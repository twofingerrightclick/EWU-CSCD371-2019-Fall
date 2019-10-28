﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Configuration.Tests
{
    [TestClass]
    public class EnvironmentConfigTests
    {
        [TestMethod]
        public void Set_Environment_Variable()
        {
            var environmentConfiger = new EnvironmentConfig();
            environmentConfiger.SetConfigValue("test1", "a");
            Assert.IsTrue(environmentConfiger.GetConfigValue("test1", null));
        }

        [TestMethod]
        public void Clear_Config_Value()
        {
            var environmentConfiger = new EnvironmentConfig();
            environmentConfiger.SetConfigValue("test1", "a");
            environmentConfiger.SetConfigValue("test1", null);

            Assert.IsFalse(environmentConfiger.GetConfigValue("test1", null));

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Throws_Exception_If_VariableName_Is_Empty()
        {
            var environmentConfiger = new EnvironmentConfig();
            environmentConfiger.SetConfigValue(null!, "a");

        }
    }
    
}
