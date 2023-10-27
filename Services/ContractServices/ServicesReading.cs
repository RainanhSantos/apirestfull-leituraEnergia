using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apicemig.Models.DadosContrato;
using apigerenciamentocontrato.Data.DTOs.Reading;
using apigerenciamentocontrato.Data.DTOs.Reading.Response;
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
    public ResponseReading CreateReading(CreateReading newReading)
    {
        //Converte DTO para o modelo Client
        //Encaminha para o repositório salvar o BD
        Leitura leitura = new();
        leitura.ValorLeitura = newReading.ValorLeitura;

        var dataLeitura = DateTime.Now;
        leitura.DataLeitura = dataLeitura;

        _readingRepository.CreatePayment(leitura);

        var responseReading = ConvertModelToResponse(leitura);

        return responseReading;
    }

        public List<ResponseReading> ListReading()
    {
        //Solicitando ao repositório os procedimentos
        var reading = _readingRepository.ListReadings();
        
        //Copiando os dados dos modelos para as respostas
        List<ResponseReading> responseReadings = new();

        foreach(var leitura in reading)
        {

            var responseReading = ConvertModelToResponse(leitura);

            responseReadings.Add(responseReading);
        }
            return responseReadings;
    }

    public ResponseReading SearcReadingForId(int id)
    {
        //Solicita ao repositório buscar por id
        var reading =  _readingRepository.SearcReadingForId(id);

        if(reading is null)
        {
            return null;
        }

        //Copiando o modelo para resposta
        var responseReading = ConvertModelToResponse(reading);

        return responseReading;
    }

    public void RemoveReading(int id)
    {
        //Regra de negocio
        //

        //Buscando o procedimento no banco de dados
        var reading = _readingRepository.SearcReadingForId(id);

        if(reading is null)
        {
            return;
        }

        //Solicitando que o repositório remova
        _readingRepository.RemoveReading(reading);
    }

        public ResponseReading UpdateReading(int id, CreateReading readingEdited)
            {
                //Buscando o procedimento no banco de dados para editá-lo
                var reading = _readingRepository.SearcReadingForId(id);

                if(reading is null)
                {
                    return null;
                }

                //Copiando os dados da requisição para o modelo
                reading.ValorLeitura = readingEdited.ValorLeitura;


                //Regrad de negócio
                //

                //Salvando no banco de dados
                _readingRepository.UpdateReading();

                //Copiando os dados do modelo para a resposta
                var responseReading = ConvertModelToResponse(reading);

                return responseReading;

            }

    private ResponseReading ConvertModelToResponse(Leitura model)
    {
        var responseReading = new ResponseReading();
        responseReading.Id = model.Id;
        responseReading.ValorLeitura = model.ValorLeitura;

        return responseReading;
    }
}