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
    public Pagamento CreatePayment(Pagamento payment)
    {
        //Salvar o cliente o cliente no context
        _context.Pagamentos.Add(payment);
        _context.SaveChanges();

        return payment;

    }

    public List<Pagamento> ListPayments()
    {
        return _context.Pagamentos.ToList();
    }

    public Pagamento SearcPaymentForId(int id)
    {
        return _context.Pagamentos.FirstOrDefault(Cliente => Cliente.Id == id);
    }

    public void RemovePayment(Pagamento payment)
    {
        //Removendo do contexto
        _context.Remove(payment);

        //Salvando as mudanças no banco de dados
        _context.SaveChanges();
    }

    public void UpdatePayment()
    {
        //SAlvando qualquer atualização feita no banco de dados
        _context.SaveChanges();
    }

}