using System.ComponentModel.DataAnnotations;

namespace REST_API.Controllers
{
    public class CreateGuestRequest
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string GuestCardNumber { get; set; }
    }
}