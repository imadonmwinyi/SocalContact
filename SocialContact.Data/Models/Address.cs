using SocialContact.Data.Enum;


namespace SocialContact.Data.Models
{
    public class Address:BaseEntity
    {
        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public AddressType Type { get; set; }

        public string UserId { get; set; }

        public AppUser User { get; set; }
    }
}
