using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apicemig.Models.DadosContrato;
using apigerenciamentocontrato.Data.DTOs.Payment;
using apigerenciamentocontrato.Data.DTOs.Payment.Response;
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
    public ResponsePayment CreatePayment(CreatePayment newPayment)
    {
        //Converte DTO para o modelo Client
        //Encaminha para o repositório salvar o BD
        Pagamento pagamento = new();
        pagamento.ValorPago = newPayment.ValorPago;

        var dataPagamento = DateTime.Now;
        pagamento.DataPagamento = dataPagamento;

        _paymentRepository.CreatePayment(pagamento);

        var responsePayment = ConvertModelToResponse(pagamento);

        return responsePayment;
    }

        public List<ResponsePayment> ListPayments()
    {
        //Solicitando ao repositório os procedimentos
        var payment = _paymentRepository.ListPayments();
        
        //Copiando os dados dos modelos para as respostas
        List<ResponsePayment> responsePayments = new();

        foreach(var pagamento in payment)
        {

        var responsePayment = ConvertModelToResponse(pagamento);

        responsePayments.Add(responsePayment);

        }
            return responsePayments;
    }

    public ResponsePayment SearcPaymentForId(int id)
    {
        //Solicita ao repositório buscar por id
        var payment =  _paymentRepository.SearcPaymentForId(id);

        if(payment is null)
        {
            return null;
        }

        //Copiando o modelo para resposta
        var responsePayment = ConvertModelToResponse(payment);

        return responsePayment;
    }

    public void RemovePayment(int id)
    {
        //Regra de negocio
        //

        //Buscando o procedimento no banco de dados
        var payment = _paymentRepository.SearcPaymentForId(id);

        if(payment is null)
        {
            return;
        }

        //Solicitando que o repositório remova
        _paymentRepository.RemovePayment(payment);
    }

        public ResponsePayment UpdatePayment(int id, CreatePayment paymentEdited)
            {
                //Buscando o procedimento no banco de dados para editá-lo
                var payment = _paymentRepository.SearcPaymentForId(id);

                if(payment is null)
                {
                    return null;
                }

                //Copiando os dados da requisição para o modelo
                payment.ValorPago = paymentEdited.ValorPago;


                //Regrad de negócio
                //

                //Salvando no banco de dados
                _paymentRepository.UpdatePayment();

                //Copiando os dados do modelo para a resposta
                var responsePayment = ConvertModelToResponse(payment);

                return responsePayment;

            }

    private ResponsePayment ConvertModelToResponse(Pagamento model)
    {
        var responsePayment = new ResponsePayment();
        responsePayment.Id = model.Id;
        responsePayment.ValorPago = model.ValorPago;

        return responsePayment;
    }
}