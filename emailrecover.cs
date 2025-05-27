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
   public class emailrecover : GXProcedure
   {
      public emailrecover( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public emailrecover( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_SecUserFullName ,
                           string aP1_Link ,
                           out string aP2_HTML )
      {
         this.AV8SecUserFullName = aP0_SecUserFullName;
         this.AV9Link = aP1_Link;
         this.AV10HTML = "" ;
         initialize();
         ExecuteImpl();
         aP2_HTML=this.AV10HTML;
      }

      public string executeUdp( string aP0_SecUserFullName ,
                                string aP1_Link )
      {
         execute(aP0_SecUserFullName, aP1_Link, out aP2_HTML);
         return AV10HTML ;
      }

      public void executeSubmit( string aP0_SecUserFullName ,
                                 string aP1_Link ,
                                 out string aP2_HTML )
      {
         this.AV8SecUserFullName = aP0_SecUserFullName;
         this.AV9Link = aP1_Link;
         this.AV10HTML = "" ;
         SubmitImpl();
         aP2_HTML=this.AV10HTML;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10HTML += "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">";
         AV10HTML += "<html dir=\"ltr\" xmlns=\"http://www.w3.org/1999/xhtml\" xmlns:o=\"urn:schemas-microsoft-com:office:office\" lang=\"pt\">";
         AV10HTML += "<head>";
         AV10HTML += "  <meta charset=\"UTF-8\">";
         AV10HTML += "  <meta content=\"width=device-width, initial-scale=1\" name=\"viewport\">";
         AV10HTML += "  <meta name=\"x-apple-disable-message-reformatting\">";
         AV10HTML += "  <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">";
         AV10HTML += "  <meta content=\"telephone=no\" name=\"format-detection\">";
         AV10HTML += "  <title>Nova mensagem</title>";
         AV10HTML += "  <!--[if (mso 16)]>";
         AV10HTML += "    <style type=\"text/css\">";
         AV10HTML += "    a {text-decoration: none;}";
         AV10HTML += "    </style>";
         AV10HTML += "  <![endif]-->";
         AV10HTML += "  <!--[if gte mso 9]><style>sup { font-size: 100% !important; }</style><![endif]-->";
         AV10HTML += "  <!--[if gte mso 9]>";
         AV10HTML += "    <xml>";
         AV10HTML += "    <o:OfficeDocumentSettings>";
         AV10HTML += "    <o:AllowPNG></o:AllowPNG>";
         AV10HTML += "    <o:PixelsPerInch>96</o:PixelsPerInch>";
         AV10HTML += "    </o:OfficeDocumentSettings>";
         AV10HTML += "    </xml>";
         AV10HTML += "  <![endif]-->";
         AV10HTML += "  <!--[if !mso]><!-->";
         AV10HTML += "    <link href=\"https://fonts.googleapis.com/css?family=Roboto:400,400i,700,700i\" rel=\"stylesheet\">";
         AV10HTML += "  <!--<![endif]-->";
         AV10HTML += "  <style type=\"text/css\">";
         AV10HTML += "    #outlook a {";
         AV10HTML += "      padding:0;";
         AV10HTML += "    }";
         AV10HTML += "    .es-button {";
         AV10HTML += "      mso-style-priority:100!important;";
         AV10HTML += "      text-decoration:none!important;";
         AV10HTML += "    }";
         AV10HTML += "    a[x-apple-data-detectors] {";
         AV10HTML += "      color:inherit!important;";
         AV10HTML += "      text-decoration:none!important;";
         AV10HTML += "      font-size:inherit!important;";
         AV10HTML += "      font-family:inherit!important;";
         AV10HTML += "      font-weight:inherit!important;";
         AV10HTML += "      line-height:inherit!important;";
         AV10HTML += "    }";
         AV10HTML += "    .es-desk-hidden {";
         AV10HTML += "      display:none;";
         AV10HTML += "      float:left;";
         AV10HTML += "      overflow:hidden;";
         AV10HTML += "      width:0;";
         AV10HTML += "      max-height:0;";
         AV10HTML += "      line-height:0;";
         AV10HTML += "      mso-hide:all;";
         AV10HTML += "    }";
         AV10HTML += "    @media only screen and (max-width:600px) {";
         AV10HTML += "      p, ul li, ol li, a { line-height:120%!important; }";
         AV10HTML += "      h1, h2, h3, h1 a, h2 a, h3 a { line-height:120% }";
         AV10HTML += "      h1 { font-size:36px!important; text-align:left }";
         AV10HTML += "      h2 { font-size:26px!important; text-align:left }";
         AV10HTML += "      h3 { font-size:20px!important; text-align:left }";
         AV10HTML += "      .es-header-body h1 a, .es-content-body h1 a, .es-footer-body h1 a { font-size:36px!important; text-align:left }";
         AV10HTML += "      .es-header-body h2 a, .es-content-body h2 a, .es-footer-body h2 a { font-size:26px!important; text-align:left }";
         AV10HTML += "      .es-header-body h3 a, .es-content-body h3 a, .es-footer-body h3 a { font-size:20px!important; text-align:left }";
         AV10HTML += "      .es-menu td a { font-size:12px!important }";
         AV10HTML += "      .es-header-body p, .es-header-body ul li, .es-header-body ol li, .es-header-body a { font-size:14px!important }";
         AV10HTML += "      .es-content-body p, .es-content-body ul li, .es-content-body ol li, .es-content-body a { font-size:16px!important }";
         AV10HTML += "      .es-footer-body p, .es-footer-body ul li, .es-footer-body ol li, .es-footer-body a { font-size:14px!important }";
         AV10HTML += "      .es-infoblock p, .es-infoblock ul li, .es-infoblock ol li, .es-infoblock a { font-size:12px!important }";
         AV10HTML += "      *[class=\"gmail-fix\"] { display:none!important }";
         AV10HTML += "      .es-m-txt-c, .es-m-txt-c h1, .es-m-txt-c h2, .es-m-txt-c h3 { text-align:center!important }";
         AV10HTML += "      .es-m-txt-r, .es-m-txt-r h1, .es-m-txt-r h2, .es-m-txt-r h3 { text-align:right!important }";
         AV10HTML += "      .es-m-txt-l, .es-m-txt-l h1, .es-m-txt-l h2, .es-m-txt-l h3 { text-align:left!important }";
         AV10HTML += "      .es-m-txt-r img, .es-m-txt-c img, .es-m-txt-l img { display:inline!important }";
         AV10HTML += "      .es-button-border { display:inline-block!important }";
         AV10HTML += "      a.es-button, button.es-button { font-size:20px!important; display:inline-block!important }";
         AV10HTML += "      .es-adaptive table, .es-left, .es-right { width:100%!important }";
         AV10HTML += "      .es-content table, .es-header table, .es-footer table, .es-content, .es-footer, .es-header { width:100%!important; max-width:600px!important }";
         AV10HTML += "      .es-adapt-td { display:block!important; width:100%!important }";
         AV10HTML += "      .adapt-img { width:100%!important; height:auto!important }";
         AV10HTML += "      .es-m-p0 { padding:0!important }";
         AV10HTML += "      .es-m-p0r { padding-right:0!important }";
         AV10HTML += "      .es-m-p0l { padding-left:0!important }";
         AV10HTML += "      .es-m-p0t { padding-top:0!important }";
         AV10HTML += "      .es-m-p0b { padding-bottom:0!important }";
         AV10HTML += "      .es-m-p20b { padding-bottom:20px!important }";
         AV10HTML += "      .es-mobile-hidden, .es-hidden { display:none!important }";
         AV10HTML += "      tr.es-desk-hidden, td.es-desk-hidden, table.es-desk-hidden { width:auto!important; overflow:visible!important; float:none!important; max-height:inherit!important; line-height:inherit!important }";
         AV10HTML += "      tr.es-desk-hidden { display:table-row!important }";
         AV10HTML += "      table.es-desk-hidden { display:table!important }";
         AV10HTML += "      td.es-desk-menu-hidden { display:table-cell!important }";
         AV10HTML += "      .es-menu td { width:1%!important }";
         AV10HTML += "      table.es-table-not-adapt, .esd-block-html table { width:auto!important }";
         AV10HTML += "      table.es-social { display:inline-block!important }";
         AV10HTML += "      table.es-social td { display:inline-block!important }";
         AV10HTML += "      .es-m-p5 { padding:5px!important }";
         AV10HTML += "      .es-m-p5t { padding-top:5px!important }";
         AV10HTML += "      .es-m-p5b { padding-bottom:5px!important }";
         AV10HTML += "      .es-m-p5r { padding-right:5px!important }";
         AV10HTML += "      .es-m-p5l { padding-left:5px!important }";
         AV10HTML += "      .es-m-p10 { padding:10px!important }";
         AV10HTML += "      .es-m-p10t { padding-top:10px!important }";
         AV10HTML += "      .es-m-p10b { padding-bottom:10px!important }";
         AV10HTML += "      .es-m-p10r { padding-right:10px!important }";
         AV10HTML += "      .es-m-p10l { padding-left:10px!important }";
         AV10HTML += "      .es-m-p15 { padding:15px!important }";
         AV10HTML += "      .es-m-p15t { padding-top:15px!important }";
         AV10HTML += "      .es-m-p15b { padding-bottom:15px!important }";
         AV10HTML += "      .es-m-p15r { padding-right:15px!important }";
         AV10HTML += "      .es-m-p15l { padding-left:15px!important }";
         AV10HTML += "      .es-m-p20 { padding:20px!important }";
         AV10HTML += "      .es-m-p20t { padding-top:20px!important }";
         AV10HTML += "      .es-m-p20b { padding-bottom:20px!important }";
         AV10HTML += "      .es-m-p20r { padding-right:20px!important }";
         AV10HTML += "      .es-m-p20l { padding-left:20px!important }";
         AV10HTML += "      .es-m-p25 { padding:25px!important }";
         AV10HTML += "      .es-m-p25t { padding-top:25px!important }";
         AV10HTML += "      .es-m-p25b { padding-bottom:25px!important }";
         AV10HTML += "      .es-m-p25r { padding-right:25px!important }";
         AV10HTML += "      .es-m-p25l { padding-left:25px!important }";
         AV10HTML += "      .es-m-p30 { padding:30px!important }";
         AV10HTML += "      .es-m-p30t { padding-top:30px!important }";
         AV10HTML += "      .es-m-p30b { padding-bottom:30px!important }";
         AV10HTML += "      .es-m-p30r { padding-right:30px!important }";
         AV10HTML += "      .es-m-p30l { padding-left:30px!imporant }";
         AV10HTML += "      .es-m-p35 { padding:35px!important }";
         AV10HTML += "      .es-m-p35t { padding-top:35px!important }";
         AV10HTML += "      .es-m-p35b { padding-bottom:35px!important }";
         AV10HTML += "      .es-m-p35r { padding-right:35px!important }";
         AV10HTML += "      .es-m-p35l { padding-left:35px!important }";
         AV10HTML += "      .es-m-p40 { padding:40px!important }";
         AV10HTML += "      .es-m-p40t { padding-top:40px!important }";
         AV10HTML += "      .es-m-p40b { padding-bottom:40px!important }";
         AV10HTML += "      .es-m-p40r { padding-right:40px!important }";
         AV10HTML += "      .es-m-p40l { padding-left:40px!important }";
         AV10HTML += "    }";
         AV10HTML += "  </style>";
         AV10HTML += "</head>";
         AV10HTML += "<body style=\"width:100%;font-family:Arial helvetica, arial, sans-serif;-webkit-text-size-adjust:100%;-ms-text-size-adjust:100%;padding:0;Margin:0\">";
         AV10HTML += "  <div dir=\"ltr\" class=\"es-wrapper-color\" lang=\"pt\" style=\"background-color:#FAFAFA\"><!--[if gte mso 9]>";
         AV10HTML += "    <v:background xmlns:v=\"urn:schemas-microsoft-com:vml\" fill=\"t\">";
         AV10HTML += "      <v:fill type=\"tile\" color=\"#fafafa\"></v:fill>";
         AV10HTML += "    </v:background>";
         AV10HTML += "  <![endif]-->";
         AV10HTML += "   <table class=\"es-wrapper\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" role=\"none\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;padding:0;Margin:0;width:100%;height:100%;background-repeat:repeat;background-position:center top;background-color:#FAFAFA\">";
         AV10HTML += "     <tr>";
         AV10HTML += "      <td valign=\"top\" style=\"padding:0;Margin:0\">";
         AV10HTML += "       <table cellpadding=\"0\" cellspacing=\"0\" class=\"es-content\" align=\"center\" role=\"none\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%\">";
         AV10HTML += "         <tr>";
         AV10HTML += "          <td class=\"es-info-area\" align=\"center\" style=\"padding:0;Margin:0\">";
         AV10HTML += "           <table class=\"es-content-body\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:transparent;width:600px\" bgcolor=\"#FFFFFF\" role=\"none\">";
         AV10HTML += "             <tr>";
         AV10HTML += "              <td align=\"left\" style=\"padding:20px;Margin:0\">";
         AV10HTML += "               <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"none\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\">";
         AV10HTML += "                 <tr>";
         AV10HTML += "                  <td align=\"center\" valign=\"top\" style=\"padding:0;Margin:0;width:560px\">";
         AV10HTML += "                   <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\">";
         AV10HTML += "                    ";
         AV10HTML += "                   </table></td>";
         AV10HTML += "                 </tr>";
         AV10HTML += "               </table></td>";
         AV10HTML += "             </tr>";
         AV10HTML += "           </table></td>";
         AV10HTML += "         </tr>";
         AV10HTML += "       </table>";
         AV10HTML += "       <table cellpadding=\"0\" cellspacing=\"0\" class=\"es-header\" align=\"center\" role=\"none\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%;background-color:transparent;background-repeat:repeat;background-position:center top\">";
         AV10HTML += "         <tr>";
         AV10HTML += "          <td align=\"center\" style=\"padding:0;Margin:0\">";
         AV10HTML += "           <table bgcolor=\"#ffffff\" class=\"es-header-body\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" role=\"none\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:transparent;width:600px\">";
         AV10HTML += "             <tr>";
         AV10HTML += "              <td align=\"left\" style=\"Margin:0;padding-top:10px;padding-bottom:10px;padding-left:20px;padding-right:20px\">";
         AV10HTML += "               <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"none\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\">";
         AV10HTML += "                 <tr>";
         AV10HTML += "                  <td class=\"es-m-p0r\" valign=\"top\" align=\"center\" style=\"padding:0;Margin:0;width:560px\">";
         AV10HTML += "                   <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"none\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\">";
         AV10HTML += "                     <tr>";
         AV10HTML += "                      <td align=\"center\" style=\"padding:0;Margin:0;display:none\"></td>";
         AV10HTML += "                     </tr>";
         AV10HTML += "                   </table></td>";
         AV10HTML += "                 </tr>";
         AV10HTML += "               </table></td>";
         AV10HTML += "             </tr>";
         AV10HTML += "           </table></td>";
         AV10HTML += "         </tr>";
         AV10HTML += "       </table>";
         AV10HTML += "       <tablecellpadding=\"0\" cellspacing=\"0\" class=\"es-content\" align=\"center\" role=\"none\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%\">";
         AV10HTML += "         <tr>";
         AV10HTML += "          <td align=\"center\" style=\"padding:0;Margin:0\">";
         AV10HTML += "           <table bgcolor=\"#ffffff\" class=\"es-content-body\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" role=\"none\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#FFFFFF;width:600px\">";
         AV10HTML += "             <tr>";
         AV10HTML += "              <td align=\"left\" style=\"padding:40px;Margin:0;border-radius:40px\">";
         AV10HTML += "               <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"none\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\">";
         AV10HTML += "                 <tr>";
         AV10HTML += "                  <td align=\"center\" valign=\"top\" style=\"padding:0;Margin:0;width:520px\">";
         AV10HTML += "                   <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\">";
         AV10HTML += "                     <tr>";
         AV10HTML += "                      <td align=\"center\" style=\"padding:0;Margin:0;padding-top:10px;padding-bottom:10px;font-size:0px\"><img src=\"https://painel.erwise.com.br/assets/img/logo.png\" alt style=\"display:block;border:0;outline:none;text-decoration:none;-ms-interpolation-mode:bicubic\" width=\"280\"></td>";
         AV10HTML += "                     </tr>";
         AV10HTML += "                     <tr>";
         AV10HTML += "                      <td align=\"center\" class=\"es-m-txt-c\" style=\"padding:0;Margin:0\"><h1 style=\"Margin:0;line-height:46px;mso-line-height-rule:exactly;font-family:arial, helvetica, sans-serif;font-size:46px;font-style:normal;font-weight:bold;color:#333333\">Recuperar e-mail</h1></td>";
         AV10HTML += "                     </tr>";
         AV10HTML += "                     <tr class=\"es-visible-simple-html-only\">";
         AV10HTML += StringUtil.Format( "                      <td align=\"center\" class=\"es-m-p0r es-m-p0l\" style=\"Margin:0;padding-top:5px;padding-bottom:5px;padding-left:40px;padding-right:40px\"><p style=\"Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:roboto,  helvetica, arial, sans-serif;line-height:17px;color:#333333;font-size:14px\">Olá %1</p></td>", AV8SecUserFullName, "", "", "", "", "", "", "", "");
         AV10HTML += "                     </tr>";
         AV10HTML += "                     <tr>";
         AV10HTML += "                      <td align=\"center\" class=\"es-m-p0r es-m-p0l\" style=\"padding:0;Margin:0;padding-top:5px;padding-left:40px;padding-right:40px\"><p style=\"Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:roboto,  helvetica, arial, sans-serif;line-height:17px;color:#333333;font-size:14px\"><strong>Atenção, o link é válido por apenas 48 horas. Após esse período, você deve fazer uma nova solicitação.</strong></p><p style=\"Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:roboto,  helvetica, arial, sans-serif;line-height:17px;color:#333333;font-size:14px\"><br></p></td>";
         AV10HTML += "                     </tr>";
         AV10HTML += "                     <tr>";
         AV10HTML += StringUtil.Format( "                      <td align=\"center\" style=\"padding:0;Margin:0;padding-top:10px;padding-bottom:10px\"><span class=\"es-button-border\" style=\"border-style:solid;border-color:#2CB543;background:#24a297;border-width:0px;display:inline-block;border-radius:6px;width:auto\"><a href=\"%1\" class=\"es-button\" target=\"_blank\" style=\"mso-style-priority:100 !important;text-decoration:none;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;color:#FFFFFF;font-size:20px;padding:10px 30px 10px 30px;display:inline-block;background:#24a297;border-radius:6px;font-family:roboto,  helvetica, arial, sans-serif;font-weight:normal;font-style:normal;line-height:24px;width:auto;text-align:center;mso-padding-alt:0;mso-border-alt:10px solid #24a297;padding-left:30px;padding-right:30px\">Definir nova senha</a></span></td>", AV9Link, "", "", "", "", "", "", "", "");
         AV10HTML += "                     </tr>";
         AV10HTML += "                   </table></td>";
         AV10HTML += "                 </tr>";
         AV10HTML += "               </table></td>";
         AV10HTML += "             </tr>";
         AV10HTML += "           </table></td>";
         AV10HTML += "         </tr>";
         AV10HTML += "       </table>";
         AV10HTML += "       <table cellpadding=\"0\" cellspacing=\"0\" class=\"es-footer\" align=\"center\" role=\"none\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%;background-color:transparent;background-repeat:repeat;background-position:center top\">";
         AV10HTML += "         <tr>";
         AV10HTML += "          <td align=\"center\" style=\"padding:0;Margin:0\">";
         AV10HTML += "           <table class=\"es-footer-body\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:transparent;width:600px\" role=\"none\">";
         AV10HTML += "             <tr>";
         AV10HTML += "              <td align=\"left\" style=\"Margin:0;padding-top:20px;padding-bottom:20px;padding-left:20px;padding-right:20px\">";
         AV10HTML += "               <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"none\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\">";
         AV10HTML += "                 <tr>";
         AV10HTML += "                  <td align=\"left\" style=\"padding:0;Margin:0;width:560px\">";
         AV10HTML += "                   <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"none\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\">";
         AV10HTML += "                     <tr>";
         AV10HTML += "                      <td align=\"center\" style=\"padding:0;Margin:0;display:none\"></td>";
         AV10HTML += "                     </tr>";
         AV10HTML += "                   </table></td>";
         AV10HTML += "                 </tr>";
         AV10HTML += "               </table></td>";
         AV10HTML += "             </tr>";
         AV10HTML += "           </table></td>";
         AV10HTML += "         </tr>";
         AV10HTML += "       </table>";
         AV10HTML += "       <table cellpadding=\"0\" cellspacing=\"0\" class=\"es-content\" align=\"center\" role=\"none\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%\">";
         AV10HTML += "         <tr>";
         AV10HTML += "          <td class=\"es-info-area\" align=\"center\" style=\"padding:0;Margin:0\">";
         AV10HTML += "           <table class=\"es-content-body\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:transparent;width:600px\" bgcolor=\"#FFFFFF\" role=\"none\">";
         AV10HTML += "             <tr>";
         AV10HTML += "              <td align=\"left\" style=\"padding:20px;Margin:0\">";
         AV10HTML += "               <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"none\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\">";
         AV10HTML += "                ";
         AV10HTML += "               </table></td>";
         AV10HTML += "             </tr>";
         AV10HTML += "           </table></td>";
         AV10HTML += "         </tr>";
         AV10HTML += "       </table></td>";
         AV10HTML += "     </tr>";
         AV10HTML += "   </table>";
         AV10HTML += "  </div>";
         AV10HTML += " </body>";
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
      private string AV8SecUserFullName ;
      private string AV9Link ;
      private string aP2_HTML ;
   }

}
