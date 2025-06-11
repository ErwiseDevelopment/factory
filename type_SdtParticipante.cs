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
   [XmlRoot(ElementName = "Participante" )]
   [XmlType(TypeName =  "Participante" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtParticipante : GxSilentTrnSdt
   {
      public SdtParticipante( )
      {
      }

      public SdtParticipante( IGxContext context )
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

      public void Load( int AV233ParticipanteId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV233ParticipanteId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ParticipanteId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Participante");
         metadata.Set("BT", "Participante");
         metadata.Set("PK", "[ \"ParticipanteId\" ]");
         metadata.Set("PKAssigned", "[ \"ParticipanteId\" ]");
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
         state.Add("gxTpr_Participanteid_Z");
         state.Add("gxTpr_Participantedocumento_Z");
         state.Add("gxTpr_Participantenome_Z");
         state.Add("gxTpr_Participanteemail_Z");
         state.Add("gxTpr_Participantetipopessoa_Z");
         state.Add("gxTpr_Participanterepresentantenome_Z");
         state.Add("gxTpr_Participanterepresentanteemail_Z");
         state.Add("gxTpr_Participanterepresentantedocumento_Z");
         state.Add("gxTpr_Participanteemail_f_Z");
         state.Add("gxTpr_Participantedocumento_f_Z");
         state.Add("gxTpr_Participanteid_N");
         state.Add("gxTpr_Participantedocumento_N");
         state.Add("gxTpr_Participantenome_N");
         state.Add("gxTpr_Participanteemail_N");
         state.Add("gxTpr_Participantetipopessoa_N");
         state.Add("gxTpr_Participanterepresentantenome_N");
         state.Add("gxTpr_Participanterepresentanteemail_N");
         state.Add("gxTpr_Participanterepresentantedocumento_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtParticipante sdt;
         sdt = (SdtParticipante)(source);
         gxTv_SdtParticipante_Participanteid = sdt.gxTv_SdtParticipante_Participanteid ;
         gxTv_SdtParticipante_Participantedocumento = sdt.gxTv_SdtParticipante_Participantedocumento ;
         gxTv_SdtParticipante_Participantenome = sdt.gxTv_SdtParticipante_Participantenome ;
         gxTv_SdtParticipante_Participanteemail = sdt.gxTv_SdtParticipante_Participanteemail ;
         gxTv_SdtParticipante_Participantetipopessoa = sdt.gxTv_SdtParticipante_Participantetipopessoa ;
         gxTv_SdtParticipante_Participanterepresentantenome = sdt.gxTv_SdtParticipante_Participanterepresentantenome ;
         gxTv_SdtParticipante_Participanterepresentanteemail = sdt.gxTv_SdtParticipante_Participanterepresentanteemail ;
         gxTv_SdtParticipante_Participanterepresentantedocumento = sdt.gxTv_SdtParticipante_Participanterepresentantedocumento ;
         gxTv_SdtParticipante_Participanteemail_f = sdt.gxTv_SdtParticipante_Participanteemail_f ;
         gxTv_SdtParticipante_Participantedocumento_f = sdt.gxTv_SdtParticipante_Participantedocumento_f ;
         gxTv_SdtParticipante_Mode = sdt.gxTv_SdtParticipante_Mode ;
         gxTv_SdtParticipante_Initialized = sdt.gxTv_SdtParticipante_Initialized ;
         gxTv_SdtParticipante_Participanteid_Z = sdt.gxTv_SdtParticipante_Participanteid_Z ;
         gxTv_SdtParticipante_Participantedocumento_Z = sdt.gxTv_SdtParticipante_Participantedocumento_Z ;
         gxTv_SdtParticipante_Participantenome_Z = sdt.gxTv_SdtParticipante_Participantenome_Z ;
         gxTv_SdtParticipante_Participanteemail_Z = sdt.gxTv_SdtParticipante_Participanteemail_Z ;
         gxTv_SdtParticipante_Participantetipopessoa_Z = sdt.gxTv_SdtParticipante_Participantetipopessoa_Z ;
         gxTv_SdtParticipante_Participanterepresentantenome_Z = sdt.gxTv_SdtParticipante_Participanterepresentantenome_Z ;
         gxTv_SdtParticipante_Participanterepresentanteemail_Z = sdt.gxTv_SdtParticipante_Participanterepresentanteemail_Z ;
         gxTv_SdtParticipante_Participanterepresentantedocumento_Z = sdt.gxTv_SdtParticipante_Participanterepresentantedocumento_Z ;
         gxTv_SdtParticipante_Participanteemail_f_Z = sdt.gxTv_SdtParticipante_Participanteemail_f_Z ;
         gxTv_SdtParticipante_Participantedocumento_f_Z = sdt.gxTv_SdtParticipante_Participantedocumento_f_Z ;
         gxTv_SdtParticipante_Participanteid_N = sdt.gxTv_SdtParticipante_Participanteid_N ;
         gxTv_SdtParticipante_Participantedocumento_N = sdt.gxTv_SdtParticipante_Participantedocumento_N ;
         gxTv_SdtParticipante_Participantenome_N = sdt.gxTv_SdtParticipante_Participantenome_N ;
         gxTv_SdtParticipante_Participanteemail_N = sdt.gxTv_SdtParticipante_Participanteemail_N ;
         gxTv_SdtParticipante_Participantetipopessoa_N = sdt.gxTv_SdtParticipante_Participantetipopessoa_N ;
         gxTv_SdtParticipante_Participanterepresentantenome_N = sdt.gxTv_SdtParticipante_Participanterepresentantenome_N ;
         gxTv_SdtParticipante_Participanterepresentanteemail_N = sdt.gxTv_SdtParticipante_Participanterepresentanteemail_N ;
         gxTv_SdtParticipante_Participanterepresentantedocumento_N = sdt.gxTv_SdtParticipante_Participanterepresentantedocumento_N ;
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
         AddObjectProperty("ParticipanteId", gxTv_SdtParticipante_Participanteid, false, includeNonInitialized);
         AddObjectProperty("ParticipanteId_N", gxTv_SdtParticipante_Participanteid_N, false, includeNonInitialized);
         AddObjectProperty("ParticipanteDocumento", gxTv_SdtParticipante_Participantedocumento, false, includeNonInitialized);
         AddObjectProperty("ParticipanteDocumento_N", gxTv_SdtParticipante_Participantedocumento_N, false, includeNonInitialized);
         AddObjectProperty("ParticipanteNome", gxTv_SdtParticipante_Participantenome, false, includeNonInitialized);
         AddObjectProperty("ParticipanteNome_N", gxTv_SdtParticipante_Participantenome_N, false, includeNonInitialized);
         AddObjectProperty("ParticipanteEmail", gxTv_SdtParticipante_Participanteemail, false, includeNonInitialized);
         AddObjectProperty("ParticipanteEmail_N", gxTv_SdtParticipante_Participanteemail_N, false, includeNonInitialized);
         AddObjectProperty("ParticipanteTipoPessoa", gxTv_SdtParticipante_Participantetipopessoa, false, includeNonInitialized);
         AddObjectProperty("ParticipanteTipoPessoa_N", gxTv_SdtParticipante_Participantetipopessoa_N, false, includeNonInitialized);
         AddObjectProperty("ParticipanteRepresentanteNome", gxTv_SdtParticipante_Participanterepresentantenome, false, includeNonInitialized);
         AddObjectProperty("ParticipanteRepresentanteNome_N", gxTv_SdtParticipante_Participanterepresentantenome_N, false, includeNonInitialized);
         AddObjectProperty("ParticipanteRepresentanteEmail", gxTv_SdtParticipante_Participanterepresentanteemail, false, includeNonInitialized);
         AddObjectProperty("ParticipanteRepresentanteEmail_N", gxTv_SdtParticipante_Participanterepresentanteemail_N, false, includeNonInitialized);
         AddObjectProperty("ParticipanteRepresentanteDocumento", gxTv_SdtParticipante_Participanterepresentantedocumento, false, includeNonInitialized);
         AddObjectProperty("ParticipanteRepresentanteDocumento_N", gxTv_SdtParticipante_Participanterepresentantedocumento_N, false, includeNonInitialized);
         AddObjectProperty("ParticipanteEmail_F", gxTv_SdtParticipante_Participanteemail_f, false, includeNonInitialized);
         AddObjectProperty("ParticipanteDocumento_F", gxTv_SdtParticipante_Participantedocumento_f, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtParticipante_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtParticipante_Initialized, false, includeNonInitialized);
            AddObjectProperty("ParticipanteId_Z", gxTv_SdtParticipante_Participanteid_Z, false, includeNonInitialized);
            AddObjectProperty("ParticipanteDocumento_Z", gxTv_SdtParticipante_Participantedocumento_Z, false, includeNonInitialized);
            AddObjectProperty("ParticipanteNome_Z", gxTv_SdtParticipante_Participantenome_Z, false, includeNonInitialized);
            AddObjectProperty("ParticipanteEmail_Z", gxTv_SdtParticipante_Participanteemail_Z, false, includeNonInitialized);
            AddObjectProperty("ParticipanteTipoPessoa_Z", gxTv_SdtParticipante_Participantetipopessoa_Z, false, includeNonInitialized);
            AddObjectProperty("ParticipanteRepresentanteNome_Z", gxTv_SdtParticipante_Participanterepresentantenome_Z, false, includeNonInitialized);
            AddObjectProperty("ParticipanteRepresentanteEmail_Z", gxTv_SdtParticipante_Participanterepresentanteemail_Z, false, includeNonInitialized);
            AddObjectProperty("ParticipanteRepresentanteDocumento_Z", gxTv_SdtParticipante_Participanterepresentantedocumento_Z, false, includeNonInitialized);
            AddObjectProperty("ParticipanteEmail_F_Z", gxTv_SdtParticipante_Participanteemail_f_Z, false, includeNonInitialized);
            AddObjectProperty("ParticipanteDocumento_F_Z", gxTv_SdtParticipante_Participantedocumento_f_Z, false, includeNonInitialized);
            AddObjectProperty("ParticipanteId_N", gxTv_SdtParticipante_Participanteid_N, false, includeNonInitialized);
            AddObjectProperty("ParticipanteDocumento_N", gxTv_SdtParticipante_Participantedocumento_N, false, includeNonInitialized);
            AddObjectProperty("ParticipanteNome_N", gxTv_SdtParticipante_Participantenome_N, false, includeNonInitialized);
            AddObjectProperty("ParticipanteEmail_N", gxTv_SdtParticipante_Participanteemail_N, false, includeNonInitialized);
            AddObjectProperty("ParticipanteTipoPessoa_N", gxTv_SdtParticipante_Participantetipopessoa_N, false, includeNonInitialized);
            AddObjectProperty("ParticipanteRepresentanteNome_N", gxTv_SdtParticipante_Participanterepresentantenome_N, false, includeNonInitialized);
            AddObjectProperty("ParticipanteRepresentanteEmail_N", gxTv_SdtParticipante_Participanterepresentanteemail_N, false, includeNonInitialized);
            AddObjectProperty("ParticipanteRepresentanteDocumento_N", gxTv_SdtParticipante_Participanterepresentantedocumento_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtParticipante sdt )
      {
         if ( sdt.IsDirty("ParticipanteId") )
         {
            sdtIsNull = 0;
            gxTv_SdtParticipante_Participanteid = sdt.gxTv_SdtParticipante_Participanteid ;
         }
         if ( sdt.IsDirty("ParticipanteDocumento") )
         {
            gxTv_SdtParticipante_Participantedocumento_N = (short)(sdt.gxTv_SdtParticipante_Participantedocumento_N);
            sdtIsNull = 0;
            gxTv_SdtParticipante_Participantedocumento = sdt.gxTv_SdtParticipante_Participantedocumento ;
         }
         if ( sdt.IsDirty("ParticipanteNome") )
         {
            gxTv_SdtParticipante_Participantenome_N = (short)(sdt.gxTv_SdtParticipante_Participantenome_N);
            sdtIsNull = 0;
            gxTv_SdtParticipante_Participantenome = sdt.gxTv_SdtParticipante_Participantenome ;
         }
         if ( sdt.IsDirty("ParticipanteEmail") )
         {
            gxTv_SdtParticipante_Participanteemail_N = (short)(sdt.gxTv_SdtParticipante_Participanteemail_N);
            sdtIsNull = 0;
            gxTv_SdtParticipante_Participanteemail = sdt.gxTv_SdtParticipante_Participanteemail ;
         }
         if ( sdt.IsDirty("ParticipanteTipoPessoa") )
         {
            gxTv_SdtParticipante_Participantetipopessoa_N = (short)(sdt.gxTv_SdtParticipante_Participantetipopessoa_N);
            sdtIsNull = 0;
            gxTv_SdtParticipante_Participantetipopessoa = sdt.gxTv_SdtParticipante_Participantetipopessoa ;
         }
         if ( sdt.IsDirty("ParticipanteRepresentanteNome") )
         {
            gxTv_SdtParticipante_Participanterepresentantenome_N = (short)(sdt.gxTv_SdtParticipante_Participanterepresentantenome_N);
            sdtIsNull = 0;
            gxTv_SdtParticipante_Participanterepresentantenome = sdt.gxTv_SdtParticipante_Participanterepresentantenome ;
         }
         if ( sdt.IsDirty("ParticipanteRepresentanteEmail") )
         {
            gxTv_SdtParticipante_Participanterepresentanteemail_N = (short)(sdt.gxTv_SdtParticipante_Participanterepresentanteemail_N);
            sdtIsNull = 0;
            gxTv_SdtParticipante_Participanterepresentanteemail = sdt.gxTv_SdtParticipante_Participanterepresentanteemail ;
         }
         if ( sdt.IsDirty("ParticipanteRepresentanteDocumento") )
         {
            gxTv_SdtParticipante_Participanterepresentantedocumento_N = (short)(sdt.gxTv_SdtParticipante_Participanterepresentantedocumento_N);
            sdtIsNull = 0;
            gxTv_SdtParticipante_Participanterepresentantedocumento = sdt.gxTv_SdtParticipante_Participanterepresentantedocumento ;
         }
         if ( sdt.IsDirty("ParticipanteEmail_F") )
         {
            sdtIsNull = 0;
            gxTv_SdtParticipante_Participanteemail_f = sdt.gxTv_SdtParticipante_Participanteemail_f ;
         }
         if ( sdt.IsDirty("ParticipanteDocumento_F") )
         {
            sdtIsNull = 0;
            gxTv_SdtParticipante_Participantedocumento_f = sdt.gxTv_SdtParticipante_Participantedocumento_f ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ParticipanteId" )]
      [  XmlElement( ElementName = "ParticipanteId"   )]
      public int gxTpr_Participanteid
      {
         get {
            return gxTv_SdtParticipante_Participanteid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtParticipante_Participanteid != value )
            {
               gxTv_SdtParticipante_Mode = "INS";
               this.gxTv_SdtParticipante_Participanteid_Z_SetNull( );
               this.gxTv_SdtParticipante_Participantedocumento_Z_SetNull( );
               this.gxTv_SdtParticipante_Participantenome_Z_SetNull( );
               this.gxTv_SdtParticipante_Participanteemail_Z_SetNull( );
               this.gxTv_SdtParticipante_Participantetipopessoa_Z_SetNull( );
               this.gxTv_SdtParticipante_Participanterepresentantenome_Z_SetNull( );
               this.gxTv_SdtParticipante_Participanterepresentanteemail_Z_SetNull( );
               this.gxTv_SdtParticipante_Participanterepresentantedocumento_Z_SetNull( );
               this.gxTv_SdtParticipante_Participanteemail_f_Z_SetNull( );
               this.gxTv_SdtParticipante_Participantedocumento_f_Z_SetNull( );
            }
            gxTv_SdtParticipante_Participanteid = value;
            SetDirty("Participanteid");
         }

      }

      [  SoapElement( ElementName = "ParticipanteDocumento" )]
      [  XmlElement( ElementName = "ParticipanteDocumento"   )]
      public string gxTpr_Participantedocumento
      {
         get {
            return gxTv_SdtParticipante_Participantedocumento ;
         }

         set {
            gxTv_SdtParticipante_Participantedocumento_N = 0;
            sdtIsNull = 0;
            gxTv_SdtParticipante_Participantedocumento = value;
            SetDirty("Participantedocumento");
         }

      }

      public void gxTv_SdtParticipante_Participantedocumento_SetNull( )
      {
         gxTv_SdtParticipante_Participantedocumento_N = 1;
         gxTv_SdtParticipante_Participantedocumento = "";
         SetDirty("Participantedocumento");
         return  ;
      }

      public bool gxTv_SdtParticipante_Participantedocumento_IsNull( )
      {
         return (gxTv_SdtParticipante_Participantedocumento_N==1) ;
      }

      [  SoapElement( ElementName = "ParticipanteNome" )]
      [  XmlElement( ElementName = "ParticipanteNome"   )]
      public string gxTpr_Participantenome
      {
         get {
            return gxTv_SdtParticipante_Participantenome ;
         }

         set {
            gxTv_SdtParticipante_Participantenome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtParticipante_Participantenome = value;
            SetDirty("Participantenome");
         }

      }

      public void gxTv_SdtParticipante_Participantenome_SetNull( )
      {
         gxTv_SdtParticipante_Participantenome_N = 1;
         gxTv_SdtParticipante_Participantenome = "";
         SetDirty("Participantenome");
         return  ;
      }

      public bool gxTv_SdtParticipante_Participantenome_IsNull( )
      {
         return (gxTv_SdtParticipante_Participantenome_N==1) ;
      }

      [  SoapElement( ElementName = "ParticipanteEmail" )]
      [  XmlElement( ElementName = "ParticipanteEmail"   )]
      public string gxTpr_Participanteemail
      {
         get {
            return gxTv_SdtParticipante_Participanteemail ;
         }

         set {
            gxTv_SdtParticipante_Participanteemail_N = 0;
            sdtIsNull = 0;
            gxTv_SdtParticipante_Participanteemail = value;
            SetDirty("Participanteemail");
         }

      }

      public void gxTv_SdtParticipante_Participanteemail_SetNull( )
      {
         gxTv_SdtParticipante_Participanteemail_N = 1;
         gxTv_SdtParticipante_Participanteemail = "";
         SetDirty("Participanteemail");
         return  ;
      }

      public bool gxTv_SdtParticipante_Participanteemail_IsNull( )
      {
         return (gxTv_SdtParticipante_Participanteemail_N==1) ;
      }

      [  SoapElement( ElementName = "ParticipanteTipoPessoa" )]
      [  XmlElement( ElementName = "ParticipanteTipoPessoa"   )]
      public string gxTpr_Participantetipopessoa
      {
         get {
            return gxTv_SdtParticipante_Participantetipopessoa ;
         }

         set {
            gxTv_SdtParticipante_Participantetipopessoa_N = 0;
            sdtIsNull = 0;
            gxTv_SdtParticipante_Participantetipopessoa = value;
            SetDirty("Participantetipopessoa");
         }

      }

      public void gxTv_SdtParticipante_Participantetipopessoa_SetNull( )
      {
         gxTv_SdtParticipante_Participantetipopessoa_N = 1;
         gxTv_SdtParticipante_Participantetipopessoa = "";
         SetDirty("Participantetipopessoa");
         return  ;
      }

      public bool gxTv_SdtParticipante_Participantetipopessoa_IsNull( )
      {
         return (gxTv_SdtParticipante_Participantetipopessoa_N==1) ;
      }

      [  SoapElement( ElementName = "ParticipanteRepresentanteNome" )]
      [  XmlElement( ElementName = "ParticipanteRepresentanteNome"   )]
      public string gxTpr_Participanterepresentantenome
      {
         get {
            return gxTv_SdtParticipante_Participanterepresentantenome ;
         }

         set {
            gxTv_SdtParticipante_Participanterepresentantenome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtParticipante_Participanterepresentantenome = value;
            SetDirty("Participanterepresentantenome");
         }

      }

      public void gxTv_SdtParticipante_Participanterepresentantenome_SetNull( )
      {
         gxTv_SdtParticipante_Participanterepresentantenome_N = 1;
         gxTv_SdtParticipante_Participanterepresentantenome = "";
         SetDirty("Participanterepresentantenome");
         return  ;
      }

      public bool gxTv_SdtParticipante_Participanterepresentantenome_IsNull( )
      {
         return (gxTv_SdtParticipante_Participanterepresentantenome_N==1) ;
      }

      [  SoapElement( ElementName = "ParticipanteRepresentanteEmail" )]
      [  XmlElement( ElementName = "ParticipanteRepresentanteEmail"   )]
      public string gxTpr_Participanterepresentanteemail
      {
         get {
            return gxTv_SdtParticipante_Participanterepresentanteemail ;
         }

         set {
            gxTv_SdtParticipante_Participanterepresentanteemail_N = 0;
            sdtIsNull = 0;
            gxTv_SdtParticipante_Participanterepresentanteemail = value;
            SetDirty("Participanterepresentanteemail");
         }

      }

      public void gxTv_SdtParticipante_Participanterepresentanteemail_SetNull( )
      {
         gxTv_SdtParticipante_Participanterepresentanteemail_N = 1;
         gxTv_SdtParticipante_Participanterepresentanteemail = "";
         SetDirty("Participanterepresentanteemail");
         return  ;
      }

      public bool gxTv_SdtParticipante_Participanterepresentanteemail_IsNull( )
      {
         return (gxTv_SdtParticipante_Participanterepresentanteemail_N==1) ;
      }

      [  SoapElement( ElementName = "ParticipanteRepresentanteDocumento" )]
      [  XmlElement( ElementName = "ParticipanteRepresentanteDocumento"   )]
      public string gxTpr_Participanterepresentantedocumento
      {
         get {
            return gxTv_SdtParticipante_Participanterepresentantedocumento ;
         }

         set {
            gxTv_SdtParticipante_Participanterepresentantedocumento_N = 0;
            sdtIsNull = 0;
            gxTv_SdtParticipante_Participanterepresentantedocumento = value;
            SetDirty("Participanterepresentantedocumento");
         }

      }

      public void gxTv_SdtParticipante_Participanterepresentantedocumento_SetNull( )
      {
         gxTv_SdtParticipante_Participanterepresentantedocumento_N = 1;
         gxTv_SdtParticipante_Participanterepresentantedocumento = "";
         SetDirty("Participanterepresentantedocumento");
         return  ;
      }

      public bool gxTv_SdtParticipante_Participanterepresentantedocumento_IsNull( )
      {
         return (gxTv_SdtParticipante_Participanterepresentantedocumento_N==1) ;
      }

      [  SoapElement( ElementName = "ParticipanteEmail_F" )]
      [  XmlElement( ElementName = "ParticipanteEmail_F"   )]
      public string gxTpr_Participanteemail_f
      {
         get {
            return gxTv_SdtParticipante_Participanteemail_f ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParticipante_Participanteemail_f = value;
            SetDirty("Participanteemail_f");
         }

      }

      public void gxTv_SdtParticipante_Participanteemail_f_SetNull( )
      {
         gxTv_SdtParticipante_Participanteemail_f = "";
         SetDirty("Participanteemail_f");
         return  ;
      }

      public bool gxTv_SdtParticipante_Participanteemail_f_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParticipanteDocumento_F" )]
      [  XmlElement( ElementName = "ParticipanteDocumento_F"   )]
      public string gxTpr_Participantedocumento_f
      {
         get {
            return gxTv_SdtParticipante_Participantedocumento_f ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParticipante_Participantedocumento_f = value;
            SetDirty("Participantedocumento_f");
         }

      }

      public void gxTv_SdtParticipante_Participantedocumento_f_SetNull( )
      {
         gxTv_SdtParticipante_Participantedocumento_f = "";
         SetDirty("Participantedocumento_f");
         return  ;
      }

      public bool gxTv_SdtParticipante_Participantedocumento_f_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtParticipante_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParticipante_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtParticipante_Mode_SetNull( )
      {
         gxTv_SdtParticipante_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtParticipante_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtParticipante_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParticipante_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtParticipante_Initialized_SetNull( )
      {
         gxTv_SdtParticipante_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtParticipante_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParticipanteId_Z" )]
      [  XmlElement( ElementName = "ParticipanteId_Z"   )]
      public int gxTpr_Participanteid_Z
      {
         get {
            return gxTv_SdtParticipante_Participanteid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParticipante_Participanteid_Z = value;
            SetDirty("Participanteid_Z");
         }

      }

      public void gxTv_SdtParticipante_Participanteid_Z_SetNull( )
      {
         gxTv_SdtParticipante_Participanteid_Z = 0;
         SetDirty("Participanteid_Z");
         return  ;
      }

      public bool gxTv_SdtParticipante_Participanteid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParticipanteDocumento_Z" )]
      [  XmlElement( ElementName = "ParticipanteDocumento_Z"   )]
      public string gxTpr_Participantedocumento_Z
      {
         get {
            return gxTv_SdtParticipante_Participantedocumento_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParticipante_Participantedocumento_Z = value;
            SetDirty("Participantedocumento_Z");
         }

      }

      public void gxTv_SdtParticipante_Participantedocumento_Z_SetNull( )
      {
         gxTv_SdtParticipante_Participantedocumento_Z = "";
         SetDirty("Participantedocumento_Z");
         return  ;
      }

      public bool gxTv_SdtParticipante_Participantedocumento_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParticipanteNome_Z" )]
      [  XmlElement( ElementName = "ParticipanteNome_Z"   )]
      public string gxTpr_Participantenome_Z
      {
         get {
            return gxTv_SdtParticipante_Participantenome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParticipante_Participantenome_Z = value;
            SetDirty("Participantenome_Z");
         }

      }

      public void gxTv_SdtParticipante_Participantenome_Z_SetNull( )
      {
         gxTv_SdtParticipante_Participantenome_Z = "";
         SetDirty("Participantenome_Z");
         return  ;
      }

      public bool gxTv_SdtParticipante_Participantenome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParticipanteEmail_Z" )]
      [  XmlElement( ElementName = "ParticipanteEmail_Z"   )]
      public string gxTpr_Participanteemail_Z
      {
         get {
            return gxTv_SdtParticipante_Participanteemail_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParticipante_Participanteemail_Z = value;
            SetDirty("Participanteemail_Z");
         }

      }

      public void gxTv_SdtParticipante_Participanteemail_Z_SetNull( )
      {
         gxTv_SdtParticipante_Participanteemail_Z = "";
         SetDirty("Participanteemail_Z");
         return  ;
      }

      public bool gxTv_SdtParticipante_Participanteemail_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParticipanteTipoPessoa_Z" )]
      [  XmlElement( ElementName = "ParticipanteTipoPessoa_Z"   )]
      public string gxTpr_Participantetipopessoa_Z
      {
         get {
            return gxTv_SdtParticipante_Participantetipopessoa_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParticipante_Participantetipopessoa_Z = value;
            SetDirty("Participantetipopessoa_Z");
         }

      }

      public void gxTv_SdtParticipante_Participantetipopessoa_Z_SetNull( )
      {
         gxTv_SdtParticipante_Participantetipopessoa_Z = "";
         SetDirty("Participantetipopessoa_Z");
         return  ;
      }

      public bool gxTv_SdtParticipante_Participantetipopessoa_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParticipanteRepresentanteNome_Z" )]
      [  XmlElement( ElementName = "ParticipanteRepresentanteNome_Z"   )]
      public string gxTpr_Participanterepresentantenome_Z
      {
         get {
            return gxTv_SdtParticipante_Participanterepresentantenome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParticipante_Participanterepresentantenome_Z = value;
            SetDirty("Participanterepresentantenome_Z");
         }

      }

      public void gxTv_SdtParticipante_Participanterepresentantenome_Z_SetNull( )
      {
         gxTv_SdtParticipante_Participanterepresentantenome_Z = "";
         SetDirty("Participanterepresentantenome_Z");
         return  ;
      }

      public bool gxTv_SdtParticipante_Participanterepresentantenome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParticipanteRepresentanteEmail_Z" )]
      [  XmlElement( ElementName = "ParticipanteRepresentanteEmail_Z"   )]
      public string gxTpr_Participanterepresentanteemail_Z
      {
         get {
            return gxTv_SdtParticipante_Participanterepresentanteemail_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParticipante_Participanterepresentanteemail_Z = value;
            SetDirty("Participanterepresentanteemail_Z");
         }

      }

      public void gxTv_SdtParticipante_Participanterepresentanteemail_Z_SetNull( )
      {
         gxTv_SdtParticipante_Participanterepresentanteemail_Z = "";
         SetDirty("Participanterepresentanteemail_Z");
         return  ;
      }

      public bool gxTv_SdtParticipante_Participanterepresentanteemail_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParticipanteRepresentanteDocumento_Z" )]
      [  XmlElement( ElementName = "ParticipanteRepresentanteDocumento_Z"   )]
      public string gxTpr_Participanterepresentantedocumento_Z
      {
         get {
            return gxTv_SdtParticipante_Participanterepresentantedocumento_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParticipante_Participanterepresentantedocumento_Z = value;
            SetDirty("Participanterepresentantedocumento_Z");
         }

      }

      public void gxTv_SdtParticipante_Participanterepresentantedocumento_Z_SetNull( )
      {
         gxTv_SdtParticipante_Participanterepresentantedocumento_Z = "";
         SetDirty("Participanterepresentantedocumento_Z");
         return  ;
      }

      public bool gxTv_SdtParticipante_Participanterepresentantedocumento_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParticipanteEmail_F_Z" )]
      [  XmlElement( ElementName = "ParticipanteEmail_F_Z"   )]
      public string gxTpr_Participanteemail_f_Z
      {
         get {
            return gxTv_SdtParticipante_Participanteemail_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParticipante_Participanteemail_f_Z = value;
            SetDirty("Participanteemail_f_Z");
         }

      }

      public void gxTv_SdtParticipante_Participanteemail_f_Z_SetNull( )
      {
         gxTv_SdtParticipante_Participanteemail_f_Z = "";
         SetDirty("Participanteemail_f_Z");
         return  ;
      }

      public bool gxTv_SdtParticipante_Participanteemail_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParticipanteDocumento_F_Z" )]
      [  XmlElement( ElementName = "ParticipanteDocumento_F_Z"   )]
      public string gxTpr_Participantedocumento_f_Z
      {
         get {
            return gxTv_SdtParticipante_Participantedocumento_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParticipante_Participantedocumento_f_Z = value;
            SetDirty("Participantedocumento_f_Z");
         }

      }

      public void gxTv_SdtParticipante_Participantedocumento_f_Z_SetNull( )
      {
         gxTv_SdtParticipante_Participantedocumento_f_Z = "";
         SetDirty("Participantedocumento_f_Z");
         return  ;
      }

      public bool gxTv_SdtParticipante_Participantedocumento_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParticipanteId_N" )]
      [  XmlElement( ElementName = "ParticipanteId_N"   )]
      public short gxTpr_Participanteid_N
      {
         get {
            return gxTv_SdtParticipante_Participanteid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParticipante_Participanteid_N = value;
            SetDirty("Participanteid_N");
         }

      }

      public void gxTv_SdtParticipante_Participanteid_N_SetNull( )
      {
         gxTv_SdtParticipante_Participanteid_N = 0;
         SetDirty("Participanteid_N");
         return  ;
      }

      public bool gxTv_SdtParticipante_Participanteid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParticipanteDocumento_N" )]
      [  XmlElement( ElementName = "ParticipanteDocumento_N"   )]
      public short gxTpr_Participantedocumento_N
      {
         get {
            return gxTv_SdtParticipante_Participantedocumento_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParticipante_Participantedocumento_N = value;
            SetDirty("Participantedocumento_N");
         }

      }

      public void gxTv_SdtParticipante_Participantedocumento_N_SetNull( )
      {
         gxTv_SdtParticipante_Participantedocumento_N = 0;
         SetDirty("Participantedocumento_N");
         return  ;
      }

      public bool gxTv_SdtParticipante_Participantedocumento_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParticipanteNome_N" )]
      [  XmlElement( ElementName = "ParticipanteNome_N"   )]
      public short gxTpr_Participantenome_N
      {
         get {
            return gxTv_SdtParticipante_Participantenome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParticipante_Participantenome_N = value;
            SetDirty("Participantenome_N");
         }

      }

      public void gxTv_SdtParticipante_Participantenome_N_SetNull( )
      {
         gxTv_SdtParticipante_Participantenome_N = 0;
         SetDirty("Participantenome_N");
         return  ;
      }

      public bool gxTv_SdtParticipante_Participantenome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParticipanteEmail_N" )]
      [  XmlElement( ElementName = "ParticipanteEmail_N"   )]
      public short gxTpr_Participanteemail_N
      {
         get {
            return gxTv_SdtParticipante_Participanteemail_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParticipante_Participanteemail_N = value;
            SetDirty("Participanteemail_N");
         }

      }

      public void gxTv_SdtParticipante_Participanteemail_N_SetNull( )
      {
         gxTv_SdtParticipante_Participanteemail_N = 0;
         SetDirty("Participanteemail_N");
         return  ;
      }

      public bool gxTv_SdtParticipante_Participanteemail_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParticipanteTipoPessoa_N" )]
      [  XmlElement( ElementName = "ParticipanteTipoPessoa_N"   )]
      public short gxTpr_Participantetipopessoa_N
      {
         get {
            return gxTv_SdtParticipante_Participantetipopessoa_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParticipante_Participantetipopessoa_N = value;
            SetDirty("Participantetipopessoa_N");
         }

      }

      public void gxTv_SdtParticipante_Participantetipopessoa_N_SetNull( )
      {
         gxTv_SdtParticipante_Participantetipopessoa_N = 0;
         SetDirty("Participantetipopessoa_N");
         return  ;
      }

      public bool gxTv_SdtParticipante_Participantetipopessoa_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParticipanteRepresentanteNome_N" )]
      [  XmlElement( ElementName = "ParticipanteRepresentanteNome_N"   )]
      public short gxTpr_Participanterepresentantenome_N
      {
         get {
            return gxTv_SdtParticipante_Participanterepresentantenome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParticipante_Participanterepresentantenome_N = value;
            SetDirty("Participanterepresentantenome_N");
         }

      }

      public void gxTv_SdtParticipante_Participanterepresentantenome_N_SetNull( )
      {
         gxTv_SdtParticipante_Participanterepresentantenome_N = 0;
         SetDirty("Participanterepresentantenome_N");
         return  ;
      }

      public bool gxTv_SdtParticipante_Participanterepresentantenome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParticipanteRepresentanteEmail_N" )]
      [  XmlElement( ElementName = "ParticipanteRepresentanteEmail_N"   )]
      public short gxTpr_Participanterepresentanteemail_N
      {
         get {
            return gxTv_SdtParticipante_Participanterepresentanteemail_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParticipante_Participanterepresentanteemail_N = value;
            SetDirty("Participanterepresentanteemail_N");
         }

      }

      public void gxTv_SdtParticipante_Participanterepresentanteemail_N_SetNull( )
      {
         gxTv_SdtParticipante_Participanterepresentanteemail_N = 0;
         SetDirty("Participanterepresentanteemail_N");
         return  ;
      }

      public bool gxTv_SdtParticipante_Participanterepresentanteemail_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParticipanteRepresentanteDocumento_N" )]
      [  XmlElement( ElementName = "ParticipanteRepresentanteDocumento_N"   )]
      public short gxTpr_Participanterepresentantedocumento_N
      {
         get {
            return gxTv_SdtParticipante_Participanterepresentantedocumento_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParticipante_Participanterepresentantedocumento_N = value;
            SetDirty("Participanterepresentantedocumento_N");
         }

      }

      public void gxTv_SdtParticipante_Participanterepresentantedocumento_N_SetNull( )
      {
         gxTv_SdtParticipante_Participanterepresentantedocumento_N = 0;
         SetDirty("Participanterepresentantedocumento_N");
         return  ;
      }

      public bool gxTv_SdtParticipante_Participanterepresentantedocumento_N_IsNull( )
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
         gxTv_SdtParticipante_Participantedocumento = "";
         gxTv_SdtParticipante_Participantenome = "";
         gxTv_SdtParticipante_Participanteemail = "";
         gxTv_SdtParticipante_Participantetipopessoa = "";
         gxTv_SdtParticipante_Participanterepresentantenome = "";
         gxTv_SdtParticipante_Participanterepresentanteemail = "";
         gxTv_SdtParticipante_Participanterepresentantedocumento = "";
         gxTv_SdtParticipante_Participanteemail_f = "";
         gxTv_SdtParticipante_Participantedocumento_f = "";
         gxTv_SdtParticipante_Mode = "";
         gxTv_SdtParticipante_Participantedocumento_Z = "";
         gxTv_SdtParticipante_Participantenome_Z = "";
         gxTv_SdtParticipante_Participanteemail_Z = "";
         gxTv_SdtParticipante_Participantetipopessoa_Z = "";
         gxTv_SdtParticipante_Participanterepresentantenome_Z = "";
         gxTv_SdtParticipante_Participanterepresentanteemail_Z = "";
         gxTv_SdtParticipante_Participanterepresentantedocumento_Z = "";
         gxTv_SdtParticipante_Participanteemail_f_Z = "";
         gxTv_SdtParticipante_Participantedocumento_f_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "participante", "GeneXus.Programs.participante_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtParticipante_Initialized ;
      private short gxTv_SdtParticipante_Participanteid_N ;
      private short gxTv_SdtParticipante_Participantedocumento_N ;
      private short gxTv_SdtParticipante_Participantenome_N ;
      private short gxTv_SdtParticipante_Participanteemail_N ;
      private short gxTv_SdtParticipante_Participantetipopessoa_N ;
      private short gxTv_SdtParticipante_Participanterepresentantenome_N ;
      private short gxTv_SdtParticipante_Participanterepresentanteemail_N ;
      private short gxTv_SdtParticipante_Participanterepresentantedocumento_N ;
      private int gxTv_SdtParticipante_Participanteid ;
      private int gxTv_SdtParticipante_Participanteid_Z ;
      private string gxTv_SdtParticipante_Mode ;
      private string gxTv_SdtParticipante_Participantedocumento ;
      private string gxTv_SdtParticipante_Participantenome ;
      private string gxTv_SdtParticipante_Participanteemail ;
      private string gxTv_SdtParticipante_Participantetipopessoa ;
      private string gxTv_SdtParticipante_Participanterepresentantenome ;
      private string gxTv_SdtParticipante_Participanterepresentanteemail ;
      private string gxTv_SdtParticipante_Participanterepresentantedocumento ;
      private string gxTv_SdtParticipante_Participanteemail_f ;
      private string gxTv_SdtParticipante_Participantedocumento_f ;
      private string gxTv_SdtParticipante_Participantedocumento_Z ;
      private string gxTv_SdtParticipante_Participantenome_Z ;
      private string gxTv_SdtParticipante_Participanteemail_Z ;
      private string gxTv_SdtParticipante_Participantetipopessoa_Z ;
      private string gxTv_SdtParticipante_Participanterepresentantenome_Z ;
      private string gxTv_SdtParticipante_Participanterepresentanteemail_Z ;
      private string gxTv_SdtParticipante_Participanterepresentantedocumento_Z ;
      private string gxTv_SdtParticipante_Participanteemail_f_Z ;
      private string gxTv_SdtParticipante_Participantedocumento_f_Z ;
   }

   [DataContract(Name = @"Participante", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtParticipante_RESTInterface : GxGenericCollectionItem<SdtParticipante>
   {
      public SdtParticipante_RESTInterface( ) : base()
      {
      }

      public SdtParticipante_RESTInterface( SdtParticipante psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ParticipanteId" , Order = 0 )]
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

      [DataMember( Name = "ParticipanteDocumento" , Order = 1 )]
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

      [DataMember( Name = "ParticipanteNome" , Order = 2 )]
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

      [DataMember( Name = "ParticipanteEmail" , Order = 3 )]
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

      [DataMember( Name = "ParticipanteTipoPessoa" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Participantetipopessoa
      {
         get {
            return sdt.gxTpr_Participantetipopessoa ;
         }

         set {
            sdt.gxTpr_Participantetipopessoa = value;
         }

      }

      [DataMember( Name = "ParticipanteRepresentanteNome" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Participanterepresentantenome
      {
         get {
            return sdt.gxTpr_Participanterepresentantenome ;
         }

         set {
            sdt.gxTpr_Participanterepresentantenome = value;
         }

      }

      [DataMember( Name = "ParticipanteRepresentanteEmail" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Participanterepresentanteemail
      {
         get {
            return sdt.gxTpr_Participanterepresentanteemail ;
         }

         set {
            sdt.gxTpr_Participanterepresentanteemail = value;
         }

      }

      [DataMember( Name = "ParticipanteRepresentanteDocumento" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Participanterepresentantedocumento
      {
         get {
            return sdt.gxTpr_Participanterepresentantedocumento ;
         }

         set {
            sdt.gxTpr_Participanterepresentantedocumento = value;
         }

      }

      [DataMember( Name = "ParticipanteEmail_F" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Participanteemail_f
      {
         get {
            return sdt.gxTpr_Participanteemail_f ;
         }

         set {
            sdt.gxTpr_Participanteemail_f = value;
         }

      }

      [DataMember( Name = "ParticipanteDocumento_F" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Participantedocumento_f
      {
         get {
            return sdt.gxTpr_Participantedocumento_f ;
         }

         set {
            sdt.gxTpr_Participantedocumento_f = value;
         }

      }

      public SdtParticipante sdt
      {
         get {
            return (SdtParticipante)Sdt ;
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
            sdt = new SdtParticipante() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 10 )]
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

   [DataContract(Name = @"Participante", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtParticipante_RESTLInterface : GxGenericCollectionItem<SdtParticipante>
   {
      public SdtParticipante_RESTLInterface( ) : base()
      {
      }

      public SdtParticipante_RESTLInterface( SdtParticipante psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ParticipanteDocumento" , Order = 0 )]
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

      [DataMember( Name = "uri" , Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtParticipante sdt
      {
         get {
            return (SdtParticipante)Sdt ;
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
            sdt = new SdtParticipante() ;
         }
      }

   }

}
