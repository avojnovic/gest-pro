using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using GestPro.BussinesObjects;
using GestPro.BussinesObjects.BussinesObjects;
using GestPro.DataAccessObjects.DataAccessObjects;

namespace GestPro.ControlObjects.ControlObjects
{
    public class AdminProyecto
    {
        protected static AdminProyecto Instance = null;
        [MethodImpl(MethodImplOptions.Synchronized)]
        private static void CreateInstance()
        {
            if (Instance == null)
            {
                Instance = new AdminProyecto();
            }
        }

        public static AdminProyecto Instancia
        {
            get
            {
                CreateInstance();
                return Instance;
            }
        }

       
        private Dictionary<long, Proyecto> _dicProyectos;
        public Proyecto _proyectoEdit;

       

        public Proyecto obtenerRecursoPorId(long id)
        {
            return ProyectosDAO.Instancia.obtenerRecursoPorId(id);
        }

        public Dictionary<long, Proyecto> obtenerTodos()
        {
            _dicProyectos = ProyectosDAO.Instancia.obtenerTodos();
            return _dicProyectos;
        }


        public void insertar(Proyecto p)
        {
            ProyectosDAO.Instancia.insertar(p);
            
        }

        public void actualizar(Proyecto p)
        {

            ProyectosDAO.Instancia.actualizar(p);
        }
    }
}
