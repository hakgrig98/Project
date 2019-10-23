using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_DAL.EntityConfigrations
{
    public class AdvertConfiguration : IEntityTypeConfiguration<Advert>
    {
        public void Configure(EntityTypeBuilder<Advert> builder)
        {
            builder
                .ToTable("advert");

            builder
                .HasKey((a) => a.Id)
                .HasName("advert_id");

            builder
                .Property((a) => a.Text)
                .HasColumnName("advert_text")
                .IsRequired();

            builder
                .Property((a) => a.Rating)
                .HasColumnName("advert_rating")
                .IsRequired();
            
            builder
                .Property((a) => a.CreatedDate)
                .HasColumnName("advert_created_date")
                .IsRequired();
        }
    }
}
