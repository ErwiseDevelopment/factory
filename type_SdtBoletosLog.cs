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
   [XmlRoot(ElementName = "BoletosLog" )]
   [XmlType(TypeName =  "BoletosLog" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtBoletosLog : GxSilentTrnSdt
   {
      public SdtBoletosLog( )
      {
      }

      public SdtBoletosLog( IGxContext context )
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

      public void Load( int AV1101BoletosLogId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV1101BoletosLogId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"BoletosLogId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "BoletosLog");
         metadata.Set("BT", "BoletosLog");
         metadata.Set("PK", "[ \"BoletosLogId\" ]");
         metadata.Set("PKAssigned", "[ \"BoletosLogId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"BoletosId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Boletoslogid_Z");
         state.Add("gxTpr_Boletosid_Z");
         state.Add("gxTpr_Boletoslogoperacao_Z");
         state.Add("gxTpr_Boletoslogstatusanterior_Z");
         state.Add("gxTpr_Boletoslogstatusnovo_Z");
         state.Add("gxTpr_Boletoslogcodigohttp_Z");
         state.Add("gxTpr_Boletoslogsucesso_Z");
         state.Add("gxTpr_Boletoslogobservacao_Z");
         state.Add("gxTpr_Boletoslogcreatedat_Z_Nullable");
         state.Add("gxTpr_Boletosid_N");
         state.Add("gxTpr_Boletoslogoperacao_N");
         state.Add("gxTpr_Boletoslogstatusanterior_N");
         state.Add("gxTpr_Boletoslogstatusnovo_N");
         state.Add("gxTpr_Boletoslogrequisicao_N");
         state.Add("gxTpr_Boletoslogresponse_N");
         state.Add("gxTpr_Boletoslogcodigohttp_N");
         state.Add("gxTpr_Boletoslogsucesso_N");
         state.Add("gxTpr_Boletoslogobservacao_N");
         state.Add("gxTpr_Boletoslogcreatedat_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtBoletosLog sdt;
         sdt = (SdtBoletosLog)(source);
         gxTv_SdtBoletosLog_Boletoslogid = sdt.gxTv_SdtBoletosLog_Boletoslogid ;
         gxTv_SdtBoletosLog_Boletosid = sdt.gxTv_SdtBoletosLog_Boletosid ;
         gxTv_SdtBoletosLog_Boletoslogoperacao = sdt.gxTv_SdtBoletosLog_Boletoslogoperacao ;
         gxTv_SdtBoletosLog_Boletoslogstatusanterior = sdt.gxTv_SdtBoletosLog_Boletoslogstatusanterior ;
         gxTv_SdtBoletosLog_Boletoslogstatusnovo = sdt.gxTv_SdtBoletosLog_Boletoslogstatusnovo ;
         gxTv_SdtBoletosLog_Boletoslogrequisicao = sdt.gxTv_SdtBoletosLog_Boletoslogrequisicao ;
         gxTv_SdtBoletosLog_Boletoslogresponse = sdt.gxTv_SdtBoletosLog_Boletoslogresponse ;
         gxTv_SdtBoletosLog_Boletoslogcodigohttp = sdt.gxTv_SdtBoletosLog_Boletoslogcodigohttp ;
         gxTv_SdtBoletosLog_Boletoslogsucesso = sdt.gxTv_SdtBoletosLog_Boletoslogsucesso ;
         gxTv_SdtBoletosLog_Boletoslogobservacao = sdt.gxTv_SdtBoletosLog_Boletoslogobservacao ;
         gxTv_SdtBoletosLog_Boletoslogcreatedat = sdt.gxTv_SdtBoletosLog_Boletoslogcreatedat ;
         gxTv_SdtBoletosLog_Mode = sdt.gxTv_SdtBoletosLog_Mode ;
         gxTv_SdtBoletosLog_Initialized = sdt.gxTv_SdtBoletosLog_Initialized ;
         gxTv_SdtBoletosLog_Boletoslogid_Z = sdt.gxTv_SdtBoletosLog_Boletoslogid_Z ;
         gxTv_SdtBoletosLog_Boletosid_Z = sdt.gxTv_SdtBoletosLog_Boletosid_Z ;
         gxTv_SdtBoletosLog_Boletoslogoperacao_Z = sdt.gxTv_SdtBoletosLog_Boletoslogoperacao_Z ;
         gxTv_SdtBoletosLog_Boletoslogstatusanterior_Z = sdt.gxTv_SdtBoletosLog_Boletoslogstatusanterior_Z ;
         gxTv_SdtBoletosLog_Boletoslogstatusnovo_Z = sdt.gxTv_SdtBoletosLog_Boletoslogstatusnovo_Z ;
         gxTv_SdtBoletosLog_Boletoslogcodigohttp_Z = sdt.gxTv_SdtBoletosLog_Boletoslogcodigohttp_Z ;
         gxTv_SdtBoletosLog_Boletoslogsucesso_Z = sdt.gxTv_SdtBoletosLog_Boletoslogsucesso_Z ;
         gxTv_SdtBoletosLog_Boletoslogobservacao_Z = sdt.gxTv_SdtBoletosLog_Boletoslogobservacao_Z ;
         gxTv_SdtBoletosLog_Boletoslogcreatedat_Z = sdt.gxTv_SdtBoletosLog_Boletoslogcreatedat_Z ;
         gxTv_SdtBoletosLog_Boletosid_N = sdt.gxTv_SdtBoletosLog_Boletosid_N ;
         gxTv_SdtBoletosLog_Boletoslogoperacao_N = sdt.gxTv_SdtBoletosLog_Boletoslogoperacao_N ;
         gxTv_SdtBoletosLog_Boletoslogstatusanterior_N = sdt.gxTv_SdtBoletosLog_Boletoslogstatusanterior_N ;
         gxTv_SdtBoletosLog_Boletoslogstatusnovo_N = sdt.gxTv_SdtBoletosLog_Boletoslogstatusnovo_N ;
         gxTv_SdtBoletosLog_Boletoslogrequisicao_N = sdt.gxTv_SdtBoletosLog_Boletoslogrequisicao_N ;
         gxTv_SdtBoletosLog_Boletoslogresponse_N = sdt.gxTv_SdtBoletosLog_Boletoslogresponse_N ;
         gxTv_SdtBoletosLog_Boletoslogcodigohttp_N = sdt.gxTv_SdtBoletosLog_Boletoslogcodigohttp_N ;
         gxTv_SdtBoletosLog_Boletoslogsucesso_N = sdt.gxTv_SdtBoletosLog_Boletoslogsucesso_N ;
         gxTv_SdtBoletosLog_Boletoslogobservacao_N = sdt.gxTv_SdtBoletosLog_Boletoslogobservacao_N ;
         gxTv_SdtBoletosLog_Boletoslogcreatedat_N = sdt.gxTv_SdtBoletosLog_Boletoslogcreatedat_N ;
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
         AddObjectProperty("BoletosLogId", gxTv_SdtBoletosLog_Boletoslogid, false, includeNonInitialized);
         AddObjectProperty("BoletosId", gxTv_SdtBoletosLog_Boletosid, false, includeNonInitialized);
         AddObjectProperty("BoletosId_N", gxTv_SdtBoletosLog_Boletosid_N, false, includeNonInitialized);
         AddObjectProperty("BoletosLogOperacao", gxTv_SdtBoletosLog_Boletoslogoperacao, false, includeNonInitialized);
         AddObjectProperty("BoletosLogOperacao_N", gxTv_SdtBoletosLog_Boletoslogoperacao_N, false, includeNonInitialized);
         AddObjectProperty("BoletosLogStatusAnterior", gxTv_SdtBoletosLog_Boletoslogstatusanterior, false, includeNonInitialized);
         AddObjectProperty("BoletosLogStatusAnterior_N", gxTv_SdtBoletosLog_Boletoslogstatusanterior_N, false, includeNonInitialized);
         AddObjectProperty("BoletosLogStatusNovo", gxTv_SdtBoletosLog_Boletoslogstatusnovo, false, includeNonInitialized);
         AddObjectProperty("BoletosLogStatusNovo_N", gxTv_SdtBoletosLog_Boletoslogstatusnovo_N, false, includeNonInitialized);
         AddObjectProperty("BoletosLogRequisicao", gxTv_SdtBoletosLog_Boletoslogrequisicao, false, includeNonInitialized);
         AddObjectProperty("BoletosLogRequisicao_N", gxTv_SdtBoletosLog_Boletoslogrequisicao_N, false, includeNonInitialized);
         AddObjectProperty("BoletosLogResponse", gxTv_SdtBoletosLog_Boletoslogresponse, false, includeNonInitialized);
         AddObjectProperty("BoletosLogResponse_N", gxTv_SdtBoletosLog_Boletoslogresponse_N, false, includeNonInitialized);
         AddObjectProperty("BoletosLogCodigoHttp", gxTv_SdtBoletosLog_Boletoslogcodigohttp, false, includeNonInitialized);
         AddObjectProperty("BoletosLogCodigoHttp_N", gxTv_SdtBoletosLog_Boletoslogcodigohttp_N, false, includeNonInitialized);
         AddObjectProperty("BoletosLogSucesso", gxTv_SdtBoletosLog_Boletoslogsucesso, false, includeNonInitialized);
         AddObjectProperty("BoletosLogSucesso_N", gxTv_SdtBoletosLog_Boletoslogsucesso_N, false, includeNonInitialized);
         AddObjectProperty("BoletosLogObservacao", gxTv_SdtBoletosLog_Boletoslogobservacao, false, includeNonInitialized);
         AddObjectProperty("BoletosLogObservacao_N", gxTv_SdtBoletosLog_Boletoslogobservacao_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtBoletosLog_Boletoslogcreatedat;
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
         AddObjectProperty("BoletosLogCreatedAt", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("BoletosLogCreatedAt_N", gxTv_SdtBoletosLog_Boletoslogcreatedat_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtBoletosLog_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtBoletosLog_Initialized, false, includeNonInitialized);
            AddObjectProperty("BoletosLogId_Z", gxTv_SdtBoletosLog_Boletoslogid_Z, false, includeNonInitialized);
            AddObjectProperty("BoletosId_Z", gxTv_SdtBoletosLog_Boletosid_Z, false, includeNonInitialized);
            AddObjectProperty("BoletosLogOperacao_Z", gxTv_SdtBoletosLog_Boletoslogoperacao_Z, false, includeNonInitialized);
            AddObjectProperty("BoletosLogStatusAnterior_Z", gxTv_SdtBoletosLog_Boletoslogstatusanterior_Z, false, includeNonInitialized);
            AddObjectProperty("BoletosLogStatusNovo_Z", gxTv_SdtBoletosLog_Boletoslogstatusnovo_Z, false, includeNonInitialized);
            AddObjectProperty("BoletosLogCodigoHttp_Z", gxTv_SdtBoletosLog_Boletoslogcodigohttp_Z, false, includeNonInitialized);
            AddObjectProperty("BoletosLogSucesso_Z", gxTv_SdtBoletosLog_Boletoslogsucesso_Z, false, includeNonInitialized);
            AddObjectProperty("BoletosLogObservacao_Z", gxTv_SdtBoletosLog_Boletoslogobservacao_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtBoletosLog_Boletoslogcreatedat_Z;
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
            AddObjectProperty("BoletosLogCreatedAt_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("BoletosId_N", gxTv_SdtBoletosLog_Boletosid_N, false, includeNonInitialized);
            AddObjectProperty("BoletosLogOperacao_N", gxTv_SdtBoletosLog_Boletoslogoperacao_N, false, includeNonInitialized);
            AddObjectProperty("BoletosLogStatusAnterior_N", gxTv_SdtBoletosLog_Boletoslogstatusanterior_N, false, includeNonInitialized);
            AddObjectProperty("BoletosLogStatusNovo_N", gxTv_SdtBoletosLog_Boletoslogstatusnovo_N, false, includeNonInitialized);
            AddObjectProperty("BoletosLogRequisicao_N", gxTv_SdtBoletosLog_Boletoslogrequisicao_N, false, includeNonInitialized);
            AddObjectProperty("BoletosLogResponse_N", gxTv_SdtBoletosLog_Boletoslogresponse_N, false, includeNonInitialized);
            AddObjectProperty("BoletosLogCodigoHttp_N", gxTv_SdtBoletosLog_Boletoslogcodigohttp_N, false, includeNonInitialized);
            AddObjectProperty("BoletosLogSucesso_N", gxTv_SdtBoletosLog_Boletoslogsucesso_N, false, includeNonInitialized);
            AddObjectProperty("BoletosLogObservacao_N", gxTv_SdtBoletosLog_Boletoslogobservacao_N, false, includeNonInitialized);
            AddObjectProperty("BoletosLogCreatedAt_N", gxTv_SdtBoletosLog_Boletoslogcreatedat_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtBoletosLog sdt )
      {
         if ( sdt.IsDirty("BoletosLogId") )
         {
            sdtIsNull = 0;
            gxTv_SdtBoletosLog_Boletoslogid = sdt.gxTv_SdtBoletosLog_Boletoslogid ;
         }
         if ( sdt.IsDirty("BoletosId") )
         {
            gxTv_SdtBoletosLog_Boletosid_N = (short)(sdt.gxTv_SdtBoletosLog_Boletosid_N);
            sdtIsNull = 0;
            gxTv_SdtBoletosLog_Boletosid = sdt.gxTv_SdtBoletosLog_Boletosid ;
         }
         if ( sdt.IsDirty("BoletosLogOperacao") )
         {
            gxTv_SdtBoletosLog_Boletoslogoperacao_N = (short)(sdt.gxTv_SdtBoletosLog_Boletoslogoperacao_N);
            sdtIsNull = 0;
            gxTv_SdtBoletosLog_Boletoslogoperacao = sdt.gxTv_SdtBoletosLog_Boletoslogoperacao ;
         }
         if ( sdt.IsDirty("BoletosLogStatusAnterior") )
         {
            gxTv_SdtBoletosLog_Boletoslogstatusanterior_N = (short)(sdt.gxTv_SdtBoletosLog_Boletoslogstatusanterior_N);
            sdtIsNull = 0;
            gxTv_SdtBoletosLog_Boletoslogstatusanterior = sdt.gxTv_SdtBoletosLog_Boletoslogstatusanterior ;
         }
         if ( sdt.IsDirty("BoletosLogStatusNovo") )
         {
            gxTv_SdtBoletosLog_Boletoslogstatusnovo_N = (short)(sdt.gxTv_SdtBoletosLog_Boletoslogstatusnovo_N);
            sdtIsNull = 0;
            gxTv_SdtBoletosLog_Boletoslogstatusnovo = sdt.gxTv_SdtBoletosLog_Boletoslogstatusnovo ;
         }
         if ( sdt.IsDirty("BoletosLogRequisicao") )
         {
            gxTv_SdtBoletosLog_Boletoslogrequisicao_N = (short)(sdt.gxTv_SdtBoletosLog_Boletoslogrequisicao_N);
            sdtIsNull = 0;
            gxTv_SdtBoletosLog_Boletoslogrequisicao = sdt.gxTv_SdtBoletosLog_Boletoslogrequisicao ;
         }
         if ( sdt.IsDirty("BoletosLogResponse") )
         {
            gxTv_SdtBoletosLog_Boletoslogresponse_N = (short)(sdt.gxTv_SdtBoletosLog_Boletoslogresponse_N);
            sdtIsNull = 0;
            gxTv_SdtBoletosLog_Boletoslogresponse = sdt.gxTv_SdtBoletosLog_Boletoslogresponse ;
         }
         if ( sdt.IsDirty("BoletosLogCodigoHttp") )
         {
            gxTv_SdtBoletosLog_Boletoslogcodigohttp_N = (short)(sdt.gxTv_SdtBoletosLog_Boletoslogcodigohttp_N);
            sdtIsNull = 0;
            gxTv_SdtBoletosLog_Boletoslogcodigohttp = sdt.gxTv_SdtBoletosLog_Boletoslogcodigohttp ;
         }
         if ( sdt.IsDirty("BoletosLogSucesso") )
         {
            gxTv_SdtBoletosLog_Boletoslogsucesso_N = (short)(sdt.gxTv_SdtBoletosLog_Boletoslogsucesso_N);
            sdtIsNull = 0;
            gxTv_SdtBoletosLog_Boletoslogsucesso = sdt.gxTv_SdtBoletosLog_Boletoslogsucesso ;
         }
         if ( sdt.IsDirty("BoletosLogObservacao") )
         {
            gxTv_SdtBoletosLog_Boletoslogobservacao_N = (short)(sdt.gxTv_SdtBoletosLog_Boletoslogobservacao_N);
            sdtIsNull = 0;
            gxTv_SdtBoletosLog_Boletoslogobservacao = sdt.gxTv_SdtBoletosLog_Boletoslogobservacao ;
         }
         if ( sdt.IsDirty("BoletosLogCreatedAt") )
         {
            gxTv_SdtBoletosLog_Boletoslogcreatedat_N = (short)(sdt.gxTv_SdtBoletosLog_Boletoslogcreatedat_N);
            sdtIsNull = 0;
            gxTv_SdtBoletosLog_Boletoslogcreatedat = sdt.gxTv_SdtBoletosLog_Boletoslogcreatedat ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "BoletosLogId" )]
      [  XmlElement( ElementName = "BoletosLogId"   )]
      public int gxTpr_Boletoslogid
      {
         get {
            return gxTv_SdtBoletosLog_Boletoslogid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtBoletosLog_Boletoslogid != value )
            {
               gxTv_SdtBoletosLog_Mode = "INS";
               this.gxTv_SdtBoletosLog_Boletoslogid_Z_SetNull( );
               this.gxTv_SdtBoletosLog_Boletosid_Z_SetNull( );
               this.gxTv_SdtBoletosLog_Boletoslogoperacao_Z_SetNull( );
               this.gxTv_SdtBoletosLog_Boletoslogstatusanterior_Z_SetNull( );
               this.gxTv_SdtBoletosLog_Boletoslogstatusnovo_Z_SetNull( );
               this.gxTv_SdtBoletosLog_Boletoslogcodigohttp_Z_SetNull( );
               this.gxTv_SdtBoletosLog_Boletoslogsucesso_Z_SetNull( );
               this.gxTv_SdtBoletosLog_Boletoslogobservacao_Z_SetNull( );
               this.gxTv_SdtBoletosLog_Boletoslogcreatedat_Z_SetNull( );
            }
            gxTv_SdtBoletosLog_Boletoslogid = value;
            SetDirty("Boletoslogid");
         }

      }

      [  SoapElement( ElementName = "BoletosId" )]
      [  XmlElement( ElementName = "BoletosId"   )]
      public int gxTpr_Boletosid
      {
         get {
            return gxTv_SdtBoletosLog_Boletosid ;
         }

         set {
            gxTv_SdtBoletosLog_Boletosid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtBoletosLog_Boletosid = value;
            SetDirty("Boletosid");
         }

      }

      public void gxTv_SdtBoletosLog_Boletosid_SetNull( )
      {
         gxTv_SdtBoletosLog_Boletosid_N = 1;
         gxTv_SdtBoletosLog_Boletosid = 0;
         SetDirty("Boletosid");
         return  ;
      }

      public bool gxTv_SdtBoletosLog_Boletosid_IsNull( )
      {
         return (gxTv_SdtBoletosLog_Boletosid_N==1) ;
      }

      [  SoapElement( ElementName = "BoletosLogOperacao" )]
      [  XmlElement( ElementName = "BoletosLogOperacao"   )]
      public string gxTpr_Boletoslogoperacao
      {
         get {
            return gxTv_SdtBoletosLog_Boletoslogoperacao ;
         }

         set {
            gxTv_SdtBoletosLog_Boletoslogoperacao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtBoletosLog_Boletoslogoperacao = value;
            SetDirty("Boletoslogoperacao");
         }

      }

      public void gxTv_SdtBoletosLog_Boletoslogoperacao_SetNull( )
      {
         gxTv_SdtBoletosLog_Boletoslogoperacao_N = 1;
         gxTv_SdtBoletosLog_Boletoslogoperacao = "";
         SetDirty("Boletoslogoperacao");
         return  ;
      }

      public bool gxTv_SdtBoletosLog_Boletoslogoperacao_IsNull( )
      {
         return (gxTv_SdtBoletosLog_Boletoslogoperacao_N==1) ;
      }

      [  SoapElement( ElementName = "BoletosLogStatusAnterior" )]
      [  XmlElement( ElementName = "BoletosLogStatusAnterior"   )]
      public string gxTpr_Boletoslogstatusanterior
      {
         get {
            return gxTv_SdtBoletosLog_Boletoslogstatusanterior ;
         }

         set {
            gxTv_SdtBoletosLog_Boletoslogstatusanterior_N = 0;
            sdtIsNull = 0;
            gxTv_SdtBoletosLog_Boletoslogstatusanterior = value;
            SetDirty("Boletoslogstatusanterior");
         }

      }

      public void gxTv_SdtBoletosLog_Boletoslogstatusanterior_SetNull( )
      {
         gxTv_SdtBoletosLog_Boletoslogstatusanterior_N = 1;
         gxTv_SdtBoletosLog_Boletoslogstatusanterior = "";
         SetDirty("Boletoslogstatusanterior");
         return  ;
      }

      public bool gxTv_SdtBoletosLog_Boletoslogstatusanterior_IsNull( )
      {
         return (gxTv_SdtBoletosLog_Boletoslogstatusanterior_N==1) ;
      }

      [  SoapElement( ElementName = "BoletosLogStatusNovo" )]
      [  XmlElement( ElementName = "BoletosLogStatusNovo"   )]
      public string gxTpr_Boletoslogstatusnovo
      {
         get {
            return gxTv_SdtBoletosLog_Boletoslogstatusnovo ;
         }

         set {
            gxTv_SdtBoletosLog_Boletoslogstatusnovo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtBoletosLog_Boletoslogstatusnovo = value;
            SetDirty("Boletoslogstatusnovo");
         }

      }

      public void gxTv_SdtBoletosLog_Boletoslogstatusnovo_SetNull( )
      {
         gxTv_SdtBoletosLog_Boletoslogstatusnovo_N = 1;
         gxTv_SdtBoletosLog_Boletoslogstatusnovo = "";
         SetDirty("Boletoslogstatusnovo");
         return  ;
      }

      public bool gxTv_SdtBoletosLog_Boletoslogstatusnovo_IsNull( )
      {
         return (gxTv_SdtBoletosLog_Boletoslogstatusnovo_N==1) ;
      }

      [  SoapElement( ElementName = "BoletosLogRequisicao" )]
      [  XmlElement( ElementName = "BoletosLogRequisicao"   )]
      public string gxTpr_Boletoslogrequisicao
      {
         get {
            return gxTv_SdtBoletosLog_Boletoslogrequisicao ;
         }

         set {
            gxTv_SdtBoletosLog_Boletoslogrequisicao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtBoletosLog_Boletoslogrequisicao = value;
            SetDirty("Boletoslogrequisicao");
         }

      }

      public void gxTv_SdtBoletosLog_Boletoslogrequisicao_SetNull( )
      {
         gxTv_SdtBoletosLog_Boletoslogrequisicao_N = 1;
         gxTv_SdtBoletosLog_Boletoslogrequisicao = "";
         SetDirty("Boletoslogrequisicao");
         return  ;
      }

      public bool gxTv_SdtBoletosLog_Boletoslogrequisicao_IsNull( )
      {
         return (gxTv_SdtBoletosLog_Boletoslogrequisicao_N==1) ;
      }

      [  SoapElement( ElementName = "BoletosLogResponse" )]
      [  XmlElement( ElementName = "BoletosLogResponse"   )]
      public string gxTpr_Boletoslogresponse
      {
         get {
            return gxTv_SdtBoletosLog_Boletoslogresponse ;
         }

         set {
            gxTv_SdtBoletosLog_Boletoslogresponse_N = 0;
            sdtIsNull = 0;
            gxTv_SdtBoletosLog_Boletoslogresponse = value;
            SetDirty("Boletoslogresponse");
         }

      }

      public void gxTv_SdtBoletosLog_Boletoslogresponse_SetNull( )
      {
         gxTv_SdtBoletosLog_Boletoslogresponse_N = 1;
         gxTv_SdtBoletosLog_Boletoslogresponse = "";
         SetDirty("Boletoslogresponse");
         return  ;
      }

      public bool gxTv_SdtBoletosLog_Boletoslogresponse_IsNull( )
      {
         return (gxTv_SdtBoletosLog_Boletoslogresponse_N==1) ;
      }

      [  SoapElement( ElementName = "BoletosLogCodigoHttp" )]
      [  XmlElement( ElementName = "BoletosLogCodigoHttp"   )]
      public short gxTpr_Boletoslogcodigohttp
      {
         get {
            return gxTv_SdtBoletosLog_Boletoslogcodigohttp ;
         }

         set {
            gxTv_SdtBoletosLog_Boletoslogcodigohttp_N = 0;
            sdtIsNull = 0;
            gxTv_SdtBoletosLog_Boletoslogcodigohttp = value;
            SetDirty("Boletoslogcodigohttp");
         }

      }

      public void gxTv_SdtBoletosLog_Boletoslogcodigohttp_SetNull( )
      {
         gxTv_SdtBoletosLog_Boletoslogcodigohttp_N = 1;
         gxTv_SdtBoletosLog_Boletoslogcodigohttp = 0;
         SetDirty("Boletoslogcodigohttp");
         return  ;
      }

      public bool gxTv_SdtBoletosLog_Boletoslogcodigohttp_IsNull( )
      {
         return (gxTv_SdtBoletosLog_Boletoslogcodigohttp_N==1) ;
      }

      [  SoapElement( ElementName = "BoletosLogSucesso" )]
      [  XmlElement( ElementName = "BoletosLogSucesso"   )]
      public bool gxTpr_Boletoslogsucesso
      {
         get {
            return gxTv_SdtBoletosLog_Boletoslogsucesso ;
         }

         set {
            gxTv_SdtBoletosLog_Boletoslogsucesso_N = 0;
            sdtIsNull = 0;
            gxTv_SdtBoletosLog_Boletoslogsucesso = value;
            SetDirty("Boletoslogsucesso");
         }

      }

      public void gxTv_SdtBoletosLog_Boletoslogsucesso_SetNull( )
      {
         gxTv_SdtBoletosLog_Boletoslogsucesso_N = 1;
         gxTv_SdtBoletosLog_Boletoslogsucesso = false;
         SetDirty("Boletoslogsucesso");
         return  ;
      }

      public bool gxTv_SdtBoletosLog_Boletoslogsucesso_IsNull( )
      {
         return (gxTv_SdtBoletosLog_Boletoslogsucesso_N==1) ;
      }

      [  SoapElement( ElementName = "BoletosLogObservacao" )]
      [  XmlElement( ElementName = "BoletosLogObservacao"   )]
      public string gxTpr_Boletoslogobservacao
      {
         get {
            return gxTv_SdtBoletosLog_Boletoslogobservacao ;
         }

         set {
            gxTv_SdtBoletosLog_Boletoslogobservacao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtBoletosLog_Boletoslogobservacao = value;
            SetDirty("Boletoslogobservacao");
         }

      }

      public void gxTv_SdtBoletosLog_Boletoslogobservacao_SetNull( )
      {
         gxTv_SdtBoletosLog_Boletoslogobservacao_N = 1;
         gxTv_SdtBoletosLog_Boletoslogobservacao = "";
         SetDirty("Boletoslogobservacao");
         return  ;
      }

      public bool gxTv_SdtBoletosLog_Boletoslogobservacao_IsNull( )
      {
         return (gxTv_SdtBoletosLog_Boletoslogobservacao_N==1) ;
      }

      [  SoapElement( ElementName = "BoletosLogCreatedAt" )]
      [  XmlElement( ElementName = "BoletosLogCreatedAt"  , IsNullable=true )]
      public string gxTpr_Boletoslogcreatedat_Nullable
      {
         get {
            if ( gxTv_SdtBoletosLog_Boletoslogcreatedat == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtBoletosLog_Boletoslogcreatedat).value ;
         }

         set {
            gxTv_SdtBoletosLog_Boletoslogcreatedat_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtBoletosLog_Boletoslogcreatedat = DateTime.MinValue;
            else
               gxTv_SdtBoletosLog_Boletoslogcreatedat = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Boletoslogcreatedat
      {
         get {
            return gxTv_SdtBoletosLog_Boletoslogcreatedat ;
         }

         set {
            gxTv_SdtBoletosLog_Boletoslogcreatedat_N = 0;
            sdtIsNull = 0;
            gxTv_SdtBoletosLog_Boletoslogcreatedat = value;
            SetDirty("Boletoslogcreatedat");
         }

      }

      public void gxTv_SdtBoletosLog_Boletoslogcreatedat_SetNull( )
      {
         gxTv_SdtBoletosLog_Boletoslogcreatedat_N = 1;
         gxTv_SdtBoletosLog_Boletoslogcreatedat = (DateTime)(DateTime.MinValue);
         SetDirty("Boletoslogcreatedat");
         return  ;
      }

      public bool gxTv_SdtBoletosLog_Boletoslogcreatedat_IsNull( )
      {
         return (gxTv_SdtBoletosLog_Boletoslogcreatedat_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtBoletosLog_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoletosLog_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtBoletosLog_Mode_SetNull( )
      {
         gxTv_SdtBoletosLog_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtBoletosLog_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtBoletosLog_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoletosLog_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtBoletosLog_Initialized_SetNull( )
      {
         gxTv_SdtBoletosLog_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtBoletosLog_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosLogId_Z" )]
      [  XmlElement( ElementName = "BoletosLogId_Z"   )]
      public int gxTpr_Boletoslogid_Z
      {
         get {
            return gxTv_SdtBoletosLog_Boletoslogid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoletosLog_Boletoslogid_Z = value;
            SetDirty("Boletoslogid_Z");
         }

      }

      public void gxTv_SdtBoletosLog_Boletoslogid_Z_SetNull( )
      {
         gxTv_SdtBoletosLog_Boletoslogid_Z = 0;
         SetDirty("Boletoslogid_Z");
         return  ;
      }

      public bool gxTv_SdtBoletosLog_Boletoslogid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosId_Z" )]
      [  XmlElement( ElementName = "BoletosId_Z"   )]
      public int gxTpr_Boletosid_Z
      {
         get {
            return gxTv_SdtBoletosLog_Boletosid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoletosLog_Boletosid_Z = value;
            SetDirty("Boletosid_Z");
         }

      }

      public void gxTv_SdtBoletosLog_Boletosid_Z_SetNull( )
      {
         gxTv_SdtBoletosLog_Boletosid_Z = 0;
         SetDirty("Boletosid_Z");
         return  ;
      }

      public bool gxTv_SdtBoletosLog_Boletosid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosLogOperacao_Z" )]
      [  XmlElement( ElementName = "BoletosLogOperacao_Z"   )]
      public string gxTpr_Boletoslogoperacao_Z
      {
         get {
            return gxTv_SdtBoletosLog_Boletoslogoperacao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoletosLog_Boletoslogoperacao_Z = value;
            SetDirty("Boletoslogoperacao_Z");
         }

      }

      public void gxTv_SdtBoletosLog_Boletoslogoperacao_Z_SetNull( )
      {
         gxTv_SdtBoletosLog_Boletoslogoperacao_Z = "";
         SetDirty("Boletoslogoperacao_Z");
         return  ;
      }

      public bool gxTv_SdtBoletosLog_Boletoslogoperacao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosLogStatusAnterior_Z" )]
      [  XmlElement( ElementName = "BoletosLogStatusAnterior_Z"   )]
      public string gxTpr_Boletoslogstatusanterior_Z
      {
         get {
            return gxTv_SdtBoletosLog_Boletoslogstatusanterior_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoletosLog_Boletoslogstatusanterior_Z = value;
            SetDirty("Boletoslogstatusanterior_Z");
         }

      }

      public void gxTv_SdtBoletosLog_Boletoslogstatusanterior_Z_SetNull( )
      {
         gxTv_SdtBoletosLog_Boletoslogstatusanterior_Z = "";
         SetDirty("Boletoslogstatusanterior_Z");
         return  ;
      }

      public bool gxTv_SdtBoletosLog_Boletoslogstatusanterior_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosLogStatusNovo_Z" )]
      [  XmlElement( ElementName = "BoletosLogStatusNovo_Z"   )]
      public string gxTpr_Boletoslogstatusnovo_Z
      {
         get {
            return gxTv_SdtBoletosLog_Boletoslogstatusnovo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoletosLog_Boletoslogstatusnovo_Z = value;
            SetDirty("Boletoslogstatusnovo_Z");
         }

      }

      public void gxTv_SdtBoletosLog_Boletoslogstatusnovo_Z_SetNull( )
      {
         gxTv_SdtBoletosLog_Boletoslogstatusnovo_Z = "";
         SetDirty("Boletoslogstatusnovo_Z");
         return  ;
      }

      public bool gxTv_SdtBoletosLog_Boletoslogstatusnovo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosLogCodigoHttp_Z" )]
      [  XmlElement( ElementName = "BoletosLogCodigoHttp_Z"   )]
      public short gxTpr_Boletoslogcodigohttp_Z
      {
         get {
            return gxTv_SdtBoletosLog_Boletoslogcodigohttp_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoletosLog_Boletoslogcodigohttp_Z = value;
            SetDirty("Boletoslogcodigohttp_Z");
         }

      }

      public void gxTv_SdtBoletosLog_Boletoslogcodigohttp_Z_SetNull( )
      {
         gxTv_SdtBoletosLog_Boletoslogcodigohttp_Z = 0;
         SetDirty("Boletoslogcodigohttp_Z");
         return  ;
      }

      public bool gxTv_SdtBoletosLog_Boletoslogcodigohttp_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosLogSucesso_Z" )]
      [  XmlElement( ElementName = "BoletosLogSucesso_Z"   )]
      public bool gxTpr_Boletoslogsucesso_Z
      {
         get {
            return gxTv_SdtBoletosLog_Boletoslogsucesso_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoletosLog_Boletoslogsucesso_Z = value;
            SetDirty("Boletoslogsucesso_Z");
         }

      }

      public void gxTv_SdtBoletosLog_Boletoslogsucesso_Z_SetNull( )
      {
         gxTv_SdtBoletosLog_Boletoslogsucesso_Z = false;
         SetDirty("Boletoslogsucesso_Z");
         return  ;
      }

      public bool gxTv_SdtBoletosLog_Boletoslogsucesso_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosLogObservacao_Z" )]
      [  XmlElement( ElementName = "BoletosLogObservacao_Z"   )]
      public string gxTpr_Boletoslogobservacao_Z
      {
         get {
            return gxTv_SdtBoletosLog_Boletoslogobservacao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoletosLog_Boletoslogobservacao_Z = value;
            SetDirty("Boletoslogobservacao_Z");
         }

      }

      public void gxTv_SdtBoletosLog_Boletoslogobservacao_Z_SetNull( )
      {
         gxTv_SdtBoletosLog_Boletoslogobservacao_Z = "";
         SetDirty("Boletoslogobservacao_Z");
         return  ;
      }

      public bool gxTv_SdtBoletosLog_Boletoslogobservacao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosLogCreatedAt_Z" )]
      [  XmlElement( ElementName = "BoletosLogCreatedAt_Z"  , IsNullable=true )]
      public string gxTpr_Boletoslogcreatedat_Z_Nullable
      {
         get {
            if ( gxTv_SdtBoletosLog_Boletoslogcreatedat_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtBoletosLog_Boletoslogcreatedat_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtBoletosLog_Boletoslogcreatedat_Z = DateTime.MinValue;
            else
               gxTv_SdtBoletosLog_Boletoslogcreatedat_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Boletoslogcreatedat_Z
      {
         get {
            return gxTv_SdtBoletosLog_Boletoslogcreatedat_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoletosLog_Boletoslogcreatedat_Z = value;
            SetDirty("Boletoslogcreatedat_Z");
         }

      }

      public void gxTv_SdtBoletosLog_Boletoslogcreatedat_Z_SetNull( )
      {
         gxTv_SdtBoletosLog_Boletoslogcreatedat_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Boletoslogcreatedat_Z");
         return  ;
      }

      public bool gxTv_SdtBoletosLog_Boletoslogcreatedat_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosId_N" )]
      [  XmlElement( ElementName = "BoletosId_N"   )]
      public short gxTpr_Boletosid_N
      {
         get {
            return gxTv_SdtBoletosLog_Boletosid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoletosLog_Boletosid_N = value;
            SetDirty("Boletosid_N");
         }

      }

      public void gxTv_SdtBoletosLog_Boletosid_N_SetNull( )
      {
         gxTv_SdtBoletosLog_Boletosid_N = 0;
         SetDirty("Boletosid_N");
         return  ;
      }

      public bool gxTv_SdtBoletosLog_Boletosid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosLogOperacao_N" )]
      [  XmlElement( ElementName = "BoletosLogOperacao_N"   )]
      public short gxTpr_Boletoslogoperacao_N
      {
         get {
            return gxTv_SdtBoletosLog_Boletoslogoperacao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoletosLog_Boletoslogoperacao_N = value;
            SetDirty("Boletoslogoperacao_N");
         }

      }

      public void gxTv_SdtBoletosLog_Boletoslogoperacao_N_SetNull( )
      {
         gxTv_SdtBoletosLog_Boletoslogoperacao_N = 0;
         SetDirty("Boletoslogoperacao_N");
         return  ;
      }

      public bool gxTv_SdtBoletosLog_Boletoslogoperacao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosLogStatusAnterior_N" )]
      [  XmlElement( ElementName = "BoletosLogStatusAnterior_N"   )]
      public short gxTpr_Boletoslogstatusanterior_N
      {
         get {
            return gxTv_SdtBoletosLog_Boletoslogstatusanterior_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoletosLog_Boletoslogstatusanterior_N = value;
            SetDirty("Boletoslogstatusanterior_N");
         }

      }

      public void gxTv_SdtBoletosLog_Boletoslogstatusanterior_N_SetNull( )
      {
         gxTv_SdtBoletosLog_Boletoslogstatusanterior_N = 0;
         SetDirty("Boletoslogstatusanterior_N");
         return  ;
      }

      public bool gxTv_SdtBoletosLog_Boletoslogstatusanterior_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosLogStatusNovo_N" )]
      [  XmlElement( ElementName = "BoletosLogStatusNovo_N"   )]
      public short gxTpr_Boletoslogstatusnovo_N
      {
         get {
            return gxTv_SdtBoletosLog_Boletoslogstatusnovo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoletosLog_Boletoslogstatusnovo_N = value;
            SetDirty("Boletoslogstatusnovo_N");
         }

      }

      public void gxTv_SdtBoletosLog_Boletoslogstatusnovo_N_SetNull( )
      {
         gxTv_SdtBoletosLog_Boletoslogstatusnovo_N = 0;
         SetDirty("Boletoslogstatusnovo_N");
         return  ;
      }

      public bool gxTv_SdtBoletosLog_Boletoslogstatusnovo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosLogRequisicao_N" )]
      [  XmlElement( ElementName = "BoletosLogRequisicao_N"   )]
      public short gxTpr_Boletoslogrequisicao_N
      {
         get {
            return gxTv_SdtBoletosLog_Boletoslogrequisicao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoletosLog_Boletoslogrequisicao_N = value;
            SetDirty("Boletoslogrequisicao_N");
         }

      }

      public void gxTv_SdtBoletosLog_Boletoslogrequisicao_N_SetNull( )
      {
         gxTv_SdtBoletosLog_Boletoslogrequisicao_N = 0;
         SetDirty("Boletoslogrequisicao_N");
         return  ;
      }

      public bool gxTv_SdtBoletosLog_Boletoslogrequisicao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosLogResponse_N" )]
      [  XmlElement( ElementName = "BoletosLogResponse_N"   )]
      public short gxTpr_Boletoslogresponse_N
      {
         get {
            return gxTv_SdtBoletosLog_Boletoslogresponse_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoletosLog_Boletoslogresponse_N = value;
            SetDirty("Boletoslogresponse_N");
         }

      }

      public void gxTv_SdtBoletosLog_Boletoslogresponse_N_SetNull( )
      {
         gxTv_SdtBoletosLog_Boletoslogresponse_N = 0;
         SetDirty("Boletoslogresponse_N");
         return  ;
      }

      public bool gxTv_SdtBoletosLog_Boletoslogresponse_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosLogCodigoHttp_N" )]
      [  XmlElement( ElementName = "BoletosLogCodigoHttp_N"   )]
      public short gxTpr_Boletoslogcodigohttp_N
      {
         get {
            return gxTv_SdtBoletosLog_Boletoslogcodigohttp_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoletosLog_Boletoslogcodigohttp_N = value;
            SetDirty("Boletoslogcodigohttp_N");
         }

      }

      public void gxTv_SdtBoletosLog_Boletoslogcodigohttp_N_SetNull( )
      {
         gxTv_SdtBoletosLog_Boletoslogcodigohttp_N = 0;
         SetDirty("Boletoslogcodigohttp_N");
         return  ;
      }

      public bool gxTv_SdtBoletosLog_Boletoslogcodigohttp_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosLogSucesso_N" )]
      [  XmlElement( ElementName = "BoletosLogSucesso_N"   )]
      public short gxTpr_Boletoslogsucesso_N
      {
         get {
            return gxTv_SdtBoletosLog_Boletoslogsucesso_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoletosLog_Boletoslogsucesso_N = value;
            SetDirty("Boletoslogsucesso_N");
         }

      }

      public void gxTv_SdtBoletosLog_Boletoslogsucesso_N_SetNull( )
      {
         gxTv_SdtBoletosLog_Boletoslogsucesso_N = 0;
         SetDirty("Boletoslogsucesso_N");
         return  ;
      }

      public bool gxTv_SdtBoletosLog_Boletoslogsucesso_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosLogObservacao_N" )]
      [  XmlElement( ElementName = "BoletosLogObservacao_N"   )]
      public short gxTpr_Boletoslogobservacao_N
      {
         get {
            return gxTv_SdtBoletosLog_Boletoslogobservacao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoletosLog_Boletoslogobservacao_N = value;
            SetDirty("Boletoslogobservacao_N");
         }

      }

      public void gxTv_SdtBoletosLog_Boletoslogobservacao_N_SetNull( )
      {
         gxTv_SdtBoletosLog_Boletoslogobservacao_N = 0;
         SetDirty("Boletoslogobservacao_N");
         return  ;
      }

      public bool gxTv_SdtBoletosLog_Boletoslogobservacao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosLogCreatedAt_N" )]
      [  XmlElement( ElementName = "BoletosLogCreatedAt_N"   )]
      public short gxTpr_Boletoslogcreatedat_N
      {
         get {
            return gxTv_SdtBoletosLog_Boletoslogcreatedat_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoletosLog_Boletoslogcreatedat_N = value;
            SetDirty("Boletoslogcreatedat_N");
         }

      }

      public void gxTv_SdtBoletosLog_Boletoslogcreatedat_N_SetNull( )
      {
         gxTv_SdtBoletosLog_Boletoslogcreatedat_N = 0;
         SetDirty("Boletoslogcreatedat_N");
         return  ;
      }

      public bool gxTv_SdtBoletosLog_Boletoslogcreatedat_N_IsNull( )
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
         gxTv_SdtBoletosLog_Boletoslogoperacao = "";
         gxTv_SdtBoletosLog_Boletoslogstatusanterior = "";
         gxTv_SdtBoletosLog_Boletoslogstatusnovo = "";
         gxTv_SdtBoletosLog_Boletoslogrequisicao = "";
         gxTv_SdtBoletosLog_Boletoslogresponse = "";
         gxTv_SdtBoletosLog_Boletoslogobservacao = "";
         gxTv_SdtBoletosLog_Boletoslogcreatedat = (DateTime)(DateTime.MinValue);
         gxTv_SdtBoletosLog_Mode = "";
         gxTv_SdtBoletosLog_Boletoslogoperacao_Z = "";
         gxTv_SdtBoletosLog_Boletoslogstatusanterior_Z = "";
         gxTv_SdtBoletosLog_Boletoslogstatusnovo_Z = "";
         gxTv_SdtBoletosLog_Boletoslogobservacao_Z = "";
         gxTv_SdtBoletosLog_Boletoslogcreatedat_Z = (DateTime)(DateTime.MinValue);
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "boletoslog", "GeneXus.Programs.boletoslog_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtBoletosLog_Boletoslogcodigohttp ;
      private short gxTv_SdtBoletosLog_Initialized ;
      private short gxTv_SdtBoletosLog_Boletoslogcodigohttp_Z ;
      private short gxTv_SdtBoletosLog_Boletosid_N ;
      private short gxTv_SdtBoletosLog_Boletoslogoperacao_N ;
      private short gxTv_SdtBoletosLog_Boletoslogstatusanterior_N ;
      private short gxTv_SdtBoletosLog_Boletoslogstatusnovo_N ;
      private short gxTv_SdtBoletosLog_Boletoslogrequisicao_N ;
      private short gxTv_SdtBoletosLog_Boletoslogresponse_N ;
      private short gxTv_SdtBoletosLog_Boletoslogcodigohttp_N ;
      private short gxTv_SdtBoletosLog_Boletoslogsucesso_N ;
      private short gxTv_SdtBoletosLog_Boletoslogobservacao_N ;
      private short gxTv_SdtBoletosLog_Boletoslogcreatedat_N ;
      private int gxTv_SdtBoletosLog_Boletoslogid ;
      private int gxTv_SdtBoletosLog_Boletosid ;
      private int gxTv_SdtBoletosLog_Boletoslogid_Z ;
      private int gxTv_SdtBoletosLog_Boletosid_Z ;
      private string gxTv_SdtBoletosLog_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtBoletosLog_Boletoslogcreatedat ;
      private DateTime gxTv_SdtBoletosLog_Boletoslogcreatedat_Z ;
      private DateTime datetime_STZ ;
      private bool gxTv_SdtBoletosLog_Boletoslogsucesso ;
      private bool gxTv_SdtBoletosLog_Boletoslogsucesso_Z ;
      private string gxTv_SdtBoletosLog_Boletoslogrequisicao ;
      private string gxTv_SdtBoletosLog_Boletoslogresponse ;
      private string gxTv_SdtBoletosLog_Boletoslogoperacao ;
      private string gxTv_SdtBoletosLog_Boletoslogstatusanterior ;
      private string gxTv_SdtBoletosLog_Boletoslogstatusnovo ;
      private string gxTv_SdtBoletosLog_Boletoslogobservacao ;
      private string gxTv_SdtBoletosLog_Boletoslogoperacao_Z ;
      private string gxTv_SdtBoletosLog_Boletoslogstatusanterior_Z ;
      private string gxTv_SdtBoletosLog_Boletoslogstatusnovo_Z ;
      private string gxTv_SdtBoletosLog_Boletoslogobservacao_Z ;
   }

   [DataContract(Name = @"BoletosLog", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtBoletosLog_RESTInterface : GxGenericCollectionItem<SdtBoletosLog>
   {
      public SdtBoletosLog_RESTInterface( ) : base()
      {
      }

      public SdtBoletosLog_RESTInterface( SdtBoletosLog psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "BoletosLogId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Boletoslogid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Boletoslogid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Boletoslogid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "BoletosId" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Boletosid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Boletosid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Boletosid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "BoletosLogOperacao" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Boletoslogoperacao
      {
         get {
            return sdt.gxTpr_Boletoslogoperacao ;
         }

         set {
            sdt.gxTpr_Boletoslogoperacao = value;
         }

      }

      [DataMember( Name = "BoletosLogStatusAnterior" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Boletoslogstatusanterior
      {
         get {
            return sdt.gxTpr_Boletoslogstatusanterior ;
         }

         set {
            sdt.gxTpr_Boletoslogstatusanterior = value;
         }

      }

      [DataMember( Name = "BoletosLogStatusNovo" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Boletoslogstatusnovo
      {
         get {
            return sdt.gxTpr_Boletoslogstatusnovo ;
         }

         set {
            sdt.gxTpr_Boletoslogstatusnovo = value;
         }

      }

      [DataMember( Name = "BoletosLogRequisicao" , Order = 5 )]
      public string gxTpr_Boletoslogrequisicao
      {
         get {
            return sdt.gxTpr_Boletoslogrequisicao ;
         }

         set {
            sdt.gxTpr_Boletoslogrequisicao = value;
         }

      }

      [DataMember( Name = "BoletosLogResponse" , Order = 6 )]
      public string gxTpr_Boletoslogresponse
      {
         get {
            return sdt.gxTpr_Boletoslogresponse ;
         }

         set {
            sdt.gxTpr_Boletoslogresponse = value;
         }

      }

      [DataMember( Name = "BoletosLogCodigoHttp" , Order = 7 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Boletoslogcodigohttp
      {
         get {
            return sdt.gxTpr_Boletoslogcodigohttp ;
         }

         set {
            sdt.gxTpr_Boletoslogcodigohttp = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "BoletosLogSucesso" , Order = 8 )]
      [GxSeudo()]
      public bool gxTpr_Boletoslogsucesso
      {
         get {
            return sdt.gxTpr_Boletoslogsucesso ;
         }

         set {
            sdt.gxTpr_Boletoslogsucesso = value;
         }

      }

      [DataMember( Name = "BoletosLogObservacao" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Boletoslogobservacao
      {
         get {
            return sdt.gxTpr_Boletoslogobservacao ;
         }

         set {
            sdt.gxTpr_Boletoslogobservacao = value;
         }

      }

      [DataMember( Name = "BoletosLogCreatedAt" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Boletoslogcreatedat
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Boletoslogcreatedat, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Boletoslogcreatedat = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      public SdtBoletosLog sdt
      {
         get {
            return (SdtBoletosLog)Sdt ;
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
            sdt = new SdtBoletosLog() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 11 )]
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

   [DataContract(Name = @"BoletosLog", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtBoletosLog_RESTLInterface : GxGenericCollectionItem<SdtBoletosLog>
   {
      public SdtBoletosLog_RESTLInterface( ) : base()
      {
      }

      public SdtBoletosLog_RESTLInterface( SdtBoletosLog psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "BoletosLogOperacao" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Boletoslogoperacao
      {
         get {
            return sdt.gxTpr_Boletoslogoperacao ;
         }

         set {
            sdt.gxTpr_Boletoslogoperacao = value;
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

      public SdtBoletosLog sdt
      {
         get {
            return (SdtBoletosLog)Sdt ;
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
            sdt = new SdtBoletosLog() ;
         }
      }

   }

}
