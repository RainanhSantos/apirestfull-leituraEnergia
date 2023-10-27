using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apigerenciamentocontrato.Data.DTOs.Procedure
{
    public class UpdateClient
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        [MaxLength(60, ErrorMessage = "Limite de caracteres excedido")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório")]
        [MaxLength(11, ErrorMessage = "O CPF é inválido")]
        public int Cpf { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatório")]
        public DateTime DataNascimento { get; set; }
    }
}