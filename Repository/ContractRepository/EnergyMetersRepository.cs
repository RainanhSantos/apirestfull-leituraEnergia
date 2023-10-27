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
    public Medidor CreateCEnergyMeters(Medidor energyMeters)
    {
        //Salvar o cliente o cliente no context
        _context.Medidores.Add(energyMeters);
        _context.SaveChanges();

        return energyMeters;

    }

     public List<Medidor> ListEnergyMeters()
    {
        return _context.Medidores.ToList();
    }
    public Medidor SearcEnergyMetersForId(int id)
    {
        return _context.Medidores.FirstOrDefault(Cliente => Cliente.Id == id);
    }

    public void RemoveEnergyMeters(Medidor energyMeters)
    {
        //Removendo do contexto
        _context.Remove(energyMeters);

        //Salvando as mudanças no banco de dados
        _context.SaveChanges();
    }

    public void UpdateEnergyMeters()
    {
        //SAlvando qualquer atualização feita no banco de dados
        _context.SaveChanges();
    }

}