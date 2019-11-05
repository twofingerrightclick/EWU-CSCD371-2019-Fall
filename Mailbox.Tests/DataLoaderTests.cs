using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Mailbox.Tests
{
    [TestClass]

    public class DataLoaderTests
    {
        private List<Mailbox> testMailboxes = new List<Mailbox>()
        {
            new Mailbox(Sizes.LargePremium, (1, 1), new Person("John", "Doe")),
            new Mailbox(Sizes.Small, (15, 5), new Person("Jane", "Doe")),
            new Mailbox(Sizes.Medium, (30, 10), new Person("Indiana", "Jones"))
        };
        //public Mailbox(Sizes size, ValueTuple<int, int> location, Person owner)
        [DataTestMethod]
        [DataRow(Sizes.Small, 0,0, "Jeff", "Smalls")]
        public void Test_One_MailBox_Write_Read(Sizes size, int x, int y, string fName, string lName)
        {
            Console.WriteLine("step0");
            using var mS = new MemoryStream();
            using DataLoader dl = new DataLoader(mS);

            Console.WriteLine("step1");


            Person person = new Person(fName, lName);
            var location = (x, y);
            Console.WriteLine("step68768");
            Mailbox mailBox = new Mailbox(size, location, person);

            Console.WriteLine(mailBox);

            List<Mailbox> mailboxesStart = new List<Mailbox>();
            List<Mailbox> mailboxesEnd = new List<Mailbox>();
            mailboxesStart.Add(mailBox);

            try
            {
                dl.Save(mailboxesStart);



                mailboxesEnd = dl.Load();

                Assert.IsTrue(mailboxesEnd[0].Equals(mailboxesStart[0]));

            }

            finally
            {
               dl.Dispose();
                  
            }

        }



        [TestMethod()]
        public void SaveTest()
        {
            //Arrange
            List<Mailbox> mailboxes = new List<Mailbox>();
            var ms = new MemoryStream();
            DataLoader dataLoader = new DataLoader(ms);

            try
            {
                //Act
                dataLoader.Save(testMailboxes);
                string? jsonLine;

                ms.Position = 0;
                using (StreamReader sr = new StreamReader(ms))
                {
                    while ((jsonLine = sr.ReadLine()) != null)
                    {
                        mailboxes.Add(JsonConvert.DeserializeObject<Mailbox>(jsonLine));
                    }
                }

                //Assert
                Assert.AreEqual(3, mailboxes.Count);
            }
            finally
            {
                dataLoader.Dispose();
            }

        }

    }
}
