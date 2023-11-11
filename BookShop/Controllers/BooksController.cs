using BookShop.Models;
using BookShop.Services.BookRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksRepository _bookRepository;
        public BooksController(IBooksRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        [HttpGet]
        public IActionResult GetBooks([FromQuery] BooksQueryParameters queryParameters)
        {
            return Ok(_bookRepository.GetBooks(queryParameters));
        }
        [HttpPost]
        public IActionResult InsertBook(Book book)//use automappers
        {
            var insertBook=_bookRepository.InsertBook(book);
            return Ok(insertBook);
        }
    }
}
