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
   public class gxdomaindmnivelhierarquico
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomaindmnivelhierarquico ()
      {
         domain["ESTAGIARIO"] = "Estagiário";
         domain["ASSISTENTE"] = "Assistente";
         domain["ANALISTA"] = "Analista";
         domain["COORDENADOR"] = "Coordenador";
         domain["SUPERVISOR"] = "Supervisor";
         domain["GERENTE"] = "Gerente";
         domain["DIRETOR"] = "Diretor";
         domain["VICE_PRESIDENTE"] = "Vice-Presidente";
         domain["PRESIDENTE"] = "Presidente";
         domain["CEO"] = "CEO";
         domain["SOCIO"] = "Sócio";
         domain["CONSELHEIRO"] = "Conselheiro";
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
            domainMap["ESTAGIARIO"] = "ESTAGIARIO";
            domainMap["ASSISTENTE"] = "ASSISTENTE";
            domainMap["ANALISTA"] = "ANALISTA";
            domainMap["COORDENADOR"] = "COORDENADOR";
            domainMap["SUPERVISOR"] = "SUPERVISOR";
            domainMap["GERENTE"] = "GERENTE";
            domainMap["DIRETOR"] = "DIRETOR";
            domainMap["VICE_PRESIDENTE"] = "VICE_PRESIDENTE";
            domainMap["PRESIDENTE"] = "PRESIDENTE";
            domainMap["CEO"] = "CEO";
            domainMap["SOCIO"] = "SOCIO";
            domainMap["CONSELHEIRO"] = "CONSELHEIRO";
         }
         return (string)domainMap[key] ;
      }

   }

}
