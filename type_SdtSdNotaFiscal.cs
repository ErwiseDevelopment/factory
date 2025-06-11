/*
				   File: type_SdtSdNotaFiscal
			Description: SdNotaFiscal
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
	[XmlRoot(ElementName="SdNotaFiscal")]
	[XmlType(TypeName="SdNotaFiscal" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdNotaFiscal : GxUserType
	{
		public SdtSdNotaFiscal( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdNotaFiscal_Nome_arquivo = "";

		}

		public SdtSdNotaFiscal(IGxContext context)
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
			if (gxTv_SdtSdNotaFiscal_Nfe != null)
			{
				AddObjectProperty("NFe", gxTv_SdtSdNotaFiscal_Nfe, false);
			}

			AddObjectProperty("nome_arquivo", gxTpr_Nome_arquivo, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="NFe" )]
		[XmlElement(ElementName="NFe" )]
		public SdtSdNotaFiscal_NFe gxTpr_Nfe
		{
			get {
				if ( gxTv_SdtSdNotaFiscal_Nfe == null )
				{
					gxTv_SdtSdNotaFiscal_Nfe = new SdtSdNotaFiscal_NFe(context);
				}
				gxTv_SdtSdNotaFiscal_Nfe_N = false;
				SetDirty("Nfe");
				return gxTv_SdtSdNotaFiscal_Nfe;
			}
			set {
				gxTv_SdtSdNotaFiscal_Nfe_N = false;
				gxTv_SdtSdNotaFiscal_Nfe = value;
				SetDirty("Nfe");
			}

		}

		public void gxTv_SdtSdNotaFiscal_Nfe_SetNull()
		{
			gxTv_SdtSdNotaFiscal_Nfe_N = true;
			gxTv_SdtSdNotaFiscal_Nfe = null;
		}

		public bool gxTv_SdtSdNotaFiscal_Nfe_IsNull()
		{
			return gxTv_SdtSdNotaFiscal_Nfe == null;
		}
		public bool ShouldSerializegxTpr_Nfe_Json()
		{
				return (gxTv_SdtSdNotaFiscal_Nfe != null && gxTv_SdtSdNotaFiscal_Nfe.ShouldSerializeSdtJson());

		}



		[SoapElement(ElementName="nome_arquivo")]
		[XmlElement(ElementName="nome_arquivo")]
		public string gxTpr_Nome_arquivo
		{
			get {
				return gxTv_SdtSdNotaFiscal_Nome_arquivo; 
			}
			set {
				gxTv_SdtSdNotaFiscal_Nome_arquivo = value;
				SetDirty("Nome_arquivo");
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
			gxTv_SdtSdNotaFiscal_Nfe_N = true;

			gxTv_SdtSdNotaFiscal_Nome_arquivo = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtSdNotaFiscal_Nfe_N;
		protected SdtSdNotaFiscal_NFe gxTv_SdtSdNotaFiscal_Nfe = null; 


		protected string gxTv_SdtSdNotaFiscal_Nome_arquivo;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdNotaFiscal", Namespace="Factory21")]
	public class SdtSdNotaFiscal_RESTInterface : GxGenericCollectionItem<SdtSdNotaFiscal>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdNotaFiscal_RESTInterface( ) : base()
		{	
		}

		public SdtSdNotaFiscal_RESTInterface( SdtSdNotaFiscal psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("NFe")]
		[JsonPropertyOrder(0)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="NFe", Order=0, EmitDefaultValue=false)]
		public SdtSdNotaFiscal_NFe_RESTInterface gxTpr_Nfe
		{
			get {
				if (sdt.ShouldSerializegxTpr_Nfe_Json())
					return new SdtSdNotaFiscal_NFe_RESTInterface(sdt.gxTpr_Nfe);
				else
					return null;

			}

			set {
				sdt.gxTpr_Nfe = value.sdt;
			}

		}

		[JsonPropertyName("nome_arquivo")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="nome_arquivo", Order=1)]
		public  string gxTpr_Nome_arquivo
		{
			get { 
				return sdt.gxTpr_Nome_arquivo;

			}
			set { 
				 sdt.gxTpr_Nome_arquivo = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdNotaFiscal sdt
		{
			get { 
				return (SdtSdNotaFiscal)Sdt;
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
				sdt = new SdtSdNotaFiscal() ;
			}
		}
	}
	#endregion
}