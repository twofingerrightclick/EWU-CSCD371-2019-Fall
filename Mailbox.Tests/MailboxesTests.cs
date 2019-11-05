using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Mailbox.Tests
{
    [TestClass]
    public class MailboxesTests

    {
        private List<Mailbox> testMailboxes = new List<Mailbox>()
        {
            new Mailbox(Sizes.LargePremium, (0, 0), new Person("Chris", "Martin")),
            new Mailbox(Sizes.Small, (0, 1), new Person("Guy", "Berryman")),
            new Mailbox(Sizes.Medium, (0, 2), new Person("Will", "Champion")),
            new Mailbox(Sizes.Medium, (0, 3), new Person("Johnny", "Buckland"))
        };

        

    }
}
