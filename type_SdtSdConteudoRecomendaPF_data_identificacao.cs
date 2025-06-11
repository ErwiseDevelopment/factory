/*
				   File: type_SdtSdConteudoRecomendaPF_data_identificacao
			Description: identificacao
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
	[XmlRoot(ElementName="SdConteudoRecomendaPF.data.identificacao")]
	[XmlType(TypeName="SdConteudoRecomendaPF.data.identificacao" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdConteudoRecomendaPF_data_identificacao : GxUserType
	{
		public SdtSdConteudoRecomendaPF_data_identificacao( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdConteudoRecomendaPF_data_identificacao_Cpf = "";

			gxTv_SdtSdConteudoRecomendaPF_data_identificacao_Situacaocpf = "";

			gxTv_SdtSdConteudoRecomendaPF_data_identificacao_Datanascimento = (DateTime)(DateTime.MinValue);

			gxTv_SdtSdConteudoRecomendaPF_data_identificacao_Genero = "";

			gxTv_SdtSdConteudoRecomendaPF_data_identificacao_Nomemae = "";

			gxTv_SdtSdConteudoRecomendaPF_data_identificacao_Grafia = "";

		}

		public SdtSdConteudoRecomendaPF_data_identificacao(IGxContext context)
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


			AddObjectProperty("situacaoCPF", gxTpr_Situacaocpf, false);


			datetime_STZ = gxTpr_Datanascimento;
			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim( StringUtil.Str((decimal)(DateTimeUtil.Month(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "T";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Hour(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Minute(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Second(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("dataNascimento", sDateCnv, false);



			AddObjectProperty("genero", gxTpr_Genero, false);


			AddObjectProperty("nomeMae", gxTpr_Nomemae, false);


			AddObjectProperty("grafia", gxTpr_Grafia, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="cpf")]
		[XmlElement(ElementName="cpf")]
		public string gxTpr_Cpf
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_identificacao_Cpf; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_identificacao_Cpf = value;
				SetDirty("Cpf");
			}
		}




		[SoapElement(ElementName="situacaoCPF")]
		[XmlElement(ElementName="situacaoCPF")]
		public string gxTpr_Situacaocpf
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_identificacao_Situacaocpf; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_identificacao_Situacaocpf = value;
				SetDirty("Situacaocpf");
			}
		}



		[SoapElement(ElementName="dataNascimento")]
		[XmlElement(ElementName="dataNascimento" , IsNullable=true)]
		public string gxTpr_Datanascimento_Nullable
		{
			get {
				if ( gxTv_SdtSdConteudoRecomendaPF_data_identificacao_Datanascimento == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSdConteudoRecomendaPF_data_identificacao_Datanascimento).value ;
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_identificacao_Datanascimento = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Datanascimento
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_identificacao_Datanascimento; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_identificacao_Datanascimento = value;
				SetDirty("Datanascimento");
			}
		}



		[SoapElement(ElementName="genero")]
		[XmlElement(ElementName="genero")]
		public string gxTpr_Genero
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_identificacao_Genero; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_identificacao_Genero = value;
				SetDirty("Genero");
			}
		}




		[SoapElement(ElementName="nomeMae")]
		[XmlElement(ElementName="nomeMae")]
		public string gxTpr_Nomemae
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_identificacao_Nomemae; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_identificacao_Nomemae = value;
				SetDirty("Nomemae");
			}
		}




		[SoapElement(ElementName="grafia")]
		[XmlElement(ElementName="grafia")]
		public string gxTpr_Grafia
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_identificacao_Grafia; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_identificacao_Grafia = value;
				SetDirty("Grafia");
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
			gxTv_SdtSdConteudoRecomendaPF_data_identificacao_Cpf = "";
			gxTv_SdtSdConteudoRecomendaPF_data_identificacao_Situacaocpf = "";
			gxTv_SdtSdConteudoRecomendaPF_data_identificacao_Datanascimento = (DateTime)(DateTime.MinValue);
			gxTv_SdtSdConteudoRecomendaPF_data_identificacao_Genero = "";
			gxTv_SdtSdConteudoRecomendaPF_data_identificacao_Nomemae = "";
			gxTv_SdtSdConteudoRecomendaPF_data_identificacao_Grafia = "";
			datetime_STZ = (DateTime)(DateTime.MinValue);
			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected DateTime datetime_STZ ;

		protected string gxTv_SdtSdConteudoRecomendaPF_data_identificacao_Cpf;
		 

		protected string gxTv_SdtSdConteudoRecomendaPF_data_identificacao_Situacaocpf;
		 

		protected DateTime gxTv_SdtSdConteudoRecomendaPF_data_identificacao_Datanascimento;
		 

		protected string gxTv_SdtSdConteudoRecomendaPF_data_identificacao_Genero;
		 

		protected string gxTv_SdtSdConteudoRecomendaPF_data_identificacao_Nomemae;
		 

		protected string gxTv_SdtSdConteudoRecomendaPF_data_identificacao_Grafia;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdConteudoRecomendaPF.data.identificacao", Namespace="Factory21")]
	public class SdtSdConteudoRecomendaPF_data_identificacao_RESTInterface : GxGenericCollectionItem<SdtSdConteudoRecomendaPF_data_identificacao>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdConteudoRecomendaPF_data_identificacao_RESTInterface( ) : base()
		{	
		}

		public SdtSdConteudoRecomendaPF_data_identificacao_RESTInterface( SdtSdConteudoRecomendaPF_data_identificacao psdt ) : base(psdt)
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

		[JsonPropertyName("situacaoCPF")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="situacaoCPF", Order=1)]
		public  string gxTpr_Situacaocpf
		{
			get { 
				return sdt.gxTpr_Situacaocpf;

			}
			set { 
				 sdt.gxTpr_Situacaocpf = value;
			}
		}

		[JsonPropertyName("dataNascimento")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="dataNascimento", Order=2)]
		public  string gxTpr_Datanascimento
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Datanascimento,context);

			}
			set { 
				sdt.gxTpr_Datanascimento = DateTimeUtil.CToT2(value,context);
			}
		}

		[JsonPropertyName("genero")]
		[JsonPropertyOrder(3)]
		[DataMember(Name="genero", Order=3)]
		public  string gxTpr_Genero
		{
			get { 
				return sdt.gxTpr_Genero;

			}
			set { 
				 sdt.gxTpr_Genero = value;
			}
		}

		[JsonPropertyName("nomeMae")]
		[JsonPropertyOrder(4)]
		[DataMember(Name="nomeMae", Order=4)]
		public  string gxTpr_Nomemae
		{
			get { 
				return sdt.gxTpr_Nomemae;

			}
			set { 
				 sdt.gxTpr_Nomemae = value;
			}
		}

		[JsonPropertyName("grafia")]
		[JsonPropertyOrder(5)]
		[DataMember(Name="grafia", Order=5)]
		public  string gxTpr_Grafia
		{
			get { 
				return sdt.gxTpr_Grafia;

			}
			set { 
				 sdt.gxTpr_Grafia = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdConteudoRecomendaPF_data_identificacao sdt
		{
			get { 
				return (SdtSdConteudoRecomendaPF_data_identificacao)Sdt;
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
				sdt = new SdtSdConteudoRecomendaPF_data_identificacao() ;
			}
		}
	}
	#endregion
}