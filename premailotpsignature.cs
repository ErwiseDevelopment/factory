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
   public class premailotpsignature : GXProcedure
   {
      public premailotpsignature( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public premailotpsignature( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_ParticipanteNome ,
                           string aP1_Codigo ,
                           out string aP2_HTML )
      {
         this.AV8ParticipanteNome = aP0_ParticipanteNome;
         this.AV9Codigo = aP1_Codigo;
         this.AV10HTML = "" ;
         initialize();
         ExecuteImpl();
         aP2_HTML=this.AV10HTML;
      }

      public string executeUdp( string aP0_ParticipanteNome ,
                                string aP1_Codigo )
      {
         execute(aP0_ParticipanteNome, aP1_Codigo, out aP2_HTML);
         return AV10HTML ;
      }

      public void executeSubmit( string aP0_ParticipanteNome ,
                                 string aP1_Codigo ,
                                 out string aP2_HTML )
      {
         this.AV8ParticipanteNome = aP0_ParticipanteNome;
         this.AV9Codigo = aP1_Codigo;
         this.AV10HTML = "" ;
         SubmitImpl();
         aP2_HTML=this.AV10HTML;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10HTML = "<!DOCTYPE html>";
         AV10HTML += "<html lang=\"en\">";
         AV10HTML += "<head>";
         AV10HTML += "    <meta charset=\"UTF-8\">";
         AV10HTML += "    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">";
         AV10HTML += "    <title>Código OTP</title>";
         AV10HTML += "    <style>";
         AV10HTML += "        body {";
         AV10HTML += "            font-family: Arial, sans-serif;";
         AV10HTML += "            background-color: #f4f4f9;";
         AV10HTML += "            margin: 0;";
         AV10HTML += "            padding: 0;";
         AV10HTML += "        }";
         AV10HTML += "        .email-container {";
         AV10HTML += "            max-width: 600px;";
         AV10HTML += "            margin: 20px auto;";
         AV10HTML += "            background: #fff;";
         AV10HTML += "            border: 1px solid #ddd;";
         AV10HTML += "            border-radius: 8px;";
         AV10HTML += "            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);";
         AV10HTML += "            overflow: hidden;";
         AV10HTML += "        }";
         AV10HTML += "        .email-header {";
         AV10HTML += "            background-color: #08A086;";
         AV10HTML += "            color: #fff;";
         AV10HTML += "            text-align: center;";
         AV10HTML += "            padding: 20px;";
         AV10HTML += "            font-size: 24px;";
         AV10HTML += "        }";
         AV10HTML += "        .email-body {";
         AV10HTML += "            padding: 20px;";
         AV10HTML += "            color: #333;";
         AV10HTML += "            text-align: center;";
         AV10HTML += "        }";
         AV10HTML += "        .email-body p {";
         AV10HTML += "            font-size: 16px;";
         AV10HTML += "            line-height: 1.6;";
         AV10HTML += "            margin-bottom: 20px;";
         AV10HTML += "        }";
         AV10HTML += "        .otp-code {";
         AV10HTML += "            display: inline-block;";
         AV10HTML += "            font-size: 32px;";
         AV10HTML += "            font-weight: bold;";
         AV10HTML += "            color: #08A086;";
         AV10HTML += "            background: #f1f9f8;";
         AV10HTML += "            padding: 10px 20px;";
         AV10HTML += "            border-radius: 5px;";
         AV10HTML += "            margin-top: 10px;";
         AV10HTML += "            text-align: center;";
         AV10HTML += "        }";
         AV10HTML += "        .email-footer {";
         AV10HTML += "            text-align: center;";
         AV10HTML += "            background-color: #f4f4f9;";
         AV10HTML += "            color: #999;";
         AV10HTML += "            font-size: 14px;";
         AV10HTML += "            padding: 10px;";
         AV10HTML += "        }";
         AV10HTML += "    </style>";
         AV10HTML += "</head>";
         AV10HTML += "<body>";
         AV10HTML += "    <div class=\"email-container\">";
         AV10HTML += "        <div class=\"email-header\">";
         AV10HTML += "            Verificação de Identidade";
         AV10HTML += "        </div>";
         AV10HTML += "        <div class=\"email-body\">";
         AV10HTML += StringUtil.Format( "            <p>Olá, %1</p>", AV8ParticipanteNome, "", "", "", "", "", "", "", "");
         AV10HTML += "            <p>Para iniciar sua assinatura digital, insira o código abaixo no campo solicitado:</p>";
         AV10HTML += "            <div>";
         AV10HTML += StringUtil.Format( "                <span class=\"otp-code\">%1</span>", AV9Codigo, "", "", "", "", "", "", "", "");
         AV10HTML += "            </div>";
         AV10HTML += "            <p>Este código expira em 10 minutos. Caso não tenha solicitado esta operação, desconsidere este e-mail.</p>";
         AV10HTML += "        </div>";
         AV10HTML += "        <div class=\"email-footer\">";
         AV10HTML += "            © 2024 Erwise. Todos os direitos reservados.";
         AV10HTML += "        </div>";
         AV10HTML += "    </div>";
         AV10HTML += "</body>";
         AV10HTML += "</html>";
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
         AV10HTML = "";
         /* GeneXus formulas. */
      }

      private string AV10HTML ;
      private string AV8ParticipanteNome ;
      private string AV9Codigo ;
      private string aP2_HTML ;
   }

}
