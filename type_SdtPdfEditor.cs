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
   public class SdtPdfEditor : GxUserType, IGxExternalObject
   {
      public SdtPdfEditor( )
      {
         /* Constructor for serialization */
      }

      public SdtPdfEditor( IGxContext context )
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

      public int addtexttopdf( string gxTp_inputPdfPath ,
                               string gxTp_outputPdfPath ,
                               string gxTp_text )
      {
         int returnaddtexttopdf;
         if ( PdfEditor_externalReference == null )
         {
            PdfEditor_externalReference = new PDFAnnotationLib.PdfEditor();
         }
         returnaddtexttopdf = 0;
         returnaddtexttopdf = (int)(PdfEditor_externalReference.AddTextToPdf(gxTp_inputPdfPath, gxTp_outputPdfPath, gxTp_text));
         return returnaddtexttopdf ;
      }

      public Object ExternalInstance
      {
         get {
            if ( PdfEditor_externalReference == null )
            {
               PdfEditor_externalReference = new PDFAnnotationLib.PdfEditor();
            }
            return PdfEditor_externalReference ;
         }

         set {
            PdfEditor_externalReference = (PDFAnnotationLib.PdfEditor)(value);
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

      protected PDFAnnotationLib.PdfEditor PdfEditor_externalReference=null ;
   }

}
