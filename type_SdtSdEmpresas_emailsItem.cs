/*
				   File: type_SdtSdEmpresas_emailsItem
			Description: emails
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
	[XmlRoot(ElementName="SdEmpresas.emailsItem")]
	[XmlType(TypeName="SdEmpresas.emailsItem" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdEmpresas_emailsItem : GxUserType
	{
		public SdtSdEmpresas_emailsItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdEmpresas_emailsItem_Address = "";

			gxTv_SdtSdEmpresas_emailsItem_Domain = "";

		}

		public SdtSdEmpresas_emailsItem(IGxContext context)
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
			AddObjectProperty("address", gxTpr_Address, false);


			AddObjectProperty("domain", gxTpr_Domain, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="address")]
		[XmlElement(ElementName="address")]
		public string gxTpr_Address
		{
			get {
				return gxTv_SdtSdEmpresas_emailsItem_Address; 
			}
			set {
				gxTv_SdtSdEmpresas_emailsItem_Address = value;
				SetDirty("Address");
			}
		}




		[SoapElement(ElementName="domain")]
		[XmlElement(ElementName="domain")]
		public string gxTpr_Domain
		{
			get {
				return gxTv_SdtSdEmpresas_emailsItem_Domain; 
			}
			set {
				gxTv_SdtSdEmpresas_emailsItem_Domain = value;
				SetDirty("Domain");
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
			gxTv_SdtSdEmpresas_emailsItem_Address = "";
			gxTv_SdtSdEmpresas_emailsItem_Domain = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSdEmpresas_emailsItem_Address;
		 

		protected string gxTv_SdtSdEmpresas_emailsItem_Domain;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SdEmpresas.emailsItem", Namespace="Factory21")]
	public class SdtSdEmpresas_emailsItem_RESTInterface : GxGenericCollectionItem<SdtSdEmpresas_emailsItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdEmpresas_emailsItem_RESTInterface( ) : base()
		{	
		}

		public SdtSdEmpresas_emailsItem_RESTInterface( SdtSdEmpresas_emailsItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("address")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="address", Order=0)]
		public  string gxTpr_Address
		{
			get { 
				return sdt.gxTpr_Address;

			}
			set { 
				 sdt.gxTpr_Address = value;
			}
		}

		[JsonPropertyName("domain")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="domain", Order=1)]
		public  string gxTpr_Domain
		{
			get { 
				return sdt.gxTpr_Domain;

			}
			set { 
				 sdt.gxTpr_Domain = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdEmpresas_emailsItem sdt
		{
			get { 
				return (SdtSdEmpresas_emailsItem)Sdt;
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
				sdt = new SdtSdEmpresas_emailsItem() ;
			}
		}
	}
	#endregion
}