/*
				   File: type_SdtSdEmpresas_address_country
			Description: country
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
	[XmlRoot(ElementName="SdEmpresas.address.country")]
	[XmlType(TypeName="SdEmpresas.address.country" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdEmpresas_address_country : GxUserType
	{
		public SdtSdEmpresas_address_country( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdEmpresas_address_country_Name = "";

		}

		public SdtSdEmpresas_address_country(IGxContext context)
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


			AddObjectProperty("name", gxTpr_Name, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="id")]
		[XmlElement(ElementName="id")]
		public string gxTpr_Id_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdEmpresas_address_country_Id, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdEmpresas_address_country_Id = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Id
		{
			get {
				return gxTv_SdtSdEmpresas_address_country_Id; 
			}
			set {
				gxTv_SdtSdEmpresas_address_country_Id = value;
				SetDirty("Id");
			}
		}




		[SoapElement(ElementName="name")]
		[XmlElement(ElementName="name")]
		public string gxTpr_Name
		{
			get {
				return gxTv_SdtSdEmpresas_address_country_Name; 
			}
			set {
				gxTv_SdtSdEmpresas_address_country_Name = value;
				SetDirty("Name");
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
			gxTv_SdtSdEmpresas_address_country_Name = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected decimal gxTv_SdtSdEmpresas_address_country_Id;
		 

		protected string gxTv_SdtSdEmpresas_address_country_Name;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdEmpresas.address.country", Namespace="Factory21")]
	public class SdtSdEmpresas_address_country_RESTInterface : GxGenericCollectionItem<SdtSdEmpresas_address_country>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdEmpresas_address_country_RESTInterface( ) : base()
		{	
		}

		public SdtSdEmpresas_address_country_RESTInterface( SdtSdEmpresas_address_country psdt ) : base(psdt)
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

		[JsonPropertyName("name")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="name", Order=1)]
		public  string gxTpr_Name
		{
			get { 
				return sdt.gxTpr_Name;

			}
			set { 
				 sdt.gxTpr_Name = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdEmpresas_address_country sdt
		{
			get { 
				return (SdtSdEmpresas_address_country)Sdt;
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
				sdt = new SdtSdEmpresas_address_country() ;
			}
		}
	}
	#endregion
}