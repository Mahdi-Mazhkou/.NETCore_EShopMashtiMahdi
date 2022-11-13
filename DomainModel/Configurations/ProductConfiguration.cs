using System;
using System.Collections.Generic;
using System.Text;
using DomainModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainModel.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.ProductID);
            builder
                .HasMany(x => x.RelatedProducts)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductID)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(x => x.OrderDetails)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductID)
                .OnDelete(DeleteBehavior.ClientNoAction);
            builder
                .HasMany(x => x.ProductFeatures)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductID)
                .OnDelete(DeleteBehavior.NoAction);
            builder
                .HasMany(x => x.ProductKeyWords)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductID)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Property(x => x.ProductName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.SmallDescription).HasMaxLength(400).IsRequired();
            builder.Property(x => x.UnitPrice).IsRequired();

        }
    }
}
