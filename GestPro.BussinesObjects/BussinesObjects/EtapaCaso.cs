using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestPro.BussinesObjects.BussinesObjects
{
    public class EtapaCaso
    {
        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
