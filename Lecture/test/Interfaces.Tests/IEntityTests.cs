using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.Tests
{
    [TestClass]
    public class IEntityTests : IEntity
    {
        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        [TestMethod]
        public void CreateUser()
        {
            IEntity user = new User();

            Assert.AreEqual(0, user.Id);
            IEntity.SetMessageValue("Hello from a static field on an interface");
            Assert.AreEqual("Hello from a static field on an interface", user.Save(null));
        }

        public string SayHello()
        {
            throw new NotImplementedException();
        }
    }
}
