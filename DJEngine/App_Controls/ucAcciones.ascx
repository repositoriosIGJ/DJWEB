<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucAcciones.ascx.cs" Inherits="DJEngine.App_Controls.ucAcciones" %>
        <body style="text-align: left">
        <tr ID="trTipoFiscal" >
            <td>
                <asp:Label ID="lblCantAcciones" runat="server" >Cantidad de Acciones</asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCantAcciones" class="txteffect" runat="server" Width="107px" ></asp:TextBox>
                <asp:CustomValidator ID="cvTipoFiscal0" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" 
                ControlToValidate="txtCantAcciones" Display="Dynamic" EnableClientScript="False" 
                onservervalidate="CustomValidator_Standar" 
    ValidateEmptyText="True" CssClass="imgAsterisco"></asp:CustomValidator>
                <br />
            </td>
        </tr>        
        <tr ID="trTipoFiscal" runat="server">        
            <td> 
                <asp:Label ID="lblDomicilio" runat="server" >Cantidad de Votos</asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCantVotos" class="txteffect" runat="server" Width="107px" ></asp:TextBox>
                <asp:CustomValidator ID="cvTipoFiscal" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" 
                ControlToValidate="txtCantVotos" Display="Dynamic" EnableClientScript="False" 
                onservervalidate="CustomValidator_Standar" 
    ValidateEmptyText="True" CssClass="imgAsterisco"></asp:CustomValidator>
                <br />
            </td>
        </tr>
        <tr ID="trNroFiscal" runat="server">
            <td>
                <asp:Label ID="lblNroFiscal" runat="server"  
                style="margin-right: 0px">Porcentaje</asp:Label>
            </td>
            <td> 
                <asp:TextBox ID="txtPorcentaje" runat="server" Width="97px" ></asp:TextBox>
                <asp:CustomValidator ID="cvNroFiscal" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" 
                ControlToValidate="txtPorcentaje" Display="Dynamic" EnableClientScript="False" 
                onservervalidate="CustomValidator_Standar" 
    ValidateEmptyText="True" CssClass="imgAsterisco"></asp:CustomValidator>
            </td>
        </tr>