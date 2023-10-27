using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apigerenciamentocontrato.Data.DTOs.Address.Response;

public class ResponseAddress
{
        public int Id { get; set; }
    public int NumeroCasa { get; set; }
    public int Cep { get; set; }
}