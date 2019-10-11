using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WEBAPI_SICARO.Modles;

namespace WEBAPI_SICARO.Persistencia
{
    public class PROVEEDOR_DA
    {

        private static PROVEEDOR_DA accion;
        private PROVEEDOR_DA() { }
        public static PROVEEDOR_DA Accion
        {
            get
            {
                if (accion == null)
                {
                    accion = new PROVEEDOR_DA();
                }
                return accion;
            }
        }

        public List<PROVEEDOR_EL> GetAllPROVEEDOR(int iIdProveedor)
        {
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("spGet_PROVEEDOR", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@iIdProveedor", SqlDbType.Int).Value = iIdProveedor;

                    List<PROVEEDOR_EL> list = new List<PROVEEDOR_EL>();

                    using (IDataReader dataReader = com.ExecuteReader())
                    {

                        while (dataReader.Read())
                        {

                            PROVEEDOR_EL obj = new PROVEEDOR_EL();

                            if (dataReader["iIdProveedor"] != DBNull.Value) { obj.iIdProveedor = (int)dataReader["iIdProveedor"]; }
                            if (dataReader["vNombreProveedor"] != DBNull.Value) { obj.vNombreProveedor = (string)dataReader["vNombreProveedor"]; }
                            if (dataReader["vApellidoPaterno"] != DBNull.Value) { obj.vApellidoPaterno = (string)dataReader["vApellidoPaterno"]; }
                            if (dataReader["vApellidoMaterno"] != DBNull.Value) { obj.vApellidoMaterno = (string)dataReader["vApellidoMaterno"]; }
                            if (dataReader["iTipoDocumento"] != DBNull.Value) { obj.iTipoDocumento = (int)dataReader["iTipoDocumento"]; }
                            if (dataReader["vDocumento"] != DBNull.Value) { obj.vDocumento = (string)dataReader["vDocumento"]; }
                            if (dataReader["vTelefono"] != DBNull.Value) { obj.vTelefono = (string)dataReader["vTelefono"]; }
                            if (dataReader["vNroLicenciaMunicipal"] != DBNull.Value) { obj.vNroLicenciaMunicipal = (string)dataReader["vNroLicenciaMunicipal"]; }
                            if (dataReader["vNroInspeccionSanitaria"] != DBNull.Value) { obj.vNroInspeccionSanitaria = (string)dataReader["vNroInspeccionSanitaria"]; }
                            if (dataReader["iEstadoEmpresa"] != DBNull.Value) { obj.iEstadoEmpresa = (int)dataReader["iEstadoEmpresa"]; }
                            if (dataReader["iTipoEmpresa"] != DBNull.Value) { obj.iTipoEmpresa = (int)dataReader["iTipoEmpresa"]; }
                            if (dataReader["iUbigeo"] != DBNull.Value) { obj.iUbigeo = (string)dataReader["iUbigeo"]; }
                            if (dataReader["iUsuarioCrea"] != DBNull.Value) { obj.iUsuarioCrea = (int)dataReader["iUsuarioCrea"]; }
                            if (dataReader["dFechaCrea"] != DBNull.Value) { obj.dFechaCrea = (DateTime)dataReader["dFechaCrea"]; }
                            if (dataReader["iUsuarioMod"] != DBNull.Value) { obj.iUsuarioMod = (int)dataReader["iUsuarioMod"]; }
                            if (dataReader["dFechaMod"] != DBNull.Value) { obj.dFechaMod = (DateTime)dataReader["dFechaMod"]; }

                            list.Add(obj);

                        }

                    }

                    return list;

                }
            }
        }

        public int InsertPROVEEDOR(PROVEEDOR_EL C)
        {
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("spInsertPROVEEDOR", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@vNombreProveedor", SqlDbType.VarChar).Value = C.vNombreProveedor;
                    com.Parameters.Add("@vApellidoPaterno", SqlDbType.VarChar).Value = C.vApellidoPaterno;
                    com.Parameters.Add("@vApellidoMaterno", SqlDbType.VarChar).Value = C.vApellidoMaterno;
                    com.Parameters.Add("@iTipoDocumento", SqlDbType.Int).Value = C.iTipoDocumento;
                    com.Parameters.Add("@vDocumento", SqlDbType.VarChar).Value = C.vDocumento;
                    com.Parameters.Add("@vTelefono", SqlDbType.VarChar).Value = C.vTelefono;
                    com.Parameters.Add("@vNroLicenciaMunicipal", SqlDbType.VarChar).Value = C.vNroLicenciaMunicipal;
                    com.Parameters.Add("@vNroInspeccionSanitaria", SqlDbType.VarChar).Value = C.vNroInspeccionSanitaria;
                    com.Parameters.Add("@iEstadoEmpresa", SqlDbType.Int).Value = C.iEstadoEmpresa;
                    com.Parameters.Add("@iTipoEmpresa", SqlDbType.Int).Value = C.iTipoEmpresa;
                    com.Parameters.Add("@iUbigeo", SqlDbType.Char, 6).Value = C.iUbigeo;
                    com.Parameters.Add("@iUsuarioCrea", SqlDbType.Int).Value = C.iUsuarioCrea;
                    return com.ExecuteNonQuery();
                }
            }
        }

        public int UpdatePROVEEDOR(PROVEEDOR_EL C)
        {
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("spUpdatePROVEEDOR", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@iIdProveedor", SqlDbType.Int).Value = C.iIdProveedor;
                    com.Parameters.Add("@vNombreProveedor", SqlDbType.VarChar).Value = C.vNombreProveedor;
                    com.Parameters.Add("@vApellidoPaterno", SqlDbType.VarChar).Value = C.vApellidoPaterno;
                    com.Parameters.Add("@vApellidoMaterno", SqlDbType.VarChar).Value = C.vApellidoMaterno;
                    com.Parameters.Add("@iTipoDocumento", SqlDbType.Int).Value = C.iTipoDocumento;
                    com.Parameters.Add("@vDocumento", SqlDbType.VarChar).Value = C.vDocumento;
                    com.Parameters.Add("@vTelefono", SqlDbType.VarChar).Value = C.vTelefono;
                    com.Parameters.Add("@vNroLicenciaMunicipal", SqlDbType.VarChar).Value = C.vNroLicenciaMunicipal;
                    com.Parameters.Add("@vNroInspeccionSanitaria", SqlDbType.VarChar).Value = C.vNroInspeccionSanitaria;
                    com.Parameters.Add("@iEstadoEmpresa", SqlDbType.Int).Value = C.iEstadoEmpresa;
                    com.Parameters.Add("@iTipoEmpresa", SqlDbType.Int).Value = C.iTipoEmpresa;
                    com.Parameters.Add("@iUbigeo", SqlDbType.Char,6).Value = C.iUbigeo;
                    com.Parameters.Add("@iUsuarioMod", SqlDbType.Int).Value = C.iUsuarioCrea;
                    return com.ExecuteNonQuery();
                }
            }
        }

        public int DeleteTGeneral(int dato)
        {
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("spDeletePROVEEDOR", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Inicio Parámetros
                    cmd.Parameters.Add("@iIdProveedor", SqlDbType.Int).Value = dato;
                    return cmd.ExecuteNonQuery();
                }
            }

        }



    }
}