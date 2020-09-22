using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WEBAPI_SICARO;
using WEBAPI_SICARO.Modles;

namespace WEBAPI_SICARO.Persistencia
{
    public class CAPACITACION_DA
    {
        private static CAPACITACION_DA accion;
        private CAPACITACION_DA() { }
        public static CAPACITACION_DA Accion
        {
            get
            {
                if (accion == null)
                {
                    accion = new CAPACITACION_DA();
                }
                return accion;
            }
        }

        public List<CAPACITACION_EL> GetAllCAPACITACION1()
        {
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("spGet_CAPACITACION", con))
                {
                    com.CommandType = CommandType.StoredProcedure;

                    List<CAPACITACION_EL> list = new List<CAPACITACION_EL>();
                    using (IDataReader dataReader = com.ExecuteReader())
                    {

                        while (dataReader.Read())
                        {

                            CAPACITACION_EL obj = new CAPACITACION_EL();

                            if (dataReader["iIdCapacitacion"] != DBNull.Value) { obj.iIdCapacitacion = (int)dataReader["iIdCapacitacion"]; }
                            if (dataReader["vCodCapacitacion"] != DBNull.Value) { obj.vCodCapacitacion = (string)dataReader["vCodCapacitacion"]; }
                            if (dataReader["vTemaCapacitacion"] != DBNull.Value) { obj.vTemaCapacitacion = (string)dataReader["vTemaCapacitacion"]; }
                            if (dataReader["dFechaPropuestaCapacitacion"] != DBNull.Value) { obj.dFechaPropuestaCapacitacion = (DateTime)dataReader["dFechaPropuestaCapacitacion"]; }
                            if (dataReader["iEstadoCapactiacion"] != DBNull.Value) { obj.iEstadoCapactiacion = (int)dataReader["iEstadoCapactiacion"]; }
                            if (dataReader["iEstadoComunicacionCapacitacion"] != DBNull.Value) { obj.iEstadoComunicacionCapacitacion = (int)dataReader["iEstadoComunicacionCapacitacion"]; }
                            if (dataReader["iUsuarioCrea"] != DBNull.Value) { obj.iUsuarioCrea = (int)dataReader["iUsuarioCrea"]; }
                            if (dataReader["dFechaCrea"] != DBNull.Value) { obj.dFechaCrea = (DateTime)dataReader["dFechaCrea"]; }
                            if (dataReader["iUsuarioMod"] != DBNull.Value) { obj.iUsuarioMod = (int)dataReader["iUsuarioMod"]; }
                            if (dataReader["dFechaMod"] != DBNull.Value) { obj.dFechaMod = (DateTime)dataReader["dFechaMod"]; }
                            if (dataReader["Latitud"] != DBNull.Value) { obj.dLatitud = Convert.ToString(dataReader["Latitud"]); }
                            if (dataReader["Longitud"] != DBNull.Value) { obj.dLongitud = Convert.ToString(dataReader["Longitud"]); }
                            list.Add(obj);

                        }

                    }
                    return list;
                }

            }
        }


        public List<CAPACITACION_EL> GetAllCAPACITACION_TEST(int idUsusario)
        {
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("spGet_Capacitacion_Test", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@idUsusario", SqlDbType.Int).Value = idUsusario;

                    List<CAPACITACION_EL> list = new List<CAPACITACION_EL>();
                    using (IDataReader dataReader = com.ExecuteReader())
                    {

                        while (dataReader.Read())
                        {

                            CAPACITACION_EL obj = new CAPACITACION_EL();

                            if (dataReader["iIdCapacitacion"] != DBNull.Value) { obj.iIdCapacitacion = (int)dataReader["iIdCapacitacion"]; }
                            if (dataReader["vCodCapacitacion"] != DBNull.Value) { obj.vCodCapacitacion = (string)dataReader["vCodCapacitacion"]; }
                            if (dataReader["vTemaCapacitacion"] != DBNull.Value) { obj.vTemaCapacitacion = (string)dataReader["vTemaCapacitacion"]; }
                            if (dataReader["dFechaPropuestaCapacitacion"] != DBNull.Value) { obj.dFechaPropuestaCapacitacion = (DateTime)dataReader["dFechaPropuestaCapacitacion"]; }
                            if (dataReader["iEstadoCapactiacion"] != DBNull.Value) { obj.iEstadoCapactiacion = (int)dataReader["iEstadoCapactiacion"]; }
                            if (dataReader["iEstadoComunicacionCapacitacion"] != DBNull.Value) { obj.iEstadoComunicacionCapacitacion = (int)dataReader["iEstadoComunicacionCapacitacion"]; }
                            if (dataReader["iUsuarioCrea"] != DBNull.Value) { obj.iUsuarioCrea = (int)dataReader["iUsuarioCrea"]; }
                            if (dataReader["dFechaCrea"] != DBNull.Value) { obj.dFechaCrea = (DateTime)dataReader["dFechaCrea"]; }
                            if (dataReader["iUsuarioMod"] != DBNull.Value) { obj.iUsuarioMod = (int)dataReader["iUsuarioMod"]; }
                            if (dataReader["dFechaMod"] != DBNull.Value) { obj.dFechaMod = (DateTime)dataReader["dFechaMod"]; }
                            if (dataReader["Latitud"] != DBNull.Value) { obj.dLatitud = Convert.ToString(dataReader["Latitud"]); }
                            if (dataReader["Longitud"] != DBNull.Value) { obj.dLongitud = Convert.ToString(dataReader["Longitud"]); }
                            list.Add(obj);

                        }

                    }
                    return list;
                }

            }
        }

        //public List<CAPACITACION_EL> GetAllCAPACITACION(CAPACITACION_EL C)
        //{
        //    using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
        //    {
        //        con.Open();
        //        using (SqlCommand com = new SqlCommand("spGet_CAPACITACION", con))
        //        {
        //            com.CommandType = CommandType.StoredProcedure;
        //            com.Parameters.Add("@iIdCapacitacion", SqlDbType.Int).Value = C.iIdCapacitacion;

        //            List<CAPACITACION_EL> list = new List<CAPACITACION_EL>();
        //            using (IDataReader dataReader = com.ExecuteReader())
        //            {

        //                while (dataReader.Read())
        //                {

        //                    CAPACITACION_EL obj = new CAPACITACION_EL();

        //                    if (dataReader["iIdCapacitacion"] != DBNull.Value) { obj.iIdCapacitacion = (int)dataReader["iIdCapacitacion"]; }
        //                    if (dataReader["vCodCapacitacion"] != DBNull.Value) { obj.vCodCapacitacion = (string)dataReader["vCodCapacitacion"]; }
        //                    if (dataReader["vTemaCapacitacion"] != DBNull.Value) { obj.vTemaCapacitacion = (string)dataReader["vTemaCapacitacion"]; }
        //                    if (dataReader["dFechaPropuestaCapacitacion"] != DBNull.Value) { obj.dFechaPropuestaCapacitacion = (DateTime)dataReader["dFechaPropuestaCapacitacion"]; }
        //                    if (dataReader["iEstadoCapactiacion"] != DBNull.Value) { obj.iEstadoCapactiacion = (int)dataReader["iEstadoCapactiacion"]; }
        //                    if (dataReader["iEstadoComunicacionCapacitacion"] != DBNull.Value) { obj.iEstadoComunicacionCapacitacion = (int)dataReader["iEstadoComunicacionCapacitacion"]; }
        //                    if (dataReader["iUsuarioCrea"] != DBNull.Value) { obj.iUsuarioCrea = (int)dataReader["iUsuarioCrea"]; }
        //                    if (dataReader["dFechaCrea"] != DBNull.Value) { obj.dFechaCrea = (DateTime)dataReader["dFechaCrea"]; }
        //                    if (dataReader["iUsuarioMod"] != DBNull.Value) { obj.iUsuarioMod = (int)dataReader["iUsuarioMod"]; }
        //                    if (dataReader["dFechaMod"] != DBNull.Value) { obj.dFechaMod = (DateTime)dataReader["dFechaMod"]; }
        //                    if (dataReader["Latitud"] != DBNull.Value) { obj.dLatitud = (decimal)dataReader["Latitud"]; }
        //                    if (dataReader["Longitud"] != DBNull.Value) { obj.dLongitud = (decimal)dataReader["Longitud"]; }
        //                    list.Add(obj);

        //                }

        //            }
        //            return list;
        //        }

        //    }
        //}

        public CAPACITACION_EL GetAllCAPACITACION(int iIdCapacitacion)
        {
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("spGet_CAPACITACION", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@iIdCapacitacion", SqlDbType.Int).Value = iIdCapacitacion;

                    //List<CAPACITACION_EL> list = new List<CAPACITACION_EL>();
                    CAPACITACION_EL obj = new CAPACITACION_EL();
                    using (IDataReader dataReader = com.ExecuteReader())
                    {

                        while (dataReader.Read())
                        {



                            if (dataReader["iIdCapacitacion"] != DBNull.Value) { obj.iIdCapacitacion = (int)dataReader["iIdCapacitacion"]; }
                            if (dataReader["vCodCapacitacion"] != DBNull.Value) { obj.vCodCapacitacion = (string)dataReader["vCodCapacitacion"]; }
                            if (dataReader["vTemaCapacitacion"] != DBNull.Value) { obj.vTemaCapacitacion = (string)dataReader["vTemaCapacitacion"]; }
                            if (dataReader["dFechaPropuestaCapacitacion"] != DBNull.Value) { obj.dFechaPropuestaCapacitacion = (DateTime)dataReader["dFechaPropuestaCapacitacion"]; }
                            if (dataReader["iEstadoCapactiacion"] != DBNull.Value) { obj.iEstadoCapactiacion = (int)dataReader["iEstadoCapactiacion"]; }
                            if (dataReader["iEstadoComunicacionCapacitacion"] != DBNull.Value) { obj.iEstadoComunicacionCapacitacion = (int)dataReader["iEstadoComunicacionCapacitacion"]; }
                            if (dataReader["iUsuarioCrea"] != DBNull.Value) { obj.iUsuarioCrea = (int)dataReader["iUsuarioCrea"]; }
                            if (dataReader["dFechaCrea"] != DBNull.Value) { obj.dFechaCrea = (DateTime)dataReader["dFechaCrea"]; }
                            if (dataReader["iUsuarioMod"] != DBNull.Value) { obj.iUsuarioMod = (int)dataReader["iUsuarioMod"]; }
                            if (dataReader["dFechaMod"] != DBNull.Value) { obj.dFechaMod = (DateTime)dataReader["dFechaMod"]; }
                            if (dataReader["Latitud"] != DBNull.Value) { obj.dLatitud = (string)dataReader["Latitud"]; }
                            if (dataReader["Longitud"] != DBNull.Value) { obj.dLongitud = (string)dataReader["Longitud"]; }
                            //list.Add(obj);

                        }

                    }
                    return obj;
                }

            }
        }



        public Respuesta InsertCAPACITACION(CAPACITACION_EL C)
        {
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("spInsertCAPACITACION", con))
                {
                    Respuesta res = new Respuesta();
                    try
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.Add("@vTemaCapacitacion", SqlDbType.VarChar).Value = C.vTemaCapacitacion;
                        com.Parameters.Add("@dFechaPropuestaCapacitacion", SqlDbType.DateTime).Value = C.dFechaPropuestaCapacitacion;
                        com.Parameters.Add("@iUsuarioCrea", SqlDbType.Int).Value = C.iUsuarioCrea;
                        res.codigo = com.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        res.codigo = -1;
                        res.Mensaje = e.Message;
                    }
                    return res;
                }
            }
        }

        public Respuesta UpdateCAPACITACION(CAPACITACION_EL C)
        {
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("spUpdateCAPACITACION", con))
                {
                    Respuesta res = new Respuesta();
                    try
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.Add("@iIdCapacitacion", SqlDbType.Int).Value = C.iIdCapacitacion;
                        com.Parameters.Add("@vTemaCapacitacion", SqlDbType.VarChar).Value = C.vTemaCapacitacion;
                        com.Parameters.Add("@dFechaPropuestaCapacitacion", SqlDbType.DateTime).Value = C.dFechaPropuestaCapacitacion;
                        com.Parameters.Add("@iUsuarioMod", SqlDbType.Int).Value = C.iUsuarioCrea;
                        res.codigo = com.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        res.codigo = -1;
                        res.Mensaje = e.Message;
                    }
                    return res;
                }
            }
        }

        public int FinalizarCapacitacion(int idcapacitacion)
        {
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("FinalizarCapacitacion", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@iIdCapacitacion", SqlDbType.Int).Value = idcapacitacion;
                    
                    using (IDataReader dataReader = com.ExecuteReader())
                    {
                        string CorreosOpererariosFaltantes = "";
                        string ContenidoOperarioFaltantes = "";
                        string temaCapacitacion = "";

                        int Aprobado = 0;
                        int Desaprobado = 0;
                        int NroParticipante = 0;
                        string ContenidoFinalizacionCapacitacion = "";

                        while (dataReader.Read())
                        {
                            if (dataReader["Email"] != DBNull.Value) { CorreosOpererariosFaltantes += (string)dataReader["Email"] + ";"; }
                        }

                        while (dataReader.NextResult())
                        {
                            while (dataReader.Read())
                            {
                                if (dataReader["Aprobado"] != DBNull.Value) { Aprobado = (int)dataReader["Aprobado"]; }
                                if (dataReader["Desaprobado"] != DBNull.Value) { Desaprobado = (int)dataReader["Desaprobado"]; }
                                if (dataReader["NroParticipante"] != DBNull.Value) { NroParticipante = (int)dataReader["NroParticipante"]; }
                                if (dataReader["TemaCapacitacion"] != DBNull.Value) { temaCapacitacion = (string)dataReader["TemaCapacitacion"]; }
                            }
                        }

                        // Envio de correo a Personal que no asistieron a la capacitacion
                        ContenidoOperarioFaltantes = "Estimado Colaborador: <br /><br />" +
                                                     "Este correo es para hacerle saber que WISLAN S.A.C. no ha podido contar con su participación para la capacitación : " + temaCapacitacion + ".<br />" +
                                                     "Los organizadores del evento se encuentran interesados en su instrucción continua y desean saber el motivo por el cual no pudo asistir a la capacitación, por favor presentar su descargo a la siguiente dirección electrónica : sys.icaro@gmail.com <br /><br />" +
                                                     "Gracias de antemano por su respuesta <br /><br />" +
                                                     "Saludos.";
                        Utilitarios.Accion.EnvioCorreo(CorreosOpererariosFaltantes, "Falta a la capacitación  ", ContenidoOperarioFaltantes);

                        //Envio el resultado final de la capacitacion
                        ContenidoFinalizacionCapacitacion = "Estimado Jefe de Aseguramiento de la calidad: <br /><br />" +
                                                            "Este correo es para informarle que habiendo concluido la capacitación con el tema " + temaCapacitacion + " que contó con la participación de" + NroParticipante + "miembros de nuestra organización. <br /><br />"+
                                                            "Se tuvieron en los resultados del test de comprobación de conocimientos: <br/ >" +
                                                            "- " + Aprobado + " Aprobados <br />" +
                                                            "- " + Desaprobado + " Desaprobados <br /><br />" +
                                                            "Agradecemos que pueda conservar el resultado o informar a las personas correspondientes.<br /><br />" +
                                                            "Saludos";
                        Utilitarios.Accion.EnvioCorreo("jefe.calidad.wislan@gmail.com", "Capacitación Finalizada ", ContenidoFinalizacionCapacitacion);

                    }
                    return 1;
                }

            }

            //using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            //{
            //    con.Open();
            //    using (SqlCommand com = new SqlCommand("spInsertCAPACITACION", con))
            //    {
            //        com.CommandType = CommandType.StoredProcedure;
            //        com.Parameters.Add("@vTemaCapacitacion", SqlDbType.VarChar).Value = C.vTemaCapacitacion;
            //        com.Parameters.Add("@dFechaPropuestaCapacitacion", SqlDbType.DateTime).Value = C.dFechaPropuestaCapacitacion;
            //        com.Parameters.Add("@iUsuarioCrea", SqlDbType.Int).Value = C.iUsuarioCrea;
            //        return com.ExecuteNonQuery();
            //    }
            //}
        }

    }
}