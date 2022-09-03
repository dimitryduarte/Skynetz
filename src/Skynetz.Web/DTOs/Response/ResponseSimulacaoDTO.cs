using Newtonsoft.Json;
using Skynetz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skynetz.Web.DTOs
{
    public class ResponseSimulacaoDTO
    {
        [JsonProperty("valorComPlano")]
        public string valorComPlano { get; set; }

        [JsonProperty("valorSemPlano")] 
        public string valorSemPlano { get; set; }
    }
}
