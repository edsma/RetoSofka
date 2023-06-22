﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RetoSofka.Infrastructure;

#nullable disable

namespace RetoSofka.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RetoSofka.Domain.Inventario.Product", b =>
                {
                    b.Property<Guid>("idProduct")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("enabled")
                        .HasColumnType("bit");

                    b.Property<int>("inInventory")
                        .HasColumnType("int");

                    b.Property<int>("max")
                        .HasColumnType("int");

                    b.Property<int>("min")
                        .HasColumnType("int");

                    b.Property<string>("nameProduct")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idProduct");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("RetoSofka.Domain.Shop.DetailShopProduct", b =>
                {
                    b.Property<Guid>("idDetatilShopProduct")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("idProduct")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("idShoppingRef")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasKey("idDetatilShopProduct");

                    b.HasIndex("idProduct");

                    b.HasIndex("idShoppingRef");

                    b.ToTable("DetailShopProduct");
                });

            modelBuilder.Entity("RetoSofka.Domain.Shop.Shopping", b =>
                {
                    b.Property<Guid>("idShopping")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("clientName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<int>("idType")
                        .HasColumnType("int");

                    b.HasKey("idShopping");

                    b.ToTable("Shopping");
                });

            modelBuilder.Entity("RetoSofka.Domain.Shop.DetailShopProduct", b =>
                {
                    b.HasOne("RetoSofka.Domain.Inventario.Product", "product")
                        .WithMany()
                        .HasForeignKey("idProduct")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RetoSofka.Domain.Shop.Shopping", null)
                        .WithMany("detailProduct")
                        .HasForeignKey("idShoppingRef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("product");
                });

            modelBuilder.Entity("RetoSofka.Domain.Shop.Shopping", b =>
                {
                    b.Navigation("detailProduct");
                });
#pragma warning restore 612, 618
        }
    }
}
