using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration.Tests
{
    [TestClass]
    public class MockConfigTests
    {

        [DataTestMethod]
        [DataRow("cant have spaces in name", "spacesinName")]
        [DataRow("CantHave=inName", "equalsInName")]
        [DataRow("CantHaveEqualsinValue", "Equals=")]
        [DataRow("", "noEmptyNameString")]
        [DataRow("noEmptyValueString", "")]
        [DataRow(null, "value")]

        [ExpectedException(typeof(ArgumentException))]
        public void Set_Environment_Variable_Variable_Must_Be_Valid_Format(string variable, string value)
        {
            var mockConfiger = new MockConfig();
            mockConfiger.SetConfigValue(variable, value);

        }

        [DataTestMethod]
        [DataRow("name", "value1")]
        [DataRow("name", "value2")]
        [DataRow("name", "value3")]
        public void Set_Variable_Correctly_Appends_To_File(string variable, string value)
        {
            var mockConfiger = new MockConfig();
            mockConfiger.SetConfigValue(variable, value);
            Assert.IsTrue(mockConfiger.GetConfigValue(variable, out value));
        }

        [DataTestMethod]
        [DataRow("name1", "test")]

        public void Get_Entry_By_Name_True_When_Entry_Exists_And_False_When_Not(string name, string value)
        {
            var mockConfiger = new MockConfig();
            
                mockConfiger.SetConfigValue("2name2", "multipleEntries");
                mockConfiger.SetConfigValue(name, value);
                mockConfiger.SetConfigValue("3name3", "multipleEntries");

                Assert.IsTrue(mockConfiger.GetConfigValue(name, out value));
                Assert.IsFalse(mockConfiger.GetConfigValue("thisEntryWasntSet", out value));

        }

        [TestMethod]
        public void Changes_Asscoiated_Config_value_If_Config_Value_Already_Set_For_Name()
        {

                var mockConfiger = new MockConfig();
           
                string name = "name";
                string originalValue = "one";
                string newValue = "two";

                mockConfiger.SetConfigValue(name, originalValue);
                mockConfiger.SetConfigValue(name, newValue);

                string finalValue;
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                mockConfiger.GetConfigValue(name, out finalValue);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                Assert.IsTrue(string.Equals(finalValue, newValue));

        }
        [TestMethod]

        public void Remove_Config_Entry_By_Setting_With_Null_Success_True()
        {

                var mockConfiger = new MockConfig();
               

                string name = "name";
                string originalValue = "one";


                mockConfiger.SetConfigValue(name, originalValue);
                mockConfiger.SetConfigValue(name, null);


                string finalValue;
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                Assert.IsFalse(mockConfiger.GetConfigValue(name, out finalValue));
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.


           
        }
    }
}
