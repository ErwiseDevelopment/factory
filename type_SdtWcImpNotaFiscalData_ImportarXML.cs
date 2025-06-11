/*
				   File: type_SdtWcImpNotaFiscalData_ImportarXML
			Description: ImportarXML
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
	[XmlRoot(ElementName="WcImpNotaFiscalData.ImportarXML")]
	[XmlType(TypeName="WcImpNotaFiscalData.ImportarXML" , Namespace="Factory21" )]
	[Serializable]
	public class SdtWcImpNotaFiscalData_ImportarXML : GxUserType
	{
		public SdtWcImpNotaFiscalData_ImportarXML( )
		{
			/* Constructor for serialization */
			gxTv_SdtWcImpNotaFiscalData_ImportarXML_Jsonsdnotafiscal = "";

			gxTv_SdtWcImpNotaFiscalData_ImportarXML_Jsonsdprodutosnota = "";

			gxTv_SdtWcImpNotaFiscalData_ImportarXML_Jsonbase64arquivos = "";


		}

		public SdtWcImpNotaFiscalData_ImportarXML(IGxContext context)
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
			AddObjectProperty("JSONSdNotaFiscal", gxTpr_Jsonsdnotafiscal, false);


			AddObjectProperty("JSONSdProdutosNota", gxTpr_Jsonsdprodutosnota, false);


			AddObjectProperty("JSONBase64Arquivos", gxTpr_Jsonbase64arquivos, false);


			AddObjectProperty("ClienteId", gxTpr_Clienteid, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="JSONSdNotaFiscal")]
		[XmlElement(ElementName="JSONSdNotaFiscal")]
		public string gxTpr_Jsonsdnotafiscal
		{
			get {
				return gxTv_SdtWcImpNotaFiscalData_ImportarXML_Jsonsdnotafiscal; 
			}
			set {
				gxTv_SdtWcImpNotaFiscalData_ImportarXML_Jsonsdnotafiscal = value;
				SetDirty("Jsonsdnotafiscal");
			}
		}




		[SoapElement(ElementName="JSONSdProdutosNota")]
		[XmlElement(ElementName="JSONSdProdutosNota")]
		public string gxTpr_Jsonsdprodutosnota
		{
			get {
				return gxTv_SdtWcImpNotaFiscalData_ImportarXML_Jsonsdprodutosnota; 
			}
			set {
				gxTv_SdtWcImpNotaFiscalData_ImportarXML_Jsonsdprodutosnota = value;
				SetDirty("Jsonsdprodutosnota");
			}
		}




		[SoapElement(ElementName="JSONBase64Arquivos")]
		[XmlElement(ElementName="JSONBase64Arquivos")]
		public string gxTpr_Jsonbase64arquivos
		{
			get {
				return gxTv_SdtWcImpNotaFiscalData_ImportarXML_Jsonbase64arquivos; 
			}
			set {
				gxTv_SdtWcImpNotaFiscalData_ImportarXML_Jsonbase64arquivos = value;
				SetDirty("Jsonbase64arquivos");
			}
		}




		[SoapElement(ElementName="ClienteId")]
		[XmlElement(ElementName="ClienteId")]
		public int gxTpr_Clienteid
		{
			get {
				return gxTv_SdtWcImpNotaFiscalData_ImportarXML_Clienteid; 
			}
			set {
				gxTv_SdtWcImpNotaFiscalData_ImportarXML_Clienteid = value;
				SetDirty("Clienteid");
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
			gxTv_SdtWcImpNotaFiscalData_ImportarXML_Jsonsdnotafiscal = "";
			gxTv_SdtWcImpNotaFiscalData_ImportarXML_Jsonsdprodutosnota = "";
			gxTv_SdtWcImpNotaFiscalData_ImportarXML_Jsonbase64arquivos = "";

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtWcImpNotaFiscalData_ImportarXML_Jsonsdnotafiscal;
		 

		protected string gxTv_SdtWcImpNotaFiscalData_ImportarXML_Jsonsdprodutosnota;
		 

		protected string gxTv_SdtWcImpNotaFiscalData_ImportarXML_Jsonbase64arquivos;
		 

		protected int gxTv_SdtWcImpNotaFiscalData_ImportarXML_Clienteid;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WcImpNotaFiscalData.ImportarXML", Namespace="Factory21")]
	public class SdtWcImpNotaFiscalData_ImportarXML_RESTInterface : GxGenericCollectionItem<SdtWcImpNotaFiscalData_ImportarXML>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWcImpNotaFiscalData_ImportarXML_RESTInterface( ) : base()
		{	
		}

		public SdtWcImpNotaFiscalData_ImportarXML_RESTInterface( SdtWcImpNotaFiscalData_ImportarXML psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("JSONSdNotaFiscal")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="JSONSdNotaFiscal", Order=0)]
		public  string gxTpr_Jsonsdnotafiscal
		{
			get { 
				return sdt.gxTpr_Jsonsdnotafiscal;

			}
			set { 
				 sdt.gxTpr_Jsonsdnotafiscal = value;
			}
		}

		[JsonPropertyName("JSONSdProdutosNota")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="JSONSdProdutosNota", Order=1)]
		public  string gxTpr_Jsonsdprodutosnota
		{
			get { 
				return sdt.gxTpr_Jsonsdprodutosnota;

			}
			set { 
				 sdt.gxTpr_Jsonsdprodutosnota = value;
			}
		}

		[JsonPropertyName("JSONBase64Arquivos")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="JSONBase64Arquivos", Order=2)]
		public  string gxTpr_Jsonbase64arquivos
		{
			get { 
				return sdt.gxTpr_Jsonbase64arquivos;

			}
			set { 
				 sdt.gxTpr_Jsonbase64arquivos = value;
			}
		}

		[JsonPropertyName("ClienteId")]
		[JsonPropertyOrder(3)]
		[DataMember(Name="ClienteId", Order=3)]
		public  string gxTpr_Clienteid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Clienteid, 9, 0));

			}
			set { 
				sdt.gxTpr_Clienteid = (int) NumberUtil.Val( value, ".");
			}
		}


		#endregion
		[JsonIgnore]
		public SdtWcImpNotaFiscalData_ImportarXML sdt
		{
			get { 
				return (SdtWcImpNotaFiscalData_ImportarXML)Sdt;
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
				sdt = new SdtWcImpNotaFiscalData_ImportarXML() ;
			}
		}
	}
	#endregion
}