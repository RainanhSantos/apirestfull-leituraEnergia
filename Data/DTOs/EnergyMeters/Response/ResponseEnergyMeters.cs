using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apigerenciamentocontrato.Data.DTOs.EnergyMeters.Response;

public class ResponseEnergyMeters
{
        public int Id { get; set; }
        public int NumeroSerie { get; set; }
        public String TipoMedidor { get; set; }
        public int Leituras { get; set; }
}