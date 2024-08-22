<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucDomicilio.ascx.cs" Inherits="DJEngine.App_Controls.ucDomicilio" %>
        <tr>
            <td align="right">
                <asp:Label ID="lblDomicilio" runat="server" Width="210px">Domicilio Real</asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtDomicilio" class="txteffect" runat="server" Width="280px"></asp:TextBox>
                <asp:CustomValidator ID="cvDomicilio" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" 
                ControlToValidate="txtDomicilio" Display="Dynamic" EnableClientScript="False" 
                onservervalidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
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