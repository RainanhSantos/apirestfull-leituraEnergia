using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apigerenciamentocontrato.Data.DTOs.Procedure
{
    public class ReadClient
    {
        public string? Nome { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}