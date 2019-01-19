using System.ComponentModel.DataAnnotations;

namespace Drinks.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(8,MinimumLength=4,ErrorMessage="You must specify password between 4 and 8 characters")]
        public string Password { get; set; }
    }
}