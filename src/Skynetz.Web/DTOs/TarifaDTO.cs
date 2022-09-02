using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skynetz.Web.DTOs
{
    public class TarifaDTO
    {
        public int Id { get; set; }

        public string Origem { get; set; }

        public string Destino { get; set; }

        public decimal TarifaMinuto { get; set; }
    }
}
