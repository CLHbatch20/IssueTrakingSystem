using IssueTrackingSystem.Entities.Enum;
using Microsoft.AspNetCore.Identity;

namespace IssueTrackingSystem.Entities.Domain
{
    public class User : Auditables
    {
        public string UserName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public Role Roles { get; set; }
    }
}
