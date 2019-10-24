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
                Name = "John"
            }, new User
            {
                Name = "James"
            }, new User
            {
                Name = "Steve"
            });

        }
    }
}
