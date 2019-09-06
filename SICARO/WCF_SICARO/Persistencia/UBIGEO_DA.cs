using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WCF_SICARO.Dominio;

namespace WCF_SICARO.Persistencia
{
    public class UBIGEO_DA
    {
        private static UBIGEO_DA accion;
        private UBIGEO_DA() { }
        public static UBIGEO_DA Accion
        {
            get
            {
                if (accion == null)
                {
                    accion = new UBIGEO_DA();
                }
                return accion;
            }
        }
        public List<UBIGEO_EL> GetAllUBIGEO(UBIGEO_EL U)
        {
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("spGet_UBIGEO", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@co_ubigeo", SqlDbType.Char, 8).Value = U.co_ubigeo;
                    com.Parameters.Add("@flag", SqlDbType.Char, 1).Value = U.flag;

                    List<UBIGEO_EL> list = new List<UBIGEO_EL>();
                    using (IDataReader dataReader = com.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            UBIGEO_EL obj = new UBIGEO_EL();
                            if (dataReader["co_ubigeo"] != DBNull.Value) { obj.co_ubigeo = (string)dataReader["co_ubigeo"]; }
                            if (dataReader["de_ubigeo"] != DBNull.Value) { obj.de_ubigeo = (string)dataReader["de_ubigeo"]; }
                            list.Add(obj);
                        }
                    }
                    return list;
                }
            }
        }
    }
}