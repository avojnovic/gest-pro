using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

namespace GestPro.BussinesObjects.BussinesObjects
{
    public class RegistroAvance
    {

        private long _id;

        public long Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private float _tiempo;

        public float Tiempo
        {
            get { return _tiempo; }
            set { _tiempo = value; }
        }
        private string _descripcion;

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        private bool _borrado;

        public bool Borrado
        {
            get { return _borrado; }
            set { _borrado = value; }
        }

        private DateTime _fecha;

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        private Recurso _recurso;

        public Recurso Recurso
        {
            get { return _recurso; }
            set { _recurso = value; }
        }

        private string _proyecto;

        public string Proyecto
        {
            get { return _proyecto; }
            set { _proyecto = value; }
        }

        private string _caso;

        public string Caso
        {
            get { return _caso; }
            set { _caso = value; }
        }
    }
}
