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
   public class SdtPDFTools : GxUserType, IGxExternalObject
   {
      public SdtPDFTools( )
      {
         /* Constructor for serialization */
      }

      public SdtPDFTools( IGxContext context )
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

      public string concatfiles( GxSimpleCollection<string> gxTp_files ,
                                 string gxTp_targetPath )
      {
         string returnconcatfiles;
         if ( PDFTools_externalReference == null )
         {
            PDFTools_externalReference = new PDFTools_iTextSharpLib.iTextSharpUtil();
         }
         returnconcatfiles = "";
         System.Collections.Generic.List< System.String> externalParm0;
         externalParm0 = (System.Collections.Generic.List< System.String>)CollectionUtils.ConvertToExternal( typeof(System.Collections.Generic.List< System.String>), gxTp_files.ExternalInstance);
         returnconcatfiles = (string)(PDFTools_externalReference.ConcatFiles(externalParm0, gxTp_targetPath));
         return returnconcatfiles ;
      }

      public string addsignature( string gxTp_PathSource ,
                                  string gxTp_PathTarget ,
                                  string gxTp_CertPath ,
                                  string gxTp_CertPass ,
                                  bool gxTp_Visible )
      {
         string returnaddsignature;
         if ( PDFTools_externalReference == null )
         {
            PDFTools_externalReference = new PDFTools_iTextSharpLib.iTextSharpUtil();
         }
         returnaddsignature = "";
         returnaddsignature = (string)(PDFTools_externalReference.AddSignature(gxTp_PathSource, gxTp_PathTarget, gxTp_CertPath, gxTp_CertPass, gxTp_Visible));
         return returnaddsignature ;
      }

      public string addsignature( string gxTp_PathSource ,
                                  string gxTp_PathTarget ,
                                  string gxTp_CertPath ,
                                  string gxTp_CertPass ,
                                  int gxTp_x ,
                                  int gxTp_y ,
                                  int gxTp_LengthX ,
                                  int gxTp_LengthY ,
                                  int gxTp_Page ,
                                  bool gxTp_Visible )
      {
         string returnaddsignature;
         if ( PDFTools_externalReference == null )
         {
            PDFTools_externalReference = new PDFTools_iTextSharpLib.iTextSharpUtil();
         }
         returnaddsignature = "";
         returnaddsignature = (string)(PDFTools_externalReference.AddSignature(gxTp_PathSource, gxTp_PathTarget, gxTp_CertPath, gxTp_CertPass, gxTp_x, gxTp_y, gxTp_LengthX, gxTp_LengthY, gxTp_Page, gxTp_Visible));
         return returnaddsignature ;
      }

      public string modifypermissions( string gxTp_PathSource ,
                                       string gxTp_PathTarget ,
                                       string gxTp_UserPassword ,
                                       GxSimpleCollection<int> gxTp_Permissons )
      {
         string returnmodifypermissions;
         if ( PDFTools_externalReference == null )
         {
            PDFTools_externalReference = new PDFTools_iTextSharpLib.iTextSharpUtil();
         }
         returnmodifypermissions = "";
         System.Collections.Generic.List< System.Int32> externalParm0;
         externalParm0 = (System.Collections.Generic.List< System.Int32>)CollectionUtils.ConvertToExternal( typeof(System.Collections.Generic.List< System.Int32>), gxTp_Permissons.ExternalInstance);
         returnmodifypermissions = (string)(PDFTools_externalReference.ModifyPermissions(gxTp_PathSource, gxTp_PathTarget, gxTp_UserPassword, externalParm0));
         return returnmodifypermissions ;
      }

      public int pagecount( string gxTp_PathSource )
      {
         int returnpagecount;
         if ( PDFTools_externalReference == null )
         {
            PDFTools_externalReference = new PDFTools_iTextSharpLib.iTextSharpUtil();
         }
         returnpagecount = 0;
         returnpagecount = (int)(PDFTools_externalReference.NumberOfPages(gxTp_PathSource));
         return returnpagecount ;
      }

      public string tifftopdf( GxSimpleCollection<string> gxTp_files ,
                               string gxTp_targetPath )
      {
         string returntifftopdf;
         if ( PDFTools_externalReference == null )
         {
            PDFTools_externalReference = new PDFTools_iTextSharpLib.iTextSharpUtil();
         }
         returntifftopdf = "";
         System.Collections.Generic.List< System.String> externalParm0;
         externalParm0 = (System.Collections.Generic.List< System.String>)CollectionUtils.ConvertToExternal( typeof(System.Collections.Generic.List< System.String>), gxTp_files.ExternalInstance);
         returntifftopdf = (string)(PDFTools_externalReference.TiffAsPDF(externalParm0, gxTp_targetPath));
         return returntifftopdf ;
      }

      public string setfields( string gxTp_PathSource ,
                               string gxTp_PathTarget ,
                               object gxTp_Fields )
      {
         string returnsetfields;
         if ( PDFTools_externalReference == null )
         {
            PDFTools_externalReference = new PDFTools_iTextSharpLib.iTextSharpUtil();
         }
         returnsetfields = "";
         returnsetfields = (string)(PDFTools_externalReference.SetFields(gxTp_PathSource, gxTp_PathTarget, (System.Object)(gxTp_Fields)));
         return returnsetfields ;
      }

      public string addtext( string gxTp_PathSource ,
                             string gxTp_PathTarget ,
                             int gxTp_x ,
                             int gxTp_y ,
                             int gxTp_selectedPage ,
                             string gxTp_text ,
                             int gxTp_fontSize )
      {
         string returnaddtext;
         if ( PDFTools_externalReference == null )
         {
            PDFTools_externalReference = new PDFTools_iTextSharpLib.iTextSharpUtil();
         }
         returnaddtext = "";
         returnaddtext = (string)(PDFTools_externalReference.AddText(gxTp_PathSource, gxTp_PathTarget, gxTp_x, gxTp_y, gxTp_selectedPage, gxTp_text, gxTp_fontSize));
         return returnaddtext ;
      }

      public string addtext( string gxTp_PathSource ,
                             string gxTp_PathTarget ,
                             int gxTp_x ,
                             int gxTp_y ,
                             int gxTp_selectedPage ,
                             string gxTp_text ,
                             int gxTp_angle ,
                             int gxTp_red ,
                             int gxTp_green ,
                             int gxTp_blue ,
                             int gxTp_fontSize ,
                             decimal gxTp_opacity )
      {
         string returnaddtext;
         if ( PDFTools_externalReference == null )
         {
            PDFTools_externalReference = new PDFTools_iTextSharpLib.iTextSharpUtil();
         }
         returnaddtext = "";
         float externalParm0;
         externalParm0 = (float)(gxTp_opacity);
         returnaddtext = (string)(PDFTools_externalReference.AddText(gxTp_PathSource, gxTp_PathTarget, gxTp_x, gxTp_y, gxTp_selectedPage, gxTp_text, gxTp_angle, gxTp_red, gxTp_green, gxTp_blue, gxTp_fontSize, externalParm0));
         return returnaddtext ;
      }

      public string html2pdf( string gxTp_HtmlContent ,
                              string gxTp_TargetPath ,
                              string gxTp_FontPath )
      {
         string returnhtml2pdf;
         if ( PDFTools_externalReference == null )
         {
            PDFTools_externalReference = new PDFTools_iTextSharpLib.iTextSharpUtil();
         }
         returnhtml2pdf = "";
         returnhtml2pdf = (string)(PDFTools_externalReference.Html2PDF(gxTp_HtmlContent, gxTp_TargetPath, gxTp_FontPath));
         return returnhtml2pdf ;
      }

      public Object ExternalInstance
      {
         get {
            if ( PDFTools_externalReference == null )
            {
               PDFTools_externalReference = new PDFTools_iTextSharpLib.iTextSharpUtil();
            }
            return PDFTools_externalReference ;
         }

         set {
            PDFTools_externalReference = (PDFTools_iTextSharpLib.iTextSharpUtil)(value);
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

      protected PDFTools_iTextSharpLib.iTextSharpUtil PDFTools_externalReference=null ;
   }

}
