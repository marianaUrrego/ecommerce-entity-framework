using ecommerce.Aplicacion.DTOs;
using ecommerce.Domain.Entities;
using ecommerce.Domain.Interfaces;
using ecommerce.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using ecommerce.Domain.Aggregates;
using ecommerce.Aplicacion.Commands;
using ecommerce.Aplicacion.Handlers;
using ecommerce.Infrastructure;
using AutoMapper;

namespace ecommerce.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdenCompraController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly CrearOrdenCompraHandler _crearOrdenCompraHandler;
        private readonly IMapper _mapper;

        public OrdenCompraController(IUnitOfWork unitOfWork, CrearOrdenCompraHandler crearOrdenCompraHandler, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _crearOrdenCompraHandler = crearOrdenCompraHandler;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CrearOrden([FromBody] CrearOrdenCompraDto dto, CancellationToken cancellationToken)  // Incluir cancellationToken
        {
            // Mapear el DTO a Command usando AutoMapper y enviar al Handler
            var command = _mapper.Map<CrearOrdenCompraCommand>(dto);

            // Usar el handler para crear la orden, pasando el cancellationToken
            var orden = await _crearOrdenCompraHandler.Handle(command, cancellationToken);  // Pasa el cancellationToken aquí

            // Retornar la respuesta con el detalle de la orden
            return CreatedAtAction(nameof(ObtenerOrdenPorId), new { id = orden.Id }, orden);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerOrdenPorId(Guid id)
        {
            var orden = await _unitOfWork.Ordenes.GetByIdAsync(id);
            if (orden == null)
                return NotFound();

            return Ok(orden);
        }
    }
}