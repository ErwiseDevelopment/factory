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
   public class SdtHtmlToPdfConverter : GxUserType, IGxExternalObject
   {
      public SdtHtmlToPdfConverter( )
      {
         /* Constructor for serialization */
      }

      public SdtHtmlToPdfConverter( IGxContext context )
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

      public void convert( string gxTp_htmlFilePath ,
                           string gxTp_pdfFilePath ,
                           out string gxTp_response )
      {
         gxTp_response = "";
         if ( HtmlToPdfConverter_externalReference == null )
         {
            HtmlToPdfConverter_externalReference = new HtmlToPdfLibrary.HtmlToPdfConverter();
         }
         HtmlToPdfConverter_externalReference.Convert(gxTp_htmlFilePath, gxTp_pdfFilePath, out gxTp_response);
         return  ;
      }

      public void dispose( )
      {
         if ( HtmlToPdfConverter_externalReference == null )
         {
            HtmlToPdfConverter_externalReference = new HtmlToPdfLibrary.HtmlToPdfConverter();
         }
         HtmlToPdfConverter_externalReference.Dispose();
         return  ;
      }

      public Object ExternalInstance
      {
         get {
            if ( HtmlToPdfConverter_externalReference == null )
            {
               HtmlToPdfConverter_externalReference = new HtmlToPdfLibrary.HtmlToPdfConverter();
            }
            return HtmlToPdfConverter_externalReference ;
         }

         set {
            HtmlToPdfConverter_externalReference = (HtmlToPdfLibrary.HtmlToPdfConverter)(value);
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

      protected HtmlToPdfLibrary.HtmlToPdfConverter HtmlToPdfConverter_externalReference=null ;
   }

}
