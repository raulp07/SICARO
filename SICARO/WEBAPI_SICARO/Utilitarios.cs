using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace WEBAPI_SICARO
{
    public class Utilitarios
    {
        private static Utilitarios accion;
        private Utilitarios() { }
        public static Utilitarios Accion
        {
            get
            {
                if (accion == null)
                {
                    accion = new Utilitarios();
                }
                return accion;
            }
        }
        public string EnvioCorreo(string destinatario, string titulo, string Mensaje, string Archivo = "")
        {
            string MSG = "";
            try
            {
                var listaCorreos = destinatario.Split(';');

                MailMessage correo = new MailMessage();
                correo.From = new MailAddress("Sys.ICARO@gmail.com");

                foreach (string item in listaCorreos)
                {
                    if (item != "")
                    {
                        correo.To.Add(item);
                    }
                }

                correo.Subject = titulo;
                correo.Body = Mensaje;
                correo.IsBodyHtml = true;
                correo.Priority = MailPriority.Normal;
                if (Archivo != "")
                {
                    string rutaArchivo = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Archivo);
                    if (File.Exists(rutaArchivo))
                    {
                        Attachment a = new Attachment(rutaArchivo);
                        correo.Attachments.Add(a);
                        //File.Delete(rutaArchivo);
                    }
                }

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 25;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = true;
                string cuentacorreo = "Sys.ICARO@gmail.com";
                string password = "webicar0";
                smtp.Credentials = new System.Net.NetworkCredential(cuentacorreo, password);

                smtp.Send(correo);
                MSG = "Mensaje Enviado";
            }
            catch (Exception e)
            {
                MSG = e.Message;
            }
            return MSG;

        }
    }
}