using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apicemig.Data;
using apicemig.Models.DadosContrato;
using Microsoft.AspNetCore.Mvc;

namespace apigerenciamentocontrato.Repository.ContractRepository;

public class ReadingRepository
{
    private AppDbContext _context;
    public ReadingRepository([FromServices] AppDbContext context)
    {
        _context = context;
    }
    public Leitura CreatePayment(Leitura reading)
    {
        //Salvar o cliente o cliente no context
        _context.Leituras.Add(reading);
        _context.SaveChanges();

        return reading;

    }

    public List<Leitura> ListReadings()
    {
        return _context.Leituras.ToList();
    }

    public Leitura SearcReadingForId(int id)
    {
        return _context.Leituras.FirstOrDefault(Cliente => Cliente.Id == id);
    }

    public void RemoveReading(Leitura reading)
    {
        //Removendo do contexto
        _context.Remove(reading);

        //Salvando as mudanças no banco de dados
        _context.SaveChanges();
    }

    public void UpdateReading()
    {
        //SAlvando qualquer atualização feita no banco de dados
        _context.SaveChanges();
    }

}