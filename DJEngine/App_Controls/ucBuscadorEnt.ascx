<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucBuscadorEnt.ascx.cs" Inherits="DJEngine.App_Controls.ucBuscadorEnt" %>
    <%-- Empieza Busqueda de Entidades --%>
    <asp:UpdatePanel ID="updpnlBuscadorEnt" runat="server">
    <ContentTemplate>
    <table cellspacing="10px"> 
        <tr>
            <td align="right">
                <asp:Label ID="lblNroCorrelativo" runat="server" Width="210px">N&uacute;mero Correlativo</asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtNroCorrelativo" class="txtNroCorr txteffect" runat="server" MaxLength="12" Width="200px" Height="24px"></asp:TextBox>
                <asp:ImageButton ID="btnBuscarNroCorrelativo" runat="server" class="btnLupa" ImageUrl="~/App_Theme/Imagenes/imgLupa.png" onclick="btnBuscarNroCorrelativo_Click" AutoPostBack="True"/>
                <asp:CustomValidator ID="cvNroCorrelativo" runat="server" ErrorMessage="*" 
                ControlToValidate="txtNroCorrelativo" Display="Dynamic" EnableClientScript="False" 
                onservervalidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                <asp:CustomValidator ID="cvNoExiste" runat="server" 
                    ErrorMessage="No Encontro Sociedad o Entidad">*</asp:CustomValidator>
            </td>
        </tr>
        <div ID="DivCuadroNroCorrelativoError" runat="server" class="CuadroCaptchaError" Visible="false">
            <asp:Label ID="lblNroCorrelativoError" runat="server" class="lblCaptchaError" Text="&nbsp;El N&uacute;mero Correlativo no se corresponde a una Entidad existe&nbsp;" />                   
        </div>
        <div id="divdatosentidad" runat="server" visible="false"> 
            <tr>
                <td align="right">
                    <asp:Label ID="lblEntidad" runat="server" Width="210px">Denominaci&oacute;n de la Entidad</asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtEntidad" runat="server" Width="300px" style="text-align: left;" class="txtreferencial" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblTipoSocietario" runat="server" Width="210px">Tipo Societario</asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtTipoSocietario" runat="server" Width="250px" style="text-align: left;" class="txtreferencial" Enabled="false"></asp:TextBox>
                </td>
             </tr>
         </div>
         </table>
		<%-- Termina el Panel de Busqueda Avanzada de Entidades --%>
        </ContentTemplate>
        <Triggers>
              <asp:AsyncPostBackTrigger ControlID="btnBuscarNroCorrelativo" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>