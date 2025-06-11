/*
				   File: type_SdtSdClientePFPJRetorno
			Description: SdClientePFPJRetorno
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
	[XmlRoot(ElementName="SdClientePFPJRetorno")]
	[XmlType(TypeName="SdClientePFPJRetorno" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdClientePFPJRetorno : GxUserType
	{
		public SdtSdClientePFPJRetorno( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdClientePFPJRetorno_Id_N = true;

			gxTv_SdtSdClientePFPJRetorno_Document = "";
			gxTv_SdtSdClientePFPJRetorno_Document_N = true;

			gxTv_SdtSdClientePFPJRetorno_Created_at = (DateTime)(DateTime.MinValue);
			gxTv_SdtSdClientePFPJRetorno_Created_at_N = true;

			gxTv_SdtSdClientePFPJRetorno_Message = "";
			gxTv_SdtSdClientePFPJRetorno_Message_N = true;

		}

		public SdtSdClientePFPJRetorno(IGxContext context)
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
			if (ShouldSerializegxTpr_Id_Json())
			{	
				AddObjectProperty("id", gxTpr_Id, false);
			}


			if (ShouldSerializegxTpr_Document_Json())
			{	
				AddObjectProperty("document", gxTpr_Document, false);
			}


			if (ShouldSerializegxTpr_Created_at_Json())
			{	
				datetime_STZ = gxTpr_Created_at;
				sDateCnv = "";
				sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(datetime_STZ)), 10, 0));
				sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
				sDateCnv = sDateCnv + "-";
				sNumToPad = StringUtil.Trim( StringUtil.Str((decimal)(DateTimeUtil.Month(datetime_STZ)), 10, 0));
				sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
				sDateCnv = sDateCnv + "-";
				sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(datetime_STZ)), 10, 0));
				sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
				sDateCnv = sDateCnv + "T";
				sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Hour(datetime_STZ)), 10, 0));
				sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
				sDateCnv = sDateCnv + ":";
				sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Minute(datetime_STZ)), 10, 0));
				sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
				sDateCnv = sDateCnv + ":";
				sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Second(datetime_STZ)), 10, 0));
				sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
				AddObjectProperty("created_at", sDateCnv, false);

			}


			if (ShouldSerializegxTpr_Message_Json())
			{	
				AddObjectProperty("message", gxTpr_Message, false);
			}

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="id")]
		[XmlElement(ElementName="id")]
		public int gxTpr_Id
		{
			get {
				return gxTv_SdtSdClientePFPJRetorno_Id; 
			}
			set {
				gxTv_SdtSdClientePFPJRetorno_Id_N = false;
				gxTv_SdtSdClientePFPJRetorno_Id = value;
				SetDirty("Id");
			}
		}

		public bool ShouldSerializegxTpr_Id_Json()
		{
			return !gxTv_SdtSdClientePFPJRetorno_Id_N;

		}



		[SoapElement(ElementName="document")]
		[XmlElement(ElementName="document")]
		public string gxTpr_Document
		{
			get {
				return gxTv_SdtSdClientePFPJRetorno_Document; 
			}
			set {
				gxTv_SdtSdClientePFPJRetorno_Document_N = false;
				gxTv_SdtSdClientePFPJRetorno_Document = value;
				SetDirty("Document");
			}
		}

		public bool ShouldSerializegxTpr_Document_Json()
		{
			return !gxTv_SdtSdClientePFPJRetorno_Document_N;

		}


		[SoapElement(ElementName="created_at")]
		[XmlElement(ElementName="created_at" , IsNullable=true)]
		public string gxTpr_Created_at_Nullable
		{
			get {
				if ( gxTv_SdtSdClientePFPJRetorno_Created_at == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSdClientePFPJRetorno_Created_at).value ;
			}
			set {
				gxTv_SdtSdClientePFPJRetorno_Created_at = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Created_at
		{
			get {
				return gxTv_SdtSdClientePFPJRetorno_Created_at; 
			}
			set {
				gxTv_SdtSdClientePFPJRetorno_Created_at_N = false;
				gxTv_SdtSdClientePFPJRetorno_Created_at = value;
				SetDirty("Created_at");
			}
		}

		public bool ShouldSerializegxTpr_Created_at_Json()
		{
			return gxTv_SdtSdClientePFPJRetorno_Created_at != DateTime.MinValue;

		}


		[SoapElement(ElementName="message")]
		[XmlElement(ElementName="message")]
		public string gxTpr_Message
		{
			get {
				return gxTv_SdtSdClientePFPJRetorno_Message; 
			}
			set {
				gxTv_SdtSdClientePFPJRetorno_Message_N = false;
				gxTv_SdtSdClientePFPJRetorno_Message = value;
				SetDirty("Message");
			}
		}

		public bool ShouldSerializegxTpr_Message_Json()
		{
			return !gxTv_SdtSdClientePFPJRetorno_Message_N;

		}


		public override bool ShouldSerializeSdtJson()
		{
			return (
				 ShouldSerializegxTpr_Id_Json()|| 
				 ShouldSerializegxTpr_Document_Json()|| 
				 ShouldSerializegxTpr_Created_at_Json()|| 
				 ShouldSerializegxTpr_Message_Json()||  
				false);
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
			gxTv_SdtSdClientePFPJRetorno_Id_N = true;

			gxTv_SdtSdClientePFPJRetorno_Document = "";
			gxTv_SdtSdClientePFPJRetorno_Document_N = true;

			gxTv_SdtSdClientePFPJRetorno_Created_at = (DateTime)(DateTime.MinValue);
			gxTv_SdtSdClientePFPJRetorno_Created_at_N = true;

			gxTv_SdtSdClientePFPJRetorno_Message = "";
			gxTv_SdtSdClientePFPJRetorno_Message_N = true;

			datetime_STZ = (DateTime)(DateTime.MinValue);
			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected DateTime datetime_STZ ;

		protected int gxTv_SdtSdClientePFPJRetorno_Id;
		protected bool gxTv_SdtSdClientePFPJRetorno_Id_N;
		 

		protected string gxTv_SdtSdClientePFPJRetorno_Document;
		protected bool gxTv_SdtSdClientePFPJRetorno_Document_N;
		 

		protected DateTime gxTv_SdtSdClientePFPJRetorno_Created_at;
		protected bool gxTv_SdtSdClientePFPJRetorno_Created_at_N;
		 

		protected string gxTv_SdtSdClientePFPJRetorno_Message;
		protected bool gxTv_SdtSdClientePFPJRetorno_Message_N;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdClientePFPJRetorno", Namespace="Factory21")]
	public class SdtSdClientePFPJRetorno_RESTInterface : GxGenericCollectionItem<SdtSdClientePFPJRetorno>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdClientePFPJRetorno_RESTInterface( ) : base()
		{	
		}

		public SdtSdClientePFPJRetorno_RESTInterface( SdtSdClientePFPJRetorno psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("id")]
		[JsonPropertyOrder(0)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="id", Order=0, EmitDefaultValue=false)]
		public  string gxTpr_Id
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Id_Json())
					return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Id, 9, 0));
				else
					return null;

			}
			set { 
				sdt.gxTpr_Id = (int) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("document")]
		[JsonPropertyOrder(1)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="document", Order=1, EmitDefaultValue=false)]
		public  string gxTpr_Document
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Document_Json())
					return sdt.gxTpr_Document;
				else
					return null;

			}
			set { 
				 sdt.gxTpr_Document = value;
			}
		}

		[JsonPropertyName("created_at")]
		[JsonPropertyOrder(2)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="created_at", Order=2, EmitDefaultValue=false)]
		public  string gxTpr_Created_at
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Created_at_Json())
					return DateTimeUtil.TToC2( sdt.gxTpr_Created_at,context);
				else
					return null;

			}
			set { 
				sdt.gxTpr_Created_at = DateTimeUtil.CToT2(value,context);
			}
		}

		[JsonPropertyName("message")]
		[JsonPropertyOrder(3)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="message", Order=3, EmitDefaultValue=false)]
		public  string gxTpr_Message
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Message_Json())
					return sdt.gxTpr_Message;
				else
					return null;

			}
			set { 
				 sdt.gxTpr_Message = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdClientePFPJRetorno sdt
		{
			get { 
				return (SdtSdClientePFPJRetorno)Sdt;
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
				sdt = new SdtSdClientePFPJRetorno() ;
			}
		}
	}
	#endregion
}