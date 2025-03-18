using DDDCommerceBCC.Domain.Entities;
using DDDCommerceBCC.Infra.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DDDCommerceBCC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoRepository _context;

        public PedidosController(IPedidoRepository context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Pedido>> GetPedidos()
        {
            return _context.GetAll();
        }


        [HttpGet("{id}")]
        public ActionResult<Pedido> GetPedido(int id)
        {
            var pedido = _context.GetPedidoById(id);

            if (pedido == null)
            {
                return NotFound();
            }

            return pedido;
        }

        [HttpPost]
        public ActionResult<Pedido> PostPedido(Pedido pedido)
        {
            _context.AddPedido(pedido);
            return CreatedAtAction("GetPedido", new { id = pedido.Id }, pedido);
        }

        [HttpPut("{id}")]
        public IActionResult PutPedido(int id, Pedido pedido)
        {
            if (id != pedido.Id) return BadRequest("ID do pedido não corresponde ao ID na URL.");

            try
            {
                _context.UpdatePedido(id, pedido);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Pedido não encontrado.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao atualizar o pedido: " + ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePedido(int id)
        {
            if (_context.DeletePedido(id))
                return Ok("Pedido Deletado com sucesso");

            return NotFound("Id nao encontrado");
        }

    }
}
