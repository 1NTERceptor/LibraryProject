using System.ComponentModel.DataAnnotations;

namespace REST_API.Controllers
{
    public class CreateUserRequest
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string GuestCardNumber { get; set; }

        [Required]
        public string Login { get; set; }
    }
}