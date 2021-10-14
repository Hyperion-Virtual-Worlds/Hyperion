

using Hyperion.Types.StructuredData.Llsd;
using System;
using System.IO;

namespace Hyperion.Types.Asset.Format.Mesh
{
    public class LLMesh
    {
        private readonly Map m_MeshData;
        private readonly int m_EndOfHeader;
        private readonly byte[] m_AssetData;

        public LLMesh(AssetData asset)
        {
            m_AssetData = asset.Data;

            if (asset.Type != AssetType.Mesh)
            {
                throw new NotAMeshFormatException();
            }

            try
            {
                using (Stream s = asset.InputStream)
                {
                    m_MeshData = (Map)LlsdBinary.Deserialize(s);
                    m_EndOfHeader = (int)s.Position;
                }
            }
            catch
            {
                throw new NotAMeshFormatException();
            }
        }

        public enum LodLevel
        {
            LOD0,
            LOD1,
            LOD2,
            LOD3,
            Physics
        }

        public bool HasConvexPhysics() => m_MeshData.ContainsKey("physics_convex");

        public PhysicsConvexShape GetConvexPhysics(bool uselist)
        {
            IValue iv;

            if (!m_MeshData.TryGetValue("physics_convex", out iv))
            {
                throw new NoSuchMeshDataException();
            }

            var lodMap = iv as Map;

            if (lodMap == null)
            {
                throw new NoSuchMeshDataException();
            }

            int physOffset = lodMap["offset"].AsInt + m_EndOfHeader;
            int physSize = lodMap["size"].AsInt;

            if (physOffset < m_EndOfHeader || physSize <= 0)
            {
                throw new NotAMeshFormatException();
            }

            return new PhysicsConvexShape(m_AssetData, physOffset, physSize, uselist);
        }

        public bool HasLOD(LodLevel level)
        {
            switch (level)
            {
                case LodLevel.Physics:
                    return m_MeshData.ContainsKey("physics_mesh");
                case LodLevel.LOD0:
                    return m_MeshData.ContainsKey("lowest_lod");
                case LodLevel.LOD1:
                    return m_MeshData.ContainsKey("low_lod");
                case LodLevel.LOD2:
                    return m_MeshData.ContainsKey("medium_lod");
                case LodLevel.LOD3:
                    return m_MeshData.ContainsKey("high_lod");
                default:
                    throw new ArgumentOutOfRangeException(nameof(level));
            }
        }

        public MeshLOD GetLOD(LodLevel level)
        {
            string lodName;

            switch (level)
            {
                case LodLevel.Physics:
                    lodName = "physics_mesh";
                    break;
                case LodLevel.LOD0:
                    lodName = "lowest_lod";
                    break;
                case LodLevel.LOD1:
                    lodName = "low_lod";
                    break;
                case LodLevel.LOD2:
                    lodName = "medium_lod";
                    break;
                case LodLevel.LOD3:
                    lodName = "high_lod";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(level));
            }

            IValue iv;

            if (!m_MeshData.TryGetValue(lodName, out iv))
            {
                throw new NoSuchMeshDataException();
            }

            var lodMap = iv as Map;

            if (lodMap == null)
            {
                throw new NoSuchMeshDataException();
            }

            int physOffset = lodMap["offset"].AsInt + m_EndOfHeader;
            int physSize = lodMap["size"].AsInt;

            if (physOffset < m_EndOfHeader || physSize <= 0)
            {
                throw new NotAMeshFormatException();
            }

            return new MeshLOD(m_AssetData, physOffset, physSize);
        }

        public bool TryGetLODByteSize(LodLevel level, out int bytesize)
        {
            bytesize = 0;
            string lodName;

            switch (level)
            {
                case LodLevel.Physics:
                    lodName = "physics_mesh";
                    break;
                case LodLevel.LOD0:
                    lodName = "lowest_lod";
                    break;
                case LodLevel.LOD1:
                    lodName = "low_lod";
                    break;
                case LodLevel.LOD2:
                    lodName = "medium_lod";
                    break;
                case LodLevel.LOD3:
                    lodName = "high_lod";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(level));
            }

            IValue iv;

            if (!m_MeshData.TryGetValue(lodName, out iv))
            {
                return false;
            }

            var lodMap = iv as Map;

            if (lodMap == null)
            {
                return false;
            }

            bytesize = lodMap["size"].AsInt;

            if (bytesize < m_EndOfHeader || bytesize <= 0)
            {
                bytesize = 0;
                return false;
            }

            return true;
        }

        private const int MetaDataDiscount = 384;
        private const int MinimumByteSize = 16;
        private const int MeshBytesPerTriangle = 16;
        private const int MeshTriangleBudget = 250000;
        private const int MaxDistance = 512;

        // Streaming cost algorithm close to what is known
        public double CalculateStreamingCost(Vector3 primscale)
        {
            double radius = primscale.Length / 2;
            double d_lowest = Math.Min(radius / 0.03, MaxDistance);
            double d_low = Math.Min(radius / 0.06, MaxDistance);
            double d_mid = Math.Min(radius / 0.24, MaxDistance);

            int lowestLodSize;
            int lowLodSize;
            int mediumLodSize;
            int highLodSize;

            if (!TryGetLODByteSize(LodLevel.LOD3, out highLodSize))
            {
                return 0;
            }

            if (!TryGetLODByteSize(LodLevel.LOD2, out mediumLodSize))
            {
                mediumLodSize = highLodSize;
            }

            if (!TryGetLODByteSize(LodLevel.LOD1, out lowLodSize))
            {
                lowLodSize = mediumLodSize;
            }

            if (!TryGetLODByteSize(LodLevel.LOD0, out lowestLodSize))
            {
                lowestLodSize = lowLodSize;
            }

            double tri_lowest = Math.Max((double)lowestLodSize - MetaDataDiscount, MinimumByteSize) / MeshBytesPerTriangle;
            double tri_low = Math.Max((double)lowLodSize - MetaDataDiscount, MinimumByteSize) / MeshBytesPerTriangle;
            double tri_medium = Math.Max((double)mediumLodSize - MetaDataDiscount, MinimumByteSize) / MeshBytesPerTriangle;
            double tri_high = Math.Max((double)highLodSize - MetaDataDiscount, MinimumByteSize) / MeshBytesPerTriangle;

            double max_area = 102944;
            double min_area = 1;

            double high_area = Math.Min(Math.PI * d_mid * d_mid, max_area);
            double medium_area = Math.Min(Math.PI * d_low * d_low, max_area);
            double low_area = Math.Min(Math.PI * d_lowest * d_lowest, max_area);
            double lowest_area = max_area;

            lowest_area -= low_area;
            low_area -= medium_area;
            medium_area -= high_area;

            high_area = high_area.Clamp(min_area, max_area);
            medium_area = medium_area.Clamp(min_area, max_area);
            low_area = low_area.Clamp(min_area, max_area);
            lowest_area = lowest_area.Clamp(min_area, max_area);

            double total_area = high_area + medium_area + lowest_area + lowest_area;
            high_area /= total_area;
            medium_area /= total_area;
            low_area /= total_area;
            lowest_area /= total_area;

            return (tri_high * high_area +
                tri_medium * medium_area *
                tri_low * low_area +
                tri_lowest * lowest_area) / MeshTriangleBudget;
        }
    }
}