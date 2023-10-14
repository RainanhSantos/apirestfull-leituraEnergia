using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using apicemig.Models.DadosContrato;
using apigerenciamentocontrato.Data.DTOs.Contact;
using apigerenciamentocontrato.Data.DTOs.Contract;
using apigerenciamentocontrato.Repository.ContractRepository;
using Microsoft.AspNetCore.Mvc;

namespace apigerenciamentocontrato.Services.ContractServices;

public class ServiceContract
{
    private ContractRepository _contractRepository;

    public ServiceContract([FromServices] ContractRepository contract)
    {
        _contractRepository = contract;
    }
    public void CreateContract(CreateContract newContract)
    {
        //Converte DTO para o modelo 
        //Encaminha para o repositório salvar o BD
        Contrato contrato = new();
        contrato.TipoContrato = newContract.TipoContrato;
        contrato.ConsumoContrato = newContract.ConsumoContrato;
        contrato.DataTermino = newContract.DataTermino;
        contrato.StatusContrato = newContract.StatusContrato;

        var dataInicio = DateTime.Now;
        contrato.DataInicio = dataInicio;
        
        _contractRepository.CreateContract(contrato);
        
    }
}