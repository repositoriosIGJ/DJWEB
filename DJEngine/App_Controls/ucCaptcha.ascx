<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCaptcha.ascx.cs" Inherits="DJEngine.App_Controls.ucCaptcha" %>
<asp:UpdatePanel ID="updpnlCuadroCaptcha" runat="server">
    <ContentTemplate>
                <div class="CuadroCaptchaHeader">
                    <asp:Image ID="ImgHeader_Captcha" class="CuadroHeader" runat="server" ImageUrl="~/App_Theme/Imagenes/CuadroCaptchaHeader.png" />
                </div>
                <table class="CuadroCaptchaCentro" style="margin: -3px auto;">
                    <tr>        
                        <td> 
                            <div class="divimgCaptcha">                          
                            <asp:Image ID="imgCaptcha" class="imgCaptcha" runat="server" ImageUrl="~/imgCaptcha.aspx" />
                            </div>
                            <asp:Image ID="ImgSeparador" class="ImgSeparador" runat="server" ImageUrl="~/App_Theme/Imagenes/CuadroCaptchaCentro.png" />
                            <div class="divtxtucCaptcha">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtucCaptcha" runat="server" class="txtucCaptcha" Columns="10" MaxLength="6" />
                                            <asp:CustomValidator ID="cvCaptcha" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" 
                                            ControlToValidate="txtucCaptcha" Display="Dynamic" EnableClientScript="False" onservervalidate="CustomValidator_Captcha"
                                            ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="btnRecargarCaptcha" runat="server" alt="Recargar" CausesValidation="false" class="btnRecargar" ImageUrl="~/App_Theme/Imagenes/btnrecargarcaptcha.png" OnClick="btnRecargarCaptcha_Click" /><br />
                                            <asp:Image ID="btnInfoCaptcha" alt="Información" runat="server" CausesValidation="false" class="btnInfo" ImageUrl="~/App_Theme/Imagenes/btninfocaptcha.png" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
                <div ID="DivCuadroCaptchaError" runat="server" class="CuadroCaptchaError" Visible="false">
                    <asp:Label ID="lblCaptchaError" runat="server" class="lblCaptchaError" Text="&nbsp;El texto ingresado es incorrecto&nbsp;" />
                    <%--<asp:Image ID="ImgError_Captcha" runat="server" ImageUrl="~/App_Theme/Imagenes/CuadroCaptchaError.png" />--%>
                </div>
                <div class="CuadroCaptchaFooter">
                    <asp:Image ID="ImgFooter_Captcha" runat="server" ImageUrl="~/App_Theme/Imagenes/CuadroCaptchaFooter.png" />
                </div>
                <br />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnRecargarCaptcha" EventName="Click" />
    </Triggers>
</asp:UpdatePanel>
