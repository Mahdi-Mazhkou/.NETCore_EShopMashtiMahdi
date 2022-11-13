using System;
using System.Collections.Generic;
using System.Text;
using DomainModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainModel.Configurations
{
    class ProductKeyWordConfigurations : IEntityTypeConfiguration<ProductKeyWord>
    {
        public void Configure(EntityTypeBuilder<ProductKeyWord> builder)
        {
            builder.HasKey(x => x.ProductKeyWordID);
        }
    }
}
