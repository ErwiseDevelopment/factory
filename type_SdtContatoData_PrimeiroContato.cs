/*
				   File: type_SdtContatoData_PrimeiroContato
			Description: PrimeiroContato
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
	[XmlRoot(ElementName="ContatoData.PrimeiroContato")]
	[XmlType(TypeName="ContatoData.PrimeiroContato" , Namespace="Factory21" )]
	[Serializable]
	public class SdtContatoData_PrimeiroContato : GxUserType
	{
		public SdtContatoData_PrimeiroContato( )
		{
			/* Constructor for serialization */
		}

		public SdtContatoData_PrimeiroContato(IGxContext context)
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
			AddObjectProperty("ClienteTipo", gxTpr_Clientetipo, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ClienteTipo")]
		[XmlElement(ElementName="ClienteTipo")]
		public bool gxTpr_Clientetipo
		{
			get {
				return gxTv_SdtContatoData_PrimeiroContato_Clientetipo; 
			}
			set {
				gxTv_SdtContatoData_PrimeiroContato_Clientetipo = value;
				SetDirty("Clientetipo");
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

		protected bool gxTv_SdtContatoData_PrimeiroContato_Clientetipo;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"ContatoData.PrimeiroContato", Namespace="Factory21")]
	public class SdtContatoData_PrimeiroContato_RESTInterface : GxGenericCollectionItem<SdtContatoData_PrimeiroContato>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtContatoData_PrimeiroContato_RESTInterface( ) : base()
		{	
		}

		public SdtContatoData_PrimeiroContato_RESTInterface( SdtContatoData_PrimeiroContato psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("ClienteTipo")]
		[JsonPropertyOrder(0)]
		[JsonConverter(typeof(BoolStringJsonConverter))]
		[DataMember(Name="ClienteTipo", Order=0)]
		public bool gxTpr_Clientetipo
		{
			get { 
				return sdt.gxTpr_Clientetipo;

			}
			set { 
				sdt.gxTpr_Clientetipo = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtContatoData_PrimeiroContato sdt
		{
			get { 
				return (SdtContatoData_PrimeiroContato)Sdt;
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
				sdt = new SdtContatoData_PrimeiroContato() ;
			}
		}
	}
	#endregion
}