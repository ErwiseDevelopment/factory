/*
				   File: type_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem
			Description: anotacoesNegativas
				 Author: Nemo 🐠 for C# (.NET) version 18.0.12.186073
		   Program type: Callable routine
			  Main DBMS: 
*/
using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace GeneXus.Programs
{
	[XmlRoot(ElementName="SdConteudoRecomendaPF.data.anotacoesNegativasItem")]
	[XmlType(TypeName="SdConteudoRecomendaPF.data.anotacoesNegativasItem" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem : GxUserType
	{
		public SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Dataprimeiraocorrenciaprotesto = (DateTime)(DateTime.MinValue);

			gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Dataultimaocorrenciaprotesto = (DateTime)(DateTime.MinValue);


		}

		public SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem(IGxContext context)
		{
			this.context = context;	
			initialize();
		}

		#region Json
		private static Hashtable mapper;
		public override string JsonMap(string value)
		{
			if (mapper == null)
			{
				mapper = new Hashtable();
			}
			return (string)mapper[value]; ;
		}

		public override void ToJSON()
		{
			ToJSON(true) ;
			return;
		}

		public override void ToJSON(bool includeState)
		{
			AddObjectProperty("valorPrimeiraOcorrenciaDividasVencidas", gxTpr_Valorprimeiraocorrenciadividasvencidas, false);


			AddObjectProperty("valorUltimaOcorrenciaDividasVencidas", gxTpr_Valorultimaocorrenciadividasvencidas, false);


			AddObjectProperty("quantidadeTotalDividasVencidas", gxTpr_Quantidadetotaldividasvencidas, false);


			AddObjectProperty("valorTotalDividasVencidas", gxTpr_Valortotaldividasvencidas, false);


			AddObjectProperty("quantidadePefin12M", gxTpr_Quantidadepefin12m, false);


			AddObjectProperty("valorPefin12M", gxTpr_Valorpefin12m, false);


			AddObjectProperty("quantidadePefin18M", gxTpr_Quantidadepefin18m, false);


			AddObjectProperty("valorPefin18M", gxTpr_Valorpefin18m, false);


			AddObjectProperty("quantidadePefin24M", gxTpr_Quantidadepefin24m, false);


			AddObjectProperty("quantidadePefin6M", gxTpr_Quantidadepefin6m, false);


			AddObjectProperty("valorUltimaOcorrenciaPefin", gxTpr_Valorultimaocorrenciapefin, false);


			AddObjectProperty("quantidadeTotalPefin", gxTpr_Quantidadetotalpefin, false);


			AddObjectProperty("valorTotalPefin", gxTpr_Valortotalpefin, false);


			AddObjectProperty("quantidadeRefin12M", gxTpr_Quantidaderefin12m, false);


			AddObjectProperty("valorRefin12M", gxTpr_Valorrefin12m, false);


			AddObjectProperty("quantidadeRefin18M", gxTpr_Quantidaderefin18m, false);


			AddObjectProperty("valorRefin18M", gxTpr_Valorrefin18m, false);


			AddObjectProperty("quantidadeRefin24M", gxTpr_Quantidaderefin24m, false);


			AddObjectProperty("quantidadeRefin6M", gxTpr_Quantidaderefin6m, false);


			AddObjectProperty("valorUltimaOcorrenciaRefin", gxTpr_Valorultimaocorrenciarefin, false);


			AddObjectProperty("quantidadeTotalRefin", gxTpr_Quantidadetotalrefin, false);


			AddObjectProperty("valorTotalRefin", gxTpr_Valortotalrefin, false);


			datetime_STZ = gxTpr_Dataprimeiraocorrenciaprotesto;
			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim( StringUtil.Str((decimal)(DateTimeUtil.Month(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "T";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Hour(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Minute(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Second(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("dataPrimeiraOcorrenciaProtesto", sDateCnv, false);



			datetime_STZ = gxTpr_Dataultimaocorrenciaprotesto;
			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim( StringUtil.Str((decimal)(DateTimeUtil.Month(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "T";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Hour(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Minute(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Second(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("dataUltimaOcorrenciaProtesto", sDateCnv, false);



			AddObjectProperty("quantidadeTotalProtesto", gxTpr_Quantidadetotalprotesto, false);


			AddObjectProperty("valorTotalProtesto", gxTpr_Valortotalprotesto, false);


			AddObjectProperty("valorUltimaOcorrenciaProtesto", gxTpr_Valorultimaocorrenciaprotesto, false);

			if (gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Protestos != null)
			{
				AddObjectProperty("protestos", gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Protestos, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="valorPrimeiraOcorrenciaDividasVencidas")]
		[XmlElement(ElementName="valorPrimeiraOcorrenciaDividasVencidas")]
		public string gxTpr_Valorprimeiraocorrenciadividasvencidas_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valorprimeiraocorrenciadividasvencidas, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valorprimeiraocorrenciadividasvencidas = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Valorprimeiraocorrenciadividasvencidas
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valorprimeiraocorrenciadividasvencidas; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valorprimeiraocorrenciadividasvencidas = value;
				SetDirty("Valorprimeiraocorrenciadividasvencidas");
			}
		}



		[SoapElement(ElementName="valorUltimaOcorrenciaDividasVencidas")]
		[XmlElement(ElementName="valorUltimaOcorrenciaDividasVencidas")]
		public string gxTpr_Valorultimaocorrenciadividasvencidas_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valorultimaocorrenciadividasvencidas, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valorultimaocorrenciadividasvencidas = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Valorultimaocorrenciadividasvencidas
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valorultimaocorrenciadividasvencidas; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valorultimaocorrenciadividasvencidas = value;
				SetDirty("Valorultimaocorrenciadividasvencidas");
			}
		}



		[SoapElement(ElementName="quantidadeTotalDividasVencidas")]
		[XmlElement(ElementName="quantidadeTotalDividasVencidas")]
		public string gxTpr_Quantidadetotaldividasvencidas_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidadetotaldividasvencidas, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidadetotaldividasvencidas = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Quantidadetotaldividasvencidas
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidadetotaldividasvencidas; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidadetotaldividasvencidas = value;
				SetDirty("Quantidadetotaldividasvencidas");
			}
		}



		[SoapElement(ElementName="valorTotalDividasVencidas")]
		[XmlElement(ElementName="valorTotalDividasVencidas")]
		public string gxTpr_Valortotaldividasvencidas_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valortotaldividasvencidas, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valortotaldividasvencidas = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Valortotaldividasvencidas
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valortotaldividasvencidas; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valortotaldividasvencidas = value;
				SetDirty("Valortotaldividasvencidas");
			}
		}



		[SoapElement(ElementName="quantidadePefin12M")]
		[XmlElement(ElementName="quantidadePefin12M")]
		public string gxTpr_Quantidadepefin12m_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidadepefin12m, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidadepefin12m = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Quantidadepefin12m
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidadepefin12m; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidadepefin12m = value;
				SetDirty("Quantidadepefin12m");
			}
		}



		[SoapElement(ElementName="valorPefin12M")]
		[XmlElement(ElementName="valorPefin12M")]
		public string gxTpr_Valorpefin12m_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valorpefin12m, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valorpefin12m = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Valorpefin12m
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valorpefin12m; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valorpefin12m = value;
				SetDirty("Valorpefin12m");
			}
		}



		[SoapElement(ElementName="quantidadePefin18M")]
		[XmlElement(ElementName="quantidadePefin18M")]
		public string gxTpr_Quantidadepefin18m_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidadepefin18m, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidadepefin18m = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Quantidadepefin18m
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidadepefin18m; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidadepefin18m = value;
				SetDirty("Quantidadepefin18m");
			}
		}



		[SoapElement(ElementName="valorPefin18M")]
		[XmlElement(ElementName="valorPefin18M")]
		public string gxTpr_Valorpefin18m_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valorpefin18m, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valorpefin18m = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Valorpefin18m
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valorpefin18m; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valorpefin18m = value;
				SetDirty("Valorpefin18m");
			}
		}



		[SoapElement(ElementName="quantidadePefin24M")]
		[XmlElement(ElementName="quantidadePefin24M")]
		public string gxTpr_Quantidadepefin24m_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidadepefin24m, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidadepefin24m = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Quantidadepefin24m
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidadepefin24m; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidadepefin24m = value;
				SetDirty("Quantidadepefin24m");
			}
		}



		[SoapElement(ElementName="quantidadePefin6M")]
		[XmlElement(ElementName="quantidadePefin6M")]
		public string gxTpr_Quantidadepefin6m_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidadepefin6m, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidadepefin6m = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Quantidadepefin6m
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidadepefin6m; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidadepefin6m = value;
				SetDirty("Quantidadepefin6m");
			}
		}



		[SoapElement(ElementName="valorUltimaOcorrenciaPefin")]
		[XmlElement(ElementName="valorUltimaOcorrenciaPefin")]
		public string gxTpr_Valorultimaocorrenciapefin_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valorultimaocorrenciapefin, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valorultimaocorrenciapefin = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Valorultimaocorrenciapefin
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valorultimaocorrenciapefin; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valorultimaocorrenciapefin = value;
				SetDirty("Valorultimaocorrenciapefin");
			}
		}



		[SoapElement(ElementName="quantidadeTotalPefin")]
		[XmlElement(ElementName="quantidadeTotalPefin")]
		public string gxTpr_Quantidadetotalpefin_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidadetotalpefin, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidadetotalpefin = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Quantidadetotalpefin
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidadetotalpefin; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidadetotalpefin = value;
				SetDirty("Quantidadetotalpefin");
			}
		}



		[SoapElement(ElementName="valorTotalPefin")]
		[XmlElement(ElementName="valorTotalPefin")]
		public string gxTpr_Valortotalpefin_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valortotalpefin, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valortotalpefin = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Valortotalpefin
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valortotalpefin; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valortotalpefin = value;
				SetDirty("Valortotalpefin");
			}
		}



		[SoapElement(ElementName="quantidadeRefin12M")]
		[XmlElement(ElementName="quantidadeRefin12M")]
		public string gxTpr_Quantidaderefin12m_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidaderefin12m, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidaderefin12m = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Quantidaderefin12m
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidaderefin12m; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidaderefin12m = value;
				SetDirty("Quantidaderefin12m");
			}
		}



		[SoapElement(ElementName="valorRefin12M")]
		[XmlElement(ElementName="valorRefin12M")]
		public string gxTpr_Valorrefin12m_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valorrefin12m, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valorrefin12m = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Valorrefin12m
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valorrefin12m; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valorrefin12m = value;
				SetDirty("Valorrefin12m");
			}
		}



		[SoapElement(ElementName="quantidadeRefin18M")]
		[XmlElement(ElementName="quantidadeRefin18M")]
		public string gxTpr_Quantidaderefin18m_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidaderefin18m, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidaderefin18m = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Quantidaderefin18m
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidaderefin18m; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidaderefin18m = value;
				SetDirty("Quantidaderefin18m");
			}
		}



		[SoapElement(ElementName="valorRefin18M")]
		[XmlElement(ElementName="valorRefin18M")]
		public string gxTpr_Valorrefin18m_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valorrefin18m, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valorrefin18m = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Valorrefin18m
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valorrefin18m; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valorrefin18m = value;
				SetDirty("Valorrefin18m");
			}
		}



		[SoapElement(ElementName="quantidadeRefin24M")]
		[XmlElement(ElementName="quantidadeRefin24M")]
		public string gxTpr_Quantidaderefin24m_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidaderefin24m, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidaderefin24m = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Quantidaderefin24m
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidaderefin24m; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidaderefin24m = value;
				SetDirty("Quantidaderefin24m");
			}
		}



		[SoapElement(ElementName="quantidadeRefin6M")]
		[XmlElement(ElementName="quantidadeRefin6M")]
		public string gxTpr_Quantidaderefin6m_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidaderefin6m, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidaderefin6m = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Quantidaderefin6m
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidaderefin6m; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidaderefin6m = value;
				SetDirty("Quantidaderefin6m");
			}
		}



		[SoapElement(ElementName="valorUltimaOcorrenciaRefin")]
		[XmlElement(ElementName="valorUltimaOcorrenciaRefin")]
		public string gxTpr_Valorultimaocorrenciarefin_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valorultimaocorrenciarefin, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valorultimaocorrenciarefin = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Valorultimaocorrenciarefin
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valorultimaocorrenciarefin; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valorultimaocorrenciarefin = value;
				SetDirty("Valorultimaocorrenciarefin");
			}
		}



		[SoapElement(ElementName="quantidadeTotalRefin")]
		[XmlElement(ElementName="quantidadeTotalRefin")]
		public string gxTpr_Quantidadetotalrefin_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidadetotalrefin, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidadetotalrefin = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Quantidadetotalrefin
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidadetotalrefin; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidadetotalrefin = value;
				SetDirty("Quantidadetotalrefin");
			}
		}



		[SoapElement(ElementName="valorTotalRefin")]
		[XmlElement(ElementName="valorTotalRefin")]
		public string gxTpr_Valortotalrefin_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valortotalrefin, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valortotalrefin = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Valortotalrefin
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valortotalrefin; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valortotalrefin = value;
				SetDirty("Valortotalrefin");
			}
		}



		[SoapElement(ElementName="dataPrimeiraOcorrenciaProtesto")]
		[XmlElement(ElementName="dataPrimeiraOcorrenciaProtesto" , IsNullable=true)]
		public string gxTpr_Dataprimeiraocorrenciaprotesto_Nullable
		{
			get {
				if ( gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Dataprimeiraocorrenciaprotesto == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Dataprimeiraocorrenciaprotesto).value ;
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Dataprimeiraocorrenciaprotesto = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Dataprimeiraocorrenciaprotesto
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Dataprimeiraocorrenciaprotesto; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Dataprimeiraocorrenciaprotesto = value;
				SetDirty("Dataprimeiraocorrenciaprotesto");
			}
		}


		[SoapElement(ElementName="dataUltimaOcorrenciaProtesto")]
		[XmlElement(ElementName="dataUltimaOcorrenciaProtesto" , IsNullable=true)]
		public string gxTpr_Dataultimaocorrenciaprotesto_Nullable
		{
			get {
				if ( gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Dataultimaocorrenciaprotesto == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Dataultimaocorrenciaprotesto).value ;
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Dataultimaocorrenciaprotesto = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Dataultimaocorrenciaprotesto
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Dataultimaocorrenciaprotesto; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Dataultimaocorrenciaprotesto = value;
				SetDirty("Dataultimaocorrenciaprotesto");
			}
		}


		[SoapElement(ElementName="quantidadeTotalProtesto")]
		[XmlElement(ElementName="quantidadeTotalProtesto")]
		public string gxTpr_Quantidadetotalprotesto_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidadetotalprotesto, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidadetotalprotesto = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Quantidadetotalprotesto
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidadetotalprotesto; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidadetotalprotesto = value;
				SetDirty("Quantidadetotalprotesto");
			}
		}



		[SoapElement(ElementName="valorTotalProtesto")]
		[XmlElement(ElementName="valorTotalProtesto")]
		public string gxTpr_Valortotalprotesto_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valortotalprotesto, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valortotalprotesto = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Valortotalprotesto
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valortotalprotesto; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valortotalprotesto = value;
				SetDirty("Valortotalprotesto");
			}
		}



		[SoapElement(ElementName="valorUltimaOcorrenciaProtesto")]
		[XmlElement(ElementName="valorUltimaOcorrenciaProtesto")]
		public string gxTpr_Valorultimaocorrenciaprotesto_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valorultimaocorrenciaprotesto, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valorultimaocorrenciaprotesto = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Valorultimaocorrenciaprotesto
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valorultimaocorrenciaprotesto; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valorultimaocorrenciaprotesto = value;
				SetDirty("Valorultimaocorrenciaprotesto");
			}
		}




		[SoapElement(ElementName="protestos" )]
		[XmlArray(ElementName="protestos"  )]
		[XmlArrayItemAttribute(ElementName="protestosItem" , IsNullable=false )]
		public GXBaseCollection<SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_protestosItem> gxTpr_Protestos
		{
			get {
				if ( gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Protestos == null )
				{
					gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Protestos = new GXBaseCollection<SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_protestosItem>( context, "SdConteudoRecomendaPF.data.anotacoesNegativasItem.protestosItem", "");
				}
				SetDirty("Protestos");
				return gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Protestos;
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Protestos_N = false;
				gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Protestos = value;
				SetDirty("Protestos");
			}
		}

		public void gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Protestos_SetNull()
		{
			gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Protestos_N = true;
			gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Protestos = null;
		}

		public bool gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Protestos_IsNull()
		{
			return gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Protestos == null;
		}
		public bool ShouldSerializegxTpr_Protestos_GxSimpleCollection_Json()
		{
			return gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Protestos != null && gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Protestos.Count > 0;

		}


		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Static Type Properties

		[XmlIgnore]
		private static GXTypeInfo _typeProps;
		protected override GXTypeInfo TypeInfo { get { return _typeProps; } set { _typeProps = value; } }

		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Dataprimeiraocorrenciaprotesto = (DateTime)(DateTime.MinValue);
			gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Dataultimaocorrenciaprotesto = (DateTime)(DateTime.MinValue);




			gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Protestos_N = true;

			datetime_STZ = (DateTime)(DateTime.MinValue);
			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected DateTime datetime_STZ ;

		protected decimal gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valorprimeiraocorrenciadividasvencidas;
		 

		protected decimal gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valorultimaocorrenciadividasvencidas;
		 

		protected decimal gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidadetotaldividasvencidas;
		 

		protected decimal gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valortotaldividasvencidas;
		 

		protected decimal gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidadepefin12m;
		 

		protected decimal gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valorpefin12m;
		 

		protected decimal gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidadepefin18m;
		 

		protected decimal gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valorpefin18m;
		 

		protected decimal gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidadepefin24m;
		 

		protected decimal gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidadepefin6m;
		 

		protected decimal gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valorultimaocorrenciapefin;
		 

		protected decimal gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidadetotalpefin;
		 

		protected decimal gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valortotalpefin;
		 

		protected decimal gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidaderefin12m;
		 

		protected decimal gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valorrefin12m;
		 

		protected decimal gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidaderefin18m;
		 

		protected decimal gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valorrefin18m;
		 

		protected decimal gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidaderefin24m;
		 

		protected decimal gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidaderefin6m;
		 

		protected decimal gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valorultimaocorrenciarefin;
		 

		protected decimal gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidadetotalrefin;
		 

		protected decimal gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valortotalrefin;
		 

		protected DateTime gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Dataprimeiraocorrenciaprotesto;
		 

		protected DateTime gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Dataultimaocorrenciaprotesto;
		 

		protected decimal gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Quantidadetotalprotesto;
		 

		protected decimal gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valortotalprotesto;
		 

		protected decimal gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Valorultimaocorrenciaprotesto;
		 
		protected bool gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Protestos_N;
		protected GXBaseCollection<SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_protestosItem> gxTv_SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_Protestos = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SdConteudoRecomendaPF.data.anotacoesNegativasItem", Namespace="Factory21")]
	public class SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_RESTInterface : GxGenericCollectionItem<SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_RESTInterface( ) : base()
		{	
		}

		public SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_RESTInterface( SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("valorPrimeiraOcorrenciaDividasVencidas")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="valorPrimeiraOcorrenciaDividasVencidas", Order=0)]
		public  string gxTpr_Valorprimeiraocorrenciadividasvencidas
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Valorprimeiraocorrenciadividasvencidas, 10, 5));

			}
			set { 
				sdt.gxTpr_Valorprimeiraocorrenciadividasvencidas =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("valorUltimaOcorrenciaDividasVencidas")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="valorUltimaOcorrenciaDividasVencidas", Order=1)]
		public  string gxTpr_Valorultimaocorrenciadividasvencidas
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Valorultimaocorrenciadividasvencidas, 10, 5));

			}
			set { 
				sdt.gxTpr_Valorultimaocorrenciadividasvencidas =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("quantidadeTotalDividasVencidas")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="quantidadeTotalDividasVencidas", Order=2)]
		public  string gxTpr_Quantidadetotaldividasvencidas
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Quantidadetotaldividasvencidas, 10, 5));

			}
			set { 
				sdt.gxTpr_Quantidadetotaldividasvencidas =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("valorTotalDividasVencidas")]
		[JsonPropertyOrder(3)]
		[DataMember(Name="valorTotalDividasVencidas", Order=3)]
		public  string gxTpr_Valortotaldividasvencidas
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Valortotaldividasvencidas, 10, 5));

			}
			set { 
				sdt.gxTpr_Valortotaldividasvencidas =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("quantidadePefin12M")]
		[JsonPropertyOrder(4)]
		[DataMember(Name="quantidadePefin12M", Order=4)]
		public  string gxTpr_Quantidadepefin12m
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Quantidadepefin12m, 10, 5));

			}
			set { 
				sdt.gxTpr_Quantidadepefin12m =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("valorPefin12M")]
		[JsonPropertyOrder(5)]
		[DataMember(Name="valorPefin12M", Order=5)]
		public  string gxTpr_Valorpefin12m
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Valorpefin12m, 10, 5));

			}
			set { 
				sdt.gxTpr_Valorpefin12m =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("quantidadePefin18M")]
		[JsonPropertyOrder(6)]
		[DataMember(Name="quantidadePefin18M", Order=6)]
		public  string gxTpr_Quantidadepefin18m
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Quantidadepefin18m, 10, 5));

			}
			set { 
				sdt.gxTpr_Quantidadepefin18m =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("valorPefin18M")]
		[JsonPropertyOrder(7)]
		[DataMember(Name="valorPefin18M", Order=7)]
		public  string gxTpr_Valorpefin18m
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Valorpefin18m, 10, 5));

			}
			set { 
				sdt.gxTpr_Valorpefin18m =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("quantidadePefin24M")]
		[JsonPropertyOrder(8)]
		[DataMember(Name="quantidadePefin24M", Order=8)]
		public  string gxTpr_Quantidadepefin24m
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Quantidadepefin24m, 10, 5));

			}
			set { 
				sdt.gxTpr_Quantidadepefin24m =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("quantidadePefin6M")]
		[JsonPropertyOrder(9)]
		[DataMember(Name="quantidadePefin6M", Order=9)]
		public  string gxTpr_Quantidadepefin6m
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Quantidadepefin6m, 10, 5));

			}
			set { 
				sdt.gxTpr_Quantidadepefin6m =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("valorUltimaOcorrenciaPefin")]
		[JsonPropertyOrder(10)]
		[DataMember(Name="valorUltimaOcorrenciaPefin", Order=10)]
		public  string gxTpr_Valorultimaocorrenciapefin
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Valorultimaocorrenciapefin, 10, 5));

			}
			set { 
				sdt.gxTpr_Valorultimaocorrenciapefin =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("quantidadeTotalPefin")]
		[JsonPropertyOrder(11)]
		[DataMember(Name="quantidadeTotalPefin", Order=11)]
		public  string gxTpr_Quantidadetotalpefin
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Quantidadetotalpefin, 10, 5));

			}
			set { 
				sdt.gxTpr_Quantidadetotalpefin =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("valorTotalPefin")]
		[JsonPropertyOrder(12)]
		[DataMember(Name="valorTotalPefin", Order=12)]
		public  string gxTpr_Valortotalpefin
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Valortotalpefin, 10, 5));

			}
			set { 
				sdt.gxTpr_Valortotalpefin =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("quantidadeRefin12M")]
		[JsonPropertyOrder(13)]
		[DataMember(Name="quantidadeRefin12M", Order=13)]
		public  string gxTpr_Quantidaderefin12m
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Quantidaderefin12m, 10, 5));

			}
			set { 
				sdt.gxTpr_Quantidaderefin12m =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("valorRefin12M")]
		[JsonPropertyOrder(14)]
		[DataMember(Name="valorRefin12M", Order=14)]
		public  string gxTpr_Valorrefin12m
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Valorrefin12m, 10, 5));

			}
			set { 
				sdt.gxTpr_Valorrefin12m =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("quantidadeRefin18M")]
		[JsonPropertyOrder(15)]
		[DataMember(Name="quantidadeRefin18M", Order=15)]
		public  string gxTpr_Quantidaderefin18m
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Quantidaderefin18m, 10, 5));

			}
			set { 
				sdt.gxTpr_Quantidaderefin18m =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("valorRefin18M")]
		[JsonPropertyOrder(16)]
		[DataMember(Name="valorRefin18M", Order=16)]
		public  string gxTpr_Valorrefin18m
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Valorrefin18m, 10, 5));

			}
			set { 
				sdt.gxTpr_Valorrefin18m =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("quantidadeRefin24M")]
		[JsonPropertyOrder(17)]
		[DataMember(Name="quantidadeRefin24M", Order=17)]
		public  string gxTpr_Quantidaderefin24m
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Quantidaderefin24m, 10, 5));

			}
			set { 
				sdt.gxTpr_Quantidaderefin24m =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("quantidadeRefin6M")]
		[JsonPropertyOrder(18)]
		[DataMember(Name="quantidadeRefin6M", Order=18)]
		public  string gxTpr_Quantidaderefin6m
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Quantidaderefin6m, 10, 5));

			}
			set { 
				sdt.gxTpr_Quantidaderefin6m =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("valorUltimaOcorrenciaRefin")]
		[JsonPropertyOrder(19)]
		[DataMember(Name="valorUltimaOcorrenciaRefin", Order=19)]
		public  string gxTpr_Valorultimaocorrenciarefin
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Valorultimaocorrenciarefin, 10, 5));

			}
			set { 
				sdt.gxTpr_Valorultimaocorrenciarefin =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("quantidadeTotalRefin")]
		[JsonPropertyOrder(20)]
		[DataMember(Name="quantidadeTotalRefin", Order=20)]
		public  string gxTpr_Quantidadetotalrefin
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Quantidadetotalrefin, 10, 5));

			}
			set { 
				sdt.gxTpr_Quantidadetotalrefin =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("valorTotalRefin")]
		[JsonPropertyOrder(21)]
		[DataMember(Name="valorTotalRefin", Order=21)]
		public  string gxTpr_Valortotalrefin
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Valortotalrefin, 10, 5));

			}
			set { 
				sdt.gxTpr_Valortotalrefin =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("dataPrimeiraOcorrenciaProtesto")]
		[JsonPropertyOrder(22)]
		[DataMember(Name="dataPrimeiraOcorrenciaProtesto", Order=22)]
		public  string gxTpr_Dataprimeiraocorrenciaprotesto
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Dataprimeiraocorrenciaprotesto,context);

			}
			set { 
				sdt.gxTpr_Dataprimeiraocorrenciaprotesto = DateTimeUtil.CToT2(value,context);
			}
		}

		[JsonPropertyName("dataUltimaOcorrenciaProtesto")]
		[JsonPropertyOrder(23)]
		[DataMember(Name="dataUltimaOcorrenciaProtesto", Order=23)]
		public  string gxTpr_Dataultimaocorrenciaprotesto
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Dataultimaocorrenciaprotesto,context);

			}
			set { 
				sdt.gxTpr_Dataultimaocorrenciaprotesto = DateTimeUtil.CToT2(value,context);
			}
		}

		[JsonPropertyName("quantidadeTotalProtesto")]
		[JsonPropertyOrder(24)]
		[DataMember(Name="quantidadeTotalProtesto", Order=24)]
		public  string gxTpr_Quantidadetotalprotesto
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Quantidadetotalprotesto, 10, 5));

			}
			set { 
				sdt.gxTpr_Quantidadetotalprotesto =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("valorTotalProtesto")]
		[JsonPropertyOrder(25)]
		[DataMember(Name="valorTotalProtesto", Order=25)]
		public  string gxTpr_Valortotalprotesto
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Valortotalprotesto, 10, 5));

			}
			set { 
				sdt.gxTpr_Valortotalprotesto =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("valorUltimaOcorrenciaProtesto")]
		[JsonPropertyOrder(26)]
		[DataMember(Name="valorUltimaOcorrenciaProtesto", Order=26)]
		public  string gxTpr_Valorultimaocorrenciaprotesto
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Valorultimaocorrenciaprotesto, 10, 5));

			}
			set { 
				sdt.gxTpr_Valorultimaocorrenciaprotesto =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("protestos")]
		[JsonPropertyOrder(27)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="protestos", Order=27, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_protestosItem_RESTInterface> gxTpr_Protestos
		{
			get {
				if (sdt.ShouldSerializegxTpr_Protestos_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_protestosItem_RESTInterface>(sdt.gxTpr_Protestos);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Protestos);
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem sdt
		{
			get { 
				return (SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem)Sdt;
			}
			set { 
				Sdt = value;
			}
		}

		[OnDeserializing]
		void checkSdt( StreamingContext ctx )
		{
			if ( sdt == null )
			{
				sdt = new SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem() ;
			}
		}
	}
	#endregion
}