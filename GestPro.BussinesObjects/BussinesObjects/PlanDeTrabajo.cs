using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

namespace GestPro.BussinesObjects.BussinesObjects
{
    public class PlanDeTrabajo
    {
        private long _id;

        public long Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private DateTime _fechaInicio;

        public DateTime FechaInicio
        {
            get { return _fechaInicio; }
            set { _fechaInicio = value; }
        }
        private DateTime _fechaFin;

        public DateTime FechaFin
        {
            get { return _fechaFin; }
            set { _fechaFin = value; }
        }
        private float _cantHoras;

        public float CantHoras
        {
            get { return _cantHoras; }
            set { _cantHoras = value; }
        }
        private bool _borrado;

        public bool Borrado
        {
            get { return _borrado; }
            set { _borrado = value; }
        }
        private Recurso _recurso;

        public Recurso Recurso
        {
            get { return _recurso; }
            set { _recurso = value; }
        }
        private Caso _caso;

        public Caso Caso
        {
            get { return _caso; }
            set { _caso = value; }
        }


    }
}
