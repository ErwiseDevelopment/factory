/*
				   File: type_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_ICMS00
			Description: ICMS00
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
	[XmlRoot(ElementName="SdNotaFiscal.NFe.infNFe.detItem.imposto.ICMS.ICMS00")]
	[XmlType(TypeName="SdNotaFiscal.NFe.infNFe.detItem.imposto.ICMS.ICMS00" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_ICMS00 : GxUserType
	{
		public SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_ICMS00( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_ICMS00_Orig = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_ICMS00_Cst = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_ICMS00_Modbc = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_ICMS00_Vbc = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_ICMS00_Picms = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_ICMS00_Vicms = "";

		}

		public SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_ICMS00(IGxContext context)
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
			AddObjectProperty("orig", gxTpr_Orig, false);


			AddObjectProperty("CST", gxTpr_Cst, false);


			AddObjectProperty("modBC", gxTpr_Modbc, false);


			AddObjectProperty("vBC", gxTpr_Vbc, false);


			AddObjectProperty("pICMS", gxTpr_Picms, false);


			AddObjectProperty("vICMS", gxTpr_Vicms, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="orig")]
		[XmlElement(ElementName="orig")]
		public string gxTpr_Orig
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_ICMS00_Orig; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_ICMS00_Orig = value;
				SetDirty("Orig");
			}
		}




		[SoapElement(ElementName="CST")]
		[XmlElement(ElementName="CST")]
		public string gxTpr_Cst
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_ICMS00_Cst; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_ICMS00_Cst = value;
				SetDirty("Cst");
			}
		}




		[SoapElement(ElementName="modBC")]
		[XmlElement(ElementName="modBC")]
		public string gxTpr_Modbc
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_ICMS00_Modbc; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_ICMS00_Modbc = value;
				SetDirty("Modbc");
			}
		}




		[SoapElement(ElementName="vBC")]
		[XmlElement(ElementName="vBC")]
		public string gxTpr_Vbc
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_ICMS00_Vbc; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_ICMS00_Vbc = value;
				SetDirty("Vbc");
			}
		}




		[SoapElement(ElementName="pICMS")]
		[XmlElement(ElementName="pICMS")]
		public string gxTpr_Picms
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_ICMS00_Picms; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_ICMS00_Picms = value;
				SetDirty("Picms");
			}
		}




		[SoapElement(ElementName="vICMS")]
		[XmlElement(ElementName="vICMS")]
		public string gxTpr_Vicms
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_ICMS00_Vicms; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_ICMS00_Vicms = value;
				SetDirty("Vicms");
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
			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_ICMS00_Orig = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_ICMS00_Cst = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_ICMS00_Modbc = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_ICMS00_Vbc = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_ICMS00_Picms = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_ICMS00_Vicms = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_ICMS00_Orig;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_ICMS00_Cst;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_ICMS00_Modbc;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_ICMS00_Vbc;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_ICMS00_Picms;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_ICMS00_Vicms;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdNotaFiscal.NFe.infNFe.detItem.imposto.ICMS.ICMS00", Namespace="Factory21")]
	public class SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_ICMS00_RESTInterface : GxGenericCollectionItem<SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_ICMS00>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_ICMS00_RESTInterface( ) : base()
		{	
		}

		public SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_ICMS00_RESTInterface( SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_ICMS00 psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("orig")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="orig", Order=0)]
		public  string gxTpr_Orig
		{
			get { 
				return sdt.gxTpr_Orig;

			}
			set { 
				 sdt.gxTpr_Orig = value;
			}
		}

		[JsonPropertyName("CST")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="CST", Order=1)]
		public  string gxTpr_Cst
		{
			get { 
				return sdt.gxTpr_Cst;

			}
			set { 
				 sdt.gxTpr_Cst = value;
			}
		}

		[JsonPropertyName("modBC")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="modBC", Order=2)]
		public  string gxTpr_Modbc
		{
			get { 
				return sdt.gxTpr_Modbc;

			}
			set { 
				 sdt.gxTpr_Modbc = value;
			}
		}

		[JsonPropertyName("vBC")]
		[JsonPropertyOrder(3)]
		[DataMember(Name="vBC", Order=3)]
		public  string gxTpr_Vbc
		{
			get { 
				return sdt.gxTpr_Vbc;

			}
			set { 
				 sdt.gxTpr_Vbc = value;
			}
		}

		[JsonPropertyName("pICMS")]
		[JsonPropertyOrder(4)]
		[DataMember(Name="pICMS", Order=4)]
		public  string gxTpr_Picms
		{
			get { 
				return sdt.gxTpr_Picms;

			}
			set { 
				 sdt.gxTpr_Picms = value;
			}
		}

		[JsonPropertyName("vICMS")]
		[JsonPropertyOrder(5)]
		[DataMember(Name="vICMS", Order=5)]
		public  string gxTpr_Vicms
		{
			get { 
				return sdt.gxTpr_Vicms;

			}
			set { 
				 sdt.gxTpr_Vicms = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_ICMS00 sdt
		{
			get { 
				return (SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_ICMS00)Sdt;
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
				sdt = new SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_ICMS00() ;
			}
		}
	}
	#endregion
}