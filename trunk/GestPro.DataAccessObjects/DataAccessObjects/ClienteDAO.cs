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
using Npgsql;

namespace GestPro.DataAccessObjects.DataAccessObjects
{
    public class ClienteDAO
    {
           #region Singleton
        private static ClienteDAO Instance = null;
        private ClienteDAO() 
        {
            
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private static void CreateInstance()
        {
            if (Instance == null)
            {
                Instance = new ClienteDAO();
            }
        }

        public static ClienteDAO Instancia
        {
            get
            {
                CreateInstance();
                return Instance;
            }
        }
        #endregion

        private Dictionary<long, Cliente> _diccionarioClientes;

        public Cliente obtenerClientePorId(long id)
        {
            if (_diccionarioClientes == null)
                _diccionarioClientes = obtenerTodos();

            if (_diccionarioClientes.ContainsKey(id))
                return _diccionarioClientes[id];
            else
                return null;
        }

        public Dictionary<long, Cliente> obtenerTodos()
        {

            string sql = "";
            sql += " SELECT id, cod_postal, direccion, localidad, nombre_contacto, nombre_empresa, pais, telefono, email FROM clientes where borrado=false";

            NpgsqlDb.Instancia.PrepareCommand(sql);
            NpgsqlDataReader dr = NpgsqlDb.Instancia.ExecuteQuery();
            Dictionary<long, Cliente> dicClientes = new Dictionary<long, Cliente>();

            while (dr.Read())
            {
                Cliente c = new Cliente();

                if (!dr.IsDBNull(dr.GetOrdinal("id")))
                    c.Id = long.Parse(dr["id"].ToString());

                if (!dr.IsDBNull(dr.GetOrdinal("cod_postal")))
                    c.CodPostal = int.Parse(dr["cod_postal"].ToString());

                if (!dr.IsDBNull(dr.GetOrdinal("direccion")))
                    c.Direccion = dr.GetString(dr.GetOrdinal("direccion"));

                if (!dr.IsDBNull(dr.GetOrdinal("localidad")))
                    c.Localidad = dr.GetString(dr.GetOrdinal("localidad"));
              
                if (!dr.IsDBNull(dr.GetOrdinal("nombre_contacto")))
                    c.NombreContacto = dr.GetString(dr.GetOrdinal("nombre_contacto"));

                if (!dr.IsDBNull(dr.GetOrdinal("nombre_empresa")))
                    c.NombreEmpresa = dr.GetString(dr.GetOrdinal("nombre_empresa"));

                if (!dr.IsDBNull(dr.GetOrdinal("pais")))
                    c.Pais = dr.GetString(dr.GetOrdinal("pais"));

                if (!dr.IsDBNull(dr.GetOrdinal("telefono")))
                    c.Telefono = dr.GetString(dr.GetOrdinal("telefono"));

                if (!dr.IsDBNull(dr.GetOrdinal("email")))
                    c.Email = dr.GetString(dr.GetOrdinal("email"));

              
                if (!dicClientes.ContainsKey(c.Id))
                    dicClientes.Add(c.Id, c);
            }
            _diccionarioClientes = dicClientes;

            return dicClientes;

        }


    }
}
