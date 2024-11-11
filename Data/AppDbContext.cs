using System.Collections.Generic;
using Book_Management.Models;
using Microsoft.EntityFrameworkCore;
namespace Book_Management.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Book>  Books { get; set; }
        public DbSet<CartItem> Cartitem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>().HasKey(x => x.Id);
            modelBuilder.Entity<Book>()
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CartItem>().HasKey(s => s.CartId);

            modelBuilder.Entity<Book>()
                .HasOne(s => s.CartItem)
                .WithMany(x => x.Books)
                .HasForeignKey(s => s.CartId);

            // seeder
            modelBuilder.Entity<Book>().HasData(
            new Book { Id = 1, Title = "Romeo and  Juliet", Author = "Kirinyaga  Kamau", Price = 400, CartId = 1 },
            new Book { Id = 2, Title = " Kidagaa Kimemwozea", Author = "Abdi Hakim", Price = 410, CartId = 1 },
            new Book { Id = 3, Title = "How to thrive in business", Author = "Jane  Atieno", Price = 420, CartId = 3 },
            new Book { Id = 4, Title = "Taste Jesus", Author = "Pascal Kazungu", Price = 430, CartId = 2 },
            new Book { Id = 5, Title = "Good to great", Author = "Jane  Atieno", Price = 420, CartId = 3 },
            new Book { Id = 6, Title = "Great is great", Author = "Jane  Atieno", Price = 420, CartId = 2 },
            new Book { Id = 7, Title = "Entreprenuership", Author = "Jane  Atieno", Price = 420, CartId = 3 },
            new Book { Id = 8, Title = "Java", Author = "Jane  Atieno", Price = 420, CartId = 4 }

            );

            modelBuilder.Entity<CartItem>().HasData(
            new CartItem { CartId = 1, CategoryName = "swahili Novels", Description = "swahili Novels only" },
            new CartItem { CartId = 2, CategoryName = "Religion books", Description = "Religion books and  buddism" },
            new CartItem { CartId = 3, CategoryName = "Business related", Description = "Business related books and artricles" },
            new CartItem { CartId = 4, CategoryName = "Technology ", Description = "Technology and   Cloud " },
            new CartItem { CartId = 5, CategoryName = "Space and Austronomy", Description = "Space and Austronomy" },
            new CartItem { CartId = 6, CategoryName = "English  and  Foreign  Languages ", Description = "English  and  Foreign  Languages" }
            );










        }
}
}
