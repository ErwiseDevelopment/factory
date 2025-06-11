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
   [XmlRoot(ElementName = "Credito" )]
   [XmlType(TypeName =  "Credito" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtCredito : GxSilentTrnSdt
   {
      public SdtCredito( )
      {
      }

      public SdtCredito( IGxContext context )
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

      public void Load( int AV856CreditoId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV856CreditoId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"CreditoId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Credito");
         metadata.Set("BT", "Credito");
         metadata.Set("PK", "[ \"CreditoId\" ]");
         metadata.Set("PKAssigned", "[ \"CreditoId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"ClienteId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"SecUserId\" ],\"FKMap\":[ \"CreditoCreatedBy-SecUserId\" ] },{ \"FK\":[ \"SecUserId\" ],\"FKMap\":[ \"CreditoUpdatedBy-SecUserId\" ] } ]");
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
         state.Add("gxTpr_Creditoid_Z");
         state.Add("gxTpr_Clienteid_Z");
         state.Add("gxTpr_Creditovalor_Z");
         state.Add("gxTpr_Creditovigencia_Z_Nullable");
         state.Add("gxTpr_Creditocreatedat_Z_Nullable");
         state.Add("gxTpr_Creditoupdatedat_Z_Nullable");
         state.Add("gxTpr_Creditocreatedby_Z");
         state.Add("gxTpr_Creditoupdatedby_Z");
         state.Add("gxTpr_Clienteid_N");
         state.Add("gxTpr_Creditovalor_N");
         state.Add("gxTpr_Creditovigencia_N");
         state.Add("gxTpr_Creditocreatedat_N");
         state.Add("gxTpr_Creditoupdatedat_N");
         state.Add("gxTpr_Creditocreatedby_N");
         state.Add("gxTpr_Creditoupdatedby_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtCredito sdt;
         sdt = (SdtCredito)(source);
         gxTv_SdtCredito_Creditoid = sdt.gxTv_SdtCredito_Creditoid ;
         gxTv_SdtCredito_Clienteid = sdt.gxTv_SdtCredito_Clienteid ;
         gxTv_SdtCredito_Creditovalor = sdt.gxTv_SdtCredito_Creditovalor ;
         gxTv_SdtCredito_Creditovigencia = sdt.gxTv_SdtCredito_Creditovigencia ;
         gxTv_SdtCredito_Creditocreatedat = sdt.gxTv_SdtCredito_Creditocreatedat ;
         gxTv_SdtCredito_Creditoupdatedat = sdt.gxTv_SdtCredito_Creditoupdatedat ;
         gxTv_SdtCredito_Creditocreatedby = sdt.gxTv_SdtCredito_Creditocreatedby ;
         gxTv_SdtCredito_Creditoupdatedby = sdt.gxTv_SdtCredito_Creditoupdatedby ;
         gxTv_SdtCredito_Mode = sdt.gxTv_SdtCredito_Mode ;
         gxTv_SdtCredito_Initialized = sdt.gxTv_SdtCredito_Initialized ;
         gxTv_SdtCredito_Creditoid_Z = sdt.gxTv_SdtCredito_Creditoid_Z ;
         gxTv_SdtCredito_Clienteid_Z = sdt.gxTv_SdtCredito_Clienteid_Z ;
         gxTv_SdtCredito_Creditovalor_Z = sdt.gxTv_SdtCredito_Creditovalor_Z ;
         gxTv_SdtCredito_Creditovigencia_Z = sdt.gxTv_SdtCredito_Creditovigencia_Z ;
         gxTv_SdtCredito_Creditocreatedat_Z = sdt.gxTv_SdtCredito_Creditocreatedat_Z ;
         gxTv_SdtCredito_Creditoupdatedat_Z = sdt.gxTv_SdtCredito_Creditoupdatedat_Z ;
         gxTv_SdtCredito_Creditocreatedby_Z = sdt.gxTv_SdtCredito_Creditocreatedby_Z ;
         gxTv_SdtCredito_Creditoupdatedby_Z = sdt.gxTv_SdtCredito_Creditoupdatedby_Z ;
         gxTv_SdtCredito_Clienteid_N = sdt.gxTv_SdtCredito_Clienteid_N ;
         gxTv_SdtCredito_Creditovalor_N = sdt.gxTv_SdtCredito_Creditovalor_N ;
         gxTv_SdtCredito_Creditovigencia_N = sdt.gxTv_SdtCredito_Creditovigencia_N ;
         gxTv_SdtCredito_Creditocreatedat_N = sdt.gxTv_SdtCredito_Creditocreatedat_N ;
         gxTv_SdtCredito_Creditoupdatedat_N = sdt.gxTv_SdtCredito_Creditoupdatedat_N ;
         gxTv_SdtCredito_Creditocreatedby_N = sdt.gxTv_SdtCredito_Creditocreatedby_N ;
         gxTv_SdtCredito_Creditoupdatedby_N = sdt.gxTv_SdtCredito_Creditoupdatedby_N ;
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
         AddObjectProperty("CreditoId", gxTv_SdtCredito_Creditoid, false, includeNonInitialized);
         AddObjectProperty("ClienteId", gxTv_SdtCredito_Clienteid, false, includeNonInitialized);
         AddObjectProperty("ClienteId_N", gxTv_SdtCredito_Clienteid_N, false, includeNonInitialized);
         AddObjectProperty("CreditoValor", StringUtil.LTrim( StringUtil.Str( gxTv_SdtCredito_Creditovalor, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("CreditoValor_N", gxTv_SdtCredito_Creditovalor_N, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtCredito_Creditovigencia)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtCredito_Creditovigencia)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtCredito_Creditovigencia)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("CreditoVigencia", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("CreditoVigencia_N", gxTv_SdtCredito_Creditovigencia_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtCredito_Creditocreatedat;
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
         AddObjectProperty("CreditoCreatedAt", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("CreditoCreatedAt_N", gxTv_SdtCredito_Creditocreatedat_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtCredito_Creditoupdatedat;
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
         AddObjectProperty("CreditoUpdatedAt", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("CreditoUpdatedAt_N", gxTv_SdtCredito_Creditoupdatedat_N, false, includeNonInitialized);
         AddObjectProperty("CreditoCreatedBy", gxTv_SdtCredito_Creditocreatedby, false, includeNonInitialized);
         AddObjectProperty("CreditoCreatedBy_N", gxTv_SdtCredito_Creditocreatedby_N, false, includeNonInitialized);
         AddObjectProperty("CreditoUpdatedBy", gxTv_SdtCredito_Creditoupdatedby, false, includeNonInitialized);
         AddObjectProperty("CreditoUpdatedBy_N", gxTv_SdtCredito_Creditoupdatedby_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtCredito_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtCredito_Initialized, false, includeNonInitialized);
            AddObjectProperty("CreditoId_Z", gxTv_SdtCredito_Creditoid_Z, false, includeNonInitialized);
            AddObjectProperty("ClienteId_Z", gxTv_SdtCredito_Clienteid_Z, false, includeNonInitialized);
            AddObjectProperty("CreditoValor_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtCredito_Creditovalor_Z, 18, 2)), false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtCredito_Creditovigencia_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtCredito_Creditovigencia_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtCredito_Creditovigencia_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("CreditoVigencia_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtCredito_Creditocreatedat_Z;
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
            AddObjectProperty("CreditoCreatedAt_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtCredito_Creditoupdatedat_Z;
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
            AddObjectProperty("CreditoUpdatedAt_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("CreditoCreatedBy_Z", gxTv_SdtCredito_Creditocreatedby_Z, false, includeNonInitialized);
            AddObjectProperty("CreditoUpdatedBy_Z", gxTv_SdtCredito_Creditoupdatedby_Z, false, includeNonInitialized);
            AddObjectProperty("ClienteId_N", gxTv_SdtCredito_Clienteid_N, false, includeNonInitialized);
            AddObjectProperty("CreditoValor_N", gxTv_SdtCredito_Creditovalor_N, false, includeNonInitialized);
            AddObjectProperty("CreditoVigencia_N", gxTv_SdtCredito_Creditovigencia_N, false, includeNonInitialized);
            AddObjectProperty("CreditoCreatedAt_N", gxTv_SdtCredito_Creditocreatedat_N, false, includeNonInitialized);
            AddObjectProperty("CreditoUpdatedAt_N", gxTv_SdtCredito_Creditoupdatedat_N, false, includeNonInitialized);
            AddObjectProperty("CreditoCreatedBy_N", gxTv_SdtCredito_Creditocreatedby_N, false, includeNonInitialized);
            AddObjectProperty("CreditoUpdatedBy_N", gxTv_SdtCredito_Creditoupdatedby_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtCredito sdt )
      {
         if ( sdt.IsDirty("CreditoId") )
         {
            sdtIsNull = 0;
            gxTv_SdtCredito_Creditoid = sdt.gxTv_SdtCredito_Creditoid ;
         }
         if ( sdt.IsDirty("ClienteId") )
         {
            gxTv_SdtCredito_Clienteid_N = (short)(sdt.gxTv_SdtCredito_Clienteid_N);
            sdtIsNull = 0;
            gxTv_SdtCredito_Clienteid = sdt.gxTv_SdtCredito_Clienteid ;
         }
         if ( sdt.IsDirty("CreditoValor") )
         {
            gxTv_SdtCredito_Creditovalor_N = (short)(sdt.gxTv_SdtCredito_Creditovalor_N);
            sdtIsNull = 0;
            gxTv_SdtCredito_Creditovalor = sdt.gxTv_SdtCredito_Creditovalor ;
         }
         if ( sdt.IsDirty("CreditoVigencia") )
         {
            gxTv_SdtCredito_Creditovigencia_N = (short)(sdt.gxTv_SdtCredito_Creditovigencia_N);
            sdtIsNull = 0;
            gxTv_SdtCredito_Creditovigencia = sdt.gxTv_SdtCredito_Creditovigencia ;
         }
         if ( sdt.IsDirty("CreditoCreatedAt") )
         {
            gxTv_SdtCredito_Creditocreatedat_N = (short)(sdt.gxTv_SdtCredito_Creditocreatedat_N);
            sdtIsNull = 0;
            gxTv_SdtCredito_Creditocreatedat = sdt.gxTv_SdtCredito_Creditocreatedat ;
         }
         if ( sdt.IsDirty("CreditoUpdatedAt") )
         {
            gxTv_SdtCredito_Creditoupdatedat_N = (short)(sdt.gxTv_SdtCredito_Creditoupdatedat_N);
            sdtIsNull = 0;
            gxTv_SdtCredito_Creditoupdatedat = sdt.gxTv_SdtCredito_Creditoupdatedat ;
         }
         if ( sdt.IsDirty("CreditoCreatedBy") )
         {
            gxTv_SdtCredito_Creditocreatedby_N = (short)(sdt.gxTv_SdtCredito_Creditocreatedby_N);
            sdtIsNull = 0;
            gxTv_SdtCredito_Creditocreatedby = sdt.gxTv_SdtCredito_Creditocreatedby ;
         }
         if ( sdt.IsDirty("CreditoUpdatedBy") )
         {
            gxTv_SdtCredito_Creditoupdatedby_N = (short)(sdt.gxTv_SdtCredito_Creditoupdatedby_N);
            sdtIsNull = 0;
            gxTv_SdtCredito_Creditoupdatedby = sdt.gxTv_SdtCredito_Creditoupdatedby ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "CreditoId" )]
      [  XmlElement( ElementName = "CreditoId"   )]
      public int gxTpr_Creditoid
      {
         get {
            return gxTv_SdtCredito_Creditoid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtCredito_Creditoid != value )
            {
               gxTv_SdtCredito_Mode = "INS";
               this.gxTv_SdtCredito_Creditoid_Z_SetNull( );
               this.gxTv_SdtCredito_Clienteid_Z_SetNull( );
               this.gxTv_SdtCredito_Creditovalor_Z_SetNull( );
               this.gxTv_SdtCredito_Creditovigencia_Z_SetNull( );
               this.gxTv_SdtCredito_Creditocreatedat_Z_SetNull( );
               this.gxTv_SdtCredito_Creditoupdatedat_Z_SetNull( );
               this.gxTv_SdtCredito_Creditocreatedby_Z_SetNull( );
               this.gxTv_SdtCredito_Creditoupdatedby_Z_SetNull( );
            }
            gxTv_SdtCredito_Creditoid = value;
            SetDirty("Creditoid");
         }

      }

      [  SoapElement( ElementName = "ClienteId" )]
      [  XmlElement( ElementName = "ClienteId"   )]
      public int gxTpr_Clienteid
      {
         get {
            return gxTv_SdtCredito_Clienteid ;
         }

         set {
            gxTv_SdtCredito_Clienteid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCredito_Clienteid = value;
            SetDirty("Clienteid");
         }

      }

      public void gxTv_SdtCredito_Clienteid_SetNull( )
      {
         gxTv_SdtCredito_Clienteid_N = 1;
         gxTv_SdtCredito_Clienteid = 0;
         SetDirty("Clienteid");
         return  ;
      }

      public bool gxTv_SdtCredito_Clienteid_IsNull( )
      {
         return (gxTv_SdtCredito_Clienteid_N==1) ;
      }

      [  SoapElement( ElementName = "CreditoValor" )]
      [  XmlElement( ElementName = "CreditoValor"   )]
      public decimal gxTpr_Creditovalor
      {
         get {
            return gxTv_SdtCredito_Creditovalor ;
         }

         set {
            gxTv_SdtCredito_Creditovalor_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCredito_Creditovalor = value;
            SetDirty("Creditovalor");
         }

      }

      public void gxTv_SdtCredito_Creditovalor_SetNull( )
      {
         gxTv_SdtCredito_Creditovalor_N = 1;
         gxTv_SdtCredito_Creditovalor = 0;
         SetDirty("Creditovalor");
         return  ;
      }

      public bool gxTv_SdtCredito_Creditovalor_IsNull( )
      {
         return (gxTv_SdtCredito_Creditovalor_N==1) ;
      }

      [  SoapElement( ElementName = "CreditoVigencia" )]
      [  XmlElement( ElementName = "CreditoVigencia"  , IsNullable=true )]
      public string gxTpr_Creditovigencia_Nullable
      {
         get {
            if ( gxTv_SdtCredito_Creditovigencia == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtCredito_Creditovigencia).value ;
         }

         set {
            gxTv_SdtCredito_Creditovigencia_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtCredito_Creditovigencia = DateTime.MinValue;
            else
               gxTv_SdtCredito_Creditovigencia = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Creditovigencia
      {
         get {
            return gxTv_SdtCredito_Creditovigencia ;
         }

         set {
            gxTv_SdtCredito_Creditovigencia_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCredito_Creditovigencia = value;
            SetDirty("Creditovigencia");
         }

      }

      public void gxTv_SdtCredito_Creditovigencia_SetNull( )
      {
         gxTv_SdtCredito_Creditovigencia_N = 1;
         gxTv_SdtCredito_Creditovigencia = (DateTime)(DateTime.MinValue);
         SetDirty("Creditovigencia");
         return  ;
      }

      public bool gxTv_SdtCredito_Creditovigencia_IsNull( )
      {
         return (gxTv_SdtCredito_Creditovigencia_N==1) ;
      }

      [  SoapElement( ElementName = "CreditoCreatedAt" )]
      [  XmlElement( ElementName = "CreditoCreatedAt"  , IsNullable=true )]
      public string gxTpr_Creditocreatedat_Nullable
      {
         get {
            if ( gxTv_SdtCredito_Creditocreatedat == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtCredito_Creditocreatedat).value ;
         }

         set {
            gxTv_SdtCredito_Creditocreatedat_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtCredito_Creditocreatedat = DateTime.MinValue;
            else
               gxTv_SdtCredito_Creditocreatedat = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Creditocreatedat
      {
         get {
            return gxTv_SdtCredito_Creditocreatedat ;
         }

         set {
            gxTv_SdtCredito_Creditocreatedat_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCredito_Creditocreatedat = value;
            SetDirty("Creditocreatedat");
         }

      }

      public void gxTv_SdtCredito_Creditocreatedat_SetNull( )
      {
         gxTv_SdtCredito_Creditocreatedat_N = 1;
         gxTv_SdtCredito_Creditocreatedat = (DateTime)(DateTime.MinValue);
         SetDirty("Creditocreatedat");
         return  ;
      }

      public bool gxTv_SdtCredito_Creditocreatedat_IsNull( )
      {
         return (gxTv_SdtCredito_Creditocreatedat_N==1) ;
      }

      [  SoapElement( ElementName = "CreditoUpdatedAt" )]
      [  XmlElement( ElementName = "CreditoUpdatedAt"  , IsNullable=true )]
      public string gxTpr_Creditoupdatedat_Nullable
      {
         get {
            if ( gxTv_SdtCredito_Creditoupdatedat == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtCredito_Creditoupdatedat).value ;
         }

         set {
            gxTv_SdtCredito_Creditoupdatedat_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtCredito_Creditoupdatedat = DateTime.MinValue;
            else
               gxTv_SdtCredito_Creditoupdatedat = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Creditoupdatedat
      {
         get {
            return gxTv_SdtCredito_Creditoupdatedat ;
         }

         set {
            gxTv_SdtCredito_Creditoupdatedat_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCredito_Creditoupdatedat = value;
            SetDirty("Creditoupdatedat");
         }

      }

      public void gxTv_SdtCredito_Creditoupdatedat_SetNull( )
      {
         gxTv_SdtCredito_Creditoupdatedat_N = 1;
         gxTv_SdtCredito_Creditoupdatedat = (DateTime)(DateTime.MinValue);
         SetDirty("Creditoupdatedat");
         return  ;
      }

      public bool gxTv_SdtCredito_Creditoupdatedat_IsNull( )
      {
         return (gxTv_SdtCredito_Creditoupdatedat_N==1) ;
      }

      [  SoapElement( ElementName = "CreditoCreatedBy" )]
      [  XmlElement( ElementName = "CreditoCreatedBy"   )]
      public short gxTpr_Creditocreatedby
      {
         get {
            return gxTv_SdtCredito_Creditocreatedby ;
         }

         set {
            gxTv_SdtCredito_Creditocreatedby_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCredito_Creditocreatedby = value;
            SetDirty("Creditocreatedby");
         }

      }

      public void gxTv_SdtCredito_Creditocreatedby_SetNull( )
      {
         gxTv_SdtCredito_Creditocreatedby_N = 1;
         gxTv_SdtCredito_Creditocreatedby = 0;
         SetDirty("Creditocreatedby");
         return  ;
      }

      public bool gxTv_SdtCredito_Creditocreatedby_IsNull( )
      {
         return (gxTv_SdtCredito_Creditocreatedby_N==1) ;
      }

      [  SoapElement( ElementName = "CreditoUpdatedBy" )]
      [  XmlElement( ElementName = "CreditoUpdatedBy"   )]
      public short gxTpr_Creditoupdatedby
      {
         get {
            return gxTv_SdtCredito_Creditoupdatedby ;
         }

         set {
            gxTv_SdtCredito_Creditoupdatedby_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCredito_Creditoupdatedby = value;
            SetDirty("Creditoupdatedby");
         }

      }

      public void gxTv_SdtCredito_Creditoupdatedby_SetNull( )
      {
         gxTv_SdtCredito_Creditoupdatedby_N = 1;
         gxTv_SdtCredito_Creditoupdatedby = 0;
         SetDirty("Creditoupdatedby");
         return  ;
      }

      public bool gxTv_SdtCredito_Creditoupdatedby_IsNull( )
      {
         return (gxTv_SdtCredito_Creditoupdatedby_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtCredito_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCredito_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtCredito_Mode_SetNull( )
      {
         gxTv_SdtCredito_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtCredito_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtCredito_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCredito_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtCredito_Initialized_SetNull( )
      {
         gxTv_SdtCredito_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtCredito_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CreditoId_Z" )]
      [  XmlElement( ElementName = "CreditoId_Z"   )]
      public int gxTpr_Creditoid_Z
      {
         get {
            return gxTv_SdtCredito_Creditoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCredito_Creditoid_Z = value;
            SetDirty("Creditoid_Z");
         }

      }

      public void gxTv_SdtCredito_Creditoid_Z_SetNull( )
      {
         gxTv_SdtCredito_Creditoid_Z = 0;
         SetDirty("Creditoid_Z");
         return  ;
      }

      public bool gxTv_SdtCredito_Creditoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteId_Z" )]
      [  XmlElement( ElementName = "ClienteId_Z"   )]
      public int gxTpr_Clienteid_Z
      {
         get {
            return gxTv_SdtCredito_Clienteid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCredito_Clienteid_Z = value;
            SetDirty("Clienteid_Z");
         }

      }

      public void gxTv_SdtCredito_Clienteid_Z_SetNull( )
      {
         gxTv_SdtCredito_Clienteid_Z = 0;
         SetDirty("Clienteid_Z");
         return  ;
      }

      public bool gxTv_SdtCredito_Clienteid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CreditoValor_Z" )]
      [  XmlElement( ElementName = "CreditoValor_Z"   )]
      public decimal gxTpr_Creditovalor_Z
      {
         get {
            return gxTv_SdtCredito_Creditovalor_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCredito_Creditovalor_Z = value;
            SetDirty("Creditovalor_Z");
         }

      }

      public void gxTv_SdtCredito_Creditovalor_Z_SetNull( )
      {
         gxTv_SdtCredito_Creditovalor_Z = 0;
         SetDirty("Creditovalor_Z");
         return  ;
      }

      public bool gxTv_SdtCredito_Creditovalor_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CreditoVigencia_Z" )]
      [  XmlElement( ElementName = "CreditoVigencia_Z"  , IsNullable=true )]
      public string gxTpr_Creditovigencia_Z_Nullable
      {
         get {
            if ( gxTv_SdtCredito_Creditovigencia_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtCredito_Creditovigencia_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtCredito_Creditovigencia_Z = DateTime.MinValue;
            else
               gxTv_SdtCredito_Creditovigencia_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Creditovigencia_Z
      {
         get {
            return gxTv_SdtCredito_Creditovigencia_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCredito_Creditovigencia_Z = value;
            SetDirty("Creditovigencia_Z");
         }

      }

      public void gxTv_SdtCredito_Creditovigencia_Z_SetNull( )
      {
         gxTv_SdtCredito_Creditovigencia_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Creditovigencia_Z");
         return  ;
      }

      public bool gxTv_SdtCredito_Creditovigencia_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CreditoCreatedAt_Z" )]
      [  XmlElement( ElementName = "CreditoCreatedAt_Z"  , IsNullable=true )]
      public string gxTpr_Creditocreatedat_Z_Nullable
      {
         get {
            if ( gxTv_SdtCredito_Creditocreatedat_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtCredito_Creditocreatedat_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtCredito_Creditocreatedat_Z = DateTime.MinValue;
            else
               gxTv_SdtCredito_Creditocreatedat_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Creditocreatedat_Z
      {
         get {
            return gxTv_SdtCredito_Creditocreatedat_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCredito_Creditocreatedat_Z = value;
            SetDirty("Creditocreatedat_Z");
         }

      }

      public void gxTv_SdtCredito_Creditocreatedat_Z_SetNull( )
      {
         gxTv_SdtCredito_Creditocreatedat_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Creditocreatedat_Z");
         return  ;
      }

      public bool gxTv_SdtCredito_Creditocreatedat_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CreditoUpdatedAt_Z" )]
      [  XmlElement( ElementName = "CreditoUpdatedAt_Z"  , IsNullable=true )]
      public string gxTpr_Creditoupdatedat_Z_Nullable
      {
         get {
            if ( gxTv_SdtCredito_Creditoupdatedat_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtCredito_Creditoupdatedat_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtCredito_Creditoupdatedat_Z = DateTime.MinValue;
            else
               gxTv_SdtCredito_Creditoupdatedat_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Creditoupdatedat_Z
      {
         get {
            return gxTv_SdtCredito_Creditoupdatedat_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCredito_Creditoupdatedat_Z = value;
            SetDirty("Creditoupdatedat_Z");
         }

      }

      public void gxTv_SdtCredito_Creditoupdatedat_Z_SetNull( )
      {
         gxTv_SdtCredito_Creditoupdatedat_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Creditoupdatedat_Z");
         return  ;
      }

      public bool gxTv_SdtCredito_Creditoupdatedat_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CreditoCreatedBy_Z" )]
      [  XmlElement( ElementName = "CreditoCreatedBy_Z"   )]
      public short gxTpr_Creditocreatedby_Z
      {
         get {
            return gxTv_SdtCredito_Creditocreatedby_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCredito_Creditocreatedby_Z = value;
            SetDirty("Creditocreatedby_Z");
         }

      }

      public void gxTv_SdtCredito_Creditocreatedby_Z_SetNull( )
      {
         gxTv_SdtCredito_Creditocreatedby_Z = 0;
         SetDirty("Creditocreatedby_Z");
         return  ;
      }

      public bool gxTv_SdtCredito_Creditocreatedby_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CreditoUpdatedBy_Z" )]
      [  XmlElement( ElementName = "CreditoUpdatedBy_Z"   )]
      public short gxTpr_Creditoupdatedby_Z
      {
         get {
            return gxTv_SdtCredito_Creditoupdatedby_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCredito_Creditoupdatedby_Z = value;
            SetDirty("Creditoupdatedby_Z");
         }

      }

      public void gxTv_SdtCredito_Creditoupdatedby_Z_SetNull( )
      {
         gxTv_SdtCredito_Creditoupdatedby_Z = 0;
         SetDirty("Creditoupdatedby_Z");
         return  ;
      }

      public bool gxTv_SdtCredito_Creditoupdatedby_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteId_N" )]
      [  XmlElement( ElementName = "ClienteId_N"   )]
      public short gxTpr_Clienteid_N
      {
         get {
            return gxTv_SdtCredito_Clienteid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCredito_Clienteid_N = value;
            SetDirty("Clienteid_N");
         }

      }

      public void gxTv_SdtCredito_Clienteid_N_SetNull( )
      {
         gxTv_SdtCredito_Clienteid_N = 0;
         SetDirty("Clienteid_N");
         return  ;
      }

      public bool gxTv_SdtCredito_Clienteid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CreditoValor_N" )]
      [  XmlElement( ElementName = "CreditoValor_N"   )]
      public short gxTpr_Creditovalor_N
      {
         get {
            return gxTv_SdtCredito_Creditovalor_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCredito_Creditovalor_N = value;
            SetDirty("Creditovalor_N");
         }

      }

      public void gxTv_SdtCredito_Creditovalor_N_SetNull( )
      {
         gxTv_SdtCredito_Creditovalor_N = 0;
         SetDirty("Creditovalor_N");
         return  ;
      }

      public bool gxTv_SdtCredito_Creditovalor_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CreditoVigencia_N" )]
      [  XmlElement( ElementName = "CreditoVigencia_N"   )]
      public short gxTpr_Creditovigencia_N
      {
         get {
            return gxTv_SdtCredito_Creditovigencia_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCredito_Creditovigencia_N = value;
            SetDirty("Creditovigencia_N");
         }

      }

      public void gxTv_SdtCredito_Creditovigencia_N_SetNull( )
      {
         gxTv_SdtCredito_Creditovigencia_N = 0;
         SetDirty("Creditovigencia_N");
         return  ;
      }

      public bool gxTv_SdtCredito_Creditovigencia_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CreditoCreatedAt_N" )]
      [  XmlElement( ElementName = "CreditoCreatedAt_N"   )]
      public short gxTpr_Creditocreatedat_N
      {
         get {
            return gxTv_SdtCredito_Creditocreatedat_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCredito_Creditocreatedat_N = value;
            SetDirty("Creditocreatedat_N");
         }

      }

      public void gxTv_SdtCredito_Creditocreatedat_N_SetNull( )
      {
         gxTv_SdtCredito_Creditocreatedat_N = 0;
         SetDirty("Creditocreatedat_N");
         return  ;
      }

      public bool gxTv_SdtCredito_Creditocreatedat_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CreditoUpdatedAt_N" )]
      [  XmlElement( ElementName = "CreditoUpdatedAt_N"   )]
      public short gxTpr_Creditoupdatedat_N
      {
         get {
            return gxTv_SdtCredito_Creditoupdatedat_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCredito_Creditoupdatedat_N = value;
            SetDirty("Creditoupdatedat_N");
         }

      }

      public void gxTv_SdtCredito_Creditoupdatedat_N_SetNull( )
      {
         gxTv_SdtCredito_Creditoupdatedat_N = 0;
         SetDirty("Creditoupdatedat_N");
         return  ;
      }

      public bool gxTv_SdtCredito_Creditoupdatedat_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CreditoCreatedBy_N" )]
      [  XmlElement( ElementName = "CreditoCreatedBy_N"   )]
      public short gxTpr_Creditocreatedby_N
      {
         get {
            return gxTv_SdtCredito_Creditocreatedby_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCredito_Creditocreatedby_N = value;
            SetDirty("Creditocreatedby_N");
         }

      }

      public void gxTv_SdtCredito_Creditocreatedby_N_SetNull( )
      {
         gxTv_SdtCredito_Creditocreatedby_N = 0;
         SetDirty("Creditocreatedby_N");
         return  ;
      }

      public bool gxTv_SdtCredito_Creditocreatedby_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CreditoUpdatedBy_N" )]
      [  XmlElement( ElementName = "CreditoUpdatedBy_N"   )]
      public short gxTpr_Creditoupdatedby_N
      {
         get {
            return gxTv_SdtCredito_Creditoupdatedby_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCredito_Creditoupdatedby_N = value;
            SetDirty("Creditoupdatedby_N");
         }

      }

      public void gxTv_SdtCredito_Creditoupdatedby_N_SetNull( )
      {
         gxTv_SdtCredito_Creditoupdatedby_N = 0;
         SetDirty("Creditoupdatedby_N");
         return  ;
      }

      public bool gxTv_SdtCredito_Creditoupdatedby_N_IsNull( )
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
         gxTv_SdtCredito_Creditovigencia = DateTime.MinValue;
         gxTv_SdtCredito_Creditocreatedat = (DateTime)(DateTime.MinValue);
         gxTv_SdtCredito_Creditoupdatedat = (DateTime)(DateTime.MinValue);
         gxTv_SdtCredito_Mode = "";
         gxTv_SdtCredito_Creditovigencia_Z = DateTime.MinValue;
         gxTv_SdtCredito_Creditocreatedat_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtCredito_Creditoupdatedat_Z = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "credito", "GeneXus.Programs.credito_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtCredito_Creditocreatedby ;
      private short gxTv_SdtCredito_Creditoupdatedby ;
      private short gxTv_SdtCredito_Initialized ;
      private short gxTv_SdtCredito_Creditocreatedby_Z ;
      private short gxTv_SdtCredito_Creditoupdatedby_Z ;
      private short gxTv_SdtCredito_Clienteid_N ;
      private short gxTv_SdtCredito_Creditovalor_N ;
      private short gxTv_SdtCredito_Creditovigencia_N ;
      private short gxTv_SdtCredito_Creditocreatedat_N ;
      private short gxTv_SdtCredito_Creditoupdatedat_N ;
      private short gxTv_SdtCredito_Creditocreatedby_N ;
      private short gxTv_SdtCredito_Creditoupdatedby_N ;
      private int gxTv_SdtCredito_Creditoid ;
      private int gxTv_SdtCredito_Clienteid ;
      private int gxTv_SdtCredito_Creditoid_Z ;
      private int gxTv_SdtCredito_Clienteid_Z ;
      private decimal gxTv_SdtCredito_Creditovalor ;
      private decimal gxTv_SdtCredito_Creditovalor_Z ;
      private string gxTv_SdtCredito_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtCredito_Creditocreatedat ;
      private DateTime gxTv_SdtCredito_Creditoupdatedat ;
      private DateTime gxTv_SdtCredito_Creditocreatedat_Z ;
      private DateTime gxTv_SdtCredito_Creditoupdatedat_Z ;
      private DateTime datetime_STZ ;
      private DateTime gxTv_SdtCredito_Creditovigencia ;
      private DateTime gxTv_SdtCredito_Creditovigencia_Z ;
   }

   [DataContract(Name = @"Credito", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtCredito_RESTInterface : GxGenericCollectionItem<SdtCredito>
   {
      public SdtCredito_RESTInterface( ) : base()
      {
      }

      public SdtCredito_RESTInterface( SdtCredito psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "CreditoId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Creditoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Creditoid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Creditoid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ClienteId" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Clienteid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Clienteid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Clienteid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "CreditoValor" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Creditovalor
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Creditovalor, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Creditovalor = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "CreditoVigencia" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Creditovigencia
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Creditovigencia) ;
         }

         set {
            sdt.gxTpr_Creditovigencia = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "CreditoCreatedAt" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Creditocreatedat
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Creditocreatedat, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Creditocreatedat = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "CreditoUpdatedAt" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Creditoupdatedat
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Creditoupdatedat, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Creditoupdatedat = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "CreditoCreatedBy" , Order = 6 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Creditocreatedby
      {
         get {
            return sdt.gxTpr_Creditocreatedby ;
         }

         set {
            sdt.gxTpr_Creditocreatedby = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "CreditoUpdatedBy" , Order = 7 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Creditoupdatedby
      {
         get {
            return sdt.gxTpr_Creditoupdatedby ;
         }

         set {
            sdt.gxTpr_Creditoupdatedby = (short)(value.HasValue ? value.Value : 0);
         }

      }

      public SdtCredito sdt
      {
         get {
            return (SdtCredito)Sdt ;
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
            sdt = new SdtCredito() ;
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

   [DataContract(Name = @"Credito", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtCredito_RESTLInterface : GxGenericCollectionItem<SdtCredito>
   {
      public SdtCredito_RESTLInterface( ) : base()
      {
      }

      public SdtCredito_RESTLInterface( SdtCredito psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "CreditoValor" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Creditovalor
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Creditovalor, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Creditovalor = NumberUtil.Val( value, ".");
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

      public SdtCredito sdt
      {
         get {
            return (SdtCredito)Sdt ;
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
            sdt = new SdtCredito() ;
         }
      }

   }

}
