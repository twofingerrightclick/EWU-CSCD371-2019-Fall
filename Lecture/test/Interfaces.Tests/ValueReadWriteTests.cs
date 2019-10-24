using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.Tests
{
    [TestClass]
    public class ValueReadWriteTests
    {
        [TestMethod]
        public void CanIBeIWriteValue()
        {
            ValueReadWrite valueReadWrite = new ValueReadWrite();

            Assert.IsNotNull(valueReadWrite as IWriteValue);

            // valueReadWrite.Save(null);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void IWriteValue_ShouldThrowExceptionOnSave()
        {
            IWriteValue valueReadWrite = new ValueReadWrite();

            Assert.IsNotNull(valueReadWrite as IWriteValue);

            valueReadWrite.Save(null);
        }
    }
}
