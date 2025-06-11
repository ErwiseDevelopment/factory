using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class htmltopdf : GXProcedure
   {
      public htmltopdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public htmltopdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_ContentHTML ,
                           string aP1_PDFSource )
      {
         this.AV8ContentHTML = aP0_ContentHTML;
         this.AV9PDFSource = aP1_PDFSource;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( string aP0_ContentHTML ,
                                 string aP1_PDFSource )
      {
         this.AV8ContentHTML = aP0_ContentHTML;
         this.AV9PDFSource = aP1_PDFSource;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10Style = "<style>*{font-family: Arial; font-size: 16px; margin-left: 15px; margin-right: 15px; word-break: break-word;} p{margin-left:0;} td{padding-left:5px; padding-top: 2px; padding-bottom: 2px;}</style>";
         new limpatextohtml(context ).execute( ref  AV8ContentHTML) ;
         AV8ContentHTML += AV10Style;
         AV11File = new GxFile(context.GetPhysicalPath());
         AV11File.Source = "C:\\temp\\teste.html";
         if ( ! AV11File.Exists() )
         {
            AV11File.Create();
         }
         AV11File.WriteAllText(AV8ContentHTML, "UTF8");
         AV12BinDirectory = new GxDirectory(context.GetPhysicalPath());
         AV12BinDirectory.Source = ".\\bin\\";
         AV13SourceExecutavel = AV12BinDirectory.GetAbsoluteName() + StringUtil.Format( "wkhtmltopdf --encoding utf8 %1 %2", "C:\\temp\\teste.html", AV9PDFSource, "", "", "", "", "", "", "");
         AV15Ret = (decimal)(GXUtil.Shell( AV13SourceExecutavel, 1, 0));
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV10Style = "";
         AV11File = new GxFile(context.GetPhysicalPath());
         AV12BinDirectory = new GxDirectory(context.GetPhysicalPath());
         AV13SourceExecutavel = "";
         /* GeneXus formulas. */
      }

      private decimal AV15Ret ;
      private string AV8ContentHTML ;
      private string AV10Style ;
      private string AV9PDFSource ;
      private string AV13SourceExecutavel ;
      private GxFile AV11File ;
      private GxDirectory AV12BinDirectory ;
   }

}
