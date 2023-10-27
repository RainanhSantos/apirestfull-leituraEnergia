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
    public Endereco CreateAddress(Endereco address)
    {
        _context.Enderecos.Add(address);
        _context.SaveChanges();

        return address;
    }

        public List<Endereco> ListAdresses()
    {
        return _context.Enderecos.ToList();
    }

    public Endereco SearcAddressForId(int id)
    {
        return _context.Enderecos.FirstOrDefault(Cliente => Cliente.Id == id);
    }

    public void RemoveAddress(Endereco address)
    {
        //Removendo do contexto
        _context.Remove(address);

        //Salvando as mudanças no banco de dados
        _context.SaveChanges();
    }

    public void UpdateAddress()
    {
        //SAlvando qualquer atualização feita no banco de dados
        _context.SaveChanges();
    }

}