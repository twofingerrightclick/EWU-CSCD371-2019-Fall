using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Configuration.Tests
{
    [TestClass]
    public class FileConfigTests
    {

        static string testFilePath = Environment.CurrentDirectory + Path.DirectorySeparatorChar + "fileTest.settings";


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
            var fileConfiger = new FileConfig();
            fileConfiger.SetConfigValue(variable, value);

        }

       

        [DataTestMethod]
        [DataRow("name", "value1")]
        [DataRow("name", "value2")]
        [DataRow("name", "value3")]
        public void Set_Variable_Correctly_Appends_New_Entry_To_File(string variable, string value)
        {
            var fileConfiger = new FileConfig();
            fileConfiger.SetConfigValue(variable, value);
            Assert.IsTrue(fileConfiger.GetConfigValue(variable, out value));
        }


        [DataTestMethod]
        [DataRow("name", "test", "<name>=<test>")]

        public void Config_File_Entry_Correctly_Parsed(string name, string value, string testEntry)
        {


            try
            {
                File.Delete(testFilePath);

                var fileConfiger = new FileConfig();
                fileConfiger.FilePath = testFilePath;

                fileConfiger.SetConfigValue(name, value);

                string[] results = fileConfiger.ParseConfigEntry(testEntry);



                Assert.IsTrue(results[0] == name);
                Assert.IsTrue(results[1] == value);
            }

            finally
            {
                File.Delete(testFilePath);
            }
        }


        [DataTestMethod]
        [DataRow("name1", "test")]


        public void Get_Entry_By_Name_True_When_Entry_Exists_And_False_When_Not(string name, string value)
        {


            try
            {
                File.Delete(testFilePath);

                var fileConfiger = new FileConfig();
                fileConfiger.FilePath = testFilePath;

                fileConfiger.SetConfigValue("2name2", "multipleEntries");
                fileConfiger.SetConfigValue(name, value);
                fileConfiger.SetConfigValue("3name3", "multipleEntries");


                Assert.IsTrue(fileConfiger.GetConfigValue(name, out value));
                Assert.IsFalse(fileConfiger.GetConfigValue("thisEntryWasntSet", out value));

            }

            finally
            {
                File.Delete(testFilePath);
            }
        }


        [TestMethod]

        public void Changes_Asscoiated_Config_value_If_Config_Value_Already_Set_For_Name()
        {


            try
            {
                File.Delete(testFilePath);

                var fileConfiger = new FileConfig();
                fileConfiger.FilePath = testFilePath;

                string name = "name";
                string originalValue = "one";
                string newValue = "two";

                

                fileConfiger.SetConfigValue(name, originalValue);
                fileConfiger.SetConfigValue(name, newValue);


                string finalValue;
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                fileConfiger.GetConfigValue(name, out finalValue);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                Assert.IsTrue(string.Equals(finalValue, newValue));


            }

            finally
            {
                File.Delete(testFilePath);
            }
        }


        [TestMethod]

        public void Remove_Config_Entry_By_Setting_With_Null_Success_True()
        {


            try
            {
                File.Delete(testFilePath);

                var fileConfiger = new FileConfig();
                fileConfiger.FilePath = testFilePath;

                string name = "name";
                string originalValue = "one";
                



                fileConfiger.SetConfigValue(name, originalValue);
                fileConfiger.SetConfigValue(name, null);


                string finalValue;
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                Assert.IsFalse(fileConfiger.GetConfigValue(name, out finalValue));
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.



            }

            finally
            {
                File.Delete(testFilePath);
            }
        }



    }

}
