<%@ Page Title="Crack Company - Administraci&oacute;n" Language="C#" MasterPageFile="~/admin/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<form id="form1" runat="server">

<div class="divCentrado">
    Proyecto&nbsp;
    <asp:TextBox ID="txtBuscador" runat="server" CssClass="formulario" Width="350px"></asp:TextBox>&nbsp;<br /><br /><asp:Button ID="btnBuscar" runat="server" CssClass="boton" Text="Buscar" />
</div>

<div class="divCentrado">    
    <asp:Repeater ID="rpProyectos" runat="server">
        <ItemTemplate></ItemTemplate>          
    </asp:Repeater>
    <br /><br /><asp:Button ID="btnNuevo" runat="server" CssClass="boton" Text="Nuevo" OnClick="btnNuevo_Click" />
</div>

</form>

</asp:Content>

