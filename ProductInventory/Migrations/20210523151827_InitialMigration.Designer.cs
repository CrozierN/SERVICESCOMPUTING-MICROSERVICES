﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductInventory.Data;

namespace ProductInventory.Migrations
{
    [DbContext(typeof(ProductContext))]
    [Migration("20210523151827_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("ProductInventory.Models.Product", b =>
                {
                    b.Property<string>("productId")
                        .HasColumnType("TEXT");

                    b.Property<string>("color")
                        .HasColumnType("TEXT");

                    b.Property<string>("fit")
                        .HasColumnType("TEXT");

                    b.Property<string>("model")
                        .HasColumnType("TEXT");

                    b.Property<int>("quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("productId");

                    b.ToTable("Product");
                });
#pragma warning restore 612, 618
        }
    }
}
