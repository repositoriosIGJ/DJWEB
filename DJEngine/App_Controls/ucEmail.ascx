<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucEmail.ascx.cs" Inherits="DJEngine.App_Controls.ucEmail" %>
        <tr>
            <td align="right">
                <asp:Label ID="lblEmail" runat="server" Width="210px">Correo Electrónico</asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtEmail" CssClass="txteffect" runat="server" Width="280px" type="email"></asp:TextBox>
                <asp:CustomValidator ID="cvEmail" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" 
                ControlToValidate="txtEmail" Display="Dynamic" EnableClientScript="False" 
                onservervalidate="CustomValidator_Email" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
            </td>
        </tr>