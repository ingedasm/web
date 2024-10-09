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
         context.SetDefaultTheme("IndicadroresPalmas", false);
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
         executePrivate();
      }

      void executePrivate( )
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
            DS.Connection.Database = "";
            ErrCode = DS.Connection.FullConnect();
            if ( ErrCode == 0 )
            {
               try
               {
                  GeneXus.Reorg.GXReorganization.AddMsg( GXResourceManager.GetMessage("GXM_dbcrea")+ " " +DataBaseName , null);
                  cmdBuffer = "CREATE DATABASE " + "[" + DataBaseName + "]";
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
                  cmdBuffer = "ALTER DATABASE " + "[" + DataBaseName + "]" + " SET READ_COMMITTED_SNAPSHOT ON";
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
               setupDB = 0;
               if ( ( setupDB == 1 ) || GeneXus.Configuration.Preferences.MustSetupDB( ) )
               {
                  defaultUsers = GXUtil.DefaultWebUser( context);
                  short gxidx;
                  gxidx = 1;
                  while ( gxidx <= defaultUsers.Count )
                  {
                     defaultUser = ((string)defaultUsers.Item(gxidx));
                     try
                     {
                        GeneXus.Reorg.GXReorganization.AddMsg( GXResourceManager.GetMessage("GXM_dbadduser", new   object[]  {defaultUser, DataBaseName}) , null);
                        cmdBuffer = "CREATE LOGIN " + "[" + defaultUser + "]" + " FROM WINDOWS";
                        RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                        RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                        RGZ.ExecuteStmt() ;
                        RGZ.Drop();
                     }
                     catch
                     {
                     }
                     try
                     {
                        cmdBuffer = "CREATE USER " + "[" + defaultUser + "]" + " FOR LOGIN " + "[" + defaultUser + "]";
                        RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                        RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                        RGZ.ExecuteStmt() ;
                        RGZ.Drop();
                     }
                     catch
                     {
                     }
                     try
                     {
                        cmdBuffer = "EXEC sp_addrolemember N'db_datareader', N'" + defaultUser + "'";
                        RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                        RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                        RGZ.ExecuteStmt() ;
                        RGZ.Drop();
                     }
                     catch
                     {
                     }
                     try
                     {
                        cmdBuffer = "EXEC sp_addrolemember N'db_datawriter', N'" + defaultUser + "'";
                        RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                        RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                        RGZ.ExecuteStmt() ;
                        RGZ.Drop();
                     }
                     catch
                     {
                     }
                     gxidx = (short)(gxidx+1);
                  }
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

      public void CreateTRABAJADORESMES( )
      {
         string cmdBuffer = "";
         /* Indices for table TRABAJADORESMES */
         try
         {
            cmdBuffer=" CREATE TABLE [TRABAJADORESMES] ([TRABAJADORESMESANO] smallint NOT NULL , [TRABAJADORESMESMES] smallint NOT NULL , [TRABAJADORESMESNRO] decimal( 10) NOT NULL , PRIMARY KEY([TRABAJADORESMESANO], [TRABAJADORESMESMES]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[TRABAJADORESMES]") ;
               cmdBuffer=" DROP TABLE [TRABAJADORESMES] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[TRABAJADORESMES]") ;
                  cmdBuffer=" DROP VIEW [TRABAJADORESMES] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[TRABAJADORESMES]") ;
                     cmdBuffer=" DROP FUNCTION [TRABAJADORESMES] "
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
            cmdBuffer=" CREATE TABLE [TRABAJADORESMES] ([TRABAJADORESMESANO] smallint NOT NULL , [TRABAJADORESMESMES] smallint NOT NULL , [TRABAJADORESMESNRO] decimal( 10) NOT NULL , PRIMARY KEY([TRABAJADORESMESANO], [TRABAJADORESMESMES]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateZONALOTES( )
      {
         string cmdBuffer = "";
         /* Indices for table ZONALOTES */
         try
         {
            cmdBuffer=" CREATE TABLE [ZONALOTES] ([ZONALOTESCODZON] nvarchar(40) NOT NULL , [ZONALOTESCODLOT] nvarchar(40) NOT NULL , PRIMARY KEY([ZONALOTESCODZON], [ZONALOTESCODLOT]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[ZONALOTES]") ;
               cmdBuffer=" DROP TABLE [ZONALOTES] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[ZONALOTES]") ;
                  cmdBuffer=" DROP VIEW [ZONALOTES] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[ZONALOTES]") ;
                     cmdBuffer=" DROP FUNCTION [ZONALOTES] "
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
            cmdBuffer=" CREATE TABLE [ZONALOTES] ([ZONALOTESCODZON] nvarchar(40) NOT NULL , [ZONALOTESCODLOT] nvarchar(40) NOT NULL , PRIMARY KEY([ZONALOTESCODZON], [ZONALOTESCODLOT]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateMATERIALPALMAS( )
      {
         string cmdBuffer = "";
         /* Indices for table MATERIALPALMAS */
         try
         {
            cmdBuffer=" CREATE TABLE [MATERIALPALMAS] ([MATERIALPALMASCOD] nvarchar(140) NOT NULL , [MATERIALPALMASNOM] nvarchar(200) NOT NULL , PRIMARY KEY([MATERIALPALMASCOD]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[MATERIALPALMAS]") ;
               cmdBuffer=" DROP TABLE [MATERIALPALMAS] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[MATERIALPALMAS]") ;
                  cmdBuffer=" DROP VIEW [MATERIALPALMAS] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[MATERIALPALMAS]") ;
                     cmdBuffer=" DROP FUNCTION [MATERIALPALMAS] "
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
            cmdBuffer=" CREATE TABLE [MATERIALPALMAS] ([MATERIALPALMASCOD] nvarchar(140) NOT NULL , [MATERIALPALMASNOM] nvarchar(200) NOT NULL , PRIMARY KEY([MATERIALPALMASCOD]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTiposEnfermedades( )
      {
         string cmdBuffer = "";
         /* Indices for table TiposEnfermedades */
         try
         {
            cmdBuffer=" CREATE TABLE [TiposEnfermedades] ([TiposEnfermedadesCod] nvarchar(40) NOT NULL , [TiposEnfermedadesNom] nvarchar(150) NOT NULL , PRIMARY KEY([TiposEnfermedadesCod]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[TiposEnfermedades]") ;
               cmdBuffer=" DROP TABLE [TiposEnfermedades] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[TiposEnfermedades]") ;
                  cmdBuffer=" DROP VIEW [TiposEnfermedades] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[TiposEnfermedades]") ;
                     cmdBuffer=" DROP FUNCTION [TiposEnfermedades] "
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
            cmdBuffer=" CREATE TABLE [TiposEnfermedades] ([TiposEnfermedadesCod] nvarchar(40) NOT NULL , [TiposEnfermedadesNom] nvarchar(150) NOT NULL , PRIMARY KEY([TiposEnfermedadesCod]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateRFF_COMPRADA( )
      {
         string cmdBuffer = "";
         /* Indices for table RFF_COMPRADA */
         try
         {
            cmdBuffer=" CREATE TABLE [RFF_COMPRADA] ([RFF_COMPRADAFecha] datetime NOT NULL , [Cod_Area] nvarchar(40) NOT NULL , [IndicadoresCodigo] nvarchar(40) NOT NULL , [RFF_COMPRADAMes] smallint NOT NULL , [RFF_COMPRADAAno] smallint NOT NULL , [RFF_COMPRAPRODUCUP] nchar(20) NOT NULL , [RFF_COMPRATON] money NULL , [RFF_COMPRAPROVEE] nvarchar(300) NULL , [RFF_COMPRAFINCA] nvarchar(300) NULL , [RFF_COMPRAZONA] nvarchar(40) NULL , [RFF_COMPRAVEREDAID] decimal( 15) NULL , [RFF_COMPRAVEREDANOM] nvarchar(300) NULL , [RFF_COMPRAMUNIID] decimal( 10) NULL , [RFF_COMPRAMUNINOM] nvarchar(300) NULL , [RFF_COMPRADEPTOID] decimal( 10) NULL , [RFF_COMPRADEPTONOM] nvarchar(300) NULL , [RFF_COMPRACLASIFIC] nvarchar(40) NULL , [RFF_COMPRATAMANO] nvarchar(40) NULL , [RFF_COMPRAHAS] money NULL , [RFF_COMPRADISTAKM] money NULL , [RFF_COMPRARANDISTAN] nvarchar(40) NULL , [RFF_COMPRAIDACOMPANAM] decimal( 15) NULL , [RFF_COMPRAACOMPANANOM] nvarchar(300) NULL , [RFF_COMPRARSPO] nvarchar(40) NULL , [RFF_COMPRANATURALEZA] nvarchar(40) NULL , [RFF_COMPRACOORDX] nvarchar(40) NULL , [RFF_COMPRACOORDY] nvarchar(40) NULL , [RFF_COMPRAEDADRANGO] nvarchar(50) NULL , [RFF_COMPRAMATERIAL] nvarchar(40) NULL , [RFF_COMPRACOMITE] nvarchar(300) NULL , PRIMARY KEY([RFF_COMPRADAFecha], [Cod_Area], [IndicadoresCodigo], [RFF_COMPRADAMes], [RFF_COMPRADAAno], [RFF_COMPRAPRODUCUP]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[RFF_COMPRADA]") ;
               cmdBuffer=" DROP TABLE [RFF_COMPRADA] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[RFF_COMPRADA]") ;
                  cmdBuffer=" DROP VIEW [RFF_COMPRADA] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[RFF_COMPRADA]") ;
                     cmdBuffer=" DROP FUNCTION [RFF_COMPRADA] "
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
            cmdBuffer=" CREATE TABLE [RFF_COMPRADA] ([RFF_COMPRADAFecha] datetime NOT NULL , [Cod_Area] nvarchar(40) NOT NULL , [IndicadoresCodigo] nvarchar(40) NOT NULL , [RFF_COMPRADAMes] smallint NOT NULL , [RFF_COMPRADAAno] smallint NOT NULL , [RFF_COMPRAPRODUCUP] nchar(20) NOT NULL , [RFF_COMPRATON] money NULL , [RFF_COMPRAPROVEE] nvarchar(300) NULL , [RFF_COMPRAFINCA] nvarchar(300) NULL , [RFF_COMPRAZONA] nvarchar(40) NULL , [RFF_COMPRAVEREDAID] decimal( 15) NULL , [RFF_COMPRAVEREDANOM] nvarchar(300) NULL , [RFF_COMPRAMUNIID] decimal( 10) NULL , [RFF_COMPRAMUNINOM] nvarchar(300) NULL , [RFF_COMPRADEPTOID] decimal( 10) NULL , [RFF_COMPRADEPTONOM] nvarchar(300) NULL , [RFF_COMPRACLASIFIC] nvarchar(40) NULL , [RFF_COMPRATAMANO] nvarchar(40) NULL , [RFF_COMPRAHAS] money NULL , [RFF_COMPRADISTAKM] money NULL , [RFF_COMPRARANDISTAN] nvarchar(40) NULL , [RFF_COMPRAIDACOMPANAM] decimal( 15) NULL , [RFF_COMPRAACOMPANANOM] nvarchar(300) NULL , [RFF_COMPRARSPO] nvarchar(40) NULL , [RFF_COMPRANATURALEZA] nvarchar(40) NULL , [RFF_COMPRACOORDX] nvarchar(40) NULL , [RFF_COMPRACOORDY] nvarchar(40) NULL , [RFF_COMPRAEDADRANGO] nvarchar(50) NULL , [RFF_COMPRAMATERIAL] nvarchar(40) NULL , [RFF_COMPRACOMITE] nvarchar(300) NULL , PRIMARY KEY([RFF_COMPRADAFecha], [Cod_Area], [IndicadoresCodigo], [RFF_COMPRADAMes], [RFF_COMPRADAAno], [RFF_COMPRAPRODUCUP]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IRFF_COMPRADA1] ON [RFF_COMPRADA] ([IndicadoresCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IRFF_COMPRADA1] ON [RFF_COMPRADA] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IRFF_COMPRADA1] ON [RFF_COMPRADA] ([IndicadoresCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IRFF_COMPRADA2] ON [RFF_COMPRADA] ([Cod_Area] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IRFF_COMPRADA2] ON [RFF_COMPRADA] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IRFF_COMPRADA2] ON [RFF_COMPRADA] ([Cod_Area] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreatePRECNETOTONCPO( )
      {
         string cmdBuffer = "";
         /* Indices for table PRECNETOTONCPO */
         try
         {
            cmdBuffer=" CREATE TABLE [PRECNETOTONCPO] ([PRECNETOTONCPOFecha] datetime NOT NULL , [PRECNETOTONCPOMes] smallint NOT NULL , [PRECNETOTONCPOAno] smallint NOT NULL , [Cod_Area] nvarchar(40) NOT NULL , [IndicadoresCodigo] nvarchar(40) NOT NULL , [MOTIVOSPRENETCodigo] nvarchar(200) NOT NULL , [PRECNETOTONCPOValor] money NOT NULL , PRIMARY KEY([PRECNETOTONCPOFecha], [PRECNETOTONCPOMes], [PRECNETOTONCPOAno], [Cod_Area], [IndicadoresCodigo], [MOTIVOSPRENETCodigo]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[PRECNETOTONCPO]") ;
               cmdBuffer=" DROP TABLE [PRECNETOTONCPO] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[PRECNETOTONCPO]") ;
                  cmdBuffer=" DROP VIEW [PRECNETOTONCPO] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[PRECNETOTONCPO]") ;
                     cmdBuffer=" DROP FUNCTION [PRECNETOTONCPO] "
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
            cmdBuffer=" CREATE TABLE [PRECNETOTONCPO] ([PRECNETOTONCPOFecha] datetime NOT NULL , [PRECNETOTONCPOMes] smallint NOT NULL , [PRECNETOTONCPOAno] smallint NOT NULL , [Cod_Area] nvarchar(40) NOT NULL , [IndicadoresCodigo] nvarchar(40) NOT NULL , [MOTIVOSPRENETCodigo] nvarchar(200) NOT NULL , [PRECNETOTONCPOValor] money NOT NULL , PRIMARY KEY([PRECNETOTONCPOFecha], [PRECNETOTONCPOMes], [PRECNETOTONCPOAno], [Cod_Area], [IndicadoresCodigo], [MOTIVOSPRENETCodigo]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IPRECNETOTONCPO1] ON [PRECNETOTONCPO] ([MOTIVOSPRENETCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IPRECNETOTONCPO1] ON [PRECNETOTONCPO] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IPRECNETOTONCPO1] ON [PRECNETOTONCPO] ([MOTIVOSPRENETCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IPRECNETOTONCPO2] ON [PRECNETOTONCPO] ([IndicadoresCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IPRECNETOTONCPO2] ON [PRECNETOTONCPO] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IPRECNETOTONCPO2] ON [PRECNETOTONCPO] ([IndicadoresCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IPRECNETOTONCPO3] ON [PRECNETOTONCPO] ([Cod_Area] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IPRECNETOTONCPO3] ON [PRECNETOTONCPO] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IPRECNETOTONCPO3] ON [PRECNETOTONCPO] ([Cod_Area] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateMOTIVOSPRENET( )
      {
         string cmdBuffer = "";
         /* Indices for table MOTIVOSPRENET */
         try
         {
            cmdBuffer=" CREATE TABLE [MOTIVOSPRENET] ([MOTIVOSPRENETCodigo] nvarchar(200) NOT NULL , [MOTIVOSPRENETNombre] nvarchar(250) NOT NULL , PRIMARY KEY([MOTIVOSPRENETCodigo]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[MOTIVOSPRENET]") ;
               cmdBuffer=" DROP TABLE [MOTIVOSPRENET] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[MOTIVOSPRENET]") ;
                  cmdBuffer=" DROP VIEW [MOTIVOSPRENET] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[MOTIVOSPRENET]") ;
                     cmdBuffer=" DROP FUNCTION [MOTIVOSPRENET] "
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
            cmdBuffer=" CREATE TABLE [MOTIVOSPRENET] ([MOTIVOSPRENETCodigo] nvarchar(200) NOT NULL , [MOTIVOSPRENETNombre] nvarchar(250) NOT NULL , PRIMARY KEY([MOTIVOSPRENETCodigo]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateCOSTONRFFPROCES( )
      {
         string cmdBuffer = "";
         /* Indices for table COSTONRFFPROCES */
         try
         {
            cmdBuffer=" CREATE TABLE [COSTONRFFPROCES] ([COSTONRFFPROCESFecha] datetime NOT NULL , [COSTONRFFPROCESMes] smallint NOT NULL , [COSTONRFFPROCESAno] smallint NOT NULL , [Cod_Area] nvarchar(40) NOT NULL , [IndicadoresCodigo] nvarchar(40) NOT NULL , [MOTIVOSCOSRFFCodigo] nvarchar(140) NOT NULL , [COSTONRFFPROCESValor] money NOT NULL , [COSTONRFFPROCESUser] nvarchar(150) NOT NULL , [COSTONRFFPROCESReg] datetime NOT NULL , [COSTONRFFPROCESHor] nvarchar(40) NOT NULL , PRIMARY KEY([COSTONRFFPROCESFecha], [COSTONRFFPROCESMes], [COSTONRFFPROCESAno], [Cod_Area], [IndicadoresCodigo], [MOTIVOSCOSRFFCodigo]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[COSTONRFFPROCES]") ;
               cmdBuffer=" DROP TABLE [COSTONRFFPROCES] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[COSTONRFFPROCES]") ;
                  cmdBuffer=" DROP VIEW [COSTONRFFPROCES] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[COSTONRFFPROCES]") ;
                     cmdBuffer=" DROP FUNCTION [COSTONRFFPROCES] "
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
            cmdBuffer=" CREATE TABLE [COSTONRFFPROCES] ([COSTONRFFPROCESFecha] datetime NOT NULL , [COSTONRFFPROCESMes] smallint NOT NULL , [COSTONRFFPROCESAno] smallint NOT NULL , [Cod_Area] nvarchar(40) NOT NULL , [IndicadoresCodigo] nvarchar(40) NOT NULL , [MOTIVOSCOSRFFCodigo] nvarchar(140) NOT NULL , [COSTONRFFPROCESValor] money NOT NULL , [COSTONRFFPROCESUser] nvarchar(150) NOT NULL , [COSTONRFFPROCESReg] datetime NOT NULL , [COSTONRFFPROCESHor] nvarchar(40) NOT NULL , PRIMARY KEY([COSTONRFFPROCESFecha], [COSTONRFFPROCESMes], [COSTONRFFPROCESAno], [Cod_Area], [IndicadoresCodigo], [MOTIVOSCOSRFFCodigo]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ICOSTONRFFPROCES1] ON [COSTONRFFPROCES] ([MOTIVOSCOSRFFCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [ICOSTONRFFPROCES1] ON [COSTONRFFPROCES] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ICOSTONRFFPROCES1] ON [COSTONRFFPROCES] ([MOTIVOSCOSRFFCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ICOSTONRFFPROCES2] ON [COSTONRFFPROCES] ([IndicadoresCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [ICOSTONRFFPROCES2] ON [COSTONRFFPROCES] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ICOSTONRFFPROCES2] ON [COSTONRFFPROCES] ([IndicadoresCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ICOSTONRFFPROCES3] ON [COSTONRFFPROCES] ([Cod_Area] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [ICOSTONRFFPROCES3] ON [COSTONRFFPROCES] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ICOSTONRFFPROCES3] ON [COSTONRFFPROCES] ([Cod_Area] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateMOTIVOSCOSRFF( )
      {
         string cmdBuffer = "";
         /* Indices for table MOTIVOSCOSRFF */
         try
         {
            cmdBuffer=" CREATE TABLE [MOTIVOSCOSRFF] ([MOTIVOSCOSRFFCodigo] nvarchar(140) NOT NULL , [MOTIVOSCOSRFFNombre] nvarchar(150) NOT NULL , PRIMARY KEY([MOTIVOSCOSRFFCodigo]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[MOTIVOSCOSRFF]") ;
               cmdBuffer=" DROP TABLE [MOTIVOSCOSRFF] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[MOTIVOSCOSRFF]") ;
                  cmdBuffer=" DROP VIEW [MOTIVOSCOSRFF] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[MOTIVOSCOSRFF]") ;
                     cmdBuffer=" DROP FUNCTION [MOTIVOSCOSRFF] "
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
            cmdBuffer=" CREATE TABLE [MOTIVOSCOSRFF] ([MOTIVOSCOSRFFCodigo] nvarchar(140) NOT NULL , [MOTIVOSCOSRFFNombre] nvarchar(150) NOT NULL , PRIMARY KEY([MOTIVOSCOSRFFCodigo]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateCOSTOTONRFFPRODU( )
      {
         string cmdBuffer = "";
         /* Indices for table COSTOTONRFFPRODU */
         try
         {
            cmdBuffer=" CREATE TABLE [COSTOTONRFFPRODU] ([COSTOTONRFFPRODUFecha] datetime NOT NULL , [COSTOTONRFFPRODUMes] smallint NOT NULL , [COSTOTONRFFPRODUAno] smallint NOT NULL , [Cod_Area] nvarchar(40) NOT NULL , [IndicadoresCodigo] nvarchar(40) NOT NULL , [MOTIVOTONRFFcod] nvarchar(140) NOT NULL , [COSTOTONRFFPRODUValor] money NOT NULL , PRIMARY KEY([COSTOTONRFFPRODUFecha], [COSTOTONRFFPRODUMes], [COSTOTONRFFPRODUAno], [Cod_Area], [IndicadoresCodigo], [MOTIVOTONRFFcod]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[COSTOTONRFFPRODU]") ;
               cmdBuffer=" DROP TABLE [COSTOTONRFFPRODU] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[COSTOTONRFFPRODU]") ;
                  cmdBuffer=" DROP VIEW [COSTOTONRFFPRODU] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[COSTOTONRFFPRODU]") ;
                     cmdBuffer=" DROP FUNCTION [COSTOTONRFFPRODU] "
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
            cmdBuffer=" CREATE TABLE [COSTOTONRFFPRODU] ([COSTOTONRFFPRODUFecha] datetime NOT NULL , [COSTOTONRFFPRODUMes] smallint NOT NULL , [COSTOTONRFFPRODUAno] smallint NOT NULL , [Cod_Area] nvarchar(40) NOT NULL , [IndicadoresCodigo] nvarchar(40) NOT NULL , [MOTIVOTONRFFcod] nvarchar(140) NOT NULL , [COSTOTONRFFPRODUValor] money NOT NULL , PRIMARY KEY([COSTOTONRFFPRODUFecha], [COSTOTONRFFPRODUMes], [COSTOTONRFFPRODUAno], [Cod_Area], [IndicadoresCodigo], [MOTIVOTONRFFcod]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ICOSTOTONRFFPRODU1] ON [COSTOTONRFFPRODU] ([MOTIVOTONRFFcod] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [ICOSTOTONRFFPRODU1] ON [COSTOTONRFFPRODU] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ICOSTOTONRFFPRODU1] ON [COSTOTONRFFPRODU] ([MOTIVOTONRFFcod] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ICOSTOTONRFFPRODU2] ON [COSTOTONRFFPRODU] ([IndicadoresCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [ICOSTOTONRFFPRODU2] ON [COSTOTONRFFPRODU] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ICOSTOTONRFFPRODU2] ON [COSTOTONRFFPRODU] ([IndicadoresCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ICOSTOTONRFFPRODU3] ON [COSTOTONRFFPRODU] ([Cod_Area] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [ICOSTOTONRFFPRODU3] ON [COSTOTONRFFPRODU] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ICOSTOTONRFFPRODU3] ON [COSTOTONRFFPRODU] ([Cod_Area] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateMOTIVOTONRFF( )
      {
         string cmdBuffer = "";
         /* Indices for table MOTIVOTONRFF */
         try
         {
            cmdBuffer=" CREATE TABLE [MOTIVOTONRFF] ([MOTIVOTONRFFcod] nvarchar(140) NOT NULL , [MOTIVOTONRFFNom] nvarchar(144) NOT NULL , PRIMARY KEY([MOTIVOTONRFFcod]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[MOTIVOTONRFF]") ;
               cmdBuffer=" DROP TABLE [MOTIVOTONRFF] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[MOTIVOTONRFF]") ;
                  cmdBuffer=" DROP VIEW [MOTIVOTONRFF] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[MOTIVOTONRFF]") ;
                     cmdBuffer=" DROP FUNCTION [MOTIVOTONRFF] "
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
            cmdBuffer=" CREATE TABLE [MOTIVOTONRFF] ([MOTIVOTONRFFcod] nvarchar(140) NOT NULL , [MOTIVOTONRFFNom] nvarchar(144) NOT NULL , PRIMARY KEY([MOTIVOTONRFFcod]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateCOSTOCPOPRODUCIDO( )
      {
         string cmdBuffer = "";
         /* Indices for table COSTOCPOPRODUCIDO */
         try
         {
            cmdBuffer=" CREATE TABLE [COSTOCPOPRODUCIDO] ([COSTOCPOPRODUCIDOFecha] datetime NOT NULL , [COSTOCPOPRODUCIDOMes] smallint NOT NULL , [COSTOCPOPRODUCIDOAno] smallint NOT NULL , [Cod_Area] nvarchar(40) NOT NULL , [IndicadoresCodigo] nvarchar(40) NOT NULL , [TIPOSCPOCod] nvarchar(120) NOT NULL , [TipoProductoCod] nvarchar(40) NOT NULL , [COSTOCPOPRODUCIDOValor] money NOT NULL , [COSTOCPOPRODUCIDOUser] nvarchar(150) NOT NULL , [COSTOCPOPRODUCIDOReg] datetime NOT NULL , [COSTOCPOPRODUCIDOHor] nvarchar(40) NOT NULL , PRIMARY KEY([COSTOCPOPRODUCIDOFecha], [COSTOCPOPRODUCIDOMes], [COSTOCPOPRODUCIDOAno], [Cod_Area], [IndicadoresCodigo], [TIPOSCPOCod], [TipoProductoCod]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[COSTOCPOPRODUCIDO]") ;
               cmdBuffer=" DROP TABLE [COSTOCPOPRODUCIDO] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[COSTOCPOPRODUCIDO]") ;
                  cmdBuffer=" DROP VIEW [COSTOCPOPRODUCIDO] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[COSTOCPOPRODUCIDO]") ;
                     cmdBuffer=" DROP FUNCTION [COSTOCPOPRODUCIDO] "
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
            cmdBuffer=" CREATE TABLE [COSTOCPOPRODUCIDO] ([COSTOCPOPRODUCIDOFecha] datetime NOT NULL , [COSTOCPOPRODUCIDOMes] smallint NOT NULL , [COSTOCPOPRODUCIDOAno] smallint NOT NULL , [Cod_Area] nvarchar(40) NOT NULL , [IndicadoresCodigo] nvarchar(40) NOT NULL , [TIPOSCPOCod] nvarchar(120) NOT NULL , [TipoProductoCod] nvarchar(40) NOT NULL , [COSTOCPOPRODUCIDOValor] money NOT NULL , [COSTOCPOPRODUCIDOUser] nvarchar(150) NOT NULL , [COSTOCPOPRODUCIDOReg] datetime NOT NULL , [COSTOCPOPRODUCIDOHor] nvarchar(40) NOT NULL , PRIMARY KEY([COSTOCPOPRODUCIDOFecha], [COSTOCPOPRODUCIDOMes], [COSTOCPOPRODUCIDOAno], [Cod_Area], [IndicadoresCodigo], [TIPOSCPOCod], [TipoProductoCod]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ICOSTOCPOPRODUCIDO1] ON [COSTOCPOPRODUCIDO] ([TipoProductoCod] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [ICOSTOCPOPRODUCIDO1] ON [COSTOCPOPRODUCIDO] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ICOSTOCPOPRODUCIDO1] ON [COSTOCPOPRODUCIDO] ([TipoProductoCod] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ICOSTOCPOPRODUCIDO2] ON [COSTOCPOPRODUCIDO] ([TIPOSCPOCod] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [ICOSTOCPOPRODUCIDO2] ON [COSTOCPOPRODUCIDO] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ICOSTOCPOPRODUCIDO2] ON [COSTOCPOPRODUCIDO] ([TIPOSCPOCod] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ICOSTOCPOPRODUCIDO3] ON [COSTOCPOPRODUCIDO] ([IndicadoresCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [ICOSTOCPOPRODUCIDO3] ON [COSTOCPOPRODUCIDO] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ICOSTOCPOPRODUCIDO3] ON [COSTOCPOPRODUCIDO] ([IndicadoresCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ICOSTOCPOPRODUCIDO4] ON [COSTOCPOPRODUCIDO] ([Cod_Area] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [ICOSTOCPOPRODUCIDO4] ON [COSTOCPOPRODUCIDO] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ICOSTOCPOPRODUCIDO4] ON [COSTOCPOPRODUCIDO] ([Cod_Area] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTIPOSCPO( )
      {
         string cmdBuffer = "";
         /* Indices for table TIPOSCPO */
         try
         {
            cmdBuffer=" CREATE TABLE [TIPOSCPO] ([TIPOSCPOCod] nvarchar(120) NOT NULL , [TIPOSCPONom] nvarchar(150) NOT NULL , PRIMARY KEY([TIPOSCPOCod]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[TIPOSCPO]") ;
               cmdBuffer=" DROP TABLE [TIPOSCPO] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[TIPOSCPO]") ;
                  cmdBuffer=" DROP VIEW [TIPOSCPO] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[TIPOSCPO]") ;
                     cmdBuffer=" DROP FUNCTION [TIPOSCPO] "
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
            cmdBuffer=" CREATE TABLE [TIPOSCPO] ([TIPOSCPOCod] nvarchar(120) NOT NULL , [TIPOSCPONom] nvarchar(150) NOT NULL , PRIMARY KEY([TIPOSCPOCod]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateMARGENEBITDA( )
      {
         string cmdBuffer = "";
         /* Indices for table MARGENEBITDA */
         try
         {
            cmdBuffer=" CREATE TABLE [MARGENEBITDA] ([MARGENEBITDAFecha] datetime NOT NULL , [MARGENEBITDAMes] smallint NOT NULL , [MARGENEBITDAAno] smallint NOT NULL , [Cod_Area] nvarchar(40) NOT NULL , [IndicadoresCodigo] nvarchar(40) NOT NULL , [MOTIVOMARGENCod] nvarchar(40) NOT NULL , [MARGENEBITDAValor] money NOT NULL , [MARGENEBITDAuser] nvarchar(150) NOT NULL , [MARGENEBITDAfec] datetime NOT NULL , [MARGENEBITDAhor] nvarchar(40) NOT NULL , PRIMARY KEY([MARGENEBITDAFecha], [MARGENEBITDAMes], [MARGENEBITDAAno], [Cod_Area], [IndicadoresCodigo], [MOTIVOMARGENCod]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[MARGENEBITDA]") ;
               cmdBuffer=" DROP TABLE [MARGENEBITDA] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[MARGENEBITDA]") ;
                  cmdBuffer=" DROP VIEW [MARGENEBITDA] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[MARGENEBITDA]") ;
                     cmdBuffer=" DROP FUNCTION [MARGENEBITDA] "
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
            cmdBuffer=" CREATE TABLE [MARGENEBITDA] ([MARGENEBITDAFecha] datetime NOT NULL , [MARGENEBITDAMes] smallint NOT NULL , [MARGENEBITDAAno] smallint NOT NULL , [Cod_Area] nvarchar(40) NOT NULL , [IndicadoresCodigo] nvarchar(40) NOT NULL , [MOTIVOMARGENCod] nvarchar(40) NOT NULL , [MARGENEBITDAValor] money NOT NULL , [MARGENEBITDAuser] nvarchar(150) NOT NULL , [MARGENEBITDAfec] datetime NOT NULL , [MARGENEBITDAhor] nvarchar(40) NOT NULL , PRIMARY KEY([MARGENEBITDAFecha], [MARGENEBITDAMes], [MARGENEBITDAAno], [Cod_Area], [IndicadoresCodigo], [MOTIVOMARGENCod]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IMARGENEBITDA1] ON [MARGENEBITDA] ([MOTIVOMARGENCod] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IMARGENEBITDA1] ON [MARGENEBITDA] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IMARGENEBITDA1] ON [MARGENEBITDA] ([MOTIVOMARGENCod] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IMARGENEBITDA2] ON [MARGENEBITDA] ([IndicadoresCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IMARGENEBITDA2] ON [MARGENEBITDA] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IMARGENEBITDA2] ON [MARGENEBITDA] ([IndicadoresCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IMARGENEBITDA3] ON [MARGENEBITDA] ([Cod_Area] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IMARGENEBITDA3] ON [MARGENEBITDA] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IMARGENEBITDA3] ON [MARGENEBITDA] ([Cod_Area] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateMOTIVOMARGEN( )
      {
         string cmdBuffer = "";
         /* Indices for table MOTIVOMARGEN */
         try
         {
            cmdBuffer=" CREATE TABLE [MOTIVOMARGEN] ([MOTIVOMARGENCod] nvarchar(40) NOT NULL , [MOTIVOMARGENNom] nvarchar(250) NOT NULL , PRIMARY KEY([MOTIVOMARGENCod]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[MOTIVOMARGEN]") ;
               cmdBuffer=" DROP TABLE [MOTIVOMARGEN] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[MOTIVOMARGEN]") ;
                  cmdBuffer=" DROP VIEW [MOTIVOMARGEN] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[MOTIVOMARGEN]") ;
                     cmdBuffer=" DROP FUNCTION [MOTIVOMARGEN] "
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
            cmdBuffer=" CREATE TABLE [MOTIVOMARGEN] ([MOTIVOMARGENCod] nvarchar(40) NOT NULL , [MOTIVOMARGENNom] nvarchar(250) NOT NULL , PRIMARY KEY([MOTIVOMARGENCod]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateINCIDENCIAPC( )
      {
         string cmdBuffer = "";
         /* Indices for table INCIDENCIAPC */
         try
         {
            cmdBuffer=" CREATE TABLE [INCIDENCIAPC] ([INCIDENCIAPCFec] datetime NOT NULL , [INCIDENCIAPCMes] smallint NOT NULL , [INCIDENCIAPCano] smallint NOT NULL , [Cod_Area] nvarchar(40) NOT NULL , [IndicadoresCodigo] nvarchar(40) NOT NULL , [TiposEnfermedadesCod] nvarchar(40) NOT NULL , [MATERIALPALMASCOD] nvarchar(140) NOT NULL , [INCIDENCIAPCZONA] nvarchar(40) NOT NULL , [INCIDENCIAPCLOTE] nvarchar(40) NOT NULL , [INCIDENCIAPCCasos] money NOT NULL , [INCIDENCIAPCPalmas] decimal( 12) NOT NULL , [INCIDENCIAPCuser] nvarchar(150) NOT NULL , [INCIDENCIAPCreg] datetime NOT NULL , [INCIDENCIAPChor] nvarchar(40) NOT NULL , [INCIDENCIAPCUMA] nvarchar(40) NOT NULL , [INCIDENCIAPCSIEMBRA] decimal( 12) NOT NULL , [INCIDENCIAPCGRUPOZONA] nvarchar(40) NOT NULL , PRIMARY KEY([INCIDENCIAPCFec], [INCIDENCIAPCMes], [INCIDENCIAPCano], [Cod_Area], [IndicadoresCodigo], [TiposEnfermedadesCod], [MATERIALPALMASCOD], [INCIDENCIAPCZONA], [INCIDENCIAPCLOTE]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[INCIDENCIAPC]") ;
               cmdBuffer=" DROP TABLE [INCIDENCIAPC] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[INCIDENCIAPC]") ;
                  cmdBuffer=" DROP VIEW [INCIDENCIAPC] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[INCIDENCIAPC]") ;
                     cmdBuffer=" DROP FUNCTION [INCIDENCIAPC] "
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
            cmdBuffer=" CREATE TABLE [INCIDENCIAPC] ([INCIDENCIAPCFec] datetime NOT NULL , [INCIDENCIAPCMes] smallint NOT NULL , [INCIDENCIAPCano] smallint NOT NULL , [Cod_Area] nvarchar(40) NOT NULL , [IndicadoresCodigo] nvarchar(40) NOT NULL , [TiposEnfermedadesCod] nvarchar(40) NOT NULL , [MATERIALPALMASCOD] nvarchar(140) NOT NULL , [INCIDENCIAPCZONA] nvarchar(40) NOT NULL , [INCIDENCIAPCLOTE] nvarchar(40) NOT NULL , [INCIDENCIAPCCasos] money NOT NULL , [INCIDENCIAPCPalmas] decimal( 12) NOT NULL , [INCIDENCIAPCuser] nvarchar(150) NOT NULL , [INCIDENCIAPCreg] datetime NOT NULL , [INCIDENCIAPChor] nvarchar(40) NOT NULL , [INCIDENCIAPCUMA] nvarchar(40) NOT NULL , [INCIDENCIAPCSIEMBRA] decimal( 12) NOT NULL , [INCIDENCIAPCGRUPOZONA] nvarchar(40) NOT NULL , PRIMARY KEY([INCIDENCIAPCFec], [INCIDENCIAPCMes], [INCIDENCIAPCano], [Cod_Area], [IndicadoresCodigo], [TiposEnfermedadesCod], [MATERIALPALMASCOD], [INCIDENCIAPCZONA], [INCIDENCIAPCLOTE]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IINCIDENCIAPC3] ON [INCIDENCIAPC] ([IndicadoresCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IINCIDENCIAPC3] ON [INCIDENCIAPC] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IINCIDENCIAPC3] ON [INCIDENCIAPC] ([IndicadoresCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IINCIDENCIAPC4] ON [INCIDENCIAPC] ([Cod_Area] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IINCIDENCIAPC4] ON [INCIDENCIAPC] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IINCIDENCIAPC4] ON [INCIDENCIAPC] ([Cod_Area] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IINCIDENCIAPC1] ON [INCIDENCIAPC] ([MATERIALPALMASCOD] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IINCIDENCIAPC1] ON [INCIDENCIAPC] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IINCIDENCIAPC1] ON [INCIDENCIAPC] ([MATERIALPALMASCOD] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IINCIDENCIAPC2] ON [INCIDENCIAPC] ([TiposEnfermedadesCod] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IINCIDENCIAPC2] ON [INCIDENCIAPC] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IINCIDENCIAPC2] ON [INCIDENCIAPC] ([TiposEnfermedadesCod] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateCOSTONRFFPROD( )
      {
         string cmdBuffer = "";
         /* Indices for table COSTONRFFPROD */
         try
         {
            cmdBuffer=" CREATE TABLE [COSTONRFFPROD] ([COSTONRFFPRODfec] datetime NOT NULL , [COSTONRFFPRODmes] smallint NOT NULL , [COSTONRFFPRODano] smallint NOT NULL , [Cod_Area] nvarchar(40) NOT NULL , [IndicadoresCodigo] nvarchar(40) NOT NULL , [COSTONRFFPRODValoEjec] money NOT NULL , PRIMARY KEY([COSTONRFFPRODfec], [COSTONRFFPRODmes], [COSTONRFFPRODano], [Cod_Area], [IndicadoresCodigo]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[COSTONRFFPROD]") ;
               cmdBuffer=" DROP TABLE [COSTONRFFPROD] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[COSTONRFFPROD]") ;
                  cmdBuffer=" DROP VIEW [COSTONRFFPROD] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[COSTONRFFPROD]") ;
                     cmdBuffer=" DROP FUNCTION [COSTONRFFPROD] "
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
            cmdBuffer=" CREATE TABLE [COSTONRFFPROD] ([COSTONRFFPRODfec] datetime NOT NULL , [COSTONRFFPRODmes] smallint NOT NULL , [COSTONRFFPRODano] smallint NOT NULL , [Cod_Area] nvarchar(40) NOT NULL , [IndicadoresCodigo] nvarchar(40) NOT NULL , [COSTONRFFPRODValoEjec] money NOT NULL , PRIMARY KEY([COSTONRFFPRODfec], [COSTONRFFPRODmes], [COSTONRFFPRODano], [Cod_Area], [IndicadoresCodigo]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ICOSTONRFFPROD1] ON [COSTONRFFPROD] ([IndicadoresCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [ICOSTONRFFPROD1] ON [COSTONRFFPROD] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ICOSTONRFFPROD1] ON [COSTONRFFPROD] ([IndicadoresCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ICOSTONRFFPROD2] ON [COSTONRFFPROD] ([Cod_Area] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [ICOSTONRFFPROD2] ON [COSTONRFFPROD] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ICOSTONRFFPROD2] ON [COSTONRFFPROD] ([Cod_Area] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateHATRABAJADORES( )
      {
         string cmdBuffer = "";
         /* Indices for table HATRABAJADORES */
         try
         {
            cmdBuffer=" CREATE TABLE [HATRABAJADORES] ([HATRABAJADORESFecha] datetime NOT NULL , [HATRABAJADORESMes] smallint NOT NULL , [HATRABAJADORESAno] smallint NOT NULL , [Cod_Area] nvarchar(40) NOT NULL , [IndicadoresCodigo] nvarchar(40) NOT NULL , [HATRABAJADORESTotHas] money NOT NULL , [HATRABAJADORESTotTrab] int NOT NULL , [HATRABAJADORESuser] nvarchar(140) NOT NULL , [HATRABAJADORESreg] datetime NOT NULL , [HATRABAJADOREShor] nvarchar(40) NOT NULL , PRIMARY KEY([HATRABAJADORESFecha], [HATRABAJADORESMes], [HATRABAJADORESAno], [Cod_Area], [IndicadoresCodigo]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[HATRABAJADORES]") ;
               cmdBuffer=" DROP TABLE [HATRABAJADORES] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[HATRABAJADORES]") ;
                  cmdBuffer=" DROP VIEW [HATRABAJADORES] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[HATRABAJADORES]") ;
                     cmdBuffer=" DROP FUNCTION [HATRABAJADORES] "
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
            cmdBuffer=" CREATE TABLE [HATRABAJADORES] ([HATRABAJADORESFecha] datetime NOT NULL , [HATRABAJADORESMes] smallint NOT NULL , [HATRABAJADORESAno] smallint NOT NULL , [Cod_Area] nvarchar(40) NOT NULL , [IndicadoresCodigo] nvarchar(40) NOT NULL , [HATRABAJADORESTotHas] money NOT NULL , [HATRABAJADORESTotTrab] int NOT NULL , [HATRABAJADORESuser] nvarchar(140) NOT NULL , [HATRABAJADORESreg] datetime NOT NULL , [HATRABAJADOREShor] nvarchar(40) NOT NULL , PRIMARY KEY([HATRABAJADORESFecha], [HATRABAJADORESMes], [HATRABAJADORESAno], [Cod_Area], [IndicadoresCodigo]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IHATRABAJADORES1] ON [HATRABAJADORES] ([IndicadoresCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IHATRABAJADORES1] ON [HATRABAJADORES] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IHATRABAJADORES1] ON [HATRABAJADORES] ([IndicadoresCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IHATRABAJADORES2] ON [HATRABAJADORES] ([Cod_Area] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IHATRABAJADORES2] ON [HATRABAJADORES] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IHATRABAJADORES2] ON [HATRABAJADORES] ([Cod_Area] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTONCPOHA( )
      {
         string cmdBuffer = "";
         /* Indices for table TONCPOHA */
         try
         {
            cmdBuffer=" CREATE TABLE [TONCPOHA] ([TONCPOHAFecha] datetime NOT NULL , [TONCPOHAMes] smallint NOT NULL , [TONCPOHAAno] smallint NOT NULL , [Cod_Area] nvarchar(40) NOT NULL , [IndicadoresCodigo] nvarchar(40) NOT NULL , [TONCPOHAhaproduc] money NOT NULL , [TONCPOHAuse] nvarchar(200) NOT NULL , [TONCPOHAreg] datetime NOT NULL , [TONCPOHAhor] nvarchar(40) NOT NULL , PRIMARY KEY([TONCPOHAFecha], [TONCPOHAMes], [TONCPOHAAno], [Cod_Area], [IndicadoresCodigo]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[TONCPOHA]") ;
               cmdBuffer=" DROP TABLE [TONCPOHA] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[TONCPOHA]") ;
                  cmdBuffer=" DROP VIEW [TONCPOHA] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[TONCPOHA]") ;
                     cmdBuffer=" DROP FUNCTION [TONCPOHA] "
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
            cmdBuffer=" CREATE TABLE [TONCPOHA] ([TONCPOHAFecha] datetime NOT NULL , [TONCPOHAMes] smallint NOT NULL , [TONCPOHAAno] smallint NOT NULL , [Cod_Area] nvarchar(40) NOT NULL , [IndicadoresCodigo] nvarchar(40) NOT NULL , [TONCPOHAhaproduc] money NOT NULL , [TONCPOHAuse] nvarchar(200) NOT NULL , [TONCPOHAreg] datetime NOT NULL , [TONCPOHAhor] nvarchar(40) NOT NULL , PRIMARY KEY([TONCPOHAFecha], [TONCPOHAMes], [TONCPOHAAno], [Cod_Area], [IndicadoresCodigo]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ITONCPOHA1] ON [TONCPOHA] ([IndicadoresCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [ITONCPOHA1] ON [TONCPOHA] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ITONCPOHA1] ON [TONCPOHA] ([IndicadoresCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ITONCPOHA2] ON [TONCPOHA] ([Cod_Area] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [ITONCPOHA2] ON [TONCPOHA] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ITONCPOHA2] ON [TONCPOHA] ([Cod_Area] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateFRUTAPROPIA( )
      {
         string cmdBuffer = "";
         /* Indices for table FRUTAPROPIA */
         try
         {
            cmdBuffer=" CREATE TABLE [FRUTAPROPIA] ([FRUTAPROPIAFecha] datetime NOT NULL , [FRUTAPROPIAMes] smallint NOT NULL , [FRUTAPROPIAAno] smallint NOT NULL , [IndicadoresCodigo] nvarchar(40) NOT NULL , [Cod_Area] nvarchar(40) NOT NULL , [VIAJE] decimal( 12) NOT NULL , [SETOR] nvarchar(40) NOT NULL , [FINCA] nvarchar(150) NOT NULL , [PROVE_COD] nvarchar(150) NOT NULL , [DIA] datetime NOT NULL , [LOTE] nvarchar(40) NOT NULL , [TAL] nvarchar(40) NOT NULL , [FINCA_nom] nvarchar(150) NOT NULL , [PROVE_NOM] nvarchar(150) NOT NULL , [CHOFER] nvarchar(120) NOT NULL , [CABEZAL] nvarchar(120) NOT NULL , [FH_ENT] datetime NOT NULL , [FH_SAI] datetime NOT NULL , [PESO] money NOT NULL , [PESO_NETO] money NOT NULL , [TARA] money NOT NULL , [BRUTO] money NOT NULL , [FORN_ASOCIADO] nvarchar(150) NOT NULL , [NOM_ASOCIADO] nvarchar(200) NOT NULL , [COd_PROPIETARIO] nvarchar(300) NOT NULL , [NOM_PROPIETARIO] nvarchar(300) NOT NULL , [TIPO] smallmoney NOT NULL , [AGRUPACION] nvarchar(40) NOT NULL , [VALOR_TRANSP_AP] decimal( 10) NOT NULL , [HORA_SAI] nvarchar(40) NOT NULL , [HORA_BRUTO] nvarchar(40) NOT NULL , [LOTE_NOM] nvarchar(40) NOT NULL , [TAL_DET] nvarchar(30) NOT NULL , PRIMARY KEY([FRUTAPROPIAFecha], [FRUTAPROPIAMes], [FRUTAPROPIAAno], [IndicadoresCodigo], [Cod_Area], [VIAJE], [SETOR], [FINCA], [PROVE_COD], [DIA], [LOTE], [TAL]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[FRUTAPROPIA]") ;
               cmdBuffer=" DROP TABLE [FRUTAPROPIA] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[FRUTAPROPIA]") ;
                  cmdBuffer=" DROP VIEW [FRUTAPROPIA] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[FRUTAPROPIA]") ;
                     cmdBuffer=" DROP FUNCTION [FRUTAPROPIA] "
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
            cmdBuffer=" CREATE TABLE [FRUTAPROPIA] ([FRUTAPROPIAFecha] datetime NOT NULL , [FRUTAPROPIAMes] smallint NOT NULL , [FRUTAPROPIAAno] smallint NOT NULL , [IndicadoresCodigo] nvarchar(40) NOT NULL , [Cod_Area] nvarchar(40) NOT NULL , [VIAJE] decimal( 12) NOT NULL , [SETOR] nvarchar(40) NOT NULL , [FINCA] nvarchar(150) NOT NULL , [PROVE_COD] nvarchar(150) NOT NULL , [DIA] datetime NOT NULL , [LOTE] nvarchar(40) NOT NULL , [TAL] nvarchar(40) NOT NULL , [FINCA_nom] nvarchar(150) NOT NULL , [PROVE_NOM] nvarchar(150) NOT NULL , [CHOFER] nvarchar(120) NOT NULL , [CABEZAL] nvarchar(120) NOT NULL , [FH_ENT] datetime NOT NULL , [FH_SAI] datetime NOT NULL , [PESO] money NOT NULL , [PESO_NETO] money NOT NULL , [TARA] money NOT NULL , [BRUTO] money NOT NULL , [FORN_ASOCIADO] nvarchar(150) NOT NULL , [NOM_ASOCIADO] nvarchar(200) NOT NULL , [COd_PROPIETARIO] nvarchar(300) NOT NULL , [NOM_PROPIETARIO] nvarchar(300) NOT NULL , [TIPO] smallmoney NOT NULL , [AGRUPACION] nvarchar(40) NOT NULL , [VALOR_TRANSP_AP] decimal( 10) NOT NULL , [HORA_SAI] nvarchar(40) NOT NULL , [HORA_BRUTO] nvarchar(40) NOT NULL , [LOTE_NOM] nvarchar(40) NOT NULL , [TAL_DET] nvarchar(30) NOT NULL , PRIMARY KEY([FRUTAPROPIAFecha], [FRUTAPROPIAMes], [FRUTAPROPIAAno], [IndicadoresCodigo], [Cod_Area], [VIAJE], [SETOR], [FINCA], [PROVE_COD], [DIA], [LOTE], [TAL]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IFRUTAPROPIA1] ON [FRUTAPROPIA] ([Cod_Area] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IFRUTAPROPIA1] ON [FRUTAPROPIA] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IFRUTAPROPIA1] ON [FRUTAPROPIA] ([Cod_Area] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IFRUTAPROPIA2] ON [FRUTAPROPIA] ([IndicadoresCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IFRUTAPROPIA2] ON [FRUTAPROPIA] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IFRUTAPROPIA2] ON [FRUTAPROPIA] ([IndicadoresCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateCOSTONRFFPROCESADA( )
      {
         string cmdBuffer = "";
         /* Indices for table COSTONRFFPROCESADA */
         try
         {
            cmdBuffer=" CREATE TABLE [COSTONRFFPROCESADA] ([COSTONRFFPROCFec] datetime NOT NULL , [COSTONRFFPROCMes] smallint NOT NULL , [COSTONRFFPROCAno] smallint NOT NULL , [Cod_Area] nvarchar(40) NOT NULL , [IndicadoresCodigo] nvarchar(40) NOT NULL , [MOTIVOSCOSRFFPROCod] nvarchar(40) NOT NULL , [COSTONRFFPROCValor] decimal( 14, 4) NOT NULL , PRIMARY KEY([COSTONRFFPROCFec], [COSTONRFFPROCMes], [COSTONRFFPROCAno], [Cod_Area], [IndicadoresCodigo], [MOTIVOSCOSRFFPROCod]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[COSTONRFFPROCESADA]") ;
               cmdBuffer=" DROP TABLE [COSTONRFFPROCESADA] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[COSTONRFFPROCESADA]") ;
                  cmdBuffer=" DROP VIEW [COSTONRFFPROCESADA] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[COSTONRFFPROCESADA]") ;
                     cmdBuffer=" DROP FUNCTION [COSTONRFFPROCESADA] "
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
            cmdBuffer=" CREATE TABLE [COSTONRFFPROCESADA] ([COSTONRFFPROCFec] datetime NOT NULL , [COSTONRFFPROCMes] smallint NOT NULL , [COSTONRFFPROCAno] smallint NOT NULL , [Cod_Area] nvarchar(40) NOT NULL , [IndicadoresCodigo] nvarchar(40) NOT NULL , [MOTIVOSCOSRFFPROCod] nvarchar(40) NOT NULL , [COSTONRFFPROCValor] decimal( 14, 4) NOT NULL , PRIMARY KEY([COSTONRFFPROCFec], [COSTONRFFPROCMes], [COSTONRFFPROCAno], [Cod_Area], [IndicadoresCodigo], [MOTIVOSCOSRFFPROCod]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ICOSTONRFFPROCESADA1] ON [COSTONRFFPROCESADA] ([MOTIVOSCOSRFFPROCod] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [ICOSTONRFFPROCESADA1] ON [COSTONRFFPROCESADA] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ICOSTONRFFPROCESADA1] ON [COSTONRFFPROCESADA] ([MOTIVOSCOSRFFPROCod] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ICOSTONRFFPROCESADA2] ON [COSTONRFFPROCESADA] ([IndicadoresCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [ICOSTONRFFPROCESADA2] ON [COSTONRFFPROCESADA] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ICOSTONRFFPROCESADA2] ON [COSTONRFFPROCESADA] ([IndicadoresCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ICOSTONRFFPROCESADA3] ON [COSTONRFFPROCESADA] ([Cod_Area] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [ICOSTONRFFPROCESADA3] ON [COSTONRFFPROCESADA] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ICOSTONRFFPROCESADA3] ON [COSTONRFFPROCESADA] ([Cod_Area] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateMOTIVOSCOSRFFPRO( )
      {
         string cmdBuffer = "";
         /* Indices for table MOTIVOSCOSRFFPRO */
         try
         {
            cmdBuffer=" CREATE TABLE [MOTIVOSCOSRFFPRO] ([MOTIVOSCOSRFFPROCod] nvarchar(40) NOT NULL , [MOTIVOSCOSRFFPRONom] nvarchar(200) NOT NULL , PRIMARY KEY([MOTIVOSCOSRFFPROCod]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[MOTIVOSCOSRFFPRO]") ;
               cmdBuffer=" DROP TABLE [MOTIVOSCOSRFFPRO] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[MOTIVOSCOSRFFPRO]") ;
                  cmdBuffer=" DROP VIEW [MOTIVOSCOSRFFPRO] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[MOTIVOSCOSRFFPRO]") ;
                     cmdBuffer=" DROP FUNCTION [MOTIVOSCOSRFFPRO] "
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
            cmdBuffer=" CREATE TABLE [MOTIVOSCOSRFFPRO] ([MOTIVOSCOSRFFPROCod] nvarchar(40) NOT NULL , [MOTIVOSCOSRFFPRONom] nvarchar(200) NOT NULL , PRIMARY KEY([MOTIVOSCOSRFFPROCod]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateAcidez( )
      {
         string cmdBuffer = "";
         /* Indices for table Acidez */
         try
         {
            cmdBuffer=" CREATE TABLE [Acidez] ([AcidezFecha] datetime NOT NULL , [AcidezMes] smallint NOT NULL , [AcidezAno] smallint NOT NULL , [Cod_Area] nvarchar(40) NOT NULL , [IndicadoresCodigo] nvarchar(40) NOT NULL , [AcidezValor] decimal( 9, 5) NOT NULL , [AcidezUser] nvarchar(200) NOT NULL , [AcidezReg] datetime NOT NULL , [AcidezHora] nvarchar(40) NOT NULL , PRIMARY KEY([AcidezFecha], [AcidezMes], [AcidezAno], [Cod_Area], [IndicadoresCodigo]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[Acidez]") ;
               cmdBuffer=" DROP TABLE [Acidez] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[Acidez]") ;
                  cmdBuffer=" DROP VIEW [Acidez] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[Acidez]") ;
                     cmdBuffer=" DROP FUNCTION [Acidez] "
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
            cmdBuffer=" CREATE TABLE [Acidez] ([AcidezFecha] datetime NOT NULL , [AcidezMes] smallint NOT NULL , [AcidezAno] smallint NOT NULL , [Cod_Area] nvarchar(40) NOT NULL , [IndicadoresCodigo] nvarchar(40) NOT NULL , [AcidezValor] decimal( 9, 5) NOT NULL , [AcidezUser] nvarchar(200) NOT NULL , [AcidezReg] datetime NOT NULL , [AcidezHora] nvarchar(40) NOT NULL , PRIMARY KEY([AcidezFecha], [AcidezMes], [AcidezAno], [Cod_Area], [IndicadoresCodigo]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IACIDEZ1] ON [Acidez] ([IndicadoresCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IACIDEZ1] ON [Acidez] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IACIDEZ1] ON [Acidez] ([IndicadoresCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IACIDEZ2] ON [Acidez] ([Cod_Area] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IACIDEZ2] ON [Acidez] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IACIDEZ2] ON [Acidez] ([Cod_Area] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateClientes( )
      {
         string cmdBuffer = "";
         /* Indices for table Clientes */
         try
         {
            cmdBuffer=" CREATE TABLE [Clientes] ([ClientesCodigo] nvarchar(40) NOT NULL , [ClientesNombres] nvarchar(300) NOT NULL , [ClientesInterno] smallint NOT NULL , PRIMARY KEY([ClientesCodigo]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[Clientes]") ;
               cmdBuffer=" DROP TABLE [Clientes] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[Clientes]") ;
                  cmdBuffer=" DROP VIEW [Clientes] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[Clientes]") ;
                     cmdBuffer=" DROP FUNCTION [Clientes] "
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
            cmdBuffer=" CREATE TABLE [Clientes] ([ClientesCodigo] nvarchar(40) NOT NULL , [ClientesNombres] nvarchar(300) NOT NULL , [ClientesInterno] smallint NOT NULL , PRIMARY KEY([ClientesCodigo]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateVentas( )
      {
         string cmdBuffer = "";
         /* Indices for table Ventas */
         try
         {
            cmdBuffer=" CREATE TABLE [Ventas] ([VentasFecha] datetime NOT NULL , [VentasMes] smallint NOT NULL , [VentasAno] smallint NOT NULL , [TipoProductoCod] nvarchar(40) NOT NULL , [VentasValor] money NOT NULL , [ClientesCodigo] nvarchar(40) NOT NULL , PRIMARY KEY([VentasFecha], [VentasMes], [VentasAno], [TipoProductoCod]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[Ventas]") ;
               cmdBuffer=" DROP TABLE [Ventas] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[Ventas]") ;
                  cmdBuffer=" DROP VIEW [Ventas] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[Ventas]") ;
                     cmdBuffer=" DROP FUNCTION [Ventas] "
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
            cmdBuffer=" CREATE TABLE [Ventas] ([VentasFecha] datetime NOT NULL , [VentasMes] smallint NOT NULL , [VentasAno] smallint NOT NULL , [TipoProductoCod] nvarchar(40) NOT NULL , [VentasValor] money NOT NULL , [ClientesCodigo] nvarchar(40) NOT NULL , PRIMARY KEY([VentasFecha], [VentasMes], [VentasAno], [TipoProductoCod]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IVENTAS1] ON [Ventas] ([TipoProductoCod] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IVENTAS1] ON [Ventas] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IVENTAS1] ON [Ventas] ([TipoProductoCod] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IVENTAS2] ON [Ventas] ([ClientesCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IVENTAS2] ON [Ventas] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IVENTAS2] ON [Ventas] ([ClientesCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTipoProducto( )
      {
         string cmdBuffer = "";
         /* Indices for table TipoProducto */
         try
         {
            cmdBuffer=" CREATE TABLE [TipoProducto] ([TipoProductoCod] nvarchar(40) NOT NULL , [TipoProductoNombre] nvarchar(40) NOT NULL , PRIMARY KEY([TipoProductoCod]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[TipoProducto]") ;
               cmdBuffer=" DROP TABLE [TipoProducto] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[TipoProducto]") ;
                  cmdBuffer=" DROP VIEW [TipoProducto] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[TipoProducto]") ;
                     cmdBuffer=" DROP FUNCTION [TipoProducto] "
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
            cmdBuffer=" CREATE TABLE [TipoProducto] ([TipoProductoCod] nvarchar(40) NOT NULL , [TipoProductoNombre] nvarchar(40) NOT NULL , PRIMARY KEY([TipoProductoCod]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTEA( )
      {
         string cmdBuffer = "";
         /* Indices for table TEA */
         try
         {
            cmdBuffer=" CREATE TABLE [TEA] ([TEAFecha] datetime NOT NULL , [TEAMes] smallint NOT NULL , [TEAAno] smallint NOT NULL , [IndicadoresCodigo] nvarchar(40) NOT NULL , [Cod_Area] nvarchar(40) NOT NULL , [TEAValor] money NOT NULL , PRIMARY KEY([TEAFecha], [TEAMes], [TEAAno], [IndicadoresCodigo], [Cod_Area]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[TEA]") ;
               cmdBuffer=" DROP TABLE [TEA] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[TEA]") ;
                  cmdBuffer=" DROP VIEW [TEA] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[TEA]") ;
                     cmdBuffer=" DROP FUNCTION [TEA] "
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
            cmdBuffer=" CREATE TABLE [TEA] ([TEAFecha] datetime NOT NULL , [TEAMes] smallint NOT NULL , [TEAAno] smallint NOT NULL , [IndicadoresCodigo] nvarchar(40) NOT NULL , [Cod_Area] nvarchar(40) NOT NULL , [TEAValor] money NOT NULL , PRIMARY KEY([TEAFecha], [TEAMes], [TEAAno], [IndicadoresCodigo], [Cod_Area]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ITEA1] ON [TEA] ([Cod_Area] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [ITEA1] ON [TEA] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ITEA1] ON [TEA] ([Cod_Area] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ITEA2] ON [TEA] ([IndicadoresCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [ITEA2] ON [TEA] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ITEA2] ON [TEA] ([IndicadoresCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateFRUTOPROCESADO( )
      {
         string cmdBuffer = "";
         /* Indices for table FRUTOPROCESADO */
         try
         {
            cmdBuffer=" CREATE TABLE [FRUTOPROCESADO] ([FRUTOPROCESADOFec] datetime NOT NULL , [FRUTOPROCESADOMes] smallint NOT NULL , [FRUTOPROCESADOAno] smallint NOT NULL , [Cod_Area] nvarchar(40) NOT NULL , [IndicadoresCodigo] nvarchar(40) NOT NULL , [FRUTOPROCESADOValor] money NOT NULL , [FRUTOPROCESADOUser] nvarchar(200) NOT NULL , [FRUTOPROCESADOReg] datetime NOT NULL , [FRUTOPROCESADOHor] nvarchar(40) NOT NULL , PRIMARY KEY([FRUTOPROCESADOFec], [FRUTOPROCESADOMes], [FRUTOPROCESADOAno], [Cod_Area], [IndicadoresCodigo]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[FRUTOPROCESADO]") ;
               cmdBuffer=" DROP TABLE [FRUTOPROCESADO] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[FRUTOPROCESADO]") ;
                  cmdBuffer=" DROP VIEW [FRUTOPROCESADO] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[FRUTOPROCESADO]") ;
                     cmdBuffer=" DROP FUNCTION [FRUTOPROCESADO] "
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
            cmdBuffer=" CREATE TABLE [FRUTOPROCESADO] ([FRUTOPROCESADOFec] datetime NOT NULL , [FRUTOPROCESADOMes] smallint NOT NULL , [FRUTOPROCESADOAno] smallint NOT NULL , [Cod_Area] nvarchar(40) NOT NULL , [IndicadoresCodigo] nvarchar(40) NOT NULL , [FRUTOPROCESADOValor] money NOT NULL , [FRUTOPROCESADOUser] nvarchar(200) NOT NULL , [FRUTOPROCESADOReg] datetime NOT NULL , [FRUTOPROCESADOHor] nvarchar(40) NOT NULL , PRIMARY KEY([FRUTOPROCESADOFec], [FRUTOPROCESADOMes], [FRUTOPROCESADOAno], [Cod_Area], [IndicadoresCodigo]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IFRUTOPROCESADO1] ON [FRUTOPROCESADO] ([IndicadoresCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IFRUTOPROCESADO1] ON [FRUTOPROCESADO] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IFRUTOPROCESADO1] ON [FRUTOPROCESADO] ([IndicadoresCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IFRUTOPROCESADO2] ON [FRUTOPROCESADO] ([Cod_Area] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IFRUTOPROCESADO2] ON [FRUTOPROCESADO] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IFRUTOPROCESADO2] ON [FRUTOPROCESADO] ([Cod_Area] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateCOSTOCPOHA( )
      {
         string cmdBuffer = "";
         /* Indices for table COSTOCPOHA */
         try
         {
            cmdBuffer=" CREATE TABLE [COSTOCPOHA] ([COSTOCPOHAFecha] datetime NOT NULL , [COSTOCPOHAAno] smallint NOT NULL , [COSTOCPOHAMes] smallint NOT NULL , [Cod_Area] nvarchar(40) NOT NULL , [IndicadoresCodigo] nvarchar(40) NOT NULL , [COSTOCPOHAValor] money NOT NULL , [COSTOCPOHAUser] nvarchar(240) NOT NULL , [COSTOCPOHAReg] datetime NOT NULL , [COSTOCPOHAHor] nvarchar(40) NOT NULL , PRIMARY KEY([COSTOCPOHAFecha], [COSTOCPOHAAno], [COSTOCPOHAMes], [Cod_Area], [IndicadoresCodigo]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[COSTOCPOHA]") ;
               cmdBuffer=" DROP TABLE [COSTOCPOHA] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[COSTOCPOHA]") ;
                  cmdBuffer=" DROP VIEW [COSTOCPOHA] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[COSTOCPOHA]") ;
                     cmdBuffer=" DROP FUNCTION [COSTOCPOHA] "
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
            cmdBuffer=" CREATE TABLE [COSTOCPOHA] ([COSTOCPOHAFecha] datetime NOT NULL , [COSTOCPOHAAno] smallint NOT NULL , [COSTOCPOHAMes] smallint NOT NULL , [Cod_Area] nvarchar(40) NOT NULL , [IndicadoresCodigo] nvarchar(40) NOT NULL , [COSTOCPOHAValor] money NOT NULL , [COSTOCPOHAUser] nvarchar(240) NOT NULL , [COSTOCPOHAReg] datetime NOT NULL , [COSTOCPOHAHor] nvarchar(40) NOT NULL , PRIMARY KEY([COSTOCPOHAFecha], [COSTOCPOHAAno], [COSTOCPOHAMes], [Cod_Area], [IndicadoresCodigo]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ICOSTOCPOHA1] ON [COSTOCPOHA] ([IndicadoresCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [ICOSTOCPOHA1] ON [COSTOCPOHA] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ICOSTOCPOHA1] ON [COSTOCPOHA] ([IndicadoresCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ICOSTOCPOHA2] ON [COSTOCPOHA] ([Cod_Area] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [ICOSTOCPOHA2] ON [COSTOCPOHA] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ICOSTOCPOHA2] ON [COSTOCPOHA] ([Cod_Area] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateParametros( )
      {
         string cmdBuffer = "";
         /* Indices for table Parametros */
         try
         {
            cmdBuffer=" CREATE TABLE [Parametros] ([ParametrosCodigo] smallint NOT NULL , [ParametrosNombres] nvarchar(200) NOT NULL , [ParametrosTipo] nvarchar(20) NOT NULL , [IndicadoresCodigo] nvarchar(40) NOT NULL , [ParametrosMes] smallint NOT NULL , [ParametrosAno] smallint NOT NULL , [ParametrosValor] decimal( 14, 4) NOT NULL , PRIMARY KEY([ParametrosCodigo]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[Parametros]") ;
               cmdBuffer=" DROP TABLE [Parametros] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[Parametros]") ;
                  cmdBuffer=" DROP VIEW [Parametros] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[Parametros]") ;
                     cmdBuffer=" DROP FUNCTION [Parametros] "
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
            cmdBuffer=" CREATE TABLE [Parametros] ([ParametrosCodigo] smallint NOT NULL , [ParametrosNombres] nvarchar(200) NOT NULL , [ParametrosTipo] nvarchar(20) NOT NULL , [IndicadoresCodigo] nvarchar(40) NOT NULL , [ParametrosMes] smallint NOT NULL , [ParametrosAno] smallint NOT NULL , [ParametrosValor] decimal( 14, 4) NOT NULL , PRIMARY KEY([ParametrosCodigo]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IPARAMETROS1] ON [Parametros] ([IndicadoresCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IPARAMETROS1] ON [Parametros] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IPARAMETROS1] ON [Parametros] ([IndicadoresCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateMotivosMetas( )
      {
         string cmdBuffer = "";
         /* Indices for table MotivosMetas */
         try
         {
            cmdBuffer=" CREATE TABLE [MotivosMetas] ([MotivosMetasCodigo] nvarchar(40) NOT NULL , [MotivosMetasNombres] nvarchar(140) NOT NULL , PRIMARY KEY([MotivosMetasCodigo]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[MotivosMetas]") ;
               cmdBuffer=" DROP TABLE [MotivosMetas] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[MotivosMetas]") ;
                  cmdBuffer=" DROP VIEW [MotivosMetas] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[MotivosMetas]") ;
                     cmdBuffer=" DROP FUNCTION [MotivosMetas] "
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
            cmdBuffer=" CREATE TABLE [MotivosMetas] ([MotivosMetasCodigo] nvarchar(40) NOT NULL , [MotivosMetasNombres] nvarchar(140) NOT NULL , PRIMARY KEY([MotivosMetasCodigo]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateMetasIndicadores( )
      {
         string cmdBuffer = "";
         /* Indices for table MetasIndicadores */
         try
         {
            cmdBuffer=" CREATE TABLE [MetasIndicadores] ([IndicadoresCodigo] nvarchar(40) NOT NULL , [MetasIndicadoresMes] smallint NOT NULL , [MetasIndicadoresAno] smallint NOT NULL , [TipoMetasCodigo] nvarchar(40) NOT NULL , [MetasIndicadoresValorMes] money NOT NULL , [MetasIndicadoresTicketNro] decimal( 10) NOT NULL , [UsuariosCodigo] nvarchar(150) NOT NULL , [MotivosMetasCodigo] nvarchar(40) NOT NULL , [MetasIndicadoresReg] datetime NOT NULL , [MetasIndicadoresHor] nvarchar(40) NOT NULL , [MetasIndicadoresValorAno] money NOT NULL , PRIMARY KEY([IndicadoresCodigo], [MetasIndicadoresMes], [MetasIndicadoresAno], [TipoMetasCodigo]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[MetasIndicadores]") ;
               cmdBuffer=" DROP TABLE [MetasIndicadores] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[MetasIndicadores]") ;
                  cmdBuffer=" DROP VIEW [MetasIndicadores] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[MetasIndicadores]") ;
                     cmdBuffer=" DROP FUNCTION [MetasIndicadores] "
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
            cmdBuffer=" CREATE TABLE [MetasIndicadores] ([IndicadoresCodigo] nvarchar(40) NOT NULL , [MetasIndicadoresMes] smallint NOT NULL , [MetasIndicadoresAno] smallint NOT NULL , [TipoMetasCodigo] nvarchar(40) NOT NULL , [MetasIndicadoresValorMes] money NOT NULL , [MetasIndicadoresTicketNro] decimal( 10) NOT NULL , [UsuariosCodigo] nvarchar(150) NOT NULL , [MotivosMetasCodigo] nvarchar(40) NOT NULL , [MetasIndicadoresReg] datetime NOT NULL , [MetasIndicadoresHor] nvarchar(40) NOT NULL , [MetasIndicadoresValorAno] money NOT NULL , PRIMARY KEY([IndicadoresCodigo], [MetasIndicadoresMes], [MetasIndicadoresAno], [TipoMetasCodigo]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IMETASINDICADORES1] ON [MetasIndicadores] ([UsuariosCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IMETASINDICADORES1] ON [MetasIndicadores] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IMETASINDICADORES1] ON [MetasIndicadores] ([UsuariosCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IMETASINDICADORES2] ON [MetasIndicadores] ([TipoMetasCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IMETASINDICADORES2] ON [MetasIndicadores] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IMETASINDICADORES2] ON [MetasIndicadores] ([TipoMetasCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IMETASINDICADORES4] ON [MetasIndicadores] ([MotivosMetasCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IMETASINDICADORES4] ON [MetasIndicadores] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IMETASINDICADORES4] ON [MetasIndicadores] ([MotivosMetasCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTipoMetas( )
      {
         string cmdBuffer = "";
         /* Indices for table TipoMetas */
         try
         {
            cmdBuffer=" CREATE TABLE [TipoMetas] ([TipoMetasCodigo] nvarchar(40) NOT NULL , [TipoMetasNombres] nvarchar(40) NOT NULL , PRIMARY KEY([TipoMetasCodigo]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[TipoMetas]") ;
               cmdBuffer=" DROP TABLE [TipoMetas] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[TipoMetas]") ;
                  cmdBuffer=" DROP VIEW [TipoMetas] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[TipoMetas]") ;
                     cmdBuffer=" DROP FUNCTION [TipoMetas] "
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
            cmdBuffer=" CREATE TABLE [TipoMetas] ([TipoMetasCodigo] nvarchar(40) NOT NULL , [TipoMetasNombres] nvarchar(40) NOT NULL , PRIMARY KEY([TipoMetasCodigo]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreatePAGOFRUTA( )
      {
         string cmdBuffer = "";
         /* Indices for table PAGOFRUTA */
         try
         {
            cmdBuffer=" CREATE TABLE [PAGOFRUTA] ([PAGOFRUTAFecha] datetime NOT NULL , [PAGOFRUTAMes] smallint NOT NULL , [PAGOFRUTAAno] smallint NOT NULL , [Cod_Area] nvarchar(40) NOT NULL , [IndicadoresCodigo] nvarchar(40) NOT NULL , [MotivosUspCodigo] nvarchar(40) NOT NULL , [PAGOFRUTAValor] money NOT NULL , PRIMARY KEY([PAGOFRUTAFecha], [PAGOFRUTAMes], [PAGOFRUTAAno], [Cod_Area], [IndicadoresCodigo], [MotivosUspCodigo]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[PAGOFRUTA]") ;
               cmdBuffer=" DROP TABLE [PAGOFRUTA] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[PAGOFRUTA]") ;
                  cmdBuffer=" DROP VIEW [PAGOFRUTA] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[PAGOFRUTA]") ;
                     cmdBuffer=" DROP FUNCTION [PAGOFRUTA] "
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
            cmdBuffer=" CREATE TABLE [PAGOFRUTA] ([PAGOFRUTAFecha] datetime NOT NULL , [PAGOFRUTAMes] smallint NOT NULL , [PAGOFRUTAAno] smallint NOT NULL , [Cod_Area] nvarchar(40) NOT NULL , [IndicadoresCodigo] nvarchar(40) NOT NULL , [MotivosUspCodigo] nvarchar(40) NOT NULL , [PAGOFRUTAValor] money NOT NULL , PRIMARY KEY([PAGOFRUTAFecha], [PAGOFRUTAMes], [PAGOFRUTAAno], [Cod_Area], [IndicadoresCodigo], [MotivosUspCodigo]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IPAGOFRUTA1] ON [PAGOFRUTA] ([MotivosUspCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IPAGOFRUTA1] ON [PAGOFRUTA] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IPAGOFRUTA1] ON [PAGOFRUTA] ([MotivosUspCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IPAGOFRUTA2] ON [PAGOFRUTA] ([IndicadoresCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IPAGOFRUTA2] ON [PAGOFRUTA] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IPAGOFRUTA2] ON [PAGOFRUTA] ([IndicadoresCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IPAGOFRUTA3] ON [PAGOFRUTA] ([Cod_Area] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IPAGOFRUTA3] ON [PAGOFRUTA] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IPAGOFRUTA3] ON [PAGOFRUTA] ([Cod_Area] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateMotivosUsp( )
      {
         string cmdBuffer = "";
         /* Indices for table MotivosUsp */
         try
         {
            cmdBuffer=" CREATE TABLE [MotivosUsp] ([MotivosUspCodigo] nvarchar(40) NOT NULL , [MotivosUspNombres] nvarchar(120) NOT NULL , PRIMARY KEY([MotivosUspCodigo]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[MotivosUsp]") ;
               cmdBuffer=" DROP TABLE [MotivosUsp] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[MotivosUsp]") ;
                  cmdBuffer=" DROP VIEW [MotivosUsp] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[MotivosUsp]") ;
                     cmdBuffer=" DROP FUNCTION [MotivosUsp] "
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
            cmdBuffer=" CREATE TABLE [MotivosUsp] ([MotivosUspCodigo] nvarchar(40) NOT NULL , [MotivosUspNombres] nvarchar(120) NOT NULL , PRIMARY KEY([MotivosUspCodigo]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateCOSUSPTONFRUTA( )
      {
         string cmdBuffer = "";
         /* Indices for table COSUSPTONFRUTA */
         try
         {
            cmdBuffer=" CREATE TABLE [COSUSPTONFRUTA] ([COSUSPTONFRUTAFecha] datetime NOT NULL , [COSUSPTONFRUTAMes] smallint NOT NULL , [COSUSPTONFRUTAAno] smallint NOT NULL , [Cod_Area] nvarchar(40) NOT NULL , [IndicadoresCodigo] nvarchar(40) NOT NULL , [COSUSPTONFRUTAValor] decimal( 11, 5) NOT NULL , PRIMARY KEY([COSUSPTONFRUTAFecha], [COSUSPTONFRUTAMes], [COSUSPTONFRUTAAno], [Cod_Area], [IndicadoresCodigo]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[COSUSPTONFRUTA]") ;
               cmdBuffer=" DROP TABLE [COSUSPTONFRUTA] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[COSUSPTONFRUTA]") ;
                  cmdBuffer=" DROP VIEW [COSUSPTONFRUTA] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[COSUSPTONFRUTA]") ;
                     cmdBuffer=" DROP FUNCTION [COSUSPTONFRUTA] "
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
            cmdBuffer=" CREATE TABLE [COSUSPTONFRUTA] ([COSUSPTONFRUTAFecha] datetime NOT NULL , [COSUSPTONFRUTAMes] smallint NOT NULL , [COSUSPTONFRUTAAno] smallint NOT NULL , [Cod_Area] nvarchar(40) NOT NULL , [IndicadoresCodigo] nvarchar(40) NOT NULL , [COSUSPTONFRUTAValor] decimal( 11, 5) NOT NULL , PRIMARY KEY([COSUSPTONFRUTAFecha], [COSUSPTONFRUTAMes], [COSUSPTONFRUTAAno], [Cod_Area], [IndicadoresCodigo]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ICOSUSPTONFRUTA1] ON [COSUSPTONFRUTA] ([IndicadoresCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [ICOSUSPTONFRUTA1] ON [COSUSPTONFRUTA] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ICOSUSPTONFRUTA1] ON [COSUSPTONFRUTA] ([IndicadoresCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ICOSUSPTONFRUTA2] ON [COSUSPTONFRUTA] ([Cod_Area] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [ICOSUSPTONFRUTA2] ON [COSUSPTONFRUTA] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ICOSUSPTONFRUTA2] ON [COSUSPTONFRUTA] ([Cod_Area] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTRIF( )
      {
         string cmdBuffer = "";
         /* Indices for table TRIF */
         try
         {
            cmdBuffer=" CREATE TABLE [TRIF] ([TRIFFecha] datetime NOT NULL , [TRIFMes] smallint NOT NULL , [TRIFAno] smallint NOT NULL , [IndicadoresCodigo] nvarchar(40) NOT NULL , [Cod_Area] nvarchar(40) NOT NULL , [TRIF_Valor_ACC] money NOT NULL , [TRIF_Valor_TRAB] money NOT NULL , [TRIF_Dias_PerdidosAtel] decimal( 12) NOT NULL , PRIMARY KEY([TRIFFecha], [TRIFMes], [TRIFAno], [IndicadoresCodigo], [Cod_Area]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[TRIF]") ;
               cmdBuffer=" DROP TABLE [TRIF] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[TRIF]") ;
                  cmdBuffer=" DROP VIEW [TRIF] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[TRIF]") ;
                     cmdBuffer=" DROP FUNCTION [TRIF] "
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
            cmdBuffer=" CREATE TABLE [TRIF] ([TRIFFecha] datetime NOT NULL , [TRIFMes] smallint NOT NULL , [TRIFAno] smallint NOT NULL , [IndicadoresCodigo] nvarchar(40) NOT NULL , [Cod_Area] nvarchar(40) NOT NULL , [TRIF_Valor_ACC] money NOT NULL , [TRIF_Valor_TRAB] money NOT NULL , [TRIF_Dias_PerdidosAtel] decimal( 12) NOT NULL , PRIMARY KEY([TRIFFecha], [TRIFMes], [TRIFAno], [IndicadoresCodigo], [Cod_Area]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ITRIF1] ON [TRIF] ([Cod_Area] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [ITRIF1] ON [TRIF] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ITRIF1] ON [TRIF] ([Cod_Area] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ITRIF2] ON [TRIF] ([IndicadoresCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [ITRIF2] ON [TRIF] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ITRIF2] ON [TRIF] ([IndicadoresCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateCOSTOHE( )
      {
         string cmdBuffer = "";
         /* Indices for table COSTOHE */
         try
         {
            cmdBuffer=" CREATE TABLE [COSTOHE] ([COSTOHEFecha] datetime NOT NULL , [COSTOHEMes] smallint NOT NULL , [COSTOHEAno] smallint NOT NULL , [IndicadoresCodigo] nvarchar(40) NOT NULL , [Cod_Area] nvarchar(40) NOT NULL , [COSTOHEValor] money NOT NULL , [COSTOHETotHoras] int NOT NULL , PRIMARY KEY([COSTOHEFecha], [COSTOHEMes], [COSTOHEAno], [IndicadoresCodigo], [Cod_Area]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[COSTOHE]") ;
               cmdBuffer=" DROP TABLE [COSTOHE] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[COSTOHE]") ;
                  cmdBuffer=" DROP VIEW [COSTOHE] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[COSTOHE]") ;
                     cmdBuffer=" DROP FUNCTION [COSTOHE] "
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
            cmdBuffer=" CREATE TABLE [COSTOHE] ([COSTOHEFecha] datetime NOT NULL , [COSTOHEMes] smallint NOT NULL , [COSTOHEAno] smallint NOT NULL , [IndicadoresCodigo] nvarchar(40) NOT NULL , [Cod_Area] nvarchar(40) NOT NULL , [COSTOHEValor] money NOT NULL , [COSTOHETotHoras] int NOT NULL , PRIMARY KEY([COSTOHEFecha], [COSTOHEMes], [COSTOHEAno], [IndicadoresCodigo], [Cod_Area]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ICOSTOHE1] ON [COSTOHE] ([Cod_Area] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [ICOSTOHE1] ON [COSTOHE] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ICOSTOHE1] ON [COSTOHE] ([Cod_Area] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ICOSTOHE2] ON [COSTOHE] ([IndicadoresCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [ICOSTOHE2] ON [COSTOHE] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ICOSTOHE2] ON [COSTOHE] ([IndicadoresCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateACCDAG( )
      {
         string cmdBuffer = "";
         /* Indices for table ACCDAG */
         try
         {
            cmdBuffer=" CREATE TABLE [ACCDAG] ([ACCDAG_Fecha] datetime NOT NULL , [ACCDAG_Mes] smallint NOT NULL , [ACCDAG_Ano] smallint NOT NULL , [Cod_Area] nvarchar(40) NOT NULL , [IndicadoresCodigo] nvarchar(40) NOT NULL , [ProcesosACCDAGCod] nvarchar(40) NOT NULL , [ACCDAGValor] money NOT NULL , [ACCDAGUser] nvarchar(150) NOT NULL , [ACCDAGReg] datetime NOT NULL , [ACCDAGHor] nvarchar(40) NOT NULL , PRIMARY KEY([ACCDAG_Fecha], [ACCDAG_Mes], [ACCDAG_Ano], [Cod_Area], [IndicadoresCodigo], [ProcesosACCDAGCod]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[ACCDAG]") ;
               cmdBuffer=" DROP TABLE [ACCDAG] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[ACCDAG]") ;
                  cmdBuffer=" DROP VIEW [ACCDAG] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[ACCDAG]") ;
                     cmdBuffer=" DROP FUNCTION [ACCDAG] "
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
            cmdBuffer=" CREATE TABLE [ACCDAG] ([ACCDAG_Fecha] datetime NOT NULL , [ACCDAG_Mes] smallint NOT NULL , [ACCDAG_Ano] smallint NOT NULL , [Cod_Area] nvarchar(40) NOT NULL , [IndicadoresCodigo] nvarchar(40) NOT NULL , [ProcesosACCDAGCod] nvarchar(40) NOT NULL , [ACCDAGValor] money NOT NULL , [ACCDAGUser] nvarchar(150) NOT NULL , [ACCDAGReg] datetime NOT NULL , [ACCDAGHor] nvarchar(40) NOT NULL , PRIMARY KEY([ACCDAG_Fecha], [ACCDAG_Mes], [ACCDAG_Ano], [Cod_Area], [IndicadoresCodigo], [ProcesosACCDAGCod]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IACCDAG1] ON [ACCDAG] ([ProcesosACCDAGCod] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IACCDAG1] ON [ACCDAG] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IACCDAG1] ON [ACCDAG] ([ProcesosACCDAGCod] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IACCDAG2] ON [ACCDAG] ([IndicadoresCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IACCDAG2] ON [ACCDAG] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IACCDAG2] ON [ACCDAG] ([IndicadoresCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IACCDAG3] ON [ACCDAG] ([Cod_Area] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IACCDAG3] ON [ACCDAG] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IACCDAG3] ON [ACCDAG] ([Cod_Area] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateProcesosACCDAG( )
      {
         string cmdBuffer = "";
         /* Indices for table ProcesosACCDAG */
         try
         {
            cmdBuffer=" CREATE TABLE [ProcesosACCDAG] ([ProcesosACCDAGCod] nvarchar(40) NOT NULL , [ProcesosACCDAGNom] nvarchar(200) NOT NULL , PRIMARY KEY([ProcesosACCDAGCod]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[ProcesosACCDAG]") ;
               cmdBuffer=" DROP TABLE [ProcesosACCDAG] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[ProcesosACCDAG]") ;
                  cmdBuffer=" DROP VIEW [ProcesosACCDAG] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[ProcesosACCDAG]") ;
                     cmdBuffer=" DROP FUNCTION [ProcesosACCDAG] "
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
            cmdBuffer=" CREATE TABLE [ProcesosACCDAG] ([ProcesosACCDAGCod] nvarchar(40) NOT NULL , [ProcesosACCDAGNom] nvarchar(200) NOT NULL , PRIMARY KEY([ProcesosACCDAGCod]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateAusentismosTipos( )
      {
         string cmdBuffer = "";
         /* Indices for table AusentismosTipos */
         try
         {
            cmdBuffer=" CREATE TABLE [AusentismosTipos] ([Ausen_Fecha] datetime NOT NULL , [Ausen_Mes] smallint NOT NULL , [Ausen_Ano] smallint NOT NULL , [IndicadoresCodigo] nvarchar(40) NOT NULL , [Cod_Area] nvarchar(40) NOT NULL , [AusenArea_Fecha] datetime NOT NULL , [TipoAusen_Codigo] nvarchar(40) NOT NULL , [AusenAreaValor] money NOT NULL , [AusentismosAreaUser] nvarchar(120) NOT NULL , [AusentismosAreaReg] datetime NOT NULL , [AusentismosAreaHor] nvarchar(40) NOT NULL , PRIMARY KEY([Ausen_Fecha], [Ausen_Mes], [Ausen_Ano], [IndicadoresCodigo], [Cod_Area], [AusenArea_Fecha], [TipoAusen_Codigo]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[AusentismosTipos]") ;
               cmdBuffer=" DROP TABLE [AusentismosTipos] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[AusentismosTipos]") ;
                  cmdBuffer=" DROP VIEW [AusentismosTipos] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[AusentismosTipos]") ;
                     cmdBuffer=" DROP FUNCTION [AusentismosTipos] "
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
            cmdBuffer=" CREATE TABLE [AusentismosTipos] ([Ausen_Fecha] datetime NOT NULL , [Ausen_Mes] smallint NOT NULL , [Ausen_Ano] smallint NOT NULL , [IndicadoresCodigo] nvarchar(40) NOT NULL , [Cod_Area] nvarchar(40) NOT NULL , [AusenArea_Fecha] datetime NOT NULL , [TipoAusen_Codigo] nvarchar(40) NOT NULL , [AusenAreaValor] money NOT NULL , [AusentismosAreaUser] nvarchar(120) NOT NULL , [AusentismosAreaReg] datetime NOT NULL , [AusentismosAreaHor] nvarchar(40) NOT NULL , PRIMARY KEY([Ausen_Fecha], [Ausen_Mes], [Ausen_Ano], [IndicadoresCodigo], [Cod_Area], [AusenArea_Fecha], [TipoAusen_Codigo]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IAUSENTISMOSAREA4] ON [AusentismosTipos] ([TipoAusen_Codigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IAUSENTISMOSAREA4] ON [AusentismosTipos] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IAUSENTISMOSAREA4] ON [AusentismosTipos] ([TipoAusen_Codigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateAusentismos( )
      {
         string cmdBuffer = "";
         /* Indices for table Ausentismos */
         try
         {
            cmdBuffer=" CREATE TABLE [Ausentismos] ([Ausen_Fecha] datetime NOT NULL , [Ausen_Mes] smallint NOT NULL , [Ausen_Ano] smallint NOT NULL , [IndicadoresCodigo] nvarchar(40) NOT NULL , [Cod_Area] nvarchar(40) NOT NULL , [Ausen_Valor] money NOT NULL , [AusentismosUser] nvarchar(150) NOT NULL , [AusentismosReg] datetime NOT NULL , [AusentismosHor] nvarchar(40) NOT NULL , PRIMARY KEY([Ausen_Fecha], [Ausen_Mes], [Ausen_Ano], [IndicadoresCodigo], [Cod_Area]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[Ausentismos]") ;
               cmdBuffer=" DROP TABLE [Ausentismos] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[Ausentismos]") ;
                  cmdBuffer=" DROP VIEW [Ausentismos] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[Ausentismos]") ;
                     cmdBuffer=" DROP FUNCTION [Ausentismos] "
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
            cmdBuffer=" CREATE TABLE [Ausentismos] ([Ausen_Fecha] datetime NOT NULL , [Ausen_Mes] smallint NOT NULL , [Ausen_Ano] smallint NOT NULL , [IndicadoresCodigo] nvarchar(40) NOT NULL , [Cod_Area] nvarchar(40) NOT NULL , [Ausen_Valor] money NOT NULL , [AusentismosUser] nvarchar(150) NOT NULL , [AusentismosReg] datetime NOT NULL , [AusentismosHor] nvarchar(40) NOT NULL , PRIMARY KEY([Ausen_Fecha], [Ausen_Mes], [Ausen_Ano], [IndicadoresCodigo], [Cod_Area]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IAUSENTISMOSAREA2] ON [Ausentismos] ([Cod_Area] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IAUSENTISMOSAREA2] ON [Ausentismos] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IAUSENTISMOSAREA2] ON [Ausentismos] ([Cod_Area] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IAUSENTISMOSAREA1] ON [Ausentismos] ([IndicadoresCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IAUSENTISMOSAREA1] ON [Ausentismos] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IAUSENTISMOSAREA1] ON [Ausentismos] ([IndicadoresCodigo] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTipoAusentismo( )
      {
         string cmdBuffer = "";
         /* Indices for table TipoAusentismo */
         try
         {
            cmdBuffer=" CREATE TABLE [TipoAusentismo] ([TipoAusen_Codigo] nvarchar(40) NOT NULL , [TipoAusen_Nombres] nvarchar(150) NOT NULL , PRIMARY KEY([TipoAusen_Codigo]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[TipoAusentismo]") ;
               cmdBuffer=" DROP TABLE [TipoAusentismo] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[TipoAusentismo]") ;
                  cmdBuffer=" DROP VIEW [TipoAusentismo] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[TipoAusentismo]") ;
                     cmdBuffer=" DROP FUNCTION [TipoAusentismo] "
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
            cmdBuffer=" CREATE TABLE [TipoAusentismo] ([TipoAusen_Codigo] nvarchar(40) NOT NULL , [TipoAusen_Nombres] nvarchar(150) NOT NULL , PRIMARY KEY([TipoAusen_Codigo]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateIndicadores( )
      {
         string cmdBuffer = "";
         /* Indices for table Indicadores */
         try
         {
            cmdBuffer=" CREATE TABLE [Indicadores] ([IndicadoresCodigo] nvarchar(40) NOT NULL , [IndicadoresSigla] nvarchar(40) NULL , [IndicadoresNombres] nvarchar(300) NOT NULL , [IndicadoresFormula] nvarchar(300) NULL , [IndicadoresConsecutivo] smallint NULL , PRIMARY KEY([IndicadoresCodigo]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[Indicadores]") ;
               cmdBuffer=" DROP TABLE [Indicadores] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[Indicadores]") ;
                  cmdBuffer=" DROP VIEW [Indicadores] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[Indicadores]") ;
                     cmdBuffer=" DROP FUNCTION [Indicadores] "
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
            cmdBuffer=" CREATE TABLE [Indicadores] ([IndicadoresCodigo] nvarchar(40) NOT NULL , [IndicadoresSigla] nvarchar(40) NULL , [IndicadoresNombres] nvarchar(300) NOT NULL , [IndicadoresFormula] nvarchar(300) NULL , [IndicadoresConsecutivo] smallint NULL , PRIMARY KEY([IndicadoresCodigo]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateUsuarios( )
      {
         string cmdBuffer = "";
         /* Indices for table Usuarios */
         try
         {
            cmdBuffer=" CREATE TABLE [Usuarios] ([UsuariosCodigo] nvarchar(150) NOT NULL , [UsuariosNombres] nvarchar(120) NOT NULL , [UsuariosPsw] nvarchar(32) NOT NULL , [Cod_Area] nvarchar(40) NOT NULL , [UsuariosAdmin] smallint NOT NULL , [UsuariosActualiza] smallint NOT NULL , [UsuariosOrden] smallint NOT NULL , [UsuariosImagen] VARBINARY(MAX) NULL , [UsuariosLinkImagen] nvarchar(300) NULL , [UsuariosVigenciaHasta] datetime NULL , PRIMARY KEY([UsuariosCodigo]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[Usuarios]") ;
               cmdBuffer=" DROP TABLE [Usuarios] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[Usuarios]") ;
                  cmdBuffer=" DROP VIEW [Usuarios] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[Usuarios]") ;
                     cmdBuffer=" DROP FUNCTION [Usuarios] "
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
            cmdBuffer=" CREATE TABLE [Usuarios] ([UsuariosCodigo] nvarchar(150) NOT NULL , [UsuariosNombres] nvarchar(120) NOT NULL , [UsuariosPsw] nvarchar(32) NOT NULL , [Cod_Area] nvarchar(40) NOT NULL , [UsuariosAdmin] smallint NOT NULL , [UsuariosActualiza] smallint NOT NULL , [UsuariosOrden] smallint NOT NULL , [UsuariosImagen] VARBINARY(MAX) NULL , [UsuariosLinkImagen] nvarchar(300) NULL , [UsuariosVigenciaHasta] datetime NULL , PRIMARY KEY([UsuariosCodigo]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IUSUARIOS1] ON [Usuarios] ([Cod_Area] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IUSUARIOS1] ON [Usuarios] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IUSUARIOS1] ON [Usuarios] ([Cod_Area] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateAreas( )
      {
         string cmdBuffer = "";
         /* Indices for table Areas */
         try
         {
            cmdBuffer=" CREATE TABLE [Areas] ([Cod_Area] nvarchar(40) NOT NULL , [Nom_Area] nvarchar(40) NOT NULL , [logo] VARBINARY(MAX) NULL , [AreasLinkUrlImagen] nvarchar(300) NULL , PRIMARY KEY([Cod_Area]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[Areas]") ;
               cmdBuffer=" DROP TABLE [Areas] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[Areas]") ;
                  cmdBuffer=" DROP VIEW [Areas] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[Areas]") ;
                     cmdBuffer=" DROP FUNCTION [Areas] "
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
            cmdBuffer=" CREATE TABLE [Areas] ([Cod_Area] nvarchar(40) NOT NULL , [Nom_Area] nvarchar(40) NOT NULL , [logo] VARBINARY(MAX) NULL , [AreasLinkUrlImagen] nvarchar(300) NULL , PRIMARY KEY([Cod_Area]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIUsuariosAreas( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [Usuarios] ADD CONSTRAINT [IUSUARIOS1] FOREIGN KEY ([Cod_Area]) REFERENCES [Areas] ([Cod_Area]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [Usuarios] DROP CONSTRAINT [IUSUARIOS1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [Usuarios] ADD CONSTRAINT [IUSUARIOS1] FOREIGN KEY ([Cod_Area]) REFERENCES [Areas] ([Cod_Area]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIAusentismosIndicadores( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [Ausentismos] ADD CONSTRAINT [IAUSENTISMOSAREA1] FOREIGN KEY ([IndicadoresCodigo]) REFERENCES [Indicadores] ([IndicadoresCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [Ausentismos] DROP CONSTRAINT [IAUSENTISMOSAREA1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [Ausentismos] ADD CONSTRAINT [IAUSENTISMOSAREA1] FOREIGN KEY ([IndicadoresCodigo]) REFERENCES [Indicadores] ([IndicadoresCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIAusentismosAreas( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [Ausentismos] ADD CONSTRAINT [IAUSENTISMOSAREA2] FOREIGN KEY ([Cod_Area]) REFERENCES [Areas] ([Cod_Area]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [Ausentismos] DROP CONSTRAINT [IAUSENTISMOSAREA2] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [Ausentismos] ADD CONSTRAINT [IAUSENTISMOSAREA2] FOREIGN KEY ([Cod_Area]) REFERENCES [Areas] ([Cod_Area]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIAusentismosTiposAusentismos( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [AusentismosTipos] ADD CONSTRAINT [IAUSENTISMOSAREA5] FOREIGN KEY ([Ausen_Fecha], [Ausen_Mes], [Ausen_Ano], [IndicadoresCodigo], [Cod_Area]) REFERENCES [Ausentismos] ([Ausen_Fecha], [Ausen_Mes], [Ausen_Ano], [IndicadoresCodigo], [Cod_Area]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [AusentismosTipos] DROP CONSTRAINT [IAUSENTISMOSAREA5] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [AusentismosTipos] ADD CONSTRAINT [IAUSENTISMOSAREA5] FOREIGN KEY ([Ausen_Fecha], [Ausen_Mes], [Ausen_Ano], [IndicadoresCodigo], [Cod_Area]) REFERENCES [Ausentismos] ([Ausen_Fecha], [Ausen_Mes], [Ausen_Ano], [IndicadoresCodigo], [Cod_Area]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIAusentismosTiposTipoAusentismo( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [AusentismosTipos] ADD CONSTRAINT [IAUSENTISMOSAREA4] FOREIGN KEY ([TipoAusen_Codigo]) REFERENCES [TipoAusentismo] ([TipoAusen_Codigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [AusentismosTipos] DROP CONSTRAINT [IAUSENTISMOSAREA4] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [AusentismosTipos] ADD CONSTRAINT [IAUSENTISMOSAREA4] FOREIGN KEY ([TipoAusen_Codigo]) REFERENCES [TipoAusentismo] ([TipoAusen_Codigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIACCDAGAreas( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [ACCDAG] ADD CONSTRAINT [IACCDAG3] FOREIGN KEY ([Cod_Area]) REFERENCES [Areas] ([Cod_Area]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [ACCDAG] DROP CONSTRAINT [IACCDAG3] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [ACCDAG] ADD CONSTRAINT [IACCDAG3] FOREIGN KEY ([Cod_Area]) REFERENCES [Areas] ([Cod_Area]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIACCDAGIndicadores( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [ACCDAG] ADD CONSTRAINT [IACCDAG2] FOREIGN KEY ([IndicadoresCodigo]) REFERENCES [Indicadores] ([IndicadoresCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [ACCDAG] DROP CONSTRAINT [IACCDAG2] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [ACCDAG] ADD CONSTRAINT [IACCDAG2] FOREIGN KEY ([IndicadoresCodigo]) REFERENCES [Indicadores] ([IndicadoresCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIACCDAGProcesosACCDAG( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [ACCDAG] ADD CONSTRAINT [IACCDAG1] FOREIGN KEY ([ProcesosACCDAGCod]) REFERENCES [ProcesosACCDAG] ([ProcesosACCDAGCod]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [ACCDAG] DROP CONSTRAINT [IACCDAG1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [ACCDAG] ADD CONSTRAINT [IACCDAG1] FOREIGN KEY ([ProcesosACCDAGCod]) REFERENCES [ProcesosACCDAG] ([ProcesosACCDAGCod]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RICOSTOHEIndicadores( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [COSTOHE] ADD CONSTRAINT [ICOSTOHE2] FOREIGN KEY ([IndicadoresCodigo]) REFERENCES [Indicadores] ([IndicadoresCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [COSTOHE] DROP CONSTRAINT [ICOSTOHE2] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [COSTOHE] ADD CONSTRAINT [ICOSTOHE2] FOREIGN KEY ([IndicadoresCodigo]) REFERENCES [Indicadores] ([IndicadoresCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RICOSTOHEAreas( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [COSTOHE] ADD CONSTRAINT [ICOSTOHE1] FOREIGN KEY ([Cod_Area]) REFERENCES [Areas] ([Cod_Area]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [COSTOHE] DROP CONSTRAINT [ICOSTOHE1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [COSTOHE] ADD CONSTRAINT [ICOSTOHE1] FOREIGN KEY ([Cod_Area]) REFERENCES [Areas] ([Cod_Area]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITRIFIndicadores( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [TRIF] ADD CONSTRAINT [ITRIF2] FOREIGN KEY ([IndicadoresCodigo]) REFERENCES [Indicadores] ([IndicadoresCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [TRIF] DROP CONSTRAINT [ITRIF2] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [TRIF] ADD CONSTRAINT [ITRIF2] FOREIGN KEY ([IndicadoresCodigo]) REFERENCES [Indicadores] ([IndicadoresCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITRIFAreas( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [TRIF] ADD CONSTRAINT [ITRIF1] FOREIGN KEY ([Cod_Area]) REFERENCES [Areas] ([Cod_Area]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [TRIF] DROP CONSTRAINT [ITRIF1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [TRIF] ADD CONSTRAINT [ITRIF1] FOREIGN KEY ([Cod_Area]) REFERENCES [Areas] ([Cod_Area]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RICOSUSPTONFRUTAAreas( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [COSUSPTONFRUTA] ADD CONSTRAINT [ICOSUSPTONFRUTA2] FOREIGN KEY ([Cod_Area]) REFERENCES [Areas] ([Cod_Area]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [COSUSPTONFRUTA] DROP CONSTRAINT [ICOSUSPTONFRUTA2] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [COSUSPTONFRUTA] ADD CONSTRAINT [ICOSUSPTONFRUTA2] FOREIGN KEY ([Cod_Area]) REFERENCES [Areas] ([Cod_Area]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RICOSUSPTONFRUTAIndicadores( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [COSUSPTONFRUTA] ADD CONSTRAINT [ICOSUSPTONFRUTA1] FOREIGN KEY ([IndicadoresCodigo]) REFERENCES [Indicadores] ([IndicadoresCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [COSUSPTONFRUTA] DROP CONSTRAINT [ICOSUSPTONFRUTA1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [COSUSPTONFRUTA] ADD CONSTRAINT [ICOSUSPTONFRUTA1] FOREIGN KEY ([IndicadoresCodigo]) REFERENCES [Indicadores] ([IndicadoresCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIPAGOFRUTAAreas( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [PAGOFRUTA] ADD CONSTRAINT [IPAGOFRUTA3] FOREIGN KEY ([Cod_Area]) REFERENCES [Areas] ([Cod_Area]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [PAGOFRUTA] DROP CONSTRAINT [IPAGOFRUTA3] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [PAGOFRUTA] ADD CONSTRAINT [IPAGOFRUTA3] FOREIGN KEY ([Cod_Area]) REFERENCES [Areas] ([Cod_Area]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIPAGOFRUTAIndicadores( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [PAGOFRUTA] ADD CONSTRAINT [IPAGOFRUTA2] FOREIGN KEY ([IndicadoresCodigo]) REFERENCES [Indicadores] ([IndicadoresCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [PAGOFRUTA] DROP CONSTRAINT [IPAGOFRUTA2] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [PAGOFRUTA] ADD CONSTRAINT [IPAGOFRUTA2] FOREIGN KEY ([IndicadoresCodigo]) REFERENCES [Indicadores] ([IndicadoresCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIPAGOFRUTAMotivosUsp( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [PAGOFRUTA] ADD CONSTRAINT [IPAGOFRUTA1] FOREIGN KEY ([MotivosUspCodigo]) REFERENCES [MotivosUsp] ([MotivosUspCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [PAGOFRUTA] DROP CONSTRAINT [IPAGOFRUTA1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [PAGOFRUTA] ADD CONSTRAINT [IPAGOFRUTA1] FOREIGN KEY ([MotivosUspCodigo]) REFERENCES [MotivosUsp] ([MotivosUspCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIMetasIndicadoresIndicadores( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [MetasIndicadores] ADD CONSTRAINT [IMETASINDICADORES3] FOREIGN KEY ([IndicadoresCodigo]) REFERENCES [Indicadores] ([IndicadoresCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [MetasIndicadores] DROP CONSTRAINT [IMETASINDICADORES3] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [MetasIndicadores] ADD CONSTRAINT [IMETASINDICADORES3] FOREIGN KEY ([IndicadoresCodigo]) REFERENCES [Indicadores] ([IndicadoresCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIMetasIndicadoresTipoMetas( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [MetasIndicadores] ADD CONSTRAINT [IMETASINDICADORES2] FOREIGN KEY ([TipoMetasCodigo]) REFERENCES [TipoMetas] ([TipoMetasCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [MetasIndicadores] DROP CONSTRAINT [IMETASINDICADORES2] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [MetasIndicadores] ADD CONSTRAINT [IMETASINDICADORES2] FOREIGN KEY ([TipoMetasCodigo]) REFERENCES [TipoMetas] ([TipoMetasCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIMetasIndicadoresUsuarios( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [MetasIndicadores] ADD CONSTRAINT [IMETASINDICADORES1] FOREIGN KEY ([UsuariosCodigo]) REFERENCES [Usuarios] ([UsuariosCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [MetasIndicadores] DROP CONSTRAINT [IMETASINDICADORES1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [MetasIndicadores] ADD CONSTRAINT [IMETASINDICADORES1] FOREIGN KEY ([UsuariosCodigo]) REFERENCES [Usuarios] ([UsuariosCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIMetasIndicadoresMotivosMetas( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [MetasIndicadores] ADD CONSTRAINT [IMETASINDICADORES4] FOREIGN KEY ([MotivosMetasCodigo]) REFERENCES [MotivosMetas] ([MotivosMetasCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [MetasIndicadores] DROP CONSTRAINT [IMETASINDICADORES4] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [MetasIndicadores] ADD CONSTRAINT [IMETASINDICADORES4] FOREIGN KEY ([MotivosMetasCodigo]) REFERENCES [MotivosMetas] ([MotivosMetasCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIParametrosIndicadores( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [Parametros] ADD CONSTRAINT [IPARAMETROS1] FOREIGN KEY ([IndicadoresCodigo]) REFERENCES [Indicadores] ([IndicadoresCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [Parametros] DROP CONSTRAINT [IPARAMETROS1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [Parametros] ADD CONSTRAINT [IPARAMETROS1] FOREIGN KEY ([IndicadoresCodigo]) REFERENCES [Indicadores] ([IndicadoresCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RICOSTOCPOHAAreas( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [COSTOCPOHA] ADD CONSTRAINT [ICOSTOCPOHA2] FOREIGN KEY ([Cod_Area]) REFERENCES [Areas] ([Cod_Area]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [COSTOCPOHA] DROP CONSTRAINT [ICOSTOCPOHA2] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [COSTOCPOHA] ADD CONSTRAINT [ICOSTOCPOHA2] FOREIGN KEY ([Cod_Area]) REFERENCES [Areas] ([Cod_Area]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RICOSTOCPOHAIndicadores( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [COSTOCPOHA] ADD CONSTRAINT [ICOSTOCPOHA1] FOREIGN KEY ([IndicadoresCodigo]) REFERENCES [Indicadores] ([IndicadoresCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [COSTOCPOHA] DROP CONSTRAINT [ICOSTOCPOHA1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [COSTOCPOHA] ADD CONSTRAINT [ICOSTOCPOHA1] FOREIGN KEY ([IndicadoresCodigo]) REFERENCES [Indicadores] ([IndicadoresCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIFRUTOPROCESADOAreas( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [FRUTOPROCESADO] ADD CONSTRAINT [IFRUTOPROCESADO2] FOREIGN KEY ([Cod_Area]) REFERENCES [Areas] ([Cod_Area]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [FRUTOPROCESADO] DROP CONSTRAINT [IFRUTOPROCESADO2] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [FRUTOPROCESADO] ADD CONSTRAINT [IFRUTOPROCESADO2] FOREIGN KEY ([Cod_Area]) REFERENCES [Areas] ([Cod_Area]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIFRUTOPROCESADOIndicadores( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [FRUTOPROCESADO] ADD CONSTRAINT [IFRUTOPROCESADO1] FOREIGN KEY ([IndicadoresCodigo]) REFERENCES [Indicadores] ([IndicadoresCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [FRUTOPROCESADO] DROP CONSTRAINT [IFRUTOPROCESADO1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [FRUTOPROCESADO] ADD CONSTRAINT [IFRUTOPROCESADO1] FOREIGN KEY ([IndicadoresCodigo]) REFERENCES [Indicadores] ([IndicadoresCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITEAIndicadores( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [TEA] ADD CONSTRAINT [ITEA2] FOREIGN KEY ([IndicadoresCodigo]) REFERENCES [Indicadores] ([IndicadoresCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [TEA] DROP CONSTRAINT [ITEA2] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [TEA] ADD CONSTRAINT [ITEA2] FOREIGN KEY ([IndicadoresCodigo]) REFERENCES [Indicadores] ([IndicadoresCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITEAAreas( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [TEA] ADD CONSTRAINT [ITEA1] FOREIGN KEY ([Cod_Area]) REFERENCES [Areas] ([Cod_Area]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [TEA] DROP CONSTRAINT [ITEA1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [TEA] ADD CONSTRAINT [ITEA1] FOREIGN KEY ([Cod_Area]) REFERENCES [Areas] ([Cod_Area]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIVentasTipoProducto( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [Ventas] ADD CONSTRAINT [IVENTAS1] FOREIGN KEY ([TipoProductoCod]) REFERENCES [TipoProducto] ([TipoProductoCod]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [Ventas] DROP CONSTRAINT [IVENTAS1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [Ventas] ADD CONSTRAINT [IVENTAS1] FOREIGN KEY ([TipoProductoCod]) REFERENCES [TipoProducto] ([TipoProductoCod]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIVentasClientes( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [Ventas] ADD CONSTRAINT [IVENTAS2] FOREIGN KEY ([ClientesCodigo]) REFERENCES [Clientes] ([ClientesCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [Ventas] DROP CONSTRAINT [IVENTAS2] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [Ventas] ADD CONSTRAINT [IVENTAS2] FOREIGN KEY ([ClientesCodigo]) REFERENCES [Clientes] ([ClientesCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIAcidezAreas( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [Acidez] ADD CONSTRAINT [IACIDEZ2] FOREIGN KEY ([Cod_Area]) REFERENCES [Areas] ([Cod_Area]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [Acidez] DROP CONSTRAINT [IACIDEZ2] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [Acidez] ADD CONSTRAINT [IACIDEZ2] FOREIGN KEY ([Cod_Area]) REFERENCES [Areas] ([Cod_Area]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIAcidezIndicadores( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [Acidez] ADD CONSTRAINT [IACIDEZ1] FOREIGN KEY ([IndicadoresCodigo]) REFERENCES [Indicadores] ([IndicadoresCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [Acidez] DROP CONSTRAINT [IACIDEZ1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [Acidez] ADD CONSTRAINT [IACIDEZ1] FOREIGN KEY ([IndicadoresCodigo]) REFERENCES [Indicadores] ([IndicadoresCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RICOSTONRFFPROCESADAAreas( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [COSTONRFFPROCESADA] ADD CONSTRAINT [ICOSTONRFFPROCESADA3] FOREIGN KEY ([Cod_Area]) REFERENCES [Areas] ([Cod_Area]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [COSTONRFFPROCESADA] DROP CONSTRAINT [ICOSTONRFFPROCESADA3] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [COSTONRFFPROCESADA] ADD CONSTRAINT [ICOSTONRFFPROCESADA3] FOREIGN KEY ([Cod_Area]) REFERENCES [Areas] ([Cod_Area]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RICOSTONRFFPROCESADAIndicadores( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [COSTONRFFPROCESADA] ADD CONSTRAINT [ICOSTONRFFPROCESADA2] FOREIGN KEY ([IndicadoresCodigo]) REFERENCES [Indicadores] ([IndicadoresCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [COSTONRFFPROCESADA] DROP CONSTRAINT [ICOSTONRFFPROCESADA2] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [COSTONRFFPROCESADA] ADD CONSTRAINT [ICOSTONRFFPROCESADA2] FOREIGN KEY ([IndicadoresCodigo]) REFERENCES [Indicadores] ([IndicadoresCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RICOSTONRFFPROCESADAMOTIVOSCOSRFFPRO( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [COSTONRFFPROCESADA] ADD CONSTRAINT [ICOSTONRFFPROCESADA1] FOREIGN KEY ([MOTIVOSCOSRFFPROCod]) REFERENCES [MOTIVOSCOSRFFPRO] ([MOTIVOSCOSRFFPROCod]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [COSTONRFFPROCESADA] DROP CONSTRAINT [ICOSTONRFFPROCESADA1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [COSTONRFFPROCESADA] ADD CONSTRAINT [ICOSTONRFFPROCESADA1] FOREIGN KEY ([MOTIVOSCOSRFFPROCod]) REFERENCES [MOTIVOSCOSRFFPRO] ([MOTIVOSCOSRFFPROCod]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIFRUTAPROPIAIndicadores( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [FRUTAPROPIA] ADD CONSTRAINT [IFRUTAPROPIA2] FOREIGN KEY ([IndicadoresCodigo]) REFERENCES [Indicadores] ([IndicadoresCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [FRUTAPROPIA] DROP CONSTRAINT [IFRUTAPROPIA2] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [FRUTAPROPIA] ADD CONSTRAINT [IFRUTAPROPIA2] FOREIGN KEY ([IndicadoresCodigo]) REFERENCES [Indicadores] ([IndicadoresCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIFRUTAPROPIAAreas( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [FRUTAPROPIA] ADD CONSTRAINT [IFRUTAPROPIA1] FOREIGN KEY ([Cod_Area]) REFERENCES [Areas] ([Cod_Area]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [FRUTAPROPIA] DROP CONSTRAINT [IFRUTAPROPIA1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [FRUTAPROPIA] ADD CONSTRAINT [IFRUTAPROPIA1] FOREIGN KEY ([Cod_Area]) REFERENCES [Areas] ([Cod_Area]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITONCPOHAAreas( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [TONCPOHA] ADD CONSTRAINT [ITONCPOHA2] FOREIGN KEY ([Cod_Area]) REFERENCES [Areas] ([Cod_Area]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [TONCPOHA] DROP CONSTRAINT [ITONCPOHA2] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [TONCPOHA] ADD CONSTRAINT [ITONCPOHA2] FOREIGN KEY ([Cod_Area]) REFERENCES [Areas] ([Cod_Area]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITONCPOHAIndicadores( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [TONCPOHA] ADD CONSTRAINT [ITONCPOHA1] FOREIGN KEY ([IndicadoresCodigo]) REFERENCES [Indicadores] ([IndicadoresCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [TONCPOHA] DROP CONSTRAINT [ITONCPOHA1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [TONCPOHA] ADD CONSTRAINT [ITONCPOHA1] FOREIGN KEY ([IndicadoresCodigo]) REFERENCES [Indicadores] ([IndicadoresCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIHATRABAJADORESAreas( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [HATRABAJADORES] ADD CONSTRAINT [IHATRABAJADORES2] FOREIGN KEY ([Cod_Area]) REFERENCES [Areas] ([Cod_Area]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [HATRABAJADORES] DROP CONSTRAINT [IHATRABAJADORES2] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [HATRABAJADORES] ADD CONSTRAINT [IHATRABAJADORES2] FOREIGN KEY ([Cod_Area]) REFERENCES [Areas] ([Cod_Area]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIHATRABAJADORESIndicadores( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [HATRABAJADORES] ADD CONSTRAINT [IHATRABAJADORES1] FOREIGN KEY ([IndicadoresCodigo]) REFERENCES [Indicadores] ([IndicadoresCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [HATRABAJADORES] DROP CONSTRAINT [IHATRABAJADORES1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [HATRABAJADORES] ADD CONSTRAINT [IHATRABAJADORES1] FOREIGN KEY ([IndicadoresCodigo]) REFERENCES [Indicadores] ([IndicadoresCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RICOSTONRFFPRODAreas( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [COSTONRFFPROD] ADD CONSTRAINT [ICOSTONRFFPROD2] FOREIGN KEY ([Cod_Area]) REFERENCES [Areas] ([Cod_Area]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [COSTONRFFPROD] DROP CONSTRAINT [ICOSTONRFFPROD2] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [COSTONRFFPROD] ADD CONSTRAINT [ICOSTONRFFPROD2] FOREIGN KEY ([Cod_Area]) REFERENCES [Areas] ([Cod_Area]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RICOSTONRFFPRODIndicadores( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [COSTONRFFPROD] ADD CONSTRAINT [ICOSTONRFFPROD1] FOREIGN KEY ([IndicadoresCodigo]) REFERENCES [Indicadores] ([IndicadoresCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [COSTONRFFPROD] DROP CONSTRAINT [ICOSTONRFFPROD1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [COSTONRFFPROD] ADD CONSTRAINT [ICOSTONRFFPROD1] FOREIGN KEY ([IndicadoresCodigo]) REFERENCES [Indicadores] ([IndicadoresCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIINCIDENCIAPCAreas( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [INCIDENCIAPC] ADD CONSTRAINT [IINCIDENCIAPC4] FOREIGN KEY ([Cod_Area]) REFERENCES [Areas] ([Cod_Area]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [INCIDENCIAPC] DROP CONSTRAINT [IINCIDENCIAPC4] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [INCIDENCIAPC] ADD CONSTRAINT [IINCIDENCIAPC4] FOREIGN KEY ([Cod_Area]) REFERENCES [Areas] ([Cod_Area]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIINCIDENCIAPCIndicadores( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [INCIDENCIAPC] ADD CONSTRAINT [IINCIDENCIAPC3] FOREIGN KEY ([IndicadoresCodigo]) REFERENCES [Indicadores] ([IndicadoresCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [INCIDENCIAPC] DROP CONSTRAINT [IINCIDENCIAPC3] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [INCIDENCIAPC] ADD CONSTRAINT [IINCIDENCIAPC3] FOREIGN KEY ([IndicadoresCodigo]) REFERENCES [Indicadores] ([IndicadoresCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIINCIDENCIAPCTiposEnfermedades( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [INCIDENCIAPC] ADD CONSTRAINT [IINCIDENCIAPC2] FOREIGN KEY ([TiposEnfermedadesCod]) REFERENCES [TiposEnfermedades] ([TiposEnfermedadesCod]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [INCIDENCIAPC] DROP CONSTRAINT [IINCIDENCIAPC2] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [INCIDENCIAPC] ADD CONSTRAINT [IINCIDENCIAPC2] FOREIGN KEY ([TiposEnfermedadesCod]) REFERENCES [TiposEnfermedades] ([TiposEnfermedadesCod]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIINCIDENCIAPCMATERIALPALMAS( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [INCIDENCIAPC] ADD CONSTRAINT [IINCIDENCIAPC1] FOREIGN KEY ([MATERIALPALMASCOD]) REFERENCES [MATERIALPALMAS] ([MATERIALPALMASCOD]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [INCIDENCIAPC] DROP CONSTRAINT [IINCIDENCIAPC1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [INCIDENCIAPC] ADD CONSTRAINT [IINCIDENCIAPC1] FOREIGN KEY ([MATERIALPALMASCOD]) REFERENCES [MATERIALPALMAS] ([MATERIALPALMASCOD]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIMARGENEBITDAAreas( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [MARGENEBITDA] ADD CONSTRAINT [IMARGENEBITDA3] FOREIGN KEY ([Cod_Area]) REFERENCES [Areas] ([Cod_Area]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [MARGENEBITDA] DROP CONSTRAINT [IMARGENEBITDA3] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [MARGENEBITDA] ADD CONSTRAINT [IMARGENEBITDA3] FOREIGN KEY ([Cod_Area]) REFERENCES [Areas] ([Cod_Area]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIMARGENEBITDAIndicadores( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [MARGENEBITDA] ADD CONSTRAINT [IMARGENEBITDA2] FOREIGN KEY ([IndicadoresCodigo]) REFERENCES [Indicadores] ([IndicadoresCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [MARGENEBITDA] DROP CONSTRAINT [IMARGENEBITDA2] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [MARGENEBITDA] ADD CONSTRAINT [IMARGENEBITDA2] FOREIGN KEY ([IndicadoresCodigo]) REFERENCES [Indicadores] ([IndicadoresCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIMARGENEBITDAMOTIVOMARGEN( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [MARGENEBITDA] ADD CONSTRAINT [IMARGENEBITDA1] FOREIGN KEY ([MOTIVOMARGENCod]) REFERENCES [MOTIVOMARGEN] ([MOTIVOMARGENCod]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [MARGENEBITDA] DROP CONSTRAINT [IMARGENEBITDA1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [MARGENEBITDA] ADD CONSTRAINT [IMARGENEBITDA1] FOREIGN KEY ([MOTIVOMARGENCod]) REFERENCES [MOTIVOMARGEN] ([MOTIVOMARGENCod]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RICOSTOCPOPRODUCIDOAreas( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [COSTOCPOPRODUCIDO] ADD CONSTRAINT [ICOSTOCPOPRODUCIDO4] FOREIGN KEY ([Cod_Area]) REFERENCES [Areas] ([Cod_Area]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [COSTOCPOPRODUCIDO] DROP CONSTRAINT [ICOSTOCPOPRODUCIDO4] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [COSTOCPOPRODUCIDO] ADD CONSTRAINT [ICOSTOCPOPRODUCIDO4] FOREIGN KEY ([Cod_Area]) REFERENCES [Areas] ([Cod_Area]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RICOSTOCPOPRODUCIDOIndicadores( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [COSTOCPOPRODUCIDO] ADD CONSTRAINT [ICOSTOCPOPRODUCIDO3] FOREIGN KEY ([IndicadoresCodigo]) REFERENCES [Indicadores] ([IndicadoresCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [COSTOCPOPRODUCIDO] DROP CONSTRAINT [ICOSTOCPOPRODUCIDO3] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [COSTOCPOPRODUCIDO] ADD CONSTRAINT [ICOSTOCPOPRODUCIDO3] FOREIGN KEY ([IndicadoresCodigo]) REFERENCES [Indicadores] ([IndicadoresCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RICOSTOCPOPRODUCIDOTIPOSCPO( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [COSTOCPOPRODUCIDO] ADD CONSTRAINT [ICOSTOCPOPRODUCIDO2] FOREIGN KEY ([TIPOSCPOCod]) REFERENCES [TIPOSCPO] ([TIPOSCPOCod]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [COSTOCPOPRODUCIDO] DROP CONSTRAINT [ICOSTOCPOPRODUCIDO2] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [COSTOCPOPRODUCIDO] ADD CONSTRAINT [ICOSTOCPOPRODUCIDO2] FOREIGN KEY ([TIPOSCPOCod]) REFERENCES [TIPOSCPO] ([TIPOSCPOCod]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RICOSTOCPOPRODUCIDOTipoProducto( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [COSTOCPOPRODUCIDO] ADD CONSTRAINT [ICOSTOCPOPRODUCIDO1] FOREIGN KEY ([TipoProductoCod]) REFERENCES [TipoProducto] ([TipoProductoCod]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [COSTOCPOPRODUCIDO] DROP CONSTRAINT [ICOSTOCPOPRODUCIDO1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [COSTOCPOPRODUCIDO] ADD CONSTRAINT [ICOSTOCPOPRODUCIDO1] FOREIGN KEY ([TipoProductoCod]) REFERENCES [TipoProducto] ([TipoProductoCod]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RICOSTOTONRFFPRODUAreas( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [COSTOTONRFFPRODU] ADD CONSTRAINT [ICOSTOTONRFFPRODU3] FOREIGN KEY ([Cod_Area]) REFERENCES [Areas] ([Cod_Area]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [COSTOTONRFFPRODU] DROP CONSTRAINT [ICOSTOTONRFFPRODU3] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [COSTOTONRFFPRODU] ADD CONSTRAINT [ICOSTOTONRFFPRODU3] FOREIGN KEY ([Cod_Area]) REFERENCES [Areas] ([Cod_Area]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RICOSTOTONRFFPRODUIndicadores( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [COSTOTONRFFPRODU] ADD CONSTRAINT [ICOSTOTONRFFPRODU2] FOREIGN KEY ([IndicadoresCodigo]) REFERENCES [Indicadores] ([IndicadoresCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [COSTOTONRFFPRODU] DROP CONSTRAINT [ICOSTOTONRFFPRODU2] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [COSTOTONRFFPRODU] ADD CONSTRAINT [ICOSTOTONRFFPRODU2] FOREIGN KEY ([IndicadoresCodigo]) REFERENCES [Indicadores] ([IndicadoresCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RICOSTOTONRFFPRODUMOTIVOTONRFF( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [COSTOTONRFFPRODU] ADD CONSTRAINT [ICOSTOTONRFFPRODU1] FOREIGN KEY ([MOTIVOTONRFFcod]) REFERENCES [MOTIVOTONRFF] ([MOTIVOTONRFFcod]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [COSTOTONRFFPRODU] DROP CONSTRAINT [ICOSTOTONRFFPRODU1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [COSTOTONRFFPRODU] ADD CONSTRAINT [ICOSTOTONRFFPRODU1] FOREIGN KEY ([MOTIVOTONRFFcod]) REFERENCES [MOTIVOTONRFF] ([MOTIVOTONRFFcod]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RICOSTONRFFPROCESAreas( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [COSTONRFFPROCES] ADD CONSTRAINT [ICOSTONRFFPROCES3] FOREIGN KEY ([Cod_Area]) REFERENCES [Areas] ([Cod_Area]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [COSTONRFFPROCES] DROP CONSTRAINT [ICOSTONRFFPROCES3] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [COSTONRFFPROCES] ADD CONSTRAINT [ICOSTONRFFPROCES3] FOREIGN KEY ([Cod_Area]) REFERENCES [Areas] ([Cod_Area]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RICOSTONRFFPROCESIndicadores( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [COSTONRFFPROCES] ADD CONSTRAINT [ICOSTONRFFPROCES2] FOREIGN KEY ([IndicadoresCodigo]) REFERENCES [Indicadores] ([IndicadoresCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [COSTONRFFPROCES] DROP CONSTRAINT [ICOSTONRFFPROCES2] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [COSTONRFFPROCES] ADD CONSTRAINT [ICOSTONRFFPROCES2] FOREIGN KEY ([IndicadoresCodigo]) REFERENCES [Indicadores] ([IndicadoresCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RICOSTONRFFPROCESMOTIVOSCOSRFF( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [COSTONRFFPROCES] ADD CONSTRAINT [ICOSTONRFFPROCES1] FOREIGN KEY ([MOTIVOSCOSRFFCodigo]) REFERENCES [MOTIVOSCOSRFF] ([MOTIVOSCOSRFFCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [COSTONRFFPROCES] DROP CONSTRAINT [ICOSTONRFFPROCES1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [COSTONRFFPROCES] ADD CONSTRAINT [ICOSTONRFFPROCES1] FOREIGN KEY ([MOTIVOSCOSRFFCodigo]) REFERENCES [MOTIVOSCOSRFF] ([MOTIVOSCOSRFFCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIPRECNETOTONCPOAreas( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [PRECNETOTONCPO] ADD CONSTRAINT [IPRECNETOTONCPO3] FOREIGN KEY ([Cod_Area]) REFERENCES [Areas] ([Cod_Area]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [PRECNETOTONCPO] DROP CONSTRAINT [IPRECNETOTONCPO3] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [PRECNETOTONCPO] ADD CONSTRAINT [IPRECNETOTONCPO3] FOREIGN KEY ([Cod_Area]) REFERENCES [Areas] ([Cod_Area]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIPRECNETOTONCPOIndicadores( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [PRECNETOTONCPO] ADD CONSTRAINT [IPRECNETOTONCPO2] FOREIGN KEY ([IndicadoresCodigo]) REFERENCES [Indicadores] ([IndicadoresCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [PRECNETOTONCPO] DROP CONSTRAINT [IPRECNETOTONCPO2] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [PRECNETOTONCPO] ADD CONSTRAINT [IPRECNETOTONCPO2] FOREIGN KEY ([IndicadoresCodigo]) REFERENCES [Indicadores] ([IndicadoresCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIPRECNETOTONCPOMOTIVOSPRENET( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [PRECNETOTONCPO] ADD CONSTRAINT [IPRECNETOTONCPO1] FOREIGN KEY ([MOTIVOSPRENETCodigo]) REFERENCES [MOTIVOSPRENET] ([MOTIVOSPRENETCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [PRECNETOTONCPO] DROP CONSTRAINT [IPRECNETOTONCPO1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [PRECNETOTONCPO] ADD CONSTRAINT [IPRECNETOTONCPO1] FOREIGN KEY ([MOTIVOSPRENETCodigo]) REFERENCES [MOTIVOSPRENET] ([MOTIVOSPRENETCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIRFF_COMPRADAAreas( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [RFF_COMPRADA] ADD CONSTRAINT [IRFF_COMPRADA2] FOREIGN KEY ([Cod_Area]) REFERENCES [Areas] ([Cod_Area]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [RFF_COMPRADA] DROP CONSTRAINT [IRFF_COMPRADA2] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [RFF_COMPRADA] ADD CONSTRAINT [IRFF_COMPRADA2] FOREIGN KEY ([Cod_Area]) REFERENCES [Areas] ([Cod_Area]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIRFF_COMPRADAIndicadores( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [RFF_COMPRADA] ADD CONSTRAINT [IRFF_COMPRADA1] FOREIGN KEY ([IndicadoresCodigo]) REFERENCES [Indicadores] ([IndicadoresCodigo]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [RFF_COMPRADA] DROP CONSTRAINT [IRFF_COMPRADA1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [RFF_COMPRADA] ADD CONSTRAINT [IRFF_COMPRADA1] FOREIGN KEY ([IndicadoresCodigo]) REFERENCES [Indicadores] ([IndicadoresCodigo]) "
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
         if ( ! IsResumeMode( ) )
         {
            if ( GXUtil.DbmsVersion( context, "DEFAULT") < 10 )
            {
               SetCheckError ( GXResourceManager.GetMessage("GXM_bad_DBMS_version", new   object[]  {"2012"}) ) ;
               return false ;
            }
         }
         if ( ! MustRunCheck( ) )
         {
            return true ;
         }
         if ( GXUtil.IsSQLSERVER2005( context, "DEFAULT") )
         {
            /* Using cursor P00012 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               sSchemaVar = P00012_AsSchemaVar[0];
               nsSchemaVar = P00012_nsSchemaVar[0];
               pr_default.readNext(0);
            }
            pr_default.close(0);
         }
         else
         {
            /* Using cursor P00023 */
            pr_default.execute(1);
            while ( (pr_default.getStatus(1) != 101) )
            {
               sSchemaVar = P00023_AsSchemaVar[0];
               nsSchemaVar = P00023_nsSchemaVar[0];
               pr_default.readNext(1);
            }
            pr_default.close(1);
         }
         if ( tableexist("TRABAJADORESMES",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"TRABAJADORESMES"}) ) ;
            return false ;
         }
         if ( tableexist("ZONALOTES",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"ZONALOTES"}) ) ;
            return false ;
         }
         if ( tableexist("MATERIALPALMAS",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"MATERIALPALMAS"}) ) ;
            return false ;
         }
         if ( tableexist("TiposEnfermedades",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"TiposEnfermedades"}) ) ;
            return false ;
         }
         if ( tableexist("RFF_COMPRADA",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"RFF_COMPRADA"}) ) ;
            return false ;
         }
         if ( tableexist("PRECNETOTONCPO",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"PRECNETOTONCPO"}) ) ;
            return false ;
         }
         if ( tableexist("MOTIVOSPRENET",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"MOTIVOSPRENET"}) ) ;
            return false ;
         }
         if ( tableexist("COSTONRFFPROCES",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"COSTONRFFPROCES"}) ) ;
            return false ;
         }
         if ( tableexist("MOTIVOSCOSRFF",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"MOTIVOSCOSRFF"}) ) ;
            return false ;
         }
         if ( tableexist("COSTOTONRFFPRODU",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"COSTOTONRFFPRODU"}) ) ;
            return false ;
         }
         if ( tableexist("MOTIVOTONRFF",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"MOTIVOTONRFF"}) ) ;
            return false ;
         }
         if ( tableexist("COSTOCPOPRODUCIDO",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"COSTOCPOPRODUCIDO"}) ) ;
            return false ;
         }
         if ( tableexist("TIPOSCPO",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"TIPOSCPO"}) ) ;
            return false ;
         }
         if ( tableexist("MARGENEBITDA",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"MARGENEBITDA"}) ) ;
            return false ;
         }
         if ( tableexist("MOTIVOMARGEN",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"MOTIVOMARGEN"}) ) ;
            return false ;
         }
         if ( tableexist("INCIDENCIAPC",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"INCIDENCIAPC"}) ) ;
            return false ;
         }
         if ( tableexist("COSTONRFFPROD",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"COSTONRFFPROD"}) ) ;
            return false ;
         }
         if ( tableexist("HATRABAJADORES",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"HATRABAJADORES"}) ) ;
            return false ;
         }
         if ( tableexist("TONCPOHA",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"TONCPOHA"}) ) ;
            return false ;
         }
         if ( tableexist("FRUTAPROPIA",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"FRUTAPROPIA"}) ) ;
            return false ;
         }
         if ( tableexist("COSTONRFFPROCESADA",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"COSTONRFFPROCESADA"}) ) ;
            return false ;
         }
         if ( tableexist("MOTIVOSCOSRFFPRO",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"MOTIVOSCOSRFFPRO"}) ) ;
            return false ;
         }
         if ( tableexist("Acidez",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Acidez"}) ) ;
            return false ;
         }
         if ( tableexist("Clientes",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Clientes"}) ) ;
            return false ;
         }
         if ( tableexist("Ventas",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Ventas"}) ) ;
            return false ;
         }
         if ( tableexist("TipoProducto",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"TipoProducto"}) ) ;
            return false ;
         }
         if ( tableexist("TEA",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"TEA"}) ) ;
            return false ;
         }
         if ( tableexist("FRUTOPROCESADO",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"FRUTOPROCESADO"}) ) ;
            return false ;
         }
         if ( tableexist("COSTOCPOHA",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"COSTOCPOHA"}) ) ;
            return false ;
         }
         if ( tableexist("Parametros",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Parametros"}) ) ;
            return false ;
         }
         if ( tableexist("MotivosMetas",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"MotivosMetas"}) ) ;
            return false ;
         }
         if ( tableexist("MetasIndicadores",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"MetasIndicadores"}) ) ;
            return false ;
         }
         if ( tableexist("TipoMetas",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"TipoMetas"}) ) ;
            return false ;
         }
         if ( tableexist("PAGOFRUTA",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"PAGOFRUTA"}) ) ;
            return false ;
         }
         if ( tableexist("MotivosUsp",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"MotivosUsp"}) ) ;
            return false ;
         }
         if ( tableexist("COSUSPTONFRUTA",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"COSUSPTONFRUTA"}) ) ;
            return false ;
         }
         if ( tableexist("TRIF",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"TRIF"}) ) ;
            return false ;
         }
         if ( tableexist("COSTOHE",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"COSTOHE"}) ) ;
            return false ;
         }
         if ( tableexist("ACCDAG",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"ACCDAG"}) ) ;
            return false ;
         }
         if ( tableexist("ProcesosACCDAG",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"ProcesosACCDAG"}) ) ;
            return false ;
         }
         if ( tableexist("AusentismosTipos",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"AusentismosTipos"}) ) ;
            return false ;
         }
         if ( tableexist("Ausentismos",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Ausentismos"}) ) ;
            return false ;
         }
         if ( tableexist("TipoAusentismo",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"TipoAusentismo"}) ) ;
            return false ;
         }
         if ( tableexist("Indicadores",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Indicadores"}) ) ;
            return false ;
         }
         if ( tableexist("Usuarios",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Usuarios"}) ) ;
            return false ;
         }
         if ( tableexist("Areas",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Areas"}) ) ;
            return false ;
         }
         return true ;
      }

      private bool tableexist( string sTableName ,
                               string sMySchemaName )
      {
         bool result;
         result = false;
         /* Using cursor P00034 */
         pr_default.execute(2, new Object[] {sTableName, sMySchemaName});
         while ( (pr_default.getStatus(2) != 101) )
         {
            tablename = P00034_Atablename[0];
            ntablename = P00034_ntablename[0];
            schemaname = P00034_Aschemaname[0];
            nschemaname = P00034_nschemaname[0];
            result = true;
            pr_default.readNext(2);
         }
         pr_default.close(2);
         return result ;
      }

      private void ExecuteOnlyTablesReorganization( )
      {
         ReorgExecute.RegisterBlockForSubmit( 1 ,  "CreateTRABAJADORESMES" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 2 ,  "CreateZONALOTES" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 3 ,  "CreateMATERIALPALMAS" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 4 ,  "CreateTiposEnfermedades" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 5 ,  "CreateRFF_COMPRADA" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 6 ,  "CreatePRECNETOTONCPO" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 7 ,  "CreateMOTIVOSPRENET" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 8 ,  "CreateCOSTONRFFPROCES" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 9 ,  "CreateMOTIVOSCOSRFF" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 10 ,  "CreateCOSTOTONRFFPRODU" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 11 ,  "CreateMOTIVOTONRFF" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 12 ,  "CreateCOSTOCPOPRODUCIDO" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 13 ,  "CreateTIPOSCPO" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 14 ,  "CreateMARGENEBITDA" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 15 ,  "CreateMOTIVOMARGEN" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 16 ,  "CreateINCIDENCIAPC" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 17 ,  "CreateCOSTONRFFPROD" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 18 ,  "CreateHATRABAJADORES" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 19 ,  "CreateTONCPOHA" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 20 ,  "CreateFRUTAPROPIA" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 21 ,  "CreateCOSTONRFFPROCESADA" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 22 ,  "CreateMOTIVOSCOSRFFPRO" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 23 ,  "CreateAcidez" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 24 ,  "CreateClientes" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 25 ,  "CreateVentas" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 26 ,  "CreateTipoProducto" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 27 ,  "CreateTEA" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 28 ,  "CreateFRUTOPROCESADO" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 29 ,  "CreateCOSTOCPOHA" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 30 ,  "CreateParametros" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 31 ,  "CreateMotivosMetas" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 32 ,  "CreateMetasIndicadores" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 33 ,  "CreateTipoMetas" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 34 ,  "CreatePAGOFRUTA" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 35 ,  "CreateMotivosUsp" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 36 ,  "CreateCOSUSPTONFRUTA" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 37 ,  "CreateTRIF" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 38 ,  "CreateCOSTOHE" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 39 ,  "CreateACCDAG" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 40 ,  "CreateProcesosACCDAG" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 41 ,  "CreateAusentismosTipos" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 42 ,  "CreateAusentismos" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 43 ,  "CreateTipoAusentismo" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 44 ,  "CreateIndicadores" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 45 ,  "CreateUsuarios" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 46 ,  "CreateAreas" , new Object[]{ });
      }

      private void ExecuteOnlyRisReorganization( )
      {
         ReorgExecute.RegisterBlockForSubmit( 47 ,  "RIUsuariosAreas" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 48 ,  "RIAusentismosIndicadores" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 49 ,  "RIAusentismosAreas" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 50 ,  "RIAusentismosTiposAusentismos" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 51 ,  "RIAusentismosTiposTipoAusentismo" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 52 ,  "RIACCDAGAreas" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 53 ,  "RIACCDAGIndicadores" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 54 ,  "RIACCDAGProcesosACCDAG" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 55 ,  "RICOSTOHEIndicadores" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 56 ,  "RICOSTOHEAreas" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 57 ,  "RITRIFIndicadores" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 58 ,  "RITRIFAreas" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 59 ,  "RICOSUSPTONFRUTAAreas" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 60 ,  "RICOSUSPTONFRUTAIndicadores" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 61 ,  "RIPAGOFRUTAAreas" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 62 ,  "RIPAGOFRUTAIndicadores" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 63 ,  "RIPAGOFRUTAMotivosUsp" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 64 ,  "RIMetasIndicadoresIndicadores" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 65 ,  "RIMetasIndicadoresTipoMetas" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 66 ,  "RIMetasIndicadoresUsuarios" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 67 ,  "RIMetasIndicadoresMotivosMetas" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 68 ,  "RIParametrosIndicadores" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 69 ,  "RICOSTOCPOHAAreas" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 70 ,  "RICOSTOCPOHAIndicadores" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 71 ,  "RIFRUTOPROCESADOAreas" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 72 ,  "RIFRUTOPROCESADOIndicadores" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 73 ,  "RITEAIndicadores" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 74 ,  "RITEAAreas" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 75 ,  "RIVentasTipoProducto" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 76 ,  "RIVentasClientes" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 77 ,  "RIAcidezAreas" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 78 ,  "RIAcidezIndicadores" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 79 ,  "RICOSTONRFFPROCESADAAreas" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 80 ,  "RICOSTONRFFPROCESADAIndicadores" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 81 ,  "RICOSTONRFFPROCESADAMOTIVOSCOSRFFPRO" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 82 ,  "RIFRUTAPROPIAIndicadores" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 83 ,  "RIFRUTAPROPIAAreas" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 84 ,  "RITONCPOHAAreas" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 85 ,  "RITONCPOHAIndicadores" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 86 ,  "RIHATRABAJADORESAreas" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 87 ,  "RIHATRABAJADORESIndicadores" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 88 ,  "RICOSTONRFFPRODAreas" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 89 ,  "RICOSTONRFFPRODIndicadores" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 90 ,  "RIINCIDENCIAPCAreas" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 91 ,  "RIINCIDENCIAPCIndicadores" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 92 ,  "RIINCIDENCIAPCTiposEnfermedades" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 93 ,  "RIINCIDENCIAPCMATERIALPALMAS" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 94 ,  "RIMARGENEBITDAAreas" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 95 ,  "RIMARGENEBITDAIndicadores" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 96 ,  "RIMARGENEBITDAMOTIVOMARGEN" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 97 ,  "RICOSTOCPOPRODUCIDOAreas" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 98 ,  "RICOSTOCPOPRODUCIDOIndicadores" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 99 ,  "RICOSTOCPOPRODUCIDOTIPOSCPO" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 100 ,  "RICOSTOCPOPRODUCIDOTipoProducto" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 101 ,  "RICOSTOTONRFFPRODUAreas" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 102 ,  "RICOSTOTONRFFPRODUIndicadores" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 103 ,  "RICOSTOTONRFFPRODUMOTIVOTONRFF" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 104 ,  "RICOSTONRFFPROCESAreas" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 105 ,  "RICOSTONRFFPROCESIndicadores" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 106 ,  "RICOSTONRFFPROCESMOTIVOSCOSRFF" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 107 ,  "RIPRECNETOTONCPOAreas" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 108 ,  "RIPRECNETOTONCPOIndicadores" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 109 ,  "RIPRECNETOTONCPOMOTIVOSPRENET" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 110 ,  "RIRFF_COMPRADAAreas" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 111 ,  "RIRFF_COMPRADAIndicadores" , new Object[]{ });
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
         GXReorganization.SetMsg( 1 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"TRABAJADORESMES", ""}) );
         GXReorganization.SetMsg( 2 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"ZONALOTES", ""}) );
         GXReorganization.SetMsg( 3 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"MATERIALPALMAS", ""}) );
         GXReorganization.SetMsg( 4 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"TiposEnfermedades", ""}) );
         GXReorganization.SetMsg( 5 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"RFF_COMPRADA", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateRFF_COMPRADA" ,  "CreateAreas" );
         ReorgExecute.RegisterPrecedence( "CreateRFF_COMPRADA" ,  "CreateIndicadores" );
         GXReorganization.SetMsg( 6 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"PRECNETOTONCPO", ""}) );
         ReorgExecute.RegisterPrecedence( "CreatePRECNETOTONCPO" ,  "CreateAreas" );
         ReorgExecute.RegisterPrecedence( "CreatePRECNETOTONCPO" ,  "CreateIndicadores" );
         ReorgExecute.RegisterPrecedence( "CreatePRECNETOTONCPO" ,  "CreateMOTIVOSPRENET" );
         GXReorganization.SetMsg( 7 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"MOTIVOSPRENET", ""}) );
         GXReorganization.SetMsg( 8 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"COSTONRFFPROCES", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateCOSTONRFFPROCES" ,  "CreateAreas" );
         ReorgExecute.RegisterPrecedence( "CreateCOSTONRFFPROCES" ,  "CreateIndicadores" );
         ReorgExecute.RegisterPrecedence( "CreateCOSTONRFFPROCES" ,  "CreateMOTIVOSCOSRFF" );
         GXReorganization.SetMsg( 9 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"MOTIVOSCOSRFF", ""}) );
         GXReorganization.SetMsg( 10 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"COSTOTONRFFPRODU", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateCOSTOTONRFFPRODU" ,  "CreateAreas" );
         ReorgExecute.RegisterPrecedence( "CreateCOSTOTONRFFPRODU" ,  "CreateIndicadores" );
         ReorgExecute.RegisterPrecedence( "CreateCOSTOTONRFFPRODU" ,  "CreateMOTIVOTONRFF" );
         GXReorganization.SetMsg( 11 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"MOTIVOTONRFF", ""}) );
         GXReorganization.SetMsg( 12 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"COSTOCPOPRODUCIDO", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateCOSTOCPOPRODUCIDO" ,  "CreateAreas" );
         ReorgExecute.RegisterPrecedence( "CreateCOSTOCPOPRODUCIDO" ,  "CreateIndicadores" );
         ReorgExecute.RegisterPrecedence( "CreateCOSTOCPOPRODUCIDO" ,  "CreateTIPOSCPO" );
         ReorgExecute.RegisterPrecedence( "CreateCOSTOCPOPRODUCIDO" ,  "CreateTipoProducto" );
         GXReorganization.SetMsg( 13 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"TIPOSCPO", ""}) );
         GXReorganization.SetMsg( 14 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"MARGENEBITDA", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateMARGENEBITDA" ,  "CreateAreas" );
         ReorgExecute.RegisterPrecedence( "CreateMARGENEBITDA" ,  "CreateIndicadores" );
         ReorgExecute.RegisterPrecedence( "CreateMARGENEBITDA" ,  "CreateMOTIVOMARGEN" );
         GXReorganization.SetMsg( 15 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"MOTIVOMARGEN", ""}) );
         GXReorganization.SetMsg( 16 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"INCIDENCIAPC", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateINCIDENCIAPC" ,  "CreateAreas" );
         ReorgExecute.RegisterPrecedence( "CreateINCIDENCIAPC" ,  "CreateIndicadores" );
         ReorgExecute.RegisterPrecedence( "CreateINCIDENCIAPC" ,  "CreateTiposEnfermedades" );
         ReorgExecute.RegisterPrecedence( "CreateINCIDENCIAPC" ,  "CreateMATERIALPALMAS" );
         GXReorganization.SetMsg( 17 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"COSTONRFFPROD", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateCOSTONRFFPROD" ,  "CreateAreas" );
         ReorgExecute.RegisterPrecedence( "CreateCOSTONRFFPROD" ,  "CreateIndicadores" );
         GXReorganization.SetMsg( 18 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"HATRABAJADORES", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateHATRABAJADORES" ,  "CreateAreas" );
         ReorgExecute.RegisterPrecedence( "CreateHATRABAJADORES" ,  "CreateIndicadores" );
         GXReorganization.SetMsg( 19 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"TONCPOHA", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateTONCPOHA" ,  "CreateAreas" );
         ReorgExecute.RegisterPrecedence( "CreateTONCPOHA" ,  "CreateIndicadores" );
         GXReorganization.SetMsg( 20 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"FRUTAPROPIA", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateFRUTAPROPIA" ,  "CreateIndicadores" );
         ReorgExecute.RegisterPrecedence( "CreateFRUTAPROPIA" ,  "CreateAreas" );
         GXReorganization.SetMsg( 21 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"COSTONRFFPROCESADA", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateCOSTONRFFPROCESADA" ,  "CreateAreas" );
         ReorgExecute.RegisterPrecedence( "CreateCOSTONRFFPROCESADA" ,  "CreateIndicadores" );
         ReorgExecute.RegisterPrecedence( "CreateCOSTONRFFPROCESADA" ,  "CreateMOTIVOSCOSRFFPRO" );
         GXReorganization.SetMsg( 22 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"MOTIVOSCOSRFFPRO", ""}) );
         GXReorganization.SetMsg( 23 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Acidez", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateAcidez" ,  "CreateAreas" );
         ReorgExecute.RegisterPrecedence( "CreateAcidez" ,  "CreateIndicadores" );
         GXReorganization.SetMsg( 24 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Clientes", ""}) );
         GXReorganization.SetMsg( 25 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Ventas", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateVentas" ,  "CreateTipoProducto" );
         ReorgExecute.RegisterPrecedence( "CreateVentas" ,  "CreateClientes" );
         GXReorganization.SetMsg( 26 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"TipoProducto", ""}) );
         GXReorganization.SetMsg( 27 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"TEA", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateTEA" ,  "CreateIndicadores" );
         ReorgExecute.RegisterPrecedence( "CreateTEA" ,  "CreateAreas" );
         GXReorganization.SetMsg( 28 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"FRUTOPROCESADO", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateFRUTOPROCESADO" ,  "CreateAreas" );
         ReorgExecute.RegisterPrecedence( "CreateFRUTOPROCESADO" ,  "CreateIndicadores" );
         GXReorganization.SetMsg( 29 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"COSTOCPOHA", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateCOSTOCPOHA" ,  "CreateAreas" );
         ReorgExecute.RegisterPrecedence( "CreateCOSTOCPOHA" ,  "CreateIndicadores" );
         GXReorganization.SetMsg( 30 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Parametros", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateParametros" ,  "CreateIndicadores" );
         GXReorganization.SetMsg( 31 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"MotivosMetas", ""}) );
         GXReorganization.SetMsg( 32 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"MetasIndicadores", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateMetasIndicadores" ,  "CreateIndicadores" );
         ReorgExecute.RegisterPrecedence( "CreateMetasIndicadores" ,  "CreateTipoMetas" );
         ReorgExecute.RegisterPrecedence( "CreateMetasIndicadores" ,  "CreateUsuarios" );
         ReorgExecute.RegisterPrecedence( "CreateMetasIndicadores" ,  "CreateMotivosMetas" );
         GXReorganization.SetMsg( 33 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"TipoMetas", ""}) );
         GXReorganization.SetMsg( 34 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"PAGOFRUTA", ""}) );
         ReorgExecute.RegisterPrecedence( "CreatePAGOFRUTA" ,  "CreateAreas" );
         ReorgExecute.RegisterPrecedence( "CreatePAGOFRUTA" ,  "CreateIndicadores" );
         ReorgExecute.RegisterPrecedence( "CreatePAGOFRUTA" ,  "CreateMotivosUsp" );
         GXReorganization.SetMsg( 35 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"MotivosUsp", ""}) );
         GXReorganization.SetMsg( 36 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"COSUSPTONFRUTA", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateCOSUSPTONFRUTA" ,  "CreateAreas" );
         ReorgExecute.RegisterPrecedence( "CreateCOSUSPTONFRUTA" ,  "CreateIndicadores" );
         GXReorganization.SetMsg( 37 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"TRIF", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateTRIF" ,  "CreateIndicadores" );
         ReorgExecute.RegisterPrecedence( "CreateTRIF" ,  "CreateAreas" );
         GXReorganization.SetMsg( 38 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"COSTOHE", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateCOSTOHE" ,  "CreateIndicadores" );
         ReorgExecute.RegisterPrecedence( "CreateCOSTOHE" ,  "CreateAreas" );
         GXReorganization.SetMsg( 39 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"ACCDAG", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateACCDAG" ,  "CreateAreas" );
         ReorgExecute.RegisterPrecedence( "CreateACCDAG" ,  "CreateIndicadores" );
         ReorgExecute.RegisterPrecedence( "CreateACCDAG" ,  "CreateProcesosACCDAG" );
         GXReorganization.SetMsg( 40 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"ProcesosACCDAG", ""}) );
         GXReorganization.SetMsg( 41 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"AusentismosTipos", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateAusentismosTipos" ,  "CreateAusentismos" );
         ReorgExecute.RegisterPrecedence( "CreateAusentismosTipos" ,  "CreateTipoAusentismo" );
         GXReorganization.SetMsg( 42 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Ausentismos", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateAusentismos" ,  "CreateIndicadores" );
         ReorgExecute.RegisterPrecedence( "CreateAusentismos" ,  "CreateAreas" );
         GXReorganization.SetMsg( 43 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"TipoAusentismo", ""}) );
         GXReorganization.SetMsg( 44 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Indicadores", ""}) );
         GXReorganization.SetMsg( 45 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Usuarios", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateUsuarios" ,  "CreateAreas" );
         GXReorganization.SetMsg( 46 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Areas", ""}) );
      }

      private void SetPrecedenceris( )
      {
         GXReorganization.SetMsg( 47 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IUSUARIOS1]"}) );
         ReorgExecute.RegisterPrecedence( "RIUsuariosAreas" ,  "CreateUsuarios" );
         ReorgExecute.RegisterPrecedence( "RIUsuariosAreas" ,  "CreateAreas" );
         GXReorganization.SetMsg( 48 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IAUSENTISMOSAREA1]"}) );
         ReorgExecute.RegisterPrecedence( "RIAusentismosIndicadores" ,  "CreateAusentismos" );
         ReorgExecute.RegisterPrecedence( "RIAusentismosIndicadores" ,  "CreateIndicadores" );
         GXReorganization.SetMsg( 49 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IAUSENTISMOSAREA2]"}) );
         ReorgExecute.RegisterPrecedence( "RIAusentismosAreas" ,  "CreateAusentismos" );
         ReorgExecute.RegisterPrecedence( "RIAusentismosAreas" ,  "CreateAreas" );
         GXReorganization.SetMsg( 50 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IAUSENTISMOSAREA5]"}) );
         ReorgExecute.RegisterPrecedence( "RIAusentismosTiposAusentismos" ,  "CreateAusentismosTipos" );
         ReorgExecute.RegisterPrecedence( "RIAusentismosTiposAusentismos" ,  "CreateAusentismos" );
         GXReorganization.SetMsg( 51 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IAUSENTISMOSAREA4]"}) );
         ReorgExecute.RegisterPrecedence( "RIAusentismosTiposTipoAusentismo" ,  "CreateAusentismosTipos" );
         ReorgExecute.RegisterPrecedence( "RIAusentismosTiposTipoAusentismo" ,  "CreateTipoAusentismo" );
         GXReorganization.SetMsg( 52 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IACCDAG3]"}) );
         ReorgExecute.RegisterPrecedence( "RIACCDAGAreas" ,  "CreateACCDAG" );
         ReorgExecute.RegisterPrecedence( "RIACCDAGAreas" ,  "CreateAreas" );
         GXReorganization.SetMsg( 53 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IACCDAG2]"}) );
         ReorgExecute.RegisterPrecedence( "RIACCDAGIndicadores" ,  "CreateACCDAG" );
         ReorgExecute.RegisterPrecedence( "RIACCDAGIndicadores" ,  "CreateIndicadores" );
         GXReorganization.SetMsg( 54 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IACCDAG1]"}) );
         ReorgExecute.RegisterPrecedence( "RIACCDAGProcesosACCDAG" ,  "CreateACCDAG" );
         ReorgExecute.RegisterPrecedence( "RIACCDAGProcesosACCDAG" ,  "CreateProcesosACCDAG" );
         GXReorganization.SetMsg( 55 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[ICOSTOHE2]"}) );
         ReorgExecute.RegisterPrecedence( "RICOSTOHEIndicadores" ,  "CreateCOSTOHE" );
         ReorgExecute.RegisterPrecedence( "RICOSTOHEIndicadores" ,  "CreateIndicadores" );
         GXReorganization.SetMsg( 56 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[ICOSTOHE1]"}) );
         ReorgExecute.RegisterPrecedence( "RICOSTOHEAreas" ,  "CreateCOSTOHE" );
         ReorgExecute.RegisterPrecedence( "RICOSTOHEAreas" ,  "CreateAreas" );
         GXReorganization.SetMsg( 57 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[ITRIF2]"}) );
         ReorgExecute.RegisterPrecedence( "RITRIFIndicadores" ,  "CreateTRIF" );
         ReorgExecute.RegisterPrecedence( "RITRIFIndicadores" ,  "CreateIndicadores" );
         GXReorganization.SetMsg( 58 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[ITRIF1]"}) );
         ReorgExecute.RegisterPrecedence( "RITRIFAreas" ,  "CreateTRIF" );
         ReorgExecute.RegisterPrecedence( "RITRIFAreas" ,  "CreateAreas" );
         GXReorganization.SetMsg( 59 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[ICOSUSPTONFRUTA2]"}) );
         ReorgExecute.RegisterPrecedence( "RICOSUSPTONFRUTAAreas" ,  "CreateCOSUSPTONFRUTA" );
         ReorgExecute.RegisterPrecedence( "RICOSUSPTONFRUTAAreas" ,  "CreateAreas" );
         GXReorganization.SetMsg( 60 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[ICOSUSPTONFRUTA1]"}) );
         ReorgExecute.RegisterPrecedence( "RICOSUSPTONFRUTAIndicadores" ,  "CreateCOSUSPTONFRUTA" );
         ReorgExecute.RegisterPrecedence( "RICOSUSPTONFRUTAIndicadores" ,  "CreateIndicadores" );
         GXReorganization.SetMsg( 61 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IPAGOFRUTA3]"}) );
         ReorgExecute.RegisterPrecedence( "RIPAGOFRUTAAreas" ,  "CreatePAGOFRUTA" );
         ReorgExecute.RegisterPrecedence( "RIPAGOFRUTAAreas" ,  "CreateAreas" );
         GXReorganization.SetMsg( 62 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IPAGOFRUTA2]"}) );
         ReorgExecute.RegisterPrecedence( "RIPAGOFRUTAIndicadores" ,  "CreatePAGOFRUTA" );
         ReorgExecute.RegisterPrecedence( "RIPAGOFRUTAIndicadores" ,  "CreateIndicadores" );
         GXReorganization.SetMsg( 63 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IPAGOFRUTA1]"}) );
         ReorgExecute.RegisterPrecedence( "RIPAGOFRUTAMotivosUsp" ,  "CreatePAGOFRUTA" );
         ReorgExecute.RegisterPrecedence( "RIPAGOFRUTAMotivosUsp" ,  "CreateMotivosUsp" );
         GXReorganization.SetMsg( 64 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IMETASINDICADORES3]"}) );
         ReorgExecute.RegisterPrecedence( "RIMetasIndicadoresIndicadores" ,  "CreateMetasIndicadores" );
         ReorgExecute.RegisterPrecedence( "RIMetasIndicadoresIndicadores" ,  "CreateIndicadores" );
         GXReorganization.SetMsg( 65 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IMETASINDICADORES2]"}) );
         ReorgExecute.RegisterPrecedence( "RIMetasIndicadoresTipoMetas" ,  "CreateMetasIndicadores" );
         ReorgExecute.RegisterPrecedence( "RIMetasIndicadoresTipoMetas" ,  "CreateTipoMetas" );
         GXReorganization.SetMsg( 66 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IMETASINDICADORES1]"}) );
         ReorgExecute.RegisterPrecedence( "RIMetasIndicadoresUsuarios" ,  "CreateMetasIndicadores" );
         ReorgExecute.RegisterPrecedence( "RIMetasIndicadoresUsuarios" ,  "CreateUsuarios" );
         GXReorganization.SetMsg( 67 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IMETASINDICADORES4]"}) );
         ReorgExecute.RegisterPrecedence( "RIMetasIndicadoresMotivosMetas" ,  "CreateMetasIndicadores" );
         ReorgExecute.RegisterPrecedence( "RIMetasIndicadoresMotivosMetas" ,  "CreateMotivosMetas" );
         GXReorganization.SetMsg( 68 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IPARAMETROS1]"}) );
         ReorgExecute.RegisterPrecedence( "RIParametrosIndicadores" ,  "CreateParametros" );
         ReorgExecute.RegisterPrecedence( "RIParametrosIndicadores" ,  "CreateIndicadores" );
         GXReorganization.SetMsg( 69 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[ICOSTOCPOHA2]"}) );
         ReorgExecute.RegisterPrecedence( "RICOSTOCPOHAAreas" ,  "CreateCOSTOCPOHA" );
         ReorgExecute.RegisterPrecedence( "RICOSTOCPOHAAreas" ,  "CreateAreas" );
         GXReorganization.SetMsg( 70 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[ICOSTOCPOHA1]"}) );
         ReorgExecute.RegisterPrecedence( "RICOSTOCPOHAIndicadores" ,  "CreateCOSTOCPOHA" );
         ReorgExecute.RegisterPrecedence( "RICOSTOCPOHAIndicadores" ,  "CreateIndicadores" );
         GXReorganization.SetMsg( 71 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IFRUTOPROCESADO2]"}) );
         ReorgExecute.RegisterPrecedence( "RIFRUTOPROCESADOAreas" ,  "CreateFRUTOPROCESADO" );
         ReorgExecute.RegisterPrecedence( "RIFRUTOPROCESADOAreas" ,  "CreateAreas" );
         GXReorganization.SetMsg( 72 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IFRUTOPROCESADO1]"}) );
         ReorgExecute.RegisterPrecedence( "RIFRUTOPROCESADOIndicadores" ,  "CreateFRUTOPROCESADO" );
         ReorgExecute.RegisterPrecedence( "RIFRUTOPROCESADOIndicadores" ,  "CreateIndicadores" );
         GXReorganization.SetMsg( 73 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[ITEA2]"}) );
         ReorgExecute.RegisterPrecedence( "RITEAIndicadores" ,  "CreateTEA" );
         ReorgExecute.RegisterPrecedence( "RITEAIndicadores" ,  "CreateIndicadores" );
         GXReorganization.SetMsg( 74 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[ITEA1]"}) );
         ReorgExecute.RegisterPrecedence( "RITEAAreas" ,  "CreateTEA" );
         ReorgExecute.RegisterPrecedence( "RITEAAreas" ,  "CreateAreas" );
         GXReorganization.SetMsg( 75 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IVENTAS1]"}) );
         ReorgExecute.RegisterPrecedence( "RIVentasTipoProducto" ,  "CreateVentas" );
         ReorgExecute.RegisterPrecedence( "RIVentasTipoProducto" ,  "CreateTipoProducto" );
         GXReorganization.SetMsg( 76 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IVENTAS2]"}) );
         ReorgExecute.RegisterPrecedence( "RIVentasClientes" ,  "CreateVentas" );
         ReorgExecute.RegisterPrecedence( "RIVentasClientes" ,  "CreateClientes" );
         GXReorganization.SetMsg( 77 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IACIDEZ2]"}) );
         ReorgExecute.RegisterPrecedence( "RIAcidezAreas" ,  "CreateAcidez" );
         ReorgExecute.RegisterPrecedence( "RIAcidezAreas" ,  "CreateAreas" );
         GXReorganization.SetMsg( 78 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IACIDEZ1]"}) );
         ReorgExecute.RegisterPrecedence( "RIAcidezIndicadores" ,  "CreateAcidez" );
         ReorgExecute.RegisterPrecedence( "RIAcidezIndicadores" ,  "CreateIndicadores" );
         GXReorganization.SetMsg( 79 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[ICOSTONRFFPROCESADA3]"}) );
         ReorgExecute.RegisterPrecedence( "RICOSTONRFFPROCESADAAreas" ,  "CreateCOSTONRFFPROCESADA" );
         ReorgExecute.RegisterPrecedence( "RICOSTONRFFPROCESADAAreas" ,  "CreateAreas" );
         GXReorganization.SetMsg( 80 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[ICOSTONRFFPROCESADA2]"}) );
         ReorgExecute.RegisterPrecedence( "RICOSTONRFFPROCESADAIndicadores" ,  "CreateCOSTONRFFPROCESADA" );
         ReorgExecute.RegisterPrecedence( "RICOSTONRFFPROCESADAIndicadores" ,  "CreateIndicadores" );
         GXReorganization.SetMsg( 81 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[ICOSTONRFFPROCESADA1]"}) );
         ReorgExecute.RegisterPrecedence( "RICOSTONRFFPROCESADAMOTIVOSCOSRFFPRO" ,  "CreateCOSTONRFFPROCESADA" );
         ReorgExecute.RegisterPrecedence( "RICOSTONRFFPROCESADAMOTIVOSCOSRFFPRO" ,  "CreateMOTIVOSCOSRFFPRO" );
         GXReorganization.SetMsg( 82 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IFRUTAPROPIA2]"}) );
         ReorgExecute.RegisterPrecedence( "RIFRUTAPROPIAIndicadores" ,  "CreateFRUTAPROPIA" );
         ReorgExecute.RegisterPrecedence( "RIFRUTAPROPIAIndicadores" ,  "CreateIndicadores" );
         GXReorganization.SetMsg( 83 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IFRUTAPROPIA1]"}) );
         ReorgExecute.RegisterPrecedence( "RIFRUTAPROPIAAreas" ,  "CreateFRUTAPROPIA" );
         ReorgExecute.RegisterPrecedence( "RIFRUTAPROPIAAreas" ,  "CreateAreas" );
         GXReorganization.SetMsg( 84 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[ITONCPOHA2]"}) );
         ReorgExecute.RegisterPrecedence( "RITONCPOHAAreas" ,  "CreateTONCPOHA" );
         ReorgExecute.RegisterPrecedence( "RITONCPOHAAreas" ,  "CreateAreas" );
         GXReorganization.SetMsg( 85 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[ITONCPOHA1]"}) );
         ReorgExecute.RegisterPrecedence( "RITONCPOHAIndicadores" ,  "CreateTONCPOHA" );
         ReorgExecute.RegisterPrecedence( "RITONCPOHAIndicadores" ,  "CreateIndicadores" );
         GXReorganization.SetMsg( 86 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IHATRABAJADORES2]"}) );
         ReorgExecute.RegisterPrecedence( "RIHATRABAJADORESAreas" ,  "CreateHATRABAJADORES" );
         ReorgExecute.RegisterPrecedence( "RIHATRABAJADORESAreas" ,  "CreateAreas" );
         GXReorganization.SetMsg( 87 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IHATRABAJADORES1]"}) );
         ReorgExecute.RegisterPrecedence( "RIHATRABAJADORESIndicadores" ,  "CreateHATRABAJADORES" );
         ReorgExecute.RegisterPrecedence( "RIHATRABAJADORESIndicadores" ,  "CreateIndicadores" );
         GXReorganization.SetMsg( 88 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[ICOSTONRFFPROD2]"}) );
         ReorgExecute.RegisterPrecedence( "RICOSTONRFFPRODAreas" ,  "CreateCOSTONRFFPROD" );
         ReorgExecute.RegisterPrecedence( "RICOSTONRFFPRODAreas" ,  "CreateAreas" );
         GXReorganization.SetMsg( 89 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[ICOSTONRFFPROD1]"}) );
         ReorgExecute.RegisterPrecedence( "RICOSTONRFFPRODIndicadores" ,  "CreateCOSTONRFFPROD" );
         ReorgExecute.RegisterPrecedence( "RICOSTONRFFPRODIndicadores" ,  "CreateIndicadores" );
         GXReorganization.SetMsg( 90 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IINCIDENCIAPC4]"}) );
         ReorgExecute.RegisterPrecedence( "RIINCIDENCIAPCAreas" ,  "CreateINCIDENCIAPC" );
         ReorgExecute.RegisterPrecedence( "RIINCIDENCIAPCAreas" ,  "CreateAreas" );
         GXReorganization.SetMsg( 91 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IINCIDENCIAPC3]"}) );
         ReorgExecute.RegisterPrecedence( "RIINCIDENCIAPCIndicadores" ,  "CreateINCIDENCIAPC" );
         ReorgExecute.RegisterPrecedence( "RIINCIDENCIAPCIndicadores" ,  "CreateIndicadores" );
         GXReorganization.SetMsg( 92 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IINCIDENCIAPC2]"}) );
         ReorgExecute.RegisterPrecedence( "RIINCIDENCIAPCTiposEnfermedades" ,  "CreateINCIDENCIAPC" );
         ReorgExecute.RegisterPrecedence( "RIINCIDENCIAPCTiposEnfermedades" ,  "CreateTiposEnfermedades" );
         GXReorganization.SetMsg( 93 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IINCIDENCIAPC1]"}) );
         ReorgExecute.RegisterPrecedence( "RIINCIDENCIAPCMATERIALPALMAS" ,  "CreateINCIDENCIAPC" );
         ReorgExecute.RegisterPrecedence( "RIINCIDENCIAPCMATERIALPALMAS" ,  "CreateMATERIALPALMAS" );
         GXReorganization.SetMsg( 94 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IMARGENEBITDA3]"}) );
         ReorgExecute.RegisterPrecedence( "RIMARGENEBITDAAreas" ,  "CreateMARGENEBITDA" );
         ReorgExecute.RegisterPrecedence( "RIMARGENEBITDAAreas" ,  "CreateAreas" );
         GXReorganization.SetMsg( 95 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IMARGENEBITDA2]"}) );
         ReorgExecute.RegisterPrecedence( "RIMARGENEBITDAIndicadores" ,  "CreateMARGENEBITDA" );
         ReorgExecute.RegisterPrecedence( "RIMARGENEBITDAIndicadores" ,  "CreateIndicadores" );
         GXReorganization.SetMsg( 96 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IMARGENEBITDA1]"}) );
         ReorgExecute.RegisterPrecedence( "RIMARGENEBITDAMOTIVOMARGEN" ,  "CreateMARGENEBITDA" );
         ReorgExecute.RegisterPrecedence( "RIMARGENEBITDAMOTIVOMARGEN" ,  "CreateMOTIVOMARGEN" );
         GXReorganization.SetMsg( 97 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[ICOSTOCPOPRODUCIDO4]"}) );
         ReorgExecute.RegisterPrecedence( "RICOSTOCPOPRODUCIDOAreas" ,  "CreateCOSTOCPOPRODUCIDO" );
         ReorgExecute.RegisterPrecedence( "RICOSTOCPOPRODUCIDOAreas" ,  "CreateAreas" );
         GXReorganization.SetMsg( 98 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[ICOSTOCPOPRODUCIDO3]"}) );
         ReorgExecute.RegisterPrecedence( "RICOSTOCPOPRODUCIDOIndicadores" ,  "CreateCOSTOCPOPRODUCIDO" );
         ReorgExecute.RegisterPrecedence( "RICOSTOCPOPRODUCIDOIndicadores" ,  "CreateIndicadores" );
         GXReorganization.SetMsg( 99 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[ICOSTOCPOPRODUCIDO2]"}) );
         ReorgExecute.RegisterPrecedence( "RICOSTOCPOPRODUCIDOTIPOSCPO" ,  "CreateCOSTOCPOPRODUCIDO" );
         ReorgExecute.RegisterPrecedence( "RICOSTOCPOPRODUCIDOTIPOSCPO" ,  "CreateTIPOSCPO" );
         GXReorganization.SetMsg( 100 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[ICOSTOCPOPRODUCIDO1]"}) );
         ReorgExecute.RegisterPrecedence( "RICOSTOCPOPRODUCIDOTipoProducto" ,  "CreateCOSTOCPOPRODUCIDO" );
         ReorgExecute.RegisterPrecedence( "RICOSTOCPOPRODUCIDOTipoProducto" ,  "CreateTipoProducto" );
         GXReorganization.SetMsg( 101 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[ICOSTOTONRFFPRODU3]"}) );
         ReorgExecute.RegisterPrecedence( "RICOSTOTONRFFPRODUAreas" ,  "CreateCOSTOTONRFFPRODU" );
         ReorgExecute.RegisterPrecedence( "RICOSTOTONRFFPRODUAreas" ,  "CreateAreas" );
         GXReorganization.SetMsg( 102 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[ICOSTOTONRFFPRODU2]"}) );
         ReorgExecute.RegisterPrecedence( "RICOSTOTONRFFPRODUIndicadores" ,  "CreateCOSTOTONRFFPRODU" );
         ReorgExecute.RegisterPrecedence( "RICOSTOTONRFFPRODUIndicadores" ,  "CreateIndicadores" );
         GXReorganization.SetMsg( 103 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[ICOSTOTONRFFPRODU1]"}) );
         ReorgExecute.RegisterPrecedence( "RICOSTOTONRFFPRODUMOTIVOTONRFF" ,  "CreateCOSTOTONRFFPRODU" );
         ReorgExecute.RegisterPrecedence( "RICOSTOTONRFFPRODUMOTIVOTONRFF" ,  "CreateMOTIVOTONRFF" );
         GXReorganization.SetMsg( 104 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[ICOSTONRFFPROCES3]"}) );
         ReorgExecute.RegisterPrecedence( "RICOSTONRFFPROCESAreas" ,  "CreateCOSTONRFFPROCES" );
         ReorgExecute.RegisterPrecedence( "RICOSTONRFFPROCESAreas" ,  "CreateAreas" );
         GXReorganization.SetMsg( 105 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[ICOSTONRFFPROCES2]"}) );
         ReorgExecute.RegisterPrecedence( "RICOSTONRFFPROCESIndicadores" ,  "CreateCOSTONRFFPROCES" );
         ReorgExecute.RegisterPrecedence( "RICOSTONRFFPROCESIndicadores" ,  "CreateIndicadores" );
         GXReorganization.SetMsg( 106 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[ICOSTONRFFPROCES1]"}) );
         ReorgExecute.RegisterPrecedence( "RICOSTONRFFPROCESMOTIVOSCOSRFF" ,  "CreateCOSTONRFFPROCES" );
         ReorgExecute.RegisterPrecedence( "RICOSTONRFFPROCESMOTIVOSCOSRFF" ,  "CreateMOTIVOSCOSRFF" );
         GXReorganization.SetMsg( 107 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IPRECNETOTONCPO3]"}) );
         ReorgExecute.RegisterPrecedence( "RIPRECNETOTONCPOAreas" ,  "CreatePRECNETOTONCPO" );
         ReorgExecute.RegisterPrecedence( "RIPRECNETOTONCPOAreas" ,  "CreateAreas" );
         GXReorganization.SetMsg( 108 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IPRECNETOTONCPO2]"}) );
         ReorgExecute.RegisterPrecedence( "RIPRECNETOTONCPOIndicadores" ,  "CreatePRECNETOTONCPO" );
         ReorgExecute.RegisterPrecedence( "RIPRECNETOTONCPOIndicadores" ,  "CreateIndicadores" );
         GXReorganization.SetMsg( 109 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IPRECNETOTONCPO1]"}) );
         ReorgExecute.RegisterPrecedence( "RIPRECNETOTONCPOMOTIVOSPRENET" ,  "CreatePRECNETOTONCPO" );
         ReorgExecute.RegisterPrecedence( "RIPRECNETOTONCPOMOTIVOSPRENET" ,  "CreateMOTIVOSPRENET" );
         GXReorganization.SetMsg( 110 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IRFF_COMPRADA2]"}) );
         ReorgExecute.RegisterPrecedence( "RIRFF_COMPRADAAreas" ,  "CreateRFF_COMPRADA" );
         ReorgExecute.RegisterPrecedence( "RIRFF_COMPRADAAreas" ,  "CreateAreas" );
         GXReorganization.SetMsg( 111 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IRFF_COMPRADA1]"}) );
         ReorgExecute.RegisterPrecedence( "RIRFF_COMPRADAIndicadores" ,  "CreateRFF_COMPRADA" );
         ReorgExecute.RegisterPrecedence( "RIRFF_COMPRADAIndicadores" ,  "CreateIndicadores" );
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

      public void DropTableConstraints( string sTableName )
      {
         string cmdBuffer;
         /* Using cursor P00045 */
         pr_default.execute(3, new Object[] {sTableName});
         while ( (pr_default.getStatus(3) != 101) )
         {
            constid = P00045_Aconstid[0];
            nconstid = P00045_nconstid[0];
            fkeyid = P00045_Afkeyid[0];
            nfkeyid = P00045_nfkeyid[0];
            rkeyid = P00045_Arkeyid[0];
            nrkeyid = P00045_nrkeyid[0];
            cmdBuffer = "ALTER TABLE " + "[" + fkeyid + "] DROP CONSTRAINT " + constid;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      public void UtilsCleanup( )
      {
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         DS = new GxDataStore();
         ErrMsg = "";
         DataBaseName = "";
         defaultUsers = new GeneXus.Utils.GxStringCollection();
         defaultUser = "";
         sSchemaVar = "";
         nsSchemaVar = false;
         scmdbuf = "";
         P00012_AsSchemaVar = new string[] {""} ;
         P00012_nsSchemaVar = new bool[] {false} ;
         P00023_AsSchemaVar = new string[] {""} ;
         P00023_nsSchemaVar = new bool[] {false} ;
         sTableName = "";
         sMySchemaName = "";
         tablename = "";
         ntablename = false;
         schemaname = "";
         nschemaname = false;
         P00034_Atablename = new string[] {""} ;
         P00034_ntablename = new bool[] {false} ;
         P00034_Aschemaname = new string[] {""} ;
         P00034_nschemaname = new bool[] {false} ;
         constid = "";
         nconstid = false;
         fkeyid = "";
         nfkeyid = false;
         P00045_Aconstid = new string[] {""} ;
         P00045_nconstid = new bool[] {false} ;
         P00045_Afkeyid = new string[] {""} ;
         P00045_nfkeyid = new bool[] {false} ;
         P00045_Arkeyid = new int[1] ;
         P00045_nrkeyid = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reorg__default(),
            new Object[][] {
                new Object[] {
               P00012_AsSchemaVar
               }
               , new Object[] {
               P00023_AsSchemaVar
               }
               , new Object[] {
               P00034_Atablename, P00034_Aschemaname
               }
               , new Object[] {
               P00045_Aconstid, P00045_Afkeyid, P00045_Arkeyid
               }
            }
         );
         /* GeneXus formulas. */
      }

      protected short ErrCode ;
      protected short Count ;
      protected short Res ;
      protected short setupDB ;
      protected int rkeyid ;
      protected string ErrMsg ;
      protected string DataBaseName ;
      protected string cmdBuffer ;
      protected string defaultUser ;
      protected string sSchemaVar ;
      protected string scmdbuf ;
      protected string sTableName ;
      protected string sMySchemaName ;
      protected bool nsSchemaVar ;
      protected bool ntablename ;
      protected bool nschemaname ;
      protected bool nconstid ;
      protected bool nfkeyid ;
      protected bool nrkeyid ;
      protected string tablename ;
      protected string schemaname ;
      protected string constid ;
      protected string fkeyid ;
      protected GeneXus.Utils.GxStringCollection defaultUsers ;
      protected GxDataStore DS ;
      protected IGxDataStore dsDefault ;
      protected GxCommand RGZ ;
      protected IDataStoreProvider pr_default ;
      protected string[] P00012_AsSchemaVar ;
      protected bool[] P00012_nsSchemaVar ;
      protected string[] P00023_AsSchemaVar ;
      protected bool[] P00023_nsSchemaVar ;
      protected string[] P00034_Atablename ;
      protected bool[] P00034_ntablename ;
      protected string[] P00034_Aschemaname ;
      protected bool[] P00034_nschemaname ;
      protected string[] P00045_Aconstid ;
      protected bool[] P00045_nconstid ;
      protected string[] P00045_Afkeyid ;
      protected bool[] P00045_nfkeyid ;
      protected int[] P00045_Arkeyid ;
      protected bool[] P00045_nrkeyid ;
   }

   public class reorg__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00012;
          prmP00012 = new Object[] {
          };
          Object[] prmP00023;
          prmP00023 = new Object[] {
          };
          Object[] prmP00034;
          prmP00034 = new Object[] {
          new ParDef("@sTableName",GXType.Char,255,0) ,
          new ParDef("@sMySchemaName",GXType.Char,255,0)
          };
          Object[] prmP00045;
          prmP00045 = new Object[] {
          new ParDef("@sTableName",GXType.Char,255,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00012", "SELECT SCHEMA_NAME() ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00012,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00023", "SELECT USER_NAME() ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00023,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00034", "SELECT TABLE_NAME, TABLE_SCHEMA FROM INFORMATION_SCHEMA.TABLES WHERE (TABLE_NAME = @sTableName) AND (TABLE_SCHEMA = @sMySchemaName) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00034,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00045", "SELECT OBJECT_NAME(object_id), OBJECT_NAME(parent_object_id), referenced_object_id FROM sys.foreign_keys WHERE referenced_object_id = OBJECT_ID(RTRIM(LTRIM(@sTableName))) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00045,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 255);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 255);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
       }
    }

 }

}
