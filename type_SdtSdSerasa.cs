/*
				   File: type_SdtSdSerasa
			Description: SdSerasa
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
	[XmlRoot(ElementName="SdSerasa")]
	[XmlType(TypeName="SdSerasa" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdSerasa : GxUserType
	{
		public SdtSdSerasa( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdSerasa_Numeroproposta = "";

			gxTv_SdtSdSerasa_Cpf = "";

			gxTv_SdtSdSerasa_Nome = "";

			gxTv_SdtSdSerasa_Politica = "";

			gxTv_SdtSdSerasa_Criacao = (DateTime)(DateTime.MinValue);

			gxTv_SdtSdSerasa_Tipovenda = "";

			gxTv_SdtSdSerasa_Tiporecomendacaovenda = "";

			gxTv_SdtSdSerasa_Faixarendaestimada = "";

			gxTv_SdtSdSerasa_Mensagemrendaestimada = "";

			gxTv_SdtSdSerasa_Mensagemscore = "";

		}

		public SdtSdSerasa(IGxContext context)
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


			AddObjectProperty("valorLimiteRecomendado", gxTpr_Valorlimiterecomendado, false);


			AddObjectProperty("faixaRendaEstimada", gxTpr_Faixarendaestimada, false);


			AddObjectProperty("mensagemRendaEstimada", gxTpr_Mensagemrendaestimada, false);


			AddObjectProperty("serasaScore", gxTpr_Serasascore, false);


			AddObjectProperty("mensagemScore", gxTpr_Mensagemscore, false);

			if (gxTv_SdtSdSerasa_Criteriosanalisados != null)
			{
				AddObjectProperty("criteriosAnalisados", gxTv_SdtSdSerasa_Criteriosanalisados, false);
			}
			if (gxTv_SdtSdSerasa_Informacoesadicionais != null)
			{
				AddObjectProperty("informacoesAdicionais", gxTv_SdtSdSerasa_Informacoesadicionais, false);
			}
			if (gxTv_SdtSdSerasa_Chequesdevolvidos != null)
			{
				AddObjectProperty("chequesDevolvidos", gxTv_SdtSdSerasa_Chequesdevolvidos, false);
			}
			if (gxTv_SdtSdSerasa_Falencias != null)
			{
				AddObjectProperty("falencias", gxTv_SdtSdSerasa_Falencias, false);
			}
			if (gxTv_SdtSdSerasa_Protestos != null)
			{
				AddObjectProperty("protestos", gxTv_SdtSdSerasa_Protestos, false);
			}
			if (gxTv_SdtSdSerasa_Dividasvencidas != null)
			{
				AddObjectProperty("dividasVencidas", gxTv_SdtSdSerasa_Dividasvencidas, false);
			}
			if (gxTv_SdtSdSerasa_Enderecopessoal != null)
			{
				AddObjectProperty("enderecoPessoal", gxTv_SdtSdSerasa_Enderecopessoal, false);
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
				return gxTv_SdtSdSerasa_Numeroproposta; 
			}
			set {
				gxTv_SdtSdSerasa_Numeroproposta = value;
				SetDirty("Numeroproposta");
			}
		}




		[SoapElement(ElementName="cpf")]
		[XmlElement(ElementName="cpf")]
		public string gxTpr_Cpf
		{
			get {
				return gxTv_SdtSdSerasa_Cpf; 
			}
			set {
				gxTv_SdtSdSerasa_Cpf = value;
				SetDirty("Cpf");
			}
		}




		[SoapElement(ElementName="nome")]
		[XmlElement(ElementName="nome")]
		public string gxTpr_Nome
		{
			get {
				return gxTv_SdtSdSerasa_Nome; 
			}
			set {
				gxTv_SdtSdSerasa_Nome = value;
				SetDirty("Nome");
			}
		}



		[SoapElement(ElementName="valorOperacao")]
		[XmlElement(ElementName="valorOperacao")]
		public string gxTpr_Valoroperacao_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdSerasa_Valoroperacao, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdSerasa_Valoroperacao = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Valoroperacao
		{
			get {
				return gxTv_SdtSdSerasa_Valoroperacao; 
			}
			set {
				gxTv_SdtSdSerasa_Valoroperacao = value;
				SetDirty("Valoroperacao");
			}
		}




		[SoapElement(ElementName="politica")]
		[XmlElement(ElementName="politica")]
		public string gxTpr_Politica
		{
			get {
				return gxTv_SdtSdSerasa_Politica; 
			}
			set {
				gxTv_SdtSdSerasa_Politica = value;
				SetDirty("Politica");
			}
		}



		[SoapElement(ElementName="criacao")]
		[XmlElement(ElementName="criacao" , IsNullable=true)]
		public string gxTpr_Criacao_Nullable
		{
			get {
				if ( gxTv_SdtSdSerasa_Criacao == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSdSerasa_Criacao).value ;
			}
			set {
				gxTv_SdtSdSerasa_Criacao = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Criacao
		{
			get {
				return gxTv_SdtSdSerasa_Criacao; 
			}
			set {
				gxTv_SdtSdSerasa_Criacao = value;
				SetDirty("Criacao");
			}
		}



		[SoapElement(ElementName="tipoVenda")]
		[XmlElement(ElementName="tipoVenda")]
		public string gxTpr_Tipovenda
		{
			get {
				return gxTv_SdtSdSerasa_Tipovenda; 
			}
			set {
				gxTv_SdtSdSerasa_Tipovenda = value;
				SetDirty("Tipovenda");
			}
		}



		[SoapElement(ElementName="codTipoVenda")]
		[XmlElement(ElementName="codTipoVenda")]
		public string gxTpr_Codtipovenda_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdSerasa_Codtipovenda, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdSerasa_Codtipovenda = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Codtipovenda
		{
			get {
				return gxTv_SdtSdSerasa_Codtipovenda; 
			}
			set {
				gxTv_SdtSdSerasa_Codtipovenda = value;
				SetDirty("Codtipovenda");
			}
		}



		[SoapElement(ElementName="codNivelRisco")]
		[XmlElement(ElementName="codNivelRisco")]
		public string gxTpr_Codnivelrisco_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdSerasa_Codnivelrisco, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdSerasa_Codnivelrisco = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Codnivelrisco
		{
			get {
				return gxTv_SdtSdSerasa_Codnivelrisco; 
			}
			set {
				gxTv_SdtSdSerasa_Codnivelrisco = value;
				SetDirty("Codnivelrisco");
			}
		}



		[SoapElement(ElementName="tipoRecomendacao")]
		[XmlElement(ElementName="tipoRecomendacao")]
		public string gxTpr_Tiporecomendacao_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdSerasa_Tiporecomendacao, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdSerasa_Tiporecomendacao = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Tiporecomendacao
		{
			get {
				return gxTv_SdtSdSerasa_Tiporecomendacao; 
			}
			set {
				gxTv_SdtSdSerasa_Tiporecomendacao = value;
				SetDirty("Tiporecomendacao");
			}
		}




		[SoapElement(ElementName="tipoRecomendacaoVenda")]
		[XmlElement(ElementName="tipoRecomendacaoVenda")]
		public string gxTpr_Tiporecomendacaovenda
		{
			get {
				return gxTv_SdtSdSerasa_Tiporecomendacaovenda; 
			}
			set {
				gxTv_SdtSdSerasa_Tiporecomendacaovenda = value;
				SetDirty("Tiporecomendacaovenda");
			}
		}



		[SoapElement(ElementName="valorLimiteRecomendado")]
		[XmlElement(ElementName="valorLimiteRecomendado")]
		public string gxTpr_Valorlimiterecomendado_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdSerasa_Valorlimiterecomendado, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdSerasa_Valorlimiterecomendado = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Valorlimiterecomendado
		{
			get {
				return gxTv_SdtSdSerasa_Valorlimiterecomendado; 
			}
			set {
				gxTv_SdtSdSerasa_Valorlimiterecomendado = value;
				SetDirty("Valorlimiterecomendado");
			}
		}




		[SoapElement(ElementName="faixaRendaEstimada")]
		[XmlElement(ElementName="faixaRendaEstimada")]
		public string gxTpr_Faixarendaestimada
		{
			get {
				return gxTv_SdtSdSerasa_Faixarendaestimada; 
			}
			set {
				gxTv_SdtSdSerasa_Faixarendaestimada = value;
				SetDirty("Faixarendaestimada");
			}
		}




		[SoapElement(ElementName="mensagemRendaEstimada")]
		[XmlElement(ElementName="mensagemRendaEstimada")]
		public string gxTpr_Mensagemrendaestimada
		{
			get {
				return gxTv_SdtSdSerasa_Mensagemrendaestimada; 
			}
			set {
				gxTv_SdtSdSerasa_Mensagemrendaestimada = value;
				SetDirty("Mensagemrendaestimada");
			}
		}



		[SoapElement(ElementName="serasaScore")]
		[XmlElement(ElementName="serasaScore")]
		public string gxTpr_Serasascore_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdSerasa_Serasascore, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdSerasa_Serasascore = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Serasascore
		{
			get {
				return gxTv_SdtSdSerasa_Serasascore; 
			}
			set {
				gxTv_SdtSdSerasa_Serasascore = value;
				SetDirty("Serasascore");
			}
		}




		[SoapElement(ElementName="mensagemScore")]
		[XmlElement(ElementName="mensagemScore")]
		public string gxTpr_Mensagemscore
		{
			get {
				return gxTv_SdtSdSerasa_Mensagemscore; 
			}
			set {
				gxTv_SdtSdSerasa_Mensagemscore = value;
				SetDirty("Mensagemscore");
			}
		}



		[SoapElement(ElementName="criteriosAnalisados" )]
		[XmlElement(ElementName="criteriosAnalisados" )]
		public SdtSdSerasa_criteriosAnalisados gxTpr_Criteriosanalisados
		{
			get {
				if ( gxTv_SdtSdSerasa_Criteriosanalisados == null )
				{
					gxTv_SdtSdSerasa_Criteriosanalisados = new SdtSdSerasa_criteriosAnalisados(context);
				}
				gxTv_SdtSdSerasa_Criteriosanalisados_N = false;
				SetDirty("Criteriosanalisados");
				return gxTv_SdtSdSerasa_Criteriosanalisados;
			}
			set {
				gxTv_SdtSdSerasa_Criteriosanalisados_N = false;
				gxTv_SdtSdSerasa_Criteriosanalisados = value;
				SetDirty("Criteriosanalisados");
			}

		}

		public void gxTv_SdtSdSerasa_Criteriosanalisados_SetNull()
		{
			gxTv_SdtSdSerasa_Criteriosanalisados_N = true;
			gxTv_SdtSdSerasa_Criteriosanalisados = null;
		}

		public bool gxTv_SdtSdSerasa_Criteriosanalisados_IsNull()
		{
			return gxTv_SdtSdSerasa_Criteriosanalisados == null;
		}
		public bool ShouldSerializegxTpr_Criteriosanalisados_Json()
		{
				return (gxTv_SdtSdSerasa_Criteriosanalisados != null && gxTv_SdtSdSerasa_Criteriosanalisados.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="informacoesAdicionais" )]
		[XmlElement(ElementName="informacoesAdicionais" )]
		public SdtSdSerasa_informacoesAdicionais gxTpr_Informacoesadicionais
		{
			get {
				if ( gxTv_SdtSdSerasa_Informacoesadicionais == null )
				{
					gxTv_SdtSdSerasa_Informacoesadicionais = new SdtSdSerasa_informacoesAdicionais(context);
				}
				gxTv_SdtSdSerasa_Informacoesadicionais_N = false;
				SetDirty("Informacoesadicionais");
				return gxTv_SdtSdSerasa_Informacoesadicionais;
			}
			set {
				gxTv_SdtSdSerasa_Informacoesadicionais_N = false;
				gxTv_SdtSdSerasa_Informacoesadicionais = value;
				SetDirty("Informacoesadicionais");
			}

		}

		public void gxTv_SdtSdSerasa_Informacoesadicionais_SetNull()
		{
			gxTv_SdtSdSerasa_Informacoesadicionais_N = true;
			gxTv_SdtSdSerasa_Informacoesadicionais = null;
		}

		public bool gxTv_SdtSdSerasa_Informacoesadicionais_IsNull()
		{
			return gxTv_SdtSdSerasa_Informacoesadicionais == null;
		}
		public bool ShouldSerializegxTpr_Informacoesadicionais_Json()
		{
				return (gxTv_SdtSdSerasa_Informacoesadicionais != null && gxTv_SdtSdSerasa_Informacoesadicionais.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="chequesDevolvidos" )]
		[XmlElement(ElementName="chequesDevolvidos" )]
		public SdtSdSerasa_chequesDevolvidos gxTpr_Chequesdevolvidos
		{
			get {
				if ( gxTv_SdtSdSerasa_Chequesdevolvidos == null )
				{
					gxTv_SdtSdSerasa_Chequesdevolvidos = new SdtSdSerasa_chequesDevolvidos(context);
				}
				gxTv_SdtSdSerasa_Chequesdevolvidos_N = false;
				SetDirty("Chequesdevolvidos");
				return gxTv_SdtSdSerasa_Chequesdevolvidos;
			}
			set {
				gxTv_SdtSdSerasa_Chequesdevolvidos_N = false;
				gxTv_SdtSdSerasa_Chequesdevolvidos = value;
				SetDirty("Chequesdevolvidos");
			}

		}

		public void gxTv_SdtSdSerasa_Chequesdevolvidos_SetNull()
		{
			gxTv_SdtSdSerasa_Chequesdevolvidos_N = true;
			gxTv_SdtSdSerasa_Chequesdevolvidos = null;
		}

		public bool gxTv_SdtSdSerasa_Chequesdevolvidos_IsNull()
		{
			return gxTv_SdtSdSerasa_Chequesdevolvidos == null;
		}
		public bool ShouldSerializegxTpr_Chequesdevolvidos_Json()
		{
				return (gxTv_SdtSdSerasa_Chequesdevolvidos != null && gxTv_SdtSdSerasa_Chequesdevolvidos.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="falencias" )]
		[XmlElement(ElementName="falencias" )]
		public SdtSdSerasa_falencias gxTpr_Falencias
		{
			get {
				if ( gxTv_SdtSdSerasa_Falencias == null )
				{
					gxTv_SdtSdSerasa_Falencias = new SdtSdSerasa_falencias(context);
				}
				gxTv_SdtSdSerasa_Falencias_N = false;
				SetDirty("Falencias");
				return gxTv_SdtSdSerasa_Falencias;
			}
			set {
				gxTv_SdtSdSerasa_Falencias_N = false;
				gxTv_SdtSdSerasa_Falencias = value;
				SetDirty("Falencias");
			}

		}

		public void gxTv_SdtSdSerasa_Falencias_SetNull()
		{
			gxTv_SdtSdSerasa_Falencias_N = true;
			gxTv_SdtSdSerasa_Falencias = null;
		}

		public bool gxTv_SdtSdSerasa_Falencias_IsNull()
		{
			return gxTv_SdtSdSerasa_Falencias == null;
		}
		public bool ShouldSerializegxTpr_Falencias_Json()
		{
				return (gxTv_SdtSdSerasa_Falencias != null && gxTv_SdtSdSerasa_Falencias.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="protestos" )]
		[XmlElement(ElementName="protestos" )]
		public SdtSdSerasa_protestos gxTpr_Protestos
		{
			get {
				if ( gxTv_SdtSdSerasa_Protestos == null )
				{
					gxTv_SdtSdSerasa_Protestos = new SdtSdSerasa_protestos(context);
				}
				gxTv_SdtSdSerasa_Protestos_N = false;
				SetDirty("Protestos");
				return gxTv_SdtSdSerasa_Protestos;
			}
			set {
				gxTv_SdtSdSerasa_Protestos_N = false;
				gxTv_SdtSdSerasa_Protestos = value;
				SetDirty("Protestos");
			}

		}

		public void gxTv_SdtSdSerasa_Protestos_SetNull()
		{
			gxTv_SdtSdSerasa_Protestos_N = true;
			gxTv_SdtSdSerasa_Protestos = null;
		}

		public bool gxTv_SdtSdSerasa_Protestos_IsNull()
		{
			return gxTv_SdtSdSerasa_Protestos == null;
		}
		public bool ShouldSerializegxTpr_Protestos_Json()
		{
				return (gxTv_SdtSdSerasa_Protestos != null && gxTv_SdtSdSerasa_Protestos.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="dividasVencidas" )]
		[XmlElement(ElementName="dividasVencidas" )]
		public SdtSdSerasa_dividasVencidas gxTpr_Dividasvencidas
		{
			get {
				if ( gxTv_SdtSdSerasa_Dividasvencidas == null )
				{
					gxTv_SdtSdSerasa_Dividasvencidas = new SdtSdSerasa_dividasVencidas(context);
				}
				gxTv_SdtSdSerasa_Dividasvencidas_N = false;
				SetDirty("Dividasvencidas");
				return gxTv_SdtSdSerasa_Dividasvencidas;
			}
			set {
				gxTv_SdtSdSerasa_Dividasvencidas_N = false;
				gxTv_SdtSdSerasa_Dividasvencidas = value;
				SetDirty("Dividasvencidas");
			}

		}

		public void gxTv_SdtSdSerasa_Dividasvencidas_SetNull()
		{
			gxTv_SdtSdSerasa_Dividasvencidas_N = true;
			gxTv_SdtSdSerasa_Dividasvencidas = null;
		}

		public bool gxTv_SdtSdSerasa_Dividasvencidas_IsNull()
		{
			return gxTv_SdtSdSerasa_Dividasvencidas == null;
		}
		public bool ShouldSerializegxTpr_Dividasvencidas_Json()
		{
				return (gxTv_SdtSdSerasa_Dividasvencidas != null && gxTv_SdtSdSerasa_Dividasvencidas.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="enderecoPessoal" )]
		[XmlElement(ElementName="enderecoPessoal" )]
		public SdtSdSerasa_enderecoPessoal gxTpr_Enderecopessoal
		{
			get {
				if ( gxTv_SdtSdSerasa_Enderecopessoal == null )
				{
					gxTv_SdtSdSerasa_Enderecopessoal = new SdtSdSerasa_enderecoPessoal(context);
				}
				gxTv_SdtSdSerasa_Enderecopessoal_N = false;
				SetDirty("Enderecopessoal");
				return gxTv_SdtSdSerasa_Enderecopessoal;
			}
			set {
				gxTv_SdtSdSerasa_Enderecopessoal_N = false;
				gxTv_SdtSdSerasa_Enderecopessoal = value;
				SetDirty("Enderecopessoal");
			}

		}

		public void gxTv_SdtSdSerasa_Enderecopessoal_SetNull()
		{
			gxTv_SdtSdSerasa_Enderecopessoal_N = true;
			gxTv_SdtSdSerasa_Enderecopessoal = null;
		}

		public bool gxTv_SdtSdSerasa_Enderecopessoal_IsNull()
		{
			return gxTv_SdtSdSerasa_Enderecopessoal == null;
		}
		public bool ShouldSerializegxTpr_Enderecopessoal_Json()
		{
				return (gxTv_SdtSdSerasa_Enderecopessoal != null && gxTv_SdtSdSerasa_Enderecopessoal.ShouldSerializeSdtJson());

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
			gxTv_SdtSdSerasa_Numeroproposta = "";
			gxTv_SdtSdSerasa_Cpf = "";
			gxTv_SdtSdSerasa_Nome = "";

			gxTv_SdtSdSerasa_Politica = "";
			gxTv_SdtSdSerasa_Criacao = (DateTime)(DateTime.MinValue);
			gxTv_SdtSdSerasa_Tipovenda = "";



			gxTv_SdtSdSerasa_Tiporecomendacaovenda = "";

			gxTv_SdtSdSerasa_Faixarendaestimada = "";
			gxTv_SdtSdSerasa_Mensagemrendaestimada = "";

			gxTv_SdtSdSerasa_Mensagemscore = "";

			gxTv_SdtSdSerasa_Criteriosanalisados_N = true;


			gxTv_SdtSdSerasa_Informacoesadicionais_N = true;


			gxTv_SdtSdSerasa_Chequesdevolvidos_N = true;


			gxTv_SdtSdSerasa_Falencias_N = true;


			gxTv_SdtSdSerasa_Protestos_N = true;


			gxTv_SdtSdSerasa_Dividasvencidas_N = true;


			gxTv_SdtSdSerasa_Enderecopessoal_N = true;

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

		protected string gxTv_SdtSdSerasa_Numeroproposta;
		 

		protected string gxTv_SdtSdSerasa_Cpf;
		 

		protected string gxTv_SdtSdSerasa_Nome;
		 

		protected decimal gxTv_SdtSdSerasa_Valoroperacao;
		 

		protected string gxTv_SdtSdSerasa_Politica;
		 

		protected DateTime gxTv_SdtSdSerasa_Criacao;
		 

		protected string gxTv_SdtSdSerasa_Tipovenda;
		 

		protected decimal gxTv_SdtSdSerasa_Codtipovenda;
		 

		protected decimal gxTv_SdtSdSerasa_Codnivelrisco;
		 

		protected decimal gxTv_SdtSdSerasa_Tiporecomendacao;
		 

		protected string gxTv_SdtSdSerasa_Tiporecomendacaovenda;
		 

		protected decimal gxTv_SdtSdSerasa_Valorlimiterecomendado;
		 

		protected string gxTv_SdtSdSerasa_Faixarendaestimada;
		 

		protected string gxTv_SdtSdSerasa_Mensagemrendaestimada;
		 

		protected decimal gxTv_SdtSdSerasa_Serasascore;
		 

		protected string gxTv_SdtSdSerasa_Mensagemscore;
		 
		protected bool gxTv_SdtSdSerasa_Criteriosanalisados_N;
		protected SdtSdSerasa_criteriosAnalisados gxTv_SdtSdSerasa_Criteriosanalisados = null; 

		protected bool gxTv_SdtSdSerasa_Informacoesadicionais_N;
		protected SdtSdSerasa_informacoesAdicionais gxTv_SdtSdSerasa_Informacoesadicionais = null; 

		protected bool gxTv_SdtSdSerasa_Chequesdevolvidos_N;
		protected SdtSdSerasa_chequesDevolvidos gxTv_SdtSdSerasa_Chequesdevolvidos = null; 

		protected bool gxTv_SdtSdSerasa_Falencias_N;
		protected SdtSdSerasa_falencias gxTv_SdtSdSerasa_Falencias = null; 

		protected bool gxTv_SdtSdSerasa_Protestos_N;
		protected SdtSdSerasa_protestos gxTv_SdtSdSerasa_Protestos = null; 

		protected bool gxTv_SdtSdSerasa_Dividasvencidas_N;
		protected SdtSdSerasa_dividasVencidas gxTv_SdtSdSerasa_Dividasvencidas = null; 

		protected bool gxTv_SdtSdSerasa_Enderecopessoal_N;
		protected SdtSdSerasa_enderecoPessoal gxTv_SdtSdSerasa_Enderecopessoal = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdSerasa", Namespace="Factory21")]
	public class SdtSdSerasa_RESTInterface : GxGenericCollectionItem<SdtSdSerasa>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdSerasa_RESTInterface( ) : base()
		{	
		}

		public SdtSdSerasa_RESTInterface( SdtSdSerasa psdt ) : base(psdt)
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
				return sdt.gxTpr_Politica;

			}
			set { 
				 sdt.gxTpr_Politica = value;
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
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Tiporecomendacao, 10, 5));

			}
			set { 
				sdt.gxTpr_Tiporecomendacao =  NumberUtil.Val( value, ".");
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

		[JsonPropertyName("valorLimiteRecomendado")]
		[JsonPropertyOrder(11)]
		[DataMember(Name="valorLimiteRecomendado", Order=11)]
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
		[JsonPropertyOrder(12)]
		[DataMember(Name="faixaRendaEstimada", Order=12)]
		public  string gxTpr_Faixarendaestimada
		{
			get { 
				return sdt.gxTpr_Faixarendaestimada;

			}
			set { 
				 sdt.gxTpr_Faixarendaestimada = value;
			}
		}

		[JsonPropertyName("mensagemRendaEstimada")]
		[JsonPropertyOrder(13)]
		[DataMember(Name="mensagemRendaEstimada", Order=13)]
		public  string gxTpr_Mensagemrendaestimada
		{
			get { 
				return sdt.gxTpr_Mensagemrendaestimada;

			}
			set { 
				 sdt.gxTpr_Mensagemrendaestimada = value;
			}
		}

		[JsonPropertyName("serasaScore")]
		[JsonPropertyOrder(14)]
		[DataMember(Name="serasaScore", Order=14)]
		public  string gxTpr_Serasascore
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Serasascore, 10, 5));

			}
			set { 
				sdt.gxTpr_Serasascore =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("mensagemScore")]
		[JsonPropertyOrder(15)]
		[DataMember(Name="mensagemScore", Order=15)]
		public  string gxTpr_Mensagemscore
		{
			get { 
				return sdt.gxTpr_Mensagemscore;

			}
			set { 
				 sdt.gxTpr_Mensagemscore = value;
			}
		}

		[JsonPropertyName("criteriosAnalisados")]
		[JsonPropertyOrder(16)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="criteriosAnalisados", Order=16, EmitDefaultValue=false)]
		public SdtSdSerasa_criteriosAnalisados_RESTInterface gxTpr_Criteriosanalisados
		{
			get {
				if (sdt.ShouldSerializegxTpr_Criteriosanalisados_Json())
					return new SdtSdSerasa_criteriosAnalisados_RESTInterface(sdt.gxTpr_Criteriosanalisados);
				else
					return null;

			}

			set {
				sdt.gxTpr_Criteriosanalisados = value.sdt;
			}

		}

		[JsonPropertyName("informacoesAdicionais")]
		[JsonPropertyOrder(17)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="informacoesAdicionais", Order=17, EmitDefaultValue=false)]
		public SdtSdSerasa_informacoesAdicionais_RESTInterface gxTpr_Informacoesadicionais
		{
			get {
				if (sdt.ShouldSerializegxTpr_Informacoesadicionais_Json())
					return new SdtSdSerasa_informacoesAdicionais_RESTInterface(sdt.gxTpr_Informacoesadicionais);
				else
					return null;

			}

			set {
				sdt.gxTpr_Informacoesadicionais = value.sdt;
			}

		}

		[JsonPropertyName("chequesDevolvidos")]
		[JsonPropertyOrder(18)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="chequesDevolvidos", Order=18, EmitDefaultValue=false)]
		public SdtSdSerasa_chequesDevolvidos_RESTInterface gxTpr_Chequesdevolvidos
		{
			get {
				if (sdt.ShouldSerializegxTpr_Chequesdevolvidos_Json())
					return new SdtSdSerasa_chequesDevolvidos_RESTInterface(sdt.gxTpr_Chequesdevolvidos);
				else
					return null;

			}

			set {
				sdt.gxTpr_Chequesdevolvidos = value.sdt;
			}

		}

		[JsonPropertyName("falencias")]
		[JsonPropertyOrder(19)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="falencias", Order=19, EmitDefaultValue=false)]
		public SdtSdSerasa_falencias_RESTInterface gxTpr_Falencias
		{
			get {
				if (sdt.ShouldSerializegxTpr_Falencias_Json())
					return new SdtSdSerasa_falencias_RESTInterface(sdt.gxTpr_Falencias);
				else
					return null;

			}

			set {
				sdt.gxTpr_Falencias = value.sdt;
			}

		}

		[JsonPropertyName("protestos")]
		[JsonPropertyOrder(20)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="protestos", Order=20, EmitDefaultValue=false)]
		public SdtSdSerasa_protestos_RESTInterface gxTpr_Protestos
		{
			get {
				if (sdt.ShouldSerializegxTpr_Protestos_Json())
					return new SdtSdSerasa_protestos_RESTInterface(sdt.gxTpr_Protestos);
				else
					return null;

			}

			set {
				sdt.gxTpr_Protestos = value.sdt;
			}

		}

		[JsonPropertyName("dividasVencidas")]
		[JsonPropertyOrder(21)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="dividasVencidas", Order=21, EmitDefaultValue=false)]
		public SdtSdSerasa_dividasVencidas_RESTInterface gxTpr_Dividasvencidas
		{
			get {
				if (sdt.ShouldSerializegxTpr_Dividasvencidas_Json())
					return new SdtSdSerasa_dividasVencidas_RESTInterface(sdt.gxTpr_Dividasvencidas);
				else
					return null;

			}

			set {
				sdt.gxTpr_Dividasvencidas = value.sdt;
			}

		}

		[JsonPropertyName("enderecoPessoal")]
		[JsonPropertyOrder(22)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="enderecoPessoal", Order=22, EmitDefaultValue=false)]
		public SdtSdSerasa_enderecoPessoal_RESTInterface gxTpr_Enderecopessoal
		{
			get {
				if (sdt.ShouldSerializegxTpr_Enderecopessoal_Json())
					return new SdtSdSerasa_enderecoPessoal_RESTInterface(sdt.gxTpr_Enderecopessoal);
				else
					return null;

			}

			set {
				sdt.gxTpr_Enderecopessoal = value.sdt;
			}

		}


		#endregion
		[JsonIgnore]
		public SdtSdSerasa sdt
		{
			get { 
				return (SdtSdSerasa)Sdt;
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
				sdt = new SdtSdSerasa() ;
			}
		}
	}
	#endregion
}