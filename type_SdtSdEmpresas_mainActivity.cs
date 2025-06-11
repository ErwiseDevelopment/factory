/*
				   File: type_SdtSdEmpresas_mainActivity
			Description: mainActivity
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
	[XmlRoot(ElementName="SdEmpresas.mainActivity")]
	[XmlType(TypeName="SdEmpresas.mainActivity" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdEmpresas_mainActivity : GxUserType
	{
		public SdtSdEmpresas_mainActivity( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdEmpresas_mainActivity_Text = "";

		}

		public SdtSdEmpresas_mainActivity(IGxContext context)
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
			AddObjectProperty("id", gxTpr_Id, false);


			AddObjectProperty("text", gxTpr_Text, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="id")]
		[XmlElement(ElementName="id")]
		public string gxTpr_Id_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdEmpresas_mainActivity_Id, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdEmpresas_mainActivity_Id = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Id
		{
			get {
				return gxTv_SdtSdEmpresas_mainActivity_Id; 
			}
			set {
				gxTv_SdtSdEmpresas_mainActivity_Id = value;
				SetDirty("Id");
			}
		}




		[SoapElement(ElementName="text")]
		[XmlElement(ElementName="text")]
		public string gxTpr_Text
		{
			get {
				return gxTv_SdtSdEmpresas_mainActivity_Text; 
			}
			set {
				gxTv_SdtSdEmpresas_mainActivity_Text = value;
				SetDirty("Text");
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
			gxTv_SdtSdEmpresas_mainActivity_Text = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected decimal gxTv_SdtSdEmpresas_mainActivity_Id;
		 

		protected string gxTv_SdtSdEmpresas_mainActivity_Text;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdEmpresas.mainActivity", Namespace="Factory21")]
	public class SdtSdEmpresas_mainActivity_RESTInterface : GxGenericCollectionItem<SdtSdEmpresas_mainActivity>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdEmpresas_mainActivity_RESTInterface( ) : base()
		{	
		}

		public SdtSdEmpresas_mainActivity_RESTInterface( SdtSdEmpresas_mainActivity psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("id")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="id", Order=0)]
		public  string gxTpr_Id
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Id, 10, 5));

			}
			set { 
				sdt.gxTpr_Id =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("text")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="text", Order=1)]
		public  string gxTpr_Text
		{
			get { 
				return sdt.gxTpr_Text;

			}
			set { 
				 sdt.gxTpr_Text = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdEmpresas_mainActivity sdt
		{
			get { 
				return (SdtSdEmpresas_mainActivity)Sdt;
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
				sdt = new SdtSdEmpresas_mainActivity() ;
			}
		}
	}
	#endregion
}