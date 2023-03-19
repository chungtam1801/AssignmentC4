﻿using Assignment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment.Configurations
{
    public class ClothesConfiguration : IEntityTypeConfiguration<Clothes>
    {
        public void Configure(EntityTypeBuilder<Clothes> builder)
        {
            builder.ToTable("Clothes");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Name).HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(x => x.Price).HasColumnType("int").IsRequired();
            builder.Property(x => x.Quantity).HasColumnType("int").IsRequired();
            builder.Property(x => x.Status).HasColumnType("int").IsRequired();
            builder.Property(x => x.Supplier).HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(x => x.Description).HasColumnType("nvarchar(100)");
        }
    }
}
