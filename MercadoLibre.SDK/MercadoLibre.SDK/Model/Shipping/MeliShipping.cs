using Newtonsoft.Json;

namespace MercadoLibre.SDK.Model.Shipping
{
    public class MeliShipping
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("order_id")]
        public string Order_Id{ get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("substatus")]
        public string Substatus { get; set; }

    }
}