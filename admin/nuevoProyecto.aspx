<%@ Page Title="Crack Company - Administraci&oacute;n" Language="C#" MasterPageFile="~/admin/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="nuevoProyecto.aspx.cs" Inherits="admin_nuevoProyecto" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<div class="divContenidoGestor">

<h1 align="center">Nuevo Proyecto</h1>
    
    <asp:Literal ID="LParcial" runat="server"></asp:Literal>

    <div id="divTitulos" runat="server">
        <table align="center" width="500px">
            <tr>
                <td><b>T&iacute;tulo</b>&nbsp;<span class="texto_rojo">(*)</span></td>
                <td rowspan="2" width="5px">&nbsp;</td>
                <td><asp:TextBox ID="txtTitulo" runat="server" CssClass="formulario" Width="350px" TabIndex="1"></asp:TextBox></td>               
            </tr>
            <tr>
                <td><b>Subt&iacute;tulo</b></td>
                <td><asp:TextBox ID="txtSubtitulo" runat="server" CssClass="formulario" Width="350px" TabIndex="2"></asp:TextBox></td>
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
                <td><asp:FileUpload ID="txtLogo" runat="server" CssClass="formulario" Width="350px"/></td>                
            </tr>
            <tr><td colspan="3">&nbsp;</td></tr>
            <tr><td colspan="3">El logo se redimensiona a un tama&ntilde;o de 250x250px. Se recomienda subir im&aacute;genes centradas y encuadradas en un lienzo de estas dimensiones, que conserve un margen razonable, para que no se distorsionen. </td></tr>
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
        <b>Descripci&oacute;n Castellano</b><br /><br />
        <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" Width="98%" Height="700px"></asp:TextBox>
        <asp:HtmlEditorExtender ID="HTMLEditorExtender" runat="server" TargetControlID="txtDescripcion"
            EnableSanitization="false" OnImageUploadComplete="HTMLEditorExtender_ImageUploadComplete" DisplaySourceTab="true">            
            <Toolbar>
                <asp:Undo />
                <asp:Redo />
                <asp:Bold />
                <asp:Italic />
                <asp:Underline />
                <asp:StrikeThrough />
                <asp:Subscript />
                <asp:Superscript />
                <asp:JustifyLeft />
                <asp:JustifyCenter />
                <asp:JustifyRight />
                <asp:JustifyFull />
                <asp:InsertOrderedList />
                <asp:InsertUnorderedList />
                <asp:CreateLink />
                <asp:UnLink />
                <asp:RemoveFormat />
                <asp:SelectAll />
                <asp:UnSelect />
                <asp:Delete />
                <asp:Cut />
                <asp:Copy />
                <asp:Paste />
                <asp:BackgroundColorSelector />
                <asp:ForeColorSelector />
                <asp:FontNameSelector />
                <asp:FontSizeSelector />
                <asp:Indent />
                <asp:Outdent />
                <asp:InsertHorizontalRule />
                <asp:HorizontalSeparator />
                <asp:InsertImage />
            </Toolbar>
        </asp:HtmlEditorExtender>
        <br />
        <table width="98%">
            <tr>
                <td align="center"><asp:Button ID="btnAceptar" runat="server" CssClass="boton" Text="Aceptar" OnClick="btnAceptar_Click"/></td>
            </tr>
        </table>
    </div>

    <div style="display:none;">
        <input type="hidden" runat="server" id="hidPID" />
    </div>

</div>

</form>

</asp:Content>

