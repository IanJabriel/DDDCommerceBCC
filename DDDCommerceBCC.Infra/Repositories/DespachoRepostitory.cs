using DDDCommerceBCC.Domain.Entities;
using DDDCommerceBCC.Infra.Interfaces;

namespace DDDCommerceBCC.Infra.Repositories
{
    public class DespachoRepository : IDespachoRepository
    {
        private readonly SqlContext sqlContext;

        public DespachoRepository()
        {
            sqlContext = new SqlContext();
        }

        public Despacho GetByPedidoId(int pedidoId)
        {
            return sqlContext.Despachos.FirstOrDefault(d => d.PedidoId == pedidoId);
        }

        public void Create(Despacho despacho)
        {
            despacho.DataDespacho = DateTime.Now;
            sqlContext.Despachos.Add(despacho);
            sqlContext.SaveChanges();
        }
    }
}