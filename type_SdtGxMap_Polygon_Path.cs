/*
				   File: type_SdtGxMap_Polygon_Path
			Description: Paths
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
	[XmlRoot(ElementName="GxMap.Polygon.Path")]
	[XmlType(TypeName="GxMap.Polygon.Path" , Namespace="Factory21" )]
	[Serializable]
	public class SdtGxMap_Polygon_Path : GxUserType
	{
		public SdtGxMap_Polygon_Path( )
		{
			/* Constructor for serialization */
			gxTv_SdtGxMap_Polygon_Path_Pathlat = "";

			gxTv_SdtGxMap_Polygon_Path_Pathlong = "";

		}

		public SdtGxMap_Polygon_Path(IGxContext context)
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
			AddObjectProperty("PathLat", gxTpr_Pathlat, false);


			AddObjectProperty("PathLong", gxTpr_Pathlong, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="PathLat")]
		[XmlElement(ElementName="PathLat")]
		public string gxTpr_Pathlat
		{
			get {
				return gxTv_SdtGxMap_Polygon_Path_Pathlat; 
			}
			set {
				gxTv_SdtGxMap_Polygon_Path_Pathlat = value;
				SetDirty("Pathlat");
			}
		}




		[SoapElement(ElementName="PathLong")]
		[XmlElement(ElementName="PathLong")]
		public string gxTpr_Pathlong
		{
			get {
				return gxTv_SdtGxMap_Polygon_Path_Pathlong; 
			}
			set {
				gxTv_SdtGxMap_Polygon_Path_Pathlong = value;
				SetDirty("Pathlong");
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
			gxTv_SdtGxMap_Polygon_Path_Pathlat = "";
			gxTv_SdtGxMap_Polygon_Path_Pathlong = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtGxMap_Polygon_Path_Pathlat;
		 

		protected string gxTv_SdtGxMap_Polygon_Path_Pathlong;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"GxMap.Polygon.Path", Namespace="Factory21")]
	public class SdtGxMap_Polygon_Path_RESTInterface : GxGenericCollectionItem<SdtGxMap_Polygon_Path>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtGxMap_Polygon_Path_RESTInterface( ) : base()
		{	
		}

		public SdtGxMap_Polygon_Path_RESTInterface( SdtGxMap_Polygon_Path psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("PathLat")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="PathLat", Order=0)]
		public  string gxTpr_Pathlat
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Pathlat);

			}
			set { 
				 sdt.gxTpr_Pathlat = value;
			}
		}

		[JsonPropertyName("PathLong")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="PathLong", Order=1)]
		public  string gxTpr_Pathlong
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Pathlong);

			}
			set { 
				 sdt.gxTpr_Pathlong = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtGxMap_Polygon_Path sdt
		{
			get { 
				return (SdtGxMap_Polygon_Path)Sdt;
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
				sdt = new SdtGxMap_Polygon_Path() ;
			}
		}
	}
	#endregion
}