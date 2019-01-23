using MercadoLibre.SDK;
using MercadoLibre.SDK.Model;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using System.Text;
using MercadoLibre.SDK.Model.Items;
using MercadoLibre.SDK.Model.General;
using MercadoLibre.SDK.Model.Shipping;

namespace MercadoLibre.SDK.Client
{
    /// <summary>
    /// This client offert a small set of methods to interact with mercado libre API 
    /// </summary>
    public class MeliClient
    {
        Meli mlClient = null;
        MeliToken _token;
        string _refreshToken;


        public MeliClient(long clientId, string clientSecret, string refreshToken = null)
        {
            this._refreshToken = refreshToken;


            mlClient = new Meli(clientId, clientSecret);
        }


        #region Public methods 

        public MeliToken GetToken()
        {
            // try to refresh the token if the response is no valid try to generate a new key 
            var parameters = new List<Parameter>()
            {
                new Parameter{ Name="grant_type", Value="refresh_token"},
                new Parameter{ Name="client_id", Value=mlClient.ClientId},
                new Parameter{ Name="client_secret", Value=mlClient.ClientSecret},
                new Parameter{ Name="refresh_token", Value=_refreshToken},
            };


            var result = mlClient.Post("/oauth/token", parameters, null);
            if (result.StatusCode != HttpStatusCode.OK)
            {
                parameters = new List<Parameter>()
                {
                    new Parameter{ Name="grant_type", Value="authorization_code"},
                    new Parameter{ Name="client_id", Value=mlClient.ClientId},
                    new Parameter{ Name="client_secret", Value=mlClient.ClientSecret},
                    new Parameter{ Name="code", Value="TG-5c3de33ea43a4a00065f2ae1-393015527" },
                    new Parameter{ Name="redirect_uri", Value="https://developers.mercadolibre.com.ar" },

                };

                result = mlClient.Post("/oauth/token", parameters, null);
            }

            ValidateResponse(result);
            _token = JsonConvert.DeserializeObject<MeliToken>(result.Content);


            return _token;
        }

        /// <summary>
        /// Return the item from ML 
        /// </summary>
        /// <param name="id">item to find</param>
        /// <param name="includeAttributes"></param>
        /// <returns></returns>
        public MeliItem GetItem(string id, bool includeAttributes = false)
        {

            GetToken();
            IRestResponse result = mlClient.Get(string.Format("/items/{0}{1}", id, (includeAttributes ? "?attributes=attributes&include_internal_attributes=true" : "")), GetBasicParameters());

            if (result.ErrorException != null)
                throw result.ErrorException;

            return JsonConvert.DeserializeObject<MeliItem>(result.Content);
        }

        public MeliItem ModifyItem(MeliItem item)
        {
            GetToken();
            IRestResponse result = mlClient.Put(string.Concat("/items/", item.Id), GetBasicParameters(), item);
            ValidateResponse(result);

            return JsonConvert.DeserializeObject<MeliItem>(result.Content);
        }

        /// <summary>
        /// Modify item description 
        /// </summary>
        /// <param name="id">Item to modify</param>
        /// <param name="newDescription">New description</param>
        public void ModifyItemDescription(string id, string newDescription)
        {
            GetToken();
            IRestResponse result = mlClient.Put(string.Concat("/items/", id, "/description"), GetBasicParameters(), new { plain_text = newDescription });
            ValidateResponse(result);
        }

        /// <summary>
        /// Returns item description 
        /// </summary>
        /// <param name="id">Item to find </param>
        /// <returns></returns>
        public MeliItemDescription GetItemDescription(string id)
        {
            GetToken();

            IRestResponse result = mlClient.Get(string.Concat("/items/", id, "/description"), GetBasicParameters());
            ValidateResponse(result);

            return JsonConvert.DeserializeObject<MeliItemDescription>(result.Content);
        }

        /// <summary>
        /// Modify item stock
        /// </summary>
        /// <param name="id">item to modify</param>
        /// <param name="quantity">new stock </param>
        /// <returns></returns>
        public MeliItem ModifyItemStock(string id, int quantity)
        {
            GetToken();
            IRestResponse result = mlClient.Put(string.Concat("/items/", id), GetBasicParameters(), new { available_quantity = quantity });
            ValidateResponse(result);
            return JsonConvert.DeserializeObject<MeliItem>(result.Content);
        }

        /// <summary>
        /// Modify item price 
        /// </summary>
        /// <param name="id">item to modify</param>
        /// <param name="price">new price </param>
        /// <returns></returns>
        public MeliItem ModifyItemPrice(string id, decimal price)
        {
            GetToken();
            IRestResponse result = mlClient.Put(string.Concat("/items/", id), GetBasicParameters(), new { price = price });
            ValidateResponse(result);
            return JsonConvert.DeserializeObject<MeliItem>(result.Content);
        }

        public void DeleteItem(string item)
        {
            GetToken();
            IRestResponse result = mlClient.Delete(string.Concat("/items/", item), GetBasicParameters());

            ValidateResponse(result);

        }

        /// <summary>
        /// Publish a new item 
        /// </summary>
        /// <param name="item">Item to publish</param>
        /// <returns></returns>
        public MeliItem PublishItem(MeliItem item)
        {
            GetToken();
            IRestResponse result = mlClient.Post(string.Concat("/items"), GetBasicParameters(), item);

            ValidateResponse(result);

            return JsonConvert.DeserializeObject<MeliItem>(result.Content);
        }

        /// <summary>
        /// returns all items associated to the user 
        /// </summary>
        /// <param name="user">user owner</param>
        /// <returns></returns>
        public MeliUserItems GetAllUserItems(string user)
        {

            GetToken();
            IRestResponse result = mlClient.Get(string.Concat("/users/", user, "/items/search"), GetBasicParameters());

            ValidateResponse(result);

            return JsonConvert.DeserializeObject<MeliUserItems>(result.Content);

        }

        /// <summary>
        /// returns all orders with state Paid 
        /// </summary>
        /// <param name="userId">user seller</param>
        /// <returns></returns>
        public MeliOrdersBySeller GetAllPaidOrders(string userId)
        {
            GetToken();
            var parameters = GetBasicParameters();
            parameters.Add(new Parameter { Name = "order.status", Value = "paid" });
            parameters.Add(new Parameter { Name = "seller", Value = userId });
            IRestResponse result = mlClient.Get(string.Concat("/orders/search"), parameters);

            ValidateResponse(result);

            return JsonConvert.DeserializeObject<MeliOrdersBySeller>(result.Content);
        }

        /// <summary>
        /// Returns an specific order
        /// </summary>
        /// <param name="orderId">order to find</param>
        /// <returns></returns>
        public MeliOrder GetOrder(string orderId)
        {
            GetToken();
            var parameters = GetBasicParameters();
            IRestResponse result = mlClient.Get(string.Concat("/orders/", orderId), parameters);

            ValidateResponse(result);

            return JsonConvert.DeserializeObject<MeliOrder>(result.Content);
        }

        /// <summary>
        /// Returns the user logged 
        /// </summary>
        /// <returns></returns>
        public MeliUser GetCurrentUser()
        {

            GetToken();
            IRestResponse result = mlClient.Get(string.Concat("/users/me"), GetBasicParameters());

            ValidateResponse(result);

            return JsonConvert.DeserializeObject<MeliUser>(result.Content);
        }


        /// <summary>
        /// Returns a specific shipping 
        /// </summary>
        /// <param name="shippingId">shipping to return</param>
        /// <returns></returns>
        public MeliShipping GetShipping(string shippingId)
        {
            GetToken();
            var parameters = GetBasicParameters();
            IRestResponse result = mlClient.Get(string.Concat("/shipments/", shippingId), parameters);

            ValidateResponse(result);

            return JsonConvert.DeserializeObject<MeliShipping>(result.Content);
        }

        #endregion public methods 

        #region Private methods

        private void ValidateResponse(IRestResponse response)
        {
            if (response.ErrorException != null)
                throw response.ErrorException;

            if (!new Object[] { HttpStatusCode.OK, HttpStatusCode.Created }.Contains(response.StatusCode))
            {
                MeliError error = JsonConvert.DeserializeObject<MeliError>(response.Content);
                throw new MeliException(string.Concat(error.Status, " - ", error.Message, ": ", error.Error), null);
            }
        }

        private List<Parameter> GetBasicParameters()
        {
            List<Parameter> parameters = new List<Parameter>()
                ;
            parameters.Add(new Parameter() { Name = "access_token", Value = this._token.Access_Token });
            return parameters;
        }

        #endregion

    }
}
