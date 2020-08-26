using System.Diagnostics;
using System.IO;
using System.Linq;
using XiangJiang.Core;

namespace XiangJiang.Common
{
    public static class ProcessHelper
    {
        public static bool IsRunning(string path)
        {
            Checker.Begin()
                .NotNullOrEmpty(path, nameof(path))
                .CheckFileExists(path);
            var processName = Path.GetFileNameWithoutExtension(path);
            var processes = Process.GetProcessesByName(processName);
            return processes?.Any() ?? false;
        }

        public static bool IsRunning(int id)
        {
            return Process.GetProcesses().Any(x => x.Id == id);
        }

        public static Process GetProcessById(int id)
        {
            var processes = Process.GetProcesses();
            return processes.FirstOrDefault(pr => pr.Id == id);
        }
    }
}