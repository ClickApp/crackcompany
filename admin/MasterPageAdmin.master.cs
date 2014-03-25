using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_MasterPageAdmin : System.Web.UI.MasterPage
{
    #region Variables

    public string nombre = string.Empty;    

    #endregion

    #region Carga Página

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AID"] != null)
        {
            nombre = Session["nomAdmin"].ToString() + " " + Session["apeAdmin"].ToString();
        }
        else
        {
            Response.Redirect("cerrarSession.aspx");
        }
    }

    #endregion
}
