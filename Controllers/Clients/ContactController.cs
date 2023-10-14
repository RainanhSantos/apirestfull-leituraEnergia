using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apigerenciamentocontrato.Data.DTOs.Contact;
using apigerenciamentocontrato.Services.ClientServices;
using Microsoft.AspNetCore.Mvc;

namespace apigerenciamentocontrato.Controllers.Clients;

[ApiController]
[Route("contact")]
public class ContactController : ControllerBase
{
   //Campo injetado no construtor
   //Vai armazenar o client que vai ser usado pelo controlador
    private ServiceContact _serviceContact;

    public ContactController([FromBody] ServiceContact contact)
    {
        _serviceContact = contact;
    }
        //Metodo para inserir dados
        /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public void CreateClient([FromBody] CreateContact newContact)
    {
            //Enviando os dados para a camada de serviço
            _serviceContact.CreateContact(newContact);
    }
}