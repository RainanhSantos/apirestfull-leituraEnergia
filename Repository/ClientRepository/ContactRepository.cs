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
    public Contato CreateContact(Contato contact)
    {
        //Salvar o cliente o cliente no context
        _context.Contatos.Add(contact);
        _context.SaveChanges();

        return contact;

    }

     public List<Contato> ListContacts()
    {
        return _context.Contatos.ToList();
    }

    public Contato SearcContactForId(int id)
    {
        return _context.Contatos.FirstOrDefault(Cliente => Cliente.Id == id);
    }

    public void RemoveContact(Contato contact)
    {
        //Removendo do contexto
        _context.Remove(contact);

        //Salvando as mudanças no banco de dados
        _context.SaveChanges();
    }

    public void UpdateContact()
    {
        //SAlvando qualquer atualização feita no banco de dados
        _context.SaveChanges();
    }

}