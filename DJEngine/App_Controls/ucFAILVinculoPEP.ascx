<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucFAILVinculoPEP.ascx.cs" Inherits="DJEngine.App_Controls.ucFAILVinculoPEP" %>
        <tr>
            <td align="right">
                <asp:Label ID="lblVinculoPEP" runat="server" Width="210px">Vinculo/Relacion con la persona expuesta</asp:Label>
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlVinculoPEP" class="ddleffect" runat="server" Width="280px" DataTextField="Descripcion" DataValueField="Codigo" AutoPostBack="False"></asp:DropDownList>
                <asp:CustomValidator ID="cvVinculoPEP" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" 
                ControlToValidate="ddlVinculoPEP" Display="Dynamic" EnableClientScript="False" 
                onservervalidate="CustomValidator_VinculoPEP" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                <br />
            </td>
        </tr>
