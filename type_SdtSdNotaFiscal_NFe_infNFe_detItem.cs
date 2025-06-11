/*
				   File: type_SdtSdNotaFiscal_NFe_infNFe_detItem
			Description: det
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
	[XmlRoot(ElementName="SdNotaFiscal.NFe.infNFe.detItem")]
	[XmlType(TypeName="SdNotaFiscal.NFe.infNFe.detItem" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdNotaFiscal_NFe_infNFe_detItem : GxUserType
	{
		public SdtSdNotaFiscal_NFe_infNFe_detItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_Item_0 = "";

		}

		public SdtSdNotaFiscal_NFe_infNFe_detItem(IGxContext context)
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
				mapper["_nItem"] = "Item_0";

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
			if (gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_Prod != null)
			{
				AddObjectProperty("prod", gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_Prod, false);
			}
			if (gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_Imposto != null)
			{
				AddObjectProperty("imposto", gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_Imposto, false);
			}

			AddObjectProperty("_nItem", gxTpr_Item_0, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="prod" )]
		[XmlElement(ElementName="prod" )]
		public SdtSdNotaFiscal_NFe_infNFe_detItem_prod gxTpr_Prod
		{
			get {
				if ( gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_Prod == null )
				{
					gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_Prod = new SdtSdNotaFiscal_NFe_infNFe_detItem_prod(context);
				}
				gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_Prod_N = false;
				SetDirty("Prod");
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_Prod;
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_Prod_N = false;
				gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_Prod = value;
				SetDirty("Prod");
			}

		}

		public void gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_Prod_SetNull()
		{
			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_Prod_N = true;
			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_Prod = null;
		}

		public bool gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_Prod_IsNull()
		{
			return gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_Prod == null;
		}
		public bool ShouldSerializegxTpr_Prod_Json()
		{
				return (gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_Prod != null && gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_Prod.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="imposto" )]
		[XmlElement(ElementName="imposto" )]
		public SdtSdNotaFiscal_NFe_infNFe_detItem_imposto gxTpr_Imposto
		{
			get {
				if ( gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_Imposto == null )
				{
					gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_Imposto = new SdtSdNotaFiscal_NFe_infNFe_detItem_imposto(context);
				}
				gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_Imposto_N = false;
				SetDirty("Imposto");
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_Imposto;
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_Imposto_N = false;
				gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_Imposto = value;
				SetDirty("Imposto");
			}

		}

		public void gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_Imposto_SetNull()
		{
			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_Imposto_N = true;
			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_Imposto = null;
		}

		public bool gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_Imposto_IsNull()
		{
			return gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_Imposto == null;
		}
		public bool ShouldSerializegxTpr_Imposto_Json()
		{
				return (gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_Imposto != null && gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_Imposto.ShouldSerializeSdtJson());

		}



		[SoapElement(ElementName="Item_0")]
		[XmlElement(ElementName="Item_0")]
		public string gxTpr_Item_0
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_Item_0; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_Item_0 = value;
				SetDirty("Item_0");
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
			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_Prod_N = true;


			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_Imposto_N = true;

			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_Item_0 = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_Prod_N;
		protected SdtSdNotaFiscal_NFe_infNFe_detItem_prod gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_Prod = null; 

		protected bool gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_Imposto_N;
		protected SdtSdNotaFiscal_NFe_infNFe_detItem_imposto gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_Imposto = null; 


		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_Item_0;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SdNotaFiscal.NFe.infNFe.detItem", Namespace="Factory21")]
	public class SdtSdNotaFiscal_NFe_infNFe_detItem_RESTInterface : GxGenericCollectionItem<SdtSdNotaFiscal_NFe_infNFe_detItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdNotaFiscal_NFe_infNFe_detItem_RESTInterface( ) : base()
		{	
		}

		public SdtSdNotaFiscal_NFe_infNFe_detItem_RESTInterface( SdtSdNotaFiscal_NFe_infNFe_detItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("prod")]
		[JsonPropertyOrder(0)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="prod", Order=0, EmitDefaultValue=false)]
		public SdtSdNotaFiscal_NFe_infNFe_detItem_prod_RESTInterface gxTpr_Prod
		{
			get {
				if (sdt.ShouldSerializegxTpr_Prod_Json())
					return new SdtSdNotaFiscal_NFe_infNFe_detItem_prod_RESTInterface(sdt.gxTpr_Prod);
				else
					return null;

			}

			set {
				sdt.gxTpr_Prod = value.sdt;
			}

		}

		[JsonPropertyName("imposto")]
		[JsonPropertyOrder(1)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="imposto", Order=1, EmitDefaultValue=false)]
		public SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_RESTInterface gxTpr_Imposto
		{
			get {
				if (sdt.ShouldSerializegxTpr_Imposto_Json())
					return new SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_RESTInterface(sdt.gxTpr_Imposto);
				else
					return null;

			}

			set {
				sdt.gxTpr_Imposto = value.sdt;
			}

		}

		[JsonPropertyName("_nItem")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="_nItem", Order=2)]
		public  string gxTpr_Item_0
		{
			get { 
				return sdt.gxTpr_Item_0;

			}
			set { 
				 sdt.gxTpr_Item_0 = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdNotaFiscal_NFe_infNFe_detItem sdt
		{
			get { 
				return (SdtSdNotaFiscal_NFe_infNFe_detItem)Sdt;
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
				sdt = new SdtSdNotaFiscal_NFe_infNFe_detItem() ;
			}
		}
	}
	#endregion
}