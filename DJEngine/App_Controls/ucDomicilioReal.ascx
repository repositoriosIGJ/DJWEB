<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucDomicilioReal.ascx.cs" Inherits="DJEngine.App_Controls.ucDomicilioReal" %>
        <tr>
            <td align="right">
                <asp:Label ID="lblDomicilioReal" runat="server" Width="210px">Domicilio Real</asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtDomicilioReal" class="txteffect" runat="server" Width="350px"></asp:TextBox>
                <asp:CustomValidator ID="cvDomicilioReal" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" 
                ControlToValidate="txtDomicilioReal" Display="Dynamic" EnableClientScript="False" 
                onservervalidate="CustomValidator_DomicilioReal" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
            </td>
        </tr>
        <%--
        <tr>
            <td align="right">
                <asp:Label ID="lblCiudad" runat="server" Width="210px">Ciudad</asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtCiudad" class="txteffect" runat="server" Width="150px"></asp:TextBox>
                <asp:CustomValidator ID="cvCiudad" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" 
                ControlToValidate="txtCiudad" Display="Dynamic" EnableClientScript="False" 
                onservervalidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
            </td>
        </tr>
        --%>