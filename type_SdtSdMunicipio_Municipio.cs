/*
				   File: type_SdtSdMunicipio_Municipio
			Description: SdMunicipio
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
	[XmlRoot(ElementName="Municipio")]
	[XmlType(TypeName="Municipio" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdMunicipio_Municipio : GxUserType
	{
		public SdtSdMunicipio_Municipio( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdMunicipio_Municipio_Municipionome = "";

			gxTv_SdtSdMunicipio_Municipio_Municipiocodigo = "";

			gxTv_SdtSdMunicipio_Municipio_Municipioddd = "";

			gxTv_SdtSdMunicipio_Municipio_Municipiouf = "";

		}

		public SdtSdMunicipio_Municipio(IGxContext context)
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
			AddObjectProperty("MunicipioNome", gxTpr_Municipionome, false);


			AddObjectProperty("MunicipioCodigo", gxTpr_Municipiocodigo, false);


			AddObjectProperty("MunicipioDDD", gxTpr_Municipioddd, false);


			AddObjectProperty("MunicipioUF", gxTpr_Municipiouf, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="MunicipioNome")]
		[XmlElement(ElementName="MunicipioNome")]
		public string gxTpr_Municipionome
		{
			get {
				return gxTv_SdtSdMunicipio_Municipio_Municipionome; 
			}
			set {
				gxTv_SdtSdMunicipio_Municipio_Municipionome = value;
				SetDirty("Municipionome");
			}
		}




		[SoapElement(ElementName="MunicipioCodigo")]
		[XmlElement(ElementName="MunicipioCodigo")]
		public string gxTpr_Municipiocodigo
		{
			get {
				return gxTv_SdtSdMunicipio_Municipio_Municipiocodigo; 
			}
			set {
				gxTv_SdtSdMunicipio_Municipio_Municipiocodigo = value;
				SetDirty("Municipiocodigo");
			}
		}




		[SoapElement(ElementName="MunicipioDDD")]
		[XmlElement(ElementName="MunicipioDDD")]
		public string gxTpr_Municipioddd
		{
			get {
				return gxTv_SdtSdMunicipio_Municipio_Municipioddd; 
			}
			set {
				gxTv_SdtSdMunicipio_Municipio_Municipioddd = value;
				SetDirty("Municipioddd");
			}
		}




		[SoapElement(ElementName="MunicipioUF")]
		[XmlElement(ElementName="MunicipioUF")]
		public string gxTpr_Municipiouf
		{
			get {
				return gxTv_SdtSdMunicipio_Municipio_Municipiouf; 
			}
			set {
				gxTv_SdtSdMunicipio_Municipio_Municipiouf = value;
				SetDirty("Municipiouf");
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
			gxTv_SdtSdMunicipio_Municipio_Municipionome = "";
			gxTv_SdtSdMunicipio_Municipio_Municipiocodigo = "";
			gxTv_SdtSdMunicipio_Municipio_Municipioddd = "";
			gxTv_SdtSdMunicipio_Municipio_Municipiouf = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSdMunicipio_Municipio_Municipionome;
		 

		protected string gxTv_SdtSdMunicipio_Municipio_Municipiocodigo;
		 

		protected string gxTv_SdtSdMunicipio_Municipio_Municipioddd;
		 

		protected string gxTv_SdtSdMunicipio_Municipio_Municipiouf;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"Municipio", Namespace="Factory21")]
	public class SdtSdMunicipio_Municipio_RESTInterface : GxGenericCollectionItem<SdtSdMunicipio_Municipio>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdMunicipio_Municipio_RESTInterface( ) : base()
		{	
		}

		public SdtSdMunicipio_Municipio_RESTInterface( SdtSdMunicipio_Municipio psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("MunicipioNome")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="MunicipioNome", Order=0)]
		public  string gxTpr_Municipionome
		{
			get { 
				return sdt.gxTpr_Municipionome;

			}
			set { 
				 sdt.gxTpr_Municipionome = value;
			}
		}

		[JsonPropertyName("MunicipioCodigo")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="MunicipioCodigo", Order=1)]
		public  string gxTpr_Municipiocodigo
		{
			get { 
				return sdt.gxTpr_Municipiocodigo;

			}
			set { 
				 sdt.gxTpr_Municipiocodigo = value;
			}
		}

		[JsonPropertyName("MunicipioDDD")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="MunicipioDDD", Order=2)]
		public  string gxTpr_Municipioddd
		{
			get { 
				return sdt.gxTpr_Municipioddd;

			}
			set { 
				 sdt.gxTpr_Municipioddd = value;
			}
		}

		[JsonPropertyName("MunicipioUF")]
		[JsonPropertyOrder(3)]
		[DataMember(Name="MunicipioUF", Order=3)]
		public  string gxTpr_Municipiouf
		{
			get { 
				return sdt.gxTpr_Municipiouf;

			}
			set { 
				 sdt.gxTpr_Municipiouf = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdMunicipio_Municipio sdt
		{
			get { 
				return (SdtSdMunicipio_Municipio)Sdt;
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
				sdt = new SdtSdMunicipio_Municipio() ;
			}
		}
	}
	#endregion
}