﻿// <auto-generated />
using ASP_Project_2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ASP_Project_2.Migrations
{
    [DbContext(typeof(ASP_Project_2Context))]
    [Migration("20250109195820_f3")]
    partial class f3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ASPproj.Models.Cart", b =>
                {
                    b.Property<string>("Cart_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Customr_Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Cart_Id");

                    b.HasIndex("Customr_Id");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("ASPproj.Models.Cart_item", b =>
                {
                    b.Property<string>("Car_Item_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Cart_Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Item_Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("Quantity");

                    b.HasKey("Car_Item_Id");

                    b.HasIndex("Cart_Id");

                    b.HasIndex("Item_Id");

                    b.ToTable("Cart_item");
                });

            modelBuilder.Entity("ASPproj.Models.Customer", b =>
                {
                    b.Property<string>("Customr_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Password");

                    b.HasKey("Customr_Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("ASPproj.Models.Item", b =>
                {
                    b.Property<string>("Item_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Name");

                    b.Property<int>("Price")
                        .HasColumnType("int")
                        .HasColumnName("Price");

                    b.Property<int>("stock_quantity")
                        .HasColumnType("int")
                        .HasColumnName("stock_quantity");

                    b.HasKey("Item_Id");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("ASPproj.Models.Order", b =>
                {
                    b.Property<string>("Order_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Customer_Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Customr_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Status");

                    b.Property<decimal>("total_price")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Total_Price");

                    b.HasKey("Order_Id");

                    b.HasIndex("Customr_Id");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("ASPproj.Models.Order_item", b =>
                {
                    b.Property<string>("Order_Item_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Item_Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Order_Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("Quantity");

                    b.HasKey("Order_Item_Id");

                    b.HasIndex("Item_Id");

                    b.HasIndex("Order_Id");

                    b.ToTable("Order_item");
                });

            modelBuilder.Entity("ASPproj.Models.Cart", b =>
                {
                    b.HasOne("ASPproj.Models.Customer", "customer")
                        .WithMany()
                        .HasForeignKey("Customr_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("customer");
                });

            modelBuilder.Entity("ASPproj.Models.Cart_item", b =>
                {
                    b.HasOne("ASPproj.Models.Cart", "cart")
                        .WithMany("Cart_items")
                        .HasForeignKey("Cart_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASPproj.Models.Item", "item")
                        .WithMany()
                        .HasForeignKey("Item_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cart");

                    b.Navigation("item");
                });

            modelBuilder.Entity("ASPproj.Models.Order", b =>
                {
                    b.HasOne("ASPproj.Models.Customer", "customer")
                        .WithMany()
                        .HasForeignKey("Customr_Id");

                    b.Navigation("customer");
                });

            modelBuilder.Entity("ASPproj.Models.Order_item", b =>
                {
                    b.HasOne("ASPproj.Models.Item", "item")
                        .WithMany()
                        .HasForeignKey("Item_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASPproj.Models.Order", "order")
                        .WithMany("Order_items")
                        .HasForeignKey("Order_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("item");

                    b.Navigation("order");
                });

            modelBuilder.Entity("ASPproj.Models.Cart", b =>
                {
                    b.Navigation("Cart_items");
                });

            modelBuilder.Entity("ASPproj.Models.Order", b =>
                {
                    b.Navigation("Order_items");
                });
#pragma warning restore 612, 618
        }
    }
}
