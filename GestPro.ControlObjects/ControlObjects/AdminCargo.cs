using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using GestPro.BussinesObjects.BussinesObjects;
using GestPro.DataAccessObjects.DataAccessObjects;

namespace GestPro.ControlObjects.ControlObjects
{
    public class AdminCargo
    {
        protected static AdminCargo Instance = null;
        [MethodImpl(MethodImplOptions.Synchronized)]
        private static void CreateInstance()
        {
            if (Instance == null)
            {
                Instance = new AdminCargo();
            }
        }

        public static AdminCargo Instancia
        {
            get
            {
                CreateInstance();
                return Instance;
            }
        }



        public Dictionary<long, Cargo> obtenerTodos()
        {
            return CargoDAO.Instancia.obtenerTodos();
        }
    }
}
