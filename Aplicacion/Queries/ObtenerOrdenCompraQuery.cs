using MediatR;
using ecommerce.Aplicacion.DTOs;

namespace ecommerce.Aplicacion.Queries
{
    /// <summary>Consulta para obtener una orden por su ID.</summary>
    public class ObtenerReservaPorIdQuery : IRequest<OrdenCompraDto>
    {
        public Guid Id { get; set; }
    }
}
