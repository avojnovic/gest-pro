using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using GestPro.BussinesObjects.BussinesObjects;
using GestPro.DataAccessObjects.DataAccessObjects;

namespace GestPro.ControlObjects.ControlObjects
{
    public class AdminCliente
    {
        protected static AdminCliente Instance = null;
        [MethodImpl(MethodImplOptions.Synchronized)]
        private static void CreateInstance()
        {
            if (Instance == null)
            {
                Instance = new AdminCliente();
            }
        }

        public static AdminCliente Instancia
        {
            get
            {
                CreateInstance();
                return Instance;
            }
        }



        public Dictionary<long,Cliente> obtenerTodos()
        {
            return ClienteDAO.Instancia.obtenerTodos();
        }


    }
}
