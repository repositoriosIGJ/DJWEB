using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DJEngine.Business;
using System.Web.UI.HtmlControls;

namespace DJEngine.WebEntities
{
    public partial class Legal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DJAbstract d = (DJAbstract)Session["DJ"];
            d.WorkFlow.WorkFlowValidate(Page);
            LoadCss();
            Page.MaintainScrollPositionOnPostBack = true;

            if (!IsPostBack)
            {
                btnContinuar.ImageUrl = "~/App_Theme/Imagenes/btncontinuard.png";
                btnContinuar.Enabled = false;
                DJEngine.Business.DJAbstract dj = (DJEngine.Business.DJAbstract)Session["DJ"];
                divMarcoLegal.InnerHtml = dj.MarcoLegal.TextoLegal;
            }
        }

        protected void btnContinuar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (chkAceptar.Checked)//resolucion de seguridad
                {
                    DJAbstract d = (DJAbstract)Session["DJ"];
                    d.WorkFlow.Siguiente();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnVolver_Click(object sender, ImageClickEventArgs e)
        {
            DJAbstract d = (DJAbstract)Session["DJ"];
            d.WorkFlow.Anterior();
            //Response.Redirect("HomeDJ.aspx");
        }


        protected void chkAceptar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAceptar.Checked == true)
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
