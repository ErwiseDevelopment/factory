/*
				   File: type_SdtWWP_SDTNotificationMetadata
			Description: WWP_SDTNotificationMetadata
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
using GeneXus.Programs.wwpbaseobjects;
using GeneXus.Programs.wwpbaseobjects.notifications;
namespace GeneXus.Programs.wwpbaseobjects.notifications.common
{
	[XmlRoot(ElementName="WWP_SDTNotificationMetadata")]
	[XmlType(TypeName="WWP_SDTNotificationMetadata" , Namespace="Factory21" )]
	[Serializable]
	public class SdtWWP_SDTNotificationMetadata : GxUserType
	{
		public SdtWWP_SDTNotificationMetadata( )
		{
			/* Constructor for serialization */
			gxTv_SdtWWP_SDTNotificationMetadata_Sessionkey = "";

			gxTv_SdtWWP_SDTNotificationMetadata_Sessionvalue = "";

		}

		public SdtWWP_SDTNotificationMetadata(IGxContext context)
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
			AddObjectProperty("Timeout", gxTpr_Timeout, false);


			AddObjectProperty("SessionKey", gxTpr_Sessionkey, false);


			AddObjectProperty("SessionValue", gxTpr_Sessionvalue, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Timeout")]
		[XmlElement(ElementName="Timeout")]
		public int gxTpr_Timeout
		{
			get {
				return gxTv_SdtWWP_SDTNotificationMetadata_Timeout; 
			}
			set {
				gxTv_SdtWWP_SDTNotificationMetadata_Timeout = value;
				SetDirty("Timeout");
			}
		}




		[SoapElement(ElementName="SessionKey")]
		[XmlElement(ElementName="SessionKey")]
		public string gxTpr_Sessionkey
		{
			get {
				return gxTv_SdtWWP_SDTNotificationMetadata_Sessionkey; 
			}
			set {
				gxTv_SdtWWP_SDTNotificationMetadata_Sessionkey = value;
				SetDirty("Sessionkey");
			}
		}




		[SoapElement(ElementName="SessionValue")]
		[XmlElement(ElementName="SessionValue")]
		public string gxTpr_Sessionvalue
		{
			get {
				return gxTv_SdtWWP_SDTNotificationMetadata_Sessionvalue; 
			}
			set {
				gxTv_SdtWWP_SDTNotificationMetadata_Sessionvalue = value;
				SetDirty("Sessionvalue");
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
			gxTv_SdtWWP_SDTNotificationMetadata_Sessionkey = "";
			gxTv_SdtWWP_SDTNotificationMetadata_Sessionvalue = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected int gxTv_SdtWWP_SDTNotificationMetadata_Timeout;
		 

		protected string gxTv_SdtWWP_SDTNotificationMetadata_Sessionkey;
		 

		protected string gxTv_SdtWWP_SDTNotificationMetadata_Sessionvalue;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WWP_SDTNotificationMetadata", Namespace="Factory21")]
	public class SdtWWP_SDTNotificationMetadata_RESTInterface : GxGenericCollectionItem<SdtWWP_SDTNotificationMetadata>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWWP_SDTNotificationMetadata_RESTInterface( ) : base()
		{	
		}

		public SdtWWP_SDTNotificationMetadata_RESTInterface( SdtWWP_SDTNotificationMetadata psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("Timeout")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="Timeout", Order=0)]
		public  string gxTpr_Timeout
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Timeout, 8, 0));

			}
			set { 
				sdt.gxTpr_Timeout = (int) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("SessionKey")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="SessionKey", Order=1)]
		public  string gxTpr_Sessionkey
		{
			get { 
				return sdt.gxTpr_Sessionkey;

			}
			set { 
				 sdt.gxTpr_Sessionkey = value;
			}
		}

		[JsonPropertyName("SessionValue")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="SessionValue", Order=2)]
		public  string gxTpr_Sessionvalue
		{
			get { 
				return sdt.gxTpr_Sessionvalue;

			}
			set { 
				 sdt.gxTpr_Sessionvalue = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtWWP_SDTNotificationMetadata sdt
		{
			get { 
				return (SdtWWP_SDTNotificationMetadata)Sdt;
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
				sdt = new SdtWWP_SDTNotificationMetadata() ;
			}
		}
	}
	#endregion
}