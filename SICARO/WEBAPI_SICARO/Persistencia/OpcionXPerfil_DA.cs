using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WEBAPI_SICARO.Modles;

namespace WEBAPI_SICARO.Persistencia
{
    public class OpcionXPerfil_DA
    {
        private static OpcionXPerfil_DA accion;
        private OpcionXPerfil_DA() { }
        public static OpcionXPerfil_DA Accion
        {
            get
            {
                if (accion == null)
                {
                    accion = new OpcionXPerfil_DA();
                }
                return accion;
            }
        }

        public List<OpcionXPerfil_EL> ListMenu(int Id)
        {

            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("spOpcionXPerfil", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@IdRol", SqlDbType.Int).Value = Id;

                    List<OpcionXPerfil_EL> lstMenu = new List<OpcionXPerfil_EL>();
                    using (IDataReader dataReader = com.ExecuteReader())
                    {

                        while (dataReader.Read())
                        {
                            OpcionXPerfil_EL item = new OpcionXPerfil_EL();
                            Opcion_EL opcion = OPCION_DA.Opcion.GetOpcionByID((int)dataReader["OpcionId"]);
                            item.Opcion = opcion;
                            
                            Rol_EL rol = new Rol_EL()
                            {
                                Id = dataReader["IdRol"] != DBNull.Value ? (int)dataReader["IdRol"] : 0,
                                Nombre = dataReader["Perfil"] != DBNull.Value ? (string)dataReader["Perfil"] : ""
                            };
                            item.Rol = rol;
                            if (dataReader["Escritura"] != DBNull.Value) { item.Escritura = (bool)dataReader["Escritura"]; }

                            lstMenu.Add(item);
                        }
                    }

                    return lstMenu;
                }
            }

        }

        public int InsertOpcionXPerfil(Opcion_EL GC)
        {
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("spInsertOpcionRol", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@IdRol", SqlDbType.Int).Value = GC.Id;
                    com.Parameters.Add("@XMLOpciones", SqlDbType.Xml).Value = GC.Nombre;
                    return com.ExecuteNonQuery();
                }
            }
        }
    }
}