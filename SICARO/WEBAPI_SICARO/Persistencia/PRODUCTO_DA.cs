using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WEBAPI_SICARO.Models;

namespace WEBAPI_SICARO.Persistencia
{
    public class PRODUCTO_DA
    {

        private static PRODUCTO_DA accion;
        private PRODUCTO_DA() { }
        public static PRODUCTO_DA Accion
        {
            get
            {
                if (accion == null)
                {
                    accion = new PRODUCTO_DA();
                }
                return accion;
            }
        }

        public List<PRODUCTO_EL> GetAllPRODUCTO(int iIdproducto)
        {
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("usp_Sel_PRODUCTO", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@iIdproducto", SqlDbType.Int).Value = iIdproducto;
                    List<PRODUCTO_EL> list = new List<PRODUCTO_EL>();
                    using (IDataReader dataReader = com.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            PRODUCTO_EL obj = new PRODUCTO_EL();

                            if (dataReader["iIdproducto"] != DBNull.Value) { obj.iIdproducto = (int)dataReader["iIdproducto"]; }
                            if (dataReader["vCodproducto"] != DBNull.Value) { obj.vCodproducto = (string)dataReader["vCodproducto"]; }
                            if (dataReader["vNombreProducto"] != DBNull.Value) { obj.vNombreProducto = (string)dataReader["vNombreProducto"]; }
                            
                            list.Add(obj);
                        }
                    }
                    return list;
                }
            }
        }
        public int InsertPRODUCTO(PRODUCTO_EL P)
        {
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("usp_Ins_PRODUCTO", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@vNombreProducto", SqlDbType.VarChar).Value = P.vNombreProducto;
                    com.Parameters.Add("@iUsuarioCrea", SqlDbType.Int).Value = P.iUsusario;
                    return com.ExecuteNonQuery();
                }
            }
        }
        public int UpdatePRODUCTO(PRODUCTO_EL P)
        {
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("usp_UpdPRODUCTO", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@iIdproducto", SqlDbType.Int).Value = P.iIdproducto;
                    com.Parameters.Add("@vNombreProducto", SqlDbType.VarChar).Value = P.vNombreProducto;
                    com.Parameters.Add("@iUsuarioMod", SqlDbType.VarChar).Value = P.iUsusario;

                    return com.ExecuteNonQuery();

                }
            }
        }
    }
}