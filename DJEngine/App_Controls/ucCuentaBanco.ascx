<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCuentaBanco.ascx.cs"
    Inherits="DJEngine.App_Controls.ucCuentaBanco" %>
<tr>
    <td align="right">
        <asp:Label ID="lblEntBancaria" runat="server" Width="220px">Entidad Bancaria</asp:Label>
    </td>
    <td align="left">
        <asp:TextBox ID="txtEntBancaria" class="txteffect" runat="server" Width="150px"></asp:TextBox>
        <asp:CustomValidator ID="cvEntBancaria" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;"
            ControlToValidate="txtEntBancaria" Display="Dynamic" EnableClientScript="False"
            OnServerValidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
        <br />
    </td>
</tr>
<tr>
    <td align="right">
        <asp:Label ID="lblTipoCuenta" runat="server" Width="220px">Tipo de Cuenta</asp:Label>
    </td>
    <td align="left">
        <asp:DropDownList ID="ddlTipoCuenta" class="ddleffect" runat="server" Width="280px"
            DataTextField="Descripcion" DataValueField="Codigo" AutoPostBack="false" OnSelectedIndexChanged="ddlTipoCuenta_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:CustomValidator ID="cvTipoCuenta" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;"
            ControlToValidate="ddlTipoCuenta" Display="Dynamic" EnableClientScript="False"
            OnServerValidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
        <br />
    </td>
</tr>
<tr>
    <td align="right">
        <asp:Label ID="lblNroCuenta" runat="server" Width="220px">Numero de Cuenta</asp:Label>
    </td>
    <td align="left">
        <asp:TextBox ID="txtNroCuenta" class="txteffect" runat="server" Width="170px"></asp:TextBox>
        <asp:CustomValidator ID="cvNroCuenta" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;"
            ControlToValidate="txtNroCuenta" Display="Dynamic" EnableClientScript="False"
            OnServerValidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
        <br />
    </td>
</tr>
