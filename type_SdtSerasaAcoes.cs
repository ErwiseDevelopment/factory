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
   [XmlRoot(ElementName = "SerasaAcoes" )]
   [XmlType(TypeName =  "SerasaAcoes" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtSerasaAcoes : GxSilentTrnSdt
   {
      public SdtSerasaAcoes( )
      {
      }

      public SdtSerasaAcoes( IGxContext context )
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

      public void Load( int AV699SerasaAcoesId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV699SerasaAcoesId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"SerasaAcoesId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "SerasaAcoes");
         metadata.Set("BT", "SerasaAcoes");
         metadata.Set("PK", "[ \"SerasaAcoesId\" ]");
         metadata.Set("PKAssigned", "[ \"SerasaAcoesId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"SerasaId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Serasaacoesid_Z");
         state.Add("gxTpr_Serasaid_Z");
         state.Add("gxTpr_Serasaacoesdata_Z_Nullable");
         state.Add("gxTpr_Serasaacoesnatureza_Z");
         state.Add("gxTpr_Serasaacoesvalor_Z");
         state.Add("gxTpr_Serasaacoesdistribuidor_Z");
         state.Add("gxTpr_Serasaacoesvara_Z");
         state.Add("gxTpr_Serasaacoescidade_Z");
         state.Add("gxTpr_Serasaacoesuf_Z");
         state.Add("gxTpr_Serasaacoesprincipal_Z");
         state.Add("gxTpr_Serasaacoestipomoeda_Z");
         state.Add("gxTpr_Serasaacoesqtdoco_Z");
         state.Add("gxTpr_Serasaid_N");
         state.Add("gxTpr_Serasaacoesdata_N");
         state.Add("gxTpr_Serasaacoesnatureza_N");
         state.Add("gxTpr_Serasaacoesvalor_N");
         state.Add("gxTpr_Serasaacoesdistribuidor_N");
         state.Add("gxTpr_Serasaacoesvara_N");
         state.Add("gxTpr_Serasaacoescidade_N");
         state.Add("gxTpr_Serasaacoesuf_N");
         state.Add("gxTpr_Serasaacoesprincipal_N");
         state.Add("gxTpr_Serasaacoestipomoeda_N");
         state.Add("gxTpr_Serasaacoesqtdoco_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtSerasaAcoes sdt;
         sdt = (SdtSerasaAcoes)(source);
         gxTv_SdtSerasaAcoes_Serasaacoesid = sdt.gxTv_SdtSerasaAcoes_Serasaacoesid ;
         gxTv_SdtSerasaAcoes_Serasaid = sdt.gxTv_SdtSerasaAcoes_Serasaid ;
         gxTv_SdtSerasaAcoes_Serasaacoesdata = sdt.gxTv_SdtSerasaAcoes_Serasaacoesdata ;
         gxTv_SdtSerasaAcoes_Serasaacoesnatureza = sdt.gxTv_SdtSerasaAcoes_Serasaacoesnatureza ;
         gxTv_SdtSerasaAcoes_Serasaacoesvalor = sdt.gxTv_SdtSerasaAcoes_Serasaacoesvalor ;
         gxTv_SdtSerasaAcoes_Serasaacoesdistribuidor = sdt.gxTv_SdtSerasaAcoes_Serasaacoesdistribuidor ;
         gxTv_SdtSerasaAcoes_Serasaacoesvara = sdt.gxTv_SdtSerasaAcoes_Serasaacoesvara ;
         gxTv_SdtSerasaAcoes_Serasaacoescidade = sdt.gxTv_SdtSerasaAcoes_Serasaacoescidade ;
         gxTv_SdtSerasaAcoes_Serasaacoesuf = sdt.gxTv_SdtSerasaAcoes_Serasaacoesuf ;
         gxTv_SdtSerasaAcoes_Serasaacoesprincipal = sdt.gxTv_SdtSerasaAcoes_Serasaacoesprincipal ;
         gxTv_SdtSerasaAcoes_Serasaacoestipomoeda = sdt.gxTv_SdtSerasaAcoes_Serasaacoestipomoeda ;
         gxTv_SdtSerasaAcoes_Serasaacoesqtdoco = sdt.gxTv_SdtSerasaAcoes_Serasaacoesqtdoco ;
         gxTv_SdtSerasaAcoes_Mode = sdt.gxTv_SdtSerasaAcoes_Mode ;
         gxTv_SdtSerasaAcoes_Initialized = sdt.gxTv_SdtSerasaAcoes_Initialized ;
         gxTv_SdtSerasaAcoes_Serasaacoesid_Z = sdt.gxTv_SdtSerasaAcoes_Serasaacoesid_Z ;
         gxTv_SdtSerasaAcoes_Serasaid_Z = sdt.gxTv_SdtSerasaAcoes_Serasaid_Z ;
         gxTv_SdtSerasaAcoes_Serasaacoesdata_Z = sdt.gxTv_SdtSerasaAcoes_Serasaacoesdata_Z ;
         gxTv_SdtSerasaAcoes_Serasaacoesnatureza_Z = sdt.gxTv_SdtSerasaAcoes_Serasaacoesnatureza_Z ;
         gxTv_SdtSerasaAcoes_Serasaacoesvalor_Z = sdt.gxTv_SdtSerasaAcoes_Serasaacoesvalor_Z ;
         gxTv_SdtSerasaAcoes_Serasaacoesdistribuidor_Z = sdt.gxTv_SdtSerasaAcoes_Serasaacoesdistribuidor_Z ;
         gxTv_SdtSerasaAcoes_Serasaacoesvara_Z = sdt.gxTv_SdtSerasaAcoes_Serasaacoesvara_Z ;
         gxTv_SdtSerasaAcoes_Serasaacoescidade_Z = sdt.gxTv_SdtSerasaAcoes_Serasaacoescidade_Z ;
         gxTv_SdtSerasaAcoes_Serasaacoesuf_Z = sdt.gxTv_SdtSerasaAcoes_Serasaacoesuf_Z ;
         gxTv_SdtSerasaAcoes_Serasaacoesprincipal_Z = sdt.gxTv_SdtSerasaAcoes_Serasaacoesprincipal_Z ;
         gxTv_SdtSerasaAcoes_Serasaacoestipomoeda_Z = sdt.gxTv_SdtSerasaAcoes_Serasaacoestipomoeda_Z ;
         gxTv_SdtSerasaAcoes_Serasaacoesqtdoco_Z = sdt.gxTv_SdtSerasaAcoes_Serasaacoesqtdoco_Z ;
         gxTv_SdtSerasaAcoes_Serasaid_N = sdt.gxTv_SdtSerasaAcoes_Serasaid_N ;
         gxTv_SdtSerasaAcoes_Serasaacoesdata_N = sdt.gxTv_SdtSerasaAcoes_Serasaacoesdata_N ;
         gxTv_SdtSerasaAcoes_Serasaacoesnatureza_N = sdt.gxTv_SdtSerasaAcoes_Serasaacoesnatureza_N ;
         gxTv_SdtSerasaAcoes_Serasaacoesvalor_N = sdt.gxTv_SdtSerasaAcoes_Serasaacoesvalor_N ;
         gxTv_SdtSerasaAcoes_Serasaacoesdistribuidor_N = sdt.gxTv_SdtSerasaAcoes_Serasaacoesdistribuidor_N ;
         gxTv_SdtSerasaAcoes_Serasaacoesvara_N = sdt.gxTv_SdtSerasaAcoes_Serasaacoesvara_N ;
         gxTv_SdtSerasaAcoes_Serasaacoescidade_N = sdt.gxTv_SdtSerasaAcoes_Serasaacoescidade_N ;
         gxTv_SdtSerasaAcoes_Serasaacoesuf_N = sdt.gxTv_SdtSerasaAcoes_Serasaacoesuf_N ;
         gxTv_SdtSerasaAcoes_Serasaacoesprincipal_N = sdt.gxTv_SdtSerasaAcoes_Serasaacoesprincipal_N ;
         gxTv_SdtSerasaAcoes_Serasaacoestipomoeda_N = sdt.gxTv_SdtSerasaAcoes_Serasaacoestipomoeda_N ;
         gxTv_SdtSerasaAcoes_Serasaacoesqtdoco_N = sdt.gxTv_SdtSerasaAcoes_Serasaacoesqtdoco_N ;
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
         AddObjectProperty("SerasaAcoesId", gxTv_SdtSerasaAcoes_Serasaacoesid, false, includeNonInitialized);
         AddObjectProperty("SerasaId", gxTv_SdtSerasaAcoes_Serasaid, false, includeNonInitialized);
         AddObjectProperty("SerasaId_N", gxTv_SdtSerasaAcoes_Serasaid_N, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtSerasaAcoes_Serasaacoesdata)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtSerasaAcoes_Serasaacoesdata)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtSerasaAcoes_Serasaacoesdata)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("SerasaAcoesData", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("SerasaAcoesData_N", gxTv_SdtSerasaAcoes_Serasaacoesdata_N, false, includeNonInitialized);
         AddObjectProperty("SerasaAcoesNatureza", gxTv_SdtSerasaAcoes_Serasaacoesnatureza, false, includeNonInitialized);
         AddObjectProperty("SerasaAcoesNatureza_N", gxTv_SdtSerasaAcoes_Serasaacoesnatureza_N, false, includeNonInitialized);
         AddObjectProperty("SerasaAcoesValor", StringUtil.LTrim( StringUtil.Str( gxTv_SdtSerasaAcoes_Serasaacoesvalor, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("SerasaAcoesValor_N", gxTv_SdtSerasaAcoes_Serasaacoesvalor_N, false, includeNonInitialized);
         AddObjectProperty("SerasaAcoesDistribuidor", gxTv_SdtSerasaAcoes_Serasaacoesdistribuidor, false, includeNonInitialized);
         AddObjectProperty("SerasaAcoesDistribuidor_N", gxTv_SdtSerasaAcoes_Serasaacoesdistribuidor_N, false, includeNonInitialized);
         AddObjectProperty("SerasaAcoesVara", gxTv_SdtSerasaAcoes_Serasaacoesvara, false, includeNonInitialized);
         AddObjectProperty("SerasaAcoesVara_N", gxTv_SdtSerasaAcoes_Serasaacoesvara_N, false, includeNonInitialized);
         AddObjectProperty("SerasaAcoesCidade", gxTv_SdtSerasaAcoes_Serasaacoescidade, false, includeNonInitialized);
         AddObjectProperty("SerasaAcoesCidade_N", gxTv_SdtSerasaAcoes_Serasaacoescidade_N, false, includeNonInitialized);
         AddObjectProperty("SerasaAcoesUF", gxTv_SdtSerasaAcoes_Serasaacoesuf, false, includeNonInitialized);
         AddObjectProperty("SerasaAcoesUF_N", gxTv_SdtSerasaAcoes_Serasaacoesuf_N, false, includeNonInitialized);
         AddObjectProperty("SerasaAcoesPrincipal", gxTv_SdtSerasaAcoes_Serasaacoesprincipal, false, includeNonInitialized);
         AddObjectProperty("SerasaAcoesPrincipal_N", gxTv_SdtSerasaAcoes_Serasaacoesprincipal_N, false, includeNonInitialized);
         AddObjectProperty("SerasaAcoesTipoMoeda", gxTv_SdtSerasaAcoes_Serasaacoestipomoeda, false, includeNonInitialized);
         AddObjectProperty("SerasaAcoesTipoMoeda_N", gxTv_SdtSerasaAcoes_Serasaacoestipomoeda_N, false, includeNonInitialized);
         AddObjectProperty("SerasaAcoesQtdOco", gxTv_SdtSerasaAcoes_Serasaacoesqtdoco, false, includeNonInitialized);
         AddObjectProperty("SerasaAcoesQtdOco_N", gxTv_SdtSerasaAcoes_Serasaacoesqtdoco_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtSerasaAcoes_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtSerasaAcoes_Initialized, false, includeNonInitialized);
            AddObjectProperty("SerasaAcoesId_Z", gxTv_SdtSerasaAcoes_Serasaacoesid_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaId_Z", gxTv_SdtSerasaAcoes_Serasaid_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtSerasaAcoes_Serasaacoesdata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtSerasaAcoes_Serasaacoesdata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtSerasaAcoes_Serasaacoesdata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("SerasaAcoesData_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("SerasaAcoesNatureza_Z", gxTv_SdtSerasaAcoes_Serasaacoesnatureza_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaAcoesValor_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtSerasaAcoes_Serasaacoesvalor_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("SerasaAcoesDistribuidor_Z", gxTv_SdtSerasaAcoes_Serasaacoesdistribuidor_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaAcoesVara_Z", gxTv_SdtSerasaAcoes_Serasaacoesvara_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaAcoesCidade_Z", gxTv_SdtSerasaAcoes_Serasaacoescidade_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaAcoesUF_Z", gxTv_SdtSerasaAcoes_Serasaacoesuf_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaAcoesPrincipal_Z", gxTv_SdtSerasaAcoes_Serasaacoesprincipal_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaAcoesTipoMoeda_Z", gxTv_SdtSerasaAcoes_Serasaacoestipomoeda_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaAcoesQtdOco_Z", gxTv_SdtSerasaAcoes_Serasaacoesqtdoco_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaId_N", gxTv_SdtSerasaAcoes_Serasaid_N, false, includeNonInitialized);
            AddObjectProperty("SerasaAcoesData_N", gxTv_SdtSerasaAcoes_Serasaacoesdata_N, false, includeNonInitialized);
            AddObjectProperty("SerasaAcoesNatureza_N", gxTv_SdtSerasaAcoes_Serasaacoesnatureza_N, false, includeNonInitialized);
            AddObjectProperty("SerasaAcoesValor_N", gxTv_SdtSerasaAcoes_Serasaacoesvalor_N, false, includeNonInitialized);
            AddObjectProperty("SerasaAcoesDistribuidor_N", gxTv_SdtSerasaAcoes_Serasaacoesdistribuidor_N, false, includeNonInitialized);
            AddObjectProperty("SerasaAcoesVara_N", gxTv_SdtSerasaAcoes_Serasaacoesvara_N, false, includeNonInitialized);
            AddObjectProperty("SerasaAcoesCidade_N", gxTv_SdtSerasaAcoes_Serasaacoescidade_N, false, includeNonInitialized);
            AddObjectProperty("SerasaAcoesUF_N", gxTv_SdtSerasaAcoes_Serasaacoesuf_N, false, includeNonInitialized);
            AddObjectProperty("SerasaAcoesPrincipal_N", gxTv_SdtSerasaAcoes_Serasaacoesprincipal_N, false, includeNonInitialized);
            AddObjectProperty("SerasaAcoesTipoMoeda_N", gxTv_SdtSerasaAcoes_Serasaacoestipomoeda_N, false, includeNonInitialized);
            AddObjectProperty("SerasaAcoesQtdOco_N", gxTv_SdtSerasaAcoes_Serasaacoesqtdoco_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtSerasaAcoes sdt )
      {
         if ( sdt.IsDirty("SerasaAcoesId") )
         {
            sdtIsNull = 0;
            gxTv_SdtSerasaAcoes_Serasaacoesid = sdt.gxTv_SdtSerasaAcoes_Serasaacoesid ;
         }
         if ( sdt.IsDirty("SerasaId") )
         {
            gxTv_SdtSerasaAcoes_Serasaid_N = (short)(sdt.gxTv_SdtSerasaAcoes_Serasaid_N);
            sdtIsNull = 0;
            gxTv_SdtSerasaAcoes_Serasaid = sdt.gxTv_SdtSerasaAcoes_Serasaid ;
         }
         if ( sdt.IsDirty("SerasaAcoesData") )
         {
            gxTv_SdtSerasaAcoes_Serasaacoesdata_N = (short)(sdt.gxTv_SdtSerasaAcoes_Serasaacoesdata_N);
            sdtIsNull = 0;
            gxTv_SdtSerasaAcoes_Serasaacoesdata = sdt.gxTv_SdtSerasaAcoes_Serasaacoesdata ;
         }
         if ( sdt.IsDirty("SerasaAcoesNatureza") )
         {
            gxTv_SdtSerasaAcoes_Serasaacoesnatureza_N = (short)(sdt.gxTv_SdtSerasaAcoes_Serasaacoesnatureza_N);
            sdtIsNull = 0;
            gxTv_SdtSerasaAcoes_Serasaacoesnatureza = sdt.gxTv_SdtSerasaAcoes_Serasaacoesnatureza ;
         }
         if ( sdt.IsDirty("SerasaAcoesValor") )
         {
            gxTv_SdtSerasaAcoes_Serasaacoesvalor_N = (short)(sdt.gxTv_SdtSerasaAcoes_Serasaacoesvalor_N);
            sdtIsNull = 0;
            gxTv_SdtSerasaAcoes_Serasaacoesvalor = sdt.gxTv_SdtSerasaAcoes_Serasaacoesvalor ;
         }
         if ( sdt.IsDirty("SerasaAcoesDistribuidor") )
         {
            gxTv_SdtSerasaAcoes_Serasaacoesdistribuidor_N = (short)(sdt.gxTv_SdtSerasaAcoes_Serasaacoesdistribuidor_N);
            sdtIsNull = 0;
            gxTv_SdtSerasaAcoes_Serasaacoesdistribuidor = sdt.gxTv_SdtSerasaAcoes_Serasaacoesdistribuidor ;
         }
         if ( sdt.IsDirty("SerasaAcoesVara") )
         {
            gxTv_SdtSerasaAcoes_Serasaacoesvara_N = (short)(sdt.gxTv_SdtSerasaAcoes_Serasaacoesvara_N);
            sdtIsNull = 0;
            gxTv_SdtSerasaAcoes_Serasaacoesvara = sdt.gxTv_SdtSerasaAcoes_Serasaacoesvara ;
         }
         if ( sdt.IsDirty("SerasaAcoesCidade") )
         {
            gxTv_SdtSerasaAcoes_Serasaacoescidade_N = (short)(sdt.gxTv_SdtSerasaAcoes_Serasaacoescidade_N);
            sdtIsNull = 0;
            gxTv_SdtSerasaAcoes_Serasaacoescidade = sdt.gxTv_SdtSerasaAcoes_Serasaacoescidade ;
         }
         if ( sdt.IsDirty("SerasaAcoesUF") )
         {
            gxTv_SdtSerasaAcoes_Serasaacoesuf_N = (short)(sdt.gxTv_SdtSerasaAcoes_Serasaacoesuf_N);
            sdtIsNull = 0;
            gxTv_SdtSerasaAcoes_Serasaacoesuf = sdt.gxTv_SdtSerasaAcoes_Serasaacoesuf ;
         }
         if ( sdt.IsDirty("SerasaAcoesPrincipal") )
         {
            gxTv_SdtSerasaAcoes_Serasaacoesprincipal_N = (short)(sdt.gxTv_SdtSerasaAcoes_Serasaacoesprincipal_N);
            sdtIsNull = 0;
            gxTv_SdtSerasaAcoes_Serasaacoesprincipal = sdt.gxTv_SdtSerasaAcoes_Serasaacoesprincipal ;
         }
         if ( sdt.IsDirty("SerasaAcoesTipoMoeda") )
         {
            gxTv_SdtSerasaAcoes_Serasaacoestipomoeda_N = (short)(sdt.gxTv_SdtSerasaAcoes_Serasaacoestipomoeda_N);
            sdtIsNull = 0;
            gxTv_SdtSerasaAcoes_Serasaacoestipomoeda = sdt.gxTv_SdtSerasaAcoes_Serasaacoestipomoeda ;
         }
         if ( sdt.IsDirty("SerasaAcoesQtdOco") )
         {
            gxTv_SdtSerasaAcoes_Serasaacoesqtdoco_N = (short)(sdt.gxTv_SdtSerasaAcoes_Serasaacoesqtdoco_N);
            sdtIsNull = 0;
            gxTv_SdtSerasaAcoes_Serasaacoesqtdoco = sdt.gxTv_SdtSerasaAcoes_Serasaacoesqtdoco ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "SerasaAcoesId" )]
      [  XmlElement( ElementName = "SerasaAcoesId"   )]
      public int gxTpr_Serasaacoesid
      {
         get {
            return gxTv_SdtSerasaAcoes_Serasaacoesid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtSerasaAcoes_Serasaacoesid != value )
            {
               gxTv_SdtSerasaAcoes_Mode = "INS";
               this.gxTv_SdtSerasaAcoes_Serasaacoesid_Z_SetNull( );
               this.gxTv_SdtSerasaAcoes_Serasaid_Z_SetNull( );
               this.gxTv_SdtSerasaAcoes_Serasaacoesdata_Z_SetNull( );
               this.gxTv_SdtSerasaAcoes_Serasaacoesnatureza_Z_SetNull( );
               this.gxTv_SdtSerasaAcoes_Serasaacoesvalor_Z_SetNull( );
               this.gxTv_SdtSerasaAcoes_Serasaacoesdistribuidor_Z_SetNull( );
               this.gxTv_SdtSerasaAcoes_Serasaacoesvara_Z_SetNull( );
               this.gxTv_SdtSerasaAcoes_Serasaacoescidade_Z_SetNull( );
               this.gxTv_SdtSerasaAcoes_Serasaacoesuf_Z_SetNull( );
               this.gxTv_SdtSerasaAcoes_Serasaacoesprincipal_Z_SetNull( );
               this.gxTv_SdtSerasaAcoes_Serasaacoestipomoeda_Z_SetNull( );
               this.gxTv_SdtSerasaAcoes_Serasaacoesqtdoco_Z_SetNull( );
            }
            gxTv_SdtSerasaAcoes_Serasaacoesid = value;
            SetDirty("Serasaacoesid");
         }

      }

      [  SoapElement( ElementName = "SerasaId" )]
      [  XmlElement( ElementName = "SerasaId"   )]
      public int gxTpr_Serasaid
      {
         get {
            return gxTv_SdtSerasaAcoes_Serasaid ;
         }

         set {
            gxTv_SdtSerasaAcoes_Serasaid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasaAcoes_Serasaid = value;
            SetDirty("Serasaid");
         }

      }

      public void gxTv_SdtSerasaAcoes_Serasaid_SetNull( )
      {
         gxTv_SdtSerasaAcoes_Serasaid_N = 1;
         gxTv_SdtSerasaAcoes_Serasaid = 0;
         SetDirty("Serasaid");
         return  ;
      }

      public bool gxTv_SdtSerasaAcoes_Serasaid_IsNull( )
      {
         return (gxTv_SdtSerasaAcoes_Serasaid_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaAcoesData" )]
      [  XmlElement( ElementName = "SerasaAcoesData"  , IsNullable=true )]
      public string gxTpr_Serasaacoesdata_Nullable
      {
         get {
            if ( gxTv_SdtSerasaAcoes_Serasaacoesdata == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtSerasaAcoes_Serasaacoesdata).value ;
         }

         set {
            gxTv_SdtSerasaAcoes_Serasaacoesdata_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtSerasaAcoes_Serasaacoesdata = DateTime.MinValue;
            else
               gxTv_SdtSerasaAcoes_Serasaacoesdata = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Serasaacoesdata
      {
         get {
            return gxTv_SdtSerasaAcoes_Serasaacoesdata ;
         }

         set {
            gxTv_SdtSerasaAcoes_Serasaacoesdata_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasaAcoes_Serasaacoesdata = value;
            SetDirty("Serasaacoesdata");
         }

      }

      public void gxTv_SdtSerasaAcoes_Serasaacoesdata_SetNull( )
      {
         gxTv_SdtSerasaAcoes_Serasaacoesdata_N = 1;
         gxTv_SdtSerasaAcoes_Serasaacoesdata = (DateTime)(DateTime.MinValue);
         SetDirty("Serasaacoesdata");
         return  ;
      }

      public bool gxTv_SdtSerasaAcoes_Serasaacoesdata_IsNull( )
      {
         return (gxTv_SdtSerasaAcoes_Serasaacoesdata_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaAcoesNatureza" )]
      [  XmlElement( ElementName = "SerasaAcoesNatureza"   )]
      public string gxTpr_Serasaacoesnatureza
      {
         get {
            return gxTv_SdtSerasaAcoes_Serasaacoesnatureza ;
         }

         set {
            gxTv_SdtSerasaAcoes_Serasaacoesnatureza_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasaAcoes_Serasaacoesnatureza = value;
            SetDirty("Serasaacoesnatureza");
         }

      }

      public void gxTv_SdtSerasaAcoes_Serasaacoesnatureza_SetNull( )
      {
         gxTv_SdtSerasaAcoes_Serasaacoesnatureza_N = 1;
         gxTv_SdtSerasaAcoes_Serasaacoesnatureza = "";
         SetDirty("Serasaacoesnatureza");
         return  ;
      }

      public bool gxTv_SdtSerasaAcoes_Serasaacoesnatureza_IsNull( )
      {
         return (gxTv_SdtSerasaAcoes_Serasaacoesnatureza_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaAcoesValor" )]
      [  XmlElement( ElementName = "SerasaAcoesValor"   )]
      public decimal gxTpr_Serasaacoesvalor
      {
         get {
            return gxTv_SdtSerasaAcoes_Serasaacoesvalor ;
         }

         set {
            gxTv_SdtSerasaAcoes_Serasaacoesvalor_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasaAcoes_Serasaacoesvalor = value;
            SetDirty("Serasaacoesvalor");
         }

      }

      public void gxTv_SdtSerasaAcoes_Serasaacoesvalor_SetNull( )
      {
         gxTv_SdtSerasaAcoes_Serasaacoesvalor_N = 1;
         gxTv_SdtSerasaAcoes_Serasaacoesvalor = 0;
         SetDirty("Serasaacoesvalor");
         return  ;
      }

      public bool gxTv_SdtSerasaAcoes_Serasaacoesvalor_IsNull( )
      {
         return (gxTv_SdtSerasaAcoes_Serasaacoesvalor_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaAcoesDistribuidor" )]
      [  XmlElement( ElementName = "SerasaAcoesDistribuidor"   )]
      public string gxTpr_Serasaacoesdistribuidor
      {
         get {
            return gxTv_SdtSerasaAcoes_Serasaacoesdistribuidor ;
         }

         set {
            gxTv_SdtSerasaAcoes_Serasaacoesdistribuidor_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasaAcoes_Serasaacoesdistribuidor = value;
            SetDirty("Serasaacoesdistribuidor");
         }

      }

      public void gxTv_SdtSerasaAcoes_Serasaacoesdistribuidor_SetNull( )
      {
         gxTv_SdtSerasaAcoes_Serasaacoesdistribuidor_N = 1;
         gxTv_SdtSerasaAcoes_Serasaacoesdistribuidor = "";
         SetDirty("Serasaacoesdistribuidor");
         return  ;
      }

      public bool gxTv_SdtSerasaAcoes_Serasaacoesdistribuidor_IsNull( )
      {
         return (gxTv_SdtSerasaAcoes_Serasaacoesdistribuidor_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaAcoesVara" )]
      [  XmlElement( ElementName = "SerasaAcoesVara"   )]
      public string gxTpr_Serasaacoesvara
      {
         get {
            return gxTv_SdtSerasaAcoes_Serasaacoesvara ;
         }

         set {
            gxTv_SdtSerasaAcoes_Serasaacoesvara_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasaAcoes_Serasaacoesvara = value;
            SetDirty("Serasaacoesvara");
         }

      }

      public void gxTv_SdtSerasaAcoes_Serasaacoesvara_SetNull( )
      {
         gxTv_SdtSerasaAcoes_Serasaacoesvara_N = 1;
         gxTv_SdtSerasaAcoes_Serasaacoesvara = "";
         SetDirty("Serasaacoesvara");
         return  ;
      }

      public bool gxTv_SdtSerasaAcoes_Serasaacoesvara_IsNull( )
      {
         return (gxTv_SdtSerasaAcoes_Serasaacoesvara_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaAcoesCidade" )]
      [  XmlElement( ElementName = "SerasaAcoesCidade"   )]
      public string gxTpr_Serasaacoescidade
      {
         get {
            return gxTv_SdtSerasaAcoes_Serasaacoescidade ;
         }

         set {
            gxTv_SdtSerasaAcoes_Serasaacoescidade_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasaAcoes_Serasaacoescidade = value;
            SetDirty("Serasaacoescidade");
         }

      }

      public void gxTv_SdtSerasaAcoes_Serasaacoescidade_SetNull( )
      {
         gxTv_SdtSerasaAcoes_Serasaacoescidade_N = 1;
         gxTv_SdtSerasaAcoes_Serasaacoescidade = "";
         SetDirty("Serasaacoescidade");
         return  ;
      }

      public bool gxTv_SdtSerasaAcoes_Serasaacoescidade_IsNull( )
      {
         return (gxTv_SdtSerasaAcoes_Serasaacoescidade_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaAcoesUF" )]
      [  XmlElement( ElementName = "SerasaAcoesUF"   )]
      public string gxTpr_Serasaacoesuf
      {
         get {
            return gxTv_SdtSerasaAcoes_Serasaacoesuf ;
         }

         set {
            gxTv_SdtSerasaAcoes_Serasaacoesuf_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasaAcoes_Serasaacoesuf = value;
            SetDirty("Serasaacoesuf");
         }

      }

      public void gxTv_SdtSerasaAcoes_Serasaacoesuf_SetNull( )
      {
         gxTv_SdtSerasaAcoes_Serasaacoesuf_N = 1;
         gxTv_SdtSerasaAcoes_Serasaacoesuf = "";
         SetDirty("Serasaacoesuf");
         return  ;
      }

      public bool gxTv_SdtSerasaAcoes_Serasaacoesuf_IsNull( )
      {
         return (gxTv_SdtSerasaAcoes_Serasaacoesuf_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaAcoesPrincipal" )]
      [  XmlElement( ElementName = "SerasaAcoesPrincipal"   )]
      public string gxTpr_Serasaacoesprincipal
      {
         get {
            return gxTv_SdtSerasaAcoes_Serasaacoesprincipal ;
         }

         set {
            gxTv_SdtSerasaAcoes_Serasaacoesprincipal_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasaAcoes_Serasaacoesprincipal = value;
            SetDirty("Serasaacoesprincipal");
         }

      }

      public void gxTv_SdtSerasaAcoes_Serasaacoesprincipal_SetNull( )
      {
         gxTv_SdtSerasaAcoes_Serasaacoesprincipal_N = 1;
         gxTv_SdtSerasaAcoes_Serasaacoesprincipal = "";
         SetDirty("Serasaacoesprincipal");
         return  ;
      }

      public bool gxTv_SdtSerasaAcoes_Serasaacoesprincipal_IsNull( )
      {
         return (gxTv_SdtSerasaAcoes_Serasaacoesprincipal_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaAcoesTipoMoeda" )]
      [  XmlElement( ElementName = "SerasaAcoesTipoMoeda"   )]
      public string gxTpr_Serasaacoestipomoeda
      {
         get {
            return gxTv_SdtSerasaAcoes_Serasaacoestipomoeda ;
         }

         set {
            gxTv_SdtSerasaAcoes_Serasaacoestipomoeda_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasaAcoes_Serasaacoestipomoeda = value;
            SetDirty("Serasaacoestipomoeda");
         }

      }

      public void gxTv_SdtSerasaAcoes_Serasaacoestipomoeda_SetNull( )
      {
         gxTv_SdtSerasaAcoes_Serasaacoestipomoeda_N = 1;
         gxTv_SdtSerasaAcoes_Serasaacoestipomoeda = "";
         SetDirty("Serasaacoestipomoeda");
         return  ;
      }

      public bool gxTv_SdtSerasaAcoes_Serasaacoestipomoeda_IsNull( )
      {
         return (gxTv_SdtSerasaAcoes_Serasaacoestipomoeda_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaAcoesQtdOco" )]
      [  XmlElement( ElementName = "SerasaAcoesQtdOco"   )]
      public short gxTpr_Serasaacoesqtdoco
      {
         get {
            return gxTv_SdtSerasaAcoes_Serasaacoesqtdoco ;
         }

         set {
            gxTv_SdtSerasaAcoes_Serasaacoesqtdoco_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasaAcoes_Serasaacoesqtdoco = value;
            SetDirty("Serasaacoesqtdoco");
         }

      }

      public void gxTv_SdtSerasaAcoes_Serasaacoesqtdoco_SetNull( )
      {
         gxTv_SdtSerasaAcoes_Serasaacoesqtdoco_N = 1;
         gxTv_SdtSerasaAcoes_Serasaacoesqtdoco = 0;
         SetDirty("Serasaacoesqtdoco");
         return  ;
      }

      public bool gxTv_SdtSerasaAcoes_Serasaacoesqtdoco_IsNull( )
      {
         return (gxTv_SdtSerasaAcoes_Serasaacoesqtdoco_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtSerasaAcoes_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaAcoes_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtSerasaAcoes_Mode_SetNull( )
      {
         gxTv_SdtSerasaAcoes_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtSerasaAcoes_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtSerasaAcoes_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaAcoes_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtSerasaAcoes_Initialized_SetNull( )
      {
         gxTv_SdtSerasaAcoes_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtSerasaAcoes_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaAcoesId_Z" )]
      [  XmlElement( ElementName = "SerasaAcoesId_Z"   )]
      public int gxTpr_Serasaacoesid_Z
      {
         get {
            return gxTv_SdtSerasaAcoes_Serasaacoesid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaAcoes_Serasaacoesid_Z = value;
            SetDirty("Serasaacoesid_Z");
         }

      }

      public void gxTv_SdtSerasaAcoes_Serasaacoesid_Z_SetNull( )
      {
         gxTv_SdtSerasaAcoes_Serasaacoesid_Z = 0;
         SetDirty("Serasaacoesid_Z");
         return  ;
      }

      public bool gxTv_SdtSerasaAcoes_Serasaacoesid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaId_Z" )]
      [  XmlElement( ElementName = "SerasaId_Z"   )]
      public int gxTpr_Serasaid_Z
      {
         get {
            return gxTv_SdtSerasaAcoes_Serasaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaAcoes_Serasaid_Z = value;
            SetDirty("Serasaid_Z");
         }

      }

      public void gxTv_SdtSerasaAcoes_Serasaid_Z_SetNull( )
      {
         gxTv_SdtSerasaAcoes_Serasaid_Z = 0;
         SetDirty("Serasaid_Z");
         return  ;
      }

      public bool gxTv_SdtSerasaAcoes_Serasaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaAcoesData_Z" )]
      [  XmlElement( ElementName = "SerasaAcoesData_Z"  , IsNullable=true )]
      public string gxTpr_Serasaacoesdata_Z_Nullable
      {
         get {
            if ( gxTv_SdtSerasaAcoes_Serasaacoesdata_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtSerasaAcoes_Serasaacoesdata_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtSerasaAcoes_Serasaacoesdata_Z = DateTime.MinValue;
            else
               gxTv_SdtSerasaAcoes_Serasaacoesdata_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Serasaacoesdata_Z
      {
         get {
            return gxTv_SdtSerasaAcoes_Serasaacoesdata_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaAcoes_Serasaacoesdata_Z = value;
            SetDirty("Serasaacoesdata_Z");
         }

      }

      public void gxTv_SdtSerasaAcoes_Serasaacoesdata_Z_SetNull( )
      {
         gxTv_SdtSerasaAcoes_Serasaacoesdata_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Serasaacoesdata_Z");
         return  ;
      }

      public bool gxTv_SdtSerasaAcoes_Serasaacoesdata_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaAcoesNatureza_Z" )]
      [  XmlElement( ElementName = "SerasaAcoesNatureza_Z"   )]
      public string gxTpr_Serasaacoesnatureza_Z
      {
         get {
            return gxTv_SdtSerasaAcoes_Serasaacoesnatureza_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaAcoes_Serasaacoesnatureza_Z = value;
            SetDirty("Serasaacoesnatureza_Z");
         }

      }

      public void gxTv_SdtSerasaAcoes_Serasaacoesnatureza_Z_SetNull( )
      {
         gxTv_SdtSerasaAcoes_Serasaacoesnatureza_Z = "";
         SetDirty("Serasaacoesnatureza_Z");
         return  ;
      }

      public bool gxTv_SdtSerasaAcoes_Serasaacoesnatureza_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaAcoesValor_Z" )]
      [  XmlElement( ElementName = "SerasaAcoesValor_Z"   )]
      public decimal gxTpr_Serasaacoesvalor_Z
      {
         get {
            return gxTv_SdtSerasaAcoes_Serasaacoesvalor_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaAcoes_Serasaacoesvalor_Z = value;
            SetDirty("Serasaacoesvalor_Z");
         }

      }

      public void gxTv_SdtSerasaAcoes_Serasaacoesvalor_Z_SetNull( )
      {
         gxTv_SdtSerasaAcoes_Serasaacoesvalor_Z = 0;
         SetDirty("Serasaacoesvalor_Z");
         return  ;
      }

      public bool gxTv_SdtSerasaAcoes_Serasaacoesvalor_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaAcoesDistribuidor_Z" )]
      [  XmlElement( ElementName = "SerasaAcoesDistribuidor_Z"   )]
      public string gxTpr_Serasaacoesdistribuidor_Z
      {
         get {
            return gxTv_SdtSerasaAcoes_Serasaacoesdistribuidor_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaAcoes_Serasaacoesdistribuidor_Z = value;
            SetDirty("Serasaacoesdistribuidor_Z");
         }

      }

      public void gxTv_SdtSerasaAcoes_Serasaacoesdistribuidor_Z_SetNull( )
      {
         gxTv_SdtSerasaAcoes_Serasaacoesdistribuidor_Z = "";
         SetDirty("Serasaacoesdistribuidor_Z");
         return  ;
      }

      public bool gxTv_SdtSerasaAcoes_Serasaacoesdistribuidor_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaAcoesVara_Z" )]
      [  XmlElement( ElementName = "SerasaAcoesVara_Z"   )]
      public string gxTpr_Serasaacoesvara_Z
      {
         get {
            return gxTv_SdtSerasaAcoes_Serasaacoesvara_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaAcoes_Serasaacoesvara_Z = value;
            SetDirty("Serasaacoesvara_Z");
         }

      }

      public void gxTv_SdtSerasaAcoes_Serasaacoesvara_Z_SetNull( )
      {
         gxTv_SdtSerasaAcoes_Serasaacoesvara_Z = "";
         SetDirty("Serasaacoesvara_Z");
         return  ;
      }

      public bool gxTv_SdtSerasaAcoes_Serasaacoesvara_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaAcoesCidade_Z" )]
      [  XmlElement( ElementName = "SerasaAcoesCidade_Z"   )]
      public string gxTpr_Serasaacoescidade_Z
      {
         get {
            return gxTv_SdtSerasaAcoes_Serasaacoescidade_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaAcoes_Serasaacoescidade_Z = value;
            SetDirty("Serasaacoescidade_Z");
         }

      }

      public void gxTv_SdtSerasaAcoes_Serasaacoescidade_Z_SetNull( )
      {
         gxTv_SdtSerasaAcoes_Serasaacoescidade_Z = "";
         SetDirty("Serasaacoescidade_Z");
         return  ;
      }

      public bool gxTv_SdtSerasaAcoes_Serasaacoescidade_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaAcoesUF_Z" )]
      [  XmlElement( ElementName = "SerasaAcoesUF_Z"   )]
      public string gxTpr_Serasaacoesuf_Z
      {
         get {
            return gxTv_SdtSerasaAcoes_Serasaacoesuf_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaAcoes_Serasaacoesuf_Z = value;
            SetDirty("Serasaacoesuf_Z");
         }

      }

      public void gxTv_SdtSerasaAcoes_Serasaacoesuf_Z_SetNull( )
      {
         gxTv_SdtSerasaAcoes_Serasaacoesuf_Z = "";
         SetDirty("Serasaacoesuf_Z");
         return  ;
      }

      public bool gxTv_SdtSerasaAcoes_Serasaacoesuf_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaAcoesPrincipal_Z" )]
      [  XmlElement( ElementName = "SerasaAcoesPrincipal_Z"   )]
      public string gxTpr_Serasaacoesprincipal_Z
      {
         get {
            return gxTv_SdtSerasaAcoes_Serasaacoesprincipal_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaAcoes_Serasaacoesprincipal_Z = value;
            SetDirty("Serasaacoesprincipal_Z");
         }

      }

      public void gxTv_SdtSerasaAcoes_Serasaacoesprincipal_Z_SetNull( )
      {
         gxTv_SdtSerasaAcoes_Serasaacoesprincipal_Z = "";
         SetDirty("Serasaacoesprincipal_Z");
         return  ;
      }

      public bool gxTv_SdtSerasaAcoes_Serasaacoesprincipal_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaAcoesTipoMoeda_Z" )]
      [  XmlElement( ElementName = "SerasaAcoesTipoMoeda_Z"   )]
      public string gxTpr_Serasaacoestipomoeda_Z
      {
         get {
            return gxTv_SdtSerasaAcoes_Serasaacoestipomoeda_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaAcoes_Serasaacoestipomoeda_Z = value;
            SetDirty("Serasaacoestipomoeda_Z");
         }

      }

      public void gxTv_SdtSerasaAcoes_Serasaacoestipomoeda_Z_SetNull( )
      {
         gxTv_SdtSerasaAcoes_Serasaacoestipomoeda_Z = "";
         SetDirty("Serasaacoestipomoeda_Z");
         return  ;
      }

      public bool gxTv_SdtSerasaAcoes_Serasaacoestipomoeda_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaAcoesQtdOco_Z" )]
      [  XmlElement( ElementName = "SerasaAcoesQtdOco_Z"   )]
      public short gxTpr_Serasaacoesqtdoco_Z
      {
         get {
            return gxTv_SdtSerasaAcoes_Serasaacoesqtdoco_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaAcoes_Serasaacoesqtdoco_Z = value;
            SetDirty("Serasaacoesqtdoco_Z");
         }

      }

      public void gxTv_SdtSerasaAcoes_Serasaacoesqtdoco_Z_SetNull( )
      {
         gxTv_SdtSerasaAcoes_Serasaacoesqtdoco_Z = 0;
         SetDirty("Serasaacoesqtdoco_Z");
         return  ;
      }

      public bool gxTv_SdtSerasaAcoes_Serasaacoesqtdoco_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaId_N" )]
      [  XmlElement( ElementName = "SerasaId_N"   )]
      public short gxTpr_Serasaid_N
      {
         get {
            return gxTv_SdtSerasaAcoes_Serasaid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaAcoes_Serasaid_N = value;
            SetDirty("Serasaid_N");
         }

      }

      public void gxTv_SdtSerasaAcoes_Serasaid_N_SetNull( )
      {
         gxTv_SdtSerasaAcoes_Serasaid_N = 0;
         SetDirty("Serasaid_N");
         return  ;
      }

      public bool gxTv_SdtSerasaAcoes_Serasaid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaAcoesData_N" )]
      [  XmlElement( ElementName = "SerasaAcoesData_N"   )]
      public short gxTpr_Serasaacoesdata_N
      {
         get {
            return gxTv_SdtSerasaAcoes_Serasaacoesdata_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaAcoes_Serasaacoesdata_N = value;
            SetDirty("Serasaacoesdata_N");
         }

      }

      public void gxTv_SdtSerasaAcoes_Serasaacoesdata_N_SetNull( )
      {
         gxTv_SdtSerasaAcoes_Serasaacoesdata_N = 0;
         SetDirty("Serasaacoesdata_N");
         return  ;
      }

      public bool gxTv_SdtSerasaAcoes_Serasaacoesdata_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaAcoesNatureza_N" )]
      [  XmlElement( ElementName = "SerasaAcoesNatureza_N"   )]
      public short gxTpr_Serasaacoesnatureza_N
      {
         get {
            return gxTv_SdtSerasaAcoes_Serasaacoesnatureza_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaAcoes_Serasaacoesnatureza_N = value;
            SetDirty("Serasaacoesnatureza_N");
         }

      }

      public void gxTv_SdtSerasaAcoes_Serasaacoesnatureza_N_SetNull( )
      {
         gxTv_SdtSerasaAcoes_Serasaacoesnatureza_N = 0;
         SetDirty("Serasaacoesnatureza_N");
         return  ;
      }

      public bool gxTv_SdtSerasaAcoes_Serasaacoesnatureza_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaAcoesValor_N" )]
      [  XmlElement( ElementName = "SerasaAcoesValor_N"   )]
      public short gxTpr_Serasaacoesvalor_N
      {
         get {
            return gxTv_SdtSerasaAcoes_Serasaacoesvalor_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaAcoes_Serasaacoesvalor_N = value;
            SetDirty("Serasaacoesvalor_N");
         }

      }

      public void gxTv_SdtSerasaAcoes_Serasaacoesvalor_N_SetNull( )
      {
         gxTv_SdtSerasaAcoes_Serasaacoesvalor_N = 0;
         SetDirty("Serasaacoesvalor_N");
         return  ;
      }

      public bool gxTv_SdtSerasaAcoes_Serasaacoesvalor_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaAcoesDistribuidor_N" )]
      [  XmlElement( ElementName = "SerasaAcoesDistribuidor_N"   )]
      public short gxTpr_Serasaacoesdistribuidor_N
      {
         get {
            return gxTv_SdtSerasaAcoes_Serasaacoesdistribuidor_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaAcoes_Serasaacoesdistribuidor_N = value;
            SetDirty("Serasaacoesdistribuidor_N");
         }

      }

      public void gxTv_SdtSerasaAcoes_Serasaacoesdistribuidor_N_SetNull( )
      {
         gxTv_SdtSerasaAcoes_Serasaacoesdistribuidor_N = 0;
         SetDirty("Serasaacoesdistribuidor_N");
         return  ;
      }

      public bool gxTv_SdtSerasaAcoes_Serasaacoesdistribuidor_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaAcoesVara_N" )]
      [  XmlElement( ElementName = "SerasaAcoesVara_N"   )]
      public short gxTpr_Serasaacoesvara_N
      {
         get {
            return gxTv_SdtSerasaAcoes_Serasaacoesvara_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaAcoes_Serasaacoesvara_N = value;
            SetDirty("Serasaacoesvara_N");
         }

      }

      public void gxTv_SdtSerasaAcoes_Serasaacoesvara_N_SetNull( )
      {
         gxTv_SdtSerasaAcoes_Serasaacoesvara_N = 0;
         SetDirty("Serasaacoesvara_N");
         return  ;
      }

      public bool gxTv_SdtSerasaAcoes_Serasaacoesvara_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaAcoesCidade_N" )]
      [  XmlElement( ElementName = "SerasaAcoesCidade_N"   )]
      public short gxTpr_Serasaacoescidade_N
      {
         get {
            return gxTv_SdtSerasaAcoes_Serasaacoescidade_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaAcoes_Serasaacoescidade_N = value;
            SetDirty("Serasaacoescidade_N");
         }

      }

      public void gxTv_SdtSerasaAcoes_Serasaacoescidade_N_SetNull( )
      {
         gxTv_SdtSerasaAcoes_Serasaacoescidade_N = 0;
         SetDirty("Serasaacoescidade_N");
         return  ;
      }

      public bool gxTv_SdtSerasaAcoes_Serasaacoescidade_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaAcoesUF_N" )]
      [  XmlElement( ElementName = "SerasaAcoesUF_N"   )]
      public short gxTpr_Serasaacoesuf_N
      {
         get {
            return gxTv_SdtSerasaAcoes_Serasaacoesuf_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaAcoes_Serasaacoesuf_N = value;
            SetDirty("Serasaacoesuf_N");
         }

      }

      public void gxTv_SdtSerasaAcoes_Serasaacoesuf_N_SetNull( )
      {
         gxTv_SdtSerasaAcoes_Serasaacoesuf_N = 0;
         SetDirty("Serasaacoesuf_N");
         return  ;
      }

      public bool gxTv_SdtSerasaAcoes_Serasaacoesuf_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaAcoesPrincipal_N" )]
      [  XmlElement( ElementName = "SerasaAcoesPrincipal_N"   )]
      public short gxTpr_Serasaacoesprincipal_N
      {
         get {
            return gxTv_SdtSerasaAcoes_Serasaacoesprincipal_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaAcoes_Serasaacoesprincipal_N = value;
            SetDirty("Serasaacoesprincipal_N");
         }

      }

      public void gxTv_SdtSerasaAcoes_Serasaacoesprincipal_N_SetNull( )
      {
         gxTv_SdtSerasaAcoes_Serasaacoesprincipal_N = 0;
         SetDirty("Serasaacoesprincipal_N");
         return  ;
      }

      public bool gxTv_SdtSerasaAcoes_Serasaacoesprincipal_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaAcoesTipoMoeda_N" )]
      [  XmlElement( ElementName = "SerasaAcoesTipoMoeda_N"   )]
      public short gxTpr_Serasaacoestipomoeda_N
      {
         get {
            return gxTv_SdtSerasaAcoes_Serasaacoestipomoeda_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaAcoes_Serasaacoestipomoeda_N = value;
            SetDirty("Serasaacoestipomoeda_N");
         }

      }

      public void gxTv_SdtSerasaAcoes_Serasaacoestipomoeda_N_SetNull( )
      {
         gxTv_SdtSerasaAcoes_Serasaacoestipomoeda_N = 0;
         SetDirty("Serasaacoestipomoeda_N");
         return  ;
      }

      public bool gxTv_SdtSerasaAcoes_Serasaacoestipomoeda_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaAcoesQtdOco_N" )]
      [  XmlElement( ElementName = "SerasaAcoesQtdOco_N"   )]
      public short gxTpr_Serasaacoesqtdoco_N
      {
         get {
            return gxTv_SdtSerasaAcoes_Serasaacoesqtdoco_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaAcoes_Serasaacoesqtdoco_N = value;
            SetDirty("Serasaacoesqtdoco_N");
         }

      }

      public void gxTv_SdtSerasaAcoes_Serasaacoesqtdoco_N_SetNull( )
      {
         gxTv_SdtSerasaAcoes_Serasaacoesqtdoco_N = 0;
         SetDirty("Serasaacoesqtdoco_N");
         return  ;
      }

      public bool gxTv_SdtSerasaAcoes_Serasaacoesqtdoco_N_IsNull( )
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
         gxTv_SdtSerasaAcoes_Serasaacoesdata = DateTime.MinValue;
         gxTv_SdtSerasaAcoes_Serasaacoesnatureza = "";
         gxTv_SdtSerasaAcoes_Serasaacoesdistribuidor = "";
         gxTv_SdtSerasaAcoes_Serasaacoesvara = "";
         gxTv_SdtSerasaAcoes_Serasaacoescidade = "";
         gxTv_SdtSerasaAcoes_Serasaacoesuf = "";
         gxTv_SdtSerasaAcoes_Serasaacoesprincipal = "";
         gxTv_SdtSerasaAcoes_Serasaacoestipomoeda = "";
         gxTv_SdtSerasaAcoes_Mode = "";
         gxTv_SdtSerasaAcoes_Serasaacoesdata_Z = DateTime.MinValue;
         gxTv_SdtSerasaAcoes_Serasaacoesnatureza_Z = "";
         gxTv_SdtSerasaAcoes_Serasaacoesdistribuidor_Z = "";
         gxTv_SdtSerasaAcoes_Serasaacoesvara_Z = "";
         gxTv_SdtSerasaAcoes_Serasaacoescidade_Z = "";
         gxTv_SdtSerasaAcoes_Serasaacoesuf_Z = "";
         gxTv_SdtSerasaAcoes_Serasaacoesprincipal_Z = "";
         gxTv_SdtSerasaAcoes_Serasaacoestipomoeda_Z = "";
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "serasaacoes", "GeneXus.Programs.serasaacoes_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtSerasaAcoes_Serasaacoesqtdoco ;
      private short gxTv_SdtSerasaAcoes_Initialized ;
      private short gxTv_SdtSerasaAcoes_Serasaacoesqtdoco_Z ;
      private short gxTv_SdtSerasaAcoes_Serasaid_N ;
      private short gxTv_SdtSerasaAcoes_Serasaacoesdata_N ;
      private short gxTv_SdtSerasaAcoes_Serasaacoesnatureza_N ;
      private short gxTv_SdtSerasaAcoes_Serasaacoesvalor_N ;
      private short gxTv_SdtSerasaAcoes_Serasaacoesdistribuidor_N ;
      private short gxTv_SdtSerasaAcoes_Serasaacoesvara_N ;
      private short gxTv_SdtSerasaAcoes_Serasaacoescidade_N ;
      private short gxTv_SdtSerasaAcoes_Serasaacoesuf_N ;
      private short gxTv_SdtSerasaAcoes_Serasaacoesprincipal_N ;
      private short gxTv_SdtSerasaAcoes_Serasaacoestipomoeda_N ;
      private short gxTv_SdtSerasaAcoes_Serasaacoesqtdoco_N ;
      private int gxTv_SdtSerasaAcoes_Serasaacoesid ;
      private int gxTv_SdtSerasaAcoes_Serasaid ;
      private int gxTv_SdtSerasaAcoes_Serasaacoesid_Z ;
      private int gxTv_SdtSerasaAcoes_Serasaid_Z ;
      private decimal gxTv_SdtSerasaAcoes_Serasaacoesvalor ;
      private decimal gxTv_SdtSerasaAcoes_Serasaacoesvalor_Z ;
      private string gxTv_SdtSerasaAcoes_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtSerasaAcoes_Serasaacoesdata ;
      private DateTime gxTv_SdtSerasaAcoes_Serasaacoesdata_Z ;
      private string gxTv_SdtSerasaAcoes_Serasaacoesnatureza ;
      private string gxTv_SdtSerasaAcoes_Serasaacoesdistribuidor ;
      private string gxTv_SdtSerasaAcoes_Serasaacoesvara ;
      private string gxTv_SdtSerasaAcoes_Serasaacoescidade ;
      private string gxTv_SdtSerasaAcoes_Serasaacoesuf ;
      private string gxTv_SdtSerasaAcoes_Serasaacoesprincipal ;
      private string gxTv_SdtSerasaAcoes_Serasaacoestipomoeda ;
      private string gxTv_SdtSerasaAcoes_Serasaacoesnatureza_Z ;
      private string gxTv_SdtSerasaAcoes_Serasaacoesdistribuidor_Z ;
      private string gxTv_SdtSerasaAcoes_Serasaacoesvara_Z ;
      private string gxTv_SdtSerasaAcoes_Serasaacoescidade_Z ;
      private string gxTv_SdtSerasaAcoes_Serasaacoesuf_Z ;
      private string gxTv_SdtSerasaAcoes_Serasaacoesprincipal_Z ;
      private string gxTv_SdtSerasaAcoes_Serasaacoestipomoeda_Z ;
   }

   [DataContract(Name = @"SerasaAcoes", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtSerasaAcoes_RESTInterface : GxGenericCollectionItem<SdtSerasaAcoes>
   {
      public SdtSerasaAcoes_RESTInterface( ) : base()
      {
      }

      public SdtSerasaAcoes_RESTInterface( SdtSerasaAcoes psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "SerasaAcoesId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Serasaacoesid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Serasaacoesid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Serasaacoesid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "SerasaId" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Serasaid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Serasaid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Serasaid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "SerasaAcoesData" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Serasaacoesdata
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Serasaacoesdata) ;
         }

         set {
            sdt.gxTpr_Serasaacoesdata = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "SerasaAcoesNatureza" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Serasaacoesnatureza
      {
         get {
            return sdt.gxTpr_Serasaacoesnatureza ;
         }

         set {
            sdt.gxTpr_Serasaacoesnatureza = value;
         }

      }

      [DataMember( Name = "SerasaAcoesValor" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Serasaacoesvalor
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Serasaacoesvalor, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Serasaacoesvalor = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "SerasaAcoesDistribuidor" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Serasaacoesdistribuidor
      {
         get {
            return sdt.gxTpr_Serasaacoesdistribuidor ;
         }

         set {
            sdt.gxTpr_Serasaacoesdistribuidor = value;
         }

      }

      [DataMember( Name = "SerasaAcoesVara" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Serasaacoesvara
      {
         get {
            return sdt.gxTpr_Serasaacoesvara ;
         }

         set {
            sdt.gxTpr_Serasaacoesvara = value;
         }

      }

      [DataMember( Name = "SerasaAcoesCidade" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Serasaacoescidade
      {
         get {
            return sdt.gxTpr_Serasaacoescidade ;
         }

         set {
            sdt.gxTpr_Serasaacoescidade = value;
         }

      }

      [DataMember( Name = "SerasaAcoesUF" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Serasaacoesuf
      {
         get {
            return sdt.gxTpr_Serasaacoesuf ;
         }

         set {
            sdt.gxTpr_Serasaacoesuf = value;
         }

      }

      [DataMember( Name = "SerasaAcoesPrincipal" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Serasaacoesprincipal
      {
         get {
            return sdt.gxTpr_Serasaacoesprincipal ;
         }

         set {
            sdt.gxTpr_Serasaacoesprincipal = value;
         }

      }

      [DataMember( Name = "SerasaAcoesTipoMoeda" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Serasaacoestipomoeda
      {
         get {
            return sdt.gxTpr_Serasaacoestipomoeda ;
         }

         set {
            sdt.gxTpr_Serasaacoestipomoeda = value;
         }

      }

      [DataMember( Name = "SerasaAcoesQtdOco" , Order = 11 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Serasaacoesqtdoco
      {
         get {
            return sdt.gxTpr_Serasaacoesqtdoco ;
         }

         set {
            sdt.gxTpr_Serasaacoesqtdoco = (short)(value.HasValue ? value.Value : 0);
         }

      }

      public SdtSerasaAcoes sdt
      {
         get {
            return (SdtSerasaAcoes)Sdt ;
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
            sdt = new SdtSerasaAcoes() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 12 )]
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

   [DataContract(Name = @"SerasaAcoes", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtSerasaAcoes_RESTLInterface : GxGenericCollectionItem<SdtSerasaAcoes>
   {
      public SdtSerasaAcoes_RESTLInterface( ) : base()
      {
      }

      public SdtSerasaAcoes_RESTLInterface( SdtSerasaAcoes psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "SerasaAcoesData" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Serasaacoesdata
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Serasaacoesdata) ;
         }

         set {
            sdt.gxTpr_Serasaacoesdata = DateTimeUtil.CToD2( value);
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

      public SdtSerasaAcoes sdt
      {
         get {
            return (SdtSerasaAcoes)Sdt ;
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
            sdt = new SdtSerasaAcoes() ;
         }
      }

   }

}
