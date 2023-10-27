using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apicemig.Models.DadosCliente;

public class Contato
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O telefone é obrigatório")]
    [MaxLength(11, ErrorMessage = "Número de telefone inválido")]
    public int Telefone { get; set; }

    [Required(ErrorMessage = "O E-mail é obrigatório")]
    [MaxLength(40, ErrorMessage = "Limite de caracteres excedido")]
    public string Email { get; set; }
    
    [Required]
    public int EnderecoId { get; set; }
    public virtual Endereco Endereco { get; set; }
}