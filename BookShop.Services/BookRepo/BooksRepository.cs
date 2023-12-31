﻿using BookShop.DataAccess;
using BookShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Services.BookRepo
{
    public class BooksRepository : IBooksRepository
    {
        private readonly BookShopDbContext _context;
        public BooksRepository(BookShopDbContext context)
        {
            _context = context;
        }
        public ICollection<Book> GetBooks(BooksQueryParameters queryParameters)
        {
            //paginations
            IQueryable<Book> books = _context.books;
            books = books.Skip(queryParameters.Size * (queryParameters.Page - 1))
                .Take(queryParameters.Size);

            //sorting
            if (!string.IsNullOrEmpty(queryParameters.SortOrder))
            {
                switch (queryParameters.SortOrder)
                {
                    case "asc":
                        books = books.OrderBy(b => EF.Property<object>(b, queryParameters.SortBy)); break;
                    case "desc":
                        books = books.OrderByDescending(b => EF.Property<object>(b, queryParameters.SortBy)); break;
                }
            }

            //max price range
            if (queryParameters.MaxPrice != null)
            {
                books = books.Where(b => b.Price < queryParameters.MaxPrice);
            }

            //min price range
            if (queryParameters.MinPrice != null)
            {
                books = books.Where(b => b.Price > queryParameters.MinPrice);
            }

            //search term
            if (!string.IsNullOrEmpty(queryParameters.SearchTerm))
            {
                books = books.Where(b => b.Name.ToLower().Contains(queryParameters.SearchTerm));
            }

            var allBooks = books.ToList();
            if (allBooks.Count != 0)
                return allBooks;
            return new List<Book>();
        }
        public Book GetBook(int Id) {
            var book=_context.books.Where(b=>b.Id == Id).FirstOrDefault();
            if (book != null)
                return book;
            return new Book();
        }
        public Boolean InsertBook(Book book)
        {
            if (book != null)
            {
                _context.books.Add(book);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public Boolean DeleteBook(int Id)
        {
            var book=_context.books.Where(b=>b.Id==Id).FirstOrDefault();
            if (book != null)
            {
                _context.books.Remove(book);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public Book UpdateBook(Book book)
        {
            if (book != null)
            {
                _context.books.Update(book);
                _context.SaveChanges();
                return GetBook(book.Id);
            }
            return new Book();
        }
    }
}
