/*
				   File: type_SdtWPAddFuncSDT_WPAddFuncSDTItem
			Description: WPAddFuncSDT
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
	[XmlRoot(ElementName="WPAddFuncSDTItem")]
	[XmlType(TypeName="WPAddFuncSDTItem" , Namespace="Factory21" )]
	[Serializable]
	public class SdtWPAddFuncSDT_WPAddFuncSDTItem : GxUserType
	{
		public SdtWPAddFuncSDT_WPAddFuncSDTItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtWPAddFuncSDT_WPAddFuncSDTItem_Secfunctionalitymodule = "";

			gxTv_SdtWPAddFuncSDT_WPAddFuncSDTItem_Secfunctionalitykey = "";

			gxTv_SdtWPAddFuncSDT_WPAddFuncSDTItem_Secfunctionalitydescription = "";

			gxTv_SdtWPAddFuncSDT_WPAddFuncSDTItem_Secparentfunctionalitydescription = "";


		}

		public SdtWPAddFuncSDT_WPAddFuncSDTItem(IGxContext context)
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
			AddObjectProperty("SecFunctionalityId", gxTpr_Secfunctionalityid, false);


			AddObjectProperty("SecFunctionalityModule", gxTpr_Secfunctionalitymodule, false);


			AddObjectProperty("SecFunctionalityKey", gxTpr_Secfunctionalitykey, false);


			AddObjectProperty("SecFunctionalityDescription", gxTpr_Secfunctionalitydescription, false);


			AddObjectProperty("SecFunctionalityType", gxTpr_Secfunctionalitytype, false);


			AddObjectProperty("SecParentFunctionalityId", gxTpr_Secparentfunctionalityid, false);


			AddObjectProperty("SecParentFunctionalityDescription", gxTpr_Secparentfunctionalitydescription, false);


			AddObjectProperty("SecFunctionalityActive", gxTpr_Secfunctionalityactive, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="SecFunctionalityId")]
		[XmlElement(ElementName="SecFunctionalityId")]
		public long gxTpr_Secfunctionalityid
		{
			get {
				return gxTv_SdtWPAddFuncSDT_WPAddFuncSDTItem_Secfunctionalityid; 
			}
			set {
				gxTv_SdtWPAddFuncSDT_WPAddFuncSDTItem_Secfunctionalityid = value;
				SetDirty("Secfunctionalityid");
			}
		}




		[SoapElement(ElementName="SecFunctionalityModule")]
		[XmlElement(ElementName="SecFunctionalityModule")]
		public string gxTpr_Secfunctionalitymodule
		{
			get {
				return gxTv_SdtWPAddFuncSDT_WPAddFuncSDTItem_Secfunctionalitymodule; 
			}
			set {
				gxTv_SdtWPAddFuncSDT_WPAddFuncSDTItem_Secfunctionalitymodule = value;
				SetDirty("Secfunctionalitymodule");
			}
		}




		[SoapElement(ElementName="SecFunctionalityKey")]
		[XmlElement(ElementName="SecFunctionalityKey")]
		public string gxTpr_Secfunctionalitykey
		{
			get {
				return gxTv_SdtWPAddFuncSDT_WPAddFuncSDTItem_Secfunctionalitykey; 
			}
			set {
				gxTv_SdtWPAddFuncSDT_WPAddFuncSDTItem_Secfunctionalitykey = value;
				SetDirty("Secfunctionalitykey");
			}
		}




		[SoapElement(ElementName="SecFunctionalityDescription")]
		[XmlElement(ElementName="SecFunctionalityDescription")]
		public string gxTpr_Secfunctionalitydescription
		{
			get {
				return gxTv_SdtWPAddFuncSDT_WPAddFuncSDTItem_Secfunctionalitydescription; 
			}
			set {
				gxTv_SdtWPAddFuncSDT_WPAddFuncSDTItem_Secfunctionalitydescription = value;
				SetDirty("Secfunctionalitydescription");
			}
		}




		[SoapElement(ElementName="SecFunctionalityType")]
		[XmlElement(ElementName="SecFunctionalityType")]
		public short gxTpr_Secfunctionalitytype
		{
			get {
				return gxTv_SdtWPAddFuncSDT_WPAddFuncSDTItem_Secfunctionalitytype; 
			}
			set {
				gxTv_SdtWPAddFuncSDT_WPAddFuncSDTItem_Secfunctionalitytype = value;
				SetDirty("Secfunctionalitytype");
			}
		}




		[SoapElement(ElementName="SecParentFunctionalityId")]
		[XmlElement(ElementName="SecParentFunctionalityId")]
		public long gxTpr_Secparentfunctionalityid
		{
			get {
				return gxTv_SdtWPAddFuncSDT_WPAddFuncSDTItem_Secparentfunctionalityid; 
			}
			set {
				gxTv_SdtWPAddFuncSDT_WPAddFuncSDTItem_Secparentfunctionalityid = value;
				SetDirty("Secparentfunctionalityid");
			}
		}




		[SoapElement(ElementName="SecParentFunctionalityDescription")]
		[XmlElement(ElementName="SecParentFunctionalityDescription")]
		public string gxTpr_Secparentfunctionalitydescription
		{
			get {
				return gxTv_SdtWPAddFuncSDT_WPAddFuncSDTItem_Secparentfunctionalitydescription; 
			}
			set {
				gxTv_SdtWPAddFuncSDT_WPAddFuncSDTItem_Secparentfunctionalitydescription = value;
				SetDirty("Secparentfunctionalitydescription");
			}
		}




		[SoapElement(ElementName="SecFunctionalityActive")]
		[XmlElement(ElementName="SecFunctionalityActive")]
		public bool gxTpr_Secfunctionalityactive
		{
			get {
				return gxTv_SdtWPAddFuncSDT_WPAddFuncSDTItem_Secfunctionalityactive; 
			}
			set {
				gxTv_SdtWPAddFuncSDT_WPAddFuncSDTItem_Secfunctionalityactive = value;
				SetDirty("Secfunctionalityactive");
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
			gxTv_SdtWPAddFuncSDT_WPAddFuncSDTItem_Secfunctionalitymodule = "";
			gxTv_SdtWPAddFuncSDT_WPAddFuncSDTItem_Secfunctionalitykey = "";
			gxTv_SdtWPAddFuncSDT_WPAddFuncSDTItem_Secfunctionalitydescription = "";


			gxTv_SdtWPAddFuncSDT_WPAddFuncSDTItem_Secparentfunctionalitydescription = "";

			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtWPAddFuncSDT_WPAddFuncSDTItem_Secfunctionalityid;
		 

		protected string gxTv_SdtWPAddFuncSDT_WPAddFuncSDTItem_Secfunctionalitymodule;
		 

		protected string gxTv_SdtWPAddFuncSDT_WPAddFuncSDTItem_Secfunctionalitykey;
		 

		protected string gxTv_SdtWPAddFuncSDT_WPAddFuncSDTItem_Secfunctionalitydescription;
		 

		protected short gxTv_SdtWPAddFuncSDT_WPAddFuncSDTItem_Secfunctionalitytype;
		 

		protected long gxTv_SdtWPAddFuncSDT_WPAddFuncSDTItem_Secparentfunctionalityid;
		 

		protected string gxTv_SdtWPAddFuncSDT_WPAddFuncSDTItem_Secparentfunctionalitydescription;
		 

		protected bool gxTv_SdtWPAddFuncSDT_WPAddFuncSDTItem_Secfunctionalityactive;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"WPAddFuncSDTItem", Namespace="Factory21")]
	public class SdtWPAddFuncSDT_WPAddFuncSDTItem_RESTInterface : GxGenericCollectionItem<SdtWPAddFuncSDT_WPAddFuncSDTItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWPAddFuncSDT_WPAddFuncSDTItem_RESTInterface( ) : base()
		{	
		}

		public SdtWPAddFuncSDT_WPAddFuncSDTItem_RESTInterface( SdtWPAddFuncSDT_WPAddFuncSDTItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("SecFunctionalityId")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="SecFunctionalityId", Order=0)]
		public  string gxTpr_Secfunctionalityid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Secfunctionalityid, 10, 0));

			}
			set { 
				sdt.gxTpr_Secfunctionalityid = (long) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("SecFunctionalityModule")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="SecFunctionalityModule", Order=1)]
		public  string gxTpr_Secfunctionalitymodule
		{
			get { 
				return sdt.gxTpr_Secfunctionalitymodule;

			}
			set { 
				 sdt.gxTpr_Secfunctionalitymodule = value;
			}
		}

		[JsonPropertyName("SecFunctionalityKey")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="SecFunctionalityKey", Order=2)]
		public  string gxTpr_Secfunctionalitykey
		{
			get { 
				return sdt.gxTpr_Secfunctionalitykey;

			}
			set { 
				 sdt.gxTpr_Secfunctionalitykey = value;
			}
		}

		[JsonPropertyName("SecFunctionalityDescription")]
		[JsonPropertyOrder(3)]
		[DataMember(Name="SecFunctionalityDescription", Order=3)]
		public  string gxTpr_Secfunctionalitydescription
		{
			get { 
				return sdt.gxTpr_Secfunctionalitydescription;

			}
			set { 
				 sdt.gxTpr_Secfunctionalitydescription = value;
			}
		}

		[JsonPropertyName("SecFunctionalityType")]
		[JsonPropertyOrder(4)]
		[DataMember(Name="SecFunctionalityType", Order=4)]
		public short gxTpr_Secfunctionalitytype
		{
			get { 
				return sdt.gxTpr_Secfunctionalitytype;

			}
			set { 
				sdt.gxTpr_Secfunctionalitytype = value;
			}
		}

		[JsonPropertyName("SecParentFunctionalityId")]
		[JsonPropertyOrder(5)]
		[DataMember(Name="SecParentFunctionalityId", Order=5)]
		public  string gxTpr_Secparentfunctionalityid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Secparentfunctionalityid, 10, 0));

			}
			set { 
				sdt.gxTpr_Secparentfunctionalityid = (long) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("SecParentFunctionalityDescription")]
		[JsonPropertyOrder(6)]
		[DataMember(Name="SecParentFunctionalityDescription", Order=6)]
		public  string gxTpr_Secparentfunctionalitydescription
		{
			get { 
				return sdt.gxTpr_Secparentfunctionalitydescription;

			}
			set { 
				 sdt.gxTpr_Secparentfunctionalitydescription = value;
			}
		}

		[JsonPropertyName("SecFunctionalityActive")]
		[JsonPropertyOrder(7)]
		[JsonConverter(typeof(BoolStringJsonConverter))]
		[DataMember(Name="SecFunctionalityActive", Order=7)]
		public bool gxTpr_Secfunctionalityactive
		{
			get { 
				return sdt.gxTpr_Secfunctionalityactive;

			}
			set { 
				sdt.gxTpr_Secfunctionalityactive = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtWPAddFuncSDT_WPAddFuncSDTItem sdt
		{
			get { 
				return (SdtWPAddFuncSDT_WPAddFuncSDTItem)Sdt;
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
				sdt = new SdtWPAddFuncSDT_WPAddFuncSDTItem() ;
			}
		}
	}
	#endregion
}