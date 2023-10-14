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
    public void CreateContract(Contrato contract)
    {
        //Salvar o cliente o cliente no context
        _context.Contratos.Add(contract);
        _context.SaveChanges();

    }
}