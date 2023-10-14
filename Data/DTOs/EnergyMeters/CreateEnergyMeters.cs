using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apigerenciamentocontrato.Data.DTOs.EnergyMeters
{
    public class CreateEnergyMeters
    {
        [Required(ErrorMessage = "O número de série é obrigatório")]
        public int NumeroSerie { get; set; }

        [Required(ErrorMessage = "O tipo do medidor é obrigatório")]
        public String? TipoMedidor { get; set; }

        // [Required(ErrorMessage = "A data de instalação é obrigatória")]
        // public DateTime DataInstalacao { get; set; }

        [Required(ErrorMessage = "A quantidade de leituras é obrigatória")]
        public int Leituras { get; set; }
    }
}