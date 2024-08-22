<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucFechaNac.ascx.cs" Inherits="DJEngine.App_Controls.ucFechaNac" %>
        <tr>
            <td align="right">
                <asp:Label ID="lblFechaNac" runat="server" Width="150px">Fecha de Nacimiento</asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtFechaNac" class="txteffect datepicker" runat="server" Width="150px"></asp:TextBox>
                <asp:CustomValidator ID="cvFechaNac" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" 
                ControlToValidate="txtFechaNac" Display="Dynamic" EnableClientScript="False" 
                onservervalidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
            </td> 
        </tr>