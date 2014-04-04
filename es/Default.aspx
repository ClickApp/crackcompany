<%@ Page Title="Crack Company" Language="C#" MasterPageFile="~/es/MasterPageES.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="es_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.5.2/jquery.min.js" type="text/javascript"></script>

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

    function mostrarDetalles(pid,tit,subtit,des) {
        var objLogo = document.getElementById('LitLogoPeq');
        objLogo.innerHTML = "<img src=\"../logos/logo_" + pid + ".png\" alt=\"" + tit + "\" width=\"48px\" border=\"0\"/>";
        var objTit = document.getElementById('LitTitulo');
        objTit.innerHTML = tit;
        var objSub = document.getElementById('LitSubTitulo');
        objSub.innerHTML = subtit;
        var objDes = document.getElementById('LitDescripcion');
        objDes.innerHTML = des;
        var boton = document.getElementById('<%=lnkMostrarDetalles.ClientID%>');
        boton.click();
    }    

</script>

<form id="form1" runat="server">
<asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" CombineScripts="false" ScriptMode="Release" EnablePartialRendering="true" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ToolkitScriptManager>

<div id="divLogos">

    <div class="divCentrado">    
        <audio id="beep-two" controls preload="auto" style="display:none;">
		    <source src="../audio/beep.mp3" controls></source>
		    <source src="../audio/beep.ogg" controls></source>				
	    </audio>            
        <asp:Repeater ID="rpProyectos" runat="server">
            <ItemTemplate>
                <div class="caja_logo_web">
                    <img id="imgLogo" src="../logos/logo_gris_<%#DataBinder.Eval(Container.DataItem, "PROYECTO_ID").ToString()%>.png" alt="<%#DataBinder.Eval(Container.DataItem, "TITULO").ToString()%>" title="<%#DataBinder.Eval(Container.DataItem, "TITULO").ToString()%>" border="0" width="100%" onmouseover="this.src='../logos/logo_<%#DataBinder.Eval(Container.DataItem, "PROYECTO_ID").ToString()%>.png';javascript:visible(<%#DataBinder.Eval(Container.DataItem, "PROYECTO_ID").ToString()%>);" onmouseout="this.src='../logos/logo_gris_<%#DataBinder.Eval(Container.DataItem, "PROYECTO_ID").ToString()%>.png';javascript:ocultar(<%#DataBinder.Eval(Container.DataItem, "PROYECTO_ID").ToString()%>);" onclick="javascript:mostrarDetalles('<%#DataBinder.Eval(Container.DataItem, "PROYECTO_ID").ToString()%>','<%#DataBinder.Eval(Container.DataItem, "TITULO").ToString()%>','<%#DataBinder.Eval(Container.DataItem, "SUBTITULO").ToString()%>','<%#DataBinder.Eval(Container.DataItem, "DESCRIPCION").ToString()%>');" style="vertical-align:middle;outline:none;cursor:pointer;"/>
                    <br /><br />
                    <div id="div_<%#DataBinder.Eval(Container.DataItem, "PROYECTO_ID").ToString()%>" style="display:none;">
                        <span class="titulo_caja_logo"><%#DataBinder.Eval(Container.DataItem, "TITULO").ToString()%></span><br />
                        <span class="subtitulo_caja_logo"><%#DataBinder.Eval(Container.DataItem, "SUBTITULO").ToString()%></span>
                    </div>    
                </div>            
            </ItemTemplate>              
        </asp:Repeater>        
    </div>

</div>

<div id="divEspacio">&nbsp;</div>

<script type="text/javascript">

    $(".caja_logo_web img").each(function (i) {
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

<div style="display:none;">
    <asp:LinkButton ID="lnkMostrarDetalles" runat="server" OnClientClick="return false;" />
</div>

<div id="divDetalles">   
    <div class="div_TituloVentana">
        <img src="../images/btnCerrar.png" height="22" width="22" runat="server" id="imgCerrar" alt="Cerrar" onmouseover="this.src='../images/btnCerrarAct.png';" onmouseout="this.src='../images/btnCerrar.png';" style="cursor:pointer;" onclick="return false;" />                
    </div>
    <br />
    <table>
        <tr>
            <td>
                <label id="LitLogoPeq"></label>                            
            </td>
            <td valign="bottom">
                &nbsp;&nbsp;<span class="titulo"><label id="LitTitulo"></label></span>             
                &nbsp;&nbsp;<span class="subtitulo"><label id="LitSubTitulo"></label></span>                    
            </td>
        </tr>                
    </table>
	<br />    
    <label id="LitDescripcion"></label>         
</div>       

<asp:AnimationExtender ID="AnimationExtender1" runat="server" TargetControlID="lnkMostrarDetalles">
    <Animations>
        <OnLoad>
            <Sequence AnimationTarget="divDetalles">              
                <StyleAction AnimationTarget="divDetalles" Attribute="display" Value="none"/>
                <Parallel AnimationTarget="divDetalles" Duration=".5" Fps="150">                
                    <Resize Width="1024" />                                                        
                    <Scale ScaleFactor="0.05" FontUnit="px" />
                    <FadeIn />
                </Parallel>                                                              
            </Sequence>  
        </OnLoad>
        <OnClick>
            <Sequence AnimationTarget="divDetalles">              
                <Parallel AnimationTarget="divLogos" Duration=".5" Fps="150">                                                    
                    <FadeOut/>
                </Parallel>
                <StyleAction AnimationTarget="divLogos" Attribute="display" Value="none"/>                  
                <StyleAction AnimationTarget="divDetalles" Attribute="display" Value="block"/>                
                <Parallel AnimationTarget="divDetalles" Duration=".5" Fps="150">                
                    <Resize Width="1024" />                                                        
                    <FadeIn />
                </Parallel>                                                                                            
            </Sequence>
        </OnClick>
    </Animations>        
</asp:AnimationExtender>
        
<asp:AnimationExtender ID="AnimationExtender2" runat="server" TargetControlID="imgCerrar">        
    <Animations>
        <OnClick>
            <Sequence AnimationTarget="divDetalles">
                <Parallel AnimationTarget="divDetalles" Duration=".7" Fps="150">
                    <Move Horizontal="350" Vertical="-50"></Move>
                    <Scale ScaleFactor="0.05" FontUnit="px" />
                    <FadeOut />
                </Parallel>                
                <StyleAction AnimationTarget="divLogos" Attribute="display" Value="block"/> 
                <Parallel AnimationTarget="divLogos" Duration=".5" Fps="150">                                                    
                    <Resize Width="1024" />
                    <FadeIn/>
                </Parallel>               
            </Sequence>
        </OnClick>
    </Animations>        
</asp:AnimationExtender>

</form>

</asp:Content>

