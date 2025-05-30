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
   public class gxdomainwwpsecfunctionalitytypes
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomainwwpsecfunctionalitytypes ()
      {
         domain[(short)1] = "Mode";
         domain[(short)2] = "Action";
         domain[(short)3] = "Tab";
         domain[(short)4] = "Object";
         domain[(short)5] = "Attribute";
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
            domainMap["Mode"] = (short)1;
            domainMap["Action"] = (short)2;
            domainMap["Tab"] = (short)3;
            domainMap["Object"] = (short)4;
            domainMap["Attribute"] = (short)5;
         }
         return (short)domainMap[key] ;
      }

   }

}
