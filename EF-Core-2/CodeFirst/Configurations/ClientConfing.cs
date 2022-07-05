using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CodeFirst.Models;

namespace CodeFirst.Configurations
{
    public class ClientConfig : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(e => e.IdClient).HasName("Client_PK");
            builder.Property(e => e.IdClient).UseIdentityColumn();

            builder.Property(e => e.ClientFirstName).HasMaxLength(50).IsRequired();
            builder.Property(e => e.ClientLastName).HasMaxLength(60).IsRequired();

            var Clients = new HashSet<Client>();

            Clients.Add(new Client
            {
                IdClient = 1,
                ClientFirstName = "priv",
                ClientLastName = "toPriv"
            });

            builder.HasData(Clients);
        }
    }
}

