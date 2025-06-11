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
   [XmlRoot(ElementName = "NotaFiscalItem" )]
   [XmlType(TypeName =  "NotaFiscalItem" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtNotaFiscalItem : GxSilentTrnSdt
   {
      public SdtNotaFiscalItem( )
      {
      }

      public SdtNotaFiscalItem( IGxContext context )
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

      public void Load( Guid AV830NotaFiscalItemId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV830NotaFiscalItemId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"NotaFiscalItemId", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "NotaFiscalItem");
         metadata.Set("BT", "NotaFiscalItem");
         metadata.Set("PK", "[ \"NotaFiscalItemId\" ]");
         metadata.Set("PKAssigned", "[ \"NotaFiscalItemId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"NotaFiscalId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"PropostaId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Notafiscalitemid_Z");
         state.Add("gxTpr_Propostaid_Z");
         state.Add("gxTpr_Notafiscalid_Z");
         state.Add("gxTpr_Notafiscalitemcodigo_Z");
         state.Add("gxTpr_Notafiscalitemcfop_Z");
         state.Add("gxTpr_Notafiscalitemdescricao_Z");
         state.Add("gxTpr_Notafiscalitemncm_Z");
         state.Add("gxTpr_Notafiscalitemcodigoean_Z");
         state.Add("gxTpr_Notafiscalitemunidadecomercial_Z");
         state.Add("gxTpr_Notafiscalitemquantidade_Z");
         state.Add("gxTpr_Notafiscalitemvalorunitario_Z");
         state.Add("gxTpr_Notafiscalitemvalortotal_Z");
         state.Add("gxTpr_Notafiscalitemcodbargtin_Z");
         state.Add("gxTpr_Notafiscalitemunidadetributavel_Z");
         state.Add("gxTpr_Notafiscalitemvaloruntributavel_Z");
         state.Add("gxTpr_Notafiscalitemqtdtributavel_Z");
         state.Add("gxTpr_Notafiscalitemvalorfrete_Z");
         state.Add("gxTpr_Notafiscalitemdesconto_Z");
         state.Add("gxTpr_Notafiscalitemindicadorvalortotal_Z");
         state.Add("gxTpr_Notafiscalitemnumpedido_Z");
         state.Add("gxTpr_Notafiscalitemnumitem_Z");
         state.Add("gxTpr_Notafiscalitemvendido_Z");
         state.Add("gxTpr_Propostaid_N");
         state.Add("gxTpr_Notafiscalid_N");
         state.Add("gxTpr_Notafiscalitemcodigo_N");
         state.Add("gxTpr_Notafiscalitemcfop_N");
         state.Add("gxTpr_Notafiscalitemdescricao_N");
         state.Add("gxTpr_Notafiscalitemncm_N");
         state.Add("gxTpr_Notafiscalitemcodigoean_N");
         state.Add("gxTpr_Notafiscalitemunidadecomercial_N");
         state.Add("gxTpr_Notafiscalitemquantidade_N");
         state.Add("gxTpr_Notafiscalitemvalorunitario_N");
         state.Add("gxTpr_Notafiscalitemvalortotal_N");
         state.Add("gxTpr_Notafiscalitemcodbargtin_N");
         state.Add("gxTpr_Notafiscalitemunidadetributavel_N");
         state.Add("gxTpr_Notafiscalitemvaloruntributavel_N");
         state.Add("gxTpr_Notafiscalitemqtdtributavel_N");
         state.Add("gxTpr_Notafiscalitemvalorfrete_N");
         state.Add("gxTpr_Notafiscalitemdesconto_N");
         state.Add("gxTpr_Notafiscalitemindicadorvalortotal_N");
         state.Add("gxTpr_Notafiscalitemnumpedido_N");
         state.Add("gxTpr_Notafiscalitemnumitem_N");
         state.Add("gxTpr_Notafiscalitemvendido_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtNotaFiscalItem sdt;
         sdt = (SdtNotaFiscalItem)(source);
         gxTv_SdtNotaFiscalItem_Notafiscalitemid = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemid ;
         gxTv_SdtNotaFiscalItem_Propostaid = sdt.gxTv_SdtNotaFiscalItem_Propostaid ;
         gxTv_SdtNotaFiscalItem_Notafiscalid = sdt.gxTv_SdtNotaFiscalItem_Notafiscalid ;
         gxTv_SdtNotaFiscalItem_Notafiscalitemcodigo = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemcodigo ;
         gxTv_SdtNotaFiscalItem_Notafiscalitemcfop = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemcfop ;
         gxTv_SdtNotaFiscalItem_Notafiscalitemdescricao = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemdescricao ;
         gxTv_SdtNotaFiscalItem_Notafiscalitemncm = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemncm ;
         gxTv_SdtNotaFiscalItem_Notafiscalitemcodigoean = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemcodigoean ;
         gxTv_SdtNotaFiscalItem_Notafiscalitemunidadecomercial = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemunidadecomercial ;
         gxTv_SdtNotaFiscalItem_Notafiscalitemquantidade = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemquantidade ;
         gxTv_SdtNotaFiscalItem_Notafiscalitemvalorunitario = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemvalorunitario ;
         gxTv_SdtNotaFiscalItem_Notafiscalitemvalortotal = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemvalortotal ;
         gxTv_SdtNotaFiscalItem_Notafiscalitemcodbargtin = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemcodbargtin ;
         gxTv_SdtNotaFiscalItem_Notafiscalitemunidadetributavel = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemunidadetributavel ;
         gxTv_SdtNotaFiscalItem_Notafiscalitemvaloruntributavel = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemvaloruntributavel ;
         gxTv_SdtNotaFiscalItem_Notafiscalitemqtdtributavel = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemqtdtributavel ;
         gxTv_SdtNotaFiscalItem_Notafiscalitemvalorfrete = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemvalorfrete ;
         gxTv_SdtNotaFiscalItem_Notafiscalitemdesconto = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemdesconto ;
         gxTv_SdtNotaFiscalItem_Notafiscalitemindicadorvalortotal = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemindicadorvalortotal ;
         gxTv_SdtNotaFiscalItem_Notafiscalitemnumpedido = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemnumpedido ;
         gxTv_SdtNotaFiscalItem_Notafiscalitemnumitem = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemnumitem ;
         gxTv_SdtNotaFiscalItem_Notafiscalitemvendido = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemvendido ;
         gxTv_SdtNotaFiscalItem_Mode = sdt.gxTv_SdtNotaFiscalItem_Mode ;
         gxTv_SdtNotaFiscalItem_Initialized = sdt.gxTv_SdtNotaFiscalItem_Initialized ;
         gxTv_SdtNotaFiscalItem_Notafiscalitemid_Z = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemid_Z ;
         gxTv_SdtNotaFiscalItem_Propostaid_Z = sdt.gxTv_SdtNotaFiscalItem_Propostaid_Z ;
         gxTv_SdtNotaFiscalItem_Notafiscalid_Z = sdt.gxTv_SdtNotaFiscalItem_Notafiscalid_Z ;
         gxTv_SdtNotaFiscalItem_Notafiscalitemcodigo_Z = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemcodigo_Z ;
         gxTv_SdtNotaFiscalItem_Notafiscalitemcfop_Z = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemcfop_Z ;
         gxTv_SdtNotaFiscalItem_Notafiscalitemdescricao_Z = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemdescricao_Z ;
         gxTv_SdtNotaFiscalItem_Notafiscalitemncm_Z = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemncm_Z ;
         gxTv_SdtNotaFiscalItem_Notafiscalitemcodigoean_Z = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemcodigoean_Z ;
         gxTv_SdtNotaFiscalItem_Notafiscalitemunidadecomercial_Z = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemunidadecomercial_Z ;
         gxTv_SdtNotaFiscalItem_Notafiscalitemquantidade_Z = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemquantidade_Z ;
         gxTv_SdtNotaFiscalItem_Notafiscalitemvalorunitario_Z = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemvalorunitario_Z ;
         gxTv_SdtNotaFiscalItem_Notafiscalitemvalortotal_Z = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemvalortotal_Z ;
         gxTv_SdtNotaFiscalItem_Notafiscalitemcodbargtin_Z = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemcodbargtin_Z ;
         gxTv_SdtNotaFiscalItem_Notafiscalitemunidadetributavel_Z = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemunidadetributavel_Z ;
         gxTv_SdtNotaFiscalItem_Notafiscalitemvaloruntributavel_Z = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemvaloruntributavel_Z ;
         gxTv_SdtNotaFiscalItem_Notafiscalitemqtdtributavel_Z = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemqtdtributavel_Z ;
         gxTv_SdtNotaFiscalItem_Notafiscalitemvalorfrete_Z = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemvalorfrete_Z ;
         gxTv_SdtNotaFiscalItem_Notafiscalitemdesconto_Z = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemdesconto_Z ;
         gxTv_SdtNotaFiscalItem_Notafiscalitemindicadorvalortotal_Z = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemindicadorvalortotal_Z ;
         gxTv_SdtNotaFiscalItem_Notafiscalitemnumpedido_Z = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemnumpedido_Z ;
         gxTv_SdtNotaFiscalItem_Notafiscalitemnumitem_Z = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemnumitem_Z ;
         gxTv_SdtNotaFiscalItem_Notafiscalitemvendido_Z = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemvendido_Z ;
         gxTv_SdtNotaFiscalItem_Propostaid_N = sdt.gxTv_SdtNotaFiscalItem_Propostaid_N ;
         gxTv_SdtNotaFiscalItem_Notafiscalid_N = sdt.gxTv_SdtNotaFiscalItem_Notafiscalid_N ;
         gxTv_SdtNotaFiscalItem_Notafiscalitemcodigo_N = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemcodigo_N ;
         gxTv_SdtNotaFiscalItem_Notafiscalitemcfop_N = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemcfop_N ;
         gxTv_SdtNotaFiscalItem_Notafiscalitemdescricao_N = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemdescricao_N ;
         gxTv_SdtNotaFiscalItem_Notafiscalitemncm_N = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemncm_N ;
         gxTv_SdtNotaFiscalItem_Notafiscalitemcodigoean_N = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemcodigoean_N ;
         gxTv_SdtNotaFiscalItem_Notafiscalitemunidadecomercial_N = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemunidadecomercial_N ;
         gxTv_SdtNotaFiscalItem_Notafiscalitemquantidade_N = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemquantidade_N ;
         gxTv_SdtNotaFiscalItem_Notafiscalitemvalorunitario_N = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemvalorunitario_N ;
         gxTv_SdtNotaFiscalItem_Notafiscalitemvalortotal_N = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemvalortotal_N ;
         gxTv_SdtNotaFiscalItem_Notafiscalitemcodbargtin_N = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemcodbargtin_N ;
         gxTv_SdtNotaFiscalItem_Notafiscalitemunidadetributavel_N = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemunidadetributavel_N ;
         gxTv_SdtNotaFiscalItem_Notafiscalitemvaloruntributavel_N = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemvaloruntributavel_N ;
         gxTv_SdtNotaFiscalItem_Notafiscalitemqtdtributavel_N = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemqtdtributavel_N ;
         gxTv_SdtNotaFiscalItem_Notafiscalitemvalorfrete_N = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemvalorfrete_N ;
         gxTv_SdtNotaFiscalItem_Notafiscalitemdesconto_N = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemdesconto_N ;
         gxTv_SdtNotaFiscalItem_Notafiscalitemindicadorvalortotal_N = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemindicadorvalortotal_N ;
         gxTv_SdtNotaFiscalItem_Notafiscalitemnumpedido_N = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemnumpedido_N ;
         gxTv_SdtNotaFiscalItem_Notafiscalitemnumitem_N = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemnumitem_N ;
         gxTv_SdtNotaFiscalItem_Notafiscalitemvendido_N = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemvendido_N ;
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
         AddObjectProperty("NotaFiscalItemId", gxTv_SdtNotaFiscalItem_Notafiscalitemid, false, includeNonInitialized);
         AddObjectProperty("PropostaId", gxTv_SdtNotaFiscalItem_Propostaid, false, includeNonInitialized);
         AddObjectProperty("PropostaId_N", gxTv_SdtNotaFiscalItem_Propostaid_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalId", gxTv_SdtNotaFiscalItem_Notafiscalid, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalId_N", gxTv_SdtNotaFiscalItem_Notafiscalid_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalItemCodigo", gxTv_SdtNotaFiscalItem_Notafiscalitemcodigo, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalItemCodigo_N", gxTv_SdtNotaFiscalItem_Notafiscalitemcodigo_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalItemCFOP", gxTv_SdtNotaFiscalItem_Notafiscalitemcfop, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalItemCFOP_N", gxTv_SdtNotaFiscalItem_Notafiscalitemcfop_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalItemDescricao", gxTv_SdtNotaFiscalItem_Notafiscalitemdescricao, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalItemDescricao_N", gxTv_SdtNotaFiscalItem_Notafiscalitemdescricao_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalItemNCM", gxTv_SdtNotaFiscalItem_Notafiscalitemncm, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalItemNCM_N", gxTv_SdtNotaFiscalItem_Notafiscalitemncm_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalItemCodigoEAN", gxTv_SdtNotaFiscalItem_Notafiscalitemcodigoean, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalItemCodigoEAN_N", gxTv_SdtNotaFiscalItem_Notafiscalitemcodigoean_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalItemUnidadeComercial", gxTv_SdtNotaFiscalItem_Notafiscalitemunidadecomercial, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalItemUnidadeComercial_N", gxTv_SdtNotaFiscalItem_Notafiscalitemunidadecomercial_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalItemQuantidade", StringUtil.LTrim( StringUtil.Str( gxTv_SdtNotaFiscalItem_Notafiscalitemquantidade, 18, 6)), false, includeNonInitialized);
         AddObjectProperty("NotaFiscalItemQuantidade_N", gxTv_SdtNotaFiscalItem_Notafiscalitemquantidade_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalItemValorUnitario", StringUtil.LTrim( StringUtil.Str( gxTv_SdtNotaFiscalItem_Notafiscalitemvalorunitario, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("NotaFiscalItemValorUnitario_N", gxTv_SdtNotaFiscalItem_Notafiscalitemvalorunitario_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalItemValorTotal", StringUtil.LTrim( StringUtil.Str( gxTv_SdtNotaFiscalItem_Notafiscalitemvalortotal, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("NotaFiscalItemValorTotal_N", gxTv_SdtNotaFiscalItem_Notafiscalitemvalortotal_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalItemCodBarGTIN", gxTv_SdtNotaFiscalItem_Notafiscalitemcodbargtin, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalItemCodBarGTIN_N", gxTv_SdtNotaFiscalItem_Notafiscalitemcodbargtin_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalItemUnidadeTributavel", gxTv_SdtNotaFiscalItem_Notafiscalitemunidadetributavel, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalItemUnidadeTributavel_N", gxTv_SdtNotaFiscalItem_Notafiscalitemunidadetributavel_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalItemValorUnTributavel", StringUtil.LTrim( StringUtil.Str( gxTv_SdtNotaFiscalItem_Notafiscalitemvaloruntributavel, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("NotaFiscalItemValorUnTributavel_N", gxTv_SdtNotaFiscalItem_Notafiscalitemvaloruntributavel_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalItemQtdTributavel", StringUtil.LTrim( StringUtil.Str( gxTv_SdtNotaFiscalItem_Notafiscalitemqtdtributavel, 18, 6)), false, includeNonInitialized);
         AddObjectProperty("NotaFiscalItemQtdTributavel_N", gxTv_SdtNotaFiscalItem_Notafiscalitemqtdtributavel_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalItemValorFrete", StringUtil.LTrim( StringUtil.Str( gxTv_SdtNotaFiscalItem_Notafiscalitemvalorfrete, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("NotaFiscalItemValorFrete_N", gxTv_SdtNotaFiscalItem_Notafiscalitemvalorfrete_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalItemDesconto", StringUtil.LTrim( StringUtil.Str( gxTv_SdtNotaFiscalItem_Notafiscalitemdesconto, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("NotaFiscalItemDesconto_N", gxTv_SdtNotaFiscalItem_Notafiscalitemdesconto_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalItemIndicadorValorTotal", gxTv_SdtNotaFiscalItem_Notafiscalitemindicadorvalortotal, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalItemIndicadorValorTotal_N", gxTv_SdtNotaFiscalItem_Notafiscalitemindicadorvalortotal_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalItemNumPedido", gxTv_SdtNotaFiscalItem_Notafiscalitemnumpedido, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalItemNumPedido_N", gxTv_SdtNotaFiscalItem_Notafiscalitemnumpedido_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalItemNumItem", gxTv_SdtNotaFiscalItem_Notafiscalitemnumitem, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalItemNumItem_N", gxTv_SdtNotaFiscalItem_Notafiscalitemnumitem_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalItemVendido", gxTv_SdtNotaFiscalItem_Notafiscalitemvendido, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalItemVendido_N", gxTv_SdtNotaFiscalItem_Notafiscalitemvendido_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtNotaFiscalItem_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtNotaFiscalItem_Initialized, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalItemId_Z", gxTv_SdtNotaFiscalItem_Notafiscalitemid_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaId_Z", gxTv_SdtNotaFiscalItem_Propostaid_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalId_Z", gxTv_SdtNotaFiscalItem_Notafiscalid_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalItemCodigo_Z", gxTv_SdtNotaFiscalItem_Notafiscalitemcodigo_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalItemCFOP_Z", gxTv_SdtNotaFiscalItem_Notafiscalitemcfop_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalItemDescricao_Z", gxTv_SdtNotaFiscalItem_Notafiscalitemdescricao_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalItemNCM_Z", gxTv_SdtNotaFiscalItem_Notafiscalitemncm_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalItemCodigoEAN_Z", gxTv_SdtNotaFiscalItem_Notafiscalitemcodigoean_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalItemUnidadeComercial_Z", gxTv_SdtNotaFiscalItem_Notafiscalitemunidadecomercial_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalItemQuantidade_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtNotaFiscalItem_Notafiscalitemquantidade_Z, 18, 6)), false, includeNonInitialized);
            AddObjectProperty("NotaFiscalItemValorUnitario_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtNotaFiscalItem_Notafiscalitemvalorunitario_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("NotaFiscalItemValorTotal_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtNotaFiscalItem_Notafiscalitemvalortotal_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("NotaFiscalItemCodBarGTIN_Z", gxTv_SdtNotaFiscalItem_Notafiscalitemcodbargtin_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalItemUnidadeTributavel_Z", gxTv_SdtNotaFiscalItem_Notafiscalitemunidadetributavel_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalItemValorUnTributavel_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtNotaFiscalItem_Notafiscalitemvaloruntributavel_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("NotaFiscalItemQtdTributavel_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtNotaFiscalItem_Notafiscalitemqtdtributavel_Z, 18, 6)), false, includeNonInitialized);
            AddObjectProperty("NotaFiscalItemValorFrete_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtNotaFiscalItem_Notafiscalitemvalorfrete_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("NotaFiscalItemDesconto_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtNotaFiscalItem_Notafiscalitemdesconto_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("NotaFiscalItemIndicadorValorTotal_Z", gxTv_SdtNotaFiscalItem_Notafiscalitemindicadorvalortotal_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalItemNumPedido_Z", gxTv_SdtNotaFiscalItem_Notafiscalitemnumpedido_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalItemNumItem_Z", gxTv_SdtNotaFiscalItem_Notafiscalitemnumitem_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalItemVendido_Z", gxTv_SdtNotaFiscalItem_Notafiscalitemvendido_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaId_N", gxTv_SdtNotaFiscalItem_Propostaid_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalId_N", gxTv_SdtNotaFiscalItem_Notafiscalid_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalItemCodigo_N", gxTv_SdtNotaFiscalItem_Notafiscalitemcodigo_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalItemCFOP_N", gxTv_SdtNotaFiscalItem_Notafiscalitemcfop_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalItemDescricao_N", gxTv_SdtNotaFiscalItem_Notafiscalitemdescricao_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalItemNCM_N", gxTv_SdtNotaFiscalItem_Notafiscalitemncm_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalItemCodigoEAN_N", gxTv_SdtNotaFiscalItem_Notafiscalitemcodigoean_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalItemUnidadeComercial_N", gxTv_SdtNotaFiscalItem_Notafiscalitemunidadecomercial_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalItemQuantidade_N", gxTv_SdtNotaFiscalItem_Notafiscalitemquantidade_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalItemValorUnitario_N", gxTv_SdtNotaFiscalItem_Notafiscalitemvalorunitario_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalItemValorTotal_N", gxTv_SdtNotaFiscalItem_Notafiscalitemvalortotal_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalItemCodBarGTIN_N", gxTv_SdtNotaFiscalItem_Notafiscalitemcodbargtin_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalItemUnidadeTributavel_N", gxTv_SdtNotaFiscalItem_Notafiscalitemunidadetributavel_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalItemValorUnTributavel_N", gxTv_SdtNotaFiscalItem_Notafiscalitemvaloruntributavel_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalItemQtdTributavel_N", gxTv_SdtNotaFiscalItem_Notafiscalitemqtdtributavel_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalItemValorFrete_N", gxTv_SdtNotaFiscalItem_Notafiscalitemvalorfrete_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalItemDesconto_N", gxTv_SdtNotaFiscalItem_Notafiscalitemdesconto_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalItemIndicadorValorTotal_N", gxTv_SdtNotaFiscalItem_Notafiscalitemindicadorvalortotal_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalItemNumPedido_N", gxTv_SdtNotaFiscalItem_Notafiscalitemnumpedido_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalItemNumItem_N", gxTv_SdtNotaFiscalItem_Notafiscalitemnumitem_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalItemVendido_N", gxTv_SdtNotaFiscalItem_Notafiscalitemvendido_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtNotaFiscalItem sdt )
      {
         if ( sdt.IsDirty("NotaFiscalItemId") )
         {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemid = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemid ;
         }
         if ( sdt.IsDirty("PropostaId") )
         {
            gxTv_SdtNotaFiscalItem_Propostaid_N = (short)(sdt.gxTv_SdtNotaFiscalItem_Propostaid_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Propostaid = sdt.gxTv_SdtNotaFiscalItem_Propostaid ;
         }
         if ( sdt.IsDirty("NotaFiscalId") )
         {
            gxTv_SdtNotaFiscalItem_Notafiscalid_N = (short)(sdt.gxTv_SdtNotaFiscalItem_Notafiscalid_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalid = sdt.gxTv_SdtNotaFiscalItem_Notafiscalid ;
         }
         if ( sdt.IsDirty("NotaFiscalItemCodigo") )
         {
            gxTv_SdtNotaFiscalItem_Notafiscalitemcodigo_N = (short)(sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemcodigo_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemcodigo = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemcodigo ;
         }
         if ( sdt.IsDirty("NotaFiscalItemCFOP") )
         {
            gxTv_SdtNotaFiscalItem_Notafiscalitemcfop_N = (short)(sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemcfop_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemcfop = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemcfop ;
         }
         if ( sdt.IsDirty("NotaFiscalItemDescricao") )
         {
            gxTv_SdtNotaFiscalItem_Notafiscalitemdescricao_N = (short)(sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemdescricao_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemdescricao = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemdescricao ;
         }
         if ( sdt.IsDirty("NotaFiscalItemNCM") )
         {
            gxTv_SdtNotaFiscalItem_Notafiscalitemncm_N = (short)(sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemncm_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemncm = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemncm ;
         }
         if ( sdt.IsDirty("NotaFiscalItemCodigoEAN") )
         {
            gxTv_SdtNotaFiscalItem_Notafiscalitemcodigoean_N = (short)(sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemcodigoean_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemcodigoean = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemcodigoean ;
         }
         if ( sdt.IsDirty("NotaFiscalItemUnidadeComercial") )
         {
            gxTv_SdtNotaFiscalItem_Notafiscalitemunidadecomercial_N = (short)(sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemunidadecomercial_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemunidadecomercial = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemunidadecomercial ;
         }
         if ( sdt.IsDirty("NotaFiscalItemQuantidade") )
         {
            gxTv_SdtNotaFiscalItem_Notafiscalitemquantidade_N = (short)(sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemquantidade_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemquantidade = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemquantidade ;
         }
         if ( sdt.IsDirty("NotaFiscalItemValorUnitario") )
         {
            gxTv_SdtNotaFiscalItem_Notafiscalitemvalorunitario_N = (short)(sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemvalorunitario_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemvalorunitario = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemvalorunitario ;
         }
         if ( sdt.IsDirty("NotaFiscalItemValorTotal") )
         {
            gxTv_SdtNotaFiscalItem_Notafiscalitemvalortotal_N = (short)(sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemvalortotal_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemvalortotal = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemvalortotal ;
         }
         if ( sdt.IsDirty("NotaFiscalItemCodBarGTIN") )
         {
            gxTv_SdtNotaFiscalItem_Notafiscalitemcodbargtin_N = (short)(sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemcodbargtin_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemcodbargtin = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemcodbargtin ;
         }
         if ( sdt.IsDirty("NotaFiscalItemUnidadeTributavel") )
         {
            gxTv_SdtNotaFiscalItem_Notafiscalitemunidadetributavel_N = (short)(sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemunidadetributavel_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemunidadetributavel = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemunidadetributavel ;
         }
         if ( sdt.IsDirty("NotaFiscalItemValorUnTributavel") )
         {
            gxTv_SdtNotaFiscalItem_Notafiscalitemvaloruntributavel_N = (short)(sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemvaloruntributavel_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemvaloruntributavel = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemvaloruntributavel ;
         }
         if ( sdt.IsDirty("NotaFiscalItemQtdTributavel") )
         {
            gxTv_SdtNotaFiscalItem_Notafiscalitemqtdtributavel_N = (short)(sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemqtdtributavel_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemqtdtributavel = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemqtdtributavel ;
         }
         if ( sdt.IsDirty("NotaFiscalItemValorFrete") )
         {
            gxTv_SdtNotaFiscalItem_Notafiscalitemvalorfrete_N = (short)(sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemvalorfrete_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemvalorfrete = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemvalorfrete ;
         }
         if ( sdt.IsDirty("NotaFiscalItemDesconto") )
         {
            gxTv_SdtNotaFiscalItem_Notafiscalitemdesconto_N = (short)(sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemdesconto_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemdesconto = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemdesconto ;
         }
         if ( sdt.IsDirty("NotaFiscalItemIndicadorValorTotal") )
         {
            gxTv_SdtNotaFiscalItem_Notafiscalitemindicadorvalortotal_N = (short)(sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemindicadorvalortotal_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemindicadorvalortotal = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemindicadorvalortotal ;
         }
         if ( sdt.IsDirty("NotaFiscalItemNumPedido") )
         {
            gxTv_SdtNotaFiscalItem_Notafiscalitemnumpedido_N = (short)(sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemnumpedido_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemnumpedido = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemnumpedido ;
         }
         if ( sdt.IsDirty("NotaFiscalItemNumItem") )
         {
            gxTv_SdtNotaFiscalItem_Notafiscalitemnumitem_N = (short)(sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemnumitem_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemnumitem = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemnumitem ;
         }
         if ( sdt.IsDirty("NotaFiscalItemVendido") )
         {
            gxTv_SdtNotaFiscalItem_Notafiscalitemvendido_N = (short)(sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemvendido_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemvendido = sdt.gxTv_SdtNotaFiscalItem_Notafiscalitemvendido ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemId" )]
      [  XmlElement( ElementName = "NotaFiscalItemId"   )]
      public Guid gxTpr_Notafiscalitemid
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtNotaFiscalItem_Notafiscalitemid != value )
            {
               gxTv_SdtNotaFiscalItem_Mode = "INS";
               this.gxTv_SdtNotaFiscalItem_Notafiscalitemid_Z_SetNull( );
               this.gxTv_SdtNotaFiscalItem_Propostaid_Z_SetNull( );
               this.gxTv_SdtNotaFiscalItem_Notafiscalid_Z_SetNull( );
               this.gxTv_SdtNotaFiscalItem_Notafiscalitemcodigo_Z_SetNull( );
               this.gxTv_SdtNotaFiscalItem_Notafiscalitemcfop_Z_SetNull( );
               this.gxTv_SdtNotaFiscalItem_Notafiscalitemdescricao_Z_SetNull( );
               this.gxTv_SdtNotaFiscalItem_Notafiscalitemncm_Z_SetNull( );
               this.gxTv_SdtNotaFiscalItem_Notafiscalitemcodigoean_Z_SetNull( );
               this.gxTv_SdtNotaFiscalItem_Notafiscalitemunidadecomercial_Z_SetNull( );
               this.gxTv_SdtNotaFiscalItem_Notafiscalitemquantidade_Z_SetNull( );
               this.gxTv_SdtNotaFiscalItem_Notafiscalitemvalorunitario_Z_SetNull( );
               this.gxTv_SdtNotaFiscalItem_Notafiscalitemvalortotal_Z_SetNull( );
               this.gxTv_SdtNotaFiscalItem_Notafiscalitemcodbargtin_Z_SetNull( );
               this.gxTv_SdtNotaFiscalItem_Notafiscalitemunidadetributavel_Z_SetNull( );
               this.gxTv_SdtNotaFiscalItem_Notafiscalitemvaloruntributavel_Z_SetNull( );
               this.gxTv_SdtNotaFiscalItem_Notafiscalitemqtdtributavel_Z_SetNull( );
               this.gxTv_SdtNotaFiscalItem_Notafiscalitemvalorfrete_Z_SetNull( );
               this.gxTv_SdtNotaFiscalItem_Notafiscalitemdesconto_Z_SetNull( );
               this.gxTv_SdtNotaFiscalItem_Notafiscalitemindicadorvalortotal_Z_SetNull( );
               this.gxTv_SdtNotaFiscalItem_Notafiscalitemnumpedido_Z_SetNull( );
               this.gxTv_SdtNotaFiscalItem_Notafiscalitemnumitem_Z_SetNull( );
               this.gxTv_SdtNotaFiscalItem_Notafiscalitemvendido_Z_SetNull( );
            }
            gxTv_SdtNotaFiscalItem_Notafiscalitemid = value;
            SetDirty("Notafiscalitemid");
         }

      }

      [  SoapElement( ElementName = "PropostaId" )]
      [  XmlElement( ElementName = "PropostaId"   )]
      public int gxTpr_Propostaid
      {
         get {
            return gxTv_SdtNotaFiscalItem_Propostaid ;
         }

         set {
            gxTv_SdtNotaFiscalItem_Propostaid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Propostaid = value;
            SetDirty("Propostaid");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Propostaid_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Propostaid_N = 1;
         gxTv_SdtNotaFiscalItem_Propostaid = 0;
         SetDirty("Propostaid");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Propostaid_IsNull( )
      {
         return (gxTv_SdtNotaFiscalItem_Propostaid_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalId" )]
      [  XmlElement( ElementName = "NotaFiscalId"   )]
      public Guid gxTpr_Notafiscalid
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalid ;
         }

         set {
            gxTv_SdtNotaFiscalItem_Notafiscalid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalid = value;
            SetDirty("Notafiscalid");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalid_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalid_N = 1;
         gxTv_SdtNotaFiscalItem_Notafiscalid = Guid.Empty;
         SetDirty("Notafiscalid");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalid_IsNull( )
      {
         return (gxTv_SdtNotaFiscalItem_Notafiscalid_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemCodigo" )]
      [  XmlElement( ElementName = "NotaFiscalItemCodigo"   )]
      public string gxTpr_Notafiscalitemcodigo
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemcodigo ;
         }

         set {
            gxTv_SdtNotaFiscalItem_Notafiscalitemcodigo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemcodigo = value;
            SetDirty("Notafiscalitemcodigo");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalitemcodigo_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalitemcodigo_N = 1;
         gxTv_SdtNotaFiscalItem_Notafiscalitemcodigo = "";
         SetDirty("Notafiscalitemcodigo");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalitemcodigo_IsNull( )
      {
         return (gxTv_SdtNotaFiscalItem_Notafiscalitemcodigo_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemCFOP" )]
      [  XmlElement( ElementName = "NotaFiscalItemCFOP"   )]
      public short gxTpr_Notafiscalitemcfop
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemcfop ;
         }

         set {
            gxTv_SdtNotaFiscalItem_Notafiscalitemcfop_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemcfop = value;
            SetDirty("Notafiscalitemcfop");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalitemcfop_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalitemcfop_N = 1;
         gxTv_SdtNotaFiscalItem_Notafiscalitemcfop = 0;
         SetDirty("Notafiscalitemcfop");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalitemcfop_IsNull( )
      {
         return (gxTv_SdtNotaFiscalItem_Notafiscalitemcfop_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemDescricao" )]
      [  XmlElement( ElementName = "NotaFiscalItemDescricao"   )]
      public string gxTpr_Notafiscalitemdescricao
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemdescricao ;
         }

         set {
            gxTv_SdtNotaFiscalItem_Notafiscalitemdescricao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemdescricao = value;
            SetDirty("Notafiscalitemdescricao");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalitemdescricao_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalitemdescricao_N = 1;
         gxTv_SdtNotaFiscalItem_Notafiscalitemdescricao = "";
         SetDirty("Notafiscalitemdescricao");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalitemdescricao_IsNull( )
      {
         return (gxTv_SdtNotaFiscalItem_Notafiscalitemdescricao_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemNCM" )]
      [  XmlElement( ElementName = "NotaFiscalItemNCM"   )]
      public string gxTpr_Notafiscalitemncm
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemncm ;
         }

         set {
            gxTv_SdtNotaFiscalItem_Notafiscalitemncm_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemncm = value;
            SetDirty("Notafiscalitemncm");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalitemncm_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalitemncm_N = 1;
         gxTv_SdtNotaFiscalItem_Notafiscalitemncm = "";
         SetDirty("Notafiscalitemncm");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalitemncm_IsNull( )
      {
         return (gxTv_SdtNotaFiscalItem_Notafiscalitemncm_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemCodigoEAN" )]
      [  XmlElement( ElementName = "NotaFiscalItemCodigoEAN"   )]
      public string gxTpr_Notafiscalitemcodigoean
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemcodigoean ;
         }

         set {
            gxTv_SdtNotaFiscalItem_Notafiscalitemcodigoean_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemcodigoean = value;
            SetDirty("Notafiscalitemcodigoean");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalitemcodigoean_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalitemcodigoean_N = 1;
         gxTv_SdtNotaFiscalItem_Notafiscalitemcodigoean = "";
         SetDirty("Notafiscalitemcodigoean");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalitemcodigoean_IsNull( )
      {
         return (gxTv_SdtNotaFiscalItem_Notafiscalitemcodigoean_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemUnidadeComercial" )]
      [  XmlElement( ElementName = "NotaFiscalItemUnidadeComercial"   )]
      public string gxTpr_Notafiscalitemunidadecomercial
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemunidadecomercial ;
         }

         set {
            gxTv_SdtNotaFiscalItem_Notafiscalitemunidadecomercial_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemunidadecomercial = value;
            SetDirty("Notafiscalitemunidadecomercial");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalitemunidadecomercial_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalitemunidadecomercial_N = 1;
         gxTv_SdtNotaFiscalItem_Notafiscalitemunidadecomercial = "";
         SetDirty("Notafiscalitemunidadecomercial");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalitemunidadecomercial_IsNull( )
      {
         return (gxTv_SdtNotaFiscalItem_Notafiscalitemunidadecomercial_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemQuantidade" )]
      [  XmlElement( ElementName = "NotaFiscalItemQuantidade"   )]
      public decimal gxTpr_Notafiscalitemquantidade
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemquantidade ;
         }

         set {
            gxTv_SdtNotaFiscalItem_Notafiscalitemquantidade_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemquantidade = value;
            SetDirty("Notafiscalitemquantidade");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalitemquantidade_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalitemquantidade_N = 1;
         gxTv_SdtNotaFiscalItem_Notafiscalitemquantidade = 0;
         SetDirty("Notafiscalitemquantidade");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalitemquantidade_IsNull( )
      {
         return (gxTv_SdtNotaFiscalItem_Notafiscalitemquantidade_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemValorUnitario" )]
      [  XmlElement( ElementName = "NotaFiscalItemValorUnitario"   )]
      public decimal gxTpr_Notafiscalitemvalorunitario
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemvalorunitario ;
         }

         set {
            gxTv_SdtNotaFiscalItem_Notafiscalitemvalorunitario_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemvalorunitario = value;
            SetDirty("Notafiscalitemvalorunitario");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalitemvalorunitario_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalitemvalorunitario_N = 1;
         gxTv_SdtNotaFiscalItem_Notafiscalitemvalorunitario = 0;
         SetDirty("Notafiscalitemvalorunitario");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalitemvalorunitario_IsNull( )
      {
         return (gxTv_SdtNotaFiscalItem_Notafiscalitemvalorunitario_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemValorTotal" )]
      [  XmlElement( ElementName = "NotaFiscalItemValorTotal"   )]
      public decimal gxTpr_Notafiscalitemvalortotal
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemvalortotal ;
         }

         set {
            gxTv_SdtNotaFiscalItem_Notafiscalitemvalortotal_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemvalortotal = value;
            SetDirty("Notafiscalitemvalortotal");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalitemvalortotal_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalitemvalortotal_N = 1;
         gxTv_SdtNotaFiscalItem_Notafiscalitemvalortotal = 0;
         SetDirty("Notafiscalitemvalortotal");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalitemvalortotal_IsNull( )
      {
         return (gxTv_SdtNotaFiscalItem_Notafiscalitemvalortotal_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemCodBarGTIN" )]
      [  XmlElement( ElementName = "NotaFiscalItemCodBarGTIN"   )]
      public string gxTpr_Notafiscalitemcodbargtin
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemcodbargtin ;
         }

         set {
            gxTv_SdtNotaFiscalItem_Notafiscalitemcodbargtin_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemcodbargtin = value;
            SetDirty("Notafiscalitemcodbargtin");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalitemcodbargtin_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalitemcodbargtin_N = 1;
         gxTv_SdtNotaFiscalItem_Notafiscalitemcodbargtin = "";
         SetDirty("Notafiscalitemcodbargtin");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalitemcodbargtin_IsNull( )
      {
         return (gxTv_SdtNotaFiscalItem_Notafiscalitemcodbargtin_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemUnidadeTributavel" )]
      [  XmlElement( ElementName = "NotaFiscalItemUnidadeTributavel"   )]
      public string gxTpr_Notafiscalitemunidadetributavel
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemunidadetributavel ;
         }

         set {
            gxTv_SdtNotaFiscalItem_Notafiscalitemunidadetributavel_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemunidadetributavel = value;
            SetDirty("Notafiscalitemunidadetributavel");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalitemunidadetributavel_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalitemunidadetributavel_N = 1;
         gxTv_SdtNotaFiscalItem_Notafiscalitemunidadetributavel = "";
         SetDirty("Notafiscalitemunidadetributavel");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalitemunidadetributavel_IsNull( )
      {
         return (gxTv_SdtNotaFiscalItem_Notafiscalitemunidadetributavel_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemValorUnTributavel" )]
      [  XmlElement( ElementName = "NotaFiscalItemValorUnTributavel"   )]
      public decimal gxTpr_Notafiscalitemvaloruntributavel
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemvaloruntributavel ;
         }

         set {
            gxTv_SdtNotaFiscalItem_Notafiscalitemvaloruntributavel_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemvaloruntributavel = value;
            SetDirty("Notafiscalitemvaloruntributavel");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalitemvaloruntributavel_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalitemvaloruntributavel_N = 1;
         gxTv_SdtNotaFiscalItem_Notafiscalitemvaloruntributavel = 0;
         SetDirty("Notafiscalitemvaloruntributavel");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalitemvaloruntributavel_IsNull( )
      {
         return (gxTv_SdtNotaFiscalItem_Notafiscalitemvaloruntributavel_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemQtdTributavel" )]
      [  XmlElement( ElementName = "NotaFiscalItemQtdTributavel"   )]
      public decimal gxTpr_Notafiscalitemqtdtributavel
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemqtdtributavel ;
         }

         set {
            gxTv_SdtNotaFiscalItem_Notafiscalitemqtdtributavel_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemqtdtributavel = value;
            SetDirty("Notafiscalitemqtdtributavel");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalitemqtdtributavel_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalitemqtdtributavel_N = 1;
         gxTv_SdtNotaFiscalItem_Notafiscalitemqtdtributavel = 0;
         SetDirty("Notafiscalitemqtdtributavel");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalitemqtdtributavel_IsNull( )
      {
         return (gxTv_SdtNotaFiscalItem_Notafiscalitemqtdtributavel_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemValorFrete" )]
      [  XmlElement( ElementName = "NotaFiscalItemValorFrete"   )]
      public decimal gxTpr_Notafiscalitemvalorfrete
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemvalorfrete ;
         }

         set {
            gxTv_SdtNotaFiscalItem_Notafiscalitemvalorfrete_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemvalorfrete = value;
            SetDirty("Notafiscalitemvalorfrete");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalitemvalorfrete_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalitemvalorfrete_N = 1;
         gxTv_SdtNotaFiscalItem_Notafiscalitemvalorfrete = 0;
         SetDirty("Notafiscalitemvalorfrete");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalitemvalorfrete_IsNull( )
      {
         return (gxTv_SdtNotaFiscalItem_Notafiscalitemvalorfrete_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemDesconto" )]
      [  XmlElement( ElementName = "NotaFiscalItemDesconto"   )]
      public decimal gxTpr_Notafiscalitemdesconto
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemdesconto ;
         }

         set {
            gxTv_SdtNotaFiscalItem_Notafiscalitemdesconto_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemdesconto = value;
            SetDirty("Notafiscalitemdesconto");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalitemdesconto_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalitemdesconto_N = 1;
         gxTv_SdtNotaFiscalItem_Notafiscalitemdesconto = 0;
         SetDirty("Notafiscalitemdesconto");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalitemdesconto_IsNull( )
      {
         return (gxTv_SdtNotaFiscalItem_Notafiscalitemdesconto_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemIndicadorValorTotal" )]
      [  XmlElement( ElementName = "NotaFiscalItemIndicadorValorTotal"   )]
      public string gxTpr_Notafiscalitemindicadorvalortotal
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemindicadorvalortotal ;
         }

         set {
            gxTv_SdtNotaFiscalItem_Notafiscalitemindicadorvalortotal_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemindicadorvalortotal = value;
            SetDirty("Notafiscalitemindicadorvalortotal");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalitemindicadorvalortotal_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalitemindicadorvalortotal_N = 1;
         gxTv_SdtNotaFiscalItem_Notafiscalitemindicadorvalortotal = "";
         SetDirty("Notafiscalitemindicadorvalortotal");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalitemindicadorvalortotal_IsNull( )
      {
         return (gxTv_SdtNotaFiscalItem_Notafiscalitemindicadorvalortotal_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemNumPedido" )]
      [  XmlElement( ElementName = "NotaFiscalItemNumPedido"   )]
      public string gxTpr_Notafiscalitemnumpedido
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemnumpedido ;
         }

         set {
            gxTv_SdtNotaFiscalItem_Notafiscalitemnumpedido_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemnumpedido = value;
            SetDirty("Notafiscalitemnumpedido");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalitemnumpedido_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalitemnumpedido_N = 1;
         gxTv_SdtNotaFiscalItem_Notafiscalitemnumpedido = "";
         SetDirty("Notafiscalitemnumpedido");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalitemnumpedido_IsNull( )
      {
         return (gxTv_SdtNotaFiscalItem_Notafiscalitemnumpedido_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemNumItem" )]
      [  XmlElement( ElementName = "NotaFiscalItemNumItem"   )]
      public string gxTpr_Notafiscalitemnumitem
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemnumitem ;
         }

         set {
            gxTv_SdtNotaFiscalItem_Notafiscalitemnumitem_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemnumitem = value;
            SetDirty("Notafiscalitemnumitem");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalitemnumitem_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalitemnumitem_N = 1;
         gxTv_SdtNotaFiscalItem_Notafiscalitemnumitem = "";
         SetDirty("Notafiscalitemnumitem");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalitemnumitem_IsNull( )
      {
         return (gxTv_SdtNotaFiscalItem_Notafiscalitemnumitem_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemVendido" )]
      [  XmlElement( ElementName = "NotaFiscalItemVendido"   )]
      public string gxTpr_Notafiscalitemvendido
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemvendido ;
         }

         set {
            gxTv_SdtNotaFiscalItem_Notafiscalitemvendido_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemvendido = value;
            SetDirty("Notafiscalitemvendido");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalitemvendido_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalitemvendido_N = 1;
         gxTv_SdtNotaFiscalItem_Notafiscalitemvendido = "";
         SetDirty("Notafiscalitemvendido");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalitemvendido_IsNull( )
      {
         return (gxTv_SdtNotaFiscalItem_Notafiscalitemvendido_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtNotaFiscalItem_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Mode_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtNotaFiscalItem_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Initialized_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemId_Z" )]
      [  XmlElement( ElementName = "NotaFiscalItemId_Z"   )]
      public Guid gxTpr_Notafiscalitemid_Z
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemid_Z = value;
            SetDirty("Notafiscalitemid_Z");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalitemid_Z_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalitemid_Z = Guid.Empty;
         SetDirty("Notafiscalitemid_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalitemid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaId_Z" )]
      [  XmlElement( ElementName = "PropostaId_Z"   )]
      public int gxTpr_Propostaid_Z
      {
         get {
            return gxTv_SdtNotaFiscalItem_Propostaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Propostaid_Z = value;
            SetDirty("Propostaid_Z");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Propostaid_Z_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Propostaid_Z = 0;
         SetDirty("Propostaid_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Propostaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalId_Z" )]
      [  XmlElement( ElementName = "NotaFiscalId_Z"   )]
      public Guid gxTpr_Notafiscalid_Z
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalid_Z = value;
            SetDirty("Notafiscalid_Z");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalid_Z_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalid_Z = Guid.Empty;
         SetDirty("Notafiscalid_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemCodigo_Z" )]
      [  XmlElement( ElementName = "NotaFiscalItemCodigo_Z"   )]
      public string gxTpr_Notafiscalitemcodigo_Z
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemcodigo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemcodigo_Z = value;
            SetDirty("Notafiscalitemcodigo_Z");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalitemcodigo_Z_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalitemcodigo_Z = "";
         SetDirty("Notafiscalitemcodigo_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalitemcodigo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemCFOP_Z" )]
      [  XmlElement( ElementName = "NotaFiscalItemCFOP_Z"   )]
      public short gxTpr_Notafiscalitemcfop_Z
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemcfop_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemcfop_Z = value;
            SetDirty("Notafiscalitemcfop_Z");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalitemcfop_Z_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalitemcfop_Z = 0;
         SetDirty("Notafiscalitemcfop_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalitemcfop_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemDescricao_Z" )]
      [  XmlElement( ElementName = "NotaFiscalItemDescricao_Z"   )]
      public string gxTpr_Notafiscalitemdescricao_Z
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemdescricao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemdescricao_Z = value;
            SetDirty("Notafiscalitemdescricao_Z");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalitemdescricao_Z_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalitemdescricao_Z = "";
         SetDirty("Notafiscalitemdescricao_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalitemdescricao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemNCM_Z" )]
      [  XmlElement( ElementName = "NotaFiscalItemNCM_Z"   )]
      public string gxTpr_Notafiscalitemncm_Z
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemncm_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemncm_Z = value;
            SetDirty("Notafiscalitemncm_Z");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalitemncm_Z_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalitemncm_Z = "";
         SetDirty("Notafiscalitemncm_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalitemncm_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemCodigoEAN_Z" )]
      [  XmlElement( ElementName = "NotaFiscalItemCodigoEAN_Z"   )]
      public string gxTpr_Notafiscalitemcodigoean_Z
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemcodigoean_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemcodigoean_Z = value;
            SetDirty("Notafiscalitemcodigoean_Z");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalitemcodigoean_Z_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalitemcodigoean_Z = "";
         SetDirty("Notafiscalitemcodigoean_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalitemcodigoean_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemUnidadeComercial_Z" )]
      [  XmlElement( ElementName = "NotaFiscalItemUnidadeComercial_Z"   )]
      public string gxTpr_Notafiscalitemunidadecomercial_Z
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemunidadecomercial_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemunidadecomercial_Z = value;
            SetDirty("Notafiscalitemunidadecomercial_Z");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalitemunidadecomercial_Z_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalitemunidadecomercial_Z = "";
         SetDirty("Notafiscalitemunidadecomercial_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalitemunidadecomercial_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemQuantidade_Z" )]
      [  XmlElement( ElementName = "NotaFiscalItemQuantidade_Z"   )]
      public decimal gxTpr_Notafiscalitemquantidade_Z
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemquantidade_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemquantidade_Z = value;
            SetDirty("Notafiscalitemquantidade_Z");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalitemquantidade_Z_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalitemquantidade_Z = 0;
         SetDirty("Notafiscalitemquantidade_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalitemquantidade_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemValorUnitario_Z" )]
      [  XmlElement( ElementName = "NotaFiscalItemValorUnitario_Z"   )]
      public decimal gxTpr_Notafiscalitemvalorunitario_Z
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemvalorunitario_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemvalorunitario_Z = value;
            SetDirty("Notafiscalitemvalorunitario_Z");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalitemvalorunitario_Z_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalitemvalorunitario_Z = 0;
         SetDirty("Notafiscalitemvalorunitario_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalitemvalorunitario_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemValorTotal_Z" )]
      [  XmlElement( ElementName = "NotaFiscalItemValorTotal_Z"   )]
      public decimal gxTpr_Notafiscalitemvalortotal_Z
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemvalortotal_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemvalortotal_Z = value;
            SetDirty("Notafiscalitemvalortotal_Z");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalitemvalortotal_Z_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalitemvalortotal_Z = 0;
         SetDirty("Notafiscalitemvalortotal_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalitemvalortotal_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemCodBarGTIN_Z" )]
      [  XmlElement( ElementName = "NotaFiscalItemCodBarGTIN_Z"   )]
      public string gxTpr_Notafiscalitemcodbargtin_Z
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemcodbargtin_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemcodbargtin_Z = value;
            SetDirty("Notafiscalitemcodbargtin_Z");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalitemcodbargtin_Z_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalitemcodbargtin_Z = "";
         SetDirty("Notafiscalitemcodbargtin_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalitemcodbargtin_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemUnidadeTributavel_Z" )]
      [  XmlElement( ElementName = "NotaFiscalItemUnidadeTributavel_Z"   )]
      public string gxTpr_Notafiscalitemunidadetributavel_Z
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemunidadetributavel_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemunidadetributavel_Z = value;
            SetDirty("Notafiscalitemunidadetributavel_Z");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalitemunidadetributavel_Z_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalitemunidadetributavel_Z = "";
         SetDirty("Notafiscalitemunidadetributavel_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalitemunidadetributavel_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemValorUnTributavel_Z" )]
      [  XmlElement( ElementName = "NotaFiscalItemValorUnTributavel_Z"   )]
      public decimal gxTpr_Notafiscalitemvaloruntributavel_Z
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemvaloruntributavel_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemvaloruntributavel_Z = value;
            SetDirty("Notafiscalitemvaloruntributavel_Z");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalitemvaloruntributavel_Z_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalitemvaloruntributavel_Z = 0;
         SetDirty("Notafiscalitemvaloruntributavel_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalitemvaloruntributavel_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemQtdTributavel_Z" )]
      [  XmlElement( ElementName = "NotaFiscalItemQtdTributavel_Z"   )]
      public decimal gxTpr_Notafiscalitemqtdtributavel_Z
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemqtdtributavel_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemqtdtributavel_Z = value;
            SetDirty("Notafiscalitemqtdtributavel_Z");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalitemqtdtributavel_Z_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalitemqtdtributavel_Z = 0;
         SetDirty("Notafiscalitemqtdtributavel_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalitemqtdtributavel_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemValorFrete_Z" )]
      [  XmlElement( ElementName = "NotaFiscalItemValorFrete_Z"   )]
      public decimal gxTpr_Notafiscalitemvalorfrete_Z
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemvalorfrete_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemvalorfrete_Z = value;
            SetDirty("Notafiscalitemvalorfrete_Z");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalitemvalorfrete_Z_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalitemvalorfrete_Z = 0;
         SetDirty("Notafiscalitemvalorfrete_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalitemvalorfrete_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemDesconto_Z" )]
      [  XmlElement( ElementName = "NotaFiscalItemDesconto_Z"   )]
      public decimal gxTpr_Notafiscalitemdesconto_Z
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemdesconto_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemdesconto_Z = value;
            SetDirty("Notafiscalitemdesconto_Z");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalitemdesconto_Z_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalitemdesconto_Z = 0;
         SetDirty("Notafiscalitemdesconto_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalitemdesconto_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemIndicadorValorTotal_Z" )]
      [  XmlElement( ElementName = "NotaFiscalItemIndicadorValorTotal_Z"   )]
      public string gxTpr_Notafiscalitemindicadorvalortotal_Z
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemindicadorvalortotal_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemindicadorvalortotal_Z = value;
            SetDirty("Notafiscalitemindicadorvalortotal_Z");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalitemindicadorvalortotal_Z_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalitemindicadorvalortotal_Z = "";
         SetDirty("Notafiscalitemindicadorvalortotal_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalitemindicadorvalortotal_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemNumPedido_Z" )]
      [  XmlElement( ElementName = "NotaFiscalItemNumPedido_Z"   )]
      public string gxTpr_Notafiscalitemnumpedido_Z
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemnumpedido_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemnumpedido_Z = value;
            SetDirty("Notafiscalitemnumpedido_Z");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalitemnumpedido_Z_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalitemnumpedido_Z = "";
         SetDirty("Notafiscalitemnumpedido_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalitemnumpedido_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemNumItem_Z" )]
      [  XmlElement( ElementName = "NotaFiscalItemNumItem_Z"   )]
      public string gxTpr_Notafiscalitemnumitem_Z
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemnumitem_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemnumitem_Z = value;
            SetDirty("Notafiscalitemnumitem_Z");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalitemnumitem_Z_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalitemnumitem_Z = "";
         SetDirty("Notafiscalitemnumitem_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalitemnumitem_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemVendido_Z" )]
      [  XmlElement( ElementName = "NotaFiscalItemVendido_Z"   )]
      public string gxTpr_Notafiscalitemvendido_Z
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemvendido_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemvendido_Z = value;
            SetDirty("Notafiscalitemvendido_Z");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalitemvendido_Z_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalitemvendido_Z = "";
         SetDirty("Notafiscalitemvendido_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalitemvendido_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaId_N" )]
      [  XmlElement( ElementName = "PropostaId_N"   )]
      public short gxTpr_Propostaid_N
      {
         get {
            return gxTv_SdtNotaFiscalItem_Propostaid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Propostaid_N = value;
            SetDirty("Propostaid_N");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Propostaid_N_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Propostaid_N = 0;
         SetDirty("Propostaid_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Propostaid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalId_N" )]
      [  XmlElement( ElementName = "NotaFiscalId_N"   )]
      public short gxTpr_Notafiscalid_N
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalid_N = value;
            SetDirty("Notafiscalid_N");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalid_N_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalid_N = 0;
         SetDirty("Notafiscalid_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemCodigo_N" )]
      [  XmlElement( ElementName = "NotaFiscalItemCodigo_N"   )]
      public short gxTpr_Notafiscalitemcodigo_N
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemcodigo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemcodigo_N = value;
            SetDirty("Notafiscalitemcodigo_N");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalitemcodigo_N_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalitemcodigo_N = 0;
         SetDirty("Notafiscalitemcodigo_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalitemcodigo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemCFOP_N" )]
      [  XmlElement( ElementName = "NotaFiscalItemCFOP_N"   )]
      public short gxTpr_Notafiscalitemcfop_N
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemcfop_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemcfop_N = value;
            SetDirty("Notafiscalitemcfop_N");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalitemcfop_N_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalitemcfop_N = 0;
         SetDirty("Notafiscalitemcfop_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalitemcfop_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemDescricao_N" )]
      [  XmlElement( ElementName = "NotaFiscalItemDescricao_N"   )]
      public short gxTpr_Notafiscalitemdescricao_N
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemdescricao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemdescricao_N = value;
            SetDirty("Notafiscalitemdescricao_N");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalitemdescricao_N_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalitemdescricao_N = 0;
         SetDirty("Notafiscalitemdescricao_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalitemdescricao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemNCM_N" )]
      [  XmlElement( ElementName = "NotaFiscalItemNCM_N"   )]
      public short gxTpr_Notafiscalitemncm_N
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemncm_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemncm_N = value;
            SetDirty("Notafiscalitemncm_N");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalitemncm_N_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalitemncm_N = 0;
         SetDirty("Notafiscalitemncm_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalitemncm_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemCodigoEAN_N" )]
      [  XmlElement( ElementName = "NotaFiscalItemCodigoEAN_N"   )]
      public short gxTpr_Notafiscalitemcodigoean_N
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemcodigoean_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemcodigoean_N = value;
            SetDirty("Notafiscalitemcodigoean_N");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalitemcodigoean_N_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalitemcodigoean_N = 0;
         SetDirty("Notafiscalitemcodigoean_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalitemcodigoean_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemUnidadeComercial_N" )]
      [  XmlElement( ElementName = "NotaFiscalItemUnidadeComercial_N"   )]
      public short gxTpr_Notafiscalitemunidadecomercial_N
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemunidadecomercial_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemunidadecomercial_N = value;
            SetDirty("Notafiscalitemunidadecomercial_N");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalitemunidadecomercial_N_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalitemunidadecomercial_N = 0;
         SetDirty("Notafiscalitemunidadecomercial_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalitemunidadecomercial_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemQuantidade_N" )]
      [  XmlElement( ElementName = "NotaFiscalItemQuantidade_N"   )]
      public short gxTpr_Notafiscalitemquantidade_N
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemquantidade_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemquantidade_N = value;
            SetDirty("Notafiscalitemquantidade_N");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalitemquantidade_N_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalitemquantidade_N = 0;
         SetDirty("Notafiscalitemquantidade_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalitemquantidade_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemValorUnitario_N" )]
      [  XmlElement( ElementName = "NotaFiscalItemValorUnitario_N"   )]
      public short gxTpr_Notafiscalitemvalorunitario_N
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemvalorunitario_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemvalorunitario_N = value;
            SetDirty("Notafiscalitemvalorunitario_N");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalitemvalorunitario_N_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalitemvalorunitario_N = 0;
         SetDirty("Notafiscalitemvalorunitario_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalitemvalorunitario_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemValorTotal_N" )]
      [  XmlElement( ElementName = "NotaFiscalItemValorTotal_N"   )]
      public short gxTpr_Notafiscalitemvalortotal_N
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemvalortotal_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemvalortotal_N = value;
            SetDirty("Notafiscalitemvalortotal_N");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalitemvalortotal_N_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalitemvalortotal_N = 0;
         SetDirty("Notafiscalitemvalortotal_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalitemvalortotal_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemCodBarGTIN_N" )]
      [  XmlElement( ElementName = "NotaFiscalItemCodBarGTIN_N"   )]
      public short gxTpr_Notafiscalitemcodbargtin_N
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemcodbargtin_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemcodbargtin_N = value;
            SetDirty("Notafiscalitemcodbargtin_N");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalitemcodbargtin_N_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalitemcodbargtin_N = 0;
         SetDirty("Notafiscalitemcodbargtin_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalitemcodbargtin_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemUnidadeTributavel_N" )]
      [  XmlElement( ElementName = "NotaFiscalItemUnidadeTributavel_N"   )]
      public short gxTpr_Notafiscalitemunidadetributavel_N
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemunidadetributavel_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemunidadetributavel_N = value;
            SetDirty("Notafiscalitemunidadetributavel_N");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalitemunidadetributavel_N_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalitemunidadetributavel_N = 0;
         SetDirty("Notafiscalitemunidadetributavel_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalitemunidadetributavel_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemValorUnTributavel_N" )]
      [  XmlElement( ElementName = "NotaFiscalItemValorUnTributavel_N"   )]
      public short gxTpr_Notafiscalitemvaloruntributavel_N
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemvaloruntributavel_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemvaloruntributavel_N = value;
            SetDirty("Notafiscalitemvaloruntributavel_N");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalitemvaloruntributavel_N_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalitemvaloruntributavel_N = 0;
         SetDirty("Notafiscalitemvaloruntributavel_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalitemvaloruntributavel_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemQtdTributavel_N" )]
      [  XmlElement( ElementName = "NotaFiscalItemQtdTributavel_N"   )]
      public short gxTpr_Notafiscalitemqtdtributavel_N
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemqtdtributavel_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemqtdtributavel_N = value;
            SetDirty("Notafiscalitemqtdtributavel_N");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalitemqtdtributavel_N_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalitemqtdtributavel_N = 0;
         SetDirty("Notafiscalitemqtdtributavel_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalitemqtdtributavel_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemValorFrete_N" )]
      [  XmlElement( ElementName = "NotaFiscalItemValorFrete_N"   )]
      public short gxTpr_Notafiscalitemvalorfrete_N
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemvalorfrete_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemvalorfrete_N = value;
            SetDirty("Notafiscalitemvalorfrete_N");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalitemvalorfrete_N_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalitemvalorfrete_N = 0;
         SetDirty("Notafiscalitemvalorfrete_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalitemvalorfrete_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemDesconto_N" )]
      [  XmlElement( ElementName = "NotaFiscalItemDesconto_N"   )]
      public short gxTpr_Notafiscalitemdesconto_N
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemdesconto_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemdesconto_N = value;
            SetDirty("Notafiscalitemdesconto_N");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalitemdesconto_N_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalitemdesconto_N = 0;
         SetDirty("Notafiscalitemdesconto_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalitemdesconto_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemIndicadorValorTotal_N" )]
      [  XmlElement( ElementName = "NotaFiscalItemIndicadorValorTotal_N"   )]
      public short gxTpr_Notafiscalitemindicadorvalortotal_N
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemindicadorvalortotal_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemindicadorvalortotal_N = value;
            SetDirty("Notafiscalitemindicadorvalortotal_N");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalitemindicadorvalortotal_N_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalitemindicadorvalortotal_N = 0;
         SetDirty("Notafiscalitemindicadorvalortotal_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalitemindicadorvalortotal_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemNumPedido_N" )]
      [  XmlElement( ElementName = "NotaFiscalItemNumPedido_N"   )]
      public short gxTpr_Notafiscalitemnumpedido_N
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemnumpedido_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemnumpedido_N = value;
            SetDirty("Notafiscalitemnumpedido_N");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalitemnumpedido_N_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalitemnumpedido_N = 0;
         SetDirty("Notafiscalitemnumpedido_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalitemnumpedido_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemNumItem_N" )]
      [  XmlElement( ElementName = "NotaFiscalItemNumItem_N"   )]
      public short gxTpr_Notafiscalitemnumitem_N
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemnumitem_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemnumitem_N = value;
            SetDirty("Notafiscalitemnumitem_N");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalitemnumitem_N_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalitemnumitem_N = 0;
         SetDirty("Notafiscalitemnumitem_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalitemnumitem_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalItemVendido_N" )]
      [  XmlElement( ElementName = "NotaFiscalItemVendido_N"   )]
      public short gxTpr_Notafiscalitemvendido_N
      {
         get {
            return gxTv_SdtNotaFiscalItem_Notafiscalitemvendido_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscalItem_Notafiscalitemvendido_N = value;
            SetDirty("Notafiscalitemvendido_N");
         }

      }

      public void gxTv_SdtNotaFiscalItem_Notafiscalitemvendido_N_SetNull( )
      {
         gxTv_SdtNotaFiscalItem_Notafiscalitemvendido_N = 0;
         SetDirty("Notafiscalitemvendido_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscalItem_Notafiscalitemvendido_N_IsNull( )
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
         gxTv_SdtNotaFiscalItem_Notafiscalitemid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtNotaFiscalItem_Notafiscalid = Guid.Empty;
         gxTv_SdtNotaFiscalItem_Notafiscalitemcodigo = "";
         gxTv_SdtNotaFiscalItem_Notafiscalitemdescricao = "";
         gxTv_SdtNotaFiscalItem_Notafiscalitemncm = "";
         gxTv_SdtNotaFiscalItem_Notafiscalitemcodigoean = "";
         gxTv_SdtNotaFiscalItem_Notafiscalitemunidadecomercial = "";
         gxTv_SdtNotaFiscalItem_Notafiscalitemcodbargtin = "";
         gxTv_SdtNotaFiscalItem_Notafiscalitemunidadetributavel = "";
         gxTv_SdtNotaFiscalItem_Notafiscalitemindicadorvalortotal = "";
         gxTv_SdtNotaFiscalItem_Notafiscalitemnumpedido = "";
         gxTv_SdtNotaFiscalItem_Notafiscalitemnumitem = "";
         gxTv_SdtNotaFiscalItem_Notafiscalitemvendido = "";
         gxTv_SdtNotaFiscalItem_Mode = "";
         gxTv_SdtNotaFiscalItem_Notafiscalitemid_Z = Guid.Empty;
         gxTv_SdtNotaFiscalItem_Notafiscalid_Z = Guid.Empty;
         gxTv_SdtNotaFiscalItem_Notafiscalitemcodigo_Z = "";
         gxTv_SdtNotaFiscalItem_Notafiscalitemdescricao_Z = "";
         gxTv_SdtNotaFiscalItem_Notafiscalitemncm_Z = "";
         gxTv_SdtNotaFiscalItem_Notafiscalitemcodigoean_Z = "";
         gxTv_SdtNotaFiscalItem_Notafiscalitemunidadecomercial_Z = "";
         gxTv_SdtNotaFiscalItem_Notafiscalitemcodbargtin_Z = "";
         gxTv_SdtNotaFiscalItem_Notafiscalitemunidadetributavel_Z = "";
         gxTv_SdtNotaFiscalItem_Notafiscalitemindicadorvalortotal_Z = "";
         gxTv_SdtNotaFiscalItem_Notafiscalitemnumpedido_Z = "";
         gxTv_SdtNotaFiscalItem_Notafiscalitemnumitem_Z = "";
         gxTv_SdtNotaFiscalItem_Notafiscalitemvendido_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "notafiscalitem", "GeneXus.Programs.notafiscalitem_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtNotaFiscalItem_Notafiscalitemcfop ;
      private short gxTv_SdtNotaFiscalItem_Initialized ;
      private short gxTv_SdtNotaFiscalItem_Notafiscalitemcfop_Z ;
      private short gxTv_SdtNotaFiscalItem_Propostaid_N ;
      private short gxTv_SdtNotaFiscalItem_Notafiscalid_N ;
      private short gxTv_SdtNotaFiscalItem_Notafiscalitemcodigo_N ;
      private short gxTv_SdtNotaFiscalItem_Notafiscalitemcfop_N ;
      private short gxTv_SdtNotaFiscalItem_Notafiscalitemdescricao_N ;
      private short gxTv_SdtNotaFiscalItem_Notafiscalitemncm_N ;
      private short gxTv_SdtNotaFiscalItem_Notafiscalitemcodigoean_N ;
      private short gxTv_SdtNotaFiscalItem_Notafiscalitemunidadecomercial_N ;
      private short gxTv_SdtNotaFiscalItem_Notafiscalitemquantidade_N ;
      private short gxTv_SdtNotaFiscalItem_Notafiscalitemvalorunitario_N ;
      private short gxTv_SdtNotaFiscalItem_Notafiscalitemvalortotal_N ;
      private short gxTv_SdtNotaFiscalItem_Notafiscalitemcodbargtin_N ;
      private short gxTv_SdtNotaFiscalItem_Notafiscalitemunidadetributavel_N ;
      private short gxTv_SdtNotaFiscalItem_Notafiscalitemvaloruntributavel_N ;
      private short gxTv_SdtNotaFiscalItem_Notafiscalitemqtdtributavel_N ;
      private short gxTv_SdtNotaFiscalItem_Notafiscalitemvalorfrete_N ;
      private short gxTv_SdtNotaFiscalItem_Notafiscalitemdesconto_N ;
      private short gxTv_SdtNotaFiscalItem_Notafiscalitemindicadorvalortotal_N ;
      private short gxTv_SdtNotaFiscalItem_Notafiscalitemnumpedido_N ;
      private short gxTv_SdtNotaFiscalItem_Notafiscalitemnumitem_N ;
      private short gxTv_SdtNotaFiscalItem_Notafiscalitemvendido_N ;
      private int gxTv_SdtNotaFiscalItem_Propostaid ;
      private int gxTv_SdtNotaFiscalItem_Propostaid_Z ;
      private decimal gxTv_SdtNotaFiscalItem_Notafiscalitemquantidade ;
      private decimal gxTv_SdtNotaFiscalItem_Notafiscalitemvalorunitario ;
      private decimal gxTv_SdtNotaFiscalItem_Notafiscalitemvalortotal ;
      private decimal gxTv_SdtNotaFiscalItem_Notafiscalitemvaloruntributavel ;
      private decimal gxTv_SdtNotaFiscalItem_Notafiscalitemqtdtributavel ;
      private decimal gxTv_SdtNotaFiscalItem_Notafiscalitemvalorfrete ;
      private decimal gxTv_SdtNotaFiscalItem_Notafiscalitemdesconto ;
      private decimal gxTv_SdtNotaFiscalItem_Notafiscalitemquantidade_Z ;
      private decimal gxTv_SdtNotaFiscalItem_Notafiscalitemvalorunitario_Z ;
      private decimal gxTv_SdtNotaFiscalItem_Notafiscalitemvalortotal_Z ;
      private decimal gxTv_SdtNotaFiscalItem_Notafiscalitemvaloruntributavel_Z ;
      private decimal gxTv_SdtNotaFiscalItem_Notafiscalitemqtdtributavel_Z ;
      private decimal gxTv_SdtNotaFiscalItem_Notafiscalitemvalorfrete_Z ;
      private decimal gxTv_SdtNotaFiscalItem_Notafiscalitemdesconto_Z ;
      private string gxTv_SdtNotaFiscalItem_Mode ;
      private string gxTv_SdtNotaFiscalItem_Notafiscalitemcodigo ;
      private string gxTv_SdtNotaFiscalItem_Notafiscalitemdescricao ;
      private string gxTv_SdtNotaFiscalItem_Notafiscalitemncm ;
      private string gxTv_SdtNotaFiscalItem_Notafiscalitemcodigoean ;
      private string gxTv_SdtNotaFiscalItem_Notafiscalitemunidadecomercial ;
      private string gxTv_SdtNotaFiscalItem_Notafiscalitemcodbargtin ;
      private string gxTv_SdtNotaFiscalItem_Notafiscalitemunidadetributavel ;
      private string gxTv_SdtNotaFiscalItem_Notafiscalitemindicadorvalortotal ;
      private string gxTv_SdtNotaFiscalItem_Notafiscalitemnumpedido ;
      private string gxTv_SdtNotaFiscalItem_Notafiscalitemnumitem ;
      private string gxTv_SdtNotaFiscalItem_Notafiscalitemvendido ;
      private string gxTv_SdtNotaFiscalItem_Notafiscalitemcodigo_Z ;
      private string gxTv_SdtNotaFiscalItem_Notafiscalitemdescricao_Z ;
      private string gxTv_SdtNotaFiscalItem_Notafiscalitemncm_Z ;
      private string gxTv_SdtNotaFiscalItem_Notafiscalitemcodigoean_Z ;
      private string gxTv_SdtNotaFiscalItem_Notafiscalitemunidadecomercial_Z ;
      private string gxTv_SdtNotaFiscalItem_Notafiscalitemcodbargtin_Z ;
      private string gxTv_SdtNotaFiscalItem_Notafiscalitemunidadetributavel_Z ;
      private string gxTv_SdtNotaFiscalItem_Notafiscalitemindicadorvalortotal_Z ;
      private string gxTv_SdtNotaFiscalItem_Notafiscalitemnumpedido_Z ;
      private string gxTv_SdtNotaFiscalItem_Notafiscalitemnumitem_Z ;
      private string gxTv_SdtNotaFiscalItem_Notafiscalitemvendido_Z ;
      private Guid gxTv_SdtNotaFiscalItem_Notafiscalitemid ;
      private Guid gxTv_SdtNotaFiscalItem_Notafiscalid ;
      private Guid gxTv_SdtNotaFiscalItem_Notafiscalitemid_Z ;
      private Guid gxTv_SdtNotaFiscalItem_Notafiscalid_Z ;
   }

   [DataContract(Name = @"NotaFiscalItem", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtNotaFiscalItem_RESTInterface : GxGenericCollectionItem<SdtNotaFiscalItem>
   {
      public SdtNotaFiscalItem_RESTInterface( ) : base()
      {
      }

      public SdtNotaFiscalItem_RESTInterface( SdtNotaFiscalItem psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "NotaFiscalItemId" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Notafiscalitemid
      {
         get {
            return sdt.gxTpr_Notafiscalitemid ;
         }

         set {
            sdt.gxTpr_Notafiscalitemid = value;
         }

      }

      [DataMember( Name = "PropostaId" , Order = 1 )]
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

      [DataMember( Name = "NotaFiscalId" , Order = 2 )]
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

      [DataMember( Name = "NotaFiscalItemCodigo" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Notafiscalitemcodigo
      {
         get {
            return sdt.gxTpr_Notafiscalitemcodigo ;
         }

         set {
            sdt.gxTpr_Notafiscalitemcodigo = value;
         }

      }

      [DataMember( Name = "NotaFiscalItemCFOP" , Order = 4 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Notafiscalitemcfop
      {
         get {
            return sdt.gxTpr_Notafiscalitemcfop ;
         }

         set {
            sdt.gxTpr_Notafiscalitemcfop = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "NotaFiscalItemDescricao" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Notafiscalitemdescricao
      {
         get {
            return sdt.gxTpr_Notafiscalitemdescricao ;
         }

         set {
            sdt.gxTpr_Notafiscalitemdescricao = value;
         }

      }

      [DataMember( Name = "NotaFiscalItemNCM" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Notafiscalitemncm
      {
         get {
            return sdt.gxTpr_Notafiscalitemncm ;
         }

         set {
            sdt.gxTpr_Notafiscalitemncm = value;
         }

      }

      [DataMember( Name = "NotaFiscalItemCodigoEAN" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Notafiscalitemcodigoean
      {
         get {
            return sdt.gxTpr_Notafiscalitemcodigoean ;
         }

         set {
            sdt.gxTpr_Notafiscalitemcodigoean = value;
         }

      }

      [DataMember( Name = "NotaFiscalItemUnidadeComercial" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Notafiscalitemunidadecomercial
      {
         get {
            return sdt.gxTpr_Notafiscalitemunidadecomercial ;
         }

         set {
            sdt.gxTpr_Notafiscalitemunidadecomercial = value;
         }

      }

      [DataMember( Name = "NotaFiscalItemQuantidade" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Notafiscalitemquantidade
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Notafiscalitemquantidade, 18, 6)) ;
         }

         set {
            sdt.gxTpr_Notafiscalitemquantidade = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "NotaFiscalItemValorUnitario" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Notafiscalitemvalorunitario
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Notafiscalitemvalorunitario, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Notafiscalitemvalorunitario = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "NotaFiscalItemValorTotal" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Notafiscalitemvalortotal
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Notafiscalitemvalortotal, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Notafiscalitemvalortotal = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "NotaFiscalItemCodBarGTIN" , Order = 12 )]
      [GxSeudo()]
      public string gxTpr_Notafiscalitemcodbargtin
      {
         get {
            return sdt.gxTpr_Notafiscalitemcodbargtin ;
         }

         set {
            sdt.gxTpr_Notafiscalitemcodbargtin = value;
         }

      }

      [DataMember( Name = "NotaFiscalItemUnidadeTributavel" , Order = 13 )]
      [GxSeudo()]
      public string gxTpr_Notafiscalitemunidadetributavel
      {
         get {
            return sdt.gxTpr_Notafiscalitemunidadetributavel ;
         }

         set {
            sdt.gxTpr_Notafiscalitemunidadetributavel = value;
         }

      }

      [DataMember( Name = "NotaFiscalItemValorUnTributavel" , Order = 14 )]
      [GxSeudo()]
      public string gxTpr_Notafiscalitemvaloruntributavel
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Notafiscalitemvaloruntributavel, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Notafiscalitemvaloruntributavel = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "NotaFiscalItemQtdTributavel" , Order = 15 )]
      [GxSeudo()]
      public string gxTpr_Notafiscalitemqtdtributavel
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Notafiscalitemqtdtributavel, 18, 6)) ;
         }

         set {
            sdt.gxTpr_Notafiscalitemqtdtributavel = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "NotaFiscalItemValorFrete" , Order = 16 )]
      [GxSeudo()]
      public string gxTpr_Notafiscalitemvalorfrete
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Notafiscalitemvalorfrete, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Notafiscalitemvalorfrete = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "NotaFiscalItemDesconto" , Order = 17 )]
      [GxSeudo()]
      public string gxTpr_Notafiscalitemdesconto
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Notafiscalitemdesconto, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Notafiscalitemdesconto = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "NotaFiscalItemIndicadorValorTotal" , Order = 18 )]
      [GxSeudo()]
      public string gxTpr_Notafiscalitemindicadorvalortotal
      {
         get {
            return sdt.gxTpr_Notafiscalitemindicadorvalortotal ;
         }

         set {
            sdt.gxTpr_Notafiscalitemindicadorvalortotal = value;
         }

      }

      [DataMember( Name = "NotaFiscalItemNumPedido" , Order = 19 )]
      [GxSeudo()]
      public string gxTpr_Notafiscalitemnumpedido
      {
         get {
            return sdt.gxTpr_Notafiscalitemnumpedido ;
         }

         set {
            sdt.gxTpr_Notafiscalitemnumpedido = value;
         }

      }

      [DataMember( Name = "NotaFiscalItemNumItem" , Order = 20 )]
      [GxSeudo()]
      public string gxTpr_Notafiscalitemnumitem
      {
         get {
            return sdt.gxTpr_Notafiscalitemnumitem ;
         }

         set {
            sdt.gxTpr_Notafiscalitemnumitem = value;
         }

      }

      [DataMember( Name = "NotaFiscalItemVendido" , Order = 21 )]
      [GxSeudo()]
      public string gxTpr_Notafiscalitemvendido
      {
         get {
            return sdt.gxTpr_Notafiscalitemvendido ;
         }

         set {
            sdt.gxTpr_Notafiscalitemvendido = value;
         }

      }

      public SdtNotaFiscalItem sdt
      {
         get {
            return (SdtNotaFiscalItem)Sdt ;
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
            sdt = new SdtNotaFiscalItem() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 22 )]
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

   [DataContract(Name = @"NotaFiscalItem", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtNotaFiscalItem_RESTLInterface : GxGenericCollectionItem<SdtNotaFiscalItem>
   {
      public SdtNotaFiscalItem_RESTLInterface( ) : base()
      {
      }

      public SdtNotaFiscalItem_RESTLInterface( SdtNotaFiscalItem psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "NotaFiscalItemCodigo" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Notafiscalitemcodigo
      {
         get {
            return sdt.gxTpr_Notafiscalitemcodigo ;
         }

         set {
            sdt.gxTpr_Notafiscalitemcodigo = value;
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

      public SdtNotaFiscalItem sdt
      {
         get {
            return (SdtNotaFiscalItem)Sdt ;
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
            sdt = new SdtNotaFiscalItem() ;
         }
      }

   }

}
