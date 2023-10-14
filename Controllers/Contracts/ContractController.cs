using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apigerenciamentocontrato.Data.DTOs.Contract;
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
    public void CreateContract([FromBody] CreateContract newContract)
    {
        _serviceContract.CreateContract(newContract);
    }
}