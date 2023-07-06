using AutoMapper;
using BusinessApi.Dtos;
using BusinessApi.Models;

namespace BusinessApi.Profiles;

public class InventoryProfile : Profile
{
    public InventoryProfile()
    {
        CreateMap<Product, ProductReadDTO>();
        CreateMap<ProductCreateDTO, Product>();
        
        CreateMap<InventoryItem, InventoryDTO>();
        CreateMap<InventoryCreateDTO, InventoryItem>();

        CreateMap<Order, OrderDTO>();
        CreateMap<OrderCreateDTO, Order>();

        CreateMap<OrderItem,OrderItemDTO>();
        CreateMap<OrderItemCreateDTO, OrderItem>();
    }
    
}