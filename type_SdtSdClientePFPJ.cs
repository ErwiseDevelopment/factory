/*
				   File: type_SdtSdClientePFPJ
			Description: SdClientePFPJ
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
	[XmlRoot(ElementName="SdClientePFPJ")]
	[XmlType(TypeName="SdClientePFPJ" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdClientePFPJ : GxUserType
	{
		public SdtSdClientePFPJ( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdClientePFPJ_Document = "";
			gxTv_SdtSdClientePFPJ_Document_N = true;

			gxTv_SdtSdClientePFPJ_Company_name = "";
			gxTv_SdtSdClientePFPJ_Company_name_N = true;

			gxTv_SdtSdClientePFPJ_Trade_name = "";
			gxTv_SdtSdClientePFPJ_Trade_name_N = true;

			gxTv_SdtSdClientePFPJ_Birth_date = "";
			gxTv_SdtSdClientePFPJ_Birth_date_N = true;

			gxTv_SdtSdClientePFPJ_Person_type = "";
			gxTv_SdtSdClientePFPJ_Person_type_N = true;

			gxTv_SdtSdClientePFPJ_Status = "";
			gxTv_SdtSdClientePFPJ_Status_N = true;

			gxTv_SdtSdClientePFPJ_Health_insurance = "";
			gxTv_SdtSdClientePFPJ_Health_insurance_N = true;

			gxTv_SdtSdClientePFPJ_Created_at = (DateTime)(DateTime.MinValue);
			gxTv_SdtSdClientePFPJ_Created_at_N = true;

			gxTv_SdtSdClientePFPJ_Updated_at = (DateTime)(DateTime.MinValue);
			gxTv_SdtSdClientePFPJ_Updated_at_N = true;

			gxTv_SdtSdClientePFPJ_Nationality = "";
			gxTv_SdtSdClientePFPJ_Nationality_N = true;

			gxTv_SdtSdClientePFPJ_Marital_status = "";
			gxTv_SdtSdClientePFPJ_Marital_status_N = true;

			gxTv_SdtSdClientePFPJ_Identity_document = "";
			gxTv_SdtSdClientePFPJ_Identity_document_N = true;

		}

		public SdtSdClientePFPJ(IGxContext context)
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
			if (ShouldSerializegxTpr_Document_Json())
			{	
				AddObjectProperty("document", gxTpr_Document, false);
			}


			if (ShouldSerializegxTpr_Company_name_Json())
			{	
				AddObjectProperty("company_name", gxTpr_Company_name, false);
			}


			if (ShouldSerializegxTpr_Trade_name_Json())
			{	
				AddObjectProperty("trade_name", gxTpr_Trade_name, false);
			}


			if (ShouldSerializegxTpr_Birth_date_Json())
			{	
				AddObjectProperty("birth_date", gxTpr_Birth_date, false);
			}


			if (ShouldSerializegxTpr_Person_type_Json())
			{	
				AddObjectProperty("person_type", gxTpr_Person_type, false);
			}


			if (ShouldSerializegxTpr_Status_Json())
			{	
				AddObjectProperty("status", gxTpr_Status, false);
			}


			if (ShouldSerializegxTpr_Health_insurance_Json())
			{	
				AddObjectProperty("health_insurance", gxTpr_Health_insurance, false);
			}


			if (ShouldSerializegxTpr_Created_at_Json())
			{	
				datetime_STZ = gxTpr_Created_at;
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
				AddObjectProperty("created_at", sDateCnv, false);

			}


			if (ShouldSerializegxTpr_Updated_at_Json())
			{	
				datetime_STZ = gxTpr_Updated_at;
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
				AddObjectProperty("updated_at", sDateCnv, false);

			}


			if (ShouldSerializegxTpr_Nationality_Json())
			{	
				AddObjectProperty("nationality", gxTpr_Nationality, false);
			}


			if (ShouldSerializegxTpr_Marital_status_Json())
			{	
				AddObjectProperty("marital_status", gxTpr_Marital_status, false);
			}

			if (gxTv_SdtSdClientePFPJ_Address != null)
			{
				AddObjectProperty("address", gxTv_SdtSdClientePFPJ_Address, false);
			}
			if (gxTv_SdtSdClientePFPJ_Contact != null)
			{
				AddObjectProperty("contact", gxTv_SdtSdClientePFPJ_Contact, false);
			}

			if (ShouldSerializegxTpr_Identity_document_Json())
			{	
				AddObjectProperty("identity_document", gxTpr_Identity_document, false);
			}

			if (gxTv_SdtSdClientePFPJ_Responsible != null)
			{
				AddObjectProperty("responsible", gxTv_SdtSdClientePFPJ_Responsible, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="document")]
		[XmlElement(ElementName="document")]
		public string gxTpr_Document
		{
			get {
				return gxTv_SdtSdClientePFPJ_Document; 
			}
			set {
				gxTv_SdtSdClientePFPJ_Document_N = false;
				gxTv_SdtSdClientePFPJ_Document = value;
				SetDirty("Document");
			}
		}

		public bool ShouldSerializegxTpr_Document_Json()
		{
			return !gxTv_SdtSdClientePFPJ_Document_N;

		}



		[SoapElement(ElementName="company_name")]
		[XmlElement(ElementName="company_name")]
		public string gxTpr_Company_name
		{
			get {
				return gxTv_SdtSdClientePFPJ_Company_name; 
			}
			set {
				gxTv_SdtSdClientePFPJ_Company_name_N = false;
				gxTv_SdtSdClientePFPJ_Company_name = value;
				SetDirty("Company_name");
			}
		}

		public bool ShouldSerializegxTpr_Company_name_Json()
		{
			return !gxTv_SdtSdClientePFPJ_Company_name_N;

		}



		[SoapElement(ElementName="trade_name")]
		[XmlElement(ElementName="trade_name")]
		public string gxTpr_Trade_name
		{
			get {
				return gxTv_SdtSdClientePFPJ_Trade_name; 
			}
			set {
				gxTv_SdtSdClientePFPJ_Trade_name_N = false;
				gxTv_SdtSdClientePFPJ_Trade_name = value;
				SetDirty("Trade_name");
			}
		}

		public bool ShouldSerializegxTpr_Trade_name_Json()
		{
			return !gxTv_SdtSdClientePFPJ_Trade_name_N;

		}



		[SoapElement(ElementName="birth_date")]
		[XmlElement(ElementName="birth_date")]
		public string gxTpr_Birth_date
		{
			get {
				return gxTv_SdtSdClientePFPJ_Birth_date; 
			}
			set {
				gxTv_SdtSdClientePFPJ_Birth_date_N = false;
				gxTv_SdtSdClientePFPJ_Birth_date = value;
				SetDirty("Birth_date");
			}
		}

		public bool ShouldSerializegxTpr_Birth_date_Json()
		{
			return !gxTv_SdtSdClientePFPJ_Birth_date_N;

		}



		[SoapElement(ElementName="person_type")]
		[XmlElement(ElementName="person_type")]
		public string gxTpr_Person_type
		{
			get {
				return gxTv_SdtSdClientePFPJ_Person_type; 
			}
			set {
				gxTv_SdtSdClientePFPJ_Person_type_N = false;
				gxTv_SdtSdClientePFPJ_Person_type = value;
				SetDirty("Person_type");
			}
		}

		public bool ShouldSerializegxTpr_Person_type_Json()
		{
			return !gxTv_SdtSdClientePFPJ_Person_type_N;

		}



		[SoapElement(ElementName="status")]
		[XmlElement(ElementName="status")]
		public string gxTpr_Status
		{
			get {
				return gxTv_SdtSdClientePFPJ_Status; 
			}
			set {
				gxTv_SdtSdClientePFPJ_Status_N = false;
				gxTv_SdtSdClientePFPJ_Status = value;
				SetDirty("Status");
			}
		}

		public bool ShouldSerializegxTpr_Status_Json()
		{
			return !gxTv_SdtSdClientePFPJ_Status_N;

		}



		[SoapElement(ElementName="health_insurance")]
		[XmlElement(ElementName="health_insurance")]
		public string gxTpr_Health_insurance
		{
			get {
				return gxTv_SdtSdClientePFPJ_Health_insurance; 
			}
			set {
				gxTv_SdtSdClientePFPJ_Health_insurance_N = false;
				gxTv_SdtSdClientePFPJ_Health_insurance = value;
				SetDirty("Health_insurance");
			}
		}

		public bool ShouldSerializegxTpr_Health_insurance_Json()
		{
			return !gxTv_SdtSdClientePFPJ_Health_insurance_N;

		}


		[SoapElement(ElementName="created_at")]
		[XmlElement(ElementName="created_at" , IsNullable=true)]
		public string gxTpr_Created_at_Nullable
		{
			get {
				if ( gxTv_SdtSdClientePFPJ_Created_at == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSdClientePFPJ_Created_at).value ;
			}
			set {
				gxTv_SdtSdClientePFPJ_Created_at = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Created_at
		{
			get {
				return gxTv_SdtSdClientePFPJ_Created_at; 
			}
			set {
				gxTv_SdtSdClientePFPJ_Created_at_N = false;
				gxTv_SdtSdClientePFPJ_Created_at = value;
				SetDirty("Created_at");
			}
		}

		public bool ShouldSerializegxTpr_Created_at_Json()
		{
			return gxTv_SdtSdClientePFPJ_Created_at != DateTime.MinValue;

		}

		[SoapElement(ElementName="updated_at")]
		[XmlElement(ElementName="updated_at" , IsNullable=true)]
		public string gxTpr_Updated_at_Nullable
		{
			get {
				if ( gxTv_SdtSdClientePFPJ_Updated_at == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSdClientePFPJ_Updated_at).value ;
			}
			set {
				gxTv_SdtSdClientePFPJ_Updated_at = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Updated_at
		{
			get {
				return gxTv_SdtSdClientePFPJ_Updated_at; 
			}
			set {
				gxTv_SdtSdClientePFPJ_Updated_at_N = false;
				gxTv_SdtSdClientePFPJ_Updated_at = value;
				SetDirty("Updated_at");
			}
		}

		public bool ShouldSerializegxTpr_Updated_at_Json()
		{
			return gxTv_SdtSdClientePFPJ_Updated_at != DateTime.MinValue;

		}


		[SoapElement(ElementName="nationality")]
		[XmlElement(ElementName="nationality")]
		public string gxTpr_Nationality
		{
			get {
				return gxTv_SdtSdClientePFPJ_Nationality; 
			}
			set {
				gxTv_SdtSdClientePFPJ_Nationality_N = false;
				gxTv_SdtSdClientePFPJ_Nationality = value;
				SetDirty("Nationality");
			}
		}

		public bool ShouldSerializegxTpr_Nationality_Json()
		{
			return !gxTv_SdtSdClientePFPJ_Nationality_N;

		}



		[SoapElement(ElementName="marital_status")]
		[XmlElement(ElementName="marital_status")]
		public string gxTpr_Marital_status
		{
			get {
				return gxTv_SdtSdClientePFPJ_Marital_status; 
			}
			set {
				gxTv_SdtSdClientePFPJ_Marital_status_N = false;
				gxTv_SdtSdClientePFPJ_Marital_status = value;
				SetDirty("Marital_status");
			}
		}

		public bool ShouldSerializegxTpr_Marital_status_Json()
		{
			return !gxTv_SdtSdClientePFPJ_Marital_status_N;

		}


		[SoapElement(ElementName="address" )]
		[XmlElement(ElementName="address" )]
		public SdtSdClientePFPJ_address gxTpr_Address
		{
			get {
				if ( gxTv_SdtSdClientePFPJ_Address == null )
				{
					gxTv_SdtSdClientePFPJ_Address = new SdtSdClientePFPJ_address(context);
				}
				gxTv_SdtSdClientePFPJ_Address_N = false;
				SetDirty("Address");
				return gxTv_SdtSdClientePFPJ_Address;
			}
			set {
				gxTv_SdtSdClientePFPJ_Address_N = false;
				gxTv_SdtSdClientePFPJ_Address = value;
				SetDirty("Address");
			}

		}

		public void gxTv_SdtSdClientePFPJ_Address_SetNull()
		{
			gxTv_SdtSdClientePFPJ_Address_N = true;
			gxTv_SdtSdClientePFPJ_Address = null;
		}

		public bool gxTv_SdtSdClientePFPJ_Address_IsNull()
		{
			return gxTv_SdtSdClientePFPJ_Address == null;
		}
		public bool ShouldSerializegxTpr_Address_Json()
		{
				return (gxTv_SdtSdClientePFPJ_Address != null && gxTv_SdtSdClientePFPJ_Address.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="contact" )]
		[XmlElement(ElementName="contact" )]
		public SdtSdClientePFPJ_contact gxTpr_Contact
		{
			get {
				if ( gxTv_SdtSdClientePFPJ_Contact == null )
				{
					gxTv_SdtSdClientePFPJ_Contact = new SdtSdClientePFPJ_contact(context);
				}
				gxTv_SdtSdClientePFPJ_Contact_N = false;
				SetDirty("Contact");
				return gxTv_SdtSdClientePFPJ_Contact;
			}
			set {
				gxTv_SdtSdClientePFPJ_Contact_N = false;
				gxTv_SdtSdClientePFPJ_Contact = value;
				SetDirty("Contact");
			}

		}

		public void gxTv_SdtSdClientePFPJ_Contact_SetNull()
		{
			gxTv_SdtSdClientePFPJ_Contact_N = true;
			gxTv_SdtSdClientePFPJ_Contact = null;
		}

		public bool gxTv_SdtSdClientePFPJ_Contact_IsNull()
		{
			return gxTv_SdtSdClientePFPJ_Contact == null;
		}
		public bool ShouldSerializegxTpr_Contact_Json()
		{
				return (gxTv_SdtSdClientePFPJ_Contact != null && gxTv_SdtSdClientePFPJ_Contact.ShouldSerializeSdtJson());

		}



		[SoapElement(ElementName="identity_document")]
		[XmlElement(ElementName="identity_document")]
		public string gxTpr_Identity_document
		{
			get {
				return gxTv_SdtSdClientePFPJ_Identity_document; 
			}
			set {
				gxTv_SdtSdClientePFPJ_Identity_document_N = false;
				gxTv_SdtSdClientePFPJ_Identity_document = value;
				SetDirty("Identity_document");
			}
		}

		public bool ShouldSerializegxTpr_Identity_document_Json()
		{
			return !gxTv_SdtSdClientePFPJ_Identity_document_N;

		}


		[SoapElement(ElementName="responsible" )]
		[XmlElement(ElementName="responsible" )]
		public SdtSdClientePFPJ_responsible gxTpr_Responsible
		{
			get {
				if ( gxTv_SdtSdClientePFPJ_Responsible == null )
				{
					gxTv_SdtSdClientePFPJ_Responsible = new SdtSdClientePFPJ_responsible(context);
				}
				gxTv_SdtSdClientePFPJ_Responsible_N = false;
				SetDirty("Responsible");
				return gxTv_SdtSdClientePFPJ_Responsible;
			}
			set {
				gxTv_SdtSdClientePFPJ_Responsible_N = false;
				gxTv_SdtSdClientePFPJ_Responsible = value;
				SetDirty("Responsible");
			}

		}

		public void gxTv_SdtSdClientePFPJ_Responsible_SetNull()
		{
			gxTv_SdtSdClientePFPJ_Responsible_N = true;
			gxTv_SdtSdClientePFPJ_Responsible = null;
		}

		public bool gxTv_SdtSdClientePFPJ_Responsible_IsNull()
		{
			return gxTv_SdtSdClientePFPJ_Responsible == null;
		}
		public bool ShouldSerializegxTpr_Responsible_Json()
		{
				return (gxTv_SdtSdClientePFPJ_Responsible != null && gxTv_SdtSdClientePFPJ_Responsible.ShouldSerializeSdtJson());

		}


		public override bool ShouldSerializeSdtJson()
		{
			return (
				 ShouldSerializegxTpr_Document_Json()|| 
				 ShouldSerializegxTpr_Company_name_Json()|| 
				 ShouldSerializegxTpr_Trade_name_Json()|| 
				 ShouldSerializegxTpr_Birth_date_Json()|| 
				 ShouldSerializegxTpr_Person_type_Json()|| 
				 ShouldSerializegxTpr_Status_Json()|| 
				 ShouldSerializegxTpr_Health_insurance_Json()|| 
				 ShouldSerializegxTpr_Created_at_Json()|| 
				 ShouldSerializegxTpr_Updated_at_Json()|| 
				 ShouldSerializegxTpr_Nationality_Json()|| 
				 ShouldSerializegxTpr_Marital_status_Json()|| 
				ShouldSerializegxTpr_Address_Json() ||
				ShouldSerializegxTpr_Contact_Json() ||
				 ShouldSerializegxTpr_Identity_document_Json()|| 
				ShouldSerializegxTpr_Responsible_Json() || 
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
			gxTv_SdtSdClientePFPJ_Document = "";
			gxTv_SdtSdClientePFPJ_Document_N = true;

			gxTv_SdtSdClientePFPJ_Company_name = "";
			gxTv_SdtSdClientePFPJ_Company_name_N = true;

			gxTv_SdtSdClientePFPJ_Trade_name = "";
			gxTv_SdtSdClientePFPJ_Trade_name_N = true;

			gxTv_SdtSdClientePFPJ_Birth_date = "";
			gxTv_SdtSdClientePFPJ_Birth_date_N = true;

			gxTv_SdtSdClientePFPJ_Person_type = "";
			gxTv_SdtSdClientePFPJ_Person_type_N = true;

			gxTv_SdtSdClientePFPJ_Status = "";
			gxTv_SdtSdClientePFPJ_Status_N = true;

			gxTv_SdtSdClientePFPJ_Health_insurance = "";
			gxTv_SdtSdClientePFPJ_Health_insurance_N = true;

			gxTv_SdtSdClientePFPJ_Created_at = (DateTime)(DateTime.MinValue);
			gxTv_SdtSdClientePFPJ_Created_at_N = true;

			gxTv_SdtSdClientePFPJ_Updated_at = (DateTime)(DateTime.MinValue);
			gxTv_SdtSdClientePFPJ_Updated_at_N = true;

			gxTv_SdtSdClientePFPJ_Nationality = "";
			gxTv_SdtSdClientePFPJ_Nationality_N = true;

			gxTv_SdtSdClientePFPJ_Marital_status = "";
			gxTv_SdtSdClientePFPJ_Marital_status_N = true;


			gxTv_SdtSdClientePFPJ_Address_N = true;


			gxTv_SdtSdClientePFPJ_Contact_N = true;

			gxTv_SdtSdClientePFPJ_Identity_document = "";
			gxTv_SdtSdClientePFPJ_Identity_document_N = true;


			gxTv_SdtSdClientePFPJ_Responsible_N = true;

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

		protected string gxTv_SdtSdClientePFPJ_Document;
		protected bool gxTv_SdtSdClientePFPJ_Document_N;
		 

		protected string gxTv_SdtSdClientePFPJ_Company_name;
		protected bool gxTv_SdtSdClientePFPJ_Company_name_N;
		 

		protected string gxTv_SdtSdClientePFPJ_Trade_name;
		protected bool gxTv_SdtSdClientePFPJ_Trade_name_N;
		 

		protected string gxTv_SdtSdClientePFPJ_Birth_date;
		protected bool gxTv_SdtSdClientePFPJ_Birth_date_N;
		 

		protected string gxTv_SdtSdClientePFPJ_Person_type;
		protected bool gxTv_SdtSdClientePFPJ_Person_type_N;
		 

		protected string gxTv_SdtSdClientePFPJ_Status;
		protected bool gxTv_SdtSdClientePFPJ_Status_N;
		 

		protected string gxTv_SdtSdClientePFPJ_Health_insurance;
		protected bool gxTv_SdtSdClientePFPJ_Health_insurance_N;
		 

		protected DateTime gxTv_SdtSdClientePFPJ_Created_at;
		protected bool gxTv_SdtSdClientePFPJ_Created_at_N;
		 

		protected DateTime gxTv_SdtSdClientePFPJ_Updated_at;
		protected bool gxTv_SdtSdClientePFPJ_Updated_at_N;
		 

		protected string gxTv_SdtSdClientePFPJ_Nationality;
		protected bool gxTv_SdtSdClientePFPJ_Nationality_N;
		 

		protected string gxTv_SdtSdClientePFPJ_Marital_status;
		protected bool gxTv_SdtSdClientePFPJ_Marital_status_N;
		 
		protected bool gxTv_SdtSdClientePFPJ_Address_N;
		protected SdtSdClientePFPJ_address gxTv_SdtSdClientePFPJ_Address = null; 

		protected bool gxTv_SdtSdClientePFPJ_Contact_N;
		protected SdtSdClientePFPJ_contact gxTv_SdtSdClientePFPJ_Contact = null; 


		protected string gxTv_SdtSdClientePFPJ_Identity_document;
		protected bool gxTv_SdtSdClientePFPJ_Identity_document_N;
		 
		protected bool gxTv_SdtSdClientePFPJ_Responsible_N;
		protected SdtSdClientePFPJ_responsible gxTv_SdtSdClientePFPJ_Responsible = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdClientePFPJ", Namespace="Factory21")]
	public class SdtSdClientePFPJ_RESTInterface : GxGenericCollectionItem<SdtSdClientePFPJ>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdClientePFPJ_RESTInterface( ) : base()
		{	
		}

		public SdtSdClientePFPJ_RESTInterface( SdtSdClientePFPJ psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("document")]
		[JsonPropertyOrder(0)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="document", Order=0, EmitDefaultValue=false)]
		public  string gxTpr_Document
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Document_Json())
					return sdt.gxTpr_Document;
				else
					return null;

			}
			set { 
				 sdt.gxTpr_Document = value;
			}
		}

		[JsonPropertyName("company_name")]
		[JsonPropertyOrder(1)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="company_name", Order=1, EmitDefaultValue=false)]
		public  string gxTpr_Company_name
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Company_name_Json())
					return sdt.gxTpr_Company_name;
				else
					return null;

			}
			set { 
				 sdt.gxTpr_Company_name = value;
			}
		}

		[JsonPropertyName("trade_name")]
		[JsonPropertyOrder(2)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="trade_name", Order=2, EmitDefaultValue=false)]
		public  string gxTpr_Trade_name
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Trade_name_Json())
					return sdt.gxTpr_Trade_name;
				else
					return null;

			}
			set { 
				 sdt.gxTpr_Trade_name = value;
			}
		}

		[JsonPropertyName("birth_date")]
		[JsonPropertyOrder(3)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="birth_date", Order=3, EmitDefaultValue=false)]
		public  string gxTpr_Birth_date
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Birth_date_Json())
					return sdt.gxTpr_Birth_date;
				else
					return null;

			}
			set { 
				 sdt.gxTpr_Birth_date = value;
			}
		}

		[JsonPropertyName("person_type")]
		[JsonPropertyOrder(4)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="person_type", Order=4, EmitDefaultValue=false)]
		public  string gxTpr_Person_type
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Person_type_Json())
					return sdt.gxTpr_Person_type;
				else
					return null;

			}
			set { 
				 sdt.gxTpr_Person_type = value;
			}
		}

		[JsonPropertyName("status")]
		[JsonPropertyOrder(5)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="status", Order=5, EmitDefaultValue=false)]
		public  string gxTpr_Status
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Status_Json())
					return sdt.gxTpr_Status;
				else
					return null;

			}
			set { 
				 sdt.gxTpr_Status = value;
			}
		}

		[JsonPropertyName("health_insurance")]
		[JsonPropertyOrder(6)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="health_insurance", Order=6, EmitDefaultValue=false)]
		public  string gxTpr_Health_insurance
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Health_insurance_Json())
					return sdt.gxTpr_Health_insurance;
				else
					return null;

			}
			set { 
				 sdt.gxTpr_Health_insurance = value;
			}
		}

		[JsonPropertyName("created_at")]
		[JsonPropertyOrder(7)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="created_at", Order=7, EmitDefaultValue=false)]
		public  string gxTpr_Created_at
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Created_at_Json())
					return DateTimeUtil.TToC2( sdt.gxTpr_Created_at,context);
				else
					return null;

			}
			set { 
				sdt.gxTpr_Created_at = DateTimeUtil.CToT2(value,context);
			}
		}

		[JsonPropertyName("updated_at")]
		[JsonPropertyOrder(8)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="updated_at", Order=8, EmitDefaultValue=false)]
		public  string gxTpr_Updated_at
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Updated_at_Json())
					return DateTimeUtil.TToC2( sdt.gxTpr_Updated_at,context);
				else
					return null;

			}
			set { 
				sdt.gxTpr_Updated_at = DateTimeUtil.CToT2(value,context);
			}
		}

		[JsonPropertyName("nationality")]
		[JsonPropertyOrder(9)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="nationality", Order=9, EmitDefaultValue=false)]
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
		[JsonPropertyOrder(10)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="marital_status", Order=10, EmitDefaultValue=false)]
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

		[JsonPropertyName("address")]
		[JsonPropertyOrder(11)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="address", Order=11, EmitDefaultValue=false)]
		public SdtSdClientePFPJ_address_RESTInterface gxTpr_Address
		{
			get {
				if (sdt.ShouldSerializegxTpr_Address_Json())
					return new SdtSdClientePFPJ_address_RESTInterface(sdt.gxTpr_Address);
				else
					return null;

			}

			set {
				sdt.gxTpr_Address = value.sdt;
			}

		}

		[JsonPropertyName("contact")]
		[JsonPropertyOrder(12)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="contact", Order=12, EmitDefaultValue=false)]
		public SdtSdClientePFPJ_contact_RESTInterface gxTpr_Contact
		{
			get {
				if (sdt.ShouldSerializegxTpr_Contact_Json())
					return new SdtSdClientePFPJ_contact_RESTInterface(sdt.gxTpr_Contact);
				else
					return null;

			}

			set {
				sdt.gxTpr_Contact = value.sdt;
			}

		}

		[JsonPropertyName("identity_document")]
		[JsonPropertyOrder(13)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="identity_document", Order=13, EmitDefaultValue=false)]
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

		[JsonPropertyName("responsible")]
		[JsonPropertyOrder(14)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="responsible", Order=14, EmitDefaultValue=false)]
		public SdtSdClientePFPJ_responsible_RESTInterface gxTpr_Responsible
		{
			get {
				if (sdt.ShouldSerializegxTpr_Responsible_Json())
					return new SdtSdClientePFPJ_responsible_RESTInterface(sdt.gxTpr_Responsible);
				else
					return null;

			}

			set {
				sdt.gxTpr_Responsible = value.sdt;
			}

		}


		#endregion
		[JsonIgnore]
		public SdtSdClientePFPJ sdt
		{
			get { 
				return (SdtSdClientePFPJ)Sdt;
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
				sdt = new SdtSdClientePFPJ() ;
			}
		}
	}
	#endregion
}