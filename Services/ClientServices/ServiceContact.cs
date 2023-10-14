using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apicemig.Models.DadosCliente;
using apigerenciamentocontrato.Data.DTOs.Contact;
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
    public void CreateContact(CreateContact newContact)
    {
        //Converte DTO para o modelo 
        //Encaminha para o repositório salvar o BD

        Contato contato = new();
        contato.Email = newContact.Email;
        contato.Telefone = newContact.Telefone;

        _contactRepository.CreateContact(contato);

    }
}