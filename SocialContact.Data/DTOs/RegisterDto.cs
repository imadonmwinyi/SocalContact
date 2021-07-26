
using System.ComponentModel.DataAnnotations;

namespace SocialContact.Data.DTOs
{
    public class RegisterDto
    {
        [Required(ErrorMessage ="First Name cannot be Empty")]
        public string FirstName { get; set; }

        [Required(ErrorMessage ="Last Name cannot be Empty")]
        public string LastName { get; set; }

        [Required(ErrorMessage ="Email is Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password Confirmation is Required")]
        [Compare("Password", ErrorMessage ="Password Does not Match")]
        public string ConfirmPassword { get; set; }
    }
}
