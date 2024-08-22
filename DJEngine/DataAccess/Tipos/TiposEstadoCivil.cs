using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for TipoEstadoCivil
/// </summary>
/// 
namespace DJEngine.DataAccess.Tipos
{
    public class TiposEstadoCivil : Tipos
    {
        private static DataSet ds;

        public TiposEstadoCivil()
            : base(ds)
        {
            getTipoEstadoCivil();
        }

        public TiposEstadoCivil(int index)
            : base(ds)
        {
            getTipoEstadoCivil();
            Load(index);
        }

        public DataSet getTipoEstadoCivil()
        {
            _CodigoDefault = 1;

            if (ds == null)
            {
               LoadTablaEstadosCiviles();
            }
            return ds;
        }

        public void LoadTablaEstadosCiviles()
        {
            WSMotorDDJJ.WS_MOTOR_DDJJ ws = new WSMotorDDJJ.WS_MOTOR_DDJJ();

            _CodigoDefault = 1;

            ds = ws.LstTiposEstadosCiviles();

            //Harcode Estados Civiles
            /*
            <asp:ListItem Text="Soltero" Value="1"></asp:ListItem>
            <asp:ListItem Text="Casado" Value="2"></asp:ListItem>
            <asp:ListItem Text="Viudo" Value="3"></asp:ListItem>
            <asp:ListItem Text="Divorciado" Value="4"></asp:ListItem>
            */
        }

        /*
        string[] TABLE_COLUMNS = new string[] { "PilotID", "Start_date", "End_date", "Hours", };
        static void Main()
        {

            var i_need_new_table = HardCodedDataTable();
            var i_need_one_more_new_table = HardCodedDataTable(TABLE_COLUMNS);

        }

        private static DataTable HardCodedDataTable() // default hard-coded table
        {
            DataTable myTable = new DataTable();
            myTable.Columns.Add("PilotID");
            myTable.Columns.Add("Start_date");
            myTable.Columns.Add("End_date");
            myTable.Columns.Add("Hours");
            return myTable;
        }

        private static DataTable HardCodedDataTable(string[] columns) // table with predefined columns in array
        {
            DataTable myTable = new DataTable();
            Array.ForEach(columns, s => myTable.Columns.Add(s));
            return myTable;
        }
        */
    }
}