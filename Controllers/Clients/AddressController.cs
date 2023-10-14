using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apigerenciamentocontrato.Data.DTOs.Address;
using apigerenciamentocontrato.Services.ClientService;
using Microsoft.AspNetCore.Mvc;

namespace apigerenciamentocontrato.Controllers.Clients;

[ApiController]
[Route("address")]
public class AddressController : ControllerBase
{
   //Campo injetado no construtor
   //Vai armazenar o client que vai ser usado pelo controlador
     private ServiceAddress _serviceEndress;

     public AddressController([FromBody] ServiceAddress address)
     {
          _serviceEndress = address;
     }
    //Metodo para inserir dados
    /// <response code="201">Caso inserção seja feita com sucesso</response>
   [HttpPost]
   [ProducesResponseType(StatusCodes.Status201Created)]
   public void CreateAddress([FromBody] CreateAddress newAddress)
   {
        //Enviando os dados para a camada de serviço
        _serviceEndress.CreateAddress(newAddress);
   }
}
