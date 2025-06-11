/*
				   File: type_SdtSdEmpresas
			Description: SdEmpresas
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
	[XmlRoot(ElementName="SdEmpresas")]
	[XmlType(TypeName="SdEmpresas" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdEmpresas : GxUserType
	{
		public SdtSdEmpresas( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdEmpresas_Updated = (DateTime)(DateTime.MinValue);

			gxTv_SdtSdEmpresas_Taxid = "";

			gxTv_SdtSdEmpresas_Alias = "";

			gxTv_SdtSdEmpresas_Founded = "";

			gxTv_SdtSdEmpresas_Statusdate = "";

		}

		public SdtSdEmpresas(IGxContext context)
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
			datetime_STZ = gxTpr_Updated;
			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim( StringUtil.Str((decimal)(DateTimeUtil.Month(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "T";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Hour(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Minute(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Second(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("updated", sDateCnv, false);



			AddObjectProperty("taxId", gxTpr_Taxid, false);

			if (gxTv_SdtSdEmpresas_Company != null)
			{
				AddObjectProperty("company", gxTv_SdtSdEmpresas_Company, false);
			}

			AddObjectProperty("alias", gxTpr_Alias, false);


			AddObjectProperty("founded", gxTpr_Founded, false);


			AddObjectProperty("head", gxTpr_Head, false);


			AddObjectProperty("statusDate", gxTpr_Statusdate, false);

			if (gxTv_SdtSdEmpresas_Status != null)
			{
				AddObjectProperty("status", gxTv_SdtSdEmpresas_Status, false);
			}
			if (gxTv_SdtSdEmpresas_Address != null)
			{
				AddObjectProperty("address", gxTv_SdtSdEmpresas_Address, false);
			}
			if (gxTv_SdtSdEmpresas_Phones != null)
			{
				AddObjectProperty("phones", gxTv_SdtSdEmpresas_Phones, false);
			}
			if (gxTv_SdtSdEmpresas_Emails != null)
			{
				AddObjectProperty("emails", gxTv_SdtSdEmpresas_Emails, false);
			}
			if (gxTv_SdtSdEmpresas_Mainactivity != null)
			{
				AddObjectProperty("mainActivity", gxTv_SdtSdEmpresas_Mainactivity, false);
			}
			if (gxTv_SdtSdEmpresas_Sideactivities != null)
			{
				AddObjectProperty("sideActivities", gxTv_SdtSdEmpresas_Sideactivities, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="updated")]
		[XmlElement(ElementName="updated" , IsNullable=true)]
		public string gxTpr_Updated_Nullable
		{
			get {
				if ( gxTv_SdtSdEmpresas_Updated == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSdEmpresas_Updated).value ;
			}
			set {
				gxTv_SdtSdEmpresas_Updated = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Updated
		{
			get {
				return gxTv_SdtSdEmpresas_Updated; 
			}
			set {
				gxTv_SdtSdEmpresas_Updated = value;
				SetDirty("Updated");
			}
		}



		[SoapElement(ElementName="taxId")]
		[XmlElement(ElementName="taxId")]
		public string gxTpr_Taxid
		{
			get {
				return gxTv_SdtSdEmpresas_Taxid; 
			}
			set {
				gxTv_SdtSdEmpresas_Taxid = value;
				SetDirty("Taxid");
			}
		}



		[SoapElement(ElementName="company" )]
		[XmlElement(ElementName="company" )]
		public SdtSdEmpresas_company gxTpr_Company
		{
			get {
				if ( gxTv_SdtSdEmpresas_Company == null )
				{
					gxTv_SdtSdEmpresas_Company = new SdtSdEmpresas_company(context);
				}
				gxTv_SdtSdEmpresas_Company_N = false;
				SetDirty("Company");
				return gxTv_SdtSdEmpresas_Company;
			}
			set {
				gxTv_SdtSdEmpresas_Company_N = false;
				gxTv_SdtSdEmpresas_Company = value;
				SetDirty("Company");
			}

		}

		public void gxTv_SdtSdEmpresas_Company_SetNull()
		{
			gxTv_SdtSdEmpresas_Company_N = true;
			gxTv_SdtSdEmpresas_Company = null;
		}

		public bool gxTv_SdtSdEmpresas_Company_IsNull()
		{
			return gxTv_SdtSdEmpresas_Company == null;
		}
		public bool ShouldSerializegxTpr_Company_Json()
		{
				return (gxTv_SdtSdEmpresas_Company != null && gxTv_SdtSdEmpresas_Company.ShouldSerializeSdtJson());

		}



		[SoapElement(ElementName="alias")]
		[XmlElement(ElementName="alias")]
		public string gxTpr_Alias
		{
			get {
				return gxTv_SdtSdEmpresas_Alias; 
			}
			set {
				gxTv_SdtSdEmpresas_Alias = value;
				SetDirty("Alias");
			}
		}




		[SoapElement(ElementName="founded")]
		[XmlElement(ElementName="founded")]
		public string gxTpr_Founded
		{
			get {
				return gxTv_SdtSdEmpresas_Founded; 
			}
			set {
				gxTv_SdtSdEmpresas_Founded = value;
				SetDirty("Founded");
			}
		}




		[SoapElement(ElementName="head")]
		[XmlElement(ElementName="head")]
		public bool gxTpr_Head
		{
			get {
				return gxTv_SdtSdEmpresas_Head; 
			}
			set {
				gxTv_SdtSdEmpresas_Head = value;
				SetDirty("Head");
			}
		}




		[SoapElement(ElementName="statusDate")]
		[XmlElement(ElementName="statusDate")]
		public string gxTpr_Statusdate
		{
			get {
				return gxTv_SdtSdEmpresas_Statusdate; 
			}
			set {
				gxTv_SdtSdEmpresas_Statusdate = value;
				SetDirty("Statusdate");
			}
		}



		[SoapElement(ElementName="status" )]
		[XmlElement(ElementName="status" )]
		public SdtSdEmpresas_status gxTpr_Status
		{
			get {
				if ( gxTv_SdtSdEmpresas_Status == null )
				{
					gxTv_SdtSdEmpresas_Status = new SdtSdEmpresas_status(context);
				}
				gxTv_SdtSdEmpresas_Status_N = false;
				SetDirty("Status");
				return gxTv_SdtSdEmpresas_Status;
			}
			set {
				gxTv_SdtSdEmpresas_Status_N = false;
				gxTv_SdtSdEmpresas_Status = value;
				SetDirty("Status");
			}

		}

		public void gxTv_SdtSdEmpresas_Status_SetNull()
		{
			gxTv_SdtSdEmpresas_Status_N = true;
			gxTv_SdtSdEmpresas_Status = null;
		}

		public bool gxTv_SdtSdEmpresas_Status_IsNull()
		{
			return gxTv_SdtSdEmpresas_Status == null;
		}
		public bool ShouldSerializegxTpr_Status_Json()
		{
				return (gxTv_SdtSdEmpresas_Status != null && gxTv_SdtSdEmpresas_Status.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="address" )]
		[XmlElement(ElementName="address" )]
		public SdtSdEmpresas_address gxTpr_Address
		{
			get {
				if ( gxTv_SdtSdEmpresas_Address == null )
				{
					gxTv_SdtSdEmpresas_Address = new SdtSdEmpresas_address(context);
				}
				gxTv_SdtSdEmpresas_Address_N = false;
				SetDirty("Address");
				return gxTv_SdtSdEmpresas_Address;
			}
			set {
				gxTv_SdtSdEmpresas_Address_N = false;
				gxTv_SdtSdEmpresas_Address = value;
				SetDirty("Address");
			}

		}

		public void gxTv_SdtSdEmpresas_Address_SetNull()
		{
			gxTv_SdtSdEmpresas_Address_N = true;
			gxTv_SdtSdEmpresas_Address = null;
		}

		public bool gxTv_SdtSdEmpresas_Address_IsNull()
		{
			return gxTv_SdtSdEmpresas_Address == null;
		}
		public bool ShouldSerializegxTpr_Address_Json()
		{
				return (gxTv_SdtSdEmpresas_Address != null && gxTv_SdtSdEmpresas_Address.ShouldSerializeSdtJson());

		}



		[SoapElement(ElementName="phones" )]
		[XmlArray(ElementName="phones"  )]
		[XmlArrayItemAttribute(ElementName="phonesItem" , IsNullable=false )]
		public GXBaseCollection<SdtSdEmpresas_phonesItem> gxTpr_Phones
		{
			get {
				if ( gxTv_SdtSdEmpresas_Phones == null )
				{
					gxTv_SdtSdEmpresas_Phones = new GXBaseCollection<SdtSdEmpresas_phonesItem>( context, "SdEmpresas.phonesItem", "");
				}
				SetDirty("Phones");
				return gxTv_SdtSdEmpresas_Phones;
			}
			set {
				gxTv_SdtSdEmpresas_Phones_N = false;
				gxTv_SdtSdEmpresas_Phones = value;
				SetDirty("Phones");
			}
		}

		public void gxTv_SdtSdEmpresas_Phones_SetNull()
		{
			gxTv_SdtSdEmpresas_Phones_N = true;
			gxTv_SdtSdEmpresas_Phones = null;
		}

		public bool gxTv_SdtSdEmpresas_Phones_IsNull()
		{
			return gxTv_SdtSdEmpresas_Phones == null;
		}
		public bool ShouldSerializegxTpr_Phones_GxSimpleCollection_Json()
		{
			return gxTv_SdtSdEmpresas_Phones != null && gxTv_SdtSdEmpresas_Phones.Count > 0;

		}



		[SoapElement(ElementName="emails" )]
		[XmlArray(ElementName="emails"  )]
		[XmlArrayItemAttribute(ElementName="emailsItem" , IsNullable=false )]
		public GXBaseCollection<SdtSdEmpresas_emailsItem> gxTpr_Emails
		{
			get {
				if ( gxTv_SdtSdEmpresas_Emails == null )
				{
					gxTv_SdtSdEmpresas_Emails = new GXBaseCollection<SdtSdEmpresas_emailsItem>( context, "SdEmpresas.emailsItem", "");
				}
				SetDirty("Emails");
				return gxTv_SdtSdEmpresas_Emails;
			}
			set {
				gxTv_SdtSdEmpresas_Emails_N = false;
				gxTv_SdtSdEmpresas_Emails = value;
				SetDirty("Emails");
			}
		}

		public void gxTv_SdtSdEmpresas_Emails_SetNull()
		{
			gxTv_SdtSdEmpresas_Emails_N = true;
			gxTv_SdtSdEmpresas_Emails = null;
		}

		public bool gxTv_SdtSdEmpresas_Emails_IsNull()
		{
			return gxTv_SdtSdEmpresas_Emails == null;
		}
		public bool ShouldSerializegxTpr_Emails_GxSimpleCollection_Json()
		{
			return gxTv_SdtSdEmpresas_Emails != null && gxTv_SdtSdEmpresas_Emails.Count > 0;

		}


		[SoapElement(ElementName="mainActivity" )]
		[XmlElement(ElementName="mainActivity" )]
		public SdtSdEmpresas_mainActivity gxTpr_Mainactivity
		{
			get {
				if ( gxTv_SdtSdEmpresas_Mainactivity == null )
				{
					gxTv_SdtSdEmpresas_Mainactivity = new SdtSdEmpresas_mainActivity(context);
				}
				gxTv_SdtSdEmpresas_Mainactivity_N = false;
				SetDirty("Mainactivity");
				return gxTv_SdtSdEmpresas_Mainactivity;
			}
			set {
				gxTv_SdtSdEmpresas_Mainactivity_N = false;
				gxTv_SdtSdEmpresas_Mainactivity = value;
				SetDirty("Mainactivity");
			}

		}

		public void gxTv_SdtSdEmpresas_Mainactivity_SetNull()
		{
			gxTv_SdtSdEmpresas_Mainactivity_N = true;
			gxTv_SdtSdEmpresas_Mainactivity = null;
		}

		public bool gxTv_SdtSdEmpresas_Mainactivity_IsNull()
		{
			return gxTv_SdtSdEmpresas_Mainactivity == null;
		}
		public bool ShouldSerializegxTpr_Mainactivity_Json()
		{
				return (gxTv_SdtSdEmpresas_Mainactivity != null && gxTv_SdtSdEmpresas_Mainactivity.ShouldSerializeSdtJson());

		}



		[SoapElement(ElementName="sideActivities" )]
		[XmlArray(ElementName="sideActivities"  )]
		[XmlArrayItemAttribute(ElementName="sideActivitiesItem" , IsNullable=false )]
		public GXBaseCollection<SdtSdEmpresas_sideActivitiesItem> gxTpr_Sideactivities
		{
			get {
				if ( gxTv_SdtSdEmpresas_Sideactivities == null )
				{
					gxTv_SdtSdEmpresas_Sideactivities = new GXBaseCollection<SdtSdEmpresas_sideActivitiesItem>( context, "SdEmpresas.sideActivitiesItem", "");
				}
				SetDirty("Sideactivities");
				return gxTv_SdtSdEmpresas_Sideactivities;
			}
			set {
				gxTv_SdtSdEmpresas_Sideactivities_N = false;
				gxTv_SdtSdEmpresas_Sideactivities = value;
				SetDirty("Sideactivities");
			}
		}

		public void gxTv_SdtSdEmpresas_Sideactivities_SetNull()
		{
			gxTv_SdtSdEmpresas_Sideactivities_N = true;
			gxTv_SdtSdEmpresas_Sideactivities = null;
		}

		public bool gxTv_SdtSdEmpresas_Sideactivities_IsNull()
		{
			return gxTv_SdtSdEmpresas_Sideactivities == null;
		}
		public bool ShouldSerializegxTpr_Sideactivities_GxSimpleCollection_Json()
		{
			return gxTv_SdtSdEmpresas_Sideactivities != null && gxTv_SdtSdEmpresas_Sideactivities.Count > 0;

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
			gxTv_SdtSdEmpresas_Updated = (DateTime)(DateTime.MinValue);
			gxTv_SdtSdEmpresas_Taxid = "";

			gxTv_SdtSdEmpresas_Company_N = true;

			gxTv_SdtSdEmpresas_Alias = "";
			gxTv_SdtSdEmpresas_Founded = "";

			gxTv_SdtSdEmpresas_Statusdate = "";

			gxTv_SdtSdEmpresas_Status_N = true;


			gxTv_SdtSdEmpresas_Address_N = true;


			gxTv_SdtSdEmpresas_Phones_N = true;


			gxTv_SdtSdEmpresas_Emails_N = true;


			gxTv_SdtSdEmpresas_Mainactivity_N = true;


			gxTv_SdtSdEmpresas_Sideactivities_N = true;

			datetime_STZ = (DateTime)(DateTime.MinValue);
			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected DateTime datetime_STZ ;

		protected DateTime gxTv_SdtSdEmpresas_Updated;
		 

		protected string gxTv_SdtSdEmpresas_Taxid;
		 
		protected bool gxTv_SdtSdEmpresas_Company_N;
		protected SdtSdEmpresas_company gxTv_SdtSdEmpresas_Company = null; 


		protected string gxTv_SdtSdEmpresas_Alias;
		 

		protected string gxTv_SdtSdEmpresas_Founded;
		 

		protected bool gxTv_SdtSdEmpresas_Head;
		 

		protected string gxTv_SdtSdEmpresas_Statusdate;
		 
		protected bool gxTv_SdtSdEmpresas_Status_N;
		protected SdtSdEmpresas_status gxTv_SdtSdEmpresas_Status = null; 

		protected bool gxTv_SdtSdEmpresas_Address_N;
		protected SdtSdEmpresas_address gxTv_SdtSdEmpresas_Address = null; 

		protected bool gxTv_SdtSdEmpresas_Phones_N;
		protected GXBaseCollection<SdtSdEmpresas_phonesItem> gxTv_SdtSdEmpresas_Phones = null; 

		protected bool gxTv_SdtSdEmpresas_Emails_N;
		protected GXBaseCollection<SdtSdEmpresas_emailsItem> gxTv_SdtSdEmpresas_Emails = null; 

		protected bool gxTv_SdtSdEmpresas_Mainactivity_N;
		protected SdtSdEmpresas_mainActivity gxTv_SdtSdEmpresas_Mainactivity = null; 

		protected bool gxTv_SdtSdEmpresas_Sideactivities_N;
		protected GXBaseCollection<SdtSdEmpresas_sideActivitiesItem> gxTv_SdtSdEmpresas_Sideactivities = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdEmpresas", Namespace="Factory21")]
	public class SdtSdEmpresas_RESTInterface : GxGenericCollectionItem<SdtSdEmpresas>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdEmpresas_RESTInterface( ) : base()
		{	
		}

		public SdtSdEmpresas_RESTInterface( SdtSdEmpresas psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("updated")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="updated", Order=0)]
		public  string gxTpr_Updated
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Updated,context);

			}
			set { 
				sdt.gxTpr_Updated = DateTimeUtil.CToT2(value,context);
			}
		}

		[JsonPropertyName("taxId")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="taxId", Order=1)]
		public  string gxTpr_Taxid
		{
			get { 
				return sdt.gxTpr_Taxid;

			}
			set { 
				 sdt.gxTpr_Taxid = value;
			}
		}

		[JsonPropertyName("company")]
		[JsonPropertyOrder(2)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="company", Order=2, EmitDefaultValue=false)]
		public SdtSdEmpresas_company_RESTInterface gxTpr_Company
		{
			get {
				if (sdt.ShouldSerializegxTpr_Company_Json())
					return new SdtSdEmpresas_company_RESTInterface(sdt.gxTpr_Company);
				else
					return null;

			}

			set {
				sdt.gxTpr_Company = value.sdt;
			}

		}

		[JsonPropertyName("alias")]
		[JsonPropertyOrder(3)]
		[DataMember(Name="alias", Order=3)]
		public  string gxTpr_Alias
		{
			get { 
				return sdt.gxTpr_Alias;

			}
			set { 
				 sdt.gxTpr_Alias = value;
			}
		}

		[JsonPropertyName("founded")]
		[JsonPropertyOrder(4)]
		[DataMember(Name="founded", Order=4)]
		public  string gxTpr_Founded
		{
			get { 
				return sdt.gxTpr_Founded;

			}
			set { 
				 sdt.gxTpr_Founded = value;
			}
		}

		[JsonPropertyName("head")]
		[JsonPropertyOrder(5)]
		[JsonConverter(typeof(BoolStringJsonConverter))]
		[DataMember(Name="head", Order=5)]
		public bool gxTpr_Head
		{
			get { 
				return sdt.gxTpr_Head;

			}
			set { 
				sdt.gxTpr_Head = value;
			}
		}

		[JsonPropertyName("statusDate")]
		[JsonPropertyOrder(6)]
		[DataMember(Name="statusDate", Order=6)]
		public  string gxTpr_Statusdate
		{
			get { 
				return sdt.gxTpr_Statusdate;

			}
			set { 
				 sdt.gxTpr_Statusdate = value;
			}
		}

		[JsonPropertyName("status")]
		[JsonPropertyOrder(7)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="status", Order=7, EmitDefaultValue=false)]
		public SdtSdEmpresas_status_RESTInterface gxTpr_Status
		{
			get {
				if (sdt.ShouldSerializegxTpr_Status_Json())
					return new SdtSdEmpresas_status_RESTInterface(sdt.gxTpr_Status);
				else
					return null;

			}

			set {
				sdt.gxTpr_Status = value.sdt;
			}

		}

		[JsonPropertyName("address")]
		[JsonPropertyOrder(8)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="address", Order=8, EmitDefaultValue=false)]
		public SdtSdEmpresas_address_RESTInterface gxTpr_Address
		{
			get {
				if (sdt.ShouldSerializegxTpr_Address_Json())
					return new SdtSdEmpresas_address_RESTInterface(sdt.gxTpr_Address);
				else
					return null;

			}

			set {
				sdt.gxTpr_Address = value.sdt;
			}

		}

		[JsonPropertyName("phones")]
		[JsonPropertyOrder(9)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="phones", Order=9, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSdEmpresas_phonesItem_RESTInterface> gxTpr_Phones
		{
			get {
				if (sdt.ShouldSerializegxTpr_Phones_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSdEmpresas_phonesItem_RESTInterface>(sdt.gxTpr_Phones);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Phones);
			}
		}

		[JsonPropertyName("emails")]
		[JsonPropertyOrder(10)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="emails", Order=10, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSdEmpresas_emailsItem_RESTInterface> gxTpr_Emails
		{
			get {
				if (sdt.ShouldSerializegxTpr_Emails_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSdEmpresas_emailsItem_RESTInterface>(sdt.gxTpr_Emails);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Emails);
			}
		}

		[JsonPropertyName("mainActivity")]
		[JsonPropertyOrder(11)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="mainActivity", Order=11, EmitDefaultValue=false)]
		public SdtSdEmpresas_mainActivity_RESTInterface gxTpr_Mainactivity
		{
			get {
				if (sdt.ShouldSerializegxTpr_Mainactivity_Json())
					return new SdtSdEmpresas_mainActivity_RESTInterface(sdt.gxTpr_Mainactivity);
				else
					return null;

			}

			set {
				sdt.gxTpr_Mainactivity = value.sdt;
			}

		}

		[JsonPropertyName("sideActivities")]
		[JsonPropertyOrder(12)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="sideActivities", Order=12, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSdEmpresas_sideActivitiesItem_RESTInterface> gxTpr_Sideactivities
		{
			get {
				if (sdt.ShouldSerializegxTpr_Sideactivities_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSdEmpresas_sideActivitiesItem_RESTInterface>(sdt.gxTpr_Sideactivities);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Sideactivities);
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdEmpresas sdt
		{
			get { 
				return (SdtSdEmpresas)Sdt;
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
				sdt = new SdtSdEmpresas() ;
			}
		}
	}
	#endregion
}