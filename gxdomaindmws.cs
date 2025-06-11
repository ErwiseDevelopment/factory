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
   public class gxdomaindmws
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomaindmws ()
      {
         domain["Serasa_AUTH"] = "Serasa_AUTH";
         domain["Serasa_PROPOSTA_PF"] = "Serasa_PROPOSTA_PF";
         domain["Santander"] = "Santander";
      }

      public static string getDescription( IGxContext context ,
                                           string key )
      {
         string rtkey;
         string value;
         rtkey = ((key==null) ? "" : StringUtil.Trim( (string)(key)));
         value = (string)(domain[rtkey]==null?"":domain[rtkey]);
         return value ;
      }

      public static GxSimpleCollection<string> getValues( )
      {
         GxSimpleCollection<string> value = new GxSimpleCollection<string>();
         ArrayList aKeys = new ArrayList(domain.Keys);
         aKeys.Sort();
         foreach (string key in aKeys)
         {
            value.Add(key);
         }
         return value;
      }

      public static string getValue( string key )
      {
         if(domainMap == null)
         {
            domainMap = new Hashtable();
            domainMap["Serasa_AUTH"] = "Serasa_AUTH";
            domainMap["Serasa_PROPOSTA_PF"] = "Serasa_PROPOSTA_PF";
            domainMap["Santander"] = "Santander";
         }
         return (string)domainMap[key] ;
      }

   }

}
