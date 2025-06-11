using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class prpropostastatuselement : GXProcedure
   {
      public prpropostastatuselement( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prpropostastatuselement( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_PropostaStatus ,
                           bool aP1_IsWithLabel ,
                           out string aP2_HTML )
      {
         this.AV10PropostaStatus = aP0_PropostaStatus;
         this.AV11IsWithLabel = aP1_IsWithLabel;
         this.AV9HTML = "" ;
         initialize();
         ExecuteImpl();
         aP2_HTML=this.AV9HTML;
      }

      public string executeUdp( string aP0_PropostaStatus ,
                                bool aP1_IsWithLabel )
      {
         execute(aP0_PropostaStatus, aP1_IsWithLabel, out aP2_HTML);
         return AV9HTML ;
      }

      public void executeSubmit( string aP0_PropostaStatus ,
                                 bool aP1_IsWithLabel ,
                                 out string aP2_HTML )
      {
         this.AV10PropostaStatus = aP0_PropostaStatus;
         this.AV11IsWithLabel = aP1_IsWithLabel;
         this.AV9HTML = "" ;
         SubmitImpl();
         aP2_HTML=this.AV9HTML;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! AV11IsWithLabel )
         {
            if ( StringUtil.StrCmp(AV10PropostaStatus, "PENDENTE") == 0 )
            {
               AV9HTML = "<span class=\"status-badge status-awaiting\">Aguardando Aprovação</span>";
            }
            else if ( StringUtil.StrCmp(AV10PropostaStatus, "AnaliseReprovada") == 0 )
            {
               AV9HTML = "<span class=\"status-badge status-rejected\">Análise Reprovada</span>";
            }
            else if ( StringUtil.StrCmp(AV10PropostaStatus, "APROVADO") == 0 )
            {
               AV9HTML = "<span class=\"status-badge status-approved\">Aprovado</span>";
            }
            else if ( StringUtil.StrCmp(AV10PropostaStatus, "CANCELADO") == 0 )
            {
               AV9HTML = "<span class=\"status-badge status-cancelled\">Cancelado</span>";
            }
            else if ( StringUtil.StrCmp(AV10PropostaStatus, "EM_ANALISE") == 0 )
            {
               AV9HTML = "<span class=\"status-badge status-in-progress\">Em Análise</span>";
            }
            else if ( StringUtil.StrCmp(AV10PropostaStatus, "REJEITADO") == 0 )
            {
               AV9HTML = "<span class=\"status-badge status-rejected\">Rejeitado</span>";
            }
            else if ( StringUtil.StrCmp(AV10PropostaStatus, "REVISAO") == 0 )
            {
               AV9HTML = "<span class=\"status-badge status-on-hold\">Em Revisão</span>";
            }
         }
         else
         {
            if ( StringUtil.StrCmp(AV10PropostaStatus, "PENDENTE") == 0 )
            {
               AV9HTML = "<div style=\"margin-top:3px;display:flex; width:100%; align-items:center;justify-content: space-between;\"><strong>Status</strong> <span class=\"status-badge status-awaiting\">Aguardando Aprovação</span></div>";
            }
            else if ( StringUtil.StrCmp(AV10PropostaStatus, "AnaliseReprovada") == 0 )
            {
               AV9HTML = "<div style=\"margin-top:3px;display:flex; width:100%; align-items:center;justify-content: space-between;\"><strong>Status</strong> <span class=\"status-badge status-rejected\">Análise Reprovada</span></div>";
            }
            else if ( StringUtil.StrCmp(AV10PropostaStatus, "APROVADO") == 0 )
            {
               AV9HTML = "<div style=\"margin-top:3px;display:flex; width:100%; align-items:center;justify-content: space-between;\"><strong>Status</strong> <span class=\"status-badge status-approved\">Aprovado</span></div>";
            }
            else if ( StringUtil.StrCmp(AV10PropostaStatus, "CANCELADO") == 0 )
            {
               AV9HTML = "<div style=\"margin-top:3px;display:flex; width:100%; align-items:center;justify-content: space-between;\"><strong>Status</strong> <span class=\"status-badge status-cancelled\">Cancelado</span></div>";
            }
            else if ( StringUtil.StrCmp(AV10PropostaStatus, "EM_ANALISE") == 0 )
            {
               AV9HTML = "<div style=\"margin-top:3px;display:flex; width:100%; align-items:center;justify-content: space-between;\"><strong>Status</strong> <span class=\"status-badge status-in-progress\">Em Análise</span></div>";
            }
            else if ( StringUtil.StrCmp(AV10PropostaStatus, "REJEITADO") == 0 )
            {
               AV9HTML = "<div style=\"margin-top:3px;display:flex; width:100%; align-items:center;justify-content: space-between;\"><strong>Status</strong> <span class=\"status-badge status-rejected\">Rejeitado</span></div>";
            }
            else if ( StringUtil.StrCmp(AV10PropostaStatus, "REVISAO") == 0 )
            {
               AV9HTML = "<div style=\"margin-top:3px;display:flex; width:100%; align-items:center;justify-content: space-between;\"><strong>Status</strong> <span class=\"status-badge status-on-hold\">Em Revisão</span></div>";
            }
         }
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV9HTML = "";
         /* GeneXus formulas. */
      }

      private bool AV11IsWithLabel ;
      private string AV9HTML ;
      private string AV10PropostaStatus ;
      private string aP2_HTML ;
   }

}
