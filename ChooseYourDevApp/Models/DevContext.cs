using System;
using Microsoft.EntityFrameworkCore;

namespace ChooseYourDevApp.Models
{
    public class DevContext : DbContext
    {
        public DevContext(DbContextOptions<DevContext> options)
            : base(options)
        {
        }

        public DbSet<Dev> Dev { get; set; }

    }
}
