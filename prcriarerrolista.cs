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
   public class prcriarerrolista : GXProcedure
   {
      public prcriarerrolista( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prcriarerrolista( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GxSimpleCollection<string> aP0_Lista ,
                           out string aP1_HTML )
      {
         this.AV9Lista = aP0_Lista;
         this.AV8HTML = "" ;
         initialize();
         ExecuteImpl();
         aP1_HTML=this.AV8HTML;
      }

      public string executeUdp( GxSimpleCollection<string> aP0_Lista )
      {
         execute(aP0_Lista, out aP1_HTML);
         return AV8HTML ;
      }

      public void executeSubmit( GxSimpleCollection<string> aP0_Lista ,
                                 out string aP1_HTML )
      {
         this.AV9Lista = aP0_Lista;
         this.AV8HTML = "" ;
         SubmitImpl();
         aP1_HTML=this.AV8HTML;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8HTML = "";
         AV8HTML += "<!DOCTYPE html>";
         AV8HTML += "<html lang=\"pt-BR\">";
         AV8HTML += "<head>";
         AV8HTML += "<meta charset=\"UTF-8\" />";
         AV8HTML += "<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\"/>";
         AV8HTML += "<title>Lista de Erros</title>";
         AV8HTML += "<style>";
         AV8HTML += ".erro-box {";
         AV8HTML += "background-color: #ffeaea;";
         AV8HTML += "color: #b00020;";
         AV8HTML += "border-left: 4px solid #b00020;";
         AV8HTML += "padding: 16px 20px;";
         AV8HTML += "width: 100%;";
         AV8HTML += "border-radius: 8px;";
         AV8HTML += "box-sizing: border-box;";
         AV8HTML += "font-family: sans-serif";
         AV8HTML += "}";
         AV8HTML += ".erro-box h2 {";
         AV8HTML += "margin: 0 0 8px;";
         AV8HTML += "font-size: 1.2rem;";
         AV8HTML += "display: flex;";
         AV8HTML += "align-items: center;";
         AV8HTML += "gap: 8px";
         AV8HTML += "}";
         AV8HTML += ".erro-box ul {";
         AV8HTML += "margin: 0;";
         AV8HTML += "padding-left: 24px;";
         AV8HTML += "font-size: 0.95rem;";
         AV8HTML += "color: #333";
         AV8HTML += "}";
         AV8HTML += ".erro-box ul li {";
         AV8HTML += "margin-bottom: 6px";
         AV8HTML += "}";
         AV8HTML += ".emoji {";
         AV8HTML += "font-size: 1.5rem";
         AV8HTML += "}";
         AV8HTML += " .erro-icon {";
         AV8HTML += "font-size: 1.4rem;";
         AV8HTML += "color: #b00020;";
         AV8HTML += "}";
         AV8HTML += "</style>";
         AV8HTML += "</head>";
         AV8HTML += "<body>";
         AV8HTML += "<div class=\"erro-box\">";
         AV8HTML += "<h2><i class=\"fas fa-exclamation-triangle erro-icon\"></i></span> Erros encontrados:</h2>";
         AV8HTML += "<ul>";
         AV11GXV1 = 1;
         while ( AV11GXV1 <= AV9Lista.Count )
         {
            AV10ItemLista = ((string)AV9Lista.Item(AV11GXV1));
            AV8HTML += StringUtil.Format( "<li>%1</li>", AV10ItemLista, "", "", "", "", "", "", "", "");
            AV11GXV1 = (int)(AV11GXV1+1);
         }
         AV8HTML += "</ul>";
         AV8HTML += "</div>";
         AV8HTML += "</body>";
         AV8HTML += "</html>";
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
         AV8HTML = "";
         AV10ItemLista = "";
         /* GeneXus formulas. */
      }

      private int AV11GXV1 ;
      private string AV8HTML ;
      private string AV10ItemLista ;
      private GxSimpleCollection<string> AV9Lista ;
      private string aP1_HTML ;
   }

}
