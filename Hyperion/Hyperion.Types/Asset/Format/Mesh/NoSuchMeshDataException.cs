

using System;
using System.Runtime.Serialization;

namespace Hyperion.Types.Asset.Format.Mesh
{
    [Serializable]
    public class NoSuchMeshDataException : Exception
    {
        public NoSuchMeshDataException()
        {
        }

        public NoSuchMeshDataException(string message) : base(message)
        {
        }

        protected NoSuchMeshDataException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public NoSuchMeshDataException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}