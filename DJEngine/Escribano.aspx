<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DJ.Master" AutoEventWireup="true" CodeBehind="Escribano.aspx.cs" Inherits="DJEngine.WebEntities.EscribanoWeb" %>
<%@ Register src="App_Controls/ucFiscal.ascx" tagname="ucFiscal" tagprefix="uc1" %>
<%@ Register src="App_Controls/ucDocumento.ascx" tagname="ucDocumento" tagprefix="uc2" %>
<%@ Register src="App_Controls/ucFecha.ascx" tagname="ucFecha" tagprefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MasterPage" runat="server">
            <%-- Termina Panel de Escribano Publico--%> 
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
            <%-- Termina Botones Workflow --%>                
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
            
            <%-- Empieza Panel de Escribano Publico / Escritura Publica --%>
            <asp:Panel ID="pnlwfk_2" runat="server">
                <div class="DJCuadroHeader">
                    <asp:Image ID="ImgHeader_2" class="CuadroHeader" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroHeaderG.png" />
                    <asp:Label ID="LblTitulo_2" class="CuadroTitulo" runat="server" Width="700px">Escribano Publico</asp:Label>
                </div>
                <div class="DJCuadroCentro">                   
                        <table cellspacing="10px">
                            <tr>
                                <td>
                                    <asp:Label ID="lblMatriculaEP1" runat="server" Width="150px">Nombre</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox class="txteffect" ID="txtNombreEP" runat="server" Width="150px"></asp:TextBox>
                                    <asp:CustomValidator ID="cvNombreEP" runat="server" ErrorMessage="*" 
                                    ControlToValidate="txtNombreEP" Display="Dynamic" EnableClientScript="False" 
                                    onservervalidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblMatriculaEP0" runat="server" Width="150px">Apellido</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox class="txteffect" ID="txtApellidoEP" runat="server" Width="170px"></asp:TextBox>
                                    <asp:CustomValidator ID="cvApellidoEP" runat="server" ErrorMessage="*" 
                                    ControlToValidate="txtApellidoEP" Display="Dynamic" EnableClientScript="False" 
                                    onservervalidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblMatriculaEP" runat="server" Width="150px">Matricula</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox class="txteffect" ID="txtMatriculaEP" runat="server" Width="97px"></asp:TextBox>
                                    <asp:CustomValidator ID="cvMatriculaEP" runat="server" ErrorMessage="*" 
                                    ControlToValidate="txtMatriculaEP" Display="Dynamic" EnableClientScript="False" 
                                    onservervalidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblTomoEP" runat="server" Width="150px">Tomo</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox class="txteffect" ID="txtTomoEP" runat="server" Width="95px"></asp:TextBox>
                                    <asp:CustomValidator ID="cvTomoEP" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" 
                                    ControlToValidate="txtTomoEP" Display="Dynamic" EnableClientScript="False" 
                                    onservervalidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>                                    
                                    <asp:Label ID="lblFolioEP" runat="server" Width="150px">Folio</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox class="txteffect" ID="txtFolioEP" runat="server" Width="92px"></asp:TextBox>
                                    <asp:CustomValidator ID="cvFolioEP" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" 
                                    ControlToValidate="txtFolioEP" Display="Dynamic" EnableClientScript="False" 
                                    onservervalidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                                    <br />
                                </td>
                            </tr>
                        </table>
                        <br />
                        <br />
 						<asp:Label ID="lblHeader_2b" class="CuadroTituloIntermedio" runat="server" Width="700px">Escritura Publica</asp:Label>                        
                        <br />
                        <table cellspacing="10px">
                            <tr>
                                <td>                                    
                                    <asp:Label ID="lblNroEscr" runat="server" Width="150px">Numero</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox class="txteffect" ID="txtNroEscr" runat="server" Width="150px"></asp:TextBox>
                                    <asp:CustomValidator ID="cvNroEscr" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" 
                                    ControlToValidate="txtNroEscr" Display="Dynamic" EnableClientScript="False" 
                                    onservervalidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>                                    
                                    <asp:Label ID="lblFolioEscr" runat="server" Width="150px">Folio</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox class="txteffect" ID="txtFolioEscr" runat="server" Width="150px"></asp:TextBox>
                                    <%--CustomValidator4--%>
                                    <asp:CustomValidator ID="cvFolioEscr" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" 
                                    ControlToValidate="txtFolioEscr" Display="Dynamic" EnableClientScript="False" 
                                    onservervalidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                                    <br />
                                </td>
                            </tr>
                            <%--<tr>
                                <td style="width: 160px">                                    
                                    <asp:Label ID="lblFechaEscr" runat="server" Width="150px" 
                                        style="text-align: right">Fecha</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox class="txteffect" ID="txtFechaEscr" runat="server" Width="150px"></asp:TextBox>
                                    <asp:CustomValidator ID="cvFechaEscr" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" 
                                    ControlToValidate="txtFechaEscr" Display="Dynamic" EnableClientScript="False" 
                                    onservervalidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                                    &nbsp;<asp:Label ID="Label1" runat="server" Font-Overline="False" 
                                        Font-Size="Smaller" Font-Underline="False" Text="(ejm 22/05/2012)"></asp:Label><br />                                    
                                </td>                                
                            </tr>--%>
                            <uc3:ucFecha ID="ucFechaEscr" runat="server" />                             
                        </table>            
                </div>
                <div class="DJCuadroFooter">
                    <asp:Image ID="ImgFooter_2" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroFooterCOG.png" />                    
                </div>
                <br />            
            </asp:Panel> 
            <%-- Termina Panel de Escribano Publico--%>
            <%-- Empieza Botones Workflow --%>
            <asp:Panel ID="pnlwfk_botones" runat="server"> 
                <div class="WorkFlowButtons">
                    <asp:ImageButton ID="btnVolver" runat="server" alt="Volver" class="btnVolver" 
                        ImageUrl="~/App_Theme/Imagenes/btnvolver.png" onclick="btnVolver_Click" />
                    &nbsp;&nbsp;
                    <asp:ImageButton ID="btnContinuar" alt="Continuar" onclick="btnContinuar_Click" class="btnContinuar" runat="server" ImageUrl="~/App_Theme/Imagenes/btncontinuar.png" />
                </div>
            </asp:Panel>
            <%-- Termina Botones Workflow --%>       
       <br/> 
</asp:Content>
