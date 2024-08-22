<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucDocumento.ascx.cs" Inherits="DJEngine.App_Controls.ucDocumento" %>
        <tr>
            <td align="right">
                <asp:Label ID="lblTipoDoc" runat="server" Width="210px">Tipo de Documento</asp:Label>
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlTipoDoc" class="ddleffect" runat="server" Width="280px" DataTextField="Descripcion" DataValueField="Codigo" AutoPostBack="false">
                </asp:DropDownList>
                <asp:CustomValidator ID="cvTipoDoc" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" 
                    ControlToValidate="ddlTipoDoc" Display="Dynamic" EnableClientScript="False" 
                    onservervalidate="CustomValidator_TipoDoc" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                <br />
            </td>
        </tr>                            
        <tr>
            <td align="right">
                <asp:Label ID="lblNroDoc" runat="server" Width="210px">N&uacute;mero de Documento</asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtNroDoc" class="txteffect" runat="server" Width="150px"></asp:TextBox>
                <asp:CustomValidator ID="cvNroDoc" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" 
                ControlToValidate="txtNroDoc" Display="Dynamic" EnableClientScript="False" 
                onservervalidate="CustomValidator_NroDoc" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
            </td>
        </tr>
