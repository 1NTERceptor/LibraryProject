using System;
using System.ComponentModel.DataAnnotations;

namespace REST_API.Controllers
{
    public class CreateLoanRequest
    {
        [Required]
        public Guid BookId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public DateTime DateTo { get; set; }
    }
}