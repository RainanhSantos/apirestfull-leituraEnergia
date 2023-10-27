using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apigerenciamentocontrato.Data.DTOs.Payment.Response;

public class ResponsePayment
{
    public int Id { get; set; }
    public decimal ValorPago { get; set; }
}