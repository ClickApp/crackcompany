<%@ Page Title="Crack Company - Administraci&oacute;n" Language="C#" MasterPageFile="~/admin/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="admin_Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script type="text/javascript">

    function visible(pid) {

        obj = document.getElementById("div_" + pid);
        obj.style.display = "block";

    }

    function ocultar(pid) {
        obj = document.getElementById("div_" + pid);
        obj.style.display = "none";

    }

    function GestionarIconos(pid, tit, activa, accion) {

        var objPid = document.getElementById('<%=hidPID.ClientID%>');
        objPid.value = pid;

        var objTit = document.getElementById('<%=hidTitulo.ClientID%>');
        objTit.value = tit;

        var objAct = document.getElementById('<%=hidActivo.ClientID%>');
        objAct.value = activa;

        var objAccion = document.getElementById('<%=hidAccion.ClientID%>');
        objAccion.value = accion;

        var boton = document.getElementById('<%=btnGestionarIconos.ClientID%>');
        boton.click();
    }

</script>

<form id="form1" runat="server">
<asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" CombineScripts="false" ScriptMode="Release" EnablePartialRendering="true" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ToolkitScriptManager>

<div class="divCentrado">
    Proyecto&nbsp;
    <asp:TextBox ID="txtBuscador" runat="server" CssClass="formulario" Width="350px"></asp:TextBox>&nbsp;<br /><br /><asp:Button ID="btnBuscar" runat="server" CssClass="boton" Text="Buscar" OnClick="btnBuscar_Click" />   
</div>

<div class="divCentrado">    
    <br /><br />
    <asp:Repeater ID="rpProyectos" runat="server">
        <ItemTemplate>
            <div class="caja_logo">
            <table width="80%" align="center">
                <tr>                    
                    <td><img id="imgActivar" src="<%#objUtils.muestraIconos(Boolean.Parse(DataBinder.Eval(Container.DataItem, "ACTIVO").ToString()))%>" alt="<%#objUtils.traduceActivoDesactivo(Boolean.Parse(DataBinder.Eval(Container.DataItem, "ACTIVO").ToString()))%> Proyecto" title="<%#objUtils.traduceActivoDesactivo(Boolean.Parse(DataBinder.Eval(Container.DataItem, "ACTIVO").ToString()))%> Proyecto" border="0px" height="20px" width="20px" style="cursor:pointer; vertical-align:middle;" onclick="javascript:GestionarIconos('<%# Eval("PROYECTO_ID").ToString()%>','<%# Eval("TITULO").ToString()%>','<%# Eval("ACTIVO").ToString()%>',1);"/></td>
                    <td><img id="imgModificar" src="images/ico_modificar.png" alt="Editar Proyecto" title="Editar Proyecto" border="0px" height="20px" width="20px" style="cursor:pointer; vertical-align:middle;" onclick="javascript:GestionarIconos('<%# Eval("PROYECTO_ID").ToString()%>','<%# Eval("TITULO").ToString()%>','<%# Eval("ACTIVO").ToString()%>',2);" /></td>
                    <td><img id="imgEliminar" src="images/ico_delete.gif" alt="Eliminar Proyecto" title="Eliminar Proyecto" border="0px" height="20px" width="20px" style="cursor:pointer; vertical-align:middle;" onclick="javascript:GestionarIconos('<%# Eval("PROYECTO_ID").ToString()%>','<%# Eval("TITULO").ToString()%>','<%# Eval("ACTIVO").ToString()%>',3);" /> </td>
                </tr>                
            </table>
            <br />
            <img id="imgLogo" src="../logos/logo_gris_<%#DataBinder.Eval(Container.DataItem, "PROYECTO_ID").ToString()%>.png" alt="<%#DataBinder.Eval(Container.DataItem, "TITULO").ToString()%>" title="<%#DataBinder.Eval(Container.DataItem, "TITULO").ToString()%>" border="0" width="100%" onmouseover="this.src='../logos/logo_<%#DataBinder.Eval(Container.DataItem, "PROYECTO_ID").ToString()%>.png';javascript:visible(<%#DataBinder.Eval(Container.DataItem, "PROYECTO_ID").ToString()%>);" onmouseout="this.src='../logos/logo_gris_<%#DataBinder.Eval(Container.DataItem, "PROYECTO_ID").ToString()%>.png';javascript:ocultar(<%#DataBinder.Eval(Container.DataItem, "PROYECTO_ID").ToString()%>);" style="vertical-align:middle;outline:none;cursor:pointer;" onclick="javascript:gestionarLogos(<%#DataBinder.Eval(Container.DataItem, "PROYECTO_ID").ToString()%>);"/>
            <br /><br />
            <div id="div_<%#DataBinder.Eval(Container.DataItem, "PROYECTO_ID").ToString()%>" style="display:none;">
            <%#DataBinder.Eval(Container.DataItem, "TITULO").ToString()%><br />
            <%#DataBinder.Eval(Container.DataItem, "SUBTITULO").ToString()%>
            </div>    
            </div>            
        </ItemTemplate>          
    </asp:Repeater>    
</div>

<div style="display:none;">
    <input type="hidden" id="hidPID" runat="server" />
    <input type="hidden" id="hidAccion" runat="server" />
    <input type="hidden" id="hidActivo" runat="server" />
    <input type="hidden" id="hidTitulo" runat="server" />
    <asp:Button ID="btnGestionarIconos" runat="server" OnClick="btnGestionarIconos_Click"/>              
</div>

<asp:HiddenField ID="hdnConfirmMessage" runat="server"></asp:HiddenField>
<div id="ModalPopUpConfirmacion">
    <asp:ModalPopupExtender ID="ModalPopupExtenderConfirmacion" runat="server" PopupControlID="panConfirmacion" BackgroundCssClass="modalBackground"
    PopupDragHandleControlID="panConfirmacion" TargetControlID="hdnConfirmMessage" CancelControlID="imgCerrar">
    </asp:ModalPopupExtender>
   
    <asp:Panel ID="panConfirmacion" runat="server" Height="200px" Width="500px" CssClass="ModalWindow">
        <div class="div_TituloVentana">
            <img src="../images/btnCerrar.png" height="22" width="22" runat="server" id="imgCerrar" alt="Cerrar" onmouseover="this.src='../images/btnCerrarAct.png';" onmouseout="this.src='../images/btnCerrar.png';" style="cursor:pointer;"/>                
        </div>
        <table width="95%" align="center">                                        
            <tr>
                <td align="center">
                    <asp:Label ID="Lconfirmacion" runat="server"></asp:Label>                                
                </td>
            </tr>  
            <tr><td colspan="2">&nbsp;</td></tr>                           
            <tr>
                <td align="center">
                    <asp:Button ID="btnSi" runat="server" Text="Si" CssClass="boton" OnClick="btnSi_Click"/>
                    &nbsp;&nbsp;
                    <asp:Button ID="btnNo" runat="server" Text="No" CssClass="boton" OnClick="btnNo_Click"/>
                </td>
            </tr>
        </table>
        <br />
    </asp:Panel>    
</div>  

</form>

</asp:Content>

