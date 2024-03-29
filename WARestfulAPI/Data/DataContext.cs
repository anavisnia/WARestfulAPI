﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WARestfulAPI.Entities;
using WARestfulAPI.Entities.Base;

namespace WARestfulAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        // duomenu baze
        public DbSet<Shop> Shops { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Fruit> Fruits { get; set; }

        public DbSet<Tableware> Tablewares { get; set; }

        public DbSet<Vegetable> Vegetables { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Shop>()
        //    .HasMany(s => s.Products)
        //    .WithOne(pr => pr.shop)
        //    .HasForeignKey(si => si.ShopId);
        //}

    }
}
