using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apicemig.Models.DadosContrato
{
    public class Leitura
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "A data da leitura é obrigatório")]
        public DateTime DataLeitura { get; set; }

        [Required(ErrorMessage = "O valor da leitura é obrigatório")]
        public int ValorLeitura { get; set; }

        [Required]
        public int MedidorId { get; set; }
        public virtual Medidor Medidor { get; set; }

    }
}