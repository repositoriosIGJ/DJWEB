using System;
using System.Data;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DJEngine.UsoGeneral;

namespace DJEngine.DataAccess.Tipos
{
    public class VinculoPEP : Tipos
    {
        private static DataSet ds;

        private static List<VinculoPEP> _Vinculos;

        public static List<VinculoPEP> Vinculos { 
        
            get{
                if(_Vinculos == null)
                    {
                
                        _Vinculos = new List<VinculoPEP>();
                        LoadTablaVinculoPEP();
                    }
                    return VinculoPEP._Vinculos;
            
                }

            set { _Vinculos = value; }
        
        }

        public VinculoPEP(): base(ds){

            getVinculoPEP();
    
        }

        public VinculoPEP(int index)
            : base(ds) 
        {
            getVinculoPEP();
            Load(index);
        }

        public DataSet getVinculoPEP() {

            _CodigoDefault = 1;

            if (ds == null) {

                LoadTablaVinculoPEP();
            }

            return ds;
        }

        public static void LoadTablaVinculoPEP()
        {
            WSMotorDDJJ.WS_MOTOR_DDJJ ws = new WSMotorDDJJ.WS_MOTOR_DDJJ();

            ds = ws.LstVinculoPEP();
           

            foreach (DataRow dr in ds.Tables[0].Rows) {

                VinculoPEP vin = new VinculoPEP();
                vin.Codigo = Convert.ToInt32(dr["CODIGO"]);
                vin.Descripcion = dr["DESCRIPCION"].ToString();

                Vinculos.Add(vin);               

            }

            //ORDENA LISTA POR DESCRIPCION
            //Vinculos = Vinculos.OrderBy(x => x.Descripcion).ToList();
        }

        public static VinculoPEP GetVinculo(int codigo)
        {
            foreach (VinculoPEP v in Vinculos) 
            {
                if (v.Codigo == codigo)
                    return v;
            }

            return null;
        }

    }
}
