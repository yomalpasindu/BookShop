using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Services.BookRepo
{
    public interface IBooksRepository
    {
        public ICollection<Book> GetBooks(BooksQueryParameters queryParameters);
        public Boolean InsertBook(Book book);
        public Book GetBook(int Id);
        public Boolean DeleteBook(int Id);
        public Book UpdateBook(Book book);
    }
}
