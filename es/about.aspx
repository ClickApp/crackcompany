<%@ Page Title="Crack Company - About" Language="C#" MasterPageFile="~/es/MasterPageES.master" AutoEventWireup="true" CodeFile="about.aspx.cs" Inherits="es_about" %>

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

<script type="text/javascript">

    function visible(pid) {
        obj = document.getElementById("div_" + pid);
        obj.style.display = "block";
    }

    function ocultar(pid) {
        obj = document.getElementById("div_" + pid);
        obj.style.display = "none";
    }

    function cargarURL() {
        history.pushState('estado', 'null', 'http://localhost/crackcompany/es/');
    }

</script>

<form id="form1" runat="server">
<asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" CombineScripts="false" ScriptMode="Release" EnablePartialRendering="true" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ToolkitScriptManager>
    
    <div id="divAbout" style="display:none;">    
        <audio id="beep-two" controls preload="auto" style="display:none;">
		    <source src="../audio/beep.mp3" controls></source>
		    <source src="../audio/beep.ogg" controls></source>				
	    </audio>
       
        <span class="titulo" style="margin-left:25px;">About<div id="cajaTituloAbout"></div></span>   
        
        <table width="95%" align="center" style="margin-left:20px;">
            <tr><td colspan="4">&nbsp;</td></tr>
            <tr>
                <td width="180px"><div class="caja_about"><a id="lnkPakrolsky" runat="server"><img id="imgBorja" src="../images/borja_pakrolsky.png" alt="Borja Pakrolsky" title="Borja Pakrolsky" border="0" width="100%" onmouseover="this.src='../images/borja_pakrolsky_act.png';javascript:visible(1);" onmouseout="this.src='../images/borja_pakrolsky.png';javascript:ocultar(1);" onclick="javascript:mostrarDetalles(1);" style="vertical-align:middle;outline:none;cursor:pointer;"/></a></div></td>
                <td width="15px">&nbsp;</td>
                <td width="180px"><div class="caja_about"><a id="lnkBidezabal" runat="server"><img id="imgJavi" src="../images/javi_bidezabal.png" alt="Javier Bidezabal" title="Javier Bidezabal" border="0" width="100%" onmouseover="this.src='../images/javi_bidezabal_act.png';javascript:visible(2);" onmouseout="this.src='../images/javi_bidezabal.png';javascript:ocultar(2);" onclick="javascript:mostrarDetalles(2);" style="vertical-align:middle;outline:none;cursor:pointer;"/></a></div></td>
                <td align="right" valign="bottom"><div class="caja_about"><img id="imgTrabaja" src="../images/trabaja.png" alt="Trabaja con nosotros" title="Trabaja con nosotros" border="0" onmouseover="this.src='../images/trabaja_act.png';" onmouseout="this.src='../images/trabaja.png';" style="vertical-align:middle;outline:none;cursor:pointer;"/></div></td>
            </tr>
            <tr>
                <td align="center" height="40px">
                    <div id="div_1" style="display:none;" class="titulo_caja_about">
                        Borja Pakrolsky                        
                    </div>    
                </td>
                <td>&nbsp;</td>
                <td align="center">
                    <div id="div_2" style="display:none;" class="titulo_caja_about">
                        Javier Bidezabal                 
                    </div>   
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr><td colspan="4">&nbsp;</td></tr>
            <tr><td colspan="4"><img src="../images/barras_color.png" alt="" /></td></tr>
            <tr><td colspan="4">&nbsp;</td></tr>
            <tr><td colspan="4">&nbsp;</td></tr>
            <tr><td colspan="4">&nbsp;</td></tr>
            <tr>
                <td colspan="4">
                    <b>Crack Co</b>. Compa&ntilde;&iacute;a, colectivo, estudio, agencia, amigos. <b>Nace en 2011 en una tasca</b>. Como toda empresa que se considere seria. <b>Aprendimos a divertirnos</b>, y lo hicimos mucho antes de o&iacute;r hablar de <b>creatividad</b>, el instituto no estaba preparado para ello y la universidad quedaba lejos, peque&ntilde;a y borrosa.
                    <p align="center" class="titulo_caja_logo">&quot;Una persona aburrida es un muerto que respira&quot;<br /></p>
                    <p>Programaci&oacute;n y Dise&ntilde;o web, Dise&ntilde;o gr&aacute;fico e industrial, Ilustraci&oacute;n, Packaging, Edici&oacute;n de v&iacute;deo, Guionizaci&oacute;n, Fotograf&iacute;a, Direcci&oacute;n de Arte, Sonido. Una madre lo habr&iacute;a resumido con <i><b>&quot;No salir del cuarto&quot;.</b></i> Nosotros lo hicimos con <b>actividad creativa.</b></p>
                    <p>Podr&iacute;amos dedicarnos en cuerpo y alma a una de estas profesiones, pero estamos seguros que acabar&iacute;a siendo f&aacute;cil y cuando algo, lo que sea, se vuelve f&aacute;cil, <b>acaba siendo aburrido.</b></p>
                    <p>Aquella noche de 2011, solo &eacute;ramos dos seres balbuzeantes en aquel antro sombr&iacute;o, pero este proyecto lo respalda un <b>espl&eacute;ndido equipo t&eacute;cnico</b> y una trabajada red de colaboradores.</p>
                </td>               
            </tr>
            <%--<tr><td colspan="4" height="100px">&nbsp;</td></tr> --%>           
        </table> 

        <div id="divPie">
            Original idea. Copyright &copy; <b>All Rights Reserved</b>
        </div> 

    </div>       

    <div id="BorjaPakrolsky" style="display:none;">  
            
       <div id="fotacaPakrolsky">        
        <img src="../images/pakrolsky.png" height="100%" alt="Borja Pakrolsky" />
       </div>       
       <div class="div_TituloVentanaAbout">
        <img src="../images/btnCerrar.png" height="22" width="22" runat="server" id="imgCerrar" alt="Cerrar" onmouseover="this.src='../images/btnCerrarAct.png';" onmouseout="this.src='../images/btnCerrar.png';" style="cursor:pointer;" onclick="javascript:cargarURL();"/>                
       </div>
       <div class="div_Textaco">
        <span class="titulo_about">Borja Pakrolsky</span><br />
        <img src="../images/barras_color_paju.png" alt="" />
        <p><b>Pakrolsky naci&oacute; sin avisar y de forma violenta a mediados de 1986.</b></p>
        <p>Pas&eacute; por el IES Diego Vel&aacute;zquez donde no aprend&iacute; absolutamente nada. Despu&eacute;s vinieron las <b>artes gr&aacute;ficas</b> en el IES Virgen de la Paloma el M&aacute;ster en Dise&ntilde;o Gr&aacute;fico en la escuela CEI donde un tipo <b>muy agradable me calific&oacute; con Sobresaliente.</b></p>
        <p class="cursivaGran">            En una hoja beige.<br />            Sin medallas.<br />            Sin canciones.
        </p>    
        <p>He trabajado en <b>Perfil Creativo</b> como Director de arte, conozco la vida freelance y Tambi&eacute;n he colaborado con <b>Patrimonio de la comunidad de Madrid</b> o el <b>Grupo espa&ntilde;ol de Conservaci&oacute;n de Arte.</b></p>
        <p><b><u>AWARDS</u></b></p>
        <p>            <b>J&Oacute;VENES ARTISTAS</b> de la Sierra Noroeste de Madrid edici&oacute;n 2010<br />            <b>VODAFONE 360</b> &quot;Decora nuestro Vag&oacute;n cafeter&iacute;a&quot;<br />            Finalista del concurso &quot;perdidos&quot; organizado por el canal de Televisi&oacute;n <b>CUATRO</b><br />            Finalista del concurso imagen corporativa para el XX aniversario de <b>PULL&BEAR</b>
        </p>
       </div>
       <div class="div_Cita">
        <p>
            Benditas sean las mujeres<br />
            pues son dueñas de nuestra alegría,<br />
            y malditas las que lo saben.<br /><br />
            <span class="caja_about"><img id="imgBehance" src="../images/behance.png" alt="Behance" title="Behance" border="0" onmouseover="this.src='../images/behanceAct.png';" onmouseout="this.src='../images/behance.png';" style="vertical-align:middle;outline:none;cursor:pointer;"/></span>
            <span class="caja_about"><img id="imgFacebook" src="../images/facebook.png" alt="Facebook" title="Facebook" border="0" onmouseover="this.src='../images/facebookAct.png';" onmouseout="this.src='../images/facebook.png';" style="vertical-align:middle;outline:none;cursor:pointer;"/></span>
            <span class="caja_about"><img id="imgInstagram" src="../images/instagram.png" alt="Instagram" title="Instagram" border="0" onmouseover="this.src='../images/instagramAct.png';" onmouseout="this.src='../images/instagram.png';" style="vertical-align:middle;outline:none;cursor:pointer;"/></span>
            <span class="caja_about"><img id="imgTwitter" src="../images/twitter.png" alt="Twitter" title="Twitter" border="0" onmouseover="this.src='../images/twitterAct.png';" onmouseout="this.src='../images/twitter.png';" style="vertical-align:middle;outline:none;cursor:pointer;"/></span>
            <span class="caja_about"><img id="imgDomestika" src="../images/domestika.png" alt="Domestika" title="Domestika" border="0" onmouseover="this.src='../images/domestikaAct.png';" onmouseout="this.src='../images/domestika.png';" style="vertical-align:middle;outline:none;cursor:pointer;"/></span>
            <br />
            <b style="margin-top:-15px;" class="texto_url"><a href="http://www.borjapakrolsky.com" target="_blank" class="links">www.borjapakrolsky.com</a></b>
        </p>
       </div>
    </div>

    <div id="JavierBidezabal" style="display:none;">
       
       <div id="fotacaBidezabal">
        <img src="../images/bidezabal.png" height="100%" alt="Javier Bidezabal" />
       </div>
       <div class="div_TituloVentanaAbout">
        <img src="../images/btnCerrar.png" height="22" width="22" runat="server" id="imgCerrar2" alt="Cerrar" onmouseover="this.src='../images/btnCerrarAct.png';" onmouseout="this.src='../images/btnCerrar.png';" style="cursor:pointer;" onclick="javascript:cargarURL();"/>                
       </div>
       <div class="div_Textaco">
        <span class="titulo_about">Javier Bidezabal</span><br />
        <img src="../images/barras_color_javi.png" alt="" />
        <p><b>Javier E. Mart&iacute;nez Bidezabal. Fabricado en 1987.</b> Madrid, España.</p>
        <p>Sal&iacute; defectuoso, fui un bebe llor&oacute;n. m&aacute;s tarde un ni&ntilde;o con tos cr&oacute;nica que miraba siniestramente por la ventana la ciudad de noche. Me mude al campo, <b>se paso la tos</b>. Guerras de piedras, brechas, <b>¡ ha sido &eacute;l !</b> , caba&ntilde;as, fresquitos, mi bici, cromos, m&aacute;s brechas, f&uacute;tbol. Que malo era al f&uacute;tbol. <b>Empece a dibujar.</b></p>
        <p>Tras mi transparente paso por el instituto empece a tomarme la vida m&aacute;s en serio y a formarme en lo que me interesaba. Ilustrador editorial en <b>ESDIP</b>, M&aacute;ster en Dise&ntilde;o Gr&aacute;fico en <b>CEI</b> Photoshop Avanzado en <b>SUNION</b>, a&aacute;n continuo form&aacute;ndome, en fotograf&iacute;a y escritura guionizada en 3 actos.</p>    
        <p>Hasta ahora he trabajado como <b>Freelance.</b> Para la <b>UAM</b> Universidad Au&oacute;onoma de Madrid, <b>Point, Grupo Mir, Vel&aacute;zquez Inversores</b> y otras empresas. Actualmente dirijo y soy co-fundador de <b>Crack Company.</b></p>
        <p><b><u>AWARDS</u></b></p>
        <p>Ganador del concurso de <b>poes&iacute;a y narrativa breve</b> de Torrelodones 2011.</p>
       </div>
       <div class="div_Cita">
        <p>
            Hay rincones en nuestra mente<br />
            donde somos eternos.<br /><br />
            <span class="caja_about"><img id="img1" src="../images/behance.png" alt="Behance" title="Behance" border="0" onmouseover="this.src='../images/behanceAct.png';" onmouseout="this.src='../images/behance.png';" style="vertical-align:middle;outline:none;cursor:pointer;"/></span>
            <span class="caja_about"><img id="img2" src="../images/facebook.png" alt="Facebook" title="Facebook" border="0" onmouseover="this.src='../images/facebookAct.png';" onmouseout="this.src='../images/facebook.png';" style="vertical-align:middle;outline:none;cursor:pointer;"/></span>
            <span class="caja_about"><img id="img3" src="../images/instagram.png" alt="Instagram" title="Instagram" border="0" onmouseover="this.src='../images/instagramAct.png';" onmouseout="this.src='../images/instagram.png';" style="vertical-align:middle;outline:none;cursor:pointer;"/></span>
            <span class="caja_about"><img id="img4" src="../images/twitter.png" alt="Twitter" title="Twitter" border="0" onmouseover="this.src='../images/twitterAct.png';" onmouseout="this.src='../images/twitter.png';" style="vertical-align:middle;outline:none;cursor:pointer;"/></span>
            <span class="caja_about"><img id="img5" src="../images/domestika.png" alt="Domestika" title="Domestika" border="0" onmouseover="this.src='../images/domestikaAct.png';" onmouseout="this.src='../images/domestika.png';" style="vertical-align:middle;outline:none;cursor:pointer;"/></span>            
        </p>
       </div>
    
    </div>

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

    <asp:AnimationExtender ID="AnimationExtender1" runat="server" TargetControlID="lnkPakrolsky">
        <Animations>
            <OnLoad>
                <Sequence AnimationTarget="BorjaPakrolsky">              
                    <StyleAction AnimationTarget="BorjaPakrolsky" Attribute="display" Value="none"/>
                    <Parallel AnimationTarget="BorjaPakrolsky" Duration=".5" Fps="150">                
                        <%--<Resize Width="1024" />                                                        
                        <Scale ScaleFactor="0.05" FontUnit="px" />--%>
                        <FadeIn />
                    </Parallel>                                                                            
                </Sequence>  
            </OnLoad>
            <OnClick>
                <Sequence AnimationTarget="BorjaPakrolsky">              
                    <Parallel AnimationTarget="divAbout" Duration=".5" Fps="150">                                                    
                        <FadeOut/>
                    </Parallel>
                    <StyleAction AnimationTarget="divAbout" Attribute="display" Value="none"/>  
                    <StyleAction AnimationTarget="divPie" Attribute="display" Value="none"/>                
                    <StyleAction AnimationTarget="BorjaPakrolsky" Attribute="display" Value="block"/>                                                                            
                    <Parallel AnimationTarget="BorjaPakrolsky" Duration=".5" Fps="150">                
                        <%--<Resize Width="1024" /> --%>                                                       
                        <FadeIn />
                    </Parallel>                                                                                            
                </Sequence>
            </OnClick>
        </Animations>        
    </asp:AnimationExtender>

    <asp:AnimationExtender ID="AnimationExtender2" runat="server" TargetControlID="lnkBidezabal">
        <Animations>
            <OnLoad>
                <Sequence AnimationTarget="JavierBidezabal">              
                    <StyleAction AnimationTarget="JavierBidezabal" Attribute="display" Value="none"/>
                    <Parallel AnimationTarget="JavierBidezabal" Duration=".5" Fps="150">                
                       <%-- <Resize Width="1024" />                                                        
                        <Scale ScaleFactor="0.05" FontUnit="px" />--%>
                        <FadeIn />
                    </Parallel>                                                                            
                </Sequence>  
            </OnLoad>
            <OnClick>
                <Sequence AnimationTarget="JavierBidezabal">              
                    <Parallel AnimationTarget="divAbout" Duration=".5" Fps="150">                                                    
                        <FadeOut/>
                    </Parallel>
                    <StyleAction AnimationTarget="divAbout" Attribute="display" Value="none"/>  
                    <StyleAction AnimationTarget="divPie" Attribute="display" Value="none"/>                 
                    <StyleAction AnimationTarget="JavierBidezabal" Attribute="display" Value="block"/>                                                                            
                    <Parallel AnimationTarget="JavierBidezabal" Duration=".5" Fps="150">                
                        <%--<Resize Width="1024" />    --%>                                                    
                        <FadeIn />
                    </Parallel>                                                                                            
                </Sequence>
            </OnClick>
        </Animations>        
    </asp:AnimationExtender>   

    <asp:AnimationExtender ID="AnimationExtender3" runat="server" TargetControlID="imgCerrar">        
        <Animations>
            <OnClick>
                <Sequence AnimationTarget="BorjaPakrolsky">
                    <Parallel AnimationTarget="BorjaPakrolsky" Duration=".7" Fps="150">
                        <%--<Move Horizontal="350" Vertical="-50"></Move>
                        <Scale ScaleFactor="0.05" FontUnit="px" />--%>
                        <FadeOut />
                    </Parallel>                
                    <StyleAction AnimationTarget="divAbout" Attribute="display" Value="block"/> 
                    <StyleAction AnimationTarget="divPie" Attribute="display" Value="block"/> 
                    <StyleAction AnimationTarget="BorjaPakrolsky" Attribute="display" Value="none"/> 
                    <Parallel AnimationTarget="divAbout" Duration=".5" Fps="150">                                                    
                       <%-- <Resize Width="1024" />--%>
                        <FadeIn/>
                    </Parallel>               
                </Sequence>
            </OnClick>
        </Animations>        
    </asp:AnimationExtender>

    <asp:AnimationExtender ID="AnimationExtender4" runat="server" TargetControlID="imgCerrar2">        
        <Animations>
            <OnClick>
                <Sequence AnimationTarget="JavierBidezabal">
                    <Parallel AnimationTarget="JavierBidezabal" Duration=".7" Fps="150">
                        <%--<Move Horizontal="350" Vertical="-50"></Move>
                        <Scale ScaleFactor="0.05" FontUnit="px" />--%>
                        <FadeOut />
                    </Parallel>                
                    <StyleAction AnimationTarget="divAbout" Attribute="display" Value="block"/> 
                    <StyleAction AnimationTarget="divPie" Attribute="display" Value="block"/> 
                    <StyleAction AnimationTarget="JavierBidezabal" Attribute="display" Value="none"/> 
                    <Parallel AnimationTarget="divAbout" Duration=".5" Fps="150">                                                    
                       <%-- <Resize Width="1024" />--%>
                        <FadeIn/>
                    </Parallel>               
                </Sequence>
            </OnClick>
        </Animations>        
    </asp:AnimationExtender>

    <asp:HiddenField ID="hdnDivAbout" runat="server" />
    <asp:AnimationExtender ID="AnimationExtender5" runat="server" TargetControlID="hdnDivAbout">
        <Animations>
            <OnLoad>
                <Sequence AnimationTarget="divAbout">              
                    <StyleAction AnimationTarget="divAbout" Attribute="display" Value="block"/>
                    <Parallel AnimationTarget="divAbout" Duration=".8" Fps="250">                
                        <%--<Resize Width="1024" />                                                        
                        <Scale ScaleFactor="0.05" FontUnit="px" />--%>
                        <FadeIn />
                    </Parallel>                                                                                     
                </Sequence>  
            </OnLoad>            
        </Animations>        
    </asp:AnimationExtender>
</form>

</asp:Content>

