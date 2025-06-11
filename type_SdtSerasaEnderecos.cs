using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   [XmlRoot(ElementName = "SerasaEnderecos" )]
   [XmlType(TypeName =  "SerasaEnderecos" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtSerasaEnderecos : GxSilentTrnSdt
   {
      public SdtSerasaEnderecos( )
      {
      }

      public SdtSerasaEnderecos( IGxContext context )
      {
         this.context = context;
         constructorCallingAssembly = Assembly.GetEntryAssembly();
         initialize();
      }

      private static Hashtable mapper;
      public override string JsonMap( string value )
      {
         if ( mapper == null )
         {
            mapper = new Hashtable();
         }
         return (string)mapper[value]; ;
      }

      public void Load( int AV716SerasaEnderecosId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV716SerasaEnderecosId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"SerasaEnderecosId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "SerasaEnderecos");
         metadata.Set("BT", "SerasaEnderecos");
         metadata.Set("PK", "[ \"SerasaEnderecosId\" ]");
         metadata.Set("PKAssigned", "[ \"SerasaEnderecosId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"SerasaId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Serasaenderecosid_Z");
         state.Add("gxTpr_Serasaid_Z");
         state.Add("gxTpr_Serasaenderecoslogr_Z");
         state.Add("gxTpr_Serasaenderecosnum_Z");
         state.Add("gxTpr_Serasaenderecoscompl_Z");
         state.Add("gxTpr_Serasaenderecosbairro_Z");
         state.Add("gxTpr_Serasaenderecoscidade_Z");
         state.Add("gxTpr_Serasaenderecosestado_Z");
         state.Add("gxTpr_Serasaenderecoscep_Z");
         state.Add("gxTpr_Serasaenderecostelddd_Z");
         state.Add("gxTpr_Serasaenderecostel_Z");
         state.Add("gxTpr_Serasaid_N");
         state.Add("gxTpr_Serasaenderecoslogr_N");
         state.Add("gxTpr_Serasaenderecosnum_N");
         state.Add("gxTpr_Serasaenderecoscompl_N");
         state.Add("gxTpr_Serasaenderecosbairro_N");
         state.Add("gxTpr_Serasaenderecoscidade_N");
         state.Add("gxTpr_Serasaenderecosestado_N");
         state.Add("gxTpr_Serasaenderecoscep_N");
         state.Add("gxTpr_Serasaenderecostelddd_N");
         state.Add("gxTpr_Serasaenderecostel_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtSerasaEnderecos sdt;
         sdt = (SdtSerasaEnderecos)(source);
         gxTv_SdtSerasaEnderecos_Serasaenderecosid = sdt.gxTv_SdtSerasaEnderecos_Serasaenderecosid ;
         gxTv_SdtSerasaEnderecos_Serasaid = sdt.gxTv_SdtSerasaEnderecos_Serasaid ;
         gxTv_SdtSerasaEnderecos_Serasaenderecoslogr = sdt.gxTv_SdtSerasaEnderecos_Serasaenderecoslogr ;
         gxTv_SdtSerasaEnderecos_Serasaenderecosnum = sdt.gxTv_SdtSerasaEnderecos_Serasaenderecosnum ;
         gxTv_SdtSerasaEnderecos_Serasaenderecoscompl = sdt.gxTv_SdtSerasaEnderecos_Serasaenderecoscompl ;
         gxTv_SdtSerasaEnderecos_Serasaenderecosbairro = sdt.gxTv_SdtSerasaEnderecos_Serasaenderecosbairro ;
         gxTv_SdtSerasaEnderecos_Serasaenderecoscidade = sdt.gxTv_SdtSerasaEnderecos_Serasaenderecoscidade ;
         gxTv_SdtSerasaEnderecos_Serasaenderecosestado = sdt.gxTv_SdtSerasaEnderecos_Serasaenderecosestado ;
         gxTv_SdtSerasaEnderecos_Serasaenderecoscep = sdt.gxTv_SdtSerasaEnderecos_Serasaenderecoscep ;
         gxTv_SdtSerasaEnderecos_Serasaenderecostelddd = sdt.gxTv_SdtSerasaEnderecos_Serasaenderecostelddd ;
         gxTv_SdtSerasaEnderecos_Serasaenderecostel = sdt.gxTv_SdtSerasaEnderecos_Serasaenderecostel ;
         gxTv_SdtSerasaEnderecos_Mode = sdt.gxTv_SdtSerasaEnderecos_Mode ;
         gxTv_SdtSerasaEnderecos_Initialized = sdt.gxTv_SdtSerasaEnderecos_Initialized ;
         gxTv_SdtSerasaEnderecos_Serasaenderecosid_Z = sdt.gxTv_SdtSerasaEnderecos_Serasaenderecosid_Z ;
         gxTv_SdtSerasaEnderecos_Serasaid_Z = sdt.gxTv_SdtSerasaEnderecos_Serasaid_Z ;
         gxTv_SdtSerasaEnderecos_Serasaenderecoslogr_Z = sdt.gxTv_SdtSerasaEnderecos_Serasaenderecoslogr_Z ;
         gxTv_SdtSerasaEnderecos_Serasaenderecosnum_Z = sdt.gxTv_SdtSerasaEnderecos_Serasaenderecosnum_Z ;
         gxTv_SdtSerasaEnderecos_Serasaenderecoscompl_Z = sdt.gxTv_SdtSerasaEnderecos_Serasaenderecoscompl_Z ;
         gxTv_SdtSerasaEnderecos_Serasaenderecosbairro_Z = sdt.gxTv_SdtSerasaEnderecos_Serasaenderecosbairro_Z ;
         gxTv_SdtSerasaEnderecos_Serasaenderecoscidade_Z = sdt.gxTv_SdtSerasaEnderecos_Serasaenderecoscidade_Z ;
         gxTv_SdtSerasaEnderecos_Serasaenderecosestado_Z = sdt.gxTv_SdtSerasaEnderecos_Serasaenderecosestado_Z ;
         gxTv_SdtSerasaEnderecos_Serasaenderecoscep_Z = sdt.gxTv_SdtSerasaEnderecos_Serasaenderecoscep_Z ;
         gxTv_SdtSerasaEnderecos_Serasaenderecostelddd_Z = sdt.gxTv_SdtSerasaEnderecos_Serasaenderecostelddd_Z ;
         gxTv_SdtSerasaEnderecos_Serasaenderecostel_Z = sdt.gxTv_SdtSerasaEnderecos_Serasaenderecostel_Z ;
         gxTv_SdtSerasaEnderecos_Serasaid_N = sdt.gxTv_SdtSerasaEnderecos_Serasaid_N ;
         gxTv_SdtSerasaEnderecos_Serasaenderecoslogr_N = sdt.gxTv_SdtSerasaEnderecos_Serasaenderecoslogr_N ;
         gxTv_SdtSerasaEnderecos_Serasaenderecosnum_N = sdt.gxTv_SdtSerasaEnderecos_Serasaenderecosnum_N ;
         gxTv_SdtSerasaEnderecos_Serasaenderecoscompl_N = sdt.gxTv_SdtSerasaEnderecos_Serasaenderecoscompl_N ;
         gxTv_SdtSerasaEnderecos_Serasaenderecosbairro_N = sdt.gxTv_SdtSerasaEnderecos_Serasaenderecosbairro_N ;
         gxTv_SdtSerasaEnderecos_Serasaenderecoscidade_N = sdt.gxTv_SdtSerasaEnderecos_Serasaenderecoscidade_N ;
         gxTv_SdtSerasaEnderecos_Serasaenderecosestado_N = sdt.gxTv_SdtSerasaEnderecos_Serasaenderecosestado_N ;
         gxTv_SdtSerasaEnderecos_Serasaenderecoscep_N = sdt.gxTv_SdtSerasaEnderecos_Serasaenderecoscep_N ;
         gxTv_SdtSerasaEnderecos_Serasaenderecostelddd_N = sdt.gxTv_SdtSerasaEnderecos_Serasaenderecostelddd_N ;
         gxTv_SdtSerasaEnderecos_Serasaenderecostel_N = sdt.gxTv_SdtSerasaEnderecos_Serasaenderecostel_N ;
         return  ;
      }

      public override void ToJSON( )
      {
         ToJSON( true) ;
         return  ;
      }

      public override void ToJSON( bool includeState )
      {
         ToJSON( includeState, true) ;
         return  ;
      }

      public override void ToJSON( bool includeState ,
                                   bool includeNonInitialized )
      {
         AddObjectProperty("SerasaEnderecosId", gxTv_SdtSerasaEnderecos_Serasaenderecosid, false, includeNonInitialized);
         AddObjectProperty("SerasaId", gxTv_SdtSerasaEnderecos_Serasaid, false, includeNonInitialized);
         AddObjectProperty("SerasaId_N", gxTv_SdtSerasaEnderecos_Serasaid_N, false, includeNonInitialized);
         AddObjectProperty("SerasaEnderecosLogr", gxTv_SdtSerasaEnderecos_Serasaenderecoslogr, false, includeNonInitialized);
         AddObjectProperty("SerasaEnderecosLogr_N", gxTv_SdtSerasaEnderecos_Serasaenderecoslogr_N, false, includeNonInitialized);
         AddObjectProperty("SerasaEnderecosNum", gxTv_SdtSerasaEnderecos_Serasaenderecosnum, false, includeNonInitialized);
         AddObjectProperty("SerasaEnderecosNum_N", gxTv_SdtSerasaEnderecos_Serasaenderecosnum_N, false, includeNonInitialized);
         AddObjectProperty("SerasaEnderecosCompl", gxTv_SdtSerasaEnderecos_Serasaenderecoscompl, false, includeNonInitialized);
         AddObjectProperty("SerasaEnderecosCompl_N", gxTv_SdtSerasaEnderecos_Serasaenderecoscompl_N, false, includeNonInitialized);
         AddObjectProperty("SerasaEnderecosBairro", gxTv_SdtSerasaEnderecos_Serasaenderecosbairro, false, includeNonInitialized);
         AddObjectProperty("SerasaEnderecosBairro_N", gxTv_SdtSerasaEnderecos_Serasaenderecosbairro_N, false, includeNonInitialized);
         AddObjectProperty("SerasaEnderecosCidade", gxTv_SdtSerasaEnderecos_Serasaenderecoscidade, false, includeNonInitialized);
         AddObjectProperty("SerasaEnderecosCidade_N", gxTv_SdtSerasaEnderecos_Serasaenderecoscidade_N, false, includeNonInitialized);
         AddObjectProperty("SerasaEnderecosEstado", gxTv_SdtSerasaEnderecos_Serasaenderecosestado, false, includeNonInitialized);
         AddObjectProperty("SerasaEnderecosEstado_N", gxTv_SdtSerasaEnderecos_Serasaenderecosestado_N, false, includeNonInitialized);
         AddObjectProperty("SerasaEnderecosCEP", gxTv_SdtSerasaEnderecos_Serasaenderecoscep, false, includeNonInitialized);
         AddObjectProperty("SerasaEnderecosCEP_N", gxTv_SdtSerasaEnderecos_Serasaenderecoscep_N, false, includeNonInitialized);
         AddObjectProperty("SerasaEnderecosTelDDD", gxTv_SdtSerasaEnderecos_Serasaenderecostelddd, false, includeNonInitialized);
         AddObjectProperty("SerasaEnderecosTelDDD_N", gxTv_SdtSerasaEnderecos_Serasaenderecostelddd_N, false, includeNonInitialized);
         AddObjectProperty("SerasaEnderecosTel", gxTv_SdtSerasaEnderecos_Serasaenderecostel, false, includeNonInitialized);
         AddObjectProperty("SerasaEnderecosTel_N", gxTv_SdtSerasaEnderecos_Serasaenderecostel_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtSerasaEnderecos_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtSerasaEnderecos_Initialized, false, includeNonInitialized);
            AddObjectProperty("SerasaEnderecosId_Z", gxTv_SdtSerasaEnderecos_Serasaenderecosid_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaId_Z", gxTv_SdtSerasaEnderecos_Serasaid_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaEnderecosLogr_Z", gxTv_SdtSerasaEnderecos_Serasaenderecoslogr_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaEnderecosNum_Z", gxTv_SdtSerasaEnderecos_Serasaenderecosnum_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaEnderecosCompl_Z", gxTv_SdtSerasaEnderecos_Serasaenderecoscompl_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaEnderecosBairro_Z", gxTv_SdtSerasaEnderecos_Serasaenderecosbairro_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaEnderecosCidade_Z", gxTv_SdtSerasaEnderecos_Serasaenderecoscidade_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaEnderecosEstado_Z", gxTv_SdtSerasaEnderecos_Serasaenderecosestado_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaEnderecosCEP_Z", gxTv_SdtSerasaEnderecos_Serasaenderecoscep_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaEnderecosTelDDD_Z", gxTv_SdtSerasaEnderecos_Serasaenderecostelddd_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaEnderecosTel_Z", gxTv_SdtSerasaEnderecos_Serasaenderecostel_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaId_N", gxTv_SdtSerasaEnderecos_Serasaid_N, false, includeNonInitialized);
            AddObjectProperty("SerasaEnderecosLogr_N", gxTv_SdtSerasaEnderecos_Serasaenderecoslogr_N, false, includeNonInitialized);
            AddObjectProperty("SerasaEnderecosNum_N", gxTv_SdtSerasaEnderecos_Serasaenderecosnum_N, false, includeNonInitialized);
            AddObjectProperty("SerasaEnderecosCompl_N", gxTv_SdtSerasaEnderecos_Serasaenderecoscompl_N, false, includeNonInitialized);
            AddObjectProperty("SerasaEnderecosBairro_N", gxTv_SdtSerasaEnderecos_Serasaenderecosbairro_N, false, includeNonInitialized);
            AddObjectProperty("SerasaEnderecosCidade_N", gxTv_SdtSerasaEnderecos_Serasaenderecoscidade_N, false, includeNonInitialized);
            AddObjectProperty("SerasaEnderecosEstado_N", gxTv_SdtSerasaEnderecos_Serasaenderecosestado_N, false, includeNonInitialized);
            AddObjectProperty("SerasaEnderecosCEP_N", gxTv_SdtSerasaEnderecos_Serasaenderecoscep_N, false, includeNonInitialized);
            AddObjectProperty("SerasaEnderecosTelDDD_N", gxTv_SdtSerasaEnderecos_Serasaenderecostelddd_N, false, includeNonInitialized);
            AddObjectProperty("SerasaEnderecosTel_N", gxTv_SdtSerasaEnderecos_Serasaenderecostel_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtSerasaEnderecos sdt )
      {
         if ( sdt.IsDirty("SerasaEnderecosId") )
         {
            sdtIsNull = 0;
            gxTv_SdtSerasaEnderecos_Serasaenderecosid = sdt.gxTv_SdtSerasaEnderecos_Serasaenderecosid ;
         }
         if ( sdt.IsDirty("SerasaId") )
         {
            gxTv_SdtSerasaEnderecos_Serasaid_N = (short)(sdt.gxTv_SdtSerasaEnderecos_Serasaid_N);
            sdtIsNull = 0;
            gxTv_SdtSerasaEnderecos_Serasaid = sdt.gxTv_SdtSerasaEnderecos_Serasaid ;
         }
         if ( sdt.IsDirty("SerasaEnderecosLogr") )
         {
            gxTv_SdtSerasaEnderecos_Serasaenderecoslogr_N = (short)(sdt.gxTv_SdtSerasaEnderecos_Serasaenderecoslogr_N);
            sdtIsNull = 0;
            gxTv_SdtSerasaEnderecos_Serasaenderecoslogr = sdt.gxTv_SdtSerasaEnderecos_Serasaenderecoslogr ;
         }
         if ( sdt.IsDirty("SerasaEnderecosNum") )
         {
            gxTv_SdtSerasaEnderecos_Serasaenderecosnum_N = (short)(sdt.gxTv_SdtSerasaEnderecos_Serasaenderecosnum_N);
            sdtIsNull = 0;
            gxTv_SdtSerasaEnderecos_Serasaenderecosnum = sdt.gxTv_SdtSerasaEnderecos_Serasaenderecosnum ;
         }
         if ( sdt.IsDirty("SerasaEnderecosCompl") )
         {
            gxTv_SdtSerasaEnderecos_Serasaenderecoscompl_N = (short)(sdt.gxTv_SdtSerasaEnderecos_Serasaenderecoscompl_N);
            sdtIsNull = 0;
            gxTv_SdtSerasaEnderecos_Serasaenderecoscompl = sdt.gxTv_SdtSerasaEnderecos_Serasaenderecoscompl ;
         }
         if ( sdt.IsDirty("SerasaEnderecosBairro") )
         {
            gxTv_SdtSerasaEnderecos_Serasaenderecosbairro_N = (short)(sdt.gxTv_SdtSerasaEnderecos_Serasaenderecosbairro_N);
            sdtIsNull = 0;
            gxTv_SdtSerasaEnderecos_Serasaenderecosbairro = sdt.gxTv_SdtSerasaEnderecos_Serasaenderecosbairro ;
         }
         if ( sdt.IsDirty("SerasaEnderecosCidade") )
         {
            gxTv_SdtSerasaEnderecos_Serasaenderecoscidade_N = (short)(sdt.gxTv_SdtSerasaEnderecos_Serasaenderecoscidade_N);
            sdtIsNull = 0;
            gxTv_SdtSerasaEnderecos_Serasaenderecoscidade = sdt.gxTv_SdtSerasaEnderecos_Serasaenderecoscidade ;
         }
         if ( sdt.IsDirty("SerasaEnderecosEstado") )
         {
            gxTv_SdtSerasaEnderecos_Serasaenderecosestado_N = (short)(sdt.gxTv_SdtSerasaEnderecos_Serasaenderecosestado_N);
            sdtIsNull = 0;
            gxTv_SdtSerasaEnderecos_Serasaenderecosestado = sdt.gxTv_SdtSerasaEnderecos_Serasaenderecosestado ;
         }
         if ( sdt.IsDirty("SerasaEnderecosCEP") )
         {
            gxTv_SdtSerasaEnderecos_Serasaenderecoscep_N = (short)(sdt.gxTv_SdtSerasaEnderecos_Serasaenderecoscep_N);
            sdtIsNull = 0;
            gxTv_SdtSerasaEnderecos_Serasaenderecoscep = sdt.gxTv_SdtSerasaEnderecos_Serasaenderecoscep ;
         }
         if ( sdt.IsDirty("SerasaEnderecosTelDDD") )
         {
            gxTv_SdtSerasaEnderecos_Serasaenderecostelddd_N = (short)(sdt.gxTv_SdtSerasaEnderecos_Serasaenderecostelddd_N);
            sdtIsNull = 0;
            gxTv_SdtSerasaEnderecos_Serasaenderecostelddd = sdt.gxTv_SdtSerasaEnderecos_Serasaenderecostelddd ;
         }
         if ( sdt.IsDirty("SerasaEnderecosTel") )
         {
            gxTv_SdtSerasaEnderecos_Serasaenderecostel_N = (short)(sdt.gxTv_SdtSerasaEnderecos_Serasaenderecostel_N);
            sdtIsNull = 0;
            gxTv_SdtSerasaEnderecos_Serasaenderecostel = sdt.gxTv_SdtSerasaEnderecos_Serasaenderecostel ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "SerasaEnderecosId" )]
      [  XmlElement( ElementName = "SerasaEnderecosId"   )]
      public int gxTpr_Serasaenderecosid
      {
         get {
            return gxTv_SdtSerasaEnderecos_Serasaenderecosid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtSerasaEnderecos_Serasaenderecosid != value )
            {
               gxTv_SdtSerasaEnderecos_Mode = "INS";
               this.gxTv_SdtSerasaEnderecos_Serasaenderecosid_Z_SetNull( );
               this.gxTv_SdtSerasaEnderecos_Serasaid_Z_SetNull( );
               this.gxTv_SdtSerasaEnderecos_Serasaenderecoslogr_Z_SetNull( );
               this.gxTv_SdtSerasaEnderecos_Serasaenderecosnum_Z_SetNull( );
               this.gxTv_SdtSerasaEnderecos_Serasaenderecoscompl_Z_SetNull( );
               this.gxTv_SdtSerasaEnderecos_Serasaenderecosbairro_Z_SetNull( );
               this.gxTv_SdtSerasaEnderecos_Serasaenderecoscidade_Z_SetNull( );
               this.gxTv_SdtSerasaEnderecos_Serasaenderecosestado_Z_SetNull( );
               this.gxTv_SdtSerasaEnderecos_Serasaenderecoscep_Z_SetNull( );
               this.gxTv_SdtSerasaEnderecos_Serasaenderecostelddd_Z_SetNull( );
               this.gxTv_SdtSerasaEnderecos_Serasaenderecostel_Z_SetNull( );
            }
            gxTv_SdtSerasaEnderecos_Serasaenderecosid = value;
            SetDirty("Serasaenderecosid");
         }

      }

      [  SoapElement( ElementName = "SerasaId" )]
      [  XmlElement( ElementName = "SerasaId"   )]
      public int gxTpr_Serasaid
      {
         get {
            return gxTv_SdtSerasaEnderecos_Serasaid ;
         }

         set {
            gxTv_SdtSerasaEnderecos_Serasaid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasaEnderecos_Serasaid = value;
            SetDirty("Serasaid");
         }

      }

      public void gxTv_SdtSerasaEnderecos_Serasaid_SetNull( )
      {
         gxTv_SdtSerasaEnderecos_Serasaid_N = 1;
         gxTv_SdtSerasaEnderecos_Serasaid = 0;
         SetDirty("Serasaid");
         return  ;
      }

      public bool gxTv_SdtSerasaEnderecos_Serasaid_IsNull( )
      {
         return (gxTv_SdtSerasaEnderecos_Serasaid_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaEnderecosLogr" )]
      [  XmlElement( ElementName = "SerasaEnderecosLogr"   )]
      public string gxTpr_Serasaenderecoslogr
      {
         get {
            return gxTv_SdtSerasaEnderecos_Serasaenderecoslogr ;
         }

         set {
            gxTv_SdtSerasaEnderecos_Serasaenderecoslogr_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasaEnderecos_Serasaenderecoslogr = value;
            SetDirty("Serasaenderecoslogr");
         }

      }

      public void gxTv_SdtSerasaEnderecos_Serasaenderecoslogr_SetNull( )
      {
         gxTv_SdtSerasaEnderecos_Serasaenderecoslogr_N = 1;
         gxTv_SdtSerasaEnderecos_Serasaenderecoslogr = "";
         SetDirty("Serasaenderecoslogr");
         return  ;
      }

      public bool gxTv_SdtSerasaEnderecos_Serasaenderecoslogr_IsNull( )
      {
         return (gxTv_SdtSerasaEnderecos_Serasaenderecoslogr_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaEnderecosNum" )]
      [  XmlElement( ElementName = "SerasaEnderecosNum"   )]
      public string gxTpr_Serasaenderecosnum
      {
         get {
            return gxTv_SdtSerasaEnderecos_Serasaenderecosnum ;
         }

         set {
            gxTv_SdtSerasaEnderecos_Serasaenderecosnum_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasaEnderecos_Serasaenderecosnum = value;
            SetDirty("Serasaenderecosnum");
         }

      }

      public void gxTv_SdtSerasaEnderecos_Serasaenderecosnum_SetNull( )
      {
         gxTv_SdtSerasaEnderecos_Serasaenderecosnum_N = 1;
         gxTv_SdtSerasaEnderecos_Serasaenderecosnum = "";
         SetDirty("Serasaenderecosnum");
         return  ;
      }

      public bool gxTv_SdtSerasaEnderecos_Serasaenderecosnum_IsNull( )
      {
         return (gxTv_SdtSerasaEnderecos_Serasaenderecosnum_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaEnderecosCompl" )]
      [  XmlElement( ElementName = "SerasaEnderecosCompl"   )]
      public string gxTpr_Serasaenderecoscompl
      {
         get {
            return gxTv_SdtSerasaEnderecos_Serasaenderecoscompl ;
         }

         set {
            gxTv_SdtSerasaEnderecos_Serasaenderecoscompl_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasaEnderecos_Serasaenderecoscompl = value;
            SetDirty("Serasaenderecoscompl");
         }

      }

      public void gxTv_SdtSerasaEnderecos_Serasaenderecoscompl_SetNull( )
      {
         gxTv_SdtSerasaEnderecos_Serasaenderecoscompl_N = 1;
         gxTv_SdtSerasaEnderecos_Serasaenderecoscompl = "";
         SetDirty("Serasaenderecoscompl");
         return  ;
      }

      public bool gxTv_SdtSerasaEnderecos_Serasaenderecoscompl_IsNull( )
      {
         return (gxTv_SdtSerasaEnderecos_Serasaenderecoscompl_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaEnderecosBairro" )]
      [  XmlElement( ElementName = "SerasaEnderecosBairro"   )]
      public string gxTpr_Serasaenderecosbairro
      {
         get {
            return gxTv_SdtSerasaEnderecos_Serasaenderecosbairro ;
         }

         set {
            gxTv_SdtSerasaEnderecos_Serasaenderecosbairro_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasaEnderecos_Serasaenderecosbairro = value;
            SetDirty("Serasaenderecosbairro");
         }

      }

      public void gxTv_SdtSerasaEnderecos_Serasaenderecosbairro_SetNull( )
      {
         gxTv_SdtSerasaEnderecos_Serasaenderecosbairro_N = 1;
         gxTv_SdtSerasaEnderecos_Serasaenderecosbairro = "";
         SetDirty("Serasaenderecosbairro");
         return  ;
      }

      public bool gxTv_SdtSerasaEnderecos_Serasaenderecosbairro_IsNull( )
      {
         return (gxTv_SdtSerasaEnderecos_Serasaenderecosbairro_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaEnderecosCidade" )]
      [  XmlElement( ElementName = "SerasaEnderecosCidade"   )]
      public string gxTpr_Serasaenderecoscidade
      {
         get {
            return gxTv_SdtSerasaEnderecos_Serasaenderecoscidade ;
         }

         set {
            gxTv_SdtSerasaEnderecos_Serasaenderecoscidade_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasaEnderecos_Serasaenderecoscidade = value;
            SetDirty("Serasaenderecoscidade");
         }

      }

      public void gxTv_SdtSerasaEnderecos_Serasaenderecoscidade_SetNull( )
      {
         gxTv_SdtSerasaEnderecos_Serasaenderecoscidade_N = 1;
         gxTv_SdtSerasaEnderecos_Serasaenderecoscidade = "";
         SetDirty("Serasaenderecoscidade");
         return  ;
      }

      public bool gxTv_SdtSerasaEnderecos_Serasaenderecoscidade_IsNull( )
      {
         return (gxTv_SdtSerasaEnderecos_Serasaenderecoscidade_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaEnderecosEstado" )]
      [  XmlElement( ElementName = "SerasaEnderecosEstado"   )]
      public string gxTpr_Serasaenderecosestado
      {
         get {
            return gxTv_SdtSerasaEnderecos_Serasaenderecosestado ;
         }

         set {
            gxTv_SdtSerasaEnderecos_Serasaenderecosestado_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasaEnderecos_Serasaenderecosestado = value;
            SetDirty("Serasaenderecosestado");
         }

      }

      public void gxTv_SdtSerasaEnderecos_Serasaenderecosestado_SetNull( )
      {
         gxTv_SdtSerasaEnderecos_Serasaenderecosestado_N = 1;
         gxTv_SdtSerasaEnderecos_Serasaenderecosestado = "";
         SetDirty("Serasaenderecosestado");
         return  ;
      }

      public bool gxTv_SdtSerasaEnderecos_Serasaenderecosestado_IsNull( )
      {
         return (gxTv_SdtSerasaEnderecos_Serasaenderecosestado_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaEnderecosCEP" )]
      [  XmlElement( ElementName = "SerasaEnderecosCEP"   )]
      public string gxTpr_Serasaenderecoscep
      {
         get {
            return gxTv_SdtSerasaEnderecos_Serasaenderecoscep ;
         }

         set {
            gxTv_SdtSerasaEnderecos_Serasaenderecoscep_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasaEnderecos_Serasaenderecoscep = value;
            SetDirty("Serasaenderecoscep");
         }

      }

      public void gxTv_SdtSerasaEnderecos_Serasaenderecoscep_SetNull( )
      {
         gxTv_SdtSerasaEnderecos_Serasaenderecoscep_N = 1;
         gxTv_SdtSerasaEnderecos_Serasaenderecoscep = "";
         SetDirty("Serasaenderecoscep");
         return  ;
      }

      public bool gxTv_SdtSerasaEnderecos_Serasaenderecoscep_IsNull( )
      {
         return (gxTv_SdtSerasaEnderecos_Serasaenderecoscep_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaEnderecosTelDDD" )]
      [  XmlElement( ElementName = "SerasaEnderecosTelDDD"   )]
      public string gxTpr_Serasaenderecostelddd
      {
         get {
            return gxTv_SdtSerasaEnderecos_Serasaenderecostelddd ;
         }

         set {
            gxTv_SdtSerasaEnderecos_Serasaenderecostelddd_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasaEnderecos_Serasaenderecostelddd = value;
            SetDirty("Serasaenderecostelddd");
         }

      }

      public void gxTv_SdtSerasaEnderecos_Serasaenderecostelddd_SetNull( )
      {
         gxTv_SdtSerasaEnderecos_Serasaenderecostelddd_N = 1;
         gxTv_SdtSerasaEnderecos_Serasaenderecostelddd = "";
         SetDirty("Serasaenderecostelddd");
         return  ;
      }

      public bool gxTv_SdtSerasaEnderecos_Serasaenderecostelddd_IsNull( )
      {
         return (gxTv_SdtSerasaEnderecos_Serasaenderecostelddd_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaEnderecosTel" )]
      [  XmlElement( ElementName = "SerasaEnderecosTel"   )]
      public string gxTpr_Serasaenderecostel
      {
         get {
            return gxTv_SdtSerasaEnderecos_Serasaenderecostel ;
         }

         set {
            gxTv_SdtSerasaEnderecos_Serasaenderecostel_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasaEnderecos_Serasaenderecostel = value;
            SetDirty("Serasaenderecostel");
         }

      }

      public void gxTv_SdtSerasaEnderecos_Serasaenderecostel_SetNull( )
      {
         gxTv_SdtSerasaEnderecos_Serasaenderecostel_N = 1;
         gxTv_SdtSerasaEnderecos_Serasaenderecostel = "";
         SetDirty("Serasaenderecostel");
         return  ;
      }

      public bool gxTv_SdtSerasaEnderecos_Serasaenderecostel_IsNull( )
      {
         return (gxTv_SdtSerasaEnderecos_Serasaenderecostel_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtSerasaEnderecos_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaEnderecos_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtSerasaEnderecos_Mode_SetNull( )
      {
         gxTv_SdtSerasaEnderecos_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtSerasaEnderecos_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtSerasaEnderecos_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaEnderecos_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtSerasaEnderecos_Initialized_SetNull( )
      {
         gxTv_SdtSerasaEnderecos_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtSerasaEnderecos_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaEnderecosId_Z" )]
      [  XmlElement( ElementName = "SerasaEnderecosId_Z"   )]
      public int gxTpr_Serasaenderecosid_Z
      {
         get {
            return gxTv_SdtSerasaEnderecos_Serasaenderecosid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaEnderecos_Serasaenderecosid_Z = value;
            SetDirty("Serasaenderecosid_Z");
         }

      }

      public void gxTv_SdtSerasaEnderecos_Serasaenderecosid_Z_SetNull( )
      {
         gxTv_SdtSerasaEnderecos_Serasaenderecosid_Z = 0;
         SetDirty("Serasaenderecosid_Z");
         return  ;
      }

      public bool gxTv_SdtSerasaEnderecos_Serasaenderecosid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaId_Z" )]
      [  XmlElement( ElementName = "SerasaId_Z"   )]
      public int gxTpr_Serasaid_Z
      {
         get {
            return gxTv_SdtSerasaEnderecos_Serasaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaEnderecos_Serasaid_Z = value;
            SetDirty("Serasaid_Z");
         }

      }

      public void gxTv_SdtSerasaEnderecos_Serasaid_Z_SetNull( )
      {
         gxTv_SdtSerasaEnderecos_Serasaid_Z = 0;
         SetDirty("Serasaid_Z");
         return  ;
      }

      public bool gxTv_SdtSerasaEnderecos_Serasaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaEnderecosLogr_Z" )]
      [  XmlElement( ElementName = "SerasaEnderecosLogr_Z"   )]
      public string gxTpr_Serasaenderecoslogr_Z
      {
         get {
            return gxTv_SdtSerasaEnderecos_Serasaenderecoslogr_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaEnderecos_Serasaenderecoslogr_Z = value;
            SetDirty("Serasaenderecoslogr_Z");
         }

      }

      public void gxTv_SdtSerasaEnderecos_Serasaenderecoslogr_Z_SetNull( )
      {
         gxTv_SdtSerasaEnderecos_Serasaenderecoslogr_Z = "";
         SetDirty("Serasaenderecoslogr_Z");
         return  ;
      }

      public bool gxTv_SdtSerasaEnderecos_Serasaenderecoslogr_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaEnderecosNum_Z" )]
      [  XmlElement( ElementName = "SerasaEnderecosNum_Z"   )]
      public string gxTpr_Serasaenderecosnum_Z
      {
         get {
            return gxTv_SdtSerasaEnderecos_Serasaenderecosnum_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaEnderecos_Serasaenderecosnum_Z = value;
            SetDirty("Serasaenderecosnum_Z");
         }

      }

      public void gxTv_SdtSerasaEnderecos_Serasaenderecosnum_Z_SetNull( )
      {
         gxTv_SdtSerasaEnderecos_Serasaenderecosnum_Z = "";
         SetDirty("Serasaenderecosnum_Z");
         return  ;
      }

      public bool gxTv_SdtSerasaEnderecos_Serasaenderecosnum_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaEnderecosCompl_Z" )]
      [  XmlElement( ElementName = "SerasaEnderecosCompl_Z"   )]
      public string gxTpr_Serasaenderecoscompl_Z
      {
         get {
            return gxTv_SdtSerasaEnderecos_Serasaenderecoscompl_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaEnderecos_Serasaenderecoscompl_Z = value;
            SetDirty("Serasaenderecoscompl_Z");
         }

      }

      public void gxTv_SdtSerasaEnderecos_Serasaenderecoscompl_Z_SetNull( )
      {
         gxTv_SdtSerasaEnderecos_Serasaenderecoscompl_Z = "";
         SetDirty("Serasaenderecoscompl_Z");
         return  ;
      }

      public bool gxTv_SdtSerasaEnderecos_Serasaenderecoscompl_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaEnderecosBairro_Z" )]
      [  XmlElement( ElementName = "SerasaEnderecosBairro_Z"   )]
      public string gxTpr_Serasaenderecosbairro_Z
      {
         get {
            return gxTv_SdtSerasaEnderecos_Serasaenderecosbairro_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaEnderecos_Serasaenderecosbairro_Z = value;
            SetDirty("Serasaenderecosbairro_Z");
         }

      }

      public void gxTv_SdtSerasaEnderecos_Serasaenderecosbairro_Z_SetNull( )
      {
         gxTv_SdtSerasaEnderecos_Serasaenderecosbairro_Z = "";
         SetDirty("Serasaenderecosbairro_Z");
         return  ;
      }

      public bool gxTv_SdtSerasaEnderecos_Serasaenderecosbairro_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaEnderecosCidade_Z" )]
      [  XmlElement( ElementName = "SerasaEnderecosCidade_Z"   )]
      public string gxTpr_Serasaenderecoscidade_Z
      {
         get {
            return gxTv_SdtSerasaEnderecos_Serasaenderecoscidade_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaEnderecos_Serasaenderecoscidade_Z = value;
            SetDirty("Serasaenderecoscidade_Z");
         }

      }

      public void gxTv_SdtSerasaEnderecos_Serasaenderecoscidade_Z_SetNull( )
      {
         gxTv_SdtSerasaEnderecos_Serasaenderecoscidade_Z = "";
         SetDirty("Serasaenderecoscidade_Z");
         return  ;
      }

      public bool gxTv_SdtSerasaEnderecos_Serasaenderecoscidade_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaEnderecosEstado_Z" )]
      [  XmlElement( ElementName = "SerasaEnderecosEstado_Z"   )]
      public string gxTpr_Serasaenderecosestado_Z
      {
         get {
            return gxTv_SdtSerasaEnderecos_Serasaenderecosestado_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaEnderecos_Serasaenderecosestado_Z = value;
            SetDirty("Serasaenderecosestado_Z");
         }

      }

      public void gxTv_SdtSerasaEnderecos_Serasaenderecosestado_Z_SetNull( )
      {
         gxTv_SdtSerasaEnderecos_Serasaenderecosestado_Z = "";
         SetDirty("Serasaenderecosestado_Z");
         return  ;
      }

      public bool gxTv_SdtSerasaEnderecos_Serasaenderecosestado_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaEnderecosCEP_Z" )]
      [  XmlElement( ElementName = "SerasaEnderecosCEP_Z"   )]
      public string gxTpr_Serasaenderecoscep_Z
      {
         get {
            return gxTv_SdtSerasaEnderecos_Serasaenderecoscep_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaEnderecos_Serasaenderecoscep_Z = value;
            SetDirty("Serasaenderecoscep_Z");
         }

      }

      public void gxTv_SdtSerasaEnderecos_Serasaenderecoscep_Z_SetNull( )
      {
         gxTv_SdtSerasaEnderecos_Serasaenderecoscep_Z = "";
         SetDirty("Serasaenderecoscep_Z");
         return  ;
      }

      public bool gxTv_SdtSerasaEnderecos_Serasaenderecoscep_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaEnderecosTelDDD_Z" )]
      [  XmlElement( ElementName = "SerasaEnderecosTelDDD_Z"   )]
      public string gxTpr_Serasaenderecostelddd_Z
      {
         get {
            return gxTv_SdtSerasaEnderecos_Serasaenderecostelddd_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaEnderecos_Serasaenderecostelddd_Z = value;
            SetDirty("Serasaenderecostelddd_Z");
         }

      }

      public void gxTv_SdtSerasaEnderecos_Serasaenderecostelddd_Z_SetNull( )
      {
         gxTv_SdtSerasaEnderecos_Serasaenderecostelddd_Z = "";
         SetDirty("Serasaenderecostelddd_Z");
         return  ;
      }

      public bool gxTv_SdtSerasaEnderecos_Serasaenderecostelddd_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaEnderecosTel_Z" )]
      [  XmlElement( ElementName = "SerasaEnderecosTel_Z"   )]
      public string gxTpr_Serasaenderecostel_Z
      {
         get {
            return gxTv_SdtSerasaEnderecos_Serasaenderecostel_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaEnderecos_Serasaenderecostel_Z = value;
            SetDirty("Serasaenderecostel_Z");
         }

      }

      public void gxTv_SdtSerasaEnderecos_Serasaenderecostel_Z_SetNull( )
      {
         gxTv_SdtSerasaEnderecos_Serasaenderecostel_Z = "";
         SetDirty("Serasaenderecostel_Z");
         return  ;
      }

      public bool gxTv_SdtSerasaEnderecos_Serasaenderecostel_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaId_N" )]
      [  XmlElement( ElementName = "SerasaId_N"   )]
      public short gxTpr_Serasaid_N
      {
         get {
            return gxTv_SdtSerasaEnderecos_Serasaid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaEnderecos_Serasaid_N = value;
            SetDirty("Serasaid_N");
         }

      }

      public void gxTv_SdtSerasaEnderecos_Serasaid_N_SetNull( )
      {
         gxTv_SdtSerasaEnderecos_Serasaid_N = 0;
         SetDirty("Serasaid_N");
         return  ;
      }

      public bool gxTv_SdtSerasaEnderecos_Serasaid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaEnderecosLogr_N" )]
      [  XmlElement( ElementName = "SerasaEnderecosLogr_N"   )]
      public short gxTpr_Serasaenderecoslogr_N
      {
         get {
            return gxTv_SdtSerasaEnderecos_Serasaenderecoslogr_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaEnderecos_Serasaenderecoslogr_N = value;
            SetDirty("Serasaenderecoslogr_N");
         }

      }

      public void gxTv_SdtSerasaEnderecos_Serasaenderecoslogr_N_SetNull( )
      {
         gxTv_SdtSerasaEnderecos_Serasaenderecoslogr_N = 0;
         SetDirty("Serasaenderecoslogr_N");
         return  ;
      }

      public bool gxTv_SdtSerasaEnderecos_Serasaenderecoslogr_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaEnderecosNum_N" )]
      [  XmlElement( ElementName = "SerasaEnderecosNum_N"   )]
      public short gxTpr_Serasaenderecosnum_N
      {
         get {
            return gxTv_SdtSerasaEnderecos_Serasaenderecosnum_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaEnderecos_Serasaenderecosnum_N = value;
            SetDirty("Serasaenderecosnum_N");
         }

      }

      public void gxTv_SdtSerasaEnderecos_Serasaenderecosnum_N_SetNull( )
      {
         gxTv_SdtSerasaEnderecos_Serasaenderecosnum_N = 0;
         SetDirty("Serasaenderecosnum_N");
         return  ;
      }

      public bool gxTv_SdtSerasaEnderecos_Serasaenderecosnum_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaEnderecosCompl_N" )]
      [  XmlElement( ElementName = "SerasaEnderecosCompl_N"   )]
      public short gxTpr_Serasaenderecoscompl_N
      {
         get {
            return gxTv_SdtSerasaEnderecos_Serasaenderecoscompl_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaEnderecos_Serasaenderecoscompl_N = value;
            SetDirty("Serasaenderecoscompl_N");
         }

      }

      public void gxTv_SdtSerasaEnderecos_Serasaenderecoscompl_N_SetNull( )
      {
         gxTv_SdtSerasaEnderecos_Serasaenderecoscompl_N = 0;
         SetDirty("Serasaenderecoscompl_N");
         return  ;
      }

      public bool gxTv_SdtSerasaEnderecos_Serasaenderecoscompl_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaEnderecosBairro_N" )]
      [  XmlElement( ElementName = "SerasaEnderecosBairro_N"   )]
      public short gxTpr_Serasaenderecosbairro_N
      {
         get {
            return gxTv_SdtSerasaEnderecos_Serasaenderecosbairro_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaEnderecos_Serasaenderecosbairro_N = value;
            SetDirty("Serasaenderecosbairro_N");
         }

      }

      public void gxTv_SdtSerasaEnderecos_Serasaenderecosbairro_N_SetNull( )
      {
         gxTv_SdtSerasaEnderecos_Serasaenderecosbairro_N = 0;
         SetDirty("Serasaenderecosbairro_N");
         return  ;
      }

      public bool gxTv_SdtSerasaEnderecos_Serasaenderecosbairro_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaEnderecosCidade_N" )]
      [  XmlElement( ElementName = "SerasaEnderecosCidade_N"   )]
      public short gxTpr_Serasaenderecoscidade_N
      {
         get {
            return gxTv_SdtSerasaEnderecos_Serasaenderecoscidade_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaEnderecos_Serasaenderecoscidade_N = value;
            SetDirty("Serasaenderecoscidade_N");
         }

      }

      public void gxTv_SdtSerasaEnderecos_Serasaenderecoscidade_N_SetNull( )
      {
         gxTv_SdtSerasaEnderecos_Serasaenderecoscidade_N = 0;
         SetDirty("Serasaenderecoscidade_N");
         return  ;
      }

      public bool gxTv_SdtSerasaEnderecos_Serasaenderecoscidade_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaEnderecosEstado_N" )]
      [  XmlElement( ElementName = "SerasaEnderecosEstado_N"   )]
      public short gxTpr_Serasaenderecosestado_N
      {
         get {
            return gxTv_SdtSerasaEnderecos_Serasaenderecosestado_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaEnderecos_Serasaenderecosestado_N = value;
            SetDirty("Serasaenderecosestado_N");
         }

      }

      public void gxTv_SdtSerasaEnderecos_Serasaenderecosestado_N_SetNull( )
      {
         gxTv_SdtSerasaEnderecos_Serasaenderecosestado_N = 0;
         SetDirty("Serasaenderecosestado_N");
         return  ;
      }

      public bool gxTv_SdtSerasaEnderecos_Serasaenderecosestado_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaEnderecosCEP_N" )]
      [  XmlElement( ElementName = "SerasaEnderecosCEP_N"   )]
      public short gxTpr_Serasaenderecoscep_N
      {
         get {
            return gxTv_SdtSerasaEnderecos_Serasaenderecoscep_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaEnderecos_Serasaenderecoscep_N = value;
            SetDirty("Serasaenderecoscep_N");
         }

      }

      public void gxTv_SdtSerasaEnderecos_Serasaenderecoscep_N_SetNull( )
      {
         gxTv_SdtSerasaEnderecos_Serasaenderecoscep_N = 0;
         SetDirty("Serasaenderecoscep_N");
         return  ;
      }

      public bool gxTv_SdtSerasaEnderecos_Serasaenderecoscep_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaEnderecosTelDDD_N" )]
      [  XmlElement( ElementName = "SerasaEnderecosTelDDD_N"   )]
      public short gxTpr_Serasaenderecostelddd_N
      {
         get {
            return gxTv_SdtSerasaEnderecos_Serasaenderecostelddd_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaEnderecos_Serasaenderecostelddd_N = value;
            SetDirty("Serasaenderecostelddd_N");
         }

      }

      public void gxTv_SdtSerasaEnderecos_Serasaenderecostelddd_N_SetNull( )
      {
         gxTv_SdtSerasaEnderecos_Serasaenderecostelddd_N = 0;
         SetDirty("Serasaenderecostelddd_N");
         return  ;
      }

      public bool gxTv_SdtSerasaEnderecos_Serasaenderecostelddd_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaEnderecosTel_N" )]
      [  XmlElement( ElementName = "SerasaEnderecosTel_N"   )]
      public short gxTpr_Serasaenderecostel_N
      {
         get {
            return gxTv_SdtSerasaEnderecos_Serasaenderecostel_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaEnderecos_Serasaenderecostel_N = value;
            SetDirty("Serasaenderecostel_N");
         }

      }

      public void gxTv_SdtSerasaEnderecos_Serasaenderecostel_N_SetNull( )
      {
         gxTv_SdtSerasaEnderecos_Serasaenderecostel_N = 0;
         SetDirty("Serasaenderecostel_N");
         return  ;
      }

      public bool gxTv_SdtSerasaEnderecos_Serasaenderecostel_N_IsNull( )
      {
         return false ;
      }

      [XmlIgnore]
      private static GXTypeInfo _typeProps;
      protected override GXTypeInfo TypeInfo
      {
         get {
            return _typeProps ;
         }

         set {
            _typeProps = value ;
         }

      }

      public void initialize( )
      {
         sdtIsNull = 1;
         gxTv_SdtSerasaEnderecos_Serasaenderecoslogr = "";
         gxTv_SdtSerasaEnderecos_Serasaenderecosnum = "";
         gxTv_SdtSerasaEnderecos_Serasaenderecoscompl = "";
         gxTv_SdtSerasaEnderecos_Serasaenderecosbairro = "";
         gxTv_SdtSerasaEnderecos_Serasaenderecoscidade = "";
         gxTv_SdtSerasaEnderecos_Serasaenderecosestado = "";
         gxTv_SdtSerasaEnderecos_Serasaenderecoscep = "";
         gxTv_SdtSerasaEnderecos_Serasaenderecostelddd = "";
         gxTv_SdtSerasaEnderecos_Serasaenderecostel = "";
         gxTv_SdtSerasaEnderecos_Mode = "";
         gxTv_SdtSerasaEnderecos_Serasaenderecoslogr_Z = "";
         gxTv_SdtSerasaEnderecos_Serasaenderecosnum_Z = "";
         gxTv_SdtSerasaEnderecos_Serasaenderecoscompl_Z = "";
         gxTv_SdtSerasaEnderecos_Serasaenderecosbairro_Z = "";
         gxTv_SdtSerasaEnderecos_Serasaenderecoscidade_Z = "";
         gxTv_SdtSerasaEnderecos_Serasaenderecosestado_Z = "";
         gxTv_SdtSerasaEnderecos_Serasaenderecoscep_Z = "";
         gxTv_SdtSerasaEnderecos_Serasaenderecostelddd_Z = "";
         gxTv_SdtSerasaEnderecos_Serasaenderecostel_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "serasaenderecos", "GeneXus.Programs.serasaenderecos_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short sdtIsNull ;
      private short gxTv_SdtSerasaEnderecos_Initialized ;
      private short gxTv_SdtSerasaEnderecos_Serasaid_N ;
      private short gxTv_SdtSerasaEnderecos_Serasaenderecoslogr_N ;
      private short gxTv_SdtSerasaEnderecos_Serasaenderecosnum_N ;
      private short gxTv_SdtSerasaEnderecos_Serasaenderecoscompl_N ;
      private short gxTv_SdtSerasaEnderecos_Serasaenderecosbairro_N ;
      private short gxTv_SdtSerasaEnderecos_Serasaenderecoscidade_N ;
      private short gxTv_SdtSerasaEnderecos_Serasaenderecosestado_N ;
      private short gxTv_SdtSerasaEnderecos_Serasaenderecoscep_N ;
      private short gxTv_SdtSerasaEnderecos_Serasaenderecostelddd_N ;
      private short gxTv_SdtSerasaEnderecos_Serasaenderecostel_N ;
      private int gxTv_SdtSerasaEnderecos_Serasaenderecosid ;
      private int gxTv_SdtSerasaEnderecos_Serasaid ;
      private int gxTv_SdtSerasaEnderecos_Serasaenderecosid_Z ;
      private int gxTv_SdtSerasaEnderecos_Serasaid_Z ;
      private string gxTv_SdtSerasaEnderecos_Mode ;
      private string gxTv_SdtSerasaEnderecos_Serasaenderecoslogr ;
      private string gxTv_SdtSerasaEnderecos_Serasaenderecosnum ;
      private string gxTv_SdtSerasaEnderecos_Serasaenderecoscompl ;
      private string gxTv_SdtSerasaEnderecos_Serasaenderecosbairro ;
      private string gxTv_SdtSerasaEnderecos_Serasaenderecoscidade ;
      private string gxTv_SdtSerasaEnderecos_Serasaenderecosestado ;
      private string gxTv_SdtSerasaEnderecos_Serasaenderecoscep ;
      private string gxTv_SdtSerasaEnderecos_Serasaenderecostelddd ;
      private string gxTv_SdtSerasaEnderecos_Serasaenderecostel ;
      private string gxTv_SdtSerasaEnderecos_Serasaenderecoslogr_Z ;
      private string gxTv_SdtSerasaEnderecos_Serasaenderecosnum_Z ;
      private string gxTv_SdtSerasaEnderecos_Serasaenderecoscompl_Z ;
      private string gxTv_SdtSerasaEnderecos_Serasaenderecosbairro_Z ;
      private string gxTv_SdtSerasaEnderecos_Serasaenderecoscidade_Z ;
      private string gxTv_SdtSerasaEnderecos_Serasaenderecosestado_Z ;
      private string gxTv_SdtSerasaEnderecos_Serasaenderecoscep_Z ;
      private string gxTv_SdtSerasaEnderecos_Serasaenderecostelddd_Z ;
      private string gxTv_SdtSerasaEnderecos_Serasaenderecostel_Z ;
   }

   [DataContract(Name = @"SerasaEnderecos", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtSerasaEnderecos_RESTInterface : GxGenericCollectionItem<SdtSerasaEnderecos>
   {
      public SdtSerasaEnderecos_RESTInterface( ) : base()
      {
      }

      public SdtSerasaEnderecos_RESTInterface( SdtSerasaEnderecos psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "SerasaEnderecosId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Serasaenderecosid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Serasaenderecosid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Serasaenderecosid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "SerasaId" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Serasaid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Serasaid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Serasaid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "SerasaEnderecosLogr" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Serasaenderecoslogr
      {
         get {
            return sdt.gxTpr_Serasaenderecoslogr ;
         }

         set {
            sdt.gxTpr_Serasaenderecoslogr = value;
         }

      }

      [DataMember( Name = "SerasaEnderecosNum" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Serasaenderecosnum
      {
         get {
            return sdt.gxTpr_Serasaenderecosnum ;
         }

         set {
            sdt.gxTpr_Serasaenderecosnum = value;
         }

      }

      [DataMember( Name = "SerasaEnderecosCompl" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Serasaenderecoscompl
      {
         get {
            return sdt.gxTpr_Serasaenderecoscompl ;
         }

         set {
            sdt.gxTpr_Serasaenderecoscompl = value;
         }

      }

      [DataMember( Name = "SerasaEnderecosBairro" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Serasaenderecosbairro
      {
         get {
            return sdt.gxTpr_Serasaenderecosbairro ;
         }

         set {
            sdt.gxTpr_Serasaenderecosbairro = value;
         }

      }

      [DataMember( Name = "SerasaEnderecosCidade" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Serasaenderecoscidade
      {
         get {
            return sdt.gxTpr_Serasaenderecoscidade ;
         }

         set {
            sdt.gxTpr_Serasaenderecoscidade = value;
         }

      }

      [DataMember( Name = "SerasaEnderecosEstado" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Serasaenderecosestado
      {
         get {
            return sdt.gxTpr_Serasaenderecosestado ;
         }

         set {
            sdt.gxTpr_Serasaenderecosestado = value;
         }

      }

      [DataMember( Name = "SerasaEnderecosCEP" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Serasaenderecoscep
      {
         get {
            return sdt.gxTpr_Serasaenderecoscep ;
         }

         set {
            sdt.gxTpr_Serasaenderecoscep = value;
         }

      }

      [DataMember( Name = "SerasaEnderecosTelDDD" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Serasaenderecostelddd
      {
         get {
            return sdt.gxTpr_Serasaenderecostelddd ;
         }

         set {
            sdt.gxTpr_Serasaenderecostelddd = value;
         }

      }

      [DataMember( Name = "SerasaEnderecosTel" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Serasaenderecostel
      {
         get {
            return sdt.gxTpr_Serasaenderecostel ;
         }

         set {
            sdt.gxTpr_Serasaenderecostel = value;
         }

      }

      public SdtSerasaEnderecos sdt
      {
         get {
            return (SdtSerasaEnderecos)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtSerasaEnderecos() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 11 )]
      public string Hash
      {
         get {
            if ( StringUtil.StrCmp(md5Hash, null) == 0 )
            {
               md5Hash = (string)(getHash());
            }
            return md5Hash ;
         }

         set {
            md5Hash = value ;
         }

      }

      private string md5Hash ;
   }

   [DataContract(Name = @"SerasaEnderecos", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtSerasaEnderecos_RESTLInterface : GxGenericCollectionItem<SdtSerasaEnderecos>
   {
      public SdtSerasaEnderecos_RESTLInterface( ) : base()
      {
      }

      public SdtSerasaEnderecos_RESTLInterface( SdtSerasaEnderecos psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "SerasaEnderecosLogr" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Serasaenderecoslogr
      {
         get {
            return sdt.gxTpr_Serasaenderecoslogr ;
         }

         set {
            sdt.gxTpr_Serasaenderecoslogr = value;
         }

      }

      [DataMember( Name = "uri" , Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtSerasaEnderecos sdt
      {
         get {
            return (SdtSerasaEnderecos)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtSerasaEnderecos() ;
         }
      }

   }

}
