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
   public class gxdomaindmufcod
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomaindmufcod ()
      {
         domain[(short)11] = "Rondônia (RO)";
         domain[(short)12] = "Acre (AC)";
         domain[(short)13] = "Amazonas (AM)";
         domain[(short)14] = "Roraima (RR)";
         domain[(short)15] = "Pará (PA)";
         domain[(short)16] = "Amapá (AP)";
         domain[(short)17] = "Tocantins (TO)";
         domain[(short)21] = "Maranhão (MA)";
         domain[(short)22] = "Piauí (PI)";
         domain[(short)23] = "Ceará (CE)";
         domain[(short)24] = "Rio Grande do Norte (RN)";
         domain[(short)25] = "Paraíba (PB)";
         domain[(short)26] = "Pernambuco (PE)";
         domain[(short)27] = "Alagoas (AL)";
         domain[(short)28] = "Sergipe (SE)";
         domain[(short)29] = "Bahia (BA)";
         domain[(short)31] = "Minas Gerais (MG)";
         domain[(short)32] = "Espírito Santo (ES)";
         domain[(short)33] = "Rio de Janeiro (RJ)";
         domain[(short)35] = "São Paulo (SP)";
         domain[(short)41] = "Paraná (PR)";
         domain[(short)42] = "Santa Catarina (SC)";
         domain[(short)43] = "Rio Grande do Sul (RS)";
         domain[(short)50] = "Mato Grosso do Sul (MS)";
         domain[(short)51] = "Mato Grosso (MT)";
         domain[(short)52] = "Goiás (GO)";
         domain[(short)53] = "Distrito Federal (DF)";
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
            domainMap["RO"] = (short)11;
            domainMap["AC"] = (short)12;
            domainMap["AM"] = (short)13;
            domainMap["RR"] = (short)14;
            domainMap["PA"] = (short)15;
            domainMap["AP"] = (short)16;
            domainMap["TO"] = (short)17;
            domainMap["MA"] = (short)21;
            domainMap["PI"] = (short)22;
            domainMap["CE"] = (short)23;
            domainMap["RN"] = (short)24;
            domainMap["PB"] = (short)25;
            domainMap["PE"] = (short)26;
            domainMap["AL"] = (short)27;
            domainMap["SE"] = (short)28;
            domainMap["BA"] = (short)29;
            domainMap["MG"] = (short)31;
            domainMap["ES"] = (short)32;
            domainMap["RJ"] = (short)33;
            domainMap["SP"] = (short)35;
            domainMap["PR"] = (short)41;
            domainMap["SC"] = (short)42;
            domainMap["RS"] = (short)43;
            domainMap["MS"] = (short)50;
            domainMap["MT"] = (short)51;
            domainMap["GO"] = (short)52;
            domainMap["DF"] = (short)53;
         }
         return (short)domainMap[key] ;
      }

   }

}
