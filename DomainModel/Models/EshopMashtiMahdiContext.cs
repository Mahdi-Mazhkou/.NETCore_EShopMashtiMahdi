using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DomainModel.Models;
using DomainModel.Configurations;

namespace DomainModel.Models
{
    public class EshopMashtiMahdiContext : DbContext
    {
        public EshopMashtiMahdiContext(DbContextOptions<EshopMashtiMahdiContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails{ get; set; }
        public DbSet<CategoryFeature> CategoryFeatures { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }
        public DbSet<ProductKeyWord> ProductKeyWords { get; set; }
        public DbSet<RelatedProduct> RelatedProducts { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<KeyWord> KeyWords { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Category>(new CategoryConfigurations());
            modelBuilder.ApplyConfiguration<Product>(new ProductConfiguration());
            modelBuilder.ApplyConfiguration<Supplier>(new SupplierConfigurations());
            modelBuilder.ApplyConfiguration<Feature>(new FeatureConfigurations());
            modelBuilder.ApplyConfiguration<Order>(new OrderConfigurations());
            modelBuilder.ApplyConfiguration<ProductFeature>(new ProductFeatureConfigurations());
            modelBuilder.ApplyConfiguration<KeyWord>(new KeyWordsConfigurations());
            base.OnModelCreating(modelBuilder);
        }

    }
}
