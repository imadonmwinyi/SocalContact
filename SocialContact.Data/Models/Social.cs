

namespace SocialContact.Data.Models
{
    public class Social:BaseEntity
    {
        public string Link { get; set; }

        public string UserId { get; set; }

        public AppUser User { get; set; }
    }
}
