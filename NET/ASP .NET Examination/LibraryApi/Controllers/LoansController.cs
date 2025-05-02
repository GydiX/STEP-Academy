using Microsoft.AspNetCore.Mvc;
using LibraryApi.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace LibraryApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly LibraryContext _context;

        public LoansController(LibraryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Loan>> GetLoans()
        {
            return Ok(_context.Loans.ToList());
        }

        [HttpPost]
        public ActionResult<Loan> CreateLoan(Loan loan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Loans.Add(loan);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetLoans), new { id = loan.Id }, loan);
        }

        [HttpPut("{id}")]
        public ActionResult<Loan> UpdateLoan(int id, Loan loan)
        {
            if (id != loan.Id)
            {
                return BadRequest("Loan ID mismatch.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingLoan = _context.Loans.FirstOrDefault(l => l.Id == id);
            if (existingLoan == null)
            {
                return NotFound();
            }

            existingLoan.UserId = loan.UserId;
            existingLoan.BookId = loan.BookId;
            existingLoan.LoanDate = loan.LoanDate;
            existingLoan.ReturnDate = loan.ReturnDate;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteLoan(int id)
        {
            var loan = _context.Loans.FirstOrDefault(l => l.Id == id);
            if (loan == null)
            {
                return NotFound();
            }

            _context.Loans.Remove(loan);
            _context.SaveChanges();
            return NoContent();
        }
    }
}