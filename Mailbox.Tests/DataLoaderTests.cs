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
            new Mailbox(Sizes.LargePremium, (0, 0), new Person("Chris", "Martin")),
            new Mailbox(Sizes.Small, (0, 1), new Person("Guy", "Berryman")),
            new Mailbox(Sizes.Medium, (0, 2), new Person("Will", "Champion")),
            new Mailbox(Sizes.Medium, (0, 3), new Person("Johnny", "Buckland"))
        };

        [TestMethod]
        public void Test_One_MailBox_Write_Read()
        {
            
            using var mS = new MemoryStream();
            using DataLoader dl = new DataLoader(mS);


            List<Mailbox> mailboxesStart = new List<Mailbox>();
            List<Mailbox> mailboxesEnd = new List<Mailbox>();
            mailboxesStart.Add(testMailboxes[1]);

            try
            {
                dl.Save(mailboxesStart);


                mailboxesEnd = dl.Load();

                Console.WriteLine(mailboxesStart[0]);
                Console.WriteLine(mailboxesEnd[0]);

                Assert.IsTrue(mailboxesEnd[0].Equals(mailboxesStart[0]));

            }

            finally
            {
                dl.Dispose();

            }

        }


    }
}
