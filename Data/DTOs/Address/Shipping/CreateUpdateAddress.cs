using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apigerenciamentocontrato.Data.DTOs.Address
{
    public class CreateAddress
    {

    [Required(ErrorMessage = "O número da casa é obrigatório")]
    public int NumeroCasa { get; set; }

    [Required(ErrorMessage = "O CEP é obrigatório")]
    [MaxLength(8, ErrorMessage = "o CEP é inválido")]
    public int Cep { get; set; }
    
    }
}