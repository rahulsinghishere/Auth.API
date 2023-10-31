using System.ComponentModel.DataAnnotations;

namespace Auth.API.Application.ViewModels
{
    public class LoginVM
    {
        [Required]
        [EmailAddress(ErrorMessage ="EmailID is invalid")]
        public string EmailID { get; set; }
        [Required]
        public string UserPassword { get; set; }
    }
}


