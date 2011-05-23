using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;

namespace GestPro.BussinesObjects.BussinesObjects
{
     public  class Sesion
    {

         protected static Sesion Instance = null;
        [MethodImpl(MethodImplOptions.Synchronized)]
        private static void CreateInstance()
        {
            if (Instance == null)
            {
                Instance = new Sesion();
            }
        }

        public static Sesion Instancia
        {
            get
            {
                CreateInstance();
                return Instance;
            }
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
