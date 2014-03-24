using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Default : System.Web.UI.Page
{
    #region Carga Página

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #endregion

    #region botones

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        Response.Redirect("nuevoProyecto.aspx");
    }

    #endregion
}