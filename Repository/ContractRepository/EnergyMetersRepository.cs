using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apicemig.Data;
using apicemig.Models.DadosContrato;
using Microsoft.AspNetCore.Mvc;

namespace apigerenciamentocontrato.Repository.ContractRepository;

public class EnergyMetersRepository
{
    private AppDbContext _context;
    public EnergyMetersRepository([FromServices] AppDbContext context)
    {
        _context = context;
    }
    public void CreateCEnergyMeters(Medidor energyMeters)
    {
        //Salvar o cliente o cliente no context
        _context.Medidores.Add(energyMeters);
        _context.SaveChanges();

    }
}