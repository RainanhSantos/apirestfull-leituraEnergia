using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apicemig.Data;
using apicemig.Models;
using apigerenciamentocontrato.Data.DTOs.Client.response;
using apigerenciamentocontrato.Data.DTOs.Procedure;
using apigerenciamentocontrato.Services;
using Microsoft.AspNetCore.Mvc;

namespace apicemig.Controllers;

[ApiController]
[Route("cliente")]
public class ClientController : ControllerBase
{

   //Campo injetado no construtor
   //Vai armazenar o client que vai ser usado pelo controlador
   private ServiceClient _serviceClient;
   
   public ClientController([FromBody] ServiceClient client)
   {
      _serviceClient = client;
   }
   
    //Metodo para inserir dados
        /// <response code="201">Caso inserção seja feita com sucesso</response>
   [HttpPost]
   [ProducesResponseType(StatusCodes.Status201Created)]
   public ResponseClient CreateClient([FromBody] CreateClient newClient)
   {
      return  _serviceClient.CreateClient(newClient);
   }

   [HttpGet]
   public List<ResponseClient> GetResponseClients()
   {
      return _serviceClient.ListClients();
   }

   [HttpGet("{id:int}")]
   public ResponseClient GetClient([FromRoute] int id)
   {
      //Solicitando ao serviço que busque um cliente pelo id e realizando o retorno
      return _serviceClient.SearcCLientForId(id);
   }

   [HttpDelete("{id:int}")]
   public void DeleteClient ([FromRoute] int id)
   {
      //Mandando o serviço excluir
      _serviceClient.RemoveClient(id);
   }

   [HttpPut("{id:int}")]
   public ResponseClient PutClient([FromRoute] int id, [FromBody] CreateClient clientEdited)
   {
      //Enviando para o serviço editar
      var ResponseClient = _serviceClient.UpdateClient(id, clientEdited);

      return ResponseClient;
   }
}