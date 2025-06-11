/*
				   File: type_SdtIniciarSistemaData_Empresa
			Description: Empresa
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
	[XmlRoot(ElementName="IniciarSistemaData.Empresa")]
	[XmlType(TypeName="IniciarSistemaData.Empresa" , Namespace="Factory21" )]
	[Serializable]
	public class SdtIniciarSistemaData_Empresa : GxUserType
	{
		public SdtIniciarSistemaData_Empresa( )
		{
			/* Constructor for serialization */
			gxTv_SdtIniciarSistemaData_Empresa_Empresacnpj = "";

			gxTv_SdtIniciarSistemaData_Empresa_Empresarazaosocial = "";

			gxTv_SdtIniciarSistemaData_Empresa_Empresanomefantasia = "";

			gxTv_SdtIniciarSistemaData_Empresa_Empresaemail = "";

			gxTv_SdtIniciarSistemaData_Empresa_Empresacep = "";

			gxTv_SdtIniciarSistemaData_Empresa_Empresalogradouro = "";

			gxTv_SdtIniciarSistemaData_Empresa_Empresabairro = "";

			gxTv_SdtIniciarSistemaData_Empresa_Empresacomplemento = "";

			gxTv_SdtIniciarSistemaData_Empresa_Municipiocodigo = "";

			gxTv_SdtIniciarSistemaData_Empresa_Municipionome = "";

			gxTv_SdtIniciarSistemaData_Empresa_Municipiouf = "";

			gxTv_SdtIniciarSistemaData_Empresa_Empresapixtipo = "";

			gxTv_SdtIniciarSistemaData_Empresa_Empresapix = "";

		}

		public SdtIniciarSistemaData_Empresa(IGxContext context)
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
			AddObjectProperty("EmpresaCNPJ", gxTpr_Empresacnpj, false);


			AddObjectProperty("EmpresaRazaoSocial", gxTpr_Empresarazaosocial, false);


			AddObjectProperty("EmpresaNomeFantasia", gxTpr_Empresanomefantasia, false);


			AddObjectProperty("EmpresaEmail", gxTpr_Empresaemail, false);


			AddObjectProperty("EmpresaSede", gxTpr_Empresasede, false);


			AddObjectProperty("EmpresaCEP", gxTpr_Empresacep, false);


			AddObjectProperty("EmpresaLogradouro", gxTpr_Empresalogradouro, false);


			AddObjectProperty("EmpresaLogradouroNumero", gxTpr_Empresalogradouronumero, false);


			AddObjectProperty("EmpresaBairro", gxTpr_Empresabairro, false);


			AddObjectProperty("EmpresaComplemento", gxTpr_Empresacomplemento, false);


			AddObjectProperty("MunicipioCodigo", gxTpr_Municipiocodigo, false);


			AddObjectProperty("MunicipioNome", gxTpr_Municipionome, false);


			AddObjectProperty("MunicipioUF", gxTpr_Municipiouf, false);


			AddObjectProperty("EmpresaBancoId", gxTpr_Empresabancoid, false);


			AddObjectProperty("EmpresaAgencia", gxTpr_Empresaagencia, false);


			AddObjectProperty("EmpresaAgenciaDigito", gxTpr_Empresaagenciadigito, false);


			AddObjectProperty("EmpresaConta", gxTpr_Empresaconta, false);


			AddObjectProperty("EmpresaPixTipo", gxTpr_Empresapixtipo, false);


			AddObjectProperty("EmpresaPix", gxTpr_Empresapix, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="EmpresaCNPJ")]
		[XmlElement(ElementName="EmpresaCNPJ")]
		public string gxTpr_Empresacnpj
		{
			get {
				return gxTv_SdtIniciarSistemaData_Empresa_Empresacnpj; 
			}
			set {
				gxTv_SdtIniciarSistemaData_Empresa_Empresacnpj = value;
				SetDirty("Empresacnpj");
			}
		}




		[SoapElement(ElementName="EmpresaRazaoSocial")]
		[XmlElement(ElementName="EmpresaRazaoSocial")]
		public string gxTpr_Empresarazaosocial
		{
			get {
				return gxTv_SdtIniciarSistemaData_Empresa_Empresarazaosocial; 
			}
			set {
				gxTv_SdtIniciarSistemaData_Empresa_Empresarazaosocial = value;
				SetDirty("Empresarazaosocial");
			}
		}




		[SoapElement(ElementName="EmpresaNomeFantasia")]
		[XmlElement(ElementName="EmpresaNomeFantasia")]
		public string gxTpr_Empresanomefantasia
		{
			get {
				return gxTv_SdtIniciarSistemaData_Empresa_Empresanomefantasia; 
			}
			set {
				gxTv_SdtIniciarSistemaData_Empresa_Empresanomefantasia = value;
				SetDirty("Empresanomefantasia");
			}
		}




		[SoapElement(ElementName="EmpresaEmail")]
		[XmlElement(ElementName="EmpresaEmail")]
		public string gxTpr_Empresaemail
		{
			get {
				return gxTv_SdtIniciarSistemaData_Empresa_Empresaemail; 
			}
			set {
				gxTv_SdtIniciarSistemaData_Empresa_Empresaemail = value;
				SetDirty("Empresaemail");
			}
		}




		[SoapElement(ElementName="EmpresaSede")]
		[XmlElement(ElementName="EmpresaSede")]
		public bool gxTpr_Empresasede
		{
			get {
				return gxTv_SdtIniciarSistemaData_Empresa_Empresasede; 
			}
			set {
				gxTv_SdtIniciarSistemaData_Empresa_Empresasede = value;
				SetDirty("Empresasede");
			}
		}




		[SoapElement(ElementName="EmpresaCEP")]
		[XmlElement(ElementName="EmpresaCEP")]
		public string gxTpr_Empresacep
		{
			get {
				return gxTv_SdtIniciarSistemaData_Empresa_Empresacep; 
			}
			set {
				gxTv_SdtIniciarSistemaData_Empresa_Empresacep = value;
				SetDirty("Empresacep");
			}
		}




		[SoapElement(ElementName="EmpresaLogradouro")]
		[XmlElement(ElementName="EmpresaLogradouro")]
		public string gxTpr_Empresalogradouro
		{
			get {
				return gxTv_SdtIniciarSistemaData_Empresa_Empresalogradouro; 
			}
			set {
				gxTv_SdtIniciarSistemaData_Empresa_Empresalogradouro = value;
				SetDirty("Empresalogradouro");
			}
		}




		[SoapElement(ElementName="EmpresaLogradouroNumero")]
		[XmlElement(ElementName="EmpresaLogradouroNumero")]
		public long gxTpr_Empresalogradouronumero
		{
			get {
				return gxTv_SdtIniciarSistemaData_Empresa_Empresalogradouronumero; 
			}
			set {
				gxTv_SdtIniciarSistemaData_Empresa_Empresalogradouronumero = value;
				SetDirty("Empresalogradouronumero");
			}
		}




		[SoapElement(ElementName="EmpresaBairro")]
		[XmlElement(ElementName="EmpresaBairro")]
		public string gxTpr_Empresabairro
		{
			get {
				return gxTv_SdtIniciarSistemaData_Empresa_Empresabairro; 
			}
			set {
				gxTv_SdtIniciarSistemaData_Empresa_Empresabairro = value;
				SetDirty("Empresabairro");
			}
		}




		[SoapElement(ElementName="EmpresaComplemento")]
		[XmlElement(ElementName="EmpresaComplemento")]
		public string gxTpr_Empresacomplemento
		{
			get {
				return gxTv_SdtIniciarSistemaData_Empresa_Empresacomplemento; 
			}
			set {
				gxTv_SdtIniciarSistemaData_Empresa_Empresacomplemento = value;
				SetDirty("Empresacomplemento");
			}
		}




		[SoapElement(ElementName="MunicipioCodigo")]
		[XmlElement(ElementName="MunicipioCodigo")]
		public string gxTpr_Municipiocodigo
		{
			get {
				return gxTv_SdtIniciarSistemaData_Empresa_Municipiocodigo; 
			}
			set {
				gxTv_SdtIniciarSistemaData_Empresa_Municipiocodigo = value;
				SetDirty("Municipiocodigo");
			}
		}




		[SoapElement(ElementName="MunicipioNome")]
		[XmlElement(ElementName="MunicipioNome")]
		public string gxTpr_Municipionome
		{
			get {
				return gxTv_SdtIniciarSistemaData_Empresa_Municipionome; 
			}
			set {
				gxTv_SdtIniciarSistemaData_Empresa_Municipionome = value;
				SetDirty("Municipionome");
			}
		}




		[SoapElement(ElementName="MunicipioUF")]
		[XmlElement(ElementName="MunicipioUF")]
		public string gxTpr_Municipiouf
		{
			get {
				return gxTv_SdtIniciarSistemaData_Empresa_Municipiouf; 
			}
			set {
				gxTv_SdtIniciarSistemaData_Empresa_Municipiouf = value;
				SetDirty("Municipiouf");
			}
		}




		[SoapElement(ElementName="EmpresaBancoId")]
		[XmlElement(ElementName="EmpresaBancoId")]
		public int gxTpr_Empresabancoid
		{
			get {
				return gxTv_SdtIniciarSistemaData_Empresa_Empresabancoid; 
			}
			set {
				gxTv_SdtIniciarSistemaData_Empresa_Empresabancoid = value;
				SetDirty("Empresabancoid");
			}
		}




		[SoapElement(ElementName="EmpresaAgencia")]
		[XmlElement(ElementName="EmpresaAgencia")]
		public int gxTpr_Empresaagencia
		{
			get {
				return gxTv_SdtIniciarSistemaData_Empresa_Empresaagencia; 
			}
			set {
				gxTv_SdtIniciarSistemaData_Empresa_Empresaagencia = value;
				SetDirty("Empresaagencia");
			}
		}




		[SoapElement(ElementName="EmpresaAgenciaDigito")]
		[XmlElement(ElementName="EmpresaAgenciaDigito")]
		public int gxTpr_Empresaagenciadigito
		{
			get {
				return gxTv_SdtIniciarSistemaData_Empresa_Empresaagenciadigito; 
			}
			set {
				gxTv_SdtIniciarSistemaData_Empresa_Empresaagenciadigito = value;
				SetDirty("Empresaagenciadigito");
			}
		}




		[SoapElement(ElementName="EmpresaConta")]
		[XmlElement(ElementName="EmpresaConta")]
		public int gxTpr_Empresaconta
		{
			get {
				return gxTv_SdtIniciarSistemaData_Empresa_Empresaconta; 
			}
			set {
				gxTv_SdtIniciarSistemaData_Empresa_Empresaconta = value;
				SetDirty("Empresaconta");
			}
		}




		[SoapElement(ElementName="EmpresaPixTipo")]
		[XmlElement(ElementName="EmpresaPixTipo")]
		public string gxTpr_Empresapixtipo
		{
			get {
				return gxTv_SdtIniciarSistemaData_Empresa_Empresapixtipo; 
			}
			set {
				gxTv_SdtIniciarSistemaData_Empresa_Empresapixtipo = value;
				SetDirty("Empresapixtipo");
			}
		}




		[SoapElement(ElementName="EmpresaPix")]
		[XmlElement(ElementName="EmpresaPix")]
		public string gxTpr_Empresapix
		{
			get {
				return gxTv_SdtIniciarSistemaData_Empresa_Empresapix; 
			}
			set {
				gxTv_SdtIniciarSistemaData_Empresa_Empresapix = value;
				SetDirty("Empresapix");
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
			gxTv_SdtIniciarSistemaData_Empresa_Empresacnpj = "";
			gxTv_SdtIniciarSistemaData_Empresa_Empresarazaosocial = "";
			gxTv_SdtIniciarSistemaData_Empresa_Empresanomefantasia = "";
			gxTv_SdtIniciarSistemaData_Empresa_Empresaemail = "";

			gxTv_SdtIniciarSistemaData_Empresa_Empresacep = "";
			gxTv_SdtIniciarSistemaData_Empresa_Empresalogradouro = "";

			gxTv_SdtIniciarSistemaData_Empresa_Empresabairro = "";
			gxTv_SdtIniciarSistemaData_Empresa_Empresacomplemento = "";
			gxTv_SdtIniciarSistemaData_Empresa_Municipiocodigo = "";
			gxTv_SdtIniciarSistemaData_Empresa_Municipionome = "";
			gxTv_SdtIniciarSistemaData_Empresa_Municipiouf = "";




			gxTv_SdtIniciarSistemaData_Empresa_Empresapixtipo = "";
			gxTv_SdtIniciarSistemaData_Empresa_Empresapix = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtIniciarSistemaData_Empresa_Empresacnpj;
		 

		protected string gxTv_SdtIniciarSistemaData_Empresa_Empresarazaosocial;
		 

		protected string gxTv_SdtIniciarSistemaData_Empresa_Empresanomefantasia;
		 

		protected string gxTv_SdtIniciarSistemaData_Empresa_Empresaemail;
		 

		protected bool gxTv_SdtIniciarSistemaData_Empresa_Empresasede;
		 

		protected string gxTv_SdtIniciarSistemaData_Empresa_Empresacep;
		 

		protected string gxTv_SdtIniciarSistemaData_Empresa_Empresalogradouro;
		 

		protected long gxTv_SdtIniciarSistemaData_Empresa_Empresalogradouronumero;
		 

		protected string gxTv_SdtIniciarSistemaData_Empresa_Empresabairro;
		 

		protected string gxTv_SdtIniciarSistemaData_Empresa_Empresacomplemento;
		 

		protected string gxTv_SdtIniciarSistemaData_Empresa_Municipiocodigo;
		 

		protected string gxTv_SdtIniciarSistemaData_Empresa_Municipionome;
		 

		protected string gxTv_SdtIniciarSistemaData_Empresa_Municipiouf;
		 

		protected int gxTv_SdtIniciarSistemaData_Empresa_Empresabancoid;
		 

		protected int gxTv_SdtIniciarSistemaData_Empresa_Empresaagencia;
		 

		protected int gxTv_SdtIniciarSistemaData_Empresa_Empresaagenciadigito;
		 

		protected int gxTv_SdtIniciarSistemaData_Empresa_Empresaconta;
		 

		protected string gxTv_SdtIniciarSistemaData_Empresa_Empresapixtipo;
		 

		protected string gxTv_SdtIniciarSistemaData_Empresa_Empresapix;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"IniciarSistemaData.Empresa", Namespace="Factory21")]
	public class SdtIniciarSistemaData_Empresa_RESTInterface : GxGenericCollectionItem<SdtIniciarSistemaData_Empresa>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtIniciarSistemaData_Empresa_RESTInterface( ) : base()
		{	
		}

		public SdtIniciarSistemaData_Empresa_RESTInterface( SdtIniciarSistemaData_Empresa psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("EmpresaCNPJ")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="EmpresaCNPJ", Order=0)]
		public  string gxTpr_Empresacnpj
		{
			get { 
				return sdt.gxTpr_Empresacnpj;

			}
			set { 
				 sdt.gxTpr_Empresacnpj = value;
			}
		}

		[JsonPropertyName("EmpresaRazaoSocial")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="EmpresaRazaoSocial", Order=1)]
		public  string gxTpr_Empresarazaosocial
		{
			get { 
				return sdt.gxTpr_Empresarazaosocial;

			}
			set { 
				 sdt.gxTpr_Empresarazaosocial = value;
			}
		}

		[JsonPropertyName("EmpresaNomeFantasia")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="EmpresaNomeFantasia", Order=2)]
		public  string gxTpr_Empresanomefantasia
		{
			get { 
				return sdt.gxTpr_Empresanomefantasia;

			}
			set { 
				 sdt.gxTpr_Empresanomefantasia = value;
			}
		}

		[JsonPropertyName("EmpresaEmail")]
		[JsonPropertyOrder(3)]
		[DataMember(Name="EmpresaEmail", Order=3)]
		public  string gxTpr_Empresaemail
		{
			get { 
				return sdt.gxTpr_Empresaemail;

			}
			set { 
				 sdt.gxTpr_Empresaemail = value;
			}
		}

		[JsonPropertyName("EmpresaSede")]
		[JsonPropertyOrder(4)]
		[JsonConverter(typeof(BoolStringJsonConverter))]
		[DataMember(Name="EmpresaSede", Order=4)]
		public bool gxTpr_Empresasede
		{
			get { 
				return sdt.gxTpr_Empresasede;

			}
			set { 
				sdt.gxTpr_Empresasede = value;
			}
		}

		[JsonPropertyName("EmpresaCEP")]
		[JsonPropertyOrder(5)]
		[DataMember(Name="EmpresaCEP", Order=5)]
		public  string gxTpr_Empresacep
		{
			get { 
				return sdt.gxTpr_Empresacep;

			}
			set { 
				 sdt.gxTpr_Empresacep = value;
			}
		}

		[JsonPropertyName("EmpresaLogradouro")]
		[JsonPropertyOrder(6)]
		[DataMember(Name="EmpresaLogradouro", Order=6)]
		public  string gxTpr_Empresalogradouro
		{
			get { 
				return sdt.gxTpr_Empresalogradouro;

			}
			set { 
				 sdt.gxTpr_Empresalogradouro = value;
			}
		}

		[JsonPropertyName("EmpresaLogradouroNumero")]
		[JsonPropertyOrder(7)]
		[DataMember(Name="EmpresaLogradouroNumero", Order=7)]
		public  string gxTpr_Empresalogradouronumero
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Empresalogradouronumero, 10, 0));

			}
			set { 
				sdt.gxTpr_Empresalogradouronumero = (long) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("EmpresaBairro")]
		[JsonPropertyOrder(8)]
		[DataMember(Name="EmpresaBairro", Order=8)]
		public  string gxTpr_Empresabairro
		{
			get { 
				return sdt.gxTpr_Empresabairro;

			}
			set { 
				 sdt.gxTpr_Empresabairro = value;
			}
		}

		[JsonPropertyName("EmpresaComplemento")]
		[JsonPropertyOrder(9)]
		[DataMember(Name="EmpresaComplemento", Order=9)]
		public  string gxTpr_Empresacomplemento
		{
			get { 
				return sdt.gxTpr_Empresacomplemento;

			}
			set { 
				 sdt.gxTpr_Empresacomplemento = value;
			}
		}

		[JsonPropertyName("MunicipioCodigo")]
		[JsonPropertyOrder(10)]
		[DataMember(Name="MunicipioCodigo", Order=10)]
		public  string gxTpr_Municipiocodigo
		{
			get { 
				return sdt.gxTpr_Municipiocodigo;

			}
			set { 
				 sdt.gxTpr_Municipiocodigo = value;
			}
		}

		[JsonPropertyName("MunicipioNome")]
		[JsonPropertyOrder(11)]
		[DataMember(Name="MunicipioNome", Order=11)]
		public  string gxTpr_Municipionome
		{
			get { 
				return sdt.gxTpr_Municipionome;

			}
			set { 
				 sdt.gxTpr_Municipionome = value;
			}
		}

		[JsonPropertyName("MunicipioUF")]
		[JsonPropertyOrder(12)]
		[DataMember(Name="MunicipioUF", Order=12)]
		public  string gxTpr_Municipiouf
		{
			get { 
				return sdt.gxTpr_Municipiouf;

			}
			set { 
				 sdt.gxTpr_Municipiouf = value;
			}
		}

		[JsonPropertyName("EmpresaBancoId")]
		[JsonPropertyOrder(13)]
		[DataMember(Name="EmpresaBancoId", Order=13)]
		public  string gxTpr_Empresabancoid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Empresabancoid, 9, 0));

			}
			set { 
				sdt.gxTpr_Empresabancoid = (int) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("EmpresaAgencia")]
		[JsonPropertyOrder(14)]
		[DataMember(Name="EmpresaAgencia", Order=14)]
		public  string gxTpr_Empresaagencia
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Empresaagencia, 9, 0));

			}
			set { 
				sdt.gxTpr_Empresaagencia = (int) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("EmpresaAgenciaDigito")]
		[JsonPropertyOrder(15)]
		[DataMember(Name="EmpresaAgenciaDigito", Order=15)]
		public  string gxTpr_Empresaagenciadigito
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Empresaagenciadigito, 9, 0));

			}
			set { 
				sdt.gxTpr_Empresaagenciadigito = (int) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("EmpresaConta")]
		[JsonPropertyOrder(16)]
		[DataMember(Name="EmpresaConta", Order=16)]
		public  string gxTpr_Empresaconta
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Empresaconta, 8, 0));

			}
			set { 
				sdt.gxTpr_Empresaconta = (int) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("EmpresaPixTipo")]
		[JsonPropertyOrder(17)]
		[DataMember(Name="EmpresaPixTipo", Order=17)]
		public  string gxTpr_Empresapixtipo
		{
			get { 
				return sdt.gxTpr_Empresapixtipo;

			}
			set { 
				 sdt.gxTpr_Empresapixtipo = value;
			}
		}

		[JsonPropertyName("EmpresaPix")]
		[JsonPropertyOrder(18)]
		[DataMember(Name="EmpresaPix", Order=18)]
		public  string gxTpr_Empresapix
		{
			get { 
				return sdt.gxTpr_Empresapix;

			}
			set { 
				 sdt.gxTpr_Empresapix = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtIniciarSistemaData_Empresa sdt
		{
			get { 
				return (SdtIniciarSistemaData_Empresa)Sdt;
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
				sdt = new SdtIniciarSistemaData_Empresa() ;
			}
		}
	}
	#endregion
}