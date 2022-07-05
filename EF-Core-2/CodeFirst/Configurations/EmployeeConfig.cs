using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CodeFirst.Models;

namespace CodeFirst.Configurations
{
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.IdEmployee).HasName("IdEmployee_PK");
            builder.Property(e => e.IdEmployee).UseIdentityColumn();

            builder.Property(e => e.EmpFirstName).HasMaxLength(50).IsRequired();
            builder.Property(e => e.EmpLastName).HasMaxLength(60).IsRequired();
           

        }
    }
}

