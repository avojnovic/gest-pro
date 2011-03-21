using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using GestPro.BussinesObjects.BussinesObjects;
using Npgsql;

namespace GestPro.DataAccessObjects.DataAccessObjects
{
    public class CargoDAO
    {
        #region Singleton
        private static CargoDAO Instance = null;
        private CargoDAO() 
        {
            
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private static void CreateInstance()
        {
            if (Instance == null)
            {
                Instance = new CargoDAO();
            }
        }

        public static CargoDAO Instancia
        {
            get
            {
                CreateInstance();
                return Instance;
            }
        }
        #endregion


        public Dictionary<long, Cargo> obtenerTodos()
        {

            string sql = "";
            sql += " SELECT id, descripcion, nombre, sueldo FROM cargos ";

            NpgsqlDb.Instancia.PrepareCommand(sql);
            NpgsqlDataReader dr = NpgsqlDb.Instancia.ExecuteQuery();
            Dictionary<long, Cargo> dicCargos = new Dictionary<long, Cargo>();

            while (dr.Read())
            {
                Cargo c = new Cargo();

                if (!dr.IsDBNull(dr.GetOrdinal("id")))
                    c.Id = long.Parse(dr["id"].ToString());

                if (!dr.IsDBNull(dr.GetOrdinal("descripcion")))
                    c.Descripcion = dr.GetString(dr.GetOrdinal("descripcion"));

                if (!dr.IsDBNull(dr.GetOrdinal("nombre")))
                    c.Nombre = dr.GetString(dr.GetOrdinal("nombre"));

                if (!dr.IsDBNull(dr.GetOrdinal("sueldo")))
                    c.Sueldo = float.Parse(dr["sueldo"].ToString());




                if (!dicCargos.ContainsKey(c.Id))
                    dicCargos.Add(c.Id, c);
            }


            return dicCargos;

        }

    }
}
