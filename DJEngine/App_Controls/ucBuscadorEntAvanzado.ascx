<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucBuscadorEntAvanzado.ascx.cs" Inherits="DJEngine.App_Controls.ucBuscadorEnt" %>
    <%-- Empieza Busqueda de Entidades --%>
    <asp:UpdatePanel ID="updpnlBuscadorEnt" runat="server">
    <ContentTemplate>
                <div class="CuadroBusEntHeader">
                    <asp:Image ID="ImgHeader_BusEnt" class="CuadroHeader" runat="server" ImageUrl="~/App_Theme/Imagenes/CuadroBusEntHeader.jpg" />
                </div>
                <div class="CuadroBusEntCentro">
                    <div class="DatosEntidad">
                        &nbsp;<img alt="Usuario" src="../App_Theme/Imagenes/iconousuario.jpg"/>
                        <asp:Label ID="lblNomEnt" class="lblNomEnt tooltip" runat="server" Text="Label" title="[!]Razón Social[/!] A.P.B.A ASSOCIAZIONE PUGLIESE DI BUENOS AIRES E GRAN BS AS.">Nombre de la Entidad</asp:Label> <%--title="[!]Razón Social[/!] Nombre de la Entidad."--%>
                        &nbsp;&nbsp;<img alt="Tipo Societario" src="../App_Theme/Imagenes/iconotiposoc.jpg"/>
                        <asp:Label ID="lblTpoSoc" runat="server" Text="Label">Tipo Societario</asp:Label>
                    </div>
                    <br class="brchico">
                    <asp:TextBox ID="txtNroCorrelativo" class="txtNroCorr txteffect" runat="server" Width="200px" Height="24px" AutoPostBack="True" value="Numero Correlativo" MaxLength="10" onfocus="if(this.value==this.defaultValue)this.value='';" onblur="if(this.value=='')this.value=this.defaultValue;" ></asp:TextBox>
                    <asp:ImageButton ID="btnBuscarNroCorrelativo" runat="server" class="btnLupa" ImageUrl="~/App_Theme/Imagenes/imgLupa.png" onclick="btnBuscarNroCorrelativo_Click" AutoPostBack="True"/>
                    <asp:RangeValidator ID="rnvbtnBuscarNroCorrelativo" runat="server" 
                        ErrorMessage="Debe ser un número superior a 10000" 
                        ControlToValidate="txtNroCorrelativo" MaximumValue="9999999" MinimumValue="10" 
                        Font-Names="Arial" Type="Double" Font-Bold="true" Font-Size="14px" 
                        EnableClientScript="False">x</asp:RangeValidator>      
                    <%--<asp:ImageButton ID="btnBusquedaAvanzada" runat="server" 
                        class="btnBusquedaAvanzada" ImageUrl="~/App_Theme/Imagenes/imgMas.png" 
                        alt="Busqueda Avanzada" CausesValidation="false"
                        onclick="btnBusquedaAvanzada_Click"/>--%>
                </div>               
                <div class="CuadroBusEntFooter">
                    <asp:Image ID="ImgFooter_BusEnt" runat="server" ImageUrl="~/App_Theme/Imagenes/CuadroBusEntFooter.jpg" />
                </div>                
                <br />
                <%-- Termina Busqueda de Entidades --%>
                <%-- Empieza el Panel de Busqueda Avanzada de Entidades --%>
                <%--<div id="DivFlotante" runat="server" class="CuadroBusEntAvanCentro" visible="false">
			        <asp:Panel ID="pnlBuscadorAvanzado" runat="server" class="pnlBuscadorAvanzado" Visible="false">
				        <table>   		                                            
                            <tr>
                                <td>
                                    <asp:Label ID="lblRazonSocial" runat="server" Width="90px">R&aacute;zon Social</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRazonSocial" runat="server" class="txteffect" MaxLength="20" Width="160px"></asp:TextBox>
                                    <%--<asp:CheckBox ID="chkEnAlguna" runat="server" class="chkFrase" AutoPostBack="true" Text="Solo parte de la frase"/>
                                    <img alt="No Poseo" src="../App_Theme/Imagenes/imgAstAzul.png"/>--%>                                                            
                                    <%--<asp:CustomValidator ID="cvNroDoc" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" 
                                    ControlToValidate="txtNroDoc" Display="Dynamic" EnableClientScript="False" 
                                    onservervalidate="CustomValidator_NroDoc" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>--%>                                    
                                    <%--<asp:ImageButton ID="cmdBoton" runat="server" class="btnLupa" CausesValidation="False" ImageUrl="~/App_Theme/Imagenes/imgLupa.png" onclick="btnBuscar_Click" />                                           
                                </td>                                                        
                                <td>
                                    <asp:Label ID="lblTipoSoc" runat="server" Width="90px">Tipo Societario</asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlTipoSoc" class="ddleffect" runat="server" Width="210px" DataTextField="Descripcion" DataValueField="Codigo" AutoPostBack="false"></asp:DropDownList>
                                    <%--<asp:CustomValidator ID="cvTipoDoc" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" 
                                        ControlToValidate="ddlTipoDoc" Display="Dynamic" EnableClientScript="False" 
                                        onservervalidate="CustomValidator_TipoDoc" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>--%>
                                    <%--<br />
                                </td>
                            </tr>
                            <tr>
                            <td colspan="4" align="center">
                            <div ID="DivCuadroBusEntError" runat="server" class="CuadroBusEntError" Visible="false">
                                <asp:Label ID="lblBusEntError" runat="server" class="lblBusEntError" Text="&nbsp;&nbsp;" />                                
                            </div>
                            </td>
                            </tr>
                            <tr>
                                <td colspan="4" align="center">						            
						            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="updpnlBuscadorEnt" DisplayAfter="10">
							            <ProgressTemplate>
								            <img ID="imgProgressCircle" runat="server" alt="Buscando" src="~/App_Theme/Imagenes/IGJLoad.gif" /></ProgressTemplate>
						            </asp:UpdateProgress>					                
					            </td>
					        </tr>
			                <tr>
                                <td colspan="4" align="center">
                                    <asp:Panel ID="pnlGrilla" runat="server" ScrollBars="auto" Height="120px" Width="590px">
                                        <asp:GridView ID="gridSociedades" class="gridSociedades" runat="server" AutoGenerateColumns="False"
                                            OnSelectedIndexChanged="gridSociedades_SelectedIndexChanged" ShowHeader="False" 
                                            UseAccessibleHeader="False" Visible="False" CellPadding="3" EmptyDataText="No se Encontro Ninguna Sociedad" 
                                            GridLines="Vertical">
                                            <EmptyDataRowStyle Font-Size="20px" ForeColor="#303030" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Nro Correlativo" ItemStyle-CssClass="Columna1">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtNroCorrelativo" runat="server" Text='<%# Bind("NroCorrelativo") %>'></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <ItemStyle Width="20px" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkNroCorr" runat="server" CommandArgument='<%# Bind("NroCorrelativo") %>' OnClick="lnkNroCorr_Click" Text='<%# Bind("NroCorrelativo") %>'></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="TipoSoc" HeaderText="Tipo Societario" ItemStyle-CssClass="Columna2">
                                                        <ItemStyle HorizontalAlign="Center" Width="40px"/>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="RazonSocial" HeaderText="Razon Social" ItemStyle-CssClass="Columna3">
                                                        <ItemStyle Font-Bold="True" Width="240px" />
                                                    </asp:BoundField>
                                                </Columns>
                                            <RowStyle BackColor="#F7F6F3" Font-Size="Small" ForeColor="#333333" />
                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="XX-Small" ForeColor="White" />
                                            <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                            <EditRowStyle BackColor="#999999" />
                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        </asp:GridView>
                                    </asp:Panel>
                                </td>
                            </tr>
				        </table>
			        </asp:Panel>
		        </div>
		        <br />--%>
	
		        <%-- Termina el Panel de Busqueda Avanzada de Entidades --%>

        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnBuscarNroCorrelativo" EventName="Click" />
            <%--<asp:AsyncPostBackTrigger ControlID="btnBusquedaAvanzada" EventName="Click" />       
            <asp:AsyncPostBackTrigger ControlID="gridSociedades" />
            <asp:AsyncPostBackTrigger ControlID="btnBuscar" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="cmdBoton" EventName="Click" />--%>
        </Triggers>
</asp:UpdatePanel>