﻿using System;
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


    }
}