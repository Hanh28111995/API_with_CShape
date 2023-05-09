using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApiNetCore6.Models;
using MyApiNetCore6.Repositories;

namespace MyApiNetCore6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Book2Controller : ControllerBase
    {
        private readonly IBookRepository _bookRepo;

        public Book2Controller(IBookRepository repo)
        {
            _bookRepo = repo;
        }

        [HttpGet, Route("getbookAll")]
        [Authorize]
        public async Task<IActionResult> GetAllBooks()
        {
            try
            {
                return Ok(await _bookRepo.getAllBooksAsync());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookbyId(int id)
        {
            try
            {
                var books = await _bookRepo.getAllBookAsync(id);
                return books == null ? NotFound() : Ok(books);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult>  AddNewBook(BookModel model) 
        {
            try
            {
                var newBook = await _bookRepo.AddBookAsync(model);
                var book = await _bookRepo.getAllBookAsync(newBook);
                return book == null ? NotFound() : Ok(book);
            }
            catch
            {
            return BadRequest();
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateBook(int id, BookModel model)
        {
            if(id != model.Id)
            {
                return NotFound();
            }    
            await _bookRepo.UpdateBookAsync(id, model);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async  Task<IActionResult> DeleteBook([FromRoute] int id)
        {

            await _bookRepo.DeleteBookAsync(id);
            return Ok();
        }

    }
}
