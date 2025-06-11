/*
				   File: type_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS
			Description: COFINS
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
	[XmlRoot(ElementName="SdNotaFiscal.NFe.infNFe.detItem.imposto.COFINS")]
	[XmlType(TypeName="SdNotaFiscal.NFe.infNFe.detItem.imposto.COFINS" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS : GxUserType
	{
		public SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS( )
		{
			/* Constructor for serialization */
		}

		public SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS(IGxContext context)
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
			if (gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_Cofinsaliq != null)
			{
				AddObjectProperty("COFINSAliq", gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_Cofinsaliq, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="COFINSAliq" )]
		[XmlElement(ElementName="COFINSAliq" )]
		public SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_COFINSAliq gxTpr_Cofinsaliq
		{
			get {
				if ( gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_Cofinsaliq == null )
				{
					gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_Cofinsaliq = new SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_COFINSAliq(context);
				}
				gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_Cofinsaliq_N = false;
				SetDirty("Cofinsaliq");
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_Cofinsaliq;
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_Cofinsaliq_N = false;
				gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_Cofinsaliq = value;
				SetDirty("Cofinsaliq");
			}

		}

		public void gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_Cofinsaliq_SetNull()
		{
			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_Cofinsaliq_N = true;
			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_Cofinsaliq = null;
		}

		public bool gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_Cofinsaliq_IsNull()
		{
			return gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_Cofinsaliq == null;
		}
		public bool ShouldSerializegxTpr_Cofinsaliq_Json()
		{
				return (gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_Cofinsaliq != null && gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_Cofinsaliq.ShouldSerializeSdtJson());

		}


		public override bool ShouldSerializeSdtJson()
		{
			return (
				ShouldSerializegxTpr_Cofinsaliq_Json() || 
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
			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_Cofinsaliq_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_Cofinsaliq_N;
		protected SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_COFINSAliq gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_Cofinsaliq = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdNotaFiscal.NFe.infNFe.detItem.imposto.COFINS", Namespace="Factory21")]
	public class SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_RESTInterface : GxGenericCollectionItem<SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_RESTInterface( ) : base()
		{	
		}

		public SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_RESTInterface( SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("COFINSAliq")]
		[JsonPropertyOrder(0)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="COFINSAliq", Order=0, EmitDefaultValue=false)]
		public SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_COFINSAliq_RESTInterface gxTpr_Cofinsaliq
		{
			get {
				if (sdt.ShouldSerializegxTpr_Cofinsaliq_Json())
					return new SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_COFINSAliq_RESTInterface(sdt.gxTpr_Cofinsaliq);
				else
					return null;

			}

			set {
				sdt.gxTpr_Cofinsaliq = value.sdt;
			}

		}


		#endregion
		[JsonIgnore]
		public SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS sdt
		{
			get { 
				return (SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS)Sdt;
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
				sdt = new SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS() ;
			}
		}
	}
	#endregion
}