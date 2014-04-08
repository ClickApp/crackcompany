<%@ Page Title="Crack Company - Contact" Language="C#" MasterPageFile="~/es/MasterPageES.master" AutoEventWireup="true" CodeFile="contact.aspx.cs" Inherits="es_contact" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.5.2/jquery.min.js" type="text/javascript"></script>

<style type="text/css">
    
body
{	
	background-color:#F3F3F3; 	
}	
    
</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<form id="form1" runat="server">
<asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" CombineScripts="false" ScriptMode="Release" EnablePartialRendering="true" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ToolkitScriptManager>

    <div id="divContact">    
                  
        <span class="titulo" style="margin-left:25px;">Contact</span>   
        
        <table width="95%" align="center" style="margin-left:20px;font-family:Times New Roman;">
            <tr><td colspan="3">&nbsp;</td></tr>
            <tr>
                <td colspan="3" class="texto">Estaremos <b>encantados</b> de responder a cualquier tipo de duda o proposici&oacute;n sobre <b>colaboraciones en proyectos</b> u <b>otros trabajos.</b></td>                
            </tr>
            <tr><td colspan="3">&nbsp;</td></tr>
            <tr>
                <td width="50px">Nombre&nbsp;</td>
                <td><asp:TextBox ID="txtNombre" runat="server" CssClass="formulario" Width="400px" TabIndex="1"></asp:TextBox></td>
                <td rowspan="3" valign="bottom" style="border-bottom:#000000 1px solid;vertical-align:bottom;" class="citas">&nbsp;Buscanos en</td>
            </tr>
            <tr><td colspan="2">&nbsp;</td></tr>
            <tr>
                <td>E-mail&nbsp;</td>
                <td><asp:TextBox ID="txtEmail" runat="server" CssClass="formulario" Width="400px" TabIndex="2"></asp:TextBox></td>                                                   
            </tr>
            <tr>
                <td colspan="2">&nbsp;</td>
                <td rowspan="4" style="vertical-align:middle;text-align:right;letter-spacing:3px; line-height:2px;">
                    &nbsp;<span class="caja_about"><img id="img1" src="../images/pinterest.png" alt="Pinterest" title="Pinterest" border="0" onmouseover="this.src='../images/pinterestAct.png';" onmouseout="this.src='../images/pinterest.png';" style="vertical-align:middle;outline:none;cursor:pointer;"/></span>
                    <span class="caja_about"><img id="img2" src="../images/twitter.png" alt="Twitter" title="Twitter" border="0" onmouseover="this.src='../images/twitterAct.png';" onmouseout="this.src='../images/twitter.png';" style="vertical-align:middle;outline:none;cursor:pointer;"/></span>
                    <span class="caja_about"><img id="img3" src="../images/vimeo.png" alt="Vimeo" title="Vimeo" border="0" onmouseover="this.src='../images/vimeoAct.png';" onmouseout="this.src='../images/vimeo.png';" style="vertical-align:middle;outline:none;cursor:pointer;"/></span><br />
                    <span class="caja_about"><img id="img4" src="../images/behance.png" alt="Behance" title="Behance" border="0" onmouseover="this.src='../images/behanceAct.png';" onmouseout="this.src='../images/behance.png';" style="vertical-align:middle;outline:none;cursor:pointer;"/></span>&nbsp;
                    <span class="caja_about"><img id="img5" src="../images/instagram.png" alt="Instagram" title="Instagram" border="0" onmouseover="this.src='../images/instagramAct.png';" onmouseout="this.src='../images/instagram.png';" style="vertical-align:middle;outline:none;cursor:pointer;"/></span>&nbsp;
                    <span class="caja_about"><img id="img6" src="../images/facebook.png" alt="Facebook" title="Facebook" border="0" onmouseover="this.src='../images/facebookAct.png';" onmouseout="this.src='../images/facebook.png';" style="vertical-align:middle;outline:none;cursor:pointer;"/></span>&nbsp;                 
                    <span class="caja_about"><img id="img7" src="../images/domestika.png" alt="Domestika" title="Domestika" border="0" onmouseover="this.src='../images/domestikaAct.png';" onmouseout="this.src='../images/domestika.png';" style="vertical-align:middle;outline:none;cursor:pointer;"/></span>            
                </td>   
            </tr>
            <tr>
                <td>Asunto&nbsp;</td>
                <td><asp:TextBox ID="txtAsunto" runat="server" CssClass="formulario" Width="400px" TabIndex="3"></asp:TextBox></td>                               
            </tr>
            <tr><td colspan="2">&nbsp;</td></tr>
            <tr>
                <td>&nbsp;</td>
                <td><asp:CheckBox ID="chkNewsletter" runat="server" Text="Recibir notificaciones de nuevos proyectos" Checked="true" TabIndex="4" /></td>                
            </tr>
            <tr><td colspan="3">&nbsp;</td></tr>
            <tr>
                <td valign="top">Mensaje&nbsp;</td>
                <td colspan="2"><asp:TextBox ID="txtMensaje" runat="server" TextMode="MultiLine" CssClass="formulario_contacto" Width="98%" TabIndex="5"></asp:TextBox></td>
            </tr>           
            <tr><td colspan="3">&nbsp;</td></tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <table width="100%">
                        <tr id="filaError" runat="server">
                            <td class="fila_error"><asp:Literal ID="Lerror" runat="server"></asp:Literal></td>
                        </tr>
                        <tr id="filaAcierto" runat="server">
                            <td class="fila_acierto"><asp:Literal ID="Lacierto" runat="server"></asp:Literal></td>
                        </tr>
                    </table>
                </td>
                <td align="right"><asp:Button ID="btnEnviar" runat="server" Text="Enviar" CssClass="boton" OnClick="btnEnviar_Click" /></td>
            </tr>             
        </table> 
    </div>  

    <audio id="beep-two" controls preload="auto" style="display:none;">
		<source src="../audio/beep.mp3" controls></source>
		<source src="../audio/beep.ogg" controls></source>				
	</audio>

    <script type="text/javascript">

        $(".caja_about img").each(function (i) {
            if (i != 0) {
                $("#beep-two")
            .clone()
            .attr("id", "beep-two" + i)
            .appendTo($(this).parent());
            }

            $(this).data("beeper", i);
        })

        .mouseenter(function () {
            $("#beep-two" + $(this).data("beeper"))[0].play();
        });

        $("#beep-two").attr("id", "beep-two0");  

    </script>

</form>

</asp:Content>

