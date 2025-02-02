using Library.Domain.Aggregates;
using Library.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebService.Controllers
{
    [Route("api/v1/[Area]")]
    [Area("books")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly ILogger<LibraryController> _logger;
        private readonly ILibrary _library;        

        public LibraryController(
            ILogger<LibraryController> logger,
            ILibrary library)
        {
            _logger = logger;
            _library = library;
        }

        [HttpGet]
        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _library.GetBooks();
}

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var book = await _library.GetById(id);

            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpGet("Title/{title}")]
        public async Task<IActionResult> GetByTitle(string title)
        {
            var book = await _library.GetByTitle(title);

            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpGet("date/{date}")]
        public async Task<IActionResult> GetByReleaseDate(DateTime date)
        {
            var book = await _library.GetByDate(date);

            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpGet("series/{author}")]
        public async Task<IActionResult> GetBooksSeries(string author)
        {
            var books = _library.GetBooksSeries(author);

            if (books == null)
                return NotFound();

            return Ok(books);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Book book)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (!await _library.AddBook(book))
                    return Conflict();

                return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error while adding book");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Book bookToCorrect)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (!(await _library.UpdateBook(bookToCorrect)))
                    return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while updateing book");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await _library.Remove(id))
                return NotFound();

            return NoContent();
        }

        [HttpGet("import/{filePath}")]
        public async Task<IActionResult> GetBookFromFile(string filePath)
        {
            var book = await _library.GetFromFile(filePath);

            if (book == null)
                return NotFound();

            return Ok(book);
        }

    }
}
