using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WCF_SICARO.Dominio;

namespace WCF_SICARO.Persistencia
{
    public class OpcionXPerfil_DA
    {
        private static OpcionXPerfil_DA opcionXPerfil;
        private OpcionXPerfil_DA() { }
        public static OpcionXPerfil_DA OpcionXPerfil
        {
            get
            {
                if (opcionXPerfil == null)
                {
                    opcionXPerfil = new OpcionXPerfil_DA();
                }
                return opcionXPerfil;
            }
        }

        public List<OpcionXPerfil_EL> ListMenu(OpcionXPerfil_EL opcionPerfil)
        {

            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("spOpcionXPerfil", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@IdRol", SqlDbType.Int).Value = opcionPerfil.Rol.Id;

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

    }
}