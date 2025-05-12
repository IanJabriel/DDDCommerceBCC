using DDDCommerceBCC.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class Despacho
{
    public int Id { get; set; }
    public string Transportadora { get; set; }
    public DateTime DataDespacho { get; set; }
    public string CodigoRastreio { get; set; }

    [Required]
    public int PedidoId { get; set; }
}