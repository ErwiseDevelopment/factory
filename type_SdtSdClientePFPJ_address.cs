/*
				   File: type_SdtSdClientePFPJ_address
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
	[XmlRoot(ElementName="SdClientePFPJ.address")]
	[XmlType(TypeName="SdClientePFPJ.address" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdClientePFPJ_address : GxUserType
	{
		public SdtSdClientePFPJ_address( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdClientePFPJ_address_Type = "";
			gxTv_SdtSdClientePFPJ_address_Type_N = true;

			gxTv_SdtSdClientePFPJ_address_Zip_code = "";
			gxTv_SdtSdClientePFPJ_address_Zip_code_N = true;

			gxTv_SdtSdClientePFPJ_address_Street = "";
			gxTv_SdtSdClientePFPJ_address_Street_N = true;

			gxTv_SdtSdClientePFPJ_address_Neighborhood = "";
			gxTv_SdtSdClientePFPJ_address_Neighborhood_N = true;

			gxTv_SdtSdClientePFPJ_address_City = "";
			gxTv_SdtSdClientePFPJ_address_City_N = true;

			gxTv_SdtSdClientePFPJ_address_Municipality_code = "";
			gxTv_SdtSdClientePFPJ_address_Municipality_code_N = true;

			gxTv_SdtSdClientePFPJ_address_Number = "";
			gxTv_SdtSdClientePFPJ_address_Number_N = true;

			gxTv_SdtSdClientePFPJ_address_Complement = "";
			gxTv_SdtSdClientePFPJ_address_Complement_N = true;

		}

		public SdtSdClientePFPJ_address(IGxContext context)
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
			if (ShouldSerializegxTpr_Type_Json())
			{	
				AddObjectProperty("type", gxTpr_Type, false);
			}


			if (ShouldSerializegxTpr_Zip_code_Json())
			{	
				AddObjectProperty("zip_code", gxTpr_Zip_code, false);
			}


			if (ShouldSerializegxTpr_Street_Json())
			{	
				AddObjectProperty("street", gxTpr_Street, false);
			}


			if (ShouldSerializegxTpr_Neighborhood_Json())
			{	
				AddObjectProperty("neighborhood", gxTpr_Neighborhood, false);
			}


			if (ShouldSerializegxTpr_City_Json())
			{	
				AddObjectProperty("city", gxTpr_City, false);
			}


			if (ShouldSerializegxTpr_Municipality_code_Json())
			{	
				AddObjectProperty("municipality_code", gxTpr_Municipality_code, false);
			}


			if (ShouldSerializegxTpr_Number_Json())
			{	
				AddObjectProperty("number", gxTpr_Number, false);
			}


			if (ShouldSerializegxTpr_Complement_Json())
			{	
				AddObjectProperty("complement", gxTpr_Complement, false);
			}

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="type")]
		[XmlElement(ElementName="type")]
		public string gxTpr_Type
		{
			get {
				return gxTv_SdtSdClientePFPJ_address_Type; 
			}
			set {
				gxTv_SdtSdClientePFPJ_address_Type_N = false;
				gxTv_SdtSdClientePFPJ_address_Type = value;
				SetDirty("Type");
			}
		}

		public bool ShouldSerializegxTpr_Type_Json()
		{
			return !gxTv_SdtSdClientePFPJ_address_Type_N;

		}



		[SoapElement(ElementName="zip_code")]
		[XmlElement(ElementName="zip_code")]
		public string gxTpr_Zip_code
		{
			get {
				return gxTv_SdtSdClientePFPJ_address_Zip_code; 
			}
			set {
				gxTv_SdtSdClientePFPJ_address_Zip_code_N = false;
				gxTv_SdtSdClientePFPJ_address_Zip_code = value;
				SetDirty("Zip_code");
			}
		}

		public bool ShouldSerializegxTpr_Zip_code_Json()
		{
			return !gxTv_SdtSdClientePFPJ_address_Zip_code_N;

		}



		[SoapElement(ElementName="street")]
		[XmlElement(ElementName="street")]
		public string gxTpr_Street
		{
			get {
				return gxTv_SdtSdClientePFPJ_address_Street; 
			}
			set {
				gxTv_SdtSdClientePFPJ_address_Street_N = false;
				gxTv_SdtSdClientePFPJ_address_Street = value;
				SetDirty("Street");
			}
		}

		public bool ShouldSerializegxTpr_Street_Json()
		{
			return !gxTv_SdtSdClientePFPJ_address_Street_N;

		}



		[SoapElement(ElementName="neighborhood")]
		[XmlElement(ElementName="neighborhood")]
		public string gxTpr_Neighborhood
		{
			get {
				return gxTv_SdtSdClientePFPJ_address_Neighborhood; 
			}
			set {
				gxTv_SdtSdClientePFPJ_address_Neighborhood_N = false;
				gxTv_SdtSdClientePFPJ_address_Neighborhood = value;
				SetDirty("Neighborhood");
			}
		}

		public bool ShouldSerializegxTpr_Neighborhood_Json()
		{
			return !gxTv_SdtSdClientePFPJ_address_Neighborhood_N;

		}



		[SoapElement(ElementName="city")]
		[XmlElement(ElementName="city")]
		public string gxTpr_City
		{
			get {
				return gxTv_SdtSdClientePFPJ_address_City; 
			}
			set {
				gxTv_SdtSdClientePFPJ_address_City_N = false;
				gxTv_SdtSdClientePFPJ_address_City = value;
				SetDirty("City");
			}
		}

		public bool ShouldSerializegxTpr_City_Json()
		{
			return !gxTv_SdtSdClientePFPJ_address_City_N;

		}



		[SoapElement(ElementName="municipality_code")]
		[XmlElement(ElementName="municipality_code")]
		public string gxTpr_Municipality_code
		{
			get {
				return gxTv_SdtSdClientePFPJ_address_Municipality_code; 
			}
			set {
				gxTv_SdtSdClientePFPJ_address_Municipality_code_N = false;
				gxTv_SdtSdClientePFPJ_address_Municipality_code = value;
				SetDirty("Municipality_code");
			}
		}

		public bool ShouldSerializegxTpr_Municipality_code_Json()
		{
			return !gxTv_SdtSdClientePFPJ_address_Municipality_code_N;

		}



		[SoapElement(ElementName="number")]
		[XmlElement(ElementName="number")]
		public string gxTpr_Number
		{
			get {
				return gxTv_SdtSdClientePFPJ_address_Number; 
			}
			set {
				gxTv_SdtSdClientePFPJ_address_Number_N = false;
				gxTv_SdtSdClientePFPJ_address_Number = value;
				SetDirty("Number");
			}
		}

		public bool ShouldSerializegxTpr_Number_Json()
		{
			return !gxTv_SdtSdClientePFPJ_address_Number_N;

		}



		[SoapElement(ElementName="complement")]
		[XmlElement(ElementName="complement")]
		public string gxTpr_Complement
		{
			get {
				return gxTv_SdtSdClientePFPJ_address_Complement; 
			}
			set {
				gxTv_SdtSdClientePFPJ_address_Complement_N = false;
				gxTv_SdtSdClientePFPJ_address_Complement = value;
				SetDirty("Complement");
			}
		}

		public bool ShouldSerializegxTpr_Complement_Json()
		{
			return !gxTv_SdtSdClientePFPJ_address_Complement_N;

		}


		public override bool ShouldSerializeSdtJson()
		{
			return (
				 ShouldSerializegxTpr_Type_Json()|| 
				 ShouldSerializegxTpr_Zip_code_Json()|| 
				 ShouldSerializegxTpr_Street_Json()|| 
				 ShouldSerializegxTpr_Neighborhood_Json()|| 
				 ShouldSerializegxTpr_City_Json()|| 
				 ShouldSerializegxTpr_Municipality_code_Json()|| 
				 ShouldSerializegxTpr_Number_Json()|| 
				 ShouldSerializegxTpr_Complement_Json()||  
				false);
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
			gxTv_SdtSdClientePFPJ_address_Type = "";
			gxTv_SdtSdClientePFPJ_address_Type_N = true;

			gxTv_SdtSdClientePFPJ_address_Zip_code = "";
			gxTv_SdtSdClientePFPJ_address_Zip_code_N = true;

			gxTv_SdtSdClientePFPJ_address_Street = "";
			gxTv_SdtSdClientePFPJ_address_Street_N = true;

			gxTv_SdtSdClientePFPJ_address_Neighborhood = "";
			gxTv_SdtSdClientePFPJ_address_Neighborhood_N = true;

			gxTv_SdtSdClientePFPJ_address_City = "";
			gxTv_SdtSdClientePFPJ_address_City_N = true;

			gxTv_SdtSdClientePFPJ_address_Municipality_code = "";
			gxTv_SdtSdClientePFPJ_address_Municipality_code_N = true;

			gxTv_SdtSdClientePFPJ_address_Number = "";
			gxTv_SdtSdClientePFPJ_address_Number_N = true;

			gxTv_SdtSdClientePFPJ_address_Complement = "";
			gxTv_SdtSdClientePFPJ_address_Complement_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSdClientePFPJ_address_Type;
		protected bool gxTv_SdtSdClientePFPJ_address_Type_N;
		 

		protected string gxTv_SdtSdClientePFPJ_address_Zip_code;
		protected bool gxTv_SdtSdClientePFPJ_address_Zip_code_N;
		 

		protected string gxTv_SdtSdClientePFPJ_address_Street;
		protected bool gxTv_SdtSdClientePFPJ_address_Street_N;
		 

		protected string gxTv_SdtSdClientePFPJ_address_Neighborhood;
		protected bool gxTv_SdtSdClientePFPJ_address_Neighborhood_N;
		 

		protected string gxTv_SdtSdClientePFPJ_address_City;
		protected bool gxTv_SdtSdClientePFPJ_address_City_N;
		 

		protected string gxTv_SdtSdClientePFPJ_address_Municipality_code;
		protected bool gxTv_SdtSdClientePFPJ_address_Municipality_code_N;
		 

		protected string gxTv_SdtSdClientePFPJ_address_Number;
		protected bool gxTv_SdtSdClientePFPJ_address_Number_N;
		 

		protected string gxTv_SdtSdClientePFPJ_address_Complement;
		protected bool gxTv_SdtSdClientePFPJ_address_Complement_N;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdClientePFPJ.address", Namespace="Factory21")]
	public class SdtSdClientePFPJ_address_RESTInterface : GxGenericCollectionItem<SdtSdClientePFPJ_address>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdClientePFPJ_address_RESTInterface( ) : base()
		{	
		}

		public SdtSdClientePFPJ_address_RESTInterface( SdtSdClientePFPJ_address psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("type")]
		[JsonPropertyOrder(0)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="type", Order=0, EmitDefaultValue=false)]
		public  string gxTpr_Type
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Type_Json())
					return sdt.gxTpr_Type;
				else
					return null;

			}
			set { 
				 sdt.gxTpr_Type = value;
			}
		}

		[JsonPropertyName("zip_code")]
		[JsonPropertyOrder(1)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="zip_code", Order=1, EmitDefaultValue=false)]
		public  string gxTpr_Zip_code
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Zip_code_Json())
					return sdt.gxTpr_Zip_code;
				else
					return null;

			}
			set { 
				 sdt.gxTpr_Zip_code = value;
			}
		}

		[JsonPropertyName("street")]
		[JsonPropertyOrder(2)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="street", Order=2, EmitDefaultValue=false)]
		public  string gxTpr_Street
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Street_Json())
					return sdt.gxTpr_Street;
				else
					return null;

			}
			set { 
				 sdt.gxTpr_Street = value;
			}
		}

		[JsonPropertyName("neighborhood")]
		[JsonPropertyOrder(3)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="neighborhood", Order=3, EmitDefaultValue=false)]
		public  string gxTpr_Neighborhood
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Neighborhood_Json())
					return sdt.gxTpr_Neighborhood;
				else
					return null;

			}
			set { 
				 sdt.gxTpr_Neighborhood = value;
			}
		}

		[JsonPropertyName("city")]
		[JsonPropertyOrder(4)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="city", Order=4, EmitDefaultValue=false)]
		public  string gxTpr_City
		{
			get { 
				if (sdt.ShouldSerializegxTpr_City_Json())
					return sdt.gxTpr_City;
				else
					return null;

			}
			set { 
				 sdt.gxTpr_City = value;
			}
		}

		[JsonPropertyName("municipality_code")]
		[JsonPropertyOrder(5)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="municipality_code", Order=5, EmitDefaultValue=false)]
		public  string gxTpr_Municipality_code
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Municipality_code_Json())
					return sdt.gxTpr_Municipality_code;
				else
					return null;

			}
			set { 
				 sdt.gxTpr_Municipality_code = value;
			}
		}

		[JsonPropertyName("number")]
		[JsonPropertyOrder(6)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="number", Order=6, EmitDefaultValue=false)]
		public  string gxTpr_Number
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Number_Json())
					return sdt.gxTpr_Number;
				else
					return null;

			}
			set { 
				 sdt.gxTpr_Number = value;
			}
		}

		[JsonPropertyName("complement")]
		[JsonPropertyOrder(7)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="complement", Order=7, EmitDefaultValue=false)]
		public  string gxTpr_Complement
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Complement_Json())
					return sdt.gxTpr_Complement;
				else
					return null;

			}
			set { 
				 sdt.gxTpr_Complement = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdClientePFPJ_address sdt
		{
			get { 
				return (SdtSdClientePFPJ_address)Sdt;
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
				sdt = new SdtSdClientePFPJ_address() ;
			}
		}
	}
	#endregion
}