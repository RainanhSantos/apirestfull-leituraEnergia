using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apicemig.Models.DadosContrato;
using apigerenciamentocontrato.Data.DTOs.EnergyMeters;
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
    public void CreateEnergyMeters(CreateEnergyMeters newEnergyMeters)
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
    }

}