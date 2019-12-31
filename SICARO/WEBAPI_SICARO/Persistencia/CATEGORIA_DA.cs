using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WEBAPI_SICARO.Models;

namespace WEBAPI_SICARO.Persistencia
{
    public class CATEGORIA_DA
    {
        private static CATEGORIA_DA accion;
        private CATEGORIA_DA() { }
        public static CATEGORIA_DA Accion
        {
            get
            {
                if (accion == null)
                {
                    accion = new CATEGORIA_DA();
                }
                return accion;
            }
        }

        public List<CATEGORIA_EL> GetAllCATEGORIA(int iIdproducto)
        {
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("spGet_CATEGORIA", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@iIdproducto", SqlDbType.Int).Value = iIdproducto;
                    List<CATEGORIA_EL> list = new List<CATEGORIA_EL>();
                    using (IDataReader dataReader = com.ExecuteReader())
                    {

                        while (dataReader.Read())
                        {

                            CATEGORIA_EL obj = new CATEGORIA_EL();

                            if (dataReader["idCategoria"] != DBNull.Value) { obj.idCategoria = (int)dataReader["idCategoria"]; }
                            if (dataReader["NombreCategoria"] != DBNull.Value) { obj.NombreCategoria = (string)dataReader["NombreCategoria"]; }
                            if (dataReader["RedInicio"] != DBNull.Value) { obj.RedInicio = (int)dataReader["RedInicio"]; }
                            if (dataReader["RedFin"] != DBNull.Value) { obj.RedFin = (int)dataReader["RedFin"]; }
                            if (dataReader["YellowInicio"] != DBNull.Value) { obj.YellowInicio = (int)dataReader["YellowInicio"]; }
                            if (dataReader["YellowFin"] != DBNull.Value) { obj.YellowFin = (int)dataReader["YellowFin"]; }
                            if (dataReader["GreenInicio"] != DBNull.Value) { obj.GreenInicio = (int)dataReader["GreenInicio"]; }
                            if (dataReader["GreenFin"] != DBNull.Value) { obj.GreenFin = (int)dataReader["GreenFin"]; }
                            list.Add(obj);

                        }

                    }
                    return list;
                }

            }
        }

        public int UpdateCategoriaRango(CATEGORIA_EL C)
        {
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("spUpdateCategoria", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@RedInicio", SqlDbType.Int).Value = C.RedInicio;
                    com.Parameters.Add("@RedFin", SqlDbType.Int).Value = C.RedFin;
                    com.Parameters.Add("@YellowInicio", SqlDbType.Int).Value = C.YellowInicio;
                    com.Parameters.Add("@YellowFin", SqlDbType.Int).Value = C.YellowFin;
                    com.Parameters.Add("@GreenInicio", SqlDbType.Int).Value = C.GreenInicio;
                    com.Parameters.Add("@GreenFin", SqlDbType.Int).Value = C.GreenFin;
                    com.Parameters.Add("@idCategoria", SqlDbType.Int).Value = C.idCategoria;
                    return com.ExecuteNonQuery();
                }
            }
        }
    }
}