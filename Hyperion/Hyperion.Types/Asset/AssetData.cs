

using Hyperion.Types.Asset.Format;
using System;
using System.Collections.Generic;
using System.IO;

namespace Hyperion.Types.Asset
{
    public class AssetData : AssetMetadata, IReferencesAccessor
    {
        public byte[] Data = new byte[0];

        public AssetData()
        {
        }

        public AssetData(AssetData copy) : base(copy)
        {
            Data = new byte[copy.Data.Length];
            Buffer.BlockCopy(copy.Data, 0, Data, 0, Data.Length);
        }

        public Stream InputStream
        {
            get { return new MemoryStream(Data); }
        }

        #region References accessor

        public List<UUID> References
        {
            get
            {
                List<UUID> refs;

                switch (Type)
                {
                    case AssetType.Bodypart:
                    case AssetType.Clothing:
                        try
                        {
                            refs = new Wearable(this).References;
                            refs.Remove(ID);
                        }
                        catch
                        {
                            refs = new List<UUID>();
                        }

                        return refs;
                    case AssetType.Gesture:
                        try
                        {
                            refs = new Gesture(this).References;
                            refs.Remove(ID);
                        }
                        catch
                        {
                            refs = new List<UUID>();
                        }

                        return refs;
                    case AssetType.Material:
                        try
                        {
                            refs = new Material(this).References;
                            refs.Remove(ID);
                        }
                        catch
                        {
                            refs = new List<UUID>();
                        }

                        return refs;
                    case AssetType.Notecard:
                        try
                        {
                            refs = new Notecard(this).References;
                            refs.Remove(ID);
                        }
                        catch
                        {
                            refs = new List<UUID>();
                        }

                        return refs;
                    case AssetType.Object:
                        try
                        {
                            return ObjectReferenceDecoder.GetReferences(this);
                        }
                        catch
                        {
                            return new List<UUID>();
                        }
                    case AssetType.LSLText:
                        try
                        {
                            refs = new ScriptSource(this).References;
                            refs.Remove(ID);
                        }
                        catch
                        {
                            refs = new List<UUID>();
                        }

                        return refs;
                    default:
                        break;
                }

                return new List<UUID>();
            }
        }

        #endregion
    }
}