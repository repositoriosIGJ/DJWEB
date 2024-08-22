<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMontosPesos.ascx.cs" Inherits="DJEngine.App_Controls.ucMontosPesos" %>
        <tr>
            <td>
                <asp:Label ID="lblMontoMoneda" runat="server" Width="210px">Monto</asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtMontoMoneda" class="txteffect" runat="server" Width="120px"></asp:TextBox>
                <asp:Label ID="lblPesosArg" runat="server" height="19px" Width="150px" style="margin-left:8px; font-size: 8pt; text-align:left; margin-top:2px;">($) Peso Argentino</asp:Label>
                <%--<asp:DropDownList ID="ddlMoneda" class="ddleffect" runat="server" height="19px" Width="150px" style="margin-left:8px; font-size: 8pt; background-color:#d2d2d2;" DataTextField="Descripcion" DataValueField="Codigo" AutoPostBack="true" onselectedindexchanged="ddlMoneda_SelectedIndexChanged"></asp:DropDownList>--%>
                <asp:CustomValidator ID="cvMontoMoneda" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;"
                    ControlToValidate="txtMontoMoneda" Display="Dynamic" EnableClientScript="False"
                    OnServerValidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                <br />
            </td>
        </tr>
        <%-- 
        <tr ID="trMontoPesos" runat="server">
            <td>
                <asp:Label ID="lblMontoPesos" runat="server" Width="210px">Monto en Pesos Arg.</asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtMontoPesos" class="txteffect" runat="server" Width="120px"></asp:TextBox>
                <asp:Label ID="lblPesosArg" runat="server" height="19px" Width="150px" style="margin-left:8px; font-size: 8pt; text-align:left; margin-top:2px;">($) Peso Argentino (segun BNA)</asp:Label>
                <asp:CustomValidator ID="cvMontoPesos" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;"
                    ControlToValidate="txtMontoPesos" Display="Dynamic" EnableClientScript="False"
                    OnServerValidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                <br />
            </td>
        </tr>--%>