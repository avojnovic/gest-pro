using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

namespace GestPro.BussinesObjects.BussinesObjects
{
    public class Cliente
    {
        private long _id;

        public long Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private int _codPostal;

        public int CodPostal
        {
            get { return _codPostal; }
            set { _codPostal = value; }
        }
        private string _direccion;

        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }
        private string _localidad;

        public string Localidad
        {
            get { return _localidad; }
            set { _localidad = value; }
        }
        private string _nombreContacto;

        public string NombreContacto
        {
            get { return _nombreContacto; }
            set { _nombreContacto = value; }
        }
        private string _nombreEmpresa;

        public string NombreEmpresa
        {
            get { return _nombreEmpresa; }
            set { _nombreEmpresa = value; }
        }
        private string _pais;

        public string Pais
        {
            get { return _pais; }
            set { _pais = value; }
        }
        private string _telefono;

        public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }
        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        private bool _borrado;

        public bool Borrado
        {
            get { return _borrado; }
            set { _borrado = value; }
        }

        public override string ToString()
        {
            return NombreContacto+"/"+NombreEmpresa;
        }
    }
}
