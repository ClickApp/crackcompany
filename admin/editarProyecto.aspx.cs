﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections;
using System.Data;

public partial class admin_editarProyecto : System.Web.UI.Page
{
    #region Variables

    Proyectos proyecto = new Proyectos();
    ProcesarImagenes procesarImg = new ProcesarImagenes();
    public String imagenes = string.Empty;
    
    #endregion

    #region Carga Página

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //Recuperamos los datos del proyecto que vamos a editar
            int proyectoId = int.Parse(Session["proyectoId"].ToString());

            DataSet ds = new DataSet();
            ds = proyecto.dameDatosProyecto(proyectoId);

            bool logo = false;

            if (ds.Tables["DATOS"].Rows.Count > 0)
            {
                this.txtTitulo.Text = ds.Tables["DATOS"].Rows[0]["TITULO"].ToString();
                this.txtTituloEng.Text = ds.Tables["DATOS"].Rows[0]["TITULO_ENG"].ToString();
                this.txtSubtitulo.Text = ds.Tables["DATOS"].Rows[0]["SUBTITULO"].ToString();
                this.txtSubtituloEng.Text = ds.Tables["DATOS"].Rows[0]["SUBTITULO_ENG"].ToString();
                this.hidPID.Value = ds.Tables["DATOS"].Rows[0]["PROYECTO_ID"].ToString();
                this.txtDescripcion.Text = ds.Tables["DATOS"].Rows[0]["DESCRIPCION"].ToString();
                this.txtDescripcionEng.Text = ds.Tables["DATOS"].Rows[0]["DESCRIPCION_ENG"].ToString();
                logo = bool.Parse(ds.Tables["DATOS"].Rows[0]["LOGO"].ToString());
            }

            string cuerpo = "<table>";
            cuerpo += "<tr><td><img src=\"../logos/logo_" + this.hidPID.Value.ToString() + ".png\" alt=\"" + this.txtTitulo.Text + "\" width=\"48px\" border=\"0\"/></td>";
            cuerpo += "<td valign=\"bottom\">&nbsp;&nbsp;<span class=\"titulo\">" + this.txtTitulo.Text + "</span>&nbsp;&nbsp;<span class=\"subtitulo\">" + this.txtSubtitulo.Text + "</span></td></tr>";
            cuerpo += "</table>";

            this.LParcial.Text = cuerpo;

            Session["fotosTemporal"] = null;

            //Cargamos las fotos que acompañan a la entrada
            List<String> fotos = GetImages(proyectoId);

            if (fotos.Count > 0)
            {
                //Aqui hay que crear un ArrayList e ir metiendo las fotos de este proyecto en Session
                ArrayList fotosTemporal = new ArrayList();

                for (int i = 0; i < fotos.Count; i++)
                {
                    string url = fotos[i].ToString();

                    if (!fotosTemporal.Contains(url))
                    {
                        fotosTemporal.Add(url);
                        Session["fotosTemporal"] = fotosTemporal;
                    }
                }
            }  

            //Cargamos el logo
            this.CargarLogo(logo, proyectoId);

            //Preparo las capas según se tienen que mostrar
            this.divLogo.Visible = false;
            this.divDescripcion.Visible = false;
            this.LParcial.Visible = false;
            this.fila_blanco1.Visible = false;
            this.fila_error1.Visible = false;
            this.fila_blanco2.Visible = false;
            this.fila_error2.Visible = false;
            this.filaErrorFoto.Visible = false;
            this.txtTitulo.Focus();            
        }

        //Recargamos la pagina de subida de fotos
        this.CargarFotos();
    }

    private void CargarFotos()
    {
        imagenes = string.Empty; //Limpiamos la variable imagenes

        ArrayList fotosTemporal = new ArrayList();

        //Recorro el ArrayList de fotos y voy creando la visualización
        if (Session["fotosTemporal"] != null)
            fotosTemporal = (ArrayList)Session["fotosTemporal"];

        if (fotosTemporal != null && fotosTemporal.Count > 0)
        {
            //Tenemos fotos guardadas            

            imagenes = imagenes + "<br/><table>";

            for (int i = 0; i < fotosTemporal.Count; i++)
            {
                imagenes = imagenes + "<tr>";
                imagenes = imagenes + "<td width=\"120px\"><img src=\"../fotos/" + this.hidPID.Value + "/" + fotosTemporal[i].ToString() + "\" alt=\"\" width=\"100px\" border=\"0\"/></td>";
                imagenes = imagenes + "<td>http://localhost/crackcompany/fotos/" + this.hidPID.Value + "/" + fotosTemporal[i].ToString() + "&nbsp;<img src=\"images/ico_delete.gif\" alt=\"Borrar Imagen\" border=\"0\" style=\"cursor:pointer;vertical-align:middle;\" onclick=\"javascript:BorrarFoto('" + fotosTemporal[i].ToString() + "');\"></td>";
                imagenes = imagenes + "</tr>";
            }

            imagenes = imagenes + "</table>";
        }
    }

    private void CargarLogo(bool logo,int proyectoId) {

        if (logo)
        {
            this.celdaSubirLogo.Visible = false;
            this.celdaLogo.Visible = true;
            this.fila_Explicacion.Visible = false;
            this.LitLogo.Text = "<img src=\"../logos/logo_" + proyectoId + ".png\" alt=\"\" border=\"0\" width=\"150px\"><br/><br/><img src=\"images/ico_delete.gif\" alt=\"Borrar Logo\" border=\"0\" style=\"cursor:pointer;vertical-align:middle;\" onclick=\"javascript:BorrarLogo('" + proyectoId + "');\">&nbsp;<a href=\"#\" onclick=\"javascript:BorrarLogo('" + proyectoId + "');\" class=\"links\">Borrar Logo</a>";
        }
        else
        {
            this.celdaSubirLogo.Visible = true;
            this.celdaLogo.Visible = false;
            this.fila_Explicacion.Visible = true;
        }
    }

    #endregion

    #region botones

    protected void btnSiguiente_Click(object sender, EventArgs e)
    {
        bool anadir = false;

        #region comprobaciones

        if (this.txtTitulo.Text != string.Empty && this.txtTituloEng.Text != string.Empty)
        {
            anadir = true;

            //Compruebo que no exista ya un proyecto con ese nombre
            if (proyecto.existeProyecto(this.txtTitulo.Text))
            {
                string proyectoId = proyecto.dameIdProyecto(this.txtTitulo.Text);

                if (proyectoId != this.hidPID.Value)
                {
                    anadir = false;
                    this.Lerror1.Text = "Uy! Ya existe un proyecto con ese título.";
                    this.txtTitulo.Focus();
                }
            }
        }
        else
        {
            anadir = false;

            if (this.txtTituloEng.Text == string.Empty)
            {
                this.Lerror1.Text = "Vaya! No has indicado el título en inglés del proyecto.";
                this.txtTituloEng.Focus();
            }

            if (this.txtTitulo.Text == string.Empty)
            {
                this.Lerror1.Text = "Vaya! No has indicado el título del proyecto.";
                this.txtTitulo.Focus();
            }
        }

        #endregion

        #region anadir

        if (anadir)
        {
            //Actualizo el proyecto porque todo ha ido bien
            string descripcion = txtDescripcion.Text.Replace("'", "\"");
            string descripcionEng = txtDescripcionEng.Text.Replace("'", "\"");

            proyecto.actualizaProyecto(int.Parse(this.hidPID.Value.ToString()),this.txtTitulo.Text, this.txtTituloEng.Text, this.txtSubtitulo.Text, this.txtSubtituloEng.Text, 1, descripcion, descripcionEng, 0);

            this.hidPID.Value = this.hidPID.Value;

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

        if (this.txtLogo.HasFile || this.celdaSubirLogo.Visible)
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
            if (this.celdaSubirLogo.Visible)
            {
                this.Lerror2.Text = "Vaya! No has seleccionado el logo.";
                anadir = false;
            }
            else
                anadir = true;
        }

        #endregion

        #region anadir

        if (anadir)
        {
            //Añado el logo del proyecto porque todo ha ido bien y actualizo los datos del proyecto
            if(this.celdaSubirLogo.Visible)
                this.grabaFoto(this.hidPID.Value.ToString());
            
            string descripcion = txtDescripcion.Text.Replace("'", "\"");
            string descripcionEng = txtDescripcionEng.Text.Replace("'", "\"");
            proyecto.actualizaProyecto(int.Parse(this.hidPID.Value.ToString()), this.txtTitulo.Text, this.txtTituloEng.Text, this.txtSubtitulo.Text, this.txtSubtituloEng.Text, 1, descripcion, descripcionEng, 0);

            this.hidPID.Value = this.hidPID.Value.ToString();

            string cuerpo = "<table>";
            cuerpo += "<tr><td><img src=\"../logos/logo_" + this.hidPID.Value.ToString() + ".png\" alt=\"" + this.txtTitulo.Text + "\" width=\"48px\" border=\"0\"/></td>";
            cuerpo += "<td valign=\"bottom\">&nbsp;&nbsp;<span class=\"titulo\">" + this.txtTitulo.Text + "</span>&nbsp;&nbsp;<span class=\"subtitulo\">" + this.txtSubtitulo.Text + "</span></td></tr>";
            cuerpo += "</table>";

            this.LParcial.Text = cuerpo;

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

    protected void btnAnadirFoto_Click(object sender, EventArgs e)
    {
        this.hidPID.Value = this.hidPID.Value;

        //Miramos si ha seleccionado la foto
        if (FileUpload1.HasFile)
        {
            string fileExt = Path.GetExtension(FileUpload1.FileName);

            bool correcto = this.procesarImg.validaImagen(fileExt);

            if (correcto)
            {
                //Se trata de una imagen 
                procesarImg.crearDirectorio(Server.MapPath("~/fotos/" + this.hidPID.Value));
                string ruta = Server.MapPath("~/fotos/" + this.hidPID.Value + "/foto_" + FileUpload1.FileName);

                try
                {
                    this.FileUpload1.SaveAs(ruta);

                    //Aqui hay que crear un ArrayList e ir metiendo las fotos de esta entrada en Session
                    ArrayList fotosTemporal = new ArrayList();

                    //Formamos la url correcta
                    string url = "foto_" + FileUpload1.FileName;
                    //string url = "http://www.crackcompany.com/fotos/foto_" + FileUpload1.FileName;

                    if (Session["fotosTemporal"] != null)
                        fotosTemporal = (ArrayList)Session["fotosTemporal"];

                    if (!fotosTemporal.Contains(url))
                    {
                        fotosTemporal.Add(url);
                        Session["fotosTemporal"] = fotosTemporal;
                    }

                    this.Lerrorfoto.Text = "ENHORABUENA! La imagen se ha subido correctamente.";
                    this.filaErrorFoto.Visible = false;

                }
                catch (Exception)
                {
                    //No se ha podido subir, mostrar mensaje de error
                    this.Lerrorfoto.Text = "Se ha producido un fallo en la subida de la imagen, si el error persiste p&oacute;ngase en contacto con el servicio t&eacute;cnico.";
                }
            }
            else
            {
                //No es una imagen, mensaje de error
                this.Lerrorfoto.Text = "Vaya! Parece que el archivo seleccionado no es una imagen.";
                this.filaErrorFoto.Visible = true;
            }
        }
        else
        {
            //No es una imagen, mensagito de error
            this.Lerrorfoto.Text = "Uy! Parece que te has olvidado de seleccionar una imagen.";
            this.filaErrorFoto.Visible = true;
        }

        this.CargarFotos();
    }

    protected void btnBorrarFoto_Click(object sender, EventArgs e)
    {
        string url = this.hidURL.Value;
        this.hidPID.Value = this.hidPID.Value;

        ArrayList fotosTemporal = new ArrayList();

        //Recorro el ArrayList de fotos y voy creando la visualización
        if (Session["fotosTemporal"] != null)
            fotosTemporal = (ArrayList)Session["fotosTemporal"];

        if (fotosTemporal != null && fotosTemporal.Count > 0)
        {
            if (fotosTemporal.Contains(url))
            {
                fotosTemporal.Remove(url);
            }
        }

        this.CargarFotos();
    }

    protected void btnBorrarLogo_Click(object sender, EventArgs e)
    {
        int proyectoId = int.Parse(this.hidLogo.Value.ToString());
        this.hidPID.Value = proyectoId.ToString();        

        this.CargarLogo(false,proyectoId);
    }

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        string descripcion = txtDescripcion.Text.Replace("'", "\"");
        string descripcionEng = txtDescripcionEng.Text.Replace("'", "\"");
        proyecto.actualizaProyecto(int.Parse(this.hidPID.Value.ToString()), this.txtTitulo.Text, this.txtTituloEng.Text, this.txtSubtitulo.Text, this.txtSubtituloEng.Text, 1, descripcion, descripcionEng, 0);

        Response.Redirect("Default.aspx");
    }

    #endregion

    #region funciones

    //Función que guarda el logo asociado a un proyecto
    private void grabaFoto(string proyectoId)
    {
        procesarImg.crearDirectorio(Server.MapPath("~/logos/"));

        string ruta = Server.MapPath("~/logos/temp_logo_" + proyectoId + ".png");
        //Guardamos el archivo temp fisicamente
        this.txtLogo.SaveAs(ruta);
        procesarImg.ResizeImagenHeightWidth(ruta, Server.MapPath("~/logos/logo_" + proyectoId + ".png"), 250, 250);
        //Aplicamos filtro a gris
        procesarImg.convertirGris(Server.MapPath("~/logos/logo_" + proyectoId + ".png"), Server.MapPath("~/logos/logo_gris_" + proyectoId + ".png"));
        File.Delete(ruta);
    }

    //Función que obtiene los ficheros de una determinada carpeta
    private List<String> GetImages(int proyectoId)
    {
        List<String> slides = new List<String>();
        string ruta = Server.MapPath("~/fotos/" + proyectoId);

        if (Directory.Exists(ruta))
        {
            string[] files = Directory.GetFiles(ruta);
            foreach (string file in files)
            {
                string url = file;

                //Cogemos lo que interesa
                string[] strArr = null;
                char[] splitchar = { '\\' };
                strArr = url.Split(splitchar);

                url = strArr[strArr.Length - 1];

                slides.Add(url);
            }
        }
        return slides;
    }

    #endregion
}