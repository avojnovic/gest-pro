using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using GestPro.BussinesObjects.BussinesObjects;
using NpgsqlTypes;
using System.Data;
using Npgsql;

namespace GestPro.DataAccessObjects.DataAccessObjects
{
    public class RegAvanceDAO
    {
         #region Singleton
        private static RegAvanceDAO Instance = null;
        private RegAvanceDAO() 
        {
            
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private static void CreateInstance()
        {
            if (Instance == null)
            {
                Instance = new RegAvanceDAO();
            }
        }

        public static RegAvanceDAO Instancia
        {
            get
            {
                CreateInstance();
                return Instance;
            }
        }
        #endregion

        public List<RegistroAvance> obtenerRegAvanceProyecto(long idProyecto)
        {
            string query = "";
            query += "SELECT registro_avance_proyecto.id, registros_avance.descripcion,registros_avance.tiempo  FROM registro_avance_proyecto";
            query += " left join registros_avance on registro_avance_proyecto.id_registro_avance=registros_avance.id";
            query += " where registro_avance_proyecto.id_proyecto='" + idProyecto.ToString() + "' and registro_avance_proyecto.borrado=false";

            return obtenerRegAvance(query);
        }

        public List<RegistroAvance> obtenerRegAvanceCaso(long idCaso)
        {
            string query = "";
            query += "SELECT registro_avance_caso.id,registros_avance.descripcion,registros_avance.tiempo  FROM registro_avance_caso";
            query += " left join registros_avance on registro_avance_caso.id_registro_avance=registros_avance.id";
            query += " where registro_avance_caso.id_caso='" + idCaso.ToString() + "' and registro_avance_caso.borrado=false";

            return obtenerRegAvance(query);
        }

        private static List<RegistroAvance> obtenerRegAvance(string query)
        {
            NpgsqlDb.Instancia.PrepareCommand(query);
            NpgsqlDataReader dr = NpgsqlDb.Instancia.ExecuteQuery();
            List<RegistroAvance> _listaRegAvance = new List<RegistroAvance>();

            while (dr.Read())
            {
                RegistroAvance r = new RegistroAvance();
                r.Borrado = false;

                if (!dr.IsDBNull(dr.GetOrdinal("descripcion")))
                    r.Descripcion = dr.GetString(dr.GetOrdinal("descripcion"));

                if (!dr.IsDBNull(dr.GetOrdinal("tiempo")))
                    r.Tiempo = float.Parse(dr["tiempo"].ToString());

                _listaRegAvance.Add(r);
            }


            return _listaRegAvance;
        }

       

        public void insertar(RegistroAvance r, long idVinculacion, bool caso)
        {

            string queryStr1;
            string queryStr2;
            long idRegAvance = 0;

            queryStr1 = "INSERT INTO registros_avance(tiempo, descripcion)";
            queryStr1 += " VALUES (:tiempo, :descripcion);";

            NpgsqlDb.Instancia.PrepareCommand(queryStr1);
            NpgsqlDb.Instancia.AddCommandParameter(":tiempo", NpgsqlDbType.Double, ParameterDirection.Input, false, r.Tiempo);
            NpgsqlDb.Instancia.AddCommandParameter(":descripcion", NpgsqlDbType.Varchar, ParameterDirection.Input, false, r.Descripcion);
            //NpgsqlDb.Instancia.AddCommandParameter(":borrado", NpgsqlDbType.Boolean, ParameterDirection.Input, false, r.Borrado);


            try
            {
                NpgsqlDb.Instancia.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {
                throw Ex;
            }

             queryStr1 = "select max(id) as max from registros_avance";
             NpgsqlDataReader dr = NpgsqlDb.Instancia.ExecuteQuery(queryStr1);
             while (dr.Read())
            {
                if (!dr.IsDBNull(dr.GetOrdinal("max")))
                    idRegAvance = long.Parse(dr["max"].ToString());
            }

            if (idRegAvance != 0)
            {
                if (caso)
                {
                    queryStr2 = "INSERT INTO registro_avance_caso(id_caso, id_registro_avance,borrado)";
                    queryStr2 += " VALUES (:idvinc, :id_registro_avance,:borrado);";
                }
                else
                {
                    queryStr2 = "INSERT INTO registro_avance_proyecto(id_proyecto, id_registro_avance,borrado)";
                    queryStr2 += " VALUES (:idvinc, :id_registro_avance,:borrado);";
                }

                NpgsqlDb.Instancia.PrepareCommand(queryStr2);

                NpgsqlDb.Instancia.AddCommandParameter(":idvinc", NpgsqlDbType.Bigint, ParameterDirection.Input, false, idVinculacion);
                NpgsqlDb.Instancia.AddCommandParameter(":id_registro_avance", NpgsqlDbType.Bigint, ParameterDirection.Input, false, idRegAvance);
                NpgsqlDb.Instancia.AddCommandParameter(":borrado", NpgsqlDbType.Boolean, ParameterDirection.Input, false, r.Borrado);



                try
                {
                    NpgsqlDb.Instancia.ExecuteNonQuery();

                }
                catch (Exception Ex)
                {
                    throw Ex;
                }
            }
        }





    }
}
