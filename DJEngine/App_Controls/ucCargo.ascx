<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCargo.ascx.cs" Inherits="DJEngine.App_Controls.ucCargo" %>
        <tr>
            <td align="right">
                <asp:Label ID="lblCargo" runat="server" Width="210px">Cargo en la Entidad</asp:Label>
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlCargo" class="ddleffect" runat="server" Width="280px" DataTextField="Descripcion" DataValueField="Codigo" AutoPostBack="False"></asp:DropDownList>
                <asp:CustomValidator ID="cvCargo" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" 
                ControlToValidate="ddlCargo" Display="Dynamic" EnableClientScript="False" 
                onservervalidate="CustomValidator_Cargo" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                <br />
            </td>
        </tr>
