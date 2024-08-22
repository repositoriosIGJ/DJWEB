using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Reflection;

namespace DJEngine.UsoGeneral
{
    /// <summary>
    /// Summary description for ToDataSet
    /// </summary>
    public class ConvertToDataTable
    {
        public ConvertToDataTable()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region Converting ObjectArray to Datatable

        public static DataTable Convert<T>(List<T> array)
        {


            DataTable dt = null;

            if (array.Count != 0)
            {
                PropertyInfo[] properties = array[0].GetType().GetProperties();

                dt = CreateDataTable(properties);
                dt.TableName = array[0].GetType().ToString();
                foreach (object o in array)
                    FillData(properties, dt, o);
            }
            return dt;
        }
        public static DataTable Convert(Object obj)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties();
            DataTable dt = CreateDataTable(properties);
            FillData(properties, dt, obj);

            dt.TableName = obj.GetType().ToString();
            return dt;
        }
        private static DataTable CreateDataTable(PropertyInfo[] properties)
        {
            DataTable dt = new DataTable();
            DataColumn dc = null;
            foreach (PropertyInfo pi in properties)
            {
                dc = new DataColumn();
                dc.ColumnName = pi.Name;
                dc.DataType = pi.PropertyType;
                dt.Columns.Add(dc);
            }
            return dt;
        }

        private static void FillData(PropertyInfo[] properties, DataTable dt, Object o)
        {
            DataRow dr = dt.NewRow();
            foreach (PropertyInfo pi in properties)
            {
                dr[pi.Name] = pi.GetValue(o, null);
            }
            dt.Rows.Add(dr);
        }

        #endregion
    }
}
