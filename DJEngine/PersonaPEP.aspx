<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DJ.Master" AutoEventWireup="true" CodeBehind="PersonaPEP.aspx.cs" Inherits="DJEngine.WebEntities.PersonaPEP" %>
<%@ Register src="App_Controls/ucDocumento.ascx" tagname="ucDocumento" tagprefix="uc1" %>
<%@ Register src="App_Controls/ucCaptcha.ascx" tagname="ucCaptcha" tagprefix="uc2" %>
<%@ Register src="App_Controls/ucFiscal.ascx" tagname="ucFiscal" tagprefix="uc3" %>
<%@ Register src="App_Controls/ucCategoriaPEP.ascx" tagname="ucCategoriaPEP" tagprefix="uc4" %>
<%@ Register src="App_Controls/ucDomicilio.ascx" tagname="ucDomicilio" tagprefix="uc5" %>
<%@ Register src="App_Controls/ucCargo.ascx" tagname="ucCargo" tagprefix="uc6" %>
<%@ Register src="App_Controls/ucDomicilioReal.ascx" tagname="ucDomicilioReal" tagprefix="uc7" %>
<%@ Register src="App_Controls/ucVinculoPEP.ascx" tagname="ucVinculoPEP" tagprefix="uc8" %>
<%@ Register Src="App_Controls/ucEstadoCivil.ascx" TagName="ucEstadoCivil" TagPrefix="uc3" %>
<%@ Register Src="App_Controls/ucEmail.ascx" TagName="ucEmail" TagPrefix="uc7" %>
<%@ Register Src="App_Controls/ucFechaNac.ascx" TagName="ucFechaNac" TagPrefix="uc10" %>
<%@ Register Src="App_Controls/ucNacionalidad.ascx" TagName="ucNacionalidad" TagPrefix="uc9" %>
<%@ Register Src="App_Controls/ucProfesion.ascx" TagName="ucProfesion" TagPrefix="uc11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MasterPage" runat="server">
            <%-- Empieza Panel de datos de Referencia --%>
            <asp:Panel ID="pnlwfk_1" runat="server">
                <div class="DJCuadroHeader">
                      <asp:Label ID="LblTitulo_1" class="CuadroTituloSinBack" runat="server" Width="625px">Datos de la Entidad</asp:Label>
                </div>
                <div class="DJCuadroReferen">
                    <table cellspacing="10px">
                        <tr>
                            <td>
                                <asp:Label ID="lblNroCorrelativo" runat="server" Width="180px">Número Correlativo</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtNroCorrelativo" runat="server" style="text-align: left;" class="txtreferencial" Enabled="false" Width="140px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblEntidad" runat="server" Width="180px">Denominaci&oacute;n de la Entidad</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEntidad" runat="server" style="text-align: left;" class="txtreferencial" Enabled="false" Width="320px" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblTipoSocietario" runat="server" Width="180px">Tipo Societario</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTipoSocietario" runat="server" style="text-align: left;" class="txtreferencial" Enabled="false" Width="320px"></asp:TextBox>
                            </td>
                         </tr>
                     </table>
                 </div>                   
            </asp:Panel>
            <%-- Termina Panel de datos de Referencia --%>    
            <%-- Empieza RadioButtonList PEP e Incisos --%> 
            <asp:Panel ID="pnlrlb_PEP_Incisos" runat="server">    
                    <div class="DJCuadroHeader">
                        <asp:Image ID="ImgHeader_1" class="CuadroHeader" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroHeaderG.png" />
                        <asp:Label ID="lblHeader_1" class="CuadroTitulo" runat="server" Width="700px">Indique si usted es una Persona Expuesta Pol&iacute;ticamente</asp:Label>
                        <br />
                    </div>
                    <div class="DJCuadroCentro">                   
                        <div class="DJCuadroPEPoF">
                            <asp:RadioButtonList ID="rblPEPoNO" runat="server" AutoPostBack="True" 
                                OnSelectedIndexChanged="rblPEPoNO_SelectedIndexChanged" 
                                RepeatDirection="Horizontal">
                                <asp:ListItem Text="SI" Value="1" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="NO" Value="2"></asp:ListItem>                                                              
                            </asp:RadioButtonList>
                            <div id="divIncisos" runat="server">
                                <br />
                                <asp:Label ID="lblHeader_1b" class="CuadroTituloIntermedio" runat="server" Width="700px">Indique si es persona politicamente expuesto por parentesco o cercania</asp:Label>
                                <asp:RadioButtonList ID="rblIncisos" runat="server" AutoPostBack="True" 
                                    OnSelectedIndexChanged="rblIncisos_SelectedIndexChanged" 
                                    RepeatDirection="Horizontal">                                
                                    <asp:ListItem Text="No Incluido" Value="0" Selected="True"></asp:ListItem>
                                    <%--<asp:ListItem Text="Inciso F" Value="1"></asp:ListItem>--%>
                                    <asp:ListItem Text="Por parentesco" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Por cercania" Value="3"></asp:ListItem>                                    
                                </asp:RadioButtonList>
                            </div>
                         </div>
                    </div>
                    <div class="DJCuadroFooter">
                        <asp:Image ID="ImgFooter_1" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroFooterG.png" />                    
                    </div>
            <br />
            </asp:Panel>
            <%-- Termina RadioButtonList PEP e Incisos --%>            
            <%-- Empieza Panel de Validacion --%>
            <asp:Panel ID="pnlvalidacion" runat="server" Visible="false">
                <div class="divValidacion">
                    <div class="DJValidHeader">
                        <asp:Image ID="ImgHeader_val" class="CuadroHeader" runat="server" ImageUrl="~/App_Theme/Imagenes/DJValidHeader.png" />
                        <asp:Label ID="LblTitulo_val" class="CuadroTitulo" runat="server" Width="700px">Por favor resuelva los siguientes errores</asp:Label>
                    </div>
                    <div class="DJValidCentro">                     
                         <asp:ValidationSummary ID="vldsumEntidad" runat="server" Width="650px"/></asp:ValidationSummary>                         
                    </div>				
                    <div class="DJValidFooter">
                        <asp:Image ID="ImgFooter_val" runat="server" ImageUrl="~/App_Theme/Imagenes/DJValidFooter.png" />
                    </div>
                </div>
            <br />    
            </asp:Panel>
            <%-- Termina Panel de Validacion --%>
            <%-- Empieza Formulario PPR --%> 
            <asp:Panel ID="pnlwfk_PPR" runat="server" Visible="false" Enabled="false">    
                <div class="DJCuadroHeader">
                    <asp:Image ID="ImgHeader_PPR" class="CuadroHeader" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroHeaderG.png" />
                    <asp:Label ID="LblTitulo_PPR" class="CuadroTitulo" runat="server" Width="700px">Datos de la Persona Declarante</asp:Label>
                </div>                
                <div class="DJCuadroCentro">                   
                    <div class="DJCuadroPresen">
                        <asp:UpdatePanel ID="updpnlwfk_PPR" runat="server">
                        <ContentTemplate>
                        <table cellspacing="10px">
                            <tr>
                                <td>
                                    <asp:Label ID="lblNombrePPR" runat="server" Width="210px">Nombre</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNombrePPR" class="txteffect" runat="server" Width="150px"></asp:TextBox>
                                    <asp:CustomValidator ID="cvNombrePPR" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" 
                                    ControlToValidate="txtNombrePPR" Display="Dynamic" EnableClientScript="False" 
                                    onservervalidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                                    <br />
                                </td>
                            </tr>                         
                            <tr>
                                <td>
                                    <asp:Label ID="lblApellidoPPR" runat="server" Width="210px">Apellido</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtApellidoPPR" class="txteffect" runat="server" Width="170px"></asp:TextBox>
                                    <asp:CustomValidator ID="cvApellidoPPR" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" 
                                    ControlToValidate="txtApellidoPPR" Display="Dynamic" EnableClientScript="False" 
                                    onservervalidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                                    <br />
                                </td>
                            </tr>                            
                            <uc1:ucDocumento ID="ucDocumentoPPR" runat="server" />
                            
                          
                            <uc3:ucFiscal ID="ucFiscalPPR" runat="server" />
                            <!--Combo "Inciso Resolución 11/2011"-->
                            <uc4:ucCategoriaPEP ID="ucCategoriaPPR" runat="server" />
                            <uc6:ucCargo ID="ucCargoPPR" runat="server" />
                            <uc7:ucDomicilioReal ID="ucDomicilioRealPPR" runat="server" />
                            
                            
                            <%--<uc5:ucDomicilio ID="ucDomicilioPPR" runat="server" />--%>
                            <tr ID="trRelacionPPRPEP" runat="server">
                                <td>
                                    <asp:Label ID="lblRelacionPPRPEP" runat="server">Relaci&oacute;n con la Persona Expuesta</asp:Label>
                                </td>
                                <td> 
                                <%--Agrego el APPCONTROL ucVinculoPEP --%>
                                 <uc8:ucVinculoPEP ID="ucVinculoPEP" runat="server" />
                                <%--<asp:TextBox ID="txtRelacionPPRPEP" class="txteffect" runat="server" Width="170px" Enabled="false"></asp:TextBox> 
                                    <asp:CustomValidator ID="cvRelacionPPRPEP" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" 
                                    ControlToValidate="txtRelacionPPRPEP" Display="Dynamic" EnableClientScript="False" 
                                    onservervalidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz" Visible="false" Enabled="false"></asp:CustomValidator> --%>
                                                                       
                                    <br />
                                </td> 
                            </tr>                             
                        </table>
                        </ContentTemplate>
                        </asp:UpdatePanel>
                        <br />
                    </div>                    
                </div>
                <div class="DJCuadroFooter">
                    <asp:Image ID="ImgFooter_PPR" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroFooterFiscal.png" />                    
                </div>
                
            <br />
            </asp:Panel>
            <%-- Termina Formulario PPR --%>
            <%-- Empieza Formulario PEP --%>                             
            <asp:Panel ID="pnlwfk_PEP" runat="server">    
                <div class="DJCuadroHeader">
                    <asp:Image ID="ImgHeader_PEP" class="CuadroHeader" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroHeaderG.png" />
                    <asp:Label ID="LblTitulo_PEP" class="CuadroTitulo" runat="server" Width="700px">Datos de la Persona Expuesta Pol&iacute;ticamente</asp:Label>
                </div>
                <div class="DJCuadroCentro">                   
                        <asp:UpdatePanel ID="updpnlwfk_PEP" runat="server">
                        <ContentTemplate>
                        <table cellspacing="10px">
                            <tr>
                                <td>                                    
                                    <asp:Label ID="lblNombrePEP" runat="server" Width="210px">Nombre</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNombrePEP" class="txteffect" runat="server" Width="150px"></asp:TextBox>
                                    <asp:CustomValidator ID="cvNombrePEP" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" 
                                    ControlToValidate="txtNombrePEP" Display="Dynamic" EnableClientScript="False" 
                                    onservervalidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblApellidoPEP" runat="server" Width="210px">Apellido</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtApellidoPEP" class="txteffect" runat="server" Width="170px"></asp:TextBox>
                                    <asp:CustomValidator ID="cvApellidoPEP" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" 
                                    ControlToValidate="txtApellidoPEP" Display="Dynamic" EnableClientScript="False" 
                                    onservervalidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                                    <br />
                                </td>
                            </tr>
                            <uc1:ucDocumento ID="ucDocumentoPEP" runat="server" />
                            
                            
                            
                                       
                                    <uc10:ucFechaNac ID="ucFechaNac1" runat="server" />
                                    <uc3:ucEstadoCivil ID="ucEstadoCivil" runat="server" />
                                    <uc7:ucEmail ID="ucEmail" runat="server" />
                                    <uc9:ucNacionalidad ID="ucNacionalidad" runat="server" />
                                    <uc11:ucProfesion ID="ucProfesion" runat="server" />
                                  
                            
                            
                            
                            <uc3:ucFiscal ID="ucFiscalPEP" runat="server" />
                            <!--Combo "Inciso Resolución 11/2011"-->
                            <uc4:ucCategoriaPEP ID="ucCategoriaPEP" runat="server" />
                            <uc6:ucCargo ID="ucCargoPEP" runat="server" />
                            <uc7:ucDomicilioReal ID="ucDomicilioRealPEP" runat="server" />
                            <%--<uc5:ucDomicilio ID="ucDomicilioPEP" runat="server" />--%>
                        </table>
                        </ContentTemplate>
                        </asp:UpdatePanel>
                        <br />                  
                </div>
                <div class="DJCuadroFooter">
                    <asp:Image ID="ImgFooter_PEP" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroFooterFiscal.png" />                    
                </div>
            <br />
            </asp:Panel>
            <%-- Termina Formulario PEP --%>
			<%-- Empieza Captcha --%>
			<uc2:ucCaptcha ID="ucCaptchaPersona" runat="server" />
			<%-- Termina Captcha --%>
            <%-- Empieza Botones Workflow --%>
            <asp:Panel ID="pnlwfk_botones" runat="server"> 
                <div class="WorkFlowButtons">
                    <asp:ImageButton ID="btnVolver" runat="server" alt="" class="btnVolverEF" ImageUrl="~/App_Theme/Imagenes/btnvacio.png" onclick="btnVolver_Click" />
                    &nbsp;&nbsp;
                    <asp:ImageButton ID="btnConfirmar" runat="server" alt="" class="btnConfirmarEF" ImageUrl="~/App_Theme/Imagenes/btnvacio.png" onclick="btnConfirmar_Click" />
                </div>
            </asp:Panel>
            <%-- Termina Botones Workflow --%>        
       <br/>   
</asp:Content>
