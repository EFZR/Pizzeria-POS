using AutoMapper;
using Application.DTO;
using Domain.Entity;

namespace Transversal.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Mapping Country Entity.
        CreateMap<Country, CountryDTO>().ReverseMap()
            .ForMember(destination => destination.Country_Id, source => source.MapFrom(src => src.Id))
            .ForMember(destination => destination.Country_Name, source => source.MapFrom(src => src.Name));

        // Mapping Customer Entity.
        CreateMap<Customer, CustomerDTO>().ReverseMap()
            .ForMember(destination => destination.Cust_Id, source => source.MapFrom(src => src.Id))
            .ForMember(destination => destination.Cust_LocalId, source => source.MapFrom(src => src.LocalityId))
            .ForMember(destination => destination.Cust_FirstName, source => source.MapFrom(src => src.FirstName))
            .ForMember(destination => destination.Cust_LastName, source => source.MapFrom(src => src.LastName))
            .ForMember(destination => destination.Cust_Phone, source => source.MapFrom(src => src.Phone))
            .ForMember(destination => destination.Cust_Email, source => source.MapFrom(src => src.Email));

        // Mapping Employee Entity.
        CreateMap<Employee, EmployeeDTO>().ReverseMap()
            .ForMember(destination => destination.Emp_Id, source => source.MapFrom(src => src.Id))
            .ForMember(destination => destination.Emp_LocalId, source => source.MapFrom(src => src.LocalityId))
            .ForMember(destination => destination.Emp_FirstName, source => source.MapFrom(src => src.FirstName))
            .ForMember(destination => destination.Emp_LastName, source => source.MapFrom(src => src.LastName))
            .ForMember(destination => destination.Emp_Phone, source => source.MapFrom(src => src.Phone));

        // Mapping Locality Entity.
        CreateMap<Locality, LocalityDTO>().ReverseMap()
            .ForMember(destination => destination.Local_Id, source => source.MapFrom(src => src.Id))
            .ForMember(destination => destination.Local_ProviId, source => source.MapFrom(src => src.ProvinceId))
            .ForMember(destination => destination.Local_Name, source => source.MapFrom(src => src.Name));

        // Mapping Order Entity.
        CreateMap<Order, OrderDTO>().ReverseMap()
            .ForMember(destination => destination.Ord_Id, source => source.MapFrom(src => src.Id))
            .ForMember(destination => destination.Ord_EmpId, source => source.MapFrom(src => src.EmployeeId))
            .ForMember(destination => destination.Ord_CustId, source => source.MapFrom(src => src.CustomerId))
            .ForMember(destination => destination.Ord_Date, source => source.MapFrom(src => src.Date))
            .ForMember(destination => destination.Ord_BillNumber, source => source.MapFrom(src => src.BillNumber))
            .ForMember(destination => destination.Ord_Total, source => source.MapFrom(src => src.Total));

        // Mapping Order Detail Entity.
        CreateMap<OrderDetail, OrderDetailDTO>().ReverseMap()
            .ForMember(destination => destination.OD_Id, source => source.MapFrom(src => src.Id))
            .ForMember(destination => destination.OD_OrdId, source => source.MapFrom(src => src.OrderId))
            .ForMember(destination => destination.OD_ProdId, source => source.MapFrom(src => src.ProductId))
            .ForMember(destination => destination.OD_Quantity, source => source.MapFrom(src => src.Quantity))
            .ForMember(destination => destination.OD_Price, source => source.MapFrom(src => src.Price));

        // Mapping Product Entity.
        CreateMap<Product, ProductDTO>().ReverseMap()
            .ForMember(destination => destination.Prod_Id, source => source.MapFrom(src => src.Id))
            .ForMember(destination => destination.Prod_Name, source => source.MapFrom(src => src.Name))
            .ForMember(destination => destination.Prod_Description, source => source.MapFrom(src => src.Description))
            .ForMember(destination => destination.Prod_Price, source => source.MapFrom(src => src.Price))
            .ForMember(destination => destination.Prod_Availability, source => source.MapFrom(src => src.Availability));

        // Mapping Province Entity.
        CreateMap<Province, ProvinceDTO>().ReverseMap()
            .ForMember(destination => destination.Provi_Id, source => source.MapFrom(src => src.Id))
            .ForMember(destination => destination.Provi_CountryId, source => source.MapFrom(src => src.CountryId))
            .ForMember(destination => destination.Provi_Name, source => source.MapFrom(src => src.Name));

        // Mapping User Entity.
        CreateMap<User, UserDTO>().ReverseMap()
            .ForMember(destination => destination.User_Id, source => source.MapFrom(src => src.Id))
            .ForMember(destination => destination.User_EmpId, source => source.MapFrom(src => src.EmployeeId))
            .ForMember(destination => destination.User_Username, source => source.MapFrom(src => src.Username))
            .ForMember(destination => destination.User_Email, source => source.MapFrom(src => src.Email));
    }
}
