/*
				   File: type_SdtSdNotaFiscal_NFe_infNFe_transp_reboque
			Description: reboque
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
	[XmlRoot(ElementName="SdNotaFiscal.NFe.infNFe.transp.reboque")]
	[XmlType(TypeName="SdNotaFiscal.NFe.infNFe.transp.reboque" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdNotaFiscal_NFe_infNFe_transp_reboque : GxUserType
	{
		public SdtSdNotaFiscal_NFe_infNFe_transp_reboque( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_reboque_Placa = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_reboque_Uf = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_reboque_Rntc = "";

		}

		public SdtSdNotaFiscal_NFe_infNFe_transp_reboque(IGxContext context)
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
			AddObjectProperty("placa", gxTpr_Placa, false);


			AddObjectProperty("UF", gxTpr_Uf, false);


			AddObjectProperty("RNTC", gxTpr_Rntc, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="placa")]
		[XmlElement(ElementName="placa")]
		public string gxTpr_Placa
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_reboque_Placa; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_reboque_Placa = value;
				SetDirty("Placa");
			}
		}




		[SoapElement(ElementName="UF")]
		[XmlElement(ElementName="UF")]
		public string gxTpr_Uf
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_reboque_Uf; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_reboque_Uf = value;
				SetDirty("Uf");
			}
		}




		[SoapElement(ElementName="RNTC")]
		[XmlElement(ElementName="RNTC")]
		public string gxTpr_Rntc
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_reboque_Rntc; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_reboque_Rntc = value;
				SetDirty("Rntc");
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
			gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_reboque_Placa = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_reboque_Uf = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_reboque_Rntc = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_reboque_Placa;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_reboque_Uf;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_transp_reboque_Rntc;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdNotaFiscal.NFe.infNFe.transp.reboque", Namespace="Factory21")]
	public class SdtSdNotaFiscal_NFe_infNFe_transp_reboque_RESTInterface : GxGenericCollectionItem<SdtSdNotaFiscal_NFe_infNFe_transp_reboque>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdNotaFiscal_NFe_infNFe_transp_reboque_RESTInterface( ) : base()
		{	
		}

		public SdtSdNotaFiscal_NFe_infNFe_transp_reboque_RESTInterface( SdtSdNotaFiscal_NFe_infNFe_transp_reboque psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("placa")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="placa", Order=0)]
		public  string gxTpr_Placa
		{
			get { 
				return sdt.gxTpr_Placa;

			}
			set { 
				 sdt.gxTpr_Placa = value;
			}
		}

		[JsonPropertyName("UF")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="UF", Order=1)]
		public  string gxTpr_Uf
		{
			get { 
				return sdt.gxTpr_Uf;

			}
			set { 
				 sdt.gxTpr_Uf = value;
			}
		}

		[JsonPropertyName("RNTC")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="RNTC", Order=2)]
		public  string gxTpr_Rntc
		{
			get { 
				return sdt.gxTpr_Rntc;

			}
			set { 
				 sdt.gxTpr_Rntc = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdNotaFiscal_NFe_infNFe_transp_reboque sdt
		{
			get { 
				return (SdtSdNotaFiscal_NFe_infNFe_transp_reboque)Sdt;
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
				sdt = new SdtSdNotaFiscal_NFe_infNFe_transp_reboque() ;
			}
		}
	}
	#endregion
}