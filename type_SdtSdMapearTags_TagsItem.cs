/*
				   File: type_SdtSdMapearTags_TagsItem
			Description: Tags
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
	[XmlRoot(ElementName="SdMapearTags.TagsItem")]
	[XmlType(TypeName="SdMapearTags.TagsItem" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdMapearTags_TagsItem : GxUserType
	{
		public SdtSdMapearTags_TagsItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdMapearTags_TagsItem_Tag = "";

		}

		public SdtSdMapearTags_TagsItem(IGxContext context)
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
			AddObjectProperty("Tag", gxTpr_Tag, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Tag")]
		[XmlElement(ElementName="Tag")]
		public string gxTpr_Tag
		{
			get {
				return gxTv_SdtSdMapearTags_TagsItem_Tag; 
			}
			set {
				gxTv_SdtSdMapearTags_TagsItem_Tag = value;
				SetDirty("Tag");
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
			gxTv_SdtSdMapearTags_TagsItem_Tag = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSdMapearTags_TagsItem_Tag;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SdMapearTags.TagsItem", Namespace="Factory21")]
	public class SdtSdMapearTags_TagsItem_RESTInterface : GxGenericCollectionItem<SdtSdMapearTags_TagsItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdMapearTags_TagsItem_RESTInterface( ) : base()
		{	
		}

		public SdtSdMapearTags_TagsItem_RESTInterface( SdtSdMapearTags_TagsItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("Tag")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="Tag", Order=0)]
		public  string gxTpr_Tag
		{
			get { 
				return sdt.gxTpr_Tag;

			}
			set { 
				 sdt.gxTpr_Tag = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdMapearTags_TagsItem sdt
		{
			get { 
				return (SdtSdMapearTags_TagsItem)Sdt;
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
				sdt = new SdtSdMapearTags_TagsItem() ;
			}
		}
	}
	#endregion
}