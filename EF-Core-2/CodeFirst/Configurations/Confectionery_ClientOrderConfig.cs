using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CodeFirst.Models;

namespace CodeFirst.Configurations
{
    public class Confectionery_ClientOrderConfig : IEntityTypeConfiguration<Confectionery_ClientOrder>
    {
        public void Configure(EntityTypeBuilder<Confectionery_ClientOrder> builder)
        {
            builder.HasKey(e => new
            {
                e.IdConfectionery,
                e.IdClientOrder
            }).HasName("Confectionery_ClientOrder_PK");

            builder.ToTable("Confectionery_ClientOrder");

            builder.Property(e => e.Amount).IsRequired();
            builder.Property(e => e.Comments).HasMaxLength(300);

            builder.HasOne(e => e.IdConfectioneryNav)
                .WithMany(e => e.Confectionery_ClientOrders)
                .HasForeignKey(e => e.IdConfectionery)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Confectionery_FK");

            builder.HasOne(e => e.IdClientOrderNav)
                .WithMany(e => e.Confectionery_ClientOrders)
                .HasForeignKey(e => e.IdClientOrder)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ClientOrder_FK");
        }
    }
}

