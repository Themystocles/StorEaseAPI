using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("TransactionHistory")]
public class TransactionHistory
{
    public int Id { get; set; }

    [Required]
    [StringLength(255)]
    public string Cliente { get; set; }

    public string CPF { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Quantidade deve ser maior que zero.")]
    public int Quantidade { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime? DataHora { get; set; } = DateTime.UtcNow;

    [Required]
    [StringLength(50)]
    public string Operacao { get; set; }

    [StringLength(255)]
    public string Item { get; set; }

    // Construtor
    public TransactionHistory() { }
    public TransactionHistory(string cliente, string cpf, int quantidade, string operacao, string item)
    {
        Cliente = cliente;
        CPF = cpf;
        Quantidade = quantidade;
        Operacao = operacao;
        Item = item;
        DataHora = DateTime.UtcNow;
    }
}
