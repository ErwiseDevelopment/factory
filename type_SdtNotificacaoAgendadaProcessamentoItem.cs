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
   [XmlRoot(ElementName = "NotificacaoAgendadaProcessamentoItem" )]
   [XmlType(TypeName =  "NotificacaoAgendadaProcessamentoItem" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtNotificacaoAgendadaProcessamentoItem : GxSilentTrnSdt
   {
      public SdtNotificacaoAgendadaProcessamentoItem( )
      {
      }

      public SdtNotificacaoAgendadaProcessamentoItem( IGxContext context )
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

      public void Load( Guid AV908NotificacaoAgendadaProcessamentoId ,
                        int AV916NotificacaoAgendadaProcessamentoItemId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV908NotificacaoAgendadaProcessamentoId,(int)AV916NotificacaoAgendadaProcessamentoItemId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"NotificacaoAgendadaProcessamentoId", typeof(Guid)}, new Object[]{"NotificacaoAgendadaProcessamentoItemId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "NotificacaoAgendadaProcessamentoItem");
         metadata.Set("BT", "NotificacaoAgendadaProcessamentoItem");
         metadata.Set("PK", "[ \"NotificacaoAgendadaProcessamentoId\",\"NotificacaoAgendadaProcessamentoItemId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"NotificacaoAgendadaProcessamentoId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Notificacaoagendadaprocessamentoitemid_Z");
         state.Add("gxTpr_Notificacaoagendadaprocessamentoitemexecucao_Z_Nullable");
         state.Add("gxTpr_Notificacaoagendadaprocessamentoitemtipo_Z");
         state.Add("gxTpr_Notificacaoagendadaprocessamentoitemsituacao_Z");
         state.Add("gxTpr_Notificacaoagendadaprocessamentoitemretorno_Z");
         state.Add("gxTpr_Notificacaoagendadaprocessamentoitemexecucao_N");
         state.Add("gxTpr_Notificacaoagendadaprocessamentoitemjson_N");
         state.Add("gxTpr_Notificacaoagendadaprocessamentoitemtipo_N");
         state.Add("gxTpr_Notificacaoagendadaprocessamentoitemsituacao_N");
         state.Add("gxTpr_Notificacaoagendadaprocessamentoitemretorno_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtNotificacaoAgendadaProcessamentoItem sdt;
         sdt = (SdtNotificacaoAgendadaProcessamentoItem)(source);
         gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoid = sdt.gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoid ;
         gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemid = sdt.gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemid ;
         gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemexecucao = sdt.gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemexecucao ;
         gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemjson = sdt.gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemjson ;
         gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemtipo = sdt.gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemtipo ;
         gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemsituacao = sdt.gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemsituacao ;
         gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemretorno = sdt.gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemretorno ;
         gxTv_SdtNotificacaoAgendadaProcessamentoItem_Mode = sdt.gxTv_SdtNotificacaoAgendadaProcessamentoItem_Mode ;
         gxTv_SdtNotificacaoAgendadaProcessamentoItem_Initialized = sdt.gxTv_SdtNotificacaoAgendadaProcessamentoItem_Initialized ;
         gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoid_Z = sdt.gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoid_Z ;
         gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemid_Z = sdt.gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemid_Z ;
         gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemexecucao_Z = sdt.gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemexecucao_Z ;
         gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemtipo_Z = sdt.gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemtipo_Z ;
         gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemsituacao_Z = sdt.gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemsituacao_Z ;
         gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemretorno_Z = sdt.gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemretorno_Z ;
         gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemexecucao_N = sdt.gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemexecucao_N ;
         gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemjson_N = sdt.gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemjson_N ;
         gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemtipo_N = sdt.gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemtipo_N ;
         gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemsituacao_N = sdt.gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemsituacao_N ;
         gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemretorno_N = sdt.gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemretorno_N ;
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
         AddObjectProperty("NotificacaoAgendadaProcessamentoId", gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoid, false, includeNonInitialized);
         AddObjectProperty("NotificacaoAgendadaProcessamentoItemId", gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemid, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemexecucao;
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
         AddObjectProperty("NotificacaoAgendadaProcessamentoItemExecucao", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("NotificacaoAgendadaProcessamentoItemExecucao_N", gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemexecucao_N, false, includeNonInitialized);
         AddObjectProperty("NotificacaoAgendadaProcessamentoItemJson", gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemjson, false, includeNonInitialized);
         AddObjectProperty("NotificacaoAgendadaProcessamentoItemJson_N", gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemjson_N, false, includeNonInitialized);
         AddObjectProperty("NotificacaoAgendadaProcessamentoItemTipo", gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemtipo, false, includeNonInitialized);
         AddObjectProperty("NotificacaoAgendadaProcessamentoItemTipo_N", gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemtipo_N, false, includeNonInitialized);
         AddObjectProperty("NotificacaoAgendadaProcessamentoItemSituacao", gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemsituacao, false, includeNonInitialized);
         AddObjectProperty("NotificacaoAgendadaProcessamentoItemSituacao_N", gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemsituacao_N, false, includeNonInitialized);
         AddObjectProperty("NotificacaoAgendadaProcessamentoItemRetorno", gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemretorno, false, includeNonInitialized);
         AddObjectProperty("NotificacaoAgendadaProcessamentoItemRetorno_N", gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemretorno_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtNotificacaoAgendadaProcessamentoItem_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtNotificacaoAgendadaProcessamentoItem_Initialized, false, includeNonInitialized);
            AddObjectProperty("NotificacaoAgendadaProcessamentoId_Z", gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoid_Z, false, includeNonInitialized);
            AddObjectProperty("NotificacaoAgendadaProcessamentoItemId_Z", gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemid_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemexecucao_Z;
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
            AddObjectProperty("NotificacaoAgendadaProcessamentoItemExecucao_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("NotificacaoAgendadaProcessamentoItemTipo_Z", gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemtipo_Z, false, includeNonInitialized);
            AddObjectProperty("NotificacaoAgendadaProcessamentoItemSituacao_Z", gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemsituacao_Z, false, includeNonInitialized);
            AddObjectProperty("NotificacaoAgendadaProcessamentoItemRetorno_Z", gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemretorno_Z, false, includeNonInitialized);
            AddObjectProperty("NotificacaoAgendadaProcessamentoItemExecucao_N", gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemexecucao_N, false, includeNonInitialized);
            AddObjectProperty("NotificacaoAgendadaProcessamentoItemJson_N", gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemjson_N, false, includeNonInitialized);
            AddObjectProperty("NotificacaoAgendadaProcessamentoItemTipo_N", gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemtipo_N, false, includeNonInitialized);
            AddObjectProperty("NotificacaoAgendadaProcessamentoItemSituacao_N", gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemsituacao_N, false, includeNonInitialized);
            AddObjectProperty("NotificacaoAgendadaProcessamentoItemRetorno_N", gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemretorno_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtNotificacaoAgendadaProcessamentoItem sdt )
      {
         if ( sdt.IsDirty("NotificacaoAgendadaProcessamentoId") )
         {
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoid = sdt.gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoid ;
         }
         if ( sdt.IsDirty("NotificacaoAgendadaProcessamentoItemId") )
         {
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemid = sdt.gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemid ;
         }
         if ( sdt.IsDirty("NotificacaoAgendadaProcessamentoItemExecucao") )
         {
            gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemexecucao_N = (short)(sdt.gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemexecucao_N);
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemexecucao = sdt.gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemexecucao ;
         }
         if ( sdt.IsDirty("NotificacaoAgendadaProcessamentoItemJson") )
         {
            gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemjson_N = (short)(sdt.gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemjson_N);
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemjson = sdt.gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemjson ;
         }
         if ( sdt.IsDirty("NotificacaoAgendadaProcessamentoItemTipo") )
         {
            gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemtipo_N = (short)(sdt.gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemtipo_N);
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemtipo = sdt.gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemtipo ;
         }
         if ( sdt.IsDirty("NotificacaoAgendadaProcessamentoItemSituacao") )
         {
            gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemsituacao_N = (short)(sdt.gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemsituacao_N);
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemsituacao = sdt.gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemsituacao ;
         }
         if ( sdt.IsDirty("NotificacaoAgendadaProcessamentoItemRetorno") )
         {
            gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemretorno_N = (short)(sdt.gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemretorno_N);
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemretorno = sdt.gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemretorno ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "NotificacaoAgendadaProcessamentoId" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaProcessamentoId"   )]
      public Guid gxTpr_Notificacaoagendadaprocessamentoid
      {
         get {
            return gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoid != value )
            {
               gxTv_SdtNotificacaoAgendadaProcessamentoItem_Mode = "INS";
               this.gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoid_Z_SetNull( );
               this.gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemid_Z_SetNull( );
               this.gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemexecucao_Z_SetNull( );
               this.gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemtipo_Z_SetNull( );
               this.gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemsituacao_Z_SetNull( );
               this.gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemretorno_Z_SetNull( );
            }
            gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoid = value;
            SetDirty("Notificacaoagendadaprocessamentoid");
         }

      }

      [  SoapElement( ElementName = "NotificacaoAgendadaProcessamentoItemId" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaProcessamentoItemId"   )]
      public int gxTpr_Notificacaoagendadaprocessamentoitemid
      {
         get {
            return gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemid != value )
            {
               gxTv_SdtNotificacaoAgendadaProcessamentoItem_Mode = "INS";
               this.gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoid_Z_SetNull( );
               this.gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemid_Z_SetNull( );
               this.gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemexecucao_Z_SetNull( );
               this.gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemtipo_Z_SetNull( );
               this.gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemsituacao_Z_SetNull( );
               this.gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemretorno_Z_SetNull( );
            }
            gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemid = value;
            SetDirty("Notificacaoagendadaprocessamentoitemid");
         }

      }

      [  SoapElement( ElementName = "NotificacaoAgendadaProcessamentoItemExecucao" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaProcessamentoItemExecucao"  , IsNullable=true )]
      public string gxTpr_Notificacaoagendadaprocessamentoitemexecucao_Nullable
      {
         get {
            if ( gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemexecucao == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemexecucao).value ;
         }

         set {
            gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemexecucao_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemexecucao = DateTime.MinValue;
            else
               gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemexecucao = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Notificacaoagendadaprocessamentoitemexecucao
      {
         get {
            return gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemexecucao ;
         }

         set {
            gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemexecucao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemexecucao = value;
            SetDirty("Notificacaoagendadaprocessamentoitemexecucao");
         }

      }

      public void gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemexecucao_SetNull( )
      {
         gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemexecucao_N = 1;
         gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemexecucao = (DateTime)(DateTime.MinValue);
         SetDirty("Notificacaoagendadaprocessamentoitemexecucao");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemexecucao_IsNull( )
      {
         return (gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemexecucao_N==1) ;
      }

      [  SoapElement( ElementName = "NotificacaoAgendadaProcessamentoItemJson" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaProcessamentoItemJson"   )]
      public string gxTpr_Notificacaoagendadaprocessamentoitemjson
      {
         get {
            return gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemjson ;
         }

         set {
            gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemjson_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemjson = value;
            SetDirty("Notificacaoagendadaprocessamentoitemjson");
         }

      }

      public void gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemjson_SetNull( )
      {
         gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemjson_N = 1;
         gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemjson = "";
         SetDirty("Notificacaoagendadaprocessamentoitemjson");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemjson_IsNull( )
      {
         return (gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemjson_N==1) ;
      }

      [  SoapElement( ElementName = "NotificacaoAgendadaProcessamentoItemTipo" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaProcessamentoItemTipo"   )]
      public string gxTpr_Notificacaoagendadaprocessamentoitemtipo
      {
         get {
            return gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemtipo ;
         }

         set {
            gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemtipo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemtipo = value;
            SetDirty("Notificacaoagendadaprocessamentoitemtipo");
         }

      }

      public void gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemtipo_SetNull( )
      {
         gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemtipo_N = 1;
         gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemtipo = "";
         SetDirty("Notificacaoagendadaprocessamentoitemtipo");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemtipo_IsNull( )
      {
         return (gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemtipo_N==1) ;
      }

      [  SoapElement( ElementName = "NotificacaoAgendadaProcessamentoItemSituacao" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaProcessamentoItemSituacao"   )]
      public string gxTpr_Notificacaoagendadaprocessamentoitemsituacao
      {
         get {
            return gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemsituacao ;
         }

         set {
            gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemsituacao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemsituacao = value;
            SetDirty("Notificacaoagendadaprocessamentoitemsituacao");
         }

      }

      public void gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemsituacao_SetNull( )
      {
         gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemsituacao_N = 1;
         gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemsituacao = "";
         SetDirty("Notificacaoagendadaprocessamentoitemsituacao");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemsituacao_IsNull( )
      {
         return (gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemsituacao_N==1) ;
      }

      [  SoapElement( ElementName = "NotificacaoAgendadaProcessamentoItemRetorno" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaProcessamentoItemRetorno"   )]
      public string gxTpr_Notificacaoagendadaprocessamentoitemretorno
      {
         get {
            return gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemretorno ;
         }

         set {
            gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemretorno_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemretorno = value;
            SetDirty("Notificacaoagendadaprocessamentoitemretorno");
         }

      }

      public void gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemretorno_SetNull( )
      {
         gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemretorno_N = 1;
         gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemretorno = "";
         SetDirty("Notificacaoagendadaprocessamentoitemretorno");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemretorno_IsNull( )
      {
         return (gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemretorno_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtNotificacaoAgendadaProcessamentoItem_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendadaProcessamentoItem_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtNotificacaoAgendadaProcessamentoItem_Mode_SetNull( )
      {
         gxTv_SdtNotificacaoAgendadaProcessamentoItem_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendadaProcessamentoItem_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtNotificacaoAgendadaProcessamentoItem_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendadaProcessamentoItem_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtNotificacaoAgendadaProcessamentoItem_Initialized_SetNull( )
      {
         gxTv_SdtNotificacaoAgendadaProcessamentoItem_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendadaProcessamentoItem_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotificacaoAgendadaProcessamentoId_Z" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaProcessamentoId_Z"   )]
      public Guid gxTpr_Notificacaoagendadaprocessamentoid_Z
      {
         get {
            return gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoid_Z = value;
            SetDirty("Notificacaoagendadaprocessamentoid_Z");
         }

      }

      public void gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoid_Z_SetNull( )
      {
         gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoid_Z = Guid.Empty;
         SetDirty("Notificacaoagendadaprocessamentoid_Z");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotificacaoAgendadaProcessamentoItemId_Z" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaProcessamentoItemId_Z"   )]
      public int gxTpr_Notificacaoagendadaprocessamentoitemid_Z
      {
         get {
            return gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemid_Z = value;
            SetDirty("Notificacaoagendadaprocessamentoitemid_Z");
         }

      }

      public void gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemid_Z_SetNull( )
      {
         gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemid_Z = 0;
         SetDirty("Notificacaoagendadaprocessamentoitemid_Z");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotificacaoAgendadaProcessamentoItemExecucao_Z" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaProcessamentoItemExecucao_Z"  , IsNullable=true )]
      public string gxTpr_Notificacaoagendadaprocessamentoitemexecucao_Z_Nullable
      {
         get {
            if ( gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemexecucao_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemexecucao_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemexecucao_Z = DateTime.MinValue;
            else
               gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemexecucao_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Notificacaoagendadaprocessamentoitemexecucao_Z
      {
         get {
            return gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemexecucao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemexecucao_Z = value;
            SetDirty("Notificacaoagendadaprocessamentoitemexecucao_Z");
         }

      }

      public void gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemexecucao_Z_SetNull( )
      {
         gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemexecucao_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Notificacaoagendadaprocessamentoitemexecucao_Z");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemexecucao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotificacaoAgendadaProcessamentoItemTipo_Z" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaProcessamentoItemTipo_Z"   )]
      public string gxTpr_Notificacaoagendadaprocessamentoitemtipo_Z
      {
         get {
            return gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemtipo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemtipo_Z = value;
            SetDirty("Notificacaoagendadaprocessamentoitemtipo_Z");
         }

      }

      public void gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemtipo_Z_SetNull( )
      {
         gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemtipo_Z = "";
         SetDirty("Notificacaoagendadaprocessamentoitemtipo_Z");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemtipo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotificacaoAgendadaProcessamentoItemSituacao_Z" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaProcessamentoItemSituacao_Z"   )]
      public string gxTpr_Notificacaoagendadaprocessamentoitemsituacao_Z
      {
         get {
            return gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemsituacao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemsituacao_Z = value;
            SetDirty("Notificacaoagendadaprocessamentoitemsituacao_Z");
         }

      }

      public void gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemsituacao_Z_SetNull( )
      {
         gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemsituacao_Z = "";
         SetDirty("Notificacaoagendadaprocessamentoitemsituacao_Z");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemsituacao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotificacaoAgendadaProcessamentoItemRetorno_Z" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaProcessamentoItemRetorno_Z"   )]
      public string gxTpr_Notificacaoagendadaprocessamentoitemretorno_Z
      {
         get {
            return gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemretorno_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemretorno_Z = value;
            SetDirty("Notificacaoagendadaprocessamentoitemretorno_Z");
         }

      }

      public void gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemretorno_Z_SetNull( )
      {
         gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemretorno_Z = "";
         SetDirty("Notificacaoagendadaprocessamentoitemretorno_Z");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemretorno_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotificacaoAgendadaProcessamentoItemExecucao_N" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaProcessamentoItemExecucao_N"   )]
      public short gxTpr_Notificacaoagendadaprocessamentoitemexecucao_N
      {
         get {
            return gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemexecucao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemexecucao_N = value;
            SetDirty("Notificacaoagendadaprocessamentoitemexecucao_N");
         }

      }

      public void gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemexecucao_N_SetNull( )
      {
         gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemexecucao_N = 0;
         SetDirty("Notificacaoagendadaprocessamentoitemexecucao_N");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemexecucao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotificacaoAgendadaProcessamentoItemJson_N" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaProcessamentoItemJson_N"   )]
      public short gxTpr_Notificacaoagendadaprocessamentoitemjson_N
      {
         get {
            return gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemjson_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemjson_N = value;
            SetDirty("Notificacaoagendadaprocessamentoitemjson_N");
         }

      }

      public void gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemjson_N_SetNull( )
      {
         gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemjson_N = 0;
         SetDirty("Notificacaoagendadaprocessamentoitemjson_N");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemjson_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotificacaoAgendadaProcessamentoItemTipo_N" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaProcessamentoItemTipo_N"   )]
      public short gxTpr_Notificacaoagendadaprocessamentoitemtipo_N
      {
         get {
            return gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemtipo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemtipo_N = value;
            SetDirty("Notificacaoagendadaprocessamentoitemtipo_N");
         }

      }

      public void gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemtipo_N_SetNull( )
      {
         gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemtipo_N = 0;
         SetDirty("Notificacaoagendadaprocessamentoitemtipo_N");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemtipo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotificacaoAgendadaProcessamentoItemSituacao_N" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaProcessamentoItemSituacao_N"   )]
      public short gxTpr_Notificacaoagendadaprocessamentoitemsituacao_N
      {
         get {
            return gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemsituacao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemsituacao_N = value;
            SetDirty("Notificacaoagendadaprocessamentoitemsituacao_N");
         }

      }

      public void gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemsituacao_N_SetNull( )
      {
         gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemsituacao_N = 0;
         SetDirty("Notificacaoagendadaprocessamentoitemsituacao_N");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemsituacao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotificacaoAgendadaProcessamentoItemRetorno_N" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaProcessamentoItemRetorno_N"   )]
      public short gxTpr_Notificacaoagendadaprocessamentoitemretorno_N
      {
         get {
            return gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemretorno_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemretorno_N = value;
            SetDirty("Notificacaoagendadaprocessamentoitemretorno_N");
         }

      }

      public void gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemretorno_N_SetNull( )
      {
         gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemretorno_N = 0;
         SetDirty("Notificacaoagendadaprocessamentoitemretorno_N");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemretorno_N_IsNull( )
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
         gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemexecucao = (DateTime)(DateTime.MinValue);
         gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemjson = "";
         gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemtipo = "";
         gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemsituacao = "";
         gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemretorno = "";
         gxTv_SdtNotificacaoAgendadaProcessamentoItem_Mode = "";
         gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoid_Z = Guid.Empty;
         gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemexecucao_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemtipo_Z = "";
         gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemsituacao_Z = "";
         gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemretorno_Z = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "notificacaoagendadaprocessamentoitem", "GeneXus.Programs.notificacaoagendadaprocessamentoitem_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtNotificacaoAgendadaProcessamentoItem_Initialized ;
      private short gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemexecucao_N ;
      private short gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemjson_N ;
      private short gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemtipo_N ;
      private short gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemsituacao_N ;
      private short gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemretorno_N ;
      private int gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemid ;
      private int gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemid_Z ;
      private string gxTv_SdtNotificacaoAgendadaProcessamentoItem_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemexecucao ;
      private DateTime gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemexecucao_Z ;
      private DateTime datetime_STZ ;
      private string gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemjson ;
      private string gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemtipo ;
      private string gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemsituacao ;
      private string gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemretorno ;
      private string gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemtipo_Z ;
      private string gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemsituacao_Z ;
      private string gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoitemretorno_Z ;
      private Guid gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoid ;
      private Guid gxTv_SdtNotificacaoAgendadaProcessamentoItem_Notificacaoagendadaprocessamentoid_Z ;
   }

   [DataContract(Name = @"NotificacaoAgendadaProcessamentoItem", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtNotificacaoAgendadaProcessamentoItem_RESTInterface : GxGenericCollectionItem<SdtNotificacaoAgendadaProcessamentoItem>
   {
      public SdtNotificacaoAgendadaProcessamentoItem_RESTInterface( ) : base()
      {
      }

      public SdtNotificacaoAgendadaProcessamentoItem_RESTInterface( SdtNotificacaoAgendadaProcessamentoItem psdt ) : base(psdt)
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

      [DataMember( Name = "NotificacaoAgendadaProcessamentoItemId" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Notificacaoagendadaprocessamentoitemid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Notificacaoagendadaprocessamentoitemid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Notificacaoagendadaprocessamentoitemid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "NotificacaoAgendadaProcessamentoItemExecucao" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Notificacaoagendadaprocessamentoitemexecucao
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Notificacaoagendadaprocessamentoitemexecucao, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Notificacaoagendadaprocessamentoitemexecucao = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "NotificacaoAgendadaProcessamentoItemJson" , Order = 3 )]
      public string gxTpr_Notificacaoagendadaprocessamentoitemjson
      {
         get {
            return sdt.gxTpr_Notificacaoagendadaprocessamentoitemjson ;
         }

         set {
            sdt.gxTpr_Notificacaoagendadaprocessamentoitemjson = value;
         }

      }

      [DataMember( Name = "NotificacaoAgendadaProcessamentoItemTipo" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Notificacaoagendadaprocessamentoitemtipo
      {
         get {
            return sdt.gxTpr_Notificacaoagendadaprocessamentoitemtipo ;
         }

         set {
            sdt.gxTpr_Notificacaoagendadaprocessamentoitemtipo = value;
         }

      }

      [DataMember( Name = "NotificacaoAgendadaProcessamentoItemSituacao" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Notificacaoagendadaprocessamentoitemsituacao
      {
         get {
            return sdt.gxTpr_Notificacaoagendadaprocessamentoitemsituacao ;
         }

         set {
            sdt.gxTpr_Notificacaoagendadaprocessamentoitemsituacao = value;
         }

      }

      [DataMember( Name = "NotificacaoAgendadaProcessamentoItemRetorno" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Notificacaoagendadaprocessamentoitemretorno
      {
         get {
            return sdt.gxTpr_Notificacaoagendadaprocessamentoitemretorno ;
         }

         set {
            sdt.gxTpr_Notificacaoagendadaprocessamentoitemretorno = value;
         }

      }

      public SdtNotificacaoAgendadaProcessamentoItem sdt
      {
         get {
            return (SdtNotificacaoAgendadaProcessamentoItem)Sdt ;
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
            sdt = new SdtNotificacaoAgendadaProcessamentoItem() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 7 )]
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

   [DataContract(Name = @"NotificacaoAgendadaProcessamentoItem", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtNotificacaoAgendadaProcessamentoItem_RESTLInterface : GxGenericCollectionItem<SdtNotificacaoAgendadaProcessamentoItem>
   {
      public SdtNotificacaoAgendadaProcessamentoItem_RESTLInterface( ) : base()
      {
      }

      public SdtNotificacaoAgendadaProcessamentoItem_RESTLInterface( SdtNotificacaoAgendadaProcessamentoItem psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "NotificacaoAgendadaProcessamentoItemExecucao" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Notificacaoagendadaprocessamentoitemexecucao
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Notificacaoagendadaprocessamentoitemexecucao, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Notificacaoagendadaprocessamentoitemexecucao = DateTimeUtil.CToT2( value, (IGxContext)(context));
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

      public SdtNotificacaoAgendadaProcessamentoItem sdt
      {
         get {
            return (SdtNotificacaoAgendadaProcessamentoItem)Sdt ;
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
            sdt = new SdtNotificacaoAgendadaProcessamentoItem() ;
         }
      }

   }

}
