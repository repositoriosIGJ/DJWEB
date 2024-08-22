<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DJ.Master" AutoEventWireup="true"
    CodeBehind="Beneficiario.aspx.cs" Inherits="DJEngine.WebEntities.Beneficiario" %>

<%@ Register Src="App_Controls/ucFiscal.ascx" TagName="ucFiscal" TagPrefix="uc1" %>
<%@ Register Src="App_Controls/ucDocumento.ascx" TagName="ucDocumento" TagPrefix="uc2" %>
<%@ Register Src="App_Controls/ucFechaNac.ascx" TagName="ucFechaNac" TagPrefix="uc4" %>
<%@ Register Src="App_Controls/ucCaptcha.ascx" TagName="ucCaptcha" TagPrefix="uc5" %>
<%@ Register Src="App_Controls/ucDomicilioReal.ascx" TagName="ucDomicilioReal" TagPrefix="uc6" %>
<%@ Register Src="App_Controls/ucEstadoCivil.ascx" TagName="ucEstadoCivil" TagPrefix="uc3" %>
<%@ Register Src="App_Controls/ucEmail.ascx" TagName="ucEmail" TagPrefix="uc7" %>
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
                        <asp:TextBox ID="txtNroCorrelativo" runat="server" Style="text-align: left;" class="txtreferencial"
                            Enabled="false" Width="140px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblEntidad" runat="server" Width="180px">Denominaci&oacute;n de la Entidad</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEntidad" runat="server" Style="text-align: left;" class="txtreferencial"
                            Enabled="false" Width="320px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblTipoSocietario" runat="server" Width="180px">Tipo Societario</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTipoSocietario" runat="server" Style="text-align: left;" class="txtreferencial"
                            Enabled="false" Width="320px"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <%-- Termina Panel de Datos Referenciales --%>
    <%-- Empieza Panel de Si es Beneficiario o No --%>
    <%--<asp:Panel ID="PnlBenefSIoNO" runat="server" Visible="true">
                    <div class="DJCuadroHeader">                        
                        <asp:Image ID="ImgHeader_Ben" class="CuadroHeader" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroHeaderG.png" />
                        <asp:Label ID="ImgTitulo_Ben" class="CuadroTitulo" runat="server" Width="700px">Marcar si Corresponde</asp:Label>
                        <br />
                    </div>
                    <div class="DJCuadroCentro">
                        <div class="DJBenefSIoNO">
                            <asp:CheckBox ID="chkBenefSIoNO" class="chkBenefSIoNO" runat="server" AutoPostBack="True" 
                                Text="Indique si NO hay persona humana que posea el car&aacute;cter de beneficiario/s final/es" 
                                oncheckedchanged="chkBenefSIoNO_CheckedChanged"/>
                         </div>
                    </div>
                    <div class="DJCuadroFooter">
                        <asp:Image ID="ImgFooter_1" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroFooterG.png" />                    
                    </div>
            </asp:Panel>--%>
    <%-- Termina Panel de Si es Beneficiario o No --%>
    <%-- Empieza Panel de Tipo de Beneficiario --%>
    <asp:Panel ID="PnlTipoBen" runat="server" Visible="true">
        <div class="DJCuadroHeader">
            <asp:Image ID="ImgHeader_Ben" class="CuadroHeader" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroHeaderG.png" />
            <asp:Label ID="ImgTitulo_Ben" class="CuadroTitulo" runat="server" Width="700px">Elija tipo de Beneficiario</asp:Label>
            <br />
        </div>
        <div class="DJCuadroCentro">
            <div class="DJCuadroTipoBen">
                <asp:RadioButtonList ID="rblTipoBen" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblTipoBen_SelectedIndexChanged"
                    RepeatDirection="Horizontal">
                    <asp:ListItem Text="Participación Directa" Value="1" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Participación Indirecta" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Persona Humana que Ejerce el Control Final" Value="3"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </div>
        <div class="DJCuadroFooter">
            <asp:Image ID="ImgFooter_1" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroFooterG.png" />
        </div>
    </asp:Panel>
    <%-- Termina Panel de Tipo de Beneficiario --%>
    <%-- Empieza Panel de Validacion --%>
    <asp:Panel ID="pnlvalidacion" runat="server" Visible="false">
        <div class="divValidacion">
            <div class="DJValidHeader">
                <asp:Image ID="ImgHeader_val" class="CuadroHeader" runat="server" ImageUrl="~/App_Theme/Imagenes/DJValidHeader.png" />
                <asp:Label ID="LblTitulo_val" class="CuadroTitulo" runat="server" Width="700px">Por favor resuelva los siguientes errores</asp:Label>
            </div>
            <div class="DJValidCentro">
                <asp:ValidationSummary ID="vldsumRepresentante" runat="server" Width="650px" />
                </asp:ValidationSummary>
                <asp:Label ID="lblCaptchaErrorvld" class="CuadroTitulo" runat="server" Width="700px"
                    Visible="false">&#8226; [CODIGO DE VALIDACION] El texto ingresado es incorrecto, por favor vuelva a intentarlo nuevamente.</asp:Label>
            </div>
            <div class="DJValidFooter">
                <asp:Image ID="ImgFooter_val" runat="server" ImageUrl="~/App_Theme/Imagenes/DJValidFooter.png" />
            </div>
        </div>
        <br />
    </asp:Panel>
    <%-- Termina Panel de Validacion --%>
    <%-- Empieza Formulario Beneficiario --%>
    <asp:Panel ID="pnlwfk_2" runat="server">
        <div class="DJCuadroHeader">
            <asp:Image ID="ImgHeader_2" class="CuadroHeader" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroHeaderG.png" />
            <asp:Label ID="LblTitulo_2" class="CuadroTitulo" runat="server" Width="700px">Datos del Beneficiario Final</asp:Label>
        </div>
        <div class="DJCuadroCentro">
            <table cellspacing="10px">
                <tr>
                    <td>
                        <asp:Label ID="lblNombre" runat="server" Width="260px">Nombre</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNombre" class="txteffect" runat="server" Width="150px"></asp:TextBox>
                        <asp:CustomValidator ID="cvNombre" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;"
                            ControlToValidate="txtNombre" Display="Dynamic" EnableClientScript="False" OnServerValidate="CustomValidator_Standar"
                            ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblApellido" runat="server" Width="260px">Apellido</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtApellido" class="txteffect" runat="server" Width="170px"></asp:TextBox>
                        <asp:CustomValidator ID="cvApellido" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;"
                            ControlToValidate="txtApellido" Display="Dynamic" EnableClientScript="False"
                            OnServerValidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                        <br />
                    </td>
                </tr>
                <uc2:ucDocumento ID="ucDocumento" runat="server" />
                <uc1:ucFiscal ID="ucFiscal" runat="server" />
                <uc6:ucDomicilioReal ID="ucDomicilioReal" runat="server" />
                <tr>
                    <td>
                        <asp:Label ID="lblNacionalidad" runat="server" Width="260px">Nacionalidad</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNacionalidad" class="txteffect" runat="server" Width="210px"></asp:TextBox>
                        <asp:CustomValidator ID="cvNacionalidad" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;"
                            ControlToValidate="txtNacionalidad" Display="Dynamic" EnableClientScript="False"
                            OnServerValidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                        <br />
                    </td>
                </tr>
                <uc4:ucFechaNac ID="ucFechaNac" runat="server" />
                <uc3:ucEstadoCivil ID="ucEstadoCivil" runat="server" />
                <uc7:ucEmail ID="ucEmail" runat="server" />
                <tr>
                    <td>
                        <asp:Label ID="lblProfesion" runat="server" Width="260px">Profesión</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtProfesion" class="txteffect" runat="server" Width="260px"></asp:TextBox>
                        <asp:CustomValidator ID="cvProfesion" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;"
                            ControlToValidate="txtProfesion" Display="Dynamic" EnableClientScript="False"
                            OnServerValidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                        <br />
                    </td>
                </tr>
                <div id="divPorcentaje" runat="server" visible="true">
                    <tr>
                        <td>
                            <asp:Label ID="lblPorcentaje" runat="server" Style="font-size: 10px; letter-spacing: 0.2px;"
                                Width="260px">Porcentaje de Participación en la Entidad (Directo)</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPorcentaje" class="txteffect" runat="server" Width="50px" MaxLength="5"></asp:TextBox>
                            <asp:CustomValidator ID="cvPorcentaje" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;"
                                ControlToValidate="txtPorcentaje" Display="Dynamic" EnableClientScript="False"
                                OnServerValidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>&nbsp;%
                            <b style="font-size: 7pt; color: #0290bf; letter-spacing: 0.5pt;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(MAX.
                                DOS DECIMALES)</b>
                            <br />
                        </td>
                    </tr>
                </div>
                <div id="divCaracter" runat="server" visible="false">
                    <tr>
                        <td>
                            <asp:Label ID="lblCaracter" runat="server" Style="font-size: 10px; letter-spacing: 0.2px;" Width="260px">Calidad de la persona humana que frente a la entidad ejerce el control final</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCaracter" class="txteffect" runat="server" Width="260px"></asp:TextBox>
                            <asp:CustomValidator ID="cvCaracter" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;"
                                ControlToValidate="txtCaracter" Display="Dynamic" EnableClientScript="False"
                                OnServerValidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                            <br />
                        </td>
                    </tr>
                </div>
                </table>
                <table cellspacing="10px">
                <tr>
                    <td>
                        <asp:Label ID="lblObserv" runat="server" Width="340px" style="text-align:left;">Observaciones</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;<b style="font-size: 6pt; color: #0290bf; letter-spacing: 0.5pt; margin-bottom:10px;">(MAX. 1000 CARACTERES)</b><br />
                        <asp:TextBox ID="txaObserv" TextMode="MultiLine" class="txteffect" runat="server" Width="480px" Height="100px"></asp:TextBox>
                        <asp:CustomValidator ID="cvObserv" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;"
                            ControlToValidate="txaObserv" Display="Dynamic" EnableClientScript="False"
                            OnServerValidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                            
                        <br />
                    </td>
                </tr>
            </table>
            <br />
        </div>
        <div class="DJCuadroFooter">
            <asp:Image ID="ImgFooter_2" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroFooterFiscal.png" />
        </div>
        <br />
    </asp:Panel>
    <%-- Termina Formulario Beneficiario --%>
    <%-- Empieza Captcha --%>
    <uc5:ucCaptcha ID="ucCaptcha" runat="server" />
    <%-- Termina Captcha --%>
    <%-- Empieza Botones Workflow --%>
    <asp:Panel ID="pnlwfk_botones" runat="server">
        <div class="WorkFlowButtons">
            <asp:ImageButton ID="btnVolver" runat="server" alt="Volver" class="btnVolver" ImageUrl="~/App_Theme/Imagenes/btnvolver.png"
                OnClick="btnVolver_Click" />
            &nbsp;&nbsp;
            <asp:ImageButton ID="btnContinuar" alt="Continuar" class="btnContinuar" runat="server"
                ImageUrl="~/App_Theme/Imagenes/btncontinuar.png" OnClick="btnContinuar_Click" />
        </div>
    </asp:Panel>
    <%-- Termina Botones Workflow --%>
    <br />
</asp:Content>
