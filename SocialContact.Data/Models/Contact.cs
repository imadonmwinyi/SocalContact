
using System;

namespace SocialContact.Data.Models
{
    public class Contact:BaseEntity
    {

        public string UserId { get; set; }

        public string ContactId { get; set; }

        public AppUser AppUser { get; set; }


    }
}
