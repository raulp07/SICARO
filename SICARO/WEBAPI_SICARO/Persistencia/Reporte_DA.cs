using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WEBAPI_SICARO.Modles;

namespace WEBAPI_SICARO.Persistencia
{
    public class Reporte_DA
    {
        private static Reporte_DA accion;
        private Reporte_DA() { }
        public static Reporte_DA Accion
        {
            get
            {
                if (accion == null)
                {
                    accion = new Reporte_DA();
                }
                return accion;
            }
        }

        public List<Reporte_EL> GetReporteGeneral(Reporte_EL r)
        {
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("ReporteGeneral", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@fechainicial", SqlDbType.Date).Value = r.fechainicial;
                    com.Parameters.AddWithValue("@fechafinal", SqlDbType.Date).Value = r.fechafinal;

                    List<Reporte_EL> list = new List<Reporte_EL>();
                    using (IDataReader dataReader = com.ExecuteReader())
                    {

                        while (dataReader.Read())
                        {

                            Reporte_EL obj = new Reporte_EL();

                            if (dataReader["indice"] != DBNull.Value) { obj.indice = (decimal)dataReader["indice"]; }
                            if (dataReader["estado"] != DBNull.Value) { obj.estado = Convert.ToInt16(dataReader["estado"]); }
                            if (dataReader["descripcion"] != DBNull.Value) { obj.descripcion = (string)dataReader["descripcion"]; }
                            if (dataReader["fecha"] != DBNull.Value) { obj.fecha = (DateTime)dataReader["fecha"]; }
                            list.Add(obj);

                        }

                    }
                    return list;
                }

            }
        }


    }
}