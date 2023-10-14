using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apigerenciamentocontrato.Data.DTOs.Payment;
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
    public void CreateClient([FromBody] CreatePayment newPayment)
    {
        //Enviando os dados para a camada de serviço
        
    }
}