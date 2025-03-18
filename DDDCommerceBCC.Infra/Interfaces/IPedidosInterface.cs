using DDDCommerceBCC.Domain.Entities;

namespace DDDCommerceBCC.Infra.Interfaces
{
    public interface IPedidoRepository
    {
        Pedido GetPedidoById(int id);
        bool AddPedido(Pedido pedido);
        List<Pedido> GetAll();
        void UpdatePedido(int id, Pedido pedido);
        bool DeletePedido(int id);
    }
}