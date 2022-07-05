using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CodeFirst.Models;

namespace CodeFirst.Configurations
{
    public class ConfectioneryConfig : IEntityTypeConfiguration<Confectionery>
    {
        public void Configure(EntityTypeBuilder<Confectionery> builder)
        {
            builder.HasKey(e => e.IdConfectionery).HasName("IdConfectionery_PK");
            builder.Property(e => e.IdConfectionery).UseIdentityColumn();

            builder.Property(e => e.Name).HasMaxLength(100).IsRequired();
            builder.Property(e => e.PricePerOne).IsRequired();
            
        }
    }
}

