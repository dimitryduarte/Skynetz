using Skynetz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skynetz.Web.DTOs
{
    public class SimulacaoRequestDTO
    {
        public List<Tarifa> Tarifas { get; set; }

        public List<Plano> Planos { get; set; }

        public int Minutos { get; set; }
    }
}
