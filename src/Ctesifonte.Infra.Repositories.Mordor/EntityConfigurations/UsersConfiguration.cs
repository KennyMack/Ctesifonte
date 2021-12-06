using Ctesifonte.Domain.Mordor.Models;
using Ctesifonte.Infra.Repositories.Base.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ctesifonte.Infra.Repositories.Mordor.EntityConfigurations
{
    public class UsersConfiguration : BaseEntityConfigurarion<User>
    {
        public UsersConfiguration(string Table, string Schema) : base(Table, Schema)
        {
        }

        public override void Configure(EntityTypeBuilder<User> config)
        {
            base.Configure(config);

            config.Property(b => b.Uid)
                .HasMaxLength(36)
                .IsRequired();
            config.Property(b => b.Username)
                .HasMaxLength(60)
                .IsRequired();
            config.Property(b => b.Email)
                .HasMaxLength(120)
                .IsRequired();
            config.Property(b => b.Password)
                .HasMaxLength(255)
                .IsRequired();
            config.Property(b => b.Role)
                .HasMaxLength(60)
                .IsRequired();
            config.Property(b => b.Active)
                .HasDefaultValue(true)
                .IsRequired();

            config.HasIndex("Id")
              .IsUnique(true);
            config.HasIndex("Email")
              .IsUnique(true);
            config.HasIndex("Username")
              .IsUnique(true);
            config.HasIndex("Uid")
              .IsUnique(true);

            config.HasIndex("Active");
        }
    }
}
