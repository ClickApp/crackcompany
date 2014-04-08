using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class es_MasterPageES : System.Web.UI.MasterPage
{
    #region Carga Página

    protected void Page_Load(object sender, EventArgs e)
    {
        this.CargarProyectos();     
    }

    private void CargarProyectos()
    {
        try
        {
            //Accedemos a la clase de negocio
            Proyectos proyecto = new Proyectos();
            Utilidades objUtils = new Utilidades();

            //Obtengo los proyectos
            DataSet ds = new DataSet();
            ds = proyecto.dameProyectos("%", 2);

            //Si todo correcto, mostramos los datos en el Grid
            if (ds.Tables["DATOS"].Rows.Count > 0)
            {
                //Mostramos los resultados obtenidos
                objUtils.cargarDatos(ds, rpProyectos);
            }
            else
                objUtils.cargarDatos(null, rpProyectos);

        }
        catch (Exception e) { string resultado = e.Message; }
    }

    #endregion
}
