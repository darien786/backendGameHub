namespace backendGameHub.Models;

public class CustomIdentityUserPwdDTO
{
    public string? Id { get; set; }
    public required string username { get; set; }
    public required string password { get; set; }
    public required string rol { get; set; }
}