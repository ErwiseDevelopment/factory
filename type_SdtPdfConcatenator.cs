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
   public class SdtPdfConcatenator : GxUserType, IGxExternalObject
   {
      public SdtPdfConcatenator( )
      {
         /* Constructor for serialization */
      }

      public SdtPdfConcatenator( IGxContext context )
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

      public int concatenatehtmlwithpdf( string gxTp_htmlContent ,
                                         string gxTp_existingPdfPath ,
                                         string gxTp_outputPdfPath )
      {
         int returnconcatenatehtmlwithpdf;
         if ( PdfConcatenator_externalReference == null )
         {
            PdfConcatenator_externalReference = new PdfProcessingLibrary.PdfConcatenator();
         }
         returnconcatenatehtmlwithpdf = 0;
         returnconcatenatehtmlwithpdf = (int)(PdfConcatenator_externalReference.ConcatenateHtmlWithPdf(gxTp_htmlContent, gxTp_existingPdfPath, gxTp_outputPdfPath));
         return returnconcatenatehtmlwithpdf ;
      }

      public Object ExternalInstance
      {
         get {
            if ( PdfConcatenator_externalReference == null )
            {
               PdfConcatenator_externalReference = new PdfProcessingLibrary.PdfConcatenator();
            }
            return PdfConcatenator_externalReference ;
         }

         set {
            PdfConcatenator_externalReference = (PdfProcessingLibrary.PdfConcatenator)(value);
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

      protected PdfProcessingLibrary.PdfConcatenator PdfConcatenator_externalReference=null ;
   }

}
