using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

namespace GestPro.BussinesObjects.BussinesObjects
{
    public class Recurso
    {

        private long _id;

        public long Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        private string _apellido;

        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }

        public string NombreCompleto
        {
            get { return Nombre + " " + Apellido; }
          
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        private string _usuario;

        public string Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }
        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        private bool _borrado;

        public bool Borrado
        {
            get { return _borrado; }
            set { _borrado = value; }
        }

        private Cargo _cargo;

        public Cargo Cargo
        {
            get { return _cargo; }
            set { _cargo = value; }
        }

        public string IdString
        {
            get { return Id.ToString(); }
        }

        public override string ToString()
        {
            return Nombre+" " + Apellido;
        }
    }
}
