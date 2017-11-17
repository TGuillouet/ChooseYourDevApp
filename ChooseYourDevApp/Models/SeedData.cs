using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace ChooseYourDevApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DevContext(
                serviceProvider.GetRequiredService<DbContextOptions<DevContext>>()))
            {
                if (context.Dev.Any())
                {
                    return;   // DB has been seeded
                }

            }
        }
    }
}