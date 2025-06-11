/*
				   File: type_SdtSdEmpresas_company_membersItem_person
			Description: person
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
	[XmlRoot(ElementName="SdEmpresas.company.membersItem.person")]
	[XmlType(TypeName="SdEmpresas.company.membersItem.person" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdEmpresas_company_membersItem_person : GxUserType
	{
		public SdtSdEmpresas_company_membersItem_person( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdEmpresas_company_membersItem_person_Id = "";

			gxTv_SdtSdEmpresas_company_membersItem_person_Name = "";

			gxTv_SdtSdEmpresas_company_membersItem_person_Type = "";

			gxTv_SdtSdEmpresas_company_membersItem_person_Taxid = "";

			gxTv_SdtSdEmpresas_company_membersItem_person_Age = "";

		}

		public SdtSdEmpresas_company_membersItem_person(IGxContext context)
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
			AddObjectProperty("id", gxTpr_Id, false);


			AddObjectProperty("name", gxTpr_Name, false);


			AddObjectProperty("type", gxTpr_Type, false);


			AddObjectProperty("taxId", gxTpr_Taxid, false);


			AddObjectProperty("age", gxTpr_Age, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="id")]
		[XmlElement(ElementName="id")]
		public string gxTpr_Id
		{
			get {
				return gxTv_SdtSdEmpresas_company_membersItem_person_Id; 
			}
			set {
				gxTv_SdtSdEmpresas_company_membersItem_person_Id = value;
				SetDirty("Id");
			}
		}




		[SoapElement(ElementName="name")]
		[XmlElement(ElementName="name")]
		public string gxTpr_Name
		{
			get {
				return gxTv_SdtSdEmpresas_company_membersItem_person_Name; 
			}
			set {
				gxTv_SdtSdEmpresas_company_membersItem_person_Name = value;
				SetDirty("Name");
			}
		}




		[SoapElement(ElementName="type")]
		[XmlElement(ElementName="type")]
		public string gxTpr_Type
		{
			get {
				return gxTv_SdtSdEmpresas_company_membersItem_person_Type; 
			}
			set {
				gxTv_SdtSdEmpresas_company_membersItem_person_Type = value;
				SetDirty("Type");
			}
		}




		[SoapElement(ElementName="taxId")]
		[XmlElement(ElementName="taxId")]
		public string gxTpr_Taxid
		{
			get {
				return gxTv_SdtSdEmpresas_company_membersItem_person_Taxid; 
			}
			set {
				gxTv_SdtSdEmpresas_company_membersItem_person_Taxid = value;
				SetDirty("Taxid");
			}
		}




		[SoapElement(ElementName="age")]
		[XmlElement(ElementName="age")]
		public string gxTpr_Age
		{
			get {
				return gxTv_SdtSdEmpresas_company_membersItem_person_Age; 
			}
			set {
				gxTv_SdtSdEmpresas_company_membersItem_person_Age = value;
				SetDirty("Age");
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
			gxTv_SdtSdEmpresas_company_membersItem_person_Id = "";
			gxTv_SdtSdEmpresas_company_membersItem_person_Name = "";
			gxTv_SdtSdEmpresas_company_membersItem_person_Type = "";
			gxTv_SdtSdEmpresas_company_membersItem_person_Taxid = "";
			gxTv_SdtSdEmpresas_company_membersItem_person_Age = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSdEmpresas_company_membersItem_person_Id;
		 

		protected string gxTv_SdtSdEmpresas_company_membersItem_person_Name;
		 

		protected string gxTv_SdtSdEmpresas_company_membersItem_person_Type;
		 

		protected string gxTv_SdtSdEmpresas_company_membersItem_person_Taxid;
		 

		protected string gxTv_SdtSdEmpresas_company_membersItem_person_Age;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdEmpresas.company.membersItem.person", Namespace="Factory21")]
	public class SdtSdEmpresas_company_membersItem_person_RESTInterface : GxGenericCollectionItem<SdtSdEmpresas_company_membersItem_person>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdEmpresas_company_membersItem_person_RESTInterface( ) : base()
		{	
		}

		public SdtSdEmpresas_company_membersItem_person_RESTInterface( SdtSdEmpresas_company_membersItem_person psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("id")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="id", Order=0)]
		public  string gxTpr_Id
		{
			get { 
				return sdt.gxTpr_Id;

			}
			set { 
				 sdt.gxTpr_Id = value;
			}
		}

		[JsonPropertyName("name")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="name", Order=1)]
		public  string gxTpr_Name
		{
			get { 
				return sdt.gxTpr_Name;

			}
			set { 
				 sdt.gxTpr_Name = value;
			}
		}

		[JsonPropertyName("type")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="type", Order=2)]
		public  string gxTpr_Type
		{
			get { 
				return sdt.gxTpr_Type;

			}
			set { 
				 sdt.gxTpr_Type = value;
			}
		}

		[JsonPropertyName("taxId")]
		[JsonPropertyOrder(3)]
		[DataMember(Name="taxId", Order=3)]
		public  string gxTpr_Taxid
		{
			get { 
				return sdt.gxTpr_Taxid;

			}
			set { 
				 sdt.gxTpr_Taxid = value;
			}
		}

		[JsonPropertyName("age")]
		[JsonPropertyOrder(4)]
		[DataMember(Name="age", Order=4)]
		public  string gxTpr_Age
		{
			get { 
				return sdt.gxTpr_Age;

			}
			set { 
				 sdt.gxTpr_Age = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdEmpresas_company_membersItem_person sdt
		{
			get { 
				return (SdtSdEmpresas_company_membersItem_person)Sdt;
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
				sdt = new SdtSdEmpresas_company_membersItem_person() ;
			}
		}
	}
	#endregion
}