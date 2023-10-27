using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apigerenciamentocontrato.Data.DTOs.Contact
{
    public class CreateContact
    {
    [Required(ErrorMessage = "O telefone é obrigatório")]
    [MaxLength(11, ErrorMessage = "Número de telefone inválido")]
    public int Telefone { get; set; }

    [Required(ErrorMessage = "O E-mail é obrigatório")]
    [MaxLength(40, ErrorMessage = "Limite de caracteres excedido")]
    public string Email { get; set; }
    }
}