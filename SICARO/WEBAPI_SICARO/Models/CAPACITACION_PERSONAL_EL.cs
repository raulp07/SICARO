﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WEBAPI_SICARO.Modles
{
    public class CAPACITACION_PERSONAL_EL
    {

        ///

        /// Gets or Sets iIdCapacitacionPersonal
        ///
        [DataMember]
        public int iIdCapacitacionPersonal
        {
            get { return _iIdCapacitacionPersonal; }
            set { _iIdCapacitacionPersonal = value; }
        }
        private int _iIdCapacitacionPersonal;

        ///

        /// Gets or Sets iIdPersonal
        ///
        [DataMember]
        public int iIdPersonal
        {
            get { return _iIdPersonal; }
            set { _iIdPersonal = value; }
        }
        private int _iIdPersonal;

        ///

        /// Gets or Sets iIdCapacitacion
        ///
        [DataMember]
        public int iIdCapacitacion
        {
            get { return _iIdCapacitacion; }
            set { _iIdCapacitacion = value; }
        }
        private int _iIdCapacitacion;

        ///

        /// Gets or Sets iPuntajePersonal
        ///
        [DataMember]
        public int iPuntajePersonal
        {
            get { return _iPuntajePersonal; }
            set { _iPuntajePersonal = value; }
        }
        private int _iPuntajePersonal;

        ///

        /// Gets or Sets vObservacionPersonal
        ///
        [DataMember]
        public string vObservacionPersonal
        {
            get { return _vObservacionPersonal; }
            set { _vObservacionPersonal = value; }
        }
        private string _vObservacionPersonal;

        ///

        /// Gets or Sets iAsistenciaPersonal
        ///
        [DataMember]
        public int iAsistenciaPersonal
        {
            get { return _iAsistenciaPersonal; }
            set { _iAsistenciaPersonal = value; }
        }
        private int _iAsistenciaPersonal;

        ///

        /// Gets or Sets iUsuarioCrea
        ///
        [DataMember]
        public int iUsuarioCrea
        {
            get { return _iUsuarioCrea; }
            set { _iUsuarioCrea = value; }
        }
        private int _iUsuarioCrea;

        ///

        /// Gets or Sets dFechaCrea
        ///
        [DataMember]
        public DateTime dFechaCrea
        {
            get { return _dFechaCrea; }
            set { _dFechaCrea = value; }
        }
        private DateTime _dFechaCrea;

        ///

        /// Gets or Sets iUsuarioMod
        ///
        [DataMember]
        public int iUsuarioMod
        {
            get { return _iUsuarioMod; }
            set { _iUsuarioMod = value; }
        }
        private int _iUsuarioMod;

        ///

        /// Gets or Sets dFechaMod
        ///
        [DataMember]
        public DateTime dFechaMod
        {
            get { return _dFechaMod; }
            set { _dFechaMod = value; }
        }
        private DateTime _dFechaMod;
    }
}