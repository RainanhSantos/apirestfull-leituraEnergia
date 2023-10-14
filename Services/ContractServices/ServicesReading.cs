using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apicemig.Models.DadosContrato;
using apigerenciamentocontrato.Data.DTOs.Reading;
using apigerenciamentocontrato.Repository.ContractRepository;
using Microsoft.AspNetCore.Mvc;

namespace apigerenciamentocontrato.Services.ContractServices;

public class ServicesReading
{
    private ReadingRepository _readingRepository;

    public ServicesReading([FromServices] ReadingRepository repository)
    {
        _readingRepository = repository;
    }
    public void CreateReading(CreateReading newReading)
    {
        //Converte DTO para o modelo Client
        //Encaminha para o repositório salvar o BD
        Leitura leitura = new();
        leitura.ValorLeitura = newReading.ValorLeitura;

        var dataLeitura = DateTime.Now;
        leitura.DataLeitura = dataLeitura;

        _readingRepository.CreatePayment(leitura);
    }
}