using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace apigerenciamentocontrato.Data.DTOs.Payment
{
    public class CreatePayment
    {
    // [Required(ErrorMessage = "A data de pagamento é obrigatória")]
    // public DateTime DataPagamento { get; set; }

    [Required(ErrorMessage = "O valor pago na fatura é obrigatório")]
    [Column(TypeName = "decimal(13,2)")]
    public decimal ValorPago { get; set; }
    }
}