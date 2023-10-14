using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apicemig.Models.DadosCliente;
using apigerenciamentocontrato.Data.DTOs.Address;
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
    public void CreateAddress(CreateAddress newAddress)
    {
        //Converte DTO para o modelo 
        //Encaminha para o repositório salvar o BD

            //Transformando de DTO para Modelo
            //Copia os dados da requisição para o modelo
            Endereco endereco = new();
            endereco.Cep = newAddress.Cep;
            endereco.NumeroCasa = newAddress.NumeroCasa;

            _addressRepository.CreateAddress(endereco);
    }
}