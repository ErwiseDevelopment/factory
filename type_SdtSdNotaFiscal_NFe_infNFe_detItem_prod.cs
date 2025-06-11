/*
				   File: type_SdtSdNotaFiscal_NFe_infNFe_detItem_prod
			Description: prod
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
	[XmlRoot(ElementName="SdNotaFiscal.NFe.infNFe.detItem.prod")]
	[XmlType(TypeName="SdNotaFiscal.NFe.infNFe.detItem.prod" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdNotaFiscal_NFe_infNFe_detItem_prod : GxUserType
	{
		public SdtSdNotaFiscal_NFe_infNFe_detItem_prod( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Cprod = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Cean = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Ncm = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Xprod = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Cfop = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Ucom = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Qcom = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Vuncom = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Vprod = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Ceantrib = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Utrib = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Qtrib = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Vuntrib = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Vfrete = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Vdesc = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Indtot = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Xped = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Nitemped = "";

		}

		public SdtSdNotaFiscal_NFe_infNFe_detItem_prod(IGxContext context)
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


			AddObjectProperty("cEAN", gxTpr_Cean, false);


			AddObjectProperty("NCM", gxTpr_Ncm, false);


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


			AddObjectProperty("vFrete", gxTpr_Vfrete, false);


			AddObjectProperty("vDesc", gxTpr_Vdesc, false);


			AddObjectProperty("indTot", gxTpr_Indtot, false);


			AddObjectProperty("xPed", gxTpr_Xped, false);


			AddObjectProperty("nItemPed", gxTpr_Nitemped, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="cProd")]
		[XmlElement(ElementName="cProd")]
		public string gxTpr_Cprod
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Cprod; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Cprod = value;
				SetDirty("Cprod");
			}
		}




		[SoapElement(ElementName="cEAN")]
		[XmlElement(ElementName="cEAN")]
		public string gxTpr_Cean
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Cean; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Cean = value;
				SetDirty("Cean");
			}
		}




		[SoapElement(ElementName="NCM")]
		[XmlElement(ElementName="NCM")]
		public string gxTpr_Ncm
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Ncm; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Ncm = value;
				SetDirty("Ncm");
			}
		}




		[SoapElement(ElementName="xProd")]
		[XmlElement(ElementName="xProd")]
		public string gxTpr_Xprod
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Xprod; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Xprod = value;
				SetDirty("Xprod");
			}
		}




		[SoapElement(ElementName="CFOP")]
		[XmlElement(ElementName="CFOP")]
		public string gxTpr_Cfop
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Cfop; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Cfop = value;
				SetDirty("Cfop");
			}
		}




		[SoapElement(ElementName="uCom")]
		[XmlElement(ElementName="uCom")]
		public string gxTpr_Ucom
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Ucom; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Ucom = value;
				SetDirty("Ucom");
			}
		}




		[SoapElement(ElementName="qCom")]
		[XmlElement(ElementName="qCom")]
		public string gxTpr_Qcom
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Qcom; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Qcom = value;
				SetDirty("Qcom");
			}
		}




		[SoapElement(ElementName="vUnCom")]
		[XmlElement(ElementName="vUnCom")]
		public string gxTpr_Vuncom
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Vuncom; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Vuncom = value;
				SetDirty("Vuncom");
			}
		}




		[SoapElement(ElementName="vProd")]
		[XmlElement(ElementName="vProd")]
		public string gxTpr_Vprod
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Vprod; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Vprod = value;
				SetDirty("Vprod");
			}
		}




		[SoapElement(ElementName="cEANTrib")]
		[XmlElement(ElementName="cEANTrib")]
		public string gxTpr_Ceantrib
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Ceantrib; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Ceantrib = value;
				SetDirty("Ceantrib");
			}
		}




		[SoapElement(ElementName="uTrib")]
		[XmlElement(ElementName="uTrib")]
		public string gxTpr_Utrib
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Utrib; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Utrib = value;
				SetDirty("Utrib");
			}
		}




		[SoapElement(ElementName="qTrib")]
		[XmlElement(ElementName="qTrib")]
		public string gxTpr_Qtrib
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Qtrib; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Qtrib = value;
				SetDirty("Qtrib");
			}
		}




		[SoapElement(ElementName="vUnTrib")]
		[XmlElement(ElementName="vUnTrib")]
		public string gxTpr_Vuntrib
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Vuntrib; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Vuntrib = value;
				SetDirty("Vuntrib");
			}
		}




		[SoapElement(ElementName="IsSel")]
		[XmlElement(ElementName="IsSel")]
		public bool gxTpr_Issel
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Issel; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Issel = value;
				SetDirty("Issel");
			}
		}




		[SoapElement(ElementName="vFrete")]
		[XmlElement(ElementName="vFrete")]
		public string gxTpr_Vfrete
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Vfrete; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Vfrete = value;
				SetDirty("Vfrete");
			}
		}




		[SoapElement(ElementName="vDesc")]
		[XmlElement(ElementName="vDesc")]
		public string gxTpr_Vdesc
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Vdesc; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Vdesc = value;
				SetDirty("Vdesc");
			}
		}




		[SoapElement(ElementName="indTot")]
		[XmlElement(ElementName="indTot")]
		public string gxTpr_Indtot
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Indtot; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Indtot = value;
				SetDirty("Indtot");
			}
		}




		[SoapElement(ElementName="xPed")]
		[XmlElement(ElementName="xPed")]
		public string gxTpr_Xped
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Xped; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Xped = value;
				SetDirty("Xped");
			}
		}




		[SoapElement(ElementName="nItemPed")]
		[XmlElement(ElementName="nItemPed")]
		public string gxTpr_Nitemped
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Nitemped; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Nitemped = value;
				SetDirty("Nitemped");
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
			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Cprod = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Cean = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Ncm = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Xprod = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Cfop = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Ucom = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Qcom = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Vuncom = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Vprod = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Ceantrib = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Utrib = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Qtrib = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Vuntrib = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Vfrete = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Vdesc = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Indtot = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Xped = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Nitemped = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Cprod;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Cean;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Ncm;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Xprod;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Cfop;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Ucom;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Qcom;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Vuncom;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Vprod;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Ceantrib;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Utrib;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Qtrib;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Vuntrib;
		 

		protected bool gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Issel;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Vfrete;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Vdesc;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Indtot;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Xped;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_prod_Nitemped;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdNotaFiscal.NFe.infNFe.detItem.prod", Namespace="Factory21")]
	public class SdtSdNotaFiscal_NFe_infNFe_detItem_prod_RESTInterface : GxGenericCollectionItem<SdtSdNotaFiscal_NFe_infNFe_detItem_prod>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdNotaFiscal_NFe_infNFe_detItem_prod_RESTInterface( ) : base()
		{	
		}

		public SdtSdNotaFiscal_NFe_infNFe_detItem_prod_RESTInterface( SdtSdNotaFiscal_NFe_infNFe_detItem_prod psdt ) : base(psdt)
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

		[JsonPropertyName("cEAN")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="cEAN", Order=1)]
		public  string gxTpr_Cean
		{
			get { 
				return sdt.gxTpr_Cean;

			}
			set { 
				 sdt.gxTpr_Cean = value;
			}
		}

		[JsonPropertyName("NCM")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="NCM", Order=2)]
		public  string gxTpr_Ncm
		{
			get { 
				return sdt.gxTpr_Ncm;

			}
			set { 
				 sdt.gxTpr_Ncm = value;
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

		[JsonPropertyName("vFrete")]
		[JsonPropertyOrder(14)]
		[DataMember(Name="vFrete", Order=14)]
		public  string gxTpr_Vfrete
		{
			get { 
				return sdt.gxTpr_Vfrete;

			}
			set { 
				 sdt.gxTpr_Vfrete = value;
			}
		}

		[JsonPropertyName("vDesc")]
		[JsonPropertyOrder(15)]
		[DataMember(Name="vDesc", Order=15)]
		public  string gxTpr_Vdesc
		{
			get { 
				return sdt.gxTpr_Vdesc;

			}
			set { 
				 sdt.gxTpr_Vdesc = value;
			}
		}

		[JsonPropertyName("indTot")]
		[JsonPropertyOrder(16)]
		[DataMember(Name="indTot", Order=16)]
		public  string gxTpr_Indtot
		{
			get { 
				return sdt.gxTpr_Indtot;

			}
			set { 
				 sdt.gxTpr_Indtot = value;
			}
		}

		[JsonPropertyName("xPed")]
		[JsonPropertyOrder(17)]
		[DataMember(Name="xPed", Order=17)]
		public  string gxTpr_Xped
		{
			get { 
				return sdt.gxTpr_Xped;

			}
			set { 
				 sdt.gxTpr_Xped = value;
			}
		}

		[JsonPropertyName("nItemPed")]
		[JsonPropertyOrder(18)]
		[DataMember(Name="nItemPed", Order=18)]
		public  string gxTpr_Nitemped
		{
			get { 
				return sdt.gxTpr_Nitemped;

			}
			set { 
				 sdt.gxTpr_Nitemped = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdNotaFiscal_NFe_infNFe_detItem_prod sdt
		{
			get { 
				return (SdtSdNotaFiscal_NFe_infNFe_detItem_prod)Sdt;
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
				sdt = new SdtSdNotaFiscal_NFe_infNFe_detItem_prod() ;
			}
		}
	}
	#endregion
}