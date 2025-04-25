using ecommerce.Aplicacion.Commands;
using ecommerce.Domain.Aggregates;
using ecommerce.Domain.Entities;
using ecommerce.Domain.Interfaces;
using ecommerce.Domain.ValueObjects;
using MediatR;
using System.Runtime.InteropServices;
using AutoMapper;

namespace ecommerce.Aplicacion.Handlers
{
    public class CrearOrdenCompraCommandHandler : IRequestHandler<CrearOrdenCompraCommand, Guid>
    {
        private readonly IOrdenCompraRepository _ordenCompraRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CrearOrdenCompraCommandHandler(IOrdenCompraRepository ordenCompraRepository, IUnitOfWork unitOfWork)
        {
            _ordenCompraRepository = ordenCompraRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CrearOrdenCompraCommand request, CancellationToken cancellationToken)
        {
            var direccion = new DireccionEntrega(
                request.DireccionEntrega.Ciudad,
                request.DireccionEntrega.Direccion
            );

            var items = request.Items.Select(i =>
                new ItemOrden(i.ProductoId, i.Cantidad, i.PrecioUnitario)
            ).ToList();

            var orden = new OrdenCompra(request.ClienteId, items, direccion);

            await _ordenCompraRepository.AddAsync(orden, cancellationToken);

            await _unitOfWork.SaveEntitiesAsync(cancellationToken);

            return orden.Id;
        }
    }
}
