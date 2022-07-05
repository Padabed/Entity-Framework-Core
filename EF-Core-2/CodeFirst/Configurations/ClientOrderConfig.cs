using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CodeFirst.Models;

namespace CodeFirst.Configurations
{
    public class ClientOrderConfig : IEntityTypeConfiguration<ClientOrder>
    {
        public void Configure(EntityTypeBuilder<ClientOrder> builder)
        {
            builder.HasKey(e => e.IdClientOrder).HasName("IdClientOrder_PK");
            builder.Property(e => e.IdClientOrder).UseIdentityColumn();

            builder.Property(e => e.OrderDate).IsRequired();
            builder.Property(e => e.CompletionDate);
            builder.Property(e => e.Comments).HasMaxLength(300);

            builder.HasOne(e => e.IdClientNav)
                .WithMany(e => e.ClientOrders)
                .HasForeignKey(e => e.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Client_ClientOrder_FK");

            builder.HasOne(e => e.IdEmployeeNav)
                .WithMany(e => e.ClientOrders)
                .HasForeignKey(e => e.IdEmployee)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Employee_ClientOrder_FK");
        }
    }
}

