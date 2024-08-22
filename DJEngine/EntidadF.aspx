<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DJ.Master" AutoEventWireup="true" CodeBehind="EntidadF.aspx.cs" Inherits="DJEngine.WebEntities.EntidadF" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register src="App_Controls/ucCaptcha.ascx" tagname="ucCaptcha" tagprefix="uc1" %>
<%@ Register src="App_Controls/ucDomicilioReal.ascx" tagname="ucDomicilioReal" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MasterPage" runat="server">
        <asp:UpdatePanel ID="updpnlBuscadorEnt" runat="server">
        <ContentTemplate>
            <%-- Empieza Datos Referenciales --%>
            <asp:Panel ID="pnlwfk_0" runat="server">
                <div class="DJCuadroHeader">
                      <asp:Label ID="LblTitulo_0" class="CuadroTituloSinBack" runat="server" Width="625px">Datos del Fideicomiso</asp:Label>
                </div>
                <div class="DJCuadroReferen">
                    <table cellspacing="10px">
                        <tr>
                            <td>
                                <asp:Label ID="lblNroCorrelativoRef" runat="server" Width="180px">Número Correlativo</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtNroCorrelativoRef" runat="server" style="text-align: left;" class="txtreferencial" Enabled="false" Width="140px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblEntidadRef" runat="server" Width="180px">Denominaci&oacute;n del Fideicomiso</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEntidadRef" runat="server" style="text-align: left;" class="txtreferencial" Enabled="false" Width="320px" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblTipoSocietarioRef" runat="server" Width="180px">Tipo Societario</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTipoSocietarioRef" runat="server" style="text-align: left;" class="txtreferencial" Enabled="false" Width="320px"></asp:TextBox>
                            </td>
                         </tr>
                     </table>
                 </div>                   
            </asp:Panel>
            <%-- Termina  Datos Referenciales --%> 
        <%-- Empieza Panel de Entidad Constituida o No --%>
        <asp:Panel ID="pnlwfk_1" runat="server" Visible="true">
                <div class="DJCuadroHeader">
                    <asp:Image ID="ImgHeader_1" class="CuadroHeader" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroHeaderG.png" />
                    <asp:Label ID="LblTitulo_1" class="CuadroTitulo" runat="server" Width="700px">Indique si la Entidad esta Constituida en IGJ</asp:Label>
                    <br />
                </div>
                <div class="DJCuadroCentro">
                    <div class="DJCuadroConstituida" style="font-size=12px">
                        <asp:RadioButtonList ID="rblConstituida" runat="server" AutoPostBack="True" 
                            OnSelectedIndexChanged="rblConstituida_SelectedIndexChanged" 
                            RepeatDirection="Horizontal">
                            <asp:ListItem Text="Buscar Entidad Constituida en IGJ" Value="1" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Ingresar Entidad Constituida en Otra Jurisdicción" Value="2"></asp:ListItem>                                                              
                        </asp:RadioButtonList>
                     </div>
                </div>
                <div class="DJCuadroFooter">
                    <asp:Image ID="ImgFooter_1" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroFooterG.png" />                    
                </div>
        </asp:Panel>        
        <%-- Termina Panel de Entidad Constituida o No  --%>        
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
        <%-- Empieza Busqueda de Entidad Constituida --%>
        <asp:Panel ID="pnlwfk_2" runat="server" BackImageUrl="/imagenes/" Visible="False">
                <div class="DJCuadroHeader">
                    <asp:Image ID="ImgHeader_2" class="CuadroHeader" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroHeaderG.png" />
                    <asp:Label ID="LblTitulo_2" class="CuadroTitulo" runat="server" Width="700px">B&uacute;squeda de Entidad Constituida por N&uacute;mero Correlativo</asp:Label>
                    <br />
                </div>
                <div class="DJCuadroCentro">
                <table cellspacing="10px">
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblNroCorrelativo" runat="server" Width="210">N&uacute;mero Correlativo</asp:Label>
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
                            <asp:Label ID="lblTipoDeEntidadConstituida" runat="server" Width="210">Tipo de Entidad</asp:Label>
                        </td>
                        <td>
                             <asp:DropDownList ID="ddlTipoDeEntidadConstituida" class="ddleffect" runat="server" AutoPostBack="True" 
                             DataTextField="Descripcion" DataValueField="Codigo">
                             </asp:DropDownList>
                             <asp:CustomValidator ID="cvTipoDeEntidadConstituida" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" 
                             ControlToValidate="ddlTipoDeEntidadConstituida" Display="Dynamic" EnableClientScript="False" 
                             onservervalidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                             <br />
                        </td>
                     </tr>
                     <uc2:ucDomicilioReal ID="ucDomicilioRealC" runat="server" />
                     <%--<tr>
                        <td>
                            <asp:Label ID="lblSedeSocial" runat="server" Width="180px">Sede Social</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtSedeSocial" class="txteffect" runat="server" Width="280px"></asp:TextBox>
                            <asp:CustomValidator ID="cvSedeSocial" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" 
                            ControlToValidate="txtSedeSocial" Display="Dynamic" EnableClientScript="False" 
                            onservervalidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                            <br />
                        </td>
                     </tr>--%>
                     </div>
                    <%--<div ID="DivCuadroNroCorrelativoError" runat="server" class="CuadroCaptchaError" Visible="false">
                        <asp:Label ID="lblNroCorrelativoError" runat="server" class="lblCaptchaError" Text="&nbsp;El N&uacute;mero Correlativo no se corresponde a una Entidad existe&nbsp;" />                   
                    </div>--%>
                    <%-- Empieza Datos Referenciales de la Entidad --%>
                    <div id="divdatosentidad" runat="server" visible="false"> 
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblEntidadC" runat="server" Width="180px">Denominaci&oacute;n de la Entidad</asp:Label>
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
                            <td align="right">
                                <asp:Label ID="lblSedeSocialDato" runat="server" Width="180px">Sede Social</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtSedeSocialDato" runat="server" Width="350px" style="text-align: left;" class="txtreferencial" Enabled="false"></asp:TextBox>                                
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
                <%-- Termina Datos Referenciales de la Entidad --%>
                <div id="divcaptchaentidad" runat="server" class="DJCuadroCentroCaptcha">
                    <%-- Empieza Captcha --%>
                    <uc1:ucCaptcha ID="ucCaptchaEntidad" runat="server" />                               
                    <%-- Termina Captcha --%>
                    <asp:ImageButton ID="btnBuscarNroCorr" runat="server" class="btnBuscarNroCorr" ImageUrl="~/App_Theme/Imagenes/btnBuscar.png" onclick="btnBuscarNroCorr_Click" AutoPostBack="True"/>
                    <br />
                    <br />
                    <asp:Label ID="lblBuscarRazonSoc" runat="server" class="lblBuscarRazonSoc"><B>NOTA:</B> Si no recuerda el n&uacute;mero correlativo puede utilizar la siguiente <a href="http://www2.jus.gov.ar/igj-vistas/Busqueda.aspx" target="_blank">B&uacute;squeda de Sociedades</a></asp:Label>
                </div>
            <%--<div class="DJCuadroCentro">
                <br />
                <asp:Label ID="lblBuscRazonSoc" runat="server" style="margin-left:-40px;" Width="500px" Font-Size="10px">Si no recuerda el n&uacute;mero correlativo puede utilizar la siguiente <a href="http://www2.jus.gov.ar/igj-vistas/Busqueda.aspx" target="_blank">B&uacute;squeda de Sociedades</a></asp:Label>
                </div>--%>
                <div class="DJCuadroFooter">
                    <asp:Image ID="ImgFooter_2" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroFooterG.png" />                    
                </div>                
                <br />
        </asp:Panel>
        <%-- Termina Busqueda de Entidad Constituida --%>
        <%-- Empieza Ingreso de Entidad No Constituida --%>
        <asp:Panel ID="pnlwfk_3" runat="server">
                <div class="DJCuadroHeader">
                    <asp:Image ID="ImgHeader_3" class="CuadroHeader" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroHeaderG.png" />
                    <asp:Label ID="LblTitulo_3" class="CuadroTitulo" runat="server" Width="700px">Datos de la Entidad Constituida en Otra Jurisdici&oacute;n</asp:Label>
                </div>
                <div class="DJCuadroCentro">                 
                        <table cellspacing="10px">
                            <tr>
                                <td>
                                    <asp:Label ID="lblEntidad" runat="server" Width="210px">Denominaci&oacute;n de la Entidad</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEntidad" class="txteffect" runat="server" Width="280px"></asp:TextBox>
                                    <asp:CustomValidator ID="cvEntidad" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" 
                                    ControlToValidate="txtEntidad" Display="Dynamic" EnableClientScript="False" 
                                    onservervalidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblTipoDeEntidad" runat="server" Width="210px">Tipo de Entidad</asp:Label>
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
                            <uc2:ucDomicilioReal ID="ucDomicilioRealOJ" runat="server" />
                            <%--<tr>
                                <td>
                                    <asp:Label ID="lblSedeSocialOJ" runat="server" Width="180px">Sede Social</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSedeSocialOJ" class="txteffect" runat="server" Width="280px"></asp:TextBox>
                                    <asp:CustomValidator ID="cvSedeSocialOJ" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" 
                                    ControlToValidate="txtSedeSocialOJ" Display="Dynamic" EnableClientScript="False" 
                                    onservervalidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                                    <br />
                                </td>
                            </tr>--%>
                        </table>
                        <br />
                </div>
                <div class="DJCuadroFooter">
                    <asp:Image ID="ImgFooter_3" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroFooterG.png" />                    
                </div>
            <br />
            </asp:Panel>
           <%-- Termina Ingreso de Entidad No Constituida --%>
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
                    </Triggers>
           </asp:UpdatePanel>
         <br />                                  
</asp:Content>

