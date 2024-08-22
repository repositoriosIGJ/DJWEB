<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DJ.Master" AutoEventWireup="true"
    CodeBehind="Libros.aspx.cs" Inherits="DJEngine.WebEntities.Libros" %>

<%@ Register Src="App_Controls/ucFechaRub.ascx" TagName="ucFechaRubrica" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MasterPage" runat="server">
    <%-- Termina Formulario Documento de Rubrica --%>
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
    <%-- Empieza Formulario Datos de Libros Rubricados --%>
    <%--<asp:CustomValidator ID="cvDocRubrica" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;"
                            ControlToValidate="ddlDocRubrica" Display="Dynamic" EnableClientScript="False"
                            OnServerValidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>--%>
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
    <%--<asp:CustomValidator ID="cvDenominacionRUB" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;"
                            ControlToValidate="txtDenominacionRUB" Display="Dynamic" EnableClientScript="False"
                            OnServerValidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>--%>
    <%--<asp:CustomValidator ID="cvNumeroRUB" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;"
                            ControlToValidate="txtNumeroRUB" Display="Dynamic" EnableClientScript="False"
                            OnServerValidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>--%>
    <%--<asp:CustomValidator ID="cvFoliosRUB" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;"
                            ControlToValidate="txtFoliosRUB" Display="Dynamic" EnableClientScript="False"
                            OnServerValidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>--%>
    <%-- Termina Formulario Datos de Libros Rubricados--%>
    <%-- Empieza Captcha --%>
    <asp:Panel ID="pnlwfk_3" runat="server">
        <div class="DJCuadroHeader">
            <asp:Image ID="ImgHeader_3" class="CuadroHeader" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroHeaderG.png" />
            <asp:Label ID="LblTitulo_3" class="CuadroTitulo" runat="server" Width="700px">Datos del Libro de Rúbrica</asp:Label>
        </div>
        <div class="DJCuadroCentro">
            <table cellspacing="10px">
                <tr>
                    <td align="right">
                        <asp:Label ID="lblDocRubrica" runat="server" Width="240px">Seleccione el Documento de Rúbrica</asp:Label>
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlDocRubrica" class="ddleffect" runat="server" Width="280px"
                            DataTextField="Descripcion" DataValueField="Codigo" AutoPostBack="True" OnSelectedIndexChanged="ddlDocRubrica_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:CustomValidator ID="cvDocRubrica" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;"
                            ControlToValidate="ddlDocRubrica" Display="Dynamic" EnableClientScript="False"
                            OnServerValidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                    </td>
                </tr>
            </table>
        </div>
        <div class="DJCuadroCentro">
            <table cellspacing="10px">
                <tr>
                    <td>
                        <asp:Label ID="lblDenominacionRUB" runat="server" Width="200px">Denominación</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDenominacionRUB" class="txteffect" runat="server" Width="240px"></asp:TextBox>
                        <asp:CustomValidator ID="cvDenominacionRUB" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;"
                            ControlToValidate="txtDenominacionRUB" Display="Dynamic" EnableClientScript="False"
                            OnServerValidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblNumeroRUB" runat="server" Width="200px">Numero de Rúbrica/RL</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNumeroRUB" class="txteffect" runat="server" Width="240px"></asp:TextBox>
                        <asp:CustomValidator ID="cvNumeroRUB" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;"
                            ControlToValidate="txtNumeroRUB" Display="Dynamic" EnableClientScript="False"
                            OnServerValidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                        <br />
                    </td>
                </tr>
                <uc2:ucFechaRubrica ID="ucFechaRUB" runat="server" />
                <tr>
                    <td>
                        <asp:Label ID="lblFoliosRUB" runat="server" Width="200px">Folios</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFoliosRUB" class="txteffect" runat="server" Width="170px"></asp:TextBox>
                        <asp:CustomValidator ID="cvFoliosRUB" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;"
                            ControlToValidate="txtFoliosRUB" Display="Dynamic" EnableClientScript="False"
                            OnServerValidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:ImageButton ID="btnGuardar" runat="server" CssClass="btnGuardarRubrica" alt="Guardar"
                            class="btnVolver" ImageUrl="~/App_Theme/Imagenes/btnguardar.png" OnClick="btnGuardar_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="DJCuadroFooter">
            <asp:Image ID="ImgFooter_3" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroFooterNC.png" />
        </div>
        <asp:GridView ID="grdLibros" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
            AutoGenerateColumns="False">
            <RowStyle Font-Size="Small" BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:BoundField DataField="doc" HeaderText="Documento" />
                <asp:BoundField DataField="den" HeaderText="Denominación" />
                <asp:BoundField DataField="nru" HeaderText="Nro Rúbrica/RL" />
                <asp:BoundField DataField="fru" HeaderText="Fec Rúbrica/Reg LD" />
                <asp:BoundField DataField="fol" HeaderText="Folios" />
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle Font-Size="Small" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle Font-Size="Small" BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        <br />
        <br />
    </asp:Panel>
    <%-- Termina Formulario Datos de Libros Rubricados--%>
    <%-- Empieza Botones Workflow --%>
    <asp:Panel ID="pnlwfk_botones" runat="server">
        <div class="WorkFlowButtons">
            <asp:ImageButton ID="btnVolver" runat="server" alt="" class="btnVolverEF" ImageUrl="~/App_Theme/Imagenes/btnvacio.png"
                OnClick="btnVolver_Click" />
            &nbsp;&nbsp;
            <asp:ImageButton ID="btnContinuar" runat="server" alt="" class="btnContinuarEF" ImageUrl="~/App_Theme/Imagenes/btnvacio.png"
                OnClick="btnContinuar_Click" />
        </div>
    </asp:Panel>
    <%-- Termina Botones Workflow --%>
    <br />
</asp:Content>
