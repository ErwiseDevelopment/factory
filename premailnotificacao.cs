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
   public class premailnotificacao : GXProcedure
   {
      public premailnotificacao( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public premailnotificacao( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out string aP0_HTML )
      {
         this.AV8HTML = "" ;
         initialize();
         ExecuteImpl();
         aP0_HTML=this.AV8HTML;
      }

      public string executeUdp( )
      {
         execute(out aP0_HTML);
         return AV8HTML ;
      }

      public void executeSubmit( out string aP0_HTML )
      {
         this.AV8HTML = "" ;
         SubmitImpl();
         aP0_HTML=this.AV8HTML;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8HTML += "<!DOCTYPE html>";
         AV8HTML += "<html lang=\"pt\">";
         AV8HTML += "<head>";
         AV8HTML += "    <meta charset=\"UTF-8\">";
         AV8HTML += "    <title>Notificação de Nova Proposta</title>";
         AV8HTML += "    <style>";
         AV8HTML += "        body {";
         AV8HTML += "            font-family: Arial, sans-serif;";
         AV8HTML += "            background-color: #f4f4f4;";
         AV8HTML += "            margin: 0;";
         AV8HTML += "            padding: 0;";
         AV8HTML += "        }";
         AV8HTML += "        .email-container {";
         AV8HTML += "            background-color: #ffffff;";
         AV8HTML += "            width: 100%;";
         AV8HTML += "            max-width: 600px;";
         AV8HTML += "            margin: auto;";
         AV8HTML += "            border: 1px solid #dddddd;";
         AV8HTML += "        }";
         AV8HTML += "        .email-header {";
         AV8HTML += "            background-color: #08A086;";
         AV8HTML += "            color: #ffffff;";
         AV8HTML += "            padding: 20px;";
         AV8HTML += "            text-align: center;";
         AV8HTML += "        }";
         AV8HTML += "        .email-content {";
         AV8HTML += "            padding: 20px;";
         AV8HTML += "        }";
         AV8HTML += "        .email-content p {";
         AV8HTML += "            font-size: 16px;";
         AV8HTML += "            color: #333333;";
         AV8HTML += "            line-height: 1.5;";
         AV8HTML += "        }";
         AV8HTML += "        .email-footer {";
         AV8HTML += "            background-color: #eeeeee;";
         AV8HTML += "            color: #777777;";
         AV8HTML += "            padding: 10px;";
         AV8HTML += "            text-align: center;";
         AV8HTML += "            font-size: 12px;";
         AV8HTML += "        }";
         AV8HTML += "        .button {";
         AV8HTML += "            background-color: #08A086;";
         AV8HTML += "            color: #ffffff;";
         AV8HTML += "            padding: 10px 20px;";
         AV8HTML += "            text-decoration: none;";
         AV8HTML += "            display: inline-block;";
         AV8HTML += "            margin-top: 20px;";
         AV8HTML += "            border-radius: 5px;";
         AV8HTML += "        }";
         AV8HTML += "        .button:hover {";
         AV8HTML += "            background-color: #067a6d;";
         AV8HTML += "        }";
         AV8HTML += "    </style>";
         AV8HTML += "</head>";
         AV8HTML += "<body>";
         AV8HTML += "    <div class=\"email-container\">";
         AV8HTML += "        <div class=\"email-header\">";
         AV8HTML += "            <h1>Nova Proposta Recebida</h1>";
         AV8HTML += "        </div>";
         AV8HTML += "        <div class=\"email-content\">";
         AV8HTML += "            <p>Prezado(a),</p>";
         AV8HTML += "            <p>Há uma nova proposta que requer sua análise.</p>";
         AV8HTML += "            <p>Por favor, acesse o sistema para revisar os detalhes da proposta.</p>";
         AV8HTML += "            ";
         AV8HTML += "        </div>";
         AV8HTML += "        <div class=\"email-footer\">";
         AV8HTML += "            <p>Este é um e-mail automático. Por favor, não responda.</p>";
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
         /* GeneXus formulas. */
      }

      private string AV8HTML ;
      private string aP0_HTML ;
   }

}
