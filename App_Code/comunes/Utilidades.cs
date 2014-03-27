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

    #region traducciones

    public String traduceActivoDesactivo(bool activo)
    {
        string valdev = string.Empty;

        if (!activo)
            valdev = "Activar";
        else if (activo)
            valdev = "Desactivar";
        return valdev;
    }

    //Funcion que muestra el icono de activo o inactivo en función de los parametros que se le pasan
    public String muestraIconos(bool activo)
    {
        string valdev = string.Empty;

        if (!activo)
            valdev = "images/ico_desactivo.gif";
        else if (activo)
            valdev = "images/ico_activo.gif";
        return valdev;
    }

    #endregion

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