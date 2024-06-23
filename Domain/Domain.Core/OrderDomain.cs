using Domain.Interface;
using Domain.Entity;
using Infrastructure.Interface;
using Application.DTO;

namespace Domain.Core;

// TODO: Better the orders structure.
public class OrderDomain : IOrderDomain
{
    private readonly IOrderRepository _orderRepository;
    private readonly IOrderDetailRepository _orderDetailRepository;
    private readonly IUserRepository _userRepository;
    public OrderDomain(IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository, IUserRepository userRepository)
    {
        _orderRepository = orderRepository;
        _orderDetailRepository = orderDetailRepository;
        _userRepository = userRepository;
    }

    public async Task<OrderWithDetails> PlaceOrder(CreateOrderWithDetailsDTO createOrderWithDetailsDTO, string userId)
    {
        // Ensure input validation and setup
        if (createOrderWithDetailsDTO == null)
            throw new ArgumentNullException(nameof(createOrderWithDetailsDTO), "CreateOrderWithDetailsDTO must not be null.");
        if (string.IsNullOrEmpty(userId))
            throw new ArgumentNullException(nameof(userId), "User ID must not be null or empty.");

        // Extract necessary data from DTO
        var order = createOrderWithDetailsDTO.Order ?? throw new ArgumentNullException(nameof(createOrderWithDetailsDTO.Order), "Order must not be null.");
        var orderDetails = createOrderWithDetailsDTO.OrderDetails ?? throw new ArgumentNullException(nameof(createOrderWithDetailsDTO.OrderDetails), "OrderDetails must not be null.");

        // Retrieve user information from database
        var user = await _userRepository.Get(userId) ?? throw new InvalidOperationException($"User with ID '{userId}' not found.");

        // Generate necessary data for the order
        var orderDate = DateTime.Now;
        var billNumber = GenerateBillNumber();
        var totalAmount = CalculateTotalAmount(orderDetails);

        // Prepare order object for insertion
        var orderToInsert = new Order
        {
            Ord_Id = null, // Assuming Ord_Id is nullable and will be auto-generated
            Ord_BillNumber = billNumber,
            Ord_CustId = order.CustomerId,
            Ord_Date = orderDate.ToString("yyyy-MM-dd"),
            Ord_EmpId = user.User_EmpId,
            Ord_Total = totalAmount.ToString("F2"),
        };

        // Insert the order into the repository
        var insertedOrder = await _orderRepository.Insert(orderToInsert);

        // Retrieve the inserted order to get its ID
        var retrievedOrder = await _orderRepository.Get(billNumber);

        // Prepare order details for insertion
        var orderDetailsToInsert = new List<OrderDetail>();
        foreach (var detail in orderDetails)
        {
            var orderDetail = new OrderDetail
            {
                OD_Id = null,
                OD_OrdId = retrievedOrder.Ord_Id,
                OD_Price = detail.Price,
                OD_ProdId = detail.ProductId,
                OD_Quantity = detail.Quantity,
            };
            orderDetailsToInsert.Add(orderDetail);
        }

        // Insert the order details into the repository
        var orderDetailResponse = await _orderDetailRepository.Insert(orderDetailsToInsert);

        // Retrived Order Details.
        var retrivedOrderDetails_enum = await _orderDetailRepository.GetAllByOrderId(retrievedOrder.Ord_Id!);
        var retrivedOrderDetails = retrivedOrderDetails_enum.ToList();

        // 
        var orderWithDetails = new OrderWithDetails
        {
            Order = retrievedOrder,
            OrderDetails = retrivedOrderDetails,
        };

        return orderWithDetails;
    }

    static string GenerateBillNumber()
    {
        string prefix = "INV";
        int length = 10;
        string randomDigits = GenerateRandomDigits(length - prefix.Length);
        return prefix + randomDigits;
    }

    static string GenerateRandomDigits(int length)
    {
        var random = new Random();
        char[] digits = new char[length];
        for (int i = 0; i < length; i++)
        {
            digits[i] = (char)('0' + random.Next(0, 10));
        }
        return new string(digits);
    }

    static float CalculateTotalAmount(List<CreateOrderDetailDTO> orderDetails)
    {
        float total = 0;
        foreach (var detail in orderDetails)
        {
            if (float.TryParse(detail.Price, out float price) && float.TryParse(detail.Quantity, out float quantity))
            {
                total += price * quantity;
            }
            else
            {
                throw new FormatException($"Invalid format for order detail, price:{detail.Price}, quantity: {detail.Quantity}");
            }
        }
        return total;
    }

}