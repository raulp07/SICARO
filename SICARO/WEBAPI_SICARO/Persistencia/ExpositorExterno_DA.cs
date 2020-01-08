using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WEBAPI_SICARO.Models;

namespace WEBAPI_SICARO.Persistencia
{
    public class ExpositorExterno_DA
    {

        private static ExpositorExterno_DA accion;
        private ExpositorExterno_DA() { }
        public static ExpositorExterno_DA Accion
        {
            get
            {
                if (accion == null)
                {
                    accion = new ExpositorExterno_DA();
                }
                return accion;
            }
        }


        public List<ExpositorExterno_EL> List_ExpositorExterno(int iIdExpositorExterno)
        {
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("List_ExpositorExterno", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@iIdExpositorExterno", SqlDbType.Int).Value = iIdExpositorExterno;
                    List<ExpositorExterno_EL> list = new List<ExpositorExterno_EL>();
                    using (IDataReader dataReader = com.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            ExpositorExterno_EL obj = new ExpositorExterno_EL();
                            if (dataReader["iIdExpositorExterno"] != DBNull.Value) { obj.iIdExpositorExterno = (int)dataReader["iIdExpositorExterno"]; }
                            if (dataReader["NombreEmpresa"] != DBNull.Value) { obj.NombreEmpresa = (string)dataReader["NombreEmpresa"]; }
                            if (dataReader["RUC"] != DBNull.Value) { obj.RUC = (string)dataReader["RUC"]; }
                            if (dataReader["Telefono"] != DBNull.Value) { obj.Telefono = (string)dataReader["Telefono"]; }
                            if (dataReader["NombreExpositor"] != DBNull.Value) { obj.NombreExpositor = (string)dataReader["NombreExpositor"]; }
                            if (dataReader["ApellidoPaternoExpositor"] != DBNull.Value) { obj.ApellidoPaternoExpositor = (string)dataReader["ApellidoPaternoExpositor"]; }
                            if (dataReader["ApellidoMaternoExpositor"] != DBNull.Value) { obj.ApellidoMaternoExpositor = (string)dataReader["ApellidoMaternoExpositor"]; }
                            if (dataReader["TipoDocumentoExpositor"] != DBNull.Value) { obj.TipoDocumentoExpositor = Convert.ToString(dataReader["TipoDocumentoExpositor"]); }
                            if (dataReader["NroDocumentoExpositor"] != DBNull.Value) { obj.NroDocumentoExpositor = (string)dataReader["NroDocumentoExpositor"]; }
                            if (dataReader["TelefonoExpositor"] != DBNull.Value) { obj.TelefonoExpositor = (string)dataReader["TelefonoExpositor"]; }
                            list.Add(obj);
                        }
                    }
                    return list;
                }

            }
        }

        public int CRUDExpositorExterno(ExpositorExterno_EL C)
        {
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("CRUD_ExpositorExterno", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@iIdExpositorExterno", SqlDbType.Int).Value = C.iIdExpositorExterno;
                    com.Parameters.Add("@NombreEmpresa", SqlDbType.VarChar).Value = C.NombreEmpresa;
                    com.Parameters.Add("@RUC", SqlDbType.VarChar).Value = C.RUC;
                    com.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = C.Telefono;
                    com.Parameters.Add("@NombreExpositor", SqlDbType.VarChar).Value = C.NombreExpositor;
                    com.Parameters.Add("@ApellidoPaternoExpositor", SqlDbType.VarChar).Value = C.ApellidoPaternoExpositor;
                    com.Parameters.Add("@ApellidoMaternoExpositor", SqlDbType.VarChar).Value = C.ApellidoMaternoExpositor;
                    com.Parameters.Add("@TipoDocumentoExpositor", SqlDbType.VarChar).Value = C.TipoDocumentoExpositor;
                    com.Parameters.Add("@NroDocumentoExpositor", SqlDbType.VarChar).Value = C.NroDocumentoExpositor;
                    com.Parameters.Add("@TelefonoExpositor", SqlDbType.VarChar).Value = C.TelefonoExpositor;
                    return com.ExecuteNonQuery();
                }
            }
        }
    }
}