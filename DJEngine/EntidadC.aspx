<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DJ.Master" AutoEventWireup="true"
    CodeBehind="EntidadC.aspx.cs" Inherits="DJEngine.WebEntities.EntidadC" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="App_Controls/ucCaptcha.ascx" TagName="ucCaptcha" TagPrefix="uc1" %>
<%@ Register Src="App_Controls/ucDomicilioReal.ascx" TagName="ucDomicilioReal" TagPrefix="uc2" %>
<%@ Register Src="App_Controls/ucCUIT.ascx" TagName="ucCUIT" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MasterPage" runat="server">
    <asp:UpdatePanel ID="updpnlBuscadorEnt" runat="server">
        <ContentTemplate>
            <%-- Empieza Panel de Busqueda de Entidad Por Nro Correlativo o CUIT --%>
            <asp:Panel ID="pnlwfk_1" runat="server" Visible="true">
                <div class="DJCuadroHeader">
                    <asp:Image ID="ImgHeader_1" class="CuadroHeader" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroHeaderG.png" />
                    <asp:Label ID="LblTitulo_1" class="CuadroTitulo" runat="server" Width="700px">Indique como desea realizar la busqueda de la Entidad</asp:Label>
                    <br />
                </div>
                <div class="DJCuadroCentro">
                    <div class="DJCuadroConstituida">
                        <asp:RadioButtonList ID="rblBusqueda" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblBusqueda_SelectedIndexChanged"
                            RepeatDirection="Horizontal">
                            <asp:ListItem Text="Buscar Entidad por Numero Correlativo" Value="1" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Buscar Entidad por CUIT" Value="2"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div class="DJCuadroFooter">
                    <asp:Image ID="ImgFooter_1" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroFooterG.png" />
                </div>
            </asp:Panel>
            <%-- Termina Panel de Busqueda de Entidad Por Nro Correlativo o CUIT --%>
            <%-- Empieza Panel de Validacion --%>
            <asp:Panel ID="pnlvalidacion" runat="server" Visible="false">
                <div class="divValidacion">
                    <div class="DJValidHeader">
                        <asp:Image ID="ImgHeader_val" class="CuadroHeader" runat="server" ImageUrl="~/App_Theme/Imagenes/DJValidHeader.png" />
                        <asp:Label ID="LblTitulo_val" class="CuadroTitulo" runat="server" Width="700px">Por favor resuelva los siguientes errores</asp:Label>
                    </div>
                    <div class="DJValidCentro">
                        <asp:ValidationSummary ID="vldsumEntidad" runat="server" Width="600px"></asp:ValidationSummary>
                    </div>
                    <div class="DJValidFooter">
                        <asp:Image ID="ImgFooter_val" runat="server" ImageUrl="~/App_Theme/Imagenes/DJValidFooter.png" />
                    </div>
                </div>
            </asp:Panel>
            <%-- Termina Panel de Validacion --%>
            <%-- Empieza Busqueda de Entidad por Nro Correlativo --%>
            <asp:Panel ID="pnlwfk_2" runat="server" BackImageUrl="/imagenes/" Visible="False">
                <div class="DJCuadroHeader">
                    <asp:Image ID="ImgHeader_2" class="CuadroHeader" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroHeaderG.png" />
                    <asp:Label ID="LblTitulo_2" class="CuadroTitulo" runat="server" Width="700px">B&uacute;squeda de Entidad Constituida por N&uacute;mero Correlativo</asp:Label>
                    <br />
                </div>
                <div class="DJCuadroCentro">
                    <%-- Empieza Busqueda de Entidades --%>
                    <table cellspacing="10px">
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblNroCorrelativo" runat="server" Width="210px">N&uacute;mero Correlativo</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtNroCorrelativo" class="txtNroCorr txteffect" runat="server" MaxLength="12"
                                    Width="180px" Height="24px"></asp:TextBox>
                                <asp:CustomValidator ID="cvNroCorrelativo" runat="server" ErrorMessage="*" ControlToValidate="txtNroCorrelativo"
                                    Display="Dynamic" EnableClientScript="False" OnServerValidate="CustomValidator_Standar"
                                    ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                                <asp:CustomValidator ID="cvNoExisteNroCorr" runat="server" ErrorMessage="El N&uacute;mero Correlativo no se corresponde a una Entidad existente"
                                    Display="Dynamic" EnableClientScript="False" CssClass="imgCruz"></asp:CustomValidator>
                            </td>
                        </tr>
                        <div id="divTipoDeEntidadC" runat="server" visible="true">
                            <tr>
                                <td>
                                    <asp:Label ID="lblTipoDeEntidadConstituida" runat="server" Width="210px">Tipo de Entidad</asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlTipoDeEntidadConstituida" class="ddleffect" runat="server"
                                        AutoPostBack="True" DataTextField="Descripcion" DataValueField="Codigo" Enabled="false">
                                    </asp:DropDownList>
                                    <asp:CustomValidator ID="cvTipoDeEntidadConstituida" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;"
                                        ControlToValidate="ddlTipoDeEntidadConstituida" Display="Dynamic" EnableClientScript="False"
                                        OnServerValidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                                    <br />
                                </td>
                            </tr>
                        </div>
                        <%-- Empieza Datos Referenciales de la Entidad --%>
                        <div id="divdatosentidad" runat="server" visible="false">
                            <div id="divCUITref" runat="server" visible="false">
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblCUITref" runat="server" Width="180px">CUIT</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtCUITref" runat="server" Width="180px" Style="text-align: left;"
                                            class="txtreferencial" Enabled="false"></asp:TextBox>
                                    </td>
                                </tr>
                            </div>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblEntidadC" runat="server" Width="180px">Denominaci&oacute;n de la Entidad</asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtEntidadC" runat="server" Width="300px" Style="text-align: left;"
                                        class="txtreferencial" Enabled="false"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblTipoSocietario" runat="server" Width="180px">Tipo Societario</asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtTipoSocietario" runat="server" Width="250px" Style="text-align: left;"
                                        class="txtreferencial" Enabled="false"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">
                                    <asp:ImageButton ID="btnBuscarNroCorrOtra" runat="server" class="btnBuscarNroCorr"
                                        ImageUrl="~/App_Theme/Imagenes/btnbuscarnueva.png" OnClick="btnBuscarNroCorrOtra_Click"
                                        AutoPostBack="True" />
                                </td>
                            </tr>
                        </div>
                    </table>
                </div>
                <%-- Termina Datos Referenciales de la Entidad --%>
                <%-- Empieza pedido de Sede Social y/o Nro de CUIT (Si no se encuentra) para busqueda por Numero Correlativo --%>
                <div id="divdatosextra" runat="server" visible="false">
                    <div class="DJCuadroCentro DJDatosExtra">
                        <br />
                        <hr />
                        <br />
                        <asp:Label ID="lblHeader_extra" class="CuadroTituloExtra" runat="server" Width="700px">Por Favor, Ingrese los Siguientes Datos de la Entidad</asp:Label>
                        <table cellspacing="10px">
                            <uc2:ucDomicilioReal ID="ucDomicilioRealN" runat="server" />
                            <%-- Empieza pedido del CUIT de la Entidad si no esta en la base --%>
                            <div id="divcuitentidad" runat="server" visible="false">
                                <uc3:ucCUIT ID="ucCUITN" runat="server" />
                            </div>
                            <%-- Termina pedido del CUIT de la Entidad si no esta en la base --%>
                        </table>
                    </div>
                </div>
                <%-- Termina pedido de Sede Social y/o Nro de CUIT (Si no se encuentra) para busqueda por Numero Correlativo --%>
                <div id="divcaptchaentidad" runat="server" class="DJCuadroCentroCaptcha">
                    <%-- Empieza Captcha --%>
                    <uc1:ucCaptcha ID="ucCaptchaEntidad" runat="server" Visible="true" />
                    <%-- Termina Captcha --%>
                    <asp:ImageButton ID="btnBuscarNroCorr" runat="server" class="btnBuscarNroCorr" ImageUrl="~/App_Theme/Imagenes/btnBuscar.png"
                        OnClick="btnBuscarNroCorr_Click" AutoPostBack="True" />
                    <br />
                    <br />
                    <asp:Label ID="lblBuscarRazonSoc" runat="server" class="lblBuscarRazonSoc"><B>NOTA:</B> Si no recuerda el n&uacute;mero correlativo puede utilizar la siguiente <a href="http://www2.jus.gov.ar/igj-vistas/Busqueda.aspx" target="_blank">B&uacute;squeda de Sociedades</a></asp:Label>
                </div>
                <%--<div class="DJCuadroCentro">
                <br />
                <asp:Label ID="lblBuscRazonSoc" runat="server" style="margin-left:-40px;" Width="500px" Font-Size="10px">Si no recuerda el n&uacute;mero correlativo puede utilizar la siguiente <a href="http://www2.jus.gov.ar/igj-vistas/Busqueda.aspx" target="_blank">B&uacute;squeda de Sociedades</a></asp:Label>
                </div>--%>
                <div class="DJCuadroFooter">
                    <asp:Image ID="ImgFooter_2" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroFooterG.png" />
                </div>
                <br />
            </asp:Panel>
            <%-- Termina Busqueda de Entidad por Nro Correlativo --%>
            <%-- Empieza Busqueda de Entidad por CUIT --%>
            <asp:Panel ID="pnlwfk_3" runat="server" BackImageUrl="/imagenes/" Visible="False">
                <div class="DJCuadroHeader">
                    <asp:Image ID="ImgHeader_3" class="CuadroHeader" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroHeaderG.png" />
                    <asp:Label ID="LblTitulo_3" class="CuadroTitulo" runat="server" Width="700px">B&uacute;squeda de Entidad Constituida por N&uacute;mero de CUIT</asp:Label>
                    <br />
                </div>
                <div class="DJCuadroCentro">
                    <%-- Empieza Busqueda de Entidades --%>
                    <table cellspacing="10px">
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblCUIT" runat="server" Width="210px">N&uacute;mero de CUIT</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtCUIT" class="txtNroCorr txteffect" runat="server" MaxLength="12"
                                    Width="180px" Height="24px"></asp:TextBox>
                                <asp:CustomValidator ID="cvCUIT" runat="server" ErrorMessage="*" ControlToValidate="txtCUIT"
                                    Display="Dynamic" EnableClientScript="False" OnServerValidate="CustomValidator_Standar"
                                    ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                                <asp:CustomValidator ID="cvNoExisteCUIT" runat="server" ErrorMessage="El N&uacute;mero de CUIT no se corresponde a una Entidad existente"
                                    Display="Dynamic" EnableClientScript="False" CssClass="imgCruz"></asp:CustomValidator>
                            </td>
                        </tr>
                        <div id="divTipoDeEntidadC_CUIT" runat="server" visible="true">
                            <tr>
                                <td>
                                    <asp:Label ID="lblTipoDeEntidadConstituida_CUIT" runat="server" Width="210px">Tipo de Entidad</asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlTipoDeEntidadConstituida_CUIT" class="ddleffect" runat="server"
                                        AutoPostBack="True" DataTextField="Descripcion" DataValueField="Codigo" Enabled="false">
                                    </asp:DropDownList>
                                    <asp:CustomValidator ID="cvTipoDeEntidadConstituida_CUIT" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;"
                                        ControlToValidate="ddlTipoDeEntidadConstituida_CUIT" Display="Dynamic" EnableClientScript="False"
                                        OnServerValidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                                    <br />
                                </td>
                            </tr>
                        </div>
                        <%-- Empieza Datos Referenciales de la Entidad --%>
                        <div id="divdatosentidad_CUIT" runat="server" visible="false">
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblEntidadC_CUIT" runat="server" Width="180px">Denominaci&oacute;n de la Entidad</asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtEntidadC_CUIT" runat="server" Width="300px" Style="text-align: left;"
                                        class="txtreferencial" Enabled="false"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblTipoSocietario_CUIT" runat="server" Width="180px">Tipo Societario</asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtTipoSocietario_CUIT" runat="server" Width="250px" Style="text-align: left;"
                                        class="txtreferencial" Enabled="false"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">
                                    <asp:ImageButton ID="btnBuscarCUITOtra" runat="server" class="btnBuscarNroCorr" ImageUrl="~/App_Theme/Imagenes/btnbuscarnueva.png"
                                        OnClick="btnBuscarNroCUITOtra_Click" AutoPostBack="True" />
                                </td>
                            </tr>
                        </div>
                    </table>
                </div>
                <%-- Termina Datos Referenciales de la Entidad --%>
                <%-- Empieza pedido de Sede Social para busqueda por CUIT --%>
                <div id="divdatosextra_CUIT" runat="server" visible="false">
                    <div class="DJCuadroCentro DJDatosExtra">
                        <br />
                        <hr />
                        <br />
                        <asp:Label ID="lblHeader_extraC" class="CuadroTituloExtra" runat="server" Width="700px">Por Favor, Ingrese los Siguientes Datos de la Entidad</asp:Label>
                        <table cellspacing="10px">
                            <uc2:ucDomicilioReal ID="ucDomicilioRealC" runat="server" />
                        </table>
                    </div>
                </div>
                <%-- Termina pedido de Sede Social para busqueda por CUIT --%>
                <div id="divcaptchaentidad_CUIT" runat="server" class="DJCuadroCentroCaptcha">
                    <%-- Empieza Captcha --%>
                    <uc1:ucCaptcha ID="ucCaptchaEntidad_CUIT" runat="server" Visible="true" />
                    <%-- Termina Captcha --%>
                    <asp:ImageButton ID="btnBuscarCUIT" runat="server" class="btnBuscarNroCorr" ImageUrl="~/App_Theme/Imagenes/btnBuscar.png"
                        OnClick="btnBuscarNroCuit_Click" AutoPostBack="True" />
                    <caption>
                        <br />
                        <br />
                        <%--<asp:Label ID="lblBuscarRazonSoc_CUIT" runat="server" class="lblBuscarRazonSoc"><B>NOTA:</B> Si no recuerda el CUIT puede utilizar la siguiente <a href="http://www2.jus.gov.ar/igj-vistas/Busqueda.aspx" target="_blank">B&uacute;squeda de Sociedades</a></asp:Label>--%>
                    </caption>
                </div>
                <div class="DJCuadroFooter">
                    <asp:Image ID="ImgFooter_3" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroFooterG.png" />
                </div>
                <br />
            </asp:Panel>
            <%-- Termina Busqueda de Entidad por CUIT --%>
            <%-- Empieza Botones Workflow de Busqueda de Entidad por CUIT --%>
            <asp:Panel ID="pnlwfk_botones" runat="server">
                <div class="WorkFlowButtons">
                    <asp:ImageButton ID="btnVolver" runat="server" alt="" class="btnVolverEF" ImageUrl="~/App_Theme/Imagenes/btnvacio.png"
                        OnClick="btnVolver_Click" />
                    &nbsp;&nbsp;
                    <asp:ImageButton ID="btnContinuar" runat="server" alt="" class="btnContinuarEF" ImageUrl="~/App_Theme/Imagenes/btnvacio.png"
                        OnClick="btnContinuar_Click" />
                </div>
            </asp:Panel>
            <%-- Termina Botones Workflow de Entidad Busqueda de Entidad por CUIT --%>
        </ContentTemplate>
        <Triggers>
            <%--<asp:AsyncPostBackTrigger ControlID="btnBuscarNroCorrelativo" EventName="Click" />--%>
            <asp:AsyncPostBackTrigger ControlID="btnBuscarNroCorr" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnBuscarNroCorrOtra" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="rblBusqueda" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
    <br />
</asp:Content>
