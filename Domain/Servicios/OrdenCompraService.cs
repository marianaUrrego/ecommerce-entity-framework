using ecommerce.Domain.Aggregates;
using ecommerce.Domain.Entities;
using ecommerce.Domain.Interfaces;
using ecommerce.Domain.ValueObjects;

namespace ecommerce.Domain.Servicios
{
    public class OrdenCompraService
    {
        private readonly IOrdenCompraRepository _ordenCompraRepository;

        public OrdenCompraService(IOrdenCompraRepository ordenCompraRepository)
        {
            _ordenCompraRepository = ordenCompraRepository;
        }

        public async Task CrearOrdenCompra()
        {
            var orden = new OrdenCompra(
                Guid.NewGuid(),
                new List<ItemOrden>
                {
                new ItemOrden(Guid.NewGuid(), 2, 100)
                },
                new DireccionEntrega("Calle 123", "Ciudad Ejemplo")
            );

            await _ordenCompraRepository.AddAsync(orden);
        }

        public async Task<List<OrdenCompra>> ObtenerOrdenes()
        {
            return await _ordenCompraRepository.GetAllAsync();
        }
    }
}
