using AutoMapper;
using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Services.BookRepo
{
    public class BooksProfile:Profile
    {
        public BooksProfile()
        {
            CreateMap<AddBooksDto,Book>();
            CreateMap<Book,ViewBooksDto>();
            CreateMap<UpdateBookDto,Book>();
        }
    }
}
