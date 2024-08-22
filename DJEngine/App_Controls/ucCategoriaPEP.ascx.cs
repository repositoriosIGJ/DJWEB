using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DJEngine.DataAccess.Tipos;
using DJEngine.UsoGeneral;

namespace DJEngine.App_Controls
{
    public partial class ucCategoriaPEP : System.Web.UI.UserControl
    {
        public int Categoria
        {
            get { return Convert.ToInt32(ddlCategoriaPEP.SelectedValue); }
            set {

                foreach (ListItem l in ddlCategoriaPEP.Items)
                {
                    if (Convert.ToInt32(l.Value) == value)
                    {
                        l.Selected = true;
                        return;
                    }
                }                
            }
        }

        public int SubCategoria
        {
            //get { return Convert.ToInt32(ddlSubCategoriaPEP.SelectedValue); }
            //Arreglado por Fer
            get {
                if (ddlSubCategoriaPEP.SelectedValue == "")
                    return -1;

                return Convert.ToInt32(ddlSubCategoriaPEP.SelectedValue);
            }
            set {

                foreach (ListItem l in ddlSubCategoriaPEP.Items)
                {
                    if (Convert.ToInt32(l.Value) == value)
                    {
                        l.Selected = true;
                        return;
                    }
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCombos();
            }
        }

        public void CargarCombos()
        {
            ddlCategoriaPEP.DataSource = CategoriaPEP.Categorias;
            ddlCategoriaPEP.DataBind();
            Combo.CargarLeyenda(ddlCategoriaPEP);
            //Deshabilito la SubCategoriaPEP
            OcultarSubCatPEP(true);
        }

        protected void CustomValidator_Standar(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Validation.Validar((CustomValidator)source, args.Value);
        }

        protected void ddlCategoriaPEP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCategoriaPEP.SelectedValue == "-1")
            {
                //Deshabilito la SubCategoriaPEP
                OcultarSubCatPEP(true);
            }
            else
            {
                OcultarSubCatPEP(false);
                if (CategoriaPEP.GetCategoria(Convert.ToInt32(ddlCategoriaPEP.SelectedValue)).SubCategorias.Count > 0)
                {
                    ddlSubCategoriaPEP.DataSource = CategoriaPEP.GetCategoria(Convert.ToInt32(ddlCategoriaPEP.SelectedValue)).SubCategorias;
                    ddlSubCategoriaPEP.DataBind();
                    Combo.CargarLeyenda(ddlSubCategoriaPEP);
                }
                else
                {
                    //Deshabilito la SubCategoriaPEP
                    OcultarSubCatPEP(true);
                }
            }
            

            //switch (ddlCategoriaPEP.SelectedValue)
            //{
            //    case "1": //"Categoria 1"
            //    case "2": //"Categoria 2"
            //    case "3": //"Categoria 3"
            //        //OcultarSubCatPEP(false);
            //        //ddlSubCategoriaPEP.DataSource = CategoriaPEP.GetCategoria(Convert.ToInt32(ddlCategoriaPEP.SelectedValue)).SubCategorias;
            //        //ddlSubCategoriaPEP.DataBind();
            //        //Combo.CargarLeyenda(ddlSubCategoriaPEP);
            //        //break;
            //    case "4": //"Categoria 4"                    
            //    case "5": //"Categoria 5"
            //    case "6": //"Categoria 6"
            //    case "7": //"Categoria 7"
            //    case "-1": //"Categoria -1"
            //        //Deshabilito la SubCategoriaPEP
            //        OcultarSubCatPEP(true);
            //        break;
            //}
        }

        //Oculta la subcategoriapep y deshabilita el combo y su validador
        public void OcultarSubCatPEP(bool Ocultar)
        {
            if (Ocultar)
            {//Oculto la subcategoria
                trSubCategoriaPEP.Visible = false;
                ddlSubCategoriaPEP.Enabled = false;
                cvSubCategoriaPEP.Enabled = false;
            }
            else
            {//Muestro la subcategoria
                trSubCategoriaPEP.Visible = true;
                ddlSubCategoriaPEP.Enabled = true;
                cvSubCategoriaPEP.Enabled = true;
            }
        }

        public void ReiniciarCombos()
        {
            ddlCategoriaPEP.SelectedIndex = -1;
            ddlSubCategoriaPEP.SelectedIndex = -1;
            OcultarSubCatPEP(true);
        }
    }
}