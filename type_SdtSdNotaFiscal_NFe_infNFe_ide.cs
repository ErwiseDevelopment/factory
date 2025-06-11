/*
				   File: type_SdtSdNotaFiscal_NFe_infNFe_ide
			Description: ide
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
	[XmlRoot(ElementName="SdNotaFiscal.NFe.infNFe.ide")]
	[XmlType(TypeName="SdNotaFiscal.NFe.infNFe.ide" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdNotaFiscal_NFe_infNFe_ide : GxUserType
	{
		public SdtSdNotaFiscal_NFe_infNFe_ide( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Cuf = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Cnf = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Natop = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Indpag = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Mod = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Serie = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Nnf = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Demi = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Dsaient = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Tpnf = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Cmunfg = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Tpimp = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Tpemis = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Cdv = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Tpamb = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Finnfe = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Procemi = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Verproc = "";

		}

		public SdtSdNotaFiscal_NFe_infNFe_ide(IGxContext context)
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
			AddObjectProperty("cUF", gxTpr_Cuf, false);


			AddObjectProperty("cNF", gxTpr_Cnf, false);


			AddObjectProperty("natOp", gxTpr_Natop, false);


			AddObjectProperty("indPag", gxTpr_Indpag, false);


			AddObjectProperty("mod", gxTpr_Mod, false);


			AddObjectProperty("serie", gxTpr_Serie, false);


			AddObjectProperty("nNF", gxTpr_Nnf, false);


			AddObjectProperty("dEmi", gxTpr_Demi, false);


			AddObjectProperty("dSaiEnt", gxTpr_Dsaient, false);


			AddObjectProperty("tpNF", gxTpr_Tpnf, false);


			AddObjectProperty("cMunFG", gxTpr_Cmunfg, false);


			AddObjectProperty("tpImp", gxTpr_Tpimp, false);


			AddObjectProperty("tpEmis", gxTpr_Tpemis, false);


			AddObjectProperty("cDV", gxTpr_Cdv, false);


			AddObjectProperty("tpAmb", gxTpr_Tpamb, false);


			AddObjectProperty("finNFe", gxTpr_Finnfe, false);


			AddObjectProperty("procEmi", gxTpr_Procemi, false);


			AddObjectProperty("verProc", gxTpr_Verproc, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="cUF")]
		[XmlElement(ElementName="cUF")]
		public string gxTpr_Cuf
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Cuf; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Cuf = value;
				SetDirty("Cuf");
			}
		}




		[SoapElement(ElementName="cNF")]
		[XmlElement(ElementName="cNF")]
		public string gxTpr_Cnf
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Cnf; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Cnf = value;
				SetDirty("Cnf");
			}
		}




		[SoapElement(ElementName="natOp")]
		[XmlElement(ElementName="natOp")]
		public string gxTpr_Natop
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Natop; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Natop = value;
				SetDirty("Natop");
			}
		}




		[SoapElement(ElementName="indPag")]
		[XmlElement(ElementName="indPag")]
		public string gxTpr_Indpag
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Indpag; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Indpag = value;
				SetDirty("Indpag");
			}
		}




		[SoapElement(ElementName="mod")]
		[XmlElement(ElementName="mod")]
		public string gxTpr_Mod
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Mod; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Mod = value;
				SetDirty("Mod");
			}
		}




		[SoapElement(ElementName="serie")]
		[XmlElement(ElementName="serie")]
		public string gxTpr_Serie
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Serie; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Serie = value;
				SetDirty("Serie");
			}
		}




		[SoapElement(ElementName="nNF")]
		[XmlElement(ElementName="nNF")]
		public string gxTpr_Nnf
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Nnf; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Nnf = value;
				SetDirty("Nnf");
			}
		}




		[SoapElement(ElementName="dEmi")]
		[XmlElement(ElementName="dEmi")]
		public string gxTpr_Demi
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Demi; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Demi = value;
				SetDirty("Demi");
			}
		}




		[SoapElement(ElementName="dSaiEnt")]
		[XmlElement(ElementName="dSaiEnt")]
		public string gxTpr_Dsaient
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Dsaient; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Dsaient = value;
				SetDirty("Dsaient");
			}
		}




		[SoapElement(ElementName="tpNF")]
		[XmlElement(ElementName="tpNF")]
		public string gxTpr_Tpnf
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Tpnf; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Tpnf = value;
				SetDirty("Tpnf");
			}
		}




		[SoapElement(ElementName="cMunFG")]
		[XmlElement(ElementName="cMunFG")]
		public string gxTpr_Cmunfg
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Cmunfg; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Cmunfg = value;
				SetDirty("Cmunfg");
			}
		}




		[SoapElement(ElementName="tpImp")]
		[XmlElement(ElementName="tpImp")]
		public string gxTpr_Tpimp
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Tpimp; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Tpimp = value;
				SetDirty("Tpimp");
			}
		}




		[SoapElement(ElementName="tpEmis")]
		[XmlElement(ElementName="tpEmis")]
		public string gxTpr_Tpemis
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Tpemis; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Tpemis = value;
				SetDirty("Tpemis");
			}
		}




		[SoapElement(ElementName="cDV")]
		[XmlElement(ElementName="cDV")]
		public string gxTpr_Cdv
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Cdv; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Cdv = value;
				SetDirty("Cdv");
			}
		}




		[SoapElement(ElementName="tpAmb")]
		[XmlElement(ElementName="tpAmb")]
		public string gxTpr_Tpamb
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Tpamb; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Tpamb = value;
				SetDirty("Tpamb");
			}
		}




		[SoapElement(ElementName="finNFe")]
		[XmlElement(ElementName="finNFe")]
		public string gxTpr_Finnfe
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Finnfe; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Finnfe = value;
				SetDirty("Finnfe");
			}
		}




		[SoapElement(ElementName="procEmi")]
		[XmlElement(ElementName="procEmi")]
		public string gxTpr_Procemi
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Procemi; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Procemi = value;
				SetDirty("Procemi");
			}
		}




		[SoapElement(ElementName="verProc")]
		[XmlElement(ElementName="verProc")]
		public string gxTpr_Verproc
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Verproc; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Verproc = value;
				SetDirty("Verproc");
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
			gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Cuf = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Cnf = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Natop = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Indpag = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Mod = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Serie = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Nnf = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Demi = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Dsaient = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Tpnf = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Cmunfg = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Tpimp = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Tpemis = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Cdv = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Tpamb = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Finnfe = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Procemi = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Verproc = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Cuf;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Cnf;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Natop;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Indpag;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Mod;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Serie;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Nnf;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Demi;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Dsaient;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Tpnf;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Cmunfg;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Tpimp;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Tpemis;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Cdv;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Tpamb;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Finnfe;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Procemi;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_ide_Verproc;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdNotaFiscal.NFe.infNFe.ide", Namespace="Factory21")]
	public class SdtSdNotaFiscal_NFe_infNFe_ide_RESTInterface : GxGenericCollectionItem<SdtSdNotaFiscal_NFe_infNFe_ide>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdNotaFiscal_NFe_infNFe_ide_RESTInterface( ) : base()
		{	
		}

		public SdtSdNotaFiscal_NFe_infNFe_ide_RESTInterface( SdtSdNotaFiscal_NFe_infNFe_ide psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("cUF")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="cUF", Order=0)]
		public  string gxTpr_Cuf
		{
			get { 
				return sdt.gxTpr_Cuf;

			}
			set { 
				 sdt.gxTpr_Cuf = value;
			}
		}

		[JsonPropertyName("cNF")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="cNF", Order=1)]
		public  string gxTpr_Cnf
		{
			get { 
				return sdt.gxTpr_Cnf;

			}
			set { 
				 sdt.gxTpr_Cnf = value;
			}
		}

		[JsonPropertyName("natOp")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="natOp", Order=2)]
		public  string gxTpr_Natop
		{
			get { 
				return sdt.gxTpr_Natop;

			}
			set { 
				 sdt.gxTpr_Natop = value;
			}
		}

		[JsonPropertyName("indPag")]
		[JsonPropertyOrder(3)]
		[DataMember(Name="indPag", Order=3)]
		public  string gxTpr_Indpag
		{
			get { 
				return sdt.gxTpr_Indpag;

			}
			set { 
				 sdt.gxTpr_Indpag = value;
			}
		}

		[JsonPropertyName("mod")]
		[JsonPropertyOrder(4)]
		[DataMember(Name="mod", Order=4)]
		public  string gxTpr_Mod
		{
			get { 
				return sdt.gxTpr_Mod;

			}
			set { 
				 sdt.gxTpr_Mod = value;
			}
		}

		[JsonPropertyName("serie")]
		[JsonPropertyOrder(5)]
		[DataMember(Name="serie", Order=5)]
		public  string gxTpr_Serie
		{
			get { 
				return sdt.gxTpr_Serie;

			}
			set { 
				 sdt.gxTpr_Serie = value;
			}
		}

		[JsonPropertyName("nNF")]
		[JsonPropertyOrder(6)]
		[DataMember(Name="nNF", Order=6)]
		public  string gxTpr_Nnf
		{
			get { 
				return sdt.gxTpr_Nnf;

			}
			set { 
				 sdt.gxTpr_Nnf = value;
			}
		}

		[JsonPropertyName("dEmi")]
		[JsonPropertyOrder(7)]
		[DataMember(Name="dEmi", Order=7)]
		public  string gxTpr_Demi
		{
			get { 
				return sdt.gxTpr_Demi;

			}
			set { 
				 sdt.gxTpr_Demi = value;
			}
		}

		[JsonPropertyName("dSaiEnt")]
		[JsonPropertyOrder(8)]
		[DataMember(Name="dSaiEnt", Order=8)]
		public  string gxTpr_Dsaient
		{
			get { 
				return sdt.gxTpr_Dsaient;

			}
			set { 
				 sdt.gxTpr_Dsaient = value;
			}
		}

		[JsonPropertyName("tpNF")]
		[JsonPropertyOrder(9)]
		[DataMember(Name="tpNF", Order=9)]
		public  string gxTpr_Tpnf
		{
			get { 
				return sdt.gxTpr_Tpnf;

			}
			set { 
				 sdt.gxTpr_Tpnf = value;
			}
		}

		[JsonPropertyName("cMunFG")]
		[JsonPropertyOrder(10)]
		[DataMember(Name="cMunFG", Order=10)]
		public  string gxTpr_Cmunfg
		{
			get { 
				return sdt.gxTpr_Cmunfg;

			}
			set { 
				 sdt.gxTpr_Cmunfg = value;
			}
		}

		[JsonPropertyName("tpImp")]
		[JsonPropertyOrder(11)]
		[DataMember(Name="tpImp", Order=11)]
		public  string gxTpr_Tpimp
		{
			get { 
				return sdt.gxTpr_Tpimp;

			}
			set { 
				 sdt.gxTpr_Tpimp = value;
			}
		}

		[JsonPropertyName("tpEmis")]
		[JsonPropertyOrder(12)]
		[DataMember(Name="tpEmis", Order=12)]
		public  string gxTpr_Tpemis
		{
			get { 
				return sdt.gxTpr_Tpemis;

			}
			set { 
				 sdt.gxTpr_Tpemis = value;
			}
		}

		[JsonPropertyName("cDV")]
		[JsonPropertyOrder(13)]
		[DataMember(Name="cDV", Order=13)]
		public  string gxTpr_Cdv
		{
			get { 
				return sdt.gxTpr_Cdv;

			}
			set { 
				 sdt.gxTpr_Cdv = value;
			}
		}

		[JsonPropertyName("tpAmb")]
		[JsonPropertyOrder(14)]
		[DataMember(Name="tpAmb", Order=14)]
		public  string gxTpr_Tpamb
		{
			get { 
				return sdt.gxTpr_Tpamb;

			}
			set { 
				 sdt.gxTpr_Tpamb = value;
			}
		}

		[JsonPropertyName("finNFe")]
		[JsonPropertyOrder(15)]
		[DataMember(Name="finNFe", Order=15)]
		public  string gxTpr_Finnfe
		{
			get { 
				return sdt.gxTpr_Finnfe;

			}
			set { 
				 sdt.gxTpr_Finnfe = value;
			}
		}

		[JsonPropertyName("procEmi")]
		[JsonPropertyOrder(16)]
		[DataMember(Name="procEmi", Order=16)]
		public  string gxTpr_Procemi
		{
			get { 
				return sdt.gxTpr_Procemi;

			}
			set { 
				 sdt.gxTpr_Procemi = value;
			}
		}

		[JsonPropertyName("verProc")]
		[JsonPropertyOrder(17)]
		[DataMember(Name="verProc", Order=17)]
		public  string gxTpr_Verproc
		{
			get { 
				return sdt.gxTpr_Verproc;

			}
			set { 
				 sdt.gxTpr_Verproc = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdNotaFiscal_NFe_infNFe_ide sdt
		{
			get { 
				return (SdtSdNotaFiscal_NFe_infNFe_ide)Sdt;
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
				sdt = new SdtSdNotaFiscal_NFe_infNFe_ide() ;
			}
		}
	}
	#endregion
}