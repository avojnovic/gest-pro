using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using GestPro.BussinesObjects.BussinesObjects;
using GestPro.DataAccessObjects.DataAccessObjects;

namespace GestPro.ControlObjects.ControlObjects
{
    public class AdminEtapaProyecto
    {

        protected static AdminEtapaProyecto Instance = null;
        [MethodImpl(MethodImplOptions.Synchronized)]
        private static void CreateInstance()
        {
            if (Instance == null)
            {
                Instance = new AdminEtapaProyecto();
            }
        }

        public static AdminEtapaProyecto Instancia
        {
            get
            {
                CreateInstance();
                return Instance;
            }
        }



        public Dictionary<long, EtapaProyecto> obtenerTodos()
        {
            return EtapaProyectoDAO.Instancia.obtenerTodos();
             
        }
    }
}
