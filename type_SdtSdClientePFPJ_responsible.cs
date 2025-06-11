/*
				   File: type_SdtSdClientePFPJ_responsible
			Description: responsible
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
	[XmlRoot(ElementName="SdClientePFPJ.responsible")]
	[XmlType(TypeName="SdClientePFPJ.responsible" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdClientePFPJ_responsible : GxUserType
	{
		public SdtSdClientePFPJ_responsible( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdClientePFPJ_responsible_Name = "";
			gxTv_SdtSdClientePFPJ_responsible_Name_N = true;

			gxTv_SdtSdClientePFPJ_responsible_Nationality = "";
			gxTv_SdtSdClientePFPJ_responsible_Nationality_N = true;

			gxTv_SdtSdClientePFPJ_responsible_Marital_status = "";
			gxTv_SdtSdClientePFPJ_responsible_Marital_status_N = true;

			gxTv_SdtSdClientePFPJ_responsible_Profession = "";
			gxTv_SdtSdClientePFPJ_responsible_Profession_N = true;

			gxTv_SdtSdClientePFPJ_responsible_Identity_document = "";
			gxTv_SdtSdClientePFPJ_responsible_Identity_document_N = true;

			gxTv_SdtSdClientePFPJ_responsible_Cpf = "";
			gxTv_SdtSdClientePFPJ_responsible_Cpf_N = true;

		}

		public SdtSdClientePFPJ_responsible(IGxContext context)
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
			if (ShouldSerializegxTpr_Name_Json())
			{	
				AddObjectProperty("name", gxTpr_Name, false);
			}


			if (ShouldSerializegxTpr_Nationality_Json())
			{	
				AddObjectProperty("nationality", gxTpr_Nationality, false);
			}


			if (ShouldSerializegxTpr_Marital_status_Json())
			{	
				AddObjectProperty("marital_status", gxTpr_Marital_status, false);
			}


			if (ShouldSerializegxTpr_Profession_Json())
			{	
				AddObjectProperty("profession", gxTpr_Profession, false);
			}


			if (ShouldSerializegxTpr_Identity_document_Json())
			{	
				AddObjectProperty("identity_document", gxTpr_Identity_document, false);
			}


			if (ShouldSerializegxTpr_Cpf_Json())
			{	
				AddObjectProperty("cpf", gxTpr_Cpf, false);
			}

			if (gxTv_SdtSdClientePFPJ_responsible_Address != null)
			{
				AddObjectProperty("address", gxTv_SdtSdClientePFPJ_responsible_Address, false);
			}
			if (gxTv_SdtSdClientePFPJ_responsible_Contact != null)
			{
				AddObjectProperty("contact", gxTv_SdtSdClientePFPJ_responsible_Contact, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="name")]
		[XmlElement(ElementName="name")]
		public string gxTpr_Name
		{
			get {
				return gxTv_SdtSdClientePFPJ_responsible_Name; 
			}
			set {
				gxTv_SdtSdClientePFPJ_responsible_Name_N = false;
				gxTv_SdtSdClientePFPJ_responsible_Name = value;
				SetDirty("Name");
			}
		}

		public bool ShouldSerializegxTpr_Name_Json()
		{
			return !gxTv_SdtSdClientePFPJ_responsible_Name_N;

		}



		[SoapElement(ElementName="nationality")]
		[XmlElement(ElementName="nationality")]
		public string gxTpr_Nationality
		{
			get {
				return gxTv_SdtSdClientePFPJ_responsible_Nationality; 
			}
			set {
				gxTv_SdtSdClientePFPJ_responsible_Nationality_N = false;
				gxTv_SdtSdClientePFPJ_responsible_Nationality = value;
				SetDirty("Nationality");
			}
		}

		public bool ShouldSerializegxTpr_Nationality_Json()
		{
			return !gxTv_SdtSdClientePFPJ_responsible_Nationality_N;

		}



		[SoapElement(ElementName="marital_status")]
		[XmlElement(ElementName="marital_status")]
		public string gxTpr_Marital_status
		{
			get {
				return gxTv_SdtSdClientePFPJ_responsible_Marital_status; 
			}
			set {
				gxTv_SdtSdClientePFPJ_responsible_Marital_status_N = false;
				gxTv_SdtSdClientePFPJ_responsible_Marital_status = value;
				SetDirty("Marital_status");
			}
		}

		public bool ShouldSerializegxTpr_Marital_status_Json()
		{
			return !gxTv_SdtSdClientePFPJ_responsible_Marital_status_N;

		}



		[SoapElement(ElementName="profession")]
		[XmlElement(ElementName="profession")]
		public string gxTpr_Profession
		{
			get {
				return gxTv_SdtSdClientePFPJ_responsible_Profession; 
			}
			set {
				gxTv_SdtSdClientePFPJ_responsible_Profession_N = false;
				gxTv_SdtSdClientePFPJ_responsible_Profession = value;
				SetDirty("Profession");
			}
		}

		public bool ShouldSerializegxTpr_Profession_Json()
		{
			return !gxTv_SdtSdClientePFPJ_responsible_Profession_N;

		}



		[SoapElement(ElementName="identity_document")]
		[XmlElement(ElementName="identity_document")]
		public string gxTpr_Identity_document
		{
			get {
				return gxTv_SdtSdClientePFPJ_responsible_Identity_document; 
			}
			set {
				gxTv_SdtSdClientePFPJ_responsible_Identity_document_N = false;
				gxTv_SdtSdClientePFPJ_responsible_Identity_document = value;
				SetDirty("Identity_document");
			}
		}

		public bool ShouldSerializegxTpr_Identity_document_Json()
		{
			return !gxTv_SdtSdClientePFPJ_responsible_Identity_document_N;

		}



		[SoapElement(ElementName="cpf")]
		[XmlElement(ElementName="cpf")]
		public string gxTpr_Cpf
		{
			get {
				return gxTv_SdtSdClientePFPJ_responsible_Cpf; 
			}
			set {
				gxTv_SdtSdClientePFPJ_responsible_Cpf_N = false;
				gxTv_SdtSdClientePFPJ_responsible_Cpf = value;
				SetDirty("Cpf");
			}
		}

		public bool ShouldSerializegxTpr_Cpf_Json()
		{
			return !gxTv_SdtSdClientePFPJ_responsible_Cpf_N;

		}


		[SoapElement(ElementName="address" )]
		[XmlElement(ElementName="address" )]
		public SdtSdClientePFPJ_responsible_address gxTpr_Address
		{
			get {
				if ( gxTv_SdtSdClientePFPJ_responsible_Address == null )
				{
					gxTv_SdtSdClientePFPJ_responsible_Address = new SdtSdClientePFPJ_responsible_address(context);
				}
				gxTv_SdtSdClientePFPJ_responsible_Address_N = false;
				SetDirty("Address");
				return gxTv_SdtSdClientePFPJ_responsible_Address;
			}
			set {
				gxTv_SdtSdClientePFPJ_responsible_Address_N = false;
				gxTv_SdtSdClientePFPJ_responsible_Address = value;
				SetDirty("Address");
			}

		}

		public void gxTv_SdtSdClientePFPJ_responsible_Address_SetNull()
		{
			gxTv_SdtSdClientePFPJ_responsible_Address_N = true;
			gxTv_SdtSdClientePFPJ_responsible_Address = null;
		}

		public bool gxTv_SdtSdClientePFPJ_responsible_Address_IsNull()
		{
			return gxTv_SdtSdClientePFPJ_responsible_Address == null;
		}
		public bool ShouldSerializegxTpr_Address_Json()
		{
				return (gxTv_SdtSdClientePFPJ_responsible_Address != null && gxTv_SdtSdClientePFPJ_responsible_Address.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="contact" )]
		[XmlElement(ElementName="contact" )]
		public SdtSdClientePFPJ_responsible_contact gxTpr_Contact
		{
			get {
				if ( gxTv_SdtSdClientePFPJ_responsible_Contact == null )
				{
					gxTv_SdtSdClientePFPJ_responsible_Contact = new SdtSdClientePFPJ_responsible_contact(context);
				}
				gxTv_SdtSdClientePFPJ_responsible_Contact_N = false;
				SetDirty("Contact");
				return gxTv_SdtSdClientePFPJ_responsible_Contact;
			}
			set {
				gxTv_SdtSdClientePFPJ_responsible_Contact_N = false;
				gxTv_SdtSdClientePFPJ_responsible_Contact = value;
				SetDirty("Contact");
			}

		}

		public void gxTv_SdtSdClientePFPJ_responsible_Contact_SetNull()
		{
			gxTv_SdtSdClientePFPJ_responsible_Contact_N = true;
			gxTv_SdtSdClientePFPJ_responsible_Contact = null;
		}

		public bool gxTv_SdtSdClientePFPJ_responsible_Contact_IsNull()
		{
			return gxTv_SdtSdClientePFPJ_responsible_Contact == null;
		}
		public bool ShouldSerializegxTpr_Contact_Json()
		{
				return (gxTv_SdtSdClientePFPJ_responsible_Contact != null && gxTv_SdtSdClientePFPJ_responsible_Contact.ShouldSerializeSdtJson());

		}


		public override bool ShouldSerializeSdtJson()
		{
			return (
				 ShouldSerializegxTpr_Name_Json()|| 
				 ShouldSerializegxTpr_Nationality_Json()|| 
				 ShouldSerializegxTpr_Marital_status_Json()|| 
				 ShouldSerializegxTpr_Profession_Json()|| 
				 ShouldSerializegxTpr_Identity_document_Json()|| 
				 ShouldSerializegxTpr_Cpf_Json()|| 
				ShouldSerializegxTpr_Address_Json() ||
				ShouldSerializegxTpr_Contact_Json() || 
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
			gxTv_SdtSdClientePFPJ_responsible_Name = "";
			gxTv_SdtSdClientePFPJ_responsible_Name_N = true;

			gxTv_SdtSdClientePFPJ_responsible_Nationality = "";
			gxTv_SdtSdClientePFPJ_responsible_Nationality_N = true;

			gxTv_SdtSdClientePFPJ_responsible_Marital_status = "";
			gxTv_SdtSdClientePFPJ_responsible_Marital_status_N = true;

			gxTv_SdtSdClientePFPJ_responsible_Profession = "";
			gxTv_SdtSdClientePFPJ_responsible_Profession_N = true;

			gxTv_SdtSdClientePFPJ_responsible_Identity_document = "";
			gxTv_SdtSdClientePFPJ_responsible_Identity_document_N = true;

			gxTv_SdtSdClientePFPJ_responsible_Cpf = "";
			gxTv_SdtSdClientePFPJ_responsible_Cpf_N = true;


			gxTv_SdtSdClientePFPJ_responsible_Address_N = true;


			gxTv_SdtSdClientePFPJ_responsible_Contact_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSdClientePFPJ_responsible_Name;
		protected bool gxTv_SdtSdClientePFPJ_responsible_Name_N;
		 

		protected string gxTv_SdtSdClientePFPJ_responsible_Nationality;
		protected bool gxTv_SdtSdClientePFPJ_responsible_Nationality_N;
		 

		protected string gxTv_SdtSdClientePFPJ_responsible_Marital_status;
		protected bool gxTv_SdtSdClientePFPJ_responsible_Marital_status_N;
		 

		protected string gxTv_SdtSdClientePFPJ_responsible_Profession;
		protected bool gxTv_SdtSdClientePFPJ_responsible_Profession_N;
		 

		protected string gxTv_SdtSdClientePFPJ_responsible_Identity_document;
		protected bool gxTv_SdtSdClientePFPJ_responsible_Identity_document_N;
		 

		protected string gxTv_SdtSdClientePFPJ_responsible_Cpf;
		protected bool gxTv_SdtSdClientePFPJ_responsible_Cpf_N;
		 
		protected bool gxTv_SdtSdClientePFPJ_responsible_Address_N;
		protected SdtSdClientePFPJ_responsible_address gxTv_SdtSdClientePFPJ_responsible_Address = null; 

		protected bool gxTv_SdtSdClientePFPJ_responsible_Contact_N;
		protected SdtSdClientePFPJ_responsible_contact gxTv_SdtSdClientePFPJ_responsible_Contact = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdClientePFPJ.responsible", Namespace="Factory21")]
	public class SdtSdClientePFPJ_responsible_RESTInterface : GxGenericCollectionItem<SdtSdClientePFPJ_responsible>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdClientePFPJ_responsible_RESTInterface( ) : base()
		{	
		}

		public SdtSdClientePFPJ_responsible_RESTInterface( SdtSdClientePFPJ_responsible psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("name")]
		[JsonPropertyOrder(0)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="name", Order=0, EmitDefaultValue=false)]
		public  string gxTpr_Name
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Name_Json())
					return sdt.gxTpr_Name;
				else
					return null;

			}
			set { 
				 sdt.gxTpr_Name = value;
			}
		}

		[JsonPropertyName("nationality")]
		[JsonPropertyOrder(1)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="nationality", Order=1, EmitDefaultValue=false)]
		public  string gxTpr_Nationality
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Nationality_Json())
					return sdt.gxTpr_Nationality;
				else
					return null;

			}
			set { 
				 sdt.gxTpr_Nationality = value;
			}
		}

		[JsonPropertyName("marital_status")]
		[JsonPropertyOrder(2)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="marital_status", Order=2, EmitDefaultValue=false)]
		public  string gxTpr_Marital_status
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Marital_status_Json())
					return sdt.gxTpr_Marital_status;
				else
					return null;

			}
			set { 
				 sdt.gxTpr_Marital_status = value;
			}
		}

		[JsonPropertyName("profession")]
		[JsonPropertyOrder(3)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="profession", Order=3, EmitDefaultValue=false)]
		public  string gxTpr_Profession
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Profession_Json())
					return sdt.gxTpr_Profession;
				else
					return null;

			}
			set { 
				 sdt.gxTpr_Profession = value;
			}
		}

		[JsonPropertyName("identity_document")]
		[JsonPropertyOrder(4)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="identity_document", Order=4, EmitDefaultValue=false)]
		public  string gxTpr_Identity_document
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Identity_document_Json())
					return sdt.gxTpr_Identity_document;
				else
					return null;

			}
			set { 
				 sdt.gxTpr_Identity_document = value;
			}
		}

		[JsonPropertyName("cpf")]
		[JsonPropertyOrder(5)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="cpf", Order=5, EmitDefaultValue=false)]
		public  string gxTpr_Cpf
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Cpf_Json())
					return sdt.gxTpr_Cpf;
				else
					return null;

			}
			set { 
				 sdt.gxTpr_Cpf = value;
			}
		}

		[JsonPropertyName("address")]
		[JsonPropertyOrder(6)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="address", Order=6, EmitDefaultValue=false)]
		public SdtSdClientePFPJ_responsible_address_RESTInterface gxTpr_Address
		{
			get {
				if (sdt.ShouldSerializegxTpr_Address_Json())
					return new SdtSdClientePFPJ_responsible_address_RESTInterface(sdt.gxTpr_Address);
				else
					return null;

			}

			set {
				sdt.gxTpr_Address = value.sdt;
			}

		}

		[JsonPropertyName("contact")]
		[JsonPropertyOrder(7)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="contact", Order=7, EmitDefaultValue=false)]
		public SdtSdClientePFPJ_responsible_contact_RESTInterface gxTpr_Contact
		{
			get {
				if (sdt.ShouldSerializegxTpr_Contact_Json())
					return new SdtSdClientePFPJ_responsible_contact_RESTInterface(sdt.gxTpr_Contact);
				else
					return null;

			}

			set {
				sdt.gxTpr_Contact = value.sdt;
			}

		}


		#endregion
		[JsonIgnore]
		public SdtSdClientePFPJ_responsible sdt
		{
			get { 
				return (SdtSdClientePFPJ_responsible)Sdt;
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
				sdt = new SdtSdClientePFPJ_responsible() ;
			}
		}
	}
	#endregion
}