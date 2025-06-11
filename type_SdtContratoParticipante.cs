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
   [XmlRoot(ElementName = "ContratoParticipante" )]
   [XmlType(TypeName =  "ContratoParticipante" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtContratoParticipante : GxSilentTrnSdt
   {
      public SdtContratoParticipante( )
      {
      }

      public SdtContratoParticipante( IGxContext context )
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

      public void Load( int AV237ContratoParticipanteId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV237ContratoParticipanteId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ContratoParticipanteId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "ContratoParticipante");
         metadata.Set("BT", "ContratoParticipante");
         metadata.Set("PK", "[ \"ContratoParticipanteId\" ]");
         metadata.Set("PKAssigned", "[ \"ContratoParticipanteId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"ContratoId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"ParticipanteId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Contratoparticipanteid_Z");
         state.Add("gxTpr_Contratoid_Z");
         state.Add("gxTpr_Participanteid_Z");
         state.Add("gxTpr_Contratoid_N");
         state.Add("gxTpr_Participanteid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtContratoParticipante sdt;
         sdt = (SdtContratoParticipante)(source);
         gxTv_SdtContratoParticipante_Contratoparticipanteid = sdt.gxTv_SdtContratoParticipante_Contratoparticipanteid ;
         gxTv_SdtContratoParticipante_Contratoid = sdt.gxTv_SdtContratoParticipante_Contratoid ;
         gxTv_SdtContratoParticipante_Participanteid = sdt.gxTv_SdtContratoParticipante_Participanteid ;
         gxTv_SdtContratoParticipante_Mode = sdt.gxTv_SdtContratoParticipante_Mode ;
         gxTv_SdtContratoParticipante_Initialized = sdt.gxTv_SdtContratoParticipante_Initialized ;
         gxTv_SdtContratoParticipante_Contratoparticipanteid_Z = sdt.gxTv_SdtContratoParticipante_Contratoparticipanteid_Z ;
         gxTv_SdtContratoParticipante_Contratoid_Z = sdt.gxTv_SdtContratoParticipante_Contratoid_Z ;
         gxTv_SdtContratoParticipante_Participanteid_Z = sdt.gxTv_SdtContratoParticipante_Participanteid_Z ;
         gxTv_SdtContratoParticipante_Contratoid_N = sdt.gxTv_SdtContratoParticipante_Contratoid_N ;
         gxTv_SdtContratoParticipante_Participanteid_N = sdt.gxTv_SdtContratoParticipante_Participanteid_N ;
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
         AddObjectProperty("ContratoParticipanteId", gxTv_SdtContratoParticipante_Contratoparticipanteid, false, includeNonInitialized);
         AddObjectProperty("ContratoId", gxTv_SdtContratoParticipante_Contratoid, false, includeNonInitialized);
         AddObjectProperty("ContratoId_N", gxTv_SdtContratoParticipante_Contratoid_N, false, includeNonInitialized);
         AddObjectProperty("ParticipanteId", gxTv_SdtContratoParticipante_Participanteid, false, includeNonInitialized);
         AddObjectProperty("ParticipanteId_N", gxTv_SdtContratoParticipante_Participanteid_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtContratoParticipante_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtContratoParticipante_Initialized, false, includeNonInitialized);
            AddObjectProperty("ContratoParticipanteId_Z", gxTv_SdtContratoParticipante_Contratoparticipanteid_Z, false, includeNonInitialized);
            AddObjectProperty("ContratoId_Z", gxTv_SdtContratoParticipante_Contratoid_Z, false, includeNonInitialized);
            AddObjectProperty("ParticipanteId_Z", gxTv_SdtContratoParticipante_Participanteid_Z, false, includeNonInitialized);
            AddObjectProperty("ContratoId_N", gxTv_SdtContratoParticipante_Contratoid_N, false, includeNonInitialized);
            AddObjectProperty("ParticipanteId_N", gxTv_SdtContratoParticipante_Participanteid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtContratoParticipante sdt )
      {
         if ( sdt.IsDirty("ContratoParticipanteId") )
         {
            sdtIsNull = 0;
            gxTv_SdtContratoParticipante_Contratoparticipanteid = sdt.gxTv_SdtContratoParticipante_Contratoparticipanteid ;
         }
         if ( sdt.IsDirty("ContratoId") )
         {
            gxTv_SdtContratoParticipante_Contratoid_N = (short)(sdt.gxTv_SdtContratoParticipante_Contratoid_N);
            sdtIsNull = 0;
            gxTv_SdtContratoParticipante_Contratoid = sdt.gxTv_SdtContratoParticipante_Contratoid ;
         }
         if ( sdt.IsDirty("ParticipanteId") )
         {
            gxTv_SdtContratoParticipante_Participanteid_N = (short)(sdt.gxTv_SdtContratoParticipante_Participanteid_N);
            sdtIsNull = 0;
            gxTv_SdtContratoParticipante_Participanteid = sdt.gxTv_SdtContratoParticipante_Participanteid ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ContratoParticipanteId" )]
      [  XmlElement( ElementName = "ContratoParticipanteId"   )]
      public int gxTpr_Contratoparticipanteid
      {
         get {
            return gxTv_SdtContratoParticipante_Contratoparticipanteid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtContratoParticipante_Contratoparticipanteid != value )
            {
               gxTv_SdtContratoParticipante_Mode = "INS";
               this.gxTv_SdtContratoParticipante_Contratoparticipanteid_Z_SetNull( );
               this.gxTv_SdtContratoParticipante_Contratoid_Z_SetNull( );
               this.gxTv_SdtContratoParticipante_Participanteid_Z_SetNull( );
            }
            gxTv_SdtContratoParticipante_Contratoparticipanteid = value;
            SetDirty("Contratoparticipanteid");
         }

      }

      [  SoapElement( ElementName = "ContratoId" )]
      [  XmlElement( ElementName = "ContratoId"   )]
      public int gxTpr_Contratoid
      {
         get {
            return gxTv_SdtContratoParticipante_Contratoid ;
         }

         set {
            gxTv_SdtContratoParticipante_Contratoid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtContratoParticipante_Contratoid = value;
            SetDirty("Contratoid");
         }

      }

      public void gxTv_SdtContratoParticipante_Contratoid_SetNull( )
      {
         gxTv_SdtContratoParticipante_Contratoid_N = 1;
         gxTv_SdtContratoParticipante_Contratoid = 0;
         SetDirty("Contratoid");
         return  ;
      }

      public bool gxTv_SdtContratoParticipante_Contratoid_IsNull( )
      {
         return (gxTv_SdtContratoParticipante_Contratoid_N==1) ;
      }

      [  SoapElement( ElementName = "ParticipanteId" )]
      [  XmlElement( ElementName = "ParticipanteId"   )]
      public int gxTpr_Participanteid
      {
         get {
            return gxTv_SdtContratoParticipante_Participanteid ;
         }

         set {
            gxTv_SdtContratoParticipante_Participanteid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtContratoParticipante_Participanteid = value;
            SetDirty("Participanteid");
         }

      }

      public void gxTv_SdtContratoParticipante_Participanteid_SetNull( )
      {
         gxTv_SdtContratoParticipante_Participanteid_N = 1;
         gxTv_SdtContratoParticipante_Participanteid = 0;
         SetDirty("Participanteid");
         return  ;
      }

      public bool gxTv_SdtContratoParticipante_Participanteid_IsNull( )
      {
         return (gxTv_SdtContratoParticipante_Participanteid_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtContratoParticipante_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContratoParticipante_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtContratoParticipante_Mode_SetNull( )
      {
         gxTv_SdtContratoParticipante_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtContratoParticipante_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtContratoParticipante_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContratoParticipante_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtContratoParticipante_Initialized_SetNull( )
      {
         gxTv_SdtContratoParticipante_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtContratoParticipante_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoParticipanteId_Z" )]
      [  XmlElement( ElementName = "ContratoParticipanteId_Z"   )]
      public int gxTpr_Contratoparticipanteid_Z
      {
         get {
            return gxTv_SdtContratoParticipante_Contratoparticipanteid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContratoParticipante_Contratoparticipanteid_Z = value;
            SetDirty("Contratoparticipanteid_Z");
         }

      }

      public void gxTv_SdtContratoParticipante_Contratoparticipanteid_Z_SetNull( )
      {
         gxTv_SdtContratoParticipante_Contratoparticipanteid_Z = 0;
         SetDirty("Contratoparticipanteid_Z");
         return  ;
      }

      public bool gxTv_SdtContratoParticipante_Contratoparticipanteid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoId_Z" )]
      [  XmlElement( ElementName = "ContratoId_Z"   )]
      public int gxTpr_Contratoid_Z
      {
         get {
            return gxTv_SdtContratoParticipante_Contratoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContratoParticipante_Contratoid_Z = value;
            SetDirty("Contratoid_Z");
         }

      }

      public void gxTv_SdtContratoParticipante_Contratoid_Z_SetNull( )
      {
         gxTv_SdtContratoParticipante_Contratoid_Z = 0;
         SetDirty("Contratoid_Z");
         return  ;
      }

      public bool gxTv_SdtContratoParticipante_Contratoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParticipanteId_Z" )]
      [  XmlElement( ElementName = "ParticipanteId_Z"   )]
      public int gxTpr_Participanteid_Z
      {
         get {
            return gxTv_SdtContratoParticipante_Participanteid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContratoParticipante_Participanteid_Z = value;
            SetDirty("Participanteid_Z");
         }

      }

      public void gxTv_SdtContratoParticipante_Participanteid_Z_SetNull( )
      {
         gxTv_SdtContratoParticipante_Participanteid_Z = 0;
         SetDirty("Participanteid_Z");
         return  ;
      }

      public bool gxTv_SdtContratoParticipante_Participanteid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoId_N" )]
      [  XmlElement( ElementName = "ContratoId_N"   )]
      public short gxTpr_Contratoid_N
      {
         get {
            return gxTv_SdtContratoParticipante_Contratoid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContratoParticipante_Contratoid_N = value;
            SetDirty("Contratoid_N");
         }

      }

      public void gxTv_SdtContratoParticipante_Contratoid_N_SetNull( )
      {
         gxTv_SdtContratoParticipante_Contratoid_N = 0;
         SetDirty("Contratoid_N");
         return  ;
      }

      public bool gxTv_SdtContratoParticipante_Contratoid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParticipanteId_N" )]
      [  XmlElement( ElementName = "ParticipanteId_N"   )]
      public short gxTpr_Participanteid_N
      {
         get {
            return gxTv_SdtContratoParticipante_Participanteid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContratoParticipante_Participanteid_N = value;
            SetDirty("Participanteid_N");
         }

      }

      public void gxTv_SdtContratoParticipante_Participanteid_N_SetNull( )
      {
         gxTv_SdtContratoParticipante_Participanteid_N = 0;
         SetDirty("Participanteid_N");
         return  ;
      }

      public bool gxTv_SdtContratoParticipante_Participanteid_N_IsNull( )
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
         gxTv_SdtContratoParticipante_Mode = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "contratoparticipante", "GeneXus.Programs.contratoparticipante_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtContratoParticipante_Initialized ;
      private short gxTv_SdtContratoParticipante_Contratoid_N ;
      private short gxTv_SdtContratoParticipante_Participanteid_N ;
      private int gxTv_SdtContratoParticipante_Contratoparticipanteid ;
      private int gxTv_SdtContratoParticipante_Contratoid ;
      private int gxTv_SdtContratoParticipante_Participanteid ;
      private int gxTv_SdtContratoParticipante_Contratoparticipanteid_Z ;
      private int gxTv_SdtContratoParticipante_Contratoid_Z ;
      private int gxTv_SdtContratoParticipante_Participanteid_Z ;
      private string gxTv_SdtContratoParticipante_Mode ;
   }

   [DataContract(Name = @"ContratoParticipante", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtContratoParticipante_RESTInterface : GxGenericCollectionItem<SdtContratoParticipante>
   {
      public SdtContratoParticipante_RESTInterface( ) : base()
      {
      }

      public SdtContratoParticipante_RESTInterface( SdtContratoParticipante psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ContratoParticipanteId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Contratoparticipanteid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Contratoparticipanteid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Contratoparticipanteid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ContratoId" , Order = 1 )]
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

      public SdtContratoParticipante sdt
      {
         get {
            return (SdtContratoParticipante)Sdt ;
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
            sdt = new SdtContratoParticipante() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 3 )]
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

   [DataContract(Name = @"ContratoParticipante", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtContratoParticipante_RESTLInterface : GxGenericCollectionItem<SdtContratoParticipante>
   {
      public SdtContratoParticipante_RESTLInterface( ) : base()
      {
      }

      public SdtContratoParticipante_RESTLInterface( SdtContratoParticipante psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ContratoParticipanteId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Contratoparticipanteid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Contratoparticipanteid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Contratoparticipanteid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "uri" , Order = 1 )]
      public string Uri
      {
         get {
            string gxuri = "/rest/ContratoParticipante/{0}";
            gxuri = String.Format(gxuri,gxTpr_Contratoparticipanteid) ;
            return gxuri ;
         }

         set {
         }

      }

      public SdtContratoParticipante sdt
      {
         get {
            return (SdtContratoParticipante)Sdt ;
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
            sdt = new SdtContratoParticipante() ;
         }
      }

      private string gxuri ;
   }

}
