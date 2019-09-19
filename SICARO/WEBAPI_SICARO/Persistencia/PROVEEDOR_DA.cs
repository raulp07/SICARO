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

        public List<PROVEEDOR_EL> GetAllPROVEEDOR(PROVEEDOR_EL P)
        {
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("spGet_PROVEEDOR", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@iIdProveedor", SqlDbType.Int).Value = P.iIdProveedor;

                    List<PROVEEDOR_EL> list = new List<PROVEEDOR_EL>();

                    using (IDataReader dataReader = com.ExecuteReader())
                    {

                        while (dataReader.Read())
                        {

                            PROVEEDOR_EL obj = new PROVEEDOR_EL();

                            if (dataReader["iIdProveedor"] != DBNull.Value) { obj.iIdProveedor = (int)dataReader["iIdProveedor"]; }
                            if (dataReader["vNombreProveedor"] != DBNull.Value) { obj.vNombreProveedor = (string)dataReader["vNombreProveedor"]; }
                            if (dataReader["vRUC"] != DBNull.Value) { obj.vRUC = (string)dataReader["vRUC"]; }
                            if (dataReader["vTelefono"] != DBNull.Value) { obj.vTelefono = (string)dataReader["vTelefono"]; }
                            if (dataReader["vNroLicenciaMunicipal"] != DBNull.Value) { obj.vNroLicenciaMunicipal = (string)dataReader["vNroLicenciaMunicipal"]; }
                            if (dataReader["vNroInspeccionSanitaria"] != DBNull.Value) { obj.vNroInspeccionSanitaria = (string)dataReader["vNroInspeccionSanitaria"]; }
                            if (dataReader["iEstadoEmpresa"] != DBNull.Value) { obj.iEstadoEmpresa = (int)dataReader["iEstadoEmpresa"]; }
                            if (dataReader["iTipoEmpresa"] != DBNull.Value) { obj.iTipoEmpresa = (int)dataReader["iTipoEmpresa"]; }
                            if (dataReader["iUbigeo"] != DBNull.Value) { obj.iUbigeo = (int)dataReader["iUbigeo"]; }
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
                    com.Parameters.Add("@vRUC", SqlDbType.VarChar).Value = C.vRUC;
                    com.Parameters.Add("@vTelefono", SqlDbType.VarChar).Value = C.vTelefono;
                    com.Parameters.Add("@vNroLicenciaMunicipal", SqlDbType.VarChar).Value = C.vNroLicenciaMunicipal;
                    com.Parameters.Add("@vNroInspeccionSanitaria", SqlDbType.VarChar).Value = C.vNroInspeccionSanitaria;
                    com.Parameters.Add("@iEstadoEmpresa", SqlDbType.Int).Value = C.iEstadoEmpresa;
                    com.Parameters.Add("@iTipoEmpresa", SqlDbType.Int).Value = C.iTipoEmpresa;
                    com.Parameters.Add("@iUbigeo", SqlDbType.Int).Value = C.iUbigeo;
                    com.Parameters.Add("@vDireccion", SqlDbType.VarChar).Value = C.vDireccion;
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
                    com.Parameters.Add("@vRUC", SqlDbType.VarChar).Value = C.vRUC;
                    com.Parameters.Add("@vTelefono", SqlDbType.VarChar).Value = C.vTelefono;
                    com.Parameters.Add("@vNroLicenciaMunicipal", SqlDbType.VarChar).Value = C.vNroLicenciaMunicipal;
                    com.Parameters.Add("@vNroInspeccionSanitaria", SqlDbType.VarChar).Value = C.vNroInspeccionSanitaria;
                    com.Parameters.Add("@iEstadoEmpresa", SqlDbType.Int).Value = C.iEstadoEmpresa;
                    com.Parameters.Add("@iTipoEmpresa", SqlDbType.Int).Value = C.iTipoEmpresa;
                    com.Parameters.Add("@iUbigeo", SqlDbType.Int).Value = C.iUbigeo;    
                    com.Parameters.Add("@vDireccion", SqlDbType.VarChar).Value = C.vDireccion;
                    com.Parameters.Add("@iUsuarioMod", SqlDbType.Int).Value = C.iUsuarioMod;
                    return com.ExecuteNonQuery();
                }
            }
        }


    }
}