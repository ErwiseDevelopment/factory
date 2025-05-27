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
   public class premailnotificainicioreembolso : GXProcedure
   {
      public premailnotificainicioreembolso( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public premailnotificainicioreembolso( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_PacienteNome ,
                           DateTime aP1_DataInicio ,
                           out string aP2_HTML )
      {
         this.AV10PacienteNome = aP0_PacienteNome;
         this.AV9DataInicio = aP1_DataInicio;
         this.AV8HTML = "" ;
         initialize();
         ExecuteImpl();
         aP2_HTML=this.AV8HTML;
      }

      public string executeUdp( string aP0_PacienteNome ,
                                DateTime aP1_DataInicio )
      {
         execute(aP0_PacienteNome, aP1_DataInicio, out aP2_HTML);
         return AV8HTML ;
      }

      public void executeSubmit( string aP0_PacienteNome ,
                                 DateTime aP1_DataInicio ,
                                 out string aP2_HTML )
      {
         this.AV10PacienteNome = aP0_PacienteNome;
         this.AV9DataInicio = aP1_DataInicio;
         this.AV8HTML = "" ;
         SubmitImpl();
         aP2_HTML=this.AV8HTML;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8HTML += "<!DOCTYPE html>";
         AV8HTML += "<html lang=\"pt-BR\">";
         AV8HTML += "<head>";
         AV8HTML += "    <meta charset=\"UTF-8\">";
         AV8HTML += "    <title>Processo de Reembolso Iniciado</title>";
         AV8HTML += "    <style>";
         AV8HTML += "        body {";
         AV8HTML += "            font-family: Arial, sans-serif;";
         AV8HTML += "            background-color: #f4f4f4;";
         AV8HTML += "            margin: 0;";
         AV8HTML += "            padding: 0;";
         AV8HTML += "        }";
         AV8HTML += "        .email-container {";
         AV8HTML += "            max-width: 600px;";
         AV8HTML += "            margin: 30px auto;";
         AV8HTML += "            background-color: #ffffff;";
         AV8HTML += "            border: 1px solid #dddddd;";
         AV8HTML += "            border-radius: 5px;";
         AV8HTML += "            overflow: hidden;";
         AV8HTML += "        }";
         AV8HTML += "        .header {";
         AV8HTML += "            background-color: #08A086;";
         AV8HTML += "            color: #ffffff;";
         AV8HTML += "            padding: 20px;";
         AV8HTML += "            text-align: center;";
         AV8HTML += "        }";
         AV8HTML += "        .content {";
         AV8HTML += "            padding: 20px;";
         AV8HTML += "            color: #333333;";
         AV8HTML += "        }";
         AV8HTML += "        .footer {";
         AV8HTML += "            background-color: #f4f4f4;";
         AV8HTML += "            color: #777777;";
         AV8HTML += "            text-align: center;";
         AV8HTML += "            padding: 15px;";
         AV8HTML += "            font-size: 12px;";
         AV8HTML += "        }";
         AV8HTML += "        .button {";
         AV8HTML += "            display: inline-block;";
         AV8HTML += "            padding: 10px 20px;";
         AV8HTML += "            background-color: #08A086;";
         AV8HTML += "            color: #ffffff;";
         AV8HTML += "            text-decoration: none;";
         AV8HTML += "            border-radius: 3px;";
         AV8HTML += "            margin-top: 20px;";
         AV8HTML += "        }";
         AV8HTML += "        @media only screen and (max-width: 600px) {";
         AV8HTML += "            .email-container {";
         AV8HTML += "                width: 100% !important;";
         AV8HTML += "            }";
         AV8HTML += "        }";
         AV8HTML += "    </style>";
         AV8HTML += "</head>";
         AV8HTML += "<body>";
         AV8HTML += "    <div class=\"email-container\">";
         AV8HTML += "        <div class=\"header\">";
         AV8HTML += "            <h1>Atualização de Reembolso</h1>";
         AV8HTML += "        </div>";
         AV8HTML += "        <div class=\"content\">";
         AV8HTML += "            <p>Prezado(a),</p>";
         AV8HTML += StringUtil.Format( "            <p>Estamos felizes em informar que o processo de reembolso referente à proposta do paciente %1 foi iniciado com sucesso.</p>", AV10PacienteNome, "", "", "", "", "", "", "", "");
         AV8HTML += "            <p><strong>Detalhes do Reembolso:</strong></p>";
         AV8HTML += "            <ul>";
         AV8HTML += StringUtil.Format( "                <li><strong>Data de Início:</strong> %1</li>", context.localUtil.TToC( AV9DataInicio, 10, 5, 0, 3, "/", ":", " "), "", "", "", "", "", "", "", "");
         AV8HTML += "            </ul>";
         AV8HTML += "        </div>";
         AV8HTML += "        <div class=\"footer\">";
         AV8HTML += "            <p>© 2024 Erwise. Todos os direitos reservados.</p>";
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

      private DateTime AV9DataInicio ;
      private string AV8HTML ;
      private string AV10PacienteNome ;
      private string aP2_HTML ;
   }

}
