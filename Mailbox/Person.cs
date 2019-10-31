namespace Mailbox
{
    public class Person
    {

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
      

        

    }
}