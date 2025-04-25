using ecommerce.Domain.Aggregates;
using ecommerce.Domain.Entities;
using ecommerce.Domain.ValueObjects;

namespace ecommerce.Domain.Factories
{
    public class OrdenCompraFactory
    {
        public OrdenCompra CrearOrden(Guid clienteId, List<ItemOrden> items, DireccionEntrega direccion)
        {
            // Aquí podrías añadir más validaciones o lógica antes de la creación

            var orden = new OrdenCompra(clienteId, items, direccion);

            // Después de crear la orden, puedes publicar el evento de orden creada
            // Mediator.Publish(new OrdenCreadaEvent(orden.Id, clienteId, orden.Total)); // si lo necesitas

            return orden;
        }
    }
}
