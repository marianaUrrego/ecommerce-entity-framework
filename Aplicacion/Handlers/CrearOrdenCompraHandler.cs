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
    public class CrearOrdenCompraHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CrearOrdenCompraHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OrdenCompra> Handle(CrearOrdenCompraCommand command, CancellationToken cancellationToken)
        {
            // Mapear los items del DTO al dominio
            var items = command.Items.Select(i =>
                new ItemOrden(i.ProductoId, i.Cantidad, i.PrecioUnitario)).ToList();

            // Crear dirección desde el DTO
            var direccion = new DireccionEntrega(command.DireccionEntrega.Ciudad, command.DireccionEntrega.Direccion);

            // Crear la orden
            var orden = new OrdenCompra(command.ClienteId, items, direccion);

            // Guardar en la base de datos
            await _unitOfWork.Ordenes.AddAsync(orden);
            await _unitOfWork.CommitAsync();

            return orden;
        }
    }
}
