/*
				   File: type_SdtSdNotaFiscal_NFe_infNFe_cobr
			Description: cobr
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
	[XmlRoot(ElementName="SdNotaFiscal.NFe.infNFe.cobr")]
	[XmlType(TypeName="SdNotaFiscal.NFe.infNFe.cobr" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdNotaFiscal_NFe_infNFe_cobr : GxUserType
	{
		public SdtSdNotaFiscal_NFe_infNFe_cobr( )
		{
			/* Constructor for serialization */
		}

		public SdtSdNotaFiscal_NFe_infNFe_cobr(IGxContext context)
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
			if (gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_Fat != null)
			{
				AddObjectProperty("fat", gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_Fat, false);
			}
			if (gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_Dup != null)
			{
				AddObjectProperty("dup", gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_Dup, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="fat" )]
		[XmlElement(ElementName="fat" )]
		public SdtSdNotaFiscal_NFe_infNFe_cobr_fat gxTpr_Fat
		{
			get {
				if ( gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_Fat == null )
				{
					gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_Fat = new SdtSdNotaFiscal_NFe_infNFe_cobr_fat(context);
				}
				gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_Fat_N = false;
				SetDirty("Fat");
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_Fat;
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_Fat_N = false;
				gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_Fat = value;
				SetDirty("Fat");
			}

		}

		public void gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_Fat_SetNull()
		{
			gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_Fat_N = true;
			gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_Fat = null;
		}

		public bool gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_Fat_IsNull()
		{
			return gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_Fat == null;
		}
		public bool ShouldSerializegxTpr_Fat_Json()
		{
				return (gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_Fat != null && gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_Fat.ShouldSerializeSdtJson());

		}



		[SoapElement(ElementName="dup" )]
		[XmlArray(ElementName="dup"  )]
		[XmlArrayItemAttribute(ElementName="dupItem" , IsNullable=false )]
		public GXBaseCollection<SdtSdNotaFiscal_NFe_infNFe_cobr_dupItem> gxTpr_Dup
		{
			get {
				if ( gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_Dup == null )
				{
					gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_Dup = new GXBaseCollection<SdtSdNotaFiscal_NFe_infNFe_cobr_dupItem>( context, "SdNotaFiscal.NFe.infNFe.cobr.dupItem", "");
				}
				SetDirty("Dup");
				return gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_Dup;
			}
			set {
				gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_Dup_N = false;
				gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_Dup = value;
				SetDirty("Dup");
			}
		}

		public void gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_Dup_SetNull()
		{
			gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_Dup_N = true;
			gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_Dup = null;
		}

		public bool gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_Dup_IsNull()
		{
			return gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_Dup == null;
		}
		public bool ShouldSerializegxTpr_Dup_GxSimpleCollection_Json()
		{
			return gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_Dup != null && gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_Dup.Count > 0;

		}


		public override bool ShouldSerializeSdtJson()
		{
			return (
				ShouldSerializegxTpr_Fat_Json() ||
				ShouldSerializegxTpr_Dup_GxSimpleCollection_Json() || 
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
			gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_Fat_N = true;


			gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_Dup_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_Fat_N;
		protected SdtSdNotaFiscal_NFe_infNFe_cobr_fat gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_Fat = null; 

		protected bool gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_Dup_N;
		protected GXBaseCollection<SdtSdNotaFiscal_NFe_infNFe_cobr_dupItem> gxTv_SdtSdNotaFiscal_NFe_infNFe_cobr_Dup = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdNotaFiscal.NFe.infNFe.cobr", Namespace="Factory21")]
	public class SdtSdNotaFiscal_NFe_infNFe_cobr_RESTInterface : GxGenericCollectionItem<SdtSdNotaFiscal_NFe_infNFe_cobr>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdNotaFiscal_NFe_infNFe_cobr_RESTInterface( ) : base()
		{	
		}

		public SdtSdNotaFiscal_NFe_infNFe_cobr_RESTInterface( SdtSdNotaFiscal_NFe_infNFe_cobr psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("fat")]
		[JsonPropertyOrder(0)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="fat", Order=0, EmitDefaultValue=false)]
		public SdtSdNotaFiscal_NFe_infNFe_cobr_fat_RESTInterface gxTpr_Fat
		{
			get {
				if (sdt.ShouldSerializegxTpr_Fat_Json())
					return new SdtSdNotaFiscal_NFe_infNFe_cobr_fat_RESTInterface(sdt.gxTpr_Fat);
				else
					return null;

			}

			set {
				sdt.gxTpr_Fat = value.sdt;
			}

		}

		[JsonPropertyName("dup")]
		[JsonPropertyOrder(1)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="dup", Order=1, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSdNotaFiscal_NFe_infNFe_cobr_dupItem_RESTInterface> gxTpr_Dup
		{
			get {
				if (sdt.ShouldSerializegxTpr_Dup_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSdNotaFiscal_NFe_infNFe_cobr_dupItem_RESTInterface>(sdt.gxTpr_Dup);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Dup);
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdNotaFiscal_NFe_infNFe_cobr sdt
		{
			get { 
				return (SdtSdNotaFiscal_NFe_infNFe_cobr)Sdt;
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
				sdt = new SdtSdNotaFiscal_NFe_infNFe_cobr() ;
			}
		}
	}
	#endregion
}