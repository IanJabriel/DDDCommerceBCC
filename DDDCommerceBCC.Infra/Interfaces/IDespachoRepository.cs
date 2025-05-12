using DDDCommerceBCC.Domain.Entities;

namespace DDDCommerceBCC.Infra.Interfaces
{
    public interface IDespachoRepository
    {
        Despacho GetByPedidoId(int pedidoId);
        void Create(Despacho despacho);
    }
}