using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class gxdomaindmmeses
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomaindmmeses ()
      {
         domain[(short)1] = "Janeiro";
         domain[(short)2] = "Fevereiro";
         domain[(short)3] = "Maço";
         domain[(short)4] = "Abril";
         domain[(short)5] = "Maio";
         domain[(short)6] = "Junho";
         domain[(short)7] = "Julho";
         domain[(short)8] = "Agosto";
         domain[(short)9] = "Setembro";
         domain[(short)10] = "Outubro";
         domain[(short)11] = "Novembro";
         domain[(short)12] = "Dezembro";
      }

      public static string getDescription( IGxContext context ,
                                           short key )
      {
         string value;
         value = (string)(domain[key]==null?"":domain[key]);
         return value ;
      }

      public static GxSimpleCollection<short> getValues( )
      {
         GxSimpleCollection<short> value = new GxSimpleCollection<short>();
         ArrayList aKeys = new ArrayList(domain.Keys);
         aKeys.Sort();
         foreach (short key in aKeys)
         {
            value.Add(key);
         }
         return value;
      }

      public static short getValue( string key )
      {
         if(domainMap == null)
         {
            domainMap = new Hashtable();
            domainMap["Janeiro"] = (short)1;
            domainMap["Fevereiro"] = (short)2;
            domainMap["Marco"] = (short)3;
            domainMap["Abril"] = (short)4;
            domainMap["Maio"] = (short)5;
            domainMap["Junho"] = (short)6;
            domainMap["Julho"] = (short)7;
            domainMap["Agosto"] = (short)8;
            domainMap["Setembro"] = (short)9;
            domainMap["Outubro"] = (short)10;
            domainMap["Novembro"] = (short)11;
            domainMap["Dezembro"] = (short)12;
         }
         return (short)domainMap[key] ;
      }

   }

}
