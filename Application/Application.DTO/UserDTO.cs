namespace Application.DTO;

public class UserDTO
{
    public required string Id { get; set; }
    public string? EmployeeId { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Token { get; set; }
}