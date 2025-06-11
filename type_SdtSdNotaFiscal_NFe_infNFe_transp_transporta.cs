/*
				   File: type_SdtSdNotaFiscal_NFe_infNFe_transp_transporta
			Description: transporta
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
	[XmlRoot(ElementName="SdNotaFiscal.NFe.infNFe.transp.transporta")]
	[XmlType(TypeName="SdNotaFiscal.NFe.infNFe.transp.transporta" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdNotaFiscal_NFe_infNFe_transp_transporta : GxUserType
	{
		public SdtSdNotaFiscal_NFe_infNFe_transp_transporta( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_transporta_Cnpj = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_transporta_Xnome = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_transporta_Ie = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_transporta_Xender = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_transporta_Xmun = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_transporta_Uf = "";

		}

		public SdtSdNotaFiscal_NFe_infNFe_transp_transporta(IGxContext context)
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
			AddObjectProperty("CNPJ", gxTpr_Cnpj, false);


			AddObjectProperty("xNome", gxTpr_Xnome, false);


			AddObjectProperty("IE", gxTpr_Ie, false);


			AddObjectProperty("xEnder", gxTpr_Xender, false);


			AddObjectProperty("xMun", gxTpr_Xmun, false);


			AddObjectProperty("UF", gxTpr_Uf, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="CNPJ")]
		[XmlElement(ElementName="CNPJ")]
		public string gxTpr_Cnpj
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_transporta_Cnpj; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_transporta_Cnpj = value;
				SetDirty("Cnpj");
			}
		}




		[SoapElement(ElementName="xNome")]
		[XmlElement(ElementName="xNome")]
		public string gxTpr_Xnome
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_transporta_Xnome; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_transporta_Xnome = value;
				SetDirty("Xnome");
			}
		}




		[SoapElement(ElementName="IE")]
		[XmlElement(ElementName="IE")]
		public string gxTpr_Ie
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_transporta_Ie; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_transporta_Ie = value;
				SetDirty("Ie");
			}
		}




		[SoapElement(ElementName="xEnder")]
		[XmlElement(ElementName="xEnder")]
		public string gxTpr_Xender
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_transporta_Xender; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_transporta_Xender = value;
				SetDirty("Xender");
			}
		}




		[SoapElement(ElementName="xMun")]
		[XmlElement(ElementName="xMun")]
		public string gxTpr_Xmun
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_transporta_Xmun; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_transporta_Xmun = value;
				SetDirty("Xmun");
			}
		}




		[SoapElement(ElementName="UF")]
		[XmlElement(ElementName="UF")]
		public string gxTpr_Uf
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_transporta_Uf; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_transporta_Uf = value;
				SetDirty("Uf");
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
			gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_transporta_Cnpj = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_transporta_Xnome = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_transporta_Ie = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_transporta_Xender = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_transporta_Xmun = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_transporta_Uf = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_transporta_Cnpj;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_transporta_Xnome;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_transporta_Ie;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_transporta_Xender;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_transporta_Xmun;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_transporta_Uf;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdNotaFiscal.NFe.infNFe.transp.transporta", Namespace="Factory21")]
	public class SdtSdNotaFiscal_NFe_infNFe_transp_transporta_RESTInterface : GxGenericCollectionItem<SdtSdNotaFiscal_NFe_infNFe_transp_transporta>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdNotaFiscal_NFe_infNFe_transp_transporta_RESTInterface( ) : base()
		{	
		}

		public SdtSdNotaFiscal_NFe_infNFe_transp_transporta_RESTInterface( SdtSdNotaFiscal_NFe_infNFe_transp_transporta psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("CNPJ")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="CNPJ", Order=0)]
		public  string gxTpr_Cnpj
		{
			get { 
				return sdt.gxTpr_Cnpj;

			}
			set { 
				 sdt.gxTpr_Cnpj = value;
			}
		}

		[JsonPropertyName("xNome")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="xNome", Order=1)]
		public  string gxTpr_Xnome
		{
			get { 
				return sdt.gxTpr_Xnome;

			}
			set { 
				 sdt.gxTpr_Xnome = value;
			}
		}

		[JsonPropertyName("IE")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="IE", Order=2)]
		public  string gxTpr_Ie
		{
			get { 
				return sdt.gxTpr_Ie;

			}
			set { 
				 sdt.gxTpr_Ie = value;
			}
		}

		[JsonPropertyName("xEnder")]
		[JsonPropertyOrder(3)]
		[DataMember(Name="xEnder", Order=3)]
		public  string gxTpr_Xender
		{
			get { 
				return sdt.gxTpr_Xender;

			}
			set { 
				 sdt.gxTpr_Xender = value;
			}
		}

		[JsonPropertyName("xMun")]
		[JsonPropertyOrder(4)]
		[DataMember(Name="xMun", Order=4)]
		public  string gxTpr_Xmun
		{
			get { 
				return sdt.gxTpr_Xmun;

			}
			set { 
				 sdt.gxTpr_Xmun = value;
			}
		}

		[JsonPropertyName("UF")]
		[JsonPropertyOrder(5)]
		[DataMember(Name="UF", Order=5)]
		public  string gxTpr_Uf
		{
			get { 
				return sdt.gxTpr_Uf;

			}
			set { 
				 sdt.gxTpr_Uf = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdNotaFiscal_NFe_infNFe_transp_transporta sdt
		{
			get { 
				return (SdtSdNotaFiscal_NFe_infNFe_transp_transporta)Sdt;
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
				sdt = new SdtSdNotaFiscal_NFe_infNFe_transp_transporta() ;
			}
		}
	}
	#endregion
}