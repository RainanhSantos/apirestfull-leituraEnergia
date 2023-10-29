using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apigerenciamentocontrato.Data.DTOs.Reading;
using apigerenciamentocontrato.Data.DTOs.Reading.Response;
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
    public ResponseReading CreateClient([FromBody] CreateReading newReading)
    {
        //Enviando os dados para a camada de serviço
        var responseReading = _serviceReading.CreateReading(newReading);

        return responseReading;
    }

   [HttpGet]
   public List<ResponseReading> GetResponseReadings()
   {
      return _serviceReading.ListReading();
   }

   [HttpGet("{id:int}")]
   public ResponseReading GetReading([FromRoute] int id)
   {
      //Solicitando ao serviço que busque um cliente pelo id e realizando o retorno
      return _serviceReading.SearcReadingForId(id);
   }

   [HttpDelete("{id:int}")]
   public void DeleteReading ([FromRoute] int id)
   {
      //Mandando o serviço excluir
      _serviceReading.RemoveReading(id);
   }

   [HttpPut("{id:int}")]
   public ResponseReading PutReading([FromRoute] int id, [FromBody] CreateReading readingEdited)
   {
      //Enviando para o serviço editar
      var responseReading = _serviceReading.UpdateReading(id, readingEdited);

      return responseReading;
   }
}