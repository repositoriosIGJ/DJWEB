<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucValores.ascx.cs" Inherits="DJEngine.App_Controls.ucValores" %>
<asp:UpdatePanel ID="updpnlValores" runat="server">
    <ContentTemplate>
        <table cellspacing="10px">
            <tr>
                <td>
                    <asp:Label ID="lblCantidad" runat="server" Width="210px">Cantidad</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCantidad" class="txteffect" runat="server" Width="150px" style="margin-right: 100px;"></asp:TextBox>
                    <asp:CustomValidator ID="cvCantidad" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;"
                        ControlToValidate="txtCantidad" Display="Dynamic" EnableClientScript="False"
                        OnServerValidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblValCorUni" runat="server" Width="210px">Valor Corriente Unitario</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtValCorUni" class="txteffect" runat="server" Width="150px"></asp:TextBox>
                    <asp:CustomValidator ID="cvValCorUni" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;"
                        ControlToValidate="txtValCorUni" Display="Dynamic" EnableClientScript="False"
                        OnServerValidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:ImageButton ID="btnCalcular" runat="server" alt="Calcular" class="btnCalcularEF"
                        CausesValidation="false" ImageUrl="~/App_Theme/Imagenes/btnvacio.png" OnClick="btnCalcular_Click"
                        AutoPostBack="True" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblValCorTot" runat="server" Width="210px">Valor Corriente Total</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtValCorTot" class="txtreferencial" Style="text-align: left;" runat="server"
                        Width="150px" disabled="disabled"></asp:TextBox>
                    <%--disabled="disabled"--%>
                    <asp:CustomValidator ID="cvValCorTot" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;"
                        ControlToValidate="txtValCorTot" Display="Dynamic" EnableClientScript="False"
                        OnServerValidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                    <br />
                </td>
            </tr>
            <tr>
                <td colspan="2" Style="text-align:center">
                    <asp:Label ID="lblValoresError" runat="server" class="NotaValoresError" Visible="false" Width="250px"
                        Text="&nbsp;El Valor Unitario deber contener un maximo de 13 digitos y 2 decimales.&nbsp;" />
                </td>
            </tr>
        </table>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnCalcular" EventName="Click" />
    </Triggers>
</asp:UpdatePanel>
