using AutoMapper;
using ecommerce.Aplicacion.DTOs;
using ecommerce.Domain.Aggregates;
using ecommerce.Domain.Entities;

namespace ecommerce.Domain.Servicios
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Configuración de mapeo entre DTO y entidad
            CreateMap<CrearOrdenCompraDto, OrdenCompra>()
                .ForMember(dest => dest.ClienteId, opt => opt.MapFrom(src => src.ClienteId))
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));

            CreateMap<ItemOrdenDto, ItemOrden>(); // Mapeo de los items
        }
    }
}
