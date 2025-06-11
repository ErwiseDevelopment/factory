/*
				   File: type_SdtSdClientePFPJ_responsible_contact
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
	[XmlRoot(ElementName="SdClientePFPJ.responsible.contact")]
	[XmlType(TypeName="SdClientePFPJ.responsible.contact" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdClientePFPJ_responsible_contact : GxUserType
	{
		public SdtSdClientePFPJ_responsible_contact( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdClientePFPJ_responsible_contact_Ddi = "";
			gxTv_SdtSdClientePFPJ_responsible_contact_Ddi_N = true;

			gxTv_SdtSdClientePFPJ_responsible_contact_Ddd = "";
			gxTv_SdtSdClientePFPJ_responsible_contact_Ddd_N = true;

			gxTv_SdtSdClientePFPJ_responsible_contact_Number = "";
			gxTv_SdtSdClientePFPJ_responsible_contact_Number_N = true;

			gxTv_SdtSdClientePFPJ_responsible_contact_Email = "";
			gxTv_SdtSdClientePFPJ_responsible_contact_Email_N = true;

		}

		public SdtSdClientePFPJ_responsible_contact(IGxContext context)
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
			if (ShouldSerializegxTpr_Ddi_Json())
			{	
				AddObjectProperty("ddi", gxTpr_Ddi, false);
			}


			if (ShouldSerializegxTpr_Ddd_Json())
			{	
				AddObjectProperty("ddd", gxTpr_Ddd, false);
			}


			if (ShouldSerializegxTpr_Number_Json())
			{	
				AddObjectProperty("number", gxTpr_Number, false);
			}


			if (ShouldSerializegxTpr_Email_Json())
			{	
				AddObjectProperty("email", gxTpr_Email, false);
			}

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ddi")]
		[XmlElement(ElementName="ddi")]
		public string gxTpr_Ddi
		{
			get {
				return gxTv_SdtSdClientePFPJ_responsible_contact_Ddi; 
			}
			set {
				gxTv_SdtSdClientePFPJ_responsible_contact_Ddi_N = false;
				gxTv_SdtSdClientePFPJ_responsible_contact_Ddi = value;
				SetDirty("Ddi");
			}
		}

		public bool ShouldSerializegxTpr_Ddi_Json()
		{
			return !gxTv_SdtSdClientePFPJ_responsible_contact_Ddi_N;

		}



		[SoapElement(ElementName="ddd")]
		[XmlElement(ElementName="ddd")]
		public string gxTpr_Ddd
		{
			get {
				return gxTv_SdtSdClientePFPJ_responsible_contact_Ddd; 
			}
			set {
				gxTv_SdtSdClientePFPJ_responsible_contact_Ddd_N = false;
				gxTv_SdtSdClientePFPJ_responsible_contact_Ddd = value;
				SetDirty("Ddd");
			}
		}

		public bool ShouldSerializegxTpr_Ddd_Json()
		{
			return !gxTv_SdtSdClientePFPJ_responsible_contact_Ddd_N;

		}



		[SoapElement(ElementName="number")]
		[XmlElement(ElementName="number")]
		public string gxTpr_Number
		{
			get {
				return gxTv_SdtSdClientePFPJ_responsible_contact_Number; 
			}
			set {
				gxTv_SdtSdClientePFPJ_responsible_contact_Number_N = false;
				gxTv_SdtSdClientePFPJ_responsible_contact_Number = value;
				SetDirty("Number");
			}
		}

		public bool ShouldSerializegxTpr_Number_Json()
		{
			return !gxTv_SdtSdClientePFPJ_responsible_contact_Number_N;

		}



		[SoapElement(ElementName="email")]
		[XmlElement(ElementName="email")]
		public string gxTpr_Email
		{
			get {
				return gxTv_SdtSdClientePFPJ_responsible_contact_Email; 
			}
			set {
				gxTv_SdtSdClientePFPJ_responsible_contact_Email_N = false;
				gxTv_SdtSdClientePFPJ_responsible_contact_Email = value;
				SetDirty("Email");
			}
		}

		public bool ShouldSerializegxTpr_Email_Json()
		{
			return !gxTv_SdtSdClientePFPJ_responsible_contact_Email_N;

		}


		public override bool ShouldSerializeSdtJson()
		{
			return (
				 ShouldSerializegxTpr_Ddi_Json()|| 
				 ShouldSerializegxTpr_Ddd_Json()|| 
				 ShouldSerializegxTpr_Number_Json()|| 
				 ShouldSerializegxTpr_Email_Json()||  
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
			gxTv_SdtSdClientePFPJ_responsible_contact_Ddi = "";
			gxTv_SdtSdClientePFPJ_responsible_contact_Ddi_N = true;

			gxTv_SdtSdClientePFPJ_responsible_contact_Ddd = "";
			gxTv_SdtSdClientePFPJ_responsible_contact_Ddd_N = true;

			gxTv_SdtSdClientePFPJ_responsible_contact_Number = "";
			gxTv_SdtSdClientePFPJ_responsible_contact_Number_N = true;

			gxTv_SdtSdClientePFPJ_responsible_contact_Email = "";
			gxTv_SdtSdClientePFPJ_responsible_contact_Email_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSdClientePFPJ_responsible_contact_Ddi;
		protected bool gxTv_SdtSdClientePFPJ_responsible_contact_Ddi_N;
		 

		protected string gxTv_SdtSdClientePFPJ_responsible_contact_Ddd;
		protected bool gxTv_SdtSdClientePFPJ_responsible_contact_Ddd_N;
		 

		protected string gxTv_SdtSdClientePFPJ_responsible_contact_Number;
		protected bool gxTv_SdtSdClientePFPJ_responsible_contact_Number_N;
		 

		protected string gxTv_SdtSdClientePFPJ_responsible_contact_Email;
		protected bool gxTv_SdtSdClientePFPJ_responsible_contact_Email_N;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdClientePFPJ.responsible.contact", Namespace="Factory21")]
	public class SdtSdClientePFPJ_responsible_contact_RESTInterface : GxGenericCollectionItem<SdtSdClientePFPJ_responsible_contact>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdClientePFPJ_responsible_contact_RESTInterface( ) : base()
		{	
		}

		public SdtSdClientePFPJ_responsible_contact_RESTInterface( SdtSdClientePFPJ_responsible_contact psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("ddi")]
		[JsonPropertyOrder(0)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="ddi", Order=0, EmitDefaultValue=false)]
		public  string gxTpr_Ddi
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Ddi_Json())
					return sdt.gxTpr_Ddi;
				else
					return null;

			}
			set { 
				 sdt.gxTpr_Ddi = value;
			}
		}

		[JsonPropertyName("ddd")]
		[JsonPropertyOrder(1)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="ddd", Order=1, EmitDefaultValue=false)]
		public  string gxTpr_Ddd
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Ddd_Json())
					return sdt.gxTpr_Ddd;
				else
					return null;

			}
			set { 
				 sdt.gxTpr_Ddd = value;
			}
		}

		[JsonPropertyName("number")]
		[JsonPropertyOrder(2)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="number", Order=2, EmitDefaultValue=false)]
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

		[JsonPropertyName("email")]
		[JsonPropertyOrder(3)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="email", Order=3, EmitDefaultValue=false)]
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


		#endregion
		[JsonIgnore]
		public SdtSdClientePFPJ_responsible_contact sdt
		{
			get { 
				return (SdtSdClientePFPJ_responsible_contact)Sdt;
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
				sdt = new SdtSdClientePFPJ_responsible_contact() ;
			}
		}
	}
	#endregion
}