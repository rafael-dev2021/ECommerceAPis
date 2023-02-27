using AutoMapper;
using ECommerce.Application.DTOs;
using ECommerce.Application.Products.Commands;

namespace ECommerce.Application.Mappings
{
    public class MappingCommandProfile : Profile
    {
        public MappingCommandProfile()
        {
            CreateMap<ProductDto, CreateCommand>();
            CreateMap<ProductDto, UpdateCommand>();
        }
    }
}
