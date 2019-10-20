using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Inheritance.Tests
{
    [TestClass]
    public class ActorTests
    {
        [TestMethod]

        public void Actor_Penny_Speaks()
        {
            // Arrange
            Actor item = new Penny {};

            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream))
                {
                    // Act
                    ((Penny)item).Speak(writer);
                    writer.Flush();

                    stream.Position = 0;
                    stream.Seek(0, SeekOrigin.Begin);

                    // Assert
                    using (var reader = new StreamReader(stream))
                    {
                        var lineWritten = reader.ReadLine();
                        Assert.AreEqual("helo", lineWritten);
                    }
                }
            }
        }


        [TestMethod]

        public void Actor_Raj_Speaks_no_women()
        {
            // Arrange
            Actor actor = new Raj {};

            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream))
                {
                    // Act
                    actor.Speak(writer);
                    writer.Flush();

                    stream.Position = 0;
                    stream.Seek(0, SeekOrigin.Begin);

                    // Assert
                    using (var reader = new StreamReader(stream))
                    {
                        var lineWritten = reader.ReadLine();
                        Assert.AreNotEqual("Raj mumbles", lineWritten);
                    }
                }
            }
        }

        [TestMethod]

        public void Actor_Raj_Speaks_with_women()
        {
            // Arrange
            Actor actor = new Raj {WomenPresent=true};

            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream))
                {
                    // Act
                    actor.Speak(writer);
                    writer.Flush();

                    stream.Position = 0;
                    stream.Seek(0, SeekOrigin.Begin);

                    // Assert
                    using (var reader = new StreamReader(stream))
                    {
                        var lineWritten = reader.ReadLine();
                        Assert.AreEqual("Raj mumbles", lineWritten);
                    }
                }
            }
        }
    }
}
