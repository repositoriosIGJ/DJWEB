using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using DJEngine.Business;
using System.Data;
using DJEngine.DataAccess.Tipos;

namespace DJEngine.WebEntities
{
    public partial class HomeDJ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadCss();

            if (!IsPostBack)
            {
                //Session["DJ"] = null;
                //Borro toda la Session
                Session.Clear();
                //Borro la cookie SessionMac para volver a empezar de cero, estableciendo una fecha anterior
                Session.Abandon();

                //Manejo de la habilitacion de los botones de las declaraciones juradas
                //DataAccess.Tipos.TiposDJ tipodj = new DataAccess.Tipos.TiposDJ();
                //DataSet dstdj = tipodj.getTiposDJ();

                if (TiposDJ.TiposDDJJ.Count() > 0)
                {
                    foreach (TiposDJ tdj in TiposDJ.TiposDDJJ)
                    {
                        if (tdj.Habilitado == 1)
                        {
                            switch (tdj.TipoDJ_Id)
                            {
                                case 1:
                                    DJ01.Visible = true;
                                    ImgDJ01.Enabled = true;
                                    break;
                                case 2:
                                    DJ02.Visible = true;
                                    ImgDJ02.Enabled = true;
                                    break;
                                case 3:
                                    DJ03.Visible = true;
                                    ImgDJ03.Enabled = true;
                                    break;
                                case 4:
                                    DJ04.Visible = true;
                                    ImgDJ04.Enabled = true;
                                    break;
                                case 5:
                                    DJ05.Visible = true;
                                    ImgDJ05.Enabled = true;
                                    break;
                                case 6:
                                    DJ06.Visible = true;
                                    ImgDJ06.Enabled = true;
                                    break;
                                case 7:
                                    DJ07.Visible = true;
                                    ImgDJ07.Enabled = true;
                                    break;
                                case 8:
                                    DJ08.Visible = true;
                                    ImgDJ08.Enabled = true;
                                    break;
                                case 9:
                                    DJ09.Visible = true;
                                    ImgDJ09.Enabled = true;
                                    break;
                                case 10:
                                    DJ10.Visible = true;
                                    ImgDJ10.Enabled = true;
                                    break;
                                case 11:
                                    DJ11.Visible = true;
                                    ImgDJ11.Enabled = true;
                                    break;
                            }
                        }
                    }
                }
                else
                {
                    //Muestra pantalla de mantenimiento
                    this.DJMantenimiento.Visible = true;
                    this.lblReader.Visible = false;
                    this.ImgBtnReader.Visible = false;
                }

                //if (Request.Cookies["DJESessionMac"] != null)
                //{
                //    HttpCookie myCookie = new HttpCookie("SessionMac");
                //    myCookie.Expires = DateTime.Now.AddDays(-1d);
                //    //myCookie.Path = "/DJE/";
                //    Response.Cookies.Add(myCookie);
                //}
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

        protected void ImgDJ01_Click(object sender, ImageClickEventArgs e)
        {
            //DJ01 dj01 = new DJ01();
            //Session["DJ"] = dj01;
            //dj01.WorkFlow.Iniciar();
        }

        protected void ImgDJ02_Click(object sender, ImageClickEventArgs e)
        {
            //DJ02 dj02 = new DJ02();
            //Session["DJ"] = dj02;
            //dj02.WorkFlow.Iniciar();
        }


        protected void ImgDJ03_Click(object sender, ImageClickEventArgs e)
        {
            DJ03 dj03 = new DJ03();
            Session["DJ"] = dj03;
            dj03.WorkFlow.Iniciar();
        }

        protected void ImgDJ04_Click(object sender, ImageClickEventArgs e)
        {
            DJ04 dj04 = new DJ04();
            Session["DJ"] = dj04;
            dj04.WorkFlow.Iniciar();
        }

        protected void ImgDJ05_Click(object sender, ImageClickEventArgs e)
        {
            DJ05 dj05 = new DJ05();
            Session["DJ"] = dj05;
            dj05.WorkFlow.Iniciar();
        }

        protected void ImgDJ06_Click(object sender, ImageClickEventArgs e)
        {
            //TODO: Comentado porque ya no se usa esta DJ.
            //DJ06 dj06 = new DJ06();
            //Session["DJ"] = dj06;
            //dj06.WorkFlow.Iniciar();
        }

        protected void ImgDJ07_Click(object sender, ImageClickEventArgs e)
        {
            DJ07 dj07 = new DJ07();
            Session["DJ"] = dj07;
            dj07.WorkFlow.Iniciar();
        }

        protected void ImgDJ08_Click(object sender, ImageClickEventArgs e)
        {
            DJ08 dj08 = new DJ08();
            Session["DJ"] = dj08;
            dj08.WorkFlow.Iniciar();
        }

        protected void ImgDJ09_Click(object sender, ImageClickEventArgs e)
        {
            DJ09 dj09 = new DJ09();
            Session["DJ"] = dj09;
            dj09.WorkFlow.Iniciar();
        }

        protected void ImgDJ10_Click(object sender, ImageClickEventArgs e)
        {
            DJ10 dj10 = new DJ10();
            Session["DJ"] = dj10;
            dj10.WorkFlow.Iniciar();
        }

        protected void ImgDJ11_Click(object sender, ImageClickEventArgs e)
        {
            DJ11 dj11 = new DJ11();
            Session["DJ"] = dj11;
            dj11.WorkFlow.Iniciar();
        }

        protected void ImgBtnReader_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("http://get.adobe.com/es/reader/");
        }
    }
}
