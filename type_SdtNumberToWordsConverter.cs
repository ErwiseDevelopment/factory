using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   [Serializable]
   public class SdtNumberToWordsConverter : GxUserType, IGxExternalObject
   {
      public SdtNumberToWordsConverter( )
      {
         /* Constructor for serialization */
      }

      public SdtNumberToWordsConverter( IGxContext context )
      {
         this.context = context;
         initialize();
      }

      private static Hashtable mapper;
      public override string JsonMap( string value )
      {
         if ( mapper == null )
         {
            mapper = new Hashtable();
         }
         return (string)mapper[value]; ;
      }

      public string numbertomoneywords( decimal gxTp_number )
      {
         string returnnumbertomoneywords;
         returnnumbertomoneywords = "";
         returnnumbertomoneywords = (string)(NumberToWordsConverter.NumberToMoneyWords(gxTp_number));
         return returnnumbertomoneywords ;
      }

      public Object ExternalInstance
      {
         get {
            if ( NumberToWordsConverter_externalReference == null )
            {
               NumberToWordsConverter_externalReference = new NumberToWordsConverter();
            }
            return NumberToWordsConverter_externalReference ;
         }

         set {
            NumberToWordsConverter_externalReference = (NumberToWordsConverter)(value);
         }

      }

      [XmlIgnore]
      private static GXTypeInfo _typeProps;
      protected override GXTypeInfo TypeInfo
      {
         get {
            return _typeProps ;
         }

         set {
            _typeProps = value ;
         }

      }

      public void initialize( )
      {
         return  ;
      }

      protected NumberToWordsConverter NumberToWordsConverter_externalReference=null ;
   }

}
