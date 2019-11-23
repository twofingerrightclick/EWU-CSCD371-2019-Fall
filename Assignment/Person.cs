namespace Assignment
{

    public class Person : IPerson
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IAddress Address { get;set; }

        public string EmailAddress { get; set; }
    }
}
