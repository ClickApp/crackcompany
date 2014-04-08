<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Crack Company - Actividad Creativa</title>
    <link href="~/styles/estilo.css" rel="stylesheet" type="text/css" />
    <link rel="shortcut icon" type="image/x-icon" href="images/favicon.ico" />
    <style type="text/css">
        body
        {	
	        background-color:#F3F3F3; 	
        }    
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="div_cabecera">
            <div class="div_centrado">
                <div id="divMenuIzqda"></div>
                    <img src="images/CrackCompany.png" alt="Crack Company" title="Crack Company" border="0" />
                <div id="divMenuDcha"></div>            
            </div>
        </div>
        <div class="div_centrado">
            <br /><br />
            <table width="475px" cellspacing="0" cellpadding="0" align="center">
                <tr>
                    <td valign="middle" align="center">
                        Bienvenid@ al &Aacute;rea de Administraci&oacute;n de Crack Company, <br />por favor identif&iacute;quese antes de entrar.                                               
                    </td>
                </tr>
                <tr><td>&nbsp;</td></tr>
                <tr><td>&nbsp;</td></tr>
                <tr><td>&nbsp;</td></tr>
                <tr align="center">
                    <td>
                        Nombre de Usuario <span class="texto_rojo">(*)</span><br/><asp:TextBox runat="server" ID="uname" name="uname" class="formulario" size="25"></asp:TextBox><br/><br />
                        Contrase&ntilde;a <span class="texto_rojo">(*)</span><br/><asp:TextBox runat="server" ID="upass" name="upass" class="formulario" TextMode="Password" size="27"></asp:TextBox>
                    </td>
                </tr>
                <tr><td>&nbsp;</td></tr>
                <tr id="fila_error" runat="server"><td colspan="2" align="center" class="texto_rojo"><asp:Literal runat="server" ID="error"></asp:Literal></td></tr>
                <tr><td>&nbsp;</td></tr>
                <tr><td align="center">Los campos marcados con <span class="texto_rojo">(*)</span> son obligatorios.</td></tr>
                <tr><td>&nbsp;</td></tr>
                <tr><td>&nbsp;</td></tr>
                <tr>
                    <td align="center">
                        <asp:Button runat="server" ID="btnEntrar" Text="Entrar" class="boton" OnClick="btnEntrar_Click" />                           
                    </td>
                </tr>
                <tr><td>&nbsp;</td></tr>
                <tr>
                    <td align="center">
                        <asp:Label ID="LblMensaje" runat="server" CssClass="texto_rojo" />                                
                    </td>
                </tr>
            </table>
        </div>
        <div id="div_pie">
            Original idea. Copyright &copy; <b>All Rights Reserved</b>
        </div>
    </form>
</body>
</html>
