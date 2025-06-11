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
   public class prtags : GXProcedure
   {
      public prtags( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prtags( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( SdtSdtListaTags aP0_SdtListaTags ,
                           ref string aP1_HTML )
      {
         this.AV9SdtListaTags = aP0_SdtListaTags;
         this.AV8HTML = aP1_HTML;
         initialize();
         ExecuteImpl();
         aP1_HTML=this.AV8HTML;
      }

      public string executeUdp( SdtSdtListaTags aP0_SdtListaTags )
      {
         execute(aP0_SdtListaTags, ref aP1_HTML);
         return AV8HTML ;
      }

      public void executeSubmit( SdtSdtListaTags aP0_SdtListaTags ,
                                 ref string aP1_HTML )
      {
         this.AV9SdtListaTags = aP0_SdtListaTags;
         this.AV8HTML = aP1_HTML;
         SubmitImpl();
         aP1_HTML=this.AV8HTML;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_char1 = AV8HTML;
         new initcap(context ).execute(  AV9SdtListaTags.gxTpr_Clienterazaosocial, out  GXt_char1) ;
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{NomeCompleto}}", GXt_char1);
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{TotalReceber}}", StringUtil.Str( AV9SdtListaTags.gxTpr_Clientevalorareceber_f, 18, 2));
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{TotalPagar}}", StringUtil.Str( AV9SdtListaTags.gxTpr_Clientevalorapagar_f, 18, 2));
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{Celular}}", AV9SdtListaTags.gxTpr_Clientecelular_f);
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{Telefone}}", AV9SdtListaTags.gxTpr_Clientetelefone_f);
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{DDI}}", StringUtil.Str( (decimal)(AV9SdtListaTags.gxTpr_Contatotelefoneddi), 4, 0));
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{DDD}}", StringUtil.Str( (decimal)(AV9SdtListaTags.gxTpr_Contatotelefoneddd), 4, 0));
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{NumeroTelefone}}", StringUtil.Str( (decimal)(AV9SdtListaTags.gxTpr_Contatotelefonenumero), 18, 0));
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{NumeroContato}}", StringUtil.Str( (decimal)(AV9SdtListaTags.gxTpr_Contatonumero), 18, 0));
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{ContatoDDI}}", StringUtil.Str( (decimal)(AV9SdtListaTags.gxTpr_Contatoddi), 4, 0));
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{ContatoDDD}}", StringUtil.Str( (decimal)(AV9SdtListaTags.gxTpr_Contatoddd), 4, 0));
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{ContatoEmail}}", AV9SdtListaTags.gxTpr_Contatoemail);
         GXt_char1 = AV8HTML;
         new initcap(context ).execute(  AV9SdtListaTags.gxTpr_Enderecocomplemento, out  GXt_char1) ;
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{EnderecoComplemento}}", GXt_char1);
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{EnderecoNumero}}", AV9SdtListaTags.gxTpr_Endereconumero);
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{UF}}", AV9SdtListaTags.gxTpr_Municipiouf);
         GXt_char1 = AV8HTML;
         new initcap(context ).execute(  AV9SdtListaTags.gxTpr_Municipionome, out  GXt_char1) ;
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{MunicipioNome}}", GXt_char1);
         GXt_char1 = AV8HTML;
         new initcap(context ).execute(  AV9SdtListaTags.gxTpr_Enderecocidade, out  GXt_char1) ;
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{EnderecoCidade}}", GXt_char1);
         GXt_char1 = AV8HTML;
         new initcap(context ).execute(  AV9SdtListaTags.gxTpr_Enderecobairro, out  GXt_char1) ;
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{EnderecoBairro}}", GXt_char1);
         GXt_char1 = AV8HTML;
         new initcap(context ).execute(  AV9SdtListaTags.gxTpr_Enderecologradouro, out  GXt_char1) ;
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{EnderecoLogradouro}}", GXt_char1);
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{EnderecoCEP}}", AV9SdtListaTags.gxTpr_Enderecocep);
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{EnderecoTipo}}", AV9SdtListaTags.gxTpr_Enderecotipo);
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{NomeUsuario}}", AV9SdtListaTags.gxTpr_Secusername);
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{Tipo}}", AV9SdtListaTags.gxTpr_Tipoclientedescricao);
         GXt_char1 = AV8HTML;
         new initcap(context ).execute(  AV9SdtListaTags.gxTpr_Clientetipopessoa, out  GXt_char1) ;
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{TipoPessoa}}", GXt_char1);
         GXt_char1 = AV8HTML;
         new initcap(context ).execute(  AV9SdtListaTags.gxTpr_Clienterazaosocial, out  GXt_char1) ;
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{RazaoSocial}}", GXt_char1);
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{CPF/CNPJ}}", AV9SdtListaTags.gxTpr_Clientedocumento);
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{RG}}", StringUtil.Trim( StringUtil.Str( (decimal)(AV9SdtListaTags.gxTpr_Clienterg), 12, 0)));
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{Convenio}}", AV9SdtListaTags.gxTpr_Conveniodescricao);
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{ValorProposta}}", context.localUtil.Format( AV9SdtListaTags.gxTpr_Propostavalor, "ZZZ,ZZZ,ZZZ,ZZ9.99"));
         GXt_char1 = AV8HTML;
         new initcap(context ).execute(  AV9SdtListaTags.gxTpr_Responsavelnome, out  GXt_char1) ;
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{RepresentanteNomeCompleto}}", GXt_char1);
         GXt_char1 = AV8HTML;
         new initcap(context ).execute(  AV9SdtListaTags.gxTpr_Responsavelnacionalidadenome, out  GXt_char1) ;
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{RepresentanteNacionalidade}}", GXt_char1);
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{RepresentanteEstadoCivil}}", AV9SdtListaTags.gxTpr_Responsavelestadocivil);
         GXt_char1 = AV8HTML;
         new initcap(context ).execute(  AV9SdtListaTags.gxTpr_Responsavelprofissaonome, out  GXt_char1) ;
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{RepresentanteProfissão}}", GXt_char1);
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{RepresentanteCPF}}", AV9SdtListaTags.gxTpr_Responsavelcpf);
         GXt_char1 = AV8HTML;
         new initcap(context ).execute(  AV9SdtListaTags.gxTpr_Responsavellogradouro, out  GXt_char1) ;
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{RepresentanteLogadouro}}", GXt_char1);
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{RepresentanteEnderecoNumero}}", StringUtil.Trim( StringUtil.Str( (decimal)(AV9SdtListaTags.gxTpr_Responsavellogradouronumero), 9, 0)));
         GXt_char1 = AV8HTML;
         new initcap(context ).execute(  AV9SdtListaTags.gxTpr_Responsavelcomplemento, out  GXt_char1) ;
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{RepresentanteComplemento}}", GXt_char1);
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{RepresentanteMunicipio}}", AV9SdtListaTags.gxTpr_Responsavelmunicipionome);
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{RepresentanteCidade}}", AV9SdtListaTags.gxTpr_Responsavelcidade);
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{RepresentanteUF}}", AV9SdtListaTags.gxTpr_Responsavelmunicipiouf);
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{RepresentanteCEP}}", StringUtil.Trim( AV9SdtListaTags.gxTpr_Responsavelcep));
         GXt_char1 = AV8HTML;
         new initcap(context ).execute(  AV9SdtListaTags.gxTpr_Responsavelbairro, out  GXt_char1) ;
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{RepresentanteBairro}}", GXt_char1);
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{ContratoJurosMora}}", StringUtil.Trim( StringUtil.Str( AV9SdtListaTags.gxTpr_Contratojurosmora, 16, 4)));
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{ContratoTaxaAdministrativa}}", StringUtil.Trim( StringUtil.Str( AV9SdtListaTags.gxTpr_Contratotaxa, 16, 4)));
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{ContratoIOFMinimo}}", StringUtil.Trim( StringUtil.Str( AV9SdtListaTags.gxTpr_Contratoiofminimo, 16, 4)));
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{EmpresaBanco}}", AV9SdtListaTags.gxTpr_Empresabanconome);
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{EmpresaAgencia}}", StringUtil.Trim( StringUtil.Str( (decimal)(AV9SdtListaTags.gxTpr_Empresaagencia), 9, 0)));
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{EmpresaConta}}", StringUtil.Trim( StringUtil.Str( (decimal)(AV9SdtListaTags.gxTpr_Empresaconta), 8, 0)));
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{EmpresaPix}}", AV9SdtListaTags.gxTpr_Empresapix);
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{EmpresaEmail}}", StringUtil.Lower( AV9SdtListaTags.gxTpr_Empresaemail));
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{ClienteNacionalidade}}", AV9SdtListaTags.gxTpr_Clientenacionalidade);
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{ClienteEstadoCivil}}", AV9SdtListaTags.gxTpr_Clienteestadocivil);
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{ClienteProfissão}}", AV9SdtListaTags.gxTpr_Clienteprofissao);
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{ClienteRG}}", StringUtil.Trim( StringUtil.Str( (decimal)(AV9SdtListaTags.gxTpr_Clienterg), 12, 0)));
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{CategoriaConvenio}}", StringUtil.Trim( AV9SdtListaTags.gxTpr_Conveniocategoriadescricao));
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{ConvenioMes}}", StringUtil.Trim( StringUtil.Str( (decimal)(AV9SdtListaTags.gxTpr_Conveniovencimentomes), 4, 0)));
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{ConvenioAno}}", StringUtil.Trim( StringUtil.Str( (decimal)(AV9SdtListaTags.gxTpr_Conveniovencimentoano), 4, 0)));
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{DiaAtual}}", StringUtil.Trim( StringUtil.Str( (decimal)(AV9SdtListaTags.gxTpr_Diaatual), 4, 0)));
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{AnoAtual}}", StringUtil.Trim( StringUtil.Str( (decimal)(AV9SdtListaTags.gxTpr_Anoatual), 4, 0)));
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{MesAtualExtenso}}", StringUtil.Trim( AV9SdtListaTags.gxTpr_Mesatualextenso));
         GXt_char1 = AV8HTML;
         new initcap(context ).execute(  StringUtil.Trim( AV9SdtListaTags.gxTpr_Clinicarazaosocial), out  GXt_char1) ;
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{ClinicaRazaoSocial}}", GXt_char1);
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{ClinicaEndereço}}", StringUtil.Trim( AV9SdtListaTags.gxTpr_Clinicaendereco));
         GXt_char1 = AV8HTML;
         new initcap(context ).execute(  StringUtil.Trim( AV9SdtListaTags.gxTpr_Clinicabairro), out  GXt_char1) ;
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{ClinicaBairro}}", GXt_char1);
         GXt_char1 = AV8HTML;
         new initcap(context ).execute(  StringUtil.Trim( AV9SdtListaTags.gxTpr_Clinicarepresentantenome), out  GXt_char1) ;
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{ClinicaRepresentanteNome}}", GXt_char1);
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{ClinicaRepresentanteCPF}}", StringUtil.Trim( AV9SdtListaTags.gxTpr_Clinicarepresentantecpf));
         GXt_char1 = AV8HTML;
         new initcap(context ).execute(  StringUtil.Trim( AV9SdtListaTags.gxTpr_Testemunhapadraonome1), out  GXt_char1) ;
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{TestemunhaPadraoNome1}}", GXt_char1);
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{TestemunhaPadraoCPF1}}", StringUtil.Trim( AV9SdtListaTags.gxTpr_Testemunhapadraocpf1));
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{TestemunhaPadraoNome1}}", StringUtil.Trim( AV9SdtListaTags.gxTpr_Testemunhapadraonome1));
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{ValorTaxa}}", StringUtil.Trim( StringUtil.Str( AV9SdtListaTags.gxTpr_Valortaxa, 18, 2)));
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{ValorTaxaExtenso}}", StringUtil.Trim( AV9SdtListaTags.gxTpr_Valortaxaextenso));
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{ValorPropostaExtenso}}", StringUtil.Trim( AV9SdtListaTags.gxTpr_Valorpropostaextenso));
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{NumeroNotaEmprestimo}}", StringUtil.Trim( StringUtil.Str( (decimal)(AV9SdtListaTags.gxTpr_Numeronotaemprestimo), 9, 0)));
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{NumeroNotaEmprestimo}}", StringUtil.Trim( StringUtil.Str( (decimal)(AV9SdtListaTags.gxTpr_Numeronotaemprestimo), 9, 0)));
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{ClinicaRepresentanteNacionalidade}}", StringUtil.Trim( AV9SdtListaTags.gxTpr_Clinicarepresentantenacionalidade));
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{ClinicaRepresentanteEstadoCivil}}", AV9SdtListaTags.gxTpr_Clinicarepresentanteestadocivil);
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{ClinicaRepresentanteProfissão}}", StringUtil.Trim( AV9SdtListaTags.gxTpr_Clinicarepresentanteprofissao));
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{ClinicaRepresentanteRG}}", StringUtil.Trim( StringUtil.Str( (decimal)(AV9SdtListaTags.gxTpr_Clinicarepresentanterg), 12, 0)));
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{ClinicaRepresentanteEndereco}}", StringUtil.Trim( AV9SdtListaTags.gxTpr_Clinicarepresentanteendereco));
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{ClinicaRepresentanteTelefone}}", StringUtil.Trim( AV9SdtListaTags.gxTpr_Clinicarepresentantetelefone));
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{ClinicaRepresentanteCelular}}", StringUtil.Trim( AV9SdtListaTags.gxTpr_Clinicarepresentantecelular));
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{ClinicaRepresentanteEmail}}", StringUtil.Trim( AV9SdtListaTags.gxTpr_Clinicarepresentanteemail));
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{ClinicaCNPJ}}", StringUtil.Trim( AV9SdtListaTags.gxTpr_Clinicacnpj));
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{ClienteBanco}}", StringUtil.Trim( AV9SdtListaTags.gxTpr_Clientebanco));
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{ClienteAgencia}}", StringUtil.Trim( AV9SdtListaTags.gxTpr_Clienteagencia));
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{ClienteConta}}", StringUtil.Trim( AV9SdtListaTags.gxTpr_Clienteconta));
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{ClientePIX}}", StringUtil.Trim( AV9SdtListaTags.gxTpr_Clientepix));
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{ClinicaBanco}}", StringUtil.Trim( AV9SdtListaTags.gxTpr_Clinicabanco));
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{ClinicaAgencia}}", StringUtil.Trim( AV9SdtListaTags.gxTpr_Clinicaagencia));
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{ClinicaConta}}", StringUtil.Trim( AV9SdtListaTags.gxTpr_Clinicaconta));
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{ClinicaPIX}}", StringUtil.Trim( AV9SdtListaTags.gxTpr_Clinicapix));
         GXt_char1 = AV8HTML;
         new initcap(context ).execute(  StringUtil.Trim( AV9SdtListaTags.gxTpr_Procedimentosmedicosdescricao), out  GXt_char1) ;
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{Procedimento}}", GXt_char1);
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{ReembolsoValor}}", StringUtil.Str( AV9SdtListaTags.gxTpr_Reembolsovalorreembolsado_f, 18, 2));
         if ( (Convert.ToDecimal(0)==AV9SdtListaTags.gxTpr_Reembolsosaldovalor) )
         {
            AV8HTML = StringUtil.StringReplace( AV8HTML, "{{ValorRemanescente}}", "0,00");
         }
         else
         {
            AV8HTML = StringUtil.StringReplace( AV8HTML, "{{ValorRemanescente}}", StringUtil.Str( AV9SdtListaTags.gxTpr_Reembolsosaldovalor, 18, 2));
         }
         AV8HTML = StringUtil.StringReplace( AV8HTML, "{{ClinicaValor}}", StringUtil.Str( AV9SdtListaTags.gxTpr_Propostavalortaxaclinica_f, 18, 2));
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
         GXt_char1 = "";
         /* GeneXus formulas. */
      }

      private string GXt_char1 ;
      private string AV8HTML ;
      private SdtSdtListaTags AV9SdtListaTags ;
      private string aP1_HTML ;
   }

}
