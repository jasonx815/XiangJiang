using Microsoft.VisualStudio.TestTools.UnitTesting;
using XiangJiang.Common;

namespace XiangJiangTests.Common
{
    [TestClass]
    public class ReflectHelperTests
    {
        [TestMethod]
        public void GetFieldValueTest()
        {
            var person = new Person {Age = 1, Name = "xiang"};
            var actual = ReflectHelper.GetFieldValue<Person, string>(person, "Name");
            Assert.AreEqual(actual, person.Name);
        }
    }

    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }
}