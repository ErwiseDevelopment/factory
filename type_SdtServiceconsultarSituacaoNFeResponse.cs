/*
				   File: type_SdtServiceconsultarSituacaoNFeResponse
			Description: ServiceconsultarSituacaoNFeResponse
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
	[XmlRoot(ElementName="consultarSituacaoNFeResponse")]
	[XmlType(TypeName="consultarSituacaoNFeResponse" , Namespace="http://tempuri.org/" )]
	[Serializable]
	public class SdtServiceconsultarSituacaoNFeResponse : GxUserType
	{
		public SdtServiceconsultarSituacaoNFeResponse( )
		{
			/* Constructor for serialization */
			gxTv_SdtServiceconsultarSituacaoNFeResponse_Consultarsituacaonferesult = "";

		}

		public SdtServiceconsultarSituacaoNFeResponse(IGxContext context)
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
			AddObjectProperty("consultarSituacaoNFeResult", gxTpr_Consultarsituacaonferesult, false);

			return;
		}
		#endregion

		#region Properties

		[XmlAnyElement]
		public System.Xml.XmlElement[] gxTpr_Consultarsituacaonferesult_UnknownContent
		{
			get {
				return XmlToElements( gxTv_SdtServiceconsultarSituacaoNFeResponse_Consultarsituacaonferesult);
			}
			set {
				gxTv_SdtServiceconsultarSituacaoNFeResponse_Consultarsituacaonferesult = "";
				if (value != null)
				{
					foreach (System.Xml.XmlElement unknownItem in value)
						gxTv_SdtServiceconsultarSituacaoNFeResponse_Consultarsituacaonferesult += unknownItem.OuterXml;
				}
			}
		}[XmlIgnore]
		public string gxTpr_Consultarsituacaonferesult
		{
			get {
				return gxTv_SdtServiceconsultarSituacaoNFeResponse_Consultarsituacaonferesult; 
			}
			set {
				gxTv_SdtServiceconsultarSituacaoNFeResponse_Consultarsituacaonferesult = value;
				SetDirty("Consultarsituacaonferesult");
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
			gxTv_SdtServiceconsultarSituacaoNFeResponse_Consultarsituacaonferesult = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtServiceconsultarSituacaoNFeResponse_Consultarsituacaonferesult;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"consultarSituacaoNFeResponse", Namespace="http://tempuri.org/")]
	public class SdtServiceconsultarSituacaoNFeResponse_RESTInterface : GxGenericCollectionItem<SdtServiceconsultarSituacaoNFeResponse>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtServiceconsultarSituacaoNFeResponse_RESTInterface( ) : base()
		{	
		}

		public SdtServiceconsultarSituacaoNFeResponse_RESTInterface( SdtServiceconsultarSituacaoNFeResponse psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("consultarSituacaoNFeResult")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="consultarSituacaoNFeResult", Order=0)]
		public  string gxTpr_Consultarsituacaonferesult
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Consultarsituacaonferesult);

			}
			set { 
				 sdt.gxTpr_Consultarsituacaonferesult = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtServiceconsultarSituacaoNFeResponse sdt
		{
			get { 
				return (SdtServiceconsultarSituacaoNFeResponse)Sdt;
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
				sdt = new SdtServiceconsultarSituacaoNFeResponse() ;
			}
		}
	}
	#endregion
}