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
   [XmlRoot(ElementName = "AssinaturaParticipanteToken" )]
   [XmlType(TypeName =  "AssinaturaParticipanteToken" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtAssinaturaParticipanteToken : GxSilentTrnSdt
   {
      public SdtAssinaturaParticipanteToken( )
      {
      }

      public SdtAssinaturaParticipanteToken( IGxContext context )
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

      public void Load( int AV554AssinaturaParticipanteTokenId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV554AssinaturaParticipanteTokenId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"AssinaturaParticipanteTokenId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "AssinaturaParticipanteToken");
         metadata.Set("BT", "AssinaturaParticipanteToken");
         metadata.Set("PK", "[ \"AssinaturaParticipanteTokenId\" ]");
         metadata.Set("PKAssigned", "[ \"AssinaturaParticipanteTokenId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"AssinaturaParticipanteId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Assinaturaparticipantetokenid_Z");
         state.Add("gxTpr_Assinaturaparticipanteid_Z");
         state.Add("gxTpr_Assinaturaparticipantetokenexpire_Z_Nullable");
         state.Add("gxTpr_Assinaturaparticipantetokenused_Z");
         state.Add("gxTpr_Assinaturaparticipantetokencontent_Z");
         state.Add("gxTpr_Assinaturaparticipanteid_N");
         state.Add("gxTpr_Assinaturaparticipantetokenexpire_N");
         state.Add("gxTpr_Assinaturaparticipantetokenused_N");
         state.Add("gxTpr_Assinaturaparticipantetokencontent_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtAssinaturaParticipanteToken sdt;
         sdt = (SdtAssinaturaParticipanteToken)(source);
         gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenid = sdt.gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenid ;
         gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipanteid = sdt.gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipanteid ;
         gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenexpire = sdt.gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenexpire ;
         gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenused = sdt.gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenused ;
         gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokencontent = sdt.gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokencontent ;
         gxTv_SdtAssinaturaParticipanteToken_Mode = sdt.gxTv_SdtAssinaturaParticipanteToken_Mode ;
         gxTv_SdtAssinaturaParticipanteToken_Initialized = sdt.gxTv_SdtAssinaturaParticipanteToken_Initialized ;
         gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenid_Z = sdt.gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenid_Z ;
         gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipanteid_Z = sdt.gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipanteid_Z ;
         gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenexpire_Z = sdt.gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenexpire_Z ;
         gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenused_Z = sdt.gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenused_Z ;
         gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokencontent_Z = sdt.gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokencontent_Z ;
         gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipanteid_N = sdt.gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipanteid_N ;
         gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenexpire_N = sdt.gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenexpire_N ;
         gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenused_N = sdt.gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenused_N ;
         gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokencontent_N = sdt.gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokencontent_N ;
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
         AddObjectProperty("AssinaturaParticipanteTokenId", gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenid, false, includeNonInitialized);
         AddObjectProperty("AssinaturaParticipanteId", gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipanteid, false, includeNonInitialized);
         AddObjectProperty("AssinaturaParticipanteId_N", gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipanteid_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenexpire;
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
         AddObjectProperty("AssinaturaParticipanteTokenExpire", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("AssinaturaParticipanteTokenExpire_N", gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenexpire_N, false, includeNonInitialized);
         AddObjectProperty("AssinaturaParticipanteTokenUsed", gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenused, false, includeNonInitialized);
         AddObjectProperty("AssinaturaParticipanteTokenUsed_N", gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenused_N, false, includeNonInitialized);
         AddObjectProperty("AssinaturaParticipanteTokenContent", gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokencontent, false, includeNonInitialized);
         AddObjectProperty("AssinaturaParticipanteTokenContent_N", gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokencontent_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtAssinaturaParticipanteToken_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtAssinaturaParticipanteToken_Initialized, false, includeNonInitialized);
            AddObjectProperty("AssinaturaParticipanteTokenId_Z", gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenid_Z, false, includeNonInitialized);
            AddObjectProperty("AssinaturaParticipanteId_Z", gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipanteid_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenexpire_Z;
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
            AddObjectProperty("AssinaturaParticipanteTokenExpire_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("AssinaturaParticipanteTokenUsed_Z", gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenused_Z, false, includeNonInitialized);
            AddObjectProperty("AssinaturaParticipanteTokenContent_Z", gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokencontent_Z, false, includeNonInitialized);
            AddObjectProperty("AssinaturaParticipanteId_N", gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipanteid_N, false, includeNonInitialized);
            AddObjectProperty("AssinaturaParticipanteTokenExpire_N", gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenexpire_N, false, includeNonInitialized);
            AddObjectProperty("AssinaturaParticipanteTokenUsed_N", gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenused_N, false, includeNonInitialized);
            AddObjectProperty("AssinaturaParticipanteTokenContent_N", gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokencontent_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtAssinaturaParticipanteToken sdt )
      {
         if ( sdt.IsDirty("AssinaturaParticipanteTokenId") )
         {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenid = sdt.gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenid ;
         }
         if ( sdt.IsDirty("AssinaturaParticipanteId") )
         {
            gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipanteid_N = (short)(sdt.gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipanteid_N);
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipanteid = sdt.gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipanteid ;
         }
         if ( sdt.IsDirty("AssinaturaParticipanteTokenExpire") )
         {
            gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenexpire_N = (short)(sdt.gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenexpire_N);
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenexpire = sdt.gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenexpire ;
         }
         if ( sdt.IsDirty("AssinaturaParticipanteTokenUsed") )
         {
            gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenused_N = (short)(sdt.gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenused_N);
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenused = sdt.gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenused ;
         }
         if ( sdt.IsDirty("AssinaturaParticipanteTokenContent") )
         {
            gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokencontent_N = (short)(sdt.gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokencontent_N);
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokencontent = sdt.gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokencontent ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteTokenId" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteTokenId"   )]
      public int gxTpr_Assinaturaparticipantetokenid
      {
         get {
            return gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenid != value )
            {
               gxTv_SdtAssinaturaParticipanteToken_Mode = "INS";
               this.gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenid_Z_SetNull( );
               this.gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipanteid_Z_SetNull( );
               this.gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenexpire_Z_SetNull( );
               this.gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenused_Z_SetNull( );
               this.gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokencontent_Z_SetNull( );
            }
            gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenid = value;
            SetDirty("Assinaturaparticipantetokenid");
         }

      }

      [  SoapElement( ElementName = "AssinaturaParticipanteId" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteId"   )]
      public int gxTpr_Assinaturaparticipanteid
      {
         get {
            return gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipanteid ;
         }

         set {
            gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipanteid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipanteid = value;
            SetDirty("Assinaturaparticipanteid");
         }

      }

      public void gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipanteid_SetNull( )
      {
         gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipanteid_N = 1;
         gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipanteid = 0;
         SetDirty("Assinaturaparticipanteid");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipanteid_IsNull( )
      {
         return (gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipanteid_N==1) ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteTokenExpire" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteTokenExpire"  , IsNullable=true )]
      public string gxTpr_Assinaturaparticipantetokenexpire_Nullable
      {
         get {
            if ( gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenexpire == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenexpire).value ;
         }

         set {
            gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenexpire_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenexpire = DateTime.MinValue;
            else
               gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenexpire = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Assinaturaparticipantetokenexpire
      {
         get {
            return gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenexpire ;
         }

         set {
            gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenexpire_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenexpire = value;
            SetDirty("Assinaturaparticipantetokenexpire");
         }

      }

      public void gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenexpire_SetNull( )
      {
         gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenexpire_N = 1;
         gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenexpire = (DateTime)(DateTime.MinValue);
         SetDirty("Assinaturaparticipantetokenexpire");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenexpire_IsNull( )
      {
         return (gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenexpire_N==1) ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteTokenUsed" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteTokenUsed"   )]
      public bool gxTpr_Assinaturaparticipantetokenused
      {
         get {
            return gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenused ;
         }

         set {
            gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenused_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenused = value;
            SetDirty("Assinaturaparticipantetokenused");
         }

      }

      public void gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenused_SetNull( )
      {
         gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenused_N = 1;
         gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenused = false;
         SetDirty("Assinaturaparticipantetokenused");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenused_IsNull( )
      {
         return (gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenused_N==1) ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteTokenContent" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteTokenContent"   )]
      public string gxTpr_Assinaturaparticipantetokencontent
      {
         get {
            return gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokencontent ;
         }

         set {
            gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokencontent_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokencontent = value;
            SetDirty("Assinaturaparticipantetokencontent");
         }

      }

      public void gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokencontent_SetNull( )
      {
         gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokencontent_N = 1;
         gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokencontent = "";
         SetDirty("Assinaturaparticipantetokencontent");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokencontent_IsNull( )
      {
         return (gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokencontent_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtAssinaturaParticipanteToken_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipanteToken_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtAssinaturaParticipanteToken_Mode_SetNull( )
      {
         gxTv_SdtAssinaturaParticipanteToken_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipanteToken_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtAssinaturaParticipanteToken_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipanteToken_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtAssinaturaParticipanteToken_Initialized_SetNull( )
      {
         gxTv_SdtAssinaturaParticipanteToken_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipanteToken_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteTokenId_Z" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteTokenId_Z"   )]
      public int gxTpr_Assinaturaparticipantetokenid_Z
      {
         get {
            return gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenid_Z = value;
            SetDirty("Assinaturaparticipantetokenid_Z");
         }

      }

      public void gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenid_Z_SetNull( )
      {
         gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenid_Z = 0;
         SetDirty("Assinaturaparticipantetokenid_Z");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteId_Z" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteId_Z"   )]
      public int gxTpr_Assinaturaparticipanteid_Z
      {
         get {
            return gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipanteid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipanteid_Z = value;
            SetDirty("Assinaturaparticipanteid_Z");
         }

      }

      public void gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipanteid_Z_SetNull( )
      {
         gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipanteid_Z = 0;
         SetDirty("Assinaturaparticipanteid_Z");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipanteid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteTokenExpire_Z" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteTokenExpire_Z"  , IsNullable=true )]
      public string gxTpr_Assinaturaparticipantetokenexpire_Z_Nullable
      {
         get {
            if ( gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenexpire_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenexpire_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenexpire_Z = DateTime.MinValue;
            else
               gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenexpire_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Assinaturaparticipantetokenexpire_Z
      {
         get {
            return gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenexpire_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenexpire_Z = value;
            SetDirty("Assinaturaparticipantetokenexpire_Z");
         }

      }

      public void gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenexpire_Z_SetNull( )
      {
         gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenexpire_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Assinaturaparticipantetokenexpire_Z");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenexpire_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteTokenUsed_Z" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteTokenUsed_Z"   )]
      public bool gxTpr_Assinaturaparticipantetokenused_Z
      {
         get {
            return gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenused_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenused_Z = value;
            SetDirty("Assinaturaparticipantetokenused_Z");
         }

      }

      public void gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenused_Z_SetNull( )
      {
         gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenused_Z = false;
         SetDirty("Assinaturaparticipantetokenused_Z");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenused_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteTokenContent_Z" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteTokenContent_Z"   )]
      public string gxTpr_Assinaturaparticipantetokencontent_Z
      {
         get {
            return gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokencontent_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokencontent_Z = value;
            SetDirty("Assinaturaparticipantetokencontent_Z");
         }

      }

      public void gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokencontent_Z_SetNull( )
      {
         gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokencontent_Z = "";
         SetDirty("Assinaturaparticipantetokencontent_Z");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokencontent_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteId_N" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteId_N"   )]
      public short gxTpr_Assinaturaparticipanteid_N
      {
         get {
            return gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipanteid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipanteid_N = value;
            SetDirty("Assinaturaparticipanteid_N");
         }

      }

      public void gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipanteid_N_SetNull( )
      {
         gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipanteid_N = 0;
         SetDirty("Assinaturaparticipanteid_N");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipanteid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteTokenExpire_N" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteTokenExpire_N"   )]
      public short gxTpr_Assinaturaparticipantetokenexpire_N
      {
         get {
            return gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenexpire_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenexpire_N = value;
            SetDirty("Assinaturaparticipantetokenexpire_N");
         }

      }

      public void gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenexpire_N_SetNull( )
      {
         gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenexpire_N = 0;
         SetDirty("Assinaturaparticipantetokenexpire_N");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenexpire_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteTokenUsed_N" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteTokenUsed_N"   )]
      public short gxTpr_Assinaturaparticipantetokenused_N
      {
         get {
            return gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenused_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenused_N = value;
            SetDirty("Assinaturaparticipantetokenused_N");
         }

      }

      public void gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenused_N_SetNull( )
      {
         gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenused_N = 0;
         SetDirty("Assinaturaparticipantetokenused_N");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenused_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteTokenContent_N" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteTokenContent_N"   )]
      public short gxTpr_Assinaturaparticipantetokencontent_N
      {
         get {
            return gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokencontent_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokencontent_N = value;
            SetDirty("Assinaturaparticipantetokencontent_N");
         }

      }

      public void gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokencontent_N_SetNull( )
      {
         gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokencontent_N = 0;
         SetDirty("Assinaturaparticipantetokencontent_N");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokencontent_N_IsNull( )
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
         gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenexpire = (DateTime)(DateTime.MinValue);
         gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokencontent = "";
         gxTv_SdtAssinaturaParticipanteToken_Mode = "";
         gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenexpire_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokencontent_Z = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "assinaturaparticipantetoken", "GeneXus.Programs.assinaturaparticipantetoken_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtAssinaturaParticipanteToken_Initialized ;
      private short gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipanteid_N ;
      private short gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenexpire_N ;
      private short gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenused_N ;
      private short gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokencontent_N ;
      private int gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenid ;
      private int gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipanteid ;
      private int gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenid_Z ;
      private int gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipanteid_Z ;
      private string gxTv_SdtAssinaturaParticipanteToken_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenexpire ;
      private DateTime gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenexpire_Z ;
      private DateTime datetime_STZ ;
      private bool gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenused ;
      private bool gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokenused_Z ;
      private string gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokencontent ;
      private string gxTv_SdtAssinaturaParticipanteToken_Assinaturaparticipantetokencontent_Z ;
   }

   [DataContract(Name = @"AssinaturaParticipanteToken", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtAssinaturaParticipanteToken_RESTInterface : GxGenericCollectionItem<SdtAssinaturaParticipanteToken>
   {
      public SdtAssinaturaParticipanteToken_RESTInterface( ) : base()
      {
      }

      public SdtAssinaturaParticipanteToken_RESTInterface( SdtAssinaturaParticipanteToken psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "AssinaturaParticipanteTokenId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Assinaturaparticipantetokenid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Assinaturaparticipantetokenid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Assinaturaparticipantetokenid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "AssinaturaParticipanteId" , Order = 1 )]
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

      [DataMember( Name = "AssinaturaParticipanteTokenExpire" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Assinaturaparticipantetokenexpire
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Assinaturaparticipantetokenexpire, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Assinaturaparticipantetokenexpire = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "AssinaturaParticipanteTokenUsed" , Order = 3 )]
      [GxSeudo()]
      public bool gxTpr_Assinaturaparticipantetokenused
      {
         get {
            return sdt.gxTpr_Assinaturaparticipantetokenused ;
         }

         set {
            sdt.gxTpr_Assinaturaparticipantetokenused = value;
         }

      }

      [DataMember( Name = "AssinaturaParticipanteTokenContent" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Assinaturaparticipantetokencontent
      {
         get {
            return sdt.gxTpr_Assinaturaparticipantetokencontent ;
         }

         set {
            sdt.gxTpr_Assinaturaparticipantetokencontent = value;
         }

      }

      public SdtAssinaturaParticipanteToken sdt
      {
         get {
            return (SdtAssinaturaParticipanteToken)Sdt ;
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
            sdt = new SdtAssinaturaParticipanteToken() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 5 )]
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

   [DataContract(Name = @"AssinaturaParticipanteToken", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtAssinaturaParticipanteToken_RESTLInterface : GxGenericCollectionItem<SdtAssinaturaParticipanteToken>
   {
      public SdtAssinaturaParticipanteToken_RESTLInterface( ) : base()
      {
      }

      public SdtAssinaturaParticipanteToken_RESTLInterface( SdtAssinaturaParticipanteToken psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "AssinaturaParticipanteTokenExpire" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Assinaturaparticipantetokenexpire
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Assinaturaparticipantetokenexpire, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Assinaturaparticipantetokenexpire = DateTimeUtil.CToT2( value, (IGxContext)(context));
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

      public SdtAssinaturaParticipanteToken sdt
      {
         get {
            return (SdtAssinaturaParticipanteToken)Sdt ;
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
            sdt = new SdtAssinaturaParticipanteToken() ;
         }
      }

   }

}
