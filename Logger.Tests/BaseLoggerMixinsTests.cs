using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class BaseLoggerMixinsTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Error_WithNullLogger_ThrowsException()
        {
            // Arrange
            string[] args= new string[0];
            // Act
            BaseLoggerMixins.Error(null, "message", args );

            // Assert
        }

        [TestMethod]
        
        public void Error_Extension_Works()
        {
            string tempPath = Path.GetRandomFileName();
            string[] args = new string[0];
            // Arrange
            var logger = new FileLogger(tempPath);
            // Act
            BaseLoggerMixins.Error(logger, "message", args);

            // Assert
            File.Delete(tempPath);

        }



        [TestMethod]
        public void Error_WithData_LogsMessage()
        {
            // Arrange
            var logger = new TestLogger();

            // Act
            logger.Error("Message {0}", 42);

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Error, logger.LoggedMessages[0].LogLevel);
            Assert.AreNotEqual("Message 42", logger.LoggedMessages[0].Message);
        }

    }

    public class TestLogger : BaseLogger
    {
        public List<(LogLevel LogLevel, string Message)> LoggedMessages { get; } = new List<(LogLevel, string)>();

        public override void Log(LogLevel logLevel, string message)
        {
            LoggedMessages.Add((logLevel, message));
        }

       
    }

    static class ExtensionMethods
    {
        public static void Error(this TestLogger t, string message, int errorNum)
        {
            t.Log(LogLevel.Error, String.Format("{0} {1}", message, errorNum));
        }

        public static void Warning(this TestLogger t, string message, int errorNum)
        {
            t.Log(LogLevel.Error, String.Format("{0} {1}", message, errorNum));
        }
    }
}
