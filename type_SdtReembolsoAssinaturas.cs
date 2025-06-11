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
   [XmlRoot(ElementName = "ReembolsoAssinaturas" )]
   [XmlType(TypeName =  "ReembolsoAssinaturas" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtReembolsoAssinaturas : GxSilentTrnSdt
   {
      public SdtReembolsoAssinaturas( )
      {
      }

      public SdtReembolsoAssinaturas( IGxContext context )
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

      public void Load( int AV631ReembolsoAssinaturasId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV631ReembolsoAssinaturasId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ReembolsoAssinaturasId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "ReembolsoAssinaturas");
         metadata.Set("BT", "ReembolsoAssinaturas");
         metadata.Set("PK", "[ \"ReembolsoAssinaturasId\" ]");
         metadata.Set("PKAssigned", "[ \"ReembolsoAssinaturasId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"PropostaContratoAssinaturaId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"ReembolsoId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Reembolsoassinaturasid_Z");
         state.Add("gxTpr_Reembolsoid_Z");
         state.Add("gxTpr_Propostacontratoassinaturaid_Z");
         state.Add("gxTpr_Propostaassinatura_Z");
         state.Add("gxTpr_Reembolsoassinaturasnome_Z");
         state.Add("gxTpr_Reembolsoassinaturasemissao_Z_Nullable");
         state.Add("gxTpr_Reembolsoid_N");
         state.Add("gxTpr_Propostacontratoassinaturaid_N");
         state.Add("gxTpr_Propostaassinatura_N");
         state.Add("gxTpr_Reembolsoassinaturasnome_N");
         state.Add("gxTpr_Reembolsoassinaturasemissao_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtReembolsoAssinaturas sdt;
         sdt = (SdtReembolsoAssinaturas)(source);
         gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasid = sdt.gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasid ;
         gxTv_SdtReembolsoAssinaturas_Reembolsoid = sdt.gxTv_SdtReembolsoAssinaturas_Reembolsoid ;
         gxTv_SdtReembolsoAssinaturas_Propostacontratoassinaturaid = sdt.gxTv_SdtReembolsoAssinaturas_Propostacontratoassinaturaid ;
         gxTv_SdtReembolsoAssinaturas_Propostaassinatura = sdt.gxTv_SdtReembolsoAssinaturas_Propostaassinatura ;
         gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasnome = sdt.gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasnome ;
         gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasemissao = sdt.gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasemissao ;
         gxTv_SdtReembolsoAssinaturas_Mode = sdt.gxTv_SdtReembolsoAssinaturas_Mode ;
         gxTv_SdtReembolsoAssinaturas_Initialized = sdt.gxTv_SdtReembolsoAssinaturas_Initialized ;
         gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasid_Z = sdt.gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasid_Z ;
         gxTv_SdtReembolsoAssinaturas_Reembolsoid_Z = sdt.gxTv_SdtReembolsoAssinaturas_Reembolsoid_Z ;
         gxTv_SdtReembolsoAssinaturas_Propostacontratoassinaturaid_Z = sdt.gxTv_SdtReembolsoAssinaturas_Propostacontratoassinaturaid_Z ;
         gxTv_SdtReembolsoAssinaturas_Propostaassinatura_Z = sdt.gxTv_SdtReembolsoAssinaturas_Propostaassinatura_Z ;
         gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasnome_Z = sdt.gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasnome_Z ;
         gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasemissao_Z = sdt.gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasemissao_Z ;
         gxTv_SdtReembolsoAssinaturas_Reembolsoid_N = sdt.gxTv_SdtReembolsoAssinaturas_Reembolsoid_N ;
         gxTv_SdtReembolsoAssinaturas_Propostacontratoassinaturaid_N = sdt.gxTv_SdtReembolsoAssinaturas_Propostacontratoassinaturaid_N ;
         gxTv_SdtReembolsoAssinaturas_Propostaassinatura_N = sdt.gxTv_SdtReembolsoAssinaturas_Propostaassinatura_N ;
         gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasnome_N = sdt.gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasnome_N ;
         gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasemissao_N = sdt.gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasemissao_N ;
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
         AddObjectProperty("ReembolsoAssinaturasId", gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasid, false, includeNonInitialized);
         AddObjectProperty("ReembolsoId", gxTv_SdtReembolsoAssinaturas_Reembolsoid, false, includeNonInitialized);
         AddObjectProperty("ReembolsoId_N", gxTv_SdtReembolsoAssinaturas_Reembolsoid_N, false, includeNonInitialized);
         AddObjectProperty("PropostaContratoAssinaturaId", gxTv_SdtReembolsoAssinaturas_Propostacontratoassinaturaid, false, includeNonInitialized);
         AddObjectProperty("PropostaContratoAssinaturaId_N", gxTv_SdtReembolsoAssinaturas_Propostacontratoassinaturaid_N, false, includeNonInitialized);
         AddObjectProperty("PropostaAssinatura", gxTv_SdtReembolsoAssinaturas_Propostaassinatura, false, includeNonInitialized);
         AddObjectProperty("PropostaAssinatura_N", gxTv_SdtReembolsoAssinaturas_Propostaassinatura_N, false, includeNonInitialized);
         AddObjectProperty("ReembolsoAssinaturasNome", gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasnome, false, includeNonInitialized);
         AddObjectProperty("ReembolsoAssinaturasNome_N", gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasnome_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasemissao;
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
         AddObjectProperty("ReembolsoAssinaturasEmissao", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("ReembolsoAssinaturasEmissao_N", gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasemissao_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtReembolsoAssinaturas_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtReembolsoAssinaturas_Initialized, false, includeNonInitialized);
            AddObjectProperty("ReembolsoAssinaturasId_Z", gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasid_Z, false, includeNonInitialized);
            AddObjectProperty("ReembolsoId_Z", gxTv_SdtReembolsoAssinaturas_Reembolsoid_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaContratoAssinaturaId_Z", gxTv_SdtReembolsoAssinaturas_Propostacontratoassinaturaid_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaAssinatura_Z", gxTv_SdtReembolsoAssinaturas_Propostaassinatura_Z, false, includeNonInitialized);
            AddObjectProperty("ReembolsoAssinaturasNome_Z", gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasnome_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasemissao_Z;
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
            AddObjectProperty("ReembolsoAssinaturasEmissao_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("ReembolsoId_N", gxTv_SdtReembolsoAssinaturas_Reembolsoid_N, false, includeNonInitialized);
            AddObjectProperty("PropostaContratoAssinaturaId_N", gxTv_SdtReembolsoAssinaturas_Propostacontratoassinaturaid_N, false, includeNonInitialized);
            AddObjectProperty("PropostaAssinatura_N", gxTv_SdtReembolsoAssinaturas_Propostaassinatura_N, false, includeNonInitialized);
            AddObjectProperty("ReembolsoAssinaturasNome_N", gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasnome_N, false, includeNonInitialized);
            AddObjectProperty("ReembolsoAssinaturasEmissao_N", gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasemissao_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtReembolsoAssinaturas sdt )
      {
         if ( sdt.IsDirty("ReembolsoAssinaturasId") )
         {
            sdtIsNull = 0;
            gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasid = sdt.gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasid ;
         }
         if ( sdt.IsDirty("ReembolsoId") )
         {
            gxTv_SdtReembolsoAssinaturas_Reembolsoid_N = (short)(sdt.gxTv_SdtReembolsoAssinaturas_Reembolsoid_N);
            sdtIsNull = 0;
            gxTv_SdtReembolsoAssinaturas_Reembolsoid = sdt.gxTv_SdtReembolsoAssinaturas_Reembolsoid ;
         }
         if ( sdt.IsDirty("PropostaContratoAssinaturaId") )
         {
            gxTv_SdtReembolsoAssinaturas_Propostacontratoassinaturaid_N = (short)(sdt.gxTv_SdtReembolsoAssinaturas_Propostacontratoassinaturaid_N);
            sdtIsNull = 0;
            gxTv_SdtReembolsoAssinaturas_Propostacontratoassinaturaid = sdt.gxTv_SdtReembolsoAssinaturas_Propostacontratoassinaturaid ;
         }
         if ( sdt.IsDirty("PropostaAssinatura") )
         {
            gxTv_SdtReembolsoAssinaturas_Propostaassinatura_N = (short)(sdt.gxTv_SdtReembolsoAssinaturas_Propostaassinatura_N);
            sdtIsNull = 0;
            gxTv_SdtReembolsoAssinaturas_Propostaassinatura = sdt.gxTv_SdtReembolsoAssinaturas_Propostaassinatura ;
         }
         if ( sdt.IsDirty("ReembolsoAssinaturasNome") )
         {
            gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasnome_N = (short)(sdt.gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasnome_N);
            sdtIsNull = 0;
            gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasnome = sdt.gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasnome ;
         }
         if ( sdt.IsDirty("ReembolsoAssinaturasEmissao") )
         {
            gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasemissao_N = (short)(sdt.gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasemissao_N);
            sdtIsNull = 0;
            gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasemissao = sdt.gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasemissao ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ReembolsoAssinaturasId" )]
      [  XmlElement( ElementName = "ReembolsoAssinaturasId"   )]
      public int gxTpr_Reembolsoassinaturasid
      {
         get {
            return gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasid != value )
            {
               gxTv_SdtReembolsoAssinaturas_Mode = "INS";
               this.gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasid_Z_SetNull( );
               this.gxTv_SdtReembolsoAssinaturas_Reembolsoid_Z_SetNull( );
               this.gxTv_SdtReembolsoAssinaturas_Propostacontratoassinaturaid_Z_SetNull( );
               this.gxTv_SdtReembolsoAssinaturas_Propostaassinatura_Z_SetNull( );
               this.gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasnome_Z_SetNull( );
               this.gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasemissao_Z_SetNull( );
            }
            gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasid = value;
            SetDirty("Reembolsoassinaturasid");
         }

      }

      [  SoapElement( ElementName = "ReembolsoId" )]
      [  XmlElement( ElementName = "ReembolsoId"   )]
      public int gxTpr_Reembolsoid
      {
         get {
            return gxTv_SdtReembolsoAssinaturas_Reembolsoid ;
         }

         set {
            gxTv_SdtReembolsoAssinaturas_Reembolsoid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtReembolsoAssinaturas_Reembolsoid = value;
            SetDirty("Reembolsoid");
         }

      }

      public void gxTv_SdtReembolsoAssinaturas_Reembolsoid_SetNull( )
      {
         gxTv_SdtReembolsoAssinaturas_Reembolsoid_N = 1;
         gxTv_SdtReembolsoAssinaturas_Reembolsoid = 0;
         SetDirty("Reembolsoid");
         return  ;
      }

      public bool gxTv_SdtReembolsoAssinaturas_Reembolsoid_IsNull( )
      {
         return (gxTv_SdtReembolsoAssinaturas_Reembolsoid_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaContratoAssinaturaId" )]
      [  XmlElement( ElementName = "PropostaContratoAssinaturaId"   )]
      public int gxTpr_Propostacontratoassinaturaid
      {
         get {
            return gxTv_SdtReembolsoAssinaturas_Propostacontratoassinaturaid ;
         }

         set {
            gxTv_SdtReembolsoAssinaturas_Propostacontratoassinaturaid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtReembolsoAssinaturas_Propostacontratoassinaturaid = value;
            SetDirty("Propostacontratoassinaturaid");
         }

      }

      public void gxTv_SdtReembolsoAssinaturas_Propostacontratoassinaturaid_SetNull( )
      {
         gxTv_SdtReembolsoAssinaturas_Propostacontratoassinaturaid_N = 1;
         gxTv_SdtReembolsoAssinaturas_Propostacontratoassinaturaid = 0;
         SetDirty("Propostacontratoassinaturaid");
         return  ;
      }

      public bool gxTv_SdtReembolsoAssinaturas_Propostacontratoassinaturaid_IsNull( )
      {
         return (gxTv_SdtReembolsoAssinaturas_Propostacontratoassinaturaid_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaAssinatura" )]
      [  XmlElement( ElementName = "PropostaAssinatura"   )]
      public long gxTpr_Propostaassinatura
      {
         get {
            return gxTv_SdtReembolsoAssinaturas_Propostaassinatura ;
         }

         set {
            gxTv_SdtReembolsoAssinaturas_Propostaassinatura_N = 0;
            sdtIsNull = 0;
            gxTv_SdtReembolsoAssinaturas_Propostaassinatura = value;
            SetDirty("Propostaassinatura");
         }

      }

      public void gxTv_SdtReembolsoAssinaturas_Propostaassinatura_SetNull( )
      {
         gxTv_SdtReembolsoAssinaturas_Propostaassinatura_N = 1;
         gxTv_SdtReembolsoAssinaturas_Propostaassinatura = 0;
         SetDirty("Propostaassinatura");
         return  ;
      }

      public bool gxTv_SdtReembolsoAssinaturas_Propostaassinatura_IsNull( )
      {
         return (gxTv_SdtReembolsoAssinaturas_Propostaassinatura_N==1) ;
      }

      [  SoapElement( ElementName = "ReembolsoAssinaturasNome" )]
      [  XmlElement( ElementName = "ReembolsoAssinaturasNome"   )]
      public string gxTpr_Reembolsoassinaturasnome
      {
         get {
            return gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasnome ;
         }

         set {
            gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasnome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasnome = value;
            SetDirty("Reembolsoassinaturasnome");
         }

      }

      public void gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasnome_SetNull( )
      {
         gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasnome_N = 1;
         gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasnome = "";
         SetDirty("Reembolsoassinaturasnome");
         return  ;
      }

      public bool gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasnome_IsNull( )
      {
         return (gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasnome_N==1) ;
      }

      [  SoapElement( ElementName = "ReembolsoAssinaturasEmissao" )]
      [  XmlElement( ElementName = "ReembolsoAssinaturasEmissao"  , IsNullable=true )]
      public string gxTpr_Reembolsoassinaturasemissao_Nullable
      {
         get {
            if ( gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasemissao == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasemissao).value ;
         }

         set {
            gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasemissao_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasemissao = DateTime.MinValue;
            else
               gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasemissao = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Reembolsoassinaturasemissao
      {
         get {
            return gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasemissao ;
         }

         set {
            gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasemissao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasemissao = value;
            SetDirty("Reembolsoassinaturasemissao");
         }

      }

      public void gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasemissao_SetNull( )
      {
         gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasemissao_N = 1;
         gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasemissao = (DateTime)(DateTime.MinValue);
         SetDirty("Reembolsoassinaturasemissao");
         return  ;
      }

      public bool gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasemissao_IsNull( )
      {
         return (gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasemissao_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtReembolsoAssinaturas_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoAssinaturas_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtReembolsoAssinaturas_Mode_SetNull( )
      {
         gxTv_SdtReembolsoAssinaturas_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtReembolsoAssinaturas_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtReembolsoAssinaturas_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoAssinaturas_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtReembolsoAssinaturas_Initialized_SetNull( )
      {
         gxTv_SdtReembolsoAssinaturas_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtReembolsoAssinaturas_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoAssinaturasId_Z" )]
      [  XmlElement( ElementName = "ReembolsoAssinaturasId_Z"   )]
      public int gxTpr_Reembolsoassinaturasid_Z
      {
         get {
            return gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasid_Z = value;
            SetDirty("Reembolsoassinaturasid_Z");
         }

      }

      public void gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasid_Z_SetNull( )
      {
         gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasid_Z = 0;
         SetDirty("Reembolsoassinaturasid_Z");
         return  ;
      }

      public bool gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoId_Z" )]
      [  XmlElement( ElementName = "ReembolsoId_Z"   )]
      public int gxTpr_Reembolsoid_Z
      {
         get {
            return gxTv_SdtReembolsoAssinaturas_Reembolsoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoAssinaturas_Reembolsoid_Z = value;
            SetDirty("Reembolsoid_Z");
         }

      }

      public void gxTv_SdtReembolsoAssinaturas_Reembolsoid_Z_SetNull( )
      {
         gxTv_SdtReembolsoAssinaturas_Reembolsoid_Z = 0;
         SetDirty("Reembolsoid_Z");
         return  ;
      }

      public bool gxTv_SdtReembolsoAssinaturas_Reembolsoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaContratoAssinaturaId_Z" )]
      [  XmlElement( ElementName = "PropostaContratoAssinaturaId_Z"   )]
      public int gxTpr_Propostacontratoassinaturaid_Z
      {
         get {
            return gxTv_SdtReembolsoAssinaturas_Propostacontratoassinaturaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoAssinaturas_Propostacontratoassinaturaid_Z = value;
            SetDirty("Propostacontratoassinaturaid_Z");
         }

      }

      public void gxTv_SdtReembolsoAssinaturas_Propostacontratoassinaturaid_Z_SetNull( )
      {
         gxTv_SdtReembolsoAssinaturas_Propostacontratoassinaturaid_Z = 0;
         SetDirty("Propostacontratoassinaturaid_Z");
         return  ;
      }

      public bool gxTv_SdtReembolsoAssinaturas_Propostacontratoassinaturaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaAssinatura_Z" )]
      [  XmlElement( ElementName = "PropostaAssinatura_Z"   )]
      public long gxTpr_Propostaassinatura_Z
      {
         get {
            return gxTv_SdtReembolsoAssinaturas_Propostaassinatura_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoAssinaturas_Propostaassinatura_Z = value;
            SetDirty("Propostaassinatura_Z");
         }

      }

      public void gxTv_SdtReembolsoAssinaturas_Propostaassinatura_Z_SetNull( )
      {
         gxTv_SdtReembolsoAssinaturas_Propostaassinatura_Z = 0;
         SetDirty("Propostaassinatura_Z");
         return  ;
      }

      public bool gxTv_SdtReembolsoAssinaturas_Propostaassinatura_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoAssinaturasNome_Z" )]
      [  XmlElement( ElementName = "ReembolsoAssinaturasNome_Z"   )]
      public string gxTpr_Reembolsoassinaturasnome_Z
      {
         get {
            return gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasnome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasnome_Z = value;
            SetDirty("Reembolsoassinaturasnome_Z");
         }

      }

      public void gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasnome_Z_SetNull( )
      {
         gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasnome_Z = "";
         SetDirty("Reembolsoassinaturasnome_Z");
         return  ;
      }

      public bool gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasnome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoAssinaturasEmissao_Z" )]
      [  XmlElement( ElementName = "ReembolsoAssinaturasEmissao_Z"  , IsNullable=true )]
      public string gxTpr_Reembolsoassinaturasemissao_Z_Nullable
      {
         get {
            if ( gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasemissao_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasemissao_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasemissao_Z = DateTime.MinValue;
            else
               gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasemissao_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Reembolsoassinaturasemissao_Z
      {
         get {
            return gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasemissao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasemissao_Z = value;
            SetDirty("Reembolsoassinaturasemissao_Z");
         }

      }

      public void gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasemissao_Z_SetNull( )
      {
         gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasemissao_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Reembolsoassinaturasemissao_Z");
         return  ;
      }

      public bool gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasemissao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoId_N" )]
      [  XmlElement( ElementName = "ReembolsoId_N"   )]
      public short gxTpr_Reembolsoid_N
      {
         get {
            return gxTv_SdtReembolsoAssinaturas_Reembolsoid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoAssinaturas_Reembolsoid_N = value;
            SetDirty("Reembolsoid_N");
         }

      }

      public void gxTv_SdtReembolsoAssinaturas_Reembolsoid_N_SetNull( )
      {
         gxTv_SdtReembolsoAssinaturas_Reembolsoid_N = 0;
         SetDirty("Reembolsoid_N");
         return  ;
      }

      public bool gxTv_SdtReembolsoAssinaturas_Reembolsoid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaContratoAssinaturaId_N" )]
      [  XmlElement( ElementName = "PropostaContratoAssinaturaId_N"   )]
      public short gxTpr_Propostacontratoassinaturaid_N
      {
         get {
            return gxTv_SdtReembolsoAssinaturas_Propostacontratoassinaturaid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoAssinaturas_Propostacontratoassinaturaid_N = value;
            SetDirty("Propostacontratoassinaturaid_N");
         }

      }

      public void gxTv_SdtReembolsoAssinaturas_Propostacontratoassinaturaid_N_SetNull( )
      {
         gxTv_SdtReembolsoAssinaturas_Propostacontratoassinaturaid_N = 0;
         SetDirty("Propostacontratoassinaturaid_N");
         return  ;
      }

      public bool gxTv_SdtReembolsoAssinaturas_Propostacontratoassinaturaid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaAssinatura_N" )]
      [  XmlElement( ElementName = "PropostaAssinatura_N"   )]
      public short gxTpr_Propostaassinatura_N
      {
         get {
            return gxTv_SdtReembolsoAssinaturas_Propostaassinatura_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoAssinaturas_Propostaassinatura_N = value;
            SetDirty("Propostaassinatura_N");
         }

      }

      public void gxTv_SdtReembolsoAssinaturas_Propostaassinatura_N_SetNull( )
      {
         gxTv_SdtReembolsoAssinaturas_Propostaassinatura_N = 0;
         SetDirty("Propostaassinatura_N");
         return  ;
      }

      public bool gxTv_SdtReembolsoAssinaturas_Propostaassinatura_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoAssinaturasNome_N" )]
      [  XmlElement( ElementName = "ReembolsoAssinaturasNome_N"   )]
      public short gxTpr_Reembolsoassinaturasnome_N
      {
         get {
            return gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasnome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasnome_N = value;
            SetDirty("Reembolsoassinaturasnome_N");
         }

      }

      public void gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasnome_N_SetNull( )
      {
         gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasnome_N = 0;
         SetDirty("Reembolsoassinaturasnome_N");
         return  ;
      }

      public bool gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasnome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoAssinaturasEmissao_N" )]
      [  XmlElement( ElementName = "ReembolsoAssinaturasEmissao_N"   )]
      public short gxTpr_Reembolsoassinaturasemissao_N
      {
         get {
            return gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasemissao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasemissao_N = value;
            SetDirty("Reembolsoassinaturasemissao_N");
         }

      }

      public void gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasemissao_N_SetNull( )
      {
         gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasemissao_N = 0;
         SetDirty("Reembolsoassinaturasemissao_N");
         return  ;
      }

      public bool gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasemissao_N_IsNull( )
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
         gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasnome = "";
         gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasemissao = (DateTime)(DateTime.MinValue);
         gxTv_SdtReembolsoAssinaturas_Mode = "";
         gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasnome_Z = "";
         gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasemissao_Z = (DateTime)(DateTime.MinValue);
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "reembolsoassinaturas", "GeneXus.Programs.reembolsoassinaturas_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtReembolsoAssinaturas_Initialized ;
      private short gxTv_SdtReembolsoAssinaturas_Reembolsoid_N ;
      private short gxTv_SdtReembolsoAssinaturas_Propostacontratoassinaturaid_N ;
      private short gxTv_SdtReembolsoAssinaturas_Propostaassinatura_N ;
      private short gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasnome_N ;
      private short gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasemissao_N ;
      private int gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasid ;
      private int gxTv_SdtReembolsoAssinaturas_Reembolsoid ;
      private int gxTv_SdtReembolsoAssinaturas_Propostacontratoassinaturaid ;
      private int gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasid_Z ;
      private int gxTv_SdtReembolsoAssinaturas_Reembolsoid_Z ;
      private int gxTv_SdtReembolsoAssinaturas_Propostacontratoassinaturaid_Z ;
      private long gxTv_SdtReembolsoAssinaturas_Propostaassinatura ;
      private long gxTv_SdtReembolsoAssinaturas_Propostaassinatura_Z ;
      private string gxTv_SdtReembolsoAssinaturas_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasemissao ;
      private DateTime gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasemissao_Z ;
      private DateTime datetime_STZ ;
      private string gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasnome ;
      private string gxTv_SdtReembolsoAssinaturas_Reembolsoassinaturasnome_Z ;
   }

   [DataContract(Name = @"ReembolsoAssinaturas", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtReembolsoAssinaturas_RESTInterface : GxGenericCollectionItem<SdtReembolsoAssinaturas>
   {
      public SdtReembolsoAssinaturas_RESTInterface( ) : base()
      {
      }

      public SdtReembolsoAssinaturas_RESTInterface( SdtReembolsoAssinaturas psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ReembolsoAssinaturasId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Reembolsoassinaturasid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Reembolsoassinaturasid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Reembolsoassinaturasid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ReembolsoId" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Reembolsoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Reembolsoid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Reembolsoid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "PropostaContratoAssinaturaId" , Order = 2 )]
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

      [DataMember( Name = "ReembolsoAssinaturasNome" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Reembolsoassinaturasnome
      {
         get {
            return sdt.gxTpr_Reembolsoassinaturasnome ;
         }

         set {
            sdt.gxTpr_Reembolsoassinaturasnome = value;
         }

      }

      [DataMember( Name = "ReembolsoAssinaturasEmissao" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Reembolsoassinaturasemissao
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Reembolsoassinaturasemissao, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Reembolsoassinaturasemissao = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      public SdtReembolsoAssinaturas sdt
      {
         get {
            return (SdtReembolsoAssinaturas)Sdt ;
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
            sdt = new SdtReembolsoAssinaturas() ;
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

   [DataContract(Name = @"ReembolsoAssinaturas", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtReembolsoAssinaturas_RESTLInterface : GxGenericCollectionItem<SdtReembolsoAssinaturas>
   {
      public SdtReembolsoAssinaturas_RESTLInterface( ) : base()
      {
      }

      public SdtReembolsoAssinaturas_RESTLInterface( SdtReembolsoAssinaturas psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ReembolsoAssinaturasNome" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Reembolsoassinaturasnome
      {
         get {
            return sdt.gxTpr_Reembolsoassinaturasnome ;
         }

         set {
            sdt.gxTpr_Reembolsoassinaturasnome = value;
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

      public SdtReembolsoAssinaturas sdt
      {
         get {
            return (SdtReembolsoAssinaturas)Sdt ;
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
            sdt = new SdtReembolsoAssinaturas() ;
         }
      }

   }

}
