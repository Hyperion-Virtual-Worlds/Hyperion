

using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Hyperion.Types.Asset.Format
{
    public class ScriptSource : IReferencesAccessor
    {
        private static readonly Regex m_HeuristicUUIDPattern = new Regex("[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}");

        public ScriptSource(AssetData asset)
        {
            using (var assetdata = asset.InputStream)
            {
                string data = assetdata.ReadToStreamEnd().FromUTF8Bytes();

                foreach (Match match in m_HeuristicUUIDPattern.Matches(data))
                {
                    UUID id = new UUID(match.Value);

                    if (id != UUID.Zero && !References.Contains(id))
                    {
                        References.Add(id);
                    }
                }
            }
        }

        public List<UUID> References { get; } = new List<UUID>();
    }
}