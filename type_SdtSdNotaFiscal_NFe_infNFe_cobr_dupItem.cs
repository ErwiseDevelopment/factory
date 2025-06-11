/*
				   File: type_SdtSdNotaFiscal_NFe_infNFe_cobr_dupItem
			Description: dup
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
	[XmlRoot(ElementName="SdNotaFiscal.NFe.infNFe.cobr.dupItem")]
	[XmlType(TypeName="SdNotaFiscal.NFe.infNFe.cobr.dupItem" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdNotaFiscal_NFe_infNFe_cobr_dupItem : GxUserType
	{
		public SdtSdNotaFiscal_NFe_infNFe_cobr_dupItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_dupItem_Ndup = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_dupItem_Dvenc = "";

			gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_dupItem_Vdup = "";

		}

		public SdtSdNotaFiscal_NFe_infNFe_cobr_dupItem(IGxContext context)
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
			AddObjectProperty("nDup", gxTpr_Ndup, false);


			AddObjectProperty("dVenc", gxTpr_Dvenc, false);


			AddObjectProperty("vDup", gxTpr_Vdup, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="nDup")]
		[XmlElement(ElementName="nDup")]
		public string gxTpr_Ndup
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_dupItem_Ndup; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_dupItem_Ndup = value;
				SetDirty("Ndup");
			}
		}




		[SoapElement(ElementName="dVenc")]
		[XmlElement(ElementName="dVenc")]
		public string gxTpr_Dvenc
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_dupItem_Dvenc; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_dupItem_Dvenc = value;
				SetDirty("Dvenc");
			}
		}




		[SoapElement(ElementName="vDup")]
		[XmlElement(ElementName="vDup")]
		public string gxTpr_Vdup
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_dupItem_Vdup; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_dupItem_Vdup = value;
				SetDirty("Vdup");
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
			gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_dupItem_Ndup = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_dupItem_Dvenc = "";
			gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_dupItem_Vdup = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_dupItem_Ndup;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_dupItem_Dvenc;
		 

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_dupItem_Vdup;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SdNotaFiscal.NFe.infNFe.cobr.dupItem", Namespace="Factory21")]
	public class SdtSdNotaFiscal_NFe_infNFe_cobr_dupItem_RESTInterface : GxGenericCollectionItem<SdtSdNotaFiscal_NFe_infNFe_cobr_dupItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdNotaFiscal_NFe_infNFe_cobr_dupItem_RESTInterface( ) : base()
		{	
		}

		public SdtSdNotaFiscal_NFe_infNFe_cobr_dupItem_RESTInterface( SdtSdNotaFiscal_NFe_infNFe_cobr_dupItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("nDup")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="nDup", Order=0)]
		public  string gxTpr_Ndup
		{
			get { 
				return sdt.gxTpr_Ndup;

			}
			set { 
				 sdt.gxTpr_Ndup = value;
			}
		}

		[JsonPropertyName("dVenc")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="dVenc", Order=1)]
		public  string gxTpr_Dvenc
		{
			get { 
				return sdt.gxTpr_Dvenc;

			}
			set { 
				 sdt.gxTpr_Dvenc = value;
			}
		}

		[JsonPropertyName("vDup")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="vDup", Order=2)]
		public  string gxTpr_Vdup
		{
			get { 
				return sdt.gxTpr_Vdup;

			}
			set { 
				 sdt.gxTpr_Vdup = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdNotaFiscal_NFe_infNFe_cobr_dupItem sdt
		{
			get { 
				return (SdtSdNotaFiscal_NFe_infNFe_cobr_dupItem)Sdt;
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
				sdt = new SdtSdNotaFiscal_NFe_infNFe_cobr_dupItem() ;
			}
		}
	}
	#endregion
}