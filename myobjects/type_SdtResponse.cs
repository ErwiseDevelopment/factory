/*
				   File: type_SdtResponse
			Description: Response
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
namespace GeneXus.Programs.myobjects
{
	[XmlRoot(ElementName="Response")]
	[XmlType(TypeName="Response" , Namespace="Factory21" )]
	[Serializable]
	public class SdtResponse : GxUserType
	{
		public SdtResponse( )
		{
			/* Constructor for serialization */
		}

		public SdtResponse(IGxContext context)
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
			AddObjectProperty("erro", gxTpr_Erro, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="erro")]
		[XmlElement(ElementName="erro")]
		public bool gxTpr_Erro
		{
			get {
				return gxTv_SdtResponse_Erro; 
			}
			set {
				gxTv_SdtResponse_Erro = value;
				SetDirty("Erro");
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
			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtResponse_Erro;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"Response", Namespace="Factory21")]
	public class SdtResponse_RESTInterface : GxGenericCollectionItem<SdtResponse>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtResponse_RESTInterface( ) : base()
		{	
		}

		public SdtResponse_RESTInterface( SdtResponse psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("erro")]
		[JsonPropertyOrder(0)]
		[JsonConverter(typeof(BoolStringJsonConverter))]
		[DataMember(Name="erro", Order=0)]
		public bool gxTpr_Erro
		{
			get { 
				return sdt.gxTpr_Erro;

			}
			set { 
				sdt.gxTpr_Erro = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtResponse sdt
		{
			get { 
				return (SdtResponse)Sdt;
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
				sdt = new SdtResponse() ;
			}
		}
	}
	#endregion
}