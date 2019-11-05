using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace Mailbox
{
    // I AM A MAIL BOX
    public class Mailbox : IEquatable<Mailbox>
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

        public override bool Equals(object? obj)
        {
            return Equals(obj as Mailbox);
        }

        public bool Equals([AllowNull] Mailbox other)
        {
            return other != null &&
                   Location.Equals(other.Location) &&
                   BoxSize == other.BoxSize &&
                   Owner.Equals(other.Owner);
        }
    }

    //public GetOwnersDisplay()
}
