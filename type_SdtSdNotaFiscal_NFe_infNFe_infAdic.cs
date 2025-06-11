/*
				   File: type_SdtSdNotaFiscal_NFe_infNFe_infAdic
			Description: infAdic
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
	[XmlRoot(ElementName="SdNotaFiscal.NFe.infNFe.infAdic")]
	[XmlType(TypeName="SdNotaFiscal.NFe.infNFe.infAdic" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdNotaFiscal_NFe_infNFe_infAdic : GxUserType
	{
		public SdtSdNotaFiscal_NFe_infNFe_infAdic( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdNotaFiscal_NFe_infNFe_infAdic_Infadfisco = "";

		}

		public SdtSdNotaFiscal_NFe_infNFe_infAdic(IGxContext context)
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
			AddObjectProperty("infAdFisco", gxTpr_Infadfisco, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="infAdFisco")]
		[XmlElement(ElementName="infAdFisco")]
		public string gxTpr_Infadfisco
		{
			get {
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_infAdic_Infadfisco; 
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_infAdic_Infadfisco = value;
				SetDirty("Infadfisco");
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
			gxTv_SdtSdNotaFiscal_NFe_infNFe_infAdic_Infadfisco = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSdNotaFiscal_NFe_infNFe_infAdic_Infadfisco;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdNotaFiscal.NFe.infNFe.infAdic", Namespace="Factory21")]
	public class SdtSdNotaFiscal_NFe_infNFe_infAdic_RESTInterface : GxGenericCollectionItem<SdtSdNotaFiscal_NFe_infNFe_infAdic>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdNotaFiscal_NFe_infNFe_infAdic_RESTInterface( ) : base()
		{	
		}

		public SdtSdNotaFiscal_NFe_infNFe_infAdic_RESTInterface( SdtSdNotaFiscal_NFe_infNFe_infAdic psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("infAdFisco")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="infAdFisco", Order=0)]
		public  string gxTpr_Infadfisco
		{
			get { 
				return sdt.gxTpr_Infadfisco;

			}
			set { 
				 sdt.gxTpr_Infadfisco = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdNotaFiscal_NFe_infNFe_infAdic sdt
		{
			get { 
				return (SdtSdNotaFiscal_NFe_infNFe_infAdic)Sdt;
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
				sdt = new SdtSdNotaFiscal_NFe_infNFe_infAdic() ;
			}
		}
	}
	#endregion
}