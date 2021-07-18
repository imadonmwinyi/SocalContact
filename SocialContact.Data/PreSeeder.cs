
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SocialContact.Data
{
    public static class PreSeeder
    {
        private static string path = Path.GetFullPath(@"../ContactApp.Lib.Data/Data.json");
        private static string password = "P@ssw0rd";

        public static void EnsurePopulated(IApplicationBuilder app)
        {
           
        }
    }
}
