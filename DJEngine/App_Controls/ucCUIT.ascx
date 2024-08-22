<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCUIT.ascx.cs" Inherits="DJEngine.App_Controls.ucCUIT" %>
        <tr>
            <td align="right">
                <asp:Label ID="lblCUIT" runat="server" Width="210px">N&uacute;mero de CUIT</asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtCUIT" class="txteffect" runat="server" MaxLength="12" Width="180px"></asp:TextBox>
                <asp:CustomValidator ID="cvCUIT" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" 
                ControlToValidate="txtCUIT" Display="Dynamic" EnableClientScript="False" 
                onservervalidate="CustomValidator_CUIT" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
            </td>
        </tr>