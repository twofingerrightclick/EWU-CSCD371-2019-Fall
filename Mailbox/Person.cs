using System.Diagnostics.CodeAnalysis;

namespace Mailbox
{
    public struct Person : System.IEquatable<Person>
    {
        //make a struct!

        public (string firstName, string lastName) Name { get;  set; }

        public Person( string firstName, string lastName) {
            if (firstName is null)
            {
                throw new System.ArgumentNullException(nameof(firstName));
            }

            if (lastName is null)
            {
                throw new System.ArgumentNullException(nameof(lastName));
            }

            Name = (firstName, lastName);


        }

        public override string ToString()
        {
            return $"{Name.lastName}, {Name.firstName}";
        }

        public bool Equals([AllowNull] Person other)
        {   
            //name is a value tuple so does this work without any boxing?
            return Name == other.Name;
        }

        //public override bool Equals(object? obj)
        //{
        //   return (obj as Person)this;
        //}

            //Person p = new Person();
            //object p2 = new Person()
            //p1.Equals((Obj) p) versus p1.Equals(p2);
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }
    }
}