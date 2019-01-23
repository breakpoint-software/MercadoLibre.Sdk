using System;
using System.Collections.Generic;
using System.Text;

namespace MercadoLibre.SDK.Model.Items
{
    public class MeliItemAttributeCreator
    {
        public readonly static string BOOK_TITLE = "BOOK_TITLE";
        public readonly static string SELLER_SKU = "SELLER_SKU";
        public readonly static string PUBLISHER = "PUBLISHER";
        public readonly static string LANGUAGE = "LANGUAGE";
        public readonly static string ITEM_CONDITION = "ITEM_CONDITION";
        public readonly static string ISBN = "ISBN";
        public readonly static string FORMAT = "FORMAT";

        public static MeliItemAttribute CreateAuthor(string author)
        {
            return new MeliItemAttribute { Id = "AUTHOR", Value_Name = author };
        }

        public static MeliItemAttribute CreateBookTitle(string title)
        {
            return new MeliItemAttribute { Id = BOOK_TITLE, Value_Name = title };

        }

        public static MeliItemAttribute CreateFormat(string value)
        {
            return new MeliItemAttribute { Id = FORMAT, Value_Id = value };
        }

        public static MeliItemAttribute CreateISBN(string isbn)
        {
            return
                     new MeliItemAttribute { Id = ISBN, Value_Name = isbn };
        }

        public static MeliItemAttribute CreatePublisher(string publisher)
        {
            return new MeliItemAttribute { Id = PUBLISHER, Value_Id = "", Value_Name = publisher };
        }

        public static MeliItemAttribute CreateLanguage(string language)
        {
            return language.ToLower() == "es" ? new MeliItemAttribute { Id = LANGUAGE, Value_Id = "313886" } : null;

        }

        public static MeliItemAttribute CreateCondition(string condition)
        {
            return condition.ToLower() == "nuevo" ? new MeliItemAttribute { Id = ITEM_CONDITION, Value_Id = "2230284", Value_Name = "Nuevo" } : null;
        }
    }
}
