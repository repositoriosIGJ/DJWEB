<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DJ.Master" AutoEventWireup="true"
    CodeBehind="DomDig.aspx.cs" Inherits="DJEngine.WebEntities.DomDig" %>

<%@ Register Src="App_Controls/ucCaptcha.ascx" TagName="ucCaptcha" TagPrefix="uc3" %>
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
    <%-- Empieza Formulario Domicilio Digital --%>
    <asp:Panel ID="pnlwfk_2" runat="server" Width="800px">
        <div class="DJCuadroHeader">
            <asp:Image ID="ImgHeader_2" class="CuadroHeader" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroHeaderG.png" />
            <asp:Label ID="LblTitulo_2" class="CuadroTitulo" runat="server" Width="700px">Ingreso y Validaci&oacute;n del Domicilio Digital</asp:Label>
        </div>
        <div class="DJCuadroCentro">
            <table cellspacing="10px">
                <tr>
                    <td>
                        <asp:Label ID="lblDomDigNuevo" runat="server" Width="240px">Domicilio Digital (email)</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDomDigNuevo" class="txteffect" runat="server" Width="240px"></asp:TextBox>
                        <asp:CustomValidator ID="cvDomDigNuevo" runat="server" ErrorMessage="*" ControlToValidate="txtDomDigNuevo"
                            Display="Dynamic" EnableClientScript="False" OnServerValidate="CustomValidator_Standar"
                            ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDomDigConfirm" runat="server" Width="240px">Confirmar Domicilio Digital (email)</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDomDigConfirm" class="txteffect" runat="server" Width="240px"></asp:TextBox>
                        <asp:CustomValidator ID="cvDomDigConfirm" runat="server" ErrorMessage="*" ControlToValidate="txtDomDigConfirm"
                            Display="Dynamic" EnableClientScript="False" OnServerValidate="CustomValidator_Standar"
                            ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                        <asp:CustomValidator ID="cvDomDigCompare" runat="server" Display="Dynamic" EnableClientScript="False"
                            ErrorMessage="*" OnServerValidate="CustomValidator_DomDig" CssClass="imgCruz"></asp:CustomValidator>
                    </td>
                </tr>
            </table>
            <br />
        </div>
        <div class="DJCuadroFooter">
            <asp:Image ID="ImgFooter_2" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroFooterCOG.png" />
        </div>
        <br />
    </asp:Panel>
    <%-- Termina Formulario Domicilio Digital --%>
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
