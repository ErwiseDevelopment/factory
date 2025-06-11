/*
				   File: type_SdtSdTitulo
			Description: SdTitulo
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
	[XmlRoot(ElementName="SdTitulo")]
	[XmlType(TypeName="SdTitulo" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdTitulo : GxUserType
	{
		public SdtSdTitulo( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdTitulo_Titulocep = "";

			gxTv_SdtSdTitulo_Titulologradouro = "";

			gxTv_SdtSdTitulo_Titulonumeroendereco = "";

			gxTv_SdtSdTitulo_Titulocomplemento = "";

			gxTv_SdtSdTitulo_Titulobairro = "";

			gxTv_SdtSdTitulo_Titulomunicipio = "";

			gxTv_SdtSdTitulo_Titulotipo = "";

			gxTv_SdtSdTitulo_Titulopropostatipo = "";


		}

		public SdtSdTitulo(IGxContext context)
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
			AddObjectProperty("ClienteId", gxTpr_Clienteid, false);


			AddObjectProperty("TituloValor", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Titulovalor, 18, 2)), false);


			AddObjectProperty("TituloDesconto", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Titulodesconto, 18, 2)), false);


			AddObjectProperty("TituloDeleted", gxTpr_Titulodeleted, false);


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


			AddObjectProperty("TituloTipo", gxTpr_Titulotipo, false);


			AddObjectProperty("TituloCompetenciaAno", gxTpr_Titulocompetenciaano, false);


			AddObjectProperty("TituloJurosMora", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Titulojurosmora, 16, 4)), false);


			AddObjectProperty("TituloCompetenciaMes", gxTpr_Titulocompetenciames, false);


			AddObjectProperty("TituloId", gxTpr_Tituloid, false);


			AddObjectProperty("PropostaId", gxTpr_Propostaid, false);


			AddObjectProperty("ContaId", gxTpr_Contaid, false);


			AddObjectProperty("CategoriaTituloId", gxTpr_Categoriatituloid, false);


			AddObjectProperty("TituloPropostaTipo", gxTpr_Titulopropostatipo, false);


			AddObjectProperty("NotaFiscalParcelamentoId", gxTpr_Notafiscalparcelamentoid, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ClienteId")]
		[XmlElement(ElementName="ClienteId")]
		public int gxTpr_Clienteid
		{
			get {
				return gxTv_SdtSdTitulo_Clienteid; 
			}
			set {
				gxTv_SdtSdTitulo_Clienteid = value;
				SetDirty("Clienteid");
			}
		}



		[SoapElement(ElementName="TituloValor")]
		[XmlElement(ElementName="TituloValor")]
		public string gxTpr_Titulovalor_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdTitulo_Titulovalor, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdTitulo_Titulovalor = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Titulovalor
		{
			get {
				return gxTv_SdtSdTitulo_Titulovalor; 
			}
			set {
				gxTv_SdtSdTitulo_Titulovalor = value;
				SetDirty("Titulovalor");
			}
		}



		[SoapElement(ElementName="TituloDesconto")]
		[XmlElement(ElementName="TituloDesconto")]
		public string gxTpr_Titulodesconto_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdTitulo_Titulodesconto, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdTitulo_Titulodesconto = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Titulodesconto
		{
			get {
				return gxTv_SdtSdTitulo_Titulodesconto; 
			}
			set {
				gxTv_SdtSdTitulo_Titulodesconto = value;
				SetDirty("Titulodesconto");
			}
		}




		[SoapElement(ElementName="TituloDeleted")]
		[XmlElement(ElementName="TituloDeleted")]
		public bool gxTpr_Titulodeleted
		{
			get {
				return gxTv_SdtSdTitulo_Titulodeleted; 
			}
			set {
				gxTv_SdtSdTitulo_Titulodeleted = value;
				SetDirty("Titulodeleted");
			}
		}



		[SoapElement(ElementName="TituloVencimento")]
		[XmlElement(ElementName="TituloVencimento" , IsNullable=true)]
		public string gxTpr_Titulovencimento_Nullable
		{
			get {
				if ( gxTv_SdtSdTitulo_Titulovencimento == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSdTitulo_Titulovencimento).value ;
			}
			set {
				gxTv_SdtSdTitulo_Titulovencimento = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Titulovencimento
		{
			get {
				return gxTv_SdtSdTitulo_Titulovencimento; 
			}
			set {
				gxTv_SdtSdTitulo_Titulovencimento = value;
				SetDirty("Titulovencimento");
			}
		}


		[SoapElement(ElementName="TituloProrrogacao")]
		[XmlElement(ElementName="TituloProrrogacao" , IsNullable=true)]
		public string gxTpr_Tituloprorrogacao_Nullable
		{
			get {
				if ( gxTv_SdtSdTitulo_Tituloprorrogacao == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSdTitulo_Tituloprorrogacao).value ;
			}
			set {
				gxTv_SdtSdTitulo_Tituloprorrogacao = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Tituloprorrogacao
		{
			get {
				return gxTv_SdtSdTitulo_Tituloprorrogacao; 
			}
			set {
				gxTv_SdtSdTitulo_Tituloprorrogacao = value;
				SetDirty("Tituloprorrogacao");
			}
		}



		[SoapElement(ElementName="TituloCEP")]
		[XmlElement(ElementName="TituloCEP")]
		public string gxTpr_Titulocep
		{
			get {
				return gxTv_SdtSdTitulo_Titulocep; 
			}
			set {
				gxTv_SdtSdTitulo_Titulocep = value;
				SetDirty("Titulocep");
			}
		}




		[SoapElement(ElementName="TituloLogradouro")]
		[XmlElement(ElementName="TituloLogradouro")]
		public string gxTpr_Titulologradouro
		{
			get {
				return gxTv_SdtSdTitulo_Titulologradouro; 
			}
			set {
				gxTv_SdtSdTitulo_Titulologradouro = value;
				SetDirty("Titulologradouro");
			}
		}




		[SoapElement(ElementName="TituloNumeroEndereco")]
		[XmlElement(ElementName="TituloNumeroEndereco")]
		public string gxTpr_Titulonumeroendereco
		{
			get {
				return gxTv_SdtSdTitulo_Titulonumeroendereco; 
			}
			set {
				gxTv_SdtSdTitulo_Titulonumeroendereco = value;
				SetDirty("Titulonumeroendereco");
			}
		}




		[SoapElement(ElementName="TituloComplemento")]
		[XmlElement(ElementName="TituloComplemento")]
		public string gxTpr_Titulocomplemento
		{
			get {
				return gxTv_SdtSdTitulo_Titulocomplemento; 
			}
			set {
				gxTv_SdtSdTitulo_Titulocomplemento = value;
				SetDirty("Titulocomplemento");
			}
		}




		[SoapElement(ElementName="TituloBairro")]
		[XmlElement(ElementName="TituloBairro")]
		public string gxTpr_Titulobairro
		{
			get {
				return gxTv_SdtSdTitulo_Titulobairro; 
			}
			set {
				gxTv_SdtSdTitulo_Titulobairro = value;
				SetDirty("Titulobairro");
			}
		}




		[SoapElement(ElementName="TituloMunicipio")]
		[XmlElement(ElementName="TituloMunicipio")]
		public string gxTpr_Titulomunicipio
		{
			get {
				return gxTv_SdtSdTitulo_Titulomunicipio; 
			}
			set {
				gxTv_SdtSdTitulo_Titulomunicipio = value;
				SetDirty("Titulomunicipio");
			}
		}




		[SoapElement(ElementName="TituloTipo")]
		[XmlElement(ElementName="TituloTipo")]
		public string gxTpr_Titulotipo
		{
			get {
				return gxTv_SdtSdTitulo_Titulotipo; 
			}
			set {
				gxTv_SdtSdTitulo_Titulotipo = value;
				SetDirty("Titulotipo");
			}
		}




		[SoapElement(ElementName="TituloCompetenciaAno")]
		[XmlElement(ElementName="TituloCompetenciaAno")]
		public short gxTpr_Titulocompetenciaano
		{
			get {
				return gxTv_SdtSdTitulo_Titulocompetenciaano; 
			}
			set {
				gxTv_SdtSdTitulo_Titulocompetenciaano = value;
				SetDirty("Titulocompetenciaano");
			}
		}



		[SoapElement(ElementName="TituloJurosMora")]
		[XmlElement(ElementName="TituloJurosMora")]
		public string gxTpr_Titulojurosmora_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdTitulo_Titulojurosmora, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdTitulo_Titulojurosmora = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Titulojurosmora
		{
			get {
				return gxTv_SdtSdTitulo_Titulojurosmora; 
			}
			set {
				gxTv_SdtSdTitulo_Titulojurosmora = value;
				SetDirty("Titulojurosmora");
			}
		}




		[SoapElement(ElementName="TituloCompetenciaMes")]
		[XmlElement(ElementName="TituloCompetenciaMes")]
		public short gxTpr_Titulocompetenciames
		{
			get {
				return gxTv_SdtSdTitulo_Titulocompetenciames; 
			}
			set {
				gxTv_SdtSdTitulo_Titulocompetenciames = value;
				SetDirty("Titulocompetenciames");
			}
		}




		[SoapElement(ElementName="TituloId")]
		[XmlElement(ElementName="TituloId")]
		public int gxTpr_Tituloid
		{
			get {
				return gxTv_SdtSdTitulo_Tituloid; 
			}
			set {
				gxTv_SdtSdTitulo_Tituloid = value;
				SetDirty("Tituloid");
			}
		}




		[SoapElement(ElementName="PropostaId")]
		[XmlElement(ElementName="PropostaId")]
		public int gxTpr_Propostaid
		{
			get {
				return gxTv_SdtSdTitulo_Propostaid; 
			}
			set {
				gxTv_SdtSdTitulo_Propostaid = value;
				SetDirty("Propostaid");
			}
		}




		[SoapElement(ElementName="ContaId")]
		[XmlElement(ElementName="ContaId")]
		public int gxTpr_Contaid
		{
			get {
				return gxTv_SdtSdTitulo_Contaid; 
			}
			set {
				gxTv_SdtSdTitulo_Contaid = value;
				SetDirty("Contaid");
			}
		}




		[SoapElement(ElementName="CategoriaTituloId")]
		[XmlElement(ElementName="CategoriaTituloId")]
		public int gxTpr_Categoriatituloid
		{
			get {
				return gxTv_SdtSdTitulo_Categoriatituloid; 
			}
			set {
				gxTv_SdtSdTitulo_Categoriatituloid = value;
				SetDirty("Categoriatituloid");
			}
		}




		[SoapElement(ElementName="TituloPropostaTipo")]
		[XmlElement(ElementName="TituloPropostaTipo")]
		public string gxTpr_Titulopropostatipo
		{
			get {
				return gxTv_SdtSdTitulo_Titulopropostatipo; 
			}
			set {
				gxTv_SdtSdTitulo_Titulopropostatipo = value;
				SetDirty("Titulopropostatipo");
			}
		}




		[SoapElement(ElementName="NotaFiscalParcelamentoId")]
		[XmlElement(ElementName="NotaFiscalParcelamentoId")]
		public Guid gxTpr_Notafiscalparcelamentoid
		{
			get {
				return gxTv_SdtSdTitulo_Notafiscalparcelamentoid; 
			}
			set {
				gxTv_SdtSdTitulo_Notafiscalparcelamentoid = value;
				SetDirty("Notafiscalparcelamentoid");
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
			gxTv_SdtSdTitulo_Titulocep = "";
			gxTv_SdtSdTitulo_Titulologradouro = "";
			gxTv_SdtSdTitulo_Titulonumeroendereco = "";
			gxTv_SdtSdTitulo_Titulocomplemento = "";
			gxTv_SdtSdTitulo_Titulobairro = "";
			gxTv_SdtSdTitulo_Titulomunicipio = "";
			gxTv_SdtSdTitulo_Titulotipo = "";







			gxTv_SdtSdTitulo_Titulopropostatipo = "";

			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected int gxTv_SdtSdTitulo_Clienteid;
		 

		protected decimal gxTv_SdtSdTitulo_Titulovalor;
		 

		protected decimal gxTv_SdtSdTitulo_Titulodesconto;
		 

		protected bool gxTv_SdtSdTitulo_Titulodeleted;
		 

		protected DateTime gxTv_SdtSdTitulo_Titulovencimento;
		 

		protected DateTime gxTv_SdtSdTitulo_Tituloprorrogacao;
		 

		protected string gxTv_SdtSdTitulo_Titulocep;
		 

		protected string gxTv_SdtSdTitulo_Titulologradouro;
		 

		protected string gxTv_SdtSdTitulo_Titulonumeroendereco;
		 

		protected string gxTv_SdtSdTitulo_Titulocomplemento;
		 

		protected string gxTv_SdtSdTitulo_Titulobairro;
		 

		protected string gxTv_SdtSdTitulo_Titulomunicipio;
		 

		protected string gxTv_SdtSdTitulo_Titulotipo;
		 

		protected short gxTv_SdtSdTitulo_Titulocompetenciaano;
		 

		protected decimal gxTv_SdtSdTitulo_Titulojurosmora;
		 

		protected short gxTv_SdtSdTitulo_Titulocompetenciames;
		 

		protected int gxTv_SdtSdTitulo_Tituloid;
		 

		protected int gxTv_SdtSdTitulo_Propostaid;
		 

		protected int gxTv_SdtSdTitulo_Contaid;
		 

		protected int gxTv_SdtSdTitulo_Categoriatituloid;
		 

		protected string gxTv_SdtSdTitulo_Titulopropostatipo;
		 

		protected Guid gxTv_SdtSdTitulo_Notafiscalparcelamentoid;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdTitulo", Namespace="Factory21")]
	public class SdtSdTitulo_RESTInterface : GxGenericCollectionItem<SdtSdTitulo>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdTitulo_RESTInterface( ) : base()
		{	
		}

		public SdtSdTitulo_RESTInterface( SdtSdTitulo psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("ClienteId")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="ClienteId", Order=0)]
		public  string gxTpr_Clienteid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Clienteid, 9, 0));

			}
			set { 
				sdt.gxTpr_Clienteid = (int) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("TituloValor")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="TituloValor", Order=1)]
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
		[JsonPropertyOrder(2)]
		[DataMember(Name="TituloDesconto", Order=2)]
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
		[JsonPropertyOrder(3)]
		[JsonConverter(typeof(BoolStringJsonConverter))]
		[DataMember(Name="TituloDeleted", Order=3)]
		public bool gxTpr_Titulodeleted
		{
			get { 
				return sdt.gxTpr_Titulodeleted;

			}
			set { 
				sdt.gxTpr_Titulodeleted = value;
			}
		}

		[JsonPropertyName("TituloVencimento")]
		[JsonPropertyOrder(4)]
		[DataMember(Name="TituloVencimento", Order=4)]
		public  string gxTpr_Titulovencimento
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Titulovencimento);

			}
			set { 
				sdt.gxTpr_Titulovencimento = DateTimeUtil.CToD2(value);
			}
		}

		[JsonPropertyName("TituloProrrogacao")]
		[JsonPropertyOrder(5)]
		[DataMember(Name="TituloProrrogacao", Order=5)]
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
		[JsonPropertyOrder(6)]
		[DataMember(Name="TituloCEP", Order=6)]
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
		[JsonPropertyOrder(7)]
		[DataMember(Name="TituloLogradouro", Order=7)]
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
		[JsonPropertyOrder(8)]
		[DataMember(Name="TituloNumeroEndereco", Order=8)]
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
		[JsonPropertyOrder(9)]
		[DataMember(Name="TituloComplemento", Order=9)]
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
		[JsonPropertyOrder(10)]
		[DataMember(Name="TituloBairro", Order=10)]
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
		[JsonPropertyOrder(11)]
		[DataMember(Name="TituloMunicipio", Order=11)]
		public  string gxTpr_Titulomunicipio
		{
			get { 
				return sdt.gxTpr_Titulomunicipio;

			}
			set { 
				 sdt.gxTpr_Titulomunicipio = value;
			}
		}

		[JsonPropertyName("TituloTipo")]
		[JsonPropertyOrder(12)]
		[DataMember(Name="TituloTipo", Order=12)]
		public  string gxTpr_Titulotipo
		{
			get { 
				return sdt.gxTpr_Titulotipo;

			}
			set { 
				 sdt.gxTpr_Titulotipo = value;
			}
		}

		[JsonPropertyName("TituloCompetenciaAno")]
		[JsonPropertyOrder(13)]
		[DataMember(Name="TituloCompetenciaAno", Order=13)]
		public short gxTpr_Titulocompetenciaano
		{
			get { 
				return sdt.gxTpr_Titulocompetenciaano;

			}
			set { 
				sdt.gxTpr_Titulocompetenciaano = value;
			}
		}

		[JsonPropertyName("TituloJurosMora")]
		[JsonPropertyOrder(14)]
		[DataMember(Name="TituloJurosMora", Order=14)]
		public  string gxTpr_Titulojurosmora
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Titulojurosmora, 16, 4));

			}
			set { 
				sdt.gxTpr_Titulojurosmora =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("TituloCompetenciaMes")]
		[JsonPropertyOrder(15)]
		[DataMember(Name="TituloCompetenciaMes", Order=15)]
		public short gxTpr_Titulocompetenciames
		{
			get { 
				return sdt.gxTpr_Titulocompetenciames;

			}
			set { 
				sdt.gxTpr_Titulocompetenciames = value;
			}
		}

		[JsonPropertyName("TituloId")]
		[JsonPropertyOrder(16)]
		[DataMember(Name="TituloId", Order=16)]
		public  string gxTpr_Tituloid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Tituloid, 9, 0));

			}
			set { 
				sdt.gxTpr_Tituloid = (int) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("PropostaId")]
		[JsonPropertyOrder(17)]
		[DataMember(Name="PropostaId", Order=17)]
		public  string gxTpr_Propostaid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Propostaid, 9, 0));

			}
			set { 
				sdt.gxTpr_Propostaid = (int) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("ContaId")]
		[JsonPropertyOrder(18)]
		[DataMember(Name="ContaId", Order=18)]
		public  string gxTpr_Contaid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Contaid, 9, 0));

			}
			set { 
				sdt.gxTpr_Contaid = (int) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("CategoriaTituloId")]
		[JsonPropertyOrder(19)]
		[DataMember(Name="CategoriaTituloId", Order=19)]
		public  string gxTpr_Categoriatituloid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Categoriatituloid, 9, 0));

			}
			set { 
				sdt.gxTpr_Categoriatituloid = (int) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("TituloPropostaTipo")]
		[JsonPropertyOrder(20)]
		[DataMember(Name="TituloPropostaTipo", Order=20)]
		public  string gxTpr_Titulopropostatipo
		{
			get { 
				return sdt.gxTpr_Titulopropostatipo;

			}
			set { 
				 sdt.gxTpr_Titulopropostatipo = value;
			}
		}

		[JsonPropertyName("NotaFiscalParcelamentoId")]
		[JsonPropertyOrder(21)]
		[DataMember(Name="NotaFiscalParcelamentoId", Order=21)]
		public Guid gxTpr_Notafiscalparcelamentoid
		{
			get { 
				return sdt.gxTpr_Notafiscalparcelamentoid;

			}
			set { 
				sdt.gxTpr_Notafiscalparcelamentoid = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdTitulo sdt
		{
			get { 
				return (SdtSdTitulo)Sdt;
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
				sdt = new SdtSdTitulo() ;
			}
		}
	}
	#endregion
}