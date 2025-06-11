/*
				   File: type_SdtSdNotaFiscal_NFe_infNFe_cobr_fat
			Description: fat
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
	[XmlRoot(ElementName="SdNotaFiscal.NFe.infNFe.cobr.fat")]
	[XmlType(TypeName="SdNotaFiscal.NFe.infNFe.cobr.fat" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdNotaFiscal_NFe_infNFe_cobr_fat : GxUserType
	{
		public SdtSdNotaFiscal_NFe_infNFe_cobr_fat( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_fat_Nfat = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_fat_Vorig = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_fat_Vdesc = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_fat_Vliq = "";

		}

		public SdtSdNotaFiscal_NFe_infNFe_cobr_fat(IGxContext context)
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
			AddObjectProperty("nFat", gxTpr_Nfat, false);


			AddObjectProperty("vOrig", gxTpr_Vorig, false);


			AddObjectProperty("vDesc", gxTpr_Vdesc, false);


			AddObjectProperty("vLiq", gxTpr_Vliq, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="nFat")]
		[XmlElement(ElementName="nFat")]
		public string gxTpr_Nfat
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_fat_Nfat; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_fat_Nfat = value;
				SetDirty("Nfat");
			}
		}




		[SoapElement(ElementName="vOrig")]
		[XmlElement(ElementName="vOrig")]
		public string gxTpr_Vorig
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_fat_Vorig; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_fat_Vorig = value;
				SetDirty("Vorig");
			}
		}




		[SoapElement(ElementName="vDesc")]
		[XmlElement(ElementName="vDesc")]
		public string gxTpr_Vdesc
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_fat_Vdesc; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_fat_Vdesc = value;
				SetDirty("Vdesc");
			}
		}




		[SoapElement(ElementName="vLiq")]
		[XmlElement(ElementName="vLiq")]
		public string gxTpr_Vliq
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_fat_Vliq; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_fat_Vliq = value;
				SetDirty("Vliq");
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
			gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_fat_Nfat = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_fat_Vorig = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_fat_Vdesc = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_fat_Vliq = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_fat_Nfat;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_fat_Vorig;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_fat_Vdesc;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_fat_Vliq;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdNotaFiscal.NFe.infNFe.cobr.fat", Namespace="Factory21")]
	public class SdtSdNotaFiscal_NFe_infNFe_cobr_fat_RESTInterface : GxGenericCollectionItem<SdtSdNotaFiscal_NFe_infNFe_cobr_fat>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdNotaFiscal_NFe_infNFe_cobr_fat_RESTInterface( ) : base()
		{	
		}

		public SdtSdNotaFiscal_NFe_infNFe_cobr_fat_RESTInterface( SdtSdNotaFiscal_NFe_infNFe_cobr_fat psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("nFat")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="nFat", Order=0)]
		public  string gxTpr_Nfat
		{
			get { 
				return sdt.gxTpr_Nfat;

			}
			set { 
				 sdt.gxTpr_Nfat = value;
			}
		}

		[JsonPropertyName("vOrig")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="vOrig", Order=1)]
		public  string gxTpr_Vorig
		{
			get { 
				return sdt.gxTpr_Vorig;

			}
			set { 
				 sdt.gxTpr_Vorig = value;
			}
		}

		[JsonPropertyName("vDesc")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="vDesc", Order=2)]
		public  string gxTpr_Vdesc
		{
			get { 
				return sdt.gxTpr_Vdesc;

			}
			set { 
				 sdt.gxTpr_Vdesc = value;
			}
		}

		[JsonPropertyName("vLiq")]
		[JsonPropertyOrder(3)]
		[DataMember(Name="vLiq", Order=3)]
		public  string gxTpr_Vliq
		{
			get { 
				return sdt.gxTpr_Vliq;

			}
			set { 
				 sdt.gxTpr_Vliq = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdNotaFiscal_NFe_infNFe_cobr_fat sdt
		{
			get { 
				return (SdtSdNotaFiscal_NFe_infNFe_cobr_fat)Sdt;
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
				sdt = new SdtSdNotaFiscal_NFe_infNFe_cobr_fat() ;
			}
		}
	}
	#endregion
}