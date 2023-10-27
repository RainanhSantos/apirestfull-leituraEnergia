using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apigerenciamentocontrato.Data.DTOs.Invoice.Response;

public class ResponseInvoice
{
    public int Id { get; set; }
    public decimal ValorTotal { get; set; }
    public string StatusFatura { get; set; }
}