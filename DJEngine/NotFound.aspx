<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DJ.Master" AutoEventWireup="true" CodeBehind="NotFound.aspx.cs" Inherits="DJEngine.WebPages.NotFound" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MasterPage" runat="server">
        <%-- Empieza Panel de Pagina no Encontrada --%>
        <asp:Panel ID="pnlwfk_0" runat="server">
                <%--<div class="DJCuadroHeader">
                    <asp:Image ID="ImgHeader_0" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroHeaderG.png" />
                    <asp:Label ID="LblTitulo_0" class="CuadroTitulo" runat="server" Width="700px">Seleccione una Declaración Jurada</asp:Label>
                    <br />
                </div>--%> 
                <div class="DJCuadroCentro">                
                    <div class="DJCuadroSeleccion">
                    <center>
                         <table cellspacing="10px">
                            <tr>                                
                                <td>
                                    <br />
                                    <asp:Label ID="lblNotFound" runat="server" Width="500px">Lo sentimos, la p&aacute;gina solicitada<br />no ha sido encontrada</asp:Label>                                    
                                    <br />
                                    <br />
                                    <center>
                                    <asp:Image ID="imgNotFound" runat="server" ImageUrl="~/App_Theme/Imagenes/enconstruccion.png" /> 
                                    </center>
                                    <br />
                                    <br />
                                    <asp:Label ID="lblNotFoundb" runat="server" Width="500px" Font-Size="Medium">Por favor, vuelva a crear la declaraci&oacute;n jurada nuevamente desde el siguiente bot&oacute;n:</asp:Label>
                                </td>
                            </tr>
                         </table>
                         </center>
                     </div>
                </div>
                <%--<div class="DJCuadroFooter">
                    <asp:Image ID="ImgFooter_0" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroFooterG.png" />                    
                </div>--%> 
        </asp:Panel>        
        <%-- Termina Panel de Pagina no Encontrada --%>
            <%-- Empieza Botones Workflow --%>
            <asp:Panel ID="pnlwfk_botones" runat="server"> 
                <div class="WorkFlowButtons">
                <table>
                    <tr>
                        <td>                        
                            <asp:ImageButton ID="btnNuevaDJ" alt="NuevaDJ" class="btnNuevaDJ" runat="server" ImageUrl="~/App_Theme/Imagenes/btnnuevadj.png" onclick="btnNuevaDJ_Click" />                            
                        
                        </td>
                    </tr>
                </table>
                </div>
            </asp:Panel>
            <%-- Termina Botones Workflow --%>   
</asp:Content>
