/*
				   File: type_SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit
			Description: enderEmit
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
	[XmlRoot(ElementName="SdNotaFiscal.NFe.infNFe.emit.enderEmit")]
	[XmlType(TypeName="SdNotaFiscal.NFe.infNFe.emit.enderEmit" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit : GxUserType
	{
		public SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_Xlgr = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_Nro = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_Xcpl = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_Xbairro = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_Cmun = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_Xmun = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_Uf = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_Cep = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_Cpais = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_Xpais = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_Fone = "";

		}

		public SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit(IGxContext context)
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
			AddObjectProperty("xLgr", gxTpr_Xlgr, false);


			AddObjectProperty("nro", gxTpr_Nro, false);


			AddObjectProperty("xCpl", gxTpr_Xcpl, false);


			AddObjectProperty("xBairro", gxTpr_Xbairro, false);


			AddObjectProperty("cMun", gxTpr_Cmun, false);


			AddObjectProperty("xMun", gxTpr_Xmun, false);


			AddObjectProperty("UF", gxTpr_Uf, false);


			AddObjectProperty("CEP", gxTpr_Cep, false);


			AddObjectProperty("cPais", gxTpr_Cpais, false);


			AddObjectProperty("xPais", gxTpr_Xpais, false);


			AddObjectProperty("fone", gxTpr_Fone, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="xLgr")]
		[XmlElement(ElementName="xLgr")]
		public string gxTpr_Xlgr
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_Xlgr; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_Xlgr = value;
				SetDirty("Xlgr");
			}
		}




		[SoapElement(ElementName="nro")]
		[XmlElement(ElementName="nro")]
		public string gxTpr_Nro
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_Nro; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_Nro = value;
				SetDirty("Nro");
			}
		}




		[SoapElement(ElementName="xCpl")]
		[XmlElement(ElementName="xCpl")]
		public string gxTpr_Xcpl
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_Xcpl; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_Xcpl = value;
				SetDirty("Xcpl");
			}
		}




		[SoapElement(ElementName="xBairro")]
		[XmlElement(ElementName="xBairro")]
		public string gxTpr_Xbairro
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_Xbairro; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_Xbairro = value;
				SetDirty("Xbairro");
			}
		}




		[SoapElement(ElementName="cMun")]
		[XmlElement(ElementName="cMun")]
		public string gxTpr_Cmun
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_Cmun; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_Cmun = value;
				SetDirty("Cmun");
			}
		}




		[SoapElement(ElementName="xMun")]
		[XmlElement(ElementName="xMun")]
		public string gxTpr_Xmun
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_Xmun; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_Xmun = value;
				SetDirty("Xmun");
			}
		}




		[SoapElement(ElementName="UF")]
		[XmlElement(ElementName="UF")]
		public string gxTpr_Uf
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_Uf; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_Uf = value;
				SetDirty("Uf");
			}
		}




		[SoapElement(ElementName="CEP")]
		[XmlElement(ElementName="CEP")]
		public string gxTpr_Cep
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_Cep; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_Cep = value;
				SetDirty("Cep");
			}
		}




		[SoapElement(ElementName="cPais")]
		[XmlElement(ElementName="cPais")]
		public string gxTpr_Cpais
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_Cpais; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_Cpais = value;
				SetDirty("Cpais");
			}
		}




		[SoapElement(ElementName="xPais")]
		[XmlElement(ElementName="xPais")]
		public string gxTpr_Xpais
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_Xpais; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_Xpais = value;
				SetDirty("Xpais");
			}
		}




		[SoapElement(ElementName="fone")]
		[XmlElement(ElementName="fone")]
		public string gxTpr_Fone
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_Fone; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_Fone = value;
				SetDirty("Fone");
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
			gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_Xlgr = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_Nro = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_Xcpl = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_Xbairro = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_Cmun = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_Xmun = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_Uf = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_Cep = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_Cpais = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_Xpais = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_Fone = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_Xlgr;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_Nro;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_Xcpl;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_Xbairro;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_Cmun;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_Xmun;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_Uf;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_Cep;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_Cpais;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_Xpais;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_Fone;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdNotaFiscal.NFe.infNFe.emit.enderEmit", Namespace="Factory21")]
	public class SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_RESTInterface : GxGenericCollectionItem<SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_RESTInterface( ) : base()
		{	
		}

		public SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit_RESTInterface( SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("xLgr")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="xLgr", Order=0)]
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
		[JsonPropertyOrder(1)]
		[DataMember(Name="nro", Order=1)]
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
		[JsonPropertyOrder(2)]
		[DataMember(Name="xCpl", Order=2)]
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
		[JsonPropertyOrder(3)]
		[DataMember(Name="xBairro", Order=3)]
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
		[JsonPropertyOrder(4)]
		[DataMember(Name="cMun", Order=4)]
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
		[JsonPropertyOrder(5)]
		[DataMember(Name="xMun", Order=5)]
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
		[JsonPropertyOrder(6)]
		[DataMember(Name="UF", Order=6)]
		public  string gxTpr_Uf
		{
			get { 
				return sdt.gxTpr_Uf;

			}
			set { 
				 sdt.gxTpr_Uf = value;
			}
		}

		[JsonPropertyName("CEP")]
		[JsonPropertyOrder(7)]
		[DataMember(Name="CEP", Order=7)]
		public  string gxTpr_Cep
		{
			get { 
				return sdt.gxTpr_Cep;

			}
			set { 
				 sdt.gxTpr_Cep = value;
			}
		}

		[JsonPropertyName("cPais")]
		[JsonPropertyOrder(8)]
		[DataMember(Name="cPais", Order=8)]
		public  string gxTpr_Cpais
		{
			get { 
				return sdt.gxTpr_Cpais;

			}
			set { 
				 sdt.gxTpr_Cpais = value;
			}
		}

		[JsonPropertyName("xPais")]
		[JsonPropertyOrder(9)]
		[DataMember(Name="xPais", Order=9)]
		public  string gxTpr_Xpais
		{
			get { 
				return sdt.gxTpr_Xpais;

			}
			set { 
				 sdt.gxTpr_Xpais = value;
			}
		}

		[JsonPropertyName("fone")]
		[JsonPropertyOrder(10)]
		[DataMember(Name="fone", Order=10)]
		public  string gxTpr_Fone
		{
			get { 
				return sdt.gxTpr_Fone;

			}
			set { 
				 sdt.gxTpr_Fone = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit sdt
		{
			get { 
				return (SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit)Sdt;
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
				sdt = new SdtSdNotaFiscal_NFe_infNFe_emit_enderEmit() ;
			}
		}
	}
	#endregion
}