<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DJ.Master" AutoEventWireup="true"
    CodeBehind="Contador.aspx.cs" Inherits="DJEngine.WebEntities.Contador" %>

<%@ Register Src="App_Controls/ucFiscal.ascx" TagName="ucFiscal" TagPrefix="uc1" %>
<%@ Register Src="App_Controls/ucDocumento.ascx" TagName="ucDocumento" TagPrefix="uc2" %>
<%@ Register Src="App_Controls/ucFecha.ascx" TagName="ucFecha" TagPrefix="uc3" %>
<%@ Register Src="App_Controls/ucDictamen.ascx" TagName="ucDictamen" TagPrefix="uc4" %>
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
                <tr>
                    <td>
                        <asp:Label ID="lblCuitEnt" runat="server" Width="180px">CUIT</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCuitEnt" runat="server" Style="text-align: left;" class="txtreferencial"
                            Enabled="false" Width="200px"></asp:TextBox>
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
    <%-- Empieza Formulario Representante --%>
    <asp:Panel ID="pnlwfk_2" runat="server">
        <div class="DJCuadroHeader">
            <asp:Image ID="ImgHeader_2" class="CuadroHeader" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroHeaderG.png" />
            <asp:Label ID="LblTitulo_2" class="CuadroTitulo" runat="server" Width="700px">Datos del Contador Certificante</asp:Label>
        </div>
        <div class="DJCuadroCentro">
            <%--<div class="DJCuadroPresen">--%>
            <table cellspacing="10px">
                <tr>
                    <td>
                        <asp:Label ID="lblNombreCON" runat="server" Width="210px">Nombre</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNombreCON" class="txteffect" runat="server" Width="150px"></asp:TextBox>
                        <asp:CustomValidator ID="cvNombreCON" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;"
                            ControlToValidate="txtNombreCON" Display="Dynamic" EnableClientScript="False"
                            OnServerValidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblApellidoCON" runat="server" Width="210px">Apellido</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtApellidoCON" class="txteffect" runat="server" Width="170px"></asp:TextBox>
                        <asp:CustomValidator ID="cvApellidoCON" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;"
                            ControlToValidate="txtApellidoCON" Display="Dynamic" EnableClientScript="False"
                            OnServerValidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                        <br />
                    </td>
                </tr>
                <uc2:ucDocumento ID="ucDocumentoCON" runat="server" />
                <uc1:ucFiscal ID="ucFiscalCON" runat="server" />
                <tr>
                    <td>
                        <asp:Label ID="lblTomoCON" runat="server" Width="210px">Tomo</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox class="txteffect" ID="txtTomoCON" runat="server" Width="95px"></asp:TextBox>
                        <asp:CustomValidator ID="cvTomoCON" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;"
                            ControlToValidate="txtTomoCON" Display="Dynamic" EnableClientScript="False" OnServerValidate="CustomValidator_Standar"
                            ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblFolioCON" runat="server" Width="210px">Folio</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox class="txteffect" ID="txtFolioCON" runat="server" Width="92px"></asp:TextBox>
                        <asp:CustomValidator ID="cvFolioCON" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;"
                            ControlToValidate="txtFolioCON" Display="Dynamic" EnableClientScript="False"
                            OnServerValidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                        <br />
                    </td>
                </tr>
                <uc3:ucFecha ID="ucFechaAUD" runat="server" />
                <tr>
                    <td>
                        <asp:Label ID="lblNroLegAUD" runat="server" Width="210px" Font-Size="14px">Nro. de Legalización del Informe del Auditor Externo</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox class="txteffect" ID="txtNroLegAUD" runat="server" Width="95px"></asp:TextBox>
                        <asp:CustomValidator ID="cvNroLegAUD" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;"
                            ControlToValidate="txtNroLegAUD" Display="Dynamic" EnableClientScript="False"
                            OnServerValidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                        <br />
                    </td>
                </tr>
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
