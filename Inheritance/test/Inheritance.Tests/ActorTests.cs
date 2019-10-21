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
            Actor actor = new Penny {};

            string lineWritten = writerHelper(actor);
            Assert.AreEqual(((Penny)actor).Name + " says \"Who do we love?\"", lineWritten);
                
        }


        [TestMethod]

        public void Actor_Sheldon_Speaks()
        {
            // Arrange
            Actor actor = new Sheldon { };

            string lineWritten = writerHelper(actor);
            Assert.AreEqual(((Sheldon)actor).Name + " says \"I'll be back before this banana hits the ground.\"", lineWritten);

        }


        [TestMethod]

        public void Actor_Raj_Speaks_no_women()
        {
            // Arrange
            Actor actor = new Raj {};

            string lineWritten = writerHelper(actor);
            Assert.AreEqual(((Raj)actor).Name + " says \"I'm sorry I'm so late. I was on the phone with my mother.\"", lineWritten);
           
               
        }

        [TestMethod]

        public void Actor_Raj_Speaks_with_women()
        {
            // Arrange
            Actor actor = new Raj {WomenPresent=true};

            string lineWritten = writerHelper(actor);
            
            Assert.AreEqual("Raj mumbles", lineWritten);
                    
                
            
        }

        public string writerHelper(Actor actor)
        {
            string lineWritten;

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
                        lineWritten = reader.ReadLine();
                        
                    }
                }
            }
            return lineWritten;
        }
    }
}
