using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WEBAPI_SICARO.Models;
using WEBAPI_SICARO.Modles;

namespace WEBAPI_SICARO.Persistencia
{
    public class DETALLE_CAPACITACION_PERSONAL_DA
    {

        private static DETALLE_CAPACITACION_PERSONAL_DA accion;
        private DETALLE_CAPACITACION_PERSONAL_DA() { }
        public static DETALLE_CAPACITACION_PERSONAL_DA Accion
        {
            get
            {
                if (accion == null)
                {
                    accion = new DETALLE_CAPACITACION_PERSONAL_DA();
                }
                return accion;
            }
        }

        public List<DETALLE_CAPACITACION_PERSONAL_EL> GetAllDETALLECAPACITACIONPERSONAL(int iIdDetalleCapacitacionPersonal)
        {
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("spGetDETALLE_CAPACITACION_PERSONAL", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@iIdDetalleCapacitacionPersonal", SqlDbType.Int).Value = iIdDetalleCapacitacionPersonal;
                    List<DETALLE_CAPACITACION_PERSONAL_EL> list = new List<DETALLE_CAPACITACION_PERSONAL_EL>();
                    using (IDataReader dataReader = com.ExecuteReader())
                    {

                        while (dataReader.Read())
                        {
                            DETALLE_CAPACITACION_PERSONAL_EL obj = new DETALLE_CAPACITACION_PERSONAL_EL();

                            if (dataReader["iIdDetalleCapacitacionPersonal"] != DBNull.Value) { obj.iIdDetalleCapacitacionPersonal = (int)dataReader["iIdDetalleCapacitacionPersonal"]; }
                            if (dataReader["iIdCapacitacionPersonal"] != DBNull.Value) { obj.iIdCapacitacionPersonal = (int)dataReader["iIdCapacitacionPersonal"]; }
                            if (dataReader["iIdPregunta"] != DBNull.Value) { obj.iIdPregunta = (int)dataReader["iIdPregunta"]; }
                            if (dataReader["iIdOpcion"] != DBNull.Value) { obj.iIdOpcion = (int)dataReader["iIdOpcion"]; }
                            if (dataReader["iEstadoRespuesta"] != DBNull.Value) { obj.iEstadoRespuesta = (int)dataReader["iEstadoRespuesta"]; }
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
        public int InsertDETALLE_CAPACITACION_PERSONAL(IEnumerable<DETALLE_CAPACITACION_PERSONAL_EL> ListaCP)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
                {
                    con.Open();

                    foreach (DETALLE_CAPACITACION_PERSONAL_EL CP in ListaCP)
                    {
                        using (SqlCommand com = new SqlCommand("spInsertDETALLE_CAPACITACION_PERSONAL", con))
                        {
                            com.CommandType = CommandType.StoredProcedure;
                            com.Parameters.Add("@iIdDetalleCapacitacionPersonal", SqlDbType.Int).Value = CP.iIdDetalleCapacitacionPersonal;
                            com.Parameters.Add("@iIdCapacitacionPersonal", SqlDbType.Int).Value = CP.iIdCapacitacionPersonal;
                            com.Parameters.Add("@iIdPregunta", SqlDbType.Int).Value = CP.iIdPregunta;
                            com.Parameters.Add("@iIdOpcion", SqlDbType.Int).Value = CP.iIdOpcion;
                            com.Parameters.Add("@iEstadoRespuesta", SqlDbType.Int).Value = CP.iEstadoRespuesta;
                            com.Parameters.Add("@iUsuarioCrea", SqlDbType.Int).Value = CP.iUsuarioCrea;

                            com.ExecuteNonQuery();
                        }
                    }

                    return 0;
                }
            }
            catch (Exception e)
            {

                return -1;
            }


        }
        public int UpdateDETALLE_CAPACITACION_PERSONAL(DETALLE_CAPACITACION_PERSONAL_EL CP)
        {
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("spUpdateDETALLE_CAPACITACION_PERSONAL", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@iIdDetalleCapacitacionPersonal", SqlDbType.Int).Value = CP.iIdDetalleCapacitacionPersonal;
                    com.Parameters.Add("@iIdCapacitacionPersonal", SqlDbType.Int).Value = CP.iIdCapacitacionPersonal;
                    com.Parameters.Add("@iIdPregunta", SqlDbType.Int).Value = CP.iIdPregunta;
                    com.Parameters.Add("@iIdOpcion", SqlDbType.Int).Value = CP.iIdOpcion;
                    com.Parameters.Add("@iEstadoRespuesta", SqlDbType.Int).Value = CP.iEstadoRespuesta;
                    com.Parameters.Add("@iUsuarioMod", SqlDbType.Int).Value = CP.iUsuarioMod;

                    return com.ExecuteNonQuery();
                }
            }

        }

        public List<ElementosSaliente> GetAllDETALLECAPACITACIONPERSONALSERVICIO(int iIdCapacitacion)
        {
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("graficoAlumnosAprobados", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@iIdCapacitacion", SqlDbType.Int).Value = iIdCapacitacion;
                    List<ElementosSaliente> list = new List<ElementosSaliente>();
                    using (IDataReader dataReader = com.ExecuteReader())
                    {
                        int contador = 0;
                        ElementosSaliente obj = new ElementosSaliente();
                        stats s = new stats();
                        question_more_success q1 = new question_more_success();
                        question_less_success q2 = new question_less_success();
                        while (dataReader.Read())
                        {
                            contador++;
                            switch (contador)
                            {
                                case 1:
                                    s.approved = (int)dataReader["Aciertos"]; break;
                                case 2:
                                    s.disapproved = (int)dataReader["Aciertos"]; break;
                                case 3:
                                    q1.question = (string)dataReader["titulo"];
                                    q1.evaluated = Convert.ToString((int)dataReader["Aciertos"]); break;
                                case 4:
                                    q2.question = (string)dataReader["titulo"];
                                    q2.evaluated = Convert.ToString((int)dataReader["Aciertos"]); break;
                            }
                        }
                        obj.stats = s;
                        obj.question_more_success = q1;
                        obj.question_less_success = q2;

                        list.Add(obj);
                    }
                    return list;
                }

            }
        }

        public List<PREGUNTAS_CORRECTAS> GetPREGUNTAS_CORRECTAS(int iIdCapacitacion)
        {
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("NumeroAciertosPorPregunta", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@iIdCapacitacion", SqlDbType.Int).Value = iIdCapacitacion;

                    int nro = 1;
                    List<PREGUNTAS_CORRECTAS> list = new List<PREGUNTAS_CORRECTAS>();
                    using (IDataReader dataReader = com.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            PREGUNTAS_CORRECTAS obj = new PREGUNTAS_CORRECTAS();
                            if (dataReader["idPregunta"] != DBNull.Value) { obj.titulo = "Pregunta " + nro; }
                            if (dataReader["numaciertos"] != DBNull.Value) { obj.Value = Convert.ToString((int)dataReader["numaciertos"]); }
                            list.Add(obj); nro++;
                        }
                    }
                    return list;
                }

            }
        }

        public ReporteGrafico_EL graficoAlumnosAprobados(int iIdCapacitacion)
        {
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("graficoAlumnosAprobados", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@iIdCapacitacion", SqlDbType.Int).Value = iIdCapacitacion;
                    ReporteGrafico_EL obj = new ReporteGrafico_EL();
                    using (IDataReader dataReader = com.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {

                            if (dataReader["totalparticipantes"] != DBNull.Value) { obj.totalparticipantes = (int)dataReader["totalparticipantes"]; }
                            if (dataReader["aprobados"] != DBNull.Value) { obj.aprobados = (int)dataReader["aprobados"]; }
                            if (dataReader["desaprobados"] != DBNull.Value) { obj.desaprobados = (int)dataReader["desaprobados"]; }
                        }
                    }
                    return obj;
                }

            }
        }

        public IEnumerable<ReporteGrafico_EL> preguntaMayorMenorAcierto(int iIdCapacitacion)
        {
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("preguntaMayorMenorAcierto", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@iIdCapacitacion", SqlDbType.Int).Value = iIdCapacitacion;
                    List<ReporteGrafico_EL> list = new List<ReporteGrafico_EL>();
                    using (IDataReader dataReader = com.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            ReporteGrafico_EL obj = new ReporteGrafico_EL();
                            //if (dataReader["nombrePregunta"] != DBNull.Value) { obj.totalparticipantes = (int)dataReader["nombrePregunta"]; }
                            if (dataReader["idPregunta"] != DBNull.Value) { obj.idPregunta = (int)dataReader["idPregunta"]; }
                            if (dataReader["numaciertos"] != DBNull.Value) { obj.numaciertos = (int)dataReader["numaciertos"]; }
                            list.Add(obj);
                        }
                    }
                    return list;
                }

            }
        }

        public IEnumerable<ReporteGrafico_EL> NumeroAciertosPorPregunta(int iIdCapacitacion)
        {
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("NumeroAciertosPorPregunta", con))
                {
                    int nro = 1;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@iIdCapacitacion", SqlDbType.Int).Value = iIdCapacitacion;
                    List<ReporteGrafico_EL> list = new List<ReporteGrafico_EL>();
                    using (IDataReader dataReader = com.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            ReporteGrafico_EL obj = new ReporteGrafico_EL();
                            if (dataReader["idPregunta"] != DBNull.Value) { obj.nombrePregunta = "Pregunta " + nro; }
                            if (dataReader["idPregunta"] != DBNull.Value) { obj.idPregunta = (int)dataReader["idPregunta"]; }
                            if (dataReader["numaciertos"] != DBNull.Value) { obj.numaciertos = (int)dataReader["numaciertos"]; }
                            list.Add(obj);
                            nro++;
                        }
                    }
                    return list;
                }

            }
        }


    }
}