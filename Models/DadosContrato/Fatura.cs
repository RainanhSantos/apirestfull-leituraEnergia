using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apicemig.Models.DadosContrato;

public class Fatura
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "A data de emissão é obrigatório")]
    public DateTime DataEmissao { get; set; }

    [Required(ErrorMessage = "A data de vencimento é obrigatório")]
    public DateTime DataVencimento { get; set; }

    [Required(ErrorMessage = "O valor total da fatura é obrigatório")]
    public decimal ValorTotal { get; set; }

    [Required(ErrorMessage = "O status da fatura é obrigatório")]
    [MaxLength(8, ErrorMessage = "Limite de caracteres excedido")]
    public string? StatusFatura { get; set; }
    
    public virtual Pagamento Pagamento { get; set; }
    
    [Required]
    public int ContratoId { get; set; }
    public virtual Contrato Contrato { get; set; }
}