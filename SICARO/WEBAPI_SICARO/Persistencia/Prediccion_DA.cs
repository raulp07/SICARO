using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WEBAPI_SICARO.Models;

namespace WEBAPI_SICARO.Persistencia
{
    public class Prediccion_DA
    {
        private static Prediccion_DA accion;
        private Prediccion_DA() { }
        public static Prediccion_DA Accion
        {
            get
            {
                if (accion == null)
                {
                    accion = new Prediccion_DA();
                }
                return accion;
            }
        }

        public List<pronostico_duracion_insumo_EL> GetAllpronostico_duracion_insumo(int Producto,int Proveedor,int UnidadMedida,int vecesutilizadoprod)
        {
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("GetAllPrediccionGrafico", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@opcion", SqlDbType.Int).Value = 1;
                    com.Parameters.Add("@Producto", SqlDbType.Int).Value = Producto;
                    com.Parameters.Add("@Proveedor", SqlDbType.Int).Value = Proveedor;
                    com.Parameters.Add("@UnidadMedida", SqlDbType.Int).Value = UnidadMedida;
                    com.Parameters.Add("@vecesutilizadoprod", SqlDbType.Int).Value = vecesutilizadoprod;
                    List<pronostico_duracion_insumo_EL> list = new List<pronostico_duracion_insumo_EL>();
                    using (IDataReader dataReader = com.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            pronostico_duracion_insumo_EL obj = new pronostico_duracion_insumo_EL();
                            if (dataReader["producto"] != DBNull.Value) { obj.producto = (int)dataReader["producto"]; }
                            if (dataReader["proveedor"] != DBNull.Value) { obj.proveedor = (int)dataReader["proveedor"]; }
                            if (dataReader["unidadmedida"] != DBNull.Value) { obj.unidadmedida = (int)dataReader["unidadmedida"]; }
                            if (dataReader["peso"] != DBNull.Value) { obj.peso = (int)dataReader["peso"]; }
                            if (dataReader["vecesutilizadoprod"] != DBNull.Value) { obj.vecesutilizadoprod = (int)dataReader["vecesutilizadoprod"]; }
                            if (dataReader["tiempo"] != DBNull.Value) { obj.tiempo = (int)dataReader["tiempo"]; }
                            list.Add(obj);
                        }
                    }
                    return list;
                }
            }
        }

        public List<pronostico_arribo_insumo_EL> GetAllpronostico_arribo_insumo(int Producto, int Proveedor, int UnidadMedida)
        {
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("GetAllPrediccionGrafico", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@opcion", SqlDbType.Int).Value = 2;
                    com.Parameters.Add("@Producto", SqlDbType.Int).Value = Producto;
                    com.Parameters.Add("@Proveedor", SqlDbType.Int).Value = Proveedor;
                    com.Parameters.Add("@UnidadMedida", SqlDbType.Int).Value = UnidadMedida;
                    List<pronostico_arribo_insumo_EL> list = new List<pronostico_arribo_insumo_EL>();
                    using (IDataReader dataReader = com.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            pronostico_arribo_insumo_EL obj = new pronostico_arribo_insumo_EL();
                            if (dataReader["producto"] != DBNull.Value) { obj.producto = (int)dataReader["producto"]; }
                            if (dataReader["proveedor"] != DBNull.Value) { obj.proveedor = (int)dataReader["proveedor"]; }
                            if (dataReader["unidadmedida"] != DBNull.Value) { obj.unidadmedida = (int)dataReader["unidadmedida"]; }
                            if (dataReader["peso"] != DBNull.Value) { obj.peso = (int)dataReader["peso"]; }
                            if (dataReader["tiempo"] != DBNull.Value) { obj.tiempo = (int)dataReader["tiempo"]; }
                            list.Add(obj);
                        }
                    }
                    return list;
                }
            }
        }

        public List<pronostico_cantidad_producida_EL> GetAllpronostico_cantidad_producida(int Producto, int actividad)
        {
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("GetAllPrediccionGrafico", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@opcion", SqlDbType.Int).Value = 3;
                    com.Parameters.Add("@Producto", SqlDbType.Int).Value = Producto;
                    com.Parameters.Add("@actividad", SqlDbType.Int).Value = actividad;
                    List<pronostico_cantidad_producida_EL> list = new List<pronostico_cantidad_producida_EL>();
                    using (IDataReader dataReader = com.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            pronostico_cantidad_producida_EL obj = new pronostico_cantidad_producida_EL();
                            if (dataReader["producto"] != DBNull.Value) { obj.producto = (int)dataReader["producto"]; }
                            if (dataReader["actividad"] != DBNull.Value) { obj.actividad = (int)dataReader["actividad"]; }
                            if (dataReader["cantidad"] != DBNull.Value) { obj.cantidad = (int)dataReader["cantidad"]; }
                            if (dataReader["tiempo"] != DBNull.Value) { obj.tiempo = (int)dataReader["tiempo"]; }
                            list.Add(obj);
                        }
                    }
                    return list;
                }
            }
        }

        public List<pronostico_merma_insumo_EL> GetAllpronostico_merma_insumo(int Producto, int Proveedor,int unidadmedida)
        {
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("GetAllPrediccionGrafico", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@opcion", SqlDbType.Int).Value = 4;
                    com.Parameters.Add("@Producto", SqlDbType.Int).Value = Producto;
                    com.Parameters.Add("@Proveedor", SqlDbType.Int).Value = Proveedor;
                    com.Parameters.Add("@unidadmedida", SqlDbType.Int).Value = unidadmedida;
                    List<pronostico_merma_insumo_EL> list = new List<pronostico_merma_insumo_EL>();
                    using (IDataReader dataReader = com.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            pronostico_merma_insumo_EL obj = new pronostico_merma_insumo_EL();
                            if (dataReader["producto"] != DBNull.Value) { obj.producto = (int)dataReader["producto"]; }
                            if (dataReader["proveedor"] != DBNull.Value) { obj.proveedor = (int)dataReader["proveedor"]; }
                            if (dataReader["unidadmedida"] != DBNull.Value) { obj.unidadmedida = (int)dataReader["unidadmedida"]; }
                            if (dataReader["peso"] != DBNull.Value) { obj.peso = (int)dataReader["peso"]; }
                            if (dataReader["merma"] != DBNull.Value) { obj.merma = (int)dataReader["merma"]; }
                            list.Add(obj);
                        }
                    }
                    return list;
                }
            }
        }
    }
}