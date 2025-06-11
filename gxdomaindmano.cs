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
   public class gxdomaindmano
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomaindmano ()
      {
         domain[(short)2024] = "2024";
         domain[(short)2025] = "2025";
         domain[(short)2026] = "2026";
         domain[(short)2027] = "2027";
         domain[(short)2028] = "2028";
         domain[(short)2029] = "2029";
         domain[(short)2030] = "2030";
         domain[(short)2031] = "2031";
         domain[(short)2032] = "2032";
         domain[(short)2033] = "2033";
         domain[(short)2034] = "2034";
         domain[(short)2035] = "2035";
         domain[(short)2036] = "2036";
         domain[(short)2037] = "2037";
         domain[(short)2038] = "2038";
         domain[(short)2039] = "2039";
         domain[(short)2040] = "2040";
         domain[(short)2041] = "2041";
         domain[(short)2042] = "2042";
         domain[(short)2043] = "2043";
         domain[(short)2044] = "2044";
         domain[(short)2045] = "2045";
         domain[(short)2046] = "2046";
         domain[(short)2047] = "2047";
         domain[(short)2048] = "2048";
         domain[(short)2049] = "2049";
         domain[(short)2050] = "2050";
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
            domainMap["A2024"] = (short)2024;
            domainMap["A2025"] = (short)2025;
            domainMap["A2026"] = (short)2026;
            domainMap["A2027"] = (short)2027;
            domainMap["A2028"] = (short)2028;
            domainMap["A2029"] = (short)2029;
            domainMap["A2030"] = (short)2030;
            domainMap["A2031"] = (short)2031;
            domainMap["A2032"] = (short)2032;
            domainMap["A2033"] = (short)2033;
            domainMap["A2034"] = (short)2034;
            domainMap["A2035"] = (short)2035;
            domainMap["A2036"] = (short)2036;
            domainMap["A2037"] = (short)2037;
            domainMap["A2038"] = (short)2038;
            domainMap["A2039"] = (short)2039;
            domainMap["A2040"] = (short)2040;
            domainMap["A2041"] = (short)2041;
            domainMap["A2042"] = (short)2042;
            domainMap["A2043"] = (short)2043;
            domainMap["A2044"] = (short)2044;
            domainMap["A2045"] = (short)2045;
            domainMap["A2046"] = (short)2046;
            domainMap["A2047"] = (short)2047;
            domainMap["A2048"] = (short)2048;
            domainMap["A2049"] = (short)2049;
            domainMap["A2050"] = (short)2050;
         }
         return (short)domainMap[key] ;
      }

   }

}
