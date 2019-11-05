using System.Diagnostics.CodeAnalysis;

namespace Mailbox
{
    public struct Person : System.IEquatable<Person>
    {
        //make a struct!

        public (string first, string last) Name { get; private set; }

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
            return $"{Name.last}, {Name.first}";
        }

        public bool Equals([AllowNull] Person other)
        {   
            //name is a value tuple so does this work without any boxing?
            return Name == other.Name;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Person?);
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}