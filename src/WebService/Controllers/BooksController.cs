using AutoMapper;
using Library.Domain;
using Library.Domain.Aggregates;
using Library.Domain.Services;
using Library.Messages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.Controllers
{
    [Route("api/v1/[Area]")]
    [Area("books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;
        private readonly IFileReader _fileReader;

        public BooksController(
            ILogger<BooksController> logger,
            IDataContext dataContext,
            IMapper mapper,
            IFileReader fileReader)
        {
            _logger = logger;
            _dataContext = dataContext;
            _mapper = mapper;
            _fileReader = fileReader;
        }

        [HttpGet]
        public async Task<IEnumerable<BookModel>> GetAll()
        {
            var books = await _dataContext.Books.ToListAsync();
            return _mapper.Map<IEnumerable<BookModel>>(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var book = await _dataContext.Books.Where(b => b.Key == id).ToListAsync();

            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpGet("Title/{title}")]
        public async Task<IActionResult> GetByTitle(string title)
        {
            var book = await _dataContext.Books.Where(b => b.Title == title).ToListAsync();

            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpGet("date/{date}")]
        public async Task<IActionResult> GetByReleaseDate(DateTime date)
        {
            var book = await _dataContext.Books.Where(b => b.ReleaseDate.Date == date.Date).ToListAsync();

            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpGet("author/{author}")]
        public async Task<IActionResult> GetBooksSeries(string author)
        {
            var books = await _dataContext.Books.Where(b => b.Author == author).ToListAsync();

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

                _dataContext.Books.Add(book);
                await _dataContext.SaveChangesAsync();

                return CreatedAtAction(nameof(GetById), new { id = book.Key }, book);
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

                _dataContext.Books.Update(bookToCorrect);
                await _dataContext.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while updateing book");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var book = await _dataContext.Books.Where(b => b.Key == id).FirstOrDefaultAsync();
            
            if(book == null)
                return NotFound();

            _dataContext.Books.Remove(book);
            await _dataContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("import/{filePath}")]
        public async Task<IActionResult> GetBookFromFile(string filePath)
        {
            var book = _fileReader.GetFromFile(filePath);

            if (book == null)
                return NotFound();

            return Ok(book);
        }

    }
}
