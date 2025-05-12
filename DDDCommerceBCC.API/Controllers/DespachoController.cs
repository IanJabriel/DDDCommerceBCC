using DDDCommerceBCC.Domain.Entities;
using DDDCommerceBCC.Infra.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DDDCommerce.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DespachoController : ControllerBase
    {
        private readonly IDespachoRepository _despachoRepository;
        private readonly IPedidoRepository _pedidoRepository;

        public DespachoController(
            IDespachoRepository despachoRepository,
            IPedidoRepository pedidoRepository)
        {
            _despachoRepository = despachoRepository;
            _pedidoRepository = pedidoRepository;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Despacho request)
        {
            // Remove a validação da propriedade de navegação
            ModelState.Remove("request.Pedido");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Validação manual do PedidoId
            if (request.PedidoId <= 0)
                return BadRequest("PedidoId inválido");

            var pedidoExistente = _pedidoRepository.GetPedidoById(request.PedidoId);
            if (pedidoExistente == null)
                return NotFound("Pedido não encontrado");

            var despachoExistente = _despachoRepository.GetByPedidoId(request.PedidoId);
            if (despachoExistente != null)
                return BadRequest("Pedido já despachado");

            var novoDespacho = new Despacho
            {
                Transportadora = request.Transportadora,
                CodigoRastreio = request.CodigoRastreio,
                PedidoId = request.PedidoId,
                DataDespacho = DateTime.Now
            };

            _despachoRepository.Create(novoDespacho);
            return Ok(novoDespacho);
        }
        [HttpGet("pedido/{pedidoId}")]
        public IActionResult GetByPedidoId(int pedidoId)
        {
            var despacho = _despachoRepository.GetByPedidoId(pedidoId);
            if (despacho == null)
                return NotFound();

            return Ok(despacho);
        }
    }
}