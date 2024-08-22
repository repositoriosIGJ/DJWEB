<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucFiscal.ascx.cs" Inherits="DJEngine.App_Controls.ucFiscal" %>
        <%--<tr>
            <td>
                <asp:Label ID="lblNoPoseo" runat="server" Width="210px">No Poseo Identificaci&oacute;n Fiscal</asp:Label>
            </td>
            <td>
                <asp:CheckBox ID="chkNoPoseo" runat="server" oncheckedchanged="chkNoPoseo_CheckedChanged" AutoPostBack="true"/> <label style="font-size:10px">&nbsp;(Marcar solo en caso de ser extranjero y no poseer CUIT/CUIL/CDI)</label>
                <br />
            </td>
        </tr>--%>
        <tr ID="trTipoFiscal" runat="server">        
            <td align="right"> 
                <asp:Label ID="lblTipoFiscal" runat="server" Width="210px">Tipo de Identificaci&oacute;n Fiscal</asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlTipoFiscal" class="ddleffect" runat="server" Width="210px" DataTextField="Acronimo" DataValueField="Codigo" AutoPostBack="False"></asp:DropDownList>
                <asp:CustomValidator ID="cvTipoFiscal" runat="server" ErrorMessage="*" ControlToValidate="ddlTipoFiscal" Display="Dynamic" EnableClientScript="False" onservervalidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                <div id="divchkNoPoseo" runat="server" visible="true">
                    <asp:CheckBox ID="chkNoPoseo" runat="server" class="chkNoPoseo" oncheckedchanged="chkNoPoseo_CheckedChanged" AutoPostBack="true" Text="NO POSEO " Enabled="true"/>
                    <img alt="No Poseo" src="./App_Theme/Imagenes/imgAstAzul.png"/>                
                </div>
                <%--<br />--%>              
            </td>
        </tr>
        <tr ID="trNroFiscal" runat="server">
            <td align="right">
                <asp:Label ID="lblNroFiscal" runat="server" Width="210px">Numero de Identificaci&oacute;n Fiscal</asp:Label>
            </td>
            <td> 
                <asp:TextBox ID="txtNroFiscal" CssClass="txteffect" runat="server" Width="210px"></asp:TextBox>
                <asp:CustomValidator ID="cvNroFiscal" runat="server" ErrorMessage="*" 
                ControlToValidate="txtNroFiscal" Display="Dynamic" EnableClientScript="False" 
                onservervalidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
            </td>
        </tr>