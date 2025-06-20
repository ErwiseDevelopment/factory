/*
				   File: type_SdtGxMap_Line
			Description: Lines
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
	[XmlRoot(ElementName="GxMap.Line")]
	[XmlType(TypeName="GxMap.Line" , Namespace="Factory21" )]
	[Serializable]
	public class SdtGxMap_Line : GxUserType
	{
		public SdtGxMap_Line( )
		{
			/* Constructor for serialization */
			gxTv_SdtGxMap_Line_Linestrokecolor = "";


		}

		public SdtGxMap_Line(IGxContext context)
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
			AddObjectProperty("LineStrokeColor", gxTpr_Linestrokecolor, false);


			AddObjectProperty("LineStrokeOpacity", gxTpr_Linestrokeopacity, false);


			AddObjectProperty("LineStrokeWeight", gxTpr_Linestrokeweight, false);

			if (gxTv_SdtGxMap_Line_Points != null)
			{
				AddObjectProperty("Points", gxTv_SdtGxMap_Line_Points, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="LineStrokeColor")]
		[XmlElement(ElementName="LineStrokeColor")]
		public string gxTpr_Linestrokecolor
		{
			get {
				return gxTv_SdtGxMap_Line_Linestrokecolor; 
			}
			set {
				gxTv_SdtGxMap_Line_Linestrokecolor = value;
				SetDirty("Linestrokecolor");
			}
		}



		[SoapElement(ElementName="LineStrokeOpacity")]
		[XmlElement(ElementName="LineStrokeOpacity")]
		public string gxTpr_Linestrokeopacity_double
		{
			get {
				return Convert.ToString(gxTv_SdtGxMap_Line_Linestrokeopacity, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtGxMap_Line_Linestrokeopacity = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Linestrokeopacity
		{
			get {
				return gxTv_SdtGxMap_Line_Linestrokeopacity; 
			}
			set {
				gxTv_SdtGxMap_Line_Linestrokeopacity = value;
				SetDirty("Linestrokeopacity");
			}
		}




		[SoapElement(ElementName="LineStrokeWeight")]
		[XmlElement(ElementName="LineStrokeWeight")]
		public short gxTpr_Linestrokeweight
		{
			get {
				return gxTv_SdtGxMap_Line_Linestrokeweight; 
			}
			set {
				gxTv_SdtGxMap_Line_Linestrokeweight = value;
				SetDirty("Linestrokeweight");
			}
		}




		[SoapElement(ElementName="Points" )]
		[XmlArray(ElementName="Points"  )]
		[XmlArrayItemAttribute(ElementName="Point" , IsNullable=false )]
		public GXBaseCollection<SdtGxMap_Line_Point> gxTpr_Points
		{
			get {
				if ( gxTv_SdtGxMap_Line_Points == null )
				{
					gxTv_SdtGxMap_Line_Points = new GXBaseCollection<SdtGxMap_Line_Point>( context, "GxMap.Line.Point", "");
				}
				SetDirty("Points");
				return gxTv_SdtGxMap_Line_Points;
			}
			set {
				gxTv_SdtGxMap_Line_Points_N = false;
				gxTv_SdtGxMap_Line_Points = value;
				SetDirty("Points");
			}
		}

		public void gxTv_SdtGxMap_Line_Points_SetNull()
		{
			gxTv_SdtGxMap_Line_Points_N = true;
			gxTv_SdtGxMap_Line_Points = null;
		}

		public bool gxTv_SdtGxMap_Line_Points_IsNull()
		{
			return gxTv_SdtGxMap_Line_Points == null;
		}
		public bool ShouldSerializegxTpr_Points_GxSimpleCollection_Json()
		{
			return gxTv_SdtGxMap_Line_Points != null && gxTv_SdtGxMap_Line_Points.Count > 0;

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
			gxTv_SdtGxMap_Line_Linestrokecolor = "";



			gxTv_SdtGxMap_Line_Points_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtGxMap_Line_Linestrokecolor;
		 

		protected decimal gxTv_SdtGxMap_Line_Linestrokeopacity;
		 

		protected short gxTv_SdtGxMap_Line_Linestrokeweight;
		 
		protected bool gxTv_SdtGxMap_Line_Points_N;
		protected GXBaseCollection<SdtGxMap_Line_Point> gxTv_SdtGxMap_Line_Points = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"GxMap.Line", Namespace="Factory21")]
	public class SdtGxMap_Line_RESTInterface : GxGenericCollectionItem<SdtGxMap_Line>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtGxMap_Line_RESTInterface( ) : base()
		{	
		}

		public SdtGxMap_Line_RESTInterface( SdtGxMap_Line psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("LineStrokeColor")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="LineStrokeColor", Order=0)]
		public  string gxTpr_Linestrokecolor
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Linestrokecolor);

			}
			set { 
				 sdt.gxTpr_Linestrokecolor = value;
			}
		}

		[JsonPropertyName("LineStrokeOpacity")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="LineStrokeOpacity", Order=1)]
		public decimal gxTpr_Linestrokeopacity
		{
			get { 
				return sdt.gxTpr_Linestrokeopacity;

			}
			set { 
				sdt.gxTpr_Linestrokeopacity = value;
			}
		}

		[JsonPropertyName("LineStrokeWeight")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="LineStrokeWeight", Order=2)]
		public short gxTpr_Linestrokeweight
		{
			get { 
				return sdt.gxTpr_Linestrokeweight;

			}
			set { 
				sdt.gxTpr_Linestrokeweight = value;
			}
		}

		[JsonPropertyName("Points")]
		[JsonPropertyOrder(3)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="Points", Order=3, EmitDefaultValue=false)]
		public GxGenericCollection<SdtGxMap_Line_Point_RESTInterface> gxTpr_Points
		{
			get {
				if (sdt.ShouldSerializegxTpr_Points_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtGxMap_Line_Point_RESTInterface>(sdt.gxTpr_Points);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Points);
			}
		}


		#endregion
		[JsonIgnore]
		public SdtGxMap_Line sdt
		{
			get { 
				return (SdtGxMap_Line)Sdt;
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
				sdt = new SdtGxMap_Line() ;
			}
		}
	}
	#endregion
}