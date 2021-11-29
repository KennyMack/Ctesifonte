using Ctesifonte.Domain.Mordor.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ctesifonte.Infra.Repositories.Mordor.Context
{
    public class MordorDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }

        private string ConnectionString { get; }
        public MordorDbContext(IConfiguration configuration) : base()
        {
            ConnectionString = configuration.GetConnectionString("Mordor");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.
        }
    }
}
