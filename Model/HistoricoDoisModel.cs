using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("HistoricoDois")]
public class HistoricoDoisModel
{
    public int Id { get; set; }

    [MaxLength(255)]
    public string Cliente { get; set; }

    [MaxLength(11)]
    public string CPF { get; set; }

    public int Quantidade { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime? DataHora { get; set; } = DateTime.Now;

     [MaxLength(11)]
    public string Operacao { get; set; }

    public string item { get; set; }
}
    