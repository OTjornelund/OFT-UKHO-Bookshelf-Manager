using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OFT_UKHO_Bookshelf_Manager.DbContexts;
using OFT_UKHO_Bookshelf_Manager.Models;

namespace OFT_UKHO_Bookshelf_Manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly BookLibraryContext _context;

        public RentalsController(BookLibraryContext context)
        {
            _context = context;
        }

        // GET: api/Rentals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rental>>> GetRentals()
        {
            return await _context.Rentals.ToListAsync();
        }

        // GET: api/Rentals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rental>> GetRental(int id)
        {
            var rental = await _context.Rentals.FindAsync(id);

            if (rental == null)
            {
                return NotFound();
            }

            return rental;
        }

        // PUT: api/Rentals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{rentalId}")]
        public async Task<IActionResult> PutRental(int rentalId, int newCopyId, int newUserId, DateTime newStartDateTime, DateTime? newEndDateTime)
        {
            if (!RentalExists(rentalId))
            {
                return NotFound("RentalId not found.");
            }

            if (!CopyExists(newCopyId))
            {
                return NotFound("CopyId not found.");
            }

            if (!UserExists(newUserId))
            {
                return NotFound("UserId not found.");
            }

            var rental = await _context.Rentals.FindAsync(rentalId);
            rental.CopyId = newCopyId;
            rental.UserId = newUserId;
            rental.StartDateTime = newStartDateTime;
            rental.EndDateTime = newEndDateTime;
            _context.Entry(rental).State = EntityState.Modified;

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

        // POST: api/Rentals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Rental>> PostRental(int newCopyId, int newUserId, DateTime newStartDateTime, DateTime? newEndDateTime)
        {
            if (!CopyExists(newCopyId))
            {
                return NotFound("CopyId not found.");
            }

            if (!UserExists(newUserId))
            {
                return NotFound("UserId not found.");
            }

            var rental = new Rental(newCopyId, newUserId, newStartDateTime, newEndDateTime);
            _context.Rentals.Add(rental);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRental", new { id = rental.Id }, rental);
        }

        // DELETE: api/Rentals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRental(int id)
        {
            var rental = await _context.Rentals.FindAsync(id);
            if (rental == null)
            {
                return NotFound();
            }

            _context.Rentals.Remove(rental);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RentalExists(int id)
        {
            return _context.Rentals.Any(e => e.Id == id);
        }

        private bool CopyExists(int id)
        {
            return _context.Copies.Any(e => e.Id == id);
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
