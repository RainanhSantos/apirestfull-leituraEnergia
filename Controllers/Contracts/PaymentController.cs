using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apigerenciamentocontrato.Data.DTOs.Payment;
using apigerenciamentocontrato.Data.DTOs.Payment.Response;
using apigerenciamentocontrato.Services.ContractServices;
using Microsoft.AspNetCore.Mvc;

namespace apigerenciamentocontrato.Controllers.Contracts;

[ApiController]
[Route("payment")]
public class PaymentController
{
   //Campo injetado no construtor
   //Vai armazenar o client que vai ser usado pelo controlador
   private ServicePayment _servicePayment;

   public PaymentController([FromBody] ServicePayment payment)
   {
    _servicePayment = payment;
   }
    //Metodo para inserir dados
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public ResponsePayment CreateClient([FromBody] CreatePayment newPayment)
    {
        //Enviando os dados para a camada de serviço
        var responsePayment = _servicePayment.CreatePayment(newPayment);

        return responsePayment;
    }

   [HttpGet]
   public List<ResponsePayment> GetResponsePayments()
   {
      return _servicePayment.ListPayments();
   }

   [HttpGet("{id:int}")]
   public ResponsePayment GetPayment([FromRoute] int id)
   {
      //Solicitando ao serviço que busque um cliente pelo id e realizando o retorno
      return _servicePayment.SearcPaymentForId(id);
   }

   [HttpDelete("{id:int}")]
   public void DeletePayment ([FromRoute] int id)
   {
      //Mandando o serviço excluir
      _servicePayment.RemovePayment(id);
   }

}