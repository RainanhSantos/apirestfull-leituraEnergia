using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apicemig.Data;
using apicemig.Models.DadosCliente;
using Microsoft.AspNetCore.Mvc;

namespace apigerenciamentocontrato.Repository.ClientRepository;

public class AddressRepository
{
    private AppDbContext _context;
    
    public AddressRepository([FromBody] AppDbContext context)
    {
        _context = context;
    }
    public void CreateAddress(Endereco address)
    {
        _context.Enderecos.Add(address);
        _context.SaveChanges();
    }
}