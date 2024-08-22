<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DJ.Master" AutoEventWireup="true" CodeBehind="Persona.aspx.cs" Inherits="DJEngine.WebEntities.Persona" %>
<%@ Register src="App_Controls/ucDocumento.ascx" tagname="ucDocumento" tagprefix="uc1" %>
<%@ Register src="App_Controls/ucCaptcha.ascx" tagname="ucCaptcha" tagprefix="uc2" %>
<%@ Register src="App_Controls/ucFiscal.ascx" tagname="ucFiscal" tagprefix="uc3" %>
<%@ Register src="App_Controls/ucCategoriaPEP.ascx" tagname="ucCategoriaPEP" tagprefix="uc4" %>
<%@ Register src="App_Controls/ucDomicilio.ascx" tagname="ucDomicilio" tagprefix="uc5" %>
<%@ Register src="App_Controls/ucVinculoPEP.ascx" tagname="ucVinculoPEP" tagprefix="uc8" %>
<%@ Register Src="App_Controls/ucEstadoCivil.ascx" TagName="ucEstadoCivil" TagPrefix="uc3" %>
<%@ Register Src="App_Controls/ucEmail.ascx" TagName="ucEmail" TagPrefix="uc7" %>
<%@ Register Src="App_Controls/ucFechaNac.ascx" TagName="ucFechaNac" TagPrefix="uc10" %>
<%@ Register Src="App_Controls/ucNacionalidad.ascx" TagName="ucNacionalidad" TagPrefix="uc9" %>
<%@ Register Src="App_Controls/ucProfesion.ascx" TagName="ucProfesion" TagPrefix="uc11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MasterPage" runat="server">
            <%-- Empieza Formulario PEP --%>
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
            <%-- Termina Formulario PEP --%>            
            <%-- Empieza Formulario PEP Incisos --%> 
            <asp:Panel ID="pnlPEP" runat="server">    
                    <div class="DJCuadroHeader">
                        <asp:Image ID="ImgHeader_1" class="CuadroHeader" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroHeaderG.png" />
                        <asp:Label ID="lblHeader_1" class="CuadroTitulo" runat="server" Width="700px">Indique si usted es una Persona  </asp:Label>
                        <br />
                    </div>
                    <div class="DJCuadroCentro">                   
                        <div class="DJCuadroPEPoF">
                            <asp:RadioButtonList ID="rblPEPoF" runat="server" AutoPostBack="True" 
                                OnSelectedIndexChanged="rblPEPoF_SelectedIndexChanged" 
                                RepeatDirection="Horizontal">
                                <asp:ListItem Text="SI" Value="1" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="NO" Value="2"></asp:ListItem>                                                              
                            </asp:RadioButtonList>
                             <div id="RelacionadoPEP" runat="server">
                                <br />
                                <asp:Label ID="lblHeader_1b" class="CuadroTituloIntermedio" runat="server" Width="700px"> Indique si es Persona Expuesta Politicamente por parentesco o cercania </asp:Label>
                                <asp:RadioButtonList ID="rblRelacionadoPEP" runat="server" AutoPostBack="True" 
                                    OnSelectedIndexChanged="rblRelacionadoPEP_SelectedIndexChanged" 
                                    RepeatDirection="Horizontal">                                
                                  <asp:ListItem Text="No Incluido" Value="0" Selected="True"></asp:ListItem>
                                    <%--<asp:ListItem Text="Inciso F" Value="1"></asp:ListItem>--%>
                                    <asp:ListItem Text="Parentesco" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Cercania" Value="3"></asp:ListItem>                                    
                                </asp:RadioButtonList>
                            </div>
                         </div>
                    </div>
                    <div class="DJCuadroFooter">
                        <asp:Image ID="ImgFooter_1" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroFooterG.png" />                    
                    </div>
            <br />
            </asp:Panel>
            <%-- Termina Formulario PEP Incisos --%>            
            <%-- Empieza Captcha --%>
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
            <%-- Termina Captcha --%>            
            <%-- Empieza Botones Workflow --%>                             
            <asp:Panel ID="pnlwfk_2" runat="server">    
                <div class="DJCuadroHeader">
                    <asp:Image ID="ImgHeader_2" class="CuadroHeader" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroHeaderG.png" />
                    <asp:Label ID="LblTitulo_2" class="CuadroTitulo" runat="server" Width="700px">Datos de la Persona Expuesta Pol&iacute;ticamente</asp:Label>
                </div>
                <div class="DJCuadroCentro">                   
                        <asp:UpdatePanel ID="updpnlwfk_2" runat="server">
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
                            <uc4:ucCategoriaPEP ID="ucCategoriaPEP" runat="server" />                            
                            <tr>
                                <td>
                                    <asp:Label ID="lblCargoPEP" runat="server" Width="210px">Cargo en la Entidad</asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlCargoPEP" class="ddleffect" runat="server" Width="280px" DataTextField="Descripcion" DataValueField="Codigo" AutoPostBack="False"></asp:DropDownList>
                                    <asp:CustomValidator ID="cvCargoPEP" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" 
                                    ControlToValidate="ddlCargoPEP" Display="Dynamic" EnableClientScript="False" 
                                    onservervalidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator> 
                                   <!-- <asp:TextBox ID="txtCargoPEP" class="txteffect" runat="server" Width="170px"></asp:TextBox>--> 
                                   
                                    <br />
                                </td>
                            </tr>
                             
                                
                              
                                    
                                    <uc10:ucFechaNac ID="ucFechaNac1" runat="server" />
                                    <uc3:ucEstadoCivil ID="ucEstadoCivil" runat="server" />
                                    <uc7:ucEmail ID="ucEmail" runat="server" />
                                    <uc9:ucNacionalidad ID="ucNacionalidad" runat="server" />
                                    <uc11:ucProfesion ID="ucProfesion" runat="server" />
             
                                 
            
                            <uc5:ucDomicilio ID="ucDomicilioPEP" runat="server" />
                            <uc3:ucFiscal ID="ucFiscalPEP" runat="server" />
                            
                             <uc8:ucVinculoPEP ID="ucVinculoPEP" runat="server" />    
                         
                        </table>
                        </ContentTemplate>
                        </asp:UpdatePanel>
                        <br />                  
                </div>
                <div class="DJCuadroFooter">
                    <asp:Image ID="ImgFooter_2" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroFooterFiscal.png" />                    
                </div>
            <br />
            </asp:Panel>
            <%-- Termina Botones Workflow --%>
            <%-- Empieza Formulario PEP Incisos --%> 
            <asp:Panel ID="pnlwfk_3" runat="server" Visible="false" Enabled="false">    
                <div class="DJCuadroHeader">
                    <asp:Image ID="ImgHeader_3" class="CuadroHeader" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroHeaderG.png" />
                    <asp:Label ID="LblTitulo_3" class="CuadroTitulo" runat="server" Width="700px">Datos de la Persona Expuesta Pol&iacute;ticamente</asp:Label>
                </div>                
                <div class="DJCuadroCentro">                   
                    <div class="DJCuadroPresen">
                        <asp:UpdatePanel ID="updpnlwfk_3" runat="server">
                        <ContentTemplate>
                        <table cellspacing="10px">
                            <tr>
                                <td>
                                    <asp:Label ID="lblNombrePEPR" runat="server" Width="210px">Nombre</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNombrePEPR" class="txteffect" runat="server" Width="150px"></asp:TextBox>
                                    <asp:CustomValidator ID="cvNombrePEPR" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" 
                                    ControlToValidate="txtNombrePEPR" Display="Dynamic" EnableClientScript="False" 
                                    onservervalidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                                    <br />
                                </td>
                            </tr>                         
                            <tr>
                                <td>
                                    <asp:Label ID="lblApellidoPEPR" runat="server" Width="210px">Apellido</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtApellidoPEPR" class="txteffect" runat="server" Width="170px"></asp:TextBox>
                                    <asp:CustomValidator ID="cvApellidoPEPR" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" 
                                    ControlToValidate="txtApellidoPEPR" Display="Dynamic" EnableClientScript="False" 
                                    onservervalidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                                    <br />
                                </td>
                            </tr>                            
                            <uc1:ucDocumento ID="ucDocumentoPEPR" runat="server" />
                            
                             <uc10:ucFechaNac ID="ucFechaNac2" runat="server" />
                             <uc9:ucNacionalidad ID="ucNacionalidad1" runat="server" />
                             <uc7:ucEmail ID="ucEmail1" runat="server" />
                             <uc11:ucProfesion ID="ucProfesion1" runat="server" />
                            
                            <uc4:ucCategoriaPEP ID="ucCategoriaPEPR" runat="server" />                            
                            <uc3:ucFiscal ID="ucFiscalPEPR" runat="server" /> 
                        </table>
                        </ContentTemplate>
                        </asp:UpdatePanel>
                        <br />
                    </div>                    
                </div>
                <div class="DJCuadroFooter">
                    <asp:Image ID="ImgFooter_3" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroFooterFiscal.png" />                    
                </div>
                
            <br />
            </asp:Panel>
            <%-- Termina Formulario PEP Incisos --%>             
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
