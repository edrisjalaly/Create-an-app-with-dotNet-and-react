using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class DbSeeder
    {
        public static async Task SeedDb(AppDbContext context)
        {
            if (context.Activities.Any()) return;

            var activities = new List<Activity>
            {
               new()
               {
                   Title = "run",
                   Date = DateTime.Now,
                   Description = "run from now ",
                   Category = "sport",
                   City = "kabul",
                   Venue = "markaz",
                   Latitude = 90,
                   Longitude = 80,
               },
               new()
               {
                   Title = "swim",
                   Date = DateTime.Now,
                   Description = "swim from now ",
                   Category = "sport",
                   City = "kabul",
                   Venue = "markaz",
                   Latitude = 90,
                   Longitude = 80,
               }               
            };


           context.Activities.AddRange(activities);
           await context.SaveChangesAsync();
        }
    }
}
