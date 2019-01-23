using Newtonsoft.Json;
using RestSharp.Serializers;
using System.Collections.Generic;

namespace MercadoLibre.SDK.Model.Items
{
    public class MeliUserItems
    {
        /// <summary>
        /// List of the meli item id
        /// </summary>
        [JsonProperty("results", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Results { get; set; }
    }
}