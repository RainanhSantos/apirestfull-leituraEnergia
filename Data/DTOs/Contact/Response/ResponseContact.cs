using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apigerenciamentocontrato.Data.DTOs.Contact.Response;

public class ResponseContact
{
    public int Id { get; set; }
    public int Telefone { get; set; }
    public string Email { get; set; }
}