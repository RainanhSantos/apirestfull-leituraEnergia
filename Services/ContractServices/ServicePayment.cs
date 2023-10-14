using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apicemig.Models.DadosContrato;
using apigerenciamentocontrato.Data.DTOs.Payment;
using apigerenciamentocontrato.Repository.ContractRepository;
using Microsoft.AspNetCore.Mvc;

namespace apigerenciamentocontrato.Services.ContractServices;

public class ServicePayment
{
    private PaymentRepository _paymentRepository;

    public ServicePayment([FromServices] PaymentRepository repository)
    {
        _paymentRepository = repository;
    }
    public void CreatePayment(CreatePayment newPayment)
    {
        //Converte DTO para o modelo Client
        //Encaminha para o repositório salvar o BD
        Pagamento pagamento = new();
        pagamento.ValorPago = newPayment.ValorPago;

        var dataPagamento = DateTime.Now;
        pagamento.DataPagamento = dataPagamento;

        _paymentRepository.CreatePayment(pagamento);
    }
}