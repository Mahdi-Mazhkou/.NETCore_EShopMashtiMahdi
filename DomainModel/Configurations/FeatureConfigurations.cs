using System;
using System.Collections.Generic;
using System.Text;
using DomainModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainModel.Configurations
{
    public class FeatureConfigurations : IEntityTypeConfiguration<Feature>
    {
        public void Configure(EntityTypeBuilder<Feature> builder)
        {
            builder.HasKey(x => x.FeatureID);
            builder
                .HasMany(x => x.CategoryFeatures)
                .WithOne(x => x.Feature)
                .HasForeignKey(x => x.FeatureID)
                .OnDelete(DeleteBehavior.NoAction);
            builder
                .HasMany(x => x.ProductFeatures)
                .WithOne(x => x.Feature)
                .HasForeignKey(x => x.FeatureID)
                .OnDelete(DeleteBehavior.NoAction);
            builder.Property(x => x.FeatureName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.FeatureDescription).HasMaxLength(400).IsRequired();
        }
    }
}
