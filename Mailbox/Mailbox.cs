using System.Collections;

namespace Mailbox
{
    // I AM A MAIL BOX
    public class Mailbox : IEnumerable
    {
        //mailbox.Location == (x, y)
        public (int x, int y) Location { get; set; }

        public Person Owner { get; set; }

        public IEnumerator GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }

    //public GetOwnersDisplay()
}
