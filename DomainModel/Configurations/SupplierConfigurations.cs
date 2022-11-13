using System;
using System.Collections.Generic;
using System.Text;
using DomainModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainModel.Configurations
{
    public class SupplierConfigurations : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(x => x.SupplierID);
            builder
                .HasMany(x => x.Products)
                .WithOne(x => x.Supplier)
                .HasForeignKey(x => x.SupplierID)
                .OnDelete(DeleteBehavior.NoAction);
            builder.Property(x => x.SupplierName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Tel).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Mobile).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Photo).HasMaxLength(50);
        }
    }
}
