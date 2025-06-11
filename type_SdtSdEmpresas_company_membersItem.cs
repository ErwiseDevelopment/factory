/*
				   File: type_SdtSdEmpresas_company_membersItem
			Description: members
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
	[XmlRoot(ElementName="SdEmpresas.company.membersItem")]
	[XmlType(TypeName="SdEmpresas.company.membersItem" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdEmpresas_company_membersItem : GxUserType
	{
		public SdtSdEmpresas_company_membersItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdEmpresas_company_membersItem_Since = "";

		}

		public SdtSdEmpresas_company_membersItem(IGxContext context)
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
			AddObjectProperty("since", gxTpr_Since, false);

			if (gxTv_SdtSdEmpresas_company_membersItem_Role != null)
			{
				AddObjectProperty("role", gxTv_SdtSdEmpresas_company_membersItem_Role, false);
			}
			if (gxTv_SdtSdEmpresas_company_membersItem_Person != null)
			{
				AddObjectProperty("person", gxTv_SdtSdEmpresas_company_membersItem_Person, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="since")]
		[XmlElement(ElementName="since")]
		public string gxTpr_Since
		{
			get {
				return gxTv_SdtSdEmpresas_company_membersItem_Since; 
			}
			set {
				gxTv_SdtSdEmpresas_company_membersItem_Since = value;
				SetDirty("Since");
			}
		}



		[SoapElement(ElementName="role" )]
		[XmlElement(ElementName="role" )]
		public SdtSdEmpresas_company_membersItem_role gxTpr_Role
		{
			get {
				if ( gxTv_SdtSdEmpresas_company_membersItem_Role == null )
				{
					gxTv_SdtSdEmpresas_company_membersItem_Role = new SdtSdEmpresas_company_membersItem_role(context);
				}
				gxTv_SdtSdEmpresas_company_membersItem_Role_N = false;
				SetDirty("Role");
				return gxTv_SdtSdEmpresas_company_membersItem_Role;
			}
			set {
				gxTv_SdtSdEmpresas_company_membersItem_Role_N = false;
				gxTv_SdtSdEmpresas_company_membersItem_Role = value;
				SetDirty("Role");
			}

		}

		public void gxTv_SdtSdEmpresas_company_membersItem_Role_SetNull()
		{
			gxTv_SdtSdEmpresas_company_membersItem_Role_N = true;
			gxTv_SdtSdEmpresas_company_membersItem_Role = null;
		}

		public bool gxTv_SdtSdEmpresas_company_membersItem_Role_IsNull()
		{
			return gxTv_SdtSdEmpresas_company_membersItem_Role == null;
		}
		public bool ShouldSerializegxTpr_Role_Json()
		{
				return (gxTv_SdtSdEmpresas_company_membersItem_Role != null && gxTv_SdtSdEmpresas_company_membersItem_Role.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="person" )]
		[XmlElement(ElementName="person" )]
		public SdtSdEmpresas_company_membersItem_person gxTpr_Person
		{
			get {
				if ( gxTv_SdtSdEmpresas_company_membersItem_Person == null )
				{
					gxTv_SdtSdEmpresas_company_membersItem_Person = new SdtSdEmpresas_company_membersItem_person(context);
				}
				gxTv_SdtSdEmpresas_company_membersItem_Person_N = false;
				SetDirty("Person");
				return gxTv_SdtSdEmpresas_company_membersItem_Person;
			}
			set {
				gxTv_SdtSdEmpresas_company_membersItem_Person_N = false;
				gxTv_SdtSdEmpresas_company_membersItem_Person = value;
				SetDirty("Person");
			}

		}

		public void gxTv_SdtSdEmpresas_company_membersItem_Person_SetNull()
		{
			gxTv_SdtSdEmpresas_company_membersItem_Person_N = true;
			gxTv_SdtSdEmpresas_company_membersItem_Person = null;
		}

		public bool gxTv_SdtSdEmpresas_company_membersItem_Person_IsNull()
		{
			return gxTv_SdtSdEmpresas_company_membersItem_Person == null;
		}
		public bool ShouldSerializegxTpr_Person_Json()
		{
				return (gxTv_SdtSdEmpresas_company_membersItem_Person != null && gxTv_SdtSdEmpresas_company_membersItem_Person.ShouldSerializeSdtJson());

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
			gxTv_SdtSdEmpresas_company_membersItem_Since = "";

			gxTv_SdtSdEmpresas_company_membersItem_Role_N = true;


			gxTv_SdtSdEmpresas_company_membersItem_Person_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSdEmpresas_company_membersItem_Since;
		 
		protected bool gxTv_SdtSdEmpresas_company_membersItem_Role_N;
		protected SdtSdEmpresas_company_membersItem_role gxTv_SdtSdEmpresas_company_membersItem_Role = null; 

		protected bool gxTv_SdtSdEmpresas_company_membersItem_Person_N;
		protected SdtSdEmpresas_company_membersItem_person gxTv_SdtSdEmpresas_company_membersItem_Person = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SdEmpresas.company.membersItem", Namespace="Factory21")]
	public class SdtSdEmpresas_company_membersItem_RESTInterface : GxGenericCollectionItem<SdtSdEmpresas_company_membersItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdEmpresas_company_membersItem_RESTInterface( ) : base()
		{	
		}

		public SdtSdEmpresas_company_membersItem_RESTInterface( SdtSdEmpresas_company_membersItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("since")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="since", Order=0)]
		public  string gxTpr_Since
		{
			get { 
				return sdt.gxTpr_Since;

			}
			set { 
				 sdt.gxTpr_Since = value;
			}
		}

		[JsonPropertyName("role")]
		[JsonPropertyOrder(1)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="role", Order=1, EmitDefaultValue=false)]
		public SdtSdEmpresas_company_membersItem_role_RESTInterface gxTpr_Role
		{
			get {
				if (sdt.ShouldSerializegxTpr_Role_Json())
					return new SdtSdEmpresas_company_membersItem_role_RESTInterface(sdt.gxTpr_Role);
				else
					return null;

			}

			set {
				sdt.gxTpr_Role = value.sdt;
			}

		}

		[JsonPropertyName("person")]
		[JsonPropertyOrder(2)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="person", Order=2, EmitDefaultValue=false)]
		public SdtSdEmpresas_company_membersItem_person_RESTInterface gxTpr_Person
		{
			get {
				if (sdt.ShouldSerializegxTpr_Person_Json())
					return new SdtSdEmpresas_company_membersItem_person_RESTInterface(sdt.gxTpr_Person);
				else
					return null;

			}

			set {
				sdt.gxTpr_Person = value.sdt;
			}

		}


		#endregion
		[JsonIgnore]
		public SdtSdEmpresas_company_membersItem sdt
		{
			get { 
				return (SdtSdEmpresas_company_membersItem)Sdt;
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
				sdt = new SdtSdEmpresas_company_membersItem() ;
			}
		}
	}
	#endregion
}