/*
				   File: type_SdtSdTituloMovimento
			Description: SdTituloMovimento
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
	[XmlRoot(ElementName="SdTituloMovimento")]
	[XmlType(TypeName="SdTituloMovimento" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdTituloMovimento : GxUserType
	{
		public SdtSdTituloMovimento( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdTituloMovimento_Titulomovimentotipo = "";

			gxTv_SdtSdTituloMovimento_Titulomovimentocreatedat = (DateTime)(DateTime.MinValue);

			gxTv_SdtSdTituloMovimento_Titulomovimentoupdatedat = (DateTime)(DateTime.MinValue);

			gxTv_SdtSdTituloMovimento_Titulomovimentoope = "";


		}

		public SdtSdTituloMovimento(IGxContext context)
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
			AddObjectProperty("TipoPagamentoId", gxTpr_Tipopagamentoid, false);


			AddObjectProperty("TituloId", gxTpr_Tituloid, false);


			AddObjectProperty("TituloMovimentoValor", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Titulomovimentovalor, 18, 2)), false);


			AddObjectProperty("TituloMovimentoTipo", gxTpr_Titulomovimentotipo, false);


			AddObjectProperty("TituloMovimentoSoma", gxTpr_Titulomovimentosoma, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Titulomovimentodatacredito)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Titulomovimentodatacredito)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Titulomovimentodatacredito)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("TituloMovimentoDataCredito", sDateCnv, false);



			datetime_STZ = gxTpr_Titulomovimentocreatedat;
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
			AddObjectProperty("TituloMovimentoCreatedAt", sDateCnv, false);



			datetime_STZ = gxTpr_Titulomovimentoupdatedat;
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
			AddObjectProperty("TituloMovimentoUpdatedAt", sDateCnv, false);



			AddObjectProperty("TituloMovimentoOpe", gxTpr_Titulomovimentoope, false);


			AddObjectProperty("TituloMovimentoConta", gxTpr_Titulomovimentoconta, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="TipoPagamentoId")]
		[XmlElement(ElementName="TipoPagamentoId")]
		public int gxTpr_Tipopagamentoid
		{
			get {
				return gxTv_SdtSdTituloMovimento_Tipopagamentoid; 
			}
			set {
				gxTv_SdtSdTituloMovimento_Tipopagamentoid = value;
				SetDirty("Tipopagamentoid");
			}
		}




		[SoapElement(ElementName="TituloId")]
		[XmlElement(ElementName="TituloId")]
		public int gxTpr_Tituloid
		{
			get {
				return gxTv_SdtSdTituloMovimento_Tituloid; 
			}
			set {
				gxTv_SdtSdTituloMovimento_Tituloid = value;
				SetDirty("Tituloid");
			}
		}



		[SoapElement(ElementName="TituloMovimentoValor")]
		[XmlElement(ElementName="TituloMovimentoValor")]
		public string gxTpr_Titulomovimentovalor_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdTituloMovimento_Titulomovimentovalor, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdTituloMovimento_Titulomovimentovalor = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Titulomovimentovalor
		{
			get {
				return gxTv_SdtSdTituloMovimento_Titulomovimentovalor; 
			}
			set {
				gxTv_SdtSdTituloMovimento_Titulomovimentovalor = value;
				SetDirty("Titulomovimentovalor");
			}
		}




		[SoapElement(ElementName="TituloMovimentoTipo")]
		[XmlElement(ElementName="TituloMovimentoTipo")]
		public string gxTpr_Titulomovimentotipo
		{
			get {
				return gxTv_SdtSdTituloMovimento_Titulomovimentotipo; 
			}
			set {
				gxTv_SdtSdTituloMovimento_Titulomovimentotipo = value;
				SetDirty("Titulomovimentotipo");
			}
		}




		[SoapElement(ElementName="TituloMovimentoSoma")]
		[XmlElement(ElementName="TituloMovimentoSoma")]
		public bool gxTpr_Titulomovimentosoma
		{
			get {
				return gxTv_SdtSdTituloMovimento_Titulomovimentosoma; 
			}
			set {
				gxTv_SdtSdTituloMovimento_Titulomovimentosoma = value;
				SetDirty("Titulomovimentosoma");
			}
		}



		[SoapElement(ElementName="TituloMovimentoDataCredito")]
		[XmlElement(ElementName="TituloMovimentoDataCredito" , IsNullable=true)]
		public string gxTpr_Titulomovimentodatacredito_Nullable
		{
			get {
				if ( gxTv_SdtSdTituloMovimento_Titulomovimentodatacredito == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSdTituloMovimento_Titulomovimentodatacredito).value ;
			}
			set {
				gxTv_SdtSdTituloMovimento_Titulomovimentodatacredito = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Titulomovimentodatacredito
		{
			get {
				return gxTv_SdtSdTituloMovimento_Titulomovimentodatacredito; 
			}
			set {
				gxTv_SdtSdTituloMovimento_Titulomovimentodatacredito = value;
				SetDirty("Titulomovimentodatacredito");
			}
		}


		[SoapElement(ElementName="TituloMovimentoCreatedAt")]
		[XmlElement(ElementName="TituloMovimentoCreatedAt" , IsNullable=true)]
		public string gxTpr_Titulomovimentocreatedat_Nullable
		{
			get {
				if ( gxTv_SdtSdTituloMovimento_Titulomovimentocreatedat == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSdTituloMovimento_Titulomovimentocreatedat).value ;
			}
			set {
				gxTv_SdtSdTituloMovimento_Titulomovimentocreatedat = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Titulomovimentocreatedat
		{
			get {
				return gxTv_SdtSdTituloMovimento_Titulomovimentocreatedat; 
			}
			set {
				gxTv_SdtSdTituloMovimento_Titulomovimentocreatedat = value;
				SetDirty("Titulomovimentocreatedat");
			}
		}


		[SoapElement(ElementName="TituloMovimentoUpdatedAt")]
		[XmlElement(ElementName="TituloMovimentoUpdatedAt" , IsNullable=true)]
		public string gxTpr_Titulomovimentoupdatedat_Nullable
		{
			get {
				if ( gxTv_SdtSdTituloMovimento_Titulomovimentoupdatedat == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSdTituloMovimento_Titulomovimentoupdatedat).value ;
			}
			set {
				gxTv_SdtSdTituloMovimento_Titulomovimentoupdatedat = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Titulomovimentoupdatedat
		{
			get {
				return gxTv_SdtSdTituloMovimento_Titulomovimentoupdatedat; 
			}
			set {
				gxTv_SdtSdTituloMovimento_Titulomovimentoupdatedat = value;
				SetDirty("Titulomovimentoupdatedat");
			}
		}



		[SoapElement(ElementName="TituloMovimentoOpe")]
		[XmlElement(ElementName="TituloMovimentoOpe")]
		public string gxTpr_Titulomovimentoope
		{
			get {
				return gxTv_SdtSdTituloMovimento_Titulomovimentoope; 
			}
			set {
				gxTv_SdtSdTituloMovimento_Titulomovimentoope = value;
				SetDirty("Titulomovimentoope");
			}
		}




		[SoapElement(ElementName="TituloMovimentoConta")]
		[XmlElement(ElementName="TituloMovimentoConta")]
		public int gxTpr_Titulomovimentoconta
		{
			get {
				return gxTv_SdtSdTituloMovimento_Titulomovimentoconta; 
			}
			set {
				gxTv_SdtSdTituloMovimento_Titulomovimentoconta = value;
				SetDirty("Titulomovimentoconta");
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
			gxTv_SdtSdTituloMovimento_Titulomovimentotipo = "";


			gxTv_SdtSdTituloMovimento_Titulomovimentocreatedat = (DateTime)(DateTime.MinValue);
			gxTv_SdtSdTituloMovimento_Titulomovimentoupdatedat = (DateTime)(DateTime.MinValue);
			gxTv_SdtSdTituloMovimento_Titulomovimentoope = "";

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

		protected int gxTv_SdtSdTituloMovimento_Tipopagamentoid;
		 

		protected int gxTv_SdtSdTituloMovimento_Tituloid;
		 

		protected decimal gxTv_SdtSdTituloMovimento_Titulomovimentovalor;
		 

		protected string gxTv_SdtSdTituloMovimento_Titulomovimentotipo;
		 

		protected bool gxTv_SdtSdTituloMovimento_Titulomovimentosoma;
		 

		protected DateTime gxTv_SdtSdTituloMovimento_Titulomovimentodatacredito;
		 

		protected DateTime gxTv_SdtSdTituloMovimento_Titulomovimentocreatedat;
		 

		protected DateTime gxTv_SdtSdTituloMovimento_Titulomovimentoupdatedat;
		 

		protected string gxTv_SdtSdTituloMovimento_Titulomovimentoope;
		 

		protected int gxTv_SdtSdTituloMovimento_Titulomovimentoconta;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdTituloMovimento", Namespace="Factory21")]
	public class SdtSdTituloMovimento_RESTInterface : GxGenericCollectionItem<SdtSdTituloMovimento>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdTituloMovimento_RESTInterface( ) : base()
		{	
		}

		public SdtSdTituloMovimento_RESTInterface( SdtSdTituloMovimento psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("TipoPagamentoId")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="TipoPagamentoId", Order=0)]
		public  string gxTpr_Tipopagamentoid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Tipopagamentoid, 9, 0));

			}
			set { 
				sdt.gxTpr_Tipopagamentoid = (int) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("TituloId")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="TituloId", Order=1)]
		public  string gxTpr_Tituloid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Tituloid, 9, 0));

			}
			set { 
				sdt.gxTpr_Tituloid = (int) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("TituloMovimentoValor")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="TituloMovimentoValor", Order=2)]
		public  string gxTpr_Titulomovimentovalor
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Titulomovimentovalor, 18, 2));

			}
			set { 
				sdt.gxTpr_Titulomovimentovalor =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("TituloMovimentoTipo")]
		[JsonPropertyOrder(3)]
		[DataMember(Name="TituloMovimentoTipo", Order=3)]
		public  string gxTpr_Titulomovimentotipo
		{
			get { 
				return sdt.gxTpr_Titulomovimentotipo;

			}
			set { 
				 sdt.gxTpr_Titulomovimentotipo = value;
			}
		}

		[JsonPropertyName("TituloMovimentoSoma")]
		[JsonPropertyOrder(4)]
		[JsonConverter(typeof(BoolStringJsonConverter))]
		[DataMember(Name="TituloMovimentoSoma", Order=4)]
		public bool gxTpr_Titulomovimentosoma
		{
			get { 
				return sdt.gxTpr_Titulomovimentosoma;

			}
			set { 
				sdt.gxTpr_Titulomovimentosoma = value;
			}
		}

		[JsonPropertyName("TituloMovimentoDataCredito")]
		[JsonPropertyOrder(5)]
		[DataMember(Name="TituloMovimentoDataCredito", Order=5)]
		public  string gxTpr_Titulomovimentodatacredito
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Titulomovimentodatacredito);

			}
			set { 
				sdt.gxTpr_Titulomovimentodatacredito = DateTimeUtil.CToD2(value);
			}
		}

		[JsonPropertyName("TituloMovimentoCreatedAt")]
		[JsonPropertyOrder(6)]
		[DataMember(Name="TituloMovimentoCreatedAt", Order=6)]
		public  string gxTpr_Titulomovimentocreatedat
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Titulomovimentocreatedat,context);

			}
			set { 
				sdt.gxTpr_Titulomovimentocreatedat = DateTimeUtil.CToT2(value,context);
			}
		}

		[JsonPropertyName("TituloMovimentoUpdatedAt")]
		[JsonPropertyOrder(7)]
		[DataMember(Name="TituloMovimentoUpdatedAt", Order=7)]
		public  string gxTpr_Titulomovimentoupdatedat
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Titulomovimentoupdatedat,context);

			}
			set { 
				sdt.gxTpr_Titulomovimentoupdatedat = DateTimeUtil.CToT2(value,context);
			}
		}

		[JsonPropertyName("TituloMovimentoOpe")]
		[JsonPropertyOrder(8)]
		[DataMember(Name="TituloMovimentoOpe", Order=8)]
		public  string gxTpr_Titulomovimentoope
		{
			get { 
				return sdt.gxTpr_Titulomovimentoope;

			}
			set { 
				 sdt.gxTpr_Titulomovimentoope = value;
			}
		}

		[JsonPropertyName("TituloMovimentoConta")]
		[JsonPropertyOrder(9)]
		[DataMember(Name="TituloMovimentoConta", Order=9)]
		public  string gxTpr_Titulomovimentoconta
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Titulomovimentoconta, 9, 0));

			}
			set { 
				sdt.gxTpr_Titulomovimentoconta = (int) NumberUtil.Val( value, ".");
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdTituloMovimento sdt
		{
			get { 
				return (SdtSdTituloMovimento)Sdt;
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
				sdt = new SdtSdTituloMovimento() ;
			}
		}
	}
	#endregion
}