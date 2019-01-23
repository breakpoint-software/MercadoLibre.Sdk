using Newtonsoft.Json;

namespace MercadoLibre.SDK.Model.Items
{
    public class MeliItemDescription
    {

        [JsonProperty("plain_text")]
        public string Plain_Text { get; set; }
    }
}