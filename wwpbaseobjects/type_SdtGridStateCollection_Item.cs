/*
				   File: type_SdtGridStateCollection_Item
			Description: GridStateCollection
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
	[XmlRoot(ElementName="Item")]
	[XmlType(TypeName="Item" , Namespace="" )]
	[Serializable]
	public class SdtGridStateCollection_Item : GxUserType
	{
		public SdtGridStateCollection_Item( )
		{
			/* Constructor for serialization */
			gxTv_SdtGridStateCollection_Item_Title = "";

			gxTv_SdtGridStateCollection_Item_Gridstatexml = "";

		}

		public SdtGridStateCollection_Item(IGxContext context)
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
			AddObjectProperty("Title", gxTpr_Title, false);


			AddObjectProperty("GridStateXML", gxTpr_Gridstatexml, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Title")]
		[XmlElement(ElementName="Title")]
		public string gxTpr_Title
		{
			get {
				return gxTv_SdtGridStateCollection_Item_Title; 
			}
			set {
				gxTv_SdtGridStateCollection_Item_Title = value;
				SetDirty("Title");
			}
		}




		[SoapElement(ElementName="GridStateXML")]
		[XmlElement(ElementName="GridStateXML")]
		public string gxTpr_Gridstatexml
		{
			get {
				return gxTv_SdtGridStateCollection_Item_Gridstatexml; 
			}
			set {
				gxTv_SdtGridStateCollection_Item_Gridstatexml = value;
				SetDirty("Gridstatexml");
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
			gxTv_SdtGridStateCollection_Item_Title = "";
			gxTv_SdtGridStateCollection_Item_Gridstatexml = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtGridStateCollection_Item_Title;
		 

		protected string gxTv_SdtGridStateCollection_Item_Gridstatexml;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"Item", Namespace="")]
	public class SdtGridStateCollection_Item_RESTInterface : GxGenericCollectionItem<SdtGridStateCollection_Item>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtGridStateCollection_Item_RESTInterface( ) : base()
		{	
		}

		public SdtGridStateCollection_Item_RESTInterface( SdtGridStateCollection_Item psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("Title")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="Title", Order=0)]
		public  string gxTpr_Title
		{
			get { 
				return sdt.gxTpr_Title;

			}
			set { 
				 sdt.gxTpr_Title = value;
			}
		}

		[JsonPropertyName("GridStateXML")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="GridStateXML", Order=1)]
		public  string gxTpr_Gridstatexml
		{
			get { 
				return sdt.gxTpr_Gridstatexml;

			}
			set { 
				 sdt.gxTpr_Gridstatexml = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtGridStateCollection_Item sdt
		{
			get { 
				return (SdtGridStateCollection_Item)Sdt;
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
				sdt = new SdtGridStateCollection_Item() ;
			}
		}
	}
	#endregion
}