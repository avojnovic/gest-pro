using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using GestPro.BussinesObjects.BussinesObjects;
using GestPro.DataAccessObjects.DataAccessObjects;

namespace GestPro.ControlObjects.ControlObjects
{
    public class AdminCaso
    {

        protected static AdminCaso Instance = null;
        [MethodImpl(MethodImplOptions.Synchronized)]
        private static void CreateInstance()
        {
            if (Instance == null)
            {
                Instance = new AdminCaso();
            }
        }

        public static AdminCaso Instancia
        {
            get
            {
                CreateInstance();
                return Instance;
            }
        }

        private Dictionary<long, Caso> _dicCasos;
        public Caso _casoEdit;
        public bool todos;

        public Dictionary<long, Caso> obtenerTodos()
        {
            return CasoDAO.Instancia.obtenerTodos();
        }

        public Dictionary<long, Caso> obtenerTodosPorResponsable(Recurso r)
        {
            return CasoDAO.Instancia.obtenerTodosPorResponsable(r);
        }

        public long insertar(Caso c)
        {
            return CasoDAO.Instancia.insertar(c);
        }

        public void actualizar(Caso c)
        {
            CasoDAO.Instancia.Actualizar(c);
        }


        public Dictionary<long, TipoCaso> obtenerTipos()
        {
            return CasoDAO.Instancia.obtenerTipos();
        }

        public Dictionary<long, EtapaCaso> obtenerEtapas()
        {
            return CasoDAO.Instancia.obtenerEtapas();
        }

         public Caso obtenerPorId(long id)
         {
             return CasoDAO.Instancia.obtenerPorId(id);
         }

         public List<Caso> obtenerTodosPorProyecto(long idProyecto)
         {
             return CasoDAO.Instancia.obtenerTodosPorProyecto(idProyecto);
         }
    }

}
