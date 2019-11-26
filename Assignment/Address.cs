using System.ComponentModel;

namespace Assignment
{

    public class Address : IAddress
    {
        [DefaultValue("")]
        public string StreetAddress { get; set; } = "";
        [DefaultValue("")]
        public string City { get; set; } = "";
        [DefaultValue("")]
        public string State { get; set; }= "";
        [DefaultValue("")]
        public string Zip { get; set; }= "";
    }
}
