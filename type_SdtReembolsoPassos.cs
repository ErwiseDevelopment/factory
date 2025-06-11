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
   [XmlRoot(ElementName = "ReembolsoPassos" )]
   [XmlType(TypeName =  "ReembolsoPassos" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtReembolsoPassos : GxSilentTrnSdt
   {
      public SdtReembolsoPassos( )
      {
      }

      public SdtReembolsoPassos( IGxContext context )
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

      public void Load( short AV738ReembolsoPassos )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV738ReembolsoPassos});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ReembolsoPassos", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "ReembolsoPassos");
         metadata.Set("BT", "ReembolsoPassos");
         metadata.Set("PK", "[ \"ReembolsoPassos\" ]");
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
         state.Add("gxTpr_Reembolsopassos_Z");
         state.Add("gxTpr_Reembolsopassosnome_Z");
         state.Add("gxTpr_Reembolsopassosstatus_Z");
         state.Add("gxTpr_Reembolsopassosslalembrete_Z");
         state.Add("gxTpr_Reembolsopassosnome_N");
         state.Add("gxTpr_Reembolsopassosstatus_N");
         state.Add("gxTpr_Reembolsopassosslalembrete_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtReembolsoPassos sdt;
         sdt = (SdtReembolsoPassos)(source);
         gxTv_SdtReembolsoPassos_Reembolsopassos = sdt.gxTv_SdtReembolsoPassos_Reembolsopassos ;
         gxTv_SdtReembolsoPassos_Reembolsopassosnome = sdt.gxTv_SdtReembolsoPassos_Reembolsopassosnome ;
         gxTv_SdtReembolsoPassos_Reembolsopassosstatus = sdt.gxTv_SdtReembolsoPassos_Reembolsopassosstatus ;
         gxTv_SdtReembolsoPassos_Reembolsopassosslalembrete = sdt.gxTv_SdtReembolsoPassos_Reembolsopassosslalembrete ;
         gxTv_SdtReembolsoPassos_Mode = sdt.gxTv_SdtReembolsoPassos_Mode ;
         gxTv_SdtReembolsoPassos_Initialized = sdt.gxTv_SdtReembolsoPassos_Initialized ;
         gxTv_SdtReembolsoPassos_Reembolsopassos_Z = sdt.gxTv_SdtReembolsoPassos_Reembolsopassos_Z ;
         gxTv_SdtReembolsoPassos_Reembolsopassosnome_Z = sdt.gxTv_SdtReembolsoPassos_Reembolsopassosnome_Z ;
         gxTv_SdtReembolsoPassos_Reembolsopassosstatus_Z = sdt.gxTv_SdtReembolsoPassos_Reembolsopassosstatus_Z ;
         gxTv_SdtReembolsoPassos_Reembolsopassosslalembrete_Z = sdt.gxTv_SdtReembolsoPassos_Reembolsopassosslalembrete_Z ;
         gxTv_SdtReembolsoPassos_Reembolsopassosnome_N = sdt.gxTv_SdtReembolsoPassos_Reembolsopassosnome_N ;
         gxTv_SdtReembolsoPassos_Reembolsopassosstatus_N = sdt.gxTv_SdtReembolsoPassos_Reembolsopassosstatus_N ;
         gxTv_SdtReembolsoPassos_Reembolsopassosslalembrete_N = sdt.gxTv_SdtReembolsoPassos_Reembolsopassosslalembrete_N ;
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
         AddObjectProperty("ReembolsoPassos", gxTv_SdtReembolsoPassos_Reembolsopassos, false, includeNonInitialized);
         AddObjectProperty("ReembolsoPassosNome", gxTv_SdtReembolsoPassos_Reembolsopassosnome, false, includeNonInitialized);
         AddObjectProperty("ReembolsoPassosNome_N", gxTv_SdtReembolsoPassos_Reembolsopassosnome_N, false, includeNonInitialized);
         AddObjectProperty("ReembolsoPassosStatus", gxTv_SdtReembolsoPassos_Reembolsopassosstatus, false, includeNonInitialized);
         AddObjectProperty("ReembolsoPassosStatus_N", gxTv_SdtReembolsoPassos_Reembolsopassosstatus_N, false, includeNonInitialized);
         AddObjectProperty("ReembolsoPassosSLALembrete", gxTv_SdtReembolsoPassos_Reembolsopassosslalembrete, false, includeNonInitialized);
         AddObjectProperty("ReembolsoPassosSLALembrete_N", gxTv_SdtReembolsoPassos_Reembolsopassosslalembrete_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtReembolsoPassos_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtReembolsoPassos_Initialized, false, includeNonInitialized);
            AddObjectProperty("ReembolsoPassos_Z", gxTv_SdtReembolsoPassos_Reembolsopassos_Z, false, includeNonInitialized);
            AddObjectProperty("ReembolsoPassosNome_Z", gxTv_SdtReembolsoPassos_Reembolsopassosnome_Z, false, includeNonInitialized);
            AddObjectProperty("ReembolsoPassosStatus_Z", gxTv_SdtReembolsoPassos_Reembolsopassosstatus_Z, false, includeNonInitialized);
            AddObjectProperty("ReembolsoPassosSLALembrete_Z", gxTv_SdtReembolsoPassos_Reembolsopassosslalembrete_Z, false, includeNonInitialized);
            AddObjectProperty("ReembolsoPassosNome_N", gxTv_SdtReembolsoPassos_Reembolsopassosnome_N, false, includeNonInitialized);
            AddObjectProperty("ReembolsoPassosStatus_N", gxTv_SdtReembolsoPassos_Reembolsopassosstatus_N, false, includeNonInitialized);
            AddObjectProperty("ReembolsoPassosSLALembrete_N", gxTv_SdtReembolsoPassos_Reembolsopassosslalembrete_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtReembolsoPassos sdt )
      {
         if ( sdt.IsDirty("ReembolsoPassos") )
         {
            sdtIsNull = 0;
            gxTv_SdtReembolsoPassos_Reembolsopassos = sdt.gxTv_SdtReembolsoPassos_Reembolsopassos ;
         }
         if ( sdt.IsDirty("ReembolsoPassosNome") )
         {
            gxTv_SdtReembolsoPassos_Reembolsopassosnome_N = (short)(sdt.gxTv_SdtReembolsoPassos_Reembolsopassosnome_N);
            sdtIsNull = 0;
            gxTv_SdtReembolsoPassos_Reembolsopassosnome = sdt.gxTv_SdtReembolsoPassos_Reembolsopassosnome ;
         }
         if ( sdt.IsDirty("ReembolsoPassosStatus") )
         {
            gxTv_SdtReembolsoPassos_Reembolsopassosstatus_N = (short)(sdt.gxTv_SdtReembolsoPassos_Reembolsopassosstatus_N);
            sdtIsNull = 0;
            gxTv_SdtReembolsoPassos_Reembolsopassosstatus = sdt.gxTv_SdtReembolsoPassos_Reembolsopassosstatus ;
         }
         if ( sdt.IsDirty("ReembolsoPassosSLALembrete") )
         {
            gxTv_SdtReembolsoPassos_Reembolsopassosslalembrete_N = (short)(sdt.gxTv_SdtReembolsoPassos_Reembolsopassosslalembrete_N);
            sdtIsNull = 0;
            gxTv_SdtReembolsoPassos_Reembolsopassosslalembrete = sdt.gxTv_SdtReembolsoPassos_Reembolsopassosslalembrete ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ReembolsoPassos" )]
      [  XmlElement( ElementName = "ReembolsoPassos"   )]
      public short gxTpr_Reembolsopassos
      {
         get {
            return gxTv_SdtReembolsoPassos_Reembolsopassos ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtReembolsoPassos_Reembolsopassos != value )
            {
               gxTv_SdtReembolsoPassos_Mode = "INS";
               this.gxTv_SdtReembolsoPassos_Reembolsopassos_Z_SetNull( );
               this.gxTv_SdtReembolsoPassos_Reembolsopassosnome_Z_SetNull( );
               this.gxTv_SdtReembolsoPassos_Reembolsopassosstatus_Z_SetNull( );
               this.gxTv_SdtReembolsoPassos_Reembolsopassosslalembrete_Z_SetNull( );
            }
            gxTv_SdtReembolsoPassos_Reembolsopassos = value;
            SetDirty("Reembolsopassos");
         }

      }

      [  SoapElement( ElementName = "ReembolsoPassosNome" )]
      [  XmlElement( ElementName = "ReembolsoPassosNome"   )]
      public string gxTpr_Reembolsopassosnome
      {
         get {
            return gxTv_SdtReembolsoPassos_Reembolsopassosnome ;
         }

         set {
            gxTv_SdtReembolsoPassos_Reembolsopassosnome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtReembolsoPassos_Reembolsopassosnome = value;
            SetDirty("Reembolsopassosnome");
         }

      }

      public void gxTv_SdtReembolsoPassos_Reembolsopassosnome_SetNull( )
      {
         gxTv_SdtReembolsoPassos_Reembolsopassosnome_N = 1;
         gxTv_SdtReembolsoPassos_Reembolsopassosnome = "";
         SetDirty("Reembolsopassosnome");
         return  ;
      }

      public bool gxTv_SdtReembolsoPassos_Reembolsopassosnome_IsNull( )
      {
         return (gxTv_SdtReembolsoPassos_Reembolsopassosnome_N==1) ;
      }

      [  SoapElement( ElementName = "ReembolsoPassosStatus" )]
      [  XmlElement( ElementName = "ReembolsoPassosStatus"   )]
      public bool gxTpr_Reembolsopassosstatus
      {
         get {
            return gxTv_SdtReembolsoPassos_Reembolsopassosstatus ;
         }

         set {
            gxTv_SdtReembolsoPassos_Reembolsopassosstatus_N = 0;
            sdtIsNull = 0;
            gxTv_SdtReembolsoPassos_Reembolsopassosstatus = value;
            SetDirty("Reembolsopassosstatus");
         }

      }

      public void gxTv_SdtReembolsoPassos_Reembolsopassosstatus_SetNull( )
      {
         gxTv_SdtReembolsoPassos_Reembolsopassosstatus_N = 1;
         gxTv_SdtReembolsoPassos_Reembolsopassosstatus = false;
         SetDirty("Reembolsopassosstatus");
         return  ;
      }

      public bool gxTv_SdtReembolsoPassos_Reembolsopassosstatus_IsNull( )
      {
         return (gxTv_SdtReembolsoPassos_Reembolsopassosstatus_N==1) ;
      }

      [  SoapElement( ElementName = "ReembolsoPassosSLALembrete" )]
      [  XmlElement( ElementName = "ReembolsoPassosSLALembrete"   )]
      public short gxTpr_Reembolsopassosslalembrete
      {
         get {
            return gxTv_SdtReembolsoPassos_Reembolsopassosslalembrete ;
         }

         set {
            gxTv_SdtReembolsoPassos_Reembolsopassosslalembrete_N = 0;
            sdtIsNull = 0;
            gxTv_SdtReembolsoPassos_Reembolsopassosslalembrete = value;
            SetDirty("Reembolsopassosslalembrete");
         }

      }

      public void gxTv_SdtReembolsoPassos_Reembolsopassosslalembrete_SetNull( )
      {
         gxTv_SdtReembolsoPassos_Reembolsopassosslalembrete_N = 1;
         gxTv_SdtReembolsoPassos_Reembolsopassosslalembrete = 0;
         SetDirty("Reembolsopassosslalembrete");
         return  ;
      }

      public bool gxTv_SdtReembolsoPassos_Reembolsopassosslalembrete_IsNull( )
      {
         return (gxTv_SdtReembolsoPassos_Reembolsopassosslalembrete_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtReembolsoPassos_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoPassos_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtReembolsoPassos_Mode_SetNull( )
      {
         gxTv_SdtReembolsoPassos_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtReembolsoPassos_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtReembolsoPassos_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoPassos_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtReembolsoPassos_Initialized_SetNull( )
      {
         gxTv_SdtReembolsoPassos_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtReembolsoPassos_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoPassos_Z" )]
      [  XmlElement( ElementName = "ReembolsoPassos_Z"   )]
      public short gxTpr_Reembolsopassos_Z
      {
         get {
            return gxTv_SdtReembolsoPassos_Reembolsopassos_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoPassos_Reembolsopassos_Z = value;
            SetDirty("Reembolsopassos_Z");
         }

      }

      public void gxTv_SdtReembolsoPassos_Reembolsopassos_Z_SetNull( )
      {
         gxTv_SdtReembolsoPassos_Reembolsopassos_Z = 0;
         SetDirty("Reembolsopassos_Z");
         return  ;
      }

      public bool gxTv_SdtReembolsoPassos_Reembolsopassos_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoPassosNome_Z" )]
      [  XmlElement( ElementName = "ReembolsoPassosNome_Z"   )]
      public string gxTpr_Reembolsopassosnome_Z
      {
         get {
            return gxTv_SdtReembolsoPassos_Reembolsopassosnome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoPassos_Reembolsopassosnome_Z = value;
            SetDirty("Reembolsopassosnome_Z");
         }

      }

      public void gxTv_SdtReembolsoPassos_Reembolsopassosnome_Z_SetNull( )
      {
         gxTv_SdtReembolsoPassos_Reembolsopassosnome_Z = "";
         SetDirty("Reembolsopassosnome_Z");
         return  ;
      }

      public bool gxTv_SdtReembolsoPassos_Reembolsopassosnome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoPassosStatus_Z" )]
      [  XmlElement( ElementName = "ReembolsoPassosStatus_Z"   )]
      public bool gxTpr_Reembolsopassosstatus_Z
      {
         get {
            return gxTv_SdtReembolsoPassos_Reembolsopassosstatus_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoPassos_Reembolsopassosstatus_Z = value;
            SetDirty("Reembolsopassosstatus_Z");
         }

      }

      public void gxTv_SdtReembolsoPassos_Reembolsopassosstatus_Z_SetNull( )
      {
         gxTv_SdtReembolsoPassos_Reembolsopassosstatus_Z = false;
         SetDirty("Reembolsopassosstatus_Z");
         return  ;
      }

      public bool gxTv_SdtReembolsoPassos_Reembolsopassosstatus_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoPassosSLALembrete_Z" )]
      [  XmlElement( ElementName = "ReembolsoPassosSLALembrete_Z"   )]
      public short gxTpr_Reembolsopassosslalembrete_Z
      {
         get {
            return gxTv_SdtReembolsoPassos_Reembolsopassosslalembrete_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoPassos_Reembolsopassosslalembrete_Z = value;
            SetDirty("Reembolsopassosslalembrete_Z");
         }

      }

      public void gxTv_SdtReembolsoPassos_Reembolsopassosslalembrete_Z_SetNull( )
      {
         gxTv_SdtReembolsoPassos_Reembolsopassosslalembrete_Z = 0;
         SetDirty("Reembolsopassosslalembrete_Z");
         return  ;
      }

      public bool gxTv_SdtReembolsoPassos_Reembolsopassosslalembrete_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoPassosNome_N" )]
      [  XmlElement( ElementName = "ReembolsoPassosNome_N"   )]
      public short gxTpr_Reembolsopassosnome_N
      {
         get {
            return gxTv_SdtReembolsoPassos_Reembolsopassosnome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoPassos_Reembolsopassosnome_N = value;
            SetDirty("Reembolsopassosnome_N");
         }

      }

      public void gxTv_SdtReembolsoPassos_Reembolsopassosnome_N_SetNull( )
      {
         gxTv_SdtReembolsoPassos_Reembolsopassosnome_N = 0;
         SetDirty("Reembolsopassosnome_N");
         return  ;
      }

      public bool gxTv_SdtReembolsoPassos_Reembolsopassosnome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoPassosStatus_N" )]
      [  XmlElement( ElementName = "ReembolsoPassosStatus_N"   )]
      public short gxTpr_Reembolsopassosstatus_N
      {
         get {
            return gxTv_SdtReembolsoPassos_Reembolsopassosstatus_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoPassos_Reembolsopassosstatus_N = value;
            SetDirty("Reembolsopassosstatus_N");
         }

      }

      public void gxTv_SdtReembolsoPassos_Reembolsopassosstatus_N_SetNull( )
      {
         gxTv_SdtReembolsoPassos_Reembolsopassosstatus_N = 0;
         SetDirty("Reembolsopassosstatus_N");
         return  ;
      }

      public bool gxTv_SdtReembolsoPassos_Reembolsopassosstatus_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoPassosSLALembrete_N" )]
      [  XmlElement( ElementName = "ReembolsoPassosSLALembrete_N"   )]
      public short gxTpr_Reembolsopassosslalembrete_N
      {
         get {
            return gxTv_SdtReembolsoPassos_Reembolsopassosslalembrete_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoPassos_Reembolsopassosslalembrete_N = value;
            SetDirty("Reembolsopassosslalembrete_N");
         }

      }

      public void gxTv_SdtReembolsoPassos_Reembolsopassosslalembrete_N_SetNull( )
      {
         gxTv_SdtReembolsoPassos_Reembolsopassosslalembrete_N = 0;
         SetDirty("Reembolsopassosslalembrete_N");
         return  ;
      }

      public bool gxTv_SdtReembolsoPassos_Reembolsopassosslalembrete_N_IsNull( )
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
         gxTv_SdtReembolsoPassos_Reembolsopassosnome = "";
         gxTv_SdtReembolsoPassos_Mode = "";
         gxTv_SdtReembolsoPassos_Reembolsopassosnome_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "reembolsopassos", "GeneXus.Programs.reembolsopassos_bc", new Object[] {context}, constructorCallingAssembly);;
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

      private short gxTv_SdtReembolsoPassos_Reembolsopassos ;
      private short sdtIsNull ;
      private short gxTv_SdtReembolsoPassos_Reembolsopassosslalembrete ;
      private short gxTv_SdtReembolsoPassos_Initialized ;
      private short gxTv_SdtReembolsoPassos_Reembolsopassos_Z ;
      private short gxTv_SdtReembolsoPassos_Reembolsopassosslalembrete_Z ;
      private short gxTv_SdtReembolsoPassos_Reembolsopassosnome_N ;
      private short gxTv_SdtReembolsoPassos_Reembolsopassosstatus_N ;
      private short gxTv_SdtReembolsoPassos_Reembolsopassosslalembrete_N ;
      private string gxTv_SdtReembolsoPassos_Mode ;
      private bool gxTv_SdtReembolsoPassos_Reembolsopassosstatus ;
      private bool gxTv_SdtReembolsoPassos_Reembolsopassosstatus_Z ;
      private string gxTv_SdtReembolsoPassos_Reembolsopassosnome ;
      private string gxTv_SdtReembolsoPassos_Reembolsopassosnome_Z ;
   }

   [DataContract(Name = @"ReembolsoPassos", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtReembolsoPassos_RESTInterface : GxGenericCollectionItem<SdtReembolsoPassos>
   {
      public SdtReembolsoPassos_RESTInterface( ) : base()
      {
      }

      public SdtReembolsoPassos_RESTInterface( SdtReembolsoPassos psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ReembolsoPassos" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Reembolsopassos
      {
         get {
            return sdt.gxTpr_Reembolsopassos ;
         }

         set {
            sdt.gxTpr_Reembolsopassos = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ReembolsoPassosNome" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Reembolsopassosnome
      {
         get {
            return sdt.gxTpr_Reembolsopassosnome ;
         }

         set {
            sdt.gxTpr_Reembolsopassosnome = value;
         }

      }

      [DataMember( Name = "ReembolsoPassosStatus" , Order = 2 )]
      [GxSeudo()]
      public bool gxTpr_Reembolsopassosstatus
      {
         get {
            return sdt.gxTpr_Reembolsopassosstatus ;
         }

         set {
            sdt.gxTpr_Reembolsopassosstatus = value;
         }

      }

      [DataMember( Name = "ReembolsoPassosSLALembrete" , Order = 3 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Reembolsopassosslalembrete
      {
         get {
            return sdt.gxTpr_Reembolsopassosslalembrete ;
         }

         set {
            sdt.gxTpr_Reembolsopassosslalembrete = (short)(value.HasValue ? value.Value : 0);
         }

      }

      public SdtReembolsoPassos sdt
      {
         get {
            return (SdtReembolsoPassos)Sdt ;
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
            sdt = new SdtReembolsoPassos() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 4 )]
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

   [DataContract(Name = @"ReembolsoPassos", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtReembolsoPassos_RESTLInterface : GxGenericCollectionItem<SdtReembolsoPassos>
   {
      public SdtReembolsoPassos_RESTLInterface( ) : base()
      {
      }

      public SdtReembolsoPassos_RESTLInterface( SdtReembolsoPassos psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ReembolsoPassosNome" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Reembolsopassosnome
      {
         get {
            return sdt.gxTpr_Reembolsopassosnome ;
         }

         set {
            sdt.gxTpr_Reembolsopassosnome = value;
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

      public SdtReembolsoPassos sdt
      {
         get {
            return (SdtReembolsoPassos)Sdt ;
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
            sdt = new SdtReembolsoPassos() ;
         }
      }

   }

}
