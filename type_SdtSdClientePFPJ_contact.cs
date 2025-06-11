/*
				   File: type_SdtSdClientePFPJ_contact
			Description: contact
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
	[XmlRoot(ElementName="SdClientePFPJ.contact")]
	[XmlType(TypeName="SdClientePFPJ.contact" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdClientePFPJ_contact : GxUserType
	{
		public SdtSdClientePFPJ_contact( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdClientePFPJ_contact_Email = "";
			gxTv_SdtSdClientePFPJ_contact_Email_N = true;

		}

		public SdtSdClientePFPJ_contact(IGxContext context)
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
			if (ShouldSerializegxTpr_Email_Json())
			{	
				AddObjectProperty("email", gxTpr_Email, false);
			}

			if (gxTv_SdtSdClientePFPJ_contact_Phone != null)
			{
				AddObjectProperty("phone", gxTv_SdtSdClientePFPJ_contact_Phone, false);
			}
			if (gxTv_SdtSdClientePFPJ_contact_Secondary_phone != null)
			{
				AddObjectProperty("secondary_phone", gxTv_SdtSdClientePFPJ_contact_Secondary_phone, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="email")]
		[XmlElement(ElementName="email")]
		public string gxTpr_Email
		{
			get {
				return gxTv_SdtSdClientePFPJ_contact_Email; 
			}
			set {
				gxTv_SdtSdClientePFPJ_contact_Email_N = false;
				gxTv_SdtSdClientePFPJ_contact_Email = value;
				SetDirty("Email");
			}
		}

		public bool ShouldSerializegxTpr_Email_Json()
		{
			return !gxTv_SdtSdClientePFPJ_contact_Email_N;

		}


		[SoapElement(ElementName="phone" )]
		[XmlElement(ElementName="phone" )]
		public SdtSdClientePFPJ_contact_phone gxTpr_Phone
		{
			get {
				if ( gxTv_SdtSdClientePFPJ_contact_Phone == null )
				{
					gxTv_SdtSdClientePFPJ_contact_Phone = new SdtSdClientePFPJ_contact_phone(context);
				}
				gxTv_SdtSdClientePFPJ_contact_Phone_N = false;
				SetDirty("Phone");
				return gxTv_SdtSdClientePFPJ_contact_Phone;
			}
			set {
				gxTv_SdtSdClientePFPJ_contact_Phone_N = false;
				gxTv_SdtSdClientePFPJ_contact_Phone = value;
				SetDirty("Phone");
			}

		}

		public void gxTv_SdtSdClientePFPJ_contact_Phone_SetNull()
		{
			gxTv_SdtSdClientePFPJ_contact_Phone_N = true;
			gxTv_SdtSdClientePFPJ_contact_Phone = null;
		}

		public bool gxTv_SdtSdClientePFPJ_contact_Phone_IsNull()
		{
			return gxTv_SdtSdClientePFPJ_contact_Phone == null;
		}
		public bool ShouldSerializegxTpr_Phone_Json()
		{
				return (gxTv_SdtSdClientePFPJ_contact_Phone != null && gxTv_SdtSdClientePFPJ_contact_Phone.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="secondary_phone" )]
		[XmlElement(ElementName="secondary_phone" )]
		public SdtSdClientePFPJ_contact_secondary_phone gxTpr_Secondary_phone
		{
			get {
				if ( gxTv_SdtSdClientePFPJ_contact_Secondary_phone == null )
				{
					gxTv_SdtSdClientePFPJ_contact_Secondary_phone = new SdtSdClientePFPJ_contact_secondary_phone(context);
				}
				gxTv_SdtSdClientePFPJ_contact_Secondary_phone_N = false;
				SetDirty("Secondary_phone");
				return gxTv_SdtSdClientePFPJ_contact_Secondary_phone;
			}
			set {
				gxTv_SdtSdClientePFPJ_contact_Secondary_phone_N = false;
				gxTv_SdtSdClientePFPJ_contact_Secondary_phone = value;
				SetDirty("Secondary_phone");
			}

		}

		public void gxTv_SdtSdClientePFPJ_contact_Secondary_phone_SetNull()
		{
			gxTv_SdtSdClientePFPJ_contact_Secondary_phone_N = true;
			gxTv_SdtSdClientePFPJ_contact_Secondary_phone = null;
		}

		public bool gxTv_SdtSdClientePFPJ_contact_Secondary_phone_IsNull()
		{
			return gxTv_SdtSdClientePFPJ_contact_Secondary_phone == null;
		}
		public bool ShouldSerializegxTpr_Secondary_phone_Json()
		{
				return (gxTv_SdtSdClientePFPJ_contact_Secondary_phone != null && gxTv_SdtSdClientePFPJ_contact_Secondary_phone.ShouldSerializeSdtJson());

		}


		public override bool ShouldSerializeSdtJson()
		{
			return (
				 ShouldSerializegxTpr_Email_Json()|| 
				ShouldSerializegxTpr_Phone_Json() ||
				ShouldSerializegxTpr_Secondary_phone_Json() || 
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
			gxTv_SdtSdClientePFPJ_contact_Email = "";
			gxTv_SdtSdClientePFPJ_contact_Email_N = true;


			gxTv_SdtSdClientePFPJ_contact_Phone_N = true;


			gxTv_SdtSdClientePFPJ_contact_Secondary_phone_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSdClientePFPJ_contact_Email;
		protected bool gxTv_SdtSdClientePFPJ_contact_Email_N;
		 
		protected bool gxTv_SdtSdClientePFPJ_contact_Phone_N;
		protected SdtSdClientePFPJ_contact_phone gxTv_SdtSdClientePFPJ_contact_Phone = null; 

		protected bool gxTv_SdtSdClientePFPJ_contact_Secondary_phone_N;
		protected SdtSdClientePFPJ_contact_secondary_phone gxTv_SdtSdClientePFPJ_contact_Secondary_phone = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdClientePFPJ.contact", Namespace="Factory21")]
	public class SdtSdClientePFPJ_contact_RESTInterface : GxGenericCollectionItem<SdtSdClientePFPJ_contact>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdClientePFPJ_contact_RESTInterface( ) : base()
		{	
		}

		public SdtSdClientePFPJ_contact_RESTInterface( SdtSdClientePFPJ_contact psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("email")]
		[JsonPropertyOrder(0)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="email", Order=0, EmitDefaultValue=false)]
		public  string gxTpr_Email
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Email_Json())
					return sdt.gxTpr_Email;
				else
					return null;

			}
			set { 
				 sdt.gxTpr_Email = value;
			}
		}

		[JsonPropertyName("phone")]
		[JsonPropertyOrder(1)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="phone", Order=1, EmitDefaultValue=false)]
		public SdtSdClientePFPJ_contact_phone_RESTInterface gxTpr_Phone
		{
			get {
				if (sdt.ShouldSerializegxTpr_Phone_Json())
					return new SdtSdClientePFPJ_contact_phone_RESTInterface(sdt.gxTpr_Phone);
				else
					return null;

			}

			set {
				sdt.gxTpr_Phone = value.sdt;
			}

		}

		[JsonPropertyName("secondary_phone")]
		[JsonPropertyOrder(2)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="secondary_phone", Order=2, EmitDefaultValue=false)]
		public SdtSdClientePFPJ_contact_secondary_phone_RESTInterface gxTpr_Secondary_phone
		{
			get {
				if (sdt.ShouldSerializegxTpr_Secondary_phone_Json())
					return new SdtSdClientePFPJ_contact_secondary_phone_RESTInterface(sdt.gxTpr_Secondary_phone);
				else
					return null;

			}

			set {
				sdt.gxTpr_Secondary_phone = value.sdt;
			}

		}


		#endregion
		[JsonIgnore]
		public SdtSdClientePFPJ_contact sdt
		{
			get { 
				return (SdtSdClientePFPJ_contact)Sdt;
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
				sdt = new SdtSdClientePFPJ_contact() ;
			}
		}
	}
	#endregion
}