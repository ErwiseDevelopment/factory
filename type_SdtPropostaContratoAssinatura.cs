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
   [XmlRoot(ElementName = "PropostaContratoAssinatura" )]
   [XmlType(TypeName =  "PropostaContratoAssinatura" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtPropostaContratoAssinatura : GxSilentTrnSdt
   {
      public SdtPropostaContratoAssinatura( )
      {
      }

      public SdtPropostaContratoAssinatura( IGxContext context )
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

      public void Load( int AV572PropostaContratoAssinaturaId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV572PropostaContratoAssinaturaId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"PropostaContratoAssinaturaId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "PropostaContratoAssinatura");
         metadata.Set("BT", "PropostaContratoAssinatura");
         metadata.Set("PK", "[ \"PropostaContratoAssinaturaId\" ]");
         metadata.Set("PKAssigned", "[ \"PropostaContratoAssinaturaId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"AssinaturaId\" ],\"FKMap\":[ \"PropostaAssinatura-AssinaturaId\" ] },{ \"FK\":[ \"ContratoId\" ],\"FKMap\":[ \"PropostaContrato-ContratoId\" ] },{ \"FK\":[ \"PropostaId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Propostacontratoassinaturaid_Z");
         state.Add("gxTpr_Propostaid_Z");
         state.Add("gxTpr_Propostacontrato_Z");
         state.Add("gxTpr_Propostaassinatura_Z");
         state.Add("gxTpr_Propostaassinaturastatus_Z");
         state.Add("gxTpr_Propostacontratoassinaturatipo_Z");
         state.Add("gxTpr_Propostacontratoassinaturaid_N");
         state.Add("gxTpr_Propostaid_N");
         state.Add("gxTpr_Propostacontrato_N");
         state.Add("gxTpr_Propostaassinatura_N");
         state.Add("gxTpr_Propostaassinaturastatus_N");
         state.Add("gxTpr_Propostacontratoassinaturatipo_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtPropostaContratoAssinatura sdt;
         sdt = (SdtPropostaContratoAssinatura)(source);
         gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturaid = sdt.gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturaid ;
         gxTv_SdtPropostaContratoAssinatura_Propostaid = sdt.gxTv_SdtPropostaContratoAssinatura_Propostaid ;
         gxTv_SdtPropostaContratoAssinatura_Propostacontrato = sdt.gxTv_SdtPropostaContratoAssinatura_Propostacontrato ;
         gxTv_SdtPropostaContratoAssinatura_Propostaassinatura = sdt.gxTv_SdtPropostaContratoAssinatura_Propostaassinatura ;
         gxTv_SdtPropostaContratoAssinatura_Propostaassinaturastatus = sdt.gxTv_SdtPropostaContratoAssinatura_Propostaassinaturastatus ;
         gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturatipo = sdt.gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturatipo ;
         gxTv_SdtPropostaContratoAssinatura_Mode = sdt.gxTv_SdtPropostaContratoAssinatura_Mode ;
         gxTv_SdtPropostaContratoAssinatura_Initialized = sdt.gxTv_SdtPropostaContratoAssinatura_Initialized ;
         gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturaid_Z = sdt.gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturaid_Z ;
         gxTv_SdtPropostaContratoAssinatura_Propostaid_Z = sdt.gxTv_SdtPropostaContratoAssinatura_Propostaid_Z ;
         gxTv_SdtPropostaContratoAssinatura_Propostacontrato_Z = sdt.gxTv_SdtPropostaContratoAssinatura_Propostacontrato_Z ;
         gxTv_SdtPropostaContratoAssinatura_Propostaassinatura_Z = sdt.gxTv_SdtPropostaContratoAssinatura_Propostaassinatura_Z ;
         gxTv_SdtPropostaContratoAssinatura_Propostaassinaturastatus_Z = sdt.gxTv_SdtPropostaContratoAssinatura_Propostaassinaturastatus_Z ;
         gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturatipo_Z = sdt.gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturatipo_Z ;
         gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturaid_N = sdt.gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturaid_N ;
         gxTv_SdtPropostaContratoAssinatura_Propostaid_N = sdt.gxTv_SdtPropostaContratoAssinatura_Propostaid_N ;
         gxTv_SdtPropostaContratoAssinatura_Propostacontrato_N = sdt.gxTv_SdtPropostaContratoAssinatura_Propostacontrato_N ;
         gxTv_SdtPropostaContratoAssinatura_Propostaassinatura_N = sdt.gxTv_SdtPropostaContratoAssinatura_Propostaassinatura_N ;
         gxTv_SdtPropostaContratoAssinatura_Propostaassinaturastatus_N = sdt.gxTv_SdtPropostaContratoAssinatura_Propostaassinaturastatus_N ;
         gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturatipo_N = sdt.gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturatipo_N ;
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
         AddObjectProperty("PropostaContratoAssinaturaId", gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturaid, false, includeNonInitialized);
         AddObjectProperty("PropostaContratoAssinaturaId_N", gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturaid_N, false, includeNonInitialized);
         AddObjectProperty("PropostaId", gxTv_SdtPropostaContratoAssinatura_Propostaid, false, includeNonInitialized);
         AddObjectProperty("PropostaId_N", gxTv_SdtPropostaContratoAssinatura_Propostaid_N, false, includeNonInitialized);
         AddObjectProperty("PropostaContrato", gxTv_SdtPropostaContratoAssinatura_Propostacontrato, false, includeNonInitialized);
         AddObjectProperty("PropostaContrato_N", gxTv_SdtPropostaContratoAssinatura_Propostacontrato_N, false, includeNonInitialized);
         AddObjectProperty("PropostaAssinatura", gxTv_SdtPropostaContratoAssinatura_Propostaassinatura, false, includeNonInitialized);
         AddObjectProperty("PropostaAssinatura_N", gxTv_SdtPropostaContratoAssinatura_Propostaassinatura_N, false, includeNonInitialized);
         AddObjectProperty("PropostaAssinaturaStatus", gxTv_SdtPropostaContratoAssinatura_Propostaassinaturastatus, false, includeNonInitialized);
         AddObjectProperty("PropostaAssinaturaStatus_N", gxTv_SdtPropostaContratoAssinatura_Propostaassinaturastatus_N, false, includeNonInitialized);
         AddObjectProperty("PropostaContratoAssinaturaTipo", gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturatipo, false, includeNonInitialized);
         AddObjectProperty("PropostaContratoAssinaturaTipo_N", gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturatipo_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtPropostaContratoAssinatura_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtPropostaContratoAssinatura_Initialized, false, includeNonInitialized);
            AddObjectProperty("PropostaContratoAssinaturaId_Z", gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturaid_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaId_Z", gxTv_SdtPropostaContratoAssinatura_Propostaid_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaContrato_Z", gxTv_SdtPropostaContratoAssinatura_Propostacontrato_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaAssinatura_Z", gxTv_SdtPropostaContratoAssinatura_Propostaassinatura_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaAssinaturaStatus_Z", gxTv_SdtPropostaContratoAssinatura_Propostaassinaturastatus_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaContratoAssinaturaTipo_Z", gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturatipo_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaContratoAssinaturaId_N", gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturaid_N, false, includeNonInitialized);
            AddObjectProperty("PropostaId_N", gxTv_SdtPropostaContratoAssinatura_Propostaid_N, false, includeNonInitialized);
            AddObjectProperty("PropostaContrato_N", gxTv_SdtPropostaContratoAssinatura_Propostacontrato_N, false, includeNonInitialized);
            AddObjectProperty("PropostaAssinatura_N", gxTv_SdtPropostaContratoAssinatura_Propostaassinatura_N, false, includeNonInitialized);
            AddObjectProperty("PropostaAssinaturaStatus_N", gxTv_SdtPropostaContratoAssinatura_Propostaassinaturastatus_N, false, includeNonInitialized);
            AddObjectProperty("PropostaContratoAssinaturaTipo_N", gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturatipo_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtPropostaContratoAssinatura sdt )
      {
         if ( sdt.IsDirty("PropostaContratoAssinaturaId") )
         {
            sdtIsNull = 0;
            gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturaid = sdt.gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturaid ;
         }
         if ( sdt.IsDirty("PropostaId") )
         {
            gxTv_SdtPropostaContratoAssinatura_Propostaid_N = (short)(sdt.gxTv_SdtPropostaContratoAssinatura_Propostaid_N);
            sdtIsNull = 0;
            gxTv_SdtPropostaContratoAssinatura_Propostaid = sdt.gxTv_SdtPropostaContratoAssinatura_Propostaid ;
         }
         if ( sdt.IsDirty("PropostaContrato") )
         {
            gxTv_SdtPropostaContratoAssinatura_Propostacontrato_N = (short)(sdt.gxTv_SdtPropostaContratoAssinatura_Propostacontrato_N);
            sdtIsNull = 0;
            gxTv_SdtPropostaContratoAssinatura_Propostacontrato = sdt.gxTv_SdtPropostaContratoAssinatura_Propostacontrato ;
         }
         if ( sdt.IsDirty("PropostaAssinatura") )
         {
            gxTv_SdtPropostaContratoAssinatura_Propostaassinatura_N = (short)(sdt.gxTv_SdtPropostaContratoAssinatura_Propostaassinatura_N);
            sdtIsNull = 0;
            gxTv_SdtPropostaContratoAssinatura_Propostaassinatura = sdt.gxTv_SdtPropostaContratoAssinatura_Propostaassinatura ;
         }
         if ( sdt.IsDirty("PropostaAssinaturaStatus") )
         {
            gxTv_SdtPropostaContratoAssinatura_Propostaassinaturastatus_N = (short)(sdt.gxTv_SdtPropostaContratoAssinatura_Propostaassinaturastatus_N);
            sdtIsNull = 0;
            gxTv_SdtPropostaContratoAssinatura_Propostaassinaturastatus = sdt.gxTv_SdtPropostaContratoAssinatura_Propostaassinaturastatus ;
         }
         if ( sdt.IsDirty("PropostaContratoAssinaturaTipo") )
         {
            gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturatipo_N = (short)(sdt.gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturatipo_N);
            sdtIsNull = 0;
            gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturatipo = sdt.gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturatipo ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "PropostaContratoAssinaturaId" )]
      [  XmlElement( ElementName = "PropostaContratoAssinaturaId"   )]
      public int gxTpr_Propostacontratoassinaturaid
      {
         get {
            return gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturaid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturaid != value )
            {
               gxTv_SdtPropostaContratoAssinatura_Mode = "INS";
               this.gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturaid_Z_SetNull( );
               this.gxTv_SdtPropostaContratoAssinatura_Propostaid_Z_SetNull( );
               this.gxTv_SdtPropostaContratoAssinatura_Propostacontrato_Z_SetNull( );
               this.gxTv_SdtPropostaContratoAssinatura_Propostaassinatura_Z_SetNull( );
               this.gxTv_SdtPropostaContratoAssinatura_Propostaassinaturastatus_Z_SetNull( );
               this.gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturatipo_Z_SetNull( );
            }
            gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturaid = value;
            SetDirty("Propostacontratoassinaturaid");
         }

      }

      [  SoapElement( ElementName = "PropostaId" )]
      [  XmlElement( ElementName = "PropostaId"   )]
      public int gxTpr_Propostaid
      {
         get {
            return gxTv_SdtPropostaContratoAssinatura_Propostaid ;
         }

         set {
            gxTv_SdtPropostaContratoAssinatura_Propostaid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtPropostaContratoAssinatura_Propostaid = value;
            SetDirty("Propostaid");
         }

      }

      public void gxTv_SdtPropostaContratoAssinatura_Propostaid_SetNull( )
      {
         gxTv_SdtPropostaContratoAssinatura_Propostaid_N = 1;
         gxTv_SdtPropostaContratoAssinatura_Propostaid = 0;
         SetDirty("Propostaid");
         return  ;
      }

      public bool gxTv_SdtPropostaContratoAssinatura_Propostaid_IsNull( )
      {
         return (gxTv_SdtPropostaContratoAssinatura_Propostaid_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaContrato" )]
      [  XmlElement( ElementName = "PropostaContrato"   )]
      public int gxTpr_Propostacontrato
      {
         get {
            return gxTv_SdtPropostaContratoAssinatura_Propostacontrato ;
         }

         set {
            gxTv_SdtPropostaContratoAssinatura_Propostacontrato_N = 0;
            sdtIsNull = 0;
            gxTv_SdtPropostaContratoAssinatura_Propostacontrato = value;
            SetDirty("Propostacontrato");
         }

      }

      public void gxTv_SdtPropostaContratoAssinatura_Propostacontrato_SetNull( )
      {
         gxTv_SdtPropostaContratoAssinatura_Propostacontrato_N = 1;
         gxTv_SdtPropostaContratoAssinatura_Propostacontrato = 0;
         SetDirty("Propostacontrato");
         return  ;
      }

      public bool gxTv_SdtPropostaContratoAssinatura_Propostacontrato_IsNull( )
      {
         return (gxTv_SdtPropostaContratoAssinatura_Propostacontrato_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaAssinatura" )]
      [  XmlElement( ElementName = "PropostaAssinatura"   )]
      public long gxTpr_Propostaassinatura
      {
         get {
            return gxTv_SdtPropostaContratoAssinatura_Propostaassinatura ;
         }

         set {
            gxTv_SdtPropostaContratoAssinatura_Propostaassinatura_N = 0;
            sdtIsNull = 0;
            gxTv_SdtPropostaContratoAssinatura_Propostaassinatura = value;
            SetDirty("Propostaassinatura");
         }

      }

      public void gxTv_SdtPropostaContratoAssinatura_Propostaassinatura_SetNull( )
      {
         gxTv_SdtPropostaContratoAssinatura_Propostaassinatura_N = 1;
         gxTv_SdtPropostaContratoAssinatura_Propostaassinatura = 0;
         SetDirty("Propostaassinatura");
         return  ;
      }

      public bool gxTv_SdtPropostaContratoAssinatura_Propostaassinatura_IsNull( )
      {
         return (gxTv_SdtPropostaContratoAssinatura_Propostaassinatura_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaAssinaturaStatus" )]
      [  XmlElement( ElementName = "PropostaAssinaturaStatus"   )]
      public string gxTpr_Propostaassinaturastatus
      {
         get {
            return gxTv_SdtPropostaContratoAssinatura_Propostaassinaturastatus ;
         }

         set {
            gxTv_SdtPropostaContratoAssinatura_Propostaassinaturastatus_N = 0;
            sdtIsNull = 0;
            gxTv_SdtPropostaContratoAssinatura_Propostaassinaturastatus = value;
            SetDirty("Propostaassinaturastatus");
         }

      }

      public void gxTv_SdtPropostaContratoAssinatura_Propostaassinaturastatus_SetNull( )
      {
         gxTv_SdtPropostaContratoAssinatura_Propostaassinaturastatus_N = 1;
         gxTv_SdtPropostaContratoAssinatura_Propostaassinaturastatus = "";
         SetDirty("Propostaassinaturastatus");
         return  ;
      }

      public bool gxTv_SdtPropostaContratoAssinatura_Propostaassinaturastatus_IsNull( )
      {
         return (gxTv_SdtPropostaContratoAssinatura_Propostaassinaturastatus_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaContratoAssinaturaTipo" )]
      [  XmlElement( ElementName = "PropostaContratoAssinaturaTipo"   )]
      public string gxTpr_Propostacontratoassinaturatipo
      {
         get {
            return gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturatipo ;
         }

         set {
            gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturatipo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturatipo = value;
            SetDirty("Propostacontratoassinaturatipo");
         }

      }

      public void gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturatipo_SetNull( )
      {
         gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturatipo_N = 1;
         gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturatipo = "";
         SetDirty("Propostacontratoassinaturatipo");
         return  ;
      }

      public bool gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturatipo_IsNull( )
      {
         return (gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturatipo_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtPropostaContratoAssinatura_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaContratoAssinatura_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtPropostaContratoAssinatura_Mode_SetNull( )
      {
         gxTv_SdtPropostaContratoAssinatura_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtPropostaContratoAssinatura_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtPropostaContratoAssinatura_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaContratoAssinatura_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtPropostaContratoAssinatura_Initialized_SetNull( )
      {
         gxTv_SdtPropostaContratoAssinatura_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtPropostaContratoAssinatura_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaContratoAssinaturaId_Z" )]
      [  XmlElement( ElementName = "PropostaContratoAssinaturaId_Z"   )]
      public int gxTpr_Propostacontratoassinaturaid_Z
      {
         get {
            return gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturaid_Z = value;
            SetDirty("Propostacontratoassinaturaid_Z");
         }

      }

      public void gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturaid_Z_SetNull( )
      {
         gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturaid_Z = 0;
         SetDirty("Propostacontratoassinaturaid_Z");
         return  ;
      }

      public bool gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaId_Z" )]
      [  XmlElement( ElementName = "PropostaId_Z"   )]
      public int gxTpr_Propostaid_Z
      {
         get {
            return gxTv_SdtPropostaContratoAssinatura_Propostaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaContratoAssinatura_Propostaid_Z = value;
            SetDirty("Propostaid_Z");
         }

      }

      public void gxTv_SdtPropostaContratoAssinatura_Propostaid_Z_SetNull( )
      {
         gxTv_SdtPropostaContratoAssinatura_Propostaid_Z = 0;
         SetDirty("Propostaid_Z");
         return  ;
      }

      public bool gxTv_SdtPropostaContratoAssinatura_Propostaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaContrato_Z" )]
      [  XmlElement( ElementName = "PropostaContrato_Z"   )]
      public int gxTpr_Propostacontrato_Z
      {
         get {
            return gxTv_SdtPropostaContratoAssinatura_Propostacontrato_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaContratoAssinatura_Propostacontrato_Z = value;
            SetDirty("Propostacontrato_Z");
         }

      }

      public void gxTv_SdtPropostaContratoAssinatura_Propostacontrato_Z_SetNull( )
      {
         gxTv_SdtPropostaContratoAssinatura_Propostacontrato_Z = 0;
         SetDirty("Propostacontrato_Z");
         return  ;
      }

      public bool gxTv_SdtPropostaContratoAssinatura_Propostacontrato_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaAssinatura_Z" )]
      [  XmlElement( ElementName = "PropostaAssinatura_Z"   )]
      public long gxTpr_Propostaassinatura_Z
      {
         get {
            return gxTv_SdtPropostaContratoAssinatura_Propostaassinatura_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaContratoAssinatura_Propostaassinatura_Z = value;
            SetDirty("Propostaassinatura_Z");
         }

      }

      public void gxTv_SdtPropostaContratoAssinatura_Propostaassinatura_Z_SetNull( )
      {
         gxTv_SdtPropostaContratoAssinatura_Propostaassinatura_Z = 0;
         SetDirty("Propostaassinatura_Z");
         return  ;
      }

      public bool gxTv_SdtPropostaContratoAssinatura_Propostaassinatura_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaAssinaturaStatus_Z" )]
      [  XmlElement( ElementName = "PropostaAssinaturaStatus_Z"   )]
      public string gxTpr_Propostaassinaturastatus_Z
      {
         get {
            return gxTv_SdtPropostaContratoAssinatura_Propostaassinaturastatus_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaContratoAssinatura_Propostaassinaturastatus_Z = value;
            SetDirty("Propostaassinaturastatus_Z");
         }

      }

      public void gxTv_SdtPropostaContratoAssinatura_Propostaassinaturastatus_Z_SetNull( )
      {
         gxTv_SdtPropostaContratoAssinatura_Propostaassinaturastatus_Z = "";
         SetDirty("Propostaassinaturastatus_Z");
         return  ;
      }

      public bool gxTv_SdtPropostaContratoAssinatura_Propostaassinaturastatus_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaContratoAssinaturaTipo_Z" )]
      [  XmlElement( ElementName = "PropostaContratoAssinaturaTipo_Z"   )]
      public string gxTpr_Propostacontratoassinaturatipo_Z
      {
         get {
            return gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturatipo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturatipo_Z = value;
            SetDirty("Propostacontratoassinaturatipo_Z");
         }

      }

      public void gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturatipo_Z_SetNull( )
      {
         gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturatipo_Z = "";
         SetDirty("Propostacontratoassinaturatipo_Z");
         return  ;
      }

      public bool gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturatipo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaContratoAssinaturaId_N" )]
      [  XmlElement( ElementName = "PropostaContratoAssinaturaId_N"   )]
      public short gxTpr_Propostacontratoassinaturaid_N
      {
         get {
            return gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturaid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturaid_N = value;
            SetDirty("Propostacontratoassinaturaid_N");
         }

      }

      public void gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturaid_N_SetNull( )
      {
         gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturaid_N = 0;
         SetDirty("Propostacontratoassinaturaid_N");
         return  ;
      }

      public bool gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturaid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaId_N" )]
      [  XmlElement( ElementName = "PropostaId_N"   )]
      public short gxTpr_Propostaid_N
      {
         get {
            return gxTv_SdtPropostaContratoAssinatura_Propostaid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaContratoAssinatura_Propostaid_N = value;
            SetDirty("Propostaid_N");
         }

      }

      public void gxTv_SdtPropostaContratoAssinatura_Propostaid_N_SetNull( )
      {
         gxTv_SdtPropostaContratoAssinatura_Propostaid_N = 0;
         SetDirty("Propostaid_N");
         return  ;
      }

      public bool gxTv_SdtPropostaContratoAssinatura_Propostaid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaContrato_N" )]
      [  XmlElement( ElementName = "PropostaContrato_N"   )]
      public short gxTpr_Propostacontrato_N
      {
         get {
            return gxTv_SdtPropostaContratoAssinatura_Propostacontrato_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaContratoAssinatura_Propostacontrato_N = value;
            SetDirty("Propostacontrato_N");
         }

      }

      public void gxTv_SdtPropostaContratoAssinatura_Propostacontrato_N_SetNull( )
      {
         gxTv_SdtPropostaContratoAssinatura_Propostacontrato_N = 0;
         SetDirty("Propostacontrato_N");
         return  ;
      }

      public bool gxTv_SdtPropostaContratoAssinatura_Propostacontrato_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaAssinatura_N" )]
      [  XmlElement( ElementName = "PropostaAssinatura_N"   )]
      public short gxTpr_Propostaassinatura_N
      {
         get {
            return gxTv_SdtPropostaContratoAssinatura_Propostaassinatura_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaContratoAssinatura_Propostaassinatura_N = value;
            SetDirty("Propostaassinatura_N");
         }

      }

      public void gxTv_SdtPropostaContratoAssinatura_Propostaassinatura_N_SetNull( )
      {
         gxTv_SdtPropostaContratoAssinatura_Propostaassinatura_N = 0;
         SetDirty("Propostaassinatura_N");
         return  ;
      }

      public bool gxTv_SdtPropostaContratoAssinatura_Propostaassinatura_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaAssinaturaStatus_N" )]
      [  XmlElement( ElementName = "PropostaAssinaturaStatus_N"   )]
      public short gxTpr_Propostaassinaturastatus_N
      {
         get {
            return gxTv_SdtPropostaContratoAssinatura_Propostaassinaturastatus_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaContratoAssinatura_Propostaassinaturastatus_N = value;
            SetDirty("Propostaassinaturastatus_N");
         }

      }

      public void gxTv_SdtPropostaContratoAssinatura_Propostaassinaturastatus_N_SetNull( )
      {
         gxTv_SdtPropostaContratoAssinatura_Propostaassinaturastatus_N = 0;
         SetDirty("Propostaassinaturastatus_N");
         return  ;
      }

      public bool gxTv_SdtPropostaContratoAssinatura_Propostaassinaturastatus_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaContratoAssinaturaTipo_N" )]
      [  XmlElement( ElementName = "PropostaContratoAssinaturaTipo_N"   )]
      public short gxTpr_Propostacontratoassinaturatipo_N
      {
         get {
            return gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturatipo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturatipo_N = value;
            SetDirty("Propostacontratoassinaturatipo_N");
         }

      }

      public void gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturatipo_N_SetNull( )
      {
         gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturatipo_N = 0;
         SetDirty("Propostacontratoassinaturatipo_N");
         return  ;
      }

      public bool gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturatipo_N_IsNull( )
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
         gxTv_SdtPropostaContratoAssinatura_Propostaassinaturastatus = "";
         gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturatipo = "";
         gxTv_SdtPropostaContratoAssinatura_Mode = "";
         gxTv_SdtPropostaContratoAssinatura_Propostaassinaturastatus_Z = "";
         gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturatipo_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "propostacontratoassinatura", "GeneXus.Programs.propostacontratoassinatura_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtPropostaContratoAssinatura_Initialized ;
      private short gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturaid_N ;
      private short gxTv_SdtPropostaContratoAssinatura_Propostaid_N ;
      private short gxTv_SdtPropostaContratoAssinatura_Propostacontrato_N ;
      private short gxTv_SdtPropostaContratoAssinatura_Propostaassinatura_N ;
      private short gxTv_SdtPropostaContratoAssinatura_Propostaassinaturastatus_N ;
      private short gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturatipo_N ;
      private int gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturaid ;
      private int gxTv_SdtPropostaContratoAssinatura_Propostaid ;
      private int gxTv_SdtPropostaContratoAssinatura_Propostacontrato ;
      private int gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturaid_Z ;
      private int gxTv_SdtPropostaContratoAssinatura_Propostaid_Z ;
      private int gxTv_SdtPropostaContratoAssinatura_Propostacontrato_Z ;
      private long gxTv_SdtPropostaContratoAssinatura_Propostaassinatura ;
      private long gxTv_SdtPropostaContratoAssinatura_Propostaassinatura_Z ;
      private string gxTv_SdtPropostaContratoAssinatura_Mode ;
      private string gxTv_SdtPropostaContratoAssinatura_Propostaassinaturastatus ;
      private string gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturatipo ;
      private string gxTv_SdtPropostaContratoAssinatura_Propostaassinaturastatus_Z ;
      private string gxTv_SdtPropostaContratoAssinatura_Propostacontratoassinaturatipo_Z ;
   }

   [DataContract(Name = @"PropostaContratoAssinatura", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtPropostaContratoAssinatura_RESTInterface : GxGenericCollectionItem<SdtPropostaContratoAssinatura>
   {
      public SdtPropostaContratoAssinatura_RESTInterface( ) : base()
      {
      }

      public SdtPropostaContratoAssinatura_RESTInterface( SdtPropostaContratoAssinatura psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PropostaContratoAssinaturaId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Propostacontratoassinaturaid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Propostacontratoassinaturaid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Propostacontratoassinaturaid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "PropostaId" , Order = 1 )]
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

      [DataMember( Name = "PropostaContrato" , Order = 2 )]
      [GxSeudo()]
      public Nullable<int> gxTpr_Propostacontrato
      {
         get {
            return sdt.gxTpr_Propostacontrato ;
         }

         set {
            sdt.gxTpr_Propostacontrato = (int)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "PropostaAssinatura" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Propostaassinatura
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Propostaassinatura), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Propostaassinatura = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "PropostaAssinaturaStatus" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Propostaassinaturastatus
      {
         get {
            return sdt.gxTpr_Propostaassinaturastatus ;
         }

         set {
            sdt.gxTpr_Propostaassinaturastatus = value;
         }

      }

      [DataMember( Name = "PropostaContratoAssinaturaTipo" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Propostacontratoassinaturatipo
      {
         get {
            return sdt.gxTpr_Propostacontratoassinaturatipo ;
         }

         set {
            sdt.gxTpr_Propostacontratoassinaturatipo = value;
         }

      }

      public SdtPropostaContratoAssinatura sdt
      {
         get {
            return (SdtPropostaContratoAssinatura)Sdt ;
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
            sdt = new SdtPropostaContratoAssinatura() ;
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

   [DataContract(Name = @"PropostaContratoAssinatura", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtPropostaContratoAssinatura_RESTLInterface : GxGenericCollectionItem<SdtPropostaContratoAssinatura>
   {
      public SdtPropostaContratoAssinatura_RESTLInterface( ) : base()
      {
      }

      public SdtPropostaContratoAssinatura_RESTLInterface( SdtPropostaContratoAssinatura psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PropostaAssinaturaStatus" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Propostaassinaturastatus
      {
         get {
            return sdt.gxTpr_Propostaassinaturastatus ;
         }

         set {
            sdt.gxTpr_Propostaassinaturastatus = value;
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

      public SdtPropostaContratoAssinatura sdt
      {
         get {
            return (SdtPropostaContratoAssinatura)Sdt ;
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
            sdt = new SdtPropostaContratoAssinatura() ;
         }
      }

   }

}
