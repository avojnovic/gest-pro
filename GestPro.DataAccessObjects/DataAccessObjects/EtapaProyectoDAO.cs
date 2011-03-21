using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using GestPro.BussinesObjects.BussinesObjects;
using Npgsql;

namespace GestPro.DataAccessObjects.DataAccessObjects
{
    public class EtapaProyectoDAO
    {
         #region Singleton
        private static EtapaProyectoDAO Instance = null;
        private EtapaProyectoDAO() 
        {
            
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private static void CreateInstance()
        {
            if (Instance == null)
            {
                Instance = new EtapaProyectoDAO();
            }
        }

        public static EtapaProyectoDAO Instancia
        {
            get
            {
                CreateInstance();
                return Instance;
            }
        }
        #endregion


        public Dictionary<long, EtapaProyecto> obtenerTodos()
        {

            string sql = "SELECT id, nombre FROM etapa_proyecto;";

            NpgsqlDb.Instancia.PrepareCommand(sql);
            NpgsqlDataReader dr = NpgsqlDb.Instancia.ExecuteQuery();
            Dictionary<long, EtapaProyecto> dicEtapas = new Dictionary<long, EtapaProyecto>();

            while (dr.Read())
            {
                EtapaProyecto e = new EtapaProyecto();

                if (!dr.IsDBNull(dr.GetOrdinal("id")))
                    e.Id = long.Parse(dr["id"].ToString());

                if (!dr.IsDBNull(dr.GetOrdinal("nombre")))
                    e.Nombre = dr.GetString(dr.GetOrdinal("nombre"));


                if (!dicEtapas.ContainsKey(e.Id))
                    dicEtapas.Add(e.Id, e);
            }

            return dicEtapas;

        }

    }
}
