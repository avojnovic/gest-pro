using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;

namespace GestPro.BussinesObjects.BussinesObjects
{
    public class Caso
    {
        private long _id;

        public long Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private long _nroCaso;

        public long NroCaso
        {
            get { return _nroCaso; }
            set { _nroCaso = value; }
        }
        private string _descripcion;

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        private DateTime _fechaEntrega;

        public DateTime FechaEntrega
        {
            get { return _fechaEntrega; }
            set { _fechaEntrega = value; }
        }
        private int _prioridad;

        public int Prioridad
        {
            get { return _prioridad; }
            set { _prioridad = value; }
        }
        private float _tiempoEstimado;

        public float TiempoEstimado
        {
            get { return _tiempoEstimado; }
            set { _tiempoEstimado = value; }
        }
        private float _tiempoRestante;

        public float TiempoRestante
        {
            get { return _tiempoRestante; }
            set { _tiempoRestante = value; }
        }
        private string _descripcionImplementacion;

        public string DescripcionImplementacion
        {
            get { return _descripcionImplementacion; }
            set { _descripcionImplementacion = value; }
        }
        private string _descripcionPruebas;

        public string DescripcionPruebas
        {
            get { return _descripcionPruebas; }
            set { _descripcionPruebas = value; }
        }
        private bool _borrado;

        public bool Borrado
        {
            get { return _borrado; }
            set { _borrado = value; }
        }
        private Recurso _responsable;

        public Recurso Responsable
        {
            get { return _responsable; }
            set { _responsable = value; }
        }

        private Recurso _responsableDesarrollo;

        public Recurso ResponsableDesarrollo
        {
            get { return _responsableDesarrollo; }
            set { _responsableDesarrollo = value; }
        }
        private Recurso _responsablePruebas;

        public Recurso ResponsablePruebas
        {
            get { return _responsablePruebas; }
            set { _responsablePruebas = value; }
        }

        private TipoCaso _tipoCaso;

        public TipoCaso TipoCaso
        {
            get { return _tipoCaso; }
            set { _tipoCaso = value; }
        }
        private EtapaCaso _etapaCaso;


        public EtapaCaso EtapaCaso
        {
            get { return _etapaCaso; }
            set { _etapaCaso = value; }
        }

        private List<RegistroAvance> _listaRegistrosAvance;

        public List<RegistroAvance> ListaRegistrosAvance
        {
            get { return _listaRegistrosAvance; }
            set { _listaRegistrosAvance = value; }
        }
        private Proyecto _proyecto;

        public Proyecto Proyecto
        {
            get { return _proyecto; }
            set { _proyecto = value; }
        }

        public string IdString
        {
            get { return Id.ToString(); }
        }
        public string NroCasoString
        {
            get { return NroCaso.ToString(); }
           
        }

        public string PrioridadString
        {
            get { return Prioridad.ToString(); }
        }
    }
}
