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
namespace GeneXus.Programs.wwpbaseobjects {
   [XmlRoot(ElementName = "SecFunctionality" )]
   [XmlType(TypeName =  "SecFunctionality" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtSecFunctionality : GxSilentTrnSdt
   {
      public SdtSecFunctionality( )
      {
      }

      public SdtSecFunctionality( IGxContext context )
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

      public void Load( long AV128SecFunctionalityId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(long)AV128SecFunctionalityId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"SecFunctionalityId", typeof(long)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "WWPBaseObjects\\SecFunctionality");
         metadata.Set("BT", "SecFunctionality");
         metadata.Set("PK", "[ \"SecFunctionalityId\" ]");
         metadata.Set("PKAssigned", "[ \"SecFunctionalityId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"SecFunctionalityId\" ],\"FKMap\":[ \"SecParentFunctionalityId-SecFunctionalityId\" ] } ]");
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
         state.Add("gxTpr_Secfunctionalityid_Z");
         state.Add("gxTpr_Secfunctionalitykey_Z");
         state.Add("gxTpr_Secfunctionalitydescription_Z");
         state.Add("gxTpr_Secfunctionalitymodule_Z");
         state.Add("gxTpr_Secfunctionalitytype_Z");
         state.Add("gxTpr_Secparentfunctionalityid_Z");
         state.Add("gxTpr_Secparentfunctionalitydescription_Z");
         state.Add("gxTpr_Secfunctionalityactive_Z");
         state.Add("gxTpr_Secfunctionalitykey_N");
         state.Add("gxTpr_Secfunctionalitydescription_N");
         state.Add("gxTpr_Secfunctionalitymodule_N");
         state.Add("gxTpr_Secfunctionalitytype_N");
         state.Add("gxTpr_Secparentfunctionalityid_N");
         state.Add("gxTpr_Secparentfunctionalitydescription_N");
         state.Add("gxTpr_Secfunctionalityactive_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.wwpbaseobjects.SdtSecFunctionality sdt;
         sdt = (GeneXus.Programs.wwpbaseobjects.SdtSecFunctionality)(source);
         gxTv_SdtSecFunctionality_Secfunctionalityid = sdt.gxTv_SdtSecFunctionality_Secfunctionalityid ;
         gxTv_SdtSecFunctionality_Secfunctionalitykey = sdt.gxTv_SdtSecFunctionality_Secfunctionalitykey ;
         gxTv_SdtSecFunctionality_Secfunctionalitydescription = sdt.gxTv_SdtSecFunctionality_Secfunctionalitydescription ;
         gxTv_SdtSecFunctionality_Secfunctionalitymodule = sdt.gxTv_SdtSecFunctionality_Secfunctionalitymodule ;
         gxTv_SdtSecFunctionality_Secfunctionalitytype = sdt.gxTv_SdtSecFunctionality_Secfunctionalitytype ;
         gxTv_SdtSecFunctionality_Secparentfunctionalityid = sdt.gxTv_SdtSecFunctionality_Secparentfunctionalityid ;
         gxTv_SdtSecFunctionality_Secparentfunctionalitydescription = sdt.gxTv_SdtSecFunctionality_Secparentfunctionalitydescription ;
         gxTv_SdtSecFunctionality_Secfunctionalityactive = sdt.gxTv_SdtSecFunctionality_Secfunctionalityactive ;
         gxTv_SdtSecFunctionality_Mode = sdt.gxTv_SdtSecFunctionality_Mode ;
         gxTv_SdtSecFunctionality_Initialized = sdt.gxTv_SdtSecFunctionality_Initialized ;
         gxTv_SdtSecFunctionality_Secfunctionalityid_Z = sdt.gxTv_SdtSecFunctionality_Secfunctionalityid_Z ;
         gxTv_SdtSecFunctionality_Secfunctionalitykey_Z = sdt.gxTv_SdtSecFunctionality_Secfunctionalitykey_Z ;
         gxTv_SdtSecFunctionality_Secfunctionalitydescription_Z = sdt.gxTv_SdtSecFunctionality_Secfunctionalitydescription_Z ;
         gxTv_SdtSecFunctionality_Secfunctionalitymodule_Z = sdt.gxTv_SdtSecFunctionality_Secfunctionalitymodule_Z ;
         gxTv_SdtSecFunctionality_Secfunctionalitytype_Z = sdt.gxTv_SdtSecFunctionality_Secfunctionalitytype_Z ;
         gxTv_SdtSecFunctionality_Secparentfunctionalityid_Z = sdt.gxTv_SdtSecFunctionality_Secparentfunctionalityid_Z ;
         gxTv_SdtSecFunctionality_Secparentfunctionalitydescription_Z = sdt.gxTv_SdtSecFunctionality_Secparentfunctionalitydescription_Z ;
         gxTv_SdtSecFunctionality_Secfunctionalityactive_Z = sdt.gxTv_SdtSecFunctionality_Secfunctionalityactive_Z ;
         gxTv_SdtSecFunctionality_Secfunctionalitykey_N = sdt.gxTv_SdtSecFunctionality_Secfunctionalitykey_N ;
         gxTv_SdtSecFunctionality_Secfunctionalitydescription_N = sdt.gxTv_SdtSecFunctionality_Secfunctionalitydescription_N ;
         gxTv_SdtSecFunctionality_Secfunctionalitymodule_N = sdt.gxTv_SdtSecFunctionality_Secfunctionalitymodule_N ;
         gxTv_SdtSecFunctionality_Secfunctionalitytype_N = sdt.gxTv_SdtSecFunctionality_Secfunctionalitytype_N ;
         gxTv_SdtSecFunctionality_Secparentfunctionalityid_N = sdt.gxTv_SdtSecFunctionality_Secparentfunctionalityid_N ;
         gxTv_SdtSecFunctionality_Secparentfunctionalitydescription_N = sdt.gxTv_SdtSecFunctionality_Secparentfunctionalitydescription_N ;
         gxTv_SdtSecFunctionality_Secfunctionalityactive_N = sdt.gxTv_SdtSecFunctionality_Secfunctionalityactive_N ;
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
         AddObjectProperty("SecFunctionalityId", gxTv_SdtSecFunctionality_Secfunctionalityid, false, includeNonInitialized);
         AddObjectProperty("SecFunctionalityKey", gxTv_SdtSecFunctionality_Secfunctionalitykey, false, includeNonInitialized);
         AddObjectProperty("SecFunctionalityKey_N", gxTv_SdtSecFunctionality_Secfunctionalitykey_N, false, includeNonInitialized);
         AddObjectProperty("SecFunctionalityDescription", gxTv_SdtSecFunctionality_Secfunctionalitydescription, false, includeNonInitialized);
         AddObjectProperty("SecFunctionalityDescription_N", gxTv_SdtSecFunctionality_Secfunctionalitydescription_N, false, includeNonInitialized);
         AddObjectProperty("SecFunctionalityModule", gxTv_SdtSecFunctionality_Secfunctionalitymodule, false, includeNonInitialized);
         AddObjectProperty("SecFunctionalityModule_N", gxTv_SdtSecFunctionality_Secfunctionalitymodule_N, false, includeNonInitialized);
         AddObjectProperty("SecFunctionalityType", gxTv_SdtSecFunctionality_Secfunctionalitytype, false, includeNonInitialized);
         AddObjectProperty("SecFunctionalityType_N", gxTv_SdtSecFunctionality_Secfunctionalitytype_N, false, includeNonInitialized);
         AddObjectProperty("SecParentFunctionalityId", gxTv_SdtSecFunctionality_Secparentfunctionalityid, false, includeNonInitialized);
         AddObjectProperty("SecParentFunctionalityId_N", gxTv_SdtSecFunctionality_Secparentfunctionalityid_N, false, includeNonInitialized);
         AddObjectProperty("SecParentFunctionalityDescription", gxTv_SdtSecFunctionality_Secparentfunctionalitydescription, false, includeNonInitialized);
         AddObjectProperty("SecParentFunctionalityDescription_N", gxTv_SdtSecFunctionality_Secparentfunctionalitydescription_N, false, includeNonInitialized);
         AddObjectProperty("SecFunctionalityActive", gxTv_SdtSecFunctionality_Secfunctionalityactive, false, includeNonInitialized);
         AddObjectProperty("SecFunctionalityActive_N", gxTv_SdtSecFunctionality_Secfunctionalityactive_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtSecFunctionality_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtSecFunctionality_Initialized, false, includeNonInitialized);
            AddObjectProperty("SecFunctionalityId_Z", gxTv_SdtSecFunctionality_Secfunctionalityid_Z, false, includeNonInitialized);
            AddObjectProperty("SecFunctionalityKey_Z", gxTv_SdtSecFunctionality_Secfunctionalitykey_Z, false, includeNonInitialized);
            AddObjectProperty("SecFunctionalityDescription_Z", gxTv_SdtSecFunctionality_Secfunctionalitydescription_Z, false, includeNonInitialized);
            AddObjectProperty("SecFunctionalityModule_Z", gxTv_SdtSecFunctionality_Secfunctionalitymodule_Z, false, includeNonInitialized);
            AddObjectProperty("SecFunctionalityType_Z", gxTv_SdtSecFunctionality_Secfunctionalitytype_Z, false, includeNonInitialized);
            AddObjectProperty("SecParentFunctionalityId_Z", gxTv_SdtSecFunctionality_Secparentfunctionalityid_Z, false, includeNonInitialized);
            AddObjectProperty("SecParentFunctionalityDescription_Z", gxTv_SdtSecFunctionality_Secparentfunctionalitydescription_Z, false, includeNonInitialized);
            AddObjectProperty("SecFunctionalityActive_Z", gxTv_SdtSecFunctionality_Secfunctionalityactive_Z, false, includeNonInitialized);
            AddObjectProperty("SecFunctionalityKey_N", gxTv_SdtSecFunctionality_Secfunctionalitykey_N, false, includeNonInitialized);
            AddObjectProperty("SecFunctionalityDescription_N", gxTv_SdtSecFunctionality_Secfunctionalitydescription_N, false, includeNonInitialized);
            AddObjectProperty("SecFunctionalityModule_N", gxTv_SdtSecFunctionality_Secfunctionalitymodule_N, false, includeNonInitialized);
            AddObjectProperty("SecFunctionalityType_N", gxTv_SdtSecFunctionality_Secfunctionalitytype_N, false, includeNonInitialized);
            AddObjectProperty("SecParentFunctionalityId_N", gxTv_SdtSecFunctionality_Secparentfunctionalityid_N, false, includeNonInitialized);
            AddObjectProperty("SecParentFunctionalityDescription_N", gxTv_SdtSecFunctionality_Secparentfunctionalitydescription_N, false, includeNonInitialized);
            AddObjectProperty("SecFunctionalityActive_N", gxTv_SdtSecFunctionality_Secfunctionalityactive_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.wwpbaseobjects.SdtSecFunctionality sdt )
      {
         if ( sdt.IsDirty("SecFunctionalityId") )
         {
            sdtIsNull = 0;
            gxTv_SdtSecFunctionality_Secfunctionalityid = sdt.gxTv_SdtSecFunctionality_Secfunctionalityid ;
         }
         if ( sdt.IsDirty("SecFunctionalityKey") )
         {
            gxTv_SdtSecFunctionality_Secfunctionalitykey_N = (short)(sdt.gxTv_SdtSecFunctionality_Secfunctionalitykey_N);
            sdtIsNull = 0;
            gxTv_SdtSecFunctionality_Secfunctionalitykey = sdt.gxTv_SdtSecFunctionality_Secfunctionalitykey ;
         }
         if ( sdt.IsDirty("SecFunctionalityDescription") )
         {
            gxTv_SdtSecFunctionality_Secfunctionalitydescription_N = (short)(sdt.gxTv_SdtSecFunctionality_Secfunctionalitydescription_N);
            sdtIsNull = 0;
            gxTv_SdtSecFunctionality_Secfunctionalitydescription = sdt.gxTv_SdtSecFunctionality_Secfunctionalitydescription ;
         }
         if ( sdt.IsDirty("SecFunctionalityModule") )
         {
            gxTv_SdtSecFunctionality_Secfunctionalitymodule_N = (short)(sdt.gxTv_SdtSecFunctionality_Secfunctionalitymodule_N);
            sdtIsNull = 0;
            gxTv_SdtSecFunctionality_Secfunctionalitymodule = sdt.gxTv_SdtSecFunctionality_Secfunctionalitymodule ;
         }
         if ( sdt.IsDirty("SecFunctionalityType") )
         {
            gxTv_SdtSecFunctionality_Secfunctionalitytype_N = (short)(sdt.gxTv_SdtSecFunctionality_Secfunctionalitytype_N);
            sdtIsNull = 0;
            gxTv_SdtSecFunctionality_Secfunctionalitytype = sdt.gxTv_SdtSecFunctionality_Secfunctionalitytype ;
         }
         if ( sdt.IsDirty("SecParentFunctionalityId") )
         {
            gxTv_SdtSecFunctionality_Secparentfunctionalityid_N = (short)(sdt.gxTv_SdtSecFunctionality_Secparentfunctionalityid_N);
            sdtIsNull = 0;
            gxTv_SdtSecFunctionality_Secparentfunctionalityid = sdt.gxTv_SdtSecFunctionality_Secparentfunctionalityid ;
         }
         if ( sdt.IsDirty("SecParentFunctionalityDescription") )
         {
            gxTv_SdtSecFunctionality_Secparentfunctionalitydescription_N = (short)(sdt.gxTv_SdtSecFunctionality_Secparentfunctionalitydescription_N);
            sdtIsNull = 0;
            gxTv_SdtSecFunctionality_Secparentfunctionalitydescription = sdt.gxTv_SdtSecFunctionality_Secparentfunctionalitydescription ;
         }
         if ( sdt.IsDirty("SecFunctionalityActive") )
         {
            gxTv_SdtSecFunctionality_Secfunctionalityactive_N = (short)(sdt.gxTv_SdtSecFunctionality_Secfunctionalityactive_N);
            sdtIsNull = 0;
            gxTv_SdtSecFunctionality_Secfunctionalityactive = sdt.gxTv_SdtSecFunctionality_Secfunctionalityactive ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "SecFunctionalityId" )]
      [  XmlElement( ElementName = "SecFunctionalityId"   )]
      public long gxTpr_Secfunctionalityid
      {
         get {
            return gxTv_SdtSecFunctionality_Secfunctionalityid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtSecFunctionality_Secfunctionalityid != value )
            {
               gxTv_SdtSecFunctionality_Mode = "INS";
               this.gxTv_SdtSecFunctionality_Secfunctionalityid_Z_SetNull( );
               this.gxTv_SdtSecFunctionality_Secfunctionalitykey_Z_SetNull( );
               this.gxTv_SdtSecFunctionality_Secfunctionalitydescription_Z_SetNull( );
               this.gxTv_SdtSecFunctionality_Secfunctionalitymodule_Z_SetNull( );
               this.gxTv_SdtSecFunctionality_Secfunctionalitytype_Z_SetNull( );
               this.gxTv_SdtSecFunctionality_Secparentfunctionalityid_Z_SetNull( );
               this.gxTv_SdtSecFunctionality_Secparentfunctionalitydescription_Z_SetNull( );
               this.gxTv_SdtSecFunctionality_Secfunctionalityactive_Z_SetNull( );
            }
            gxTv_SdtSecFunctionality_Secfunctionalityid = value;
            SetDirty("Secfunctionalityid");
         }

      }

      [  SoapElement( ElementName = "SecFunctionalityKey" )]
      [  XmlElement( ElementName = "SecFunctionalityKey"   )]
      public string gxTpr_Secfunctionalitykey
      {
         get {
            return gxTv_SdtSecFunctionality_Secfunctionalitykey ;
         }

         set {
            gxTv_SdtSecFunctionality_Secfunctionalitykey_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSecFunctionality_Secfunctionalitykey = value;
            SetDirty("Secfunctionalitykey");
         }

      }

      public void gxTv_SdtSecFunctionality_Secfunctionalitykey_SetNull( )
      {
         gxTv_SdtSecFunctionality_Secfunctionalitykey_N = 1;
         gxTv_SdtSecFunctionality_Secfunctionalitykey = "";
         SetDirty("Secfunctionalitykey");
         return  ;
      }

      public bool gxTv_SdtSecFunctionality_Secfunctionalitykey_IsNull( )
      {
         return (gxTv_SdtSecFunctionality_Secfunctionalitykey_N==1) ;
      }

      [  SoapElement( ElementName = "SecFunctionalityDescription" )]
      [  XmlElement( ElementName = "SecFunctionalityDescription"   )]
      public string gxTpr_Secfunctionalitydescription
      {
         get {
            return gxTv_SdtSecFunctionality_Secfunctionalitydescription ;
         }

         set {
            gxTv_SdtSecFunctionality_Secfunctionalitydescription_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSecFunctionality_Secfunctionalitydescription = value;
            SetDirty("Secfunctionalitydescription");
         }

      }

      public void gxTv_SdtSecFunctionality_Secfunctionalitydescription_SetNull( )
      {
         gxTv_SdtSecFunctionality_Secfunctionalitydescription_N = 1;
         gxTv_SdtSecFunctionality_Secfunctionalitydescription = "";
         SetDirty("Secfunctionalitydescription");
         return  ;
      }

      public bool gxTv_SdtSecFunctionality_Secfunctionalitydescription_IsNull( )
      {
         return (gxTv_SdtSecFunctionality_Secfunctionalitydescription_N==1) ;
      }

      [  SoapElement( ElementName = "SecFunctionalityModule" )]
      [  XmlElement( ElementName = "SecFunctionalityModule"   )]
      public string gxTpr_Secfunctionalitymodule
      {
         get {
            return gxTv_SdtSecFunctionality_Secfunctionalitymodule ;
         }

         set {
            gxTv_SdtSecFunctionality_Secfunctionalitymodule_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSecFunctionality_Secfunctionalitymodule = value;
            SetDirty("Secfunctionalitymodule");
         }

      }

      public void gxTv_SdtSecFunctionality_Secfunctionalitymodule_SetNull( )
      {
         gxTv_SdtSecFunctionality_Secfunctionalitymodule_N = 1;
         gxTv_SdtSecFunctionality_Secfunctionalitymodule = "";
         SetDirty("Secfunctionalitymodule");
         return  ;
      }

      public bool gxTv_SdtSecFunctionality_Secfunctionalitymodule_IsNull( )
      {
         return (gxTv_SdtSecFunctionality_Secfunctionalitymodule_N==1) ;
      }

      [  SoapElement( ElementName = "SecFunctionalityType" )]
      [  XmlElement( ElementName = "SecFunctionalityType"   )]
      public short gxTpr_Secfunctionalitytype
      {
         get {
            return gxTv_SdtSecFunctionality_Secfunctionalitytype ;
         }

         set {
            gxTv_SdtSecFunctionality_Secfunctionalitytype_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSecFunctionality_Secfunctionalitytype = value;
            SetDirty("Secfunctionalitytype");
         }

      }

      public void gxTv_SdtSecFunctionality_Secfunctionalitytype_SetNull( )
      {
         gxTv_SdtSecFunctionality_Secfunctionalitytype_N = 1;
         gxTv_SdtSecFunctionality_Secfunctionalitytype = 0;
         SetDirty("Secfunctionalitytype");
         return  ;
      }

      public bool gxTv_SdtSecFunctionality_Secfunctionalitytype_IsNull( )
      {
         return (gxTv_SdtSecFunctionality_Secfunctionalitytype_N==1) ;
      }

      [  SoapElement( ElementName = "SecParentFunctionalityId" )]
      [  XmlElement( ElementName = "SecParentFunctionalityId"   )]
      public long gxTpr_Secparentfunctionalityid
      {
         get {
            return gxTv_SdtSecFunctionality_Secparentfunctionalityid ;
         }

         set {
            gxTv_SdtSecFunctionality_Secparentfunctionalityid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSecFunctionality_Secparentfunctionalityid = value;
            SetDirty("Secparentfunctionalityid");
         }

      }

      public void gxTv_SdtSecFunctionality_Secparentfunctionalityid_SetNull( )
      {
         gxTv_SdtSecFunctionality_Secparentfunctionalityid_N = 1;
         gxTv_SdtSecFunctionality_Secparentfunctionalityid = 0;
         SetDirty("Secparentfunctionalityid");
         return  ;
      }

      public bool gxTv_SdtSecFunctionality_Secparentfunctionalityid_IsNull( )
      {
         return (gxTv_SdtSecFunctionality_Secparentfunctionalityid_N==1) ;
      }

      [  SoapElement( ElementName = "SecParentFunctionalityDescription" )]
      [  XmlElement( ElementName = "SecParentFunctionalityDescription"   )]
      public string gxTpr_Secparentfunctionalitydescription
      {
         get {
            return gxTv_SdtSecFunctionality_Secparentfunctionalitydescription ;
         }

         set {
            gxTv_SdtSecFunctionality_Secparentfunctionalitydescription_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSecFunctionality_Secparentfunctionalitydescription = value;
            SetDirty("Secparentfunctionalitydescription");
         }

      }

      public void gxTv_SdtSecFunctionality_Secparentfunctionalitydescription_SetNull( )
      {
         gxTv_SdtSecFunctionality_Secparentfunctionalitydescription_N = 1;
         gxTv_SdtSecFunctionality_Secparentfunctionalitydescription = "";
         SetDirty("Secparentfunctionalitydescription");
         return  ;
      }

      public bool gxTv_SdtSecFunctionality_Secparentfunctionalitydescription_IsNull( )
      {
         return (gxTv_SdtSecFunctionality_Secparentfunctionalitydescription_N==1) ;
      }

      [  SoapElement( ElementName = "SecFunctionalityActive" )]
      [  XmlElement( ElementName = "SecFunctionalityActive"   )]
      public bool gxTpr_Secfunctionalityactive
      {
         get {
            return gxTv_SdtSecFunctionality_Secfunctionalityactive ;
         }

         set {
            gxTv_SdtSecFunctionality_Secfunctionalityactive_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSecFunctionality_Secfunctionalityactive = value;
            SetDirty("Secfunctionalityactive");
         }

      }

      public void gxTv_SdtSecFunctionality_Secfunctionalityactive_SetNull( )
      {
         gxTv_SdtSecFunctionality_Secfunctionalityactive_N = 1;
         gxTv_SdtSecFunctionality_Secfunctionalityactive = false;
         SetDirty("Secfunctionalityactive");
         return  ;
      }

      public bool gxTv_SdtSecFunctionality_Secfunctionalityactive_IsNull( )
      {
         return (gxTv_SdtSecFunctionality_Secfunctionalityactive_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtSecFunctionality_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecFunctionality_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtSecFunctionality_Mode_SetNull( )
      {
         gxTv_SdtSecFunctionality_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtSecFunctionality_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtSecFunctionality_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecFunctionality_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtSecFunctionality_Initialized_SetNull( )
      {
         gxTv_SdtSecFunctionality_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtSecFunctionality_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecFunctionalityId_Z" )]
      [  XmlElement( ElementName = "SecFunctionalityId_Z"   )]
      public long gxTpr_Secfunctionalityid_Z
      {
         get {
            return gxTv_SdtSecFunctionality_Secfunctionalityid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecFunctionality_Secfunctionalityid_Z = value;
            SetDirty("Secfunctionalityid_Z");
         }

      }

      public void gxTv_SdtSecFunctionality_Secfunctionalityid_Z_SetNull( )
      {
         gxTv_SdtSecFunctionality_Secfunctionalityid_Z = 0;
         SetDirty("Secfunctionalityid_Z");
         return  ;
      }

      public bool gxTv_SdtSecFunctionality_Secfunctionalityid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecFunctionalityKey_Z" )]
      [  XmlElement( ElementName = "SecFunctionalityKey_Z"   )]
      public string gxTpr_Secfunctionalitykey_Z
      {
         get {
            return gxTv_SdtSecFunctionality_Secfunctionalitykey_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecFunctionality_Secfunctionalitykey_Z = value;
            SetDirty("Secfunctionalitykey_Z");
         }

      }

      public void gxTv_SdtSecFunctionality_Secfunctionalitykey_Z_SetNull( )
      {
         gxTv_SdtSecFunctionality_Secfunctionalitykey_Z = "";
         SetDirty("Secfunctionalitykey_Z");
         return  ;
      }

      public bool gxTv_SdtSecFunctionality_Secfunctionalitykey_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecFunctionalityDescription_Z" )]
      [  XmlElement( ElementName = "SecFunctionalityDescription_Z"   )]
      public string gxTpr_Secfunctionalitydescription_Z
      {
         get {
            return gxTv_SdtSecFunctionality_Secfunctionalitydescription_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecFunctionality_Secfunctionalitydescription_Z = value;
            SetDirty("Secfunctionalitydescription_Z");
         }

      }

      public void gxTv_SdtSecFunctionality_Secfunctionalitydescription_Z_SetNull( )
      {
         gxTv_SdtSecFunctionality_Secfunctionalitydescription_Z = "";
         SetDirty("Secfunctionalitydescription_Z");
         return  ;
      }

      public bool gxTv_SdtSecFunctionality_Secfunctionalitydescription_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecFunctionalityModule_Z" )]
      [  XmlElement( ElementName = "SecFunctionalityModule_Z"   )]
      public string gxTpr_Secfunctionalitymodule_Z
      {
         get {
            return gxTv_SdtSecFunctionality_Secfunctionalitymodule_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecFunctionality_Secfunctionalitymodule_Z = value;
            SetDirty("Secfunctionalitymodule_Z");
         }

      }

      public void gxTv_SdtSecFunctionality_Secfunctionalitymodule_Z_SetNull( )
      {
         gxTv_SdtSecFunctionality_Secfunctionalitymodule_Z = "";
         SetDirty("Secfunctionalitymodule_Z");
         return  ;
      }

      public bool gxTv_SdtSecFunctionality_Secfunctionalitymodule_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecFunctionalityType_Z" )]
      [  XmlElement( ElementName = "SecFunctionalityType_Z"   )]
      public short gxTpr_Secfunctionalitytype_Z
      {
         get {
            return gxTv_SdtSecFunctionality_Secfunctionalitytype_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecFunctionality_Secfunctionalitytype_Z = value;
            SetDirty("Secfunctionalitytype_Z");
         }

      }

      public void gxTv_SdtSecFunctionality_Secfunctionalitytype_Z_SetNull( )
      {
         gxTv_SdtSecFunctionality_Secfunctionalitytype_Z = 0;
         SetDirty("Secfunctionalitytype_Z");
         return  ;
      }

      public bool gxTv_SdtSecFunctionality_Secfunctionalitytype_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecParentFunctionalityId_Z" )]
      [  XmlElement( ElementName = "SecParentFunctionalityId_Z"   )]
      public long gxTpr_Secparentfunctionalityid_Z
      {
         get {
            return gxTv_SdtSecFunctionality_Secparentfunctionalityid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecFunctionality_Secparentfunctionalityid_Z = value;
            SetDirty("Secparentfunctionalityid_Z");
         }

      }

      public void gxTv_SdtSecFunctionality_Secparentfunctionalityid_Z_SetNull( )
      {
         gxTv_SdtSecFunctionality_Secparentfunctionalityid_Z = 0;
         SetDirty("Secparentfunctionalityid_Z");
         return  ;
      }

      public bool gxTv_SdtSecFunctionality_Secparentfunctionalityid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecParentFunctionalityDescription_Z" )]
      [  XmlElement( ElementName = "SecParentFunctionalityDescription_Z"   )]
      public string gxTpr_Secparentfunctionalitydescription_Z
      {
         get {
            return gxTv_SdtSecFunctionality_Secparentfunctionalitydescription_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecFunctionality_Secparentfunctionalitydescription_Z = value;
            SetDirty("Secparentfunctionalitydescription_Z");
         }

      }

      public void gxTv_SdtSecFunctionality_Secparentfunctionalitydescription_Z_SetNull( )
      {
         gxTv_SdtSecFunctionality_Secparentfunctionalitydescription_Z = "";
         SetDirty("Secparentfunctionalitydescription_Z");
         return  ;
      }

      public bool gxTv_SdtSecFunctionality_Secparentfunctionalitydescription_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecFunctionalityActive_Z" )]
      [  XmlElement( ElementName = "SecFunctionalityActive_Z"   )]
      public bool gxTpr_Secfunctionalityactive_Z
      {
         get {
            return gxTv_SdtSecFunctionality_Secfunctionalityactive_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecFunctionality_Secfunctionalityactive_Z = value;
            SetDirty("Secfunctionalityactive_Z");
         }

      }

      public void gxTv_SdtSecFunctionality_Secfunctionalityactive_Z_SetNull( )
      {
         gxTv_SdtSecFunctionality_Secfunctionalityactive_Z = false;
         SetDirty("Secfunctionalityactive_Z");
         return  ;
      }

      public bool gxTv_SdtSecFunctionality_Secfunctionalityactive_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecFunctionalityKey_N" )]
      [  XmlElement( ElementName = "SecFunctionalityKey_N"   )]
      public short gxTpr_Secfunctionalitykey_N
      {
         get {
            return gxTv_SdtSecFunctionality_Secfunctionalitykey_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecFunctionality_Secfunctionalitykey_N = value;
            SetDirty("Secfunctionalitykey_N");
         }

      }

      public void gxTv_SdtSecFunctionality_Secfunctionalitykey_N_SetNull( )
      {
         gxTv_SdtSecFunctionality_Secfunctionalitykey_N = 0;
         SetDirty("Secfunctionalitykey_N");
         return  ;
      }

      public bool gxTv_SdtSecFunctionality_Secfunctionalitykey_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecFunctionalityDescription_N" )]
      [  XmlElement( ElementName = "SecFunctionalityDescription_N"   )]
      public short gxTpr_Secfunctionalitydescription_N
      {
         get {
            return gxTv_SdtSecFunctionality_Secfunctionalitydescription_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecFunctionality_Secfunctionalitydescription_N = value;
            SetDirty("Secfunctionalitydescription_N");
         }

      }

      public void gxTv_SdtSecFunctionality_Secfunctionalitydescription_N_SetNull( )
      {
         gxTv_SdtSecFunctionality_Secfunctionalitydescription_N = 0;
         SetDirty("Secfunctionalitydescription_N");
         return  ;
      }

      public bool gxTv_SdtSecFunctionality_Secfunctionalitydescription_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecFunctionalityModule_N" )]
      [  XmlElement( ElementName = "SecFunctionalityModule_N"   )]
      public short gxTpr_Secfunctionalitymodule_N
      {
         get {
            return gxTv_SdtSecFunctionality_Secfunctionalitymodule_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecFunctionality_Secfunctionalitymodule_N = value;
            SetDirty("Secfunctionalitymodule_N");
         }

      }

      public void gxTv_SdtSecFunctionality_Secfunctionalitymodule_N_SetNull( )
      {
         gxTv_SdtSecFunctionality_Secfunctionalitymodule_N = 0;
         SetDirty("Secfunctionalitymodule_N");
         return  ;
      }

      public bool gxTv_SdtSecFunctionality_Secfunctionalitymodule_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecFunctionalityType_N" )]
      [  XmlElement( ElementName = "SecFunctionalityType_N"   )]
      public short gxTpr_Secfunctionalitytype_N
      {
         get {
            return gxTv_SdtSecFunctionality_Secfunctionalitytype_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecFunctionality_Secfunctionalitytype_N = value;
            SetDirty("Secfunctionalitytype_N");
         }

      }

      public void gxTv_SdtSecFunctionality_Secfunctionalitytype_N_SetNull( )
      {
         gxTv_SdtSecFunctionality_Secfunctionalitytype_N = 0;
         SetDirty("Secfunctionalitytype_N");
         return  ;
      }

      public bool gxTv_SdtSecFunctionality_Secfunctionalitytype_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecParentFunctionalityId_N" )]
      [  XmlElement( ElementName = "SecParentFunctionalityId_N"   )]
      public short gxTpr_Secparentfunctionalityid_N
      {
         get {
            return gxTv_SdtSecFunctionality_Secparentfunctionalityid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecFunctionality_Secparentfunctionalityid_N = value;
            SetDirty("Secparentfunctionalityid_N");
         }

      }

      public void gxTv_SdtSecFunctionality_Secparentfunctionalityid_N_SetNull( )
      {
         gxTv_SdtSecFunctionality_Secparentfunctionalityid_N = 0;
         SetDirty("Secparentfunctionalityid_N");
         return  ;
      }

      public bool gxTv_SdtSecFunctionality_Secparentfunctionalityid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecParentFunctionalityDescription_N" )]
      [  XmlElement( ElementName = "SecParentFunctionalityDescription_N"   )]
      public short gxTpr_Secparentfunctionalitydescription_N
      {
         get {
            return gxTv_SdtSecFunctionality_Secparentfunctionalitydescription_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecFunctionality_Secparentfunctionalitydescription_N = value;
            SetDirty("Secparentfunctionalitydescription_N");
         }

      }

      public void gxTv_SdtSecFunctionality_Secparentfunctionalitydescription_N_SetNull( )
      {
         gxTv_SdtSecFunctionality_Secparentfunctionalitydescription_N = 0;
         SetDirty("Secparentfunctionalitydescription_N");
         return  ;
      }

      public bool gxTv_SdtSecFunctionality_Secparentfunctionalitydescription_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecFunctionalityActive_N" )]
      [  XmlElement( ElementName = "SecFunctionalityActive_N"   )]
      public short gxTpr_Secfunctionalityactive_N
      {
         get {
            return gxTv_SdtSecFunctionality_Secfunctionalityactive_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecFunctionality_Secfunctionalityactive_N = value;
            SetDirty("Secfunctionalityactive_N");
         }

      }

      public void gxTv_SdtSecFunctionality_Secfunctionalityactive_N_SetNull( )
      {
         gxTv_SdtSecFunctionality_Secfunctionalityactive_N = 0;
         SetDirty("Secfunctionalityactive_N");
         return  ;
      }

      public bool gxTv_SdtSecFunctionality_Secfunctionalityactive_N_IsNull( )
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
         gxTv_SdtSecFunctionality_Secfunctionalitykey = "";
         gxTv_SdtSecFunctionality_Secfunctionalitydescription = "";
         gxTv_SdtSecFunctionality_Secfunctionalitymodule = "";
         gxTv_SdtSecFunctionality_Secparentfunctionalitydescription = "";
         gxTv_SdtSecFunctionality_Mode = "";
         gxTv_SdtSecFunctionality_Secfunctionalitykey_Z = "";
         gxTv_SdtSecFunctionality_Secfunctionalitydescription_Z = "";
         gxTv_SdtSecFunctionality_Secfunctionalitymodule_Z = "";
         gxTv_SdtSecFunctionality_Secparentfunctionalitydescription_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "wwpbaseobjects.secfunctionality", "GeneXus.Programs.wwpbaseobjects.secfunctionality_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtSecFunctionality_Secfunctionalitytype ;
      private short gxTv_SdtSecFunctionality_Initialized ;
      private short gxTv_SdtSecFunctionality_Secfunctionalitytype_Z ;
      private short gxTv_SdtSecFunctionality_Secfunctionalitykey_N ;
      private short gxTv_SdtSecFunctionality_Secfunctionalitydescription_N ;
      private short gxTv_SdtSecFunctionality_Secfunctionalitymodule_N ;
      private short gxTv_SdtSecFunctionality_Secfunctionalitytype_N ;
      private short gxTv_SdtSecFunctionality_Secparentfunctionalityid_N ;
      private short gxTv_SdtSecFunctionality_Secparentfunctionalitydescription_N ;
      private short gxTv_SdtSecFunctionality_Secfunctionalityactive_N ;
      private long gxTv_SdtSecFunctionality_Secfunctionalityid ;
      private long gxTv_SdtSecFunctionality_Secparentfunctionalityid ;
      private long gxTv_SdtSecFunctionality_Secfunctionalityid_Z ;
      private long gxTv_SdtSecFunctionality_Secparentfunctionalityid_Z ;
      private string gxTv_SdtSecFunctionality_Mode ;
      private bool gxTv_SdtSecFunctionality_Secfunctionalityactive ;
      private bool gxTv_SdtSecFunctionality_Secfunctionalityactive_Z ;
      private string gxTv_SdtSecFunctionality_Secfunctionalitykey ;
      private string gxTv_SdtSecFunctionality_Secfunctionalitydescription ;
      private string gxTv_SdtSecFunctionality_Secfunctionalitymodule ;
      private string gxTv_SdtSecFunctionality_Secparentfunctionalitydescription ;
      private string gxTv_SdtSecFunctionality_Secfunctionalitykey_Z ;
      private string gxTv_SdtSecFunctionality_Secfunctionalitydescription_Z ;
      private string gxTv_SdtSecFunctionality_Secfunctionalitymodule_Z ;
      private string gxTv_SdtSecFunctionality_Secparentfunctionalitydescription_Z ;
   }

   [DataContract(Name = @"WWPBaseObjects\SecFunctionality", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtSecFunctionality_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.wwpbaseobjects.SdtSecFunctionality>
   {
      public SdtSecFunctionality_RESTInterface( ) : base()
      {
      }

      public SdtSecFunctionality_RESTInterface( GeneXus.Programs.wwpbaseobjects.SdtSecFunctionality psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "SecFunctionalityId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Secfunctionalityid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Secfunctionalityid), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Secfunctionalityid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "SecFunctionalityKey" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Secfunctionalitykey
      {
         get {
            return sdt.gxTpr_Secfunctionalitykey ;
         }

         set {
            sdt.gxTpr_Secfunctionalitykey = value;
         }

      }

      [DataMember( Name = "SecFunctionalityDescription" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Secfunctionalitydescription
      {
         get {
            return sdt.gxTpr_Secfunctionalitydescription ;
         }

         set {
            sdt.gxTpr_Secfunctionalitydescription = value;
         }

      }

      [DataMember( Name = "SecFunctionalityModule" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Secfunctionalitymodule
      {
         get {
            return sdt.gxTpr_Secfunctionalitymodule ;
         }

         set {
            sdt.gxTpr_Secfunctionalitymodule = value;
         }

      }

      [DataMember( Name = "SecFunctionalityType" , Order = 4 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Secfunctionalitytype
      {
         get {
            return sdt.gxTpr_Secfunctionalitytype ;
         }

         set {
            sdt.gxTpr_Secfunctionalitytype = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "SecParentFunctionalityId" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Secparentfunctionalityid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Secparentfunctionalityid), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Secparentfunctionalityid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "SecParentFunctionalityDescription" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Secparentfunctionalitydescription
      {
         get {
            return sdt.gxTpr_Secparentfunctionalitydescription ;
         }

         set {
            sdt.gxTpr_Secparentfunctionalitydescription = value;
         }

      }

      [DataMember( Name = "SecFunctionalityActive" , Order = 7 )]
      [GxSeudo()]
      public bool gxTpr_Secfunctionalityactive
      {
         get {
            return sdt.gxTpr_Secfunctionalityactive ;
         }

         set {
            sdt.gxTpr_Secfunctionalityactive = value;
         }

      }

      public GeneXus.Programs.wwpbaseobjects.SdtSecFunctionality sdt
      {
         get {
            return (GeneXus.Programs.wwpbaseobjects.SdtSecFunctionality)Sdt ;
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
            sdt = new GeneXus.Programs.wwpbaseobjects.SdtSecFunctionality() ;
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

   [DataContract(Name = @"WWPBaseObjects\SecFunctionality", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtSecFunctionality_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.wwpbaseobjects.SdtSecFunctionality>
   {
      public SdtSecFunctionality_RESTLInterface( ) : base()
      {
      }

      public SdtSecFunctionality_RESTLInterface( GeneXus.Programs.wwpbaseobjects.SdtSecFunctionality psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "SecFunctionalityDescription" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Secfunctionalitydescription
      {
         get {
            return sdt.gxTpr_Secfunctionalitydescription ;
         }

         set {
            sdt.gxTpr_Secfunctionalitydescription = value;
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

      public GeneXus.Programs.wwpbaseobjects.SdtSecFunctionality sdt
      {
         get {
            return (GeneXus.Programs.wwpbaseobjects.SdtSecFunctionality)Sdt ;
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
            sdt = new GeneXus.Programs.wwpbaseobjects.SdtSecFunctionality() ;
         }
      }

   }

}
