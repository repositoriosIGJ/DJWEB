<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucFechaRub.ascx.cs" Inherits="DJEngine.App_Controls.ucFechaRub" %>
        <tr>
            <td align="right">
                <asp:Label ID="lblFechaRub" runat="server" Width="200px">Fecha</asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtFechaRub" class="txteffect datepicker" runat="server" Width="150px"></asp:TextBox>
                <asp:CustomValidator ID="cvFechaRub" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" 
                ControlToValidate="txtFechaRub" Display="Dynamic" EnableClientScript="False" 
                onservervalidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
            </td> 
        </tr>