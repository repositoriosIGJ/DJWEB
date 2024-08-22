<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucFecha.ascx.cs" Inherits="DJEngine.App_Controls.ucFecha" %>
        <tr>
            <td align="right">
                <asp:Label ID="lblFecha" runat="server" Width="150px">Fecha</asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtFecha" class="txteffect datepicker" runat="server" Width="150px"></asp:TextBox>
                <asp:CustomValidator ID="cvFecha" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" 
                ControlToValidate="txtFecha" Display="Dynamic" EnableClientScript="False" 
                onservervalidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
            </td> 
        </tr>