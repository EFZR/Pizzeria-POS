namespace Domain.Entity;

public class User
{
    public string? User_Id { get; set; }
    public string? User_EmpId { get; set; }
    public string? User_Username { get; set; }
    public string? User_Email { get; set; }
    public string? User_Password { get; set; }
    public string? User_PasswordSalt { get; set; }
    public string? User_TokenSalt { get; set; }
}