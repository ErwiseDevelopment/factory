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
   public class prhtmlfimcontratoconsulta : GXProcedure
   {
      public prhtmlfimcontratoconsulta( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prhtmlfimcontratoconsulta( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_ContratoNome ,
                           Guid aP1_AssinaturaPublicKey ,
                           DateTime aP2_AssinaturaFinalizadoData ,
                           GXBaseCollection<SdtSdParticipantesContrato> aP3_Array_SdParticipantesContrato ,
                           out string aP4_HTML )
      {
         this.AV11ContratoNome = aP0_ContratoNome;
         this.AV12AssinaturaPublicKey = aP1_AssinaturaPublicKey;
         this.AV15AssinaturaFinalizadoData = aP2_AssinaturaFinalizadoData;
         this.AV10Array_SdParticipantesContrato = aP3_Array_SdParticipantesContrato;
         this.AV8HTML = "" ;
         initialize();
         ExecuteImpl();
         aP4_HTML=this.AV8HTML;
      }

      public string executeUdp( string aP0_ContratoNome ,
                                Guid aP1_AssinaturaPublicKey ,
                                DateTime aP2_AssinaturaFinalizadoData ,
                                GXBaseCollection<SdtSdParticipantesContrato> aP3_Array_SdParticipantesContrato )
      {
         execute(aP0_ContratoNome, aP1_AssinaturaPublicKey, aP2_AssinaturaFinalizadoData, aP3_Array_SdParticipantesContrato, out aP4_HTML);
         return AV8HTML ;
      }

      public void executeSubmit( string aP0_ContratoNome ,
                                 Guid aP1_AssinaturaPublicKey ,
                                 DateTime aP2_AssinaturaFinalizadoData ,
                                 GXBaseCollection<SdtSdParticipantesContrato> aP3_Array_SdParticipantesContrato ,
                                 out string aP4_HTML )
      {
         this.AV11ContratoNome = aP0_ContratoNome;
         this.AV12AssinaturaPublicKey = aP1_AssinaturaPublicKey;
         this.AV15AssinaturaFinalizadoData = aP2_AssinaturaFinalizadoData;
         this.AV10Array_SdParticipantesContrato = aP3_Array_SdParticipantesContrato;
         this.AV8HTML = "" ;
         SubmitImpl();
         aP4_HTML=this.AV8HTML;
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
         AV8HTML += "    <title>Lista de Assinaturas</title>";
         AV8HTML += "    <link rel=\"stylesheet\" href=\"https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css\">";
         AV8HTML += "	  <script src=\"https://cdnjs.cloudflare.com/ajax/libs/qrcodejs/1.0.0/qrcode.min.js\"></script>";
         AV8HTML += "    <style>";
         AV8HTML += "body{font-family: Arial, sans-serif;}";
         AV8HTML += ".container { font-family: Arial, sans-serif; background-color: #f9f9f9; margin: 20px; padding: 20px; border: 1px solid #ccc; border-radius: 8px; }";
         AV8HTML += "h2 { color: #333; }";
         AV8HTML += ".signature-card { background-color: #fff; border: 1px solid #ddd; border-radius: 5px; padding: 15px; margin-bottom: 15px; box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1); display:flex; flex-wrap: wrap;}";
         AV8HTML += ".auth-point { background-color: #e7f3ff; border: 1px solid #a0c4ff; border-radius: 5px; padding: 10px; margin: 5px 0; display: inline-block; }";
         AV8HTML += "h3 { margin: 0; color: #007BFF; }";
         AV8HTML += ".check-icon { color: #00AEA9; font-size: 20px; vertical-align: middle; display: inline-flex; align-items: center; justify-content: center; width: 30px; height: 30px; border-radius: 50%; background-color: #fff; border: 2px solid #00AEA9; margin-right: 10px; }";
         AV8HTML += ".container { page-break-inside: avoid; }";
         AV8HTML += "@media print { .container { break-inside: avoid; page-break-inside: avoid; } }";
         AV8HTML += ".header { overflow: hidden; border-bottom: 1px solid #ccc; padding-bottom: 10px; }";
         AV8HTML += ".header-logo { float: left; width: 50%; }";
         AV8HTML += ".header-logo img { width: 50px; margin-right: 10px; float: left; }";
         AV8HTML += ".header-info { float: right; width: 50%; text-align: right; font-size: 12px; color: #666; }";
         AV8HTML += ".main-content { margin-top: 20px; }";
         AV8HTML += ".main-content h1 { font-size: 24px; }";
         AV8HTML += ".main-content p { font-size: 14px; color: #666; }";
         AV8HTML += ".qr-code { text-align: right; }";
         AV8HTML += ".qr-code img { width: 100px; }";
         AV8HTML += ".container-header { padding: 20px; }";
         AV8HTML += ".content { overflow: hidden; border-bottom: 1px solid #ccc; padding-bottom: 10px; }";
         AV8HTML += ".main-content { float: left; width: 50%; }";
         AV8HTML += ".sub-content { float: right; width: 50%; }";
         AV8HTML += "    </style>";
         AV8HTML += "</head>";
         AV8HTML += "<body>";
         AV8HTML += "    <div class=\"container-header\">";
         AV8HTML += "        <div class=\"header\">";
         AV8HTML += "            <div class=\"header-logo\">";
         AV8HTML += "                <img src=\"https://erwise.com.br/wp-content/uploads/2024/06/logo-e1717427590330.png\" alt=\"Erwise Logo\">";
         AV8HTML += "                <div>";
         AV8HTML += "                    <h3>Erwise</h3>";
         AV8HTML += "                    <p>Relatório de Assinaturas</p>";
         AV8HTML += "                </div>";
         AV8HTML += "            </div>";
         AV8HTML += "            <div class=\"header-info\">";
         AV8HTML += "                <p>Datas e horários em UTC-0300 (America/Sao_Paulo)</p>";
         AV13CarimboData = StringUtil.Format( "Última atualização em %1 %2 %3, %4:%5:%6", StringUtil.PadL( StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( AV15AssinaturaFinalizadoData)), 10, 0)), 2, "0"), StringUtil.Trim( DateTimeUtil.CMonth( AV15AssinaturaFinalizadoData, "por")), StringUtil.LTrimStr( (decimal)(DateTimeUtil.Year( AV15AssinaturaFinalizadoData)), 9, 0), StringUtil.PadL( StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( AV15AssinaturaFinalizadoData)), 10, 0)), 2, "0"), StringUtil.PadL( StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( AV15AssinaturaFinalizadoData)), 10, 0)), 2, "0"), StringUtil.PadL( StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( AV15AssinaturaFinalizadoData)), 10, 0)), 2, "0"), "", "", "");
         AV8HTML += StringUtil.Format( "                <p>%1</p>", AV13CarimboData, "", "", "", "", "", "", "", "");
         AV8HTML += "            </div>";
         AV8HTML += "        </div>";
         AV8HTML += "        <div class=\"content\">";
         AV8HTML += StringUtil.Format( "            	<h1>%1</h1>", AV11ContratoNome, "", "", "", "", "", "", "", "");
         AV8HTML += StringUtil.Format( "            	<p>Documento número %1</p>", AV12AssinaturaPublicKey.ToString(), "", "", "", "", "", "", "", "");
         AV8HTML += "        </div>";
         AV16GXV1 = 1;
         while ( AV16GXV1 <= AV10Array_SdParticipantesContrato.Count )
         {
            AV9SdParticipantesContrato = ((SdtSdParticipantesContrato)AV10Array_SdParticipantesContrato.Item(AV16GXV1));
            AV8HTML += "    <div class=\"container\">";
            AV8HTML += "        <h3>";
            GXt_char1 = AV8HTML;
            new initcap(context ).execute(  AV9SdParticipantesContrato.gxTpr_Participantenome, out  GXt_char1) ;
            AV8HTML += StringUtil.Format( "            <span class=\"check-icon\"><i class=\"fas fa-check\"></i></span> %1", GXt_char1, "", "", "", "", "", "", "", "");
            AV8HTML += "        </h3>";
            AV8HTML += "        <p>Assinou o contrato!</p>";
            AV8HTML += "        <h4>Pontos de autenticação:</h4>";
            AV8HTML += "        <div class=\"signature-card\">";
            AV8HTML += StringUtil.Format( "            <div class=\"auth-point\">Método de Autenticação: Token de Autenticação (OTP via Email) (%1)</div>", StringUtil.Lower( AV9SdParticipantesContrato.gxTpr_Participanteemail), "", "", "", "", "", "", "", "");
            AV8HTML += StringUtil.Format( "            <div class=\"auth-point\">IP: %1</div>", AV9SdParticipantesContrato.gxTpr_Assinaturaparticipanteremoteaddres, "", "", "", "", "", "", "", "");
            AV8HTML += StringUtil.Format( "            <div class=\"auth-point\">Geolocalização: %1</div>", AV9SdParticipantesContrato.gxTpr_Assinaturaparticipantegeolocalizacao, "", "", "", "", "", "", "", "");
            AV8HTML += StringUtil.Format( "            <div class=\"auth-point\">Dispositivo: %1</div>", AV9SdParticipantesContrato.gxTpr_Assinaturaparticipantedispositivo, "", "", "", "", "", "", "", "");
            AV8HTML += StringUtil.Format( "            <div class=\"auth-point\">Data e hora: %1</div>", context.localUtil.TToC( (DateTime)(AV9SdParticipantesContrato.gxTpr_Assinaturaparticipantedataconclusao), 10, 8, 0, 3, "/", ":", " "), "", "", "", "", "", "", "", "");
            AV8HTML += StringUtil.Format( "            <div class=\"auth-point\">CPF: %1</div>", AV9SdParticipantesContrato.gxTpr_Assinaturaparticipantecpf, "", "", "", "", "", "", "", "");
            AV8HTML += StringUtil.Format( "            <div class=\"auth-point\">Data de nascimento: %1</div>", context.localUtil.DToC( (DateTime)(AV9SdParticipantesContrato.gxTpr_Assinaturaparticipantenascimento), 0, "-"), "", "", "", "", "", "", "", "");
            AV8HTML += StringUtil.Format( "            <div class=\"auth-point\">Token: %1</div>", AV9SdParticipantesContrato.gxTpr_Assinaturaparticipantekey, "", "", "", "", "", "", "", "");
            AV8HTML += "        </div>";
            AV8HTML += "    </div>";
            AV16GXV1 = (int)(AV16GXV1+1);
         }
         AV8HTML += "    <script>";
         AV8HTML += "        new QRCode(document.getElementById(\"qrcode\"), {";
         AV8HTML += StringUtil.Format( "            text: \"%1\",", AV14AssinaturaPaginaConsulta, "", "", "", "", "", "", "", "");
         AV8HTML += "            width: 100,";
         AV8HTML += "            height: 100";
         AV8HTML += "        });";
         AV8HTML += "    </script>";
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
         AV13CarimboData = "";
         AV9SdParticipantesContrato = new SdtSdParticipantesContrato(context);
         GXt_char1 = "";
         AV14AssinaturaPaginaConsulta = "";
         /* GeneXus formulas. */
      }

      private int AV16GXV1 ;
      private string GXt_char1 ;
      private DateTime AV15AssinaturaFinalizadoData ;
      private string AV8HTML ;
      private string AV11ContratoNome ;
      private string AV13CarimboData ;
      private string AV14AssinaturaPaginaConsulta ;
      private Guid AV12AssinaturaPublicKey ;
      private GXBaseCollection<SdtSdParticipantesContrato> AV10Array_SdParticipantesContrato ;
      private SdtSdParticipantesContrato AV9SdParticipantesContrato ;
      private string aP4_HTML ;
   }

}
