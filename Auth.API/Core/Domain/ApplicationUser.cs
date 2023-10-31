using Auth.API.Application.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Auth.API.Core.Domain
{
    public class ApplicationUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsApproved { get; set; } = false;
        public string? ApprovedBy { get; set; }
        public DateTime? ApprovalDate { get; set; }

        public string UserRegistrationSource { get; set; }

    }

    public class ApplicationUserRole:IdentityRole
    {

    }
}


