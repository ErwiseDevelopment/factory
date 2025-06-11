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
   [XmlRoot(ElementName = "AssinaturaParticipante" )]
   [XmlType(TypeName =  "AssinaturaParticipante" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtAssinaturaParticipante : GxSilentTrnSdt
   {
      public SdtAssinaturaParticipante( )
      {
      }

      public SdtAssinaturaParticipante( IGxContext context )
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

      public void Load( int AV242AssinaturaParticipanteId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV242AssinaturaParticipanteId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"AssinaturaParticipanteId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "AssinaturaParticipante");
         metadata.Set("BT", "AssinaturaParticipante");
         metadata.Set("PK", "[ \"AssinaturaParticipanteId\" ]");
         metadata.Set("PKAssigned", "[ \"AssinaturaParticipanteId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"AssinaturaId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"ClienteId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"ParticipanteId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Assinaturaparticipanteid_Z");
         state.Add("gxTpr_Assinaturaid_Z");
         state.Add("gxTpr_Participanteid_Z");
         state.Add("gxTpr_Clienteid_Z");
         state.Add("gxTpr_Participantenome_Z");
         state.Add("gxTpr_Participanteemail_Z");
         state.Add("gxTpr_Participantedocumento_Z");
         state.Add("gxTpr_Assinaturaparticipantestatus_Z");
         state.Add("gxTpr_Assinaturaparticipantedatavisualizacao_Z_Nullable");
         state.Add("gxTpr_Assinaturaparticipantedataconclusao_Z_Nullable");
         state.Add("gxTpr_Assinaturaparticipantekey_Z");
         state.Add("gxTpr_Assinaturaparticipantetipo_Z");
         state.Add("gxTpr_Assinaturaparticipanteremoteaddres_Z");
         state.Add("gxTpr_Assinaturaparticipantegeolocalizacao_Z");
         state.Add("gxTpr_Assinaturaparticipantedispositivo_Z");
         state.Add("gxTpr_Assinaturaparticipantecpf_Z");
         state.Add("gxTpr_Assinaturaparticipanteemail_Z");
         state.Add("gxTpr_Assinaturaparticipantenascimento_Z_Nullable");
         state.Add("gxTpr_Assinaturaparticipantelink_Z");
         state.Add("gxTpr_Assinaturaparticipanteid_N");
         state.Add("gxTpr_Assinaturaid_N");
         state.Add("gxTpr_Participanteid_N");
         state.Add("gxTpr_Clienteid_N");
         state.Add("gxTpr_Participantenome_N");
         state.Add("gxTpr_Participanteemail_N");
         state.Add("gxTpr_Participantedocumento_N");
         state.Add("gxTpr_Assinaturaparticipantestatus_N");
         state.Add("gxTpr_Assinaturaparticipantedatavisualizacao_N");
         state.Add("gxTpr_Assinaturaparticipantedataconclusao_N");
         state.Add("gxTpr_Assinaturaparticipantekey_N");
         state.Add("gxTpr_Assinaturaparticipantetipo_N");
         state.Add("gxTpr_Assinaturaparticipanteremoteaddres_N");
         state.Add("gxTpr_Assinaturaparticipantegeolocalizacao_N");
         state.Add("gxTpr_Assinaturaparticipantedispositivo_N");
         state.Add("gxTpr_Assinaturaparticipantecpf_N");
         state.Add("gxTpr_Assinaturaparticipanteemail_N");
         state.Add("gxTpr_Assinaturaparticipantenascimento_N");
         state.Add("gxTpr_Assinaturaparticipantelink_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtAssinaturaParticipante sdt;
         sdt = (SdtAssinaturaParticipante)(source);
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteid = sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteid ;
         gxTv_SdtAssinaturaParticipante_Assinaturaid = sdt.gxTv_SdtAssinaturaParticipante_Assinaturaid ;
         gxTv_SdtAssinaturaParticipante_Participanteid = sdt.gxTv_SdtAssinaturaParticipante_Participanteid ;
         gxTv_SdtAssinaturaParticipante_Clienteid = sdt.gxTv_SdtAssinaturaParticipante_Clienteid ;
         gxTv_SdtAssinaturaParticipante_Participantenome = sdt.gxTv_SdtAssinaturaParticipante_Participantenome ;
         gxTv_SdtAssinaturaParticipante_Participanteemail = sdt.gxTv_SdtAssinaturaParticipante_Participanteemail ;
         gxTv_SdtAssinaturaParticipante_Participantedocumento = sdt.gxTv_SdtAssinaturaParticipante_Participantedocumento ;
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantestatus = sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantestatus ;
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedatavisualizacao = sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedatavisualizacao ;
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedataconclusao = sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedataconclusao ;
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantekey = sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantekey ;
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantetipo = sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantetipo ;
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteremoteaddres = sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteremoteaddres ;
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantegeolocalizacao = sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantegeolocalizacao ;
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedispositivo = sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedispositivo ;
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantecpf = sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantecpf ;
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteemail = sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteemail ;
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantenascimento = sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantenascimento ;
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantelink = sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantelink ;
         gxTv_SdtAssinaturaParticipante_Mode = sdt.gxTv_SdtAssinaturaParticipante_Mode ;
         gxTv_SdtAssinaturaParticipante_Initialized = sdt.gxTv_SdtAssinaturaParticipante_Initialized ;
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteid_Z = sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteid_Z ;
         gxTv_SdtAssinaturaParticipante_Assinaturaid_Z = sdt.gxTv_SdtAssinaturaParticipante_Assinaturaid_Z ;
         gxTv_SdtAssinaturaParticipante_Participanteid_Z = sdt.gxTv_SdtAssinaturaParticipante_Participanteid_Z ;
         gxTv_SdtAssinaturaParticipante_Clienteid_Z = sdt.gxTv_SdtAssinaturaParticipante_Clienteid_Z ;
         gxTv_SdtAssinaturaParticipante_Participantenome_Z = sdt.gxTv_SdtAssinaturaParticipante_Participantenome_Z ;
         gxTv_SdtAssinaturaParticipante_Participanteemail_Z = sdt.gxTv_SdtAssinaturaParticipante_Participanteemail_Z ;
         gxTv_SdtAssinaturaParticipante_Participantedocumento_Z = sdt.gxTv_SdtAssinaturaParticipante_Participantedocumento_Z ;
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantestatus_Z = sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantestatus_Z ;
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedatavisualizacao_Z = sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedatavisualizacao_Z ;
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedataconclusao_Z = sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedataconclusao_Z ;
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantekey_Z = sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantekey_Z ;
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantetipo_Z = sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantetipo_Z ;
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteremoteaddres_Z = sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteremoteaddres_Z ;
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantegeolocalizacao_Z = sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantegeolocalizacao_Z ;
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedispositivo_Z = sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedispositivo_Z ;
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantecpf_Z = sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantecpf_Z ;
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteemail_Z = sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteemail_Z ;
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantenascimento_Z = sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantenascimento_Z ;
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantelink_Z = sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantelink_Z ;
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteid_N = sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteid_N ;
         gxTv_SdtAssinaturaParticipante_Assinaturaid_N = sdt.gxTv_SdtAssinaturaParticipante_Assinaturaid_N ;
         gxTv_SdtAssinaturaParticipante_Participanteid_N = sdt.gxTv_SdtAssinaturaParticipante_Participanteid_N ;
         gxTv_SdtAssinaturaParticipante_Clienteid_N = sdt.gxTv_SdtAssinaturaParticipante_Clienteid_N ;
         gxTv_SdtAssinaturaParticipante_Participantenome_N = sdt.gxTv_SdtAssinaturaParticipante_Participantenome_N ;
         gxTv_SdtAssinaturaParticipante_Participanteemail_N = sdt.gxTv_SdtAssinaturaParticipante_Participanteemail_N ;
         gxTv_SdtAssinaturaParticipante_Participantedocumento_N = sdt.gxTv_SdtAssinaturaParticipante_Participantedocumento_N ;
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantestatus_N = sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantestatus_N ;
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedatavisualizacao_N = sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedatavisualizacao_N ;
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedataconclusao_N = sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedataconclusao_N ;
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantekey_N = sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantekey_N ;
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantetipo_N = sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantetipo_N ;
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteremoteaddres_N = sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteremoteaddres_N ;
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantegeolocalizacao_N = sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantegeolocalizacao_N ;
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedispositivo_N = sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedispositivo_N ;
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantecpf_N = sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantecpf_N ;
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteemail_N = sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteemail_N ;
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantenascimento_N = sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantenascimento_N ;
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantelink_N = sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantelink_N ;
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
         AddObjectProperty("AssinaturaParticipanteId", gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteid, false, includeNonInitialized);
         AddObjectProperty("AssinaturaParticipanteId_N", gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteid_N, false, includeNonInitialized);
         AddObjectProperty("AssinaturaId", gxTv_SdtAssinaturaParticipante_Assinaturaid, false, includeNonInitialized);
         AddObjectProperty("AssinaturaId_N", gxTv_SdtAssinaturaParticipante_Assinaturaid_N, false, includeNonInitialized);
         AddObjectProperty("ParticipanteId", gxTv_SdtAssinaturaParticipante_Participanteid, false, includeNonInitialized);
         AddObjectProperty("ParticipanteId_N", gxTv_SdtAssinaturaParticipante_Participanteid_N, false, includeNonInitialized);
         AddObjectProperty("ClienteId", gxTv_SdtAssinaturaParticipante_Clienteid, false, includeNonInitialized);
         AddObjectProperty("ClienteId_N", gxTv_SdtAssinaturaParticipante_Clienteid_N, false, includeNonInitialized);
         AddObjectProperty("ParticipanteNome", gxTv_SdtAssinaturaParticipante_Participantenome, false, includeNonInitialized);
         AddObjectProperty("ParticipanteNome_N", gxTv_SdtAssinaturaParticipante_Participantenome_N, false, includeNonInitialized);
         AddObjectProperty("ParticipanteEmail", gxTv_SdtAssinaturaParticipante_Participanteemail, false, includeNonInitialized);
         AddObjectProperty("ParticipanteEmail_N", gxTv_SdtAssinaturaParticipante_Participanteemail_N, false, includeNonInitialized);
         AddObjectProperty("ParticipanteDocumento", gxTv_SdtAssinaturaParticipante_Participantedocumento, false, includeNonInitialized);
         AddObjectProperty("ParticipanteDocumento_N", gxTv_SdtAssinaturaParticipante_Participantedocumento_N, false, includeNonInitialized);
         AddObjectProperty("AssinaturaParticipanteStatus", gxTv_SdtAssinaturaParticipante_Assinaturaparticipantestatus, false, includeNonInitialized);
         AddObjectProperty("AssinaturaParticipanteStatus_N", gxTv_SdtAssinaturaParticipante_Assinaturaparticipantestatus_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedatavisualizacao;
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
         AddObjectProperty("AssinaturaParticipanteDataVisualizacao", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("AssinaturaParticipanteDataVisualizacao_N", gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedatavisualizacao_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedataconclusao;
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
         AddObjectProperty("AssinaturaParticipanteDataConclusao", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("AssinaturaParticipanteDataConclusao_N", gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedataconclusao_N, false, includeNonInitialized);
         AddObjectProperty("AssinaturaParticipanteKey", gxTv_SdtAssinaturaParticipante_Assinaturaparticipantekey, false, includeNonInitialized);
         AddObjectProperty("AssinaturaParticipanteKey_N", gxTv_SdtAssinaturaParticipante_Assinaturaparticipantekey_N, false, includeNonInitialized);
         AddObjectProperty("AssinaturaParticipanteTipo", gxTv_SdtAssinaturaParticipante_Assinaturaparticipantetipo, false, includeNonInitialized);
         AddObjectProperty("AssinaturaParticipanteTipo_N", gxTv_SdtAssinaturaParticipante_Assinaturaparticipantetipo_N, false, includeNonInitialized);
         AddObjectProperty("AssinaturaParticipanteRemoteAddres", gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteremoteaddres, false, includeNonInitialized);
         AddObjectProperty("AssinaturaParticipanteRemoteAddres_N", gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteremoteaddres_N, false, includeNonInitialized);
         AddObjectProperty("AssinaturaParticipanteGeolocalizacao", gxTv_SdtAssinaturaParticipante_Assinaturaparticipantegeolocalizacao, false, includeNonInitialized);
         AddObjectProperty("AssinaturaParticipanteGeolocalizacao_N", gxTv_SdtAssinaturaParticipante_Assinaturaparticipantegeolocalizacao_N, false, includeNonInitialized);
         AddObjectProperty("AssinaturaParticipanteDispositivo", gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedispositivo, false, includeNonInitialized);
         AddObjectProperty("AssinaturaParticipanteDispositivo_N", gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedispositivo_N, false, includeNonInitialized);
         AddObjectProperty("AssinaturaParticipanteCPF", gxTv_SdtAssinaturaParticipante_Assinaturaparticipantecpf, false, includeNonInitialized);
         AddObjectProperty("AssinaturaParticipanteCPF_N", gxTv_SdtAssinaturaParticipante_Assinaturaparticipantecpf_N, false, includeNonInitialized);
         AddObjectProperty("AssinaturaParticipanteEmail", gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteemail, false, includeNonInitialized);
         AddObjectProperty("AssinaturaParticipanteEmail_N", gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteemail_N, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtAssinaturaParticipante_Assinaturaparticipantenascimento)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtAssinaturaParticipante_Assinaturaparticipantenascimento)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtAssinaturaParticipante_Assinaturaparticipantenascimento)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("AssinaturaParticipanteNascimento", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("AssinaturaParticipanteNascimento_N", gxTv_SdtAssinaturaParticipante_Assinaturaparticipantenascimento_N, false, includeNonInitialized);
         AddObjectProperty("AssinaturaParticipanteLink", gxTv_SdtAssinaturaParticipante_Assinaturaparticipantelink, false, includeNonInitialized);
         AddObjectProperty("AssinaturaParticipanteLink_N", gxTv_SdtAssinaturaParticipante_Assinaturaparticipantelink_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtAssinaturaParticipante_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtAssinaturaParticipante_Initialized, false, includeNonInitialized);
            AddObjectProperty("AssinaturaParticipanteId_Z", gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteid_Z, false, includeNonInitialized);
            AddObjectProperty("AssinaturaId_Z", gxTv_SdtAssinaturaParticipante_Assinaturaid_Z, false, includeNonInitialized);
            AddObjectProperty("ParticipanteId_Z", gxTv_SdtAssinaturaParticipante_Participanteid_Z, false, includeNonInitialized);
            AddObjectProperty("ClienteId_Z", gxTv_SdtAssinaturaParticipante_Clienteid_Z, false, includeNonInitialized);
            AddObjectProperty("ParticipanteNome_Z", gxTv_SdtAssinaturaParticipante_Participantenome_Z, false, includeNonInitialized);
            AddObjectProperty("ParticipanteEmail_Z", gxTv_SdtAssinaturaParticipante_Participanteemail_Z, false, includeNonInitialized);
            AddObjectProperty("ParticipanteDocumento_Z", gxTv_SdtAssinaturaParticipante_Participantedocumento_Z, false, includeNonInitialized);
            AddObjectProperty("AssinaturaParticipanteStatus_Z", gxTv_SdtAssinaturaParticipante_Assinaturaparticipantestatus_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedatavisualizacao_Z;
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
            AddObjectProperty("AssinaturaParticipanteDataVisualizacao_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedataconclusao_Z;
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
            AddObjectProperty("AssinaturaParticipanteDataConclusao_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("AssinaturaParticipanteKey_Z", gxTv_SdtAssinaturaParticipante_Assinaturaparticipantekey_Z, false, includeNonInitialized);
            AddObjectProperty("AssinaturaParticipanteTipo_Z", gxTv_SdtAssinaturaParticipante_Assinaturaparticipantetipo_Z, false, includeNonInitialized);
            AddObjectProperty("AssinaturaParticipanteRemoteAddres_Z", gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteremoteaddres_Z, false, includeNonInitialized);
            AddObjectProperty("AssinaturaParticipanteGeolocalizacao_Z", gxTv_SdtAssinaturaParticipante_Assinaturaparticipantegeolocalizacao_Z, false, includeNonInitialized);
            AddObjectProperty("AssinaturaParticipanteDispositivo_Z", gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedispositivo_Z, false, includeNonInitialized);
            AddObjectProperty("AssinaturaParticipanteCPF_Z", gxTv_SdtAssinaturaParticipante_Assinaturaparticipantecpf_Z, false, includeNonInitialized);
            AddObjectProperty("AssinaturaParticipanteEmail_Z", gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteemail_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtAssinaturaParticipante_Assinaturaparticipantenascimento_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtAssinaturaParticipante_Assinaturaparticipantenascimento_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtAssinaturaParticipante_Assinaturaparticipantenascimento_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("AssinaturaParticipanteNascimento_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("AssinaturaParticipanteLink_Z", gxTv_SdtAssinaturaParticipante_Assinaturaparticipantelink_Z, false, includeNonInitialized);
            AddObjectProperty("AssinaturaParticipanteId_N", gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteid_N, false, includeNonInitialized);
            AddObjectProperty("AssinaturaId_N", gxTv_SdtAssinaturaParticipante_Assinaturaid_N, false, includeNonInitialized);
            AddObjectProperty("ParticipanteId_N", gxTv_SdtAssinaturaParticipante_Participanteid_N, false, includeNonInitialized);
            AddObjectProperty("ClienteId_N", gxTv_SdtAssinaturaParticipante_Clienteid_N, false, includeNonInitialized);
            AddObjectProperty("ParticipanteNome_N", gxTv_SdtAssinaturaParticipante_Participantenome_N, false, includeNonInitialized);
            AddObjectProperty("ParticipanteEmail_N", gxTv_SdtAssinaturaParticipante_Participanteemail_N, false, includeNonInitialized);
            AddObjectProperty("ParticipanteDocumento_N", gxTv_SdtAssinaturaParticipante_Participantedocumento_N, false, includeNonInitialized);
            AddObjectProperty("AssinaturaParticipanteStatus_N", gxTv_SdtAssinaturaParticipante_Assinaturaparticipantestatus_N, false, includeNonInitialized);
            AddObjectProperty("AssinaturaParticipanteDataVisualizacao_N", gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedatavisualizacao_N, false, includeNonInitialized);
            AddObjectProperty("AssinaturaParticipanteDataConclusao_N", gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedataconclusao_N, false, includeNonInitialized);
            AddObjectProperty("AssinaturaParticipanteKey_N", gxTv_SdtAssinaturaParticipante_Assinaturaparticipantekey_N, false, includeNonInitialized);
            AddObjectProperty("AssinaturaParticipanteTipo_N", gxTv_SdtAssinaturaParticipante_Assinaturaparticipantetipo_N, false, includeNonInitialized);
            AddObjectProperty("AssinaturaParticipanteRemoteAddres_N", gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteremoteaddres_N, false, includeNonInitialized);
            AddObjectProperty("AssinaturaParticipanteGeolocalizacao_N", gxTv_SdtAssinaturaParticipante_Assinaturaparticipantegeolocalizacao_N, false, includeNonInitialized);
            AddObjectProperty("AssinaturaParticipanteDispositivo_N", gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedispositivo_N, false, includeNonInitialized);
            AddObjectProperty("AssinaturaParticipanteCPF_N", gxTv_SdtAssinaturaParticipante_Assinaturaparticipantecpf_N, false, includeNonInitialized);
            AddObjectProperty("AssinaturaParticipanteEmail_N", gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteemail_N, false, includeNonInitialized);
            AddObjectProperty("AssinaturaParticipanteNascimento_N", gxTv_SdtAssinaturaParticipante_Assinaturaparticipantenascimento_N, false, includeNonInitialized);
            AddObjectProperty("AssinaturaParticipanteLink_N", gxTv_SdtAssinaturaParticipante_Assinaturaparticipantelink_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtAssinaturaParticipante sdt )
      {
         if ( sdt.IsDirty("AssinaturaParticipanteId") )
         {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteid = sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteid ;
         }
         if ( sdt.IsDirty("AssinaturaId") )
         {
            gxTv_SdtAssinaturaParticipante_Assinaturaid_N = (short)(sdt.gxTv_SdtAssinaturaParticipante_Assinaturaid_N);
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Assinaturaid = sdt.gxTv_SdtAssinaturaParticipante_Assinaturaid ;
         }
         if ( sdt.IsDirty("ParticipanteId") )
         {
            gxTv_SdtAssinaturaParticipante_Participanteid_N = (short)(sdt.gxTv_SdtAssinaturaParticipante_Participanteid_N);
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Participanteid = sdt.gxTv_SdtAssinaturaParticipante_Participanteid ;
         }
         if ( sdt.IsDirty("ClienteId") )
         {
            gxTv_SdtAssinaturaParticipante_Clienteid_N = (short)(sdt.gxTv_SdtAssinaturaParticipante_Clienteid_N);
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Clienteid = sdt.gxTv_SdtAssinaturaParticipante_Clienteid ;
         }
         if ( sdt.IsDirty("ParticipanteNome") )
         {
            gxTv_SdtAssinaturaParticipante_Participantenome_N = (short)(sdt.gxTv_SdtAssinaturaParticipante_Participantenome_N);
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Participantenome = sdt.gxTv_SdtAssinaturaParticipante_Participantenome ;
         }
         if ( sdt.IsDirty("ParticipanteEmail") )
         {
            gxTv_SdtAssinaturaParticipante_Participanteemail_N = (short)(sdt.gxTv_SdtAssinaturaParticipante_Participanteemail_N);
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Participanteemail = sdt.gxTv_SdtAssinaturaParticipante_Participanteemail ;
         }
         if ( sdt.IsDirty("ParticipanteDocumento") )
         {
            gxTv_SdtAssinaturaParticipante_Participantedocumento_N = (short)(sdt.gxTv_SdtAssinaturaParticipante_Participantedocumento_N);
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Participantedocumento = sdt.gxTv_SdtAssinaturaParticipante_Participantedocumento ;
         }
         if ( sdt.IsDirty("AssinaturaParticipanteStatus") )
         {
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantestatus_N = (short)(sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantestatus_N);
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantestatus = sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantestatus ;
         }
         if ( sdt.IsDirty("AssinaturaParticipanteDataVisualizacao") )
         {
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedatavisualizacao_N = (short)(sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedatavisualizacao_N);
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedatavisualizacao = sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedatavisualizacao ;
         }
         if ( sdt.IsDirty("AssinaturaParticipanteDataConclusao") )
         {
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedataconclusao_N = (short)(sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedataconclusao_N);
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedataconclusao = sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedataconclusao ;
         }
         if ( sdt.IsDirty("AssinaturaParticipanteKey") )
         {
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantekey_N = (short)(sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantekey_N);
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantekey = sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantekey ;
         }
         if ( sdt.IsDirty("AssinaturaParticipanteTipo") )
         {
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantetipo_N = (short)(sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantetipo_N);
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantetipo = sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantetipo ;
         }
         if ( sdt.IsDirty("AssinaturaParticipanteRemoteAddres") )
         {
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteremoteaddres_N = (short)(sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteremoteaddres_N);
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteremoteaddres = sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteremoteaddres ;
         }
         if ( sdt.IsDirty("AssinaturaParticipanteGeolocalizacao") )
         {
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantegeolocalizacao_N = (short)(sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantegeolocalizacao_N);
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantegeolocalizacao = sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantegeolocalizacao ;
         }
         if ( sdt.IsDirty("AssinaturaParticipanteDispositivo") )
         {
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedispositivo_N = (short)(sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedispositivo_N);
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedispositivo = sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedispositivo ;
         }
         if ( sdt.IsDirty("AssinaturaParticipanteCPF") )
         {
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantecpf_N = (short)(sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantecpf_N);
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantecpf = sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantecpf ;
         }
         if ( sdt.IsDirty("AssinaturaParticipanteEmail") )
         {
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteemail_N = (short)(sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteemail_N);
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteemail = sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteemail ;
         }
         if ( sdt.IsDirty("AssinaturaParticipanteNascimento") )
         {
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantenascimento_N = (short)(sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantenascimento_N);
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantenascimento = sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantenascimento ;
         }
         if ( sdt.IsDirty("AssinaturaParticipanteLink") )
         {
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantelink_N = (short)(sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantelink_N);
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantelink = sdt.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantelink ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteId" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteId"   )]
      public int gxTpr_Assinaturaparticipanteid
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteid != value )
            {
               gxTv_SdtAssinaturaParticipante_Mode = "INS";
               this.gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteid_Z_SetNull( );
               this.gxTv_SdtAssinaturaParticipante_Assinaturaid_Z_SetNull( );
               this.gxTv_SdtAssinaturaParticipante_Participanteid_Z_SetNull( );
               this.gxTv_SdtAssinaturaParticipante_Clienteid_Z_SetNull( );
               this.gxTv_SdtAssinaturaParticipante_Participantenome_Z_SetNull( );
               this.gxTv_SdtAssinaturaParticipante_Participanteemail_Z_SetNull( );
               this.gxTv_SdtAssinaturaParticipante_Participantedocumento_Z_SetNull( );
               this.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantestatus_Z_SetNull( );
               this.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedatavisualizacao_Z_SetNull( );
               this.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedataconclusao_Z_SetNull( );
               this.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantekey_Z_SetNull( );
               this.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantetipo_Z_SetNull( );
               this.gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteremoteaddres_Z_SetNull( );
               this.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantegeolocalizacao_Z_SetNull( );
               this.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedispositivo_Z_SetNull( );
               this.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantecpf_Z_SetNull( );
               this.gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteemail_Z_SetNull( );
               this.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantenascimento_Z_SetNull( );
               this.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantelink_Z_SetNull( );
            }
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteid = value;
            SetDirty("Assinaturaparticipanteid");
         }

      }

      [  SoapElement( ElementName = "AssinaturaId" )]
      [  XmlElement( ElementName = "AssinaturaId"   )]
      public long gxTpr_Assinaturaid
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Assinaturaid ;
         }

         set {
            gxTv_SdtAssinaturaParticipante_Assinaturaid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Assinaturaid = value;
            SetDirty("Assinaturaid");
         }

      }

      public void gxTv_SdtAssinaturaParticipante_Assinaturaid_SetNull( )
      {
         gxTv_SdtAssinaturaParticipante_Assinaturaid_N = 1;
         gxTv_SdtAssinaturaParticipante_Assinaturaid = 0;
         SetDirty("Assinaturaid");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipante_Assinaturaid_IsNull( )
      {
         return (gxTv_SdtAssinaturaParticipante_Assinaturaid_N==1) ;
      }

      [  SoapElement( ElementName = "ParticipanteId" )]
      [  XmlElement( ElementName = "ParticipanteId"   )]
      public int gxTpr_Participanteid
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Participanteid ;
         }

         set {
            gxTv_SdtAssinaturaParticipante_Participanteid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Participanteid = value;
            SetDirty("Participanteid");
         }

      }

      public void gxTv_SdtAssinaturaParticipante_Participanteid_SetNull( )
      {
         gxTv_SdtAssinaturaParticipante_Participanteid_N = 1;
         gxTv_SdtAssinaturaParticipante_Participanteid = 0;
         SetDirty("Participanteid");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipante_Participanteid_IsNull( )
      {
         return (gxTv_SdtAssinaturaParticipante_Participanteid_N==1) ;
      }

      [  SoapElement( ElementName = "ClienteId" )]
      [  XmlElement( ElementName = "ClienteId"   )]
      public int gxTpr_Clienteid
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Clienteid ;
         }

         set {
            gxTv_SdtAssinaturaParticipante_Clienteid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Clienteid = value;
            SetDirty("Clienteid");
         }

      }

      public void gxTv_SdtAssinaturaParticipante_Clienteid_SetNull( )
      {
         gxTv_SdtAssinaturaParticipante_Clienteid_N = 1;
         gxTv_SdtAssinaturaParticipante_Clienteid = 0;
         SetDirty("Clienteid");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipante_Clienteid_IsNull( )
      {
         return (gxTv_SdtAssinaturaParticipante_Clienteid_N==1) ;
      }

      [  SoapElement( ElementName = "ParticipanteNome" )]
      [  XmlElement( ElementName = "ParticipanteNome"   )]
      public string gxTpr_Participantenome
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Participantenome ;
         }

         set {
            gxTv_SdtAssinaturaParticipante_Participantenome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Participantenome = value;
            SetDirty("Participantenome");
         }

      }

      public void gxTv_SdtAssinaturaParticipante_Participantenome_SetNull( )
      {
         gxTv_SdtAssinaturaParticipante_Participantenome_N = 1;
         gxTv_SdtAssinaturaParticipante_Participantenome = "";
         SetDirty("Participantenome");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipante_Participantenome_IsNull( )
      {
         return (gxTv_SdtAssinaturaParticipante_Participantenome_N==1) ;
      }

      [  SoapElement( ElementName = "ParticipanteEmail" )]
      [  XmlElement( ElementName = "ParticipanteEmail"   )]
      public string gxTpr_Participanteemail
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Participanteemail ;
         }

         set {
            gxTv_SdtAssinaturaParticipante_Participanteemail_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Participanteemail = value;
            SetDirty("Participanteemail");
         }

      }

      public void gxTv_SdtAssinaturaParticipante_Participanteemail_SetNull( )
      {
         gxTv_SdtAssinaturaParticipante_Participanteemail_N = 1;
         gxTv_SdtAssinaturaParticipante_Participanteemail = "";
         SetDirty("Participanteemail");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipante_Participanteemail_IsNull( )
      {
         return (gxTv_SdtAssinaturaParticipante_Participanteemail_N==1) ;
      }

      [  SoapElement( ElementName = "ParticipanteDocumento" )]
      [  XmlElement( ElementName = "ParticipanteDocumento"   )]
      public string gxTpr_Participantedocumento
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Participantedocumento ;
         }

         set {
            gxTv_SdtAssinaturaParticipante_Participantedocumento_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Participantedocumento = value;
            SetDirty("Participantedocumento");
         }

      }

      public void gxTv_SdtAssinaturaParticipante_Participantedocumento_SetNull( )
      {
         gxTv_SdtAssinaturaParticipante_Participantedocumento_N = 1;
         gxTv_SdtAssinaturaParticipante_Participantedocumento = "";
         SetDirty("Participantedocumento");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipante_Participantedocumento_IsNull( )
      {
         return (gxTv_SdtAssinaturaParticipante_Participantedocumento_N==1) ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteStatus" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteStatus"   )]
      public string gxTpr_Assinaturaparticipantestatus
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Assinaturaparticipantestatus ;
         }

         set {
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantestatus_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantestatus = value;
            SetDirty("Assinaturaparticipantestatus");
         }

      }

      public void gxTv_SdtAssinaturaParticipante_Assinaturaparticipantestatus_SetNull( )
      {
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantestatus_N = 1;
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantestatus = "";
         SetDirty("Assinaturaparticipantestatus");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipante_Assinaturaparticipantestatus_IsNull( )
      {
         return (gxTv_SdtAssinaturaParticipante_Assinaturaparticipantestatus_N==1) ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteDataVisualizacao" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteDataVisualizacao"  , IsNullable=true )]
      public string gxTpr_Assinaturaparticipantedatavisualizacao_Nullable
      {
         get {
            if ( gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedatavisualizacao == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedatavisualizacao).value ;
         }

         set {
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedatavisualizacao_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedatavisualizacao = DateTime.MinValue;
            else
               gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedatavisualizacao = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Assinaturaparticipantedatavisualizacao
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedatavisualizacao ;
         }

         set {
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedatavisualizacao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedatavisualizacao = value;
            SetDirty("Assinaturaparticipantedatavisualizacao");
         }

      }

      public void gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedatavisualizacao_SetNull( )
      {
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedatavisualizacao_N = 1;
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedatavisualizacao = (DateTime)(DateTime.MinValue);
         SetDirty("Assinaturaparticipantedatavisualizacao");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedatavisualizacao_IsNull( )
      {
         return (gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedatavisualizacao_N==1) ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteDataConclusao" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteDataConclusao"  , IsNullable=true )]
      public string gxTpr_Assinaturaparticipantedataconclusao_Nullable
      {
         get {
            if ( gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedataconclusao == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedataconclusao).value ;
         }

         set {
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedataconclusao_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedataconclusao = DateTime.MinValue;
            else
               gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedataconclusao = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Assinaturaparticipantedataconclusao
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedataconclusao ;
         }

         set {
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedataconclusao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedataconclusao = value;
            SetDirty("Assinaturaparticipantedataconclusao");
         }

      }

      public void gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedataconclusao_SetNull( )
      {
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedataconclusao_N = 1;
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedataconclusao = (DateTime)(DateTime.MinValue);
         SetDirty("Assinaturaparticipantedataconclusao");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedataconclusao_IsNull( )
      {
         return (gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedataconclusao_N==1) ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteKey" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteKey"   )]
      public Guid gxTpr_Assinaturaparticipantekey
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Assinaturaparticipantekey ;
         }

         set {
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantekey_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantekey = value;
            SetDirty("Assinaturaparticipantekey");
         }

      }

      public void gxTv_SdtAssinaturaParticipante_Assinaturaparticipantekey_SetNull( )
      {
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantekey_N = 1;
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantekey = Guid.Empty;
         SetDirty("Assinaturaparticipantekey");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipante_Assinaturaparticipantekey_IsNull( )
      {
         return (gxTv_SdtAssinaturaParticipante_Assinaturaparticipantekey_N==1) ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteTipo" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteTipo"   )]
      public string gxTpr_Assinaturaparticipantetipo
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Assinaturaparticipantetipo ;
         }

         set {
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantetipo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantetipo = value;
            SetDirty("Assinaturaparticipantetipo");
         }

      }

      public void gxTv_SdtAssinaturaParticipante_Assinaturaparticipantetipo_SetNull( )
      {
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantetipo_N = 1;
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantetipo = "";
         SetDirty("Assinaturaparticipantetipo");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipante_Assinaturaparticipantetipo_IsNull( )
      {
         return (gxTv_SdtAssinaturaParticipante_Assinaturaparticipantetipo_N==1) ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteRemoteAddres" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteRemoteAddres"   )]
      public string gxTpr_Assinaturaparticipanteremoteaddres
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteremoteaddres ;
         }

         set {
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteremoteaddres_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteremoteaddres = value;
            SetDirty("Assinaturaparticipanteremoteaddres");
         }

      }

      public void gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteremoteaddres_SetNull( )
      {
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteremoteaddres_N = 1;
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteremoteaddres = "";
         SetDirty("Assinaturaparticipanteremoteaddres");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteremoteaddres_IsNull( )
      {
         return (gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteremoteaddres_N==1) ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteGeolocalizacao" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteGeolocalizacao"   )]
      public string gxTpr_Assinaturaparticipantegeolocalizacao
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Assinaturaparticipantegeolocalizacao ;
         }

         set {
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantegeolocalizacao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantegeolocalizacao = value;
            SetDirty("Assinaturaparticipantegeolocalizacao");
         }

      }

      public void gxTv_SdtAssinaturaParticipante_Assinaturaparticipantegeolocalizacao_SetNull( )
      {
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantegeolocalizacao_N = 1;
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantegeolocalizacao = "";
         SetDirty("Assinaturaparticipantegeolocalizacao");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipante_Assinaturaparticipantegeolocalizacao_IsNull( )
      {
         return (gxTv_SdtAssinaturaParticipante_Assinaturaparticipantegeolocalizacao_N==1) ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteDispositivo" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteDispositivo"   )]
      public string gxTpr_Assinaturaparticipantedispositivo
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedispositivo ;
         }

         set {
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedispositivo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedispositivo = value;
            SetDirty("Assinaturaparticipantedispositivo");
         }

      }

      public void gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedispositivo_SetNull( )
      {
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedispositivo_N = 1;
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedispositivo = "";
         SetDirty("Assinaturaparticipantedispositivo");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedispositivo_IsNull( )
      {
         return (gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedispositivo_N==1) ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteCPF" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteCPF"   )]
      public string gxTpr_Assinaturaparticipantecpf
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Assinaturaparticipantecpf ;
         }

         set {
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantecpf_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantecpf = value;
            SetDirty("Assinaturaparticipantecpf");
         }

      }

      public void gxTv_SdtAssinaturaParticipante_Assinaturaparticipantecpf_SetNull( )
      {
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantecpf_N = 1;
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantecpf = "";
         SetDirty("Assinaturaparticipantecpf");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipante_Assinaturaparticipantecpf_IsNull( )
      {
         return (gxTv_SdtAssinaturaParticipante_Assinaturaparticipantecpf_N==1) ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteEmail" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteEmail"   )]
      public string gxTpr_Assinaturaparticipanteemail
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteemail ;
         }

         set {
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteemail_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteemail = value;
            SetDirty("Assinaturaparticipanteemail");
         }

      }

      public void gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteemail_SetNull( )
      {
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteemail_N = 1;
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteemail = "";
         SetDirty("Assinaturaparticipanteemail");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteemail_IsNull( )
      {
         return (gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteemail_N==1) ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteNascimento" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteNascimento"  , IsNullable=true )]
      public string gxTpr_Assinaturaparticipantenascimento_Nullable
      {
         get {
            if ( gxTv_SdtAssinaturaParticipante_Assinaturaparticipantenascimento == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtAssinaturaParticipante_Assinaturaparticipantenascimento).value ;
         }

         set {
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantenascimento_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtAssinaturaParticipante_Assinaturaparticipantenascimento = DateTime.MinValue;
            else
               gxTv_SdtAssinaturaParticipante_Assinaturaparticipantenascimento = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Assinaturaparticipantenascimento
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Assinaturaparticipantenascimento ;
         }

         set {
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantenascimento_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantenascimento = value;
            SetDirty("Assinaturaparticipantenascimento");
         }

      }

      public void gxTv_SdtAssinaturaParticipante_Assinaturaparticipantenascimento_SetNull( )
      {
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantenascimento_N = 1;
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantenascimento = (DateTime)(DateTime.MinValue);
         SetDirty("Assinaturaparticipantenascimento");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipante_Assinaturaparticipantenascimento_IsNull( )
      {
         return (gxTv_SdtAssinaturaParticipante_Assinaturaparticipantenascimento_N==1) ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteLink" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteLink"   )]
      public string gxTpr_Assinaturaparticipantelink
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Assinaturaparticipantelink ;
         }

         set {
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantelink_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantelink = value;
            SetDirty("Assinaturaparticipantelink");
         }

      }

      public void gxTv_SdtAssinaturaParticipante_Assinaturaparticipantelink_SetNull( )
      {
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantelink_N = 1;
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantelink = "";
         SetDirty("Assinaturaparticipantelink");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipante_Assinaturaparticipantelink_IsNull( )
      {
         return (gxTv_SdtAssinaturaParticipante_Assinaturaparticipantelink_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtAssinaturaParticipante_Mode_SetNull( )
      {
         gxTv_SdtAssinaturaParticipante_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipante_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtAssinaturaParticipante_Initialized_SetNull( )
      {
         gxTv_SdtAssinaturaParticipante_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipante_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteId_Z" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteId_Z"   )]
      public int gxTpr_Assinaturaparticipanteid_Z
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteid_Z = value;
            SetDirty("Assinaturaparticipanteid_Z");
         }

      }

      public void gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteid_Z_SetNull( )
      {
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteid_Z = 0;
         SetDirty("Assinaturaparticipanteid_Z");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaId_Z" )]
      [  XmlElement( ElementName = "AssinaturaId_Z"   )]
      public long gxTpr_Assinaturaid_Z
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Assinaturaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Assinaturaid_Z = value;
            SetDirty("Assinaturaid_Z");
         }

      }

      public void gxTv_SdtAssinaturaParticipante_Assinaturaid_Z_SetNull( )
      {
         gxTv_SdtAssinaturaParticipante_Assinaturaid_Z = 0;
         SetDirty("Assinaturaid_Z");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipante_Assinaturaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParticipanteId_Z" )]
      [  XmlElement( ElementName = "ParticipanteId_Z"   )]
      public int gxTpr_Participanteid_Z
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Participanteid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Participanteid_Z = value;
            SetDirty("Participanteid_Z");
         }

      }

      public void gxTv_SdtAssinaturaParticipante_Participanteid_Z_SetNull( )
      {
         gxTv_SdtAssinaturaParticipante_Participanteid_Z = 0;
         SetDirty("Participanteid_Z");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipante_Participanteid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteId_Z" )]
      [  XmlElement( ElementName = "ClienteId_Z"   )]
      public int gxTpr_Clienteid_Z
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Clienteid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Clienteid_Z = value;
            SetDirty("Clienteid_Z");
         }

      }

      public void gxTv_SdtAssinaturaParticipante_Clienteid_Z_SetNull( )
      {
         gxTv_SdtAssinaturaParticipante_Clienteid_Z = 0;
         SetDirty("Clienteid_Z");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipante_Clienteid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParticipanteNome_Z" )]
      [  XmlElement( ElementName = "ParticipanteNome_Z"   )]
      public string gxTpr_Participantenome_Z
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Participantenome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Participantenome_Z = value;
            SetDirty("Participantenome_Z");
         }

      }

      public void gxTv_SdtAssinaturaParticipante_Participantenome_Z_SetNull( )
      {
         gxTv_SdtAssinaturaParticipante_Participantenome_Z = "";
         SetDirty("Participantenome_Z");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipante_Participantenome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParticipanteEmail_Z" )]
      [  XmlElement( ElementName = "ParticipanteEmail_Z"   )]
      public string gxTpr_Participanteemail_Z
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Participanteemail_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Participanteemail_Z = value;
            SetDirty("Participanteemail_Z");
         }

      }

      public void gxTv_SdtAssinaturaParticipante_Participanteemail_Z_SetNull( )
      {
         gxTv_SdtAssinaturaParticipante_Participanteemail_Z = "";
         SetDirty("Participanteemail_Z");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipante_Participanteemail_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParticipanteDocumento_Z" )]
      [  XmlElement( ElementName = "ParticipanteDocumento_Z"   )]
      public string gxTpr_Participantedocumento_Z
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Participantedocumento_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Participantedocumento_Z = value;
            SetDirty("Participantedocumento_Z");
         }

      }

      public void gxTv_SdtAssinaturaParticipante_Participantedocumento_Z_SetNull( )
      {
         gxTv_SdtAssinaturaParticipante_Participantedocumento_Z = "";
         SetDirty("Participantedocumento_Z");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipante_Participantedocumento_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteStatus_Z" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteStatus_Z"   )]
      public string gxTpr_Assinaturaparticipantestatus_Z
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Assinaturaparticipantestatus_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantestatus_Z = value;
            SetDirty("Assinaturaparticipantestatus_Z");
         }

      }

      public void gxTv_SdtAssinaturaParticipante_Assinaturaparticipantestatus_Z_SetNull( )
      {
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantestatus_Z = "";
         SetDirty("Assinaturaparticipantestatus_Z");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipante_Assinaturaparticipantestatus_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteDataVisualizacao_Z" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteDataVisualizacao_Z"  , IsNullable=true )]
      public string gxTpr_Assinaturaparticipantedatavisualizacao_Z_Nullable
      {
         get {
            if ( gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedatavisualizacao_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedatavisualizacao_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedatavisualizacao_Z = DateTime.MinValue;
            else
               gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedatavisualizacao_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Assinaturaparticipantedatavisualizacao_Z
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedatavisualizacao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedatavisualizacao_Z = value;
            SetDirty("Assinaturaparticipantedatavisualizacao_Z");
         }

      }

      public void gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedatavisualizacao_Z_SetNull( )
      {
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedatavisualizacao_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Assinaturaparticipantedatavisualizacao_Z");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedatavisualizacao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteDataConclusao_Z" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteDataConclusao_Z"  , IsNullable=true )]
      public string gxTpr_Assinaturaparticipantedataconclusao_Z_Nullable
      {
         get {
            if ( gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedataconclusao_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedataconclusao_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedataconclusao_Z = DateTime.MinValue;
            else
               gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedataconclusao_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Assinaturaparticipantedataconclusao_Z
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedataconclusao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedataconclusao_Z = value;
            SetDirty("Assinaturaparticipantedataconclusao_Z");
         }

      }

      public void gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedataconclusao_Z_SetNull( )
      {
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedataconclusao_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Assinaturaparticipantedataconclusao_Z");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedataconclusao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteKey_Z" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteKey_Z"   )]
      public Guid gxTpr_Assinaturaparticipantekey_Z
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Assinaturaparticipantekey_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantekey_Z = value;
            SetDirty("Assinaturaparticipantekey_Z");
         }

      }

      public void gxTv_SdtAssinaturaParticipante_Assinaturaparticipantekey_Z_SetNull( )
      {
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantekey_Z = Guid.Empty;
         SetDirty("Assinaturaparticipantekey_Z");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipante_Assinaturaparticipantekey_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteTipo_Z" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteTipo_Z"   )]
      public string gxTpr_Assinaturaparticipantetipo_Z
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Assinaturaparticipantetipo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantetipo_Z = value;
            SetDirty("Assinaturaparticipantetipo_Z");
         }

      }

      public void gxTv_SdtAssinaturaParticipante_Assinaturaparticipantetipo_Z_SetNull( )
      {
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantetipo_Z = "";
         SetDirty("Assinaturaparticipantetipo_Z");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipante_Assinaturaparticipantetipo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteRemoteAddres_Z" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteRemoteAddres_Z"   )]
      public string gxTpr_Assinaturaparticipanteremoteaddres_Z
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteremoteaddres_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteremoteaddres_Z = value;
            SetDirty("Assinaturaparticipanteremoteaddres_Z");
         }

      }

      public void gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteremoteaddres_Z_SetNull( )
      {
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteremoteaddres_Z = "";
         SetDirty("Assinaturaparticipanteremoteaddres_Z");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteremoteaddres_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteGeolocalizacao_Z" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteGeolocalizacao_Z"   )]
      public string gxTpr_Assinaturaparticipantegeolocalizacao_Z
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Assinaturaparticipantegeolocalizacao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantegeolocalizacao_Z = value;
            SetDirty("Assinaturaparticipantegeolocalizacao_Z");
         }

      }

      public void gxTv_SdtAssinaturaParticipante_Assinaturaparticipantegeolocalizacao_Z_SetNull( )
      {
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantegeolocalizacao_Z = "";
         SetDirty("Assinaturaparticipantegeolocalizacao_Z");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipante_Assinaturaparticipantegeolocalizacao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteDispositivo_Z" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteDispositivo_Z"   )]
      public string gxTpr_Assinaturaparticipantedispositivo_Z
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedispositivo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedispositivo_Z = value;
            SetDirty("Assinaturaparticipantedispositivo_Z");
         }

      }

      public void gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedispositivo_Z_SetNull( )
      {
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedispositivo_Z = "";
         SetDirty("Assinaturaparticipantedispositivo_Z");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedispositivo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteCPF_Z" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteCPF_Z"   )]
      public string gxTpr_Assinaturaparticipantecpf_Z
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Assinaturaparticipantecpf_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantecpf_Z = value;
            SetDirty("Assinaturaparticipantecpf_Z");
         }

      }

      public void gxTv_SdtAssinaturaParticipante_Assinaturaparticipantecpf_Z_SetNull( )
      {
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantecpf_Z = "";
         SetDirty("Assinaturaparticipantecpf_Z");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipante_Assinaturaparticipantecpf_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteEmail_Z" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteEmail_Z"   )]
      public string gxTpr_Assinaturaparticipanteemail_Z
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteemail_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteemail_Z = value;
            SetDirty("Assinaturaparticipanteemail_Z");
         }

      }

      public void gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteemail_Z_SetNull( )
      {
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteemail_Z = "";
         SetDirty("Assinaturaparticipanteemail_Z");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteemail_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteNascimento_Z" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteNascimento_Z"  , IsNullable=true )]
      public string gxTpr_Assinaturaparticipantenascimento_Z_Nullable
      {
         get {
            if ( gxTv_SdtAssinaturaParticipante_Assinaturaparticipantenascimento_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtAssinaturaParticipante_Assinaturaparticipantenascimento_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtAssinaturaParticipante_Assinaturaparticipantenascimento_Z = DateTime.MinValue;
            else
               gxTv_SdtAssinaturaParticipante_Assinaturaparticipantenascimento_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Assinaturaparticipantenascimento_Z
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Assinaturaparticipantenascimento_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantenascimento_Z = value;
            SetDirty("Assinaturaparticipantenascimento_Z");
         }

      }

      public void gxTv_SdtAssinaturaParticipante_Assinaturaparticipantenascimento_Z_SetNull( )
      {
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantenascimento_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Assinaturaparticipantenascimento_Z");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipante_Assinaturaparticipantenascimento_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteLink_Z" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteLink_Z"   )]
      public string gxTpr_Assinaturaparticipantelink_Z
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Assinaturaparticipantelink_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantelink_Z = value;
            SetDirty("Assinaturaparticipantelink_Z");
         }

      }

      public void gxTv_SdtAssinaturaParticipante_Assinaturaparticipantelink_Z_SetNull( )
      {
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantelink_Z = "";
         SetDirty("Assinaturaparticipantelink_Z");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipante_Assinaturaparticipantelink_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteId_N" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteId_N"   )]
      public short gxTpr_Assinaturaparticipanteid_N
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteid_N = value;
            SetDirty("Assinaturaparticipanteid_N");
         }

      }

      public void gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteid_N_SetNull( )
      {
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteid_N = 0;
         SetDirty("Assinaturaparticipanteid_N");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaId_N" )]
      [  XmlElement( ElementName = "AssinaturaId_N"   )]
      public short gxTpr_Assinaturaid_N
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Assinaturaid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Assinaturaid_N = value;
            SetDirty("Assinaturaid_N");
         }

      }

      public void gxTv_SdtAssinaturaParticipante_Assinaturaid_N_SetNull( )
      {
         gxTv_SdtAssinaturaParticipante_Assinaturaid_N = 0;
         SetDirty("Assinaturaid_N");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipante_Assinaturaid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParticipanteId_N" )]
      [  XmlElement( ElementName = "ParticipanteId_N"   )]
      public short gxTpr_Participanteid_N
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Participanteid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Participanteid_N = value;
            SetDirty("Participanteid_N");
         }

      }

      public void gxTv_SdtAssinaturaParticipante_Participanteid_N_SetNull( )
      {
         gxTv_SdtAssinaturaParticipante_Participanteid_N = 0;
         SetDirty("Participanteid_N");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipante_Participanteid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteId_N" )]
      [  XmlElement( ElementName = "ClienteId_N"   )]
      public short gxTpr_Clienteid_N
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Clienteid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Clienteid_N = value;
            SetDirty("Clienteid_N");
         }

      }

      public void gxTv_SdtAssinaturaParticipante_Clienteid_N_SetNull( )
      {
         gxTv_SdtAssinaturaParticipante_Clienteid_N = 0;
         SetDirty("Clienteid_N");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipante_Clienteid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParticipanteNome_N" )]
      [  XmlElement( ElementName = "ParticipanteNome_N"   )]
      public short gxTpr_Participantenome_N
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Participantenome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Participantenome_N = value;
            SetDirty("Participantenome_N");
         }

      }

      public void gxTv_SdtAssinaturaParticipante_Participantenome_N_SetNull( )
      {
         gxTv_SdtAssinaturaParticipante_Participantenome_N = 0;
         SetDirty("Participantenome_N");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipante_Participantenome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParticipanteEmail_N" )]
      [  XmlElement( ElementName = "ParticipanteEmail_N"   )]
      public short gxTpr_Participanteemail_N
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Participanteemail_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Participanteemail_N = value;
            SetDirty("Participanteemail_N");
         }

      }

      public void gxTv_SdtAssinaturaParticipante_Participanteemail_N_SetNull( )
      {
         gxTv_SdtAssinaturaParticipante_Participanteemail_N = 0;
         SetDirty("Participanteemail_N");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipante_Participanteemail_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParticipanteDocumento_N" )]
      [  XmlElement( ElementName = "ParticipanteDocumento_N"   )]
      public short gxTpr_Participantedocumento_N
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Participantedocumento_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Participantedocumento_N = value;
            SetDirty("Participantedocumento_N");
         }

      }

      public void gxTv_SdtAssinaturaParticipante_Participantedocumento_N_SetNull( )
      {
         gxTv_SdtAssinaturaParticipante_Participantedocumento_N = 0;
         SetDirty("Participantedocumento_N");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipante_Participantedocumento_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteStatus_N" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteStatus_N"   )]
      public short gxTpr_Assinaturaparticipantestatus_N
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Assinaturaparticipantestatus_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantestatus_N = value;
            SetDirty("Assinaturaparticipantestatus_N");
         }

      }

      public void gxTv_SdtAssinaturaParticipante_Assinaturaparticipantestatus_N_SetNull( )
      {
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantestatus_N = 0;
         SetDirty("Assinaturaparticipantestatus_N");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipante_Assinaturaparticipantestatus_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteDataVisualizacao_N" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteDataVisualizacao_N"   )]
      public short gxTpr_Assinaturaparticipantedatavisualizacao_N
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedatavisualizacao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedatavisualizacao_N = value;
            SetDirty("Assinaturaparticipantedatavisualizacao_N");
         }

      }

      public void gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedatavisualizacao_N_SetNull( )
      {
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedatavisualizacao_N = 0;
         SetDirty("Assinaturaparticipantedatavisualizacao_N");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedatavisualizacao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteDataConclusao_N" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteDataConclusao_N"   )]
      public short gxTpr_Assinaturaparticipantedataconclusao_N
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedataconclusao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedataconclusao_N = value;
            SetDirty("Assinaturaparticipantedataconclusao_N");
         }

      }

      public void gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedataconclusao_N_SetNull( )
      {
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedataconclusao_N = 0;
         SetDirty("Assinaturaparticipantedataconclusao_N");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedataconclusao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteKey_N" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteKey_N"   )]
      public short gxTpr_Assinaturaparticipantekey_N
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Assinaturaparticipantekey_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantekey_N = value;
            SetDirty("Assinaturaparticipantekey_N");
         }

      }

      public void gxTv_SdtAssinaturaParticipante_Assinaturaparticipantekey_N_SetNull( )
      {
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantekey_N = 0;
         SetDirty("Assinaturaparticipantekey_N");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipante_Assinaturaparticipantekey_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteTipo_N" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteTipo_N"   )]
      public short gxTpr_Assinaturaparticipantetipo_N
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Assinaturaparticipantetipo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantetipo_N = value;
            SetDirty("Assinaturaparticipantetipo_N");
         }

      }

      public void gxTv_SdtAssinaturaParticipante_Assinaturaparticipantetipo_N_SetNull( )
      {
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantetipo_N = 0;
         SetDirty("Assinaturaparticipantetipo_N");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipante_Assinaturaparticipantetipo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteRemoteAddres_N" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteRemoteAddres_N"   )]
      public short gxTpr_Assinaturaparticipanteremoteaddres_N
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteremoteaddres_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteremoteaddres_N = value;
            SetDirty("Assinaturaparticipanteremoteaddres_N");
         }

      }

      public void gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteremoteaddres_N_SetNull( )
      {
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteremoteaddres_N = 0;
         SetDirty("Assinaturaparticipanteremoteaddres_N");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteremoteaddres_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteGeolocalizacao_N" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteGeolocalizacao_N"   )]
      public short gxTpr_Assinaturaparticipantegeolocalizacao_N
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Assinaturaparticipantegeolocalizacao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantegeolocalizacao_N = value;
            SetDirty("Assinaturaparticipantegeolocalizacao_N");
         }

      }

      public void gxTv_SdtAssinaturaParticipante_Assinaturaparticipantegeolocalizacao_N_SetNull( )
      {
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantegeolocalizacao_N = 0;
         SetDirty("Assinaturaparticipantegeolocalizacao_N");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipante_Assinaturaparticipantegeolocalizacao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteDispositivo_N" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteDispositivo_N"   )]
      public short gxTpr_Assinaturaparticipantedispositivo_N
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedispositivo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedispositivo_N = value;
            SetDirty("Assinaturaparticipantedispositivo_N");
         }

      }

      public void gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedispositivo_N_SetNull( )
      {
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedispositivo_N = 0;
         SetDirty("Assinaturaparticipantedispositivo_N");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedispositivo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteCPF_N" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteCPF_N"   )]
      public short gxTpr_Assinaturaparticipantecpf_N
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Assinaturaparticipantecpf_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantecpf_N = value;
            SetDirty("Assinaturaparticipantecpf_N");
         }

      }

      public void gxTv_SdtAssinaturaParticipante_Assinaturaparticipantecpf_N_SetNull( )
      {
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantecpf_N = 0;
         SetDirty("Assinaturaparticipantecpf_N");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipante_Assinaturaparticipantecpf_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteEmail_N" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteEmail_N"   )]
      public short gxTpr_Assinaturaparticipanteemail_N
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteemail_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteemail_N = value;
            SetDirty("Assinaturaparticipanteemail_N");
         }

      }

      public void gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteemail_N_SetNull( )
      {
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteemail_N = 0;
         SetDirty("Assinaturaparticipanteemail_N");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteemail_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteNascimento_N" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteNascimento_N"   )]
      public short gxTpr_Assinaturaparticipantenascimento_N
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Assinaturaparticipantenascimento_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantenascimento_N = value;
            SetDirty("Assinaturaparticipantenascimento_N");
         }

      }

      public void gxTv_SdtAssinaturaParticipante_Assinaturaparticipantenascimento_N_SetNull( )
      {
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantenascimento_N = 0;
         SetDirty("Assinaturaparticipantenascimento_N");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipante_Assinaturaparticipantenascimento_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteLink_N" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteLink_N"   )]
      public short gxTpr_Assinaturaparticipantelink_N
      {
         get {
            return gxTv_SdtAssinaturaParticipante_Assinaturaparticipantelink_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipante_Assinaturaparticipantelink_N = value;
            SetDirty("Assinaturaparticipantelink_N");
         }

      }

      public void gxTv_SdtAssinaturaParticipante_Assinaturaparticipantelink_N_SetNull( )
      {
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantelink_N = 0;
         SetDirty("Assinaturaparticipantelink_N");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipante_Assinaturaparticipantelink_N_IsNull( )
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
         gxTv_SdtAssinaturaParticipante_Participantenome = "";
         gxTv_SdtAssinaturaParticipante_Participanteemail = "";
         gxTv_SdtAssinaturaParticipante_Participantedocumento = "";
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantestatus = "";
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedatavisualizacao = (DateTime)(DateTime.MinValue);
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedataconclusao = (DateTime)(DateTime.MinValue);
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantekey = Guid.Empty;
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantetipo = "";
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteremoteaddres = "";
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantegeolocalizacao = "";
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedispositivo = "";
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantecpf = "";
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteemail = "";
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantenascimento = DateTime.MinValue;
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantelink = "";
         gxTv_SdtAssinaturaParticipante_Mode = "";
         gxTv_SdtAssinaturaParticipante_Participantenome_Z = "";
         gxTv_SdtAssinaturaParticipante_Participanteemail_Z = "";
         gxTv_SdtAssinaturaParticipante_Participantedocumento_Z = "";
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantestatus_Z = "";
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedatavisualizacao_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedataconclusao_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantekey_Z = Guid.Empty;
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantetipo_Z = "";
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteremoteaddres_Z = "";
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantegeolocalizacao_Z = "";
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedispositivo_Z = "";
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantecpf_Z = "";
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteemail_Z = "";
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantenascimento_Z = DateTime.MinValue;
         gxTv_SdtAssinaturaParticipante_Assinaturaparticipantelink_Z = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "assinaturaparticipante", "GeneXus.Programs.assinaturaparticipante_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtAssinaturaParticipante_Initialized ;
      private short gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteid_N ;
      private short gxTv_SdtAssinaturaParticipante_Assinaturaid_N ;
      private short gxTv_SdtAssinaturaParticipante_Participanteid_N ;
      private short gxTv_SdtAssinaturaParticipante_Clienteid_N ;
      private short gxTv_SdtAssinaturaParticipante_Participantenome_N ;
      private short gxTv_SdtAssinaturaParticipante_Participanteemail_N ;
      private short gxTv_SdtAssinaturaParticipante_Participantedocumento_N ;
      private short gxTv_SdtAssinaturaParticipante_Assinaturaparticipantestatus_N ;
      private short gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedatavisualizacao_N ;
      private short gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedataconclusao_N ;
      private short gxTv_SdtAssinaturaParticipante_Assinaturaparticipantekey_N ;
      private short gxTv_SdtAssinaturaParticipante_Assinaturaparticipantetipo_N ;
      private short gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteremoteaddres_N ;
      private short gxTv_SdtAssinaturaParticipante_Assinaturaparticipantegeolocalizacao_N ;
      private short gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedispositivo_N ;
      private short gxTv_SdtAssinaturaParticipante_Assinaturaparticipantecpf_N ;
      private short gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteemail_N ;
      private short gxTv_SdtAssinaturaParticipante_Assinaturaparticipantenascimento_N ;
      private short gxTv_SdtAssinaturaParticipante_Assinaturaparticipantelink_N ;
      private int gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteid ;
      private int gxTv_SdtAssinaturaParticipante_Participanteid ;
      private int gxTv_SdtAssinaturaParticipante_Clienteid ;
      private int gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteid_Z ;
      private int gxTv_SdtAssinaturaParticipante_Participanteid_Z ;
      private int gxTv_SdtAssinaturaParticipante_Clienteid_Z ;
      private long gxTv_SdtAssinaturaParticipante_Assinaturaid ;
      private long gxTv_SdtAssinaturaParticipante_Assinaturaid_Z ;
      private string gxTv_SdtAssinaturaParticipante_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedatavisualizacao ;
      private DateTime gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedataconclusao ;
      private DateTime gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedatavisualizacao_Z ;
      private DateTime gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedataconclusao_Z ;
      private DateTime datetime_STZ ;
      private DateTime gxTv_SdtAssinaturaParticipante_Assinaturaparticipantenascimento ;
      private DateTime gxTv_SdtAssinaturaParticipante_Assinaturaparticipantenascimento_Z ;
      private string gxTv_SdtAssinaturaParticipante_Participantenome ;
      private string gxTv_SdtAssinaturaParticipante_Participanteemail ;
      private string gxTv_SdtAssinaturaParticipante_Participantedocumento ;
      private string gxTv_SdtAssinaturaParticipante_Assinaturaparticipantestatus ;
      private string gxTv_SdtAssinaturaParticipante_Assinaturaparticipantetipo ;
      private string gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteremoteaddres ;
      private string gxTv_SdtAssinaturaParticipante_Assinaturaparticipantegeolocalizacao ;
      private string gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedispositivo ;
      private string gxTv_SdtAssinaturaParticipante_Assinaturaparticipantecpf ;
      private string gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteemail ;
      private string gxTv_SdtAssinaturaParticipante_Assinaturaparticipantelink ;
      private string gxTv_SdtAssinaturaParticipante_Participantenome_Z ;
      private string gxTv_SdtAssinaturaParticipante_Participanteemail_Z ;
      private string gxTv_SdtAssinaturaParticipante_Participantedocumento_Z ;
      private string gxTv_SdtAssinaturaParticipante_Assinaturaparticipantestatus_Z ;
      private string gxTv_SdtAssinaturaParticipante_Assinaturaparticipantetipo_Z ;
      private string gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteremoteaddres_Z ;
      private string gxTv_SdtAssinaturaParticipante_Assinaturaparticipantegeolocalizacao_Z ;
      private string gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedispositivo_Z ;
      private string gxTv_SdtAssinaturaParticipante_Assinaturaparticipantecpf_Z ;
      private string gxTv_SdtAssinaturaParticipante_Assinaturaparticipanteemail_Z ;
      private string gxTv_SdtAssinaturaParticipante_Assinaturaparticipantelink_Z ;
      private Guid gxTv_SdtAssinaturaParticipante_Assinaturaparticipantekey ;
      private Guid gxTv_SdtAssinaturaParticipante_Assinaturaparticipantekey_Z ;
   }

   [DataContract(Name = @"AssinaturaParticipante", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtAssinaturaParticipante_RESTInterface : GxGenericCollectionItem<SdtAssinaturaParticipante>
   {
      public SdtAssinaturaParticipante_RESTInterface( ) : base()
      {
      }

      public SdtAssinaturaParticipante_RESTInterface( SdtAssinaturaParticipante psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "AssinaturaParticipanteId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Assinaturaparticipanteid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Assinaturaparticipanteid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Assinaturaparticipanteid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "AssinaturaId" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Assinaturaid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Assinaturaid), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Assinaturaid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ParticipanteId" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Participanteid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Participanteid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Participanteid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ClienteId" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Clienteid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Clienteid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Clienteid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ParticipanteNome" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Participantenome
      {
         get {
            return sdt.gxTpr_Participantenome ;
         }

         set {
            sdt.gxTpr_Participantenome = value;
         }

      }

      [DataMember( Name = "ParticipanteEmail" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Participanteemail
      {
         get {
            return sdt.gxTpr_Participanteemail ;
         }

         set {
            sdt.gxTpr_Participanteemail = value;
         }

      }

      [DataMember( Name = "ParticipanteDocumento" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Participantedocumento
      {
         get {
            return sdt.gxTpr_Participantedocumento ;
         }

         set {
            sdt.gxTpr_Participantedocumento = value;
         }

      }

      [DataMember( Name = "AssinaturaParticipanteStatus" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Assinaturaparticipantestatus
      {
         get {
            return sdt.gxTpr_Assinaturaparticipantestatus ;
         }

         set {
            sdt.gxTpr_Assinaturaparticipantestatus = value;
         }

      }

      [DataMember( Name = "AssinaturaParticipanteDataVisualizacao" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Assinaturaparticipantedatavisualizacao
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Assinaturaparticipantedatavisualizacao, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Assinaturaparticipantedatavisualizacao = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "AssinaturaParticipanteDataConclusao" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Assinaturaparticipantedataconclusao
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Assinaturaparticipantedataconclusao, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Assinaturaparticipantedataconclusao = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "AssinaturaParticipanteKey" , Order = 10 )]
      [GxSeudo()]
      public Guid gxTpr_Assinaturaparticipantekey
      {
         get {
            return sdt.gxTpr_Assinaturaparticipantekey ;
         }

         set {
            sdt.gxTpr_Assinaturaparticipantekey = value;
         }

      }

      [DataMember( Name = "AssinaturaParticipanteTipo" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Assinaturaparticipantetipo
      {
         get {
            return sdt.gxTpr_Assinaturaparticipantetipo ;
         }

         set {
            sdt.gxTpr_Assinaturaparticipantetipo = value;
         }

      }

      [DataMember( Name = "AssinaturaParticipanteRemoteAddres" , Order = 12 )]
      [GxSeudo()]
      public string gxTpr_Assinaturaparticipanteremoteaddres
      {
         get {
            return sdt.gxTpr_Assinaturaparticipanteremoteaddres ;
         }

         set {
            sdt.gxTpr_Assinaturaparticipanteremoteaddres = value;
         }

      }

      [DataMember( Name = "AssinaturaParticipanteGeolocalizacao" , Order = 13 )]
      [GxSeudo()]
      public string gxTpr_Assinaturaparticipantegeolocalizacao
      {
         get {
            return sdt.gxTpr_Assinaturaparticipantegeolocalizacao ;
         }

         set {
            sdt.gxTpr_Assinaturaparticipantegeolocalizacao = value;
         }

      }

      [DataMember( Name = "AssinaturaParticipanteDispositivo" , Order = 14 )]
      [GxSeudo()]
      public string gxTpr_Assinaturaparticipantedispositivo
      {
         get {
            return sdt.gxTpr_Assinaturaparticipantedispositivo ;
         }

         set {
            sdt.gxTpr_Assinaturaparticipantedispositivo = value;
         }

      }

      [DataMember( Name = "AssinaturaParticipanteCPF" , Order = 15 )]
      [GxSeudo()]
      public string gxTpr_Assinaturaparticipantecpf
      {
         get {
            return sdt.gxTpr_Assinaturaparticipantecpf ;
         }

         set {
            sdt.gxTpr_Assinaturaparticipantecpf = value;
         }

      }

      [DataMember( Name = "AssinaturaParticipanteEmail" , Order = 16 )]
      [GxSeudo()]
      public string gxTpr_Assinaturaparticipanteemail
      {
         get {
            return sdt.gxTpr_Assinaturaparticipanteemail ;
         }

         set {
            sdt.gxTpr_Assinaturaparticipanteemail = value;
         }

      }

      [DataMember( Name = "AssinaturaParticipanteNascimento" , Order = 17 )]
      [GxSeudo()]
      public string gxTpr_Assinaturaparticipantenascimento
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Assinaturaparticipantenascimento) ;
         }

         set {
            sdt.gxTpr_Assinaturaparticipantenascimento = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "AssinaturaParticipanteLink" , Order = 18 )]
      [GxSeudo()]
      public string gxTpr_Assinaturaparticipantelink
      {
         get {
            return sdt.gxTpr_Assinaturaparticipantelink ;
         }

         set {
            sdt.gxTpr_Assinaturaparticipantelink = value;
         }

      }

      public SdtAssinaturaParticipante sdt
      {
         get {
            return (SdtAssinaturaParticipante)Sdt ;
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
            sdt = new SdtAssinaturaParticipante() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 19 )]
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

   [DataContract(Name = @"AssinaturaParticipante", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtAssinaturaParticipante_RESTLInterface : GxGenericCollectionItem<SdtAssinaturaParticipante>
   {
      public SdtAssinaturaParticipante_RESTLInterface( ) : base()
      {
      }

      public SdtAssinaturaParticipante_RESTLInterface( SdtAssinaturaParticipante psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "AssinaturaParticipanteStatus" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Assinaturaparticipantestatus
      {
         get {
            return sdt.gxTpr_Assinaturaparticipantestatus ;
         }

         set {
            sdt.gxTpr_Assinaturaparticipantestatus = value;
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

      public SdtAssinaturaParticipante sdt
      {
         get {
            return (SdtAssinaturaParticipante)Sdt ;
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
            sdt = new SdtAssinaturaParticipante() ;
         }
      }

   }

}
