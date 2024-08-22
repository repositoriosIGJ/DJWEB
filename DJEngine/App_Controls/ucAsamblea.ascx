<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucAsamblea.ascx.cs" Inherits="DJEngine.App_Controls.ucAsamblea" %>
        <tr>
            <td align="right">
                <asp:Label ID="lblAsamblea" runat="server" Width="210px">Tipo de Asamblea</asp:Label>
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlAsamblea" class="ddleffect" runat="server" Width="280px" DataTextField="Descripcion" DataValueField="Codigo" AutoPostBack="False"></asp:DropDownList>
                <asp:CustomValidator ID="cvAsamblea" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" 
                ControlToValidate="ddlAsamblea" Display="Dynamic" EnableClientScript="False" 
                onservervalidate="CustomValidator_Asamblea" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                <br />
            </td>
        </tr>
