/*
				   File: type_SdtSdBanco_Banco
			Description: SdBanco
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
	[XmlRoot(ElementName="Banco")]
	[XmlType(TypeName="Banco" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdBanco_Banco : GxUserType
	{
		public SdtSdBanco_Banco( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdBanco_Banco_Banconome = "";

		}

		public SdtSdBanco_Banco(IGxContext context)
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
			AddObjectProperty("BancoCodigo", gxTpr_Bancocodigo, false);


			AddObjectProperty("BancoNome", gxTpr_Banconome, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="BancoCodigo")]
		[XmlElement(ElementName="BancoCodigo")]
		public int gxTpr_Bancocodigo
		{
			get {
				return gxTv_SdtSdBanco_Banco_Bancocodigo; 
			}
			set {
				gxTv_SdtSdBanco_Banco_Bancocodigo = value;
				SetDirty("Bancocodigo");
			}
		}




		[SoapElement(ElementName="BancoNome")]
		[XmlElement(ElementName="BancoNome")]
		public string gxTpr_Banconome
		{
			get {
				return gxTv_SdtSdBanco_Banco_Banconome; 
			}
			set {
				gxTv_SdtSdBanco_Banco_Banconome = value;
				SetDirty("Banconome");
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
			gxTv_SdtSdBanco_Banco_Banconome = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected int gxTv_SdtSdBanco_Banco_Bancocodigo;
		 

		protected string gxTv_SdtSdBanco_Banco_Banconome;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"Banco", Namespace="Factory21")]
	public class SdtSdBanco_Banco_RESTInterface : GxGenericCollectionItem<SdtSdBanco_Banco>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdBanco_Banco_RESTInterface( ) : base()
		{	
		}

		public SdtSdBanco_Banco_RESTInterface( SdtSdBanco_Banco psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("BancoCodigo")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="BancoCodigo", Order=0)]
		public  string gxTpr_Bancocodigo
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Bancocodigo, 9, 0));

			}
			set { 
				sdt.gxTpr_Bancocodigo = (int) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("BancoNome")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="BancoNome", Order=1)]
		public  string gxTpr_Banconome
		{
			get { 
				return sdt.gxTpr_Banconome;

			}
			set { 
				 sdt.gxTpr_Banconome = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdBanco_Banco sdt
		{
			get { 
				return (SdtSdBanco_Banco)Sdt;
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
				sdt = new SdtSdBanco_Banco() ;
			}
		}
	}
	#endregion
}