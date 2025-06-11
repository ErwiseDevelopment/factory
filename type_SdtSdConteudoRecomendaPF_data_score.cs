/*
				   File: type_SdtSdConteudoRecomendaPF_data_score
			Description: score
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
	[XmlRoot(ElementName="SdConteudoRecomendaPF.data.score")]
	[XmlType(TypeName="SdConteudoRecomendaPF.data.score" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdConteudoRecomendaPF_data_score : GxUserType
	{
		public SdtSdConteudoRecomendaPF_data_score( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdConteudoRecomendaPF_data_score_Serasascore = "";

			gxTv_SdtSdConteudoRecomendaPF_data_score_Taxa = "";

		}

		public SdtSdConteudoRecomendaPF_data_score(IGxContext context)
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
			AddObjectProperty("serasaScore", gxTpr_Serasascore, false);


			AddObjectProperty("taxa", gxTpr_Taxa, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="serasaScore")]
		[XmlElement(ElementName="serasaScore")]
		public string gxTpr_Serasascore
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_score_Serasascore; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_score_Serasascore = value;
				SetDirty("Serasascore");
			}
		}




		[SoapElement(ElementName="taxa")]
		[XmlElement(ElementName="taxa")]
		public string gxTpr_Taxa
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_score_Taxa; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_score_Taxa = value;
				SetDirty("Taxa");
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
			gxTv_SdtSdConteudoRecomendaPF_data_score_Serasascore = "";
			gxTv_SdtSdConteudoRecomendaPF_data_score_Taxa = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSdConteudoRecomendaPF_data_score_Serasascore;
		 

		protected string gxTv_SdtSdConteudoRecomendaPF_data_score_Taxa;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdConteudoRecomendaPF.data.score", Namespace="Factory21")]
	public class SdtSdConteudoRecomendaPF_data_score_RESTInterface : GxGenericCollectionItem<SdtSdConteudoRecomendaPF_data_score>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdConteudoRecomendaPF_data_score_RESTInterface( ) : base()
		{	
		}

		public SdtSdConteudoRecomendaPF_data_score_RESTInterface( SdtSdConteudoRecomendaPF_data_score psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("serasaScore")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="serasaScore", Order=0)]
		public  string gxTpr_Serasascore
		{
			get { 
				return sdt.gxTpr_Serasascore;

			}
			set { 
				 sdt.gxTpr_Serasascore = value;
			}
		}

		[JsonPropertyName("taxa")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="taxa", Order=1)]
		public  string gxTpr_Taxa
		{
			get { 
				return sdt.gxTpr_Taxa;

			}
			set { 
				 sdt.gxTpr_Taxa = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdConteudoRecomendaPF_data_score sdt
		{
			get { 
				return (SdtSdConteudoRecomendaPF_data_score)Sdt;
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
				sdt = new SdtSdConteudoRecomendaPF_data_score() ;
			}
		}
	}
	#endregion
}