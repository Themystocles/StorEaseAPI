using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("historico")]
public class HistoricoModel
{
    public int Id { get; set; }
    public string Item { get; set; }
    public string Operacao { get; set; }
    public DateTime? DataHoraRegistro { get; set; } = DateTime.Now;
}
