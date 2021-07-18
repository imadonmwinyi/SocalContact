using SocialContact.Data.Enum;

namespace SocialContact.Data.Models
{
    public class PhoneNumber:BaseEntity
    {
        public string Number { get; set; }

        public PhoneNumberType Type { get; set; }

        public string UserId { get; set; }

        public AppUser User { get; set; }
    }
}
