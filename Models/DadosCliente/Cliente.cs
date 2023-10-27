using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using apicemig.Models.DadosCliente;
using apicemig.Models.DadosContrato;

namespace apicemig.Models
{
    public class Cliente
    {
        [Key]
        [Required]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "O nome é obrigatório")]
        [MaxLength(60, ErrorMessage = "Limite de caracteres excedido")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório")]
        [MaxLength(11, ErrorMessage = "O CPF é inválido")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatório")]
        public DateTime DataNascimento { get; set; }
        public virtual ICollection<Endereco> Endereco { get; set; }
        public virtual ICollection<Contrato> Contrato { get; set; }
        
    }
}