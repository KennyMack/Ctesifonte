using Ctesifonte.Domain.Mordor.Models;
using Ctesifonte.Infra.Repositories.Mordor.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ctesifonte.Infra.Repositories.Mordor.Context
{
    public class MordorDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }

        private string ConnectionString { get; }

        public MordorDbContext()
        {
            ConnectionString = Environment.GetEnvironmentVariable("CONNMORDOR");
        }

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
            modelBuilder.ApplyConfiguration(new UsersConfiguration("USERS", "MORDOR"));
        }
    }
}
