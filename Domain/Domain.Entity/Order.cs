namespace Domain.Entity;

public class Order
{
    public string? Ord_Id { get; set; }
    public string? Ord_EmpId { get; set; }
    public string? Ord_CustId { get; set; }
    public string? Ord_Date { get; set; }
    public string? Ord_BillNumber { get; set; }
    public string? Ord_Total { get; set; }
}

public class OrderDetail
{
    public string? OD_Id { get; set; }
    public string? OD_OrdId { get; set; }
    public string? OD_ProdId { get; set; }
    public string? OD_Quantity { get; set; }
    public string? OD_Price { get; set; }
}

public class OrderWithDetails
{
    public Order? Order { get; set; }
    public List<OrderDetail>? OrderDetails { get; set; }
}