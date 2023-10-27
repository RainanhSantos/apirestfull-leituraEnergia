using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apicemig.Models.DadosContrato;
using apigerenciamentocontrato.Data.DTOs.EnergyMeters;
using apigerenciamentocontrato.Data.DTOs.EnergyMeters.Response;
using apigerenciamentocontrato.Repository.ContractRepository;
using Microsoft.AspNetCore.Mvc;

namespace apigerenciamentocontrato.Services.ContractServices;

public class ServiceEnergyMeters
{
    private EnergyMetersRepository _energyMatersRepository;

    public ServiceEnergyMeters([FromServices] EnergyMetersRepository energyMeters)
    {
        _energyMatersRepository = energyMeters;
    }
    public ResponseEnergyMeters CreateEnergyMeters(CreateEnergyMeters newEnergyMeters)
    {
        //Converte DTO para o modelo Client
        //Encaminha para o repositório salvar o BD
        Medidor medidor = new();
        medidor.NumeroSerie = newEnergyMeters.NumeroSerie;
        medidor.TipoMedidor = newEnergyMeters.TipoMedidor;
        medidor.Leituras = newEnergyMeters.Leituras;

        var dataInstalacao = DateTime.Now;
        medidor.DataInstalacao = dataInstalacao;

        _energyMatersRepository.CreateCEnergyMeters(medidor);

        var responseEnergyMeters = ConvertModelToResponse(medidor);

        return responseEnergyMeters;
    }

        public List<ResponseEnergyMeters> ListEnergyMeters()
    {
        //Solicitando ao repositório os procedimentos
        var energiMeters = _energyMatersRepository.ListEnergyMeters();
        
        //Copiando os dados dos modelos para as respostas
        List<ResponseEnergyMeters> responseEnergyMeters = new();

        foreach(var medidor in energiMeters)
        {

            var responseEnergyMeter = ConvertModelToResponse(medidor);

            responseEnergyMeters.Add(responseEnergyMeter);


        }
            return responseEnergyMeters;
    }

    public ResponseEnergyMeters SearcEnergyMetersForId(int id)
    {
        //Solicita ao repositório buscar por id
        var energyMeters =  _energyMatersRepository.SearcEnergyMetersForId(id);

        if(energyMeters is null)
        {
            return null;
        }

        //Copiando o modelo para resposta
        var responseEnergyMeters = ConvertModelToResponse(energyMeters);

        return responseEnergyMeters;
    }

    public void RemoveEnergyMeters(int id)
    {
        //Regra de negocio
        //

        //Buscando o procedimento no banco de dados
        var energyMeters = _energyMatersRepository.SearcEnergyMetersForId(id);

        if(energyMeters is null)
        {
            return;
        }

        //Solicitando que o repositório remova
        _energyMatersRepository.RemoveEnergyMeters(energyMeters);
    }

   public ResponseEnergyMeters UpdateEnergyMeters(int id, CreateEnergyMeters energyMetersEdited)
    {
        //Buscando o procedimento no banco de dados para editá-lo
        var energyMeters = _energyMatersRepository.SearcEnergyMetersForId(id);

        if(energyMeters is null)
        {
            return null;
        }

        //Copiando os dados da requisição para o modelo
        energyMeters.NumeroSerie = energyMetersEdited.NumeroSerie;
        energyMeters.TipoMedidor = energyMetersEdited.TipoMedidor;
        energyMeters.Leituras = energyMetersEdited.Leituras;


        //Regrad de negócio
        //

        //Salvando no banco de dados
        _energyMatersRepository.UpdateEnergyMeters();

        //Copiando os dados do modelo para a resposta
        var responseEnergyMeters = ConvertModelToResponse(energyMeters);

        return responseEnergyMeters;

    }

    private ResponseEnergyMeters ConvertModelToResponse(Medidor model)
    {
        var responseEnergyMeter = new ResponseEnergyMeters();
        responseEnergyMeter.Id = model.Id;
        responseEnergyMeter.Leituras = model.Leituras;
        responseEnergyMeter.TipoMedidor = model.TipoMedidor;
        responseEnergyMeter.NumeroSerie = model.NumeroSerie;

        return responseEnergyMeter;
    }

}