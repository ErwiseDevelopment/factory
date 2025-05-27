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
   public class gxdomainpdfpermission
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomainpdfpermission ()
      {
         domain[(int)2052] = "Allow Printing";
         domain[(int)8] = "Allow Modify Contents";
         domain[(int)16] = "Allow Copy";
         domain[(int)32] = "Allow Modify Annotations";
         domain[(int)256] = "Allow Fill In";
         domain[(int)512] = "Allow Screen Readers";
         domain[(int)1024] = "Allow Assembly";
         domain[(int)4] = "Allow Degraded Printing";
      }

      public static string getDescription( IGxContext context ,
                                           int key )
      {
         string value;
         value = (string)(domain[key]==null?"":domain[key]);
         return value ;
      }

      public static GxSimpleCollection<int> getValues( )
      {
         GxSimpleCollection<int> value = new GxSimpleCollection<int>();
         ArrayList aKeys = new ArrayList(domain.Keys);
         aKeys.Sort();
         foreach (int key in aKeys)
         {
            value.Add(key);
         }
         return value;
      }

      public static int getValue( string key )
      {
         if(domainMap == null)
         {
            domainMap = new Hashtable();
            domainMap["AllowPrinting"] = (int)2052;
            domainMap["AllowModifyContents"] = (int)8;
            domainMap["AllowCopy"] = (int)16;
            domainMap["AllowModifyAnnotations"] = (int)32;
            domainMap["AllowFillIn"] = (int)256;
            domainMap["AllowScreenReaders"] = (int)512;
            domainMap["AllowAssembly"] = (int)1024;
            domainMap["AllowDegradedPrinting"] = (int)4;
         }
         return (int)domainMap[key] ;
      }

   }

}
