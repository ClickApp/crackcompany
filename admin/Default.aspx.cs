using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class admin_Default : System.Web.UI.Page
{
    #region variables

    public Utilidades objUtils = new Utilidades();

    #endregion

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
            else
                objUtils.cargarDatos(null, rpProyectos);
        }
        catch (Exception e) { string resultado = e.Message; }

    }

    #endregion

    #region botones

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        this.CargarProyectos();
    }

    protected void btnGestionarIconos_Click(object sender, EventArgs e)
    {
        Proyectos proyecto = new Proyectos();

        if (this.hidAccion.Value == "1") //Activar o Desactivar un Proyecto
        {
            proyecto.activarProyecto(int.Parse(this.hidPID.Value.ToString()), bool.Parse(this.hidActivo.Value.ToString()));
            this.CargarProyectos();
        }
        else if (this.hidAccion.Value == "2") //Editar un Proyecto
        {
            Session["proyectoId"] = this.hidPID.Value;
            Response.Redirect("editarProyecto.aspx");

        }
        else if (this.hidAccion.Value == "3") //Eliminar un Proyecto
        {
            string titulo = this.hidTitulo.Value;
            this.hidPID.Value = this.hidPID.Value;

            //Mostramos el PopUp de confirmación de eliminación de un Proyecto
            this.Lconfirmacion.Text = "¿Estas seguro de querer eliminar el proyecto: <b>" + titulo + "</b>? Se eliminar&aacute; la informaci&oacute;n relativa al mismo.";
            this.ModalPopupExtenderConfirmacion.Show();
        }
    }

    protected void btnSi_Click(object sender, EventArgs e)
    {
        Proyectos proyecto = new Proyectos();
        proyecto.eliminarProyecto(int.Parse(this.hidPID.Value.ToString()));        
       
        this.CargarProyectos();
    }

    protected void btnNo_Click(object sender, EventArgs e)
    {
        this.ModalPopupExtenderConfirmacion.Hide();
        this.CargarProyectos();
    }

    #endregion    
}