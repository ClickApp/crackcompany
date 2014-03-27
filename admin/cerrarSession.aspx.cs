using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
using System.IO;

public partial class admin_cerrarSession : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();
        FormsAuthentication.SignOut();

        //Eliminamos los ficheros fisicos que esten pendientes de borrar en la tabla temporal FICHEROS_A_BORRAR
        Historico his = new Historico();
        DataSet ds = new DataSet();

        ds = his.dameFicherosABorrar();

        if (ds.Tables["DATOS"].Rows.Count > 0)
        {
            //Hay ficheros a borrar
            for (int i = 0; i < ds.Tables["DATOS"].Rows.Count; i++)
            {
                int id = int.Parse(ds.Tables["DATOS"].Rows[i]["ID"].ToString());

                string ruta = Server.MapPath("~/logos/logo_" + id + ".png");
                if (File.Exists(ruta))
                    File.Delete(ruta);
                ruta = Server.MapPath("~/logos/logo_gris_" + id + ".png");
                if (File.Exists(ruta))
                    File.Delete(ruta);
                ruta = Server.MapPath("~/fotos/"+ id +"/");
                if (Directory.Exists(ruta))
                    Directory.Delete(ruta, true);

                his.eliminaFicheroBorrar(id);                
            }
        }

        Response.Redirect("Default.aspx");
    }
}