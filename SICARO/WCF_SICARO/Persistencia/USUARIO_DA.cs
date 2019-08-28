using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WCF_SICARO.Dominio;

namespace WCF_SICARO.Persistencia
{
    public class USUARIO_DA
    {
        private static USUARIO_DA accion;
        private USUARIO_DA() { }
        public static USUARIO_DA Accion
        {
            get
            {
                if (accion == null)
                {
                    accion = new USUARIO_DA();
                }
                return accion;
            }
        }

        public List<USUARIO_EL> GetAllUSUARIO(USUARIO_EL P)
        {
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("spGetUSUARIOAll", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@vNombreUsuario", SqlDbType.VarChar).Value = P.CtaUsuario;
                    com.Parameters.Add("@vPassword", SqlDbType.VarChar).Value = P.Contrasenia;
                    List<USUARIO_EL> list = new List<USUARIO_EL>();

                    using (IDataReader dataReader = com.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            USUARIO_EL obj = new USUARIO_EL();

                            if (dataReader["Id"] != DBNull.Value) { obj.Id = (int)dataReader["Id"]; }
                            if (dataReader["IdRol"] != DBNull.Value) { obj.IdRol = (int)dataReader["IdRol"]; }
                            if (dataReader["CtaUsuario"] != DBNull.Value) { obj.CtaUsuario = (string)dataReader["CtaUsuario"]; }
                            //if (dataReader["Contrasenia"] != DBNull.Value) { obj.Contrasenia = (string)dataReader["Contrasenia"]; }
                            if (dataReader["Nombres"] != DBNull.Value) { obj.Nombres = (string)dataReader["Nombres"]; }
                            if (dataReader["Apellidos"] != DBNull.Value) { obj.Apellidos = (string)dataReader["Apellidos"]; }
                            if (dataReader["Cargo"] != DBNull.Value) { obj.Cargo = (string)dataReader["Cargo"]; }
                            if (dataReader["Email"] != DBNull.Value) { obj.Email = (string)dataReader["Email"]; }
                            if (dataReader["Telefono"] != DBNull.Value) { obj.Telefono = (string)dataReader["Telefono"]; }
                            if (dataReader["Estado"] != DBNull.Value) { obj.Estado = (byte)dataReader["Estado"]; }
                            if (dataReader["CambiarContrasenia"] != DBNull.Value) { obj.CambiarContrasenia = (bool)dataReader["CambiarContrasenia"]; }
                            if (dataReader["FechaVencimientoCta"] != DBNull.Value) { obj.FechaVencimientoCta = (DateTime)dataReader["FechaVencimientoCta"]; }
                            if (dataReader["FechaVencimiento"] != DBNull.Value) { obj.FechaVencimiento = (DateTime)dataReader["FechaVencimiento"]; }
                            if (dataReader["AuditoriaUC"] != DBNull.Value) { obj.AuditoriaUC = (int)dataReader["AuditoriaUC"]; }
                            if (dataReader["AuditoriaUM"] != DBNull.Value) { obj.AuditoriaUM = (int)dataReader["AuditoriaUM"]; }
                            if (dataReader["AuditoriaFC"] != DBNull.Value) { obj.AuditoriaFC = (DateTime)dataReader["AuditoriaFC"]; }
                            if (dataReader["AuditoriaFM"] != DBNull.Value) { obj.AuditoriaFM = (DateTime)dataReader["AuditoriaFM"]; }

                            list.Add(obj);
                        }
                    }
                    return list;
                }
            }
        }

    }
}