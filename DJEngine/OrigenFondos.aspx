<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DJ.Master" AutoEventWireup="true"
    CodeBehind="OrigenFondos.aspx.cs" Inherits="DJEngine.WebEntities.OrigenFondos" %>

<%@ Register Src="App_Controls/ucDocumento.ascx" TagName="ucDocumento" TagPrefix="uc1" %>
<%@ Register Src="App_Controls/ucFiscal.ascx" TagName="ucFiscal" TagPrefix="uc2" %>
<%@ Register Src="App_Controls/ucCaptcha.ascx" TagName="ucCaptcha" TagPrefix="uc3" %>
<%@ Register Src="App_Controls/ucFecha.ascx" TagName="ucFecha" TagPrefix="uc4" %>
<%@ Register Src="App_Controls/ucMontos.ascx" TagName="ucMontos" TagPrefix="uc5" %>
<%@ Register Src="App_Controls/ucValores.ascx" TagName="ucValores" TagPrefix="uc6" %>
<%@ Register Src="App_Controls/ucCuentaBanco.ascx" TagName="ucCuentaBanco" TagPrefix="uc7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MasterPage" runat="server">
    <contenttemplate>
    <%-- Empieza Panel de Personeria --%>
    <asp:Panel ID="pnlPFPJ" runat="server">
        <div class="DJCuadroHeader">
            <asp:Image ID="ImgHeader_1" class="CuadroHeader" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroHeaderG.png" />
            <asp:Label ID="lblHeader_1" class="CuadroTitulo" runat="server" Width="700px">Indique tipo de Personeria del Donante / Aportante</asp:Label>
        <br />
        </div>
        <div class="DJCuadroCentro">
            <div class="DJCuadroPEPoF">
                <asp:RadioButtonList ID="rblPFPJ" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblPFPJ_SelectedIndexChanged"
                    RepeatDirection="Horizontal">
                    <asp:ListItem Text="Persona Fisica" Value="1" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Persona Jurídica" Value="2"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </div>
        <div class="DJCuadroFooter">
            <asp:Image ID="ImgFooter_1" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroFooterG.png" />
        </div>
        <br />
    </asp:Panel>
    <%-- Termina Panel de Personeria --%>
    <%-- Empieza Panel de Validacion --%>
    <asp:Panel ID="pnlvalidacion" runat="server" Visible="false">
        <div class="divValidacion">
            <div class="DJValidHeader">
                <asp:Image ID="ImgHeader_val" class="CuadroHeader" runat="server" ImageUrl="~/App_Theme/Imagenes/DJValidHeader.png" />
                <asp:Label ID="LblTitulo_val" class="CuadroTitulo" runat="server" Width="700px">Por favor resuelva los siguientes errores</asp:Label>
            </div>
            <div class="DJValidCentro">
                <asp:ValidationSummary ID="vldsumValidSummary" runat="server" Width="650px" />
                </asp:ValidationSummary>
                <asp:Label ID="lblCaptchaErrorvld" class="CuadroTitulo" runat="server" Width="700px"
                    Visible="false">&#8226; [CODIGO DE VALIDACION] El texto ingresado es incorrecto, por favor vuelva a intentarlo nuevamente.</asp:Label>
            </div>
            <div class="DJValidFooter">
                <asp:Image ID="ImgFooter_val" runat="server" ImageUrl="~/App_Theme/Imagenes/DJValidFooter.png" />
            </div>
        </div>
        <br />
    </asp:Panel>
    <%-- Termina Panel de Validacion --%>
    <%-- Empieza Panel de Datos del Donante / Aportante Persona Fisica --%>
    <asp:Panel ID="pnlwfk_2" runat="server">
        <div class="DJCuadroHeader">
            <asp:Image ID="ImgHeader_2" class="CuadroHeader" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroHeaderG.png" />
            <asp:Label ID="LblTitulo_2" class="CuadroTitulo" runat="server" Width="700px">Datos del Donante / Aportante</asp:Label>
        </div>
        <div class="DJCuadroCentro">
            <%--<div class="DJCuadroPresen">--%>
            <table cellspacing="10px">
                <tr>
                    <td>
                        <asp:Label ID="lblNombrePF" runat="server" Width="210px">Nombre</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNombrePF" class="txteffect" runat="server" Width="150px"></asp:TextBox>
                        <asp:CustomValidator ID="cvNombrePF" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;"
                            ControlToValidate="txtNombrePF" Display="Dynamic" EnableClientScript="False"
                            OnServerValidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblApellidoPF" runat="server" Width="210px">Apellido</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtApellidoPF" class="txteffect" runat="server" Width="170px"></asp:TextBox>
                        <asp:CustomValidator ID="cvApellidoPF" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;"
                            ControlToValidate="txtApellidoPF" Display="Dynamic" EnableClientScript="False"
                            OnServerValidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                        <br />
                    </td>
                </tr>
                <uc1:ucDocumento ID="ucDocumentoPF" runat="server" />
                <uc2:ucFiscal ID="ucFiscalPF" runat="server" />
            </table>
            <br />
            <%--</div>--%>
        </div>
        <div class="DJCuadroFooter">
            <asp:Image ID="ImgFooter_2" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroFooterFiscal.png" />
        </div>
        <br />
    </asp:Panel>
    <%-- Termina Panel de Datos del Donante / Aportante Persona Fisica --%>
    <%-- Empieza Panel de Datos del Donante / Aportante Persona Juridica --%>
    <asp:Panel ID="pnlwfk_3" runat="server">
        <div class="DJCuadroHeader">
            <asp:Image ID="ImgHeader_3" class="CuadroHeader" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroHeaderG.png" />
            <asp:Label ID="LblTitulo_3" class="CuadroTitulo" runat="server" Width="700px">Datos del Donante / Aportante</asp:Label>
        </div>
        <div class="DJCuadroCentro">
            <div class="DJCuadroPresen">
                <table cellspacing="10px">
                    <tr>
                        <td>
                            <asp:Label ID="lblRazonSocPJ" runat="server" Width="180px">Razón Social</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRazonSocPJ" class="txteffect" runat="server" Width="220px"></asp:TextBox>
                            <asp:CustomValidator ID="cvRazonSocPJ" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;"
                                ControlToValidate="txtRazonSocPJ" Display="Dynamic" EnableClientScript="False"
                                OnServerValidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblCuitPJ" runat="server" Width="180px">N&uacute;mero de CUIT</asp:Label>
                        </td>
                        <td>
                            <%-- TextBox de Persona Juridica Nacional --%>
                            <asp:TextBox ID="txtCuitPJ" class="txteffect" runat="server" Width="170px" Visible="true" Enabled="true"></asp:TextBox>
                            <asp:CustomValidator ID="cvCuitPJ" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;"
                                ControlToValidate="txtCuitPJ" Display="Dynamic" EnableClientScript="False" OnServerValidate="CustomValidator_Standar"
                                ValidateEmptyText="True" CssClass="imgCruz" Visible="true" Enabled="true"></asp:CustomValidator>
                            <%-- TextBox de Persona Juridica Extranjera --%>
                            <asp:TextBox ID="txtCuitPJEXT" class="txteffect" runat="server" Width="170px" Visible="false" Enabled="false"></asp:TextBox>
                            <asp:CustomValidator ID="cvCuitPJEXT" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;"
                                ControlToValidate="txtCuitPJEXT" Display="Dynamic" EnableClientScript="False"
                                OnServerValidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz" Visible="false" Enabled="false"></asp:CustomValidator>
                            <%-- CheckBox de Persona Juridica Nacional/Extranjera --%>
                            <asp:CheckBox ID="chkCuitPJEXT" runat="server" class="chkNoPoseo" OnCheckedChanged="chkCuitPJEXT_CheckedChanged" AutoPostBack="true" Text="Entidad Extrajera " />
                            <img alt="Entidad Extranjera" src="./App_Theme/Imagenes/imgAstAzul.png" />
                            <br />
                        </td>
                    </tr>
                </table>
                <br />
            </div>
        </div>
        <div class="DJCuadroFooter">
            <asp:Image ID="ImgFooter_3" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroFooterEXT.png" />
        </div>
        <br />
    </asp:Panel>
    <%-- Termina Panel de Datos del Donante / Aportante Persona Juridica --%>
    <%-- Empieza Panel de Carácter de los Fondos --%>
    <asp:Panel ID="pnlwfk_4" runat="server">
        <div class="DJCuadroHeader">
            <asp:Image ID="ImgHeader_4" class="CuadroHeader" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroHeaderG.png" />
            <asp:Label ID="LblTitulo_4" class="CuadroTitulo" runat="server" Width="700px">Carácter de los Fondos</asp:Label>
        </div>
        <div class="DJCuadroCentro">
            <div class="DJCuadroPresen">
                <table cellspacing="10px">
                    <tr>
                        <td>
                            <asp:Label ID="lblCaracter" runat="server" Width="210px">Caracter de los Fondos</asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCaracter" class="ddleffect" runat="server" Width="280px"
                                DataTextField="Descripcion" DataValueField="Codigo">
                                <asp:ListItem Value="-1" Selected="True">&lt;&lt; SELECCIONAR OPCION &gt;&gt;</asp:ListItem>
                                <asp:ListItem Value="1">DONACION</asp:ListItem>
                                <asp:ListItem Value="2">APORTE DE TERCEROS</asp:ListItem>
                            </asp:DropDownList>
                            <asp:CustomValidator ID="cvCaracter" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;"
                                ControlToValidate="ddlCaracter" Display="Dynamic" EnableClientScript="False"
                                OnServerValidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblOrigen" runat="server" Width="210px">Origen de los Aportes</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtOrigen" class="txteffect" runat="server" Width="220px"></asp:TextBox>
                            <asp:CustomValidator ID="cvOrigen" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;"
                                ControlToValidate="txtOrigen" Display="Dynamic" EnableClientScript="False" OnServerValidate="CustomValidator_Standar"
                                ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                            <br />
                        </td>
                    </tr>
                    <uc4:ucFecha ID="ucFechaCF" runat="server" />
                </table>
                <br />
            </div>
        </div>
        <div class="DJCuadroFooter">
            <asp:Image ID="ImgFooter_4" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroFooterCOG.png" />
        </div>
        <br />
    </asp:Panel>
    <%-- Termina Panel de Carácter de los Fondos --%>
    <%-- Empieza Panel de Modo de Ingreso --%>
    <asp:Panel ID="pnlwfk_Modo" runat="server">
        <div class="DJCuadroHeader">
            <asp:Image ID="ImgHeader_Modo" class="CuadroHeader" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroHeaderG.png" />
            <asp:Label ID="LblTitulo_Modo" class="CuadroTituloV" runat="server" Width="700px">Indique el Tipo de Aporte/Donaci&oacute;n</asp:Label>
            <%--<asp:Label ID="LblTitulo_Modo" class="CuadroTituloV" runat="server" Width="700px">Indique el Modo de Ingreso de los Fondos</asp:Label>--%>
            <br />
        </div>
        <div class="DJCuadroCentro">
            <div class="DJCuadroPEPoF">
                <asp:RadioButtonList ID="rblModoIngreso" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblModoIngreso_SelectedIndexChanged"
                    RepeatDirection="Horizontal">
                    <asp:ListItem Text="Efectivo" Value="1" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Especie" Value="2"></asp:ListItem>
                    <%--<asp:ListItem Text="Ambos" Value="3"></asp:ListItem>--%>
                </asp:RadioButtonList>
            </div>
        </div>
        <div class="DJCuadroFooter">
            <asp:Image ID="ImgFooter_Modo" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroFooterG.png" />
        </div>
        <%--<br />--%>
    </asp:Panel>
    <%-- Termina Panel de Modo de Ingreso --%>
    <%-- Empieza Panel de Modo de Ingreso en Efectivo --%>
    <asp:Panel ID="pnlwfk_5efe" runat="server">
        <div class="DJCuadroHeader">
            <asp:Image ID="ImgHeader_5efe" class="CuadroHeader" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroHeaderG.png" />
            <asp:Label ID="LblTitulo_5efe" class="CuadroTituloV" runat="server" Width="700px">Ingreso de Fondos en Efectivo</asp:Label>
        </div>
        <%--<asp:Label ID="lblHeader_4b" class="CuadroTituloIntermedio" runat="server" Width="700px">Modo de Ingreso de los Fondos</asp:Label>--%>
        <div class="DJCuadroCentro">
            <div class="DJCuadroPresen">
                <table cellspacing="10px">
                    <tr>
                        <td>
                            <asp:Label ID="lblTipoInstrumentoEfe" runat="server" Width="210px">Instrumento</asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlTipoInstrumentoEfe" class="ddleffect" runat="server" Width="280px"
                                DataTextField="Descripcion" DataValueField="Codigo" OnSelectedIndexChanged="ddlTipoInstrumentoEfe_SelectedIndexChanged"
                                AutoPostBack="True">
                                <asp:ListItem Selected="True" Value="-1">&lt;&lt; SELECCIONAR OPCION &gt;&gt;</asp:ListItem>
                                <asp:ListItem Value="1">DEPOSITO BANCARIO</asp:ListItem>
                                <asp:ListItem Value="2">TRANSFERENCIA BANCARIA</asp:ListItem>
                                <asp:ListItem Value="3">OTRO INSTRUMENTO</asp:ListItem>
                            </asp:DropDownList>
                            <asp:CustomValidator ID="cvTipoInstrumentoEfe" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;"
                                ControlToValidate="ddlTipoInstrumentoEfe" Display="Dynamic" EnableClientScript="False"
                                OnServerValidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                            <br />                            
                        </td>
                    </tr>
                </table>
                <table cellspacing="10px">
                    <div id="divDeposito" runat="server">
                        <uc7:ucCuentaBanco ID="ucCuentaBancoDeposito" runat="server" />
                        <%--<tr>
                            <td>
                                <asp:Label ID="lblEntBancariaDep" runat="server" Width="210px">Entidad Bancaria Deposito</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEntBancariaDep" class="txteffect" runat="server" Width="150px"></asp:TextBox>
                                <asp:CustomValidator ID="cvEntBancariaDep" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;"
                                    ControlToValidate="txtEntBancariaDep" Display="Dynamic" EnableClientScript="False"
                                    OnServerValidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblNroCuentaDep" runat="server" Width="210px">Numero de Cuenta Deposito</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtNroCuentaDep" class="txteffect" runat="server" Width="170px"></asp:TextBox>
                                <asp:CustomValidator ID="cvNroCuentaDep" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;"
                                    ControlToValidate="txtNroCuentaDep" Display="Dynamic" EnableClientScript="False"
                                    OnServerValidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                                <br />
                            </td>
                        </tr>--%>
                    </div>
                    <div id="divTransferencia" runat="server">
                        <uc7:ucCuentaBanco ID="ucCuentaBancoDonante" runat="server" />
                        <uc7:ucCuentaBanco ID="ucCuentaBancoDonatario" runat="server" />                        
                        <%--<tr>
                            <td>
                                <asp:Label ID="lblEntBancariaDon" runat="server" Width="210px">Entidad Bancaria Donante</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEntBancariaDon" class="txteffect" runat="server" Width="150px"></asp:TextBox>
                                <asp:CustomValidator ID="cvEntBancariaDon" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;"
                                    ControlToValidate="txtEntBancariaDon" Display="Dynamic" EnableClientScript="False"
                                    OnServerValidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblNroCuentaDon" runat="server" Width="210px">Numero de Cuenta Donante</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtNroCuentaDon" class="txteffect" runat="server" Width="170px"></asp:TextBox>
                                <asp:CustomValidator ID="cvNroCuentaDon" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;"
                                    ControlToValidate="txtNroCuentaDon" Display="Dynamic" EnableClientScript="False"
                                    OnServerValidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblEntBancaria" runat="server" Width="210px">Entidad Bancaria Donatario</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEntBancaria" class="txteffect" runat="server" Width="150px"></asp:TextBox>
                                <asp:CustomValidator ID="cvEntBancaria" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;"
                                    ControlToValidate="txtEntBancaria" Display="Dynamic" EnableClientScript="False"
                                    OnServerValidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblNroCuenta" runat="server" Width="210px">Numero de Cuenta Donatario</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtNroCuenta" class="txteffect" runat="server" Width="170px"></asp:TextBox>
                                <asp:CustomValidator ID="cvNroCuenta" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;"
                                    ControlToValidate="txtNroCuenta" Display="Dynamic" EnableClientScript="False"
                                    OnServerValidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                                <br />
                            </td>
                        </tr>--%>
                    </div>
                    <div id="divOtroInstrumento" runat="server">
                        <tr>
                            <td>
                                <asp:Label ID="lblOtroInst" runat="server" Width="210px">Otro Instrumento</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtOtroInst" class="txteffect" runat="server" Width="150px"></asp:TextBox>
                                <asp:CustomValidator ID="cvOtroInst" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;"
                                    ControlToValidate="txtOtroInst" Display="Dynamic" EnableClientScript="False"
                                    OnServerValidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                                <br />
                            </td>
                        </tr>
                    </div>
                    <div id="divMontos" runat="server">
                        <uc5:ucMontos ID="ucMontosEfe" runat="server" />
                    </div>
                </table>
                <br />
            </div>
        </div>
        <div class="DJCuadroFooter">
            <asp:Image ID="ImgFooter_5efe" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroFooterCOG.png" />
        </div>
        <%--<br />--%>
    </asp:Panel>
    <%-- Termina Panel de Modo de Ingreso en Efectivo --%>
    <%-- Empieza Panel de Modo de Ingreso en Especies --%>
    <asp:Panel ID="pnlwfk_5esp" runat="server">
        <div class="DJCuadroHeader">
            <asp:Image ID="ImgHeader_5esp" class="CuadroHeader" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroHeaderG.png" />
            <asp:Label ID="LblTitulo_5esp" class="CuadroTitulo" runat="server" Width="700px">Ingreso de Fondos en Especie</asp:Label>
        </div>
        <%--<asp:Label ID="lblHeader_4b" class="CuadroTituloIntermedio" runat="server" Width="700px">Modo de Ingreso de los Fondos</asp:Label>--%>
        <div class="DJCuadroCentro">
            <div class="DJCuadroPresen">
               <table cellspacing="10px">
                        <tr>
                            <td>
                                <asp:Label ID="lblTipoBien" runat="server" Width="210px">Tipo de Bien</asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlTipoBien" class="ddleffect" runat="server" Width="250px"
                                    DataTextField="Descripcion" DataValueField="Codigo" OnSelectedIndexChanged="ddlTipoBien_SelectedIndexChanged"
                                    AutoPostBack="True">
                                    <asp:ListItem Selected="True" Value="-1">&lt;&lt; SELECCIONAR OPCION &gt;&gt;</asp:ListItem>
                                    <asp:ListItem Value="1">REGISTRABLE</asp:ListItem>
                                    <asp:ListItem Value="2">NO REGISTRABLE</asp:ListItem>
                                </asp:DropDownList>
                                <asp:CustomValidator ID="cvTipoBien" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;"
                                    ControlToValidate="ddlTipoBien" Display="Dynamic" EnableClientScript="False"
                                    OnServerValidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                                <br />
                            </td>
                        </tr>
                </table>
                <div id="divValuacion" runat="server"> 
                <table cellspacing="10px">
                    
                        <tr>
                            <td>
                                <asp:Label ID="lblDescripcionBien" runat="server" Width="210px">Descripci&oacute;n</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDescripcionBien" class="txteffect" runat="server" Width="250px"></asp:TextBox>
                                <asp:CustomValidator ID="cvDescripcionBien" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;"
                                    ControlToValidate="txtDescripcionBien" Display="Dynamic" EnableClientScript="False"
                                    OnServerValidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblValuacion" runat="server" Width="210px">Valuaci&oacute;n</asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlValuacion" class="ddleffect" runat="server" Width="250px" DataTextField="Descripcion" DataValueField="Codigo">
                                </asp:DropDownList>
                                <asp:CustomValidator ID="cvValuacion" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;" ControlToValidate="ddlValuacion" Display="Dynamic" EnableClientScript="False" OnServerValidate="CustomValidator_Standar" ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                                <br />
                            </td>                            
                        </tr>                    
                </table>
                <uc6:ucValores ID="ucValores" runat="server" />
                </div>               
                <br />
            </div>
        </div>
        <div class="DJCuadroFooter">
            <asp:Image ID="ImgFooter_5esp" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroFooterCOG.png" />
        </div>
        <%--<br />--%>
    </asp:Panel>
    <%-- Termina Panel de Modo de Ingreso en Especies --%>
    <%-- Empieza Panel de Monto --%>
    <asp:Panel ID="pnlwfk_6" runat="server">
        <br />
        <div class="DJCuadroHeader">
            <asp:Image ID="ImgHeader_6" class="CuadroHeader" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroHeaderG.png" />
            <asp:Label ID="LblTitulo_6" class="CuadroTitulo" runat="server" Width="700px">Monto</asp:Label>
        </div>
        <%--<asp:Label ID="lblHeader_4c" class="CuadroTituloIntermedio" runat="server" Width="700px">Monto</asp:Label>--%>
        <div class="DJCuadroCentro">
            <div class="DJCuadroPresen">
                <table cellspacing="10px">
                    <tr>
                        <td>
                            <asp:Label ID="lblMonto" runat="server" Width="210px">Monto total superior a los pesos</asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlMonto" class="ddleffect" runat="server" Width="280px" DataTextField="Descripcion"
                                DataValueField="Codigo" onselectedindexchanged="ddlMonto_SelectedIndexChanged" AutoPostBack="True">
                                <asp:ListItem Selected="True" Value="-1">&lt;&lt; SELECCIONAR OPCION &gt;&gt;</asp:ListItem>
                                <%--<asp:ListItem Value="1">CUATROCIENTOS MIL</asp:ListItem>
                                <asp:ListItem Value="2">OCHOCIENTOS MIL</asp:ListItem>--%>
                                <asp:ListItem Value="1">TRES MILLONES QUINIENTOS CUARENTA Y NUEVE MIL CUATROCIENTOS OCHENTA</asp:ListItem>
                                <asp:ListItem Value="2">SIETE MILLONES TREINTA Y OCHO MIL NOVECIENTOS SESENTA</asp:ListItem>
                            </asp:DropDownList>
                            <asp:CustomValidator ID="cvMonto" runat="server" ErrorMessage="&lt;img src=&quot;/App_Theme/Imagenes/imgAsterisco.png&quot;/&gt;"
                                ControlToValidate="ddlMonto" Display="Dynamic" EnableClientScript="False" OnServerValidate="CustomValidator_Standar"
                                ValidateEmptyText="True" CssClass="imgCruz"></asp:CustomValidator>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblDocResp" runat="server" Width="210px">Documentacion Respaldatoria</asp:Label>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rblDocResp" runat="server" Width="280px" RepeatDirection="Horizontal">
                                <asp:ListItem Text="SI" Value="1" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="NO" Value="2"></asp:ListItem>
                            </asp:RadioButtonList>                            
                            <br />
                        </td>                        
                    </tr>
                    <tr>
                    <td colspan="2">
                    <asp:Label ID="lblDocResp200" runat="server" Text="Documentación Respaldatoria Obligatoria (Art. 517)" class="NotaObligatorio"></asp:Label>
                    </td>
                    </tr>
                </table>                
                <br />
            </div>
        </div>
        <div class="DJCuadroFooter">
            <asp:Image ID="ImgFooter_6" runat="server" ImageUrl="~/App_Theme/Imagenes/DJCuadroFooterCOG.png" />
        </div>
        <br />
    </asp:Panel>
    <%-- Termina Panel de Monto --%>
    <%-- Empieza Captcha --%>
    <uc3:ucCaptcha ID="ucCaptchaOrigenFondos" runat="server" />
    <%-- Termina Captcha --%>
    <%-- Empieza Botones Workflow --%>
    <asp:Panel ID="pnlwfk_botones" runat="server">
        <div class="WorkFlowButtons">
            <asp:ImageButton ID="btnVolver" runat="server" alt="Volver" class="btnVolver" ImageUrl="~/App_Theme/Imagenes/btnvolver.png"
                OnClick="btnVolver_Click" />
            &nbsp;&nbsp;
            <asp:ImageButton ID="btnConfirmar" alt="Confirmar" class="btnConfirmar" runat="server"
                ImageUrl="~/App_Theme/Imagenes/btnconfirmar.png" OnClick="btnConfirmar_Click" />
        </div>
    </asp:Panel>
</asp:Content>
