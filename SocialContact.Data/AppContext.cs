using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialContact.Data.Models;

namespace SocialContact.Data
{
   public class AppContext:IdentityDbContext
   {
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {

        }

        public DbSet<AppUser> AppUsers { get; set; }

        public DbSet<Social> Socials { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
    }
}
