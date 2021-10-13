

using System;
using System.Collections.Generic;

namespace Hyperion.Types.Agent
{
    public class CircuitInfo
    {
        public uint CircuitCode;
        public string CapsPath = string.Empty;
        public bool IsChild;
        public Dictionary<UInt64, string> ChildrenCapSeeds = new Dictionary<UInt64, string>();
    }
}
