using System;
using System.Collections.Generic;
using System.Text;
using DomainModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainModel.Configurations
{
    class CategoryFeatureConfigurations : IEntityTypeConfiguration<CategoryFeature>
    {
        public void Configure(EntityTypeBuilder<CategoryFeature> builder)
        {
            builder.HasKey(x => x.CategoryFeatureID);

        }
    }
}
