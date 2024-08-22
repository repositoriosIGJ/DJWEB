<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DJ.Master" AutoEventWireup="true"
    CodeBehind="Validar.aspx.cs" Inherits="DJEngine.WebEntities.Validar" %>
<%@ Register Src="App_Controls/ucCaptcha.ascx" TagName="ucCaptcha" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MasterPage" runat="server">
    <%-- Empieza Mensaje de Atención --%>
    <asp:Panel ID="pnlMensaje" runat="server" Width="530px">
        <div class="MSGCuadroNuevo">                    
            <asp:Label ID="lblCuadroTitulo" class="CuadroTitulo" runat="server" Width="530px">ATENCION: Se le ha Enviado un Email</asp:Label>
            <hr />
            <div class="MSGCuadroCentroNuevo" Width="400px">
            <p align="justify">Por favor, revise su cuenta de email recientemente<br />ingresada como "domicilio digital", ya que se le<br />envio un correo con el codigo de validacion<br /> necesario para poder ser copiado y pegado<br />o tipeado en el campo correspondiente</p>
            </div>                    
        </div>
    <br />
    </asp:Panel> 
    <%-- Termina Mensaje de Atención --%>
    <%-- Empieza Panel de Datos Referenciales --%>
    <asp:Panel ID="pnlwfk_1" runat="server">
        <div class="DJCuadroHeader">
            <asp:Label ID="LblTitulo_1" class="CuadroTituloSinBack" runat="server" Width="625px">Datos Cargados Previamente</asp:Label>
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
                        <asp:Label ID="lblDomDig" runat="server" Width="180px">Domicilio Digital (email)</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDomDig" runat="server" Style="text-align: left;" class="txtreferencial"
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
    <%-- Empieza Formulario de Codigo de Comprobación --%>
    <asp:Panel ID="pnlwfk_3" runat="server">
        <div class="DJCuadroHeader">
            <asp:Image ID="ImgHeader_2" class="CuadroHeader" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroHeaderG.png" />
            <asp:Label ID="LblTitulo_2" class="CuadroTitulo" runat="server" Width="700px">C&oacute;digo de Comprobaci&oacute;n del Domicilio Digital</asp:Label>
        </div>
        <div class="DJCuadroCentro">
            <table cellspacing="10px">
                <tr>
                    <td>
                        <asp:Label ID="lblCodValDD" runat="server" Width="270px">C&oacute;digo de Validaci&oacute;n del Domicilio Digital</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCodValDD" class="txteffect" runat="server" Width="330px"></asp:TextBox>
                        <asp:CustomValidator ID="cvCodValDD" runat="server" ErrorMessage="*" ControlToValidate="txtCodValDD"
                            Display="Dynamic" EnableClientScript="False" OnServerValidate="CustomValidator_Standar"
                            ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                        <asp:CustomValidator ID="cvCodValDDCompare" runat="server" ErrorMessage="*"
                            ControlToValidate="txtCodValDD" Display="Dynamic" EnableClientScript="False"
                            OnServerValidate="CustomValidator_CodValDD" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                        <br />
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
    <%-- Termina Formulario de Codigo de Comprobación --%>
    <%-- Empieza Captcha --%>
    <uc3:ucCaptcha ID="ucCaptchaDomDig" runat="server" />
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
