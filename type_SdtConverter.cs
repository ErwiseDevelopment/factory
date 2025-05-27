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
   public class SdtConverter : GxUserType, IGxExternalObject
   {
      public SdtConverter( )
      {
         /* Constructor for serialization */
      }

      public SdtConverter( IGxContext context )
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

      public bool converthtmlfiletopdf( string gxTp_htmlFilePath ,
                                        string gxTp_outputPdfPath ,
                                        out string gxTp_errorMessage )
      {
         bool returnconverthtmlfiletopdf;
         gxTp_errorMessage = "";
         if ( Converter_externalReference == null )
         {
            Converter_externalReference = new HtmlToPdfLibrary.Converter();
         }
         returnconverthtmlfiletopdf = false;
         returnconverthtmlfiletopdf = (bool)(Converter_externalReference.ConvertHtmlFileToPdf(gxTp_htmlFilePath, gxTp_outputPdfPath, out gxTp_errorMessage));
         return returnconverthtmlfiletopdf ;
      }

      public Object ExternalInstance
      {
         get {
            if ( Converter_externalReference == null )
            {
               Converter_externalReference = new HtmlToPdfLibrary.Converter();
            }
            return Converter_externalReference ;
         }

         set {
            Converter_externalReference = (HtmlToPdfLibrary.Converter)(value);
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

      protected HtmlToPdfLibrary.Converter Converter_externalReference=null ;
   }

}
