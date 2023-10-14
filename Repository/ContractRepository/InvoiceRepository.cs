using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apicemig.Data;
using apicemig.Models.DadosContrato;
using Microsoft.AspNetCore.Mvc;

namespace apigerenciamentocontrato.Repository.ContractRepository;

public class InvoiceRepository
{
    private AppDbContext _context;
    public InvoiceRepository([FromServices] AppDbContext context)
    {
        _context = context;
    }
    public void CreateInvoice(Fatura invoice)
    {
        //Salvar o cliente o cliente no context
        _context.Faturas.Add(invoice);
        _context.SaveChanges();

    }
}