using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apigerenciamentocontrato.Data.DTOs.Reading
{
    public class CreateReading
    {
        // [Required(ErrorMessage = "A data da leitura é obrigatório")]
        // public DateTime DataLeitura { get; set; }

        [Required(ErrorMessage = "O valor da leitura é obrigatório")]
        public int ValorLeitura { get; set; }
    }
}