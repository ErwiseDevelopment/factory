/*
				   File: type_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem
			Description: WPRegistrarTituloSDT
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
	[XmlRoot(ElementName="WPRegistrarTituloSDTItem")]
	[XmlType(TypeName="WPRegistrarTituloSDTItem" , Namespace="Factory21" )]
	[Serializable]
	public class SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem : GxUserType
	{
		public SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Tituloclienterazaosocial = "";

			gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulopropostadescricao = "";

			gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulopropostatipo = "";

			gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulocompetencia_f = "";

			gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulocep = "";

			gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulologradouro = "";

			gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulonumeroendereco = "";

			gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulocomplemento = "";

			gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulobairro = "";

			gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulomunicipio = "";

			gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulotipo = "";

			gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulocriacao = (DateTime)(DateTime.MinValue);

			gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulostatus_f = "";

			gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Notafiscalnumero = "";

		}

		public SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem(IGxContext context)
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
			AddObjectProperty("TituloId", gxTpr_Tituloid, false);


			AddObjectProperty("TituloClienteId", gxTpr_Tituloclienteid, false);


			AddObjectProperty("TituloCLienteRazaoSocial", gxTpr_Tituloclienterazaosocial, false);


			AddObjectProperty("TituloPropostaDescricao", gxTpr_Titulopropostadescricao, false);


			AddObjectProperty("TituloPropostaTipo", gxTpr_Titulopropostatipo, false);


			AddObjectProperty("TituloValor", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Titulovalor, 18, 2)), false);


			AddObjectProperty("TituloDesconto", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Titulodesconto, 18, 2)), false);


			AddObjectProperty("TituloDeleted", gxTpr_Titulodeleted, false);


			AddObjectProperty("TituloArchived", gxTpr_Tituloarchived, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Titulovencimento)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Titulovencimento)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Titulovencimento)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("TituloVencimento", sDateCnv, false);



			AddObjectProperty("TituloCompetenciaMes", gxTpr_Titulocompetenciames, false);


			AddObjectProperty("TituloCompetenciaAno", gxTpr_Titulocompetenciaano, false);


			AddObjectProperty("TituloCompetencia_F", gxTpr_Titulocompetencia_f, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Tituloprorrogacao)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Tituloprorrogacao)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Tituloprorrogacao)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("TituloProrrogacao", sDateCnv, false);



			AddObjectProperty("TituloCEP", gxTpr_Titulocep, false);


			AddObjectProperty("TituloLogradouro", gxTpr_Titulologradouro, false);


			AddObjectProperty("TituloNumeroEndereco", gxTpr_Titulonumeroendereco, false);


			AddObjectProperty("TituloComplemento", gxTpr_Titulocomplemento, false);


			AddObjectProperty("TituloBairro", gxTpr_Titulobairro, false);


			AddObjectProperty("TituloMunicipio", gxTpr_Titulomunicipio, false);


			AddObjectProperty("TituloJurosMora", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Titulojurosmora, 16, 4)), false);


			AddObjectProperty("TituloTipo", gxTpr_Titulotipo, false);


			AddObjectProperty("TituloPropostaId", gxTpr_Titulopropostaid, false);


			AddObjectProperty("PropostaTaxaAdministrativa", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Propostataxaadministrativa, 16, 4)), false);


			AddObjectProperty("ContaId", gxTpr_Contaid, false);


			datetime_STZ = gxTpr_Titulocriacao;
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
			AddObjectProperty("TituloCriacao", sDateCnv, false);



			AddObjectProperty("CategoriaTituloId", gxTpr_Categoriatituloid, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Titulodatacredito_f)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Titulodatacredito_f)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Titulodatacredito_f)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("TituloDataCredito_F", sDateCnv, false);



			AddObjectProperty("TituloTotalMovimento_F", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Titulototalmovimento_f, 18, 2)), false);


			AddObjectProperty("TituloTotalMultaJuros_F", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Titulototalmultajuros_f, 18, 2)), false);


			AddObjectProperty("TituloSaldo_F", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Titulosaldo_f, 18, 2)), false);


			AddObjectProperty("TituloStatus_F", gxTpr_Titulostatus_f, false);


			AddObjectProperty("NotaFiscalParcelamentoID", gxTpr_Notafiscalparcelamentoid, false);


			AddObjectProperty("NotaFiscalNumero", gxTpr_Notafiscalnumero, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="TituloId")]
		[XmlElement(ElementName="TituloId")]
		public int gxTpr_Tituloid
		{
			get {
				return gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Tituloid; 
			}
			set {
				gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Tituloid = value;
				SetDirty("Tituloid");
			}
		}




		[SoapElement(ElementName="TituloClienteId")]
		[XmlElement(ElementName="TituloClienteId")]
		public int gxTpr_Tituloclienteid
		{
			get {
				return gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Tituloclienteid; 
			}
			set {
				gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Tituloclienteid = value;
				SetDirty("Tituloclienteid");
			}
		}




		[SoapElement(ElementName="TituloCLienteRazaoSocial")]
		[XmlElement(ElementName="TituloCLienteRazaoSocial")]
		public string gxTpr_Tituloclienterazaosocial
		{
			get {
				return gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Tituloclienterazaosocial; 
			}
			set {
				gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Tituloclienterazaosocial = value;
				SetDirty("Tituloclienterazaosocial");
			}
		}




		[SoapElement(ElementName="TituloPropostaDescricao")]
		[XmlElement(ElementName="TituloPropostaDescricao")]
		public string gxTpr_Titulopropostadescricao
		{
			get {
				return gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulopropostadescricao; 
			}
			set {
				gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulopropostadescricao = value;
				SetDirty("Titulopropostadescricao");
			}
		}




		[SoapElement(ElementName="TituloPropostaTipo")]
		[XmlElement(ElementName="TituloPropostaTipo")]
		public string gxTpr_Titulopropostatipo
		{
			get {
				return gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulopropostatipo; 
			}
			set {
				gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulopropostatipo = value;
				SetDirty("Titulopropostatipo");
			}
		}



		[SoapElement(ElementName="TituloValor")]
		[XmlElement(ElementName="TituloValor")]
		public string gxTpr_Titulovalor_double
		{
			get {
				return Convert.ToString(gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulovalor, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulovalor = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Titulovalor
		{
			get {
				return gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulovalor; 
			}
			set {
				gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulovalor = value;
				SetDirty("Titulovalor");
			}
		}



		[SoapElement(ElementName="TituloDesconto")]
		[XmlElement(ElementName="TituloDesconto")]
		public string gxTpr_Titulodesconto_double
		{
			get {
				return Convert.ToString(gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulodesconto, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulodesconto = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Titulodesconto
		{
			get {
				return gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulodesconto; 
			}
			set {
				gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulodesconto = value;
				SetDirty("Titulodesconto");
			}
		}




		[SoapElement(ElementName="TituloDeleted")]
		[XmlElement(ElementName="TituloDeleted")]
		public bool gxTpr_Titulodeleted
		{
			get {
				return gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulodeleted; 
			}
			set {
				gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulodeleted = value;
				SetDirty("Titulodeleted");
			}
		}




		[SoapElement(ElementName="TituloArchived")]
		[XmlElement(ElementName="TituloArchived")]
		public bool gxTpr_Tituloarchived
		{
			get {
				return gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Tituloarchived; 
			}
			set {
				gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Tituloarchived = value;
				SetDirty("Tituloarchived");
			}
		}



		[SoapElement(ElementName="TituloVencimento")]
		[XmlElement(ElementName="TituloVencimento" , IsNullable=true)]
		public string gxTpr_Titulovencimento_Nullable
		{
			get {
				if ( gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulovencimento == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulovencimento).value ;
			}
			set {
				gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulovencimento = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Titulovencimento
		{
			get {
				return gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulovencimento; 
			}
			set {
				gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulovencimento = value;
				SetDirty("Titulovencimento");
			}
		}



		[SoapElement(ElementName="TituloCompetenciaMes")]
		[XmlElement(ElementName="TituloCompetenciaMes")]
		public short gxTpr_Titulocompetenciames
		{
			get {
				return gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulocompetenciames; 
			}
			set {
				gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulocompetenciames = value;
				SetDirty("Titulocompetenciames");
			}
		}




		[SoapElement(ElementName="TituloCompetenciaAno")]
		[XmlElement(ElementName="TituloCompetenciaAno")]
		public short gxTpr_Titulocompetenciaano
		{
			get {
				return gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulocompetenciaano; 
			}
			set {
				gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulocompetenciaano = value;
				SetDirty("Titulocompetenciaano");
			}
		}




		[SoapElement(ElementName="TituloCompetencia_F")]
		[XmlElement(ElementName="TituloCompetencia_F")]
		public string gxTpr_Titulocompetencia_f
		{
			get {
				return gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulocompetencia_f; 
			}
			set {
				gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulocompetencia_f = value;
				SetDirty("Titulocompetencia_f");
			}
		}



		[SoapElement(ElementName="TituloProrrogacao")]
		[XmlElement(ElementName="TituloProrrogacao" , IsNullable=true)]
		public string gxTpr_Tituloprorrogacao_Nullable
		{
			get {
				if ( gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Tituloprorrogacao == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Tituloprorrogacao).value ;
			}
			set {
				gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Tituloprorrogacao = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Tituloprorrogacao
		{
			get {
				return gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Tituloprorrogacao; 
			}
			set {
				gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Tituloprorrogacao = value;
				SetDirty("Tituloprorrogacao");
			}
		}



		[SoapElement(ElementName="TituloCEP")]
		[XmlElement(ElementName="TituloCEP")]
		public string gxTpr_Titulocep
		{
			get {
				return gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulocep; 
			}
			set {
				gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulocep = value;
				SetDirty("Titulocep");
			}
		}




		[SoapElement(ElementName="TituloLogradouro")]
		[XmlElement(ElementName="TituloLogradouro")]
		public string gxTpr_Titulologradouro
		{
			get {
				return gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulologradouro; 
			}
			set {
				gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulologradouro = value;
				SetDirty("Titulologradouro");
			}
		}




		[SoapElement(ElementName="TituloNumeroEndereco")]
		[XmlElement(ElementName="TituloNumeroEndereco")]
		public string gxTpr_Titulonumeroendereco
		{
			get {
				return gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulonumeroendereco; 
			}
			set {
				gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulonumeroendereco = value;
				SetDirty("Titulonumeroendereco");
			}
		}




		[SoapElement(ElementName="TituloComplemento")]
		[XmlElement(ElementName="TituloComplemento")]
		public string gxTpr_Titulocomplemento
		{
			get {
				return gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulocomplemento; 
			}
			set {
				gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulocomplemento = value;
				SetDirty("Titulocomplemento");
			}
		}




		[SoapElement(ElementName="TituloBairro")]
		[XmlElement(ElementName="TituloBairro")]
		public string gxTpr_Titulobairro
		{
			get {
				return gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulobairro; 
			}
			set {
				gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulobairro = value;
				SetDirty("Titulobairro");
			}
		}




		[SoapElement(ElementName="TituloMunicipio")]
		[XmlElement(ElementName="TituloMunicipio")]
		public string gxTpr_Titulomunicipio
		{
			get {
				return gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulomunicipio; 
			}
			set {
				gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulomunicipio = value;
				SetDirty("Titulomunicipio");
			}
		}



		[SoapElement(ElementName="TituloJurosMora")]
		[XmlElement(ElementName="TituloJurosMora")]
		public string gxTpr_Titulojurosmora_double
		{
			get {
				return Convert.ToString(gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulojurosmora, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulojurosmora = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Titulojurosmora
		{
			get {
				return gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulojurosmora; 
			}
			set {
				gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulojurosmora = value;
				SetDirty("Titulojurosmora");
			}
		}




		[SoapElement(ElementName="TituloTipo")]
		[XmlElement(ElementName="TituloTipo")]
		public string gxTpr_Titulotipo
		{
			get {
				return gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulotipo; 
			}
			set {
				gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulotipo = value;
				SetDirty("Titulotipo");
			}
		}




		[SoapElement(ElementName="TituloPropostaId")]
		[XmlElement(ElementName="TituloPropostaId")]
		public int gxTpr_Titulopropostaid
		{
			get {
				return gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulopropostaid; 
			}
			set {
				gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulopropostaid = value;
				SetDirty("Titulopropostaid");
			}
		}



		[SoapElement(ElementName="PropostaTaxaAdministrativa")]
		[XmlElement(ElementName="PropostaTaxaAdministrativa")]
		public string gxTpr_Propostataxaadministrativa_double
		{
			get {
				return Convert.ToString(gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Propostataxaadministrativa, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Propostataxaadministrativa = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Propostataxaadministrativa
		{
			get {
				return gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Propostataxaadministrativa; 
			}
			set {
				gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Propostataxaadministrativa = value;
				SetDirty("Propostataxaadministrativa");
			}
		}




		[SoapElement(ElementName="ContaId")]
		[XmlElement(ElementName="ContaId")]
		public int gxTpr_Contaid
		{
			get {
				return gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Contaid; 
			}
			set {
				gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Contaid = value;
				SetDirty("Contaid");
			}
		}



		[SoapElement(ElementName="TituloCriacao")]
		[XmlElement(ElementName="TituloCriacao" , IsNullable=true)]
		public string gxTpr_Titulocriacao_Nullable
		{
			get {
				if ( gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulocriacao == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulocriacao).value ;
			}
			set {
				gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulocriacao = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Titulocriacao
		{
			get {
				return gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulocriacao; 
			}
			set {
				gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulocriacao = value;
				SetDirty("Titulocriacao");
			}
		}



		[SoapElement(ElementName="CategoriaTituloId")]
		[XmlElement(ElementName="CategoriaTituloId")]
		public int gxTpr_Categoriatituloid
		{
			get {
				return gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Categoriatituloid; 
			}
			set {
				gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Categoriatituloid = value;
				SetDirty("Categoriatituloid");
			}
		}



		[SoapElement(ElementName="TituloDataCredito_F")]
		[XmlElement(ElementName="TituloDataCredito_F" , IsNullable=true)]
		public string gxTpr_Titulodatacredito_f_Nullable
		{
			get {
				if ( gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulodatacredito_f == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulodatacredito_f).value ;
			}
			set {
				gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulodatacredito_f = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Titulodatacredito_f
		{
			get {
				return gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulodatacredito_f; 
			}
			set {
				gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulodatacredito_f = value;
				SetDirty("Titulodatacredito_f");
			}
		}


		[SoapElement(ElementName="TituloTotalMovimento_F")]
		[XmlElement(ElementName="TituloTotalMovimento_F")]
		public string gxTpr_Titulototalmovimento_f_double
		{
			get {
				return Convert.ToString(gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulototalmovimento_f, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulototalmovimento_f = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Titulototalmovimento_f
		{
			get {
				return gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulototalmovimento_f; 
			}
			set {
				gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulototalmovimento_f = value;
				SetDirty("Titulototalmovimento_f");
			}
		}



		[SoapElement(ElementName="TituloTotalMultaJuros_F")]
		[XmlElement(ElementName="TituloTotalMultaJuros_F")]
		public string gxTpr_Titulototalmultajuros_f_double
		{
			get {
				return Convert.ToString(gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulototalmultajuros_f, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulototalmultajuros_f = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Titulototalmultajuros_f
		{
			get {
				return gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulototalmultajuros_f; 
			}
			set {
				gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulototalmultajuros_f = value;
				SetDirty("Titulototalmultajuros_f");
			}
		}



		[SoapElement(ElementName="TituloSaldo_F")]
		[XmlElement(ElementName="TituloSaldo_F")]
		public string gxTpr_Titulosaldo_f_double
		{
			get {
				return Convert.ToString(gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulosaldo_f, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulosaldo_f = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Titulosaldo_f
		{
			get {
				return gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulosaldo_f; 
			}
			set {
				gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulosaldo_f = value;
				SetDirty("Titulosaldo_f");
			}
		}




		[SoapElement(ElementName="TituloStatus_F")]
		[XmlElement(ElementName="TituloStatus_F")]
		public string gxTpr_Titulostatus_f
		{
			get {
				return gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulostatus_f; 
			}
			set {
				gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulostatus_f = value;
				SetDirty("Titulostatus_f");
			}
		}




		[SoapElement(ElementName="NotaFiscalParcelamentoID")]
		[XmlElement(ElementName="NotaFiscalParcelamentoID")]
		public Guid gxTpr_Notafiscalparcelamentoid
		{
			get {
				return gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Notafiscalparcelamentoid; 
			}
			set {
				gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Notafiscalparcelamentoid = value;
				SetDirty("Notafiscalparcelamentoid");
			}
		}




		[SoapElement(ElementName="NotaFiscalNumero")]
		[XmlElement(ElementName="NotaFiscalNumero")]
		public string gxTpr_Notafiscalnumero
		{
			get {
				return gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Notafiscalnumero; 
			}
			set {
				gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Notafiscalnumero = value;
				SetDirty("Notafiscalnumero");
			}
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
			gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Tituloclienterazaosocial = "";
			gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulopropostadescricao = "";
			gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulopropostatipo = "";







			gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulocompetencia_f = "";

			gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulocep = "";
			gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulologradouro = "";
			gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulonumeroendereco = "";
			gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulocomplemento = "";
			gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulobairro = "";
			gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulomunicipio = "";

			gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulotipo = "";



			gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulocriacao = (DateTime)(DateTime.MinValue);





			gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulostatus_f = "";

			gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Notafiscalnumero = "";
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

		protected int gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Tituloid;
		 

		protected int gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Tituloclienteid;
		 

		protected string gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Tituloclienterazaosocial;
		 

		protected string gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulopropostadescricao;
		 

		protected string gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulopropostatipo;
		 

		protected decimal gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulovalor;
		 

		protected decimal gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulodesconto;
		 

		protected bool gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulodeleted;
		 

		protected bool gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Tituloarchived;
		 

		protected DateTime gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulovencimento;
		 

		protected short gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulocompetenciames;
		 

		protected short gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulocompetenciaano;
		 

		protected string gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulocompetencia_f;
		 

		protected DateTime gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Tituloprorrogacao;
		 

		protected string gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulocep;
		 

		protected string gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulologradouro;
		 

		protected string gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulonumeroendereco;
		 

		protected string gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulocomplemento;
		 

		protected string gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulobairro;
		 

		protected string gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulomunicipio;
		 

		protected decimal gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulojurosmora;
		 

		protected string gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulotipo;
		 

		protected int gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulopropostaid;
		 

		protected decimal gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Propostataxaadministrativa;
		 

		protected int gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Contaid;
		 

		protected DateTime gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulocriacao;
		 

		protected int gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Categoriatituloid;
		 

		protected DateTime gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulodatacredito_f;
		 

		protected decimal gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulototalmovimento_f;
		 

		protected decimal gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulototalmultajuros_f;
		 

		protected decimal gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulosaldo_f;
		 

		protected string gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Titulostatus_f;
		 

		protected Guid gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Notafiscalparcelamentoid;
		 

		protected string gxTv_SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_Notafiscalnumero;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"WPRegistrarTituloSDTItem", Namespace="Factory21")]
	public class SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_RESTInterface : GxGenericCollectionItem<SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_RESTInterface( ) : base()
		{	
		}

		public SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem_RESTInterface( SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("TituloId")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="TituloId", Order=0)]
		public  string gxTpr_Tituloid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Tituloid, 9, 0));

			}
			set { 
				sdt.gxTpr_Tituloid = (int) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("TituloClienteId")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="TituloClienteId", Order=1)]
		public  string gxTpr_Tituloclienteid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Tituloclienteid, 9, 0));

			}
			set { 
				sdt.gxTpr_Tituloclienteid = (int) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("TituloCLienteRazaoSocial")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="TituloCLienteRazaoSocial", Order=2)]
		public  string gxTpr_Tituloclienterazaosocial
		{
			get { 
				return sdt.gxTpr_Tituloclienterazaosocial;

			}
			set { 
				 sdt.gxTpr_Tituloclienterazaosocial = value;
			}
		}

		[JsonPropertyName("TituloPropostaDescricao")]
		[JsonPropertyOrder(3)]
		[DataMember(Name="TituloPropostaDescricao", Order=3)]
		public  string gxTpr_Titulopropostadescricao
		{
			get { 
				return sdt.gxTpr_Titulopropostadescricao;

			}
			set { 
				 sdt.gxTpr_Titulopropostadescricao = value;
			}
		}

		[JsonPropertyName("TituloPropostaTipo")]
		[JsonPropertyOrder(4)]
		[DataMember(Name="TituloPropostaTipo", Order=4)]
		public  string gxTpr_Titulopropostatipo
		{
			get { 
				return sdt.gxTpr_Titulopropostatipo;

			}
			set { 
				 sdt.gxTpr_Titulopropostatipo = value;
			}
		}

		[JsonPropertyName("TituloValor")]
		[JsonPropertyOrder(5)]
		[DataMember(Name="TituloValor", Order=5)]
		public  string gxTpr_Titulovalor
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Titulovalor, 18, 2));

			}
			set { 
				sdt.gxTpr_Titulovalor =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("TituloDesconto")]
		[JsonPropertyOrder(6)]
		[DataMember(Name="TituloDesconto", Order=6)]
		public  string gxTpr_Titulodesconto
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Titulodesconto, 18, 2));

			}
			set { 
				sdt.gxTpr_Titulodesconto =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("TituloDeleted")]
		[JsonPropertyOrder(7)]
		[JsonConverter(typeof(BoolStringJsonConverter))]
		[DataMember(Name="TituloDeleted", Order=7)]
		public bool gxTpr_Titulodeleted
		{
			get { 
				return sdt.gxTpr_Titulodeleted;

			}
			set { 
				sdt.gxTpr_Titulodeleted = value;
			}
		}

		[JsonPropertyName("TituloArchived")]
		[JsonPropertyOrder(8)]
		[JsonConverter(typeof(BoolStringJsonConverter))]
		[DataMember(Name="TituloArchived", Order=8)]
		public bool gxTpr_Tituloarchived
		{
			get { 
				return sdt.gxTpr_Tituloarchived;

			}
			set { 
				sdt.gxTpr_Tituloarchived = value;
			}
		}

		[JsonPropertyName("TituloVencimento")]
		[JsonPropertyOrder(9)]
		[DataMember(Name="TituloVencimento", Order=9)]
		public  string gxTpr_Titulovencimento
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Titulovencimento);

			}
			set { 
				sdt.gxTpr_Titulovencimento = DateTimeUtil.CToD2(value);
			}
		}

		[JsonPropertyName("TituloCompetenciaMes")]
		[JsonPropertyOrder(10)]
		[DataMember(Name="TituloCompetenciaMes", Order=10)]
		public short gxTpr_Titulocompetenciames
		{
			get { 
				return sdt.gxTpr_Titulocompetenciames;

			}
			set { 
				sdt.gxTpr_Titulocompetenciames = value;
			}
		}

		[JsonPropertyName("TituloCompetenciaAno")]
		[JsonPropertyOrder(11)]
		[DataMember(Name="TituloCompetenciaAno", Order=11)]
		public short gxTpr_Titulocompetenciaano
		{
			get { 
				return sdt.gxTpr_Titulocompetenciaano;

			}
			set { 
				sdt.gxTpr_Titulocompetenciaano = value;
			}
		}

		[JsonPropertyName("TituloCompetencia_F")]
		[JsonPropertyOrder(12)]
		[DataMember(Name="TituloCompetencia_F", Order=12)]
		public  string gxTpr_Titulocompetencia_f
		{
			get { 
				return sdt.gxTpr_Titulocompetencia_f;

			}
			set { 
				 sdt.gxTpr_Titulocompetencia_f = value;
			}
		}

		[JsonPropertyName("TituloProrrogacao")]
		[JsonPropertyOrder(13)]
		[DataMember(Name="TituloProrrogacao", Order=13)]
		public  string gxTpr_Tituloprorrogacao
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Tituloprorrogacao);

			}
			set { 
				sdt.gxTpr_Tituloprorrogacao = DateTimeUtil.CToD2(value);
			}
		}

		[JsonPropertyName("TituloCEP")]
		[JsonPropertyOrder(14)]
		[DataMember(Name="TituloCEP", Order=14)]
		public  string gxTpr_Titulocep
		{
			get { 
				return sdt.gxTpr_Titulocep;

			}
			set { 
				 sdt.gxTpr_Titulocep = value;
			}
		}

		[JsonPropertyName("TituloLogradouro")]
		[JsonPropertyOrder(15)]
		[DataMember(Name="TituloLogradouro", Order=15)]
		public  string gxTpr_Titulologradouro
		{
			get { 
				return sdt.gxTpr_Titulologradouro;

			}
			set { 
				 sdt.gxTpr_Titulologradouro = value;
			}
		}

		[JsonPropertyName("TituloNumeroEndereco")]
		[JsonPropertyOrder(16)]
		[DataMember(Name="TituloNumeroEndereco", Order=16)]
		public  string gxTpr_Titulonumeroendereco
		{
			get { 
				return sdt.gxTpr_Titulonumeroendereco;

			}
			set { 
				 sdt.gxTpr_Titulonumeroendereco = value;
			}
		}

		[JsonPropertyName("TituloComplemento")]
		[JsonPropertyOrder(17)]
		[DataMember(Name="TituloComplemento", Order=17)]
		public  string gxTpr_Titulocomplemento
		{
			get { 
				return sdt.gxTpr_Titulocomplemento;

			}
			set { 
				 sdt.gxTpr_Titulocomplemento = value;
			}
		}

		[JsonPropertyName("TituloBairro")]
		[JsonPropertyOrder(18)]
		[DataMember(Name="TituloBairro", Order=18)]
		public  string gxTpr_Titulobairro
		{
			get { 
				return sdt.gxTpr_Titulobairro;

			}
			set { 
				 sdt.gxTpr_Titulobairro = value;
			}
		}

		[JsonPropertyName("TituloMunicipio")]
		[JsonPropertyOrder(19)]
		[DataMember(Name="TituloMunicipio", Order=19)]
		public  string gxTpr_Titulomunicipio
		{
			get { 
				return sdt.gxTpr_Titulomunicipio;

			}
			set { 
				 sdt.gxTpr_Titulomunicipio = value;
			}
		}

		[JsonPropertyName("TituloJurosMora")]
		[JsonPropertyOrder(20)]
		[DataMember(Name="TituloJurosMora", Order=20)]
		public  string gxTpr_Titulojurosmora
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Titulojurosmora, 16, 4));

			}
			set { 
				sdt.gxTpr_Titulojurosmora =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("TituloTipo")]
		[JsonPropertyOrder(21)]
		[DataMember(Name="TituloTipo", Order=21)]
		public  string gxTpr_Titulotipo
		{
			get { 
				return sdt.gxTpr_Titulotipo;

			}
			set { 
				 sdt.gxTpr_Titulotipo = value;
			}
		}

		[JsonPropertyName("TituloPropostaId")]
		[JsonPropertyOrder(22)]
		[DataMember(Name="TituloPropostaId", Order=22)]
		public  string gxTpr_Titulopropostaid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Titulopropostaid, 9, 0));

			}
			set { 
				sdt.gxTpr_Titulopropostaid = (int) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("PropostaTaxaAdministrativa")]
		[JsonPropertyOrder(23)]
		[DataMember(Name="PropostaTaxaAdministrativa", Order=23)]
		public  string gxTpr_Propostataxaadministrativa
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Propostataxaadministrativa, 16, 4));

			}
			set { 
				sdt.gxTpr_Propostataxaadministrativa =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("ContaId")]
		[JsonPropertyOrder(24)]
		[DataMember(Name="ContaId", Order=24)]
		public  string gxTpr_Contaid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Contaid, 9, 0));

			}
			set { 
				sdt.gxTpr_Contaid = (int) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("TituloCriacao")]
		[JsonPropertyOrder(25)]
		[DataMember(Name="TituloCriacao", Order=25)]
		public  string gxTpr_Titulocriacao
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Titulocriacao,context);

			}
			set { 
				sdt.gxTpr_Titulocriacao = DateTimeUtil.CToT2(value,context);
			}
		}

		[JsonPropertyName("CategoriaTituloId")]
		[JsonPropertyOrder(26)]
		[DataMember(Name="CategoriaTituloId", Order=26)]
		public  string gxTpr_Categoriatituloid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Categoriatituloid, 9, 0));

			}
			set { 
				sdt.gxTpr_Categoriatituloid = (int) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("TituloDataCredito_F")]
		[JsonPropertyOrder(27)]
		[DataMember(Name="TituloDataCredito_F", Order=27)]
		public  string gxTpr_Titulodatacredito_f
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Titulodatacredito_f);

			}
			set { 
				sdt.gxTpr_Titulodatacredito_f = DateTimeUtil.CToD2(value);
			}
		}

		[JsonPropertyName("TituloTotalMovimento_F")]
		[JsonPropertyOrder(28)]
		[DataMember(Name="TituloTotalMovimento_F", Order=28)]
		public  string gxTpr_Titulototalmovimento_f
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Titulototalmovimento_f, 18, 2));

			}
			set { 
				sdt.gxTpr_Titulototalmovimento_f =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("TituloTotalMultaJuros_F")]
		[JsonPropertyOrder(29)]
		[DataMember(Name="TituloTotalMultaJuros_F", Order=29)]
		public  string gxTpr_Titulototalmultajuros_f
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Titulototalmultajuros_f, 18, 2));

			}
			set { 
				sdt.gxTpr_Titulototalmultajuros_f =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("TituloSaldo_F")]
		[JsonPropertyOrder(30)]
		[DataMember(Name="TituloSaldo_F", Order=30)]
		public  string gxTpr_Titulosaldo_f
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Titulosaldo_f, 18, 2));

			}
			set { 
				sdt.gxTpr_Titulosaldo_f =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("TituloStatus_F")]
		[JsonPropertyOrder(31)]
		[DataMember(Name="TituloStatus_F", Order=31)]
		public  string gxTpr_Titulostatus_f
		{
			get { 
				return sdt.gxTpr_Titulostatus_f;

			}
			set { 
				 sdt.gxTpr_Titulostatus_f = value;
			}
		}

		[JsonPropertyName("NotaFiscalParcelamentoID")]
		[JsonPropertyOrder(32)]
		[DataMember(Name="NotaFiscalParcelamentoID", Order=32)]
		public Guid gxTpr_Notafiscalparcelamentoid
		{
			get { 
				return sdt.gxTpr_Notafiscalparcelamentoid;

			}
			set { 
				sdt.gxTpr_Notafiscalparcelamentoid = value;
			}
		}

		[JsonPropertyName("NotaFiscalNumero")]
		[JsonPropertyOrder(33)]
		[DataMember(Name="NotaFiscalNumero", Order=33)]
		public  string gxTpr_Notafiscalnumero
		{
			get { 
				return sdt.gxTpr_Notafiscalnumero;

			}
			set { 
				 sdt.gxTpr_Notafiscalnumero = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem sdt
		{
			get { 
				return (SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem)Sdt;
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
				sdt = new SdtWPRegistrarTituloSDT_WPRegistrarTituloSDTItem() ;
			}
		}
	}
	#endregion
}