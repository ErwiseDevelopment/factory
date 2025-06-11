/*
				   File: type_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto
			Description: imposto
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
	[XmlRoot(ElementName="SdNotaFiscal.NFe.infNFe.detItem.imposto")]
	[XmlType(TypeName="SdNotaFiscal.NFe.infNFe.detItem.imposto" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdNotaFiscal_NFe_infNFe_detItem_imposto : GxUserType
	{
		public SdtSdNotaFiscal_NFe_infNFe_detItem_imposto( )
		{
			/* Constructor for serialization */
		}

		public SdtSdNotaFiscal_NFe_infNFe_detItem_imposto(IGxContext context)
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
			if (gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_Icms != null)
			{
				AddObjectProperty("ICMS", gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_Icms, false);
			}
			if (gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_Pis != null)
			{
				AddObjectProperty("PIS", gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_Pis, false);
			}
			if (gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_Cofins != null)
			{
				AddObjectProperty("COFINS", gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_Cofins, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ICMS" )]
		[XmlElement(ElementName="ICMS" )]
		public SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS gxTpr_Icms
		{
			get {
				if ( gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_Icms == null )
				{
					gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_Icms = new SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS(context);
				}
				gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_Icms_N = false;
				SetDirty("Icms");
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_Icms;
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_Icms_N = false;
				gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_Icms = value;
				SetDirty("Icms");
			}

		}

		public void gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_Icms_SetNull()
		{
			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_Icms_N = true;
			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_Icms = null;
		}

		public bool gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_Icms_IsNull()
		{
			return gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_Icms == null;
		}
		public bool ShouldSerializegxTpr_Icms_Json()
		{
				return (gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_Icms != null && gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_Icms.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="PIS" )]
		[XmlElement(ElementName="PIS" )]
		public SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS gxTpr_Pis
		{
			get {
				if ( gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_Pis == null )
				{
					gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_Pis = new SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS(context);
				}
				gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_Pis_N = false;
				SetDirty("Pis");
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_Pis;
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_Pis_N = false;
				gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_Pis = value;
				SetDirty("Pis");
			}

		}

		public void gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_Pis_SetNull()
		{
			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_Pis_N = true;
			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_Pis = null;
		}

		public bool gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_Pis_IsNull()
		{
			return gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_Pis == null;
		}
		public bool ShouldSerializegxTpr_Pis_Json()
		{
				return (gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_Pis != null && gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_Pis.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="COFINS" )]
		[XmlElement(ElementName="COFINS" )]
		public SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS gxTpr_Cofins
		{
			get {
				if ( gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_Cofins == null )
				{
					gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_Cofins = new SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS(context);
				}
				gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_Cofins_N = false;
				SetDirty("Cofins");
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_Cofins;
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_Cofins_N = false;
				gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_Cofins = value;
				SetDirty("Cofins");
			}

		}

		public void gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_Cofins_SetNull()
		{
			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_Cofins_N = true;
			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_Cofins = null;
		}

		public bool gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_Cofins_IsNull()
		{
			return gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_Cofins == null;
		}
		public bool ShouldSerializegxTpr_Cofins_Json()
		{
				return (gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_Cofins != null && gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_Cofins.ShouldSerializeSdtJson());

		}


		public override bool ShouldSerializeSdtJson()
		{
			return (
				ShouldSerializegxTpr_Icms_Json() ||
				ShouldSerializegxTpr_Pis_Json() ||
				ShouldSerializegxTpr_Cofins_Json() || 
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
			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_Icms_N = true;


			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_Pis_N = true;


			gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_Cofins_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_Icms_N;
		protected SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_Icms = null; 

		protected bool gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_Pis_N;
		protected SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_Pis = null; 

		protected bool gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_Cofins_N;
		protected SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS gxTv_SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_Cofins = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdNotaFiscal.NFe.infNFe.detItem.imposto", Namespace="Factory21")]
	public class SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_RESTInterface : GxGenericCollectionItem<SdtSdNotaFiscal_NFe_infNFe_detItem_imposto>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_RESTInterface( ) : base()
		{	
		}

		public SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_RESTInterface( SdtSdNotaFiscal_NFe_infNFe_detItem_imposto psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("ICMS")]
		[JsonPropertyOrder(0)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="ICMS", Order=0, EmitDefaultValue=false)]
		public SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_RESTInterface gxTpr_Icms
		{
			get {
				if (sdt.ShouldSerializegxTpr_Icms_Json())
					return new SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_ICMS_RESTInterface(sdt.gxTpr_Icms);
				else
					return null;

			}

			set {
				sdt.gxTpr_Icms = value.sdt;
			}

		}

		[JsonPropertyName("PIS")]
		[JsonPropertyOrder(1)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="PIS", Order=1, EmitDefaultValue=false)]
		public SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_RESTInterface gxTpr_Pis
		{
			get {
				if (sdt.ShouldSerializegxTpr_Pis_Json())
					return new SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_PIS_RESTInterface(sdt.gxTpr_Pis);
				else
					return null;

			}

			set {
				sdt.gxTpr_Pis = value.sdt;
			}

		}

		[JsonPropertyName("COFINS")]
		[JsonPropertyOrder(2)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="COFINS", Order=2, EmitDefaultValue=false)]
		public SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_RESTInterface gxTpr_Cofins
		{
			get {
				if (sdt.ShouldSerializegxTpr_Cofins_Json())
					return new SdtSdNotaFiscal_NFe_infNFe_detItem_imposto_COFINS_RESTInterface(sdt.gxTpr_Cofins);
				else
					return null;

			}

			set {
				sdt.gxTpr_Cofins = value.sdt;
			}

		}


		#endregion
		[JsonIgnore]
		public SdtSdNotaFiscal_NFe_infNFe_detItem_imposto sdt
		{
			get { 
				return (SdtSdNotaFiscal_NFe_infNFe_detItem_imposto)Sdt;
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
				sdt = new SdtSdNotaFiscal_NFe_infNFe_detItem_imposto() ;
			}
		}
	}
	#endregion
}