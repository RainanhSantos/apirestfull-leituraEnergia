using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apigerenciamentocontrato.Data.DTOs.Reading;
using apigerenciamentocontrato.Services.ContractServices;
using Microsoft.AspNetCore.Mvc;

namespace apigerenciamentocontrato.Controllers.Contracts;

[ApiController]
[Route("reading")]
public class ReadingController
{
    //Campo injetado no construtor
    //Vai armazenar o client que vai ser usado pelo controlador
    private ServicesReading _serviceReading;

    public ReadingController([FromBody] ServicesReading reading)
    {
    _serviceReading = reading;
    }
    //Metodo para inserir dados
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public void CreateClient([FromBody] CreateReading newReading)
    {
        //Enviando os dados para a camada de serviço
        _serviceReading.CreateReading(newReading);
    }   
}