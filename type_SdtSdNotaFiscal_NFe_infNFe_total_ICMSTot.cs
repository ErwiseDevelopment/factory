/*
				   File: type_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot
			Description: ICMSTot
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
	[XmlRoot(ElementName="SdNotaFiscal.NFe.infNFe.total.ICMSTot")]
	[XmlType(TypeName="SdNotaFiscal.NFe.infNFe.total.ICMSTot" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot : GxUserType
	{
		public SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vbc = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vicms = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vbcst = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vst = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vprod = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vfrete = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vseg = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vdesc = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vii = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vipi = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vpis = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vcofins = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Voutro = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vnf = "";

		}

		public SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot(IGxContext context)
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
			AddObjectProperty("vBC", gxTpr_Vbc, false);


			AddObjectProperty("vICMS", gxTpr_Vicms, false);


			AddObjectProperty("vBCST", gxTpr_Vbcst, false);


			AddObjectProperty("vST", gxTpr_Vst, false);


			AddObjectProperty("vProd", gxTpr_Vprod, false);


			AddObjectProperty("vFrete", gxTpr_Vfrete, false);


			AddObjectProperty("vSeg", gxTpr_Vseg, false);


			AddObjectProperty("vDesc", gxTpr_Vdesc, false);


			AddObjectProperty("vII", gxTpr_Vii, false);


			AddObjectProperty("vIPI", gxTpr_Vipi, false);


			AddObjectProperty("vPIS", gxTpr_Vpis, false);


			AddObjectProperty("vCOFINS", gxTpr_Vcofins, false);


			AddObjectProperty("vOutro", gxTpr_Voutro, false);


			AddObjectProperty("vNF", gxTpr_Vnf, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="vBC")]
		[XmlElement(ElementName="vBC")]
		public string gxTpr_Vbc
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vbc; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vbc = value;
				SetDirty("Vbc");
			}
		}




		[SoapElement(ElementName="vICMS")]
		[XmlElement(ElementName="vICMS")]
		public string gxTpr_Vicms
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vicms; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vicms = value;
				SetDirty("Vicms");
			}
		}




		[SoapElement(ElementName="vBCST")]
		[XmlElement(ElementName="vBCST")]
		public string gxTpr_Vbcst
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vbcst; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vbcst = value;
				SetDirty("Vbcst");
			}
		}




		[SoapElement(ElementName="vST")]
		[XmlElement(ElementName="vST")]
		public string gxTpr_Vst
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vst; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vst = value;
				SetDirty("Vst");
			}
		}




		[SoapElement(ElementName="vProd")]
		[XmlElement(ElementName="vProd")]
		public string gxTpr_Vprod
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vprod; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vprod = value;
				SetDirty("Vprod");
			}
		}




		[SoapElement(ElementName="vFrete")]
		[XmlElement(ElementName="vFrete")]
		public string gxTpr_Vfrete
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vfrete; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vfrete = value;
				SetDirty("Vfrete");
			}
		}




		[SoapElement(ElementName="vSeg")]
		[XmlElement(ElementName="vSeg")]
		public string gxTpr_Vseg
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vseg; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vseg = value;
				SetDirty("Vseg");
			}
		}




		[SoapElement(ElementName="vDesc")]
		[XmlElement(ElementName="vDesc")]
		public string gxTpr_Vdesc
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vdesc; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vdesc = value;
				SetDirty("Vdesc");
			}
		}




		[SoapElement(ElementName="vII")]
		[XmlElement(ElementName="vII")]
		public string gxTpr_Vii
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vii; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vii = value;
				SetDirty("Vii");
			}
		}




		[SoapElement(ElementName="vIPI")]
		[XmlElement(ElementName="vIPI")]
		public string gxTpr_Vipi
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vipi; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vipi = value;
				SetDirty("Vipi");
			}
		}




		[SoapElement(ElementName="vPIS")]
		[XmlElement(ElementName="vPIS")]
		public string gxTpr_Vpis
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vpis; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vpis = value;
				SetDirty("Vpis");
			}
		}




		[SoapElement(ElementName="vCOFINS")]
		[XmlElement(ElementName="vCOFINS")]
		public string gxTpr_Vcofins
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vcofins; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vcofins = value;
				SetDirty("Vcofins");
			}
		}




		[SoapElement(ElementName="vOutro")]
		[XmlElement(ElementName="vOutro")]
		public string gxTpr_Voutro
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Voutro; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Voutro = value;
				SetDirty("Voutro");
			}
		}




		[SoapElement(ElementName="vNF")]
		[XmlElement(ElementName="vNF")]
		public string gxTpr_Vnf
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vnf; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vnf = value;
				SetDirty("Vnf");
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
			gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vbc = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vicms = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vbcst = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vst = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vprod = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vfrete = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vseg = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vdesc = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vii = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vipi = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vpis = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vcofins = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Voutro = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vnf = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vbc;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vicms;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vbcst;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vst;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vprod;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vfrete;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vseg;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vdesc;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vii;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vipi;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vpis;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vcofins;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Voutro;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_Vnf;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdNotaFiscal.NFe.infNFe.total.ICMSTot", Namespace="Factory21")]
	public class SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_RESTInterface : GxGenericCollectionItem<SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_RESTInterface( ) : base()
		{	
		}

		public SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot_RESTInterface( SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("vBC")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="vBC", Order=0)]
		public  string gxTpr_Vbc
		{
			get { 
				return sdt.gxTpr_Vbc;

			}
			set { 
				 sdt.gxTpr_Vbc = value;
			}
		}

		[JsonPropertyName("vICMS")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="vICMS", Order=1)]
		public  string gxTpr_Vicms
		{
			get { 
				return sdt.gxTpr_Vicms;

			}
			set { 
				 sdt.gxTpr_Vicms = value;
			}
		}

		[JsonPropertyName("vBCST")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="vBCST", Order=2)]
		public  string gxTpr_Vbcst
		{
			get { 
				return sdt.gxTpr_Vbcst;

			}
			set { 
				 sdt.gxTpr_Vbcst = value;
			}
		}

		[JsonPropertyName("vST")]
		[JsonPropertyOrder(3)]
		[DataMember(Name="vST", Order=3)]
		public  string gxTpr_Vst
		{
			get { 
				return sdt.gxTpr_Vst;

			}
			set { 
				 sdt.gxTpr_Vst = value;
			}
		}

		[JsonPropertyName("vProd")]
		[JsonPropertyOrder(4)]
		[DataMember(Name="vProd", Order=4)]
		public  string gxTpr_Vprod
		{
			get { 
				return sdt.gxTpr_Vprod;

			}
			set { 
				 sdt.gxTpr_Vprod = value;
			}
		}

		[JsonPropertyName("vFrete")]
		[JsonPropertyOrder(5)]
		[DataMember(Name="vFrete", Order=5)]
		public  string gxTpr_Vfrete
		{
			get { 
				return sdt.gxTpr_Vfrete;

			}
			set { 
				 sdt.gxTpr_Vfrete = value;
			}
		}

		[JsonPropertyName("vSeg")]
		[JsonPropertyOrder(6)]
		[DataMember(Name="vSeg", Order=6)]
		public  string gxTpr_Vseg
		{
			get { 
				return sdt.gxTpr_Vseg;

			}
			set { 
				 sdt.gxTpr_Vseg = value;
			}
		}

		[JsonPropertyName("vDesc")]
		[JsonPropertyOrder(7)]
		[DataMember(Name="vDesc", Order=7)]
		public  string gxTpr_Vdesc
		{
			get { 
				return sdt.gxTpr_Vdesc;

			}
			set { 
				 sdt.gxTpr_Vdesc = value;
			}
		}

		[JsonPropertyName("vII")]
		[JsonPropertyOrder(8)]
		[DataMember(Name="vII", Order=8)]
		public  string gxTpr_Vii
		{
			get { 
				return sdt.gxTpr_Vii;

			}
			set { 
				 sdt.gxTpr_Vii = value;
			}
		}

		[JsonPropertyName("vIPI")]
		[JsonPropertyOrder(9)]
		[DataMember(Name="vIPI", Order=9)]
		public  string gxTpr_Vipi
		{
			get { 
				return sdt.gxTpr_Vipi;

			}
			set { 
				 sdt.gxTpr_Vipi = value;
			}
		}

		[JsonPropertyName("vPIS")]
		[JsonPropertyOrder(10)]
		[DataMember(Name="vPIS", Order=10)]
		public  string gxTpr_Vpis
		{
			get { 
				return sdt.gxTpr_Vpis;

			}
			set { 
				 sdt.gxTpr_Vpis = value;
			}
		}

		[JsonPropertyName("vCOFINS")]
		[JsonPropertyOrder(11)]
		[DataMember(Name="vCOFINS", Order=11)]
		public  string gxTpr_Vcofins
		{
			get { 
				return sdt.gxTpr_Vcofins;

			}
			set { 
				 sdt.gxTpr_Vcofins = value;
			}
		}

		[JsonPropertyName("vOutro")]
		[JsonPropertyOrder(12)]
		[DataMember(Name="vOutro", Order=12)]
		public  string gxTpr_Voutro
		{
			get { 
				return sdt.gxTpr_Voutro;

			}
			set { 
				 sdt.gxTpr_Voutro = value;
			}
		}

		[JsonPropertyName("vNF")]
		[JsonPropertyOrder(13)]
		[DataMember(Name="vNF", Order=13)]
		public  string gxTpr_Vnf
		{
			get { 
				return sdt.gxTpr_Vnf;

			}
			set { 
				 sdt.gxTpr_Vnf = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot sdt
		{
			get { 
				return (SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot)Sdt;
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
				sdt = new SdtSdNotaFiscal_NFe_infNFe_total_ICMSTot() ;
			}
		}
	}
	#endregion
}