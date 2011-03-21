using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using GestPro.BussinesObjects.BussinesObjects;
using GestPro.DataAccessObjects.DataAccessObjects;

namespace GestPro.ControlObjects.ControlObjects
{
    public class AdminRegAvance
    {

        protected static AdminRegAvance Instance = null;
        [MethodImpl(MethodImplOptions.Synchronized)]
        private static void CreateInstance()
        {
            if (Instance == null)
            {
                Instance = new AdminRegAvance();
            }
        }

        public static AdminRegAvance Instancia
        {
            get
            {
                CreateInstance();
                return Instance;
            }
        }


 
        public long _idVinculacion;
        public bool caso;


        public void insertar(RegistroAvance r, long idVinculacion, bool caso)
        {
            RegAvanceDAO.Instancia.insertar(r, idVinculacion, caso);
        }

    }
}
