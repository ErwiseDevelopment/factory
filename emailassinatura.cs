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
   public class emailassinatura : GXProcedure
   {
      public emailassinatura( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public emailassinatura( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GXBaseCollection<SdtSdParticipantes> aP0_Array_SdParticipantes ,
                           int aP1_ParticipanteId ,
                           string aP2_ParticipanteNome ,
                           string aP3_ContratoNome ,
                           string aP4_EmpresaRazaoSocial ,
                           string aP5_Link ,
                           out string aP6_HTML )
      {
         this.AV10Array_SdParticipantes = aP0_Array_SdParticipantes;
         this.AV11ParticipanteId = aP1_ParticipanteId;
         this.AV12ParticipanteNome = aP2_ParticipanteNome;
         this.AV13ContratoNome = aP3_ContratoNome;
         this.AV15EmpresaRazaoSocial = aP4_EmpresaRazaoSocial;
         this.AV14Link = aP5_Link;
         this.AV8HTML = "" ;
         initialize();
         ExecuteImpl();
         aP6_HTML=this.AV8HTML;
      }

      public string executeUdp( GXBaseCollection<SdtSdParticipantes> aP0_Array_SdParticipantes ,
                                int aP1_ParticipanteId ,
                                string aP2_ParticipanteNome ,
                                string aP3_ContratoNome ,
                                string aP4_EmpresaRazaoSocial ,
                                string aP5_Link )
      {
         execute(aP0_Array_SdParticipantes, aP1_ParticipanteId, aP2_ParticipanteNome, aP3_ContratoNome, aP4_EmpresaRazaoSocial, aP5_Link, out aP6_HTML);
         return AV8HTML ;
      }

      public void executeSubmit( GXBaseCollection<SdtSdParticipantes> aP0_Array_SdParticipantes ,
                                 int aP1_ParticipanteId ,
                                 string aP2_ParticipanteNome ,
                                 string aP3_ContratoNome ,
                                 string aP4_EmpresaRazaoSocial ,
                                 string aP5_Link ,
                                 out string aP6_HTML )
      {
         this.AV10Array_SdParticipantes = aP0_Array_SdParticipantes;
         this.AV11ParticipanteId = aP1_ParticipanteId;
         this.AV12ParticipanteNome = aP2_ParticipanteNome;
         this.AV13ContratoNome = aP3_ContratoNome;
         this.AV15EmpresaRazaoSocial = aP4_EmpresaRazaoSocial;
         this.AV14Link = aP5_Link;
         this.AV8HTML = "" ;
         SubmitImpl();
         aP6_HTML=this.AV8HTML;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8HTML += "<!DOCTYPE html>";
         AV8HTML += "<html lang=\"pt-BR\">";
         AV8HTML += "<head>";
         AV8HTML += "    <meta charset=\"UTF-8\">";
         AV8HTML += "    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">";
         AV8HTML += "    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">";
         AV8HTML += "    <title>Documento para Assinatura</title>";
         AV8HTML += "    <style>";
         AV8HTML += "        body {";
         AV8HTML += "            margin: 0;";
         AV8HTML += "            padding: 0;";
         AV8HTML += "            background-color: #f4f4f4;";
         AV8HTML += "        }";
         AV8HTML += "        table {";
         AV8HTML += "            border-collapse: collapse;";
         AV8HTML += "        }";
         AV8HTML += "    </style>";
         AV8HTML += "</head>";
         AV8HTML += "<body style=\"margin: 0; padding: 0; background-color: #f4f4f4;\">";
         AV8HTML += "    <table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"font-family: Arial, sans-serif; font-size: 14px; color: #000;\">";
         AV8HTML += "        <tr>";
         AV8HTML += "            <td align=\"center\">";
         AV8HTML += "                <table width=\"600\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"background-color: #ffffff; border: 1px solid #dddddd;\">";
         AV8HTML += "                    <tr>";
         AV8HTML += "                        <td align=\"center\" style=\"padding: 20px;\">";
         AV8HTML += "                            <img src=\"https://ci3.googleusercontent.com/meips/ADKq_NaX-Xb8Y1BlhN-xaxsftvcXLE0n8O9QXUnWE_QsIqvIxUH6rMqZ2xpC2L1TxUMM68-9vSLejcfl-qwCM1RqOLaTYFwY1JY=s0-d-e1-ft#https://painel.erwise.com.br/assets/img/logo.png\" alt=\"Erwise Dev\" style=\"display: block;\">";
         AV8HTML += "                        </td>";
         AV8HTML += "                    </tr>";
         AV8HTML += "                    <tr>";
         AV8HTML += "                        <td align=\"left\" style=\"padding: 0 20px 20px;\">";
         AV8HTML += StringUtil.Format( "                            <h2 style=\"font-size: 18px; color: #800080; margin-bottom: 10px;\">%1 enviou um documento para você assinar</h2>", AV15EmpresaRazaoSocial, "", "", "", "", "", "", "", "");
         AV8HTML += StringUtil.Format( "                            <p>Olá %1,</p>", AV12ParticipanteNome, "", "", "", "", "", "", "", "");
         AV8HTML += StringUtil.Format( "                            <p>A solicitação a sua assinatura para a contratação \"<strong>%1</strong>\"</p>", AV13ContratoNome, "", "", "", "", "", "", "", "");
         AV8HTML += "                            <p><strong>Assinantes da contratação:</strong></p>";
         AV8HTML += "                            <ul style=\"list-style-type: none; padding: 0;\">";
         AV16GXV1 = 1;
         while ( AV16GXV1 <= AV10Array_SdParticipantes.Count )
         {
            AV9SdParticipantes = ((SdtSdParticipantes)AV10Array_SdParticipantes.Item(AV16GXV1));
            if ( AV9SdParticipantes.gxTpr_Participanteid == AV11ParticipanteId )
            {
               AV8HTML += StringUtil.Format( "                                <li style=\"font-weigth:bold;\">%1 (%2)</li>", AV9SdParticipantes.gxTpr_Participantenome, AV9SdParticipantes.gxTpr_Assinaturaparticipantetipo, "", "", "", "", "", "", "");
            }
            else
            {
               AV8HTML += StringUtil.Format( "                                <li>%1 (%2)</li>", AV9SdParticipantes.gxTpr_Participantenome, AV9SdParticipantes.gxTpr_Assinaturaparticipantetipo, "", "", "", "", "", "", "");
            }
            AV16GXV1 = (int)(AV16GXV1+1);
         }
         AV8HTML += "                            </ul>";
         AV8HTML += "                        </td>";
         AV8HTML += "                    </tr>";
         AV8HTML += "                    <tr>";
         AV8HTML += "                        <td align=\"center\" style=\"padding: 20px;\">";
         AV8HTML += StringUtil.Format( "                            <a href=\"%1\" style=\"display: inline-block; background-color: #08A086; color: #ffffff; text-decoration: none; padding: 12px 24px; border-radius: 5px; font-weight: bold;\">", AV14Link, "", "", "", "", "", "", "", "");
         AV8HTML += "                                Visualizar documento para assinatura";
         AV8HTML += "                            </a>";
         AV8HTML += "                        </td>";
         AV8HTML += "                    </tr>";
         AV8HTML += "                    <tr>";
         AV8HTML += "                        <td align=\"center\" style=\"padding: 20px; font-size: 12px; color: #666;\">";
         AV8HTML += "                            Este é um serviço de assinatura por meio eletrônico com proteção legal e validade jurídica que a utiliza para ativar contratações sem o uso de papel impresso.";
         AV8HTML += "                        </td>";
         AV8HTML += "                    </tr>";
         AV8HTML += "                </table>";
         AV8HTML += "            </td>";
         AV8HTML += "        </tr>";
         AV8HTML += "    </table>";
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
         AV9SdParticipantes = new SdtSdParticipantes(context);
         /* GeneXus formulas. */
      }

      private int AV11ParticipanteId ;
      private int AV16GXV1 ;
      private string AV8HTML ;
      private string AV12ParticipanteNome ;
      private string AV13ContratoNome ;
      private string AV15EmpresaRazaoSocial ;
      private string AV14Link ;
      private GXBaseCollection<SdtSdParticipantes> AV10Array_SdParticipantes ;
      private SdtSdParticipantes AV9SdParticipantes ;
      private string aP6_HTML ;
   }

}
