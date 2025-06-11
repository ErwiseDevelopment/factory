/*
				   File: type_SdtSdSecUser
			Description: SdSecUser
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
	[XmlRoot(ElementName="SdSecUser")]
	[XmlType(TypeName="SdSecUser" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdSecUser : GxUserType
	{
		public SdtSdSecUser( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdSecUser_Secusername = "";

			gxTv_SdtSdSecUser_Secuserfullname = "";

			gxTv_SdtSdSecUser_Secuseremail = "";

			gxTv_SdtSdSecUser_Secuserpassword = "";

			gxTv_SdtSdSecUser_Secusercreatedat = (DateTime)(DateTime.MinValue);

			gxTv_SdtSdSecUser_Secuserupdateat = (DateTime)(DateTime.MinValue);

			gxTv_SdtSdSecUser_Secuserteste = "";


		}

		public SdtSdSecUser(IGxContext context)
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
			AddObjectProperty("SecUserId", gxTpr_Secuserid, false);


			AddObjectProperty("SecUserName", gxTpr_Secusername, false);


			AddObjectProperty("SecUserFullName", gxTpr_Secuserfullname, false);


			AddObjectProperty("SecUserEmail", gxTpr_Secuseremail, false);


			AddObjectProperty("SecUserStatus", gxTpr_Secuserstatus, false);


			AddObjectProperty("SecUserPassword", gxTpr_Secuserpassword, false);


			AddObjectProperty("SecUserAnalista", gxTpr_Secuseranalista, false);


			datetime_STZ = gxTpr_Secusercreatedat;
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
			AddObjectProperty("SecUserCreatedAt", sDateCnv, false);



			datetime_STZ = gxTpr_Secuserupdateat;
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
			AddObjectProperty("SecUserUpdateAt", sDateCnv, false);



			AddObjectProperty("SecUserUserMan", gxTpr_Secuseruserman, false);


			AddObjectProperty("SecUserTemp", gxTpr_Secusertemp, false);


			AddObjectProperty("SecUserClienteAcesso", gxTpr_Secuserclienteacesso, false);


			AddObjectProperty("SecUserTeste", gxTpr_Secuserteste, false);


			AddObjectProperty("SecUserClienteId", gxTpr_Secuserclienteid, false);


			AddObjectProperty("SecUserOwnerId", gxTpr_Secuserownerid, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="SecUserId")]
		[XmlElement(ElementName="SecUserId")]
		public short gxTpr_Secuserid
		{
			get {
				return gxTv_SdtSdSecUser_Secuserid; 
			}
			set {
				gxTv_SdtSdSecUser_Secuserid = value;
				SetDirty("Secuserid");
			}
		}




		[SoapElement(ElementName="SecUserName")]
		[XmlElement(ElementName="SecUserName")]
		public string gxTpr_Secusername
		{
			get {
				return gxTv_SdtSdSecUser_Secusername; 
			}
			set {
				gxTv_SdtSdSecUser_Secusername = value;
				SetDirty("Secusername");
			}
		}




		[SoapElement(ElementName="SecUserFullName")]
		[XmlElement(ElementName="SecUserFullName")]
		public string gxTpr_Secuserfullname
		{
			get {
				return gxTv_SdtSdSecUser_Secuserfullname; 
			}
			set {
				gxTv_SdtSdSecUser_Secuserfullname = value;
				SetDirty("Secuserfullname");
			}
		}




		[SoapElement(ElementName="SecUserEmail")]
		[XmlElement(ElementName="SecUserEmail")]
		public string gxTpr_Secuseremail
		{
			get {
				return gxTv_SdtSdSecUser_Secuseremail; 
			}
			set {
				gxTv_SdtSdSecUser_Secuseremail = value;
				SetDirty("Secuseremail");
			}
		}




		[SoapElement(ElementName="SecUserStatus")]
		[XmlElement(ElementName="SecUserStatus")]
		public bool gxTpr_Secuserstatus
		{
			get {
				return gxTv_SdtSdSecUser_Secuserstatus; 
			}
			set {
				gxTv_SdtSdSecUser_Secuserstatus = value;
				SetDirty("Secuserstatus");
			}
		}




		[SoapElement(ElementName="SecUserPassword")]
		[XmlElement(ElementName="SecUserPassword")]
		public string gxTpr_Secuserpassword
		{
			get {
				return gxTv_SdtSdSecUser_Secuserpassword; 
			}
			set {
				gxTv_SdtSdSecUser_Secuserpassword = value;
				SetDirty("Secuserpassword");
			}
		}




		[SoapElement(ElementName="SecUserAnalista")]
		[XmlElement(ElementName="SecUserAnalista")]
		public bool gxTpr_Secuseranalista
		{
			get {
				return gxTv_SdtSdSecUser_Secuseranalista; 
			}
			set {
				gxTv_SdtSdSecUser_Secuseranalista = value;
				SetDirty("Secuseranalista");
			}
		}



		[SoapElement(ElementName="SecUserCreatedAt")]
		[XmlElement(ElementName="SecUserCreatedAt" , IsNullable=true)]
		public string gxTpr_Secusercreatedat_Nullable
		{
			get {
				if ( gxTv_SdtSdSecUser_Secusercreatedat == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSdSecUser_Secusercreatedat).value ;
			}
			set {
				gxTv_SdtSdSecUser_Secusercreatedat = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Secusercreatedat
		{
			get {
				return gxTv_SdtSdSecUser_Secusercreatedat; 
			}
			set {
				gxTv_SdtSdSecUser_Secusercreatedat = value;
				SetDirty("Secusercreatedat");
			}
		}


		[SoapElement(ElementName="SecUserUpdateAt")]
		[XmlElement(ElementName="SecUserUpdateAt" , IsNullable=true)]
		public string gxTpr_Secuserupdateat_Nullable
		{
			get {
				if ( gxTv_SdtSdSecUser_Secuserupdateat == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSdSecUser_Secuserupdateat).value ;
			}
			set {
				gxTv_SdtSdSecUser_Secuserupdateat = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Secuserupdateat
		{
			get {
				return gxTv_SdtSdSecUser_Secuserupdateat; 
			}
			set {
				gxTv_SdtSdSecUser_Secuserupdateat = value;
				SetDirty("Secuserupdateat");
			}
		}



		[SoapElement(ElementName="SecUserUserMan")]
		[XmlElement(ElementName="SecUserUserMan")]
		public short gxTpr_Secuseruserman
		{
			get {
				return gxTv_SdtSdSecUser_Secuseruserman; 
			}
			set {
				gxTv_SdtSdSecUser_Secuseruserman = value;
				SetDirty("Secuseruserman");
			}
		}




		[SoapElement(ElementName="SecUserTemp")]
		[XmlElement(ElementName="SecUserTemp")]
		public bool gxTpr_Secusertemp
		{
			get {
				return gxTv_SdtSdSecUser_Secusertemp; 
			}
			set {
				gxTv_SdtSdSecUser_Secusertemp = value;
				SetDirty("Secusertemp");
			}
		}




		[SoapElement(ElementName="SecUserClienteAcesso")]
		[XmlElement(ElementName="SecUserClienteAcesso")]
		public bool gxTpr_Secuserclienteacesso
		{
			get {
				return gxTv_SdtSdSecUser_Secuserclienteacesso; 
			}
			set {
				gxTv_SdtSdSecUser_Secuserclienteacesso = value;
				SetDirty("Secuserclienteacesso");
			}
		}




		[SoapElement(ElementName="SecUserTeste")]
		[XmlElement(ElementName="SecUserTeste")]
		public string gxTpr_Secuserteste
		{
			get {
				return gxTv_SdtSdSecUser_Secuserteste; 
			}
			set {
				gxTv_SdtSdSecUser_Secuserteste = value;
				SetDirty("Secuserteste");
			}
		}




		[SoapElement(ElementName="SecUserClienteId")]
		[XmlElement(ElementName="SecUserClienteId")]
		public short gxTpr_Secuserclienteid
		{
			get {
				return gxTv_SdtSdSecUser_Secuserclienteid; 
			}
			set {
				gxTv_SdtSdSecUser_Secuserclienteid = value;
				SetDirty("Secuserclienteid");
			}
		}




		[SoapElement(ElementName="SecUserOwnerId")]
		[XmlElement(ElementName="SecUserOwnerId")]
		public int gxTpr_Secuserownerid
		{
			get {
				return gxTv_SdtSdSecUser_Secuserownerid; 
			}
			set {
				gxTv_SdtSdSecUser_Secuserownerid = value;
				SetDirty("Secuserownerid");
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
			gxTv_SdtSdSecUser_Secusername = "";
			gxTv_SdtSdSecUser_Secuserfullname = "";
			gxTv_SdtSdSecUser_Secuseremail = "";

			gxTv_SdtSdSecUser_Secuserpassword = "";

			gxTv_SdtSdSecUser_Secusercreatedat = (DateTime)(DateTime.MinValue);
			gxTv_SdtSdSecUser_Secuserupdateat = (DateTime)(DateTime.MinValue);



			gxTv_SdtSdSecUser_Secuserteste = "";


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

		protected short gxTv_SdtSdSecUser_Secuserid;
		 

		protected string gxTv_SdtSdSecUser_Secusername;
		 

		protected string gxTv_SdtSdSecUser_Secuserfullname;
		 

		protected string gxTv_SdtSdSecUser_Secuseremail;
		 

		protected bool gxTv_SdtSdSecUser_Secuserstatus;
		 

		protected string gxTv_SdtSdSecUser_Secuserpassword;
		 

		protected bool gxTv_SdtSdSecUser_Secuseranalista;
		 

		protected DateTime gxTv_SdtSdSecUser_Secusercreatedat;
		 

		protected DateTime gxTv_SdtSdSecUser_Secuserupdateat;
		 

		protected short gxTv_SdtSdSecUser_Secuseruserman;
		 

		protected bool gxTv_SdtSdSecUser_Secusertemp;
		 

		protected bool gxTv_SdtSdSecUser_Secuserclienteacesso;
		 

		protected string gxTv_SdtSdSecUser_Secuserteste;
		 

		protected short gxTv_SdtSdSecUser_Secuserclienteid;
		 

		protected int gxTv_SdtSdSecUser_Secuserownerid;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdSecUser", Namespace="Factory21")]
	public class SdtSdSecUser_RESTInterface : GxGenericCollectionItem<SdtSdSecUser>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdSecUser_RESTInterface( ) : base()
		{	
		}

		public SdtSdSecUser_RESTInterface( SdtSdSecUser psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("SecUserId")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="SecUserId", Order=0)]
		public short gxTpr_Secuserid
		{
			get { 
				return sdt.gxTpr_Secuserid;

			}
			set { 
				sdt.gxTpr_Secuserid = value;
			}
		}

		[JsonPropertyName("SecUserName")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="SecUserName", Order=1)]
		public  string gxTpr_Secusername
		{
			get { 
				return sdt.gxTpr_Secusername;

			}
			set { 
				 sdt.gxTpr_Secusername = value;
			}
		}

		[JsonPropertyName("SecUserFullName")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="SecUserFullName", Order=2)]
		public  string gxTpr_Secuserfullname
		{
			get { 
				return sdt.gxTpr_Secuserfullname;

			}
			set { 
				 sdt.gxTpr_Secuserfullname = value;
			}
		}

		[JsonPropertyName("SecUserEmail")]
		[JsonPropertyOrder(3)]
		[DataMember(Name="SecUserEmail", Order=3)]
		public  string gxTpr_Secuseremail
		{
			get { 
				return sdt.gxTpr_Secuseremail;

			}
			set { 
				 sdt.gxTpr_Secuseremail = value;
			}
		}

		[JsonPropertyName("SecUserStatus")]
		[JsonPropertyOrder(4)]
		[JsonConverter(typeof(BoolStringJsonConverter))]
		[DataMember(Name="SecUserStatus", Order=4)]
		public bool gxTpr_Secuserstatus
		{
			get { 
				return sdt.gxTpr_Secuserstatus;

			}
			set { 
				sdt.gxTpr_Secuserstatus = value;
			}
		}

		[JsonPropertyName("SecUserPassword")]
		[JsonPropertyOrder(5)]
		[DataMember(Name="SecUserPassword", Order=5)]
		public  string gxTpr_Secuserpassword
		{
			get { 
				return sdt.gxTpr_Secuserpassword;

			}
			set { 
				 sdt.gxTpr_Secuserpassword = value;
			}
		}

		[JsonPropertyName("SecUserAnalista")]
		[JsonPropertyOrder(6)]
		[JsonConverter(typeof(BoolStringJsonConverter))]
		[DataMember(Name="SecUserAnalista", Order=6)]
		public bool gxTpr_Secuseranalista
		{
			get { 
				return sdt.gxTpr_Secuseranalista;

			}
			set { 
				sdt.gxTpr_Secuseranalista = value;
			}
		}

		[JsonPropertyName("SecUserCreatedAt")]
		[JsonPropertyOrder(7)]
		[DataMember(Name="SecUserCreatedAt", Order=7)]
		public  string gxTpr_Secusercreatedat
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Secusercreatedat,context);

			}
			set { 
				sdt.gxTpr_Secusercreatedat = DateTimeUtil.CToT2(value,context);
			}
		}

		[JsonPropertyName("SecUserUpdateAt")]
		[JsonPropertyOrder(8)]
		[DataMember(Name="SecUserUpdateAt", Order=8)]
		public  string gxTpr_Secuserupdateat
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Secuserupdateat,context);

			}
			set { 
				sdt.gxTpr_Secuserupdateat = DateTimeUtil.CToT2(value,context);
			}
		}

		[JsonPropertyName("SecUserUserMan")]
		[JsonPropertyOrder(9)]
		[DataMember(Name="SecUserUserMan", Order=9)]
		public short gxTpr_Secuseruserman
		{
			get { 
				return sdt.gxTpr_Secuseruserman;

			}
			set { 
				sdt.gxTpr_Secuseruserman = value;
			}
		}

		[JsonPropertyName("SecUserTemp")]
		[JsonPropertyOrder(10)]
		[JsonConverter(typeof(BoolStringJsonConverter))]
		[DataMember(Name="SecUserTemp", Order=10)]
		public bool gxTpr_Secusertemp
		{
			get { 
				return sdt.gxTpr_Secusertemp;

			}
			set { 
				sdt.gxTpr_Secusertemp = value;
			}
		}

		[JsonPropertyName("SecUserClienteAcesso")]
		[JsonPropertyOrder(11)]
		[JsonConverter(typeof(BoolStringJsonConverter))]
		[DataMember(Name="SecUserClienteAcesso", Order=11)]
		public bool gxTpr_Secuserclienteacesso
		{
			get { 
				return sdt.gxTpr_Secuserclienteacesso;

			}
			set { 
				sdt.gxTpr_Secuserclienteacesso = value;
			}
		}

		[JsonPropertyName("SecUserTeste")]
		[JsonPropertyOrder(12)]
		[DataMember(Name="SecUserTeste", Order=12)]
		public  string gxTpr_Secuserteste
		{
			get { 
				return sdt.gxTpr_Secuserteste;

			}
			set { 
				 sdt.gxTpr_Secuserteste = value;
			}
		}

		[JsonPropertyName("SecUserClienteId")]
		[JsonPropertyOrder(13)]
		[DataMember(Name="SecUserClienteId", Order=13)]
		public short gxTpr_Secuserclienteid
		{
			get { 
				return sdt.gxTpr_Secuserclienteid;

			}
			set { 
				sdt.gxTpr_Secuserclienteid = value;
			}
		}

		[JsonPropertyName("SecUserOwnerId")]
		[JsonPropertyOrder(14)]
		[DataMember(Name="SecUserOwnerId", Order=14)]
		public  string gxTpr_Secuserownerid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Secuserownerid, 9, 0));

			}
			set { 
				sdt.gxTpr_Secuserownerid = (int) NumberUtil.Val( value, ".");
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdSecUser sdt
		{
			get { 
				return (SdtSdSecUser)Sdt;
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
				sdt = new SdtSdSecUser() ;
			}
		}
	}
	#endregion
}