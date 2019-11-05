using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Mailbox.Tests
{
    [TestClass]
    public class PersonTests

    {   //how to pass an object type as data?
        [DataTestMethod]
        [DataRow("first", "last", "first", "last1", DisplayName = "Different People")]
        
        public void Compare_Two_People_Different_IsFalse(string firstName1, string lastName1, string firstName2, string lastName2)
        {
            Person person1 = new Person(firstName1,lastName1);
            Person person2 = new Person(firstName2, lastName2);

            Assert.IsFalse(person1.Equals(person2));


        }

        [DataTestMethod]
        [DataRow("first", "last", "first", "last", DisplayName = "Same People")]
        public void Compare_Two_People_The_Same_True(string firstName1, string lastName1, string firstName2, string lastName2)
        {
            Person person1 = new Person(firstName1, lastName1);
            Person person2 = new Person(firstName2, lastName2);

            Assert.IsTrue(person1.Equals(person2));


        }

        [DataTestMethod]
        [DataRow("first", "last", "first", "last", DisplayName = "Same People")]
        public void Object_Compare_Two_People_The_Same_True(string firstName1, string lastName1, string firstName2, string lastName2)
        {
            Person person1 = new Person(firstName1, lastName1);
            Person person2 = new Person(firstName2, lastName2);

            Assert.IsTrue((person1).Equals((Object)person2));


        }
      

    }
}
