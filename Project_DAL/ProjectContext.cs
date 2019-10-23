using Microsoft.EntityFrameworkCore;
using Project_DAL.Entities;
using Project_DAL.EntityConfigrations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_DAL
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions options)
            : base(options)
        {}

        public DbSet<Advert> Adverts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AdvertUser> AdvertUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AdvertConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new AdvertUserConfiguration());
        }
    }
}
