using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using DJEngine.Business;
using DJEngine.DataAccess.Tipos;
using DJEngine.UsoGeneral;

namespace DJEngine.WebEntities
{
    public partial class Libros : System.Web.UI.Page
    {
        DJEngine.Business.Libros oLibros = new DJEngine.Business.Libros();

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadCss();
            Page.MaintainScrollPositionOnPostBack = true;

            DJAbstract d = (DJAbstract)Session["DJ"];
            d.WorkFlow.WorkFlowValidate(Page);

            if (Session["Libros"] != null)
            {
                this.oLibros = (DJEngine.Business.Libros)Session["Libros"];
            }

            if (!IsPostBack)
            {
                //Oculta boton Continuar
                MostrarContinuar(false);

                pnlvalidacion.Visible = false;

                ucFechaRUB.proplblFecha = "Fecha de Rúbrica/Registro LD";
                CargarCombos();
                CargarLibroVacio();

                //Oculto Labels y Textbox
                lblCaptchaErrorvld.Visible = false;
                MostrarDatosEntidad();

                //Oculta Captcha para Desarrollo
                //if (Session["CaptchaHabilitado"] != null)
                //{
                //    if ((bool)Session["CaptchaHabilitado"] == false)
                //    {
                //        this.ucCaptchaPersona.Visible = false;
                //    }
                //}
            }
        }

        public void MostrarContinuar(bool Continuar)
        {
            if (Continuar)
            {
                btnContinuar.ImageUrl = "~/App_Theme/Imagenes/btnvacio.png";
                btnContinuar.Enabled = true;
            }
            else
            {
                btnContinuar.ImageUrl = "~/App_Theme/Imagenes/btncontinuard.png";
                btnContinuar.Enabled = false;
            }
        }

        public void CargarCombos()
        {
            ddlDocRubrica.DataSource = new TiposDocRubrica().getTiposDocRubrica();
            ddlDocRubrica.DataBind();
            //Combo.CargarLeyenda(ddlDocRubrica);
        }

        protected void MostrarDatosEntidad()
        {
            //RECUPERA LOS DATOS DE LA ENTIDAD DE LA SESSION
            Business.Entidad Ent = (Business.Entidad)Session["Entidad"];

            //Si esta constituida muestro de la entidad
            //Denominacion, TipoSocietario, NroCorrelativo y CUIT
            lblEntidad.Visible = true;
            lblTipoSocietario.Visible = true;
            lblNroCorrelativo.Visible = true;
            txtEntidad.Visible = true;
            txtTipoSocietario.Visible = true;
            txtNroCorrelativo.Visible = true;

            //Dato Cuit Referencial
            lblCuitEnt.Visible = Ent.Cuit.ToString() == String.Empty ? false : true;
            txtCuitEnt.Visible = Ent.Cuit.ToString() == String.Empty ? false : true;

            txtNroCorrelativo.Text = Ent.NroCorrelativo.ToString();
            txtTipoSocietario.Text = Ent.TipoSocDesc;
            txtEntidad.Text = Ent.RazonSocial.ToString();

            //Dato Cuit Referencial
            txtCuitEnt.Text = Ent.Cuit.ToString();
        }

        private void LoadCss()
        {
            string aspxpath = "~/App_Theme/Cascading/";
            string aspxname = (Request.Url.Segments[Request.Url.Segments.Length - 1]).Replace(".aspx", ".css");
            HtmlLink cssLink = new HtmlLink();
            cssLink.Href = aspxpath + aspxname;
            cssLink.Attributes.Add("rel", "stylesheet");
            cssLink.Attributes.Add("type", "text/css");
            Header.Controls.Add(cssLink);
            //Tambien Levanto el Generico de Diseño de Formularios
            //cssLink.Href = "~/App_Theme/Cascading/FormDesign.css";
            //Header.Controls.Add(cssLink);
        }

        protected void btnVolver_Click(object sender, ImageClickEventArgs e)
        {
            DJAbstract d = (DJAbstract)Session["DJ"];
            d.WorkFlow.Anterior();
        }

        protected void CustomValidator_Standar(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validation.Validar((CustomValidator)source, args.Value);
        }

        protected void btnContinuar_Click(object sender, ImageClickEventArgs e)
        {
            //Valida todos la lista de libros de rubrica
            if (ValidarMinimo())
            {
                DJAbstract d = (DJAbstract)Session["DJ"];
                d.WorkFlow.Siguiente();
            }
            else
            {
                //Mostrar Mensaje de que el listado esta vacio en el Panel de Validacion
            }
        }

        protected void CargarLibroVacio()
        {
            try
            {
                //Guardo en propiedades los datos del Libro
                DJEngine.Business.Libro LIB = new DJEngine.Business.Libro();
                oLibros.libros = new List<Libro>();

                foreach (ListItem item in ddlDocRubrica.Items)
                {
                    LIB = new DJEngine.Business.Libro();

                    LIB.iddoc = Convert.ToInt32(item.Value);
                    LIB.doc = item.Text.ToString();
                    LIB.den = "N/C";
                    LIB.nru = "N/C";
                    LIB.fru = "N/C";
                    LIB.fol = "N/C";

                    oLibros.libros.Add(LIB);
                }

                Session["Libros"] = oLibros;

                grdLibros.DataSource = oLibros.libros;
                grdLibros.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void GuardarLibro()
        {
            try
            {
                Page.Validate();

                if (!Page.IsValid)
                {
                    pnlvalidacion.Visible = true;
                    return;
                }
                else
                {
                    pnlvalidacion.Visible = false;
                }

                //Guardo en propiedades los datos del Libro
                DJEngine.Business.Libro LIB = new DJEngine.Business.Libro();

                LIB.iddoc = Convert.ToInt32(ddlDocRubrica.SelectedValue);
                LIB.doc = new TiposDocRubrica(LIB.iddoc).Descripcion;
                LIB.den = txtDenominacionRUB.Text.Trim() == "" ? "N/C" : txtDenominacionRUB.Text.Trim();
                LIB.nru = txtNumeroRUB.Text.Trim() == "" ? "N/C" : txtNumeroRUB.Text.Trim();
                LIB.fru = Convert.ToString(ucFechaRUB.proptxtFecha.Trim()) == "" ? "N/C" : Convert.ToString(ucFechaRUB.proptxtFecha.Trim());
                LIB.fol = txtFoliosRUB.Text.Trim() == "" ? "N/C" : txtFoliosRUB.Text.Trim();

                //this.oLibros = (DJEngine.Business.Libros)Session["Libros"];

                if (oLibros != null)
                {
                    //if (oLibros.libros == null)
                    //{
                    //    oLibros.libros = new List<Libro>();
                    //    oLibros.libros.Add(LIB);
                    //}
                    //else
                    //{
                    //bool editado = false;

                    //Busca el libro en la lista para modificarlo
                    foreach (var item in oLibros.libros)
                    {
                        if (item.iddoc == LIB.iddoc)
                        {
                            item.doc = LIB.doc;
                            item.den = LIB.den;
                            item.nru = LIB.nru;
                            item.fru = LIB.fru;
                            item.fol = LIB.fol;

                            //editado = true;
                        }
                    }

                    //Si no se edito se inserta como nuevo
                    //if (editado == false)
                    //{
                    //    oLibros.libros.Add(LIB);
                    //}
                    //}

                    Session["Libros"] = oLibros;
                }

                CargarGrilla(oLibros);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void MostrarLibro(int iddocsel)
        {
            try
            {
                if (oLibros != null)
                {
                    if (oLibros.libros != null)
                    {
                        //Carga los datos de la lista para editar
                        foreach (var item in oLibros.libros)
                        {
                            if (item.iddoc == iddocsel)
                            {
                                txtDenominacionRUB.Text = (item.den.ToString().ToLower().Trim() == "n/c" ? "" : item.den);
                                txtNumeroRUB.Text = (item.nru.ToString().ToLower().Trim() == "n/c" ? "" : item.nru);
                                ucFechaRUB.proptxtFecha = (item.fru.ToString().ToLower().Trim() == "n/c" ? "" : item.fru);
                                txtFoliosRUB.Text = (item.fol.ToString().ToLower().Trim() == "n/c" ? "" : item.fol);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarGrilla(DJEngine.Business.Libros oLibros)
        {
            grdLibros.DataSource = oLibros.libros;
            grdLibros.DataBind();
        }

        protected void ddlDocRubrica_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlDocRub = (DropDownList)sender;
            int iddocsel = Convert.ToInt32(ddlDocRub.SelectedValue);

            MostrarLibro(iddocsel);

            //Oculta el Panel de Validacion porque cambia el combo
            pnlvalidacion.Visible = false;
        }

        protected void btnGuardar_Click(object sender, ImageClickEventArgs e)
        {
            GuardarLibro();

            if (ValidarMinimo())
            {
                MostrarContinuar(true);
            }
            else
            {
                MostrarContinuar(false);
            }
        }

        public bool ValidarMinimo()
        {
            int cant = 0;

            foreach (var item in oLibros.libros)
            {
                if (item.den != "N/C" || item.nru != "N/C" || item.fru != "N/C" || item.fol != "N/C")
                {
                    //Se encontro un Registro con algun campo lleno distino de vacio o N/C
                    cant++;
                }
            }

            if (cant > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected bool CargarCabecera()
        {
            DJAbstract d = (DJAbstract)Session["DJ"];

            if (d.RegistrarDJ())
            {
                Session["DJ"] = d;
                return true;
            }
            else
            {
                Session["DJ"] = null;
                return false;
            }
        }
    }
}
