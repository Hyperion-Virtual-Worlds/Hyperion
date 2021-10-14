

using System.Collections.Generic;

namespace Hyperion.Types.Asset.Format
{
    public interface IReferencesAccessor
    {
        List<UUID> References { get; }
    }
}