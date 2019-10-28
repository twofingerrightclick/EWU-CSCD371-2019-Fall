using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Configuration.Tests
{
    [TestClass]
    public class FileConfigTests
    {
        [DataTestMethod]
        [DataRow("cant have spaces in name", "value")]
        [DataRow("CantHave=inName", "hello")]
        [DataRow("CantHaveEqualsinValue", "hello=")]
        [DataRow("", "noEmptyNameString")]
        [DataRow("noEmptyValueString", "")]
        //[DataRow("Can't have =", "hello")]
        [ExpectedException(typeof(ArgumentException))]
        public void Set_Environment_Variable_Variable_Must_Be_Valid_Format(string variable, string value)
        {
            var fileConfiger = new FileConfig();
            fileConfiger.SetConfigValue(variable, value);
            
        }

        [DataTestMethod]
        [DataRow(null, "value")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Set_Environment_Variable_Variable_CantBe_Null(string variable, string value)
        {
            var fileConfiger = new FileConfig();
            fileConfiger.SetConfigValue(variable, value);

        }


    }

}
