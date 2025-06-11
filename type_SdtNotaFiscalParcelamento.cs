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
   [XmlRoot(ElementName = "NotaFiscalParcelamento" )]
   [XmlType(TypeName =  "NotaFiscalParcelamento" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtNotaFiscalParcelamento : GxSilentTrnSdt
   {
      public SdtNotaFiscalParcelamento( )
      {
      }

      public SdtNotaFiscalParcelamento( IGxContext context )
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

      public void Load( Guid AV890NotaFiscalParcelamentoID )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV890NotaFiscalParcelamentoID});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"NotaFiscalParcelamentoID", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "NotaFiscalParcelamento");
         metadata.Set("BT", "NotaFiscalParcelamento");
         metadata.Set("PK", "[ \"NotaFiscalParcelamentoID\" ]");
         metadata.Set("PKAssigned", "[ \"NotaFiscalParcelamentoID\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"NotaFiscalId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Notafiscalparcelamentoid_Z");
         state.Add("gxTpr_Notafiscalid_Z");
         state.Add("gxTpr_Notafiscalnumero_Z");
         state.Add("gxTpr_Notafiscalparcelamentonumero_Z");
         state.Add("gxTpr_Notafiscalparcelamentovalor_Z");
         state.Add("gxTpr_Notafiscalparcelamentovencimento_Z_Nullable");
         state.Add("gxTpr_Notafiscalparcelamentovalortaxaadministrativa_Z");
         state.Add("gxTpr_Notafiscalparcelamentovalortaxaanual_Z");
         state.Add("gxTpr_Notafiscalparcelamentoliquido_Z");
         state.Add("gxTpr_Notafiscalparcelamentoid_N");
         state.Add("gxTpr_Notafiscalid_N");
         state.Add("gxTpr_Notafiscalnumero_N");
         state.Add("gxTpr_Notafiscalparcelamentonumero_N");
         state.Add("gxTpr_Notafiscalparcelamentovalor_N");
         state.Add("gxTpr_Notafiscalparcelamentovencimento_N");
         state.Add("gxTpr_Notafiscalparcelamentovalortaxaadministrativa_N");
         state.Add("gxTpr_Notafiscalparcelamentovalortaxaanual_N");
         state.Add("gxTpr_Notafiscalparcelamentoliquido_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtNotaFiscalParcelamento sdt;
         sdt = (SdtNotaFiscalParcelamento)(source);
         gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoid = sdt.gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoid ;
         gxTv_SdtNotaFiscalParcelamento_Notafiscalid = sdt.gxTv_SdtNotaFiscalParcelamento_Notafiscalid ;
         gxTv_SdtNotaFiscalParcelamento_Notafiscalnumero = sdt.gxTv_SdtNotaFiscalParcelamento_Notafiscalnumero ;
         gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentonumero = sdt.gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentonumero ;
         gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalor = sdt.gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalor ;
         gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovencimento = sdt.gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovencimento ;
         gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaadministrativa = sdt.gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaadministrativa ;
         gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaanual = sdt.gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaanual ;
         gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoliquido = sdt.gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoliquido ;
         gxTv_SdtNotaFiscalParcelamento_Mode = sdt.gxTv_SdtNotaFiscalParcelamento_Mode ;
         gxTv_SdtNotaFiscalParcelamento_Initialized = sdt.gxTv_SdtNotaFiscalParcelamento_Initialized ;
         gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoid_Z = sdt.gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoid_Z ;
         gxTv_SdtNotaFiscalParcelamento_Notafiscalid_Z = sdt.gxTv_SdtNotaFiscalParcelamento_Notafiscalid_Z ;
         gxTv_SdtNotaFiscalParcelamento_Notafiscalnumero_Z = sdt.gxTv_SdtNotaFiscalParcelamento_Notafiscalnumero_Z ;
         gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentonumero_Z = sdt.gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentonumero_Z ;
         gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalor_Z = sdt.gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalor_Z ;
         gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovencimento_Z = sdt.gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovencimento_Z ;
         gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaadministrativa_Z = sdt.gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaadministrativa_Z ;
         gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaanual_Z = sdt.gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaanual_Z ;
         gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoliquido_Z = sdt.gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoliquido_Z ;
         gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoid_N = sdt.gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoid_N ;
         gxTv_SdtNotaFiscalParcelamento_Notafiscalid_N = sdt.gxTv_SdtNotaFiscalParcelamento_Notafiscalid_N ;
         gxTv_SdtNotaFiscalParcelamento_Notafiscalnumero_N = sdt.gxTv_SdtNotaFiscalParcelamento_Notafiscalnumero_N ;
         gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentonumero_N = sdt.gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentonumero_N ;
         gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalor_N = sdt.gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalor_N ;
         gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovencimento_N = sdt.gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovencimento_N ;
         gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaadministrativa_N = sdt.gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaadministrativa_N ;
         gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaanual_N = sdt.gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaanual_N ;
         gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoliquido_N = sdt.gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoliquido_N ;
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
         AddObjectProperty("NotaFiscalParcelamentoID", gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoid, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalParcelamentoID_N", gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoid_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalId", gxTv_SdtNotaFiscalParcelamento_Notafiscalid, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalId_N", gxTv_SdtNotaFiscalParcelamento_Notafiscalid_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalNumero", gxTv_SdtNotaFiscalParcelamento_Notafiscalnumero, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalNumero_N", gxTv_SdtNotaFiscalParcelamento_Notafiscalnumero_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalParcelamentoNumero", gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentonumero, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalParcelamentoNumero_N", gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentonumero_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalParcelamentoValor", StringUtil.LTrim( StringUtil.Str( gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalor, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("NotaFiscalParcelamentoValor_N", gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalor_N, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovencimento)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovencimento)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovencimento)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("NotaFiscalParcelamentoVencimento", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalParcelamentoVencimento_N", gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovencimento_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalParcelamentoValorTaxaAdministrativa", StringUtil.LTrim( StringUtil.Str( gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaadministrativa, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("NotaFiscalParcelamentoValorTaxaAdministrativa_N", gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaadministrativa_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalParcelamentoValorTaxaAnual", StringUtil.LTrim( StringUtil.Str( gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaanual, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("NotaFiscalParcelamentoValorTaxaAnual_N", gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaanual_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalParcelamentoLiquido", StringUtil.LTrim( StringUtil.Str( gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoliquido, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("NotaFiscalParcelamentoLiquido_N", gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoliquido_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtNotaFiscalParcelamento_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtNotaFiscalParcelamento_Initialized, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalParcelamentoID_Z", gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoid_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalId_Z", gxTv_SdtNotaFiscalParcelamento_Notafiscalid_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalNumero_Z", gxTv_SdtNotaFiscalParcelamento_Notafiscalnumero_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalParcelamentoNumero_Z", gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentonumero_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalParcelamentoValor_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalor_Z, 18, 2)), false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovencimento_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovencimento_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovencimento_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("NotaFiscalParcelamentoVencimento_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalParcelamentoValorTaxaAdministrativa_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaadministrativa_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("NotaFiscalParcelamentoValorTaxaAnual_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaanual_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("NotaFiscalParcelamentoLiquido_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoliquido_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("NotaFiscalParcelamentoID_N", gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoid_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalId_N", gxTv_SdtNotaFiscalParcelamento_Notafiscalid_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalNumero_N", gxTv_SdtNotaFiscalParcelamento_Notafiscalnumero_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalParcelamentoNumero_N", gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentonumero_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalParcelamentoValor_N", gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalor_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalParcelamentoVencimento_N", gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovencimento_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalParcelamentoValorTaxaAdministrativa_N", gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaadministrativa_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalParcelamentoValorTaxaAnual_N", gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaanual_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalParcelamentoLiquido_N", gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoliquido_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtNotaFiscalParcelamento sdt )
      {
         if ( sdt.IsDirty("NotaFiscalParcelamentoID") )
         {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoid = sdt.gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoid ;
         }
         if ( sdt.IsDirty("NotaFiscalId") )
         {
            gxTv_SdtNotaFiscalParcelamento_Notafiscalid_N = (short)(sdt.gxTv_SdtNotaFiscalParcelamento_Notafiscalid_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalParcelamento_Notafiscalid = sdt.gxTv_SdtNotaFiscalParcelamento_Notafiscalid ;
         }
         if ( sdt.IsDirty("NotaFiscalNumero") )
         {
            gxTv_SdtNotaFiscalParcelamento_Notafiscalnumero_N = (short)(sdt.gxTv_SdtNotaFiscalParcelamento_Notafiscalnumero_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalParcelamento_Notafiscalnumero = sdt.gxTv_SdtNotaFiscalParcelamento_Notafiscalnumero ;
         }
         if ( sdt.IsDirty("NotaFiscalParcelamentoNumero") )
         {
            gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentonumero_N = (short)(sdt.gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentonumero_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentonumero = sdt.gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentonumero ;
         }
         if ( sdt.IsDirty("NotaFiscalParcelamentoValor") )
         {
            gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalor_N = (short)(sdt.gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalor_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalor = sdt.gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalor ;
         }
         if ( sdt.IsDirty("NotaFiscalParcelamentoVencimento") )
         {
            gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovencimento_N = (short)(sdt.gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovencimento_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovencimento = sdt.gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovencimento ;
         }
         if ( sdt.IsDirty("NotaFiscalParcelamentoValorTaxaAdministrativa") )
         {
            gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaadministrativa_N = (short)(sdt.gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaadministrativa_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaadministrativa = sdt.gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaadministrativa ;
         }
         if ( sdt.IsDirty("NotaFiscalParcelamentoValorTaxaAnual") )
         {
            gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaanual_N = (short)(sdt.gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaanual_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaanual = sdt.gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaanual ;
         }
         if ( sdt.IsDirty("NotaFiscalParcelamentoLiquido") )
         {
            gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoliquido_N = (short)(sdt.gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoliquido_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoliquido = sdt.gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoliquido ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "NotaFiscalParcelamentoID" )]
      [  XmlElement( ElementName = "NotaFiscalParcelamentoID"   )]
      public Guid gxTpr_Notafiscalparcelamentoid
      {
         get {
            return gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoid != value )
            {
               gxTv_SdtNotaFiscalParcelamento_Mode = "INS";
               this.gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoid_Z_SetNull( );
               this.gxTv_SdtNotaFiscalParcelamento_Notafiscalid_Z_SetNull( );
               this.gxTv_SdtNotaFiscalParcelamento_Notafiscalnumero_Z_SetNull( );
               this.gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentonumero_Z_SetNull( );
               this.gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalor_Z_SetNull( );
               this.gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovencimento_Z_SetNull( );
               this.gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaadministrativa_Z_SetNull( );
               this.gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaanual_Z_SetNull( );
               this.gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoliquido_Z_SetNull( );
            }
            gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoid = value;
            SetDirty("Notafiscalparcelamentoid");
         }

      }

      [  SoapElement( ElementName = "NotaFiscalId" )]
      [  XmlElement( ElementName = "NotaFiscalId"   )]
      public Guid gxTpr_Notafiscalid
      {
         get {
            return gxTv_SdtNotaFiscalParcelamento_Notafiscalid ;
         }

         set {
            gxTv_SdtNotaFiscalParcelamento_Notafiscalid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalParcelamento_Notafiscalid = value;
            SetDirty("Notafiscalid");
         }

      }

      public void gxTv_SdtNotaFiscalParcelamento_Notafiscalid_SetNull( )
      {
         gxTv_SdtNotaFiscalParcelamento_Notafiscalid_N = 1;
         gxTv_SdtNotaFiscalParcelamento_Notafiscalid = Guid.Empty;
         SetDirty("Notafiscalid");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalParcelamento_Notafiscalid_IsNull( )
      {
         return (gxTv_SdtNotaFiscalParcelamento_Notafiscalid_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalNumero" )]
      [  XmlElement( ElementName = "NotaFiscalNumero"   )]
      public string gxTpr_Notafiscalnumero
      {
         get {
            return gxTv_SdtNotaFiscalParcelamento_Notafiscalnumero ;
         }

         set {
            gxTv_SdtNotaFiscalParcelamento_Notafiscalnumero_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalParcelamento_Notafiscalnumero = value;
            SetDirty("Notafiscalnumero");
         }

      }

      public void gxTv_SdtNotaFiscalParcelamento_Notafiscalnumero_SetNull( )
      {
         gxTv_SdtNotaFiscalParcelamento_Notafiscalnumero_N = 1;
         gxTv_SdtNotaFiscalParcelamento_Notafiscalnumero = "";
         SetDirty("Notafiscalnumero");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalParcelamento_Notafiscalnumero_IsNull( )
      {
         return (gxTv_SdtNotaFiscalParcelamento_Notafiscalnumero_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalParcelamentoNumero" )]
      [  XmlElement( ElementName = "NotaFiscalParcelamentoNumero"   )]
      public string gxTpr_Notafiscalparcelamentonumero
      {
         get {
            return gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentonumero ;
         }

         set {
            gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentonumero_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentonumero = value;
            SetDirty("Notafiscalparcelamentonumero");
         }

      }

      public void gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentonumero_SetNull( )
      {
         gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentonumero_N = 1;
         gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentonumero = "";
         SetDirty("Notafiscalparcelamentonumero");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentonumero_IsNull( )
      {
         return (gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentonumero_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalParcelamentoValor" )]
      [  XmlElement( ElementName = "NotaFiscalParcelamentoValor"   )]
      public decimal gxTpr_Notafiscalparcelamentovalor
      {
         get {
            return gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalor ;
         }

         set {
            gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalor_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalor = value;
            SetDirty("Notafiscalparcelamentovalor");
         }

      }

      public void gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalor_SetNull( )
      {
         gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalor_N = 1;
         gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalor = 0;
         SetDirty("Notafiscalparcelamentovalor");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalor_IsNull( )
      {
         return (gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalor_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalParcelamentoVencimento" )]
      [  XmlElement( ElementName = "NotaFiscalParcelamentoVencimento"  , IsNullable=true )]
      public string gxTpr_Notafiscalparcelamentovencimento_Nullable
      {
         get {
            if ( gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovencimento == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovencimento).value ;
         }

         set {
            gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovencimento_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovencimento = DateTime.MinValue;
            else
               gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovencimento = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Notafiscalparcelamentovencimento
      {
         get {
            return gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovencimento ;
         }

         set {
            gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovencimento_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovencimento = value;
            SetDirty("Notafiscalparcelamentovencimento");
         }

      }

      public void gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovencimento_SetNull( )
      {
         gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovencimento_N = 1;
         gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovencimento = (DateTime)(DateTime.MinValue);
         SetDirty("Notafiscalparcelamentovencimento");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovencimento_IsNull( )
      {
         return (gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovencimento_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalParcelamentoValorTaxaAdministrativa" )]
      [  XmlElement( ElementName = "NotaFiscalParcelamentoValorTaxaAdministrativa"   )]
      public decimal gxTpr_Notafiscalparcelamentovalortaxaadministrativa
      {
         get {
            return gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaadministrativa ;
         }

         set {
            gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaadministrativa_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaadministrativa = value;
            SetDirty("Notafiscalparcelamentovalortaxaadministrativa");
         }

      }

      public void gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaadministrativa_SetNull( )
      {
         gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaadministrativa_N = 1;
         gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaadministrativa = 0;
         SetDirty("Notafiscalparcelamentovalortaxaadministrativa");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaadministrativa_IsNull( )
      {
         return (gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaadministrativa_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalParcelamentoValorTaxaAnual" )]
      [  XmlElement( ElementName = "NotaFiscalParcelamentoValorTaxaAnual"   )]
      public decimal gxTpr_Notafiscalparcelamentovalortaxaanual
      {
         get {
            return gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaanual ;
         }

         set {
            gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaanual_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaanual = value;
            SetDirty("Notafiscalparcelamentovalortaxaanual");
         }

      }

      public void gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaanual_SetNull( )
      {
         gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaanual_N = 1;
         gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaanual = 0;
         SetDirty("Notafiscalparcelamentovalortaxaanual");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaanual_IsNull( )
      {
         return (gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaanual_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalParcelamentoLiquido" )]
      [  XmlElement( ElementName = "NotaFiscalParcelamentoLiquido"   )]
      public decimal gxTpr_Notafiscalparcelamentoliquido
      {
         get {
            return gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoliquido ;
         }

         set {
            gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoliquido_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoliquido = value;
            SetDirty("Notafiscalparcelamentoliquido");
         }

      }

      public void gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoliquido_SetNull( )
      {
         gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoliquido_N = 1;
         gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoliquido = 0;
         SetDirty("Notafiscalparcelamentoliquido");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoliquido_IsNull( )
      {
         return (gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoliquido_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtNotaFiscalParcelamento_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalParcelamento_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtNotaFiscalParcelamento_Mode_SetNull( )
      {
         gxTv_SdtNotaFiscalParcelamento_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalParcelamento_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtNotaFiscalParcelamento_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalParcelamento_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtNotaFiscalParcelamento_Initialized_SetNull( )
      {
         gxTv_SdtNotaFiscalParcelamento_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalParcelamento_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalParcelamentoID_Z" )]
      [  XmlElement( ElementName = "NotaFiscalParcelamentoID_Z"   )]
      public Guid gxTpr_Notafiscalparcelamentoid_Z
      {
         get {
            return gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoid_Z = value;
            SetDirty("Notafiscalparcelamentoid_Z");
         }

      }

      public void gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoid_Z_SetNull( )
      {
         gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoid_Z = Guid.Empty;
         SetDirty("Notafiscalparcelamentoid_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalId_Z" )]
      [  XmlElement( ElementName = "NotaFiscalId_Z"   )]
      public Guid gxTpr_Notafiscalid_Z
      {
         get {
            return gxTv_SdtNotaFiscalParcelamento_Notafiscalid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalParcelamento_Notafiscalid_Z = value;
            SetDirty("Notafiscalid_Z");
         }

      }

      public void gxTv_SdtNotaFiscalParcelamento_Notafiscalid_Z_SetNull( )
      {
         gxTv_SdtNotaFiscalParcelamento_Notafiscalid_Z = Guid.Empty;
         SetDirty("Notafiscalid_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalParcelamento_Notafiscalid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalNumero_Z" )]
      [  XmlElement( ElementName = "NotaFiscalNumero_Z"   )]
      public string gxTpr_Notafiscalnumero_Z
      {
         get {
            return gxTv_SdtNotaFiscalParcelamento_Notafiscalnumero_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalParcelamento_Notafiscalnumero_Z = value;
            SetDirty("Notafiscalnumero_Z");
         }

      }

      public void gxTv_SdtNotaFiscalParcelamento_Notafiscalnumero_Z_SetNull( )
      {
         gxTv_SdtNotaFiscalParcelamento_Notafiscalnumero_Z = "";
         SetDirty("Notafiscalnumero_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalParcelamento_Notafiscalnumero_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalParcelamentoNumero_Z" )]
      [  XmlElement( ElementName = "NotaFiscalParcelamentoNumero_Z"   )]
      public string gxTpr_Notafiscalparcelamentonumero_Z
      {
         get {
            return gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentonumero_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentonumero_Z = value;
            SetDirty("Notafiscalparcelamentonumero_Z");
         }

      }

      public void gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentonumero_Z_SetNull( )
      {
         gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentonumero_Z = "";
         SetDirty("Notafiscalparcelamentonumero_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentonumero_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalParcelamentoValor_Z" )]
      [  XmlElement( ElementName = "NotaFiscalParcelamentoValor_Z"   )]
      public decimal gxTpr_Notafiscalparcelamentovalor_Z
      {
         get {
            return gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalor_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalor_Z = value;
            SetDirty("Notafiscalparcelamentovalor_Z");
         }

      }

      public void gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalor_Z_SetNull( )
      {
         gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalor_Z = 0;
         SetDirty("Notafiscalparcelamentovalor_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalor_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalParcelamentoVencimento_Z" )]
      [  XmlElement( ElementName = "NotaFiscalParcelamentoVencimento_Z"  , IsNullable=true )]
      public string gxTpr_Notafiscalparcelamentovencimento_Z_Nullable
      {
         get {
            if ( gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovencimento_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovencimento_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovencimento_Z = DateTime.MinValue;
            else
               gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovencimento_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Notafiscalparcelamentovencimento_Z
      {
         get {
            return gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovencimento_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovencimento_Z = value;
            SetDirty("Notafiscalparcelamentovencimento_Z");
         }

      }

      public void gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovencimento_Z_SetNull( )
      {
         gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovencimento_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Notafiscalparcelamentovencimento_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovencimento_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalParcelamentoValorTaxaAdministrativa_Z" )]
      [  XmlElement( ElementName = "NotaFiscalParcelamentoValorTaxaAdministrativa_Z"   )]
      public decimal gxTpr_Notafiscalparcelamentovalortaxaadministrativa_Z
      {
         get {
            return gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaadministrativa_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaadministrativa_Z = value;
            SetDirty("Notafiscalparcelamentovalortaxaadministrativa_Z");
         }

      }

      public void gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaadministrativa_Z_SetNull( )
      {
         gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaadministrativa_Z = 0;
         SetDirty("Notafiscalparcelamentovalortaxaadministrativa_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaadministrativa_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalParcelamentoValorTaxaAnual_Z" )]
      [  XmlElement( ElementName = "NotaFiscalParcelamentoValorTaxaAnual_Z"   )]
      public decimal gxTpr_Notafiscalparcelamentovalortaxaanual_Z
      {
         get {
            return gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaanual_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaanual_Z = value;
            SetDirty("Notafiscalparcelamentovalortaxaanual_Z");
         }

      }

      public void gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaanual_Z_SetNull( )
      {
         gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaanual_Z = 0;
         SetDirty("Notafiscalparcelamentovalortaxaanual_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaanual_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalParcelamentoLiquido_Z" )]
      [  XmlElement( ElementName = "NotaFiscalParcelamentoLiquido_Z"   )]
      public decimal gxTpr_Notafiscalparcelamentoliquido_Z
      {
         get {
            return gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoliquido_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoliquido_Z = value;
            SetDirty("Notafiscalparcelamentoliquido_Z");
         }

      }

      public void gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoliquido_Z_SetNull( )
      {
         gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoliquido_Z = 0;
         SetDirty("Notafiscalparcelamentoliquido_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoliquido_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalParcelamentoID_N" )]
      [  XmlElement( ElementName = "NotaFiscalParcelamentoID_N"   )]
      public short gxTpr_Notafiscalparcelamentoid_N
      {
         get {
            return gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoid_N = value;
            SetDirty("Notafiscalparcelamentoid_N");
         }

      }

      public void gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoid_N_SetNull( )
      {
         gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoid_N = 0;
         SetDirty("Notafiscalparcelamentoid_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalId_N" )]
      [  XmlElement( ElementName = "NotaFiscalId_N"   )]
      public short gxTpr_Notafiscalid_N
      {
         get {
            return gxTv_SdtNotaFiscalParcelamento_Notafiscalid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalParcelamento_Notafiscalid_N = value;
            SetDirty("Notafiscalid_N");
         }

      }

      public void gxTv_SdtNotaFiscalParcelamento_Notafiscalid_N_SetNull( )
      {
         gxTv_SdtNotaFiscalParcelamento_Notafiscalid_N = 0;
         SetDirty("Notafiscalid_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalParcelamento_Notafiscalid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalNumero_N" )]
      [  XmlElement( ElementName = "NotaFiscalNumero_N"   )]
      public short gxTpr_Notafiscalnumero_N
      {
         get {
            return gxTv_SdtNotaFiscalParcelamento_Notafiscalnumero_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalParcelamento_Notafiscalnumero_N = value;
            SetDirty("Notafiscalnumero_N");
         }

      }

      public void gxTv_SdtNotaFiscalParcelamento_Notafiscalnumero_N_SetNull( )
      {
         gxTv_SdtNotaFiscalParcelamento_Notafiscalnumero_N = 0;
         SetDirty("Notafiscalnumero_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalParcelamento_Notafiscalnumero_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalParcelamentoNumero_N" )]
      [  XmlElement( ElementName = "NotaFiscalParcelamentoNumero_N"   )]
      public short gxTpr_Notafiscalparcelamentonumero_N
      {
         get {
            return gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentonumero_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentonumero_N = value;
            SetDirty("Notafiscalparcelamentonumero_N");
         }

      }

      public void gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentonumero_N_SetNull( )
      {
         gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentonumero_N = 0;
         SetDirty("Notafiscalparcelamentonumero_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentonumero_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalParcelamentoValor_N" )]
      [  XmlElement( ElementName = "NotaFiscalParcelamentoValor_N"   )]
      public short gxTpr_Notafiscalparcelamentovalor_N
      {
         get {
            return gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalor_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalor_N = value;
            SetDirty("Notafiscalparcelamentovalor_N");
         }

      }

      public void gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalor_N_SetNull( )
      {
         gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalor_N = 0;
         SetDirty("Notafiscalparcelamentovalor_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalor_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalParcelamentoVencimento_N" )]
      [  XmlElement( ElementName = "NotaFiscalParcelamentoVencimento_N"   )]
      public short gxTpr_Notafiscalparcelamentovencimento_N
      {
         get {
            return gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovencimento_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovencimento_N = value;
            SetDirty("Notafiscalparcelamentovencimento_N");
         }

      }

      public void gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovencimento_N_SetNull( )
      {
         gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovencimento_N = 0;
         SetDirty("Notafiscalparcelamentovencimento_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovencimento_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalParcelamentoValorTaxaAdministrativa_N" )]
      [  XmlElement( ElementName = "NotaFiscalParcelamentoValorTaxaAdministrativa_N"   )]
      public short gxTpr_Notafiscalparcelamentovalortaxaadministrativa_N
      {
         get {
            return gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaadministrativa_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaadministrativa_N = value;
            SetDirty("Notafiscalparcelamentovalortaxaadministrativa_N");
         }

      }

      public void gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaadministrativa_N_SetNull( )
      {
         gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaadministrativa_N = 0;
         SetDirty("Notafiscalparcelamentovalortaxaadministrativa_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaadministrativa_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalParcelamentoValorTaxaAnual_N" )]
      [  XmlElement( ElementName = "NotaFiscalParcelamentoValorTaxaAnual_N"   )]
      public short gxTpr_Notafiscalparcelamentovalortaxaanual_N
      {
         get {
            return gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaanual_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaanual_N = value;
            SetDirty("Notafiscalparcelamentovalortaxaanual_N");
         }

      }

      public void gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaanual_N_SetNull( )
      {
         gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaanual_N = 0;
         SetDirty("Notafiscalparcelamentovalortaxaanual_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaanual_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalParcelamentoLiquido_N" )]
      [  XmlElement( ElementName = "NotaFiscalParcelamentoLiquido_N"   )]
      public short gxTpr_Notafiscalparcelamentoliquido_N
      {
         get {
            return gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoliquido_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoliquido_N = value;
            SetDirty("Notafiscalparcelamentoliquido_N");
         }

      }

      public void gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoliquido_N_SetNull( )
      {
         gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoliquido_N = 0;
         SetDirty("Notafiscalparcelamentoliquido_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoliquido_N_IsNull( )
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
         gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtNotaFiscalParcelamento_Notafiscalid = Guid.Empty;
         gxTv_SdtNotaFiscalParcelamento_Notafiscalnumero = "";
         gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentonumero = "";
         gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovencimento = DateTime.MinValue;
         gxTv_SdtNotaFiscalParcelamento_Mode = "";
         gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoid_Z = Guid.Empty;
         gxTv_SdtNotaFiscalParcelamento_Notafiscalid_Z = Guid.Empty;
         gxTv_SdtNotaFiscalParcelamento_Notafiscalnumero_Z = "";
         gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentonumero_Z = "";
         gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovencimento_Z = DateTime.MinValue;
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "notafiscalparcelamento", "GeneXus.Programs.notafiscalparcelamento_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtNotaFiscalParcelamento_Initialized ;
      private short gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoid_N ;
      private short gxTv_SdtNotaFiscalParcelamento_Notafiscalid_N ;
      private short gxTv_SdtNotaFiscalParcelamento_Notafiscalnumero_N ;
      private short gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentonumero_N ;
      private short gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalor_N ;
      private short gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovencimento_N ;
      private short gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaadministrativa_N ;
      private short gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaanual_N ;
      private short gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoliquido_N ;
      private decimal gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalor ;
      private decimal gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaadministrativa ;
      private decimal gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaanual ;
      private decimal gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoliquido ;
      private decimal gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalor_Z ;
      private decimal gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaadministrativa_Z ;
      private decimal gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovalortaxaanual_Z ;
      private decimal gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoliquido_Z ;
      private string gxTv_SdtNotaFiscalParcelamento_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovencimento ;
      private DateTime gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentovencimento_Z ;
      private string gxTv_SdtNotaFiscalParcelamento_Notafiscalnumero ;
      private string gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentonumero ;
      private string gxTv_SdtNotaFiscalParcelamento_Notafiscalnumero_Z ;
      private string gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentonumero_Z ;
      private Guid gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoid ;
      private Guid gxTv_SdtNotaFiscalParcelamento_Notafiscalid ;
      private Guid gxTv_SdtNotaFiscalParcelamento_Notafiscalparcelamentoid_Z ;
      private Guid gxTv_SdtNotaFiscalParcelamento_Notafiscalid_Z ;
   }

   [DataContract(Name = @"NotaFiscalParcelamento", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtNotaFiscalParcelamento_RESTInterface : GxGenericCollectionItem<SdtNotaFiscalParcelamento>
   {
      public SdtNotaFiscalParcelamento_RESTInterface( ) : base()
      {
      }

      public SdtNotaFiscalParcelamento_RESTInterface( SdtNotaFiscalParcelamento psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "NotaFiscalParcelamentoID" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Notafiscalparcelamentoid
      {
         get {
            return sdt.gxTpr_Notafiscalparcelamentoid ;
         }

         set {
            sdt.gxTpr_Notafiscalparcelamentoid = value;
         }

      }

      [DataMember( Name = "NotaFiscalId" , Order = 1 )]
      [GxSeudo()]
      public Guid gxTpr_Notafiscalid
      {
         get {
            return sdt.gxTpr_Notafiscalid ;
         }

         set {
            sdt.gxTpr_Notafiscalid = value;
         }

      }

      [DataMember( Name = "NotaFiscalNumero" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Notafiscalnumero
      {
         get {
            return sdt.gxTpr_Notafiscalnumero ;
         }

         set {
            sdt.gxTpr_Notafiscalnumero = value;
         }

      }

      [DataMember( Name = "NotaFiscalParcelamentoNumero" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Notafiscalparcelamentonumero
      {
         get {
            return sdt.gxTpr_Notafiscalparcelamentonumero ;
         }

         set {
            sdt.gxTpr_Notafiscalparcelamentonumero = value;
         }

      }

      [DataMember( Name = "NotaFiscalParcelamentoValor" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Notafiscalparcelamentovalor
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Notafiscalparcelamentovalor, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Notafiscalparcelamentovalor = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "NotaFiscalParcelamentoVencimento" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Notafiscalparcelamentovencimento
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Notafiscalparcelamentovencimento) ;
         }

         set {
            sdt.gxTpr_Notafiscalparcelamentovencimento = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "NotaFiscalParcelamentoValorTaxaAdministrativa" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Notafiscalparcelamentovalortaxaadministrativa
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Notafiscalparcelamentovalortaxaadministrativa, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Notafiscalparcelamentovalortaxaadministrativa = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "NotaFiscalParcelamentoValorTaxaAnual" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Notafiscalparcelamentovalortaxaanual
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Notafiscalparcelamentovalortaxaanual, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Notafiscalparcelamentovalortaxaanual = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "NotaFiscalParcelamentoLiquido" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Notafiscalparcelamentoliquido
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Notafiscalparcelamentoliquido, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Notafiscalparcelamentoliquido = NumberUtil.Val( value, ".");
         }

      }

      public SdtNotaFiscalParcelamento sdt
      {
         get {
            return (SdtNotaFiscalParcelamento)Sdt ;
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
            sdt = new SdtNotaFiscalParcelamento() ;
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

   [DataContract(Name = @"NotaFiscalParcelamento", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtNotaFiscalParcelamento_RESTLInterface : GxGenericCollectionItem<SdtNotaFiscalParcelamento>
   {
      public SdtNotaFiscalParcelamento_RESTLInterface( ) : base()
      {
      }

      public SdtNotaFiscalParcelamento_RESTLInterface( SdtNotaFiscalParcelamento psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "NotaFiscalParcelamentoNumero" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Notafiscalparcelamentonumero
      {
         get {
            return sdt.gxTpr_Notafiscalparcelamentonumero ;
         }

         set {
            sdt.gxTpr_Notafiscalparcelamentonumero = value;
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

      public SdtNotaFiscalParcelamento sdt
      {
         get {
            return (SdtNotaFiscalParcelamento)Sdt ;
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
            sdt = new SdtNotaFiscalParcelamento() ;
         }
      }

   }

}
