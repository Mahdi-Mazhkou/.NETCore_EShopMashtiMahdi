using System;
using System.Collections.Generic;
using System.Text;
using DomainModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainModel.Configurations
{
    class RelatedProductConfigurations : IEntityTypeConfiguration<RelatedProduct>
    {
        public void Configure(EntityTypeBuilder<RelatedProduct> builder)
        {
            builder.HasKey(x => x.RelatedProductID);
             
        }
    }
}
