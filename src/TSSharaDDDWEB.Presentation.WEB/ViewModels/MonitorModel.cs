using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TSSharaDDDWEB.Presentation.WEB.ViewModels
{
    public class MonitorModel
    {
        // We declare Left and Top as lowercase with 
        // JsonProperty to sync the client and server models
        [JsonProperty("top")]
        public double Top { get; set; }

        [JsonProperty("left")]
        public double Left { get; set; }

        [JsonProperty("tensaoEntrada")]
        public double TensaoEntrada { get; set; }

        [JsonProperty("tensaoSaida")]
        public double TensaoSaida { get; set; }

        
        [JsonProperty("frequencia")]
        public double Frequencia { get; set; }

        [JsonProperty("bateria")]
        public double Bateria { get; set; }

        [JsonProperty("carga")]
        public double Carga { get; set; }

        [JsonProperty("temperatura")]
        public double Temperatura { get; set; }

        [JsonProperty("Email")]
        public double Email { get; set; }
        
        // We don't want the client to get the "LastUpdatedBy" property
        [JsonIgnore]
        public string LastUpdatedBy { get; set; }

        [JsonProperty("serial")]
        public string Serial { get; set; }
    }
}