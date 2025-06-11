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
   [XmlRoot(ElementName = "NotificacaoAgendadaProcessamento" )]
   [XmlType(TypeName =  "NotificacaoAgendadaProcessamento" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtNotificacaoAgendadaProcessamento : GxSilentTrnSdt
   {
      public SdtNotificacaoAgendadaProcessamento( )
      {
      }

      public SdtNotificacaoAgendadaProcessamento( IGxContext context )
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

      public void Load( Guid AV908NotificacaoAgendadaProcessamentoId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV908NotificacaoAgendadaProcessamentoId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"NotificacaoAgendadaProcessamentoId", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "NotificacaoAgendadaProcessamento");
         metadata.Set("BT", "NotificacaoAgendadaProcessamento");
         metadata.Set("PK", "[ \"NotificacaoAgendadaProcessamentoId\" ]");
         metadata.Set("PKAssigned", "[ \"NotificacaoAgendadaProcessamentoId\" ]");
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
         state.Add("gxTpr_Notificacaoagendadaprocessamentoid_Z");
         state.Add("gxTpr_Notificacaoagendadaprocessamentoinicio_Z_Nullable");
         state.Add("gxTpr_Notificacaoagendadaprocessamentofim_Z_Nullable");
         state.Add("gxTpr_Notificacaoagendadaprocessamentoqtdexec_Z");
         state.Add("gxTpr_Notificacaoagendadaprocessamentoqtdsucesso_Z");
         state.Add("gxTpr_Notificacaoagendadaprocessamentoqtdfalhas_Z");
         state.Add("gxTpr_Notificacaoagendadaprocessamentosituacao_Z");
         state.Add("gxTpr_Notificacaoagendadaprocessamentoinicio_N");
         state.Add("gxTpr_Notificacaoagendadaprocessamentofim_N");
         state.Add("gxTpr_Notificacaoagendadaprocessamentoqtdexec_N");
         state.Add("gxTpr_Notificacaoagendadaprocessamentoqtdsucesso_N");
         state.Add("gxTpr_Notificacaoagendadaprocessamentoqtdfalhas_N");
         state.Add("gxTpr_Notificacaoagendadaprocessamentosituacao_N");
         state.Add("gxTpr_Notificacaoagendadaprocessamentomensagemerro_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtNotificacaoAgendadaProcessamento sdt;
         sdt = (SdtNotificacaoAgendadaProcessamento)(source);
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoid = sdt.gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoid ;
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoinicio = sdt.gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoinicio ;
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentofim = sdt.gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentofim ;
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdexec = sdt.gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdexec ;
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdsucesso = sdt.gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdsucesso ;
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdfalhas = sdt.gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdfalhas ;
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentosituacao = sdt.gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentosituacao ;
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentomensagemerro = sdt.gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentomensagemerro ;
         gxTv_SdtNotificacaoAgendadaProcessamento_Mode = sdt.gxTv_SdtNotificacaoAgendadaProcessamento_Mode ;
         gxTv_SdtNotificacaoAgendadaProcessamento_Initialized = sdt.gxTv_SdtNotificacaoAgendadaProcessamento_Initialized ;
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoid_Z = sdt.gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoid_Z ;
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoinicio_Z = sdt.gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoinicio_Z ;
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentofim_Z = sdt.gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentofim_Z ;
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdexec_Z = sdt.gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdexec_Z ;
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdsucesso_Z = sdt.gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdsucesso_Z ;
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdfalhas_Z = sdt.gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdfalhas_Z ;
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentosituacao_Z = sdt.gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentosituacao_Z ;
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoinicio_N = sdt.gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoinicio_N ;
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentofim_N = sdt.gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentofim_N ;
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdexec_N = sdt.gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdexec_N ;
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdsucesso_N = sdt.gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdsucesso_N ;
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdfalhas_N = sdt.gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdfalhas_N ;
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentosituacao_N = sdt.gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentosituacao_N ;
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentomensagemerro_N = sdt.gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentomensagemerro_N ;
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
         AddObjectProperty("NotificacaoAgendadaProcessamentoId", gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoid, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoinicio;
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
         AddObjectProperty("NotificacaoAgendadaProcessamentoInicio", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("NotificacaoAgendadaProcessamentoInicio_N", gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoinicio_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentofim;
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
         AddObjectProperty("NotificacaoAgendadaProcessamentoFim", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("NotificacaoAgendadaProcessamentoFim_N", gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentofim_N, false, includeNonInitialized);
         AddObjectProperty("NotificacaoAgendadaProcessamentoQtdExec", gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdexec, false, includeNonInitialized);
         AddObjectProperty("NotificacaoAgendadaProcessamentoQtdExec_N", gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdexec_N, false, includeNonInitialized);
         AddObjectProperty("NotificacaoAgendadaProcessamentoQtdSucesso", gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdsucesso, false, includeNonInitialized);
         AddObjectProperty("NotificacaoAgendadaProcessamentoQtdSucesso_N", gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdsucesso_N, false, includeNonInitialized);
         AddObjectProperty("NotificacaoAgendadaProcessamentoQtdFalhas", gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdfalhas, false, includeNonInitialized);
         AddObjectProperty("NotificacaoAgendadaProcessamentoQtdFalhas_N", gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdfalhas_N, false, includeNonInitialized);
         AddObjectProperty("NotificacaoAgendadaProcessamentoSituacao", gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentosituacao, false, includeNonInitialized);
         AddObjectProperty("NotificacaoAgendadaProcessamentoSituacao_N", gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentosituacao_N, false, includeNonInitialized);
         AddObjectProperty("NotificacaoAgendadaProcessamentoMensagemErro", gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentomensagemerro, false, includeNonInitialized);
         AddObjectProperty("NotificacaoAgendadaProcessamentoMensagemErro_N", gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentomensagemerro_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtNotificacaoAgendadaProcessamento_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtNotificacaoAgendadaProcessamento_Initialized, false, includeNonInitialized);
            AddObjectProperty("NotificacaoAgendadaProcessamentoId_Z", gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoid_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoinicio_Z;
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
            AddObjectProperty("NotificacaoAgendadaProcessamentoInicio_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentofim_Z;
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
            AddObjectProperty("NotificacaoAgendadaProcessamentoFim_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("NotificacaoAgendadaProcessamentoQtdExec_Z", gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdexec_Z, false, includeNonInitialized);
            AddObjectProperty("NotificacaoAgendadaProcessamentoQtdSucesso_Z", gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdsucesso_Z, false, includeNonInitialized);
            AddObjectProperty("NotificacaoAgendadaProcessamentoQtdFalhas_Z", gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdfalhas_Z, false, includeNonInitialized);
            AddObjectProperty("NotificacaoAgendadaProcessamentoSituacao_Z", gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentosituacao_Z, false, includeNonInitialized);
            AddObjectProperty("NotificacaoAgendadaProcessamentoInicio_N", gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoinicio_N, false, includeNonInitialized);
            AddObjectProperty("NotificacaoAgendadaProcessamentoFim_N", gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentofim_N, false, includeNonInitialized);
            AddObjectProperty("NotificacaoAgendadaProcessamentoQtdExec_N", gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdexec_N, false, includeNonInitialized);
            AddObjectProperty("NotificacaoAgendadaProcessamentoQtdSucesso_N", gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdsucesso_N, false, includeNonInitialized);
            AddObjectProperty("NotificacaoAgendadaProcessamentoQtdFalhas_N", gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdfalhas_N, false, includeNonInitialized);
            AddObjectProperty("NotificacaoAgendadaProcessamentoSituacao_N", gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentosituacao_N, false, includeNonInitialized);
            AddObjectProperty("NotificacaoAgendadaProcessamentoMensagemErro_N", gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentomensagemerro_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtNotificacaoAgendadaProcessamento sdt )
      {
         if ( sdt.IsDirty("NotificacaoAgendadaProcessamentoId") )
         {
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoid = sdt.gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoid ;
         }
         if ( sdt.IsDirty("NotificacaoAgendadaProcessamentoInicio") )
         {
            gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoinicio_N = (short)(sdt.gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoinicio_N);
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoinicio = sdt.gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoinicio ;
         }
         if ( sdt.IsDirty("NotificacaoAgendadaProcessamentoFim") )
         {
            gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentofim_N = (short)(sdt.gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentofim_N);
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentofim = sdt.gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentofim ;
         }
         if ( sdt.IsDirty("NotificacaoAgendadaProcessamentoQtdExec") )
         {
            gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdexec_N = (short)(sdt.gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdexec_N);
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdexec = sdt.gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdexec ;
         }
         if ( sdt.IsDirty("NotificacaoAgendadaProcessamentoQtdSucesso") )
         {
            gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdsucesso_N = (short)(sdt.gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdsucesso_N);
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdsucesso = sdt.gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdsucesso ;
         }
         if ( sdt.IsDirty("NotificacaoAgendadaProcessamentoQtdFalhas") )
         {
            gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdfalhas_N = (short)(sdt.gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdfalhas_N);
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdfalhas = sdt.gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdfalhas ;
         }
         if ( sdt.IsDirty("NotificacaoAgendadaProcessamentoSituacao") )
         {
            gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentosituacao_N = (short)(sdt.gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentosituacao_N);
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentosituacao = sdt.gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentosituacao ;
         }
         if ( sdt.IsDirty("NotificacaoAgendadaProcessamentoMensagemErro") )
         {
            gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentomensagemerro_N = (short)(sdt.gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentomensagemerro_N);
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentomensagemerro = sdt.gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentomensagemerro ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "NotificacaoAgendadaProcessamentoId" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaProcessamentoId"   )]
      public Guid gxTpr_Notificacaoagendadaprocessamentoid
      {
         get {
            return gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoid != value )
            {
               gxTv_SdtNotificacaoAgendadaProcessamento_Mode = "INS";
               this.gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoid_Z_SetNull( );
               this.gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoinicio_Z_SetNull( );
               this.gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentofim_Z_SetNull( );
               this.gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdexec_Z_SetNull( );
               this.gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdsucesso_Z_SetNull( );
               this.gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdfalhas_Z_SetNull( );
               this.gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentosituacao_Z_SetNull( );
            }
            gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoid = value;
            SetDirty("Notificacaoagendadaprocessamentoid");
         }

      }

      [  SoapElement( ElementName = "NotificacaoAgendadaProcessamentoInicio" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaProcessamentoInicio"  , IsNullable=true )]
      public string gxTpr_Notificacaoagendadaprocessamentoinicio_Nullable
      {
         get {
            if ( gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoinicio == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoinicio).value ;
         }

         set {
            gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoinicio_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoinicio = DateTime.MinValue;
            else
               gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoinicio = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Notificacaoagendadaprocessamentoinicio
      {
         get {
            return gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoinicio ;
         }

         set {
            gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoinicio_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoinicio = value;
            SetDirty("Notificacaoagendadaprocessamentoinicio");
         }

      }

      public void gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoinicio_SetNull( )
      {
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoinicio_N = 1;
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoinicio = (DateTime)(DateTime.MinValue);
         SetDirty("Notificacaoagendadaprocessamentoinicio");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoinicio_IsNull( )
      {
         return (gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoinicio_N==1) ;
      }

      [  SoapElement( ElementName = "NotificacaoAgendadaProcessamentoFim" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaProcessamentoFim"  , IsNullable=true )]
      public string gxTpr_Notificacaoagendadaprocessamentofim_Nullable
      {
         get {
            if ( gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentofim == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentofim).value ;
         }

         set {
            gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentofim_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentofim = DateTime.MinValue;
            else
               gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentofim = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Notificacaoagendadaprocessamentofim
      {
         get {
            return gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentofim ;
         }

         set {
            gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentofim_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentofim = value;
            SetDirty("Notificacaoagendadaprocessamentofim");
         }

      }

      public void gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentofim_SetNull( )
      {
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentofim_N = 1;
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentofim = (DateTime)(DateTime.MinValue);
         SetDirty("Notificacaoagendadaprocessamentofim");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentofim_IsNull( )
      {
         return (gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentofim_N==1) ;
      }

      [  SoapElement( ElementName = "NotificacaoAgendadaProcessamentoQtdExec" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaProcessamentoQtdExec"   )]
      public int gxTpr_Notificacaoagendadaprocessamentoqtdexec
      {
         get {
            return gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdexec ;
         }

         set {
            gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdexec_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdexec = value;
            SetDirty("Notificacaoagendadaprocessamentoqtdexec");
         }

      }

      public void gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdexec_SetNull( )
      {
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdexec_N = 1;
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdexec = 0;
         SetDirty("Notificacaoagendadaprocessamentoqtdexec");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdexec_IsNull( )
      {
         return (gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdexec_N==1) ;
      }

      [  SoapElement( ElementName = "NotificacaoAgendadaProcessamentoQtdSucesso" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaProcessamentoQtdSucesso"   )]
      public short gxTpr_Notificacaoagendadaprocessamentoqtdsucesso
      {
         get {
            return gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdsucesso ;
         }

         set {
            gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdsucesso_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdsucesso = value;
            SetDirty("Notificacaoagendadaprocessamentoqtdsucesso");
         }

      }

      public void gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdsucesso_SetNull( )
      {
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdsucesso_N = 1;
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdsucesso = 0;
         SetDirty("Notificacaoagendadaprocessamentoqtdsucesso");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdsucesso_IsNull( )
      {
         return (gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdsucesso_N==1) ;
      }

      [  SoapElement( ElementName = "NotificacaoAgendadaProcessamentoQtdFalhas" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaProcessamentoQtdFalhas"   )]
      public short gxTpr_Notificacaoagendadaprocessamentoqtdfalhas
      {
         get {
            return gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdfalhas ;
         }

         set {
            gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdfalhas_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdfalhas = value;
            SetDirty("Notificacaoagendadaprocessamentoqtdfalhas");
         }

      }

      public void gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdfalhas_SetNull( )
      {
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdfalhas_N = 1;
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdfalhas = 0;
         SetDirty("Notificacaoagendadaprocessamentoqtdfalhas");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdfalhas_IsNull( )
      {
         return (gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdfalhas_N==1) ;
      }

      [  SoapElement( ElementName = "NotificacaoAgendadaProcessamentoSituacao" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaProcessamentoSituacao"   )]
      public string gxTpr_Notificacaoagendadaprocessamentosituacao
      {
         get {
            return gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentosituacao ;
         }

         set {
            gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentosituacao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentosituacao = value;
            SetDirty("Notificacaoagendadaprocessamentosituacao");
         }

      }

      public void gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentosituacao_SetNull( )
      {
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentosituacao_N = 1;
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentosituacao = "";
         SetDirty("Notificacaoagendadaprocessamentosituacao");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentosituacao_IsNull( )
      {
         return (gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentosituacao_N==1) ;
      }

      [  SoapElement( ElementName = "NotificacaoAgendadaProcessamentoMensagemErro" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaProcessamentoMensagemErro"   )]
      public string gxTpr_Notificacaoagendadaprocessamentomensagemerro
      {
         get {
            return gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentomensagemerro ;
         }

         set {
            gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentomensagemerro_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentomensagemerro = value;
            SetDirty("Notificacaoagendadaprocessamentomensagemerro");
         }

      }

      public void gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentomensagemerro_SetNull( )
      {
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentomensagemerro_N = 1;
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentomensagemerro = "";
         SetDirty("Notificacaoagendadaprocessamentomensagemerro");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentomensagemerro_IsNull( )
      {
         return (gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentomensagemerro_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtNotificacaoAgendadaProcessamento_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendadaProcessamento_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtNotificacaoAgendadaProcessamento_Mode_SetNull( )
      {
         gxTv_SdtNotificacaoAgendadaProcessamento_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendadaProcessamento_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtNotificacaoAgendadaProcessamento_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendadaProcessamento_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtNotificacaoAgendadaProcessamento_Initialized_SetNull( )
      {
         gxTv_SdtNotificacaoAgendadaProcessamento_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendadaProcessamento_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotificacaoAgendadaProcessamentoId_Z" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaProcessamentoId_Z"   )]
      public Guid gxTpr_Notificacaoagendadaprocessamentoid_Z
      {
         get {
            return gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoid_Z = value;
            SetDirty("Notificacaoagendadaprocessamentoid_Z");
         }

      }

      public void gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoid_Z_SetNull( )
      {
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoid_Z = Guid.Empty;
         SetDirty("Notificacaoagendadaprocessamentoid_Z");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotificacaoAgendadaProcessamentoInicio_Z" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaProcessamentoInicio_Z"  , IsNullable=true )]
      public string gxTpr_Notificacaoagendadaprocessamentoinicio_Z_Nullable
      {
         get {
            if ( gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoinicio_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoinicio_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoinicio_Z = DateTime.MinValue;
            else
               gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoinicio_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Notificacaoagendadaprocessamentoinicio_Z
      {
         get {
            return gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoinicio_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoinicio_Z = value;
            SetDirty("Notificacaoagendadaprocessamentoinicio_Z");
         }

      }

      public void gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoinicio_Z_SetNull( )
      {
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoinicio_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Notificacaoagendadaprocessamentoinicio_Z");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoinicio_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotificacaoAgendadaProcessamentoFim_Z" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaProcessamentoFim_Z"  , IsNullable=true )]
      public string gxTpr_Notificacaoagendadaprocessamentofim_Z_Nullable
      {
         get {
            if ( gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentofim_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentofim_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentofim_Z = DateTime.MinValue;
            else
               gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentofim_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Notificacaoagendadaprocessamentofim_Z
      {
         get {
            return gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentofim_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentofim_Z = value;
            SetDirty("Notificacaoagendadaprocessamentofim_Z");
         }

      }

      public void gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentofim_Z_SetNull( )
      {
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentofim_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Notificacaoagendadaprocessamentofim_Z");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentofim_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotificacaoAgendadaProcessamentoQtdExec_Z" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaProcessamentoQtdExec_Z"   )]
      public int gxTpr_Notificacaoagendadaprocessamentoqtdexec_Z
      {
         get {
            return gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdexec_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdexec_Z = value;
            SetDirty("Notificacaoagendadaprocessamentoqtdexec_Z");
         }

      }

      public void gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdexec_Z_SetNull( )
      {
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdexec_Z = 0;
         SetDirty("Notificacaoagendadaprocessamentoqtdexec_Z");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdexec_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotificacaoAgendadaProcessamentoQtdSucesso_Z" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaProcessamentoQtdSucesso_Z"   )]
      public short gxTpr_Notificacaoagendadaprocessamentoqtdsucesso_Z
      {
         get {
            return gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdsucesso_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdsucesso_Z = value;
            SetDirty("Notificacaoagendadaprocessamentoqtdsucesso_Z");
         }

      }

      public void gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdsucesso_Z_SetNull( )
      {
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdsucesso_Z = 0;
         SetDirty("Notificacaoagendadaprocessamentoqtdsucesso_Z");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdsucesso_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotificacaoAgendadaProcessamentoQtdFalhas_Z" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaProcessamentoQtdFalhas_Z"   )]
      public short gxTpr_Notificacaoagendadaprocessamentoqtdfalhas_Z
      {
         get {
            return gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdfalhas_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdfalhas_Z = value;
            SetDirty("Notificacaoagendadaprocessamentoqtdfalhas_Z");
         }

      }

      public void gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdfalhas_Z_SetNull( )
      {
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdfalhas_Z = 0;
         SetDirty("Notificacaoagendadaprocessamentoqtdfalhas_Z");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdfalhas_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotificacaoAgendadaProcessamentoSituacao_Z" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaProcessamentoSituacao_Z"   )]
      public string gxTpr_Notificacaoagendadaprocessamentosituacao_Z
      {
         get {
            return gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentosituacao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentosituacao_Z = value;
            SetDirty("Notificacaoagendadaprocessamentosituacao_Z");
         }

      }

      public void gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentosituacao_Z_SetNull( )
      {
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentosituacao_Z = "";
         SetDirty("Notificacaoagendadaprocessamentosituacao_Z");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentosituacao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotificacaoAgendadaProcessamentoInicio_N" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaProcessamentoInicio_N"   )]
      public short gxTpr_Notificacaoagendadaprocessamentoinicio_N
      {
         get {
            return gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoinicio_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoinicio_N = value;
            SetDirty("Notificacaoagendadaprocessamentoinicio_N");
         }

      }

      public void gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoinicio_N_SetNull( )
      {
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoinicio_N = 0;
         SetDirty("Notificacaoagendadaprocessamentoinicio_N");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoinicio_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotificacaoAgendadaProcessamentoFim_N" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaProcessamentoFim_N"   )]
      public short gxTpr_Notificacaoagendadaprocessamentofim_N
      {
         get {
            return gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentofim_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentofim_N = value;
            SetDirty("Notificacaoagendadaprocessamentofim_N");
         }

      }

      public void gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentofim_N_SetNull( )
      {
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentofim_N = 0;
         SetDirty("Notificacaoagendadaprocessamentofim_N");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentofim_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotificacaoAgendadaProcessamentoQtdExec_N" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaProcessamentoQtdExec_N"   )]
      public short gxTpr_Notificacaoagendadaprocessamentoqtdexec_N
      {
         get {
            return gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdexec_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdexec_N = value;
            SetDirty("Notificacaoagendadaprocessamentoqtdexec_N");
         }

      }

      public void gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdexec_N_SetNull( )
      {
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdexec_N = 0;
         SetDirty("Notificacaoagendadaprocessamentoqtdexec_N");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdexec_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotificacaoAgendadaProcessamentoQtdSucesso_N" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaProcessamentoQtdSucesso_N"   )]
      public short gxTpr_Notificacaoagendadaprocessamentoqtdsucesso_N
      {
         get {
            return gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdsucesso_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdsucesso_N = value;
            SetDirty("Notificacaoagendadaprocessamentoqtdsucesso_N");
         }

      }

      public void gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdsucesso_N_SetNull( )
      {
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdsucesso_N = 0;
         SetDirty("Notificacaoagendadaprocessamentoqtdsucesso_N");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdsucesso_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotificacaoAgendadaProcessamentoQtdFalhas_N" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaProcessamentoQtdFalhas_N"   )]
      public short gxTpr_Notificacaoagendadaprocessamentoqtdfalhas_N
      {
         get {
            return gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdfalhas_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdfalhas_N = value;
            SetDirty("Notificacaoagendadaprocessamentoqtdfalhas_N");
         }

      }

      public void gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdfalhas_N_SetNull( )
      {
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdfalhas_N = 0;
         SetDirty("Notificacaoagendadaprocessamentoqtdfalhas_N");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdfalhas_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotificacaoAgendadaProcessamentoSituacao_N" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaProcessamentoSituacao_N"   )]
      public short gxTpr_Notificacaoagendadaprocessamentosituacao_N
      {
         get {
            return gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentosituacao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentosituacao_N = value;
            SetDirty("Notificacaoagendadaprocessamentosituacao_N");
         }

      }

      public void gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentosituacao_N_SetNull( )
      {
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentosituacao_N = 0;
         SetDirty("Notificacaoagendadaprocessamentosituacao_N");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentosituacao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotificacaoAgendadaProcessamentoMensagemErro_N" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaProcessamentoMensagemErro_N"   )]
      public short gxTpr_Notificacaoagendadaprocessamentomensagemerro_N
      {
         get {
            return gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentomensagemerro_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentomensagemerro_N = value;
            SetDirty("Notificacaoagendadaprocessamentomensagemerro_N");
         }

      }

      public void gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentomensagemerro_N_SetNull( )
      {
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentomensagemerro_N = 0;
         SetDirty("Notificacaoagendadaprocessamentomensagemerro_N");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentomensagemerro_N_IsNull( )
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
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoinicio = (DateTime)(DateTime.MinValue);
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentofim = (DateTime)(DateTime.MinValue);
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentosituacao = "";
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentomensagemerro = "";
         gxTv_SdtNotificacaoAgendadaProcessamento_Mode = "";
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoid_Z = Guid.Empty;
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoinicio_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentofim_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentosituacao_Z = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "notificacaoagendadaprocessamento", "GeneXus.Programs.notificacaoagendadaprocessamento_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdsucesso ;
      private short gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdfalhas ;
      private short gxTv_SdtNotificacaoAgendadaProcessamento_Initialized ;
      private short gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdsucesso_Z ;
      private short gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdfalhas_Z ;
      private short gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoinicio_N ;
      private short gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentofim_N ;
      private short gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdexec_N ;
      private short gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdsucesso_N ;
      private short gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdfalhas_N ;
      private short gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentosituacao_N ;
      private short gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentomensagemerro_N ;
      private int gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdexec ;
      private int gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoqtdexec_Z ;
      private string gxTv_SdtNotificacaoAgendadaProcessamento_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoinicio ;
      private DateTime gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentofim ;
      private DateTime gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoinicio_Z ;
      private DateTime gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentofim_Z ;
      private DateTime datetime_STZ ;
      private string gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentomensagemerro ;
      private string gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentosituacao ;
      private string gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentosituacao_Z ;
      private Guid gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoid ;
      private Guid gxTv_SdtNotificacaoAgendadaProcessamento_Notificacaoagendadaprocessamentoid_Z ;
   }

   [DataContract(Name = @"NotificacaoAgendadaProcessamento", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtNotificacaoAgendadaProcessamento_RESTInterface : GxGenericCollectionItem<SdtNotificacaoAgendadaProcessamento>
   {
      public SdtNotificacaoAgendadaProcessamento_RESTInterface( ) : base()
      {
      }

      public SdtNotificacaoAgendadaProcessamento_RESTInterface( SdtNotificacaoAgendadaProcessamento psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "NotificacaoAgendadaProcessamentoId" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Notificacaoagendadaprocessamentoid
      {
         get {
            return sdt.gxTpr_Notificacaoagendadaprocessamentoid ;
         }

         set {
            sdt.gxTpr_Notificacaoagendadaprocessamentoid = value;
         }

      }

      [DataMember( Name = "NotificacaoAgendadaProcessamentoInicio" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Notificacaoagendadaprocessamentoinicio
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Notificacaoagendadaprocessamentoinicio, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Notificacaoagendadaprocessamentoinicio = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "NotificacaoAgendadaProcessamentoFim" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Notificacaoagendadaprocessamentofim
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Notificacaoagendadaprocessamentofim, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Notificacaoagendadaprocessamentofim = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "NotificacaoAgendadaProcessamentoQtdExec" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Notificacaoagendadaprocessamentoqtdexec
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Notificacaoagendadaprocessamentoqtdexec), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Notificacaoagendadaprocessamentoqtdexec = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "NotificacaoAgendadaProcessamentoQtdSucesso" , Order = 4 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Notificacaoagendadaprocessamentoqtdsucesso
      {
         get {
            return sdt.gxTpr_Notificacaoagendadaprocessamentoqtdsucesso ;
         }

         set {
            sdt.gxTpr_Notificacaoagendadaprocessamentoqtdsucesso = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "NotificacaoAgendadaProcessamentoQtdFalhas" , Order = 5 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Notificacaoagendadaprocessamentoqtdfalhas
      {
         get {
            return sdt.gxTpr_Notificacaoagendadaprocessamentoqtdfalhas ;
         }

         set {
            sdt.gxTpr_Notificacaoagendadaprocessamentoqtdfalhas = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "NotificacaoAgendadaProcessamentoSituacao" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Notificacaoagendadaprocessamentosituacao
      {
         get {
            return sdt.gxTpr_Notificacaoagendadaprocessamentosituacao ;
         }

         set {
            sdt.gxTpr_Notificacaoagendadaprocessamentosituacao = value;
         }

      }

      [DataMember( Name = "NotificacaoAgendadaProcessamentoMensagemErro" , Order = 7 )]
      public string gxTpr_Notificacaoagendadaprocessamentomensagemerro
      {
         get {
            return sdt.gxTpr_Notificacaoagendadaprocessamentomensagemerro ;
         }

         set {
            sdt.gxTpr_Notificacaoagendadaprocessamentomensagemerro = value;
         }

      }

      public SdtNotificacaoAgendadaProcessamento sdt
      {
         get {
            return (SdtNotificacaoAgendadaProcessamento)Sdt ;
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
            sdt = new SdtNotificacaoAgendadaProcessamento() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 8 )]
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

   [DataContract(Name = @"NotificacaoAgendadaProcessamento", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtNotificacaoAgendadaProcessamento_RESTLInterface : GxGenericCollectionItem<SdtNotificacaoAgendadaProcessamento>
   {
      public SdtNotificacaoAgendadaProcessamento_RESTLInterface( ) : base()
      {
      }

      public SdtNotificacaoAgendadaProcessamento_RESTLInterface( SdtNotificacaoAgendadaProcessamento psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "NotificacaoAgendadaProcessamentoInicio" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Notificacaoagendadaprocessamentoinicio
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Notificacaoagendadaprocessamentoinicio, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Notificacaoagendadaprocessamentoinicio = DateTimeUtil.CToT2( value, (IGxContext)(context));
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

      public SdtNotificacaoAgendadaProcessamento sdt
      {
         get {
            return (SdtNotificacaoAgendadaProcessamento)Sdt ;
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
            sdt = new SdtNotificacaoAgendadaProcessamento() ;
         }
      }

   }

}
