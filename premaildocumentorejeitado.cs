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
   public class premaildocumentorejeitado : GXProcedure
   {
      public premaildocumentorejeitado( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public premaildocumentorejeitado( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_PropostaClienteRazaoSocial ,
                           out string aP1_HTML )
      {
         this.AV9PropostaClienteRazaoSocial = aP0_PropostaClienteRazaoSocial;
         this.AV8HTML = "" ;
         initialize();
         ExecuteImpl();
         aP1_HTML=this.AV8HTML;
      }

      public string executeUdp( string aP0_PropostaClienteRazaoSocial )
      {
         execute(aP0_PropostaClienteRazaoSocial, out aP1_HTML);
         return AV8HTML ;
      }

      public void executeSubmit( string aP0_PropostaClienteRazaoSocial ,
                                 out string aP1_HTML )
      {
         this.AV9PropostaClienteRazaoSocial = aP0_PropostaClienteRazaoSocial;
         this.AV8HTML = "" ;
         SubmitImpl();
         aP1_HTML=this.AV8HTML;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8HTML += "<!DOCTYPE html>";
         AV8HTML += "<html>";
         AV8HTML += "<head>";
         AV8HTML += "<style>";
         AV8HTML += "body {";
         AV8HTML += "    font-family: Arial, sans-serif;";
         AV8HTML += "    margin: 0;";
         AV8HTML += "    padding: 0;";
         AV8HTML += "    background-color: #f5f5f5;";
         AV8HTML += "}";
         AV8HTML += ".email-container {";
         AV8HTML += "    max-width: 600px;";
         AV8HTML += "    margin: 0 auto;";
         AV8HTML += "    background-color: #ffffff;";
         AV8HTML += "    border: 1px solid #eaeaea;";
         AV8HTML += "    border-radius: 8px;";
         AV8HTML += "    overflow: hidden;";
         AV8HTML += "    box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);";
         AV8HTML += "}";
         AV8HTML += ".header {";
         AV8HTML += "    background-color: #08A086;";
         AV8HTML += "    color: #ffffff;";
         AV8HTML += "    padding: 20px;";
         AV8HTML += "    text-align: center;";
         AV8HTML += "}";
         AV8HTML += ".header h1 {";
         AV8HTML += "    margin: 0;";
         AV8HTML += "    font-size: 24px;";
         AV8HTML += "}";
         AV8HTML += ".content {";
         AV8HTML += "    padding: 20px;";
         AV8HTML += "}";
         AV8HTML += ".content h2 {";
         AV8HTML += "    color: #333333;";
         AV8HTML += "    font-size: 20px;";
         AV8HTML += "}";
         AV8HTML += ".content p {";
         AV8HTML += "    color: #555555;";
         AV8HTML += "    font-size: 16px;";
         AV8HTML += "    line-height: 1.5;";
         AV8HTML += "}";
         AV8HTML += ".footer {";
         AV8HTML += "    background-color: #f5f5f5;";
         AV8HTML += "    color: #888888;";
         AV8HTML += "    text-align: center;";
         AV8HTML += "    padding: 10px;";
         AV8HTML += "    font-size: 14px;";
         AV8HTML += "}";
         AV8HTML += "</style>";
         AV8HTML += "</head>";
         AV8HTML += "<body>";
         AV8HTML += "<div class=\"email-container\">";
         AV8HTML += "    <div class=\"header\">";
         AV8HTML += "        <h1>Documento Reprovado</h1>";
         AV8HTML += "    </div>";
         AV8HTML += "    <div class=\"content\">";
         AV8HTML += "        <h2>Olá,</h2>";
         AV8HTML += "        <p>";
         AV8HTML += StringUtil.Format( "            Informamos que o documento da <strong>proposta do paciente %1</strong> foi reprovado durante a análise. Para seguir com o processo, é necessário realizar as devidas correções e reenviar o documento.", AV9PropostaClienteRazaoSocial, "", "", "", "", "", "", "", "");
         AV8HTML += "        </p>";
         AV8HTML += "        <p>";
         AV8HTML += "            Por favor, revise as informações enviadas e garanta que atendem aos critérios exigidos.";
         AV8HTML += "        </p>";
         AV8HTML += "    </div>";
         AV8HTML += "    <div class=\"footer\">";
         AV8HTML += "        <p>Este é um e-mail automático. Não responda.</p>";
         AV8HTML += "    </div>";
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
         /* GeneXus formulas. */
      }

      private string AV8HTML ;
      private string AV9PropostaClienteRazaoSocial ;
      private string aP1_HTML ;
   }

}
