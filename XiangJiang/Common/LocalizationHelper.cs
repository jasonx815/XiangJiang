using System.Globalization;
using System.Threading;
using XiangJiang.Core;

namespace XiangJiang.Common
{
    public sealed class LocalizationHelper
    {
        public static void SetCulture(string culture)
        {
            Checker.Begin().NotNullOrEmpty(culture, nameof(culture));
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
            CultureInfo.CurrentCulture = new CultureInfo(culture);
            CultureInfo.CurrentUICulture = new CultureInfo(culture);
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo(culture);
        }
    }
}