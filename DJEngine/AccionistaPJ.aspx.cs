using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using DJEngine.Entities;
using DJEngine.DataAccess.Tipos;
using DJEngine.DataAccess.Entidades;

namespace DJEngine.WebEntities
{
    public partial class AccionistaPJ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
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
            

            DDJJ DJ = (DDJJ)Session["DatosEntidad"];
            Entities.Entidad Ent = (Entities.Entidad)Session["Entidad"];

            DJAbstract d = (DJAbstract)Session["DJ"];

           /* if (rblConstituida.SelectedIndex == 0)
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
            }*/

        }

    }
}
