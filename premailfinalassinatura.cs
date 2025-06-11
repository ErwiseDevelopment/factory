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
   public class premailfinalassinatura : GXProcedure
   {
      public premailfinalassinatura( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public premailfinalassinatura( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_NomeContrato ,
                           string aP1_NomeCompleto ,
                           string aP2_Link ,
                           string aP3_Hash ,
                           out string aP4_HTML )
      {
         this.AV12NomeContrato = aP0_NomeContrato;
         this.AV11NomeCompleto = aP1_NomeCompleto;
         this.AV10Link = aP2_Link;
         this.AV9Hash = aP3_Hash;
         this.AV8HTML = "" ;
         initialize();
         ExecuteImpl();
         aP4_HTML=this.AV8HTML;
      }

      public string executeUdp( string aP0_NomeContrato ,
                                string aP1_NomeCompleto ,
                                string aP2_Link ,
                                string aP3_Hash )
      {
         execute(aP0_NomeContrato, aP1_NomeCompleto, aP2_Link, aP3_Hash, out aP4_HTML);
         return AV8HTML ;
      }

      public void executeSubmit( string aP0_NomeContrato ,
                                 string aP1_NomeCompleto ,
                                 string aP2_Link ,
                                 string aP3_Hash ,
                                 out string aP4_HTML )
      {
         this.AV12NomeContrato = aP0_NomeContrato;
         this.AV11NomeCompleto = aP1_NomeCompleto;
         this.AV10Link = aP2_Link;
         this.AV9Hash = aP3_Hash;
         this.AV8HTML = "" ;
         SubmitImpl();
         aP4_HTML=this.AV8HTML;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8HTML += "<!DOCTYPE html>";
         AV8HTML += "<html lang='pt-BR'>";
         AV8HTML += "<head>";
         AV8HTML += "  <meta charset='UTF-8'>";
         AV8HTML += "  <meta name='viewport' content='width=device-width, initial-scale=1.0'>";
         AV8HTML += "  <style>";
         AV8HTML += "    body {";
         AV8HTML += "      font-family: Arial, sans-serif;";
         AV8HTML += "      margin: 0;";
         AV8HTML += "      padding: 0;";
         AV8HTML += "      background-color: #f4f4f4;";
         AV8HTML += "    }";
         AV8HTML += "    .email-container {";
         AV8HTML += "      max-width: 600px;";
         AV8HTML += "      margin: 20px auto;";
         AV8HTML += "      background-color: #ffffff;";
         AV8HTML += "      border-radius: 8px;";
         AV8HTML += "      box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);";
         AV8HTML += "      overflow: hidden;";
         AV8HTML += "    }";
         AV8HTML += "    .email-header {";
         AV8HTML += "      background-color: #08A086;";
         AV8HTML += "      color: #ffffff;";
         AV8HTML += "      text-align: center;";
         AV8HTML += "      padding: 20px;";
         AV8HTML += "      font-size: 24px;";
         AV8HTML += "      font-weight: bold;";
         AV8HTML += "    }";
         AV8HTML += "    .email-body {";
         AV8HTML += "      padding: 20px;";
         AV8HTML += "      color: #333333;";
         AV8HTML += "      line-height: 1.6;";
         AV8HTML += "    }";
         AV8HTML += "    .email-body p {";
         AV8HTML += "      margin: 10px 0;";
         AV8HTML += "    }";
         AV8HTML += "    .email-body a {";
         AV8HTML += "      color: #08A086;";
         AV8HTML += "      text-decoration: none;";
         AV8HTML += "      font-weight: bold;";
         AV8HTML += "    }";
         AV8HTML += "    .email-footer {";
         AV8HTML += "      text-align: center;";
         AV8HTML += "      padding: 10px;";
         AV8HTML += "      font-size: 14px;";
         AV8HTML += "      color: #666666;";
         AV8HTML += "      background-color: #f4f4f4;";
         AV8HTML += "    }";
         AV8HTML += "    .btn-container {";
         AV8HTML += "      text-align: center;";
         AV8HTML += "      margin: 20px 0;";
         AV8HTML += "    }";
         AV8HTML += "    .btn {";
         AV8HTML += "      display: inline-block;";
         AV8HTML += "      padding: 12px 30px;";
         AV8HTML += "      background-color: #08A086;";
         AV8HTML += "      color: #ffffff !important;";
         AV8HTML += "      text-decoration: none;";
         AV8HTML += "      font-weight: bold;";
         AV8HTML += "      border-radius: 25px;";
         AV8HTML += "      font-size: 16px;";
         AV8HTML += "      box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);";
         AV8HTML += "      transition: background-color 0.3s ease, box-shadow 0.3s ease;";
         AV8HTML += "    }";
         AV8HTML += "    .btn:hover {";
         AV8HTML += "      background-color: #066e63;";
         AV8HTML += "      box-shadow: 0 6px 8px rgba(0, 0, 0, 0.2);";
         AV8HTML += "    }";
         AV8HTML += "    .hash-section {";
         AV8HTML += "      background-color: #f9f9f9;";
         AV8HTML += "      padding: 15px;";
         AV8HTML += "      margin: 20px 0;";
         AV8HTML += "      border: 1px solid #e0e0e0;";
         AV8HTML += "      border-radius: 5px;";
         AV8HTML += "      word-wrap: break-word;";
         AV8HTML += "      font-family: monospace;";
         AV8HTML += "      color: #333;";
         AV8HTML += "    }";
         AV8HTML += "    .hash-label {";
         AV8HTML += "      font-weight: bold;";
         AV8HTML += "      margin-bottom: 10px;";
         AV8HTML += "      display: block;";
         AV8HTML += "    }";
         AV8HTML += "  </style>";
         AV8HTML += "</head>";
         AV8HTML += "<body>";
         AV8HTML += "  <div class='email-container'>";
         AV8HTML += "    <div class='email-header'>";
         AV8HTML += "      Contrato Assinado";
         AV8HTML += "    </div>";
         AV8HTML += "    <div class='email-body'>";
         AV8HTML += StringUtil.Format( "      <p><strong>Nome do Contrato:</strong> %1</p>", AV12NomeContrato, "", "", "", "", "", "", "", "");
         AV8HTML += StringUtil.Format( "      <p>Prezado(a), %1</p>", AV11NomeCompleto, "", "", "", "", "", "", "", "");
         AV8HTML += "      <p>Informamos que o contrato foi assinado por todas as partes envolvidas.</p>";
         AV8HTML += "      <p>Você pode verificar a autenticidade e as assinaturas clicando no botão abaixo:</p>";
         AV8HTML += "      <div class='btn-container'>";
         AV8HTML += StringUtil.Format( "        <a href='%1' class='btn'>Verificar Contrato</a>", AV10Link, "", "", "", "", "", "", "", "");
         AV8HTML += "      </div>";
         AV8HTML += "      <p>Para maior segurança, segue o hash do arquivo assinado:</p>";
         AV8HTML += "      <div class='hash-section'>";
         AV8HTML += "        <span class='hash-label'>Hash do Arquivo:</span>";
         AV8HTML += StringUtil.Format( "        <span id='file-hash'>%1</span>", AV9Hash, "", "", "", "", "", "", "", "");
         AV8HTML += "      </div>";
         AV8HTML += "    </div>";
         AV8HTML += "    <div class='email-footer'>";
         AV8HTML += "      © 2024 Erwise - Todos os direitos reservados.";
         AV8HTML += "    </div>";
         AV8HTML += "  </div>";
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
      private string AV12NomeContrato ;
      private string AV11NomeCompleto ;
      private string AV10Link ;
      private string AV9Hash ;
      private string aP4_HTML ;
   }

}
