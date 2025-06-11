/*
				   File: type_SdtSdConteudoRecomendaPF_data
			Description: data
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
	[XmlRoot(ElementName="SdConteudoRecomendaPF.data")]
	[XmlType(TypeName="SdConteudoRecomendaPF.data" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdConteudoRecomendaPF_data : GxUserType
	{
		public SdtSdConteudoRecomendaPF_data( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdConteudoRecomendaPF_data_Numeroproposta = "";

			gxTv_SdtSdConteudoRecomendaPF_data_Cpf = "";

			gxTv_SdtSdConteudoRecomendaPF_data_Nome = "";

			gxTv_SdtSdConteudoRecomendaPF_data_Criacao = (DateTime)(DateTime.MinValue);

			gxTv_SdtSdConteudoRecomendaPF_data_Tipovenda = "";

			gxTv_SdtSdConteudoRecomendaPF_data_Tiporecomendacao = "";

			gxTv_SdtSdConteudoRecomendaPF_data_Tiporecomendacaovenda = "";

			gxTv_SdtSdConteudoRecomendaPF_data_Mensagemrendaestimada = "";

			gxTv_SdtSdConteudoRecomendaPF_data_Mensagemscore = "";

		}

		public SdtSdConteudoRecomendaPF_data(IGxContext context)
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
			AddObjectProperty("numeroProposta", gxTpr_Numeroproposta, false);


			AddObjectProperty("cpf", gxTpr_Cpf, false);


			AddObjectProperty("nome", gxTpr_Nome, false);


			AddObjectProperty("valorOperacao", gxTpr_Valoroperacao, false);


			AddObjectProperty("politica", gxTpr_Politica, false);


			datetime_STZ = gxTpr_Criacao;
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
			AddObjectProperty("criacao", sDateCnv, false);



			AddObjectProperty("tipoVenda", gxTpr_Tipovenda, false);


			AddObjectProperty("codTipoVenda", gxTpr_Codtipovenda, false);


			AddObjectProperty("codNivelRisco", gxTpr_Codnivelrisco, false);


			AddObjectProperty("tipoRecomendacao", gxTpr_Tiporecomendacao, false);


			AddObjectProperty("tipoRecomendacaoVenda", gxTpr_Tiporecomendacaovenda, false);

			if (gxTv_SdtSdConteudoRecomendaPF_data_Criteriosanalisados != null)
			{
				AddObjectProperty("criteriosAnalisados", gxTv_SdtSdConteudoRecomendaPF_data_Criteriosanalisados, false);
			}

			AddObjectProperty("valorLimiteRecomendado", gxTpr_Valorlimiterecomendado, false);


			AddObjectProperty("faixaRendaEstimada", gxTpr_Faixarendaestimada, false);


			AddObjectProperty("mensagemRendaEstimada", gxTpr_Mensagemrendaestimada, false);

			if (gxTv_SdtSdConteudoRecomendaPF_data_Informacoesadicionais != null)
			{
				AddObjectProperty("informacoesAdicionais", gxTv_SdtSdConteudoRecomendaPF_data_Informacoesadicionais, false);
			}
			if (gxTv_SdtSdConteudoRecomendaPF_data_Score != null)
			{
				AddObjectProperty("score", gxTv_SdtSdConteudoRecomendaPF_data_Score, false);
			}

			AddObjectProperty("mensagemScore", gxTpr_Mensagemscore, false);

			if (gxTv_SdtSdConteudoRecomendaPF_data_Identificacao != null)
			{
				AddObjectProperty("identificacao", gxTv_SdtSdConteudoRecomendaPF_data_Identificacao, false);
			}
			if (gxTv_SdtSdConteudoRecomendaPF_data_Chequesdevolvidos != null)
			{
				AddObjectProperty("chequesDevolvidos", gxTv_SdtSdConteudoRecomendaPF_data_Chequesdevolvidos, false);
			}
			if (gxTv_SdtSdConteudoRecomendaPF_data_Anotacoescompletas != null)
			{
				AddObjectProperty("anotacoesCompletas", gxTv_SdtSdConteudoRecomendaPF_data_Anotacoescompletas, false);
			}
			if (gxTv_SdtSdConteudoRecomendaPF_data_Consultasdetalhadasserasa != null)
			{
				AddObjectProperty("consultasDetalhadasSerasa", gxTv_SdtSdConteudoRecomendaPF_data_Consultasdetalhadasserasa, false);
			}
			if (gxTv_SdtSdConteudoRecomendaPF_data_Enderecopessoal != null)
			{
				AddObjectProperty("enderecoPessoal", gxTv_SdtSdConteudoRecomendaPF_data_Enderecopessoal, false);
			}
			if (gxTv_SdtSdConteudoRecomendaPF_data_Enderecos != null)
			{
				AddObjectProperty("enderecos", gxTv_SdtSdConteudoRecomendaPF_data_Enderecos, false);
			}
			if (gxTv_SdtSdConteudoRecomendaPF_data_Anotacoesnegativas != null)
			{
				AddObjectProperty("anotacoesNegativas", gxTv_SdtSdConteudoRecomendaPF_data_Anotacoesnegativas, false);
			}
			if (gxTv_SdtSdConteudoRecomendaPF_data_Criteriosmensagemrecomendacao != null)
			{
				AddObjectProperty("criteriosMensagemRecomendacao", gxTv_SdtSdConteudoRecomendaPF_data_Criteriosmensagemrecomendacao, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="numeroProposta")]
		[XmlElement(ElementName="numeroProposta")]
		public string gxTpr_Numeroproposta
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_Numeroproposta; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_Numeroproposta = value;
				SetDirty("Numeroproposta");
			}
		}




		[SoapElement(ElementName="cpf")]
		[XmlElement(ElementName="cpf")]
		public string gxTpr_Cpf
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_Cpf; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_Cpf = value;
				SetDirty("Cpf");
			}
		}




		[SoapElement(ElementName="nome")]
		[XmlElement(ElementName="nome")]
		public string gxTpr_Nome
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_Nome; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_Nome = value;
				SetDirty("Nome");
			}
		}



		[SoapElement(ElementName="valorOperacao")]
		[XmlElement(ElementName="valorOperacao")]
		public string gxTpr_Valoroperacao_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdConteudoRecomendaPF_data_Valoroperacao, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_Valoroperacao = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Valoroperacao
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_Valoroperacao; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_Valoroperacao = value;
				SetDirty("Valoroperacao");
			}
		}



		[SoapElement(ElementName="politica")]
		[XmlElement(ElementName="politica")]
		public string gxTpr_Politica_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdConteudoRecomendaPF_data_Politica, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_Politica = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Politica
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_Politica; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_Politica = value;
				SetDirty("Politica");
			}
		}



		[SoapElement(ElementName="criacao")]
		[XmlElement(ElementName="criacao" , IsNullable=true)]
		public string gxTpr_Criacao_Nullable
		{
			get {
				if ( gxTv_SdtSdConteudoRecomendaPF_data_Criacao == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSdConteudoRecomendaPF_data_Criacao).value ;
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_Criacao = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Criacao
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_Criacao; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_Criacao = value;
				SetDirty("Criacao");
			}
		}



		[SoapElement(ElementName="tipoVenda")]
		[XmlElement(ElementName="tipoVenda")]
		public string gxTpr_Tipovenda
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_Tipovenda; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_Tipovenda = value;
				SetDirty("Tipovenda");
			}
		}



		[SoapElement(ElementName="codTipoVenda")]
		[XmlElement(ElementName="codTipoVenda")]
		public string gxTpr_Codtipovenda_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdConteudoRecomendaPF_data_Codtipovenda, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_Codtipovenda = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Codtipovenda
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_Codtipovenda; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_Codtipovenda = value;
				SetDirty("Codtipovenda");
			}
		}



		[SoapElement(ElementName="codNivelRisco")]
		[XmlElement(ElementName="codNivelRisco")]
		public string gxTpr_Codnivelrisco_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdConteudoRecomendaPF_data_Codnivelrisco, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_Codnivelrisco = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Codnivelrisco
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_Codnivelrisco; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_Codnivelrisco = value;
				SetDirty("Codnivelrisco");
			}
		}




		[SoapElement(ElementName="tipoRecomendacao")]
		[XmlElement(ElementName="tipoRecomendacao")]
		public string gxTpr_Tiporecomendacao
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_Tiporecomendacao; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_Tiporecomendacao = value;
				SetDirty("Tiporecomendacao");
			}
		}




		[SoapElement(ElementName="tipoRecomendacaoVenda")]
		[XmlElement(ElementName="tipoRecomendacaoVenda")]
		public string gxTpr_Tiporecomendacaovenda
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_Tiporecomendacaovenda; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_Tiporecomendacaovenda = value;
				SetDirty("Tiporecomendacaovenda");
			}
		}



		[SoapElement(ElementName="criteriosAnalisados" )]
		[XmlElement(ElementName="criteriosAnalisados" )]
		public SdtSdConteudoRecomendaPF_data_criteriosAnalisados gxTpr_Criteriosanalisados
		{
			get {
				if ( gxTv_SdtSdConteudoRecomendaPF_data_Criteriosanalisados == null )
				{
					gxTv_SdtSdConteudoRecomendaPF_data_Criteriosanalisados = new SdtSdConteudoRecomendaPF_data_criteriosAnalisados(context);
				}
				gxTv_SdtSdConteudoRecomendaPF_data_Criteriosanalisados_N = false;
				SetDirty("Criteriosanalisados");
				return gxTv_SdtSdConteudoRecomendaPF_data_Criteriosanalisados;
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_Criteriosanalisados_N = false;
				gxTv_SdtSdConteudoRecomendaPF_data_Criteriosanalisados = value;
				SetDirty("Criteriosanalisados");
			}

		}

		public void gxTv_SdtSdConteudoRecomendaPF_data_Criteriosanalisados_SetNull()
		{
			gxTv_SdtSdConteudoRecomendaPF_data_Criteriosanalisados_N = true;
			gxTv_SdtSdConteudoRecomendaPF_data_Criteriosanalisados = null;
		}

		public bool gxTv_SdtSdConteudoRecomendaPF_data_Criteriosanalisados_IsNull()
		{
			return gxTv_SdtSdConteudoRecomendaPF_data_Criteriosanalisados == null;
		}
		public bool ShouldSerializegxTpr_Criteriosanalisados_Json()
		{
				return (gxTv_SdtSdConteudoRecomendaPF_data_Criteriosanalisados != null && gxTv_SdtSdConteudoRecomendaPF_data_Criteriosanalisados.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="valorLimiteRecomendado")]
		[XmlElement(ElementName="valorLimiteRecomendado")]
		public string gxTpr_Valorlimiterecomendado_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdConteudoRecomendaPF_data_Valorlimiterecomendado, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_Valorlimiterecomendado = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Valorlimiterecomendado
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_Valorlimiterecomendado; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_Valorlimiterecomendado = value;
				SetDirty("Valorlimiterecomendado");
			}
		}



		[SoapElement(ElementName="faixaRendaEstimada")]
		[XmlElement(ElementName="faixaRendaEstimada")]
		public string gxTpr_Faixarendaestimada_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdConteudoRecomendaPF_data_Faixarendaestimada, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_Faixarendaestimada = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Faixarendaestimada
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_Faixarendaestimada; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_Faixarendaestimada = value;
				SetDirty("Faixarendaestimada");
			}
		}




		[SoapElement(ElementName="mensagemRendaEstimada")]
		[XmlElement(ElementName="mensagemRendaEstimada")]
		public string gxTpr_Mensagemrendaestimada
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_Mensagemrendaestimada; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_Mensagemrendaestimada = value;
				SetDirty("Mensagemrendaestimada");
			}
		}



		[SoapElement(ElementName="informacoesAdicionais" )]
		[XmlElement(ElementName="informacoesAdicionais" )]
		public SdtSdConteudoRecomendaPF_data_informacoesAdicionais gxTpr_Informacoesadicionais
		{
			get {
				if ( gxTv_SdtSdConteudoRecomendaPF_data_Informacoesadicionais == null )
				{
					gxTv_SdtSdConteudoRecomendaPF_data_Informacoesadicionais = new SdtSdConteudoRecomendaPF_data_informacoesAdicionais(context);
				}
				gxTv_SdtSdConteudoRecomendaPF_data_Informacoesadicionais_N = false;
				SetDirty("Informacoesadicionais");
				return gxTv_SdtSdConteudoRecomendaPF_data_Informacoesadicionais;
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_Informacoesadicionais_N = false;
				gxTv_SdtSdConteudoRecomendaPF_data_Informacoesadicionais = value;
				SetDirty("Informacoesadicionais");
			}

		}

		public void gxTv_SdtSdConteudoRecomendaPF_data_Informacoesadicionais_SetNull()
		{
			gxTv_SdtSdConteudoRecomendaPF_data_Informacoesadicionais_N = true;
			gxTv_SdtSdConteudoRecomendaPF_data_Informacoesadicionais = null;
		}

		public bool gxTv_SdtSdConteudoRecomendaPF_data_Informacoesadicionais_IsNull()
		{
			return gxTv_SdtSdConteudoRecomendaPF_data_Informacoesadicionais == null;
		}
		public bool ShouldSerializegxTpr_Informacoesadicionais_Json()
		{
				return (gxTv_SdtSdConteudoRecomendaPF_data_Informacoesadicionais != null && gxTv_SdtSdConteudoRecomendaPF_data_Informacoesadicionais.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="score" )]
		[XmlElement(ElementName="score" )]
		public SdtSdConteudoRecomendaPF_data_score gxTpr_Score
		{
			get {
				if ( gxTv_SdtSdConteudoRecomendaPF_data_Score == null )
				{
					gxTv_SdtSdConteudoRecomendaPF_data_Score = new SdtSdConteudoRecomendaPF_data_score(context);
				}
				gxTv_SdtSdConteudoRecomendaPF_data_Score_N = false;
				SetDirty("Score");
				return gxTv_SdtSdConteudoRecomendaPF_data_Score;
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_Score_N = false;
				gxTv_SdtSdConteudoRecomendaPF_data_Score = value;
				SetDirty("Score");
			}

		}

		public void gxTv_SdtSdConteudoRecomendaPF_data_Score_SetNull()
		{
			gxTv_SdtSdConteudoRecomendaPF_data_Score_N = true;
			gxTv_SdtSdConteudoRecomendaPF_data_Score = null;
		}

		public bool gxTv_SdtSdConteudoRecomendaPF_data_Score_IsNull()
		{
			return gxTv_SdtSdConteudoRecomendaPF_data_Score == null;
		}
		public bool ShouldSerializegxTpr_Score_Json()
		{
				return (gxTv_SdtSdConteudoRecomendaPF_data_Score != null && gxTv_SdtSdConteudoRecomendaPF_data_Score.ShouldSerializeSdtJson());

		}



		[SoapElement(ElementName="mensagemScore")]
		[XmlElement(ElementName="mensagemScore")]
		public string gxTpr_Mensagemscore
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_Mensagemscore; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_Mensagemscore = value;
				SetDirty("Mensagemscore");
			}
		}



		[SoapElement(ElementName="identificacao" )]
		[XmlElement(ElementName="identificacao" )]
		public SdtSdConteudoRecomendaPF_data_identificacao gxTpr_Identificacao
		{
			get {
				if ( gxTv_SdtSdConteudoRecomendaPF_data_Identificacao == null )
				{
					gxTv_SdtSdConteudoRecomendaPF_data_Identificacao = new SdtSdConteudoRecomendaPF_data_identificacao(context);
				}
				gxTv_SdtSdConteudoRecomendaPF_data_Identificacao_N = false;
				SetDirty("Identificacao");
				return gxTv_SdtSdConteudoRecomendaPF_data_Identificacao;
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_Identificacao_N = false;
				gxTv_SdtSdConteudoRecomendaPF_data_Identificacao = value;
				SetDirty("Identificacao");
			}

		}

		public void gxTv_SdtSdConteudoRecomendaPF_data_Identificacao_SetNull()
		{
			gxTv_SdtSdConteudoRecomendaPF_data_Identificacao_N = true;
			gxTv_SdtSdConteudoRecomendaPF_data_Identificacao = null;
		}

		public bool gxTv_SdtSdConteudoRecomendaPF_data_Identificacao_IsNull()
		{
			return gxTv_SdtSdConteudoRecomendaPF_data_Identificacao == null;
		}
		public bool ShouldSerializegxTpr_Identificacao_Json()
		{
				return (gxTv_SdtSdConteudoRecomendaPF_data_Identificacao != null && gxTv_SdtSdConteudoRecomendaPF_data_Identificacao.ShouldSerializeSdtJson());

		}



		[SoapElement(ElementName="chequesDevolvidos" )]
		[XmlArray(ElementName="chequesDevolvidos"  )]
		[XmlArrayItemAttribute(ElementName="chequesDevolvidosItem" , IsNullable=false )]
		public GXBaseCollection<SdtSdConteudoRecomendaPF_data_chequesDevolvidosItem> gxTpr_Chequesdevolvidos
		{
			get {
				if ( gxTv_SdtSdConteudoRecomendaPF_data_Chequesdevolvidos == null )
				{
					gxTv_SdtSdConteudoRecomendaPF_data_Chequesdevolvidos = new GXBaseCollection<SdtSdConteudoRecomendaPF_data_chequesDevolvidosItem>( context, "SdConteudoRecomendaPF.data.chequesDevolvidosItem", "");
				}
				SetDirty("Chequesdevolvidos");
				return gxTv_SdtSdConteudoRecomendaPF_data_Chequesdevolvidos;
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_Chequesdevolvidos_N = false;
				gxTv_SdtSdConteudoRecomendaPF_data_Chequesdevolvidos = value;
				SetDirty("Chequesdevolvidos");
			}
		}

		public void gxTv_SdtSdConteudoRecomendaPF_data_Chequesdevolvidos_SetNull()
		{
			gxTv_SdtSdConteudoRecomendaPF_data_Chequesdevolvidos_N = true;
			gxTv_SdtSdConteudoRecomendaPF_data_Chequesdevolvidos = null;
		}

		public bool gxTv_SdtSdConteudoRecomendaPF_data_Chequesdevolvidos_IsNull()
		{
			return gxTv_SdtSdConteudoRecomendaPF_data_Chequesdevolvidos == null;
		}
		public bool ShouldSerializegxTpr_Chequesdevolvidos_GxSimpleCollection_Json()
		{
			return gxTv_SdtSdConteudoRecomendaPF_data_Chequesdevolvidos != null && gxTv_SdtSdConteudoRecomendaPF_data_Chequesdevolvidos.Count > 0;

		}



		[SoapElement(ElementName="anotacoesCompletas" )]
		[XmlArray(ElementName="anotacoesCompletas"  )]
		[XmlArrayItemAttribute(ElementName="anotacoesCompletasItem" , IsNullable=false )]
		public GXBaseCollection<SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem> gxTpr_Anotacoescompletas
		{
			get {
				if ( gxTv_SdtSdConteudoRecomendaPF_data_Anotacoescompletas == null )
				{
					gxTv_SdtSdConteudoRecomendaPF_data_Anotacoescompletas = new GXBaseCollection<SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem>( context, "SdConteudoRecomendaPF.data.anotacoesCompletasItem", "");
				}
				SetDirty("Anotacoescompletas");
				return gxTv_SdtSdConteudoRecomendaPF_data_Anotacoescompletas;
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_Anotacoescompletas_N = false;
				gxTv_SdtSdConteudoRecomendaPF_data_Anotacoescompletas = value;
				SetDirty("Anotacoescompletas");
			}
		}

		public void gxTv_SdtSdConteudoRecomendaPF_data_Anotacoescompletas_SetNull()
		{
			gxTv_SdtSdConteudoRecomendaPF_data_Anotacoescompletas_N = true;
			gxTv_SdtSdConteudoRecomendaPF_data_Anotacoescompletas = null;
		}

		public bool gxTv_SdtSdConteudoRecomendaPF_data_Anotacoescompletas_IsNull()
		{
			return gxTv_SdtSdConteudoRecomendaPF_data_Anotacoescompletas == null;
		}
		public bool ShouldSerializegxTpr_Anotacoescompletas_GxSimpleCollection_Json()
		{
			return gxTv_SdtSdConteudoRecomendaPF_data_Anotacoescompletas != null && gxTv_SdtSdConteudoRecomendaPF_data_Anotacoescompletas.Count > 0;

		}



		[SoapElement(ElementName="consultasDetalhadasSerasa" )]
		[XmlArray(ElementName="consultasDetalhadasSerasa"  )]
		[XmlArrayItemAttribute(ElementName="consultasDetalhadasSerasaItem" , IsNullable=false )]
		public GXBaseCollection<SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem> gxTpr_Consultasdetalhadasserasa
		{
			get {
				if ( gxTv_SdtSdConteudoRecomendaPF_data_Consultasdetalhadasserasa == null )
				{
					gxTv_SdtSdConteudoRecomendaPF_data_Consultasdetalhadasserasa = new GXBaseCollection<SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem>( context, "SdConteudoRecomendaPF.data.consultasDetalhadasSerasaItem", "");
				}
				SetDirty("Consultasdetalhadasserasa");
				return gxTv_SdtSdConteudoRecomendaPF_data_Consultasdetalhadasserasa;
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_Consultasdetalhadasserasa_N = false;
				gxTv_SdtSdConteudoRecomendaPF_data_Consultasdetalhadasserasa = value;
				SetDirty("Consultasdetalhadasserasa");
			}
		}

		public void gxTv_SdtSdConteudoRecomendaPF_data_Consultasdetalhadasserasa_SetNull()
		{
			gxTv_SdtSdConteudoRecomendaPF_data_Consultasdetalhadasserasa_N = true;
			gxTv_SdtSdConteudoRecomendaPF_data_Consultasdetalhadasserasa = null;
		}

		public bool gxTv_SdtSdConteudoRecomendaPF_data_Consultasdetalhadasserasa_IsNull()
		{
			return gxTv_SdtSdConteudoRecomendaPF_data_Consultasdetalhadasserasa == null;
		}
		public bool ShouldSerializegxTpr_Consultasdetalhadasserasa_GxSimpleCollection_Json()
		{
			return gxTv_SdtSdConteudoRecomendaPF_data_Consultasdetalhadasserasa != null && gxTv_SdtSdConteudoRecomendaPF_data_Consultasdetalhadasserasa.Count > 0;

		}


		[SoapElement(ElementName="enderecoPessoal" )]
		[XmlElement(ElementName="enderecoPessoal" )]
		public SdtSdConteudoRecomendaPF_data_enderecoPessoal gxTpr_Enderecopessoal
		{
			get {
				if ( gxTv_SdtSdConteudoRecomendaPF_data_Enderecopessoal == null )
				{
					gxTv_SdtSdConteudoRecomendaPF_data_Enderecopessoal = new SdtSdConteudoRecomendaPF_data_enderecoPessoal(context);
				}
				gxTv_SdtSdConteudoRecomendaPF_data_Enderecopessoal_N = false;
				SetDirty("Enderecopessoal");
				return gxTv_SdtSdConteudoRecomendaPF_data_Enderecopessoal;
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_Enderecopessoal_N = false;
				gxTv_SdtSdConteudoRecomendaPF_data_Enderecopessoal = value;
				SetDirty("Enderecopessoal");
			}

		}

		public void gxTv_SdtSdConteudoRecomendaPF_data_Enderecopessoal_SetNull()
		{
			gxTv_SdtSdConteudoRecomendaPF_data_Enderecopessoal_N = true;
			gxTv_SdtSdConteudoRecomendaPF_data_Enderecopessoal = null;
		}

		public bool gxTv_SdtSdConteudoRecomendaPF_data_Enderecopessoal_IsNull()
		{
			return gxTv_SdtSdConteudoRecomendaPF_data_Enderecopessoal == null;
		}
		public bool ShouldSerializegxTpr_Enderecopessoal_Json()
		{
				return (gxTv_SdtSdConteudoRecomendaPF_data_Enderecopessoal != null && gxTv_SdtSdConteudoRecomendaPF_data_Enderecopessoal.ShouldSerializeSdtJson());

		}



		[SoapElement(ElementName="enderecos" )]
		[XmlArray(ElementName="enderecos"  )]
		[XmlArrayItemAttribute(ElementName="enderecosItem" , IsNullable=false )]
		public GXBaseCollection<SdtSdConteudoRecomendaPF_data_enderecosItem> gxTpr_Enderecos
		{
			get {
				if ( gxTv_SdtSdConteudoRecomendaPF_data_Enderecos == null )
				{
					gxTv_SdtSdConteudoRecomendaPF_data_Enderecos = new GXBaseCollection<SdtSdConteudoRecomendaPF_data_enderecosItem>( context, "SdConteudoRecomendaPF.data.enderecosItem", "");
				}
				SetDirty("Enderecos");
				return gxTv_SdtSdConteudoRecomendaPF_data_Enderecos;
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_Enderecos_N = false;
				gxTv_SdtSdConteudoRecomendaPF_data_Enderecos = value;
				SetDirty("Enderecos");
			}
		}

		public void gxTv_SdtSdConteudoRecomendaPF_data_Enderecos_SetNull()
		{
			gxTv_SdtSdConteudoRecomendaPF_data_Enderecos_N = true;
			gxTv_SdtSdConteudoRecomendaPF_data_Enderecos = null;
		}

		public bool gxTv_SdtSdConteudoRecomendaPF_data_Enderecos_IsNull()
		{
			return gxTv_SdtSdConteudoRecomendaPF_data_Enderecos == null;
		}
		public bool ShouldSerializegxTpr_Enderecos_GxSimpleCollection_Json()
		{
			return gxTv_SdtSdConteudoRecomendaPF_data_Enderecos != null && gxTv_SdtSdConteudoRecomendaPF_data_Enderecos.Count > 0;

		}



		[SoapElement(ElementName="anotacoesNegativas" )]
		[XmlArray(ElementName="anotacoesNegativas"  )]
		[XmlArrayItemAttribute(ElementName="anotacoesNegativasItem" , IsNullable=false )]
		public GXBaseCollection<SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem> gxTpr_Anotacoesnegativas
		{
			get {
				if ( gxTv_SdtSdConteudoRecomendaPF_data_Anotacoesnegativas == null )
				{
					gxTv_SdtSdConteudoRecomendaPF_data_Anotacoesnegativas = new GXBaseCollection<SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem>( context, "SdConteudoRecomendaPF.data.anotacoesNegativasItem", "");
				}
				SetDirty("Anotacoesnegativas");
				return gxTv_SdtSdConteudoRecomendaPF_data_Anotacoesnegativas;
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_Anotacoesnegativas_N = false;
				gxTv_SdtSdConteudoRecomendaPF_data_Anotacoesnegativas = value;
				SetDirty("Anotacoesnegativas");
			}
		}

		public void gxTv_SdtSdConteudoRecomendaPF_data_Anotacoesnegativas_SetNull()
		{
			gxTv_SdtSdConteudoRecomendaPF_data_Anotacoesnegativas_N = true;
			gxTv_SdtSdConteudoRecomendaPF_data_Anotacoesnegativas = null;
		}

		public bool gxTv_SdtSdConteudoRecomendaPF_data_Anotacoesnegativas_IsNull()
		{
			return gxTv_SdtSdConteudoRecomendaPF_data_Anotacoesnegativas == null;
		}
		public bool ShouldSerializegxTpr_Anotacoesnegativas_GxSimpleCollection_Json()
		{
			return gxTv_SdtSdConteudoRecomendaPF_data_Anotacoesnegativas != null && gxTv_SdtSdConteudoRecomendaPF_data_Anotacoesnegativas.Count > 0;

		}


		[SoapElement(ElementName="criteriosMensagemRecomendacao" )]
		[XmlElement(ElementName="criteriosMensagemRecomendacao" )]
		public SdtSdConteudoRecomendaPF_data_criteriosMensagemRecomendacao gxTpr_Criteriosmensagemrecomendacao
		{
			get {
				if ( gxTv_SdtSdConteudoRecomendaPF_data_Criteriosmensagemrecomendacao == null )
				{
					gxTv_SdtSdConteudoRecomendaPF_data_Criteriosmensagemrecomendacao = new SdtSdConteudoRecomendaPF_data_criteriosMensagemRecomendacao(context);
				}
				gxTv_SdtSdConteudoRecomendaPF_data_Criteriosmensagemrecomendacao_N = false;
				SetDirty("Criteriosmensagemrecomendacao");
				return gxTv_SdtSdConteudoRecomendaPF_data_Criteriosmensagemrecomendacao;
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_Criteriosmensagemrecomendacao_N = false;
				gxTv_SdtSdConteudoRecomendaPF_data_Criteriosmensagemrecomendacao = value;
				SetDirty("Criteriosmensagemrecomendacao");
			}

		}

		public void gxTv_SdtSdConteudoRecomendaPF_data_Criteriosmensagemrecomendacao_SetNull()
		{
			gxTv_SdtSdConteudoRecomendaPF_data_Criteriosmensagemrecomendacao_N = true;
			gxTv_SdtSdConteudoRecomendaPF_data_Criteriosmensagemrecomendacao = null;
		}

		public bool gxTv_SdtSdConteudoRecomendaPF_data_Criteriosmensagemrecomendacao_IsNull()
		{
			return gxTv_SdtSdConteudoRecomendaPF_data_Criteriosmensagemrecomendacao == null;
		}
		public bool ShouldSerializegxTpr_Criteriosmensagemrecomendacao_Json()
		{
				return (gxTv_SdtSdConteudoRecomendaPF_data_Criteriosmensagemrecomendacao != null && gxTv_SdtSdConteudoRecomendaPF_data_Criteriosmensagemrecomendacao.ShouldSerializeSdtJson());

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
			gxTv_SdtSdConteudoRecomendaPF_data_Numeroproposta = "";
			gxTv_SdtSdConteudoRecomendaPF_data_Cpf = "";
			gxTv_SdtSdConteudoRecomendaPF_data_Nome = "";


			gxTv_SdtSdConteudoRecomendaPF_data_Criacao = (DateTime)(DateTime.MinValue);
			gxTv_SdtSdConteudoRecomendaPF_data_Tipovenda = "";


			gxTv_SdtSdConteudoRecomendaPF_data_Tiporecomendacao = "";
			gxTv_SdtSdConteudoRecomendaPF_data_Tiporecomendacaovenda = "";

			gxTv_SdtSdConteudoRecomendaPF_data_Criteriosanalisados_N = true;



			gxTv_SdtSdConteudoRecomendaPF_data_Mensagemrendaestimada = "";

			gxTv_SdtSdConteudoRecomendaPF_data_Informacoesadicionais_N = true;


			gxTv_SdtSdConteudoRecomendaPF_data_Score_N = true;

			gxTv_SdtSdConteudoRecomendaPF_data_Mensagemscore = "";

			gxTv_SdtSdConteudoRecomendaPF_data_Identificacao_N = true;


			gxTv_SdtSdConteudoRecomendaPF_data_Chequesdevolvidos_N = true;


			gxTv_SdtSdConteudoRecomendaPF_data_Anotacoescompletas_N = true;


			gxTv_SdtSdConteudoRecomendaPF_data_Consultasdetalhadasserasa_N = true;


			gxTv_SdtSdConteudoRecomendaPF_data_Enderecopessoal_N = true;


			gxTv_SdtSdConteudoRecomendaPF_data_Enderecos_N = true;


			gxTv_SdtSdConteudoRecomendaPF_data_Anotacoesnegativas_N = true;


			gxTv_SdtSdConteudoRecomendaPF_data_Criteriosmensagemrecomendacao_N = true;

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

		protected string gxTv_SdtSdConteudoRecomendaPF_data_Numeroproposta;
		 

		protected string gxTv_SdtSdConteudoRecomendaPF_data_Cpf;
		 

		protected string gxTv_SdtSdConteudoRecomendaPF_data_Nome;
		 

		protected decimal gxTv_SdtSdConteudoRecomendaPF_data_Valoroperacao;
		 

		protected decimal gxTv_SdtSdConteudoRecomendaPF_data_Politica;
		 

		protected DateTime gxTv_SdtSdConteudoRecomendaPF_data_Criacao;
		 

		protected string gxTv_SdtSdConteudoRecomendaPF_data_Tipovenda;
		 

		protected decimal gxTv_SdtSdConteudoRecomendaPF_data_Codtipovenda;
		 

		protected decimal gxTv_SdtSdConteudoRecomendaPF_data_Codnivelrisco;
		 

		protected string gxTv_SdtSdConteudoRecomendaPF_data_Tiporecomendacao;
		 

		protected string gxTv_SdtSdConteudoRecomendaPF_data_Tiporecomendacaovenda;
		 
		protected bool gxTv_SdtSdConteudoRecomendaPF_data_Criteriosanalisados_N;
		protected SdtSdConteudoRecomendaPF_data_criteriosAnalisados gxTv_SdtSdConteudoRecomendaPF_data_Criteriosanalisados = null; 


		protected decimal gxTv_SdtSdConteudoRecomendaPF_data_Valorlimiterecomendado;
		 

		protected decimal gxTv_SdtSdConteudoRecomendaPF_data_Faixarendaestimada;
		 

		protected string gxTv_SdtSdConteudoRecomendaPF_data_Mensagemrendaestimada;
		 
		protected bool gxTv_SdtSdConteudoRecomendaPF_data_Informacoesadicionais_N;
		protected SdtSdConteudoRecomendaPF_data_informacoesAdicionais gxTv_SdtSdConteudoRecomendaPF_data_Informacoesadicionais = null; 

		protected bool gxTv_SdtSdConteudoRecomendaPF_data_Score_N;
		protected SdtSdConteudoRecomendaPF_data_score gxTv_SdtSdConteudoRecomendaPF_data_Score = null; 


		protected string gxTv_SdtSdConteudoRecomendaPF_data_Mensagemscore;
		 
		protected bool gxTv_SdtSdConteudoRecomendaPF_data_Identificacao_N;
		protected SdtSdConteudoRecomendaPF_data_identificacao gxTv_SdtSdConteudoRecomendaPF_data_Identificacao = null; 

		protected bool gxTv_SdtSdConteudoRecomendaPF_data_Chequesdevolvidos_N;
		protected GXBaseCollection<SdtSdConteudoRecomendaPF_data_chequesDevolvidosItem> gxTv_SdtSdConteudoRecomendaPF_data_Chequesdevolvidos = null; 

		protected bool gxTv_SdtSdConteudoRecomendaPF_data_Anotacoescompletas_N;
		protected GXBaseCollection<SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem> gxTv_SdtSdConteudoRecomendaPF_data_Anotacoescompletas = null; 

		protected bool gxTv_SdtSdConteudoRecomendaPF_data_Consultasdetalhadasserasa_N;
		protected GXBaseCollection<SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem> gxTv_SdtSdConteudoRecomendaPF_data_Consultasdetalhadasserasa = null; 

		protected bool gxTv_SdtSdConteudoRecomendaPF_data_Enderecopessoal_N;
		protected SdtSdConteudoRecomendaPF_data_enderecoPessoal gxTv_SdtSdConteudoRecomendaPF_data_Enderecopessoal = null; 

		protected bool gxTv_SdtSdConteudoRecomendaPF_data_Enderecos_N;
		protected GXBaseCollection<SdtSdConteudoRecomendaPF_data_enderecosItem> gxTv_SdtSdConteudoRecomendaPF_data_Enderecos = null; 

		protected bool gxTv_SdtSdConteudoRecomendaPF_data_Anotacoesnegativas_N;
		protected GXBaseCollection<SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem> gxTv_SdtSdConteudoRecomendaPF_data_Anotacoesnegativas = null; 

		protected bool gxTv_SdtSdConteudoRecomendaPF_data_Criteriosmensagemrecomendacao_N;
		protected SdtSdConteudoRecomendaPF_data_criteriosMensagemRecomendacao gxTv_SdtSdConteudoRecomendaPF_data_Criteriosmensagemrecomendacao = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdConteudoRecomendaPF.data", Namespace="Factory21")]
	public class SdtSdConteudoRecomendaPF_data_RESTInterface : GxGenericCollectionItem<SdtSdConteudoRecomendaPF_data>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdConteudoRecomendaPF_data_RESTInterface( ) : base()
		{	
		}

		public SdtSdConteudoRecomendaPF_data_RESTInterface( SdtSdConteudoRecomendaPF_data psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("numeroProposta")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="numeroProposta", Order=0)]
		public  string gxTpr_Numeroproposta
		{
			get { 
				return sdt.gxTpr_Numeroproposta;

			}
			set { 
				 sdt.gxTpr_Numeroproposta = value;
			}
		}

		[JsonPropertyName("cpf")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="cpf", Order=1)]
		public  string gxTpr_Cpf
		{
			get { 
				return sdt.gxTpr_Cpf;

			}
			set { 
				 sdt.gxTpr_Cpf = value;
			}
		}

		[JsonPropertyName("nome")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="nome", Order=2)]
		public  string gxTpr_Nome
		{
			get { 
				return sdt.gxTpr_Nome;

			}
			set { 
				 sdt.gxTpr_Nome = value;
			}
		}

		[JsonPropertyName("valorOperacao")]
		[JsonPropertyOrder(3)]
		[DataMember(Name="valorOperacao", Order=3)]
		public  string gxTpr_Valoroperacao
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Valoroperacao, 10, 5));

			}
			set { 
				sdt.gxTpr_Valoroperacao =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("politica")]
		[JsonPropertyOrder(4)]
		[DataMember(Name="politica", Order=4)]
		public  string gxTpr_Politica
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Politica, 10, 5));

			}
			set { 
				sdt.gxTpr_Politica =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("criacao")]
		[JsonPropertyOrder(5)]
		[DataMember(Name="criacao", Order=5)]
		public  string gxTpr_Criacao
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Criacao,context);

			}
			set { 
				sdt.gxTpr_Criacao = DateTimeUtil.CToT2(value,context);
			}
		}

		[JsonPropertyName("tipoVenda")]
		[JsonPropertyOrder(6)]
		[DataMember(Name="tipoVenda", Order=6)]
		public  string gxTpr_Tipovenda
		{
			get { 
				return sdt.gxTpr_Tipovenda;

			}
			set { 
				 sdt.gxTpr_Tipovenda = value;
			}
		}

		[JsonPropertyName("codTipoVenda")]
		[JsonPropertyOrder(7)]
		[DataMember(Name="codTipoVenda", Order=7)]
		public  string gxTpr_Codtipovenda
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Codtipovenda, 10, 5));

			}
			set { 
				sdt.gxTpr_Codtipovenda =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("codNivelRisco")]
		[JsonPropertyOrder(8)]
		[DataMember(Name="codNivelRisco", Order=8)]
		public  string gxTpr_Codnivelrisco
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Codnivelrisco, 10, 5));

			}
			set { 
				sdt.gxTpr_Codnivelrisco =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("tipoRecomendacao")]
		[JsonPropertyOrder(9)]
		[DataMember(Name="tipoRecomendacao", Order=9)]
		public  string gxTpr_Tiporecomendacao
		{
			get { 
				return sdt.gxTpr_Tiporecomendacao;

			}
			set { 
				 sdt.gxTpr_Tiporecomendacao = value;
			}
		}

		[JsonPropertyName("tipoRecomendacaoVenda")]
		[JsonPropertyOrder(10)]
		[DataMember(Name="tipoRecomendacaoVenda", Order=10)]
		public  string gxTpr_Tiporecomendacaovenda
		{
			get { 
				return sdt.gxTpr_Tiporecomendacaovenda;

			}
			set { 
				 sdt.gxTpr_Tiporecomendacaovenda = value;
			}
		}

		[JsonPropertyName("criteriosAnalisados")]
		[JsonPropertyOrder(11)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="criteriosAnalisados", Order=11, EmitDefaultValue=false)]
		public SdtSdConteudoRecomendaPF_data_criteriosAnalisados_RESTInterface gxTpr_Criteriosanalisados
		{
			get {
				if (sdt.ShouldSerializegxTpr_Criteriosanalisados_Json())
					return new SdtSdConteudoRecomendaPF_data_criteriosAnalisados_RESTInterface(sdt.gxTpr_Criteriosanalisados);
				else
					return null;

			}

			set {
				sdt.gxTpr_Criteriosanalisados = value.sdt;
			}

		}

		[JsonPropertyName("valorLimiteRecomendado")]
		[JsonPropertyOrder(12)]
		[DataMember(Name="valorLimiteRecomendado", Order=12)]
		public  string gxTpr_Valorlimiterecomendado
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Valorlimiterecomendado, 10, 5));

			}
			set { 
				sdt.gxTpr_Valorlimiterecomendado =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("faixaRendaEstimada")]
		[JsonPropertyOrder(13)]
		[DataMember(Name="faixaRendaEstimada", Order=13)]
		public  string gxTpr_Faixarendaestimada
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Faixarendaestimada, 10, 5));

			}
			set { 
				sdt.gxTpr_Faixarendaestimada =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("mensagemRendaEstimada")]
		[JsonPropertyOrder(14)]
		[DataMember(Name="mensagemRendaEstimada", Order=14)]
		public  string gxTpr_Mensagemrendaestimada
		{
			get { 
				return sdt.gxTpr_Mensagemrendaestimada;

			}
			set { 
				 sdt.gxTpr_Mensagemrendaestimada = value;
			}
		}

		[JsonPropertyName("informacoesAdicionais")]
		[JsonPropertyOrder(15)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="informacoesAdicionais", Order=15, EmitDefaultValue=false)]
		public SdtSdConteudoRecomendaPF_data_informacoesAdicionais_RESTInterface gxTpr_Informacoesadicionais
		{
			get {
				if (sdt.ShouldSerializegxTpr_Informacoesadicionais_Json())
					return new SdtSdConteudoRecomendaPF_data_informacoesAdicionais_RESTInterface(sdt.gxTpr_Informacoesadicionais);
				else
					return null;

			}

			set {
				sdt.gxTpr_Informacoesadicionais = value.sdt;
			}

		}

		[JsonPropertyName("score")]
		[JsonPropertyOrder(16)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="score", Order=16, EmitDefaultValue=false)]
		public SdtSdConteudoRecomendaPF_data_score_RESTInterface gxTpr_Score
		{
			get {
				if (sdt.ShouldSerializegxTpr_Score_Json())
					return new SdtSdConteudoRecomendaPF_data_score_RESTInterface(sdt.gxTpr_Score);
				else
					return null;

			}

			set {
				sdt.gxTpr_Score = value.sdt;
			}

		}

		[JsonPropertyName("mensagemScore")]
		[JsonPropertyOrder(17)]
		[DataMember(Name="mensagemScore", Order=17)]
		public  string gxTpr_Mensagemscore
		{
			get { 
				return sdt.gxTpr_Mensagemscore;

			}
			set { 
				 sdt.gxTpr_Mensagemscore = value;
			}
		}

		[JsonPropertyName("identificacao")]
		[JsonPropertyOrder(18)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="identificacao", Order=18, EmitDefaultValue=false)]
		public SdtSdConteudoRecomendaPF_data_identificacao_RESTInterface gxTpr_Identificacao
		{
			get {
				if (sdt.ShouldSerializegxTpr_Identificacao_Json())
					return new SdtSdConteudoRecomendaPF_data_identificacao_RESTInterface(sdt.gxTpr_Identificacao);
				else
					return null;

			}

			set {
				sdt.gxTpr_Identificacao = value.sdt;
			}

		}

		[JsonPropertyName("chequesDevolvidos")]
		[JsonPropertyOrder(19)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="chequesDevolvidos", Order=19, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSdConteudoRecomendaPF_data_chequesDevolvidosItem_RESTInterface> gxTpr_Chequesdevolvidos
		{
			get {
				if (sdt.ShouldSerializegxTpr_Chequesdevolvidos_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSdConteudoRecomendaPF_data_chequesDevolvidosItem_RESTInterface>(sdt.gxTpr_Chequesdevolvidos);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Chequesdevolvidos);
			}
		}

		[JsonPropertyName("anotacoesCompletas")]
		[JsonPropertyOrder(20)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="anotacoesCompletas", Order=20, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_RESTInterface> gxTpr_Anotacoescompletas
		{
			get {
				if (sdt.ShouldSerializegxTpr_Anotacoescompletas_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_RESTInterface>(sdt.gxTpr_Anotacoescompletas);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Anotacoescompletas);
			}
		}

		[JsonPropertyName("consultasDetalhadasSerasa")]
		[JsonPropertyOrder(21)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="consultasDetalhadasSerasa", Order=21, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_RESTInterface> gxTpr_Consultasdetalhadasserasa
		{
			get {
				if (sdt.ShouldSerializegxTpr_Consultasdetalhadasserasa_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_RESTInterface>(sdt.gxTpr_Consultasdetalhadasserasa);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Consultasdetalhadasserasa);
			}
		}

		[JsonPropertyName("enderecoPessoal")]
		[JsonPropertyOrder(22)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="enderecoPessoal", Order=22, EmitDefaultValue=false)]
		public SdtSdConteudoRecomendaPF_data_enderecoPessoal_RESTInterface gxTpr_Enderecopessoal
		{
			get {
				if (sdt.ShouldSerializegxTpr_Enderecopessoal_Json())
					return new SdtSdConteudoRecomendaPF_data_enderecoPessoal_RESTInterface(sdt.gxTpr_Enderecopessoal);
				else
					return null;

			}

			set {
				sdt.gxTpr_Enderecopessoal = value.sdt;
			}

		}

		[JsonPropertyName("enderecos")]
		[JsonPropertyOrder(23)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="enderecos", Order=23, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSdConteudoRecomendaPF_data_enderecosItem_RESTInterface> gxTpr_Enderecos
		{
			get {
				if (sdt.ShouldSerializegxTpr_Enderecos_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSdConteudoRecomendaPF_data_enderecosItem_RESTInterface>(sdt.gxTpr_Enderecos);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Enderecos);
			}
		}

		[JsonPropertyName("anotacoesNegativas")]
		[JsonPropertyOrder(24)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="anotacoesNegativas", Order=24, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_RESTInterface> gxTpr_Anotacoesnegativas
		{
			get {
				if (sdt.ShouldSerializegxTpr_Anotacoesnegativas_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_RESTInterface>(sdt.gxTpr_Anotacoesnegativas);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Anotacoesnegativas);
			}
		}

		[JsonPropertyName("criteriosMensagemRecomendacao")]
		[JsonPropertyOrder(25)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="criteriosMensagemRecomendacao", Order=25, EmitDefaultValue=false)]
		public SdtSdConteudoRecomendaPF_data_criteriosMensagemRecomendacao_RESTInterface gxTpr_Criteriosmensagemrecomendacao
		{
			get {
				if (sdt.ShouldSerializegxTpr_Criteriosmensagemrecomendacao_Json())
					return new SdtSdConteudoRecomendaPF_data_criteriosMensagemRecomendacao_RESTInterface(sdt.gxTpr_Criteriosmensagemrecomendacao);
				else
					return null;

			}

			set {
				sdt.gxTpr_Criteriosmensagemrecomendacao = value.sdt;
			}

		}


		#endregion
		[JsonIgnore]
		public SdtSdConteudoRecomendaPF_data sdt
		{
			get { 
				return (SdtSdConteudoRecomendaPF_data)Sdt;
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
				sdt = new SdtSdConteudoRecomendaPF_data() ;
			}
		}
	}
	#endregion
}