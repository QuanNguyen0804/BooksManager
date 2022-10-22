using ContosoUniversity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BooksAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookContext _context;

        public BooksController(BookContext context)
        {
            _context = context;
        }


        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            var res = _context.Book.ToList();

            return res;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public IEnumerable<Book> Get(int id)
        {
            var res = _context.Book.Find(id);
            yield return res;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            _context.Book.Add(book);
            var res = _context.SaveChanges();

            return Ok(res);
        }

        // PUT api/<ValuesController>/5
        [HttpPost("{id}")]
        public IActionResult Update(int id, [FromBody] Book book)
        {
            var entity = _context.Book.Find(id);
            if (entity == null)
            {
                return NotFound(id);
            }

            entity.Name = book.Name;
            entity.publisher = book.publisher;
            entity.Category = book.Category;
            entity.author = book.author;

            var res = _context.SaveChanges();
            return Ok(res);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var bookDelete = _context.Book.Find(id);

            if (bookDelete == null)
            {
                return NotFound(id);
            }

            _context.Book.Remove(bookDelete);
            var res = _context.SaveChanges();

            return Ok(res);
        }
    }
}
