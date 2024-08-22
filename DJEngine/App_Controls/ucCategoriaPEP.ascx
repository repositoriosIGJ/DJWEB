<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCategoriaPEP.ascx.cs" Inherits="DJEngine.App_Controls.ucCategoriaPEP" %>
        <tr>
            <td>
                <asp:Label ID="lblCategoriaPEP" runat="server" Width="210px"> Tipo de persona Politicamente expuesta</asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlCategoriaPEP" class="ddleffect" runat="server" Width="350px" DataTextField="DescripcionCorta" DataValueField="Codigo" AutoPostBack="true" onselectedindexchanged="ddlCategoriaPEP_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:CustomValidator ID="cvCategoriaPEP" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" 
                    ControlToValidate="ddlCategoriaPEP" Display="Dynamic" EnableClientScript="False" 
                    onservervalidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                <br />
            </td>
        </tr>
        <tr ID="trSubCategoriaPEP" runat="server">
            <td>
                <asp:Label ID="lblSubCategoriaPEP" runat="server" Width="210px"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlSubCategoriaPEP" class="ddleffect" runat="server" Width="350px" DataTextField="DescripcionCorta" DataValueField="Codigo" AutoPostBack="false">
                </asp:DropDownList>
                <asp:CustomValidator ID="cvSubCategoriaPEP" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" 
                    ControlToValidate="ddlSubCategoriaPEP" Display="Dynamic" EnableClientScript="False" 
                    onservervalidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                <br />
            </td>
        </tr>
 