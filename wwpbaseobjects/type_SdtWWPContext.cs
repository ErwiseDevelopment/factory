/*
				   File: type_SdtWWPContext
			Description: WWPContext
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
	[XmlRoot(ElementName="WWPContext")]
	[XmlType(TypeName="WWPContext" , Namespace="Factory21" )]
	[Serializable]
	public class SdtWWPContext : GxUserType
	{
		public SdtWWPContext( )
		{
			/* Constructor for serialization */
			gxTv_SdtWWPContext_Username = "";

			gxTv_SdtWWPContext_Userfullname = "";

			gxTv_SdtWWPContext_Expire = (DateTime)(DateTime.MinValue);


		}

		public SdtWWPContext(IGxContext context)
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
			AddObjectProperty("UserId", gxTpr_Userid, false);


			AddObjectProperty("UserName", gxTpr_Username, false);


			AddObjectProperty("UserFullname", gxTpr_Userfullname, false);


			datetime_STZ = gxTpr_Expire;
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
			AddObjectProperty("Expire", sDateCnv, false);



			AddObjectProperty("OwnerId", gxTpr_Ownerid, false);


			AddObjectProperty("IsAprover", gxTpr_Isaprover, false);


			AddObjectProperty("IsCliente", gxTpr_Iscliente, false);


			AddObjectProperty("SecUserClienteId", gxTpr_Secuserclienteid, false);


			AddObjectProperty("SecUserAnalista", gxTpr_Secuseranalista, false);


			AddObjectProperty("AprovadorId", gxTpr_Aprovadorid, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="UserId")]
		[XmlElement(ElementName="UserId")]
		public short gxTpr_Userid
		{
			get {
				return gxTv_SdtWWPContext_Userid; 
			}
			set {
				gxTv_SdtWWPContext_Userid = value;
				SetDirty("Userid");
			}
		}




		[SoapElement(ElementName="UserName")]
		[XmlElement(ElementName="UserName")]
		public string gxTpr_Username
		{
			get {
				return gxTv_SdtWWPContext_Username; 
			}
			set {
				gxTv_SdtWWPContext_Username = value;
				SetDirty("Username");
			}
		}




		[SoapElement(ElementName="UserFullname")]
		[XmlElement(ElementName="UserFullname")]
		public string gxTpr_Userfullname
		{
			get {
				return gxTv_SdtWWPContext_Userfullname; 
			}
			set {
				gxTv_SdtWWPContext_Userfullname = value;
				SetDirty("Userfullname");
			}
		}



		[SoapElement(ElementName="Expire")]
		[XmlElement(ElementName="Expire" , IsNullable=true)]
		public string gxTpr_Expire_Nullable
		{
			get {
				if ( gxTv_SdtWWPContext_Expire == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtWWPContext_Expire).value ;
			}
			set {
				gxTv_SdtWWPContext_Expire = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Expire
		{
			get {
				return gxTv_SdtWWPContext_Expire; 
			}
			set {
				gxTv_SdtWWPContext_Expire = value;
				SetDirty("Expire");
			}
		}



		[SoapElement(ElementName="OwnerId")]
		[XmlElement(ElementName="OwnerId")]
		public short gxTpr_Ownerid
		{
			get {
				return gxTv_SdtWWPContext_Ownerid; 
			}
			set {
				gxTv_SdtWWPContext_Ownerid = value;
				SetDirty("Ownerid");
			}
		}




		[SoapElement(ElementName="IsAprover")]
		[XmlElement(ElementName="IsAprover")]
		public bool gxTpr_Isaprover
		{
			get {
				return gxTv_SdtWWPContext_Isaprover; 
			}
			set {
				gxTv_SdtWWPContext_Isaprover = value;
				SetDirty("Isaprover");
			}
		}




		[SoapElement(ElementName="IsCliente")]
		[XmlElement(ElementName="IsCliente")]
		public bool gxTpr_Iscliente
		{
			get {
				return gxTv_SdtWWPContext_Iscliente; 
			}
			set {
				gxTv_SdtWWPContext_Iscliente = value;
				SetDirty("Iscliente");
			}
		}




		[SoapElement(ElementName="SecUserClienteId")]
		[XmlElement(ElementName="SecUserClienteId")]
		public short gxTpr_Secuserclienteid
		{
			get {
				return gxTv_SdtWWPContext_Secuserclienteid; 
			}
			set {
				gxTv_SdtWWPContext_Secuserclienteid = value;
				SetDirty("Secuserclienteid");
			}
		}




		[SoapElement(ElementName="SecUserAnalista")]
		[XmlElement(ElementName="SecUserAnalista")]
		public bool gxTpr_Secuseranalista
		{
			get {
				return gxTv_SdtWWPContext_Secuseranalista; 
			}
			set {
				gxTv_SdtWWPContext_Secuseranalista = value;
				SetDirty("Secuseranalista");
			}
		}




		[SoapElement(ElementName="AprovadorId")]
		[XmlElement(ElementName="AprovadorId")]
		public short gxTpr_Aprovadorid
		{
			get {
				return gxTv_SdtWWPContext_Aprovadorid; 
			}
			set {
				gxTv_SdtWWPContext_Aprovadorid = value;
				SetDirty("Aprovadorid");
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
			gxTv_SdtWWPContext_Username = "";
			gxTv_SdtWWPContext_Userfullname = "";
			gxTv_SdtWWPContext_Expire = (DateTime)(DateTime.MinValue);






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

		protected short gxTv_SdtWWPContext_Userid;
		 

		protected string gxTv_SdtWWPContext_Username;
		 

		protected string gxTv_SdtWWPContext_Userfullname;
		 

		protected DateTime gxTv_SdtWWPContext_Expire;
		 

		protected short gxTv_SdtWWPContext_Ownerid;
		 

		protected bool gxTv_SdtWWPContext_Isaprover;
		 

		protected bool gxTv_SdtWWPContext_Iscliente;
		 

		protected short gxTv_SdtWWPContext_Secuserclienteid;
		 

		protected bool gxTv_SdtWWPContext_Secuseranalista;
		 

		protected short gxTv_SdtWWPContext_Aprovadorid;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WWPContext", Namespace="Factory21")]
	public class SdtWWPContext_RESTInterface : GxGenericCollectionItem<SdtWWPContext>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWWPContext_RESTInterface( ) : base()
		{	
		}

		public SdtWWPContext_RESTInterface( SdtWWPContext psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("UserId")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="UserId", Order=0)]
		public short gxTpr_Userid
		{
			get { 
				return sdt.gxTpr_Userid;

			}
			set { 
				sdt.gxTpr_Userid = value;
			}
		}

		[JsonPropertyName("UserName")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="UserName", Order=1)]
		public  string gxTpr_Username
		{
			get { 
				return sdt.gxTpr_Username;

			}
			set { 
				 sdt.gxTpr_Username = value;
			}
		}

		[JsonPropertyName("UserFullname")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="UserFullname", Order=2)]
		public  string gxTpr_Userfullname
		{
			get { 
				return sdt.gxTpr_Userfullname;

			}
			set { 
				 sdt.gxTpr_Userfullname = value;
			}
		}

		[JsonPropertyName("Expire")]
		[JsonPropertyOrder(3)]
		[DataMember(Name="Expire", Order=3)]
		public  string gxTpr_Expire
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Expire,context);

			}
			set { 
				sdt.gxTpr_Expire = DateTimeUtil.CToT2(value,context);
			}
		}

		[JsonPropertyName("OwnerId")]
		[JsonPropertyOrder(4)]
		[DataMember(Name="OwnerId", Order=4)]
		public short gxTpr_Ownerid
		{
			get { 
				return sdt.gxTpr_Ownerid;

			}
			set { 
				sdt.gxTpr_Ownerid = value;
			}
		}

		[JsonPropertyName("IsAprover")]
		[JsonPropertyOrder(5)]
		[JsonConverter(typeof(BoolStringJsonConverter))]
		[DataMember(Name="IsAprover", Order=5)]
		public bool gxTpr_Isaprover
		{
			get { 
				return sdt.gxTpr_Isaprover;

			}
			set { 
				sdt.gxTpr_Isaprover = value;
			}
		}

		[JsonPropertyName("IsCliente")]
		[JsonPropertyOrder(6)]
		[JsonConverter(typeof(BoolStringJsonConverter))]
		[DataMember(Name="IsCliente", Order=6)]
		public bool gxTpr_Iscliente
		{
			get { 
				return sdt.gxTpr_Iscliente;

			}
			set { 
				sdt.gxTpr_Iscliente = value;
			}
		}

		[JsonPropertyName("SecUserClienteId")]
		[JsonPropertyOrder(7)]
		[DataMember(Name="SecUserClienteId", Order=7)]
		public short gxTpr_Secuserclienteid
		{
			get { 
				return sdt.gxTpr_Secuserclienteid;

			}
			set { 
				sdt.gxTpr_Secuserclienteid = value;
			}
		}

		[JsonPropertyName("SecUserAnalista")]
		[JsonPropertyOrder(8)]
		[JsonConverter(typeof(BoolStringJsonConverter))]
		[DataMember(Name="SecUserAnalista", Order=8)]
		public bool gxTpr_Secuseranalista
		{
			get { 
				return sdt.gxTpr_Secuseranalista;

			}
			set { 
				sdt.gxTpr_Secuseranalista = value;
			}
		}

		[JsonPropertyName("AprovadorId")]
		[JsonPropertyOrder(9)]
		[DataMember(Name="AprovadorId", Order=9)]
		public short gxTpr_Aprovadorid
		{
			get { 
				return sdt.gxTpr_Aprovadorid;

			}
			set { 
				sdt.gxTpr_Aprovadorid = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtWWPContext sdt
		{
			get { 
				return (SdtWWPContext)Sdt;
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
				sdt = new SdtWWPContext() ;
			}
		}
	}
	#endregion
}