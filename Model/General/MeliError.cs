using System.Collections.Generic;

namespace MercadoLibre.SDK.Model.General
{
    public class MeliError
    {
        public string Message { get; set; }
        public List<string> Causes { get; set; }
        public string Error { get; set; }
        public string Status { get; set; }
    }
}