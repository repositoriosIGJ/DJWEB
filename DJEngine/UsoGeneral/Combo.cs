using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace DJEngine.UsoGeneral
{
    public class Combo
    {
        public static void CargarLeyenda(DropDownList combo,string Leyenda , string valor)
        {
            combo.Items.Insert(0,new ListItem(Leyenda,valor));
          
        }
        public static void CargarLeyenda(DropDownList combo)
        {
            CargarLeyenda(combo, "<< SELECCIONAR OPCION >>", "-1");

        }
        public static void SetValue(DropDownList combo, string valor)
        {

            foreach (ListItem l in combo.Items)
            {
                if (l.Value == valor)
                {
                    l.Selected = true;
                    return;
                }
            }

        }


    }
    
}
