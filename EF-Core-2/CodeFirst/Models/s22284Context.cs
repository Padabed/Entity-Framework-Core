using System;
using Microsoft.EntityFrameworkCore;
using CodeFirst.Configurations;
using CodeFirst.Models;

namespace CodeFirst.Models
{
    public class s22284Context : DbContext
    {
        public s22284Context()
        {
        }

        public s22284Context(DbContextOptions<s22284Context> options) : base(options) { }


        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<ClientOrder> ClientOrder { get; set; }
        public virtual DbSet<Confectionery> Confectionery { get; set; }
        public virtual DbSet<Confectionery_ClientOrder> Confectionery_ClientOrder { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientConfig());
            modelBuilder.ApplyConfiguration(new ClientOrderConfig());
            modelBuilder.ApplyConfiguration(new Confectionery_ClientOrderConfig());
            modelBuilder.ApplyConfiguration(new ConfectioneryConfig());
            modelBuilder.ApplyConfiguration(new EmployeeConfig());
        }
    }
}

