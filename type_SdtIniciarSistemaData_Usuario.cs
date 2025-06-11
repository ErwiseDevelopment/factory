/*
				   File: type_SdtIniciarSistemaData_Usuario
			Description: Usuario
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
	[XmlRoot(ElementName="IniciarSistemaData.Usuario")]
	[XmlType(TypeName="IniciarSistemaData.Usuario" , Namespace="Factory21" )]
	[Serializable]
	public class SdtIniciarSistemaData_Usuario : GxUserType
	{
		public SdtIniciarSistemaData_Usuario( )
		{
			/* Constructor for serialization */
			gxTv_SdtIniciarSistemaData_Usuario_Secusername = "";

			gxTv_SdtIniciarSistemaData_Usuario_Secuserfullname = "";

			gxTv_SdtIniciarSistemaData_Usuario_Secuseremail = "";

			gxTv_SdtIniciarSistemaData_Usuario_Secuserpassword = "";

		}

		public SdtIniciarSistemaData_Usuario(IGxContext context)
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
			AddObjectProperty("SecUserName", gxTpr_Secusername, false);


			AddObjectProperty("SecUserFullName", gxTpr_Secuserfullname, false);


			AddObjectProperty("SecUserEmail", gxTpr_Secuseremail, false);


			AddObjectProperty("SecUserPassword", gxTpr_Secuserpassword, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="SecUserName")]
		[XmlElement(ElementName="SecUserName")]
		public string gxTpr_Secusername
		{
			get {
				return gxTv_SdtIniciarSistemaData_Usuario_Secusername; 
			}
			set {
				gxTv_SdtIniciarSistemaData_Usuario_Secusername = value;
				SetDirty("Secusername");
			}
		}




		[SoapElement(ElementName="SecUserFullName")]
		[XmlElement(ElementName="SecUserFullName")]
		public string gxTpr_Secuserfullname
		{
			get {
				return gxTv_SdtIniciarSistemaData_Usuario_Secuserfullname; 
			}
			set {
				gxTv_SdtIniciarSistemaData_Usuario_Secuserfullname = value;
				SetDirty("Secuserfullname");
			}
		}




		[SoapElement(ElementName="SecUserEmail")]
		[XmlElement(ElementName="SecUserEmail")]
		public string gxTpr_Secuseremail
		{
			get {
				return gxTv_SdtIniciarSistemaData_Usuario_Secuseremail; 
			}
			set {
				gxTv_SdtIniciarSistemaData_Usuario_Secuseremail = value;
				SetDirty("Secuseremail");
			}
		}




		[SoapElement(ElementName="SecUserPassword")]
		[XmlElement(ElementName="SecUserPassword")]
		public string gxTpr_Secuserpassword
		{
			get {
				return gxTv_SdtIniciarSistemaData_Usuario_Secuserpassword; 
			}
			set {
				gxTv_SdtIniciarSistemaData_Usuario_Secuserpassword = value;
				SetDirty("Secuserpassword");
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
			gxTv_SdtIniciarSistemaData_Usuario_Secusername = "";
			gxTv_SdtIniciarSistemaData_Usuario_Secuserfullname = "";
			gxTv_SdtIniciarSistemaData_Usuario_Secuseremail = "";
			gxTv_SdtIniciarSistemaData_Usuario_Secuserpassword = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtIniciarSistemaData_Usuario_Secusername;
		 

		protected string gxTv_SdtIniciarSistemaData_Usuario_Secuserfullname;
		 

		protected string gxTv_SdtIniciarSistemaData_Usuario_Secuseremail;
		 

		protected string gxTv_SdtIniciarSistemaData_Usuario_Secuserpassword;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"IniciarSistemaData.Usuario", Namespace="Factory21")]
	public class SdtIniciarSistemaData_Usuario_RESTInterface : GxGenericCollectionItem<SdtIniciarSistemaData_Usuario>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtIniciarSistemaData_Usuario_RESTInterface( ) : base()
		{	
		}

		public SdtIniciarSistemaData_Usuario_RESTInterface( SdtIniciarSistemaData_Usuario psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("SecUserName")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="SecUserName", Order=0)]
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
		[JsonPropertyOrder(1)]
		[DataMember(Name="SecUserFullName", Order=1)]
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
		[JsonPropertyOrder(2)]
		[DataMember(Name="SecUserEmail", Order=2)]
		public  string gxTpr_Secuseremail
		{
			get { 
				return sdt.gxTpr_Secuseremail;

			}
			set { 
				 sdt.gxTpr_Secuseremail = value;
			}
		}

		[JsonPropertyName("SecUserPassword")]
		[JsonPropertyOrder(3)]
		[DataMember(Name="SecUserPassword", Order=3)]
		public  string gxTpr_Secuserpassword
		{
			get { 
				return sdt.gxTpr_Secuserpassword;

			}
			set { 
				 sdt.gxTpr_Secuserpassword = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtIniciarSistemaData_Usuario sdt
		{
			get { 
				return (SdtIniciarSistemaData_Usuario)Sdt;
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
				sdt = new SdtIniciarSistemaData_Usuario() ;
			}
		}
	}
	#endregion
}