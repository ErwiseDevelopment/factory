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
   [XmlRoot(ElementName = "ProcedimentosMedicos" )]
   [XmlType(TypeName =  "ProcedimentosMedicos" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtProcedimentosMedicos : GxSilentTrnSdt
   {
      public SdtProcedimentosMedicos( )
      {
      }

      public SdtProcedimentosMedicos( IGxContext context )
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

      public void Load( int AV376ProcedimentosMedicosId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV376ProcedimentosMedicosId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ProcedimentosMedicosId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "ProcedimentosMedicos");
         metadata.Set("BT", "ProcedimentosMedicos");
         metadata.Set("PK", "[ \"ProcedimentosMedicosId\" ]");
         metadata.Set("PKAssigned", "[ \"ProcedimentosMedicosId\" ]");
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
         state.Add("gxTpr_Procedimentosmedicosid_Z");
         state.Add("gxTpr_Procedimentosmedicosnome_Z");
         state.Add("gxTpr_Procedimentosmedicosarea_Z");
         state.Add("gxTpr_Cid_Z");
         state.Add("gxTpr_Procedimentosmedicosativo_Z");
         state.Add("gxTpr_Procedimentosmedicosid_N");
         state.Add("gxTpr_Procedimentosmedicosnome_N");
         state.Add("gxTpr_Procedimentosmedicosdescricao_N");
         state.Add("gxTpr_Procedimentosmedicosarea_N");
         state.Add("gxTpr_Cid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtProcedimentosMedicos sdt;
         sdt = (SdtProcedimentosMedicos)(source);
         gxTv_SdtProcedimentosMedicos_Procedimentosmedicosid = sdt.gxTv_SdtProcedimentosMedicos_Procedimentosmedicosid ;
         gxTv_SdtProcedimentosMedicos_Procedimentosmedicosnome = sdt.gxTv_SdtProcedimentosMedicos_Procedimentosmedicosnome ;
         gxTv_SdtProcedimentosMedicos_Procedimentosmedicosdescricao = sdt.gxTv_SdtProcedimentosMedicos_Procedimentosmedicosdescricao ;
         gxTv_SdtProcedimentosMedicos_Procedimentosmedicosarea = sdt.gxTv_SdtProcedimentosMedicos_Procedimentosmedicosarea ;
         gxTv_SdtProcedimentosMedicos_Cid = sdt.gxTv_SdtProcedimentosMedicos_Cid ;
         gxTv_SdtProcedimentosMedicos_Procedimentosmedicosativo = sdt.gxTv_SdtProcedimentosMedicos_Procedimentosmedicosativo ;
         gxTv_SdtProcedimentosMedicos_Mode = sdt.gxTv_SdtProcedimentosMedicos_Mode ;
         gxTv_SdtProcedimentosMedicos_Initialized = sdt.gxTv_SdtProcedimentosMedicos_Initialized ;
         gxTv_SdtProcedimentosMedicos_Procedimentosmedicosid_Z = sdt.gxTv_SdtProcedimentosMedicos_Procedimentosmedicosid_Z ;
         gxTv_SdtProcedimentosMedicos_Procedimentosmedicosnome_Z = sdt.gxTv_SdtProcedimentosMedicos_Procedimentosmedicosnome_Z ;
         gxTv_SdtProcedimentosMedicos_Procedimentosmedicosarea_Z = sdt.gxTv_SdtProcedimentosMedicos_Procedimentosmedicosarea_Z ;
         gxTv_SdtProcedimentosMedicos_Cid_Z = sdt.gxTv_SdtProcedimentosMedicos_Cid_Z ;
         gxTv_SdtProcedimentosMedicos_Procedimentosmedicosativo_Z = sdt.gxTv_SdtProcedimentosMedicos_Procedimentosmedicosativo_Z ;
         gxTv_SdtProcedimentosMedicos_Procedimentosmedicosid_N = sdt.gxTv_SdtProcedimentosMedicos_Procedimentosmedicosid_N ;
         gxTv_SdtProcedimentosMedicos_Procedimentosmedicosnome_N = sdt.gxTv_SdtProcedimentosMedicos_Procedimentosmedicosnome_N ;
         gxTv_SdtProcedimentosMedicos_Procedimentosmedicosdescricao_N = sdt.gxTv_SdtProcedimentosMedicos_Procedimentosmedicosdescricao_N ;
         gxTv_SdtProcedimentosMedicos_Procedimentosmedicosarea_N = sdt.gxTv_SdtProcedimentosMedicos_Procedimentosmedicosarea_N ;
         gxTv_SdtProcedimentosMedicos_Cid_N = sdt.gxTv_SdtProcedimentosMedicos_Cid_N ;
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
         AddObjectProperty("ProcedimentosMedicosId", gxTv_SdtProcedimentosMedicos_Procedimentosmedicosid, false, includeNonInitialized);
         AddObjectProperty("ProcedimentosMedicosId_N", gxTv_SdtProcedimentosMedicos_Procedimentosmedicosid_N, false, includeNonInitialized);
         AddObjectProperty("ProcedimentosMedicosNome", gxTv_SdtProcedimentosMedicos_Procedimentosmedicosnome, false, includeNonInitialized);
         AddObjectProperty("ProcedimentosMedicosNome_N", gxTv_SdtProcedimentosMedicos_Procedimentosmedicosnome_N, false, includeNonInitialized);
         AddObjectProperty("ProcedimentosMedicosDescricao", gxTv_SdtProcedimentosMedicos_Procedimentosmedicosdescricao, false, includeNonInitialized);
         AddObjectProperty("ProcedimentosMedicosDescricao_N", gxTv_SdtProcedimentosMedicos_Procedimentosmedicosdescricao_N, false, includeNonInitialized);
         AddObjectProperty("ProcedimentosMedicosArea", gxTv_SdtProcedimentosMedicos_Procedimentosmedicosarea, false, includeNonInitialized);
         AddObjectProperty("ProcedimentosMedicosArea_N", gxTv_SdtProcedimentosMedicos_Procedimentosmedicosarea_N, false, includeNonInitialized);
         AddObjectProperty("CID", gxTv_SdtProcedimentosMedicos_Cid, false, includeNonInitialized);
         AddObjectProperty("CID_N", gxTv_SdtProcedimentosMedicos_Cid_N, false, includeNonInitialized);
         AddObjectProperty("ProcedimentosMedicosAtivo", gxTv_SdtProcedimentosMedicos_Procedimentosmedicosativo, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtProcedimentosMedicos_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtProcedimentosMedicos_Initialized, false, includeNonInitialized);
            AddObjectProperty("ProcedimentosMedicosId_Z", gxTv_SdtProcedimentosMedicos_Procedimentosmedicosid_Z, false, includeNonInitialized);
            AddObjectProperty("ProcedimentosMedicosNome_Z", gxTv_SdtProcedimentosMedicos_Procedimentosmedicosnome_Z, false, includeNonInitialized);
            AddObjectProperty("ProcedimentosMedicosArea_Z", gxTv_SdtProcedimentosMedicos_Procedimentosmedicosarea_Z, false, includeNonInitialized);
            AddObjectProperty("CID_Z", gxTv_SdtProcedimentosMedicos_Cid_Z, false, includeNonInitialized);
            AddObjectProperty("ProcedimentosMedicosAtivo_Z", gxTv_SdtProcedimentosMedicos_Procedimentosmedicosativo_Z, false, includeNonInitialized);
            AddObjectProperty("ProcedimentosMedicosId_N", gxTv_SdtProcedimentosMedicos_Procedimentosmedicosid_N, false, includeNonInitialized);
            AddObjectProperty("ProcedimentosMedicosNome_N", gxTv_SdtProcedimentosMedicos_Procedimentosmedicosnome_N, false, includeNonInitialized);
            AddObjectProperty("ProcedimentosMedicosDescricao_N", gxTv_SdtProcedimentosMedicos_Procedimentosmedicosdescricao_N, false, includeNonInitialized);
            AddObjectProperty("ProcedimentosMedicosArea_N", gxTv_SdtProcedimentosMedicos_Procedimentosmedicosarea_N, false, includeNonInitialized);
            AddObjectProperty("CID_N", gxTv_SdtProcedimentosMedicos_Cid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtProcedimentosMedicos sdt )
      {
         if ( sdt.IsDirty("ProcedimentosMedicosId") )
         {
            sdtIsNull = 0;
            gxTv_SdtProcedimentosMedicos_Procedimentosmedicosid = sdt.gxTv_SdtProcedimentosMedicos_Procedimentosmedicosid ;
         }
         if ( sdt.IsDirty("ProcedimentosMedicosNome") )
         {
            gxTv_SdtProcedimentosMedicos_Procedimentosmedicosnome_N = (short)(sdt.gxTv_SdtProcedimentosMedicos_Procedimentosmedicosnome_N);
            sdtIsNull = 0;
            gxTv_SdtProcedimentosMedicos_Procedimentosmedicosnome = sdt.gxTv_SdtProcedimentosMedicos_Procedimentosmedicosnome ;
         }
         if ( sdt.IsDirty("ProcedimentosMedicosDescricao") )
         {
            gxTv_SdtProcedimentosMedicos_Procedimentosmedicosdescricao_N = (short)(sdt.gxTv_SdtProcedimentosMedicos_Procedimentosmedicosdescricao_N);
            sdtIsNull = 0;
            gxTv_SdtProcedimentosMedicos_Procedimentosmedicosdescricao = sdt.gxTv_SdtProcedimentosMedicos_Procedimentosmedicosdescricao ;
         }
         if ( sdt.IsDirty("ProcedimentosMedicosArea") )
         {
            gxTv_SdtProcedimentosMedicos_Procedimentosmedicosarea_N = (short)(sdt.gxTv_SdtProcedimentosMedicos_Procedimentosmedicosarea_N);
            sdtIsNull = 0;
            gxTv_SdtProcedimentosMedicos_Procedimentosmedicosarea = sdt.gxTv_SdtProcedimentosMedicos_Procedimentosmedicosarea ;
         }
         if ( sdt.IsDirty("CID") )
         {
            gxTv_SdtProcedimentosMedicos_Cid_N = (short)(sdt.gxTv_SdtProcedimentosMedicos_Cid_N);
            sdtIsNull = 0;
            gxTv_SdtProcedimentosMedicos_Cid = sdt.gxTv_SdtProcedimentosMedicos_Cid ;
         }
         if ( sdt.IsDirty("ProcedimentosMedicosAtivo") )
         {
            sdtIsNull = 0;
            gxTv_SdtProcedimentosMedicos_Procedimentosmedicosativo = sdt.gxTv_SdtProcedimentosMedicos_Procedimentosmedicosativo ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ProcedimentosMedicosId" )]
      [  XmlElement( ElementName = "ProcedimentosMedicosId"   )]
      public int gxTpr_Procedimentosmedicosid
      {
         get {
            return gxTv_SdtProcedimentosMedicos_Procedimentosmedicosid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtProcedimentosMedicos_Procedimentosmedicosid != value )
            {
               gxTv_SdtProcedimentosMedicos_Mode = "INS";
               this.gxTv_SdtProcedimentosMedicos_Procedimentosmedicosid_Z_SetNull( );
               this.gxTv_SdtProcedimentosMedicos_Procedimentosmedicosnome_Z_SetNull( );
               this.gxTv_SdtProcedimentosMedicos_Procedimentosmedicosarea_Z_SetNull( );
               this.gxTv_SdtProcedimentosMedicos_Cid_Z_SetNull( );
               this.gxTv_SdtProcedimentosMedicos_Procedimentosmedicosativo_Z_SetNull( );
            }
            gxTv_SdtProcedimentosMedicos_Procedimentosmedicosid = value;
            SetDirty("Procedimentosmedicosid");
         }

      }

      [  SoapElement( ElementName = "ProcedimentosMedicosNome" )]
      [  XmlElement( ElementName = "ProcedimentosMedicosNome"   )]
      public string gxTpr_Procedimentosmedicosnome
      {
         get {
            return gxTv_SdtProcedimentosMedicos_Procedimentosmedicosnome ;
         }

         set {
            gxTv_SdtProcedimentosMedicos_Procedimentosmedicosnome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProcedimentosMedicos_Procedimentosmedicosnome = value;
            SetDirty("Procedimentosmedicosnome");
         }

      }

      public void gxTv_SdtProcedimentosMedicos_Procedimentosmedicosnome_SetNull( )
      {
         gxTv_SdtProcedimentosMedicos_Procedimentosmedicosnome_N = 1;
         gxTv_SdtProcedimentosMedicos_Procedimentosmedicosnome = "";
         SetDirty("Procedimentosmedicosnome");
         return  ;
      }

      public bool gxTv_SdtProcedimentosMedicos_Procedimentosmedicosnome_IsNull( )
      {
         return (gxTv_SdtProcedimentosMedicos_Procedimentosmedicosnome_N==1) ;
      }

      [  SoapElement( ElementName = "ProcedimentosMedicosDescricao" )]
      [  XmlElement( ElementName = "ProcedimentosMedicosDescricao"   )]
      public string gxTpr_Procedimentosmedicosdescricao
      {
         get {
            return gxTv_SdtProcedimentosMedicos_Procedimentosmedicosdescricao ;
         }

         set {
            gxTv_SdtProcedimentosMedicos_Procedimentosmedicosdescricao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProcedimentosMedicos_Procedimentosmedicosdescricao = value;
            SetDirty("Procedimentosmedicosdescricao");
         }

      }

      public void gxTv_SdtProcedimentosMedicos_Procedimentosmedicosdescricao_SetNull( )
      {
         gxTv_SdtProcedimentosMedicos_Procedimentosmedicosdescricao_N = 1;
         gxTv_SdtProcedimentosMedicos_Procedimentosmedicosdescricao = "";
         SetDirty("Procedimentosmedicosdescricao");
         return  ;
      }

      public bool gxTv_SdtProcedimentosMedicos_Procedimentosmedicosdescricao_IsNull( )
      {
         return (gxTv_SdtProcedimentosMedicos_Procedimentosmedicosdescricao_N==1) ;
      }

      [  SoapElement( ElementName = "ProcedimentosMedicosArea" )]
      [  XmlElement( ElementName = "ProcedimentosMedicosArea"   )]
      public string gxTpr_Procedimentosmedicosarea
      {
         get {
            return gxTv_SdtProcedimentosMedicos_Procedimentosmedicosarea ;
         }

         set {
            gxTv_SdtProcedimentosMedicos_Procedimentosmedicosarea_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProcedimentosMedicos_Procedimentosmedicosarea = value;
            SetDirty("Procedimentosmedicosarea");
         }

      }

      public void gxTv_SdtProcedimentosMedicos_Procedimentosmedicosarea_SetNull( )
      {
         gxTv_SdtProcedimentosMedicos_Procedimentosmedicosarea_N = 1;
         gxTv_SdtProcedimentosMedicos_Procedimentosmedicosarea = "";
         SetDirty("Procedimentosmedicosarea");
         return  ;
      }

      public bool gxTv_SdtProcedimentosMedicos_Procedimentosmedicosarea_IsNull( )
      {
         return (gxTv_SdtProcedimentosMedicos_Procedimentosmedicosarea_N==1) ;
      }

      [  SoapElement( ElementName = "CID" )]
      [  XmlElement( ElementName = "CID"   )]
      public int gxTpr_Cid
      {
         get {
            return gxTv_SdtProcedimentosMedicos_Cid ;
         }

         set {
            gxTv_SdtProcedimentosMedicos_Cid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProcedimentosMedicos_Cid = value;
            SetDirty("Cid");
         }

      }

      public void gxTv_SdtProcedimentosMedicos_Cid_SetNull( )
      {
         gxTv_SdtProcedimentosMedicos_Cid_N = 1;
         gxTv_SdtProcedimentosMedicos_Cid = 0;
         SetDirty("Cid");
         return  ;
      }

      public bool gxTv_SdtProcedimentosMedicos_Cid_IsNull( )
      {
         return (gxTv_SdtProcedimentosMedicos_Cid_N==1) ;
      }

      [  SoapElement( ElementName = "ProcedimentosMedicosAtivo" )]
      [  XmlElement( ElementName = "ProcedimentosMedicosAtivo"   )]
      public bool gxTpr_Procedimentosmedicosativo
      {
         get {
            return gxTv_SdtProcedimentosMedicos_Procedimentosmedicosativo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProcedimentosMedicos_Procedimentosmedicosativo = value;
            SetDirty("Procedimentosmedicosativo");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtProcedimentosMedicos_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProcedimentosMedicos_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtProcedimentosMedicos_Mode_SetNull( )
      {
         gxTv_SdtProcedimentosMedicos_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtProcedimentosMedicos_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtProcedimentosMedicos_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProcedimentosMedicos_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtProcedimentosMedicos_Initialized_SetNull( )
      {
         gxTv_SdtProcedimentosMedicos_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtProcedimentosMedicos_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProcedimentosMedicosId_Z" )]
      [  XmlElement( ElementName = "ProcedimentosMedicosId_Z"   )]
      public int gxTpr_Procedimentosmedicosid_Z
      {
         get {
            return gxTv_SdtProcedimentosMedicos_Procedimentosmedicosid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProcedimentosMedicos_Procedimentosmedicosid_Z = value;
            SetDirty("Procedimentosmedicosid_Z");
         }

      }

      public void gxTv_SdtProcedimentosMedicos_Procedimentosmedicosid_Z_SetNull( )
      {
         gxTv_SdtProcedimentosMedicos_Procedimentosmedicosid_Z = 0;
         SetDirty("Procedimentosmedicosid_Z");
         return  ;
      }

      public bool gxTv_SdtProcedimentosMedicos_Procedimentosmedicosid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProcedimentosMedicosNome_Z" )]
      [  XmlElement( ElementName = "ProcedimentosMedicosNome_Z"   )]
      public string gxTpr_Procedimentosmedicosnome_Z
      {
         get {
            return gxTv_SdtProcedimentosMedicos_Procedimentosmedicosnome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProcedimentosMedicos_Procedimentosmedicosnome_Z = value;
            SetDirty("Procedimentosmedicosnome_Z");
         }

      }

      public void gxTv_SdtProcedimentosMedicos_Procedimentosmedicosnome_Z_SetNull( )
      {
         gxTv_SdtProcedimentosMedicos_Procedimentosmedicosnome_Z = "";
         SetDirty("Procedimentosmedicosnome_Z");
         return  ;
      }

      public bool gxTv_SdtProcedimentosMedicos_Procedimentosmedicosnome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProcedimentosMedicosArea_Z" )]
      [  XmlElement( ElementName = "ProcedimentosMedicosArea_Z"   )]
      public string gxTpr_Procedimentosmedicosarea_Z
      {
         get {
            return gxTv_SdtProcedimentosMedicos_Procedimentosmedicosarea_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProcedimentosMedicos_Procedimentosmedicosarea_Z = value;
            SetDirty("Procedimentosmedicosarea_Z");
         }

      }

      public void gxTv_SdtProcedimentosMedicos_Procedimentosmedicosarea_Z_SetNull( )
      {
         gxTv_SdtProcedimentosMedicos_Procedimentosmedicosarea_Z = "";
         SetDirty("Procedimentosmedicosarea_Z");
         return  ;
      }

      public bool gxTv_SdtProcedimentosMedicos_Procedimentosmedicosarea_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CID_Z" )]
      [  XmlElement( ElementName = "CID_Z"   )]
      public int gxTpr_Cid_Z
      {
         get {
            return gxTv_SdtProcedimentosMedicos_Cid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProcedimentosMedicos_Cid_Z = value;
            SetDirty("Cid_Z");
         }

      }

      public void gxTv_SdtProcedimentosMedicos_Cid_Z_SetNull( )
      {
         gxTv_SdtProcedimentosMedicos_Cid_Z = 0;
         SetDirty("Cid_Z");
         return  ;
      }

      public bool gxTv_SdtProcedimentosMedicos_Cid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProcedimentosMedicosAtivo_Z" )]
      [  XmlElement( ElementName = "ProcedimentosMedicosAtivo_Z"   )]
      public bool gxTpr_Procedimentosmedicosativo_Z
      {
         get {
            return gxTv_SdtProcedimentosMedicos_Procedimentosmedicosativo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProcedimentosMedicos_Procedimentosmedicosativo_Z = value;
            SetDirty("Procedimentosmedicosativo_Z");
         }

      }

      public void gxTv_SdtProcedimentosMedicos_Procedimentosmedicosativo_Z_SetNull( )
      {
         gxTv_SdtProcedimentosMedicos_Procedimentosmedicosativo_Z = false;
         SetDirty("Procedimentosmedicosativo_Z");
         return  ;
      }

      public bool gxTv_SdtProcedimentosMedicos_Procedimentosmedicosativo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProcedimentosMedicosId_N" )]
      [  XmlElement( ElementName = "ProcedimentosMedicosId_N"   )]
      public short gxTpr_Procedimentosmedicosid_N
      {
         get {
            return gxTv_SdtProcedimentosMedicos_Procedimentosmedicosid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProcedimentosMedicos_Procedimentosmedicosid_N = value;
            SetDirty("Procedimentosmedicosid_N");
         }

      }

      public void gxTv_SdtProcedimentosMedicos_Procedimentosmedicosid_N_SetNull( )
      {
         gxTv_SdtProcedimentosMedicos_Procedimentosmedicosid_N = 0;
         SetDirty("Procedimentosmedicosid_N");
         return  ;
      }

      public bool gxTv_SdtProcedimentosMedicos_Procedimentosmedicosid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProcedimentosMedicosNome_N" )]
      [  XmlElement( ElementName = "ProcedimentosMedicosNome_N"   )]
      public short gxTpr_Procedimentosmedicosnome_N
      {
         get {
            return gxTv_SdtProcedimentosMedicos_Procedimentosmedicosnome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProcedimentosMedicos_Procedimentosmedicosnome_N = value;
            SetDirty("Procedimentosmedicosnome_N");
         }

      }

      public void gxTv_SdtProcedimentosMedicos_Procedimentosmedicosnome_N_SetNull( )
      {
         gxTv_SdtProcedimentosMedicos_Procedimentosmedicosnome_N = 0;
         SetDirty("Procedimentosmedicosnome_N");
         return  ;
      }

      public bool gxTv_SdtProcedimentosMedicos_Procedimentosmedicosnome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProcedimentosMedicosDescricao_N" )]
      [  XmlElement( ElementName = "ProcedimentosMedicosDescricao_N"   )]
      public short gxTpr_Procedimentosmedicosdescricao_N
      {
         get {
            return gxTv_SdtProcedimentosMedicos_Procedimentosmedicosdescricao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProcedimentosMedicos_Procedimentosmedicosdescricao_N = value;
            SetDirty("Procedimentosmedicosdescricao_N");
         }

      }

      public void gxTv_SdtProcedimentosMedicos_Procedimentosmedicosdescricao_N_SetNull( )
      {
         gxTv_SdtProcedimentosMedicos_Procedimentosmedicosdescricao_N = 0;
         SetDirty("Procedimentosmedicosdescricao_N");
         return  ;
      }

      public bool gxTv_SdtProcedimentosMedicos_Procedimentosmedicosdescricao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProcedimentosMedicosArea_N" )]
      [  XmlElement( ElementName = "ProcedimentosMedicosArea_N"   )]
      public short gxTpr_Procedimentosmedicosarea_N
      {
         get {
            return gxTv_SdtProcedimentosMedicos_Procedimentosmedicosarea_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProcedimentosMedicos_Procedimentosmedicosarea_N = value;
            SetDirty("Procedimentosmedicosarea_N");
         }

      }

      public void gxTv_SdtProcedimentosMedicos_Procedimentosmedicosarea_N_SetNull( )
      {
         gxTv_SdtProcedimentosMedicos_Procedimentosmedicosarea_N = 0;
         SetDirty("Procedimentosmedicosarea_N");
         return  ;
      }

      public bool gxTv_SdtProcedimentosMedicos_Procedimentosmedicosarea_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CID_N" )]
      [  XmlElement( ElementName = "CID_N"   )]
      public short gxTpr_Cid_N
      {
         get {
            return gxTv_SdtProcedimentosMedicos_Cid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProcedimentosMedicos_Cid_N = value;
            SetDirty("Cid_N");
         }

      }

      public void gxTv_SdtProcedimentosMedicos_Cid_N_SetNull( )
      {
         gxTv_SdtProcedimentosMedicos_Cid_N = 0;
         SetDirty("Cid_N");
         return  ;
      }

      public bool gxTv_SdtProcedimentosMedicos_Cid_N_IsNull( )
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
         gxTv_SdtProcedimentosMedicos_Procedimentosmedicosnome = "";
         gxTv_SdtProcedimentosMedicos_Procedimentosmedicosdescricao = "";
         gxTv_SdtProcedimentosMedicos_Procedimentosmedicosarea = "";
         gxTv_SdtProcedimentosMedicos_Mode = "";
         gxTv_SdtProcedimentosMedicos_Procedimentosmedicosnome_Z = "";
         gxTv_SdtProcedimentosMedicos_Procedimentosmedicosarea_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "procedimentosmedicos", "GeneXus.Programs.procedimentosmedicos_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtProcedimentosMedicos_Initialized ;
      private short gxTv_SdtProcedimentosMedicos_Procedimentosmedicosid_N ;
      private short gxTv_SdtProcedimentosMedicos_Procedimentosmedicosnome_N ;
      private short gxTv_SdtProcedimentosMedicos_Procedimentosmedicosdescricao_N ;
      private short gxTv_SdtProcedimentosMedicos_Procedimentosmedicosarea_N ;
      private short gxTv_SdtProcedimentosMedicos_Cid_N ;
      private int gxTv_SdtProcedimentosMedicos_Procedimentosmedicosid ;
      private int gxTv_SdtProcedimentosMedicos_Cid ;
      private int gxTv_SdtProcedimentosMedicos_Procedimentosmedicosid_Z ;
      private int gxTv_SdtProcedimentosMedicos_Cid_Z ;
      private string gxTv_SdtProcedimentosMedicos_Mode ;
      private bool gxTv_SdtProcedimentosMedicos_Procedimentosmedicosativo ;
      private bool gxTv_SdtProcedimentosMedicos_Procedimentosmedicosativo_Z ;
      private string gxTv_SdtProcedimentosMedicos_Procedimentosmedicosdescricao ;
      private string gxTv_SdtProcedimentosMedicos_Procedimentosmedicosnome ;
      private string gxTv_SdtProcedimentosMedicos_Procedimentosmedicosarea ;
      private string gxTv_SdtProcedimentosMedicos_Procedimentosmedicosnome_Z ;
      private string gxTv_SdtProcedimentosMedicos_Procedimentosmedicosarea_Z ;
   }

   [DataContract(Name = @"ProcedimentosMedicos", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtProcedimentosMedicos_RESTInterface : GxGenericCollectionItem<SdtProcedimentosMedicos>
   {
      public SdtProcedimentosMedicos_RESTInterface( ) : base()
      {
      }

      public SdtProcedimentosMedicos_RESTInterface( SdtProcedimentosMedicos psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ProcedimentosMedicosId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Procedimentosmedicosid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Procedimentosmedicosid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Procedimentosmedicosid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ProcedimentosMedicosNome" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Procedimentosmedicosnome
      {
         get {
            return sdt.gxTpr_Procedimentosmedicosnome ;
         }

         set {
            sdt.gxTpr_Procedimentosmedicosnome = value;
         }

      }

      [DataMember( Name = "ProcedimentosMedicosDescricao" , Order = 2 )]
      public string gxTpr_Procedimentosmedicosdescricao
      {
         get {
            return sdt.gxTpr_Procedimentosmedicosdescricao ;
         }

         set {
            sdt.gxTpr_Procedimentosmedicosdescricao = value;
         }

      }

      [DataMember( Name = "ProcedimentosMedicosArea" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Procedimentosmedicosarea
      {
         get {
            return sdt.gxTpr_Procedimentosmedicosarea ;
         }

         set {
            sdt.gxTpr_Procedimentosmedicosarea = value;
         }

      }

      [DataMember( Name = "CID" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Cid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Cid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Cid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ProcedimentosMedicosAtivo" , Order = 5 )]
      [GxSeudo()]
      public bool gxTpr_Procedimentosmedicosativo
      {
         get {
            return sdt.gxTpr_Procedimentosmedicosativo ;
         }

         set {
            sdt.gxTpr_Procedimentosmedicosativo = value;
         }

      }

      public SdtProcedimentosMedicos sdt
      {
         get {
            return (SdtProcedimentosMedicos)Sdt ;
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
            sdt = new SdtProcedimentosMedicos() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 6 )]
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

   [DataContract(Name = @"ProcedimentosMedicos", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtProcedimentosMedicos_RESTLInterface : GxGenericCollectionItem<SdtProcedimentosMedicos>
   {
      public SdtProcedimentosMedicos_RESTLInterface( ) : base()
      {
      }

      public SdtProcedimentosMedicos_RESTLInterface( SdtProcedimentosMedicos psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ProcedimentosMedicosNome" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Procedimentosmedicosnome
      {
         get {
            return sdt.gxTpr_Procedimentosmedicosnome ;
         }

         set {
            sdt.gxTpr_Procedimentosmedicosnome = value;
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

      public SdtProcedimentosMedicos sdt
      {
         get {
            return (SdtProcedimentosMedicos)Sdt ;
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
            sdt = new SdtProcedimentosMedicos() ;
         }
      }

   }

}
