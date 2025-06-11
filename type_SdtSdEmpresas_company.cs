/*
				   File: type_SdtSdEmpresas_company
			Description: company
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
	[XmlRoot(ElementName="SdEmpresas.company")]
	[XmlType(TypeName="SdEmpresas.company" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdEmpresas_company : GxUserType
	{
		public SdtSdEmpresas_company( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdEmpresas_company_Name = "";


		}

		public SdtSdEmpresas_company(IGxContext context)
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


			AddObjectProperty("equity", gxTpr_Equity, false);

			if (gxTv_SdtSdEmpresas_company_Nature != null)
			{
				AddObjectProperty("nature", gxTv_SdtSdEmpresas_company_Nature, false);
			}
			if (gxTv_SdtSdEmpresas_company_Size != null)
			{
				AddObjectProperty("size", gxTv_SdtSdEmpresas_company_Size, false);
			}
			if (gxTv_SdtSdEmpresas_company_Members != null)
			{
				AddObjectProperty("members", gxTv_SdtSdEmpresas_company_Members, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="id")]
		[XmlElement(ElementName="id")]
		public string gxTpr_Id_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdEmpresas_company_Id, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdEmpresas_company_Id = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Id
		{
			get {
				return gxTv_SdtSdEmpresas_company_Id; 
			}
			set {
				gxTv_SdtSdEmpresas_company_Id = value;
				SetDirty("Id");
			}
		}




		[SoapElement(ElementName="name")]
		[XmlElement(ElementName="name")]
		public string gxTpr_Name
		{
			get {
				return gxTv_SdtSdEmpresas_company_Name; 
			}
			set {
				gxTv_SdtSdEmpresas_company_Name = value;
				SetDirty("Name");
			}
		}



		[SoapElement(ElementName="equity")]
		[XmlElement(ElementName="equity")]
		public string gxTpr_Equity_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdEmpresas_company_Equity, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdEmpresas_company_Equity = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Equity
		{
			get {
				return gxTv_SdtSdEmpresas_company_Equity; 
			}
			set {
				gxTv_SdtSdEmpresas_company_Equity = value;
				SetDirty("Equity");
			}
		}



		[SoapElement(ElementName="nature" )]
		[XmlElement(ElementName="nature" )]
		public SdtSdEmpresas_company_nature gxTpr_Nature
		{
			get {
				if ( gxTv_SdtSdEmpresas_company_Nature == null )
				{
					gxTv_SdtSdEmpresas_company_Nature = new SdtSdEmpresas_company_nature(context);
				}
				gxTv_SdtSdEmpresas_company_Nature_N = false;
				SetDirty("Nature");
				return gxTv_SdtSdEmpresas_company_Nature;
			}
			set {
				gxTv_SdtSdEmpresas_company_Nature_N = false;
				gxTv_SdtSdEmpresas_company_Nature = value;
				SetDirty("Nature");
			}

		}

		public void gxTv_SdtSdEmpresas_company_Nature_SetNull()
		{
			gxTv_SdtSdEmpresas_company_Nature_N = true;
			gxTv_SdtSdEmpresas_company_Nature = null;
		}

		public bool gxTv_SdtSdEmpresas_company_Nature_IsNull()
		{
			return gxTv_SdtSdEmpresas_company_Nature == null;
		}
		public bool ShouldSerializegxTpr_Nature_Json()
		{
				return (gxTv_SdtSdEmpresas_company_Nature != null && gxTv_SdtSdEmpresas_company_Nature.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="size" )]
		[XmlElement(ElementName="size" )]
		public SdtSdEmpresas_company_size gxTpr_Size
		{
			get {
				if ( gxTv_SdtSdEmpresas_company_Size == null )
				{
					gxTv_SdtSdEmpresas_company_Size = new SdtSdEmpresas_company_size(context);
				}
				gxTv_SdtSdEmpresas_company_Size_N = false;
				SetDirty("Size");
				return gxTv_SdtSdEmpresas_company_Size;
			}
			set {
				gxTv_SdtSdEmpresas_company_Size_N = false;
				gxTv_SdtSdEmpresas_company_Size = value;
				SetDirty("Size");
			}

		}

		public void gxTv_SdtSdEmpresas_company_Size_SetNull()
		{
			gxTv_SdtSdEmpresas_company_Size_N = true;
			gxTv_SdtSdEmpresas_company_Size = null;
		}

		public bool gxTv_SdtSdEmpresas_company_Size_IsNull()
		{
			return gxTv_SdtSdEmpresas_company_Size == null;
		}
		public bool ShouldSerializegxTpr_Size_Json()
		{
				return (gxTv_SdtSdEmpresas_company_Size != null && gxTv_SdtSdEmpresas_company_Size.ShouldSerializeSdtJson());

		}



		[SoapElement(ElementName="members" )]
		[XmlArray(ElementName="members"  )]
		[XmlArrayItemAttribute(ElementName="membersItem" , IsNullable=false )]
		public GXBaseCollection<SdtSdEmpresas_company_membersItem> gxTpr_Members
		{
			get {
				if ( gxTv_SdtSdEmpresas_company_Members == null )
				{
					gxTv_SdtSdEmpresas_company_Members = new GXBaseCollection<SdtSdEmpresas_company_membersItem>( context, "SdEmpresas.company.membersItem", "");
				}
				SetDirty("Members");
				return gxTv_SdtSdEmpresas_company_Members;
			}
			set {
				gxTv_SdtSdEmpresas_company_Members_N = false;
				gxTv_SdtSdEmpresas_company_Members = value;
				SetDirty("Members");
			}
		}

		public void gxTv_SdtSdEmpresas_company_Members_SetNull()
		{
			gxTv_SdtSdEmpresas_company_Members_N = true;
			gxTv_SdtSdEmpresas_company_Members = null;
		}

		public bool gxTv_SdtSdEmpresas_company_Members_IsNull()
		{
			return gxTv_SdtSdEmpresas_company_Members == null;
		}
		public bool ShouldSerializegxTpr_Members_GxSimpleCollection_Json()
		{
			return gxTv_SdtSdEmpresas_company_Members != null && gxTv_SdtSdEmpresas_company_Members.Count > 0;

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
			gxTv_SdtSdEmpresas_company_Name = "";


			gxTv_SdtSdEmpresas_company_Nature_N = true;


			gxTv_SdtSdEmpresas_company_Size_N = true;


			gxTv_SdtSdEmpresas_company_Members_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected decimal gxTv_SdtSdEmpresas_company_Id;
		 

		protected string gxTv_SdtSdEmpresas_company_Name;
		 

		protected decimal gxTv_SdtSdEmpresas_company_Equity;
		 
		protected bool gxTv_SdtSdEmpresas_company_Nature_N;
		protected SdtSdEmpresas_company_nature gxTv_SdtSdEmpresas_company_Nature = null; 

		protected bool gxTv_SdtSdEmpresas_company_Size_N;
		protected SdtSdEmpresas_company_size gxTv_SdtSdEmpresas_company_Size = null; 

		protected bool gxTv_SdtSdEmpresas_company_Members_N;
		protected GXBaseCollection<SdtSdEmpresas_company_membersItem> gxTv_SdtSdEmpresas_company_Members = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdEmpresas.company", Namespace="Factory21")]
	public class SdtSdEmpresas_company_RESTInterface : GxGenericCollectionItem<SdtSdEmpresas_company>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdEmpresas_company_RESTInterface( ) : base()
		{	
		}

		public SdtSdEmpresas_company_RESTInterface( SdtSdEmpresas_company psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("id")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="id", Order=0)]
		public  string gxTpr_Id
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Id, 10, 5));

			}
			set { 
				sdt.gxTpr_Id =  NumberUtil.Val( value, ".");
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

		[JsonPropertyName("equity")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="equity", Order=2)]
		public  string gxTpr_Equity
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Equity, 10, 5));

			}
			set { 
				sdt.gxTpr_Equity =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("nature")]
		[JsonPropertyOrder(3)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="nature", Order=3, EmitDefaultValue=false)]
		public SdtSdEmpresas_company_nature_RESTInterface gxTpr_Nature
		{
			get {
				if (sdt.ShouldSerializegxTpr_Nature_Json())
					return new SdtSdEmpresas_company_nature_RESTInterface(sdt.gxTpr_Nature);
				else
					return null;

			}

			set {
				sdt.gxTpr_Nature = value.sdt;
			}

		}

		[JsonPropertyName("size")]
		[JsonPropertyOrder(4)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="size", Order=4, EmitDefaultValue=false)]
		public SdtSdEmpresas_company_size_RESTInterface gxTpr_Size
		{
			get {
				if (sdt.ShouldSerializegxTpr_Size_Json())
					return new SdtSdEmpresas_company_size_RESTInterface(sdt.gxTpr_Size);
				else
					return null;

			}

			set {
				sdt.gxTpr_Size = value.sdt;
			}

		}

		[JsonPropertyName("members")]
		[JsonPropertyOrder(5)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="members", Order=5, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSdEmpresas_company_membersItem_RESTInterface> gxTpr_Members
		{
			get {
				if (sdt.ShouldSerializegxTpr_Members_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSdEmpresas_company_membersItem_RESTInterface>(sdt.gxTpr_Members);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Members);
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdEmpresas_company sdt
		{
			get { 
				return (SdtSdEmpresas_company)Sdt;
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
				sdt = new SdtSdEmpresas_company() ;
			}
		}
	}
	#endregion
}