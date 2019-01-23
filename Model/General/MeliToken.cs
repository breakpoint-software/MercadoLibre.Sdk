using System;
using System.Collections.Generic;
using System.Text;

namespace MercadoLibre.SDK.Model.General

{
    public class MeliToken

    {
        public string Access_Token { get; set; }
        public string Token_Type { get; set; }
        public int Expire_In { get; set; }
        public string Scope { get; set; }
        public string User_Id{ get; set; }
    }
}
