namespace backendGameHub.Models;

public class CustomIdentityUserDTO
{
    public string? Id { get; set; }
    public required string username { get; set; }
    public required string nombre { get; set; }
    public required string rol { get; set; }

}