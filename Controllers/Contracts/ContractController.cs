using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apigerenciamentocontrato.Data.DTOs.Contract;
using apigerenciamentocontrato.Data.DTOs.Contract.Response;
using apigerenciamentocontrato.Services.ContractServices;
using Microsoft.AspNetCore.Mvc;

namespace apigerenciamentocontrato.Controllers.Contracts;

[ApiController]
[Route("contract")]
public class ContractController : ControllerBase
{
    //Campo injetado no construtor
    //Vai armazenar o client que vai ser usado pelo controlador
    private ServiceContract _serviceContract;

    public ContractController([FromBody] ServiceContract contract)
    {
        _serviceContract = contract;
    }
    //Metodo para inserir dados
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public ResponseContract CreateContract([FromBody] CreateContract newContract)
    {
        var responseContract = _serviceContract.CreateContract(newContract);

        return responseContract;
    }

   [HttpGet]
   public List<ResponseContract> GetResponseContracts()
   {
      return _serviceContract.ListContracts();
   }

   [HttpGet("{id:int}")]
   public ResponseContract GetContract([FromRoute] int id)
   {
      //Solicitando ao serviço que busque um cliente pelo id e realizando o retorno
      return _serviceContract.SearcContractForId(id);
   }

   [HttpDelete("{id:int}")]
   public void DeleteContract ([FromRoute] int id)
   {
      //Mandando o serviço excluir
      _serviceContract.RemoveContract(id);
   }

   [HttpPut("{id:int}")]
   public ResponseContract PutContract([FromRoute] int id, [FromBody] CreateContract contractEdited)
   {
      //Enviando para o serviço editar
      var responseContract = _serviceContract.UpdateContract(id, contractEdited);

      return responseContract;
   }
}