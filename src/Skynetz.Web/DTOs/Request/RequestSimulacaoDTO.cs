using Newtonsoft.Json;
using Skynetz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skynetz.Web.DTOs
{
    public class RequestSimulacaoDTO
    {
        public RequestSimulacaoDTO() { }

        public RequestSimulacaoDTO(int _quantMinutos, int _tarifaId, int _planoId) {
            quantMinutos = _quantMinutos;
            tarifaId = _tarifaId;
            planoId = _planoId;
            ValidacaoDTO();
        }

        [JsonProperty("quantMinutos")]
        public int quantMinutos { get; set; }
        
        [JsonProperty("tarifaId")]
        public int tarifaId { get; set; }
        
        [JsonProperty("planoId")] 
        public int planoId { get; set; }

        public void ValidacaoDTO()
        {
            if (quantMinutos == default) throw new Exception("Informe uma quantidade valida de minutos.");
            if (tarifaId == default) throw new Exception("Informe um Id de Tarifa válido");
            if (planoId == default) throw new Exception("Informe um Id de Plano válido");
        }
    }

}
