using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

using JurosaConnection;

/// <summary>
/// Clase que maneja el historico del sistema
/// </summary>
/// 
public class Historico
{
    #region atributos

    Connection con = new Connection();
    string valdev = string.Empty;
    DataSet ds = new DataSet();

    #endregion

    public Historico()
	{
		
	}

    ////Función que añade un nuevo emailo a las newsletter de nuestra BD
    //public void AnadirNewsletter(string email, string nombre, int tipo)
    //{
    //    string newsletterId = con.execValor("SELECT NEWSLETTER_ID FROM NEWSLETTER WHERE EMAIL='" + email + "'");

    //    if(newsletterId == "-10000")
    //        con.execVoid("spr_AnadirNewsletter '" + email + "','" + nombre + "'," + tipo + "");
    //}    

    ////Función que me devuelve el listado de contactos de la newsletter
    //public DataTable dameListadoNewsletter(string nombre, string email, int origen)
    //{
    //    DataTable dt = new DataTable();

    //    string strSQL = "SELECT N.NEWSLETTER_ID,ISNULL(N.NOMBRE,'') AS NOMBRE, ISNULL(N.ORIGEN,0) AS ORIGEN,N.EMAIL FROM NEWSLETTER N WHERE 1=1";        

    //    if (nombre != string.Empty)
    //    {
    //        strSQL = strSQL + " AND N.NOMBRE LIKE '%" + nombre + "%'";
    //    }

    //    if (email != string.Empty)
    //    {
    //        strSQL = strSQL + " AND N.EMAIL LIKE '%" + email + "%'";
    //    }

    //    if (origen != 0)
    //    {
    //        strSQL = strSQL + " AND N.ORIGEN=" + origen + "";
    //    }

    //    strSQL = strSQL + " ORDER BY N.NEWSLETTER_ID DESC";

    //    dt = con.execArrayDT(strSQL);

    //    return dt;
    //}

    ////Función que me devuelve la newsletter para su impresión
    //public String dameListadoNewsletter(int opcion)
    //{
    //    valdev = string.Empty;
    //    Utilidades objUtils = new Utilidades();

    //    DataSet ds = new DataSet();
    //    string strSQL = "SELECT ISNULL(NOMBRE,'') AS NOMBRE, EMAIL, ISNULL(ORIGEN,0) AS ORIGEN FROM NEWSLETTER ORDER BY NEWSLETTER_ID ASC";
    //    ds = con.execArray(strSQL);

    //    if (ds.Tables["DATOS"].Rows.Count > 0)
    //    {
    //        for (int i = 0; i < ds.Tables["DATOS"].Rows.Count; i++)
    //        {
    //            switch (opcion)
    //            {
    //                case 0: //Quiere nombre, email y origen
    //                    if ((i % 2) == 0)
    //                        valdev += "<tr style=\"height:25px;background-color:#8EAFC1;color:#FFFFFF;outline:none;\"><td>&nbsp;" + ds.Tables["DATOS"].Rows[i]["NOMBRE"].ToString() + "&nbsp;</td><td>&nbsp;" + ds.Tables["DATOS"].Rows[i]["EMAIL"].ToString() + "</td><td>&nbsp;" + objUtils.traduceOrigenNewsletter(int.Parse(ds.Tables["DATOS"].Rows[i]["ORIGEN"].ToString())) + "&nbsp;</td></tr>";
    //                    else
    //                        valdev += "<tr style=\"height:25px;color:#8EAFC1;outline:none;\"><td>&nbsp;" + ds.Tables["DATOS"].Rows[i]["NOMBRE"].ToString() + "&nbsp;</td><td>&nbsp;" + ds.Tables["DATOS"].Rows[i]["EMAIL"].ToString() + "&nbsp;</td><td>&nbsp;" + objUtils.traduceOrigenNewsletter(int.Parse(ds.Tables["DATOS"].Rows[i]["ORIGEN"].ToString())) + "&nbsp;</td></tr>"; 

    //                    break;                    
    //                case 1: //Quiere nombre e email
    //                    if ((i % 2) == 0)
    //                        valdev += "<tr style=\"height:25px;background-color:#8EAFC1;color:#FFFFFF;outline:none;\"><td>&nbsp;" + ds.Tables["DATOS"].Rows[i]["NOMBRE"].ToString() + "&nbsp;</td><td>&nbsp;" + ds.Tables["DATOS"].Rows[i]["EMAIL"].ToString() + "&nbsp;</td></tr>"; 
    //                    else
    //                        valdev += "<tr style=\"height:25px;color:#8EAFC1;outline:none;\"><td>&nbsp;" + ds.Tables["DATOS"].Rows[i]["NOMBRE"].ToString() + "&nbsp;</td><td>&nbsp;" + ds.Tables["DATOS"].Rows[i]["EMAIL"].ToString() + "&nbsp;</td></tr>"; 
    //                    break;
    //                case 2: //Quiere nombre y origen
    //                    if ((i % 2) == 0)
    //                        valdev += "<tr style=\"height:25px;background-color:#8EAFC1;color:#FFFFFF;outline:none;\"><td>&nbsp;" + ds.Tables["DATOS"].Rows[i]["NOMBRE"].ToString() + "&nbsp;</td><td>&nbsp;" + objUtils.traduceOrigenNewsletter(int.Parse(ds.Tables["DATOS"].Rows[i]["ORIGEN"].ToString())) + "&nbsp;</td></tr>";
    //                    else
    //                        valdev += "<tr style=\"height:25px;color:#8EAFC1;outline:none;\"><td>&nbsp;" + ds.Tables["DATOS"].Rows[i]["NOMBRE"].ToString() + "&nbsp;</td><td>&nbsp;" + objUtils.traduceOrigenNewsletter(int.Parse(ds.Tables["DATOS"].Rows[i]["ORIGEN"].ToString())) + "&nbsp;</td></tr>";
    //                    break;
    //                case 3: //Quiere email y origen
    //                    if ((i % 2) == 0)
    //                        valdev += "<tr style=\"height:25px;background-color:#8EAFC1;color:#FFFFFF;outline:none;\"><td>&nbsp;" + ds.Tables["DATOS"].Rows[i]["EMAIL"].ToString() + "&nbsp;</td><td>&nbsp;" + objUtils.traduceOrigenNewsletter(int.Parse(ds.Tables["DATOS"].Rows[i]["ORIGEN"].ToString())) + "&nbsp;</td></tr>";
    //                    else
    //                        valdev += "<tr style=\"height:25px;color:#8EAFC1;outline:none;\"><td>&nbsp;" + ds.Tables["DATOS"].Rows[i]["EMAIL"].ToString() + "&nbsp;</td><td>&nbsp;" + objUtils.traduceOrigenNewsletter(int.Parse(ds.Tables["DATOS"].Rows[i]["ORIGEN"].ToString())) + "&nbsp;</td></tr>";
    //                    break;
    //                case 4: //Quiere nombre
    //                    if ((i % 2) == 0)
    //                        valdev += "<tr style=\"height:25px;background-color:#8EAFC1;color:#FFFFFF;outline:none;\"><td>&nbsp;" + ds.Tables["DATOS"].Rows[i]["NOMBRE"].ToString() + "&nbsp;</td></tr>"; 
    //                    else
    //                        valdev += "<tr style=\"height:25px;color:#8EAFC1;outline:none;\"><td>&nbsp;" + ds.Tables["DATOS"].Rows[i]["NOMBRE"].ToString() + "&nbsp;</td></tr>"; 
    //                    break;
    //                case 5: //Quiere email
    //                    if ((i % 2) == 0)
    //                        valdev += "<tr style=\"height:25px;background-color:#8EAFC1;color:#FFFFFF;outline:none;\"><td>&nbsp;" + ds.Tables["DATOS"].Rows[i]["EMAIL"].ToString() + "&nbsp;</td></tr>"; 
    //                    else
    //                        valdev += "<tr style=\"height:25px;color:#8EAFC1;outline:none;\"><td>&nbsp;" + ds.Tables["DATOS"].Rows[i]["EMAIL"].ToString() + "&nbsp;</td></tr>"; 
    //                    break;
    //                case 6: //Quiere origen
    //                    if ((i % 2) == 0)
    //                        valdev += "<tr style=\"height:25px;background-color:#8EAFC1;color:#FFFFFF;outline:none;\"><td>&nbsp;" + objUtils.traduceOrigenNewsletter(int.Parse(ds.Tables["DATOS"].Rows[i]["ORIGEN"].ToString())) + "&nbsp;</td></tr>";
    //                    else
    //                        valdev += "<tr style=\"height:25px;color:#8EAFC1;outline:none;\"><td>&nbsp;" + objUtils.traduceOrigenNewsletter(int.Parse(ds.Tables["DATOS"].Rows[i]["ORIGEN"].ToString())) + "&nbsp;</td></tr>";
    //                    break;
    //            }
    //        }
    //    }

    //    return valdev;        
    //}

    ////Función que me devuelve el id de un contacto de la newsletter pasado su email 
    //public String dameIdNewsletter(string email)
    //{
    //    string valdev = string.Empty;
    //    valdev = con.execValor("SELECT NEWSLETTER_ID FROM NEWSLETTER WHERE EMAIL='" + email + "'");
    //    return valdev;
    //}

    ////Función que modifica una categoria de la base de datos
    //public void modificarNewsletter(int newsletterId, string email, string nombre, int origen)
    //{
    //    con.execVoid("UPDATE NEWSLETTER SET NOMBRE='" + nombre + "', EMAIL='" + email + "', ORIGEN=" + origen + " WHERE NEWSLETTER_ID=" + newsletterId);        
    //}

    ////Función que elimina un contacto de la nwsletter
    //public void eliminaNewsletter(int newsletterId)
    //{
    //    con.execVoid("DELETE FROM NEWSLETTER WHERE NEWSLETTER_ID=" + newsletterId);    
    //}

    //Función que añade fichero a borrar en la tabla temporal que se encarga de esto

    public void anadirFicheroBorrar(int id)
    {
        SqlCommand cmd = new SqlCommand();
        SqlParameter sqlPar = null;
        sqlPar = cmd.Parameters.Add("@ID", SqlDbType.Int);
        sqlPar.Value = id;

        con.execProcedureVoid(cmd, "spr_AnadirFicheroBorrar");        
    }
   
    public void eliminaFicheroBorrar(int id)
    {
        SqlCommand cmd = new SqlCommand();
        SqlParameter sqlPar = null;
        sqlPar = cmd.Parameters.Add("@ID", SqlDbType.Int);
        sqlPar.Value = id;

        con.execProcedureVoid(cmd, "spr_EliminarFicheroBorrar");
    }

    //Función que me devuelve los ficheros a borrar
    public DataSet dameFicherosABorrar() 
    {
        DataSet ds = new DataSet();
        SqlCommand cmd = new SqlCommand();
        ds = con.execProcedureArrayDS(cmd, "spr_DameFicherosBorrar");
        return ds;
    }

}