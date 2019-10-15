using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        [TestMethod]
        public void If_not_configured_CreateLogger_return_null()
        {
            // Arrange
            var factory = new LogFactory();

            var fileLogger = factory.CreateLogger("FileLogger");
           
            // Assert
            Assert.IsNull(fileLogger);
           
        }

        [TestMethod]
        public void When_configured_returns_not_null()
        {
            // Arrange
            string path =Path.GetRandomFileName();
            var factory = new LogFactory();

            factory.ConfigureFileLogger(path);
            var fileLogger = factory.CreateLogger("FileLogger");
            

            // Assert
            Assert.IsNotNull(fileLogger);

            //cleanup
            File.Delete(path);

        }
    }
}
