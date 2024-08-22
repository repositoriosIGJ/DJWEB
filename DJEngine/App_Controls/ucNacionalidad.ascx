<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucNacionalidad.ascx.cs" Inherits="DJEngine.App_Controls.ucNacionalidad" %>
    <tr>
            <td align="right">
                <asp:Label ID="lblNacionalidad" runat="server" Width="150px">Nacionalidad</asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtNacionalidad" class="txteffect" runat="server" Width="150px"></asp:TextBox>
                <asp:CustomValidator ID="cvNacionalidad" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" 
                ControlToValidate="txtNacionalidad" Display="Dynamic" EnableClientScript="False" 
                onservervalidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
            </td> 
        </tr>