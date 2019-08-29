﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCF_SICARO.Dominio;

namespace WCF_SICARO
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IWCFICARO
    {

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "CAPACITACION", ResponseFormat = WebMessageFormat.Json)]
        List<CAPACITACION_EL> GetAllCAPACITACION1();

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "CAPACITACION", ResponseFormat = WebMessageFormat.Json)]
        List<CAPACITACION_EL> GetAllCAPACITACION(CAPACITACION_EL C);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "ICAPACITACIONCABECERA", ResponseFormat = WebMessageFormat.Json)]
        int InsertCAPACITACION(CAPACITACION_EL GC);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "UCAPACITACIONCABECERA", ResponseFormat = WebMessageFormat.Json)]
        int UpdateCAPACITACION(CAPACITACION_EL GC);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GESTIONCAPACITACION", ResponseFormat = WebMessageFormat.Json)]
        List<GESTION_CAPACITACION_EL> GetAllGESTION_CAPACITACION(GESTION_CAPACITACION_EL GC);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "ICAPACITACION", ResponseFormat = WebMessageFormat.Json)]
        int InsertGESTION_CAPACITACION(GESTION_CAPACITACION_EL GC);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "UCAPACITACION", ResponseFormat = WebMessageFormat.Json)]
        int UpdateGESTION_CAPACITACION(GESTION_CAPACITACION_EL GC);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "TEST", ResponseFormat = WebMessageFormat.Json)]
        List<TEST_EL> GetAllTEST(TEST_EL T);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "ITEST", ResponseFormat = WebMessageFormat.Json)]
        int InsertTEST(TEST_EL T);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "UTEST", ResponseFormat = WebMessageFormat.Json)]
        int UpdateTEST(TEST_EL T);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "PREGUNTA", ResponseFormat = WebMessageFormat.Json)]
        List<PREGUNTA_EL> GetAllPREGUNTA(PREGUNTA_EL P);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "IPREGUNTA", ResponseFormat = WebMessageFormat.Json)]
        int InsertPREGUNTA(PREGUNTA_EL P);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "UPREGUNTA", ResponseFormat = WebMessageFormat.Json)]
        int UpdatePREGUNTA(PREGUNTA_EL P);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "OPCION_PREGUNTA", ResponseFormat = WebMessageFormat.Json)]
        List<OPCION_PREGUNTA_EL> GetAllOPCION_PREGUNTA(OPCION_PREGUNTA_EL OP);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "IOPCION_PREGUNTA", ResponseFormat = WebMessageFormat.Json)]
        int InsertOPCION_PREGUNTA(OPCION_PREGUNTA_EL OP);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "UOPCION_PREGUNTA", ResponseFormat = WebMessageFormat.Json)]
        int UpdateOPCION_PREGUNTA(OPCION_PREGUNTA_EL OP);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "REPRESENTANTE", ResponseFormat = WebMessageFormat.Json)]
        List<REPRESENTANTE_EL> GetAllREPRESENTANTE(REPRESENTANTE_EL R);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "IREPRESENTANTE", ResponseFormat = WebMessageFormat.Json)]
        int InsertREPRESENTANTE(REPRESENTANTE_EL R);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "UREPRESENTANTE", ResponseFormat = WebMessageFormat.Json)]
        int UpdateREPRESENTANTE(REPRESENTANTE_EL R);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "PERSONAL", ResponseFormat = WebMessageFormat.Json)]
        List<PERSONAL_EL> GetAllPERSONAL(PERSONAL_EL P);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "IPERSONAL", ResponseFormat = WebMessageFormat.Json)]
        int InsertPERSONAL(PERSONAL_EL P);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "UPERSONAL", ResponseFormat = WebMessageFormat.Json)]
        int UpdatePERSONAL(PERSONAL_EL P);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "PROVEEDOR", ResponseFormat = WebMessageFormat.Json)]
        List<PROVEEDOR_EL> GetAllPROVEEDOR(PROVEEDOR_EL P);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "CAPACITACION_PERSONAL", ResponseFormat = WebMessageFormat.Json)]
        List<CAPACITACION_PERSONAL_EL> GetAllCAPACITACION_PERSONAL(CAPACITACION_PERSONAL_EL CP);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "ICAPACITACION_PERSONAL", ResponseFormat = WebMessageFormat.Json)]
        int InsertCAPACITACION_PERSONAL(CAPACITACION_PERSONAL_EL CP);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "UCAPACITACION_PERSONAL", ResponseFormat = WebMessageFormat.Json)]
        int UpdateCAPACITACION_PERSONAL(CAPACITACION_PERSONAL_EL CP);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "DETALLE_CAPACITACION_PERSONAL", ResponseFormat = WebMessageFormat.Json)]
        List<DETALLE_CAPACITACION_PERSONAL_EL> GetAllDETALLECAPACITACIONPERSONAL(DETALLE_CAPACITACION_PERSONAL_EL CP);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "IDETALLE_CAPACITACION_PERSONAL", ResponseFormat = WebMessageFormat.Json)]
        int InsertDETALLE_CAPACITACION_PERSONAL(DETALLE_CAPACITACION_PERSONAL_EL CP);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "UDETALLE_CAPACITACION_PERSONAL", ResponseFormat = WebMessageFormat.Json)]
        int UpdateDETALLE_CAPACITACION_PERSONAL(DETALLE_CAPACITACION_PERSONAL_EL CP);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetAllDETALLECAPACITACIONPERSONALSERVICIO", ResponseFormat = WebMessageFormat.Json)]
        List<ElementosSaliente> GetAllDETALLECAPACITACIONPERSONALSERVICIO();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetAllPREGUNTASCORRECTAS", ResponseFormat = WebMessageFormat.Json)]
        List<PREGUNTAS_CORRECTAS> GetPREGUNTAS_CORRECTAS();

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "MATERIA_PRIMA", ResponseFormat = WebMessageFormat.Json)]
        List<MATERIA_PRIMA_EL> GetAllMATERIA_PRIMA(MATERIA_PRIMA_EL MP);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "PRONOSTICO", ResponseFormat = WebMessageFormat.Json)]
        List<PRONOSTICO_EL> GetPRONOSTICOAll(PRONOSTICO_EL CP);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "IPRONOSTICO", ResponseFormat = WebMessageFormat.Json)]
        int InsertPRONOSTICO(PRONOSTICO_EL CP);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "UPRONOSTICO", ResponseFormat = WebMessageFormat.Json)]
        int UpdatePRONOSTICO(PRONOSTICO_EL CP);


        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "CONTROLPRODUCCION", ResponseFormat = WebMessageFormat.Json)]
        List<CONTROLPRODUCCION_EL> GetCONTROLPRODUCCIONAll(CONTROLPRODUCCION_EL CP);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "ICONTROLPRODUCCION", ResponseFormat = WebMessageFormat.Json)]
        int InsertCONTROLPRODUCCION(CONTROLPRODUCCION_EL CP);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "UCONTROLPRODUCCION", ResponseFormat = WebMessageFormat.Json)]
        int UpdateCONTROLPRODUCCION(CONTROLPRODUCCION_EL CP);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GETUSUARIO", ResponseFormat = WebMessageFormat.Json)]
        List<USUARIO_EL> GetUsuario(USUARIO_EL CP);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "ListaMenu", ResponseFormat = WebMessageFormat.Json)]
        List<OpcionXPerfil_EL> ListMenu(OpcionXPerfil_EL opcionPerfil);
    }



}
