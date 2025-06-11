/*
				   File: type_SdtSdSerasa_falencias
			Description: falencias
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
	[XmlRoot(ElementName="SdSerasa.falencias")]
	[XmlType(TypeName="SdSerasa.falencias" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdSerasa_falencias : GxUserType
	{
		public SdtSdSerasa_falencias( )
		{
			/* Constructor for serialization */
		}

		public SdtSdSerasa_falencias(IGxContext context)
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
			AddObjectProperty("quantidadeTotalFalencia", gxTpr_Quantidadetotalfalencia, false);


			AddObjectProperty("valorTotalFalencia", gxTpr_Valortotalfalencia, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="quantidadeTotalFalencia")]
		[XmlElement(ElementName="quantidadeTotalFalencia")]
		public string gxTpr_Quantidadetotalfalencia_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdSerasa_falencias_Quantidadetotalfalencia, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdSerasa_falencias_Quantidadetotalfalencia = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Quantidadetotalfalencia
		{
			get {
				return gxTv_SdtSdSerasa_falencias_Quantidadetotalfalencia; 
			}
			set {
				gxTv_SdtSdSerasa_falencias_Quantidadetotalfalencia = value;
				SetDirty("Quantidadetotalfalencia");
			}
		}



		[SoapElement(ElementName="valorTotalFalencia")]
		[XmlElement(ElementName="valorTotalFalencia")]
		public string gxTpr_Valortotalfalencia_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdSerasa_falencias_Valortotalfalencia, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdSerasa_falencias_Valortotalfalencia = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Valortotalfalencia
		{
			get {
				return gxTv_SdtSdSerasa_falencias_Valortotalfalencia; 
			}
			set {
				gxTv_SdtSdSerasa_falencias_Valortotalfalencia = value;
				SetDirty("Valortotalfalencia");
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
			return  ;
		}



		#endregion

		#region Declaration

		protected decimal gxTv_SdtSdSerasa_falencias_Quantidadetotalfalencia;
		 

		protected decimal gxTv_SdtSdSerasa_falencias_Valortotalfalencia;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdSerasa.falencias", Namespace="Factory21")]
	public class SdtSdSerasa_falencias_RESTInterface : GxGenericCollectionItem<SdtSdSerasa_falencias>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdSerasa_falencias_RESTInterface( ) : base()
		{	
		}

		public SdtSdSerasa_falencias_RESTInterface( SdtSdSerasa_falencias psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("quantidadeTotalFalencia")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="quantidadeTotalFalencia", Order=0)]
		public  string gxTpr_Quantidadetotalfalencia
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Quantidadetotalfalencia, 10, 5));

			}
			set { 
				sdt.gxTpr_Quantidadetotalfalencia =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("valorTotalFalencia")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="valorTotalFalencia", Order=1)]
		public  string gxTpr_Valortotalfalencia
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Valortotalfalencia, 10, 5));

			}
			set { 
				sdt.gxTpr_Valortotalfalencia =  NumberUtil.Val( value, ".");
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdSerasa_falencias sdt
		{
			get { 
				return (SdtSdSerasa_falencias)Sdt;
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
				sdt = new SdtSdSerasa_falencias() ;
			}
		}
	}
	#endregion
}