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
   public class gxdomaindmrelacionamento
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomaindmrelacionamento ()
      {
         domain["Cliente"] = "Cliente";
         domain["Paciente"] = "Paciente";
         domain["Clinica"] = "Clinica";
         domain["Sacado"] = "Sacado";
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
            domainMap["Cliente"] = "Cliente";
            domainMap["Paciente"] = "Paciente";
            domainMap["Clinica"] = "Clinica";
            domainMap["Sacado"] = "Sacado";
         }
         return (string)domainMap[key] ;
      }

   }

}
