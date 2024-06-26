﻿using Microsoft.EntityFrameworkCore;
using SharedProject.Models;
namespace SharedProject.Data;

public class AppDbContext :DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductImage> ProductImages  { get; set; }

        public virtual DbSet<Category> Categories  { get; set; }
        public virtual DbSet<Brand> Brands  { get; set; }
        public virtual DbSet<Seller> Sellers  { get; set; }
        public virtual DbSet<ProductLongDescription> ProductLongDescription { get; set; }
        public virtual DbSet<Review> Reviews  { get; set; }
}
