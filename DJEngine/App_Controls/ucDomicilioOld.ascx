<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucDomicilioOld.ascx.cs" Inherits="DJEngine.App_Controls.ucDomicilioOld" %>
        <tr>
        <td style="text-align: left"><asp:Label ID="lblCiudad" runat="server" 
                Text="Ciudad"></asp:Label>
        </td>                            <td>
                                    <asp:TextBox ID="txtCiudad" runat="server" 
                Width="400px"></asp:TextBox>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    
            <asp:Label ID="lblCalle" runat="server" Text="Calle"></asp:Label>
&nbsp;</td><td style="text-align: left"><asp:TextBox ID="txtCalle" runat="server" Width="400px"></asp:TextBox></td></tr><tr><td>
                                    </td><tr>
                                <td style="text-align: left">
                                    
                                    <asp:Label ID="lblNumero" runat="server" 
                Text="Numero / Depto / Piso"></asp:Label></td><td align="center">
&nbsp;<asp:TextBox ID="txtNumero" runat="server" 
                Width="107px"></asp:TextBox></td></tr>
                <tr><td><asp:Label ID="lblCP" runat="server" 
                Text="Codigo Postal"></asp:Label>
                                </td>
                                <td style="text-align: left">
                                    
                                    
&nbsp;<asp:TextBox ID="txtCP" runat="server" 
                Width="87px"></asp:TextBox>
                                    
              </td></tr>