<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DJ.Master" AutoEventWireup="true" CodeBehind="Auditor.aspx.cs" Inherits="DJEngine.WebEntities.Auditor" %>
<%@ Register src="App_Controls/ucFiscal.ascx" tagname="ucFiscal" tagprefix="uc1" %>
<%@ Register src="App_Controls/ucDocumento.ascx" tagname="ucDocumento" tagprefix="uc2" %>
<%@ Register src="App_Controls/ucFecha.ascx" tagname="ucFecha" tagprefix="uc3" %>
<%@ Register src="App_Controls/ucDictamen.ascx" tagname="ucDictamen" tagprefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MasterPage" runat="server">
            <%-- Empieza Panel de Datos Referenciales --%>              
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
            <%-- Termina Panel de Datos Referenciales --%>
            <%-- Empieza Panel de Validacion --%>
            <asp:Panel ID="pnlvalidacion" runat="server" Visible="false">
                <div class="divValidacion">
                    <div class="DJValidHeader">
                        <asp:Image ID="ImgHeader_val" class="CuadroHeader" runat="server" ImageUrl="~/App_Theme/Imagenes/DJValidHeader.png" />
                        <asp:Label ID="LblTitulo_val" class="CuadroTitulo" runat="server" Width="700px">Por favor resuelva los siguientes errores</asp:Label>
                    </div>
                    <div class="DJValidCentro">                     
                         <asp:ValidationSummary ID="vldsumRepresentante" runat="server" Width="650px"/></asp:ValidationSummary>
                         <asp:Label ID="lblCaptchaErrorvld" class="CuadroTitulo" runat="server" Width="700px" Visible="false">&#8226; [CODIGO DE VALIDACION] El texto ingresado es incorrecto, por favor vuelva a intentarlo nuevamente.</asp:Label>
                    </div>				
                    <div class="DJValidFooter">
                        <asp:Image ID="ImgFooter_val" runat="server" ImageUrl="~/App_Theme/Imagenes/DJValidFooter.png" />
                    </div>
                </div>
            <br />    
            </asp:Panel>            
            <%-- Termina Panel de Validacion --%>
            <%-- Empieza Formulario Representante --%>                      
            <asp:Panel ID="pnlwfk_2" runat="server">
                <div class="DJCuadroHeader">
                    <asp:Image ID="ImgHeader_2" class="CuadroHeader" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroHeaderG.png" />
                    <asp:Label ID="LblTitulo_2" class="CuadroTitulo" runat="server" Width="700px">Datos del Auditor Externo</asp:Label>
                </div>
                <div class="DJCuadroCentro">                   
                    <%--<div class="DJCuadroPresen">--%>
                        <table cellspacing="10px">
                            <tr>
                                <td>
                                    <asp:Label ID="lblNombreAUD" runat="server" Width="210px">Nombre</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNombreAUD" class="txteffect" runat="server" Width="150px"></asp:TextBox>
                                    <asp:CustomValidator ID="cvNombreAUD" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" 
                                    ControlToValidate="txtNombreAUD" Display="Dynamic" EnableClientScript="False" 
                                    onservervalidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblApellidoAUD" runat="server" Width="210px">Apellido</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtApellidoAUD" class="txteffect" runat="server" Width="170px"></asp:TextBox>
                                    <asp:CustomValidator ID="cvApellidoAUD" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" 
                                    ControlToValidate="txtApellidoAUD" Display="Dynamic" EnableClientScript="False" 
                                    onservervalidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                                    <br />
                                </td>
                            </tr>                        
                            <uc2:ucDocumento ID="ucDocumentoAUD" runat="server" />
                            <uc1:ucFiscal ID="ucFiscalAUD" runat="server" />
                            <uc3:ucFecha ID="ucFechaAUD" runat="server" />
                            <tr>
                                <td>
                                    <asp:Label ID="lblTomoAUD" runat="server" Width="210px">Tomo</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox class="txteffect" ID="txtTomoAUD" runat="server" Width="95px"></asp:TextBox>
                                    <asp:CustomValidator ID="cvTomoAUD" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" 
                                    ControlToValidate="txtTomoAUD" Display="Dynamic" EnableClientScript="False" 
                                    onservervalidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>                                    
                                    <asp:Label ID="lblFolioAUD" runat="server" Width="210px">Folio</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox class="txteffect" ID="txtFolioAUD" runat="server" Width="92px"></asp:TextBox>
                                    <asp:CustomValidator ID="cvFolioAUD" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" 
                                    ControlToValidate="txtFolioAUD" Display="Dynamic" EnableClientScript="False" 
                                    onservervalidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                                    <br />                                    
                                </td>
                            </tr>
                            <uc4:ucDictamen ID="ucDictamenAUD" runat="server" />
                        </table>
                        
                        <br />
                    <%--</div>--%>                    
                </div>
                <div class="DJCuadroFooter">
                    <asp:Image ID="ImgFooter_2" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroFooterCOG.png" />                    
                </div>
            <br />
            </asp:Panel> 
            <%-- Termina Formulario Representante --%>
            <%-- Empieza Botones Workflow --%>
            <asp:Panel ID="pnlwfk_botones" runat="server"> 
                <div class="WorkFlowButtons">
                    <asp:ImageButton ID="btnVolver" runat="server" alt="Volver" class="btnVolver" 
                        ImageUrl="~/App_Theme/Imagenes/btnvolver.png" onclick="btnVolver_Click" />
                    &nbsp;&nbsp;
                    <asp:ImageButton ID="btnContinuar" alt="Continuar" class="btnContinuar" runat="server" ImageUrl="~/App_Theme/Imagenes/btncontinuar.png" onclick="btnContinuar_Click" />
                </div>
            </asp:Panel>
            <%-- Termina Botones Workflow --%>        
       <br/> 
</asp:Content>
