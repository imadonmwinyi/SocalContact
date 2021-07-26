
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SocialContact.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SocialContact.Data
{
    public static class PreSeeder
    {
        private static string path = Path.GetFullPath(@"../SocialContact.Data/Data.json/");
        private static string password = "P@ssw0rd";

        public async static Task EnsurePopulated(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<AppContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (context.Users.Any())
            {
                return;
            }
            else
            {
                var userManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<AppUser>>();

                var users = GatSample<AppUser>(File.ReadAllText(path + "User.json"));
                
                foreach(var user in users)
                {
                    user.UserName = user.Email;
                    await userManager.CreateAsync(user, password);
                    var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    await userManager.ConfirmEmailAsync(user, token);

                    await context.Addresses.AddAsync(user.Address);

                    await context.PhoneNumbers.AddRangeAsync(user.PhoneNumbers);

                    await context.Socials.AddRangeAsync(user.Socials);

                    //if(userCount > 1)
                    //{
                    //    var mainUser = await userManager.FindByNameAsync("osasfrank246@gmail.com");
                    //    var contact = new Contact { OwnerId = mainUser.Id, ContactId = user.Id };
                    //    await context.Contacts.AddAsync(contact);
                        
                    //}
                    //userCount += 1;
                }

                await context.SaveChangesAsync();
            }
        }

        private static List<T> GatSample<T>(string fileLocation)
        {
            var output = JsonSerializer.Deserialize<List<T>>(fileLocation, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return output;
        }
    }
}
