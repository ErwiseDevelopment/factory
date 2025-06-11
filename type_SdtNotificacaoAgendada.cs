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
   [XmlRoot(ElementName = "NotificacaoAgendada" )]
   [XmlType(TypeName =  "NotificacaoAgendada" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtNotificacaoAgendada : GxSilentTrnSdt
   {
      public SdtNotificacaoAgendada( )
      {
      }

      public SdtNotificacaoAgendada( IGxContext context )
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

      public void Load( int AV898NotificacaoAgendadaId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV898NotificacaoAgendadaId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"NotificacaoAgendadaId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "NotificacaoAgendada");
         metadata.Set("BT", "NotificacaoAgendada");
         metadata.Set("PK", "[ \"NotificacaoAgendadaId\" ]");
         metadata.Set("PKAssigned", "[ \"NotificacaoAgendadaId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"LayoutContratoId\" ],\"FKMap\":[ \"NotificacaoAgendadaLayoutId-LayoutContratoId\" ] } ]");
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
         state.Add("gxTpr_Notificacaoagendadaid_Z");
         state.Add("gxTpr_Notificacaoagendadaorigem_Z");
         state.Add("gxTpr_Notificacaoagendadadescricao_Z");
         state.Add("gxTpr_Notificacaoagendadadias_Z");
         state.Add("gxTpr_Notificacaoagendadamomentoenvio_Z");
         state.Add("gxTpr_Notificacaoagendadatipo_Z");
         state.Add("gxTpr_Notificacaoagendadalayoutid_Z");
         state.Add("gxTpr_Notificacaoagendadastatus_Z");
         state.Add("gxTpr_Notificacaoagendadaoffsetdias_Z");
         state.Add("gxTpr_Notificacaoagendadadias_N");
         state.Add("gxTpr_Notificacaoagendadamomentoenvio_N");
         state.Add("gxTpr_Notificacaoagendadatipo_N");
         state.Add("gxTpr_Notificacaoagendadalayoutid_N");
         state.Add("gxTpr_Notificacaoagendadastatus_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtNotificacaoAgendada sdt;
         sdt = (SdtNotificacaoAgendada)(source);
         gxTv_SdtNotificacaoAgendada_Notificacaoagendadaid = sdt.gxTv_SdtNotificacaoAgendada_Notificacaoagendadaid ;
         gxTv_SdtNotificacaoAgendada_Notificacaoagendadaorigem = sdt.gxTv_SdtNotificacaoAgendada_Notificacaoagendadaorigem ;
         gxTv_SdtNotificacaoAgendada_Notificacaoagendadadescricao = sdt.gxTv_SdtNotificacaoAgendada_Notificacaoagendadadescricao ;
         gxTv_SdtNotificacaoAgendada_Notificacaoagendadadias = sdt.gxTv_SdtNotificacaoAgendada_Notificacaoagendadadias ;
         gxTv_SdtNotificacaoAgendada_Notificacaoagendadamomentoenvio = sdt.gxTv_SdtNotificacaoAgendada_Notificacaoagendadamomentoenvio ;
         gxTv_SdtNotificacaoAgendada_Notificacaoagendadatipo = sdt.gxTv_SdtNotificacaoAgendada_Notificacaoagendadatipo ;
         gxTv_SdtNotificacaoAgendada_Notificacaoagendadalayoutid = sdt.gxTv_SdtNotificacaoAgendada_Notificacaoagendadalayoutid ;
         gxTv_SdtNotificacaoAgendada_Notificacaoagendadastatus = sdt.gxTv_SdtNotificacaoAgendada_Notificacaoagendadastatus ;
         gxTv_SdtNotificacaoAgendada_Notificacaoagendadaoffsetdias = sdt.gxTv_SdtNotificacaoAgendada_Notificacaoagendadaoffsetdias ;
         gxTv_SdtNotificacaoAgendada_Mode = sdt.gxTv_SdtNotificacaoAgendada_Mode ;
         gxTv_SdtNotificacaoAgendada_Initialized = sdt.gxTv_SdtNotificacaoAgendada_Initialized ;
         gxTv_SdtNotificacaoAgendada_Notificacaoagendadaid_Z = sdt.gxTv_SdtNotificacaoAgendada_Notificacaoagendadaid_Z ;
         gxTv_SdtNotificacaoAgendada_Notificacaoagendadaorigem_Z = sdt.gxTv_SdtNotificacaoAgendada_Notificacaoagendadaorigem_Z ;
         gxTv_SdtNotificacaoAgendada_Notificacaoagendadadescricao_Z = sdt.gxTv_SdtNotificacaoAgendada_Notificacaoagendadadescricao_Z ;
         gxTv_SdtNotificacaoAgendada_Notificacaoagendadadias_Z = sdt.gxTv_SdtNotificacaoAgendada_Notificacaoagendadadias_Z ;
         gxTv_SdtNotificacaoAgendada_Notificacaoagendadamomentoenvio_Z = sdt.gxTv_SdtNotificacaoAgendada_Notificacaoagendadamomentoenvio_Z ;
         gxTv_SdtNotificacaoAgendada_Notificacaoagendadatipo_Z = sdt.gxTv_SdtNotificacaoAgendada_Notificacaoagendadatipo_Z ;
         gxTv_SdtNotificacaoAgendada_Notificacaoagendadalayoutid_Z = sdt.gxTv_SdtNotificacaoAgendada_Notificacaoagendadalayoutid_Z ;
         gxTv_SdtNotificacaoAgendada_Notificacaoagendadastatus_Z = sdt.gxTv_SdtNotificacaoAgendada_Notificacaoagendadastatus_Z ;
         gxTv_SdtNotificacaoAgendada_Notificacaoagendadaoffsetdias_Z = sdt.gxTv_SdtNotificacaoAgendada_Notificacaoagendadaoffsetdias_Z ;
         gxTv_SdtNotificacaoAgendada_Notificacaoagendadadias_N = sdt.gxTv_SdtNotificacaoAgendada_Notificacaoagendadadias_N ;
         gxTv_SdtNotificacaoAgendada_Notificacaoagendadamomentoenvio_N = sdt.gxTv_SdtNotificacaoAgendada_Notificacaoagendadamomentoenvio_N ;
         gxTv_SdtNotificacaoAgendada_Notificacaoagendadatipo_N = sdt.gxTv_SdtNotificacaoAgendada_Notificacaoagendadatipo_N ;
         gxTv_SdtNotificacaoAgendada_Notificacaoagendadalayoutid_N = sdt.gxTv_SdtNotificacaoAgendada_Notificacaoagendadalayoutid_N ;
         gxTv_SdtNotificacaoAgendada_Notificacaoagendadastatus_N = sdt.gxTv_SdtNotificacaoAgendada_Notificacaoagendadastatus_N ;
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
         AddObjectProperty("NotificacaoAgendadaId", gxTv_SdtNotificacaoAgendada_Notificacaoagendadaid, false, includeNonInitialized);
         AddObjectProperty("NotificacaoAgendadaOrigem", gxTv_SdtNotificacaoAgendada_Notificacaoagendadaorigem, false, includeNonInitialized);
         AddObjectProperty("NotificacaoAgendadaDescricao", gxTv_SdtNotificacaoAgendada_Notificacaoagendadadescricao, false, includeNonInitialized);
         AddObjectProperty("NotificacaoAgendadaDias", gxTv_SdtNotificacaoAgendada_Notificacaoagendadadias, false, includeNonInitialized);
         AddObjectProperty("NotificacaoAgendadaDias_N", gxTv_SdtNotificacaoAgendada_Notificacaoagendadadias_N, false, includeNonInitialized);
         AddObjectProperty("NotificacaoAgendadaMomentoEnvio", gxTv_SdtNotificacaoAgendada_Notificacaoagendadamomentoenvio, false, includeNonInitialized);
         AddObjectProperty("NotificacaoAgendadaMomentoEnvio_N", gxTv_SdtNotificacaoAgendada_Notificacaoagendadamomentoenvio_N, false, includeNonInitialized);
         AddObjectProperty("NotificacaoAgendadaTipo", gxTv_SdtNotificacaoAgendada_Notificacaoagendadatipo, false, includeNonInitialized);
         AddObjectProperty("NotificacaoAgendadaTipo_N", gxTv_SdtNotificacaoAgendada_Notificacaoagendadatipo_N, false, includeNonInitialized);
         AddObjectProperty("NotificacaoAgendadaLayoutId", gxTv_SdtNotificacaoAgendada_Notificacaoagendadalayoutid, false, includeNonInitialized);
         AddObjectProperty("NotificacaoAgendadaLayoutId_N", gxTv_SdtNotificacaoAgendada_Notificacaoagendadalayoutid_N, false, includeNonInitialized);
         AddObjectProperty("NotificacaoAgendadaStatus", gxTv_SdtNotificacaoAgendada_Notificacaoagendadastatus, false, includeNonInitialized);
         AddObjectProperty("NotificacaoAgendadaStatus_N", gxTv_SdtNotificacaoAgendada_Notificacaoagendadastatus_N, false, includeNonInitialized);
         AddObjectProperty("NotificacaoAgendadaOffsetDias", gxTv_SdtNotificacaoAgendada_Notificacaoagendadaoffsetdias, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtNotificacaoAgendada_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtNotificacaoAgendada_Initialized, false, includeNonInitialized);
            AddObjectProperty("NotificacaoAgendadaId_Z", gxTv_SdtNotificacaoAgendada_Notificacaoagendadaid_Z, false, includeNonInitialized);
            AddObjectProperty("NotificacaoAgendadaOrigem_Z", gxTv_SdtNotificacaoAgendada_Notificacaoagendadaorigem_Z, false, includeNonInitialized);
            AddObjectProperty("NotificacaoAgendadaDescricao_Z", gxTv_SdtNotificacaoAgendada_Notificacaoagendadadescricao_Z, false, includeNonInitialized);
            AddObjectProperty("NotificacaoAgendadaDias_Z", gxTv_SdtNotificacaoAgendada_Notificacaoagendadadias_Z, false, includeNonInitialized);
            AddObjectProperty("NotificacaoAgendadaMomentoEnvio_Z", gxTv_SdtNotificacaoAgendada_Notificacaoagendadamomentoenvio_Z, false, includeNonInitialized);
            AddObjectProperty("NotificacaoAgendadaTipo_Z", gxTv_SdtNotificacaoAgendada_Notificacaoagendadatipo_Z, false, includeNonInitialized);
            AddObjectProperty("NotificacaoAgendadaLayoutId_Z", gxTv_SdtNotificacaoAgendada_Notificacaoagendadalayoutid_Z, false, includeNonInitialized);
            AddObjectProperty("NotificacaoAgendadaStatus_Z", gxTv_SdtNotificacaoAgendada_Notificacaoagendadastatus_Z, false, includeNonInitialized);
            AddObjectProperty("NotificacaoAgendadaOffsetDias_Z", gxTv_SdtNotificacaoAgendada_Notificacaoagendadaoffsetdias_Z, false, includeNonInitialized);
            AddObjectProperty("NotificacaoAgendadaDias_N", gxTv_SdtNotificacaoAgendada_Notificacaoagendadadias_N, false, includeNonInitialized);
            AddObjectProperty("NotificacaoAgendadaMomentoEnvio_N", gxTv_SdtNotificacaoAgendada_Notificacaoagendadamomentoenvio_N, false, includeNonInitialized);
            AddObjectProperty("NotificacaoAgendadaTipo_N", gxTv_SdtNotificacaoAgendada_Notificacaoagendadatipo_N, false, includeNonInitialized);
            AddObjectProperty("NotificacaoAgendadaLayoutId_N", gxTv_SdtNotificacaoAgendada_Notificacaoagendadalayoutid_N, false, includeNonInitialized);
            AddObjectProperty("NotificacaoAgendadaStatus_N", gxTv_SdtNotificacaoAgendada_Notificacaoagendadastatus_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtNotificacaoAgendada sdt )
      {
         if ( sdt.IsDirty("NotificacaoAgendadaId") )
         {
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendada_Notificacaoagendadaid = sdt.gxTv_SdtNotificacaoAgendada_Notificacaoagendadaid ;
         }
         if ( sdt.IsDirty("NotificacaoAgendadaOrigem") )
         {
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendada_Notificacaoagendadaorigem = sdt.gxTv_SdtNotificacaoAgendada_Notificacaoagendadaorigem ;
         }
         if ( sdt.IsDirty("NotificacaoAgendadaDescricao") )
         {
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendada_Notificacaoagendadadescricao = sdt.gxTv_SdtNotificacaoAgendada_Notificacaoagendadadescricao ;
         }
         if ( sdt.IsDirty("NotificacaoAgendadaDias") )
         {
            gxTv_SdtNotificacaoAgendada_Notificacaoagendadadias_N = (short)(sdt.gxTv_SdtNotificacaoAgendada_Notificacaoagendadadias_N);
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendada_Notificacaoagendadadias = sdt.gxTv_SdtNotificacaoAgendada_Notificacaoagendadadias ;
         }
         if ( sdt.IsDirty("NotificacaoAgendadaMomentoEnvio") )
         {
            gxTv_SdtNotificacaoAgendada_Notificacaoagendadamomentoenvio_N = (short)(sdt.gxTv_SdtNotificacaoAgendada_Notificacaoagendadamomentoenvio_N);
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendada_Notificacaoagendadamomentoenvio = sdt.gxTv_SdtNotificacaoAgendada_Notificacaoagendadamomentoenvio ;
         }
         if ( sdt.IsDirty("NotificacaoAgendadaTipo") )
         {
            gxTv_SdtNotificacaoAgendada_Notificacaoagendadatipo_N = (short)(sdt.gxTv_SdtNotificacaoAgendada_Notificacaoagendadatipo_N);
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendada_Notificacaoagendadatipo = sdt.gxTv_SdtNotificacaoAgendada_Notificacaoagendadatipo ;
         }
         if ( sdt.IsDirty("NotificacaoAgendadaLayoutId") )
         {
            gxTv_SdtNotificacaoAgendada_Notificacaoagendadalayoutid_N = (short)(sdt.gxTv_SdtNotificacaoAgendada_Notificacaoagendadalayoutid_N);
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendada_Notificacaoagendadalayoutid = sdt.gxTv_SdtNotificacaoAgendada_Notificacaoagendadalayoutid ;
         }
         if ( sdt.IsDirty("NotificacaoAgendadaStatus") )
         {
            gxTv_SdtNotificacaoAgendada_Notificacaoagendadastatus_N = (short)(sdt.gxTv_SdtNotificacaoAgendada_Notificacaoagendadastatus_N);
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendada_Notificacaoagendadastatus = sdt.gxTv_SdtNotificacaoAgendada_Notificacaoagendadastatus ;
         }
         if ( sdt.IsDirty("NotificacaoAgendadaOffsetDias") )
         {
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendada_Notificacaoagendadaoffsetdias = sdt.gxTv_SdtNotificacaoAgendada_Notificacaoagendadaoffsetdias ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "NotificacaoAgendadaId" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaId"   )]
      public int gxTpr_Notificacaoagendadaid
      {
         get {
            return gxTv_SdtNotificacaoAgendada_Notificacaoagendadaid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtNotificacaoAgendada_Notificacaoagendadaid != value )
            {
               gxTv_SdtNotificacaoAgendada_Mode = "INS";
               this.gxTv_SdtNotificacaoAgendada_Notificacaoagendadaid_Z_SetNull( );
               this.gxTv_SdtNotificacaoAgendada_Notificacaoagendadaorigem_Z_SetNull( );
               this.gxTv_SdtNotificacaoAgendada_Notificacaoagendadadescricao_Z_SetNull( );
               this.gxTv_SdtNotificacaoAgendada_Notificacaoagendadadias_Z_SetNull( );
               this.gxTv_SdtNotificacaoAgendada_Notificacaoagendadamomentoenvio_Z_SetNull( );
               this.gxTv_SdtNotificacaoAgendada_Notificacaoagendadatipo_Z_SetNull( );
               this.gxTv_SdtNotificacaoAgendada_Notificacaoagendadalayoutid_Z_SetNull( );
               this.gxTv_SdtNotificacaoAgendada_Notificacaoagendadastatus_Z_SetNull( );
               this.gxTv_SdtNotificacaoAgendada_Notificacaoagendadaoffsetdias_Z_SetNull( );
            }
            gxTv_SdtNotificacaoAgendada_Notificacaoagendadaid = value;
            SetDirty("Notificacaoagendadaid");
         }

      }

      [  SoapElement( ElementName = "NotificacaoAgendadaOrigem" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaOrigem"   )]
      public string gxTpr_Notificacaoagendadaorigem
      {
         get {
            return gxTv_SdtNotificacaoAgendada_Notificacaoagendadaorigem ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendada_Notificacaoagendadaorigem = value;
            SetDirty("Notificacaoagendadaorigem");
         }

      }

      [  SoapElement( ElementName = "NotificacaoAgendadaDescricao" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaDescricao"   )]
      public string gxTpr_Notificacaoagendadadescricao
      {
         get {
            return gxTv_SdtNotificacaoAgendada_Notificacaoagendadadescricao ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendada_Notificacaoagendadadescricao = value;
            SetDirty("Notificacaoagendadadescricao");
         }

      }

      [  SoapElement( ElementName = "NotificacaoAgendadaDias" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaDias"   )]
      public int gxTpr_Notificacaoagendadadias
      {
         get {
            return gxTv_SdtNotificacaoAgendada_Notificacaoagendadadias ;
         }

         set {
            gxTv_SdtNotificacaoAgendada_Notificacaoagendadadias_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendada_Notificacaoagendadadias = value;
            SetDirty("Notificacaoagendadadias");
         }

      }

      public void gxTv_SdtNotificacaoAgendada_Notificacaoagendadadias_SetNull( )
      {
         gxTv_SdtNotificacaoAgendada_Notificacaoagendadadias_N = 1;
         gxTv_SdtNotificacaoAgendada_Notificacaoagendadadias = 0;
         SetDirty("Notificacaoagendadadias");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendada_Notificacaoagendadadias_IsNull( )
      {
         return (gxTv_SdtNotificacaoAgendada_Notificacaoagendadadias_N==1) ;
      }

      [  SoapElement( ElementName = "NotificacaoAgendadaMomentoEnvio" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaMomentoEnvio"   )]
      public string gxTpr_Notificacaoagendadamomentoenvio
      {
         get {
            return gxTv_SdtNotificacaoAgendada_Notificacaoagendadamomentoenvio ;
         }

         set {
            gxTv_SdtNotificacaoAgendada_Notificacaoagendadamomentoenvio_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendada_Notificacaoagendadamomentoenvio = value;
            SetDirty("Notificacaoagendadamomentoenvio");
         }

      }

      public void gxTv_SdtNotificacaoAgendada_Notificacaoagendadamomentoenvio_SetNull( )
      {
         gxTv_SdtNotificacaoAgendada_Notificacaoagendadamomentoenvio_N = 1;
         gxTv_SdtNotificacaoAgendada_Notificacaoagendadamomentoenvio = "";
         SetDirty("Notificacaoagendadamomentoenvio");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendada_Notificacaoagendadamomentoenvio_IsNull( )
      {
         return (gxTv_SdtNotificacaoAgendada_Notificacaoagendadamomentoenvio_N==1) ;
      }

      [  SoapElement( ElementName = "NotificacaoAgendadaTipo" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaTipo"   )]
      public string gxTpr_Notificacaoagendadatipo
      {
         get {
            return gxTv_SdtNotificacaoAgendada_Notificacaoagendadatipo ;
         }

         set {
            gxTv_SdtNotificacaoAgendada_Notificacaoagendadatipo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendada_Notificacaoagendadatipo = value;
            SetDirty("Notificacaoagendadatipo");
         }

      }

      public void gxTv_SdtNotificacaoAgendada_Notificacaoagendadatipo_SetNull( )
      {
         gxTv_SdtNotificacaoAgendada_Notificacaoagendadatipo_N = 1;
         gxTv_SdtNotificacaoAgendada_Notificacaoagendadatipo = "";
         SetDirty("Notificacaoagendadatipo");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendada_Notificacaoagendadatipo_IsNull( )
      {
         return (gxTv_SdtNotificacaoAgendada_Notificacaoagendadatipo_N==1) ;
      }

      [  SoapElement( ElementName = "NotificacaoAgendadaLayoutId" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaLayoutId"   )]
      public short gxTpr_Notificacaoagendadalayoutid
      {
         get {
            return gxTv_SdtNotificacaoAgendada_Notificacaoagendadalayoutid ;
         }

         set {
            gxTv_SdtNotificacaoAgendada_Notificacaoagendadalayoutid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendada_Notificacaoagendadalayoutid = value;
            SetDirty("Notificacaoagendadalayoutid");
         }

      }

      public void gxTv_SdtNotificacaoAgendada_Notificacaoagendadalayoutid_SetNull( )
      {
         gxTv_SdtNotificacaoAgendada_Notificacaoagendadalayoutid_N = 1;
         gxTv_SdtNotificacaoAgendada_Notificacaoagendadalayoutid = 0;
         SetDirty("Notificacaoagendadalayoutid");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendada_Notificacaoagendadalayoutid_IsNull( )
      {
         return (gxTv_SdtNotificacaoAgendada_Notificacaoagendadalayoutid_N==1) ;
      }

      [  SoapElement( ElementName = "NotificacaoAgendadaStatus" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaStatus"   )]
      public bool gxTpr_Notificacaoagendadastatus
      {
         get {
            return gxTv_SdtNotificacaoAgendada_Notificacaoagendadastatus ;
         }

         set {
            gxTv_SdtNotificacaoAgendada_Notificacaoagendadastatus_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendada_Notificacaoagendadastatus = value;
            SetDirty("Notificacaoagendadastatus");
         }

      }

      public void gxTv_SdtNotificacaoAgendada_Notificacaoagendadastatus_SetNull( )
      {
         gxTv_SdtNotificacaoAgendada_Notificacaoagendadastatus_N = 1;
         gxTv_SdtNotificacaoAgendada_Notificacaoagendadastatus = false;
         SetDirty("Notificacaoagendadastatus");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendada_Notificacaoagendadastatus_IsNull( )
      {
         return (gxTv_SdtNotificacaoAgendada_Notificacaoagendadastatus_N==1) ;
      }

      [  SoapElement( ElementName = "NotificacaoAgendadaOffsetDias" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaOffsetDias"   )]
      public int gxTpr_Notificacaoagendadaoffsetdias
      {
         get {
            return gxTv_SdtNotificacaoAgendada_Notificacaoagendadaoffsetdias ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendada_Notificacaoagendadaoffsetdias = value;
            SetDirty("Notificacaoagendadaoffsetdias");
         }

      }

      public void gxTv_SdtNotificacaoAgendada_Notificacaoagendadaoffsetdias_SetNull( )
      {
         gxTv_SdtNotificacaoAgendada_Notificacaoagendadaoffsetdias = 0;
         SetDirty("Notificacaoagendadaoffsetdias");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendada_Notificacaoagendadaoffsetdias_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtNotificacaoAgendada_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendada_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtNotificacaoAgendada_Mode_SetNull( )
      {
         gxTv_SdtNotificacaoAgendada_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendada_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtNotificacaoAgendada_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendada_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtNotificacaoAgendada_Initialized_SetNull( )
      {
         gxTv_SdtNotificacaoAgendada_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendada_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotificacaoAgendadaId_Z" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaId_Z"   )]
      public int gxTpr_Notificacaoagendadaid_Z
      {
         get {
            return gxTv_SdtNotificacaoAgendada_Notificacaoagendadaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendada_Notificacaoagendadaid_Z = value;
            SetDirty("Notificacaoagendadaid_Z");
         }

      }

      public void gxTv_SdtNotificacaoAgendada_Notificacaoagendadaid_Z_SetNull( )
      {
         gxTv_SdtNotificacaoAgendada_Notificacaoagendadaid_Z = 0;
         SetDirty("Notificacaoagendadaid_Z");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendada_Notificacaoagendadaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotificacaoAgendadaOrigem_Z" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaOrigem_Z"   )]
      public string gxTpr_Notificacaoagendadaorigem_Z
      {
         get {
            return gxTv_SdtNotificacaoAgendada_Notificacaoagendadaorigem_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendada_Notificacaoagendadaorigem_Z = value;
            SetDirty("Notificacaoagendadaorigem_Z");
         }

      }

      public void gxTv_SdtNotificacaoAgendada_Notificacaoagendadaorigem_Z_SetNull( )
      {
         gxTv_SdtNotificacaoAgendada_Notificacaoagendadaorigem_Z = "";
         SetDirty("Notificacaoagendadaorigem_Z");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendada_Notificacaoagendadaorigem_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotificacaoAgendadaDescricao_Z" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaDescricao_Z"   )]
      public string gxTpr_Notificacaoagendadadescricao_Z
      {
         get {
            return gxTv_SdtNotificacaoAgendada_Notificacaoagendadadescricao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendada_Notificacaoagendadadescricao_Z = value;
            SetDirty("Notificacaoagendadadescricao_Z");
         }

      }

      public void gxTv_SdtNotificacaoAgendada_Notificacaoagendadadescricao_Z_SetNull( )
      {
         gxTv_SdtNotificacaoAgendada_Notificacaoagendadadescricao_Z = "";
         SetDirty("Notificacaoagendadadescricao_Z");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendada_Notificacaoagendadadescricao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotificacaoAgendadaDias_Z" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaDias_Z"   )]
      public int gxTpr_Notificacaoagendadadias_Z
      {
         get {
            return gxTv_SdtNotificacaoAgendada_Notificacaoagendadadias_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendada_Notificacaoagendadadias_Z = value;
            SetDirty("Notificacaoagendadadias_Z");
         }

      }

      public void gxTv_SdtNotificacaoAgendada_Notificacaoagendadadias_Z_SetNull( )
      {
         gxTv_SdtNotificacaoAgendada_Notificacaoagendadadias_Z = 0;
         SetDirty("Notificacaoagendadadias_Z");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendada_Notificacaoagendadadias_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotificacaoAgendadaMomentoEnvio_Z" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaMomentoEnvio_Z"   )]
      public string gxTpr_Notificacaoagendadamomentoenvio_Z
      {
         get {
            return gxTv_SdtNotificacaoAgendada_Notificacaoagendadamomentoenvio_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendada_Notificacaoagendadamomentoenvio_Z = value;
            SetDirty("Notificacaoagendadamomentoenvio_Z");
         }

      }

      public void gxTv_SdtNotificacaoAgendada_Notificacaoagendadamomentoenvio_Z_SetNull( )
      {
         gxTv_SdtNotificacaoAgendada_Notificacaoagendadamomentoenvio_Z = "";
         SetDirty("Notificacaoagendadamomentoenvio_Z");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendada_Notificacaoagendadamomentoenvio_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotificacaoAgendadaTipo_Z" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaTipo_Z"   )]
      public string gxTpr_Notificacaoagendadatipo_Z
      {
         get {
            return gxTv_SdtNotificacaoAgendada_Notificacaoagendadatipo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendada_Notificacaoagendadatipo_Z = value;
            SetDirty("Notificacaoagendadatipo_Z");
         }

      }

      public void gxTv_SdtNotificacaoAgendada_Notificacaoagendadatipo_Z_SetNull( )
      {
         gxTv_SdtNotificacaoAgendada_Notificacaoagendadatipo_Z = "";
         SetDirty("Notificacaoagendadatipo_Z");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendada_Notificacaoagendadatipo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotificacaoAgendadaLayoutId_Z" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaLayoutId_Z"   )]
      public short gxTpr_Notificacaoagendadalayoutid_Z
      {
         get {
            return gxTv_SdtNotificacaoAgendada_Notificacaoagendadalayoutid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendada_Notificacaoagendadalayoutid_Z = value;
            SetDirty("Notificacaoagendadalayoutid_Z");
         }

      }

      public void gxTv_SdtNotificacaoAgendada_Notificacaoagendadalayoutid_Z_SetNull( )
      {
         gxTv_SdtNotificacaoAgendada_Notificacaoagendadalayoutid_Z = 0;
         SetDirty("Notificacaoagendadalayoutid_Z");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendada_Notificacaoagendadalayoutid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotificacaoAgendadaStatus_Z" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaStatus_Z"   )]
      public bool gxTpr_Notificacaoagendadastatus_Z
      {
         get {
            return gxTv_SdtNotificacaoAgendada_Notificacaoagendadastatus_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendada_Notificacaoagendadastatus_Z = value;
            SetDirty("Notificacaoagendadastatus_Z");
         }

      }

      public void gxTv_SdtNotificacaoAgendada_Notificacaoagendadastatus_Z_SetNull( )
      {
         gxTv_SdtNotificacaoAgendada_Notificacaoagendadastatus_Z = false;
         SetDirty("Notificacaoagendadastatus_Z");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendada_Notificacaoagendadastatus_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotificacaoAgendadaOffsetDias_Z" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaOffsetDias_Z"   )]
      public int gxTpr_Notificacaoagendadaoffsetdias_Z
      {
         get {
            return gxTv_SdtNotificacaoAgendada_Notificacaoagendadaoffsetdias_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendada_Notificacaoagendadaoffsetdias_Z = value;
            SetDirty("Notificacaoagendadaoffsetdias_Z");
         }

      }

      public void gxTv_SdtNotificacaoAgendada_Notificacaoagendadaoffsetdias_Z_SetNull( )
      {
         gxTv_SdtNotificacaoAgendada_Notificacaoagendadaoffsetdias_Z = 0;
         SetDirty("Notificacaoagendadaoffsetdias_Z");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendada_Notificacaoagendadaoffsetdias_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotificacaoAgendadaDias_N" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaDias_N"   )]
      public short gxTpr_Notificacaoagendadadias_N
      {
         get {
            return gxTv_SdtNotificacaoAgendada_Notificacaoagendadadias_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendada_Notificacaoagendadadias_N = value;
            SetDirty("Notificacaoagendadadias_N");
         }

      }

      public void gxTv_SdtNotificacaoAgendada_Notificacaoagendadadias_N_SetNull( )
      {
         gxTv_SdtNotificacaoAgendada_Notificacaoagendadadias_N = 0;
         SetDirty("Notificacaoagendadadias_N");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendada_Notificacaoagendadadias_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotificacaoAgendadaMomentoEnvio_N" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaMomentoEnvio_N"   )]
      public short gxTpr_Notificacaoagendadamomentoenvio_N
      {
         get {
            return gxTv_SdtNotificacaoAgendada_Notificacaoagendadamomentoenvio_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendada_Notificacaoagendadamomentoenvio_N = value;
            SetDirty("Notificacaoagendadamomentoenvio_N");
         }

      }

      public void gxTv_SdtNotificacaoAgendada_Notificacaoagendadamomentoenvio_N_SetNull( )
      {
         gxTv_SdtNotificacaoAgendada_Notificacaoagendadamomentoenvio_N = 0;
         SetDirty("Notificacaoagendadamomentoenvio_N");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendada_Notificacaoagendadamomentoenvio_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotificacaoAgendadaTipo_N" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaTipo_N"   )]
      public short gxTpr_Notificacaoagendadatipo_N
      {
         get {
            return gxTv_SdtNotificacaoAgendada_Notificacaoagendadatipo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendada_Notificacaoagendadatipo_N = value;
            SetDirty("Notificacaoagendadatipo_N");
         }

      }

      public void gxTv_SdtNotificacaoAgendada_Notificacaoagendadatipo_N_SetNull( )
      {
         gxTv_SdtNotificacaoAgendada_Notificacaoagendadatipo_N = 0;
         SetDirty("Notificacaoagendadatipo_N");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendada_Notificacaoagendadatipo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotificacaoAgendadaLayoutId_N" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaLayoutId_N"   )]
      public short gxTpr_Notificacaoagendadalayoutid_N
      {
         get {
            return gxTv_SdtNotificacaoAgendada_Notificacaoagendadalayoutid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendada_Notificacaoagendadalayoutid_N = value;
            SetDirty("Notificacaoagendadalayoutid_N");
         }

      }

      public void gxTv_SdtNotificacaoAgendada_Notificacaoagendadalayoutid_N_SetNull( )
      {
         gxTv_SdtNotificacaoAgendada_Notificacaoagendadalayoutid_N = 0;
         SetDirty("Notificacaoagendadalayoutid_N");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendada_Notificacaoagendadalayoutid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotificacaoAgendadaStatus_N" )]
      [  XmlElement( ElementName = "NotificacaoAgendadaStatus_N"   )]
      public short gxTpr_Notificacaoagendadastatus_N
      {
         get {
            return gxTv_SdtNotificacaoAgendada_Notificacaoagendadastatus_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotificacaoAgendada_Notificacaoagendadastatus_N = value;
            SetDirty("Notificacaoagendadastatus_N");
         }

      }

      public void gxTv_SdtNotificacaoAgendada_Notificacaoagendadastatus_N_SetNull( )
      {
         gxTv_SdtNotificacaoAgendada_Notificacaoagendadastatus_N = 0;
         SetDirty("Notificacaoagendadastatus_N");
         return  ;
      }

      public bool gxTv_SdtNotificacaoAgendada_Notificacaoagendadastatus_N_IsNull( )
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
         gxTv_SdtNotificacaoAgendada_Notificacaoagendadaorigem = "";
         gxTv_SdtNotificacaoAgendada_Notificacaoagendadadescricao = "";
         gxTv_SdtNotificacaoAgendada_Notificacaoagendadamomentoenvio = "";
         gxTv_SdtNotificacaoAgendada_Notificacaoagendadatipo = "";
         gxTv_SdtNotificacaoAgendada_Mode = "";
         gxTv_SdtNotificacaoAgendada_Notificacaoagendadaorigem_Z = "";
         gxTv_SdtNotificacaoAgendada_Notificacaoagendadadescricao_Z = "";
         gxTv_SdtNotificacaoAgendada_Notificacaoagendadamomentoenvio_Z = "";
         gxTv_SdtNotificacaoAgendada_Notificacaoagendadatipo_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "notificacaoagendada", "GeneXus.Programs.notificacaoagendada_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtNotificacaoAgendada_Notificacaoagendadalayoutid ;
      private short gxTv_SdtNotificacaoAgendada_Initialized ;
      private short gxTv_SdtNotificacaoAgendada_Notificacaoagendadalayoutid_Z ;
      private short gxTv_SdtNotificacaoAgendada_Notificacaoagendadadias_N ;
      private short gxTv_SdtNotificacaoAgendada_Notificacaoagendadamomentoenvio_N ;
      private short gxTv_SdtNotificacaoAgendada_Notificacaoagendadatipo_N ;
      private short gxTv_SdtNotificacaoAgendada_Notificacaoagendadalayoutid_N ;
      private short gxTv_SdtNotificacaoAgendada_Notificacaoagendadastatus_N ;
      private int gxTv_SdtNotificacaoAgendada_Notificacaoagendadaid ;
      private int gxTv_SdtNotificacaoAgendada_Notificacaoagendadadias ;
      private int gxTv_SdtNotificacaoAgendada_Notificacaoagendadaoffsetdias ;
      private int gxTv_SdtNotificacaoAgendada_Notificacaoagendadaid_Z ;
      private int gxTv_SdtNotificacaoAgendada_Notificacaoagendadadias_Z ;
      private int gxTv_SdtNotificacaoAgendada_Notificacaoagendadaoffsetdias_Z ;
      private string gxTv_SdtNotificacaoAgendada_Mode ;
      private bool gxTv_SdtNotificacaoAgendada_Notificacaoagendadastatus ;
      private bool gxTv_SdtNotificacaoAgendada_Notificacaoagendadastatus_Z ;
      private string gxTv_SdtNotificacaoAgendada_Notificacaoagendadaorigem ;
      private string gxTv_SdtNotificacaoAgendada_Notificacaoagendadadescricao ;
      private string gxTv_SdtNotificacaoAgendada_Notificacaoagendadamomentoenvio ;
      private string gxTv_SdtNotificacaoAgendada_Notificacaoagendadatipo ;
      private string gxTv_SdtNotificacaoAgendada_Notificacaoagendadaorigem_Z ;
      private string gxTv_SdtNotificacaoAgendada_Notificacaoagendadadescricao_Z ;
      private string gxTv_SdtNotificacaoAgendada_Notificacaoagendadamomentoenvio_Z ;
      private string gxTv_SdtNotificacaoAgendada_Notificacaoagendadatipo_Z ;
   }

   [DataContract(Name = @"NotificacaoAgendada", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtNotificacaoAgendada_RESTInterface : GxGenericCollectionItem<SdtNotificacaoAgendada>
   {
      public SdtNotificacaoAgendada_RESTInterface( ) : base()
      {
      }

      public SdtNotificacaoAgendada_RESTInterface( SdtNotificacaoAgendada psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "NotificacaoAgendadaId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Notificacaoagendadaid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Notificacaoagendadaid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Notificacaoagendadaid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "NotificacaoAgendadaOrigem" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Notificacaoagendadaorigem
      {
         get {
            return sdt.gxTpr_Notificacaoagendadaorigem ;
         }

         set {
            sdt.gxTpr_Notificacaoagendadaorigem = value;
         }

      }

      [DataMember( Name = "NotificacaoAgendadaDescricao" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Notificacaoagendadadescricao
      {
         get {
            return sdt.gxTpr_Notificacaoagendadadescricao ;
         }

         set {
            sdt.gxTpr_Notificacaoagendadadescricao = value;
         }

      }

      [DataMember( Name = "NotificacaoAgendadaDias" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Notificacaoagendadadias
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Notificacaoagendadadias), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Notificacaoagendadadias = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "NotificacaoAgendadaMomentoEnvio" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Notificacaoagendadamomentoenvio
      {
         get {
            return sdt.gxTpr_Notificacaoagendadamomentoenvio ;
         }

         set {
            sdt.gxTpr_Notificacaoagendadamomentoenvio = value;
         }

      }

      [DataMember( Name = "NotificacaoAgendadaTipo" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Notificacaoagendadatipo
      {
         get {
            return sdt.gxTpr_Notificacaoagendadatipo ;
         }

         set {
            sdt.gxTpr_Notificacaoagendadatipo = value;
         }

      }

      [DataMember( Name = "NotificacaoAgendadaLayoutId" , Order = 6 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Notificacaoagendadalayoutid
      {
         get {
            return sdt.gxTpr_Notificacaoagendadalayoutid ;
         }

         set {
            sdt.gxTpr_Notificacaoagendadalayoutid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "NotificacaoAgendadaStatus" , Order = 7 )]
      [GxSeudo()]
      public bool gxTpr_Notificacaoagendadastatus
      {
         get {
            return sdt.gxTpr_Notificacaoagendadastatus ;
         }

         set {
            sdt.gxTpr_Notificacaoagendadastatus = value;
         }

      }

      [DataMember( Name = "NotificacaoAgendadaOffsetDias" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Notificacaoagendadaoffsetdias
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Notificacaoagendadaoffsetdias), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Notificacaoagendadaoffsetdias = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      public SdtNotificacaoAgendada sdt
      {
         get {
            return (SdtNotificacaoAgendada)Sdt ;
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
            sdt = new SdtNotificacaoAgendada() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 9 )]
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

   [DataContract(Name = @"NotificacaoAgendada", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtNotificacaoAgendada_RESTLInterface : GxGenericCollectionItem<SdtNotificacaoAgendada>
   {
      public SdtNotificacaoAgendada_RESTLInterface( ) : base()
      {
      }

      public SdtNotificacaoAgendada_RESTLInterface( SdtNotificacaoAgendada psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "NotificacaoAgendadaOrigem" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Notificacaoagendadaorigem
      {
         get {
            return sdt.gxTpr_Notificacaoagendadaorigem ;
         }

         set {
            sdt.gxTpr_Notificacaoagendadaorigem = value;
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

      public SdtNotificacaoAgendada sdt
      {
         get {
            return (SdtNotificacaoAgendada)Sdt ;
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
            sdt = new SdtNotificacaoAgendada() ;
         }
      }

   }

}
