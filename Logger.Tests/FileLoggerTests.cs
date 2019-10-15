using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException),"filepath is null")]
        public void Error_WithNullLogger_ThrowsException()
        {
            // Arrange

            // Act
            FileLogger testFileLogger = new FileLogger(null);

            // Assert
            testFileLogger.Log(LogLevel.Error, "the path is null");

           
        }

        [TestMethod]
      
        public void Log_Written_To_File_Succesfull()
        {
            // Arrange

            string tempPath= Path.GetRandomFileName();

            // Act
            FileLogger testFileLogger = new FileLogger(tempPath);
            testFileLogger.ClassName = "FileLogger";
            testFileLogger.Log(LogLevel.Error, "there was an error");
            testFileLogger.Log(LogLevel.Warning, "there was a warning");

            using (StreamReader r = File.OpenText(tempPath))
            {
                LogToConsole(r);
            }


            // Assert
            Assert.IsTrue(File.Exists(tempPath));

            //clean up

            File.Delete(tempPath);



        }

        public static void LogToConsole(StreamReader r)
        {
            string line;
            while ((line = r.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }

    }
}
