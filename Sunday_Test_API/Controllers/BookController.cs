using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Entities.DTOs;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Sunday_Test_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public BookController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var booksDb = await _bookService.GetBooksAsync();

            if (booksDb is null)
                return NotFound();

            var booksDto = _mapper.Map<List<BookDto>>(booksDb);

            return Ok(booksDto);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetBookById(int id)
        {
            var bookDb = await _bookService.GetBookByIdAsync(id);

            if (bookDb is null)
                return NotFound();

            var bookDto = _mapper.Map<BookDto>(bookDb);


            return Ok(bookDto);
        }

        [HttpPost]
        public async Task<ActionResult> CreateBook([FromBody] BookDto bookDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var bookDb = _mapper.Map<Book>(bookDto);

            await _bookService.AddBookAsync(bookDb);

            return Ok("Success!");
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> EditBoook(int id, [FromBody] BookDto bookDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var bookDb = await _bookService.GetBookByIdAsync(id);

            if (bookDb is null)
                return NotFound();

            bookDto.Id = bookDb.Id;

            _mapper.Map(bookDto, bookDb);

            await _bookService.EditBookAsync(bookDb);

            return Ok("Success!");
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await _bookService.DeleteBookAsync(id);

            return Ok("Success!");
        }
    }
}