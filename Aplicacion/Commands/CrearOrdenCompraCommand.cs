using ecommerce.Aplicacion.DTOs;
using MediatR;

namespace ecommerce.Aplicacion.Commands
{
    public class CrearOrdenCompraCommand : IRequest<Guid>
    {
        public Guid ClienteId { get; set; }
        public List<ItemOrdenDto> Items { get; set; } = new();
        public DireccionEntregaDto DireccionEntrega { get; set; } = null!;
        public CrearOrdenCompraCommand(Guid clienteId, List<ItemOrdenDto> items, DireccionEntregaDto direccionEntrega)
        {
            ClienteId = clienteId;
            Items = items;
            DireccionEntrega = direccionEntrega;
        }
    }
}
