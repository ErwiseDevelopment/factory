/*
				   File: type_SdtSdNotaFiscal_NFe_infNFe_transp_vol
			Description: vol
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
	[XmlRoot(ElementName="SdNotaFiscal.NFe.infNFe.transp.vol")]
	[XmlType(TypeName="SdNotaFiscal.NFe.infNFe.transp.vol" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdNotaFiscal_NFe_infNFe_transp_vol : GxUserType
	{
		public SdtSdNotaFiscal_NFe_infNFe_transp_vol( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_vol_Qvol = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_vol_Esp = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_vol_Marca = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_vol_Nvol = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_vol_Pesol = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_vol_Pesob = "";

		}

		public SdtSdNotaFiscal_NFe_infNFe_transp_vol(IGxContext context)
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
			AddObjectProperty("qVol", gxTpr_Qvol, false);


			AddObjectProperty("esp", gxTpr_Esp, false);


			AddObjectProperty("marca", gxTpr_Marca, false);


			AddObjectProperty("nVol", gxTpr_Nvol, false);


			AddObjectProperty("pesoL", gxTpr_Pesol, false);


			AddObjectProperty("pesoB", gxTpr_Pesob, false);

			if (gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_vol_Lacres != null)
			{
				AddObjectProperty("lacres", gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_vol_Lacres, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="qVol")]
		[XmlElement(ElementName="qVol")]
		public string gxTpr_Qvol
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_vol_Qvol; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_vol_Qvol = value;
				SetDirty("Qvol");
			}
		}




		[SoapElement(ElementName="esp")]
		[XmlElement(ElementName="esp")]
		public string gxTpr_Esp
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_vol_Esp; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_vol_Esp = value;
				SetDirty("Esp");
			}
		}




		[SoapElement(ElementName="marca")]
		[XmlElement(ElementName="marca")]
		public string gxTpr_Marca
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_vol_Marca; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_vol_Marca = value;
				SetDirty("Marca");
			}
		}




		[SoapElement(ElementName="nVol")]
		[XmlElement(ElementName="nVol")]
		public string gxTpr_Nvol
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_vol_Nvol; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_vol_Nvol = value;
				SetDirty("Nvol");
			}
		}




		[SoapElement(ElementName="pesoL")]
		[XmlElement(ElementName="pesoL")]
		public string gxTpr_Pesol
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_vol_Pesol; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_vol_Pesol = value;
				SetDirty("Pesol");
			}
		}




		[SoapElement(ElementName="pesoB")]
		[XmlElement(ElementName="pesoB")]
		public string gxTpr_Pesob
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_vol_Pesob; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_vol_Pesob = value;
				SetDirty("Pesob");
			}
		}



		[SoapElement(ElementName="lacres" )]
		[XmlElement(ElementName="lacres" )]
		public SdtSdNotaFiscal_NFe_infNFe_transp_vol_lacres gxTpr_Lacres
		{
			get {
				if ( gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_vol_Lacres == null )
				{
					gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_vol_Lacres = new SdtSdNotaFiscal_NFe_infNFe_transp_vol_lacres(context);
				}
				gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_vol_Lacres_N = false;
				SetDirty("Lacres");
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_vol_Lacres;
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_vol_Lacres_N = false;
				gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_vol_Lacres = value;
				SetDirty("Lacres");
			}

		}

		public void gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_vol_Lacres_SetNull()
		{
			gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_vol_Lacres_N = true;
			gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_vol_Lacres = null;
		}

		public bool gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_vol_Lacres_IsNull()
		{
			return gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_vol_Lacres == null;
		}
		public bool ShouldSerializegxTpr_Lacres_Json()
		{
				return (gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_vol_Lacres != null && gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_vol_Lacres.ShouldSerializeSdtJson());

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
			gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_vol_Qvol = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_vol_Esp = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_vol_Marca = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_vol_Nvol = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_vol_Pesol = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_vol_Pesob = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_vol_Lacres_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_vol_Qvol;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_vol_Esp;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_vol_Marca;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_vol_Nvol;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_vol_Pesol;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_vol_Pesob;
		 
		protected bool gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_vol_Lacres_N;
		protected SdtSdNotaFiscal_NFe_infNFe_transp_vol_lacres gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_vol_Lacres = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdNotaFiscal.NFe.infNFe.transp.vol", Namespace="Factory21")]
	public class SdtSdNotaFiscal_NFe_infNFe_transp_vol_RESTInterface : GxGenericCollectionItem<SdtSdNotaFiscal_NFe_infNFe_transp_vol>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdNotaFiscal_NFe_infNFe_transp_vol_RESTInterface( ) : base()
		{	
		}

		public SdtSdNotaFiscal_NFe_infNFe_transp_vol_RESTInterface( SdtSdNotaFiscal_NFe_infNFe_transp_vol psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("qVol")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="qVol", Order=0)]
		public  string gxTpr_Qvol
		{
			get { 
				return sdt.gxTpr_Qvol;

			}
			set { 
				 sdt.gxTpr_Qvol = value;
			}
		}

		[JsonPropertyName("esp")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="esp", Order=1)]
		public  string gxTpr_Esp
		{
			get { 
				return sdt.gxTpr_Esp;

			}
			set { 
				 sdt.gxTpr_Esp = value;
			}
		}

		[JsonPropertyName("marca")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="marca", Order=2)]
		public  string gxTpr_Marca
		{
			get { 
				return sdt.gxTpr_Marca;

			}
			set { 
				 sdt.gxTpr_Marca = value;
			}
		}

		[JsonPropertyName("nVol")]
		[JsonPropertyOrder(3)]
		[DataMember(Name="nVol", Order=3)]
		public  string gxTpr_Nvol
		{
			get { 
				return sdt.gxTpr_Nvol;

			}
			set { 
				 sdt.gxTpr_Nvol = value;
			}
		}

		[JsonPropertyName("pesoL")]
		[JsonPropertyOrder(4)]
		[DataMember(Name="pesoL", Order=4)]
		public  string gxTpr_Pesol
		{
			get { 
				return sdt.gxTpr_Pesol;

			}
			set { 
				 sdt.gxTpr_Pesol = value;
			}
		}

		[JsonPropertyName("pesoB")]
		[JsonPropertyOrder(5)]
		[DataMember(Name="pesoB", Order=5)]
		public  string gxTpr_Pesob
		{
			get { 
				return sdt.gxTpr_Pesob;

			}
			set { 
				 sdt.gxTpr_Pesob = value;
			}
		}

		[JsonPropertyName("lacres")]
		[JsonPropertyOrder(6)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="lacres", Order=6, EmitDefaultValue=false)]
		public SdtSdNotaFiscal_NFe_infNFe_transp_vol_lacres_RESTInterface gxTpr_Lacres
		{
			get {
				if (sdt.ShouldSerializegxTpr_Lacres_Json())
					return new SdtSdNotaFiscal_NFe_infNFe_transp_vol_lacres_RESTInterface(sdt.gxTpr_Lacres);
				else
					return null;

			}

			set {
				sdt.gxTpr_Lacres = value.sdt;
			}

		}


		#endregion
		[JsonIgnore]
		public SdtSdNotaFiscal_NFe_infNFe_transp_vol sdt
		{
			get { 
				return (SdtSdNotaFiscal_NFe_infNFe_transp_vol)Sdt;
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
				sdt = new SdtSdNotaFiscal_NFe_infNFe_transp_vol() ;
			}
		}
	}
	#endregion
}