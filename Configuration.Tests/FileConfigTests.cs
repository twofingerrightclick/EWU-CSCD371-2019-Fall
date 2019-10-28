﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

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

        [DataTestMethod]
        [DataRow("name", "value1")]
        [DataRow("name", "value2")]
        [DataRow("name", "value3")]
        public void Set_Variable_Correctly_Appends_To_File(string variable, string value)
        {
            var fileConfiger = new FileConfig();
            fileConfiger.SetConfigValue(variable, value);
            Assert.IsTrue(fileConfiger.GetConfigValue(variable, value));
        }


        [DataTestMethod]
        [DataRow("name", "test", "<name>=<value>")]

        public void Config_File_Entry_Correctly_Parsed(string name, string value, string testEntry)
        {

            string testFilePath = Environment.CurrentDirectory + Path.DirectorySeparatorChar + "fileTest.settings";

            try
            {
                File.Delete(testFilePath);

                var fileConfiger = new FileConfig();
                fileConfiger.FilePath = testFilePath;

                fileConfiger.SetConfigValue(name, value);

                string[] results = fileConfiger.ParseConfigEntry(testEntry);


                Assert.IsTrue(results[0] == name && results[1] == value);
            }

            finally
            {
                File.Delete(testFilePath);
            }
        }



    }

}
