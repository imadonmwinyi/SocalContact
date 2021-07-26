

using System.ComponentModel.DataAnnotations.Schema;

namespace SocialContact.Data.Models
{
    public class Contact:BaseEntity
    {

        public string OwnerId { get; set; }

        [ForeignKey("OwnerId")]
        public AppUser User { get; set; }


        public string ContactId { get; set; }

        [ForeignKey("ContactId")]
        public AppUser UserContact { get; set; }

    }
}
