using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apigerenciamentocontrato.Data.DTOs.Invoice;
using apigerenciamentocontrato.Data.DTOs.Invoice.Response;
using apigerenciamentocontrato.Services.ContractServices;
using Microsoft.AspNetCore.Mvc;

namespace apigerenciamentocontrato.Controllers.Contracts;

[ApiController]
[Route("invoice")]
public class InvoiceController
{
   //Campo injetado no construtor
   //Vai armazenar o client que vai ser usado pelo controlador
   private ServiceInvoice _serviceInvoice;

   public InvoiceController([FromBody] ServiceInvoice invoice)
   {
        _serviceInvoice = invoice;
   }
    //Metodo para inserir dados
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public ResponseInvoice CreateClient([FromBody] CreateInvoice newInvoice)
    {
        //Enviando os dados para a camada de serviço
        var responseInvoice = _serviceInvoice.CreateInvoice(newInvoice);

        return responseInvoice;
    }

   [HttpGet]
   public List<ResponseInvoice> GetResponseInvoices()
   {
      return _serviceInvoice.ListEnergyMeters();
   }

   [HttpGet("{id:int}")]
   public ResponseInvoice GetInvoice([FromRoute] int id)
   {
      //Solicitando ao serviço que busque um cliente pelo id e realizando o retorno
      return _serviceInvoice.SearcInvoiceForId(id);
   }

   [HttpDelete("{id:int}")]
   public void DeleteInvoice ([FromRoute] int id)
   {
      //Mandando o serviço excluir
      _serviceInvoice.RemoveInvoice(id);
   }

}