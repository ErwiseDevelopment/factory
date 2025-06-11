/*
				   File: type_SdtSdSerasaPFProposta
			Description: SdSerasaPFProposta
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
	[XmlRoot(ElementName="SdSerasaPFProposta")]
	[XmlType(TypeName="SdSerasaPFProposta" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdSerasaPFProposta : GxUserType
	{
		public SdtSdSerasaPFProposta( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdSerasaPFProposta_Cpf = "";

			gxTv_SdtSdSerasaPFProposta_Valoroperacao = "";

			gxTv_SdtSdSerasaPFProposta_Politica = "";


		}

		public SdtSdSerasaPFProposta(IGxContext context)
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
			AddObjectProperty("cpf", gxTpr_Cpf, false);


			AddObjectProperty("valorOperacao", gxTpr_Valoroperacao, false);


			AddObjectProperty("politica", gxTpr_Politica, false);


			AddObjectProperty("codTipoVenda", gxTpr_Codtipovenda, false);

			if (gxTv_SdtSdSerasaPFProposta_Informacoesadicionais != null)
			{
				AddObjectProperty("informacoesAdicionais", gxTv_SdtSdSerasaPFProposta_Informacoesadicionais, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="cpf")]
		[XmlElement(ElementName="cpf")]
		public string gxTpr_Cpf
		{
			get {
				return gxTv_SdtSdSerasaPFProposta_Cpf; 
			}
			set {
				gxTv_SdtSdSerasaPFProposta_Cpf = value;
				SetDirty("Cpf");
			}
		}




		[SoapElement(ElementName="valorOperacao")]
		[XmlElement(ElementName="valorOperacao")]
		public string gxTpr_Valoroperacao
		{
			get {
				return gxTv_SdtSdSerasaPFProposta_Valoroperacao; 
			}
			set {
				gxTv_SdtSdSerasaPFProposta_Valoroperacao = value;
				SetDirty("Valoroperacao");
			}
		}




		[SoapElement(ElementName="politica")]
		[XmlElement(ElementName="politica")]
		public string gxTpr_Politica
		{
			get {
				return gxTv_SdtSdSerasaPFProposta_Politica; 
			}
			set {
				gxTv_SdtSdSerasaPFProposta_Politica = value;
				SetDirty("Politica");
			}
		}



		[SoapElement(ElementName="codTipoVenda")]
		[XmlElement(ElementName="codTipoVenda")]
		public string gxTpr_Codtipovenda_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdSerasaPFProposta_Codtipovenda, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdSerasaPFProposta_Codtipovenda = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Codtipovenda
		{
			get {
				return gxTv_SdtSdSerasaPFProposta_Codtipovenda; 
			}
			set {
				gxTv_SdtSdSerasaPFProposta_Codtipovenda = value;
				SetDirty("Codtipovenda");
			}
		}



		[SoapElement(ElementName="informacoesAdicionais" )]
		[XmlElement(ElementName="informacoesAdicionais" )]
		public SdtSdSerasaPFProposta_informacoesAdicionais gxTpr_Informacoesadicionais
		{
			get {
				if ( gxTv_SdtSdSerasaPFProposta_Informacoesadicionais == null )
				{
					gxTv_SdtSdSerasaPFProposta_Informacoesadicionais = new SdtSdSerasaPFProposta_informacoesAdicionais(context);
				}
				gxTv_SdtSdSerasaPFProposta_Informacoesadicionais_N = false;
				SetDirty("Informacoesadicionais");
				return gxTv_SdtSdSerasaPFProposta_Informacoesadicionais;
			}
			set {
				gxTv_SdtSdSerasaPFProposta_Informacoesadicionais_N = false;
				gxTv_SdtSdSerasaPFProposta_Informacoesadicionais = value;
				SetDirty("Informacoesadicionais");
			}

		}

		public void gxTv_SdtSdSerasaPFProposta_Informacoesadicionais_SetNull()
		{
			gxTv_SdtSdSerasaPFProposta_Informacoesadicionais_N = true;
			gxTv_SdtSdSerasaPFProposta_Informacoesadicionais = null;
		}

		public bool gxTv_SdtSdSerasaPFProposta_Informacoesadicionais_IsNull()
		{
			return gxTv_SdtSdSerasaPFProposta_Informacoesadicionais == null;
		}
		public bool ShouldSerializegxTpr_Informacoesadicionais_Json()
		{
				return (gxTv_SdtSdSerasaPFProposta_Informacoesadicionais != null && gxTv_SdtSdSerasaPFProposta_Informacoesadicionais.ShouldSerializeSdtJson());

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
			gxTv_SdtSdSerasaPFProposta_Cpf = "";
			gxTv_SdtSdSerasaPFProposta_Valoroperacao = "";
			gxTv_SdtSdSerasaPFProposta_Politica = "";


			gxTv_SdtSdSerasaPFProposta_Informacoesadicionais_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSdSerasaPFProposta_Cpf;
		 

		protected string gxTv_SdtSdSerasaPFProposta_Valoroperacao;
		 

		protected string gxTv_SdtSdSerasaPFProposta_Politica;
		 

		protected decimal gxTv_SdtSdSerasaPFProposta_Codtipovenda;
		 
		protected bool gxTv_SdtSdSerasaPFProposta_Informacoesadicionais_N;
		protected SdtSdSerasaPFProposta_informacoesAdicionais gxTv_SdtSdSerasaPFProposta_Informacoesadicionais = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdSerasaPFProposta", Namespace="Factory21")]
	public class SdtSdSerasaPFProposta_RESTInterface : GxGenericCollectionItem<SdtSdSerasaPFProposta>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdSerasaPFProposta_RESTInterface( ) : base()
		{	
		}

		public SdtSdSerasaPFProposta_RESTInterface( SdtSdSerasaPFProposta psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("cpf")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="cpf", Order=0)]
		public  string gxTpr_Cpf
		{
			get { 
				return sdt.gxTpr_Cpf;

			}
			set { 
				 sdt.gxTpr_Cpf = value;
			}
		}

		[JsonPropertyName("valorOperacao")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="valorOperacao", Order=1)]
		public  string gxTpr_Valoroperacao
		{
			get { 
				return sdt.gxTpr_Valoroperacao;

			}
			set { 
				 sdt.gxTpr_Valoroperacao = value;
			}
		}

		[JsonPropertyName("politica")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="politica", Order=2)]
		public  string gxTpr_Politica
		{
			get { 
				return sdt.gxTpr_Politica;

			}
			set { 
				 sdt.gxTpr_Politica = value;
			}
		}

		[JsonPropertyName("codTipoVenda")]
		[JsonPropertyOrder(3)]
		[DataMember(Name="codTipoVenda", Order=3)]
		public  string gxTpr_Codtipovenda
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Codtipovenda, 10, 5));

			}
			set { 
				sdt.gxTpr_Codtipovenda =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("informacoesAdicionais")]
		[JsonPropertyOrder(4)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="informacoesAdicionais", Order=4, EmitDefaultValue=false)]
		public SdtSdSerasaPFProposta_informacoesAdicionais_RESTInterface gxTpr_Informacoesadicionais
		{
			get {
				if (sdt.ShouldSerializegxTpr_Informacoesadicionais_Json())
					return new SdtSdSerasaPFProposta_informacoesAdicionais_RESTInterface(sdt.gxTpr_Informacoesadicionais);
				else
					return null;

			}

			set {
				sdt.gxTpr_Informacoesadicionais = value.sdt;
			}

		}


		#endregion
		[JsonIgnore]
		public SdtSdSerasaPFProposta sdt
		{
			get { 
				return (SdtSdSerasaPFProposta)Sdt;
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
				sdt = new SdtSdSerasaPFProposta() ;
			}
		}
	}
	#endregion
}