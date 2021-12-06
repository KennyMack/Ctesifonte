using Ctesifonte.Domain.Base.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ctesifonte.Infra.Repositories.Base.Configurations
{
    public abstract class BaseEntityConfigurarion<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        protected string Table { get; }
        protected string Schema { get; }

        public BaseEntityConfigurarion(string Table, string Schema)
        {
            this.Table = Table;
            this.Schema = Schema;
        }

        public virtual void Configure(EntityTypeBuilder<T> config)
        {
            config.ToTable(Table, Schema);

            config.HasKey(b => b.Id);

            config.Property(b => b.Created)
                .HasDefaultValueSql("SYSDATETIME()")
                .IsRequired();
            config.Property(b => b.Modified)
                .HasDefaultValueSql("SYSDATETIME()")
                .IsRequired();

            config.HasIndex("Id")
              .IsUnique(true);
        }
    }
}
