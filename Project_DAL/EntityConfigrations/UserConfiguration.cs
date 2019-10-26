using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_DAL.EntityConfigrations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .ToTable("user");

            builder
                .HasKey((u) => u.Id)
                .HasName("user_id");

            builder
                .Property(u => u.Name)
                .HasColumnName("user_name")
                .IsRequired();

            builder.HasData(new User
            {
                Id = 1,
                Name = "John"
            }, new User
            {
                Id = 2,
                Name = "James"
            }, new User
            {
                Id = 3,
                Name = "Steve"
            });

        }
    }
}
