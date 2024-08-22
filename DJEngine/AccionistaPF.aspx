<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DJ.Master" AutoEventWireup="true" CodeBehind="AccionistaPF.aspx.cs" Inherits="DJEngine.WebEntities.AccionistaPF" %>
<%@ Register src="App_Controls/ucFiscal.ascx" tagname="ucFiscal" tagprefix="uc1" %>
<%@ Register src="App_Controls/ucDocumento.ascx" tagname="ucDocumento" tagprefix="uc2" %>
<%@ Register src="App_Controls/ucAcciones.ascx" tagname="ucAcciones" tagprefix="uc3" %>
<%@ Register src="App_Controls/ucDomicilio.ascx" tagname="ucDomicilio" tagprefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MasterPage" runat="server">
            <%--<tr>
                                <td>
                                    <asp:Label ID="lblTipoDocREP" runat="server" Width="210px">Tipo de Documento</asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlTipoDocREP" runat="server" Width="280px" 
                                        DataTextField="Descripcion" DataValueField="Codigo"></asp:DropDownList>
                                    <asp:CustomValidator ID="cvTipoDocREP" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" 
                                    ControlToValidate="ddlTipoDocREP" Display="Dynamic" EnableClientScript="False" 
                                    onservervalidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgAsterisco"></asp:CustomValidator>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblNroDocREP" runat="server" Width="210px">N&uacute;mero de Documento</asp:Label>
                                </td>
                                <td>                     
                                    <asp:TextBox ID="txtNroDocREP" runat="server" Width="150px"></asp:TextBox>
                                    <asp:CustomValidator ID="cvNroDocREP" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" 
                                    ControlToValidate="txtNroDocREP" Display="Dynamic" EnableClientScript="False" 
                                    onservervalidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgAsterisco"></asp:CustomValidator>
                                    <br />
                                </td>
                            </tr>--%>              
            <asp:Panel ID="pnlwfk_1" runat="server">
                <div class="DJCuadroHeader">
                    <%--<asp:Image ID="ImgHeader_1" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroHeader.png" />--%>
                      <asp:Label ID="LblTitulo_1" class="CuadroTituloSinBack" runat="server" Width="625px">Datos de la Entidad</asp:Label>
                </div>
                <div class="DJCuadroReferen">
                    <table cellspacing="10px">
                        <tr>
                            <td>
                                <asp:Label ID="lblEntidad" runat="server" Width="180px">Denominaci&oacute;n de la Entidad</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEntidad" runat="server" Width="300px" Enabled="false" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblTipoSocietario" runat="server" Width="180px">Tipo Societario</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTipoSocietario" runat="server" Enabled="false" Width="300px"></asp:TextBox>
                            </td>
                         </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblNroCorrelativo" runat="server" Width="180px">Número Correlativo</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtNroCorrelativo" runat="server" Enabled="false" Width="180px"></asp:TextBox>
                            </td>
                        </tr>
                     </table>
                 </div>                    
                <%-- 
                <div class="DJCuadroFooter">
                    <asp:Image ID="ImgFooter_1" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroFooter.png" />
                </div>
                --%>
            </asp:Panel>            
            <%-- Empieza Botones Workflow --%>            <%-- Termina Botones Workflow --%>
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
                    <asp:Label ID="LblTitulo_2" class="CuadroTitulo" runat="server" Width="700px">Datos del Presidente o Titular</asp:Label>
                </div>
                <div class="DJCuadroCentro">                   
                    <div class="DJCuadroPresen">
                        <table cellspacing="10px">
                            <tr>
                                <td colspan="2" style="height: 69px">
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                        Height="88px">
                                        <Columns>
                                            <asp:BoundField HeaderText="Nombre y Apellido" />
                                            <asp:BoundField HeaderText="Domicilio" />
                                            <asp:BoundField HeaderText="Clave Fiscal" />
                                            <asp:BoundField HeaderText="Cant. Acciones" />
                                            <asp:BoundField HeaderText="Cant. Votos" />
                                            <asp:BoundField HeaderText="Procentaje" />
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblNombreREP" runat="server" Width="210px">Nombre</asp:Label>
                                </td>
                                <td style="text-align: left">
                                    <asp:TextBox ID="txtNombreAPF" runat="server" Width="150px"></asp:TextBox>
                                    <asp:CustomValidator ID="cvNombreREP" runat="server" 
                                        ControlToValidate="txtNombreAPF" CssClass="imgAsterisco" Display="Dynamic" 
                                        EnableClientScript="False" 
                                        ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" 
                                        onservervalidate="CustomValidator_Standar" ValidateEmptyText="True"></asp:CustomValidator>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblApellidoREP" runat="server" Width="210px">Apellido</asp:Label>
                                </td>
                                <td style="text-align: left">
                                    <asp:TextBox ID="txtApellidoAPF" runat="server" Width="170px"></asp:TextBox>
                                    <asp:CustomValidator ID="cvApellidoREP" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" 
                                    ControlToValidate="txtApellidoAPF" Display="Dynamic" EnableClientScript="False" 
                                    onservervalidate="CustomValidator_Standar" ValidateEmptyText="True" 
                                        CssClass="imgAsterisco"></asp:CustomValidator>
                                    <br />
                                </td>
                            </tr>                        
                            <%--<tr>
                                <td>
                                    <asp:Label ID="lblTipoDocREP" runat="server" Width="210px">Tipo de Documento</asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlTipoDocREP" runat="server" Width="280px" 
                                        DataTextField="Descripcion" DataValueField="Codigo"></asp:DropDownList>
                                    <asp:CustomValidator ID="cvTipoDocREP" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" 
                                    ControlToValidate="ddlTipoDocREP" Display="Dynamic" EnableClientScript="False" 
                                    onservervalidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgAsterisco"></asp:CustomValidator>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblNroDocREP" runat="server" Width="210px">N&uacute;mero de Documento</asp:Label>
                                </td>
                                <td>                     
                                    <asp:TextBox ID="txtNroDocREP" runat="server" Width="150px"></asp:TextBox>
                                    <asp:CustomValidator ID="cvNroDocREP" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" 
                                    ControlToValidate="txtNroDocREP" Display="Dynamic" EnableClientScript="False" 
                                    onservervalidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgAsterisco"></asp:CustomValidator>
                                    <br />
                                </td>
                            </tr>--%>
                            <uc4:ucDomicilio ID="ucDomicilio1" runat="server" />
                            <uc2:ucDocumento ID="ucDocumentoAPF" runat="server" />
                            
                            <uc1:ucFiscal ID="ucFiscalAPF" runat="server" />
                            <uc3:ucAcciones ID="ucAccionesAPF" runat="server" />
                            <tr>
                                <td>
                                    <br />
                                </td>
                            </tr>
                        <%--<tr>
                                <td>
                                    <asp:Label ID="lblTipoClaveFiscalREP" runat="server" Width="210px">Tipo de Identificaci&oacute;n Fiscal</asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlTipoClaveFiscalREP" runat="server" Width="280px" DataTextField="Descripcion" DataValueField="Codigo">
                                        <asp:ListItem Selected="True" Value="-1">&lt;&lt; SELECCIONAR OPCION &gt;&gt;</asp:ListItem>
                                        <asp:ListItem Value="1">CUIT</asp:ListItem>
                                        <asp:ListItem Value="2">CUIL</asp:ListItem>
										<asp:ListItem Value="3">CDI</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:CustomValidator ID="cvTipoClaveFiscalREP" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" 
                                    ControlToValidate="ddlTipoClaveFiscalREP" Display="Dynamic" EnableClientScript="False" 
                                    onservervalidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgAsterisco"></asp:CustomValidator>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblNroClaveFiscalREP" runat="server" Width="210px">Numero de Identificaci&oacute;n Fiscal</asp:Label>
                                </td>
                                <td> 
                                    <asp:TextBox ID="txtNroClaveFiscalREP" runat="server" Width="170px"></asp:TextBox>
                                    <asp:CustomValidator ID="cvNroClaveFiscalREP" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" 
                                    ControlToValidate="txtNroClaveFiscalREP" Display="Dynamic" EnableClientScript="False" 
                                    onservervalidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgAsterisco"></asp:CustomValidator>
                                    <br />
                                </td>
                            </tr>--%>
                            <tr>
                            <td></td>
                                <td style="text-align: left">
                                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" 
                                        onclick="btnAgregar_Click" />
                                </td>
                            </tr>
                        </table>
                        <br />
                    </div>                    
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
