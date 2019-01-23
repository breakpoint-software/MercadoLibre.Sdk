using Newtonsoft.Json;

namespace MercadoLibre.SDK.Model
{
    public class MeliOrderDetail
    {
        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("unit_price")]
        public decimal Unit_Price { get; set; }

        [JsonProperty("item")]
        public MeliOrderItem Item { get; set; }
    }
}