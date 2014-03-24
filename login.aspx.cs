using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Web.Security;
using System.Security.Cryptography;
using System.Web.Configuration;

using JurosaConnection;

public partial class login : System.Web.UI.Page
{
    #region variables

    Connection con = new Connection();
    string seccion = string.Empty;

    #endregion

    #region Carga Página

    protected void Page_Load(object sender, EventArgs e)
    {
        seccion = "admin";
        this.uname.Focus();
    }

    #endregion

    #region botones

    protected void btnEntrar_Click(object sender, EventArgs e)
    {
        int IntentosPWD = 0;
        bool autentificado = false;

        string dato = verificarPassword(uname.Text, upass.Text, seccion);

        switch (dato)
        {
            case "correcto":
                autentificado = true;
                break;
            case "Password_Incorrecto":
                LblMensaje.Text = "Contraseña Incorrecta";
                if (Session["FallosPWD"] == null)
                    Session["FallosPWD"] = 1;

                else
                {
                    IntentosPWD = (int)Session["FallosPWD"] + 1;
                    Session["FallosPWD"] = IntentosPWD;
                }
                if (IntentosPWD > 3)
                {
                    //HLKRecuperar.Text = "¿Olvidó su contraseña?";
                    //HLKRecuperar.NavigateUrl = "recuperarPWD.aspx";
                    //HLKRecuperar.Visible = true;
                }
                break;
            default:
                break;
        }

        if (autentificado)
        {
            //Metemos en Session los datos de la persona logada

            SqlCommand cmd = new SqlCommand();

            SqlParameter sqlPar = null;
            sqlPar = cmd.Parameters.Add("@UNAME", SqlDbType.VarChar, 12);
            sqlPar.Value = uname.Text;

            SqlDataReader dtr = con.execProcedureArray(cmd, "spr_DameDatosAdministrador");

            if (dtr.HasRows)
            {
                dtr.Read();
                Session["AID"] = dtr.GetInt32(0).ToString();
                Session["nomAdmin"] = dtr.GetString(1);
                Session["apeAdmin"] = dtr.GetString(2);
                Session["emailAdmin"] = dtr.GetString(3);

                dtr.Close();
                con.CloseSQL();

                string nombre = Session["nomAdmin"].ToString() + " " + Session["apeAdmin"].ToString();
            }

            FormsAuthenticationTicket AuthVale = new FormsAuthenticationTicket(1, uname.Text, DateTime.Now, DateTime.Now.AddMinutes(60), false, seccion);
            string EncryVale = FormsAuthentication.Encrypt(AuthVale);
            HttpCookie AuthCookie = new HttpCookie(FormsAuthentication.FormsCookieName, EncryVale);
            Response.Cookies.Add(AuthCookie);

            FormsAuthentication.RedirectFromLoginPage(uname.Text, false);
        }
    }

    #endregion

    #region funciones

    private string verificarPassword(string usr, string pwd, string strSeccion)
    {
        bool correcto = false;

        SqlCommand cmd = new SqlCommand();

        SqlParameter sqlPar = null;
        sqlPar = cmd.Parameters.Add("@UNAME", SqlDbType.VarChar, 12);
        sqlPar.Value = usr;
        try
        {
            SqlDataReader dtr = con.execProcedureArray(cmd, "spr_BuscaAdministrador");
            if (dtr.HasRows)
            {
                dtr.Read();
                string dbPass = dtr.GetString(0);
                string salt = dtr.GetString(1);
                dtr.Close();
                con.CloseSQL();
                string pwd_salt = string.Concat(pwd, salt);
                string hashedPwdSalt = FormsAuthentication.HashPasswordForStoringInConfigFile(pwd_salt, "SHA1");
                correcto = hashedPwdSalt.Equals(dbPass);

                if (!correcto)
                    return "Password_Incorrecto";
            }
            else
                return "Password_Incorrecto";

        }
        catch (Exception ex) { LblMensaje.Text = ex.Message; }
        return "correcto";
    }

    #endregion
}