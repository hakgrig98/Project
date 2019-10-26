using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_DAL.EntityConfigrations
{
    public class AdvertUserConfiguration : IEntityTypeConfiguration<AdvertUser>
    {
        public void Configure(EntityTypeBuilder<AdvertUser> builder)
        {
            builder.
                ToTable("advert_user");

            builder.
                HasKey(au => new { au.AdvertId, au.UserId });

            builder
                .Property((au) => au.AdvertId)
                .HasColumnName("advert_id");

            builder
                .Property((au) => au.UserId)
                .HasColumnName("user_id");

            builder
                .HasOne(ua => ua.User)
                .WithMany(u => u.AdvertUser)
                .HasForeignKey(ua => ua.UserId);

            builder
                .HasOne(ua => ua.Advert)
                .WithMany(s => s.AdvertUser)
                .HasForeignKey(ua => ua.AdvertId);
        }
    }
}
