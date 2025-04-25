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
using MediatR;

namespace ecommerce.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdenesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdenesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CrearOrden([FromBody] CrearOrdenCompraCommand command)
        {
            var ordenId = await _mediator.Send(command);
            return CreatedAtAction(nameof(ObtenerOrden), new { id = ordenId }, ordenId);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerOrden(Guid id, [FromServices] IOrdenCompraRepository repo)
        {
            var orden = await repo.GetByIdAsync(id);
            return orden is null ? NotFound() : Ok(orden);
        }
    }
}