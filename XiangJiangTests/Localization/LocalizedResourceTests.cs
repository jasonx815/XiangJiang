using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        }

        [TestMethod]
        public void GetStringTest()
        {
            var actual = _localizedResource.GetString("ParameterCheck_DirectoryNotExists");
            var result = string.Equals(actual, "指定的目录路径“{0}”不存在。", StringComparison.OrdinalIgnoreCase) ||
                         string.Equals(actual, @"The specified directory path '{0}' does not exist.",
                             StringComparison.OrdinalIgnoreCase);
            Assert.IsTrue(result);
        }
    }
}