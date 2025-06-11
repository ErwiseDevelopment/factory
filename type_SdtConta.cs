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
   [XmlRoot(ElementName = "Conta" )]
   [XmlType(TypeName =  "Conta" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtConta : GxSilentTrnSdt
   {
      public SdtConta( )
      {
      }

      public SdtConta( IGxContext context )
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

      public void Load( int AV422ContaId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV422ContaId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ContaId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Conta");
         metadata.Set("BT", "Conta");
         metadata.Set("PK", "[ \"ContaId\" ]");
         metadata.Set("PKAssigned", "[ \"ContaId\" ]");
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
         state.Add("gxTpr_Contaid_Z");
         state.Add("gxTpr_Contasaldoatual_Z");
         state.Add("gxTpr_Contanomeconta_Z");
         state.Add("gxTpr_Contadataultimaatualizacao_Z_Nullable");
         state.Add("gxTpr_Contastatus_Z");
         state.Add("gxTpr_Contaproposta_Z");
         state.Add("gxTpr_Contaid_N");
         state.Add("gxTpr_Contasaldoatual_N");
         state.Add("gxTpr_Contanomeconta_N");
         state.Add("gxTpr_Contadataultimaatualizacao_N");
         state.Add("gxTpr_Contastatus_N");
         state.Add("gxTpr_Contaproposta_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtConta sdt;
         sdt = (SdtConta)(source);
         gxTv_SdtConta_Contaid = sdt.gxTv_SdtConta_Contaid ;
         gxTv_SdtConta_Contasaldoatual = sdt.gxTv_SdtConta_Contasaldoatual ;
         gxTv_SdtConta_Contanomeconta = sdt.gxTv_SdtConta_Contanomeconta ;
         gxTv_SdtConta_Contadataultimaatualizacao = sdt.gxTv_SdtConta_Contadataultimaatualizacao ;
         gxTv_SdtConta_Contastatus = sdt.gxTv_SdtConta_Contastatus ;
         gxTv_SdtConta_Contaproposta = sdt.gxTv_SdtConta_Contaproposta ;
         gxTv_SdtConta_Mode = sdt.gxTv_SdtConta_Mode ;
         gxTv_SdtConta_Initialized = sdt.gxTv_SdtConta_Initialized ;
         gxTv_SdtConta_Contaid_Z = sdt.gxTv_SdtConta_Contaid_Z ;
         gxTv_SdtConta_Contasaldoatual_Z = sdt.gxTv_SdtConta_Contasaldoatual_Z ;
         gxTv_SdtConta_Contanomeconta_Z = sdt.gxTv_SdtConta_Contanomeconta_Z ;
         gxTv_SdtConta_Contadataultimaatualizacao_Z = sdt.gxTv_SdtConta_Contadataultimaatualizacao_Z ;
         gxTv_SdtConta_Contastatus_Z = sdt.gxTv_SdtConta_Contastatus_Z ;
         gxTv_SdtConta_Contaproposta_Z = sdt.gxTv_SdtConta_Contaproposta_Z ;
         gxTv_SdtConta_Contaid_N = sdt.gxTv_SdtConta_Contaid_N ;
         gxTv_SdtConta_Contasaldoatual_N = sdt.gxTv_SdtConta_Contasaldoatual_N ;
         gxTv_SdtConta_Contanomeconta_N = sdt.gxTv_SdtConta_Contanomeconta_N ;
         gxTv_SdtConta_Contadataultimaatualizacao_N = sdt.gxTv_SdtConta_Contadataultimaatualizacao_N ;
         gxTv_SdtConta_Contastatus_N = sdt.gxTv_SdtConta_Contastatus_N ;
         gxTv_SdtConta_Contaproposta_N = sdt.gxTv_SdtConta_Contaproposta_N ;
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
         AddObjectProperty("ContaId", gxTv_SdtConta_Contaid, false, includeNonInitialized);
         AddObjectProperty("ContaId_N", gxTv_SdtConta_Contaid_N, false, includeNonInitialized);
         AddObjectProperty("ContaSaldoAtual", StringUtil.LTrim( StringUtil.Str( gxTv_SdtConta_Contasaldoatual, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("ContaSaldoAtual_N", gxTv_SdtConta_Contasaldoatual_N, false, includeNonInitialized);
         AddObjectProperty("ContaNomeConta", gxTv_SdtConta_Contanomeconta, false, includeNonInitialized);
         AddObjectProperty("ContaNomeConta_N", gxTv_SdtConta_Contanomeconta_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtConta_Contadataultimaatualizacao;
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
         AddObjectProperty("ContaDataUltimaAtualizacao", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("ContaDataUltimaAtualizacao_N", gxTv_SdtConta_Contadataultimaatualizacao_N, false, includeNonInitialized);
         AddObjectProperty("ContaStatus", gxTv_SdtConta_Contastatus, false, includeNonInitialized);
         AddObjectProperty("ContaStatus_N", gxTv_SdtConta_Contastatus_N, false, includeNonInitialized);
         AddObjectProperty("ContaProposta", gxTv_SdtConta_Contaproposta, false, includeNonInitialized);
         AddObjectProperty("ContaProposta_N", gxTv_SdtConta_Contaproposta_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtConta_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtConta_Initialized, false, includeNonInitialized);
            AddObjectProperty("ContaId_Z", gxTv_SdtConta_Contaid_Z, false, includeNonInitialized);
            AddObjectProperty("ContaSaldoAtual_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtConta_Contasaldoatual_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("ContaNomeConta_Z", gxTv_SdtConta_Contanomeconta_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtConta_Contadataultimaatualizacao_Z;
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
            AddObjectProperty("ContaDataUltimaAtualizacao_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("ContaStatus_Z", gxTv_SdtConta_Contastatus_Z, false, includeNonInitialized);
            AddObjectProperty("ContaProposta_Z", gxTv_SdtConta_Contaproposta_Z, false, includeNonInitialized);
            AddObjectProperty("ContaId_N", gxTv_SdtConta_Contaid_N, false, includeNonInitialized);
            AddObjectProperty("ContaSaldoAtual_N", gxTv_SdtConta_Contasaldoatual_N, false, includeNonInitialized);
            AddObjectProperty("ContaNomeConta_N", gxTv_SdtConta_Contanomeconta_N, false, includeNonInitialized);
            AddObjectProperty("ContaDataUltimaAtualizacao_N", gxTv_SdtConta_Contadataultimaatualizacao_N, false, includeNonInitialized);
            AddObjectProperty("ContaStatus_N", gxTv_SdtConta_Contastatus_N, false, includeNonInitialized);
            AddObjectProperty("ContaProposta_N", gxTv_SdtConta_Contaproposta_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtConta sdt )
      {
         if ( sdt.IsDirty("ContaId") )
         {
            sdtIsNull = 0;
            gxTv_SdtConta_Contaid = sdt.gxTv_SdtConta_Contaid ;
         }
         if ( sdt.IsDirty("ContaSaldoAtual") )
         {
            gxTv_SdtConta_Contasaldoatual_N = (short)(sdt.gxTv_SdtConta_Contasaldoatual_N);
            sdtIsNull = 0;
            gxTv_SdtConta_Contasaldoatual = sdt.gxTv_SdtConta_Contasaldoatual ;
         }
         if ( sdt.IsDirty("ContaNomeConta") )
         {
            gxTv_SdtConta_Contanomeconta_N = (short)(sdt.gxTv_SdtConta_Contanomeconta_N);
            sdtIsNull = 0;
            gxTv_SdtConta_Contanomeconta = sdt.gxTv_SdtConta_Contanomeconta ;
         }
         if ( sdt.IsDirty("ContaDataUltimaAtualizacao") )
         {
            gxTv_SdtConta_Contadataultimaatualizacao_N = (short)(sdt.gxTv_SdtConta_Contadataultimaatualizacao_N);
            sdtIsNull = 0;
            gxTv_SdtConta_Contadataultimaatualizacao = sdt.gxTv_SdtConta_Contadataultimaatualizacao ;
         }
         if ( sdt.IsDirty("ContaStatus") )
         {
            gxTv_SdtConta_Contastatus_N = (short)(sdt.gxTv_SdtConta_Contastatus_N);
            sdtIsNull = 0;
            gxTv_SdtConta_Contastatus = sdt.gxTv_SdtConta_Contastatus ;
         }
         if ( sdt.IsDirty("ContaProposta") )
         {
            gxTv_SdtConta_Contaproposta_N = (short)(sdt.gxTv_SdtConta_Contaproposta_N);
            sdtIsNull = 0;
            gxTv_SdtConta_Contaproposta = sdt.gxTv_SdtConta_Contaproposta ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ContaId" )]
      [  XmlElement( ElementName = "ContaId"   )]
      public int gxTpr_Contaid
      {
         get {
            return gxTv_SdtConta_Contaid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtConta_Contaid != value )
            {
               gxTv_SdtConta_Mode = "INS";
               this.gxTv_SdtConta_Contaid_Z_SetNull( );
               this.gxTv_SdtConta_Contasaldoatual_Z_SetNull( );
               this.gxTv_SdtConta_Contanomeconta_Z_SetNull( );
               this.gxTv_SdtConta_Contadataultimaatualizacao_Z_SetNull( );
               this.gxTv_SdtConta_Contastatus_Z_SetNull( );
               this.gxTv_SdtConta_Contaproposta_Z_SetNull( );
            }
            gxTv_SdtConta_Contaid = value;
            SetDirty("Contaid");
         }

      }

      [  SoapElement( ElementName = "ContaSaldoAtual" )]
      [  XmlElement( ElementName = "ContaSaldoAtual"   )]
      public decimal gxTpr_Contasaldoatual
      {
         get {
            return gxTv_SdtConta_Contasaldoatual ;
         }

         set {
            gxTv_SdtConta_Contasaldoatual_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConta_Contasaldoatual = value;
            SetDirty("Contasaldoatual");
         }

      }

      public void gxTv_SdtConta_Contasaldoatual_SetNull( )
      {
         gxTv_SdtConta_Contasaldoatual_N = 1;
         gxTv_SdtConta_Contasaldoatual = 0;
         SetDirty("Contasaldoatual");
         return  ;
      }

      public bool gxTv_SdtConta_Contasaldoatual_IsNull( )
      {
         return (gxTv_SdtConta_Contasaldoatual_N==1) ;
      }

      [  SoapElement( ElementName = "ContaNomeConta" )]
      [  XmlElement( ElementName = "ContaNomeConta"   )]
      public string gxTpr_Contanomeconta
      {
         get {
            return gxTv_SdtConta_Contanomeconta ;
         }

         set {
            gxTv_SdtConta_Contanomeconta_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConta_Contanomeconta = value;
            SetDirty("Contanomeconta");
         }

      }

      public void gxTv_SdtConta_Contanomeconta_SetNull( )
      {
         gxTv_SdtConta_Contanomeconta_N = 1;
         gxTv_SdtConta_Contanomeconta = "";
         SetDirty("Contanomeconta");
         return  ;
      }

      public bool gxTv_SdtConta_Contanomeconta_IsNull( )
      {
         return (gxTv_SdtConta_Contanomeconta_N==1) ;
      }

      [  SoapElement( ElementName = "ContaDataUltimaAtualizacao" )]
      [  XmlElement( ElementName = "ContaDataUltimaAtualizacao"  , IsNullable=true )]
      public string gxTpr_Contadataultimaatualizacao_Nullable
      {
         get {
            if ( gxTv_SdtConta_Contadataultimaatualizacao == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtConta_Contadataultimaatualizacao).value ;
         }

         set {
            gxTv_SdtConta_Contadataultimaatualizacao_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtConta_Contadataultimaatualizacao = DateTime.MinValue;
            else
               gxTv_SdtConta_Contadataultimaatualizacao = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Contadataultimaatualizacao
      {
         get {
            return gxTv_SdtConta_Contadataultimaatualizacao ;
         }

         set {
            gxTv_SdtConta_Contadataultimaatualizacao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConta_Contadataultimaatualizacao = value;
            SetDirty("Contadataultimaatualizacao");
         }

      }

      public void gxTv_SdtConta_Contadataultimaatualizacao_SetNull( )
      {
         gxTv_SdtConta_Contadataultimaatualizacao_N = 1;
         gxTv_SdtConta_Contadataultimaatualizacao = (DateTime)(DateTime.MinValue);
         SetDirty("Contadataultimaatualizacao");
         return  ;
      }

      public bool gxTv_SdtConta_Contadataultimaatualizacao_IsNull( )
      {
         return (gxTv_SdtConta_Contadataultimaatualizacao_N==1) ;
      }

      [  SoapElement( ElementName = "ContaStatus" )]
      [  XmlElement( ElementName = "ContaStatus"   )]
      public bool gxTpr_Contastatus
      {
         get {
            return gxTv_SdtConta_Contastatus ;
         }

         set {
            gxTv_SdtConta_Contastatus_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConta_Contastatus = value;
            SetDirty("Contastatus");
         }

      }

      public void gxTv_SdtConta_Contastatus_SetNull( )
      {
         gxTv_SdtConta_Contastatus_N = 1;
         gxTv_SdtConta_Contastatus = false;
         SetDirty("Contastatus");
         return  ;
      }

      public bool gxTv_SdtConta_Contastatus_IsNull( )
      {
         return (gxTv_SdtConta_Contastatus_N==1) ;
      }

      [  SoapElement( ElementName = "ContaProposta" )]
      [  XmlElement( ElementName = "ContaProposta"   )]
      public bool gxTpr_Contaproposta
      {
         get {
            return gxTv_SdtConta_Contaproposta ;
         }

         set {
            gxTv_SdtConta_Contaproposta_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConta_Contaproposta = value;
            SetDirty("Contaproposta");
         }

      }

      public void gxTv_SdtConta_Contaproposta_SetNull( )
      {
         gxTv_SdtConta_Contaproposta_N = 1;
         gxTv_SdtConta_Contaproposta = false;
         SetDirty("Contaproposta");
         return  ;
      }

      public bool gxTv_SdtConta_Contaproposta_IsNull( )
      {
         return (gxTv_SdtConta_Contaproposta_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtConta_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConta_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtConta_Mode_SetNull( )
      {
         gxTv_SdtConta_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtConta_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtConta_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConta_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtConta_Initialized_SetNull( )
      {
         gxTv_SdtConta_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtConta_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaId_Z" )]
      [  XmlElement( ElementName = "ContaId_Z"   )]
      public int gxTpr_Contaid_Z
      {
         get {
            return gxTv_SdtConta_Contaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConta_Contaid_Z = value;
            SetDirty("Contaid_Z");
         }

      }

      public void gxTv_SdtConta_Contaid_Z_SetNull( )
      {
         gxTv_SdtConta_Contaid_Z = 0;
         SetDirty("Contaid_Z");
         return  ;
      }

      public bool gxTv_SdtConta_Contaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaSaldoAtual_Z" )]
      [  XmlElement( ElementName = "ContaSaldoAtual_Z"   )]
      public decimal gxTpr_Contasaldoatual_Z
      {
         get {
            return gxTv_SdtConta_Contasaldoatual_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConta_Contasaldoatual_Z = value;
            SetDirty("Contasaldoatual_Z");
         }

      }

      public void gxTv_SdtConta_Contasaldoatual_Z_SetNull( )
      {
         gxTv_SdtConta_Contasaldoatual_Z = 0;
         SetDirty("Contasaldoatual_Z");
         return  ;
      }

      public bool gxTv_SdtConta_Contasaldoatual_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaNomeConta_Z" )]
      [  XmlElement( ElementName = "ContaNomeConta_Z"   )]
      public string gxTpr_Contanomeconta_Z
      {
         get {
            return gxTv_SdtConta_Contanomeconta_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConta_Contanomeconta_Z = value;
            SetDirty("Contanomeconta_Z");
         }

      }

      public void gxTv_SdtConta_Contanomeconta_Z_SetNull( )
      {
         gxTv_SdtConta_Contanomeconta_Z = "";
         SetDirty("Contanomeconta_Z");
         return  ;
      }

      public bool gxTv_SdtConta_Contanomeconta_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaDataUltimaAtualizacao_Z" )]
      [  XmlElement( ElementName = "ContaDataUltimaAtualizacao_Z"  , IsNullable=true )]
      public string gxTpr_Contadataultimaatualizacao_Z_Nullable
      {
         get {
            if ( gxTv_SdtConta_Contadataultimaatualizacao_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtConta_Contadataultimaatualizacao_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtConta_Contadataultimaatualizacao_Z = DateTime.MinValue;
            else
               gxTv_SdtConta_Contadataultimaatualizacao_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Contadataultimaatualizacao_Z
      {
         get {
            return gxTv_SdtConta_Contadataultimaatualizacao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConta_Contadataultimaatualizacao_Z = value;
            SetDirty("Contadataultimaatualizacao_Z");
         }

      }

      public void gxTv_SdtConta_Contadataultimaatualizacao_Z_SetNull( )
      {
         gxTv_SdtConta_Contadataultimaatualizacao_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Contadataultimaatualizacao_Z");
         return  ;
      }

      public bool gxTv_SdtConta_Contadataultimaatualizacao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaStatus_Z" )]
      [  XmlElement( ElementName = "ContaStatus_Z"   )]
      public bool gxTpr_Contastatus_Z
      {
         get {
            return gxTv_SdtConta_Contastatus_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConta_Contastatus_Z = value;
            SetDirty("Contastatus_Z");
         }

      }

      public void gxTv_SdtConta_Contastatus_Z_SetNull( )
      {
         gxTv_SdtConta_Contastatus_Z = false;
         SetDirty("Contastatus_Z");
         return  ;
      }

      public bool gxTv_SdtConta_Contastatus_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaProposta_Z" )]
      [  XmlElement( ElementName = "ContaProposta_Z"   )]
      public bool gxTpr_Contaproposta_Z
      {
         get {
            return gxTv_SdtConta_Contaproposta_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConta_Contaproposta_Z = value;
            SetDirty("Contaproposta_Z");
         }

      }

      public void gxTv_SdtConta_Contaproposta_Z_SetNull( )
      {
         gxTv_SdtConta_Contaproposta_Z = false;
         SetDirty("Contaproposta_Z");
         return  ;
      }

      public bool gxTv_SdtConta_Contaproposta_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaId_N" )]
      [  XmlElement( ElementName = "ContaId_N"   )]
      public short gxTpr_Contaid_N
      {
         get {
            return gxTv_SdtConta_Contaid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConta_Contaid_N = value;
            SetDirty("Contaid_N");
         }

      }

      public void gxTv_SdtConta_Contaid_N_SetNull( )
      {
         gxTv_SdtConta_Contaid_N = 0;
         SetDirty("Contaid_N");
         return  ;
      }

      public bool gxTv_SdtConta_Contaid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaSaldoAtual_N" )]
      [  XmlElement( ElementName = "ContaSaldoAtual_N"   )]
      public short gxTpr_Contasaldoatual_N
      {
         get {
            return gxTv_SdtConta_Contasaldoatual_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConta_Contasaldoatual_N = value;
            SetDirty("Contasaldoatual_N");
         }

      }

      public void gxTv_SdtConta_Contasaldoatual_N_SetNull( )
      {
         gxTv_SdtConta_Contasaldoatual_N = 0;
         SetDirty("Contasaldoatual_N");
         return  ;
      }

      public bool gxTv_SdtConta_Contasaldoatual_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaNomeConta_N" )]
      [  XmlElement( ElementName = "ContaNomeConta_N"   )]
      public short gxTpr_Contanomeconta_N
      {
         get {
            return gxTv_SdtConta_Contanomeconta_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConta_Contanomeconta_N = value;
            SetDirty("Contanomeconta_N");
         }

      }

      public void gxTv_SdtConta_Contanomeconta_N_SetNull( )
      {
         gxTv_SdtConta_Contanomeconta_N = 0;
         SetDirty("Contanomeconta_N");
         return  ;
      }

      public bool gxTv_SdtConta_Contanomeconta_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaDataUltimaAtualizacao_N" )]
      [  XmlElement( ElementName = "ContaDataUltimaAtualizacao_N"   )]
      public short gxTpr_Contadataultimaatualizacao_N
      {
         get {
            return gxTv_SdtConta_Contadataultimaatualizacao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConta_Contadataultimaatualizacao_N = value;
            SetDirty("Contadataultimaatualizacao_N");
         }

      }

      public void gxTv_SdtConta_Contadataultimaatualizacao_N_SetNull( )
      {
         gxTv_SdtConta_Contadataultimaatualizacao_N = 0;
         SetDirty("Contadataultimaatualizacao_N");
         return  ;
      }

      public bool gxTv_SdtConta_Contadataultimaatualizacao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaStatus_N" )]
      [  XmlElement( ElementName = "ContaStatus_N"   )]
      public short gxTpr_Contastatus_N
      {
         get {
            return gxTv_SdtConta_Contastatus_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConta_Contastatus_N = value;
            SetDirty("Contastatus_N");
         }

      }

      public void gxTv_SdtConta_Contastatus_N_SetNull( )
      {
         gxTv_SdtConta_Contastatus_N = 0;
         SetDirty("Contastatus_N");
         return  ;
      }

      public bool gxTv_SdtConta_Contastatus_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaProposta_N" )]
      [  XmlElement( ElementName = "ContaProposta_N"   )]
      public short gxTpr_Contaproposta_N
      {
         get {
            return gxTv_SdtConta_Contaproposta_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConta_Contaproposta_N = value;
            SetDirty("Contaproposta_N");
         }

      }

      public void gxTv_SdtConta_Contaproposta_N_SetNull( )
      {
         gxTv_SdtConta_Contaproposta_N = 0;
         SetDirty("Contaproposta_N");
         return  ;
      }

      public bool gxTv_SdtConta_Contaproposta_N_IsNull( )
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
         gxTv_SdtConta_Contanomeconta = "";
         gxTv_SdtConta_Contadataultimaatualizacao = (DateTime)(DateTime.MinValue);
         gxTv_SdtConta_Mode = "";
         gxTv_SdtConta_Contanomeconta_Z = "";
         gxTv_SdtConta_Contadataultimaatualizacao_Z = (DateTime)(DateTime.MinValue);
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "conta", "GeneXus.Programs.conta_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtConta_Initialized ;
      private short gxTv_SdtConta_Contaid_N ;
      private short gxTv_SdtConta_Contasaldoatual_N ;
      private short gxTv_SdtConta_Contanomeconta_N ;
      private short gxTv_SdtConta_Contadataultimaatualizacao_N ;
      private short gxTv_SdtConta_Contastatus_N ;
      private short gxTv_SdtConta_Contaproposta_N ;
      private int gxTv_SdtConta_Contaid ;
      private int gxTv_SdtConta_Contaid_Z ;
      private decimal gxTv_SdtConta_Contasaldoatual ;
      private decimal gxTv_SdtConta_Contasaldoatual_Z ;
      private string gxTv_SdtConta_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtConta_Contadataultimaatualizacao ;
      private DateTime gxTv_SdtConta_Contadataultimaatualizacao_Z ;
      private DateTime datetime_STZ ;
      private bool gxTv_SdtConta_Contastatus ;
      private bool gxTv_SdtConta_Contaproposta ;
      private bool gxTv_SdtConta_Contastatus_Z ;
      private bool gxTv_SdtConta_Contaproposta_Z ;
      private string gxTv_SdtConta_Contanomeconta ;
      private string gxTv_SdtConta_Contanomeconta_Z ;
   }

   [DataContract(Name = @"Conta", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtConta_RESTInterface : GxGenericCollectionItem<SdtConta>
   {
      public SdtConta_RESTInterface( ) : base()
      {
      }

      public SdtConta_RESTInterface( SdtConta psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ContaId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Contaid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Contaid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Contaid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ContaSaldoAtual" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Contasaldoatual
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Contasaldoatual, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Contasaldoatual = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "ContaNomeConta" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Contanomeconta
      {
         get {
            return sdt.gxTpr_Contanomeconta ;
         }

         set {
            sdt.gxTpr_Contanomeconta = value;
         }

      }

      [DataMember( Name = "ContaDataUltimaAtualizacao" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Contadataultimaatualizacao
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Contadataultimaatualizacao, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Contadataultimaatualizacao = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "ContaStatus" , Order = 4 )]
      [GxSeudo()]
      public bool gxTpr_Contastatus
      {
         get {
            return sdt.gxTpr_Contastatus ;
         }

         set {
            sdt.gxTpr_Contastatus = value;
         }

      }

      [DataMember( Name = "ContaProposta" , Order = 5 )]
      [GxSeudo()]
      public bool gxTpr_Contaproposta
      {
         get {
            return sdt.gxTpr_Contaproposta ;
         }

         set {
            sdt.gxTpr_Contaproposta = value;
         }

      }

      public SdtConta sdt
      {
         get {
            return (SdtConta)Sdt ;
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
            sdt = new SdtConta() ;
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

   [DataContract(Name = @"Conta", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtConta_RESTLInterface : GxGenericCollectionItem<SdtConta>
   {
      public SdtConta_RESTLInterface( ) : base()
      {
      }

      public SdtConta_RESTLInterface( SdtConta psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ContaSaldoAtual" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Contasaldoatual
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Contasaldoatual, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Contasaldoatual = NumberUtil.Val( value, ".");
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

      public SdtConta sdt
      {
         get {
            return (SdtConta)Sdt ;
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
            sdt = new SdtConta() ;
         }
      }

   }

}
