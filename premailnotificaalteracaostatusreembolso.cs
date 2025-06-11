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
   public class premailnotificaalteracaostatusreembolso : GXProcedure
   {
      public premailnotificaalteracaostatusreembolso( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public premailnotificaalteracaostatusreembolso( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_ClienteRazaoSocial ,
                           string aP1_ReembolsoProtocolo ,
                           out string aP2_HTML )
      {
         this.AV9ClienteRazaoSocial = aP0_ClienteRazaoSocial;
         this.AV10ReembolsoProtocolo = aP1_ReembolsoProtocolo;
         this.AV8HTML = "" ;
         initialize();
         ExecuteImpl();
         aP2_HTML=this.AV8HTML;
      }

      public string executeUdp( string aP0_ClienteRazaoSocial ,
                                string aP1_ReembolsoProtocolo )
      {
         execute(aP0_ClienteRazaoSocial, aP1_ReembolsoProtocolo, out aP2_HTML);
         return AV8HTML ;
      }

      public void executeSubmit( string aP0_ClienteRazaoSocial ,
                                 string aP1_ReembolsoProtocolo ,
                                 out string aP2_HTML )
      {
         this.AV9ClienteRazaoSocial = aP0_ClienteRazaoSocial;
         this.AV10ReembolsoProtocolo = aP1_ReembolsoProtocolo;
         this.AV8HTML = "" ;
         SubmitImpl();
         aP2_HTML=this.AV8HTML;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8HTML += "<!DOCTYPE html>";
         AV8HTML += "<html lang=\"en\">";
         AV8HTML += "<head>";
         AV8HTML += "    <meta charset=\"UTF-8\">";
         AV8HTML += "    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">";
         AV8HTML += "    <title>Notificação de Reembolso</title>";
         AV8HTML += "    <style>";
         AV8HTML += "        body {";
         AV8HTML += "            font-family: Arial, sans-serif;";
         AV8HTML += "            margin: 0;";
         AV8HTML += "            padding: 0;";
         AV8HTML += "            background-color: #f4f4f4;";
         AV8HTML += "            color: #333;";
         AV8HTML += "        }";
         AV8HTML += "        .email-container {";
         AV8HTML += "            max-width: 600px;";
         AV8HTML += "            margin: 20px auto;";
         AV8HTML += "            background: #ffffff;";
         AV8HTML += "            border-radius: 8px;";
         AV8HTML += "            overflow: hidden;";
         AV8HTML += "            box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);";
         AV8HTML += "        }";
         AV8HTML += "        .email-header {";
         AV8HTML += "            background-color: #08A086;";
         AV8HTML += "            color: #ffffff;";
         AV8HTML += "            padding: 20px;";
         AV8HTML += "            text-align: center;";
         AV8HTML += "        }";
         AV8HTML += "        .email-header h1 {";
         AV8HTML += "            margin: 0;";
         AV8HTML += "            font-size: 24px;";
         AV8HTML += "        }";
         AV8HTML += "        .email-body {";
         AV8HTML += "            padding: 20px;";
         AV8HTML += "        }";
         AV8HTML += "        .email-body p {";
         AV8HTML += "            font-size: 16px;";
         AV8HTML += "            line-height: 1.5;";
         AV8HTML += "            margin: 10px 0;";
         AV8HTML += "        }";
         AV8HTML += "        .email-body .highlight {";
         AV8HTML += "            color: #08A086;";
         AV8HTML += "            font-weight: bold;";
         AV8HTML += "        }";
         AV8HTML += "        .email-footer {";
         AV8HTML += "            background-color: #f4f4f4;";
         AV8HTML += "            text-align: center;";
         AV8HTML += "            padding: 10px;";
         AV8HTML += "            font-size: 14px;";
         AV8HTML += "            color: #666;";
         AV8HTML += "        }";
         AV8HTML += "        .email-footer a {";
         AV8HTML += "            color: #08A086;";
         AV8HTML += "            text-decoration: none;";
         AV8HTML += "        }";
         AV8HTML += "    </style>";
         AV8HTML += "</head>";
         AV8HTML += "<body>";
         AV8HTML += "    <div class=\"email-container\">";
         AV8HTML += "        <div class=\"email-header\">";
         AV8HTML += "            <h1>Status do Reembolso Alterado</h1>";
         AV8HTML += "        </div>";
         AV8HTML += "        <div class=\"email-body\">";
         GXt_char1 = AV8HTML;
         new initcap(context ).execute(  AV9ClienteRazaoSocial, out  GXt_char1) ;
         AV8HTML += StringUtil.Format( "            <p>Prezado(a) %1,</p>", GXt_char1, "", "", "", "", "", "", "", "");
         AV8HTML += StringUtil.Format( "            <p>Gostaríamos de informar que o status do seu reembolso (%1) foi atualizado. Por favor, acesse o sistema para mais detalhes.</p>", AV10ReembolsoProtocolo, "", "", "", "", "", "", "", "");
         AV8HTML += "            <p>Além disso, títulos a pagar foram gerados para a clínica com base nas informações fornecidas.</p>";
         AV8HTML += "            <p class=\"highlight\">Acesse o sistema para verificar as atualizações e garantir o acompanhamento de seus pagamentos.</p>";
         AV8HTML += "            <p>Atenciosamente,</p>";
         AV8HTML += "            <p><strong>Equipe de Atendimento</strong></p>";
         AV8HTML += "        </div>";
         AV8HTML += "        <div class=\"email-footer\">";
         AV8HTML += "            <p>Este é um e-mail automático, por favor, não responda.</p>";
         AV8HTML += "            <p>Para dúvidas, acesse nosso suporte: <a href=\"#\">Clique aqui</a></p>";
         AV8HTML += "        </div>";
         AV8HTML += "    </div>";
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
         GXt_char1 = "";
         /* GeneXus formulas. */
      }

      private string GXt_char1 ;
      private string AV8HTML ;
      private string AV9ClienteRazaoSocial ;
      private string AV10ReembolsoProtocolo ;
      private string aP2_HTML ;
   }

}
