namespace Application.DTO;

public class OrderDTO
{
    public string? Id { get; set; }
    public string? EmployeeId { get; set; }
    public string? CustomerId { get; set; }
    public string? Date { get; set; }
    public string? BillNumber { get; set; }
    public string? Total { get; set; }
}