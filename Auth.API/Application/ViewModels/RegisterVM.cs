using System.ComponentModel.DataAnnotations;

namespace Auth.API.Application.ViewModels
{
    public class RegisterVM
    {
        [Required]
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="Please Enter Valid Email Address")]
        public string EmailID { get; set; }
        [Required]
        public string RoleName { get; set; }
        [Required]
        public string RegistrationSource { get; set; }
        [Required]
        [Phone(ErrorMessage ="Please Enter Valid Phone Number")]
        public string PhoneNumber { get; set; }
    }
}
