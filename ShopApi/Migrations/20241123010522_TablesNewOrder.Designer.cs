﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ShopApi.Data;

#nullable disable

namespace ShopApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241123010522_TablesNewOrder")]
    partial class TablesNewOrder
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ShopApi.Models.Customer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("character varying(254)")
                        .HasColumnName("address");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("character varying(254)")
                        .HasColumnName("city");

                    b.Property<long>("CustomerNumber")
                        .HasColumnType("bigint")
                        .HasColumnName("customer_number");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("character varying(254)")
                        .HasColumnName("email");

                    b.Property<long>("IdCardNumber")
                        .HasColumnType("bigint")
                        .HasColumnName("id_card_number");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("phone");

                    b.HasKey("Id");

                    b.ToTable("customers");
                });

            modelBuilder.Entity("ShopApi.Models.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("CustomerId")
                        .HasColumnType("bigint");

                    b.Property<long>("CustomerNumber")
                        .HasColumnType("bigint")
                        .HasColumnName("customer_number");

                    b.Property<string>("GroupOrderId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("group_order_id");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("order_date");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("payment_date");

                    b.Property<int>("PaymentStatus")
                        .HasColumnType("integer")
                        .HasColumnName("payment_status");

                    b.Property<long>("ProductNumber")
                        .HasColumnType("bigint")
                        .HasColumnName("product_number");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

                    b.Property<int>("ReturnStatus")
                        .HasColumnType("integer")
                        .HasColumnName("return_status");

                    b.Property<decimal>("Total")
                        .HasColumnType("numeric")
                        .HasColumnName("total");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("ShopApi.Models.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("brand");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("expiration_date");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("image");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("price");

                    b.Property<long>("ProductNumber")
                        .HasColumnType("bigint")
                        .HasColumnName("product_number");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

                    b.HasKey("Id");

                    b.ToTable("products");
                });

            modelBuilder.Entity("ShopApi.Models.Order", b =>
                {
                    b.HasOne("ShopApi.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("ShopApi.Models.Customer", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
