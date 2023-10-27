using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apicemig.Models.DadosContrato;
using apigerenciamentocontrato.Data.DTOs.Invoice;
using apigerenciamentocontrato.Data.DTOs.Invoice.Response;
using apigerenciamentocontrato.Repository.ContractRepository;
using Microsoft.AspNetCore.Mvc;

namespace apigerenciamentocontrato.Services.ContractServices;

public class ServiceInvoice
{
    private InvoiceRepository _invoiceRepository;

    public ServiceInvoice([FromServices] InvoiceRepository invoice)
    {
        _invoiceRepository = invoice;
    }
    public ResponseInvoice CreateInvoice(CreateInvoice newInvoice)
    {
        //Converte DTO para o modelo Client
        //Encaminha para o repositório salvar o BD
        Fatura fatura = new();
        fatura.ValorTotal = newInvoice.ValorTotal;
        fatura.StatusFatura = newInvoice.StatusFatura;

        var dataEmissao = DateTime.Now;
        var dataVencimento = dataEmissao.AddMonths(1);

        _invoiceRepository.CreateInvoice(fatura);

        var responseInvoice = ConvertModelToResponse(fatura);

        return responseInvoice;
    }

        public List<ResponseInvoice> ListEnergyMeters()
    {
        //Solicitando ao repositório os procedimentos
        var invoice = _invoiceRepository.ListInvoices();
        
        //Copiando os dados dos modelos para as respostas
        List<ResponseInvoice> responseInvoices = new();

        foreach(var fatura in invoice)
        {

            var responseInvoice = ConvertModelToResponse(fatura);

            responseInvoices.Add(responseInvoice);

        }
            return responseInvoices;
    }

    public ResponseInvoice SearcInvoiceForId(int id)
    {
        //Solicita ao repositório buscar por id
        var invoice =  _invoiceRepository.SearcInvoiceForId(id);

        if(invoice is null)
        {
            return null;
        }

        //Copiando o modelo para resposta
        var responseInvoice = ConvertModelToResponse(invoice);

        return responseInvoice;
    }

    public void RemoveInvoice(int id)
    {
        //Regra de negocio
        //

        //Buscando o procedimento no banco de dados
        var invoice = _invoiceRepository.SearcInvoiceForId(id);

        if(invoice is null)
        {
            return;
        }

        //Solicitando que o repositório remova
        _invoiceRepository.RemoveInvoice(invoice);
    }

    public ResponseInvoice UpdateInvoice(int id, CreateInvoice invoiceEdited)
        {
            //Buscando o procedimento no banco de dados para editá-lo
            var invoice = _invoiceRepository.SearcInvoiceForId(id);

            if(invoice is null)
            {
                return null;
            }

            //Copiando os dados da requisição para o modelo
            invoice.ValorTotal = invoiceEdited.ValorTotal;
            invoice.StatusFatura = invoiceEdited.StatusFatura;


            //Regrad de negócio
            //

            //Salvando no banco de dados
            _invoiceRepository.UpdateInvoice();

            //Copiando os dados do modelo para a resposta
            var responseInvoice = ConvertModelToResponse(invoice);

            return responseInvoice;

        }

    private ResponseInvoice ConvertModelToResponse(Fatura model)
    {
        var responseInvoice = new ResponseInvoice();
        responseInvoice.Id = model.Id;
        responseInvoice.StatusFatura = model.StatusFatura;
        responseInvoice.ValorTotal = model.ValorTotal;

        return responseInvoice;
    }
}