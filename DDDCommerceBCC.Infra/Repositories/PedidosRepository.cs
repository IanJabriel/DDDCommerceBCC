using DDDCommerceBCC.Domain.Entities;
using DDDCommerceBCC.Infra.Interfaces;

namespace DDDCommerceBCC.Infra.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly SqlContext sqlContext;

        public PedidoRepository()
        {
            sqlContext = new SqlContext();
        }

        public bool AddPedido(Pedido pedido)
        {
            if (pedido == null) return false;
            sqlContext.Pedidos.Add(pedido);
            sqlContext.SaveChanges();
            return true;
        }

        public bool DeletePedido(int id)
        {
            if (id <= 0) return false;
            var pedido = sqlContext.Pedidos.Find(id);
            sqlContext.Pedidos.Remove(pedido);
            sqlContext.SaveChanges();
            return true;
        }

        public List<Pedido> GetAll()
        {
            return sqlContext.Pedidos.ToList();
        }

        public Pedido GetPedidoById(int id)
        {
            return sqlContext.Pedidos.Find(id);
        }

        public void UpdatePedido(int id, Pedido pedido)
        {
            if (pedido == null || id <= 0) throw new ArgumentException("Pedido inválido ou ID inválido.");

            var pedidoExistente = sqlContext.Pedidos.Find(id);
            if (pedidoExistente == null) throw new KeyNotFoundException("Pedido não encontrado.");

            // Atualiza os campos do pedido existente
            pedidoExistente.LojaOrigem = pedido.LojaOrigem;
            pedidoExistente.Data = pedido.Data;

            sqlContext.SaveChanges();
        }
    }
}