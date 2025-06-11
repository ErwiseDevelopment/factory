/*
				   File: type_SdtSdSerasa_protestos
			Description: protestos
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
	[XmlRoot(ElementName="SdSerasa.protestos")]
	[XmlType(TypeName="SdSerasa.protestos" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdSerasa_protestos : GxUserType
	{
		public SdtSdSerasa_protestos( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdSerasa_protestos_Dataultimaocorrenciaprotesto = "";

		}

		public SdtSdSerasa_protestos(IGxContext context)
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
			AddObjectProperty("quantidadeTotalProtesto", gxTpr_Quantidadetotalprotesto, false);


			AddObjectProperty("valorTotalProtesto", gxTpr_Valortotalprotesto, false);


			AddObjectProperty("dataUltimaOcorrenciaProtesto", gxTpr_Dataultimaocorrenciaprotesto, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="quantidadeTotalProtesto")]
		[XmlElement(ElementName="quantidadeTotalProtesto")]
		public string gxTpr_Quantidadetotalprotesto_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdSerasa_protestos_Quantidadetotalprotesto, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdSerasa_protestos_Quantidadetotalprotesto = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Quantidadetotalprotesto
		{
			get {
				return gxTv_SdtSdSerasa_protestos_Quantidadetotalprotesto; 
			}
			set {
				gxTv_SdtSdSerasa_protestos_Quantidadetotalprotesto = value;
				SetDirty("Quantidadetotalprotesto");
			}
		}



		[SoapElement(ElementName="valorTotalProtesto")]
		[XmlElement(ElementName="valorTotalProtesto")]
		public string gxTpr_Valortotalprotesto_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdSerasa_protestos_Valortotalprotesto, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdSerasa_protestos_Valortotalprotesto = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Valortotalprotesto
		{
			get {
				return gxTv_SdtSdSerasa_protestos_Valortotalprotesto; 
			}
			set {
				gxTv_SdtSdSerasa_protestos_Valortotalprotesto = value;
				SetDirty("Valortotalprotesto");
			}
		}




		[SoapElement(ElementName="dataUltimaOcorrenciaProtesto")]
		[XmlElement(ElementName="dataUltimaOcorrenciaProtesto")]
		public string gxTpr_Dataultimaocorrenciaprotesto
		{
			get {
				return gxTv_SdtSdSerasa_protestos_Dataultimaocorrenciaprotesto; 
			}
			set {
				gxTv_SdtSdSerasa_protestos_Dataultimaocorrenciaprotesto = value;
				SetDirty("Dataultimaocorrenciaprotesto");
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
			gxTv_SdtSdSerasa_protestos_Dataultimaocorrenciaprotesto = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected decimal gxTv_SdtSdSerasa_protestos_Quantidadetotalprotesto;
		 

		protected decimal gxTv_SdtSdSerasa_protestos_Valortotalprotesto;
		 

		protected string gxTv_SdtSdSerasa_protestos_Dataultimaocorrenciaprotesto;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdSerasa.protestos", Namespace="Factory21")]
	public class SdtSdSerasa_protestos_RESTInterface : GxGenericCollectionItem<SdtSdSerasa_protestos>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdSerasa_protestos_RESTInterface( ) : base()
		{	
		}

		public SdtSdSerasa_protestos_RESTInterface( SdtSdSerasa_protestos psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("quantidadeTotalProtesto")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="quantidadeTotalProtesto", Order=0)]
		public  string gxTpr_Quantidadetotalprotesto
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Quantidadetotalprotesto, 10, 5));

			}
			set { 
				sdt.gxTpr_Quantidadetotalprotesto =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("valorTotalProtesto")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="valorTotalProtesto", Order=1)]
		public  string gxTpr_Valortotalprotesto
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Valortotalprotesto, 10, 5));

			}
			set { 
				sdt.gxTpr_Valortotalprotesto =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("dataUltimaOcorrenciaProtesto")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="dataUltimaOcorrenciaProtesto", Order=2)]
		public  string gxTpr_Dataultimaocorrenciaprotesto
		{
			get { 
				return sdt.gxTpr_Dataultimaocorrenciaprotesto;

			}
			set { 
				 sdt.gxTpr_Dataultimaocorrenciaprotesto = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdSerasa_protestos sdt
		{
			get { 
				return (SdtSdSerasa_protestos)Sdt;
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
				sdt = new SdtSdSerasa_protestos() ;
			}
		}
	}
	#endregion
}