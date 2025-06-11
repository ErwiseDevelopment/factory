/*
				   File: type_SdtSdProdutoNotaFiscal
			Description: SdProdutoNotaFiscal
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
	[XmlRoot(ElementName="SdProdutoNotaFiscal")]
	[XmlType(TypeName="SdProdutoNotaFiscal" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdProdutoNotaFiscal : GxUserType
	{
		public SdtSdProdutoNotaFiscal( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdProdutoNotaFiscal_Cprod = "";

			gxTv_SdtSdProdutoNotaFiscal_Cnfe = "";

			gxTv_SdtSdProdutoNotaFiscal_Cean = "";

			gxTv_SdtSdProdutoNotaFiscal_Xprod = "";

			gxTv_SdtSdProdutoNotaFiscal_Cfop = "";

			gxTv_SdtSdProdutoNotaFiscal_Ucom = "";

			gxTv_SdtSdProdutoNotaFiscal_Qcom = "";

			gxTv_SdtSdProdutoNotaFiscal_Vuncom = "";

			gxTv_SdtSdProdutoNotaFiscal_Vprod = "";

			gxTv_SdtSdProdutoNotaFiscal_Ceantrib = "";

			gxTv_SdtSdProdutoNotaFiscal_Utrib = "";

			gxTv_SdtSdProdutoNotaFiscal_Qtrib = "";

			gxTv_SdtSdProdutoNotaFiscal_Vuntrib = "";


		}

		public SdtSdProdutoNotaFiscal(IGxContext context)
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
			AddObjectProperty("cProd", gxTpr_Cprod, false);


			AddObjectProperty("cNfe", gxTpr_Cnfe, false);


			AddObjectProperty("cEAN", gxTpr_Cean, false);


			AddObjectProperty("xProd", gxTpr_Xprod, false);


			AddObjectProperty("CFOP", gxTpr_Cfop, false);


			AddObjectProperty("uCom", gxTpr_Ucom, false);


			AddObjectProperty("qCom", gxTpr_Qcom, false);


			AddObjectProperty("vUnCom", gxTpr_Vuncom, false);


			AddObjectProperty("vProd", gxTpr_Vprod, false);


			AddObjectProperty("cEANTrib", gxTpr_Ceantrib, false);


			AddObjectProperty("uTrib", gxTpr_Utrib, false);


			AddObjectProperty("qTrib", gxTpr_Qtrib, false);


			AddObjectProperty("vUnTrib", gxTpr_Vuntrib, false);


			AddObjectProperty("IsSel", gxTpr_Issel, false);


			AddObjectProperty("Id", gxTpr_Id, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="cProd")]
		[XmlElement(ElementName="cProd")]
		public string gxTpr_Cprod
		{
			get {
				return gxTv_SdtSdProdutoNotaFiscal_Cprod; 
			}
			set {
				gxTv_SdtSdProdutoNotaFiscal_Cprod = value;
				SetDirty("Cprod");
			}
		}




		[SoapElement(ElementName="cNfe")]
		[XmlElement(ElementName="cNfe")]
		public string gxTpr_Cnfe
		{
			get {
				return gxTv_SdtSdProdutoNotaFiscal_Cnfe; 
			}
			set {
				gxTv_SdtSdProdutoNotaFiscal_Cnfe = value;
				SetDirty("Cnfe");
			}
		}




		[SoapElement(ElementName="cEAN")]
		[XmlElement(ElementName="cEAN")]
		public string gxTpr_Cean
		{
			get {
				return gxTv_SdtSdProdutoNotaFiscal_Cean; 
			}
			set {
				gxTv_SdtSdProdutoNotaFiscal_Cean = value;
				SetDirty("Cean");
			}
		}




		[SoapElement(ElementName="xProd")]
		[XmlElement(ElementName="xProd")]
		public string gxTpr_Xprod
		{
			get {
				return gxTv_SdtSdProdutoNotaFiscal_Xprod; 
			}
			set {
				gxTv_SdtSdProdutoNotaFiscal_Xprod = value;
				SetDirty("Xprod");
			}
		}




		[SoapElement(ElementName="CFOP")]
		[XmlElement(ElementName="CFOP")]
		public string gxTpr_Cfop
		{
			get {
				return gxTv_SdtSdProdutoNotaFiscal_Cfop; 
			}
			set {
				gxTv_SdtSdProdutoNotaFiscal_Cfop = value;
				SetDirty("Cfop");
			}
		}




		[SoapElement(ElementName="uCom")]
		[XmlElement(ElementName="uCom")]
		public string gxTpr_Ucom
		{
			get {
				return gxTv_SdtSdProdutoNotaFiscal_Ucom; 
			}
			set {
				gxTv_SdtSdProdutoNotaFiscal_Ucom = value;
				SetDirty("Ucom");
			}
		}




		[SoapElement(ElementName="qCom")]
		[XmlElement(ElementName="qCom")]
		public string gxTpr_Qcom
		{
			get {
				return gxTv_SdtSdProdutoNotaFiscal_Qcom; 
			}
			set {
				gxTv_SdtSdProdutoNotaFiscal_Qcom = value;
				SetDirty("Qcom");
			}
		}




		[SoapElement(ElementName="vUnCom")]
		[XmlElement(ElementName="vUnCom")]
		public string gxTpr_Vuncom
		{
			get {
				return gxTv_SdtSdProdutoNotaFiscal_Vuncom; 
			}
			set {
				gxTv_SdtSdProdutoNotaFiscal_Vuncom = value;
				SetDirty("Vuncom");
			}
		}




		[SoapElement(ElementName="vProd")]
		[XmlElement(ElementName="vProd")]
		public string gxTpr_Vprod
		{
			get {
				return gxTv_SdtSdProdutoNotaFiscal_Vprod; 
			}
			set {
				gxTv_SdtSdProdutoNotaFiscal_Vprod = value;
				SetDirty("Vprod");
			}
		}




		[SoapElement(ElementName="cEANTrib")]
		[XmlElement(ElementName="cEANTrib")]
		public string gxTpr_Ceantrib
		{
			get {
				return gxTv_SdtSdProdutoNotaFiscal_Ceantrib; 
			}
			set {
				gxTv_SdtSdProdutoNotaFiscal_Ceantrib = value;
				SetDirty("Ceantrib");
			}
		}




		[SoapElement(ElementName="uTrib")]
		[XmlElement(ElementName="uTrib")]
		public string gxTpr_Utrib
		{
			get {
				return gxTv_SdtSdProdutoNotaFiscal_Utrib; 
			}
			set {
				gxTv_SdtSdProdutoNotaFiscal_Utrib = value;
				SetDirty("Utrib");
			}
		}




		[SoapElement(ElementName="qTrib")]
		[XmlElement(ElementName="qTrib")]
		public string gxTpr_Qtrib
		{
			get {
				return gxTv_SdtSdProdutoNotaFiscal_Qtrib; 
			}
			set {
				gxTv_SdtSdProdutoNotaFiscal_Qtrib = value;
				SetDirty("Qtrib");
			}
		}




		[SoapElement(ElementName="vUnTrib")]
		[XmlElement(ElementName="vUnTrib")]
		public string gxTpr_Vuntrib
		{
			get {
				return gxTv_SdtSdProdutoNotaFiscal_Vuntrib; 
			}
			set {
				gxTv_SdtSdProdutoNotaFiscal_Vuntrib = value;
				SetDirty("Vuntrib");
			}
		}




		[SoapElement(ElementName="IsSel")]
		[XmlElement(ElementName="IsSel")]
		public bool gxTpr_Issel
		{
			get {
				return gxTv_SdtSdProdutoNotaFiscal_Issel; 
			}
			set {
				gxTv_SdtSdProdutoNotaFiscal_Issel = value;
				SetDirty("Issel");
			}
		}




		[SoapElement(ElementName="Id")]
		[XmlElement(ElementName="Id")]
		public int gxTpr_Id
		{
			get {
				return gxTv_SdtSdProdutoNotaFiscal_Id; 
			}
			set {
				gxTv_SdtSdProdutoNotaFiscal_Id = value;
				SetDirty("Id");
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
			gxTv_SdtSdProdutoNotaFiscal_Cprod = "";
			gxTv_SdtSdProdutoNotaFiscal_Cnfe = "";
			gxTv_SdtSdProdutoNotaFiscal_Cean = "";
			gxTv_SdtSdProdutoNotaFiscal_Xprod = "";
			gxTv_SdtSdProdutoNotaFiscal_Cfop = "";
			gxTv_SdtSdProdutoNotaFiscal_Ucom = "";
			gxTv_SdtSdProdutoNotaFiscal_Qcom = "";
			gxTv_SdtSdProdutoNotaFiscal_Vuncom = "";
			gxTv_SdtSdProdutoNotaFiscal_Vprod = "";
			gxTv_SdtSdProdutoNotaFiscal_Ceantrib = "";
			gxTv_SdtSdProdutoNotaFiscal_Utrib = "";
			gxTv_SdtSdProdutoNotaFiscal_Qtrib = "";
			gxTv_SdtSdProdutoNotaFiscal_Vuntrib = "";


			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSdProdutoNotaFiscal_Cprod;
		 

		protected string gxTv_SdtSdProdutoNotaFiscal_Cnfe;
		 

		protected string gxTv_SdtSdProdutoNotaFiscal_Cean;
		 

		protected string gxTv_SdtSdProdutoNotaFiscal_Xprod;
		 

		protected string gxTv_SdtSdProdutoNotaFiscal_Cfop;
		 

		protected string gxTv_SdtSdProdutoNotaFiscal_Ucom;
		 

		protected string gxTv_SdtSdProdutoNotaFiscal_Qcom;
		 

		protected string gxTv_SdtSdProdutoNotaFiscal_Vuncom;
		 

		protected string gxTv_SdtSdProdutoNotaFiscal_Vprod;
		 

		protected string gxTv_SdtSdProdutoNotaFiscal_Ceantrib;
		 

		protected string gxTv_SdtSdProdutoNotaFiscal_Utrib;
		 

		protected string gxTv_SdtSdProdutoNotaFiscal_Qtrib;
		 

		protected string gxTv_SdtSdProdutoNotaFiscal_Vuntrib;
		 

		protected bool gxTv_SdtSdProdutoNotaFiscal_Issel;
		 

		protected int gxTv_SdtSdProdutoNotaFiscal_Id;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdProdutoNotaFiscal", Namespace="Factory21")]
	public class SdtSdProdutoNotaFiscal_RESTInterface : GxGenericCollectionItem<SdtSdProdutoNotaFiscal>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdProdutoNotaFiscal_RESTInterface( ) : base()
		{	
		}

		public SdtSdProdutoNotaFiscal_RESTInterface( SdtSdProdutoNotaFiscal psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("cProd")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="cProd", Order=0)]
		public  string gxTpr_Cprod
		{
			get { 
				return sdt.gxTpr_Cprod;

			}
			set { 
				 sdt.gxTpr_Cprod = value;
			}
		}

		[JsonPropertyName("cNfe")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="cNfe", Order=1)]
		public  string gxTpr_Cnfe
		{
			get { 
				return sdt.gxTpr_Cnfe;

			}
			set { 
				 sdt.gxTpr_Cnfe = value;
			}
		}

		[JsonPropertyName("cEAN")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="cEAN", Order=2)]
		public  string gxTpr_Cean
		{
			get { 
				return sdt.gxTpr_Cean;

			}
			set { 
				 sdt.gxTpr_Cean = value;
			}
		}

		[JsonPropertyName("xProd")]
		[JsonPropertyOrder(3)]
		[DataMember(Name="xProd", Order=3)]
		public  string gxTpr_Xprod
		{
			get { 
				return sdt.gxTpr_Xprod;

			}
			set { 
				 sdt.gxTpr_Xprod = value;
			}
		}

		[JsonPropertyName("CFOP")]
		[JsonPropertyOrder(4)]
		[DataMember(Name="CFOP", Order=4)]
		public  string gxTpr_Cfop
		{
			get { 
				return sdt.gxTpr_Cfop;

			}
			set { 
				 sdt.gxTpr_Cfop = value;
			}
		}

		[JsonPropertyName("uCom")]
		[JsonPropertyOrder(5)]
		[DataMember(Name="uCom", Order=5)]
		public  string gxTpr_Ucom
		{
			get { 
				return sdt.gxTpr_Ucom;

			}
			set { 
				 sdt.gxTpr_Ucom = value;
			}
		}

		[JsonPropertyName("qCom")]
		[JsonPropertyOrder(6)]
		[DataMember(Name="qCom", Order=6)]
		public  string gxTpr_Qcom
		{
			get { 
				return sdt.gxTpr_Qcom;

			}
			set { 
				 sdt.gxTpr_Qcom = value;
			}
		}

		[JsonPropertyName("vUnCom")]
		[JsonPropertyOrder(7)]
		[DataMember(Name="vUnCom", Order=7)]
		public  string gxTpr_Vuncom
		{
			get { 
				return sdt.gxTpr_Vuncom;

			}
			set { 
				 sdt.gxTpr_Vuncom = value;
			}
		}

		[JsonPropertyName("vProd")]
		[JsonPropertyOrder(8)]
		[DataMember(Name="vProd", Order=8)]
		public  string gxTpr_Vprod
		{
			get { 
				return sdt.gxTpr_Vprod;

			}
			set { 
				 sdt.gxTpr_Vprod = value;
			}
		}

		[JsonPropertyName("cEANTrib")]
		[JsonPropertyOrder(9)]
		[DataMember(Name="cEANTrib", Order=9)]
		public  string gxTpr_Ceantrib
		{
			get { 
				return sdt.gxTpr_Ceantrib;

			}
			set { 
				 sdt.gxTpr_Ceantrib = value;
			}
		}

		[JsonPropertyName("uTrib")]
		[JsonPropertyOrder(10)]
		[DataMember(Name="uTrib", Order=10)]
		public  string gxTpr_Utrib
		{
			get { 
				return sdt.gxTpr_Utrib;

			}
			set { 
				 sdt.gxTpr_Utrib = value;
			}
		}

		[JsonPropertyName("qTrib")]
		[JsonPropertyOrder(11)]
		[DataMember(Name="qTrib", Order=11)]
		public  string gxTpr_Qtrib
		{
			get { 
				return sdt.gxTpr_Qtrib;

			}
			set { 
				 sdt.gxTpr_Qtrib = value;
			}
		}

		[JsonPropertyName("vUnTrib")]
		[JsonPropertyOrder(12)]
		[DataMember(Name="vUnTrib", Order=12)]
		public  string gxTpr_Vuntrib
		{
			get { 
				return sdt.gxTpr_Vuntrib;

			}
			set { 
				 sdt.gxTpr_Vuntrib = value;
			}
		}

		[JsonPropertyName("IsSel")]
		[JsonPropertyOrder(13)]
		[JsonConverter(typeof(BoolStringJsonConverter))]
		[DataMember(Name="IsSel", Order=13)]
		public bool gxTpr_Issel
		{
			get { 
				return sdt.gxTpr_Issel;

			}
			set { 
				sdt.gxTpr_Issel = value;
			}
		}

		[JsonPropertyName("Id")]
		[JsonPropertyOrder(14)]
		[DataMember(Name="Id", Order=14)]
		public  string gxTpr_Id
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Id, 9, 0));

			}
			set { 
				sdt.gxTpr_Id = (int) NumberUtil.Val( value, ".");
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdProdutoNotaFiscal sdt
		{
			get { 
				return (SdtSdProdutoNotaFiscal)Sdt;
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
				sdt = new SdtSdProdutoNotaFiscal() ;
			}
		}
	}
	#endregion
}