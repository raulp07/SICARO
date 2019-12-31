using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace SICARO.WEB.Controllers
{
    public class Utilitario
    {

        private static Utilitario accion;
        private Utilitario() { }
        public static Utilitario Accion
        {
            get
            {
                if (accion == null)
                {
                    accion = new Utilitario();
                }
                return accion;
            }
        }

        private static JavaScriptSerializer js;
        public static JavaScriptSerializer js_
        {
            get
            {
                if (js == null)
                {
                    js = new JavaScriptSerializer();
                }
                return js;
            }
        }
        public static string Serialize<T>(List<T> value)
        {
            if (value == null)
            {
                return string.Empty;
            }
            try
            {
                var xmlserializer = new XmlSerializer(typeof(List<T>));
                var stringWriter = new StringWriter();
                using (var writer = XmlWriter.Create(stringWriter))
                {
                    xmlserializer.Serialize(writer, value);
                    return stringWriter.ToString();//.Replace("<?xml version="""+"1.0" + "encoding=\"utf-16\"?>", "");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred", ex);
            }
        }


        public static string urlSite = ConfigurationManager.AppSettings["urlWS"];
        public static string urlSiteWEBAPI = ConfigurationManager.AppSettings["urlWEBAPI"];
        public string ConectREST(string url, string method, string postdata = "")
        {
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(urlSite + "WCFICARO.svc/" + url);
                HttpWebResponse res = null;
                StreamReader reader = null;
                switch (method)
                {
                    case "GET":
                        req.Method = method;
                        res = (HttpWebResponse)req.GetResponse();
                        reader = new StreamReader(res.GetResponseStream());
                        return reader.ReadToEnd();
                    case "POST":
                        byte[] data = Encoding.UTF8.GetBytes(postdata);
                        req.Method = method;
                        req.ContentLength = data.Length;
                        req.ContentType = "application/json";
                        var reqStream = req.GetRequestStream();
                        reqStream.Write(data, 0, data.Length);
                        res = (HttpWebResponse)req.GetResponse();
                        reader = new StreamReader(res.GetResponseStream());
                        return reader.ReadToEnd();
                    default: return "";
                }
                HttpClient clienteHttp = new HttpClient();
                clienteHttp.BaseAddress = new Uri(urlSite + "WCFICARO.svc/");
                var request = clienteHttp.GetAsync(url).Result;
                if (request.IsSuccessStatusCode)
                {
                    var resultString = request.Content.ReadAsStringAsync().Result;
                    return resultString;
                }

            }
            catch (Exception e)
            {
                throw new ArgumentNullException(e.Message);
            }

        }

        public string Conect_WEBAPI(string url, string method, string postdata = "", string id = "-1")
        {
            try
            {
                HttpClient clientHttp = new HttpClient();
                clientHttp.BaseAddress = new Uri(urlSiteWEBAPI);
                byte[] buffer;
                ByteArrayContent byteContent;
                HttpResponseMessage request;

                switch (method)
                {
                    case "GET":
                        if (id == "-1")
                        {
                            request = clientHttp.GetAsync("api/" + url).Result; break;
                        }
                        else
                        {
                            request = clientHttp.GetAsync("api/" + url + "?value=" + id).Result; break;
                        }

                    case "POST":
                        buffer = Encoding.UTF8.GetBytes(postdata);
                        byteContent = new ByteArrayContent(buffer);
                        byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                        request = clientHttp.PostAsync("api/" + url, byteContent).Result; break;
                    case "PUT":
                        buffer = Encoding.UTF8.GetBytes(postdata);
                        byteContent = new ByteArrayContent(buffer);
                        byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                        request = clientHttp.PutAsync("api/" + url + "/" + id, byteContent).Result; break;
                    case "DEL":
                        request = clientHttp.DeleteAsync("api/" + url + "?value=" + id).Result; break;
                    default: return "";
                }
                if (request.IsSuccessStatusCode)
                {
                    return request.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    return "";
                }


            }
            catch (Exception e)
            {
                throw new ArgumentNullException(e.Message);
            }

        }

        public string Conect_WEBPython(string url, string method, string postdata = "", string id = "-1")
        {
            try
            {
                HttpClient clientHttp = new HttpClient();
                clientHttp.BaseAddress = new Uri(urlSiteWEBAPI);
                byte[] buffer;
                ByteArrayContent byteContent;
                HttpResponseMessage request;

                switch (method)
                {
                    case "GET":
                        if (id == "-1")
                        {
                            request = clientHttp.GetAsync(url).Result; break;
                        }
                        else
                        {
                            request = clientHttp.GetAsync(url + "?value=" + id).Result; break;
                        }

                    case "POST":
                        buffer = Encoding.UTF8.GetBytes(postdata);
                        byteContent = new ByteArrayContent(buffer);
                        byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                        request = clientHttp.PostAsync("api/" + url, byteContent).Result; break;
                    case "PUT":
                        buffer = Encoding.UTF8.GetBytes(postdata);
                        byteContent = new ByteArrayContent(buffer);
                        byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                        request = clientHttp.PutAsync("api/" + url + "/" + id, byteContent).Result; break;
                    case "DEL":
                        request = clientHttp.DeleteAsync("api/" + url + "?value=" + id).Result; break;
                    default: return "";
                }
                if (request.IsSuccessStatusCode)
                {
                    return request.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    return "";
                }


            }
            catch (Exception e)
            {
                throw new ArgumentNullException(e.Message);
            }

        }

    }
}