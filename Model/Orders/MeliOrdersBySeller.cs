using Newtonsoft.Json;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MercadoLibre.SDK.Model
{
    public class MeliOrdersBySeller
    {
        [JsonProperty("results")]
        List<MeliOrder> Orders { get; set; }
    }

}