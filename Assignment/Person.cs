using FileHelpers;


namespace Assignment
{



    [DelimitedRecord(",")]
    public class Person : IPerson
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetAddress { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public Address Address { get;set; }
    }
}
