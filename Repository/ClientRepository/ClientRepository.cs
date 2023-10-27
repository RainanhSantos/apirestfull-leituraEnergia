using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apicemig.Data;
using apicemig.Models;
using Microsoft.AspNetCore.Mvc;

namespace apigerenciamentocontrato.Repository.ClientRepository;

public class ClientRepository
{
    //Campo injetado no contrutor
    private AppDbContext _context;
    public ClientRepository([FromServices] AppDbContext context)
    {
        _context = context;
    }
    public Cliente CreateClient(Cliente client)
    {
        //Salvar o cliente o cliente no context
        _context.Clientes.Add(client);
        _context.SaveChanges();

        return client;

    }

    public List<Cliente> ListCustomers()
    {
        return _context.Clientes.ToList();
    }

    public Cliente SearchClientForId(int id)
    {
        return _context.Clientes.FirstOrDefault(Cliente => Cliente.Id == id);
    }

    public void RemoveClient(Cliente client)
    {
        //Removendo do contexto
        _context.Remove(client);

        //Salvando as mudanças no banco de dados
        _context.SaveChanges();
    }

    public void UpdateClient()
    {
        //SAlvando qualquer atualização feita no banco de dados
        _context.SaveChanges();
    }
}