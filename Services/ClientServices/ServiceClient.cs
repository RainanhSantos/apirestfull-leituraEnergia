using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using apicemig.Models;
using apigerenciamentocontrato.Data.DTOs.Procedure;
using apigerenciamentocontrato.Repository;
using apigerenciamentocontrato.Repository.ClientRepository;
using Microsoft.AspNetCore.Mvc;


namespace apigerenciamentocontrato.Services;

public class ServiceClient
{

    private ClientRepository _clientRepository;

    //Contrutor com injeção de dependência
    public ServiceClient([FromServices] ClientRepository cliente)
    {
        _clientRepository = cliente;
    }
    public void CreateClient(CreateClient newClient)
    {

        //Transformando de DTO para Modelo
        //Copia os dados da requisição para o modelo
        Cliente cliente = new();
        cliente.Nome = newClient.Nome;
        cliente.Cpf = newClient.Cpf;
        cliente.DataNascimento = newClient.DataNascimento;

        //Enviar par ao repositório salvar no BD
        _clientRepository.CreateClient(cliente);
    }
}