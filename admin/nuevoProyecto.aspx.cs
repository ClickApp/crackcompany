using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class admin_nuevoProyecto : System.Web.UI.Page
{
    #region Variables

    Proyectos proyecto = new Proyectos();
    ProcesarImagenes procesarImg = new ProcesarImagenes();

    #endregion

    #region Carga Página

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //Preparo las capas según se tienen que mostrar
            this.divLogo.Visible = false;
            this.divDescripcion.Visible = false;
            this.LParcial.Visible = false;
            this.fila_blanco1.Visible = false;
            this.fila_error1.Visible = false;
            this.fila_blanco2.Visible = false;
            this.fila_error2.Visible = false;
        }
    }

    #endregion

    #region eventos

    protected void HTMLEditorExtender_ImageUploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
    {
        string fullpath = Server.MapPath("~/img/") + e.FileName;

        HTMLEditorExtender.AjaxFileUpload.SaveAs(fullpath);

        e.PostedUrl = Page.ResolveUrl("~/img/" + e.FileName);
    }

    #endregion

    #region botones

    protected void btnSiguiente_Click(object sender, EventArgs e)
    {
        bool anadir = false;

        #region comprobaciones

        if (this.txtTitulo.Text != string.Empty)
        {
            anadir = true;

            //Compruebo que no exista ya un proyecto con ese nombre
            if (proyecto.existeProyecto(this.txtTitulo.Text))
            {
                anadir = false;
                this.Lerror1.Text = "Uy! Ya existe un proyecto con ese título.";               
            }
        }
        else
        {
            this.Lerror1.Text = "Vaya! No has indicado el título del proyecto.";  
            anadir = false;
        }

        #endregion

        #region anadir

        if (anadir)
        {
            //Añado el proyecto porque todo ha ido bien
            this.hidPID.Value = proyecto.anadirProyecto(this.txtTitulo.Text, this.txtSubtitulo.Text, 0, string.Empty, string.Empty, 0);

            this.LParcial.Text = "<span class=\"titulo\">" + this.txtTitulo.Text + "</span>&nbsp;&nbsp;<span class=\"subtitulo\">" + this.txtSubtitulo.Text + "</span>";

            //Preparo las capas según se tienen que mostrar
            this.divTitulos.Visible = false;
            this.divLogo.Visible = true;
            this.divDescripcion.Visible = false;
            this.LParcial.Visible = true;
            this.fila_blanco1.Visible = false;
            this.fila_error1.Visible = false;
        }
        else
        {
            this.fila_blanco1.Visible = true;
            this.fila_error1.Visible = true;
        }

        #endregion
    }

    protected void btnSubir_Click(object sender, EventArgs e)
    {
        bool anadir = false;

        #region comprobaciones

        if (this.txtLogo.HasFile)
        {
            anadir = true;
          
            //Compruebo que sea una imagen
            if (!procesarImg.validaImagen(Path.GetExtension(txtLogo.FileName)))
            {
                anadir = false;
                this.Lerror2.Text = "Uy! Parece que lo que intentas subir no es una imagen.";
            }
        }
        else
        {
            this.Lerror2.Text = "Vaya! No has seleccionado el logo.";
            anadir = false;
        }

        #endregion

        #region anadir

        if (anadir)
        {
            //Añado el logo del proyecto porque todo ha ido bien y actualizo los datos del proyecto
            this.grabaFoto(this.hidPID.Value.ToString());
            proyecto.actualizaProyecto(int.Parse(this.hidPID.Value.ToString()),this.txtTitulo.Text, this.txtSubtitulo.Text, 1, string.Empty, string.Empty, 0);

            this.hidPID.Value = this.hidPID.Value.ToString();

            this.LParcial.Text = "<img src=\"../img/logo" + this.hidPID.Value.ToString() + ".png\" alt=\"" + this.txtTitulo.Text + "\" width=\"48px\" border=\"0\" style=\"vertical-align:middle;\"/>&nbsp;&nbsp;<span class=\"titulo\">" + this.txtTitulo.Text + "</span>&nbsp;&nbsp;<span class=\"subtitulo\">" + this.txtSubtitulo.Text + "</span>";

            //Preparo las capas según se tienen que mostrar
            this.divTitulos.Visible = false;
            this.divLogo.Visible = false;
            this.divDescripcion.Visible = true;
            this.LParcial.Visible = true;
            this.fila_blanco2.Visible = false;
            this.fila_error2.Visible = false;
        }
        else
        {
            this.fila_blanco2.Visible = true;
            this.fila_error2.Visible = true;
        }

        #endregion
    }

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        string descripcion = txtDescripcion.Text.Replace("'","\"");
        proyecto.actualizaProyecto(int.Parse(this.hidPID.Value.ToString()), this.txtTitulo.Text, this.txtSubtitulo.Text, 1, descripcion, string.Empty, 0);

        Response.Redirect("Default.aspx");
    }

    #endregion

    #region funciones

    //Función que guarda el logo asociado a un proyecto
    private void grabaFoto(string proyectoId)
    {
        procesarImg.crearDirectorio(Server.MapPath("../img/"));

        string ruta = Server.MapPath("../img/temp_logo" + proyectoId + ".png");
        //Guardamos el archivo temp fisicamente
        this.txtLogo.SaveAs(ruta);
        procesarImg.ResizeImagenHeightWidth(ruta, Server.MapPath("../img/logo" + proyectoId + ".png"), 250,250);
        File.Delete(ruta);     
    }

    #endregion
}