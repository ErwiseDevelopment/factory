/*
				   File: type_SdtWWP_DesignSystemSettings
			Description: WWP_DesignSystemSettings
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
	[XmlRoot(ElementName="WWP_DesignSystemSettings")]
	[XmlType(TypeName="WWP_DesignSystemSettings" , Namespace="Factory21" )]
	[Serializable]
	public class SdtWWP_DesignSystemSettings : GxUserType
	{
		public SdtWWP_DesignSystemSettings( )
		{
			/* Constructor for serialization */
			gxTv_SdtWWP_DesignSystemSettings_Basecolor = "";

			gxTv_SdtWWP_DesignSystemSettings_Backgroundstyle = "";

			gxTv_SdtWWP_DesignSystemSettings_Fontsize = "";

			gxTv_SdtWWP_DesignSystemSettings_Menucolor = "";

		}

		public SdtWWP_DesignSystemSettings(IGxContext context)
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
			AddObjectProperty("BaseColor", gxTpr_Basecolor, false);


			AddObjectProperty("BackgroundStyle", gxTpr_Backgroundstyle, false);


			AddObjectProperty("FontSize", gxTpr_Fontsize, false);


			AddObjectProperty("MenuColor", gxTpr_Menucolor, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="BaseColor")]
		[XmlElement(ElementName="BaseColor")]
		public string gxTpr_Basecolor
		{
			get {
				return gxTv_SdtWWP_DesignSystemSettings_Basecolor; 
			}
			set {
				gxTv_SdtWWP_DesignSystemSettings_Basecolor = value;
				SetDirty("Basecolor");
			}
		}




		[SoapElement(ElementName="BackgroundStyle")]
		[XmlElement(ElementName="BackgroundStyle")]
		public string gxTpr_Backgroundstyle
		{
			get {
				return gxTv_SdtWWP_DesignSystemSettings_Backgroundstyle; 
			}
			set {
				gxTv_SdtWWP_DesignSystemSettings_Backgroundstyle = value;
				SetDirty("Backgroundstyle");
			}
		}




		[SoapElement(ElementName="FontSize")]
		[XmlElement(ElementName="FontSize")]
		public string gxTpr_Fontsize
		{
			get {
				return gxTv_SdtWWP_DesignSystemSettings_Fontsize; 
			}
			set {
				gxTv_SdtWWP_DesignSystemSettings_Fontsize = value;
				SetDirty("Fontsize");
			}
		}




		[SoapElement(ElementName="MenuColor")]
		[XmlElement(ElementName="MenuColor")]
		public string gxTpr_Menucolor
		{
			get {
				return gxTv_SdtWWP_DesignSystemSettings_Menucolor; 
			}
			set {
				gxTv_SdtWWP_DesignSystemSettings_Menucolor = value;
				SetDirty("Menucolor");
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
			gxTv_SdtWWP_DesignSystemSettings_Basecolor = "";
			gxTv_SdtWWP_DesignSystemSettings_Backgroundstyle = "";
			gxTv_SdtWWP_DesignSystemSettings_Fontsize = "";
			gxTv_SdtWWP_DesignSystemSettings_Menucolor = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtWWP_DesignSystemSettings_Basecolor;
		 

		protected string gxTv_SdtWWP_DesignSystemSettings_Backgroundstyle;
		 

		protected string gxTv_SdtWWP_DesignSystemSettings_Fontsize;
		 

		protected string gxTv_SdtWWP_DesignSystemSettings_Menucolor;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WWP_DesignSystemSettings", Namespace="Factory21")]
	public class SdtWWP_DesignSystemSettings_RESTInterface : GxGenericCollectionItem<SdtWWP_DesignSystemSettings>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWWP_DesignSystemSettings_RESTInterface( ) : base()
		{	
		}

		public SdtWWP_DesignSystemSettings_RESTInterface( SdtWWP_DesignSystemSettings psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("BaseColor")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="BaseColor", Order=0)]
		public  string gxTpr_Basecolor
		{
			get { 
				return sdt.gxTpr_Basecolor;

			}
			set { 
				 sdt.gxTpr_Basecolor = value;
			}
		}

		[JsonPropertyName("BackgroundStyle")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="BackgroundStyle", Order=1)]
		public  string gxTpr_Backgroundstyle
		{
			get { 
				return sdt.gxTpr_Backgroundstyle;

			}
			set { 
				 sdt.gxTpr_Backgroundstyle = value;
			}
		}

		[JsonPropertyName("FontSize")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="FontSize", Order=2)]
		public  string gxTpr_Fontsize
		{
			get { 
				return sdt.gxTpr_Fontsize;

			}
			set { 
				 sdt.gxTpr_Fontsize = value;
			}
		}

		[JsonPropertyName("MenuColor")]
		[JsonPropertyOrder(3)]
		[DataMember(Name="MenuColor", Order=3)]
		public  string gxTpr_Menucolor
		{
			get { 
				return sdt.gxTpr_Menucolor;

			}
			set { 
				 sdt.gxTpr_Menucolor = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtWWP_DesignSystemSettings sdt
		{
			get { 
				return (SdtWWP_DesignSystemSettings)Sdt;
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
				sdt = new SdtWWP_DesignSystemSettings() ;
			}
		}
	}
	#endregion
}