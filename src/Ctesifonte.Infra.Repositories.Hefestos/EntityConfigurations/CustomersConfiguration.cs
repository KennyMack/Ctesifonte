using Ctesifonte.Domain.Hefestos.Models;
using Ctesifonte.Infra.Repositories.Base.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ctesifonte.Infra.Repositories.Hefestos.EntityConfigurations
{
    public class CustomersConfiguration : BaseEntityConfigurarion<Customers>
    {
        public CustomersConfiguration(string Table, string Schema) : base(Table, Schema)
        {
        }

        public override void Configure(EntityTypeBuilder<Customers> config)
        {
            base.Configure(config);

            config.Property(b => b.Id)
                .HasMaxLength(36)
                .IsRequired();

            config.Property(b => b.Name)
                .HasMaxLength(120)
                .IsRequired();

            config.Property(b => b.CNPJ)
                .HasMaxLength(20)
                .IsRequired();

            config.Property(b => b.Email)
                .HasMaxLength(120)
                .IsRequired();

            config.Property(b => b.Active)
                .HasDefaultValue(true)
                .IsRequired();

            config.HasIndex("Email");

            config.HasIndex("Active");
        }
    }
}
