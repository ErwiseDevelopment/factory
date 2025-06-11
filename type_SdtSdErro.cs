/*
				   File: type_SdtSdErro
			Description: SdErro
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
	[XmlRoot(ElementName="SdErro")]
	[XmlType(TypeName="SdErro" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdErro : GxUserType
	{
		public SdtSdErro( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdErro_Msg = "";

		}

		public SdtSdErro(IGxContext context)
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
			AddObjectProperty("Status", gxTpr_Status, false);


			AddObjectProperty("InternalCode", gxTpr_Internalcode, false);


			AddObjectProperty("Msg", gxTpr_Msg, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Status")]
		[XmlElement(ElementName="Status")]
		public short gxTpr_Status
		{
			get {
				return gxTv_SdtSdErro_Status; 
			}
			set {
				gxTv_SdtSdErro_Status = value;
				SetDirty("Status");
			}
		}




		[SoapElement(ElementName="InternalCode")]
		[XmlElement(ElementName="InternalCode")]
		public int gxTpr_Internalcode
		{
			get {
				return gxTv_SdtSdErro_Internalcode; 
			}
			set {
				gxTv_SdtSdErro_Internalcode = value;
				SetDirty("Internalcode");
			}
		}




		[SoapElement(ElementName="Msg")]
		[XmlElement(ElementName="Msg")]
		public string gxTpr_Msg
		{
			get {
				return gxTv_SdtSdErro_Msg; 
			}
			set {
				gxTv_SdtSdErro_Msg = value;
				SetDirty("Msg");
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
			gxTv_SdtSdErro_Msg = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtSdErro_Status;
		 

		protected int gxTv_SdtSdErro_Internalcode;
		 

		protected string gxTv_SdtSdErro_Msg;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdErro", Namespace="Factory21")]
	public class SdtSdErro_RESTInterface : GxGenericCollectionItem<SdtSdErro>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdErro_RESTInterface( ) : base()
		{	
		}

		public SdtSdErro_RESTInterface( SdtSdErro psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("Status")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="Status", Order=0)]
		public short gxTpr_Status
		{
			get { 
				return sdt.gxTpr_Status;

			}
			set { 
				sdt.gxTpr_Status = value;
			}
		}

		[JsonPropertyName("InternalCode")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="InternalCode", Order=1)]
		public int gxTpr_Internalcode
		{
			get { 
				return sdt.gxTpr_Internalcode;

			}
			set { 
				sdt.gxTpr_Internalcode = value;
			}
		}

		[JsonPropertyName("Msg")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="Msg", Order=2)]
		public  string gxTpr_Msg
		{
			get { 
				return sdt.gxTpr_Msg;

			}
			set { 
				 sdt.gxTpr_Msg = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdErro sdt
		{
			get { 
				return (SdtSdErro)Sdt;
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
				sdt = new SdtSdErro() ;
			}
		}
	}
	#endregion
}