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
    public void CreatePayment(Leitura reading)
    {
        //Salvar o cliente o cliente no context
        _context.Leituras.Add(reading);
        _context.SaveChanges();

    }
}