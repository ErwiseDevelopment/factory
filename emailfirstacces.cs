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
   public class emailfirstacces : GXProcedure
   {
      public emailfirstacces( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public emailfirstacces( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_Codigo ,
                           out string aP1_HTML )
      {
         this.AV9Codigo = aP0_Codigo;
         this.AV8HTML = "" ;
         initialize();
         ExecuteImpl();
         aP1_HTML=this.AV8HTML;
      }

      public string executeUdp( string aP0_Codigo )
      {
         execute(aP0_Codigo, out aP1_HTML);
         return AV8HTML ;
      }

      public void executeSubmit( string aP0_Codigo ,
                                 out string aP1_HTML )
      {
         this.AV9Codigo = aP0_Codigo;
         this.AV8HTML = "" ;
         SubmitImpl();
         aP1_HTML=this.AV8HTML;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8HTML += "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">";
         AV8HTML += "<html dir=\"ltr\" xmlns=\"http://www.w3.org/1999/xhtml\" xmlns:o=\"urn:schemas-microsoft-com:office:office\" lang=\"en\">";
         AV8HTML += " <head>";
         AV8HTML += "  <meta charset=\"UTF-8\">";
         AV8HTML += "  <meta content=\"width=device-width, initial-scale=1\" name=\"viewport\">";
         AV8HTML += "  <meta name=\"x-apple-disable-message-reformatting\">";
         AV8HTML += "  <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">";
         AV8HTML += "  <meta content=\"telephone=no\" name=\"format-detection\">";
         AV8HTML += "  <title>Nova mensagem</title><!--[if (mso 16)]>";
         AV8HTML += "    <style type=\"text/css\">";
         AV8HTML += "    a {text-decoration: none;}";
         AV8HTML += "    </style>";
         AV8HTML += "    <![endif]--><!--[if gte mso 9]><style>sup { font-size: 100% !important; }</style><![endif]--><!--[if gte mso 9]>";
         AV8HTML += "<xml>";
         AV8HTML += "    <o:OfficeDocumentSettings>";
         AV8HTML += "    <o:AllowPNG></o:AllowPNG>";
         AV8HTML += "    <o:PixelsPerInch>96</o:PixelsPerInch>";
         AV8HTML += "    </o:OfficeDocumentSettings>";
         AV8HTML += "</xml>";
         AV8HTML += "<![endif]--><!--[if !mso]><!-- -->";
         AV8HTML += "  <link href=\"https://fonts.googleapis.com/css?family=Roboto:400,400i,700,700i\" rel=\"stylesheet\"><!--<![endif]-->";
         AV8HTML += "  <style type=\"text/css\">";
         AV8HTML += "#outlook a {";
         AV8HTML += "	padding:0;";
         AV8HTML += "}";
         AV8HTML += ".es-button {";
         AV8HTML += "	mso-style-priority:100!important;";
         AV8HTML += "	text-decoration:none!important;";
         AV8HTML += "}";
         AV8HTML += "a[x-apple-data-detectors] {";
         AV8HTML += "	color:inherit!important;";
         AV8HTML += "	text-decoration:none!important;";
         AV8HTML += "	font-size:inherit!important;";
         AV8HTML += "	font-family:inherit!important;";
         AV8HTML += "	font-weight:inherit!important;";
         AV8HTML += "	line-height:inherit!important;";
         AV8HTML += "}";
         AV8HTML += ".es-desk-hidden {";
         AV8HTML += "	display:none;";
         AV8HTML += "	float:left;";
         AV8HTML += "	overflow:hidden;";
         AV8HTML += "	width:0;";
         AV8HTML += "	max-height:0;";
         AV8HTML += "	line-height:0;";
         AV8HTML += "	mso-hide:all;";
         AV8HTML += "}";
         AV8HTML += "@media only screen and (max-width:600px) {p, ul li, ol li, a { line-height:120%!important } h1, h2, h3, h1 a, h2 a, h3 a { line-height:120% } h1 { font-size:36px!important; text-align:left } h2 { font-size:2px!important; text-align:left } h3 { font-size:20px!important; text-align:left } .es-header-body h1 a, .es-content-body h1 a, .es-footer-body h1 a { font-size:36px!important; text-align:left } .es-header-body h2 a, .es-content-body h2 a, .es-footer-body h2 a { font-size:26px!important; text-align:left } .es-header-body h3 a, .es-content-body h3 a, .es-footer-body h3 a { font-size:20px!important; text-align:left } .es-menu td a { font-size:12px!important } .es-header-body p, .es-header-body ul li, .es-header-body ol li, .es-header-body a { font-size:14px!important } .es-content-body p, .es-content-body ul li, .es-content-body ol li, .es-content-body a { font-size:16px!important } .es-footer-body p, .es-footer-body ul li, .es-footer-body ol li, .es-footer-body a { font-size:14px!important } .es-infoblock p, .es-infoblock ul li, .es-infoblock ol li, .es-infoblock a { font-size:12px!important } *[class=\"gmail-fix\"] { display:none!important } .es-m-txt-c, .es-m-txt-c h1, .es-m-txt-c h2, .es-m-txt-c h3 { text-align:center!important } .es-m-txt-r, .es-m-txt-r h1, .es-m-txt-r h2, .es-m-txt-r h3 { text-align:right!important } .es-m-txt-l, .es-m-txt-l h1, .es-m-txt-l h2, .es-m-txt-l h3 { text-align:left!important } .es-m-txt-r img, .es-m-txt-c img, .es-m-txt-l img { display:inline!important } .es-button-border { display:inline-block!important } a.es-button, button.es-button { font-size:20px!important; display:inline-block!important } .es-adaptive table, .es-left, .es-right { width:100%!important } .es-content table, .es-header table, .es-footer table, .es-content, .es-footer, .es-header { width:100%!important; max-width:600px!important } .es-adapt-td { display:block!important; width:100%!important } .adapt-img { width:100%!important; height:auto!important } .es-m-p0 { padding:0!important } .es-m-p0r { padding-right:0!important } .es-m-p0l { padding-left:0!important } .es-m-p0t { padding-top:0!important } .es-m-p0b { padding-bottom:0!important } .es-m-p20b { padding-bottom:20px!important } .es-mobile-hidden, .es-hidden { display:none!important } tr.es-desk-hidden, td.es-desk-hidden, table.es-desk-hidden { width:auto!important; overflow:visible!important; float:none!important; max-height:inherit!important; line-height:inherit!important } tr.es-desk-hidden { display:table-row!important } table.es-desk-hidden { display:table!important } td.es-desk-menu-hidden { display:table-cell!important } .es-menu td { width:1%!important } table.es-table-not-adapt, .esd-block-html table { width:auto!important } table.es-social { display:inline-block!important } table.es-social td { display:inline-block!important } .es-m-p5 { padding:5px!important } .es-m-p5t { padding-top:5px!important } .es-m-p5b { padding-bottom:5px!important } .es-m-p5r { padding-right:5px!important } .es-m-p5l { padding-left:5px!important } .es-m-p10 { padding:10px!important } .es-m-p10t { padding-top:10px!important } .es-m-p10b { padding-bottom:10px!important } .es-m-p10r { padding-right:10px!important } .es-m-p10l { padding-left:10px!important } .es-m-p15 { padding:15px!important } .es-m-p15t { padding-top:15px!important } .es-m-p15b { padding-bottom:15px!important } .es-m-p15r { padding-right:15px!important } .es-m-p15l { padding-left:15px!important } .es-m-p20 { padding:20px!important } .es-m-p20t { padding-top:20px!important } .es-m-p20r { padding-right:20px!important } .es-m-p20l { padding-left:20px!important } .es-m-p25 { padding:25px!important } .es-m-p25t { padding-top:25px!important } .es-m-p25b { padding-bottom:25px!important } .es-m-p25r { padding-right:25px!important } .es-m-p25l { padding-left:25px!important } .es-m-p30 { padding:30px!important } .es-m-p30t { padding-top:30px!important } .es-m-p30b { padding-bottom:30px!important } .es-m-p30r { padding-right:30px!important } .es-m-p30l { padding-left:30px!important } .es-m-p35 { padding:35px!important } .es-m-p35t { padding-top:35px!important } .es-m-p35b { padding-bottom:35px!important } .es-m-p35r { padding-right:35px!important } .es-m-p35l { padding-left:35px!important } .es-m-p40 { padding:40px!important } .es-m-p40t { padding-top:40px!important } .es-m-p40r { padding-right:40px!important } .es-m-p40l { padding-left:40px!important }";
         AV8HTML += ".es-desk-hidden { display:table-row!important; width:auto!important; overflow:visible!important; max-height:inherit!important } }";
         AV8HTML += "@media screen and (max-width:384px) {.mail-message-content { width:414px!important } }";
         AV8HTML += "</style>";
         AV8HTML += " </head>";
         AV8HTML += " <body style=" + "\"" + "width:100%;font-family:roboto, 'helvetica neue', helvetica, arial, sans-serif;-webkit-text-size-adjust:100%;-ms-text-size-adjust:100%;padding:0;Margin:0" + "\"" + ">";
         AV8HTML += "  <div dir=\"ltr\" class=\"es-wrapper-color\" lang=\"en\" style=\"background-color:#FAFAFA\"><!--[if gte mso 9]>";
         AV8HTML += "			<v:background xmlns:v=\"urn:schemas-microsoft-com:vml\" fill=\"t\">";
         AV8HTML += "				<v:fill type=\"tile\" color=\"#fafafa\"></v:fill>";
         AV8HTML += "			</v:background>";
         AV8HTML += "		<![endif]-->";
         AV8HTML += "       <table cellpadding=\"0\" cellspacing=\"0\" class=\"es-header\" align=\"center\" role=\"none\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%;background-color:transparent;background-repeat:repeat;background-position:center top\">";
         AV8HTML += "         <tr>";
         AV8HTML += "          <td align=\"center\" style=\"padding:0;Margin:0\">";
         AV8HTML += "           <table bgcolor=\"#ffffff\" class=\"es-header-body\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" role=\"none\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:transparent;width:600px\">";
         AV8HTML += "             <tr>";
         AV8HTML += "              <td align=\"left\" style=\"Margin:0;padding-top:10px;padding-bottom:10px;padding-left:20px;padding-right:20px\">";
         AV8HTML += "               <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"none\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\">";
         AV8HTML += "                 <tr>";
         AV8HTML += "                  <td class=\"es-m-p0r\" valign=\"top\" align=\"center\" style=\"padding:0;Margin:0;width:560px\">";
         AV8HTML += "                   <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"none\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\">";
         AV8HTML += "                     <tr>";
         AV8HTML += "                      <td align=\"center\" style=\"padding:0;Margin:0;display:none\"></td>";
         AV8HTML += "                     </tr>";
         AV8HTML += "                   </table></td>";
         AV8HTML += "                 </tr>";
         AV8HTML += "               </table></td>";
         AV8HTML += "             </tr>";
         AV8HTML += "           </table></td>";
         AV8HTML += "         </tr>";
         AV8HTML += "       </table>";
         AV8HTML += "       <table cellpadding=\"0\" cellspacing=\"0\" class=\"es-content\" align=\"center\" role=\"none\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%\">";
         AV8HTML += "         <tr>";
         AV8HTML += "          <td align=\"center\" style=\"padding:0;Margin:0\">";
         AV8HTML += "           <table bgcolor=\"#ffffff\" class=\"es-content-body\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" role=\"none\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#FFFFFF;width:600px\">";
         AV8HTML += "             <tr>";
         AV8HTML += "              <td align=\"left\" style=\"padding:40px;Margin:0;border-radius:40px\">";
         AV8HTML += "               <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"none\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\">";
         AV8HTML += "                 <tr>";
         AV8HTML += "                  <td align=\"center\" valign=\"top\" style=\"padding:0;Margin:0;width:520px\">";
         AV8HTML += "                   <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\">";
         AV8HTML += "                     <tr>";
         AV8HTML += "                      <td align=\"center\" style=\"padding:0;Margin:0;padding-top:10px;padding-bottom:10px;font-size:0px\"><img src=\"https://painel.erwise.com.br/assets/img/logo.png\" alt style=\"display:block;border:0;outline:none;text-decoration:none;-ms-interpolation-mode:bicubic\" width=\"280\" height=\"69\"></td>";
         AV8HTML += "                     </tr>";
         AV8HTML += "                     <tr class=\"es-visible-simple-html-only\">";
         AV8HTML += "                      <td align=\"center\" class=\"es-m-txt-c\" style=\"padding:0;Margin:0\"><h1 style=\"Margin:0;line-height:26px;mso-line-height-rule:exactly;font-family:arial,  helvetica, sans-serif;font-size:26px;font-style:normal;font-weight:bold;color:#333333\">Código primeiro acesso</h1></td>";
         AV8HTML += "                     </tr>";
         AV8HTML += "                     <tr class=\"es-visible-simple-html-only\">";
         AV8HTML += StringUtil.Format( "                      <td align=\"center\" class=\"es-m-p0r es-m-p0l\" style=\"Margin:0;padding-top:5px;padding-bottom:5px;padding-left:40px;padding-right:40px\"><p style=\"Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:roboto,  helvetica, arial, sans-serif;line-height:31px;color:#333333;font-size:26px;white-space:nowrap\">%1</p></td>", AV9Codigo, "", "", "", "", "", "", "", "");
         AV8HTML += "                     </tr>";
         AV8HTML += "                   </table></td>";
         AV8HTML += "                 </tr>";
         AV8HTML += "               </table></td>";
         AV8HTML += "             </tr>";
         AV8HTML += "           </table></td>";
         AV8HTML += "         </tr>";
         AV8HTML += "       </table>";
         AV8HTML += "       <table cellpadding=\"0\" cellspacing=\"0\" class=\"es-footer\" align=\"center\" role=\"none\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%;background-color:transparent;background-repeat:repeat;background-position:center top\">";
         AV8HTML += "         <tr>";
         AV8HTML += "          <td align=\"center\" style=\"padding:0;Margin:0\">";
         AV8HTML += "           <table class=\"es-footer-body\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:transparent;width:600px\" role=\"none\">";
         AV8HTML += "             <tr>";
         AV8HTML += "              <td align=\"left\" style=\"Margin:0;padding-top:20px;padding-bottom:20px;padding-left:20px;padding-right:20px\">";
         AV8HTML += "               <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"none\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\">";
         AV8HTML += "                 <tr>";
         AV8HTML += "                  <td align=\"left\" style=\"padding:0;Margin:0;width:560px\">";
         AV8HTML += "                   <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" role=\"none\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\">";
         AV8HTML += "                     <tr>";
         AV8HTML += "                      <td align=\"center\" style=\"padding:0;Margin:0;display:none\"></td>";
         AV8HTML += "                     </tr>";
         AV8HTML += "                   </table></td>";
         AV8HTML += "                 </tr>";
         AV8HTML += "               </table></td>";
         AV8HTML += "             </tr>";
         AV8HTML += "           </table></td>";
         AV8HTML += "         </tr>";
         AV8HTML += "       </table>";
         AV8HTML += "  </div>";
         AV8HTML += " </body>";
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
      private string AV9Codigo ;
      private string aP1_HTML ;
   }

}
