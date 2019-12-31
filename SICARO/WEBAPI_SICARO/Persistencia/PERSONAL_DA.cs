using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WEBAPI_SICARO.Modles;

namespace WEBAPI_SICARO.Persistencia
{
    public class PERSONAL_DA
    {
        private static PERSONAL_DA accion;
        private PERSONAL_DA() { }
        public static PERSONAL_DA Accion
        {
            get
            {
                if (accion == null)
                {
                    accion = new PERSONAL_DA();
                }
                return accion;
            }
        }

        public List<PERSONAL_EL> GetAllPERSONAL(int iIdPersonal)
        {
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("spGet_PERSONAL", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@iIdPersonal", SqlDbType.Int).Value = iIdPersonal;
                    List<PERSONAL_EL> list = new List<PERSONAL_EL>();

                    using (IDataReader dataReader = com.ExecuteReader())
                    {

                        while (dataReader.Read())
                        {

                            PERSONAL_EL obj = new PERSONAL_EL();

                            if (dataReader["iIdPersonal"] != DBNull.Value) { obj.iIdPersonal = (int)dataReader["iIdPersonal"]; }
                            if (dataReader["vCodPersonal"] != DBNull.Value) { obj.vCodPersonal = (string)dataReader["vCodPersonal"]; }
                            if (dataReader["vNombrePersonal"] != DBNull.Value) { obj.vNombrePersonal = (string)dataReader["vNombrePersonal"]; }
                            if (dataReader["vApellidoPaternoPersonal"] != DBNull.Value) { obj.vApellidoPaternoPersonal = (string)dataReader["vApellidoPaternoPersonal"]; }
                            if (dataReader["vApellidoMaternoPersonal"] != DBNull.Value) { obj.vApellidoMaternoPersonal = (string)dataReader["vApellidoMaternoPersonal"]; }
                            if (dataReader["dFechaNacimiento"] != DBNull.Value) { obj.dFechaNacimiento = (DateTime)dataReader["dFechaNacimiento"]; }
                            if (dataReader["vDomicilio"] != DBNull.Value) { obj.vDomicilio = (string)dataReader["vDomicilio"]; }
                            if (dataReader["iIdArea"] != DBNull.Value) { obj.iIdArea = (int)dataReader["iIdArea"]; }
                            if (dataReader["iUbigeo"] != DBNull.Value) { obj.iUbigeo = (string)dataReader["iUbigeo"]; }
                            if (dataReader["iTipoPersonal"] != DBNull.Value) { obj.iTipoPersonal = (int)dataReader["iTipoPersonal"]; }
                            if (dataReader["iEstadoPersonal"] != DBNull.Value) { obj.iEstadoPersonal = (int)dataReader["iEstadoPersonal"]; }
                            if (dataReader["de_Area"] != DBNull.Value) { obj.de_Area = (string)dataReader["de_Area"]; }
                            if (dataReader["Email"] != DBNull.Value) { obj.Email = (string)dataReader["Email"]; }
                            if (dataReader["TipoDocumento"] != DBNull.Value) { obj.TipoDocumento = (int)dataReader["TipoDocumento"]; }
                            if (dataReader["de_TipoDocumento"] != DBNull.Value) { obj.de_TipoDocumento = (string)dataReader["de_TipoDocumento"]; }                            
                            if (dataReader["NroDocumento"] != DBNull.Value) { obj.NroDocumento = (string)dataReader["NroDocumento"]; }
                            if (dataReader["Telefono"] != DBNull.Value) { obj.Telefono = (string)dataReader["Telefono"]; }
                            if (dataReader["CtaUsuario"] != DBNull.Value) { obj.CtaUsuario = (string)dataReader["CtaUsuario"]; }
                            list.Add(obj);

                        }

                    }

                    return list;

                }
            }
        }
        public int InsertPERSONAL(PERSONAL_EL P)
        {
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("spInsertPERSONAL", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@vNombrePersonal", SqlDbType.VarChar).Value = P.vNombrePersonal;
                    com.Parameters.Add("@vApellidoPaternoPersonal", SqlDbType.VarChar).Value = P.vApellidoPaternoPersonal;
                    com.Parameters.Add("@vApellidoMaternoPersonal", SqlDbType.VarChar).Value = P.vApellidoMaternoPersonal;
                    com.Parameters.Add("@dFechaNacimiento", SqlDbType.Date).Value = P.dFechaNacimiento;
                    com.Parameters.Add("@vDomicilio", SqlDbType.VarChar).Value = P.vDomicilio;
                    com.Parameters.Add("@iIdArea", SqlDbType.Int).Value = P.iIdArea;
                    com.Parameters.Add("@iUbigeo", SqlDbType.VarChar).Value = P.iUbigeo;
                    com.Parameters.Add("@iTipoPersonal", SqlDbType.Int).Value = P.iTipoPersonal;
                    com.Parameters.Add("@iEstadoPersonal", SqlDbType.Int).Value = P.iEstadoPersonal;
                    com.Parameters.Add("@Email", SqlDbType.VarChar).Value = P.Email;
                    com.Parameters.Add("@TipoDocumento", SqlDbType.Int).Value = P.TipoDocumento;
                    com.Parameters.Add("@NroDocumento", SqlDbType.VarChar).Value = P.NroDocumento;
                    com.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = P.Telefono;
                    com.Parameters.Add("@iUsuarioCrea", SqlDbType.Int).Value = P.iUsuarioCrea;

                    return com.ExecuteNonQuery();
                }
            }
        }
        public int UpdatePERSONAL(PERSONAL_EL P)
        {
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("spUpdatePERSONAL", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@iIdPersonal", SqlDbType.Int).Value = P.iIdPersonal;
                    com.Parameters.Add("@vNombrePersonal", SqlDbType.VarChar).Value = P.vNombrePersonal;
                    com.Parameters.Add("@vApellidoPaternoPersonal", SqlDbType.VarChar).Value = P.vApellidoPaternoPersonal;
                    com.Parameters.Add("@vApellidoMaternoPersonal", SqlDbType.VarChar).Value = P.vApellidoMaternoPersonal;
                    com.Parameters.Add("@dFechaNacimiento", SqlDbType.Date).Value = P.dFechaNacimiento;
                    com.Parameters.Add("@vDomicilio", SqlDbType.VarChar).Value = P.vDomicilio;
                    com.Parameters.Add("@iIdArea", SqlDbType.Int).Value = P.iIdArea;
                    com.Parameters.Add("@iUbigeo", SqlDbType.VarChar).Value = P.iUbigeo;
                    com.Parameters.Add("@iTipoPersonal", SqlDbType.Int).Value = P.iTipoPersonal;
                    com.Parameters.Add("@iEstadoPersonal", SqlDbType.Int).Value = P.iEstadoPersonal;
                    com.Parameters.Add("@Email", SqlDbType.VarChar).Value = P.Email;
                    com.Parameters.Add("@TipoDocumento", SqlDbType.Int).Value = P.TipoDocumento;
                    com.Parameters.Add("@NroDocumento", SqlDbType.VarChar).Value = P.NroDocumento;
                    com.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = P.Telefono;
                    com.Parameters.Add("@iUsuarioMod", SqlDbType.Int).Value = P.iUsuarioMod;

                    return com.ExecuteNonQuery();
                }
            }
        }

    }
}