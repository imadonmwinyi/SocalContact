using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace SocialContact.Data.Models
{
    public class AppUser:IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhotoUrl { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public Address Address { get; set; }

        public ICollection<Contact> Contacts { get; set; }

        public ICollection<PhoneNumber> PhoneNumbers { get; set; }

        public ICollection<Social> Socials { get; set; }


        public AppUser()
        {
            Contacts = new List<Contact>();

            PhoneNumbers = new List<PhoneNumber>();

            Socials = new List<Social>();

        }

    }
}
