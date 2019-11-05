using System;
using System.Collections;

namespace Mailbox
{
    // I AM A MAIL BOX
    public class Mailbox
    {
        //mailbox.Location == (x, y)
        public (int X, int Y) Location { get; set; }

        public Sizes BoxSize{ get; set; } 

        public Person Owner { get; set; }

        public Mailbox(Sizes size, ValueTuple<int, int> location, Person Owner)
        {
            if (size.Equals(Sizes.Premium)) throw new ArgumentException(" \"Premium\" is not a size itself", (nameof(size)));

            BoxSize = size;
            Location = location;
            this.Owner = Owner;
        }

        override
    public string ToString()
        {
            string mailboxString = $"Owner: {Owner.ToString()}, Location: x = {Location.X}, y = {Location.Y}";
            if (BoxSize == Sizes.Unspecified)
            {
                return mailboxString;
            }
            return mailboxString + $", BoxSize: {BoxSize}";
        }


       
    }

    //public GetOwnersDisplay()
}
