using MercadoLibre.SDK.Model.Shipping;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MercadoLibre.SDK.Model
{
    public class MeliOrder
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("date_created")]
        public DateTime Date_Created { get; set; }
        [JsonProperty("order_items")]
        public List<MeliOrderItem> OrderItems { get; set; }

        [JsonProperty("shipping")]
        public MeliShipping Shipping { get; set; }
    }
}