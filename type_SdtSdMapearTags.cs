/*
				   File: type_SdtSdMapearTags
			Description: SdMapearTags
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
	[XmlRoot(ElementName="SdMapearTags")]
	[XmlType(TypeName="SdMapearTags" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdMapearTags : GxUserType
	{
		public SdtSdMapearTags( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdMapearTags_Tabela = "";

		}

		public SdtSdMapearTags(IGxContext context)
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
			if (gxTv_SdtSdMapearTags_Tags != null)
			{
				AddObjectProperty("Tags", gxTv_SdtSdMapearTags_Tags, false);
			}

			AddObjectProperty("Tabela", gxTpr_Tabela, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Tags" )]
		[XmlArray(ElementName="Tags"  )]
		[XmlArrayItemAttribute(ElementName="TagsItem" , IsNullable=false )]
		public GXBaseCollection<SdtSdMapearTags_TagsItem> gxTpr_Tags
		{
			get {
				if ( gxTv_SdtSdMapearTags_Tags == null )
				{
					gxTv_SdtSdMapearTags_Tags = new GXBaseCollection<SdtSdMapearTags_TagsItem>( context, "SdMapearTags.TagsItem", "");
				}
				SetDirty("Tags");
				return gxTv_SdtSdMapearTags_Tags;
			}
			set {
				gxTv_SdtSdMapearTags_Tags_N = false;
				gxTv_SdtSdMapearTags_Tags = value;
				SetDirty("Tags");
			}
		}

		public void gxTv_SdtSdMapearTags_Tags_SetNull()
		{
			gxTv_SdtSdMapearTags_Tags_N = true;
			gxTv_SdtSdMapearTags_Tags = null;
		}

		public bool gxTv_SdtSdMapearTags_Tags_IsNull()
		{
			return gxTv_SdtSdMapearTags_Tags == null;
		}
		public bool ShouldSerializegxTpr_Tags_GxSimpleCollection_Json()
		{
			return gxTv_SdtSdMapearTags_Tags != null && gxTv_SdtSdMapearTags_Tags.Count > 0;

		}



		[SoapElement(ElementName="Tabela")]
		[XmlElement(ElementName="Tabela")]
		public string gxTpr_Tabela
		{
			get {
				return gxTv_SdtSdMapearTags_Tabela; 
			}
			set {
				gxTv_SdtSdMapearTags_Tabela = value;
				SetDirty("Tabela");
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
			gxTv_SdtSdMapearTags_Tags_N = true;

			gxTv_SdtSdMapearTags_Tabela = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtSdMapearTags_Tags_N;
		protected GXBaseCollection<SdtSdMapearTags_TagsItem> gxTv_SdtSdMapearTags_Tags = null; 


		protected string gxTv_SdtSdMapearTags_Tabela;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdMapearTags", Namespace="Factory21")]
	public class SdtSdMapearTags_RESTInterface : GxGenericCollectionItem<SdtSdMapearTags>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdMapearTags_RESTInterface( ) : base()
		{	
		}

		public SdtSdMapearTags_RESTInterface( SdtSdMapearTags psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("Tags")]
		[JsonPropertyOrder(0)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="Tags", Order=0, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSdMapearTags_TagsItem_RESTInterface> gxTpr_Tags
		{
			get {
				if (sdt.ShouldSerializegxTpr_Tags_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSdMapearTags_TagsItem_RESTInterface>(sdt.gxTpr_Tags);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Tags);
			}
		}

		[JsonPropertyName("Tabela")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="Tabela", Order=1)]
		public  string gxTpr_Tabela
		{
			get { 
				return sdt.gxTpr_Tabela;

			}
			set { 
				 sdt.gxTpr_Tabela = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdMapearTags sdt
		{
			get { 
				return (SdtSdMapearTags)Sdt;
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
				sdt = new SdtSdMapearTags() ;
			}
		}
	}
	#endregion
}