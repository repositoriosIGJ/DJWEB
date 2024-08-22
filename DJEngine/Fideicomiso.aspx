<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DJ.Master" AutoEventWireup="true" CodeBehind="Fideicomiso.aspx.cs" Inherits="DJEngine.WebEntities.Fideicomiso" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register src="App_Controls/ucCaptcha.ascx" tagname="ucCaptcha" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MasterPage" runat="server">
        <asp:UpdatePanel ID="updpnlBuscadorEnt" runat="server">
        <ContentTemplate>
        <%-- Empieza Panel de Fideicomiso Constituido o No --%>
        <asp:Panel ID="pnlwfk_1" runat="server" Visible="true">
                <div class="DJCuadroHeader">
                    <asp:Image ID="ImgHeader_1" class="CuadroHeader" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroHeaderG.png" />
                    <asp:Label ID="LblTitulo_1" class="CuadroTitulo" runat="server" Width="700px">Indique si el Fideicomiso esta Inscripto en IGJ</asp:Label>
                    <br />
                </div>
                <div class="DJCuadroCentro">
                    <div class="DJCuadroConstituida">
                        <asp:RadioButtonList ID="rblConstituida" runat="server" AutoPostBack="True" 
                            OnSelectedIndexChanged="rblConstituida_SelectedIndexChanged"
                            RepeatDirection="Horizontal">
                            <asp:ListItem Text="Buscar Fideicomiso Inscripto" Value="1" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Ingresar Fideicomiso" Value="2"></asp:ListItem>                                                              
                        </asp:RadioButtonList>
                     </div>
                </div>
                <div class="DJCuadroFooter">
                    <asp:Image ID="ImgFooter_1" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroFooterG.png" />                    
                </div>
        </asp:Panel>        
        <%-- Termina Panel de Fideicomiso Constituido o No  --%>        
        <%-- Empieza Panel de Validacion --%>
        <asp:Panel ID="pnlvalidacion" runat="server" Visible="false">
            <div class="divValidacion">
                <div class="DJValidHeader">
                    <asp:Image ID="ImgHeader_val" class="CuadroHeader" runat="server" ImageUrl="~/App_Theme/Imagenes/DJValidHeader.png" />
                    <asp:Label ID="LblTitulo_val" class="CuadroTitulo" runat="server" Width="700px">Por favor resuelva los siguientes errores</asp:Label>
                </div>
                <div class="DJValidCentro">                     
                     <asp:ValidationSummary ID="vldsumEntidad" runat="server" Width="600px">
                     </asp:ValidationSummary>
                </div>				
                <div class="DJValidFooter">
                    <asp:Image ID="ImgFooter_val" runat="server" ImageUrl="~/App_Theme/Imagenes/DJValidFooter.png" />
                </div>
            </div>
        </asp:Panel>
        <%-- Termina Panel de Validacion --%>  
        <%-- Empieza Busqueda de Fideicomiso Constituido --%>
        <asp:Panel ID="pnlwfk_2" runat="server" BackImageUrl="/imagenes/" Visible="False">
                <div class="DJCuadroHeader">
                    <asp:Image ID="ImgHeader_2" class="CuadroHeader" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroHeaderG.png" />
                    <asp:Label ID="LblTitulo_2" class="CuadroTitulo" runat="server" Width="700px">B&uacute;squeda de Fideicomiso Inscripto por Nro Correlativo</asp:Label>
                    <br />
                </div>
                <div class="DJCuadroCentro">                    
                <%-- Empieza Busqueda de Fideicomiso --%>
                <table cellspacing="10px"> 
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblNroCorrelativo" runat="server" Width="180px">N&uacute;mero Correlativo</asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtNroCorrelativo" class="txtNroCorr txteffect" runat="server" MaxLength="12" Width="180px" Height="24px"></asp:TextBox>
                            <asp:CustomValidator ID="cvNroCorrelativo" runat="server" ErrorMessage="*"
                            ControlToValidate="txtNroCorrelativo" Display="Dynamic" EnableClientScript="False"
                            onservervalidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                            <asp:CustomValidator ID="cvNoExisteNroCorr" runat="server" ErrorMessage="El N&uacute;mero Correlativo no se corresponde a una Entidad existente"
                            Display="Dynamic" EnableClientScript="False" CssClass="imgCruz"></asp:CustomValidator>
                        </td>
                    </tr>
                    <div id="divTipoDeEntidadC" runat="server" visible="true"> 
                    <tr>                    
                        <td>
                            <asp:Label ID="lblTipoDeEntidadConstituida" runat="server" Width="180px">Tipo de Entidad</asp:Label>
                        </td>
                        <td>
                             <asp:DropDownList ID="ddlTipoDeEntidadConstituida" class="ddleffect" runat="server" AutoPostBack="True" 
                             DataTextField="Descripcion" DataValueField="Codigo" Enabled="false">
                             </asp:DropDownList>
                             <asp:CustomValidator ID="cvTipoDeEntidadConstituida" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" 
                             ControlToValidate="ddlTipoDeEntidadConstituida" Display="Dynamic" EnableClientScript="False" 
                             onservervalidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                             <br />
                        </td>
                     </tr>
                     </div>
                    <%-- Empieza Datos Referenciales del Fideicomiso --%>
                    <div id="divdatosentidad" runat="server" visible="false"> 
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblEntidadC" runat="server" Width="180px">Denominaci&oacute;n del Fideicomiso</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtEntidadC" runat="server" Width="300px" style="text-align: left;" class="txtreferencial" Enabled="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblTipoSocietario" runat="server" Width="180px">Tipo Societario</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtTipoSocietario" runat="server" Width="250px" style="text-align: left;" class="txtreferencial" Enabled="false"></asp:TextBox>
                            </td>
                         </tr>
                         <tr>
                             <td colspan="2" align="center">
                                <asp:ImageButton ID="btnBuscarNroCorrOtra" runat="server" class="btnBuscarNroCorr" ImageUrl="~/App_Theme/Imagenes/btnbuscarnueva.png" onclick="btnBuscarNroCorrOtra_Click" AutoPostBack="True"/>                
                             </td>
                         </tr>
                     </div>
                     </table>
                </div>
                <%-- Termina Datos Referenciales del Fideicomiso --%>
                <div id="divcaptchaentidad" runat="server" class="DJCuadroCentroCaptcha">
                    <%-- Empieza Captcha --%>
                    <uc1:ucCaptcha ID="ucCaptchaEntidad" runat="server" />                               
                    <%-- Termina Captcha --%>
                    <asp:ImageButton ID="btnBuscarNroCorr" runat="server" class="btnBuscarNroCorr" ImageUrl="~/App_Theme/Imagenes/btnBuscar.png" onclick="btnBuscarNroCorr_Click" AutoPostBack="True"/>
                    <br />
                    <br />
                    <asp:Label ID="lblBuscarRazonSoc" runat="server" class="lblBuscarRazonSoc"><B>NOTA:</B> Si no recuerda el n&uacute;mero correlativo puede utilizar la siguiente <a href="http://www2.jus.gov.ar/igj-ddjj/Default.aspx" target="_blank">B&uacute;squeda de Sociedades</a></asp:Label>
                </div>
                <div class="DJCuadroFooter">
                    <asp:Image ID="ImgFooter_2" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroFooterG.png" />                    
                </div>                
                <br />
        </asp:Panel>
        <%-- Termina Busqueda de Fideicomiso --%>
        <%-- Empieza Ingreso de Nuevo Fideicomiso --%>
        <asp:Panel ID="pnlwfk_3" runat="server">
                <div class="DJCuadroHeader">
                    <asp:Image ID="ImgHeader_3" class="CuadroHeader" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroHeaderG.png" />
                    <asp:Label ID="LblTitulo_3" class="CuadroTitulo" runat="server" Width="700px">Datos del Fideicomiso No Constituido</asp:Label>
                </div>
                <div class="DJCuadroCentro">                 
                        <table cellspacing="10px">
                            <tr>
                                <td>
                                    <asp:Label ID="lblEntidad" runat="server" Width="180px">Denominaci&oacute;n del Fideicomiso</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEntidad" class="txteffect" runat="server" Width="280px"></asp:TextBox>
                                    <asp:CustomValidator ID="cvEntidad" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" 
                                    ControlToValidate="txtEntidad" Display="Dynamic" EnableClientScript="False" 
                                    onservervalidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz" Enabled="false"></asp:CustomValidator>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblTipoDeEntidad" runat="server" Width="180px">Tipo de Entidad</asp:Label>
                                </td>
                                <td>
                                     <asp:DropDownList ID="ddlTipoDeEntidad" class="ddleffect" runat="server" AutoPostBack="True" 
                                     DataTextField="Descripcion" DataValueField="Codigo">
                                     </asp:DropDownList>
                                     <asp:CustomValidator ID="cvTipoDeEntidad" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" 
                                     ControlToValidate="ddlTipoDeEntidad" Display="Dynamic" EnableClientScript="False" 
                                     onservervalidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                                     <br />
                                </td>
                            </tr>
                        </table>
                        <br />
                </div>
                <div class="DJCuadroFooter">
                    <asp:Image ID="ImgFooter_3" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroFooterG.png" />                    
                </div>
            <br />
            </asp:Panel>
           <%-- Termina Ingreso de Nuevo Fideicomiso --%>
           <%-- Empieza Botones Workflow de Entidad No Constituida --%>
           <asp:Panel ID="pnlwfk_botones" runat="server"> 
                <div class="WorkFlowButtons">
                    <asp:ImageButton ID="btnVolver" runat="server" alt="" class="btnVolverEF" ImageUrl="~/App_Theme/Imagenes/btnvacio.png" onclick="btnVolver_Click" />
                    &nbsp;&nbsp;
                    <asp:ImageButton ID="btnContinuar" runat="server" alt="" class="btnContinuarEF" ImageUrl="~/App_Theme/Imagenes/btnvacio.png" onclick="btnContinuar_Click" />
                 </div>
            </asp:Panel>            
            <%-- Termina Botones Workflow de Entidad No Constituida --%>
            </ContentTemplate>
                    <Triggers>
                          <%--<asp:AsyncPostBackTrigger ControlID="btnBuscarNroCorrelativo" EventName="Click" />--%>
                          <asp:AsyncPostBackTrigger ControlID="btnBuscarNroCorr" EventName="Click" />
                          <asp:AsyncPostBackTrigger ControlID="btnBuscarNroCorrOtra" EventName="Click" />                          
                          <asp:AsyncPostBackTrigger ControlID="rblConstituida" EventName="SelectedIndexChanged" />
                          <asp:AsyncPostBackTrigger ControlID="rblConstituida" EventName="PreRender" />                          
                    </Triggers>
           </asp:UpdatePanel>
         <br />                                  
</asp:Content>

