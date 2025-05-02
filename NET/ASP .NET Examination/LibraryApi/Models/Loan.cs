using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryApi.Models
{
    public class Loan
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "User Id is required.")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "BookId is required.")]
        public int BookId { get; set; }

        [Required(ErrorMessage = "LoanDate is required.")]
        public DateTime LoanDate { get; set; }

        [Required(ErrorMessage = "ReturnDate is required.")]
        public DateTime ReturnDate { get; set; }
    }
}
