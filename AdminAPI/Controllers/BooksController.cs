using AdminAPI.Context;
using AdminAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdminAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        //TODO: Move context away from controller and put into a repository class.
        //TODO: Replace context with a service handler
        private readonly BookDetailContext _context;

        public BooksController(BookDetailContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDetail>>> GetAll()
        {
            return await _context.BookDetails.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDetail>> GetBookDetail(int id)
        {
            return await _context.BookDetails.FindAsync(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BookDetail>> PutBookDetail(int id, BookDetail bookDetail)
        {
            if (id != bookDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(bookDetail).State = EntityState.Modified;
            try
            { 
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException )
            {
                if (!bookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return await GetBookDetail(id);
        }

        private bool bookExists(int id)
        {
            return _context.BookDetails.Any(e => e.Id == id);
        }
    }
}

