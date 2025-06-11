/*
				   File: type_SdtSdNotaFiscal_NFe_infNFe_entrega
			Description: entrega
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
	[XmlRoot(ElementName="SdNotaFiscal.NFe.infNFe.entrega")]
	[XmlType(TypeName="SdNotaFiscal.NFe.infNFe.entrega" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdNotaFiscal_NFe_infNFe_entrega : GxUserType
	{
		public SdtSdNotaFiscal_NFe_infNFe_entrega( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdNotaFiscal_NFe_infNFe_entrega_Cnpj = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_entrega_Xlgr = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_entrega_Nro = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_entrega_Xcpl = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_entrega_Xbairro = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_entrega_Cmun = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_entrega_Xmun = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_entrega_Uf = "";

		}

		public SdtSdNotaFiscal_NFe_infNFe_entrega(IGxContext context)
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


			AddObjectProperty("xLgr", gxTpr_Xlgr, false);


			AddObjectProperty("nro", gxTpr_Nro, false);


			AddObjectProperty("xCpl", gxTpr_Xcpl, false);


			AddObjectProperty("xBairro", gxTpr_Xbairro, false);


			AddObjectProperty("cMun", gxTpr_Cmun, false);


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
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_entrega_Cnpj; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_entrega_Cnpj = value;
				SetDirty("Cnpj");
			}
		}




		[SoapElement(ElementName="xLgr")]
		[XmlElement(ElementName="xLgr")]
		public string gxTpr_Xlgr
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_entrega_Xlgr; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_entrega_Xlgr = value;
				SetDirty("Xlgr");
			}
		}




		[SoapElement(ElementName="nro")]
		[XmlElement(ElementName="nro")]
		public string gxTpr_Nro
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_entrega_Nro; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_entrega_Nro = value;
				SetDirty("Nro");
			}
		}




		[SoapElement(ElementName="xCpl")]
		[XmlElement(ElementName="xCpl")]
		public string gxTpr_Xcpl
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_entrega_Xcpl; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_entrega_Xcpl = value;
				SetDirty("Xcpl");
			}
		}




		[SoapElement(ElementName="xBairro")]
		[XmlElement(ElementName="xBairro")]
		public string gxTpr_Xbairro
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_entrega_Xbairro; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_entrega_Xbairro = value;
				SetDirty("Xbairro");
			}
		}




		[SoapElement(ElementName="cMun")]
		[XmlElement(ElementName="cMun")]
		public string gxTpr_Cmun
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_entrega_Cmun; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_entrega_Cmun = value;
				SetDirty("Cmun");
			}
		}




		[SoapElement(ElementName="xMun")]
		[XmlElement(ElementName="xMun")]
		public string gxTpr_Xmun
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_entrega_Xmun; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_entrega_Xmun = value;
				SetDirty("Xmun");
			}
		}




		[SoapElement(ElementName="UF")]
		[XmlElement(ElementName="UF")]
		public string gxTpr_Uf
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_entrega_Uf; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_entrega_Uf = value;
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
			gxTv_SdtSdNotaFiscal_NFe_infNFe_entrega_Cnpj = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_entrega_Xlgr = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_entrega_Nro = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_entrega_Xcpl = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_entrega_Xbairro = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_entrega_Cmun = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_entrega_Xmun = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_entrega_Uf = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_entrega_Cnpj;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_entrega_Xlgr;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_entrega_Nro;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_entrega_Xcpl;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_entrega_Xbairro;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_entrega_Cmun;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_entrega_Xmun;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_entrega_Uf;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdNotaFiscal.NFe.infNFe.entrega", Namespace="Factory21")]
	public class SdtSdNotaFiscal_NFe_infNFe_entrega_RESTInterface : GxGenericCollectionItem<SdtSdNotaFiscal_NFe_infNFe_entrega>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdNotaFiscal_NFe_infNFe_entrega_RESTInterface( ) : base()
		{	
		}

		public SdtSdNotaFiscal_NFe_infNFe_entrega_RESTInterface( SdtSdNotaFiscal_NFe_infNFe_entrega psdt ) : base(psdt)
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

		[JsonPropertyName("xLgr")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="xLgr", Order=1)]
		public  string gxTpr_Xlgr
		{
			get { 
				return sdt.gxTpr_Xlgr;

			}
			set { 
				 sdt.gxTpr_Xlgr = value;
			}
		}

		[JsonPropertyName("nro")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="nro", Order=2)]
		public  string gxTpr_Nro
		{
			get { 
				return sdt.gxTpr_Nro;

			}
			set { 
				 sdt.gxTpr_Nro = value;
			}
		}

		[JsonPropertyName("xCpl")]
		[JsonPropertyOrder(3)]
		[DataMember(Name="xCpl", Order=3)]
		public  string gxTpr_Xcpl
		{
			get { 
				return sdt.gxTpr_Xcpl;

			}
			set { 
				 sdt.gxTpr_Xcpl = value;
			}
		}

		[JsonPropertyName("xBairro")]
		[JsonPropertyOrder(4)]
		[DataMember(Name="xBairro", Order=4)]
		public  string gxTpr_Xbairro
		{
			get { 
				return sdt.gxTpr_Xbairro;

			}
			set { 
				 sdt.gxTpr_Xbairro = value;
			}
		}

		[JsonPropertyName("cMun")]
		[JsonPropertyOrder(5)]
		[DataMember(Name="cMun", Order=5)]
		public  string gxTpr_Cmun
		{
			get { 
				return sdt.gxTpr_Cmun;

			}
			set { 
				 sdt.gxTpr_Cmun = value;
			}
		}

		[JsonPropertyName("xMun")]
		[JsonPropertyOrder(6)]
		[DataMember(Name="xMun", Order=6)]
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
		[JsonPropertyOrder(7)]
		[DataMember(Name="UF", Order=7)]
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
		public SdtSdNotaFiscal_NFe_infNFe_entrega sdt
		{
			get { 
				return (SdtSdNotaFiscal_NFe_infNFe_entrega)Sdt;
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
				sdt = new SdtSdNotaFiscal_NFe_infNFe_entrega() ;
			}
		}
	}
	#endregion
}