using Microsoft.EntityFrameworkCore;
using POS_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Server.Context
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<ClientAccount> clients => Set<ClientAccount>();
        public ApplicationDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Bank25.db");
        }


    }
}
