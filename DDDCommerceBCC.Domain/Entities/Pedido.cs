using System.Text.Json.Serialization;

namespace DDDCommerceBCC.Domain.Entities
{
    public class Pedido
    {
        public int Id { get; set; }
        public string LojaOrigem { get; set; }
        public DateTime Data { get; set; }
    }
}