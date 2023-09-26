using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apicemig.Models.DadosCliente;

public class Endereco
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O número da casa é obrigatório")]
    public int NumeroCasa { get; set; }

    [Required(ErrorMessage = "O CEP é obrigatório")]
    [MaxLength(8, ErrorMessage = "o CEP é inválido")]
    public int Cep { get; set; }

    [Required]
    public int ClienteId { get; set; }
    public virtual Cliente Cliente { get; set; }
    public virtual ICollection<Contato> Contato { get; set; }

    
}