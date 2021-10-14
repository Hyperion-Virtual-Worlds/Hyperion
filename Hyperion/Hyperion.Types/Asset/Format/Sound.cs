

using NVorbis;

namespace Hyperion.Types.Asset.Format
{
    public sealed class Sound
    {
        /// <summary>
        /// duration in seconds
        /// </summary>
        public double Duration;

        public Sound(AssetData data)
        {
            using (VorbisReader reader = new VorbisReader(data.InputStream, true))
            {
                Duration = reader.TotalTime.TotalSeconds;
            }
        }
    }
}