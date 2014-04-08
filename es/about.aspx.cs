using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class es_about : System.Web.UI.Page
{
    #region Cargar Página

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //Establecemos la sección
            ((es_MasterPageES)this.Master).seccion = "about";

            //Formamos la url amigable
            ClientScript.RegisterStartupScript(this.GetType(), "myScript", "cargarURL();", true);            
        }
    }

    #endregion
}