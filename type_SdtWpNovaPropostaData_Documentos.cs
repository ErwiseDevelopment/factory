/*
				   File: type_SdtWpNovaPropostaData_Documentos
			Description: Documentos
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
	[XmlRoot(ElementName="WpNovaPropostaData.Documentos")]
	[XmlType(TypeName="WpNovaPropostaData.Documentos" , Namespace="Factory21" )]
	[Serializable]
	public class SdtWpNovaPropostaData_Documentos : GxUserType
	{
		public SdtWpNovaPropostaData_Documentos( )
		{
			/* Constructor for serialization */
		}

		public SdtWpNovaPropostaData_Documentos(IGxContext context)
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
			if (gxTv_SdtWpNovaPropostaData_Documentos_Griddocumentos != null)
			{
				AddObjectProperty("GridDocumentos", gxTv_SdtWpNovaPropostaData_Documentos_Griddocumentos, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="GridDocumentos" )]
		[XmlArray(ElementName="GridDocumentos"  )]
		[XmlArrayItemAttribute(ElementName="GridDocumentosItem" , IsNullable=false )]
		public GXBaseCollection<SdtWpNovaPropostaData_Documentos_GridDocumentosItem> gxTpr_Griddocumentos
		{
			get {
				if ( gxTv_SdtWpNovaPropostaData_Documentos_Griddocumentos == null )
				{
					gxTv_SdtWpNovaPropostaData_Documentos_Griddocumentos = new GXBaseCollection<SdtWpNovaPropostaData_Documentos_GridDocumentosItem>( context, "WpNovaPropostaData.Documentos.GridDocumentosItem", "");
				}
				SetDirty("Griddocumentos");
				return gxTv_SdtWpNovaPropostaData_Documentos_Griddocumentos;
			}
			set {
				gxTv_SdtWpNovaPropostaData_Documentos_Griddocumentos_N = false;
				gxTv_SdtWpNovaPropostaData_Documentos_Griddocumentos = value;
				SetDirty("Griddocumentos");
			}
		}

		public void gxTv_SdtWpNovaPropostaData_Documentos_Griddocumentos_SetNull()
		{
			gxTv_SdtWpNovaPropostaData_Documentos_Griddocumentos_N = true;
			gxTv_SdtWpNovaPropostaData_Documentos_Griddocumentos = null;
		}

		public bool gxTv_SdtWpNovaPropostaData_Documentos_Griddocumentos_IsNull()
		{
			return gxTv_SdtWpNovaPropostaData_Documentos_Griddocumentos == null;
		}
		public bool ShouldSerializegxTpr_Griddocumentos_GxSimpleCollection_Json()
		{
			return gxTv_SdtWpNovaPropostaData_Documentos_Griddocumentos != null && gxTv_SdtWpNovaPropostaData_Documentos_Griddocumentos.Count > 0;

		}


		public override bool ShouldSerializeSdtJson()
		{
			return (
				ShouldSerializegxTpr_Griddocumentos_GxSimpleCollection_Json() || 
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
			gxTv_SdtWpNovaPropostaData_Documentos_Griddocumentos_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtWpNovaPropostaData_Documentos_Griddocumentos_N;
		protected GXBaseCollection<SdtWpNovaPropostaData_Documentos_GridDocumentosItem> gxTv_SdtWpNovaPropostaData_Documentos_Griddocumentos = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WpNovaPropostaData.Documentos", Namespace="Factory21")]
	public class SdtWpNovaPropostaData_Documentos_RESTInterface : GxGenericCollectionItem<SdtWpNovaPropostaData_Documentos>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWpNovaPropostaData_Documentos_RESTInterface( ) : base()
		{	
		}

		public SdtWpNovaPropostaData_Documentos_RESTInterface( SdtWpNovaPropostaData_Documentos psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("GridDocumentos")]
		[JsonPropertyOrder(0)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="GridDocumentos", Order=0, EmitDefaultValue=false)]
		public GxGenericCollection<SdtWpNovaPropostaData_Documentos_GridDocumentosItem_RESTInterface> gxTpr_Griddocumentos
		{
			get {
				if (sdt.ShouldSerializegxTpr_Griddocumentos_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtWpNovaPropostaData_Documentos_GridDocumentosItem_RESTInterface>(sdt.gxTpr_Griddocumentos);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Griddocumentos);
			}
		}


		#endregion
		[JsonIgnore]
		public SdtWpNovaPropostaData_Documentos sdt
		{
			get { 
				return (SdtWpNovaPropostaData_Documentos)Sdt;
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
				sdt = new SdtWpNovaPropostaData_Documentos() ;
			}
		}
	}
	#endregion
}