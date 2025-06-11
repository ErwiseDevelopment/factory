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
   public class prhtmlcomprovante : GXProcedure
   {
      public prhtmlcomprovante( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prhtmlcomprovante( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( SdtSdComprovante aP0_SdComprovante ,
                           out string aP1_HTML )
      {
         this.AV9SdComprovante = aP0_SdComprovante;
         this.AV8HTML = "" ;
         initialize();
         ExecuteImpl();
         aP1_HTML=this.AV8HTML;
      }

      public string executeUdp( SdtSdComprovante aP0_SdComprovante )
      {
         execute(aP0_SdComprovante, out aP1_HTML);
         return AV8HTML ;
      }

      public void executeSubmit( SdtSdComprovante aP0_SdComprovante ,
                                 out string aP1_HTML )
      {
         this.AV9SdComprovante = aP0_SdComprovante;
         this.AV8HTML = "" ;
         SubmitImpl();
         aP1_HTML=this.AV8HTML;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8HTML += "<!DOCTYPE html>";
         AV8HTML += "<html lang=\"pt-BR\">";
         AV8HTML += "<head>";
         AV8HTML += "    <meta charset=\"UTF-8\">";
         AV8HTML += "    <title>Proposta Criada</title>";
         AV8HTML += "    <link rel=\"stylesheet\" href=\"https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css\">";
         AV8HTML += "    <link rel=\"stylesheet\" href=\"https://fonts.googleapis.com/css?family=Roboto&display=swap\">";
         AV8HTML += "    <script src=\"https://cdnjs.cloudflare.com/ajax/libs/html2pdf.js/0.10.1/html2pdf.bundle.min.js\"></script>";
         GXt_char1 = AV8HTML;
         new prestilocomprovante(context ).execute( out  GXt_char1) ;
         AV8HTML += GXt_char1;
         AV8HTML += "</head>";
         AV8HTML += "<body>";
         AV8HTML += "    <div class=\"proposta-container\" id=\"propostaContent\">";
         AV8HTML += "";
         AV8HTML += "        <h1><i class=\"fas fa-check-circle\"></i></h1>";
         AV8HTML += "        <p class=\"proposta-message\">A proposta foi criada para o cliente indicado e enviada para aprovação.</p>";
         AV8HTML += "        <p class=\"proposta-message\">Assim que for aprovada, uma notificação será enviada por e-mail.</p>";
         AV8HTML += "";
         AV8HTML += "        <div class=\"proposta-section proposta-client-info\">";
         AV8HTML += "            <h2><i class=\"fas fa-user\"></i> Informações do Cliente</h2>";
         AV8HTML += "            <div class=\"proposta-info-group\">";
         AV8HTML += "                <div class=\"proposta-info-item\">";
         AV8HTML += "                    <div class=\"proposta-label\"><i class=\"fas fa-id-card\"></i> Documento:</div>";
         AV8HTML += StringUtil.Format( "                    <div class=\"proposta-value\">%1</div>", AV9SdComprovante.gxTpr_Clientedocumento, "", "", "", "", "", "", "", "");
         AV8HTML += "                </div>";
         AV8HTML += "                <div class=\"proposta-info-item\">";
         AV8HTML += "                    <div class=\"proposta-label\"><i class=\"fas fa-building\"></i> Nome:</div>";
         AV8HTML += StringUtil.Format( "                    <div class=\"proposta-value\">%1</div>", AV9SdComprovante.gxTpr_Clienterazaosocial, "", "", "", "", "", "", "", "");
         AV8HTML += "                </div>";
         AV8HTML += "                <div class=\"proposta-info-item\">";
         AV8HTML += "                    <div class=\"proposta-label\"><i class=\"fas fa-user-tag\"></i> Tipo Pessoa:</div>";
         AV8HTML += StringUtil.Format( "                    <div class=\"proposta-value\">%1</div>", AV9SdComprovante.gxTpr_Clientetipopessoa, "", "", "", "", "", "", "", "");
         AV8HTML += "                </div>";
         AV8HTML += "                <div class=\"proposta-info-item\">";
         AV8HTML += "                    <div class=\"proposta-label\"><i class=\"fas fa-info-circle\"></i> Descrição do Tipo Cliente:</div>";
         AV8HTML += StringUtil.Format( "                    <div class=\"proposta-value\">%1</div>", AV9SdComprovante.gxTpr_Clientetipoclientedescricao, "", "", "", "", "", "", "", "");
         AV8HTML += "                </div>";
         AV8HTML += "                <div class=\"proposta-info-item\">";
         AV8HTML += "                    <div class=\"proposta-label\"><i class=\"fas fa-calendar-alt\"></i> Data de Nascimento:</div>";
         AV8HTML += StringUtil.Format( "                    <div class=\"proposta-value\">%1</div>", context.localUtil.DToC( (DateTime)(AV9SdComprovante.gxTpr_Clientedatanascimento), 0, "-"), "", "", "", "", "", "", "", "");
         AV8HTML += "                </div>";
         AV8HTML += "                <div class=\"proposta-info-item\">";
         AV8HTML += "                    <div class=\"proposta-label\"><i class=\"fas fa-id-card-alt\"></i> RG:</div>";
         AV8HTML += StringUtil.Format( "                    <div class=\"proposta-value\">%1</div>", StringUtil.LTrimStr( (decimal)(AV9SdComprovante.gxTpr_Clienterg), 12, 0), "", "", "", "", "", "", "", "");
         AV8HTML += "                </div>";
         AV8HTML += "                <div class=\"proposta-info-item\">";
         AV8HTML += "                    <div class=\"proposta-label\"><i class=\"fas fa-globe\"></i> Nacionalidade:</div>";
         AV8HTML += StringUtil.Format( "                    <div class=\"proposta-value\">%1</div>", AV9SdComprovante.gxTpr_Clientenacionalidadenome, "", "", "", "", "", "", "", "");
         AV8HTML += "                </div>";
         AV8HTML += "                <div class=\"proposta-info-item\">";
         AV8HTML += "                    <div class=\"proposta-label\"><i class=\"fas fa-ring\"></i> Estado Civil:</div>";
         AV8HTML += StringUtil.Format( "                    <div class=\"proposta-value\">%1</div>", AV9SdComprovante.gxTpr_Clienteestadocivil, "", "", "", "", "", "", "", "");
         AV8HTML += "                </div>";
         AV8HTML += "                <div class=\"proposta-info-item\">";
         AV8HTML += "                    <div class=\"proposta-label\"><i class=\"fas fa-briefcase\"></i> Profissão:</div>";
         AV8HTML += StringUtil.Format( "                    <div class=\"proposta-value\">%1</div>", AV9SdComprovante.gxTpr_Clienteprofissaonome, "", "", "", "", "", "", "", "");
         AV8HTML += "                </div>";
         AV8HTML += "                <div class=\"proposta-info-item\" style=\"width: 100%;\">";
         AV8HTML += "                    <div class=\"proposta-label\"><i class=\"fas fa-map-marker-alt\"></i> Endereço:</div>";
         AV8HTML += "                    <div class=\"proposta-value\">";
         AV8HTML += StringUtil.Format( "                        CEP: %1, Rua: %2, Bairro: %3, Cidade: %4, Município: %5 - %6, Número: %7, Complemento: %8", AV9SdComprovante.gxTpr_Clienteenderecocep, AV9SdComprovante.gxTpr_Clienteenderecologradouro, AV9SdComprovante.gxTpr_Clienteenderecobairro, AV9SdComprovante.gxTpr_Clienteenderecocidade, AV9SdComprovante.gxTpr_Clienteenderecomunicipionome, AV9SdComprovante.gxTpr_Clienteenderecomunicipiouf, AV9SdComprovante.gxTpr_Clienteendereconumero, AV9SdComprovante.gxTpr_Clienteenderecocomplemento, "");
         AV8HTML += "                    </div>";
         AV8HTML += "                </div>";
         AV8HTML += "            </div>";
         AV8HTML += "        </div>";
         AV8HTML += "        <div class=\"proposta-section proposta-contact-info\">";
         AV8HTML += "            <h2><i class=\"fas fa-phone\"></i> Contato</h2>";
         AV8HTML += "            <div class=\"proposta-info-group\">";
         AV8HTML += "                <div class=\"proposta-info-item\">";
         AV8HTML += "                    <div class=\"proposta-label\"><i class=\"fas fa-envelope\"></i> E-mail:</div>";
         AV8HTML += StringUtil.Format( "                    <div class=\"proposta-value\">%1</div>", AV9SdComprovante.gxTpr_Contatoemail, "", "", "", "", "", "", "", "");
         AV8HTML += "                </div>";
         AV8HTML += "                <div class=\"proposta-info-item\">";
         AV8HTML += "                    <div class=\"proposta-label\"><i class=\"fas fa-phone-alt\"></i> DDD:</div>";
         AV8HTML += StringUtil.Format( "                    <div class=\"proposta-value\">%1</div>", StringUtil.LTrimStr( (decimal)(AV9SdComprovante.gxTpr_Contatoddd), 4, 0), "", "", "", "", "", "", "", "");
         AV8HTML += "                </div>";
         AV8HTML += "                <div class=\"proposta-info-item\">";
         AV8HTML += "                    <div class=\"proposta-label\"><i class=\"fas fa-phone\"></i> Número:</div>";
         AV8HTML += StringUtil.Format( "                    <div class=\"proposta-value\">%1</div>", StringUtil.LTrimStr( (decimal)(AV9SdComprovante.gxTpr_Contatonumero), 18, 0), "", "", "", "", "", "", "", "");
         AV8HTML += "                </div>";
         AV8HTML += "            </div>";
         AV8HTML += "        </div>";
         AV8HTML += "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9SdComprovante.gxTpr_Responsaveldocumento)) )
         {
            AV8HTML += "        <div class=\"proposta-section proposta-responsavel-info\" id=\"responsavelSection\">";
            AV8HTML += "            <h2><i class=\"fas fa-user-circle\"></i> Informações do Responsável</h2>";
            AV8HTML += "            <div class=\"proposta-info-group\">";
            AV8HTML += "                <div class=\"proposta-info-item\">";
            AV8HTML += "                    <div class=\"proposta-label\"><i class=\"fas fa-id-card\"></i> Documento:</div>";
            AV8HTML += StringUtil.Format( "                    <div class=\"proposta-value\">%1</div>", AV9SdComprovante.gxTpr_Responsaveldocumento, "", "", "", "", "", "", "", "");
            AV8HTML += "                </div>";
            AV8HTML += "                <div class=\"proposta-info-item\">";
            AV8HTML += "                    <div class=\"proposta-label\"><i class=\"fas fa-building\"></i> Nome:</div>";
            AV8HTML += StringUtil.Format( "                    <div class=\"proposta-value\">%1</div>", AV9SdComprovante.gxTpr_Responsavelrazaosocial, "", "", "", "", "", "", "", "");
            AV8HTML += "                </div>";
            AV8HTML += "                <div class=\"proposta-info-item\">";
            AV8HTML += "                    <div class=\"proposta-label\"><i class=\"fas fa-user-tag\"></i> Tipo Pessoa:</div>";
            AV8HTML += StringUtil.Format( "                    <div class=\"proposta-value\">%1</div>", AV9SdComprovante.gxTpr_Responsaveltipopessoa, "", "", "", "", "", "", "", "");
            AV8HTML += "                </div>";
            AV8HTML += "                <div class=\"proposta-info-item\">";
            AV8HTML += "                    <div class=\"proposta-label\"><i class=\"fas fa-info-circle\"></i> Descrição do Tipo Cliente:</div>";
            AV8HTML += StringUtil.Format( "                    <div class=\"proposta-value\">%1</div>", AV9SdComprovante.gxTpr_Responsaveltipoclientedescricao, "", "", "", "", "", "", "", "");
            AV8HTML += "                </div>";
            AV8HTML += "                <div class=\"proposta-info-item\">";
            AV8HTML += "                    <div class=\"proposta-label\"><i class=\"fas fa-calendar-alt\"></i> Data de Nascimento:</div>";
            AV8HTML += StringUtil.Format( "                    <div class=\"proposta-value\">%1</div>", context.localUtil.DToC( (DateTime)(AV9SdComprovante.gxTpr_Responsaveldatanascimento), 0, "-"), "", "", "", "", "", "", "", "");
            AV8HTML += "                </div>";
            AV8HTML += "                <div class=\"proposta-info-item\">";
            AV8HTML += "                    <div class=\"proposta-label\"><i class=\"fas fa-id-card-alt\"></i> RG:</div>";
            AV8HTML += StringUtil.Format( "                    <div class=\"proposta-value\">%1</div>", AV9SdComprovante.gxTpr_Responsavelrg, "", "", "", "", "", "", "", "");
            AV8HTML += "                </div>";
            AV8HTML += "                <div class=\"proposta-info-item\">";
            AV8HTML += "                    <div class=\"proposta-label\"><i class=\"fas fa-globe\"></i> Nacionalidade:</div>";
            AV8HTML += StringUtil.Format( "                    <div class=\"proposta-value\">%1</div>", AV9SdComprovante.gxTpr_Responsavelnacionalidade, "", "", "", "", "", "", "", "");
            AV8HTML += "                </div>";
            AV8HTML += "                <div class=\"proposta-info-item\">";
            AV8HTML += "                    <div class=\"proposta-label\"><i class=\"fas fa-ring\"></i> Estado Civil:</div>";
            AV8HTML += StringUtil.Format( "                    <div class=\"proposta-value\">%1</div>", AV9SdComprovante.gxTpr_Responsavelestadocivil, "", "", "", "", "", "", "", "");
            AV8HTML += "                </div>";
            AV8HTML += "                <div class=\"proposta-info-item\">";
            AV8HTML += "                    <div class=\"proposta-label\"><i class=\"fas fa-briefcase\"></i> Profissão:</div>";
            AV8HTML += StringUtil.Format( "                    <div class=\"proposta-value\">%1</div>", AV9SdComprovante.gxTpr_Responsavelprofissao, "", "", "", "", "", "", "", "");
            AV8HTML += "                </div>";
            AV8HTML += "            </div>";
            AV8HTML += "        </div>";
            AV8HTML += "";
            AV8HTML += "";
            AV8HTML += "                <div class=\"proposta-info-item\" style=\"width: 100%;\">";
            AV8HTML += "                    <div class=\"proposta-label\"><i class=\"fas fa-map-marker-alt\"></i> Endereço:</div>";
            AV8HTML += "                    <div class=\"proposta-value\">";
            AV8HTML += StringUtil.Format( "                        CEP: %1, Rua: %2, Bairro: %3, Cidade: %4, Município: %5 - %6, Número: %7, Complemento: %8", AV9SdComprovante.gxTpr_Clienteenderecocep, AV9SdComprovante.gxTpr_Clienteenderecologradouro, AV9SdComprovante.gxTpr_Clienteenderecobairro, AV9SdComprovante.gxTpr_Clienteenderecocidade, AV9SdComprovante.gxTpr_Clienteenderecomunicipionome, AV9SdComprovante.gxTpr_Clienteenderecomunicipiouf, AV9SdComprovante.gxTpr_Clienteendereconumero, AV9SdComprovante.gxTpr_Clienteenderecocomplemento, "");
            AV8HTML += "                    </div>";
            AV8HTML += "                </div>";
            AV8HTML += "        <div class=\"proposta-section proposta-contact-info\">";
            AV8HTML += "            <h2><i class=\"fas fa-phone\"></i> Contato</h2>";
            AV8HTML += "            <div class=\"proposta-info-group\">";
            AV8HTML += "                <div class=\"proposta-info-item\">";
            AV8HTML += "                    <div class=\"proposta-label\"><i class=\"fas fa-envelope\"></i> E-mail:</div>";
            AV8HTML += StringUtil.Format( "                    <div class=\"proposta-value\">%1</div>", AV9SdComprovante.gxTpr_Responsavelcontatoemail, "", "", "", "", "", "", "", "");
            AV8HTML += "                </div>";
            AV8HTML += "                <div class=\"proposta-info-item\">";
            AV8HTML += "                    <div class=\"proposta-label\"><i class=\"fas fa-phone-alt\"></i> DDD:</div>";
            AV8HTML += StringUtil.Format( "                    <div class=\"proposta-value\">%1</div>", StringUtil.LTrimStr( (decimal)(AV9SdComprovante.gxTpr_Responsavelcontatoddd), 4, 0), "", "", "", "", "", "", "", "");
            AV8HTML += "                </div>";
            AV8HTML += "                <div class=\"proposta-info-item\">";
            AV8HTML += "                    <div class=\"proposta-label\"><i class=\"fas fa-phone\"></i> Número:</div>";
            AV8HTML += StringUtil.Format( "                    <div class=\"proposta-value\">%1</div>", StringUtil.LTrimStr( (decimal)(AV9SdComprovante.gxTpr_Responsavelcontatonumero), 18, 0), "", "", "", "", "", "", "", "");
            AV8HTML += "                </div>";
            AV8HTML += "            </div>";
            AV8HTML += "        </div>";
         }
         AV8HTML += "        <div class=\"proposta-section proposta-bank-info\">";
         AV8HTML += "            <h2><i class=\"fas fa-university\"></i> Informações Bancárias</h2>";
         AV8HTML += "            <div class=\"proposta-info-group\">";
         if ( StringUtil.StrCmp(AV9SdComprovante.gxTpr_Bancopixtipo, "PIX") == 0 )
         {
            AV8HTML += "                <div id=\"BancoPIXInfo\" style=\" width: 100%; box-sizing: border-box;\">";
            AV8HTML += "                    <div class=\"proposta-info-item\" style=\"width: 100%;\">";
            AV8HTML += "                        <div class=\"proposta-label\"><i class=\"fas fa-qrcode\"></i> Tipo da Chave PIX:</div>";
            AV8HTML += StringUtil.Format( "                        <div class=\"proposta-value\">%1</div>", AV9SdComprovante.gxTpr_Bancopixtipo, "", "", "", "", "", "", "", "");
            AV8HTML += "                    </div>";
            AV8HTML += "                    <div class=\"proposta-info-item\" style=\"width: 100%;\">";
            AV8HTML += "                        <div class=\"proposta-label\"><i class=\"fas fa-key\"></i> Chave PIX:</div>";
            AV8HTML += StringUtil.Format( "                        <div class=\"proposta-value\">%1</div>", AV9SdComprovante.gxTpr_Bancopixchave, "", "", "", "", "", "", "", "");
            AV8HTML += "                    </div>";
            AV8HTML += "                </div>";
         }
         else
         {
            AV8HTML += "                <div id=\"BancoContaInfo\" style=\"width: 100%; box-sizing: border-box;\">";
            AV8HTML += "                    <div class=\"proposta-info-item\">";
            AV8HTML += "                        <div class=\"proposta-label\"><i class=\"fas fa-university\"></i> Banco:</div>";
            AV8HTML += StringUtil.Format( "                        <div class=\"proposta-value\">%1</div>", AV9SdComprovante.gxTpr_Banconome, "", "", "", "", "", "", "", "");
            AV8HTML += "                    </div>";
            AV8HTML += "                    <div class=\"proposta-info-item\">";
            AV8HTML += "                        <div class=\"proposta-label\"><i class=\"fas fa-building\"></i> Agência:</div>";
            AV8HTML += StringUtil.Format( "                        <div class=\"proposta-value\">%1</div>", AV9SdComprovante.gxTpr_Bancoagencia, "", "", "", "", "", "", "", "");
            AV8HTML += "                    </div>";
            AV8HTML += "                    <div class=\"proposta-info-item\">";
            AV8HTML += "                        <div class=\"proposta-label\"><i class=\"fas fa-wallet\"></i> Conta:</div>";
            AV8HTML += StringUtil.Format( "                        <div class=\"proposta-value\">%1</div>", AV9SdComprovante.gxTpr_Bancoconta, "", "", "", "", "", "", "", "");
            AV8HTML += "                    </div>";
            AV8HTML += "                </div>";
         }
         AV8HTML += "            </div>";
         AV8HTML += "        </div>";
         AV8HTML += "";
         AV8HTML += "        <div class=\"proposta-section proposta-proposal-info\">";
         AV8HTML += "            <h2><i class=\"fas fa-file-alt\"></i> Informações da Proposta</h2>";
         AV8HTML += "            <div class=\"proposta-info-group\">";
         AV8HTML += "                <div class=\"proposta-info-item\">";
         AV8HTML += "                    <div class=\"proposta-label\"><i class=\"fas fa-notes-medical\"></i> Procedimentos Médicos ID:</div>";
         AV8HTML += StringUtil.Format( "                    <div class=\"proposta-value\">%1</div>", AV9SdComprovante.gxTpr_Propostaprocedimentosmedicos, "", "", "", "", "", "", "", "");
         AV8HTML += "                </div>";
         AV8HTML += "                <div class=\"proposta-info-item\">";
         AV8HTML += "                    <div class=\"proposta-label\"><i class=\"fas fa-dollar-sign\"></i> Valor da Proposta:</div>";
         AV8HTML += StringUtil.Format( "                    <div class=\"proposta-value\">%1</div>", StringUtil.LTrimStr( (decimal)(AV9SdComprovante.gxTpr_Propostavalor), 18, 2), "", "", "", "", "", "", "", "");
         AV8HTML += "                </div>";
         AV8HTML += "                <div class=\"proposta-info-item\">";
         AV8HTML += "                    <div class=\"proposta-label\"><i class=\"fas fa-shield-alt\"></i> Convênio:</div>";
         AV8HTML += StringUtil.Format( "                    <div class=\"proposta-value\">%1</div>", AV9SdComprovante.gxTpr_Propostaconvenio, "", "", "", "", "", "", "", "");
         AV8HTML += "                </div>";
         AV8HTML += "                <div class=\"proposta-info-item\">";
         AV8HTML += "                    <div class=\"proposta-label\"><i class=\"fas fa-tag\"></i> Categoria do Convênio:</div>";
         AV8HTML += StringUtil.Format( "                    <div class=\"proposta-value\">%1</div>", AV9SdComprovante.gxTpr_Propostacategoriaconvenio, "", "", "", "", "", "", "", "");
         AV8HTML += "                </div>";
         AV8HTML += "                <div class=\"proposta-info-item\">";
         AV8HTML += "                    <div class=\"proposta-label\"><i class=\"fas fa-calendar-check\"></i> Vencimento da Carteirinha:</div>";
         AV8HTML += StringUtil.Format( "                    <div class=\"proposta-value\">%1</div>", AV9SdComprovante.gxTpr_Propostavencimentocarteirinha, "", "", "", "", "", "", "", "");
         AV8HTML += "                </div>";
         AV8HTML += "            </div>";
         AV8HTML += "        </div>";
         AV8HTML += "";
         AV8HTML += "    </div>";
         AV8HTML += "";
         AV8HTML += "";
         AV8HTML += "    </div>";
         AV8HTML += "<script>";
         AV8HTML += "        function downloadPDF() {";
         AV8HTML += "            const element = document.getElementById('propostaContent');";
         AV8HTML += "            element.classList.add('pdf-mode');";
         AV8HTML += "            document.querySelector(\".proposta-download-btn\").style.display = \"none\";";
         AV8HTML += "            const opt = {";
         AV8HTML += "                margin:       [10, 10, 10, 10], ";
         AV8HTML += "                filename:     \"proposta.pdf\",";
         AV8HTML += "                image:        { type: \"jpeg\", quality: 0.98 },";
         AV8HTML += "                html2canvas:  { scale: 2 },";
         AV8HTML += "                jsPDF:        { unit: \"mm\", format: \"a4\", orientation: \"portrait\" },";
         AV8HTML += "                pagebreak:    { mode: [\"avoid-all\", \"css\", \"legacy\"] } ";
         AV8HTML += "            };";
         AV8HTML += "";
         AV8HTML += "            html2pdf().set(opt).from(element).save().then(() => {";
         AV8HTML += "                document.querySelector(\".proposta-download-btn\").style.display = \"block\";";
         AV8HTML += "                element.classList.remove(\"pdf-mode\");";
         AV8HTML += "            });";
         AV8HTML += "        }";
         AV8HTML += "</script>";
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
      private SdtSdComprovante AV9SdComprovante ;
      private string aP1_HTML ;
   }

}
