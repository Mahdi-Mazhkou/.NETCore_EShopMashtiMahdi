using System;
using System.Collections.Generic;
using System.Text;
using DomainModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainModel.Configurations
{
    public class CategoryConfigurations : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.CategoryId);
            builder
                .HasMany(x => x.Children)
                .WithOne(x => x.Parent)
                .HasForeignKey(x => x.ParentID)
                .OnDelete(DeleteBehavior.NoAction);
            builder
               .HasMany(x => x.Products)
               .WithOne(x => x.Category)
               .HasForeignKey(x => x.CategoryID)
               .OnDelete(DeleteBehavior.NoAction);
            builder
                .HasMany(x => x.CategoryFeatures)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryID)
                .OnDelete(DeleteBehavior.NoAction);
            builder.Property(x => x.CategoryName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.LineAge).HasMaxLength(400);
            builder.Property(x => x.Depth).HasDefaultValue(1).IsRequired();
            builder.Property(x => x.ProductCount).HasDefaultValue(0).IsRequired();
            builder.Property(x => x.SmallDescription).HasMaxLength(400);
           
        }
    }
}
