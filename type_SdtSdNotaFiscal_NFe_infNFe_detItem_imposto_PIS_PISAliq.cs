/*
				   File: type_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_PISAliq
			Description: PISAliq
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
	[XmlRoot(ElementName="SdNotaFiscal.NFe.infNFe.detItem.imposto.PIS.PISAliq")]
	[XmlType(TypeName="SdNotaFiscal.NFe.infNFe.detItem.imposto.PIS.PISAliq" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_PISAliq : GxUserType
	{
		public SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_PISAliq( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_PISAliq_Cst = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_PISAliq_Vbc = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_PISAliq_Ppis = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_PISAliq_Vpis = "";

		}

		public SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_PISAliq(IGxContext context)
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
			AddObjectProperty("CST", gxTpr_Cst, false);


			AddObjectProperty("vBC", gxTpr_Vbc, false);


			AddObjectProperty("pPIS", gxTpr_Ppis, false);


			AddObjectProperty("vPIS", gxTpr_Vpis, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="CST")]
		[XmlElement(ElementName="CST")]
		public string gxTpr_Cst
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_PISAliq_Cst; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_PISAliq_Cst = value;
				SetDirty("Cst");
			}
		}




		[SoapElement(ElementName="vBC")]
		[XmlElement(ElementName="vBC")]
		public string gxTpr_Vbc
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_PISAliq_Vbc; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_PISAliq_Vbc = value;
				SetDirty("Vbc");
			}
		}




		[SoapElement(ElementName="pPIS")]
		[XmlElement(ElementName="pPIS")]
		public string gxTpr_Ppis
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_PISAliq_Ppis; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_PISAliq_Ppis = value;
				SetDirty("Ppis");
			}
		}




		[SoapElement(ElementName="vPIS")]
		[XmlElement(ElementName="vPIS")]
		public string gxTpr_Vpis
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_PISAliq_Vpis; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_PISAliq_Vpis = value;
				SetDirty("Vpis");
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
			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_PISAliq_Cst = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_PISAliq_Vbc = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_PISAliq_Ppis = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_PISAliq_Vpis = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_PISAliq_Cst;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_PISAliq_Vbc;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_PISAliq_Ppis;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_PISAliq_Vpis;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdNotaFiscal.NFe.infNFe.detItem.imposto.PIS.PISAliq", Namespace="Factory21")]
	public class SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_PISAliq_RESTInterface : GxGenericCollectionItem<SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_PISAliq>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_PISAliq_RESTInterface( ) : base()
		{	
		}

		public SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_PISAliq_RESTInterface( SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_PISAliq psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("CST")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="CST", Order=0)]
		public  string gxTpr_Cst
		{
			get { 
				return sdt.gxTpr_Cst;

			}
			set { 
				 sdt.gxTpr_Cst = value;
			}
		}

		[JsonPropertyName("vBC")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="vBC", Order=1)]
		public  string gxTpr_Vbc
		{
			get { 
				return sdt.gxTpr_Vbc;

			}
			set { 
				 sdt.gxTpr_Vbc = value;
			}
		}

		[JsonPropertyName("pPIS")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="pPIS", Order=2)]
		public  string gxTpr_Ppis
		{
			get { 
				return sdt.gxTpr_Ppis;

			}
			set { 
				 sdt.gxTpr_Ppis = value;
			}
		}

		[JsonPropertyName("vPIS")]
		[JsonPropertyOrder(3)]
		[DataMember(Name="vPIS", Order=3)]
		public  string gxTpr_Vpis
		{
			get { 
				return sdt.gxTpr_Vpis;

			}
			set { 
				 sdt.gxTpr_Vpis = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_PISAliq sdt
		{
			get { 
				return (SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_PISAliq)Sdt;
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
				sdt = new SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_PISAliq() ;
			}
		}
	}
	#endregion
}