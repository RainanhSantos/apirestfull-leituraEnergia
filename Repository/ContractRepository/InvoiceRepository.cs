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
    public Fatura CreateInvoice(Fatura invoice)
    {
        //Salvar o cliente o cliente no context
        _context.Faturas.Add(invoice);
        _context.SaveChanges();

        return invoice;

    }

    public List<Fatura> ListInvoices()
    {
        return _context.Faturas.ToList();
    }

    public Fatura SearcInvoiceForId(int id)
    {
        return _context.Faturas.FirstOrDefault(Cliente => Cliente.Id == id);
    }

    public void RemoveInvoice(Fatura invoice)
    {
        //Removendo do contexto
        _context.Remove(invoice);

        //Salvando as mudanças no banco de dados
        _context.SaveChanges();
    }

    public void UpdateInvoice()
    {
        //SAlvando qualquer atualização feita no banco de dados
        _context.SaveChanges();
    }

}