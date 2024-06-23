using AutoMapper;
using Application.DTO;
using Domain.Entity;

namespace Transversal.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Mapping Country Entity.
        CreateMap<Country, CountryDTO>()
            .ForMember(destination => destination.Id, source => source.MapFrom(src => src.Country_Id))
            .ForMember(destination => destination.Name, source => source.MapFrom(src => src.Country_Name))
            .ReverseMap();

        // Mapping Customer Entity.
        CreateMap<Customer, CustomerDTO>()
            .ForMember(destination => destination.Id, source => source.MapFrom(src => src.Cust_Id))
            .ForMember(destination => destination.LocalityId, source => source.MapFrom(src => src.Cust_LocalId))
            .ForMember(destination => destination.FirstName, source => source.MapFrom(src => src.Cust_FirstName))
            .ForMember(destination => destination.LastName, source => source.MapFrom(src => src.Cust_LastName))
            .ForMember(destination => destination.Phone, source => source.MapFrom(src => src.Cust_Phone))
            .ForMember(destination => destination.Email, source => source.MapFrom(src => src.Cust_Email))
            .ReverseMap();

        // Mapping Employee Entity.
        CreateMap<Employee, EmployeeDTO>()
            .ForMember(destination => destination.Id, source => source.MapFrom(src => src.Emp_Id))
            .ForMember(destination => destination.LocalityId, source => source.MapFrom(src => src.Emp_LocalId))
            .ForMember(destination => destination.FirstName, source => source.MapFrom(src => src.Emp_FirstName))
            .ForMember(destination => destination.LastName, source => source.MapFrom(src => src.Emp_LastName))
            .ForMember(destination => destination.Phone, source => source.MapFrom(src => src.Emp_Phone))
            .ReverseMap();

        // Mapping Locality Entity.
        CreateMap<Locality, LocalityDTO>()
            .ForMember(destination => destination.Id, source => source.MapFrom(src => src.Local_Id))
            .ForMember(destination => destination.ProvinceId, source => source.MapFrom(src => src.Local_ProviId))
            .ForMember(destination => destination.Name, source => source.MapFrom(src => src.Local_Name))
            .ReverseMap();

        // Mapping Order Entity.
        CreateMap<Order, OrderDTO>()
            .ForMember(destination => destination.Id, source => source.MapFrom(src => src.Ord_Id))
            .ForMember(destination => destination.EmployeeId, source => source.MapFrom(src => src.Ord_EmpId))
            .ForMember(destination => destination.CustomerId, source => source.MapFrom(src => src.Ord_CustId))
            .ForMember(destination => destination.Date, source => source.MapFrom(src => src.Ord_Date))
            .ForMember(destination => destination.BillNumber, source => source.MapFrom(src => src.Ord_BillNumber))
            .ForMember(destination => destination.Total, source => source.MapFrom(src => src.Ord_Total))
            .ReverseMap();

        // Mapping Order Detail Entity.
        CreateMap<OrderDetail, OrderDetailDTO>()
            .ForMember(destination => destination.Id, source => source.MapFrom(src => src.OD_Id))
            .ForMember(destination => destination.OrderId, source => source.MapFrom(src => src.OD_OrdId))
            .ForMember(destination => destination.ProductId, source => source.MapFrom(src => src.OD_ProdId))
            .ForMember(destination => destination.Quantity, source => source.MapFrom(src => src.OD_Quantity))
            .ForMember(destination => destination.Price, source => source.MapFrom(src => src.OD_Price))
            .ReverseMap();

        // Mapping Product Entity.
        CreateMap<Product, ProductDTO>()
            .ForMember(destination => destination.Id, source => source.MapFrom(src => src.Prod_Id))
            .ForMember(destination => destination.Name, source => source.MapFrom(src => src.Prod_Name))
            .ForMember(destination => destination.Description, source => source.MapFrom(src => src.Prod_Description))
            .ForMember(destination => destination.Price, source => source.MapFrom(src => src.Prod_Price))
            .ForMember(destination => destination.Availability, source => source.MapFrom(src => src.Prod_Availability))
            .ReverseMap();

        // Mapping Province Entity.
        CreateMap<Province, ProvinceDTO>()
            .ForMember(destination => destination.Id, source => source.MapFrom(src => src.Provi_Id))
            .ForMember(destination => destination.CountryId, source => source.MapFrom(src => src.Provi_CountryId))
            .ForMember(destination => destination.Name, source => source.MapFrom(src => src.Provi_Name))
            .ReverseMap();

        // Mapping User Entity.
        CreateMap<User, UserDTO>()
            .ForMember(destination => destination.Id, source => source.MapFrom(src => src.User_Id))
            .ForMember(destination => destination.EmployeeId, source => source.MapFrom(src => src.User_EmpId))
            .ForMember(destination => destination.Username, source => source.MapFrom(src => src.User_Username))
            .ForMember(destination => destination.Email, source => source.MapFrom(src => src.User_Email))
            .ReverseMap();
    }
}
