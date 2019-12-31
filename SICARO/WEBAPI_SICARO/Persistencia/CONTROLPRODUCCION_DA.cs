using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WEBAPI_SICARO.Modles;

namespace WEBAPI_SICARO.Persistencia
{
    public class CONTROLPRODUCCION_DA
    {

        private static CONTROLPRODUCCION_DA accion;
        private CONTROLPRODUCCION_DA() { }
        public static CONTROLPRODUCCION_DA Accion
        {
            get
            {
                if (accion == null)
                {
                    accion = new CONTROLPRODUCCION_DA();
                }
                return accion;
            }
        }

        public List<CONTROLPRODUCCION_EL> GetCONTROLPRODUCCIONAll(int idControlProduccion,int tipoPronostico,int idProducto,int idProveedor,int idIntervaloProduccion,int idActividad)
        {
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("spGetCONTROLPRODUCCIONAll", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@idControlProduccion", SqlDbType.Int).Value = idControlProduccion;
                    com.Parameters.Add("@tipoPronostico", SqlDbType.Int).Value = tipoPronostico;
                    com.Parameters.Add("@idProducto", SqlDbType.Int).Value = idProducto;
                    com.Parameters.Add("@idProveedor", SqlDbType.Int).Value = idProveedor;
                    com.Parameters.Add("@idIntervaloProduccion", SqlDbType.Int).Value = idIntervaloProduccion;
                    com.Parameters.Add("@idActividad", SqlDbType.Int).Value = idActividad;

                    List<CONTROLPRODUCCION_EL> list = new List<CONTROLPRODUCCION_EL>();

                    using (IDataReader dataReader = com.ExecuteReader())
                    {

                        while (dataReader.Read())
                        {

                            CONTROLPRODUCCION_EL obj = new CONTROLPRODUCCION_EL();

                            if (dataReader["idControlProduccion"] != DBNull.Value) { obj.idControlProduccion = (int)dataReader["idControlProduccion"]; }
                            if (dataReader["tipoPronostico"] != DBNull.Value) { obj.tipoPronostico = (int)dataReader["tipoPronostico"]; }
                            if (dataReader["idProducto"] != DBNull.Value) { obj.idProducto = (int)dataReader["idProducto"]; }
                            if (dataReader["idProveedor"] != DBNull.Value) { obj.idProveedor = (int)dataReader["idProveedor"]; }
                            if (dataReader["idIntervaloProduccion"] != DBNull.Value) { obj.idIntervaloProduccion = (int)dataReader["idIntervaloProduccion"]; }
                            if (dataReader["idUnidadMedida"] != DBNull.Value) { obj.idUnidadMedida = (int)dataReader["idUnidadMedida"]; }
                            if (dataReader["Peso"] != DBNull.Value) { obj.Peso = (int)dataReader["Peso"]; }
                            if (dataReader["idActividad"] != DBNull.Value) { obj.idActividad = (int)dataReader["idActividad"]; }
                            if (dataReader["cantidadProducida"] != DBNull.Value) { obj.cantidadProducida = (int)dataReader["cantidadProducida"]; }
                            if (dataReader["PRECISION"] != DBNull.Value) { obj.PRECISION = (string)dataReader["PRECISION"]; }
                            if (dataReader["ErrorMedioCuadratico"] != DBNull.Value) { obj.ErrorMedioCuadratico = (string)dataReader["ErrorMedioCuadratico"]; }
                            if (dataReader["predicion"] != DBNull.Value) { obj.predicion = (int)dataReader["predicion"]; }
                            if (dataReader["Color"] != DBNull.Value) { obj.Color = (string)dataReader["Color"]; }
                            if (dataReader["fechaProduccion"] != DBNull.Value) { obj.fechaProduccion = (DateTime)dataReader["fechaProduccion"]; }
                            if (dataReader["indicador"] != DBNull.Value) { obj.indicador = (string)dataReader["indicador"]; }


                            list.Add(obj);

                        }

                    }

                    return list;
                }
            }
        }

        public int InsertCONTROLPRODUCCION(CONTROLPRODUCCION_EL CP)
        {
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("spInsertCONTROLPRODUCCION", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    
                    com.Parameters.Add("@tipoPronostico", SqlDbType.Int).Value = CP.tipoPronostico;
                    com.Parameters.Add("@idProducto", SqlDbType.Int).Value = CP.idProducto;
                    com.Parameters.Add("@idProveedor", SqlDbType.Int).Value = CP.idProveedor;
                    com.Parameters.Add("@idIntervaloProduccion", SqlDbType.Int).Value = CP.idIntervaloProduccion;
                    com.Parameters.Add("@idUnidadMedida", SqlDbType.Int).Value = CP.idUnidadMedida;
                    com.Parameters.Add("@Peso", SqlDbType.Int).Value = CP.Peso;
                    com.Parameters.Add("@idActividad", SqlDbType.Int).Value = CP.idActividad;
                    com.Parameters.Add("@cantidadProducida", SqlDbType.Int).Value = CP.cantidadProducida;
                    com.Parameters.Add("@PRECISION", SqlDbType.VarChar).Value = CP.PRECISION;
                    com.Parameters.Add("@ErrorMedioCuadratico", SqlDbType.VarChar).Value = CP.ErrorMedioCuadratico;
                    com.Parameters.Add("@predicion", SqlDbType.VarChar).Value = CP.predicion;
                    com.Parameters.Add("@Color", SqlDbType.VarChar).Value = CP.Color;
                    com.Parameters.Add("@indicador", SqlDbType.VarChar).Value = CP.indicador;

                    return com.ExecuteNonQuery();
                }
            }

        }
        public int UpdateCONTROLPRODUCCION(CONTROLPRODUCCION_EL CP)
        {
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("spUpdateCONTROLPRODUCCION", con))
                {
                    com.Parameters.Add("@idControlProduccion", SqlDbType.Int).Value = CP.idControlProduccion;
                    com.Parameters.Add("@tipoPronostico", SqlDbType.Int).Value = CP.tipoPronostico;
                    com.Parameters.Add("@idProducto", SqlDbType.Int).Value = CP.idProducto;
                    com.Parameters.Add("@idProveedor", SqlDbType.Int).Value = CP.idProveedor;
                    com.Parameters.Add("@idIntervaloProduccion", SqlDbType.Int).Value = CP.idIntervaloProduccion;
                    com.Parameters.Add("@idUnidadMedida", SqlDbType.Int).Value = CP.idUnidadMedida;
                    com.Parameters.Add("@Peso", SqlDbType.Int).Value = CP.Peso;
                    com.Parameters.Add("@idActividad", SqlDbType.Int).Value = CP.idActividad;
                    com.Parameters.Add("@cantidadProducida", SqlDbType.Int).Value = CP.cantidadProducida;
                    com.Parameters.Add("@PRECISION", SqlDbType.VarChar).Value = CP.PRECISION;
                    com.Parameters.Add("@ErrorMedioCuadratico", SqlDbType.VarChar).Value = CP.ErrorMedioCuadratico;
                    com.Parameters.Add("@predicion", SqlDbType.VarChar).Value = CP.predicion;
                    com.Parameters.Add("@Color", SqlDbType.VarChar).Value = CP.Color;
                    com.Parameters.Add("@fechaProduccion", SqlDbType.DateTime).Value = CP.fechaProduccion;
                    com.Parameters.Add("@indicador", SqlDbType.VarChar).Value = CP.indicador;

                    return com.ExecuteNonQuery();
                }
            }
        }

        public int UpdateCONTROLPRODUCCIONcolor()
        {
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("spUpdateCONTROLPRODUCCION", con))
                {
                    return com.ExecuteNonQuery();
                }
            }

        }
    }
}