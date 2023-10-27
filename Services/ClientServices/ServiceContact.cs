using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apicemig.Models.DadosCliente;
using apigerenciamentocontrato.Data.DTOs.Contact;
using apigerenciamentocontrato.Data.DTOs.Contact.Response;
using apigerenciamentocontrato.Repository.ClientRepository;
using Microsoft.AspNetCore.Mvc;

namespace apigerenciamentocontrato.Services.ClientServices;

public class ServiceContact
{
    private ContactRepository _contactRepository;

    public ServiceContact([FromBody] ContactRepository contact)
    {
        _contactRepository = contact;
    }
    public ResponseContact CreateContact(CreateContact newContact)
    {
        //Converte DTO para o modelo 
        //Encaminha para o repositório salvar o BD

        Contato contato = new();
        contato.Email = newContact.Email;
        contato.Telefone = newContact.Telefone;

        _contactRepository.CreateContact(contato);

        var responseContact = ConvertModelToResponse(contato);

        return responseContact;

    }

        public List<ResponseContact> ListContacts()
    {
        //Solicitando ao repositório os procedimentos
        var contact = _contactRepository.ListContacts();
        
        //Copiando os dados dos modelos para as respostas
        List<ResponseContact> responseContacts = new();

        foreach(var contato in contact)
        {
            var responseContact = ConvertModelToResponse(contato);

            responseContacts.Add(responseContact);

        }
            return responseContacts;
    }

    public ResponseContact SearcContactForId(int id)
    {
        //Solicita ao repositório buscar por id
        var contact =  _contactRepository.SearcContactForId(id);

        if(contact is null)
        {
            return null;
        }

        //Copiando o modelo para resposta
        var responseContact = ConvertModelToResponse(contact);

        return responseContact;
    }

    public void RemoveContact(int id)
    {
        //Regra de negocio
        //

        //Buscando o procedimento no banco de dados
        var contact = _contactRepository.SearcContactForId(id);

        if(contact is null)
        {
            return;
        }

        //Solicitando que o repositório remova
        _contactRepository.RemoveContact(contact);
    }

    public ResponseContact UpdateContact(int id, CreateContact contactEdited)
    {
        //Buscando o procedimento no banco de dados para editá-lo
        var contact = _contactRepository.SearcContactForId(id);

        if(contact is null)
        {
            return null;
        }

        //Copiando os dados da requisição para o modelo
        contact.Email = contactEdited.Email;
        contact.Telefone = contactEdited.Telefone;

        //Regrad de negócio
        //

        //Salvando no banco de dados
        _contactRepository.UpdateContact();

        //Copiando os dados do modelo para a resposta
        var responseContact = ConvertModelToResponse(contact);

        return responseContact;

    }

    private ResponseContact ConvertModelToResponse(Contato model)
    {
            var responseContact = new ResponseContact();
            responseContact.Id = model.Id;
            responseContact.Email = model.Email;
            responseContact.Telefone = model.Telefone;

            return responseContact;
    }
}