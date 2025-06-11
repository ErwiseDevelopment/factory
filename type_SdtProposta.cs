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
   [XmlRoot(ElementName = "Proposta" )]
   [XmlType(TypeName =  "Proposta" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtProposta : GxSilentTrnSdt
   {
      public SdtProposta( )
      {
      }

      public SdtProposta( IGxContext context )
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

      public void Load( int AV323PropostaId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV323PropostaId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"PropostaId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Proposta");
         metadata.Set("BT", "Proposta");
         metadata.Set("PK", "[ \"PropostaId\" ]");
         metadata.Set("PKAssigned", "[ \"PropostaId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"ClienteId\" ],\"FKMap\":[ \"PropostaClinicaId-ClienteId\" ] },{ \"FK\":[ \"ClienteId\" ],\"FKMap\":[ \"PropostaEmpresaClienteId-ClienteId\" ] },{ \"FK\":[ \"ClienteId\" ],\"FKMap\":[ \"PropostaPacienteClienteId-ClienteId\" ] },{ \"FK\":[ \"ClienteId\" ],\"FKMap\":[ \"PropostaResponsavelId-ClienteId\" ] },{ \"FK\":[ \"ContratoId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"ConvenioCategoriaId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"ProcedimentosMedicosId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"SecUserId\" ],\"FKMap\":[ \"PropostaCratedBy-SecUserId\" ] } ]");
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
         state.Add("gxTpr_Propostaid_Z");
         state.Add("gxTpr_Propostamaxreembolsoid_f_Z");
         state.Add("gxTpr_Propostaprotocolo_Z");
         state.Add("gxTpr_Propostaempresaclienteid_Z");
         state.Add("gxTpr_Propostatipoproposta_Z");
         state.Add("gxTpr_Propostapacienteclienteid_Z");
         state.Add("gxTpr_Propostaqtditensnota_f_Z");
         state.Add("gxTpr_Propostaresponsavelid_Z");
         state.Add("gxTpr_Propostaresponsaveldocumento_Z");
         state.Add("gxTpr_Propostaresponsavelrazaosocial_Z");
         state.Add("gxTpr_Propostaresponsavelemail_Z");
         state.Add("gxTpr_Propostaresponsavelbanco_Z");
         state.Add("gxTpr_Propostaresponsavelconta_Z");
         state.Add("gxTpr_Propostaresponsavelagencia_Z");
         state.Add("gxTpr_Propostaresponsaveltipopix_Z");
         state.Add("gxTpr_Propostaresponsavelpix_Z");
         state.Add("gxTpr_Propostaresponsaveldepositotipo_Z");
         state.Add("gxTpr_Propostaresponsavelserasaconsultas_f_Z");
         state.Add("gxTpr_Propostaresponsavelserasascoreultimadata_f_Z");
         state.Add("gxTpr_Propostaresponsavelserasaultimovalorrecomendado_f_Z");
         state.Add("gxTpr_Propostapacienteclienterazaosocial_Z");
         state.Add("gxTpr_Propostapacienteclientedocumento_Z");
         state.Add("gxTpr_Propostapacientecontatoemail_Z");
         state.Add("gxTpr_Propostapacientebanco_Z");
         state.Add("gxTpr_Propostapacienteconta_Z");
         state.Add("gxTpr_Propostapacienteagencia_Z");
         state.Add("gxTpr_Propostapacientetipopix_Z");
         state.Add("gxTpr_Propostapacientepix_Z");
         state.Add("gxTpr_Propostapacientedepositotipo_Z");
         state.Add("gxTpr_Propostapacienteenderecocep_Z");
         state.Add("gxTpr_Propostapacienteenderecologradouro_Z");
         state.Add("gxTpr_Propostapacienteendereconumero_Z");
         state.Add("gxTpr_Propostapacienteenderecocomplemento_Z");
         state.Add("gxTpr_Propostapacienteenderecobairro_Z");
         state.Add("gxTpr_Propostapacientemunicipiocodigo_Z");
         state.Add("gxTpr_Propostapacienteserasaconsultas_f_Z");
         state.Add("gxTpr_Propostaserasascoreultimadata_f_Z");
         state.Add("gxTpr_Propostapacienteserasaultimovalorrecomendado_f_Z");
         state.Add("gxTpr_Propostavalortaxaclinica_f_Z");
         state.Add("gxTpr_Propostaqtddocumentopendente_f_Z");
         state.Add("gxTpr_Propostamaiorscore_f_Z");
         state.Add("gxTpr_Propostamaiorvalorrecomendado_Z");
         state.Add("gxTpr_Propostatitulo_Z");
         state.Add("gxTpr_Procedimentosmedicosid_Z");
         state.Add("gxTpr_Propostadescricao_Z");
         state.Add("gxTpr_Propostadatacirurgia_Z_Nullable");
         state.Add("gxTpr_Propostavalor_Z");
         state.Add("gxTpr_Propostavalorliquido_Z");
         state.Add("gxTpr_Propostataxaadministrativa_Z");
         state.Add("gxTpr_Propostataxa_f_Z");
         state.Add("gxTpr_Propostasla_Z");
         state.Add("gxTpr_Propostajurosmora_Z");
         state.Add("gxTpr_Propostacreatedat_Z_Nullable");
         state.Add("gxTpr_Propostacratedby_Z");
         state.Add("gxTpr_Propostaclinicaid_Z");
         state.Add("gxTpr_Propostaclinicanome_Z");
         state.Add("gxTpr_Propostaclinicanomefantasia_Z");
         state.Add("gxTpr_Propostaclinicadocumento_Z");
         state.Add("gxTpr_Propostaclinicaemail_Z");
         state.Add("gxTpr_Propostasecusername_Z");
         state.Add("gxTpr_Propostastatus_Z");
         state.Add("gxTpr_Propostacomentarioanalise_Z");
         state.Add("gxTpr_Propostaquantidadeaprovadores_Z");
         state.Add("gxTpr_Propostareprovacoespermitidas_Z");
         state.Add("gxTpr_Contratoid_Z");
         state.Add("gxTpr_Contratonome_Z");
         state.Add("gxTpr_Convenioid_Z");
         state.Add("gxTpr_Conveniovencimentoano_Z");
         state.Add("gxTpr_Conveniovencimentomes_Z");
         state.Add("gxTpr_Conveniocategoriaid_Z");
         state.Add("gxTpr_Conveniocategoriadescricao_Z");
         state.Add("gxTpr_Propostadatacreditocliente_f_Z_Nullable");
         state.Add("gxTpr_Propostavalortaxa_f_Z");
         state.Add("gxTpr_Propostavalorjurosmora_f_Z");
         state.Add("gxTpr_Propostavalorreembolsado_f_Z");
         state.Add("gxTpr_Propostavalorreembolsadojuros_f_Z");
         state.Add("gxTpr_Propostavalortaxarecebida_f_Z");
         state.Add("gxTpr_Propostaaprovacoes_f_Z");
         state.Add("gxTpr_Propostareprovacoes_f_Z");
         state.Add("gxTpr_Propostaaprovacoesrestantes_f_Z");
         state.Add("gxTpr_Propostaid_N");
         state.Add("gxTpr_Propostamaxreembolsoid_f_N");
         state.Add("gxTpr_Propostaprotocolo_N");
         state.Add("gxTpr_Propostaempresaclienteid_N");
         state.Add("gxTpr_Propostatipoproposta_N");
         state.Add("gxTpr_Propostapacienteclienteid_N");
         state.Add("gxTpr_Propostaqtditensnota_f_N");
         state.Add("gxTpr_Propostaresponsavelid_N");
         state.Add("gxTpr_Propostaresponsaveldocumento_N");
         state.Add("gxTpr_Propostaresponsavelrazaosocial_N");
         state.Add("gxTpr_Propostaresponsavelemail_N");
         state.Add("gxTpr_Propostaresponsavelconta_N");
         state.Add("gxTpr_Propostaresponsavelagencia_N");
         state.Add("gxTpr_Propostaresponsaveltipopix_N");
         state.Add("gxTpr_Propostaresponsavelpix_N");
         state.Add("gxTpr_Propostaresponsaveldepositotipo_N");
         state.Add("gxTpr_Propostaresponsavelserasaconsultas_f_N");
         state.Add("gxTpr_Propostaresponsavelserasascoreultimadata_f_N");
         state.Add("gxTpr_Propostaresponsavelserasaultimovalorrecomendado_f_N");
         state.Add("gxTpr_Propostapacienteclienterazaosocial_N");
         state.Add("gxTpr_Propostapacienteclientedocumento_N");
         state.Add("gxTpr_Propostapacientecontatoemail_N");
         state.Add("gxTpr_Propostapacienteconta_N");
         state.Add("gxTpr_Propostapacienteagencia_N");
         state.Add("gxTpr_Propostapacientetipopix_N");
         state.Add("gxTpr_Propostapacientepix_N");
         state.Add("gxTpr_Propostapacientedepositotipo_N");
         state.Add("gxTpr_Propostapacienteenderecocep_N");
         state.Add("gxTpr_Propostapacienteenderecologradouro_N");
         state.Add("gxTpr_Propostapacienteendereconumero_N");
         state.Add("gxTpr_Propostapacienteenderecocomplemento_N");
         state.Add("gxTpr_Propostapacienteenderecobairro_N");
         state.Add("gxTpr_Propostapacientemunicipiocodigo_N");
         state.Add("gxTpr_Propostapacienteserasaconsultas_f_N");
         state.Add("gxTpr_Propostaserasascoreultimadata_f_N");
         state.Add("gxTpr_Propostapacienteserasaultimovalorrecomendado_f_N");
         state.Add("gxTpr_Propostavalortaxaclinica_f_N");
         state.Add("gxTpr_Propostaqtddocumentopendente_f_N");
         state.Add("gxTpr_Propostatitulo_N");
         state.Add("gxTpr_Procedimentosmedicosid_N");
         state.Add("gxTpr_Propostadescricao_N");
         state.Add("gxTpr_Propostadatacirurgia_N");
         state.Add("gxTpr_Propostavalor_N");
         state.Add("gxTpr_Propostavalorliquido_N");
         state.Add("gxTpr_Propostataxaadministrativa_N");
         state.Add("gxTpr_Propostasla_N");
         state.Add("gxTpr_Propostajurosmora_N");
         state.Add("gxTpr_Propostacreatedat_N");
         state.Add("gxTpr_Propostacratedby_N");
         state.Add("gxTpr_Propostaclinicaid_N");
         state.Add("gxTpr_Propostaclinicanome_N");
         state.Add("gxTpr_Propostaclinicanomefantasia_N");
         state.Add("gxTpr_Propostaclinicadocumento_N");
         state.Add("gxTpr_Propostaclinicaemail_N");
         state.Add("gxTpr_Propostasecusername_N");
         state.Add("gxTpr_Propostastatus_N");
         state.Add("gxTpr_Propostacomentarioanalise_N");
         state.Add("gxTpr_Propostaquantidadeaprovadores_N");
         state.Add("gxTpr_Propostareprovacoespermitidas_N");
         state.Add("gxTpr_Contratoid_N");
         state.Add("gxTpr_Contratonome_N");
         state.Add("gxTpr_Convenioid_N");
         state.Add("gxTpr_Conveniovencimentoano_N");
         state.Add("gxTpr_Conveniovencimentomes_N");
         state.Add("gxTpr_Conveniocategoriaid_N");
         state.Add("gxTpr_Conveniocategoriadescricao_N");
         state.Add("gxTpr_Propostadatacreditocliente_f_N");
         state.Add("gxTpr_Propostavalorreembolsado_f_N");
         state.Add("gxTpr_Propostavalorreembolsadojuros_f_N");
         state.Add("gxTpr_Propostavalortaxarecebida_f_N");
         state.Add("gxTpr_Propostaaprovacoes_f_N");
         state.Add("gxTpr_Propostareprovacoes_f_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtProposta sdt;
         sdt = (SdtProposta)(source);
         gxTv_SdtProposta_Propostaid = sdt.gxTv_SdtProposta_Propostaid ;
         gxTv_SdtProposta_Propostamaxreembolsoid_f = sdt.gxTv_SdtProposta_Propostamaxreembolsoid_f ;
         gxTv_SdtProposta_Propostaprotocolo = sdt.gxTv_SdtProposta_Propostaprotocolo ;
         gxTv_SdtProposta_Propostaempresaclienteid = sdt.gxTv_SdtProposta_Propostaempresaclienteid ;
         gxTv_SdtProposta_Propostatipoproposta = sdt.gxTv_SdtProposta_Propostatipoproposta ;
         gxTv_SdtProposta_Propostapacienteclienteid = sdt.gxTv_SdtProposta_Propostapacienteclienteid ;
         gxTv_SdtProposta_Propostaqtditensnota_f = sdt.gxTv_SdtProposta_Propostaqtditensnota_f ;
         gxTv_SdtProposta_Propostaresponsavelid = sdt.gxTv_SdtProposta_Propostaresponsavelid ;
         gxTv_SdtProposta_Propostaresponsaveldocumento = sdt.gxTv_SdtProposta_Propostaresponsaveldocumento ;
         gxTv_SdtProposta_Propostaresponsavelrazaosocial = sdt.gxTv_SdtProposta_Propostaresponsavelrazaosocial ;
         gxTv_SdtProposta_Propostaresponsavelemail = sdt.gxTv_SdtProposta_Propostaresponsavelemail ;
         gxTv_SdtProposta_Propostaresponsavelbanco = sdt.gxTv_SdtProposta_Propostaresponsavelbanco ;
         gxTv_SdtProposta_Propostaresponsavelconta = sdt.gxTv_SdtProposta_Propostaresponsavelconta ;
         gxTv_SdtProposta_Propostaresponsavelagencia = sdt.gxTv_SdtProposta_Propostaresponsavelagencia ;
         gxTv_SdtProposta_Propostaresponsaveltipopix = sdt.gxTv_SdtProposta_Propostaresponsaveltipopix ;
         gxTv_SdtProposta_Propostaresponsavelpix = sdt.gxTv_SdtProposta_Propostaresponsavelpix ;
         gxTv_SdtProposta_Propostaresponsaveldepositotipo = sdt.gxTv_SdtProposta_Propostaresponsaveldepositotipo ;
         gxTv_SdtProposta_Propostaresponsavelserasaconsultas_f = sdt.gxTv_SdtProposta_Propostaresponsavelserasaconsultas_f ;
         gxTv_SdtProposta_Propostaresponsavelserasascoreultimadata_f = sdt.gxTv_SdtProposta_Propostaresponsavelserasascoreultimadata_f ;
         gxTv_SdtProposta_Propostaresponsavelserasaultimovalorrecomendado_f = sdt.gxTv_SdtProposta_Propostaresponsavelserasaultimovalorrecomendado_f ;
         gxTv_SdtProposta_Propostapacienteclienterazaosocial = sdt.gxTv_SdtProposta_Propostapacienteclienterazaosocial ;
         gxTv_SdtProposta_Propostapacienteclientedocumento = sdt.gxTv_SdtProposta_Propostapacienteclientedocumento ;
         gxTv_SdtProposta_Propostapacientecontatoemail = sdt.gxTv_SdtProposta_Propostapacientecontatoemail ;
         gxTv_SdtProposta_Propostapacientebanco = sdt.gxTv_SdtProposta_Propostapacientebanco ;
         gxTv_SdtProposta_Propostapacienteconta = sdt.gxTv_SdtProposta_Propostapacienteconta ;
         gxTv_SdtProposta_Propostapacienteagencia = sdt.gxTv_SdtProposta_Propostapacienteagencia ;
         gxTv_SdtProposta_Propostapacientetipopix = sdt.gxTv_SdtProposta_Propostapacientetipopix ;
         gxTv_SdtProposta_Propostapacientepix = sdt.gxTv_SdtProposta_Propostapacientepix ;
         gxTv_SdtProposta_Propostapacientedepositotipo = sdt.gxTv_SdtProposta_Propostapacientedepositotipo ;
         gxTv_SdtProposta_Propostapacienteenderecocep = sdt.gxTv_SdtProposta_Propostapacienteenderecocep ;
         gxTv_SdtProposta_Propostapacienteenderecologradouro = sdt.gxTv_SdtProposta_Propostapacienteenderecologradouro ;
         gxTv_SdtProposta_Propostapacienteendereconumero = sdt.gxTv_SdtProposta_Propostapacienteendereconumero ;
         gxTv_SdtProposta_Propostapacienteenderecocomplemento = sdt.gxTv_SdtProposta_Propostapacienteenderecocomplemento ;
         gxTv_SdtProposta_Propostapacienteenderecobairro = sdt.gxTv_SdtProposta_Propostapacienteenderecobairro ;
         gxTv_SdtProposta_Propostapacientemunicipiocodigo = sdt.gxTv_SdtProposta_Propostapacientemunicipiocodigo ;
         gxTv_SdtProposta_Propostapacienteserasaconsultas_f = sdt.gxTv_SdtProposta_Propostapacienteserasaconsultas_f ;
         gxTv_SdtProposta_Propostaserasascoreultimadata_f = sdt.gxTv_SdtProposta_Propostaserasascoreultimadata_f ;
         gxTv_SdtProposta_Propostapacienteserasaultimovalorrecomendado_f = sdt.gxTv_SdtProposta_Propostapacienteserasaultimovalorrecomendado_f ;
         gxTv_SdtProposta_Propostavalortaxaclinica_f = sdt.gxTv_SdtProposta_Propostavalortaxaclinica_f ;
         gxTv_SdtProposta_Propostaqtddocumentopendente_f = sdt.gxTv_SdtProposta_Propostaqtddocumentopendente_f ;
         gxTv_SdtProposta_Propostamaiorscore_f = sdt.gxTv_SdtProposta_Propostamaiorscore_f ;
         gxTv_SdtProposta_Propostamaiorvalorrecomendado = sdt.gxTv_SdtProposta_Propostamaiorvalorrecomendado ;
         gxTv_SdtProposta_Propostatitulo = sdt.gxTv_SdtProposta_Propostatitulo ;
         gxTv_SdtProposta_Procedimentosmedicosid = sdt.gxTv_SdtProposta_Procedimentosmedicosid ;
         gxTv_SdtProposta_Propostadescricao = sdt.gxTv_SdtProposta_Propostadescricao ;
         gxTv_SdtProposta_Propostadatacirurgia = sdt.gxTv_SdtProposta_Propostadatacirurgia ;
         gxTv_SdtProposta_Propostavalor = sdt.gxTv_SdtProposta_Propostavalor ;
         gxTv_SdtProposta_Propostavalorliquido = sdt.gxTv_SdtProposta_Propostavalorliquido ;
         gxTv_SdtProposta_Propostataxaadministrativa = sdt.gxTv_SdtProposta_Propostataxaadministrativa ;
         gxTv_SdtProposta_Propostataxa_f = sdt.gxTv_SdtProposta_Propostataxa_f ;
         gxTv_SdtProposta_Propostasla = sdt.gxTv_SdtProposta_Propostasla ;
         gxTv_SdtProposta_Propostajurosmora = sdt.gxTv_SdtProposta_Propostajurosmora ;
         gxTv_SdtProposta_Propostacreatedat = sdt.gxTv_SdtProposta_Propostacreatedat ;
         gxTv_SdtProposta_Propostacratedby = sdt.gxTv_SdtProposta_Propostacratedby ;
         gxTv_SdtProposta_Propostaclinicaid = sdt.gxTv_SdtProposta_Propostaclinicaid ;
         gxTv_SdtProposta_Propostaclinicanome = sdt.gxTv_SdtProposta_Propostaclinicanome ;
         gxTv_SdtProposta_Propostaclinicanomefantasia = sdt.gxTv_SdtProposta_Propostaclinicanomefantasia ;
         gxTv_SdtProposta_Propostaclinicadocumento = sdt.gxTv_SdtProposta_Propostaclinicadocumento ;
         gxTv_SdtProposta_Propostaclinicaemail = sdt.gxTv_SdtProposta_Propostaclinicaemail ;
         gxTv_SdtProposta_Propostasecusername = sdt.gxTv_SdtProposta_Propostasecusername ;
         gxTv_SdtProposta_Propostastatus = sdt.gxTv_SdtProposta_Propostastatus ;
         gxTv_SdtProposta_Propostacomentarioanalise = sdt.gxTv_SdtProposta_Propostacomentarioanalise ;
         gxTv_SdtProposta_Propostaquantidadeaprovadores = sdt.gxTv_SdtProposta_Propostaquantidadeaprovadores ;
         gxTv_SdtProposta_Propostareprovacoespermitidas = sdt.gxTv_SdtProposta_Propostareprovacoespermitidas ;
         gxTv_SdtProposta_Contratoid = sdt.gxTv_SdtProposta_Contratoid ;
         gxTv_SdtProposta_Contratonome = sdt.gxTv_SdtProposta_Contratonome ;
         gxTv_SdtProposta_Convenioid = sdt.gxTv_SdtProposta_Convenioid ;
         gxTv_SdtProposta_Conveniovencimentoano = sdt.gxTv_SdtProposta_Conveniovencimentoano ;
         gxTv_SdtProposta_Conveniovencimentomes = sdt.gxTv_SdtProposta_Conveniovencimentomes ;
         gxTv_SdtProposta_Conveniocategoriaid = sdt.gxTv_SdtProposta_Conveniocategoriaid ;
         gxTv_SdtProposta_Conveniocategoriadescricao = sdt.gxTv_SdtProposta_Conveniocategoriadescricao ;
         gxTv_SdtProposta_Propostadatacreditocliente_f = sdt.gxTv_SdtProposta_Propostadatacreditocliente_f ;
         gxTv_SdtProposta_Propostavalortaxa_f = sdt.gxTv_SdtProposta_Propostavalortaxa_f ;
         gxTv_SdtProposta_Propostavalorjurosmora_f = sdt.gxTv_SdtProposta_Propostavalorjurosmora_f ;
         gxTv_SdtProposta_Propostavalorreembolsado_f = sdt.gxTv_SdtProposta_Propostavalorreembolsado_f ;
         gxTv_SdtProposta_Propostavalorreembolsadojuros_f = sdt.gxTv_SdtProposta_Propostavalorreembolsadojuros_f ;
         gxTv_SdtProposta_Propostavalortaxarecebida_f = sdt.gxTv_SdtProposta_Propostavalortaxarecebida_f ;
         gxTv_SdtProposta_Propostaaprovacoes_f = sdt.gxTv_SdtProposta_Propostaaprovacoes_f ;
         gxTv_SdtProposta_Propostareprovacoes_f = sdt.gxTv_SdtProposta_Propostareprovacoes_f ;
         gxTv_SdtProposta_Propostaaprovacoesrestantes_f = sdt.gxTv_SdtProposta_Propostaaprovacoesrestantes_f ;
         gxTv_SdtProposta_Mode = sdt.gxTv_SdtProposta_Mode ;
         gxTv_SdtProposta_Initialized = sdt.gxTv_SdtProposta_Initialized ;
         gxTv_SdtProposta_Propostaid_Z = sdt.gxTv_SdtProposta_Propostaid_Z ;
         gxTv_SdtProposta_Propostamaxreembolsoid_f_Z = sdt.gxTv_SdtProposta_Propostamaxreembolsoid_f_Z ;
         gxTv_SdtProposta_Propostaprotocolo_Z = sdt.gxTv_SdtProposta_Propostaprotocolo_Z ;
         gxTv_SdtProposta_Propostaempresaclienteid_Z = sdt.gxTv_SdtProposta_Propostaempresaclienteid_Z ;
         gxTv_SdtProposta_Propostatipoproposta_Z = sdt.gxTv_SdtProposta_Propostatipoproposta_Z ;
         gxTv_SdtProposta_Propostapacienteclienteid_Z = sdt.gxTv_SdtProposta_Propostapacienteclienteid_Z ;
         gxTv_SdtProposta_Propostaqtditensnota_f_Z = sdt.gxTv_SdtProposta_Propostaqtditensnota_f_Z ;
         gxTv_SdtProposta_Propostaresponsavelid_Z = sdt.gxTv_SdtProposta_Propostaresponsavelid_Z ;
         gxTv_SdtProposta_Propostaresponsaveldocumento_Z = sdt.gxTv_SdtProposta_Propostaresponsaveldocumento_Z ;
         gxTv_SdtProposta_Propostaresponsavelrazaosocial_Z = sdt.gxTv_SdtProposta_Propostaresponsavelrazaosocial_Z ;
         gxTv_SdtProposta_Propostaresponsavelemail_Z = sdt.gxTv_SdtProposta_Propostaresponsavelemail_Z ;
         gxTv_SdtProposta_Propostaresponsavelbanco_Z = sdt.gxTv_SdtProposta_Propostaresponsavelbanco_Z ;
         gxTv_SdtProposta_Propostaresponsavelconta_Z = sdt.gxTv_SdtProposta_Propostaresponsavelconta_Z ;
         gxTv_SdtProposta_Propostaresponsavelagencia_Z = sdt.gxTv_SdtProposta_Propostaresponsavelagencia_Z ;
         gxTv_SdtProposta_Propostaresponsaveltipopix_Z = sdt.gxTv_SdtProposta_Propostaresponsaveltipopix_Z ;
         gxTv_SdtProposta_Propostaresponsavelpix_Z = sdt.gxTv_SdtProposta_Propostaresponsavelpix_Z ;
         gxTv_SdtProposta_Propostaresponsaveldepositotipo_Z = sdt.gxTv_SdtProposta_Propostaresponsaveldepositotipo_Z ;
         gxTv_SdtProposta_Propostaresponsavelserasaconsultas_f_Z = sdt.gxTv_SdtProposta_Propostaresponsavelserasaconsultas_f_Z ;
         gxTv_SdtProposta_Propostaresponsavelserasascoreultimadata_f_Z = sdt.gxTv_SdtProposta_Propostaresponsavelserasascoreultimadata_f_Z ;
         gxTv_SdtProposta_Propostaresponsavelserasaultimovalorrecomendado_f_Z = sdt.gxTv_SdtProposta_Propostaresponsavelserasaultimovalorrecomendado_f_Z ;
         gxTv_SdtProposta_Propostapacienteclienterazaosocial_Z = sdt.gxTv_SdtProposta_Propostapacienteclienterazaosocial_Z ;
         gxTv_SdtProposta_Propostapacienteclientedocumento_Z = sdt.gxTv_SdtProposta_Propostapacienteclientedocumento_Z ;
         gxTv_SdtProposta_Propostapacientecontatoemail_Z = sdt.gxTv_SdtProposta_Propostapacientecontatoemail_Z ;
         gxTv_SdtProposta_Propostapacientebanco_Z = sdt.gxTv_SdtProposta_Propostapacientebanco_Z ;
         gxTv_SdtProposta_Propostapacienteconta_Z = sdt.gxTv_SdtProposta_Propostapacienteconta_Z ;
         gxTv_SdtProposta_Propostapacienteagencia_Z = sdt.gxTv_SdtProposta_Propostapacienteagencia_Z ;
         gxTv_SdtProposta_Propostapacientetipopix_Z = sdt.gxTv_SdtProposta_Propostapacientetipopix_Z ;
         gxTv_SdtProposta_Propostapacientepix_Z = sdt.gxTv_SdtProposta_Propostapacientepix_Z ;
         gxTv_SdtProposta_Propostapacientedepositotipo_Z = sdt.gxTv_SdtProposta_Propostapacientedepositotipo_Z ;
         gxTv_SdtProposta_Propostapacienteenderecocep_Z = sdt.gxTv_SdtProposta_Propostapacienteenderecocep_Z ;
         gxTv_SdtProposta_Propostapacienteenderecologradouro_Z = sdt.gxTv_SdtProposta_Propostapacienteenderecologradouro_Z ;
         gxTv_SdtProposta_Propostapacienteendereconumero_Z = sdt.gxTv_SdtProposta_Propostapacienteendereconumero_Z ;
         gxTv_SdtProposta_Propostapacienteenderecocomplemento_Z = sdt.gxTv_SdtProposta_Propostapacienteenderecocomplemento_Z ;
         gxTv_SdtProposta_Propostapacienteenderecobairro_Z = sdt.gxTv_SdtProposta_Propostapacienteenderecobairro_Z ;
         gxTv_SdtProposta_Propostapacientemunicipiocodigo_Z = sdt.gxTv_SdtProposta_Propostapacientemunicipiocodigo_Z ;
         gxTv_SdtProposta_Propostapacienteserasaconsultas_f_Z = sdt.gxTv_SdtProposta_Propostapacienteserasaconsultas_f_Z ;
         gxTv_SdtProposta_Propostaserasascoreultimadata_f_Z = sdt.gxTv_SdtProposta_Propostaserasascoreultimadata_f_Z ;
         gxTv_SdtProposta_Propostapacienteserasaultimovalorrecomendado_f_Z = sdt.gxTv_SdtProposta_Propostapacienteserasaultimovalorrecomendado_f_Z ;
         gxTv_SdtProposta_Propostavalortaxaclinica_f_Z = sdt.gxTv_SdtProposta_Propostavalortaxaclinica_f_Z ;
         gxTv_SdtProposta_Propostaqtddocumentopendente_f_Z = sdt.gxTv_SdtProposta_Propostaqtddocumentopendente_f_Z ;
         gxTv_SdtProposta_Propostamaiorscore_f_Z = sdt.gxTv_SdtProposta_Propostamaiorscore_f_Z ;
         gxTv_SdtProposta_Propostamaiorvalorrecomendado_Z = sdt.gxTv_SdtProposta_Propostamaiorvalorrecomendado_Z ;
         gxTv_SdtProposta_Propostatitulo_Z = sdt.gxTv_SdtProposta_Propostatitulo_Z ;
         gxTv_SdtProposta_Procedimentosmedicosid_Z = sdt.gxTv_SdtProposta_Procedimentosmedicosid_Z ;
         gxTv_SdtProposta_Propostadescricao_Z = sdt.gxTv_SdtProposta_Propostadescricao_Z ;
         gxTv_SdtProposta_Propostadatacirurgia_Z = sdt.gxTv_SdtProposta_Propostadatacirurgia_Z ;
         gxTv_SdtProposta_Propostavalor_Z = sdt.gxTv_SdtProposta_Propostavalor_Z ;
         gxTv_SdtProposta_Propostavalorliquido_Z = sdt.gxTv_SdtProposta_Propostavalorliquido_Z ;
         gxTv_SdtProposta_Propostataxaadministrativa_Z = sdt.gxTv_SdtProposta_Propostataxaadministrativa_Z ;
         gxTv_SdtProposta_Propostataxa_f_Z = sdt.gxTv_SdtProposta_Propostataxa_f_Z ;
         gxTv_SdtProposta_Propostasla_Z = sdt.gxTv_SdtProposta_Propostasla_Z ;
         gxTv_SdtProposta_Propostajurosmora_Z = sdt.gxTv_SdtProposta_Propostajurosmora_Z ;
         gxTv_SdtProposta_Propostacreatedat_Z = sdt.gxTv_SdtProposta_Propostacreatedat_Z ;
         gxTv_SdtProposta_Propostacratedby_Z = sdt.gxTv_SdtProposta_Propostacratedby_Z ;
         gxTv_SdtProposta_Propostaclinicaid_Z = sdt.gxTv_SdtProposta_Propostaclinicaid_Z ;
         gxTv_SdtProposta_Propostaclinicanome_Z = sdt.gxTv_SdtProposta_Propostaclinicanome_Z ;
         gxTv_SdtProposta_Propostaclinicanomefantasia_Z = sdt.gxTv_SdtProposta_Propostaclinicanomefantasia_Z ;
         gxTv_SdtProposta_Propostaclinicadocumento_Z = sdt.gxTv_SdtProposta_Propostaclinicadocumento_Z ;
         gxTv_SdtProposta_Propostaclinicaemail_Z = sdt.gxTv_SdtProposta_Propostaclinicaemail_Z ;
         gxTv_SdtProposta_Propostasecusername_Z = sdt.gxTv_SdtProposta_Propostasecusername_Z ;
         gxTv_SdtProposta_Propostastatus_Z = sdt.gxTv_SdtProposta_Propostastatus_Z ;
         gxTv_SdtProposta_Propostacomentarioanalise_Z = sdt.gxTv_SdtProposta_Propostacomentarioanalise_Z ;
         gxTv_SdtProposta_Propostaquantidadeaprovadores_Z = sdt.gxTv_SdtProposta_Propostaquantidadeaprovadores_Z ;
         gxTv_SdtProposta_Propostareprovacoespermitidas_Z = sdt.gxTv_SdtProposta_Propostareprovacoespermitidas_Z ;
         gxTv_SdtProposta_Contratoid_Z = sdt.gxTv_SdtProposta_Contratoid_Z ;
         gxTv_SdtProposta_Contratonome_Z = sdt.gxTv_SdtProposta_Contratonome_Z ;
         gxTv_SdtProposta_Convenioid_Z = sdt.gxTv_SdtProposta_Convenioid_Z ;
         gxTv_SdtProposta_Conveniovencimentoano_Z = sdt.gxTv_SdtProposta_Conveniovencimentoano_Z ;
         gxTv_SdtProposta_Conveniovencimentomes_Z = sdt.gxTv_SdtProposta_Conveniovencimentomes_Z ;
         gxTv_SdtProposta_Conveniocategoriaid_Z = sdt.gxTv_SdtProposta_Conveniocategoriaid_Z ;
         gxTv_SdtProposta_Conveniocategoriadescricao_Z = sdt.gxTv_SdtProposta_Conveniocategoriadescricao_Z ;
         gxTv_SdtProposta_Propostadatacreditocliente_f_Z = sdt.gxTv_SdtProposta_Propostadatacreditocliente_f_Z ;
         gxTv_SdtProposta_Propostavalortaxa_f_Z = sdt.gxTv_SdtProposta_Propostavalortaxa_f_Z ;
         gxTv_SdtProposta_Propostavalorjurosmora_f_Z = sdt.gxTv_SdtProposta_Propostavalorjurosmora_f_Z ;
         gxTv_SdtProposta_Propostavalorreembolsado_f_Z = sdt.gxTv_SdtProposta_Propostavalorreembolsado_f_Z ;
         gxTv_SdtProposta_Propostavalorreembolsadojuros_f_Z = sdt.gxTv_SdtProposta_Propostavalorreembolsadojuros_f_Z ;
         gxTv_SdtProposta_Propostavalortaxarecebida_f_Z = sdt.gxTv_SdtProposta_Propostavalortaxarecebida_f_Z ;
         gxTv_SdtProposta_Propostaaprovacoes_f_Z = sdt.gxTv_SdtProposta_Propostaaprovacoes_f_Z ;
         gxTv_SdtProposta_Propostareprovacoes_f_Z = sdt.gxTv_SdtProposta_Propostareprovacoes_f_Z ;
         gxTv_SdtProposta_Propostaaprovacoesrestantes_f_Z = sdt.gxTv_SdtProposta_Propostaaprovacoesrestantes_f_Z ;
         gxTv_SdtProposta_Propostaid_N = sdt.gxTv_SdtProposta_Propostaid_N ;
         gxTv_SdtProposta_Propostamaxreembolsoid_f_N = sdt.gxTv_SdtProposta_Propostamaxreembolsoid_f_N ;
         gxTv_SdtProposta_Propostaprotocolo_N = sdt.gxTv_SdtProposta_Propostaprotocolo_N ;
         gxTv_SdtProposta_Propostaempresaclienteid_N = sdt.gxTv_SdtProposta_Propostaempresaclienteid_N ;
         gxTv_SdtProposta_Propostatipoproposta_N = sdt.gxTv_SdtProposta_Propostatipoproposta_N ;
         gxTv_SdtProposta_Propostapacienteclienteid_N = sdt.gxTv_SdtProposta_Propostapacienteclienteid_N ;
         gxTv_SdtProposta_Propostaqtditensnota_f_N = sdt.gxTv_SdtProposta_Propostaqtditensnota_f_N ;
         gxTv_SdtProposta_Propostaresponsavelid_N = sdt.gxTv_SdtProposta_Propostaresponsavelid_N ;
         gxTv_SdtProposta_Propostaresponsaveldocumento_N = sdt.gxTv_SdtProposta_Propostaresponsaveldocumento_N ;
         gxTv_SdtProposta_Propostaresponsavelrazaosocial_N = sdt.gxTv_SdtProposta_Propostaresponsavelrazaosocial_N ;
         gxTv_SdtProposta_Propostaresponsavelemail_N = sdt.gxTv_SdtProposta_Propostaresponsavelemail_N ;
         gxTv_SdtProposta_Propostaresponsavelconta_N = sdt.gxTv_SdtProposta_Propostaresponsavelconta_N ;
         gxTv_SdtProposta_Propostaresponsavelagencia_N = sdt.gxTv_SdtProposta_Propostaresponsavelagencia_N ;
         gxTv_SdtProposta_Propostaresponsaveltipopix_N = sdt.gxTv_SdtProposta_Propostaresponsaveltipopix_N ;
         gxTv_SdtProposta_Propostaresponsavelpix_N = sdt.gxTv_SdtProposta_Propostaresponsavelpix_N ;
         gxTv_SdtProposta_Propostaresponsaveldepositotipo_N = sdt.gxTv_SdtProposta_Propostaresponsaveldepositotipo_N ;
         gxTv_SdtProposta_Propostaresponsavelserasaconsultas_f_N = sdt.gxTv_SdtProposta_Propostaresponsavelserasaconsultas_f_N ;
         gxTv_SdtProposta_Propostaresponsavelserasascoreultimadata_f_N = sdt.gxTv_SdtProposta_Propostaresponsavelserasascoreultimadata_f_N ;
         gxTv_SdtProposta_Propostaresponsavelserasaultimovalorrecomendado_f_N = sdt.gxTv_SdtProposta_Propostaresponsavelserasaultimovalorrecomendado_f_N ;
         gxTv_SdtProposta_Propostapacienteclienterazaosocial_N = sdt.gxTv_SdtProposta_Propostapacienteclienterazaosocial_N ;
         gxTv_SdtProposta_Propostapacienteclientedocumento_N = sdt.gxTv_SdtProposta_Propostapacienteclientedocumento_N ;
         gxTv_SdtProposta_Propostapacientecontatoemail_N = sdt.gxTv_SdtProposta_Propostapacientecontatoemail_N ;
         gxTv_SdtProposta_Propostapacienteconta_N = sdt.gxTv_SdtProposta_Propostapacienteconta_N ;
         gxTv_SdtProposta_Propostapacienteagencia_N = sdt.gxTv_SdtProposta_Propostapacienteagencia_N ;
         gxTv_SdtProposta_Propostapacientetipopix_N = sdt.gxTv_SdtProposta_Propostapacientetipopix_N ;
         gxTv_SdtProposta_Propostapacientepix_N = sdt.gxTv_SdtProposta_Propostapacientepix_N ;
         gxTv_SdtProposta_Propostapacientedepositotipo_N = sdt.gxTv_SdtProposta_Propostapacientedepositotipo_N ;
         gxTv_SdtProposta_Propostapacienteenderecocep_N = sdt.gxTv_SdtProposta_Propostapacienteenderecocep_N ;
         gxTv_SdtProposta_Propostapacienteenderecologradouro_N = sdt.gxTv_SdtProposta_Propostapacienteenderecologradouro_N ;
         gxTv_SdtProposta_Propostapacienteendereconumero_N = sdt.gxTv_SdtProposta_Propostapacienteendereconumero_N ;
         gxTv_SdtProposta_Propostapacienteenderecocomplemento_N = sdt.gxTv_SdtProposta_Propostapacienteenderecocomplemento_N ;
         gxTv_SdtProposta_Propostapacienteenderecobairro_N = sdt.gxTv_SdtProposta_Propostapacienteenderecobairro_N ;
         gxTv_SdtProposta_Propostapacientemunicipiocodigo_N = sdt.gxTv_SdtProposta_Propostapacientemunicipiocodigo_N ;
         gxTv_SdtProposta_Propostapacienteserasaconsultas_f_N = sdt.gxTv_SdtProposta_Propostapacienteserasaconsultas_f_N ;
         gxTv_SdtProposta_Propostaserasascoreultimadata_f_N = sdt.gxTv_SdtProposta_Propostaserasascoreultimadata_f_N ;
         gxTv_SdtProposta_Propostapacienteserasaultimovalorrecomendado_f_N = sdt.gxTv_SdtProposta_Propostapacienteserasaultimovalorrecomendado_f_N ;
         gxTv_SdtProposta_Propostavalortaxaclinica_f_N = sdt.gxTv_SdtProposta_Propostavalortaxaclinica_f_N ;
         gxTv_SdtProposta_Propostaqtddocumentopendente_f_N = sdt.gxTv_SdtProposta_Propostaqtddocumentopendente_f_N ;
         gxTv_SdtProposta_Propostatitulo_N = sdt.gxTv_SdtProposta_Propostatitulo_N ;
         gxTv_SdtProposta_Procedimentosmedicosid_N = sdt.gxTv_SdtProposta_Procedimentosmedicosid_N ;
         gxTv_SdtProposta_Propostadescricao_N = sdt.gxTv_SdtProposta_Propostadescricao_N ;
         gxTv_SdtProposta_Propostadatacirurgia_N = sdt.gxTv_SdtProposta_Propostadatacirurgia_N ;
         gxTv_SdtProposta_Propostavalor_N = sdt.gxTv_SdtProposta_Propostavalor_N ;
         gxTv_SdtProposta_Propostavalorliquido_N = sdt.gxTv_SdtProposta_Propostavalorliquido_N ;
         gxTv_SdtProposta_Propostataxaadministrativa_N = sdt.gxTv_SdtProposta_Propostataxaadministrativa_N ;
         gxTv_SdtProposta_Propostasla_N = sdt.gxTv_SdtProposta_Propostasla_N ;
         gxTv_SdtProposta_Propostajurosmora_N = sdt.gxTv_SdtProposta_Propostajurosmora_N ;
         gxTv_SdtProposta_Propostacreatedat_N = sdt.gxTv_SdtProposta_Propostacreatedat_N ;
         gxTv_SdtProposta_Propostacratedby_N = sdt.gxTv_SdtProposta_Propostacratedby_N ;
         gxTv_SdtProposta_Propostaclinicaid_N = sdt.gxTv_SdtProposta_Propostaclinicaid_N ;
         gxTv_SdtProposta_Propostaclinicanome_N = sdt.gxTv_SdtProposta_Propostaclinicanome_N ;
         gxTv_SdtProposta_Propostaclinicanomefantasia_N = sdt.gxTv_SdtProposta_Propostaclinicanomefantasia_N ;
         gxTv_SdtProposta_Propostaclinicadocumento_N = sdt.gxTv_SdtProposta_Propostaclinicadocumento_N ;
         gxTv_SdtProposta_Propostaclinicaemail_N = sdt.gxTv_SdtProposta_Propostaclinicaemail_N ;
         gxTv_SdtProposta_Propostasecusername_N = sdt.gxTv_SdtProposta_Propostasecusername_N ;
         gxTv_SdtProposta_Propostastatus_N = sdt.gxTv_SdtProposta_Propostastatus_N ;
         gxTv_SdtProposta_Propostacomentarioanalise_N = sdt.gxTv_SdtProposta_Propostacomentarioanalise_N ;
         gxTv_SdtProposta_Propostaquantidadeaprovadores_N = sdt.gxTv_SdtProposta_Propostaquantidadeaprovadores_N ;
         gxTv_SdtProposta_Propostareprovacoespermitidas_N = sdt.gxTv_SdtProposta_Propostareprovacoespermitidas_N ;
         gxTv_SdtProposta_Contratoid_N = sdt.gxTv_SdtProposta_Contratoid_N ;
         gxTv_SdtProposta_Contratonome_N = sdt.gxTv_SdtProposta_Contratonome_N ;
         gxTv_SdtProposta_Convenioid_N = sdt.gxTv_SdtProposta_Convenioid_N ;
         gxTv_SdtProposta_Conveniovencimentoano_N = sdt.gxTv_SdtProposta_Conveniovencimentoano_N ;
         gxTv_SdtProposta_Conveniovencimentomes_N = sdt.gxTv_SdtProposta_Conveniovencimentomes_N ;
         gxTv_SdtProposta_Conveniocategoriaid_N = sdt.gxTv_SdtProposta_Conveniocategoriaid_N ;
         gxTv_SdtProposta_Conveniocategoriadescricao_N = sdt.gxTv_SdtProposta_Conveniocategoriadescricao_N ;
         gxTv_SdtProposta_Propostadatacreditocliente_f_N = sdt.gxTv_SdtProposta_Propostadatacreditocliente_f_N ;
         gxTv_SdtProposta_Propostavalorreembolsado_f_N = sdt.gxTv_SdtProposta_Propostavalorreembolsado_f_N ;
         gxTv_SdtProposta_Propostavalorreembolsadojuros_f_N = sdt.gxTv_SdtProposta_Propostavalorreembolsadojuros_f_N ;
         gxTv_SdtProposta_Propostavalortaxarecebida_f_N = sdt.gxTv_SdtProposta_Propostavalortaxarecebida_f_N ;
         gxTv_SdtProposta_Propostaaprovacoes_f_N = sdt.gxTv_SdtProposta_Propostaaprovacoes_f_N ;
         gxTv_SdtProposta_Propostareprovacoes_f_N = sdt.gxTv_SdtProposta_Propostareprovacoes_f_N ;
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
         AddObjectProperty("PropostaId", gxTv_SdtProposta_Propostaid, false, includeNonInitialized);
         AddObjectProperty("PropostaId_N", gxTv_SdtProposta_Propostaid_N, false, includeNonInitialized);
         AddObjectProperty("PropostaMaxReembolsoId_F", gxTv_SdtProposta_Propostamaxreembolsoid_f, false, includeNonInitialized);
         AddObjectProperty("PropostaMaxReembolsoId_F_N", gxTv_SdtProposta_Propostamaxreembolsoid_f_N, false, includeNonInitialized);
         AddObjectProperty("PropostaProtocolo", gxTv_SdtProposta_Propostaprotocolo, false, includeNonInitialized);
         AddObjectProperty("PropostaProtocolo_N", gxTv_SdtProposta_Propostaprotocolo_N, false, includeNonInitialized);
         AddObjectProperty("PropostaEmpresaClienteId", gxTv_SdtProposta_Propostaempresaclienteid, false, includeNonInitialized);
         AddObjectProperty("PropostaEmpresaClienteId_N", gxTv_SdtProposta_Propostaempresaclienteid_N, false, includeNonInitialized);
         AddObjectProperty("PropostaTipoProposta", gxTv_SdtProposta_Propostatipoproposta, false, includeNonInitialized);
         AddObjectProperty("PropostaTipoProposta_N", gxTv_SdtProposta_Propostatipoproposta_N, false, includeNonInitialized);
         AddObjectProperty("PropostaPacienteClienteId", gxTv_SdtProposta_Propostapacienteclienteid, false, includeNonInitialized);
         AddObjectProperty("PropostaPacienteClienteId_N", gxTv_SdtProposta_Propostapacienteclienteid_N, false, includeNonInitialized);
         AddObjectProperty("PropostaQtdItensNota_F", gxTv_SdtProposta_Propostaqtditensnota_f, false, includeNonInitialized);
         AddObjectProperty("PropostaQtdItensNota_F_N", gxTv_SdtProposta_Propostaqtditensnota_f_N, false, includeNonInitialized);
         AddObjectProperty("PropostaResponsavelId", gxTv_SdtProposta_Propostaresponsavelid, false, includeNonInitialized);
         AddObjectProperty("PropostaResponsavelId_N", gxTv_SdtProposta_Propostaresponsavelid_N, false, includeNonInitialized);
         AddObjectProperty("PropostaResponsavelDocumento", gxTv_SdtProposta_Propostaresponsaveldocumento, false, includeNonInitialized);
         AddObjectProperty("PropostaResponsavelDocumento_N", gxTv_SdtProposta_Propostaresponsaveldocumento_N, false, includeNonInitialized);
         AddObjectProperty("PropostaResponsavelRazaoSocial", gxTv_SdtProposta_Propostaresponsavelrazaosocial, false, includeNonInitialized);
         AddObjectProperty("PropostaResponsavelRazaoSocial_N", gxTv_SdtProposta_Propostaresponsavelrazaosocial_N, false, includeNonInitialized);
         AddObjectProperty("PropostaResponsavelEmail", gxTv_SdtProposta_Propostaresponsavelemail, false, includeNonInitialized);
         AddObjectProperty("PropostaResponsavelEmail_N", gxTv_SdtProposta_Propostaresponsavelemail_N, false, includeNonInitialized);
         AddObjectProperty("PropostaResponsavelBanco", gxTv_SdtProposta_Propostaresponsavelbanco, false, includeNonInitialized);
         AddObjectProperty("PropostaResponsavelConta", gxTv_SdtProposta_Propostaresponsavelconta, false, includeNonInitialized);
         AddObjectProperty("PropostaResponsavelConta_N", gxTv_SdtProposta_Propostaresponsavelconta_N, false, includeNonInitialized);
         AddObjectProperty("PropostaResponsavelAgencia", gxTv_SdtProposta_Propostaresponsavelagencia, false, includeNonInitialized);
         AddObjectProperty("PropostaResponsavelAgencia_N", gxTv_SdtProposta_Propostaresponsavelagencia_N, false, includeNonInitialized);
         AddObjectProperty("PropostaResponsavelTipoPix", gxTv_SdtProposta_Propostaresponsaveltipopix, false, includeNonInitialized);
         AddObjectProperty("PropostaResponsavelTipoPix_N", gxTv_SdtProposta_Propostaresponsaveltipopix_N, false, includeNonInitialized);
         AddObjectProperty("PropostaResponsavelPIX", gxTv_SdtProposta_Propostaresponsavelpix, false, includeNonInitialized);
         AddObjectProperty("PropostaResponsavelPIX_N", gxTv_SdtProposta_Propostaresponsavelpix_N, false, includeNonInitialized);
         AddObjectProperty("PropostaResponsavelDepositoTipo", gxTv_SdtProposta_Propostaresponsaveldepositotipo, false, includeNonInitialized);
         AddObjectProperty("PropostaResponsavelDepositoTipo_N", gxTv_SdtProposta_Propostaresponsaveldepositotipo_N, false, includeNonInitialized);
         AddObjectProperty("PropostaResponsavelSerasaConsultas_F", gxTv_SdtProposta_Propostaresponsavelserasaconsultas_f, false, includeNonInitialized);
         AddObjectProperty("PropostaResponsavelSerasaConsultas_F_N", gxTv_SdtProposta_Propostaresponsavelserasaconsultas_f_N, false, includeNonInitialized);
         AddObjectProperty("PropostaResponsavelSerasaScoreUltimaData_F", gxTv_SdtProposta_Propostaresponsavelserasascoreultimadata_f, false, includeNonInitialized);
         AddObjectProperty("PropostaResponsavelSerasaScoreUltimaData_F_N", gxTv_SdtProposta_Propostaresponsavelserasascoreultimadata_f_N, false, includeNonInitialized);
         AddObjectProperty("PropostaResponsavelSerasaUltimoValorRecomendado_F", StringUtil.LTrim( StringUtil.Str( gxTv_SdtProposta_Propostaresponsavelserasaultimovalorrecomendado_f, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("PropostaResponsavelSerasaUltimoValorRecomendado_F_N", gxTv_SdtProposta_Propostaresponsavelserasaultimovalorrecomendado_f_N, false, includeNonInitialized);
         AddObjectProperty("PropostaPacienteClienteRazaoSocial", gxTv_SdtProposta_Propostapacienteclienterazaosocial, false, includeNonInitialized);
         AddObjectProperty("PropostaPacienteClienteRazaoSocial_N", gxTv_SdtProposta_Propostapacienteclienterazaosocial_N, false, includeNonInitialized);
         AddObjectProperty("PropostaPacienteClienteDocumento", gxTv_SdtProposta_Propostapacienteclientedocumento, false, includeNonInitialized);
         AddObjectProperty("PropostaPacienteClienteDocumento_N", gxTv_SdtProposta_Propostapacienteclientedocumento_N, false, includeNonInitialized);
         AddObjectProperty("PropostaPacienteContatoEmail", gxTv_SdtProposta_Propostapacientecontatoemail, false, includeNonInitialized);
         AddObjectProperty("PropostaPacienteContatoEmail_N", gxTv_SdtProposta_Propostapacientecontatoemail_N, false, includeNonInitialized);
         AddObjectProperty("PropostaPacienteBanco", gxTv_SdtProposta_Propostapacientebanco, false, includeNonInitialized);
         AddObjectProperty("PropostaPacienteConta", gxTv_SdtProposta_Propostapacienteconta, false, includeNonInitialized);
         AddObjectProperty("PropostaPacienteConta_N", gxTv_SdtProposta_Propostapacienteconta_N, false, includeNonInitialized);
         AddObjectProperty("PropostaPacienteAgencia", gxTv_SdtProposta_Propostapacienteagencia, false, includeNonInitialized);
         AddObjectProperty("PropostaPacienteAgencia_N", gxTv_SdtProposta_Propostapacienteagencia_N, false, includeNonInitialized);
         AddObjectProperty("PropostaPacienteTipoPix", gxTv_SdtProposta_Propostapacientetipopix, false, includeNonInitialized);
         AddObjectProperty("PropostaPacienteTipoPix_N", gxTv_SdtProposta_Propostapacientetipopix_N, false, includeNonInitialized);
         AddObjectProperty("PropostaPacientePIX", gxTv_SdtProposta_Propostapacientepix, false, includeNonInitialized);
         AddObjectProperty("PropostaPacientePIX_N", gxTv_SdtProposta_Propostapacientepix_N, false, includeNonInitialized);
         AddObjectProperty("PropostaPacienteDepositoTipo", gxTv_SdtProposta_Propostapacientedepositotipo, false, includeNonInitialized);
         AddObjectProperty("PropostaPacienteDepositoTipo_N", gxTv_SdtProposta_Propostapacientedepositotipo_N, false, includeNonInitialized);
         AddObjectProperty("PropostaPacienteEnderecoCEP", gxTv_SdtProposta_Propostapacienteenderecocep, false, includeNonInitialized);
         AddObjectProperty("PropostaPacienteEnderecoCEP_N", gxTv_SdtProposta_Propostapacienteenderecocep_N, false, includeNonInitialized);
         AddObjectProperty("PropostaPacienteEnderecoLogradouro", gxTv_SdtProposta_Propostapacienteenderecologradouro, false, includeNonInitialized);
         AddObjectProperty("PropostaPacienteEnderecoLogradouro_N", gxTv_SdtProposta_Propostapacienteenderecologradouro_N, false, includeNonInitialized);
         AddObjectProperty("PropostaPacienteEnderecoNumero", gxTv_SdtProposta_Propostapacienteendereconumero, false, includeNonInitialized);
         AddObjectProperty("PropostaPacienteEnderecoNumero_N", gxTv_SdtProposta_Propostapacienteendereconumero_N, false, includeNonInitialized);
         AddObjectProperty("PropostaPacienteEnderecoComplemento", gxTv_SdtProposta_Propostapacienteenderecocomplemento, false, includeNonInitialized);
         AddObjectProperty("PropostaPacienteEnderecoComplemento_N", gxTv_SdtProposta_Propostapacienteenderecocomplemento_N, false, includeNonInitialized);
         AddObjectProperty("PropostaPacienteEnderecoBairro", gxTv_SdtProposta_Propostapacienteenderecobairro, false, includeNonInitialized);
         AddObjectProperty("PropostaPacienteEnderecoBairro_N", gxTv_SdtProposta_Propostapacienteenderecobairro_N, false, includeNonInitialized);
         AddObjectProperty("PropostaPacienteMunicipioCodigo", gxTv_SdtProposta_Propostapacientemunicipiocodigo, false, includeNonInitialized);
         AddObjectProperty("PropostaPacienteMunicipioCodigo_N", gxTv_SdtProposta_Propostapacientemunicipiocodigo_N, false, includeNonInitialized);
         AddObjectProperty("PropostaPacienteSerasaConsultas_F", gxTv_SdtProposta_Propostapacienteserasaconsultas_f, false, includeNonInitialized);
         AddObjectProperty("PropostaPacienteSerasaConsultas_F_N", gxTv_SdtProposta_Propostapacienteserasaconsultas_f_N, false, includeNonInitialized);
         AddObjectProperty("PropostaSerasaScoreUltimaData_F", gxTv_SdtProposta_Propostaserasascoreultimadata_f, false, includeNonInitialized);
         AddObjectProperty("PropostaSerasaScoreUltimaData_F_N", gxTv_SdtProposta_Propostaserasascoreultimadata_f_N, false, includeNonInitialized);
         AddObjectProperty("PropostaPacienteSerasaUltimoValorRecomendado_F", StringUtil.LTrim( StringUtil.Str( gxTv_SdtProposta_Propostapacienteserasaultimovalorrecomendado_f, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("PropostaPacienteSerasaUltimoValorRecomendado_F_N", gxTv_SdtProposta_Propostapacienteserasaultimovalorrecomendado_f_N, false, includeNonInitialized);
         AddObjectProperty("PropostaValorTaxaClinica_F", StringUtil.LTrim( StringUtil.Str( gxTv_SdtProposta_Propostavalortaxaclinica_f, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("PropostaValorTaxaClinica_F_N", gxTv_SdtProposta_Propostavalortaxaclinica_f_N, false, includeNonInitialized);
         AddObjectProperty("PropostaQtdDocumentoPendente_F", gxTv_SdtProposta_Propostaqtddocumentopendente_f, false, includeNonInitialized);
         AddObjectProperty("PropostaQtdDocumentoPendente_F_N", gxTv_SdtProposta_Propostaqtddocumentopendente_f_N, false, includeNonInitialized);
         AddObjectProperty("PropostaMaiorScore_F", gxTv_SdtProposta_Propostamaiorscore_f, false, includeNonInitialized);
         AddObjectProperty("PropostaMaiorValorRecomendado", StringUtil.LTrim( StringUtil.Str( gxTv_SdtProposta_Propostamaiorvalorrecomendado, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("PropostaTitulo", gxTv_SdtProposta_Propostatitulo, false, includeNonInitialized);
         AddObjectProperty("PropostaTitulo_N", gxTv_SdtProposta_Propostatitulo_N, false, includeNonInitialized);
         AddObjectProperty("ProcedimentosMedicosId", gxTv_SdtProposta_Procedimentosmedicosid, false, includeNonInitialized);
         AddObjectProperty("ProcedimentosMedicosId_N", gxTv_SdtProposta_Procedimentosmedicosid_N, false, includeNonInitialized);
         AddObjectProperty("PropostaDescricao", gxTv_SdtProposta_Propostadescricao, false, includeNonInitialized);
         AddObjectProperty("PropostaDescricao_N", gxTv_SdtProposta_Propostadescricao_N, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtProposta_Propostadatacirurgia)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtProposta_Propostadatacirurgia)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtProposta_Propostadatacirurgia)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("PropostaDataCirurgia", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("PropostaDataCirurgia_N", gxTv_SdtProposta_Propostadatacirurgia_N, false, includeNonInitialized);
         AddObjectProperty("PropostaValor", StringUtil.LTrim( StringUtil.Str( gxTv_SdtProposta_Propostavalor, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("PropostaValor_N", gxTv_SdtProposta_Propostavalor_N, false, includeNonInitialized);
         AddObjectProperty("PropostaValorLiquido", StringUtil.LTrim( StringUtil.Str( gxTv_SdtProposta_Propostavalorliquido, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("PropostaValorLiquido_N", gxTv_SdtProposta_Propostavalorliquido_N, false, includeNonInitialized);
         AddObjectProperty("PropostaTaxaAdministrativa", StringUtil.LTrim( StringUtil.Str( gxTv_SdtProposta_Propostataxaadministrativa, 16, 4)), false, includeNonInitialized);
         AddObjectProperty("PropostaTaxaAdministrativa_N", gxTv_SdtProposta_Propostataxaadministrativa_N, false, includeNonInitialized);
         AddObjectProperty("PropostaTaxa_F", StringUtil.LTrim( StringUtil.Str( gxTv_SdtProposta_Propostataxa_f, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("PropostaSLA", gxTv_SdtProposta_Propostasla, false, includeNonInitialized);
         AddObjectProperty("PropostaSLA_N", gxTv_SdtProposta_Propostasla_N, false, includeNonInitialized);
         AddObjectProperty("PropostaJurosMora", StringUtil.LTrim( StringUtil.Str( gxTv_SdtProposta_Propostajurosmora, 16, 4)), false, includeNonInitialized);
         AddObjectProperty("PropostaJurosMora_N", gxTv_SdtProposta_Propostajurosmora_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtProposta_Propostacreatedat;
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "T";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("PropostaCreatedAt", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("PropostaCreatedAt_N", gxTv_SdtProposta_Propostacreatedat_N, false, includeNonInitialized);
         AddObjectProperty("PropostaCratedBy", gxTv_SdtProposta_Propostacratedby, false, includeNonInitialized);
         AddObjectProperty("PropostaCratedBy_N", gxTv_SdtProposta_Propostacratedby_N, false, includeNonInitialized);
         AddObjectProperty("PropostaClinicaId", gxTv_SdtProposta_Propostaclinicaid, false, includeNonInitialized);
         AddObjectProperty("PropostaClinicaId_N", gxTv_SdtProposta_Propostaclinicaid_N, false, includeNonInitialized);
         AddObjectProperty("PropostaClinicaNome", gxTv_SdtProposta_Propostaclinicanome, false, includeNonInitialized);
         AddObjectProperty("PropostaClinicaNome_N", gxTv_SdtProposta_Propostaclinicanome_N, false, includeNonInitialized);
         AddObjectProperty("PropostaClinicaNomeFantasia", gxTv_SdtProposta_Propostaclinicanomefantasia, false, includeNonInitialized);
         AddObjectProperty("PropostaClinicaNomeFantasia_N", gxTv_SdtProposta_Propostaclinicanomefantasia_N, false, includeNonInitialized);
         AddObjectProperty("PropostaClinicaDocumento", gxTv_SdtProposta_Propostaclinicadocumento, false, includeNonInitialized);
         AddObjectProperty("PropostaClinicaDocumento_N", gxTv_SdtProposta_Propostaclinicadocumento_N, false, includeNonInitialized);
         AddObjectProperty("PropostaClinicaEmail", gxTv_SdtProposta_Propostaclinicaemail, false, includeNonInitialized);
         AddObjectProperty("PropostaClinicaEmail_N", gxTv_SdtProposta_Propostaclinicaemail_N, false, includeNonInitialized);
         AddObjectProperty("PropostaSecUserName", gxTv_SdtProposta_Propostasecusername, false, includeNonInitialized);
         AddObjectProperty("PropostaSecUserName_N", gxTv_SdtProposta_Propostasecusername_N, false, includeNonInitialized);
         AddObjectProperty("PropostaStatus", gxTv_SdtProposta_Propostastatus, false, includeNonInitialized);
         AddObjectProperty("PropostaStatus_N", gxTv_SdtProposta_Propostastatus_N, false, includeNonInitialized);
         AddObjectProperty("PropostaComentarioAnalise", gxTv_SdtProposta_Propostacomentarioanalise, false, includeNonInitialized);
         AddObjectProperty("PropostaComentarioAnalise_N", gxTv_SdtProposta_Propostacomentarioanalise_N, false, includeNonInitialized);
         AddObjectProperty("PropostaQuantidadeAprovadores", gxTv_SdtProposta_Propostaquantidadeaprovadores, false, includeNonInitialized);
         AddObjectProperty("PropostaQuantidadeAprovadores_N", gxTv_SdtProposta_Propostaquantidadeaprovadores_N, false, includeNonInitialized);
         AddObjectProperty("PropostaReprovacoesPermitidas", gxTv_SdtProposta_Propostareprovacoespermitidas, false, includeNonInitialized);
         AddObjectProperty("PropostaReprovacoesPermitidas_N", gxTv_SdtProposta_Propostareprovacoespermitidas_N, false, includeNonInitialized);
         AddObjectProperty("ContratoId", gxTv_SdtProposta_Contratoid, false, includeNonInitialized);
         AddObjectProperty("ContratoId_N", gxTv_SdtProposta_Contratoid_N, false, includeNonInitialized);
         AddObjectProperty("ContratoNome", gxTv_SdtProposta_Contratonome, false, includeNonInitialized);
         AddObjectProperty("ContratoNome_N", gxTv_SdtProposta_Contratonome_N, false, includeNonInitialized);
         AddObjectProperty("ConvenioId", gxTv_SdtProposta_Convenioid, false, includeNonInitialized);
         AddObjectProperty("ConvenioId_N", gxTv_SdtProposta_Convenioid_N, false, includeNonInitialized);
         AddObjectProperty("ConvenioVencimentoAno", gxTv_SdtProposta_Conveniovencimentoano, false, includeNonInitialized);
         AddObjectProperty("ConvenioVencimentoAno_N", gxTv_SdtProposta_Conveniovencimentoano_N, false, includeNonInitialized);
         AddObjectProperty("ConvenioVencimentoMes", gxTv_SdtProposta_Conveniovencimentomes, false, includeNonInitialized);
         AddObjectProperty("ConvenioVencimentoMes_N", gxTv_SdtProposta_Conveniovencimentomes_N, false, includeNonInitialized);
         AddObjectProperty("ConvenioCategoriaId", gxTv_SdtProposta_Conveniocategoriaid, false, includeNonInitialized);
         AddObjectProperty("ConvenioCategoriaId_N", gxTv_SdtProposta_Conveniocategoriaid_N, false, includeNonInitialized);
         AddObjectProperty("ConvenioCategoriaDescricao", gxTv_SdtProposta_Conveniocategoriadescricao, false, includeNonInitialized);
         AddObjectProperty("ConvenioCategoriaDescricao_N", gxTv_SdtProposta_Conveniocategoriadescricao_N, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtProposta_Propostadatacreditocliente_f)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtProposta_Propostadatacreditocliente_f)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtProposta_Propostadatacreditocliente_f)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("PropostaDataCreditoCliente_F", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("PropostaDataCreditoCliente_F_N", gxTv_SdtProposta_Propostadatacreditocliente_f_N, false, includeNonInitialized);
         AddObjectProperty("PropostaValorTaxa_F", StringUtil.LTrim( StringUtil.Str( gxTv_SdtProposta_Propostavalortaxa_f, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("PropostaValorJurosMora_F", StringUtil.LTrim( StringUtil.Str( gxTv_SdtProposta_Propostavalorjurosmora_f, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("PropostaValorReembolsado_F", StringUtil.LTrim( StringUtil.Str( gxTv_SdtProposta_Propostavalorreembolsado_f, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("PropostaValorReembolsado_F_N", gxTv_SdtProposta_Propostavalorreembolsado_f_N, false, includeNonInitialized);
         AddObjectProperty("PropostaValorReembolsadoJuros_F", StringUtil.LTrim( StringUtil.Str( gxTv_SdtProposta_Propostavalorreembolsadojuros_f, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("PropostaValorReembolsadoJuros_F_N", gxTv_SdtProposta_Propostavalorreembolsadojuros_f_N, false, includeNonInitialized);
         AddObjectProperty("PropostaValorTaxaRecebida_F", StringUtil.LTrim( StringUtil.Str( gxTv_SdtProposta_Propostavalortaxarecebida_f, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("PropostaValorTaxaRecebida_F_N", gxTv_SdtProposta_Propostavalortaxarecebida_f_N, false, includeNonInitialized);
         AddObjectProperty("PropostaAprovacoes_F", gxTv_SdtProposta_Propostaaprovacoes_f, false, includeNonInitialized);
         AddObjectProperty("PropostaAprovacoes_F_N", gxTv_SdtProposta_Propostaaprovacoes_f_N, false, includeNonInitialized);
         AddObjectProperty("PropostaReprovacoes_F", gxTv_SdtProposta_Propostareprovacoes_f, false, includeNonInitialized);
         AddObjectProperty("PropostaReprovacoes_F_N", gxTv_SdtProposta_Propostareprovacoes_f_N, false, includeNonInitialized);
         AddObjectProperty("PropostaAprovacoesRestantes_F", gxTv_SdtProposta_Propostaaprovacoesrestantes_f, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtProposta_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtProposta_Initialized, false, includeNonInitialized);
            AddObjectProperty("PropostaId_Z", gxTv_SdtProposta_Propostaid_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaMaxReembolsoId_F_Z", gxTv_SdtProposta_Propostamaxreembolsoid_f_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaProtocolo_Z", gxTv_SdtProposta_Propostaprotocolo_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaEmpresaClienteId_Z", gxTv_SdtProposta_Propostaempresaclienteid_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaTipoProposta_Z", gxTv_SdtProposta_Propostatipoproposta_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaPacienteClienteId_Z", gxTv_SdtProposta_Propostapacienteclienteid_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaQtdItensNota_F_Z", gxTv_SdtProposta_Propostaqtditensnota_f_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaResponsavelId_Z", gxTv_SdtProposta_Propostaresponsavelid_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaResponsavelDocumento_Z", gxTv_SdtProposta_Propostaresponsaveldocumento_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaResponsavelRazaoSocial_Z", gxTv_SdtProposta_Propostaresponsavelrazaosocial_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaResponsavelEmail_Z", gxTv_SdtProposta_Propostaresponsavelemail_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaResponsavelBanco_Z", gxTv_SdtProposta_Propostaresponsavelbanco_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaResponsavelConta_Z", gxTv_SdtProposta_Propostaresponsavelconta_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaResponsavelAgencia_Z", gxTv_SdtProposta_Propostaresponsavelagencia_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaResponsavelTipoPix_Z", gxTv_SdtProposta_Propostaresponsaveltipopix_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaResponsavelPIX_Z", gxTv_SdtProposta_Propostaresponsavelpix_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaResponsavelDepositoTipo_Z", gxTv_SdtProposta_Propostaresponsaveldepositotipo_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaResponsavelSerasaConsultas_F_Z", gxTv_SdtProposta_Propostaresponsavelserasaconsultas_f_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaResponsavelSerasaScoreUltimaData_F_Z", gxTv_SdtProposta_Propostaresponsavelserasascoreultimadata_f_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaResponsavelSerasaUltimoValorRecomendado_F_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtProposta_Propostaresponsavelserasaultimovalorrecomendado_f_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("PropostaPacienteClienteRazaoSocial_Z", gxTv_SdtProposta_Propostapacienteclienterazaosocial_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaPacienteClienteDocumento_Z", gxTv_SdtProposta_Propostapacienteclientedocumento_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaPacienteContatoEmail_Z", gxTv_SdtProposta_Propostapacientecontatoemail_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaPacienteBanco_Z", gxTv_SdtProposta_Propostapacientebanco_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaPacienteConta_Z", gxTv_SdtProposta_Propostapacienteconta_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaPacienteAgencia_Z", gxTv_SdtProposta_Propostapacienteagencia_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaPacienteTipoPix_Z", gxTv_SdtProposta_Propostapacientetipopix_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaPacientePIX_Z", gxTv_SdtProposta_Propostapacientepix_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaPacienteDepositoTipo_Z", gxTv_SdtProposta_Propostapacientedepositotipo_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaPacienteEnderecoCEP_Z", gxTv_SdtProposta_Propostapacienteenderecocep_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaPacienteEnderecoLogradouro_Z", gxTv_SdtProposta_Propostapacienteenderecologradouro_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaPacienteEnderecoNumero_Z", gxTv_SdtProposta_Propostapacienteendereconumero_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaPacienteEnderecoComplemento_Z", gxTv_SdtProposta_Propostapacienteenderecocomplemento_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaPacienteEnderecoBairro_Z", gxTv_SdtProposta_Propostapacienteenderecobairro_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaPacienteMunicipioCodigo_Z", gxTv_SdtProposta_Propostapacientemunicipiocodigo_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaPacienteSerasaConsultas_F_Z", gxTv_SdtProposta_Propostapacienteserasaconsultas_f_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaSerasaScoreUltimaData_F_Z", gxTv_SdtProposta_Propostaserasascoreultimadata_f_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaPacienteSerasaUltimoValorRecomendado_F_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtProposta_Propostapacienteserasaultimovalorrecomendado_f_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("PropostaValorTaxaClinica_F_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtProposta_Propostavalortaxaclinica_f_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("PropostaQtdDocumentoPendente_F_Z", gxTv_SdtProposta_Propostaqtddocumentopendente_f_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaMaiorScore_F_Z", gxTv_SdtProposta_Propostamaiorscore_f_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaMaiorValorRecomendado_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtProposta_Propostamaiorvalorrecomendado_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("PropostaTitulo_Z", gxTv_SdtProposta_Propostatitulo_Z, false, includeNonInitialized);
            AddObjectProperty("ProcedimentosMedicosId_Z", gxTv_SdtProposta_Procedimentosmedicosid_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaDescricao_Z", gxTv_SdtProposta_Propostadescricao_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtProposta_Propostadatacirurgia_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtProposta_Propostadatacirurgia_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtProposta_Propostadatacirurgia_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("PropostaDataCirurgia_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("PropostaValor_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtProposta_Propostavalor_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("PropostaValorLiquido_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtProposta_Propostavalorliquido_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("PropostaTaxaAdministrativa_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtProposta_Propostataxaadministrativa_Z, 16, 4)), false, includeNonInitialized);
            AddObjectProperty("PropostaTaxa_F_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtProposta_Propostataxa_f_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("PropostaSLA_Z", gxTv_SdtProposta_Propostasla_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaJurosMora_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtProposta_Propostajurosmora_Z, 16, 4)), false, includeNonInitialized);
            datetime_STZ = gxTv_SdtProposta_Propostacreatedat_Z;
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "T";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("PropostaCreatedAt_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("PropostaCratedBy_Z", gxTv_SdtProposta_Propostacratedby_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaClinicaId_Z", gxTv_SdtProposta_Propostaclinicaid_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaClinicaNome_Z", gxTv_SdtProposta_Propostaclinicanome_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaClinicaNomeFantasia_Z", gxTv_SdtProposta_Propostaclinicanomefantasia_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaClinicaDocumento_Z", gxTv_SdtProposta_Propostaclinicadocumento_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaClinicaEmail_Z", gxTv_SdtProposta_Propostaclinicaemail_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaSecUserName_Z", gxTv_SdtProposta_Propostasecusername_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaStatus_Z", gxTv_SdtProposta_Propostastatus_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaComentarioAnalise_Z", gxTv_SdtProposta_Propostacomentarioanalise_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaQuantidadeAprovadores_Z", gxTv_SdtProposta_Propostaquantidadeaprovadores_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaReprovacoesPermitidas_Z", gxTv_SdtProposta_Propostareprovacoespermitidas_Z, false, includeNonInitialized);
            AddObjectProperty("ContratoId_Z", gxTv_SdtProposta_Contratoid_Z, false, includeNonInitialized);
            AddObjectProperty("ContratoNome_Z", gxTv_SdtProposta_Contratonome_Z, false, includeNonInitialized);
            AddObjectProperty("ConvenioId_Z", gxTv_SdtProposta_Convenioid_Z, false, includeNonInitialized);
            AddObjectProperty("ConvenioVencimentoAno_Z", gxTv_SdtProposta_Conveniovencimentoano_Z, false, includeNonInitialized);
            AddObjectProperty("ConvenioVencimentoMes_Z", gxTv_SdtProposta_Conveniovencimentomes_Z, false, includeNonInitialized);
            AddObjectProperty("ConvenioCategoriaId_Z", gxTv_SdtProposta_Conveniocategoriaid_Z, false, includeNonInitialized);
            AddObjectProperty("ConvenioCategoriaDescricao_Z", gxTv_SdtProposta_Conveniocategoriadescricao_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtProposta_Propostadatacreditocliente_f_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtProposta_Propostadatacreditocliente_f_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtProposta_Propostadatacreditocliente_f_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("PropostaDataCreditoCliente_F_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("PropostaValorTaxa_F_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtProposta_Propostavalortaxa_f_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("PropostaValorJurosMora_F_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtProposta_Propostavalorjurosmora_f_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("PropostaValorReembolsado_F_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtProposta_Propostavalorreembolsado_f_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("PropostaValorReembolsadoJuros_F_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtProposta_Propostavalorreembolsadojuros_f_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("PropostaValorTaxaRecebida_F_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtProposta_Propostavalortaxarecebida_f_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("PropostaAprovacoes_F_Z", gxTv_SdtProposta_Propostaaprovacoes_f_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaReprovacoes_F_Z", gxTv_SdtProposta_Propostareprovacoes_f_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaAprovacoesRestantes_F_Z", gxTv_SdtProposta_Propostaaprovacoesrestantes_f_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaId_N", gxTv_SdtProposta_Propostaid_N, false, includeNonInitialized);
            AddObjectProperty("PropostaMaxReembolsoId_F_N", gxTv_SdtProposta_Propostamaxreembolsoid_f_N, false, includeNonInitialized);
            AddObjectProperty("PropostaProtocolo_N", gxTv_SdtProposta_Propostaprotocolo_N, false, includeNonInitialized);
            AddObjectProperty("PropostaEmpresaClienteId_N", gxTv_SdtProposta_Propostaempresaclienteid_N, false, includeNonInitialized);
            AddObjectProperty("PropostaTipoProposta_N", gxTv_SdtProposta_Propostatipoproposta_N, false, includeNonInitialized);
            AddObjectProperty("PropostaPacienteClienteId_N", gxTv_SdtProposta_Propostapacienteclienteid_N, false, includeNonInitialized);
            AddObjectProperty("PropostaQtdItensNota_F_N", gxTv_SdtProposta_Propostaqtditensnota_f_N, false, includeNonInitialized);
            AddObjectProperty("PropostaResponsavelId_N", gxTv_SdtProposta_Propostaresponsavelid_N, false, includeNonInitialized);
            AddObjectProperty("PropostaResponsavelDocumento_N", gxTv_SdtProposta_Propostaresponsaveldocumento_N, false, includeNonInitialized);
            AddObjectProperty("PropostaResponsavelRazaoSocial_N", gxTv_SdtProposta_Propostaresponsavelrazaosocial_N, false, includeNonInitialized);
            AddObjectProperty("PropostaResponsavelEmail_N", gxTv_SdtProposta_Propostaresponsavelemail_N, false, includeNonInitialized);
            AddObjectProperty("PropostaResponsavelConta_N", gxTv_SdtProposta_Propostaresponsavelconta_N, false, includeNonInitialized);
            AddObjectProperty("PropostaResponsavelAgencia_N", gxTv_SdtProposta_Propostaresponsavelagencia_N, false, includeNonInitialized);
            AddObjectProperty("PropostaResponsavelTipoPix_N", gxTv_SdtProposta_Propostaresponsaveltipopix_N, false, includeNonInitialized);
            AddObjectProperty("PropostaResponsavelPIX_N", gxTv_SdtProposta_Propostaresponsavelpix_N, false, includeNonInitialized);
            AddObjectProperty("PropostaResponsavelDepositoTipo_N", gxTv_SdtProposta_Propostaresponsaveldepositotipo_N, false, includeNonInitialized);
            AddObjectProperty("PropostaResponsavelSerasaConsultas_F_N", gxTv_SdtProposta_Propostaresponsavelserasaconsultas_f_N, false, includeNonInitialized);
            AddObjectProperty("PropostaResponsavelSerasaScoreUltimaData_F_N", gxTv_SdtProposta_Propostaresponsavelserasascoreultimadata_f_N, false, includeNonInitialized);
            AddObjectProperty("PropostaResponsavelSerasaUltimoValorRecomendado_F_N", gxTv_SdtProposta_Propostaresponsavelserasaultimovalorrecomendado_f_N, false, includeNonInitialized);
            AddObjectProperty("PropostaPacienteClienteRazaoSocial_N", gxTv_SdtProposta_Propostapacienteclienterazaosocial_N, false, includeNonInitialized);
            AddObjectProperty("PropostaPacienteClienteDocumento_N", gxTv_SdtProposta_Propostapacienteclientedocumento_N, false, includeNonInitialized);
            AddObjectProperty("PropostaPacienteContatoEmail_N", gxTv_SdtProposta_Propostapacientecontatoemail_N, false, includeNonInitialized);
            AddObjectProperty("PropostaPacienteConta_N", gxTv_SdtProposta_Propostapacienteconta_N, false, includeNonInitialized);
            AddObjectProperty("PropostaPacienteAgencia_N", gxTv_SdtProposta_Propostapacienteagencia_N, false, includeNonInitialized);
            AddObjectProperty("PropostaPacienteTipoPix_N", gxTv_SdtProposta_Propostapacientetipopix_N, false, includeNonInitialized);
            AddObjectProperty("PropostaPacientePIX_N", gxTv_SdtProposta_Propostapacientepix_N, false, includeNonInitialized);
            AddObjectProperty("PropostaPacienteDepositoTipo_N", gxTv_SdtProposta_Propostapacientedepositotipo_N, false, includeNonInitialized);
            AddObjectProperty("PropostaPacienteEnderecoCEP_N", gxTv_SdtProposta_Propostapacienteenderecocep_N, false, includeNonInitialized);
            AddObjectProperty("PropostaPacienteEnderecoLogradouro_N", gxTv_SdtProposta_Propostapacienteenderecologradouro_N, false, includeNonInitialized);
            AddObjectProperty("PropostaPacienteEnderecoNumero_N", gxTv_SdtProposta_Propostapacienteendereconumero_N, false, includeNonInitialized);
            AddObjectProperty("PropostaPacienteEnderecoComplemento_N", gxTv_SdtProposta_Propostapacienteenderecocomplemento_N, false, includeNonInitialized);
            AddObjectProperty("PropostaPacienteEnderecoBairro_N", gxTv_SdtProposta_Propostapacienteenderecobairro_N, false, includeNonInitialized);
            AddObjectProperty("PropostaPacienteMunicipioCodigo_N", gxTv_SdtProposta_Propostapacientemunicipiocodigo_N, false, includeNonInitialized);
            AddObjectProperty("PropostaPacienteSerasaConsultas_F_N", gxTv_SdtProposta_Propostapacienteserasaconsultas_f_N, false, includeNonInitialized);
            AddObjectProperty("PropostaSerasaScoreUltimaData_F_N", gxTv_SdtProposta_Propostaserasascoreultimadata_f_N, false, includeNonInitialized);
            AddObjectProperty("PropostaPacienteSerasaUltimoValorRecomendado_F_N", gxTv_SdtProposta_Propostapacienteserasaultimovalorrecomendado_f_N, false, includeNonInitialized);
            AddObjectProperty("PropostaValorTaxaClinica_F_N", gxTv_SdtProposta_Propostavalortaxaclinica_f_N, false, includeNonInitialized);
            AddObjectProperty("PropostaQtdDocumentoPendente_F_N", gxTv_SdtProposta_Propostaqtddocumentopendente_f_N, false, includeNonInitialized);
            AddObjectProperty("PropostaTitulo_N", gxTv_SdtProposta_Propostatitulo_N, false, includeNonInitialized);
            AddObjectProperty("ProcedimentosMedicosId_N", gxTv_SdtProposta_Procedimentosmedicosid_N, false, includeNonInitialized);
            AddObjectProperty("PropostaDescricao_N", gxTv_SdtProposta_Propostadescricao_N, false, includeNonInitialized);
            AddObjectProperty("PropostaDataCirurgia_N", gxTv_SdtProposta_Propostadatacirurgia_N, false, includeNonInitialized);
            AddObjectProperty("PropostaValor_N", gxTv_SdtProposta_Propostavalor_N, false, includeNonInitialized);
            AddObjectProperty("PropostaValorLiquido_N", gxTv_SdtProposta_Propostavalorliquido_N, false, includeNonInitialized);
            AddObjectProperty("PropostaTaxaAdministrativa_N", gxTv_SdtProposta_Propostataxaadministrativa_N, false, includeNonInitialized);
            AddObjectProperty("PropostaSLA_N", gxTv_SdtProposta_Propostasla_N, false, includeNonInitialized);
            AddObjectProperty("PropostaJurosMora_N", gxTv_SdtProposta_Propostajurosmora_N, false, includeNonInitialized);
            AddObjectProperty("PropostaCreatedAt_N", gxTv_SdtProposta_Propostacreatedat_N, false, includeNonInitialized);
            AddObjectProperty("PropostaCratedBy_N", gxTv_SdtProposta_Propostacratedby_N, false, includeNonInitialized);
            AddObjectProperty("PropostaClinicaId_N", gxTv_SdtProposta_Propostaclinicaid_N, false, includeNonInitialized);
            AddObjectProperty("PropostaClinicaNome_N", gxTv_SdtProposta_Propostaclinicanome_N, false, includeNonInitialized);
            AddObjectProperty("PropostaClinicaNomeFantasia_N", gxTv_SdtProposta_Propostaclinicanomefantasia_N, false, includeNonInitialized);
            AddObjectProperty("PropostaClinicaDocumento_N", gxTv_SdtProposta_Propostaclinicadocumento_N, false, includeNonInitialized);
            AddObjectProperty("PropostaClinicaEmail_N", gxTv_SdtProposta_Propostaclinicaemail_N, false, includeNonInitialized);
            AddObjectProperty("PropostaSecUserName_N", gxTv_SdtProposta_Propostasecusername_N, false, includeNonInitialized);
            AddObjectProperty("PropostaStatus_N", gxTv_SdtProposta_Propostastatus_N, false, includeNonInitialized);
            AddObjectProperty("PropostaComentarioAnalise_N", gxTv_SdtProposta_Propostacomentarioanalise_N, false, includeNonInitialized);
            AddObjectProperty("PropostaQuantidadeAprovadores_N", gxTv_SdtProposta_Propostaquantidadeaprovadores_N, false, includeNonInitialized);
            AddObjectProperty("PropostaReprovacoesPermitidas_N", gxTv_SdtProposta_Propostareprovacoespermitidas_N, false, includeNonInitialized);
            AddObjectProperty("ContratoId_N", gxTv_SdtProposta_Contratoid_N, false, includeNonInitialized);
            AddObjectProperty("ContratoNome_N", gxTv_SdtProposta_Contratonome_N, false, includeNonInitialized);
            AddObjectProperty("ConvenioId_N", gxTv_SdtProposta_Convenioid_N, false, includeNonInitialized);
            AddObjectProperty("ConvenioVencimentoAno_N", gxTv_SdtProposta_Conveniovencimentoano_N, false, includeNonInitialized);
            AddObjectProperty("ConvenioVencimentoMes_N", gxTv_SdtProposta_Conveniovencimentomes_N, false, includeNonInitialized);
            AddObjectProperty("ConvenioCategoriaId_N", gxTv_SdtProposta_Conveniocategoriaid_N, false, includeNonInitialized);
            AddObjectProperty("ConvenioCategoriaDescricao_N", gxTv_SdtProposta_Conveniocategoriadescricao_N, false, includeNonInitialized);
            AddObjectProperty("PropostaDataCreditoCliente_F_N", gxTv_SdtProposta_Propostadatacreditocliente_f_N, false, includeNonInitialized);
            AddObjectProperty("PropostaValorReembolsado_F_N", gxTv_SdtProposta_Propostavalorreembolsado_f_N, false, includeNonInitialized);
            AddObjectProperty("PropostaValorReembolsadoJuros_F_N", gxTv_SdtProposta_Propostavalorreembolsadojuros_f_N, false, includeNonInitialized);
            AddObjectProperty("PropostaValorTaxaRecebida_F_N", gxTv_SdtProposta_Propostavalortaxarecebida_f_N, false, includeNonInitialized);
            AddObjectProperty("PropostaAprovacoes_F_N", gxTv_SdtProposta_Propostaaprovacoes_f_N, false, includeNonInitialized);
            AddObjectProperty("PropostaReprovacoes_F_N", gxTv_SdtProposta_Propostareprovacoes_f_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtProposta sdt )
      {
         if ( sdt.IsDirty("PropostaId") )
         {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaid = sdt.gxTv_SdtProposta_Propostaid ;
         }
         if ( sdt.IsDirty("PropostaMaxReembolsoId_F") )
         {
            gxTv_SdtProposta_Propostamaxreembolsoid_f_N = (short)(sdt.gxTv_SdtProposta_Propostamaxreembolsoid_f_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostamaxreembolsoid_f = sdt.gxTv_SdtProposta_Propostamaxreembolsoid_f ;
         }
         if ( sdt.IsDirty("PropostaProtocolo") )
         {
            gxTv_SdtProposta_Propostaprotocolo_N = (short)(sdt.gxTv_SdtProposta_Propostaprotocolo_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaprotocolo = sdt.gxTv_SdtProposta_Propostaprotocolo ;
         }
         if ( sdt.IsDirty("PropostaEmpresaClienteId") )
         {
            gxTv_SdtProposta_Propostaempresaclienteid_N = (short)(sdt.gxTv_SdtProposta_Propostaempresaclienteid_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaempresaclienteid = sdt.gxTv_SdtProposta_Propostaempresaclienteid ;
         }
         if ( sdt.IsDirty("PropostaTipoProposta") )
         {
            gxTv_SdtProposta_Propostatipoproposta_N = (short)(sdt.gxTv_SdtProposta_Propostatipoproposta_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostatipoproposta = sdt.gxTv_SdtProposta_Propostatipoproposta ;
         }
         if ( sdt.IsDirty("PropostaPacienteClienteId") )
         {
            gxTv_SdtProposta_Propostapacienteclienteid_N = (short)(sdt.gxTv_SdtProposta_Propostapacienteclienteid_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacienteclienteid = sdt.gxTv_SdtProposta_Propostapacienteclienteid ;
         }
         if ( sdt.IsDirty("PropostaQtdItensNota_F") )
         {
            gxTv_SdtProposta_Propostaqtditensnota_f_N = (short)(sdt.gxTv_SdtProposta_Propostaqtditensnota_f_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaqtditensnota_f = sdt.gxTv_SdtProposta_Propostaqtditensnota_f ;
         }
         if ( sdt.IsDirty("PropostaResponsavelId") )
         {
            gxTv_SdtProposta_Propostaresponsavelid_N = (short)(sdt.gxTv_SdtProposta_Propostaresponsavelid_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaresponsavelid = sdt.gxTv_SdtProposta_Propostaresponsavelid ;
         }
         if ( sdt.IsDirty("PropostaResponsavelDocumento") )
         {
            gxTv_SdtProposta_Propostaresponsaveldocumento_N = (short)(sdt.gxTv_SdtProposta_Propostaresponsaveldocumento_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaresponsaveldocumento = sdt.gxTv_SdtProposta_Propostaresponsaveldocumento ;
         }
         if ( sdt.IsDirty("PropostaResponsavelRazaoSocial") )
         {
            gxTv_SdtProposta_Propostaresponsavelrazaosocial_N = (short)(sdt.gxTv_SdtProposta_Propostaresponsavelrazaosocial_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaresponsavelrazaosocial = sdt.gxTv_SdtProposta_Propostaresponsavelrazaosocial ;
         }
         if ( sdt.IsDirty("PropostaResponsavelEmail") )
         {
            gxTv_SdtProposta_Propostaresponsavelemail_N = (short)(sdt.gxTv_SdtProposta_Propostaresponsavelemail_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaresponsavelemail = sdt.gxTv_SdtProposta_Propostaresponsavelemail ;
         }
         if ( sdt.IsDirty("PropostaResponsavelBanco") )
         {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaresponsavelbanco = sdt.gxTv_SdtProposta_Propostaresponsavelbanco ;
         }
         if ( sdt.IsDirty("PropostaResponsavelConta") )
         {
            gxTv_SdtProposta_Propostaresponsavelconta_N = (short)(sdt.gxTv_SdtProposta_Propostaresponsavelconta_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaresponsavelconta = sdt.gxTv_SdtProposta_Propostaresponsavelconta ;
         }
         if ( sdt.IsDirty("PropostaResponsavelAgencia") )
         {
            gxTv_SdtProposta_Propostaresponsavelagencia_N = (short)(sdt.gxTv_SdtProposta_Propostaresponsavelagencia_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaresponsavelagencia = sdt.gxTv_SdtProposta_Propostaresponsavelagencia ;
         }
         if ( sdt.IsDirty("PropostaResponsavelTipoPix") )
         {
            gxTv_SdtProposta_Propostaresponsaveltipopix_N = (short)(sdt.gxTv_SdtProposta_Propostaresponsaveltipopix_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaresponsaveltipopix = sdt.gxTv_SdtProposta_Propostaresponsaveltipopix ;
         }
         if ( sdt.IsDirty("PropostaResponsavelPIX") )
         {
            gxTv_SdtProposta_Propostaresponsavelpix_N = (short)(sdt.gxTv_SdtProposta_Propostaresponsavelpix_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaresponsavelpix = sdt.gxTv_SdtProposta_Propostaresponsavelpix ;
         }
         if ( sdt.IsDirty("PropostaResponsavelDepositoTipo") )
         {
            gxTv_SdtProposta_Propostaresponsaveldepositotipo_N = (short)(sdt.gxTv_SdtProposta_Propostaresponsaveldepositotipo_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaresponsaveldepositotipo = sdt.gxTv_SdtProposta_Propostaresponsaveldepositotipo ;
         }
         if ( sdt.IsDirty("PropostaResponsavelSerasaConsultas_F") )
         {
            gxTv_SdtProposta_Propostaresponsavelserasaconsultas_f_N = (short)(sdt.gxTv_SdtProposta_Propostaresponsavelserasaconsultas_f_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaresponsavelserasaconsultas_f = sdt.gxTv_SdtProposta_Propostaresponsavelserasaconsultas_f ;
         }
         if ( sdt.IsDirty("PropostaResponsavelSerasaScoreUltimaData_F") )
         {
            gxTv_SdtProposta_Propostaresponsavelserasascoreultimadata_f_N = (short)(sdt.gxTv_SdtProposta_Propostaresponsavelserasascoreultimadata_f_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaresponsavelserasascoreultimadata_f = sdt.gxTv_SdtProposta_Propostaresponsavelserasascoreultimadata_f ;
         }
         if ( sdt.IsDirty("PropostaResponsavelSerasaUltimoValorRecomendado_F") )
         {
            gxTv_SdtProposta_Propostaresponsavelserasaultimovalorrecomendado_f_N = (short)(sdt.gxTv_SdtProposta_Propostaresponsavelserasaultimovalorrecomendado_f_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaresponsavelserasaultimovalorrecomendado_f = sdt.gxTv_SdtProposta_Propostaresponsavelserasaultimovalorrecomendado_f ;
         }
         if ( sdt.IsDirty("PropostaPacienteClienteRazaoSocial") )
         {
            gxTv_SdtProposta_Propostapacienteclienterazaosocial_N = (short)(sdt.gxTv_SdtProposta_Propostapacienteclienterazaosocial_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacienteclienterazaosocial = sdt.gxTv_SdtProposta_Propostapacienteclienterazaosocial ;
         }
         if ( sdt.IsDirty("PropostaPacienteClienteDocumento") )
         {
            gxTv_SdtProposta_Propostapacienteclientedocumento_N = (short)(sdt.gxTv_SdtProposta_Propostapacienteclientedocumento_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacienteclientedocumento = sdt.gxTv_SdtProposta_Propostapacienteclientedocumento ;
         }
         if ( sdt.IsDirty("PropostaPacienteContatoEmail") )
         {
            gxTv_SdtProposta_Propostapacientecontatoemail_N = (short)(sdt.gxTv_SdtProposta_Propostapacientecontatoemail_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacientecontatoemail = sdt.gxTv_SdtProposta_Propostapacientecontatoemail ;
         }
         if ( sdt.IsDirty("PropostaPacienteBanco") )
         {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacientebanco = sdt.gxTv_SdtProposta_Propostapacientebanco ;
         }
         if ( sdt.IsDirty("PropostaPacienteConta") )
         {
            gxTv_SdtProposta_Propostapacienteconta_N = (short)(sdt.gxTv_SdtProposta_Propostapacienteconta_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacienteconta = sdt.gxTv_SdtProposta_Propostapacienteconta ;
         }
         if ( sdt.IsDirty("PropostaPacienteAgencia") )
         {
            gxTv_SdtProposta_Propostapacienteagencia_N = (short)(sdt.gxTv_SdtProposta_Propostapacienteagencia_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacienteagencia = sdt.gxTv_SdtProposta_Propostapacienteagencia ;
         }
         if ( sdt.IsDirty("PropostaPacienteTipoPix") )
         {
            gxTv_SdtProposta_Propostapacientetipopix_N = (short)(sdt.gxTv_SdtProposta_Propostapacientetipopix_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacientetipopix = sdt.gxTv_SdtProposta_Propostapacientetipopix ;
         }
         if ( sdt.IsDirty("PropostaPacientePIX") )
         {
            gxTv_SdtProposta_Propostapacientepix_N = (short)(sdt.gxTv_SdtProposta_Propostapacientepix_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacientepix = sdt.gxTv_SdtProposta_Propostapacientepix ;
         }
         if ( sdt.IsDirty("PropostaPacienteDepositoTipo") )
         {
            gxTv_SdtProposta_Propostapacientedepositotipo_N = (short)(sdt.gxTv_SdtProposta_Propostapacientedepositotipo_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacientedepositotipo = sdt.gxTv_SdtProposta_Propostapacientedepositotipo ;
         }
         if ( sdt.IsDirty("PropostaPacienteEnderecoCEP") )
         {
            gxTv_SdtProposta_Propostapacienteenderecocep_N = (short)(sdt.gxTv_SdtProposta_Propostapacienteenderecocep_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacienteenderecocep = sdt.gxTv_SdtProposta_Propostapacienteenderecocep ;
         }
         if ( sdt.IsDirty("PropostaPacienteEnderecoLogradouro") )
         {
            gxTv_SdtProposta_Propostapacienteenderecologradouro_N = (short)(sdt.gxTv_SdtProposta_Propostapacienteenderecologradouro_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacienteenderecologradouro = sdt.gxTv_SdtProposta_Propostapacienteenderecologradouro ;
         }
         if ( sdt.IsDirty("PropostaPacienteEnderecoNumero") )
         {
            gxTv_SdtProposta_Propostapacienteendereconumero_N = (short)(sdt.gxTv_SdtProposta_Propostapacienteendereconumero_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacienteendereconumero = sdt.gxTv_SdtProposta_Propostapacienteendereconumero ;
         }
         if ( sdt.IsDirty("PropostaPacienteEnderecoComplemento") )
         {
            gxTv_SdtProposta_Propostapacienteenderecocomplemento_N = (short)(sdt.gxTv_SdtProposta_Propostapacienteenderecocomplemento_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacienteenderecocomplemento = sdt.gxTv_SdtProposta_Propostapacienteenderecocomplemento ;
         }
         if ( sdt.IsDirty("PropostaPacienteEnderecoBairro") )
         {
            gxTv_SdtProposta_Propostapacienteenderecobairro_N = (short)(sdt.gxTv_SdtProposta_Propostapacienteenderecobairro_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacienteenderecobairro = sdt.gxTv_SdtProposta_Propostapacienteenderecobairro ;
         }
         if ( sdt.IsDirty("PropostaPacienteMunicipioCodigo") )
         {
            gxTv_SdtProposta_Propostapacientemunicipiocodigo_N = (short)(sdt.gxTv_SdtProposta_Propostapacientemunicipiocodigo_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacientemunicipiocodigo = sdt.gxTv_SdtProposta_Propostapacientemunicipiocodigo ;
         }
         if ( sdt.IsDirty("PropostaPacienteSerasaConsultas_F") )
         {
            gxTv_SdtProposta_Propostapacienteserasaconsultas_f_N = (short)(sdt.gxTv_SdtProposta_Propostapacienteserasaconsultas_f_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacienteserasaconsultas_f = sdt.gxTv_SdtProposta_Propostapacienteserasaconsultas_f ;
         }
         if ( sdt.IsDirty("PropostaSerasaScoreUltimaData_F") )
         {
            gxTv_SdtProposta_Propostaserasascoreultimadata_f_N = (short)(sdt.gxTv_SdtProposta_Propostaserasascoreultimadata_f_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaserasascoreultimadata_f = sdt.gxTv_SdtProposta_Propostaserasascoreultimadata_f ;
         }
         if ( sdt.IsDirty("PropostaPacienteSerasaUltimoValorRecomendado_F") )
         {
            gxTv_SdtProposta_Propostapacienteserasaultimovalorrecomendado_f_N = (short)(sdt.gxTv_SdtProposta_Propostapacienteserasaultimovalorrecomendado_f_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacienteserasaultimovalorrecomendado_f = sdt.gxTv_SdtProposta_Propostapacienteserasaultimovalorrecomendado_f ;
         }
         if ( sdt.IsDirty("PropostaValorTaxaClinica_F") )
         {
            gxTv_SdtProposta_Propostavalortaxaclinica_f_N = (short)(sdt.gxTv_SdtProposta_Propostavalortaxaclinica_f_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostavalortaxaclinica_f = sdt.gxTv_SdtProposta_Propostavalortaxaclinica_f ;
         }
         if ( sdt.IsDirty("PropostaQtdDocumentoPendente_F") )
         {
            gxTv_SdtProposta_Propostaqtddocumentopendente_f_N = (short)(sdt.gxTv_SdtProposta_Propostaqtddocumentopendente_f_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaqtddocumentopendente_f = sdt.gxTv_SdtProposta_Propostaqtddocumentopendente_f ;
         }
         if ( sdt.IsDirty("PropostaMaiorScore_F") )
         {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostamaiorscore_f = sdt.gxTv_SdtProposta_Propostamaiorscore_f ;
         }
         if ( sdt.IsDirty("PropostaMaiorValorRecomendado") )
         {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostamaiorvalorrecomendado = sdt.gxTv_SdtProposta_Propostamaiorvalorrecomendado ;
         }
         if ( sdt.IsDirty("PropostaTitulo") )
         {
            gxTv_SdtProposta_Propostatitulo_N = (short)(sdt.gxTv_SdtProposta_Propostatitulo_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostatitulo = sdt.gxTv_SdtProposta_Propostatitulo ;
         }
         if ( sdt.IsDirty("ProcedimentosMedicosId") )
         {
            gxTv_SdtProposta_Procedimentosmedicosid_N = (short)(sdt.gxTv_SdtProposta_Procedimentosmedicosid_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Procedimentosmedicosid = sdt.gxTv_SdtProposta_Procedimentosmedicosid ;
         }
         if ( sdt.IsDirty("PropostaDescricao") )
         {
            gxTv_SdtProposta_Propostadescricao_N = (short)(sdt.gxTv_SdtProposta_Propostadescricao_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostadescricao = sdt.gxTv_SdtProposta_Propostadescricao ;
         }
         if ( sdt.IsDirty("PropostaDataCirurgia") )
         {
            gxTv_SdtProposta_Propostadatacirurgia_N = (short)(sdt.gxTv_SdtProposta_Propostadatacirurgia_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostadatacirurgia = sdt.gxTv_SdtProposta_Propostadatacirurgia ;
         }
         if ( sdt.IsDirty("PropostaValor") )
         {
            gxTv_SdtProposta_Propostavalor_N = (short)(sdt.gxTv_SdtProposta_Propostavalor_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostavalor = sdt.gxTv_SdtProposta_Propostavalor ;
         }
         if ( sdt.IsDirty("PropostaValorLiquido") )
         {
            gxTv_SdtProposta_Propostavalorliquido_N = (short)(sdt.gxTv_SdtProposta_Propostavalorliquido_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostavalorliquido = sdt.gxTv_SdtProposta_Propostavalorliquido ;
         }
         if ( sdt.IsDirty("PropostaTaxaAdministrativa") )
         {
            gxTv_SdtProposta_Propostataxaadministrativa_N = (short)(sdt.gxTv_SdtProposta_Propostataxaadministrativa_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostataxaadministrativa = sdt.gxTv_SdtProposta_Propostataxaadministrativa ;
         }
         if ( sdt.IsDirty("PropostaTaxa_F") )
         {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostataxa_f = sdt.gxTv_SdtProposta_Propostataxa_f ;
         }
         if ( sdt.IsDirty("PropostaSLA") )
         {
            gxTv_SdtProposta_Propostasla_N = (short)(sdt.gxTv_SdtProposta_Propostasla_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostasla = sdt.gxTv_SdtProposta_Propostasla ;
         }
         if ( sdt.IsDirty("PropostaJurosMora") )
         {
            gxTv_SdtProposta_Propostajurosmora_N = (short)(sdt.gxTv_SdtProposta_Propostajurosmora_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostajurosmora = sdt.gxTv_SdtProposta_Propostajurosmora ;
         }
         if ( sdt.IsDirty("PropostaCreatedAt") )
         {
            gxTv_SdtProposta_Propostacreatedat_N = (short)(sdt.gxTv_SdtProposta_Propostacreatedat_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostacreatedat = sdt.gxTv_SdtProposta_Propostacreatedat ;
         }
         if ( sdt.IsDirty("PropostaCratedBy") )
         {
            gxTv_SdtProposta_Propostacratedby_N = (short)(sdt.gxTv_SdtProposta_Propostacratedby_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostacratedby = sdt.gxTv_SdtProposta_Propostacratedby ;
         }
         if ( sdt.IsDirty("PropostaClinicaId") )
         {
            gxTv_SdtProposta_Propostaclinicaid_N = (short)(sdt.gxTv_SdtProposta_Propostaclinicaid_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaclinicaid = sdt.gxTv_SdtProposta_Propostaclinicaid ;
         }
         if ( sdt.IsDirty("PropostaClinicaNome") )
         {
            gxTv_SdtProposta_Propostaclinicanome_N = (short)(sdt.gxTv_SdtProposta_Propostaclinicanome_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaclinicanome = sdt.gxTv_SdtProposta_Propostaclinicanome ;
         }
         if ( sdt.IsDirty("PropostaClinicaNomeFantasia") )
         {
            gxTv_SdtProposta_Propostaclinicanomefantasia_N = (short)(sdt.gxTv_SdtProposta_Propostaclinicanomefantasia_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaclinicanomefantasia = sdt.gxTv_SdtProposta_Propostaclinicanomefantasia ;
         }
         if ( sdt.IsDirty("PropostaClinicaDocumento") )
         {
            gxTv_SdtProposta_Propostaclinicadocumento_N = (short)(sdt.gxTv_SdtProposta_Propostaclinicadocumento_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaclinicadocumento = sdt.gxTv_SdtProposta_Propostaclinicadocumento ;
         }
         if ( sdt.IsDirty("PropostaClinicaEmail") )
         {
            gxTv_SdtProposta_Propostaclinicaemail_N = (short)(sdt.gxTv_SdtProposta_Propostaclinicaemail_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaclinicaemail = sdt.gxTv_SdtProposta_Propostaclinicaemail ;
         }
         if ( sdt.IsDirty("PropostaSecUserName") )
         {
            gxTv_SdtProposta_Propostasecusername_N = (short)(sdt.gxTv_SdtProposta_Propostasecusername_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostasecusername = sdt.gxTv_SdtProposta_Propostasecusername ;
         }
         if ( sdt.IsDirty("PropostaStatus") )
         {
            gxTv_SdtProposta_Propostastatus_N = (short)(sdt.gxTv_SdtProposta_Propostastatus_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostastatus = sdt.gxTv_SdtProposta_Propostastatus ;
         }
         if ( sdt.IsDirty("PropostaComentarioAnalise") )
         {
            gxTv_SdtProposta_Propostacomentarioanalise_N = (short)(sdt.gxTv_SdtProposta_Propostacomentarioanalise_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostacomentarioanalise = sdt.gxTv_SdtProposta_Propostacomentarioanalise ;
         }
         if ( sdt.IsDirty("PropostaQuantidadeAprovadores") )
         {
            gxTv_SdtProposta_Propostaquantidadeaprovadores_N = (short)(sdt.gxTv_SdtProposta_Propostaquantidadeaprovadores_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaquantidadeaprovadores = sdt.gxTv_SdtProposta_Propostaquantidadeaprovadores ;
         }
         if ( sdt.IsDirty("PropostaReprovacoesPermitidas") )
         {
            gxTv_SdtProposta_Propostareprovacoespermitidas_N = (short)(sdt.gxTv_SdtProposta_Propostareprovacoespermitidas_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostareprovacoespermitidas = sdt.gxTv_SdtProposta_Propostareprovacoespermitidas ;
         }
         if ( sdt.IsDirty("ContratoId") )
         {
            gxTv_SdtProposta_Contratoid_N = (short)(sdt.gxTv_SdtProposta_Contratoid_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Contratoid = sdt.gxTv_SdtProposta_Contratoid ;
         }
         if ( sdt.IsDirty("ContratoNome") )
         {
            gxTv_SdtProposta_Contratonome_N = (short)(sdt.gxTv_SdtProposta_Contratonome_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Contratonome = sdt.gxTv_SdtProposta_Contratonome ;
         }
         if ( sdt.IsDirty("ConvenioId") )
         {
            gxTv_SdtProposta_Convenioid_N = (short)(sdt.gxTv_SdtProposta_Convenioid_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Convenioid = sdt.gxTv_SdtProposta_Convenioid ;
         }
         if ( sdt.IsDirty("ConvenioVencimentoAno") )
         {
            gxTv_SdtProposta_Conveniovencimentoano_N = (short)(sdt.gxTv_SdtProposta_Conveniovencimentoano_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Conveniovencimentoano = sdt.gxTv_SdtProposta_Conveniovencimentoano ;
         }
         if ( sdt.IsDirty("ConvenioVencimentoMes") )
         {
            gxTv_SdtProposta_Conveniovencimentomes_N = (short)(sdt.gxTv_SdtProposta_Conveniovencimentomes_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Conveniovencimentomes = sdt.gxTv_SdtProposta_Conveniovencimentomes ;
         }
         if ( sdt.IsDirty("ConvenioCategoriaId") )
         {
            gxTv_SdtProposta_Conveniocategoriaid_N = (short)(sdt.gxTv_SdtProposta_Conveniocategoriaid_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Conveniocategoriaid = sdt.gxTv_SdtProposta_Conveniocategoriaid ;
         }
         if ( sdt.IsDirty("ConvenioCategoriaDescricao") )
         {
            gxTv_SdtProposta_Conveniocategoriadescricao_N = (short)(sdt.gxTv_SdtProposta_Conveniocategoriadescricao_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Conveniocategoriadescricao = sdt.gxTv_SdtProposta_Conveniocategoriadescricao ;
         }
         if ( sdt.IsDirty("PropostaDataCreditoCliente_F") )
         {
            gxTv_SdtProposta_Propostadatacreditocliente_f_N = (short)(sdt.gxTv_SdtProposta_Propostadatacreditocliente_f_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostadatacreditocliente_f = sdt.gxTv_SdtProposta_Propostadatacreditocliente_f ;
         }
         if ( sdt.IsDirty("PropostaValorTaxa_F") )
         {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostavalortaxa_f = sdt.gxTv_SdtProposta_Propostavalortaxa_f ;
         }
         if ( sdt.IsDirty("PropostaValorJurosMora_F") )
         {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostavalorjurosmora_f = sdt.gxTv_SdtProposta_Propostavalorjurosmora_f ;
         }
         if ( sdt.IsDirty("PropostaValorReembolsado_F") )
         {
            gxTv_SdtProposta_Propostavalorreembolsado_f_N = (short)(sdt.gxTv_SdtProposta_Propostavalorreembolsado_f_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostavalorreembolsado_f = sdt.gxTv_SdtProposta_Propostavalorreembolsado_f ;
         }
         if ( sdt.IsDirty("PropostaValorReembolsadoJuros_F") )
         {
            gxTv_SdtProposta_Propostavalorreembolsadojuros_f_N = (short)(sdt.gxTv_SdtProposta_Propostavalorreembolsadojuros_f_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostavalorreembolsadojuros_f = sdt.gxTv_SdtProposta_Propostavalorreembolsadojuros_f ;
         }
         if ( sdt.IsDirty("PropostaValorTaxaRecebida_F") )
         {
            gxTv_SdtProposta_Propostavalortaxarecebida_f_N = (short)(sdt.gxTv_SdtProposta_Propostavalortaxarecebida_f_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostavalortaxarecebida_f = sdt.gxTv_SdtProposta_Propostavalortaxarecebida_f ;
         }
         if ( sdt.IsDirty("PropostaAprovacoes_F") )
         {
            gxTv_SdtProposta_Propostaaprovacoes_f_N = (short)(sdt.gxTv_SdtProposta_Propostaaprovacoes_f_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaaprovacoes_f = sdt.gxTv_SdtProposta_Propostaaprovacoes_f ;
         }
         if ( sdt.IsDirty("PropostaReprovacoes_F") )
         {
            gxTv_SdtProposta_Propostareprovacoes_f_N = (short)(sdt.gxTv_SdtProposta_Propostareprovacoes_f_N);
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostareprovacoes_f = sdt.gxTv_SdtProposta_Propostareprovacoes_f ;
         }
         if ( sdt.IsDirty("PropostaAprovacoesRestantes_F") )
         {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaaprovacoesrestantes_f = sdt.gxTv_SdtProposta_Propostaaprovacoesrestantes_f ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "PropostaId" )]
      [  XmlElement( ElementName = "PropostaId"   )]
      public int gxTpr_Propostaid
      {
         get {
            return gxTv_SdtProposta_Propostaid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtProposta_Propostaid != value )
            {
               gxTv_SdtProposta_Mode = "INS";
               this.gxTv_SdtProposta_Propostaid_Z_SetNull( );
               this.gxTv_SdtProposta_Propostamaxreembolsoid_f_Z_SetNull( );
               this.gxTv_SdtProposta_Propostaprotocolo_Z_SetNull( );
               this.gxTv_SdtProposta_Propostaempresaclienteid_Z_SetNull( );
               this.gxTv_SdtProposta_Propostatipoproposta_Z_SetNull( );
               this.gxTv_SdtProposta_Propostapacienteclienteid_Z_SetNull( );
               this.gxTv_SdtProposta_Propostaqtditensnota_f_Z_SetNull( );
               this.gxTv_SdtProposta_Propostaresponsavelid_Z_SetNull( );
               this.gxTv_SdtProposta_Propostaresponsaveldocumento_Z_SetNull( );
               this.gxTv_SdtProposta_Propostaresponsavelrazaosocial_Z_SetNull( );
               this.gxTv_SdtProposta_Propostaresponsavelemail_Z_SetNull( );
               this.gxTv_SdtProposta_Propostaresponsavelbanco_Z_SetNull( );
               this.gxTv_SdtProposta_Propostaresponsavelconta_Z_SetNull( );
               this.gxTv_SdtProposta_Propostaresponsavelagencia_Z_SetNull( );
               this.gxTv_SdtProposta_Propostaresponsaveltipopix_Z_SetNull( );
               this.gxTv_SdtProposta_Propostaresponsavelpix_Z_SetNull( );
               this.gxTv_SdtProposta_Propostaresponsaveldepositotipo_Z_SetNull( );
               this.gxTv_SdtProposta_Propostaresponsavelserasaconsultas_f_Z_SetNull( );
               this.gxTv_SdtProposta_Propostaresponsavelserasascoreultimadata_f_Z_SetNull( );
               this.gxTv_SdtProposta_Propostaresponsavelserasaultimovalorrecomendado_f_Z_SetNull( );
               this.gxTv_SdtProposta_Propostapacienteclienterazaosocial_Z_SetNull( );
               this.gxTv_SdtProposta_Propostapacienteclientedocumento_Z_SetNull( );
               this.gxTv_SdtProposta_Propostapacientecontatoemail_Z_SetNull( );
               this.gxTv_SdtProposta_Propostapacientebanco_Z_SetNull( );
               this.gxTv_SdtProposta_Propostapacienteconta_Z_SetNull( );
               this.gxTv_SdtProposta_Propostapacienteagencia_Z_SetNull( );
               this.gxTv_SdtProposta_Propostapacientetipopix_Z_SetNull( );
               this.gxTv_SdtProposta_Propostapacientepix_Z_SetNull( );
               this.gxTv_SdtProposta_Propostapacientedepositotipo_Z_SetNull( );
               this.gxTv_SdtProposta_Propostapacienteenderecocep_Z_SetNull( );
               this.gxTv_SdtProposta_Propostapacienteenderecologradouro_Z_SetNull( );
               this.gxTv_SdtProposta_Propostapacienteendereconumero_Z_SetNull( );
               this.gxTv_SdtProposta_Propostapacienteenderecocomplemento_Z_SetNull( );
               this.gxTv_SdtProposta_Propostapacienteenderecobairro_Z_SetNull( );
               this.gxTv_SdtProposta_Propostapacientemunicipiocodigo_Z_SetNull( );
               this.gxTv_SdtProposta_Propostapacienteserasaconsultas_f_Z_SetNull( );
               this.gxTv_SdtProposta_Propostaserasascoreultimadata_f_Z_SetNull( );
               this.gxTv_SdtProposta_Propostapacienteserasaultimovalorrecomendado_f_Z_SetNull( );
               this.gxTv_SdtProposta_Propostavalortaxaclinica_f_Z_SetNull( );
               this.gxTv_SdtProposta_Propostaqtddocumentopendente_f_Z_SetNull( );
               this.gxTv_SdtProposta_Propostamaiorscore_f_Z_SetNull( );
               this.gxTv_SdtProposta_Propostamaiorvalorrecomendado_Z_SetNull( );
               this.gxTv_SdtProposta_Propostatitulo_Z_SetNull( );
               this.gxTv_SdtProposta_Procedimentosmedicosid_Z_SetNull( );
               this.gxTv_SdtProposta_Propostadescricao_Z_SetNull( );
               this.gxTv_SdtProposta_Propostadatacirurgia_Z_SetNull( );
               this.gxTv_SdtProposta_Propostavalor_Z_SetNull( );
               this.gxTv_SdtProposta_Propostavalorliquido_Z_SetNull( );
               this.gxTv_SdtProposta_Propostataxaadministrativa_Z_SetNull( );
               this.gxTv_SdtProposta_Propostataxa_f_Z_SetNull( );
               this.gxTv_SdtProposta_Propostasla_Z_SetNull( );
               this.gxTv_SdtProposta_Propostajurosmora_Z_SetNull( );
               this.gxTv_SdtProposta_Propostacreatedat_Z_SetNull( );
               this.gxTv_SdtProposta_Propostacratedby_Z_SetNull( );
               this.gxTv_SdtProposta_Propostaclinicaid_Z_SetNull( );
               this.gxTv_SdtProposta_Propostaclinicanome_Z_SetNull( );
               this.gxTv_SdtProposta_Propostaclinicanomefantasia_Z_SetNull( );
               this.gxTv_SdtProposta_Propostaclinicadocumento_Z_SetNull( );
               this.gxTv_SdtProposta_Propostaclinicaemail_Z_SetNull( );
               this.gxTv_SdtProposta_Propostasecusername_Z_SetNull( );
               this.gxTv_SdtProposta_Propostastatus_Z_SetNull( );
               this.gxTv_SdtProposta_Propostacomentarioanalise_Z_SetNull( );
               this.gxTv_SdtProposta_Propostaquantidadeaprovadores_Z_SetNull( );
               this.gxTv_SdtProposta_Propostareprovacoespermitidas_Z_SetNull( );
               this.gxTv_SdtProposta_Contratoid_Z_SetNull( );
               this.gxTv_SdtProposta_Contratonome_Z_SetNull( );
               this.gxTv_SdtProposta_Convenioid_Z_SetNull( );
               this.gxTv_SdtProposta_Conveniovencimentoano_Z_SetNull( );
               this.gxTv_SdtProposta_Conveniovencimentomes_Z_SetNull( );
               this.gxTv_SdtProposta_Conveniocategoriaid_Z_SetNull( );
               this.gxTv_SdtProposta_Conveniocategoriadescricao_Z_SetNull( );
               this.gxTv_SdtProposta_Propostadatacreditocliente_f_Z_SetNull( );
               this.gxTv_SdtProposta_Propostavalortaxa_f_Z_SetNull( );
               this.gxTv_SdtProposta_Propostavalorjurosmora_f_Z_SetNull( );
               this.gxTv_SdtProposta_Propostavalorreembolsado_f_Z_SetNull( );
               this.gxTv_SdtProposta_Propostavalorreembolsadojuros_f_Z_SetNull( );
               this.gxTv_SdtProposta_Propostavalortaxarecebida_f_Z_SetNull( );
               this.gxTv_SdtProposta_Propostaaprovacoes_f_Z_SetNull( );
               this.gxTv_SdtProposta_Propostareprovacoes_f_Z_SetNull( );
               this.gxTv_SdtProposta_Propostaaprovacoesrestantes_f_Z_SetNull( );
            }
            gxTv_SdtProposta_Propostaid = value;
            SetDirty("Propostaid");
         }

      }

      [  SoapElement( ElementName = "PropostaMaxReembolsoId_F" )]
      [  XmlElement( ElementName = "PropostaMaxReembolsoId_F"   )]
      public int gxTpr_Propostamaxreembolsoid_f
      {
         get {
            return gxTv_SdtProposta_Propostamaxreembolsoid_f ;
         }

         set {
            gxTv_SdtProposta_Propostamaxreembolsoid_f_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostamaxreembolsoid_f = value;
            SetDirty("Propostamaxreembolsoid_f");
         }

      }

      public void gxTv_SdtProposta_Propostamaxreembolsoid_f_SetNull( )
      {
         gxTv_SdtProposta_Propostamaxreembolsoid_f_N = 1;
         gxTv_SdtProposta_Propostamaxreembolsoid_f = 0;
         SetDirty("Propostamaxreembolsoid_f");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostamaxreembolsoid_f_IsNull( )
      {
         return (gxTv_SdtProposta_Propostamaxreembolsoid_f_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaProtocolo" )]
      [  XmlElement( ElementName = "PropostaProtocolo"   )]
      public string gxTpr_Propostaprotocolo
      {
         get {
            return gxTv_SdtProposta_Propostaprotocolo ;
         }

         set {
            gxTv_SdtProposta_Propostaprotocolo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaprotocolo = value;
            SetDirty("Propostaprotocolo");
         }

      }

      public void gxTv_SdtProposta_Propostaprotocolo_SetNull( )
      {
         gxTv_SdtProposta_Propostaprotocolo_N = 1;
         gxTv_SdtProposta_Propostaprotocolo = "";
         SetDirty("Propostaprotocolo");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaprotocolo_IsNull( )
      {
         return (gxTv_SdtProposta_Propostaprotocolo_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaEmpresaClienteId" )]
      [  XmlElement( ElementName = "PropostaEmpresaClienteId"   )]
      public int gxTpr_Propostaempresaclienteid
      {
         get {
            return gxTv_SdtProposta_Propostaempresaclienteid ;
         }

         set {
            gxTv_SdtProposta_Propostaempresaclienteid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaempresaclienteid = value;
            SetDirty("Propostaempresaclienteid");
         }

      }

      public void gxTv_SdtProposta_Propostaempresaclienteid_SetNull( )
      {
         gxTv_SdtProposta_Propostaempresaclienteid_N = 1;
         gxTv_SdtProposta_Propostaempresaclienteid = 0;
         SetDirty("Propostaempresaclienteid");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaempresaclienteid_IsNull( )
      {
         return (gxTv_SdtProposta_Propostaempresaclienteid_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaTipoProposta" )]
      [  XmlElement( ElementName = "PropostaTipoProposta"   )]
      public string gxTpr_Propostatipoproposta
      {
         get {
            return gxTv_SdtProposta_Propostatipoproposta ;
         }

         set {
            gxTv_SdtProposta_Propostatipoproposta_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostatipoproposta = value;
            SetDirty("Propostatipoproposta");
         }

      }

      public void gxTv_SdtProposta_Propostatipoproposta_SetNull( )
      {
         gxTv_SdtProposta_Propostatipoproposta_N = 1;
         gxTv_SdtProposta_Propostatipoproposta = "";
         SetDirty("Propostatipoproposta");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostatipoproposta_IsNull( )
      {
         return (gxTv_SdtProposta_Propostatipoproposta_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaPacienteClienteId" )]
      [  XmlElement( ElementName = "PropostaPacienteClienteId"   )]
      public int gxTpr_Propostapacienteclienteid
      {
         get {
            return gxTv_SdtProposta_Propostapacienteclienteid ;
         }

         set {
            gxTv_SdtProposta_Propostapacienteclienteid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacienteclienteid = value;
            SetDirty("Propostapacienteclienteid");
         }

      }

      public void gxTv_SdtProposta_Propostapacienteclienteid_SetNull( )
      {
         gxTv_SdtProposta_Propostapacienteclienteid_N = 1;
         gxTv_SdtProposta_Propostapacienteclienteid = 0;
         SetDirty("Propostapacienteclienteid");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostapacienteclienteid_IsNull( )
      {
         return (gxTv_SdtProposta_Propostapacienteclienteid_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaQtdItensNota_F" )]
      [  XmlElement( ElementName = "PropostaQtdItensNota_F"   )]
      public short gxTpr_Propostaqtditensnota_f
      {
         get {
            return gxTv_SdtProposta_Propostaqtditensnota_f ;
         }

         set {
            gxTv_SdtProposta_Propostaqtditensnota_f_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaqtditensnota_f = value;
            SetDirty("Propostaqtditensnota_f");
         }

      }

      public void gxTv_SdtProposta_Propostaqtditensnota_f_SetNull( )
      {
         gxTv_SdtProposta_Propostaqtditensnota_f_N = 1;
         gxTv_SdtProposta_Propostaqtditensnota_f = 0;
         SetDirty("Propostaqtditensnota_f");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaqtditensnota_f_IsNull( )
      {
         return (gxTv_SdtProposta_Propostaqtditensnota_f_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaResponsavelId" )]
      [  XmlElement( ElementName = "PropostaResponsavelId"   )]
      public int gxTpr_Propostaresponsavelid
      {
         get {
            return gxTv_SdtProposta_Propostaresponsavelid ;
         }

         set {
            gxTv_SdtProposta_Propostaresponsavelid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaresponsavelid = value;
            SetDirty("Propostaresponsavelid");
         }

      }

      public void gxTv_SdtProposta_Propostaresponsavelid_SetNull( )
      {
         gxTv_SdtProposta_Propostaresponsavelid_N = 1;
         gxTv_SdtProposta_Propostaresponsavelid = 0;
         SetDirty("Propostaresponsavelid");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaresponsavelid_IsNull( )
      {
         return (gxTv_SdtProposta_Propostaresponsavelid_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaResponsavelDocumento" )]
      [  XmlElement( ElementName = "PropostaResponsavelDocumento"   )]
      public string gxTpr_Propostaresponsaveldocumento
      {
         get {
            return gxTv_SdtProposta_Propostaresponsaveldocumento ;
         }

         set {
            gxTv_SdtProposta_Propostaresponsaveldocumento_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaresponsaveldocumento = value;
            SetDirty("Propostaresponsaveldocumento");
         }

      }

      public void gxTv_SdtProposta_Propostaresponsaveldocumento_SetNull( )
      {
         gxTv_SdtProposta_Propostaresponsaveldocumento_N = 1;
         gxTv_SdtProposta_Propostaresponsaveldocumento = "";
         SetDirty("Propostaresponsaveldocumento");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaresponsaveldocumento_IsNull( )
      {
         return (gxTv_SdtProposta_Propostaresponsaveldocumento_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaResponsavelRazaoSocial" )]
      [  XmlElement( ElementName = "PropostaResponsavelRazaoSocial"   )]
      public string gxTpr_Propostaresponsavelrazaosocial
      {
         get {
            return gxTv_SdtProposta_Propostaresponsavelrazaosocial ;
         }

         set {
            gxTv_SdtProposta_Propostaresponsavelrazaosocial_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaresponsavelrazaosocial = value;
            SetDirty("Propostaresponsavelrazaosocial");
         }

      }

      public void gxTv_SdtProposta_Propostaresponsavelrazaosocial_SetNull( )
      {
         gxTv_SdtProposta_Propostaresponsavelrazaosocial_N = 1;
         gxTv_SdtProposta_Propostaresponsavelrazaosocial = "";
         SetDirty("Propostaresponsavelrazaosocial");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaresponsavelrazaosocial_IsNull( )
      {
         return (gxTv_SdtProposta_Propostaresponsavelrazaosocial_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaResponsavelEmail" )]
      [  XmlElement( ElementName = "PropostaResponsavelEmail"   )]
      public string gxTpr_Propostaresponsavelemail
      {
         get {
            return gxTv_SdtProposta_Propostaresponsavelemail ;
         }

         set {
            gxTv_SdtProposta_Propostaresponsavelemail_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaresponsavelemail = value;
            SetDirty("Propostaresponsavelemail");
         }

      }

      public void gxTv_SdtProposta_Propostaresponsavelemail_SetNull( )
      {
         gxTv_SdtProposta_Propostaresponsavelemail_N = 1;
         gxTv_SdtProposta_Propostaresponsavelemail = "";
         SetDirty("Propostaresponsavelemail");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaresponsavelemail_IsNull( )
      {
         return (gxTv_SdtProposta_Propostaresponsavelemail_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaResponsavelBanco" )]
      [  XmlElement( ElementName = "PropostaResponsavelBanco"   )]
      public string gxTpr_Propostaresponsavelbanco
      {
         get {
            return gxTv_SdtProposta_Propostaresponsavelbanco ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaresponsavelbanco = value;
            SetDirty("Propostaresponsavelbanco");
         }

      }

      public void gxTv_SdtProposta_Propostaresponsavelbanco_SetNull( )
      {
         gxTv_SdtProposta_Propostaresponsavelbanco = "";
         SetDirty("Propostaresponsavelbanco");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaresponsavelbanco_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaResponsavelConta" )]
      [  XmlElement( ElementName = "PropostaResponsavelConta"   )]
      public string gxTpr_Propostaresponsavelconta
      {
         get {
            return gxTv_SdtProposta_Propostaresponsavelconta ;
         }

         set {
            gxTv_SdtProposta_Propostaresponsavelconta_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaresponsavelconta = value;
            SetDirty("Propostaresponsavelconta");
         }

      }

      public void gxTv_SdtProposta_Propostaresponsavelconta_SetNull( )
      {
         gxTv_SdtProposta_Propostaresponsavelconta_N = 1;
         gxTv_SdtProposta_Propostaresponsavelconta = "";
         SetDirty("Propostaresponsavelconta");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaresponsavelconta_IsNull( )
      {
         return (gxTv_SdtProposta_Propostaresponsavelconta_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaResponsavelAgencia" )]
      [  XmlElement( ElementName = "PropostaResponsavelAgencia"   )]
      public string gxTpr_Propostaresponsavelagencia
      {
         get {
            return gxTv_SdtProposta_Propostaresponsavelagencia ;
         }

         set {
            gxTv_SdtProposta_Propostaresponsavelagencia_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaresponsavelagencia = value;
            SetDirty("Propostaresponsavelagencia");
         }

      }

      public void gxTv_SdtProposta_Propostaresponsavelagencia_SetNull( )
      {
         gxTv_SdtProposta_Propostaresponsavelagencia_N = 1;
         gxTv_SdtProposta_Propostaresponsavelagencia = "";
         SetDirty("Propostaresponsavelagencia");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaresponsavelagencia_IsNull( )
      {
         return (gxTv_SdtProposta_Propostaresponsavelagencia_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaResponsavelTipoPix" )]
      [  XmlElement( ElementName = "PropostaResponsavelTipoPix"   )]
      public string gxTpr_Propostaresponsaveltipopix
      {
         get {
            return gxTv_SdtProposta_Propostaresponsaveltipopix ;
         }

         set {
            gxTv_SdtProposta_Propostaresponsaveltipopix_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaresponsaveltipopix = value;
            SetDirty("Propostaresponsaveltipopix");
         }

      }

      public void gxTv_SdtProposta_Propostaresponsaveltipopix_SetNull( )
      {
         gxTv_SdtProposta_Propostaresponsaveltipopix_N = 1;
         gxTv_SdtProposta_Propostaresponsaveltipopix = "";
         SetDirty("Propostaresponsaveltipopix");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaresponsaveltipopix_IsNull( )
      {
         return (gxTv_SdtProposta_Propostaresponsaveltipopix_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaResponsavelPIX" )]
      [  XmlElement( ElementName = "PropostaResponsavelPIX"   )]
      public string gxTpr_Propostaresponsavelpix
      {
         get {
            return gxTv_SdtProposta_Propostaresponsavelpix ;
         }

         set {
            gxTv_SdtProposta_Propostaresponsavelpix_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaresponsavelpix = value;
            SetDirty("Propostaresponsavelpix");
         }

      }

      public void gxTv_SdtProposta_Propostaresponsavelpix_SetNull( )
      {
         gxTv_SdtProposta_Propostaresponsavelpix_N = 1;
         gxTv_SdtProposta_Propostaresponsavelpix = "";
         SetDirty("Propostaresponsavelpix");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaresponsavelpix_IsNull( )
      {
         return (gxTv_SdtProposta_Propostaresponsavelpix_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaResponsavelDepositoTipo" )]
      [  XmlElement( ElementName = "PropostaResponsavelDepositoTipo"   )]
      public string gxTpr_Propostaresponsaveldepositotipo
      {
         get {
            return gxTv_SdtProposta_Propostaresponsaveldepositotipo ;
         }

         set {
            gxTv_SdtProposta_Propostaresponsaveldepositotipo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaresponsaveldepositotipo = value;
            SetDirty("Propostaresponsaveldepositotipo");
         }

      }

      public void gxTv_SdtProposta_Propostaresponsaveldepositotipo_SetNull( )
      {
         gxTv_SdtProposta_Propostaresponsaveldepositotipo_N = 1;
         gxTv_SdtProposta_Propostaresponsaveldepositotipo = "";
         SetDirty("Propostaresponsaveldepositotipo");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaresponsaveldepositotipo_IsNull( )
      {
         return (gxTv_SdtProposta_Propostaresponsaveldepositotipo_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaResponsavelSerasaConsultas_F" )]
      [  XmlElement( ElementName = "PropostaResponsavelSerasaConsultas_F"   )]
      public short gxTpr_Propostaresponsavelserasaconsultas_f
      {
         get {
            return gxTv_SdtProposta_Propostaresponsavelserasaconsultas_f ;
         }

         set {
            gxTv_SdtProposta_Propostaresponsavelserasaconsultas_f_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaresponsavelserasaconsultas_f = value;
            SetDirty("Propostaresponsavelserasaconsultas_f");
         }

      }

      public void gxTv_SdtProposta_Propostaresponsavelserasaconsultas_f_SetNull( )
      {
         gxTv_SdtProposta_Propostaresponsavelserasaconsultas_f_N = 1;
         gxTv_SdtProposta_Propostaresponsavelserasaconsultas_f = 0;
         SetDirty("Propostaresponsavelserasaconsultas_f");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaresponsavelserasaconsultas_f_IsNull( )
      {
         return (gxTv_SdtProposta_Propostaresponsavelserasaconsultas_f_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaResponsavelSerasaScoreUltimaData_F" )]
      [  XmlElement( ElementName = "PropostaResponsavelSerasaScoreUltimaData_F"   )]
      public short gxTpr_Propostaresponsavelserasascoreultimadata_f
      {
         get {
            return gxTv_SdtProposta_Propostaresponsavelserasascoreultimadata_f ;
         }

         set {
            gxTv_SdtProposta_Propostaresponsavelserasascoreultimadata_f_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaresponsavelserasascoreultimadata_f = value;
            SetDirty("Propostaresponsavelserasascoreultimadata_f");
         }

      }

      public void gxTv_SdtProposta_Propostaresponsavelserasascoreultimadata_f_SetNull( )
      {
         gxTv_SdtProposta_Propostaresponsavelserasascoreultimadata_f_N = 1;
         gxTv_SdtProposta_Propostaresponsavelserasascoreultimadata_f = 0;
         SetDirty("Propostaresponsavelserasascoreultimadata_f");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaresponsavelserasascoreultimadata_f_IsNull( )
      {
         return (gxTv_SdtProposta_Propostaresponsavelserasascoreultimadata_f_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaResponsavelSerasaUltimoValorRecomendado_F" )]
      [  XmlElement( ElementName = "PropostaResponsavelSerasaUltimoValorRecomendado_F"   )]
      public decimal gxTpr_Propostaresponsavelserasaultimovalorrecomendado_f
      {
         get {
            return gxTv_SdtProposta_Propostaresponsavelserasaultimovalorrecomendado_f ;
         }

         set {
            gxTv_SdtProposta_Propostaresponsavelserasaultimovalorrecomendado_f_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaresponsavelserasaultimovalorrecomendado_f = value;
            SetDirty("Propostaresponsavelserasaultimovalorrecomendado_f");
         }

      }

      public void gxTv_SdtProposta_Propostaresponsavelserasaultimovalorrecomendado_f_SetNull( )
      {
         gxTv_SdtProposta_Propostaresponsavelserasaultimovalorrecomendado_f_N = 1;
         gxTv_SdtProposta_Propostaresponsavelserasaultimovalorrecomendado_f = 0;
         SetDirty("Propostaresponsavelserasaultimovalorrecomendado_f");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaresponsavelserasaultimovalorrecomendado_f_IsNull( )
      {
         return (gxTv_SdtProposta_Propostaresponsavelserasaultimovalorrecomendado_f_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaPacienteClienteRazaoSocial" )]
      [  XmlElement( ElementName = "PropostaPacienteClienteRazaoSocial"   )]
      public string gxTpr_Propostapacienteclienterazaosocial
      {
         get {
            return gxTv_SdtProposta_Propostapacienteclienterazaosocial ;
         }

         set {
            gxTv_SdtProposta_Propostapacienteclienterazaosocial_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacienteclienterazaosocial = value;
            SetDirty("Propostapacienteclienterazaosocial");
         }

      }

      public void gxTv_SdtProposta_Propostapacienteclienterazaosocial_SetNull( )
      {
         gxTv_SdtProposta_Propostapacienteclienterazaosocial_N = 1;
         gxTv_SdtProposta_Propostapacienteclienterazaosocial = "";
         SetDirty("Propostapacienteclienterazaosocial");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostapacienteclienterazaosocial_IsNull( )
      {
         return (gxTv_SdtProposta_Propostapacienteclienterazaosocial_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaPacienteClienteDocumento" )]
      [  XmlElement( ElementName = "PropostaPacienteClienteDocumento"   )]
      public string gxTpr_Propostapacienteclientedocumento
      {
         get {
            return gxTv_SdtProposta_Propostapacienteclientedocumento ;
         }

         set {
            gxTv_SdtProposta_Propostapacienteclientedocumento_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacienteclientedocumento = value;
            SetDirty("Propostapacienteclientedocumento");
         }

      }

      public void gxTv_SdtProposta_Propostapacienteclientedocumento_SetNull( )
      {
         gxTv_SdtProposta_Propostapacienteclientedocumento_N = 1;
         gxTv_SdtProposta_Propostapacienteclientedocumento = "";
         SetDirty("Propostapacienteclientedocumento");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostapacienteclientedocumento_IsNull( )
      {
         return (gxTv_SdtProposta_Propostapacienteclientedocumento_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaPacienteContatoEmail" )]
      [  XmlElement( ElementName = "PropostaPacienteContatoEmail"   )]
      public string gxTpr_Propostapacientecontatoemail
      {
         get {
            return gxTv_SdtProposta_Propostapacientecontatoemail ;
         }

         set {
            gxTv_SdtProposta_Propostapacientecontatoemail_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacientecontatoemail = value;
            SetDirty("Propostapacientecontatoemail");
         }

      }

      public void gxTv_SdtProposta_Propostapacientecontatoemail_SetNull( )
      {
         gxTv_SdtProposta_Propostapacientecontatoemail_N = 1;
         gxTv_SdtProposta_Propostapacientecontatoemail = "";
         SetDirty("Propostapacientecontatoemail");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostapacientecontatoemail_IsNull( )
      {
         return (gxTv_SdtProposta_Propostapacientecontatoemail_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaPacienteBanco" )]
      [  XmlElement( ElementName = "PropostaPacienteBanco"   )]
      public string gxTpr_Propostapacientebanco
      {
         get {
            return gxTv_SdtProposta_Propostapacientebanco ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacientebanco = value;
            SetDirty("Propostapacientebanco");
         }

      }

      public void gxTv_SdtProposta_Propostapacientebanco_SetNull( )
      {
         gxTv_SdtProposta_Propostapacientebanco = "";
         SetDirty("Propostapacientebanco");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostapacientebanco_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaPacienteConta" )]
      [  XmlElement( ElementName = "PropostaPacienteConta"   )]
      public string gxTpr_Propostapacienteconta
      {
         get {
            return gxTv_SdtProposta_Propostapacienteconta ;
         }

         set {
            gxTv_SdtProposta_Propostapacienteconta_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacienteconta = value;
            SetDirty("Propostapacienteconta");
         }

      }

      public void gxTv_SdtProposta_Propostapacienteconta_SetNull( )
      {
         gxTv_SdtProposta_Propostapacienteconta_N = 1;
         gxTv_SdtProposta_Propostapacienteconta = "";
         SetDirty("Propostapacienteconta");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostapacienteconta_IsNull( )
      {
         return (gxTv_SdtProposta_Propostapacienteconta_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaPacienteAgencia" )]
      [  XmlElement( ElementName = "PropostaPacienteAgencia"   )]
      public string gxTpr_Propostapacienteagencia
      {
         get {
            return gxTv_SdtProposta_Propostapacienteagencia ;
         }

         set {
            gxTv_SdtProposta_Propostapacienteagencia_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacienteagencia = value;
            SetDirty("Propostapacienteagencia");
         }

      }

      public void gxTv_SdtProposta_Propostapacienteagencia_SetNull( )
      {
         gxTv_SdtProposta_Propostapacienteagencia_N = 1;
         gxTv_SdtProposta_Propostapacienteagencia = "";
         SetDirty("Propostapacienteagencia");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostapacienteagencia_IsNull( )
      {
         return (gxTv_SdtProposta_Propostapacienteagencia_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaPacienteTipoPix" )]
      [  XmlElement( ElementName = "PropostaPacienteTipoPix"   )]
      public string gxTpr_Propostapacientetipopix
      {
         get {
            return gxTv_SdtProposta_Propostapacientetipopix ;
         }

         set {
            gxTv_SdtProposta_Propostapacientetipopix_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacientetipopix = value;
            SetDirty("Propostapacientetipopix");
         }

      }

      public void gxTv_SdtProposta_Propostapacientetipopix_SetNull( )
      {
         gxTv_SdtProposta_Propostapacientetipopix_N = 1;
         gxTv_SdtProposta_Propostapacientetipopix = "";
         SetDirty("Propostapacientetipopix");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostapacientetipopix_IsNull( )
      {
         return (gxTv_SdtProposta_Propostapacientetipopix_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaPacientePIX" )]
      [  XmlElement( ElementName = "PropostaPacientePIX"   )]
      public string gxTpr_Propostapacientepix
      {
         get {
            return gxTv_SdtProposta_Propostapacientepix ;
         }

         set {
            gxTv_SdtProposta_Propostapacientepix_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacientepix = value;
            SetDirty("Propostapacientepix");
         }

      }

      public void gxTv_SdtProposta_Propostapacientepix_SetNull( )
      {
         gxTv_SdtProposta_Propostapacientepix_N = 1;
         gxTv_SdtProposta_Propostapacientepix = "";
         SetDirty("Propostapacientepix");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostapacientepix_IsNull( )
      {
         return (gxTv_SdtProposta_Propostapacientepix_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaPacienteDepositoTipo" )]
      [  XmlElement( ElementName = "PropostaPacienteDepositoTipo"   )]
      public string gxTpr_Propostapacientedepositotipo
      {
         get {
            return gxTv_SdtProposta_Propostapacientedepositotipo ;
         }

         set {
            gxTv_SdtProposta_Propostapacientedepositotipo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacientedepositotipo = value;
            SetDirty("Propostapacientedepositotipo");
         }

      }

      public void gxTv_SdtProposta_Propostapacientedepositotipo_SetNull( )
      {
         gxTv_SdtProposta_Propostapacientedepositotipo_N = 1;
         gxTv_SdtProposta_Propostapacientedepositotipo = "";
         SetDirty("Propostapacientedepositotipo");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostapacientedepositotipo_IsNull( )
      {
         return (gxTv_SdtProposta_Propostapacientedepositotipo_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaPacienteEnderecoCEP" )]
      [  XmlElement( ElementName = "PropostaPacienteEnderecoCEP"   )]
      public string gxTpr_Propostapacienteenderecocep
      {
         get {
            return gxTv_SdtProposta_Propostapacienteenderecocep ;
         }

         set {
            gxTv_SdtProposta_Propostapacienteenderecocep_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacienteenderecocep = value;
            SetDirty("Propostapacienteenderecocep");
         }

      }

      public void gxTv_SdtProposta_Propostapacienteenderecocep_SetNull( )
      {
         gxTv_SdtProposta_Propostapacienteenderecocep_N = 1;
         gxTv_SdtProposta_Propostapacienteenderecocep = "";
         SetDirty("Propostapacienteenderecocep");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostapacienteenderecocep_IsNull( )
      {
         return (gxTv_SdtProposta_Propostapacienteenderecocep_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaPacienteEnderecoLogradouro" )]
      [  XmlElement( ElementName = "PropostaPacienteEnderecoLogradouro"   )]
      public string gxTpr_Propostapacienteenderecologradouro
      {
         get {
            return gxTv_SdtProposta_Propostapacienteenderecologradouro ;
         }

         set {
            gxTv_SdtProposta_Propostapacienteenderecologradouro_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacienteenderecologradouro = value;
            SetDirty("Propostapacienteenderecologradouro");
         }

      }

      public void gxTv_SdtProposta_Propostapacienteenderecologradouro_SetNull( )
      {
         gxTv_SdtProposta_Propostapacienteenderecologradouro_N = 1;
         gxTv_SdtProposta_Propostapacienteenderecologradouro = "";
         SetDirty("Propostapacienteenderecologradouro");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostapacienteenderecologradouro_IsNull( )
      {
         return (gxTv_SdtProposta_Propostapacienteenderecologradouro_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaPacienteEnderecoNumero" )]
      [  XmlElement( ElementName = "PropostaPacienteEnderecoNumero"   )]
      public string gxTpr_Propostapacienteendereconumero
      {
         get {
            return gxTv_SdtProposta_Propostapacienteendereconumero ;
         }

         set {
            gxTv_SdtProposta_Propostapacienteendereconumero_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacienteendereconumero = value;
            SetDirty("Propostapacienteendereconumero");
         }

      }

      public void gxTv_SdtProposta_Propostapacienteendereconumero_SetNull( )
      {
         gxTv_SdtProposta_Propostapacienteendereconumero_N = 1;
         gxTv_SdtProposta_Propostapacienteendereconumero = "";
         SetDirty("Propostapacienteendereconumero");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostapacienteendereconumero_IsNull( )
      {
         return (gxTv_SdtProposta_Propostapacienteendereconumero_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaPacienteEnderecoComplemento" )]
      [  XmlElement( ElementName = "PropostaPacienteEnderecoComplemento"   )]
      public string gxTpr_Propostapacienteenderecocomplemento
      {
         get {
            return gxTv_SdtProposta_Propostapacienteenderecocomplemento ;
         }

         set {
            gxTv_SdtProposta_Propostapacienteenderecocomplemento_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacienteenderecocomplemento = value;
            SetDirty("Propostapacienteenderecocomplemento");
         }

      }

      public void gxTv_SdtProposta_Propostapacienteenderecocomplemento_SetNull( )
      {
         gxTv_SdtProposta_Propostapacienteenderecocomplemento_N = 1;
         gxTv_SdtProposta_Propostapacienteenderecocomplemento = "";
         SetDirty("Propostapacienteenderecocomplemento");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostapacienteenderecocomplemento_IsNull( )
      {
         return (gxTv_SdtProposta_Propostapacienteenderecocomplemento_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaPacienteEnderecoBairro" )]
      [  XmlElement( ElementName = "PropostaPacienteEnderecoBairro"   )]
      public string gxTpr_Propostapacienteenderecobairro
      {
         get {
            return gxTv_SdtProposta_Propostapacienteenderecobairro ;
         }

         set {
            gxTv_SdtProposta_Propostapacienteenderecobairro_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacienteenderecobairro = value;
            SetDirty("Propostapacienteenderecobairro");
         }

      }

      public void gxTv_SdtProposta_Propostapacienteenderecobairro_SetNull( )
      {
         gxTv_SdtProposta_Propostapacienteenderecobairro_N = 1;
         gxTv_SdtProposta_Propostapacienteenderecobairro = "";
         SetDirty("Propostapacienteenderecobairro");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostapacienteenderecobairro_IsNull( )
      {
         return (gxTv_SdtProposta_Propostapacienteenderecobairro_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaPacienteMunicipioCodigo" )]
      [  XmlElement( ElementName = "PropostaPacienteMunicipioCodigo"   )]
      public string gxTpr_Propostapacientemunicipiocodigo
      {
         get {
            return gxTv_SdtProposta_Propostapacientemunicipiocodigo ;
         }

         set {
            gxTv_SdtProposta_Propostapacientemunicipiocodigo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacientemunicipiocodigo = value;
            SetDirty("Propostapacientemunicipiocodigo");
         }

      }

      public void gxTv_SdtProposta_Propostapacientemunicipiocodigo_SetNull( )
      {
         gxTv_SdtProposta_Propostapacientemunicipiocodigo_N = 1;
         gxTv_SdtProposta_Propostapacientemunicipiocodigo = "";
         SetDirty("Propostapacientemunicipiocodigo");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostapacientemunicipiocodigo_IsNull( )
      {
         return (gxTv_SdtProposta_Propostapacientemunicipiocodigo_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaPacienteSerasaConsultas_F" )]
      [  XmlElement( ElementName = "PropostaPacienteSerasaConsultas_F"   )]
      public short gxTpr_Propostapacienteserasaconsultas_f
      {
         get {
            return gxTv_SdtProposta_Propostapacienteserasaconsultas_f ;
         }

         set {
            gxTv_SdtProposta_Propostapacienteserasaconsultas_f_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacienteserasaconsultas_f = value;
            SetDirty("Propostapacienteserasaconsultas_f");
         }

      }

      public void gxTv_SdtProposta_Propostapacienteserasaconsultas_f_SetNull( )
      {
         gxTv_SdtProposta_Propostapacienteserasaconsultas_f_N = 1;
         gxTv_SdtProposta_Propostapacienteserasaconsultas_f = 0;
         SetDirty("Propostapacienteserasaconsultas_f");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostapacienteserasaconsultas_f_IsNull( )
      {
         return (gxTv_SdtProposta_Propostapacienteserasaconsultas_f_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaSerasaScoreUltimaData_F" )]
      [  XmlElement( ElementName = "PropostaSerasaScoreUltimaData_F"   )]
      public short gxTpr_Propostaserasascoreultimadata_f
      {
         get {
            return gxTv_SdtProposta_Propostaserasascoreultimadata_f ;
         }

         set {
            gxTv_SdtProposta_Propostaserasascoreultimadata_f_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaserasascoreultimadata_f = value;
            SetDirty("Propostaserasascoreultimadata_f");
         }

      }

      public void gxTv_SdtProposta_Propostaserasascoreultimadata_f_SetNull( )
      {
         gxTv_SdtProposta_Propostaserasascoreultimadata_f_N = 1;
         gxTv_SdtProposta_Propostaserasascoreultimadata_f = 0;
         SetDirty("Propostaserasascoreultimadata_f");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaserasascoreultimadata_f_IsNull( )
      {
         return (gxTv_SdtProposta_Propostaserasascoreultimadata_f_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaPacienteSerasaUltimoValorRecomendado_F" )]
      [  XmlElement( ElementName = "PropostaPacienteSerasaUltimoValorRecomendado_F"   )]
      public decimal gxTpr_Propostapacienteserasaultimovalorrecomendado_f
      {
         get {
            return gxTv_SdtProposta_Propostapacienteserasaultimovalorrecomendado_f ;
         }

         set {
            gxTv_SdtProposta_Propostapacienteserasaultimovalorrecomendado_f_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacienteserasaultimovalorrecomendado_f = value;
            SetDirty("Propostapacienteserasaultimovalorrecomendado_f");
         }

      }

      public void gxTv_SdtProposta_Propostapacienteserasaultimovalorrecomendado_f_SetNull( )
      {
         gxTv_SdtProposta_Propostapacienteserasaultimovalorrecomendado_f_N = 1;
         gxTv_SdtProposta_Propostapacienteserasaultimovalorrecomendado_f = 0;
         SetDirty("Propostapacienteserasaultimovalorrecomendado_f");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostapacienteserasaultimovalorrecomendado_f_IsNull( )
      {
         return (gxTv_SdtProposta_Propostapacienteserasaultimovalorrecomendado_f_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaValorTaxaClinica_F" )]
      [  XmlElement( ElementName = "PropostaValorTaxaClinica_F"   )]
      public decimal gxTpr_Propostavalortaxaclinica_f
      {
         get {
            return gxTv_SdtProposta_Propostavalortaxaclinica_f ;
         }

         set {
            gxTv_SdtProposta_Propostavalortaxaclinica_f_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostavalortaxaclinica_f = value;
            SetDirty("Propostavalortaxaclinica_f");
         }

      }

      public void gxTv_SdtProposta_Propostavalortaxaclinica_f_SetNull( )
      {
         gxTv_SdtProposta_Propostavalortaxaclinica_f_N = 1;
         gxTv_SdtProposta_Propostavalortaxaclinica_f = 0;
         SetDirty("Propostavalortaxaclinica_f");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostavalortaxaclinica_f_IsNull( )
      {
         return (gxTv_SdtProposta_Propostavalortaxaclinica_f_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaQtdDocumentoPendente_F" )]
      [  XmlElement( ElementName = "PropostaQtdDocumentoPendente_F"   )]
      public short gxTpr_Propostaqtddocumentopendente_f
      {
         get {
            return gxTv_SdtProposta_Propostaqtddocumentopendente_f ;
         }

         set {
            gxTv_SdtProposta_Propostaqtddocumentopendente_f_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaqtddocumentopendente_f = value;
            SetDirty("Propostaqtddocumentopendente_f");
         }

      }

      public void gxTv_SdtProposta_Propostaqtddocumentopendente_f_SetNull( )
      {
         gxTv_SdtProposta_Propostaqtddocumentopendente_f_N = 1;
         gxTv_SdtProposta_Propostaqtddocumentopendente_f = 0;
         SetDirty("Propostaqtddocumentopendente_f");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaqtddocumentopendente_f_IsNull( )
      {
         return (gxTv_SdtProposta_Propostaqtddocumentopendente_f_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaMaiorScore_F" )]
      [  XmlElement( ElementName = "PropostaMaiorScore_F"   )]
      public short gxTpr_Propostamaiorscore_f
      {
         get {
            return gxTv_SdtProposta_Propostamaiorscore_f ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostamaiorscore_f = value;
            SetDirty("Propostamaiorscore_f");
         }

      }

      public void gxTv_SdtProposta_Propostamaiorscore_f_SetNull( )
      {
         gxTv_SdtProposta_Propostamaiorscore_f = 0;
         SetDirty("Propostamaiorscore_f");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostamaiorscore_f_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaMaiorValorRecomendado" )]
      [  XmlElement( ElementName = "PropostaMaiorValorRecomendado"   )]
      public decimal gxTpr_Propostamaiorvalorrecomendado
      {
         get {
            return gxTv_SdtProposta_Propostamaiorvalorrecomendado ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostamaiorvalorrecomendado = value;
            SetDirty("Propostamaiorvalorrecomendado");
         }

      }

      public void gxTv_SdtProposta_Propostamaiorvalorrecomendado_SetNull( )
      {
         gxTv_SdtProposta_Propostamaiorvalorrecomendado = 0;
         SetDirty("Propostamaiorvalorrecomendado");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostamaiorvalorrecomendado_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaTitulo" )]
      [  XmlElement( ElementName = "PropostaTitulo"   )]
      public string gxTpr_Propostatitulo
      {
         get {
            return gxTv_SdtProposta_Propostatitulo ;
         }

         set {
            gxTv_SdtProposta_Propostatitulo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostatitulo = value;
            SetDirty("Propostatitulo");
         }

      }

      public void gxTv_SdtProposta_Propostatitulo_SetNull( )
      {
         gxTv_SdtProposta_Propostatitulo_N = 1;
         gxTv_SdtProposta_Propostatitulo = "";
         SetDirty("Propostatitulo");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostatitulo_IsNull( )
      {
         return (gxTv_SdtProposta_Propostatitulo_N==1) ;
      }

      [  SoapElement( ElementName = "ProcedimentosMedicosId" )]
      [  XmlElement( ElementName = "ProcedimentosMedicosId"   )]
      public int gxTpr_Procedimentosmedicosid
      {
         get {
            return gxTv_SdtProposta_Procedimentosmedicosid ;
         }

         set {
            gxTv_SdtProposta_Procedimentosmedicosid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Procedimentosmedicosid = value;
            SetDirty("Procedimentosmedicosid");
         }

      }

      public void gxTv_SdtProposta_Procedimentosmedicosid_SetNull( )
      {
         gxTv_SdtProposta_Procedimentosmedicosid_N = 1;
         gxTv_SdtProposta_Procedimentosmedicosid = 0;
         SetDirty("Procedimentosmedicosid");
         return  ;
      }

      public bool gxTv_SdtProposta_Procedimentosmedicosid_IsNull( )
      {
         return (gxTv_SdtProposta_Procedimentosmedicosid_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaDescricao" )]
      [  XmlElement( ElementName = "PropostaDescricao"   )]
      public string gxTpr_Propostadescricao
      {
         get {
            return gxTv_SdtProposta_Propostadescricao ;
         }

         set {
            gxTv_SdtProposta_Propostadescricao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostadescricao = value;
            SetDirty("Propostadescricao");
         }

      }

      public void gxTv_SdtProposta_Propostadescricao_SetNull( )
      {
         gxTv_SdtProposta_Propostadescricao_N = 1;
         gxTv_SdtProposta_Propostadescricao = "";
         SetDirty("Propostadescricao");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostadescricao_IsNull( )
      {
         return (gxTv_SdtProposta_Propostadescricao_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaDataCirurgia" )]
      [  XmlElement( ElementName = "PropostaDataCirurgia"  , IsNullable=true )]
      public string gxTpr_Propostadatacirurgia_Nullable
      {
         get {
            if ( gxTv_SdtProposta_Propostadatacirurgia == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtProposta_Propostadatacirurgia).value ;
         }

         set {
            gxTv_SdtProposta_Propostadatacirurgia_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtProposta_Propostadatacirurgia = DateTime.MinValue;
            else
               gxTv_SdtProposta_Propostadatacirurgia = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Propostadatacirurgia
      {
         get {
            return gxTv_SdtProposta_Propostadatacirurgia ;
         }

         set {
            gxTv_SdtProposta_Propostadatacirurgia_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostadatacirurgia = value;
            SetDirty("Propostadatacirurgia");
         }

      }

      public void gxTv_SdtProposta_Propostadatacirurgia_SetNull( )
      {
         gxTv_SdtProposta_Propostadatacirurgia_N = 1;
         gxTv_SdtProposta_Propostadatacirurgia = (DateTime)(DateTime.MinValue);
         SetDirty("Propostadatacirurgia");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostadatacirurgia_IsNull( )
      {
         return (gxTv_SdtProposta_Propostadatacirurgia_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaValor" )]
      [  XmlElement( ElementName = "PropostaValor"   )]
      public decimal gxTpr_Propostavalor
      {
         get {
            return gxTv_SdtProposta_Propostavalor ;
         }

         set {
            gxTv_SdtProposta_Propostavalor_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostavalor = value;
            SetDirty("Propostavalor");
         }

      }

      public void gxTv_SdtProposta_Propostavalor_SetNull( )
      {
         gxTv_SdtProposta_Propostavalor_N = 1;
         gxTv_SdtProposta_Propostavalor = 0;
         SetDirty("Propostavalor");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostavalor_IsNull( )
      {
         return (gxTv_SdtProposta_Propostavalor_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaValorLiquido" )]
      [  XmlElement( ElementName = "PropostaValorLiquido"   )]
      public decimal gxTpr_Propostavalorliquido
      {
         get {
            return gxTv_SdtProposta_Propostavalorliquido ;
         }

         set {
            gxTv_SdtProposta_Propostavalorliquido_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostavalorliquido = value;
            SetDirty("Propostavalorliquido");
         }

      }

      public void gxTv_SdtProposta_Propostavalorliquido_SetNull( )
      {
         gxTv_SdtProposta_Propostavalorliquido_N = 1;
         gxTv_SdtProposta_Propostavalorliquido = 0;
         SetDirty("Propostavalorliquido");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostavalorliquido_IsNull( )
      {
         return (gxTv_SdtProposta_Propostavalorliquido_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaTaxaAdministrativa" )]
      [  XmlElement( ElementName = "PropostaTaxaAdministrativa"   )]
      public decimal gxTpr_Propostataxaadministrativa
      {
         get {
            return gxTv_SdtProposta_Propostataxaadministrativa ;
         }

         set {
            gxTv_SdtProposta_Propostataxaadministrativa_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostataxaadministrativa = value;
            SetDirty("Propostataxaadministrativa");
         }

      }

      public void gxTv_SdtProposta_Propostataxaadministrativa_SetNull( )
      {
         gxTv_SdtProposta_Propostataxaadministrativa_N = 1;
         gxTv_SdtProposta_Propostataxaadministrativa = 0;
         SetDirty("Propostataxaadministrativa");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostataxaadministrativa_IsNull( )
      {
         return (gxTv_SdtProposta_Propostataxaadministrativa_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaTaxa_F" )]
      [  XmlElement( ElementName = "PropostaTaxa_F"   )]
      public decimal gxTpr_Propostataxa_f
      {
         get {
            return gxTv_SdtProposta_Propostataxa_f ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostataxa_f = value;
            SetDirty("Propostataxa_f");
         }

      }

      public void gxTv_SdtProposta_Propostataxa_f_SetNull( )
      {
         gxTv_SdtProposta_Propostataxa_f = 0;
         SetDirty("Propostataxa_f");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostataxa_f_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaSLA" )]
      [  XmlElement( ElementName = "PropostaSLA"   )]
      public short gxTpr_Propostasla
      {
         get {
            return gxTv_SdtProposta_Propostasla ;
         }

         set {
            gxTv_SdtProposta_Propostasla_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostasla = value;
            SetDirty("Propostasla");
         }

      }

      public void gxTv_SdtProposta_Propostasla_SetNull( )
      {
         gxTv_SdtProposta_Propostasla_N = 1;
         gxTv_SdtProposta_Propostasla = 0;
         SetDirty("Propostasla");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostasla_IsNull( )
      {
         return (gxTv_SdtProposta_Propostasla_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaJurosMora" )]
      [  XmlElement( ElementName = "PropostaJurosMora"   )]
      public decimal gxTpr_Propostajurosmora
      {
         get {
            return gxTv_SdtProposta_Propostajurosmora ;
         }

         set {
            gxTv_SdtProposta_Propostajurosmora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostajurosmora = value;
            SetDirty("Propostajurosmora");
         }

      }

      public void gxTv_SdtProposta_Propostajurosmora_SetNull( )
      {
         gxTv_SdtProposta_Propostajurosmora_N = 1;
         gxTv_SdtProposta_Propostajurosmora = 0;
         SetDirty("Propostajurosmora");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostajurosmora_IsNull( )
      {
         return (gxTv_SdtProposta_Propostajurosmora_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaCreatedAt" )]
      [  XmlElement( ElementName = "PropostaCreatedAt"  , IsNullable=true )]
      public string gxTpr_Propostacreatedat_Nullable
      {
         get {
            if ( gxTv_SdtProposta_Propostacreatedat == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtProposta_Propostacreatedat).value ;
         }

         set {
            gxTv_SdtProposta_Propostacreatedat_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtProposta_Propostacreatedat = DateTime.MinValue;
            else
               gxTv_SdtProposta_Propostacreatedat = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Propostacreatedat
      {
         get {
            return gxTv_SdtProposta_Propostacreatedat ;
         }

         set {
            gxTv_SdtProposta_Propostacreatedat_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostacreatedat = value;
            SetDirty("Propostacreatedat");
         }

      }

      public void gxTv_SdtProposta_Propostacreatedat_SetNull( )
      {
         gxTv_SdtProposta_Propostacreatedat_N = 1;
         gxTv_SdtProposta_Propostacreatedat = (DateTime)(DateTime.MinValue);
         SetDirty("Propostacreatedat");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostacreatedat_IsNull( )
      {
         return (gxTv_SdtProposta_Propostacreatedat_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaCratedBy" )]
      [  XmlElement( ElementName = "PropostaCratedBy"   )]
      public short gxTpr_Propostacratedby
      {
         get {
            return gxTv_SdtProposta_Propostacratedby ;
         }

         set {
            gxTv_SdtProposta_Propostacratedby_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostacratedby = value;
            SetDirty("Propostacratedby");
         }

      }

      public void gxTv_SdtProposta_Propostacratedby_SetNull( )
      {
         gxTv_SdtProposta_Propostacratedby_N = 1;
         gxTv_SdtProposta_Propostacratedby = 0;
         SetDirty("Propostacratedby");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostacratedby_IsNull( )
      {
         return (gxTv_SdtProposta_Propostacratedby_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaClinicaId" )]
      [  XmlElement( ElementName = "PropostaClinicaId"   )]
      public int gxTpr_Propostaclinicaid
      {
         get {
            return gxTv_SdtProposta_Propostaclinicaid ;
         }

         set {
            gxTv_SdtProposta_Propostaclinicaid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaclinicaid = value;
            SetDirty("Propostaclinicaid");
         }

      }

      public void gxTv_SdtProposta_Propostaclinicaid_SetNull( )
      {
         gxTv_SdtProposta_Propostaclinicaid_N = 1;
         gxTv_SdtProposta_Propostaclinicaid = 0;
         SetDirty("Propostaclinicaid");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaclinicaid_IsNull( )
      {
         return (gxTv_SdtProposta_Propostaclinicaid_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaClinicaNome" )]
      [  XmlElement( ElementName = "PropostaClinicaNome"   )]
      public string gxTpr_Propostaclinicanome
      {
         get {
            return gxTv_SdtProposta_Propostaclinicanome ;
         }

         set {
            gxTv_SdtProposta_Propostaclinicanome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaclinicanome = value;
            SetDirty("Propostaclinicanome");
         }

      }

      public void gxTv_SdtProposta_Propostaclinicanome_SetNull( )
      {
         gxTv_SdtProposta_Propostaclinicanome_N = 1;
         gxTv_SdtProposta_Propostaclinicanome = "";
         SetDirty("Propostaclinicanome");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaclinicanome_IsNull( )
      {
         return (gxTv_SdtProposta_Propostaclinicanome_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaClinicaNomeFantasia" )]
      [  XmlElement( ElementName = "PropostaClinicaNomeFantasia"   )]
      public string gxTpr_Propostaclinicanomefantasia
      {
         get {
            return gxTv_SdtProposta_Propostaclinicanomefantasia ;
         }

         set {
            gxTv_SdtProposta_Propostaclinicanomefantasia_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaclinicanomefantasia = value;
            SetDirty("Propostaclinicanomefantasia");
         }

      }

      public void gxTv_SdtProposta_Propostaclinicanomefantasia_SetNull( )
      {
         gxTv_SdtProposta_Propostaclinicanomefantasia_N = 1;
         gxTv_SdtProposta_Propostaclinicanomefantasia = "";
         SetDirty("Propostaclinicanomefantasia");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaclinicanomefantasia_IsNull( )
      {
         return (gxTv_SdtProposta_Propostaclinicanomefantasia_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaClinicaDocumento" )]
      [  XmlElement( ElementName = "PropostaClinicaDocumento"   )]
      public string gxTpr_Propostaclinicadocumento
      {
         get {
            return gxTv_SdtProposta_Propostaclinicadocumento ;
         }

         set {
            gxTv_SdtProposta_Propostaclinicadocumento_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaclinicadocumento = value;
            SetDirty("Propostaclinicadocumento");
         }

      }

      public void gxTv_SdtProposta_Propostaclinicadocumento_SetNull( )
      {
         gxTv_SdtProposta_Propostaclinicadocumento_N = 1;
         gxTv_SdtProposta_Propostaclinicadocumento = "";
         SetDirty("Propostaclinicadocumento");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaclinicadocumento_IsNull( )
      {
         return (gxTv_SdtProposta_Propostaclinicadocumento_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaClinicaEmail" )]
      [  XmlElement( ElementName = "PropostaClinicaEmail"   )]
      public string gxTpr_Propostaclinicaemail
      {
         get {
            return gxTv_SdtProposta_Propostaclinicaemail ;
         }

         set {
            gxTv_SdtProposta_Propostaclinicaemail_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaclinicaemail = value;
            SetDirty("Propostaclinicaemail");
         }

      }

      public void gxTv_SdtProposta_Propostaclinicaemail_SetNull( )
      {
         gxTv_SdtProposta_Propostaclinicaemail_N = 1;
         gxTv_SdtProposta_Propostaclinicaemail = "";
         SetDirty("Propostaclinicaemail");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaclinicaemail_IsNull( )
      {
         return (gxTv_SdtProposta_Propostaclinicaemail_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaSecUserName" )]
      [  XmlElement( ElementName = "PropostaSecUserName"   )]
      public string gxTpr_Propostasecusername
      {
         get {
            return gxTv_SdtProposta_Propostasecusername ;
         }

         set {
            gxTv_SdtProposta_Propostasecusername_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostasecusername = value;
            SetDirty("Propostasecusername");
         }

      }

      public void gxTv_SdtProposta_Propostasecusername_SetNull( )
      {
         gxTv_SdtProposta_Propostasecusername_N = 1;
         gxTv_SdtProposta_Propostasecusername = "";
         SetDirty("Propostasecusername");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostasecusername_IsNull( )
      {
         return (gxTv_SdtProposta_Propostasecusername_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaStatus" )]
      [  XmlElement( ElementName = "PropostaStatus"   )]
      public string gxTpr_Propostastatus
      {
         get {
            return gxTv_SdtProposta_Propostastatus ;
         }

         set {
            gxTv_SdtProposta_Propostastatus_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostastatus = value;
            SetDirty("Propostastatus");
         }

      }

      public void gxTv_SdtProposta_Propostastatus_SetNull( )
      {
         gxTv_SdtProposta_Propostastatus_N = 1;
         gxTv_SdtProposta_Propostastatus = "";
         SetDirty("Propostastatus");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostastatus_IsNull( )
      {
         return (gxTv_SdtProposta_Propostastatus_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaComentarioAnalise" )]
      [  XmlElement( ElementName = "PropostaComentarioAnalise"   )]
      public string gxTpr_Propostacomentarioanalise
      {
         get {
            return gxTv_SdtProposta_Propostacomentarioanalise ;
         }

         set {
            gxTv_SdtProposta_Propostacomentarioanalise_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostacomentarioanalise = value;
            SetDirty("Propostacomentarioanalise");
         }

      }

      public void gxTv_SdtProposta_Propostacomentarioanalise_SetNull( )
      {
         gxTv_SdtProposta_Propostacomentarioanalise_N = 1;
         gxTv_SdtProposta_Propostacomentarioanalise = "";
         SetDirty("Propostacomentarioanalise");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostacomentarioanalise_IsNull( )
      {
         return (gxTv_SdtProposta_Propostacomentarioanalise_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaQuantidadeAprovadores" )]
      [  XmlElement( ElementName = "PropostaQuantidadeAprovadores"   )]
      public short gxTpr_Propostaquantidadeaprovadores
      {
         get {
            return gxTv_SdtProposta_Propostaquantidadeaprovadores ;
         }

         set {
            gxTv_SdtProposta_Propostaquantidadeaprovadores_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaquantidadeaprovadores = value;
            SetDirty("Propostaquantidadeaprovadores");
         }

      }

      public void gxTv_SdtProposta_Propostaquantidadeaprovadores_SetNull( )
      {
         gxTv_SdtProposta_Propostaquantidadeaprovadores_N = 1;
         gxTv_SdtProposta_Propostaquantidadeaprovadores = 0;
         SetDirty("Propostaquantidadeaprovadores");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaquantidadeaprovadores_IsNull( )
      {
         return (gxTv_SdtProposta_Propostaquantidadeaprovadores_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaReprovacoesPermitidas" )]
      [  XmlElement( ElementName = "PropostaReprovacoesPermitidas"   )]
      public short gxTpr_Propostareprovacoespermitidas
      {
         get {
            return gxTv_SdtProposta_Propostareprovacoespermitidas ;
         }

         set {
            gxTv_SdtProposta_Propostareprovacoespermitidas_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostareprovacoespermitidas = value;
            SetDirty("Propostareprovacoespermitidas");
         }

      }

      public void gxTv_SdtProposta_Propostareprovacoespermitidas_SetNull( )
      {
         gxTv_SdtProposta_Propostareprovacoespermitidas_N = 1;
         gxTv_SdtProposta_Propostareprovacoespermitidas = 0;
         SetDirty("Propostareprovacoespermitidas");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostareprovacoespermitidas_IsNull( )
      {
         return (gxTv_SdtProposta_Propostareprovacoespermitidas_N==1) ;
      }

      [  SoapElement( ElementName = "ContratoId" )]
      [  XmlElement( ElementName = "ContratoId"   )]
      public int gxTpr_Contratoid
      {
         get {
            return gxTv_SdtProposta_Contratoid ;
         }

         set {
            gxTv_SdtProposta_Contratoid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Contratoid = value;
            SetDirty("Contratoid");
         }

      }

      public void gxTv_SdtProposta_Contratoid_SetNull( )
      {
         gxTv_SdtProposta_Contratoid_N = 1;
         gxTv_SdtProposta_Contratoid = 0;
         SetDirty("Contratoid");
         return  ;
      }

      public bool gxTv_SdtProposta_Contratoid_IsNull( )
      {
         return (gxTv_SdtProposta_Contratoid_N==1) ;
      }

      [  SoapElement( ElementName = "ContratoNome" )]
      [  XmlElement( ElementName = "ContratoNome"   )]
      public string gxTpr_Contratonome
      {
         get {
            return gxTv_SdtProposta_Contratonome ;
         }

         set {
            gxTv_SdtProposta_Contratonome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Contratonome = value;
            SetDirty("Contratonome");
         }

      }

      public void gxTv_SdtProposta_Contratonome_SetNull( )
      {
         gxTv_SdtProposta_Contratonome_N = 1;
         gxTv_SdtProposta_Contratonome = "";
         SetDirty("Contratonome");
         return  ;
      }

      public bool gxTv_SdtProposta_Contratonome_IsNull( )
      {
         return (gxTv_SdtProposta_Contratonome_N==1) ;
      }

      [  SoapElement( ElementName = "ConvenioId" )]
      [  XmlElement( ElementName = "ConvenioId"   )]
      public int gxTpr_Convenioid
      {
         get {
            return gxTv_SdtProposta_Convenioid ;
         }

         set {
            gxTv_SdtProposta_Convenioid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Convenioid = value;
            SetDirty("Convenioid");
         }

      }

      public void gxTv_SdtProposta_Convenioid_SetNull( )
      {
         gxTv_SdtProposta_Convenioid_N = 1;
         gxTv_SdtProposta_Convenioid = 0;
         SetDirty("Convenioid");
         return  ;
      }

      public bool gxTv_SdtProposta_Convenioid_IsNull( )
      {
         return (gxTv_SdtProposta_Convenioid_N==1) ;
      }

      [  SoapElement( ElementName = "ConvenioVencimentoAno" )]
      [  XmlElement( ElementName = "ConvenioVencimentoAno"   )]
      public short gxTpr_Conveniovencimentoano
      {
         get {
            return gxTv_SdtProposta_Conveniovencimentoano ;
         }

         set {
            gxTv_SdtProposta_Conveniovencimentoano_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Conveniovencimentoano = value;
            SetDirty("Conveniovencimentoano");
         }

      }

      public void gxTv_SdtProposta_Conveniovencimentoano_SetNull( )
      {
         gxTv_SdtProposta_Conveniovencimentoano_N = 1;
         gxTv_SdtProposta_Conveniovencimentoano = 0;
         SetDirty("Conveniovencimentoano");
         return  ;
      }

      public bool gxTv_SdtProposta_Conveniovencimentoano_IsNull( )
      {
         return (gxTv_SdtProposta_Conveniovencimentoano_N==1) ;
      }

      [  SoapElement( ElementName = "ConvenioVencimentoMes" )]
      [  XmlElement( ElementName = "ConvenioVencimentoMes"   )]
      public short gxTpr_Conveniovencimentomes
      {
         get {
            return gxTv_SdtProposta_Conveniovencimentomes ;
         }

         set {
            gxTv_SdtProposta_Conveniovencimentomes_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Conveniovencimentomes = value;
            SetDirty("Conveniovencimentomes");
         }

      }

      public void gxTv_SdtProposta_Conveniovencimentomes_SetNull( )
      {
         gxTv_SdtProposta_Conveniovencimentomes_N = 1;
         gxTv_SdtProposta_Conveniovencimentomes = 0;
         SetDirty("Conveniovencimentomes");
         return  ;
      }

      public bool gxTv_SdtProposta_Conveniovencimentomes_IsNull( )
      {
         return (gxTv_SdtProposta_Conveniovencimentomes_N==1) ;
      }

      [  SoapElement( ElementName = "ConvenioCategoriaId" )]
      [  XmlElement( ElementName = "ConvenioCategoriaId"   )]
      public int gxTpr_Conveniocategoriaid
      {
         get {
            return gxTv_SdtProposta_Conveniocategoriaid ;
         }

         set {
            gxTv_SdtProposta_Conveniocategoriaid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Conveniocategoriaid = value;
            SetDirty("Conveniocategoriaid");
         }

      }

      public void gxTv_SdtProposta_Conveniocategoriaid_SetNull( )
      {
         gxTv_SdtProposta_Conveniocategoriaid_N = 1;
         gxTv_SdtProposta_Conveniocategoriaid = 0;
         SetDirty("Conveniocategoriaid");
         return  ;
      }

      public bool gxTv_SdtProposta_Conveniocategoriaid_IsNull( )
      {
         return (gxTv_SdtProposta_Conveniocategoriaid_N==1) ;
      }

      [  SoapElement( ElementName = "ConvenioCategoriaDescricao" )]
      [  XmlElement( ElementName = "ConvenioCategoriaDescricao"   )]
      public string gxTpr_Conveniocategoriadescricao
      {
         get {
            return gxTv_SdtProposta_Conveniocategoriadescricao ;
         }

         set {
            gxTv_SdtProposta_Conveniocategoriadescricao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Conveniocategoriadescricao = value;
            SetDirty("Conveniocategoriadescricao");
         }

      }

      public void gxTv_SdtProposta_Conveniocategoriadescricao_SetNull( )
      {
         gxTv_SdtProposta_Conveniocategoriadescricao_N = 1;
         gxTv_SdtProposta_Conveniocategoriadescricao = "";
         SetDirty("Conveniocategoriadescricao");
         return  ;
      }

      public bool gxTv_SdtProposta_Conveniocategoriadescricao_IsNull( )
      {
         return (gxTv_SdtProposta_Conveniocategoriadescricao_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaDataCreditoCliente_F" )]
      [  XmlElement( ElementName = "PropostaDataCreditoCliente_F"  , IsNullable=true )]
      public string gxTpr_Propostadatacreditocliente_f_Nullable
      {
         get {
            if ( gxTv_SdtProposta_Propostadatacreditocliente_f == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtProposta_Propostadatacreditocliente_f).value ;
         }

         set {
            gxTv_SdtProposta_Propostadatacreditocliente_f_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtProposta_Propostadatacreditocliente_f = DateTime.MinValue;
            else
               gxTv_SdtProposta_Propostadatacreditocliente_f = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Propostadatacreditocliente_f
      {
         get {
            return gxTv_SdtProposta_Propostadatacreditocliente_f ;
         }

         set {
            gxTv_SdtProposta_Propostadatacreditocliente_f_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostadatacreditocliente_f = value;
            SetDirty("Propostadatacreditocliente_f");
         }

      }

      public void gxTv_SdtProposta_Propostadatacreditocliente_f_SetNull( )
      {
         gxTv_SdtProposta_Propostadatacreditocliente_f_N = 1;
         gxTv_SdtProposta_Propostadatacreditocliente_f = (DateTime)(DateTime.MinValue);
         SetDirty("Propostadatacreditocliente_f");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostadatacreditocliente_f_IsNull( )
      {
         return (gxTv_SdtProposta_Propostadatacreditocliente_f_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaValorTaxa_F" )]
      [  XmlElement( ElementName = "PropostaValorTaxa_F"   )]
      public decimal gxTpr_Propostavalortaxa_f
      {
         get {
            return gxTv_SdtProposta_Propostavalortaxa_f ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostavalortaxa_f = value;
            SetDirty("Propostavalortaxa_f");
         }

      }

      public void gxTv_SdtProposta_Propostavalortaxa_f_SetNull( )
      {
         gxTv_SdtProposta_Propostavalortaxa_f = 0;
         SetDirty("Propostavalortaxa_f");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostavalortaxa_f_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaValorJurosMora_F" )]
      [  XmlElement( ElementName = "PropostaValorJurosMora_F"   )]
      public decimal gxTpr_Propostavalorjurosmora_f
      {
         get {
            return gxTv_SdtProposta_Propostavalorjurosmora_f ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostavalorjurosmora_f = value;
            SetDirty("Propostavalorjurosmora_f");
         }

      }

      public void gxTv_SdtProposta_Propostavalorjurosmora_f_SetNull( )
      {
         gxTv_SdtProposta_Propostavalorjurosmora_f = 0;
         SetDirty("Propostavalorjurosmora_f");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostavalorjurosmora_f_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaValorReembolsado_F" )]
      [  XmlElement( ElementName = "PropostaValorReembolsado_F"   )]
      public decimal gxTpr_Propostavalorreembolsado_f
      {
         get {
            return gxTv_SdtProposta_Propostavalorreembolsado_f ;
         }

         set {
            gxTv_SdtProposta_Propostavalorreembolsado_f_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostavalorreembolsado_f = value;
            SetDirty("Propostavalorreembolsado_f");
         }

      }

      public void gxTv_SdtProposta_Propostavalorreembolsado_f_SetNull( )
      {
         gxTv_SdtProposta_Propostavalorreembolsado_f_N = 1;
         gxTv_SdtProposta_Propostavalorreembolsado_f = 0;
         SetDirty("Propostavalorreembolsado_f");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostavalorreembolsado_f_IsNull( )
      {
         return (gxTv_SdtProposta_Propostavalorreembolsado_f_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaValorReembolsadoJuros_F" )]
      [  XmlElement( ElementName = "PropostaValorReembolsadoJuros_F"   )]
      public decimal gxTpr_Propostavalorreembolsadojuros_f
      {
         get {
            return gxTv_SdtProposta_Propostavalorreembolsadojuros_f ;
         }

         set {
            gxTv_SdtProposta_Propostavalorreembolsadojuros_f_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostavalorreembolsadojuros_f = value;
            SetDirty("Propostavalorreembolsadojuros_f");
         }

      }

      public void gxTv_SdtProposta_Propostavalorreembolsadojuros_f_SetNull( )
      {
         gxTv_SdtProposta_Propostavalorreembolsadojuros_f_N = 1;
         gxTv_SdtProposta_Propostavalorreembolsadojuros_f = 0;
         SetDirty("Propostavalorreembolsadojuros_f");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostavalorreembolsadojuros_f_IsNull( )
      {
         return (gxTv_SdtProposta_Propostavalorreembolsadojuros_f_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaValorTaxaRecebida_F" )]
      [  XmlElement( ElementName = "PropostaValorTaxaRecebida_F"   )]
      public decimal gxTpr_Propostavalortaxarecebida_f
      {
         get {
            return gxTv_SdtProposta_Propostavalortaxarecebida_f ;
         }

         set {
            gxTv_SdtProposta_Propostavalortaxarecebida_f_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostavalortaxarecebida_f = value;
            SetDirty("Propostavalortaxarecebida_f");
         }

      }

      public void gxTv_SdtProposta_Propostavalortaxarecebida_f_SetNull( )
      {
         gxTv_SdtProposta_Propostavalortaxarecebida_f_N = 1;
         gxTv_SdtProposta_Propostavalortaxarecebida_f = 0;
         SetDirty("Propostavalortaxarecebida_f");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostavalortaxarecebida_f_IsNull( )
      {
         return (gxTv_SdtProposta_Propostavalortaxarecebida_f_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaAprovacoes_F" )]
      [  XmlElement( ElementName = "PropostaAprovacoes_F"   )]
      public short gxTpr_Propostaaprovacoes_f
      {
         get {
            return gxTv_SdtProposta_Propostaaprovacoes_f ;
         }

         set {
            gxTv_SdtProposta_Propostaaprovacoes_f_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaaprovacoes_f = value;
            SetDirty("Propostaaprovacoes_f");
         }

      }

      public void gxTv_SdtProposta_Propostaaprovacoes_f_SetNull( )
      {
         gxTv_SdtProposta_Propostaaprovacoes_f_N = 1;
         gxTv_SdtProposta_Propostaaprovacoes_f = 0;
         SetDirty("Propostaaprovacoes_f");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaaprovacoes_f_IsNull( )
      {
         return (gxTv_SdtProposta_Propostaaprovacoes_f_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaReprovacoes_F" )]
      [  XmlElement( ElementName = "PropostaReprovacoes_F"   )]
      public short gxTpr_Propostareprovacoes_f
      {
         get {
            return gxTv_SdtProposta_Propostareprovacoes_f ;
         }

         set {
            gxTv_SdtProposta_Propostareprovacoes_f_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostareprovacoes_f = value;
            SetDirty("Propostareprovacoes_f");
         }

      }

      public void gxTv_SdtProposta_Propostareprovacoes_f_SetNull( )
      {
         gxTv_SdtProposta_Propostareprovacoes_f_N = 1;
         gxTv_SdtProposta_Propostareprovacoes_f = 0;
         SetDirty("Propostareprovacoes_f");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostareprovacoes_f_IsNull( )
      {
         return (gxTv_SdtProposta_Propostareprovacoes_f_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaAprovacoesRestantes_F" )]
      [  XmlElement( ElementName = "PropostaAprovacoesRestantes_F"   )]
      public short gxTpr_Propostaaprovacoesrestantes_f
      {
         get {
            return gxTv_SdtProposta_Propostaaprovacoesrestantes_f ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaaprovacoesrestantes_f = value;
            SetDirty("Propostaaprovacoesrestantes_f");
         }

      }

      public void gxTv_SdtProposta_Propostaaprovacoesrestantes_f_SetNull( )
      {
         gxTv_SdtProposta_Propostaaprovacoesrestantes_f = 0;
         SetDirty("Propostaaprovacoesrestantes_f");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaaprovacoesrestantes_f_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtProposta_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtProposta_Mode_SetNull( )
      {
         gxTv_SdtProposta_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtProposta_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtProposta_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtProposta_Initialized_SetNull( )
      {
         gxTv_SdtProposta_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtProposta_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaId_Z" )]
      [  XmlElement( ElementName = "PropostaId_Z"   )]
      public int gxTpr_Propostaid_Z
      {
         get {
            return gxTv_SdtProposta_Propostaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaid_Z = value;
            SetDirty("Propostaid_Z");
         }

      }

      public void gxTv_SdtProposta_Propostaid_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostaid_Z = 0;
         SetDirty("Propostaid_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaMaxReembolsoId_F_Z" )]
      [  XmlElement( ElementName = "PropostaMaxReembolsoId_F_Z"   )]
      public int gxTpr_Propostamaxreembolsoid_f_Z
      {
         get {
            return gxTv_SdtProposta_Propostamaxreembolsoid_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostamaxreembolsoid_f_Z = value;
            SetDirty("Propostamaxreembolsoid_f_Z");
         }

      }

      public void gxTv_SdtProposta_Propostamaxreembolsoid_f_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostamaxreembolsoid_f_Z = 0;
         SetDirty("Propostamaxreembolsoid_f_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostamaxreembolsoid_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaProtocolo_Z" )]
      [  XmlElement( ElementName = "PropostaProtocolo_Z"   )]
      public string gxTpr_Propostaprotocolo_Z
      {
         get {
            return gxTv_SdtProposta_Propostaprotocolo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaprotocolo_Z = value;
            SetDirty("Propostaprotocolo_Z");
         }

      }

      public void gxTv_SdtProposta_Propostaprotocolo_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostaprotocolo_Z = "";
         SetDirty("Propostaprotocolo_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaprotocolo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaEmpresaClienteId_Z" )]
      [  XmlElement( ElementName = "PropostaEmpresaClienteId_Z"   )]
      public int gxTpr_Propostaempresaclienteid_Z
      {
         get {
            return gxTv_SdtProposta_Propostaempresaclienteid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaempresaclienteid_Z = value;
            SetDirty("Propostaempresaclienteid_Z");
         }

      }

      public void gxTv_SdtProposta_Propostaempresaclienteid_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostaempresaclienteid_Z = 0;
         SetDirty("Propostaempresaclienteid_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaempresaclienteid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaTipoProposta_Z" )]
      [  XmlElement( ElementName = "PropostaTipoProposta_Z"   )]
      public string gxTpr_Propostatipoproposta_Z
      {
         get {
            return gxTv_SdtProposta_Propostatipoproposta_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostatipoproposta_Z = value;
            SetDirty("Propostatipoproposta_Z");
         }

      }

      public void gxTv_SdtProposta_Propostatipoproposta_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostatipoproposta_Z = "";
         SetDirty("Propostatipoproposta_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostatipoproposta_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaPacienteClienteId_Z" )]
      [  XmlElement( ElementName = "PropostaPacienteClienteId_Z"   )]
      public int gxTpr_Propostapacienteclienteid_Z
      {
         get {
            return gxTv_SdtProposta_Propostapacienteclienteid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacienteclienteid_Z = value;
            SetDirty("Propostapacienteclienteid_Z");
         }

      }

      public void gxTv_SdtProposta_Propostapacienteclienteid_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostapacienteclienteid_Z = 0;
         SetDirty("Propostapacienteclienteid_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostapacienteclienteid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaQtdItensNota_F_Z" )]
      [  XmlElement( ElementName = "PropostaQtdItensNota_F_Z"   )]
      public short gxTpr_Propostaqtditensnota_f_Z
      {
         get {
            return gxTv_SdtProposta_Propostaqtditensnota_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaqtditensnota_f_Z = value;
            SetDirty("Propostaqtditensnota_f_Z");
         }

      }

      public void gxTv_SdtProposta_Propostaqtditensnota_f_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostaqtditensnota_f_Z = 0;
         SetDirty("Propostaqtditensnota_f_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaqtditensnota_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaResponsavelId_Z" )]
      [  XmlElement( ElementName = "PropostaResponsavelId_Z"   )]
      public int gxTpr_Propostaresponsavelid_Z
      {
         get {
            return gxTv_SdtProposta_Propostaresponsavelid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaresponsavelid_Z = value;
            SetDirty("Propostaresponsavelid_Z");
         }

      }

      public void gxTv_SdtProposta_Propostaresponsavelid_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostaresponsavelid_Z = 0;
         SetDirty("Propostaresponsavelid_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaresponsavelid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaResponsavelDocumento_Z" )]
      [  XmlElement( ElementName = "PropostaResponsavelDocumento_Z"   )]
      public string gxTpr_Propostaresponsaveldocumento_Z
      {
         get {
            return gxTv_SdtProposta_Propostaresponsaveldocumento_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaresponsaveldocumento_Z = value;
            SetDirty("Propostaresponsaveldocumento_Z");
         }

      }

      public void gxTv_SdtProposta_Propostaresponsaveldocumento_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostaresponsaveldocumento_Z = "";
         SetDirty("Propostaresponsaveldocumento_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaresponsaveldocumento_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaResponsavelRazaoSocial_Z" )]
      [  XmlElement( ElementName = "PropostaResponsavelRazaoSocial_Z"   )]
      public string gxTpr_Propostaresponsavelrazaosocial_Z
      {
         get {
            return gxTv_SdtProposta_Propostaresponsavelrazaosocial_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaresponsavelrazaosocial_Z = value;
            SetDirty("Propostaresponsavelrazaosocial_Z");
         }

      }

      public void gxTv_SdtProposta_Propostaresponsavelrazaosocial_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostaresponsavelrazaosocial_Z = "";
         SetDirty("Propostaresponsavelrazaosocial_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaresponsavelrazaosocial_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaResponsavelEmail_Z" )]
      [  XmlElement( ElementName = "PropostaResponsavelEmail_Z"   )]
      public string gxTpr_Propostaresponsavelemail_Z
      {
         get {
            return gxTv_SdtProposta_Propostaresponsavelemail_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaresponsavelemail_Z = value;
            SetDirty("Propostaresponsavelemail_Z");
         }

      }

      public void gxTv_SdtProposta_Propostaresponsavelemail_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostaresponsavelemail_Z = "";
         SetDirty("Propostaresponsavelemail_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaresponsavelemail_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaResponsavelBanco_Z" )]
      [  XmlElement( ElementName = "PropostaResponsavelBanco_Z"   )]
      public string gxTpr_Propostaresponsavelbanco_Z
      {
         get {
            return gxTv_SdtProposta_Propostaresponsavelbanco_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaresponsavelbanco_Z = value;
            SetDirty("Propostaresponsavelbanco_Z");
         }

      }

      public void gxTv_SdtProposta_Propostaresponsavelbanco_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostaresponsavelbanco_Z = "";
         SetDirty("Propostaresponsavelbanco_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaresponsavelbanco_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaResponsavelConta_Z" )]
      [  XmlElement( ElementName = "PropostaResponsavelConta_Z"   )]
      public string gxTpr_Propostaresponsavelconta_Z
      {
         get {
            return gxTv_SdtProposta_Propostaresponsavelconta_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaresponsavelconta_Z = value;
            SetDirty("Propostaresponsavelconta_Z");
         }

      }

      public void gxTv_SdtProposta_Propostaresponsavelconta_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostaresponsavelconta_Z = "";
         SetDirty("Propostaresponsavelconta_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaresponsavelconta_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaResponsavelAgencia_Z" )]
      [  XmlElement( ElementName = "PropostaResponsavelAgencia_Z"   )]
      public string gxTpr_Propostaresponsavelagencia_Z
      {
         get {
            return gxTv_SdtProposta_Propostaresponsavelagencia_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaresponsavelagencia_Z = value;
            SetDirty("Propostaresponsavelagencia_Z");
         }

      }

      public void gxTv_SdtProposta_Propostaresponsavelagencia_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostaresponsavelagencia_Z = "";
         SetDirty("Propostaresponsavelagencia_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaresponsavelagencia_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaResponsavelTipoPix_Z" )]
      [  XmlElement( ElementName = "PropostaResponsavelTipoPix_Z"   )]
      public string gxTpr_Propostaresponsaveltipopix_Z
      {
         get {
            return gxTv_SdtProposta_Propostaresponsaveltipopix_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaresponsaveltipopix_Z = value;
            SetDirty("Propostaresponsaveltipopix_Z");
         }

      }

      public void gxTv_SdtProposta_Propostaresponsaveltipopix_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostaresponsaveltipopix_Z = "";
         SetDirty("Propostaresponsaveltipopix_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaresponsaveltipopix_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaResponsavelPIX_Z" )]
      [  XmlElement( ElementName = "PropostaResponsavelPIX_Z"   )]
      public string gxTpr_Propostaresponsavelpix_Z
      {
         get {
            return gxTv_SdtProposta_Propostaresponsavelpix_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaresponsavelpix_Z = value;
            SetDirty("Propostaresponsavelpix_Z");
         }

      }

      public void gxTv_SdtProposta_Propostaresponsavelpix_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostaresponsavelpix_Z = "";
         SetDirty("Propostaresponsavelpix_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaresponsavelpix_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaResponsavelDepositoTipo_Z" )]
      [  XmlElement( ElementName = "PropostaResponsavelDepositoTipo_Z"   )]
      public string gxTpr_Propostaresponsaveldepositotipo_Z
      {
         get {
            return gxTv_SdtProposta_Propostaresponsaveldepositotipo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaresponsaveldepositotipo_Z = value;
            SetDirty("Propostaresponsaveldepositotipo_Z");
         }

      }

      public void gxTv_SdtProposta_Propostaresponsaveldepositotipo_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostaresponsaveldepositotipo_Z = "";
         SetDirty("Propostaresponsaveldepositotipo_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaresponsaveldepositotipo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaResponsavelSerasaConsultas_F_Z" )]
      [  XmlElement( ElementName = "PropostaResponsavelSerasaConsultas_F_Z"   )]
      public short gxTpr_Propostaresponsavelserasaconsultas_f_Z
      {
         get {
            return gxTv_SdtProposta_Propostaresponsavelserasaconsultas_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaresponsavelserasaconsultas_f_Z = value;
            SetDirty("Propostaresponsavelserasaconsultas_f_Z");
         }

      }

      public void gxTv_SdtProposta_Propostaresponsavelserasaconsultas_f_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostaresponsavelserasaconsultas_f_Z = 0;
         SetDirty("Propostaresponsavelserasaconsultas_f_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaresponsavelserasaconsultas_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaResponsavelSerasaScoreUltimaData_F_Z" )]
      [  XmlElement( ElementName = "PropostaResponsavelSerasaScoreUltimaData_F_Z"   )]
      public short gxTpr_Propostaresponsavelserasascoreultimadata_f_Z
      {
         get {
            return gxTv_SdtProposta_Propostaresponsavelserasascoreultimadata_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaresponsavelserasascoreultimadata_f_Z = value;
            SetDirty("Propostaresponsavelserasascoreultimadata_f_Z");
         }

      }

      public void gxTv_SdtProposta_Propostaresponsavelserasascoreultimadata_f_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostaresponsavelserasascoreultimadata_f_Z = 0;
         SetDirty("Propostaresponsavelserasascoreultimadata_f_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaresponsavelserasascoreultimadata_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaResponsavelSerasaUltimoValorRecomendado_F_Z" )]
      [  XmlElement( ElementName = "PropostaResponsavelSerasaUltimoValorRecomendado_F_Z"   )]
      public decimal gxTpr_Propostaresponsavelserasaultimovalorrecomendado_f_Z
      {
         get {
            return gxTv_SdtProposta_Propostaresponsavelserasaultimovalorrecomendado_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaresponsavelserasaultimovalorrecomendado_f_Z = value;
            SetDirty("Propostaresponsavelserasaultimovalorrecomendado_f_Z");
         }

      }

      public void gxTv_SdtProposta_Propostaresponsavelserasaultimovalorrecomendado_f_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostaresponsavelserasaultimovalorrecomendado_f_Z = 0;
         SetDirty("Propostaresponsavelserasaultimovalorrecomendado_f_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaresponsavelserasaultimovalorrecomendado_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaPacienteClienteRazaoSocial_Z" )]
      [  XmlElement( ElementName = "PropostaPacienteClienteRazaoSocial_Z"   )]
      public string gxTpr_Propostapacienteclienterazaosocial_Z
      {
         get {
            return gxTv_SdtProposta_Propostapacienteclienterazaosocial_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacienteclienterazaosocial_Z = value;
            SetDirty("Propostapacienteclienterazaosocial_Z");
         }

      }

      public void gxTv_SdtProposta_Propostapacienteclienterazaosocial_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostapacienteclienterazaosocial_Z = "";
         SetDirty("Propostapacienteclienterazaosocial_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostapacienteclienterazaosocial_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaPacienteClienteDocumento_Z" )]
      [  XmlElement( ElementName = "PropostaPacienteClienteDocumento_Z"   )]
      public string gxTpr_Propostapacienteclientedocumento_Z
      {
         get {
            return gxTv_SdtProposta_Propostapacienteclientedocumento_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacienteclientedocumento_Z = value;
            SetDirty("Propostapacienteclientedocumento_Z");
         }

      }

      public void gxTv_SdtProposta_Propostapacienteclientedocumento_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostapacienteclientedocumento_Z = "";
         SetDirty("Propostapacienteclientedocumento_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostapacienteclientedocumento_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaPacienteContatoEmail_Z" )]
      [  XmlElement( ElementName = "PropostaPacienteContatoEmail_Z"   )]
      public string gxTpr_Propostapacientecontatoemail_Z
      {
         get {
            return gxTv_SdtProposta_Propostapacientecontatoemail_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacientecontatoemail_Z = value;
            SetDirty("Propostapacientecontatoemail_Z");
         }

      }

      public void gxTv_SdtProposta_Propostapacientecontatoemail_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostapacientecontatoemail_Z = "";
         SetDirty("Propostapacientecontatoemail_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostapacientecontatoemail_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaPacienteBanco_Z" )]
      [  XmlElement( ElementName = "PropostaPacienteBanco_Z"   )]
      public string gxTpr_Propostapacientebanco_Z
      {
         get {
            return gxTv_SdtProposta_Propostapacientebanco_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacientebanco_Z = value;
            SetDirty("Propostapacientebanco_Z");
         }

      }

      public void gxTv_SdtProposta_Propostapacientebanco_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostapacientebanco_Z = "";
         SetDirty("Propostapacientebanco_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostapacientebanco_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaPacienteConta_Z" )]
      [  XmlElement( ElementName = "PropostaPacienteConta_Z"   )]
      public string gxTpr_Propostapacienteconta_Z
      {
         get {
            return gxTv_SdtProposta_Propostapacienteconta_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacienteconta_Z = value;
            SetDirty("Propostapacienteconta_Z");
         }

      }

      public void gxTv_SdtProposta_Propostapacienteconta_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostapacienteconta_Z = "";
         SetDirty("Propostapacienteconta_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostapacienteconta_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaPacienteAgencia_Z" )]
      [  XmlElement( ElementName = "PropostaPacienteAgencia_Z"   )]
      public string gxTpr_Propostapacienteagencia_Z
      {
         get {
            return gxTv_SdtProposta_Propostapacienteagencia_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacienteagencia_Z = value;
            SetDirty("Propostapacienteagencia_Z");
         }

      }

      public void gxTv_SdtProposta_Propostapacienteagencia_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostapacienteagencia_Z = "";
         SetDirty("Propostapacienteagencia_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostapacienteagencia_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaPacienteTipoPix_Z" )]
      [  XmlElement( ElementName = "PropostaPacienteTipoPix_Z"   )]
      public string gxTpr_Propostapacientetipopix_Z
      {
         get {
            return gxTv_SdtProposta_Propostapacientetipopix_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacientetipopix_Z = value;
            SetDirty("Propostapacientetipopix_Z");
         }

      }

      public void gxTv_SdtProposta_Propostapacientetipopix_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostapacientetipopix_Z = "";
         SetDirty("Propostapacientetipopix_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostapacientetipopix_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaPacientePIX_Z" )]
      [  XmlElement( ElementName = "PropostaPacientePIX_Z"   )]
      public string gxTpr_Propostapacientepix_Z
      {
         get {
            return gxTv_SdtProposta_Propostapacientepix_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacientepix_Z = value;
            SetDirty("Propostapacientepix_Z");
         }

      }

      public void gxTv_SdtProposta_Propostapacientepix_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostapacientepix_Z = "";
         SetDirty("Propostapacientepix_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostapacientepix_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaPacienteDepositoTipo_Z" )]
      [  XmlElement( ElementName = "PropostaPacienteDepositoTipo_Z"   )]
      public string gxTpr_Propostapacientedepositotipo_Z
      {
         get {
            return gxTv_SdtProposta_Propostapacientedepositotipo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacientedepositotipo_Z = value;
            SetDirty("Propostapacientedepositotipo_Z");
         }

      }

      public void gxTv_SdtProposta_Propostapacientedepositotipo_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostapacientedepositotipo_Z = "";
         SetDirty("Propostapacientedepositotipo_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostapacientedepositotipo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaPacienteEnderecoCEP_Z" )]
      [  XmlElement( ElementName = "PropostaPacienteEnderecoCEP_Z"   )]
      public string gxTpr_Propostapacienteenderecocep_Z
      {
         get {
            return gxTv_SdtProposta_Propostapacienteenderecocep_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacienteenderecocep_Z = value;
            SetDirty("Propostapacienteenderecocep_Z");
         }

      }

      public void gxTv_SdtProposta_Propostapacienteenderecocep_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostapacienteenderecocep_Z = "";
         SetDirty("Propostapacienteenderecocep_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostapacienteenderecocep_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaPacienteEnderecoLogradouro_Z" )]
      [  XmlElement( ElementName = "PropostaPacienteEnderecoLogradouro_Z"   )]
      public string gxTpr_Propostapacienteenderecologradouro_Z
      {
         get {
            return gxTv_SdtProposta_Propostapacienteenderecologradouro_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacienteenderecologradouro_Z = value;
            SetDirty("Propostapacienteenderecologradouro_Z");
         }

      }

      public void gxTv_SdtProposta_Propostapacienteenderecologradouro_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostapacienteenderecologradouro_Z = "";
         SetDirty("Propostapacienteenderecologradouro_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostapacienteenderecologradouro_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaPacienteEnderecoNumero_Z" )]
      [  XmlElement( ElementName = "PropostaPacienteEnderecoNumero_Z"   )]
      public string gxTpr_Propostapacienteendereconumero_Z
      {
         get {
            return gxTv_SdtProposta_Propostapacienteendereconumero_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacienteendereconumero_Z = value;
            SetDirty("Propostapacienteendereconumero_Z");
         }

      }

      public void gxTv_SdtProposta_Propostapacienteendereconumero_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostapacienteendereconumero_Z = "";
         SetDirty("Propostapacienteendereconumero_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostapacienteendereconumero_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaPacienteEnderecoComplemento_Z" )]
      [  XmlElement( ElementName = "PropostaPacienteEnderecoComplemento_Z"   )]
      public string gxTpr_Propostapacienteenderecocomplemento_Z
      {
         get {
            return gxTv_SdtProposta_Propostapacienteenderecocomplemento_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacienteenderecocomplemento_Z = value;
            SetDirty("Propostapacienteenderecocomplemento_Z");
         }

      }

      public void gxTv_SdtProposta_Propostapacienteenderecocomplemento_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostapacienteenderecocomplemento_Z = "";
         SetDirty("Propostapacienteenderecocomplemento_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostapacienteenderecocomplemento_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaPacienteEnderecoBairro_Z" )]
      [  XmlElement( ElementName = "PropostaPacienteEnderecoBairro_Z"   )]
      public string gxTpr_Propostapacienteenderecobairro_Z
      {
         get {
            return gxTv_SdtProposta_Propostapacienteenderecobairro_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacienteenderecobairro_Z = value;
            SetDirty("Propostapacienteenderecobairro_Z");
         }

      }

      public void gxTv_SdtProposta_Propostapacienteenderecobairro_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostapacienteenderecobairro_Z = "";
         SetDirty("Propostapacienteenderecobairro_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostapacienteenderecobairro_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaPacienteMunicipioCodigo_Z" )]
      [  XmlElement( ElementName = "PropostaPacienteMunicipioCodigo_Z"   )]
      public string gxTpr_Propostapacientemunicipiocodigo_Z
      {
         get {
            return gxTv_SdtProposta_Propostapacientemunicipiocodigo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacientemunicipiocodigo_Z = value;
            SetDirty("Propostapacientemunicipiocodigo_Z");
         }

      }

      public void gxTv_SdtProposta_Propostapacientemunicipiocodigo_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostapacientemunicipiocodigo_Z = "";
         SetDirty("Propostapacientemunicipiocodigo_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostapacientemunicipiocodigo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaPacienteSerasaConsultas_F_Z" )]
      [  XmlElement( ElementName = "PropostaPacienteSerasaConsultas_F_Z"   )]
      public short gxTpr_Propostapacienteserasaconsultas_f_Z
      {
         get {
            return gxTv_SdtProposta_Propostapacienteserasaconsultas_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacienteserasaconsultas_f_Z = value;
            SetDirty("Propostapacienteserasaconsultas_f_Z");
         }

      }

      public void gxTv_SdtProposta_Propostapacienteserasaconsultas_f_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostapacienteserasaconsultas_f_Z = 0;
         SetDirty("Propostapacienteserasaconsultas_f_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostapacienteserasaconsultas_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaSerasaScoreUltimaData_F_Z" )]
      [  XmlElement( ElementName = "PropostaSerasaScoreUltimaData_F_Z"   )]
      public short gxTpr_Propostaserasascoreultimadata_f_Z
      {
         get {
            return gxTv_SdtProposta_Propostaserasascoreultimadata_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaserasascoreultimadata_f_Z = value;
            SetDirty("Propostaserasascoreultimadata_f_Z");
         }

      }

      public void gxTv_SdtProposta_Propostaserasascoreultimadata_f_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostaserasascoreultimadata_f_Z = 0;
         SetDirty("Propostaserasascoreultimadata_f_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaserasascoreultimadata_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaPacienteSerasaUltimoValorRecomendado_F_Z" )]
      [  XmlElement( ElementName = "PropostaPacienteSerasaUltimoValorRecomendado_F_Z"   )]
      public decimal gxTpr_Propostapacienteserasaultimovalorrecomendado_f_Z
      {
         get {
            return gxTv_SdtProposta_Propostapacienteserasaultimovalorrecomendado_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacienteserasaultimovalorrecomendado_f_Z = value;
            SetDirty("Propostapacienteserasaultimovalorrecomendado_f_Z");
         }

      }

      public void gxTv_SdtProposta_Propostapacienteserasaultimovalorrecomendado_f_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostapacienteserasaultimovalorrecomendado_f_Z = 0;
         SetDirty("Propostapacienteserasaultimovalorrecomendado_f_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostapacienteserasaultimovalorrecomendado_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaValorTaxaClinica_F_Z" )]
      [  XmlElement( ElementName = "PropostaValorTaxaClinica_F_Z"   )]
      public decimal gxTpr_Propostavalortaxaclinica_f_Z
      {
         get {
            return gxTv_SdtProposta_Propostavalortaxaclinica_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostavalortaxaclinica_f_Z = value;
            SetDirty("Propostavalortaxaclinica_f_Z");
         }

      }

      public void gxTv_SdtProposta_Propostavalortaxaclinica_f_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostavalortaxaclinica_f_Z = 0;
         SetDirty("Propostavalortaxaclinica_f_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostavalortaxaclinica_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaQtdDocumentoPendente_F_Z" )]
      [  XmlElement( ElementName = "PropostaQtdDocumentoPendente_F_Z"   )]
      public short gxTpr_Propostaqtddocumentopendente_f_Z
      {
         get {
            return gxTv_SdtProposta_Propostaqtddocumentopendente_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaqtddocumentopendente_f_Z = value;
            SetDirty("Propostaqtddocumentopendente_f_Z");
         }

      }

      public void gxTv_SdtProposta_Propostaqtddocumentopendente_f_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostaqtddocumentopendente_f_Z = 0;
         SetDirty("Propostaqtddocumentopendente_f_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaqtddocumentopendente_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaMaiorScore_F_Z" )]
      [  XmlElement( ElementName = "PropostaMaiorScore_F_Z"   )]
      public short gxTpr_Propostamaiorscore_f_Z
      {
         get {
            return gxTv_SdtProposta_Propostamaiorscore_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostamaiorscore_f_Z = value;
            SetDirty("Propostamaiorscore_f_Z");
         }

      }

      public void gxTv_SdtProposta_Propostamaiorscore_f_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostamaiorscore_f_Z = 0;
         SetDirty("Propostamaiorscore_f_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostamaiorscore_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaMaiorValorRecomendado_Z" )]
      [  XmlElement( ElementName = "PropostaMaiorValorRecomendado_Z"   )]
      public decimal gxTpr_Propostamaiorvalorrecomendado_Z
      {
         get {
            return gxTv_SdtProposta_Propostamaiorvalorrecomendado_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostamaiorvalorrecomendado_Z = value;
            SetDirty("Propostamaiorvalorrecomendado_Z");
         }

      }

      public void gxTv_SdtProposta_Propostamaiorvalorrecomendado_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostamaiorvalorrecomendado_Z = 0;
         SetDirty("Propostamaiorvalorrecomendado_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostamaiorvalorrecomendado_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaTitulo_Z" )]
      [  XmlElement( ElementName = "PropostaTitulo_Z"   )]
      public string gxTpr_Propostatitulo_Z
      {
         get {
            return gxTv_SdtProposta_Propostatitulo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostatitulo_Z = value;
            SetDirty("Propostatitulo_Z");
         }

      }

      public void gxTv_SdtProposta_Propostatitulo_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostatitulo_Z = "";
         SetDirty("Propostatitulo_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostatitulo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProcedimentosMedicosId_Z" )]
      [  XmlElement( ElementName = "ProcedimentosMedicosId_Z"   )]
      public int gxTpr_Procedimentosmedicosid_Z
      {
         get {
            return gxTv_SdtProposta_Procedimentosmedicosid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Procedimentosmedicosid_Z = value;
            SetDirty("Procedimentosmedicosid_Z");
         }

      }

      public void gxTv_SdtProposta_Procedimentosmedicosid_Z_SetNull( )
      {
         gxTv_SdtProposta_Procedimentosmedicosid_Z = 0;
         SetDirty("Procedimentosmedicosid_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Procedimentosmedicosid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaDescricao_Z" )]
      [  XmlElement( ElementName = "PropostaDescricao_Z"   )]
      public string gxTpr_Propostadescricao_Z
      {
         get {
            return gxTv_SdtProposta_Propostadescricao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostadescricao_Z = value;
            SetDirty("Propostadescricao_Z");
         }

      }

      public void gxTv_SdtProposta_Propostadescricao_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostadescricao_Z = "";
         SetDirty("Propostadescricao_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostadescricao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaDataCirurgia_Z" )]
      [  XmlElement( ElementName = "PropostaDataCirurgia_Z"  , IsNullable=true )]
      public string gxTpr_Propostadatacirurgia_Z_Nullable
      {
         get {
            if ( gxTv_SdtProposta_Propostadatacirurgia_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtProposta_Propostadatacirurgia_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtProposta_Propostadatacirurgia_Z = DateTime.MinValue;
            else
               gxTv_SdtProposta_Propostadatacirurgia_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Propostadatacirurgia_Z
      {
         get {
            return gxTv_SdtProposta_Propostadatacirurgia_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostadatacirurgia_Z = value;
            SetDirty("Propostadatacirurgia_Z");
         }

      }

      public void gxTv_SdtProposta_Propostadatacirurgia_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostadatacirurgia_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Propostadatacirurgia_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostadatacirurgia_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaValor_Z" )]
      [  XmlElement( ElementName = "PropostaValor_Z"   )]
      public decimal gxTpr_Propostavalor_Z
      {
         get {
            return gxTv_SdtProposta_Propostavalor_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostavalor_Z = value;
            SetDirty("Propostavalor_Z");
         }

      }

      public void gxTv_SdtProposta_Propostavalor_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostavalor_Z = 0;
         SetDirty("Propostavalor_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostavalor_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaValorLiquido_Z" )]
      [  XmlElement( ElementName = "PropostaValorLiquido_Z"   )]
      public decimal gxTpr_Propostavalorliquido_Z
      {
         get {
            return gxTv_SdtProposta_Propostavalorliquido_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostavalorliquido_Z = value;
            SetDirty("Propostavalorliquido_Z");
         }

      }

      public void gxTv_SdtProposta_Propostavalorliquido_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostavalorliquido_Z = 0;
         SetDirty("Propostavalorliquido_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostavalorliquido_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaTaxaAdministrativa_Z" )]
      [  XmlElement( ElementName = "PropostaTaxaAdministrativa_Z"   )]
      public decimal gxTpr_Propostataxaadministrativa_Z
      {
         get {
            return gxTv_SdtProposta_Propostataxaadministrativa_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostataxaadministrativa_Z = value;
            SetDirty("Propostataxaadministrativa_Z");
         }

      }

      public void gxTv_SdtProposta_Propostataxaadministrativa_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostataxaadministrativa_Z = 0;
         SetDirty("Propostataxaadministrativa_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostataxaadministrativa_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaTaxa_F_Z" )]
      [  XmlElement( ElementName = "PropostaTaxa_F_Z"   )]
      public decimal gxTpr_Propostataxa_f_Z
      {
         get {
            return gxTv_SdtProposta_Propostataxa_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostataxa_f_Z = value;
            SetDirty("Propostataxa_f_Z");
         }

      }

      public void gxTv_SdtProposta_Propostataxa_f_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostataxa_f_Z = 0;
         SetDirty("Propostataxa_f_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostataxa_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaSLA_Z" )]
      [  XmlElement( ElementName = "PropostaSLA_Z"   )]
      public short gxTpr_Propostasla_Z
      {
         get {
            return gxTv_SdtProposta_Propostasla_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostasla_Z = value;
            SetDirty("Propostasla_Z");
         }

      }

      public void gxTv_SdtProposta_Propostasla_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostasla_Z = 0;
         SetDirty("Propostasla_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostasla_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaJurosMora_Z" )]
      [  XmlElement( ElementName = "PropostaJurosMora_Z"   )]
      public decimal gxTpr_Propostajurosmora_Z
      {
         get {
            return gxTv_SdtProposta_Propostajurosmora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostajurosmora_Z = value;
            SetDirty("Propostajurosmora_Z");
         }

      }

      public void gxTv_SdtProposta_Propostajurosmora_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostajurosmora_Z = 0;
         SetDirty("Propostajurosmora_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostajurosmora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaCreatedAt_Z" )]
      [  XmlElement( ElementName = "PropostaCreatedAt_Z"  , IsNullable=true )]
      public string gxTpr_Propostacreatedat_Z_Nullable
      {
         get {
            if ( gxTv_SdtProposta_Propostacreatedat_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtProposta_Propostacreatedat_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtProposta_Propostacreatedat_Z = DateTime.MinValue;
            else
               gxTv_SdtProposta_Propostacreatedat_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Propostacreatedat_Z
      {
         get {
            return gxTv_SdtProposta_Propostacreatedat_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostacreatedat_Z = value;
            SetDirty("Propostacreatedat_Z");
         }

      }

      public void gxTv_SdtProposta_Propostacreatedat_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostacreatedat_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Propostacreatedat_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostacreatedat_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaCratedBy_Z" )]
      [  XmlElement( ElementName = "PropostaCratedBy_Z"   )]
      public short gxTpr_Propostacratedby_Z
      {
         get {
            return gxTv_SdtProposta_Propostacratedby_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostacratedby_Z = value;
            SetDirty("Propostacratedby_Z");
         }

      }

      public void gxTv_SdtProposta_Propostacratedby_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostacratedby_Z = 0;
         SetDirty("Propostacratedby_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostacratedby_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaClinicaId_Z" )]
      [  XmlElement( ElementName = "PropostaClinicaId_Z"   )]
      public int gxTpr_Propostaclinicaid_Z
      {
         get {
            return gxTv_SdtProposta_Propostaclinicaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaclinicaid_Z = value;
            SetDirty("Propostaclinicaid_Z");
         }

      }

      public void gxTv_SdtProposta_Propostaclinicaid_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostaclinicaid_Z = 0;
         SetDirty("Propostaclinicaid_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaclinicaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaClinicaNome_Z" )]
      [  XmlElement( ElementName = "PropostaClinicaNome_Z"   )]
      public string gxTpr_Propostaclinicanome_Z
      {
         get {
            return gxTv_SdtProposta_Propostaclinicanome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaclinicanome_Z = value;
            SetDirty("Propostaclinicanome_Z");
         }

      }

      public void gxTv_SdtProposta_Propostaclinicanome_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostaclinicanome_Z = "";
         SetDirty("Propostaclinicanome_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaclinicanome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaClinicaNomeFantasia_Z" )]
      [  XmlElement( ElementName = "PropostaClinicaNomeFantasia_Z"   )]
      public string gxTpr_Propostaclinicanomefantasia_Z
      {
         get {
            return gxTv_SdtProposta_Propostaclinicanomefantasia_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaclinicanomefantasia_Z = value;
            SetDirty("Propostaclinicanomefantasia_Z");
         }

      }

      public void gxTv_SdtProposta_Propostaclinicanomefantasia_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostaclinicanomefantasia_Z = "";
         SetDirty("Propostaclinicanomefantasia_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaclinicanomefantasia_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaClinicaDocumento_Z" )]
      [  XmlElement( ElementName = "PropostaClinicaDocumento_Z"   )]
      public string gxTpr_Propostaclinicadocumento_Z
      {
         get {
            return gxTv_SdtProposta_Propostaclinicadocumento_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaclinicadocumento_Z = value;
            SetDirty("Propostaclinicadocumento_Z");
         }

      }

      public void gxTv_SdtProposta_Propostaclinicadocumento_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostaclinicadocumento_Z = "";
         SetDirty("Propostaclinicadocumento_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaclinicadocumento_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaClinicaEmail_Z" )]
      [  XmlElement( ElementName = "PropostaClinicaEmail_Z"   )]
      public string gxTpr_Propostaclinicaemail_Z
      {
         get {
            return gxTv_SdtProposta_Propostaclinicaemail_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaclinicaemail_Z = value;
            SetDirty("Propostaclinicaemail_Z");
         }

      }

      public void gxTv_SdtProposta_Propostaclinicaemail_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostaclinicaemail_Z = "";
         SetDirty("Propostaclinicaemail_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaclinicaemail_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaSecUserName_Z" )]
      [  XmlElement( ElementName = "PropostaSecUserName_Z"   )]
      public string gxTpr_Propostasecusername_Z
      {
         get {
            return gxTv_SdtProposta_Propostasecusername_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostasecusername_Z = value;
            SetDirty("Propostasecusername_Z");
         }

      }

      public void gxTv_SdtProposta_Propostasecusername_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostasecusername_Z = "";
         SetDirty("Propostasecusername_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostasecusername_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaStatus_Z" )]
      [  XmlElement( ElementName = "PropostaStatus_Z"   )]
      public string gxTpr_Propostastatus_Z
      {
         get {
            return gxTv_SdtProposta_Propostastatus_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostastatus_Z = value;
            SetDirty("Propostastatus_Z");
         }

      }

      public void gxTv_SdtProposta_Propostastatus_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostastatus_Z = "";
         SetDirty("Propostastatus_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostastatus_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaComentarioAnalise_Z" )]
      [  XmlElement( ElementName = "PropostaComentarioAnalise_Z"   )]
      public string gxTpr_Propostacomentarioanalise_Z
      {
         get {
            return gxTv_SdtProposta_Propostacomentarioanalise_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostacomentarioanalise_Z = value;
            SetDirty("Propostacomentarioanalise_Z");
         }

      }

      public void gxTv_SdtProposta_Propostacomentarioanalise_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostacomentarioanalise_Z = "";
         SetDirty("Propostacomentarioanalise_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostacomentarioanalise_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaQuantidadeAprovadores_Z" )]
      [  XmlElement( ElementName = "PropostaQuantidadeAprovadores_Z"   )]
      public short gxTpr_Propostaquantidadeaprovadores_Z
      {
         get {
            return gxTv_SdtProposta_Propostaquantidadeaprovadores_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaquantidadeaprovadores_Z = value;
            SetDirty("Propostaquantidadeaprovadores_Z");
         }

      }

      public void gxTv_SdtProposta_Propostaquantidadeaprovadores_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostaquantidadeaprovadores_Z = 0;
         SetDirty("Propostaquantidadeaprovadores_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaquantidadeaprovadores_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaReprovacoesPermitidas_Z" )]
      [  XmlElement( ElementName = "PropostaReprovacoesPermitidas_Z"   )]
      public short gxTpr_Propostareprovacoespermitidas_Z
      {
         get {
            return gxTv_SdtProposta_Propostareprovacoespermitidas_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostareprovacoespermitidas_Z = value;
            SetDirty("Propostareprovacoespermitidas_Z");
         }

      }

      public void gxTv_SdtProposta_Propostareprovacoespermitidas_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostareprovacoespermitidas_Z = 0;
         SetDirty("Propostareprovacoespermitidas_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostareprovacoespermitidas_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoId_Z" )]
      [  XmlElement( ElementName = "ContratoId_Z"   )]
      public int gxTpr_Contratoid_Z
      {
         get {
            return gxTv_SdtProposta_Contratoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Contratoid_Z = value;
            SetDirty("Contratoid_Z");
         }

      }

      public void gxTv_SdtProposta_Contratoid_Z_SetNull( )
      {
         gxTv_SdtProposta_Contratoid_Z = 0;
         SetDirty("Contratoid_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Contratoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoNome_Z" )]
      [  XmlElement( ElementName = "ContratoNome_Z"   )]
      public string gxTpr_Contratonome_Z
      {
         get {
            return gxTv_SdtProposta_Contratonome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Contratonome_Z = value;
            SetDirty("Contratonome_Z");
         }

      }

      public void gxTv_SdtProposta_Contratonome_Z_SetNull( )
      {
         gxTv_SdtProposta_Contratonome_Z = "";
         SetDirty("Contratonome_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Contratonome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConvenioId_Z" )]
      [  XmlElement( ElementName = "ConvenioId_Z"   )]
      public int gxTpr_Convenioid_Z
      {
         get {
            return gxTv_SdtProposta_Convenioid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Convenioid_Z = value;
            SetDirty("Convenioid_Z");
         }

      }

      public void gxTv_SdtProposta_Convenioid_Z_SetNull( )
      {
         gxTv_SdtProposta_Convenioid_Z = 0;
         SetDirty("Convenioid_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Convenioid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConvenioVencimentoAno_Z" )]
      [  XmlElement( ElementName = "ConvenioVencimentoAno_Z"   )]
      public short gxTpr_Conveniovencimentoano_Z
      {
         get {
            return gxTv_SdtProposta_Conveniovencimentoano_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Conveniovencimentoano_Z = value;
            SetDirty("Conveniovencimentoano_Z");
         }

      }

      public void gxTv_SdtProposta_Conveniovencimentoano_Z_SetNull( )
      {
         gxTv_SdtProposta_Conveniovencimentoano_Z = 0;
         SetDirty("Conveniovencimentoano_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Conveniovencimentoano_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConvenioVencimentoMes_Z" )]
      [  XmlElement( ElementName = "ConvenioVencimentoMes_Z"   )]
      public short gxTpr_Conveniovencimentomes_Z
      {
         get {
            return gxTv_SdtProposta_Conveniovencimentomes_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Conveniovencimentomes_Z = value;
            SetDirty("Conveniovencimentomes_Z");
         }

      }

      public void gxTv_SdtProposta_Conveniovencimentomes_Z_SetNull( )
      {
         gxTv_SdtProposta_Conveniovencimentomes_Z = 0;
         SetDirty("Conveniovencimentomes_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Conveniovencimentomes_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConvenioCategoriaId_Z" )]
      [  XmlElement( ElementName = "ConvenioCategoriaId_Z"   )]
      public int gxTpr_Conveniocategoriaid_Z
      {
         get {
            return gxTv_SdtProposta_Conveniocategoriaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Conveniocategoriaid_Z = value;
            SetDirty("Conveniocategoriaid_Z");
         }

      }

      public void gxTv_SdtProposta_Conveniocategoriaid_Z_SetNull( )
      {
         gxTv_SdtProposta_Conveniocategoriaid_Z = 0;
         SetDirty("Conveniocategoriaid_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Conveniocategoriaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConvenioCategoriaDescricao_Z" )]
      [  XmlElement( ElementName = "ConvenioCategoriaDescricao_Z"   )]
      public string gxTpr_Conveniocategoriadescricao_Z
      {
         get {
            return gxTv_SdtProposta_Conveniocategoriadescricao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Conveniocategoriadescricao_Z = value;
            SetDirty("Conveniocategoriadescricao_Z");
         }

      }

      public void gxTv_SdtProposta_Conveniocategoriadescricao_Z_SetNull( )
      {
         gxTv_SdtProposta_Conveniocategoriadescricao_Z = "";
         SetDirty("Conveniocategoriadescricao_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Conveniocategoriadescricao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaDataCreditoCliente_F_Z" )]
      [  XmlElement( ElementName = "PropostaDataCreditoCliente_F_Z"  , IsNullable=true )]
      public string gxTpr_Propostadatacreditocliente_f_Z_Nullable
      {
         get {
            if ( gxTv_SdtProposta_Propostadatacreditocliente_f_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtProposta_Propostadatacreditocliente_f_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtProposta_Propostadatacreditocliente_f_Z = DateTime.MinValue;
            else
               gxTv_SdtProposta_Propostadatacreditocliente_f_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Propostadatacreditocliente_f_Z
      {
         get {
            return gxTv_SdtProposta_Propostadatacreditocliente_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostadatacreditocliente_f_Z = value;
            SetDirty("Propostadatacreditocliente_f_Z");
         }

      }

      public void gxTv_SdtProposta_Propostadatacreditocliente_f_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostadatacreditocliente_f_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Propostadatacreditocliente_f_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostadatacreditocliente_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaValorTaxa_F_Z" )]
      [  XmlElement( ElementName = "PropostaValorTaxa_F_Z"   )]
      public decimal gxTpr_Propostavalortaxa_f_Z
      {
         get {
            return gxTv_SdtProposta_Propostavalortaxa_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostavalortaxa_f_Z = value;
            SetDirty("Propostavalortaxa_f_Z");
         }

      }

      public void gxTv_SdtProposta_Propostavalortaxa_f_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostavalortaxa_f_Z = 0;
         SetDirty("Propostavalortaxa_f_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostavalortaxa_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaValorJurosMora_F_Z" )]
      [  XmlElement( ElementName = "PropostaValorJurosMora_F_Z"   )]
      public decimal gxTpr_Propostavalorjurosmora_f_Z
      {
         get {
            return gxTv_SdtProposta_Propostavalorjurosmora_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostavalorjurosmora_f_Z = value;
            SetDirty("Propostavalorjurosmora_f_Z");
         }

      }

      public void gxTv_SdtProposta_Propostavalorjurosmora_f_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostavalorjurosmora_f_Z = 0;
         SetDirty("Propostavalorjurosmora_f_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostavalorjurosmora_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaValorReembolsado_F_Z" )]
      [  XmlElement( ElementName = "PropostaValorReembolsado_F_Z"   )]
      public decimal gxTpr_Propostavalorreembolsado_f_Z
      {
         get {
            return gxTv_SdtProposta_Propostavalorreembolsado_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostavalorreembolsado_f_Z = value;
            SetDirty("Propostavalorreembolsado_f_Z");
         }

      }

      public void gxTv_SdtProposta_Propostavalorreembolsado_f_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostavalorreembolsado_f_Z = 0;
         SetDirty("Propostavalorreembolsado_f_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostavalorreembolsado_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaValorReembolsadoJuros_F_Z" )]
      [  XmlElement( ElementName = "PropostaValorReembolsadoJuros_F_Z"   )]
      public decimal gxTpr_Propostavalorreembolsadojuros_f_Z
      {
         get {
            return gxTv_SdtProposta_Propostavalorreembolsadojuros_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostavalorreembolsadojuros_f_Z = value;
            SetDirty("Propostavalorreembolsadojuros_f_Z");
         }

      }

      public void gxTv_SdtProposta_Propostavalorreembolsadojuros_f_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostavalorreembolsadojuros_f_Z = 0;
         SetDirty("Propostavalorreembolsadojuros_f_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostavalorreembolsadojuros_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaValorTaxaRecebida_F_Z" )]
      [  XmlElement( ElementName = "PropostaValorTaxaRecebida_F_Z"   )]
      public decimal gxTpr_Propostavalortaxarecebida_f_Z
      {
         get {
            return gxTv_SdtProposta_Propostavalortaxarecebida_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostavalortaxarecebida_f_Z = value;
            SetDirty("Propostavalortaxarecebida_f_Z");
         }

      }

      public void gxTv_SdtProposta_Propostavalortaxarecebida_f_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostavalortaxarecebida_f_Z = 0;
         SetDirty("Propostavalortaxarecebida_f_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostavalortaxarecebida_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaAprovacoes_F_Z" )]
      [  XmlElement( ElementName = "PropostaAprovacoes_F_Z"   )]
      public short gxTpr_Propostaaprovacoes_f_Z
      {
         get {
            return gxTv_SdtProposta_Propostaaprovacoes_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaaprovacoes_f_Z = value;
            SetDirty("Propostaaprovacoes_f_Z");
         }

      }

      public void gxTv_SdtProposta_Propostaaprovacoes_f_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostaaprovacoes_f_Z = 0;
         SetDirty("Propostaaprovacoes_f_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaaprovacoes_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaReprovacoes_F_Z" )]
      [  XmlElement( ElementName = "PropostaReprovacoes_F_Z"   )]
      public short gxTpr_Propostareprovacoes_f_Z
      {
         get {
            return gxTv_SdtProposta_Propostareprovacoes_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostareprovacoes_f_Z = value;
            SetDirty("Propostareprovacoes_f_Z");
         }

      }

      public void gxTv_SdtProposta_Propostareprovacoes_f_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostareprovacoes_f_Z = 0;
         SetDirty("Propostareprovacoes_f_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostareprovacoes_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaAprovacoesRestantes_F_Z" )]
      [  XmlElement( ElementName = "PropostaAprovacoesRestantes_F_Z"   )]
      public short gxTpr_Propostaaprovacoesrestantes_f_Z
      {
         get {
            return gxTv_SdtProposta_Propostaaprovacoesrestantes_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaaprovacoesrestantes_f_Z = value;
            SetDirty("Propostaaprovacoesrestantes_f_Z");
         }

      }

      public void gxTv_SdtProposta_Propostaaprovacoesrestantes_f_Z_SetNull( )
      {
         gxTv_SdtProposta_Propostaaprovacoesrestantes_f_Z = 0;
         SetDirty("Propostaaprovacoesrestantes_f_Z");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaaprovacoesrestantes_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaId_N" )]
      [  XmlElement( ElementName = "PropostaId_N"   )]
      public short gxTpr_Propostaid_N
      {
         get {
            return gxTv_SdtProposta_Propostaid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaid_N = value;
            SetDirty("Propostaid_N");
         }

      }

      public void gxTv_SdtProposta_Propostaid_N_SetNull( )
      {
         gxTv_SdtProposta_Propostaid_N = 0;
         SetDirty("Propostaid_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaMaxReembolsoId_F_N" )]
      [  XmlElement( ElementName = "PropostaMaxReembolsoId_F_N"   )]
      public short gxTpr_Propostamaxreembolsoid_f_N
      {
         get {
            return gxTv_SdtProposta_Propostamaxreembolsoid_f_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostamaxreembolsoid_f_N = value;
            SetDirty("Propostamaxreembolsoid_f_N");
         }

      }

      public void gxTv_SdtProposta_Propostamaxreembolsoid_f_N_SetNull( )
      {
         gxTv_SdtProposta_Propostamaxreembolsoid_f_N = 0;
         SetDirty("Propostamaxreembolsoid_f_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostamaxreembolsoid_f_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaProtocolo_N" )]
      [  XmlElement( ElementName = "PropostaProtocolo_N"   )]
      public short gxTpr_Propostaprotocolo_N
      {
         get {
            return gxTv_SdtProposta_Propostaprotocolo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaprotocolo_N = value;
            SetDirty("Propostaprotocolo_N");
         }

      }

      public void gxTv_SdtProposta_Propostaprotocolo_N_SetNull( )
      {
         gxTv_SdtProposta_Propostaprotocolo_N = 0;
         SetDirty("Propostaprotocolo_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaprotocolo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaEmpresaClienteId_N" )]
      [  XmlElement( ElementName = "PropostaEmpresaClienteId_N"   )]
      public short gxTpr_Propostaempresaclienteid_N
      {
         get {
            return gxTv_SdtProposta_Propostaempresaclienteid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaempresaclienteid_N = value;
            SetDirty("Propostaempresaclienteid_N");
         }

      }

      public void gxTv_SdtProposta_Propostaempresaclienteid_N_SetNull( )
      {
         gxTv_SdtProposta_Propostaempresaclienteid_N = 0;
         SetDirty("Propostaempresaclienteid_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaempresaclienteid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaTipoProposta_N" )]
      [  XmlElement( ElementName = "PropostaTipoProposta_N"   )]
      public short gxTpr_Propostatipoproposta_N
      {
         get {
            return gxTv_SdtProposta_Propostatipoproposta_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostatipoproposta_N = value;
            SetDirty("Propostatipoproposta_N");
         }

      }

      public void gxTv_SdtProposta_Propostatipoproposta_N_SetNull( )
      {
         gxTv_SdtProposta_Propostatipoproposta_N = 0;
         SetDirty("Propostatipoproposta_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostatipoproposta_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaPacienteClienteId_N" )]
      [  XmlElement( ElementName = "PropostaPacienteClienteId_N"   )]
      public short gxTpr_Propostapacienteclienteid_N
      {
         get {
            return gxTv_SdtProposta_Propostapacienteclienteid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacienteclienteid_N = value;
            SetDirty("Propostapacienteclienteid_N");
         }

      }

      public void gxTv_SdtProposta_Propostapacienteclienteid_N_SetNull( )
      {
         gxTv_SdtProposta_Propostapacienteclienteid_N = 0;
         SetDirty("Propostapacienteclienteid_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostapacienteclienteid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaQtdItensNota_F_N" )]
      [  XmlElement( ElementName = "PropostaQtdItensNota_F_N"   )]
      public short gxTpr_Propostaqtditensnota_f_N
      {
         get {
            return gxTv_SdtProposta_Propostaqtditensnota_f_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaqtditensnota_f_N = value;
            SetDirty("Propostaqtditensnota_f_N");
         }

      }

      public void gxTv_SdtProposta_Propostaqtditensnota_f_N_SetNull( )
      {
         gxTv_SdtProposta_Propostaqtditensnota_f_N = 0;
         SetDirty("Propostaqtditensnota_f_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaqtditensnota_f_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaResponsavelId_N" )]
      [  XmlElement( ElementName = "PropostaResponsavelId_N"   )]
      public short gxTpr_Propostaresponsavelid_N
      {
         get {
            return gxTv_SdtProposta_Propostaresponsavelid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaresponsavelid_N = value;
            SetDirty("Propostaresponsavelid_N");
         }

      }

      public void gxTv_SdtProposta_Propostaresponsavelid_N_SetNull( )
      {
         gxTv_SdtProposta_Propostaresponsavelid_N = 0;
         SetDirty("Propostaresponsavelid_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaresponsavelid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaResponsavelDocumento_N" )]
      [  XmlElement( ElementName = "PropostaResponsavelDocumento_N"   )]
      public short gxTpr_Propostaresponsaveldocumento_N
      {
         get {
            return gxTv_SdtProposta_Propostaresponsaveldocumento_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaresponsaveldocumento_N = value;
            SetDirty("Propostaresponsaveldocumento_N");
         }

      }

      public void gxTv_SdtProposta_Propostaresponsaveldocumento_N_SetNull( )
      {
         gxTv_SdtProposta_Propostaresponsaveldocumento_N = 0;
         SetDirty("Propostaresponsaveldocumento_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaresponsaveldocumento_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaResponsavelRazaoSocial_N" )]
      [  XmlElement( ElementName = "PropostaResponsavelRazaoSocial_N"   )]
      public short gxTpr_Propostaresponsavelrazaosocial_N
      {
         get {
            return gxTv_SdtProposta_Propostaresponsavelrazaosocial_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaresponsavelrazaosocial_N = value;
            SetDirty("Propostaresponsavelrazaosocial_N");
         }

      }

      public void gxTv_SdtProposta_Propostaresponsavelrazaosocial_N_SetNull( )
      {
         gxTv_SdtProposta_Propostaresponsavelrazaosocial_N = 0;
         SetDirty("Propostaresponsavelrazaosocial_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaresponsavelrazaosocial_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaResponsavelEmail_N" )]
      [  XmlElement( ElementName = "PropostaResponsavelEmail_N"   )]
      public short gxTpr_Propostaresponsavelemail_N
      {
         get {
            return gxTv_SdtProposta_Propostaresponsavelemail_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaresponsavelemail_N = value;
            SetDirty("Propostaresponsavelemail_N");
         }

      }

      public void gxTv_SdtProposta_Propostaresponsavelemail_N_SetNull( )
      {
         gxTv_SdtProposta_Propostaresponsavelemail_N = 0;
         SetDirty("Propostaresponsavelemail_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaresponsavelemail_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaResponsavelConta_N" )]
      [  XmlElement( ElementName = "PropostaResponsavelConta_N"   )]
      public short gxTpr_Propostaresponsavelconta_N
      {
         get {
            return gxTv_SdtProposta_Propostaresponsavelconta_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaresponsavelconta_N = value;
            SetDirty("Propostaresponsavelconta_N");
         }

      }

      public void gxTv_SdtProposta_Propostaresponsavelconta_N_SetNull( )
      {
         gxTv_SdtProposta_Propostaresponsavelconta_N = 0;
         SetDirty("Propostaresponsavelconta_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaresponsavelconta_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaResponsavelAgencia_N" )]
      [  XmlElement( ElementName = "PropostaResponsavelAgencia_N"   )]
      public short gxTpr_Propostaresponsavelagencia_N
      {
         get {
            return gxTv_SdtProposta_Propostaresponsavelagencia_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaresponsavelagencia_N = value;
            SetDirty("Propostaresponsavelagencia_N");
         }

      }

      public void gxTv_SdtProposta_Propostaresponsavelagencia_N_SetNull( )
      {
         gxTv_SdtProposta_Propostaresponsavelagencia_N = 0;
         SetDirty("Propostaresponsavelagencia_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaresponsavelagencia_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaResponsavelTipoPix_N" )]
      [  XmlElement( ElementName = "PropostaResponsavelTipoPix_N"   )]
      public short gxTpr_Propostaresponsaveltipopix_N
      {
         get {
            return gxTv_SdtProposta_Propostaresponsaveltipopix_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaresponsaveltipopix_N = value;
            SetDirty("Propostaresponsaveltipopix_N");
         }

      }

      public void gxTv_SdtProposta_Propostaresponsaveltipopix_N_SetNull( )
      {
         gxTv_SdtProposta_Propostaresponsaveltipopix_N = 0;
         SetDirty("Propostaresponsaveltipopix_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaresponsaveltipopix_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaResponsavelPIX_N" )]
      [  XmlElement( ElementName = "PropostaResponsavelPIX_N"   )]
      public short gxTpr_Propostaresponsavelpix_N
      {
         get {
            return gxTv_SdtProposta_Propostaresponsavelpix_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaresponsavelpix_N = value;
            SetDirty("Propostaresponsavelpix_N");
         }

      }

      public void gxTv_SdtProposta_Propostaresponsavelpix_N_SetNull( )
      {
         gxTv_SdtProposta_Propostaresponsavelpix_N = 0;
         SetDirty("Propostaresponsavelpix_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaresponsavelpix_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaResponsavelDepositoTipo_N" )]
      [  XmlElement( ElementName = "PropostaResponsavelDepositoTipo_N"   )]
      public short gxTpr_Propostaresponsaveldepositotipo_N
      {
         get {
            return gxTv_SdtProposta_Propostaresponsaveldepositotipo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaresponsaveldepositotipo_N = value;
            SetDirty("Propostaresponsaveldepositotipo_N");
         }

      }

      public void gxTv_SdtProposta_Propostaresponsaveldepositotipo_N_SetNull( )
      {
         gxTv_SdtProposta_Propostaresponsaveldepositotipo_N = 0;
         SetDirty("Propostaresponsaveldepositotipo_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaresponsaveldepositotipo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaResponsavelSerasaConsultas_F_N" )]
      [  XmlElement( ElementName = "PropostaResponsavelSerasaConsultas_F_N"   )]
      public short gxTpr_Propostaresponsavelserasaconsultas_f_N
      {
         get {
            return gxTv_SdtProposta_Propostaresponsavelserasaconsultas_f_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaresponsavelserasaconsultas_f_N = value;
            SetDirty("Propostaresponsavelserasaconsultas_f_N");
         }

      }

      public void gxTv_SdtProposta_Propostaresponsavelserasaconsultas_f_N_SetNull( )
      {
         gxTv_SdtProposta_Propostaresponsavelserasaconsultas_f_N = 0;
         SetDirty("Propostaresponsavelserasaconsultas_f_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaresponsavelserasaconsultas_f_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaResponsavelSerasaScoreUltimaData_F_N" )]
      [  XmlElement( ElementName = "PropostaResponsavelSerasaScoreUltimaData_F_N"   )]
      public short gxTpr_Propostaresponsavelserasascoreultimadata_f_N
      {
         get {
            return gxTv_SdtProposta_Propostaresponsavelserasascoreultimadata_f_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaresponsavelserasascoreultimadata_f_N = value;
            SetDirty("Propostaresponsavelserasascoreultimadata_f_N");
         }

      }

      public void gxTv_SdtProposta_Propostaresponsavelserasascoreultimadata_f_N_SetNull( )
      {
         gxTv_SdtProposta_Propostaresponsavelserasascoreultimadata_f_N = 0;
         SetDirty("Propostaresponsavelserasascoreultimadata_f_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaresponsavelserasascoreultimadata_f_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaResponsavelSerasaUltimoValorRecomendado_F_N" )]
      [  XmlElement( ElementName = "PropostaResponsavelSerasaUltimoValorRecomendado_F_N"   )]
      public short gxTpr_Propostaresponsavelserasaultimovalorrecomendado_f_N
      {
         get {
            return gxTv_SdtProposta_Propostaresponsavelserasaultimovalorrecomendado_f_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaresponsavelserasaultimovalorrecomendado_f_N = value;
            SetDirty("Propostaresponsavelserasaultimovalorrecomendado_f_N");
         }

      }

      public void gxTv_SdtProposta_Propostaresponsavelserasaultimovalorrecomendado_f_N_SetNull( )
      {
         gxTv_SdtProposta_Propostaresponsavelserasaultimovalorrecomendado_f_N = 0;
         SetDirty("Propostaresponsavelserasaultimovalorrecomendado_f_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaresponsavelserasaultimovalorrecomendado_f_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaPacienteClienteRazaoSocial_N" )]
      [  XmlElement( ElementName = "PropostaPacienteClienteRazaoSocial_N"   )]
      public short gxTpr_Propostapacienteclienterazaosocial_N
      {
         get {
            return gxTv_SdtProposta_Propostapacienteclienterazaosocial_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacienteclienterazaosocial_N = value;
            SetDirty("Propostapacienteclienterazaosocial_N");
         }

      }

      public void gxTv_SdtProposta_Propostapacienteclienterazaosocial_N_SetNull( )
      {
         gxTv_SdtProposta_Propostapacienteclienterazaosocial_N = 0;
         SetDirty("Propostapacienteclienterazaosocial_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostapacienteclienterazaosocial_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaPacienteClienteDocumento_N" )]
      [  XmlElement( ElementName = "PropostaPacienteClienteDocumento_N"   )]
      public short gxTpr_Propostapacienteclientedocumento_N
      {
         get {
            return gxTv_SdtProposta_Propostapacienteclientedocumento_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacienteclientedocumento_N = value;
            SetDirty("Propostapacienteclientedocumento_N");
         }

      }

      public void gxTv_SdtProposta_Propostapacienteclientedocumento_N_SetNull( )
      {
         gxTv_SdtProposta_Propostapacienteclientedocumento_N = 0;
         SetDirty("Propostapacienteclientedocumento_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostapacienteclientedocumento_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaPacienteContatoEmail_N" )]
      [  XmlElement( ElementName = "PropostaPacienteContatoEmail_N"   )]
      public short gxTpr_Propostapacientecontatoemail_N
      {
         get {
            return gxTv_SdtProposta_Propostapacientecontatoemail_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacientecontatoemail_N = value;
            SetDirty("Propostapacientecontatoemail_N");
         }

      }

      public void gxTv_SdtProposta_Propostapacientecontatoemail_N_SetNull( )
      {
         gxTv_SdtProposta_Propostapacientecontatoemail_N = 0;
         SetDirty("Propostapacientecontatoemail_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostapacientecontatoemail_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaPacienteConta_N" )]
      [  XmlElement( ElementName = "PropostaPacienteConta_N"   )]
      public short gxTpr_Propostapacienteconta_N
      {
         get {
            return gxTv_SdtProposta_Propostapacienteconta_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacienteconta_N = value;
            SetDirty("Propostapacienteconta_N");
         }

      }

      public void gxTv_SdtProposta_Propostapacienteconta_N_SetNull( )
      {
         gxTv_SdtProposta_Propostapacienteconta_N = 0;
         SetDirty("Propostapacienteconta_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostapacienteconta_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaPacienteAgencia_N" )]
      [  XmlElement( ElementName = "PropostaPacienteAgencia_N"   )]
      public short gxTpr_Propostapacienteagencia_N
      {
         get {
            return gxTv_SdtProposta_Propostapacienteagencia_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacienteagencia_N = value;
            SetDirty("Propostapacienteagencia_N");
         }

      }

      public void gxTv_SdtProposta_Propostapacienteagencia_N_SetNull( )
      {
         gxTv_SdtProposta_Propostapacienteagencia_N = 0;
         SetDirty("Propostapacienteagencia_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostapacienteagencia_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaPacienteTipoPix_N" )]
      [  XmlElement( ElementName = "PropostaPacienteTipoPix_N"   )]
      public short gxTpr_Propostapacientetipopix_N
      {
         get {
            return gxTv_SdtProposta_Propostapacientetipopix_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacientetipopix_N = value;
            SetDirty("Propostapacientetipopix_N");
         }

      }

      public void gxTv_SdtProposta_Propostapacientetipopix_N_SetNull( )
      {
         gxTv_SdtProposta_Propostapacientetipopix_N = 0;
         SetDirty("Propostapacientetipopix_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostapacientetipopix_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaPacientePIX_N" )]
      [  XmlElement( ElementName = "PropostaPacientePIX_N"   )]
      public short gxTpr_Propostapacientepix_N
      {
         get {
            return gxTv_SdtProposta_Propostapacientepix_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacientepix_N = value;
            SetDirty("Propostapacientepix_N");
         }

      }

      public void gxTv_SdtProposta_Propostapacientepix_N_SetNull( )
      {
         gxTv_SdtProposta_Propostapacientepix_N = 0;
         SetDirty("Propostapacientepix_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostapacientepix_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaPacienteDepositoTipo_N" )]
      [  XmlElement( ElementName = "PropostaPacienteDepositoTipo_N"   )]
      public short gxTpr_Propostapacientedepositotipo_N
      {
         get {
            return gxTv_SdtProposta_Propostapacientedepositotipo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacientedepositotipo_N = value;
            SetDirty("Propostapacientedepositotipo_N");
         }

      }

      public void gxTv_SdtProposta_Propostapacientedepositotipo_N_SetNull( )
      {
         gxTv_SdtProposta_Propostapacientedepositotipo_N = 0;
         SetDirty("Propostapacientedepositotipo_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostapacientedepositotipo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaPacienteEnderecoCEP_N" )]
      [  XmlElement( ElementName = "PropostaPacienteEnderecoCEP_N"   )]
      public short gxTpr_Propostapacienteenderecocep_N
      {
         get {
            return gxTv_SdtProposta_Propostapacienteenderecocep_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacienteenderecocep_N = value;
            SetDirty("Propostapacienteenderecocep_N");
         }

      }

      public void gxTv_SdtProposta_Propostapacienteenderecocep_N_SetNull( )
      {
         gxTv_SdtProposta_Propostapacienteenderecocep_N = 0;
         SetDirty("Propostapacienteenderecocep_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostapacienteenderecocep_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaPacienteEnderecoLogradouro_N" )]
      [  XmlElement( ElementName = "PropostaPacienteEnderecoLogradouro_N"   )]
      public short gxTpr_Propostapacienteenderecologradouro_N
      {
         get {
            return gxTv_SdtProposta_Propostapacienteenderecologradouro_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacienteenderecologradouro_N = value;
            SetDirty("Propostapacienteenderecologradouro_N");
         }

      }

      public void gxTv_SdtProposta_Propostapacienteenderecologradouro_N_SetNull( )
      {
         gxTv_SdtProposta_Propostapacienteenderecologradouro_N = 0;
         SetDirty("Propostapacienteenderecologradouro_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostapacienteenderecologradouro_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaPacienteEnderecoNumero_N" )]
      [  XmlElement( ElementName = "PropostaPacienteEnderecoNumero_N"   )]
      public short gxTpr_Propostapacienteendereconumero_N
      {
         get {
            return gxTv_SdtProposta_Propostapacienteendereconumero_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacienteendereconumero_N = value;
            SetDirty("Propostapacienteendereconumero_N");
         }

      }

      public void gxTv_SdtProposta_Propostapacienteendereconumero_N_SetNull( )
      {
         gxTv_SdtProposta_Propostapacienteendereconumero_N = 0;
         SetDirty("Propostapacienteendereconumero_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostapacienteendereconumero_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaPacienteEnderecoComplemento_N" )]
      [  XmlElement( ElementName = "PropostaPacienteEnderecoComplemento_N"   )]
      public short gxTpr_Propostapacienteenderecocomplemento_N
      {
         get {
            return gxTv_SdtProposta_Propostapacienteenderecocomplemento_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacienteenderecocomplemento_N = value;
            SetDirty("Propostapacienteenderecocomplemento_N");
         }

      }

      public void gxTv_SdtProposta_Propostapacienteenderecocomplemento_N_SetNull( )
      {
         gxTv_SdtProposta_Propostapacienteenderecocomplemento_N = 0;
         SetDirty("Propostapacienteenderecocomplemento_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostapacienteenderecocomplemento_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaPacienteEnderecoBairro_N" )]
      [  XmlElement( ElementName = "PropostaPacienteEnderecoBairro_N"   )]
      public short gxTpr_Propostapacienteenderecobairro_N
      {
         get {
            return gxTv_SdtProposta_Propostapacienteenderecobairro_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacienteenderecobairro_N = value;
            SetDirty("Propostapacienteenderecobairro_N");
         }

      }

      public void gxTv_SdtProposta_Propostapacienteenderecobairro_N_SetNull( )
      {
         gxTv_SdtProposta_Propostapacienteenderecobairro_N = 0;
         SetDirty("Propostapacienteenderecobairro_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostapacienteenderecobairro_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaPacienteMunicipioCodigo_N" )]
      [  XmlElement( ElementName = "PropostaPacienteMunicipioCodigo_N"   )]
      public short gxTpr_Propostapacientemunicipiocodigo_N
      {
         get {
            return gxTv_SdtProposta_Propostapacientemunicipiocodigo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacientemunicipiocodigo_N = value;
            SetDirty("Propostapacientemunicipiocodigo_N");
         }

      }

      public void gxTv_SdtProposta_Propostapacientemunicipiocodigo_N_SetNull( )
      {
         gxTv_SdtProposta_Propostapacientemunicipiocodigo_N = 0;
         SetDirty("Propostapacientemunicipiocodigo_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostapacientemunicipiocodigo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaPacienteSerasaConsultas_F_N" )]
      [  XmlElement( ElementName = "PropostaPacienteSerasaConsultas_F_N"   )]
      public short gxTpr_Propostapacienteserasaconsultas_f_N
      {
         get {
            return gxTv_SdtProposta_Propostapacienteserasaconsultas_f_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacienteserasaconsultas_f_N = value;
            SetDirty("Propostapacienteserasaconsultas_f_N");
         }

      }

      public void gxTv_SdtProposta_Propostapacienteserasaconsultas_f_N_SetNull( )
      {
         gxTv_SdtProposta_Propostapacienteserasaconsultas_f_N = 0;
         SetDirty("Propostapacienteserasaconsultas_f_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostapacienteserasaconsultas_f_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaSerasaScoreUltimaData_F_N" )]
      [  XmlElement( ElementName = "PropostaSerasaScoreUltimaData_F_N"   )]
      public short gxTpr_Propostaserasascoreultimadata_f_N
      {
         get {
            return gxTv_SdtProposta_Propostaserasascoreultimadata_f_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaserasascoreultimadata_f_N = value;
            SetDirty("Propostaserasascoreultimadata_f_N");
         }

      }

      public void gxTv_SdtProposta_Propostaserasascoreultimadata_f_N_SetNull( )
      {
         gxTv_SdtProposta_Propostaserasascoreultimadata_f_N = 0;
         SetDirty("Propostaserasascoreultimadata_f_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaserasascoreultimadata_f_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaPacienteSerasaUltimoValorRecomendado_F_N" )]
      [  XmlElement( ElementName = "PropostaPacienteSerasaUltimoValorRecomendado_F_N"   )]
      public short gxTpr_Propostapacienteserasaultimovalorrecomendado_f_N
      {
         get {
            return gxTv_SdtProposta_Propostapacienteserasaultimovalorrecomendado_f_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostapacienteserasaultimovalorrecomendado_f_N = value;
            SetDirty("Propostapacienteserasaultimovalorrecomendado_f_N");
         }

      }

      public void gxTv_SdtProposta_Propostapacienteserasaultimovalorrecomendado_f_N_SetNull( )
      {
         gxTv_SdtProposta_Propostapacienteserasaultimovalorrecomendado_f_N = 0;
         SetDirty("Propostapacienteserasaultimovalorrecomendado_f_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostapacienteserasaultimovalorrecomendado_f_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaValorTaxaClinica_F_N" )]
      [  XmlElement( ElementName = "PropostaValorTaxaClinica_F_N"   )]
      public short gxTpr_Propostavalortaxaclinica_f_N
      {
         get {
            return gxTv_SdtProposta_Propostavalortaxaclinica_f_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostavalortaxaclinica_f_N = value;
            SetDirty("Propostavalortaxaclinica_f_N");
         }

      }

      public void gxTv_SdtProposta_Propostavalortaxaclinica_f_N_SetNull( )
      {
         gxTv_SdtProposta_Propostavalortaxaclinica_f_N = 0;
         SetDirty("Propostavalortaxaclinica_f_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostavalortaxaclinica_f_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaQtdDocumentoPendente_F_N" )]
      [  XmlElement( ElementName = "PropostaQtdDocumentoPendente_F_N"   )]
      public short gxTpr_Propostaqtddocumentopendente_f_N
      {
         get {
            return gxTv_SdtProposta_Propostaqtddocumentopendente_f_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaqtddocumentopendente_f_N = value;
            SetDirty("Propostaqtddocumentopendente_f_N");
         }

      }

      public void gxTv_SdtProposta_Propostaqtddocumentopendente_f_N_SetNull( )
      {
         gxTv_SdtProposta_Propostaqtddocumentopendente_f_N = 0;
         SetDirty("Propostaqtddocumentopendente_f_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaqtddocumentopendente_f_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaTitulo_N" )]
      [  XmlElement( ElementName = "PropostaTitulo_N"   )]
      public short gxTpr_Propostatitulo_N
      {
         get {
            return gxTv_SdtProposta_Propostatitulo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostatitulo_N = value;
            SetDirty("Propostatitulo_N");
         }

      }

      public void gxTv_SdtProposta_Propostatitulo_N_SetNull( )
      {
         gxTv_SdtProposta_Propostatitulo_N = 0;
         SetDirty("Propostatitulo_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostatitulo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProcedimentosMedicosId_N" )]
      [  XmlElement( ElementName = "ProcedimentosMedicosId_N"   )]
      public short gxTpr_Procedimentosmedicosid_N
      {
         get {
            return gxTv_SdtProposta_Procedimentosmedicosid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Procedimentosmedicosid_N = value;
            SetDirty("Procedimentosmedicosid_N");
         }

      }

      public void gxTv_SdtProposta_Procedimentosmedicosid_N_SetNull( )
      {
         gxTv_SdtProposta_Procedimentosmedicosid_N = 0;
         SetDirty("Procedimentosmedicosid_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Procedimentosmedicosid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaDescricao_N" )]
      [  XmlElement( ElementName = "PropostaDescricao_N"   )]
      public short gxTpr_Propostadescricao_N
      {
         get {
            return gxTv_SdtProposta_Propostadescricao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostadescricao_N = value;
            SetDirty("Propostadescricao_N");
         }

      }

      public void gxTv_SdtProposta_Propostadescricao_N_SetNull( )
      {
         gxTv_SdtProposta_Propostadescricao_N = 0;
         SetDirty("Propostadescricao_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostadescricao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaDataCirurgia_N" )]
      [  XmlElement( ElementName = "PropostaDataCirurgia_N"   )]
      public short gxTpr_Propostadatacirurgia_N
      {
         get {
            return gxTv_SdtProposta_Propostadatacirurgia_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostadatacirurgia_N = value;
            SetDirty("Propostadatacirurgia_N");
         }

      }

      public void gxTv_SdtProposta_Propostadatacirurgia_N_SetNull( )
      {
         gxTv_SdtProposta_Propostadatacirurgia_N = 0;
         SetDirty("Propostadatacirurgia_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostadatacirurgia_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaValor_N" )]
      [  XmlElement( ElementName = "PropostaValor_N"   )]
      public short gxTpr_Propostavalor_N
      {
         get {
            return gxTv_SdtProposta_Propostavalor_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostavalor_N = value;
            SetDirty("Propostavalor_N");
         }

      }

      public void gxTv_SdtProposta_Propostavalor_N_SetNull( )
      {
         gxTv_SdtProposta_Propostavalor_N = 0;
         SetDirty("Propostavalor_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostavalor_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaValorLiquido_N" )]
      [  XmlElement( ElementName = "PropostaValorLiquido_N"   )]
      public short gxTpr_Propostavalorliquido_N
      {
         get {
            return gxTv_SdtProposta_Propostavalorliquido_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostavalorliquido_N = value;
            SetDirty("Propostavalorliquido_N");
         }

      }

      public void gxTv_SdtProposta_Propostavalorliquido_N_SetNull( )
      {
         gxTv_SdtProposta_Propostavalorliquido_N = 0;
         SetDirty("Propostavalorliquido_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostavalorliquido_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaTaxaAdministrativa_N" )]
      [  XmlElement( ElementName = "PropostaTaxaAdministrativa_N"   )]
      public short gxTpr_Propostataxaadministrativa_N
      {
         get {
            return gxTv_SdtProposta_Propostataxaadministrativa_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostataxaadministrativa_N = value;
            SetDirty("Propostataxaadministrativa_N");
         }

      }

      public void gxTv_SdtProposta_Propostataxaadministrativa_N_SetNull( )
      {
         gxTv_SdtProposta_Propostataxaadministrativa_N = 0;
         SetDirty("Propostataxaadministrativa_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostataxaadministrativa_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaSLA_N" )]
      [  XmlElement( ElementName = "PropostaSLA_N"   )]
      public short gxTpr_Propostasla_N
      {
         get {
            return gxTv_SdtProposta_Propostasla_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostasla_N = value;
            SetDirty("Propostasla_N");
         }

      }

      public void gxTv_SdtProposta_Propostasla_N_SetNull( )
      {
         gxTv_SdtProposta_Propostasla_N = 0;
         SetDirty("Propostasla_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostasla_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaJurosMora_N" )]
      [  XmlElement( ElementName = "PropostaJurosMora_N"   )]
      public short gxTpr_Propostajurosmora_N
      {
         get {
            return gxTv_SdtProposta_Propostajurosmora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostajurosmora_N = value;
            SetDirty("Propostajurosmora_N");
         }

      }

      public void gxTv_SdtProposta_Propostajurosmora_N_SetNull( )
      {
         gxTv_SdtProposta_Propostajurosmora_N = 0;
         SetDirty("Propostajurosmora_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostajurosmora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaCreatedAt_N" )]
      [  XmlElement( ElementName = "PropostaCreatedAt_N"   )]
      public short gxTpr_Propostacreatedat_N
      {
         get {
            return gxTv_SdtProposta_Propostacreatedat_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostacreatedat_N = value;
            SetDirty("Propostacreatedat_N");
         }

      }

      public void gxTv_SdtProposta_Propostacreatedat_N_SetNull( )
      {
         gxTv_SdtProposta_Propostacreatedat_N = 0;
         SetDirty("Propostacreatedat_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostacreatedat_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaCratedBy_N" )]
      [  XmlElement( ElementName = "PropostaCratedBy_N"   )]
      public short gxTpr_Propostacratedby_N
      {
         get {
            return gxTv_SdtProposta_Propostacratedby_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostacratedby_N = value;
            SetDirty("Propostacratedby_N");
         }

      }

      public void gxTv_SdtProposta_Propostacratedby_N_SetNull( )
      {
         gxTv_SdtProposta_Propostacratedby_N = 0;
         SetDirty("Propostacratedby_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostacratedby_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaClinicaId_N" )]
      [  XmlElement( ElementName = "PropostaClinicaId_N"   )]
      public short gxTpr_Propostaclinicaid_N
      {
         get {
            return gxTv_SdtProposta_Propostaclinicaid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaclinicaid_N = value;
            SetDirty("Propostaclinicaid_N");
         }

      }

      public void gxTv_SdtProposta_Propostaclinicaid_N_SetNull( )
      {
         gxTv_SdtProposta_Propostaclinicaid_N = 0;
         SetDirty("Propostaclinicaid_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaclinicaid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaClinicaNome_N" )]
      [  XmlElement( ElementName = "PropostaClinicaNome_N"   )]
      public short gxTpr_Propostaclinicanome_N
      {
         get {
            return gxTv_SdtProposta_Propostaclinicanome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaclinicanome_N = value;
            SetDirty("Propostaclinicanome_N");
         }

      }

      public void gxTv_SdtProposta_Propostaclinicanome_N_SetNull( )
      {
         gxTv_SdtProposta_Propostaclinicanome_N = 0;
         SetDirty("Propostaclinicanome_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaclinicanome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaClinicaNomeFantasia_N" )]
      [  XmlElement( ElementName = "PropostaClinicaNomeFantasia_N"   )]
      public short gxTpr_Propostaclinicanomefantasia_N
      {
         get {
            return gxTv_SdtProposta_Propostaclinicanomefantasia_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaclinicanomefantasia_N = value;
            SetDirty("Propostaclinicanomefantasia_N");
         }

      }

      public void gxTv_SdtProposta_Propostaclinicanomefantasia_N_SetNull( )
      {
         gxTv_SdtProposta_Propostaclinicanomefantasia_N = 0;
         SetDirty("Propostaclinicanomefantasia_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaclinicanomefantasia_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaClinicaDocumento_N" )]
      [  XmlElement( ElementName = "PropostaClinicaDocumento_N"   )]
      public short gxTpr_Propostaclinicadocumento_N
      {
         get {
            return gxTv_SdtProposta_Propostaclinicadocumento_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaclinicadocumento_N = value;
            SetDirty("Propostaclinicadocumento_N");
         }

      }

      public void gxTv_SdtProposta_Propostaclinicadocumento_N_SetNull( )
      {
         gxTv_SdtProposta_Propostaclinicadocumento_N = 0;
         SetDirty("Propostaclinicadocumento_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaclinicadocumento_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaClinicaEmail_N" )]
      [  XmlElement( ElementName = "PropostaClinicaEmail_N"   )]
      public short gxTpr_Propostaclinicaemail_N
      {
         get {
            return gxTv_SdtProposta_Propostaclinicaemail_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaclinicaemail_N = value;
            SetDirty("Propostaclinicaemail_N");
         }

      }

      public void gxTv_SdtProposta_Propostaclinicaemail_N_SetNull( )
      {
         gxTv_SdtProposta_Propostaclinicaemail_N = 0;
         SetDirty("Propostaclinicaemail_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaclinicaemail_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaSecUserName_N" )]
      [  XmlElement( ElementName = "PropostaSecUserName_N"   )]
      public short gxTpr_Propostasecusername_N
      {
         get {
            return gxTv_SdtProposta_Propostasecusername_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostasecusername_N = value;
            SetDirty("Propostasecusername_N");
         }

      }

      public void gxTv_SdtProposta_Propostasecusername_N_SetNull( )
      {
         gxTv_SdtProposta_Propostasecusername_N = 0;
         SetDirty("Propostasecusername_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostasecusername_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaStatus_N" )]
      [  XmlElement( ElementName = "PropostaStatus_N"   )]
      public short gxTpr_Propostastatus_N
      {
         get {
            return gxTv_SdtProposta_Propostastatus_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostastatus_N = value;
            SetDirty("Propostastatus_N");
         }

      }

      public void gxTv_SdtProposta_Propostastatus_N_SetNull( )
      {
         gxTv_SdtProposta_Propostastatus_N = 0;
         SetDirty("Propostastatus_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostastatus_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaComentarioAnalise_N" )]
      [  XmlElement( ElementName = "PropostaComentarioAnalise_N"   )]
      public short gxTpr_Propostacomentarioanalise_N
      {
         get {
            return gxTv_SdtProposta_Propostacomentarioanalise_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostacomentarioanalise_N = value;
            SetDirty("Propostacomentarioanalise_N");
         }

      }

      public void gxTv_SdtProposta_Propostacomentarioanalise_N_SetNull( )
      {
         gxTv_SdtProposta_Propostacomentarioanalise_N = 0;
         SetDirty("Propostacomentarioanalise_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostacomentarioanalise_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaQuantidadeAprovadores_N" )]
      [  XmlElement( ElementName = "PropostaQuantidadeAprovadores_N"   )]
      public short gxTpr_Propostaquantidadeaprovadores_N
      {
         get {
            return gxTv_SdtProposta_Propostaquantidadeaprovadores_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaquantidadeaprovadores_N = value;
            SetDirty("Propostaquantidadeaprovadores_N");
         }

      }

      public void gxTv_SdtProposta_Propostaquantidadeaprovadores_N_SetNull( )
      {
         gxTv_SdtProposta_Propostaquantidadeaprovadores_N = 0;
         SetDirty("Propostaquantidadeaprovadores_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaquantidadeaprovadores_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaReprovacoesPermitidas_N" )]
      [  XmlElement( ElementName = "PropostaReprovacoesPermitidas_N"   )]
      public short gxTpr_Propostareprovacoespermitidas_N
      {
         get {
            return gxTv_SdtProposta_Propostareprovacoespermitidas_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostareprovacoespermitidas_N = value;
            SetDirty("Propostareprovacoespermitidas_N");
         }

      }

      public void gxTv_SdtProposta_Propostareprovacoespermitidas_N_SetNull( )
      {
         gxTv_SdtProposta_Propostareprovacoespermitidas_N = 0;
         SetDirty("Propostareprovacoespermitidas_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostareprovacoespermitidas_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoId_N" )]
      [  XmlElement( ElementName = "ContratoId_N"   )]
      public short gxTpr_Contratoid_N
      {
         get {
            return gxTv_SdtProposta_Contratoid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Contratoid_N = value;
            SetDirty("Contratoid_N");
         }

      }

      public void gxTv_SdtProposta_Contratoid_N_SetNull( )
      {
         gxTv_SdtProposta_Contratoid_N = 0;
         SetDirty("Contratoid_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Contratoid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoNome_N" )]
      [  XmlElement( ElementName = "ContratoNome_N"   )]
      public short gxTpr_Contratonome_N
      {
         get {
            return gxTv_SdtProposta_Contratonome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Contratonome_N = value;
            SetDirty("Contratonome_N");
         }

      }

      public void gxTv_SdtProposta_Contratonome_N_SetNull( )
      {
         gxTv_SdtProposta_Contratonome_N = 0;
         SetDirty("Contratonome_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Contratonome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConvenioId_N" )]
      [  XmlElement( ElementName = "ConvenioId_N"   )]
      public short gxTpr_Convenioid_N
      {
         get {
            return gxTv_SdtProposta_Convenioid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Convenioid_N = value;
            SetDirty("Convenioid_N");
         }

      }

      public void gxTv_SdtProposta_Convenioid_N_SetNull( )
      {
         gxTv_SdtProposta_Convenioid_N = 0;
         SetDirty("Convenioid_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Convenioid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConvenioVencimentoAno_N" )]
      [  XmlElement( ElementName = "ConvenioVencimentoAno_N"   )]
      public short gxTpr_Conveniovencimentoano_N
      {
         get {
            return gxTv_SdtProposta_Conveniovencimentoano_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Conveniovencimentoano_N = value;
            SetDirty("Conveniovencimentoano_N");
         }

      }

      public void gxTv_SdtProposta_Conveniovencimentoano_N_SetNull( )
      {
         gxTv_SdtProposta_Conveniovencimentoano_N = 0;
         SetDirty("Conveniovencimentoano_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Conveniovencimentoano_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConvenioVencimentoMes_N" )]
      [  XmlElement( ElementName = "ConvenioVencimentoMes_N"   )]
      public short gxTpr_Conveniovencimentomes_N
      {
         get {
            return gxTv_SdtProposta_Conveniovencimentomes_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Conveniovencimentomes_N = value;
            SetDirty("Conveniovencimentomes_N");
         }

      }

      public void gxTv_SdtProposta_Conveniovencimentomes_N_SetNull( )
      {
         gxTv_SdtProposta_Conveniovencimentomes_N = 0;
         SetDirty("Conveniovencimentomes_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Conveniovencimentomes_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConvenioCategoriaId_N" )]
      [  XmlElement( ElementName = "ConvenioCategoriaId_N"   )]
      public short gxTpr_Conveniocategoriaid_N
      {
         get {
            return gxTv_SdtProposta_Conveniocategoriaid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Conveniocategoriaid_N = value;
            SetDirty("Conveniocategoriaid_N");
         }

      }

      public void gxTv_SdtProposta_Conveniocategoriaid_N_SetNull( )
      {
         gxTv_SdtProposta_Conveniocategoriaid_N = 0;
         SetDirty("Conveniocategoriaid_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Conveniocategoriaid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConvenioCategoriaDescricao_N" )]
      [  XmlElement( ElementName = "ConvenioCategoriaDescricao_N"   )]
      public short gxTpr_Conveniocategoriadescricao_N
      {
         get {
            return gxTv_SdtProposta_Conveniocategoriadescricao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Conveniocategoriadescricao_N = value;
            SetDirty("Conveniocategoriadescricao_N");
         }

      }

      public void gxTv_SdtProposta_Conveniocategoriadescricao_N_SetNull( )
      {
         gxTv_SdtProposta_Conveniocategoriadescricao_N = 0;
         SetDirty("Conveniocategoriadescricao_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Conveniocategoriadescricao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaDataCreditoCliente_F_N" )]
      [  XmlElement( ElementName = "PropostaDataCreditoCliente_F_N"   )]
      public short gxTpr_Propostadatacreditocliente_f_N
      {
         get {
            return gxTv_SdtProposta_Propostadatacreditocliente_f_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostadatacreditocliente_f_N = value;
            SetDirty("Propostadatacreditocliente_f_N");
         }

      }

      public void gxTv_SdtProposta_Propostadatacreditocliente_f_N_SetNull( )
      {
         gxTv_SdtProposta_Propostadatacreditocliente_f_N = 0;
         SetDirty("Propostadatacreditocliente_f_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostadatacreditocliente_f_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaValorReembolsado_F_N" )]
      [  XmlElement( ElementName = "PropostaValorReembolsado_F_N"   )]
      public short gxTpr_Propostavalorreembolsado_f_N
      {
         get {
            return gxTv_SdtProposta_Propostavalorreembolsado_f_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostavalorreembolsado_f_N = value;
            SetDirty("Propostavalorreembolsado_f_N");
         }

      }

      public void gxTv_SdtProposta_Propostavalorreembolsado_f_N_SetNull( )
      {
         gxTv_SdtProposta_Propostavalorreembolsado_f_N = 0;
         SetDirty("Propostavalorreembolsado_f_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostavalorreembolsado_f_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaValorReembolsadoJuros_F_N" )]
      [  XmlElement( ElementName = "PropostaValorReembolsadoJuros_F_N"   )]
      public short gxTpr_Propostavalorreembolsadojuros_f_N
      {
         get {
            return gxTv_SdtProposta_Propostavalorreembolsadojuros_f_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostavalorreembolsadojuros_f_N = value;
            SetDirty("Propostavalorreembolsadojuros_f_N");
         }

      }

      public void gxTv_SdtProposta_Propostavalorreembolsadojuros_f_N_SetNull( )
      {
         gxTv_SdtProposta_Propostavalorreembolsadojuros_f_N = 0;
         SetDirty("Propostavalorreembolsadojuros_f_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostavalorreembolsadojuros_f_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaValorTaxaRecebida_F_N" )]
      [  XmlElement( ElementName = "PropostaValorTaxaRecebida_F_N"   )]
      public short gxTpr_Propostavalortaxarecebida_f_N
      {
         get {
            return gxTv_SdtProposta_Propostavalortaxarecebida_f_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostavalortaxarecebida_f_N = value;
            SetDirty("Propostavalortaxarecebida_f_N");
         }

      }

      public void gxTv_SdtProposta_Propostavalortaxarecebida_f_N_SetNull( )
      {
         gxTv_SdtProposta_Propostavalortaxarecebida_f_N = 0;
         SetDirty("Propostavalortaxarecebida_f_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostavalortaxarecebida_f_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaAprovacoes_F_N" )]
      [  XmlElement( ElementName = "PropostaAprovacoes_F_N"   )]
      public short gxTpr_Propostaaprovacoes_f_N
      {
         get {
            return gxTv_SdtProposta_Propostaaprovacoes_f_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostaaprovacoes_f_N = value;
            SetDirty("Propostaaprovacoes_f_N");
         }

      }

      public void gxTv_SdtProposta_Propostaaprovacoes_f_N_SetNull( )
      {
         gxTv_SdtProposta_Propostaaprovacoes_f_N = 0;
         SetDirty("Propostaaprovacoes_f_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostaaprovacoes_f_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaReprovacoes_F_N" )]
      [  XmlElement( ElementName = "PropostaReprovacoes_F_N"   )]
      public short gxTpr_Propostareprovacoes_f_N
      {
         get {
            return gxTv_SdtProposta_Propostareprovacoes_f_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProposta_Propostareprovacoes_f_N = value;
            SetDirty("Propostareprovacoes_f_N");
         }

      }

      public void gxTv_SdtProposta_Propostareprovacoes_f_N_SetNull( )
      {
         gxTv_SdtProposta_Propostareprovacoes_f_N = 0;
         SetDirty("Propostareprovacoes_f_N");
         return  ;
      }

      public bool gxTv_SdtProposta_Propostareprovacoes_f_N_IsNull( )
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
         gxTv_SdtProposta_Propostaprotocolo = "";
         gxTv_SdtProposta_Propostatipoproposta = "";
         gxTv_SdtProposta_Propostaresponsaveldocumento = "";
         gxTv_SdtProposta_Propostaresponsavelrazaosocial = "";
         gxTv_SdtProposta_Propostaresponsavelemail = "";
         gxTv_SdtProposta_Propostaresponsavelbanco = "";
         gxTv_SdtProposta_Propostaresponsavelconta = "";
         gxTv_SdtProposta_Propostaresponsavelagencia = "";
         gxTv_SdtProposta_Propostaresponsaveltipopix = "";
         gxTv_SdtProposta_Propostaresponsavelpix = "";
         gxTv_SdtProposta_Propostaresponsaveldepositotipo = "";
         gxTv_SdtProposta_Propostapacienteclienterazaosocial = "";
         gxTv_SdtProposta_Propostapacienteclientedocumento = "";
         gxTv_SdtProposta_Propostapacientecontatoemail = "";
         gxTv_SdtProposta_Propostapacientebanco = "";
         gxTv_SdtProposta_Propostapacienteconta = "";
         gxTv_SdtProposta_Propostapacienteagencia = "";
         gxTv_SdtProposta_Propostapacientetipopix = "";
         gxTv_SdtProposta_Propostapacientepix = "";
         gxTv_SdtProposta_Propostapacientedepositotipo = "";
         gxTv_SdtProposta_Propostapacienteenderecocep = "";
         gxTv_SdtProposta_Propostapacienteenderecologradouro = "";
         gxTv_SdtProposta_Propostapacienteendereconumero = "";
         gxTv_SdtProposta_Propostapacienteenderecocomplemento = "";
         gxTv_SdtProposta_Propostapacienteenderecobairro = "";
         gxTv_SdtProposta_Propostapacientemunicipiocodigo = "";
         gxTv_SdtProposta_Propostatitulo = "";
         gxTv_SdtProposta_Propostadescricao = "";
         gxTv_SdtProposta_Propostadatacirurgia = DateTime.MinValue;
         gxTv_SdtProposta_Propostacreatedat = (DateTime)(DateTime.MinValue);
         gxTv_SdtProposta_Propostaclinicanome = "";
         gxTv_SdtProposta_Propostaclinicanomefantasia = "";
         gxTv_SdtProposta_Propostaclinicadocumento = "";
         gxTv_SdtProposta_Propostaclinicaemail = "";
         gxTv_SdtProposta_Propostasecusername = "";
         gxTv_SdtProposta_Propostastatus = "";
         gxTv_SdtProposta_Propostacomentarioanalise = "";
         gxTv_SdtProposta_Contratonome = "";
         gxTv_SdtProposta_Conveniocategoriadescricao = "";
         gxTv_SdtProposta_Propostadatacreditocliente_f = DateTime.MinValue;
         gxTv_SdtProposta_Mode = "";
         gxTv_SdtProposta_Propostaprotocolo_Z = "";
         gxTv_SdtProposta_Propostatipoproposta_Z = "";
         gxTv_SdtProposta_Propostaresponsaveldocumento_Z = "";
         gxTv_SdtProposta_Propostaresponsavelrazaosocial_Z = "";
         gxTv_SdtProposta_Propostaresponsavelemail_Z = "";
         gxTv_SdtProposta_Propostaresponsavelbanco_Z = "";
         gxTv_SdtProposta_Propostaresponsavelconta_Z = "";
         gxTv_SdtProposta_Propostaresponsavelagencia_Z = "";
         gxTv_SdtProposta_Propostaresponsaveltipopix_Z = "";
         gxTv_SdtProposta_Propostaresponsavelpix_Z = "";
         gxTv_SdtProposta_Propostaresponsaveldepositotipo_Z = "";
         gxTv_SdtProposta_Propostapacienteclienterazaosocial_Z = "";
         gxTv_SdtProposta_Propostapacienteclientedocumento_Z = "";
         gxTv_SdtProposta_Propostapacientecontatoemail_Z = "";
         gxTv_SdtProposta_Propostapacientebanco_Z = "";
         gxTv_SdtProposta_Propostapacienteconta_Z = "";
         gxTv_SdtProposta_Propostapacienteagencia_Z = "";
         gxTv_SdtProposta_Propostapacientetipopix_Z = "";
         gxTv_SdtProposta_Propostapacientepix_Z = "";
         gxTv_SdtProposta_Propostapacientedepositotipo_Z = "";
         gxTv_SdtProposta_Propostapacienteenderecocep_Z = "";
         gxTv_SdtProposta_Propostapacienteenderecologradouro_Z = "";
         gxTv_SdtProposta_Propostapacienteendereconumero_Z = "";
         gxTv_SdtProposta_Propostapacienteenderecocomplemento_Z = "";
         gxTv_SdtProposta_Propostapacienteenderecobairro_Z = "";
         gxTv_SdtProposta_Propostapacientemunicipiocodigo_Z = "";
         gxTv_SdtProposta_Propostatitulo_Z = "";
         gxTv_SdtProposta_Propostadescricao_Z = "";
         gxTv_SdtProposta_Propostadatacirurgia_Z = DateTime.MinValue;
         gxTv_SdtProposta_Propostacreatedat_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtProposta_Propostaclinicanome_Z = "";
         gxTv_SdtProposta_Propostaclinicanomefantasia_Z = "";
         gxTv_SdtProposta_Propostaclinicadocumento_Z = "";
         gxTv_SdtProposta_Propostaclinicaemail_Z = "";
         gxTv_SdtProposta_Propostasecusername_Z = "";
         gxTv_SdtProposta_Propostastatus_Z = "";
         gxTv_SdtProposta_Propostacomentarioanalise_Z = "";
         gxTv_SdtProposta_Contratonome_Z = "";
         gxTv_SdtProposta_Conveniocategoriadescricao_Z = "";
         gxTv_SdtProposta_Propostadatacreditocliente_f_Z = DateTime.MinValue;
         sDateCnv = "";
         sNumToPad = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "proposta", "GeneXus.Programs.proposta_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtProposta_Propostaqtditensnota_f ;
      private short gxTv_SdtProposta_Propostaresponsavelserasaconsultas_f ;
      private short gxTv_SdtProposta_Propostaresponsavelserasascoreultimadata_f ;
      private short gxTv_SdtProposta_Propostapacienteserasaconsultas_f ;
      private short gxTv_SdtProposta_Propostaserasascoreultimadata_f ;
      private short gxTv_SdtProposta_Propostaqtddocumentopendente_f ;
      private short gxTv_SdtProposta_Propostamaiorscore_f ;
      private short gxTv_SdtProposta_Propostasla ;
      private short gxTv_SdtProposta_Propostacratedby ;
      private short gxTv_SdtProposta_Propostaquantidadeaprovadores ;
      private short gxTv_SdtProposta_Propostareprovacoespermitidas ;
      private short gxTv_SdtProposta_Conveniovencimentoano ;
      private short gxTv_SdtProposta_Conveniovencimentomes ;
      private short gxTv_SdtProposta_Propostaaprovacoes_f ;
      private short gxTv_SdtProposta_Propostareprovacoes_f ;
      private short gxTv_SdtProposta_Propostaaprovacoesrestantes_f ;
      private short gxTv_SdtProposta_Initialized ;
      private short gxTv_SdtProposta_Propostaqtditensnota_f_Z ;
      private short gxTv_SdtProposta_Propostaresponsavelserasaconsultas_f_Z ;
      private short gxTv_SdtProposta_Propostaresponsavelserasascoreultimadata_f_Z ;
      private short gxTv_SdtProposta_Propostapacienteserasaconsultas_f_Z ;
      private short gxTv_SdtProposta_Propostaserasascoreultimadata_f_Z ;
      private short gxTv_SdtProposta_Propostaqtddocumentopendente_f_Z ;
      private short gxTv_SdtProposta_Propostamaiorscore_f_Z ;
      private short gxTv_SdtProposta_Propostasla_Z ;
      private short gxTv_SdtProposta_Propostacratedby_Z ;
      private short gxTv_SdtProposta_Propostaquantidadeaprovadores_Z ;
      private short gxTv_SdtProposta_Propostareprovacoespermitidas_Z ;
      private short gxTv_SdtProposta_Conveniovencimentoano_Z ;
      private short gxTv_SdtProposta_Conveniovencimentomes_Z ;
      private short gxTv_SdtProposta_Propostaaprovacoes_f_Z ;
      private short gxTv_SdtProposta_Propostareprovacoes_f_Z ;
      private short gxTv_SdtProposta_Propostaaprovacoesrestantes_f_Z ;
      private short gxTv_SdtProposta_Propostaid_N ;
      private short gxTv_SdtProposta_Propostamaxreembolsoid_f_N ;
      private short gxTv_SdtProposta_Propostaprotocolo_N ;
      private short gxTv_SdtProposta_Propostaempresaclienteid_N ;
      private short gxTv_SdtProposta_Propostatipoproposta_N ;
      private short gxTv_SdtProposta_Propostapacienteclienteid_N ;
      private short gxTv_SdtProposta_Propostaqtditensnota_f_N ;
      private short gxTv_SdtProposta_Propostaresponsavelid_N ;
      private short gxTv_SdtProposta_Propostaresponsaveldocumento_N ;
      private short gxTv_SdtProposta_Propostaresponsavelrazaosocial_N ;
      private short gxTv_SdtProposta_Propostaresponsavelemail_N ;
      private short gxTv_SdtProposta_Propostaresponsavelconta_N ;
      private short gxTv_SdtProposta_Propostaresponsavelagencia_N ;
      private short gxTv_SdtProposta_Propostaresponsaveltipopix_N ;
      private short gxTv_SdtProposta_Propostaresponsavelpix_N ;
      private short gxTv_SdtProposta_Propostaresponsaveldepositotipo_N ;
      private short gxTv_SdtProposta_Propostaresponsavelserasaconsultas_f_N ;
      private short gxTv_SdtProposta_Propostaresponsavelserasascoreultimadata_f_N ;
      private short gxTv_SdtProposta_Propostaresponsavelserasaultimovalorrecomendado_f_N ;
      private short gxTv_SdtProposta_Propostapacienteclienterazaosocial_N ;
      private short gxTv_SdtProposta_Propostapacienteclientedocumento_N ;
      private short gxTv_SdtProposta_Propostapacientecontatoemail_N ;
      private short gxTv_SdtProposta_Propostapacienteconta_N ;
      private short gxTv_SdtProposta_Propostapacienteagencia_N ;
      private short gxTv_SdtProposta_Propostapacientetipopix_N ;
      private short gxTv_SdtProposta_Propostapacientepix_N ;
      private short gxTv_SdtProposta_Propostapacientedepositotipo_N ;
      private short gxTv_SdtProposta_Propostapacienteenderecocep_N ;
      private short gxTv_SdtProposta_Propostapacienteenderecologradouro_N ;
      private short gxTv_SdtProposta_Propostapacienteendereconumero_N ;
      private short gxTv_SdtProposta_Propostapacienteenderecocomplemento_N ;
      private short gxTv_SdtProposta_Propostapacienteenderecobairro_N ;
      private short gxTv_SdtProposta_Propostapacientemunicipiocodigo_N ;
      private short gxTv_SdtProposta_Propostapacienteserasaconsultas_f_N ;
      private short gxTv_SdtProposta_Propostaserasascoreultimadata_f_N ;
      private short gxTv_SdtProposta_Propostapacienteserasaultimovalorrecomendado_f_N ;
      private short gxTv_SdtProposta_Propostavalortaxaclinica_f_N ;
      private short gxTv_SdtProposta_Propostaqtddocumentopendente_f_N ;
      private short gxTv_SdtProposta_Propostatitulo_N ;
      private short gxTv_SdtProposta_Procedimentosmedicosid_N ;
      private short gxTv_SdtProposta_Propostadescricao_N ;
      private short gxTv_SdtProposta_Propostadatacirurgia_N ;
      private short gxTv_SdtProposta_Propostavalor_N ;
      private short gxTv_SdtProposta_Propostavalorliquido_N ;
      private short gxTv_SdtProposta_Propostataxaadministrativa_N ;
      private short gxTv_SdtProposta_Propostasla_N ;
      private short gxTv_SdtProposta_Propostajurosmora_N ;
      private short gxTv_SdtProposta_Propostacreatedat_N ;
      private short gxTv_SdtProposta_Propostacratedby_N ;
      private short gxTv_SdtProposta_Propostaclinicaid_N ;
      private short gxTv_SdtProposta_Propostaclinicanome_N ;
      private short gxTv_SdtProposta_Propostaclinicanomefantasia_N ;
      private short gxTv_SdtProposta_Propostaclinicadocumento_N ;
      private short gxTv_SdtProposta_Propostaclinicaemail_N ;
      private short gxTv_SdtProposta_Propostasecusername_N ;
      private short gxTv_SdtProposta_Propostastatus_N ;
      private short gxTv_SdtProposta_Propostacomentarioanalise_N ;
      private short gxTv_SdtProposta_Propostaquantidadeaprovadores_N ;
      private short gxTv_SdtProposta_Propostareprovacoespermitidas_N ;
      private short gxTv_SdtProposta_Contratoid_N ;
      private short gxTv_SdtProposta_Contratonome_N ;
      private short gxTv_SdtProposta_Convenioid_N ;
      private short gxTv_SdtProposta_Conveniovencimentoano_N ;
      private short gxTv_SdtProposta_Conveniovencimentomes_N ;
      private short gxTv_SdtProposta_Conveniocategoriaid_N ;
      private short gxTv_SdtProposta_Conveniocategoriadescricao_N ;
      private short gxTv_SdtProposta_Propostadatacreditocliente_f_N ;
      private short gxTv_SdtProposta_Propostavalorreembolsado_f_N ;
      private short gxTv_SdtProposta_Propostavalorreembolsadojuros_f_N ;
      private short gxTv_SdtProposta_Propostavalortaxarecebida_f_N ;
      private short gxTv_SdtProposta_Propostaaprovacoes_f_N ;
      private short gxTv_SdtProposta_Propostareprovacoes_f_N ;
      private int gxTv_SdtProposta_Propostaid ;
      private int gxTv_SdtProposta_Propostamaxreembolsoid_f ;
      private int gxTv_SdtProposta_Propostaempresaclienteid ;
      private int gxTv_SdtProposta_Propostapacienteclienteid ;
      private int gxTv_SdtProposta_Propostaresponsavelid ;
      private int gxTv_SdtProposta_Procedimentosmedicosid ;
      private int gxTv_SdtProposta_Propostaclinicaid ;
      private int gxTv_SdtProposta_Contratoid ;
      private int gxTv_SdtProposta_Convenioid ;
      private int gxTv_SdtProposta_Conveniocategoriaid ;
      private int gxTv_SdtProposta_Propostaid_Z ;
      private int gxTv_SdtProposta_Propostamaxreembolsoid_f_Z ;
      private int gxTv_SdtProposta_Propostaempresaclienteid_Z ;
      private int gxTv_SdtProposta_Propostapacienteclienteid_Z ;
      private int gxTv_SdtProposta_Propostaresponsavelid_Z ;
      private int gxTv_SdtProposta_Procedimentosmedicosid_Z ;
      private int gxTv_SdtProposta_Propostaclinicaid_Z ;
      private int gxTv_SdtProposta_Contratoid_Z ;
      private int gxTv_SdtProposta_Convenioid_Z ;
      private int gxTv_SdtProposta_Conveniocategoriaid_Z ;
      private decimal gxTv_SdtProposta_Propostaresponsavelserasaultimovalorrecomendado_f ;
      private decimal gxTv_SdtProposta_Propostapacienteserasaultimovalorrecomendado_f ;
      private decimal gxTv_SdtProposta_Propostavalortaxaclinica_f ;
      private decimal gxTv_SdtProposta_Propostamaiorvalorrecomendado ;
      private decimal gxTv_SdtProposta_Propostavalor ;
      private decimal gxTv_SdtProposta_Propostavalorliquido ;
      private decimal gxTv_SdtProposta_Propostataxaadministrativa ;
      private decimal gxTv_SdtProposta_Propostataxa_f ;
      private decimal gxTv_SdtProposta_Propostajurosmora ;
      private decimal gxTv_SdtProposta_Propostavalortaxa_f ;
      private decimal gxTv_SdtProposta_Propostavalorjurosmora_f ;
      private decimal gxTv_SdtProposta_Propostavalorreembolsado_f ;
      private decimal gxTv_SdtProposta_Propostavalorreembolsadojuros_f ;
      private decimal gxTv_SdtProposta_Propostavalortaxarecebida_f ;
      private decimal gxTv_SdtProposta_Propostaresponsavelserasaultimovalorrecomendado_f_Z ;
      private decimal gxTv_SdtProposta_Propostapacienteserasaultimovalorrecomendado_f_Z ;
      private decimal gxTv_SdtProposta_Propostavalortaxaclinica_f_Z ;
      private decimal gxTv_SdtProposta_Propostamaiorvalorrecomendado_Z ;
      private decimal gxTv_SdtProposta_Propostavalor_Z ;
      private decimal gxTv_SdtProposta_Propostavalorliquido_Z ;
      private decimal gxTv_SdtProposta_Propostataxaadministrativa_Z ;
      private decimal gxTv_SdtProposta_Propostataxa_f_Z ;
      private decimal gxTv_SdtProposta_Propostajurosmora_Z ;
      private decimal gxTv_SdtProposta_Propostavalortaxa_f_Z ;
      private decimal gxTv_SdtProposta_Propostavalorjurosmora_f_Z ;
      private decimal gxTv_SdtProposta_Propostavalorreembolsado_f_Z ;
      private decimal gxTv_SdtProposta_Propostavalorreembolsadojuros_f_Z ;
      private decimal gxTv_SdtProposta_Propostavalortaxarecebida_f_Z ;
      private string gxTv_SdtProposta_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtProposta_Propostacreatedat ;
      private DateTime gxTv_SdtProposta_Propostacreatedat_Z ;
      private DateTime datetime_STZ ;
      private DateTime gxTv_SdtProposta_Propostadatacirurgia ;
      private DateTime gxTv_SdtProposta_Propostadatacreditocliente_f ;
      private DateTime gxTv_SdtProposta_Propostadatacirurgia_Z ;
      private DateTime gxTv_SdtProposta_Propostadatacreditocliente_f_Z ;
      private string gxTv_SdtProposta_Propostaprotocolo ;
      private string gxTv_SdtProposta_Propostatipoproposta ;
      private string gxTv_SdtProposta_Propostaresponsaveldocumento ;
      private string gxTv_SdtProposta_Propostaresponsavelrazaosocial ;
      private string gxTv_SdtProposta_Propostaresponsavelemail ;
      private string gxTv_SdtProposta_Propostaresponsavelbanco ;
      private string gxTv_SdtProposta_Propostaresponsavelconta ;
      private string gxTv_SdtProposta_Propostaresponsavelagencia ;
      private string gxTv_SdtProposta_Propostaresponsaveltipopix ;
      private string gxTv_SdtProposta_Propostaresponsavelpix ;
      private string gxTv_SdtProposta_Propostaresponsaveldepositotipo ;
      private string gxTv_SdtProposta_Propostapacienteclienterazaosocial ;
      private string gxTv_SdtProposta_Propostapacienteclientedocumento ;
      private string gxTv_SdtProposta_Propostapacientecontatoemail ;
      private string gxTv_SdtProposta_Propostapacientebanco ;
      private string gxTv_SdtProposta_Propostapacienteconta ;
      private string gxTv_SdtProposta_Propostapacienteagencia ;
      private string gxTv_SdtProposta_Propostapacientetipopix ;
      private string gxTv_SdtProposta_Propostapacientepix ;
      private string gxTv_SdtProposta_Propostapacientedepositotipo ;
      private string gxTv_SdtProposta_Propostapacienteenderecocep ;
      private string gxTv_SdtProposta_Propostapacienteenderecologradouro ;
      private string gxTv_SdtProposta_Propostapacienteendereconumero ;
      private string gxTv_SdtProposta_Propostapacienteenderecocomplemento ;
      private string gxTv_SdtProposta_Propostapacienteenderecobairro ;
      private string gxTv_SdtProposta_Propostapacientemunicipiocodigo ;
      private string gxTv_SdtProposta_Propostatitulo ;
      private string gxTv_SdtProposta_Propostadescricao ;
      private string gxTv_SdtProposta_Propostaclinicanome ;
      private string gxTv_SdtProposta_Propostaclinicanomefantasia ;
      private string gxTv_SdtProposta_Propostaclinicadocumento ;
      private string gxTv_SdtProposta_Propostaclinicaemail ;
      private string gxTv_SdtProposta_Propostasecusername ;
      private string gxTv_SdtProposta_Propostastatus ;
      private string gxTv_SdtProposta_Propostacomentarioanalise ;
      private string gxTv_SdtProposta_Contratonome ;
      private string gxTv_SdtProposta_Conveniocategoriadescricao ;
      private string gxTv_SdtProposta_Propostaprotocolo_Z ;
      private string gxTv_SdtProposta_Propostatipoproposta_Z ;
      private string gxTv_SdtProposta_Propostaresponsaveldocumento_Z ;
      private string gxTv_SdtProposta_Propostaresponsavelrazaosocial_Z ;
      private string gxTv_SdtProposta_Propostaresponsavelemail_Z ;
      private string gxTv_SdtProposta_Propostaresponsavelbanco_Z ;
      private string gxTv_SdtProposta_Propostaresponsavelconta_Z ;
      private string gxTv_SdtProposta_Propostaresponsavelagencia_Z ;
      private string gxTv_SdtProposta_Propostaresponsaveltipopix_Z ;
      private string gxTv_SdtProposta_Propostaresponsavelpix_Z ;
      private string gxTv_SdtProposta_Propostaresponsaveldepositotipo_Z ;
      private string gxTv_SdtProposta_Propostapacienteclienterazaosocial_Z ;
      private string gxTv_SdtProposta_Propostapacienteclientedocumento_Z ;
      private string gxTv_SdtProposta_Propostapacientecontatoemail_Z ;
      private string gxTv_SdtProposta_Propostapacientebanco_Z ;
      private string gxTv_SdtProposta_Propostapacienteconta_Z ;
      private string gxTv_SdtProposta_Propostapacienteagencia_Z ;
      private string gxTv_SdtProposta_Propostapacientetipopix_Z ;
      private string gxTv_SdtProposta_Propostapacientepix_Z ;
      private string gxTv_SdtProposta_Propostapacientedepositotipo_Z ;
      private string gxTv_SdtProposta_Propostapacienteenderecocep_Z ;
      private string gxTv_SdtProposta_Propostapacienteenderecologradouro_Z ;
      private string gxTv_SdtProposta_Propostapacienteendereconumero_Z ;
      private string gxTv_SdtProposta_Propostapacienteenderecocomplemento_Z ;
      private string gxTv_SdtProposta_Propostapacienteenderecobairro_Z ;
      private string gxTv_SdtProposta_Propostapacientemunicipiocodigo_Z ;
      private string gxTv_SdtProposta_Propostatitulo_Z ;
      private string gxTv_SdtProposta_Propostadescricao_Z ;
      private string gxTv_SdtProposta_Propostaclinicanome_Z ;
      private string gxTv_SdtProposta_Propostaclinicanomefantasia_Z ;
      private string gxTv_SdtProposta_Propostaclinicadocumento_Z ;
      private string gxTv_SdtProposta_Propostaclinicaemail_Z ;
      private string gxTv_SdtProposta_Propostasecusername_Z ;
      private string gxTv_SdtProposta_Propostastatus_Z ;
      private string gxTv_SdtProposta_Propostacomentarioanalise_Z ;
      private string gxTv_SdtProposta_Contratonome_Z ;
      private string gxTv_SdtProposta_Conveniocategoriadescricao_Z ;
   }

   [DataContract(Name = @"Proposta", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtProposta_RESTInterface : GxGenericCollectionItem<SdtProposta>
   {
      public SdtProposta_RESTInterface( ) : base()
      {
      }

      public SdtProposta_RESTInterface( SdtProposta psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PropostaId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Propostaid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Propostaid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Propostaid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "PropostaMaxReembolsoId_F" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Propostamaxreembolsoid_f
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Propostamaxreembolsoid_f), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Propostamaxreembolsoid_f = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "PropostaProtocolo" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Propostaprotocolo
      {
         get {
            return sdt.gxTpr_Propostaprotocolo ;
         }

         set {
            sdt.gxTpr_Propostaprotocolo = value;
         }

      }

      [DataMember( Name = "PropostaEmpresaClienteId" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Propostaempresaclienteid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Propostaempresaclienteid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Propostaempresaclienteid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "PropostaTipoProposta" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Propostatipoproposta
      {
         get {
            return sdt.gxTpr_Propostatipoproposta ;
         }

         set {
            sdt.gxTpr_Propostatipoproposta = value;
         }

      }

      [DataMember( Name = "PropostaPacienteClienteId" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Propostapacienteclienteid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Propostapacienteclienteid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Propostapacienteclienteid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "PropostaQtdItensNota_F" , Order = 6 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Propostaqtditensnota_f
      {
         get {
            return sdt.gxTpr_Propostaqtditensnota_f ;
         }

         set {
            sdt.gxTpr_Propostaqtditensnota_f = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "PropostaResponsavelId" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Propostaresponsavelid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Propostaresponsavelid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Propostaresponsavelid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "PropostaResponsavelDocumento" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Propostaresponsaveldocumento
      {
         get {
            return sdt.gxTpr_Propostaresponsaveldocumento ;
         }

         set {
            sdt.gxTpr_Propostaresponsaveldocumento = value;
         }

      }

      [DataMember( Name = "PropostaResponsavelRazaoSocial" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Propostaresponsavelrazaosocial
      {
         get {
            return sdt.gxTpr_Propostaresponsavelrazaosocial ;
         }

         set {
            sdt.gxTpr_Propostaresponsavelrazaosocial = value;
         }

      }

      [DataMember( Name = "PropostaResponsavelEmail" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Propostaresponsavelemail
      {
         get {
            return sdt.gxTpr_Propostaresponsavelemail ;
         }

         set {
            sdt.gxTpr_Propostaresponsavelemail = value;
         }

      }

      [DataMember( Name = "PropostaResponsavelBanco" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Propostaresponsavelbanco
      {
         get {
            return sdt.gxTpr_Propostaresponsavelbanco ;
         }

         set {
            sdt.gxTpr_Propostaresponsavelbanco = value;
         }

      }

      [DataMember( Name = "PropostaResponsavelConta" , Order = 12 )]
      [GxSeudo()]
      public string gxTpr_Propostaresponsavelconta
      {
         get {
            return sdt.gxTpr_Propostaresponsavelconta ;
         }

         set {
            sdt.gxTpr_Propostaresponsavelconta = value;
         }

      }

      [DataMember( Name = "PropostaResponsavelAgencia" , Order = 13 )]
      [GxSeudo()]
      public string gxTpr_Propostaresponsavelagencia
      {
         get {
            return sdt.gxTpr_Propostaresponsavelagencia ;
         }

         set {
            sdt.gxTpr_Propostaresponsavelagencia = value;
         }

      }

      [DataMember( Name = "PropostaResponsavelTipoPix" , Order = 14 )]
      [GxSeudo()]
      public string gxTpr_Propostaresponsaveltipopix
      {
         get {
            return sdt.gxTpr_Propostaresponsaveltipopix ;
         }

         set {
            sdt.gxTpr_Propostaresponsaveltipopix = value;
         }

      }

      [DataMember( Name = "PropostaResponsavelPIX" , Order = 15 )]
      [GxSeudo()]
      public string gxTpr_Propostaresponsavelpix
      {
         get {
            return sdt.gxTpr_Propostaresponsavelpix ;
         }

         set {
            sdt.gxTpr_Propostaresponsavelpix = value;
         }

      }

      [DataMember( Name = "PropostaResponsavelDepositoTipo" , Order = 16 )]
      [GxSeudo()]
      public string gxTpr_Propostaresponsaveldepositotipo
      {
         get {
            return sdt.gxTpr_Propostaresponsaveldepositotipo ;
         }

         set {
            sdt.gxTpr_Propostaresponsaveldepositotipo = value;
         }

      }

      [DataMember( Name = "PropostaResponsavelSerasaConsultas_F" , Order = 17 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Propostaresponsavelserasaconsultas_f
      {
         get {
            return sdt.gxTpr_Propostaresponsavelserasaconsultas_f ;
         }

         set {
            sdt.gxTpr_Propostaresponsavelserasaconsultas_f = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "PropostaResponsavelSerasaScoreUltimaData_F" , Order = 18 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Propostaresponsavelserasascoreultimadata_f
      {
         get {
            return sdt.gxTpr_Propostaresponsavelserasascoreultimadata_f ;
         }

         set {
            sdt.gxTpr_Propostaresponsavelserasascoreultimadata_f = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "PropostaResponsavelSerasaUltimoValorRecomendado_F" , Order = 19 )]
      [GxSeudo()]
      public string gxTpr_Propostaresponsavelserasaultimovalorrecomendado_f
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Propostaresponsavelserasaultimovalorrecomendado_f, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Propostaresponsavelserasaultimovalorrecomendado_f = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "PropostaPacienteClienteRazaoSocial" , Order = 20 )]
      [GxSeudo()]
      public string gxTpr_Propostapacienteclienterazaosocial
      {
         get {
            return sdt.gxTpr_Propostapacienteclienterazaosocial ;
         }

         set {
            sdt.gxTpr_Propostapacienteclienterazaosocial = value;
         }

      }

      [DataMember( Name = "PropostaPacienteClienteDocumento" , Order = 21 )]
      [GxSeudo()]
      public string gxTpr_Propostapacienteclientedocumento
      {
         get {
            return sdt.gxTpr_Propostapacienteclientedocumento ;
         }

         set {
            sdt.gxTpr_Propostapacienteclientedocumento = value;
         }

      }

      [DataMember( Name = "PropostaPacienteContatoEmail" , Order = 22 )]
      [GxSeudo()]
      public string gxTpr_Propostapacientecontatoemail
      {
         get {
            return sdt.gxTpr_Propostapacientecontatoemail ;
         }

         set {
            sdt.gxTpr_Propostapacientecontatoemail = value;
         }

      }

      [DataMember( Name = "PropostaPacienteBanco" , Order = 23 )]
      [GxSeudo()]
      public string gxTpr_Propostapacientebanco
      {
         get {
            return sdt.gxTpr_Propostapacientebanco ;
         }

         set {
            sdt.gxTpr_Propostapacientebanco = value;
         }

      }

      [DataMember( Name = "PropostaPacienteConta" , Order = 24 )]
      [GxSeudo()]
      public string gxTpr_Propostapacienteconta
      {
         get {
            return sdt.gxTpr_Propostapacienteconta ;
         }

         set {
            sdt.gxTpr_Propostapacienteconta = value;
         }

      }

      [DataMember( Name = "PropostaPacienteAgencia" , Order = 25 )]
      [GxSeudo()]
      public string gxTpr_Propostapacienteagencia
      {
         get {
            return sdt.gxTpr_Propostapacienteagencia ;
         }

         set {
            sdt.gxTpr_Propostapacienteagencia = value;
         }

      }

      [DataMember( Name = "PropostaPacienteTipoPix" , Order = 26 )]
      [GxSeudo()]
      public string gxTpr_Propostapacientetipopix
      {
         get {
            return sdt.gxTpr_Propostapacientetipopix ;
         }

         set {
            sdt.gxTpr_Propostapacientetipopix = value;
         }

      }

      [DataMember( Name = "PropostaPacientePIX" , Order = 27 )]
      [GxSeudo()]
      public string gxTpr_Propostapacientepix
      {
         get {
            return sdt.gxTpr_Propostapacientepix ;
         }

         set {
            sdt.gxTpr_Propostapacientepix = value;
         }

      }

      [DataMember( Name = "PropostaPacienteDepositoTipo" , Order = 28 )]
      [GxSeudo()]
      public string gxTpr_Propostapacientedepositotipo
      {
         get {
            return sdt.gxTpr_Propostapacientedepositotipo ;
         }

         set {
            sdt.gxTpr_Propostapacientedepositotipo = value;
         }

      }

      [DataMember( Name = "PropostaPacienteEnderecoCEP" , Order = 29 )]
      [GxSeudo()]
      public string gxTpr_Propostapacienteenderecocep
      {
         get {
            return sdt.gxTpr_Propostapacienteenderecocep ;
         }

         set {
            sdt.gxTpr_Propostapacienteenderecocep = value;
         }

      }

      [DataMember( Name = "PropostaPacienteEnderecoLogradouro" , Order = 30 )]
      [GxSeudo()]
      public string gxTpr_Propostapacienteenderecologradouro
      {
         get {
            return sdt.gxTpr_Propostapacienteenderecologradouro ;
         }

         set {
            sdt.gxTpr_Propostapacienteenderecologradouro = value;
         }

      }

      [DataMember( Name = "PropostaPacienteEnderecoNumero" , Order = 31 )]
      [GxSeudo()]
      public string gxTpr_Propostapacienteendereconumero
      {
         get {
            return sdt.gxTpr_Propostapacienteendereconumero ;
         }

         set {
            sdt.gxTpr_Propostapacienteendereconumero = value;
         }

      }

      [DataMember( Name = "PropostaPacienteEnderecoComplemento" , Order = 32 )]
      [GxSeudo()]
      public string gxTpr_Propostapacienteenderecocomplemento
      {
         get {
            return sdt.gxTpr_Propostapacienteenderecocomplemento ;
         }

         set {
            sdt.gxTpr_Propostapacienteenderecocomplemento = value;
         }

      }

      [DataMember( Name = "PropostaPacienteEnderecoBairro" , Order = 33 )]
      [GxSeudo()]
      public string gxTpr_Propostapacienteenderecobairro
      {
         get {
            return sdt.gxTpr_Propostapacienteenderecobairro ;
         }

         set {
            sdt.gxTpr_Propostapacienteenderecobairro = value;
         }

      }

      [DataMember( Name = "PropostaPacienteMunicipioCodigo" , Order = 34 )]
      [GxSeudo()]
      public string gxTpr_Propostapacientemunicipiocodigo
      {
         get {
            return sdt.gxTpr_Propostapacientemunicipiocodigo ;
         }

         set {
            sdt.gxTpr_Propostapacientemunicipiocodigo = value;
         }

      }

      [DataMember( Name = "PropostaPacienteSerasaConsultas_F" , Order = 35 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Propostapacienteserasaconsultas_f
      {
         get {
            return sdt.gxTpr_Propostapacienteserasaconsultas_f ;
         }

         set {
            sdt.gxTpr_Propostapacienteserasaconsultas_f = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "PropostaSerasaScoreUltimaData_F" , Order = 36 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Propostaserasascoreultimadata_f
      {
         get {
            return sdt.gxTpr_Propostaserasascoreultimadata_f ;
         }

         set {
            sdt.gxTpr_Propostaserasascoreultimadata_f = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "PropostaPacienteSerasaUltimoValorRecomendado_F" , Order = 37 )]
      [GxSeudo()]
      public string gxTpr_Propostapacienteserasaultimovalorrecomendado_f
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Propostapacienteserasaultimovalorrecomendado_f, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Propostapacienteserasaultimovalorrecomendado_f = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "PropostaValorTaxaClinica_F" , Order = 38 )]
      [GxSeudo()]
      public string gxTpr_Propostavalortaxaclinica_f
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Propostavalortaxaclinica_f, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Propostavalortaxaclinica_f = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "PropostaQtdDocumentoPendente_F" , Order = 39 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Propostaqtddocumentopendente_f
      {
         get {
            return sdt.gxTpr_Propostaqtddocumentopendente_f ;
         }

         set {
            sdt.gxTpr_Propostaqtddocumentopendente_f = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "PropostaMaiorScore_F" , Order = 40 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Propostamaiorscore_f
      {
         get {
            return sdt.gxTpr_Propostamaiorscore_f ;
         }

         set {
            sdt.gxTpr_Propostamaiorscore_f = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "PropostaMaiorValorRecomendado" , Order = 41 )]
      [GxSeudo()]
      public string gxTpr_Propostamaiorvalorrecomendado
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Propostamaiorvalorrecomendado, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Propostamaiorvalorrecomendado = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "PropostaTitulo" , Order = 42 )]
      [GxSeudo()]
      public string gxTpr_Propostatitulo
      {
         get {
            return sdt.gxTpr_Propostatitulo ;
         }

         set {
            sdt.gxTpr_Propostatitulo = value;
         }

      }

      [DataMember( Name = "ProcedimentosMedicosId" , Order = 43 )]
      [GxSeudo()]
      public string gxTpr_Procedimentosmedicosid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Procedimentosmedicosid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Procedimentosmedicosid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "PropostaDescricao" , Order = 44 )]
      [GxSeudo()]
      public string gxTpr_Propostadescricao
      {
         get {
            return sdt.gxTpr_Propostadescricao ;
         }

         set {
            sdt.gxTpr_Propostadescricao = value;
         }

      }

      [DataMember( Name = "PropostaDataCirurgia" , Order = 45 )]
      [GxSeudo()]
      public string gxTpr_Propostadatacirurgia
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Propostadatacirurgia) ;
         }

         set {
            sdt.gxTpr_Propostadatacirurgia = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "PropostaValor" , Order = 46 )]
      [GxSeudo()]
      public string gxTpr_Propostavalor
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Propostavalor, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Propostavalor = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "PropostaValorLiquido" , Order = 47 )]
      [GxSeudo()]
      public string gxTpr_Propostavalorliquido
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Propostavalorliquido, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Propostavalorliquido = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "PropostaTaxaAdministrativa" , Order = 48 )]
      [GxSeudo()]
      public string gxTpr_Propostataxaadministrativa
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Propostataxaadministrativa, 16, 4)) ;
         }

         set {
            sdt.gxTpr_Propostataxaadministrativa = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "PropostaTaxa_F" , Order = 49 )]
      [GxSeudo()]
      public string gxTpr_Propostataxa_f
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Propostataxa_f, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Propostataxa_f = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "PropostaSLA" , Order = 50 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Propostasla
      {
         get {
            return sdt.gxTpr_Propostasla ;
         }

         set {
            sdt.gxTpr_Propostasla = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "PropostaJurosMora" , Order = 51 )]
      [GxSeudo()]
      public string gxTpr_Propostajurosmora
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Propostajurosmora, 16, 4)) ;
         }

         set {
            sdt.gxTpr_Propostajurosmora = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "PropostaCreatedAt" , Order = 52 )]
      [GxSeudo()]
      public string gxTpr_Propostacreatedat
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Propostacreatedat, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Propostacreatedat = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "PropostaCratedBy" , Order = 53 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Propostacratedby
      {
         get {
            return sdt.gxTpr_Propostacratedby ;
         }

         set {
            sdt.gxTpr_Propostacratedby = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "PropostaClinicaId" , Order = 54 )]
      [GxSeudo()]
      public string gxTpr_Propostaclinicaid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Propostaclinicaid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Propostaclinicaid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "PropostaClinicaNome" , Order = 55 )]
      [GxSeudo()]
      public string gxTpr_Propostaclinicanome
      {
         get {
            return sdt.gxTpr_Propostaclinicanome ;
         }

         set {
            sdt.gxTpr_Propostaclinicanome = value;
         }

      }

      [DataMember( Name = "PropostaClinicaNomeFantasia" , Order = 56 )]
      [GxSeudo()]
      public string gxTpr_Propostaclinicanomefantasia
      {
         get {
            return sdt.gxTpr_Propostaclinicanomefantasia ;
         }

         set {
            sdt.gxTpr_Propostaclinicanomefantasia = value;
         }

      }

      [DataMember( Name = "PropostaClinicaDocumento" , Order = 57 )]
      [GxSeudo()]
      public string gxTpr_Propostaclinicadocumento
      {
         get {
            return sdt.gxTpr_Propostaclinicadocumento ;
         }

         set {
            sdt.gxTpr_Propostaclinicadocumento = value;
         }

      }

      [DataMember( Name = "PropostaClinicaEmail" , Order = 58 )]
      [GxSeudo()]
      public string gxTpr_Propostaclinicaemail
      {
         get {
            return sdt.gxTpr_Propostaclinicaemail ;
         }

         set {
            sdt.gxTpr_Propostaclinicaemail = value;
         }

      }

      [DataMember( Name = "PropostaSecUserName" , Order = 59 )]
      [GxSeudo()]
      public string gxTpr_Propostasecusername
      {
         get {
            return sdt.gxTpr_Propostasecusername ;
         }

         set {
            sdt.gxTpr_Propostasecusername = value;
         }

      }

      [DataMember( Name = "PropostaStatus" , Order = 60 )]
      [GxSeudo()]
      public string gxTpr_Propostastatus
      {
         get {
            return sdt.gxTpr_Propostastatus ;
         }

         set {
            sdt.gxTpr_Propostastatus = value;
         }

      }

      [DataMember( Name = "PropostaComentarioAnalise" , Order = 61 )]
      [GxSeudo()]
      public string gxTpr_Propostacomentarioanalise
      {
         get {
            return sdt.gxTpr_Propostacomentarioanalise ;
         }

         set {
            sdt.gxTpr_Propostacomentarioanalise = value;
         }

      }

      [DataMember( Name = "PropostaQuantidadeAprovadores" , Order = 62 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Propostaquantidadeaprovadores
      {
         get {
            return sdt.gxTpr_Propostaquantidadeaprovadores ;
         }

         set {
            sdt.gxTpr_Propostaquantidadeaprovadores = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "PropostaReprovacoesPermitidas" , Order = 63 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Propostareprovacoespermitidas
      {
         get {
            return sdt.gxTpr_Propostareprovacoespermitidas ;
         }

         set {
            sdt.gxTpr_Propostareprovacoespermitidas = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ContratoId" , Order = 64 )]
      [GxSeudo()]
      public Nullable<int> gxTpr_Contratoid
      {
         get {
            return sdt.gxTpr_Contratoid ;
         }

         set {
            sdt.gxTpr_Contratoid = (int)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ContratoNome" , Order = 65 )]
      [GxSeudo()]
      public string gxTpr_Contratonome
      {
         get {
            return sdt.gxTpr_Contratonome ;
         }

         set {
            sdt.gxTpr_Contratonome = value;
         }

      }

      [DataMember( Name = "ConvenioId" , Order = 66 )]
      [GxSeudo()]
      public string gxTpr_Convenioid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Convenioid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Convenioid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ConvenioVencimentoAno" , Order = 67 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Conveniovencimentoano
      {
         get {
            return sdt.gxTpr_Conveniovencimentoano ;
         }

         set {
            sdt.gxTpr_Conveniovencimentoano = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ConvenioVencimentoMes" , Order = 68 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Conveniovencimentomes
      {
         get {
            return sdt.gxTpr_Conveniovencimentomes ;
         }

         set {
            sdt.gxTpr_Conveniovencimentomes = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ConvenioCategoriaId" , Order = 69 )]
      [GxSeudo()]
      public string gxTpr_Conveniocategoriaid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Conveniocategoriaid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Conveniocategoriaid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ConvenioCategoriaDescricao" , Order = 70 )]
      [GxSeudo()]
      public string gxTpr_Conveniocategoriadescricao
      {
         get {
            return sdt.gxTpr_Conveniocategoriadescricao ;
         }

         set {
            sdt.gxTpr_Conveniocategoriadescricao = value;
         }

      }

      [DataMember( Name = "PropostaDataCreditoCliente_F" , Order = 71 )]
      [GxSeudo()]
      public string gxTpr_Propostadatacreditocliente_f
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Propostadatacreditocliente_f) ;
         }

         set {
            sdt.gxTpr_Propostadatacreditocliente_f = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "PropostaValorTaxa_F" , Order = 72 )]
      [GxSeudo()]
      public string gxTpr_Propostavalortaxa_f
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Propostavalortaxa_f, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Propostavalortaxa_f = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "PropostaValorJurosMora_F" , Order = 73 )]
      [GxSeudo()]
      public string gxTpr_Propostavalorjurosmora_f
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Propostavalorjurosmora_f, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Propostavalorjurosmora_f = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "PropostaValorReembolsado_F" , Order = 74 )]
      [GxSeudo()]
      public string gxTpr_Propostavalorreembolsado_f
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Propostavalorreembolsado_f, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Propostavalorreembolsado_f = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "PropostaValorReembolsadoJuros_F" , Order = 75 )]
      [GxSeudo()]
      public string gxTpr_Propostavalorreembolsadojuros_f
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Propostavalorreembolsadojuros_f, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Propostavalorreembolsadojuros_f = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "PropostaValorTaxaRecebida_F" , Order = 76 )]
      [GxSeudo()]
      public string gxTpr_Propostavalortaxarecebida_f
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Propostavalortaxarecebida_f, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Propostavalortaxarecebida_f = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "PropostaAprovacoes_F" , Order = 77 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Propostaaprovacoes_f
      {
         get {
            return sdt.gxTpr_Propostaaprovacoes_f ;
         }

         set {
            sdt.gxTpr_Propostaaprovacoes_f = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "PropostaReprovacoes_F" , Order = 78 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Propostareprovacoes_f
      {
         get {
            return sdt.gxTpr_Propostareprovacoes_f ;
         }

         set {
            sdt.gxTpr_Propostareprovacoes_f = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "PropostaAprovacoesRestantes_F" , Order = 79 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Propostaaprovacoesrestantes_f
      {
         get {
            return sdt.gxTpr_Propostaaprovacoesrestantes_f ;
         }

         set {
            sdt.gxTpr_Propostaaprovacoesrestantes_f = (short)(value.HasValue ? value.Value : 0);
         }

      }

      public SdtProposta sdt
      {
         get {
            return (SdtProposta)Sdt ;
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
            sdt = new SdtProposta() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 80 )]
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

   [DataContract(Name = @"Proposta", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtProposta_RESTLInterface : GxGenericCollectionItem<SdtProposta>
   {
      public SdtProposta_RESTLInterface( ) : base()
      {
      }

      public SdtProposta_RESTLInterface( SdtProposta psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PropostaMaxReembolsoId_F" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Propostamaxreembolsoid_f
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Propostamaxreembolsoid_f), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Propostamaxreembolsoid_f = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
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

      public SdtProposta sdt
      {
         get {
            return (SdtProposta)Sdt ;
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
            sdt = new SdtProposta() ;
         }
      }

   }

}
