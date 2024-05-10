using Microsoft.AspNetCore.Identity;

namespace backendGameHub.Models;

public class CustomIdentityUser : IdentityUser
{
    public required string nombre { get; set; }
    public bool protegido { get; set; }
}