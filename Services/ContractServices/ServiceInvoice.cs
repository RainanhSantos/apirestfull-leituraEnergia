using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apicemig.Models.DadosContrato;
using apigerenciamentocontrato.Data.DTOs.Invoice;
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
    public void CreateInvoice(CreateInvoice newInvoice)
    {
        //Converte DTO para o modelo Client
        //Encaminha para o repositório salvar o BD
        Fatura fatura = new();
        fatura.ValorTotal = newInvoice.ValorTotal;
        fatura.StatusFatura = newInvoice.StatusFatura;

        var dataEmissao = DateTime.Now;
        var dataVencimento = dataEmissao.AddMonths(1);
        fatura.DataEmissao = dataEmissao;
        fatura.DataVencimento = dataVencimento;

        _invoiceRepository.CreateInvoice(fatura);
    }
}