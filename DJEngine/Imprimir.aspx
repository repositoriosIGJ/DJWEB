<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DJ.Master" AutoEventWireup="true" CodeBehind="Imprimir.aspx.cs" Inherits="DJEngine.WebPages.Imprimir" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MasterPage" runat="server">
            <%-- Empieza Formulario Referencial 1--%>           
            <asp:Panel ID="pnlref_1" runat="server">
                <div class="DJCuadroHeader">
                    <%--<asp:Image ID="ImgHeader_1" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroHeader.png" />--%>
                    <asp:Label ID="lblExito_1" class="CuadroExitoSinBack" runat="server" width="625px">La Declaraci&oacute;n Jurada fue procesada con &eacute;xito</asp:Label>
                    <br />
                    <br />
                    <%--<asp:Label ID="LblTit_1" class="CuadroTituloSinBack" runat="server" Width="625px">Datos de la Entidad</asp:Label>--%>
                </div>
            </asp:Panel>            
            <%-- Termina Formulario Referencial 1--%>
            <%-- Empieza Formulario 2--%>           
            <asp:Panel ID="pnlwfk_2" runat="server">    
                <div class="DJCuadroHeader">
                    <asp:Image ID="ImgHeader_2" class="CuadroHeader" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroHeader.png" />
                    <asp:Label ID="LblTitulo_2" class="CuadroTitulo" runat="server" Width="625px">Impresi&oacute;n de la Declaraci&oacute;n Jurada</asp:Label>
                </div>
                <div class="DJCuadroCentro">                   
                    <div class="DJCuadroPresen">
                        <table cellspacing="10px">
                            <tr>
                                <td>
                                    <asp:Image ID="ImgImprimir" runat="server" class="CambioDomDigDJDD" ImageUrl="~/App_Theme/Imagenes/snapdjdd.png" />
                                    <br />
                                </td>
                            </tr>
                        </table>
                        <br />
                    </div>                    
                </div>
                <div class="DJCuadroFooter">
                    <asp:Image ID="ImgFooter_2" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroFooter.png" />                    
                </div>
            <br />
            </asp:Panel>
            <%-- Termina Formulario 1--%>
            <%-- Empieza Botones Workflow --%>
            <asp:Panel ID="pnlwfk_botones" runat="server"> 
                <div class="WorkFlowButtons">
                    <table>
                        <%--<tr>
                            <td>
                                <asp:Label ID="lblReader" runat="server" Width="340px">Obtenga previamente Adobe Reader para poder<br />abrir e imprimir los formularios en formato "PDF"<br /> generados por las declaraciones juradas.</asp:Label>
                                <asp:ImageButton ID="ImgBtnReader" runat="server" ImageUrl="~/App_Theme/Imagenes/btnreader.jpg" onclick="ImgBtnReader_Click" OnClientClick="aspnetForm.target ='_blank';" />
                                <br />
                                <br />
                            </td>
                        </tr>--%>
                        <tr>
                            <td>
                            <br />
                                <asp:ImageButton ID="btnNuevaDJ" alt="NuevaDJ" class="btnNuevaDJ" runat="server" ImageUrl="~/App_Theme/Imagenes/btnnuevadj.png" onclick="btnNuevaDJ_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:ImageButton ID="btnDescargar" alt="Descargar" class="btnDescargar" runat="server" ImageUrl="~/App_Theme/Imagenes/btndescargar.png" onclick="btnDescargar_Click" />
                                <%--&nbsp;&nbsp;<asp:ImageButton ID="btnImprimir" alt="Imprimir" class="btnImprimir" runat="server" ImageUrl="~/App_Theme/Imagenes/btnimprimir.png" onclick="btnImprimir_Click" />--%>                    
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>            
            <%-- Termina Botones Workflow --%> 
</asp:Content>
