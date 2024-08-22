using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Text;
using System.Security.Cryptography;
using DJEngine.Business;

namespace DJEngine.MasterPages
{
    public partial class DJ : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionSecurity ss = new SessionSecurity();

            if (Request.Url.ToString().Contains("NotFound.aspx") == true)
                return;

            if (!ss.CheckSessionFixation())
            {
                //DJWorkFlow djw = new DJWorkFlow();
                //djw.Iniciar();
                Response.Redirect("HomeDJ.aspx");
            }
            else
            {
                if (!Page.IsPostBack)
                {
                    //Variable que Habilita (Internet) o Deshabilita (Desarrollo) el captcha                   
                    if (ConfigurationManager.AppSettings["CaptchaVisible"] != null)
                    {
                        bool CaptchaHabilitado = true;
                        CaptchaHabilitado = Convert.ToBoolean(ConfigurationManager.AppSettings["CaptchaVisible"]);
                        Session.Add("CaptchaHabilitado", CaptchaHabilitado);
                    }

                    DJAbstract dj = (DJAbstract)Session["DJ"];

                    //Variable harcodea el numero de version
                    //string versiondj = "2.7"; //20/09/12
                    //string versiondj = "2.8"; //23/02/13
                    //string versiondj = "2.9"; //04/04/13
                    //string versiondj = "3.0"; //16/09/15
                    //string versiondj = "3.1"; //02/12/15
                    string versiondj = "4.1"; //04/08/20


                    //Texto Cambiable en el Footer
                    lblFooterA.Text = "Sistema de Declaraciones Juradas v" + versiondj;

                    if (dj != null)
                    {
                        divPasos.Visible = true;

                        Image img = (Image)Page.Master.FindControl("ImgPaso_1");

                        for (int j = 2; j < 7; j++)
                        {
                            img = (Image)Page.Master.FindControl("ImgLinea_" + j.ToString());
                            img.Visible = false;
                            img = (Image)Page.Master.FindControl("ImgPaso_" + j.ToString());
                            img.Visible = false;
                        }

                        /*CALCULO LOS ACTIVOS*/
                        img = (Image)Page.Master.FindControl("ImgPaso_1");

                        if (dj.WorkFlow.Paso == 0)
                            img.ImageUrl = "~/App_Theme/Imagenes/paso_1s.png";
                        else
                            img.ImageUrl = "~/App_Theme/Imagenes/paso_1.png";
                        img.Visible = true;

                        for (int i = 2; i < dj.WorkFlow.TotalPasos + 1; i++)
                        {
                            img = (Image)Page.Master.FindControl("ImgLinea_" + i.ToString());
                            img.Visible = true;
                            img = (Image)Page.Master.FindControl("ImgPaso_" + i.ToString());
                            img.Visible = true;

                            if (dj.WorkFlow.Paso == i - 1)
                                img.ImageUrl = "~/App_Theme/Imagenes/paso_" + i.ToString() + "s.png";
                            else if (dj.WorkFlow.TotalPasos == i)
                                img.ImageUrl = "~/App_Theme/Imagenes/paso_" + i.ToString() + "f.png";
                            else
                                img.ImageUrl = "~/App_Theme/Imagenes/paso_" + i.ToString() + ".png";
                        }

                        //Manejo del Centrado de Pasos
                        switch (dj.WorkFlow.TotalPasos)
                        {
                            case 1:
                            case 2:
                            case 3:
                                this.divPasos.Style.Add("margin-left", "420px");
                                break;
                            case 4:
                                this.divPasos.Style.Add("margin-left", "380px");
                                break;
                            case 5:
                                this.divPasos.Style.Add("margin-left", "360px");
                                break;
                            case 6:
                                this.divPasos.Style.Add("margin-left", "310px");
                                break;
                            case 7:
                                this.divPasos.Style.Add("margin-left", "280px");
                                break;
                            case 8:
                                this.divPasos.Style.Add("margin-left", "260px");
                                break;
                            default:
                                break;
                        }
                        /*LOGOS DE LAS DECLARACIONES*/
                        LogoDJ.ImageUrl = "~/App_Theme/Imagenes/LogoDJ" + dj.TipoDJ_Id.ToString("00") + ".jpg";
                        //LogoDJ.Visible = true;

                        /*LEYENDA*/
                        BarraDJ.Text = dj.LeyendaDJ;

                        if (dj.TipoDJ_Id == (int)EnumDJ.EDDJJ.PERSONAS_EXPUESTAS_POLITICAMENTE_REPRESENTANTE)
                        {
                            BarraDJ.Font.Size = 9;
                        }
                        else if (dj.TipoDJ_Id == (int)EnumDJ.EDDJJ.PERSONAS_EXPUESTAS_POLITICAMENTE_FIDEICOMISO_FISICA)
                        {
                            BarraDJ.Font.Size = 8;
                        }
                          
                            
                    }
                    else
                    {
                        BarraDJ.Text = "SISTEMA DE DECLARACIONES JURADAS v" + versiondj;
                        LogoDJ.ImageUrl = "~/App_Theme/Imagenes/LogoDJ.jpg";
                        //LogoDJ.Visible = false;
                        divPasos.Visible = false;                        
                    }                    
                }
            }
        }

        private void openNewWindow(string ventana)
        {
            string Clientscript = "<script>window.open('" + ventana + "')</script>";
            
            if (!Page.ClientScript.IsStartupScriptRegistered("WOpen"))
            {
                Page.RegisterStartupScript("WOpen", Clientscript);
            }
        }


        //protected void imgBtnRecomendaciones_Click(object sender, ImageClickEventArgs e)
        //{
        //    //Response.Redirect("http://www.jus.gov.ar/igj/PagDeclaracionJurada/Instructivo.htm");
        //    openNewWindow("http://www.jus.gov.ar/igj/PagDeclaracionJurada/Instructivo.htm");

        //    //System.Diagnostics.Process Instructivo = new System.Diagnostics.Process();
        //    //Instructivo.StartInfo.FileName = @"http://www.jus.gov.ar/igj/PagDeclaracionJurada/Instructivo.htm";
        //    //Instructivo.Start();

        //}
        //protected void imgBtnManualdeUsuario_Click(object sender, ImageClickEventArgs e)
        //{
        //    //Response.Redirect("http://www.jus.gov.ar/igj/PagDeclaracionJurada/Faq.htm");       
        //    openNewWindow("http://www.jus.gov.ar/igj/PagDeclaracionJurada/Faq.htm");

        //    //System.Diagnostics.Process Fag = new System.Diagnostics.Process();
        //    //Fag.StartInfo.FileName = @"http://www.jus.gov.ar/igj/PagDeclaracionJurada/Faq.htm";
        //    //Fag.Start();

        //}

        private string createHMASCHA1(byte[] p1, byte[] key)
        {
            using (HMACSHA1 hmac = new HMACSHA1(key))
            {
                return Convert.ToBase64String(hmac.ComputeHash(p1));
            }
        }
        //protected void imgBtnIGJ_Click(object sender, ImageClickEventArgs e)
        //{

        //    openNewWindow("http://www.jus.gov.ar/igj/");

        //    //System.Diagnostics.Process siteIGJ = new System.Diagnostics.Process();
        //    //siteIGJ.StartInfo.FileName = @"http://www.jus.gov.ar/igj/";

        //    //siteIGJ.Start();
        //}
    }
}