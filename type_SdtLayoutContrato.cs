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
   [XmlRoot(ElementName = "LayoutContrato" )]
   [XmlType(TypeName =  "LayoutContrato" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtLayoutContrato : GxSilentTrnSdt
   {
      public SdtLayoutContrato( )
      {
      }

      public SdtLayoutContrato( IGxContext context )
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

      public void Load( short AV154LayoutContratoId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV154LayoutContratoId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"LayoutContratoId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "LayoutContrato");
         metadata.Set("BT", "LayoutContrato");
         metadata.Set("PK", "[ \"LayoutContratoId\" ]");
         metadata.Set("PKAssigned", "[ \"LayoutContratoId\" ]");
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
         state.Add("gxTpr_Layoutcontratoid_Z");
         state.Add("gxTpr_Layoutcontratodescricao_Z");
         state.Add("gxTpr_Layoutcontratostatus_Z");
         state.Add("gxTpr_Layoutcontratotipo_Z");
         state.Add("gxTpr_Layoutcontratotag_Z");
         state.Add("gxTpr_Layoutcontratodescricao_N");
         state.Add("gxTpr_Layoutcontratostatus_N");
         state.Add("gxTpr_Layoutcontratocorpo_N");
         state.Add("gxTpr_Layoutcontratotipo_N");
         state.Add("gxTpr_Layoutcontratotag_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtLayoutContrato sdt;
         sdt = (SdtLayoutContrato)(source);
         gxTv_SdtLayoutContrato_Layoutcontratoid = sdt.gxTv_SdtLayoutContrato_Layoutcontratoid ;
         gxTv_SdtLayoutContrato_Layoutcontratodescricao = sdt.gxTv_SdtLayoutContrato_Layoutcontratodescricao ;
         gxTv_SdtLayoutContrato_Layoutcontratostatus = sdt.gxTv_SdtLayoutContrato_Layoutcontratostatus ;
         gxTv_SdtLayoutContrato_Layoutcontratocorpo = sdt.gxTv_SdtLayoutContrato_Layoutcontratocorpo ;
         gxTv_SdtLayoutContrato_Layoutcontratotipo = sdt.gxTv_SdtLayoutContrato_Layoutcontratotipo ;
         gxTv_SdtLayoutContrato_Layoutcontratotag = sdt.gxTv_SdtLayoutContrato_Layoutcontratotag ;
         gxTv_SdtLayoutContrato_Mode = sdt.gxTv_SdtLayoutContrato_Mode ;
         gxTv_SdtLayoutContrato_Initialized = sdt.gxTv_SdtLayoutContrato_Initialized ;
         gxTv_SdtLayoutContrato_Layoutcontratoid_Z = sdt.gxTv_SdtLayoutContrato_Layoutcontratoid_Z ;
         gxTv_SdtLayoutContrato_Layoutcontratodescricao_Z = sdt.gxTv_SdtLayoutContrato_Layoutcontratodescricao_Z ;
         gxTv_SdtLayoutContrato_Layoutcontratostatus_Z = sdt.gxTv_SdtLayoutContrato_Layoutcontratostatus_Z ;
         gxTv_SdtLayoutContrato_Layoutcontratotipo_Z = sdt.gxTv_SdtLayoutContrato_Layoutcontratotipo_Z ;
         gxTv_SdtLayoutContrato_Layoutcontratotag_Z = sdt.gxTv_SdtLayoutContrato_Layoutcontratotag_Z ;
         gxTv_SdtLayoutContrato_Layoutcontratodescricao_N = sdt.gxTv_SdtLayoutContrato_Layoutcontratodescricao_N ;
         gxTv_SdtLayoutContrato_Layoutcontratostatus_N = sdt.gxTv_SdtLayoutContrato_Layoutcontratostatus_N ;
         gxTv_SdtLayoutContrato_Layoutcontratocorpo_N = sdt.gxTv_SdtLayoutContrato_Layoutcontratocorpo_N ;
         gxTv_SdtLayoutContrato_Layoutcontratotipo_N = sdt.gxTv_SdtLayoutContrato_Layoutcontratotipo_N ;
         gxTv_SdtLayoutContrato_Layoutcontratotag_N = sdt.gxTv_SdtLayoutContrato_Layoutcontratotag_N ;
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
         AddObjectProperty("LayoutContratoId", gxTv_SdtLayoutContrato_Layoutcontratoid, false, includeNonInitialized);
         AddObjectProperty("LayoutContratoDescricao", gxTv_SdtLayoutContrato_Layoutcontratodescricao, false, includeNonInitialized);
         AddObjectProperty("LayoutContratoDescricao_N", gxTv_SdtLayoutContrato_Layoutcontratodescricao_N, false, includeNonInitialized);
         AddObjectProperty("LayoutContratoStatus", gxTv_SdtLayoutContrato_Layoutcontratostatus, false, includeNonInitialized);
         AddObjectProperty("LayoutContratoStatus_N", gxTv_SdtLayoutContrato_Layoutcontratostatus_N, false, includeNonInitialized);
         AddObjectProperty("LayoutContratoCorpo", gxTv_SdtLayoutContrato_Layoutcontratocorpo, false, includeNonInitialized);
         AddObjectProperty("LayoutContratoCorpo_N", gxTv_SdtLayoutContrato_Layoutcontratocorpo_N, false, includeNonInitialized);
         AddObjectProperty("LayoutContratoTipo", gxTv_SdtLayoutContrato_Layoutcontratotipo, false, includeNonInitialized);
         AddObjectProperty("LayoutContratoTipo_N", gxTv_SdtLayoutContrato_Layoutcontratotipo_N, false, includeNonInitialized);
         AddObjectProperty("LayoutContratoTag", gxTv_SdtLayoutContrato_Layoutcontratotag, false, includeNonInitialized);
         AddObjectProperty("LayoutContratoTag_N", gxTv_SdtLayoutContrato_Layoutcontratotag_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtLayoutContrato_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtLayoutContrato_Initialized, false, includeNonInitialized);
            AddObjectProperty("LayoutContratoId_Z", gxTv_SdtLayoutContrato_Layoutcontratoid_Z, false, includeNonInitialized);
            AddObjectProperty("LayoutContratoDescricao_Z", gxTv_SdtLayoutContrato_Layoutcontratodescricao_Z, false, includeNonInitialized);
            AddObjectProperty("LayoutContratoStatus_Z", gxTv_SdtLayoutContrato_Layoutcontratostatus_Z, false, includeNonInitialized);
            AddObjectProperty("LayoutContratoTipo_Z", gxTv_SdtLayoutContrato_Layoutcontratotipo_Z, false, includeNonInitialized);
            AddObjectProperty("LayoutContratoTag_Z", gxTv_SdtLayoutContrato_Layoutcontratotag_Z, false, includeNonInitialized);
            AddObjectProperty("LayoutContratoDescricao_N", gxTv_SdtLayoutContrato_Layoutcontratodescricao_N, false, includeNonInitialized);
            AddObjectProperty("LayoutContratoStatus_N", gxTv_SdtLayoutContrato_Layoutcontratostatus_N, false, includeNonInitialized);
            AddObjectProperty("LayoutContratoCorpo_N", gxTv_SdtLayoutContrato_Layoutcontratocorpo_N, false, includeNonInitialized);
            AddObjectProperty("LayoutContratoTipo_N", gxTv_SdtLayoutContrato_Layoutcontratotipo_N, false, includeNonInitialized);
            AddObjectProperty("LayoutContratoTag_N", gxTv_SdtLayoutContrato_Layoutcontratotag_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtLayoutContrato sdt )
      {
         if ( sdt.IsDirty("LayoutContratoId") )
         {
            sdtIsNull = 0;
            gxTv_SdtLayoutContrato_Layoutcontratoid = sdt.gxTv_SdtLayoutContrato_Layoutcontratoid ;
         }
         if ( sdt.IsDirty("LayoutContratoDescricao") )
         {
            gxTv_SdtLayoutContrato_Layoutcontratodescricao_N = (short)(sdt.gxTv_SdtLayoutContrato_Layoutcontratodescricao_N);
            sdtIsNull = 0;
            gxTv_SdtLayoutContrato_Layoutcontratodescricao = sdt.gxTv_SdtLayoutContrato_Layoutcontratodescricao ;
         }
         if ( sdt.IsDirty("LayoutContratoStatus") )
         {
            gxTv_SdtLayoutContrato_Layoutcontratostatus_N = (short)(sdt.gxTv_SdtLayoutContrato_Layoutcontratostatus_N);
            sdtIsNull = 0;
            gxTv_SdtLayoutContrato_Layoutcontratostatus = sdt.gxTv_SdtLayoutContrato_Layoutcontratostatus ;
         }
         if ( sdt.IsDirty("LayoutContratoCorpo") )
         {
            gxTv_SdtLayoutContrato_Layoutcontratocorpo_N = (short)(sdt.gxTv_SdtLayoutContrato_Layoutcontratocorpo_N);
            sdtIsNull = 0;
            gxTv_SdtLayoutContrato_Layoutcontratocorpo = sdt.gxTv_SdtLayoutContrato_Layoutcontratocorpo ;
         }
         if ( sdt.IsDirty("LayoutContratoTipo") )
         {
            gxTv_SdtLayoutContrato_Layoutcontratotipo_N = (short)(sdt.gxTv_SdtLayoutContrato_Layoutcontratotipo_N);
            sdtIsNull = 0;
            gxTv_SdtLayoutContrato_Layoutcontratotipo = sdt.gxTv_SdtLayoutContrato_Layoutcontratotipo ;
         }
         if ( sdt.IsDirty("LayoutContratoTag") )
         {
            gxTv_SdtLayoutContrato_Layoutcontratotag_N = (short)(sdt.gxTv_SdtLayoutContrato_Layoutcontratotag_N);
            sdtIsNull = 0;
            gxTv_SdtLayoutContrato_Layoutcontratotag = sdt.gxTv_SdtLayoutContrato_Layoutcontratotag ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "LayoutContratoId" )]
      [  XmlElement( ElementName = "LayoutContratoId"   )]
      public short gxTpr_Layoutcontratoid
      {
         get {
            return gxTv_SdtLayoutContrato_Layoutcontratoid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtLayoutContrato_Layoutcontratoid != value )
            {
               gxTv_SdtLayoutContrato_Mode = "INS";
               this.gxTv_SdtLayoutContrato_Layoutcontratoid_Z_SetNull( );
               this.gxTv_SdtLayoutContrato_Layoutcontratodescricao_Z_SetNull( );
               this.gxTv_SdtLayoutContrato_Layoutcontratostatus_Z_SetNull( );
               this.gxTv_SdtLayoutContrato_Layoutcontratotipo_Z_SetNull( );
               this.gxTv_SdtLayoutContrato_Layoutcontratotag_Z_SetNull( );
            }
            gxTv_SdtLayoutContrato_Layoutcontratoid = value;
            SetDirty("Layoutcontratoid");
         }

      }

      [  SoapElement( ElementName = "LayoutContratoDescricao" )]
      [  XmlElement( ElementName = "LayoutContratoDescricao"   )]
      public string gxTpr_Layoutcontratodescricao
      {
         get {
            return gxTv_SdtLayoutContrato_Layoutcontratodescricao ;
         }

         set {
            gxTv_SdtLayoutContrato_Layoutcontratodescricao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtLayoutContrato_Layoutcontratodescricao = value;
            SetDirty("Layoutcontratodescricao");
         }

      }

      public void gxTv_SdtLayoutContrato_Layoutcontratodescricao_SetNull( )
      {
         gxTv_SdtLayoutContrato_Layoutcontratodescricao_N = 1;
         gxTv_SdtLayoutContrato_Layoutcontratodescricao = "";
         SetDirty("Layoutcontratodescricao");
         return  ;
      }

      public bool gxTv_SdtLayoutContrato_Layoutcontratodescricao_IsNull( )
      {
         return (gxTv_SdtLayoutContrato_Layoutcontratodescricao_N==1) ;
      }

      [  SoapElement( ElementName = "LayoutContratoStatus" )]
      [  XmlElement( ElementName = "LayoutContratoStatus"   )]
      public bool gxTpr_Layoutcontratostatus
      {
         get {
            return gxTv_SdtLayoutContrato_Layoutcontratostatus ;
         }

         set {
            gxTv_SdtLayoutContrato_Layoutcontratostatus_N = 0;
            sdtIsNull = 0;
            gxTv_SdtLayoutContrato_Layoutcontratostatus = value;
            SetDirty("Layoutcontratostatus");
         }

      }

      public void gxTv_SdtLayoutContrato_Layoutcontratostatus_SetNull( )
      {
         gxTv_SdtLayoutContrato_Layoutcontratostatus_N = 1;
         gxTv_SdtLayoutContrato_Layoutcontratostatus = false;
         SetDirty("Layoutcontratostatus");
         return  ;
      }

      public bool gxTv_SdtLayoutContrato_Layoutcontratostatus_IsNull( )
      {
         return (gxTv_SdtLayoutContrato_Layoutcontratostatus_N==1) ;
      }

      [  SoapElement( ElementName = "LayoutContratoCorpo" )]
      [  XmlElement( ElementName = "LayoutContratoCorpo"   )]
      public string gxTpr_Layoutcontratocorpo
      {
         get {
            return gxTv_SdtLayoutContrato_Layoutcontratocorpo ;
         }

         set {
            gxTv_SdtLayoutContrato_Layoutcontratocorpo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtLayoutContrato_Layoutcontratocorpo = value;
            SetDirty("Layoutcontratocorpo");
         }

      }

      public void gxTv_SdtLayoutContrato_Layoutcontratocorpo_SetNull( )
      {
         gxTv_SdtLayoutContrato_Layoutcontratocorpo_N = 1;
         gxTv_SdtLayoutContrato_Layoutcontratocorpo = "";
         SetDirty("Layoutcontratocorpo");
         return  ;
      }

      public bool gxTv_SdtLayoutContrato_Layoutcontratocorpo_IsNull( )
      {
         return (gxTv_SdtLayoutContrato_Layoutcontratocorpo_N==1) ;
      }

      [  SoapElement( ElementName = "LayoutContratoTipo" )]
      [  XmlElement( ElementName = "LayoutContratoTipo"   )]
      public string gxTpr_Layoutcontratotipo
      {
         get {
            return gxTv_SdtLayoutContrato_Layoutcontratotipo ;
         }

         set {
            gxTv_SdtLayoutContrato_Layoutcontratotipo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtLayoutContrato_Layoutcontratotipo = value;
            SetDirty("Layoutcontratotipo");
         }

      }

      public void gxTv_SdtLayoutContrato_Layoutcontratotipo_SetNull( )
      {
         gxTv_SdtLayoutContrato_Layoutcontratotipo_N = 1;
         gxTv_SdtLayoutContrato_Layoutcontratotipo = "";
         SetDirty("Layoutcontratotipo");
         return  ;
      }

      public bool gxTv_SdtLayoutContrato_Layoutcontratotipo_IsNull( )
      {
         return (gxTv_SdtLayoutContrato_Layoutcontratotipo_N==1) ;
      }

      [  SoapElement( ElementName = "LayoutContratoTag" )]
      [  XmlElement( ElementName = "LayoutContratoTag"   )]
      public string gxTpr_Layoutcontratotag
      {
         get {
            return gxTv_SdtLayoutContrato_Layoutcontratotag ;
         }

         set {
            gxTv_SdtLayoutContrato_Layoutcontratotag_N = 0;
            sdtIsNull = 0;
            gxTv_SdtLayoutContrato_Layoutcontratotag = value;
            SetDirty("Layoutcontratotag");
         }

      }

      public void gxTv_SdtLayoutContrato_Layoutcontratotag_SetNull( )
      {
         gxTv_SdtLayoutContrato_Layoutcontratotag_N = 1;
         gxTv_SdtLayoutContrato_Layoutcontratotag = "";
         SetDirty("Layoutcontratotag");
         return  ;
      }

      public bool gxTv_SdtLayoutContrato_Layoutcontratotag_IsNull( )
      {
         return (gxTv_SdtLayoutContrato_Layoutcontratotag_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtLayoutContrato_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLayoutContrato_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtLayoutContrato_Mode_SetNull( )
      {
         gxTv_SdtLayoutContrato_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtLayoutContrato_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtLayoutContrato_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLayoutContrato_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtLayoutContrato_Initialized_SetNull( )
      {
         gxTv_SdtLayoutContrato_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtLayoutContrato_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LayoutContratoId_Z" )]
      [  XmlElement( ElementName = "LayoutContratoId_Z"   )]
      public short gxTpr_Layoutcontratoid_Z
      {
         get {
            return gxTv_SdtLayoutContrato_Layoutcontratoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLayoutContrato_Layoutcontratoid_Z = value;
            SetDirty("Layoutcontratoid_Z");
         }

      }

      public void gxTv_SdtLayoutContrato_Layoutcontratoid_Z_SetNull( )
      {
         gxTv_SdtLayoutContrato_Layoutcontratoid_Z = 0;
         SetDirty("Layoutcontratoid_Z");
         return  ;
      }

      public bool gxTv_SdtLayoutContrato_Layoutcontratoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LayoutContratoDescricao_Z" )]
      [  XmlElement( ElementName = "LayoutContratoDescricao_Z"   )]
      public string gxTpr_Layoutcontratodescricao_Z
      {
         get {
            return gxTv_SdtLayoutContrato_Layoutcontratodescricao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLayoutContrato_Layoutcontratodescricao_Z = value;
            SetDirty("Layoutcontratodescricao_Z");
         }

      }

      public void gxTv_SdtLayoutContrato_Layoutcontratodescricao_Z_SetNull( )
      {
         gxTv_SdtLayoutContrato_Layoutcontratodescricao_Z = "";
         SetDirty("Layoutcontratodescricao_Z");
         return  ;
      }

      public bool gxTv_SdtLayoutContrato_Layoutcontratodescricao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LayoutContratoStatus_Z" )]
      [  XmlElement( ElementName = "LayoutContratoStatus_Z"   )]
      public bool gxTpr_Layoutcontratostatus_Z
      {
         get {
            return gxTv_SdtLayoutContrato_Layoutcontratostatus_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLayoutContrato_Layoutcontratostatus_Z = value;
            SetDirty("Layoutcontratostatus_Z");
         }

      }

      public void gxTv_SdtLayoutContrato_Layoutcontratostatus_Z_SetNull( )
      {
         gxTv_SdtLayoutContrato_Layoutcontratostatus_Z = false;
         SetDirty("Layoutcontratostatus_Z");
         return  ;
      }

      public bool gxTv_SdtLayoutContrato_Layoutcontratostatus_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LayoutContratoTipo_Z" )]
      [  XmlElement( ElementName = "LayoutContratoTipo_Z"   )]
      public string gxTpr_Layoutcontratotipo_Z
      {
         get {
            return gxTv_SdtLayoutContrato_Layoutcontratotipo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLayoutContrato_Layoutcontratotipo_Z = value;
            SetDirty("Layoutcontratotipo_Z");
         }

      }

      public void gxTv_SdtLayoutContrato_Layoutcontratotipo_Z_SetNull( )
      {
         gxTv_SdtLayoutContrato_Layoutcontratotipo_Z = "";
         SetDirty("Layoutcontratotipo_Z");
         return  ;
      }

      public bool gxTv_SdtLayoutContrato_Layoutcontratotipo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LayoutContratoTag_Z" )]
      [  XmlElement( ElementName = "LayoutContratoTag_Z"   )]
      public string gxTpr_Layoutcontratotag_Z
      {
         get {
            return gxTv_SdtLayoutContrato_Layoutcontratotag_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLayoutContrato_Layoutcontratotag_Z = value;
            SetDirty("Layoutcontratotag_Z");
         }

      }

      public void gxTv_SdtLayoutContrato_Layoutcontratotag_Z_SetNull( )
      {
         gxTv_SdtLayoutContrato_Layoutcontratotag_Z = "";
         SetDirty("Layoutcontratotag_Z");
         return  ;
      }

      public bool gxTv_SdtLayoutContrato_Layoutcontratotag_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LayoutContratoDescricao_N" )]
      [  XmlElement( ElementName = "LayoutContratoDescricao_N"   )]
      public short gxTpr_Layoutcontratodescricao_N
      {
         get {
            return gxTv_SdtLayoutContrato_Layoutcontratodescricao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLayoutContrato_Layoutcontratodescricao_N = value;
            SetDirty("Layoutcontratodescricao_N");
         }

      }

      public void gxTv_SdtLayoutContrato_Layoutcontratodescricao_N_SetNull( )
      {
         gxTv_SdtLayoutContrato_Layoutcontratodescricao_N = 0;
         SetDirty("Layoutcontratodescricao_N");
         return  ;
      }

      public bool gxTv_SdtLayoutContrato_Layoutcontratodescricao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LayoutContratoStatus_N" )]
      [  XmlElement( ElementName = "LayoutContratoStatus_N"   )]
      public short gxTpr_Layoutcontratostatus_N
      {
         get {
            return gxTv_SdtLayoutContrato_Layoutcontratostatus_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLayoutContrato_Layoutcontratostatus_N = value;
            SetDirty("Layoutcontratostatus_N");
         }

      }

      public void gxTv_SdtLayoutContrato_Layoutcontratostatus_N_SetNull( )
      {
         gxTv_SdtLayoutContrato_Layoutcontratostatus_N = 0;
         SetDirty("Layoutcontratostatus_N");
         return  ;
      }

      public bool gxTv_SdtLayoutContrato_Layoutcontratostatus_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LayoutContratoCorpo_N" )]
      [  XmlElement( ElementName = "LayoutContratoCorpo_N"   )]
      public short gxTpr_Layoutcontratocorpo_N
      {
         get {
            return gxTv_SdtLayoutContrato_Layoutcontratocorpo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLayoutContrato_Layoutcontratocorpo_N = value;
            SetDirty("Layoutcontratocorpo_N");
         }

      }

      public void gxTv_SdtLayoutContrato_Layoutcontratocorpo_N_SetNull( )
      {
         gxTv_SdtLayoutContrato_Layoutcontratocorpo_N = 0;
         SetDirty("Layoutcontratocorpo_N");
         return  ;
      }

      public bool gxTv_SdtLayoutContrato_Layoutcontratocorpo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LayoutContratoTipo_N" )]
      [  XmlElement( ElementName = "LayoutContratoTipo_N"   )]
      public short gxTpr_Layoutcontratotipo_N
      {
         get {
            return gxTv_SdtLayoutContrato_Layoutcontratotipo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLayoutContrato_Layoutcontratotipo_N = value;
            SetDirty("Layoutcontratotipo_N");
         }

      }

      public void gxTv_SdtLayoutContrato_Layoutcontratotipo_N_SetNull( )
      {
         gxTv_SdtLayoutContrato_Layoutcontratotipo_N = 0;
         SetDirty("Layoutcontratotipo_N");
         return  ;
      }

      public bool gxTv_SdtLayoutContrato_Layoutcontratotipo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LayoutContratoTag_N" )]
      [  XmlElement( ElementName = "LayoutContratoTag_N"   )]
      public short gxTpr_Layoutcontratotag_N
      {
         get {
            return gxTv_SdtLayoutContrato_Layoutcontratotag_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLayoutContrato_Layoutcontratotag_N = value;
            SetDirty("Layoutcontratotag_N");
         }

      }

      public void gxTv_SdtLayoutContrato_Layoutcontratotag_N_SetNull( )
      {
         gxTv_SdtLayoutContrato_Layoutcontratotag_N = 0;
         SetDirty("Layoutcontratotag_N");
         return  ;
      }

      public bool gxTv_SdtLayoutContrato_Layoutcontratotag_N_IsNull( )
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
         gxTv_SdtLayoutContrato_Layoutcontratodescricao = "";
         gxTv_SdtLayoutContrato_Layoutcontratocorpo = "";
         gxTv_SdtLayoutContrato_Layoutcontratotipo = "";
         gxTv_SdtLayoutContrato_Layoutcontratotag = "";
         gxTv_SdtLayoutContrato_Mode = "";
         gxTv_SdtLayoutContrato_Layoutcontratodescricao_Z = "";
         gxTv_SdtLayoutContrato_Layoutcontratotipo_Z = "";
         gxTv_SdtLayoutContrato_Layoutcontratotag_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "layoutcontrato", "GeneXus.Programs.layoutcontrato_bc", new Object[] {context}, constructorCallingAssembly);;
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

      private short gxTv_SdtLayoutContrato_Layoutcontratoid ;
      private short sdtIsNull ;
      private short gxTv_SdtLayoutContrato_Initialized ;
      private short gxTv_SdtLayoutContrato_Layoutcontratoid_Z ;
      private short gxTv_SdtLayoutContrato_Layoutcontratodescricao_N ;
      private short gxTv_SdtLayoutContrato_Layoutcontratostatus_N ;
      private short gxTv_SdtLayoutContrato_Layoutcontratocorpo_N ;
      private short gxTv_SdtLayoutContrato_Layoutcontratotipo_N ;
      private short gxTv_SdtLayoutContrato_Layoutcontratotag_N ;
      private string gxTv_SdtLayoutContrato_Mode ;
      private bool gxTv_SdtLayoutContrato_Layoutcontratostatus ;
      private bool gxTv_SdtLayoutContrato_Layoutcontratostatus_Z ;
      private string gxTv_SdtLayoutContrato_Layoutcontratocorpo ;
      private string gxTv_SdtLayoutContrato_Layoutcontratodescricao ;
      private string gxTv_SdtLayoutContrato_Layoutcontratotipo ;
      private string gxTv_SdtLayoutContrato_Layoutcontratotag ;
      private string gxTv_SdtLayoutContrato_Layoutcontratodescricao_Z ;
      private string gxTv_SdtLayoutContrato_Layoutcontratotipo_Z ;
      private string gxTv_SdtLayoutContrato_Layoutcontratotag_Z ;
   }

   [DataContract(Name = @"LayoutContrato", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtLayoutContrato_RESTInterface : GxGenericCollectionItem<SdtLayoutContrato>
   {
      public SdtLayoutContrato_RESTInterface( ) : base()
      {
      }

      public SdtLayoutContrato_RESTInterface( SdtLayoutContrato psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "LayoutContratoId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Layoutcontratoid
      {
         get {
            return sdt.gxTpr_Layoutcontratoid ;
         }

         set {
            sdt.gxTpr_Layoutcontratoid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "LayoutContratoDescricao" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Layoutcontratodescricao
      {
         get {
            return sdt.gxTpr_Layoutcontratodescricao ;
         }

         set {
            sdt.gxTpr_Layoutcontratodescricao = value;
         }

      }

      [DataMember( Name = "LayoutContratoStatus" , Order = 2 )]
      [GxSeudo()]
      public bool gxTpr_Layoutcontratostatus
      {
         get {
            return sdt.gxTpr_Layoutcontratostatus ;
         }

         set {
            sdt.gxTpr_Layoutcontratostatus = value;
         }

      }

      [DataMember( Name = "LayoutContratoCorpo" , Order = 3 )]
      public string gxTpr_Layoutcontratocorpo
      {
         get {
            return sdt.gxTpr_Layoutcontratocorpo ;
         }

         set {
            sdt.gxTpr_Layoutcontratocorpo = value;
         }

      }

      [DataMember( Name = "LayoutContratoTipo" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Layoutcontratotipo
      {
         get {
            return sdt.gxTpr_Layoutcontratotipo ;
         }

         set {
            sdt.gxTpr_Layoutcontratotipo = value;
         }

      }

      [DataMember( Name = "LayoutContratoTag" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Layoutcontratotag
      {
         get {
            return sdt.gxTpr_Layoutcontratotag ;
         }

         set {
            sdt.gxTpr_Layoutcontratotag = value;
         }

      }

      public SdtLayoutContrato sdt
      {
         get {
            return (SdtLayoutContrato)Sdt ;
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
            sdt = new SdtLayoutContrato() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 6 )]
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

   [DataContract(Name = @"LayoutContrato", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtLayoutContrato_RESTLInterface : GxGenericCollectionItem<SdtLayoutContrato>
   {
      public SdtLayoutContrato_RESTLInterface( ) : base()
      {
      }

      public SdtLayoutContrato_RESTLInterface( SdtLayoutContrato psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "LayoutContratoDescricao" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Layoutcontratodescricao
      {
         get {
            return sdt.gxTpr_Layoutcontratodescricao ;
         }

         set {
            sdt.gxTpr_Layoutcontratodescricao = value;
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

      public SdtLayoutContrato sdt
      {
         get {
            return (SdtLayoutContrato)Sdt ;
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
            sdt = new SdtLayoutContrato() ;
         }
      }

   }

}
