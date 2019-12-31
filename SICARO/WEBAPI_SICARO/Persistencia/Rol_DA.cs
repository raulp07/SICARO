using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WEBAPI_SICARO.Modles;

namespace WEBAPI_SICARO.Persistencia
{
    public class Rol_DA
    {
        private static Rol_DA accion;
        private Rol_DA() { }
        public static Rol_DA Accion
        {
            get
            {
                if (accion == null)
                {
                    accion = new Rol_DA();
                }
                return accion;
            }
        }

        public List<Rol_EL> GetAllRol(int iIdRol)
        {
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("spGet_Rol", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@iIdRol", SqlDbType.Int).Value = iIdRol;
                    List<Rol_EL> list = new List<Rol_EL>();
                    using (IDataReader dataReader = com.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Rol_EL obj = new Rol_EL();
                            if (dataReader["iIdRol"] != DBNull.Value) { obj.Id = (int)dataReader["iIdRol"]; }
                            if (dataReader["vNombre"] != DBNull.Value) { obj.Nombre = (string)dataReader["vNombre"]; }                            
                            list.Add(obj);
                        }
                    }
                    return list;
                }

            }
        }

        public int InsertRol(Rol_EL C)
        {
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("spInsert_Rol", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@iIdRol", SqlDbType.Int).Value = C.Id;
                    com.Parameters.Add("@vNombre", SqlDbType.VarChar).Value = C.Nombre;
                    return com.ExecuteNonQuery();
                }
            }
        }

    }
}