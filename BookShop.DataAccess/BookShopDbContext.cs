using BookShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataAccess
{
    public class BookShopDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<Book> books { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Author> authors { get; set; }


        public BookShopDbContext(DbContextOptions<BookShopDbContext>options):base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(b => b.Book)
                .HasForeignKey(b => b.AuthorId)
                .HasPrincipalKey(b => b.Id);
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Category)
                .WithMany(b => b.Book)
                .HasForeignKey(b => b.CategoryId)
                .HasPrincipalKey(b => b.Id);

            modelBuilder.Entity<Category>()
                .HasData(new Category
                {
                    Id = 1,
                    Description = "Novel",
                    Discount = 0
                },
                new Category
                {
                    Id = 2,
                    Description = "Transtalions",
                    Discount = 0
                },
                new Category
                {
                    Id = 3,
                    Description = "Kids",
                    Discount = 5
                });

            modelBuilder.Entity<Author>()
                .HasData(new Author
                {
                    Id = 1,
                    Name = "Martin Wickramasinghe"
                },
                new Author
                {
                    Id = 2,
                    Name = "F. Scott Fitzgerald"
                },
                new Author
                {
                    Id = 3,
                    Name = "Harper Lee"
                },
                new Author
                {
                    Id = 4,
                    Name = "George Orwell"
                });

            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Name = "Madolduwa",
                    Description = "Famous Book in Sri Lanka",
                    Price = 500,
                    Discount = 0,
                    AuthorId = 1,
                    CategoryId = 1
                },
                new Book
                {
                    Id = 2,
                    Name = "Serenity's Embrace",
                    Description = "A Journey into Tranquility",
                    Price = 650,
                    Discount = 10,
                    AuthorId = 2,
                    CategoryId = 2
                },
                new Book
                {
                    Id = 3,
                    Name = "Echoes of Eternity",
                    Description = "Timeless Epic Adventure",
                    Price = 750,
                    Discount = 5,
                    AuthorId = 3,
                    CategoryId = 1
                },
                new Book
                {
                    Id = 4,
                    Name = "Whispers in the Wind",
                    Description = "Mystical Tales of the Unknown",
                    Price = 600,
                    Discount = 15,
                    AuthorId = 4,
                    CategoryId = 3
                },
                new Book
                {
                    Id = 5,
                    Name = "Chronicles of Destiny",
                    Description = "Fate Unveiled",
                    Price = 700,
                    Discount = 8,
                    AuthorId = 1,
                    CategoryId = 2
                },
                new Book
                {
                    Id = 6,
                    Name = "Silent Echo",
                    Description = "A Tale of Love and Loss",
                    Price = 550,
                    Discount = 12,
                    AuthorId = 2,
                    CategoryId = 1
                },
                new Book
                {
                    Id = 7,
                    Name = "Ephemeral Dreams",
                    Description = "Visions of Imagination",
                    Price = 800,
                    Discount = 0,
                    AuthorId = 3,
                    CategoryId = 3
                },
                new Book
                {
                    Id = 8,
                    Name = "Whirlwind of Emotions",
                    Description = "A Rollercoaster of Feelings",
                    Price = 680,
                    Discount = 10,
                    AuthorId = 4,
                    CategoryId = 2
                },
                new Book
                {
                    Id = 9,
                    Name = "Crimson Skies",
                    Description = "Blood-Pumping Thrills",
                    Price = 720,
                    Discount = 5,
                    AuthorId = 1,
                    CategoryId = 1
                },
                new Book
                {
                    Id = 10,
                    Name = "Luminescent Horizon",
                    Description = "Radiant Tales of Hope",
                    Price = 590,
                    Discount = 8,
                    AuthorId = 2,
                    CategoryId = 3
                });

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=BookShopDb;Trusted_Connection=True;Encrypt=False;");
        }
    }
}
