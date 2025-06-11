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
   public class prestilocomprovante : GXProcedure
   {
      public prestilocomprovante( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prestilocomprovante( IGxContext context )
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
         AV8HTML += "<style>";
         AV8HTML += "        /* Paleta de cores */";
         AV8HTML += "        :root {";
         AV8HTML += "            --primary-color: #08A086; /* Atualizado para #08A086 */";
         AV8HTML += "            --secondary-color: #6c757d;";
         AV8HTML += "            --success-color: #28a745;";
         AV8HTML += "            --info-color: #17a2b8;";
         AV8HTML += "            --warning-color: #ffc107;";
         AV8HTML += "            --danger-color: #dc3545;";
         AV8HTML += "            --light-color: #f8f9fa;";
         AV8HTML += "            --dark-color: #343a40;";
         AV8HTML += "            --background-color: #f2f2f2;";
         AV8HTML += "            --text-color: #212529;";
         AV8HTML += "        }";
         AV8HTML += "";
         AV8HTML += "        /* Estilos gerais aplicados ao contêiner principal */";
         AV8HTML += "        .proposta-page {";
         AV8HTML += "            font-family: 'Roboto', Arial, sans-serif;";
         AV8HTML += "            background-color: var(--background-color);";
         AV8HTML += "            margin: 0;";
         AV8HTML += "            padding: 0;";
         AV8HTML += "            color: var(--text-color);";
         AV8HTML += "        }";
         AV8HTML += "        .proposta-container {";
         AV8HTML += "            max-width: 1200px;";
         AV8HTML += "            margin: 30px auto;";
         AV8HTML += "            background-color: #fff;";
         AV8HTML += "            padding: 20px;";
         AV8HTML += "            box-shadow: 0 0 10px #ccc;";
         AV8HTML += "            border-radius: 8px;";
         AV8HTML += "            position: relative;";
         AV8HTML += "            /* Evita quebra de página antes do contêiner */";
         AV8HTML += "            page-break-inside: avoid;";
         AV8HTML += "        }";
         AV8HTML += "        .proposta-container h1 {";
         AV8HTML += "            text-align: center;";
         AV8HTML += "            color: var(--primary-color);";
         AV8HTML += "            font-size: 28px;";
         AV8HTML += "            margin-bottom: 10px;";
         AV8HTML += "            font-family: 'Roboto', Arial, sans-serif;";
         AV8HTML += "            /* Evita quebra de página após o título */";
         AV8HTML += "            page-break-after: avoid;";
         AV8HTML += "        }";
         AV8HTML += "        .proposta-message {";
         AV8HTML += "            font-size: 18px;";
         AV8HTML += "            margin-bottom: 20px;";
         AV8HTML += "            text-align: center;";
         AV8HTML += "            color: var(--secondary-color);";
         AV8HTML += "            font-family: 'Roboto', Arial, sans-serif;";
         AV8HTML += "        }";
         AV8HTML += "        .proposta-section {";
         AV8HTML += "            margin-bottom: 20px;";
         AV8HTML += "            /* Evita quebra de página dentro das seções */";
         AV8HTML += "            page-break-inside: avoid;";
         AV8HTML += "        }";
         AV8HTML += "        .proposta-section h2 {";
         AV8HTML += "            color: var(--dark-color);";
         AV8HTML += "            border-bottom: 2px solid var(--primary-color);";
         AV8HTML += "            padding-bottom: 5px;";
         AV8HTML += "            margin-bottom: 15px;";
         AV8HTML += "            font-size: 22px;";
         AV8HTML += "            font-family: 'Roboto', Arial, sans-serif;";
         AV8HTML += "            /* Evita quebra de página após o título da seção */";
         AV8HTML += "            page-break-after: avoid;";
         AV8HTML += "        }";
         AV8HTML += "        /* Ajuste para duas colunas */";
         AV8HTML += "        .proposta-info-group {";
         AV8HTML += "            display: flex;";
         AV8HTML += "            flex-wrap: wrap;";
         AV8HTML += "        }";
         AV8HTML += "    .proposta-info-item {";
         AV8HTML += "      width: 100%; /* Ajuste para que cada item ocupe a largura completa */";
         AV8HTML += "      box-sizing: border-box;";
         AV8HTML += "      padding: 10px;";
         AV8HTML += "      display: flex;";
         AV8HTML += "      flex-direction: column; /* Alteração para alinhamento em coluna */";
         AV8HTML += "      align-items: flex-start; /* Alinhamento à esquerda */";
         AV8HTML += "      page-break-inside: avoid;";
         AV8HTML += "      margin-bottom: 15px;";
         AV8HTML += "    }";
         AV8HTML += "    .proposta-label {";
         AV8HTML += "      font-weight: bold;";
         AV8HTML += "      background-color: var(--light-color);";
         AV8HTML += "      padding: 10px;";
         AV8HTML += "      width: 100%; /* Largura total */";
         AV8HTML += "      box-sizing: border-box;";
         AV8HTML += "      display: flex;";
         AV8HTML += "      align-items: center;";
         AV8HTML += "      border-radius: 5px 5px 0 0;";
         AV8HTML += "      font-family: 'Roboto', Arial, sans-serif;";
         AV8HTML += "      margin-bottom: 5px; /* Espaço entre rótulo e valor */";
         AV8HTML += "    }";
         AV8HTML += "        .proposta-label i {";
         AV8HTML += "            margin-right: 8px;";
         AV8HTML += "            color: var(--primary-color);";
         AV8HTML += "        }";
         AV8HTML += "    .proposta-value {";
         AV8HTML += "      padding: 10px;";
         AV8HTML += "      width: 100%; /* Largura total */";
         AV8HTML += "      box-sizing: border-box;";
         AV8HTML += "      background-color: #fff;";
         AV8HTML += "      border: 1px solid #dee2e6;";
         AV8HTML += "      border-left: none;";
         AV8HTML += "      border-radius: 0 0 5px 5px;";
         AV8HTML += "      font-family: 'Roboto', Arial, sans-serif;";
         AV8HTML += "    }";
         AV8HTML += "        .proposta-footer {";
         AV8HTML += "            text-align: center;";
         AV8HTML += "            color: var(--secondary-color);";
         AV8HTML += "            font-size: 14px;";
         AV8HTML += "            margin-top: 30px;";
         AV8HTML += "            /* Evita quebra de página dentro do rodapé */";
         AV8HTML += "            page-break-inside: avoid;";
         AV8HTML += "            font-family: 'Roboto', Arial, sans-serif;";
         AV8HTML += "        }";
         AV8HTML += "    .proposta-download-btn {";
         AV8HTML += "      display: block;";
         AV8HTML += "      margin: 20px auto;";
         AV8HTML += "      padding: 12px 24px;";
         AV8HTML += "      background-color: var(--primary-color);";
         AV8HTML += "      color: #fff;";
         AV8HTML += "      border: none;";
         AV8HTML += "      border-radius: 6px;";
         AV8HTML += "      font-size: 16px;";
         AV8HTML += "      cursor: pointer;";
         AV8HTML += "      transition: background-color 0.3s ease, transform 0.2s ease, box-shadow 0.3s ease;";
         AV8HTML += "      box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);";
         AV8HTML += "    }";
         AV8HTML += "    .proposta-download-btn i {";
         AV8HTML += "      margin-right: 8px;";
         AV8HTML += "      color: #fff;";
         AV8HTML += "    }";
         AV8HTML += "    .proposta-download-btn:hover {";
         AV8HTML += "      background-color: #067e6b;";
         AV8HTML += "      transform: translateY(-2px);";
         AV8HTML += "      box-shadow: 0 6px 8px rgba(0, 0, 0, 0.15);";
         AV8HTML += "    }";
         AV8HTML += "    .proposta-download-btn:active {";
         AV8HTML += "      transform: translateY(0);";
         AV8HTML += "      box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);";
         AV8HTML += "    }";
         AV8HTML += "</style>";
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
