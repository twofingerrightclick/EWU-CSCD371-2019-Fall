using System.ComponentModel;

namespace Assignment
{

    public class Person : IPerson
    {
        [DefaultValue("")]

        public string FirstName { get; set; } = "";

        [DefaultValue("")]
        public string LastName { get; set; }= "";

        //can't be nullable because of the interface... not sure how to handle for the situation
        public IAddress Address { get; set; } = new Address();

        [DefaultValue("")]
        public string EmailAddress { get; set; }= "";
    }
}
