<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DJ.Master" AutoEventWireup="true" CodeBehind="Legal.aspx.cs" Inherits="DJEngine.WebEntities.Legal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MasterPage" runat="server">
        <%-- Empieza Panel de Marco Legal --%>
        <asp:Panel ID="pnlwfk_0" runat="server">
                <div class="DJCuadroHeader">
                    <asp:Image ID="ImgHeader_0" class="CuadroHeader" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroHeaderG.png" />
                    <asp:Label ID="LblTitulo_0" class="CuadroTitulo" runat="server" Width="700px">Lea el Marco Legal de la Declaracion Jurada</asp:Label>
                    <br />
                </div>
                <div class="DJCuadroCentro"> 
                    <asp:Panel ID="pnlMarcoLegal" runat="server" Width="640px" Height="350px" ScrollBars="Vertical">                               
                        <div id="divMarcoLegal" runat="server" class="DJCuadroLegal">
                        </div>                                        
                    </asp:Panel>
                    <div>
                    <br />
                    <table cellspacing="10px">
                            <tr>
                                <td>
                                    <asp:Label ID="lblMarcoLegal" class="chkAceptar" runat="server" Width="280px">Manifiesto que he le&iacute;do el Marco Legal</asp:Label>
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkAceptar" runat="server" oncheckedchanged="chkAceptar_CheckedChanged" AutoPostBack="True"/>
                                    <%--<asp:CustomValidator ID="cvAceptar" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" 
                                    ControlToValidate="chkAceptar" Display="Dynamic" EnableClientScript="False" 
                                    onservervalidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgAsterisco"></asp:CustomValidator>--%>
                                    <br />
                                </td>
                            </tr>
                     </table>
                   </div>
                </div>
                <div class="DJCuadroFooter">
                    <asp:Image ID="ImgFooter_0" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroFooterG.png" />                    
                </div> 
        </asp:Panel>
        <%-- Termina Panel de Marco Legal --%>
        <%-- Empieza Botones Workflow --%>
        <asp:Panel ID="pnlwfk_botones" runat="server"> 
            <div class="WorkFlowButtons">
                <asp:ImageButton ID="btnVolver" runat="server" alt="" class="btnVolverEF" ImageUrl="~/App_Theme/Imagenes/btnvacio.png" onclick="btnVolver_Click" />
                &nbsp;&nbsp;
                <asp:ImageButton ID="btnContinuar" runat="server" alt="" class="btnContinuarEF" ImageUrl="~/App_Theme/Imagenes/btnvacio.png" onclick="btnContinuar_Click" />
                <%--<asp:ImageButton ID="btnContinuar" alt="Continuar" class="btnContinuar" runat="server" ImageUrl="~/App_Theme/Imagenes/btncontinuar.png" onclick="btnContinuar_Click" />--%>
            </div>
        </asp:Panel>
        <%-- Termina Botones Workflow --%>   
</asp:Content>
