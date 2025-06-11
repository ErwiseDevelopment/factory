/*
				   File: type_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS
			Description: ICMS
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
	[XmlRoot(ElementName="SdNotaFiscal.NFe.infNFe.detItem.imposto.ICMS")]
	[XmlType(TypeName="SdNotaFiscal.NFe.infNFe.detItem.imposto.ICMS" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS : GxUserType
	{
		public SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS( )
		{
			/* Constructor for serialization */
		}

		public SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS(IGxContext context)
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
			if (gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_Icms00 != null)
			{
				AddObjectProperty("ICMS00", gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_Icms00, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ICMS00" )]
		[XmlElement(ElementName="ICMS00" )]
		public SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_ICMS00 gxTpr_Icms00
		{
			get {
				if ( gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_Icms00 == null )
				{
					gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_Icms00 = new SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_ICMS00(context);
				}
				gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_Icms00_N = false;
				SetDirty("Icms00");
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_Icms00;
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_Icms00_N = false;
				gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_Icms00 = value;
				SetDirty("Icms00");
			}

		}

		public void gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_Icms00_SetNull()
		{
			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_Icms00_N = true;
			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_Icms00 = null;
		}

		public bool gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_Icms00_IsNull()
		{
			return gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_Icms00 == null;
		}
		public bool ShouldSerializegxTpr_Icms00_Json()
		{
				return (gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_Icms00 != null && gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_Icms00.ShouldSerializeSdtJson());

		}


		public override bool ShouldSerializeSdtJson()
		{
			return (
				ShouldSerializegxTpr_Icms00_Json() || 
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
			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_Icms00_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_Icms00_N;
		protected SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_ICMS00 gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_Icms00 = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdNotaFiscal.NFe.infNFe.detItem.imposto.ICMS", Namespace="Factory21")]
	public class SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_RESTInterface : GxGenericCollectionItem<SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_RESTInterface( ) : base()
		{	
		}

		public SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_RESTInterface( SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("ICMS00")]
		[JsonPropertyOrder(0)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="ICMS00", Order=0, EmitDefaultValue=false)]
		public SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_ICMS00_RESTInterface gxTpr_Icms00
		{
			get {
				if (sdt.ShouldSerializegxTpr_Icms00_Json())
					return new SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_ICMS00_RESTInterface(sdt.gxTpr_Icms00);
				else
					return null;

			}

			set {
				sdt.gxTpr_Icms00 = value.sdt;
			}

		}


		#endregion
		[JsonIgnore]
		public SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS sdt
		{
			get { 
				return (SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS)Sdt;
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
				sdt = new SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS() ;
			}
		}
	}
	#endregion
}