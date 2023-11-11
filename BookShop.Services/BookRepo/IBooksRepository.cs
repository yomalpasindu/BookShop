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
    }
}
