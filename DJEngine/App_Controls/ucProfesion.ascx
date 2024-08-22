<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucProfesion.ascx.cs" Inherits="DJEngine.App_Controls.ucProfesion" %>

 <tr>
            <td align="right">
                <asp:Label ID="lblProfesion" runat="server" Width="150px">Profesion</asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtProfesion" class="txteffect" runat="server" Width="150px"></asp:TextBox>
                <asp:CustomValidator ID="cvProfesion" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" 
                ControlToValidate="txtProfesion" Display="Dynamic" EnableClientScript="False" 
                onservervalidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
            </td> 
        </tr>