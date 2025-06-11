/*
				   File: type_SdtSdEmpresas_company_size
			Description: size
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
	[XmlRoot(ElementName="SdEmpresas.company.size")]
	[XmlType(TypeName="SdEmpresas.company.size" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdEmpresas_company_size : GxUserType
	{
		public SdtSdEmpresas_company_size( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdEmpresas_company_size_Acronym = "";

			gxTv_SdtSdEmpresas_company_size_Text = "";

		}

		public SdtSdEmpresas_company_size(IGxContext context)
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


			AddObjectProperty("acronym", gxTpr_Acronym, false);


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
				return Convert.ToString(gxTv_SdtSdEmpresas_company_size_Id, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdEmpresas_company_size_Id = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Id
		{
			get {
				return gxTv_SdtSdEmpresas_company_size_Id; 
			}
			set {
				gxTv_SdtSdEmpresas_company_size_Id = value;
				SetDirty("Id");
			}
		}




		[SoapElement(ElementName="acronym")]
		[XmlElement(ElementName="acronym")]
		public string gxTpr_Acronym
		{
			get {
				return gxTv_SdtSdEmpresas_company_size_Acronym; 
			}
			set {
				gxTv_SdtSdEmpresas_company_size_Acronym = value;
				SetDirty("Acronym");
			}
		}




		[SoapElement(ElementName="text")]
		[XmlElement(ElementName="text")]
		public string gxTpr_Text
		{
			get {
				return gxTv_SdtSdEmpresas_company_size_Text; 
			}
			set {
				gxTv_SdtSdEmpresas_company_size_Text = value;
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
			gxTv_SdtSdEmpresas_company_size_Acronym = "";
			gxTv_SdtSdEmpresas_company_size_Text = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected decimal gxTv_SdtSdEmpresas_company_size_Id;
		 

		protected string gxTv_SdtSdEmpresas_company_size_Acronym;
		 

		protected string gxTv_SdtSdEmpresas_company_size_Text;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdEmpresas.company.size", Namespace="Factory21")]
	public class SdtSdEmpresas_company_size_RESTInterface : GxGenericCollectionItem<SdtSdEmpresas_company_size>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdEmpresas_company_size_RESTInterface( ) : base()
		{	
		}

		public SdtSdEmpresas_company_size_RESTInterface( SdtSdEmpresas_company_size psdt ) : base(psdt)
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

		[JsonPropertyName("acronym")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="acronym", Order=1)]
		public  string gxTpr_Acronym
		{
			get { 
				return sdt.gxTpr_Acronym;

			}
			set { 
				 sdt.gxTpr_Acronym = value;
			}
		}

		[JsonPropertyName("text")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="text", Order=2)]
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
		public SdtSdEmpresas_company_size sdt
		{
			get { 
				return (SdtSdEmpresas_company_size)Sdt;
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
				sdt = new SdtSdEmpresas_company_size() ;
			}
		}
	}
	#endregion
}