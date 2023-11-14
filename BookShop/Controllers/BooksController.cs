using AutoMapper;
using BookShop.Models;
using BookShop.Services.BookRepo;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IMapper _mapper;
        public BooksController(IBooksRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetBooks([FromQuery] BooksQueryParameters queryParameters)
        {
            var book = _bookRepository.GetBooks(queryParameters).ToList();
            var mappedBook = _mapper.Map<ICollection<ViewBooksDto>>(book);
            return Ok(mappedBook);
        }
        [HttpGet("{Id}")]
        public IActionResult GetBook(int Id)
        {
            return Ok(_bookRepository.GetBook(Id));
        }
        [HttpPost]
        public IActionResult InsertBook(AddBooksDto book)
        {
            var mappedBook = _mapper.Map<Book>(book);
            var insertBook = _bookRepository.InsertBook(mappedBook);

            return Ok(insertBook);
        }
        [HttpDelete]
        public IActionResult DeleteBook(int id)
        {
            var deleteBook = _bookRepository.DeleteBook(id);
            return Ok(deleteBook);
        }
        [HttpPut]
        public IActionResult UpdateBook(UpdateBookDto book)
        {
            var mappedBook=_mapper.Map<Book>(book);
            return Ok(_bookRepository.UpdateBook(mappedBook));
        }
    }
}
