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
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class prlerxml : GXProcedure
   {
      public prlerxml( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prlerxml( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_StringNota ,
                           out SdtSdNotaFiscal aP1_SdNotaFiscal )
      {
         this.AV15StringNota = aP0_StringNota;
         this.AV8SdNotaFiscal = new SdtSdNotaFiscal(context) ;
         initialize();
         ExecuteImpl();
         aP1_SdNotaFiscal=this.AV8SdNotaFiscal;
      }

      public SdtSdNotaFiscal executeUdp( string aP0_StringNota )
      {
         execute(aP0_StringNota, out aP1_SdNotaFiscal);
         return AV8SdNotaFiscal ;
      }

      public void executeSubmit( string aP0_StringNota ,
                                 out SdtSdNotaFiscal aP1_SdNotaFiscal )
      {
         this.AV15StringNota = aP0_StringNota;
         this.AV8SdNotaFiscal = new SdtSdNotaFiscal(context) ;
         SubmitImpl();
         aP1_SdNotaFiscal=this.AV8SdNotaFiscal;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10XMLReader.OpenFromString(AV15StringNota);
         AV8SdNotaFiscal = new SdtSdNotaFiscal(context);
         AV23IsRetirada = false;
         AV24IsEntrega = false;
         AV25SdNotaFiscalCobrancaDup = new SdtSdNotaFiscal_NFe_infNFe_cobr_dupItem(context);
         while ( AV10XMLReader.Read() > 0 )
         {
            AV12NodeType = AV10XMLReader.NodeType;
            AV11NodeName = AV10XMLReader.Name;
            AV13NodeValue = AV10XMLReader.Value;
            if ( AV10XMLReader.AttributeCount > 0 )
            {
               AV16i = 1;
               while ( AV16i <= AV10XMLReader.AttributeCount )
               {
                  AV17attrName = AV10XMLReader.GetAttributeName(AV16i);
                  AV18attrValue = AV10XMLReader.GetAttributeByIndex(AV16i);
                  AV19attrLine = "    Atributo: " + AV17attrName + " = " + AV18attrValue;
                  AV20AllInfo += AV19attrLine + StringUtil.NewLine( );
                  /* Execute user subroutine: 'FEEDSDT' */
                  S111 ();
                  if ( returnInSub )
                  {
                     cleanup();
                     if (true) return;
                  }
                  AV16i = (short)(AV16i+1);
               }
               AV17attrName = "";
               AV18attrValue = "";
            }
            /* Execute user subroutine: 'FEEDSDT' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'FEEDSDT' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV11NodeName, "infNFe") == 0 )
         {
            if ( StringUtil.StrCmp(AV17attrName, "Id") == 0 )
            {
               AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Id = AV18attrValue;
            }
            if ( StringUtil.StrCmp(AV17attrName, "versao") == 0 )
            {
               AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Versao = AV18attrValue;
            }
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "cUF") == 0 )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Ide.gxTpr_Cuf = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "cNF") == 0 )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Ide.gxTpr_Cnf = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "natOp") == 0 )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Ide.gxTpr_Natop = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "indPag") == 0 )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Ide.gxTpr_Indpag = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "mod") == 0 )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Ide.gxTpr_Mod = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "serie") == 0 )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Ide.gxTpr_Serie = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "nNF") == 0 )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Ide.gxTpr_Nnf = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "dEmi") == 0 )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Ide.gxTpr_Demi = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "dSaiEnt") == 0 )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Ide.gxTpr_Dsaient = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "tpNF") == 0 )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Ide.gxTpr_Tpnf = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "cMunFG") == 0 )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Ide.gxTpr_Cmunfg = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "tpImp") == 0 )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Ide.gxTpr_Tpimp = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "tpEmis") == 0 )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Ide.gxTpr_Tpemis = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "cDV") == 0 )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Ide.gxTpr_Cdv = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "tpAmb") == 0 )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Ide.gxTpr_Tpamb = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "finNFe") == 0 )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Ide.gxTpr_Finnfe = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "procEmi") == 0 )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Ide.gxTpr_Procemi = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "verProc") == 0 )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Ide.gxTpr_Verproc = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "emit") == 0 )
         {
            AV22IsEmitente = true;
         }
         else if ( ( StringUtil.StrCmp(AV11NodeName, "CNPJ") == 0 ) && AV22IsEmitente )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Emit.gxTpr_Cnpj = AV13NodeValue;
         }
         else if ( ( StringUtil.StrCmp(AV11NodeName, "xNome") == 0 ) && AV22IsEmitente )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Emit.gxTpr_Xnome = AV13NodeValue;
         }
         else if ( ( StringUtil.StrCmp(AV11NodeName, "xFant") == 0 ) && AV22IsEmitente )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Emit.gxTpr_Xfant = AV13NodeValue;
         }
         else if ( ( StringUtil.StrCmp(AV11NodeName, "enderEmit") == 0 ) && AV22IsEmitente )
         {
         }
         else if ( ( StringUtil.StrCmp(AV11NodeName, "xLgr") == 0 ) && AV22IsEmitente )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Emit.gxTpr_Enderemit.gxTpr_Xlgr = AV13NodeValue;
         }
         else if ( ( StringUtil.StrCmp(AV11NodeName, "nro") == 0 ) && AV22IsEmitente )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Emit.gxTpr_Enderemit.gxTpr_Nro = AV13NodeValue;
         }
         else if ( ( StringUtil.StrCmp(AV11NodeName, "xCpl") == 0 ) && AV22IsEmitente )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Emit.gxTpr_Enderemit.gxTpr_Xcpl = AV13NodeValue;
         }
         else if ( ( StringUtil.StrCmp(AV11NodeName, "xBairro") == 0 ) && AV22IsEmitente )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Emit.gxTpr_Enderemit.gxTpr_Xbairro = AV13NodeValue;
         }
         else if ( ( StringUtil.StrCmp(AV11NodeName, "cMun") == 0 ) && AV22IsEmitente )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Emit.gxTpr_Enderemit.gxTpr_Cmun = AV13NodeValue;
         }
         else if ( ( StringUtil.StrCmp(AV11NodeName, "xMun") == 0 ) && AV22IsEmitente )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Emit.gxTpr_Enderemit.gxTpr_Xmun = AV13NodeValue;
         }
         else if ( ( StringUtil.StrCmp(AV11NodeName, "UF") == 0 ) && AV22IsEmitente )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Emit.gxTpr_Enderemit.gxTpr_Uf = AV13NodeValue;
         }
         else if ( ( StringUtil.StrCmp(AV11NodeName, "CEP") == 0 ) && AV22IsEmitente )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Emit.gxTpr_Enderemit.gxTpr_Cep = AV13NodeValue;
         }
         else if ( ( StringUtil.StrCmp(AV11NodeName, "cPais") == 0 ) && AV22IsEmitente )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Emit.gxTpr_Enderemit.gxTpr_Cpais = AV13NodeValue;
         }
         else if ( ( StringUtil.StrCmp(AV11NodeName, "xPais") == 0 ) && AV22IsEmitente )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Emit.gxTpr_Enderemit.gxTpr_Xpais = AV13NodeValue;
         }
         else if ( ( StringUtil.StrCmp(AV11NodeName, "fone") == 0 ) && AV22IsEmitente )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Emit.gxTpr_Enderemit.gxTpr_Fone = AV13NodeValue;
         }
         else if ( ( StringUtil.StrCmp(AV11NodeName, "IE") == 0 ) && AV22IsEmitente )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Emit.gxTpr_Ie = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "dest") == 0 )
         {
            AV22IsEmitente = false;
         }
         else if ( ( StringUtil.StrCmp(AV11NodeName, "CNPJ") == 0 ) && ! AV22IsEmitente )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Dest.gxTpr_Cnpj = AV13NodeValue;
         }
         else if ( ( StringUtil.StrCmp(AV11NodeName, "CPF") == 0 ) && ! AV22IsEmitente )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Dest.gxTpr_Cpf = AV13NodeValue;
         }
         else if ( ( StringUtil.StrCmp(AV11NodeName, "xNome") == 0 ) && ! AV22IsEmitente )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Dest.gxTpr_Xnome = AV13NodeValue;
         }
         else if ( ( StringUtil.StrCmp(AV11NodeName, "enderDest") == 0 ) && ! AV22IsEmitente )
         {
         }
         else if ( ( StringUtil.StrCmp(AV11NodeName, "xLgr") == 0 ) && ! AV22IsEmitente )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Dest.gxTpr_Enderdest.gxTpr_Xlgr = AV13NodeValue;
         }
         else if ( ( StringUtil.StrCmp(AV11NodeName, "nro") == 0 ) && ! AV22IsEmitente )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Dest.gxTpr_Enderdest.gxTpr_Nro = AV13NodeValue;
         }
         else if ( ( StringUtil.StrCmp(AV11NodeName, "xCpl") == 0 ) && ! AV22IsEmitente )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Dest.gxTpr_Enderdest.gxTpr_Xcpl = AV13NodeValue;
         }
         else if ( ( StringUtil.StrCmp(AV11NodeName, "xBairro") == 0 ) && ! AV22IsEmitente )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Dest.gxTpr_Enderdest.gxTpr_Xbairro = AV13NodeValue;
         }
         else if ( ( StringUtil.StrCmp(AV11NodeName, "cMun") == 0 ) && ! AV22IsEmitente )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Dest.gxTpr_Enderdest.gxTpr_Cmun = AV13NodeValue;
         }
         else if ( ( StringUtil.StrCmp(AV11NodeName, "xMun") == 0 ) && ! AV22IsEmitente )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Dest.gxTpr_Enderdest.gxTpr_Xmun = AV13NodeValue;
         }
         else if ( ( StringUtil.StrCmp(AV11NodeName, "UF") == 0 ) && ! AV22IsEmitente )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Dest.gxTpr_Enderdest.gxTpr_Uf = AV13NodeValue;
         }
         else if ( ( StringUtil.StrCmp(AV11NodeName, "CEP") == 0 ) && ! AV22IsEmitente )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Dest.gxTpr_Enderdest.gxTpr_Cep = AV13NodeValue;
         }
         else if ( ( StringUtil.StrCmp(AV11NodeName, "cPais") == 0 ) && ! AV22IsEmitente )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Dest.gxTpr_Enderdest.gxTpr_Cpais = AV13NodeValue;
         }
         else if ( ( StringUtil.StrCmp(AV11NodeName, "xPais") == 0 ) && ! AV22IsEmitente )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Dest.gxTpr_Enderdest.gxTpr_Xpais = AV13NodeValue;
         }
         else if ( ( StringUtil.StrCmp(AV11NodeName, "fone") == 0 ) && ! AV22IsEmitente )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Dest.gxTpr_Enderdest.gxTpr_Fone = AV13NodeValue;
         }
         else if ( ( StringUtil.StrCmp(AV11NodeName, "IE") == 0 ) && ! AV22IsEmitente )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Dest.gxTpr_Ie = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "retirada") == 0 )
         {
            AV23IsRetirada = true;
         }
         else if ( ( StringUtil.StrCmp(AV11NodeName, "CNPJ") == 0 ) && AV23IsRetirada )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Retirada.gxTpr_Cnpj = AV13NodeValue;
         }
         else if ( ( StringUtil.StrCmp(AV11NodeName, "xLgr") == 0 ) && AV23IsRetirada )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Retirada.gxTpr_Xlgr = AV13NodeValue;
         }
         else if ( ( StringUtil.StrCmp(AV11NodeName, "nro") == 0 ) && AV23IsRetirada )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Retirada.gxTpr_Nro = AV13NodeValue;
         }
         else if ( ( StringUtil.StrCmp(AV11NodeName, "xCpl") == 0 ) && AV23IsRetirada )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Retirada.gxTpr_Xcpl = AV13NodeValue;
         }
         else if ( ( StringUtil.StrCmp(AV11NodeName, "xBairro") == 0 ) && AV23IsRetirada )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Retirada.gxTpr_Xbairro = AV13NodeValue;
         }
         else if ( ( StringUtil.StrCmp(AV11NodeName, "cMun") == 0 ) && AV23IsRetirada )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Retirada.gxTpr_Cmun = AV13NodeValue;
         }
         else if ( ( StringUtil.StrCmp(AV11NodeName, "xMun") == 0 ) && AV23IsRetirada )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Retirada.gxTpr_Xmun = AV13NodeValue;
         }
         else if ( ( StringUtil.StrCmp(AV11NodeName, "UF") == 0 ) && AV23IsRetirada )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Retirada.gxTpr_Uf = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "entrega") == 0 )
         {
            AV24IsEntrega = true;
         }
         else if ( ( StringUtil.StrCmp(AV11NodeName, "CNPJ") == 0 ) && AV24IsEntrega )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Entrega.gxTpr_Cnpj = AV13NodeValue;
         }
         else if ( ( StringUtil.StrCmp(AV11NodeName, "xLgr") == 0 ) && AV24IsEntrega )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Entrega.gxTpr_Xlgr = AV13NodeValue;
         }
         else if ( ( StringUtil.StrCmp(AV11NodeName, "nro") == 0 ) && AV24IsEntrega )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Entrega.gxTpr_Nro = AV13NodeValue;
         }
         else if ( ( StringUtil.StrCmp(AV11NodeName, "xCpl") == 0 ) && AV24IsEntrega )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Entrega.gxTpr_Xcpl = AV13NodeValue;
         }
         else if ( ( StringUtil.StrCmp(AV11NodeName, "xBairro") == 0 ) && AV24IsEntrega )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Entrega.gxTpr_Xbairro = AV13NodeValue;
         }
         else if ( ( StringUtil.StrCmp(AV11NodeName, "cMun") == 0 ) && AV24IsEntrega )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Entrega.gxTpr_Cmun = AV13NodeValue;
         }
         else if ( ( StringUtil.StrCmp(AV11NodeName, "xMun") == 0 ) && AV24IsEntrega )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Entrega.gxTpr_Xmun = AV13NodeValue;
         }
         else if ( ( StringUtil.StrCmp(AV11NodeName, "UF") == 0 ) && AV24IsEntrega )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Entrega.gxTpr_Uf = AV13NodeValue;
         }
         else if ( ( StringUtil.StrCmp(AV11NodeName, "det") == 0 ) && ( AV12NodeType == 1 ) )
         {
            AV21SdNotaFiscalDet = new SdtSdNotaFiscal_NFe_infNFe_detItem(context);
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "cProd") == 0 )
         {
            AV21SdNotaFiscalDet.gxTpr_Prod.gxTpr_Cprod = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "cEAN") == 0 )
         {
            AV21SdNotaFiscalDet.gxTpr_Prod.gxTpr_Cean = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "xProd") == 0 )
         {
            AV21SdNotaFiscalDet.gxTpr_Prod.gxTpr_Xprod = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "CFOP") == 0 )
         {
            AV21SdNotaFiscalDet.gxTpr_Prod.gxTpr_Cfop = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "uCom") == 0 )
         {
            AV21SdNotaFiscalDet.gxTpr_Prod.gxTpr_Ucom = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "qCom") == 0 )
         {
            AV21SdNotaFiscalDet.gxTpr_Prod.gxTpr_Qcom = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "vUnCom") == 0 )
         {
            AV21SdNotaFiscalDet.gxTpr_Prod.gxTpr_Vuncom = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "vProd") == 0 )
         {
            AV21SdNotaFiscalDet.gxTpr_Prod.gxTpr_Vprod = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "cEANTrib") == 0 )
         {
            AV21SdNotaFiscalDet.gxTpr_Prod.gxTpr_Ceantrib = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "uTrib") == 0 )
         {
            AV21SdNotaFiscalDet.gxTpr_Prod.gxTpr_Utrib = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "qTrib") == 0 )
         {
            AV21SdNotaFiscalDet.gxTpr_Prod.gxTpr_Qtrib = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "vUnTrib") == 0 )
         {
            AV21SdNotaFiscalDet.gxTpr_Prod.gxTpr_Vuntrib = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "ICMS00") == 0 )
         {
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "orig") == 0 )
         {
            AV21SdNotaFiscalDet.gxTpr_Imposto.gxTpr_Icms.gxTpr_Icms00.gxTpr_Orig = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "CST") == 0 )
         {
            AV21SdNotaFiscalDet.gxTpr_Imposto.gxTpr_Icms.gxTpr_Icms00.gxTpr_Cst = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "modBC") == 0 )
         {
            AV21SdNotaFiscalDet.gxTpr_Imposto.gxTpr_Icms.gxTpr_Icms00.gxTpr_Modbc = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "vBC") == 0 )
         {
            AV21SdNotaFiscalDet.gxTpr_Imposto.gxTpr_Icms.gxTpr_Icms00.gxTpr_Vbc = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "pICMS") == 0 )
         {
            AV21SdNotaFiscalDet.gxTpr_Imposto.gxTpr_Icms.gxTpr_Icms00.gxTpr_Picms = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "vICMS") == 0 )
         {
            AV21SdNotaFiscalDet.gxTpr_Imposto.gxTpr_Icms.gxTpr_Icms00.gxTpr_Vicms = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "PISAliq") == 0 )
         {
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "CST") == 0 )
         {
            AV21SdNotaFiscalDet.gxTpr_Imposto.gxTpr_Pis.gxTpr_Pisaliq.gxTpr_Cst = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "vBC") == 0 )
         {
            AV21SdNotaFiscalDet.gxTpr_Imposto.gxTpr_Pis.gxTpr_Pisaliq.gxTpr_Vbc = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "pPIS") == 0 )
         {
            AV21SdNotaFiscalDet.gxTpr_Imposto.gxTpr_Pis.gxTpr_Pisaliq.gxTpr_Ppis = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "vPIS") == 0 )
         {
            AV21SdNotaFiscalDet.gxTpr_Imposto.gxTpr_Pis.gxTpr_Pisaliq.gxTpr_Vpis = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "COFINSAliq") == 0 )
         {
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "CST") == 0 )
         {
            AV21SdNotaFiscalDet.gxTpr_Imposto.gxTpr_Cofins.gxTpr_Cofinsaliq.gxTpr_Cst = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "vBC") == 0 )
         {
            AV21SdNotaFiscalDet.gxTpr_Imposto.gxTpr_Cofins.gxTpr_Cofinsaliq.gxTpr_Vbc = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "pCOFINS") == 0 )
         {
            AV21SdNotaFiscalDet.gxTpr_Imposto.gxTpr_Cofins.gxTpr_Cofinsaliq.gxTpr_Pcofins = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "vCOFINS") == 0 )
         {
            AV21SdNotaFiscalDet.gxTpr_Imposto.gxTpr_Cofins.gxTpr_Cofinsaliq.gxTpr_Vcofins = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "ICMSTot") == 0 )
         {
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "vBC") == 0 )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Total.gxTpr_Icmstot.gxTpr_Vbc = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "vICMS") == 0 )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Total.gxTpr_Icmstot.gxTpr_Vicms = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "vBCST") == 0 )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Total.gxTpr_Icmstot.gxTpr_Vbcst = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "vST") == 0 )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Total.gxTpr_Icmstot.gxTpr_Vst = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "vProd") == 0 )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Total.gxTpr_Icmstot.gxTpr_Vprod = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "vFrete") == 0 )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Total.gxTpr_Icmstot.gxTpr_Vfrete = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "vSeg") == 0 )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Total.gxTpr_Icmstot.gxTpr_Vseg = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "vDesc") == 0 )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Total.gxTpr_Icmstot.gxTpr_Vdesc = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "vII") == 0 )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Total.gxTpr_Icmstot.gxTpr_Vii = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "vIPI") == 0 )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Total.gxTpr_Icmstot.gxTpr_Vipi = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "vPIS") == 0 )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Total.gxTpr_Icmstot.gxTpr_Vpis = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "vCOFINS") == 0 )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Total.gxTpr_Icmstot.gxTpr_Vcofins = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "vOutro") == 0 )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Total.gxTpr_Icmstot.gxTpr_Voutro = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "vNF") == 0 )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Total.gxTpr_Icmstot.gxTpr_Vnf = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "modFrete") == 0 )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Transp.gxTpr_Modfrete = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "transporta") == 0 )
         {
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "CNPJ") == 0 )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Transp.gxTpr_Transporta.gxTpr_Cnpj = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "xNome") == 0 )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Transp.gxTpr_Transporta.gxTpr_Xnome = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "IE") == 0 )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Transp.gxTpr_Transporta.gxTpr_Ie = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "xEnder") == 0 )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Transp.gxTpr_Transporta.gxTpr_Xender = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "xMun") == 0 )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Transp.gxTpr_Transporta.gxTpr_Xmun = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "UF") == 0 )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Transp.gxTpr_Transporta.gxTpr_Uf = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "veicTransp") == 0 )
         {
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "placa") == 0 )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Transp.gxTpr_Veictransp.gxTpr_Placa = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "UF") == 0 )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Transp.gxTpr_Veictransp.gxTpr_Uf = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "RNTC") == 0 )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Transp.gxTpr_Veictransp.gxTpr_Rntc = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "reboque") == 0 )
         {
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "placa") == 0 )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Transp.gxTpr_Reboque.gxTpr_Placa = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "UF") == 0 )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Transp.gxTpr_Reboque.gxTpr_Uf = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "RNTC") == 0 )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Transp.gxTpr_Reboque.gxTpr_Rntc = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "vol") == 0 )
         {
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "qVol") == 0 )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Transp.gxTpr_Vol.gxTpr_Qvol = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "esp") == 0 )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Transp.gxTpr_Vol.gxTpr_Esp = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "marca") == 0 )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Transp.gxTpr_Vol.gxTpr_Marca = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "nVol") == 0 )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Transp.gxTpr_Vol.gxTpr_Nvol = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "pesoL") == 0 )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Transp.gxTpr_Vol.gxTpr_Pesol = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "pesoB") == 0 )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Transp.gxTpr_Vol.gxTpr_Pesob = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "lacres") == 0 )
         {
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "nLacre") == 0 )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Transp.gxTpr_Vol.gxTpr_Lacres.gxTpr_Nlacre = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "infAdFisco") == 0 )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Infadic.gxTpr_Infadfisco = AV13NodeValue;
         }
         else if ( ( StringUtil.StrCmp(AV11NodeName, "det") == 0 ) && ( AV12NodeType == 2 ) )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Det.Add(AV21SdNotaFiscalDet, 0);
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "fat") == 0 )
         {
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "nFat") == 0 )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Cobr.gxTpr_Fat.gxTpr_Nfat = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "vOrig") == 0 )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Cobr.gxTpr_Fat.gxTpr_Vorig = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "vDesc") == 0 )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Cobr.gxTpr_Fat.gxTpr_Vdesc = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "vLiq") == 0 )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Cobr.gxTpr_Fat.gxTpr_Vliq = AV13NodeValue;
         }
         else if ( ( StringUtil.StrCmp(AV11NodeName, "dup") == 0 ) && ( AV12NodeType == 2 ) )
         {
            AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Cobr.gxTpr_Dup.Add(AV25SdNotaFiscalCobrancaDup, 0);
         }
         else if ( ( StringUtil.StrCmp(AV11NodeName, "dup") == 0 ) && ( AV12NodeType == 1 ) )
         {
            AV25SdNotaFiscalCobrancaDup = new SdtSdNotaFiscal_NFe_infNFe_cobr_dupItem(context);
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "nDup") == 0 )
         {
            AV25SdNotaFiscalCobrancaDup.gxTpr_Ndup = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "dVenc") == 0 )
         {
            AV25SdNotaFiscalCobrancaDup.gxTpr_Dvenc = AV13NodeValue;
         }
         else if ( StringUtil.StrCmp(AV11NodeName, "vDup") == 0 )
         {
            AV25SdNotaFiscalCobrancaDup.gxTpr_Vdup = AV13NodeValue;
         }
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
         AV8SdNotaFiscal = new SdtSdNotaFiscal(context);
         AV10XMLReader = new GXXMLReader(context.GetPhysicalPath());
         AV25SdNotaFiscalCobrancaDup = new SdtSdNotaFiscal_NFe_infNFe_cobr_dupItem(context);
         AV11NodeName = "";
         AV13NodeValue = "";
         AV17attrName = "";
         AV18attrValue = "";
         AV19attrLine = "";
         AV20AllInfo = "";
         AV21SdNotaFiscalDet = new SdtSdNotaFiscal_NFe_infNFe_detItem(context);
         /* GeneXus formulas. */
      }

      private short AV12NodeType ;
      private short AV16i ;
      private bool AV23IsRetirada ;
      private bool AV24IsEntrega ;
      private bool returnInSub ;
      private bool AV22IsEmitente ;
      private string AV15StringNota ;
      private string AV11NodeName ;
      private string AV13NodeValue ;
      private string AV17attrName ;
      private string AV18attrValue ;
      private string AV19attrLine ;
      private string AV20AllInfo ;
      private GXXMLReader AV10XMLReader ;
      private SdtSdNotaFiscal AV8SdNotaFiscal ;
      private SdtSdNotaFiscal_NFe_infNFe_cobr_dupItem AV25SdNotaFiscalCobrancaDup ;
      private SdtSdNotaFiscal_NFe_infNFe_detItem AV21SdNotaFiscalDet ;
      private SdtSdNotaFiscal aP1_SdNotaFiscal ;
   }

}
