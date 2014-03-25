using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

/// <summary>
/// Funciones comunes a toda la aplicación
/// </summary>
public class Utilidades
{
	public Utilidades()
	{
		
	}
   
    #region Manejo de Datos

    //Función que carga los datos en un repeater
    public void cargarDatos(DataSet ds, Repeater datos)
    {
        //Cargamos los datos en el repeater
        datos.DataSource = ds;
        datos.DataBind();
    }

    public void cargarDatosDT(DataTable dt, Repeater datos)
    {
        //Cargamos los datos en el repeater
        datos.DataSource = dt;
        datos.DataBind();
    }

    #endregion
}