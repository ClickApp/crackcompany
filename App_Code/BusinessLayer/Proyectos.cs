using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

using JurosaConnection;

/// <summary>
/// Clase que maneja los proyectos
/// </summary>
public class Proyectos
{
    #region Atributos

    Connection con = new Connection();

    #endregion

    public Proyectos()
	{
		
	}

    //Función que me devuelve los proyectos con el nombre dado
    public DataSet dameProyectos(string titulo, int activo)
    {
        DataSet ds = new DataSet();
        SqlCommand cmd = new SqlCommand();
        SqlParameter sqlPar = null;
        sqlPar = cmd.Parameters.Add("@TITULO", SqlDbType.VarChar, 200);
        sqlPar.Value = titulo;       

        if(titulo == string.Empty)
            ds = con.execProcedureArrayDS(cmd,"spr_DameProyectos");
        else
            ds = con.execProcedureArrayDS(cmd,"spr_DameProyectosLike");
        
        return ds;
    }

    //Función que añade un proyecto nuevo
    public String anadirProyecto(string titulo, string tituloEng, string subtitulo, string subtituloEng, int logo, string descripcion, string descripcionEng, int activo) 
    {
        string valdev = string.Empty;

        SqlCommand cmd = new SqlCommand();
        SqlParameter sqlPar = null;
        sqlPar = cmd.Parameters.Add("@TITULO", SqlDbType.VarChar, 200);
        sqlPar.Value = titulo;
        sqlPar = cmd.Parameters.Add("@TITULO_ENG", SqlDbType.VarChar, 200);
        sqlPar.Value = tituloEng;
        sqlPar = cmd.Parameters.Add("@SUBTITULO", SqlDbType.VarChar, 150);
        sqlPar.Value = subtitulo;
        sqlPar = cmd.Parameters.Add("@SUBTITULO_ENG", SqlDbType.VarChar, 150);
        sqlPar.Value = subtituloEng;
        sqlPar = cmd.Parameters.Add("@LOGO", SqlDbType.Bit);
        sqlPar.Value = logo;
        sqlPar = cmd.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar);
        sqlPar.Value = descripcion;
        sqlPar = cmd.Parameters.Add("@DESCRIPCION_ENG", SqlDbType.VarChar);
        sqlPar.Value = descripcionEng;
        sqlPar = cmd.Parameters.Add("@ACTIVO", SqlDbType.Bit);
        sqlPar.Value = activo;        

        valdev = con.execProcedureValor(cmd, "spr_AnadirProyecto");

        return valdev;
    }

    //Función que actualiza un proyecto
    public void actualizaProyecto(int proyectoId, string titulo, string tituloEng, string subtitulo, string subtituloEng, int logo, string descripcion, string descripcionEng, int activo) 
    {
        SqlCommand cmd = new SqlCommand();
        SqlParameter sqlPar = null;
        sqlPar = cmd.Parameters.Add("@PROYECTO_ID", SqlDbType.Int);
        sqlPar.Value = proyectoId;        
        sqlPar = cmd.Parameters.Add("@TITULO", SqlDbType.VarChar, 200);
        sqlPar.Value = titulo;
        sqlPar = cmd.Parameters.Add("@TITULO_ENG", SqlDbType.VarChar, 200);
        sqlPar.Value = tituloEng;
        sqlPar = cmd.Parameters.Add("@SUBTITULO", SqlDbType.VarChar, 150);
        sqlPar.Value = subtitulo;
        sqlPar = cmd.Parameters.Add("@SUBTITULO_ENG", SqlDbType.VarChar, 150);
        sqlPar.Value = subtituloEng;
        sqlPar = cmd.Parameters.Add("@LOGO", SqlDbType.Bit);
        sqlPar.Value = logo;
        sqlPar = cmd.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar);
        sqlPar.Value = descripcion;
        sqlPar = cmd.Parameters.Add("@DESCRIPCION_ENG", SqlDbType.VarChar);
        sqlPar.Value = descripcionEng;
        sqlPar = cmd.Parameters.Add("@ACTIVO", SqlDbType.Bit);
        sqlPar.Value = activo;

        con.execProcedureVoid(cmd, "spr_ActualizaProyecto"); 
    }

    //Función que me devuelve los datos de un proyecto pasado su id
    public DataSet dameDatosProyecto(int proyectoId)
    {
        DataSet ds = new DataSet();
        SqlCommand cmd = new SqlCommand();
        SqlParameter sqlPar = null;
        sqlPar = cmd.Parameters.Add("@PROYECTO_ID", SqlDbType.Int);
        sqlPar.Value = proyectoId;        

        ds = con.execProcedureArrayDS(cmd,"spr_DameDatosProyecto");

        return ds;        
    }

    //Función que me devuelve si existe un proyecto pasado su titulo
    public Boolean existeProyecto(string titulo)
    {
        bool existe = false;

        SqlCommand cmd = new SqlCommand();
        SqlParameter sqlPar = null;
        sqlPar = cmd.Parameters.Add("@TITULO", SqlDbType.VarChar, 200);
        sqlPar.Value = titulo;        

        string proyectoId = con.execProcedureValor(cmd,"spr_ExisteProyecto");

        if (proyectoId != "-10000")
            existe = true;

        return existe;
    }

    //Función que activa o desactiva un proyecto
    public void activarProyecto(int proyectoId, bool activa)
    {
        int activo = 0; //Por defecto lo desactivamos
        
        if (!activa) //Si esta inactivo, lo activamos
            activo = 1;

        SqlCommand cmd = new SqlCommand();
        SqlParameter sqlPar = null;
        sqlPar = cmd.Parameters.Add("@PROYECTO_ID", SqlDbType.Int);
        sqlPar.Value = proyectoId;
        sqlPar = cmd.Parameters.Add("@ACTIVO", SqlDbType.Bit);
        sqlPar.Value = activo;

        con.execProcedureVoid(cmd, "spr_ActivarProyecto");        
    }

    //Función que elimina un proyecto de la base de datos
    public void eliminarProyecto(int proyectoId)
    {        
        SqlCommand cmd = new SqlCommand();
        SqlParameter sqlPar = null;
        sqlPar = cmd.Parameters.Add("@PROYECTO_ID", SqlDbType.Int);
        sqlPar.Value = proyectoId;
            
        con.execProcedureVoid(cmd, "spr_EliminarProyecto");

        //Añadimos los ficheros del curso a la tabla temporal de ficheros a eliminar
        Historico his = new Historico();
        his.anadirFicheroBorrar(proyectoId);       
    }
}