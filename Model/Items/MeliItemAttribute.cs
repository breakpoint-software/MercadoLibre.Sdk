using Newtonsoft.Json;

namespace MercadoLibre.SDK.Model.Items
{
    public class MeliItemAttribute
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("value_id")]
        public string Value_Id{ get; set; }

        [JsonProperty("value_name")]
        public string Value_Name { get; set; }
    }
}