using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OFT_UKHO_Bookshelf_Manager.DbContexts;
using OFT_UKHO_Bookshelf_Manager.Models;

namespace OFT_UKHO_Bookshelf_Manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CopiesController : ControllerBase
    {
        private readonly BookLibraryContext _context;

        public CopiesController(BookLibraryContext context)
        {
            _context = context;
        }

        // GET: api/Copies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Copy>>> GetCopies()
        {
            return await _context.Copies.ToListAsync();
        }

        // GET: api/Copies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Copy>> GetCopy(int id)
        {
            var copy = await _context.Copies.FindAsync(id);

            if (copy == null)
            {
                return NotFound();
            }

            return copy;
        }

        // PUT: api/Copies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{copyId}")]
        public async Task<IActionResult> PutCopy(int copyId, int newBookId)
        {
            if (!CopyExists(copyId))
            {
                return NotFound();
            }

            if (!BookExists(newBookId))
            {
                return NotFound();
            }

            var copy = await _context.Copies.FindAsync(copyId);
            copy.BookId = newBookId;
            _context.Entry(copy).State = EntityState.Modified;

            //TODO: This entire try-catch block might be redundant...?
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        // POST: api/Copies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Copy>> PostCopy(int bookId)
        {
            if (!BookExists(bookId))
            {
                return NotFound();
            }

            var copy = new Copy(bookId);
            _context.Copies.Add(copy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCopy", new { id = copy.Id }, copy);
        }

        // DELETE: api/Copies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCopy(int id)
        {
            var copy = await _context.Copies.FindAsync(id);
            if (copy == null)
            {
                return NotFound();
            }

            _context.Copies.Remove(copy);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CopyExists(int id)
        {
            return _context.Copies.Any(e => e.Id == id);
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}
