using Ctesifonte.Domain.Hefestos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ctesifonte.Infra.Repositories.Hefestos.Context
{
    public class HefestosDbContext : DbContext
    {
        public virtual DbSet<Customers> Customers { get; set; }
        private string ConnectionString { get; }
        public HefestosDbContext(IConfiguration configuration) : base()
        {
            ConnectionString = configuration.GetConnectionString("Hefestos");
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
