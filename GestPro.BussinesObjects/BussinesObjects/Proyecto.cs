using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;

namespace GestPro.BussinesObjects.BussinesObjects
{
    public class Proyecto
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
        private string _release;

        public string Release
        {
            get { return _release; }
            set { _release = value; }
        }
        private EtapaProyecto _etapa;

        public EtapaProyecto Etapa
        {
            get { return _etapa; }
            set { _etapa = value; }
        }
        private bool _borrado;

        public bool Borrado
        {
            get { return _borrado; }
            set { _borrado = value; }
        }
        private Cliente _cliente;

        public Cliente Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }
        private Recurso _leader;

        public Recurso Leader
        {
            get { return _leader; }
            set { _leader = value; }
        }

        private List<RegistroAvance> _listaRegistrosAvance;

        public List<RegistroAvance> ListaRegistrosAvance
        {
            get { return _listaRegistrosAvance; }
            set { _listaRegistrosAvance = value; }
        }

        private List<Caso> _listaCasos;

        public List<Caso> ListaCasos
        {
            get { return _listaCasos; }
            set { _listaCasos = value; }
        }

        public string EtapaNombre
        {
            get { return Etapa.Nombre; }
        }

        public string ClienteNombre
        {
            get { return Cliente.ToString(); }
        }

        public string LeaderNombre
        {
            get { return Leader.ToString(); }
        }

        public string IdString
        {
            get { return Id.ToString(); }
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
