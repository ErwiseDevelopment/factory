using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   [XmlRoot(ElementName = "Configuracoes" )]
   [XmlType(TypeName =  "Configuracoes" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtConfiguracoes : GxSilentTrnSdt
   {
      public SdtConfiguracoes( )
      {
      }

      public SdtConfiguracoes( IGxContext context )
      {
         this.context = context;
         constructorCallingAssembly = Assembly.GetEntryAssembly();
         initialize();
      }

      private static Hashtable mapper;
      public override string JsonMap( string value )
      {
         if ( mapper == null )
         {
            mapper = new Hashtable();
         }
         return (string)mapper[value]; ;
      }

      public void Load( int AV299ConfiguracoesId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV299ConfiguracoesId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ConfiguracoesId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Configuracoes");
         metadata.Set("BT", "Configuracoes");
         metadata.Set("PK", "[ \"ConfiguracoesId\" ]");
         metadata.Set("PKAssigned", "[ \"ConfiguracoesId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"CategoriaTituloId\" ],\"FKMap\":[ \"ConfiguracoesCategoriaTitulo-CategoriaTituloId\" ] },{ \"FK\":[ \"LayoutContratoId\" ],\"FKMap\":[ \"ConfigLayoutContratoCompraTitulo-LayoutContratoId\" ] },{ \"FK\":[ \"LayoutContratoId\" ],\"FKMap\":[ \"ConfigLayoutPromissoriaClinicaEmprestimo-LayoutContratoId\" ] },{ \"FK\":[ \"LayoutContratoId\" ],\"FKMap\":[ \"ConfigLayoutPromissoriaClinicaTaxa-LayoutContratoId\" ] },{ \"FK\":[ \"LayoutContratoId\" ],\"FKMap\":[ \"ConfigLayoutPromissoriaPaciente-LayoutContratoId\" ] },{ \"FK\":[ \"LayoutContratoId\" ],\"FKMap\":[ \"ConfiguracoesLayoutProposta-LayoutContratoId\" ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Configuracoesid_Z");
         state.Add("gxTpr_Configuracoesimagemloginnome_Z");
         state.Add("gxTpr_Configuracoesimagemloginextencao_Z");
         state.Add("gxTpr_Configuracoesimagemloginnomeinteiro_Z");
         state.Add("gxTpr_Configuracoesimagemlogintamanho_Z");
         state.Add("gxTpr_Configuracoesimagemloginbackground_Z");
         state.Add("gxTpr_Configuracoesimagemheadernome_Z");
         state.Add("gxTpr_Configuracoesimagemheaderextencao_Z");
         state.Add("gxTpr_Configuracoesimagemheadernomeinteiro_Z");
         state.Add("gxTpr_Configuracoesimagemheadertamanho_Z");
         state.Add("gxTpr_Configuracoeslayoutproposta_Z");
         state.Add("gxTpr_Configlayoutpromissoriaclinicaemprestimo_Z");
         state.Add("gxTpr_Configlayoutpromissoriaclinicataxa_Z");
         state.Add("gxTpr_Configlayoutpromissoriapaciente_Z");
         state.Add("gxTpr_Configlayoutcontratocompratitulo_Z");
         state.Add("gxTpr_Configuracaosenhapfx_Z");
         state.Add("gxTpr_Configuracoescategoriatitulo_Z");
         state.Add("gxTpr_Configuracoesserasaanotacoescompletas_Z");
         state.Add("gxTpr_Configuracoesserasaconsultadetalhada_Z");
         state.Add("gxTpr_Configuracoesserasaparticipacaosocietaria_Z");
         state.Add("gxTpr_Configuracoesserasarendaestimada_Z");
         state.Add("gxTpr_Configuracoesserasahistoricopagamento_Z");
         state.Add("gxTpr_Configuracoescompratitulotaxaefetiva_Z");
         state.Add("gxTpr_Configuracoescompratitulotaxamora_Z");
         state.Add("gxTpr_Configuracoescompratitulofator_Z");
         state.Add("gxTpr_Configuracoescompratitulotarifatipo_Z");
         state.Add("gxTpr_Configuracoescompratitulotarifa_Z");
         state.Add("gxTpr_Configuracoesimagemlogin_N");
         state.Add("gxTpr_Configuracoesimagemloginnome_N");
         state.Add("gxTpr_Configuracoesimagemloginextencao_N");
         state.Add("gxTpr_Configuracoesimagemloginnomeinteiro_N");
         state.Add("gxTpr_Configuracoesimagemlogintamanho_N");
         state.Add("gxTpr_Configuracoesimagemloginbackground_N");
         state.Add("gxTpr_Configuracoesimagemheader_N");
         state.Add("gxTpr_Configuracoesimagemheadernome_N");
         state.Add("gxTpr_Configuracoesimagemheaderextencao_N");
         state.Add("gxTpr_Configuracoesimagemheadernomeinteiro_N");
         state.Add("gxTpr_Configuracoesimagemheadertamanho_N");
         state.Add("gxTpr_Configuracoeslayoutproposta_N");
         state.Add("gxTpr_Configuracoeslayoutcontratocorpo_N");
         state.Add("gxTpr_Configlayoutpromissoriaclinicaemprestimo_N");
         state.Add("gxTpr_Configlayoutcorpopromissoriaclinicaemprestimo_N");
         state.Add("gxTpr_Configlayoutpromissoriaclinicataxa_N");
         state.Add("gxTpr_Configlayoutcorpopromissoriaclinicataxa_N");
         state.Add("gxTpr_Configlayoutpromissoriapaciente_N");
         state.Add("gxTpr_Configlayoutcontratocompratitulo_N");
         state.Add("gxTpr_Configlayoutcorpopromissoriapaciente_N");
         state.Add("gxTpr_Configuracoesarquivopfx_N");
         state.Add("gxTpr_Configuracaosenhapfx_N");
         state.Add("gxTpr_Configuracoescategoriatitulo_N");
         state.Add("gxTpr_Configuracoesserasaanotacoescompletas_N");
         state.Add("gxTpr_Configuracoesserasaconsultadetalhada_N");
         state.Add("gxTpr_Configuracoesserasaparticipacaosocietaria_N");
         state.Add("gxTpr_Configuracoesserasarendaestimada_N");
         state.Add("gxTpr_Configuracoesserasahistoricopagamento_N");
         state.Add("gxTpr_Configuracoescompratitulotaxaefetiva_N");
         state.Add("gxTpr_Configuracoescompratitulotaxamora_N");
         state.Add("gxTpr_Configuracoescompratitulofator_N");
         state.Add("gxTpr_Configuracoescompratitulotarifatipo_N");
         state.Add("gxTpr_Configuracoescompratitulotarifa_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtConfiguracoes sdt;
         sdt = (SdtConfiguracoes)(source);
         gxTv_SdtConfiguracoes_Configuracoesid = sdt.gxTv_SdtConfiguracoes_Configuracoesid ;
         gxTv_SdtConfiguracoes_Configuracoesimagemlogin = sdt.gxTv_SdtConfiguracoes_Configuracoesimagemlogin ;
         gxTv_SdtConfiguracoes_Configuracoesimagemloginnome = sdt.gxTv_SdtConfiguracoes_Configuracoesimagemloginnome ;
         gxTv_SdtConfiguracoes_Configuracoesimagemloginextencao = sdt.gxTv_SdtConfiguracoes_Configuracoesimagemloginextencao ;
         gxTv_SdtConfiguracoes_Configuracoesimagemloginnomeinteiro = sdt.gxTv_SdtConfiguracoes_Configuracoesimagemloginnomeinteiro ;
         gxTv_SdtConfiguracoes_Configuracoesimagemlogintamanho = sdt.gxTv_SdtConfiguracoes_Configuracoesimagemlogintamanho ;
         gxTv_SdtConfiguracoes_Configuracoesimagemloginbackground = sdt.gxTv_SdtConfiguracoes_Configuracoesimagemloginbackground ;
         gxTv_SdtConfiguracoes_Configuracoesimagemheader = sdt.gxTv_SdtConfiguracoes_Configuracoesimagemheader ;
         gxTv_SdtConfiguracoes_Configuracoesimagemheadernome = sdt.gxTv_SdtConfiguracoes_Configuracoesimagemheadernome ;
         gxTv_SdtConfiguracoes_Configuracoesimagemheaderextencao = sdt.gxTv_SdtConfiguracoes_Configuracoesimagemheaderextencao ;
         gxTv_SdtConfiguracoes_Configuracoesimagemheadernomeinteiro = sdt.gxTv_SdtConfiguracoes_Configuracoesimagemheadernomeinteiro ;
         gxTv_SdtConfiguracoes_Configuracoesimagemheadertamanho = sdt.gxTv_SdtConfiguracoes_Configuracoesimagemheadertamanho ;
         gxTv_SdtConfiguracoes_Configuracoeslayoutproposta = sdt.gxTv_SdtConfiguracoes_Configuracoeslayoutproposta ;
         gxTv_SdtConfiguracoes_Configuracoeslayoutcontratocorpo = sdt.gxTv_SdtConfiguracoes_Configuracoeslayoutcontratocorpo ;
         gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicaemprestimo = sdt.gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicaemprestimo ;
         gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriaclinicaemprestimo = sdt.gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriaclinicaemprestimo ;
         gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicataxa = sdt.gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicataxa ;
         gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriaclinicataxa = sdt.gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriaclinicataxa ;
         gxTv_SdtConfiguracoes_Configlayoutpromissoriapaciente = sdt.gxTv_SdtConfiguracoes_Configlayoutpromissoriapaciente ;
         gxTv_SdtConfiguracoes_Configlayoutcontratocompratitulo = sdt.gxTv_SdtConfiguracoes_Configlayoutcontratocompratitulo ;
         gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriapaciente = sdt.gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriapaciente ;
         gxTv_SdtConfiguracoes_Configuracoesarquivopfx = sdt.gxTv_SdtConfiguracoes_Configuracoesarquivopfx ;
         gxTv_SdtConfiguracoes_Configuracaosenhapfx = sdt.gxTv_SdtConfiguracoes_Configuracaosenhapfx ;
         gxTv_SdtConfiguracoes_Configuracoescategoriatitulo = sdt.gxTv_SdtConfiguracoes_Configuracoescategoriatitulo ;
         gxTv_SdtConfiguracoes_Configuracoesserasaanotacoescompletas = sdt.gxTv_SdtConfiguracoes_Configuracoesserasaanotacoescompletas ;
         gxTv_SdtConfiguracoes_Configuracoesserasaconsultadetalhada = sdt.gxTv_SdtConfiguracoes_Configuracoesserasaconsultadetalhada ;
         gxTv_SdtConfiguracoes_Configuracoesserasaparticipacaosocietaria = sdt.gxTv_SdtConfiguracoes_Configuracoesserasaparticipacaosocietaria ;
         gxTv_SdtConfiguracoes_Configuracoesserasarendaestimada = sdt.gxTv_SdtConfiguracoes_Configuracoesserasarendaestimada ;
         gxTv_SdtConfiguracoes_Configuracoesserasahistoricopagamento = sdt.gxTv_SdtConfiguracoes_Configuracoesserasahistoricopagamento ;
         gxTv_SdtConfiguracoes_Configuracoescompratitulotaxaefetiva = sdt.gxTv_SdtConfiguracoes_Configuracoescompratitulotaxaefetiva ;
         gxTv_SdtConfiguracoes_Configuracoescompratitulotaxamora = sdt.gxTv_SdtConfiguracoes_Configuracoescompratitulotaxamora ;
         gxTv_SdtConfiguracoes_Configuracoescompratitulofator = sdt.gxTv_SdtConfiguracoes_Configuracoescompratitulofator ;
         gxTv_SdtConfiguracoes_Configuracoescompratitulotarifatipo = sdt.gxTv_SdtConfiguracoes_Configuracoescompratitulotarifatipo ;
         gxTv_SdtConfiguracoes_Configuracoescompratitulotarifa = sdt.gxTv_SdtConfiguracoes_Configuracoescompratitulotarifa ;
         gxTv_SdtConfiguracoes_Mode = sdt.gxTv_SdtConfiguracoes_Mode ;
         gxTv_SdtConfiguracoes_Initialized = sdt.gxTv_SdtConfiguracoes_Initialized ;
         gxTv_SdtConfiguracoes_Configuracoesid_Z = sdt.gxTv_SdtConfiguracoes_Configuracoesid_Z ;
         gxTv_SdtConfiguracoes_Configuracoesimagemloginnome_Z = sdt.gxTv_SdtConfiguracoes_Configuracoesimagemloginnome_Z ;
         gxTv_SdtConfiguracoes_Configuracoesimagemloginextencao_Z = sdt.gxTv_SdtConfiguracoes_Configuracoesimagemloginextencao_Z ;
         gxTv_SdtConfiguracoes_Configuracoesimagemloginnomeinteiro_Z = sdt.gxTv_SdtConfiguracoes_Configuracoesimagemloginnomeinteiro_Z ;
         gxTv_SdtConfiguracoes_Configuracoesimagemlogintamanho_Z = sdt.gxTv_SdtConfiguracoes_Configuracoesimagemlogintamanho_Z ;
         gxTv_SdtConfiguracoes_Configuracoesimagemloginbackground_Z = sdt.gxTv_SdtConfiguracoes_Configuracoesimagemloginbackground_Z ;
         gxTv_SdtConfiguracoes_Configuracoesimagemheadernome_Z = sdt.gxTv_SdtConfiguracoes_Configuracoesimagemheadernome_Z ;
         gxTv_SdtConfiguracoes_Configuracoesimagemheaderextencao_Z = sdt.gxTv_SdtConfiguracoes_Configuracoesimagemheaderextencao_Z ;
         gxTv_SdtConfiguracoes_Configuracoesimagemheadernomeinteiro_Z = sdt.gxTv_SdtConfiguracoes_Configuracoesimagemheadernomeinteiro_Z ;
         gxTv_SdtConfiguracoes_Configuracoesimagemheadertamanho_Z = sdt.gxTv_SdtConfiguracoes_Configuracoesimagemheadertamanho_Z ;
         gxTv_SdtConfiguracoes_Configuracoeslayoutproposta_Z = sdt.gxTv_SdtConfiguracoes_Configuracoeslayoutproposta_Z ;
         gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicaemprestimo_Z = sdt.gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicaemprestimo_Z ;
         gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicataxa_Z = sdt.gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicataxa_Z ;
         gxTv_SdtConfiguracoes_Configlayoutpromissoriapaciente_Z = sdt.gxTv_SdtConfiguracoes_Configlayoutpromissoriapaciente_Z ;
         gxTv_SdtConfiguracoes_Configlayoutcontratocompratitulo_Z = sdt.gxTv_SdtConfiguracoes_Configlayoutcontratocompratitulo_Z ;
         gxTv_SdtConfiguracoes_Configuracaosenhapfx_Z = sdt.gxTv_SdtConfiguracoes_Configuracaosenhapfx_Z ;
         gxTv_SdtConfiguracoes_Configuracoescategoriatitulo_Z = sdt.gxTv_SdtConfiguracoes_Configuracoescategoriatitulo_Z ;
         gxTv_SdtConfiguracoes_Configuracoesserasaanotacoescompletas_Z = sdt.gxTv_SdtConfiguracoes_Configuracoesserasaanotacoescompletas_Z ;
         gxTv_SdtConfiguracoes_Configuracoesserasaconsultadetalhada_Z = sdt.gxTv_SdtConfiguracoes_Configuracoesserasaconsultadetalhada_Z ;
         gxTv_SdtConfiguracoes_Configuracoesserasaparticipacaosocietaria_Z = sdt.gxTv_SdtConfiguracoes_Configuracoesserasaparticipacaosocietaria_Z ;
         gxTv_SdtConfiguracoes_Configuracoesserasarendaestimada_Z = sdt.gxTv_SdtConfiguracoes_Configuracoesserasarendaestimada_Z ;
         gxTv_SdtConfiguracoes_Configuracoesserasahistoricopagamento_Z = sdt.gxTv_SdtConfiguracoes_Configuracoesserasahistoricopagamento_Z ;
         gxTv_SdtConfiguracoes_Configuracoescompratitulotaxaefetiva_Z = sdt.gxTv_SdtConfiguracoes_Configuracoescompratitulotaxaefetiva_Z ;
         gxTv_SdtConfiguracoes_Configuracoescompratitulotaxamora_Z = sdt.gxTv_SdtConfiguracoes_Configuracoescompratitulotaxamora_Z ;
         gxTv_SdtConfiguracoes_Configuracoescompratitulofator_Z = sdt.gxTv_SdtConfiguracoes_Configuracoescompratitulofator_Z ;
         gxTv_SdtConfiguracoes_Configuracoescompratitulotarifatipo_Z = sdt.gxTv_SdtConfiguracoes_Configuracoescompratitulotarifatipo_Z ;
         gxTv_SdtConfiguracoes_Configuracoescompratitulotarifa_Z = sdt.gxTv_SdtConfiguracoes_Configuracoescompratitulotarifa_Z ;
         gxTv_SdtConfiguracoes_Configuracoesimagemlogin_N = sdt.gxTv_SdtConfiguracoes_Configuracoesimagemlogin_N ;
         gxTv_SdtConfiguracoes_Configuracoesimagemloginnome_N = sdt.gxTv_SdtConfiguracoes_Configuracoesimagemloginnome_N ;
         gxTv_SdtConfiguracoes_Configuracoesimagemloginextencao_N = sdt.gxTv_SdtConfiguracoes_Configuracoesimagemloginextencao_N ;
         gxTv_SdtConfiguracoes_Configuracoesimagemloginnomeinteiro_N = sdt.gxTv_SdtConfiguracoes_Configuracoesimagemloginnomeinteiro_N ;
         gxTv_SdtConfiguracoes_Configuracoesimagemlogintamanho_N = sdt.gxTv_SdtConfiguracoes_Configuracoesimagemlogintamanho_N ;
         gxTv_SdtConfiguracoes_Configuracoesimagemloginbackground_N = sdt.gxTv_SdtConfiguracoes_Configuracoesimagemloginbackground_N ;
         gxTv_SdtConfiguracoes_Configuracoesimagemheader_N = sdt.gxTv_SdtConfiguracoes_Configuracoesimagemheader_N ;
         gxTv_SdtConfiguracoes_Configuracoesimagemheadernome_N = sdt.gxTv_SdtConfiguracoes_Configuracoesimagemheadernome_N ;
         gxTv_SdtConfiguracoes_Configuracoesimagemheaderextencao_N = sdt.gxTv_SdtConfiguracoes_Configuracoesimagemheaderextencao_N ;
         gxTv_SdtConfiguracoes_Configuracoesimagemheadernomeinteiro_N = sdt.gxTv_SdtConfiguracoes_Configuracoesimagemheadernomeinteiro_N ;
         gxTv_SdtConfiguracoes_Configuracoesimagemheadertamanho_N = sdt.gxTv_SdtConfiguracoes_Configuracoesimagemheadertamanho_N ;
         gxTv_SdtConfiguracoes_Configuracoeslayoutproposta_N = sdt.gxTv_SdtConfiguracoes_Configuracoeslayoutproposta_N ;
         gxTv_SdtConfiguracoes_Configuracoeslayoutcontratocorpo_N = sdt.gxTv_SdtConfiguracoes_Configuracoeslayoutcontratocorpo_N ;
         gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicaemprestimo_N = sdt.gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicaemprestimo_N ;
         gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriaclinicaemprestimo_N = sdt.gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriaclinicaemprestimo_N ;
         gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicataxa_N = sdt.gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicataxa_N ;
         gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriaclinicataxa_N = sdt.gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriaclinicataxa_N ;
         gxTv_SdtConfiguracoes_Configlayoutpromissoriapaciente_N = sdt.gxTv_SdtConfiguracoes_Configlayoutpromissoriapaciente_N ;
         gxTv_SdtConfiguracoes_Configlayoutcontratocompratitulo_N = sdt.gxTv_SdtConfiguracoes_Configlayoutcontratocompratitulo_N ;
         gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriapaciente_N = sdt.gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriapaciente_N ;
         gxTv_SdtConfiguracoes_Configuracoesarquivopfx_N = sdt.gxTv_SdtConfiguracoes_Configuracoesarquivopfx_N ;
         gxTv_SdtConfiguracoes_Configuracaosenhapfx_N = sdt.gxTv_SdtConfiguracoes_Configuracaosenhapfx_N ;
         gxTv_SdtConfiguracoes_Configuracoescategoriatitulo_N = sdt.gxTv_SdtConfiguracoes_Configuracoescategoriatitulo_N ;
         gxTv_SdtConfiguracoes_Configuracoesserasaanotacoescompletas_N = sdt.gxTv_SdtConfiguracoes_Configuracoesserasaanotacoescompletas_N ;
         gxTv_SdtConfiguracoes_Configuracoesserasaconsultadetalhada_N = sdt.gxTv_SdtConfiguracoes_Configuracoesserasaconsultadetalhada_N ;
         gxTv_SdtConfiguracoes_Configuracoesserasaparticipacaosocietaria_N = sdt.gxTv_SdtConfiguracoes_Configuracoesserasaparticipacaosocietaria_N ;
         gxTv_SdtConfiguracoes_Configuracoesserasarendaestimada_N = sdt.gxTv_SdtConfiguracoes_Configuracoesserasarendaestimada_N ;
         gxTv_SdtConfiguracoes_Configuracoesserasahistoricopagamento_N = sdt.gxTv_SdtConfiguracoes_Configuracoesserasahistoricopagamento_N ;
         gxTv_SdtConfiguracoes_Configuracoescompratitulotaxaefetiva_N = sdt.gxTv_SdtConfiguracoes_Configuracoescompratitulotaxaefetiva_N ;
         gxTv_SdtConfiguracoes_Configuracoescompratitulotaxamora_N = sdt.gxTv_SdtConfiguracoes_Configuracoescompratitulotaxamora_N ;
         gxTv_SdtConfiguracoes_Configuracoescompratitulofator_N = sdt.gxTv_SdtConfiguracoes_Configuracoescompratitulofator_N ;
         gxTv_SdtConfiguracoes_Configuracoescompratitulotarifatipo_N = sdt.gxTv_SdtConfiguracoes_Configuracoescompratitulotarifatipo_N ;
         gxTv_SdtConfiguracoes_Configuracoescompratitulotarifa_N = sdt.gxTv_SdtConfiguracoes_Configuracoescompratitulotarifa_N ;
         return  ;
      }

      public override void ToJSON( )
      {
         ToJSON( true) ;
         return  ;
      }

      public override void ToJSON( bool includeState )
      {
         ToJSON( includeState, true) ;
         return  ;
      }

      public override void ToJSON( bool includeState ,
                                   bool includeNonInitialized )
      {
         AddObjectProperty("ConfiguracoesId", gxTv_SdtConfiguracoes_Configuracoesid, false, includeNonInitialized);
         AddObjectProperty("ConfiguracoesImagemLogin", gxTv_SdtConfiguracoes_Configuracoesimagemlogin, false, includeNonInitialized);
         AddObjectProperty("ConfiguracoesImagemLogin_N", gxTv_SdtConfiguracoes_Configuracoesimagemlogin_N, false, includeNonInitialized);
         AddObjectProperty("ConfiguracoesImagemLoginNome", gxTv_SdtConfiguracoes_Configuracoesimagemloginnome, false, includeNonInitialized);
         AddObjectProperty("ConfiguracoesImagemLoginNome_N", gxTv_SdtConfiguracoes_Configuracoesimagemloginnome_N, false, includeNonInitialized);
         AddObjectProperty("ConfiguracoesImagemLoginExtencao", gxTv_SdtConfiguracoes_Configuracoesimagemloginextencao, false, includeNonInitialized);
         AddObjectProperty("ConfiguracoesImagemLoginExtencao_N", gxTv_SdtConfiguracoes_Configuracoesimagemloginextencao_N, false, includeNonInitialized);
         AddObjectProperty("ConfiguracoesImagemLoginNomeInteiro", gxTv_SdtConfiguracoes_Configuracoesimagemloginnomeinteiro, false, includeNonInitialized);
         AddObjectProperty("ConfiguracoesImagemLoginNomeInteiro_N", gxTv_SdtConfiguracoes_Configuracoesimagemloginnomeinteiro_N, false, includeNonInitialized);
         AddObjectProperty("ConfiguracoesImagemLoginTamanho", StringUtil.LTrim( StringUtil.Str( gxTv_SdtConfiguracoes_Configuracoesimagemlogintamanho, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("ConfiguracoesImagemLoginTamanho_N", gxTv_SdtConfiguracoes_Configuracoesimagemlogintamanho_N, false, includeNonInitialized);
         AddObjectProperty("ConfiguracoesImagemLoginBackground", gxTv_SdtConfiguracoes_Configuracoesimagemloginbackground, false, includeNonInitialized);
         AddObjectProperty("ConfiguracoesImagemLoginBackground_N", gxTv_SdtConfiguracoes_Configuracoesimagemloginbackground_N, false, includeNonInitialized);
         AddObjectProperty("ConfiguracoesImagemHeader", gxTv_SdtConfiguracoes_Configuracoesimagemheader, false, includeNonInitialized);
         AddObjectProperty("ConfiguracoesImagemHeader_N", gxTv_SdtConfiguracoes_Configuracoesimagemheader_N, false, includeNonInitialized);
         AddObjectProperty("ConfiguracoesImagemHeaderNome", gxTv_SdtConfiguracoes_Configuracoesimagemheadernome, false, includeNonInitialized);
         AddObjectProperty("ConfiguracoesImagemHeaderNome_N", gxTv_SdtConfiguracoes_Configuracoesimagemheadernome_N, false, includeNonInitialized);
         AddObjectProperty("ConfiguracoesImagemHeaderExtencao", gxTv_SdtConfiguracoes_Configuracoesimagemheaderextencao, false, includeNonInitialized);
         AddObjectProperty("ConfiguracoesImagemHeaderExtencao_N", gxTv_SdtConfiguracoes_Configuracoesimagemheaderextencao_N, false, includeNonInitialized);
         AddObjectProperty("ConfiguracoesImagemHeaderNomeInteiro", gxTv_SdtConfiguracoes_Configuracoesimagemheadernomeinteiro, false, includeNonInitialized);
         AddObjectProperty("ConfiguracoesImagemHeaderNomeInteiro_N", gxTv_SdtConfiguracoes_Configuracoesimagemheadernomeinteiro_N, false, includeNonInitialized);
         AddObjectProperty("ConfiguracoesImagemHeaderTamanho", StringUtil.LTrim( StringUtil.Str( gxTv_SdtConfiguracoes_Configuracoesimagemheadertamanho, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("ConfiguracoesImagemHeaderTamanho_N", gxTv_SdtConfiguracoes_Configuracoesimagemheadertamanho_N, false, includeNonInitialized);
         AddObjectProperty("ConfiguracoesLayoutProposta", gxTv_SdtConfiguracoes_Configuracoeslayoutproposta, false, includeNonInitialized);
         AddObjectProperty("ConfiguracoesLayoutProposta_N", gxTv_SdtConfiguracoes_Configuracoeslayoutproposta_N, false, includeNonInitialized);
         AddObjectProperty("ConfiguracoesLayoutContratoCorpo", gxTv_SdtConfiguracoes_Configuracoeslayoutcontratocorpo, false, includeNonInitialized);
         AddObjectProperty("ConfiguracoesLayoutContratoCorpo_N", gxTv_SdtConfiguracoes_Configuracoeslayoutcontratocorpo_N, false, includeNonInitialized);
         AddObjectProperty("ConfigLayoutPromissoriaClinicaEmprestimo", gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicaemprestimo, false, includeNonInitialized);
         AddObjectProperty("ConfigLayoutPromissoriaClinicaEmprestimo_N", gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicaemprestimo_N, false, includeNonInitialized);
         AddObjectProperty("ConfigLayoutCorpoPromissoriaClinicaEmprestimo", gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriaclinicaemprestimo, false, includeNonInitialized);
         AddObjectProperty("ConfigLayoutCorpoPromissoriaClinicaEmprestimo_N", gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriaclinicaemprestimo_N, false, includeNonInitialized);
         AddObjectProperty("ConfigLayoutPromissoriaClinicaTaxa", gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicataxa, false, includeNonInitialized);
         AddObjectProperty("ConfigLayoutPromissoriaClinicaTaxa_N", gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicataxa_N, false, includeNonInitialized);
         AddObjectProperty("ConfigLayoutCorpoPromissoriaClinicaTaxa", gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriaclinicataxa, false, includeNonInitialized);
         AddObjectProperty("ConfigLayoutCorpoPromissoriaClinicaTaxa_N", gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriaclinicataxa_N, false, includeNonInitialized);
         AddObjectProperty("ConfigLayoutPromissoriaPaciente", gxTv_SdtConfiguracoes_Configlayoutpromissoriapaciente, false, includeNonInitialized);
         AddObjectProperty("ConfigLayoutPromissoriaPaciente_N", gxTv_SdtConfiguracoes_Configlayoutpromissoriapaciente_N, false, includeNonInitialized);
         AddObjectProperty("ConfigLayoutContratoCompraTitulo", gxTv_SdtConfiguracoes_Configlayoutcontratocompratitulo, false, includeNonInitialized);
         AddObjectProperty("ConfigLayoutContratoCompraTitulo_N", gxTv_SdtConfiguracoes_Configlayoutcontratocompratitulo_N, false, includeNonInitialized);
         AddObjectProperty("ConfigLayoutCorpoPromissoriaPaciente", gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriapaciente, false, includeNonInitialized);
         AddObjectProperty("ConfigLayoutCorpoPromissoriaPaciente_N", gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriapaciente_N, false, includeNonInitialized);
         AddObjectProperty("ConfiguracoesArquivoPFX", gxTv_SdtConfiguracoes_Configuracoesarquivopfx, false, includeNonInitialized);
         AddObjectProperty("ConfiguracoesArquivoPFX_N", gxTv_SdtConfiguracoes_Configuracoesarquivopfx_N, false, includeNonInitialized);
         AddObjectProperty("ConfiguracaoSenhaPFX", gxTv_SdtConfiguracoes_Configuracaosenhapfx, false, includeNonInitialized);
         AddObjectProperty("ConfiguracaoSenhaPFX_N", gxTv_SdtConfiguracoes_Configuracaosenhapfx_N, false, includeNonInitialized);
         AddObjectProperty("ConfiguracoesCategoriaTitulo", gxTv_SdtConfiguracoes_Configuracoescategoriatitulo, false, includeNonInitialized);
         AddObjectProperty("ConfiguracoesCategoriaTitulo_N", gxTv_SdtConfiguracoes_Configuracoescategoriatitulo_N, false, includeNonInitialized);
         AddObjectProperty("ConfiguracoesSerasaAnotacoesCompletas", gxTv_SdtConfiguracoes_Configuracoesserasaanotacoescompletas, false, includeNonInitialized);
         AddObjectProperty("ConfiguracoesSerasaAnotacoesCompletas_N", gxTv_SdtConfiguracoes_Configuracoesserasaanotacoescompletas_N, false, includeNonInitialized);
         AddObjectProperty("ConfiguracoesSerasaConsultaDetalhada", gxTv_SdtConfiguracoes_Configuracoesserasaconsultadetalhada, false, includeNonInitialized);
         AddObjectProperty("ConfiguracoesSerasaConsultaDetalhada_N", gxTv_SdtConfiguracoes_Configuracoesserasaconsultadetalhada_N, false, includeNonInitialized);
         AddObjectProperty("ConfiguracoesSerasaParticipacaoSocietaria", gxTv_SdtConfiguracoes_Configuracoesserasaparticipacaosocietaria, false, includeNonInitialized);
         AddObjectProperty("ConfiguracoesSerasaParticipacaoSocietaria_N", gxTv_SdtConfiguracoes_Configuracoesserasaparticipacaosocietaria_N, false, includeNonInitialized);
         AddObjectProperty("ConfiguracoesSerasaRendaEstimada", gxTv_SdtConfiguracoes_Configuracoesserasarendaestimada, false, includeNonInitialized);
         AddObjectProperty("ConfiguracoesSerasaRendaEstimada_N", gxTv_SdtConfiguracoes_Configuracoesserasarendaestimada_N, false, includeNonInitialized);
         AddObjectProperty("ConfiguracoesSerasaHistoricoPagamento", gxTv_SdtConfiguracoes_Configuracoesserasahistoricopagamento, false, includeNonInitialized);
         AddObjectProperty("ConfiguracoesSerasaHistoricoPagamento_N", gxTv_SdtConfiguracoes_Configuracoesserasahistoricopagamento_N, false, includeNonInitialized);
         AddObjectProperty("ConfiguracoesCompraTituloTaxaEfetiva", StringUtil.LTrim( StringUtil.Str( gxTv_SdtConfiguracoes_Configuracoescompratitulotaxaefetiva, 16, 4)), false, includeNonInitialized);
         AddObjectProperty("ConfiguracoesCompraTituloTaxaEfetiva_N", gxTv_SdtConfiguracoes_Configuracoescompratitulotaxaefetiva_N, false, includeNonInitialized);
         AddObjectProperty("ConfiguracoesCompraTituloTaxaMora", StringUtil.LTrim( StringUtil.Str( gxTv_SdtConfiguracoes_Configuracoescompratitulotaxamora, 16, 4)), false, includeNonInitialized);
         AddObjectProperty("ConfiguracoesCompraTituloTaxaMora_N", gxTv_SdtConfiguracoes_Configuracoescompratitulotaxamora_N, false, includeNonInitialized);
         AddObjectProperty("ConfiguracoesCompraTituloFator", StringUtil.LTrim( StringUtil.Str( gxTv_SdtConfiguracoes_Configuracoescompratitulofator, 16, 4)), false, includeNonInitialized);
         AddObjectProperty("ConfiguracoesCompraTituloFator_N", gxTv_SdtConfiguracoes_Configuracoescompratitulofator_N, false, includeNonInitialized);
         AddObjectProperty("ConfiguracoesCompraTituloTarifaTipo", gxTv_SdtConfiguracoes_Configuracoescompratitulotarifatipo, false, includeNonInitialized);
         AddObjectProperty("ConfiguracoesCompraTituloTarifaTipo_N", gxTv_SdtConfiguracoes_Configuracoescompratitulotarifatipo_N, false, includeNonInitialized);
         AddObjectProperty("ConfiguracoesCompraTituloTarifa", gxTv_SdtConfiguracoes_Configuracoescompratitulotarifa, false, includeNonInitialized);
         AddObjectProperty("ConfiguracoesCompraTituloTarifa_N", gxTv_SdtConfiguracoes_Configuracoescompratitulotarifa_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtConfiguracoes_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtConfiguracoes_Initialized, false, includeNonInitialized);
            AddObjectProperty("ConfiguracoesId_Z", gxTv_SdtConfiguracoes_Configuracoesid_Z, false, includeNonInitialized);
            AddObjectProperty("ConfiguracoesImagemLoginNome_Z", gxTv_SdtConfiguracoes_Configuracoesimagemloginnome_Z, false, includeNonInitialized);
            AddObjectProperty("ConfiguracoesImagemLoginExtencao_Z", gxTv_SdtConfiguracoes_Configuracoesimagemloginextencao_Z, false, includeNonInitialized);
            AddObjectProperty("ConfiguracoesImagemLoginNomeInteiro_Z", gxTv_SdtConfiguracoes_Configuracoesimagemloginnomeinteiro_Z, false, includeNonInitialized);
            AddObjectProperty("ConfiguracoesImagemLoginTamanho_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtConfiguracoes_Configuracoesimagemlogintamanho_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("ConfiguracoesImagemLoginBackground_Z", gxTv_SdtConfiguracoes_Configuracoesimagemloginbackground_Z, false, includeNonInitialized);
            AddObjectProperty("ConfiguracoesImagemHeaderNome_Z", gxTv_SdtConfiguracoes_Configuracoesimagemheadernome_Z, false, includeNonInitialized);
            AddObjectProperty("ConfiguracoesImagemHeaderExtencao_Z", gxTv_SdtConfiguracoes_Configuracoesimagemheaderextencao_Z, false, includeNonInitialized);
            AddObjectProperty("ConfiguracoesImagemHeaderNomeInteiro_Z", gxTv_SdtConfiguracoes_Configuracoesimagemheadernomeinteiro_Z, false, includeNonInitialized);
            AddObjectProperty("ConfiguracoesImagemHeaderTamanho_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtConfiguracoes_Configuracoesimagemheadertamanho_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("ConfiguracoesLayoutProposta_Z", gxTv_SdtConfiguracoes_Configuracoeslayoutproposta_Z, false, includeNonInitialized);
            AddObjectProperty("ConfigLayoutPromissoriaClinicaEmprestimo_Z", gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicaemprestimo_Z, false, includeNonInitialized);
            AddObjectProperty("ConfigLayoutPromissoriaClinicaTaxa_Z", gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicataxa_Z, false, includeNonInitialized);
            AddObjectProperty("ConfigLayoutPromissoriaPaciente_Z", gxTv_SdtConfiguracoes_Configlayoutpromissoriapaciente_Z, false, includeNonInitialized);
            AddObjectProperty("ConfigLayoutContratoCompraTitulo_Z", gxTv_SdtConfiguracoes_Configlayoutcontratocompratitulo_Z, false, includeNonInitialized);
            AddObjectProperty("ConfiguracaoSenhaPFX_Z", gxTv_SdtConfiguracoes_Configuracaosenhapfx_Z, false, includeNonInitialized);
            AddObjectProperty("ConfiguracoesCategoriaTitulo_Z", gxTv_SdtConfiguracoes_Configuracoescategoriatitulo_Z, false, includeNonInitialized);
            AddObjectProperty("ConfiguracoesSerasaAnotacoesCompletas_Z", gxTv_SdtConfiguracoes_Configuracoesserasaanotacoescompletas_Z, false, includeNonInitialized);
            AddObjectProperty("ConfiguracoesSerasaConsultaDetalhada_Z", gxTv_SdtConfiguracoes_Configuracoesserasaconsultadetalhada_Z, false, includeNonInitialized);
            AddObjectProperty("ConfiguracoesSerasaParticipacaoSocietaria_Z", gxTv_SdtConfiguracoes_Configuracoesserasaparticipacaosocietaria_Z, false, includeNonInitialized);
            AddObjectProperty("ConfiguracoesSerasaRendaEstimada_Z", gxTv_SdtConfiguracoes_Configuracoesserasarendaestimada_Z, false, includeNonInitialized);
            AddObjectProperty("ConfiguracoesSerasaHistoricoPagamento_Z", gxTv_SdtConfiguracoes_Configuracoesserasahistoricopagamento_Z, false, includeNonInitialized);
            AddObjectProperty("ConfiguracoesCompraTituloTaxaEfetiva_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtConfiguracoes_Configuracoescompratitulotaxaefetiva_Z, 16, 4)), false, includeNonInitialized);
            AddObjectProperty("ConfiguracoesCompraTituloTaxaMora_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtConfiguracoes_Configuracoescompratitulotaxamora_Z, 16, 4)), false, includeNonInitialized);
            AddObjectProperty("ConfiguracoesCompraTituloFator_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtConfiguracoes_Configuracoescompratitulofator_Z, 16, 4)), false, includeNonInitialized);
            AddObjectProperty("ConfiguracoesCompraTituloTarifaTipo_Z", gxTv_SdtConfiguracoes_Configuracoescompratitulotarifatipo_Z, false, includeNonInitialized);
            AddObjectProperty("ConfiguracoesCompraTituloTarifa_Z", gxTv_SdtConfiguracoes_Configuracoescompratitulotarifa_Z, false, includeNonInitialized);
            AddObjectProperty("ConfiguracoesImagemLogin_N", gxTv_SdtConfiguracoes_Configuracoesimagemlogin_N, false, includeNonInitialized);
            AddObjectProperty("ConfiguracoesImagemLoginNome_N", gxTv_SdtConfiguracoes_Configuracoesimagemloginnome_N, false, includeNonInitialized);
            AddObjectProperty("ConfiguracoesImagemLoginExtencao_N", gxTv_SdtConfiguracoes_Configuracoesimagemloginextencao_N, false, includeNonInitialized);
            AddObjectProperty("ConfiguracoesImagemLoginNomeInteiro_N", gxTv_SdtConfiguracoes_Configuracoesimagemloginnomeinteiro_N, false, includeNonInitialized);
            AddObjectProperty("ConfiguracoesImagemLoginTamanho_N", gxTv_SdtConfiguracoes_Configuracoesimagemlogintamanho_N, false, includeNonInitialized);
            AddObjectProperty("ConfiguracoesImagemLoginBackground_N", gxTv_SdtConfiguracoes_Configuracoesimagemloginbackground_N, false, includeNonInitialized);
            AddObjectProperty("ConfiguracoesImagemHeader_N", gxTv_SdtConfiguracoes_Configuracoesimagemheader_N, false, includeNonInitialized);
            AddObjectProperty("ConfiguracoesImagemHeaderNome_N", gxTv_SdtConfiguracoes_Configuracoesimagemheadernome_N, false, includeNonInitialized);
            AddObjectProperty("ConfiguracoesImagemHeaderExtencao_N", gxTv_SdtConfiguracoes_Configuracoesimagemheaderextencao_N, false, includeNonInitialized);
            AddObjectProperty("ConfiguracoesImagemHeaderNomeInteiro_N", gxTv_SdtConfiguracoes_Configuracoesimagemheadernomeinteiro_N, false, includeNonInitialized);
            AddObjectProperty("ConfiguracoesImagemHeaderTamanho_N", gxTv_SdtConfiguracoes_Configuracoesimagemheadertamanho_N, false, includeNonInitialized);
            AddObjectProperty("ConfiguracoesLayoutProposta_N", gxTv_SdtConfiguracoes_Configuracoeslayoutproposta_N, false, includeNonInitialized);
            AddObjectProperty("ConfiguracoesLayoutContratoCorpo_N", gxTv_SdtConfiguracoes_Configuracoeslayoutcontratocorpo_N, false, includeNonInitialized);
            AddObjectProperty("ConfigLayoutPromissoriaClinicaEmprestimo_N", gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicaemprestimo_N, false, includeNonInitialized);
            AddObjectProperty("ConfigLayoutCorpoPromissoriaClinicaEmprestimo_N", gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriaclinicaemprestimo_N, false, includeNonInitialized);
            AddObjectProperty("ConfigLayoutPromissoriaClinicaTaxa_N", gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicataxa_N, false, includeNonInitialized);
            AddObjectProperty("ConfigLayoutCorpoPromissoriaClinicaTaxa_N", gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriaclinicataxa_N, false, includeNonInitialized);
            AddObjectProperty("ConfigLayoutPromissoriaPaciente_N", gxTv_SdtConfiguracoes_Configlayoutpromissoriapaciente_N, false, includeNonInitialized);
            AddObjectProperty("ConfigLayoutContratoCompraTitulo_N", gxTv_SdtConfiguracoes_Configlayoutcontratocompratitulo_N, false, includeNonInitialized);
            AddObjectProperty("ConfigLayoutCorpoPromissoriaPaciente_N", gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriapaciente_N, false, includeNonInitialized);
            AddObjectProperty("ConfiguracoesArquivoPFX_N", gxTv_SdtConfiguracoes_Configuracoesarquivopfx_N, false, includeNonInitialized);
            AddObjectProperty("ConfiguracaoSenhaPFX_N", gxTv_SdtConfiguracoes_Configuracaosenhapfx_N, false, includeNonInitialized);
            AddObjectProperty("ConfiguracoesCategoriaTitulo_N", gxTv_SdtConfiguracoes_Configuracoescategoriatitulo_N, false, includeNonInitialized);
            AddObjectProperty("ConfiguracoesSerasaAnotacoesCompletas_N", gxTv_SdtConfiguracoes_Configuracoesserasaanotacoescompletas_N, false, includeNonInitialized);
            AddObjectProperty("ConfiguracoesSerasaConsultaDetalhada_N", gxTv_SdtConfiguracoes_Configuracoesserasaconsultadetalhada_N, false, includeNonInitialized);
            AddObjectProperty("ConfiguracoesSerasaParticipacaoSocietaria_N", gxTv_SdtConfiguracoes_Configuracoesserasaparticipacaosocietaria_N, false, includeNonInitialized);
            AddObjectProperty("ConfiguracoesSerasaRendaEstimada_N", gxTv_SdtConfiguracoes_Configuracoesserasarendaestimada_N, false, includeNonInitialized);
            AddObjectProperty("ConfiguracoesSerasaHistoricoPagamento_N", gxTv_SdtConfiguracoes_Configuracoesserasahistoricopagamento_N, false, includeNonInitialized);
            AddObjectProperty("ConfiguracoesCompraTituloTaxaEfetiva_N", gxTv_SdtConfiguracoes_Configuracoescompratitulotaxaefetiva_N, false, includeNonInitialized);
            AddObjectProperty("ConfiguracoesCompraTituloTaxaMora_N", gxTv_SdtConfiguracoes_Configuracoescompratitulotaxamora_N, false, includeNonInitialized);
            AddObjectProperty("ConfiguracoesCompraTituloFator_N", gxTv_SdtConfiguracoes_Configuracoescompratitulofator_N, false, includeNonInitialized);
            AddObjectProperty("ConfiguracoesCompraTituloTarifaTipo_N", gxTv_SdtConfiguracoes_Configuracoescompratitulotarifatipo_N, false, includeNonInitialized);
            AddObjectProperty("ConfiguracoesCompraTituloTarifa_N", gxTv_SdtConfiguracoes_Configuracoescompratitulotarifa_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtConfiguracoes sdt )
      {
         if ( sdt.IsDirty("ConfiguracoesId") )
         {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesid = sdt.gxTv_SdtConfiguracoes_Configuracoesid ;
         }
         if ( sdt.IsDirty("ConfiguracoesImagemLogin") )
         {
            gxTv_SdtConfiguracoes_Configuracoesimagemlogin_N = (short)(sdt.gxTv_SdtConfiguracoes_Configuracoesimagemlogin_N);
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesimagemlogin = sdt.gxTv_SdtConfiguracoes_Configuracoesimagemlogin ;
         }
         if ( sdt.IsDirty("ConfiguracoesImagemLoginNome") )
         {
            gxTv_SdtConfiguracoes_Configuracoesimagemloginnome_N = (short)(sdt.gxTv_SdtConfiguracoes_Configuracoesimagemloginnome_N);
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesimagemloginnome = sdt.gxTv_SdtConfiguracoes_Configuracoesimagemloginnome ;
         }
         if ( sdt.IsDirty("ConfiguracoesImagemLoginExtencao") )
         {
            gxTv_SdtConfiguracoes_Configuracoesimagemloginextencao_N = (short)(sdt.gxTv_SdtConfiguracoes_Configuracoesimagemloginextencao_N);
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesimagemloginextencao = sdt.gxTv_SdtConfiguracoes_Configuracoesimagemloginextencao ;
         }
         if ( sdt.IsDirty("ConfiguracoesImagemLoginNomeInteiro") )
         {
            gxTv_SdtConfiguracoes_Configuracoesimagemloginnomeinteiro_N = (short)(sdt.gxTv_SdtConfiguracoes_Configuracoesimagemloginnomeinteiro_N);
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesimagemloginnomeinteiro = sdt.gxTv_SdtConfiguracoes_Configuracoesimagemloginnomeinteiro ;
         }
         if ( sdt.IsDirty("ConfiguracoesImagemLoginTamanho") )
         {
            gxTv_SdtConfiguracoes_Configuracoesimagemlogintamanho_N = (short)(sdt.gxTv_SdtConfiguracoes_Configuracoesimagemlogintamanho_N);
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesimagemlogintamanho = sdt.gxTv_SdtConfiguracoes_Configuracoesimagemlogintamanho ;
         }
         if ( sdt.IsDirty("ConfiguracoesImagemLoginBackground") )
         {
            gxTv_SdtConfiguracoes_Configuracoesimagemloginbackground_N = (short)(sdt.gxTv_SdtConfiguracoes_Configuracoesimagemloginbackground_N);
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesimagemloginbackground = sdt.gxTv_SdtConfiguracoes_Configuracoesimagemloginbackground ;
         }
         if ( sdt.IsDirty("ConfiguracoesImagemHeader") )
         {
            gxTv_SdtConfiguracoes_Configuracoesimagemheader_N = (short)(sdt.gxTv_SdtConfiguracoes_Configuracoesimagemheader_N);
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesimagemheader = sdt.gxTv_SdtConfiguracoes_Configuracoesimagemheader ;
         }
         if ( sdt.IsDirty("ConfiguracoesImagemHeaderNome") )
         {
            gxTv_SdtConfiguracoes_Configuracoesimagemheadernome_N = (short)(sdt.gxTv_SdtConfiguracoes_Configuracoesimagemheadernome_N);
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesimagemheadernome = sdt.gxTv_SdtConfiguracoes_Configuracoesimagemheadernome ;
         }
         if ( sdt.IsDirty("ConfiguracoesImagemHeaderExtencao") )
         {
            gxTv_SdtConfiguracoes_Configuracoesimagemheaderextencao_N = (short)(sdt.gxTv_SdtConfiguracoes_Configuracoesimagemheaderextencao_N);
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesimagemheaderextencao = sdt.gxTv_SdtConfiguracoes_Configuracoesimagemheaderextencao ;
         }
         if ( sdt.IsDirty("ConfiguracoesImagemHeaderNomeInteiro") )
         {
            gxTv_SdtConfiguracoes_Configuracoesimagemheadernomeinteiro_N = (short)(sdt.gxTv_SdtConfiguracoes_Configuracoesimagemheadernomeinteiro_N);
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesimagemheadernomeinteiro = sdt.gxTv_SdtConfiguracoes_Configuracoesimagemheadernomeinteiro ;
         }
         if ( sdt.IsDirty("ConfiguracoesImagemHeaderTamanho") )
         {
            gxTv_SdtConfiguracoes_Configuracoesimagemheadertamanho_N = (short)(sdt.gxTv_SdtConfiguracoes_Configuracoesimagemheadertamanho_N);
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesimagemheadertamanho = sdt.gxTv_SdtConfiguracoes_Configuracoesimagemheadertamanho ;
         }
         if ( sdt.IsDirty("ConfiguracoesLayoutProposta") )
         {
            gxTv_SdtConfiguracoes_Configuracoeslayoutproposta_N = (short)(sdt.gxTv_SdtConfiguracoes_Configuracoeslayoutproposta_N);
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoeslayoutproposta = sdt.gxTv_SdtConfiguracoes_Configuracoeslayoutproposta ;
         }
         if ( sdt.IsDirty("ConfiguracoesLayoutContratoCorpo") )
         {
            gxTv_SdtConfiguracoes_Configuracoeslayoutcontratocorpo_N = (short)(sdt.gxTv_SdtConfiguracoes_Configuracoeslayoutcontratocorpo_N);
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoeslayoutcontratocorpo = sdt.gxTv_SdtConfiguracoes_Configuracoeslayoutcontratocorpo ;
         }
         if ( sdt.IsDirty("ConfigLayoutPromissoriaClinicaEmprestimo") )
         {
            gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicaemprestimo_N = (short)(sdt.gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicaemprestimo_N);
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicaemprestimo = sdt.gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicaemprestimo ;
         }
         if ( sdt.IsDirty("ConfigLayoutCorpoPromissoriaClinicaEmprestimo") )
         {
            gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriaclinicaemprestimo_N = (short)(sdt.gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriaclinicaemprestimo_N);
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriaclinicaemprestimo = sdt.gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriaclinicaemprestimo ;
         }
         if ( sdt.IsDirty("ConfigLayoutPromissoriaClinicaTaxa") )
         {
            gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicataxa_N = (short)(sdt.gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicataxa_N);
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicataxa = sdt.gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicataxa ;
         }
         if ( sdt.IsDirty("ConfigLayoutCorpoPromissoriaClinicaTaxa") )
         {
            gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriaclinicataxa_N = (short)(sdt.gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriaclinicataxa_N);
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriaclinicataxa = sdt.gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriaclinicataxa ;
         }
         if ( sdt.IsDirty("ConfigLayoutPromissoriaPaciente") )
         {
            gxTv_SdtConfiguracoes_Configlayoutpromissoriapaciente_N = (short)(sdt.gxTv_SdtConfiguracoes_Configlayoutpromissoriapaciente_N);
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configlayoutpromissoriapaciente = sdt.gxTv_SdtConfiguracoes_Configlayoutpromissoriapaciente ;
         }
         if ( sdt.IsDirty("ConfigLayoutContratoCompraTitulo") )
         {
            gxTv_SdtConfiguracoes_Configlayoutcontratocompratitulo_N = (short)(sdt.gxTv_SdtConfiguracoes_Configlayoutcontratocompratitulo_N);
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configlayoutcontratocompratitulo = sdt.gxTv_SdtConfiguracoes_Configlayoutcontratocompratitulo ;
         }
         if ( sdt.IsDirty("ConfigLayoutCorpoPromissoriaPaciente") )
         {
            gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriapaciente_N = (short)(sdt.gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriapaciente_N);
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriapaciente = sdt.gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriapaciente ;
         }
         if ( sdt.IsDirty("ConfiguracoesArquivoPFX") )
         {
            gxTv_SdtConfiguracoes_Configuracoesarquivopfx_N = (short)(sdt.gxTv_SdtConfiguracoes_Configuracoesarquivopfx_N);
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesarquivopfx = sdt.gxTv_SdtConfiguracoes_Configuracoesarquivopfx ;
         }
         if ( sdt.IsDirty("ConfiguracaoSenhaPFX") )
         {
            gxTv_SdtConfiguracoes_Configuracaosenhapfx_N = (short)(sdt.gxTv_SdtConfiguracoes_Configuracaosenhapfx_N);
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracaosenhapfx = sdt.gxTv_SdtConfiguracoes_Configuracaosenhapfx ;
         }
         if ( sdt.IsDirty("ConfiguracoesCategoriaTitulo") )
         {
            gxTv_SdtConfiguracoes_Configuracoescategoriatitulo_N = (short)(sdt.gxTv_SdtConfiguracoes_Configuracoescategoriatitulo_N);
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoescategoriatitulo = sdt.gxTv_SdtConfiguracoes_Configuracoescategoriatitulo ;
         }
         if ( sdt.IsDirty("ConfiguracoesSerasaAnotacoesCompletas") )
         {
            gxTv_SdtConfiguracoes_Configuracoesserasaanotacoescompletas_N = (short)(sdt.gxTv_SdtConfiguracoes_Configuracoesserasaanotacoescompletas_N);
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesserasaanotacoescompletas = sdt.gxTv_SdtConfiguracoes_Configuracoesserasaanotacoescompletas ;
         }
         if ( sdt.IsDirty("ConfiguracoesSerasaConsultaDetalhada") )
         {
            gxTv_SdtConfiguracoes_Configuracoesserasaconsultadetalhada_N = (short)(sdt.gxTv_SdtConfiguracoes_Configuracoesserasaconsultadetalhada_N);
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesserasaconsultadetalhada = sdt.gxTv_SdtConfiguracoes_Configuracoesserasaconsultadetalhada ;
         }
         if ( sdt.IsDirty("ConfiguracoesSerasaParticipacaoSocietaria") )
         {
            gxTv_SdtConfiguracoes_Configuracoesserasaparticipacaosocietaria_N = (short)(sdt.gxTv_SdtConfiguracoes_Configuracoesserasaparticipacaosocietaria_N);
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesserasaparticipacaosocietaria = sdt.gxTv_SdtConfiguracoes_Configuracoesserasaparticipacaosocietaria ;
         }
         if ( sdt.IsDirty("ConfiguracoesSerasaRendaEstimada") )
         {
            gxTv_SdtConfiguracoes_Configuracoesserasarendaestimada_N = (short)(sdt.gxTv_SdtConfiguracoes_Configuracoesserasarendaestimada_N);
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesserasarendaestimada = sdt.gxTv_SdtConfiguracoes_Configuracoesserasarendaestimada ;
         }
         if ( sdt.IsDirty("ConfiguracoesSerasaHistoricoPagamento") )
         {
            gxTv_SdtConfiguracoes_Configuracoesserasahistoricopagamento_N = (short)(sdt.gxTv_SdtConfiguracoes_Configuracoesserasahistoricopagamento_N);
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesserasahistoricopagamento = sdt.gxTv_SdtConfiguracoes_Configuracoesserasahistoricopagamento ;
         }
         if ( sdt.IsDirty("ConfiguracoesCompraTituloTaxaEfetiva") )
         {
            gxTv_SdtConfiguracoes_Configuracoescompratitulotaxaefetiva_N = (short)(sdt.gxTv_SdtConfiguracoes_Configuracoescompratitulotaxaefetiva_N);
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoescompratitulotaxaefetiva = sdt.gxTv_SdtConfiguracoes_Configuracoescompratitulotaxaefetiva ;
         }
         if ( sdt.IsDirty("ConfiguracoesCompraTituloTaxaMora") )
         {
            gxTv_SdtConfiguracoes_Configuracoescompratitulotaxamora_N = (short)(sdt.gxTv_SdtConfiguracoes_Configuracoescompratitulotaxamora_N);
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoescompratitulotaxamora = sdt.gxTv_SdtConfiguracoes_Configuracoescompratitulotaxamora ;
         }
         if ( sdt.IsDirty("ConfiguracoesCompraTituloFator") )
         {
            gxTv_SdtConfiguracoes_Configuracoescompratitulofator_N = (short)(sdt.gxTv_SdtConfiguracoes_Configuracoescompratitulofator_N);
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoescompratitulofator = sdt.gxTv_SdtConfiguracoes_Configuracoescompratitulofator ;
         }
         if ( sdt.IsDirty("ConfiguracoesCompraTituloTarifaTipo") )
         {
            gxTv_SdtConfiguracoes_Configuracoescompratitulotarifatipo_N = (short)(sdt.gxTv_SdtConfiguracoes_Configuracoescompratitulotarifatipo_N);
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoescompratitulotarifatipo = sdt.gxTv_SdtConfiguracoes_Configuracoescompratitulotarifatipo ;
         }
         if ( sdt.IsDirty("ConfiguracoesCompraTituloTarifa") )
         {
            gxTv_SdtConfiguracoes_Configuracoescompratitulotarifa_N = (short)(sdt.gxTv_SdtConfiguracoes_Configuracoescompratitulotarifa_N);
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoescompratitulotarifa = sdt.gxTv_SdtConfiguracoes_Configuracoescompratitulotarifa ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ConfiguracoesId" )]
      [  XmlElement( ElementName = "ConfiguracoesId"   )]
      public int gxTpr_Configuracoesid
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoesid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtConfiguracoes_Configuracoesid != value )
            {
               gxTv_SdtConfiguracoes_Mode = "INS";
               this.gxTv_SdtConfiguracoes_Configuracoesid_Z_SetNull( );
               this.gxTv_SdtConfiguracoes_Configuracoesimagemloginnome_Z_SetNull( );
               this.gxTv_SdtConfiguracoes_Configuracoesimagemloginextencao_Z_SetNull( );
               this.gxTv_SdtConfiguracoes_Configuracoesimagemloginnomeinteiro_Z_SetNull( );
               this.gxTv_SdtConfiguracoes_Configuracoesimagemlogintamanho_Z_SetNull( );
               this.gxTv_SdtConfiguracoes_Configuracoesimagemloginbackground_Z_SetNull( );
               this.gxTv_SdtConfiguracoes_Configuracoesimagemheadernome_Z_SetNull( );
               this.gxTv_SdtConfiguracoes_Configuracoesimagemheaderextencao_Z_SetNull( );
               this.gxTv_SdtConfiguracoes_Configuracoesimagemheadernomeinteiro_Z_SetNull( );
               this.gxTv_SdtConfiguracoes_Configuracoesimagemheadertamanho_Z_SetNull( );
               this.gxTv_SdtConfiguracoes_Configuracoeslayoutproposta_Z_SetNull( );
               this.gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicaemprestimo_Z_SetNull( );
               this.gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicataxa_Z_SetNull( );
               this.gxTv_SdtConfiguracoes_Configlayoutpromissoriapaciente_Z_SetNull( );
               this.gxTv_SdtConfiguracoes_Configlayoutcontratocompratitulo_Z_SetNull( );
               this.gxTv_SdtConfiguracoes_Configuracaosenhapfx_Z_SetNull( );
               this.gxTv_SdtConfiguracoes_Configuracoescategoriatitulo_Z_SetNull( );
               this.gxTv_SdtConfiguracoes_Configuracoesserasaanotacoescompletas_Z_SetNull( );
               this.gxTv_SdtConfiguracoes_Configuracoesserasaconsultadetalhada_Z_SetNull( );
               this.gxTv_SdtConfiguracoes_Configuracoesserasaparticipacaosocietaria_Z_SetNull( );
               this.gxTv_SdtConfiguracoes_Configuracoesserasarendaestimada_Z_SetNull( );
               this.gxTv_SdtConfiguracoes_Configuracoesserasahistoricopagamento_Z_SetNull( );
               this.gxTv_SdtConfiguracoes_Configuracoescompratitulotaxaefetiva_Z_SetNull( );
               this.gxTv_SdtConfiguracoes_Configuracoescompratitulotaxamora_Z_SetNull( );
               this.gxTv_SdtConfiguracoes_Configuracoescompratitulofator_Z_SetNull( );
               this.gxTv_SdtConfiguracoes_Configuracoescompratitulotarifatipo_Z_SetNull( );
               this.gxTv_SdtConfiguracoes_Configuracoescompratitulotarifa_Z_SetNull( );
            }
            gxTv_SdtConfiguracoes_Configuracoesid = value;
            SetDirty("Configuracoesid");
         }

      }

      [  SoapElement( ElementName = "ConfiguracoesImagemLogin" )]
      [  XmlElement( ElementName = "ConfiguracoesImagemLogin"   )]
      [GxUpload()]
      public byte[] gxTpr_Configuracoesimagemlogin_Blob
      {
         get {
            IGxContext context = this.context == null ? new GxContext() : this.context;
            return context.FileToByteArray( gxTv_SdtConfiguracoes_Configuracoesimagemlogin) ;
         }

         set {
            gxTv_SdtConfiguracoes_Configuracoesimagemlogin_N = 0;
            sdtIsNull = 0;
            IGxContext context = this.context == null ? new GxContext() : this.context;
            gxTv_SdtConfiguracoes_Configuracoesimagemlogin=context.FileFromByteArray( value) ;
         }

      }

      [XmlIgnore]
      [GxUpload()]
      public string gxTpr_Configuracoesimagemlogin
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoesimagemlogin ;
         }

         set {
            gxTv_SdtConfiguracoes_Configuracoesimagemlogin_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesimagemlogin = value;
            SetDirty("Configuracoesimagemlogin");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoesimagemlogin_SetBlob( string blob ,
                                                                          string fileName ,
                                                                          string fileType )
      {
         gxTv_SdtConfiguracoes_Configuracoesimagemlogin = blob;
         gxTv_SdtConfiguracoes_Configuracoesimagemloginnome = fileName;
         gxTv_SdtConfiguracoes_Configuracoesimagemloginextencao = fileType;
         return  ;
      }

      public void gxTv_SdtConfiguracoes_Configuracoesimagemlogin_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoesimagemlogin_N = 1;
         gxTv_SdtConfiguracoes_Configuracoesimagemlogin = "";
         SetDirty("Configuracoesimagemlogin");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoesimagemlogin_IsNull( )
      {
         return (gxTv_SdtConfiguracoes_Configuracoesimagemlogin_N==1) ;
      }

      [  SoapElement( ElementName = "ConfiguracoesImagemLoginNome" )]
      [  XmlElement( ElementName = "ConfiguracoesImagemLoginNome"   )]
      public string gxTpr_Configuracoesimagemloginnome
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoesimagemloginnome ;
         }

         set {
            gxTv_SdtConfiguracoes_Configuracoesimagemloginnome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesimagemloginnome = value;
            SetDirty("Configuracoesimagemloginnome");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoesimagemloginnome_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoesimagemloginnome_N = 1;
         gxTv_SdtConfiguracoes_Configuracoesimagemloginnome = "";
         SetDirty("Configuracoesimagemloginnome");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoesimagemloginnome_IsNull( )
      {
         return (gxTv_SdtConfiguracoes_Configuracoesimagemloginnome_N==1) ;
      }

      [  SoapElement( ElementName = "ConfiguracoesImagemLoginExtencao" )]
      [  XmlElement( ElementName = "ConfiguracoesImagemLoginExtencao"   )]
      public string gxTpr_Configuracoesimagemloginextencao
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoesimagemloginextencao ;
         }

         set {
            gxTv_SdtConfiguracoes_Configuracoesimagemloginextencao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesimagemloginextencao = value;
            SetDirty("Configuracoesimagemloginextencao");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoesimagemloginextencao_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoesimagemloginextencao_N = 1;
         gxTv_SdtConfiguracoes_Configuracoesimagemloginextencao = "";
         SetDirty("Configuracoesimagemloginextencao");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoesimagemloginextencao_IsNull( )
      {
         return (gxTv_SdtConfiguracoes_Configuracoesimagemloginextencao_N==1) ;
      }

      [  SoapElement( ElementName = "ConfiguracoesImagemLoginNomeInteiro" )]
      [  XmlElement( ElementName = "ConfiguracoesImagemLoginNomeInteiro"   )]
      public string gxTpr_Configuracoesimagemloginnomeinteiro
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoesimagemloginnomeinteiro ;
         }

         set {
            gxTv_SdtConfiguracoes_Configuracoesimagemloginnomeinteiro_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesimagemloginnomeinteiro = value;
            SetDirty("Configuracoesimagemloginnomeinteiro");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoesimagemloginnomeinteiro_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoesimagemloginnomeinteiro_N = 1;
         gxTv_SdtConfiguracoes_Configuracoesimagemloginnomeinteiro = "";
         SetDirty("Configuracoesimagemloginnomeinteiro");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoesimagemloginnomeinteiro_IsNull( )
      {
         return (gxTv_SdtConfiguracoes_Configuracoesimagemloginnomeinteiro_N==1) ;
      }

      [  SoapElement( ElementName = "ConfiguracoesImagemLoginTamanho" )]
      [  XmlElement( ElementName = "ConfiguracoesImagemLoginTamanho"   )]
      public decimal gxTpr_Configuracoesimagemlogintamanho
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoesimagemlogintamanho ;
         }

         set {
            gxTv_SdtConfiguracoes_Configuracoesimagemlogintamanho_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesimagemlogintamanho = value;
            SetDirty("Configuracoesimagemlogintamanho");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoesimagemlogintamanho_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoesimagemlogintamanho_N = 1;
         gxTv_SdtConfiguracoes_Configuracoesimagemlogintamanho = 0;
         SetDirty("Configuracoesimagemlogintamanho");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoesimagemlogintamanho_IsNull( )
      {
         return (gxTv_SdtConfiguracoes_Configuracoesimagemlogintamanho_N==1) ;
      }

      [  SoapElement( ElementName = "ConfiguracoesImagemLoginBackground" )]
      [  XmlElement( ElementName = "ConfiguracoesImagemLoginBackground"   )]
      public string gxTpr_Configuracoesimagemloginbackground
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoesimagemloginbackground ;
         }

         set {
            gxTv_SdtConfiguracoes_Configuracoesimagemloginbackground_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesimagemloginbackground = value;
            SetDirty("Configuracoesimagemloginbackground");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoesimagemloginbackground_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoesimagemloginbackground_N = 1;
         gxTv_SdtConfiguracoes_Configuracoesimagemloginbackground = "";
         SetDirty("Configuracoesimagemloginbackground");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoesimagemloginbackground_IsNull( )
      {
         return (gxTv_SdtConfiguracoes_Configuracoesimagemloginbackground_N==1) ;
      }

      [  SoapElement( ElementName = "ConfiguracoesImagemHeader" )]
      [  XmlElement( ElementName = "ConfiguracoesImagemHeader"   )]
      [GxUpload()]
      public byte[] gxTpr_Configuracoesimagemheader_Blob
      {
         get {
            IGxContext context = this.context == null ? new GxContext() : this.context;
            return context.FileToByteArray( gxTv_SdtConfiguracoes_Configuracoesimagemheader) ;
         }

         set {
            gxTv_SdtConfiguracoes_Configuracoesimagemheader_N = 0;
            sdtIsNull = 0;
            IGxContext context = this.context == null ? new GxContext() : this.context;
            gxTv_SdtConfiguracoes_Configuracoesimagemheader=context.FileFromByteArray( value) ;
         }

      }

      [XmlIgnore]
      [GxUpload()]
      public string gxTpr_Configuracoesimagemheader
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoesimagemheader ;
         }

         set {
            gxTv_SdtConfiguracoes_Configuracoesimagemheader_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesimagemheader = value;
            SetDirty("Configuracoesimagemheader");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoesimagemheader_SetBlob( string blob ,
                                                                           string fileName ,
                                                                           string fileType )
      {
         gxTv_SdtConfiguracoes_Configuracoesimagemheader = blob;
         return  ;
      }

      public void gxTv_SdtConfiguracoes_Configuracoesimagemheader_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoesimagemheader_N = 1;
         gxTv_SdtConfiguracoes_Configuracoesimagemheader = "";
         SetDirty("Configuracoesimagemheader");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoesimagemheader_IsNull( )
      {
         return (gxTv_SdtConfiguracoes_Configuracoesimagemheader_N==1) ;
      }

      [  SoapElement( ElementName = "ConfiguracoesImagemHeaderNome" )]
      [  XmlElement( ElementName = "ConfiguracoesImagemHeaderNome"   )]
      public string gxTpr_Configuracoesimagemheadernome
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoesimagemheadernome ;
         }

         set {
            gxTv_SdtConfiguracoes_Configuracoesimagemheadernome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesimagemheadernome = value;
            SetDirty("Configuracoesimagemheadernome");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoesimagemheadernome_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoesimagemheadernome_N = 1;
         gxTv_SdtConfiguracoes_Configuracoesimagemheadernome = "";
         SetDirty("Configuracoesimagemheadernome");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoesimagemheadernome_IsNull( )
      {
         return (gxTv_SdtConfiguracoes_Configuracoesimagemheadernome_N==1) ;
      }

      [  SoapElement( ElementName = "ConfiguracoesImagemHeaderExtencao" )]
      [  XmlElement( ElementName = "ConfiguracoesImagemHeaderExtencao"   )]
      public string gxTpr_Configuracoesimagemheaderextencao
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoesimagemheaderextencao ;
         }

         set {
            gxTv_SdtConfiguracoes_Configuracoesimagemheaderextencao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesimagemheaderextencao = value;
            SetDirty("Configuracoesimagemheaderextencao");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoesimagemheaderextencao_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoesimagemheaderextencao_N = 1;
         gxTv_SdtConfiguracoes_Configuracoesimagemheaderextencao = "";
         SetDirty("Configuracoesimagemheaderextencao");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoesimagemheaderextencao_IsNull( )
      {
         return (gxTv_SdtConfiguracoes_Configuracoesimagemheaderextencao_N==1) ;
      }

      [  SoapElement( ElementName = "ConfiguracoesImagemHeaderNomeInteiro" )]
      [  XmlElement( ElementName = "ConfiguracoesImagemHeaderNomeInteiro"   )]
      public string gxTpr_Configuracoesimagemheadernomeinteiro
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoesimagemheadernomeinteiro ;
         }

         set {
            gxTv_SdtConfiguracoes_Configuracoesimagemheadernomeinteiro_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesimagemheadernomeinteiro = value;
            SetDirty("Configuracoesimagemheadernomeinteiro");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoesimagemheadernomeinteiro_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoesimagemheadernomeinteiro_N = 1;
         gxTv_SdtConfiguracoes_Configuracoesimagemheadernomeinteiro = "";
         SetDirty("Configuracoesimagemheadernomeinteiro");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoesimagemheadernomeinteiro_IsNull( )
      {
         return (gxTv_SdtConfiguracoes_Configuracoesimagemheadernomeinteiro_N==1) ;
      }

      [  SoapElement( ElementName = "ConfiguracoesImagemHeaderTamanho" )]
      [  XmlElement( ElementName = "ConfiguracoesImagemHeaderTamanho"   )]
      public decimal gxTpr_Configuracoesimagemheadertamanho
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoesimagemheadertamanho ;
         }

         set {
            gxTv_SdtConfiguracoes_Configuracoesimagemheadertamanho_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesimagemheadertamanho = value;
            SetDirty("Configuracoesimagemheadertamanho");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoesimagemheadertamanho_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoesimagemheadertamanho_N = 1;
         gxTv_SdtConfiguracoes_Configuracoesimagemheadertamanho = 0;
         SetDirty("Configuracoesimagemheadertamanho");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoesimagemheadertamanho_IsNull( )
      {
         return (gxTv_SdtConfiguracoes_Configuracoesimagemheadertamanho_N==1) ;
      }

      [  SoapElement( ElementName = "ConfiguracoesLayoutProposta" )]
      [  XmlElement( ElementName = "ConfiguracoesLayoutProposta"   )]
      public short gxTpr_Configuracoeslayoutproposta
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoeslayoutproposta ;
         }

         set {
            gxTv_SdtConfiguracoes_Configuracoeslayoutproposta_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoeslayoutproposta = value;
            SetDirty("Configuracoeslayoutproposta");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoeslayoutproposta_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoeslayoutproposta_N = 1;
         gxTv_SdtConfiguracoes_Configuracoeslayoutproposta = 0;
         SetDirty("Configuracoeslayoutproposta");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoeslayoutproposta_IsNull( )
      {
         return (gxTv_SdtConfiguracoes_Configuracoeslayoutproposta_N==1) ;
      }

      [  SoapElement( ElementName = "ConfiguracoesLayoutContratoCorpo" )]
      [  XmlElement( ElementName = "ConfiguracoesLayoutContratoCorpo"   )]
      public string gxTpr_Configuracoeslayoutcontratocorpo
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoeslayoutcontratocorpo ;
         }

         set {
            gxTv_SdtConfiguracoes_Configuracoeslayoutcontratocorpo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoeslayoutcontratocorpo = value;
            SetDirty("Configuracoeslayoutcontratocorpo");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoeslayoutcontratocorpo_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoeslayoutcontratocorpo_N = 1;
         gxTv_SdtConfiguracoes_Configuracoeslayoutcontratocorpo = "";
         SetDirty("Configuracoeslayoutcontratocorpo");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoeslayoutcontratocorpo_IsNull( )
      {
         return (gxTv_SdtConfiguracoes_Configuracoeslayoutcontratocorpo_N==1) ;
      }

      [  SoapElement( ElementName = "ConfigLayoutPromissoriaClinicaEmprestimo" )]
      [  XmlElement( ElementName = "ConfigLayoutPromissoriaClinicaEmprestimo"   )]
      public short gxTpr_Configlayoutpromissoriaclinicaemprestimo
      {
         get {
            return gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicaemprestimo ;
         }

         set {
            gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicaemprestimo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicaemprestimo = value;
            SetDirty("Configlayoutpromissoriaclinicaemprestimo");
         }

      }

      public void gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicaemprestimo_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicaemprestimo_N = 1;
         gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicaemprestimo = 0;
         SetDirty("Configlayoutpromissoriaclinicaemprestimo");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicaemprestimo_IsNull( )
      {
         return (gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicaemprestimo_N==1) ;
      }

      [  SoapElement( ElementName = "ConfigLayoutCorpoPromissoriaClinicaEmprestimo" )]
      [  XmlElement( ElementName = "ConfigLayoutCorpoPromissoriaClinicaEmprestimo"   )]
      public string gxTpr_Configlayoutcorpopromissoriaclinicaemprestimo
      {
         get {
            return gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriaclinicaemprestimo ;
         }

         set {
            gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriaclinicaemprestimo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriaclinicaemprestimo = value;
            SetDirty("Configlayoutcorpopromissoriaclinicaemprestimo");
         }

      }

      public void gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriaclinicaemprestimo_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriaclinicaemprestimo_N = 1;
         gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriaclinicaemprestimo = "";
         SetDirty("Configlayoutcorpopromissoriaclinicaemprestimo");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriaclinicaemprestimo_IsNull( )
      {
         return (gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriaclinicaemprestimo_N==1) ;
      }

      [  SoapElement( ElementName = "ConfigLayoutPromissoriaClinicaTaxa" )]
      [  XmlElement( ElementName = "ConfigLayoutPromissoriaClinicaTaxa"   )]
      public short gxTpr_Configlayoutpromissoriaclinicataxa
      {
         get {
            return gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicataxa ;
         }

         set {
            gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicataxa_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicataxa = value;
            SetDirty("Configlayoutpromissoriaclinicataxa");
         }

      }

      public void gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicataxa_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicataxa_N = 1;
         gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicataxa = 0;
         SetDirty("Configlayoutpromissoriaclinicataxa");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicataxa_IsNull( )
      {
         return (gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicataxa_N==1) ;
      }

      [  SoapElement( ElementName = "ConfigLayoutCorpoPromissoriaClinicaTaxa" )]
      [  XmlElement( ElementName = "ConfigLayoutCorpoPromissoriaClinicaTaxa"   )]
      public string gxTpr_Configlayoutcorpopromissoriaclinicataxa
      {
         get {
            return gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriaclinicataxa ;
         }

         set {
            gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriaclinicataxa_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriaclinicataxa = value;
            SetDirty("Configlayoutcorpopromissoriaclinicataxa");
         }

      }

      public void gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriaclinicataxa_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriaclinicataxa_N = 1;
         gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriaclinicataxa = "";
         SetDirty("Configlayoutcorpopromissoriaclinicataxa");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriaclinicataxa_IsNull( )
      {
         return (gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriaclinicataxa_N==1) ;
      }

      [  SoapElement( ElementName = "ConfigLayoutPromissoriaPaciente" )]
      [  XmlElement( ElementName = "ConfigLayoutPromissoriaPaciente"   )]
      public short gxTpr_Configlayoutpromissoriapaciente
      {
         get {
            return gxTv_SdtConfiguracoes_Configlayoutpromissoriapaciente ;
         }

         set {
            gxTv_SdtConfiguracoes_Configlayoutpromissoriapaciente_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configlayoutpromissoriapaciente = value;
            SetDirty("Configlayoutpromissoriapaciente");
         }

      }

      public void gxTv_SdtConfiguracoes_Configlayoutpromissoriapaciente_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configlayoutpromissoriapaciente_N = 1;
         gxTv_SdtConfiguracoes_Configlayoutpromissoriapaciente = 0;
         SetDirty("Configlayoutpromissoriapaciente");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configlayoutpromissoriapaciente_IsNull( )
      {
         return (gxTv_SdtConfiguracoes_Configlayoutpromissoriapaciente_N==1) ;
      }

      [  SoapElement( ElementName = "ConfigLayoutContratoCompraTitulo" )]
      [  XmlElement( ElementName = "ConfigLayoutContratoCompraTitulo"   )]
      public short gxTpr_Configlayoutcontratocompratitulo
      {
         get {
            return gxTv_SdtConfiguracoes_Configlayoutcontratocompratitulo ;
         }

         set {
            gxTv_SdtConfiguracoes_Configlayoutcontratocompratitulo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configlayoutcontratocompratitulo = value;
            SetDirty("Configlayoutcontratocompratitulo");
         }

      }

      public void gxTv_SdtConfiguracoes_Configlayoutcontratocompratitulo_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configlayoutcontratocompratitulo_N = 1;
         gxTv_SdtConfiguracoes_Configlayoutcontratocompratitulo = 0;
         SetDirty("Configlayoutcontratocompratitulo");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configlayoutcontratocompratitulo_IsNull( )
      {
         return (gxTv_SdtConfiguracoes_Configlayoutcontratocompratitulo_N==1) ;
      }

      [  SoapElement( ElementName = "ConfigLayoutCorpoPromissoriaPaciente" )]
      [  XmlElement( ElementName = "ConfigLayoutCorpoPromissoriaPaciente"   )]
      public string gxTpr_Configlayoutcorpopromissoriapaciente
      {
         get {
            return gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriapaciente ;
         }

         set {
            gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriapaciente_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriapaciente = value;
            SetDirty("Configlayoutcorpopromissoriapaciente");
         }

      }

      public void gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriapaciente_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriapaciente_N = 1;
         gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriapaciente = "";
         SetDirty("Configlayoutcorpopromissoriapaciente");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriapaciente_IsNull( )
      {
         return (gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriapaciente_N==1) ;
      }

      [  SoapElement( ElementName = "ConfiguracoesArquivoPFX" )]
      [  XmlElement( ElementName = "ConfiguracoesArquivoPFX"   )]
      [GxUpload()]
      public byte[] gxTpr_Configuracoesarquivopfx_Blob
      {
         get {
            IGxContext context = this.context == null ? new GxContext() : this.context;
            return context.FileToByteArray( gxTv_SdtConfiguracoes_Configuracoesarquivopfx) ;
         }

         set {
            gxTv_SdtConfiguracoes_Configuracoesarquivopfx_N = 0;
            sdtIsNull = 0;
            IGxContext context = this.context == null ? new GxContext() : this.context;
            gxTv_SdtConfiguracoes_Configuracoesarquivopfx=context.FileFromByteArray( value) ;
         }

      }

      [XmlIgnore]
      [GxUpload()]
      public string gxTpr_Configuracoesarquivopfx
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoesarquivopfx ;
         }

         set {
            gxTv_SdtConfiguracoes_Configuracoesarquivopfx_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesarquivopfx = value;
            SetDirty("Configuracoesarquivopfx");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoesarquivopfx_SetBlob( string blob ,
                                                                         string fileName ,
                                                                         string fileType )
      {
         gxTv_SdtConfiguracoes_Configuracoesarquivopfx = blob;
         return  ;
      }

      public void gxTv_SdtConfiguracoes_Configuracoesarquivopfx_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoesarquivopfx_N = 1;
         gxTv_SdtConfiguracoes_Configuracoesarquivopfx = "";
         SetDirty("Configuracoesarquivopfx");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoesarquivopfx_IsNull( )
      {
         return (gxTv_SdtConfiguracoes_Configuracoesarquivopfx_N==1) ;
      }

      [  SoapElement( ElementName = "ConfiguracaoSenhaPFX" )]
      [  XmlElement( ElementName = "ConfiguracaoSenhaPFX"   )]
      public string gxTpr_Configuracaosenhapfx
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracaosenhapfx ;
         }

         set {
            gxTv_SdtConfiguracoes_Configuracaosenhapfx_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracaosenhapfx = value;
            SetDirty("Configuracaosenhapfx");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracaosenhapfx_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracaosenhapfx_N = 1;
         gxTv_SdtConfiguracoes_Configuracaosenhapfx = "";
         SetDirty("Configuracaosenhapfx");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracaosenhapfx_IsNull( )
      {
         return (gxTv_SdtConfiguracoes_Configuracaosenhapfx_N==1) ;
      }

      [  SoapElement( ElementName = "ConfiguracoesCategoriaTitulo" )]
      [  XmlElement( ElementName = "ConfiguracoesCategoriaTitulo"   )]
      public int gxTpr_Configuracoescategoriatitulo
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoescategoriatitulo ;
         }

         set {
            gxTv_SdtConfiguracoes_Configuracoescategoriatitulo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoescategoriatitulo = value;
            SetDirty("Configuracoescategoriatitulo");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoescategoriatitulo_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoescategoriatitulo_N = 1;
         gxTv_SdtConfiguracoes_Configuracoescategoriatitulo = 0;
         SetDirty("Configuracoescategoriatitulo");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoescategoriatitulo_IsNull( )
      {
         return (gxTv_SdtConfiguracoes_Configuracoescategoriatitulo_N==1) ;
      }

      [  SoapElement( ElementName = "ConfiguracoesSerasaAnotacoesCompletas" )]
      [  XmlElement( ElementName = "ConfiguracoesSerasaAnotacoesCompletas"   )]
      public bool gxTpr_Configuracoesserasaanotacoescompletas
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoesserasaanotacoescompletas ;
         }

         set {
            gxTv_SdtConfiguracoes_Configuracoesserasaanotacoescompletas_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesserasaanotacoescompletas = value;
            SetDirty("Configuracoesserasaanotacoescompletas");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoesserasaanotacoescompletas_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoesserasaanotacoescompletas_N = 1;
         gxTv_SdtConfiguracoes_Configuracoesserasaanotacoescompletas = false;
         SetDirty("Configuracoesserasaanotacoescompletas");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoesserasaanotacoescompletas_IsNull( )
      {
         return (gxTv_SdtConfiguracoes_Configuracoesserasaanotacoescompletas_N==1) ;
      }

      [  SoapElement( ElementName = "ConfiguracoesSerasaConsultaDetalhada" )]
      [  XmlElement( ElementName = "ConfiguracoesSerasaConsultaDetalhada"   )]
      public bool gxTpr_Configuracoesserasaconsultadetalhada
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoesserasaconsultadetalhada ;
         }

         set {
            gxTv_SdtConfiguracoes_Configuracoesserasaconsultadetalhada_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesserasaconsultadetalhada = value;
            SetDirty("Configuracoesserasaconsultadetalhada");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoesserasaconsultadetalhada_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoesserasaconsultadetalhada_N = 1;
         gxTv_SdtConfiguracoes_Configuracoesserasaconsultadetalhada = false;
         SetDirty("Configuracoesserasaconsultadetalhada");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoesserasaconsultadetalhada_IsNull( )
      {
         return (gxTv_SdtConfiguracoes_Configuracoesserasaconsultadetalhada_N==1) ;
      }

      [  SoapElement( ElementName = "ConfiguracoesSerasaParticipacaoSocietaria" )]
      [  XmlElement( ElementName = "ConfiguracoesSerasaParticipacaoSocietaria"   )]
      public bool gxTpr_Configuracoesserasaparticipacaosocietaria
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoesserasaparticipacaosocietaria ;
         }

         set {
            gxTv_SdtConfiguracoes_Configuracoesserasaparticipacaosocietaria_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesserasaparticipacaosocietaria = value;
            SetDirty("Configuracoesserasaparticipacaosocietaria");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoesserasaparticipacaosocietaria_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoesserasaparticipacaosocietaria_N = 1;
         gxTv_SdtConfiguracoes_Configuracoesserasaparticipacaosocietaria = false;
         SetDirty("Configuracoesserasaparticipacaosocietaria");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoesserasaparticipacaosocietaria_IsNull( )
      {
         return (gxTv_SdtConfiguracoes_Configuracoesserasaparticipacaosocietaria_N==1) ;
      }

      [  SoapElement( ElementName = "ConfiguracoesSerasaRendaEstimada" )]
      [  XmlElement( ElementName = "ConfiguracoesSerasaRendaEstimada"   )]
      public bool gxTpr_Configuracoesserasarendaestimada
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoesserasarendaestimada ;
         }

         set {
            gxTv_SdtConfiguracoes_Configuracoesserasarendaestimada_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesserasarendaestimada = value;
            SetDirty("Configuracoesserasarendaestimada");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoesserasarendaestimada_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoesserasarendaestimada_N = 1;
         gxTv_SdtConfiguracoes_Configuracoesserasarendaestimada = false;
         SetDirty("Configuracoesserasarendaestimada");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoesserasarendaestimada_IsNull( )
      {
         return (gxTv_SdtConfiguracoes_Configuracoesserasarendaestimada_N==1) ;
      }

      [  SoapElement( ElementName = "ConfiguracoesSerasaHistoricoPagamento" )]
      [  XmlElement( ElementName = "ConfiguracoesSerasaHistoricoPagamento"   )]
      public bool gxTpr_Configuracoesserasahistoricopagamento
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoesserasahistoricopagamento ;
         }

         set {
            gxTv_SdtConfiguracoes_Configuracoesserasahistoricopagamento_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesserasahistoricopagamento = value;
            SetDirty("Configuracoesserasahistoricopagamento");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoesserasahistoricopagamento_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoesserasahistoricopagamento_N = 1;
         gxTv_SdtConfiguracoes_Configuracoesserasahistoricopagamento = false;
         SetDirty("Configuracoesserasahistoricopagamento");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoesserasahistoricopagamento_IsNull( )
      {
         return (gxTv_SdtConfiguracoes_Configuracoesserasahistoricopagamento_N==1) ;
      }

      [  SoapElement( ElementName = "ConfiguracoesCompraTituloTaxaEfetiva" )]
      [  XmlElement( ElementName = "ConfiguracoesCompraTituloTaxaEfetiva"   )]
      public decimal gxTpr_Configuracoescompratitulotaxaefetiva
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoescompratitulotaxaefetiva ;
         }

         set {
            gxTv_SdtConfiguracoes_Configuracoescompratitulotaxaefetiva_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoescompratitulotaxaefetiva = value;
            SetDirty("Configuracoescompratitulotaxaefetiva");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoescompratitulotaxaefetiva_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoescompratitulotaxaefetiva_N = 1;
         gxTv_SdtConfiguracoes_Configuracoescompratitulotaxaefetiva = 0;
         SetDirty("Configuracoescompratitulotaxaefetiva");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoescompratitulotaxaefetiva_IsNull( )
      {
         return (gxTv_SdtConfiguracoes_Configuracoescompratitulotaxaefetiva_N==1) ;
      }

      [  SoapElement( ElementName = "ConfiguracoesCompraTituloTaxaMora" )]
      [  XmlElement( ElementName = "ConfiguracoesCompraTituloTaxaMora"   )]
      public decimal gxTpr_Configuracoescompratitulotaxamora
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoescompratitulotaxamora ;
         }

         set {
            gxTv_SdtConfiguracoes_Configuracoescompratitulotaxamora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoescompratitulotaxamora = value;
            SetDirty("Configuracoescompratitulotaxamora");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoescompratitulotaxamora_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoescompratitulotaxamora_N = 1;
         gxTv_SdtConfiguracoes_Configuracoescompratitulotaxamora = 0;
         SetDirty("Configuracoescompratitulotaxamora");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoescompratitulotaxamora_IsNull( )
      {
         return (gxTv_SdtConfiguracoes_Configuracoescompratitulotaxamora_N==1) ;
      }

      [  SoapElement( ElementName = "ConfiguracoesCompraTituloFator" )]
      [  XmlElement( ElementName = "ConfiguracoesCompraTituloFator"   )]
      public decimal gxTpr_Configuracoescompratitulofator
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoescompratitulofator ;
         }

         set {
            gxTv_SdtConfiguracoes_Configuracoescompratitulofator_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoescompratitulofator = value;
            SetDirty("Configuracoescompratitulofator");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoescompratitulofator_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoescompratitulofator_N = 1;
         gxTv_SdtConfiguracoes_Configuracoescompratitulofator = 0;
         SetDirty("Configuracoescompratitulofator");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoescompratitulofator_IsNull( )
      {
         return (gxTv_SdtConfiguracoes_Configuracoescompratitulofator_N==1) ;
      }

      [  SoapElement( ElementName = "ConfiguracoesCompraTituloTarifaTipo" )]
      [  XmlElement( ElementName = "ConfiguracoesCompraTituloTarifaTipo"   )]
      public string gxTpr_Configuracoescompratitulotarifatipo
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoescompratitulotarifatipo ;
         }

         set {
            gxTv_SdtConfiguracoes_Configuracoescompratitulotarifatipo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoescompratitulotarifatipo = value;
            SetDirty("Configuracoescompratitulotarifatipo");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoescompratitulotarifatipo_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoescompratitulotarifatipo_N = 1;
         gxTv_SdtConfiguracoes_Configuracoescompratitulotarifatipo = "";
         SetDirty("Configuracoescompratitulotarifatipo");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoescompratitulotarifatipo_IsNull( )
      {
         return (gxTv_SdtConfiguracoes_Configuracoescompratitulotarifatipo_N==1) ;
      }

      [  SoapElement( ElementName = "ConfiguracoesCompraTituloTarifa" )]
      [  XmlElement( ElementName = "ConfiguracoesCompraTituloTarifa"   )]
      public decimal gxTpr_Configuracoescompratitulotarifa
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoescompratitulotarifa ;
         }

         set {
            gxTv_SdtConfiguracoes_Configuracoescompratitulotarifa_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoescompratitulotarifa = value;
            SetDirty("Configuracoescompratitulotarifa");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoescompratitulotarifa_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoescompratitulotarifa_N = 1;
         gxTv_SdtConfiguracoes_Configuracoescompratitulotarifa = 0;
         SetDirty("Configuracoescompratitulotarifa");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoescompratitulotarifa_IsNull( )
      {
         return (gxTv_SdtConfiguracoes_Configuracoescompratitulotarifa_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtConfiguracoes_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtConfiguracoes_Mode_SetNull( )
      {
         gxTv_SdtConfiguracoes_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtConfiguracoes_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtConfiguracoes_Initialized_SetNull( )
      {
         gxTv_SdtConfiguracoes_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracoesId_Z" )]
      [  XmlElement( ElementName = "ConfiguracoesId_Z"   )]
      public int gxTpr_Configuracoesid_Z
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoesid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesid_Z = value;
            SetDirty("Configuracoesid_Z");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoesid_Z_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoesid_Z = 0;
         SetDirty("Configuracoesid_Z");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoesid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracoesImagemLoginNome_Z" )]
      [  XmlElement( ElementName = "ConfiguracoesImagemLoginNome_Z"   )]
      public string gxTpr_Configuracoesimagemloginnome_Z
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoesimagemloginnome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesimagemloginnome_Z = value;
            SetDirty("Configuracoesimagemloginnome_Z");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoesimagemloginnome_Z_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoesimagemloginnome_Z = "";
         SetDirty("Configuracoesimagemloginnome_Z");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoesimagemloginnome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracoesImagemLoginExtencao_Z" )]
      [  XmlElement( ElementName = "ConfiguracoesImagemLoginExtencao_Z"   )]
      public string gxTpr_Configuracoesimagemloginextencao_Z
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoesimagemloginextencao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesimagemloginextencao_Z = value;
            SetDirty("Configuracoesimagemloginextencao_Z");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoesimagemloginextencao_Z_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoesimagemloginextencao_Z = "";
         SetDirty("Configuracoesimagemloginextencao_Z");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoesimagemloginextencao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracoesImagemLoginNomeInteiro_Z" )]
      [  XmlElement( ElementName = "ConfiguracoesImagemLoginNomeInteiro_Z"   )]
      public string gxTpr_Configuracoesimagemloginnomeinteiro_Z
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoesimagemloginnomeinteiro_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesimagemloginnomeinteiro_Z = value;
            SetDirty("Configuracoesimagemloginnomeinteiro_Z");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoesimagemloginnomeinteiro_Z_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoesimagemloginnomeinteiro_Z = "";
         SetDirty("Configuracoesimagemloginnomeinteiro_Z");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoesimagemloginnomeinteiro_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracoesImagemLoginTamanho_Z" )]
      [  XmlElement( ElementName = "ConfiguracoesImagemLoginTamanho_Z"   )]
      public decimal gxTpr_Configuracoesimagemlogintamanho_Z
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoesimagemlogintamanho_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesimagemlogintamanho_Z = value;
            SetDirty("Configuracoesimagemlogintamanho_Z");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoesimagemlogintamanho_Z_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoesimagemlogintamanho_Z = 0;
         SetDirty("Configuracoesimagemlogintamanho_Z");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoesimagemlogintamanho_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracoesImagemLoginBackground_Z" )]
      [  XmlElement( ElementName = "ConfiguracoesImagemLoginBackground_Z"   )]
      public string gxTpr_Configuracoesimagemloginbackground_Z
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoesimagemloginbackground_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesimagemloginbackground_Z = value;
            SetDirty("Configuracoesimagemloginbackground_Z");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoesimagemloginbackground_Z_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoesimagemloginbackground_Z = "";
         SetDirty("Configuracoesimagemloginbackground_Z");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoesimagemloginbackground_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracoesImagemHeaderNome_Z" )]
      [  XmlElement( ElementName = "ConfiguracoesImagemHeaderNome_Z"   )]
      public string gxTpr_Configuracoesimagemheadernome_Z
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoesimagemheadernome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesimagemheadernome_Z = value;
            SetDirty("Configuracoesimagemheadernome_Z");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoesimagemheadernome_Z_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoesimagemheadernome_Z = "";
         SetDirty("Configuracoesimagemheadernome_Z");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoesimagemheadernome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracoesImagemHeaderExtencao_Z" )]
      [  XmlElement( ElementName = "ConfiguracoesImagemHeaderExtencao_Z"   )]
      public string gxTpr_Configuracoesimagemheaderextencao_Z
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoesimagemheaderextencao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesimagemheaderextencao_Z = value;
            SetDirty("Configuracoesimagemheaderextencao_Z");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoesimagemheaderextencao_Z_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoesimagemheaderextencao_Z = "";
         SetDirty("Configuracoesimagemheaderextencao_Z");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoesimagemheaderextencao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracoesImagemHeaderNomeInteiro_Z" )]
      [  XmlElement( ElementName = "ConfiguracoesImagemHeaderNomeInteiro_Z"   )]
      public string gxTpr_Configuracoesimagemheadernomeinteiro_Z
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoesimagemheadernomeinteiro_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesimagemheadernomeinteiro_Z = value;
            SetDirty("Configuracoesimagemheadernomeinteiro_Z");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoesimagemheadernomeinteiro_Z_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoesimagemheadernomeinteiro_Z = "";
         SetDirty("Configuracoesimagemheadernomeinteiro_Z");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoesimagemheadernomeinteiro_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracoesImagemHeaderTamanho_Z" )]
      [  XmlElement( ElementName = "ConfiguracoesImagemHeaderTamanho_Z"   )]
      public decimal gxTpr_Configuracoesimagemheadertamanho_Z
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoesimagemheadertamanho_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesimagemheadertamanho_Z = value;
            SetDirty("Configuracoesimagemheadertamanho_Z");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoesimagemheadertamanho_Z_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoesimagemheadertamanho_Z = 0;
         SetDirty("Configuracoesimagemheadertamanho_Z");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoesimagemheadertamanho_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracoesLayoutProposta_Z" )]
      [  XmlElement( ElementName = "ConfiguracoesLayoutProposta_Z"   )]
      public short gxTpr_Configuracoeslayoutproposta_Z
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoeslayoutproposta_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoeslayoutproposta_Z = value;
            SetDirty("Configuracoeslayoutproposta_Z");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoeslayoutproposta_Z_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoeslayoutproposta_Z = 0;
         SetDirty("Configuracoeslayoutproposta_Z");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoeslayoutproposta_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfigLayoutPromissoriaClinicaEmprestimo_Z" )]
      [  XmlElement( ElementName = "ConfigLayoutPromissoriaClinicaEmprestimo_Z"   )]
      public short gxTpr_Configlayoutpromissoriaclinicaemprestimo_Z
      {
         get {
            return gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicaemprestimo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicaemprestimo_Z = value;
            SetDirty("Configlayoutpromissoriaclinicaemprestimo_Z");
         }

      }

      public void gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicaemprestimo_Z_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicaemprestimo_Z = 0;
         SetDirty("Configlayoutpromissoriaclinicaemprestimo_Z");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicaemprestimo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfigLayoutPromissoriaClinicaTaxa_Z" )]
      [  XmlElement( ElementName = "ConfigLayoutPromissoriaClinicaTaxa_Z"   )]
      public short gxTpr_Configlayoutpromissoriaclinicataxa_Z
      {
         get {
            return gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicataxa_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicataxa_Z = value;
            SetDirty("Configlayoutpromissoriaclinicataxa_Z");
         }

      }

      public void gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicataxa_Z_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicataxa_Z = 0;
         SetDirty("Configlayoutpromissoriaclinicataxa_Z");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicataxa_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfigLayoutPromissoriaPaciente_Z" )]
      [  XmlElement( ElementName = "ConfigLayoutPromissoriaPaciente_Z"   )]
      public short gxTpr_Configlayoutpromissoriapaciente_Z
      {
         get {
            return gxTv_SdtConfiguracoes_Configlayoutpromissoriapaciente_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configlayoutpromissoriapaciente_Z = value;
            SetDirty("Configlayoutpromissoriapaciente_Z");
         }

      }

      public void gxTv_SdtConfiguracoes_Configlayoutpromissoriapaciente_Z_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configlayoutpromissoriapaciente_Z = 0;
         SetDirty("Configlayoutpromissoriapaciente_Z");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configlayoutpromissoriapaciente_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfigLayoutContratoCompraTitulo_Z" )]
      [  XmlElement( ElementName = "ConfigLayoutContratoCompraTitulo_Z"   )]
      public short gxTpr_Configlayoutcontratocompratitulo_Z
      {
         get {
            return gxTv_SdtConfiguracoes_Configlayoutcontratocompratitulo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configlayoutcontratocompratitulo_Z = value;
            SetDirty("Configlayoutcontratocompratitulo_Z");
         }

      }

      public void gxTv_SdtConfiguracoes_Configlayoutcontratocompratitulo_Z_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configlayoutcontratocompratitulo_Z = 0;
         SetDirty("Configlayoutcontratocompratitulo_Z");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configlayoutcontratocompratitulo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracaoSenhaPFX_Z" )]
      [  XmlElement( ElementName = "ConfiguracaoSenhaPFX_Z"   )]
      public string gxTpr_Configuracaosenhapfx_Z
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracaosenhapfx_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracaosenhapfx_Z = value;
            SetDirty("Configuracaosenhapfx_Z");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracaosenhapfx_Z_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracaosenhapfx_Z = "";
         SetDirty("Configuracaosenhapfx_Z");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracaosenhapfx_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracoesCategoriaTitulo_Z" )]
      [  XmlElement( ElementName = "ConfiguracoesCategoriaTitulo_Z"   )]
      public int gxTpr_Configuracoescategoriatitulo_Z
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoescategoriatitulo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoescategoriatitulo_Z = value;
            SetDirty("Configuracoescategoriatitulo_Z");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoescategoriatitulo_Z_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoescategoriatitulo_Z = 0;
         SetDirty("Configuracoescategoriatitulo_Z");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoescategoriatitulo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracoesSerasaAnotacoesCompletas_Z" )]
      [  XmlElement( ElementName = "ConfiguracoesSerasaAnotacoesCompletas_Z"   )]
      public bool gxTpr_Configuracoesserasaanotacoescompletas_Z
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoesserasaanotacoescompletas_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesserasaanotacoescompletas_Z = value;
            SetDirty("Configuracoesserasaanotacoescompletas_Z");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoesserasaanotacoescompletas_Z_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoesserasaanotacoescompletas_Z = false;
         SetDirty("Configuracoesserasaanotacoescompletas_Z");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoesserasaanotacoescompletas_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracoesSerasaConsultaDetalhada_Z" )]
      [  XmlElement( ElementName = "ConfiguracoesSerasaConsultaDetalhada_Z"   )]
      public bool gxTpr_Configuracoesserasaconsultadetalhada_Z
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoesserasaconsultadetalhada_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesserasaconsultadetalhada_Z = value;
            SetDirty("Configuracoesserasaconsultadetalhada_Z");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoesserasaconsultadetalhada_Z_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoesserasaconsultadetalhada_Z = false;
         SetDirty("Configuracoesserasaconsultadetalhada_Z");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoesserasaconsultadetalhada_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracoesSerasaParticipacaoSocietaria_Z" )]
      [  XmlElement( ElementName = "ConfiguracoesSerasaParticipacaoSocietaria_Z"   )]
      public bool gxTpr_Configuracoesserasaparticipacaosocietaria_Z
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoesserasaparticipacaosocietaria_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesserasaparticipacaosocietaria_Z = value;
            SetDirty("Configuracoesserasaparticipacaosocietaria_Z");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoesserasaparticipacaosocietaria_Z_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoesserasaparticipacaosocietaria_Z = false;
         SetDirty("Configuracoesserasaparticipacaosocietaria_Z");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoesserasaparticipacaosocietaria_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracoesSerasaRendaEstimada_Z" )]
      [  XmlElement( ElementName = "ConfiguracoesSerasaRendaEstimada_Z"   )]
      public bool gxTpr_Configuracoesserasarendaestimada_Z
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoesserasarendaestimada_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesserasarendaestimada_Z = value;
            SetDirty("Configuracoesserasarendaestimada_Z");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoesserasarendaestimada_Z_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoesserasarendaestimada_Z = false;
         SetDirty("Configuracoesserasarendaestimada_Z");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoesserasarendaestimada_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracoesSerasaHistoricoPagamento_Z" )]
      [  XmlElement( ElementName = "ConfiguracoesSerasaHistoricoPagamento_Z"   )]
      public bool gxTpr_Configuracoesserasahistoricopagamento_Z
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoesserasahistoricopagamento_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesserasahistoricopagamento_Z = value;
            SetDirty("Configuracoesserasahistoricopagamento_Z");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoesserasahistoricopagamento_Z_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoesserasahistoricopagamento_Z = false;
         SetDirty("Configuracoesserasahistoricopagamento_Z");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoesserasahistoricopagamento_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracoesCompraTituloTaxaEfetiva_Z" )]
      [  XmlElement( ElementName = "ConfiguracoesCompraTituloTaxaEfetiva_Z"   )]
      public decimal gxTpr_Configuracoescompratitulotaxaefetiva_Z
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoescompratitulotaxaefetiva_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoescompratitulotaxaefetiva_Z = value;
            SetDirty("Configuracoescompratitulotaxaefetiva_Z");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoescompratitulotaxaefetiva_Z_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoescompratitulotaxaefetiva_Z = 0;
         SetDirty("Configuracoescompratitulotaxaefetiva_Z");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoescompratitulotaxaefetiva_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracoesCompraTituloTaxaMora_Z" )]
      [  XmlElement( ElementName = "ConfiguracoesCompraTituloTaxaMora_Z"   )]
      public decimal gxTpr_Configuracoescompratitulotaxamora_Z
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoescompratitulotaxamora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoescompratitulotaxamora_Z = value;
            SetDirty("Configuracoescompratitulotaxamora_Z");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoescompratitulotaxamora_Z_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoescompratitulotaxamora_Z = 0;
         SetDirty("Configuracoescompratitulotaxamora_Z");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoescompratitulotaxamora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracoesCompraTituloFator_Z" )]
      [  XmlElement( ElementName = "ConfiguracoesCompraTituloFator_Z"   )]
      public decimal gxTpr_Configuracoescompratitulofator_Z
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoescompratitulofator_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoescompratitulofator_Z = value;
            SetDirty("Configuracoescompratitulofator_Z");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoescompratitulofator_Z_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoescompratitulofator_Z = 0;
         SetDirty("Configuracoescompratitulofator_Z");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoescompratitulofator_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracoesCompraTituloTarifaTipo_Z" )]
      [  XmlElement( ElementName = "ConfiguracoesCompraTituloTarifaTipo_Z"   )]
      public string gxTpr_Configuracoescompratitulotarifatipo_Z
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoescompratitulotarifatipo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoescompratitulotarifatipo_Z = value;
            SetDirty("Configuracoescompratitulotarifatipo_Z");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoescompratitulotarifatipo_Z_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoescompratitulotarifatipo_Z = "";
         SetDirty("Configuracoescompratitulotarifatipo_Z");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoescompratitulotarifatipo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracoesCompraTituloTarifa_Z" )]
      [  XmlElement( ElementName = "ConfiguracoesCompraTituloTarifa_Z"   )]
      public decimal gxTpr_Configuracoescompratitulotarifa_Z
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoescompratitulotarifa_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoescompratitulotarifa_Z = value;
            SetDirty("Configuracoescompratitulotarifa_Z");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoescompratitulotarifa_Z_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoescompratitulotarifa_Z = 0;
         SetDirty("Configuracoescompratitulotarifa_Z");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoescompratitulotarifa_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracoesImagemLogin_N" )]
      [  XmlElement( ElementName = "ConfiguracoesImagemLogin_N"   )]
      public short gxTpr_Configuracoesimagemlogin_N
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoesimagemlogin_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesimagemlogin_N = value;
            SetDirty("Configuracoesimagemlogin_N");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoesimagemlogin_N_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoesimagemlogin_N = 0;
         SetDirty("Configuracoesimagemlogin_N");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoesimagemlogin_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracoesImagemLoginNome_N" )]
      [  XmlElement( ElementName = "ConfiguracoesImagemLoginNome_N"   )]
      public short gxTpr_Configuracoesimagemloginnome_N
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoesimagemloginnome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesimagemloginnome_N = value;
            SetDirty("Configuracoesimagemloginnome_N");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoesimagemloginnome_N_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoesimagemloginnome_N = 0;
         SetDirty("Configuracoesimagemloginnome_N");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoesimagemloginnome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracoesImagemLoginExtencao_N" )]
      [  XmlElement( ElementName = "ConfiguracoesImagemLoginExtencao_N"   )]
      public short gxTpr_Configuracoesimagemloginextencao_N
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoesimagemloginextencao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesimagemloginextencao_N = value;
            SetDirty("Configuracoesimagemloginextencao_N");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoesimagemloginextencao_N_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoesimagemloginextencao_N = 0;
         SetDirty("Configuracoesimagemloginextencao_N");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoesimagemloginextencao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracoesImagemLoginNomeInteiro_N" )]
      [  XmlElement( ElementName = "ConfiguracoesImagemLoginNomeInteiro_N"   )]
      public short gxTpr_Configuracoesimagemloginnomeinteiro_N
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoesimagemloginnomeinteiro_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesimagemloginnomeinteiro_N = value;
            SetDirty("Configuracoesimagemloginnomeinteiro_N");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoesimagemloginnomeinteiro_N_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoesimagemloginnomeinteiro_N = 0;
         SetDirty("Configuracoesimagemloginnomeinteiro_N");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoesimagemloginnomeinteiro_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracoesImagemLoginTamanho_N" )]
      [  XmlElement( ElementName = "ConfiguracoesImagemLoginTamanho_N"   )]
      public short gxTpr_Configuracoesimagemlogintamanho_N
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoesimagemlogintamanho_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesimagemlogintamanho_N = value;
            SetDirty("Configuracoesimagemlogintamanho_N");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoesimagemlogintamanho_N_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoesimagemlogintamanho_N = 0;
         SetDirty("Configuracoesimagemlogintamanho_N");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoesimagemlogintamanho_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracoesImagemLoginBackground_N" )]
      [  XmlElement( ElementName = "ConfiguracoesImagemLoginBackground_N"   )]
      public short gxTpr_Configuracoesimagemloginbackground_N
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoesimagemloginbackground_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesimagemloginbackground_N = value;
            SetDirty("Configuracoesimagemloginbackground_N");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoesimagemloginbackground_N_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoesimagemloginbackground_N = 0;
         SetDirty("Configuracoesimagemloginbackground_N");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoesimagemloginbackground_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracoesImagemHeader_N" )]
      [  XmlElement( ElementName = "ConfiguracoesImagemHeader_N"   )]
      public short gxTpr_Configuracoesimagemheader_N
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoesimagemheader_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesimagemheader_N = value;
            SetDirty("Configuracoesimagemheader_N");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoesimagemheader_N_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoesimagemheader_N = 0;
         SetDirty("Configuracoesimagemheader_N");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoesimagemheader_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracoesImagemHeaderNome_N" )]
      [  XmlElement( ElementName = "ConfiguracoesImagemHeaderNome_N"   )]
      public short gxTpr_Configuracoesimagemheadernome_N
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoesimagemheadernome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesimagemheadernome_N = value;
            SetDirty("Configuracoesimagemheadernome_N");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoesimagemheadernome_N_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoesimagemheadernome_N = 0;
         SetDirty("Configuracoesimagemheadernome_N");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoesimagemheadernome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracoesImagemHeaderExtencao_N" )]
      [  XmlElement( ElementName = "ConfiguracoesImagemHeaderExtencao_N"   )]
      public short gxTpr_Configuracoesimagemheaderextencao_N
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoesimagemheaderextencao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesimagemheaderextencao_N = value;
            SetDirty("Configuracoesimagemheaderextencao_N");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoesimagemheaderextencao_N_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoesimagemheaderextencao_N = 0;
         SetDirty("Configuracoesimagemheaderextencao_N");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoesimagemheaderextencao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracoesImagemHeaderNomeInteiro_N" )]
      [  XmlElement( ElementName = "ConfiguracoesImagemHeaderNomeInteiro_N"   )]
      public short gxTpr_Configuracoesimagemheadernomeinteiro_N
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoesimagemheadernomeinteiro_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesimagemheadernomeinteiro_N = value;
            SetDirty("Configuracoesimagemheadernomeinteiro_N");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoesimagemheadernomeinteiro_N_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoesimagemheadernomeinteiro_N = 0;
         SetDirty("Configuracoesimagemheadernomeinteiro_N");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoesimagemheadernomeinteiro_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracoesImagemHeaderTamanho_N" )]
      [  XmlElement( ElementName = "ConfiguracoesImagemHeaderTamanho_N"   )]
      public short gxTpr_Configuracoesimagemheadertamanho_N
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoesimagemheadertamanho_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesimagemheadertamanho_N = value;
            SetDirty("Configuracoesimagemheadertamanho_N");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoesimagemheadertamanho_N_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoesimagemheadertamanho_N = 0;
         SetDirty("Configuracoesimagemheadertamanho_N");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoesimagemheadertamanho_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracoesLayoutProposta_N" )]
      [  XmlElement( ElementName = "ConfiguracoesLayoutProposta_N"   )]
      public short gxTpr_Configuracoeslayoutproposta_N
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoeslayoutproposta_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoeslayoutproposta_N = value;
            SetDirty("Configuracoeslayoutproposta_N");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoeslayoutproposta_N_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoeslayoutproposta_N = 0;
         SetDirty("Configuracoeslayoutproposta_N");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoeslayoutproposta_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracoesLayoutContratoCorpo_N" )]
      [  XmlElement( ElementName = "ConfiguracoesLayoutContratoCorpo_N"   )]
      public short gxTpr_Configuracoeslayoutcontratocorpo_N
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoeslayoutcontratocorpo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoeslayoutcontratocorpo_N = value;
            SetDirty("Configuracoeslayoutcontratocorpo_N");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoeslayoutcontratocorpo_N_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoeslayoutcontratocorpo_N = 0;
         SetDirty("Configuracoeslayoutcontratocorpo_N");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoeslayoutcontratocorpo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfigLayoutPromissoriaClinicaEmprestimo_N" )]
      [  XmlElement( ElementName = "ConfigLayoutPromissoriaClinicaEmprestimo_N"   )]
      public short gxTpr_Configlayoutpromissoriaclinicaemprestimo_N
      {
         get {
            return gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicaemprestimo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicaemprestimo_N = value;
            SetDirty("Configlayoutpromissoriaclinicaemprestimo_N");
         }

      }

      public void gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicaemprestimo_N_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicaemprestimo_N = 0;
         SetDirty("Configlayoutpromissoriaclinicaemprestimo_N");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicaemprestimo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfigLayoutCorpoPromissoriaClinicaEmprestimo_N" )]
      [  XmlElement( ElementName = "ConfigLayoutCorpoPromissoriaClinicaEmprestimo_N"   )]
      public short gxTpr_Configlayoutcorpopromissoriaclinicaemprestimo_N
      {
         get {
            return gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriaclinicaemprestimo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriaclinicaemprestimo_N = value;
            SetDirty("Configlayoutcorpopromissoriaclinicaemprestimo_N");
         }

      }

      public void gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriaclinicaemprestimo_N_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriaclinicaemprestimo_N = 0;
         SetDirty("Configlayoutcorpopromissoriaclinicaemprestimo_N");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriaclinicaemprestimo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfigLayoutPromissoriaClinicaTaxa_N" )]
      [  XmlElement( ElementName = "ConfigLayoutPromissoriaClinicaTaxa_N"   )]
      public short gxTpr_Configlayoutpromissoriaclinicataxa_N
      {
         get {
            return gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicataxa_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicataxa_N = value;
            SetDirty("Configlayoutpromissoriaclinicataxa_N");
         }

      }

      public void gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicataxa_N_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicataxa_N = 0;
         SetDirty("Configlayoutpromissoriaclinicataxa_N");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicataxa_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfigLayoutCorpoPromissoriaClinicaTaxa_N" )]
      [  XmlElement( ElementName = "ConfigLayoutCorpoPromissoriaClinicaTaxa_N"   )]
      public short gxTpr_Configlayoutcorpopromissoriaclinicataxa_N
      {
         get {
            return gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriaclinicataxa_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriaclinicataxa_N = value;
            SetDirty("Configlayoutcorpopromissoriaclinicataxa_N");
         }

      }

      public void gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriaclinicataxa_N_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriaclinicataxa_N = 0;
         SetDirty("Configlayoutcorpopromissoriaclinicataxa_N");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriaclinicataxa_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfigLayoutPromissoriaPaciente_N" )]
      [  XmlElement( ElementName = "ConfigLayoutPromissoriaPaciente_N"   )]
      public short gxTpr_Configlayoutpromissoriapaciente_N
      {
         get {
            return gxTv_SdtConfiguracoes_Configlayoutpromissoriapaciente_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configlayoutpromissoriapaciente_N = value;
            SetDirty("Configlayoutpromissoriapaciente_N");
         }

      }

      public void gxTv_SdtConfiguracoes_Configlayoutpromissoriapaciente_N_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configlayoutpromissoriapaciente_N = 0;
         SetDirty("Configlayoutpromissoriapaciente_N");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configlayoutpromissoriapaciente_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfigLayoutContratoCompraTitulo_N" )]
      [  XmlElement( ElementName = "ConfigLayoutContratoCompraTitulo_N"   )]
      public short gxTpr_Configlayoutcontratocompratitulo_N
      {
         get {
            return gxTv_SdtConfiguracoes_Configlayoutcontratocompratitulo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configlayoutcontratocompratitulo_N = value;
            SetDirty("Configlayoutcontratocompratitulo_N");
         }

      }

      public void gxTv_SdtConfiguracoes_Configlayoutcontratocompratitulo_N_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configlayoutcontratocompratitulo_N = 0;
         SetDirty("Configlayoutcontratocompratitulo_N");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configlayoutcontratocompratitulo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfigLayoutCorpoPromissoriaPaciente_N" )]
      [  XmlElement( ElementName = "ConfigLayoutCorpoPromissoriaPaciente_N"   )]
      public short gxTpr_Configlayoutcorpopromissoriapaciente_N
      {
         get {
            return gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriapaciente_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriapaciente_N = value;
            SetDirty("Configlayoutcorpopromissoriapaciente_N");
         }

      }

      public void gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriapaciente_N_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriapaciente_N = 0;
         SetDirty("Configlayoutcorpopromissoriapaciente_N");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriapaciente_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracoesArquivoPFX_N" )]
      [  XmlElement( ElementName = "ConfiguracoesArquivoPFX_N"   )]
      public short gxTpr_Configuracoesarquivopfx_N
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoesarquivopfx_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesarquivopfx_N = value;
            SetDirty("Configuracoesarquivopfx_N");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoesarquivopfx_N_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoesarquivopfx_N = 0;
         SetDirty("Configuracoesarquivopfx_N");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoesarquivopfx_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracaoSenhaPFX_N" )]
      [  XmlElement( ElementName = "ConfiguracaoSenhaPFX_N"   )]
      public short gxTpr_Configuracaosenhapfx_N
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracaosenhapfx_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracaosenhapfx_N = value;
            SetDirty("Configuracaosenhapfx_N");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracaosenhapfx_N_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracaosenhapfx_N = 0;
         SetDirty("Configuracaosenhapfx_N");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracaosenhapfx_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracoesCategoriaTitulo_N" )]
      [  XmlElement( ElementName = "ConfiguracoesCategoriaTitulo_N"   )]
      public short gxTpr_Configuracoescategoriatitulo_N
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoescategoriatitulo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoescategoriatitulo_N = value;
            SetDirty("Configuracoescategoriatitulo_N");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoescategoriatitulo_N_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoescategoriatitulo_N = 0;
         SetDirty("Configuracoescategoriatitulo_N");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoescategoriatitulo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracoesSerasaAnotacoesCompletas_N" )]
      [  XmlElement( ElementName = "ConfiguracoesSerasaAnotacoesCompletas_N"   )]
      public short gxTpr_Configuracoesserasaanotacoescompletas_N
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoesserasaanotacoescompletas_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesserasaanotacoescompletas_N = value;
            SetDirty("Configuracoesserasaanotacoescompletas_N");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoesserasaanotacoescompletas_N_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoesserasaanotacoescompletas_N = 0;
         SetDirty("Configuracoesserasaanotacoescompletas_N");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoesserasaanotacoescompletas_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracoesSerasaConsultaDetalhada_N" )]
      [  XmlElement( ElementName = "ConfiguracoesSerasaConsultaDetalhada_N"   )]
      public short gxTpr_Configuracoesserasaconsultadetalhada_N
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoesserasaconsultadetalhada_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesserasaconsultadetalhada_N = value;
            SetDirty("Configuracoesserasaconsultadetalhada_N");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoesserasaconsultadetalhada_N_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoesserasaconsultadetalhada_N = 0;
         SetDirty("Configuracoesserasaconsultadetalhada_N");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoesserasaconsultadetalhada_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracoesSerasaParticipacaoSocietaria_N" )]
      [  XmlElement( ElementName = "ConfiguracoesSerasaParticipacaoSocietaria_N"   )]
      public short gxTpr_Configuracoesserasaparticipacaosocietaria_N
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoesserasaparticipacaosocietaria_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesserasaparticipacaosocietaria_N = value;
            SetDirty("Configuracoesserasaparticipacaosocietaria_N");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoesserasaparticipacaosocietaria_N_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoesserasaparticipacaosocietaria_N = 0;
         SetDirty("Configuracoesserasaparticipacaosocietaria_N");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoesserasaparticipacaosocietaria_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracoesSerasaRendaEstimada_N" )]
      [  XmlElement( ElementName = "ConfiguracoesSerasaRendaEstimada_N"   )]
      public short gxTpr_Configuracoesserasarendaestimada_N
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoesserasarendaestimada_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesserasarendaestimada_N = value;
            SetDirty("Configuracoesserasarendaestimada_N");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoesserasarendaestimada_N_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoesserasarendaestimada_N = 0;
         SetDirty("Configuracoesserasarendaestimada_N");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoesserasarendaestimada_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracoesSerasaHistoricoPagamento_N" )]
      [  XmlElement( ElementName = "ConfiguracoesSerasaHistoricoPagamento_N"   )]
      public short gxTpr_Configuracoesserasahistoricopagamento_N
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoesserasahistoricopagamento_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoesserasahistoricopagamento_N = value;
            SetDirty("Configuracoesserasahistoricopagamento_N");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoesserasahistoricopagamento_N_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoesserasahistoricopagamento_N = 0;
         SetDirty("Configuracoesserasahistoricopagamento_N");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoesserasahistoricopagamento_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracoesCompraTituloTaxaEfetiva_N" )]
      [  XmlElement( ElementName = "ConfiguracoesCompraTituloTaxaEfetiva_N"   )]
      public short gxTpr_Configuracoescompratitulotaxaefetiva_N
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoescompratitulotaxaefetiva_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoescompratitulotaxaefetiva_N = value;
            SetDirty("Configuracoescompratitulotaxaefetiva_N");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoescompratitulotaxaefetiva_N_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoescompratitulotaxaefetiva_N = 0;
         SetDirty("Configuracoescompratitulotaxaefetiva_N");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoescompratitulotaxaefetiva_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracoesCompraTituloTaxaMora_N" )]
      [  XmlElement( ElementName = "ConfiguracoesCompraTituloTaxaMora_N"   )]
      public short gxTpr_Configuracoescompratitulotaxamora_N
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoescompratitulotaxamora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoescompratitulotaxamora_N = value;
            SetDirty("Configuracoescompratitulotaxamora_N");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoescompratitulotaxamora_N_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoescompratitulotaxamora_N = 0;
         SetDirty("Configuracoescompratitulotaxamora_N");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoescompratitulotaxamora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracoesCompraTituloFator_N" )]
      [  XmlElement( ElementName = "ConfiguracoesCompraTituloFator_N"   )]
      public short gxTpr_Configuracoescompratitulofator_N
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoescompratitulofator_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoescompratitulofator_N = value;
            SetDirty("Configuracoescompratitulofator_N");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoescompratitulofator_N_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoescompratitulofator_N = 0;
         SetDirty("Configuracoescompratitulofator_N");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoescompratitulofator_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracoesCompraTituloTarifaTipo_N" )]
      [  XmlElement( ElementName = "ConfiguracoesCompraTituloTarifaTipo_N"   )]
      public short gxTpr_Configuracoescompratitulotarifatipo_N
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoescompratitulotarifatipo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoescompratitulotarifatipo_N = value;
            SetDirty("Configuracoescompratitulotarifatipo_N");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoescompratitulotarifatipo_N_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoescompratitulotarifatipo_N = 0;
         SetDirty("Configuracoescompratitulotarifatipo_N");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoescompratitulotarifatipo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracoesCompraTituloTarifa_N" )]
      [  XmlElement( ElementName = "ConfiguracoesCompraTituloTarifa_N"   )]
      public short gxTpr_Configuracoescompratitulotarifa_N
      {
         get {
            return gxTv_SdtConfiguracoes_Configuracoescompratitulotarifa_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoes_Configuracoescompratitulotarifa_N = value;
            SetDirty("Configuracoescompratitulotarifa_N");
         }

      }

      public void gxTv_SdtConfiguracoes_Configuracoescompratitulotarifa_N_SetNull( )
      {
         gxTv_SdtConfiguracoes_Configuracoescompratitulotarifa_N = 0;
         SetDirty("Configuracoescompratitulotarifa_N");
         return  ;
      }

      public bool gxTv_SdtConfiguracoes_Configuracoescompratitulotarifa_N_IsNull( )
      {
         return false ;
      }

      [XmlIgnore]
      private static GXTypeInfo _typeProps;
      protected override GXTypeInfo TypeInfo
      {
         get {
            return _typeProps ;
         }

         set {
            _typeProps = value ;
         }

      }

      public void initialize( )
      {
         sdtIsNull = 1;
         gxTv_SdtConfiguracoes_Configuracoesimagemlogin = "";
         gxTv_SdtConfiguracoes_Configuracoesimagemloginnome = "";
         gxTv_SdtConfiguracoes_Configuracoesimagemloginextencao = "";
         gxTv_SdtConfiguracoes_Configuracoesimagemloginnomeinteiro = "";
         gxTv_SdtConfiguracoes_Configuracoesimagemloginbackground = "";
         gxTv_SdtConfiguracoes_Configuracoesimagemheader = "";
         gxTv_SdtConfiguracoes_Configuracoesimagemheadernome = "";
         gxTv_SdtConfiguracoes_Configuracoesimagemheaderextencao = "";
         gxTv_SdtConfiguracoes_Configuracoesimagemheadernomeinteiro = "";
         gxTv_SdtConfiguracoes_Configuracoeslayoutcontratocorpo = "";
         gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriaclinicaemprestimo = "";
         gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriaclinicataxa = "";
         gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriapaciente = "";
         gxTv_SdtConfiguracoes_Configuracoesarquivopfx = "";
         gxTv_SdtConfiguracoes_Configuracaosenhapfx = "";
         gxTv_SdtConfiguracoes_Configuracoescompratitulotarifatipo = "";
         gxTv_SdtConfiguracoes_Mode = "";
         gxTv_SdtConfiguracoes_Configuracoesimagemloginnome_Z = "";
         gxTv_SdtConfiguracoes_Configuracoesimagemloginextencao_Z = "";
         gxTv_SdtConfiguracoes_Configuracoesimagemloginnomeinteiro_Z = "";
         gxTv_SdtConfiguracoes_Configuracoesimagemloginbackground_Z = "";
         gxTv_SdtConfiguracoes_Configuracoesimagemheadernome_Z = "";
         gxTv_SdtConfiguracoes_Configuracoesimagemheaderextencao_Z = "";
         gxTv_SdtConfiguracoes_Configuracoesimagemheadernomeinteiro_Z = "";
         gxTv_SdtConfiguracoes_Configuracaosenhapfx_Z = "";
         gxTv_SdtConfiguracoes_Configuracoescompratitulotarifatipo_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "configuracoes", "GeneXus.Programs.configuracoes_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short sdtIsNull ;
      private short gxTv_SdtConfiguracoes_Configuracoeslayoutproposta ;
      private short gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicaemprestimo ;
      private short gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicataxa ;
      private short gxTv_SdtConfiguracoes_Configlayoutpromissoriapaciente ;
      private short gxTv_SdtConfiguracoes_Configlayoutcontratocompratitulo ;
      private short gxTv_SdtConfiguracoes_Initialized ;
      private short gxTv_SdtConfiguracoes_Configuracoeslayoutproposta_Z ;
      private short gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicaemprestimo_Z ;
      private short gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicataxa_Z ;
      private short gxTv_SdtConfiguracoes_Configlayoutpromissoriapaciente_Z ;
      private short gxTv_SdtConfiguracoes_Configlayoutcontratocompratitulo_Z ;
      private short gxTv_SdtConfiguracoes_Configuracoesimagemlogin_N ;
      private short gxTv_SdtConfiguracoes_Configuracoesimagemloginnome_N ;
      private short gxTv_SdtConfiguracoes_Configuracoesimagemloginextencao_N ;
      private short gxTv_SdtConfiguracoes_Configuracoesimagemloginnomeinteiro_N ;
      private short gxTv_SdtConfiguracoes_Configuracoesimagemlogintamanho_N ;
      private short gxTv_SdtConfiguracoes_Configuracoesimagemloginbackground_N ;
      private short gxTv_SdtConfiguracoes_Configuracoesimagemheader_N ;
      private short gxTv_SdtConfiguracoes_Configuracoesimagemheadernome_N ;
      private short gxTv_SdtConfiguracoes_Configuracoesimagemheaderextencao_N ;
      private short gxTv_SdtConfiguracoes_Configuracoesimagemheadernomeinteiro_N ;
      private short gxTv_SdtConfiguracoes_Configuracoesimagemheadertamanho_N ;
      private short gxTv_SdtConfiguracoes_Configuracoeslayoutproposta_N ;
      private short gxTv_SdtConfiguracoes_Configuracoeslayoutcontratocorpo_N ;
      private short gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicaemprestimo_N ;
      private short gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriaclinicaemprestimo_N ;
      private short gxTv_SdtConfiguracoes_Configlayoutpromissoriaclinicataxa_N ;
      private short gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriaclinicataxa_N ;
      private short gxTv_SdtConfiguracoes_Configlayoutpromissoriapaciente_N ;
      private short gxTv_SdtConfiguracoes_Configlayoutcontratocompratitulo_N ;
      private short gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriapaciente_N ;
      private short gxTv_SdtConfiguracoes_Configuracoesarquivopfx_N ;
      private short gxTv_SdtConfiguracoes_Configuracaosenhapfx_N ;
      private short gxTv_SdtConfiguracoes_Configuracoescategoriatitulo_N ;
      private short gxTv_SdtConfiguracoes_Configuracoesserasaanotacoescompletas_N ;
      private short gxTv_SdtConfiguracoes_Configuracoesserasaconsultadetalhada_N ;
      private short gxTv_SdtConfiguracoes_Configuracoesserasaparticipacaosocietaria_N ;
      private short gxTv_SdtConfiguracoes_Configuracoesserasarendaestimada_N ;
      private short gxTv_SdtConfiguracoes_Configuracoesserasahistoricopagamento_N ;
      private short gxTv_SdtConfiguracoes_Configuracoescompratitulotaxaefetiva_N ;
      private short gxTv_SdtConfiguracoes_Configuracoescompratitulotaxamora_N ;
      private short gxTv_SdtConfiguracoes_Configuracoescompratitulofator_N ;
      private short gxTv_SdtConfiguracoes_Configuracoescompratitulotarifatipo_N ;
      private short gxTv_SdtConfiguracoes_Configuracoescompratitulotarifa_N ;
      private int gxTv_SdtConfiguracoes_Configuracoesid ;
      private int gxTv_SdtConfiguracoes_Configuracoescategoriatitulo ;
      private int gxTv_SdtConfiguracoes_Configuracoesid_Z ;
      private int gxTv_SdtConfiguracoes_Configuracoescategoriatitulo_Z ;
      private decimal gxTv_SdtConfiguracoes_Configuracoesimagemlogintamanho ;
      private decimal gxTv_SdtConfiguracoes_Configuracoesimagemheadertamanho ;
      private decimal gxTv_SdtConfiguracoes_Configuracoescompratitulotaxaefetiva ;
      private decimal gxTv_SdtConfiguracoes_Configuracoescompratitulotaxamora ;
      private decimal gxTv_SdtConfiguracoes_Configuracoescompratitulofator ;
      private decimal gxTv_SdtConfiguracoes_Configuracoescompratitulotarifa ;
      private decimal gxTv_SdtConfiguracoes_Configuracoesimagemlogintamanho_Z ;
      private decimal gxTv_SdtConfiguracoes_Configuracoesimagemheadertamanho_Z ;
      private decimal gxTv_SdtConfiguracoes_Configuracoescompratitulotaxaefetiva_Z ;
      private decimal gxTv_SdtConfiguracoes_Configuracoescompratitulotaxamora_Z ;
      private decimal gxTv_SdtConfiguracoes_Configuracoescompratitulofator_Z ;
      private decimal gxTv_SdtConfiguracoes_Configuracoescompratitulotarifa_Z ;
      private string gxTv_SdtConfiguracoes_Mode ;
      private bool gxTv_SdtConfiguracoes_Configuracoesserasaanotacoescompletas ;
      private bool gxTv_SdtConfiguracoes_Configuracoesserasaconsultadetalhada ;
      private bool gxTv_SdtConfiguracoes_Configuracoesserasaparticipacaosocietaria ;
      private bool gxTv_SdtConfiguracoes_Configuracoesserasarendaestimada ;
      private bool gxTv_SdtConfiguracoes_Configuracoesserasahistoricopagamento ;
      private bool gxTv_SdtConfiguracoes_Configuracoesserasaanotacoescompletas_Z ;
      private bool gxTv_SdtConfiguracoes_Configuracoesserasaconsultadetalhada_Z ;
      private bool gxTv_SdtConfiguracoes_Configuracoesserasaparticipacaosocietaria_Z ;
      private bool gxTv_SdtConfiguracoes_Configuracoesserasarendaestimada_Z ;
      private bool gxTv_SdtConfiguracoes_Configuracoesserasahistoricopagamento_Z ;
      private string gxTv_SdtConfiguracoes_Configuracoeslayoutcontratocorpo ;
      private string gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriaclinicaemprestimo ;
      private string gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriaclinicataxa ;
      private string gxTv_SdtConfiguracoes_Configlayoutcorpopromissoriapaciente ;
      private string gxTv_SdtConfiguracoes_Configuracoesimagemloginnome ;
      private string gxTv_SdtConfiguracoes_Configuracoesimagemloginextencao ;
      private string gxTv_SdtConfiguracoes_Configuracoesimagemloginnomeinteiro ;
      private string gxTv_SdtConfiguracoes_Configuracoesimagemloginbackground ;
      private string gxTv_SdtConfiguracoes_Configuracoesimagemheadernome ;
      private string gxTv_SdtConfiguracoes_Configuracoesimagemheaderextencao ;
      private string gxTv_SdtConfiguracoes_Configuracoesimagemheadernomeinteiro ;
      private string gxTv_SdtConfiguracoes_Configuracaosenhapfx ;
      private string gxTv_SdtConfiguracoes_Configuracoescompratitulotarifatipo ;
      private string gxTv_SdtConfiguracoes_Configuracoesimagemloginnome_Z ;
      private string gxTv_SdtConfiguracoes_Configuracoesimagemloginextencao_Z ;
      private string gxTv_SdtConfiguracoes_Configuracoesimagemloginnomeinteiro_Z ;
      private string gxTv_SdtConfiguracoes_Configuracoesimagemloginbackground_Z ;
      private string gxTv_SdtConfiguracoes_Configuracoesimagemheadernome_Z ;
      private string gxTv_SdtConfiguracoes_Configuracoesimagemheaderextencao_Z ;
      private string gxTv_SdtConfiguracoes_Configuracoesimagemheadernomeinteiro_Z ;
      private string gxTv_SdtConfiguracoes_Configuracaosenhapfx_Z ;
      private string gxTv_SdtConfiguracoes_Configuracoescompratitulotarifatipo_Z ;
      private string gxTv_SdtConfiguracoes_Configuracoesimagemlogin ;
      private string gxTv_SdtConfiguracoes_Configuracoesimagemheader ;
      private string gxTv_SdtConfiguracoes_Configuracoesarquivopfx ;
   }

   [DataContract(Name = @"Configuracoes", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtConfiguracoes_RESTInterface : GxGenericCollectionItem<SdtConfiguracoes>
   {
      public SdtConfiguracoes_RESTInterface( ) : base()
      {
      }

      public SdtConfiguracoes_RESTInterface( SdtConfiguracoes psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ConfiguracoesId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Configuracoesid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Configuracoesid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Configuracoesid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ConfiguracoesImagemLogin" , Order = 1 )]
      [GxUpload()]
      public string gxTpr_Configuracoesimagemlogin
      {
         get {
            return PathUtil.RelativeURL( sdt.gxTpr_Configuracoesimagemlogin) ;
         }

         set {
            sdt.gxTpr_Configuracoesimagemlogin = value;
         }

      }

      [DataMember( Name = "ConfiguracoesImagemLoginNome" , Order = 2 )]
      public string gxTpr_Configuracoesimagemloginnome
      {
         get {
            return sdt.gxTpr_Configuracoesimagemloginnome ;
         }

         set {
            sdt.gxTpr_Configuracoesimagemloginnome = value;
         }

      }

      [DataMember( Name = "ConfiguracoesImagemLoginExtencao" , Order = 3 )]
      public string gxTpr_Configuracoesimagemloginextencao
      {
         get {
            return sdt.gxTpr_Configuracoesimagemloginextencao ;
         }

         set {
            sdt.gxTpr_Configuracoesimagemloginextencao = value;
         }

      }

      [DataMember( Name = "ConfiguracoesImagemLoginNomeInteiro" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Configuracoesimagemloginnomeinteiro
      {
         get {
            return sdt.gxTpr_Configuracoesimagemloginnomeinteiro ;
         }

         set {
            sdt.gxTpr_Configuracoesimagemloginnomeinteiro = value;
         }

      }

      [DataMember( Name = "ConfiguracoesImagemLoginTamanho" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Configuracoesimagemlogintamanho
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Configuracoesimagemlogintamanho, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Configuracoesimagemlogintamanho = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "ConfiguracoesImagemLoginBackground" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Configuracoesimagemloginbackground
      {
         get {
            return sdt.gxTpr_Configuracoesimagemloginbackground ;
         }

         set {
            sdt.gxTpr_Configuracoesimagemloginbackground = value;
         }

      }

      [DataMember( Name = "ConfiguracoesImagemHeader" , Order = 7 )]
      [GxUpload()]
      public string gxTpr_Configuracoesimagemheader
      {
         get {
            return PathUtil.RelativeURL( sdt.gxTpr_Configuracoesimagemheader) ;
         }

         set {
            sdt.gxTpr_Configuracoesimagemheader = value;
         }

      }

      [DataMember( Name = "ConfiguracoesImagemHeaderNome" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Configuracoesimagemheadernome
      {
         get {
            return sdt.gxTpr_Configuracoesimagemheadernome ;
         }

         set {
            sdt.gxTpr_Configuracoesimagemheadernome = value;
         }

      }

      [DataMember( Name = "ConfiguracoesImagemHeaderExtencao" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Configuracoesimagemheaderextencao
      {
         get {
            return sdt.gxTpr_Configuracoesimagemheaderextencao ;
         }

         set {
            sdt.gxTpr_Configuracoesimagemheaderextencao = value;
         }

      }

      [DataMember( Name = "ConfiguracoesImagemHeaderNomeInteiro" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Configuracoesimagemheadernomeinteiro
      {
         get {
            return sdt.gxTpr_Configuracoesimagemheadernomeinteiro ;
         }

         set {
            sdt.gxTpr_Configuracoesimagemheadernomeinteiro = value;
         }

      }

      [DataMember( Name = "ConfiguracoesImagemHeaderTamanho" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Configuracoesimagemheadertamanho
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Configuracoesimagemheadertamanho, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Configuracoesimagemheadertamanho = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "ConfiguracoesLayoutProposta" , Order = 12 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Configuracoeslayoutproposta
      {
         get {
            return sdt.gxTpr_Configuracoeslayoutproposta ;
         }

         set {
            sdt.gxTpr_Configuracoeslayoutproposta = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ConfiguracoesLayoutContratoCorpo" , Order = 13 )]
      public string gxTpr_Configuracoeslayoutcontratocorpo
      {
         get {
            return sdt.gxTpr_Configuracoeslayoutcontratocorpo ;
         }

         set {
            sdt.gxTpr_Configuracoeslayoutcontratocorpo = value;
         }

      }

      [DataMember( Name = "ConfigLayoutPromissoriaClinicaEmprestimo" , Order = 14 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Configlayoutpromissoriaclinicaemprestimo
      {
         get {
            return sdt.gxTpr_Configlayoutpromissoriaclinicaemprestimo ;
         }

         set {
            sdt.gxTpr_Configlayoutpromissoriaclinicaemprestimo = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ConfigLayoutCorpoPromissoriaClinicaEmprestimo" , Order = 15 )]
      public string gxTpr_Configlayoutcorpopromissoriaclinicaemprestimo
      {
         get {
            return sdt.gxTpr_Configlayoutcorpopromissoriaclinicaemprestimo ;
         }

         set {
            sdt.gxTpr_Configlayoutcorpopromissoriaclinicaemprestimo = value;
         }

      }

      [DataMember( Name = "ConfigLayoutPromissoriaClinicaTaxa" , Order = 16 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Configlayoutpromissoriaclinicataxa
      {
         get {
            return sdt.gxTpr_Configlayoutpromissoriaclinicataxa ;
         }

         set {
            sdt.gxTpr_Configlayoutpromissoriaclinicataxa = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ConfigLayoutCorpoPromissoriaClinicaTaxa" , Order = 17 )]
      public string gxTpr_Configlayoutcorpopromissoriaclinicataxa
      {
         get {
            return sdt.gxTpr_Configlayoutcorpopromissoriaclinicataxa ;
         }

         set {
            sdt.gxTpr_Configlayoutcorpopromissoriaclinicataxa = value;
         }

      }

      [DataMember( Name = "ConfigLayoutPromissoriaPaciente" , Order = 18 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Configlayoutpromissoriapaciente
      {
         get {
            return sdt.gxTpr_Configlayoutpromissoriapaciente ;
         }

         set {
            sdt.gxTpr_Configlayoutpromissoriapaciente = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ConfigLayoutContratoCompraTitulo" , Order = 19 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Configlayoutcontratocompratitulo
      {
         get {
            return sdt.gxTpr_Configlayoutcontratocompratitulo ;
         }

         set {
            sdt.gxTpr_Configlayoutcontratocompratitulo = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ConfigLayoutCorpoPromissoriaPaciente" , Order = 20 )]
      public string gxTpr_Configlayoutcorpopromissoriapaciente
      {
         get {
            return sdt.gxTpr_Configlayoutcorpopromissoriapaciente ;
         }

         set {
            sdt.gxTpr_Configlayoutcorpopromissoriapaciente = value;
         }

      }

      [DataMember( Name = "ConfiguracoesArquivoPFX" , Order = 21 )]
      [GxUpload()]
      public string gxTpr_Configuracoesarquivopfx
      {
         get {
            return PathUtil.RelativeURL( sdt.gxTpr_Configuracoesarquivopfx) ;
         }

         set {
            sdt.gxTpr_Configuracoesarquivopfx = value;
         }

      }

      [DataMember( Name = "ConfiguracaoSenhaPFX" , Order = 22 )]
      [GxSeudo()]
      public string gxTpr_Configuracaosenhapfx
      {
         get {
            return sdt.gxTpr_Configuracaosenhapfx ;
         }

         set {
            sdt.gxTpr_Configuracaosenhapfx = value;
         }

      }

      [DataMember( Name = "ConfiguracoesCategoriaTitulo" , Order = 23 )]
      [GxSeudo()]
      public string gxTpr_Configuracoescategoriatitulo
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Configuracoescategoriatitulo), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Configuracoescategoriatitulo = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ConfiguracoesSerasaAnotacoesCompletas" , Order = 24 )]
      [GxSeudo()]
      public bool gxTpr_Configuracoesserasaanotacoescompletas
      {
         get {
            return sdt.gxTpr_Configuracoesserasaanotacoescompletas ;
         }

         set {
            sdt.gxTpr_Configuracoesserasaanotacoescompletas = value;
         }

      }

      [DataMember( Name = "ConfiguracoesSerasaConsultaDetalhada" , Order = 25 )]
      [GxSeudo()]
      public bool gxTpr_Configuracoesserasaconsultadetalhada
      {
         get {
            return sdt.gxTpr_Configuracoesserasaconsultadetalhada ;
         }

         set {
            sdt.gxTpr_Configuracoesserasaconsultadetalhada = value;
         }

      }

      [DataMember( Name = "ConfiguracoesSerasaParticipacaoSocietaria" , Order = 26 )]
      [GxSeudo()]
      public bool gxTpr_Configuracoesserasaparticipacaosocietaria
      {
         get {
            return sdt.gxTpr_Configuracoesserasaparticipacaosocietaria ;
         }

         set {
            sdt.gxTpr_Configuracoesserasaparticipacaosocietaria = value;
         }

      }

      [DataMember( Name = "ConfiguracoesSerasaRendaEstimada" , Order = 27 )]
      [GxSeudo()]
      public bool gxTpr_Configuracoesserasarendaestimada
      {
         get {
            return sdt.gxTpr_Configuracoesserasarendaestimada ;
         }

         set {
            sdt.gxTpr_Configuracoesserasarendaestimada = value;
         }

      }

      [DataMember( Name = "ConfiguracoesSerasaHistoricoPagamento" , Order = 28 )]
      [GxSeudo()]
      public bool gxTpr_Configuracoesserasahistoricopagamento
      {
         get {
            return sdt.gxTpr_Configuracoesserasahistoricopagamento ;
         }

         set {
            sdt.gxTpr_Configuracoesserasahistoricopagamento = value;
         }

      }

      [DataMember( Name = "ConfiguracoesCompraTituloTaxaEfetiva" , Order = 29 )]
      [GxSeudo()]
      public string gxTpr_Configuracoescompratitulotaxaefetiva
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Configuracoescompratitulotaxaefetiva, 16, 4)) ;
         }

         set {
            sdt.gxTpr_Configuracoescompratitulotaxaefetiva = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "ConfiguracoesCompraTituloTaxaMora" , Order = 30 )]
      [GxSeudo()]
      public string gxTpr_Configuracoescompratitulotaxamora
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Configuracoescompratitulotaxamora, 16, 4)) ;
         }

         set {
            sdt.gxTpr_Configuracoescompratitulotaxamora = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "ConfiguracoesCompraTituloFator" , Order = 31 )]
      [GxSeudo()]
      public string gxTpr_Configuracoescompratitulofator
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Configuracoescompratitulofator, 16, 4)) ;
         }

         set {
            sdt.gxTpr_Configuracoescompratitulofator = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "ConfiguracoesCompraTituloTarifaTipo" , Order = 32 )]
      [GxSeudo()]
      public string gxTpr_Configuracoescompratitulotarifatipo
      {
         get {
            return sdt.gxTpr_Configuracoescompratitulotarifatipo ;
         }

         set {
            sdt.gxTpr_Configuracoescompratitulotarifatipo = value;
         }

      }

      [DataMember( Name = "ConfiguracoesCompraTituloTarifa" , Order = 33 )]
      [GxSeudo()]
      public string gxTpr_Configuracoescompratitulotarifa
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Configuracoescompratitulotarifa, 15, 2)) ;
         }

         set {
            sdt.gxTpr_Configuracoescompratitulotarifa = NumberUtil.Val( value, ".");
         }

      }

      public SdtConfiguracoes sdt
      {
         get {
            return (SdtConfiguracoes)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtConfiguracoes() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 34 )]
      public string Hash
      {
         get {
            if ( StringUtil.StrCmp(md5Hash, null) == 0 )
            {
               md5Hash = (string)(getHash());
            }
            return md5Hash ;
         }

         set {
            md5Hash = value ;
         }

      }

      private string md5Hash ;
   }

   [DataContract(Name = @"Configuracoes", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtConfiguracoes_RESTLInterface : GxGenericCollectionItem<SdtConfiguracoes>
   {
      public SdtConfiguracoes_RESTLInterface( ) : base()
      {
      }

      public SdtConfiguracoes_RESTLInterface( SdtConfiguracoes psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ConfiguracoesImagemLoginNome" , Order = 0 )]
      public string gxTpr_Configuracoesimagemloginnome
      {
         get {
            return sdt.gxTpr_Configuracoesimagemloginnome ;
         }

         set {
            sdt.gxTpr_Configuracoesimagemloginnome = value;
         }

      }

      [DataMember( Name = "uri" , Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtConfiguracoes sdt
      {
         get {
            return (SdtConfiguracoes)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtConfiguracoes() ;
         }
      }

   }

}
