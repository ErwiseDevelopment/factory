/*
				   File: type_SdtSdEmpresas_address
			Description: address
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
	[XmlRoot(ElementName="SdEmpresas.address")]
	[XmlType(TypeName="SdEmpresas.address" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdEmpresas_address : GxUserType
	{
		public SdtSdEmpresas_address( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdEmpresas_address_Street = "";

			gxTv_SdtSdEmpresas_address_Number = "";

			gxTv_SdtSdEmpresas_address_Details = "";

			gxTv_SdtSdEmpresas_address_District = "";

			gxTv_SdtSdEmpresas_address_City = "";

			gxTv_SdtSdEmpresas_address_State = "";

			gxTv_SdtSdEmpresas_address_Zip = "";

		}

		public SdtSdEmpresas_address(IGxContext context)
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
			AddObjectProperty("municipality", gxTpr_Municipality, false);


			AddObjectProperty("street", gxTpr_Street, false);


			AddObjectProperty("number", gxTpr_Number, false);


			AddObjectProperty("details", gxTpr_Details, false);


			AddObjectProperty("district", gxTpr_District, false);


			AddObjectProperty("city", gxTpr_City, false);


			AddObjectProperty("state", gxTpr_State, false);


			AddObjectProperty("zip", gxTpr_Zip, false);

			if (gxTv_SdtSdEmpresas_address_Country != null)
			{
				AddObjectProperty("country", gxTv_SdtSdEmpresas_address_Country, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="municipality")]
		[XmlElement(ElementName="municipality")]
		public string gxTpr_Municipality_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdEmpresas_address_Municipality, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdEmpresas_address_Municipality = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Municipality
		{
			get {
				return gxTv_SdtSdEmpresas_address_Municipality; 
			}
			set {
				gxTv_SdtSdEmpresas_address_Municipality = value;
				SetDirty("Municipality");
			}
		}




		[SoapElement(ElementName="street")]
		[XmlElement(ElementName="street")]
		public string gxTpr_Street
		{
			get {
				return gxTv_SdtSdEmpresas_address_Street; 
			}
			set {
				gxTv_SdtSdEmpresas_address_Street = value;
				SetDirty("Street");
			}
		}




		[SoapElement(ElementName="number")]
		[XmlElement(ElementName="number")]
		public string gxTpr_Number
		{
			get {
				return gxTv_SdtSdEmpresas_address_Number; 
			}
			set {
				gxTv_SdtSdEmpresas_address_Number = value;
				SetDirty("Number");
			}
		}




		[SoapElement(ElementName="details")]
		[XmlElement(ElementName="details")]
		public string gxTpr_Details
		{
			get {
				return gxTv_SdtSdEmpresas_address_Details; 
			}
			set {
				gxTv_SdtSdEmpresas_address_Details = value;
				SetDirty("Details");
			}
		}




		[SoapElement(ElementName="district")]
		[XmlElement(ElementName="district")]
		public string gxTpr_District
		{
			get {
				return gxTv_SdtSdEmpresas_address_District; 
			}
			set {
				gxTv_SdtSdEmpresas_address_District = value;
				SetDirty("District");
			}
		}




		[SoapElement(ElementName="city")]
		[XmlElement(ElementName="city")]
		public string gxTpr_City
		{
			get {
				return gxTv_SdtSdEmpresas_address_City; 
			}
			set {
				gxTv_SdtSdEmpresas_address_City = value;
				SetDirty("City");
			}
		}




		[SoapElement(ElementName="state")]
		[XmlElement(ElementName="state")]
		public string gxTpr_State
		{
			get {
				return gxTv_SdtSdEmpresas_address_State; 
			}
			set {
				gxTv_SdtSdEmpresas_address_State = value;
				SetDirty("State");
			}
		}




		[SoapElement(ElementName="zip")]
		[XmlElement(ElementName="zip")]
		public string gxTpr_Zip
		{
			get {
				return gxTv_SdtSdEmpresas_address_Zip; 
			}
			set {
				gxTv_SdtSdEmpresas_address_Zip = value;
				SetDirty("Zip");
			}
		}



		[SoapElement(ElementName="country" )]
		[XmlElement(ElementName="country" )]
		public SdtSdEmpresas_address_country gxTpr_Country
		{
			get {
				if ( gxTv_SdtSdEmpresas_address_Country == null )
				{
					gxTv_SdtSdEmpresas_address_Country = new SdtSdEmpresas_address_country(context);
				}
				gxTv_SdtSdEmpresas_address_Country_N = false;
				SetDirty("Country");
				return gxTv_SdtSdEmpresas_address_Country;
			}
			set {
				gxTv_SdtSdEmpresas_address_Country_N = false;
				gxTv_SdtSdEmpresas_address_Country = value;
				SetDirty("Country");
			}

		}

		public void gxTv_SdtSdEmpresas_address_Country_SetNull()
		{
			gxTv_SdtSdEmpresas_address_Country_N = true;
			gxTv_SdtSdEmpresas_address_Country = null;
		}

		public bool gxTv_SdtSdEmpresas_address_Country_IsNull()
		{
			return gxTv_SdtSdEmpresas_address_Country == null;
		}
		public bool ShouldSerializegxTpr_Country_Json()
		{
				return (gxTv_SdtSdEmpresas_address_Country != null && gxTv_SdtSdEmpresas_address_Country.ShouldSerializeSdtJson());

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
			gxTv_SdtSdEmpresas_address_Street = "";
			gxTv_SdtSdEmpresas_address_Number = "";
			gxTv_SdtSdEmpresas_address_Details = "";
			gxTv_SdtSdEmpresas_address_District = "";
			gxTv_SdtSdEmpresas_address_City = "";
			gxTv_SdtSdEmpresas_address_State = "";
			gxTv_SdtSdEmpresas_address_Zip = "";

			gxTv_SdtSdEmpresas_address_Country_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected decimal gxTv_SdtSdEmpresas_address_Municipality;
		 

		protected string gxTv_SdtSdEmpresas_address_Street;
		 

		protected string gxTv_SdtSdEmpresas_address_Number;
		 

		protected string gxTv_SdtSdEmpresas_address_Details;
		 

		protected string gxTv_SdtSdEmpresas_address_District;
		 

		protected string gxTv_SdtSdEmpresas_address_City;
		 

		protected string gxTv_SdtSdEmpresas_address_State;
		 

		protected string gxTv_SdtSdEmpresas_address_Zip;
		 
		protected bool gxTv_SdtSdEmpresas_address_Country_N;
		protected SdtSdEmpresas_address_country gxTv_SdtSdEmpresas_address_Country = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdEmpresas.address", Namespace="Factory21")]
	public class SdtSdEmpresas_address_RESTInterface : GxGenericCollectionItem<SdtSdEmpresas_address>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdEmpresas_address_RESTInterface( ) : base()
		{	
		}

		public SdtSdEmpresas_address_RESTInterface( SdtSdEmpresas_address psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("municipality")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="municipality", Order=0)]
		public  string gxTpr_Municipality
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Municipality, 10, 5));

			}
			set { 
				sdt.gxTpr_Municipality =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("street")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="street", Order=1)]
		public  string gxTpr_Street
		{
			get { 
				return sdt.gxTpr_Street;

			}
			set { 
				 sdt.gxTpr_Street = value;
			}
		}

		[JsonPropertyName("number")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="number", Order=2)]
		public  string gxTpr_Number
		{
			get { 
				return sdt.gxTpr_Number;

			}
			set { 
				 sdt.gxTpr_Number = value;
			}
		}

		[JsonPropertyName("details")]
		[JsonPropertyOrder(3)]
		[DataMember(Name="details", Order=3)]
		public  string gxTpr_Details
		{
			get { 
				return sdt.gxTpr_Details;

			}
			set { 
				 sdt.gxTpr_Details = value;
			}
		}

		[JsonPropertyName("district")]
		[JsonPropertyOrder(4)]
		[DataMember(Name="district", Order=4)]
		public  string gxTpr_District
		{
			get { 
				return sdt.gxTpr_District;

			}
			set { 
				 sdt.gxTpr_District = value;
			}
		}

		[JsonPropertyName("city")]
		[JsonPropertyOrder(5)]
		[DataMember(Name="city", Order=5)]
		public  string gxTpr_City
		{
			get { 
				return sdt.gxTpr_City;

			}
			set { 
				 sdt.gxTpr_City = value;
			}
		}

		[JsonPropertyName("state")]
		[JsonPropertyOrder(6)]
		[DataMember(Name="state", Order=6)]
		public  string gxTpr_State
		{
			get { 
				return sdt.gxTpr_State;

			}
			set { 
				 sdt.gxTpr_State = value;
			}
		}

		[JsonPropertyName("zip")]
		[JsonPropertyOrder(7)]
		[DataMember(Name="zip", Order=7)]
		public  string gxTpr_Zip
		{
			get { 
				return sdt.gxTpr_Zip;

			}
			set { 
				 sdt.gxTpr_Zip = value;
			}
		}

		[JsonPropertyName("country")]
		[JsonPropertyOrder(8)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="country", Order=8, EmitDefaultValue=false)]
		public SdtSdEmpresas_address_country_RESTInterface gxTpr_Country
		{
			get {
				if (sdt.ShouldSerializegxTpr_Country_Json())
					return new SdtSdEmpresas_address_country_RESTInterface(sdt.gxTpr_Country);
				else
					return null;

			}

			set {
				sdt.gxTpr_Country = value.sdt;
			}

		}


		#endregion
		[JsonIgnore]
		public SdtSdEmpresas_address sdt
		{
			get { 
				return (SdtSdEmpresas_address)Sdt;
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
				sdt = new SdtSdEmpresas_address() ;
			}
		}
	}
	#endregion
}