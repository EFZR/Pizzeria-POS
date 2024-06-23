namespace Application.DTO;

#region ResponseDTO
public class OrderDTO
{
    public string? EmployeeId { get; set; }
    public string? CustomerId { get; set; }
    public string? Date { get; set; }
    public string? BillNumber { get; set; }
    public string? Total { get; set; }
}

public class OrderDetailDTO
{
    public string? OrderId { get; set; }
    public string? ProductId { get; set; }
    public string? Quantity { get; set; }
    public string? Price { get; set; }
}

public class OrderWithDetailsDTO
{
    public OrderDTO? Order { get; set; }
    public List<OrderDetailDTO>? OrderDetails { get; set; }
}
#endregion

#region RequestDTO
public class CreateOrderDTO
{
    public string? CustomerId { get; set; }
}

public class CreateOrderDetailDTO
{
    public string? ProductId { get; set; }
    public string? Quantity { get; set; }
    public string? Price { get; set; }
}

public class CreateOrderWithDetailsDTO
{
    public CreateOrderDTO? Order { get; set; }
    public List<CreateOrderDetailDTO>? OrderDetails { get; set; }
}
#endregion