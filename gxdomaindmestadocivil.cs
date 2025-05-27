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
   public class gxdomaindmestadocivil
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomaindmestadocivil ()
      {
         domain["SOLTEIRO"] = "Solteiro(a)";
         domain["CASADO"] = "Casado(a)";
         domain["DIVORCIADO"] = "Divorciado(a)";
         domain["VIUVO"] = "Viúvo(a)";
         domain["SEPARADO"] = "Separado(a)";
         domain["UNIAO_ESTAVEL"] = "União Estável";
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
            domainMap["SOLTEIRO"] = "SOLTEIRO";
            domainMap["CASADO"] = "CASADO";
            domainMap["DIVORCIADO"] = "DIVORCIADO";
            domainMap["VIUVO"] = "VIUVO";
            domainMap["SEPARADO"] = "SEPARADO";
            domainMap["UNIAO_ESTAVEL"] = "UNIAO_ESTAVEL";
         }
         return (string)domainMap[key] ;
      }

   }

}
