using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SICARO.WEB.Models
{
    public class USUARIO_EL
    {


        ///

        /// Gets or Sets Id
        ///
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        private int _Id;

        ///

        /// Gets or Sets IdRol
        ///
        public int IdRol
        {
            get { return _IdRol; }
            set { _IdRol = value; }
        }
        private int _IdRol;

        ///

        /// Gets or Sets CtaUsuario
        ///
        public string CtaUsuario
        {
            get { return _CtaUsuario; }
            set { _CtaUsuario = value; }
        }
        private string _CtaUsuario;

        ///

        /// Gets or Sets Contrasenia
        ///
        public string Contrasenia
        {
            get { return _Contrasenia; }
            set { _Contrasenia = value; }
        }
        private string _Contrasenia;

        ///

        /// Gets or Sets Nombres
        ///
        public string Nombres
        {
            get { return _Nombres; }
            set { _Nombres = value; }
        }
        private string _Nombres;

        ///

        /// Gets or Sets Apellidos
        ///
        public string Apellidos
        {
            get { return _Apellidos; }
            set { _Apellidos = value; }
        }
        private string _Apellidos;

        ///

        /// Gets or Sets Cargo
        ///
        public string Cargo
        {
            get { return _Cargo; }
            set { _Cargo = value; }
        }
        private string _Cargo;

        ///

        /// Gets or Sets Email
        ///
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        private string _Email;

        ///

        /// Gets or Sets Telefono
        ///
        public string Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }
        private string _Telefono;

        ///

        /// Gets or Sets Estado
        ///
        public byte Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }
        private byte _Estado;

        ///

        /// Gets or Sets CambiarContrasenia
        ///
        public bool CambiarContrasenia
        {
            get { return _CambiarContrasenia; }
            set { _CambiarContrasenia = value; }
        }
        private bool _CambiarContrasenia;

        ///

        /// Gets or Sets FechaVencimientoCta
        ///
        public DateTime FechaVencimientoCta
        {
            get { return _FechaVencimientoCta; }
            set { _FechaVencimientoCta = value; }
        }
        private DateTime _FechaVencimientoCta;

        ///

        /// Gets or Sets FechaVencimiento
        ///
        public DateTime FechaVencimiento
        {
            get { return _FechaVencimiento; }
            set { _FechaVencimiento = value; }
        }
        private DateTime _FechaVencimiento;

        ///

        /// Gets or Sets AuditoriaUC
        ///
        public int AuditoriaUC
        {
            get { return _AuditoriaUC; }
            set { _AuditoriaUC = value; }
        }
        private int _AuditoriaUC;

        ///

        /// Gets or Sets AuditoriaUM
        ///
        public int AuditoriaUM
        {
            get { return _AuditoriaUM; }
            set { _AuditoriaUM = value; }
        }
        private int _AuditoriaUM;

        ///

        /// Gets or Sets AuditoriaFC
        ///
        public DateTime AuditoriaFC
        {
            get { return _AuditoriaFC; }
            set { _AuditoriaFC = value; }
        }
        private DateTime _AuditoriaFC;

        ///

        /// Gets or Sets AuditoriaFM
        ///
        public DateTime AuditoriaFM
        {
            get { return _AuditoriaFM; }
            set { _AuditoriaFM = value; }
        }
        private DateTime _AuditoriaFM;
    }
}