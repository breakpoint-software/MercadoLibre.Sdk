using Newtonsoft.Json;

namespace MercadoLibre.SDK.Model
{
    public class MeliItemImage
    {
        /// <summary>
        /// Url of the image 
        /// </summary>
        [JsonProperty("source")]
        public string Source { get; set; }
    }
}