/*
				   File: type_SdtSdConteudoRecomendaPF
			Description: SdConteudoRecomendaPF
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
	[XmlRoot(ElementName="SdConteudoRecomendaPF")]
	[XmlType(TypeName="SdConteudoRecomendaPF" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdConteudoRecomendaPF : GxUserType
	{
		public SdtSdConteudoRecomendaPF( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdConteudoRecomendaPF_Message = "";

		}

		public SdtSdConteudoRecomendaPF(IGxContext context)
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
			AddObjectProperty("code", gxTpr_Code, false);


			AddObjectProperty("message", gxTpr_Message, false);

			if (gxTv_SdtSdConteudoRecomendaPF_Data != null)
			{
				AddObjectProperty("data", gxTv_SdtSdConteudoRecomendaPF_Data, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="code")]
		[XmlElement(ElementName="code")]
		public string gxTpr_Code_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdConteudoRecomendaPF_Code, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_Code = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Code
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_Code; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_Code = value;
				SetDirty("Code");
			}
		}




		[SoapElement(ElementName="message")]
		[XmlElement(ElementName="message")]
		public string gxTpr_Message
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_Message; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_Message = value;
				SetDirty("Message");
			}
		}



		[SoapElement(ElementName="data" )]
		[XmlElement(ElementName="data" )]
		public SdtSdConteudoRecomendaPF_data gxTpr_Data
		{
			get {
				if ( gxTv_SdtSdConteudoRecomendaPF_Data == null )
				{
					gxTv_SdtSdConteudoRecomendaPF_Data = new SdtSdConteudoRecomendaPF_data(context);
				}
				gxTv_SdtSdConteudoRecomendaPF_Data_N = false;
				SetDirty("Data");
				return gxTv_SdtSdConteudoRecomendaPF_Data;
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_Data_N = false;
				gxTv_SdtSdConteudoRecomendaPF_Data = value;
				SetDirty("Data");
			}

		}

		public void gxTv_SdtSdConteudoRecomendaPF_Data_SetNull()
		{
			gxTv_SdtSdConteudoRecomendaPF_Data_N = true;
			gxTv_SdtSdConteudoRecomendaPF_Data = null;
		}

		public bool gxTv_SdtSdConteudoRecomendaPF_Data_IsNull()
		{
			return gxTv_SdtSdConteudoRecomendaPF_Data == null;
		}
		public bool ShouldSerializegxTpr_Data_Json()
		{
				return (gxTv_SdtSdConteudoRecomendaPF_Data != null && gxTv_SdtSdConteudoRecomendaPF_Data.ShouldSerializeSdtJson());

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
			gxTv_SdtSdConteudoRecomendaPF_Message = "";

			gxTv_SdtSdConteudoRecomendaPF_Data_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected decimal gxTv_SdtSdConteudoRecomendaPF_Code;
		 

		protected string gxTv_SdtSdConteudoRecomendaPF_Message;
		 
		protected bool gxTv_SdtSdConteudoRecomendaPF_Data_N;
		protected SdtSdConteudoRecomendaPF_data gxTv_SdtSdConteudoRecomendaPF_Data = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdConteudoRecomendaPF", Namespace="Factory21")]
	public class SdtSdConteudoRecomendaPF_RESTInterface : GxGenericCollectionItem<SdtSdConteudoRecomendaPF>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdConteudoRecomendaPF_RESTInterface( ) : base()
		{	
		}

		public SdtSdConteudoRecomendaPF_RESTInterface( SdtSdConteudoRecomendaPF psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("code")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="code", Order=0)]
		public  string gxTpr_Code
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Code, 10, 5));

			}
			set { 
				sdt.gxTpr_Code =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("message")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="message", Order=1)]
		public  string gxTpr_Message
		{
			get { 
				return sdt.gxTpr_Message;

			}
			set { 
				 sdt.gxTpr_Message = value;
			}
		}

		[JsonPropertyName("data")]
		[JsonPropertyOrder(2)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="data", Order=2, EmitDefaultValue=false)]
		public SdtSdConteudoRecomendaPF_data_RESTInterface gxTpr_Data
		{
			get {
				if (sdt.ShouldSerializegxTpr_Data_Json())
					return new SdtSdConteudoRecomendaPF_data_RESTInterface(sdt.gxTpr_Data);
				else
					return null;

			}

			set {
				sdt.gxTpr_Data = value.sdt;
			}

		}


		#endregion
		[JsonIgnore]
		public SdtSdConteudoRecomendaPF sdt
		{
			get { 
				return (SdtSdConteudoRecomendaPF)Sdt;
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
				sdt = new SdtSdConteudoRecomendaPF() ;
			}
		}
	}
	#endregion
}