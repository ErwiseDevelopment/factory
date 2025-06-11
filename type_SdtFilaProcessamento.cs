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
   [XmlRoot(ElementName = "FilaProcessamento" )]
   [XmlType(TypeName =  "FilaProcessamento" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtFilaProcessamento : GxSilentTrnSdt
   {
      public SdtFilaProcessamento( )
      {
      }

      public SdtFilaProcessamento( IGxContext context )
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

      public void Load( int AV355FilaProcessamentoId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV355FilaProcessamentoId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"FilaProcessamentoId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "FilaProcessamento");
         metadata.Set("BT", "FilaProcessamento");
         metadata.Set("PK", "[ \"FilaProcessamentoId\" ]");
         metadata.Set("PKAssigned", "[ \"FilaProcessamentoId\" ]");
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
         state.Add("gxTpr_Filaprocessamentoid_Z");
         state.Add("gxTpr_Filaprocessamentofuncao_Z");
         state.Add("gxTpr_Filaprocessamentostatus_Z");
         state.Add("gxTpr_Filaprocessamentocriacao_Z_Nullable");
         state.Add("gxTpr_Filaprocessamentoatualizacao_Z_Nullable");
         state.Add("gxTpr_Filaprocessamentofuncao_N");
         state.Add("gxTpr_Filaprocessamentoparametros_N");
         state.Add("gxTpr_Filaprocessamentostatus_N");
         state.Add("gxTpr_Filaprocessamentocriacao_N");
         state.Add("gxTpr_Filaprocessamentoatualizacao_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtFilaProcessamento sdt;
         sdt = (SdtFilaProcessamento)(source);
         gxTv_SdtFilaProcessamento_Filaprocessamentoid = sdt.gxTv_SdtFilaProcessamento_Filaprocessamentoid ;
         gxTv_SdtFilaProcessamento_Filaprocessamentofuncao = sdt.gxTv_SdtFilaProcessamento_Filaprocessamentofuncao ;
         gxTv_SdtFilaProcessamento_Filaprocessamentoparametros = sdt.gxTv_SdtFilaProcessamento_Filaprocessamentoparametros ;
         gxTv_SdtFilaProcessamento_Filaprocessamentostatus = sdt.gxTv_SdtFilaProcessamento_Filaprocessamentostatus ;
         gxTv_SdtFilaProcessamento_Filaprocessamentocriacao = sdt.gxTv_SdtFilaProcessamento_Filaprocessamentocriacao ;
         gxTv_SdtFilaProcessamento_Filaprocessamentoatualizacao = sdt.gxTv_SdtFilaProcessamento_Filaprocessamentoatualizacao ;
         gxTv_SdtFilaProcessamento_Mode = sdt.gxTv_SdtFilaProcessamento_Mode ;
         gxTv_SdtFilaProcessamento_Initialized = sdt.gxTv_SdtFilaProcessamento_Initialized ;
         gxTv_SdtFilaProcessamento_Filaprocessamentoid_Z = sdt.gxTv_SdtFilaProcessamento_Filaprocessamentoid_Z ;
         gxTv_SdtFilaProcessamento_Filaprocessamentofuncao_Z = sdt.gxTv_SdtFilaProcessamento_Filaprocessamentofuncao_Z ;
         gxTv_SdtFilaProcessamento_Filaprocessamentostatus_Z = sdt.gxTv_SdtFilaProcessamento_Filaprocessamentostatus_Z ;
         gxTv_SdtFilaProcessamento_Filaprocessamentocriacao_Z = sdt.gxTv_SdtFilaProcessamento_Filaprocessamentocriacao_Z ;
         gxTv_SdtFilaProcessamento_Filaprocessamentoatualizacao_Z = sdt.gxTv_SdtFilaProcessamento_Filaprocessamentoatualizacao_Z ;
         gxTv_SdtFilaProcessamento_Filaprocessamentofuncao_N = sdt.gxTv_SdtFilaProcessamento_Filaprocessamentofuncao_N ;
         gxTv_SdtFilaProcessamento_Filaprocessamentoparametros_N = sdt.gxTv_SdtFilaProcessamento_Filaprocessamentoparametros_N ;
         gxTv_SdtFilaProcessamento_Filaprocessamentostatus_N = sdt.gxTv_SdtFilaProcessamento_Filaprocessamentostatus_N ;
         gxTv_SdtFilaProcessamento_Filaprocessamentocriacao_N = sdt.gxTv_SdtFilaProcessamento_Filaprocessamentocriacao_N ;
         gxTv_SdtFilaProcessamento_Filaprocessamentoatualizacao_N = sdt.gxTv_SdtFilaProcessamento_Filaprocessamentoatualizacao_N ;
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
         AddObjectProperty("FilaProcessamentoId", gxTv_SdtFilaProcessamento_Filaprocessamentoid, false, includeNonInitialized);
         AddObjectProperty("FilaProcessamentoFuncao", gxTv_SdtFilaProcessamento_Filaprocessamentofuncao, false, includeNonInitialized);
         AddObjectProperty("FilaProcessamentoFuncao_N", gxTv_SdtFilaProcessamento_Filaprocessamentofuncao_N, false, includeNonInitialized);
         AddObjectProperty("FilaProcessamentoParametros", gxTv_SdtFilaProcessamento_Filaprocessamentoparametros, false, includeNonInitialized);
         AddObjectProperty("FilaProcessamentoParametros_N", gxTv_SdtFilaProcessamento_Filaprocessamentoparametros_N, false, includeNonInitialized);
         AddObjectProperty("FilaProcessamentoStatus", gxTv_SdtFilaProcessamento_Filaprocessamentostatus, false, includeNonInitialized);
         AddObjectProperty("FilaProcessamentoStatus_N", gxTv_SdtFilaProcessamento_Filaprocessamentostatus_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtFilaProcessamento_Filaprocessamentocriacao;
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
         AddObjectProperty("FilaProcessamentoCriacao", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("FilaProcessamentoCriacao_N", gxTv_SdtFilaProcessamento_Filaprocessamentocriacao_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtFilaProcessamento_Filaprocessamentoatualizacao;
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
         AddObjectProperty("FilaProcessamentoAtualizacao", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("FilaProcessamentoAtualizacao_N", gxTv_SdtFilaProcessamento_Filaprocessamentoatualizacao_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtFilaProcessamento_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtFilaProcessamento_Initialized, false, includeNonInitialized);
            AddObjectProperty("FilaProcessamentoId_Z", gxTv_SdtFilaProcessamento_Filaprocessamentoid_Z, false, includeNonInitialized);
            AddObjectProperty("FilaProcessamentoFuncao_Z", gxTv_SdtFilaProcessamento_Filaprocessamentofuncao_Z, false, includeNonInitialized);
            AddObjectProperty("FilaProcessamentoStatus_Z", gxTv_SdtFilaProcessamento_Filaprocessamentostatus_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtFilaProcessamento_Filaprocessamentocriacao_Z;
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
            AddObjectProperty("FilaProcessamentoCriacao_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtFilaProcessamento_Filaprocessamentoatualizacao_Z;
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
            AddObjectProperty("FilaProcessamentoAtualizacao_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("FilaProcessamentoFuncao_N", gxTv_SdtFilaProcessamento_Filaprocessamentofuncao_N, false, includeNonInitialized);
            AddObjectProperty("FilaProcessamentoParametros_N", gxTv_SdtFilaProcessamento_Filaprocessamentoparametros_N, false, includeNonInitialized);
            AddObjectProperty("FilaProcessamentoStatus_N", gxTv_SdtFilaProcessamento_Filaprocessamentostatus_N, false, includeNonInitialized);
            AddObjectProperty("FilaProcessamentoCriacao_N", gxTv_SdtFilaProcessamento_Filaprocessamentocriacao_N, false, includeNonInitialized);
            AddObjectProperty("FilaProcessamentoAtualizacao_N", gxTv_SdtFilaProcessamento_Filaprocessamentoatualizacao_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtFilaProcessamento sdt )
      {
         if ( sdt.IsDirty("FilaProcessamentoId") )
         {
            sdtIsNull = 0;
            gxTv_SdtFilaProcessamento_Filaprocessamentoid = sdt.gxTv_SdtFilaProcessamento_Filaprocessamentoid ;
         }
         if ( sdt.IsDirty("FilaProcessamentoFuncao") )
         {
            gxTv_SdtFilaProcessamento_Filaprocessamentofuncao_N = (short)(sdt.gxTv_SdtFilaProcessamento_Filaprocessamentofuncao_N);
            sdtIsNull = 0;
            gxTv_SdtFilaProcessamento_Filaprocessamentofuncao = sdt.gxTv_SdtFilaProcessamento_Filaprocessamentofuncao ;
         }
         if ( sdt.IsDirty("FilaProcessamentoParametros") )
         {
            gxTv_SdtFilaProcessamento_Filaprocessamentoparametros_N = (short)(sdt.gxTv_SdtFilaProcessamento_Filaprocessamentoparametros_N);
            sdtIsNull = 0;
            gxTv_SdtFilaProcessamento_Filaprocessamentoparametros = sdt.gxTv_SdtFilaProcessamento_Filaprocessamentoparametros ;
         }
         if ( sdt.IsDirty("FilaProcessamentoStatus") )
         {
            gxTv_SdtFilaProcessamento_Filaprocessamentostatus_N = (short)(sdt.gxTv_SdtFilaProcessamento_Filaprocessamentostatus_N);
            sdtIsNull = 0;
            gxTv_SdtFilaProcessamento_Filaprocessamentostatus = sdt.gxTv_SdtFilaProcessamento_Filaprocessamentostatus ;
         }
         if ( sdt.IsDirty("FilaProcessamentoCriacao") )
         {
            gxTv_SdtFilaProcessamento_Filaprocessamentocriacao_N = (short)(sdt.gxTv_SdtFilaProcessamento_Filaprocessamentocriacao_N);
            sdtIsNull = 0;
            gxTv_SdtFilaProcessamento_Filaprocessamentocriacao = sdt.gxTv_SdtFilaProcessamento_Filaprocessamentocriacao ;
         }
         if ( sdt.IsDirty("FilaProcessamentoAtualizacao") )
         {
            gxTv_SdtFilaProcessamento_Filaprocessamentoatualizacao_N = (short)(sdt.gxTv_SdtFilaProcessamento_Filaprocessamentoatualizacao_N);
            sdtIsNull = 0;
            gxTv_SdtFilaProcessamento_Filaprocessamentoatualizacao = sdt.gxTv_SdtFilaProcessamento_Filaprocessamentoatualizacao ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "FilaProcessamentoId" )]
      [  XmlElement( ElementName = "FilaProcessamentoId"   )]
      public int gxTpr_Filaprocessamentoid
      {
         get {
            return gxTv_SdtFilaProcessamento_Filaprocessamentoid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtFilaProcessamento_Filaprocessamentoid != value )
            {
               gxTv_SdtFilaProcessamento_Mode = "INS";
               this.gxTv_SdtFilaProcessamento_Filaprocessamentoid_Z_SetNull( );
               this.gxTv_SdtFilaProcessamento_Filaprocessamentofuncao_Z_SetNull( );
               this.gxTv_SdtFilaProcessamento_Filaprocessamentostatus_Z_SetNull( );
               this.gxTv_SdtFilaProcessamento_Filaprocessamentocriacao_Z_SetNull( );
               this.gxTv_SdtFilaProcessamento_Filaprocessamentoatualizacao_Z_SetNull( );
            }
            gxTv_SdtFilaProcessamento_Filaprocessamentoid = value;
            SetDirty("Filaprocessamentoid");
         }

      }

      [  SoapElement( ElementName = "FilaProcessamentoFuncao" )]
      [  XmlElement( ElementName = "FilaProcessamentoFuncao"   )]
      public string gxTpr_Filaprocessamentofuncao
      {
         get {
            return gxTv_SdtFilaProcessamento_Filaprocessamentofuncao ;
         }

         set {
            gxTv_SdtFilaProcessamento_Filaprocessamentofuncao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtFilaProcessamento_Filaprocessamentofuncao = value;
            SetDirty("Filaprocessamentofuncao");
         }

      }

      public void gxTv_SdtFilaProcessamento_Filaprocessamentofuncao_SetNull( )
      {
         gxTv_SdtFilaProcessamento_Filaprocessamentofuncao_N = 1;
         gxTv_SdtFilaProcessamento_Filaprocessamentofuncao = "";
         SetDirty("Filaprocessamentofuncao");
         return  ;
      }

      public bool gxTv_SdtFilaProcessamento_Filaprocessamentofuncao_IsNull( )
      {
         return (gxTv_SdtFilaProcessamento_Filaprocessamentofuncao_N==1) ;
      }

      [  SoapElement( ElementName = "FilaProcessamentoParametros" )]
      [  XmlElement( ElementName = "FilaProcessamentoParametros"   )]
      public string gxTpr_Filaprocessamentoparametros
      {
         get {
            return gxTv_SdtFilaProcessamento_Filaprocessamentoparametros ;
         }

         set {
            gxTv_SdtFilaProcessamento_Filaprocessamentoparametros_N = 0;
            sdtIsNull = 0;
            gxTv_SdtFilaProcessamento_Filaprocessamentoparametros = value;
            SetDirty("Filaprocessamentoparametros");
         }

      }

      public void gxTv_SdtFilaProcessamento_Filaprocessamentoparametros_SetNull( )
      {
         gxTv_SdtFilaProcessamento_Filaprocessamentoparametros_N = 1;
         gxTv_SdtFilaProcessamento_Filaprocessamentoparametros = "";
         SetDirty("Filaprocessamentoparametros");
         return  ;
      }

      public bool gxTv_SdtFilaProcessamento_Filaprocessamentoparametros_IsNull( )
      {
         return (gxTv_SdtFilaProcessamento_Filaprocessamentoparametros_N==1) ;
      }

      [  SoapElement( ElementName = "FilaProcessamentoStatus" )]
      [  XmlElement( ElementName = "FilaProcessamentoStatus"   )]
      public string gxTpr_Filaprocessamentostatus
      {
         get {
            return gxTv_SdtFilaProcessamento_Filaprocessamentostatus ;
         }

         set {
            gxTv_SdtFilaProcessamento_Filaprocessamentostatus_N = 0;
            sdtIsNull = 0;
            gxTv_SdtFilaProcessamento_Filaprocessamentostatus = value;
            SetDirty("Filaprocessamentostatus");
         }

      }

      public void gxTv_SdtFilaProcessamento_Filaprocessamentostatus_SetNull( )
      {
         gxTv_SdtFilaProcessamento_Filaprocessamentostatus_N = 1;
         gxTv_SdtFilaProcessamento_Filaprocessamentostatus = "";
         SetDirty("Filaprocessamentostatus");
         return  ;
      }

      public bool gxTv_SdtFilaProcessamento_Filaprocessamentostatus_IsNull( )
      {
         return (gxTv_SdtFilaProcessamento_Filaprocessamentostatus_N==1) ;
      }

      [  SoapElement( ElementName = "FilaProcessamentoCriacao" )]
      [  XmlElement( ElementName = "FilaProcessamentoCriacao"  , IsNullable=true )]
      public string gxTpr_Filaprocessamentocriacao_Nullable
      {
         get {
            if ( gxTv_SdtFilaProcessamento_Filaprocessamentocriacao == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtFilaProcessamento_Filaprocessamentocriacao).value ;
         }

         set {
            gxTv_SdtFilaProcessamento_Filaprocessamentocriacao_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtFilaProcessamento_Filaprocessamentocriacao = DateTime.MinValue;
            else
               gxTv_SdtFilaProcessamento_Filaprocessamentocriacao = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Filaprocessamentocriacao
      {
         get {
            return gxTv_SdtFilaProcessamento_Filaprocessamentocriacao ;
         }

         set {
            gxTv_SdtFilaProcessamento_Filaprocessamentocriacao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtFilaProcessamento_Filaprocessamentocriacao = value;
            SetDirty("Filaprocessamentocriacao");
         }

      }

      public void gxTv_SdtFilaProcessamento_Filaprocessamentocriacao_SetNull( )
      {
         gxTv_SdtFilaProcessamento_Filaprocessamentocriacao_N = 1;
         gxTv_SdtFilaProcessamento_Filaprocessamentocriacao = (DateTime)(DateTime.MinValue);
         SetDirty("Filaprocessamentocriacao");
         return  ;
      }

      public bool gxTv_SdtFilaProcessamento_Filaprocessamentocriacao_IsNull( )
      {
         return (gxTv_SdtFilaProcessamento_Filaprocessamentocriacao_N==1) ;
      }

      [  SoapElement( ElementName = "FilaProcessamentoAtualizacao" )]
      [  XmlElement( ElementName = "FilaProcessamentoAtualizacao"  , IsNullable=true )]
      public string gxTpr_Filaprocessamentoatualizacao_Nullable
      {
         get {
            if ( gxTv_SdtFilaProcessamento_Filaprocessamentoatualizacao == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtFilaProcessamento_Filaprocessamentoatualizacao).value ;
         }

         set {
            gxTv_SdtFilaProcessamento_Filaprocessamentoatualizacao_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtFilaProcessamento_Filaprocessamentoatualizacao = DateTime.MinValue;
            else
               gxTv_SdtFilaProcessamento_Filaprocessamentoatualizacao = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Filaprocessamentoatualizacao
      {
         get {
            return gxTv_SdtFilaProcessamento_Filaprocessamentoatualizacao ;
         }

         set {
            gxTv_SdtFilaProcessamento_Filaprocessamentoatualizacao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtFilaProcessamento_Filaprocessamentoatualizacao = value;
            SetDirty("Filaprocessamentoatualizacao");
         }

      }

      public void gxTv_SdtFilaProcessamento_Filaprocessamentoatualizacao_SetNull( )
      {
         gxTv_SdtFilaProcessamento_Filaprocessamentoatualizacao_N = 1;
         gxTv_SdtFilaProcessamento_Filaprocessamentoatualizacao = (DateTime)(DateTime.MinValue);
         SetDirty("Filaprocessamentoatualizacao");
         return  ;
      }

      public bool gxTv_SdtFilaProcessamento_Filaprocessamentoatualizacao_IsNull( )
      {
         return (gxTv_SdtFilaProcessamento_Filaprocessamentoatualizacao_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtFilaProcessamento_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFilaProcessamento_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtFilaProcessamento_Mode_SetNull( )
      {
         gxTv_SdtFilaProcessamento_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtFilaProcessamento_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtFilaProcessamento_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFilaProcessamento_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtFilaProcessamento_Initialized_SetNull( )
      {
         gxTv_SdtFilaProcessamento_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtFilaProcessamento_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FilaProcessamentoId_Z" )]
      [  XmlElement( ElementName = "FilaProcessamentoId_Z"   )]
      public int gxTpr_Filaprocessamentoid_Z
      {
         get {
            return gxTv_SdtFilaProcessamento_Filaprocessamentoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFilaProcessamento_Filaprocessamentoid_Z = value;
            SetDirty("Filaprocessamentoid_Z");
         }

      }

      public void gxTv_SdtFilaProcessamento_Filaprocessamentoid_Z_SetNull( )
      {
         gxTv_SdtFilaProcessamento_Filaprocessamentoid_Z = 0;
         SetDirty("Filaprocessamentoid_Z");
         return  ;
      }

      public bool gxTv_SdtFilaProcessamento_Filaprocessamentoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FilaProcessamentoFuncao_Z" )]
      [  XmlElement( ElementName = "FilaProcessamentoFuncao_Z"   )]
      public string gxTpr_Filaprocessamentofuncao_Z
      {
         get {
            return gxTv_SdtFilaProcessamento_Filaprocessamentofuncao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFilaProcessamento_Filaprocessamentofuncao_Z = value;
            SetDirty("Filaprocessamentofuncao_Z");
         }

      }

      public void gxTv_SdtFilaProcessamento_Filaprocessamentofuncao_Z_SetNull( )
      {
         gxTv_SdtFilaProcessamento_Filaprocessamentofuncao_Z = "";
         SetDirty("Filaprocessamentofuncao_Z");
         return  ;
      }

      public bool gxTv_SdtFilaProcessamento_Filaprocessamentofuncao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FilaProcessamentoStatus_Z" )]
      [  XmlElement( ElementName = "FilaProcessamentoStatus_Z"   )]
      public string gxTpr_Filaprocessamentostatus_Z
      {
         get {
            return gxTv_SdtFilaProcessamento_Filaprocessamentostatus_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFilaProcessamento_Filaprocessamentostatus_Z = value;
            SetDirty("Filaprocessamentostatus_Z");
         }

      }

      public void gxTv_SdtFilaProcessamento_Filaprocessamentostatus_Z_SetNull( )
      {
         gxTv_SdtFilaProcessamento_Filaprocessamentostatus_Z = "";
         SetDirty("Filaprocessamentostatus_Z");
         return  ;
      }

      public bool gxTv_SdtFilaProcessamento_Filaprocessamentostatus_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FilaProcessamentoCriacao_Z" )]
      [  XmlElement( ElementName = "FilaProcessamentoCriacao_Z"  , IsNullable=true )]
      public string gxTpr_Filaprocessamentocriacao_Z_Nullable
      {
         get {
            if ( gxTv_SdtFilaProcessamento_Filaprocessamentocriacao_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtFilaProcessamento_Filaprocessamentocriacao_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtFilaProcessamento_Filaprocessamentocriacao_Z = DateTime.MinValue;
            else
               gxTv_SdtFilaProcessamento_Filaprocessamentocriacao_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Filaprocessamentocriacao_Z
      {
         get {
            return gxTv_SdtFilaProcessamento_Filaprocessamentocriacao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFilaProcessamento_Filaprocessamentocriacao_Z = value;
            SetDirty("Filaprocessamentocriacao_Z");
         }

      }

      public void gxTv_SdtFilaProcessamento_Filaprocessamentocriacao_Z_SetNull( )
      {
         gxTv_SdtFilaProcessamento_Filaprocessamentocriacao_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Filaprocessamentocriacao_Z");
         return  ;
      }

      public bool gxTv_SdtFilaProcessamento_Filaprocessamentocriacao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FilaProcessamentoAtualizacao_Z" )]
      [  XmlElement( ElementName = "FilaProcessamentoAtualizacao_Z"  , IsNullable=true )]
      public string gxTpr_Filaprocessamentoatualizacao_Z_Nullable
      {
         get {
            if ( gxTv_SdtFilaProcessamento_Filaprocessamentoatualizacao_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtFilaProcessamento_Filaprocessamentoatualizacao_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtFilaProcessamento_Filaprocessamentoatualizacao_Z = DateTime.MinValue;
            else
               gxTv_SdtFilaProcessamento_Filaprocessamentoatualizacao_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Filaprocessamentoatualizacao_Z
      {
         get {
            return gxTv_SdtFilaProcessamento_Filaprocessamentoatualizacao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFilaProcessamento_Filaprocessamentoatualizacao_Z = value;
            SetDirty("Filaprocessamentoatualizacao_Z");
         }

      }

      public void gxTv_SdtFilaProcessamento_Filaprocessamentoatualizacao_Z_SetNull( )
      {
         gxTv_SdtFilaProcessamento_Filaprocessamentoatualizacao_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Filaprocessamentoatualizacao_Z");
         return  ;
      }

      public bool gxTv_SdtFilaProcessamento_Filaprocessamentoatualizacao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FilaProcessamentoFuncao_N" )]
      [  XmlElement( ElementName = "FilaProcessamentoFuncao_N"   )]
      public short gxTpr_Filaprocessamentofuncao_N
      {
         get {
            return gxTv_SdtFilaProcessamento_Filaprocessamentofuncao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFilaProcessamento_Filaprocessamentofuncao_N = value;
            SetDirty("Filaprocessamentofuncao_N");
         }

      }

      public void gxTv_SdtFilaProcessamento_Filaprocessamentofuncao_N_SetNull( )
      {
         gxTv_SdtFilaProcessamento_Filaprocessamentofuncao_N = 0;
         SetDirty("Filaprocessamentofuncao_N");
         return  ;
      }

      public bool gxTv_SdtFilaProcessamento_Filaprocessamentofuncao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FilaProcessamentoParametros_N" )]
      [  XmlElement( ElementName = "FilaProcessamentoParametros_N"   )]
      public short gxTpr_Filaprocessamentoparametros_N
      {
         get {
            return gxTv_SdtFilaProcessamento_Filaprocessamentoparametros_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFilaProcessamento_Filaprocessamentoparametros_N = value;
            SetDirty("Filaprocessamentoparametros_N");
         }

      }

      public void gxTv_SdtFilaProcessamento_Filaprocessamentoparametros_N_SetNull( )
      {
         gxTv_SdtFilaProcessamento_Filaprocessamentoparametros_N = 0;
         SetDirty("Filaprocessamentoparametros_N");
         return  ;
      }

      public bool gxTv_SdtFilaProcessamento_Filaprocessamentoparametros_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FilaProcessamentoStatus_N" )]
      [  XmlElement( ElementName = "FilaProcessamentoStatus_N"   )]
      public short gxTpr_Filaprocessamentostatus_N
      {
         get {
            return gxTv_SdtFilaProcessamento_Filaprocessamentostatus_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFilaProcessamento_Filaprocessamentostatus_N = value;
            SetDirty("Filaprocessamentostatus_N");
         }

      }

      public void gxTv_SdtFilaProcessamento_Filaprocessamentostatus_N_SetNull( )
      {
         gxTv_SdtFilaProcessamento_Filaprocessamentostatus_N = 0;
         SetDirty("Filaprocessamentostatus_N");
         return  ;
      }

      public bool gxTv_SdtFilaProcessamento_Filaprocessamentostatus_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FilaProcessamentoCriacao_N" )]
      [  XmlElement( ElementName = "FilaProcessamentoCriacao_N"   )]
      public short gxTpr_Filaprocessamentocriacao_N
      {
         get {
            return gxTv_SdtFilaProcessamento_Filaprocessamentocriacao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFilaProcessamento_Filaprocessamentocriacao_N = value;
            SetDirty("Filaprocessamentocriacao_N");
         }

      }

      public void gxTv_SdtFilaProcessamento_Filaprocessamentocriacao_N_SetNull( )
      {
         gxTv_SdtFilaProcessamento_Filaprocessamentocriacao_N = 0;
         SetDirty("Filaprocessamentocriacao_N");
         return  ;
      }

      public bool gxTv_SdtFilaProcessamento_Filaprocessamentocriacao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FilaProcessamentoAtualizacao_N" )]
      [  XmlElement( ElementName = "FilaProcessamentoAtualizacao_N"   )]
      public short gxTpr_Filaprocessamentoatualizacao_N
      {
         get {
            return gxTv_SdtFilaProcessamento_Filaprocessamentoatualizacao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFilaProcessamento_Filaprocessamentoatualizacao_N = value;
            SetDirty("Filaprocessamentoatualizacao_N");
         }

      }

      public void gxTv_SdtFilaProcessamento_Filaprocessamentoatualizacao_N_SetNull( )
      {
         gxTv_SdtFilaProcessamento_Filaprocessamentoatualizacao_N = 0;
         SetDirty("Filaprocessamentoatualizacao_N");
         return  ;
      }

      public bool gxTv_SdtFilaProcessamento_Filaprocessamentoatualizacao_N_IsNull( )
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
         gxTv_SdtFilaProcessamento_Filaprocessamentofuncao = "";
         gxTv_SdtFilaProcessamento_Filaprocessamentoparametros = "";
         gxTv_SdtFilaProcessamento_Filaprocessamentostatus = "";
         gxTv_SdtFilaProcessamento_Filaprocessamentocriacao = (DateTime)(DateTime.MinValue);
         gxTv_SdtFilaProcessamento_Filaprocessamentoatualizacao = (DateTime)(DateTime.MinValue);
         gxTv_SdtFilaProcessamento_Mode = "";
         gxTv_SdtFilaProcessamento_Filaprocessamentofuncao_Z = "";
         gxTv_SdtFilaProcessamento_Filaprocessamentostatus_Z = "";
         gxTv_SdtFilaProcessamento_Filaprocessamentocriacao_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtFilaProcessamento_Filaprocessamentoatualizacao_Z = (DateTime)(DateTime.MinValue);
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "filaprocessamento", "GeneXus.Programs.filaprocessamento_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtFilaProcessamento_Initialized ;
      private short gxTv_SdtFilaProcessamento_Filaprocessamentofuncao_N ;
      private short gxTv_SdtFilaProcessamento_Filaprocessamentoparametros_N ;
      private short gxTv_SdtFilaProcessamento_Filaprocessamentostatus_N ;
      private short gxTv_SdtFilaProcessamento_Filaprocessamentocriacao_N ;
      private short gxTv_SdtFilaProcessamento_Filaprocessamentoatualizacao_N ;
      private int gxTv_SdtFilaProcessamento_Filaprocessamentoid ;
      private int gxTv_SdtFilaProcessamento_Filaprocessamentoid_Z ;
      private string gxTv_SdtFilaProcessamento_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtFilaProcessamento_Filaprocessamentocriacao ;
      private DateTime gxTv_SdtFilaProcessamento_Filaprocessamentoatualizacao ;
      private DateTime gxTv_SdtFilaProcessamento_Filaprocessamentocriacao_Z ;
      private DateTime gxTv_SdtFilaProcessamento_Filaprocessamentoatualizacao_Z ;
      private DateTime datetime_STZ ;
      private string gxTv_SdtFilaProcessamento_Filaprocessamentoparametros ;
      private string gxTv_SdtFilaProcessamento_Filaprocessamentofuncao ;
      private string gxTv_SdtFilaProcessamento_Filaprocessamentostatus ;
      private string gxTv_SdtFilaProcessamento_Filaprocessamentofuncao_Z ;
      private string gxTv_SdtFilaProcessamento_Filaprocessamentostatus_Z ;
   }

   [DataContract(Name = @"FilaProcessamento", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtFilaProcessamento_RESTInterface : GxGenericCollectionItem<SdtFilaProcessamento>
   {
      public SdtFilaProcessamento_RESTInterface( ) : base()
      {
      }

      public SdtFilaProcessamento_RESTInterface( SdtFilaProcessamento psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "FilaProcessamentoId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Filaprocessamentoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Filaprocessamentoid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Filaprocessamentoid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "FilaProcessamentoFuncao" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Filaprocessamentofuncao
      {
         get {
            return sdt.gxTpr_Filaprocessamentofuncao ;
         }

         set {
            sdt.gxTpr_Filaprocessamentofuncao = value;
         }

      }

      [DataMember( Name = "FilaProcessamentoParametros" , Order = 2 )]
      public string gxTpr_Filaprocessamentoparametros
      {
         get {
            return sdt.gxTpr_Filaprocessamentoparametros ;
         }

         set {
            sdt.gxTpr_Filaprocessamentoparametros = value;
         }

      }

      [DataMember( Name = "FilaProcessamentoStatus" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Filaprocessamentostatus
      {
         get {
            return sdt.gxTpr_Filaprocessamentostatus ;
         }

         set {
            sdt.gxTpr_Filaprocessamentostatus = value;
         }

      }

      [DataMember( Name = "FilaProcessamentoCriacao" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Filaprocessamentocriacao
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Filaprocessamentocriacao, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Filaprocessamentocriacao = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "FilaProcessamentoAtualizacao" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Filaprocessamentoatualizacao
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Filaprocessamentoatualizacao, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Filaprocessamentoatualizacao = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      public SdtFilaProcessamento sdt
      {
         get {
            return (SdtFilaProcessamento)Sdt ;
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
            sdt = new SdtFilaProcessamento() ;
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

   [DataContract(Name = @"FilaProcessamento", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtFilaProcessamento_RESTLInterface : GxGenericCollectionItem<SdtFilaProcessamento>
   {
      public SdtFilaProcessamento_RESTLInterface( ) : base()
      {
      }

      public SdtFilaProcessamento_RESTLInterface( SdtFilaProcessamento psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "FilaProcessamentoFuncao" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Filaprocessamentofuncao
      {
         get {
            return sdt.gxTpr_Filaprocessamentofuncao ;
         }

         set {
            sdt.gxTpr_Filaprocessamentofuncao = value;
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

      public SdtFilaProcessamento sdt
      {
         get {
            return (SdtFilaProcessamento)Sdt ;
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
            sdt = new SdtFilaProcessamento() ;
         }
      }

   }

}
