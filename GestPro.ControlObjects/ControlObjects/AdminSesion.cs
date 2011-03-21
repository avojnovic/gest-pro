using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Runtime.CompilerServices;
using GestPro.ControlObjects;
using GestPro.BussinesObjects.BussinesObjects;
using GestPro.DataAccessObjects.DataAccessObjects;

namespace GestPro.ControlObjects.ControlObjects
{
    public class AdminSesion
    {
        

        protected static AdminSesion Instance = null;
        [MethodImpl(MethodImplOptions.Synchronized)]
        private static void CreateInstance()
        {
            if (Instance == null)
            {
                Instance = new AdminSesion();
            }
        }

        public static AdminSesion Instancia
        {
            get
            {
                CreateInstance();
                return Instance;
            }
        }

        private Recurso _usuarioLogueado;

        public Recurso UsuarioLogueado
        {
            get { return _usuarioLogueado; }
            set { _usuarioLogueado = value; }
        }



         public void Inicializar()
         {
             //NpgsqlDb.Instancia.
            

             //AdminRecurso.Instancia.Inicializar(_db);
             //AdminProyecto.Instancia.Inicializar(_db);
             //AdminEtapaProyecto.Instancia.Inicializar(_db);
             //AdminCliente.Instancia.Inicializar(_db);
         }

         


    }
}
