using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apigerenciamentocontrato.Data.DTOs.Contract.Response;

public class ResponseContract
{
        public int Id { get; set; }
        public DateTime DataTermino { get; set; }
        public string TipoContrato { get; set; }
        public int ConsumoContrato { get; set; }
        public string StatusContrato { get; set; }
}