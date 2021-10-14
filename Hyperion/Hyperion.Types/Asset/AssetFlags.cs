

using System;

namespace Hyperion.Types.Asset
{
    [Flags]
    public enum AssetFlags : uint
    {
        Normal = 0,
        Maptile = 1,
        Rewritable = 2,
        Collectable = 4
    }
}
