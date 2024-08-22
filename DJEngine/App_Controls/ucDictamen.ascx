<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucDictamen.ascx.cs" Inherits="DJEngine.App_Controls.ucDictamen" %>
        <tr>
            <td align="right">
                <asp:Label ID="lblDictamen" runat="server" Width="210px">Dictamen</asp:Label>
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlDictamen" class="ddleffect" runat="server" Width="280px" DataTextField="Descripcion" DataValueField="Codigo" AutoPostBack="False"></asp:DropDownList>
                <asp:CustomValidator ID="cvDictamen" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" 
                ControlToValidate="ddlDictamen" Display="Dynamic" EnableClientScript="False" 
                onservervalidate="CustomValidator_Dictamen" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                <br />
            </td>
        </tr>
