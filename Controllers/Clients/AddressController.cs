using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apigerenciamentocontrato.Data.DTOs.Address;
using apigerenciamentocontrato.Data.DTOs.Address.Response;
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
   public ResponseAddress CreateAddress([FromBody] CreateAddress newAddress)
   {
        //Enviando os dados para a camada de serviço
        var responseAddress = _serviceEndress.CreateAddress(newAddress);

        return responseAddress;
   }

   [HttpGet]
   public List<ResponseAddress> GetResponseAddresses()
   {
      return _serviceEndress.ListAddress();
   }

   [HttpGet("{id:int}")]
   public ResponseAddress GetAddress([FromRoute] int id)
   {
      //Solicitando ao serviço que busque um cliente pelo id e realizando o retorno
      return _serviceEndress.SearcAddressForId(id);
   }

   [HttpDelete("{id:int}")]
   public void DeleteAddress ([FromRoute] int id)
   {
      //Mandando o serviço excluir
      _serviceEndress.RemoveAddress(id);
   }

   [HttpPut("{id:int}")]
   public ResponseAddress PutAddress([FromRoute] int id, [FromBody] CreateAddress addressEdited)
   {
      //Enviando para o serviço editar
      var responseAddress = _serviceEndress.UpdateAddress(id, addressEdited);

      return responseAddress;
   }
}
