using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
[Table("CadastroItens")]
public class ItemModel
{
    public int Id { get; set; }

    [MaxLength(255)]
    public string Nome { get; set; }

    public int Quantidade { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Preco { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime? DataCadastro { get; set; }
}
