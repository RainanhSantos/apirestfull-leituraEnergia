using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apicemig.Data;
using apicemig.Models;
using apigerenciamentocontrato.Data.DTOs.Procedure;
using apigerenciamentocontrato.Services;
using Microsoft.AspNetCore.Mvc;

namespace apicemig.Controllers;

[Controller]
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
   public void CreateClient([FromBody] CreateClient newClient)
   {
      _serviceClient.CreateClient(newClient);
   }
}