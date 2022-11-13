using System;
using System.Collections.Generic;
using System.Text;
using DomainModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainModel.Configurations
{
    public class KeyWordsConfigurations : IEntityTypeConfiguration<KeyWord>
    {
        public void Configure(EntityTypeBuilder<KeyWord> builder)
        {
            builder.HasKey(x => x.KeyWordID);
            builder
                .HasMany(x => x.ProductKeyWords)
                .WithOne(x => x.KeyWord)
                .HasForeignKey(x => x.KeyWordID)
                .OnDelete(DeleteBehavior.NoAction);
            builder.Property(x => x.KeyWordText).HasMaxLength(100);
        }
    }
}
