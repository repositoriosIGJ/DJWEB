<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucDocRubrica.ascx.cs"
    Inherits="DJEngine.App_Controls.ucDocRubrica" %>
<tr>
    <td align="right">
        <asp:Label ID="lblDocRubrica" runat="server" Width="210px">Documento de Rubrica</asp:Label>
    </td>
    <td align="left">
        <asp:DropDownList ID="ddlDocRubrica" class="ddleffect" runat="server" Width="280px"
            DataTextField="Descripcion" DataValueField="Codigo" AutoPostBack="False">
        </asp:DropDownList>
        <asp:CustomValidator ID="cvDocRubrica" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;"
            ControlToValidate="ddlDocRubrica" Display="Dynamic" EnableClientScript="False"
            OnServerValidate="CustomValidator_DocRubrica" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
        <br />
    </td>
</tr>
