
using System;
using System.Reflection;
using System.Runtime.InteropServices;

[assembly: AssemblyProduct("Hyperion Virtual Worlds")]
[assembly: AssemblyCompany("Virtual World Research Inc.")]
[assembly: AssemblyCopyright("Affero GPLv3 License+Link Exception")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

[assembly: AssemblyVersion("0.0.0.1")]
[assembly: AssemblyFileVersion("0.0.0.1")]

#if NO_HYPERION_TYPES
#else
[assembly: Hyperion.Types.Assembly.InterfaceVersion("0.0.0.0")]
#endif

[assembly: ComVisible(false)]
[assembly: CLSCompliant(false)]