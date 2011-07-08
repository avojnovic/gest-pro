using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;
using System.Runtime.CompilerServices;
using GestPro.BussinesObjects;
using System.Collections.Generic;
using GestPro.BussinesObjects.BussinesObjects;
using Npgsql;
using NpgsqlTypes;

namespace GestPro.DataAccessObjects.DataAccessObjects
{
    public class RecursoDAO
    {
       

         #region Singleton
        private static RecursoDAO Instance = null;
         private RecursoDAO() 
        {
            
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private static void CreateInstance()
        {
            if (Instance == null)
            {
                Instance = new RecursoDAO();
            }
        }

        public static RecursoDAO Instancia
        {
            get
            {
                CreateInstance();
                return Instance;
            }
        }
        #endregion
        private Dictionary<long, Recurso> _diccionarioRecursos;

        public Recurso obtenerRecursoPorId(long id)
        {
            string sql;
            sql =string.Format( @"SELECT recursos.id, recursos.nombre, recursos.apellido, recursos.email, recursos.usuario, recursos.pass, cargos.descripcion,cargos.sueldo,cargos.nombre as nombreCargo,cargos.id as idCargo FROM recursos LEFT JOIN cargos
                 ON recursos.id_cargo=cargos.id where recursos.id={0}
                order by recursos.nombre, recursos.apellido
                ",id.ToString());

            NpgsqlDb.Instancia.PrepareCommand(sql);
            NpgsqlDataReader dr = NpgsqlDb.Instancia.ExecuteQuery();
   
            Recurso r = new Recurso();
            while (dr.Read())
            {
               
                LoadFromDataReader(dr, r);

            }

            return r;
        }

        public Dictionary<long,Recurso> obtenerTodos()
        {

            string sql;
            sql = @"SELECT recursos.id, recursos.nombre, recursos.apellido, recursos.email, recursos.usuario, recursos.pass, cargos.descripcion,cargos.sueldo,cargos.nombre as nombreCargo,cargos.id as idCargo FROM recursos LEFT JOIN cargos
                 ON recursos.id_cargo=cargos.id where recursos.borrado=false
                order by recursos.nombre, recursos.apellido
                ";
          
           NpgsqlDb.Instancia.PrepareCommand(sql);
           NpgsqlDataReader dr = NpgsqlDb.Instancia.ExecuteQuery();
            Dictionary<long, Recurso> dicRecursos = new Dictionary<long, Recurso>();

            while (dr.Read())
            {
                Recurso r = new Recurso();

                LoadFromDataReader(dr, r);

                if (!dicRecursos.ContainsKey(r.Id))
                    dicRecursos.Add(r.Id,r );
            }

            _diccionarioRecursos = dicRecursos;
            return dicRecursos;

        }

        private static void LoadFromDataReader(NpgsqlDataReader dr, Recurso r)
        {

            if (!dr.IsDBNull(dr.GetOrdinal("id")))
                r.Id = long.Parse(dr["id"].ToString());

            if (!dr.IsDBNull(dr.GetOrdinal("nombre")))
                r.Nombre = dr.GetString(dr.GetOrdinal("nombre"));

            if (!dr.IsDBNull(dr.GetOrdinal("apellido")))
                r.Apellido = dr.GetString(dr.GetOrdinal("apellido"));

            if (!dr.IsDBNull(dr.GetOrdinal("email")))
                r.Email = dr.GetString(dr.GetOrdinal("email"));

            if (!dr.IsDBNull(dr.GetOrdinal("usuario")))
                r.Usuario = dr.GetString(dr.GetOrdinal("usuario"));

            if (!dr.IsDBNull(dr.GetOrdinal("pass")))
                r.Password = dr.GetString(dr.GetOrdinal("pass"));

            Cargo cargo = new Cargo();
            if (!dr.IsDBNull(dr.GetOrdinal("descripcion")))
                cargo.Descripcion = dr.GetString(dr.GetOrdinal("descripcion"));

            if (!dr.IsDBNull(dr.GetOrdinal("sueldo")))
                cargo.Sueldo = float.Parse(dr["sueldo"].ToString());

            if (!dr.IsDBNull(dr.GetOrdinal("nombreCargo")))
                cargo.Nombre = dr.GetString(dr.GetOrdinal("nombreCargo"));

            if (!dr.IsDBNull(dr.GetOrdinal("idCargo")))
                cargo.Id = long.Parse(dr["idCargo"].ToString());


            r.Cargo = cargo;
        }



        public long insertar(Recurso r)
        {
            long id = 0;
            string queryStr;
            
    
            queryStr = "INSERT INTO recursos(nombre, apellido, email, usuario, pass, borrado, id_cargo)";
            queryStr += " VALUES (:nombre, :apellido, :email, :usuario, :pass, :borrado, :id_cargo); select currval('recursos_id_seq');";

            NpgsqlDb.Instancia.PrepareCommand(queryStr);
            NpgsqlDb.Instancia.AddCommandParameter(":nombre", NpgsqlDbType.Varchar, ParameterDirection.Input, false, r.Nombre);
            NpgsqlDb.Instancia.AddCommandParameter(":apellido", NpgsqlDbType.Varchar, ParameterDirection.Input, false, r.Apellido);
            NpgsqlDb.Instancia.AddCommandParameter(":email", NpgsqlDbType.Varchar, ParameterDirection.Input, false, r.Email);
            NpgsqlDb.Instancia.AddCommandParameter(":usuario", NpgsqlDbType.Varchar, ParameterDirection.Input, false, r.Usuario);
            NpgsqlDb.Instancia.AddCommandParameter(":pass", NpgsqlDbType.Varchar, ParameterDirection.Input, false, r.Password);
            NpgsqlDb.Instancia.AddCommandParameter(":borrado", NpgsqlDbType.Boolean, ParameterDirection.Input, false, r.Borrado);
            NpgsqlDb.Instancia.AddCommandParameter(":id_cargo", NpgsqlDbType.Bigint, ParameterDirection.Input, false, r.Cargo.Id);

            try
            {
                id=NpgsqlDb.Instancia.ExecuteScalar();
            }
            catch (System.OverflowException Ex)
            {
                throw Ex;
            }

            return id;

        }

        public void actualizar(Recurso r)
        {
            string queryStr;


            queryStr = "UPDATE recursos SET nombre=:nombre, apellido=:apellido, email=:email, usuario=:usuario, pass=:pass, borrado=:borrado, id_cargo=:id_cargo";
            queryStr += " WHERE id=:id";

            NpgsqlDb.Instancia.PrepareCommand(queryStr);
            NpgsqlDb.Instancia.AddCommandParameter(":id", NpgsqlDbType.Bigint, ParameterDirection.Input, false, r.Id);
            NpgsqlDb.Instancia.AddCommandParameter(":nombre", NpgsqlDbType.Varchar, ParameterDirection.Input, false, r.Nombre);
            NpgsqlDb.Instancia.AddCommandParameter(":apellido", NpgsqlDbType.Varchar, ParameterDirection.Input, false, r.Apellido);
            NpgsqlDb.Instancia.AddCommandParameter(":email", NpgsqlDbType.Varchar, ParameterDirection.Input, false, r.Email);
            NpgsqlDb.Instancia.AddCommandParameter(":usuario", NpgsqlDbType.Varchar, ParameterDirection.Input, false, r.Usuario);
            NpgsqlDb.Instancia.AddCommandParameter(":pass", NpgsqlDbType.Varchar, ParameterDirection.Input, false, r.Password);
            NpgsqlDb.Instancia.AddCommandParameter(":borrado", NpgsqlDbType.Boolean, ParameterDirection.Input, false, r.Borrado);
            NpgsqlDb.Instancia.AddCommandParameter(":id_cargo", NpgsqlDbType.Bigint, ParameterDirection.Input, false, r.Cargo.Id);


            try
            {
                NpgsqlDb.Instancia.ExecuteNonQuery();

            }
            catch (System.OverflowException Ex)
            {
                throw Ex;
            }

        }


        public Recurso verificarUsuario(string usuario, string password)
        {

            Dictionary<long, Recurso> _dicRecursos = this.obtenerTodos();
            


            foreach (Recurso r in _dicRecursos.Values.ToList())
            {
                if (r.Usuario == usuario && r.Password == password)
                {
                    return r;
                }
            }

            return null;
        }

    }
}
