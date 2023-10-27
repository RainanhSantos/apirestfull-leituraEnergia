using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using apicemig.Models;
using apigerenciamentocontrato.Data.DTOs.Client.response;
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
    public ResponseClient CreateClient(CreateClient newClient)
    {
        //Transformando de DTO para Modelo
        //Copia os dados da requisição para o modelo
        Cliente cliente = new();
        cliente.Nome = newClient.Nome;
        cliente.Cpf = newClient.Cpf;
        cliente.DataNascimento = newClient.DataNascimento;
        //Enviar par ao repositório salvar no BD
        cliente = _clientRepository.CreateClient(cliente);

        //Copiando os dados do modelo para a resposta

        var responseClient = ConvertModelToResponse(cliente);

        return responseClient;
        
    }
    public List<ResponseClient> ListClients()
    {
        //Solicitando ao repositório os procedimentos
        var client = _clientRepository.ListCustomers();

        //Copiando os dados dos modelos para as respostas
        List<ResponseClient> responseClients = new();

        foreach(var cliente in client)
        {
            var responseClient =ConvertModelToResponse(cliente);

            responseClients.Add(responseClient);

        }
            return responseClients;
    }
    public ResponseClient SearcCLientForId(int id)
    {
        //Solicita ao repositório buscar por id
        var client =  _clientRepository.SearchClientForId(id);

        if(client is null)
        {
            return null;
        }

        //Copiando o modelo para resposta
        var responseClient = ConvertModelToResponse(client);

        return responseClient;
    }

    public void RemoveClient(int id)
    {
        //Regra de negocio
        //

        //Buscando o procedimento no banco de dados
        var client = _clientRepository.SearchClientForId(id);

        if(client is null)
        {
            return;
        }

        //Solicitando que o repositório remova
        _clientRepository.RemoveClient(client);
    }

    public ResponseClient UpdateClient(int id, CreateClient clientEdited)
    {
        //Buscando o procedimento no banco de dados para editá-lo
        var client = _clientRepository.SearchClientForId(id);

        if(client is null)
        {
            return null;
        }

        //Copiando os dados da requisição para o modelo
        client.Nome = clientEdited.Nome;
        client.Cpf = clientEdited.Cpf;
        client.DataNascimento = clientEdited.DataNascimento;

        //Regrad de negócio
        //

        //Salvando no banco de dados
        _clientRepository.UpdateClient();

        //Copiando os dados do modelo para a resposta
        var responseClient = ConvertModelToResponse(client);

        return responseClient;

    }

    private ResponseClient ConvertModelToResponse(Cliente model)
    {
            var responseClient = new ResponseClient();
            responseClient.Id = model.Id;
            responseClient.Nome = model.Nome;
            responseClient.DataNascimento = model.DataNascimento;

            return responseClient;
    }
}