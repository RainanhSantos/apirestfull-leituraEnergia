using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using apicemig.Models.DadosContrato;
using apigerenciamentocontrato.Data.DTOs.Contact;
using apigerenciamentocontrato.Data.DTOs.Contract;
using apigerenciamentocontrato.Data.DTOs.Contract.Response;
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
    public ResponseContract CreateContract(CreateContract newContract)
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

        var responseContract = ConvertModelToResponse(contrato);

        return responseContract;
        
    }

        public List<ResponseContract> ListContracts()
    {
        //Solicitando ao repositório os procedimentos
        var contract = _contractRepository.ListContracts();
        
        //Copiando os dados dos modelos para as respostas
        List<ResponseContract> responseContracts = new();

        foreach(var contrato in contract)
        {

        var responseContract = ConvertModelToResponse(contrato);

        responseContracts.Add(responseContract);

        }
            return responseContracts;
    }

    public ResponseContract SearcContractForId(int id)
    {
        //Solicita ao repositório buscar por id
        var contract =  _contractRepository.SearcContractForId(id);

        if(contract is null)
        {
            return null;
        }

        //Copiando o modelo para resposta
        var responseContract = ConvertModelToResponse(contract);

        return responseContract;
    }

    public void RemoveContract(int id)
    {
        //Regra de negocio
        //

        //Buscando o procedimento no banco de dados
        var contract = _contractRepository.SearcContractForId(id);

        if(contract is null)
        {
            return;
        }

        //Solicitando que o repositório remova
        _contractRepository.RemoveContract(contract);
    }

    public ResponseContract UpdateContract(int id, CreateContract contractEdited)
    {
        //Buscando o procedimento no banco de dados para editá-lo
        var contract = _contractRepository.SearcContractForId(id);

        if(contract is null)
        {
            return null;
        }

        //Copiando os dados da requisição para o modelo
        contract.DataTermino = contractEdited.DataTermino;
        contract.TipoContrato = contractEdited.TipoContrato;
        contract.ConsumoContrato = contractEdited.ConsumoContrato;
        contract.StatusContrato = contractEdited.StatusContrato;


        //Regrad de negócio
        //

        //Salvando no banco de dados
        _contractRepository.UpdateContract();

        //Copiando os dados do modelo para a resposta
        var responseContract = ConvertModelToResponse(contract);

        return responseContract;

    }

    private ResponseContract ConvertModelToResponse(Contrato model)
    {
        var responseContract = new ResponseContract();
        responseContract.Id = model.Id;
        responseContract.StatusContrato = model.StatusContrato;
        responseContract.ConsumoContrato = model.ConsumoContrato;
        responseContract.TipoContrato = model.TipoContrato;
        responseContract.DataTermino = model.DataTermino;;

        return responseContract;
    }
}