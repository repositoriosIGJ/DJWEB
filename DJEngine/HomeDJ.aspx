<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DJ.Master" AutoEventWireup="true"
    CodeBehind="HomeDJ.aspx.cs" Inherits="DJEngine.WebEntities.HomeDJ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MasterPage" runat="server">
    <%-- Empieza Panel de Seleccion de DJs --%>
    <asp:Panel ID="pnlwfk_0" runat="server">
        <div id="DJMantenimiento" runat="server" visible="false">
            <center>
                <table cellspacing="10px">
                    <tr>
                        <td>
                            <br />
                            <br />
                            <asp:Label ID="lblNotFound" runat="server" CssClass="lblNotFound" Width="550px">Lo sentimos, la p&aacute;gina est&aacute; en mantenimiento</asp:Label>
                            <br />
                            <br />
                            <center>
                                <asp:Image ID="imgNotFound" runat="server" ImageUrl="~/App_Theme/Imagenes/enconstruccion.png" />
                            </center>
                            <br />
                            <br />
                            <asp:Label ID="lblNotFoundb" runat="server" Width="550px" CssClass="lblNotFound">Por favor, intente ingresar m&aacute;s tarde</asp:Label>
                        </td>
                    </tr>
                </table>
            </center>
        </div>
        <div class="DJCuadroCentro">
            <div class="DJCuadroSeleccion">
                <center>
                    <table cellspacing="10px">
                        <tr id="DJ01" runat="server" visible="false">
                            <td>
                                <asp:ImageButton ID="ImgDJ01" runat="server" ImageUrl="~/App_Theme/Imagenes/BannerDJ02.jpg"
                                    OnClick="ImgDJ01_Click" OnClientClick="aspnetForm.target ='_self';" Enabled="false" />
                                <br />
                                <br />
                            </td>
                        </tr>
                        <tr id="DJ02" runat="server" visible="false">
                            <td>
                                <asp:ImageButton ID="ImgDJ02" runat="server" ImageUrl="~/App_Theme/Imagenes/BannerDJ02.jpg"
                                    OnClick="ImgDJ02_Click" OnClientClick="aspnetForm.target ='_self';" Enabled="false" />
                                <br />
                                <br />
                            </td>
                        </tr>
                        <tr id="DJ03" runat="server" visible="false">
                            <td>
                                <asp:ImageButton ID="ImgDJ03" runat="server" ImageUrl="~/App_Theme/Imagenes/BannerDJ03.jpg"
                                    OnClick="ImgDJ03_Click" OnClientClick="aspnetForm.target ='_self';" Enabled="false" />
                                <br />
                                <br />
                            </td>
                        </tr>
                        <tr id="DJ04" runat="server" visible="false">
                            <td>
                                <asp:ImageButton ID="ImgDJ04" runat="server" ImageUrl="~/App_Theme/Imagenes/BannerDJ04.jpg"
                                    OnClick="ImgDJ04_Click" OnClientClick="aspnetForm.target ='_self';" Enabled="false" />
                                <br />
                                <br />
                            </td>
                        </tr>
                        <tr id="DJ05" runat="server" visible="false">
                            <td>
                                <asp:ImageButton ID="ImgDJ05" runat="server" ImageUrl="~/App_Theme/Imagenes/BannerDJ05.jpg"
                                    OnClick="ImgDJ05_Click" OnClientClick="aspnetForm.target ='_self';" Enabled="false" />
                            </td>
                        </tr>
                        <tr id="DJ06" runat="server" visible="false">
                            <td>
                                <asp:ImageButton ID="ImgDJ06" runat="server" ImageUrl="~/App_Theme/Imagenes/BannerDJ06.jpg"
                                    OnClick="ImgDJ06_Click" OnClientClick="aspnetForm.target ='_self';" Enabled="false" />
                            </td>
                        </tr>
                        <tr id="DJ07" runat="server" visible="false">
                            <td>
                                <asp:ImageButton ID="ImgDJ07" runat="server" ImageUrl="~/App_Theme/Imagenes/BannerDJ07.jpg"
                                    OnClick="ImgDJ07_Click" OnClientClick="aspnetForm.target ='_self';" Enabled="false" />
                            </td>
                        </tr>
                        <tr id="DJ08" runat="server" visible="false">
                            <td>
                                <asp:ImageButton ID="ImgDJ08" runat="server" ImageUrl="~/App_Theme/Imagenes/BannerDJ08.jpg"
                                    OnClick="ImgDJ08_Click" OnClientClick="aspnetForm.target ='_self';" Enabled="false" />
                            </td>
                        </tr>
                        <tr id="DJ09" runat="server" visible="false">
                            <td>
                                <asp:ImageButton ID="ImgDJ09" runat="server" ImageUrl="~/App_Theme/Imagenes/BannerDJ09.jpg"
                                    OnClick="ImgDJ09_Click" OnClientClick="aspnetForm.target ='_self';" Enabled="false" />
                            </td>
                        </tr>
                        <tr id="DJ10" runat="server" visible="false">
                            <td>
                                <asp:ImageButton ID="ImgDJ10" runat="server" ImageUrl="~/App_Theme/Imagenes/BannerDJ10.jpg"
                                    OnClick="ImgDJ10_Click" OnClientClick="aspnetForm.target ='_self';" Enabled="false" />
                            </td>
                        </tr>
                        <tr id="DJ11" runat="server" visible="false">
                            <td>
                                <asp:ImageButton ID="ImgDJ11" runat="server" ImageUrl="~/App_Theme/Imagenes/BannerDJ11.jpg"
                                    OnClick="ImgDJ11_Click" OnClientClick="aspnetForm.target ='_self';" Enabled="false" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                                <asp:Label ID="lblReader" runat="server" Visible="true" Width="340px">Obtenga previamente Adobe Reader para poder<br />abrir e imprimir los formularios en formato "PDF"<br /> generados por las declaraciones juradas.</asp:Label>
                                <asp:ImageButton ID="ImgBtnReader" runat="server" Visible="true" ImageUrl="~/App_Theme/Imagenes/btnreader.jpg"
                                    OnClick="ImgBtnReader_Click" OnClientClick="aspnetForm.target ='_blank';" />
                                <br />
                            </td>
                        </tr>
                    </table>
                </center>
            </div>
        </div>
    </asp:Panel>
    <%-- Termina Panel de Seleccion de DJs --%>
</asp:Content>
