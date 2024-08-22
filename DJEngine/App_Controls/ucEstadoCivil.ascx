<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucEstadoCivil.ascx.cs" Inherits="DJEngine.App_Controls.ucEstadoCivil" %>
        <tr>
            <td align="right">
                <asp:Label ID="lblEstadoCivil" runat="server" Width="210px">Estado Civil</asp:Label>
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlEstadoCivil" class="ddleffect" runat="server" Width="280px" DataTextField="Descripcion" DataValueField="Codigo" AutoPostBack="false">
                </asp:DropDownList>
                <asp:CustomValidator ID="cvEstadoCivil" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" 
                    ControlToValidate="ddlEstadoCivil" Display="Dynamic" EnableClientScript="False" 
                    onservervalidate="CustomValidator_EstadoCivil" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                <br />
            </td>
        </tr>