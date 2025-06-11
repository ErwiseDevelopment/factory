/*
				   File: type_SdtWzCadastroRepresentanteData
			Description: WzCadastroRepresentanteData
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
	[XmlRoot(ElementName="WzCadastroRepresentanteData")]
	[XmlType(TypeName="WzCadastroRepresentanteData" , Namespace="Factory21" )]
	[Serializable]
	public class SdtWzCadastroRepresentanteData : GxUserType
	{
		public SdtWzCadastroRepresentanteData( )
		{
			/* Constructor for serialization */
		}

		public SdtWzCadastroRepresentanteData(IGxContext context)
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
			if (gxTv_SdtWzCadastroRepresentanteData_Cadastrorepresentante != null)
			{
				AddObjectProperty("CadastroRepresentante", gxTv_SdtWzCadastroRepresentanteData_Cadastrorepresentante, false);
			}
			if (gxTv_SdtWzCadastroRepresentanteData_Cadastroempresa != null)
			{
				AddObjectProperty("CadastroEmpresa", gxTv_SdtWzCadastroRepresentanteData_Cadastroempresa, false);
			}
			if (gxTv_SdtWzCadastroRepresentanteData_Auxiliardata != null)
			{
				AddObjectProperty("AuxiliarData", gxTv_SdtWzCadastroRepresentanteData_Auxiliardata, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="CadastroRepresentante" )]
		[XmlElement(ElementName="CadastroRepresentante" )]
		public SdtWzCadastroRepresentanteData_CadastroRepresentante gxTpr_Cadastrorepresentante
		{
			get {
				if ( gxTv_SdtWzCadastroRepresentanteData_Cadastrorepresentante == null )
				{
					gxTv_SdtWzCadastroRepresentanteData_Cadastrorepresentante = new SdtWzCadastroRepresentanteData_CadastroRepresentante(context);
				}
				gxTv_SdtWzCadastroRepresentanteData_Cadastrorepresentante_N = false;
				SetDirty("Cadastrorepresentante");
				return gxTv_SdtWzCadastroRepresentanteData_Cadastrorepresentante;
			}
			set {
				gxTv_SdtWzCadastroRepresentanteData_Cadastrorepresentante_N = false;
				gxTv_SdtWzCadastroRepresentanteData_Cadastrorepresentante = value;
				SetDirty("Cadastrorepresentante");
			}

		}

		public void gxTv_SdtWzCadastroRepresentanteData_Cadastrorepresentante_SetNull()
		{
			gxTv_SdtWzCadastroRepresentanteData_Cadastrorepresentante_N = true;
			gxTv_SdtWzCadastroRepresentanteData_Cadastrorepresentante = null;
		}

		public bool gxTv_SdtWzCadastroRepresentanteData_Cadastrorepresentante_IsNull()
		{
			return gxTv_SdtWzCadastroRepresentanteData_Cadastrorepresentante == null;
		}
		public bool ShouldSerializegxTpr_Cadastrorepresentante_Json()
		{
				return (gxTv_SdtWzCadastroRepresentanteData_Cadastrorepresentante != null && gxTv_SdtWzCadastroRepresentanteData_Cadastrorepresentante.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="CadastroEmpresa" )]
		[XmlElement(ElementName="CadastroEmpresa" )]
		public SdtWzCadastroRepresentanteData_CadastroEmpresa gxTpr_Cadastroempresa
		{
			get {
				if ( gxTv_SdtWzCadastroRepresentanteData_Cadastroempresa == null )
				{
					gxTv_SdtWzCadastroRepresentanteData_Cadastroempresa = new SdtWzCadastroRepresentanteData_CadastroEmpresa(context);
				}
				gxTv_SdtWzCadastroRepresentanteData_Cadastroempresa_N = false;
				SetDirty("Cadastroempresa");
				return gxTv_SdtWzCadastroRepresentanteData_Cadastroempresa;
			}
			set {
				gxTv_SdtWzCadastroRepresentanteData_Cadastroempresa_N = false;
				gxTv_SdtWzCadastroRepresentanteData_Cadastroempresa = value;
				SetDirty("Cadastroempresa");
			}

		}

		public void gxTv_SdtWzCadastroRepresentanteData_Cadastroempresa_SetNull()
		{
			gxTv_SdtWzCadastroRepresentanteData_Cadastroempresa_N = true;
			gxTv_SdtWzCadastroRepresentanteData_Cadastroempresa = null;
		}

		public bool gxTv_SdtWzCadastroRepresentanteData_Cadastroempresa_IsNull()
		{
			return gxTv_SdtWzCadastroRepresentanteData_Cadastroempresa == null;
		}
		public bool ShouldSerializegxTpr_Cadastroempresa_Json()
		{
				return (gxTv_SdtWzCadastroRepresentanteData_Cadastroempresa != null && gxTv_SdtWzCadastroRepresentanteData_Cadastroempresa.ShouldSerializeSdtJson());

		}



		[SoapElement(ElementName="AuxiliarData" )]
		[XmlArray(ElementName="AuxiliarData"  )]
		[XmlArrayItemAttribute(ElementName="WizardAuxiliarDataItem" , IsNullable=false )]
		public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem> gxTpr_Auxiliardata_GXBaseCollection
		{
			get {
				if ( gxTv_SdtWzCadastroRepresentanteData_Auxiliardata == null )
				{
					gxTv_SdtWzCadastroRepresentanteData_Auxiliardata = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem>( context, "WizardAuxiliarData", "");
				}
				return gxTv_SdtWzCadastroRepresentanteData_Auxiliardata;
			}
			set {
				gxTv_SdtWzCadastroRepresentanteData_Auxiliardata_N = false;
				gxTv_SdtWzCadastroRepresentanteData_Auxiliardata = value;
			}
		}

		[XmlIgnore]
		public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem> gxTpr_Auxiliardata
		{
			get {
				if ( gxTv_SdtWzCadastroRepresentanteData_Auxiliardata == null )
				{
					gxTv_SdtWzCadastroRepresentanteData_Auxiliardata = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem>( context, "WizardAuxiliarData", "");
				}
				gxTv_SdtWzCadastroRepresentanteData_Auxiliardata_N = false;
				SetDirty("Auxiliardata");
				return gxTv_SdtWzCadastroRepresentanteData_Auxiliardata ;
			}
			set {
				gxTv_SdtWzCadastroRepresentanteData_Auxiliardata_N = false;
				gxTv_SdtWzCadastroRepresentanteData_Auxiliardata = value;
				SetDirty("Auxiliardata");
			}
		}

		public void gxTv_SdtWzCadastroRepresentanteData_Auxiliardata_SetNull()
		{
			gxTv_SdtWzCadastroRepresentanteData_Auxiliardata_N = true;
			gxTv_SdtWzCadastroRepresentanteData_Auxiliardata = null;
		}

		public bool gxTv_SdtWzCadastroRepresentanteData_Auxiliardata_IsNull()
		{
			return gxTv_SdtWzCadastroRepresentanteData_Auxiliardata == null;
		}
		public bool ShouldSerializegxTpr_Auxiliardata_GXBaseCollection_Json()
		{
			return gxTv_SdtWzCadastroRepresentanteData_Auxiliardata != null && gxTv_SdtWzCadastroRepresentanteData_Auxiliardata.Count > 0;

		}

		public override bool ShouldSerializeSdtJson()
		{
			return (
				ShouldSerializegxTpr_Cadastrorepresentante_Json() ||
				ShouldSerializegxTpr_Cadastroempresa_Json() ||
				 ShouldSerializegxTpr_Auxiliardata_GXBaseCollection_Json()||  
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
			gxTv_SdtWzCadastroRepresentanteData_Cadastrorepresentante_N = true;


			gxTv_SdtWzCadastroRepresentanteData_Cadastroempresa_N = true;


			gxTv_SdtWzCadastroRepresentanteData_Auxiliardata_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtWzCadastroRepresentanteData_Cadastrorepresentante_N;
		protected SdtWzCadastroRepresentanteData_CadastroRepresentante gxTv_SdtWzCadastroRepresentanteData_Cadastrorepresentante = null; 

		protected bool gxTv_SdtWzCadastroRepresentanteData_Cadastroempresa_N;
		protected SdtWzCadastroRepresentanteData_CadastroEmpresa gxTv_SdtWzCadastroRepresentanteData_Cadastroempresa = null; 

		protected bool gxTv_SdtWzCadastroRepresentanteData_Auxiliardata_N;
		protected GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem> gxTv_SdtWzCadastroRepresentanteData_Auxiliardata = null;  


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WzCadastroRepresentanteData", Namespace="Factory21")]
	public class SdtWzCadastroRepresentanteData_RESTInterface : GxGenericCollectionItem<SdtWzCadastroRepresentanteData>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWzCadastroRepresentanteData_RESTInterface( ) : base()
		{	
		}

		public SdtWzCadastroRepresentanteData_RESTInterface( SdtWzCadastroRepresentanteData psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("CadastroRepresentante")]
		[JsonPropertyOrder(0)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="CadastroRepresentante", Order=0, EmitDefaultValue=false)]
		public SdtWzCadastroRepresentanteData_CadastroRepresentante_RESTInterface gxTpr_Cadastrorepresentante
		{
			get {
				if (sdt.ShouldSerializegxTpr_Cadastrorepresentante_Json())
					return new SdtWzCadastroRepresentanteData_CadastroRepresentante_RESTInterface(sdt.gxTpr_Cadastrorepresentante);
				else
					return null;

			}

			set {
				sdt.gxTpr_Cadastrorepresentante = value.sdt;
			}

		}

		[JsonPropertyName("CadastroEmpresa")]
		[JsonPropertyOrder(1)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="CadastroEmpresa", Order=1, EmitDefaultValue=false)]
		public SdtWzCadastroRepresentanteData_CadastroEmpresa_RESTInterface gxTpr_Cadastroempresa
		{
			get {
				if (sdt.ShouldSerializegxTpr_Cadastroempresa_Json())
					return new SdtWzCadastroRepresentanteData_CadastroEmpresa_RESTInterface(sdt.gxTpr_Cadastroempresa);
				else
					return null;

			}

			set {
				sdt.gxTpr_Cadastroempresa = value.sdt;
			}

		}

		[JsonPropertyName("AuxiliarData")]
		[JsonPropertyOrder(2)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="AuxiliarData", Order=2, EmitDefaultValue=false)]
		public  GxGenericCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem_RESTInterface> gxTpr_Auxiliardata
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Auxiliardata_GXBaseCollection_Json())
					return new GxGenericCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem_RESTInterface>(sdt.gxTpr_Auxiliardata);
				else
					return null;

			}
			set { 
				value.LoadCollection(sdt.gxTpr_Auxiliardata);
			}
		}


		#endregion
		[JsonIgnore]
		public SdtWzCadastroRepresentanteData sdt
		{
			get { 
				return (SdtWzCadastroRepresentanteData)Sdt;
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
				sdt = new SdtWzCadastroRepresentanteData() ;
			}
		}
	}
	#endregion
}