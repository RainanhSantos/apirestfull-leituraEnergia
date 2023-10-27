using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apicemig.Models.DadosCliente;
using apigerenciamentocontrato.Data.DTOs.Address;
using apigerenciamentocontrato.Data.DTOs.Address.Response;
using apigerenciamentocontrato.Repository.ClientRepository;
using Microsoft.AspNetCore.Mvc;

namespace apigerenciamentocontrato.Services.ClientService;

public class ServiceAddress
{
    private AddressRepository _addressRepository;

    public ServiceAddress([FromServices] AddressRepository address)
    {
        _addressRepository = address;
    }
    public ResponseAddress CreateAddress(CreateAddress newAddress)
    {
        //Converte DTO para o modelo 
        //Encaminha para o repositório salvar o BD

            //Transformando de DTO para Modelo
            //Copia os dados da requisição para o modelo
            Endereco endereco = new();
            endereco.Cep = newAddress.Cep;
            endereco.NumeroCasa = newAddress.NumeroCasa;

            _addressRepository.CreateAddress(endereco);

        //Copiando os dados do modelo para a resposta
        var responseAddress = ConvertModelToResponse(endereco);

        return responseAddress;
    }

    public List<ResponseAddress> ListAddress()
    {
        //Solicitando ao repositório os procedimentos
        var address = _addressRepository.ListAdresses();
        
        //Copiando os dados dos modelos para as respostas
        List<ResponseAddress> responseAddresses = new();

        foreach(var endereco in address)
        {
            var responseAddress = ConvertModelToResponse(endereco);
            
            responseAddresses.Add(responseAddress);

        }
            return responseAddresses;
    }

 public ResponseAddress SearcAddressForId(int id)
    {
        //Solicita ao repositório buscar por id
        var address =  _addressRepository.SearcAddressForId(id);

        if(address is null)
        {
            return null;
        }

        //Copiando o modelo para resposta
        var responseAddress = ConvertModelToResponse(address);

        return responseAddress;
    }

    public void RemoveAddress(int id)
    {
        //Regra de negocio
        //

        //Buscando o procedimento no banco de dados
        var address = _addressRepository.SearcAddressForId(id);

        if(address is null)
        {
            return;
        }

        //Solicitando que o repositório remova
        _addressRepository.RemoveAddress(address);
    }

    public ResponseAddress UpdateAddress(int id, CreateAddress addressEdited)
    {
        //Buscando o procedimento no banco de dados para editá-lo
        var address = _addressRepository.SearcAddressForId(id);

        if(address is null)
        {
            return null;
        }

        //Copiando os dados da requisição para o modelo
        address.NumeroCasa = addressEdited.NumeroCasa;
        address.Cep = addressEdited.Cep;

        //Regrad de negócio
        //

        //Salvando no banco de dados
        _addressRepository.UpdateAddress();

        //Copiando os dados do modelo para a resposta
        var responseAddress = ConvertModelToResponse(address);

        return responseAddress;

    }

    private ResponseAddress ConvertModelToResponse(Endereco model)
    {
        var responseAddress = new ResponseAddress();
        responseAddress.Id = model.Id;
        responseAddress.Cep = model.Cep;
        responseAddress.NumeroCasa = model.NumeroCasa;

            return responseAddress;
    }
}