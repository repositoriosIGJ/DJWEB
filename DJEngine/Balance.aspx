<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DJ.Master" AutoEventWireup="true"
    CodeBehind="Balance.aspx.cs" Inherits="DJEngine.WebEntities.Balance" %>

<%@ Register Src="App_Controls/ucFecha.ascx" TagName="ucFecha" TagPrefix="uc1" %>
<%@ Register src="App_Controls/ucMontosPesos.ascx" tagname="ucMontosPesos" tagprefix="uc2" %>
<%@ Register src="App_Controls/ucMontosCe.ascx" tagname="ucMontosCe" tagprefix="uc4" %>
<%@ Register src="App_Controls/ucAsamblea.ascx" tagname="ucAsamblea" tagprefix="uc3" %>
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
    <%-- Empieza Panel Datos del Estado Contable --%>
    <asp:Panel ID="pnlwfk_2" runat="server">
        <div class="DJCuadroHeader">
            <asp:Image ID="ImgHeader_2" class="CuadroHeader" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroHeaderG.png" />
            <asp:Label ID="LblTitulo_2" class="CuadroTitulo" runat="server" Width="700px">Datos del Estado Contable</asp:Label>
        </div>
        <div class="DJCuadroCentro">
            <div class="DJCuadroPresen">
                <table cellspacing="10px">
                    <tr>
                        <td>
                            <asp:Label ID="lblAnioBAL" runat="server" Width="210px">Año de Cierre del Balance</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAnioBAL" class="txteffect" runat="server" Width="150px"></asp:TextBox>
                            <asp:CustomValidator ID="cvAnioBAL" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;"
                                ControlToValidate="txtAnioBAL" Display="Dynamic" EnableClientScript="False" OnServerValidate="CustomValidator_Standar"
                                ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                            <br />
                        </td>
                    </tr>
                    <uc1:ucFecha ID="ucFechaBALINI" runat="server" />
                    <uc1:ucFecha ID="ucFechaBALFIN" runat="server" />
                </table>
                <br />
            </div>
        </div>
        <div class="DJCuadroFooter">
            <asp:Image ID="ImgFooter_2" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroFooterCOG.png" />
        </div>
        <br />
    </asp:Panel>
    <%-- Termina Panel Datos del Estado Contable --%>
    <%-- Empieza Panel Datos de Aprobacion --%>
    <asp:Panel ID="Pnl_Aprobacion" runat="server">
        <div class="DJCuadroHeader">
            <asp:Image ID="Image1" class="CuadroHeader" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroHeaderG.png" />
            <asp:Label ID="Label1" class="CuadroTitulo" runat="server" Width="700px">Datos de Aprobaci&oacute;n</asp:Label>
        </div>
        <div class="DJCuadroCentro">
            <div class="DJCuadroPresen">
                <table cellspacing="10px">               
                    <uc1:ucFecha ID="ucFechaReunion" runat="server" />
                    <uc3:ucAsamblea ID="ucTipoAsamblea" runat="server" />
                    <uc1:ucFecha ID="ucFechaAsamblea" runat="server" />
                </table>
                <br />
            </div>
        </div>
        <div class="DJCuadroFooter">
            <asp:Image ID="Image2" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroFooterCOG.png" />
        </div>
        <br />
    </asp:Panel>
    <%-- Termina Panel Datos de Aprobacion --%>
    <%-- Empieza Panel Datos de Capital --%>
    <asp:Panel ID="Pnl_Capital" runat="server">
        <div class="DJCuadroHeader">
            <asp:Image ID="Image3" class="CuadroHeader" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroHeaderG.png" />
            <asp:Label ID="Label2" class="CuadroTitulo" runat="server" Width="700px">Datos del Capital</asp:Label>
        </div>
        <div class="DJCuadroCentro">
            <div class="DJCuadroPresen">
                <table cellspacing="10px">
                    <uc2:ucMontosPesos ID="ucMontosPesosCapital" runat="server" />
                    <uc4:ucMontosCe ID="ucMontosPesosAjuste" runat="server" />
                </table>
                <br />
            </div>
        </div>
        <div class="DJCuadroFooter">
            <asp:Image ID="Image4" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroFooterCOG.png" />
        </div>
        <br />
    </asp:Panel>
    <%-- Termina Panel Datos de Capital --%>
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
