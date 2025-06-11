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
   [XmlRoot(ElementName = "PropostaNota" )]
   [XmlType(TypeName =  "PropostaNota" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtPropostaNota : GxSilentTrnSdt
   {
      public SdtPropostaNota( )
      {
      }

      public SdtPropostaNota( IGxContext context )
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

      public void Load( int AV323PropostaId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV323PropostaId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"PropostaId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "PropostaNota");
         metadata.Set("BT", "Proposta");
         metadata.Set("PK", "[ \"PropostaId\" ]");
         metadata.Set("PKAssigned", "[ \"PropostaId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"ClienteId\" ],\"FKMap\":[ \"PropostaEmpresaClienteId-ClienteId\" ] },{ \"FK\":[ \"ContratoId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Propostaid_Z");
         state.Add("gxTpr_Propostaqtditensnota_f_Z");
         state.Add("gxTpr_Propostaprotocolo_Z");
         state.Add("gxTpr_Propostatipoproposta_Z");
         state.Add("gxTpr_Propostasumitensnota_f_Z");
         state.Add("gxTpr_Propostaempresaclienteid_Z");
         state.Add("gxTpr_Propostaempresarazao_Z");
         state.Add("gxTpr_Propostacreatedat_Z_Nullable");
         state.Add("gxTpr_Propostastatus_Z");
         state.Add("gxTpr_Propostaid_N");
         state.Add("gxTpr_Propostaprotocolo_N");
         state.Add("gxTpr_Propostatipoproposta_N");
         state.Add("gxTpr_Propostaempresaclienteid_N");
         state.Add("gxTpr_Propostaempresarazao_N");
         state.Add("gxTpr_Propostacreatedat_N");
         state.Add("gxTpr_Propostastatus_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtPropostaNota sdt;
         sdt = (SdtPropostaNota)(source);
         gxTv_SdtPropostaNota_Propostaid = sdt.gxTv_SdtPropostaNota_Propostaid ;
         gxTv_SdtPropostaNota_Propostaqtditensnota_f = sdt.gxTv_SdtPropostaNota_Propostaqtditensnota_f ;
         gxTv_SdtPropostaNota_Propostaprotocolo = sdt.gxTv_SdtPropostaNota_Propostaprotocolo ;
         gxTv_SdtPropostaNota_Propostatipoproposta = sdt.gxTv_SdtPropostaNota_Propostatipoproposta ;
         gxTv_SdtPropostaNota_Propostasumitensnota_f = sdt.gxTv_SdtPropostaNota_Propostasumitensnota_f ;
         gxTv_SdtPropostaNota_Propostaempresaclienteid = sdt.gxTv_SdtPropostaNota_Propostaempresaclienteid ;
         gxTv_SdtPropostaNota_Propostaempresarazao = sdt.gxTv_SdtPropostaNota_Propostaempresarazao ;
         gxTv_SdtPropostaNota_Propostacreatedat = sdt.gxTv_SdtPropostaNota_Propostacreatedat ;
         gxTv_SdtPropostaNota_Propostastatus = sdt.gxTv_SdtPropostaNota_Propostastatus ;
         gxTv_SdtPropostaNota_Mode = sdt.gxTv_SdtPropostaNota_Mode ;
         gxTv_SdtPropostaNota_Initialized = sdt.gxTv_SdtPropostaNota_Initialized ;
         gxTv_SdtPropostaNota_Propostaid_Z = sdt.gxTv_SdtPropostaNota_Propostaid_Z ;
         gxTv_SdtPropostaNota_Propostaqtditensnota_f_Z = sdt.gxTv_SdtPropostaNota_Propostaqtditensnota_f_Z ;
         gxTv_SdtPropostaNota_Propostaprotocolo_Z = sdt.gxTv_SdtPropostaNota_Propostaprotocolo_Z ;
         gxTv_SdtPropostaNota_Propostatipoproposta_Z = sdt.gxTv_SdtPropostaNota_Propostatipoproposta_Z ;
         gxTv_SdtPropostaNota_Propostasumitensnota_f_Z = sdt.gxTv_SdtPropostaNota_Propostasumitensnota_f_Z ;
         gxTv_SdtPropostaNota_Propostaempresaclienteid_Z = sdt.gxTv_SdtPropostaNota_Propostaempresaclienteid_Z ;
         gxTv_SdtPropostaNota_Propostaempresarazao_Z = sdt.gxTv_SdtPropostaNota_Propostaempresarazao_Z ;
         gxTv_SdtPropostaNota_Propostacreatedat_Z = sdt.gxTv_SdtPropostaNota_Propostacreatedat_Z ;
         gxTv_SdtPropostaNota_Propostastatus_Z = sdt.gxTv_SdtPropostaNota_Propostastatus_Z ;
         gxTv_SdtPropostaNota_Propostaid_N = sdt.gxTv_SdtPropostaNota_Propostaid_N ;
         gxTv_SdtPropostaNota_Propostaprotocolo_N = sdt.gxTv_SdtPropostaNota_Propostaprotocolo_N ;
         gxTv_SdtPropostaNota_Propostatipoproposta_N = sdt.gxTv_SdtPropostaNota_Propostatipoproposta_N ;
         gxTv_SdtPropostaNota_Propostaempresaclienteid_N = sdt.gxTv_SdtPropostaNota_Propostaempresaclienteid_N ;
         gxTv_SdtPropostaNota_Propostaempresarazao_N = sdt.gxTv_SdtPropostaNota_Propostaempresarazao_N ;
         gxTv_SdtPropostaNota_Propostacreatedat_N = sdt.gxTv_SdtPropostaNota_Propostacreatedat_N ;
         gxTv_SdtPropostaNota_Propostastatus_N = sdt.gxTv_SdtPropostaNota_Propostastatus_N ;
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
         AddObjectProperty("PropostaId", gxTv_SdtPropostaNota_Propostaid, false, includeNonInitialized);
         AddObjectProperty("PropostaId_N", gxTv_SdtPropostaNota_Propostaid_N, false, includeNonInitialized);
         AddObjectProperty("PropostaQtdItensNota_F", gxTv_SdtPropostaNota_Propostaqtditensnota_f, false, includeNonInitialized);
         AddObjectProperty("PropostaProtocolo", gxTv_SdtPropostaNota_Propostaprotocolo, false, includeNonInitialized);
         AddObjectProperty("PropostaProtocolo_N", gxTv_SdtPropostaNota_Propostaprotocolo_N, false, includeNonInitialized);
         AddObjectProperty("PropostaTipoProposta", gxTv_SdtPropostaNota_Propostatipoproposta, false, includeNonInitialized);
         AddObjectProperty("PropostaTipoProposta_N", gxTv_SdtPropostaNota_Propostatipoproposta_N, false, includeNonInitialized);
         AddObjectProperty("PropostaSumItensnota_F", StringUtil.LTrim( StringUtil.Str( gxTv_SdtPropostaNota_Propostasumitensnota_f, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("PropostaEmpresaClienteId", gxTv_SdtPropostaNota_Propostaempresaclienteid, false, includeNonInitialized);
         AddObjectProperty("PropostaEmpresaClienteId_N", gxTv_SdtPropostaNota_Propostaempresaclienteid_N, false, includeNonInitialized);
         AddObjectProperty("PropostaEmpresaRazao", gxTv_SdtPropostaNota_Propostaempresarazao, false, includeNonInitialized);
         AddObjectProperty("PropostaEmpresaRazao_N", gxTv_SdtPropostaNota_Propostaempresarazao_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtPropostaNota_Propostacreatedat;
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
         AddObjectProperty("PropostaCreatedAt", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("PropostaCreatedAt_N", gxTv_SdtPropostaNota_Propostacreatedat_N, false, includeNonInitialized);
         AddObjectProperty("PropostaStatus", gxTv_SdtPropostaNota_Propostastatus, false, includeNonInitialized);
         AddObjectProperty("PropostaStatus_N", gxTv_SdtPropostaNota_Propostastatus_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtPropostaNota_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtPropostaNota_Initialized, false, includeNonInitialized);
            AddObjectProperty("PropostaId_Z", gxTv_SdtPropostaNota_Propostaid_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaQtdItensNota_F_Z", gxTv_SdtPropostaNota_Propostaqtditensnota_f_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaProtocolo_Z", gxTv_SdtPropostaNota_Propostaprotocolo_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaTipoProposta_Z", gxTv_SdtPropostaNota_Propostatipoproposta_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaSumItensnota_F_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtPropostaNota_Propostasumitensnota_f_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("PropostaEmpresaClienteId_Z", gxTv_SdtPropostaNota_Propostaempresaclienteid_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaEmpresaRazao_Z", gxTv_SdtPropostaNota_Propostaempresarazao_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtPropostaNota_Propostacreatedat_Z;
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
            AddObjectProperty("PropostaCreatedAt_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("PropostaStatus_Z", gxTv_SdtPropostaNota_Propostastatus_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaId_N", gxTv_SdtPropostaNota_Propostaid_N, false, includeNonInitialized);
            AddObjectProperty("PropostaProtocolo_N", gxTv_SdtPropostaNota_Propostaprotocolo_N, false, includeNonInitialized);
            AddObjectProperty("PropostaTipoProposta_N", gxTv_SdtPropostaNota_Propostatipoproposta_N, false, includeNonInitialized);
            AddObjectProperty("PropostaEmpresaClienteId_N", gxTv_SdtPropostaNota_Propostaempresaclienteid_N, false, includeNonInitialized);
            AddObjectProperty("PropostaEmpresaRazao_N", gxTv_SdtPropostaNota_Propostaempresarazao_N, false, includeNonInitialized);
            AddObjectProperty("PropostaCreatedAt_N", gxTv_SdtPropostaNota_Propostacreatedat_N, false, includeNonInitialized);
            AddObjectProperty("PropostaStatus_N", gxTv_SdtPropostaNota_Propostastatus_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtPropostaNota sdt )
      {
         if ( sdt.IsDirty("PropostaId") )
         {
            sdtIsNull = 0;
            gxTv_SdtPropostaNota_Propostaid = sdt.gxTv_SdtPropostaNota_Propostaid ;
         }
         if ( sdt.IsDirty("PropostaQtdItensNota_F") )
         {
            sdtIsNull = 0;
            gxTv_SdtPropostaNota_Propostaqtditensnota_f = sdt.gxTv_SdtPropostaNota_Propostaqtditensnota_f ;
         }
         if ( sdt.IsDirty("PropostaProtocolo") )
         {
            gxTv_SdtPropostaNota_Propostaprotocolo_N = (short)(sdt.gxTv_SdtPropostaNota_Propostaprotocolo_N);
            sdtIsNull = 0;
            gxTv_SdtPropostaNota_Propostaprotocolo = sdt.gxTv_SdtPropostaNota_Propostaprotocolo ;
         }
         if ( sdt.IsDirty("PropostaTipoProposta") )
         {
            gxTv_SdtPropostaNota_Propostatipoproposta_N = (short)(sdt.gxTv_SdtPropostaNota_Propostatipoproposta_N);
            sdtIsNull = 0;
            gxTv_SdtPropostaNota_Propostatipoproposta = sdt.gxTv_SdtPropostaNota_Propostatipoproposta ;
         }
         if ( sdt.IsDirty("PropostaSumItensnota_F") )
         {
            sdtIsNull = 0;
            gxTv_SdtPropostaNota_Propostasumitensnota_f = sdt.gxTv_SdtPropostaNota_Propostasumitensnota_f ;
         }
         if ( sdt.IsDirty("PropostaEmpresaClienteId") )
         {
            gxTv_SdtPropostaNota_Propostaempresaclienteid_N = (short)(sdt.gxTv_SdtPropostaNota_Propostaempresaclienteid_N);
            sdtIsNull = 0;
            gxTv_SdtPropostaNota_Propostaempresaclienteid = sdt.gxTv_SdtPropostaNota_Propostaempresaclienteid ;
         }
         if ( sdt.IsDirty("PropostaEmpresaRazao") )
         {
            gxTv_SdtPropostaNota_Propostaempresarazao_N = (short)(sdt.gxTv_SdtPropostaNota_Propostaempresarazao_N);
            sdtIsNull = 0;
            gxTv_SdtPropostaNota_Propostaempresarazao = sdt.gxTv_SdtPropostaNota_Propostaempresarazao ;
         }
         if ( sdt.IsDirty("PropostaCreatedAt") )
         {
            gxTv_SdtPropostaNota_Propostacreatedat_N = (short)(sdt.gxTv_SdtPropostaNota_Propostacreatedat_N);
            sdtIsNull = 0;
            gxTv_SdtPropostaNota_Propostacreatedat = sdt.gxTv_SdtPropostaNota_Propostacreatedat ;
         }
         if ( sdt.IsDirty("PropostaStatus") )
         {
            gxTv_SdtPropostaNota_Propostastatus_N = (short)(sdt.gxTv_SdtPropostaNota_Propostastatus_N);
            sdtIsNull = 0;
            gxTv_SdtPropostaNota_Propostastatus = sdt.gxTv_SdtPropostaNota_Propostastatus ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "PropostaId" )]
      [  XmlElement( ElementName = "PropostaId"   )]
      public int gxTpr_Propostaid
      {
         get {
            return gxTv_SdtPropostaNota_Propostaid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtPropostaNota_Propostaid != value )
            {
               gxTv_SdtPropostaNota_Mode = "INS";
               this.gxTv_SdtPropostaNota_Propostaid_Z_SetNull( );
               this.gxTv_SdtPropostaNota_Propostaqtditensnota_f_Z_SetNull( );
               this.gxTv_SdtPropostaNota_Propostaprotocolo_Z_SetNull( );
               this.gxTv_SdtPropostaNota_Propostatipoproposta_Z_SetNull( );
               this.gxTv_SdtPropostaNota_Propostasumitensnota_f_Z_SetNull( );
               this.gxTv_SdtPropostaNota_Propostaempresaclienteid_Z_SetNull( );
               this.gxTv_SdtPropostaNota_Propostaempresarazao_Z_SetNull( );
               this.gxTv_SdtPropostaNota_Propostacreatedat_Z_SetNull( );
               this.gxTv_SdtPropostaNota_Propostastatus_Z_SetNull( );
            }
            gxTv_SdtPropostaNota_Propostaid = value;
            SetDirty("Propostaid");
         }

      }

      [  SoapElement( ElementName = "PropostaQtdItensNota_F" )]
      [  XmlElement( ElementName = "PropostaQtdItensNota_F"   )]
      public short gxTpr_Propostaqtditensnota_f
      {
         get {
            return gxTv_SdtPropostaNota_Propostaqtditensnota_f ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaNota_Propostaqtditensnota_f = value;
            SetDirty("Propostaqtditensnota_f");
         }

      }

      public void gxTv_SdtPropostaNota_Propostaqtditensnota_f_SetNull( )
      {
         gxTv_SdtPropostaNota_Propostaqtditensnota_f = 0;
         SetDirty("Propostaqtditensnota_f");
         return  ;
      }

      public bool gxTv_SdtPropostaNota_Propostaqtditensnota_f_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaProtocolo" )]
      [  XmlElement( ElementName = "PropostaProtocolo"   )]
      public string gxTpr_Propostaprotocolo
      {
         get {
            return gxTv_SdtPropostaNota_Propostaprotocolo ;
         }

         set {
            gxTv_SdtPropostaNota_Propostaprotocolo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtPropostaNota_Propostaprotocolo = value;
            SetDirty("Propostaprotocolo");
         }

      }

      public void gxTv_SdtPropostaNota_Propostaprotocolo_SetNull( )
      {
         gxTv_SdtPropostaNota_Propostaprotocolo_N = 1;
         gxTv_SdtPropostaNota_Propostaprotocolo = "";
         SetDirty("Propostaprotocolo");
         return  ;
      }

      public bool gxTv_SdtPropostaNota_Propostaprotocolo_IsNull( )
      {
         return (gxTv_SdtPropostaNota_Propostaprotocolo_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaTipoProposta" )]
      [  XmlElement( ElementName = "PropostaTipoProposta"   )]
      public string gxTpr_Propostatipoproposta
      {
         get {
            return gxTv_SdtPropostaNota_Propostatipoproposta ;
         }

         set {
            gxTv_SdtPropostaNota_Propostatipoproposta_N = 0;
            sdtIsNull = 0;
            gxTv_SdtPropostaNota_Propostatipoproposta = value;
            SetDirty("Propostatipoproposta");
         }

      }

      public void gxTv_SdtPropostaNota_Propostatipoproposta_SetNull( )
      {
         gxTv_SdtPropostaNota_Propostatipoproposta_N = 1;
         gxTv_SdtPropostaNota_Propostatipoproposta = "";
         SetDirty("Propostatipoproposta");
         return  ;
      }

      public bool gxTv_SdtPropostaNota_Propostatipoproposta_IsNull( )
      {
         return (gxTv_SdtPropostaNota_Propostatipoproposta_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaSumItensnota_F" )]
      [  XmlElement( ElementName = "PropostaSumItensnota_F"   )]
      public decimal gxTpr_Propostasumitensnota_f
      {
         get {
            return gxTv_SdtPropostaNota_Propostasumitensnota_f ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaNota_Propostasumitensnota_f = value;
            SetDirty("Propostasumitensnota_f");
         }

      }

      public void gxTv_SdtPropostaNota_Propostasumitensnota_f_SetNull( )
      {
         gxTv_SdtPropostaNota_Propostasumitensnota_f = 0;
         SetDirty("Propostasumitensnota_f");
         return  ;
      }

      public bool gxTv_SdtPropostaNota_Propostasumitensnota_f_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaEmpresaClienteId" )]
      [  XmlElement( ElementName = "PropostaEmpresaClienteId"   )]
      public int gxTpr_Propostaempresaclienteid
      {
         get {
            return gxTv_SdtPropostaNota_Propostaempresaclienteid ;
         }

         set {
            gxTv_SdtPropostaNota_Propostaempresaclienteid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtPropostaNota_Propostaempresaclienteid = value;
            SetDirty("Propostaempresaclienteid");
         }

      }

      public void gxTv_SdtPropostaNota_Propostaempresaclienteid_SetNull( )
      {
         gxTv_SdtPropostaNota_Propostaempresaclienteid_N = 1;
         gxTv_SdtPropostaNota_Propostaempresaclienteid = 0;
         SetDirty("Propostaempresaclienteid");
         return  ;
      }

      public bool gxTv_SdtPropostaNota_Propostaempresaclienteid_IsNull( )
      {
         return (gxTv_SdtPropostaNota_Propostaempresaclienteid_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaEmpresaRazao" )]
      [  XmlElement( ElementName = "PropostaEmpresaRazao"   )]
      public string gxTpr_Propostaempresarazao
      {
         get {
            return gxTv_SdtPropostaNota_Propostaempresarazao ;
         }

         set {
            gxTv_SdtPropostaNota_Propostaempresarazao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtPropostaNota_Propostaempresarazao = value;
            SetDirty("Propostaempresarazao");
         }

      }

      public void gxTv_SdtPropostaNota_Propostaempresarazao_SetNull( )
      {
         gxTv_SdtPropostaNota_Propostaempresarazao_N = 1;
         gxTv_SdtPropostaNota_Propostaempresarazao = "";
         SetDirty("Propostaempresarazao");
         return  ;
      }

      public bool gxTv_SdtPropostaNota_Propostaempresarazao_IsNull( )
      {
         return (gxTv_SdtPropostaNota_Propostaempresarazao_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaCreatedAt" )]
      [  XmlElement( ElementName = "PropostaCreatedAt"  , IsNullable=true )]
      public string gxTpr_Propostacreatedat_Nullable
      {
         get {
            if ( gxTv_SdtPropostaNota_Propostacreatedat == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtPropostaNota_Propostacreatedat).value ;
         }

         set {
            gxTv_SdtPropostaNota_Propostacreatedat_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtPropostaNota_Propostacreatedat = DateTime.MinValue;
            else
               gxTv_SdtPropostaNota_Propostacreatedat = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Propostacreatedat
      {
         get {
            return gxTv_SdtPropostaNota_Propostacreatedat ;
         }

         set {
            gxTv_SdtPropostaNota_Propostacreatedat_N = 0;
            sdtIsNull = 0;
            gxTv_SdtPropostaNota_Propostacreatedat = value;
            SetDirty("Propostacreatedat");
         }

      }

      public void gxTv_SdtPropostaNota_Propostacreatedat_SetNull( )
      {
         gxTv_SdtPropostaNota_Propostacreatedat_N = 1;
         gxTv_SdtPropostaNota_Propostacreatedat = (DateTime)(DateTime.MinValue);
         SetDirty("Propostacreatedat");
         return  ;
      }

      public bool gxTv_SdtPropostaNota_Propostacreatedat_IsNull( )
      {
         return (gxTv_SdtPropostaNota_Propostacreatedat_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaStatus" )]
      [  XmlElement( ElementName = "PropostaStatus"   )]
      public string gxTpr_Propostastatus
      {
         get {
            return gxTv_SdtPropostaNota_Propostastatus ;
         }

         set {
            gxTv_SdtPropostaNota_Propostastatus_N = 0;
            sdtIsNull = 0;
            gxTv_SdtPropostaNota_Propostastatus = value;
            SetDirty("Propostastatus");
         }

      }

      public void gxTv_SdtPropostaNota_Propostastatus_SetNull( )
      {
         gxTv_SdtPropostaNota_Propostastatus_N = 1;
         gxTv_SdtPropostaNota_Propostastatus = "";
         SetDirty("Propostastatus");
         return  ;
      }

      public bool gxTv_SdtPropostaNota_Propostastatus_IsNull( )
      {
         return (gxTv_SdtPropostaNota_Propostastatus_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtPropostaNota_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaNota_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtPropostaNota_Mode_SetNull( )
      {
         gxTv_SdtPropostaNota_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtPropostaNota_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtPropostaNota_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaNota_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtPropostaNota_Initialized_SetNull( )
      {
         gxTv_SdtPropostaNota_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtPropostaNota_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaId_Z" )]
      [  XmlElement( ElementName = "PropostaId_Z"   )]
      public int gxTpr_Propostaid_Z
      {
         get {
            return gxTv_SdtPropostaNota_Propostaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaNota_Propostaid_Z = value;
            SetDirty("Propostaid_Z");
         }

      }

      public void gxTv_SdtPropostaNota_Propostaid_Z_SetNull( )
      {
         gxTv_SdtPropostaNota_Propostaid_Z = 0;
         SetDirty("Propostaid_Z");
         return  ;
      }

      public bool gxTv_SdtPropostaNota_Propostaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaQtdItensNota_F_Z" )]
      [  XmlElement( ElementName = "PropostaQtdItensNota_F_Z"   )]
      public short gxTpr_Propostaqtditensnota_f_Z
      {
         get {
            return gxTv_SdtPropostaNota_Propostaqtditensnota_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaNota_Propostaqtditensnota_f_Z = value;
            SetDirty("Propostaqtditensnota_f_Z");
         }

      }

      public void gxTv_SdtPropostaNota_Propostaqtditensnota_f_Z_SetNull( )
      {
         gxTv_SdtPropostaNota_Propostaqtditensnota_f_Z = 0;
         SetDirty("Propostaqtditensnota_f_Z");
         return  ;
      }

      public bool gxTv_SdtPropostaNota_Propostaqtditensnota_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaProtocolo_Z" )]
      [  XmlElement( ElementName = "PropostaProtocolo_Z"   )]
      public string gxTpr_Propostaprotocolo_Z
      {
         get {
            return gxTv_SdtPropostaNota_Propostaprotocolo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaNota_Propostaprotocolo_Z = value;
            SetDirty("Propostaprotocolo_Z");
         }

      }

      public void gxTv_SdtPropostaNota_Propostaprotocolo_Z_SetNull( )
      {
         gxTv_SdtPropostaNota_Propostaprotocolo_Z = "";
         SetDirty("Propostaprotocolo_Z");
         return  ;
      }

      public bool gxTv_SdtPropostaNota_Propostaprotocolo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaTipoProposta_Z" )]
      [  XmlElement( ElementName = "PropostaTipoProposta_Z"   )]
      public string gxTpr_Propostatipoproposta_Z
      {
         get {
            return gxTv_SdtPropostaNota_Propostatipoproposta_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaNota_Propostatipoproposta_Z = value;
            SetDirty("Propostatipoproposta_Z");
         }

      }

      public void gxTv_SdtPropostaNota_Propostatipoproposta_Z_SetNull( )
      {
         gxTv_SdtPropostaNota_Propostatipoproposta_Z = "";
         SetDirty("Propostatipoproposta_Z");
         return  ;
      }

      public bool gxTv_SdtPropostaNota_Propostatipoproposta_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaSumItensnota_F_Z" )]
      [  XmlElement( ElementName = "PropostaSumItensnota_F_Z"   )]
      public decimal gxTpr_Propostasumitensnota_f_Z
      {
         get {
            return gxTv_SdtPropostaNota_Propostasumitensnota_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaNota_Propostasumitensnota_f_Z = value;
            SetDirty("Propostasumitensnota_f_Z");
         }

      }

      public void gxTv_SdtPropostaNota_Propostasumitensnota_f_Z_SetNull( )
      {
         gxTv_SdtPropostaNota_Propostasumitensnota_f_Z = 0;
         SetDirty("Propostasumitensnota_f_Z");
         return  ;
      }

      public bool gxTv_SdtPropostaNota_Propostasumitensnota_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaEmpresaClienteId_Z" )]
      [  XmlElement( ElementName = "PropostaEmpresaClienteId_Z"   )]
      public int gxTpr_Propostaempresaclienteid_Z
      {
         get {
            return gxTv_SdtPropostaNota_Propostaempresaclienteid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaNota_Propostaempresaclienteid_Z = value;
            SetDirty("Propostaempresaclienteid_Z");
         }

      }

      public void gxTv_SdtPropostaNota_Propostaempresaclienteid_Z_SetNull( )
      {
         gxTv_SdtPropostaNota_Propostaempresaclienteid_Z = 0;
         SetDirty("Propostaempresaclienteid_Z");
         return  ;
      }

      public bool gxTv_SdtPropostaNota_Propostaempresaclienteid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaEmpresaRazao_Z" )]
      [  XmlElement( ElementName = "PropostaEmpresaRazao_Z"   )]
      public string gxTpr_Propostaempresarazao_Z
      {
         get {
            return gxTv_SdtPropostaNota_Propostaempresarazao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaNota_Propostaempresarazao_Z = value;
            SetDirty("Propostaempresarazao_Z");
         }

      }

      public void gxTv_SdtPropostaNota_Propostaempresarazao_Z_SetNull( )
      {
         gxTv_SdtPropostaNota_Propostaempresarazao_Z = "";
         SetDirty("Propostaempresarazao_Z");
         return  ;
      }

      public bool gxTv_SdtPropostaNota_Propostaempresarazao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaCreatedAt_Z" )]
      [  XmlElement( ElementName = "PropostaCreatedAt_Z"  , IsNullable=true )]
      public string gxTpr_Propostacreatedat_Z_Nullable
      {
         get {
            if ( gxTv_SdtPropostaNota_Propostacreatedat_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtPropostaNota_Propostacreatedat_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtPropostaNota_Propostacreatedat_Z = DateTime.MinValue;
            else
               gxTv_SdtPropostaNota_Propostacreatedat_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Propostacreatedat_Z
      {
         get {
            return gxTv_SdtPropostaNota_Propostacreatedat_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaNota_Propostacreatedat_Z = value;
            SetDirty("Propostacreatedat_Z");
         }

      }

      public void gxTv_SdtPropostaNota_Propostacreatedat_Z_SetNull( )
      {
         gxTv_SdtPropostaNota_Propostacreatedat_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Propostacreatedat_Z");
         return  ;
      }

      public bool gxTv_SdtPropostaNota_Propostacreatedat_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaStatus_Z" )]
      [  XmlElement( ElementName = "PropostaStatus_Z"   )]
      public string gxTpr_Propostastatus_Z
      {
         get {
            return gxTv_SdtPropostaNota_Propostastatus_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaNota_Propostastatus_Z = value;
            SetDirty("Propostastatus_Z");
         }

      }

      public void gxTv_SdtPropostaNota_Propostastatus_Z_SetNull( )
      {
         gxTv_SdtPropostaNota_Propostastatus_Z = "";
         SetDirty("Propostastatus_Z");
         return  ;
      }

      public bool gxTv_SdtPropostaNota_Propostastatus_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaId_N" )]
      [  XmlElement( ElementName = "PropostaId_N"   )]
      public short gxTpr_Propostaid_N
      {
         get {
            return gxTv_SdtPropostaNota_Propostaid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaNota_Propostaid_N = value;
            SetDirty("Propostaid_N");
         }

      }

      public void gxTv_SdtPropostaNota_Propostaid_N_SetNull( )
      {
         gxTv_SdtPropostaNota_Propostaid_N = 0;
         SetDirty("Propostaid_N");
         return  ;
      }

      public bool gxTv_SdtPropostaNota_Propostaid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaProtocolo_N" )]
      [  XmlElement( ElementName = "PropostaProtocolo_N"   )]
      public short gxTpr_Propostaprotocolo_N
      {
         get {
            return gxTv_SdtPropostaNota_Propostaprotocolo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaNota_Propostaprotocolo_N = value;
            SetDirty("Propostaprotocolo_N");
         }

      }

      public void gxTv_SdtPropostaNota_Propostaprotocolo_N_SetNull( )
      {
         gxTv_SdtPropostaNota_Propostaprotocolo_N = 0;
         SetDirty("Propostaprotocolo_N");
         return  ;
      }

      public bool gxTv_SdtPropostaNota_Propostaprotocolo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaTipoProposta_N" )]
      [  XmlElement( ElementName = "PropostaTipoProposta_N"   )]
      public short gxTpr_Propostatipoproposta_N
      {
         get {
            return gxTv_SdtPropostaNota_Propostatipoproposta_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaNota_Propostatipoproposta_N = value;
            SetDirty("Propostatipoproposta_N");
         }

      }

      public void gxTv_SdtPropostaNota_Propostatipoproposta_N_SetNull( )
      {
         gxTv_SdtPropostaNota_Propostatipoproposta_N = 0;
         SetDirty("Propostatipoproposta_N");
         return  ;
      }

      public bool gxTv_SdtPropostaNota_Propostatipoproposta_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaEmpresaClienteId_N" )]
      [  XmlElement( ElementName = "PropostaEmpresaClienteId_N"   )]
      public short gxTpr_Propostaempresaclienteid_N
      {
         get {
            return gxTv_SdtPropostaNota_Propostaempresaclienteid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaNota_Propostaempresaclienteid_N = value;
            SetDirty("Propostaempresaclienteid_N");
         }

      }

      public void gxTv_SdtPropostaNota_Propostaempresaclienteid_N_SetNull( )
      {
         gxTv_SdtPropostaNota_Propostaempresaclienteid_N = 0;
         SetDirty("Propostaempresaclienteid_N");
         return  ;
      }

      public bool gxTv_SdtPropostaNota_Propostaempresaclienteid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaEmpresaRazao_N" )]
      [  XmlElement( ElementName = "PropostaEmpresaRazao_N"   )]
      public short gxTpr_Propostaempresarazao_N
      {
         get {
            return gxTv_SdtPropostaNota_Propostaempresarazao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaNota_Propostaempresarazao_N = value;
            SetDirty("Propostaempresarazao_N");
         }

      }

      public void gxTv_SdtPropostaNota_Propostaempresarazao_N_SetNull( )
      {
         gxTv_SdtPropostaNota_Propostaempresarazao_N = 0;
         SetDirty("Propostaempresarazao_N");
         return  ;
      }

      public bool gxTv_SdtPropostaNota_Propostaempresarazao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaCreatedAt_N" )]
      [  XmlElement( ElementName = "PropostaCreatedAt_N"   )]
      public short gxTpr_Propostacreatedat_N
      {
         get {
            return gxTv_SdtPropostaNota_Propostacreatedat_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaNota_Propostacreatedat_N = value;
            SetDirty("Propostacreatedat_N");
         }

      }

      public void gxTv_SdtPropostaNota_Propostacreatedat_N_SetNull( )
      {
         gxTv_SdtPropostaNota_Propostacreatedat_N = 0;
         SetDirty("Propostacreatedat_N");
         return  ;
      }

      public bool gxTv_SdtPropostaNota_Propostacreatedat_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaStatus_N" )]
      [  XmlElement( ElementName = "PropostaStatus_N"   )]
      public short gxTpr_Propostastatus_N
      {
         get {
            return gxTv_SdtPropostaNota_Propostastatus_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaNota_Propostastatus_N = value;
            SetDirty("Propostastatus_N");
         }

      }

      public void gxTv_SdtPropostaNota_Propostastatus_N_SetNull( )
      {
         gxTv_SdtPropostaNota_Propostastatus_N = 0;
         SetDirty("Propostastatus_N");
         return  ;
      }

      public bool gxTv_SdtPropostaNota_Propostastatus_N_IsNull( )
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
         gxTv_SdtPropostaNota_Propostaprotocolo = "";
         gxTv_SdtPropostaNota_Propostatipoproposta = "";
         gxTv_SdtPropostaNota_Propostaempresarazao = "";
         gxTv_SdtPropostaNota_Propostacreatedat = (DateTime)(DateTime.MinValue);
         gxTv_SdtPropostaNota_Propostastatus = "";
         gxTv_SdtPropostaNota_Mode = "";
         gxTv_SdtPropostaNota_Propostaprotocolo_Z = "";
         gxTv_SdtPropostaNota_Propostatipoproposta_Z = "";
         gxTv_SdtPropostaNota_Propostaempresarazao_Z = "";
         gxTv_SdtPropostaNota_Propostacreatedat_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtPropostaNota_Propostastatus_Z = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "propostanota", "GeneXus.Programs.propostanota_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtPropostaNota_Propostaqtditensnota_f ;
      private short gxTv_SdtPropostaNota_Initialized ;
      private short gxTv_SdtPropostaNota_Propostaqtditensnota_f_Z ;
      private short gxTv_SdtPropostaNota_Propostaid_N ;
      private short gxTv_SdtPropostaNota_Propostaprotocolo_N ;
      private short gxTv_SdtPropostaNota_Propostatipoproposta_N ;
      private short gxTv_SdtPropostaNota_Propostaempresaclienteid_N ;
      private short gxTv_SdtPropostaNota_Propostaempresarazao_N ;
      private short gxTv_SdtPropostaNota_Propostacreatedat_N ;
      private short gxTv_SdtPropostaNota_Propostastatus_N ;
      private int gxTv_SdtPropostaNota_Propostaid ;
      private int gxTv_SdtPropostaNota_Propostaempresaclienteid ;
      private int gxTv_SdtPropostaNota_Propostaid_Z ;
      private int gxTv_SdtPropostaNota_Propostaempresaclienteid_Z ;
      private decimal gxTv_SdtPropostaNota_Propostasumitensnota_f ;
      private decimal gxTv_SdtPropostaNota_Propostasumitensnota_f_Z ;
      private string gxTv_SdtPropostaNota_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtPropostaNota_Propostacreatedat ;
      private DateTime gxTv_SdtPropostaNota_Propostacreatedat_Z ;
      private DateTime datetime_STZ ;
      private string gxTv_SdtPropostaNota_Propostaprotocolo ;
      private string gxTv_SdtPropostaNota_Propostatipoproposta ;
      private string gxTv_SdtPropostaNota_Propostaempresarazao ;
      private string gxTv_SdtPropostaNota_Propostastatus ;
      private string gxTv_SdtPropostaNota_Propostaprotocolo_Z ;
      private string gxTv_SdtPropostaNota_Propostatipoproposta_Z ;
      private string gxTv_SdtPropostaNota_Propostaempresarazao_Z ;
      private string gxTv_SdtPropostaNota_Propostastatus_Z ;
   }

   [DataContract(Name = @"PropostaNota", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtPropostaNota_RESTInterface : GxGenericCollectionItem<SdtPropostaNota>
   {
      public SdtPropostaNota_RESTInterface( ) : base()
      {
      }

      public SdtPropostaNota_RESTInterface( SdtPropostaNota psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PropostaId" , Order = 0 )]
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

      [DataMember( Name = "PropostaQtdItensNota_F" , Order = 1 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Propostaqtditensnota_f
      {
         get {
            return sdt.gxTpr_Propostaqtditensnota_f ;
         }

         set {
            sdt.gxTpr_Propostaqtditensnota_f = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "PropostaProtocolo" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Propostaprotocolo
      {
         get {
            return sdt.gxTpr_Propostaprotocolo ;
         }

         set {
            sdt.gxTpr_Propostaprotocolo = value;
         }

      }

      [DataMember( Name = "PropostaTipoProposta" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Propostatipoproposta
      {
         get {
            return sdt.gxTpr_Propostatipoproposta ;
         }

         set {
            sdt.gxTpr_Propostatipoproposta = value;
         }

      }

      [DataMember( Name = "PropostaSumItensnota_F" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Propostasumitensnota_f
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Propostasumitensnota_f, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Propostasumitensnota_f = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "PropostaEmpresaClienteId" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Propostaempresaclienteid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Propostaempresaclienteid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Propostaempresaclienteid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "PropostaEmpresaRazao" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Propostaempresarazao
      {
         get {
            return sdt.gxTpr_Propostaempresarazao ;
         }

         set {
            sdt.gxTpr_Propostaempresarazao = value;
         }

      }

      [DataMember( Name = "PropostaCreatedAt" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Propostacreatedat
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Propostacreatedat, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Propostacreatedat = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "PropostaStatus" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Propostastatus
      {
         get {
            return sdt.gxTpr_Propostastatus ;
         }

         set {
            sdt.gxTpr_Propostastatus = value;
         }

      }

      public SdtPropostaNota sdt
      {
         get {
            return (SdtPropostaNota)Sdt ;
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
            sdt = new SdtPropostaNota() ;
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

   [DataContract(Name = @"PropostaNota", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtPropostaNota_RESTLInterface : GxGenericCollectionItem<SdtPropostaNota>
   {
      public SdtPropostaNota_RESTLInterface( ) : base()
      {
      }

      public SdtPropostaNota_RESTLInterface( SdtPropostaNota psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PropostaQtdItensNota_F" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Propostaqtditensnota_f
      {
         get {
            return sdt.gxTpr_Propostaqtditensnota_f ;
         }

         set {
            sdt.gxTpr_Propostaqtditensnota_f = (short)(value.HasValue ? value.Value : 0);
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

      public SdtPropostaNota sdt
      {
         get {
            return (SdtPropostaNota)Sdt ;
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
            sdt = new SdtPropostaNota() ;
         }
      }

   }

}
