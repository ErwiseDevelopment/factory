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
   public class SdtPdfService : GxUserType, IGxExternalObject
   {
      public SdtPdfService( )
      {
         /* Constructor for serialization */
      }

      public SdtPdfService( IGxContext context )
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

      public void concatenarhtmlnopdf( string gxTp_caminhoPdfExistente ,
                                       string gxTp_caminhoPdfResultado ,
                                       string gxTp_htmlContent )
      {
         if ( PdfService_externalReference == null )
         {
            PdfService_externalReference = new PdfConcateHtmlLibrary.PdfService();
         }
         PdfService_externalReference.ConcatenarHtmlNoPdf(gxTp_caminhoPdfExistente, gxTp_caminhoPdfResultado, gxTp_htmlContent);
         return  ;
      }

      public void dispose( )
      {
         if ( PdfService_externalReference == null )
         {
            PdfService_externalReference = new PdfConcateHtmlLibrary.PdfService();
         }
         PdfService_externalReference.Dispose();
         return  ;
      }

      public Object ExternalInstance
      {
         get {
            if ( PdfService_externalReference == null )
            {
               PdfService_externalReference = new PdfConcateHtmlLibrary.PdfService();
            }
            return PdfService_externalReference ;
         }

         set {
            PdfService_externalReference = (PdfConcateHtmlLibrary.PdfService)(value);
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

      protected PdfConcateHtmlLibrary.PdfService PdfService_externalReference=null ;
   }

}
