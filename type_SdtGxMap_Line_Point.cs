/*
				   File: type_SdtGxMap_Line_Point
			Description: Points
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
	[XmlRoot(ElementName="GxMap.Line.Point")]
	[XmlType(TypeName="GxMap.Line.Point" , Namespace="Factory21" )]
	[Serializable]
	public class SdtGxMap_Line_Point : GxUserType
	{
		public SdtGxMap_Line_Point( )
		{
			/* Constructor for serialization */
			gxTv_SdtGxMap_Line_Point_Pointlat = "";

			gxTv_SdtGxMap_Line_Point_Pointlong = "";

		}

		public SdtGxMap_Line_Point(IGxContext context)
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
			AddObjectProperty("PointLat", gxTpr_Pointlat, false);


			AddObjectProperty("PointLong", gxTpr_Pointlong, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="PointLat")]
		[XmlElement(ElementName="PointLat")]
		public string gxTpr_Pointlat
		{
			get {
				return gxTv_SdtGxMap_Line_Point_Pointlat; 
			}
			set {
				gxTv_SdtGxMap_Line_Point_Pointlat = value;
				SetDirty("Pointlat");
			}
		}




		[SoapElement(ElementName="PointLong")]
		[XmlElement(ElementName="PointLong")]
		public string gxTpr_Pointlong
		{
			get {
				return gxTv_SdtGxMap_Line_Point_Pointlong; 
			}
			set {
				gxTv_SdtGxMap_Line_Point_Pointlong = value;
				SetDirty("Pointlong");
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
			gxTv_SdtGxMap_Line_Point_Pointlat = "";
			gxTv_SdtGxMap_Line_Point_Pointlong = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtGxMap_Line_Point_Pointlat;
		 

		protected string gxTv_SdtGxMap_Line_Point_Pointlong;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"GxMap.Line.Point", Namespace="Factory21")]
	public class SdtGxMap_Line_Point_RESTInterface : GxGenericCollectionItem<SdtGxMap_Line_Point>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtGxMap_Line_Point_RESTInterface( ) : base()
		{	
		}

		public SdtGxMap_Line_Point_RESTInterface( SdtGxMap_Line_Point psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("PointLat")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="PointLat", Order=0)]
		public  string gxTpr_Pointlat
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Pointlat);

			}
			set { 
				 sdt.gxTpr_Pointlat = value;
			}
		}

		[JsonPropertyName("PointLong")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="PointLong", Order=1)]
		public  string gxTpr_Pointlong
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Pointlong);

			}
			set { 
				 sdt.gxTpr_Pointlong = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtGxMap_Line_Point sdt
		{
			get { 
				return (SdtGxMap_Line_Point)Sdt;
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
				sdt = new SdtGxMap_Line_Point() ;
			}
		}
	}
	#endregion
}