/*
				   File: type_SdtSdEmpresas_phonesItem
			Description: phones
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
	[XmlRoot(ElementName="SdEmpresas.phonesItem")]
	[XmlType(TypeName="SdEmpresas.phonesItem" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdEmpresas_phonesItem : GxUserType
	{
		public SdtSdEmpresas_phonesItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdEmpresas_phonesItem_Area = "";

			gxTv_SdtSdEmpresas_phonesItem_Number = "";

		}

		public SdtSdEmpresas_phonesItem(IGxContext context)
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
			AddObjectProperty("area", gxTpr_Area, false);


			AddObjectProperty("number", gxTpr_Number, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="area")]
		[XmlElement(ElementName="area")]
		public string gxTpr_Area
		{
			get {
				return gxTv_SdtSdEmpresas_phonesItem_Area; 
			}
			set {
				gxTv_SdtSdEmpresas_phonesItem_Area = value;
				SetDirty("Area");
			}
		}




		[SoapElement(ElementName="number")]
		[XmlElement(ElementName="number")]
		public string gxTpr_Number
		{
			get {
				return gxTv_SdtSdEmpresas_phonesItem_Number; 
			}
			set {
				gxTv_SdtSdEmpresas_phonesItem_Number = value;
				SetDirty("Number");
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
			gxTv_SdtSdEmpresas_phonesItem_Area = "";
			gxTv_SdtSdEmpresas_phonesItem_Number = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSdEmpresas_phonesItem_Area;
		 

		protected string gxTv_SdtSdEmpresas_phonesItem_Number;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SdEmpresas.phonesItem", Namespace="Factory21")]
	public class SdtSdEmpresas_phonesItem_RESTInterface : GxGenericCollectionItem<SdtSdEmpresas_phonesItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdEmpresas_phonesItem_RESTInterface( ) : base()
		{	
		}

		public SdtSdEmpresas_phonesItem_RESTInterface( SdtSdEmpresas_phonesItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("area")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="area", Order=0)]
		public  string gxTpr_Area
		{
			get { 
				return sdt.gxTpr_Area;

			}
			set { 
				 sdt.gxTpr_Area = value;
			}
		}

		[JsonPropertyName("number")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="number", Order=1)]
		public  string gxTpr_Number
		{
			get { 
				return sdt.gxTpr_Number;

			}
			set { 
				 sdt.gxTpr_Number = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdEmpresas_phonesItem sdt
		{
			get { 
				return (SdtSdEmpresas_phonesItem)Sdt;
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
				sdt = new SdtSdEmpresas_phonesItem() ;
			}
		}
	}
	#endregion
}