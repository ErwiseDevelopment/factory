/*
				   File: type_SdtQueryViewerElements_Element_Format
			Description: Format
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
namespace GeneXus.Programs.genexusreporting
{
	[XmlRoot(ElementName="QueryViewerElements.Element.Format")]
	[XmlType(TypeName="QueryViewerElements.Element.Format" , Namespace="GeneXus.Reporting" )]
	[Serializable]
	public class SdtQueryViewerElements_Element_Format : GxUserType
	{
		public SdtQueryViewerElements_Element_Format( )
		{
			/* Constructor for serialization */
			gxTv_SdtQueryViewerElements_Element_Format_Picture = "";

			gxTv_SdtQueryViewerElements_Element_Format_Style = "";


		}

		public SdtQueryViewerElements_Element_Format(IGxContext context)
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
			AddObjectProperty("Picture", gxTpr_Picture, false);


			AddObjectProperty("Subtotals", gxTpr_Subtotals, false);


			AddObjectProperty("CanDragToPages", gxTpr_Candragtopages, false);


			AddObjectProperty("Style", gxTpr_Style, false);


			AddObjectProperty("TargetValue", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Targetvalue, 18, 2)), false);


			AddObjectProperty("MaximumValue", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Maximumvalue, 18, 2)), false);

			if (gxTv_SdtQueryViewerElements_Element_Format_Valuesstyles != null)
			{
				AddObjectProperty("ValuesStyles", gxTv_SdtQueryViewerElements_Element_Format_Valuesstyles, false);
			}
			if (gxTv_SdtQueryViewerElements_Element_Format_Conditionalstyles != null)
			{
				AddObjectProperty("ConditionalStyles", gxTv_SdtQueryViewerElements_Element_Format_Conditionalstyles, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Picture")]
		[XmlElement(ElementName="Picture")]
		public string gxTpr_Picture
		{
			get {
				return gxTv_SdtQueryViewerElements_Element_Format_Picture; 
			}
			set {
				gxTv_SdtQueryViewerElements_Element_Format_Picture = value;
				SetDirty("Picture");
			}
		}




		[SoapElement(ElementName="Subtotals")]
		[XmlElement(ElementName="Subtotals")]
		public short gxTpr_Subtotals
		{
			get {
				return gxTv_SdtQueryViewerElements_Element_Format_Subtotals; 
			}
			set {
				gxTv_SdtQueryViewerElements_Element_Format_Subtotals = value;
				SetDirty("Subtotals");
			}
		}




		[SoapElement(ElementName="CanDragToPages")]
		[XmlElement(ElementName="CanDragToPages")]
		public bool gxTpr_Candragtopages
		{
			get {
				return gxTv_SdtQueryViewerElements_Element_Format_Candragtopages; 
			}
			set {
				gxTv_SdtQueryViewerElements_Element_Format_Candragtopages = value;
				SetDirty("Candragtopages");
			}
		}




		[SoapElement(ElementName="Style")]
		[XmlElement(ElementName="Style")]
		public string gxTpr_Style
		{
			get {
				return gxTv_SdtQueryViewerElements_Element_Format_Style; 
			}
			set {
				gxTv_SdtQueryViewerElements_Element_Format_Style = value;
				SetDirty("Style");
			}
		}



		[SoapElement(ElementName="TargetValue")]
		[XmlElement(ElementName="TargetValue")]
		public string gxTpr_Targetvalue_double
		{
			get {
				return Convert.ToString(gxTv_SdtQueryViewerElements_Element_Format_Targetvalue, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtQueryViewerElements_Element_Format_Targetvalue = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Targetvalue
		{
			get {
				return gxTv_SdtQueryViewerElements_Element_Format_Targetvalue; 
			}
			set {
				gxTv_SdtQueryViewerElements_Element_Format_Targetvalue = value;
				SetDirty("Targetvalue");
			}
		}



		[SoapElement(ElementName="MaximumValue")]
		[XmlElement(ElementName="MaximumValue")]
		public string gxTpr_Maximumvalue_double
		{
			get {
				return Convert.ToString(gxTv_SdtQueryViewerElements_Element_Format_Maximumvalue, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtQueryViewerElements_Element_Format_Maximumvalue = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Maximumvalue
		{
			get {
				return gxTv_SdtQueryViewerElements_Element_Format_Maximumvalue; 
			}
			set {
				gxTv_SdtQueryViewerElements_Element_Format_Maximumvalue = value;
				SetDirty("Maximumvalue");
			}
		}




		[SoapElement(ElementName="ValuesStyles" )]
		[XmlArray(ElementName="ValuesStyles"  )]
		[XmlArrayItemAttribute(ElementName="ValueStyle" , IsNullable=false )]
		public GXBaseCollection<SdtQueryViewerElements_Element_Format_ValueStyle> gxTpr_Valuesstyles
		{
			get {
				if ( gxTv_SdtQueryViewerElements_Element_Format_Valuesstyles == null )
				{
					gxTv_SdtQueryViewerElements_Element_Format_Valuesstyles = new GXBaseCollection<SdtQueryViewerElements_Element_Format_ValueStyle>( context, "QueryViewerElements.Element.Format.ValueStyle", "");
				}
				SetDirty("Valuesstyles");
				return gxTv_SdtQueryViewerElements_Element_Format_Valuesstyles;
			}
			set {
				gxTv_SdtQueryViewerElements_Element_Format_Valuesstyles_N = false;
				gxTv_SdtQueryViewerElements_Element_Format_Valuesstyles = value;
				SetDirty("Valuesstyles");
			}
		}

		public void gxTv_SdtQueryViewerElements_Element_Format_Valuesstyles_SetNull()
		{
			gxTv_SdtQueryViewerElements_Element_Format_Valuesstyles_N = true;
			gxTv_SdtQueryViewerElements_Element_Format_Valuesstyles = null;
		}

		public bool gxTv_SdtQueryViewerElements_Element_Format_Valuesstyles_IsNull()
		{
			return gxTv_SdtQueryViewerElements_Element_Format_Valuesstyles == null;
		}
		public bool ShouldSerializegxTpr_Valuesstyles_GxSimpleCollection_Json()
		{
			return gxTv_SdtQueryViewerElements_Element_Format_Valuesstyles != null && gxTv_SdtQueryViewerElements_Element_Format_Valuesstyles.Count > 0;

		}



		[SoapElement(ElementName="ConditionalStyles" )]
		[XmlArray(ElementName="ConditionalStyles"  )]
		[XmlArrayItemAttribute(ElementName="ConditionalStyle" , IsNullable=false )]
		public GXBaseCollection<SdtQueryViewerElements_Element_Format_ConditionalStyle> gxTpr_Conditionalstyles
		{
			get {
				if ( gxTv_SdtQueryViewerElements_Element_Format_Conditionalstyles == null )
				{
					gxTv_SdtQueryViewerElements_Element_Format_Conditionalstyles = new GXBaseCollection<SdtQueryViewerElements_Element_Format_ConditionalStyle>( context, "QueryViewerElements.Element.Format.ConditionalStyle", "");
				}
				SetDirty("Conditionalstyles");
				return gxTv_SdtQueryViewerElements_Element_Format_Conditionalstyles;
			}
			set {
				gxTv_SdtQueryViewerElements_Element_Format_Conditionalstyles_N = false;
				gxTv_SdtQueryViewerElements_Element_Format_Conditionalstyles = value;
				SetDirty("Conditionalstyles");
			}
		}

		public void gxTv_SdtQueryViewerElements_Element_Format_Conditionalstyles_SetNull()
		{
			gxTv_SdtQueryViewerElements_Element_Format_Conditionalstyles_N = true;
			gxTv_SdtQueryViewerElements_Element_Format_Conditionalstyles = null;
		}

		public bool gxTv_SdtQueryViewerElements_Element_Format_Conditionalstyles_IsNull()
		{
			return gxTv_SdtQueryViewerElements_Element_Format_Conditionalstyles == null;
		}
		public bool ShouldSerializegxTpr_Conditionalstyles_GxSimpleCollection_Json()
		{
			return gxTv_SdtQueryViewerElements_Element_Format_Conditionalstyles != null && gxTv_SdtQueryViewerElements_Element_Format_Conditionalstyles.Count > 0;

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
			gxTv_SdtQueryViewerElements_Element_Format_Picture = "";

			gxTv_SdtQueryViewerElements_Element_Format_Candragtopages = true;
			gxTv_SdtQueryViewerElements_Element_Format_Style = "";



			gxTv_SdtQueryViewerElements_Element_Format_Valuesstyles_N = true;


			gxTv_SdtQueryViewerElements_Element_Format_Conditionalstyles_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtQueryViewerElements_Element_Format_Picture;
		 

		protected short gxTv_SdtQueryViewerElements_Element_Format_Subtotals;
		 

		protected bool gxTv_SdtQueryViewerElements_Element_Format_Candragtopages;
		 

		protected string gxTv_SdtQueryViewerElements_Element_Format_Style;
		 

		protected decimal gxTv_SdtQueryViewerElements_Element_Format_Targetvalue;
		 

		protected decimal gxTv_SdtQueryViewerElements_Element_Format_Maximumvalue;
		 
		protected bool gxTv_SdtQueryViewerElements_Element_Format_Valuesstyles_N;
		protected GXBaseCollection<SdtQueryViewerElements_Element_Format_ValueStyle> gxTv_SdtQueryViewerElements_Element_Format_Valuesstyles = null; 

		protected bool gxTv_SdtQueryViewerElements_Element_Format_Conditionalstyles_N;
		protected GXBaseCollection<SdtQueryViewerElements_Element_Format_ConditionalStyle> gxTv_SdtQueryViewerElements_Element_Format_Conditionalstyles = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"QueryViewerElements.Element.Format", Namespace="GeneXus.Reporting")]
	public class SdtQueryViewerElements_Element_Format_RESTInterface : GxGenericCollectionItem<SdtQueryViewerElements_Element_Format>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtQueryViewerElements_Element_Format_RESTInterface( ) : base()
		{	
		}

		public SdtQueryViewerElements_Element_Format_RESTInterface( SdtQueryViewerElements_Element_Format psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("Picture")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="Picture", Order=0)]
		public  string gxTpr_Picture
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Picture);

			}
			set { 
				 sdt.gxTpr_Picture = value;
			}
		}

		[JsonPropertyName("Subtotals")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="Subtotals", Order=1)]
		public short gxTpr_Subtotals
		{
			get { 
				return sdt.gxTpr_Subtotals;

			}
			set { 
				sdt.gxTpr_Subtotals = value;
			}
		}

		[JsonPropertyName("CanDragToPages")]
		[JsonPropertyOrder(2)]
		[JsonConverter(typeof(BoolStringJsonConverter))]
		[DataMember(Name="CanDragToPages", Order=2)]
		public bool gxTpr_Candragtopages
		{
			get { 
				return sdt.gxTpr_Candragtopages;

			}
			set { 
				sdt.gxTpr_Candragtopages = value;
			}
		}

		[JsonPropertyName("Style")]
		[JsonPropertyOrder(3)]
		[DataMember(Name="Style", Order=3)]
		public  string gxTpr_Style
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Style);

			}
			set { 
				 sdt.gxTpr_Style = value;
			}
		}

		[JsonPropertyName("TargetValue")]
		[JsonPropertyOrder(4)]
		[DataMember(Name="TargetValue", Order=4)]
		public  string gxTpr_Targetvalue
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Targetvalue, 18, 2));

			}
			set { 
				sdt.gxTpr_Targetvalue =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("MaximumValue")]
		[JsonPropertyOrder(5)]
		[DataMember(Name="MaximumValue", Order=5)]
		public  string gxTpr_Maximumvalue
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Maximumvalue, 18, 2));

			}
			set { 
				sdt.gxTpr_Maximumvalue =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("ValuesStyles")]
		[JsonPropertyOrder(6)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="ValuesStyles", Order=6, EmitDefaultValue=false)]
		public GxGenericCollection<SdtQueryViewerElements_Element_Format_ValueStyle_RESTInterface> gxTpr_Valuesstyles
		{
			get {
				if (sdt.ShouldSerializegxTpr_Valuesstyles_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtQueryViewerElements_Element_Format_ValueStyle_RESTInterface>(sdt.gxTpr_Valuesstyles);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Valuesstyles);
			}
		}

		[JsonPropertyName("ConditionalStyles")]
		[JsonPropertyOrder(7)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="ConditionalStyles", Order=7, EmitDefaultValue=false)]
		public GxGenericCollection<SdtQueryViewerElements_Element_Format_ConditionalStyle_RESTInterface> gxTpr_Conditionalstyles
		{
			get {
				if (sdt.ShouldSerializegxTpr_Conditionalstyles_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtQueryViewerElements_Element_Format_ConditionalStyle_RESTInterface>(sdt.gxTpr_Conditionalstyles);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Conditionalstyles);
			}
		}


		#endregion
		[JsonIgnore]
		public SdtQueryViewerElements_Element_Format sdt
		{
			get { 
				return (SdtQueryViewerElements_Element_Format)Sdt;
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
				sdt = new SdtQueryViewerElements_Element_Format() ;
			}
		}
	}
	#endregion
}