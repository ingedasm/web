using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
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
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs.general.ui {
   public class sidebaritemsdp : GXProcedure
   {
      public sidebaritemsdp( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore5 = context.GetDataStore("DataStore5");
         dsDataStore4 = context.GetDataStore("DataStore4");
         dsDataStore3 = context.GetDataStore("DataStore3");
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("DSMenuIndicadores", true);
      }

      public sidebaritemsdp( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore5 = context.GetDataStore("DataStore5");
         dsDataStore4 = context.GetDataStore("DataStore4");
         dsDataStore3 = context.GetDataStore("DataStore3");
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_UsuariosCodigo ,
                           out GXBaseCollection<GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem> aP1_Gxm2rootcol )
      {
         this.AV7UsuariosCodigo = aP0_UsuariosCodigo;
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem>( context, "SidebarItem", "GeneXusUnanimo") ;
         initialize();
         executePrivate();
         aP1_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem> executeUdp( string aP0_UsuariosCodigo )
      {
         execute(aP0_UsuariosCodigo, out aP1_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( string aP0_UsuariosCodigo ,
                                 out GXBaseCollection<GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem> aP1_Gxm2rootcol )
      {
         sidebaritemsdp objsidebaritemsdp;
         objsidebaritemsdp = new sidebaritemsdp();
         objsidebaritemsdp.AV7UsuariosCodigo = aP0_UsuariosCodigo;
         objsidebaritemsdp.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem>( context, "SidebarItem", "GeneXusUnanimo") ;
         objsidebaritemsdp.context.SetSubmitInitialConfig(context);
         objsidebaritemsdp.initialize();
         Submit( executePrivateCatch,objsidebaritemsdp);
         aP1_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((sidebaritemsdp)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_objcol_SdtProgramNames_ProgramName1 = AV5wwProgramNames;
         new GeneXus.Programs.general.ui.listprograms(context ).execute( out  GXt_objcol_SdtProgramNames_ProgramName1) ;
         AV5wwProgramNames = GXt_objcol_SdtProgramNames_ProgramName1;
         AV14GXV1 = 1;
         while ( AV14GXV1 <= AV5wwProgramNames.Count )
         {
            AV6wwProgramName = ((GeneXus.Programs.general.ui.SdtProgramNames_ProgramName)AV5wwProgramNames.Item(AV14GXV1));
            if ( StringUtil.StrCmp(A16UsuariosCodigo, AV7UsuariosCodigo) == 0 )
            {
               Gxm1sidebaritems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem(context);
               Gxm2rootcol.Add(Gxm1sidebaritems, 0);
               Gxm1sidebaritems.gxTpr_Id = AV6wwProgramName.gxTpr_Name;
               Gxm1sidebaritems.gxTpr_Title = AV6wwProgramName.gxTpr_Description;
               Gxm1sidebaritems.gxTpr_Target = AV6wwProgramName.gxTpr_Link;
               Gxm1sidebaritems.gxTpr_Hassubitems = false;
            }
            AV14GXV1 = (int)(AV14GXV1+1);
         }
         /* Using cursor P00012 */
         pr_default.execute(0, new Object[] {AV7UsuariosCodigo});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A291MenuCodigo = P00012_A291MenuCodigo[0];
            A16UsuariosCodigo = P00012_A16UsuariosCodigo[0];
            A292MenuNombre = P00012_A292MenuNombre[0];
            A294MenuIcono = P00012_A294MenuIcono[0];
            A292MenuNombre = P00012_A292MenuNombre[0];
            A294MenuIcono = P00012_A294MenuIcono[0];
            Gxm1sidebaritems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem(context);
            Gxm2rootcol.Add(Gxm1sidebaritems, 0);
            Gxm1sidebaritems.gxTpr_Id = A291MenuCodigo;
            Gxm1sidebaritems.gxTpr_Title = A292MenuNombre;
            Gxm1sidebaritems.gxTpr_Icon = A294MenuIcono;
            Gxm1sidebaritems.gxTpr_Target = formatLink("#") ;
            Gxm1sidebaritems.gxTpr_Hassubitems = true;
            /* Using cursor P00013 */
            pr_default.execute(1, new Object[] {A16UsuariosCodigo, A291MenuCodigo});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A295ObjetosCodigo = P00013_A295ObjetosCodigo[0];
               A296ObjetosNombre = P00013_A296ObjetosNombre[0];
               A298PermisosOpcionesNro = P00013_A298PermisosOpcionesNro[0];
               A296ObjetosNombre = P00013_A296ObjetosNombre[0];
               Gxm3sidebaritems_sidebarsubitems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem_SubItem(context);
               Gxm1sidebaritems.gxTpr_Sidebarsubitems.Add(Gxm3sidebaritems_sidebarsubitems, 0);
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Id = A295ObjetosCodigo;
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Title = A296ObjetosNombre;
               AV8OpcionesMenuNombre = StringUtil.Trim( A295ObjetosCodigo) + ".aspx";
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Target = formatLink(AV8OpcionesMenuNombre) ;
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Hassubitems = false;
               pr_default.readNext(1);
            }
            pr_default.close(1);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         AV5wwProgramNames = new GXBaseCollection<GeneXus.Programs.general.ui.SdtProgramNames_ProgramName>( context, "ProgramName", "KbIndicadores");
         GXt_objcol_SdtProgramNames_ProgramName1 = new GXBaseCollection<GeneXus.Programs.general.ui.SdtProgramNames_ProgramName>( context, "ProgramName", "KbIndicadores");
         AV6wwProgramName = new GeneXus.Programs.general.ui.SdtProgramNames_ProgramName(context);
         A16UsuariosCodigo = "";
         Gxm1sidebaritems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem(context);
         scmdbuf = "";
         P00012_A291MenuCodigo = new string[] {""} ;
         P00012_A16UsuariosCodigo = new string[] {""} ;
         P00012_A292MenuNombre = new string[] {""} ;
         P00012_A294MenuIcono = new string[] {""} ;
         A291MenuCodigo = "";
         A292MenuNombre = "";
         A294MenuIcono = "";
         P00013_A16UsuariosCodigo = new string[] {""} ;
         P00013_A291MenuCodigo = new string[] {""} ;
         P00013_A295ObjetosCodigo = new string[] {""} ;
         P00013_A296ObjetosNombre = new string[] {""} ;
         P00013_A298PermisosOpcionesNro = new short[1] ;
         A295ObjetosCodigo = "";
         A296ObjetosNombre = "";
         Gxm3sidebaritems_sidebarsubitems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem_SubItem(context);
         AV8OpcionesMenuNombre = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.general.ui.sidebaritemsdp__default(),
            new Object[][] {
                new Object[] {
               P00012_A291MenuCodigo, P00012_A16UsuariosCodigo, P00012_A292MenuNombre, P00012_A294MenuIcono
               }
               , new Object[] {
               P00013_A16UsuariosCodigo, P00013_A291MenuCodigo, P00013_A295ObjetosCodigo, P00013_A296ObjetosNombre, P00013_A298PermisosOpcionesNro
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A298PermisosOpcionesNro ;
      private int AV14GXV1 ;
      private string scmdbuf ;
      private string AV7UsuariosCodigo ;
      private string A16UsuariosCodigo ;
      private string A291MenuCodigo ;
      private string A292MenuNombre ;
      private string A294MenuIcono ;
      private string A295ObjetosCodigo ;
      private string A296ObjetosNombre ;
      private string AV8OpcionesMenuNombre ;
      private IGxDataStore dsDataStore5 ;
      private IGxDataStore dsDataStore4 ;
      private IGxDataStore dsDataStore3 ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00012_A291MenuCodigo ;
      private string[] P00012_A16UsuariosCodigo ;
      private string[] P00012_A292MenuNombre ;
      private string[] P00012_A294MenuIcono ;
      private string[] P00013_A16UsuariosCodigo ;
      private string[] P00013_A291MenuCodigo ;
      private string[] P00013_A295ObjetosCodigo ;
      private string[] P00013_A296ObjetosNombre ;
      private short[] P00013_A298PermisosOpcionesNro ;
      private GXBaseCollection<GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem> aP1_Gxm2rootcol ;
      private GXBaseCollection<GeneXus.Programs.general.ui.SdtProgramNames_ProgramName> AV5wwProgramNames ;
      private GXBaseCollection<GeneXus.Programs.general.ui.SdtProgramNames_ProgramName> GXt_objcol_SdtProgramNames_ProgramName1 ;
      private GXBaseCollection<GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem> Gxm2rootcol ;
      private GeneXus.Programs.general.ui.SdtProgramNames_ProgramName AV6wwProgramName ;
      private GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem Gxm1sidebaritems ;
      private GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem_SubItem Gxm3sidebaritems_sidebarsubitems ;
   }

   public class sidebaritemsdp__default : DataStoreHelperBase, IDataStoreHelper
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
          new ParDef("@AV7UsuariosCodigo",GXType.NVarChar,150,0)
          };
          Object[] prmP00013;
          prmP00013 = new Object[] {
          new ParDef("@UsuariosCodigo",GXType.NVarChar,150,0) ,
          new ParDef("@MenuCodigo",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00012", "SELECT T1.[MenuCodigo], T1.[UsuariosCodigo], T2.[MenuNombre], T2.[MenuIcono] FROM ([Permisos] T1 INNER JOIN [Menu] T2 ON T2.[MenuCodigo] = T1.[MenuCodigo]) WHERE T1.[UsuariosCodigo] = @AV7UsuariosCodigo ORDER BY T1.[UsuariosCodigo] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00012,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00013", "SELECT T1.[UsuariosCodigo], T1.[MenuCodigo], T1.[ObjetosCodigo], T2.[ObjetosNombre], T1.[PermisosOpcionesNro] FROM ([PermisosOpciones] T1 INNER JOIN [Objetos] T2 ON T2.[ObjetosCodigo] = T1.[ObjetosCodigo]) WHERE T1.[UsuariosCodigo] = @UsuariosCodigo and T1.[MenuCodigo] = @MenuCodigo ORDER BY T1.[UsuariosCodigo], T1.[MenuCodigo] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00013,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
       }
    }

 }

}
