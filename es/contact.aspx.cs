using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;

public partial class es_contact : System.Web.UI.Page
{
    #region Cargar Página

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.filaError.Visible = false;
            this.filaAcierto.Visible = false;
            this.txtNombre.Focus();
            this.btnEnviar.Enabled = true;
        }
    }

    #endregion

    #region botones

    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        bool enviar = false;
        Utilidades objUtils = new Utilidades();
        Historico his = new Historico();

        #region comprobaciones

        //Comprobamos los campos obligatorios
        if (this.txtEmail.Text != string.Empty && this.txtMensaje.Text != string.Empty)
        {
            enviar = true;
            Lacierto.Text = "Tu mensaje se ha enviado con &eacute;xito. <br/>Recibir&aacute;s noticias nuestras a la mayor brevedad posible";

            //Todo los campos obligatorios son correctos, miramos si el email es una email correcto

            #region resto comprobaciones

            if (this.txtEmail.Text != string.Empty)
            {
                if (!objUtils.ValidaEmail(txtEmail.Text))
                {
                    enviar = false;
                    //El email no es correcto, mostramos el mensaje de error 
                    Lerror.Text = "Vaya! El email que nos facilitas no es un email válido. <br/>(Ej: correo@midominio.com)";
                    this.txtEmail.Focus();
                }
            }

            #endregion
        }
        else
        {
            //Alguno de los campos obligatorios no ha sido rellenado comprobamos cual y mostramos el error
            if (this.txtMensaje.Text == string.Empty)
            {
                Lerror.Text = "Uy! Parece que se te ha olvidado decirnos tu mensaje.";
                this.txtMensaje.Focus();
            }
           
            if (this.txtEmail.Text == string.Empty)
            {
                Lerror.Text = "Vaya! Has olvidado poner un email de contacto.<br/>Lo necesitamos para poder contestarte.";
                this.txtEmail.Focus(); ;
            }           
        }

        #endregion

        #region envio

        if (enviar)
        {
            try
            {
                this.EnviarCorreo(this.txtNombre.Text,this.txtAsunto.Text,this.txtEmail.Text,this.txtMensaje.Text);

                //Vemos si quiere recibir la newsletter
                if (chkNewsletter.Checked)
                    his.anadirNewsletter(this.txtNombre.Text, this.txtEmail.Text);

                this.filaError.Visible = false;
                this.filaAcierto.Visible = true;
                this.btnEnviar.Enabled = false;
            }
            catch (Exception)
            {
                Lerror.Text = "Vaya! Se ha producido un error durante el envío. Por favor int&eacute;ntalo m&aacute;s tarde.";
                this.filaError.Visible = true;
                this.filaAcierto.Visible = false;
            }            
        }
        else
        {
            this.filaError.Visible = true;
            this.filaAcierto.Visible = false;
        }

        #endregion
    }

    #endregion

    #region funciones

    public void EnviarCorreo(string nombre, string asunto, string email, string mensaje)
    {
        string cuerpo = string.Empty;

        if (nombre == string.Empty)
            nombre = "Desconocido";

        if (asunto == string.Empty)
            asunto = "Sin asunto";

        cuerpo = "<html><body>";
        cuerpo = cuerpo + "<br/><b><u>Mensaje recibido desde Crack Company</u></b><br/><br/><br/>";
        cuerpo = cuerpo + "<b>Nombre:</b> " + nombre + "<br/><br/>";
        cuerpo = cuerpo + "<b>Email:</b> " + email + "<br/><br/>";
        cuerpo = cuerpo + "<b>Asunto:</b> " + asunto + "<br/><br/>";
        cuerpo = cuerpo + "<b>Comentario:</b> <i>" + mensaje + "</i><br/>";
        cuerpo = cuerpo + "</body></html>";

        Correo c = new Correo();
        c.Asunto = asunto;
        c.Cuerpo = cuerpo;

        try
        {
            c.Destinatarios.Add("Jurosa24@gmail.com");
            c.Origen = "no-reply@crackcompany.com";
            c.usuario = "no-reply@crackcompany.com";
            c.password = "crackcompanyMaquina14#";
            c.Envio(c);            
        }
        catch (SmtpException){ }
    }

    #endregion
}