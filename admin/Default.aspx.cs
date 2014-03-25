using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class admin_Default : System.Web.UI.Page
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

            //Recogemos el nombre del patrocinador
            string titulo = string.Empty;

            if (this.txtBuscador.Text != string.Empty)
                titulo = "%" + this.txtBuscador.Text + "%";
            else
                titulo = "%";
            
            DataSet ds = new DataSet();
            ds = proyecto.dameProyectos(titulo,2);

            //Si todo correcto, mostramos los datos en el Grid
            if (ds.Tables["DATOS"].Rows.Count > 0)
            {
                //Mostramos los resultados obtenidos
                objUtils.cargarDatos(ds, rpProyectos);
            }
        }
        catch (Exception e) { string resultado = e.Message; }

    }

    #endregion

    #region botones

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        Response.Redirect("nuevoProyecto.aspx");
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        this.CargarProyectos();
    }

    #endregion
}