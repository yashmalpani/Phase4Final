using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phase4Final.Models
{
    public class ApplicationDBContext: DbContext 
    {
        public DbSet<Pizza> Pizza { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configuring Connection String
            optionsBuilder.UseSqlServer("Server=.;Database=Phase4;Integrated Security=true;");
        }
    }
}
