/*
				   File: type_SdtSecFunctionalitiesToLoad
			Description: SecFunctionalitiesToLoad
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

using GeneXus.Programs;
namespace GeneXus.Programs.wwpbaseobjects
{
	[XmlRoot(ElementName="SecFunctionalitiesToLoad")]
	[XmlType(TypeName="SecFunctionalitiesToLoad" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSecFunctionalitiesToLoad : GxUserType
	{
		public SdtSecFunctionalitiesToLoad( )
		{
			/* Constructor for serialization */
			gxTv_SdtSecFunctionalitiesToLoad_Secobjectname = "";

			gxTv_SdtSecFunctionalitiesToLoad_Secparentfunctionalitykey = "";

		}

		public SdtSecFunctionalitiesToLoad(IGxContext context)
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
			AddObjectProperty("SecObjectName", gxTpr_Secobjectname, false);


			AddObjectProperty("SecFunctionalityType", gxTpr_Secfunctionalitytype, false);


			AddObjectProperty("SecParentFunctionalityKey", gxTpr_Secparentfunctionalitykey, false);

			if (gxTv_SdtSecFunctionalitiesToLoad_Secfunctionalitykeys != null)
			{
				AddObjectProperty("SecFunctionalityKeys", gxTv_SdtSecFunctionalitiesToLoad_Secfunctionalitykeys, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="SecObjectName")]
		[XmlElement(ElementName="SecObjectName")]
		public string gxTpr_Secobjectname
		{
			get {
				return gxTv_SdtSecFunctionalitiesToLoad_Secobjectname; 
			}
			set {
				gxTv_SdtSecFunctionalitiesToLoad_Secobjectname = value;
				SetDirty("Secobjectname");
			}
		}




		[SoapElement(ElementName="SecFunctionalityType")]
		[XmlElement(ElementName="SecFunctionalityType")]
		public short gxTpr_Secfunctionalitytype
		{
			get {
				return gxTv_SdtSecFunctionalitiesToLoad_Secfunctionalitytype; 
			}
			set {
				gxTv_SdtSecFunctionalitiesToLoad_Secfunctionalitytype = value;
				SetDirty("Secfunctionalitytype");
			}
		}




		[SoapElement(ElementName="SecParentFunctionalityKey")]
		[XmlElement(ElementName="SecParentFunctionalityKey")]
		public string gxTpr_Secparentfunctionalitykey
		{
			get {
				return gxTv_SdtSecFunctionalitiesToLoad_Secparentfunctionalitykey; 
			}
			set {
				gxTv_SdtSecFunctionalitiesToLoad_Secparentfunctionalitykey = value;
				SetDirty("Secparentfunctionalitykey");
			}
		}




		[SoapElement(ElementName="SecFunctionalityKeys" )]
		[XmlArray(ElementName="SecFunctionalityKeys"  )]
		[XmlArrayItemAttribute(ElementName="SecFunctionalityKeysItem" , IsNullable=false )]
		public GXBaseCollection<SdtSecFunctionalitiesToLoad_SecFunctionalityKeysItem> gxTpr_Secfunctionalitykeys
		{
			get {
				if ( gxTv_SdtSecFunctionalitiesToLoad_Secfunctionalitykeys == null )
				{
					gxTv_SdtSecFunctionalitiesToLoad_Secfunctionalitykeys = new GXBaseCollection<SdtSecFunctionalitiesToLoad_SecFunctionalityKeysItem>( context, "SecFunctionalitiesToLoad.SecFunctionalityKeysItem", "");
				}
				SetDirty("Secfunctionalitykeys");
				return gxTv_SdtSecFunctionalitiesToLoad_Secfunctionalitykeys;
			}
			set {
				gxTv_SdtSecFunctionalitiesToLoad_Secfunctionalitykeys_N = false;
				gxTv_SdtSecFunctionalitiesToLoad_Secfunctionalitykeys = value;
				SetDirty("Secfunctionalitykeys");
			}
		}

		public void gxTv_SdtSecFunctionalitiesToLoad_Secfunctionalitykeys_SetNull()
		{
			gxTv_SdtSecFunctionalitiesToLoad_Secfunctionalitykeys_N = true;
			gxTv_SdtSecFunctionalitiesToLoad_Secfunctionalitykeys = null;
		}

		public bool gxTv_SdtSecFunctionalitiesToLoad_Secfunctionalitykeys_IsNull()
		{
			return gxTv_SdtSecFunctionalitiesToLoad_Secfunctionalitykeys == null;
		}
		public bool ShouldSerializegxTpr_Secfunctionalitykeys_GxSimpleCollection_Json()
		{
			return gxTv_SdtSecFunctionalitiesToLoad_Secfunctionalitykeys != null && gxTv_SdtSecFunctionalitiesToLoad_Secfunctionalitykeys.Count > 0;

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
			gxTv_SdtSecFunctionalitiesToLoad_Secobjectname = "";

			gxTv_SdtSecFunctionalitiesToLoad_Secparentfunctionalitykey = "";

			gxTv_SdtSecFunctionalitiesToLoad_Secfunctionalitykeys_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSecFunctionalitiesToLoad_Secobjectname;
		 

		protected short gxTv_SdtSecFunctionalitiesToLoad_Secfunctionalitytype;
		 

		protected string gxTv_SdtSecFunctionalitiesToLoad_Secparentfunctionalitykey;
		 
		protected bool gxTv_SdtSecFunctionalitiesToLoad_Secfunctionalitykeys_N;
		protected GXBaseCollection<SdtSecFunctionalitiesToLoad_SecFunctionalityKeysItem> gxTv_SdtSecFunctionalitiesToLoad_Secfunctionalitykeys = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SecFunctionalitiesToLoad", Namespace="Factory21")]
	public class SdtSecFunctionalitiesToLoad_RESTInterface : GxGenericCollectionItem<SdtSecFunctionalitiesToLoad>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSecFunctionalitiesToLoad_RESTInterface( ) : base()
		{	
		}

		public SdtSecFunctionalitiesToLoad_RESTInterface( SdtSecFunctionalitiesToLoad psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("SecObjectName")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="SecObjectName", Order=0)]
		public  string gxTpr_Secobjectname
		{
			get { 
				return sdt.gxTpr_Secobjectname;

			}
			set { 
				 sdt.gxTpr_Secobjectname = value;
			}
		}

		[JsonPropertyName("SecFunctionalityType")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="SecFunctionalityType", Order=1)]
		public short gxTpr_Secfunctionalitytype
		{
			get { 
				return sdt.gxTpr_Secfunctionalitytype;

			}
			set { 
				sdt.gxTpr_Secfunctionalitytype = value;
			}
		}

		[JsonPropertyName("SecParentFunctionalityKey")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="SecParentFunctionalityKey", Order=2)]
		public  string gxTpr_Secparentfunctionalitykey
		{
			get { 
				return sdt.gxTpr_Secparentfunctionalitykey;

			}
			set { 
				 sdt.gxTpr_Secparentfunctionalitykey = value;
			}
		}

		[JsonPropertyName("SecFunctionalityKeys")]
		[JsonPropertyOrder(3)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="SecFunctionalityKeys", Order=3, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSecFunctionalitiesToLoad_SecFunctionalityKeysItem_RESTInterface> gxTpr_Secfunctionalitykeys
		{
			get {
				if (sdt.ShouldSerializegxTpr_Secfunctionalitykeys_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSecFunctionalitiesToLoad_SecFunctionalityKeysItem_RESTInterface>(sdt.gxTpr_Secfunctionalitykeys);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Secfunctionalitykeys);
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSecFunctionalitiesToLoad sdt
		{
			get { 
				return (SdtSecFunctionalitiesToLoad)Sdt;
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
				sdt = new SdtSecFunctionalitiesToLoad() ;
			}
		}
	}
	#endregion
}