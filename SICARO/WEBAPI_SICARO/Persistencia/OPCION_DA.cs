﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WEBAPI_SICARO.Modles;

namespace WEBAPI_SICARO.Persistencia
{
    public class OPCION_DA
    {
        private static OPCION_DA opcion;
        private OPCION_DA() { }
        public static OPCION_DA Opcion
        {
            get
            {
                if (opcion == null)
                {
                    opcion = new OPCION_DA();
                }
                return opcion;
            }
        }

        public Opcion_EL GetOpcionByID(int? idOpcion)
        {

            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("USPS_Opcion", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@idOpcion", SqlDbType.Int).Value = idOpcion;
                    com.Parameters.Add("@estado", SqlDbType.Int).Value = 0;
                    Opcion_EL opcion = null;
                    IDataReader dr = null;

                    using (IDataReader dataReader = com.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            opcion = new Opcion_EL();
                            if (dataReader["Id"] != DBNull.Value) { opcion.Id = (int)dataReader["Id"]; }

                            if (dataReader["Nombre"] != DBNull.Value) { opcion.Nombre = (string)dataReader["Nombre"]; }
                            if (dataReader["PadreId"] != DBNull.Value) { opcion.PadreId = (int)dataReader["PadreId"]; }
                            if (dataReader["Nivel"] != DBNull.Value) { opcion.Nivel = (int)dataReader["Nivel"]; }
                            if (dataReader["NivelPadre"] != DBNull.Value) { opcion.NivelPadre = (int)dataReader["NivelPadre"]; }
                            if (dataReader["Imagen"] != DBNull.Value) { opcion.Imagen = (string)dataReader["Imagen"]; }
                            if (dataReader["Controler"] != DBNull.Value) { opcion.Controlador = (string)dataReader["Controler"]; }
                            if (dataReader["Accion"] != DBNull.Value) { opcion.Accion = (string)dataReader["Accion"]; }
                            if (dataReader["Orden"] != DBNull.Value) { opcion.Orden = (int)dataReader["Orden"]; }
                            if (dataReader["Observacion"] != DBNull.Value) { opcion.Observacion = (string)dataReader["Observacion"]; }
                            if (dataReader["Estado"] != DBNull.Value) { opcion.Estado = Convert.ToInt16(dataReader["Estado"]); }

                        }
                    }
                    return opcion;
                }
            }

        }

        public IEnumerable<Opcion_EL> GETOPCION(int? idOpcion)
        {

            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("USPS_Opcion", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@idOpcion", SqlDbType.Int).Value = idOpcion;
                    //com.Parameters.Add("@estado", SqlDbType.Int).Value = -1;
                    List<Opcion_EL> ListOpcion = new List<Opcion_EL>();
                    Opcion_EL opcion = null;

                    using (IDataReader dataReader = com.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            opcion = new Opcion_EL();
                            if (dataReader["Id"] != DBNull.Value) { opcion.Id = (int)dataReader["Id"]; }
                            if (dataReader["Nombre"] != DBNull.Value) { opcion.Nombre = (string)dataReader["Nombre"]; }
                            if (dataReader["PadreId"] != DBNull.Value) { opcion.PadreId = (int)dataReader["PadreId"]; }
                            if (dataReader["Nivel"] != DBNull.Value) { opcion.Nivel = (int)dataReader["Nivel"]; }
                            if (dataReader["NivelPadre"] != DBNull.Value) { opcion.NivelPadre = (int)dataReader["NivelPadre"]; }
                            if (dataReader["Imagen"] != DBNull.Value) { opcion.Imagen = (string)dataReader["Imagen"]; }
                            if (dataReader["Controler"] != DBNull.Value) { opcion.Controlador = (string)dataReader["Controler"]; }
                            if (dataReader["Accion"] != DBNull.Value) { opcion.Accion = (string)dataReader["Accion"]; }
                            if (dataReader["Orden"] != DBNull.Value) { opcion.Orden = (int)dataReader["Orden"]; }
                            if (dataReader["Observacion"] != DBNull.Value) { opcion.Observacion = (string)dataReader["Observacion"]; }
                            if (dataReader["Estado"] != DBNull.Value) { opcion.Estado = Convert.ToInt16(dataReader["Estado"]); }
                            ListOpcion.Add(opcion);
                        }
                    }
                    return ListOpcion;
                }
            }

        }

        public int InsertOpcion(Opcion_EL C)
        {
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("spInsert_Opcion", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@Id", SqlDbType.Int).Value = C.Id;
                    com.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = C.Nombre;
                    com.Parameters.Add("@PadreId", SqlDbType.Int).Value = C.PadreId;
                    com.Parameters.Add("@Controler", SqlDbType.VarChar).Value = C.Controlador;
                    com.Parameters.Add("@Accion", SqlDbType.VarChar).Value = C.Accion;
                    com.Parameters.Add("@Orden", SqlDbType.Int).Value = C.Orden;
                    return com.ExecuteNonQuery();
                }
            }
        }

        public Respuesta EliminarOpcion(int idOpcion)
        {
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("Sp_Del_Menu", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@id_tabla", SqlDbType.Int).Value = idOpcion;

                    Respuesta res = new Respuesta();
                    res.codigo = com.ExecuteNonQuery();

                    return res;
                }
            }
        }
    }
}