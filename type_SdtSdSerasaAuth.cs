/*
				   File: type_SdtSdSerasaAuth
			Description: SdSerasaAuth
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
	[XmlRoot(ElementName="SdSerasaAuth")]
	[XmlType(TypeName="SdSerasaAuth" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdSerasaAuth : GxUserType
	{
		public SdtSdSerasaAuth( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdSerasaAuth_Accesstoken = "";

			gxTv_SdtSdSerasaAuth_Tokentype = "";

			gxTv_SdtSdSerasaAuth_Expiresin = "";

		}

		public SdtSdSerasaAuth(IGxContext context)
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
			AddObjectProperty("accessToken", gxTpr_Accesstoken, false);


			AddObjectProperty("tokenType", gxTpr_Tokentype, false);


			AddObjectProperty("expiresIn", gxTpr_Expiresin, false);

			if (gxTv_SdtSdSerasaAuth_Scope != null)
			{
				AddObjectProperty("scope", gxTv_SdtSdSerasaAuth_Scope, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="accessToken")]
		[XmlElement(ElementName="accessToken")]
		public string gxTpr_Accesstoken
		{
			get {
				return gxTv_SdtSdSerasaAuth_Accesstoken; 
			}
			set {
				gxTv_SdtSdSerasaAuth_Accesstoken = value;
				SetDirty("Accesstoken");
			}
		}




		[SoapElement(ElementName="tokenType")]
		[XmlElement(ElementName="tokenType")]
		public string gxTpr_Tokentype
		{
			get {
				return gxTv_SdtSdSerasaAuth_Tokentype; 
			}
			set {
				gxTv_SdtSdSerasaAuth_Tokentype = value;
				SetDirty("Tokentype");
			}
		}




		[SoapElement(ElementName="expiresIn")]
		[XmlElement(ElementName="expiresIn")]
		public string gxTpr_Expiresin
		{
			get {
				return gxTv_SdtSdSerasaAuth_Expiresin; 
			}
			set {
				gxTv_SdtSdSerasaAuth_Expiresin = value;
				SetDirty("Expiresin");
			}
		}




		[SoapElement(ElementName="scope" )]
		[XmlArray(ElementName="scope"  )]
		[XmlArrayItemAttribute(ElementName="Item" , IsNullable=false )]
		public GxSimpleCollection<string> gxTpr_Scope_GxSimpleCollection
		{
			get {
				if ( gxTv_SdtSdSerasaAuth_Scope == null )
				{
					gxTv_SdtSdSerasaAuth_Scope = new GxSimpleCollection<string>( );
				}
				return gxTv_SdtSdSerasaAuth_Scope;
			}
			set {
				gxTv_SdtSdSerasaAuth_Scope_N = false;
				gxTv_SdtSdSerasaAuth_Scope = value;
			}
		}

		[XmlIgnore]
		public GxSimpleCollection<string> gxTpr_Scope
		{
			get {
				if ( gxTv_SdtSdSerasaAuth_Scope == null )
				{
					gxTv_SdtSdSerasaAuth_Scope = new GxSimpleCollection<string>();
				}
				gxTv_SdtSdSerasaAuth_Scope_N = false;
				SetDirty("Scope");
				return gxTv_SdtSdSerasaAuth_Scope ;
			}
			set {
				gxTv_SdtSdSerasaAuth_Scope_N = false;
				gxTv_SdtSdSerasaAuth_Scope = value;
				SetDirty("Scope");
			}
		}

		public void gxTv_SdtSdSerasaAuth_Scope_SetNull()
		{
			gxTv_SdtSdSerasaAuth_Scope_N = true;
			gxTv_SdtSdSerasaAuth_Scope = null;
		}

		public bool gxTv_SdtSdSerasaAuth_Scope_IsNull()
		{
			return gxTv_SdtSdSerasaAuth_Scope == null;
		}
		public bool ShouldSerializegxTpr_Scope_GxSimpleCollection_Json()
		{
			return gxTv_SdtSdSerasaAuth_Scope != null && gxTv_SdtSdSerasaAuth_Scope.Count > 0;

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
			gxTv_SdtSdSerasaAuth_Accesstoken = "";
			gxTv_SdtSdSerasaAuth_Tokentype = "";
			gxTv_SdtSdSerasaAuth_Expiresin = "";

			gxTv_SdtSdSerasaAuth_Scope_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSdSerasaAuth_Accesstoken;
		 

		protected string gxTv_SdtSdSerasaAuth_Tokentype;
		 

		protected string gxTv_SdtSdSerasaAuth_Expiresin;
		 
		protected bool gxTv_SdtSdSerasaAuth_Scope_N;
		protected GxSimpleCollection<string> gxTv_SdtSdSerasaAuth_Scope = null;  


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdSerasaAuth", Namespace="Factory21")]
	public class SdtSdSerasaAuth_RESTInterface : GxGenericCollectionItem<SdtSdSerasaAuth>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdSerasaAuth_RESTInterface( ) : base()
		{	
		}

		public SdtSdSerasaAuth_RESTInterface( SdtSdSerasaAuth psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("accessToken")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="accessToken", Order=0)]
		public  string gxTpr_Accesstoken
		{
			get { 
				return sdt.gxTpr_Accesstoken;

			}
			set { 
				 sdt.gxTpr_Accesstoken = value;
			}
		}

		[JsonPropertyName("tokenType")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="tokenType", Order=1)]
		public  string gxTpr_Tokentype
		{
			get { 
				return sdt.gxTpr_Tokentype;

			}
			set { 
				 sdt.gxTpr_Tokentype = value;
			}
		}

		[JsonPropertyName("expiresIn")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="expiresIn", Order=2)]
		public  string gxTpr_Expiresin
		{
			get { 
				return sdt.gxTpr_Expiresin;

			}
			set { 
				 sdt.gxTpr_Expiresin = value;
			}
		}

		[JsonPropertyName("scope")]
		[JsonPropertyOrder(3)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="scope", Order=3, EmitDefaultValue=false)]
		public  GxSimpleCollection<string> gxTpr_Scope
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Scope_GxSimpleCollection_Json())
					return sdt.gxTpr_Scope;
				else
					return null;

			}
			set { 
				sdt.gxTpr_Scope = value ;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdSerasaAuth sdt
		{
			get { 
				return (SdtSdSerasaAuth)Sdt;
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
				sdt = new SdtSdSerasaAuth() ;
			}
		}
	}
	#endregion
}