using ecommerce.Aplicacion.DTOs;
using MediatR;

namespace ecommerce.Aplicacion.Commands
{
    public class CrearOrdenCompraCommand : IRequest<Guid>
    {
        public Guid ClienteId { get; set; }
        public List<ItemOrdenCommandDto> Items { get; set; } = new();
        public DireccionEntregaDto DireccionEntrega { get; set; } = null!;
    }

    public class ItemOrdenCommandDto
    {
        public Guid ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}
