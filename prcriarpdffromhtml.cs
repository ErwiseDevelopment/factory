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
   public class prcriarpdffromhtml : GXProcedure
   {
      public prcriarpdffromhtml( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prcriarpdffromhtml( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_HtmlPath ,
                           string aP1_PdfPath ,
                           out string aP2_erro )
      {
         this.AV8HtmlPath = aP0_HtmlPath;
         this.AV9PdfPath = aP1_PdfPath;
         this.AV10erro = "" ;
         initialize();
         ExecuteImpl();
         aP2_erro=this.AV10erro;
      }

      public string executeUdp( string aP0_HtmlPath ,
                                string aP1_PdfPath )
      {
         execute(aP0_HtmlPath, aP1_PdfPath, out aP2_erro);
         return AV10erro ;
      }

      public void executeSubmit( string aP0_HtmlPath ,
                                 string aP1_PdfPath ,
                                 out string aP2_erro )
      {
         this.AV8HtmlPath = aP0_HtmlPath;
         this.AV9PdfPath = aP1_PdfPath;
         this.AV10erro = "" ;
         SubmitImpl();
         aP2_erro=this.AV10erro;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV11wkhtmlPath = ".\\bin\\wkhtmltopdf.exe";
         AV14htmlInput = AV8HtmlPath;
         AV13pdfOutput = AV9PdfPath;
         AV16Comando = AV11wkhtmlPath + " \"" + AV14htmlInput + "\" \"" + AV13pdfOutput + "\"";
         AV12resultado = (short)(GXUtil.Shell( AV16Comando, 1, 0));
         AV15File.Source = AV13pdfOutput;
         if ( AV12resultado == 0 )
         {
            if ( AV15File.Exists() )
            {
               AV10erro = "PDF gerado com sucesso!";
            }
            else
            {
               AV10erro = "Erro: Arquivo de saída não encontrado.";
            }
         }
         else
         {
            AV10erro = "Falha na conversão. Código: " + StringUtil.Str( (decimal)(AV12resultado), 4, 0);
         }
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
         AV10erro = "";
         AV11wkhtmlPath = "";
         AV14htmlInput = "";
         AV13pdfOutput = "";
         AV16Comando = "";
         AV15File = new GxFile(context.GetPhysicalPath());
         /* GeneXus formulas. */
      }

      private short AV12resultado ;
      private string AV8HtmlPath ;
      private string AV9PdfPath ;
      private string AV10erro ;
      private string AV11wkhtmlPath ;
      private string AV14htmlInput ;
      private string AV13pdfOutput ;
      private string AV16Comando ;
      private GxFile AV15File ;
      private string aP2_erro ;
   }

}
