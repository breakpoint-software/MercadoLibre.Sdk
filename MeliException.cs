using System;

namespace MercadoLibre.SDK
{
	public class MeliException : Exception
	{
		public MeliException()
        { 
		}

		public MeliException(string msg, Exception ex = null) : base(msg, ex) {
		}
	}
}

