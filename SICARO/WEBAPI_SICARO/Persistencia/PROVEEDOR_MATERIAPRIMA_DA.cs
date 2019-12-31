using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WEBAPI_SICARO.Models;

namespace WEBAPI_SICARO.Persistencia
{
    public class PROVEEDOR_MATERIAPRIMA_DA
    {
        private static PROVEEDOR_MATERIAPRIMA_DA accion;
        private PROVEEDOR_MATERIAPRIMA_DA() { }
        public static PROVEEDOR_MATERIAPRIMA_DA Accion
        {
            get
            {
                if (accion == null)
                {
                    accion = new PROVEEDOR_MATERIAPRIMA_DA();
                }
                return accion;
            }
        }

        public List<PROVEEDOR_MATERIAPRIMA_EL> Sel_PROVEEDOR_MATERIAPRIMA(int iIdProveedor,int iIdMateriaPrima)
        {
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("usp_Sel_PROVEEDOR_MATERIAPRIMA", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@iIdProveedor", SqlDbType.Int).Value = iIdProveedor;
                    com.Parameters.Add("@iIdMateriaPrima", SqlDbType.Int).Value = iIdMateriaPrima;

                    List<PROVEEDOR_MATERIAPRIMA_EL> list = new List<PROVEEDOR_MATERIAPRIMA_EL>();

                    using (IDataReader dataReader = com.ExecuteReader())
                    {

                        while (dataReader.Read())
                        {

                            PROVEEDOR_MATERIAPRIMA_EL obj = new PROVEEDOR_MATERIAPRIMA_EL();

                            if (dataReader["iIdProveedor"] != DBNull.Value) { obj.iIdProveedor = (int)dataReader["iIdProveedor"]; }
                            if (dataReader["iIdMateriaPrima"] != DBNull.Value) { obj.iIdMateriaPrima = (int)dataReader["iIdMateriaPrima"]; }
                            if (dataReader["vNombreProveedor"] != DBNull.Value) { obj.vNombreProveedor = (string)dataReader["vNombreProveedor"]; }
                            if (dataReader["vNombreMateriaPrima"] != DBNull.Value) { obj.vNombreMateriaPrima = (string)dataReader["vNombreMateriaPrima"]; }
                            if (dataReader["dFechaEvaluacion"] != DBNull.Value) { obj.dFechaEvaluacion = (DateTime)dataReader["dFechaEvaluacion"]; }

                            list.Add(obj);

                        }

                    }

                    return list;
                }
            }
        }

        public int Ins_PROVEEDOR_MATERIAPRIMA(PROVEEDOR_MATERIAPRIMA_EL CP)
        {
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("usp_Ins_PROVEEDOR_MATERIAPRIMA", con))
                {
                    com.CommandType = CommandType.StoredProcedure;

                    com.Parameters.Add("@iIdProveedor", SqlDbType.Int).Value = CP.iIdProveedor;
                    com.Parameters.Add("@iIdMateriaPrima", SqlDbType.Int).Value = CP.iIdMateriaPrima;
                    com.Parameters.Add("@iUsuarioCrea", SqlDbType.Int).Value = CP.iUsuario;

                    return com.ExecuteNonQuery();
                }
            }

        }
        //public int UpdateCONTROLPRODUCCION(PROVEEDOR_MATERIAPRIMA_EL CP)
        //{
        //    using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
        //    {
        //        con.Open();
        //        using (SqlCommand com = new SqlCommand("spUpdateCONTROLPRODUCCION", con))
        //        {
        //            com.CommandType = CommandType.StoredProcedure;
        //            com.Parameters.Add("@idControlProduccion", SqlDbType.Int).Value = CP.idControlProduccion;
        //            com.Parameters.Add("@idProducto", SqlDbType.Int).Value = CP.idProducto;
        //            com.Parameters.Add("@tipoPronostico", SqlDbType.VarChar).Value = CP.tipoPronostico;
        //            com.Parameters.Add("@fechaProduccion", SqlDbType.DateTime).Value = CP.fechaProduccion;
        //            com.Parameters.Add("@cantidadProducida", SqlDbType.Int).Value = CP.cantidadProducida;
        //            com.Parameters.Add("@idActividadControlProduccion", SqlDbType.Int).Value = CP.idActividadControlProduccion;
        //            com.Parameters.Add("@indicador", SqlDbType.VarChar).Value = CP.indicador;

        //            return com.ExecuteNonQuery();
        //        }
        //    }

        //}
    }
}