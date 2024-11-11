﻿// <auto-generated />
using Book_Management.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Book_Management.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241109223556_subsequentmig")]
    partial class subsequentmig
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Book_Management.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Kirinyaga  Kamau",
                            CartId = 1,
                            Price = 400.0,
                            Title = "Romeo and  Juliet"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Abdi Hakim",
                            CartId = 1,
                            Price = 410.0,
                            Title = " Kidagaa Kimemwozea"
                        },
                        new
                        {
                            Id = 3,
                            Author = "Jane  Atieno",
                            CartId = 3,
                            Price = 420.0,
                            Title = "How to thrive in business"
                        },
                        new
                        {
                            Id = 4,
                            Author = "Pascal Kazungu",
                            CartId = 2,
                            Price = 430.0,
                            Title = "Taste Jesus"
                        },
                        new
                        {
                            Id = 5,
                            Author = "Jane  Atieno",
                            CartId = 3,
                            Price = 420.0,
                            Title = "Good to great"
                        },
                        new
                        {
                            Id = 6,
                            Author = "Jane  Atieno",
                            CartId = 2,
                            Price = 420.0,
                            Title = "Great is great"
                        },
                        new
                        {
                            Id = 7,
                            Author = "Jane  Atieno",
                            CartId = 3,
                            Price = 420.0,
                            Title = "Entreprenuership"
                        },
                        new
                        {
                            Id = 8,
                            Author = "Jane  Atieno",
                            CartId = 4,
                            Price = 420.0,
                            Title = "Java"
                        });
                });

            modelBuilder.Entity("Book_Management.Models.CartItem", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CartId");

                    b.ToTable("Cartitem");

                    b.HasData(
                        new
                        {
                            CartId = 1,
                            CategoryName = "swahili Novels",
                            Description = "swahili Novels only"
                        },
                        new
                        {
                            CartId = 2,
                            CategoryName = "Religion books",
                            Description = "Religion books and  buddism"
                        },
                        new
                        {
                            CartId = 3,
                            CategoryName = "Business related",
                            Description = "Business related books and artricles"
                        },
                        new
                        {
                            CartId = 4,
                            CategoryName = "Technology ",
                            Description = "Technology and   Cloud "
                        },
                        new
                        {
                            CartId = 5,
                            CategoryName = "Space and Austronomy",
                            Description = "Space and Austronomy"
                        },
                        new
                        {
                            CartId = 6,
                            CategoryName = "English  and  Foreign  Languages ",
                            Description = "English  and  Foreign  Languages"
                        });
                });

            modelBuilder.Entity("Book_Management.Models.Book", b =>
                {
                    b.HasOne("Book_Management.Models.CartItem", "CartItem")
                        .WithMany("Books")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CartItem");
                });

            modelBuilder.Entity("Book_Management.Models.CartItem", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
