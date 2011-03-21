using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;
using System.Runtime.CompilerServices;
using GestPro.BussinesObjects;
using System.Collections.Generic;
using GestPro.BussinesObjects.BussinesObjects;
using GestPro.DataAccessObjects.DataAccessObjects;

namespace GestPro.ControlObjects.ControlObjects
{
    public class AdminRecurso
    {
        protected static AdminRecurso Instance = null;
        [MethodImpl(MethodImplOptions.Synchronized)]
        private static void CreateInstance()
        {
            if (Instance == null)
            {
                Instance = new AdminRecurso();
            }
        }

        public static AdminRecurso Instancia
        {
            get
            {
                CreateInstance();
                return Instance;
            }
        }


        private Dictionary<long,Recurso> _dicRecursos;
        public Recurso _recursoEdit;



        public Dictionary<long,Recurso> obtenerTodos()
        {
            _dicRecursos= RecursoDAO.Instancia.obtenerTodos();
            return _dicRecursos;
            
        }

        public Recurso verificarUsuario(string usuario, string password)
        {


                obtenerTodos(); 


            foreach (Recurso r in _dicRecursos.Values.ToList())
            {
                if (r.Usuario == usuario && r.Password == password)
                {
                    return r;
                }
            }

            return null;
        }

        public void insertar(Recurso r)
        {
            RecursoDAO.Instancia.insertar(r);
        }

        public void actualizar(Recurso r)
        {
            RecursoDAO.Instancia.actualizar(r);
        }

        public Recurso obtenerRecursoPorId(long id)
        {
            return RecursoDAO.Instancia.obtenerRecursoPorId(id);
        }

    }
}
