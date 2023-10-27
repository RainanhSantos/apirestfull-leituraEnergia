using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apicemig.Data;
using apicemig.Models.DadosContrato;
using Microsoft.AspNetCore.Mvc;

namespace apigerenciamentocontrato.Repository.ContractRepository;

public class ContractRepository
{

    private AppDbContext _context;
    public ContractRepository([FromServices] AppDbContext context)
    {
        _context = context;
    }
    public Contrato CreateContract(Contrato contract)
    {
        //Salvar o cliente o cliente no context
        _context.Contratos.Add(contract);
        _context.SaveChanges();

        return contract;

    }

     public List<Contrato> ListContracts()
    {
        return _context.Contratos.ToList();
    }

    public Contrato SearcContractForId(int id)
    {
        return _context.Contratos.FirstOrDefault(Cliente => Cliente.Id == id);
    }

    public void RemoveContract(Contrato contract)
    {
        //Removendo do contexto
        _context.Remove(contract);

        //Salvando as mudanças no banco de dados
        _context.SaveChanges();
    }

    public void UpdateContract()
    {
        //SAlvando qualquer atualização feita no banco de dados
        _context.SaveChanges();
    }
}