/*
				   File: type_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_COFINSAliq
			Description: COFINSAliq
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
	[XmlRoot(ElementName="SdNotaFiscal.NFe.infNFe.detItem.imposto.COFINS.COFINSAliq")]
	[XmlType(TypeName="SdNotaFiscal.NFe.infNFe.detItem.imposto.COFINS.COFINSAliq" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_COFINSAliq : GxUserType
	{
		public SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_COFINSAliq( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_COFINSAliq_Cst = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_COFINSAliq_Vbc = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_COFINSAliq_Pcofins = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_COFINSAliq_Vcofins = "";

		}

		public SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_COFINSAliq(IGxContext context)
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


			AddObjectProperty("pCOFINS", gxTpr_Pcofins, false);


			AddObjectProperty("vCOFINS", gxTpr_Vcofins, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="CST")]
		[XmlElement(ElementName="CST")]
		public string gxTpr_Cst
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_COFINSAliq_Cst; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_COFINSAliq_Cst = value;
				SetDirty("Cst");
			}
		}




		[SoapElement(ElementName="vBC")]
		[XmlElement(ElementName="vBC")]
		public string gxTpr_Vbc
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_COFINSAliq_Vbc; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_COFINSAliq_Vbc = value;
				SetDirty("Vbc");
			}
		}




		[SoapElement(ElementName="pCOFINS")]
		[XmlElement(ElementName="pCOFINS")]
		public string gxTpr_Pcofins
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_COFINSAliq_Pcofins; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_COFINSAliq_Pcofins = value;
				SetDirty("Pcofins");
			}
		}




		[SoapElement(ElementName="vCOFINS")]
		[XmlElement(ElementName="vCOFINS")]
		public string gxTpr_Vcofins
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_COFINSAliq_Vcofins; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_COFINSAliq_Vcofins = value;
				SetDirty("Vcofins");
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
			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_COFINSAliq_Cst = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_COFINSAliq_Vbc = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_COFINSAliq_Pcofins = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_COFINSAliq_Vcofins = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_COFINSAliq_Cst;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_COFINSAliq_Vbc;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_COFINSAliq_Pcofins;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_COFINSAliq_Vcofins;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdNotaFiscal.NFe.infNFe.detItem.imposto.COFINS.COFINSAliq", Namespace="Factory21")]
	public class SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_COFINSAliq_RESTInterface : GxGenericCollectionItem<SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_COFINSAliq>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_COFINSAliq_RESTInterface( ) : base()
		{	
		}

		public SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_COFINSAliq_RESTInterface( SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_COFINSAliq psdt ) : base(psdt)
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

		[JsonPropertyName("pCOFINS")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="pCOFINS", Order=2)]
		public  string gxTpr_Pcofins
		{
			get { 
				return sdt.gxTpr_Pcofins;

			}
			set { 
				 sdt.gxTpr_Pcofins = value;
			}
		}

		[JsonPropertyName("vCOFINS")]
		[JsonPropertyOrder(3)]
		[DataMember(Name="vCOFINS", Order=3)]
		public  string gxTpr_Vcofins
		{
			get { 
				return sdt.gxTpr_Vcofins;

			}
			set { 
				 sdt.gxTpr_Vcofins = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_COFINSAliq sdt
		{
			get { 
				return (SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_COFINSAliq)Sdt;
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
				sdt = new SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_COFINSAliq() ;
			}
		}
	}
	#endregion
}