/*
				   File: type_SdtSdParcelaCalculadaTaxa
			Description: SdParcelaCalculadaTaxa
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
	[XmlRoot(ElementName="SdParcelaCalculadaTaxa")]
	[XmlType(TypeName="SdParcelaCalculadaTaxa" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdParcelaCalculadaTaxa : GxUserType
	{
		public SdtSdParcelaCalculadaTaxa( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdParcelaCalculadaTaxa_Parcela = "";

			gxTv_SdtSdParcelaCalculadaTaxa_Notafiscalnumero = "";


		}

		public SdtSdParcelaCalculadaTaxa(IGxContext context)
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
			AddObjectProperty("Parcela", gxTpr_Parcela, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Vencimento)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Vencimento)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Vencimento)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("Vencimento", sDateCnv, false);



			AddObjectProperty("ValorBase", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Valorbase, 18, 2)), false);


			AddObjectProperty("JurosValor", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Jurosvalor, 18, 2)), false);


			AddObjectProperty("JurosPercentual", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Jurospercentual, 16, 4)), false);


			AddObjectProperty("TaxaValor", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Taxavalor, 18, 2)), false);


			AddObjectProperty("TaxaPercentual", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Taxapercentual, 16, 4)), false);


			AddObjectProperty("ValorTotal", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Valortotal, 18, 2)), false);


			AddObjectProperty("NotaFiscalNumero", gxTpr_Notafiscalnumero, false);


			AddObjectProperty("Dias", gxTpr_Dias, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Parcela")]
		[XmlElement(ElementName="Parcela")]
		public string gxTpr_Parcela
		{
			get {
				return gxTv_SdtSdParcelaCalculadaTaxa_Parcela; 
			}
			set {
				gxTv_SdtSdParcelaCalculadaTaxa_Parcela = value;
				SetDirty("Parcela");
			}
		}



		[SoapElement(ElementName="Vencimento")]
		[XmlElement(ElementName="Vencimento" , IsNullable=true)]
		public string gxTpr_Vencimento_Nullable
		{
			get {
				if ( gxTv_SdtSdParcelaCalculadaTaxa_Vencimento == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSdParcelaCalculadaTaxa_Vencimento).value ;
			}
			set {
				gxTv_SdtSdParcelaCalculadaTaxa_Vencimento = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Vencimento
		{
			get {
				return gxTv_SdtSdParcelaCalculadaTaxa_Vencimento; 
			}
			set {
				gxTv_SdtSdParcelaCalculadaTaxa_Vencimento = value;
				SetDirty("Vencimento");
			}
		}


		[SoapElement(ElementName="ValorBase")]
		[XmlElement(ElementName="ValorBase")]
		public string gxTpr_Valorbase_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdParcelaCalculadaTaxa_Valorbase, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdParcelaCalculadaTaxa_Valorbase = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Valorbase
		{
			get {
				return gxTv_SdtSdParcelaCalculadaTaxa_Valorbase; 
			}
			set {
				gxTv_SdtSdParcelaCalculadaTaxa_Valorbase = value;
				SetDirty("Valorbase");
			}
		}



		[SoapElement(ElementName="JurosValor")]
		[XmlElement(ElementName="JurosValor")]
		public string gxTpr_Jurosvalor_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdParcelaCalculadaTaxa_Jurosvalor, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdParcelaCalculadaTaxa_Jurosvalor = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Jurosvalor
		{
			get {
				return gxTv_SdtSdParcelaCalculadaTaxa_Jurosvalor; 
			}
			set {
				gxTv_SdtSdParcelaCalculadaTaxa_Jurosvalor = value;
				SetDirty("Jurosvalor");
			}
		}



		[SoapElement(ElementName="JurosPercentual")]
		[XmlElement(ElementName="JurosPercentual")]
		public string gxTpr_Jurospercentual_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdParcelaCalculadaTaxa_Jurospercentual, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdParcelaCalculadaTaxa_Jurospercentual = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Jurospercentual
		{
			get {
				return gxTv_SdtSdParcelaCalculadaTaxa_Jurospercentual; 
			}
			set {
				gxTv_SdtSdParcelaCalculadaTaxa_Jurospercentual = value;
				SetDirty("Jurospercentual");
			}
		}



		[SoapElement(ElementName="TaxaValor")]
		[XmlElement(ElementName="TaxaValor")]
		public string gxTpr_Taxavalor_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdParcelaCalculadaTaxa_Taxavalor, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdParcelaCalculadaTaxa_Taxavalor = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Taxavalor
		{
			get {
				return gxTv_SdtSdParcelaCalculadaTaxa_Taxavalor; 
			}
			set {
				gxTv_SdtSdParcelaCalculadaTaxa_Taxavalor = value;
				SetDirty("Taxavalor");
			}
		}



		[SoapElement(ElementName="TaxaPercentual")]
		[XmlElement(ElementName="TaxaPercentual")]
		public string gxTpr_Taxapercentual_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdParcelaCalculadaTaxa_Taxapercentual, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdParcelaCalculadaTaxa_Taxapercentual = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Taxapercentual
		{
			get {
				return gxTv_SdtSdParcelaCalculadaTaxa_Taxapercentual; 
			}
			set {
				gxTv_SdtSdParcelaCalculadaTaxa_Taxapercentual = value;
				SetDirty("Taxapercentual");
			}
		}



		[SoapElement(ElementName="ValorTotal")]
		[XmlElement(ElementName="ValorTotal")]
		public string gxTpr_Valortotal_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdParcelaCalculadaTaxa_Valortotal, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdParcelaCalculadaTaxa_Valortotal = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Valortotal
		{
			get {
				return gxTv_SdtSdParcelaCalculadaTaxa_Valortotal; 
			}
			set {
				gxTv_SdtSdParcelaCalculadaTaxa_Valortotal = value;
				SetDirty("Valortotal");
			}
		}




		[SoapElement(ElementName="NotaFiscalNumero")]
		[XmlElement(ElementName="NotaFiscalNumero")]
		public string gxTpr_Notafiscalnumero
		{
			get {
				return gxTv_SdtSdParcelaCalculadaTaxa_Notafiscalnumero; 
			}
			set {
				gxTv_SdtSdParcelaCalculadaTaxa_Notafiscalnumero = value;
				SetDirty("Notafiscalnumero");
			}
		}




		[SoapElement(ElementName="Dias")]
		[XmlElement(ElementName="Dias")]
		public short gxTpr_Dias
		{
			get {
				return gxTv_SdtSdParcelaCalculadaTaxa_Dias; 
			}
			set {
				gxTv_SdtSdParcelaCalculadaTaxa_Dias = value;
				SetDirty("Dias");
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
			gxTv_SdtSdParcelaCalculadaTaxa_Parcela = "";







			gxTv_SdtSdParcelaCalculadaTaxa_Notafiscalnumero = "";

			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected string gxTv_SdtSdParcelaCalculadaTaxa_Parcela;
		 

		protected DateTime gxTv_SdtSdParcelaCalculadaTaxa_Vencimento;
		 

		protected decimal gxTv_SdtSdParcelaCalculadaTaxa_Valorbase;
		 

		protected decimal gxTv_SdtSdParcelaCalculadaTaxa_Jurosvalor;
		 

		protected decimal gxTv_SdtSdParcelaCalculadaTaxa_Jurospercentual;
		 

		protected decimal gxTv_SdtSdParcelaCalculadaTaxa_Taxavalor;
		 

		protected decimal gxTv_SdtSdParcelaCalculadaTaxa_Taxapercentual;
		 

		protected decimal gxTv_SdtSdParcelaCalculadaTaxa_Valortotal;
		 

		protected string gxTv_SdtSdParcelaCalculadaTaxa_Notafiscalnumero;
		 

		protected short gxTv_SdtSdParcelaCalculadaTaxa_Dias;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdParcelaCalculadaTaxa", Namespace="Factory21")]
	public class SdtSdParcelaCalculadaTaxa_RESTInterface : GxGenericCollectionItem<SdtSdParcelaCalculadaTaxa>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdParcelaCalculadaTaxa_RESTInterface( ) : base()
		{	
		}

		public SdtSdParcelaCalculadaTaxa_RESTInterface( SdtSdParcelaCalculadaTaxa psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("Parcela")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="Parcela", Order=0)]
		public  string gxTpr_Parcela
		{
			get { 
				return sdt.gxTpr_Parcela;

			}
			set { 
				 sdt.gxTpr_Parcela = value;
			}
		}

		[JsonPropertyName("Vencimento")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="Vencimento", Order=1)]
		public  string gxTpr_Vencimento
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Vencimento);

			}
			set { 
				sdt.gxTpr_Vencimento = DateTimeUtil.CToD2(value);
			}
		}

		[JsonPropertyName("ValorBase")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="ValorBase", Order=2)]
		public  string gxTpr_Valorbase
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Valorbase, 18, 2));

			}
			set { 
				sdt.gxTpr_Valorbase =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("JurosValor")]
		[JsonPropertyOrder(3)]
		[DataMember(Name="JurosValor", Order=3)]
		public  string gxTpr_Jurosvalor
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Jurosvalor, 18, 2));

			}
			set { 
				sdt.gxTpr_Jurosvalor =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("JurosPercentual")]
		[JsonPropertyOrder(4)]
		[DataMember(Name="JurosPercentual", Order=4)]
		public  string gxTpr_Jurospercentual
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Jurospercentual, 16, 4));

			}
			set { 
				sdt.gxTpr_Jurospercentual =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("TaxaValor")]
		[JsonPropertyOrder(5)]
		[DataMember(Name="TaxaValor", Order=5)]
		public  string gxTpr_Taxavalor
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Taxavalor, 18, 2));

			}
			set { 
				sdt.gxTpr_Taxavalor =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("TaxaPercentual")]
		[JsonPropertyOrder(6)]
		[DataMember(Name="TaxaPercentual", Order=6)]
		public  string gxTpr_Taxapercentual
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Taxapercentual, 16, 4));

			}
			set { 
				sdt.gxTpr_Taxapercentual =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("ValorTotal")]
		[JsonPropertyOrder(7)]
		[DataMember(Name="ValorTotal", Order=7)]
		public  string gxTpr_Valortotal
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Valortotal, 18, 2));

			}
			set { 
				sdt.gxTpr_Valortotal =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("NotaFiscalNumero")]
		[JsonPropertyOrder(8)]
		[DataMember(Name="NotaFiscalNumero", Order=8)]
		public  string gxTpr_Notafiscalnumero
		{
			get { 
				return sdt.gxTpr_Notafiscalnumero;

			}
			set { 
				 sdt.gxTpr_Notafiscalnumero = value;
			}
		}

		[JsonPropertyName("Dias")]
		[JsonPropertyOrder(9)]
		[DataMember(Name="Dias", Order=9)]
		public short gxTpr_Dias
		{
			get { 
				return sdt.gxTpr_Dias;

			}
			set { 
				sdt.gxTpr_Dias = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdParcelaCalculadaTaxa sdt
		{
			get { 
				return (SdtSdParcelaCalculadaTaxa)Sdt;
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
				sdt = new SdtSdParcelaCalculadaTaxa() ;
			}
		}
	}
	#endregion
}