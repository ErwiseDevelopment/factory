/*
				   File: type_SdtSdNotaFiscal_NFe
			Description: NFe
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
	[XmlRoot(ElementName="SdNotaFiscal.NFe")]
	[XmlType(TypeName="SdNotaFiscal.NFe" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdNotaFiscal_NFe : GxUserType
	{
		public SdtSdNotaFiscal_NFe( )
		{
			/* Constructor for serialization */
		}

		public SdtSdNotaFiscal_NFe(IGxContext context)
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
			if (gxTv_SdtSdNotaFiscal_NFe_Infnfe != null)
			{
				AddObjectProperty("infNFe", gxTv_SdtSdNotaFiscal_NFe_Infnfe, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="infNFe" )]
		[XmlElement(ElementName="infNFe" )]
		public SdtSdNotaFiscal_NFe_infNFe gxTpr_Infnfe
		{
			get {
				if ( gxTv_SdtSdNotaFiscal_NFe_Infnfe == null )
				{
					gxTv_SdtSdNotaFiscal_NFe_Infnfe = new SdtSdNotaFiscal_NFe_infNFe(context);
				}
				gxTv_SdtSdNotaFiscal_NFe_Infnfe_N = false;
				SetDirty("Infnfe");
				return gxTv_SdtSdNotaFiscal_NFe_Infnfe;
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_Infnfe_N = false;
				gxTv_SdtSdNotaFiscal_NFe_Infnfe = value;
				SetDirty("Infnfe");
			}

		}

		public void gxTv_SdtSdNotaFiscal_NFe_Infnfe_SetNull()
		{
			gxTv_SdtSdNotaFiscal_NFe_Infnfe_N = true;
			gxTv_SdtSdNotaFiscal_NFe_Infnfe = null;
		}

		public bool gxTv_SdtSdNotaFiscal_NFe_Infnfe_IsNull()
		{
			return gxTv_SdtSdNotaFiscal_NFe_Infnfe == null;
		}
		public bool ShouldSerializegxTpr_Infnfe_Json()
		{
				return (gxTv_SdtSdNotaFiscal_NFe_Infnfe != null && gxTv_SdtSdNotaFiscal_NFe_Infnfe.ShouldSerializeSdtJson());

		}


		public override bool ShouldSerializeSdtJson()
		{
			return (
				ShouldSerializegxTpr_Infnfe_Json() || 
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
			gxTv_SdtSdNotaFiscal_NFe_Infnfe_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtSdNotaFiscal_NFe_Infnfe_N;
		protected SdtSdNotaFiscal_NFe_infNFe gxTv_SdtSdNotaFiscal_NFe_Infnfe = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdNotaFiscal.NFe", Namespace="Factory21")]
	public class SdtSdNotaFiscal_NFe_RESTInterface : GxGenericCollectionItem<SdtSdNotaFiscal_NFe>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdNotaFiscal_NFe_RESTInterface( ) : base()
		{	
		}

		public SdtSdNotaFiscal_NFe_RESTInterface( SdtSdNotaFiscal_NFe psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("infNFe")]
		[JsonPropertyOrder(0)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="infNFe", Order=0, EmitDefaultValue=false)]
		public SdtSdNotaFiscal_NFe_infNFe_RESTInterface gxTpr_Infnfe
		{
			get {
				if (sdt.ShouldSerializegxTpr_Infnfe_Json())
					return new SdtSdNotaFiscal_NFe_infNFe_RESTInterface(sdt.gxTpr_Infnfe);
				else
					return null;

			}

			set {
				sdt.gxTpr_Infnfe = value.sdt;
			}

		}


		#endregion
		[JsonIgnore]
		public SdtSdNotaFiscal_NFe sdt
		{
			get { 
				return (SdtSdNotaFiscal_NFe)Sdt;
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
				sdt = new SdtSdNotaFiscal_NFe() ;
			}
		}
	}
	#endregion
}