/*
				   File: type_SdtWcImpNotaFiscalData_Confirmacao
			Description: Confirmacao
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
	[XmlRoot(ElementName="WcImpNotaFiscalData.Confirmacao")]
	[XmlType(TypeName="WcImpNotaFiscalData.Confirmacao" , Namespace="Factory21" )]
	[Serializable]
	public class SdtWcImpNotaFiscalData_Confirmacao : GxUserType
	{
		public SdtWcImpNotaFiscalData_Confirmacao( )
		{
			/* Constructor for serialization */
			gxTv_SdtWcImpNotaFiscalData_Confirmacao_Propostaprotocolo = "";

			gxTv_SdtWcImpNotaFiscalData_Confirmacao_Propostacreatedat = (DateTime)(DateTime.MinValue);

			gxTv_SdtWcImpNotaFiscalData_Confirmacao_Propostastatus = "";

		}

		public SdtWcImpNotaFiscalData_Confirmacao(IGxContext context)
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
			AddObjectProperty("PropostaProtocolo", gxTpr_Propostaprotocolo, false);


			datetime_STZ = gxTpr_Propostacreatedat;
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
			AddObjectProperty("PropostaCreatedAt", sDateCnv, false);



			AddObjectProperty("QuantidadeItens", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Quantidadeitens, 18, 6)), false);


			AddObjectProperty("PropostaValor", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Propostavalor, 18, 2)), false);


			AddObjectProperty("PropostaStatus", gxTpr_Propostastatus, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="PropostaProtocolo")]
		[XmlElement(ElementName="PropostaProtocolo")]
		public string gxTpr_Propostaprotocolo
		{
			get {
				return gxTv_SdtWcImpNotaFiscalData_Confirmacao_Propostaprotocolo; 
			}
			set {
				gxTv_SdtWcImpNotaFiscalData_Confirmacao_Propostaprotocolo = value;
				SetDirty("Propostaprotocolo");
			}
		}



		[SoapElement(ElementName="PropostaCreatedAt")]
		[XmlElement(ElementName="PropostaCreatedAt" , IsNullable=true)]
		public string gxTpr_Propostacreatedat_Nullable
		{
			get {
				if ( gxTv_SdtWcImpNotaFiscalData_Confirmacao_Propostacreatedat == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtWcImpNotaFiscalData_Confirmacao_Propostacreatedat).value ;
			}
			set {
				gxTv_SdtWcImpNotaFiscalData_Confirmacao_Propostacreatedat = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Propostacreatedat
		{
			get {
				return gxTv_SdtWcImpNotaFiscalData_Confirmacao_Propostacreatedat; 
			}
			set {
				gxTv_SdtWcImpNotaFiscalData_Confirmacao_Propostacreatedat = value;
				SetDirty("Propostacreatedat");
			}
		}


		[SoapElement(ElementName="QuantidadeItens")]
		[XmlElement(ElementName="QuantidadeItens")]
		public string gxTpr_Quantidadeitens_double
		{
			get {
				return Convert.ToString(gxTv_SdtWcImpNotaFiscalData_Confirmacao_Quantidadeitens, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtWcImpNotaFiscalData_Confirmacao_Quantidadeitens = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Quantidadeitens
		{
			get {
				return gxTv_SdtWcImpNotaFiscalData_Confirmacao_Quantidadeitens; 
			}
			set {
				gxTv_SdtWcImpNotaFiscalData_Confirmacao_Quantidadeitens = value;
				SetDirty("Quantidadeitens");
			}
		}



		[SoapElement(ElementName="PropostaValor")]
		[XmlElement(ElementName="PropostaValor")]
		public string gxTpr_Propostavalor_double
		{
			get {
				return Convert.ToString(gxTv_SdtWcImpNotaFiscalData_Confirmacao_Propostavalor, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtWcImpNotaFiscalData_Confirmacao_Propostavalor = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Propostavalor
		{
			get {
				return gxTv_SdtWcImpNotaFiscalData_Confirmacao_Propostavalor; 
			}
			set {
				gxTv_SdtWcImpNotaFiscalData_Confirmacao_Propostavalor = value;
				SetDirty("Propostavalor");
			}
		}




		[SoapElement(ElementName="PropostaStatus")]
		[XmlElement(ElementName="PropostaStatus")]
		public string gxTpr_Propostastatus
		{
			get {
				return gxTv_SdtWcImpNotaFiscalData_Confirmacao_Propostastatus; 
			}
			set {
				gxTv_SdtWcImpNotaFiscalData_Confirmacao_Propostastatus = value;
				SetDirty("Propostastatus");
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
			gxTv_SdtWcImpNotaFiscalData_Confirmacao_Propostaprotocolo = "";
			gxTv_SdtWcImpNotaFiscalData_Confirmacao_Propostacreatedat = (DateTime)(DateTime.MinValue);


			gxTv_SdtWcImpNotaFiscalData_Confirmacao_Propostastatus = "";
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

		protected string gxTv_SdtWcImpNotaFiscalData_Confirmacao_Propostaprotocolo;
		 

		protected DateTime gxTv_SdtWcImpNotaFiscalData_Confirmacao_Propostacreatedat;
		 

		protected decimal gxTv_SdtWcImpNotaFiscalData_Confirmacao_Quantidadeitens;
		 

		protected decimal gxTv_SdtWcImpNotaFiscalData_Confirmacao_Propostavalor;
		 

		protected string gxTv_SdtWcImpNotaFiscalData_Confirmacao_Propostastatus;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WcImpNotaFiscalData.Confirmacao", Namespace="Factory21")]
	public class SdtWcImpNotaFiscalData_Confirmacao_RESTInterface : GxGenericCollectionItem<SdtWcImpNotaFiscalData_Confirmacao>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWcImpNotaFiscalData_Confirmacao_RESTInterface( ) : base()
		{	
		}

		public SdtWcImpNotaFiscalData_Confirmacao_RESTInterface( SdtWcImpNotaFiscalData_Confirmacao psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("PropostaProtocolo")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="PropostaProtocolo", Order=0)]
		public  string gxTpr_Propostaprotocolo
		{
			get { 
				return sdt.gxTpr_Propostaprotocolo;

			}
			set { 
				 sdt.gxTpr_Propostaprotocolo = value;
			}
		}

		[JsonPropertyName("PropostaCreatedAt")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="PropostaCreatedAt", Order=1)]
		public  string gxTpr_Propostacreatedat
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Propostacreatedat,context);

			}
			set { 
				sdt.gxTpr_Propostacreatedat = DateTimeUtil.CToT2(value,context);
			}
		}

		[JsonPropertyName("QuantidadeItens")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="QuantidadeItens", Order=2)]
		public  string gxTpr_Quantidadeitens
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Quantidadeitens, 18, 6));

			}
			set { 
				sdt.gxTpr_Quantidadeitens =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("PropostaValor")]
		[JsonPropertyOrder(3)]
		[DataMember(Name="PropostaValor", Order=3)]
		public  string gxTpr_Propostavalor
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Propostavalor, 18, 2));

			}
			set { 
				sdt.gxTpr_Propostavalor =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("PropostaStatus")]
		[JsonPropertyOrder(4)]
		[DataMember(Name="PropostaStatus", Order=4)]
		public  string gxTpr_Propostastatus
		{
			get { 
				return sdt.gxTpr_Propostastatus;

			}
			set { 
				 sdt.gxTpr_Propostastatus = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtWcImpNotaFiscalData_Confirmacao sdt
		{
			get { 
				return (SdtWcImpNotaFiscalData_Confirmacao)Sdt;
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
				sdt = new SdtWcImpNotaFiscalData_Confirmacao() ;
			}
		}
	}
	#endregion
}