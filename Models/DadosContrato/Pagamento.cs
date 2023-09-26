using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apicemig.Models.DadosContrato;

public class Pagamento
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "A data de pagamento é obrigatória")]
    public DateTime DataPagamento { get; set; }

    [Required(ErrorMessage = "O valor pago na fatura é obrigatório")]
    public decimal ValorPago { get; set; }
    public int FaturaId { get; set; }
    public virtual Fatura Fatura { get; set; }
}