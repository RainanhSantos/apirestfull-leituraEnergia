using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apigerenciamentocontrato.Data.DTOs.EnergyMeters;
using apigerenciamentocontrato.Services.ContractServices;
using Microsoft.AspNetCore.Mvc;

namespace apigerenciamentocontrato.Controllers.Contracts;

[ApiController]
[Route("energymeters")]
public class EnergyMetersController : ControllerBase
{
    //Campo injetado no construtor
    //Vai armazenar o client que vai ser usado pelo controlador
    private ServiceEnergyMeters _serviceEnergyMeters;

    public EnergyMetersController([FromBody] ServiceEnergyMeters energyMeters)
    {
        _serviceEnergyMeters = energyMeters;
    }
    //Metodo para inserir dados
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public void CreateClient([FromBody] CreateEnergyMeters newEnergyMeters)
    {
        //Enviando os dados para a camada de serviço
        _serviceEnergyMeters.CreateEnergyMeters(newEnergyMeters);
    }
}