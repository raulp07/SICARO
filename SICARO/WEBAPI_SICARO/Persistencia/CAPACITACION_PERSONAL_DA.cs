﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WEBAPI_SICARO.Modles;

namespace WEBAPI_SICARO.Persistencia
{
    public class CAPACITACION_PERSONAL_DA
    {
        private static CAPACITACION_PERSONAL_DA accion;
        private CAPACITACION_PERSONAL_DA() { }
        public static CAPACITACION_PERSONAL_DA Accion
        {
            get
            {
                if (accion == null)
                {
                    accion = new CAPACITACION_PERSONAL_DA();
                }
                return accion;
            }
        }

        public List<CAPACITACION_PERSONAL_EL> GetAllCAPACITACION_PERSONAL()
        {
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("spGetAll_CAPACITACION_PERSONAL", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    List<CAPACITACION_PERSONAL_EL> list = new List<CAPACITACION_PERSONAL_EL>();

                    using (IDataReader dataReader = com.ExecuteReader())
                    {

                        while (dataReader.Read())
                        {

                            CAPACITACION_PERSONAL_EL obj = new CAPACITACION_PERSONAL_EL();

                            if (dataReader["iIdCapacitacionPersonal"] != DBNull.Value) { obj.iIdCapacitacionPersonal = (int)dataReader["iIdCapacitacionPersonal"]; }
                            if (dataReader["iIdPersonal"] != DBNull.Value) { obj.iIdPersonal = (int)dataReader["iIdPersonal"]; }
                            if (dataReader["iIdCapacitacion"] != DBNull.Value) { obj.iIdCapacitacion = (int)dataReader["iIdCapacitacion"]; }
                            if (dataReader["iPuntajePersonal"] != DBNull.Value) { obj.iPuntajePersonal = (int)dataReader["iPuntajePersonal"]; }
                            if (dataReader["vObservacionPersonal"] != DBNull.Value) { obj.vObservacionPersonal = (string)dataReader["vObservacionPersonal"]; }
                            if (dataReader["iAsistenciaPersonal"] != DBNull.Value) { obj.iAsistenciaPersonal = (int)dataReader["iAsistenciaPersonal"]; }
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

        public List<CAPACITACION_PERSONAL_EL> GetAllCAPACITACION_PERSONAL(int iIdCapacitacionPersonal, int iIdPersonal, int iIdCapacitacion)
        {
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("spGet_CAPACITACION_PERSONAL", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@iIdCapacitacionPersonal", SqlDbType.Int).Value = iIdCapacitacionPersonal;
                    com.Parameters.Add("@iIdPersonal", SqlDbType.Int).Value = iIdPersonal;
                    com.Parameters.Add("@iIdCapacitacion", SqlDbType.Int).Value = iIdCapacitacion;

                    List<CAPACITACION_PERSONAL_EL> list = new List<CAPACITACION_PERSONAL_EL>();

                    using (IDataReader dataReader = com.ExecuteReader())
                    {

                        while (dataReader.Read())
                        {

                            CAPACITACION_PERSONAL_EL obj = new CAPACITACION_PERSONAL_EL();

                            if (dataReader["iIdCapacitacionPersonal"] != DBNull.Value) { obj.iIdCapacitacionPersonal = (int)dataReader["iIdCapacitacionPersonal"]; }
                            if (dataReader["iIdPersonal"] != DBNull.Value) { obj.iIdPersonal = (int)dataReader["iIdPersonal"]; }
                            if (dataReader["iIdCapacitacion"] != DBNull.Value) { obj.iIdCapacitacion = (int)dataReader["iIdCapacitacion"]; }
                            if (dataReader["iPuntajePersonal"] != DBNull.Value) { obj.iPuntajePersonal = (int)dataReader["iPuntajePersonal"]; }
                            if (dataReader["vObservacionPersonal"] != DBNull.Value) { obj.vObservacionPersonal = (string)dataReader["vObservacionPersonal"]; }
                            if (dataReader["iAsistenciaPersonal"] != DBNull.Value) { obj.iAsistenciaPersonal = (int)dataReader["iAsistenciaPersonal"]; }
                            if (dataReader["iUsuarioCrea"] != DBNull.Value) { obj.iUsuarioCrea = (int)dataReader["iUsuarioCrea"]; }
                            if (dataReader["dFechaCrea"] != DBNull.Value) { obj.dFechaCrea = (DateTime)dataReader["dFechaCrea"]; }
                            if (dataReader["iUsuarioMod"] != DBNull.Value) { obj.iUsuarioMod = (int)dataReader["iUsuarioMod"]; }
                            if (dataReader["dFechaMod"] != DBNull.Value) { obj.dFechaMod = (DateTime)dataReader["dFechaMod"]; }
                            if (dataReader["nombre"] != DBNull.Value) { obj.nombre = (string)dataReader["nombre"]; }
                            if (dataReader["apellido"] != DBNull.Value) { obj.apellido = (string)dataReader["apellido"]; }
                            if (dataReader["dni"] != DBNull.Value) { obj.dni = (string)dataReader["dni"]; }

                            list.Add(obj);

                        }

                    }

                    return list;
                }
            }
        }

        public int InsertCAPACITACION_PERSONAL(CAPACITACION_PERSONAL_EL CP)
        {
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("spInsertCAPACITACION_PERSONAL", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@iIdPersonal", SqlDbType.Int).Value = CP.iIdPersonal;
                    com.Parameters.Add("@iIdCapacitacion", SqlDbType.Int).Value = CP.iIdCapacitacion;
                    com.Parameters.Add("@iPuntajePersonal", SqlDbType.Int).Value = CP.iPuntajePersonal;
                    com.Parameters.Add("@vObservacionPersonal", SqlDbType.VarChar).Value = CP.vObservacionPersonal == null ? "" : CP.vObservacionPersonal;
                    com.Parameters.Add("@iAsistenciaPersonal", SqlDbType.Int).Value = CP.iAsistenciaPersonal;
                    com.Parameters.Add("@iUsuarioCrea", SqlDbType.Int).Value = CP.iUsuarioCrea;

                    return com.ExecuteNonQuery();
                }
            }

        }
        public int UpdateCAPACITACION_PERSONAL(CAPACITACION_PERSONAL_EL CP)
        {
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("spUpdateCAPACITACION_PERSONAL", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@iIdCapacitacionPersonal", SqlDbType.Int).Value = CP.iIdCapacitacionPersonal;
                    com.Parameters.Add("@iIdPersonal", SqlDbType.Int).Value = CP.iIdPersonal;
                    com.Parameters.Add("@iIdCapacitacion", SqlDbType.Int).Value = CP.iIdCapacitacion;
                    com.Parameters.Add("@iPuntajePersonal", SqlDbType.Int).Value = CP.iPuntajePersonal;
                    com.Parameters.Add("@vObservacionPersonal", SqlDbType.VarChar).Value = CP.vObservacionPersonal;
                    com.Parameters.Add("@iAsistenciaPersonal", SqlDbType.Int).Value = CP.iAsistenciaPersonal;
                    com.Parameters.Add("@iUsuarioMod", SqlDbType.Int).Value = CP.iUsuarioMod;

                    return com.ExecuteNonQuery();
                }
            }

        }


        public int RegistrarAsistencia(List<CAPACITACION_PERSONAL_EL> ListaCP)
        {
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                try
                {
                    con.Open();
                    foreach (CAPACITACION_PERSONAL_EL CP in ListaCP)
                    {
                        using (SqlCommand com = new SqlCommand("sp_RegistrarAsistencia", con))
                        {
                            com.CommandType = CommandType.StoredProcedure;
                            com.Parameters.Add("@iIdPersonal", SqlDbType.Int).Value = CP.iIdPersonal;
                            com.Parameters.Add("@iIdCapacitacion", SqlDbType.Int).Value = CP.iIdCapacitacion;
                            com.Parameters.Add("@vObservacionPersonal", SqlDbType.VarChar).Value = CP.vObservacionPersonal;
                            com.Parameters.Add("@iAsistenciaPersonal", SqlDbType.Int).Value = CP.iAsistenciaPersonal;
                            com.Parameters.Add("@iUsuarioMod", SqlDbType.Int).Value = CP.iUsuarioMod;

                            com.ExecuteNonQuery();
                        }
                    }
                    return 0;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
        }

        public string GETOPERADORCORREO(int iidCapacitacion)
        {
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("ListarCorreos", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@iidCapacitacion", SqlDbType.Int).Value = iidCapacitacion;

                    string Correos = "";

                    using (IDataReader dataReader = com.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            if (dataReader["Email"] != DBNull.Value) { Correos += (string)dataReader["Email"] + ";"; }
                        }
                        Correos = Correos.Substring(0, Correos.Length - 1);
                    }
                    return Correos;
                }
            }
        }

    }
}