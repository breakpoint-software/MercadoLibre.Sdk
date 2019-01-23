using Newtonsoft.Json;
using RestSharp.Serializers;
using System.Collections.Generic;
using System.Linq;

namespace MercadoLibre.SDK.Model.Items
{
    public class MeliItem
    {

        [JsonIgnore]
        public string CodigoSap { get; set; }
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("price")]
        public decimal Price { get; set; }
        [JsonProperty("currency_id")]
        public string Currency_Id { get; set; }
        [JsonProperty("available_quantity")]
        public int Available_Quantity { get; set; }
        [JsonProperty("category_id")]
        public string Category_Id { get; set; }
        [JsonProperty("buying_mode")]
        public string Buying_Mode { get; set; }

        [JsonProperty("listing_type_id")]
        public string Listing_Type_Id { get; set; }
        [JsonProperty("condition")]
        public string Condition { get; set; }
        [JsonProperty("warranty")]
        public string Warranty { get; set; }

        [JsonProperty("description")]
        public MeliItemDescription Description { get; set; }
        [JsonProperty("pictures")]
        public List<MeliItemImage> Pictures { get; set; }


        /// <summary>
        /// Attributes of the item. To add attributo use de class MeliItemAttributeCreator
        /// 
        /// </summary>
        [JsonProperty("attributes")]
        public List<MeliItemAttribute> Attributes { get; set; }


        public void RemoveAttributte(string id)
        {
            Attributes.Remove(FindAttribute(id));
        }

        public MeliItemAttribute FindAttribute(string id)
        {
            return Attributes.Where(e => e.Id == id).FirstOrDefault();
        }

    }
}