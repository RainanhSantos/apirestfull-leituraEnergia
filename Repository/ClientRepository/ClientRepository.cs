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
    public void CreateClient(Cliente client)
    {
        //Salvar o cliente o cliente no context
        _context.Clientes.Add(client);
        _context.SaveChanges();

    }
}