/*
				   File: type_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS
			Description: PIS
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
	[XmlRoot(ElementName="SdNotaFiscal.NFe.infNFe.detItem.imposto.PIS")]
	[XmlType(TypeName="SdNotaFiscal.NFe.infNFe.detItem.imposto.PIS" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS : GxUserType
	{
		public SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS( )
		{
			/* Constructor for serialization */
		}

		public SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS(IGxContext context)
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
			if (gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_Pisaliq != null)
			{
				AddObjectProperty("PISAliq", gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_Pisaliq, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="PISAliq" )]
		[XmlElement(ElementName="PISAliq" )]
		public SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_PISAliq gxTpr_Pisaliq
		{
			get {
				if ( gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_Pisaliq == null )
				{
					gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_Pisaliq = new SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_PISAliq(context);
				}
				gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_Pisaliq_N = false;
				SetDirty("Pisaliq");
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_Pisaliq;
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_Pisaliq_N = false;
				gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_Pisaliq = value;
				SetDirty("Pisaliq");
			}

		}

		public void gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_Pisaliq_SetNull()
		{
			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_Pisaliq_N = true;
			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_Pisaliq = null;
		}

		public bool gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_Pisaliq_IsNull()
		{
			return gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_Pisaliq == null;
		}
		public bool ShouldSerializegxTpr_Pisaliq_Json()
		{
				return (gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_Pisaliq != null && gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_Pisaliq.ShouldSerializeSdtJson());

		}


		public override bool ShouldSerializeSdtJson()
		{
			return (
				ShouldSerializegxTpr_Pisaliq_Json() || 
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
			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_Pisaliq_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_Pisaliq_N;
		protected SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_PISAliq gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_Pisaliq = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdNotaFiscal.NFe.infNFe.detItem.imposto.PIS", Namespace="Factory21")]
	public class SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_RESTInterface : GxGenericCollectionItem<SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_RESTInterface( ) : base()
		{	
		}

		public SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_RESTInterface( SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("PISAliq")]
		[JsonPropertyOrder(0)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="PISAliq", Order=0, EmitDefaultValue=false)]
		public SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_PISAliq_RESTInterface gxTpr_Pisaliq
		{
			get {
				if (sdt.ShouldSerializegxTpr_Pisaliq_Json())
					return new SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_PISAliq_RESTInterface(sdt.gxTpr_Pisaliq);
				else
					return null;

			}

			set {
				sdt.gxTpr_Pisaliq = value.sdt;
			}

		}


		#endregion
		[JsonIgnore]
		public SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS sdt
		{
			get { 
				return (SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS)Sdt;
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
				sdt = new SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS() ;
			}
		}
	}
	#endregion
}