
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;



/// <summary>
/// Summary description for WorkFlow
/// </summary>
/// 

    /*  NOTED: REEDME
     * 
     * VALIDACION BOTON ATRAS/ADELANTE EXPLORER
     * Se soluciona con esta funcion de javascript en la 
     * masterpage
     * DESCRIPCION
     * Se limita el historial de navegación en 1, tambien
     * se debe tener en cuenta que el explorador tenga habilitado
     * el javascript.
    <script type="text/javascript" language="javascript">                
                 javascript:window.history.forward(1);
    </script>
     * 
     * 
     * */

public class DJWorkFlow
{
    private  string[] PageWorkflow = null;

    private int _TotalPasos;

    public int TotalPasos
    {
        get { return _TotalPasos; }
        set { _TotalPasos = value; }
    }

    private int _Paso;

    public int Paso
    {
        get { return _Paso; }
        set { _Paso = value; }
    }

    public void Siguiente()
    {
        if (TotalPasos > Paso)
        {
            Paso++;
            WorkFlowRedirect(Paso);
        }
    }

    public void Anterior()
    {
        if (Paso == 0)
            HttpContext.Current.Response.Redirect("HomeDJ.aspx");

        if (Paso > 0)
        {
            Paso--;
            WorkFlowRedirect(Paso);
        }
    }

    public void Iniciar()
    {
        Paso = 0;
        WorkFlowRedirect(Paso);
    }
    public void Refrescar()
    {
        WorkFlowRedirect(Paso);
    }

    public DJWorkFlow(int tipoDJ)
	{
        Paso = 0;
        DJEngine.WSMotorDDJJ.WS_MOTOR_DDJJ Motor = new DJEngine.WSMotorDDJJ.WS_MOTOR_DDJJ();

        DataSet ds = Motor.LstWorkFlow(tipoDJ);

        List<string> paginas = new List<string>();

        foreach (DataRow dr in ds.Tables[0].Rows)
        {
    	    paginas.Add(dr["PAGINA"].ToString());
            TotalPasos++; // CUENTO LA CANTIDAD DE PASOS
        }

        PageWorkflow = paginas.ToArray();
	}

    public void WorkFlowRedirect(int Paso)
    {
        ///MANEJO DEL WORKFLOW (EVITAR BOTON ATRAS DEL EXPLORADOR)
        HttpContext.Current.Session["WorkFlow"] = Paso;
        HttpContext.Current.Response.Redirect(PageWorkflow[Paso]);    
    }

    public void WorkFlowValidate(Page p)
    {
        int Paso = (int)HttpContext.Current.Session["WorkFlow"];

        if (p.Request.AppRelativeCurrentExecutionFilePath != PageWorkflow[Paso]) 
        {
            WorkFlowRedirect(Paso);
            return;
        }
 
        return;    
    }

    public string GetCurrentPageName()
	{
	    string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
	    System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
	    string sRet = oInfo.Name;
	    return sRet;
	}


}

