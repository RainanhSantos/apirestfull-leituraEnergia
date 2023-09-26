using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apicemig.Models.DadosContrato
{
    public class Medidor
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O número de série é obrigatório")]
        public int NumeroSerie { get; set; }

        [Required(ErrorMessage = "O tipo do medidor é obrigatório")]
        public String? TipoMedidor { get; set; }

        [Required(ErrorMessage = "A data de instalação é obrigatória")]
        public DateTime DataInstalacao { get; set; }

        [Required(ErrorMessage = "A quantidade de leituras é obrigatória")]
        public int Leituras { get; set; }
        
        public virtual Contrato Contrato { get; set; }
        public virtual ICollection<Leitura> Leitura { get; set; }
    }
}