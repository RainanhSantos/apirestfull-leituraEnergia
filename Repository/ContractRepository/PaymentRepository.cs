using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apicemig.Data;
using apicemig.Models.DadosContrato;
using Microsoft.AspNetCore.Mvc;

namespace apigerenciamentocontrato.Repository.ContractRepository;

public class PaymentRepository
{
    private AppDbContext _context;
    public PaymentRepository([FromServices] AppDbContext context)
    {
        _context = context;
    }
    public void CreatePayment(Pagamento payment)
    {
        //Salvar o cliente o cliente no context
        _context.Pagamentos.Add(payment);
        _context.SaveChanges();

    }
}