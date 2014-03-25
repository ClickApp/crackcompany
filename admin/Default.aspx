<%@ Page Title="Crack Company - Administraci&oacute;n" Language="C#" MasterPageFile="~/admin/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<form id="form1" runat="server">

<div class="divCentrado">
    Proyecto&nbsp;
    <asp:TextBox ID="txtBuscador" runat="server" CssClass="formulario" Width="350px"></asp:TextBox>&nbsp;<br /><br /><asp:Button ID="btnBuscar" runat="server" CssClass="boton" Text="Buscar" OnClick="btnBuscar_Click" />
    &nbsp;&nbsp;
    <asp:Button ID="btnNuevo" runat="server" CssClass="boton" Text="Nuevo" OnClick="btnNuevo_Click" />
</div>

<div class="divCentrado">    
    <br /><br />
    <asp:Repeater ID="rpProyectos" runat="server">
        <ItemTemplate>
            <div class="caja_logo"><img id="imgLogo" src="../img/logo<%#DataBinder.Eval(Container.DataItem, "PROYECTO_ID").ToString()%>.png" alt="<%#DataBinder.Eval(Container.DataItem, "TITULO").ToString()%>" title="<%#DataBinder.Eval(Container.DataItem, "TITULO").ToString()%>" border="0" width="100%" onmouseover="this.src='../img/logo<%#DataBinder.Eval(Container.DataItem, "PROYECTO_ID").ToString()%>.png';" onmouseout="this.src='../img/logo<%#DataBinder.Eval(Container.DataItem, "PROYECTO_ID").ToString()%>.png';" style="vertical-align:middle;outline:none;cursor:pointer;" onclick="javascript:gestionarLogos(<%#DataBinder.Eval(Container.DataItem, "PROYECTO_ID").ToString()%>);"/></div>
        </ItemTemplate>          
    </asp:Repeater>    
</div>

</form>

</asp:Content>

