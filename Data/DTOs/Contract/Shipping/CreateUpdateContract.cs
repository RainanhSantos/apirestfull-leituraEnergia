using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace apigerenciamentocontrato.Data.DTOs.Contract
{
    public class CreateContract
    {
        // [Required(ErrorMessage = "A data de início é obrigatório")]
        // public DateTime DataInicio { get; set; }
        
        [Required(ErrorMessage = "A data de termino é obrigatório")]
        public DateTime DataTermino { get; set; }

        [Required(ErrorMessage = "O tipo do contrato é obrigatório")]
        [Column(TypeName = "varchar(15)")]
        public string TipoContrato { get; set; }

        [Required(ErrorMessage = "O consumo previsto em contrato é obrigatório")]
        public int ConsumoContrato { get; set; }

        [Required(ErrorMessage = "O status do contrato é obrigatório")]
        [MaxLength(9, ErrorMessage = "Limite de caracteres excedido")]
        public string StatusContrato { get; set; }
    }
}