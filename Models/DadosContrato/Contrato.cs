using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apicemig.Models.DadosContrato
{
    public class Contrato
    {
        [Key]
        [Required]
        public int MyProperty { get; set; }

        [Required(ErrorMessage = "A data de início é obrigatório")]
        public DateTime DataInicio { get; set; }
        
        [Required(ErrorMessage = "A data de termino é obrigatório")]
        public DateTime DataTermino { get; set; }

        [Required(ErrorMessage = "O tipo do contrato é obrigatório")]
        public string? TipoContrato { get; set; }

        [Required(ErrorMessage = "O consumo previsto em contrato é obrigatório")]
        public int ConsumoContrato { get; set; }

        [Required(ErrorMessage = "O status do contrato é obrigatório")]
        [MaxLength(9, ErrorMessage = "Limite de caracteres excedido")]
        public string? StatusContrato { get; set; }

         public int MedidorId { get; set; }
        //Informa que a entidade cinema possui uma relação 1-1
        public virtual Medidor Medidor { get; set; }
        
        [Required]
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<Fatura> Fatura { get; set; }
    }
}