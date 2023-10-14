using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apicemig.Data;
using apicemig.Models.DadosCliente;
using Microsoft.AspNetCore.Mvc;

namespace apigerenciamentocontrato.Repository.ClientRepository;

public class ContactRepository
{
    private AppDbContext _context;
    public ContactRepository([FromServices] AppDbContext context)
    {
        _context = context;
    }
    public void CreateContact(Contato contact)
    {
        //Salvar o cliente o cliente no context
        _context.Contatos.Add(contact);
        _context.SaveChanges();

    }
}