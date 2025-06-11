/*
				   File: type_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem
			Description: SelecionarTitulosSDT
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
	[XmlRoot(ElementName="SelecionarTitulosSDTItem")]
	[XmlType(TypeName="SelecionarTitulosSDTItem" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem : GxUserType
	{
		public SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Tituloclienterazaosocial = "";

			gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulocompetencia_f = "";

			gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulocep = "";

			gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulologradouro = "";

			gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulonumeroendereco = "";

			gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulocomplemento = "";

			gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulobairro = "";

			gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulomunicipio = "";

			gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulotipo = "";

			gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulopropostadescricao = "";

			gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulocriacao = (DateTime)(DateTime.MinValue);

			gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulostatus_f = "";

			gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulopropostatipo = "";

			gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Notafiscalnumero = "";

			gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Agenciabanconome = "";

			gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Tituloscarteiradecobranca = "";

		}

		public SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem(IGxContext context)
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



			AddObjectProperty("TituloCompetenciaAno", gxTpr_Titulocompetenciaano, false);


			AddObjectProperty("TituloCompetenciaMes", gxTpr_Titulocompetenciames, false);


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


			AddObjectProperty("TituloPropostaDescricao", gxTpr_Titulopropostadescricao, false);


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


			AddObjectProperty("TituloSaldoDebito_F", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Titulosaldodebito_f, 18, 2)), false);


			AddObjectProperty("TituloSaldoCredito_F", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Titulosaldocredito_f, 18, 2)), false);


			AddObjectProperty("TituloTotalMovimentoDebito_F", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Titulototalmovimentodebito_f, 18, 2)), false);


			AddObjectProperty("TituloTotalMovimentoCredito_F", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Titulototalmovimentocredito_f, 18, 2)), false);


			AddObjectProperty("TituloTotalMultaJurosDebito_F", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Titulototalmultajurosdebito_f, 18, 2)), false);


			AddObjectProperty("TituloTotalMultaJurosCredito_F", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Titulototalmultajuroscredito_f, 18, 2)), false);


			AddObjectProperty("TituloPropostaTipo", gxTpr_Titulopropostatipo, false);


			AddObjectProperty("NotaFiscalParcelamentoID", gxTpr_Notafiscalparcelamentoid, false);


			AddObjectProperty("NotaFiscalNumero", gxTpr_Notafiscalnumero, false);


			AddObjectProperty("ContaBancariaId", gxTpr_Contabancariaid, false);


			AddObjectProperty("AgenciaBancoNome", gxTpr_Agenciabanconome, false);


			AddObjectProperty("ContaBancariaCarteira", gxTpr_Contabancariacarteira, false);


			AddObjectProperty("ContaBancariaNumero", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Contabancarianumero, 18, 0)), false);


			AddObjectProperty("AgenciaNumero", gxTpr_Agencianumero, false);


			AddObjectProperty("TitulosEmCarteiraDeCobranca_F", gxTpr_Titulosemcarteiradecobranca_f, false);


			AddObjectProperty("TitulosCarteiraDeCobranca", gxTpr_Tituloscarteiradecobranca, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="TituloId")]
		[XmlElement(ElementName="TituloId")]
		public int gxTpr_Tituloid
		{
			get {
				return gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Tituloid; 
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Tituloid = value;
				SetDirty("Tituloid");
			}
		}




		[SoapElement(ElementName="TituloClienteId")]
		[XmlElement(ElementName="TituloClienteId")]
		public int gxTpr_Tituloclienteid
		{
			get {
				return gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Tituloclienteid; 
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Tituloclienteid = value;
				SetDirty("Tituloclienteid");
			}
		}




		[SoapElement(ElementName="TituloCLienteRazaoSocial")]
		[XmlElement(ElementName="TituloCLienteRazaoSocial")]
		public string gxTpr_Tituloclienterazaosocial
		{
			get {
				return gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Tituloclienterazaosocial; 
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Tituloclienterazaosocial = value;
				SetDirty("Tituloclienterazaosocial");
			}
		}



		[SoapElement(ElementName="TituloValor")]
		[XmlElement(ElementName="TituloValor")]
		public string gxTpr_Titulovalor_double
		{
			get {
				return Convert.ToString(gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulovalor, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulovalor = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Titulovalor
		{
			get {
				return gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulovalor; 
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulovalor = value;
				SetDirty("Titulovalor");
			}
		}



		[SoapElement(ElementName="TituloDesconto")]
		[XmlElement(ElementName="TituloDesconto")]
		public string gxTpr_Titulodesconto_double
		{
			get {
				return Convert.ToString(gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulodesconto, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulodesconto = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Titulodesconto
		{
			get {
				return gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulodesconto; 
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulodesconto = value;
				SetDirty("Titulodesconto");
			}
		}




		[SoapElement(ElementName="TituloDeleted")]
		[XmlElement(ElementName="TituloDeleted")]
		public bool gxTpr_Titulodeleted
		{
			get {
				return gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulodeleted; 
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulodeleted = value;
				SetDirty("Titulodeleted");
			}
		}




		[SoapElement(ElementName="TituloArchived")]
		[XmlElement(ElementName="TituloArchived")]
		public bool gxTpr_Tituloarchived
		{
			get {
				return gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Tituloarchived; 
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Tituloarchived = value;
				SetDirty("Tituloarchived");
			}
		}



		[SoapElement(ElementName="TituloVencimento")]
		[XmlElement(ElementName="TituloVencimento" , IsNullable=true)]
		public string gxTpr_Titulovencimento_Nullable
		{
			get {
				if ( gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulovencimento == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulovencimento).value ;
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulovencimento = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Titulovencimento
		{
			get {
				return gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulovencimento; 
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulovencimento = value;
				SetDirty("Titulovencimento");
			}
		}



		[SoapElement(ElementName="TituloCompetenciaAno")]
		[XmlElement(ElementName="TituloCompetenciaAno")]
		public short gxTpr_Titulocompetenciaano
		{
			get {
				return gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulocompetenciaano; 
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulocompetenciaano = value;
				SetDirty("Titulocompetenciaano");
			}
		}




		[SoapElement(ElementName="TituloCompetenciaMes")]
		[XmlElement(ElementName="TituloCompetenciaMes")]
		public short gxTpr_Titulocompetenciames
		{
			get {
				return gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulocompetenciames; 
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulocompetenciames = value;
				SetDirty("Titulocompetenciames");
			}
		}




		[SoapElement(ElementName="TituloCompetencia_F")]
		[XmlElement(ElementName="TituloCompetencia_F")]
		public string gxTpr_Titulocompetencia_f
		{
			get {
				return gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulocompetencia_f; 
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulocompetencia_f = value;
				SetDirty("Titulocompetencia_f");
			}
		}



		[SoapElement(ElementName="TituloProrrogacao")]
		[XmlElement(ElementName="TituloProrrogacao" , IsNullable=true)]
		public string gxTpr_Tituloprorrogacao_Nullable
		{
			get {
				if ( gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Tituloprorrogacao == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Tituloprorrogacao).value ;
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Tituloprorrogacao = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Tituloprorrogacao
		{
			get {
				return gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Tituloprorrogacao; 
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Tituloprorrogacao = value;
				SetDirty("Tituloprorrogacao");
			}
		}



		[SoapElement(ElementName="TituloCEP")]
		[XmlElement(ElementName="TituloCEP")]
		public string gxTpr_Titulocep
		{
			get {
				return gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulocep; 
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulocep = value;
				SetDirty("Titulocep");
			}
		}




		[SoapElement(ElementName="TituloLogradouro")]
		[XmlElement(ElementName="TituloLogradouro")]
		public string gxTpr_Titulologradouro
		{
			get {
				return gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulologradouro; 
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulologradouro = value;
				SetDirty("Titulologradouro");
			}
		}




		[SoapElement(ElementName="TituloNumeroEndereco")]
		[XmlElement(ElementName="TituloNumeroEndereco")]
		public string gxTpr_Titulonumeroendereco
		{
			get {
				return gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulonumeroendereco; 
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulonumeroendereco = value;
				SetDirty("Titulonumeroendereco");
			}
		}




		[SoapElement(ElementName="TituloComplemento")]
		[XmlElement(ElementName="TituloComplemento")]
		public string gxTpr_Titulocomplemento
		{
			get {
				return gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulocomplemento; 
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulocomplemento = value;
				SetDirty("Titulocomplemento");
			}
		}




		[SoapElement(ElementName="TituloBairro")]
		[XmlElement(ElementName="TituloBairro")]
		public string gxTpr_Titulobairro
		{
			get {
				return gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulobairro; 
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulobairro = value;
				SetDirty("Titulobairro");
			}
		}




		[SoapElement(ElementName="TituloMunicipio")]
		[XmlElement(ElementName="TituloMunicipio")]
		public string gxTpr_Titulomunicipio
		{
			get {
				return gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulomunicipio; 
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulomunicipio = value;
				SetDirty("Titulomunicipio");
			}
		}



		[SoapElement(ElementName="TituloJurosMora")]
		[XmlElement(ElementName="TituloJurosMora")]
		public string gxTpr_Titulojurosmora_double
		{
			get {
				return Convert.ToString(gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulojurosmora, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulojurosmora = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Titulojurosmora
		{
			get {
				return gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulojurosmora; 
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulojurosmora = value;
				SetDirty("Titulojurosmora");
			}
		}




		[SoapElement(ElementName="TituloTipo")]
		[XmlElement(ElementName="TituloTipo")]
		public string gxTpr_Titulotipo
		{
			get {
				return gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulotipo; 
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulotipo = value;
				SetDirty("Titulotipo");
			}
		}




		[SoapElement(ElementName="TituloPropostaId")]
		[XmlElement(ElementName="TituloPropostaId")]
		public int gxTpr_Titulopropostaid
		{
			get {
				return gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulopropostaid; 
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulopropostaid = value;
				SetDirty("Titulopropostaid");
			}
		}




		[SoapElement(ElementName="TituloPropostaDescricao")]
		[XmlElement(ElementName="TituloPropostaDescricao")]
		public string gxTpr_Titulopropostadescricao
		{
			get {
				return gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulopropostadescricao; 
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulopropostadescricao = value;
				SetDirty("Titulopropostadescricao");
			}
		}



		[SoapElement(ElementName="PropostaTaxaAdministrativa")]
		[XmlElement(ElementName="PropostaTaxaAdministrativa")]
		public string gxTpr_Propostataxaadministrativa_double
		{
			get {
				return Convert.ToString(gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Propostataxaadministrativa, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Propostataxaadministrativa = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Propostataxaadministrativa
		{
			get {
				return gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Propostataxaadministrativa; 
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Propostataxaadministrativa = value;
				SetDirty("Propostataxaadministrativa");
			}
		}




		[SoapElement(ElementName="ContaId")]
		[XmlElement(ElementName="ContaId")]
		public int gxTpr_Contaid
		{
			get {
				return gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Contaid; 
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Contaid = value;
				SetDirty("Contaid");
			}
		}



		[SoapElement(ElementName="TituloCriacao")]
		[XmlElement(ElementName="TituloCriacao" , IsNullable=true)]
		public string gxTpr_Titulocriacao_Nullable
		{
			get {
				if ( gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulocriacao == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulocriacao).value ;
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulocriacao = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Titulocriacao
		{
			get {
				return gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulocriacao; 
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulocriacao = value;
				SetDirty("Titulocriacao");
			}
		}



		[SoapElement(ElementName="CategoriaTituloId")]
		[XmlElement(ElementName="CategoriaTituloId")]
		public int gxTpr_Categoriatituloid
		{
			get {
				return gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Categoriatituloid; 
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Categoriatituloid = value;
				SetDirty("Categoriatituloid");
			}
		}



		[SoapElement(ElementName="TituloDataCredito_F")]
		[XmlElement(ElementName="TituloDataCredito_F" , IsNullable=true)]
		public string gxTpr_Titulodatacredito_f_Nullable
		{
			get {
				if ( gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulodatacredito_f == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulodatacredito_f).value ;
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulodatacredito_f = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Titulodatacredito_f
		{
			get {
				return gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulodatacredito_f; 
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulodatacredito_f = value;
				SetDirty("Titulodatacredito_f");
			}
		}


		[SoapElement(ElementName="TituloTotalMovimento_F")]
		[XmlElement(ElementName="TituloTotalMovimento_F")]
		public string gxTpr_Titulototalmovimento_f_double
		{
			get {
				return Convert.ToString(gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulototalmovimento_f, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulototalmovimento_f = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Titulototalmovimento_f
		{
			get {
				return gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulototalmovimento_f; 
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulototalmovimento_f = value;
				SetDirty("Titulototalmovimento_f");
			}
		}



		[SoapElement(ElementName="TituloTotalMultaJuros_F")]
		[XmlElement(ElementName="TituloTotalMultaJuros_F")]
		public string gxTpr_Titulototalmultajuros_f_double
		{
			get {
				return Convert.ToString(gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulototalmultajuros_f, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulototalmultajuros_f = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Titulototalmultajuros_f
		{
			get {
				return gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulototalmultajuros_f; 
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulototalmultajuros_f = value;
				SetDirty("Titulototalmultajuros_f");
			}
		}



		[SoapElement(ElementName="TituloSaldo_F")]
		[XmlElement(ElementName="TituloSaldo_F")]
		public string gxTpr_Titulosaldo_f_double
		{
			get {
				return Convert.ToString(gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulosaldo_f, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulosaldo_f = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Titulosaldo_f
		{
			get {
				return gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulosaldo_f; 
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulosaldo_f = value;
				SetDirty("Titulosaldo_f");
			}
		}




		[SoapElement(ElementName="TituloStatus_F")]
		[XmlElement(ElementName="TituloStatus_F")]
		public string gxTpr_Titulostatus_f
		{
			get {
				return gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulostatus_f; 
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulostatus_f = value;
				SetDirty("Titulostatus_f");
			}
		}



		[SoapElement(ElementName="TituloSaldoDebito_F")]
		[XmlElement(ElementName="TituloSaldoDebito_F")]
		public string gxTpr_Titulosaldodebito_f_double
		{
			get {
				return Convert.ToString(gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulosaldodebito_f, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulosaldodebito_f = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Titulosaldodebito_f
		{
			get {
				return gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulosaldodebito_f; 
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulosaldodebito_f = value;
				SetDirty("Titulosaldodebito_f");
			}
		}



		[SoapElement(ElementName="TituloSaldoCredito_F")]
		[XmlElement(ElementName="TituloSaldoCredito_F")]
		public string gxTpr_Titulosaldocredito_f_double
		{
			get {
				return Convert.ToString(gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulosaldocredito_f, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulosaldocredito_f = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Titulosaldocredito_f
		{
			get {
				return gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulosaldocredito_f; 
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulosaldocredito_f = value;
				SetDirty("Titulosaldocredito_f");
			}
		}



		[SoapElement(ElementName="TituloTotalMovimentoDebito_F")]
		[XmlElement(ElementName="TituloTotalMovimentoDebito_F")]
		public string gxTpr_Titulototalmovimentodebito_f_double
		{
			get {
				return Convert.ToString(gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulototalmovimentodebito_f, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulototalmovimentodebito_f = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Titulototalmovimentodebito_f
		{
			get {
				return gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulototalmovimentodebito_f; 
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulototalmovimentodebito_f = value;
				SetDirty("Titulototalmovimentodebito_f");
			}
		}



		[SoapElement(ElementName="TituloTotalMovimentoCredito_F")]
		[XmlElement(ElementName="TituloTotalMovimentoCredito_F")]
		public string gxTpr_Titulototalmovimentocredito_f_double
		{
			get {
				return Convert.ToString(gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulototalmovimentocredito_f, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulototalmovimentocredito_f = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Titulototalmovimentocredito_f
		{
			get {
				return gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulototalmovimentocredito_f; 
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulototalmovimentocredito_f = value;
				SetDirty("Titulototalmovimentocredito_f");
			}
		}



		[SoapElement(ElementName="TituloTotalMultaJurosDebito_F")]
		[XmlElement(ElementName="TituloTotalMultaJurosDebito_F")]
		public string gxTpr_Titulototalmultajurosdebito_f_double
		{
			get {
				return Convert.ToString(gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulototalmultajurosdebito_f, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulototalmultajurosdebito_f = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Titulototalmultajurosdebito_f
		{
			get {
				return gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulototalmultajurosdebito_f; 
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulototalmultajurosdebito_f = value;
				SetDirty("Titulototalmultajurosdebito_f");
			}
		}



		[SoapElement(ElementName="TituloTotalMultaJurosCredito_F")]
		[XmlElement(ElementName="TituloTotalMultaJurosCredito_F")]
		public string gxTpr_Titulototalmultajuroscredito_f_double
		{
			get {
				return Convert.ToString(gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulototalmultajuroscredito_f, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulototalmultajuroscredito_f = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Titulototalmultajuroscredito_f
		{
			get {
				return gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulototalmultajuroscredito_f; 
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulototalmultajuroscredito_f = value;
				SetDirty("Titulototalmultajuroscredito_f");
			}
		}




		[SoapElement(ElementName="TituloPropostaTipo")]
		[XmlElement(ElementName="TituloPropostaTipo")]
		public string gxTpr_Titulopropostatipo
		{
			get {
				return gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulopropostatipo; 
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulopropostatipo = value;
				SetDirty("Titulopropostatipo");
			}
		}




		[SoapElement(ElementName="NotaFiscalParcelamentoID")]
		[XmlElement(ElementName="NotaFiscalParcelamentoID")]
		public Guid gxTpr_Notafiscalparcelamentoid
		{
			get {
				return gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Notafiscalparcelamentoid; 
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Notafiscalparcelamentoid = value;
				SetDirty("Notafiscalparcelamentoid");
			}
		}




		[SoapElement(ElementName="NotaFiscalNumero")]
		[XmlElement(ElementName="NotaFiscalNumero")]
		public string gxTpr_Notafiscalnumero
		{
			get {
				return gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Notafiscalnumero; 
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Notafiscalnumero = value;
				SetDirty("Notafiscalnumero");
			}
		}




		[SoapElement(ElementName="ContaBancariaId")]
		[XmlElement(ElementName="ContaBancariaId")]
		public int gxTpr_Contabancariaid
		{
			get {
				return gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Contabancariaid; 
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Contabancariaid = value;
				SetDirty("Contabancariaid");
			}
		}




		[SoapElement(ElementName="AgenciaBancoNome")]
		[XmlElement(ElementName="AgenciaBancoNome")]
		public string gxTpr_Agenciabanconome
		{
			get {
				return gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Agenciabanconome; 
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Agenciabanconome = value;
				SetDirty("Agenciabanconome");
			}
		}




		[SoapElement(ElementName="ContaBancariaCarteira")]
		[XmlElement(ElementName="ContaBancariaCarteira")]
		public long gxTpr_Contabancariacarteira
		{
			get {
				return gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Contabancariacarteira; 
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Contabancariacarteira = value;
				SetDirty("Contabancariacarteira");
			}
		}




		[SoapElement(ElementName="ContaBancariaNumero")]
		[XmlElement(ElementName="ContaBancariaNumero")]
		public long gxTpr_Contabancarianumero
		{
			get {
				return gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Contabancarianumero; 
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Contabancarianumero = value;
				SetDirty("Contabancarianumero");
			}
		}




		[SoapElement(ElementName="AgenciaNumero")]
		[XmlElement(ElementName="AgenciaNumero")]
		public int gxTpr_Agencianumero
		{
			get {
				return gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Agencianumero; 
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Agencianumero = value;
				SetDirty("Agencianumero");
			}
		}




		[SoapElement(ElementName="TitulosEmCarteiraDeCobranca_F")]
		[XmlElement(ElementName="TitulosEmCarteiraDeCobranca_F")]
		public bool gxTpr_Titulosemcarteiradecobranca_f
		{
			get {
				return gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulosemcarteiradecobranca_f; 
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulosemcarteiradecobranca_f = value;
				SetDirty("Titulosemcarteiradecobranca_f");
			}
		}




		[SoapElement(ElementName="TitulosCarteiraDeCobranca")]
		[XmlElement(ElementName="TitulosCarteiraDeCobranca")]
		public string gxTpr_Tituloscarteiradecobranca
		{
			get {
				return gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Tituloscarteiradecobranca; 
			}
			set {
				gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Tituloscarteiradecobranca = value;
				SetDirty("Tituloscarteiradecobranca");
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
			gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Tituloclienterazaosocial = "";







			gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulocompetencia_f = "";

			gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulocep = "";
			gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulologradouro = "";
			gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulonumeroendereco = "";
			gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulocomplemento = "";
			gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulobairro = "";
			gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulomunicipio = "";

			gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulotipo = "";

			gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulopropostadescricao = "";


			gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulocriacao = (DateTime)(DateTime.MinValue);





			gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulostatus_f = "";






			gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulopropostatipo = "";

			gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Notafiscalnumero = "";

			gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Agenciabanconome = "";




			gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Tituloscarteiradecobranca = "";
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

		protected int gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Tituloid;
		 

		protected int gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Tituloclienteid;
		 

		protected string gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Tituloclienterazaosocial;
		 

		protected decimal gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulovalor;
		 

		protected decimal gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulodesconto;
		 

		protected bool gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulodeleted;
		 

		protected bool gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Tituloarchived;
		 

		protected DateTime gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulovencimento;
		 

		protected short gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulocompetenciaano;
		 

		protected short gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulocompetenciames;
		 

		protected string gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulocompetencia_f;
		 

		protected DateTime gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Tituloprorrogacao;
		 

		protected string gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulocep;
		 

		protected string gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulologradouro;
		 

		protected string gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulonumeroendereco;
		 

		protected string gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulocomplemento;
		 

		protected string gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulobairro;
		 

		protected string gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulomunicipio;
		 

		protected decimal gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulojurosmora;
		 

		protected string gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulotipo;
		 

		protected int gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulopropostaid;
		 

		protected string gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulopropostadescricao;
		 

		protected decimal gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Propostataxaadministrativa;
		 

		protected int gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Contaid;
		 

		protected DateTime gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulocriacao;
		 

		protected int gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Categoriatituloid;
		 

		protected DateTime gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulodatacredito_f;
		 

		protected decimal gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulototalmovimento_f;
		 

		protected decimal gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulototalmultajuros_f;
		 

		protected decimal gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulosaldo_f;
		 

		protected string gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulostatus_f;
		 

		protected decimal gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulosaldodebito_f;
		 

		protected decimal gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulosaldocredito_f;
		 

		protected decimal gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulototalmovimentodebito_f;
		 

		protected decimal gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulototalmovimentocredito_f;
		 

		protected decimal gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulototalmultajurosdebito_f;
		 

		protected decimal gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulototalmultajuroscredito_f;
		 

		protected string gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulopropostatipo;
		 

		protected Guid gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Notafiscalparcelamentoid;
		 

		protected string gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Notafiscalnumero;
		 

		protected int gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Contabancariaid;
		 

		protected string gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Agenciabanconome;
		 

		protected long gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Contabancariacarteira;
		 

		protected long gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Contabancarianumero;
		 

		protected int gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Agencianumero;
		 

		protected bool gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Titulosemcarteiradecobranca_f;
		 

		protected string gxTv_SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_Tituloscarteiradecobranca;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SelecionarTitulosSDTItem", Namespace="Factory21")]
	public class SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_RESTInterface : GxGenericCollectionItem<SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_RESTInterface( ) : base()
		{	
		}

		public SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem_RESTInterface( SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem psdt ) : base(psdt)
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

		[JsonPropertyName("TituloValor")]
		[JsonPropertyOrder(3)]
		[DataMember(Name="TituloValor", Order=3)]
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
		[JsonPropertyOrder(4)]
		[DataMember(Name="TituloDesconto", Order=4)]
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
		[JsonPropertyOrder(5)]
		[JsonConverter(typeof(BoolStringJsonConverter))]
		[DataMember(Name="TituloDeleted", Order=5)]
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
		[JsonPropertyOrder(6)]
		[JsonConverter(typeof(BoolStringJsonConverter))]
		[DataMember(Name="TituloArchived", Order=6)]
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
		[JsonPropertyOrder(7)]
		[DataMember(Name="TituloVencimento", Order=7)]
		public  string gxTpr_Titulovencimento
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Titulovencimento);

			}
			set { 
				sdt.gxTpr_Titulovencimento = DateTimeUtil.CToD2(value);
			}
		}

		[JsonPropertyName("TituloCompetenciaAno")]
		[JsonPropertyOrder(8)]
		[DataMember(Name="TituloCompetenciaAno", Order=8)]
		public short gxTpr_Titulocompetenciaano
		{
			get { 
				return sdt.gxTpr_Titulocompetenciaano;

			}
			set { 
				sdt.gxTpr_Titulocompetenciaano = value;
			}
		}

		[JsonPropertyName("TituloCompetenciaMes")]
		[JsonPropertyOrder(9)]
		[DataMember(Name="TituloCompetenciaMes", Order=9)]
		public short gxTpr_Titulocompetenciames
		{
			get { 
				return sdt.gxTpr_Titulocompetenciames;

			}
			set { 
				sdt.gxTpr_Titulocompetenciames = value;
			}
		}

		[JsonPropertyName("TituloCompetencia_F")]
		[JsonPropertyOrder(10)]
		[DataMember(Name="TituloCompetencia_F", Order=10)]
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
		[JsonPropertyOrder(11)]
		[DataMember(Name="TituloProrrogacao", Order=11)]
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
		[JsonPropertyOrder(12)]
		[DataMember(Name="TituloCEP", Order=12)]
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
		[JsonPropertyOrder(13)]
		[DataMember(Name="TituloLogradouro", Order=13)]
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
		[JsonPropertyOrder(14)]
		[DataMember(Name="TituloNumeroEndereco", Order=14)]
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
		[JsonPropertyOrder(15)]
		[DataMember(Name="TituloComplemento", Order=15)]
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
		[JsonPropertyOrder(16)]
		[DataMember(Name="TituloBairro", Order=16)]
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
		[JsonPropertyOrder(17)]
		[DataMember(Name="TituloMunicipio", Order=17)]
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
		[JsonPropertyOrder(18)]
		[DataMember(Name="TituloJurosMora", Order=18)]
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
		[JsonPropertyOrder(19)]
		[DataMember(Name="TituloTipo", Order=19)]
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
		[JsonPropertyOrder(20)]
		[DataMember(Name="TituloPropostaId", Order=20)]
		public  string gxTpr_Titulopropostaid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Titulopropostaid, 9, 0));

			}
			set { 
				sdt.gxTpr_Titulopropostaid = (int) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("TituloPropostaDescricao")]
		[JsonPropertyOrder(21)]
		[DataMember(Name="TituloPropostaDescricao", Order=21)]
		public  string gxTpr_Titulopropostadescricao
		{
			get { 
				return sdt.gxTpr_Titulopropostadescricao;

			}
			set { 
				 sdt.gxTpr_Titulopropostadescricao = value;
			}
		}

		[JsonPropertyName("PropostaTaxaAdministrativa")]
		[JsonPropertyOrder(22)]
		[DataMember(Name="PropostaTaxaAdministrativa", Order=22)]
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
		[JsonPropertyOrder(23)]
		[DataMember(Name="ContaId", Order=23)]
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
		[JsonPropertyOrder(24)]
		[DataMember(Name="TituloCriacao", Order=24)]
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
		[JsonPropertyOrder(25)]
		[DataMember(Name="CategoriaTituloId", Order=25)]
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
		[JsonPropertyOrder(26)]
		[DataMember(Name="TituloDataCredito_F", Order=26)]
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
		[JsonPropertyOrder(27)]
		[DataMember(Name="TituloTotalMovimento_F", Order=27)]
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
		[JsonPropertyOrder(28)]
		[DataMember(Name="TituloTotalMultaJuros_F", Order=28)]
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
		[JsonPropertyOrder(29)]
		[DataMember(Name="TituloSaldo_F", Order=29)]
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
		[JsonPropertyOrder(30)]
		[DataMember(Name="TituloStatus_F", Order=30)]
		public  string gxTpr_Titulostatus_f
		{
			get { 
				return sdt.gxTpr_Titulostatus_f;

			}
			set { 
				 sdt.gxTpr_Titulostatus_f = value;
			}
		}

		[JsonPropertyName("TituloSaldoDebito_F")]
		[JsonPropertyOrder(31)]
		[DataMember(Name="TituloSaldoDebito_F", Order=31)]
		public  string gxTpr_Titulosaldodebito_f
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Titulosaldodebito_f, 18, 2));

			}
			set { 
				sdt.gxTpr_Titulosaldodebito_f =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("TituloSaldoCredito_F")]
		[JsonPropertyOrder(32)]
		[DataMember(Name="TituloSaldoCredito_F", Order=32)]
		public  string gxTpr_Titulosaldocredito_f
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Titulosaldocredito_f, 18, 2));

			}
			set { 
				sdt.gxTpr_Titulosaldocredito_f =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("TituloTotalMovimentoDebito_F")]
		[JsonPropertyOrder(33)]
		[DataMember(Name="TituloTotalMovimentoDebito_F", Order=33)]
		public  string gxTpr_Titulototalmovimentodebito_f
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Titulototalmovimentodebito_f, 18, 2));

			}
			set { 
				sdt.gxTpr_Titulototalmovimentodebito_f =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("TituloTotalMovimentoCredito_F")]
		[JsonPropertyOrder(34)]
		[DataMember(Name="TituloTotalMovimentoCredito_F", Order=34)]
		public  string gxTpr_Titulototalmovimentocredito_f
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Titulototalmovimentocredito_f, 18, 2));

			}
			set { 
				sdt.gxTpr_Titulototalmovimentocredito_f =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("TituloTotalMultaJurosDebito_F")]
		[JsonPropertyOrder(35)]
		[DataMember(Name="TituloTotalMultaJurosDebito_F", Order=35)]
		public  string gxTpr_Titulototalmultajurosdebito_f
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Titulototalmultajurosdebito_f, 18, 2));

			}
			set { 
				sdt.gxTpr_Titulototalmultajurosdebito_f =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("TituloTotalMultaJurosCredito_F")]
		[JsonPropertyOrder(36)]
		[DataMember(Name="TituloTotalMultaJurosCredito_F", Order=36)]
		public  string gxTpr_Titulototalmultajuroscredito_f
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Titulototalmultajuroscredito_f, 18, 2));

			}
			set { 
				sdt.gxTpr_Titulototalmultajuroscredito_f =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("TituloPropostaTipo")]
		[JsonPropertyOrder(37)]
		[DataMember(Name="TituloPropostaTipo", Order=37)]
		public  string gxTpr_Titulopropostatipo
		{
			get { 
				return sdt.gxTpr_Titulopropostatipo;

			}
			set { 
				 sdt.gxTpr_Titulopropostatipo = value;
			}
		}

		[JsonPropertyName("NotaFiscalParcelamentoID")]
		[JsonPropertyOrder(38)]
		[DataMember(Name="NotaFiscalParcelamentoID", Order=38)]
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
		[JsonPropertyOrder(39)]
		[DataMember(Name="NotaFiscalNumero", Order=39)]
		public  string gxTpr_Notafiscalnumero
		{
			get { 
				return sdt.gxTpr_Notafiscalnumero;

			}
			set { 
				 sdt.gxTpr_Notafiscalnumero = value;
			}
		}

		[JsonPropertyName("ContaBancariaId")]
		[JsonPropertyOrder(40)]
		[DataMember(Name="ContaBancariaId", Order=40)]
		public  string gxTpr_Contabancariaid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Contabancariaid, 9, 0));

			}
			set { 
				sdt.gxTpr_Contabancariaid = (int) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("AgenciaBancoNome")]
		[JsonPropertyOrder(41)]
		[DataMember(Name="AgenciaBancoNome", Order=41)]
		public  string gxTpr_Agenciabanconome
		{
			get { 
				return sdt.gxTpr_Agenciabanconome;

			}
			set { 
				 sdt.gxTpr_Agenciabanconome = value;
			}
		}

		[JsonPropertyName("ContaBancariaCarteira")]
		[JsonPropertyOrder(42)]
		[DataMember(Name="ContaBancariaCarteira", Order=42)]
		public  string gxTpr_Contabancariacarteira
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Contabancariacarteira, 10, 0));

			}
			set { 
				sdt.gxTpr_Contabancariacarteira = (long) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("ContaBancariaNumero")]
		[JsonPropertyOrder(43)]
		[DataMember(Name="ContaBancariaNumero", Order=43)]
		public  string gxTpr_Contabancarianumero
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Contabancarianumero, 18, 0));

			}
			set { 
				sdt.gxTpr_Contabancarianumero = (long) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("AgenciaNumero")]
		[JsonPropertyOrder(44)]
		[DataMember(Name="AgenciaNumero", Order=44)]
		public  string gxTpr_Agencianumero
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Agencianumero, 9, 0));

			}
			set { 
				sdt.gxTpr_Agencianumero = (int) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("TitulosEmCarteiraDeCobranca_F")]
		[JsonPropertyOrder(45)]
		[JsonConverter(typeof(BoolStringJsonConverter))]
		[DataMember(Name="TitulosEmCarteiraDeCobranca_F", Order=45)]
		public bool gxTpr_Titulosemcarteiradecobranca_f
		{
			get { 
				return sdt.gxTpr_Titulosemcarteiradecobranca_f;

			}
			set { 
				sdt.gxTpr_Titulosemcarteiradecobranca_f = value;
			}
		}

		[JsonPropertyName("TitulosCarteiraDeCobranca")]
		[JsonPropertyOrder(46)]
		[DataMember(Name="TitulosCarteiraDeCobranca", Order=46)]
		public  string gxTpr_Tituloscarteiradecobranca
		{
			get { 
				return sdt.gxTpr_Tituloscarteiradecobranca;

			}
			set { 
				 sdt.gxTpr_Tituloscarteiradecobranca = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem sdt
		{
			get { 
				return (SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem)Sdt;
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
				sdt = new SdtSelecionarTitulosSDT_SelecionarTitulosSDTItem() ;
			}
		}
	}
	#endregion
}