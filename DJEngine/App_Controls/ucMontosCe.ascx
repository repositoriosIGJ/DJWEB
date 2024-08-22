<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMontosCe.ascx.cs" Inherits="DJEngine.App_Controls.ucMontosCe" %>
        <tr>
            <td>
                <asp:Label ID="lblMontoCe" runat="server" Width="210px">Monto</asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtMontoCe" class="txteffect" runat="server" Width="120px"></asp:TextBox>
                <asp:Label ID="lblPesosArg" runat="server" height="19px" Width="150px" style="margin-left:8px; font-size: 8pt; text-align:left; margin-top:2px;">($) Peso Argentino</asp:Label>
                <asp:CustomValidator ID="cvMontoCe" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;"
                    ControlToValidate="txtMontoCe" Display="Dynamic" EnableClientScript="False"
                    OnServerValidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                <br />
            </td>
        </tr>