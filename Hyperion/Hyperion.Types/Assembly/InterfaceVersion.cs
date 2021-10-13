

// Some parsers fail on Version and think it is a type
#pragma warning disable IDE0003

using System;

namespace Hyperion.Types.Assembly
{
    [AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
    public sealed class InterfaceVersionAttribute : Attribute
    {
        public string Version { get; }

        public InterfaceVersionAttribute(string version)
        {
            this.Version = version;
        }
    }
}