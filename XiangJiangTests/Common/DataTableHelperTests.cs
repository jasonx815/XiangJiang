using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XiangJiang.Common;

namespace XiangJiangTests.Common
{
    [TestClass()]
    public class DataTableHelperTests
    {
        private DataTable _mockDataTable;
        [TestInitialize]
        public void Init()
        {
            _mockDataTable = new DataTable();
            _mockDataTable.TableName = "EMP";
            _mockDataTable.Columns.Add("Name", typeof(string));
            _mockDataTable.Columns.Add("Salary", typeof(string));
            _mockDataTable.Columns.Add("Commission", typeof(int));

            var dr = _mockDataTable.NewRow();
            dr["Name"] = "Arnold";
            dr["Salary"] = "10000";
            dr["Commission"] = 20;
            _mockDataTable.Rows.Add(dr);
            dr = _mockDataTable.NewRow();
            dr["Name"] = "Arnold";
            dr["Salary"] = "3000";
            dr["Commission"] = 15;
            _mockDataTable.Rows.Add(dr);
            dr = _mockDataTable.NewRow();
            dr["Name"] = "Molin";
            dr["Salary"] = null;
            dr["Commission"] = 15;
            _mockDataTable.Rows.Add(dr);
        }

        [TestMethod()]
        public void CastDecimalThenSumTest()
        {
            decimal actual = _mockDataTable.CastDecimalThenSum("Salary");
            Assert.AreEqual(13000M, actual);
        }
    }
}