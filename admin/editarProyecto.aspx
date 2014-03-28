<%@ Page Title="Crack Company - Administraci&oacute;n" Language="C#" MasterPageFile="~/admin/MasterPageAdmin.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="editarProyecto.aspx.cs" Inherits="admin_editarProyecto" %>

<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script type="text/javascript">

    function BorrarFoto(url) {

        var objUrl = document.getElementById('<%=hidURL.ClientID%>');
        objUrl.value = url;

        var boton = document.getElementById('<%=btnBorrarFoto.ClientID%>');
        boton.click();
    }

    function BorrarLogo(pid) {

        var objLogo = document.getElementById('<%=hidLogo.ClientID%>');
        objLogo.value = pid;

        var boton = document.getElementById('<%=btnBorrarLogo.ClientID%>');
        boton.click();
    }    

</script>

<form id="form1" runat="server">

<div class="divContenidoGestor">

<h1 align="center">Nuevo Proyecto</h1>
    
    <asp:Literal ID="LParcial" runat="server"></asp:Literal>
    
    <div id="divTitulos" runat="server">
        <table align="center" width="550px">
            <tr><td colspan="3">&nbsp;</td></tr>
            <tr>
                <td><b>T&iacute;tulo Castellano</b>&nbsp;<span class="texto_rojo">(*)</span></td>
                <td rowspan="7" width="5px">&nbsp;</td>
                <td><asp:TextBox ID="txtTitulo" runat="server" CssClass="formulario" Width="350px" TabIndex="1"></asp:TextBox></td>               
            </tr>
            <tr><td colspan="3">&nbsp;</td></tr>
            <tr>
                <td><b>T&iacute;tulo Ingl&eacute;s</b>&nbsp;<span class="texto_rojo">(*)</span></td>
                <td><asp:TextBox ID="txtTituloEng" runat="server" CssClass="formulario" Width="350px" TabIndex="2"></asp:TextBox></td>               
            </tr>
            <tr><td colspan="3">&nbsp;</td></tr>
            <tr>
                <td><b>Subt&iacute;tulo Castellano</b></td>
                <td><asp:TextBox ID="txtSubtitulo" runat="server" CssClass="formulario" Width="350px" TabIndex="3"></asp:TextBox></td>
            </tr>
            <tr><td colspan="3">&nbsp;</td></tr>
            <tr>
                <td><b>Subt&iacute;tulo Ingl&eacute;s</b></td>
                <td><asp:TextBox ID="txtSubtituloEng" runat="server" CssClass="formulario" Width="350px" TabIndex="4"></asp:TextBox></td>
            </tr>
            <tr id="fila_blanco1" runat="server"><td colspan="3">&nbsp;</td></tr>
            <tr id="fila_error1" runat="server">
                <td colspan="3" class="fila_error">
                    <asp:Literal ID="Lerror1" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr><td colspan="3">&nbsp;</td></tr>
            <tr>
                <td colspan="3" align="center"><asp:Button ID="btnSiguiente" runat="server" CssClass="boton" Text="Aceptar" OnClick="btnSiguiente_Click"/></td>
            </tr>
        </table>  
    </div>

    <div id="divLogo" runat="server">
        <table align="center" width="500px">
            <tr>
                <td><b>Logo</b>&nbsp;<span class="texto_rojo">(*)</span></td>
                <td width="5px">&nbsp;</td>
                <td id="celdaSubirLogo" runat="server"><asp:FileUpload ID="txtLogo" runat="server" CssClass="formulario" Width="350px"/></td>    
                <td id="celdaLogo" runat="server"><asp:Literal ID="LitLogo" runat="server"></asp:Literal></td>            
            </tr>
            <tr><td colspan="3">&nbsp;</td></tr>
            <tr id="fila_Explicacion" runat="server"><td colspan="3">El logo se redimensiona a un tama&ntilde;o de 250x250px. Se recomienda subir im&aacute;genes centradas y encuadradas en un lienzo de estas dimensiones, que conserve un margen razonable, para que no se distorsionen. </td></tr>
            <tr id="fila_blanco2" runat="server"><td colspan="3">&nbsp;</td></tr>
            <tr id="fila_error2" runat="server">
                <td colspan="3" class="fila_error">
                    <asp:Literal ID="Lerror2" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr><td colspan="3">&nbsp;</td></tr>
            <tr>
                <td colspan="3" align="center"><asp:Button ID="btnSubir" runat="server" CssClass="boton" Text="Aceptar" OnClick="btnSubir_Click"/></td>
            </tr>
        </table>
    </div>

    <div id="divDescripcion" runat="server">
        <br />
        <b>FOTOS PARA LA DESCRIPCI&Oacute;N</b><br /><br />
        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="formulario_subida" />
        &nbsp;&nbsp;<asp:Button ID="btnAnadirFoto" runat="server" Text="A&ntilde;adir" CssClass="boton" OnClick="btnAnadirFoto_Click" /> 
        <table>
            <tr id="filaErrorFoto" runat="server">
                <td class="fila_error">
                    <asp:Literal ID="Lerrorfoto" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
        <br />       
        <%=imagenes%>             
        <br />
        <b>Descripci&oacute;n Castellano</b><br /><br />
        <FTB:FreeTextBox id="txtDescripcion" runat="Server" Width="100%" ConvertHtmlSymbolsToHtmlCodes="true" Language="es-ES" 
        ToolbarLayout="FontFacesMenu,FontSizesMenu,FontForeColorsMenu,FontForeColorPicker,FontBackColorsMenu,
        FontBackColorPicker|Bold,Italic,Underline,Strikethrough,Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,
        JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;CreateLink,Unlink,InsertImage|Cut,Copy,Paste,Delete,Undo,Redo|SymbolsMenu,StylesMenu|InsertRule,InsertDate,InsertTime|InsertTable,EditTable;InsertTableRowAfter,
        InsertTableRowBefore,DeleteTableRow;InsertTableColumnAfter,InsertTableColumnBefore,DeleteTableColumn|
        InsertDiv,EditStyle,Preview,SelectAll" 
        DesignModeCss="styles/estilo.css" ToolbarStyleConfiguration="OfficeMac" TabIndex="5" />                
        <br />        
        <b>Descripci&oacute;n Ingl&eacute;s</b><br /><br />
        <FTB:FreeTextBox id="txtDescripcionEng" runat="Server" Width="100%" ConvertHtmlSymbolsToHtmlCodes="true" Language="es-ES" 
        ToolbarLayout="FontFacesMenu,FontSizesMenu,FontForeColorsMenu,FontForeColorPicker,FontBackColorsMenu,
        FontBackColorPicker|Bold,Italic,Underline,Strikethrough,Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,
        JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;CreateLink,Unlink,InsertImage|Cut,Copy,Paste,Delete,Undo,Redo|SymbolsMenu,StylesMenu|InsertRule,InsertDate,InsertTime|InsertTable,EditTable;InsertTableRowAfter,
        InsertTableRowBefore,DeleteTableRow;InsertTableColumnAfter,InsertTableColumnBefore,DeleteTableColumn|
        InsertDiv,EditStyle,Preview,SelectAll" 
        DesignModeCss="styles/estilo.css" ToolbarStyleConfiguration="OfficeMac" TabIndex="6" />                
        <br />
        <table width="98%">
            <tr>
                <td align="center"><asp:Button ID="btnAceptar" runat="server" CssClass="boton" Text="Aceptar" OnClick="btnAceptar_Click"/></td>
            </tr>
        </table>
    </div>

    <div style="display:none;">
        <input type="hidden" runat="server" id="hidPID" />
        <input type="hidden" id="hidURL" runat="server" />
        <input type="hidden" runat="server" id="hidLogo" />
        <asp:Button ID="btnBorrarFoto" runat="server" OnClick="btnBorrarFoto_Click"/> 
        <asp:Button ID="btnBorrarLogo" runat="server" OnClick="btnBorrarLogo_Click"/>       
    </div>

</div>

</form>

</asp:Content>

