using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apigerenciamentocontrato.Data.DTOs.Contact;
using apigerenciamentocontrato.Data.DTOs.Contact.Response;
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
    public ResponseContact CreateClient([FromBody] CreateContact newContact)
    {
            //Enviando os dados para a camada de serviço
            var responseContact = _serviceContact.CreateContact(newContact);

            return responseContact;
    }

   [HttpGet]
   public List<ResponseContact> GetResponseContacts()
   {
      return _serviceContact.ListContacts();
   }

   [HttpGet("{id:int}")]
   public ResponseContact GetContact([FromRoute] int id)
   {
      //Solicitando ao serviço que busque um cliente pelo id e realizando o retorno
      return _serviceContact.SearcContactForId(id);
   }

   [HttpDelete("{id:int}")]
   public void DeleteContact ([FromRoute] int id)
   {
      //Mandando o serviço excluir
      _serviceContact.RemoveContact(id);
   }

   [HttpPut("{id:int}")]
   public ResponseContact PutContact([FromRoute] int id, [FromBody] CreateContact contactEdited)
   {
      //Enviando para o serviço editar
      var responseContact = _serviceContact.UpdateContact(id, contactEdited);

      return responseContact;
   }
}