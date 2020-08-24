using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XiangJiang.Common;

namespace XiangJiang.Localization.Tests
{
    [TestClass]
    public class LocalizedResourceTests
    {
        private LocalizedResource _localizedResource;

        [TestInitialize]
        public void Init()
        {
            _localizedResource = new LocalizedResource(Resource.ResourceManager.BaseName);
            var culture = "zh-CN";
            LocalizationHelper.SetCulture(culture);
            Resource.Culture = new CultureInfo(culture);
        }

        [TestMethod]
        public void GetStringTest()
        {
            var actual = _localizedResource.GetString("ParameterCheck_DirectoryNotExists");
            Assert.IsTrue(string.Equals(actual, "指定的目录路径“{0}”不存在。", StringComparison.OrdinalIgnoreCase));
        }
    }
}