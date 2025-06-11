/*
				   File: type_SdtSdDashboardFinanceiroCards_Item
			Description: SdDashboardFinanceiroCards
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
	[XmlRoot(ElementName="Item")]
	[XmlType(TypeName="Item" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdDashboardFinanceiroCards_Item : GxUserType
	{
		public SdtSdDashboardFinanceiroCards_Item( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdDashboardFinanceiroCards_Item_Valor = "";

			gxTv_SdtSdDashboardFinanceiroCards_Item_Title = "";

			gxTv_SdtSdDashboardFinanceiroCards_Item_Icon = "";

			gxTv_SdtSdDashboardFinanceiroCards_Item_Class = "";

			gxTv_SdtSdDashboardFinanceiroCards_Item_Moreinfo = "";

		}

		public SdtSdDashboardFinanceiroCards_Item(IGxContext context)
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
			AddObjectProperty("Valor", gxTpr_Valor, false);


			AddObjectProperty("Title", gxTpr_Title, false);


			AddObjectProperty("Visible", gxTpr_Visible, false);


			AddObjectProperty("Icon", gxTpr_Icon, false);


			AddObjectProperty("Class", gxTpr_Class, false);


			AddObjectProperty("MoreInfo", gxTpr_Moreinfo, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Valor")]
		[XmlElement(ElementName="Valor")]
		public string gxTpr_Valor
		{
			get {
				return gxTv_SdtSdDashboardFinanceiroCards_Item_Valor; 
			}
			set {
				gxTv_SdtSdDashboardFinanceiroCards_Item_Valor = value;
				SetDirty("Valor");
			}
		}




		[SoapElement(ElementName="Title")]
		[XmlElement(ElementName="Title")]
		public string gxTpr_Title
		{
			get {
				return gxTv_SdtSdDashboardFinanceiroCards_Item_Title; 
			}
			set {
				gxTv_SdtSdDashboardFinanceiroCards_Item_Title = value;
				SetDirty("Title");
			}
		}




		[SoapElement(ElementName="Visible")]
		[XmlElement(ElementName="Visible")]
		public bool gxTpr_Visible
		{
			get {
				return gxTv_SdtSdDashboardFinanceiroCards_Item_Visible; 
			}
			set {
				gxTv_SdtSdDashboardFinanceiroCards_Item_Visible = value;
				SetDirty("Visible");
			}
		}




		[SoapElement(ElementName="Icon")]
		[XmlElement(ElementName="Icon")]
		public string gxTpr_Icon
		{
			get {
				return gxTv_SdtSdDashboardFinanceiroCards_Item_Icon; 
			}
			set {
				gxTv_SdtSdDashboardFinanceiroCards_Item_Icon = value;
				SetDirty("Icon");
			}
		}




		[SoapElement(ElementName="Class")]
		[XmlElement(ElementName="Class")]
		public string gxTpr_Class
		{
			get {
				return gxTv_SdtSdDashboardFinanceiroCards_Item_Class; 
			}
			set {
				gxTv_SdtSdDashboardFinanceiroCards_Item_Class = value;
				SetDirty("Class");
			}
		}




		[SoapElement(ElementName="MoreInfo")]
		[XmlElement(ElementName="MoreInfo")]
		public string gxTpr_Moreinfo
		{
			get {
				return gxTv_SdtSdDashboardFinanceiroCards_Item_Moreinfo; 
			}
			set {
				gxTv_SdtSdDashboardFinanceiroCards_Item_Moreinfo = value;
				SetDirty("Moreinfo");
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
			gxTv_SdtSdDashboardFinanceiroCards_Item_Valor = "";
			gxTv_SdtSdDashboardFinanceiroCards_Item_Title = "";

			gxTv_SdtSdDashboardFinanceiroCards_Item_Icon = "";
			gxTv_SdtSdDashboardFinanceiroCards_Item_Class = "";
			gxTv_SdtSdDashboardFinanceiroCards_Item_Moreinfo = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSdDashboardFinanceiroCards_Item_Valor;
		 

		protected string gxTv_SdtSdDashboardFinanceiroCards_Item_Title;
		 

		protected bool gxTv_SdtSdDashboardFinanceiroCards_Item_Visible;
		 

		protected string gxTv_SdtSdDashboardFinanceiroCards_Item_Icon;
		 

		protected string gxTv_SdtSdDashboardFinanceiroCards_Item_Class;
		 

		protected string gxTv_SdtSdDashboardFinanceiroCards_Item_Moreinfo;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"Item", Namespace="Factory21")]
	public class SdtSdDashboardFinanceiroCards_Item_RESTInterface : GxGenericCollectionItem<SdtSdDashboardFinanceiroCards_Item>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdDashboardFinanceiroCards_Item_RESTInterface( ) : base()
		{	
		}

		public SdtSdDashboardFinanceiroCards_Item_RESTInterface( SdtSdDashboardFinanceiroCards_Item psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("Valor")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="Valor", Order=0)]
		public  string gxTpr_Valor
		{
			get { 
				return sdt.gxTpr_Valor;

			}
			set { 
				 sdt.gxTpr_Valor = value;
			}
		}

		[JsonPropertyName("Title")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="Title", Order=1)]
		public  string gxTpr_Title
		{
			get { 
				return sdt.gxTpr_Title;

			}
			set { 
				 sdt.gxTpr_Title = value;
			}
		}

		[JsonPropertyName("Visible")]
		[JsonPropertyOrder(2)]
		[JsonConverter(typeof(BoolStringJsonConverter))]
		[DataMember(Name="Visible", Order=2)]
		public bool gxTpr_Visible
		{
			get { 
				return sdt.gxTpr_Visible;

			}
			set { 
				sdt.gxTpr_Visible = value;
			}
		}

		[JsonPropertyName("Icon")]
		[JsonPropertyOrder(3)]
		[DataMember(Name="Icon", Order=3)]
		public  string gxTpr_Icon
		{
			get { 
				return sdt.gxTpr_Icon;

			}
			set { 
				 sdt.gxTpr_Icon = value;
			}
		}

		[JsonPropertyName("Class")]
		[JsonPropertyOrder(4)]
		[DataMember(Name="Class", Order=4)]
		public  string gxTpr_Class
		{
			get { 
				return sdt.gxTpr_Class;

			}
			set { 
				 sdt.gxTpr_Class = value;
			}
		}

		[JsonPropertyName("MoreInfo")]
		[JsonPropertyOrder(5)]
		[DataMember(Name="MoreInfo", Order=5)]
		public  string gxTpr_Moreinfo
		{
			get { 
				return sdt.gxTpr_Moreinfo;

			}
			set { 
				 sdt.gxTpr_Moreinfo = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdDashboardFinanceiroCards_Item sdt
		{
			get { 
				return (SdtSdDashboardFinanceiroCards_Item)Sdt;
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
				sdt = new SdtSdDashboardFinanceiroCards_Item() ;
			}
		}
	}
	#endregion
}