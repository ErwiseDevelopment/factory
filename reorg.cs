using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
using System.Data;
using GeneXus.Data;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class reorg : GXReorganization
   {
      public reorg( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public reorg( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         SetCreateDataBase( ) ;
         CreateDataBase( ) ;
         if ( PreviousCheck() )
         {
            ExecuteReorganization( ) ;
         }
      }

      private void CreateDataBase( )
      {
         DS = (GxDataStore)(context.GetDataStore( "Default"));
         ErrCode = DS.Connection.FullConnect();
         DataBaseName = DS.Connection.Database;
         if ( ErrCode != 0 )
         {
            DS.Connection.Database = "postgres";
            ErrCode = DS.Connection.FullConnect();
            if ( ErrCode == 0 )
            {
               try
               {
                  GeneXus.Reorg.GXReorganization.AddMsg( GXResourceManager.GetMessage("GXM_dbcrea")+ " " +DataBaseName , null);
                  cmdBuffer = "CREATE DATABASE " + "\"" + DataBaseName + "\"";
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
                  Count = 1;
               }
               catch ( Exception ex )
               {
                  ErrCode = 1;
                  GeneXus.Reorg.GXReorganization.AddMsg( ex.Message , null);
                  throw;
               }
               ErrCode = DS.Connection.Disconnect();
               DS.Connection.Database = DataBaseName;
               ErrCode = DS.Connection.FullConnect();
               while ( ( ErrCode != 0 ) && ( Count > 0 ) && ( Count < 30 ) )
               {
                  Res = GXUtil.Sleep( 1);
                  ErrCode = DS.Connection.FullConnect();
                  Count = (short)(Count+1);
               }
            }
            if ( ErrCode != 0 )
            {
               ErrMsg = DS.ErrDescription;
               GeneXus.Reorg.GXReorganization.AddMsg( ErrMsg , null);
               ErrCode = 1;
               throw new Exception( ErrMsg) ;
            }
         }
      }

      private void FirstActions( )
      {
         /* Load data into tables. */
      }

      public void CreateRepresentante( )
      {
         string cmdBuffer = "";
         /* Indices for table Representante */
         try
         {
            cmdBuffer=" CREATE SEQUENCE RepresentanteId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE RepresentanteId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE RepresentanteId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE Representante (RepresentanteId integer NOT NULL DEFAULT nextval('RepresentanteId'), RepresentanteNome VARCHAR(100) , RepresentanteRG VARCHAR(40) , RepresentanteOrgaoExpedidor VARCHAR(40) , RepresentanteRGUF VARCHAR(40) , RepresentanteCPF VARCHAR(40) , RepresentanteEstadoCivil VARCHAR(40) , RepresentanteNacionalidade VARCHAR(60) , RepresentanteProfissao integer , RepresentanteEmail VARCHAR(100) , RepresentanteCEP VARCHAR(14) , RepresentanteLogradouro VARCHAR(100) , RepresentanteBairro VARCHAR(100) , RepresentanteCidade VARCHAR(100) , RepresentanteMunicipio VARCHAR(40) , RepresentanteLogradouroNumero bigint , RepresentanteComplemento VARCHAR(100) , RepresentanteDDD smallint , RepresentanteNumero integer , RepresentanteTipo VARCHAR(40) , ClienteId integer , PRIMARY KEY(RepresentanteId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Representante CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Representante CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Representante CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Representante (RepresentanteId integer NOT NULL DEFAULT nextval('RepresentanteId'), RepresentanteNome VARCHAR(100) , RepresentanteRG VARCHAR(40) , RepresentanteOrgaoExpedidor VARCHAR(40) , RepresentanteRGUF VARCHAR(40) , RepresentanteCPF VARCHAR(40) , RepresentanteEstadoCivil VARCHAR(40) , RepresentanteNacionalidade VARCHAR(60) , RepresentanteProfissao integer , RepresentanteEmail VARCHAR(100) , RepresentanteCEP VARCHAR(14) , RepresentanteLogradouro VARCHAR(100) , RepresentanteBairro VARCHAR(100) , RepresentanteCidade VARCHAR(100) , RepresentanteMunicipio VARCHAR(40) , RepresentanteLogradouroNumero bigint , RepresentanteComplemento VARCHAR(100) , RepresentanteDDD smallint , RepresentanteNumero integer , RepresentanteTipo VARCHAR(40) , ClienteId integer , PRIMARY KEY(RepresentanteId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IREPRESENTANTE1 ON Representante (RepresentanteProfissao ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IREPRESENTANTE1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IREPRESENTANTE1 ON Representante (RepresentanteProfissao ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IREPRESENTANTE2 ON Representante (RepresentanteMunicipio ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IREPRESENTANTE2 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IREPRESENTANTE2 ON Representante (RepresentanteMunicipio ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IREPRESENTANTE3 ON Representante (ClienteId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IREPRESENTANTE3 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IREPRESENTANTE3 ON Representante (ClienteId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateChavePIX( )
      {
         string cmdBuffer = "";
         /* Indices for table ChavePIX */
         try
         {
            cmdBuffer=" CREATE SEQUENCE ChavePIXId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE ChavePIXId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE ChavePIXId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE ChavePIX (ChavePIXId integer NOT NULL DEFAULT nextval('ChavePIXId'), ChavePIXTipo VARCHAR(40) , ChavePIXConteudo VARCHAR(100) , ChavePIXStatus BOOLEAN , ChavePIXPrincipal BOOLEAN , ContaBancariaId integer , ChavePIXCreatedAt timestamp without time zone , ChavePIXCreatedBy smallint , ChavePIXUpdatedAt timestamp without time zone , ChavePIXUpdatedBy smallint , PRIMARY KEY(ChavePIXId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE ChavePIX CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW ChavePIX CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION ChavePIX CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE ChavePIX (ChavePIXId integer NOT NULL DEFAULT nextval('ChavePIXId'), ChavePIXTipo VARCHAR(40) , ChavePIXConteudo VARCHAR(100) , ChavePIXStatus BOOLEAN , ChavePIXPrincipal BOOLEAN , ContaBancariaId integer , ChavePIXCreatedAt timestamp without time zone , ChavePIXCreatedBy smallint , ChavePIXUpdatedAt timestamp without time zone , ChavePIXUpdatedBy smallint , PRIMARY KEY(ChavePIXId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ICHAVEPIX1 ON ChavePIX (ChavePIXCreatedBy ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ICHAVEPIX1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ICHAVEPIX1 ON ChavePIX (ChavePIXCreatedBy ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ICHAVEPIX2 ON ChavePIX (ChavePIXUpdatedBy ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ICHAVEPIX2 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ICHAVEPIX2 ON ChavePIX (ChavePIXUpdatedBy ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ICHAVEPIX3 ON ChavePIX (ContaBancariaId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ICHAVEPIX3 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ICHAVEPIX3 ON ChavePIX (ContaBancariaId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateContaBancaria( )
      {
         string cmdBuffer = "";
         /* Indices for table ContaBancaria */
         try
         {
            cmdBuffer=" CREATE SEQUENCE ContaBancariaId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE ContaBancariaId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE ContaBancariaId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE ContaBancaria (ContaBancariaId integer NOT NULL DEFAULT nextval('ContaBancariaId'), AgenciaId integer , ContaBancariaNumero bigint , ContaBancariaCarteira bigint , ContaBancariaCreatedAt timestamp without time zone , ContaBancariaCreatedBy smallint , ContaBancariaUpdatedAt timestamp without time zone , ContaBancariaUpdatedBy smallint , ContaBancariaStatus BOOLEAN , ContaBancariaRegistraBoletos BOOLEAN , ContaBancariaDigito smallint , PRIMARY KEY(ContaBancariaId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE ContaBancaria CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW ContaBancaria CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION ContaBancaria CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE ContaBancaria (ContaBancariaId integer NOT NULL DEFAULT nextval('ContaBancariaId'), AgenciaId integer , ContaBancariaNumero bigint , ContaBancariaCarteira bigint , ContaBancariaCreatedAt timestamp without time zone , ContaBancariaCreatedBy smallint , ContaBancariaUpdatedAt timestamp without time zone , ContaBancariaUpdatedBy smallint , ContaBancariaStatus BOOLEAN , ContaBancariaRegistraBoletos BOOLEAN , ContaBancariaDigito smallint , PRIMARY KEY(ContaBancariaId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ICONTABANCARIA1 ON ContaBancaria (ContaBancariaCreatedBy ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ICONTABANCARIA1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ICONTABANCARIA1 ON ContaBancaria (ContaBancariaCreatedBy ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ICONTABANCARIA2 ON ContaBancaria (ContaBancariaUpdatedBy ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ICONTABANCARIA2 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ICONTABANCARIA2 ON ContaBancaria (ContaBancariaUpdatedBy ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ICONTABANCARIA3 ON ContaBancaria (AgenciaId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ICONTABANCARIA3 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ICONTABANCARIA3 ON ContaBancaria (AgenciaId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateAgencia( )
      {
         string cmdBuffer = "";
         /* Indices for table Agencia */
         try
         {
            cmdBuffer=" CREATE SEQUENCE AgenciaId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE AgenciaId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE AgenciaId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE Agencia (AgenciaId integer NOT NULL DEFAULT nextval('AgenciaId'), AgenciaNumero integer , AgenciaStatus BOOLEAN , AgenciaCreatedAt timestamp without time zone , AgenciaUpdatedAt timestamp without time zone , AgenciaCreatedBy smallint , AgenciaUpdatedBy smallint , AgenciaDigito integer , AgenciaBancoId integer , PRIMARY KEY(AgenciaId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Agencia CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Agencia CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Agencia CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Agencia (AgenciaId integer NOT NULL DEFAULT nextval('AgenciaId'), AgenciaNumero integer , AgenciaStatus BOOLEAN , AgenciaCreatedAt timestamp without time zone , AgenciaUpdatedAt timestamp without time zone , AgenciaCreatedBy smallint , AgenciaUpdatedBy smallint , AgenciaDigito integer , AgenciaBancoId integer , PRIMARY KEY(AgenciaId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IAGENCIA1 ON Agencia (AgenciaCreatedBy ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IAGENCIA1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IAGENCIA1 ON Agencia (AgenciaCreatedBy ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IAGENCIA2 ON Agencia (AgenciaUpdatedBy ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IAGENCIA2 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IAGENCIA2 ON Agencia (AgenciaUpdatedBy ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IAGENCIA3 ON Agencia (AgenciaBancoId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IAGENCIA3 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IAGENCIA3 ON Agencia (AgenciaBancoId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateNotificacaoAgendadaProcessamentoItem( )
      {
         string cmdBuffer = "";
         /* Indices for table NotificacaoAgendadaProcessamentoItem */
         try
         {
            cmdBuffer=" CREATE TABLE NotificacaoAgendadaProcessamentoItem (NotificacaoAgendadaProcessamentoId CHAR(36) NOT NULL , NotificacaoAgendadaProcessamentoItemId integer NOT NULL , NotificacaoAgendadaProcessamentoItemExecucao timestamp without time zone , NotificacaoAgendadaProcessamentoItemJson TEXT , NotificacaoAgendadaProcessamentoItemTipo VARCHAR(1) , NotificacaoAgendadaProcessamentoItemSituacao VARCHAR(1) , NotificacaoAgendadaProcessamentoItemRetorno VARCHAR(400) , PRIMARY KEY(NotificacaoAgendadaProcessamentoId, NotificacaoAgendadaProcessamentoItemId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE NotificacaoAgendadaProcessamentoItem CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW NotificacaoAgendadaProcessamentoItem CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION NotificacaoAgendadaProcessamentoItem CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE NotificacaoAgendadaProcessamentoItem (NotificacaoAgendadaProcessamentoId CHAR(36) NOT NULL , NotificacaoAgendadaProcessamentoItemId integer NOT NULL , NotificacaoAgendadaProcessamentoItemExecucao timestamp without time zone , NotificacaoAgendadaProcessamentoItemJson TEXT , NotificacaoAgendadaProcessamentoItemTipo VARCHAR(1) , NotificacaoAgendadaProcessamentoItemSituacao VARCHAR(1) , NotificacaoAgendadaProcessamentoItemRetorno VARCHAR(400) , PRIMARY KEY(NotificacaoAgendadaProcessamentoId, NotificacaoAgendadaProcessamentoItemId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateNotificacaoAgendadaProcessamento( )
      {
         string cmdBuffer = "";
         /* Indices for table NotificacaoAgendadaProcessamento */
         try
         {
            cmdBuffer=" CREATE TABLE NotificacaoAgendadaProcessamento (NotificacaoAgendadaProcessamentoId CHAR(36) NOT NULL , NotificacaoAgendadaProcessamentoInicio timestamp without time zone , NotificacaoAgendadaProcessamentoFim timestamp without time zone , NotificacaoAgendadaProcessamentoQtdExec integer , NotificacaoAgendadaProcessamentoQtdSucesso smallint , NotificacaoAgendadaProcessamentoQtdFalhas smallint , NotificacaoAgendadaProcessamentoSituacao VARCHAR(1) , NotificacaoAgendadaProcessamentoMensagemErro TEXT , PRIMARY KEY(NotificacaoAgendadaProcessamentoId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE NotificacaoAgendadaProcessamento CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW NotificacaoAgendadaProcessamento CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION NotificacaoAgendadaProcessamento CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE NotificacaoAgendadaProcessamento (NotificacaoAgendadaProcessamentoId CHAR(36) NOT NULL , NotificacaoAgendadaProcessamentoInicio timestamp without time zone , NotificacaoAgendadaProcessamentoFim timestamp without time zone , NotificacaoAgendadaProcessamentoQtdExec integer , NotificacaoAgendadaProcessamentoQtdSucesso smallint , NotificacaoAgendadaProcessamentoQtdFalhas smallint , NotificacaoAgendadaProcessamentoSituacao VARCHAR(1) , NotificacaoAgendadaProcessamentoMensagemErro TEXT , PRIMARY KEY(NotificacaoAgendadaProcessamentoId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateNotificacaoAgendada( )
      {
         string cmdBuffer = "";
         /* Indices for table NotificacaoAgendada */
         try
         {
            cmdBuffer=" CREATE SEQUENCE NotificacaoAgendadaId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE NotificacaoAgendadaId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE NotificacaoAgendadaId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE NotificacaoAgendada (NotificacaoAgendadaId integer NOT NULL DEFAULT nextval('NotificacaoAgendadaId'), NotificacaoAgendadaOrigem VARCHAR(1) NOT NULL , NotificacaoAgendadaDescricao VARCHAR(120) NOT NULL , NotificacaoAgendadaDias integer , NotificacaoAgendadaMomentoEnvio VARCHAR(1) , NotificacaoAgendadaTipo VARCHAR(1) , NotificacaoAgendadaLayoutId smallint , NotificacaoAgendadaStatus BOOLEAN , PRIMARY KEY(NotificacaoAgendadaId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE NotificacaoAgendada CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW NotificacaoAgendada CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION NotificacaoAgendada CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE NotificacaoAgendada (NotificacaoAgendadaId integer NOT NULL DEFAULT nextval('NotificacaoAgendadaId'), NotificacaoAgendadaOrigem VARCHAR(1) NOT NULL , NotificacaoAgendadaDescricao VARCHAR(120) NOT NULL , NotificacaoAgendadaDias integer , NotificacaoAgendadaMomentoEnvio VARCHAR(1) , NotificacaoAgendadaTipo VARCHAR(1) , NotificacaoAgendadaLayoutId smallint , NotificacaoAgendadaStatus BOOLEAN , PRIMARY KEY(NotificacaoAgendadaId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX INOTIFICACAOAGENDADA1 ON NotificacaoAgendada (NotificacaoAgendadaLayoutId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX INOTIFICACAOAGENDADA1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX INOTIFICACAOAGENDADA1 ON NotificacaoAgendada (NotificacaoAgendadaLayoutId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateNotaFiscalParcelamento( )
      {
         string cmdBuffer = "";
         /* Indices for table NotaFiscalParcelamento */
         try
         {
            cmdBuffer=" CREATE TABLE NotaFiscalParcelamento (NotaFiscalParcelamentoID CHAR(36) NOT NULL , NotaFiscalId CHAR(36) , NotaFiscalParcelamentoNumero VARCHAR(100) , NotaFiscalParcelamentoValor NUMERIC(17,2) , NotaFiscalParcelamentoVencimento date , NotaFiscalParcelamentoValorTaxaAdministrativa NUMERIC(17,2) , NotaFiscalParcelamentoValorTaxaAnual NUMERIC(17,2) , NotaFiscalParcelamentoLiquido NUMERIC(17,2) , PRIMARY KEY(NotaFiscalParcelamentoID))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE NotaFiscalParcelamento CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW NotaFiscalParcelamento CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION NotaFiscalParcelamento CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE NotaFiscalParcelamento (NotaFiscalParcelamentoID CHAR(36) NOT NULL , NotaFiscalId CHAR(36) , NotaFiscalParcelamentoNumero VARCHAR(100) , NotaFiscalParcelamentoValor NUMERIC(17,2) , NotaFiscalParcelamentoVencimento date , NotaFiscalParcelamentoValorTaxaAdministrativa NUMERIC(17,2) , NotaFiscalParcelamentoValorTaxaAnual NUMERIC(17,2) , NotaFiscalParcelamentoLiquido NUMERIC(17,2) , PRIMARY KEY(NotaFiscalParcelamentoID))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX INOTAFISCALPARCELAMENTO1 ON NotaFiscalParcelamento (NotaFiscalId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX INOTAFISCALPARCELAMENTO1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX INOTAFISCALPARCELAMENTO1 ON NotaFiscalParcelamento (NotaFiscalId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTaxas( )
      {
         string cmdBuffer = "";
         /* Indices for table Taxas */
         try
         {
            cmdBuffer=" CREATE SEQUENCE TaxasId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE TaxasId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE TaxasId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE Taxas (TaxasId integer NOT NULL DEFAULT nextval('TaxasId'), TaxasPercentual NUMERIC(15,4) , TaxasValorMinimo NUMERIC(17,2) , TaxasCreatedAt timestamp without time zone , TaxasUpdatedAt timestamp without time zone , TaxasCreatedBy smallint , TaxasUpdatedBy smallint , TaxasPercentualAnual NUMERIC(15,4) , PRIMARY KEY(TaxasId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Taxas CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Taxas CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Taxas CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Taxas (TaxasId integer NOT NULL DEFAULT nextval('TaxasId'), TaxasPercentual NUMERIC(15,4) , TaxasValorMinimo NUMERIC(17,2) , TaxasCreatedAt timestamp without time zone , TaxasUpdatedAt timestamp without time zone , TaxasCreatedBy smallint , TaxasUpdatedBy smallint , TaxasPercentualAnual NUMERIC(15,4) , PRIMARY KEY(TaxasId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ITAXAS1 ON Taxas (TaxasUpdatedBy ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ITAXAS1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ITAXAS1 ON Taxas (TaxasUpdatedBy ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ITAXAS2 ON Taxas (TaxasCreatedBy ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ITAXAS2 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ITAXAS2 ON Taxas (TaxasCreatedBy ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateCredito( )
      {
         string cmdBuffer = "";
         /* Indices for table Credito */
         try
         {
            cmdBuffer=" CREATE SEQUENCE CreditoId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE CreditoId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE CreditoId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE Credito (CreditoId integer NOT NULL DEFAULT nextval('CreditoId'), ClienteId integer , CreditoValor NUMERIC(17,2) , CreditoVigencia date , CreditoCreatedAt timestamp without time zone , CreditoUpdatedAt timestamp without time zone , CreditoCreatedBy smallint , CreditoUpdatedBy smallint , PRIMARY KEY(CreditoId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Credito CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Credito CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Credito CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Credito (CreditoId integer NOT NULL DEFAULT nextval('CreditoId'), ClienteId integer , CreditoValor NUMERIC(17,2) , CreditoVigencia date , CreditoCreatedAt timestamp without time zone , CreditoUpdatedAt timestamp without time zone , CreditoCreatedBy smallint , CreditoUpdatedBy smallint , PRIMARY KEY(CreditoId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ICREDITO1 ON Credito (ClienteId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ICREDITO1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ICREDITO1 ON Credito (ClienteId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ICREDITO2 ON Credito (CreditoCreatedBy ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ICREDITO2 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ICREDITO2 ON Credito (CreditoCreatedBy ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ICREDITO3 ON Credito (CreditoUpdatedBy ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ICREDITO3 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ICREDITO3 ON Credito (CreditoUpdatedBy ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateNotaFiscalItem( )
      {
         string cmdBuffer = "";
         /* Indices for table NotaFiscalItem */
         try
         {
            cmdBuffer=" CREATE TABLE NotaFiscalItem (NotaFiscalItemId CHAR(36) NOT NULL , PropostaId integer , NotaFiscalId CHAR(36) , NotaFiscalItemCodigo VARCHAR(60) , NotaFiscalItemCFOP smallint , NotaFiscalItemDescricao VARCHAR(255) , NotaFiscalItemNCM VARCHAR(40) , NotaFiscalItemCodigoEAN VARCHAR(60) , NotaFiscalItemUnidadeComercial VARCHAR(40) , NotaFiscalItemQuantidade NUMERIC(17,6) , NotaFiscalItemValorUnitario NUMERIC(17,2) , NotaFiscalItemValorTotal NUMERIC(17,2) , NotaFiscalItemCodBarGTIN VARCHAR(100) , NotaFiscalItemUnidadeTributavel VARCHAR(40) , NotaFiscalItemValorUnTributavel NUMERIC(17,2) , NotaFiscalItemQtdTributavel NUMERIC(17,6) , NotaFiscalItemValorFrete NUMERIC(17,2) , NotaFiscalItemDesconto NUMERIC(17,2) , NotaFiscalItemIndicadorValorTotal VARCHAR(40) , NotaFiscalItemNumPedido VARCHAR(60) , NotaFiscalItemNumItem VARCHAR(60) , NotaFiscalItemVendido VARCHAR(40) , PRIMARY KEY(NotaFiscalItemId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE NotaFiscalItem CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW NotaFiscalItem CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION NotaFiscalItem CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE NotaFiscalItem (NotaFiscalItemId CHAR(36) NOT NULL , PropostaId integer , NotaFiscalId CHAR(36) , NotaFiscalItemCodigo VARCHAR(60) , NotaFiscalItemCFOP smallint , NotaFiscalItemDescricao VARCHAR(255) , NotaFiscalItemNCM VARCHAR(40) , NotaFiscalItemCodigoEAN VARCHAR(60) , NotaFiscalItemUnidadeComercial VARCHAR(40) , NotaFiscalItemQuantidade NUMERIC(17,6) , NotaFiscalItemValorUnitario NUMERIC(17,2) , NotaFiscalItemValorTotal NUMERIC(17,2) , NotaFiscalItemCodBarGTIN VARCHAR(100) , NotaFiscalItemUnidadeTributavel VARCHAR(40) , NotaFiscalItemValorUnTributavel NUMERIC(17,2) , NotaFiscalItemQtdTributavel NUMERIC(17,6) , NotaFiscalItemValorFrete NUMERIC(17,2) , NotaFiscalItemDesconto NUMERIC(17,2) , NotaFiscalItemIndicadorValorTotal VARCHAR(40) , NotaFiscalItemNumPedido VARCHAR(60) , NotaFiscalItemNumItem VARCHAR(60) , NotaFiscalItemVendido VARCHAR(40) , PRIMARY KEY(NotaFiscalItemId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX INOTAFISCALITEM1 ON NotaFiscalItem (NotaFiscalId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX INOTAFISCALITEM1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX INOTAFISCALITEM1 ON NotaFiscalItem (NotaFiscalId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX INOTAFISCALITEM2 ON NotaFiscalItem (PropostaId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX INOTAFISCALITEM2 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX INOTAFISCALITEM2 ON NotaFiscalItem (PropostaId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateNotaFiscal( )
      {
         string cmdBuffer = "";
         /* Indices for table NotaFiscal */
         try
         {
            cmdBuffer=" CREATE TABLE NotaFiscal (NotaFiscalId CHAR(36) NOT NULL , NotaFiscalUF smallint , NotaFiscalNatureza VARCHAR(255) , NotaFiscalMod VARCHAR(20) , NotaFiscalSerie VARCHAR(20) , NotaFiscalNumero VARCHAR(40) , NotaFiscalDataEmissao timestamp without time zone , NotaFiscalDataSaida timestamp without time zone , NotaFiscalTipo VARCHAR(40) , NotaFiscalMunicipio VARCHAR(40) , NotaFiscalTipoEmissao VARCHAR(40) , NotaFiscalAmbiente smallint , NotaFiscalFinalidades VARCHAR(40) , NotaFiscaEmitentelDocumento VARCHAR(14) , NotaFiscalEmitenteNome VARCHAR(60) , NotaFiscalEmitenteLogradouro VARCHAR(100) , NotaFiscalEmitenteLogNum VARCHAR(40) , NotaFiscalEmitenteComplemento VARCHAR(100) , NotaFiscalEmitenteBairro VARCHAR(100) , NotaFiscalEmitenteMunicipio VARCHAR(40) , NotaFiscalEmitenteUF VARCHAR(40) , NotaFiscalEmitenteCEP VARCHAR(40) , NotaFiscalEmitentePais VARCHAR(40) , NotaFiscalEmitenteTelefone VARCHAR(40) , NotaFiscalEmitenteIE VARCHAR(60) , NotaFiscalDestinatarioDocumento VARCHAR(14) , NotaFiscalDestinatarioNome VARCHAR(100) , NotaFiscalDestinatarioLogradouro VARCHAR(100) , NotaFiscalDestinatarioLogNum VARCHAR(40) , NotaFiscalDestinatarioComplemento VARCHAR(100) , NotaFiscalDestinatarioBairro VARCHAR(100) , NotaFiscalDestinatarioMunicipio VARCHAR(40) , NotaFiscalDestinatarioUF VARCHAR(40) , NotaFiscalDestinatarioCEP VARCHAR(40) , NotaFiscalDestinatarioPais VARCHAR(40) , NotaFiscalDestinatarioFone VARCHAR(40) , ClienteId integer , NotaFiscalDestinatarioClienteId integer , PRIMARY KEY(NotaFiscalId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE NotaFiscal CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW NotaFiscal CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION NotaFiscal CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE NotaFiscal (NotaFiscalId CHAR(36) NOT NULL , NotaFiscalUF smallint , NotaFiscalNatureza VARCHAR(255) , NotaFiscalMod VARCHAR(20) , NotaFiscalSerie VARCHAR(20) , NotaFiscalNumero VARCHAR(40) , NotaFiscalDataEmissao timestamp without time zone , NotaFiscalDataSaida timestamp without time zone , NotaFiscalTipo VARCHAR(40) , NotaFiscalMunicipio VARCHAR(40) , NotaFiscalTipoEmissao VARCHAR(40) , NotaFiscalAmbiente smallint , NotaFiscalFinalidades VARCHAR(40) , NotaFiscaEmitentelDocumento VARCHAR(14) , NotaFiscalEmitenteNome VARCHAR(60) , NotaFiscalEmitenteLogradouro VARCHAR(100) , NotaFiscalEmitenteLogNum VARCHAR(40) , NotaFiscalEmitenteComplemento VARCHAR(100) , NotaFiscalEmitenteBairro VARCHAR(100) , NotaFiscalEmitenteMunicipio VARCHAR(40) , NotaFiscalEmitenteUF VARCHAR(40) , NotaFiscalEmitenteCEP VARCHAR(40) , NotaFiscalEmitentePais VARCHAR(40) , NotaFiscalEmitenteTelefone VARCHAR(40) , NotaFiscalEmitenteIE VARCHAR(60) , NotaFiscalDestinatarioDocumento VARCHAR(14) , NotaFiscalDestinatarioNome VARCHAR(100) , NotaFiscalDestinatarioLogradouro VARCHAR(100) , NotaFiscalDestinatarioLogNum VARCHAR(40) , NotaFiscalDestinatarioComplemento VARCHAR(100) , NotaFiscalDestinatarioBairro VARCHAR(100) , NotaFiscalDestinatarioMunicipio VARCHAR(40) , NotaFiscalDestinatarioUF VARCHAR(40) , NotaFiscalDestinatarioCEP VARCHAR(40) , NotaFiscalDestinatarioPais VARCHAR(40) , NotaFiscalDestinatarioFone VARCHAR(40) , ClienteId integer , NotaFiscalDestinatarioClienteId integer , PRIMARY KEY(NotaFiscalId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX INOTAFISCAL1 ON NotaFiscal (ClienteId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX INOTAFISCAL1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX INOTAFISCAL1 ON NotaFiscal (ClienteId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX INOTAFISCAL2 ON NotaFiscal (NotaFiscalDestinatarioClienteId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX INOTAFISCAL2 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX INOTAFISCAL2 ON NotaFiscal (NotaFiscalDestinatarioClienteId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateReembolsoFlowLog( )
      {
         string cmdBuffer = "";
         /* Indices for table ReembolsoFlowLog */
         try
         {
            cmdBuffer=" CREATE SEQUENCE ReembolsoFlowLogId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE ReembolsoFlowLogId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE ReembolsoFlowLogId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE ReembolsoFlowLog (ReembolsoFlowLogId integer NOT NULL DEFAULT nextval('ReembolsoFlowLogId'), LogWorkflowConvenioId integer , ReembolsoFlowLogDate timestamp without time zone , ReembolsoFlowLogUser smallint , ReembolsoLogId integer , ReembolsoFlowLogDataFinal timestamp without time zone , PRIMARY KEY(ReembolsoFlowLogId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE ReembolsoFlowLog CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW ReembolsoFlowLog CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION ReembolsoFlowLog CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE ReembolsoFlowLog (ReembolsoFlowLogId integer NOT NULL DEFAULT nextval('ReembolsoFlowLogId'), LogWorkflowConvenioId integer , ReembolsoFlowLogDate timestamp without time zone , ReembolsoFlowLogUser smallint , ReembolsoLogId integer , ReembolsoFlowLogDataFinal timestamp without time zone , PRIMARY KEY(ReembolsoFlowLogId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IREEMBOLSOFLOWLOG1 ON ReembolsoFlowLog (ReembolsoFlowLogUser ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IREEMBOLSOFLOWLOG1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IREEMBOLSOFLOWLOG1 ON ReembolsoFlowLog (ReembolsoFlowLogUser ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IREEMBOLSOFLOWLOG2 ON ReembolsoFlowLog (ReembolsoLogId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IREEMBOLSOFLOWLOG2 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IREEMBOLSOFLOWLOG2 ON ReembolsoFlowLog (ReembolsoLogId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IREEMBOLSOFLOWLOG3 ON ReembolsoFlowLog (LogWorkflowConvenioId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IREEMBOLSOFLOWLOG3 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IREEMBOLSOFLOWLOG3 ON ReembolsoFlowLog (LogWorkflowConvenioId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateWorkflowConvenio( )
      {
         string cmdBuffer = "";
         /* Indices for table WorkflowConvenio */
         try
         {
            cmdBuffer=" CREATE SEQUENCE WorkflowConvenioId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE WorkflowConvenioId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE WorkflowConvenioId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE WorkflowConvenio (WorkflowConvenioId integer NOT NULL DEFAULT nextval('WorkflowConvenioId'), WorkflowConvenioDesc VARCHAR(60) , WorkflowConvenioStatus BOOLEAN , WorkflowConvenioCreatedAt timestamp without time zone , WorkflowConvenioSLA smallint , PRIMARY KEY(WorkflowConvenioId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE WorkflowConvenio CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW WorkflowConvenio CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION WorkflowConvenio CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE WorkflowConvenio (WorkflowConvenioId integer NOT NULL DEFAULT nextval('WorkflowConvenioId'), WorkflowConvenioDesc VARCHAR(60) , WorkflowConvenioStatus BOOLEAN , WorkflowConvenioCreatedAt timestamp without time zone , WorkflowConvenioSLA smallint , PRIMARY KEY(WorkflowConvenioId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateReembolsoPassos( )
      {
         string cmdBuffer = "";
         /* Indices for table ReembolsoPassos */
         try
         {
            cmdBuffer=" CREATE TABLE ReembolsoPassos (ReembolsoPassos smallint NOT NULL , ReembolsoPassosNome VARCHAR(60) , ReembolsoPassosStatus BOOLEAN , ReembolsoPassosSLALembrete smallint , PRIMARY KEY(ReembolsoPassos))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE ReembolsoPassos CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW ReembolsoPassos CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION ReembolsoPassos CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE ReembolsoPassos (ReembolsoPassos smallint NOT NULL , ReembolsoPassosNome VARCHAR(60) , ReembolsoPassosStatus BOOLEAN , ReembolsoPassosSLALembrete smallint , PRIMARY KEY(ReembolsoPassos))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateSerasaOcorrencias( )
      {
         string cmdBuffer = "";
         /* Indices for table SerasaOcorrencias */
         try
         {
            cmdBuffer=" CREATE SEQUENCE SerasaOcorrenciasId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE SerasaOcorrenciasId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE SerasaOcorrenciasId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE SerasaOcorrencias (SerasaOcorrenciasId integer NOT NULL DEFAULT nextval('SerasaOcorrenciasId'), SerasaId integer , SerasaOcorrenciasData date , SerasaOcorrenciasOrigem VARCHAR(40) , SerasaOcorrenciasModalidade VARCHAR(40) , SerasaOcorrenciasTipoMoeda VARCHAR(40) , SerasaOcorrenciasValor NUMERIC(17,2) , PRIMARY KEY(SerasaOcorrenciasId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE SerasaOcorrencias CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW SerasaOcorrencias CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION SerasaOcorrencias CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE SerasaOcorrencias (SerasaOcorrenciasId integer NOT NULL DEFAULT nextval('SerasaOcorrenciasId'), SerasaId integer , SerasaOcorrenciasData date , SerasaOcorrenciasOrigem VARCHAR(40) , SerasaOcorrenciasModalidade VARCHAR(40) , SerasaOcorrenciasTipoMoeda VARCHAR(40) , SerasaOcorrenciasValor NUMERIC(17,2) , PRIMARY KEY(SerasaOcorrenciasId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ISERASAOCORRENCIAS1 ON SerasaOcorrencias (SerasaId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ISERASAOCORRENCIAS1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ISERASAOCORRENCIAS1 ON SerasaOcorrencias (SerasaId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateSerasaEnderecos( )
      {
         string cmdBuffer = "";
         /* Indices for table SerasaEnderecos */
         try
         {
            cmdBuffer=" CREATE SEQUENCE SerasaEnderecosId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE SerasaEnderecosId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE SerasaEnderecosId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE SerasaEnderecos (SerasaEnderecosId integer NOT NULL DEFAULT nextval('SerasaEnderecosId'), SerasaId integer , SerasaEnderecosLogr VARCHAR(100) , SerasaEnderecosNum VARCHAR(40) , SerasaEnderecosCompl VARCHAR(50) , SerasaEnderecosBairro VARCHAR(100) , SerasaEnderecosCidade VARCHAR(40) , SerasaEnderecosEstado VARCHAR(40) , SerasaEnderecosCEP VARCHAR(40) , SerasaEnderecosTelDDD VARCHAR(40) , SerasaEnderecosTel VARCHAR(40) , PRIMARY KEY(SerasaEnderecosId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE SerasaEnderecos CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW SerasaEnderecos CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION SerasaEnderecos CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE SerasaEnderecos (SerasaEnderecosId integer NOT NULL DEFAULT nextval('SerasaEnderecosId'), SerasaId integer , SerasaEnderecosLogr VARCHAR(100) , SerasaEnderecosNum VARCHAR(40) , SerasaEnderecosCompl VARCHAR(50) , SerasaEnderecosBairro VARCHAR(100) , SerasaEnderecosCidade VARCHAR(40) , SerasaEnderecosEstado VARCHAR(40) , SerasaEnderecosCEP VARCHAR(40) , SerasaEnderecosTelDDD VARCHAR(40) , SerasaEnderecosTel VARCHAR(40) , PRIMARY KEY(SerasaEnderecosId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ISERASAENDERECOS1 ON SerasaEnderecos (SerasaId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ISERASAENDERECOS1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ISERASAENDERECOS1 ON SerasaEnderecos (SerasaId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateSerasaProtestos( )
      {
         string cmdBuffer = "";
         /* Indices for table SerasaProtestos */
         try
         {
            cmdBuffer=" CREATE SEQUENCE SerasaProtestosId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE SerasaProtestosId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE SerasaProtestosId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE SerasaProtestos (SerasaProtestosId integer NOT NULL DEFAULT nextval('SerasaProtestosId'), SerasaId integer , SerasaProtestosData date , SerasaProtestosValor NUMERIC(17,2) , SerasaProtestosCartorio VARCHAR(40) , SerasaProtestosCidade VARCHAR(40) , PRIMARY KEY(SerasaProtestosId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE SerasaProtestos CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW SerasaProtestos CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION SerasaProtestos CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE SerasaProtestos (SerasaProtestosId integer NOT NULL DEFAULT nextval('SerasaProtestosId'), SerasaId integer , SerasaProtestosData date , SerasaProtestosValor NUMERIC(17,2) , SerasaProtestosCartorio VARCHAR(40) , SerasaProtestosCidade VARCHAR(40) , PRIMARY KEY(SerasaProtestosId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ISERASAPROTESTOS1 ON SerasaProtestos (SerasaId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ISERASAPROTESTOS1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ISERASAPROTESTOS1 ON SerasaProtestos (SerasaId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateSerasaAcoes( )
      {
         string cmdBuffer = "";
         /* Indices for table SerasaAcoes */
         try
         {
            cmdBuffer=" CREATE SEQUENCE SerasaAcoesId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE SerasaAcoesId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE SerasaAcoesId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE SerasaAcoes (SerasaAcoesId integer NOT NULL DEFAULT nextval('SerasaAcoesId'), SerasaId integer , SerasaAcoesData date , SerasaAcoesNatureza VARCHAR(100) , SerasaAcoesValor NUMERIC(17,2) , SerasaAcoesDistribuidor VARCHAR(100) , SerasaAcoesVara VARCHAR(40) , SerasaAcoesCidade VARCHAR(40) , SerasaAcoesUF VARCHAR(40) , SerasaAcoesPrincipal VARCHAR(40) , SerasaAcoesTipoMoeda VARCHAR(40) , SerasaAcoesQtdOco smallint , PRIMARY KEY(SerasaAcoesId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE SerasaAcoes CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW SerasaAcoes CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION SerasaAcoes CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE SerasaAcoes (SerasaAcoesId integer NOT NULL DEFAULT nextval('SerasaAcoesId'), SerasaId integer , SerasaAcoesData date , SerasaAcoesNatureza VARCHAR(100) , SerasaAcoesValor NUMERIC(17,2) , SerasaAcoesDistribuidor VARCHAR(100) , SerasaAcoesVara VARCHAR(40) , SerasaAcoesCidade VARCHAR(40) , SerasaAcoesUF VARCHAR(40) , SerasaAcoesPrincipal VARCHAR(40) , SerasaAcoesTipoMoeda VARCHAR(40) , SerasaAcoesQtdOco smallint , PRIMARY KEY(SerasaAcoesId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ISERASAACOES1 ON SerasaAcoes (SerasaId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ISERASAACOES1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ISERASAACOES1 ON SerasaAcoes (SerasaId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateSerasaCheques( )
      {
         string cmdBuffer = "";
         /* Indices for table SerasaCheques */
         try
         {
            cmdBuffer=" CREATE SEQUENCE SerasaChequesId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE SerasaChequesId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE SerasaChequesId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE SerasaCheques (SerasaChequesId integer NOT NULL DEFAULT nextval('SerasaChequesId'), SerasaId integer , SerasaChequesTotalCons NUMERIC(14,2) , SerasaChequesQtdSemFundo NUMERIC(14,2) , SerasaChequesUltOcorSus date , SerasaChequesValorSemFundo NUMERIC(17,2) , SerasaChequesTotalSust NUMERIC(14,2) , PRIMARY KEY(SerasaChequesId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE SerasaCheques CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW SerasaCheques CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION SerasaCheques CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE SerasaCheques (SerasaChequesId integer NOT NULL DEFAULT nextval('SerasaChequesId'), SerasaId integer , SerasaChequesTotalCons NUMERIC(14,2) , SerasaChequesQtdSemFundo NUMERIC(14,2) , SerasaChequesUltOcorSus date , SerasaChequesValorSemFundo NUMERIC(17,2) , SerasaChequesTotalSust NUMERIC(14,2) , PRIMARY KEY(SerasaChequesId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ISERASACHEQUES1 ON SerasaCheques (SerasaId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ISERASACHEQUES1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ISERASACHEQUES1 ON SerasaCheques (SerasaId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateSerasa( )
      {
         string cmdBuffer = "";
         /* Indices for table Serasa */
         try
         {
            cmdBuffer=" CREATE SEQUENCE SerasaId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE SerasaId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE SerasaId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE Serasa (SerasaId integer NOT NULL DEFAULT nextval('SerasaId'), ClienteId integer , SerasaNumeroProposta VARCHAR(40) , SerasaPolitica NUMERIC(14,2) , SerasaCreatedAt timestamp without time zone , SerasaTipoVenda VARCHAR(40) , SerasaCodTipoVenda NUMERIC(14,2) , SerasaCodNivelRisco NUMERIC(14,2) , SerasaTipoRecomendacao VARCHAR(40) , SerasaRecomendacaoVenda VARCHAR(100) , SerasaCpfRegular BOOLEAN , SerasaRetricaoAtiva BOOLEAN , SerasaProtestoAtivo BOOLEAN , SerasaBaixoComprometimento BOOLEAN , SerasaValorLimiteRecomendado NUMERIC(17,2) , SerasaFaixaDeRendaEstimada NUMERIC(14,2) , SerasaMensagemRendaEstimada VARCHAR(250) , SerasaAnotacoesCompletas BOOLEAN , SerasaConsultasDetalhadas BOOLEAN , SerasaAnotacoesConsultaSPC BOOLEAN , SerasaParticipacaoSocietaria BOOLEAN , SerasaRendaEstimada BOOLEAN , SerasaHistoricoPagamentoPF BOOLEAN , SerasaRecomendaCompleto BOOLEAN , SerasaScore smallint , SerasaTaxa NUMERIC(14,2) , SerasaMensagemScore VARCHAR(250) , SerasaSituacaoCPF VARCHAR(40) , SerasaDataNascimento date , SerasaGenero VARCHAR(40) , SerasaNomeMae VARCHAR(60) , SerasaGrafia VARCHAR(60) , SerasaJSON TEXT , PRIMARY KEY(SerasaId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Serasa CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Serasa CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Serasa CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Serasa (SerasaId integer NOT NULL DEFAULT nextval('SerasaId'), ClienteId integer , SerasaNumeroProposta VARCHAR(40) , SerasaPolitica NUMERIC(14,2) , SerasaCreatedAt timestamp without time zone , SerasaTipoVenda VARCHAR(40) , SerasaCodTipoVenda NUMERIC(14,2) , SerasaCodNivelRisco NUMERIC(14,2) , SerasaTipoRecomendacao VARCHAR(40) , SerasaRecomendacaoVenda VARCHAR(100) , SerasaCpfRegular BOOLEAN , SerasaRetricaoAtiva BOOLEAN , SerasaProtestoAtivo BOOLEAN , SerasaBaixoComprometimento BOOLEAN , SerasaValorLimiteRecomendado NUMERIC(17,2) , SerasaFaixaDeRendaEstimada NUMERIC(14,2) , SerasaMensagemRendaEstimada VARCHAR(250) , SerasaAnotacoesCompletas BOOLEAN , SerasaConsultasDetalhadas BOOLEAN , SerasaAnotacoesConsultaSPC BOOLEAN , SerasaParticipacaoSocietaria BOOLEAN , SerasaRendaEstimada BOOLEAN , SerasaHistoricoPagamentoPF BOOLEAN , SerasaRecomendaCompleto BOOLEAN , SerasaScore smallint , SerasaTaxa NUMERIC(14,2) , SerasaMensagemScore VARCHAR(250) , SerasaSituacaoCPF VARCHAR(40) , SerasaDataNascimento date , SerasaGenero VARCHAR(40) , SerasaNomeMae VARCHAR(60) , SerasaGrafia VARCHAR(60) , SerasaJSON TEXT , PRIMARY KEY(SerasaId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ISERASA1 ON Serasa (ClienteId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ISERASA1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ISERASA1 ON Serasa (ClienteId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateWebService( )
      {
         string cmdBuffer = "";
         /* Indices for table WebService */
         try
         {
            cmdBuffer=" CREATE SEQUENCE WebServiceId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE WebServiceId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE WebServiceId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE WebService (WebServiceId integer NOT NULL DEFAULT nextval('WebServiceId'), WebServiceTipoDmWS VARCHAR(40) , WebServiceEndPoint VARCHAR(255) , WebServiceAuthTipo VARCHAR(40) , WebServiceUsuario VARCHAR(100) , WebServiceSenha VARCHAR(100) , PRIMARY KEY(WebServiceId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE WebService CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW WebService CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION WebService CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE WebService (WebServiceId integer NOT NULL DEFAULT nextval('WebServiceId'), WebServiceTipoDmWS VARCHAR(40) , WebServiceEndPoint VARCHAR(255) , WebServiceAuthTipo VARCHAR(40) , WebServiceUsuario VARCHAR(100) , WebServiceSenha VARCHAR(100) , PRIMARY KEY(WebServiceId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateReembolsoParcelas( )
      {
         string cmdBuffer = "";
         /* Indices for table ReembolsoParcelas */
         try
         {
            cmdBuffer=" CREATE SEQUENCE ReembolsoParcelasId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE ReembolsoParcelasId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE ReembolsoParcelasId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE ReembolsoParcelas (ReembolsoParcelasId integer NOT NULL DEFAULT nextval('ReembolsoParcelasId'), ReembolsoId integer , ReembolsoParcelasValor NUMERIC(17,2) , ReembolsoParcelasData date , ReembolsoParcelasObservacao VARCHAR(100) , ReembolsoParcelasCreatedAt timestamp without time zone , ReembolsoParcelasTaxaValor NUMERIC(17,2) , ReembolsoParcelasJurosValor NUMERIC(17,2) , ReembolsoParcelasDiasPJuros smallint , PRIMARY KEY(ReembolsoParcelasId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE ReembolsoParcelas CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW ReembolsoParcelas CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION ReembolsoParcelas CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE ReembolsoParcelas (ReembolsoParcelasId integer NOT NULL DEFAULT nextval('ReembolsoParcelasId'), ReembolsoId integer , ReembolsoParcelasValor NUMERIC(17,2) , ReembolsoParcelasData date , ReembolsoParcelasObservacao VARCHAR(100) , ReembolsoParcelasCreatedAt timestamp without time zone , ReembolsoParcelasTaxaValor NUMERIC(17,2) , ReembolsoParcelasJurosValor NUMERIC(17,2) , ReembolsoParcelasDiasPJuros smallint , PRIMARY KEY(ReembolsoParcelasId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IREEMBOLSOPARCELAS1 ON ReembolsoParcelas (ReembolsoId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IREEMBOLSOPARCELAS1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IREEMBOLSOPARCELAS1 ON ReembolsoParcelas (ReembolsoId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateReembolsoAssinaturas( )
      {
         string cmdBuffer = "";
         /* Indices for table ReembolsoAssinaturas */
         try
         {
            cmdBuffer=" CREATE SEQUENCE ReembolsoAssinaturasId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE ReembolsoAssinaturasId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE ReembolsoAssinaturasId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE ReembolsoAssinaturas (ReembolsoAssinaturasId integer NOT NULL DEFAULT nextval('ReembolsoAssinaturasId'), ReembolsoId integer , ReembolsoAssinaturasNome VARCHAR(100) , ReembolsoAssinaturasEmissao timestamp without time zone , PropostaContratoAssinaturaId integer , PRIMARY KEY(ReembolsoAssinaturasId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE ReembolsoAssinaturas CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW ReembolsoAssinaturas CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION ReembolsoAssinaturas CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE ReembolsoAssinaturas (ReembolsoAssinaturasId integer NOT NULL DEFAULT nextval('ReembolsoAssinaturasId'), ReembolsoId integer , ReembolsoAssinaturasNome VARCHAR(100) , ReembolsoAssinaturasEmissao timestamp without time zone , PropostaContratoAssinaturaId integer , PRIMARY KEY(ReembolsoAssinaturasId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IREEMBOLSOASSINATURAS2 ON ReembolsoAssinaturas (ReembolsoId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IREEMBOLSOASSINATURAS2 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IREEMBOLSOASSINATURAS2 ON ReembolsoAssinaturas (ReembolsoId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IREEMBOLSOASSINATURAS1 ON ReembolsoAssinaturas (PropostaContratoAssinaturaId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IREEMBOLSOASSINATURAS1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IREEMBOLSOASSINATURAS1 ON ReembolsoAssinaturas (PropostaContratoAssinaturaId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateLogEmail( )
      {
         string cmdBuffer = "";
         /* Indices for table LogEmail */
         try
         {
            cmdBuffer=" CREATE SEQUENCE LogEmailId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE LogEmailId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE LogEmailId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE LogEmail (LogEmailId integer NOT NULL DEFAULT nextval('LogEmailId'), LogEmailCorpo TEXT , LogEmailSubject VARCHAR(100) , LogEmailDestinatario VARCHAR(255) , LogEmailCreatedAt timestamp without time zone , PRIMARY KEY(LogEmailId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE LogEmail CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW LogEmail CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION LogEmail CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE LogEmail (LogEmailId integer NOT NULL DEFAULT nextval('LogEmailId'), LogEmailCorpo TEXT , LogEmailSubject VARCHAR(100) , LogEmailDestinatario VARCHAR(255) , LogEmailCreatedAt timestamp without time zone , PRIMARY KEY(LogEmailId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateClienteDocumento( )
      {
         string cmdBuffer = "";
         /* Indices for table ClienteDocumento */
         try
         {
            cmdBuffer=" CREATE SEQUENCE ClienteDocumentoId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE ClienteDocumentoId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE ClienteDocumentoId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE ClienteDocumento (ClienteDocumentoId integer NOT NULL DEFAULT nextval('ClienteDocumentoId'), ClienteId integer , DocumentosId integer , ClienteDocumentoBlob BYTEA , ClienteDocumentoNome VARCHAR(100) , ClienteDocumentoExtensao VARCHAR(100) , ClienteDocumentoCreatedAt timestamp without time zone , ClienteDocumentoCreatedBy smallint , ClienteDocumentoUpdatedAt timestamp without time zone , PRIMARY KEY(ClienteDocumentoId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE ClienteDocumento CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW ClienteDocumento CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION ClienteDocumento CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE ClienteDocumento (ClienteDocumentoId integer NOT NULL DEFAULT nextval('ClienteDocumentoId'), ClienteId integer , DocumentosId integer , ClienteDocumentoBlob BYTEA , ClienteDocumentoNome VARCHAR(100) , ClienteDocumentoExtensao VARCHAR(100) , ClienteDocumentoCreatedAt timestamp without time zone , ClienteDocumentoCreatedBy smallint , ClienteDocumentoUpdatedAt timestamp without time zone , PRIMARY KEY(ClienteDocumentoId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ICLIENTEDOCUMENTO1 ON ClienteDocumento (DocumentosId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ICLIENTEDOCUMENTO1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ICLIENTEDOCUMENTO1 ON ClienteDocumento (DocumentosId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ICLIENTEDOCUMENTO2 ON ClienteDocumento (ClienteId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ICLIENTEDOCUMENTO2 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ICLIENTEDOCUMENTO2 ON ClienteDocumento (ClienteId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ICLIENTEDOCUMENTO3 ON ClienteDocumento (ClienteDocumentoCreatedBy ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ICLIENTEDOCUMENTO3 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ICLIENTEDOCUMENTO3 ON ClienteDocumento (ClienteDocumentoCreatedBy ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreatePropostaContratoAssinatura( )
      {
         string cmdBuffer = "";
         /* Indices for table PropostaContratoAssinatura */
         try
         {
            cmdBuffer=" CREATE SEQUENCE PropostaContratoAssinaturaId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE PropostaContratoAssinaturaId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE PropostaContratoAssinaturaId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE PropostaContratoAssinatura (PropostaContratoAssinaturaId integer NOT NULL DEFAULT nextval('PropostaContratoAssinaturaId'), PropostaId integer , PropostaContrato integer , PropostaAssinatura bigint , PropostaContratoAssinaturaTipo VARCHAR(60) , PRIMARY KEY(PropostaContratoAssinaturaId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE PropostaContratoAssinatura CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW PropostaContratoAssinatura CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION PropostaContratoAssinatura CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE PropostaContratoAssinatura (PropostaContratoAssinaturaId integer NOT NULL DEFAULT nextval('PropostaContratoAssinaturaId'), PropostaId integer , PropostaContrato integer , PropostaAssinatura bigint , PropostaContratoAssinaturaTipo VARCHAR(60) , PRIMARY KEY(PropostaContratoAssinaturaId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IPROPOSTACONTRATOASSINATURA1 ON PropostaContratoAssinatura (PropostaId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IPROPOSTACONTRATOASSINATURA1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IPROPOSTACONTRATOASSINATURA1 ON PropostaContratoAssinatura (PropostaId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IPROPOSTACONTRATOASSINATURA2 ON PropostaContratoAssinatura (PropostaContrato ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IPROPOSTACONTRATOASSINATURA2 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IPROPOSTACONTRATOASSINATURA2 ON PropostaContratoAssinatura (PropostaContrato ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IPROPOSTACONTRATOASSINATURA3 ON PropostaContratoAssinatura (PropostaAssinatura ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IPROPOSTACONTRATOASSINATURA3 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IPROPOSTACONTRATOASSINATURA3 ON PropostaContratoAssinatura (PropostaAssinatura ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateSecUserLog( )
      {
         string cmdBuffer = "";
         /* Indices for table SecUserLog */
         try
         {
            cmdBuffer=" CREATE SEQUENCE SecUserLogId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE SecUserLogId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE SecUserLogId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE SecUserLog (SecUserLogId integer NOT NULL DEFAULT nextval('SecUserLogId'), SecUserId smallint , SecUserLogDateTime timestamp without time zone , PRIMARY KEY(SecUserLogId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE SecUserLog CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW SecUserLog CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION SecUserLog CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE SecUserLog (SecUserLogId integer NOT NULL DEFAULT nextval('SecUserLogId'), SecUserId smallint , SecUserLogDateTime timestamp without time zone , PRIMARY KEY(SecUserLogId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ISECUSERLOG1 ON SecUserLog (SecUserId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ISECUSERLOG1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ISECUSERLOG1 ON SecUserLog (SecUserId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateAssinaturaParticipanteToken( )
      {
         string cmdBuffer = "";
         /* Indices for table AssinaturaParticipanteToken */
         try
         {
            cmdBuffer=" CREATE SEQUENCE AssinaturaParticipanteTokenId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE AssinaturaParticipanteTokenId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE AssinaturaParticipanteTokenId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE AssinaturaParticipanteToken (AssinaturaParticipanteTokenId integer NOT NULL DEFAULT nextval('AssinaturaParticipanteTokenId'), AssinaturaParticipanteId integer , AssinaturaParticipanteTokenExpire timestamp without time zone , AssinaturaParticipanteTokenUsed BOOLEAN , AssinaturaParticipanteTokenContent VARCHAR(40) , PRIMARY KEY(AssinaturaParticipanteTokenId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE AssinaturaParticipanteToken CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW AssinaturaParticipanteToken CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION AssinaturaParticipanteToken CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE AssinaturaParticipanteToken (AssinaturaParticipanteTokenId integer NOT NULL DEFAULT nextval('AssinaturaParticipanteTokenId'), AssinaturaParticipanteId integer , AssinaturaParticipanteTokenExpire timestamp without time zone , AssinaturaParticipanteTokenUsed BOOLEAN , AssinaturaParticipanteTokenContent VARCHAR(40) , PRIMARY KEY(AssinaturaParticipanteTokenId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IASSINATURAPARTICIPANTETOKEN1 ON AssinaturaParticipanteToken (AssinaturaParticipanteId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IASSINATURAPARTICIPANTETOKEN1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IASSINATURAPARTICIPANTETOKEN1 ON AssinaturaParticipanteToken (AssinaturaParticipanteId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateClienteReponsavel( )
      {
         string cmdBuffer = "";
         /* Indices for table ClienteReponsavel */
         try
         {
            cmdBuffer=" CREATE SEQUENCE ClienteReponsavelId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE ClienteReponsavelId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE ClienteReponsavelId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE ClienteReponsavel (ClienteReponsavelId integer NOT NULL DEFAULT nextval('ClienteReponsavelId'), ReponsavelClienteId integer , ClienteId integer , PRIMARY KEY(ClienteReponsavelId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE ClienteReponsavel CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW ClienteReponsavel CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION ClienteReponsavel CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE ClienteReponsavel (ClienteReponsavelId integer NOT NULL DEFAULT nextval('ClienteReponsavelId'), ReponsavelClienteId integer , ClienteId integer , PRIMARY KEY(ClienteReponsavelId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ICLIENTEREPONSAVEL1 ON ClienteReponsavel (ClienteId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ICLIENTEREPONSAVEL1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ICLIENTEREPONSAVEL1 ON ClienteReponsavel (ClienteId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ICLIENTEREPONSAVEL2 ON ClienteReponsavel (ReponsavelClienteId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ICLIENTEREPONSAVEL2 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ICLIENTEREPONSAVEL2 ON ClienteReponsavel (ReponsavelClienteId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateReembolsoDocumento( )
      {
         string cmdBuffer = "";
         /* Indices for table ReembolsoDocumento */
         try
         {
            cmdBuffer=" CREATE SEQUENCE ReembolsoDocumentoId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE ReembolsoDocumentoId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE ReembolsoDocumentoId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE ReembolsoDocumento (ReembolsoDocumentoId integer NOT NULL DEFAULT nextval('ReembolsoDocumentoId'), ReembolsoEtapaId integer , ReembolsoDocumentoNome VARCHAR(60) , ReembolsoDocumentoBlob BYTEA , ReembolsoDocumentoBlobExt VARCHAR(60) , ReembolsoDocumentoCreatedAt timestamp without time zone , DocumentosId integer , ReembolsoDocumentoStatus VARCHAR(40) , PRIMARY KEY(ReembolsoDocumentoId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE ReembolsoDocumento CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW ReembolsoDocumento CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION ReembolsoDocumento CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE ReembolsoDocumento (ReembolsoDocumentoId integer NOT NULL DEFAULT nextval('ReembolsoDocumentoId'), ReembolsoEtapaId integer , ReembolsoDocumentoNome VARCHAR(60) , ReembolsoDocumentoBlob BYTEA , ReembolsoDocumentoBlobExt VARCHAR(60) , ReembolsoDocumentoCreatedAt timestamp without time zone , DocumentosId integer , ReembolsoDocumentoStatus VARCHAR(40) , PRIMARY KEY(ReembolsoDocumentoId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IREEMBOLSODOCUMENTO1 ON ReembolsoDocumento (DocumentosId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IREEMBOLSODOCUMENTO1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IREEMBOLSODOCUMENTO1 ON ReembolsoDocumento (DocumentosId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IREEMBOLSODOCUMENTO2 ON ReembolsoDocumento (ReembolsoEtapaId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IREEMBOLSODOCUMENTO2 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IREEMBOLSODOCUMENTO2 ON ReembolsoDocumento (ReembolsoEtapaId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateEtapa( )
      {
         string cmdBuffer = "";
         /* Indices for table Etapa */
         try
         {
            cmdBuffer=" CREATE SEQUENCE EtapaId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE EtapaId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE EtapaId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE Etapa (EtapaId integer NOT NULL DEFAULT nextval('EtapaId'), EtapaDescricao VARCHAR(60) , EtapaCreatedAt timestamp without time zone NOT NULL , PRIMARY KEY(EtapaId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Etapa CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Etapa CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Etapa CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Etapa (EtapaId integer NOT NULL DEFAULT nextval('EtapaId'), EtapaDescricao VARCHAR(60) , EtapaCreatedAt timestamp without time zone NOT NULL , PRIMARY KEY(EtapaId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateReembolsoEtapa( )
      {
         string cmdBuffer = "";
         /* Indices for table ReembolsoEtapa */
         try
         {
            cmdBuffer=" CREATE SEQUENCE ReembolsoEtapaId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE ReembolsoEtapaId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE ReembolsoEtapaId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE ReembolsoEtapa (ReembolsoEtapaId integer NOT NULL DEFAULT nextval('ReembolsoEtapaId'), ReembolsoId integer , ReembolsoEtapaCreatedAt timestamp without time zone , ReembolsoEtapaStatus VARCHAR(40) , PRIMARY KEY(ReembolsoEtapaId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE ReembolsoEtapa CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW ReembolsoEtapa CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION ReembolsoEtapa CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE ReembolsoEtapa (ReembolsoEtapaId integer NOT NULL DEFAULT nextval('ReembolsoEtapaId'), ReembolsoId integer , ReembolsoEtapaCreatedAt timestamp without time zone , ReembolsoEtapaStatus VARCHAR(40) , PRIMARY KEY(ReembolsoEtapaId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IREEMBOLSOETAPA1 ON ReembolsoEtapa (ReembolsoId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IREEMBOLSOETAPA1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IREEMBOLSOETAPA1 ON ReembolsoEtapa (ReembolsoId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateReembolso( )
      {
         string cmdBuffer = "";
         /* Indices for table Reembolso */
         try
         {
            cmdBuffer=" CREATE SEQUENCE ReembolsoId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE ReembolsoId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE ReembolsoId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE Reembolso (ReembolsoId integer NOT NULL DEFAULT nextval('ReembolsoId'), ReembolsoPropostaId integer , ReembolsoProtocolo VARCHAR(40) , ReembolsoCreatedAt timestamp without time zone , ReembolsoDataAberturaConvenio date , ReembolsoCreatedBy smallint , WorkflowConvenioId integer , PRIMARY KEY(ReembolsoId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Reembolso CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Reembolso CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Reembolso CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Reembolso (ReembolsoId integer NOT NULL DEFAULT nextval('ReembolsoId'), ReembolsoPropostaId integer , ReembolsoProtocolo VARCHAR(40) , ReembolsoCreatedAt timestamp without time zone , ReembolsoDataAberturaConvenio date , ReembolsoCreatedBy smallint , WorkflowConvenioId integer , PRIMARY KEY(ReembolsoId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IREEMBOLSO1 ON Reembolso (ReembolsoPropostaId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IREEMBOLSO1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IREEMBOLSO1 ON Reembolso (ReembolsoPropostaId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IREEMBOLSO2 ON Reembolso (ReembolsoCreatedBy ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IREEMBOLSO2 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IREEMBOLSO2 ON Reembolso (ReembolsoCreatedBy ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IREEMBOLSO3 ON Reembolso (WorkflowConvenioId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IREEMBOLSO3 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IREEMBOLSO3 ON Reembolso (WorkflowConvenioId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateConvenioCategoria( )
      {
         string cmdBuffer = "";
         /* Indices for table ConvenioCategoria */
         try
         {
            cmdBuffer=" CREATE SEQUENCE ConvenioCategoriaId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE ConvenioCategoriaId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE ConvenioCategoriaId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE ConvenioCategoria (ConvenioCategoriaId integer NOT NULL DEFAULT nextval('ConvenioCategoriaId'), ConvenioId integer , ConvenioCategoriaDescricao VARCHAR(70) , ConvenioCategoriaStatus BOOLEAN , PRIMARY KEY(ConvenioCategoriaId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE ConvenioCategoria CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW ConvenioCategoria CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION ConvenioCategoria CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE ConvenioCategoria (ConvenioCategoriaId integer NOT NULL DEFAULT nextval('ConvenioCategoriaId'), ConvenioId integer , ConvenioCategoriaDescricao VARCHAR(70) , ConvenioCategoriaStatus BOOLEAN , PRIMARY KEY(ConvenioCategoriaId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ICONVENIOCATEGORIA1 ON ConvenioCategoria (ConvenioId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ICONVENIOCATEGORIA1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ICONVENIOCATEGORIA1 ON ConvenioCategoria (ConvenioId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateConfiguracaoNotificacoes( )
      {
         string cmdBuffer = "";
         /* Indices for table ConfiguracaoNotificacoes */
         try
         {
            cmdBuffer=" CREATE SEQUENCE ConfiguracaoNotificacoesId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE ConfiguracaoNotificacoesId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE ConfiguracaoNotificacoesId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE ConfiguracaoNotificacoes (ConfiguracaoNotificacoesId integer NOT NULL DEFAULT nextval('ConfiguracaoNotificacoesId'), ConfiguracaoNotificacoesEmail VARCHAR(100) , PRIMARY KEY(ConfiguracaoNotificacoesId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE ConfiguracaoNotificacoes CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW ConfiguracaoNotificacoes CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION ConfiguracaoNotificacoes CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE ConfiguracaoNotificacoes (ConfiguracaoNotificacoesId integer NOT NULL DEFAULT nextval('ConfiguracaoNotificacoesId'), ConfiguracaoNotificacoesEmail VARCHAR(100) , PRIMARY KEY(ConfiguracaoNotificacoesId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateConfiguracoesTestemunhas( )
      {
         string cmdBuffer = "";
         /* Indices for table ConfiguracoesTestemunhas */
         try
         {
            cmdBuffer=" CREATE SEQUENCE ConfiguracoesTestemunhasId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE ConfiguracoesTestemunhasId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE ConfiguracoesTestemunhasId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE ConfiguracoesTestemunhas (ConfiguracoesTestemunhasId integer NOT NULL DEFAULT nextval('ConfiguracoesTestemunhasId'), ConfiguracoesTestemunhasNome VARCHAR(70) , ConfiguracoesTestemunhasDocumento VARCHAR(40) , ConfiguracoesTestemunhasEmail VARCHAR(100) , SecUserId smallint , PRIMARY KEY(ConfiguracoesTestemunhasId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE ConfiguracoesTestemunhas CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW ConfiguracoesTestemunhas CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION ConfiguracoesTestemunhas CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE ConfiguracoesTestemunhas (ConfiguracoesTestemunhasId integer NOT NULL DEFAULT nextval('ConfiguracoesTestemunhasId'), ConfiguracoesTestemunhasNome VARCHAR(70) , ConfiguracoesTestemunhasDocumento VARCHAR(40) , ConfiguracoesTestemunhasEmail VARCHAR(100) , SecUserId smallint , PRIMARY KEY(ConfiguracoesTestemunhasId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ICONFIGURACOESTESTEMUNHAS1 ON ConfiguracoesTestemunhas (SecUserId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ICONFIGURACOESTESTEMUNHAS1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ICONFIGURACOESTESTEMUNHAS1 ON ConfiguracoesTestemunhas (SecUserId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateEspecialidade( )
      {
         string cmdBuffer = "";
         /* Indices for table Especialidade */
         try
         {
            cmdBuffer=" CREATE SEQUENCE EspecialidadeId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE EspecialidadeId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE EspecialidadeId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE Especialidade (EspecialidadeId integer NOT NULL DEFAULT nextval('EspecialidadeId'), EspecialidadeNome VARCHAR(60) , EspecialidadeStatus BOOLEAN , EspecialidadeUpdatedAt timestamp without time zone , EspecialidadeCreatedAt timestamp without time zone , EspecialidadeCreatedBy smallint , PRIMARY KEY(EspecialidadeId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Especialidade CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Especialidade CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Especialidade CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Especialidade (EspecialidadeId integer NOT NULL DEFAULT nextval('EspecialidadeId'), EspecialidadeNome VARCHAR(60) , EspecialidadeStatus BOOLEAN , EspecialidadeUpdatedAt timestamp without time zone , EspecialidadeCreatedAt timestamp without time zone , EspecialidadeCreatedBy smallint , PRIMARY KEY(EspecialidadeId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IESPECIALIDADE1 ON Especialidade (EspecialidadeCreatedBy ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IESPECIALIDADE1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IESPECIALIDADE1 ON Especialidade (EspecialidadeCreatedBy ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateProfissao( )
      {
         string cmdBuffer = "";
         /* Indices for table Profissao */
         try
         {
            cmdBuffer=" CREATE SEQUENCE ProfissaoId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE ProfissaoId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE ProfissaoId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE Profissao (ProfissaoId integer NOT NULL DEFAULT nextval('ProfissaoId'), ProfissaoNome VARCHAR(90) , PRIMARY KEY(ProfissaoId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Profissao CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Profissao CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Profissao CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Profissao (ProfissaoId integer NOT NULL DEFAULT nextval('ProfissaoId'), ProfissaoNome VARCHAR(90) , PRIMARY KEY(ProfissaoId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateNacionalidade( )
      {
         string cmdBuffer = "";
         /* Indices for table Nacionalidade */
         try
         {
            cmdBuffer=" CREATE SEQUENCE NacionalidadeId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE NacionalidadeId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE NacionalidadeId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE Nacionalidade (NacionalidadeId integer NOT NULL DEFAULT nextval('NacionalidadeId'), NacionalidadeNome VARCHAR(100) , PRIMARY KEY(NacionalidadeId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Nacionalidade CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Nacionalidade CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Nacionalidade CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Nacionalidade (NacionalidadeId integer NOT NULL DEFAULT nextval('NacionalidadeId'), NacionalidadeNome VARCHAR(100) , PRIMARY KEY(NacionalidadeId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateCategoriaTitulo( )
      {
         string cmdBuffer = "";
         /* Indices for table CategoriaTitulo */
         try
         {
            cmdBuffer=" CREATE SEQUENCE CategoriaTituloId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE CategoriaTituloId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE CategoriaTituloId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE CategoriaTitulo (CategoriaTituloId integer NOT NULL DEFAULT nextval('CategoriaTituloId'), CategoriaTituloNome VARCHAR(60) , CategoriaTituloDescricao VARCHAR(150) , CategoriaStatus BOOLEAN , PRIMARY KEY(CategoriaTituloId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE CategoriaTitulo CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW CategoriaTitulo CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION CategoriaTitulo CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE CategoriaTitulo (CategoriaTituloId integer NOT NULL DEFAULT nextval('CategoriaTituloId'), CategoriaTituloNome VARCHAR(60) , CategoriaTituloDescricao VARCHAR(150) , CategoriaStatus BOOLEAN , PRIMARY KEY(CategoriaTituloId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateConta( )
      {
         string cmdBuffer = "";
         /* Indices for table Conta */
         try
         {
            cmdBuffer=" CREATE SEQUENCE ContaId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE ContaId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE ContaId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE Conta (ContaId integer NOT NULL DEFAULT nextval('ContaId'), ContaSaldoAtual NUMERIC(17,2) , ContaNomeConta VARCHAR(60) , ContaDataUltimaAtualizacao timestamp without time zone , ContaStatus BOOLEAN , ContaProposta BOOLEAN , PRIMARY KEY(ContaId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Conta CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Conta CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Conta CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Conta (ContaId integer NOT NULL DEFAULT nextval('ContaId'), ContaSaldoAtual NUMERIC(17,2) , ContaNomeConta VARCHAR(60) , ContaDataUltimaAtualizacao timestamp without time zone , ContaStatus BOOLEAN , ContaProposta BOOLEAN , PRIMARY KEY(ContaId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreatePropostaDocumentos( )
      {
         string cmdBuffer = "";
         /* Indices for table PropostaDocumentos */
         try
         {
            cmdBuffer=" CREATE SEQUENCE PropostaDocumentosId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE PropostaDocumentosId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE PropostaDocumentosId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE PropostaDocumentos (PropostaDocumentosId integer NOT NULL DEFAULT nextval('PropostaDocumentosId'), PropostaId integer , DocumentosId integer , PropostaDocumentosAnexo BYTEA , PropostaDocumentosAnexoName VARCHAR(128) , PropostaDocumentosAnexoFileType VARCHAR(40) , PropostaDocumentosStatus VARCHAR(40) , PropostaDocumentosAdm BOOLEAN , PRIMARY KEY(PropostaDocumentosId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE PropostaDocumentos CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW PropostaDocumentos CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION PropostaDocumentos CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE PropostaDocumentos (PropostaDocumentosId integer NOT NULL DEFAULT nextval('PropostaDocumentosId'), PropostaId integer , DocumentosId integer , PropostaDocumentosAnexo BYTEA , PropostaDocumentosAnexoName VARCHAR(128) , PropostaDocumentosAnexoFileType VARCHAR(40) , PropostaDocumentosStatus VARCHAR(40) , PropostaDocumentosAdm BOOLEAN , PRIMARY KEY(PropostaDocumentosId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IPROPOSTADOCUMENTOS1 ON PropostaDocumentos (DocumentosId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IPROPOSTADOCUMENTOS1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IPROPOSTADOCUMENTOS1 ON PropostaDocumentos (DocumentosId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IPROPOSTADOCUMENTOS2 ON PropostaDocumentos (PropostaId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IPROPOSTADOCUMENTOS2 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IPROPOSTADOCUMENTOS2 ON PropostaDocumentos (PropostaId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateConvenio( )
      {
         string cmdBuffer = "";
         /* Indices for table Convenio */
         try
         {
            cmdBuffer=" CREATE SEQUENCE ConvenioId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE ConvenioId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE ConvenioId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE Convenio (ConvenioId integer NOT NULL DEFAULT nextval('ConvenioId'), ConvenioDescricao VARCHAR(40) , ConvenioStatus BOOLEAN NOT NULL , PRIMARY KEY(ConvenioId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Convenio CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Convenio CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Convenio CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Convenio (ConvenioId integer NOT NULL DEFAULT nextval('ConvenioId'), ConvenioDescricao VARCHAR(40) , ConvenioStatus BOOLEAN NOT NULL , PRIMARY KEY(ConvenioId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateDocumentos( )
      {
         string cmdBuffer = "";
         /* Indices for table Documentos */
         try
         {
            cmdBuffer=" CREATE SEQUENCE DocumentosId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE DocumentosId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE DocumentosId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE Documentos (DocumentosId integer NOT NULL DEFAULT nextval('DocumentosId'), DocumentosDescricao VARCHAR(40) , DocumentosStatus BOOLEAN , DocumentoObrigatorio BOOLEAN , DocumentoObrigatorioReembolso BOOLEAN , PRIMARY KEY(DocumentosId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Documentos CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Documentos CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Documentos CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Documentos (DocumentosId integer NOT NULL DEFAULT nextval('DocumentosId'), DocumentosDescricao VARCHAR(40) , DocumentosStatus BOOLEAN , DocumentoObrigatorio BOOLEAN , DocumentoObrigatorioReembolso BOOLEAN , PRIMARY KEY(DocumentosId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateBanco( )
      {
         string cmdBuffer = "";
         /* Indices for table Banco */
         try
         {
            cmdBuffer=" CREATE SEQUENCE BancoId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE BancoId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE BancoId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE Banco (BancoId integer NOT NULL DEFAULT nextval('BancoId'), BancoCodigo integer , BancoNome VARCHAR(150) , PRIMARY KEY(BancoId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Banco CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Banco CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Banco CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Banco (BancoId integer NOT NULL DEFAULT nextval('BancoId'), BancoCodigo integer , BancoNome VARCHAR(150) , PRIMARY KEY(BancoId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE UNIQUE INDEX UBANCOCODIGO ON Banco (BancoCodigo ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX UBANCOCODIGO "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE UNIQUE INDEX UBANCOCODIGO ON Banco (BancoCodigo ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateEmailQueue( )
      {
         string cmdBuffer = "";
         /* Indices for table EmailQueue */
         try
         {
            cmdBuffer=" CREATE SEQUENCE EmailQueueId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE EmailQueueId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE EmailQueueId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE EmailQueue (EmailQueueId integer NOT NULL DEFAULT nextval('EmailQueueId'), NotificationId integer , EmailQueueRecipient VARCHAR(100) , EmailQueueStatus VARCHAR(40) , EmailQueueSentAt timestamp without time zone , EmailQueueErrorMessage VARCHAR(255) , PRIMARY KEY(EmailQueueId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE EmailQueue CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW EmailQueue CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION EmailQueue CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE EmailQueue (EmailQueueId integer NOT NULL DEFAULT nextval('EmailQueueId'), NotificationId integer , EmailQueueRecipient VARCHAR(100) , EmailQueueStatus VARCHAR(40) , EmailQueueSentAt timestamp without time zone , EmailQueueErrorMessage VARCHAR(255) , PRIMARY KEY(EmailQueueId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IEMAILQUEUE1 ON EmailQueue (NotificationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IEMAILQUEUE1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IEMAILQUEUE1 ON EmailQueue (NotificationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateUserNotification( )
      {
         string cmdBuffer = "";
         /* Indices for table UserNotification */
         try
         {
            cmdBuffer=" CREATE SEQUENCE UserNotificationId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE UserNotificationId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE UserNotificationId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE UserNotification (UserNotificationId integer NOT NULL DEFAULT nextval('UserNotificationId'), NotificationId integer , UserNotificationUserId smallint , UserNotificationStatus VARCHAR(40) , UserNotificationSentAt timestamp without time zone , UserNotificationReadAt timestamp without time zone , PRIMARY KEY(UserNotificationId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE UserNotification CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW UserNotification CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION UserNotification CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE UserNotification (UserNotificationId integer NOT NULL DEFAULT nextval('UserNotificationId'), NotificationId integer , UserNotificationUserId smallint , UserNotificationStatus VARCHAR(40) , UserNotificationSentAt timestamp without time zone , UserNotificationReadAt timestamp without time zone , PRIMARY KEY(UserNotificationId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IUSERNOTIFICATION1 ON UserNotification (NotificationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IUSERNOTIFICATION1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IUSERNOTIFICATION1 ON UserNotification (NotificationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IUSERNOTIFICATION2 ON UserNotification (UserNotificationUserId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IUSERNOTIFICATION2 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IUSERNOTIFICATION2 ON UserNotification (UserNotificationUserId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateNotification( )
      {
         string cmdBuffer = "";
         /* Indices for table Notification */
         try
         {
            cmdBuffer=" CREATE SEQUENCE NotificationId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE NotificationId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE NotificationId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE Notification (NotificationId integer NOT NULL DEFAULT nextval('NotificationId'), NotificationTitle VARCHAR(60) , NotificationMessage VARCHAR(106) , NotificationType VARCHAR(40) , NotificationCreatedAt timestamp without time zone , NotificationStatus VARCHAR(40) , SecUserId smallint , NotificationLink VARCHAR(1000) , PRIMARY KEY(NotificationId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Notification CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Notification CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Notification CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Notification (NotificationId integer NOT NULL DEFAULT nextval('NotificationId'), NotificationTitle VARCHAR(60) , NotificationMessage VARCHAR(106) , NotificationType VARCHAR(40) , NotificationCreatedAt timestamp without time zone , NotificationStatus VARCHAR(40) , SecUserId smallint , NotificationLink VARCHAR(1000) , PRIMARY KEY(NotificationId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX INOTIFICATION1 ON Notification (SecUserId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX INOTIFICATION1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX INOTIFICATION1 ON Notification (SecUserId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateAprovadores( )
      {
         string cmdBuffer = "";
         /* Indices for table Aprovadores */
         try
         {
            cmdBuffer=" CREATE SEQUENCE AprovadoresId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE AprovadoresId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE AprovadoresId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE Aprovadores (AprovadoresId integer NOT NULL DEFAULT nextval('AprovadoresId'), SecUserId smallint , AprovadoresStatus BOOLEAN , PRIMARY KEY(AprovadoresId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Aprovadores CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Aprovadores CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Aprovadores CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Aprovadores (AprovadoresId integer NOT NULL DEFAULT nextval('AprovadoresId'), SecUserId smallint , AprovadoresStatus BOOLEAN , PRIMARY KEY(AprovadoresId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE UNIQUE INDEX APROVADORES_UNIQUE_SECUSERID ON Aprovadores (SecUserId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX APROVADORES_UNIQUE_SECUSERID "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE UNIQUE INDEX APROVADORES_UNIQUE_SECUSERID ON Aprovadores (SecUserId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateProcedimentosMedicos( )
      {
         string cmdBuffer = "";
         /* Indices for table ProcedimentosMedicos */
         try
         {
            cmdBuffer=" CREATE SEQUENCE ProcedimentosMedicosId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE ProcedimentosMedicosId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE ProcedimentosMedicosId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE ProcedimentosMedicos (ProcedimentosMedicosId integer NOT NULL DEFAULT nextval('ProcedimentosMedicosId'), ProcedimentosMedicosNome VARCHAR(255) , ProcedimentosMedicosDescricao TEXT , ProcedimentosMedicosArea VARCHAR(255) , CID integer , ProcedimentosMedicosAtivo BOOLEAN NOT NULL , PRIMARY KEY(ProcedimentosMedicosId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE ProcedimentosMedicos CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW ProcedimentosMedicos CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION ProcedimentosMedicos CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE ProcedimentosMedicos (ProcedimentosMedicosId integer NOT NULL DEFAULT nextval('ProcedimentosMedicosId'), ProcedimentosMedicosNome VARCHAR(255) , ProcedimentosMedicosDescricao TEXT , ProcedimentosMedicosArea VARCHAR(255) , CID integer , ProcedimentosMedicosAtivo BOOLEAN NOT NULL , PRIMARY KEY(ProcedimentosMedicosId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTags( )
      {
         string cmdBuffer = "";
         /* Indices for table Tags */
         try
         {
            cmdBuffer=" CREATE SEQUENCE TagsId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE TagsId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE TagsId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE Tags (TagsId integer NOT NULL DEFAULT nextval('TagsId'), TagsDescricao VARCHAR(108) , TagsConteudo VARCHAR(40) , PRIMARY KEY(TagsId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Tags CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Tags CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Tags CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Tags (TagsId integer NOT NULL DEFAULT nextval('TagsId'), TagsDescricao VARCHAR(108) , TagsConteudo VARCHAR(40) , PRIMARY KEY(TagsId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateFilaProcessamento( )
      {
         string cmdBuffer = "";
         /* Indices for table FilaProcessamento */
         try
         {
            cmdBuffer=" CREATE SEQUENCE FilaProcessamentoId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE FilaProcessamentoId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE FilaProcessamentoId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE FilaProcessamento (FilaProcessamentoId integer NOT NULL DEFAULT nextval('FilaProcessamentoId'), FilaProcessamentoFuncao VARCHAR(100) , FilaProcessamentoParametros TEXT , FilaProcessamentoStatus VARCHAR(40) , FilaProcessamentoCriacao timestamp without time zone , FilaProcessamentoAtualizacao timestamp without time zone , PRIMARY KEY(FilaProcessamentoId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE FilaProcessamento CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW FilaProcessamento CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION FilaProcessamento CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE FilaProcessamento (FilaProcessamentoId integer NOT NULL DEFAULT nextval('FilaProcessamentoId'), FilaProcessamentoFuncao VARCHAR(100) , FilaProcessamentoParametros TEXT , FilaProcessamentoStatus VARCHAR(40) , FilaProcessamentoCriacao timestamp without time zone , FilaProcessamentoAtualizacao timestamp without time zone , PRIMARY KEY(FilaProcessamentoId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateAprovacao( )
      {
         string cmdBuffer = "";
         /* Indices for table Aprovacao */
         try
         {
            cmdBuffer=" CREATE SEQUENCE AprovacaoId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE AprovacaoId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE AprovacaoId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE Aprovacao (AprovacaoId integer NOT NULL DEFAULT nextval('AprovacaoId'), PropostaId integer , AprovacaoEm timestamp without time zone , AprovacaoDecisao VARCHAR(255) , AprovacaoStatus VARCHAR(40) , AprovadoresId integer , PRIMARY KEY(AprovacaoId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Aprovacao CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Aprovacao CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Aprovacao CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Aprovacao (AprovacaoId integer NOT NULL DEFAULT nextval('AprovacaoId'), PropostaId integer , AprovacaoEm timestamp without time zone , AprovacaoDecisao VARCHAR(255) , AprovacaoStatus VARCHAR(40) , AprovadoresId integer , PRIMARY KEY(AprovacaoId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IAPROVACAO1 ON Aprovacao (PropostaId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IAPROVACAO1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IAPROVACAO1 ON Aprovacao (PropostaId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IAPROVACAO2 ON Aprovacao (AprovadoresId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IAPROVACAO2 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IAPROVACAO2 ON Aprovacao (AprovadoresId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateLimiteAprovacao( )
      {
         string cmdBuffer = "";
         /* Indices for table LimiteAprovacao */
         try
         {
            cmdBuffer=" CREATE SEQUENCE LimiteAprovacaoId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE LimiteAprovacaoId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE LimiteAprovacaoId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE LimiteAprovacao (LimiteAprovacaoId integer NOT NULL DEFAULT nextval('LimiteAprovacaoId'), LimiteAprovacaoValorMinimo NUMERIC(17,2) , LimiteAprovacaoAprovacoes smallint , LimiteAprovacaoReprovacoesPermitidas smallint NOT NULL , PRIMARY KEY(LimiteAprovacaoId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE LimiteAprovacao CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW LimiteAprovacao CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION LimiteAprovacao CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE LimiteAprovacao (LimiteAprovacaoId integer NOT NULL DEFAULT nextval('LimiteAprovacaoId'), LimiteAprovacaoValorMinimo NUMERIC(17,2) , LimiteAprovacaoAprovacoes smallint , LimiteAprovacaoReprovacoesPermitidas smallint NOT NULL , PRIMARY KEY(LimiteAprovacaoId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateProposta( )
      {
         string cmdBuffer = "";
         /* Indices for table Proposta */
         try
         {
            cmdBuffer=" CREATE SEQUENCE PropostaId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE PropostaId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE PropostaId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE Proposta (PropostaId integer NOT NULL DEFAULT nextval('PropostaId'), PropostaTitulo VARCHAR(150) , PropostaDescricao VARCHAR(150) , PropostaValor NUMERIC(17,2) , PropostaCreatedAt timestamp without time zone , PropostaCratedBy smallint , PropostaStatus VARCHAR(150) , ContratoId integer , PropostaQuantidadeAprovadores smallint , PropostaReprovacoesPermitidas smallint , ProcedimentosMedicosId integer , ConvenioVencimentoAno smallint , ConvenioVencimentoMes smallint , ConvenioCategoriaId integer , PropostaPacienteClienteId integer , PropostaTaxaAdministrativa NUMERIC(15,4) , PropostaSLA smallint , PropostaJurosMora NUMERIC(15,4) , PropostaDataCirurgia date , PropostaResponsavelId integer , PropostaClinicaId integer , PropostaComentarioAnalise VARCHAR(255) , PropostaProtocolo VARCHAR(40) , PropostaEmpresaClienteId integer , PropostaTipoProposta VARCHAR(40) , PropostaValorLiquido NUMERIC(17,2) , PRIMARY KEY(PropostaId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Proposta CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Proposta CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Proposta CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Proposta (PropostaId integer NOT NULL DEFAULT nextval('PropostaId'), PropostaTitulo VARCHAR(150) , PropostaDescricao VARCHAR(150) , PropostaValor NUMERIC(17,2) , PropostaCreatedAt timestamp without time zone , PropostaCratedBy smallint , PropostaStatus VARCHAR(150) , ContratoId integer , PropostaQuantidadeAprovadores smallint , PropostaReprovacoesPermitidas smallint , ProcedimentosMedicosId integer , ConvenioVencimentoAno smallint , ConvenioVencimentoMes smallint , ConvenioCategoriaId integer , PropostaPacienteClienteId integer , PropostaTaxaAdministrativa NUMERIC(15,4) , PropostaSLA smallint , PropostaJurosMora NUMERIC(15,4) , PropostaDataCirurgia date , PropostaResponsavelId integer , PropostaClinicaId integer , PropostaComentarioAnalise VARCHAR(255) , PropostaProtocolo VARCHAR(40) , PropostaEmpresaClienteId integer , PropostaTipoProposta VARCHAR(40) , PropostaValorLiquido NUMERIC(17,2) , PRIMARY KEY(PropostaId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IPROPOSTA1 ON Proposta (ContratoId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IPROPOSTA1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IPROPOSTA1 ON Proposta (ContratoId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IPROPOSTA2 ON Proposta (PropostaCratedBy ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IPROPOSTA2 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IPROPOSTA2 ON Proposta (PropostaCratedBy ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IPROPOSTA4 ON Proposta (ProcedimentosMedicosId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IPROPOSTA4 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IPROPOSTA4 ON Proposta (ProcedimentosMedicosId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IPROPOSTA5 ON Proposta (ConvenioCategoriaId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IPROPOSTA5 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IPROPOSTA5 ON Proposta (ConvenioCategoriaId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IPROPOSTA6 ON Proposta (PropostaPacienteClienteId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IPROPOSTA6 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IPROPOSTA6 ON Proposta (PropostaPacienteClienteId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IPROPOSTA3 ON Proposta (PropostaResponsavelId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IPROPOSTA3 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IPROPOSTA3 ON Proposta (PropostaResponsavelId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IPROPOSTA7 ON Proposta (PropostaClinicaId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IPROPOSTA7 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IPROPOSTA7 ON Proposta (PropostaClinicaId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IPROPOSTA8 ON Proposta (PropostaEmpresaClienteId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IPROPOSTA8 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IPROPOSTA8 ON Proposta (PropostaEmpresaClienteId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateConfiguracoes( )
      {
         string cmdBuffer = "";
         /* Indices for table Configuracoes */
         try
         {
            cmdBuffer=" CREATE SEQUENCE ConfiguracoesId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE ConfiguracoesId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE ConfiguracoesId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE Configuracoes (ConfiguracoesId integer NOT NULL DEFAULT nextval('ConfiguracoesId'), ConfiguracoesImagemLogin BYTEA , ConfiguracoesImagemLoginNome VARCHAR(150) , ConfiguracoesImagemLoginExtencao VARCHAR(150) , ConfiguracoesImagemLoginNomeInteiro VARCHAR(150) , ConfiguracoesImagemLoginTamanho NUMERIC(17,2) , ConfiguracoesImagemLoginBackground VARCHAR(40) , ConfiguracoesImagemHeader BYTEA , ConfiguracoesImagemHeaderNome VARCHAR(150) , ConfiguracoesImagemHeaderExtencao VARCHAR(150) , ConfiguracoesImagemHeaderNomeInteiro VARCHAR(150) , ConfiguracoesImagemHeaderTamanho NUMERIC(17,2) , ConfiguracoesLayoutProposta smallint , ConfigLayoutPromissoriaClinicaEmprestimo smallint , ConfigLayoutPromissoriaClinicaTaxa smallint , ConfigLayoutPromissoriaPaciente smallint , ConfiguracoesArquivoPFX BYTEA , ConfiguracaoSenhaPFX VARCHAR(50) , ConfiguracoesCategoriaTitulo integer , ConfiguracoesSerasaAnotacoesCompletas BOOLEAN , ConfiguracoesSerasaConsultaDetalhada BOOLEAN , ConfiguracoesSerasaParticipacaoSocietaria BOOLEAN , ConfiguracoesSerasaRendaEstimada BOOLEAN , ConfiguracoesSerasaHistoricoPagamento BOOLEAN , ConfigLayoutContratoCompraTitulo smallint , PRIMARY KEY(ConfiguracoesId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Configuracoes CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Configuracoes CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Configuracoes CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Configuracoes (ConfiguracoesId integer NOT NULL DEFAULT nextval('ConfiguracoesId'), ConfiguracoesImagemLogin BYTEA , ConfiguracoesImagemLoginNome VARCHAR(150) , ConfiguracoesImagemLoginExtencao VARCHAR(150) , ConfiguracoesImagemLoginNomeInteiro VARCHAR(150) , ConfiguracoesImagemLoginTamanho NUMERIC(17,2) , ConfiguracoesImagemLoginBackground VARCHAR(40) , ConfiguracoesImagemHeader BYTEA , ConfiguracoesImagemHeaderNome VARCHAR(150) , ConfiguracoesImagemHeaderExtencao VARCHAR(150) , ConfiguracoesImagemHeaderNomeInteiro VARCHAR(150) , ConfiguracoesImagemHeaderTamanho NUMERIC(17,2) , ConfiguracoesLayoutProposta smallint , ConfigLayoutPromissoriaClinicaEmprestimo smallint , ConfigLayoutPromissoriaClinicaTaxa smallint , ConfigLayoutPromissoriaPaciente smallint , ConfiguracoesArquivoPFX BYTEA , ConfiguracaoSenhaPFX VARCHAR(50) , ConfiguracoesCategoriaTitulo integer , ConfiguracoesSerasaAnotacoesCompletas BOOLEAN , ConfiguracoesSerasaConsultaDetalhada BOOLEAN , ConfiguracoesSerasaParticipacaoSocietaria BOOLEAN , ConfiguracoesSerasaRendaEstimada BOOLEAN , ConfiguracoesSerasaHistoricoPagamento BOOLEAN , ConfigLayoutContratoCompraTitulo smallint , PRIMARY KEY(ConfiguracoesId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ICONFIGURACOES1 ON Configuracoes (ConfiguracoesLayoutProposta ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ICONFIGURACOES1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ICONFIGURACOES1 ON Configuracoes (ConfiguracoesLayoutProposta ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ICONFIGURACOES2 ON Configuracoes (ConfigLayoutPromissoriaClinicaEmprestimo ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ICONFIGURACOES2 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ICONFIGURACOES2 ON Configuracoes (ConfigLayoutPromissoriaClinicaEmprestimo ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ICONFIGURACOES3 ON Configuracoes (ConfigLayoutPromissoriaClinicaTaxa ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ICONFIGURACOES3 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ICONFIGURACOES3 ON Configuracoes (ConfigLayoutPromissoriaClinicaTaxa ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ICONFIGURACOES4 ON Configuracoes (ConfigLayoutPromissoriaPaciente ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ICONFIGURACOES4 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ICONFIGURACOES4 ON Configuracoes (ConfigLayoutPromissoriaPaciente ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ICONFIGURACOES5 ON Configuracoes (ConfiguracoesCategoriaTitulo ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ICONFIGURACOES5 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ICONFIGURACOES5 ON Configuracoes (ConfiguracoesCategoriaTitulo ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ICONFIGURACOES6 ON Configuracoes (ConfigLayoutContratoCompraTitulo ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ICONFIGURACOES6 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ICONFIGURACOES6 ON Configuracoes (ConfigLayoutContratoCompraTitulo ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreatePreferencias( )
      {
         string cmdBuffer = "";
         /* Indices for table Preferencias */
         try
         {
            cmdBuffer=" CREATE SEQUENCE PreferenciasId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE PreferenciasId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE PreferenciasId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE Preferencias (PreferenciasId integer NOT NULL DEFAULT nextval('PreferenciasId'), PreferenciasMulta NUMERIC(15,4) , PreferenciasJuros NUMERIC(15,4) , PRIMARY KEY(PreferenciasId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Preferencias CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Preferencias CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Preferencias CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Preferencias (PreferenciasId integer NOT NULL DEFAULT nextval('PreferenciasId'), PreferenciasMulta NUMERIC(15,4) , PreferenciasJuros NUMERIC(15,4) , PRIMARY KEY(PreferenciasId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTipoPagamento( )
      {
         string cmdBuffer = "";
         /* Indices for table TipoPagamento */
         try
         {
            cmdBuffer=" CREATE SEQUENCE TipoPagamentoId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE TipoPagamentoId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE TipoPagamentoId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE TipoPagamento (TipoPagamentoId integer NOT NULL DEFAULT nextval('TipoPagamentoId'), TipoPagamentoNome VARCHAR(60) NOT NULL , PRIMARY KEY(TipoPagamentoId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE TipoPagamento CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW TipoPagamento CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION TipoPagamento CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE TipoPagamento (TipoPagamentoId integer NOT NULL DEFAULT nextval('TipoPagamentoId'), TipoPagamentoNome VARCHAR(60) NOT NULL , PRIMARY KEY(TipoPagamentoId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTituloMovimento( )
      {
         string cmdBuffer = "";
         /* Indices for table TituloMovimento */
         try
         {
            cmdBuffer=" CREATE SEQUENCE TituloMovimentoId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE TituloMovimentoId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE TituloMovimentoId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE TituloMovimento (TituloMovimentoId integer NOT NULL DEFAULT nextval('TituloMovimentoId'), TipoPagamentoId integer , TituloId integer , TituloMovimentoValor NUMERIC(17,2) , TituloMovimentoTipo VARCHAR(40) , TituloMovimentoSoma BOOLEAN , TituloMovimentoDataCredito date , TituloMovimentoCreatedAt timestamp without time zone , TituloMovimentoUpdatedAt timestamp without time zone , TituloMovimentoOpe VARCHAR(40) , TituloMovimentoConta integer , PRIMARY KEY(TituloMovimentoId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE TituloMovimento CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW TituloMovimento CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION TituloMovimento CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE TituloMovimento (TituloMovimentoId integer NOT NULL DEFAULT nextval('TituloMovimentoId'), TipoPagamentoId integer , TituloId integer , TituloMovimentoValor NUMERIC(17,2) , TituloMovimentoTipo VARCHAR(40) , TituloMovimentoSoma BOOLEAN , TituloMovimentoDataCredito date , TituloMovimentoCreatedAt timestamp without time zone , TituloMovimentoUpdatedAt timestamp without time zone , TituloMovimentoOpe VARCHAR(40) , TituloMovimentoConta integer , PRIMARY KEY(TituloMovimentoId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ITITULOMOVIMENTO1 ON TituloMovimento (TituloId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ITITULOMOVIMENTO1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ITITULOMOVIMENTO1 ON TituloMovimento (TituloId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ITITULOMOVIMENTO2 ON TituloMovimento (TipoPagamentoId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ITITULOMOVIMENTO2 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ITITULOMOVIMENTO2 ON TituloMovimento (TipoPagamentoId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ITITULOMOVIMENTO3 ON TituloMovimento (TituloMovimentoConta ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ITITULOMOVIMENTO3 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ITITULOMOVIMENTO3 ON TituloMovimento (TituloMovimentoConta ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTitulo( )
      {
         string cmdBuffer = "";
         /* Indices for table Titulo */
         try
         {
            cmdBuffer=" CREATE SEQUENCE TituloId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE TituloId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE TituloId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE Titulo (TituloId integer NOT NULL DEFAULT nextval('TituloId'), TituloValor NUMERIC(17,2) , TituloDesconto NUMERIC(17,2) , TituloDeleted BOOLEAN , TituloVencimento date , TituloCompetenciaAno smallint , TituloCompetenciaMes smallint , TituloProrrogacao date , TituloCEP VARCHAR(14) , TituloLogradouro VARCHAR(150) , TituloNumeroEndereco VARCHAR(10) , TituloComplemento VARCHAR(150) , TituloBairro VARCHAR(150) , TituloMunicipio VARCHAR(150) , TituloTipo VARCHAR(40) , TituloArchived BOOLEAN , TituloPropostaId integer , ContaId integer , CategoriaTituloId integer , TituloJurosMora NUMERIC(15,4) , TituloCriacao timestamp without time zone , TituloPropostaTipo VARCHAR(40) , NotaFiscalParcelamentoID CHAR(36) , ContaBancariaId integer , TituloClienteId integer , PRIMARY KEY(TituloId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Titulo CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Titulo CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Titulo CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Titulo (TituloId integer NOT NULL DEFAULT nextval('TituloId'), TituloValor NUMERIC(17,2) , TituloDesconto NUMERIC(17,2) , TituloDeleted BOOLEAN , TituloVencimento date , TituloCompetenciaAno smallint , TituloCompetenciaMes smallint , TituloProrrogacao date , TituloCEP VARCHAR(14) , TituloLogradouro VARCHAR(150) , TituloNumeroEndereco VARCHAR(10) , TituloComplemento VARCHAR(150) , TituloBairro VARCHAR(150) , TituloMunicipio VARCHAR(150) , TituloTipo VARCHAR(40) , TituloArchived BOOLEAN , TituloPropostaId integer , ContaId integer , CategoriaTituloId integer , TituloJurosMora NUMERIC(15,4) , TituloCriacao timestamp without time zone , TituloPropostaTipo VARCHAR(40) , NotaFiscalParcelamentoID CHAR(36) , ContaBancariaId integer , TituloClienteId integer , PRIMARY KEY(TituloId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ITITULO2 ON Titulo (CategoriaTituloId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ITITULO2 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ITITULO2 ON Titulo (CategoriaTituloId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ITITULO3 ON Titulo (ContaId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ITITULO3 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ITITULO3 ON Titulo (ContaId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ITITULO1 ON Titulo (TituloPropostaId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ITITULO1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ITITULO1 ON Titulo (TituloPropostaId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ITITULO4 ON Titulo (NotaFiscalParcelamentoID ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ITITULO4 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ITITULO4 ON Titulo (NotaFiscalParcelamentoID ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ITITULO5 ON Titulo (ContaBancariaId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ITITULO5 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ITITULO5 ON Titulo (ContaBancariaId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ITITULO6 ON Titulo (TituloClienteId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ITITULO6 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ITITULO6 ON Titulo (TituloClienteId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateAssinaturaParticipanteNotificacao( )
      {
         string cmdBuffer = "";
         /* Indices for table AssinaturaParticipanteNotificacao */
         try
         {
            cmdBuffer=" CREATE SEQUENCE AssinaturaParticipanteNotificacaoId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE AssinaturaParticipanteNotificacaoId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE AssinaturaParticipanteNotificacaoId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE AssinaturaParticipanteNotificacao (AssinaturaParticipanteNotificacaoId integer NOT NULL DEFAULT nextval('AssinaturaParticipanteNotificacaoId'), AssinaturaParticipanteId integer , AssinaturaParticipanteNotificacaoData timestamp without time zone , AssinaturaParticipanteNotificacaoStatus VARCHAR(40) , PRIMARY KEY(AssinaturaParticipanteNotificacaoId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE AssinaturaParticipanteNotificacao CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW AssinaturaParticipanteNotificacao CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION AssinaturaParticipanteNotificacao CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE AssinaturaParticipanteNotificacao (AssinaturaParticipanteNotificacaoId integer NOT NULL DEFAULT nextval('AssinaturaParticipanteNotificacaoId'), AssinaturaParticipanteId integer , AssinaturaParticipanteNotificacaoData timestamp without time zone , AssinaturaParticipanteNotificacaoStatus VARCHAR(40) , PRIMARY KEY(AssinaturaParticipanteNotificacaoId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IASSINATURAPARTICIPANTENOTIFICACAO1 ON AssinaturaParticipanteNotificacao (AssinaturaParticipanteId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IASSINATURAPARTICIPANTENOTIFICACAO1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IASSINATURAPARTICIPANTENOTIFICACAO1 ON AssinaturaParticipanteNotificacao (AssinaturaParticipanteId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateEmpresa( )
      {
         string cmdBuffer = "";
         /* Indices for table Empresa */
         try
         {
            cmdBuffer=" CREATE SEQUENCE EmpresaId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE EmpresaId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE EmpresaId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE Empresa (EmpresaId integer NOT NULL DEFAULT nextval('EmpresaId'), EmpresaNomeFantasia VARCHAR(150) , EmpresaRazaoSocial VARCHAR(150) , EmpresaCNPJ VARCHAR(14) , EmpresaSede BOOLEAN , EmpresaBancoId integer , EmpresaAgencia integer , EmpresaAgenciaDigito integer , EmpresaConta integer , EmpresaPix VARCHAR(70) , EmpresaPixTipo VARCHAR(40) , EmpresaEmail VARCHAR(100) , EmpresaRepresentanteCPF VARCHAR(14) , EmpresaRepresentanteNome VARCHAR(60) , EmpresaRepresentanteEmail VARCHAR(100) , EmpresaUtilizaRepresentanteAssinatura BOOLEAN , EmpresaLogradouro VARCHAR(100) , EmpresaLogradouroNumero bigint , EmpresaCEP VARCHAR(40) , EmpresaBairro VARCHAR(100) , EmpresaComplemento VARCHAR(100) , MunicipioCodigo VARCHAR(40) , EmpresaRepresentanteLogradouro VARCHAR(100) , EmpresaRepresentanteNumero bigint , EmpresaRepresentanteCEP VARCHAR(20) , EmpresaRepresentanteBairro VARCHAR(100) , EmpresaRepresentanteComplemento VARCHAR(100) , EmpresaRepresentanteMunicipio VARCHAR(40) , EmpresaRepresentanteNacionalidade VARCHAR(100) , EmpresaRepresentanteProfissao integer , EmpresaRepresentanteTelefone integer , EmpresaRepresentanteTelefoneDDD smallint , PRIMARY KEY(EmpresaId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Empresa CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Empresa CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Empresa CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Empresa (EmpresaId integer NOT NULL DEFAULT nextval('EmpresaId'), EmpresaNomeFantasia VARCHAR(150) , EmpresaRazaoSocial VARCHAR(150) , EmpresaCNPJ VARCHAR(14) , EmpresaSede BOOLEAN , EmpresaBancoId integer , EmpresaAgencia integer , EmpresaAgenciaDigito integer , EmpresaConta integer , EmpresaPix VARCHAR(70) , EmpresaPixTipo VARCHAR(40) , EmpresaEmail VARCHAR(100) , EmpresaRepresentanteCPF VARCHAR(14) , EmpresaRepresentanteNome VARCHAR(60) , EmpresaRepresentanteEmail VARCHAR(100) , EmpresaUtilizaRepresentanteAssinatura BOOLEAN , EmpresaLogradouro VARCHAR(100) , EmpresaLogradouroNumero bigint , EmpresaCEP VARCHAR(40) , EmpresaBairro VARCHAR(100) , EmpresaComplemento VARCHAR(100) , MunicipioCodigo VARCHAR(40) , EmpresaRepresentanteLogradouro VARCHAR(100) , EmpresaRepresentanteNumero bigint , EmpresaRepresentanteCEP VARCHAR(20) , EmpresaRepresentanteBairro VARCHAR(100) , EmpresaRepresentanteComplemento VARCHAR(100) , EmpresaRepresentanteMunicipio VARCHAR(40) , EmpresaRepresentanteNacionalidade VARCHAR(100) , EmpresaRepresentanteProfissao integer , EmpresaRepresentanteTelefone integer , EmpresaRepresentanteTelefoneDDD smallint , PRIMARY KEY(EmpresaId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IEMPRESA1 ON Empresa (EmpresaBancoId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IEMPRESA1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IEMPRESA1 ON Empresa (EmpresaBancoId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IEMPRESA2 ON Empresa (EmpresaRepresentanteProfissao ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IEMPRESA2 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IEMPRESA2 ON Empresa (EmpresaRepresentanteProfissao ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IEMPRESA3 ON Empresa (MunicipioCodigo ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IEMPRESA3 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IEMPRESA3 ON Empresa (MunicipioCodigo ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IEMPRESA4 ON Empresa (EmpresaRepresentanteMunicipio ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IEMPRESA4 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IEMPRESA4 ON Empresa (EmpresaRepresentanteMunicipio ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateAssinaturaParticipante( )
      {
         string cmdBuffer = "";
         /* Indices for table AssinaturaParticipante */
         try
         {
            cmdBuffer=" CREATE SEQUENCE AssinaturaParticipanteId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE AssinaturaParticipanteId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE AssinaturaParticipanteId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE AssinaturaParticipante (AssinaturaParticipanteId integer NOT NULL DEFAULT nextval('AssinaturaParticipanteId'), AssinaturaId bigint , ParticipanteId integer , AssinaturaParticipanteDataVisualizacao timestamp without time zone , AssinaturaParticipanteDataConclusao timestamp without time zone , AssinaturaParticipanteKey CHAR(36) , AssinaturaParticipanteTipo VARCHAR(40) , AssinaturaParticipanteStatus VARCHAR(40) , AssinaturaParticipanteRemoteAddres VARCHAR(40) , AssinaturaParticipanteGeolocalizacao VARCHAR(40) , AssinaturaParticipanteDispositivo VARCHAR(90) , AssinaturaParticipanteCPF VARCHAR(40) , AssinaturaParticipanteEmail VARCHAR(100) , AssinaturaParticipanteNascimento date , AssinaturaParticipanteLink VARCHAR(256) , ClienteId integer , PRIMARY KEY(AssinaturaParticipanteId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE AssinaturaParticipante CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW AssinaturaParticipante CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION AssinaturaParticipante CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE AssinaturaParticipante (AssinaturaParticipanteId integer NOT NULL DEFAULT nextval('AssinaturaParticipanteId'), AssinaturaId bigint , ParticipanteId integer , AssinaturaParticipanteDataVisualizacao timestamp without time zone , AssinaturaParticipanteDataConclusao timestamp without time zone , AssinaturaParticipanteKey CHAR(36) , AssinaturaParticipanteTipo VARCHAR(40) , AssinaturaParticipanteStatus VARCHAR(40) , AssinaturaParticipanteRemoteAddres VARCHAR(40) , AssinaturaParticipanteGeolocalizacao VARCHAR(40) , AssinaturaParticipanteDispositivo VARCHAR(90) , AssinaturaParticipanteCPF VARCHAR(40) , AssinaturaParticipanteEmail VARCHAR(100) , AssinaturaParticipanteNascimento date , AssinaturaParticipanteLink VARCHAR(256) , ClienteId integer , PRIMARY KEY(AssinaturaParticipanteId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IASSINATURAPARTICIPANTE1 ON AssinaturaParticipante (ParticipanteId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IASSINATURAPARTICIPANTE1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IASSINATURAPARTICIPANTE1 ON AssinaturaParticipante (ParticipanteId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IASSINATURAPARTICIPANTE2 ON AssinaturaParticipante (AssinaturaId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IASSINATURAPARTICIPANTE2 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IASSINATURAPARTICIPANTE2 ON AssinaturaParticipante (AssinaturaId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IASSINATURAPARTICIPANTE3 ON AssinaturaParticipante (ClienteId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IASSINATURAPARTICIPANTE3 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IASSINATURAPARTICIPANTE3 ON AssinaturaParticipante (ClienteId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateAssinatura( )
      {
         string cmdBuffer = "";
         /* Indices for table Assinatura */
         try
         {
            cmdBuffer=" CREATE SEQUENCE AssinaturaId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE AssinaturaId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE AssinaturaId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE Assinatura (AssinaturaId bigint NOT NULL DEFAULT nextval('AssinaturaId'), AssinaturaStatus VARCHAR(40) , ContratoId integer , AssinaturaArquivoAssinado BYTEA , AssinaturaPublicKey CHAR(36) , AssinaturaArquivoAssinadoNome VARCHAR(150) , AssinaturaArquivoAssinadoExtensao VARCHAR(40) , ArquivoId integer , AssinaturaPaginaConsulta VARCHAR(150) , AssinaturaToken VARCHAR(512) , AssinaturaMes smallint , AssinaturaMesNome VARCHAR(40) , AssinaturaAno smallint , AssinaturaFinalizadoData timestamp without time zone , ArquivoAssinadoId integer , PRIMARY KEY(AssinaturaId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Assinatura CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Assinatura CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Assinatura CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Assinatura (AssinaturaId bigint NOT NULL DEFAULT nextval('AssinaturaId'), AssinaturaStatus VARCHAR(40) , ContratoId integer , AssinaturaArquivoAssinado BYTEA , AssinaturaPublicKey CHAR(36) , AssinaturaArquivoAssinadoNome VARCHAR(150) , AssinaturaArquivoAssinadoExtensao VARCHAR(40) , ArquivoId integer , AssinaturaPaginaConsulta VARCHAR(150) , AssinaturaToken VARCHAR(512) , AssinaturaMes smallint , AssinaturaMesNome VARCHAR(40) , AssinaturaAno smallint , AssinaturaFinalizadoData timestamp without time zone , ArquivoAssinadoId integer , PRIMARY KEY(AssinaturaId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IASSINATURA1 ON Assinatura (ContratoId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IASSINATURA1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IASSINATURA1 ON Assinatura (ContratoId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IASSINATURA2 ON Assinatura (ArquivoId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IASSINATURA2 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IASSINATURA2 ON Assinatura (ArquivoId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IASSINATURA3 ON Assinatura (ArquivoAssinadoId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IASSINATURA3 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IASSINATURA3 ON Assinatura (ArquivoAssinadoId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateContratoParticipante( )
      {
         string cmdBuffer = "";
         /* Indices for table ContratoParticipante */
         try
         {
            cmdBuffer=" CREATE SEQUENCE ContratoParticipanteId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE ContratoParticipanteId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE ContratoParticipanteId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE ContratoParticipante (ContratoParticipanteId integer NOT NULL DEFAULT nextval('ContratoParticipanteId'), ContratoId integer , ParticipanteId integer , PRIMARY KEY(ContratoParticipanteId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE ContratoParticipante CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW ContratoParticipante CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION ContratoParticipante CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE ContratoParticipante (ContratoParticipanteId integer NOT NULL DEFAULT nextval('ContratoParticipanteId'), ContratoId integer , ParticipanteId integer , PRIMARY KEY(ContratoParticipanteId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ICONTRATOPARTICIPANTE1 ON ContratoParticipante (ParticipanteId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ICONTRATOPARTICIPANTE1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ICONTRATOPARTICIPANTE1 ON ContratoParticipante (ParticipanteId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ICONTRATOPARTICIPANTE2 ON ContratoParticipante (ContratoId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ICONTRATOPARTICIPANTE2 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ICONTRATOPARTICIPANTE2 ON ContratoParticipante (ContratoId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateParticipante( )
      {
         string cmdBuffer = "";
         /* Indices for table Participante */
         try
         {
            cmdBuffer=" CREATE SEQUENCE ParticipanteId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE ParticipanteId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE ParticipanteId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE Participante (ParticipanteId integer NOT NULL DEFAULT nextval('ParticipanteId'), ParticipanteDocumento VARCHAR(14) , ParticipanteEmail VARCHAR(100) , ParticipanteNome VARCHAR(150) , ParticipanteTipoPessoa VARCHAR(40) , ParticipanteRepresentanteNome VARCHAR(100) , ParticipanteRepresentanteEmail VARCHAR(100) , ParticipanteRepresentanteDocumento VARCHAR(14) , PRIMARY KEY(ParticipanteId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Participante CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Participante CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Participante CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Participante (ParticipanteId integer NOT NULL DEFAULT nextval('ParticipanteId'), ParticipanteDocumento VARCHAR(14) , ParticipanteEmail VARCHAR(100) , ParticipanteNome VARCHAR(150) , ParticipanteTipoPessoa VARCHAR(40) , ParticipanteRepresentanteNome VARCHAR(100) , ParticipanteRepresentanteEmail VARCHAR(100) , ParticipanteRepresentanteDocumento VARCHAR(14) , PRIMARY KEY(ParticipanteId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateArquivo( )
      {
         string cmdBuffer = "";
         /* Indices for table Arquivo */
         try
         {
            cmdBuffer=" CREATE SEQUENCE ArquivoId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE ArquivoId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE ArquivoId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE Arquivo (ArquivoId integer NOT NULL DEFAULT nextval('ArquivoId'), ArquivoBlob BYTEA , ArquivoNome VARCHAR(150) , ArquivoExtensao VARCHAR(40) , PRIMARY KEY(ArquivoId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Arquivo CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Arquivo CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Arquivo CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Arquivo (ArquivoId integer NOT NULL DEFAULT nextval('ArquivoId'), ArquivoBlob BYTEA , ArquivoNome VARCHAR(150) , ArquivoExtensao VARCHAR(40) , PRIMARY KEY(ArquivoId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateContrato( )
      {
         string cmdBuffer = "";
         /* Indices for table Contrato */
         try
         {
            cmdBuffer=" CREATE SEQUENCE ContratoId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE ContratoId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE ContratoId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE Contrato (ContratoId integer NOT NULL DEFAULT nextval('ContratoId'), ContratoNome VARCHAR(125) , ContratoCorpo TEXT , ContratoComVigencia BOOLEAN , ContratoDataInicial date , ContratoDataFinal date , ContratoTaxa NUMERIC(15,4) , ContratoSLA smallint , ContratoJurosMora NUMERIC(15,4) , ContratoIOFMinimo NUMERIC(15,4) , ContratoClienteId integer , ContratoSituacao VARCHAR(40) , ContratoBlob BYTEA , ContratoPropostaId integer , PRIMARY KEY(ContratoId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Contrato CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Contrato CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Contrato CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Contrato (ContratoId integer NOT NULL DEFAULT nextval('ContratoId'), ContratoNome VARCHAR(125) , ContratoCorpo TEXT , ContratoComVigencia BOOLEAN , ContratoDataInicial date , ContratoDataFinal date , ContratoTaxa NUMERIC(15,4) , ContratoSLA smallint , ContratoJurosMora NUMERIC(15,4) , ContratoIOFMinimo NUMERIC(15,4) , ContratoClienteId integer , ContratoSituacao VARCHAR(40) , ContratoBlob BYTEA , ContratoPropostaId integer , PRIMARY KEY(ContratoId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ICONTRATO1 ON Contrato (ContratoClienteId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ICONTRATO1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ICONTRATO1 ON Contrato (ContratoClienteId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ICONTRATO2 ON Contrato (ContratoPropostaId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ICONTRATO2 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ICONTRATO2 ON Contrato (ContratoPropostaId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateFinanciamento( )
      {
         string cmdBuffer = "";
         /* Indices for table Financiamento */
         try
         {
            cmdBuffer=" CREATE SEQUENCE FinanciamentoId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE FinanciamentoId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE FinanciamentoId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE Financiamento (FinanciamentoId integer NOT NULL DEFAULT nextval('FinanciamentoId'), ClienteId integer , FinanciamentoValor NUMERIC(17,2) , IntermediadorClienteId integer , FinanciamentoStatus VARCHAR(40) , PRIMARY KEY(FinanciamentoId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Financiamento CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Financiamento CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Financiamento CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Financiamento (FinanciamentoId integer NOT NULL DEFAULT nextval('FinanciamentoId'), ClienteId integer , FinanciamentoValor NUMERIC(17,2) , IntermediadorClienteId integer , FinanciamentoStatus VARCHAR(40) , PRIMARY KEY(FinanciamentoId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IFINANCIAMENTO1 ON Financiamento (ClienteId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IFINANCIAMENTO1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IFINANCIAMENTO1 ON Financiamento (ClienteId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IFINANCIAMENTO2 ON Financiamento (IntermediadorClienteId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IFINANCIAMENTO2 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IFINANCIAMENTO2 ON Financiamento (IntermediadorClienteId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTemporaryCode( )
      {
         string cmdBuffer = "";
         /* Indices for table TemporaryCode */
         try
         {
            cmdBuffer=" CREATE SEQUENCE TemporaryCodeId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE TemporaryCodeId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE TemporaryCodeId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE TemporaryCode (TemporaryCodeId integer NOT NULL DEFAULT nextval('TemporaryCodeId'), TemporaryCodeContent VARCHAR(150) , TemporaryCodeDateTime timestamp without time zone , TemporaryCodeEmail VARCHAR(100) , TemporaryCodeUsed BOOLEAN , PRIMARY KEY(TemporaryCodeId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE TemporaryCode CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW TemporaryCode CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION TemporaryCode CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE TemporaryCode (TemporaryCodeId integer NOT NULL DEFAULT nextval('TemporaryCodeId'), TemporaryCodeContent VARCHAR(150) , TemporaryCodeDateTime timestamp without time zone , TemporaryCodeEmail VARCHAR(100) , TemporaryCodeUsed BOOLEAN , PRIMARY KEY(TemporaryCodeId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTipoCliente( )
      {
         string cmdBuffer = "";
         /* Indices for table TipoCliente */
         try
         {
            cmdBuffer=" CREATE SEQUENCE TipoClienteId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE TipoClienteId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE TipoClienteId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE TipoCliente (TipoClienteId smallint NOT NULL DEFAULT nextval('TipoClienteId'), TipoClienteDescricao VARCHAR(150) , TipoClienteTipoPessoa VARCHAR(40) , TipoClienteCreatedAt timestamp without time zone , TipoClienteUpdateAt timestamp without time zone , TipoClientePortal BOOLEAN , TipoClienteFinancia BOOLEAN , TipoClientePortalPjPf BOOLEAN , PRIMARY KEY(TipoClienteId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE TipoCliente CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW TipoCliente CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION TipoCliente CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE TipoCliente (TipoClienteId smallint NOT NULL DEFAULT nextval('TipoClienteId'), TipoClienteDescricao VARCHAR(150) , TipoClienteTipoPessoa VARCHAR(40) , TipoClienteCreatedAt timestamp without time zone , TipoClienteUpdateAt timestamp without time zone , TipoClientePortal BOOLEAN , TipoClienteFinancia BOOLEAN , TipoClientePortalPjPf BOOLEAN , PRIMARY KEY(TipoClienteId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateMunicipio( )
      {
         string cmdBuffer = "";
         /* Indices for table Municipio */
         try
         {
            cmdBuffer=" CREATE TABLE Municipio (MunicipioCodigo VARCHAR(40) NOT NULL , MunicipioNome VARCHAR(150) , MunicipioDDD VARCHAR(3) , MunicipioUF VARCHAR(10) , PRIMARY KEY(MunicipioCodigo))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Municipio CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Municipio CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Municipio CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Municipio (MunicipioCodigo VARCHAR(40) NOT NULL , MunicipioNome VARCHAR(150) , MunicipioDDD VARCHAR(3) , MunicipioUF VARCHAR(10) , PRIMARY KEY(MunicipioCodigo))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateCEP( )
      {
         string cmdBuffer = "";
         /* Indices for table CEP */
         try
         {
            cmdBuffer=" CREATE TABLE CEP (CEPId integer NOT NULL , CEP VARCHAR(8) , PRIMARY KEY(CEPId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE CEP CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW CEP CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION CEP CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE CEP (CEPId integer NOT NULL , CEP VARCHAR(8) , PRIMARY KEY(CEPId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateCliente( )
      {
         string cmdBuffer = "";
         /* Indices for table Cliente */
         try
         {
            cmdBuffer=" CREATE SEQUENCE ClienteId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE ClienteId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE ClienteId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE Cliente (ClienteId integer NOT NULL DEFAULT nextval('ClienteId'), ClienteDocumento VARCHAR(20) , ClienteRazaoSocial VARCHAR(150) , ClienteNomeFantasia VARCHAR(150) , ClienteTipoPessoa VARCHAR(40) , ClienteStatus BOOLEAN , ClienteCreatedAt timestamp without time zone , ClienteUpdatedAt timestamp without time zone , ClienteLogUser smallint , TipoClienteId smallint , EnderecoTipo VARCHAR(40) , EnderecoCEP VARCHAR(8) , EnderecoLogradouro VARCHAR(150) , EnderecoBairro VARCHAR(150) , EnderecoCidade VARCHAR(150) , MunicipioCodigo VARCHAR(40) , EnderecoNumero VARCHAR(10) , EnderecoComplemento VARCHAR(150) , ContatoEmail VARCHAR(100) , ContatoDDD smallint , ContatoDDI smallint , ContatoNumero bigint , ContatoTelefoneNumero bigint , ContatoTelefoneDDD smallint , ContatoTelefoneDDI smallint , BancoId integer , ContaAgencia VARCHAR(60) , ContaNumero VARCHAR(60) , ClienteRG bigint , ResponsavelNome VARCHAR(90) , ResponsavelNacionalidade integer , ResponsavelEstadoCivil VARCHAR(40) , ResponsavelProfissao integer , ResponsavelCPF VARCHAR(14) , ResponsavelCEP VARCHAR(15) , ResponsavelLogradouro VARCHAR(100) , ResponsavelBairro VARCHAR(100) , ResponsavelCidade VARCHAR(100) , ResponsavelMunicipio VARCHAR(40) , ResponsavelLogradouroNumero integer , ResponsavelComplemento VARCHAR(100) , ResponsavelDDD smallint , ResponsavelNumero integer , ResponsavelEmail VARCHAR(100) , ClienteDataNascimento date , EspecialidadeId integer , ClienteConvenio integer , ClienteNacionalidade integer , ClienteProfissao integer , ClienteEstadoCivil VARCHAR(40) , ClienteDepositoTipo VARCHAR(40) , ClientePixTipo VARCHAR(40) , ClientePix VARCHAR(80) , ResponsavelRG bigint , ClienteSituacao CHAR(1) , ResponsavelCargo VARCHAR(40) , PRIMARY KEY(ClienteId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Cliente CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Cliente CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Cliente CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Cliente (ClienteId integer NOT NULL DEFAULT nextval('ClienteId'), ClienteDocumento VARCHAR(20) , ClienteRazaoSocial VARCHAR(150) , ClienteNomeFantasia VARCHAR(150) , ClienteTipoPessoa VARCHAR(40) , ClienteStatus BOOLEAN , ClienteCreatedAt timestamp without time zone , ClienteUpdatedAt timestamp without time zone , ClienteLogUser smallint , TipoClienteId smallint , EnderecoTipo VARCHAR(40) , EnderecoCEP VARCHAR(8) , EnderecoLogradouro VARCHAR(150) , EnderecoBairro VARCHAR(150) , EnderecoCidade VARCHAR(150) , MunicipioCodigo VARCHAR(40) , EnderecoNumero VARCHAR(10) , EnderecoComplemento VARCHAR(150) , ContatoEmail VARCHAR(100) , ContatoDDD smallint , ContatoDDI smallint , ContatoNumero bigint , ContatoTelefoneNumero bigint , ContatoTelefoneDDD smallint , ContatoTelefoneDDI smallint , BancoId integer , ContaAgencia VARCHAR(60) , ContaNumero VARCHAR(60) , ClienteRG bigint , ResponsavelNome VARCHAR(90) , ResponsavelNacionalidade integer , ResponsavelEstadoCivil VARCHAR(40) , ResponsavelProfissao integer , ResponsavelCPF VARCHAR(14) , ResponsavelCEP VARCHAR(15) , ResponsavelLogradouro VARCHAR(100) , ResponsavelBairro VARCHAR(100) , ResponsavelCidade VARCHAR(100) , ResponsavelMunicipio VARCHAR(40) , ResponsavelLogradouroNumero integer , ResponsavelComplemento VARCHAR(100) , ResponsavelDDD smallint , ResponsavelNumero integer , ResponsavelEmail VARCHAR(100) , ClienteDataNascimento date , EspecialidadeId integer , ClienteConvenio integer , ClienteNacionalidade integer , ClienteProfissao integer , ClienteEstadoCivil VARCHAR(40) , ClienteDepositoTipo VARCHAR(40) , ClientePixTipo VARCHAR(40) , ClientePix VARCHAR(80) , ResponsavelRG bigint , ClienteSituacao CHAR(1) , ResponsavelCargo VARCHAR(40) , PRIMARY KEY(ClienteId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE UNIQUE INDEX CLIENTEUNIQUEDOCUMENT ON Cliente (ClienteDocumento ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX CLIENTEUNIQUEDOCUMENT "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE UNIQUE INDEX CLIENTEUNIQUEDOCUMENT ON Cliente (ClienteDocumento ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ICLIENTE2 ON Cliente (TipoClienteId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ICLIENTE2 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ICLIENTE2 ON Cliente (TipoClienteId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ICLIENTE3 ON Cliente (MunicipioCodigo ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ICLIENTE3 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ICLIENTE3 ON Cliente (MunicipioCodigo ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ICLIENTE4 ON Cliente (BancoId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ICLIENTE4 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ICLIENTE4 ON Cliente (BancoId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ICLIENTE5 ON Cliente (ResponsavelNacionalidade ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ICLIENTE5 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ICLIENTE5 ON Cliente (ResponsavelNacionalidade ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ICLIENTE6 ON Cliente (ResponsavelProfissao ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ICLIENTE6 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ICLIENTE6 ON Cliente (ResponsavelProfissao ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ICLIENTE7 ON Cliente (ResponsavelMunicipio ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ICLIENTE7 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ICLIENTE7 ON Cliente (ResponsavelMunicipio ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ICLIENTE8 ON Cliente (EspecialidadeId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ICLIENTE8 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ICLIENTE8 ON Cliente (EspecialidadeId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ICLIENTE9 ON Cliente (ClienteNacionalidade ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ICLIENTE9 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ICLIENTE9 ON Cliente (ClienteNacionalidade ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ICLIENTE10 ON Cliente (ClienteProfissao ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ICLIENTE10 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ICLIENTE10 ON Cliente (ClienteProfissao ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ICLIENTE11 ON Cliente (ClienteConvenio ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ICLIENTE11 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ICLIENTE11 ON Cliente (ClienteConvenio ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateSecUserToken( )
      {
         string cmdBuffer = "";
         /* Indices for table SecUserToken */
         try
         {
            cmdBuffer=" CREATE SEQUENCE SecUserTokenID MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE SecUserTokenID CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE SecUserTokenID MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE SecUserToken (SecUserTokenID smallint NOT NULL DEFAULT nextval('SecUserTokenID'), SecUserTokenKey TEXT , SecUserTokenDateTime timestamp without time zone , SecUserId smallint , SecUserTokenUsed BOOLEAN , PRIMARY KEY(SecUserTokenID))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE SecUserToken CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW SecUserToken CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION SecUserToken CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE SecUserToken (SecUserTokenID smallint NOT NULL DEFAULT nextval('SecUserTokenID'), SecUserTokenKey TEXT , SecUserTokenDateTime timestamp without time zone , SecUserId smallint , SecUserTokenUsed BOOLEAN , PRIMARY KEY(SecUserTokenID))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ISECUSERUID1 ON SecUserToken (SecUserId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ISECUSERUID1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ISECUSERUID1 ON SecUserToken (SecUserId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateServidorSMTP( )
      {
         string cmdBuffer = "";
         /* Indices for table ServidorSMTP */
         try
         {
            cmdBuffer=" CREATE SEQUENCE ServidorSMTPId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE ServidorSMTPId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE ServidorSMTPId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE ServidorSMTP (ServidorSMTPId smallint NOT NULL DEFAULT nextval('ServidorSMTPId'), ServidorSMTPServer VARCHAR(40) , ServidorSMTPPorta VARCHAR(40) , ServidorSMTPEmail VARCHAR(100) , ServidorSMTPPass VARCHAR(90) , ServidorSMTPUsuario VARCHAR(90) , PRIMARY KEY(ServidorSMTPId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE ServidorSMTP CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW ServidorSMTP CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION ServidorSMTP CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE ServidorSMTP (ServidorSMTPId smallint NOT NULL DEFAULT nextval('ServidorSMTPId'), ServidorSMTPServer VARCHAR(40) , ServidorSMTPPorta VARCHAR(40) , ServidorSMTPEmail VARCHAR(100) , ServidorSMTPPass VARCHAR(90) , ServidorSMTPUsuario VARCHAR(90) , PRIMARY KEY(ServidorSMTPId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateLayoutContrato( )
      {
         string cmdBuffer = "";
         /* Indices for table LayoutContrato */
         try
         {
            cmdBuffer=" CREATE SEQUENCE LayoutContratoId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE LayoutContratoId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE LayoutContratoId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE LayoutContrato (LayoutContratoId smallint NOT NULL DEFAULT nextval('LayoutContratoId'), LayoutContratoDescricao VARCHAR(60) , LayoutContratoStatus BOOLEAN , LayoutContratoCorpo TEXT , LayoutContratoTipo VARCHAR(1) , LayoutContratoTag VARCHAR(40) , PRIMARY KEY(LayoutContratoId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE LayoutContrato CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW LayoutContrato CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION LayoutContrato CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE LayoutContrato (LayoutContratoId smallint NOT NULL DEFAULT nextval('LayoutContratoId'), LayoutContratoDescricao VARCHAR(60) , LayoutContratoStatus BOOLEAN , LayoutContratoCorpo TEXT , LayoutContratoTipo VARCHAR(1) , LayoutContratoTag VARCHAR(40) , PRIMARY KEY(LayoutContratoId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreatePerson( )
      {
         string cmdBuffer = "";
         /* Indices for table Person */
         try
         {
            cmdBuffer=" CREATE SEQUENCE PersonID MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE PersonID CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE PersonID MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE Person (PersonID integer NOT NULL DEFAULT nextval('PersonID'), PRIMARY KEY(PersonID))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Person CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Person CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Person CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Person (PersonID integer NOT NULL DEFAULT nextval('PersonID'), PRIMARY KEY(PersonID))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateSecUserRole( )
      {
         string cmdBuffer = "";
         /* Indices for table SecUserRole */
         try
         {
            cmdBuffer=" CREATE TABLE SecUserRole (SecUserId smallint NOT NULL , SecRoleId smallint NOT NULL , SecUserRoleActive BOOLEAN NOT NULL , PRIMARY KEY(SecUserId, SecRoleId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE SecUserRole CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW SecUserRole CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION SecUserRole CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE SecUserRole (SecUserId smallint NOT NULL , SecRoleId smallint NOT NULL , SecUserRoleActive BOOLEAN NOT NULL , PRIMARY KEY(SecUserId, SecRoleId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ISECUSERROLE1 ON SecUserRole (SecRoleId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ISECUSERROLE1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ISECUSERROLE1 ON SecUserRole (SecRoleId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateSecUser( )
      {
         string cmdBuffer = "";
         /* Indices for table SecUser */
         try
         {
            cmdBuffer=" CREATE SEQUENCE SecUserId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE SecUserId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE SecUserId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE SecUser (SecUserId smallint NOT NULL DEFAULT nextval('SecUserId'), SecUserName VARCHAR(100) , SecUserPassword VARCHAR(100) , SecUserFullName VARCHAR(150) , SecUserEmail VARCHAR(100) , SecUserCreatedAt timestamp without time zone , SecUserUpdateAt timestamp without time zone , SecUserUserMan smallint , SecUserStatus BOOLEAN , SecUserTeste TEXT , SecUserTemp BOOLEAN , SecUserClienteAcesso BOOLEAN , SecUserClienteId smallint , SecUserOwnerId integer , SecUserAnalista BOOLEAN , PRIMARY KEY(SecUserId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE SecUser CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW SecUser CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION SecUser CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE SecUser (SecUserId smallint NOT NULL DEFAULT nextval('SecUserId'), SecUserName VARCHAR(100) , SecUserPassword VARCHAR(100) , SecUserFullName VARCHAR(150) , SecUserEmail VARCHAR(100) , SecUserCreatedAt timestamp without time zone , SecUserUpdateAt timestamp without time zone , SecUserUserMan smallint , SecUserStatus BOOLEAN , SecUserTeste TEXT , SecUserTemp BOOLEAN , SecUserClienteAcesso BOOLEAN , SecUserClienteId smallint , SecUserOwnerId integer , SecUserAnalista BOOLEAN , PRIMARY KEY(SecUserId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ISECUSER1 ON SecUser (SecUserUserMan ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ISECUSER1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ISECUSER1 ON SecUser (SecUserUserMan ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ISECUSER2 ON SecUser (SecUserClienteId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ISECUSER2 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ISECUSER2 ON SecUser (SecUserClienteId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ISECUSER3 ON SecUser (SecUserOwnerId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ISECUSER3 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ISECUSER3 ON SecUser (SecUserOwnerId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateSecRole( )
      {
         string cmdBuffer = "";
         /* Indices for table SecRole */
         try
         {
            cmdBuffer=" CREATE SEQUENCE SecRoleId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE SecRoleId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE SecRoleId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE SecRole (SecRoleId smallint NOT NULL DEFAULT nextval('SecRoleId'), SecRoleName VARCHAR(40) NOT NULL , SecRoleDescription VARCHAR(120) NOT NULL , SecRoleActive BOOLEAN , PRIMARY KEY(SecRoleId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE SecRole CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW SecRole CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION SecRole CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE SecRole (SecRoleId smallint NOT NULL DEFAULT nextval('SecRoleId'), SecRoleName VARCHAR(40) NOT NULL , SecRoleDescription VARCHAR(120) NOT NULL , SecRoleActive BOOLEAN , PRIMARY KEY(SecRoleId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateSecObjectFunctionalities( )
      {
         string cmdBuffer = "";
         /* Indices for table SecObjectFunctionalities */
         try
         {
            cmdBuffer=" CREATE TABLE SecObjectFunctionalities (SecObjectName VARCHAR(120) NOT NULL , SecFunctionalityId bigint NOT NULL , PRIMARY KEY(SecObjectName, SecFunctionalityId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE SecObjectFunctionalities CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW SecObjectFunctionalities CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION SecObjectFunctionalities CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE SecObjectFunctionalities (SecObjectName VARCHAR(120) NOT NULL , SecFunctionalityId bigint NOT NULL , PRIMARY KEY(SecObjectName, SecFunctionalityId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ISECOBJECTFUNCTIONALITIES1 ON SecObjectFunctionalities (SecFunctionalityId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ISECOBJECTFUNCTIONALITIES1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ISECOBJECTFUNCTIONALITIES1 ON SecObjectFunctionalities (SecFunctionalityId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateSecObject( )
      {
         string cmdBuffer = "";
         /* Indices for table SecObject */
         try
         {
            cmdBuffer=" CREATE TABLE SecObject (SecObjectName VARCHAR(120) NOT NULL , PRIMARY KEY(SecObjectName))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE SecObject CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW SecObject CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION SecObject CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE SecObject (SecObjectName VARCHAR(120) NOT NULL , PRIMARY KEY(SecObjectName))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateSecFunctionalityRole( )
      {
         string cmdBuffer = "";
         /* Indices for table SecFunctionalityRole */
         try
         {
            cmdBuffer=" CREATE TABLE SecFunctionalityRole (SecFunctionalityId bigint NOT NULL , SecRoleId smallint NOT NULL , SecFunctionalityRoleAtivo BOOLEAN NOT NULL , PRIMARY KEY(SecFunctionalityId, SecRoleId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE SecFunctionalityRole CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW SecFunctionalityRole CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION SecFunctionalityRole CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE SecFunctionalityRole (SecFunctionalityId bigint NOT NULL , SecRoleId smallint NOT NULL , SecFunctionalityRoleAtivo BOOLEAN NOT NULL , PRIMARY KEY(SecFunctionalityId, SecRoleId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ISECFUNCTIONALITYROL2 ON SecFunctionalityRole (SecRoleId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ISECFUNCTIONALITYROL2 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ISECFUNCTIONALITYROL2 ON SecFunctionalityRole (SecRoleId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateSecFunctionality( )
      {
         string cmdBuffer = "";
         /* Indices for table SecFunctionality */
         try
         {
            cmdBuffer=" CREATE SEQUENCE SecFunctionalityId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE SecFunctionalityId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE SecFunctionalityId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE SecFunctionality (SecFunctionalityId bigint NOT NULL DEFAULT nextval('SecFunctionalityId'), SecFunctionalityKey VARCHAR(100) , SecFunctionalityDescription VARCHAR(100) , SecFunctionalityType smallint , SecParentFunctionalityId bigint , SecFunctionalityActive BOOLEAN , SecFunctionalityModule VARCHAR(100) , PRIMARY KEY(SecFunctionalityId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE SecFunctionality CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW SecFunctionality CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION SecFunctionality CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE SecFunctionality (SecFunctionalityId bigint NOT NULL DEFAULT nextval('SecFunctionalityId'), SecFunctionalityKey VARCHAR(100) , SecFunctionalityDescription VARCHAR(100) , SecFunctionalityType smallint , SecParentFunctionalityId bigint , SecFunctionalityActive BOOLEAN , SecFunctionalityModule VARCHAR(100) , PRIMARY KEY(SecFunctionalityId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE UNIQUE INDEX USECFUNCTIONALITY ON SecFunctionality (SecFunctionalityKey ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX USECFUNCTIONALITY "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE UNIQUE INDEX USECFUNCTIONALITY ON SecFunctionality (SecFunctionalityKey ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ISECFUNCTIONALITY1 ON SecFunctionality (SecParentFunctionalityId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ISECFUNCTIONALITY1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ISECFUNCTIONALITY1 ON SecFunctionality (SecParentFunctionalityId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateWWP_FormInstanceElement( )
      {
         string cmdBuffer = "";
         /* Indices for table WWP_FormInstanceElement */
         try
         {
            cmdBuffer=" CREATE TABLE WWP_FormInstanceElement (WWPFormInstanceId integer NOT NULL , WWPFormElementId smallint NOT NULL , WWPFormInstanceElementId smallint NOT NULL , WWPFormInstanceElemChar TEXT , WWPFormInstanceElemDate date , WWPFormInstanceElemDateTime timestamp without time zone , WWPFormInstanceElemNumeric NUMERIC(17,5) , WWPFormInstanceElemBlob BYTEA , WWPFormInstanceElemBlobFileName VARCHAR(40) NOT NULL , WWPFormInstanceElemBlobFileType VARCHAR(40) NOT NULL , WWPFormInstanceElemBoolean BOOLEAN , PRIMARY KEY(WWPFormInstanceId, WWPFormElementId, WWPFormInstanceElementId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE WWP_FormInstanceElement CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW WWP_FormInstanceElement CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION WWP_FormInstanceElement CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE WWP_FormInstanceElement (WWPFormInstanceId integer NOT NULL , WWPFormElementId smallint NOT NULL , WWPFormInstanceElementId smallint NOT NULL , WWPFormInstanceElemChar TEXT , WWPFormInstanceElemDate date , WWPFormInstanceElemDateTime timestamp without time zone , WWPFormInstanceElemNumeric NUMERIC(17,5) , WWPFormInstanceElemBlob BYTEA , WWPFormInstanceElemBlobFileName VARCHAR(40) NOT NULL , WWPFormInstanceElemBlobFileType VARCHAR(40) NOT NULL , WWPFormInstanceElemBoolean BOOLEAN , PRIMARY KEY(WWPFormInstanceId, WWPFormElementId, WWPFormInstanceElementId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateWWP_FormInstance( )
      {
         string cmdBuffer = "";
         /* Indices for table WWP_FormInstance */
         try
         {
            cmdBuffer=" CREATE SEQUENCE WWPFormInstanceId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE WWPFormInstanceId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE WWPFormInstanceId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE WWP_FormInstance (WWPFormInstanceId integer NOT NULL DEFAULT nextval('WWPFormInstanceId'), WWPFormInstanceDate date NOT NULL , WWPFormId smallint NOT NULL , WWPFormVersionNumber smallint NOT NULL , WWPFormInstanceRecordKey TEXT , PRIMARY KEY(WWPFormInstanceId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE WWP_FormInstance CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW WWP_FormInstance CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION WWP_FormInstance CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE WWP_FormInstance (WWPFormInstanceId integer NOT NULL DEFAULT nextval('WWPFormInstanceId'), WWPFormInstanceDate date NOT NULL , WWPFormId smallint NOT NULL , WWPFormVersionNumber smallint NOT NULL , WWPFormInstanceRecordKey TEXT , PRIMARY KEY(WWPFormInstanceId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IWWPFORMINSTANCE1 ON WWP_FormInstance (WWPFormId ,WWPFormVersionNumber ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IWWPFORMINSTANCE1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IWWPFORMINSTANCE1 ON WWP_FormInstance (WWPFormId ,WWPFormVersionNumber ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateWWP_FormElement( )
      {
         string cmdBuffer = "";
         /* Indices for table WWP_FormElement */
         try
         {
            cmdBuffer=" CREATE TABLE WWP_FormElement (WWPFormId smallint NOT NULL , WWPFormVersionNumber smallint NOT NULL , WWPFormElementId smallint NOT NULL , WWPFormElementTitle TEXT NOT NULL , WWPFormElementType smallint NOT NULL , WWPFormElementOrderIndex smallint NOT NULL , WWPFormElementDataType smallint NOT NULL , WWPFormElementParentId smallint , WWPFormElementMetadata TEXT NOT NULL , WWPFormElementCaption smallint NOT NULL , WWPFormElementReferenceId VARCHAR(100) NOT NULL , WWPFormElementExcludeFromExport BOOLEAN NOT NULL , PRIMARY KEY(WWPFormId, WWPFormVersionNumber, WWPFormElementId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE WWP_FormElement CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW WWP_FormElement CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION WWP_FormElement CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE WWP_FormElement (WWPFormId smallint NOT NULL , WWPFormVersionNumber smallint NOT NULL , WWPFormElementId smallint NOT NULL , WWPFormElementTitle TEXT NOT NULL , WWPFormElementType smallint NOT NULL , WWPFormElementOrderIndex smallint NOT NULL , WWPFormElementDataType smallint NOT NULL , WWPFormElementParentId smallint , WWPFormElementMetadata TEXT NOT NULL , WWPFormElementCaption smallint NOT NULL , WWPFormElementReferenceId VARCHAR(100) NOT NULL , WWPFormElementExcludeFromExport BOOLEAN NOT NULL , PRIMARY KEY(WWPFormId, WWPFormVersionNumber, WWPFormElementId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IWWPFORMELEMENT1 ON WWP_FormElement (WWPFormId ,WWPFormVersionNumber ,WWPFormElementParentId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IWWPFORMELEMENT1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IWWPFORMELEMENT1 ON WWP_FormElement (WWPFormId ,WWPFormVersionNumber ,WWPFormElementParentId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX UWWPFORMELEMENTORDER ON WWP_FormElement (WWPFormElementOrderIndex DESC) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX UWWPFORMELEMENTORDER "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX UWWPFORMELEMENTORDER ON WWP_FormElement (WWPFormElementOrderIndex DESC) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX UWWPFORMELEMENTREFERENCEID ON WWP_FormElement (WWPFormElementReferenceId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX UWWPFORMELEMENTREFERENCEID "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX UWWPFORMELEMENTREFERENCEID ON WWP_FormElement (WWPFormElementReferenceId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateWWP_Form( )
      {
         string cmdBuffer = "";
         /* Indices for table WWP_Form */
         try
         {
            cmdBuffer=" CREATE TABLE WWP_Form (WWPFormId smallint NOT NULL , WWPFormVersionNumber smallint NOT NULL , WWPFormReferenceName VARCHAR(100) NOT NULL , WWPFormTitle VARCHAR(100) NOT NULL , WWPFormDate timestamp without time zone NOT NULL , WWPFormIsWizard BOOLEAN NOT NULL , WWPFormResume smallint NOT NULL , WWPFormResumeMessage TEXT NOT NULL , WWPFormValidations TEXT NOT NULL , WWPFormInstantiated BOOLEAN NOT NULL , WWPFormType smallint NOT NULL , WWPFormSectionRefElements VARCHAR(400) NOT NULL , WWPFormIsForDynamicValidations BOOLEAN NOT NULL , PRIMARY KEY(WWPFormId, WWPFormVersionNumber))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE WWP_Form CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW WWP_Form CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION WWP_Form CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE WWP_Form (WWPFormId smallint NOT NULL , WWPFormVersionNumber smallint NOT NULL , WWPFormReferenceName VARCHAR(100) NOT NULL , WWPFormTitle VARCHAR(100) NOT NULL , WWPFormDate timestamp without time zone NOT NULL , WWPFormIsWizard BOOLEAN NOT NULL , WWPFormResume smallint NOT NULL , WWPFormResumeMessage TEXT NOT NULL , WWPFormValidations TEXT NOT NULL , WWPFormInstantiated BOOLEAN NOT NULL , WWPFormType smallint NOT NULL , WWPFormSectionRefElements VARCHAR(400) NOT NULL , WWPFormIsForDynamicValidations BOOLEAN NOT NULL , PRIMARY KEY(WWPFormId, WWPFormVersionNumber))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX UWWP_FORMVERSIONNUMBER ON WWP_Form (WWPFormVersionNumber DESC) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX UWWP_FORMVERSIONNUMBER "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX UWWP_FORMVERSIONNUMBER ON WWP_Form (WWPFormVersionNumber DESC) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX UWWP_FORMTITLE ON WWP_Form (WWPFormTitle ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX UWWP_FORMTITLE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX UWWP_FORMTITLE ON WWP_Form (WWPFormTitle ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX UWWP_FORMREFERENCEVERSION ON WWP_Form (WWPFormReferenceName ,WWPFormVersionNumber DESC) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX UWWP_FORMREFERENCEVERSION "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX UWWP_FORMREFERENCEVERSION ON WWP_Form (WWPFormReferenceName ,WWPFormVersionNumber DESC) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX UWWP_FORMIDVERSION ON WWP_Form (WWPFormId ,WWPFormVersionNumber DESC) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX UWWP_FORMIDVERSION "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX UWWP_FORMIDVERSION ON WWP_Form (WWPFormId ,WWPFormVersionNumber DESC) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateWWP_MailAttachments( )
      {
         string cmdBuffer = "";
         /* Indices for table WWP_MailAttachments */
         try
         {
            cmdBuffer=" CREATE TABLE WWP_MailAttachments (WWPMailId bigint NOT NULL , WWPMailAttachmentName VARCHAR(40) NOT NULL , WWPMailAttachmentFile TEXT NOT NULL , PRIMARY KEY(WWPMailId, WWPMailAttachmentName))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE WWP_MailAttachments CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW WWP_MailAttachments CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION WWP_MailAttachments CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE WWP_MailAttachments (WWPMailId bigint NOT NULL , WWPMailAttachmentName VARCHAR(40) NOT NULL , WWPMailAttachmentFile TEXT NOT NULL , PRIMARY KEY(WWPMailId, WWPMailAttachmentName))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateWWP_Mail( )
      {
         string cmdBuffer = "";
         /* Indices for table WWP_Mail */
         try
         {
            cmdBuffer=" CREATE SEQUENCE WWPMailId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE WWPMailId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE WWPMailId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE WWP_Mail (WWPMailId bigint NOT NULL DEFAULT nextval('WWPMailId'), WWPMailSubject VARCHAR(80) NOT NULL , WWPMailBody TEXT NOT NULL , WWPMailTo TEXT , WWPMailCC TEXT , WWPMailBCC TEXT , WWPMailSenderAddress TEXT NOT NULL , WWPMailSenderName TEXT NOT NULL , WWPMailStatus smallint NOT NULL , WWPMailCreated timestamp without time zone NOT NULL , WWPMailScheduled timestamp without time zone NOT NULL , WWPMailProcessed timestamp without time zone , WWPMailDetail TEXT , WWPNotificationId bigint , PRIMARY KEY(WWPMailId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE WWP_Mail CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW WWP_Mail CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION WWP_Mail CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE WWP_Mail (WWPMailId bigint NOT NULL DEFAULT nextval('WWPMailId'), WWPMailSubject VARCHAR(80) NOT NULL , WWPMailBody TEXT NOT NULL , WWPMailTo TEXT , WWPMailCC TEXT , WWPMailBCC TEXT , WWPMailSenderAddress TEXT NOT NULL , WWPMailSenderName TEXT NOT NULL , WWPMailStatus smallint NOT NULL , WWPMailCreated timestamp without time zone NOT NULL , WWPMailScheduled timestamp without time zone NOT NULL , WWPMailProcessed timestamp without time zone , WWPMailDetail TEXT , WWPNotificationId bigint , PRIMARY KEY(WWPMailId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IWWP_MAIL1 ON WWP_Mail (WWPNotificationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IWWP_MAIL1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IWWP_MAIL1 ON WWP_Mail (WWPNotificationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateWWP_MailTemplate( )
      {
         string cmdBuffer = "";
         /* Indices for table WWP_MailTemplate */
         try
         {
            cmdBuffer=" CREATE TABLE WWP_MailTemplate (WWPMailTemplateName VARCHAR(40) NOT NULL , WWPMailTemplateDescription VARCHAR(100) NOT NULL , WWPMailTemplateSubject VARCHAR(80) NOT NULL , WWPMailTemplateBody TEXT NOT NULL , WWPMailTemplateSenderAddress TEXT NOT NULL , WWPMailTemplateSenderName TEXT NOT NULL , PRIMARY KEY(WWPMailTemplateName))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE WWP_MailTemplate CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW WWP_MailTemplate CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION WWP_MailTemplate CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE WWP_MailTemplate (WWPMailTemplateName VARCHAR(40) NOT NULL , WWPMailTemplateDescription VARCHAR(100) NOT NULL , WWPMailTemplateSubject VARCHAR(80) NOT NULL , WWPMailTemplateBody TEXT NOT NULL , WWPMailTemplateSenderAddress TEXT NOT NULL , WWPMailTemplateSenderName TEXT NOT NULL , PRIMARY KEY(WWPMailTemplateName))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateWWP_Notification( )
      {
         string cmdBuffer = "";
         /* Indices for table WWP_Notification */
         try
         {
            cmdBuffer=" CREATE SEQUENCE WWPNotificationId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE WWPNotificationId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE WWPNotificationId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE WWP_Notification (WWPNotificationId bigint NOT NULL DEFAULT nextval('WWPNotificationId'), WWPNotificationDefinitionId bigint NOT NULL , WWPNotificationCreated timestamp without time zone NOT NULL , WWPNotificationIcon VARCHAR(100) NOT NULL , WWPNotificationTitle VARCHAR(200) NOT NULL , WWPNotificationShortDescription VARCHAR(200) NOT NULL , WWPNotificationLink VARCHAR(1000) NOT NULL , WWPNotificationIsRead BOOLEAN NOT NULL , WWPNotificationMetadata TEXT , WWPUserExtendedId CHAR(40) , PRIMARY KEY(WWPNotificationId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE WWP_Notification CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW WWP_Notification CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION WWP_Notification CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE WWP_Notification (WWPNotificationId bigint NOT NULL DEFAULT nextval('WWPNotificationId'), WWPNotificationDefinitionId bigint NOT NULL , WWPNotificationCreated timestamp without time zone NOT NULL , WWPNotificationIcon VARCHAR(100) NOT NULL , WWPNotificationTitle VARCHAR(200) NOT NULL , WWPNotificationShortDescription VARCHAR(200) NOT NULL , WWPNotificationLink VARCHAR(1000) NOT NULL , WWPNotificationIsRead BOOLEAN NOT NULL , WWPNotificationMetadata TEXT , WWPUserExtendedId CHAR(40) , PRIMARY KEY(WWPNotificationId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IWWP_NOTIFICATION2 ON WWP_Notification (WWPNotificationDefinitionId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IWWP_NOTIFICATION2 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IWWP_NOTIFICATION2 ON WWP_Notification (WWPNotificationDefinitionId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX WWP_NOTIFICATIONCREATEDDATE ON WWP_Notification (WWPNotificationCreated DESC) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX WWP_NOTIFICATIONCREATEDDATE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX WWP_NOTIFICATIONCREATEDDATE ON WWP_Notification (WWPNotificationCreated DESC) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IWWP_NOTIFICATION1 ON WWP_Notification (WWPUserExtendedId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IWWP_NOTIFICATION1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IWWP_NOTIFICATION1 ON WWP_Notification (WWPUserExtendedId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateWWP_NotificationDefinition( )
      {
         string cmdBuffer = "";
         /* Indices for table WWP_NotificationDefinition */
         try
         {
            cmdBuffer=" CREATE SEQUENCE WWPNotificationDefinitionId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE WWPNotificationDefinitionId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE WWPNotificationDefinitionId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE WWP_NotificationDefinition (WWPNotificationDefinitionId bigint NOT NULL DEFAULT nextval('WWPNotificationDefinitionId'), WWPNotificationDefinitionName VARCHAR(100) NOT NULL , WWPNotificationDefinitionAppliesTo smallint NOT NULL , WWPNotificationDefinitionAllowUserSubscription BOOLEAN NOT NULL , WWPNotificationDefinitionDescription VARCHAR(200) NOT NULL , WWPNotificationDefinitionIcon VARCHAR(40) NOT NULL , WWPNotificationDefinitionTitle VARCHAR(200) NOT NULL , WWPNotificationDefinitionShortDescription VARCHAR(200) NOT NULL , WWPNotificationDefinitionLongDescription VARCHAR(1000) NOT NULL , WWPNotificationDefinitionLink VARCHAR(1000) NOT NULL , WWPEntityId bigint NOT NULL , WWPNotificationDefinitionSecFuncionality VARCHAR(200) NOT NULL , PRIMARY KEY(WWPNotificationDefinitionId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE WWP_NotificationDefinition CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW WWP_NotificationDefinition CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION WWP_NotificationDefinition CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE WWP_NotificationDefinition (WWPNotificationDefinitionId bigint NOT NULL DEFAULT nextval('WWPNotificationDefinitionId'), WWPNotificationDefinitionName VARCHAR(100) NOT NULL , WWPNotificationDefinitionAppliesTo smallint NOT NULL , WWPNotificationDefinitionAllowUserSubscription BOOLEAN NOT NULL , WWPNotificationDefinitionDescription VARCHAR(200) NOT NULL , WWPNotificationDefinitionIcon VARCHAR(40) NOT NULL , WWPNotificationDefinitionTitle VARCHAR(200) NOT NULL , WWPNotificationDefinitionShortDescription VARCHAR(200) NOT NULL , WWPNotificationDefinitionLongDescription VARCHAR(1000) NOT NULL , WWPNotificationDefinitionLink VARCHAR(1000) NOT NULL , WWPEntityId bigint NOT NULL , WWPNotificationDefinitionSecFuncionality VARCHAR(200) NOT NULL , PRIMARY KEY(WWPNotificationDefinitionId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IWWP_NOTIFICATIONDEFINITION1 ON WWP_NotificationDefinition (WWPEntityId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IWWP_NOTIFICATIONDEFINITION1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IWWP_NOTIFICATIONDEFINITION1 ON WWP_NotificationDefinition (WWPEntityId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateWWP_WebClient( )
      {
         string cmdBuffer = "";
         /* Indices for table WWP_WebClient */
         try
         {
            cmdBuffer=" CREATE TABLE WWP_WebClient (WWPWebClientId CHAR(100) NOT NULL , WWPWebClientBrowserId smallint NOT NULL , WWPWebClientBrowserVersion TEXT NOT NULL , WWPWebClientFirstRegistered timestamp without time zone NOT NULL , WWPWebClientLastRegistered timestamp without time zone NOT NULL , WWPUserExtendedId CHAR(40) , PRIMARY KEY(WWPWebClientId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE WWP_WebClient CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW WWP_WebClient CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION WWP_WebClient CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE WWP_WebClient (WWPWebClientId CHAR(100) NOT NULL , WWPWebClientBrowserId smallint NOT NULL , WWPWebClientBrowserVersion TEXT NOT NULL , WWPWebClientFirstRegistered timestamp without time zone NOT NULL , WWPWebClientLastRegistered timestamp without time zone NOT NULL , WWPUserExtendedId CHAR(40) , PRIMARY KEY(WWPWebClientId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IWWP_WEBCLIENT1 ON WWP_WebClient (WWPUserExtendedId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IWWP_WEBCLIENT1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IWWP_WEBCLIENT1 ON WWP_WebClient (WWPUserExtendedId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateWWP_WebNotification( )
      {
         string cmdBuffer = "";
         /* Indices for table WWP_WebNotification */
         try
         {
            cmdBuffer=" CREATE SEQUENCE WWPWebNotificationId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE WWPWebNotificationId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE WWPWebNotificationId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE WWP_WebNotification (WWPWebNotificationId bigint NOT NULL DEFAULT nextval('WWPWebNotificationId'), WWPWebNotificationTitle VARCHAR(40) NOT NULL , WWPNotificationId bigint , WWPWebNotificationText VARCHAR(120) NOT NULL , WWPWebNotificationIcon VARCHAR(255) NOT NULL , WWPWebNotificationClientId TEXT NOT NULL , WWPWebNotificationStatus smallint NOT NULL , WWPWebNotificationCreated timestamp without time zone NOT NULL , WWPWebNotificationScheduled timestamp without time zone NOT NULL , WWPWebNotificationProcessed timestamp without time zone NOT NULL , WWPWebNotificationRead timestamp without time zone , WWPWebNotificationDetail TEXT , WWPWebNotificationReceived BOOLEAN , PRIMARY KEY(WWPWebNotificationId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE WWP_WebNotification CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW WWP_WebNotification CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION WWP_WebNotification CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE WWP_WebNotification (WWPWebNotificationId bigint NOT NULL DEFAULT nextval('WWPWebNotificationId'), WWPWebNotificationTitle VARCHAR(40) NOT NULL , WWPNotificationId bigint , WWPWebNotificationText VARCHAR(120) NOT NULL , WWPWebNotificationIcon VARCHAR(255) NOT NULL , WWPWebNotificationClientId TEXT NOT NULL , WWPWebNotificationStatus smallint NOT NULL , WWPWebNotificationCreated timestamp without time zone NOT NULL , WWPWebNotificationScheduled timestamp without time zone NOT NULL , WWPWebNotificationProcessed timestamp without time zone NOT NULL , WWPWebNotificationRead timestamp without time zone , WWPWebNotificationDetail TEXT , WWPWebNotificationReceived BOOLEAN , PRIMARY KEY(WWPWebNotificationId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IWWP_WEBNOTIFICATION1 ON WWP_WebNotification (WWPNotificationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IWWP_WEBNOTIFICATION1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IWWP_WEBNOTIFICATION1 ON WWP_WebNotification (WWPNotificationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateWWP_SMS( )
      {
         string cmdBuffer = "";
         /* Indices for table WWP_SMS */
         try
         {
            cmdBuffer=" CREATE SEQUENCE WWPSMSId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE WWPSMSId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE WWPSMSId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE WWP_SMS (WWPSMSId bigint NOT NULL DEFAULT nextval('WWPSMSId'), WWPSMSMessage TEXT NOT NULL , WWPSMSSenderNumber TEXT NOT NULL , WWPSMSRecipientNumbers TEXT NOT NULL , WWPSMSStatus smallint NOT NULL , WWPSMSCreated timestamp without time zone NOT NULL , WWPSMSScheduled timestamp without time zone NOT NULL , WWPSMSProcessed timestamp without time zone , WWPSMSDetail TEXT , WWPNotificationId bigint , PRIMARY KEY(WWPSMSId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE WWP_SMS CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW WWP_SMS CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION WWP_SMS CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE WWP_SMS (WWPSMSId bigint NOT NULL DEFAULT nextval('WWPSMSId'), WWPSMSMessage TEXT NOT NULL , WWPSMSSenderNumber TEXT NOT NULL , WWPSMSRecipientNumbers TEXT NOT NULL , WWPSMSStatus smallint NOT NULL , WWPSMSCreated timestamp without time zone NOT NULL , WWPSMSScheduled timestamp without time zone NOT NULL , WWPSMSProcessed timestamp without time zone , WWPSMSDetail TEXT , WWPNotificationId bigint , PRIMARY KEY(WWPSMSId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IWWP_SMS1 ON WWP_SMS (WWPNotificationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IWWP_SMS1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IWWP_SMS1 ON WWP_SMS (WWPNotificationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateWWP_Subscription( )
      {
         string cmdBuffer = "";
         /* Indices for table WWP_Subscription */
         try
         {
            cmdBuffer=" CREATE SEQUENCE WWPSubscriptionId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE WWPSubscriptionId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE WWPSubscriptionId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE WWP_Subscription (WWPSubscriptionId bigint NOT NULL DEFAULT nextval('WWPSubscriptionId'), WWPNotificationDefinitionId bigint NOT NULL , WWPSubscriptionEntityRecordId VARCHAR(2000) NOT NULL , WWPSubscriptionEntityRecordDescription VARCHAR(200) NOT NULL , WWPSubscriptionRoleId CHAR(40) , WWPSubscriptionSubscribed BOOLEAN NOT NULL , WWPUserExtendedId CHAR(40) , PRIMARY KEY(WWPSubscriptionId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE WWP_Subscription CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW WWP_Subscription CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION WWP_Subscription CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE WWP_Subscription (WWPSubscriptionId bigint NOT NULL DEFAULT nextval('WWPSubscriptionId'), WWPNotificationDefinitionId bigint NOT NULL , WWPSubscriptionEntityRecordId VARCHAR(2000) NOT NULL , WWPSubscriptionEntityRecordDescription VARCHAR(200) NOT NULL , WWPSubscriptionRoleId CHAR(40) , WWPSubscriptionSubscribed BOOLEAN NOT NULL , WWPUserExtendedId CHAR(40) , PRIMARY KEY(WWPSubscriptionId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IWWP_SUBSCRIPTION2 ON WWP_Subscription (WWPNotificationDefinitionId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IWWP_SUBSCRIPTION2 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IWWP_SUBSCRIPTION2 ON WWP_Subscription (WWPNotificationDefinitionId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IWWP_SUBSCRIPTION1 ON WWP_Subscription (WWPUserExtendedId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IWWP_SUBSCRIPTION1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IWWP_SUBSCRIPTION1 ON WWP_Subscription (WWPUserExtendedId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateWWP_Entity( )
      {
         string cmdBuffer = "";
         /* Indices for table WWP_Entity */
         try
         {
            cmdBuffer=" CREATE SEQUENCE WWPEntityId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE WWPEntityId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE WWPEntityId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE WWP_Entity (WWPEntityId bigint NOT NULL DEFAULT nextval('WWPEntityId'), WWPEntityName VARCHAR(100) NOT NULL , PRIMARY KEY(WWPEntityId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE WWP_Entity CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW WWP_Entity CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION WWP_Entity CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE WWP_Entity (WWPEntityId bigint NOT NULL DEFAULT nextval('WWPEntityId'), WWPEntityName VARCHAR(100) NOT NULL , PRIMARY KEY(WWPEntityId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateWWP_Parameter( )
      {
         string cmdBuffer = "";
         /* Indices for table WWP_Parameter */
         try
         {
            cmdBuffer=" CREATE TABLE WWP_Parameter (WWPParameterKey VARCHAR(300) NOT NULL , WWPParameterCategory VARCHAR(200) NOT NULL , WWPParameterDescription VARCHAR(200) NOT NULL , WWPParameterValue TEXT NOT NULL , WWPParameterDisableDelete BOOLEAN NOT NULL , PRIMARY KEY(WWPParameterKey))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE WWP_Parameter CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW WWP_Parameter CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION WWP_Parameter CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE WWP_Parameter (WWPParameterKey VARCHAR(300) NOT NULL , WWPParameterCategory VARCHAR(200) NOT NULL , WWPParameterDescription VARCHAR(200) NOT NULL , WWPParameterValue TEXT NOT NULL , WWPParameterDisableDelete BOOLEAN NOT NULL , PRIMARY KEY(WWPParameterKey))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateWWP_UserExtended( )
      {
         string cmdBuffer = "";
         /* Indices for table WWP_UserExtended */
         try
         {
            cmdBuffer=" CREATE TABLE WWP_UserExtended (WWPUserExtendedId CHAR(40) NOT NULL , WWPUserExtendedPhoto BYTEA NOT NULL , WWPUserExtendedPhoto_GXI VARCHAR(2048) , WWPUserExtendedName VARCHAR(100) NOT NULL , WWPUserExtendedFullName VARCHAR(100) NOT NULL , WWPUserExtendedPhone CHAR(20) NOT NULL , WWPUserExtendedEmail VARCHAR(100) NOT NULL , WWPUserExtendedEmaiNotif BOOLEAN NOT NULL , WWPUserExtendedSMSNotif BOOLEAN NOT NULL , WWPUserExtendedMobileNotif BOOLEAN NOT NULL , WWPUserExtendedDesktopNotif BOOLEAN NOT NULL , WWPUserExtendedDeleted BOOLEAN NOT NULL , WWPUserExtendedDeletedIn timestamp without time zone , PRIMARY KEY(WWPUserExtendedId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE WWP_UserExtended CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW WWP_UserExtended CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION WWP_UserExtended CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE WWP_UserExtended (WWPUserExtendedId CHAR(40) NOT NULL , WWPUserExtendedPhoto BYTEA NOT NULL , WWPUserExtendedPhoto_GXI VARCHAR(2048) , WWPUserExtendedName VARCHAR(100) NOT NULL , WWPUserExtendedFullName VARCHAR(100) NOT NULL , WWPUserExtendedPhone CHAR(20) NOT NULL , WWPUserExtendedEmail VARCHAR(100) NOT NULL , WWPUserExtendedEmaiNotif BOOLEAN NOT NULL , WWPUserExtendedSMSNotif BOOLEAN NOT NULL , WWPUserExtendedMobileNotif BOOLEAN NOT NULL , WWPUserExtendedDesktopNotif BOOLEAN NOT NULL , WWPUserExtendedDeleted BOOLEAN NOT NULL , WWPUserExtendedDeletedIn timestamp without time zone , PRIMARY KEY(WWPUserExtendedId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIWWP_SubscriptionWWP_NotificationDefinition( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE WWP_Subscription ADD CONSTRAINT IWWP_SUBSCRIPTION2 FOREIGN KEY (WWPNotificationDefinitionId) REFERENCES WWP_NotificationDefinition (WWPNotificationDefinitionId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE WWP_Subscription DROP CONSTRAINT IWWP_SUBSCRIPTION2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE WWP_Subscription ADD CONSTRAINT IWWP_SUBSCRIPTION2 FOREIGN KEY (WWPNotificationDefinitionId) REFERENCES WWP_NotificationDefinition (WWPNotificationDefinitionId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIWWP_SubscriptionWWP_UserExtended( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE WWP_Subscription ADD CONSTRAINT IWWP_SUBSCRIPTION1 FOREIGN KEY (WWPUserExtendedId) REFERENCES WWP_UserExtended (WWPUserExtendedId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE WWP_Subscription DROP CONSTRAINT IWWP_SUBSCRIPTION1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE WWP_Subscription ADD CONSTRAINT IWWP_SUBSCRIPTION1 FOREIGN KEY (WWPUserExtendedId) REFERENCES WWP_UserExtended (WWPUserExtendedId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIWWP_SMSWWP_Notification( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE WWP_SMS ADD CONSTRAINT IWWP_SMS1 FOREIGN KEY (WWPNotificationId) REFERENCES WWP_Notification (WWPNotificationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE WWP_SMS DROP CONSTRAINT IWWP_SMS1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE WWP_SMS ADD CONSTRAINT IWWP_SMS1 FOREIGN KEY (WWPNotificationId) REFERENCES WWP_Notification (WWPNotificationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIWWP_WebNotificationWWP_Notification( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE WWP_WebNotification ADD CONSTRAINT IWWP_WEBNOTIFICATION1 FOREIGN KEY (WWPNotificationId) REFERENCES WWP_Notification (WWPNotificationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE WWP_WebNotification DROP CONSTRAINT IWWP_WEBNOTIFICATION1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE WWP_WebNotification ADD CONSTRAINT IWWP_WEBNOTIFICATION1 FOREIGN KEY (WWPNotificationId) REFERENCES WWP_Notification (WWPNotificationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIWWP_WebClientWWP_UserExtended( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE WWP_WebClient ADD CONSTRAINT IWWP_WEBCLIENT1 FOREIGN KEY (WWPUserExtendedId) REFERENCES WWP_UserExtended (WWPUserExtendedId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE WWP_WebClient DROP CONSTRAINT IWWP_WEBCLIENT1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE WWP_WebClient ADD CONSTRAINT IWWP_WEBCLIENT1 FOREIGN KEY (WWPUserExtendedId) REFERENCES WWP_UserExtended (WWPUserExtendedId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIWWP_NotificationDefinitionWWP_Entity( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE WWP_NotificationDefinition ADD CONSTRAINT IWWP_NOTIFICATIONDEFINITION1 FOREIGN KEY (WWPEntityId) REFERENCES WWP_Entity (WWPEntityId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE WWP_NotificationDefinition DROP CONSTRAINT IWWP_NOTIFICATIONDEFINITION1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE WWP_NotificationDefinition ADD CONSTRAINT IWWP_NOTIFICATIONDEFINITION1 FOREIGN KEY (WWPEntityId) REFERENCES WWP_Entity (WWPEntityId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIWWP_NotificationWWP_NotificationDefinition( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE WWP_Notification ADD CONSTRAINT IWWP_NOTIFICATION2 FOREIGN KEY (WWPNotificationDefinitionId) REFERENCES WWP_NotificationDefinition (WWPNotificationDefinitionId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE WWP_Notification DROP CONSTRAINT IWWP_NOTIFICATION2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE WWP_Notification ADD CONSTRAINT IWWP_NOTIFICATION2 FOREIGN KEY (WWPNotificationDefinitionId) REFERENCES WWP_NotificationDefinition (WWPNotificationDefinitionId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIWWP_NotificationWWP_UserExtended( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE WWP_Notification ADD CONSTRAINT IWWP_NOTIFICATION1 FOREIGN KEY (WWPUserExtendedId) REFERENCES WWP_UserExtended (WWPUserExtendedId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE WWP_Notification DROP CONSTRAINT IWWP_NOTIFICATION1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE WWP_Notification ADD CONSTRAINT IWWP_NOTIFICATION1 FOREIGN KEY (WWPUserExtendedId) REFERENCES WWP_UserExtended (WWPUserExtendedId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIWWP_MailWWP_Notification( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE WWP_Mail ADD CONSTRAINT IWWP_MAIL1 FOREIGN KEY (WWPNotificationId) REFERENCES WWP_Notification (WWPNotificationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE WWP_Mail DROP CONSTRAINT IWWP_MAIL1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE WWP_Mail ADD CONSTRAINT IWWP_MAIL1 FOREIGN KEY (WWPNotificationId) REFERENCES WWP_Notification (WWPNotificationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIWWP_MailAttachmentsWWP_Mail( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE WWP_MailAttachments ADD CONSTRAINT IWWP_MAILATTACHMENTS1 FOREIGN KEY (WWPMailId) REFERENCES WWP_Mail (WWPMailId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE WWP_MailAttachments DROP CONSTRAINT IWWP_MAILATTACHMENTS1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE WWP_MailAttachments ADD CONSTRAINT IWWP_MAILATTACHMENTS1 FOREIGN KEY (WWPMailId) REFERENCES WWP_Mail (WWPMailId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIWWP_FormElementWWP_FormElement( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE WWP_FormElement ADD CONSTRAINT IWWPFORMELEMENT1 FOREIGN KEY (WWPFormId, WWPFormVersionNumber, WWPFormElementParentId) REFERENCES WWP_FormElement (WWPFormId, WWPFormVersionNumber, WWPFormElementId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE WWP_FormElement DROP CONSTRAINT IWWPFORMELEMENT1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE WWP_FormElement ADD CONSTRAINT IWWPFORMELEMENT1 FOREIGN KEY (WWPFormId, WWPFormVersionNumber, WWPFormElementParentId) REFERENCES WWP_FormElement (WWPFormId, WWPFormVersionNumber, WWPFormElementId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIWWP_FormInstanceWWP_Form( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE WWP_FormInstance ADD CONSTRAINT IWWPFORMINSTANCE1 FOREIGN KEY (WWPFormId, WWPFormVersionNumber) REFERENCES WWP_Form (WWPFormId, WWPFormVersionNumber) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE WWP_FormInstance DROP CONSTRAINT IWWPFORMINSTANCE1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE WWP_FormInstance ADD CONSTRAINT IWWPFORMINSTANCE1 FOREIGN KEY (WWPFormId, WWPFormVersionNumber) REFERENCES WWP_Form (WWPFormId, WWPFormVersionNumber) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIWWP_FormInstanceElementWWP_FormInstance( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE WWP_FormInstanceElement ADD CONSTRAINT IWWPFORMINSTANCEELEMENT1 FOREIGN KEY (WWPFormInstanceId) REFERENCES WWP_FormInstance (WWPFormInstanceId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE WWP_FormInstanceElement DROP CONSTRAINT IWWPFORMINSTANCEELEMENT1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE WWP_FormInstanceElement ADD CONSTRAINT IWWPFORMINSTANCEELEMENT1 FOREIGN KEY (WWPFormInstanceId) REFERENCES WWP_FormInstance (WWPFormInstanceId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RISecFunctionalitySecFunctionality( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE SecFunctionality ADD CONSTRAINT ISECFUNCTIONALITY1 FOREIGN KEY (SecParentFunctionalityId) REFERENCES SecFunctionality (SecFunctionalityId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE SecFunctionality DROP CONSTRAINT ISECFUNCTIONALITY1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE SecFunctionality ADD CONSTRAINT ISECFUNCTIONALITY1 FOREIGN KEY (SecParentFunctionalityId) REFERENCES SecFunctionality (SecFunctionalityId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RISecFunctionalityRoleSecFunctionality( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE SecFunctionalityRole ADD CONSTRAINT ISECFUNCTIONALITYROL1 FOREIGN KEY (SecFunctionalityId) REFERENCES SecFunctionality (SecFunctionalityId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE SecFunctionalityRole DROP CONSTRAINT ISECFUNCTIONALITYROL1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE SecFunctionalityRole ADD CONSTRAINT ISECFUNCTIONALITYROL1 FOREIGN KEY (SecFunctionalityId) REFERENCES SecFunctionality (SecFunctionalityId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RISecFunctionalityRoleSecRole( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE SecFunctionalityRole ADD CONSTRAINT ISECFUNCTIONALITYROL2 FOREIGN KEY (SecRoleId) REFERENCES SecRole (SecRoleId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE SecFunctionalityRole DROP CONSTRAINT ISECFUNCTIONALITYROL2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE SecFunctionalityRole ADD CONSTRAINT ISECFUNCTIONALITYROL2 FOREIGN KEY (SecRoleId) REFERENCES SecRole (SecRoleId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RISecObjectFunctionalitiesSecObject( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE SecObjectFunctionalities ADD CONSTRAINT ISECOBJECTFUNCTIONALITIES2 FOREIGN KEY (SecObjectName) REFERENCES SecObject (SecObjectName) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE SecObjectFunctionalities DROP CONSTRAINT ISECOBJECTFUNCTIONALITIES2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE SecObjectFunctionalities ADD CONSTRAINT ISECOBJECTFUNCTIONALITIES2 FOREIGN KEY (SecObjectName) REFERENCES SecObject (SecObjectName) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RISecObjectFunctionalitiesSecFunctionality( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE SecObjectFunctionalities ADD CONSTRAINT ISECOBJECTFUNCTIONALITIES1 FOREIGN KEY (SecFunctionalityId) REFERENCES SecFunctionality (SecFunctionalityId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE SecObjectFunctionalities DROP CONSTRAINT ISECOBJECTFUNCTIONALITIES1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE SecObjectFunctionalities ADD CONSTRAINT ISECOBJECTFUNCTIONALITIES1 FOREIGN KEY (SecFunctionalityId) REFERENCES SecFunctionality (SecFunctionalityId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RISecUserCliente( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE SecUser ADD CONSTRAINT ISECUSER3 FOREIGN KEY (SecUserOwnerId) REFERENCES Cliente (ClienteId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE SecUser DROP CONSTRAINT ISECUSER3 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE SecUser ADD CONSTRAINT ISECUSER3 FOREIGN KEY (SecUserOwnerId) REFERENCES Cliente (ClienteId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RISecUserSecUser( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE SecUser ADD CONSTRAINT ISECUSER2 FOREIGN KEY (SecUserClienteId) REFERENCES SecUser (SecUserId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE SecUser DROP CONSTRAINT ISECUSER2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE SecUser ADD CONSTRAINT ISECUSER2 FOREIGN KEY (SecUserClienteId) REFERENCES SecUser (SecUserId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RISecUserSecUser1( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE SecUser ADD CONSTRAINT ISECUSER1 FOREIGN KEY (SecUserUserMan) REFERENCES SecUser (SecUserId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE SecUser DROP CONSTRAINT ISECUSER1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE SecUser ADD CONSTRAINT ISECUSER1 FOREIGN KEY (SecUserUserMan) REFERENCES SecUser (SecUserId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RISecUserRoleSecUser( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE SecUserRole ADD CONSTRAINT ISECUSERROLE2 FOREIGN KEY (SecUserId) REFERENCES SecUser (SecUserId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE SecUserRole DROP CONSTRAINT ISECUSERROLE2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE SecUserRole ADD CONSTRAINT ISECUSERROLE2 FOREIGN KEY (SecUserId) REFERENCES SecUser (SecUserId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RISecUserRoleSecRole( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE SecUserRole ADD CONSTRAINT ISECUSERROLE1 FOREIGN KEY (SecRoleId) REFERENCES SecRole (SecRoleId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE SecUserRole DROP CONSTRAINT ISECUSERROLE1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE SecUserRole ADD CONSTRAINT ISECUSERROLE1 FOREIGN KEY (SecRoleId) REFERENCES SecRole (SecRoleId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RISecUserTokenSecUser( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE SecUserToken ADD CONSTRAINT ISECUSERUID1 FOREIGN KEY (SecUserId) REFERENCES SecUser (SecUserId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE SecUserToken DROP CONSTRAINT ISECUSERUID1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE SecUserToken ADD CONSTRAINT ISECUSERUID1 FOREIGN KEY (SecUserId) REFERENCES SecUser (SecUserId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIClienteTipoCliente( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Cliente ADD CONSTRAINT ICLIENTE2 FOREIGN KEY (TipoClienteId) REFERENCES TipoCliente (TipoClienteId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Cliente DROP CONSTRAINT ICLIENTE2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Cliente ADD CONSTRAINT ICLIENTE2 FOREIGN KEY (TipoClienteId) REFERENCES TipoCliente (TipoClienteId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIClienteMunicipio( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Cliente ADD CONSTRAINT ICLIENTE7 FOREIGN KEY (ResponsavelMunicipio) REFERENCES Municipio (MunicipioCodigo) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Cliente DROP CONSTRAINT ICLIENTE7 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Cliente ADD CONSTRAINT ICLIENTE7 FOREIGN KEY (ResponsavelMunicipio) REFERENCES Municipio (MunicipioCodigo) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIClienteMunicipio1( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Cliente ADD CONSTRAINT ICLIENTE3 FOREIGN KEY (MunicipioCodigo) REFERENCES Municipio (MunicipioCodigo) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Cliente DROP CONSTRAINT ICLIENTE3 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Cliente ADD CONSTRAINT ICLIENTE3 FOREIGN KEY (MunicipioCodigo) REFERENCES Municipio (MunicipioCodigo) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIClienteBanco( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Cliente ADD CONSTRAINT ICLIENTE4 FOREIGN KEY (BancoId) REFERENCES Banco (BancoId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Cliente DROP CONSTRAINT ICLIENTE4 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Cliente ADD CONSTRAINT ICLIENTE4 FOREIGN KEY (BancoId) REFERENCES Banco (BancoId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIClienteEspecialidade( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Cliente ADD CONSTRAINT ICLIENTE8 FOREIGN KEY (EspecialidadeId) REFERENCES Especialidade (EspecialidadeId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Cliente DROP CONSTRAINT ICLIENTE8 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Cliente ADD CONSTRAINT ICLIENTE8 FOREIGN KEY (EspecialidadeId) REFERENCES Especialidade (EspecialidadeId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIClienteNacionalidade( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Cliente ADD CONSTRAINT ICLIENTE9 FOREIGN KEY (ClienteNacionalidade) REFERENCES Nacionalidade (NacionalidadeId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Cliente DROP CONSTRAINT ICLIENTE9 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Cliente ADD CONSTRAINT ICLIENTE9 FOREIGN KEY (ClienteNacionalidade) REFERENCES Nacionalidade (NacionalidadeId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIClienteNacionalidade1( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Cliente ADD CONSTRAINT ICLIENTE5 FOREIGN KEY (ResponsavelNacionalidade) REFERENCES Nacionalidade (NacionalidadeId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Cliente DROP CONSTRAINT ICLIENTE5 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Cliente ADD CONSTRAINT ICLIENTE5 FOREIGN KEY (ResponsavelNacionalidade) REFERENCES Nacionalidade (NacionalidadeId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIClienteProfissao( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Cliente ADD CONSTRAINT ICLIENTE10 FOREIGN KEY (ClienteProfissao) REFERENCES Profissao (ProfissaoId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Cliente DROP CONSTRAINT ICLIENTE10 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Cliente ADD CONSTRAINT ICLIENTE10 FOREIGN KEY (ClienteProfissao) REFERENCES Profissao (ProfissaoId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIClienteProfissao1( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Cliente ADD CONSTRAINT ICLIENTE6 FOREIGN KEY (ResponsavelProfissao) REFERENCES Profissao (ProfissaoId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Cliente DROP CONSTRAINT ICLIENTE6 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Cliente ADD CONSTRAINT ICLIENTE6 FOREIGN KEY (ResponsavelProfissao) REFERENCES Profissao (ProfissaoId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIClienteConvenio( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Cliente ADD CONSTRAINT ICLIENTE11 FOREIGN KEY (ClienteConvenio) REFERENCES Convenio (ConvenioId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Cliente DROP CONSTRAINT ICLIENTE11 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Cliente ADD CONSTRAINT ICLIENTE11 FOREIGN KEY (ClienteConvenio) REFERENCES Convenio (ConvenioId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIFinanciamentoCliente( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Financiamento ADD CONSTRAINT IFINANCIAMENTO2 FOREIGN KEY (IntermediadorClienteId) REFERENCES Cliente (ClienteId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Financiamento DROP CONSTRAINT IFINANCIAMENTO2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Financiamento ADD CONSTRAINT IFINANCIAMENTO2 FOREIGN KEY (IntermediadorClienteId) REFERENCES Cliente (ClienteId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIFinanciamentoCliente1( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Financiamento ADD CONSTRAINT IFINANCIAMENTO1 FOREIGN KEY (ClienteId) REFERENCES Cliente (ClienteId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Financiamento DROP CONSTRAINT IFINANCIAMENTO1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Financiamento ADD CONSTRAINT IFINANCIAMENTO1 FOREIGN KEY (ClienteId) REFERENCES Cliente (ClienteId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIContratoCliente( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Contrato ADD CONSTRAINT ICONTRATO1 FOREIGN KEY (ContratoClienteId) REFERENCES Cliente (ClienteId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Contrato DROP CONSTRAINT ICONTRATO1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Contrato ADD CONSTRAINT ICONTRATO1 FOREIGN KEY (ContratoClienteId) REFERENCES Cliente (ClienteId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIContratoProposta( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Contrato ADD CONSTRAINT ICONTRATO2 FOREIGN KEY (ContratoPropostaId) REFERENCES Proposta (PropostaId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Contrato DROP CONSTRAINT ICONTRATO2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Contrato ADD CONSTRAINT ICONTRATO2 FOREIGN KEY (ContratoPropostaId) REFERENCES Proposta (PropostaId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIContratoParticipanteContrato( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE ContratoParticipante ADD CONSTRAINT ICONTRATOPARTICIPANTE2 FOREIGN KEY (ContratoId) REFERENCES Contrato (ContratoId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE ContratoParticipante DROP CONSTRAINT ICONTRATOPARTICIPANTE2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE ContratoParticipante ADD CONSTRAINT ICONTRATOPARTICIPANTE2 FOREIGN KEY (ContratoId) REFERENCES Contrato (ContratoId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIContratoParticipanteParticipante( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE ContratoParticipante ADD CONSTRAINT ICONTRATOPARTICIPANTE1 FOREIGN KEY (ParticipanteId) REFERENCES Participante (ParticipanteId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE ContratoParticipante DROP CONSTRAINT ICONTRATOPARTICIPANTE1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE ContratoParticipante ADD CONSTRAINT ICONTRATOPARTICIPANTE1 FOREIGN KEY (ParticipanteId) REFERENCES Participante (ParticipanteId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIAssinaturaContrato( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Assinatura ADD CONSTRAINT IASSINATURA1 FOREIGN KEY (ContratoId) REFERENCES Contrato (ContratoId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Assinatura DROP CONSTRAINT IASSINATURA1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Assinatura ADD CONSTRAINT IASSINATURA1 FOREIGN KEY (ContratoId) REFERENCES Contrato (ContratoId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIAssinaturaArquivo( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Assinatura ADD CONSTRAINT IASSINATURA3 FOREIGN KEY (ArquivoAssinadoId) REFERENCES Arquivo (ArquivoId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Assinatura DROP CONSTRAINT IASSINATURA3 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Assinatura ADD CONSTRAINT IASSINATURA3 FOREIGN KEY (ArquivoAssinadoId) REFERENCES Arquivo (ArquivoId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIAssinaturaArquivo1( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Assinatura ADD CONSTRAINT IASSINATURA2 FOREIGN KEY (ArquivoId) REFERENCES Arquivo (ArquivoId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Assinatura DROP CONSTRAINT IASSINATURA2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Assinatura ADD CONSTRAINT IASSINATURA2 FOREIGN KEY (ArquivoId) REFERENCES Arquivo (ArquivoId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIAssinaturaParticipanteAssinatura( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE AssinaturaParticipante ADD CONSTRAINT IASSINATURAPARTICIPANTE2 FOREIGN KEY (AssinaturaId) REFERENCES Assinatura (AssinaturaId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE AssinaturaParticipante DROP CONSTRAINT IASSINATURAPARTICIPANTE2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE AssinaturaParticipante ADD CONSTRAINT IASSINATURAPARTICIPANTE2 FOREIGN KEY (AssinaturaId) REFERENCES Assinatura (AssinaturaId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIAssinaturaParticipanteParticipante( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE AssinaturaParticipante ADD CONSTRAINT IASSINATURAPARTICIPANTE1 FOREIGN KEY (ParticipanteId) REFERENCES Participante (ParticipanteId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE AssinaturaParticipante DROP CONSTRAINT IASSINATURAPARTICIPANTE1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE AssinaturaParticipante ADD CONSTRAINT IASSINATURAPARTICIPANTE1 FOREIGN KEY (ParticipanteId) REFERENCES Participante (ParticipanteId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIAssinaturaParticipanteCliente( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE AssinaturaParticipante ADD CONSTRAINT IASSINATURAPARTICIPANTE3 FOREIGN KEY (ClienteId) REFERENCES Cliente (ClienteId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE AssinaturaParticipante DROP CONSTRAINT IASSINATURAPARTICIPANTE3 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE AssinaturaParticipante ADD CONSTRAINT IASSINATURAPARTICIPANTE3 FOREIGN KEY (ClienteId) REFERENCES Cliente (ClienteId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIEmpresaMunicipio( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Empresa ADD CONSTRAINT IEMPRESA4 FOREIGN KEY (EmpresaRepresentanteMunicipio) REFERENCES Municipio (MunicipioCodigo) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Empresa DROP CONSTRAINT IEMPRESA4 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Empresa ADD CONSTRAINT IEMPRESA4 FOREIGN KEY (EmpresaRepresentanteMunicipio) REFERENCES Municipio (MunicipioCodigo) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIEmpresaMunicipio1( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Empresa ADD CONSTRAINT IEMPRESA3 FOREIGN KEY (MunicipioCodigo) REFERENCES Municipio (MunicipioCodigo) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Empresa DROP CONSTRAINT IEMPRESA3 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Empresa ADD CONSTRAINT IEMPRESA3 FOREIGN KEY (MunicipioCodigo) REFERENCES Municipio (MunicipioCodigo) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIEmpresaBanco( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Empresa ADD CONSTRAINT IEMPRESA1 FOREIGN KEY (EmpresaBancoId) REFERENCES Banco (BancoId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Empresa DROP CONSTRAINT IEMPRESA1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Empresa ADD CONSTRAINT IEMPRESA1 FOREIGN KEY (EmpresaBancoId) REFERENCES Banco (BancoId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIEmpresaProfissao( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Empresa ADD CONSTRAINT IEMPRESA2 FOREIGN KEY (EmpresaRepresentanteProfissao) REFERENCES Profissao (ProfissaoId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Empresa DROP CONSTRAINT IEMPRESA2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Empresa ADD CONSTRAINT IEMPRESA2 FOREIGN KEY (EmpresaRepresentanteProfissao) REFERENCES Profissao (ProfissaoId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIAssinaturaParticipanteNotificacaoAssinaturaParticipante( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE AssinaturaParticipanteNotificacao ADD CONSTRAINT IASSINATURAPARTICIPANTENOTIFICACAO1 FOREIGN KEY (AssinaturaParticipanteId) REFERENCES AssinaturaParticipante (AssinaturaParticipanteId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE AssinaturaParticipanteNotificacao DROP CONSTRAINT IASSINATURAPARTICIPANTENOTIFICACAO1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE AssinaturaParticipanteNotificacao ADD CONSTRAINT IASSINATURAPARTICIPANTENOTIFICACAO1 FOREIGN KEY (AssinaturaParticipanteId) REFERENCES AssinaturaParticipante (AssinaturaParticipanteId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITituloConta( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Titulo ADD CONSTRAINT ITITULO3 FOREIGN KEY (ContaId) REFERENCES Conta (ContaId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Titulo DROP CONSTRAINT ITITULO3 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Titulo ADD CONSTRAINT ITITULO3 FOREIGN KEY (ContaId) REFERENCES Conta (ContaId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITituloCategoriaTitulo( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Titulo ADD CONSTRAINT ITITULO2 FOREIGN KEY (CategoriaTituloId) REFERENCES CategoriaTitulo (CategoriaTituloId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Titulo DROP CONSTRAINT ITITULO2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Titulo ADD CONSTRAINT ITITULO2 FOREIGN KEY (CategoriaTituloId) REFERENCES CategoriaTitulo (CategoriaTituloId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITituloNotaFiscalParcelamento( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Titulo ADD CONSTRAINT ITITULO4 FOREIGN KEY (NotaFiscalParcelamentoID) REFERENCES NotaFiscalParcelamento (NotaFiscalParcelamentoID) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Titulo DROP CONSTRAINT ITITULO4 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Titulo ADD CONSTRAINT ITITULO4 FOREIGN KEY (NotaFiscalParcelamentoID) REFERENCES NotaFiscalParcelamento (NotaFiscalParcelamentoID) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITituloContaBancaria( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Titulo ADD CONSTRAINT ITITULO5 FOREIGN KEY (ContaBancariaId) REFERENCES ContaBancaria (ContaBancariaId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Titulo DROP CONSTRAINT ITITULO5 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Titulo ADD CONSTRAINT ITITULO5 FOREIGN KEY (ContaBancariaId) REFERENCES ContaBancaria (ContaBancariaId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITituloProposta( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Titulo ADD CONSTRAINT ITITULO1 FOREIGN KEY (TituloPropostaId) REFERENCES Proposta (PropostaId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Titulo DROP CONSTRAINT ITITULO1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Titulo ADD CONSTRAINT ITITULO1 FOREIGN KEY (TituloPropostaId) REFERENCES Proposta (PropostaId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITituloCliente( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Titulo ADD CONSTRAINT ITITULO6 FOREIGN KEY (TituloClienteId) REFERENCES Cliente (ClienteId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Titulo DROP CONSTRAINT ITITULO6 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Titulo ADD CONSTRAINT ITITULO6 FOREIGN KEY (TituloClienteId) REFERENCES Cliente (ClienteId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITituloMovimentoTipoPagamento( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE TituloMovimento ADD CONSTRAINT ITITULOMOVIMENTO2 FOREIGN KEY (TipoPagamentoId) REFERENCES TipoPagamento (TipoPagamentoId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE TituloMovimento DROP CONSTRAINT ITITULOMOVIMENTO2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE TituloMovimento ADD CONSTRAINT ITITULOMOVIMENTO2 FOREIGN KEY (TipoPagamentoId) REFERENCES TipoPagamento (TipoPagamentoId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITituloMovimentoTitulo( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE TituloMovimento ADD CONSTRAINT ITITULOMOVIMENTO1 FOREIGN KEY (TituloId) REFERENCES Titulo (TituloId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE TituloMovimento DROP CONSTRAINT ITITULOMOVIMENTO1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE TituloMovimento ADD CONSTRAINT ITITULOMOVIMENTO1 FOREIGN KEY (TituloId) REFERENCES Titulo (TituloId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITituloMovimentoConta( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE TituloMovimento ADD CONSTRAINT ITITULOMOVIMENTO3 FOREIGN KEY (TituloMovimentoConta) REFERENCES Conta (ContaId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE TituloMovimento DROP CONSTRAINT ITITULOMOVIMENTO3 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE TituloMovimento ADD CONSTRAINT ITITULOMOVIMENTO3 FOREIGN KEY (TituloMovimentoConta) REFERENCES Conta (ContaId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIConfiguracoesLayoutContrato( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Configuracoes ADD CONSTRAINT ICONFIGURACOES6 FOREIGN KEY (ConfigLayoutContratoCompraTitulo) REFERENCES LayoutContrato (LayoutContratoId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Configuracoes DROP CONSTRAINT ICONFIGURACOES6 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Configuracoes ADD CONSTRAINT ICONFIGURACOES6 FOREIGN KEY (ConfigLayoutContratoCompraTitulo) REFERENCES LayoutContrato (LayoutContratoId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIConfiguracoesLayoutContrato1( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Configuracoes ADD CONSTRAINT ICONFIGURACOES4 FOREIGN KEY (ConfigLayoutPromissoriaPaciente) REFERENCES LayoutContrato (LayoutContratoId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Configuracoes DROP CONSTRAINT ICONFIGURACOES4 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Configuracoes ADD CONSTRAINT ICONFIGURACOES4 FOREIGN KEY (ConfigLayoutPromissoriaPaciente) REFERENCES LayoutContrato (LayoutContratoId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIConfiguracoesLayoutContrato2( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Configuracoes ADD CONSTRAINT ICONFIGURACOES3 FOREIGN KEY (ConfigLayoutPromissoriaClinicaTaxa) REFERENCES LayoutContrato (LayoutContratoId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Configuracoes DROP CONSTRAINT ICONFIGURACOES3 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Configuracoes ADD CONSTRAINT ICONFIGURACOES3 FOREIGN KEY (ConfigLayoutPromissoriaClinicaTaxa) REFERENCES LayoutContrato (LayoutContratoId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIConfiguracoesLayoutContrato3( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Configuracoes ADD CONSTRAINT ICONFIGURACOES2 FOREIGN KEY (ConfigLayoutPromissoriaClinicaEmprestimo) REFERENCES LayoutContrato (LayoutContratoId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Configuracoes DROP CONSTRAINT ICONFIGURACOES2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Configuracoes ADD CONSTRAINT ICONFIGURACOES2 FOREIGN KEY (ConfigLayoutPromissoriaClinicaEmprestimo) REFERENCES LayoutContrato (LayoutContratoId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIConfiguracoesLayoutContrato4( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Configuracoes ADD CONSTRAINT ICONFIGURACOES1 FOREIGN KEY (ConfiguracoesLayoutProposta) REFERENCES LayoutContrato (LayoutContratoId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Configuracoes DROP CONSTRAINT ICONFIGURACOES1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Configuracoes ADD CONSTRAINT ICONFIGURACOES1 FOREIGN KEY (ConfiguracoesLayoutProposta) REFERENCES LayoutContrato (LayoutContratoId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIConfiguracoesCategoriaTitulo( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Configuracoes ADD CONSTRAINT ICONFIGURACOES5 FOREIGN KEY (ConfiguracoesCategoriaTitulo) REFERENCES CategoriaTitulo (CategoriaTituloId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Configuracoes DROP CONSTRAINT ICONFIGURACOES5 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Configuracoes ADD CONSTRAINT ICONFIGURACOES5 FOREIGN KEY (ConfiguracoesCategoriaTitulo) REFERENCES CategoriaTitulo (CategoriaTituloId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIPropostaContrato( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Proposta ADD CONSTRAINT IPROPOSTA1 FOREIGN KEY (ContratoId) REFERENCES Contrato (ContratoId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Proposta DROP CONSTRAINT IPROPOSTA1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Proposta ADD CONSTRAINT IPROPOSTA1 FOREIGN KEY (ContratoId) REFERENCES Contrato (ContratoId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIPropostaProcedimentosMedicos( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Proposta ADD CONSTRAINT IPROPOSTA4 FOREIGN KEY (ProcedimentosMedicosId) REFERENCES ProcedimentosMedicos (ProcedimentosMedicosId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Proposta DROP CONSTRAINT IPROPOSTA4 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Proposta ADD CONSTRAINT IPROPOSTA4 FOREIGN KEY (ProcedimentosMedicosId) REFERENCES ProcedimentosMedicos (ProcedimentosMedicosId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIPropostaConvenioCategoria( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Proposta ADD CONSTRAINT IPROPOSTA5 FOREIGN KEY (ConvenioCategoriaId) REFERENCES ConvenioCategoria (ConvenioCategoriaId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Proposta DROP CONSTRAINT IPROPOSTA5 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Proposta ADD CONSTRAINT IPROPOSTA5 FOREIGN KEY (ConvenioCategoriaId) REFERENCES ConvenioCategoria (ConvenioCategoriaId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIPropostaSecUser( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Proposta ADD CONSTRAINT IPROPOSTA2 FOREIGN KEY (PropostaCratedBy) REFERENCES SecUser (SecUserId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Proposta DROP CONSTRAINT IPROPOSTA2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Proposta ADD CONSTRAINT IPROPOSTA2 FOREIGN KEY (PropostaCratedBy) REFERENCES SecUser (SecUserId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIPropostaCliente( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Proposta ADD CONSTRAINT IPROPOSTA8 FOREIGN KEY (PropostaEmpresaClienteId) REFERENCES Cliente (ClienteId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Proposta DROP CONSTRAINT IPROPOSTA8 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Proposta ADD CONSTRAINT IPROPOSTA8 FOREIGN KEY (PropostaEmpresaClienteId) REFERENCES Cliente (ClienteId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIPropostaCliente1( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Proposta ADD CONSTRAINT IPROPOSTA7 FOREIGN KEY (PropostaClinicaId) REFERENCES Cliente (ClienteId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Proposta DROP CONSTRAINT IPROPOSTA7 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Proposta ADD CONSTRAINT IPROPOSTA7 FOREIGN KEY (PropostaClinicaId) REFERENCES Cliente (ClienteId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIPropostaCliente2( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Proposta ADD CONSTRAINT IPROPOSTA3 FOREIGN KEY (PropostaResponsavelId) REFERENCES Cliente (ClienteId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Proposta DROP CONSTRAINT IPROPOSTA3 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Proposta ADD CONSTRAINT IPROPOSTA3 FOREIGN KEY (PropostaResponsavelId) REFERENCES Cliente (ClienteId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIPropostaCliente3( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Proposta ADD CONSTRAINT IPROPOSTA6 FOREIGN KEY (PropostaPacienteClienteId) REFERENCES Cliente (ClienteId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Proposta DROP CONSTRAINT IPROPOSTA6 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Proposta ADD CONSTRAINT IPROPOSTA6 FOREIGN KEY (PropostaPacienteClienteId) REFERENCES Cliente (ClienteId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIAprovacaoProposta( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Aprovacao ADD CONSTRAINT IAPROVACAO1 FOREIGN KEY (PropostaId) REFERENCES Proposta (PropostaId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Aprovacao DROP CONSTRAINT IAPROVACAO1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Aprovacao ADD CONSTRAINT IAPROVACAO1 FOREIGN KEY (PropostaId) REFERENCES Proposta (PropostaId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIAprovacaoAprovadores( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Aprovacao ADD CONSTRAINT IAPROVACAO2 FOREIGN KEY (AprovadoresId) REFERENCES Aprovadores (AprovadoresId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Aprovacao DROP CONSTRAINT IAPROVACAO2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Aprovacao ADD CONSTRAINT IAPROVACAO2 FOREIGN KEY (AprovadoresId) REFERENCES Aprovadores (AprovadoresId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIAprovadoresSecUser( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Aprovadores ADD CONSTRAINT IAPROVADORES1 FOREIGN KEY (SecUserId) REFERENCES SecUser (SecUserId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Aprovadores DROP CONSTRAINT IAPROVADORES1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Aprovadores ADD CONSTRAINT IAPROVADORES1 FOREIGN KEY (SecUserId) REFERENCES SecUser (SecUserId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RINotificationSecUser( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Notification ADD CONSTRAINT INOTIFICATION1 FOREIGN KEY (SecUserId) REFERENCES SecUser (SecUserId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Notification DROP CONSTRAINT INOTIFICATION1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Notification ADD CONSTRAINT INOTIFICATION1 FOREIGN KEY (SecUserId) REFERENCES SecUser (SecUserId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIUserNotificationNotification( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE UserNotification ADD CONSTRAINT IUSERNOTIFICATION1 FOREIGN KEY (NotificationId) REFERENCES Notification (NotificationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE UserNotification DROP CONSTRAINT IUSERNOTIFICATION1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE UserNotification ADD CONSTRAINT IUSERNOTIFICATION1 FOREIGN KEY (NotificationId) REFERENCES Notification (NotificationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIUserNotificationSecUser( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE UserNotification ADD CONSTRAINT IUSERNOTIFICATION2 FOREIGN KEY (UserNotificationUserId) REFERENCES SecUser (SecUserId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE UserNotification DROP CONSTRAINT IUSERNOTIFICATION2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE UserNotification ADD CONSTRAINT IUSERNOTIFICATION2 FOREIGN KEY (UserNotificationUserId) REFERENCES SecUser (SecUserId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIEmailQueueNotification( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE EmailQueue ADD CONSTRAINT IEMAILQUEUE1 FOREIGN KEY (NotificationId) REFERENCES Notification (NotificationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE EmailQueue DROP CONSTRAINT IEMAILQUEUE1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE EmailQueue ADD CONSTRAINT IEMAILQUEUE1 FOREIGN KEY (NotificationId) REFERENCES Notification (NotificationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIPropostaDocumentosProposta( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE PropostaDocumentos ADD CONSTRAINT IPROPOSTADOCUMENTOS2 FOREIGN KEY (PropostaId) REFERENCES Proposta (PropostaId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE PropostaDocumentos DROP CONSTRAINT IPROPOSTADOCUMENTOS2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE PropostaDocumentos ADD CONSTRAINT IPROPOSTADOCUMENTOS2 FOREIGN KEY (PropostaId) REFERENCES Proposta (PropostaId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIPropostaDocumentosDocumentos( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE PropostaDocumentos ADD CONSTRAINT IPROPOSTADOCUMENTOS1 FOREIGN KEY (DocumentosId) REFERENCES Documentos (DocumentosId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE PropostaDocumentos DROP CONSTRAINT IPROPOSTADOCUMENTOS1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE PropostaDocumentos ADD CONSTRAINT IPROPOSTADOCUMENTOS1 FOREIGN KEY (DocumentosId) REFERENCES Documentos (DocumentosId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIEspecialidadeSecUser( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Especialidade ADD CONSTRAINT IESPECIALIDADE1 FOREIGN KEY (EspecialidadeCreatedBy) REFERENCES SecUser (SecUserId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Especialidade DROP CONSTRAINT IESPECIALIDADE1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Especialidade ADD CONSTRAINT IESPECIALIDADE1 FOREIGN KEY (EspecialidadeCreatedBy) REFERENCES SecUser (SecUserId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIConfiguracoesTestemunhasSecUser( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE ConfiguracoesTestemunhas ADD CONSTRAINT ICONFIGURACOESTESTEMUNHAS1 FOREIGN KEY (SecUserId) REFERENCES SecUser (SecUserId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE ConfiguracoesTestemunhas DROP CONSTRAINT ICONFIGURACOESTESTEMUNHAS1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE ConfiguracoesTestemunhas ADD CONSTRAINT ICONFIGURACOESTESTEMUNHAS1 FOREIGN KEY (SecUserId) REFERENCES SecUser (SecUserId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIConvenioCategoriaConvenio( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE ConvenioCategoria ADD CONSTRAINT ICONVENIOCATEGORIA1 FOREIGN KEY (ConvenioId) REFERENCES Convenio (ConvenioId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE ConvenioCategoria DROP CONSTRAINT ICONVENIOCATEGORIA1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE ConvenioCategoria ADD CONSTRAINT ICONVENIOCATEGORIA1 FOREIGN KEY (ConvenioId) REFERENCES Convenio (ConvenioId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIReembolsoWorkflowConvenio( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Reembolso ADD CONSTRAINT IREEMBOLSO3 FOREIGN KEY (WorkflowConvenioId) REFERENCES WorkflowConvenio (WorkflowConvenioId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Reembolso DROP CONSTRAINT IREEMBOLSO3 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Reembolso ADD CONSTRAINT IREEMBOLSO3 FOREIGN KEY (WorkflowConvenioId) REFERENCES WorkflowConvenio (WorkflowConvenioId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIReembolsoProposta( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Reembolso ADD CONSTRAINT IREEMBOLSO1 FOREIGN KEY (ReembolsoPropostaId) REFERENCES Proposta (PropostaId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Reembolso DROP CONSTRAINT IREEMBOLSO1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Reembolso ADD CONSTRAINT IREEMBOLSO1 FOREIGN KEY (ReembolsoPropostaId) REFERENCES Proposta (PropostaId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIReembolsoSecUser( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Reembolso ADD CONSTRAINT IREEMBOLSO2 FOREIGN KEY (ReembolsoCreatedBy) REFERENCES SecUser (SecUserId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Reembolso DROP CONSTRAINT IREEMBOLSO2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Reembolso ADD CONSTRAINT IREEMBOLSO2 FOREIGN KEY (ReembolsoCreatedBy) REFERENCES SecUser (SecUserId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIReembolsoEtapaReembolso( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE ReembolsoEtapa ADD CONSTRAINT IREEMBOLSOETAPA1 FOREIGN KEY (ReembolsoId) REFERENCES Reembolso (ReembolsoId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE ReembolsoEtapa DROP CONSTRAINT IREEMBOLSOETAPA1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE ReembolsoEtapa ADD CONSTRAINT IREEMBOLSOETAPA1 FOREIGN KEY (ReembolsoId) REFERENCES Reembolso (ReembolsoId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIReembolsoDocumentoReembolsoEtapa( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE ReembolsoDocumento ADD CONSTRAINT IREEMBOLSODOCUMENTO2 FOREIGN KEY (ReembolsoEtapaId) REFERENCES ReembolsoEtapa (ReembolsoEtapaId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE ReembolsoDocumento DROP CONSTRAINT IREEMBOLSODOCUMENTO2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE ReembolsoDocumento ADD CONSTRAINT IREEMBOLSODOCUMENTO2 FOREIGN KEY (ReembolsoEtapaId) REFERENCES ReembolsoEtapa (ReembolsoEtapaId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIReembolsoDocumentoDocumentos( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE ReembolsoDocumento ADD CONSTRAINT IREEMBOLSODOCUMENTO1 FOREIGN KEY (DocumentosId) REFERENCES Documentos (DocumentosId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE ReembolsoDocumento DROP CONSTRAINT IREEMBOLSODOCUMENTO1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE ReembolsoDocumento ADD CONSTRAINT IREEMBOLSODOCUMENTO1 FOREIGN KEY (DocumentosId) REFERENCES Documentos (DocumentosId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIClienteReponsavelCliente( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE ClienteReponsavel ADD CONSTRAINT ICLIENTEREPONSAVEL2 FOREIGN KEY (ReponsavelClienteId) REFERENCES Cliente (ClienteId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE ClienteReponsavel DROP CONSTRAINT ICLIENTEREPONSAVEL2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE ClienteReponsavel ADD CONSTRAINT ICLIENTEREPONSAVEL2 FOREIGN KEY (ReponsavelClienteId) REFERENCES Cliente (ClienteId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIClienteReponsavelCliente1( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE ClienteReponsavel ADD CONSTRAINT ICLIENTEREPONSAVEL1 FOREIGN KEY (ClienteId) REFERENCES Cliente (ClienteId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE ClienteReponsavel DROP CONSTRAINT ICLIENTEREPONSAVEL1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE ClienteReponsavel ADD CONSTRAINT ICLIENTEREPONSAVEL1 FOREIGN KEY (ClienteId) REFERENCES Cliente (ClienteId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIAssinaturaParticipanteTokenAssinaturaParticipante( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE AssinaturaParticipanteToken ADD CONSTRAINT IASSINATURAPARTICIPANTETOKEN1 FOREIGN KEY (AssinaturaParticipanteId) REFERENCES AssinaturaParticipante (AssinaturaParticipanteId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE AssinaturaParticipanteToken DROP CONSTRAINT IASSINATURAPARTICIPANTETOKEN1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE AssinaturaParticipanteToken ADD CONSTRAINT IASSINATURAPARTICIPANTETOKEN1 FOREIGN KEY (AssinaturaParticipanteId) REFERENCES AssinaturaParticipante (AssinaturaParticipanteId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RISecUserLogSecUser( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE SecUserLog ADD CONSTRAINT ISECUSERLOG1 FOREIGN KEY (SecUserId) REFERENCES SecUser (SecUserId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE SecUserLog DROP CONSTRAINT ISECUSERLOG1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE SecUserLog ADD CONSTRAINT ISECUSERLOG1 FOREIGN KEY (SecUserId) REFERENCES SecUser (SecUserId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIPropostaContratoAssinaturaProposta( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE PropostaContratoAssinatura ADD CONSTRAINT IPROPOSTACONTRATOASSINATURA1 FOREIGN KEY (PropostaId) REFERENCES Proposta (PropostaId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE PropostaContratoAssinatura DROP CONSTRAINT IPROPOSTACONTRATOASSINATURA1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE PropostaContratoAssinatura ADD CONSTRAINT IPROPOSTACONTRATOASSINATURA1 FOREIGN KEY (PropostaId) REFERENCES Proposta (PropostaId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIPropostaContratoAssinaturaContrato( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE PropostaContratoAssinatura ADD CONSTRAINT IPROPOSTACONTRATOASSINATURA2 FOREIGN KEY (PropostaContrato) REFERENCES Contrato (ContratoId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE PropostaContratoAssinatura DROP CONSTRAINT IPROPOSTACONTRATOASSINATURA2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE PropostaContratoAssinatura ADD CONSTRAINT IPROPOSTACONTRATOASSINATURA2 FOREIGN KEY (PropostaContrato) REFERENCES Contrato (ContratoId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIPropostaContratoAssinaturaAssinatura( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE PropostaContratoAssinatura ADD CONSTRAINT IPROPOSTACONTRATOASSINATURA3 FOREIGN KEY (PropostaAssinatura) REFERENCES Assinatura (AssinaturaId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE PropostaContratoAssinatura DROP CONSTRAINT IPROPOSTACONTRATOASSINATURA3 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE PropostaContratoAssinatura ADD CONSTRAINT IPROPOSTACONTRATOASSINATURA3 FOREIGN KEY (PropostaAssinatura) REFERENCES Assinatura (AssinaturaId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIClienteDocumentoCliente( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE ClienteDocumento ADD CONSTRAINT ICLIENTEDOCUMENTO2 FOREIGN KEY (ClienteId) REFERENCES Cliente (ClienteId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE ClienteDocumento DROP CONSTRAINT ICLIENTEDOCUMENTO2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE ClienteDocumento ADD CONSTRAINT ICLIENTEDOCUMENTO2 FOREIGN KEY (ClienteId) REFERENCES Cliente (ClienteId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIClienteDocumentoDocumentos( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE ClienteDocumento ADD CONSTRAINT ICLIENTEDOCUMENTO1 FOREIGN KEY (DocumentosId) REFERENCES Documentos (DocumentosId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE ClienteDocumento DROP CONSTRAINT ICLIENTEDOCUMENTO1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE ClienteDocumento ADD CONSTRAINT ICLIENTEDOCUMENTO1 FOREIGN KEY (DocumentosId) REFERENCES Documentos (DocumentosId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIClienteDocumentoSecUser( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE ClienteDocumento ADD CONSTRAINT ICLIENTEDOCUMENTO3 FOREIGN KEY (ClienteDocumentoCreatedBy) REFERENCES SecUser (SecUserId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE ClienteDocumento DROP CONSTRAINT ICLIENTEDOCUMENTO3 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE ClienteDocumento ADD CONSTRAINT ICLIENTEDOCUMENTO3 FOREIGN KEY (ClienteDocumentoCreatedBy) REFERENCES SecUser (SecUserId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIReembolsoAssinaturasReembolso( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE ReembolsoAssinaturas ADD CONSTRAINT IREEMBOLSOASSINATURAS2 FOREIGN KEY (ReembolsoId) REFERENCES Reembolso (ReembolsoId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE ReembolsoAssinaturas DROP CONSTRAINT IREEMBOLSOASSINATURAS2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE ReembolsoAssinaturas ADD CONSTRAINT IREEMBOLSOASSINATURAS2 FOREIGN KEY (ReembolsoId) REFERENCES Reembolso (ReembolsoId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIReembolsoAssinaturasPropostaContratoAssinatura( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE ReembolsoAssinaturas ADD CONSTRAINT IREEMBOLSOASSINATURAS1 FOREIGN KEY (PropostaContratoAssinaturaId) REFERENCES PropostaContratoAssinatura (PropostaContratoAssinaturaId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE ReembolsoAssinaturas DROP CONSTRAINT IREEMBOLSOASSINATURAS1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE ReembolsoAssinaturas ADD CONSTRAINT IREEMBOLSOASSINATURAS1 FOREIGN KEY (PropostaContratoAssinaturaId) REFERENCES PropostaContratoAssinatura (PropostaContratoAssinaturaId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIReembolsoParcelasReembolso( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE ReembolsoParcelas ADD CONSTRAINT IREEMBOLSOPARCELAS1 FOREIGN KEY (ReembolsoId) REFERENCES Reembolso (ReembolsoId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE ReembolsoParcelas DROP CONSTRAINT IREEMBOLSOPARCELAS1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE ReembolsoParcelas ADD CONSTRAINT IREEMBOLSOPARCELAS1 FOREIGN KEY (ReembolsoId) REFERENCES Reembolso (ReembolsoId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RISerasaCliente( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Serasa ADD CONSTRAINT ISERASA1 FOREIGN KEY (ClienteId) REFERENCES Cliente (ClienteId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Serasa DROP CONSTRAINT ISERASA1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Serasa ADD CONSTRAINT ISERASA1 FOREIGN KEY (ClienteId) REFERENCES Cliente (ClienteId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RISerasaChequesSerasa( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE SerasaCheques ADD CONSTRAINT ISERASACHEQUES1 FOREIGN KEY (SerasaId) REFERENCES Serasa (SerasaId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE SerasaCheques DROP CONSTRAINT ISERASACHEQUES1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE SerasaCheques ADD CONSTRAINT ISERASACHEQUES1 FOREIGN KEY (SerasaId) REFERENCES Serasa (SerasaId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RISerasaAcoesSerasa( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE SerasaAcoes ADD CONSTRAINT ISERASAACOES1 FOREIGN KEY (SerasaId) REFERENCES Serasa (SerasaId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE SerasaAcoes DROP CONSTRAINT ISERASAACOES1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE SerasaAcoes ADD CONSTRAINT ISERASAACOES1 FOREIGN KEY (SerasaId) REFERENCES Serasa (SerasaId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RISerasaProtestosSerasa( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE SerasaProtestos ADD CONSTRAINT ISERASAPROTESTOS1 FOREIGN KEY (SerasaId) REFERENCES Serasa (SerasaId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE SerasaProtestos DROP CONSTRAINT ISERASAPROTESTOS1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE SerasaProtestos ADD CONSTRAINT ISERASAPROTESTOS1 FOREIGN KEY (SerasaId) REFERENCES Serasa (SerasaId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RISerasaEnderecosSerasa( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE SerasaEnderecos ADD CONSTRAINT ISERASAENDERECOS1 FOREIGN KEY (SerasaId) REFERENCES Serasa (SerasaId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE SerasaEnderecos DROP CONSTRAINT ISERASAENDERECOS1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE SerasaEnderecos ADD CONSTRAINT ISERASAENDERECOS1 FOREIGN KEY (SerasaId) REFERENCES Serasa (SerasaId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RISerasaOcorrenciasSerasa( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE SerasaOcorrencias ADD CONSTRAINT ISERASAOCORRENCIAS1 FOREIGN KEY (SerasaId) REFERENCES Serasa (SerasaId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE SerasaOcorrencias DROP CONSTRAINT ISERASAOCORRENCIAS1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE SerasaOcorrencias ADD CONSTRAINT ISERASAOCORRENCIAS1 FOREIGN KEY (SerasaId) REFERENCES Serasa (SerasaId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIReembolsoFlowLogWorkflowConvenio( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE ReembolsoFlowLog ADD CONSTRAINT IREEMBOLSOFLOWLOG3 FOREIGN KEY (LogWorkflowConvenioId) REFERENCES WorkflowConvenio (WorkflowConvenioId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE ReembolsoFlowLog DROP CONSTRAINT IREEMBOLSOFLOWLOG3 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE ReembolsoFlowLog ADD CONSTRAINT IREEMBOLSOFLOWLOG3 FOREIGN KEY (LogWorkflowConvenioId) REFERENCES WorkflowConvenio (WorkflowConvenioId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIReembolsoFlowLogSecUser( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE ReembolsoFlowLog ADD CONSTRAINT IREEMBOLSOFLOWLOG1 FOREIGN KEY (ReembolsoFlowLogUser) REFERENCES SecUser (SecUserId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE ReembolsoFlowLog DROP CONSTRAINT IREEMBOLSOFLOWLOG1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE ReembolsoFlowLog ADD CONSTRAINT IREEMBOLSOFLOWLOG1 FOREIGN KEY (ReembolsoFlowLogUser) REFERENCES SecUser (SecUserId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIReembolsoFlowLogReembolso( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE ReembolsoFlowLog ADD CONSTRAINT IREEMBOLSOFLOWLOG2 FOREIGN KEY (ReembolsoLogId) REFERENCES Reembolso (ReembolsoId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE ReembolsoFlowLog DROP CONSTRAINT IREEMBOLSOFLOWLOG2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE ReembolsoFlowLog ADD CONSTRAINT IREEMBOLSOFLOWLOG2 FOREIGN KEY (ReembolsoLogId) REFERENCES Reembolso (ReembolsoId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RINotaFiscalCliente( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE NotaFiscal ADD CONSTRAINT INOTAFISCAL2 FOREIGN KEY (NotaFiscalDestinatarioClienteId) REFERENCES Cliente (ClienteId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE NotaFiscal DROP CONSTRAINT INOTAFISCAL2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE NotaFiscal ADD CONSTRAINT INOTAFISCAL2 FOREIGN KEY (NotaFiscalDestinatarioClienteId) REFERENCES Cliente (ClienteId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RINotaFiscalCliente1( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE NotaFiscal ADD CONSTRAINT INOTAFISCAL1 FOREIGN KEY (ClienteId) REFERENCES Cliente (ClienteId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE NotaFiscal DROP CONSTRAINT INOTAFISCAL1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE NotaFiscal ADD CONSTRAINT INOTAFISCAL1 FOREIGN KEY (ClienteId) REFERENCES Cliente (ClienteId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RINotaFiscalItemProposta( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE NotaFiscalItem ADD CONSTRAINT INOTAFISCALITEM2 FOREIGN KEY (PropostaId) REFERENCES Proposta (PropostaId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE NotaFiscalItem DROP CONSTRAINT INOTAFISCALITEM2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE NotaFiscalItem ADD CONSTRAINT INOTAFISCALITEM2 FOREIGN KEY (PropostaId) REFERENCES Proposta (PropostaId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RINotaFiscalItemNotaFiscal( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE NotaFiscalItem ADD CONSTRAINT INOTAFISCALITEM1 FOREIGN KEY (NotaFiscalId) REFERENCES NotaFiscal (NotaFiscalId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE NotaFiscalItem DROP CONSTRAINT INOTAFISCALITEM1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE NotaFiscalItem ADD CONSTRAINT INOTAFISCALITEM1 FOREIGN KEY (NotaFiscalId) REFERENCES NotaFiscal (NotaFiscalId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RICreditoCliente( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Credito ADD CONSTRAINT ICREDITO1 FOREIGN KEY (ClienteId) REFERENCES Cliente (ClienteId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Credito DROP CONSTRAINT ICREDITO1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Credito ADD CONSTRAINT ICREDITO1 FOREIGN KEY (ClienteId) REFERENCES Cliente (ClienteId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RICreditoSecUser( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Credito ADD CONSTRAINT ICREDITO3 FOREIGN KEY (CreditoUpdatedBy) REFERENCES SecUser (SecUserId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Credito DROP CONSTRAINT ICREDITO3 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Credito ADD CONSTRAINT ICREDITO3 FOREIGN KEY (CreditoUpdatedBy) REFERENCES SecUser (SecUserId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RICreditoSecUser1( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Credito ADD CONSTRAINT ICREDITO2 FOREIGN KEY (CreditoCreatedBy) REFERENCES SecUser (SecUserId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Credito DROP CONSTRAINT ICREDITO2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Credito ADD CONSTRAINT ICREDITO2 FOREIGN KEY (CreditoCreatedBy) REFERENCES SecUser (SecUserId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITaxasSecUser( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Taxas ADD CONSTRAINT ITAXAS1 FOREIGN KEY (TaxasUpdatedBy) REFERENCES SecUser (SecUserId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Taxas DROP CONSTRAINT ITAXAS1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Taxas ADD CONSTRAINT ITAXAS1 FOREIGN KEY (TaxasUpdatedBy) REFERENCES SecUser (SecUserId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITaxasSecUser1( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Taxas ADD CONSTRAINT ITAXAS2 FOREIGN KEY (TaxasCreatedBy) REFERENCES SecUser (SecUserId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Taxas DROP CONSTRAINT ITAXAS2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Taxas ADD CONSTRAINT ITAXAS2 FOREIGN KEY (TaxasCreatedBy) REFERENCES SecUser (SecUserId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RINotaFiscalParcelamentoNotaFiscal( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE NotaFiscalParcelamento ADD CONSTRAINT INOTAFISCALPARCELAMENTO1 FOREIGN KEY (NotaFiscalId) REFERENCES NotaFiscal (NotaFiscalId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE NotaFiscalParcelamento DROP CONSTRAINT INOTAFISCALPARCELAMENTO1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE NotaFiscalParcelamento ADD CONSTRAINT INOTAFISCALPARCELAMENTO1 FOREIGN KEY (NotaFiscalId) REFERENCES NotaFiscal (NotaFiscalId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RINotificacaoAgendadaLayoutContrato( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE NotificacaoAgendada ADD CONSTRAINT INOTIFICACAOAGENDADA1 FOREIGN KEY (NotificacaoAgendadaLayoutId) REFERENCES LayoutContrato (LayoutContratoId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE NotificacaoAgendada DROP CONSTRAINT INOTIFICACAOAGENDADA1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE NotificacaoAgendada ADD CONSTRAINT INOTIFICACAOAGENDADA1 FOREIGN KEY (NotificacaoAgendadaLayoutId) REFERENCES LayoutContrato (LayoutContratoId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RINotificacaoAgendadaProcessamentoItemNotificacaoAgendadaProcessamento( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE NotificacaoAgendadaProcessamentoItem ADD CONSTRAINT INOTIFICACAOAGENDADAPROCESSAMENTOITEM1 FOREIGN KEY (NotificacaoAgendadaProcessamentoId) REFERENCES NotificacaoAgendadaProcessamento (NotificacaoAgendadaProcessamentoId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE NotificacaoAgendadaProcessamentoItem DROP CONSTRAINT INOTIFICACAOAGENDADAPROCESSAMENTOITEM1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE NotificacaoAgendadaProcessamentoItem ADD CONSTRAINT INOTIFICACAOAGENDADAPROCESSAMENTOITEM1 FOREIGN KEY (NotificacaoAgendadaProcessamentoId) REFERENCES NotificacaoAgendadaProcessamento (NotificacaoAgendadaProcessamentoId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIAgenciaSecUser( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Agencia ADD CONSTRAINT IAGENCIA2 FOREIGN KEY (AgenciaUpdatedBy) REFERENCES SecUser (SecUserId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Agencia DROP CONSTRAINT IAGENCIA2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Agencia ADD CONSTRAINT IAGENCIA2 FOREIGN KEY (AgenciaUpdatedBy) REFERENCES SecUser (SecUserId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIAgenciaSecUser1( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Agencia ADD CONSTRAINT IAGENCIA1 FOREIGN KEY (AgenciaCreatedBy) REFERENCES SecUser (SecUserId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Agencia DROP CONSTRAINT IAGENCIA1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Agencia ADD CONSTRAINT IAGENCIA1 FOREIGN KEY (AgenciaCreatedBy) REFERENCES SecUser (SecUserId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIAgenciaBanco( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Agencia ADD CONSTRAINT IAGENCIA3 FOREIGN KEY (AgenciaBancoId) REFERENCES Banco (BancoId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Agencia DROP CONSTRAINT IAGENCIA3 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Agencia ADD CONSTRAINT IAGENCIA3 FOREIGN KEY (AgenciaBancoId) REFERENCES Banco (BancoId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIContaBancariaAgencia( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE ContaBancaria ADD CONSTRAINT ICONTABANCARIA3 FOREIGN KEY (AgenciaId) REFERENCES Agencia (AgenciaId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE ContaBancaria DROP CONSTRAINT ICONTABANCARIA3 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE ContaBancaria ADD CONSTRAINT ICONTABANCARIA3 FOREIGN KEY (AgenciaId) REFERENCES Agencia (AgenciaId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIContaBancariaSecUser( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE ContaBancaria ADD CONSTRAINT ICONTABANCARIA2 FOREIGN KEY (ContaBancariaUpdatedBy) REFERENCES SecUser (SecUserId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE ContaBancaria DROP CONSTRAINT ICONTABANCARIA2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE ContaBancaria ADD CONSTRAINT ICONTABANCARIA2 FOREIGN KEY (ContaBancariaUpdatedBy) REFERENCES SecUser (SecUserId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIContaBancariaSecUser1( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE ContaBancaria ADD CONSTRAINT ICONTABANCARIA1 FOREIGN KEY (ContaBancariaCreatedBy) REFERENCES SecUser (SecUserId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE ContaBancaria DROP CONSTRAINT ICONTABANCARIA1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE ContaBancaria ADD CONSTRAINT ICONTABANCARIA1 FOREIGN KEY (ContaBancariaCreatedBy) REFERENCES SecUser (SecUserId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIChavePIXContaBancaria( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE ChavePIX ADD CONSTRAINT ICHAVEPIX3 FOREIGN KEY (ContaBancariaId) REFERENCES ContaBancaria (ContaBancariaId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE ChavePIX DROP CONSTRAINT ICHAVEPIX3 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE ChavePIX ADD CONSTRAINT ICHAVEPIX3 FOREIGN KEY (ContaBancariaId) REFERENCES ContaBancaria (ContaBancariaId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIChavePIXSecUser( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE ChavePIX ADD CONSTRAINT ICHAVEPIX2 FOREIGN KEY (ChavePIXUpdatedBy) REFERENCES SecUser (SecUserId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE ChavePIX DROP CONSTRAINT ICHAVEPIX2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE ChavePIX ADD CONSTRAINT ICHAVEPIX2 FOREIGN KEY (ChavePIXUpdatedBy) REFERENCES SecUser (SecUserId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIChavePIXSecUser1( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE ChavePIX ADD CONSTRAINT ICHAVEPIX1 FOREIGN KEY (ChavePIXCreatedBy) REFERENCES SecUser (SecUserId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE ChavePIX DROP CONSTRAINT ICHAVEPIX1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE ChavePIX ADD CONSTRAINT ICHAVEPIX1 FOREIGN KEY (ChavePIXCreatedBy) REFERENCES SecUser (SecUserId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIRepresentanteCliente( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Representante ADD CONSTRAINT IREPRESENTANTE3 FOREIGN KEY (ClienteId) REFERENCES Cliente (ClienteId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Representante DROP CONSTRAINT IREPRESENTANTE3 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Representante ADD CONSTRAINT IREPRESENTANTE3 FOREIGN KEY (ClienteId) REFERENCES Cliente (ClienteId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIRepresentanteProfissao( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Representante ADD CONSTRAINT IREPRESENTANTE1 FOREIGN KEY (RepresentanteProfissao) REFERENCES Profissao (ProfissaoId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Representante DROP CONSTRAINT IREPRESENTANTE1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Representante ADD CONSTRAINT IREPRESENTANTE1 FOREIGN KEY (RepresentanteProfissao) REFERENCES Profissao (ProfissaoId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIRepresentanteMunicipio( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Representante ADD CONSTRAINT IREPRESENTANTE2 FOREIGN KEY (RepresentanteMunicipio) REFERENCES Municipio (MunicipioCodigo) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Representante DROP CONSTRAINT IREPRESENTANTE2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Representante ADD CONSTRAINT IREPRESENTANTE2 FOREIGN KEY (RepresentanteMunicipio) REFERENCES Municipio (MunicipioCodigo) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      private void TablesCount( )
      {
      }

      private bool PreviousCheck( )
      {
         if ( ! MustRunCheck( ) )
         {
            return true ;
         }
         sSchemaVar = GXUtil.UserId( "Server", context, pr_default);
         if ( tableexist("Representante",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Representante"}) ) ;
            return false ;
         }
         if ( tableexist("ChavePIX",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"ChavePIX"}) ) ;
            return false ;
         }
         if ( tableexist("ContaBancaria",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"ContaBancaria"}) ) ;
            return false ;
         }
         if ( tableexist("Agencia",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Agencia"}) ) ;
            return false ;
         }
         if ( tableexist("NotificacaoAgendadaProcessamentoItem",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"NotificacaoAgendadaProcessamentoItem"}) ) ;
            return false ;
         }
         if ( tableexist("NotificacaoAgendadaProcessamento",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"NotificacaoAgendadaProcessamento"}) ) ;
            return false ;
         }
         if ( tableexist("NotificacaoAgendada",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"NotificacaoAgendada"}) ) ;
            return false ;
         }
         if ( tableexist("NotaFiscalParcelamento",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"NotaFiscalParcelamento"}) ) ;
            return false ;
         }
         if ( tableexist("Taxas",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Taxas"}) ) ;
            return false ;
         }
         if ( tableexist("Credito",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Credito"}) ) ;
            return false ;
         }
         if ( tableexist("NotaFiscalItem",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"NotaFiscalItem"}) ) ;
            return false ;
         }
         if ( tableexist("NotaFiscal",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"NotaFiscal"}) ) ;
            return false ;
         }
         if ( tableexist("ReembolsoFlowLog",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"ReembolsoFlowLog"}) ) ;
            return false ;
         }
         if ( tableexist("WorkflowConvenio",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"WorkflowConvenio"}) ) ;
            return false ;
         }
         if ( tableexist("ReembolsoPassos",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"ReembolsoPassos"}) ) ;
            return false ;
         }
         if ( tableexist("SerasaOcorrencias",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"SerasaOcorrencias"}) ) ;
            return false ;
         }
         if ( tableexist("SerasaEnderecos",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"SerasaEnderecos"}) ) ;
            return false ;
         }
         if ( tableexist("SerasaProtestos",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"SerasaProtestos"}) ) ;
            return false ;
         }
         if ( tableexist("SerasaAcoes",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"SerasaAcoes"}) ) ;
            return false ;
         }
         if ( tableexist("SerasaCheques",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"SerasaCheques"}) ) ;
            return false ;
         }
         if ( tableexist("Serasa",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Serasa"}) ) ;
            return false ;
         }
         if ( tableexist("WebService",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"WebService"}) ) ;
            return false ;
         }
         if ( tableexist("ReembolsoParcelas",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"ReembolsoParcelas"}) ) ;
            return false ;
         }
         if ( tableexist("ReembolsoAssinaturas",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"ReembolsoAssinaturas"}) ) ;
            return false ;
         }
         if ( tableexist("LogEmail",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"LogEmail"}) ) ;
            return false ;
         }
         if ( tableexist("ClienteDocumento",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"ClienteDocumento"}) ) ;
            return false ;
         }
         if ( tableexist("PropostaContratoAssinatura",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"PropostaContratoAssinatura"}) ) ;
            return false ;
         }
         if ( tableexist("SecUserLog",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"SecUserLog"}) ) ;
            return false ;
         }
         if ( tableexist("AssinaturaParticipanteToken",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"AssinaturaParticipanteToken"}) ) ;
            return false ;
         }
         if ( tableexist("ClienteReponsavel",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"ClienteReponsavel"}) ) ;
            return false ;
         }
         if ( tableexist("ReembolsoDocumento",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"ReembolsoDocumento"}) ) ;
            return false ;
         }
         if ( tableexist("Etapa",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Etapa"}) ) ;
            return false ;
         }
         if ( tableexist("ReembolsoEtapa",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"ReembolsoEtapa"}) ) ;
            return false ;
         }
         if ( tableexist("Reembolso",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Reembolso"}) ) ;
            return false ;
         }
         if ( tableexist("ConvenioCategoria",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"ConvenioCategoria"}) ) ;
            return false ;
         }
         if ( tableexist("ConfiguracaoNotificacoes",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"ConfiguracaoNotificacoes"}) ) ;
            return false ;
         }
         if ( tableexist("ConfiguracoesTestemunhas",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"ConfiguracoesTestemunhas"}) ) ;
            return false ;
         }
         if ( tableexist("Especialidade",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Especialidade"}) ) ;
            return false ;
         }
         if ( tableexist("Profissao",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Profissao"}) ) ;
            return false ;
         }
         if ( tableexist("Nacionalidade",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Nacionalidade"}) ) ;
            return false ;
         }
         if ( tableexist("CategoriaTitulo",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"CategoriaTitulo"}) ) ;
            return false ;
         }
         if ( tableexist("Conta",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Conta"}) ) ;
            return false ;
         }
         if ( tableexist("PropostaDocumentos",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"PropostaDocumentos"}) ) ;
            return false ;
         }
         if ( tableexist("Convenio",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Convenio"}) ) ;
            return false ;
         }
         if ( tableexist("Documentos",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Documentos"}) ) ;
            return false ;
         }
         if ( tableexist("Banco",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Banco"}) ) ;
            return false ;
         }
         if ( tableexist("EmailQueue",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"EmailQueue"}) ) ;
            return false ;
         }
         if ( tableexist("UserNotification",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"UserNotification"}) ) ;
            return false ;
         }
         if ( tableexist("Notification",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Notification"}) ) ;
            return false ;
         }
         if ( tableexist("Aprovadores",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Aprovadores"}) ) ;
            return false ;
         }
         if ( tableexist("ProcedimentosMedicos",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"ProcedimentosMedicos"}) ) ;
            return false ;
         }
         if ( tableexist("Tags",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Tags"}) ) ;
            return false ;
         }
         if ( tableexist("FilaProcessamento",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"FilaProcessamento"}) ) ;
            return false ;
         }
         if ( tableexist("Aprovacao",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Aprovacao"}) ) ;
            return false ;
         }
         if ( tableexist("LimiteAprovacao",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"LimiteAprovacao"}) ) ;
            return false ;
         }
         if ( tableexist("Proposta",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Proposta"}) ) ;
            return false ;
         }
         if ( tableexist("Configuracoes",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Configuracoes"}) ) ;
            return false ;
         }
         if ( tableexist("Preferencias",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Preferencias"}) ) ;
            return false ;
         }
         if ( tableexist("TipoPagamento",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"TipoPagamento"}) ) ;
            return false ;
         }
         if ( tableexist("TituloMovimento",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"TituloMovimento"}) ) ;
            return false ;
         }
         if ( tableexist("Titulo",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Titulo"}) ) ;
            return false ;
         }
         if ( tableexist("AssinaturaParticipanteNotificacao",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"AssinaturaParticipanteNotificacao"}) ) ;
            return false ;
         }
         if ( tableexist("Empresa",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Empresa"}) ) ;
            return false ;
         }
         if ( tableexist("AssinaturaParticipante",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"AssinaturaParticipante"}) ) ;
            return false ;
         }
         if ( tableexist("Assinatura",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Assinatura"}) ) ;
            return false ;
         }
         if ( tableexist("ContratoParticipante",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"ContratoParticipante"}) ) ;
            return false ;
         }
         if ( tableexist("Participante",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Participante"}) ) ;
            return false ;
         }
         if ( tableexist("Arquivo",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Arquivo"}) ) ;
            return false ;
         }
         if ( tableexist("Contrato",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Contrato"}) ) ;
            return false ;
         }
         if ( tableexist("Financiamento",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Financiamento"}) ) ;
            return false ;
         }
         if ( tableexist("TemporaryCode",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"TemporaryCode"}) ) ;
            return false ;
         }
         if ( tableexist("TipoCliente",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"TipoCliente"}) ) ;
            return false ;
         }
         if ( tableexist("Municipio",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Municipio"}) ) ;
            return false ;
         }
         if ( tableexist("CEP",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"CEP"}) ) ;
            return false ;
         }
         if ( tableexist("Cliente",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Cliente"}) ) ;
            return false ;
         }
         if ( tableexist("SecUserToken",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"SecUserToken"}) ) ;
            return false ;
         }
         if ( tableexist("ServidorSMTP",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"ServidorSMTP"}) ) ;
            return false ;
         }
         if ( tableexist("LayoutContrato",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"LayoutContrato"}) ) ;
            return false ;
         }
         if ( tableexist("Person",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Person"}) ) ;
            return false ;
         }
         if ( tableexist("SecUserRole",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"SecUserRole"}) ) ;
            return false ;
         }
         if ( tableexist("SecUser",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"SecUser"}) ) ;
            return false ;
         }
         if ( tableexist("SecRole",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"SecRole"}) ) ;
            return false ;
         }
         if ( tableexist("SecObjectFunctionalities",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"SecObjectFunctionalities"}) ) ;
            return false ;
         }
         if ( tableexist("SecObject",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"SecObject"}) ) ;
            return false ;
         }
         if ( tableexist("SecFunctionalityRole",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"SecFunctionalityRole"}) ) ;
            return false ;
         }
         if ( tableexist("SecFunctionality",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"SecFunctionality"}) ) ;
            return false ;
         }
         if ( tableexist("WWP_FormInstanceElement",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"WWP_FormInstanceElement"}) ) ;
            return false ;
         }
         if ( tableexist("WWP_FormInstance",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"WWP_FormInstance"}) ) ;
            return false ;
         }
         if ( tableexist("WWP_FormElement",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"WWP_FormElement"}) ) ;
            return false ;
         }
         if ( tableexist("WWP_Form",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"WWP_Form"}) ) ;
            return false ;
         }
         if ( tableexist("WWP_MailAttachments",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"WWP_MailAttachments"}) ) ;
            return false ;
         }
         if ( tableexist("WWP_Mail",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"WWP_Mail"}) ) ;
            return false ;
         }
         if ( tableexist("WWP_MailTemplate",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"WWP_MailTemplate"}) ) ;
            return false ;
         }
         if ( tableexist("WWP_Notification",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"WWP_Notification"}) ) ;
            return false ;
         }
         if ( tableexist("WWP_NotificationDefinition",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"WWP_NotificationDefinition"}) ) ;
            return false ;
         }
         if ( tableexist("WWP_WebClient",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"WWP_WebClient"}) ) ;
            return false ;
         }
         if ( tableexist("WWP_WebNotification",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"WWP_WebNotification"}) ) ;
            return false ;
         }
         if ( tableexist("WWP_SMS",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"WWP_SMS"}) ) ;
            return false ;
         }
         if ( tableexist("WWP_Subscription",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"WWP_Subscription"}) ) ;
            return false ;
         }
         if ( tableexist("WWP_Entity",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"WWP_Entity"}) ) ;
            return false ;
         }
         if ( tableexist("WWP_Parameter",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"WWP_Parameter"}) ) ;
            return false ;
         }
         if ( tableexist("WWP_UserExtended",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"WWP_UserExtended"}) ) ;
            return false ;
         }
         return true ;
      }

      private bool tableexist( string sTableName ,
                               string sMySchemaName )
      {
         bool result;
         result = false;
         /* Using cursor P00012 */
         pr_default.execute(0, new Object[] {sTableName, sMySchemaName});
         while ( (pr_default.getStatus(0) != 101) )
         {
            tablename = P00012_Atablename[0];
            ntablename = P00012_ntablename[0];
            schemaname = P00012_Aschemaname[0];
            nschemaname = P00012_nschemaname[0];
            result = true;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         /* Using cursor P00023 */
         pr_default.execute(1, new Object[] {sTableName, sMySchemaName});
         while ( (pr_default.getStatus(1) != 101) )
         {
            tablename = P00023_Atablename[0];
            ntablename = P00023_ntablename[0];
            schemaname = P00023_Aschemaname[0];
            nschemaname = P00023_nschemaname[0];
            result = true;
            pr_default.readNext(1);
         }
         pr_default.close(1);
         return result ;
      }

      private void ExecuteOnlyTablesReorganization( )
      {
         ReorgExecute.RegisterBlockForSubmit( 1 ,  "CreateRepresentante" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 2 ,  "CreateChavePIX" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 3 ,  "CreateContaBancaria" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 4 ,  "CreateAgencia" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 5 ,  "CreateNotificacaoAgendadaProcessamentoItem" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 6 ,  "CreateNotificacaoAgendadaProcessamento" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 7 ,  "CreateNotificacaoAgendada" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 8 ,  "CreateNotaFiscalParcelamento" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 9 ,  "CreateTaxas" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 10 ,  "CreateCredito" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 11 ,  "CreateNotaFiscalItem" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 12 ,  "CreateNotaFiscal" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 13 ,  "CreateReembolsoFlowLog" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 14 ,  "CreateWorkflowConvenio" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 15 ,  "CreateReembolsoPassos" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 16 ,  "CreateSerasaOcorrencias" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 17 ,  "CreateSerasaEnderecos" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 18 ,  "CreateSerasaProtestos" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 19 ,  "CreateSerasaAcoes" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 20 ,  "CreateSerasaCheques" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 21 ,  "CreateSerasa" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 22 ,  "CreateWebService" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 23 ,  "CreateReembolsoParcelas" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 24 ,  "CreateReembolsoAssinaturas" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 25 ,  "CreateLogEmail" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 26 ,  "CreateClienteDocumento" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 27 ,  "CreatePropostaContratoAssinatura" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 28 ,  "CreateSecUserLog" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 29 ,  "CreateAssinaturaParticipanteToken" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 30 ,  "CreateClienteReponsavel" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 31 ,  "CreateReembolsoDocumento" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 32 ,  "CreateEtapa" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 33 ,  "CreateReembolsoEtapa" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 34 ,  "CreateReembolso" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 35 ,  "CreateConvenioCategoria" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 36 ,  "CreateConfiguracaoNotificacoes" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 37 ,  "CreateConfiguracoesTestemunhas" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 38 ,  "CreateEspecialidade" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 39 ,  "CreateProfissao" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 40 ,  "CreateNacionalidade" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 41 ,  "CreateCategoriaTitulo" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 42 ,  "CreateConta" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 43 ,  "CreatePropostaDocumentos" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 44 ,  "CreateConvenio" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 45 ,  "CreateDocumentos" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 46 ,  "CreateBanco" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 47 ,  "CreateEmailQueue" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 48 ,  "CreateUserNotification" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 49 ,  "CreateNotification" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 50 ,  "CreateAprovadores" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 51 ,  "CreateProcedimentosMedicos" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 52 ,  "CreateTags" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 53 ,  "CreateFilaProcessamento" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 54 ,  "CreateAprovacao" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 55 ,  "CreateLimiteAprovacao" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 56 ,  "CreateProposta" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 57 ,  "CreateConfiguracoes" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 58 ,  "CreatePreferencias" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 59 ,  "CreateTipoPagamento" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 60 ,  "CreateTituloMovimento" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 61 ,  "CreateTitulo" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 62 ,  "CreateAssinaturaParticipanteNotificacao" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 63 ,  "CreateEmpresa" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 64 ,  "CreateAssinaturaParticipante" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 65 ,  "CreateAssinatura" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 66 ,  "CreateContratoParticipante" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 67 ,  "CreateParticipante" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 68 ,  "CreateArquivo" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 69 ,  "CreateContrato" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 70 ,  "CreateFinanciamento" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 71 ,  "CreateTemporaryCode" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 72 ,  "CreateTipoCliente" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 73 ,  "CreateMunicipio" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 74 ,  "CreateCEP" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 75 ,  "CreateCliente" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 76 ,  "CreateSecUserToken" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 77 ,  "CreateServidorSMTP" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 78 ,  "CreateLayoutContrato" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 79 ,  "CreatePerson" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 80 ,  "CreateSecUserRole" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 81 ,  "CreateSecUser" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 82 ,  "CreateSecRole" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 83 ,  "CreateSecObjectFunctionalities" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 84 ,  "CreateSecObject" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 85 ,  "CreateSecFunctionalityRole" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 86 ,  "CreateSecFunctionality" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 87 ,  "CreateWWP_FormInstanceElement" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 88 ,  "CreateWWP_FormInstance" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 89 ,  "CreateWWP_FormElement" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 90 ,  "CreateWWP_Form" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 91 ,  "CreateWWP_MailAttachments" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 92 ,  "CreateWWP_Mail" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 93 ,  "CreateWWP_MailTemplate" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 94 ,  "CreateWWP_Notification" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 95 ,  "CreateWWP_NotificationDefinition" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 96 ,  "CreateWWP_WebClient" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 97 ,  "CreateWWP_WebNotification" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 98 ,  "CreateWWP_SMS" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 99 ,  "CreateWWP_Subscription" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 100 ,  "CreateWWP_Entity" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 101 ,  "CreateWWP_Parameter" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 102 ,  "CreateWWP_UserExtended" , new Object[]{ });
      }

      private void ExecuteOnlyRisReorganization( )
      {
         ReorgExecute.RegisterBlockForSubmit( 103 ,  "RIWWP_SubscriptionWWP_NotificationDefinition" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 104 ,  "RIWWP_SubscriptionWWP_UserExtended" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 105 ,  "RIWWP_SMSWWP_Notification" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 106 ,  "RIWWP_WebNotificationWWP_Notification" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 107 ,  "RIWWP_WebClientWWP_UserExtended" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 108 ,  "RIWWP_NotificationDefinitionWWP_Entity" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 109 ,  "RIWWP_NotificationWWP_NotificationDefinition" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 110 ,  "RIWWP_NotificationWWP_UserExtended" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 111 ,  "RIWWP_MailWWP_Notification" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 112 ,  "RIWWP_MailAttachmentsWWP_Mail" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 113 ,  "RIWWP_FormElementWWP_FormElement" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 114 ,  "RIWWP_FormInstanceWWP_Form" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 115 ,  "RIWWP_FormInstanceElementWWP_FormInstance" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 116 ,  "RISecFunctionalitySecFunctionality" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 117 ,  "RISecFunctionalityRoleSecFunctionality" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 118 ,  "RISecFunctionalityRoleSecRole" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 119 ,  "RISecObjectFunctionalitiesSecObject" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 120 ,  "RISecObjectFunctionalitiesSecFunctionality" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 121 ,  "RISecUserCliente" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 122 ,  "RISecUserSecUser" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 123 ,  "RISecUserSecUser1" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 124 ,  "RISecUserRoleSecUser" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 125 ,  "RISecUserRoleSecRole" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 126 ,  "RISecUserTokenSecUser" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 127 ,  "RIClienteTipoCliente" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 128 ,  "RIClienteMunicipio" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 129 ,  "RIClienteMunicipio1" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 130 ,  "RIClienteBanco" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 131 ,  "RIClienteEspecialidade" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 132 ,  "RIClienteNacionalidade" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 133 ,  "RIClienteNacionalidade1" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 134 ,  "RIClienteProfissao" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 135 ,  "RIClienteProfissao1" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 136 ,  "RIClienteConvenio" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 137 ,  "RIFinanciamentoCliente" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 138 ,  "RIFinanciamentoCliente1" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 139 ,  "RIContratoCliente" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 140 ,  "RIContratoProposta" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 141 ,  "RIContratoParticipanteContrato" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 142 ,  "RIContratoParticipanteParticipante" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 143 ,  "RIAssinaturaContrato" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 144 ,  "RIAssinaturaArquivo" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 145 ,  "RIAssinaturaArquivo1" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 146 ,  "RIAssinaturaParticipanteAssinatura" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 147 ,  "RIAssinaturaParticipanteParticipante" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 148 ,  "RIAssinaturaParticipanteCliente" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 149 ,  "RIEmpresaMunicipio" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 150 ,  "RIEmpresaMunicipio1" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 151 ,  "RIEmpresaBanco" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 152 ,  "RIEmpresaProfissao" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 153 ,  "RIAssinaturaParticipanteNotificacaoAssinaturaParticipante" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 154 ,  "RITituloConta" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 155 ,  "RITituloCategoriaTitulo" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 156 ,  "RITituloNotaFiscalParcelamento" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 157 ,  "RITituloContaBancaria" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 158 ,  "RITituloProposta" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 159 ,  "RITituloCliente" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 160 ,  "RITituloMovimentoTipoPagamento" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 161 ,  "RITituloMovimentoTitulo" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 162 ,  "RITituloMovimentoConta" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 163 ,  "RIConfiguracoesLayoutContrato1" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 164 ,  "RIConfiguracoesLayoutContrato2" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 165 ,  "RIConfiguracoesLayoutContrato3" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 166 ,  "RIConfiguracoesLayoutContrato" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 167 ,  "RIConfiguracoesLayoutContrato4" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 168 ,  "RIConfiguracoesCategoriaTitulo" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 169 ,  "RIPropostaContrato" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 170 ,  "RIPropostaProcedimentosMedicos" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 171 ,  "RIPropostaConvenioCategoria" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 172 ,  "RIPropostaSecUser" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 173 ,  "RIPropostaCliente1" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 174 ,  "RIPropostaCliente2" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 175 ,  "RIPropostaCliente" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 176 ,  "RIPropostaCliente3" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 177 ,  "RIAprovacaoProposta" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 178 ,  "RIAprovacaoAprovadores" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 179 ,  "RIAprovadoresSecUser" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 180 ,  "RINotificationSecUser" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 181 ,  "RIUserNotificationNotification" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 182 ,  "RIUserNotificationSecUser" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 183 ,  "RIEmailQueueNotification" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 184 ,  "RIPropostaDocumentosProposta" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 185 ,  "RIPropostaDocumentosDocumentos" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 186 ,  "RIEspecialidadeSecUser" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 187 ,  "RIConfiguracoesTestemunhasSecUser" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 188 ,  "RIConvenioCategoriaConvenio" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 189 ,  "RIReembolsoWorkflowConvenio" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 190 ,  "RIReembolsoProposta" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 191 ,  "RIReembolsoSecUser" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 192 ,  "RIReembolsoEtapaReembolso" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 193 ,  "RIReembolsoDocumentoReembolsoEtapa" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 194 ,  "RIReembolsoDocumentoDocumentos" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 195 ,  "RIClienteReponsavelCliente" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 196 ,  "RIClienteReponsavelCliente1" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 197 ,  "RIAssinaturaParticipanteTokenAssinaturaParticipante" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 198 ,  "RISecUserLogSecUser" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 199 ,  "RIPropostaContratoAssinaturaProposta" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 200 ,  "RIPropostaContratoAssinaturaContrato" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 201 ,  "RIPropostaContratoAssinaturaAssinatura" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 202 ,  "RIClienteDocumentoCliente" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 203 ,  "RIClienteDocumentoDocumentos" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 204 ,  "RIClienteDocumentoSecUser" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 205 ,  "RIReembolsoAssinaturasReembolso" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 206 ,  "RIReembolsoAssinaturasPropostaContratoAssinatura" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 207 ,  "RIReembolsoParcelasReembolso" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 208 ,  "RISerasaCliente" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 209 ,  "RISerasaChequesSerasa" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 210 ,  "RISerasaAcoesSerasa" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 211 ,  "RISerasaProtestosSerasa" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 212 ,  "RISerasaEnderecosSerasa" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 213 ,  "RISerasaOcorrenciasSerasa" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 214 ,  "RIReembolsoFlowLogWorkflowConvenio" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 215 ,  "RIReembolsoFlowLogSecUser" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 216 ,  "RIReembolsoFlowLogReembolso" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 217 ,  "RINotaFiscalCliente" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 218 ,  "RINotaFiscalCliente1" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 219 ,  "RINotaFiscalItemProposta" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 220 ,  "RINotaFiscalItemNotaFiscal" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 221 ,  "RICreditoCliente" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 222 ,  "RICreditoSecUser" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 223 ,  "RICreditoSecUser1" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 224 ,  "RITaxasSecUser" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 225 ,  "RITaxasSecUser1" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 226 ,  "RINotaFiscalParcelamentoNotaFiscal" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 227 ,  "RINotificacaoAgendadaLayoutContrato" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 228 ,  "RINotificacaoAgendadaProcessamentoItemNotificacaoAgendadaProcessamento" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 229 ,  "RIAgenciaSecUser" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 230 ,  "RIAgenciaSecUser1" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 231 ,  "RIAgenciaBanco" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 232 ,  "RIContaBancariaAgencia" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 233 ,  "RIContaBancariaSecUser" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 234 ,  "RIContaBancariaSecUser1" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 235 ,  "RIChavePIXContaBancaria" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 236 ,  "RIChavePIXSecUser" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 237 ,  "RIChavePIXSecUser1" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 238 ,  "RIRepresentanteCliente" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 239 ,  "RIRepresentanteProfissao" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 240 ,  "RIRepresentanteMunicipio" , new Object[]{ });
      }

      private void ExecuteTablesReorganization( )
      {
         ExecuteOnlyTablesReorganization( ) ;
         ExecuteOnlyRisReorganization( ) ;
         ReorgExecute.SubmitAll() ;
      }

      private void SetPrecedence( )
      {
         SetPrecedencetables( ) ;
         SetPrecedenceris( ) ;
      }

      private void SetPrecedencetables( )
      {
         GXReorganization.SetMsg( 1 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Representante", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateRepresentante" ,  "CreateCliente" );
         ReorgExecute.RegisterPrecedence( "CreateRepresentante" ,  "CreateProfissao" );
         ReorgExecute.RegisterPrecedence( "CreateRepresentante" ,  "CreateMunicipio" );
         GXReorganization.SetMsg( 2 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"ChavePIX", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateChavePIX" ,  "CreateContaBancaria" );
         ReorgExecute.RegisterPrecedence( "CreateChavePIX" ,  "CreateSecUser" );
         ReorgExecute.RegisterPrecedence( "CreateChavePIX" ,  "CreateSecUser" );
         GXReorganization.SetMsg( 3 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"ContaBancaria", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateContaBancaria" ,  "CreateAgencia" );
         ReorgExecute.RegisterPrecedence( "CreateContaBancaria" ,  "CreateSecUser" );
         ReorgExecute.RegisterPrecedence( "CreateContaBancaria" ,  "CreateSecUser" );
         GXReorganization.SetMsg( 4 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Agencia", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateAgencia" ,  "CreateSecUser" );
         ReorgExecute.RegisterPrecedence( "CreateAgencia" ,  "CreateSecUser" );
         ReorgExecute.RegisterPrecedence( "CreateAgencia" ,  "CreateBanco" );
         GXReorganization.SetMsg( 5 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"NotificacaoAgendadaProcessamentoItem", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateNotificacaoAgendadaProcessamentoItem" ,  "CreateNotificacaoAgendadaProcessamento" );
         GXReorganization.SetMsg( 6 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"NotificacaoAgendadaProcessamento", ""}) );
         GXReorganization.SetMsg( 7 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"NotificacaoAgendada", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateNotificacaoAgendada" ,  "CreateLayoutContrato" );
         GXReorganization.SetMsg( 8 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"NotaFiscalParcelamento", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateNotaFiscalParcelamento" ,  "CreateNotaFiscal" );
         GXReorganization.SetMsg( 9 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Taxas", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateTaxas" ,  "CreateSecUser" );
         ReorgExecute.RegisterPrecedence( "CreateTaxas" ,  "CreateSecUser" );
         GXReorganization.SetMsg( 10 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Credito", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateCredito" ,  "CreateCliente" );
         ReorgExecute.RegisterPrecedence( "CreateCredito" ,  "CreateSecUser" );
         ReorgExecute.RegisterPrecedence( "CreateCredito" ,  "CreateSecUser" );
         GXReorganization.SetMsg( 11 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"NotaFiscalItem", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateNotaFiscalItem" ,  "CreateProposta" );
         ReorgExecute.RegisterPrecedence( "CreateNotaFiscalItem" ,  "CreateNotaFiscal" );
         GXReorganization.SetMsg( 12 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"NotaFiscal", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateNotaFiscal" ,  "CreateCliente" );
         ReorgExecute.RegisterPrecedence( "CreateNotaFiscal" ,  "CreateCliente" );
         GXReorganization.SetMsg( 13 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"ReembolsoFlowLog", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateReembolsoFlowLog" ,  "CreateWorkflowConvenio" );
         ReorgExecute.RegisterPrecedence( "CreateReembolsoFlowLog" ,  "CreateSecUser" );
         ReorgExecute.RegisterPrecedence( "CreateReembolsoFlowLog" ,  "CreateReembolso" );
         GXReorganization.SetMsg( 14 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"WorkflowConvenio", ""}) );
         GXReorganization.SetMsg( 15 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"ReembolsoPassos", ""}) );
         GXReorganization.SetMsg( 16 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"SerasaOcorrencias", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateSerasaOcorrencias" ,  "CreateSerasa" );
         GXReorganization.SetMsg( 17 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"SerasaEnderecos", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateSerasaEnderecos" ,  "CreateSerasa" );
         GXReorganization.SetMsg( 18 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"SerasaProtestos", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateSerasaProtestos" ,  "CreateSerasa" );
         GXReorganization.SetMsg( 19 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"SerasaAcoes", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateSerasaAcoes" ,  "CreateSerasa" );
         GXReorganization.SetMsg( 20 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"SerasaCheques", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateSerasaCheques" ,  "CreateSerasa" );
         GXReorganization.SetMsg( 21 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Serasa", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateSerasa" ,  "CreateCliente" );
         GXReorganization.SetMsg( 22 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"WebService", ""}) );
         GXReorganization.SetMsg( 23 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"ReembolsoParcelas", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateReembolsoParcelas" ,  "CreateReembolso" );
         GXReorganization.SetMsg( 24 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"ReembolsoAssinaturas", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateReembolsoAssinaturas" ,  "CreateReembolso" );
         ReorgExecute.RegisterPrecedence( "CreateReembolsoAssinaturas" ,  "CreatePropostaContratoAssinatura" );
         GXReorganization.SetMsg( 25 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"LogEmail", ""}) );
         GXReorganization.SetMsg( 26 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"ClienteDocumento", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateClienteDocumento" ,  "CreateCliente" );
         ReorgExecute.RegisterPrecedence( "CreateClienteDocumento" ,  "CreateDocumentos" );
         ReorgExecute.RegisterPrecedence( "CreateClienteDocumento" ,  "CreateSecUser" );
         GXReorganization.SetMsg( 27 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"PropostaContratoAssinatura", ""}) );
         ReorgExecute.RegisterPrecedence( "CreatePropostaContratoAssinatura" ,  "CreateProposta" );
         ReorgExecute.RegisterPrecedence( "CreatePropostaContratoAssinatura" ,  "CreateContrato" );
         ReorgExecute.RegisterPrecedence( "CreatePropostaContratoAssinatura" ,  "CreateAssinatura" );
         GXReorganization.SetMsg( 28 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"SecUserLog", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateSecUserLog" ,  "CreateSecUser" );
         GXReorganization.SetMsg( 29 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"AssinaturaParticipanteToken", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateAssinaturaParticipanteToken" ,  "CreateAssinaturaParticipante" );
         GXReorganization.SetMsg( 30 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"ClienteReponsavel", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateClienteReponsavel" ,  "CreateCliente" );
         ReorgExecute.RegisterPrecedence( "CreateClienteReponsavel" ,  "CreateCliente" );
         GXReorganization.SetMsg( 31 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"ReembolsoDocumento", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateReembolsoDocumento" ,  "CreateReembolsoEtapa" );
         ReorgExecute.RegisterPrecedence( "CreateReembolsoDocumento" ,  "CreateDocumentos" );
         GXReorganization.SetMsg( 32 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Etapa", ""}) );
         GXReorganization.SetMsg( 33 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"ReembolsoEtapa", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateReembolsoEtapa" ,  "CreateReembolso" );
         GXReorganization.SetMsg( 34 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Reembolso", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateReembolso" ,  "CreateWorkflowConvenio" );
         ReorgExecute.RegisterPrecedence( "CreateReembolso" ,  "CreateProposta" );
         ReorgExecute.RegisterPrecedence( "CreateReembolso" ,  "CreateSecUser" );
         GXReorganization.SetMsg( 35 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"ConvenioCategoria", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateConvenioCategoria" ,  "CreateConvenio" );
         GXReorganization.SetMsg( 36 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"ConfiguracaoNotificacoes", ""}) );
         GXReorganization.SetMsg( 37 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"ConfiguracoesTestemunhas", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateConfiguracoesTestemunhas" ,  "CreateSecUser" );
         GXReorganization.SetMsg( 38 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Especialidade", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateEspecialidade" ,  "CreateSecUser" );
         GXReorganization.SetMsg( 39 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Profissao", ""}) );
         GXReorganization.SetMsg( 40 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Nacionalidade", ""}) );
         GXReorganization.SetMsg( 41 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"CategoriaTitulo", ""}) );
         GXReorganization.SetMsg( 42 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Conta", ""}) );
         GXReorganization.SetMsg( 43 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"PropostaDocumentos", ""}) );
         ReorgExecute.RegisterPrecedence( "CreatePropostaDocumentos" ,  "CreateProposta" );
         ReorgExecute.RegisterPrecedence( "CreatePropostaDocumentos" ,  "CreateDocumentos" );
         GXReorganization.SetMsg( 44 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Convenio", ""}) );
         GXReorganization.SetMsg( 45 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Documentos", ""}) );
         GXReorganization.SetMsg( 46 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Banco", ""}) );
         GXReorganization.SetMsg( 47 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"EmailQueue", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateEmailQueue" ,  "CreateNotification" );
         GXReorganization.SetMsg( 48 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"UserNotification", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateUserNotification" ,  "CreateNotification" );
         ReorgExecute.RegisterPrecedence( "CreateUserNotification" ,  "CreateSecUser" );
         GXReorganization.SetMsg( 49 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Notification", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateNotification" ,  "CreateSecUser" );
         GXReorganization.SetMsg( 50 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Aprovadores", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateAprovadores" ,  "CreateSecUser" );
         GXReorganization.SetMsg( 51 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"ProcedimentosMedicos", ""}) );
         GXReorganization.SetMsg( 52 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Tags", ""}) );
         GXReorganization.SetMsg( 53 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"FilaProcessamento", ""}) );
         GXReorganization.SetMsg( 54 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Aprovacao", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateAprovacao" ,  "CreateProposta" );
         ReorgExecute.RegisterPrecedence( "CreateAprovacao" ,  "CreateAprovadores" );
         GXReorganization.SetMsg( 55 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"LimiteAprovacao", ""}) );
         GXReorganization.SetMsg( 56 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Proposta", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateProposta" ,  "CreateContrato" );
         ReorgExecute.RegisterPrecedence( "CreateProposta" ,  "CreateProcedimentosMedicos" );
         ReorgExecute.RegisterPrecedence( "CreateProposta" ,  "CreateConvenioCategoria" );
         ReorgExecute.RegisterPrecedence( "CreateProposta" ,  "CreateSecUser" );
         ReorgExecute.RegisterPrecedence( "CreateProposta" ,  "CreateCliente" );
         ReorgExecute.RegisterPrecedence( "CreateProposta" ,  "CreateCliente" );
         ReorgExecute.RegisterPrecedence( "CreateProposta" ,  "CreateCliente" );
         ReorgExecute.RegisterPrecedence( "CreateProposta" ,  "CreateCliente" );
         GXReorganization.SetMsg( 57 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Configuracoes", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateConfiguracoes" ,  "CreateLayoutContrato" );
         ReorgExecute.RegisterPrecedence( "CreateConfiguracoes" ,  "CreateLayoutContrato" );
         ReorgExecute.RegisterPrecedence( "CreateConfiguracoes" ,  "CreateLayoutContrato" );
         ReorgExecute.RegisterPrecedence( "CreateConfiguracoes" ,  "CreateLayoutContrato" );
         ReorgExecute.RegisterPrecedence( "CreateConfiguracoes" ,  "CreateLayoutContrato" );
         ReorgExecute.RegisterPrecedence( "CreateConfiguracoes" ,  "CreateCategoriaTitulo" );
         GXReorganization.SetMsg( 58 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Preferencias", ""}) );
         GXReorganization.SetMsg( 59 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"TipoPagamento", ""}) );
         GXReorganization.SetMsg( 60 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"TituloMovimento", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateTituloMovimento" ,  "CreateTipoPagamento" );
         ReorgExecute.RegisterPrecedence( "CreateTituloMovimento" ,  "CreateTitulo" );
         ReorgExecute.RegisterPrecedence( "CreateTituloMovimento" ,  "CreateConta" );
         GXReorganization.SetMsg( 61 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Titulo", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateTitulo" ,  "CreateConta" );
         ReorgExecute.RegisterPrecedence( "CreateTitulo" ,  "CreateCategoriaTitulo" );
         ReorgExecute.RegisterPrecedence( "CreateTitulo" ,  "CreateNotaFiscalParcelamento" );
         ReorgExecute.RegisterPrecedence( "CreateTitulo" ,  "CreateContaBancaria" );
         ReorgExecute.RegisterPrecedence( "CreateTitulo" ,  "CreateProposta" );
         ReorgExecute.RegisterPrecedence( "CreateTitulo" ,  "CreateCliente" );
         GXReorganization.SetMsg( 62 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"AssinaturaParticipanteNotificacao", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateAssinaturaParticipanteNotificacao" ,  "CreateAssinaturaParticipante" );
         GXReorganization.SetMsg( 63 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Empresa", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateEmpresa" ,  "CreateMunicipio" );
         ReorgExecute.RegisterPrecedence( "CreateEmpresa" ,  "CreateMunicipio" );
         ReorgExecute.RegisterPrecedence( "CreateEmpresa" ,  "CreateBanco" );
         ReorgExecute.RegisterPrecedence( "CreateEmpresa" ,  "CreateProfissao" );
         GXReorganization.SetMsg( 64 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"AssinaturaParticipante", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateAssinaturaParticipante" ,  "CreateAssinatura" );
         ReorgExecute.RegisterPrecedence( "CreateAssinaturaParticipante" ,  "CreateParticipante" );
         ReorgExecute.RegisterPrecedence( "CreateAssinaturaParticipante" ,  "CreateCliente" );
         GXReorganization.SetMsg( 65 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Assinatura", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateAssinatura" ,  "CreateContrato" );
         ReorgExecute.RegisterPrecedence( "CreateAssinatura" ,  "CreateArquivo" );
         ReorgExecute.RegisterPrecedence( "CreateAssinatura" ,  "CreateArquivo" );
         GXReorganization.SetMsg( 66 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"ContratoParticipante", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateContratoParticipante" ,  "CreateContrato" );
         ReorgExecute.RegisterPrecedence( "CreateContratoParticipante" ,  "CreateParticipante" );
         GXReorganization.SetMsg( 67 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Participante", ""}) );
         GXReorganization.SetMsg( 68 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Arquivo", ""}) );
         GXReorganization.SetMsg( 69 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Contrato", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateContrato" ,  "CreateCliente" );
         GXReorganization.SetMsg( 70 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Financiamento", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateFinanciamento" ,  "CreateCliente" );
         ReorgExecute.RegisterPrecedence( "CreateFinanciamento" ,  "CreateCliente" );
         GXReorganization.SetMsg( 71 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"TemporaryCode", ""}) );
         GXReorganization.SetMsg( 72 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"TipoCliente", ""}) );
         GXReorganization.SetMsg( 73 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Municipio", ""}) );
         GXReorganization.SetMsg( 74 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"CEP", ""}) );
         GXReorganization.SetMsg( 75 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Cliente", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateCliente" ,  "CreateTipoCliente" );
         ReorgExecute.RegisterPrecedence( "CreateCliente" ,  "CreateMunicipio" );
         ReorgExecute.RegisterPrecedence( "CreateCliente" ,  "CreateMunicipio" );
         ReorgExecute.RegisterPrecedence( "CreateCliente" ,  "CreateBanco" );
         ReorgExecute.RegisterPrecedence( "CreateCliente" ,  "CreateEspecialidade" );
         ReorgExecute.RegisterPrecedence( "CreateCliente" ,  "CreateNacionalidade" );
         ReorgExecute.RegisterPrecedence( "CreateCliente" ,  "CreateNacionalidade" );
         ReorgExecute.RegisterPrecedence( "CreateCliente" ,  "CreateProfissao" );
         ReorgExecute.RegisterPrecedence( "CreateCliente" ,  "CreateProfissao" );
         ReorgExecute.RegisterPrecedence( "CreateCliente" ,  "CreateConvenio" );
         GXReorganization.SetMsg( 76 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"SecUserToken", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateSecUserToken" ,  "CreateSecUser" );
         GXReorganization.SetMsg( 77 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"ServidorSMTP", ""}) );
         GXReorganization.SetMsg( 78 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"LayoutContrato", ""}) );
         GXReorganization.SetMsg( 79 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Person", ""}) );
         GXReorganization.SetMsg( 80 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"SecUserRole", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateSecUserRole" ,  "CreateSecUser" );
         ReorgExecute.RegisterPrecedence( "CreateSecUserRole" ,  "CreateSecRole" );
         GXReorganization.SetMsg( 81 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"SecUser", ""}) );
         GXReorganization.SetMsg( 82 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"SecRole", ""}) );
         GXReorganization.SetMsg( 83 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"SecObjectFunctionalities", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateSecObjectFunctionalities" ,  "CreateSecObject" );
         ReorgExecute.RegisterPrecedence( "CreateSecObjectFunctionalities" ,  "CreateSecFunctionality" );
         GXReorganization.SetMsg( 84 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"SecObject", ""}) );
         GXReorganization.SetMsg( 85 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"SecFunctionalityRole", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateSecFunctionalityRole" ,  "CreateSecFunctionality" );
         ReorgExecute.RegisterPrecedence( "CreateSecFunctionalityRole" ,  "CreateSecRole" );
         GXReorganization.SetMsg( 86 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"SecFunctionality", ""}) );
         GXReorganization.SetMsg( 87 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"WWP_FormInstanceElement", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateWWP_FormInstanceElement" ,  "CreateWWP_FormInstance" );
         GXReorganization.SetMsg( 88 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"WWP_FormInstance", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateWWP_FormInstance" ,  "CreateWWP_Form" );
         GXReorganization.SetMsg( 89 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"WWP_FormElement", ""}) );
         GXReorganization.SetMsg( 90 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"WWP_Form", ""}) );
         GXReorganization.SetMsg( 91 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"WWP_MailAttachments", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateWWP_MailAttachments" ,  "CreateWWP_Mail" );
         GXReorganization.SetMsg( 92 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"WWP_Mail", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateWWP_Mail" ,  "CreateWWP_Notification" );
         GXReorganization.SetMsg( 93 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"WWP_MailTemplate", ""}) );
         GXReorganization.SetMsg( 94 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"WWP_Notification", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateWWP_Notification" ,  "CreateWWP_NotificationDefinition" );
         ReorgExecute.RegisterPrecedence( "CreateWWP_Notification" ,  "CreateWWP_UserExtended" );
         GXReorganization.SetMsg( 95 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"WWP_NotificationDefinition", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateWWP_NotificationDefinition" ,  "CreateWWP_Entity" );
         GXReorganization.SetMsg( 96 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"WWP_WebClient", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateWWP_WebClient" ,  "CreateWWP_UserExtended" );
         GXReorganization.SetMsg( 97 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"WWP_WebNotification", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateWWP_WebNotification" ,  "CreateWWP_Notification" );
         GXReorganization.SetMsg( 98 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"WWP_SMS", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateWWP_SMS" ,  "CreateWWP_Notification" );
         GXReorganization.SetMsg( 99 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"WWP_Subscription", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateWWP_Subscription" ,  "CreateWWP_NotificationDefinition" );
         ReorgExecute.RegisterPrecedence( "CreateWWP_Subscription" ,  "CreateWWP_UserExtended" );
         GXReorganization.SetMsg( 100 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"WWP_Entity", ""}) );
         GXReorganization.SetMsg( 101 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"WWP_Parameter", ""}) );
         GXReorganization.SetMsg( 102 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"WWP_UserExtended", ""}) );
      }

      private void SetPrecedenceris( )
      {
         GXReorganization.SetMsg( 103 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IWWP_SUBSCRIPTION2"}) );
         ReorgExecute.RegisterPrecedence( "RIWWP_SubscriptionWWP_NotificationDefinition" ,  "CreateWWP_Subscription" );
         ReorgExecute.RegisterPrecedence( "RIWWP_SubscriptionWWP_NotificationDefinition" ,  "CreateWWP_NotificationDefinition" );
         GXReorganization.SetMsg( 104 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IWWP_SUBSCRIPTION1"}) );
         ReorgExecute.RegisterPrecedence( "RIWWP_SubscriptionWWP_UserExtended" ,  "CreateWWP_Subscription" );
         ReorgExecute.RegisterPrecedence( "RIWWP_SubscriptionWWP_UserExtended" ,  "CreateWWP_UserExtended" );
         GXReorganization.SetMsg( 105 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IWWP_SMS1"}) );
         ReorgExecute.RegisterPrecedence( "RIWWP_SMSWWP_Notification" ,  "CreateWWP_SMS" );
         ReorgExecute.RegisterPrecedence( "RIWWP_SMSWWP_Notification" ,  "CreateWWP_Notification" );
         GXReorganization.SetMsg( 106 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IWWP_WEBNOTIFICATION1"}) );
         ReorgExecute.RegisterPrecedence( "RIWWP_WebNotificationWWP_Notification" ,  "CreateWWP_WebNotification" );
         ReorgExecute.RegisterPrecedence( "RIWWP_WebNotificationWWP_Notification" ,  "CreateWWP_Notification" );
         GXReorganization.SetMsg( 107 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IWWP_WEBCLIENT1"}) );
         ReorgExecute.RegisterPrecedence( "RIWWP_WebClientWWP_UserExtended" ,  "CreateWWP_WebClient" );
         ReorgExecute.RegisterPrecedence( "RIWWP_WebClientWWP_UserExtended" ,  "CreateWWP_UserExtended" );
         GXReorganization.SetMsg( 108 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IWWP_NOTIFICATIONDEFINITION1"}) );
         ReorgExecute.RegisterPrecedence( "RIWWP_NotificationDefinitionWWP_Entity" ,  "CreateWWP_NotificationDefinition" );
         ReorgExecute.RegisterPrecedence( "RIWWP_NotificationDefinitionWWP_Entity" ,  "CreateWWP_Entity" );
         GXReorganization.SetMsg( 109 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IWWP_NOTIFICATION2"}) );
         ReorgExecute.RegisterPrecedence( "RIWWP_NotificationWWP_NotificationDefinition" ,  "CreateWWP_Notification" );
         ReorgExecute.RegisterPrecedence( "RIWWP_NotificationWWP_NotificationDefinition" ,  "CreateWWP_NotificationDefinition" );
         GXReorganization.SetMsg( 110 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IWWP_NOTIFICATION1"}) );
         ReorgExecute.RegisterPrecedence( "RIWWP_NotificationWWP_UserExtended" ,  "CreateWWP_Notification" );
         ReorgExecute.RegisterPrecedence( "RIWWP_NotificationWWP_UserExtended" ,  "CreateWWP_UserExtended" );
         GXReorganization.SetMsg( 111 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IWWP_MAIL1"}) );
         ReorgExecute.RegisterPrecedence( "RIWWP_MailWWP_Notification" ,  "CreateWWP_Mail" );
         ReorgExecute.RegisterPrecedence( "RIWWP_MailWWP_Notification" ,  "CreateWWP_Notification" );
         GXReorganization.SetMsg( 112 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IWWP_MAILATTACHMENTS1"}) );
         ReorgExecute.RegisterPrecedence( "RIWWP_MailAttachmentsWWP_Mail" ,  "CreateWWP_MailAttachments" );
         ReorgExecute.RegisterPrecedence( "RIWWP_MailAttachmentsWWP_Mail" ,  "CreateWWP_Mail" );
         GXReorganization.SetMsg( 113 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IWWPFORMELEMENT1"}) );
         ReorgExecute.RegisterPrecedence( "RIWWP_FormElementWWP_FormElement" ,  "CreateWWP_FormElement" );
         ReorgExecute.RegisterPrecedence( "RIWWP_FormElementWWP_FormElement" ,  "CreateWWP_FormElement" );
         GXReorganization.SetMsg( 114 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IWWPFORMINSTANCE1"}) );
         ReorgExecute.RegisterPrecedence( "RIWWP_FormInstanceWWP_Form" ,  "CreateWWP_FormInstance" );
         ReorgExecute.RegisterPrecedence( "RIWWP_FormInstanceWWP_Form" ,  "CreateWWP_Form" );
         GXReorganization.SetMsg( 115 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IWWPFORMINSTANCEELEMENT1"}) );
         ReorgExecute.RegisterPrecedence( "RIWWP_FormInstanceElementWWP_FormInstance" ,  "CreateWWP_FormInstanceElement" );
         ReorgExecute.RegisterPrecedence( "RIWWP_FormInstanceElementWWP_FormInstance" ,  "CreateWWP_FormInstance" );
         GXReorganization.SetMsg( 116 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ISECFUNCTIONALITY1"}) );
         ReorgExecute.RegisterPrecedence( "RISecFunctionalitySecFunctionality" ,  "CreateSecFunctionality" );
         ReorgExecute.RegisterPrecedence( "RISecFunctionalitySecFunctionality" ,  "CreateSecFunctionality" );
         GXReorganization.SetMsg( 117 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ISECFUNCTIONALITYROL1"}) );
         ReorgExecute.RegisterPrecedence( "RISecFunctionalityRoleSecFunctionality" ,  "CreateSecFunctionalityRole" );
         ReorgExecute.RegisterPrecedence( "RISecFunctionalityRoleSecFunctionality" ,  "CreateSecFunctionality" );
         GXReorganization.SetMsg( 118 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ISECFUNCTIONALITYROL2"}) );
         ReorgExecute.RegisterPrecedence( "RISecFunctionalityRoleSecRole" ,  "CreateSecFunctionalityRole" );
         ReorgExecute.RegisterPrecedence( "RISecFunctionalityRoleSecRole" ,  "CreateSecRole" );
         GXReorganization.SetMsg( 119 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ISECOBJECTFUNCTIONALITIES2"}) );
         ReorgExecute.RegisterPrecedence( "RISecObjectFunctionalitiesSecObject" ,  "CreateSecObjectFunctionalities" );
         ReorgExecute.RegisterPrecedence( "RISecObjectFunctionalitiesSecObject" ,  "CreateSecObject" );
         GXReorganization.SetMsg( 120 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ISECOBJECTFUNCTIONALITIES1"}) );
         ReorgExecute.RegisterPrecedence( "RISecObjectFunctionalitiesSecFunctionality" ,  "CreateSecObjectFunctionalities" );
         ReorgExecute.RegisterPrecedence( "RISecObjectFunctionalitiesSecFunctionality" ,  "CreateSecFunctionality" );
         GXReorganization.SetMsg( 121 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ISECUSER3"}) );
         ReorgExecute.RegisterPrecedence( "RISecUserCliente" ,  "CreateSecUser" );
         ReorgExecute.RegisterPrecedence( "RISecUserCliente" ,  "CreateCliente" );
         GXReorganization.SetMsg( 122 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ISECUSER2"}) );
         ReorgExecute.RegisterPrecedence( "RISecUserSecUser" ,  "CreateSecUser" );
         ReorgExecute.RegisterPrecedence( "RISecUserSecUser" ,  "CreateSecUser" );
         GXReorganization.SetMsg( 123 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ISECUSER1"}) );
         ReorgExecute.RegisterPrecedence( "RISecUserSecUser1" ,  "CreateSecUser" );
         ReorgExecute.RegisterPrecedence( "RISecUserSecUser1" ,  "CreateSecUser" );
         GXReorganization.SetMsg( 124 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ISECUSERROLE2"}) );
         ReorgExecute.RegisterPrecedence( "RISecUserRoleSecUser" ,  "CreateSecUserRole" );
         ReorgExecute.RegisterPrecedence( "RISecUserRoleSecUser" ,  "CreateSecUser" );
         GXReorganization.SetMsg( 125 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ISECUSERROLE1"}) );
         ReorgExecute.RegisterPrecedence( "RISecUserRoleSecRole" ,  "CreateSecUserRole" );
         ReorgExecute.RegisterPrecedence( "RISecUserRoleSecRole" ,  "CreateSecRole" );
         GXReorganization.SetMsg( 126 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ISECUSERUID1"}) );
         ReorgExecute.RegisterPrecedence( "RISecUserTokenSecUser" ,  "CreateSecUserToken" );
         ReorgExecute.RegisterPrecedence( "RISecUserTokenSecUser" ,  "CreateSecUser" );
         GXReorganization.SetMsg( 127 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ICLIENTE2"}) );
         ReorgExecute.RegisterPrecedence( "RIClienteTipoCliente" ,  "CreateCliente" );
         ReorgExecute.RegisterPrecedence( "RIClienteTipoCliente" ,  "CreateTipoCliente" );
         GXReorganization.SetMsg( 128 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ICLIENTE7"}) );
         ReorgExecute.RegisterPrecedence( "RIClienteMunicipio" ,  "CreateCliente" );
         ReorgExecute.RegisterPrecedence( "RIClienteMunicipio" ,  "CreateMunicipio" );
         GXReorganization.SetMsg( 129 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ICLIENTE3"}) );
         ReorgExecute.RegisterPrecedence( "RIClienteMunicipio1" ,  "CreateCliente" );
         ReorgExecute.RegisterPrecedence( "RIClienteMunicipio1" ,  "CreateMunicipio" );
         GXReorganization.SetMsg( 130 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ICLIENTE4"}) );
         ReorgExecute.RegisterPrecedence( "RIClienteBanco" ,  "CreateCliente" );
         ReorgExecute.RegisterPrecedence( "RIClienteBanco" ,  "CreateBanco" );
         GXReorganization.SetMsg( 131 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ICLIENTE8"}) );
         ReorgExecute.RegisterPrecedence( "RIClienteEspecialidade" ,  "CreateCliente" );
         ReorgExecute.RegisterPrecedence( "RIClienteEspecialidade" ,  "CreateEspecialidade" );
         GXReorganization.SetMsg( 132 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ICLIENTE9"}) );
         ReorgExecute.RegisterPrecedence( "RIClienteNacionalidade" ,  "CreateCliente" );
         ReorgExecute.RegisterPrecedence( "RIClienteNacionalidade" ,  "CreateNacionalidade" );
         GXReorganization.SetMsg( 133 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ICLIENTE5"}) );
         ReorgExecute.RegisterPrecedence( "RIClienteNacionalidade1" ,  "CreateCliente" );
         ReorgExecute.RegisterPrecedence( "RIClienteNacionalidade1" ,  "CreateNacionalidade" );
         GXReorganization.SetMsg( 134 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ICLIENTE10"}) );
         ReorgExecute.RegisterPrecedence( "RIClienteProfissao" ,  "CreateCliente" );
         ReorgExecute.RegisterPrecedence( "RIClienteProfissao" ,  "CreateProfissao" );
         GXReorganization.SetMsg( 135 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ICLIENTE6"}) );
         ReorgExecute.RegisterPrecedence( "RIClienteProfissao1" ,  "CreateCliente" );
         ReorgExecute.RegisterPrecedence( "RIClienteProfissao1" ,  "CreateProfissao" );
         GXReorganization.SetMsg( 136 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ICLIENTE11"}) );
         ReorgExecute.RegisterPrecedence( "RIClienteConvenio" ,  "CreateCliente" );
         ReorgExecute.RegisterPrecedence( "RIClienteConvenio" ,  "CreateConvenio" );
         GXReorganization.SetMsg( 137 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IFINANCIAMENTO2"}) );
         ReorgExecute.RegisterPrecedence( "RIFinanciamentoCliente" ,  "CreateFinanciamento" );
         ReorgExecute.RegisterPrecedence( "RIFinanciamentoCliente" ,  "CreateCliente" );
         GXReorganization.SetMsg( 138 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IFINANCIAMENTO1"}) );
         ReorgExecute.RegisterPrecedence( "RIFinanciamentoCliente1" ,  "CreateFinanciamento" );
         ReorgExecute.RegisterPrecedence( "RIFinanciamentoCliente1" ,  "CreateCliente" );
         GXReorganization.SetMsg( 139 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ICONTRATO1"}) );
         ReorgExecute.RegisterPrecedence( "RIContratoCliente" ,  "CreateContrato" );
         ReorgExecute.RegisterPrecedence( "RIContratoCliente" ,  "CreateCliente" );
         GXReorganization.SetMsg( 140 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ICONTRATO2"}) );
         ReorgExecute.RegisterPrecedence( "RIContratoProposta" ,  "CreateContrato" );
         ReorgExecute.RegisterPrecedence( "RIContratoProposta" ,  "CreateProposta" );
         GXReorganization.SetMsg( 141 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ICONTRATOPARTICIPANTE2"}) );
         ReorgExecute.RegisterPrecedence( "RIContratoParticipanteContrato" ,  "CreateContratoParticipante" );
         ReorgExecute.RegisterPrecedence( "RIContratoParticipanteContrato" ,  "CreateContrato" );
         GXReorganization.SetMsg( 142 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ICONTRATOPARTICIPANTE1"}) );
         ReorgExecute.RegisterPrecedence( "RIContratoParticipanteParticipante" ,  "CreateContratoParticipante" );
         ReorgExecute.RegisterPrecedence( "RIContratoParticipanteParticipante" ,  "CreateParticipante" );
         GXReorganization.SetMsg( 143 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IASSINATURA1"}) );
         ReorgExecute.RegisterPrecedence( "RIAssinaturaContrato" ,  "CreateAssinatura" );
         ReorgExecute.RegisterPrecedence( "RIAssinaturaContrato" ,  "CreateContrato" );
         GXReorganization.SetMsg( 144 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IASSINATURA3"}) );
         ReorgExecute.RegisterPrecedence( "RIAssinaturaArquivo" ,  "CreateAssinatura" );
         ReorgExecute.RegisterPrecedence( "RIAssinaturaArquivo" ,  "CreateArquivo" );
         GXReorganization.SetMsg( 145 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IASSINATURA2"}) );
         ReorgExecute.RegisterPrecedence( "RIAssinaturaArquivo1" ,  "CreateAssinatura" );
         ReorgExecute.RegisterPrecedence( "RIAssinaturaArquivo1" ,  "CreateArquivo" );
         GXReorganization.SetMsg( 146 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IASSINATURAPARTICIPANTE2"}) );
         ReorgExecute.RegisterPrecedence( "RIAssinaturaParticipanteAssinatura" ,  "CreateAssinaturaParticipante" );
         ReorgExecute.RegisterPrecedence( "RIAssinaturaParticipanteAssinatura" ,  "CreateAssinatura" );
         GXReorganization.SetMsg( 147 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IASSINATURAPARTICIPANTE1"}) );
         ReorgExecute.RegisterPrecedence( "RIAssinaturaParticipanteParticipante" ,  "CreateAssinaturaParticipante" );
         ReorgExecute.RegisterPrecedence( "RIAssinaturaParticipanteParticipante" ,  "CreateParticipante" );
         GXReorganization.SetMsg( 148 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IASSINATURAPARTICIPANTE3"}) );
         ReorgExecute.RegisterPrecedence( "RIAssinaturaParticipanteCliente" ,  "CreateAssinaturaParticipante" );
         ReorgExecute.RegisterPrecedence( "RIAssinaturaParticipanteCliente" ,  "CreateCliente" );
         GXReorganization.SetMsg( 149 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IEMPRESA4"}) );
         ReorgExecute.RegisterPrecedence( "RIEmpresaMunicipio" ,  "CreateEmpresa" );
         ReorgExecute.RegisterPrecedence( "RIEmpresaMunicipio" ,  "CreateMunicipio" );
         GXReorganization.SetMsg( 150 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IEMPRESA3"}) );
         ReorgExecute.RegisterPrecedence( "RIEmpresaMunicipio1" ,  "CreateEmpresa" );
         ReorgExecute.RegisterPrecedence( "RIEmpresaMunicipio1" ,  "CreateMunicipio" );
         GXReorganization.SetMsg( 151 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IEMPRESA1"}) );
         ReorgExecute.RegisterPrecedence( "RIEmpresaBanco" ,  "CreateEmpresa" );
         ReorgExecute.RegisterPrecedence( "RIEmpresaBanco" ,  "CreateBanco" );
         GXReorganization.SetMsg( 152 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IEMPRESA2"}) );
         ReorgExecute.RegisterPrecedence( "RIEmpresaProfissao" ,  "CreateEmpresa" );
         ReorgExecute.RegisterPrecedence( "RIEmpresaProfissao" ,  "CreateProfissao" );
         GXReorganization.SetMsg( 153 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IASSINATURAPARTICIPANTENOTIFICACAO1"}) );
         ReorgExecute.RegisterPrecedence( "RIAssinaturaParticipanteNotificacaoAssinaturaParticipante" ,  "CreateAssinaturaParticipanteNotificacao" );
         ReorgExecute.RegisterPrecedence( "RIAssinaturaParticipanteNotificacaoAssinaturaParticipante" ,  "CreateAssinaturaParticipante" );
         GXReorganization.SetMsg( 154 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITITULO3"}) );
         ReorgExecute.RegisterPrecedence( "RITituloConta" ,  "CreateTitulo" );
         ReorgExecute.RegisterPrecedence( "RITituloConta" ,  "CreateConta" );
         GXReorganization.SetMsg( 155 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITITULO2"}) );
         ReorgExecute.RegisterPrecedence( "RITituloCategoriaTitulo" ,  "CreateTitulo" );
         ReorgExecute.RegisterPrecedence( "RITituloCategoriaTitulo" ,  "CreateCategoriaTitulo" );
         GXReorganization.SetMsg( 156 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITITULO4"}) );
         ReorgExecute.RegisterPrecedence( "RITituloNotaFiscalParcelamento" ,  "CreateTitulo" );
         ReorgExecute.RegisterPrecedence( "RITituloNotaFiscalParcelamento" ,  "CreateNotaFiscalParcelamento" );
         GXReorganization.SetMsg( 157 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITITULO5"}) );
         ReorgExecute.RegisterPrecedence( "RITituloContaBancaria" ,  "CreateTitulo" );
         ReorgExecute.RegisterPrecedence( "RITituloContaBancaria" ,  "CreateContaBancaria" );
         GXReorganization.SetMsg( 158 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITITULO1"}) );
         ReorgExecute.RegisterPrecedence( "RITituloProposta" ,  "CreateTitulo" );
         ReorgExecute.RegisterPrecedence( "RITituloProposta" ,  "CreateProposta" );
         GXReorganization.SetMsg( 159 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITITULO6"}) );
         ReorgExecute.RegisterPrecedence( "RITituloCliente" ,  "CreateTitulo" );
         ReorgExecute.RegisterPrecedence( "RITituloCliente" ,  "CreateCliente" );
         GXReorganization.SetMsg( 160 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITITULOMOVIMENTO2"}) );
         ReorgExecute.RegisterPrecedence( "RITituloMovimentoTipoPagamento" ,  "CreateTituloMovimento" );
         ReorgExecute.RegisterPrecedence( "RITituloMovimentoTipoPagamento" ,  "CreateTipoPagamento" );
         GXReorganization.SetMsg( 161 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITITULOMOVIMENTO1"}) );
         ReorgExecute.RegisterPrecedence( "RITituloMovimentoTitulo" ,  "CreateTituloMovimento" );
         ReorgExecute.RegisterPrecedence( "RITituloMovimentoTitulo" ,  "CreateTitulo" );
         GXReorganization.SetMsg( 162 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITITULOMOVIMENTO3"}) );
         ReorgExecute.RegisterPrecedence( "RITituloMovimentoConta" ,  "CreateTituloMovimento" );
         ReorgExecute.RegisterPrecedence( "RITituloMovimentoConta" ,  "CreateConta" );
         GXReorganization.SetMsg( 163 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ICONFIGURACOES4"}) );
         ReorgExecute.RegisterPrecedence( "RIConfiguracoesLayoutContrato1" ,  "CreateConfiguracoes" );
         ReorgExecute.RegisterPrecedence( "RIConfiguracoesLayoutContrato1" ,  "CreateLayoutContrato" );
         GXReorganization.SetMsg( 164 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ICONFIGURACOES3"}) );
         ReorgExecute.RegisterPrecedence( "RIConfiguracoesLayoutContrato2" ,  "CreateConfiguracoes" );
         ReorgExecute.RegisterPrecedence( "RIConfiguracoesLayoutContrato2" ,  "CreateLayoutContrato" );
         GXReorganization.SetMsg( 165 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ICONFIGURACOES2"}) );
         ReorgExecute.RegisterPrecedence( "RIConfiguracoesLayoutContrato3" ,  "CreateConfiguracoes" );
         ReorgExecute.RegisterPrecedence( "RIConfiguracoesLayoutContrato3" ,  "CreateLayoutContrato" );
         GXReorganization.SetMsg( 166 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ICONFIGURACOES6"}) );
         ReorgExecute.RegisterPrecedence( "RIConfiguracoesLayoutContrato" ,  "CreateConfiguracoes" );
         ReorgExecute.RegisterPrecedence( "RIConfiguracoesLayoutContrato" ,  "CreateLayoutContrato" );
         GXReorganization.SetMsg( 167 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ICONFIGURACOES1"}) );
         ReorgExecute.RegisterPrecedence( "RIConfiguracoesLayoutContrato4" ,  "CreateConfiguracoes" );
         ReorgExecute.RegisterPrecedence( "RIConfiguracoesLayoutContrato4" ,  "CreateLayoutContrato" );
         GXReorganization.SetMsg( 168 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ICONFIGURACOES5"}) );
         ReorgExecute.RegisterPrecedence( "RIConfiguracoesCategoriaTitulo" ,  "CreateConfiguracoes" );
         ReorgExecute.RegisterPrecedence( "RIConfiguracoesCategoriaTitulo" ,  "CreateCategoriaTitulo" );
         GXReorganization.SetMsg( 169 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IPROPOSTA1"}) );
         ReorgExecute.RegisterPrecedence( "RIPropostaContrato" ,  "CreateProposta" );
         ReorgExecute.RegisterPrecedence( "RIPropostaContrato" ,  "CreateContrato" );
         GXReorganization.SetMsg( 170 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IPROPOSTA4"}) );
         ReorgExecute.RegisterPrecedence( "RIPropostaProcedimentosMedicos" ,  "CreateProposta" );
         ReorgExecute.RegisterPrecedence( "RIPropostaProcedimentosMedicos" ,  "CreateProcedimentosMedicos" );
         GXReorganization.SetMsg( 171 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IPROPOSTA5"}) );
         ReorgExecute.RegisterPrecedence( "RIPropostaConvenioCategoria" ,  "CreateProposta" );
         ReorgExecute.RegisterPrecedence( "RIPropostaConvenioCategoria" ,  "CreateConvenioCategoria" );
         GXReorganization.SetMsg( 172 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IPROPOSTA2"}) );
         ReorgExecute.RegisterPrecedence( "RIPropostaSecUser" ,  "CreateProposta" );
         ReorgExecute.RegisterPrecedence( "RIPropostaSecUser" ,  "CreateSecUser" );
         GXReorganization.SetMsg( 173 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IPROPOSTA7"}) );
         ReorgExecute.RegisterPrecedence( "RIPropostaCliente1" ,  "CreateProposta" );
         ReorgExecute.RegisterPrecedence( "RIPropostaCliente1" ,  "CreateCliente" );
         GXReorganization.SetMsg( 174 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IPROPOSTA3"}) );
         ReorgExecute.RegisterPrecedence( "RIPropostaCliente2" ,  "CreateProposta" );
         ReorgExecute.RegisterPrecedence( "RIPropostaCliente2" ,  "CreateCliente" );
         GXReorganization.SetMsg( 175 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IPROPOSTA8"}) );
         ReorgExecute.RegisterPrecedence( "RIPropostaCliente" ,  "CreateProposta" );
         ReorgExecute.RegisterPrecedence( "RIPropostaCliente" ,  "CreateCliente" );
         GXReorganization.SetMsg( 176 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IPROPOSTA6"}) );
         ReorgExecute.RegisterPrecedence( "RIPropostaCliente3" ,  "CreateProposta" );
         ReorgExecute.RegisterPrecedence( "RIPropostaCliente3" ,  "CreateCliente" );
         GXReorganization.SetMsg( 177 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IAPROVACAO1"}) );
         ReorgExecute.RegisterPrecedence( "RIAprovacaoProposta" ,  "CreateAprovacao" );
         ReorgExecute.RegisterPrecedence( "RIAprovacaoProposta" ,  "CreateProposta" );
         GXReorganization.SetMsg( 178 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IAPROVACAO2"}) );
         ReorgExecute.RegisterPrecedence( "RIAprovacaoAprovadores" ,  "CreateAprovacao" );
         ReorgExecute.RegisterPrecedence( "RIAprovacaoAprovadores" ,  "CreateAprovadores" );
         GXReorganization.SetMsg( 179 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IAPROVADORES1"}) );
         ReorgExecute.RegisterPrecedence( "RIAprovadoresSecUser" ,  "CreateAprovadores" );
         ReorgExecute.RegisterPrecedence( "RIAprovadoresSecUser" ,  "CreateSecUser" );
         GXReorganization.SetMsg( 180 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"INOTIFICATION1"}) );
         ReorgExecute.RegisterPrecedence( "RINotificationSecUser" ,  "CreateNotification" );
         ReorgExecute.RegisterPrecedence( "RINotificationSecUser" ,  "CreateSecUser" );
         GXReorganization.SetMsg( 181 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IUSERNOTIFICATION1"}) );
         ReorgExecute.RegisterPrecedence( "RIUserNotificationNotification" ,  "CreateUserNotification" );
         ReorgExecute.RegisterPrecedence( "RIUserNotificationNotification" ,  "CreateNotification" );
         GXReorganization.SetMsg( 182 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IUSERNOTIFICATION2"}) );
         ReorgExecute.RegisterPrecedence( "RIUserNotificationSecUser" ,  "CreateUserNotification" );
         ReorgExecute.RegisterPrecedence( "RIUserNotificationSecUser" ,  "CreateSecUser" );
         GXReorganization.SetMsg( 183 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IEMAILQUEUE1"}) );
         ReorgExecute.RegisterPrecedence( "RIEmailQueueNotification" ,  "CreateEmailQueue" );
         ReorgExecute.RegisterPrecedence( "RIEmailQueueNotification" ,  "CreateNotification" );
         GXReorganization.SetMsg( 184 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IPROPOSTADOCUMENTOS2"}) );
         ReorgExecute.RegisterPrecedence( "RIPropostaDocumentosProposta" ,  "CreatePropostaDocumentos" );
         ReorgExecute.RegisterPrecedence( "RIPropostaDocumentosProposta" ,  "CreateProposta" );
         GXReorganization.SetMsg( 185 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IPROPOSTADOCUMENTOS1"}) );
         ReorgExecute.RegisterPrecedence( "RIPropostaDocumentosDocumentos" ,  "CreatePropostaDocumentos" );
         ReorgExecute.RegisterPrecedence( "RIPropostaDocumentosDocumentos" ,  "CreateDocumentos" );
         GXReorganization.SetMsg( 186 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IESPECIALIDADE1"}) );
         ReorgExecute.RegisterPrecedence( "RIEspecialidadeSecUser" ,  "CreateEspecialidade" );
         ReorgExecute.RegisterPrecedence( "RIEspecialidadeSecUser" ,  "CreateSecUser" );
         GXReorganization.SetMsg( 187 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ICONFIGURACOESTESTEMUNHAS1"}) );
         ReorgExecute.RegisterPrecedence( "RIConfiguracoesTestemunhasSecUser" ,  "CreateConfiguracoesTestemunhas" );
         ReorgExecute.RegisterPrecedence( "RIConfiguracoesTestemunhasSecUser" ,  "CreateSecUser" );
         GXReorganization.SetMsg( 188 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ICONVENIOCATEGORIA1"}) );
         ReorgExecute.RegisterPrecedence( "RIConvenioCategoriaConvenio" ,  "CreateConvenioCategoria" );
         ReorgExecute.RegisterPrecedence( "RIConvenioCategoriaConvenio" ,  "CreateConvenio" );
         GXReorganization.SetMsg( 189 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IREEMBOLSO3"}) );
         ReorgExecute.RegisterPrecedence( "RIReembolsoWorkflowConvenio" ,  "CreateReembolso" );
         ReorgExecute.RegisterPrecedence( "RIReembolsoWorkflowConvenio" ,  "CreateWorkflowConvenio" );
         GXReorganization.SetMsg( 190 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IREEMBOLSO1"}) );
         ReorgExecute.RegisterPrecedence( "RIReembolsoProposta" ,  "CreateReembolso" );
         ReorgExecute.RegisterPrecedence( "RIReembolsoProposta" ,  "CreateProposta" );
         GXReorganization.SetMsg( 191 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IREEMBOLSO2"}) );
         ReorgExecute.RegisterPrecedence( "RIReembolsoSecUser" ,  "CreateReembolso" );
         ReorgExecute.RegisterPrecedence( "RIReembolsoSecUser" ,  "CreateSecUser" );
         GXReorganization.SetMsg( 192 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IREEMBOLSOETAPA1"}) );
         ReorgExecute.RegisterPrecedence( "RIReembolsoEtapaReembolso" ,  "CreateReembolsoEtapa" );
         ReorgExecute.RegisterPrecedence( "RIReembolsoEtapaReembolso" ,  "CreateReembolso" );
         GXReorganization.SetMsg( 193 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IREEMBOLSODOCUMENTO2"}) );
         ReorgExecute.RegisterPrecedence( "RIReembolsoDocumentoReembolsoEtapa" ,  "CreateReembolsoDocumento" );
         ReorgExecute.RegisterPrecedence( "RIReembolsoDocumentoReembolsoEtapa" ,  "CreateReembolsoEtapa" );
         GXReorganization.SetMsg( 194 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IREEMBOLSODOCUMENTO1"}) );
         ReorgExecute.RegisterPrecedence( "RIReembolsoDocumentoDocumentos" ,  "CreateReembolsoDocumento" );
         ReorgExecute.RegisterPrecedence( "RIReembolsoDocumentoDocumentos" ,  "CreateDocumentos" );
         GXReorganization.SetMsg( 195 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ICLIENTEREPONSAVEL2"}) );
         ReorgExecute.RegisterPrecedence( "RIClienteReponsavelCliente" ,  "CreateClienteReponsavel" );
         ReorgExecute.RegisterPrecedence( "RIClienteReponsavelCliente" ,  "CreateCliente" );
         GXReorganization.SetMsg( 196 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ICLIENTEREPONSAVEL1"}) );
         ReorgExecute.RegisterPrecedence( "RIClienteReponsavelCliente1" ,  "CreateClienteReponsavel" );
         ReorgExecute.RegisterPrecedence( "RIClienteReponsavelCliente1" ,  "CreateCliente" );
         GXReorganization.SetMsg( 197 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IASSINATURAPARTICIPANTETOKEN1"}) );
         ReorgExecute.RegisterPrecedence( "RIAssinaturaParticipanteTokenAssinaturaParticipante" ,  "CreateAssinaturaParticipanteToken" );
         ReorgExecute.RegisterPrecedence( "RIAssinaturaParticipanteTokenAssinaturaParticipante" ,  "CreateAssinaturaParticipante" );
         GXReorganization.SetMsg( 198 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ISECUSERLOG1"}) );
         ReorgExecute.RegisterPrecedence( "RISecUserLogSecUser" ,  "CreateSecUserLog" );
         ReorgExecute.RegisterPrecedence( "RISecUserLogSecUser" ,  "CreateSecUser" );
         GXReorganization.SetMsg( 199 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IPROPOSTACONTRATOASSINATURA1"}) );
         ReorgExecute.RegisterPrecedence( "RIPropostaContratoAssinaturaProposta" ,  "CreatePropostaContratoAssinatura" );
         ReorgExecute.RegisterPrecedence( "RIPropostaContratoAssinaturaProposta" ,  "CreateProposta" );
         GXReorganization.SetMsg( 200 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IPROPOSTACONTRATOASSINATURA2"}) );
         ReorgExecute.RegisterPrecedence( "RIPropostaContratoAssinaturaContrato" ,  "CreatePropostaContratoAssinatura" );
         ReorgExecute.RegisterPrecedence( "RIPropostaContratoAssinaturaContrato" ,  "CreateContrato" );
         GXReorganization.SetMsg( 201 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IPROPOSTACONTRATOASSINATURA3"}) );
         ReorgExecute.RegisterPrecedence( "RIPropostaContratoAssinaturaAssinatura" ,  "CreatePropostaContratoAssinatura" );
         ReorgExecute.RegisterPrecedence( "RIPropostaContratoAssinaturaAssinatura" ,  "CreateAssinatura" );
         GXReorganization.SetMsg( 202 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ICLIENTEDOCUMENTO2"}) );
         ReorgExecute.RegisterPrecedence( "RIClienteDocumentoCliente" ,  "CreateClienteDocumento" );
         ReorgExecute.RegisterPrecedence( "RIClienteDocumentoCliente" ,  "CreateCliente" );
         GXReorganization.SetMsg( 203 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ICLIENTEDOCUMENTO1"}) );
         ReorgExecute.RegisterPrecedence( "RIClienteDocumentoDocumentos" ,  "CreateClienteDocumento" );
         ReorgExecute.RegisterPrecedence( "RIClienteDocumentoDocumentos" ,  "CreateDocumentos" );
         GXReorganization.SetMsg( 204 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ICLIENTEDOCUMENTO3"}) );
         ReorgExecute.RegisterPrecedence( "RIClienteDocumentoSecUser" ,  "CreateClienteDocumento" );
         ReorgExecute.RegisterPrecedence( "RIClienteDocumentoSecUser" ,  "CreateSecUser" );
         GXReorganization.SetMsg( 205 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IREEMBOLSOASSINATURAS2"}) );
         ReorgExecute.RegisterPrecedence( "RIReembolsoAssinaturasReembolso" ,  "CreateReembolsoAssinaturas" );
         ReorgExecute.RegisterPrecedence( "RIReembolsoAssinaturasReembolso" ,  "CreateReembolso" );
         GXReorganization.SetMsg( 206 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IREEMBOLSOASSINATURAS1"}) );
         ReorgExecute.RegisterPrecedence( "RIReembolsoAssinaturasPropostaContratoAssinatura" ,  "CreateReembolsoAssinaturas" );
         ReorgExecute.RegisterPrecedence( "RIReembolsoAssinaturasPropostaContratoAssinatura" ,  "CreatePropostaContratoAssinatura" );
         GXReorganization.SetMsg( 207 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IREEMBOLSOPARCELAS1"}) );
         ReorgExecute.RegisterPrecedence( "RIReembolsoParcelasReembolso" ,  "CreateReembolsoParcelas" );
         ReorgExecute.RegisterPrecedence( "RIReembolsoParcelasReembolso" ,  "CreateReembolso" );
         GXReorganization.SetMsg( 208 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ISERASA1"}) );
         ReorgExecute.RegisterPrecedence( "RISerasaCliente" ,  "CreateSerasa" );
         ReorgExecute.RegisterPrecedence( "RISerasaCliente" ,  "CreateCliente" );
         GXReorganization.SetMsg( 209 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ISERASACHEQUES1"}) );
         ReorgExecute.RegisterPrecedence( "RISerasaChequesSerasa" ,  "CreateSerasaCheques" );
         ReorgExecute.RegisterPrecedence( "RISerasaChequesSerasa" ,  "CreateSerasa" );
         GXReorganization.SetMsg( 210 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ISERASAACOES1"}) );
         ReorgExecute.RegisterPrecedence( "RISerasaAcoesSerasa" ,  "CreateSerasaAcoes" );
         ReorgExecute.RegisterPrecedence( "RISerasaAcoesSerasa" ,  "CreateSerasa" );
         GXReorganization.SetMsg( 211 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ISERASAPROTESTOS1"}) );
         ReorgExecute.RegisterPrecedence( "RISerasaProtestosSerasa" ,  "CreateSerasaProtestos" );
         ReorgExecute.RegisterPrecedence( "RISerasaProtestosSerasa" ,  "CreateSerasa" );
         GXReorganization.SetMsg( 212 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ISERASAENDERECOS1"}) );
         ReorgExecute.RegisterPrecedence( "RISerasaEnderecosSerasa" ,  "CreateSerasaEnderecos" );
         ReorgExecute.RegisterPrecedence( "RISerasaEnderecosSerasa" ,  "CreateSerasa" );
         GXReorganization.SetMsg( 213 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ISERASAOCORRENCIAS1"}) );
         ReorgExecute.RegisterPrecedence( "RISerasaOcorrenciasSerasa" ,  "CreateSerasaOcorrencias" );
         ReorgExecute.RegisterPrecedence( "RISerasaOcorrenciasSerasa" ,  "CreateSerasa" );
         GXReorganization.SetMsg( 214 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IREEMBOLSOFLOWLOG3"}) );
         ReorgExecute.RegisterPrecedence( "RIReembolsoFlowLogWorkflowConvenio" ,  "CreateReembolsoFlowLog" );
         ReorgExecute.RegisterPrecedence( "RIReembolsoFlowLogWorkflowConvenio" ,  "CreateWorkflowConvenio" );
         GXReorganization.SetMsg( 215 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IREEMBOLSOFLOWLOG1"}) );
         ReorgExecute.RegisterPrecedence( "RIReembolsoFlowLogSecUser" ,  "CreateReembolsoFlowLog" );
         ReorgExecute.RegisterPrecedence( "RIReembolsoFlowLogSecUser" ,  "CreateSecUser" );
         GXReorganization.SetMsg( 216 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IREEMBOLSOFLOWLOG2"}) );
         ReorgExecute.RegisterPrecedence( "RIReembolsoFlowLogReembolso" ,  "CreateReembolsoFlowLog" );
         ReorgExecute.RegisterPrecedence( "RIReembolsoFlowLogReembolso" ,  "CreateReembolso" );
         GXReorganization.SetMsg( 217 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"INOTAFISCAL2"}) );
         ReorgExecute.RegisterPrecedence( "RINotaFiscalCliente" ,  "CreateNotaFiscal" );
         ReorgExecute.RegisterPrecedence( "RINotaFiscalCliente" ,  "CreateCliente" );
         GXReorganization.SetMsg( 218 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"INOTAFISCAL1"}) );
         ReorgExecute.RegisterPrecedence( "RINotaFiscalCliente1" ,  "CreateNotaFiscal" );
         ReorgExecute.RegisterPrecedence( "RINotaFiscalCliente1" ,  "CreateCliente" );
         GXReorganization.SetMsg( 219 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"INOTAFISCALITEM2"}) );
         ReorgExecute.RegisterPrecedence( "RINotaFiscalItemProposta" ,  "CreateNotaFiscalItem" );
         ReorgExecute.RegisterPrecedence( "RINotaFiscalItemProposta" ,  "CreateProposta" );
         GXReorganization.SetMsg( 220 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"INOTAFISCALITEM1"}) );
         ReorgExecute.RegisterPrecedence( "RINotaFiscalItemNotaFiscal" ,  "CreateNotaFiscalItem" );
         ReorgExecute.RegisterPrecedence( "RINotaFiscalItemNotaFiscal" ,  "CreateNotaFiscal" );
         GXReorganization.SetMsg( 221 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ICREDITO1"}) );
         ReorgExecute.RegisterPrecedence( "RICreditoCliente" ,  "CreateCredito" );
         ReorgExecute.RegisterPrecedence( "RICreditoCliente" ,  "CreateCliente" );
         GXReorganization.SetMsg( 222 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ICREDITO3"}) );
         ReorgExecute.RegisterPrecedence( "RICreditoSecUser" ,  "CreateCredito" );
         ReorgExecute.RegisterPrecedence( "RICreditoSecUser" ,  "CreateSecUser" );
         GXReorganization.SetMsg( 223 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ICREDITO2"}) );
         ReorgExecute.RegisterPrecedence( "RICreditoSecUser1" ,  "CreateCredito" );
         ReorgExecute.RegisterPrecedence( "RICreditoSecUser1" ,  "CreateSecUser" );
         GXReorganization.SetMsg( 224 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITAXAS1"}) );
         ReorgExecute.RegisterPrecedence( "RITaxasSecUser" ,  "CreateTaxas" );
         ReorgExecute.RegisterPrecedence( "RITaxasSecUser" ,  "CreateSecUser" );
         GXReorganization.SetMsg( 225 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITAXAS2"}) );
         ReorgExecute.RegisterPrecedence( "RITaxasSecUser1" ,  "CreateTaxas" );
         ReorgExecute.RegisterPrecedence( "RITaxasSecUser1" ,  "CreateSecUser" );
         GXReorganization.SetMsg( 226 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"INOTAFISCALPARCELAMENTO1"}) );
         ReorgExecute.RegisterPrecedence( "RINotaFiscalParcelamentoNotaFiscal" ,  "CreateNotaFiscalParcelamento" );
         ReorgExecute.RegisterPrecedence( "RINotaFiscalParcelamentoNotaFiscal" ,  "CreateNotaFiscal" );
         GXReorganization.SetMsg( 227 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"INOTIFICACAOAGENDADA1"}) );
         ReorgExecute.RegisterPrecedence( "RINotificacaoAgendadaLayoutContrato" ,  "CreateNotificacaoAgendada" );
         ReorgExecute.RegisterPrecedence( "RINotificacaoAgendadaLayoutContrato" ,  "CreateLayoutContrato" );
         GXReorganization.SetMsg( 228 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"INOTIFICACAOAGENDADAPROCESSAMENTOITEM1"}) );
         ReorgExecute.RegisterPrecedence( "RINotificacaoAgendadaProcessamentoItemNotificacaoAgendadaProcessamento" ,  "CreateNotificacaoAgendadaProcessamentoItem" );
         ReorgExecute.RegisterPrecedence( "RINotificacaoAgendadaProcessamentoItemNotificacaoAgendadaProcessamento" ,  "CreateNotificacaoAgendadaProcessamento" );
         GXReorganization.SetMsg( 229 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IAGENCIA2"}) );
         ReorgExecute.RegisterPrecedence( "RIAgenciaSecUser" ,  "CreateAgencia" );
         ReorgExecute.RegisterPrecedence( "RIAgenciaSecUser" ,  "CreateSecUser" );
         GXReorganization.SetMsg( 230 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IAGENCIA1"}) );
         ReorgExecute.RegisterPrecedence( "RIAgenciaSecUser1" ,  "CreateAgencia" );
         ReorgExecute.RegisterPrecedence( "RIAgenciaSecUser1" ,  "CreateSecUser" );
         GXReorganization.SetMsg( 231 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IAGENCIA3"}) );
         ReorgExecute.RegisterPrecedence( "RIAgenciaBanco" ,  "CreateAgencia" );
         ReorgExecute.RegisterPrecedence( "RIAgenciaBanco" ,  "CreateBanco" );
         GXReorganization.SetMsg( 232 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ICONTABANCARIA3"}) );
         ReorgExecute.RegisterPrecedence( "RIContaBancariaAgencia" ,  "CreateContaBancaria" );
         ReorgExecute.RegisterPrecedence( "RIContaBancariaAgencia" ,  "CreateAgencia" );
         GXReorganization.SetMsg( 233 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ICONTABANCARIA2"}) );
         ReorgExecute.RegisterPrecedence( "RIContaBancariaSecUser" ,  "CreateContaBancaria" );
         ReorgExecute.RegisterPrecedence( "RIContaBancariaSecUser" ,  "CreateSecUser" );
         GXReorganization.SetMsg( 234 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ICONTABANCARIA1"}) );
         ReorgExecute.RegisterPrecedence( "RIContaBancariaSecUser1" ,  "CreateContaBancaria" );
         ReorgExecute.RegisterPrecedence( "RIContaBancariaSecUser1" ,  "CreateSecUser" );
         GXReorganization.SetMsg( 235 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ICHAVEPIX3"}) );
         ReorgExecute.RegisterPrecedence( "RIChavePIXContaBancaria" ,  "CreateChavePIX" );
         ReorgExecute.RegisterPrecedence( "RIChavePIXContaBancaria" ,  "CreateContaBancaria" );
         GXReorganization.SetMsg( 236 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ICHAVEPIX2"}) );
         ReorgExecute.RegisterPrecedence( "RIChavePIXSecUser" ,  "CreateChavePIX" );
         ReorgExecute.RegisterPrecedence( "RIChavePIXSecUser" ,  "CreateSecUser" );
         GXReorganization.SetMsg( 237 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ICHAVEPIX1"}) );
         ReorgExecute.RegisterPrecedence( "RIChavePIXSecUser1" ,  "CreateChavePIX" );
         ReorgExecute.RegisterPrecedence( "RIChavePIXSecUser1" ,  "CreateSecUser" );
         GXReorganization.SetMsg( 238 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IREPRESENTANTE3"}) );
         ReorgExecute.RegisterPrecedence( "RIRepresentanteCliente" ,  "CreateRepresentante" );
         ReorgExecute.RegisterPrecedence( "RIRepresentanteCliente" ,  "CreateCliente" );
         GXReorganization.SetMsg( 239 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IREPRESENTANTE1"}) );
         ReorgExecute.RegisterPrecedence( "RIRepresentanteProfissao" ,  "CreateRepresentante" );
         ReorgExecute.RegisterPrecedence( "RIRepresentanteProfissao" ,  "CreateProfissao" );
         GXReorganization.SetMsg( 240 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IREPRESENTANTE2"}) );
         ReorgExecute.RegisterPrecedence( "RIRepresentanteMunicipio" ,  "CreateRepresentante" );
         ReorgExecute.RegisterPrecedence( "RIRepresentanteMunicipio" ,  "CreateMunicipio" );
      }

      private void ExecuteReorganization( )
      {
         if ( ErrCode == 0 )
         {
            TablesCount( ) ;
            if ( ! PrintOnlyRecordCount( ) )
            {
               FirstActions( ) ;
               SetPrecedence( ) ;
               ExecuteTablesReorganization( ) ;
            }
         }
      }

      public void UtilsCleanup( )
      {
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
      }

      public override void initialize( )
      {
         DS = new GxDataStore();
         ErrMsg = "";
         DataBaseName = "";
         sSchemaVar = "";
         sTableName = "";
         sMySchemaName = "";
         tablename = "";
         ntablename = true;
         schemaname = "";
         nschemaname = true;
         P00012_Atablename = new string[] {""} ;
         P00012_ntablename = new bool[] {false} ;
         P00012_Aschemaname = new string[] {""} ;
         P00012_nschemaname = new bool[] {false} ;
         P00023_Atablename = new string[] {""} ;
         P00023_ntablename = new bool[] {false} ;
         P00023_Aschemaname = new string[] {""} ;
         P00023_nschemaname = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reorg__default(),
            new Object[][] {
                new Object[] {
               P00012_Atablename, P00012_Aschemaname
               }
               , new Object[] {
               P00023_Atablename, P00023_Aschemaname
               }
            }
         );
         /* GeneXus formulas. */
      }

      protected short ErrCode ;
      protected short Count ;
      protected short Res ;
      protected string ErrMsg ;
      protected string DataBaseName ;
      protected string cmdBuffer ;
      protected string sSchemaVar ;
      protected string sTableName ;
      protected string sMySchemaName ;
      protected bool ntablename ;
      protected bool nschemaname ;
      protected string tablename ;
      protected string schemaname ;
      protected GxDataStore DS ;
      protected IGxDataStore dsDefault ;
      protected GxCommand RGZ ;
      protected IDataStoreProvider pr_default ;
      protected string[] P00012_Atablename ;
      protected bool[] P00012_ntablename ;
      protected string[] P00012_Aschemaname ;
      protected bool[] P00012_nschemaname ;
      protected string[] P00023_Atablename ;
      protected bool[] P00023_ntablename ;
      protected string[] P00023_Aschemaname ;
      protected bool[] P00023_nschemaname ;
   }

   public class reorg__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00012;
          prmP00012 = new Object[] {
          new ParDef("sTableName",GXType.Char,255,0) ,
          new ParDef("sMySchemaName",GXType.Char,255,0)
          };
          Object[] prmP00023;
          prmP00023 = new Object[] {
          new ParDef("sTableName",GXType.Char,255,0) ,
          new ParDef("sMySchemaName",GXType.Char,255,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00012", "SELECT TABLENAME, TABLEOWNER FROM PG_TABLES WHERE (UPPER(TABLENAME) = ( UPPER(:sTableName))) AND (UPPER(TABLEOWNER) = ( UPPER(:sMySchemaName))) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00012,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00023", "SELECT VIEWNAME, VIEWOWNER FROM PG_VIEWS WHERE (UPPER(VIEWNAME) = ( UPPER(:sTableName))) AND (UPPER(VIEWOWNER) = ( UPPER(:sMySchemaName))) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00023,100, GxCacheFrequency.OFF ,true,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
