using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using DJEngine.Entities;
using DJEngine.DataAccess.Tipos;

namespace DJEngine.WebEntities
{
    public partial class AccionistaPF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            DJAbstract d = (DJAbstract)Session["DJ"];
            d.WorkFlow.WorkFlowValidate(Page);
            LoadCss();
        }
        protected void CustomValidator_Standar(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validation.Validar((CustomValidator)source, args.Value);
        }

        protected void btnVolver_Click(object sender, ImageClickEventArgs e)
        {
            DJAbstract d = (DJAbstract)Session["DJ"];
            d.WorkFlow.Anterior();
        }

        protected void btnContinuar_Click(object sender, EventArgs e)
        {
           /* if (rblConstituida.SelectedIndex == 1)
            {
                //Valido todos los controles de la pagina web
                Page.Validate();
                if (!Page.IsValid)
                {
                    pnlvalidacion.Visible = true;
                    return;
                }
            }

            DDJJ DJ = (DDJJ)Session["DatosEntidad"];
            Entities.Entidad Ent = (Entities.Entidad)Session["Entidad"];

            DJAbstract d = (DJAbstract)Session["DJ"];

            if (rblConstituida.SelectedIndex == 0)
            {

                //Constituida
                if (Ent.NroCorrelativo != 0)
                {
                    d.WorkFlow.Siguiente();
                }
                else
                {
                    d.WorkFlow.Refrescar();
                }
            }
            else //No Constituida
            {
                if (txtEntidad.Text != "" && ddlTipoDeEntidad.SelectedIndex != -1)
                {
                    CargarPropiedades();
                    d.WorkFlow.Siguiente();
                }
                else
                {
                    //Mostrar mensaje de error para completar los 2 campos
                    d.WorkFlow.Refrescar();
                }
            }
            */
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            Entities.AccionistaPF ac = new Entities.AccionistaPF();

            ac.Apellido = txtApellidoAPF.Text;
            ac.Nombre = txtNombreAPF.Text;
            ac.TipoDocumento = new TiposDocumento(ucDocumentoAPF.propddlTipoDoc);
            ac.NroDocumento = ucDocumentoAPF.proptxtNroDoc;

            ac.CUIT = ucFiscalAPF.proptxtNroFiscal;
            


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
        }
    }
}
