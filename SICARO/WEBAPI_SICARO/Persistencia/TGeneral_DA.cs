using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WEBAPI_SICARO.Models;

namespace WEBAPI_SICARO.Persistencia
{
    public class TGeneral_DA
    {
        private static TGeneral_DA accion;
        private TGeneral_DA() { }
        public static TGeneral_DA Accion
        {
            get
            {
                if (accion == null)
                {
                    accion = new TGeneral_DA();
                }
                return accion;
            }
        }


        public List<TGeneral_EL> GetAllTGeneral(TGeneral_EL ent)
        {
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("Sp_Sel_TGeneral", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@co_tabla", SqlDbType.Int).Value = ent.co_tabla;
                    cmd.Parameters.Add("@co_codigo", SqlDbType.Int).Value = ent.co_codigo;

                    //List<CAPACITACION_EL> list = new List<CAPACITACION_EL>();
                    List<TGeneral_EL> obj = new List<TGeneral_EL>();
                    using (IDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            TGeneral_EL tg = new TGeneral_EL();

                            tg.co_codigo = Convert.ToInt32(dr["co_codigo"].ToString());
                            tg.de_tabla = dr["de_tabla"].ToString();
                            tg.co_tabla = Convert.ToInt32(dr["co_tabla"].ToString());
                            tg.de_padre = dr["de_padre"].ToString();
                            //tg.ti_tabla = dr["ti_tabla"].ToString();
                            //tg.fg_tabla = dr["fg_tabla"].ToString();
                            tg.mo_valor1 = string.IsNullOrEmpty(dr["mo_valor1"].ToString()) ? 0 : Convert.ToDecimal(dr["mo_valor1"].ToString());
                            tg.mo_valor2 = string.IsNullOrEmpty(dr["mo_valor2"].ToString()) ? 0 : Convert.ToDecimal(dr["mo_valor2"].ToString());
                            tg.mo_valor3 = string.IsNullOrEmpty(dr["mo_valor3"].ToString()) ? 0 : Convert.ToDecimal(dr["mo_valor3"].ToString());
                            tg.tx_valor1 = dr["tx_valor1"].ToString();
                            tg.tx_valor2 = dr["tx_valor2"].ToString();
                            tg.tx_valor3 = dr["tx_valor3"].ToString();
                            tg.st_tabla = dr["st_tabla"].ToString();
                            if (dr["st_tabla"].ToString() == "1")
                            {
                                tg.st_tabla = "SI";
                            }
                            else
                            {
                                tg.st_tabla = "NO";
                            }
                            obj.Add(tg);
                        }

                    }
                    return obj;
                }

            }
        }

        public List<TGeneral_EL> Sel_ComboTGeneral()
        {
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("Sp_Sel_ComboTGeneral", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        List<TGeneral_EL> lista = new List<TGeneral_EL>();
                        while (dr.Read())
                        {
                            TGeneral_EL ar = new TGeneral_EL();
                            ar.co_codigo = Convert.ToInt32(dr["co_codigo"].ToString());
                            ar.de_tabla = dr["de_tabla"].ToString();
                            lista.Add(ar);
                        }
                        return lista;
                    }
                }
            }
        }


        public int InsertTGeneral(TGeneral_EL ent)
        {
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("Sp_Ins_TGeneral", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //Inicio Parámetros
                    cmd.Parameters.Add("@co_tabla", SqlDbType.Int).Value = ent.co_tabla;
                    cmd.Parameters.Add("@co_codigo", SqlDbType.Int).Value = ent.co_codigo;
                    cmd.Parameters.Add("@de_tabla", SqlDbType.VarChar, 100).Value = ent.de_tabla;
                    //cmd.Parameters.Add("@ti_tabla", SqlDbType.Char, 1).Value = ent.ti_tabla;
                    //cmd.Parameters.Add("@fg_tabla", SqlDbType.Char, 1).Value = ent.fg_tabla;
                    cmd.Parameters.Add("@st_tabla", SqlDbType.Char, 1).Value = ent.st_tabla;
                    cmd.Parameters.Add("@mo_valor1", SqlDbType.Decimal).Value = ent.mo_valor1;
                    cmd.Parameters.Add("@mo_valor2", SqlDbType.Decimal).Value = ent.mo_valor2;
                    cmd.Parameters.Add("@mo_valor3", SqlDbType.Decimal).Value = ent.mo_valor3;
                    cmd.Parameters.Add("@tx_valor1", SqlDbType.Char, 30).Value = ent.tx_valor1;
                    cmd.Parameters.Add("@tx_valor2", SqlDbType.Char, 30).Value = ent.tx_valor2;
                    cmd.Parameters.Add("@tx_valor3", SqlDbType.Char, 30).Value = ent.tx_valor3;
                    cmd.Parameters.Add("@co_usuario_registro", SqlDbType.Char, 20).Value = ent.co_usuario_registro;
                    //Fin Parámetros
                    return cmd.ExecuteNonQuery();
                }
            }

        }

        public int UpdateTGeneral(TGeneral_EL ent)
        {
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("Sp_Upd_TGeneral", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@co_tabla", SqlDbType.Int).Value = ent.co_tabla;
                    cmd.Parameters.Add("@co_codigo", SqlDbType.Int).Value = ent.co_codigo;
                    cmd.Parameters.Add("@de_tabla", SqlDbType.VarChar, 100).Value = ent.de_tabla;
                    //cmd.Parameters.Add("@ti_tabla", SqlDbType.Char, 1).Value = ent.ti_tabla;
                    //cmd.Parameters.Add("@fg_tabla", SqlDbType.Char, 1).Value = ent.fg_tabla;
                    cmd.Parameters.Add("@st_tabla", SqlDbType.Char, 1).Value = ent.st_tabla;
                    cmd.Parameters.Add("@mo_valor1", SqlDbType.Decimal).Value = ent.mo_valor1;
                    cmd.Parameters.Add("@mo_valor2", SqlDbType.Decimal).Value = ent.mo_valor2;
                    cmd.Parameters.Add("@mo_valor3", SqlDbType.Decimal).Value = ent.mo_valor3;
                    cmd.Parameters.Add("@tx_valor1", SqlDbType.Char, 30).Value = ent.tx_valor1;
                    cmd.Parameters.Add("@tx_valor2", SqlDbType.Char, 30).Value = ent.tx_valor2;
                    cmd.Parameters.Add("@tx_valor3", SqlDbType.Char, 30).Value = ent.tx_valor3;
                    cmd.Parameters.Add("@co_usuario_modificacion", SqlDbType.Char, 20).Value = ent.co_usuario_modificacion;
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public int DeleteTGeneral(TGeneral_EL ent)
        {
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("Sp_Del_TGeneral", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Inicio Parámetros
                    cmd.Parameters.Add("@co_tabla", SqlDbType.Int).Value = ent.co_tabla;
                    cmd.Parameters.Add("@co_codigo", SqlDbType.Int).Value = ent.co_codigo;
                    cmd.Parameters.Add("@co_usuario_eliminacion", SqlDbType.Char, 20).Value = ent.co_usuario_eliminacion;

                    return cmd.ExecuteNonQuery();
                }
            }

        }



    }
}