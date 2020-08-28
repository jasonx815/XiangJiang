using System;
using System.Diagnostics;
using System.Reflection;
using XiangJiang.Core;

namespace XiangJiang.Common
{
    public static class AssemblyHelper
    {
        public static Version GetFileVersion(this Assembly assembly)
        {
            Checker.Begin().NotNull(assembly, nameof(assembly));
            var info = FileVersionInfo.GetVersionInfo(assembly.Location);
            return new Version(info.FileVersion);
        }

        public static Version GetProductVersion(this Assembly assembly)
        {
            Checker.Begin().NotNull(assembly, nameof(assembly));
            var info = FileVersionInfo.GetVersionInfo(assembly.Location);
            return new Version(info.ProductVersion);
        }
    }
}