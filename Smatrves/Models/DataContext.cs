using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Smatrves.Models
{
    public class DataContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Site> Sites { get; set; }
        public DataContext() : base("DefaultConnection") { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Admin>().ToTable("Admins");
            modelBuilder.Entity<Client>().ToTable("Clients");
            modelBuilder.Entity<Site>().ToTable("Sites");
        }
    }
}