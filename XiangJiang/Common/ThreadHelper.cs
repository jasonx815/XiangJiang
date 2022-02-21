using System.Threading;
using XiangJiang.Core;

namespace XiangJiang.Common
{
    public static class ThreadHelper
    {
        public static void Cancel(this Thread thread)
        {
            Checker.Begin().NotNull(thread, nameof(thread));
            if (thread.ThreadState != ThreadState.WaitSleepJoin)
                return;

            thread.Interrupt();
        }
    }
}